// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : FileUploadHandler.cs
// 機能名      : ファイルアップロードHTTPハンドラ
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/03/31 UI見直し
// 3.0.0 2018/04/30

using System.Web;
using System.Web.SessionState;
using Infocom.Allegro.Web.WebControls;

namespace Infocom.Allegro.Web.HttpHandler
{
	/// <summary>
	/// ファイルアップロードHTTPハンドラ
	/// </summary>
	public class FileUploadHandler : IHttpHandler, IRequiresSessionState
	{
		/// <summary>
		/// ドラッグアンドドロップによってアップロードされたファイルを受け渡すセッションオブジェクトのキー値。
		/// </summary>
		private static readonly string SessionKey = "FileUploadHandler_UploadedFiles:";

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
			var name = context.Request.QueryString["name"];
			var sessionKey = FileUploadHandler.CreateSessionKey(name);
			switch (context.Request.HttpMethod)
			{
				case "PUT":
					context.Session[sessionKey] = context.Request.Files[name];
					break;
				case "DELETE":
					context.Session.Remove(sessionKey);
					break;
			}
		}

		/// <summary>
		/// アップロードされたファイルを格納するセッションオブジェクトのキー値を生成します。
		/// </summary>
		/// <param name="fileUploader"></param>
		/// <returns></returns>
		internal static string CreateSessionKey(FileUploader fileUploader)
		{
			return CreateSessionKey(fileUploader.InputFile.UniqueID);
		}

		/// <summary>
		/// アップロードされたファイルを格納するセッションオブジェクトのキー値を生成します。
		/// </summary>
		/// <param name="baseID"></param>
		/// <returns></returns>
		private static string CreateSessionKey(string baseID)
		{
			return SessionKey + baseID;
		}
	}
}
