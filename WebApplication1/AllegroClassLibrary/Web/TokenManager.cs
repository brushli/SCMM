// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : TokenManager.cs
// 機能名      : 画面トークン管理クラス
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/02/13 UI見直し
// 3.0.0 2018/04/30
// 管理番号B27167 2020/03/24 セキュリティ強化対応
// 3.1.0 2020/06/30
// 管理番号K27241 2020/08/26 開発環境バージョンアップ対応
// 管理番号K27230 2021/06/15 脆弱性対応
// 管理番号K27445 2022/08/10 ログ管理強化
// 3.2.0 2023/03/31

using System;
// 管理番号K27230 From
using System.Collections.Specialized;
using System.Linq;
// 管理番号K27230 To
using System.Text.RegularExpressions;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
// 管理番号B27167 From
using System.Text;
using System.Security.Cryptography;
// 管理番号B27167 To

namespace Infocom.Allegro.Web
{
	/// <summary>
	/// 画面トークン管理クラス
	/// </summary>
	public static class TokenManager
	{
		/// <summary>
		/// 画面に埋め込まれた、もしくはクエリ文字列に付与された画面トークンを表すID。
		/// </summary>
		public static readonly string HiddenFieldName = "__token";

		/// <summary>
		/// 画面トークンをセッションに格納する際に使用するオブジェクト。
		/// </summary>
		private static readonly object TokenObject = new object();

		/// <summary>
		/// 画面に埋め込まれた、もしくはクエリ文字列に付与された画面トークン。
		/// </summary>
		private static string EmbeddedToken
		{
			get { return IsPostBack ? Request.Form[HiddenFieldName] : Request.QueryString[HiddenFieldName]; }
		}

		/// <summary>
		/// 画面トークンの判定が失敗した場合のエラーメッセージ。
		/// </summary>
		private static string ErrorMessage
		{
			// 予期しない操作が行われました。
			get { return MultiLanguage.Get("CM_AM001761"); }
		}

		/// <summary>
		/// HTTPリクエストがポストバックによるものかどうか。
		/// </summary>
		private static bool IsPostBack
		{
			get
			{
				// 【参考情報】Server.Transferによる遷移の場合、HttpMethodはPOSTだがIsPostBackはfalseとなる。
				var page = HttpContext.Current.CurrentHandler as Page;
				return (page != null) && page.IsPostBack;
			}
		}

		private static HttpRequest Request
		{
			get { return HttpContext.Current.Request; }
		}

		private static HttpResponse Response
		{
			get { return HttpContext.Current.Response; }
		}

		private static HttpServerUtility Server
		{
			get { return HttpContext.Current.Server; }
		}

		private static HttpSessionState Session
		{
			get { return HttpContext.Current.Session; }
		}

		/// <summary>
		/// 画面トークンをURLに付加します。
		/// </summary>
		/// <param name="url">画面トークンを付与するURL。</param>
		public static string AppendTokenToUrl(string url)
		{
			var token = GenerateToken();
			// 既に画面トークンが含まれていた場合は削除する
			url = Regex.Replace(url, @"(?<=\?|&)" + HiddenFieldName + "=.*?(&|$)", string.Empty);
			if (!url.Contains("?"))
			{
				url += "?";
			}
			else if (!url.EndsWith("&", StringComparison.Ordinal))
			{
				url += "&";
			}
			url += HiddenFieldName + "=" + token;
			return url;
		}

		/// <summary>
		/// 画面に埋め込まれた画面トークンとサーバ側で保持している画面トークンの一致を判定します。
		/// <para>※このメソッドの実行により、サーバ側の画面トークンは破棄されます。</para>
		/// </summary>
		/// <param name="redirectWhenInvalid">判定失敗時にリダイレクトするかどうか。</param>
		/// <returns>画面に埋め込まれた画面トークンとサーバ側で保持している画面トークンが一致した場合、<c>true</c>。</returns>
		public static bool ValidateToken(bool redirectWhenInvalid)
		{
			var token = EmbeddedToken;
			var invalidToken = string.IsNullOrEmpty(token) || Session[token] == null;
			RemoveToken(token);

			if (invalidToken)
			{
				WriteInvalidLog();
				if (redirectWhenInvalid)
				{
					Response.ClearContent();
					Response.ClearHeaders();
					// 204 No Content
					Response.StatusCode = 204;
// 管理番号K27241 From
//					Response.End();
					Response.Flush();
					Response.SuppressContent = true;
					HttpContext.Current.ApplicationInstance.CompleteRequest();
// 管理番号K27241 To
				}
			}

			return !invalidToken;
		}

