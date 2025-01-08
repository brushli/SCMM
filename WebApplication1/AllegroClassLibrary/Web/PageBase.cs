// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : PageBase.cs
// 機能名      : 画面基底クラス
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// Plat015 例外のエラー判断処理(連続ポストバックによるViewState無効不具合対策) 2004/12/07
// 1.3.0 2004/12/31
// 管理番号K16187 2005/08/09 支払機能拡張
// 管理番号K16188 2005/08/09 与信管理機能拡張
// 管理番号 B16215 2005/09/12 委託販売後の在庫管理改善
// 1.4.0 2005/10/31
// 管理番号K16590 2005/11/25 管理会計機能改善【日付】
// 管理番号K16671 2005/11/29 貿易機能改善(参照コードの文言)対応
// 管理番号K16672 2005/11/29 貿易機能改善(船積帳票追加)対応
// 管理番号K16589 2006/01/05 管理会計機能改善【勘定明細】
// 管理番号K16943 2006/01/05 FI0507下期機能改善【経理】仕訳データ取込
// 1.5.0 2006/03/31
// 1.4.1 2006/09/30
// 管理番号 P19346 2006/12/13 ViewState/Session入替え処理機能の追加
// 管理番号 K20128 2007/04/30 プログラム操作ログ出力
// 1.5.1 2007/06/30
// 管理番号 K20684 2007/07/02 承認機能追加
// 1.5.2 2007/10/31
// 管理番号 B21203 2008/03/03 未実現利益対応(自社マスタカラム追加)
// 管理番号 K22199 2008/10/03 債権債務締入力制御
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 管理番号 K22156 2008/08/26 1ページ内に複数のCM_KeyDownScript.jsが定義される問題を修正
// 管理番号 K22158 2008/08/26 ポストバック時にフォーカスが予期しない項目へ移動してしまう問題を修正
// 管理番号 B21419 2009/03/10 ViewStateエラー発生時の例外処理対応
// 管理番号 K22327 2009/01/20 【資産改善第2段階】期末簿価での減損処理
// 管理番号 K22328 2009/01/20 【資産改善第2段階】減損後の除売却仕訳（直接控除/間接控除対応）
// 管理番号 K22332 2009/01/20 【資産改善第2段階】自動仕訳(計上日)
// 1.6.0 2009/09/30
// 管理番号 B22218 2009/08/26 ViewStateエラー発生時の例外処理対応
// 管理番号 K23209 2010/01/04 汎用出力非同期化対応
// 管理番号 K23672 2010/08/12 外貨建円転決済対応
// 管理番号 B23537 2010/10/27 .NetFrameworkランゲージパックによるViewStateエラー発生時の例外処理対応
// 管理番号 K24282 2011/12/12 客注番号表示対応
// 管理番号 K24276 2011/12/20 入荷省略初期値対応（海外仕入の入荷省略の初期値追加）
// 管理番号 K24284 2011/12/26 プロジェクト必須対応
// 管理番号 K24269 2012/01/17 社員EBデータ作成対応
// 管理番号 K24390 2012/01/30 ユーザビリティ対応
// 管理番号 K24383 2012/02/02 見込諸掛仕訳制御対応
// 管理番号 K24387 2012/02/08 購買機能拡張
// 管理番号 B23962 2012/04/11 セッションタイムアウト時のエラーハンドリング不正対応
// 管理番号 B24424 2012/04/18 セッションタイムアウトをページ読込み時にも行うようにする。
// 2.0.0 2012/10/31
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 管理番号 K24790 2013/05/08 軽減税率対応
// 管理番号 B25191 2013/10/18 ドリルスルー不備対応
// 管理番号 K25321 2014/03/26 電子債権対応
// 管理番号 K25482 2014/06/25 自動フォーカス制御
// 2.2.0 2014/10/31
// 管理番号 K25647 2015/03/12 項目桁数拡張
// 管理番号 K25902 2015/09/30 データグリッドCSV出力機能追加対応
// 管理番号 K25671 2015/10/07 返品時の未引当受注数の表示
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26344 2016/08/31 汎用出力拡張機能
// 管理番号K26528 2017/02/13 UI見直し
// 管理番号K26508 2017/06/14 アクセス権限の改善
// 管理番号K26524 2018/01/15 受発注入力の倉庫初期表示変更
// 3.0.0 2018/04/30
// 管理番号B27044 2020/04/01 ダウンロードページの呼び出し時に画面が操作不能となる不具合対応
// 管理番号B27167 2020/03/24 セキュリティ強化対応
// 管理番号B27183 2020/03/24 セキュリティ強化追加対応
// 管理番号K27058 2019/08/21 汎用区分追加
// 管理番号K27059 2019/09/19 マスタの絞り込み機能追加
// 管理番号K27068 2019/09/02 プロジェクト階層化
// 管理番号K27057 2020/03/23 汎用項目追加
// 3.1.0 2020/06/30
// 管理番号K27228 2020/10/19 サーバ帳票PDF化
// 管理番号K27230 2021/05/27 脆弱性対応
// 管理番号K27443 2022/02/15 アカウント管理強化
// 管理番号K27445 2022/02/15 ログ管理強化
// 3.2.0 2023/03/31
// 管理番号K27487 2023/06/15 継続契約OP標準化対応

using System;
using System.Data;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Infocom.Allegro.Web.WebControls;
// Plat015 From
using System.Diagnostics;
// Plat015 To
// 管理番号 P19346 From
using System.Collections;
// 管理番号 P19346 To
// 管理番号K26528 From
using System.Collections.Generic;
using System.Linq;
// 管理番号K26528 To
// 管理番号B27167 From
using System.Web;
// 管理番号B27167 To

namespace Infocom.Allegro.Web
{
	/// <summary>
	/// すべての画面への共通機能を提供します。
	/// </summary>
	public class PageBase : System.Web.UI.Page
	{
		#region Private Fields
		private const string errorPage = "CM_AC_01_S02.aspx";
		private bool isFocusControlRegistered = false;
		private bool registeredFocusAtPreRender = false;
		private string activeControlID = null;
// 管理番号 K25482 From
		private bool autoFocusControlMode = true;
// 管理番号 K25482 To

// Plat015 From
// 管理番号 B22218 From
//// 管理番号 B21419 From
////		private const string ENGINVALIDVIEWSTATEMSG = "Invalid_Viewstate_Client_Disconnected";
//		private const string ENGINVALIDVIEWSTATEMSG = "Invalid_Viewstate";
//// 管理番号 B21419 To
		private const string ENGINVALIDVIEWSTATEMSG  = "Invalid_Viewstate_Client_Disconnected";
		private const string ENGINVALIDVIEWSTATEMSG3 = "Invalid_Viewstate";
// 管理番号 B22218 To
		private const string ENGINVALIDVIEWSTATEMSG2 = "The viewstate is invalid for this page and might be corrupted.";
		private const string JPNINVALIDVIEWSTATEMSG = "このページの ViewState は無効です";		
// Plat015 To
// 管理番号 B23537 From
		private const string JPNINVALIDVIEWSTATEMSG2 = "クライアントが切断されました。";
// 管理番号 B23537 To
// 管理番号 B21419 From
		private bool isViewStateError = false;
// 管理番号 B21419 To
// 管理番号 P19346 From
		//自画面でViewStateの代わりにSessionを使用するか否かの情報を退避する（初期値「使用しない」）
		private bool isUseSessionAlternateToViewState = false;
		//自画面でViewStateの代わりにSessionを使用する場合に使用するSession変数名を退避する
		private const string SESSION_NAME_ALTERNATE_TO_VIEWSTATE = "PageBaseAlternateToViewState";
		//ViewState／Session入替え処理の際に使用するSessionに格納する配列データ(AlternateInfoが格納された配列)
		private Hashtable AlternateToViewState;
		//ログイン画面
		private const string ASPX_OF_LOGIN = "CM_AC_03_S01";
// 管理番号 K24546 From
		//ログイン画面（デモ用）
		private const string ASPX_OF_LOGIN_FOR_DEMO = "XC_AC_03_S08";
// 管理番号 K24546 To
		//ECログイン画面
		private const string ASPX_OF_ECLOGIN = "SC_EC_01_S01";
		//メインメニュー画面
		private const string ASPX_OF_MENU = "CM_AC_04_S04";
		//ECメニュー画面
		private const string ASPX_OF_ECMENU = "SC_EC_01_S03";
		//起動処理画面
		private const string ASPX_OF_EXEC = "CM_AC_01_S01";
// 管理番号K27443 From
		// 仮パスワード発行確認画面
		private const string ASPX_OF_TEMP_PASS_CHECK = "CM_AC_03_S97";
// 管理番号K27443 To
		//ViewState／Session入替え情報構造体
		#region AlternateInfo
		private struct AlternateInfo
		{
			//ViewStateの代わりにSessionを使用するか否かの情報を退避する
			private bool isUseSession;
			//ViewStateを格納する
			private object viewState;

			#region Properties
			#region IsUseSession
			/// <summary>
			/// Sessoin変数使用可否
			/// </summary>
			public bool IsUseSession
			{
				get{return isUseSession;}
				set{isUseSession = value;}
			}
			#endregion

			#region ViewState
			/// <summary>
			/// ViewState格納
			/// </summary>
			public object ViewState
			{
				get{return viewState;}
				set{viewState = value;}
			}
			#endregion
			#endregion	
		}
		#endregion
// 管理番号 P19346 To

// 管理番号K26528 From
		#region StartupScript
		/// <summary>
		/// <see cref="StartupScriptManager" />の実行優先度
		/// 定義された数値の昇順で実行されます。
		/// </summary>
		protected enum StartupPriority
		{
			/// <summary>
			/// 即時実行用
			/// </summary>
			Immediate	= 00,

			/// <summary>
			/// ページ基底クラス用
			/// </summary>
			Base		= 10,

			/// <summary>
			/// コントロールクラス用
			/// </summary>
			Control		= 20,

			/// <summary>
			/// 個別ページクラス用
			/// </summary>
			Page		= 30,
		}

		/// <summary>
		/// スタートアップスクリプトを優先度に基づいて管理するディクショナリ
		/// キーである<see cref="int" />が優先度を表し、この値が小さい程優先的に実行されます。
		/// 既定では<see cref="StartupPriority"/>のメンバーを<see cref="int" />に変換した値をキーとして、優先度が設定されています。
		/// より細かく優先度設定を行いたい場合は、任意の<see cref="int" />をキーとして<see cref="StartupScriptManager" />を登録してください。
		/// </summary>
		protected SortedDictionary<int, StartupScriptManager> startupScriptManager = new SortedDictionary<int, StartupScriptManager>();
		#endregion
// 管理番号K26528 To
		#endregion

		#region Properties

		#region CommonData, PageID, ASPXFileCode, DisclosureUnitType, AuthoritySettingType
		/// <summary>
		/// 共通データ
		/// </summary>
		protected CommonData CommonData
		{
// 管理番号K27445 From
//// 管理番号K27228 From
////// 管理番号 K24546 From
//////			get {return new CommonData(CompCode, UserName, PageID, TraceLevel);}
////			get { return new CommonData(CompCode, UserName, PageID, TraceLevel, (string)Session["LanguageSetting"]); }
//			get { return new CommonData(CompCode, UserName, PageID, TraceLevel, (string)Session["LanguageSetting"], (string)Session["LoginAccount"], (string)Session["EmpCode"], (string)Session["DeptCode"], (string[])Session["DeptCodes"]); }
////// 管理番号 K24546 To
//// 管理番号K27228 To
			get { return new CommonData(CompCode, UserName, PageID, UserHostName, TraceLevel, (string)Session["LanguageSetting"], (string)Session["LoginAccount"], (string)Session["EmpCode"], (string)Session["DeptCode"], (string[])Session["DeptCodes"]); }
// 管理番号K27445 To
		}

		/// <summary>
		/// 画面のページID。
		/// 仮想ページコードが<see cref="System.Web.HttpRequest.QueryString"/>に存在する場合は仮想ページコード。
		/// それ以外の場合は<see cref="ASPXFileCode"/>。
		/// </summary>
		public string PageID
		{
			get
			{
				try
				{
					string pageID = Request.QueryString.Get("PageID").ToUpper();
					if (pageID.Length == 0)
					{
						return ASPXFileCode;
					}
					else if (pageID.Length == 12)
					{
						return pageID;
					}
					else
					{
						TransferErrorPage(AllegroMessage.S20001);
						return string.Empty;
					}
				}
				catch (NullReferenceException)
				{
					return ASPXFileCode;
				}
			}
		}

// 管理番号K27445 From
		/// <summary>
		/// セッション変数にロードされているGRANDITアクセス中のクライアントホスト名
		/// </summary>
		public string UserHostName
		{
			get
			{
				try
				{
					string userHostName = string.Empty;
					userHostName = (string) Session["UserHostName"];
					if (userHostName.Length != 0)
					{
						return userHostName;
					}
					else
					{
						TransferErrorPage(AllegroMessage.CM_AC_S20003);
						return string.Empty;
					}
				}
				catch (NullReferenceException)
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20003);
					return string.Empty;
				}
			}
		}
// 管理番号K27445 To

		/// <summary>
		/// 画面のASPXファイルコード（ASPXファイルのファイル名部分）。
		/// </summary>
		private string ASPXFileCode
		{
			get
			{
				string url = Request.CurrentExecutionFilePath;
				int slashIndex = url.LastIndexOf('/');
				slashIndex++;
				return url.Substring(slashIndex, url.Length - slashIndex - 5).ToUpper();			
			}
		}

		/// <summary>
		/// セッション変数にロードされている公開単位区分。
		/// </summary>
		public string DisclosureUnitType
		{
			get {return (string) Session[new StringBuilder("CM_AC_", 38).Append(PageID).Append("_DisclosureUnitType").ToString()];}
		}

// 管理番号K26508 From
		/// <summary>
		/// セッション変数にロードされている権限設定区分。更新権限：U、参照権限：V
		/// </summary>
		public string AuthoritySettingType
		{
			get {return (string) Session["CM_AC_" + PageID + "_AuthoritySettingType"];}
		}
