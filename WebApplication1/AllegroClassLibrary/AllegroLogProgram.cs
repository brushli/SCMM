// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : AllegroLogProgram.cs
// 機能名      : プログラム利用ログ出力
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 管理番号K20128 2007/04/30 プログラム操作ログ出力
// 1.5.1 2007/06/30
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25879 2016/02/15 マイナンバー対応
// 管理番号 B26049 2016/02/24 プログラム利用ログ照会にてパスワードが表示されてしまう
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/22 UI見直し
// 3.0.0 2018/04/30
// 3.1.0 2020/06/30
// 管理番号K27230 2021/09/06 脆弱性対応
// 管理番号K27445 2022/02/15 ログ管理強化
// 3.2.0 2023/03/31

using System;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Diagnostics;
using Infocom.Allegro;
using Infocom.Allegro.BL.SqlClient;

namespace Infocom.Allegro
{
	/// <summary>
	/// プログラム利用ログ出力に関する共通機能を提供します。このクラスは継承できません。
	/// </summary>
	public sealed class AllegroLogProgram
	{
		#region Private Fields
		private const string HTTP_GET = "GET";
		private const string HTTP_POST = "POST";
		private const string KEY_VIEWSTATE= "__VIEWSTATE";
		#endregion

		#region Constructors
		private AllegroLogProgram()
		{
		}
		#endregion

