// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : TokenHandler.cs
// 機能名      : 画面トークンを生成するHTTPハンドラ
// Version     : 3.1.0
// Last Update : 2020/06/30
// Copyright (c) 2004-2020 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/02/13 UI見直し
// 3.0.0 2018/04/30
// 3.1.0 2020/06/30
// 管理番号K27241 2020/08/26 開発環境バージョンアップ対応

using System.Web;
using System.Web.SessionState;

namespace Infocom.Allegro.Web.HttpHandler
{
	/// <summary>
	/// 画面トークンを生成するHTTPハンドラ
	/// </summary>
	public class TokenHandler : IHttpHandler, IRequiresSessionState
	{
		/// <summary>
		/// 別の要求で<see cref="IHttpHandler" />インスタンスを使用できるかどうか。
		/// </summary>
		public bool IsReusable
		{
			get { return false; }
		}

		/// <summary>
		/// <see cref="IHttpHandler" />インターフェイスを実装するカスタムHTTPハンドラによって、HTTPリクエストの処理を有効にします。
		/// </summary>
		/// <param name="context"><see cref="HttpContext" />オブジェクト</param>
		public void ProcessRequest(HttpContext context)
		{
			switch (context.Request.HttpMethod)
			{
				case "GET":
					var token = TokenManager.GenerateToken();
					context.Response.Clear();
					context.Response.Cache.SetNoStore();
					context.Response.Write(token);
					context.Response.Flush();
// 管理番号K27241 From
//					context.Response.End();
					context.Response.SuppressContent = true;
					HttpContext.Current.ApplicationInstance.CompleteRequest();
// 管理番号K27241 To
					break;
			}
		}
	}
}
