// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : CommonData.cs
// 機能名      : 共通データ
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K24546 2012/02/20 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 3.1.0 2020/06/30
// 管理番号K27228 2020/10/19 サーバ帳票PDF化
// 管理番号K27445 2022/08/10 ログ管理強化
// 3.2.0 2023/03/31

using System;
using System.Text;

namespace Infocom.Allegro
{
	/// <summary>
	/// 各画面に共通する情報を提供します。
	/// </summary>
	[Serializable()]
	public class CommonData
	{
		#region Private Fields
		private string compCode;
		private string userName;
		private string pageID;
// 管理番号K27445 From
		private string userHostName;
// 管理番号K27445 To
		private TraceLevel traceLevel;
// 管理番号 K24546 From
		private string selectedLanguage;
		private const string BaseLang = "ja-JP";
// 管理番号 K24546 To
// 管理番号K27228 From
		private string loginAccount;
		private string empCode;
		private string deptCode;
		private string[] deptCodes;
// 管理番号K27228 To
		#endregion

		#region Constructors
// 管理番号 K24546 From
//		public CommonData(string compCode, string userName, string pageID) : this(compCode, userName, pageID, TraceLevel.Verbose)
//		{
//		}
		/// <summary>
		/// 共通情報のコンストラクタです。
		/// </summary>
		/// <param name="compCode">
		/// 自社コード
		/// </param>
		/// <param name="userName">
		/// ユーザ名
		/// </param>
		/// <param name="pageID">
		/// ページID
		/// </param>
		/// <param name="userHostName">
		/// クライアントホスト名
		/// </param>
// 管理番号K27445 From
//		public CommonData(string compCode, string userName, string pageID) : this(compCode, userName, pageID, TraceLevel.Verbose,BaseLang)
		public CommonData(string compCode, string userName, string pageID, string userHostName) : this(compCode, userName, pageID, userHostName, TraceLevel.Verbose,BaseLang)
// 管理番号K27445 To
		{
		}
// 管理番号 K24546 To
		/// <summary>
		/// 共通情報のコンストラクタです。
		/// </summary>
		/// <param name="compCode">
		/// 自社コード
		/// </param>
		/// <param name="userName">
		/// ユーザ名
		/// </param>
		/// <param name="pageID">
		/// ページID
		/// </param>
		/// <param name="traceLevel">
		/// トレースレベル
		/// </param>
		/// <param name="userHostName">
		/// クライアントホスト名
		/// </param>
// 管理番号K27445 From
//		public CommonData(string compCode, string userName, string pageID, TraceLevel traceLevel)
		public CommonData(string compCode, string userName, string pageID, string userHostName, TraceLevel traceLevel)
// 管理番号K27445 To
		{
			this.compCode = compCode;
			this.userName = userName;
			this.pageID = pageID;
// 管理番号K27445 From
			this.userHostName = userHostName;
// 管理番号K27445 To
			this.traceLevel = traceLevel;
		}
// 管理番号 K24546 From
		/// <summary>
		/// 共通情報のコンストラクタです。
		/// </summary>
		/// <param name="compCode">
		/// 自社コード
		/// </param>
		/// <param name="userName">
		/// ユーザ名
		/// </param>
		/// <param name="pageID">
		/// ページID
		/// </param>
		/// <param name="userHostName">
		/// クライアントホスト名
		/// </param>
		/// <param name="selectedLanguage">
		/// 選択言語
		/// </param>
// 管理番号K27445 From
//		public CommonData(string compCode, string userName, string pageID, string selectedLanguage) : this(compCode, userName, pageID, TraceLevel.Verbose, selectedLanguage)
		public CommonData(string compCode, string userName, string pageID, string userHostName, string selectedLanguage) : this(compCode, userName, pageID, userHostName, TraceLevel.Verbose, selectedLanguage)
// 管理番号K27445 To
		{
		}