		#region Methods
		/// <summary>
		/// プログラム利用ログを出力します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="request">
		/// リクエスト情報
		/// </param>
		/// <param name="loginAccount">
		/// ログインアカウント
		/// </param>
		/// <param name="isPostLogWriteToDatabase">
		/// プログラム操作ログ（HTTP_POSTメソッド）出力フラグ
		/// </param>
		/// <param name="isGetLogWriteToDatabase">
		/// プログラム操作ログ（HTTP_GETメソッド）出力フラグ
		/// </param>
		public static void Write(CommonData commonData, HttpRequest request, string loginAccount, bool isPostLogWriteToDatabase, bool isGetLogWriteToDatabase)
		{
			StringBuilder sb = new StringBuilder();

			string userHostAddress = request.UserHostAddress;
			string userHostName = request.UserHostName;
			string httpMethod = request.HttpMethod.ToUpper();
			string url = request.Url.ToString();
			string logEvent = string.Empty;
			string logComment = string.Empty;

			string eventTarget = request.Form["__EVENTTARGET"];
			string lastActiveControl = request.Form["__LastActiveControl"];
// 管理番号K27445 From
			string functionKeyControlName = request.Form["__FunctionKeyControlName"];
			string functionKeyControlValue = request.Form["__FunctionKeyControlValue"];
			string xbUrl = (commonData.PageID.Substring(0, 2) == "WS")
							? request.Url.LocalPath.Replace(request.ApplicationPath, string.Empty)
							: string.Empty;
			string xbUrlReferrer = (commonData.PageID.Substring(0, 2) == "WS")
							? request.UrlReferrer.LocalPath.Replace(request.ApplicationPath, string.Empty)
							: string.Empty;
// 管理番号K27445 To

//管理番号 K25879 From
//管理番号 B26049 From
//			string[] mynumberPage = new string[] { "CM_MS_15_S02", "CM_MS_15_S03", "CM_MS_15_S07" };	//個人番号登録（社員家族）,（管理者用）,（社外）
			//個人番号登録（社員家族）,（管理者用）,（社外）,パスワード変更,ログインアカウント登録,ECパスワード変更
			string[] checkPage = new string[] { "CM_MS_15_S02", "CM_MS_15_S03", "CM_MS_15_S07", "CM_AC_03_S02", "CM_AC_03_S05", "SC_EC_01_S06" };
//管理番号 B26049 To
			bool targetpage = false;
			bool targetkey = false;
//管理番号 K25879 To

			if (httpMethod == HTTP_GET && isGetLogWriteToDatabase)
			{
// 管理番号K26528 From
//				logEvent = "showModalDialog";
				logEvent = "openPage";
// 管理番号K26528 To
			}
			else if (httpMethod == HTTP_POST && isPostLogWriteToDatabase)
			{
				if ((eventTarget != null) && (eventTarget != string.Empty))
				{
					logEvent = eventTarget;
				}
				else
				{
// 管理番号K27445 From
					if ((functionKeyControlName != null) && (functionKeyControlName != string.Empty))
					{
						logEvent = functionKeyControlName + ":" + functionKeyControlValue;
					}
					else
					{
// 管理番号K27445 To
						if ((lastActiveControl != null) && (lastActiveControl != string.Empty))
						{
							logEvent = lastActiveControl;
						}
// 管理番号K27445 From
					}
// 管理番号K27445 To
				}
			}
			else
			{
				return;
			}

			foreach(string key in request.QueryString.Keys)
			{
				sb.Append(key);
				sb.Append("(QueryString)=");
				sb.Append(request.QueryString[key]);
				sb.Append("\t");
			}
//管理番号 K25879 From
//			foreach(string key in request.Form.Keys)
//			{
//				if (key != KEY_VIEWSTATE)
//				{
//					sb.Append(key);
//					sb.Append("(Form)=");
//					sb.Append(request.Form[key]);
//					sb.Append("\t");
//				}
//			}
//管理番号 B26049 From
//			//マイナンバー対象画面かチェックする
//			foreach (string pagecode in mynumberPage)
			//対象画面かチェックする
			foreach (string pagecode in checkPage)
//管理番号 B26049 To
			{
				if (pagecode.Equals(commonData.PageID))
				{
					targetpage = true;
					break;
				}
			}

			if (!targetpage || request.Form["NumberControlIDs"] == string.Empty)
			{
				//キーが無かった場合
				foreach (string key in request.Form.Keys)
				{
					if (key != KEY_VIEWSTATE)
					{
						sb.Append(key);
						sb.Append("(Form)=");
						sb.Append(request.Form[key]);
						sb.Append("\t");
					}
				}
			}
			else
			{
				string[] numberId = request.Form["NumberControlIDs"].Split(Convert.ToChar(","));
				//対象ページで且つ、個人番号が登録されるコントロールを指定している場合
				foreach (string key in request.Form.Keys)
				{
					if (key != KEY_VIEWSTATE)
					{
						targetkey = false;
						foreach (string targetcontrol in numberId)
						{
							//検索コントロール名を含む場合
							if (key.IndexOf(targetcontrol) >= 0)
							{
								targetkey = true;
								break;
							}
						}
						sb.Append(key);
						sb.Append("(Form)=");
						sb.Append(targetkey ? "" : request.Form[key]);
						sb.Append("\t");
					}
				}
			}
//管理番号 K25879 To

			logComment = sb.ToString();

			sb = new StringBuilder();
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_WriteLogProgram]"));
//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			cn.Open();

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
			cm.CommandType = CommandType.StoredProcedure;
			cm.Parameters.Add("@REMOTE_ADDR", SqlDbType.NVarChar, 15).Value = ConvertDBData.ToNVarChar(userHostAddress);
			cm.Parameters.Add("@REMOTE_USER", SqlDbType.NVarChar, 100).Value = ConvertDBData.ToNVarChar(userHostName);
			cm.Parameters.Add("@REQUEST_METHOD",SqlDbType.NVarChar, 50).Value = ConvertDBData.ToNVarChar(httpMethod);
			cm.Parameters.Add("@URL", SqlDbType.NVarChar, 500).Value = ConvertDBData.ToNVarChar(url);
			cm.Parameters.Add("@LOG_EVENT", SqlDbType.NVarChar, 100).Value = ConvertDBData.ToNVarChar(logEvent);
			cm.Parameters.Add("@LOG_COMMENT", SqlDbType.NVarChar,4000).Value = ConvertDBData.ToNVarChar(logComment);
			cm.Parameters.Add("@INSERT_USER_LOGIN_ACCOUT", SqlDbType.NVarChar, 20).Value = ConvertDBData.ToNVarChar(loginAccount);
			cm.Parameters.Add("@INSERT_USER_NAME", SqlDbType.NVarChar, 50).Value = ConvertDBData.ToNVarChar(commonData.UserName);
			cm.Parameters.Add("@INSERT_PRG_NAME", SqlDbType.NVarChar, 50).Value = ConvertDBData.ToNVarChar(commonData.PageID);
// 管理番号K27445 From
			cm.Parameters.Add("@XB_URL", SqlDbType.NVarChar, 500).Value = ConvertDBData.ToNVarChar(xbUrl);
			cm.Parameters.Add("@XB_URL_REFERRER", SqlDbType.NVarChar, 500).Value = ConvertDBData.ToNVarChar(xbUrlReferrer);
			cm.Parameters.Add("@INSERT_USER_CODE", SqlDbType.NVarChar, 10).Value = ConvertDBData.ToNVarChar(commonData.EmpCode);
// 管理番号K27445 To
			try
			{
				cm.ExecuteNonQuery();
			}
			catch (SqlException ex)
			{
				throw new AllegroException(commonData, ex).WriteLog();
			}
			finally
			{
				cn.Close();
			}
		}
		#endregion
	}
}