// 管理番号K26508 To
		#endregion

		#region Session
		/// <summary>
		/// セッション変数にロードされているログインフラグ（ログイン状態：true、ログアウト状態：false）。
		/// </summary>
		private bool LoginFlg
		{
			get
			{
				try
				{
					return (bool) Session["LoginFlg"];
				}
				catch (NullReferenceException)
				{
					return false;
				}
			}
		}

		/// <summary>
		/// セッション変数にロードされているログインセッションの自社コード。
		/// </summary>
		protected string CompCode
		{
			get
			{
				try
				{
					string myCompCode = string.Empty;
					myCompCode = (string) Session["MyCompCode"];
					if (myCompCode.Length != 0)
					{
						return myCompCode;
					}
					else
					{
						TransferErrorPage(AllegroMessage.CM_AC_S20003);
						return string.Empty;
					}
				}
				catch (NullReferenceException)
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20003);
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// <see cref="CompCode"/>と同じ。
		/// </summary>
		private string MyCompCode
		{
			get {return CompCode;}
		}

		/// <summary>
		/// セッション変数にロードされているトレースレベル。
		/// </summary>
		private TraceLevel TraceLevel
		{
			get
			{
				try
				{
					return (TraceLevel) Session["TraceLevel"];
				}
				catch (NullReferenceException)
				{
					return TraceLevel.Verbose;
				}
			}
		}

		/// <summary>
		/// セッション変数にロードされているログインセッションのログインアカウント。
		/// </summary>
		protected string LoginAccount
		{
			get
			{
				try
				{
					return (string) Session["LoginAccount"];
				}
				catch
				{
// 					TransferErrorPage(AllegroMessage.CM_AC_S20010("LoginAccount", "ログインアカウント")); //K24546
					TransferErrorPage(AllegroMessage.CM_AC_S20010("LoginAccount", MultiLanguage.Get("CM_AM000684")));
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// セッション変数にロードされているログインセッションの社員.社員コード。
		/// </summary>
		protected string UserCode
		{
			get
			{
				try
				{
					return (string) Session["EmpCode"];
				}
				catch
				{
// 					TransferErrorPage(AllegroMessage.CM_AC_S20010("EmpCode", "社員コード")); //K24546
					TransferErrorPage(AllegroMessage.CM_AC_S20010("EmpCode", MultiLanguage.Get("CM_AM001080")));
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// セッション変数にロードされているログインセッションの社員.社員略名。
		/// </summary>
		protected internal string UserName
		{
			get
			{
				try
				{
					return (string) Session["EmpShortName"];
				}
				catch
				{
// 					TransferErrorPage(AllegroMessage.CM_AC_S20010("EmpShortName", "社員略名")); //K24546
					TransferErrorPage(AllegroMessage.CM_AC_S20010("EmpShortName", MultiLanguage.Get("CM_AM001081")));
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// セッション変数にロードされているログインセッションの社員所属部門.部門コード（表示メニュー画面の部門ドロップダウンリストで選択されている値）。
		/// </summary>
		protected string UserDeptCode
		{
			get {return (string) Session["DeptCode"];}
		}

		/// <summary>
		/// セッション変数にロードされているログインセッションの社員所属部門.部門コード（表示メニュー画面の部門ドロップダウンリストで選択されている値）。
		/// </summary>
		protected string UserDeptName
		{
			get {return (string) Session["DeptShortName"];}
		}

		/// <summary>
		/// セッション変数にロードされているログインセッションの社員の社員所属部門.部門コードの配列。
		/// </summary>
		protected string[] UserAllDeptCodes
		{
			get {return (string[]) Session["DeptCodes"];}
		}

		/// <summary>
		/// セッション変数にロードされているセッションレベルのページ接続許諾情報。
		/// </summary>
		private DataTable SessionLevelPageAccessPermissionTable
		{
			get
			{
				try
				{
					return (DataTable) Session["SessionLevelPageAccessPermissionTable"];
				}
				catch (NullReferenceException)
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20003);
					return new DataTable();
				}
			}
		}
// 管理番号K26344 From
		/// <summary>
		/// セッション変数にロードされているこの画面の社員割当有無フラグ（有：true、無：false）。
		/// </summary>
		public bool EmpAllocFlg
		{
			get
			{
				try
				{
					DataRow[] row = SessionLevelPageAccessPermissionTable.Select("[PAGE_CODE] = '" + PageID.Replace("'", "''") + "'");
					if(row.Length == 1)
					{
						return row[0]["EMP_ALLOC_FLG"].ToString() == "1";
					}
					else
					{
						return false;
					}
				}
				catch (NullReferenceException)
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20003);
					return false;
				}
			}
		}
// 管理番号K26344 To
// 管理番号 K24546 From

		/// <summary>
		/// セッション変数にロードされているログインセッションの言語設定。
		/// </summary>
		protected string LanguageSetting
		{
			get
			{
				try
				{
					return (string)Session["LanguageSetting"];
				}
				catch (NullReferenceException)
				{
					return "ja-JP";
				}
			}
		}
// 管理番号 K24546 To
		#endregion

		#region Session EC
		/// <summary>
		/// セッション変数にロードされているECログインフラグ（ECでのログインである：true、ECでのログインではない：false）。
		/// </summary>
		public bool ECLoginFlg
		{
			get
			{
				try
				{
					return (bool) Session["ECLoginFlg"];
				}
				catch (NullReferenceException)
				{
					return false;
				}
			}
		}

		/// <summary>
		/// ECログイン時にセッション変数にロードされているECログインアカウント.取引先区分（得意先："C"、仕入先："S"）。
		/// </summary>
		private string SC_EC_CompType
		{
			get
			{
				try
				{
					return (string) Session["SC_EC_CompType"];
				}
				catch
				{
// 					TransferErrorPage(AllegroMessage.CM_AC_S20010("SC_EC_CompType", "取引先区分")); //K24546
					TransferErrorPage(AllegroMessage.CM_AC_S20010("SC_EC_CompType", MultiLanguage.Get("CM_AM001093")));
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// ECログイン時にセッション変数にロードされている得意先.得意先略名もしくは仕入先.仕入先略名。
		/// </summary>
		public string SC_EC_CompName
		{
			get
			{
				try
				{
					return (string) Session["SC_EC_CompName"];
				}
				catch
				{
// 					TransferErrorPage(AllegroMessage.CM_AC_S20010("SC_EC_CompName", "得意先略名 or 仕入先略名")); //K24546
					TransferErrorPage(AllegroMessage.CM_AC_S20010("SC_EC_CompName", MultiLanguage.Get("CM_AM001289")));
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// ECログイン時にセッション変数にロードされているEC担当部門コードの組織図.部門略名。
		/// </summary>
		public string SC_EC_DeptShortName
		{
			get
			{
				try
				{
					return (string) Session["SC_EC_DeptShortName"];
				}
				catch
				{
// 					TransferErrorPage(AllegroMessage.CM_AC_S20010("SC_EC_DeptShortName", "得意先部門名1 or 仕入先部門名1")); //K24546
					TransferErrorPage(AllegroMessage.CM_AC_S20010("SC_EC_DeptShortName", MultiLanguage.Get("CM_AM001288")));
					return string.Empty;
				}
			}
		}

		/// <summary>
		/// ECログイン時にセッション変数にロードされているECログインアカウント.ECログインアカウント名。
		/// </summary>
		public string SC_EC_AccountName
		{
			get
			{
				try
				{
					return (string) Session["SC_EC_AccountName"];
				}
				catch
				{
// 					TransferErrorPage(AllegroMessage.CM_AC_S20010("SC_EC_AccountName", "ECログインアカウント名")); //K24546
					TransferErrorPage(AllegroMessage.CM_AC_S20010("SC_EC_AccountName", MultiLanguage.Get("CM_AM000442")));
					return string.Empty;
				}
			}
		}
		#endregion

		#region Application CM.MYCOMP
		/// <summary>
		/// アプリケーション変数にロードされている自社.自社名。
		/// </summary>
		public string CompName
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 19).Append("_MyCompName").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.自社略名。
		/// </summary>
		public string MyCompShortName
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 24).Append("_MyCompShortName").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.自社カナ名。
		/// </summary>
		protected string MyCompKanaName
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 23).Append("_MyCompKanaName").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.自社英字名。
		/// </summary>
		protected string MyCompEngName
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 22).Append("_MyCompEngName").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.自社ドメイン。
		/// </summary>
		protected string MyCompDomain
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 21).Append("_MyCompDomain").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.国コード。
		/// </summary>
		protected string CountryCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 20).Append("_CountryCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.部門階層。
		/// </summary>
		protected int DeptLevel
		{
			get {return (int) Application[new StringBuilder(MyCompCode, 18).Append("_DeptLevel").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.部門記号桁数。
		/// </summary>
		protected byte DeptMarkDigit
		{
			get {return (byte) Application[new StringBuilder(MyCompCode, 22).Append("_DeptMarkDigit").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.本決算期ID。
		/// </summary>
		protected int RealSttlTermId
		{
			get {return (int) Application[new StringBuilder(MyCompCode, 23).Append("_RealSttlTermId").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.本会計年度。
		/// </summary>
		protected string RealFinanceYear
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 24).Append("_RealFinanceYear").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.本会計期間開始月度。
		/// </summary>
		protected string RealFinancePeriodSttMonth
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 34).Append("_RealFinancePeriodSttMonth").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.本会計期間終了月度。
		/// </summary>
		protected string RealFinancePeriodEndMonth
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 34).Append("_RealFinancePeriodEndMonth").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.仮決算期ID。
		/// </summary>
		protected int TempSttlTermId
		{
			get {return (int) Application[new StringBuilder(MyCompCode, 23).Append("_TempSttlTermId").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.仮会計年度。
		/// </summary>
		protected string TempFinanceYear
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 24).Append("_TempFinanceYear").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.仮会計期間開始月度。
		/// </summary>
		protected string TempFinancePeriodSttMonth
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 34).Append("_TempFinancePeriodSttMonth").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.仮会計期間終了月度。
		/// </summary>
		protected string TempFinancePeriodEndMonth
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 34).Append("_TempFinancePeriodEndMonth").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.消費税計算区分。
		/// </summary>
		protected string CtaxCalcType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 21).Append("_CtaxCalcType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.消費税端数丸め区分。
		/// </summary>
		protected string CtaxRoundType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 22).Append("_CtaxRoundType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.多通貨使用フラグ。
		/// </summary>
		protected bool MultiCurUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_MultiCurUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.基軸通貨コード。
		/// </summary>
		protected string KeyCurrencyCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 26).Append("_KeyCurrencyCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.通貨換算端数丸め区分。
		/// </summary>
		protected string CurRoundType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 21).Append("_CurRoundType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.金額合計端数丸め区分。
		/// </summary>
		protected string AmtRoundType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 21).Append("_AmtRoundType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.単価小数使用フラグ。
		/// </summary>
		protected bool PriceDecimalUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 27).Append("_PriceDecimalUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.数量小数使用フラグ。
		/// </summary>
		protected bool QtDecimalUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 24).Append("_QtDecimalUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.与信管理実施フラグ。
		/// </summary>
		protected bool CreditImplementFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 27).Append("_CreditImplementFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.与信管理単位区分。
		/// </summary>
		protected string CreditAdminUnitType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 28).Append("_CreditAdminUnitType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.国内売上税区分コード。
		/// </summary>
		protected string DomesticSaCtaxTypeCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 31).Append("_DomesticSaCtaxTypeCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.国内売上返品税区分コード。
		/// </summary>
		protected string DomesticSaReturnCtaxTypeCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 37).Append("_DomesticSaReturnCtaxTypeCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.国内仕入税区分コード。
		/// </summary>
		protected string DomesticPuCtaxTypeCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 31).Append("_DomesticPuCtaxTypeCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.国内仕入返品税区分コード。
		/// </summary>
		protected string DomesticPuReturnCtaxTypeCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 37).Append("_DomesticPuReturnCtaxTypeCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.海外売上税区分コード。
		/// </summary>
		protected string OverseasSaCtaxTypeCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 31).Append("_OverseasSaCtaxTypeCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.海外売上返品税区分コード。
		/// </summary>
		protected string OverseasSaReturnCtaxTypeCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 37).Append("_OverseasSaReturnCtaxTypeCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.海外仕入税区分コード。
		/// </summary>
		protected string OverseasPuCtaxTypeCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 31).Append("_OverseasPuCtaxTypeCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.海外仕入返品税区分コード。
		/// </summary>
		protected string OverseasPuReturnCtaxTypeCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 37).Append("_OverseasPuReturnCtaxTypeCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.承認実施フラグ。
		/// </summary>
		protected bool ApprovalImplementFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 29).Append("_ApprovalImplementFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.プロジェクト使用フラグ。
		/// </summary>
		protected bool ProjImplementFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 25).Append("_ProjImplementFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.EC使用フラグ。
		/// </summary>
		protected bool EcImplementFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_EcImplementFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.FAQ編集許可フラグ。
		/// </summary>
		protected bool FaqEditAllowFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 24).Append("_FaqEditAllowFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.取引先コード固定桁数。
		/// </summary>
		protected byte CompanyCodeLength
		{
			get {return (byte) Application[new StringBuilder(MyCompCode, 26).Append("_CompanyCodeLength").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.プロジェクトコード固定桁数。
		/// </summary>
		protected byte ProjectCodeLength
		{
			get {return (byte) Application[new StringBuilder(MyCompCode, 26).Append("_ProjectCodeLength").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.見積番号固定桁数。
		/// </summary>
		protected byte QuoteNoFixedDigit
		{
			get {return (byte) Application[new StringBuilder(MyCompCode, 26).Append("_QuoteNoFixedDigit").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.IPアドレスチェックフラグ。
		/// </summary>
		private bool IPAddressCheckFlg
		{
			get
			{
				try
				{
					return (bool) Application[new StringBuilder(MyCompCode, 26).Append("_IPAddressCheckFlg").ToString()];
				}
				catch (NullReferenceException)
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20004);
					return true;
				}
			}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.ページ接続許諾チェックフラグ。
		/// </summary>
		private bool PageAccessPermissionCheckFlg
		{
			get
			{
				try
				{
					return (bool) Application[new StringBuilder(MyCompCode, 37).Append("_PageAccessPermissionCheckFlg").ToString()];
				}
				catch (NullReferenceException)
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20004);
					return true;
				}
			}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.日本国コード。
		/// </summary>
		protected string JapanCountryCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 25).Append("_JapanCountryCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.日本通貨コード。
		/// </summary>
		protected string JapanCurCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 21).Append("_JapanCurCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.管理項目名1。
		/// </summary>
		protected string AdminItemName1
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 23).Append("_AdminItemName1").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.管理項目名2。
		/// </summary>
		protected string AdminItemName2
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 23).Append("_AdminItemName2").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.管理項目名3。
		/// </summary>
		protected string AdminItemName3
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 23).Append("_AdminItemName3").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.管理項目桁数1。
		/// </summary>
		protected byte AdminItemDigit1
		{
			get {return (byte) Application[new StringBuilder(MyCompCode, 24).Append("_AdminItemDigit1").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.管理項目桁数2。
		/// </summary>
		protected byte AdminItemDigit2
		{
			get {return (byte) Application[new StringBuilder(MyCompCode, 24).Append("_AdminItemDigit2").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.管理項目桁数3。
		/// </summary>
		protected byte AdminItemDigit3
		{
			get {return (byte) Application[new StringBuilder(MyCompCode, 24).Append("_AdminItemDigit3").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.管理項目文字属性1。
		/// </summary>
		protected string AdminItemAttribute1
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 28).Append("_AdminItemAttribute1").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.管理項目文字属性2。
		/// </summary>
		protected string AdminItemAttribute2
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 28).Append("_AdminItemAttribute2").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.管理項目文字属性3。
		/// </summary>
		protected string AdminItemAttribute3
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 28).Append("_AdminItemAttribute3").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.自動採番体系。
		/// </summary>
		protected string SlipAutoNumberingType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 30).Append("_SlipAutoNumberingType").ToString()];}
		}
//管理番号 K16187From
		/// <summary>
		/// アプリケーション変数にロードされている自社.消込管理区分。
		/// </summary>
		protected string KoAdminType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 20).Append("_KoAdminType").ToString()];}
		}
//管理番号 K16187To
// 管理番号K16590 From
		/// <summary>
		/// アプリケーション変数にロードされている自社.日付管理区分。
		/// </summary>
		protected string DateAdminType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 22).Append("_DateAdminType").ToString()];}
		}
// 管理番号K16590 To

// 管理番号 K23209 From
		/// <summary>
		/// アプリケーション変数にロードされている自社.同時実行可能件数。
		/// </summary>
		protected string MultiTaskCnt
		{
			get { return (string)Application[new StringBuilder(MyCompCode, 21).Append("_MultiTaskCnt").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.スケジュール実行可能件数。
		/// </summary>
		protected string ScheduleTaskCnt
		{
			get { return (string)Application[new StringBuilder(MyCompCode, 24).Append("_ScheduleTaskCnt").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.ファイル保存期間。
		/// </summary>
		protected string FileKeepPeriod
		{
			get { return (string)Application[new StringBuilder(MyCompCode, 23).Append("_FileKeepPeriod").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.履歴保存期間。
		/// </summary>
		protected string HistoryKeepPeriod
		{
			get { return (string)Application[new StringBuilder(MyCompCode, 26).Append("_HistoryKeepPeriod").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.出力指示警告件数。
		/// </summary>
		protected string WarningRowCnt
		{
			get { return (string)Application[new StringBuilder(MyCompCode, 22).Append("_WarningRowCnt").ToString()]; }
		}
// 管理番号 K23209 To
// 管理番号 K23672 From
		/// <summary>
		/// アプリケーション変数にロードされている自社.基軸換算金額変更範囲。
		/// </summary>
		protected decimal CMKeyAmtChangeScope
		{
			get { return (decimal)Application[new StringBuilder(MyCompCode, 28).Append("_CMKeyAmtChangeScope").ToString()]; }
		}
// 管理番号 K23672 To
// 管理番号 K25647 From
		/// <summary>
		/// アプリケーション変数にロードされている自社.単価小数桁数。
		/// </summary>
		protected byte PriceDecimalDigit
		{
			get { return (byte)Application[new StringBuilder(MyCompCode, 19).Append("_PriceDecimalDigit").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.数量小数桁数。
		/// </summary>
		protected byte QtDecimalDigit
		{
			get { return (byte)Application[new StringBuilder(MyCompCode, 16).Append("_QtDecimalDigit").ToString()]; }
		}
// 管理番号 K25647 To
// 管理番号K27059 From
		/// <summary>
		/// アプリケーション変数にロードされている自社.得意先検索初期値使用フラグ。
		/// </summary>
		protected bool InitCustSearchWindowUseFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 35).Append("_InitCustSearchWindowUseFlg").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社.仕入先検索初期値使用フラグ。
		/// </summary>
		protected bool InitSuplSearchWindowUseFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 35).Append("_InitSuplSearchWindowUseFlg").ToString()]; }
		}
// 管理番号K27059 To
// 管理番号K27068 From
		/// <summary>
		/// アプリケーション変数にロードされている自社.プロジェクト階層。
		/// </summary>
		protected byte ProjLevel
		{
			get { return (byte)Application[new StringBuilder(MyCompCode, 18).Append("_ProjLevel").ToString()]; }
		}
// 管理番号K27068 To
// 管理番号K27228 From
		/// <summary>
		/// アプリケーション変数にロードされている自社.運用区分。
		/// </summary>
		protected string OperationType
		{
			get { return (string)Application[new StringBuilder(MyCompCode, 22).Append("_OperationType").ToString()]; }
		}
// 管理番号K27228 To
		#endregion

		#region Application CM.CUR
		/// <summary>
		/// アプリケーション変数にロードされている有効な通貨コードの配列。
		/// </summary>
		protected string[] CurrencyCodes
		{
			get {return (string[]) Application[new StringBuilder(MyCompCode, 22).Append("_CurrencyCodes").ToString()];}
		}
		#endregion

		#region Application CM.ORG_CHANGE
		/// <summary>
		/// アプリケーション変数にロードされている現在の組織変更ID。
		/// </summary>
		protected int CurrentOrganizationChangeId
		{
			get {return (int) Application[new StringBuilder(MyCompCode, 38).Append("_CurrentOrganizationChangeId").ToString()];}
		}
		#endregion

		#region Application CM.ASPX_FILE
		/// <summary>
		/// アプリケーション変数にロードされている自社レベルのASPXファイル接続許諾情報。
		/// </summary>
		private DataTable MyCompLevelASPXFileAccessPermissionTable
		{
			get
			{
				try
				{
					return (DataTable) Application[new StringBuilder(MyCompCode, 49).Append("_MyCompLevelASPXFileAccessPermissionTable").ToString()];
				}
				catch (NullReferenceException)
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20004);
					return new DataTable();
				}
			}
		}
		#endregion

		#region Application CM.PAGE
		/// <summary>
		/// アプリケーション変数にロードされている自社レベルのページ接続許諾情報。
		/// </summary>
		private DataTable MyCompLevelPageAccessPermissionTable
		{
			get
			{
				try
				{
					return (DataTable) Application[new StringBuilder(MyCompCode, 45).Append("_MyCompLevelPageAccessPermissionTable").ToString()];
				}
				catch (NullReferenceException)
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20004);
					return new DataTable();
				}
			}
		}

// 管理番号 K25902 From
		/// <summary>
		/// アプリケーション変数にロードされているこの画面のデータグリッド出力使用フラグ（使用する：true、使用しない：false）。
		/// </summary>
		public bool IsUseDataGridDownLoad
		{
			get
			{
				try
				{
					DataTable dt = (DataTable)GetCompApplicationVariable("DataGridDownloadInfo");
					DataRow[] row = dt.Select("[PAGE_CODE] = '" + PageID.Replace("'", "''") + "'");
					return row[0]["DATAGRID_FILE_EXPORT_USE_FLG"].ToString() == "1";
				}
				catch (NullReferenceException)
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20004);
					return false;
				}
			}
		}
// 管理番号 K25902 To
// 管理番号K26344 From
		/// <summary>
		/// アプリケーション変数にロードされているこの画面の画面コントロールID。
		/// </summary>
		public DataRow[] HSControls
		{
			get
			{
				try
				{
					DataRow[] row = MyCompLevelPageAccessPermissionTable.Select("[PAGE_CODE] = '" + PageID.Replace("'", "''") + "'");
					return row;
				}
				catch (NullReferenceException)
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20004);
					return new DataRow[0];
				}
			}
		}
// 管理番号K26344 To
// 管理番号K27059 From
		/// <summary>
		/// アプリケーション変数にロードされているこの画面の得意先検索初期値使用フラグ（使用する：true、使用しない：false）。
		/// </summary>
		protected bool PageInitCustSearchWindowUseFlg
		{
			get
			{
				try
				{
					DataTable dt = (DataTable)GetCompApplicationVariable("SearchWindowInfo");
					DataRow[] row = dt.Select("[PAGE_CODE] = '" + PageID.Replace("'", "''") + "'");
					return row[0]["INIT_CUST_SEARCH_WINDOW_USE_FLG"].ToString() == "1";
				}
				catch (NullReferenceException)
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20004);
					return false;
				}
			}
		}

		/// <summary>
		/// アプリケーション変数にロードされているこの画面の仕入先検索初期値使用フラグ（使用する：true、使用しない：false）。
		/// </summary>
		protected bool PageInitSuplSearchWindowUseFlg
		{
			get
			{
				try
				{
					DataTable dt = (DataTable)GetCompApplicationVariable("SearchWindowInfo");
					DataRow[] row = dt.Select("[PAGE_CODE] = '" + PageID.Replace("'", "''") + "'");
					return row[0]["INIT_SUPL_SEARCH_WINDOW_USE_FLG"].ToString() == "1";
				}
				catch (NullReferenceException)
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20004);
					return false;
				}
			}
		}

		/// <summary>
		/// アプリケーション変数にロードされているこの画面の商品検索初期値使用フラグ（使用する：true、使用しない：false）。
		/// </summary>
		protected bool PageInitProdSearchWindowUseFlg
		{
			get
			{
				try
				{
					DataTable dt = (DataTable)GetCompApplicationVariable("SearchWindowInfo");
					DataRow[] row = dt.Select("[PAGE_CODE] = '" + PageID.Replace("'", "''") + "'");
					return row[0]["INIT_PROD_SEARCH_WINDOW_USE_FLG"].ToString() == "1";
				}
				catch (NullReferenceException)
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20004);
					return false;
				}
			}
		}
// 管理番号K27059 To
		#endregion

		// 管理番号K20128 From
		#region Application IsProgramLogWriteToDatabase
		/// <summary>
		/// アプリケーション変数にロードされているプログラム操作ログ出力フラグ。
		/// </summary>
		protected bool IsProgramLogWriteToDatabase
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 36).Append("_IsProgramLogWriteToDatabase").ToString()];}
		}
		#endregion
		#region Application IsPostLogWriteToDatabase
		/// <summary>
		/// アプリケーション変数にロードされているプログラム操作ログ（HTTP_POSTメソッド）出力フラグ。
		/// </summary>
		protected bool IsPostLogWriteToDatabase
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 36).Append("_IsPostLogWriteToDatabase").ToString()];}
		}
		#endregion
		#region Application IsGetLogWriteToDatabase
		/// <summary>
		/// アプリケーション変数にロードされているプログラム操作ログ（HTTP_GETメソッド）出力フラグ。
		/// </summary>
		protected bool IsGetLogWriteToDatabase
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 36).Append("_IsGetLogWriteToDatabase").ToString()];}
		}
		#endregion
		// 管理番号K20128 To