		/// <summary>
		/// 共通情報のコンストラクタです。
		/// </summary>
		/// <param name="compCode">
		/// 自社コード
		/// </param>
		/// <param name="userName">
		/// ユーザ名
		/// </param>
		/// <param name="pageID">
		/// ページID
		/// </param>
		/// <param name="userHostName">
		/// クライアントホスト名
		/// </param>
		/// <param name="traceLevel">
		/// トレースレベル
		/// </param>
		/// <param name="selectedLanguage">
		/// 選択言語
		/// </param>
// 管理番号K27445 From
//		public CommonData(string compCode, string userName, string pageID, TraceLevel traceLevel, string selectedLanguage)
		public CommonData(string compCode, string userName, string pageID, string userHostName, TraceLevel traceLevel, string selectedLanguage)
// 管理番号K27445 To
		{
			this.compCode = compCode;
			this.userName = userName;
			this.pageID = pageID;
// 管理番号K27445 From
			this.userHostName = userHostName;
// 管理番号K27445 To
			this.traceLevel = traceLevel;
			this.selectedLanguage = selectedLanguage;
		}
// 管理番号 K24546 To
// 管理番号K27228 From
		/// <summary>
		/// 共通情報のコンストラクタです。
		/// </summary>
		/// <param name="compCode">
		/// 自社コード
		/// </param>
		/// <param name="userName">
		/// ユーザ名
		/// </param>
		/// <param name="pageID">
		/// ページID
		/// </param>
		/// <param name="userHostName">
		/// クライアントホスト名
		/// </param>
		/// <param name="traceLevel">
		/// トレースレベル
		/// </param>
		/// <param name="selectedLanguage">
		/// 選択言語
		/// </param>
		/// <param name="loginAccount">
		/// ログインアカウント
		/// </param>
		/// <param name="empCode">
		/// 社員コード
		/// </param>
		/// <param name="deptCode">
		/// 部門コード
		/// </param>
		/// <param name="deptCodes">
		/// 部門コード（配列）
		/// </param>
// 管理番号K27445 From
//		public CommonData(string compCode, string userName, string pageID, TraceLevel traceLevel, string selectedLanguage, string loginAccount, string empCode, string deptCode, string[] deptCodes)
		public CommonData(string compCode, string userName, string pageID, string userHostName, TraceLevel traceLevel, string selectedLanguage, string loginAccount, string empCode, string deptCode, string[] deptCodes)
// 管理番号K27445 To
		{
			this.compCode = compCode;
			this.userName = userName;
			this.pageID = pageID;
// 管理番号K27445 From
			this.userHostName = userHostName;
// 管理番号K27445 To
			this.traceLevel = traceLevel;
			this.selectedLanguage = selectedLanguage;
			this.loginAccount = loginAccount;
			this.empCode = empCode;
			this.deptCode = deptCode;
			this.deptCodes = deptCodes;
		}
// 管理番号K27228 To
		#endregion

		#region Properties
		/// <summary>
		/// ページを開いているユーザの自社コード。
		/// </summary>
		public string CompCode
		{
			get {return compCode;}
		}

		/// <summary>
		/// ページを開いているユーザのユーザ名。
		/// </summary>
		public string UserName
		{
			get {return userName;}
		}

		/// <summary>
		/// 開いている画面のページID。
		/// </summary>
		public string PageID
		{
			get {return pageID;}
		}

// 管理番号K27445 From
		/// <summary>
		/// GRANDITにアクセスしているクライアントのホスト名
		/// </summary>
		public string UserHostName
		{
			get { return userHostName; }
		}
// 管理番号K27445 To

		/// <summary>
		/// セッションごとに指定されたトレースレベル。
		/// </summary>
		public TraceLevel TraceLevel
		{
			get {return traceLevel;}
		}
// 管理番号 K24546 From
		/// <summary>
		/// ページを開いているセッションの言語設定。
		/// </summary>
		public string SelectedLanguage
		{
			get {return selectedLanguage;}
		}
		// 管理番号 K24546 To
// 管理番号K27228 From
		/// <summary>
		/// ページを開いているユーザのログインアカウント。
		/// </summary>
		public string LoginAccount
		{
			get { return loginAccount; }
		}

		/// <summary>
		/// ページを開いているユーザの社員コード。
		/// </summary>
		public string EmpCode
		{
			get { return empCode; }
		}

		/// <summary>
		/// ページを開いているユーザの部門コード。
		/// </summary>
		public string DeptCode
		{
			get { return deptCode; }
		}

		/// <summary>
		/// ページを開いているユーザの部門コード（配列）。
		/// </summary>
		public string[] DeptCodes
		{
			get { return deptCodes; }
		}
// 管理番号K27228 To
		#endregion

		#region Methods
		/// <summary>
		/// 現在の<see cref="CommonData"/>を表す文字列を返します。
		/// </summary>
		/// <returns>
		/// 現在の<see cref="CommonData"/>を表す文字列。
		/// </returns>
		public override string ToString()
		{
// 			return new StringBuilder("自社コード: ", 128).Append(compCode).Append("\r\nユーザ名: ").Append(userName).Append("\r\nページID: ").Append(pageID).Append("\r\nトレースレベル: ").Append(traceLevel.ToString()).ToString(); //K24546
			return new StringBuilder(MultiLanguage.Get("CM_AM001065"), 128).Append(compCode).Append(MultiLanguage.Get("CM_AM000422")).Append(userName).Append(MultiLanguage.Get("CM_AM000421")).Append(pageID).Append(MultiLanguage.Get("CM_AM000420")).Append(traceLevel.ToString()).ToString();
		}
		#endregion
	}
}
