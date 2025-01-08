// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : TerminatePageHandler.cs
// 機能名      : 画面の終了処理を行うHTTPハンドラ
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/02/13 UI見直し
// 3.0.0 2018/04/30

using System.Web;
using System.Web.SessionState;

namespace Infocom.Allegro.Web.HttpHandler
{
	/// <summary>
	/// 画面の終了処理を行うHTTPハンドラ
	/// </summary>
	public class TerminatePageHandler : IHttpHandler, IRequiresSessionState
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
					if (TokenManager.ValidateToken(false))
					{
						// 画面トークンをセッションから破棄する
						var terminateToken = context.Request.QueryString["__terminateToken"];
						TokenManager.RemoveToken(terminateToken);
					}
					break;
			}
		}
	}
}