// 管理番号K27443 From
		#region Application PassReissueFunctionUseFlg
		/// <summary>
		/// アプリケーション変数にロードされているパスワード再発行機能使用フラグ。
		/// </summary>
		protected bool PassReissueFunctionUseFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 36).Append("_PassReissueFunctionUseFlg").ToString()]; }
		}
		#endregion
// 管理番号K27443 To

		#region Application FI.MYCOMP_FI_AP
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.支払申請入力承認フラグ。
		/// </summary>
		protected bool PymtApplInputApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 33).Append("_PymtApplInputApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.支払申請取込承認フラグ。
		/// </summary>
		protected bool PymtApplImportApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 34).Append("_PymtApplImportApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.定期支払承認フラグ。
		/// </summary>
		protected bool PeriodicPymtApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_PeriodicPymtApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.支払集計部門階層。
		/// </summary>
		protected int PymtSummaryDeptLevel
		{
			get {return (int) Application[new StringBuilder(MyCompCode, 29).Append("_PymtSummaryDeptLevel").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.支払書フォーム区分。
		/// </summary>
		protected string PymtSlipFormType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 25).Append("_PymtSlipFormType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.支払部門コード。
		/// </summary>
		protected string PymtDeptCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 21).Append("_PymtDeptCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.基軸出金口座コード。
		/// </summary>
		protected string KeyPymtAcCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 22).Append("_KeyPymtAcCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.外貨出金口座コード。
		/// </summary>
		protected string FmoneyPymtAcCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 25).Append("_FmoneyPymtAcCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.送金許可番号。
		/// </summary>
		protected string RemittanceAllowNo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 26).Append("_RemittanceAllowNo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.照会検索範囲支払申請自。
		/// </summary>
		protected string RefSearchScopePymtApplFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 35).Append("_RefSearchScopePymtApplFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.照会検索範囲支払申請至。
		/// </summary>
		protected string RefSearchScopePymtApplTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 33).Append("_RefSearchScopePymtApplTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.照会検索範囲支払締自。
		/// </summary>
		protected string RefSearchScopePymtCutoffFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 37).Append("_RefSearchScopePymtCutoffFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.照会検索範囲支払締至。
		/// </summary>
		protected string RefSearchScopePymtCutoffTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 35).Append("_RefSearchScopePymtCutoffTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.照会検索範囲支払自。
		/// </summary>
		protected string RefSearchScopePymtFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 31).Append("_RefSearchScopePymtFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.照会検索範囲支払至。
		/// </summary>
		protected string RefSearchScopePymtTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 29).Append("_RefSearchScopePymtTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.照会検索範囲支払手形自。
		/// </summary>
		protected string RefSearchScopeNpFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 29).Append("_RefSearchScopeNpFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.照会検索範囲支払手形至。
		/// </summary>
		protected string RefSearchScopeNpTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 27).Append("_RefSearchScopeNpTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.照会検索範囲債務期日決済自。
		/// </summary>
		protected string RefSearchScopeApDdSttlFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 35).Append("_RefSearchScopeApDdSttlFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.照会検索範囲債務期日決済至。
		/// </summary>
		protected string RefSearchScopeApDdSttlTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 33).Append("_RefSearchScopeApDdSttlTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.照会検索範囲債務残高自。
		/// </summary>
		protected string RefSearchScopeApRemainingFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 38).Append("_RefSearchScopeApRemainingFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.照会検索範囲債務残高至。
		/// </summary>
		protected string RefSearchScopeApRemainingTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 36).Append("_RefSearchScopeApRemainingTo").ToString()];}
		}
//管理番号 K16187From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.支払営業承認フラグ。
		/// </summary>
		protected bool PymtBusinessApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_PymtBusinessApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.支払財務承認フラグ。
		/// </summary>
		protected bool PymtFinancialApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 33).Append("_PymtFinancialApprovalFlg").ToString()];}
		}
//管理番号 K16187To
//管理番号 K16188From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.支払申請与信チェック区分。
		/// </summary>
		protected string PymtApplCreditCheckType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 32).Append("_PymtApplCreditCheckType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.与信前渡金表示フラグ。
		/// </summary>
		protected bool CreditAdpmDispFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 26).Append("_CreditAdpmDispFlg").ToString()];}
		}
//管理番号 K16188To
// 管理番号K20684 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.定期支払マスタ承認フラグ。
		/// </summary>
		protected bool PeriodicPymtMasterApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 38).Append("_PeriodicPymtMasterApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.前渡金消込承認フラグ。
		/// </summary>
		protected bool AdpmKoApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 26).Append("_AdpmKoApprovalFlg").ToString()];}
		}
// 管理番号K20684 To
// 管理番号 K22199 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.預り金返却許可フラグ。
		/// </summary>
		protected bool DepositsReceivedPermitFlg
		{
			get {return (bool)Application[new StringBuilder(MyCompCode, 37).Append("_DepositsReceivedPermitFlg").ToString()];}
		}
// 管理番号 K22199 To
// 管理番号 K24284 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.プロジェクト入力必須フラグ。
		/// </summary>
		protected bool ProjInputApIndisFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 30).Append("_ProjInputApIndisFlg").ToString()]; }
		}
// 管理番号 K24284 To
// 管理番号 K24790 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.支払書消費税率表示フラグ。
		/// </summary>
		protected bool PymtSlipCtaxRateDispFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 34).Append("_PymtSlipCtaxRateDispFlg").ToString()]; }
		}
// 管理番号 K24790 To
// 管理番号 K25321 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AP）.電子債権出金口座コード。
		/// </summary>
		protected string ElectronicNrPymtAcCode
		{
			get { return (string)Application[new StringBuilder(MyCompCode, 33).Append("_ElectronicNrPymtAcCode").ToString()]; }
		}
// 管理番号 K25321 To
		#endregion

		#region Application FI.MYCOMP_FI_AR
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.請求申請入力承認フラグ。
		/// </summary>
		protected bool BillApplInputApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 33).Append("_BillApplInputApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.請求申請取込承認フラグ。
		/// </summary>
		protected bool BillApplImportApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 34).Append("_BillApplImportApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.定期請求承認フラグ。
		/// </summary>
		protected bool PeriodicBillApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_PeriodicBillApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.入金入力承認フラグ。
		/// </summary>
		protected bool MnrcInputApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 29).Append("_MnrcInputApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.入金取込承認フラグ。
		/// </summary>
		protected bool MnrcImportApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 30).Append("_MnrcImportApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.回収消込承認フラグ。
		/// </summary>
		protected bool ClctKoApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 26).Append("_ClctKoApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.請求集計部門階層。
		/// </summary>
		protected int BillSummaryDeptLevel
		{
			get {return (int) Application[new StringBuilder(MyCompCode, 29).Append("_BillSummaryDeptLevel").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.請求書フォーム区分。
		/// </summary>
		protected string BillSlipFormType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 25).Append("_BillSlipFormType").ToString()];}
		}
//管理番号 K16187From
//		/// <summary>
//		/// アプリケーション変数にロードされている 自社（FI_AR）.消込管理区分 を取得します。
//		/// </summary>
//		protected string KoAdminType
//		{
//			get {return (string) Application[new StringBuilder(MyCompCode, 20).Append("_KoAdminType").ToString()];}
//		}
//管理番号 K16187To
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.回収部門コード。
		/// </summary>
		protected string ClctDeptCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 21).Append("_ClctDeptCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.入金口座コード。
		/// </summary>
		protected string MnrcAcCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 19).Append("_MnrcAcCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.振込手数料自動振替金額。
		/// </summary>
		protected decimal RemitFeeAutoTrnsfrAmt
		{
			get {return (decimal) Application[new StringBuilder(MyCompCode, 30).Append("_RemitFeeAutoTrnsfrAmt").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.振込手数料自動請求振替コード。
		/// </summary>
		protected string RemitFeeAutoBillTrnsfrCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 35).Append("_RemitFeeAutoBillTrnsfrCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.消費税端数自動振替金額。
		/// </summary>
		protected decimal CtaxFractionAutoTrnsfrAmt
		{
			get {return (decimal) Application[new StringBuilder(MyCompCode, 34).Append("_CtaxFractionAutoTrnsfrAmt").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.消費税端数自動請求振替コード。
		/// </summary>
		protected string CtaxFractionAutoBillTrnsfrCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 39).Append("_CtaxFractionAutoBillTrnsfrCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.消費税端数自動入金振替コード。
		/// </summary>
		protected string CtaxFractionAutoMnrcTrnsfrCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 39).Append("_CtaxFractionAutoMnrcTrnsfrCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲請求申請自。
		/// </summary>
		protected string RefSearchScopeBillApplFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 35).Append("_RefSearchScopeBillApplFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲請求申請至。
		/// </summary>
		protected string RefSearchScopeBillApplTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 33).Append("_RefSearchScopeBillApplTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲請求締自。
		/// </summary>
		protected string RefSearchScopeBillCutoffFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 37).Append("_RefSearchScopeBillCutoffFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲請求締至。
		/// </summary>
		protected string RefSearchScopeBillCutoffTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 35).Append("_RefSearchScopeBillCutoffTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲入金自。
		/// </summary>
		protected string RefSearchScopeMnrcFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 31).Append("_RefSearchScopeMnrcFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲入金至。
		/// </summary>
		protected string RefSearchScopeMnrcTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 29).Append("_RefSearchScopeMnrcTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲回収消込自。
		/// </summary>
		protected string RefSearchScopeClctKoFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 33).Append("_RefSearchScopeClctKoFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲回収消込至。
		/// </summary>
		protected string RefSearchScopeClctKoTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 31).Append("_RefSearchScopeClctKoTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲受取手形自。
		/// </summary>
		protected string RefSearchScopeNrFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 29).Append("_RefSearchScopeNrFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲受取手形至。
		/// </summary>
		protected string RefSearchScopeNrTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 27).Append("_RefSearchScopeNrTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲債権期日決済自。
		/// </summary>
		protected string RefSearchScopeArDdSttlFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 35).Append("_RefSearchScopeArDdSttlFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲債権期日決済至。
		/// </summary>
		protected string RefSearchScopeArDdSttlTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 33).Append("_RefSearchScopeArDdSttlTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲債権残高自。
		/// </summary>
		protected string RefSearchScopeArRemainingFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 38).Append("_RefSearchScopeArRemainingFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.照会検索範囲債権残高至。
		/// </summary>
		protected string RefSearchScopeArRemainingTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 36).Append("_RefSearchScopeArRemainingTo").ToString()];}
		}
//管理番号 K16188From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.与信前受金表示フラグ。
		/// </summary>
		protected bool CreditAdrcDispFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 26).Append("_CreditAdrcDispFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.請求申請与信チェック区分。
		/// </summary>
		protected string BillApplCreditCheckType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 32).Append("_BillApplCreditCheckType").ToString()];}
		}
// 管理番号K20684 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.定期請求マスタ承認フラグ。
		/// </summary>
		protected bool PeriodicBillMasterApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 38).Append("_PeriodicBillMasterApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.請求承認フラグ。
		/// </summary>
		protected bool BillApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 24).Append("_BillApprovalFlg").ToString()];}
		}
// 管理番号K20684 To
//管理番号 K16188To
// 管理番号 K22199 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.立替金回収許可フラグ。
		/// </summary>
		protected bool AdvancesPermitFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 28).Append("_AdvancesPermitFlg").ToString()]; }
		}
// 管理番号 K22199 To
// 管理番号 K24282 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.注文番号出力区分。
		/// </summary>
		protected string OrderNumberOutputType
		{
			get { return (string)Application[new StringBuilder(MyCompCode, 32).Append("_OrderNumberOutputType").ToString()]; }
		}
// 管理番号 K24282 To
// 管理番号 K24284 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.プロジェクト入力必須フラグ。
		/// </summary>
		protected bool ProjInputArIndisFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 30).Append("_ProjInputArIndisFlg").ToString()]; }
		}
// 管理番号 K24284 To
// 管理番号 K24790 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_AR）.請求書消費税率表示フラグ。
		/// </summary>
		protected bool BillSlipCtaxRateDispFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 34).Append("_BillSlipCtaxRateDispFlg").ToString()]; }
		}
// 管理番号 K24790 To
		#endregion

		#region Application FI.MYCOMP_FI_EX
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.社員区分使用フラグ。
		/// </summary>
		protected bool FI_EX_EmpTypeUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 28).Append("_FI_EX_EmpTypeUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.会議費上限金額。
		/// </summary>
		protected decimal FI_EX_ConventionExpLimitAmt
		{
			get {return (decimal) Application[new StringBuilder(MyCompCode, 36).Append("_FI_EX_ConventionExpLimitAmt").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.出張精算レート区分。
		/// </summary>
		protected string FI_EX_TripClaimRateType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 32).Append("_FI_EX_TripClaimRateType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.口座振込使用フラグ。
		/// </summary>
		protected bool FI_EX_AcRemitUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 28).Append("_FI_EX_AcRemitUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.現金使用フラグ。
		/// </summary>
		protected bool FI_EX_CashUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 25).Append("_FI_EX_CashUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.コーポレートカード使用フラグ。
		/// </summary>
		protected bool FI_EX_CooperateCardUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 34).Append("_FI_EX_CooperateCardUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.合算出納使用フラグ。
		/// </summary>
		protected bool FI_EX_OffsetCashierUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 34).Append("_FI_EX_OffsetCashierUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.申請経費計上確認使用フラグ。
		/// </summary>
		protected bool FI_EX_ApplExpBookCnfrmUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 37).Append("_FI_EX_ApplExpBookCnfrmUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.精算経費計上確認使用フラグ。
		/// </summary>
		protected bool FI_EX_ClaimExpBookCnfrmUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 38).Append("_FI_EX_ClaimExpBookCnfrmUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.出張備考1キャプション。
		/// </summary>
		protected string FI_EX_TripNote1Caption
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 31).Append("_FI_EX_TripNote1Caption").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.出張備考2キャプション。
		/// </summary>
		protected string FI_EX_TripNote2Caption
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 31).Append("_FI_EX_TripNote2Caption").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.交際費備考1キャプション。
		/// </summary>
		protected string FI_EX_SocialExpNote1Caption
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 36).Append("_FI_EX_SocialExpNote1Caption").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.交際費備考2キャプション。
		/// </summary>
		protected string FI_EX_SocialExpNote2Caption
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 36).Append("_FI_EX_SocialExpNote2Caption").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.交通費備考1キャプション。
		/// </summary>
		protected string FI_EX_TrffcExpNote1Caption
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 35).Append("_FI_EX_TrffcExpNote1Caption").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.交通費備考2キャプション。
		/// </summary>
		protected string FI_EX_TrffcExpNote2Caption
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 35).Append("_FI_EX_TrffcExpNote2Caption").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.その他備考1キャプション。
		/// </summary>
		protected string FI_EX_EtcNote1Caption
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 30).Append("_FI_EX_EtcNote1Caption").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.その他備考2キャプション。
		/// </summary>
		protected string FI_EX_EtcNote2Caption
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 30).Append("_FI_EX_EtcNote2Caption").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.照会検索範囲経費伝票自。
		/// </summary>
		protected string FI_EX_RefSearchScopeExpSlipFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 40).Append("_FI_EX_RefSearchScopeExpSlipFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.照会検索範囲経費伝票至。
		/// </summary>
		protected string FI_EX_RefSearchScopeExpSlipTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 38).Append("_FI_EX_RefSearchScopeExpSlipTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.照会検索範囲経費計上自。
		/// </summary>
		protected string FI_EX_RefSearchScopeExpBookFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 40).Append("_FI_EX_RefSearchScopeExpBookFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.照会検索範囲経費計上至。
		/// </summary>
		protected string FI_EX_RefSearchScopeExpBookTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 38).Append("_FI_EX_RefSearchScopeExpBookTo").ToString()];}
		}