		/// <summary>
		/// 画面トークンをセッションに格納する
		/// </summary>
		/// <returns></returns>
		internal static string GenerateToken()
		{
			var token = HttpServerUtility.UrlTokenEncode(Guid.NewGuid().ToByteArray());
			Session[token] = TokenObject;
			return token;
		}

		/// <summary>
		/// 画面トークンを隠しフィールドに登録する
		/// </summary>
		/// <param name="pageBase"></param>
		internal static void RegisterToken(PageBase pageBase)
		{
			var token = GenerateToken();
			pageBase.ClientScript.RegisterHiddenField(HiddenFieldName, token);
		}

		/// <summary>
		/// セッション上の比較用画面トークンを破棄する
		/// </summary>
		/// <param name="token"></param>
		internal static void RemoveToken(string token)
		{
			if (!string.IsNullOrEmpty(token))
			{
				Session.Remove(token);
			}
		}

		/// <summary>
		/// <c>Response.Redirect</c>の代替となるメソッドです。
		/// <para><c>Response.Redirect</c>は使用しないでください。</para>
		/// </summary>
		/// <param name="url"></param>
		internal static void ResponseRedirect(string url)
		{
			Response.Redirect(AppendTokenToUrl(url));
		}

		/// <summary>
		/// <c>Server.Transfer</c>の代替となるメソッドです。
		/// <para><c>Server.Transfer</c>は使用しないでください。</para>
		/// </summary>
		/// <param name="path"></param>
		internal static void ServerTransfer(string path)
		{
			if (!path.Contains("?"))
			{
				// Server.Transferはurlにクエリ文字列が含まれない場合遷移元画面のクエリ文字列を保持する。
				// urlにクエリ文字列が含まれない状態で画面トークンを付与した場合は遷移元画面のクエリ文字列が
				// 保持されなくなってしまうため、ここでクエリ文字列の再構築を行う。
				path += "?" + Request.QueryString;
			}
// 管理番号K27230 From
//			Server.Transfer(AppendTokenToUrl(path));
			path = AppendTokenToUrl(path);
			// クエリ部分の値に対してURLエンコードを行う
			NameValueCollection nvc = HttpUtility.ParseQueryString(path.Substring(path.IndexOf("?") + 1));
			string query = string.Join("&",
				nvc.AllKeys.Where(key => !string.IsNullOrWhiteSpace(nvc[key])).Select(
					key => string.Join("&", nvc.GetValues(key).Select(
						val => string.Format("{0}={1}", HttpUtility.UrlEncode(key), HttpUtility.UrlEncode(val))))));

			path = HttpUtility.UrlEncode(path.Substring(0, path.IndexOf("?"))) + "?" + query;
			Server.Transfer(path);
// 管理番号K27230 To
		}

		/// <summary>
		/// 画面トークンの判定が失敗した場合のログ出力を行います。
		/// </summary>
		private static void WriteInvalidLog()
		{
			var myCompCode = (string)Session["MyCompCode"];
			var empShortName = (string)Session["EmpShortName"];
// 管理番号K27445 From
			var userHostName = (string)Session["UserHostName"];
// 管理番号K27445 To
			// CommonDataが作成できない場合はログ出力自体不可となるのでこのメソッドは何もしない
			if (myCompCode != null && empShortName != null)
			{
// 管理番号K27445 From
//				var commonData = new CommonData(myCompCode, empShortName, typeof(TokenManager).Name);
				var commonData = new CommonData(myCompCode, empShortName, typeof(TokenManager).Name, userHostName);
// 管理番号K27445 To
				AllegroLog.Write(commonData, ExceptionLevel.Error, ErrorMessage + Environment.NewLine + "URL: " + Request.Url);
			}
		}
	}

// 管理番号B27167 From
	public static class SecureTokenManager
	{
		private static int TOKEN_LENGTH = 16; //16*2=32バイト

		//32バイトのトークンを作成
		public static string GetSecureToken()
		{
			byte[] secureToken = new byte[TOKEN_LENGTH];

			RNGCryptoServiceProvider gen = new RNGCryptoServiceProvider();
			gen.GetBytes(secureToken);

			StringBuilder buf = new StringBuilder();

			for (int i = 0; i < secureToken.Length; i++)
			{
				buf.AppendFormat("{0:x2}", secureToken[i]);
			}
			return buf.ToString();
		}
	}
// 管理番号B27167 To
}