// 管理番号K24284 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.プロジェクト入力必須フラグ。
		/// </summary>
		protected bool ProjInputExIndisFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 30).Append("_ProjInputExIndisFlg").ToString()]; }
		}
// 管理番号K24284 To
// 管理番号 K24269 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_EX）.出納口座区分。
		/// </summary>
		protected string FI_EX_CashierAcType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 38).Append("_FI_EX_CashierAcType").ToString()];}
		}
// 管理番号 K24269 To 
		#endregion

		#region Application FI.MYCOMP_FI_FA
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.固定資産年度。
		/// </summary>
		protected string FI_FA_FixedAssetYear
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 29).Append("_FI_FA_FixedAssetYear").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.申告年度。
		/// </summary>
		protected string FI_FA_ReturnYear
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 25).Append("_FI_FA_ReturnYear").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.減価償却費確定年月。
		/// </summary>
		protected string FI_FA_DepresiationFixYear
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 34).Append("_FI_FA_DepresiationFixYear").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.計上サイクル区分。
		/// </summary>
		protected string FI_FA_BookCycleType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 28).Append("_FI_FA_BookCycleType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.仕訳計上年月。
		/// </summary>
		protected string FI_FA_JrnlBookYear
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 27).Append("_FI_FA_JrnlBookYear").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.除売却時使用簿価区分。
		/// </summary>
		protected string FI_FA_ScrapSaleUseBookValueType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 40).Append("_FI_FA_ScrapSaleUseBookValueType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.資産移動時償却費負担区分。
		/// </summary>
		protected string FI_FA_AssetTransferShareType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 37).Append("_FI_FA_AssetTransferShareType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.償却限度額及び残存額端数処理区分。
		/// </summary>
		protected string FI_FA_AmtFractionRoundType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 35).Append("_FI_FA_AmtFractionRoundType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.課税標準額決定区分。
		/// </summary>
		protected string FI_FA_TaxBaseType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 26).Append("_FI_FA_TaxBaseType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.備考項目1。
		/// </summary>
		protected string FI_FA_CommentName1
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 27).Append("_FI_FA_CommentName1").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.備考項目2。
		/// </summary>
		protected string FI_FA_CommentName2
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 27).Append("_FI_FA_CommentName2").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.備考項目3。
		/// </summary>
		protected string FI_FA_CommentName3
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 27).Append("_FI_FA_CommentName3").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.リース料支払申請債務計上区分。
		/// </summary>
		protected string FI_FA_ApBookTypeCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 31).Append("_FI_FA_ApBookTypeCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.リース料支払申請債務計上明細。
		/// </summary>
		protected string FI_FA_ApBookDtilCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 31).Append("_FI_FA_ApBookDtilCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.資産情報承認。
		/// </summary>
		protected bool FI_FA_AssetInfoApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 36).Append("_FI_FA_AssetInfoApprovalFlg").ToString()];}
		}
// 管理番号K20684 To
// 管理番号K24284 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.プロジェクト入力必須フラグ。
		/// </summary>
		protected bool ProjInputFaIndisFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 30).Append("_ProjInputFaIndisFlg").ToString()]; }
		}
// 管理番号K24284 To
		#endregion

		#region Application FI.MYCOMP_FI_GL
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.部門別振替科目出力フラグ。
		/// </summary>
		protected bool DeptTrnsfrAccountOutputFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 35).Append("_DeptTrnsfrAccountOutputFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.部門別振替科目コード。
		/// </summary>
		protected string DeptTrnsfrAccountCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 30).Append("_DeptTrnsfrAccountCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.利益繰越部門コード。
		/// </summary>
		protected string ProfitCarryoverDeptCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 32).Append("_ProfitCarryoverDeptCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.仮仕訳使用フラグ。
		/// </summary>
		protected bool TempJrnlUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_TempJrnlUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.管理会計仕訳使用フラグ。
		/// </summary>
		protected bool CoJrnlUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 21).Append("_CoJrnlUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.勘定科目別使用制限使用フラグ。
		/// </summary>
		protected bool AccountUseRestrictUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 33).Append("_AccountUseRestrictUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.資金繰使用フラグ。
		/// </summary>
		protected bool CashManageUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 25).Append("_CashManageUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.配賦使用フラグ。
		/// </summary>
		protected bool ApportUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 21).Append("_ApportUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.社内金利配賦使用フラグ。
		/// </summary>
		protected bool InhouseInterestApportUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 36).Append("_InhouseInterestApportUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.定期計上使用フラグ。
		/// </summary>
		protected bool PeriodicBookUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 27).Append("_PeriodicBookUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.決算区分。
		/// </summary>
		protected string SttlType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 17).Append("_SttlType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.仮受消費税勘定科目コード。
		/// </summary>
		protected string TempRcptCtaxAccountCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 32).Append("_TempRcptCtaxAccountCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.仮払消費税勘定科目コード。
		/// </summary>
		protected string TempPymtCtaxAccountCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 32).Append("_TempPymtCtaxAccountCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.外貨残高評価フラグ。
		/// </summary>
		protected bool FmoneyRemainingValuationFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 36).Append("_FmoneyRemainingValuationFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.為替差益勘定科目コード。
		/// </summary>
		protected string ExchangeGainAccountCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 32).Append("_ExchangeGainAccountCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.為替差損勘定科目コード。
		/// </summary>
		protected string ExchangeLossAccountCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 32).Append("_ExchangeLossAccountCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.為替評価益勘定科目コード。
		/// </summary>
		protected string ExchangeValuationGainAccountCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 41).Append("_ExchangeValuationGainAccountCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.為替評価損勘定科目コード。
		/// </summary>
		protected string ExchangeValuationLossAccountCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 41).Append("_ExchangeValuationLossAccountCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.基軸換算金額変更範囲。
		/// </summary>
// 管理番号K16589 From
//		protected int KeyAmtChangeScope
//		{
//			get {return (int) Application[new StringBuilder(MyCompCode, 26).Append("_KeyAmtChangeScope").ToString()];}
//		}
		protected decimal KeyAmtChangeScope
		{
			get {return (decimal) Application[new StringBuilder(MyCompCode, 26).Append("_KeyAmtChangeScope").ToString()];}
		}
// 管理番号K16589 To
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.照会検索範囲日次自。
		/// </summary>
		protected string RefSearchScopeDailyFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 32).Append("_RefSearchScopeDailyFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.照会検索範囲日次至。
		/// </summary>
		protected string RefSearchScopeDailyTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 30).Append("_RefSearchScopeDailyTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.照会検索範囲月次自。
		/// </summary>
		protected string RefSearchScopeMonthlyFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 34).Append("_RefSearchScopeMonthlyFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.照会検索範囲月次至。
		/// </summary>
		protected string RefSearchScopeMonthlyTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 32).Append("_RefSearchScopeMonthlyTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.帳票検索範囲日次自。
		/// </summary>
		protected string ReportSearchScopeDailyFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 35).Append("_ReportSearchScopeDailyFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.帳票検索範囲日次至。
		/// </summary>
		protected string ReportSearchScopeDailyTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 33).Append("_ReportSearchScopeDailyTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.帳票検索範囲月次自。
		/// </summary>
		protected string ReportSearchScopeMonthlyFrom
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 37).Append("_ReportSearchScopeMonthlyFrom").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.帳票検索範囲月次至。
		/// </summary>
		protected string ReportSearchScopeMonthlyTo
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 35).Append("_ReportSearchScopeMonthlyTo").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.仕訳デフォルト区分。
		/// </summary>
		protected string JrnlDefaultType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 24).Append("_JrnlDefaultType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.仕訳単複区分。
		/// </summary>
		protected string JrnlSingulPluralType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 29).Append("_JrnlSingulPluralType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.仕訳通貨コード。
		/// </summary>
		protected string JrnlCurCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 20).Append("_JrnlCurCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.日次残高作成タイミング区分。
		/// </summary>
		protected string DailyRemainingCreationTimingType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 41).Append("_DailyRemainingCreationTimingType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.締処理タイミング区分。
		/// </summary>
		protected string CutoffProcessTimingType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 32).Append("_CutoffProcessTimingType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.赤伝仕訳区分。
		/// </summary>
		protected string RedSlipJrnlType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 24).Append("_RedSlipJrnlType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.借方固定伝票採番区分。
		/// </summary>
		protected string DrFixedSlipNumberingType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 33).Append("_DrFixedSlipNumberingType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.貸方固定伝票採番区分。
		/// </summary>
		protected string CrFixedSlipNumberingType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 33).Append("_DrFixedSlipNumberingType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.決算仕訳伝票採番区分。
		/// </summary>
		protected string SttlJrnlSlipNumberingType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 34).Append("_SttlJrnlSlipNumberingType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.入力時伝票自動出力区分。
		/// </summary>
		protected string OnentrySlipAutoOutputType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 34).Append("_OnentrySlipAutoOutputType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.伝票出力デフォルトフラグ。
		/// </summary>
		protected bool SlipOutputDefaultFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 29).Append("_SlipOutputDefaultFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.本伝票再出力許可区分。
		/// </summary>
		protected string RealSlipReOutputAllowType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 34).Append("_RealSlipReOutputAllowType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.仮伝票自動出力フラグ。
		/// </summary>
		protected bool TempSlipAutoOutputFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 30).Append("_TempSlipAutoOutputFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.仮伝票記号表示フラグ。
		/// </summary>
		protected bool TempSlipMarkDispFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 28).Append("_TempSlipMarkDispFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.部門別使用制限使用フラグ。
		/// </summary>
		protected bool DeptUseRestrictUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 30).Append("_DeptUseRestrictUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.締処理時伝票取消方法区分。
		/// </summary>
		protected string CutoffProcessSlipCancelMthdType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 40).Append("_CutoffProcessSlipCancelMthdType").ToString()];}
		}
// 管理番号K16589 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.残高明細管理。
		/// </summary>
		protected bool AccountDetailFunction
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 30).Append("_AccountDetailFunction").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.自動仕訳編集許可フラグ。
		/// </summary>
		protected bool AutoJrnlEditFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 24).Append("_AutoJrnlEditFlg").ToString()];}
		}
// 管理番号K16589 To
// 管理番号K16943 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.エラー時処理方法区分。
		/// </summary>
		protected string ErrorProcessMthdType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 29).Append("_ErrorProcessMthdType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.EDI管理画面ファイル取込方法区分。
		/// </summary>
		protected string EdiFileImportMthdType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 30).Append("_EdiFileImportMthdType").ToString()];}
		}
// 管理番号K16943 To
// 管理番号K20684 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_GL）.定期計上承認フラグ。
		/// </summary>
		protected bool PeriodicBookApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_PeriodicBookApprovalFlg").ToString()];}
		}
// 管理番号K20684 To
		#endregion

		#region Application SC.MYCOMP_SC
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.商品規格使用区分。
		/// </summary>
		protected string ProductSpecUseType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 24).Append("_ProdSpecUseType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.商品規格1規格名。
		/// </summary>
		protected string ProductSpec1Name
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 26).Append("_ProdSpec1SpecName").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.商品規格1規格英字名。
		/// </summary>
		protected string ProdSpec1SpecEngName
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 29).Append("_ProdSpec1SpecEngName").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.商品規格2規格名。
		/// </summary>
		protected string ProductSpec2Name
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 26).Append("_ProdSpec2SpecName").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.商品規格2規格英字名。
		/// </summary>
		protected string ProdSpec2SpecEngName
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 29).Append("_ProdSpec2SpecEngName").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.棚番使用フラグ。
		/// </summary>
		protected bool ShelfUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 20).Append("_ShelfUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.在庫管理単位区分。
		/// </summary>
		protected string StockAdminUnitType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 27).Append("_StockAdminUnitType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.在庫評価方法区分。
		/// </summary>
		protected string StockValuationMthdType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 31).Append("_StockValuationMthdType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.在庫評価端数丸め区分。
		/// </summary>
		protected string StockValuationFractionRoundType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 40).Append("_StockValuationFractionRoundType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.実在庫マイナス許可フラグ。
		/// </summary>
		protected bool RealStockMinusAllowFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 31).Append("_RealStockMinusAllowFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.有効在庫マイナス許可フラグ。
		/// </summary>
		protected bool ValidStockMinusAllowFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_ValidStockMinusAllowFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.ロット管理フラグ。
		/// </summary>
		protected bool LotAdminFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 20).Append("_LotAdminFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.積送品管理フラグ。
		/// </summary>
		protected bool ConsignmentAdminFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 28).Append("_ConsignmentAdminFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.未引当出荷依頼許可フラグ。
		/// </summary>
		protected bool UnallocShipRequestAllowFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 35).Append("_UnallocShipRequestAllowFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.時間帯使用フラグ。
		/// </summary>
		protected bool TimeUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 19).Append("_TimeUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.表示原価使用フラグ。
		/// </summary>
		protected bool DispCostUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_DispCostUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.海外表示原価使用フラグ。
		/// </summary>
		protected bool OverseasDispCostUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 31).Append("_OverseasDispCostUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.単価未決使用フラグ。
		/// </summary>
		protected bool PriceUndecidedUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 29).Append("_PriceUndecidedUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.「オープンプライス」文言。
		/// </summary>
		protected string OpenPriceWord
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 22).Append("_OpenPriceWord").ToString()];}
		}
// 管理番号 K16671 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.「参照コード」文言。
		/// </summary>
		protected string RefCodeWord
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 22).Append("_RefCodeWord").ToString()];}
		}
// 管理番号 K16671 To
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.売上計上基準区分。
		/// </summary>
		protected string SABookBasisType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 24).Append("_SABookBasisType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.仕入計上基準区分。
		/// </summary>
		protected string PUBookBasisType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 24).Append("_PUBookBasisType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.出荷依頼区分。
		/// </summary>
		protected string ShipRequestType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 24).Append("_ShipRequestType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.返品在庫状態区分。
		/// </summary>
		protected string ReturnStockStatusType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 30).Append("_ReturnStockStatusType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.与信受注残表示フラグ。
		/// </summary>
		protected bool CreditSOBalanceDispFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 31).Append("_CreditSOBalanceDispFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.売上与信チェック区分。
		/// </summary>
		protected string SACreditCheckType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 26).Append("_SACreditCheckType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.出荷依頼与信チェック区分。
		/// </summary>
		protected string ShipRequestCreditCheckType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 35).Append("_ShipRequestCreditCheckType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.受注与信チェック区分。
		/// </summary>
		protected string SOCreditCheckType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 26).Append("_SOCreditCheckType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.販売予算管理単位区分。
		/// </summary>
		protected string SellBudgetAdminUnitType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 32).Append("_SellBudgetAdminUnitType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.販売品フラグ。
		/// </summary>
		protected bool SellItemFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 20).Append("_SellItemFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.得意先別単価更新フラグ。
		/// </summary>
		protected bool CustPriceUpdateFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 27).Append("_CustPriceUpdateFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.仕入先別単価更新フラグ。
		/// </summary>
		protected bool SuplPriceUpdateFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 27).Append("_SuplPriceUpdateFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.製造計画最大サイクル数。
		/// </summary>
		protected int FabPlanMaxCycleCnt
		{
			get {return (int) Application[new StringBuilder(MyCompCode, 27).Append("_FabPlanMaxCycleCnt").ToString()];}
		}
// 管理番号 B21203 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.未実現利益算出サイクル数。
		/// </summary>
		protected int UnrealizedProfitCycleCnt
		{
			get {return (int) Application[new StringBuilder(MyCompCode, 27).Append("_UnrealizedProfitCycleCnt").ToString()];}
		}
// 管理番号 B21203 To
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.形態区分「通常」使用区分。
		/// </summary>
		protected bool ModeTypeUsuallyUseType
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 31).Append("_ModeTypeUsuallyUseType").ToString()];}
		}
// 管理番号K27058 From
//		/// <summary>
//		/// アプリケーション変数にロードされている自社（SC）.形態区分「通常」文言。
//		/// </summary>
//		protected string ModeTypeUsuallyWord
//		{
//			get {return (string) Application[new StringBuilder(MyCompCode, 28).Append("_ModeTypeUsuallyWord").ToString()];}
//		}
// 管理番号K27058 To
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.形態区分「返品」使用区分。
		/// </summary>
		protected bool ModeTypeReturnUseType
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 30).Append("_ModeTypeReturnUseType").ToString()];}
		}
// 管理番号K27058 From
//		/// <summary>
//		/// アプリケーション変数にロードされている自社（SC）.形態区分「返品」文言。
//		/// </summary>
//		protected string ModeTypeReturnWord
//		{
//			get {return (string) Application[new StringBuilder(MyCompCode, 27).Append("_ModeTypeReturnWord").ToString()];}
//		}
// 管理番号K27058 To
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.形態区分「サンプル」使用区分。
		/// </summary>
		protected bool ModeTypeSampleUseType
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 30).Append("_ModeTypeSampleUseType").ToString()];}
		}
// 管理番号K27058 From
//		/// <summary>
//		/// アプリケーション変数にロードされている自社（SC）.形態区分「サンプル」文言。
//		/// </summary>
//		protected string ModeTypeSampleWord
//		{
//			get {return (string) Application[new StringBuilder(MyCompCode, 27).Append("_ModeTypeSampleWord").ToString()];}
//		}
// 管理番号K27058 To
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.形態区分「預り」使用区分。
		/// </summary>
		protected bool ModeTypeCommissionUseType
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 34).Append("_ModeTypeCommissionUseType").ToString()];}
		}
// 管理番号K27058 From
//		/// <summary>
//		/// アプリケーション変数にロードされている自社（SC）.形態区分「預り」文言。
//		/// </summary>
//		protected string ModeTypeCommissionWord
//		{
//			get {return (string) Application[new StringBuilder(MyCompCode, 31).Append("_ModeTypeCommissionWord").ToString()];}
//		}
// 管理番号K27058 To
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.形態区分「委託」使用区分。
		/// </summary>
		protected bool ModeTypeConsignUseType
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 31).Append("_ModeTypeConsignUseType").ToString()];}
		}
// 管理番号K27058 From
//		/// <summary>
//		/// アプリケーション変数にロードされている自社（SC）.形態区分「委託」文言。
//		/// </summary>
//		protected string ModeTypeConsignWord
//		{
//			get {return (string) Application[new StringBuilder(MyCompCode, 28).Append("_ModeTypeConsignWord").ToString()];}
//		}
// 管理番号K27058 To
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.見積・タブデフォルト区分。
		/// </summary>
		protected string QuoteTabDefaultType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 28).Append("_QuoteTabDefaultType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.受注・タブデフォルト区分。
		/// </summary>
		protected string SOTabDefaultType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 25).Append("_SOTabDefaultType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.発注・タブデフォルト区分。
		/// </summary>
		protected string POTabDefaultType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 25).Append("_POTabDefaultType").ToString()];}
		}
// 管理番号 K24387 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.発注依頼・タブデフォルト区分。
		/// </summary>
		protected string PORequestTabDefaultType
		{
			get { return (string)Application[new StringBuilder(MyCompCode, 25).Append("_PORequestTabDefaultType").ToString()]; }
		}
// 管理番号 K24387 To

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.売上・タブデフォルト区分。
		/// </summary>
		protected string SATabDefaultType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 25).Append("_SATabDefaultType").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.仕入・タブデフォルト区分。
		/// </summary>
		protected string PUTabDefaultType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 25).Append("_PUTabDefaultType").ToString()];}
		}
// 管理番号 K16672 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.船積入力・タブデフォルト区分。
		/// </summary>
		protected string SpmntTabDefaultType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 28).Append("_SpmntTabDefaultType").ToString()];}
		}
// 管理番号 K16672 To

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.見積・見積書使用フラグ。
		/// </summary>
		protected bool QuoteEstimateUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 28).Append("_QuoteEstimateUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.見積書・見積金額表示フラグ。
		/// </summary>
		protected bool EstimateQuoteAmtDispFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_EstimateQuoteAmtDispFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.見積書・課税対象金額表示フラグ。
		/// </summary>
		protected bool EstimateImposeAmtDispFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 33).Append("_EstimateImposeAmtDispFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.見積書・消費税金額表示フラグ。
		/// </summary>
		protected bool EstimateCtaxAmtDispFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 31).Append("_EstimateCtaxAmtDispFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.見積書・合計金額表示フラグ。
		/// </summary>
		protected bool EstimateTtlAmtDispFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 30).Append("_EstimateTtlAmtDispFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.見積・注文書使用フラグ。
		/// </summary>
		protected bool QuoteOrderFormUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 29).Append("_QuoteOrderFormUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.見積・注文請書使用フラグ。
		/// </summary>
		protected bool QuoteOrderAcknlgmtUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 33).Append("_QuoteOrderAcknlgmtUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.見積・利益計画書使用フラグ。
		/// </summary>
		protected bool QuoteProfitPlanUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 30).Append("_QuoteProfitPlanUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.受注・注文書使用フラグ。
		/// </summary>
		protected bool SOOrderFormUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 26).Append("_SOOrderFormUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.受注・注文請書使用フラグ。
		/// </summary>
		protected bool SOOrderAcknlgmtUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 30).Append("_SOOrderAcknlgmtUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.受注・受注伝票使用フラグ。
		/// </summary>
		protected bool SOSOSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_SOSOSlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.売上・売上伝票使用フラグ。
		/// </summary>
		protected bool SASASlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_SASASlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.売上・売上一覧表使用フラグ。
		/// </summary>
		protected bool SASASlipListFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_SASASlipListFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.売上・納品書使用フラグ。
		/// </summary>
		protected bool SADeliSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_SADeliSlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.売上・納品書(控)使用フラグ。
		/// </summary>
		protected bool SADeliSlipDuplicateUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_SADeliSlipDuplicateUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.売上・物品受領書使用フラグ。
		/// </summary>
		protected bool SAReceiptUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_SAReceiptUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.受注・検収書使用フラグ。
		/// </summary>
		protected bool SoAcceptanceUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_SoAcceptanceUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.受注・検収依頼書使用フラグ。
		/// </summary>
		protected bool SoAcceptanceRequestUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_SoAcceptanceRequestUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.出荷・検収書使用フラグ。
		/// </summary>
		protected bool ShipAcceptanceUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_ShipAcceptanceUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.出荷・検収依頼書使用フラグ。
		/// </summary>
		protected bool ShipAcceptanceRequestUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_ShipAcceptanceRequestUseFlg").ToString()];}
		}
// 管理番号 K24387 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.発注依頼・発注依頼伝票使用フラグ。
		/// </summary>
		protected bool PoRequestPoRequestListUseFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 26).Append("_PoRequestPoRequestListUseFlg").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.発注依頼・発注依頼書使用フラグ。
		/// </summary>
		protected bool PoRequestPoRequestSlipUseFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 30).Append("_PoRequestPoRequestSlipUseFlg").ToString()]; }
		}
// 管理番号 K24387 To

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.発注・注文書使用フラグ。
		/// </summary>
		protected bool POOrderFormUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 26).Append("_POOrderFormUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.発注・注文請書使用フラグ。
		/// </summary>
		protected bool POOrderAcknlgmtUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 30).Append("_POOrderAcknlgmtUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.発注・発注伝票使用フラグ。
		/// </summary>
		protected bool POPOSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_POPOSlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.仕入・仕入伝票使用フラグ。
		/// </summary>
		protected bool PUPUSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_PUPUSlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.仕入・仕入一覧表使用フラグ。
		/// </summary>
		protected bool PUPUSlipListFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_PUPUSlipListFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.出荷指示書使用フラグ。
		/// </summary>
		protected bool ShipRequestFormUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 30).Append("_ShipRequestFormUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.ピッキングリスト使用フラグ。
		/// </summary>
		protected bool PickingListUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 26).Append("_PickingListUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.納品書使用フラグ。
		/// </summary>
		protected bool DeliSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 23).Append("_DeliSlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.納品書（控）使用フラグ。
		/// </summary>
		protected bool DeliSlipDuplicateUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_DeliSlipDuplicateUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.物品受領書使用フラグ。
		/// </summary>
		protected bool ReceiptUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 22).Append("_ReceiptUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.海外受注・海外受注伝票使用フラグ。
		/// </summary>
		protected bool OverseasSOOverseasSOSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 39).Append("_OverseasSOOverseasSOSlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.海外受注・海外受注一覧表使用フラグ。
		/// </summary>
		protected bool OverseasSOOverseasSOListUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 39).Append("_OverseasSOOverseasSOListUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.海外売上・海外売上伝票使用フラグ。
		/// </summary>
		protected bool OverseasSAOverseasSASlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 39).Append("_OverseasSAOverseasSASlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.海外発注・海外発注伝票使用フラグ。
		/// </summary>
		protected bool OverseasPOOverseasPOSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 39).Append("_OverseasPOOverseasPOSlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.海外発注・海外発注一覧表使用フラグ。
		/// </summary>
		protected bool OverseasPOOverseasPOListUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 39).Append("_OverseasPOOverseasPOListUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.海外仕入・海外仕入伝票使用フラグ。
		/// </summary>
		protected bool OverseasPUOverseasPUSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 39).Append("_OverseasPUOverseasPUSlipUseFlg").ToString()];}
		}
// 管理番号 K16672 From

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.船積帳票出力時・INVOICE使用フラグ。
		/// </summary>
		protected bool SpmntInvoiceUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 27).Append("_SpmntInvoiceUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.船積帳票出力時・PACKING LIST使用フラグ。
		/// </summary>
		protected bool SpmntPackingListUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 31).Append("_SpmntPackingListUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.船積帳票出力時・SHIPPING INSTRUCTION使用フラグ。
		/// </summary>
		protected bool SpmntShippingInstructionUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 39).Append("_SpmntShippingInstructionUseFlg").ToString()];}
		}
// 管理番号 K16672 To

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.出庫指示書使用フラグ。
		/// </summary>
		protected bool RetrievingRequestUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 25).Append("_RetrievingRequestUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.諸掛伝票使用フラグ。
		/// </summary>
		protected bool ChargeSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 25).Append("_ChargeSlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.社内受注・社内受注伝票使用フラグ。
		/// </summary>
		protected bool InhouseSOInhouseSOSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 37).Append("_InhouseSOInhouseSOSlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.社内売上・社内売上伝票使用フラグ。
		/// </summary>
		protected bool InhouseSAInhouseSASlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 37).Append("_InhouseSAInhouseSASlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.社内発注・社内発注伝票使用フラグ。
		/// </summary>
		protected bool InhousePOInhousePOSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 37).Append("_InhousePOInhousePOSlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.社内仕入・社内仕入伝票使用フラグ。
		/// </summary>
		protected bool InhousePUInhousePUSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 37).Append("_InhousePUInhousePUSlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.製造指図・製造指図書使用フラグ。
		/// </summary>
		protected bool FabDictateFabDictateSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 39).Append("_FabDictateFabDictateSlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.製造報告・製造報告書使用フラグ。
		/// </summary>
		protected bool FabReportFabReportSlipUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 37).Append("_FabReportFabReportSlipUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.ECゲスト得意先コード。
		/// </summary>
		protected string EcGuestCustCode
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 24).Append("_EcGuestCustCode").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.ECゲスト得意先枝番。
		/// </summary>
		protected string EcGuestCustSbno
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 24).Append("_EcGuestCustSbno").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.プロジェクト別在庫管理使用フラグ。
		/// </summary>
		protected bool ProjectStockAdminUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_ProjectStockAdminUseFlg").ToString()];}
		}

// 管理番号 B16215 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.在庫調整伝票（数量・状態）使用フラグ。
		/// </summary>
		protected bool StockQtAdjUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_StockQtAdjUseFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.在庫調整伝票（単価）使用フラグ。
		/// </summary>
		protected bool StockAmtAdjUseFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_StockAmtAdjUseFlg").ToString()];}
		}
// 管理番号 B16215 To

// 管理番号K20684 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.出荷承認フラグ。
		/// </summary>
		protected bool ShipApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_ShipApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.入荷承認フラグ。
		/// </summary>
		protected bool RcptApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_RcptApprovalFlg").ToString()];}
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.在庫調整承認フラグ。
		/// </summary>
		protected bool StockAdjApprovalFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_StockAdjApprovalFlg").ToString()];}
		}
// 管理番号K20684 To
// 管理番号 K24276 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.入荷入力不要フラグ。
		/// </summary>
		protected bool RcptInputNoNeedFlg
		{
			get {return (bool) Application[new StringBuilder(MyCompCode, 32).Append("_RcptInputNoNeedFlg").ToString()];}
		}
// 管理番号 K24276 To
// 管理番号 K22327 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.減損損失時使用簿価区分。
		/// </summary>
		protected string ImpairmentLossUseBookvalueType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 36).Append("_ImpairmentLossUseBookvalueType").ToString()];}
		}
// 管理番号 K22327 To
// 管理番号 K22328 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.減損後除売却仕訳区分。
		/// </summary>
		protected string ImpairmentScrapSaleJrnlType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 33).Append("_ImpairmentScrapSaleJrnlType").ToString()];}
		}
// 管理番号 K22328 To
// 管理番号 K22332 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（FI_FA）.遡及時自動仕訳計上日区分。
		/// </summary>
		protected string RetraceJrnlBookdateType
		{
			get {return (string) Application[new StringBuilder(MyCompCode, 29).Append("_RetraceJrnlBookdateType").ToString()];}
		}
// 管理番号 K22332 To
// 管理番号 K24284 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.プロジェクト入力必須フラグ。
		/// </summary>
		protected bool ProjInputScIndisFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 30).Append("_ProjInputScIndisFlg").ToString()]; }
		}
// 管理番号 K24284 To		
// 管理番号 K24383 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.見込諸掛仕訳作成区分。
		/// </summary>
		protected string ChargeProspectAutoJrnlType
		{
			get { return (string)Application[new StringBuilder(MyCompCode, 35).Append("_ChargeProspectAutoJrnlType").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.諸掛確定区分初期値。
		/// </summary>
		protected string InitChargeFixType
		{
			get { return (string)Application[new StringBuilder(MyCompCode, 26).Append("_InitChargeFixType").ToString()]; }
		}
// 管理番号 K24383 To
// 管理番号 K25671 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.返品分未引当数表示フラグ。
		/// </summary>
		/// <value>含む場合はtrue, 含まない場合はfalse</value>
		protected bool ReturnUnallocQtDispFlg
		{
			get { return (bool)GetCompApplicationVariable("ReturnUnallocQtDispFlg"); }
		}
// 管理番号 K25671 To
// 管理番号K26524 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.受発注倉庫区分初期値。
		/// </summary>
		protected string InitSoPoWhType
		{
			get { return (string)GetCompApplicationVariable("InitSoPoWhType"); }
		}
// 管理番号K26524 To
// 管理番号K27058 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.「事後」使用区分。
		/// </summary>
		protected bool PostUseType
		{
			get { return (bool)GetCompApplicationVariable("PostUseType"); }
		}
// 管理番号K27058 To
// 管理番号K27059 From
		/// <summary>
		/// アプリケーション変数にロードされている自社（SC）.商品検索初期値使用フラグ
		/// </summary>
		protected bool InitProdSearchWindowUseFlg
		{
			get { return (bool)Application[new StringBuilder(MyCompCode, 35).Append("_InitProdSearchWindowUseFlg").ToString()]; }
		}
// 管理番号K27059 To
		#endregion

// 管理番号 K24390 From
		#region Application 最大表示明細数
		/// <summary>
		/// アプリケーション変数にロードされている支払申請入力の最大表示明細数。
		/// </summary>
		protected int FI_AP_03_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_FI_AP_03_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている支払予定変更の最大表示明細数。
		/// </summary>
		protected int FI_AP_04_S16_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_FI_AP_04_S16_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている請求申請入力の最大表示明細数。
		/// </summary>
		protected int FI_AR_03_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_FI_AR_03_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている回収消込入力の最大表示明細数。
		/// </summary>
		protected int FI_AR_06_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_FI_AR_06_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている仕訳伝票入力の最大表示明細数。
		/// </summary>
		protected int FI_GL_03_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_FI_GL_03_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている定型仕訳登録の最大表示明細数。
		/// </summary>
		protected int FI_GL_03_S09_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_FI_GL_03_S09_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている遡及仕訳伝票入力の最大表示明細数。
		/// </summary>
		protected int FI_GL_16_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_FI_GL_16_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている受発注入力の最大表示明細数。
		/// </summary>
		protected int SC_MS_04_S01_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MS_04_S01_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている売上仕入入力の最大表示明細数。
		/// </summary>
		protected int SC_MS_04_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MS_04_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている諸掛入力の最大表示明細数。
		/// </summary>
		protected int SC_MS_06_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MS_06_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている見積入力の最大表示明細数。
		/// </summary>
		protected int SC_SD_04_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_SD_04_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている受注入力の最大表示明細数。
		/// </summary>
		protected int SC_SD_05_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_SD_05_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている海外受注入力の最大表示明細数。
		/// </summary>
		protected int SC_SD_05_S04_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_SD_05_S04_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている出荷依頼入力の最大表示明細数。
		/// </summary>
		protected int SC_SD_06_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_SD_06_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている出荷入力の最大表示明細数。
		/// </summary>
		protected int SC_SD_07_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_SD_07_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている出荷返品入力の最大表示明細数。
		/// </summary>
		protected int SC_SD_07_S04_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_SD_07_S04_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている売上入力の最大表示明細数。
		/// </summary>
		protected int SC_SD_08_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_SD_08_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている海外売上入力最大表示明細数。
		/// </summary>
		protected int SC_SD_08_S04_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_SD_08_S04_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている発注入力の最大表示明細数。
		/// </summary>
		protected int SC_MM_03_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MM_03_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている海外発注入力の最大表示明細数。
		/// </summary>
		protected int SC_MM_03_S04_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MM_03_S04_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている入荷入力の最大表示明細数。
		/// </summary>
		protected int SC_MM_04_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MM_04_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている入荷返品登録の最大表示明細数。
		/// </summary>
		protected int SC_MM_04_S05_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MM_04_S05_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている仕入入力の最大表示明細数。
		/// </summary>
		protected int SC_MM_05_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MM_05_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている海外仕入入力の最大表示明細数。
		/// </summary>
		protected int SC_MM_05_S04_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MM_05_S04_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている在庫数量・状態調整入力の最大表示明細数。
		/// </summary>
		protected int SC_MM_08_S01_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MM_08_S01_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている倉庫移動出庫依頼入力の最大表示明細数。
		/// </summary>
		protected int SC_MM_09_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MM_09_S02_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている倉庫移動出庫入力の最大表示明細数。
		/// </summary>
		protected int SC_MM_09_S03_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MM_09_S03_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている倉庫移動入庫入力の最大表示明細数。
		/// </summary>
		protected int SC_MM_09_S04_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MM_09_S04_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている発注依頼入力の最大表示明細数。
		/// </summary>
		protected int SC_MM_10_S02_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_MM_10_S02_DtilNumber").ToString()]; }
		}
// 管理番号 K24390 To
// 管理番号K27487 From
		/// <summary>
		/// アプリケーション変数にロードされている受注一括入力／受注個別入力の最大表示明細数。
		/// </summary>
		protected int SC_XF_03_S03_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_XF_03_S03_DtilNumber").ToString()]; }
		}

		/// <summary>
		/// アプリケーション変数にロードされている発注一括入力／発注個別入力の最大表示明細数。
		/// </summary>
		protected int SC_XF_03_S04_DtilNumber
		{
			get { return (int)Application[new StringBuilder(MyCompCode, 30).Append("_SC_XF_03_S04_DtilNumber").ToString()]; }
		}
// 管理番号K27487 To
		#endregion

		#region Referrer
// 管理番号 P19346 From
		/// <summary>
		/// 遷移元のASPXファイルコード。
		/// </summary>
		protected string ReferrerASPXFileCode
		{
			get
			{
				try
				{
					string myReferrerPageId = string.Empty;
					int slashIndex = 0;
					int myCount = 0;
					if (Request.QueryString["referrer"] == null)
					{
						//refrrerがnullの場合は、メニューからの起動でないため、通常のreferrerを取得する
						myReferrerPageId = System.Web.HttpContext.Current.Request.UrlReferrer.ToString();
					}
					else
					{
						//メニューからの起動時、refrrerの値を取得
						myReferrerPageId = Request.QueryString["referrer"];
					}
					//クエリストリング部分を削除
					if ( ( myCount = myReferrerPageId.IndexOf('?') ) >= 0 )
					{
						myReferrerPageId = myReferrerPageId.Substring( 0,myCount );
					}
					slashIndex = myReferrerPageId.LastIndexOf('/');
					slashIndex++;
					myReferrerPageId = myReferrerPageId.Substring(slashIndex, myReferrerPageId.Length - slashIndex - 5).ToUpper();
					return myReferrerPageId;
				}
				catch( Exception )
				{
					return string.Empty;
				}
			}	
		}
// 管理番号 P19346 To
		#endregion

// 管理番号K26528 From
		#region StartupScript
		/// <summary>
		/// 即時実行用スタートアップスクリプト
		/// </summary>
		protected internal StartupScriptManager ImmediateStartupScript
		{
			get { return GetStartupScriptManager((int)StartupPriority.Immediate); }
		}

		/// <summary>
		/// ページ基底クラス用スタートアップスクリプト
		/// </summary>
		protected StartupScriptManager BaseStartupScript
		{
			get { return GetStartupScriptManager((int)StartupPriority.Base); }
		}

		/// <summary>
		/// コントロールクラス用スタートアップスクリプト
		/// </summary>
		internal StartupScriptManager ControlStartupScript
		{
			get { return GetStartupScriptManager((int)StartupPriority.Control); }
		}

		/// <summary>
		/// ページクラス用スタートアップスクリプト
		/// </summary>
		protected StartupScriptManager PageStartupScript
		{
			get { return GetStartupScriptManager((int)StartupPriority.Page); }
		}
		#endregion
// 管理番号K26528 To
		#endregion

		#region Methods
		/// <summary>
		/// 現在の自社コードにおけるアプリケーション変数の値を取得します。
		/// </summary>
		/// <param name="paramName">
		/// アプリケーション変数名
		/// </param>
		/// <returns>
		/// 自社コードにおけるアプリケーション変数の値。
		/// </returns>
		public object GetCompApplicationVariable(string paramName)
		{
// 管理番号 K25902 From
//			StringBuilder param = new StringBuilder(MyCompCode, 40);
//			param.Append('_').Append(paramName);
//			return Application[param.ToString()];
			return Application[MyCompCode + "_" + paramName];
// 管理番号 K25902 To
		}

		/// <summary>
		/// 指定したコントロールに対してフォーカスをセットします。
		/// FocusControlが複数回呼び出された場合、最初の呼び出しのみ有効となります。
		/// </summary>
		/// <param name="controlID">
		/// コントロールID
		/// </param>
		protected virtual void FocusControl(string controlID)
		{
			if (!isFocusControlRegistered)
			{
				activeControlID = controlID;
				isFocusControlRegistered = true;
			}
		}
// 管理番号K22158 From

		/// <summary>
		/// 指定したコントロールIDの区切り文字列の$を:に置換します。
		/// </summary>
		/// <param name="controlID">
		/// コントロールID
		/// </param>
		/// <returns>
		/// 置換した後の文字列。
		/// </returns>
// 管理番号K26528 From
		[Obsolete]
// 管理番号K26528 To
		protected string changeIDSeparator(string controlID)
		{
			if (controlID == null || controlID == string.Empty)
			{
				return controlID;
			}
			else
			{
				return controlID.Replace("$", ":");
			}
		}
// 管理番号K22158 To

		/// <summary>
		/// 指定したコントロールに対してフォーカスをセットします。
		/// <paramref name="sender"/>がポストバックイベントの発生元だった場合、以前のFocusControlの呼び出しよりも優先されます。
		/// </summary>
		/// <param name="controlID">
		/// コントロールID
		/// </param>
		/// <param name="sender">
		/// イベントのソース。
		/// </param>
		protected virtual void FocusControl(string controlID, object sender)
		{
// 管理番号K22158 From
            //if (sender is Control)
            //{
            //    Control ctl = (Control)sender;
            //    if (ctl.UniqueID == Request.Form["__EVENTTARGET"])
            //    {
            //        OverRideFocus(controlID);
            //    }
            //}
            //else
            //{
            //    FocusControl(controlID);
            //}
            if (sender is Control)
            {
                Control ctl = (Control)sender;
                if (!ctl.ClientID.Equals("__Page"))
                {
// 管理番号K26528 From
//                    if (ctl.UniqueID == changeIDSeparator(Request.Form["__EVENTTARGET"]))
					if (ctl.UniqueID == Request.Form["__EVENTTARGET"])
// 管理番号K26528 To
                    {
                        OverRideFocus(controlID);
                    }
                }
                else
                {
                    FocusControl(controlID);
                }
            }
            else
            {
                FocusControl(controlID);
            }
// 管理番号K22158 To
		}

		/// <summary>
		/// 指定したコントロールに対してフォーカスをセットします。
		/// <see cref="OverRideFocus"/>が複数回呼び出された場合、最後の呼び出しのみ有効となります。
		/// </summary>
		/// <param name="controlID">
		/// コントロールID
		/// </param>
		protected virtual void OverRideFocus(string controlID)
		{
			activeControlID = controlID;
			isFocusControlRegistered = true;
		}

		/// <summary>
		/// FocusControlや<see cref="OverRideFocus"/>によるフォーカスの設定を無効にします。
		/// </summary>
		protected virtual void SetDefaultFocus()
		{
			registeredFocusAtPreRender = true;
		}

		/// <summary>
		/// 画面を閉じるスタートアップスクリプトを優先度<see cref="StartupPriority.Page" />で登録します。
		/// <para>
		/// 画面を閉じる前に別のスタートアップスクリプトによるポストバックを発生させることはできません（ポストバックの発生は抑止されます）。
		/// </para>
		/// </summary>
		protected void CloseWindow()
		{
// 管理番号K26528 From
//			if (!ClientScript.IsStartupScriptRegistered("CloseWindow"))
//			{
//				ClientScript.RegisterStartupScript(this.GetType(), "CloseWindow", "<script type=\"text/javascript\">window.close();</script>");
//			}
			this.CloseWindow(string.Empty);
// 管理番号K26528 To
		}

// 管理番号K26528 From
		/// <summary>
		/// 任意のスクリプトを実行後に画面を閉じるスタートアップスクリプトを優先度<see cref="StartupPriority.Page" />で登録します。
		/// <para>
		/// 画面を閉じる前に別のスタートアップスクリプトによるポストバックを発生させたり、
		/// <paramref name="script"/>でポストバックを発生させる処理を登録することはできません（ポストバックの発生は抑止されます）。
		/// キーの先頭にPageID + _Temporary_ を持つセッションを破棄します。
		/// </para>
		/// </summary>
		/// <param name="script">画面を閉じる前に実行する任意のスクリプト断片</param>
		protected void CloseWindow(string script)
		{
			// 画面を閉じるスクリプトの実行前にポストバックが行われるのを抑止するため、多重ポストを抑止する関数の実行を登録しておく
			if(!ImmediateStartupScript.IsScriptRegistered("PrepareCloseWindow"))
			{
				ImmediateStartupScript.RegisterScript(this.GetType(), "PrepareCloseWindow", "forbidDuplicationSubmit();");
			}

			if(!PageStartupScript.IsScriptRegistered("CloseWindow"))
			{
				var sb = new StringBuilder();
				sb.Append(script);
				sb.AppendLine(script.TrimEnd().EndsWith(";") ? string.Empty : ";");	// セミコロンが付いてないなら補完する
				sb.AppendLine("CM_closePage();");
				PageStartupScript.RegisterScript(this.GetType(), "CloseWindow", sb.ToString());
			}
// 管理番号K27057 From
			List<string> removeList = new List<string>();
			foreach (string key in Page.Session.Contents)
			{
				if (key.StartsWith(PageID + "_Temporary_"))
				{
					removeList.Add(key);
				}
			}
			foreach (string key in removeList)
			{
				Page.Session.Remove(key);
			}
// 管理番号K27057 To
		}

		/// <summary>
		/// 指定されたページIDのコンテンツをダウンロードします
		/// </summary>
		/// <param name="pageId">ダウンロード用ページID</param>
		/// <param name="queryString">クエリ文字列</param>
		/// <param name="key">スクリプトのキー（省略可）</param>
		protected void RegisterDownLoadScript(string pageId, string queryString = "", string key = "__RegisterDownLoadScript")
		{
			if(!PageStartupScript.IsScriptRegistered(key))
			{
				// パラメータ整形
// 管理番号B27044 From
//				string paramString 
//					= ("'" + pageId  + "'")
//					+ (string.IsNullOrEmpty(queryString) ? string.Empty : ", '" + queryString.Trim() + "'");
				string paramString
					= ("'" + pageId.Replace("'","\\'") + "'")
					+ (string.IsNullOrEmpty(queryString) ? string.Empty : ", '" + queryString.Replace("'","\\'").Trim() + "'");
// 管理番号B27044 To

				// 関数呼び出しスクリプト登録
				PageStartupScript.RegisterScript(GetType(), key, "CM_openDownLoadPage(" + paramString + ")");
			}
		}
// 管理番号K26528 To

		/// <summary>
		/// アラートを表示するスタートアップスクリプトを優先度<see cref="StartupPriority.Page" />で登録します。
		/// </summary>
		/// <param name="message">
		/// アラートメッセージ
		/// </param>
		protected void ShowAlert(string message)
		{
// 管理番号K26528 From
//			if (!ClientScript.IsStartupScriptRegistered("ShowAlert"))
			if (!PageStartupScript.IsScriptRegistered("ShowAlert"))
// 管理番号K26528 To
			{
// 管理番号K26528 From
//				StringBuilder script = new StringBuilder("<script type=\"text/javascript\">alert(\"", 64);
//				script.Append(message);
//				script.Append("\");</script>");
//				ClientScript.RegisterStartupScript(this.GetType(), "ShowAlert", script.ToString());
				string script = "alert(\"" + message + "\");";
				PageStartupScript.RegisterScript(this.GetType(), "ShowAlert", script);
// 管理番号K26528 To
			}
		}

		/// <summary>
		/// 指定したメッセージを画面表示用にHTMLに変換して返します。
		/// </summary>
		/// <param name="message">
		/// メッセージ
		/// </param>
		/// <returns>
		/// HTMLに変換されたメッセージ。
		/// </returns>
		protected string HtmlMessage(string message)
		{
			return HtmlMessage(message, Infocom.Allegro.MessageLevel.Info);
		}

		/// <summary>
		/// 指定したメッセージを画面表示用にHTMLに変換して返します。
		/// </summary>
		/// <param name="message">
		/// メッセージ
		/// </param>
		/// <param name="messageLevel">
		/// メッセージレベル
		/// </param>
		/// <returns>
		/// HTMLに変換されたメッセージ。
		/// </returns>
		protected string HtmlMessage(string message, MessageLevel messageLevel)
		{
// 管理番号K26528 From
//			StringBuilder sb = new StringBuilder(1024);
//
//			switch (messageLevel)
//			{
//				case Infocom.Allegro.MessageLevel.Warning:
//					sb.Append("<table cellspacing=\"0\" cellpadding=\"1\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_2_1\">");
//					sb.Append("<table cellspacing=\"1\" cellpadding=\"3\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_2_2\">");
//					sb.Append("<span class=\"msg_fnt_2\">");
//					sb.Append(message.TrimEnd(' ', '\r', '\n'));
//					sb.Append("</span><br>");
//					sb.Append("</td></tr></table>");
//					sb.Append("</td></tr></table>");
//					sb.Replace("\r\n", "<br>");
//					break;
//				case Infocom.Allegro.MessageLevel.Info:
//					sb.Append("<table cellspacing=\"0\" cellpadding=\"1\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_1_1\">");
//					sb.Append("<table cellspacing=\"1\" cellpadding=\"3\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_1_2\">");
//					sb.Append("<span class=\"msg_fnt_1\">");
//					sb.Append(message.TrimEnd(' ', '\r', '\n'));
//					sb.Append("</span><br>");
//					sb.Append("</td></tr></table>");
//					sb.Append("</td></tr></table>");
//					sb.Replace("\r\n", "<br />");
//					break;
//			}
//
//			return sb.ToString();
			return new Html.HtmlNoticeMessage(message, messageLevel).ToHtml();
// 管理番号K26528 To
		}

		/// <summary>
		/// エラー画面に遷移します。
		/// </summary>
		/// <param name="message">
		/// エラーメッセージ
		/// </param>
		protected void TransferErrorPage(string message)
		{
			Session.Add("CM_AC_ErrorMessage", message);
			Server.Transfer(errorPage);
		}

		/// <summary>
		/// 公開単位区分をセットします。
		/// </summary>
		/// <param name="disclosureUnitType">公開単位区分</param>
		private void SetDisclosureUnitType(string disclosureUnitType)
		{
			Session.Add(new StringBuilder("CM_AC_", 38).Append(PageID).Append("_DisclosureUnitType").ToString(), disclosureUnitType);
		}

// 管理番号K26508 From
		/// <summary>
		/// 権限設定区分をセットします。
		/// </summary>
		/// <param name="authoritySettingType">権限設定区分  更新権限：U、参照権限：V</param>
		private void SetAuthoritySettingType(string authoritySettingType)
		{
			Session.Add("CM_AC_" + PageID + "_AuthoritySettingType", authoritySettingType);
		}
// 管理番号K26508 To

// 管理番号 P19346 From
		/// <summary>
		/// ViewState/Session入替え処理における絶対除外画面判断処理
		/// </summary>
		/// <param name="aspxFileName">判断したいASPXファイル名</param>
		/// <returns>
		/// ViewState/Session入替え処理における絶対除外画面の場合は<b>true</b>。
		/// 絶対除外画面でない場合は<b>false</b>を返します。
		/// </returns>
		private static bool IsCompleteExclusionPage( string aspxFileName )
		{
			switch( aspxFileName )
			{
					//ログイン画面は絶対に除外
				case ASPX_OF_LOGIN:
// 管理番号 K24546 From
				case ASPX_OF_LOGIN_FOR_DEMO:
// 管理番号 K24546 To
					return true;
					//ECログイン画面は絶対に除外
				case ASPX_OF_ECLOGIN:
					return true;
					//メインメニュー画面は絶対に除外
				case ASPX_OF_MENU:
					return true;
					//ECメニュー画面は絶対に除外
				case ASPX_OF_ECMENU:
					return true;
// 管理番号K27443 From
					// 仮パスワード発行確認画面
				case ASPX_OF_TEMP_PASS_CHECK:
					return true;
// 管理番号K27443 To
					//上記にあてはまらない場合は除外しない
				default: return false;
			}
		}
// 管理番号 P19346 To
// 管理番号 B24424 From
		/// <summary>
		/// セッションタイムアウトの判定
		/// </summary>
		private bool IsSessionTimeout()
		{
			// ログイン画面やECログイン画面ではない場合は、ログインチェックを行う
			return ASPXFileCode != ASPX_OF_LOGIN
// 管理番号 K24546 From
				&& ASPXFileCode != ASPX_OF_LOGIN_FOR_DEMO
// 管理番号 K24546 To
				&& ASPXFileCode != ASPX_OF_ECLOGIN
// 管理番号K27443 From
				&& ASPXFileCode != ASPX_OF_TEMP_PASS_CHECK
// 管理番号K27443 To
				&& !LoginFlg;
		}
// 管理番号 B24424 To

// 管理番号 B25191 From
		/// <summary>
		/// アクセス権限のチェックフラグ
		/// </summary>
		/// <returns>
		/// アクセス権限のチェックフラグを返します。
		/// </returns>
		private string GetAccessAuthority()
		{
			try
			{
				string stAcAuth = "0";

// 管理番号K27230 From
//				if (Request.QueryString["acAuth"] == null)
				bool isDrillThrough = IsDrillThrough();
				if (!isDrillThrough)
// 管理番号K27230 To
				{
					if (Session["AccessAuthority"] != null)
					{
						stAcAuth = (string)Session["AccessAuthority"];
					}
				}
				else
				{
// 管理番号K27230 From
//					stAcAuth = Request.QueryString["acAuth"];
					stAcAuth = (string)Session["DrillThroughAcAuth"];
					Session.Remove("DrillThroughAcAuth");
// 管理番号K27230 To
					Session["AccessAuthority"] = stAcAuth;
				}

				// 新規等の入力が行なわれる場合、フラグを一時的にＯＦＦにする
// 管理番号K27230 From
//				if (stAcAuth == "1")
				// ParamTypeの改竄でフラグがOFFになるのを防ぐ為、条件追加
				if (stAcAuth == "1" && !isDrillThrough)
// 管理番号K27230 To
				{
					if (Request.QueryString["ParamType"] != null)
					{
						if (Request.QueryString["ParamType"] == "New" ||	// 新規 
							Request.QueryString["ParamType"] == "Mod" ||	// 修正
							Request.QueryString["ParamType"] == "Copy"		// コピー
							)
						{
							stAcAuth = "0";
						}
					}
				}

				return stAcAuth;
			}
			catch (Exception)
			{
				return "0";
			}
		}
// 管理番号 B25191 To
// 管理番号K27230 From
		/// <summary>
		/// 仕訳伝票入力のドリルスルー機能による遷移かどうかの判定
		/// </summary>
		/// <returns>ドリルスルー機能による遷移ならtrue</returns>
		private bool IsDrillThrough()
		{
			// 仕訳伝票入力のドリルスルー対象画面
			string[] targetPageId =
				{
					"FI_EX_03_S05",
					"FI_EX_03_S07",
					"FI_EX_03_S08",
					"FI_EX_03_S06",
					"FI_EX_04_S10",
					"FI_EX_04_S11",
					"FI_AP_03_S02",
					"FI_AP_05_S20",
					"FI_AP_06_S02",
					"FI_AP_07_S02",
					"FI_AR_03_S02",
					"FI_AR_05_S02",
					"FI_AR_06_S02",
					"FI_AR_07_S02",
					"FI_AR_08_S02",
					"SC_MF_05_S02",
					"SC_MS_04_S02",
					"SC_SD_08_S04",
					"SC_SD_08_S02",
					"SC_MM_05_S04",
					"SC_MM_05_S02",
					"SC_MM_08_S02",
					"SC_MM_08_S01",
					"SC_MS_05_S06",
					"SC_MS_06_S02",
					"SC_MS_09_S02"
				};

			return Session["DrillThroughAcAuth"] != null && targetPageId.Contains(PageID);
		}
// 管理番号K27230 To
// 管理番号 K25902 From
		/// <summary>
		/// アプリケーション変数にロードされている指定した画面におけるデータグリッド出力コードページを取得します。
		/// </summary>
		/// <param name="pageId">
		/// ページID
		/// </param>
		/// <returns>
		/// データグリッド出力コードページ
		/// </returns>
		public string GetDataGridDownLoadCodePage(string pageId)
		{
			try
			{
				DataTable dt = (DataTable)GetCompApplicationVariable("DataGridDownloadInfo");
				DataRow[] row = dt.Select("[PAGE_CODE] = '" + pageId.Replace("'", "''") + "'");
				return row[0]["DATAGRID_FILE_EXPORT_CODE_PAGE"].ToString();
			}
			catch
			{
				TransferErrorPage(AllegroMessage.CM_AC_S20004);
				return null;
			}
		}
// 管理番号 K25902 To

// 管理番号K26528 From
		/// <summary>
		/// <c>Response.Redirect</c>の代替メソッド。<c>Response.Redirect</c>は使用しないでください。
		/// </summary>
		/// <param name="url">リダイレクト先URL</param>
		public static void ResponseRedirect(string url)
		{
			TokenManager.ResponseRedirect(url);
		}

		/// <summary>
		/// <c>Server.Transfer</c>の代替メソッド。<c>Server.Transfer</c>は使用しないでください。
		/// </summary>
		/// <param name="path">転送先パス</param>
		public static void ServerTransfer(string path)
		{
			TokenManager.ServerTransfer(path);
		}

		/// <summary>
		/// スタートアップスクリプトを登録します。
		/// </summary>
		private void RegisterStartupScript()
		{
			// スタートアップスクリプト登録キー
			const string onImmediateKey = "__ImmediateStartupScript";
			const string onloadKey = "__LoadStartupScript";

			if(!ClientScript.IsStartupScriptRegistered(onImmediateKey))
			{
				if (startupScriptManager.ContainsKey((int)StartupPriority.Immediate))
				{
					// ステートメント取得
					var statements = startupScriptManager[(int)StartupPriority.Immediate].CallStatements;
					if (statements.Any())
					{
						// スクリプトを整形して登録
						string script = Environment.NewLine + string.Join(Environment.NewLine, statements.ToArray());
						ClientScript.RegisterStartupScript(this.GetType(), onImmediateKey, script, true);
					}
				}
			}

			if(!ClientScript.IsStartupScriptRegistered(onloadKey))
			{
				// ステートメント取得
				List<string> statements = new List<string>();
				startupScriptManager
					.Where(kv => kv.Key != (int)StartupPriority.Immediate && 0 < kv.Value.ScriptCount)
					.ToList()
					.ForEach(kv => statements.AddRange(kv.Value.CallStatements));

				if (statements.Any())
				{
					// スクリプトを整形して登録
					int startupDelay = IsPostBack ? 10 : 100;
					StringBuilder script = new StringBuilder();
					script.AppendLine();
					script.AppendLine("addEvent(window, 'load', function() {");
					script.AppendLine("\t" + "setTimeout(function() {");
					script.AppendLine("\t\t" + string.Join(Environment.NewLine + "\t\t", statements.ToArray()));
					script.AppendLine("\t" + "}, " + startupDelay + ");");
					script.AppendLine("});");

					ClientScript.RegisterStartupScript(this.GetType(), onloadKey, script.ToString(), true);
				}
			}
		}

		/// <summary>
		/// 指定された優先度のStartupScriptManagerを取得します。
		/// </summary>
		/// <param name="priority">優先度</param>
		/// <returns>指定された優先度のStartupScriptManager</returns>
		private StartupScriptManager GetStartupScriptManager(int priority)
		{
			// 指定された優先度のStartUpScriptManagerがないなら登録
			if (!startupScriptManager.ContainsKey(priority))
			{
				startupScriptManager.Add(priority, new StartupScriptManager(this));
			}
			return startupScriptManager[priority];
		}

		/// <summary>
		/// Web.configに定義された検索件数の上限値を返します。
		/// 未定義、ゼロ以下の場合は引数で指定された値をそのまま返します。
		/// </summary>
		/// <param name="defaultValue">Web.configに定義されていなかった場合の既定値</param>
		/// <returns></returns>
		protected static int GetWarningRowCount(int defaultValue)
		{
			var warningRowCount = Configuration.DebugSettings.Get("WarningRowCount", 0);
			return warningRowCount > 0 ? warningRowCount : defaultValue;
		}

		/// <summary>
		/// ポストバックに利用するURLを書き換えます。既定ではリクエストURLと同一です。
		/// このメソッドをオーバーライドする事でポストバック先URLを変更できます。
		/// </summary>
		protected virtual void RewritePostBackUrl()
		{
			// URLエンコードされたクエリストリングが送られてきた場合、ポストバック先URLであるFormのactionが、不正にエスケープされたURLとなってしまう。
			// この不正なURLで発生したポストバックのレスポンスを受け取ると、IEでは「msSaveOrOpenBlob」が失敗してしまい、ファイルのダウンロードが出来なくなる。
			// そのため、ポストバック先URLが不正とならないよう、明示的にリクエストURLと同一にする。
			// ただし、Transferされてきた場合は下記かをを行わない
			if (this.Form != null 
				&& string.IsNullOrEmpty(this.Form.Action)
				&& Context.Handler == this
			)
			{
				this.Form.Action = Request.RawUrl;
			}
		}
// 管理番号K26528 To
		#endregion

		#region Override Methods
// 管理番号 B23962 From

		/// <summary>
		/// <see cref="Control.Init"/>イベントを発生させてページを初期化します。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnInit(EventArgs e)
		{
// 管理番号 B24424 From
//			// ログイン画面やECログイン画面ではない場合は、ログインチェックを行う
//			if (ASPXFileCode != ASPX_OF_LOGIN
//				&& ASPXFileCode != ASPX_OF_ECLOGIN
//				&& !LoginFlg)
//			{
//				// ログインフラグが取得できなかった場合
//				TransferErrorPage(AllegroMessage.CM_AC_S20003);
//			}
			if (IsSessionTimeout())
			{
				TransferErrorPage(AllegroMessage.CM_AC_S20003);
			}
// 管理番号 B24424 To

// 管理番号B27167 From
			// CSRF対策
			ViewStateUserKey = Session.SessionID;
// 管理番号B27167 To

// 管理番号K26528 From
			// 画面トークンのチェック
			// ログイン画面とかは対象外
// 管理番号K27443 From
//			var whiteList = new[] { ASPX_OF_LOGIN, ASPX_OF_LOGIN_FOR_DEMO, ASPX_OF_ECLOGIN };
			var whiteList = new[] { ASPX_OF_LOGIN, ASPX_OF_LOGIN_FOR_DEMO, ASPX_OF_ECLOGIN, ASPX_OF_TEMP_PASS_CHECK };
// 管理番号K27443 To
			if (!whiteList.Contains(ASPXFileCode)
				&& !TokenManager.ValidateToken(true)
				)
			{
				return;
			}
// 管理番号K26528 To
			base.OnInit(e);
		}
// 管理番号 B23962 To

		/// <summary>
		/// <see cref="Control.Load"/>イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnLoad(EventArgs e)
		{
// 管理番号K26528 From
			// ポストバックURLの設定
			RewritePostBackUrl();
// 管理番号K26528 To

// 管理番号 B24424 From
			if (IsSessionTimeout())
			{
				TransferErrorPage(AllegroMessage.CM_AC_S20003);
			}
// 管理番号 B24424 To
			if (!IsPostBack)
			{
				// ログイン画面、ECログイン画面については「自社コード」が確定していないので何もチェックしない
// 管理番号K27443 From
//// 管理番号 K24546 From
////				if ((ASPXFileCode == "CM_AC_03_S01") || (ASPXFileCode == "SC_EC_01_S01"))
//				if ((ASPXFileCode == "CM_AC_03_S01") || (ASPXFileCode == "SC_EC_01_S01") || (ASPXFileCode == ASPX_OF_LOGIN_FOR_DEMO))
//// 管理番号 K24546 To
				if ((ASPXFileCode == "CM_AC_03_S01") || (ASPXFileCode == "SC_EC_01_S01") || (ASPXFileCode == ASPX_OF_LOGIN_FOR_DEMO) || (ASPXFileCode == ASPX_OF_TEMP_PASS_CHECK))
// 管理番号K27443 To
				{
					SetDisclosureUnitType("C");
// 管理番号K26508 From
					SetAuthoritySettingType("U");
// 管理番号K26508 To
				}
				else
				{
					// (1) IPアドレスチェック
					if (IPAddressCheckFlg)
					{
						if ((string) Session["SessionStartUserHostAddress"] != Request.UserHostAddress)
						{
							TransferErrorPage(AllegroMessage.CM_AC_S20002);
						}
					}
					// (2) ログインチェック
					if (!LoginFlg)
					{
						TransferErrorPage(AllegroMessage.CM_AC_S20003);
					}
					// ECログインの場合
					if (ECLoginFlg)
					{
						// (EC-3)得意先でのログインに対する「自社レベルのASPXファイル接続許諾情報」でのチェック
						if (SC_EC_CompType == "C")
						{
							DataRow[] rows = MyCompLevelASPXFileAccessPermissionTable.Select("[ASPX_FILE_CODE] = '" + ASPXFileCode.Replace("'", "''") + "' AND [EC_CUST_USE_FLG] = '1'");
							if (rows.Length == 1)
							{
								SetDisclosureUnitType("C");
// 管理番号K26508 From
								SetAuthoritySettingType("U");
// 管理番号K26508 To
							}
							else
							{
								TransferErrorPage(AllegroMessage.CM_AC_S20005);
							}
						}
						// (EC-3)仕入先でのログインに対する「自社レベルのASPXファイル接続許諾情報」でのチェック
						else if (SC_EC_CompType == "S")
						{
							DataRow[] rows = MyCompLevelASPXFileAccessPermissionTable.Select("[ASPX_FILE_CODE] = '" + ASPXFileCode.Replace("'", "''") + "' AND [EC_SUPL_USE_FLG] = '1'");
							if (rows.Length == 1)
							{
								SetDisclosureUnitType("C");
// 管理番号K26508 From
								SetAuthoritySettingType("U");
// 管理番号K26508 To
							}
							else
							{
								TransferErrorPage(AllegroMessage.CM_AC_S20005);
							}
						}
						else
						{
							TransferErrorPage(AllegroMessage.CM_AC_S20003);
						}
					}
					// 基幹ログインの場合
					else
					{
						if (!PageAccessPermissionCheckFlg)
						{
							SetDisclosureUnitType("C");
// 管理番号K26508 From
							SetAuthoritySettingType("U");
// 管理番号K26508 To
						}
						else
						{
							// (3)「自社レベルのASPXファイル接続許諾情報」でのチェック
							DataRow[] rows = MyCompLevelASPXFileAccessPermissionTable.Select("[ASPX_FILE_CODE] = '" + ASPXFileCode.Replace("'", "''") + "' AND [BASIC_USE_FLG] = '1'");
							if (rows.Length == 1)
							{
							}
							else
							{
								TransferErrorPage(AllegroMessage.CM_AC_S20005);
							}
							rows = MyCompLevelASPXFileAccessPermissionTable.Select("[ASPX_FILE_CODE] = '" + ASPXFileCode.Replace("'", "''") + "' AND [BASIC_USE_FLG] = '1' AND [ACCESS_PERMISSION_REQUEST_FLG] = '0'");
// 管理番号 B25191 From
//							if (rows.Length == 1)
							if (GetAccessAuthority() == "1" || rows.Length == 1)
// 管理番号 B25191 To
							{
								SetDisclosureUnitType("C");
// 管理番号K26508 From
								SetAuthoritySettingType("U");
// 管理番号K26508 To
							}
							else
							{
								// (4)「セッションレベルのページ接続許諾情報」でのチェック
								rows = SessionLevelPageAccessPermissionTable.Select("[PAGE_CODE] = '" + PageID.Replace("'", "''") + "' AND [ASPX_FILE_CODE] = '" + ASPXFileCode.Replace("'", "''") + "' AND [DISCLOSURE_UNIT_TYPE] = 'C'");
								if (rows.Length == 1)
								{
									SetDisclosureUnitType("C");
								}
								else
								{
									rows = SessionLevelPageAccessPermissionTable.Select("[PAGE_CODE] = '" + PageID.Replace("'", "''") + "' AND [ASPX_FILE_CODE] = '" + ASPXFileCode.Replace("'", "''") + "' AND [DISCLOSURE_UNIT_TYPE] = 'D'");
									if (rows.Length == 1)
									{
										SetDisclosureUnitType("D");
									}
									else
									{
										TransferErrorPage(AllegroMessage.CM_AC_S20005);
									}
								}
// 管理番号K26508 From
								rows = SessionLevelPageAccessPermissionTable.Select("[PAGE_CODE] = '" + PageID.Replace("'", "''") + "' AND [ASPX_FILE_CODE] = '" + ASPXFileCode.Replace("'", "''") + "' AND [AUTHORITY_SETTING_TYPE] = 'U'");
								if (rows.Length == 1)
								{
									SetAuthoritySettingType("U");
								}
								else
								{
									rows = SessionLevelPageAccessPermissionTable.Select("[PAGE_CODE] = '" + PageID.Replace("'", "''") + "' AND [ASPX_FILE_CODE] = '" + ASPXFileCode.Replace("'", "''") + "' AND [AUTHORITY_SETTING_TYPE] = 'V'");
									if (rows.Length == 1)
									{
										SetAuthoritySettingType("V");
									}
									else
									{
										TransferErrorPage(AllegroMessage.CM_AC_S20005);
									}
								}
// 管理番号K26508 To
							}
						}
					}
					//「自社レベルのページ接続許諾情報」で一時的な使用不能状態をチェックする。
					DataRow[] rows2 = MyCompLevelPageAccessPermissionTable.Select("[PAGE_CODE] = '" + PageID.Replace("'", "''") + "' AND [USE_ALLOW_FLG] = '1'");
					if (rows2.Length == 0)
					{
						TransferErrorPage(AllegroMessage.CM_AC_S20006);
					}
				}
			}

// 管理番号 P19346 From
			//初期画面起動時
			if( !IsPostBack )
			{
				//リファラーが「メインメニュー」または「ECメニュー」の場合、ViewStateの代替Session変数を全て削除します。
				string myReferrerASPXFileCode = ReferrerASPXFileCode;
				if( ( myReferrerASPXFileCode == ASPX_OF_MENU ) || ( myReferrerASPXFileCode == ASPX_OF_ECMENU ) )
				{
					Session.Remove(SESSION_NAME_ALTERNATE_TO_VIEWSTATE);
				}
				//絶対除外画面でない場合
				if( !IsCompleteExclusionPage( ASPXFileCode ) )
				{
					//初期起動時はアプリケーション変数から自画面のViewState/Session入替え可否情報を取得し退避
					string myWhereString = "[ASPX_FILE_CODE] = '" + ASPXFileCode.Replace("'", "''") + "'";
					DataRow[] rows = MyCompLevelASPXFileAccessPermissionTable.Select( myWhereString );
					//検索データ1件の場合のみ正常
					if (rows.Length == 1)
					{
						//入替え可否情報がnullでない場合
						if( rows[0]["SYSTEM_RESERVE2"] != null )
						{
							//入替え可否情報が'1'の場合
							if( rows[0]["SYSTEM_RESERVE2"].ToString() == "1" )
							{
								//入替え可の場合「true」をセット
								isUseSessionAlternateToViewState = true;
																
								//セッション変数がない場合
								if( Session[SESSION_NAME_ALTERNATE_TO_VIEWSTATE] == null )
								{
									//セッション変数作成
									Session.Add(SESSION_NAME_ALTERNATE_TO_VIEWSTATE, null);
									//ViewState/Session入替え情報を格納するハッシュテーブルを作成する
									AlternateToViewState = new Hashtable();
								}
								else
								{
									//ViewState/Session入替え情報をセッション変数より取得する
									AlternateToViewState = (Hashtable)Session[SESSION_NAME_ALTERNATE_TO_VIEWSTATE];
								}
								//ViewState/Session入替え情報インスタンス作成
								AlternateInfo ai = new AlternateInfo();
								//自画面IDをキーにViewState/Session入替え情報を格納する
								if (!AlternateToViewState.ContainsKey(ASPXFileCode))
								{
									AlternateToViewState.Add(ASPXFileCode, ai);
								}
								ai.IsUseSession = isUseSessionAlternateToViewState;
								AlternateToViewState[ASPXFileCode] = ai;
							}
						}
					}
					else
					{
						TransferErrorPage(AllegroMessage.CM_AC_S20009);
					}
				}	
			}
			//ポストバック時
			else
			{
			}
// 管理番号 P19346 To
// 管理番号 B21419 From
//			base.OnLoad(e);
			if(!isViewStateError)
			{
				base.OnLoad(e);
			}
			else
			{
				//Do Nothing
				isViewStateError = false;
			}
// 管理番号 B21419 To

// 管理番号B27167 From
// 管理番号K27443 From
//			var whiteList = new[] { ASPX_OF_LOGIN, ASPX_OF_LOGIN_FOR_DEMO, ASPX_OF_ECLOGIN };
			var whiteList = new[] { ASPX_OF_LOGIN, ASPX_OF_LOGIN_FOR_DEMO, ASPX_OF_ECLOGIN, ASPX_OF_TEMP_PASS_CHECK };
// 管理番号K27443 To
			if (!whiteList.Contains(ASPXFileCode))
			{
// 管理番号B27183 From
//				HttpCookie secureToken = Request.Cookies["secureToken"];
//
//				if ((secureToken == null) || (Request.Cookies["secureToken"].Value != ((string)Session["SecureToken"])))

				string sessionName = "SecureToken" + Request.ApplicationPath;
				string cookieName = "secureToken" + Request.ApplicationPath;

				HttpCookie secureToken = Request.Cookies[cookieName];
				if ((secureToken == null) || (Request.Cookies[cookieName].Value != ((string)Session[sessionName])))
// 管理番号B27183 To
				{
					TransferErrorPage(AllegroMessage.CM_AC_S20005);
				}
			}
// 管理番号B27167 To
		}

		/// <summary>
		/// <see cref="Control.PreRender"/>イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnPreRender(EventArgs e)
		{
// 管理番号K26528 From
//// 管理番号K22156 From
//            if (!Page.ClientScript.IsClientScriptBlockRegistered("AllegroControl"))
//            {
//                Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "AllegroControl", AllegroControl.OnKeyDownScript);
//            }
//// 管理番号K22156 To

			// クライアントデバッグモードフラグの制御
			string clientDebugMode = Configuration.DebugSettings.Get("ClientDebugMode", false).ToString().ToLower();
			ImmediateStartupScript.RegisterScript(this.GetType(), "writeClientDebugMode", "__ClientDebugMode = " + clientDebugMode + ";");

			// GetPostBackEventReferenceを実行することでHTMLに__doPostBackの出力を強制する
			ClientScript.GetPostBackEventReference(this, string.Empty);

			// ポストバック時の処理を上書きする
			ImmediateStartupScript.RegisterScript(this.GetType(), "initGranditSubmit", "initGranditSubmit(__doPostBack);");

			// 画面トークン登録
// 管理番号K27443 From
//			var whiteList = new[] { ASPX_OF_LOGIN, ASPX_OF_LOGIN_FOR_DEMO, ASPX_OF_ECLOGIN };
			var whiteList = new[] { ASPX_OF_LOGIN, ASPX_OF_LOGIN_FOR_DEMO, ASPX_OF_ECLOGIN, ASPX_OF_TEMP_PASS_CHECK };
// 管理番号K27443 To
			if (!whiteList.Contains(ASPXFileCode))
			{
				// 画面トークンを登録する
				TokenManager.RegisterToken(this);
			}
// 管理番号K26528 To
			if (registeredFocusAtPreRender)
			{
				isFocusControlRegistered = false;
			}
// 管理番号 B22218 From
			if(!isViewStateError)
			{
// 管理番号 B22218 To
				base.OnPreRender(e);
// 管理番号K26528 From
				// 画面が閉じられようとしている場合はフォーカス制御は行わない
				if (!PageStartupScript.IsScriptRegistered("CloseWindow"))
				{
// 管理番号K26528 To
					if (isFocusControlRegistered)
					{
// 管理番号 K25482 From
						if (autoFocusControlMode)
						{
							StringBuilder script = new StringBuilder();
// 管理番号K26528 From
//							script.Append("<script type=\"text/javascript\">\r\n");
//							script.Append("	var ctr = document.getElementById(\"" + activeControlID + "\");\r\n");
//							script.Append("	if (!ctr.disabled) {\r\n");
//							script.Append("		window.focus();\r\n");
//							script.Append("		ctr.focus();\r\n");
//							script.Append("		if ((ctr.tagName == \"INPUT\" && ctr.type == \"text\")  || ctr.tagName == \"TEXTAREA\") {\r\n");
//							script.Append("			ctr.select();\r\n");
//							script.Append("		}\r\n");
//							script.Append("		ctr.focus();\r\n");
//							script.Append("	} else {\r\n");
//							script.Append("		focusNextElement(ctr.id);\r\n");
//							script.Append("	}\r\n");
//							script.Append("</script>");
//							ClientScript.RegisterStartupScript(this.GetType(), "__FocusControl", script.ToString());
							script.AppendLine("window.focus();");
							script.AppendLine("focusNextElement('" + activeControlID + "');");
							ImmediateStartupScript.RegisterScript(this.GetType(), "__FocusControl", script.ToString());
// 管理番号K26528 To
						}
						else
						{
// 管理番号 K25482 To
// 管理番号K26528 From
//							StringBuilder script = new StringBuilder("<script type=\"text/javascript\">\r\n\twindow.focus();\r\n\tvar ctr = document.getElementById(\"", 128);
							StringBuilder script = new StringBuilder();
							script.AppendLine("window.focus();");
							script.Append("\tvar ctr = document.getElementById(\"");
// 管理番号K26528 To
							script.Append(activeControlID);
// 管理番号K26528 From
//							script.Append("\");\r\n\tctr.focus();\r\n\tif ((ctr.tagName == \"INPUT\" && ctr.type == \"text\")  || ctr.tagName == \"TEXTAREA\") {\r\n\t\tctr.select();\r\n\t}\r\n\tctr.focus();\r\n</script>");
//							ClientScript.RegisterStartupScript(this.GetType(), "__FocusControl", script.ToString());
							script.AppendLine("\");");
							script.AppendLine("\tctr.focus();");
							script.AppendLine("\tif ((ctr.tagName == \"INPUT\" && ctr.type == \"text\")  || ctr.tagName == \"TEXTAREA\") {");
							script.AppendLine("\t\tctr.select();");
							script.AppendLine("\t}");
							script.AppendLine("\tctr.focus();");
							ImmediateStartupScript.RegisterScript(this.GetType(), "__FocusControl", script.ToString());
// 管理番号K26528 To
// 管理番号 K25482 From
						}
// 管理番号 K25482 To
					}
// 管理番号 K25482 From
					else if (autoFocusControlMode && activeControlID == null)
					{
// 管理番号K26528 From
//						string eventTargetId = changeIDSeparator(Request.Form["__EVENTTARGET"]);
						var eventTargetId = Request.Form["__EVENTTARGET"];
// 管理番号K26528 To
						if (eventTargetId != null && eventTargetId != string.Empty)
						{
							Control eventTargetControl = FindControl(eventTargetId);
							if (eventTargetControl is IAllegroContorl)
							{
								activeControlID = ((IAllegroContorl)eventTargetControl).InnerNextControlID;
								if (activeControlID != null && activeControlID != string.Empty)
								{
									StringBuilder script = new StringBuilder();
// 管理番号K26528 From
//									script.Append("<script type=\"text/javascript\">\r\n");
// 管理番号K26528 To
									script.Append("	window.focus();\r\n");
									script.Append("	focusNextElement(\"").Append(activeControlID).Append("\");\r\n");
// 管理番号K26528 From
//									script.Append("</script>");
//									ClientScript.RegisterStartupScript(this.GetType(), "__FocusControl", script.ToString());
									ImmediateStartupScript.RegisterScript(this.GetType(), "__FocusControl", script.ToString());
// 管理番号K26528 To
								}
							}
						}
					}
// 管理番号 K25482 To
// 管理番号K26528 From
				}
// 管理番号K26528 To

				foreach (Control ctl in Controls)
				{
					if (ctl is HtmlForm)
					{
						((HtmlForm) ctl).Attributes.Add("onreset", "return false;");
					}
				}
				ClientScript.RegisterHiddenField(AllegroControl.LastControlHiddenName, string.Empty);
// 管理番号K27445 From
				ClientScript.RegisterHiddenField(AllegroControl.FunctionKeyControlHiddenName, string.Empty);
				ClientScript.RegisterHiddenField(AllegroControl.FunctionKeyControlHiddenValue, string.Empty);
// 管理番号K27445 To
				ClientScript.RegisterHiddenField("__PageID", PageID);
// 管理番号K26508 From
				ClientScript.RegisterHiddenField("__AuthoritySettingType", AuthoritySettingType);
// 管理番号K26508 To
// 管理番号 B22218 From
			}
			else
			{
				//Do Nothing
				isViewStateError = false;
			}
// 管理番号 B22218 To

// 管理番号K20128 From
			try
			{
// 管理番号K27445 From
//// 管理番号K27443 From
////// 管理番号 K24546 From
//////				if ((ASPXFileCode != "CM_AC_03_S01") && (ASPXFileCode != "SC_EC_01_S01") && (ASPXFileCode != "CM_MS_12_S09"))
////				if ((ASPXFileCode != "CM_AC_03_S01") && (ASPXFileCode != "SC_EC_01_S01") && (ASPXFileCode != "CM_MS_12_S09") && (ASPXFileCode != ASPX_OF_LOGIN_FOR_DEMO))
////// 管理番号 K24546 To
//				if ((ASPXFileCode != "CM_AC_03_S01") && (ASPXFileCode != "SC_EC_01_S01") && (ASPXFileCode != "CM_MS_12_S09") && (ASPXFileCode != ASPX_OF_LOGIN_FOR_DEMO) && (ASPXFileCode != ASPX_OF_TEMP_PASS_CHECK))
//// 管理番号K27443 To
				if ((ASPXFileCode != "CM_AC_03_S01") && (ASPXFileCode != "SC_EC_01_S01") && (ASPXFileCode != "CM_MS_12_S09") && (ASPXFileCode != "CM_MS_12_S51")
					&& (ASPXFileCode != ASPX_OF_LOGIN_FOR_DEMO) && (ASPXFileCode != ASPX_OF_TEMP_PASS_CHECK))
// 管理番号K27445 To
				{
					if (IsProgramLogWriteToDatabase)
					{
						AllegroLogProgram.Write(CommonData, Request, this.LoginAccount, IsPostLogWriteToDatabase, IsGetLogWriteToDatabase);
					}
				}
			}
			catch
			{
			}
// 管理番号K20128 To
		}

// 管理番号K26528 From
		/// <summary>
		/// <see cref="Page.PreRenderComplete"/>イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnPreRenderComplete(EventArgs e)
		{
			// 最後のスタートアップスクリプトでユーザによる操作を許可する
			PageStartupScript.RegisterScript(this.GetType(), "enableUserOperation", "enableUserOperation();");

			// スタートアップスクリプトの登録
			RegisterStartupScript();
			base.OnPreRenderComplete(e);
		}
// 管理番号K26528 To

// Plat015 From
		/// <summary>
		/// 保存されているビューステート情報を<see cref="Page"/>オブジェクトに読み込みます。
		/// </summary>
		/// <returns>
		/// 保存されたビューステート。
		/// </returns>
		protected override object LoadPageStateFromPersistenceMedium()
		{
			try
			{			
// 管理番号 P19346 From
				//セッション変数が存在する場合、ViewState/Session入替え情報を取得する
				if (Session[SESSION_NAME_ALTERNATE_TO_VIEWSTATE] != null)
				{
					//ViewState/Session入替え情報をセッション変数より取得する
					AlternateToViewState = (Hashtable)Session[SESSION_NAME_ALTERNATE_TO_VIEWSTATE];
					//自画面のViewState/Session入替え情報が存在する場合、ViewState/Session入替え可か否かを取得する
					if (AlternateToViewState.ContainsKey(ASPXFileCode))
					{
						isUseSessionAlternateToViewState = (bool)((AlternateInfo)AlternateToViewState[ASPXFileCode]).IsUseSession;
					}
				}

				//自画面がViewState/Session入替え可の場合
				if ( isUseSessionAlternateToViewState )
				{
					//セッションに保存した情報を返す
					return (object)((AlternateInfo)AlternateToViewState[ASPXFileCode]).ViewState;
				}
				else
				{
					//通常通りビューステート情報を読込む
					return base.LoadPageStateFromPersistenceMedium();
				}
				//return base.LoadPageStateFromPersistenceMedium();
// 管理番号 P19346 To			
			}
			catch( Exception ex )
			{	
				#region 例外をエラーとして取り扱うか否かの判断処理
			
				//例外メッセージを退避(100文字以内に切り出す)
				string exMsg = string.Empty;
				if ( ex.Message.Length >= 100 )
				{
					exMsg = ex.Message.Substring( 0, 100 );
				}
				else
				{
					exMsg = ex.Message;
				}

// 管理番号 B23537 From
				string writeMsg = string.Empty;
// 管理番号 B23537 To
				//メッセージ内をキーワード検索
				//キーワードが存在する場合 エラー以外のものとして処理を行う
// 管理番号 B22218 From
//				if ( ( exMsg.IndexOf( ENGINVALIDVIEWSTATEMSG ) >= 0 ) ||
//				     ( exMsg.IndexOf( ENGINVALIDVIEWSTATEMSG2) >= 0 ) ||
//					 ( exMsg.IndexOf( JPNINVALIDVIEWSTATEMSG ) >= 0 )
//				   )
// 管理番号 B23537 From
//				if ( exMsg.IndexOf( ENGINVALIDVIEWSTATEMSG ) >= 0 )
				if (( exMsg.IndexOf( ENGINVALIDVIEWSTATEMSG ) >= 0 ) ||
					( exMsg.IndexOf( JPNINVALIDVIEWSTATEMSG2) >= 0 )
				   )
// 管理番号 B23537 To
// 管理番号 B22218 To
				{					
					try
					{
// 管理番号 B23537 From
//// 管理番号 B22218 From
////					AllegroLog.Write(CommonData, ExceptionLevel.Info, "GRANDIT/Information <Invalid_Viewstate>");
//						AllegroLog.Write(CommonData, ExceptionLevel.Info, "GRANDIT/Information <Invalid_Viewstate_Client_Disconnected>");
//// 管理番号 B22218 To
						// ログに書き込むメッセージを設定する
						if (exMsg.IndexOf( ENGINVALIDVIEWSTATEMSG ) >= 0)
						{
							writeMsg = ENGINVALIDVIEWSTATEMSG;
						}
						else if (exMsg.IndexOf( JPNINVALIDVIEWSTATEMSG2) >= 0)
						{
							writeMsg = JPNINVALIDVIEWSTATEMSG2;
						}

						AllegroLog.Write(CommonData, ExceptionLevel.Info, "GRANDIT/Information <" + writeMsg + ">");
// 管理番号 B23537 To
// 管理番号 B21419 From
						isViewStateError = true;
// 管理番号 B21419 To
					}
					catch
					{
					}
				}
// 管理番号 B22218 From
				else if	(	( exMsg.IndexOf( ENGINVALIDVIEWSTATEMSG2) >= 0 ) ||
							( exMsg.IndexOf( ENGINVALIDVIEWSTATEMSG3) >= 0 ) ||
							( exMsg.IndexOf( JPNINVALIDVIEWSTATEMSG ) >= 0 )
						)
				{
					try
					{
						AllegroLog.Write(CommonData, ExceptionLevel.Error, "GRANDIT/Error <Invalid_Viewstate>");
					}
					catch
					{
					}
				}
// 管理番号 B22218 To
				//キーワードが存在しない場合例外をスロー(エラーとして扱うために、上位レベルへ処理を託す)
				else
				{
					throw;
				}
				return null;
				
				#endregion				
			}
		}
// Plat015 To
// 管理番号 P19346 From
		/// <summary>
		/// ページのビューステート情報とコントロールの状態情報を保存します。
		/// </summary>
		/// <param name="viewState">
		/// ビューステート
		/// </param>
		protected override void SavePageStateToPersistenceMedium(object viewState)
		{
			//自画面がViewState/Session入替え可の場合	
			if ( isUseSessionAlternateToViewState )
			{
				//ビューステート情報をセッションに保存
				AlternateInfo ai = (AlternateInfo)AlternateToViewState[ASPXFileCode];
				ai.ViewState = viewState;
				AlternateToViewState[ASPXFileCode] = ai;
				Session[SESSION_NAME_ALTERNATE_TO_VIEWSTATE] = AlternateToViewState;
			}
			//自画面がViewState/Session入替えなしの場合	
			else
			{
				//通常通りビューステートに保存
				base.SavePageStateToPersistenceMedium(viewState);
			}
		}
// 管理番号 P19346 To
// 管理番号 K24546 From
		/// <summary>
		/// ページの現在のスレッドの<see cref="Page.Culture"/>と"<see cref="Page.UICulture"/>を設定します。
		/// </summary>
		protected override void InitializeCulture()
		{
			if (Session["LanguageSetting"] != null)
			{
				String selectedLanguage = (string)Session["LanguageSetting"];

				this.Culture = selectedLanguage;
				this.UICulture = selectedLanguage;

				MultiLanguage.SetCurrentThreadCulture(selectedLanguage);

				ClientScript.RegisterHiddenField("__SelectLanguage", selectedLanguage);
			}
			base.InitializeCulture();
		}
// 管理番号 K24546 To
		#endregion
	}

	/// <summary>
	/// エラー処理のためのメソッドを表します。
	/// </summary>
	public delegate void ErrorDelegate();
}
