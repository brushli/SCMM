// Product     : Allegro
// Unit        : SC
// Module      : MM
// Function    : 05
// File Name   : SC_MM_05_S01.aspx.cs
// 機能名      : SC_MM_05_S01 仕入一覧
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 管理番号 B12657 2004/09/13 検索日付From-Toの初期値設定
// 管理番号 B13878 2005/02/03 売上・仕入時の単価未決対応
// 管理番号 B13877 2005/02/12 プロジェクト別在庫管理対応
// 管理番号 B13879 2005/02/16 管理帳票の追加
// 1.3.2 2005/03/31
// 管理番号 B15710 2005/08/03 レスポンス是正対応
// 管理番号 K16187 2005/09/06 支払機能拡張対応
// 1.4.0 2005/10/31
// 管理番号 K16764 2006/01/11 支払保留伝票の絞込機能追加
// 1.5.0 2006/03/31
// 管理番号 B18736 2007/01/15 画面入力桁数統一対応
// 管理番号 B18049 2007/01/15 帳票印刷時のレポートマスタメンテナンス参照設定の不具合対応
// 1.5.1 2007/06/30
// 管理番号 K20685 2007/07/25 ワークフロー取消機能改善
// 1.5.2 2007/10/31
// 管理番号 B20818 2007/12/17 楽観ロック対応
// 管理番号 B20935 2007/12/20 削除エラーが発生した場合、ロックテーブルで当該伝票のロックが開放されるよう修正
// 管理番号 B21232 2008/01/23 支払保留の条件に「全て」を指定し検索を行うと支払保留のデータが抽出対象にならない不具合対応
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 管理番号 K22205 2008/11/06 WF申請者以外の修正対応
// 1.6.0 2009/09/30
// 管理番号 B22516 2009/08/10 相殺による消込が行なわれているにも関わらず、伝票削除が行えてしまう不具合を修正
// 管理番号 K24268 2012/01/06 一覧形式帳票対応
// 管理番号 K24267 2012/02/04 合計行追加対応
// 管理番号 B24161 2012/05/07 仕入一覧の検索結果の並び順が履歴伝票表示するで発生伝票番号順にならない
// 2.0.0 2012/10/31
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25679 2015/10/26 グループ対応
// 管理番号 K25680 2015/10/26 外部連携
// 2.3.0 2016/06/30
// 管理番号B25370 2016/07/20 後続伝票が存在する場合は削除ボタンを押下不可とする修正
// 管理番号K26528 2017/02/13 UI見直し
// 管理番号K26508 2017/08/01 アクセス権限の改善
// 3.0.0 2018/04/30
// 管理番号B26649 2018/05/07 仮単価を使用しない場合にフォーカス移動が正しく行われない不具合対応
// 管理番号K27064 2019/08/06 請求／支払締後の伝票修正許可
// 管理番号K27058 2019/10/29 汎用区分追加
// 管理番号K27057 2019/12/02 汎用項目追加
// 3.1.0 2020/06/30
// 管理番号K27154 2020/07/16 収益認識対応
// 管理番号B23909 2022/09/06 検索結果の件数が消える不具合を修正
// 3.2.0 2023/03/31

using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Infocom.Allegro;
// 管理番号K26528 From
using Infocom.Allegro.CM;
// 管理番号K26528 To
using Infocom.Allegro.CM.MS;
using Infocom.Allegro.SC.MS;
using Infocom.Allegro.Web.WebControls;
using System.Text;

namespace Infocom.Allegro.SC
{
	public class SC_MM_05_S01 : Infocom.Allegro.Web.InputPageBase
	{
		#region Controls
		protected Infocom.Allegro.Web.WebControls.Header Header1;
		protected System.Web.UI.WebControls.Label MessageLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel FindRecordsLabel;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox DeptCodeText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox EmpCodeText;
// 管理番号 K22205 From
        protected Infocom.Allegro.Web.WebControls.CustomTextBox InputEmpCodeText;
        protected Infocom.Allegro.Web.WebControls.EncodeLabel InputEmpNameLabel;
// 管理番号 K22205 To
		protected Infocom.Allegro.Web.WebControls.CustomTextBox SuplCodeText;
		protected Infocom.Allegro.Web.WebControls.StyledButton CloseButton2;
		protected Infocom.Allegro.Web.WebControls.StyledButton NewButton2;
// 管理番号K26528 From
//		protected System.Web.UI.WebControls.Literal ShowsPrintDialogLabel;
		protected System.Web.UI.HtmlControls.HtmlInputHidden clickHidden;
// 管理番号K26528 To
		protected System.Web.UI.HtmlControls.HtmlInputHidden deleteDate;
		protected System.Web.UI.HtmlControls.HtmlInputHidden postCountHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden searchRetryHidden;
// 管理番号K27057 From
		protected System.Web.UI.HtmlControls.HtmlGenericControl HeadCustomItemPanelRow;
		protected System.Web.UI.HtmlControls.HtmlGenericControl DtilCustomItemPanelRow;
		protected Infocom.Allegro.Web.WebControls.CustomItemPanel HeadCustomItemPanel;
		protected Infocom.Allegro.Web.WebControls.CustomItemPanel DtilCustomItemPanel;
// 管理番号K27057 To
		#endregion

		#region Private Members
// 管理番号K26528 From
//		private	int MAX_DATA_CNT = 500; // 表示Alert件数
		private	int MAX_DATA_CNT = GetWarningRowCount(500); // 表示Alert件数
// 管理番号K26528 To
		private IF_SC_MM_05_S01_SearchCondition searchCondition = new IF_SC_MM_05_S01_SearchCondition();
		private string sort;
		private int viewnum;
		protected Infocom.Allegro.Web.WebControls.CustomRadioButtonList Customradiobuttonlist1;
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList ApprovalStatusTypeDrop;
		protected Infocom.Allegro.Web.WebControls.DateBox PuDateFromText;
		protected Infocom.Allegro.Web.WebControls.DateBox PuDateToText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox ProjCodeText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox PuNoFromText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox PuNoToText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox SuplBillSlipNoText;
		protected Infocom.Allegro.Web.WebControls.DateBox PoDateFromText;
		protected Infocom.Allegro.Web.WebControls.DateBox PoDateToText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox PoNoFromText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox PoNoToText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox ProdCodeText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel ProdNameLabel;
		protected Infocom.Allegro.Web.WebControls.StyledButton CloseButton;
		protected Infocom.Allegro.Web.WebControls.StyledButton PuListButton;
		protected Infocom.Allegro.Web.WebControls.StyledButton NewButton;
		protected Infocom.Allegro.Web.WebControls.StyledButton ResetButton;
		protected Infocom.Allegro.Web.WebControls.StyledButton SearchButton;
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList DisplayRecordsDrop;
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList PuModeTypeDrop;
// 管理番号K27058 From
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList BookBasisTypeDrop;
// 管理番号K27058 To
		protected Infocom.Allegro.Web.WebControls.CustomRadioButtonList RedSlipRadio;
// 管理番号 B13878 From
		protected Infocom.Allegro.Web.WebControls.EncodeLabel PriceUndecidedTitleLabel;
		protected Infocom.Allegro.Web.WebControls.CustomRadioButtonList PriceUndecidedRadio;
// 管理番号 B13878 To
// 管理番号 K16764 From
		protected Infocom.Allegro.Web.WebControls.CustomRadioButtonList HoldFlgRadio;
// 管理番号 K16764 To
		protected Infocom.Allegro.Web.WebControls.EncodeLabel SuplShortNameLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel DeptShortNameLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel EmpShortNameLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel ProjShortNameLabel;
		protected Infocom.Allegro.Web.WebControls.CustomDataGrid DataGrid1;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel ProjTitleLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel ApprovalStatusTypeTitleLabel;
		protected Infocom.Allegro.Web.WebControls.StyledButton PuDetailListButton;
		protected Infocom.Allegro.Web.WebControls.CustomCheckBox SubDeptSearchCheckBox;
		private bool useBind = false;
// 管理番号 K24268 From
		protected Infocom.Allegro.Web.WebControls.StyledButton PuListOutputButton;
// 管理番号 K24268 To
// 管理番号 K25679 From
		protected Infocom.Allegro.Web.WebControls.CustomTextBox SuplSlipNo;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel SuplSlipNoLabel;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox PoAdminNo;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel DetailPoAdminNo;
// 管理番号 K25679 To
// 管理番号 K25680 From
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList OriginTypeDrop;
// 管理番号 K25680 To
// 管理番号K27154 From
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList DealTypeDrop;
// 管理番号K27154 To
// 管理番号 K24267 From
		private string sumGrandTtl = string.Empty;
		private string sumKeyGrandTtl = string.Empty;
// 管理番号 K24267 To
// 管理番号 K25680 From
		private const string SLIP_TYPE_CODE = "SM3"; //伝票区分略名取得のための定数
// 管理番号 K25680 To
		#endregion

		#region Page Initialize Eventes
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				setDefalut();
// 管理番号K27057 From
				HeadCustomItemPanelRow.DataBind();
				DtilCustomItemPanelRow.DataBind();
// 管理番号K27057 To
			}
			else
			{
				searchCondition = (IF_SC_MM_05_S01_SearchCondition) ViewState["searchCondition"];
				viewnum = (int)ViewState["ViewNum"];
				sort = (string)ViewState["Sort"];
			}
			MessageLabel.Text      = string.Empty;
// 管理番号K26528 From
//			ShowsPrintDialogLabel.Text=Infocom.Allegro.CM.MS.Report.ShowsPrintDialog(this.CommonData,"SC_MM_05_R03",Infocom.Allegro.Report.ScreenType.ReportPrint).ToString();
// 管理番号K26528 To
		}

		private void Page_PreRender(object sender, System.EventArgs e)
		{
			if (useBind)
			{
				DataGrid1.DataBind();
			}
// 管理番号K26508 From
			// 参照権限時のヘッダ、フッタコントロール制御
			viewAuthorityControls();
// 管理番号K26508 To
			ViewState["searchCondition"] = searchCondition;
			ViewState["ViewNum"] = viewnum;
			ViewState["Sort"] = sort;
			ClientScript.RegisterHiddenField("__TodayDate", DateTime.Today.ToString("yyyy/MM/dd"));
			ClientScript.RegisterHiddenField("__DisclosureUnitType", this.DisclosureUnitType);
			ClientScript.RegisterHiddenField("__LoginDeptCode", this.UserDeptCode);
			searchCondition.ClearErrors();

			FocusControl("PuDateFromText");
		}

// 管理番号K27057 From
		protected int GetHeadCustomControlCount()
		{
			return HeadCustomItemPanel.GetList().Count;
		}

		protected int GetDtilCustomControlCount()
		{
			return DtilCustomItemPanel.GetList().Count;
		}
// 管理番号K27057 To
		#endregion

		#region Web フォーム デザイナで生成されたコード
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: この呼び出しは、ASP.NET Web フォーム デザイナで必要。
			//
			InitializeComponent();
			base.OnInit(e);
		}

// 管理番号K27057 From
		protected override void OnPreInit(EventArgs e)
		{
			// CustomItemPanelは略名取得のイベントハンドラを設定するためにOnInitで部品を構築する。
			// 個別機能のOnPreInit→CustomItemPanelのOnInit→個別機能のOnInitの順で実行されるため
			// 汎用項目、汎用項目機能別設定、汎用項目値設定の情報をCustomItemPanelに渡すタイミングを、OnPreInitにする必要がある。
			// 各情報の取得、CustomItemPanelはCustomItemが行う。
			CustomItem.InitCustomItem(CommonData, ProjectCodeLength, CompanyCodeLength, HeadCustomItemPanel, FocusControl);
			CustomItem.InitCustomItem(CommonData, ProjectCodeLength, CompanyCodeLength, DtilCustomItemPanel, FocusControl);
		}
// 管理番号K27057 To

		/// <summary>
		/// デザイナ サポートに必要なメソッド。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.SuplCodeText.TextChanged += new System.EventHandler(this.SuplCodeText_TextChanged);
			this.DeptCodeText.TextChanged += new System.EventHandler(this.DeptCodeText_TextChanged);
			this.EmpCodeText.TextChanged += new System.EventHandler(this.EmpCodeText_TextChanged);
			this.ProjCodeText.TextChanged += new System.EventHandler(this.ProjCodeText_TextChanged);
			this.ProdCodeText.TextChanged += new System.EventHandler(this.ProdCodeText_TextChanged);
			this.SearchButton.Click += this.SearchButton_Click;
			this.ResetButton.Click += this.ResetButton_Click;
			this.NewButton.Click += this.NewButton_Click;
			this.PuListButton.Click += this.PuListButton_Click;
			this.PuDetailListButton.Click += this.PuDetailListButton_Click;
			this.CloseButton.Click += this.CloseButton_Click;
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.DataGrid1.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(this.DataGrid1_SortCommand);
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid1_PageIndexChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.NewButton2.Click += this.NewButton_Click;
			this.CloseButton2.Click += this.CloseButton_Click;
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new System.EventHandler(this.Page_PreRender);
// 管理番号 K22205 From
            this.InputEmpCodeText.TextChanged += new System.EventHandler(this.InputEmpCodeText_TextChanged);
// 管理番号 K22205 To
// 管理番号 K24268 From
			this.PuListOutputButton.Click += this.PuListOutputButton_Click;
// 管理番号 K24268 To
// 管理番号 K24267 From
			this.DataGrid1.ItemCreated += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemCreated);
// 管理番号 K24267 To

		}
		#endregion

		#region Search & Disp
		private DataTable GetDataSource()
		{
			return BL_SC_MM_05_S01.Select(searchCondition, CommonData, true);
		}

		private void setDataGridProperty(DataTable dt)
		{
			StringBuilder sb = new StringBuilder();
			DataView dv = new DataView(dt);
			ViewState["Sort"] = dv.Sort = sort;
			DataGrid1.DataSource = dv;

			DataGrid1.PageSize = viewnum;
			if (dt.Rows.Count < (DataGrid1.PageSize * DataGrid1.CurrentPageIndex))
			{
				DataGrid1.CurrentPageIndex = (int) (dt.Rows.Count / DataGrid1.PageSize);
			}

			if ((dt.Rows.Count == (DataGrid1.PageSize * DataGrid1.CurrentPageIndex)) && (dt.Rows.Count != 0))
			{
				DataGrid1.CurrentPageIndex = DataGrid1.CurrentPageIndex - 1;
			}

			if ((dt.Rows.Count != 0) && (!searchCondition.HasErrors))
			{
				DataGrid1.Visible = true;
				useBind = true;
			}
			else
			{
				DataGrid1.Visible = false;
			}

			if (dt.Rows.Count != 0)
			{
// 				sb.Append(dt.Rows.Count.ToString()).Append("件"); //K24546
				sb.Append(dt.Rows.Count.ToString()).Append(MultiLanguage.Get("SC_CS000535"));
				FindRecordsLabel.Text = sb.ToString();
			}
			else
			{
				FindRecordsLabel.Text = AllegroMessage.S10002;
			}
// 管理番号 K24267 From
			getTotalTtl(dt);
// 管理番号 K24267 To
		}

		private void setMessageLabel(string errorMassage)
		{
// 管理番号B23909 From
//			FindRecordsLabel.Text  = string.Empty;
// 管理番号B23909 To
			MessageLabel.Text      = errorMassage;
		}

		private void setDefalut()
		{
			DisplayRecordsDrop.SelectedIndex = 0;

			//検索条件の初期化
			resetSearchCondition();

			//セッション情報取得（検索条件初期値）
			DeptCodeText.Text       = this.UserDeptCode;
			DeptShortNameLabel.Text = this.UserDeptName;
			EmpCodeText.Text        = this.UserCode;
			EmpShortNameLabel.Text  = this.UserName;
// 管理番号 K22205 From
            InputEmpCodeText.Text = this.UserCode;
            InputEmpNameLabel.Text = this.UserName;
// 管理番号 K22205 To
			searchRetryHidden.Value	= string.Empty;

			//ドロップダウンリスト作成
			setApprovalStatusTypeDrop();
			setPuModeTypeDrop();
// 管理番号K27058 From
			setBookBasisTypeDrop();
// 管理番号K27058 To
// 管理番号 K25680 From
			setOriginTypeDrop();
// 管理番号 K25680 To
// 管理番号K27154 From
			setDealTypeDrop(); // 取引区分のドロップダウンリスト設定
// 管理番号K27154 To

			//プロジェクト管理フラグ
			if (!this.ProjImplementFlg)
			{
				this.ProjTitleLabel.Visible = false;
				this.ProjCodeText.Visible = false;
				this.EmpCodeText.NextControlID = this.ProjCodeText.NextControlID;
			}

// 管理番号 K25679 From
			//承認管理フラグ（ワークフロー）
//			if (!Infocom.Allegro.CM.WF.Common.IsApp(CommonData, "SM3"))
			// 仕入伝票とグループ間取引仕入両方においてWF使用しない場合、承認状態ドロップダウンリストを非表示とする。
			if (!Infocom.Allegro.CM.WF.Common.IsApp(CommonData, "SM3") && !Infocom.Allegro.CM.WF.Common.IsApp(CommonData, "CG2"))
// 管理番号 K25679 To
			{
				this.ApprovalStatusTypeTitleLabel.Visible = false;
				this.ApprovalStatusTypeDrop.Visible = false;
				DataGrid1.Columns[0].Visible = false;
// 管理番号K27058 From
//// 管理番号 K25680 From
////// 管理番号 K22205 From
////                this.InputEmpCodeText.NextControlID = this.ApprovalStatusTypeDrop.NextControlID + "_0";
//////				this.PuModeTypeDrop.NextControlID = this.ApprovalStatusTypeDrop.NextControlID;
//				this.OriginTypeDrop.NextControlID = this.ApprovalStatusTypeDrop.NextControlID;
////// 管理番号 K22205 To
//// 管理番号 K25680 To
				HoldFlgRadio.NextControlID = this.ApprovalStatusTypeDrop.NextControlID;
// 管理番号K27058 To
			}

			//公開単位区分
			if (this.DisclosureUnitType == "D")	//部門
			{
				//部門を必須
				this.DeptCodeText.IsRequiredField = true;
			}

			// 管理番号 B12657 From
			DateTime today = DateTime.Today;
			PuDateFromText.Text = today.AddMonths(-2).ToString("yyyy/MM/dd");
			PuDateToText.Text	= today.ToString("yyyy/MM/dd");
			// 管理番号 B12657 To
// 管理番号 B13878 From
			if (this.PriceUndecidedUseFlg)
			{
				//単価未決使用する。
				PriceUndecidedTitleLabel.Visible = true;
// 				PriceUndecidedTitleLabel.Text = "仮単価"; //K24546
				PriceUndecidedTitleLabel.Text = MultiLanguage.Get("SC_CS002994");
				PriceUndecidedRadio.Visible = true;
			}
			else
			{
				PriceUndecidedTitleLabel.Visible = false;
				PriceUndecidedRadio.Visible = false;
// 管理番号K27154 From
//// 管理番号B26649 From
////				RedSlipRadio.NextControlID = PriceUndecidedRadio.NextControlID;
//				PuModeTypeDrop.NextControlID = PriceUndecidedRadio.NextControlID;
//// 管理番号B26649 To
				DealTypeDrop.NextControlID = PriceUndecidedRadio.NextControlID;
// 管理番号K27154 To
			}
// 管理番号 B13878 To
// 管理番号 K25679 From
			//モジュールマスタにてモジュールコード「CMGR：グループ連携」の有効フラグが0:無効の場合は仕入先伝票番号非表示
			if (!Module.CheckModule(CommonData, "CMGR"))
			{
				this.SuplSlipNoLabel.Visible = false;
				this.SuplSlipNo.Visible = false;
				this.SuplCodeText.NextControlID = this.SuplSlipNo.NextControlID;
			}
// 管理番号 K25679 To
		}
		private void setSearchCondition(IF_SC_MM_05_S01_SearchCondition searchConditionTerget)
		{
			searchConditionTerget.PuDateFrom = PuDateFromText.Text;
			searchConditionTerget.PuDateTo   = PuDateToText.Text;
			searchConditionTerget.PuNoFrom   = PuNoFromText.Text.Trim();
			searchConditionTerget.PuNoTo     = PuNoToText.Text.Trim();

			if (SuplCodeText.Text.Length != 0)
			{
				searchConditionTerget.DivideSuplCode(SuplCodeText.Text, CompanyCodeLength);
			}
			else
			{
				searchConditionTerget.SuplCode = searchConditionTerget.SuplSbNo = string.Empty;
			}
			searchConditionTerget.SubDeptSearchFlg = SubDeptSearchCheckBox.Checked == true ? "1" : "0";
			searchConditionTerget.DeptCode   = DeptCodeText.Text.Trim();
			searchConditionTerget.EmpCode    = EmpCodeText.Text.Trim();
// 管理番号 K22205 From
            searchConditionTerget.InputEmpCode = InputEmpCodeText.Text.Trim();
// 管理番号 K22205 To
			if (ProjCodeText.Text.Length != 0)
			{
				searchConditionTerget.DivideProjCode(ProjCodeText.Text, ProjectCodeLength);
			}
			else
			{
				searchConditionTerget.ProjCode = searchConditionTerget.ProjSbNo = string.Empty;
			}
			searchConditionTerget.PoDateFrom = PoDateFromText.Text;
			searchConditionTerget.PoDateTo   = PoDateToText.Text;
			searchConditionTerget.PoNoFrom   = PoNoFromText.Text.Trim();
			searchConditionTerget.PoNoTo     = PoNoToText.Text.Trim();
			searchConditionTerget.SuplBillSlipNo = SuplBillSlipNoText.Text.Trim();
			searchConditionTerget.ProdCode   = ProdCodeText.Text.Trim();
// 管理番号K27058 From
//			searchConditionTerget.PuModeType = PuModeTypeDrop.SelectedValue;
			searchConditionTerget.PuModeType = PuModeTypeDrop.SelectedValue.Substring(0, 1);
			searchConditionTerget.PuModeTypeDtilCode = PuModeTypeDrop.SelectedValue.Substring(1, PuModeTypeDrop.SelectedValue.Length - 1);
			searchConditionTerget.BookBasisType = BookBasisTypeDrop.SelectedValue.Substring(0, 1);
			searchConditionTerget.BookBasisTypeDtilCode = BookBasisTypeDrop.SelectedValue.Substring(1, BookBasisTypeDrop.SelectedValue.Length - 1);
// 管理番号K27058 To
			searchConditionTerget.ApprovalStatusType = ApprovalStatusTypeDrop.SelectedValue;
			searchConditionTerget.RedSlip    = RedSlipRadio.SelectedValue;
// 管理番号 B13877 From
			searchConditionTerget.ProjUseFlg = this.ProjImplementFlg;
// 管理番号 B13877 To
// 管理番号 B13878 From
			if (this.PriceUndecidedUseFlg)
			{
				//単価使用フラグを使用する。
				if (PriceUndecidedRadio.SelectedValue != "0")
				{
					//仮単価が単価未決のときのみ値を代入する。（それ以外はnullのままで抽出させるため）
					searchConditionTerget.PriceUndecided = PriceUndecidedRadio.SelectedValue;
				}
			}
// 管理番号 B13878 To
// 管理番号 B21232 From
//// 管理番号 K16764 From
//			if (HoldFlgRadio.SelectedValue != "0")
//			{
//				//支払保留伝票のときのみ値を代入する。
//				searchConditionTerget.HoldFlg = HoldFlgRadio.SelectedValue;
//			}
//// 管理番号 K16764 To
			//searchConditionには常に支払保留フラグをセットするようにする
			searchConditionTerget.HoldFlg = HoldFlgRadio.SelectedValue;
// 管理番号 B21232 To
// 管理番号 K16187 From
			searchConditionTerget.ApModuleFlg = Module.CheckModule(this.CommonData, "FIAP");
// 管理番号 K16187 To
// 管理番号 K25679 From
			searchConditionTerget.SuplSlipNo = SuplSlipNo.Text.Trim();
			searchConditionTerget.PoAdminNo = PoAdminNo.Text.Trim();
// 管理番号 K25679 To
// 管理番号 K25680 From
			searchConditionTerget.OriginType = OriginTypeDrop.SelectedValue;
// 管理番号 K25680 To
// 管理番号K27154 From
			searchConditionTerget.DealTypeCode = DealTypeDrop.SelectedValue; //取引区分
// 管理番号K27154 To
// 管理番号K27057 From
			CustomItem.SetValidateInfo(CommonData, HeadCustomItemPanel, searchConditionTerget.CustomItemHead);
			CustomItem.SetValidateInfo(CommonData, DtilCustomItemPanel, searchConditionTerget.CustomItemDtil);
			searchConditionTerget.SetCustomItemValidator(searchConditionTerget.CustomItemHead);
			searchConditionTerget.SetCustomItemValidator(searchConditionTerget.CustomItemDtil);
			CustomItem.SetIF(CommonData, HeadCustomItemPanel, searchConditionTerget.CustomItemHead);
			CustomItem.SetIF(CommonData, DtilCustomItemPanel, searchConditionTerget.CustomItemDtil);
// 管理番号K27057 To
		}

		private void resetSearchCondition()
		{
			PuDateFromText.Text     = string.Empty;
			PuDateToText.Text       = string.Empty;
			PuNoFromText.Text       = string.Empty;
			PuNoToText.Text         = string.Empty;
			SuplCodeText.Text       = string.Empty;
			SuplShortNameLabel.Text = string.Empty;
			SubDeptSearchCheckBox.Checked = false;
			DeptCodeText.Text       = string.Empty;
			DeptShortNameLabel.Text = string.Empty;
			EmpCodeText.Text        = string.Empty;
			EmpShortNameLabel.Text  = string.Empty;
			ProjCodeText.Text       = string.Empty;
			ProjShortNameLabel.Text = string.Empty;
			PoDateFromText.Text     = string.Empty;
			PoDateToText.Text       = string.Empty;
			PoNoFromText.Text       = string.Empty;
			PoNoToText.Text         = string.Empty;
			SuplBillSlipNoText.Text = string.Empty;
			ProdCodeText.Text       = string.Empty;
			ProdNameLabel.Text      = string.Empty;
			PuModeTypeDrop.SelectedIndex = 0;
// 管理番号K27058 From
			BookBasisTypeDrop.SelectedIndex = 0;
// 管理番号K27058 To
			ApprovalStatusTypeDrop.SelectedIndex = 0;
			RedSlipRadio.SelectedIndex = 0;
// 管理番号 B13878 From
			PriceUndecidedRadio.SelectedIndex = 1;
// 管理番号 B13878 To
// 管理番号 K16764 From
			HoldFlgRadio.SelectedIndex = 1;
// 管理番号 K16764 To
// 管理番号 K22205 From
            InputEmpCodeText.Text  = string.Empty;
            InputEmpNameLabel.Text = string.Empty;
// 管理番号 K22205 To
// 管理番号 K25679 From
			SuplSlipNo.Text = string.Empty;
			PoAdminNo.Text = string.Empty;
// 管理番号 K25679 To
// 管理番号 K25680 From
			OriginTypeDrop.SelectedIndex = 0;
// 管理番号 K25680 To
// 管理番号K27154 From
			DealTypeDrop.SelectedIndex = 0; // 取引区分
// 管理番号K27154 To
// 管理番号K27057 From
			HeadCustomItemPanel.Reset();
			DtilCustomItemPanel.Reset();
// 管理番号K27057 To
		}

// 管理番号 K24267 From
		/// <summary>
		/// 合計金額設定
		/// </summary>
		/// <param name="dt">検索結果データ</param>
		private void getTotalTtl(DataTable dt)
		{
			if (dt.Rows.Count > 0)
			{
				string curDigit = string.Empty;
				decimal tmpGrandTtl = 0M;
				decimal tmpKeyGrandTtl = 0M;

				//基軸通貨の小数桁数を取得
				string keyCurDigit = CM.MS.Cur.GetDecimalDigit(CommonData, this.KeyCurrencyCode);

				//通貨で集約
				DataView dv = new DataView(dt);
				DataTable DistinctDt = dv.ToTable("DistinctTable", true, new string[] { "CUR_CODE" });

				//通貨コードが単一の場合
				if (DistinctDt.Rows.Count == 1)
				{
					//通貨コードを取得
					string curCode = DistinctDt.Rows[0]["CUR_CODE"].ToString();
					//入力通貨の小数桁数を取得
					curDigit = CM.MS.Cur.GetDecimalDigit(CommonData, curCode);

					foreach (DataRow dr in dt.Rows)
					{
						//通貨 = 基軸通貨の場合
						decimal calcSign = dr["PU_MODE_TYPE"].ToString() == "2" ? -1M : 1M;
						if (dr["CUR_CODE"].ToString().Equals(this.KeyCurrencyCode))
						{
							tmpGrandTtl += (decimal)dr["GRAND_TTL"] * calcSign;
							tmpKeyGrandTtl += (decimal)dr["GRAND_TTL"] * calcSign;
						}
						else
						{
							tmpGrandTtl += (decimal)dr["GRAND_TTL"] * calcSign;
							tmpKeyGrandTtl += (decimal)dr["KEY_GRAND_TTL"] * calcSign;
						}
					}

					//金額合計をセット
					sumGrandTtl = CM.MS.FormatNum.GetFormatNum(this.CommonData, Convert.ToDecimal(tmpGrandTtl), double.Parse(curDigit));
					sumKeyGrandTtl = CM.MS.FormatNum.GetFormatNum(this.CommonData, Convert.ToDecimal(tmpKeyGrandTtl), double.Parse(keyCurDigit));
				}
				//複数通貨の場合
				else
				{
					foreach (DataRow dr in dt.Rows)
					{
						decimal calcSign = dr["PU_MODE_TYPE"].ToString() == "2" ? -1M : 1M;
						//通貨 = 基軸通貨の場合
						if (dr["CUR_CODE"].ToString().Equals(this.KeyCurrencyCode))
						{
							tmpKeyGrandTtl += (decimal)dr["GRAND_TTL"] * calcSign;
						}
						else
						{
							tmpKeyGrandTtl += (decimal)dr["KEY_GRAND_TTL"] * calcSign;
						}
					}
					//金額合計をセット
// 					sumGrandTtl = "※"; //K24546
					sumGrandTtl = MultiLanguage.Get("SC_CS002398");
					sumKeyGrandTtl = CM.MS.FormatNum.GetFormatNum(this.CommonData, Convert.ToDecimal(tmpKeyGrandTtl), double.Parse(keyCurDigit));
				}
			}
		}
// 管理番号 K24267 To
		#endregion

		#region DataGrid
		private void DataGrid1_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
			DataGrid1.CurrentPageIndex = e.NewPageIndex;
			DataTable dt = GetDataSource();
			setDataGridProperty(dt);
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
			DataTable dt;
			switch (e.CommandName)
			{
				case "Delete":
					IF_SC_MM_05_KeyColumn kc = new IF_SC_MM_05_KeyColumn();
					kc.SlipNo = ((CustomLinkButton) e.Item.FindControl("PuNoCodeLinkButton")).Text.Trim();
					kc.DeleteDate = this.deleteDate.Value;
// 管理番号 B15710 From
					kc.WkKey = this.Session.SessionID + DateTime.Now.ToString("yyyyMMddhhmmssfff");
// 管理番号 B15710 To
// 管理番号 B20818 From
					IF_SC_MM_05_S01_RowData rowData = new IF_SC_MM_05_S01_RowData();
					rowData.UpdateDatetime = DateTime.ParseExact(((Label) e.Item.FindControl("PrgUpdateDateTime")).Text,"yyyyMMddHHmmssfff",System.Globalization.CultureInfo.CurrentCulture);
					rowData.RefUpdateDatetime = DateTime.ParseExact(((Label) e.Item.FindControl("RefPrgUpdateDateTime")).Text,"yyyyMMddHHmmssfff",System.Globalization.CultureInfo.CurrentCulture);
// 管理番号 B20818 To
// 管理番号 K25679 From
					rowData.SuplSlipNo =((Label) e.Item.FindControl("SuplSlipNo")).Text.Trim();
// 管理番号 K25679 To
// 管理番号 K25680 From
					// 取込伝票番号がNULLでない場合
					if(((Label) e.Item.FindControl("ImportSlipNoFlg")).Text == "1")
					{
						// 仕入先伝票番号がNULLの場合1:EDI伝票、NULLでない場合2:グループ仕入取込伝票
						rowData.ProcType = ((Label) e.Item.FindControl("SuplSlipNoFlg")).Text == "0" ? "1" : "2" ;
					}
					else
					{
						rowData.ProcType = "0"; // その他
					}
// 管理番号 K25680 To

					if (!kc.HasErrors)
					{
						try
						{
							if(getLock("SM3", kc.SlipNo))
							{
								//削除処理
// 管理番号 B20818 From
//								BL_SC_MM_05.Delete(CommonData, kc);
								BL_SC_MM_05.Delete(CommonData, kc, rowData);
// 管理番号 B20818 To
								dt = GetDataSource();
								setDataGridProperty(dt);
								setMessageLabel(HtmlMessage(AllegroMessage.S00003, MessageLevel.Info));
								if(releaseLock("SM3", kc.SlipNo))
								{
									return;
								}
							}
						}
						catch (AllegroException ex)
						{
							setMessageLabel(ex.HtmlMessage);
// 管理番号 B20935 From
							if(releaseLock("SM3", kc.SlipNo))
							{
// 管理番号 B20935 To
								return;
// 管理番号 B20935 From
							}
// 管理番号 B20935 To
						}
					}
					else
					{
						setMessageLabel(kc.ErrorMessage);
						return;
					}
					break;

				case "PU_NO":
				case "Copy":
					if(FindRecordsLabel.Text.Trim().Length!=0)
					{
						dt = GetDataSource();
						setDataGridProperty(dt);
					}
					break;
			}
		}

		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			switch (e.Item.ItemType)
			{
				case ListItemType.Item:
				case ListItemType.AlternatingItem:
					DataRowView data = (DataRowView) e.Item.DataItem;
					//データグリッド内の仕入番号クリック
					CustomLinkButton puNoCodeLinkButton = (CustomLinkButton) e.Item.FindControl("PuNoCodeLinkButton");
					puNoCodeLinkButton.ClientClickScript2 = "clickPuNo('" + (string) data["PU_NO"] + "', '" + (string) data["CANCELED_ORDER_FLG"] + "')";

					//データグリッド内のコピーボタンクリック
					var copyButton = (StyledButton) e.Item.FindControl("CopyButton");
					copyButton.ClientClickScript2 = "clickCopyButton('" + (string) data["PU_NO"] + "')";
					if (data["OPPOSITE_PU_NO"].ToString().Length != 0 && searchCondition.RedSlip.Equals("1") || (string) data["PU_MODE_TYPE"] =="2")
					{
						copyButton.Visible = false;
					}

					//削除ボタンの表示設定
					var deleteButton = (StyledButton) e.Item.FindControl("DeleteButton");
// 管理番号 K25680 From
					// EDI伝票かどうか？
					bool isEdiSlip = (data["IMPORT_SLIP_NO_FLG"].ToString() == "1" && data["SUPL_SLIP_NO_FLG"].ToString() == "0");
					// 仕入.承認状況区分
					string approvalStatusType = data["APPROVAL_STATUS_TYPE"].ToString();
// 管理番号 K25680 To
// 管理番号 K25679 From
					// 承認経路区分（グループ伝票かどうかで値が変わる）
					string approvalRouteType = (data["SUPL_SLIP_NO_FLG"].ToString() == "1") ? "CG2" : "SM3";
// 管理番号 K25679 To
// 管理番号K27064 From
//// 管理番号 B22516 From
////					if (((string)data["CUTOFF_FIN_FLG"] == "1" && (string)data["KO_FLG"] == "1")
//					if (((string)data["CUTOFF_FIN_FLG"] == "1" && (string)data["DT_TYPE"] == "L")
//							|| (string)data["KO_FLG"] == "1"
//// 管理番号 B22516 To
					if ((string)data["KO_FLG"] == "1"
// 管理番号K27064 To
							|| data["OPPOSITE_PU_NO"].ToString().Length != 0
								|| (string) data["CANCELED_ORDER_FLG"] == "1"
// 管理番号 K25680 From
//									|| !Infocom.Allegro.CM.WF.Common.IsApplicant(this.CommonData, "SM3", (string) data["PU_NO"], (string) data["ORIGIN_DEPT_CODE"], this.UserCode)
//// 管理番号 K20685 From
//										||(Infocom.Allegro.CM.WF.Common.IsApp(CommonData, "SM3") && ( (string) data["APPROVAL_STATUS_TYPE"] == "2" || ((string) data["APPROVAL_STATUS_TYPE"] == "3" && (string) data["APPROVAL_CANCEL_FLG"] == "0")))
//// 管理番号 K20685 To
								// 当該行がEDI伝票でない場合
								|| (!isEdiSlip
									&& (
											// ワークフロー使用時、ログインユーザが承認申請. 申請社員コード、承認申請.入力社員コードと異なる場合
											(!CM.WF.Common.IsApplicant(this.CommonData, approvalRouteType, (string)data["PU_NO"], (string)data["ORIGIN_DEPT_CODE"], this.UserCode))
											// ワークフロー使用時、仕入.承認状況区分= 2：途中 または 3：決裁かつ仕入.決裁取消フラグ=0：なしの場合
											|| (CM.WF.Common.IsApp(CommonData, approvalRouteType)
												&& (approvalStatusType == "2" || (approvalStatusType == "3" && (string)data["APPROVAL_CANCEL_FLG"] == "0"))
												)
// 管理番号 K25679 From
											// グループ伝票の場合
											// 当該伝票に仕入先伝票番号が登録されていて、かつファイル取込プログラムテーブルで修正許可フラグが「0」（許可しない）のとき
											|| ((string)data["SUPL_SLIP_NO_FLG"] == "1" && FileImportPrg.GetCorrectFlg(this.CommonData,"CM_GR_PU") == "0")
// 管理番号 K25679 To
									)
								)
								// 当該行がEDI伝票であり、かつファイル取込プログラムテーブルにおいて修正許可フラグが「0」（許可しない）のとき
								|| (isEdiSlip && FileImportPrg.GetCorrectFlg(this.CommonData, "SC_MM_PU") == "0")
// 管理番号 K25680 To
						)
					{
						deleteButton.Visible = false;
					}
// 管理番号B25370 From
					if (0 < (int)data["CHARGE_COUNT"]
						|| 0 < (int)data["REFERRING_COUNT"]
						)
					{
						// 諸掛伝票に按分されている仕入伝票、返品が発生している仕入伝票は削除ボタン押下不可
						deleteButton.Visible = false;
					}
// 管理番号B25370 To

					//履歴伝票表示 = '1:する'
					if (searchCondition.RedSlip.Equals("1"))
					{
						//赤伝データは赤色、黒伝データは青色、通常データは黒色で表示
						string clr;
						if (data["OPPOSITE_PU_NO"].ToString().Length != 0)
						{
							((EncodeLabel) e.Item.FindControl("DetailApprovalStatusTypeLabel")).Visible = false;
							if ((data["RED_SLIP_FLG"].ToString()).Equals("1"))
							{
								clr = "slip_fnt_2";
							}
							else
							{
								clr = "slip_fnt_3";
							}
						}
						else
						{
							clr = "slip_fnt_1";
						}
						//((CustomLinkButton) e.Item.FindControl("PuNoCodeLinkButton")).CssClass		= clr;
						((EncodeLabel) e.Item.FindControl("DetailPuDateLabel")).CssClass			= clr;
						((EncodeLabel) e.Item.FindControl("DetailSuplShortNameLabel")).CssClass		= clr;
						((EncodeLabel) e.Item.FindControl("DetailSuplBillSlipNoLabel")).CssClass	= clr;
						((EncodeLabel) e.Item.FindControl("DetailDeptNameLabel")).CssClass			= clr;
						((EncodeLabel) e.Item.FindControl("DetailEmpNameLabel")).CssClass			= clr;
						((EncodeLabel) e.Item.FindControl("DetailGrandTtlLabel")).CssClass			= clr;
						((EncodeLabel) e.Item.FindControl("PuModeTypeLabel")).CssClass				= clr;
						((EncodeLabel) e.Item.FindControl("DetailPoNoLabel")).CssClass				= clr;
						((EncodeLabel) e.Item.FindControl("DetailPoDateLabel")).CssClass			= clr;
						((EncodeLabel) e.Item.FindControl("DetailCutoffDateLabel")).CssClass		= clr;
						((EncodeLabel) e.Item.FindControl("DetailOriginalPuNoLabel")).CssClass		= clr;
// 管理番号 K25679 From
						((EncodeLabel) e.Item.FindControl("DetailPoAdminNo")).CssClass				= clr;
// 管理番号 K25679 To
					}
					else
					{
						((EncodeLabel) e.Item.FindControl("DetailOriginalPuNoLabel")).Visible = false;
					}
// 管理番号K26508 From
					// 参照権限時の明細コントロール制御
					viewAuthorityGridControls(e.Item);
// 管理番号K26508 To
					break;
// 管理番号 K24267 From
				case ListItemType.Footer:
					//合計欄設定
					((EncodeLabel)e.Item.FindControl("TotalGrandTtlLabel")).Text = sumGrandTtl;
					((EncodeLabel)e.Item.FindControl("TotalKeyGrandTtlLabel")).Text = sumKeyGrandTtl;
					break;
// 管理番号 K24267 To
			}
		}
		private void DataGrid1_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
		{
			 if (sort == e.SortExpression + " ASC")
			{
				sort = e.SortExpression + " DESC";
			}
			else
			{
				sort = e.SortExpression + " ASC";
			}
			DataTable dt = GetDataSource();
			setDataGridProperty(dt);
		}

		protected void DataGrid1_Sort(object sender, CommandEventArgs e)
		{
			if (sort == e.CommandName + " ASC")
			{
				sort = e.CommandName + " DESC";
			}
			else
			{
				sort = e.CommandName + " ASC";
			}
			DataTable dt = GetDataSource();
			setDataGridProperty(dt);
		}

// 管理番号 K24267 From
		private void DataGrid1_ItemCreated(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			switch (e.Item.ItemType)
			{
				case ListItemType.Footer:
					//ワークフローを使用する場合
					if ((Infocom.Allegro.CM.WF.Common.IsApp(CommonData, "SM3")))
					{
						//セル結合
						e.Item.Cells.RemoveAt(4);
						e.Item.Cells.RemoveAt(3);
						e.Item.Cells.RemoveAt(2);
						e.Item.Cells.RemoveAt(1);
						e.Item.Cells[0].ColumnSpan = 5;
						//セル結合
						e.Item.Cells.RemoveAt(2);
						e.Item.Cells[2].ColumnSpan = 2;
						e.Item.Cells.RemoveAt(3);
						e.Item.Cells[3].ColumnSpan = 2;
						//表示名設定
// 						e.Item.Cells[0].Text = "(仕入金額合計)"; //K24546
						e.Item.Cells[0].Text = MultiLanguage.Get("SC_CS002049");
						//表示位置設定
						e.Item.Cells[0].HorizontalAlign = e.Item.Cells[1].HorizontalAlign
							= e.Item.Cells[2].HorizontalAlign = e.Item.Cells[3].HorizontalAlign = HorizontalAlign.Right;
					}
					else
					{
						//セル結合
						e.Item.Cells.RemoveAt(3);
						e.Item.Cells.RemoveAt(2);
						e.Item.Cells.RemoveAt(1);
						e.Item.Cells[1].ColumnSpan = 4;
						//セル結合
						e.Item.Cells.RemoveAt(3);
						e.Item.Cells[3].ColumnSpan = 2;
						e.Item.Cells.RemoveAt(4);
						e.Item.Cells[4].ColumnSpan = 2;

						//表示名設定
// 						e.Item.Cells[1].Text = "(仕入金額合計)"; //K24546
						e.Item.Cells[1].Text = MultiLanguage.Get("SC_CS002049");
						//表示位置設定
						e.Item.Cells[1].HorizontalAlign = e.Item.Cells[2].HorizontalAlign
							= e.Item.Cells[3].HorizontalAlign = e.Item.Cells[4].HorizontalAlign = HorizontalAlign.Right;
					}
					break;
			}
		}
// 管理番号 K24267 To

		#endregion

		#region Button Event
		private void SearchButton_Click(object sender, EventArgs e)
		{
			//テンポラリのsearchConditionを作成
			IF_SC_MM_05_S01_SearchCondition tmpSearchCondition = new IF_SC_MM_05_S01_SearchCondition();
			//（キャンセルの場合には、検索条件をバックデートする必要があるためテンポラリのSearchConditionを作成する）

			setSearchCondition(tmpSearchCondition);
			//（テンポラリSearchConditionの設定・・量が多いため外だししています）
			tmpSearchCondition.Validate(this.CommonData, this.DisclosureUnitType, this.UserDeptCode);
			if (!tmpSearchCondition.HasErrors)
			{
				//しきい値の判定
				if (searchRetryHidden.Value.Equals("R"))
				{
					//（ここの処理は二回目（ダイアログが表示されて、「はい」が押下された場合）に通ります。
					//二回目の場合は、Hidden値を戻してチェック処理を抜けます）
					//Hidden設定を戻す
					searchRetryHidden.Value = string.Empty;
				}
				else
				{
					//しきい値のチェック
					DataTable cntDt = BL_SC_MM_05_S01.Select(tmpSearchCondition, CommonData, false);
					//（作成したテンポラリのSeachConditionを使って、件数を取得します。通常のBLの最後にfalseを渡すと件数を返すようにしています）

					int dataCnt=(int) cntDt.Rows[0]["DATACOUNT"];
					//（件数を取得）
					//500件を超える場合はメッセージを表示する。
					if (dataCnt > MAX_DATA_CNT)
					{
// 管理番号K26528 From
//						if (!ClientScript.IsStartupScriptRegistered("searchCheck"))
						if (!PageStartupScript.IsScriptRegistered("searchCheck"))
// 管理番号K26528 To
						{
							//（Scriptで警告メッセージを表示します）
							StringBuilder script = new StringBuilder();
							//警告ダイアログを表示する。
// 管理番号K26528 From
//							script.Append("<script  type=\"text/javascript\">\n");
//							script.Append("<!--\n");
// 管理番号K26528 To
							script.Append("	if (confirm(\"");
							script.Append(AllegroMessage.S00004(dataCnt));
							script.Append("\"))\n");
							script.Append("	{\n");
							script.Append("		document.getElementById(\"SearchButton\").click();\n");
							//（確認ダイアログで、「はい」が押された場合は、検索ボタン押下を再実行）
							script.Append("	}\n	else\n	{\n");
							script.Append("		document.getElementById(\"searchRetryHidden\").value=\"\";\n");
							script.Append("		document.getElementById(\"PuDateFromText\").focus();\n");
							//（キャンセルが押下された場合には、リトライ判定のHidden値をクリアして検索先頭項目にフォーカスを遷移する）
							script.Append("}\n");
// 管理番号K26528 From
//							script.Append("-->\n");
//							script.Append("</script>");
//							Page.ClientScript.RegisterStartupScript(this.GetType(), "searchCheck",script.ToString());
							PageStartupScript.RegisterScript(this.GetType(), "searchCheck",script.ToString());
// 管理番号K26528 To
						}
						//Hidden値設定をリトライに設定
						searchRetryHidden.Value="R";
						//（二度目の検索押下かを判定するHiddenを設定）
						return;
					}
				}

				//SearchConditionの置き換え
				searchCondition=tmpSearchCondition;
				//（ここで、テンポラリのSearchConditionを本物にします）
				//以降は、通常の検索処理です。

				//ページ番号初期化
				DataGrid1.CurrentPageIndex = 0; //先頭ページに移動
				//表示件数の保存
				ViewState["ViewNum"] = viewnum = int.Parse(DisplayRecordsDrop.SelectedValue);
				// ソート条件セット
// 管理番号 B24161 From
//				sort = "[PU_DATE] DESC";
				sort = String.Empty;
// 管理番号 B24161 To
				DataTable dt = GetDataSource();
				setDataGridProperty(dt);
			}
			else
			{
				setMessageLabel(tmpSearchCondition.ErrorMessage);
				return;
			}
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{
			resetSearchCondition();
		}

		private void CloseButton_Click(object sender, EventArgs e)
		{
			CloseWindow();
		}

		private void NewButton_Click(object sender, EventArgs e)
		{
			if(FindRecordsLabel.Text.Trim().Length!=0)
			{
				DataTable dt = GetDataSource();
				setDataGridProperty(dt);
			}
		}

		private void PuListButton_Click(object sender, EventArgs e)
		{
			if (checkPrintData(PuListButton.ID, "SC_MM_05_R03"))
			{
				//帳票出力要求からの呼び出し
// 管理番号K26528 From
//				if (!ClientScript.IsStartupScriptRegistered("executePrint"))
				if (!PageStartupScript.IsScriptRegistered("executePrint"))
// 管理番号K26528 To
				{
					//出力条件の設定
					Session.Add(Report.Constants.SessionName, searchCondition);
					//印刷データを取得する
					StringBuilder script = new StringBuilder();
// 管理番号K26528 From
//					script.Append("<script type=\"text/vbscript\">\n");																	
//					script.Append("<!--\n");
//					script.Append("sub arv_ControlLoaded()\n");
//					script.Append("	Form1.arv.DataPath = \"SC_MM_05_R03.aspx?");
//					script.Append(Report.Constants.PrintTerm);
//					script.Append("=");
//					script.Append(Report.Constants.ReportPrint);
//// 管理番号 B13879 From
//					script.Append("&PuListOutputFlg=").Append("1");
//					script.Append("&PuOutputFlg=").Append("0");
//// 管理番号 B13879 To
//					script.Append("\"\n");
//					//マウスポインタのカーソル設定
//					script.Append("	document.body.style.cursor=\"wait\"\n");
//					script.Append("	printingFlg=true\n");
//					script.Append("end sub\n");
//					script.Append("-->\n");
//					script.Append("</script>");
//					Page.ClientScript.RegisterStartupScript(this.GetType(), "executePrint",script.ToString());
//				}
//				MessageLabel.Text=HtmlMessage(AllegroMessage.R00001,MessageLevel.Info);
					PDFType pdfExportType = PDFType.Save;
					if (clickHidden.Value == "1")
					{
						script.Append(Report.Constants.PrevTerm).Append("=").Append(Report.Constants.ReportPrint).Append("&");
						pdfExportType = PDFType.View;
					}
					script.Append("PuListOutputFlg=").Append("1");
					script.Append("&PuOutputFlg=").Append("0");
					string reportName = CM.MS.Report.GetReportName(this.CommonData, "SC_MM_05_R03");
					string printScript = ReportExport.MakePrintScript("SC_MM_05_R03", script.ToString(), pdfExportType, reportName);
					PageStartupScript.RegisterScript(this.GetType(), "executePrint", printScript);
				}
// 管理番号K26528 To
			}
		}

		private void PuDetailListButton_Click(object sender, EventArgs e)
		{
// 管理番号K26528 From
//// 管理番号 B18049 From
//			ShowsPrintDialogLabel.Text = Infocom.Allegro.CM.MS.Report.ShowsPrintDialog(this.CommonData,"SC_MM_05_R07",Infocom.Allegro.Report.ScreenType.ReportPrint).ToString();
//// 管理番号 B18049 To
// 管理番号K26528 To
			if (checkPrintData(PuDetailListButton.ID, "SC_MM_05_R07"))
			{
				//帳票出力要求からの呼び出し
// 管理番号K26528 From
//				if (!ClientScript.IsStartupScriptRegistered("executePrint"))
				if (!PageStartupScript.IsScriptRegistered("executePrint"))
// 管理番号K26528 To
				{
					//出力条件の設定
					Session.Add(Report.Constants.SessionName, searchCondition);
					//印刷データを取得する
					StringBuilder script = new StringBuilder();
// 管理番号K26528 From
//					script.Append("<script type=\"text/vbscript\">\n");
//					script.Append("<!--\n");
//					script.Append("sub arv_ControlLoaded()\n");
//					script.Append("	Form1.arv.DataPath = \"SC_MM_05_R07.aspx?");
//					script.Append(Report.Constants.PrintTerm);
//					script.Append("=");
//					script.Append(Report.Constants.ReportPrint);
//					script.Append("\"\n");
//					//マウスポインタのカーソル設定
//					script.Append("	document.body.style.cursor=\"wait\"\n");
//					script.Append("	printingFlg=true\n");
//					script.Append("end sub\n");
//					script.Append("-->\n");
//					script.Append("</script>");
//					Page.ClientScript.RegisterStartupScript(this.GetType(), "executePrint",script.ToString());
//				}
//
//				setMessageLabel(HtmlMessage(AllegroMessage.R00001, MessageLevel.Info));
					PDFType pdfExportType = PDFType.Save;
					if (clickHidden.Value == "1")
					{
						script.Append(Report.Constants.PrevTerm).Append("=").Append(Report.Constants.ReportPrint);
						pdfExportType = PDFType.View;
					}
					string reportName = CM.MS.Report.GetReportName(this.CommonData, "SC_MM_05_R07");
					string printScript = ReportExport.MakePrintScript("SC_MM_05_R07", script.ToString(), pdfExportType, reportName);
					PageStartupScript.RegisterScript(this.GetType(), "executePrint", printScript);
				}
// 管理番号K26528 To
			}
		}
// 管理番号 K24268 From
		private void PuListOutputButton_Click(object sender, EventArgs e)
		{
// 管理番号K26528 From
//			ShowsPrintDialogLabel.Text = Infocom.Allegro.CM.MS.Report.ShowsPrintDialog(this.CommonData, "SC_MM_05_R08", Infocom.Allegro.Report.ScreenType.ReportPrint).ToString();
// 管理番号K26528 To

			if (checkPrintData(PuListOutputButton.ID, "SC_MM_05_R08"))
			{
				//帳票出力要求からの呼び出し
// 管理番号K26528 From
//				if (!ClientScript.IsStartupScriptRegistered("executePrint"))
				if (!PageStartupScript.IsScriptRegistered("executePrint"))
// 管理番号K26528 To
				{
					//出力条件の設定
					Session.Add(Report.Constants.SessionName, searchCondition);
					//印刷データを取得する
					StringBuilder script = new StringBuilder();
// 管理番号K26528 From
//					script.Append("<script type=\"text/vbscript\">\n");
//					script.Append("<!--\n");
//					script.Append("sub arv_ControlLoaded()\n");
//					script.Append("	Form1.arv.DataPath = \"SC_MM_05_R08.aspx?");
//					script.Append(Report.Constants.PrintTerm);
//					script.Append("=");
//					script.Append(Report.Constants.ReportPrint);
//					script.Append("\"\n");
//					//マウスポインタのカーソル設定
//					script.Append("	document.body.style.cursor=\"wait\"\n");
//					script.Append("	printingFlg=true\n");
//					script.Append("end sub\n");
//					script.Append("-->\n");
//					script.Append("</script>");
//					Page.ClientScript.RegisterStartupScript(this.GetType(), "executePrint", script.ToString());
//				}
//
//				setMessageLabel(HtmlMessage(AllegroMessage.R00001, MessageLevel.Info));
					PDFType pdfExportType = PDFType.Save;
					if (clickHidden.Value == "1")
					{
						script.Append(Report.Constants.PrevTerm).Append("=").Append(Report.Constants.ReportPrint);
						pdfExportType = PDFType.View;
					}
					string reportName = CM.MS.Report.GetReportName(this.CommonData, "SC_MM_05_R08");
					string printScript = ReportExport.MakePrintScript("SC_MM_05_R08", script.ToString(), pdfExportType, reportName);
					PageStartupScript.RegisterScript(this.GetType(), "executePrint", printScript);
				}
// 管理番号K26528 To
			}
		}
// 管理番号 K24268 To

		#endregion

		#region Print Method
		private bool checkPrintData(string clickButton, string reportId)
		{
			//検索条件のチェックと、出力件数の確認を行う
			setSearchCondition(searchCondition);
			searchCondition.Validate(this.CommonData, this.DisclosureUnitType, this.UserDeptCode);
			if (searchCondition.HasErrors)
			{
				setMessageLabel(searchCondition.ErrorMessage);
				return false;
			}

			int headerCnt = 0;
			int detailCnt = 0;
			switch (reportId)
			{
				case "SC_MM_05_R03":
					headerCnt = int.Parse(BL_SC_MM_05_R03.Select(searchCondition, this.CommonData, "Header", true, "").Rows[0].ItemArray[0].ToString());
					detailCnt = int.Parse(BL_SC_MM_05_R03.Select(searchCondition, this.CommonData, "Detail", true, "").Rows[0].ItemArray[0].ToString());
					break;
				case "SC_MM_05_R07":
					headerCnt = int.Parse(BL_SC_MM_05_R07.Select(searchCondition, this.CommonData, "Header", true).Rows[0].ItemArray[0].ToString());
					detailCnt = int.Parse(BL_SC_MM_05_R07.Select(searchCondition, this.CommonData, "Detail", true).Rows[0].ItemArray[0].ToString());
					break;
// 管理番号 K24268 From
				case "SC_MM_05_R08":
					headerCnt = int.Parse(BL_SC_MM_05_R08.Select(searchCondition, this.CommonData, true).Rows[0].ItemArray[0].ToString());
					detailCnt = headerCnt;
					break;
// 管理番号 K24268 To
				default:
					break;
			}

			if (headerCnt == 0 || detailCnt == 0)
			{
				setMessageLabel(HtmlMessage(AllegroMessage.S10002, MessageLevel.Info));
				FocusControl(PuDateFromText.ClientID);
				return false;
			}

			if (postCountHidden.Value.Equals("R"))
			{
				//Hidden設定を戻す
				postCountHidden.Value = string.Empty;
			}
			else
			{
				int limitCnt = 0;
				//しきい値のチェック
				switch (reportId)
				{
					case "SC_MM_05_R03":
						limitCnt = Infocom.Allegro.CM.MS.Report.GetPrintableCount(this.CommonData,"SC_MM_05_R03",Infocom.Allegro.Report.ScreenType.ReportPrint);
						break;
					case "SC_MM_05_R07":
						limitCnt = Infocom.Allegro.CM.MS.Report.GetPrintableCount(this.CommonData,"SC_MM_05_R07",Infocom.Allegro.Report.ScreenType.ReportPrint);
						break;
// 管理番号 K24268 From
					case "SC_MM_05_R08":
						limitCnt = Infocom.Allegro.CM.MS.Report.GetPrintableCount(this.CommonData,"SC_MM_05_R08",Infocom.Allegro.Report.ScreenType.ReportPrint);
						break;
// 管理番号 K24268 To
					default:
						break;
				}
				if (headerCnt > limitCnt)
				{
					//帳票出力要求からの呼び出し
// 管理番号K26528 From
//					if (!ClientScript.IsStartupScriptRegistered("showWarning"))
					if (!PageStartupScript.IsScriptRegistered("showWarning"))
// 管理番号K26528 To
					{

						//警告ダイアログを表示する。
						StringBuilder script = new StringBuilder();
// 管理番号K26528 From
//						script.Append("<script type=\"text/javascript\">\n");
//						script.Append("<!--\n");
// 管理番号K26528 To
						script.Append("	if (confirm(\"");
						script.Append(AllegroMessage.R00003(headerCnt));
						script.Append("\"))\n");
						script.Append("	{\n");
						script.Append("		document.getElementById(\"");
						script.Append(clickButton);
						script.Append("\").click();\n");
						script.Append("	}\n	else\n	{\n");
						script.Append("		document.getElementById(\"postCountHidden\").value=\"\";\n");
						script.Append("}\n");
// 管理番号K26528 From
//						script.Append("-->\n");
//						script.Append("</script>");
//						Page.ClientScript.RegisterStartupScript(this.GetType(), "showWarning",script.ToString());
						PageStartupScript.RegisterScript(this.GetType(), "showWarning",script.ToString());
// 管理番号K26528 To
					}
					//Hidden値設定をリトライに設定
					postCountHidden.Value="R";
					return false;
				}
			}
			return true;
		}

		#endregion

		#region Protected Method
// 管理番号 B18736 FROM

// 管理番号 B18736 コメント削除

		protected string formatAmt(decimal decAmt, string curCode)
		{
			decimal result;

			// 通貨の桁数取得
			string cur = Cur.GetDecimalDigit(CommonData, curCode);
			result     = decAmt;

			string amt = Common.ListFormatAmt(result, double.Parse(cur));

			return amt;

		}
// 管理番号 B18736 TO

// 管理番号 K20685 From
//		protected string setApprovalStatusText(string s)
		protected string setApprovalStatusText(string s, string c)
// 管理番号 K20685 To
		{
			switch(s)
			{
				case "1":
// 					return "申"; //K24546
					return MultiLanguage.Get("SC_CS004412");
				case "2":
// 					return "途"; //K24546
					return MultiLanguage.Get("SC_CS004897");
				case "3":
// 管理番号 K20685 From
//					return "決";
					if(c == "0")
					{
// 						return "決"; //K24546
						return MultiLanguage.Get("SC_CS003239");
					}
					else
					{
// 						return "消"; //K24546
						return MultiLanguage.Get("SC_CS004356");
					}
// 管理番号 K20685 To
				case "4":
// 					return "差"; //K24546
					return MultiLanguage.Get("SC_CS003471");
				case "5":
// 					return "保"; //K24546
					return MultiLanguage.Get("SC_CS005428");
				default:
					return "";
			}
		}

// 管理番号K27058 From
//		protected string setPuModeTypeText(string s)
//		{
//			switch(s)
//			{
//				case "1":
//					return this.ModeTypeUsuallyWord;
//				case "2":
//					return this.ModeTypeReturnWord;
//				case "4":
//					return this.ModeTypeCommissionWord;
//				default:
//					return "";
//			}
//		}
// 管理番号K27058 To
		#endregion

		#region Private Method

// 管理番号K27058 From
//		private void setPuModeTypeDrop()
//		{
//			PuModeTypeDrop.Items.Insert(0, new ListItem(string.Empty, "0"));
//			PuModeTypeDrop.Items.Insert(1, new ListItem(this.ModeTypeUsuallyWord, "1"));
//			PuModeTypeDrop.Items.Insert(2, new ListItem(this.ModeTypeReturnWord, "2"));
//			PuModeTypeDrop.Items.Insert(3, new ListItem(this.ModeTypeCommissionWord, "4"));
//			PuModeTypeDrop.SelectedIndex = 0;
//		}
		private void setPuModeTypeDrop()
		{
			MultipurposeType.GetModeTypeListDataSource(CommonData, PuModeTypeDrop, this.ModeTypeUsuallyUseType, this.ModeTypeReturnUseType, false, this.ModeTypeCommissionUseType, false, true);
			PuModeTypeDrop.SelectedIndex = 0;
		}

		/// <summary>
		/// 仕入計上基準ドロップダウンの初期設定
		/// </summary>
		private void setBookBasisTypeDrop()
		{
			MultipurposeType.GetBookBasisTypeListDataSource(CommonData, BookBasisTypeDrop, "5", true, true, true);
			BookBasisTypeDrop.SelectedIndex = 0;
		}
		/// <summary>
		/// 運送業者初期設定
		/// </summary>
		private void setBookBasisTypeDrop()
		{
			MultipurposeType.GetBookBasisTypeListDataSource(CommonData, CarrierDrop, "5", true, true, true);		
		}
		// 管理番号K27058 To
		private void setApprovalStatusTypeDrop()
		{
			ApprovalStatusTypeDrop.Items.Insert(0, new ListItem(string.Empty, "0"));
// 			ApprovalStatusTypeDrop.Items.Insert(1, new ListItem("申請", "1")); //K24546
			ApprovalStatusTypeDrop.Items.Insert(1, new ListItem(MultiLanguage.Get("SC_CS001250"), "1"));
// 			ApprovalStatusTypeDrop.Items.Insert(2, new ListItem("途中", "2")); //K24546
			ApprovalStatusTypeDrop.Items.Insert(2, new ListItem(MultiLanguage.Get("SC_CS001563"), "2"));
// 			ApprovalStatusTypeDrop.Items.Insert(3, new ListItem("決裁", "3")); //K24546
			ApprovalStatusTypeDrop.Items.Insert(3, new ListItem(MultiLanguage.Get("SC_CS003243"), "3"));
// 			ApprovalStatusTypeDrop.Items.Insert(4, new ListItem("差戻", "4")); //K24546
			ApprovalStatusTypeDrop.Items.Insert(4, new ListItem(MultiLanguage.Get("SC_CS000660"), "4"));
// 			ApprovalStatusTypeDrop.Items.Insert(5, new ListItem("保留", "5")); //K24546
			ApprovalStatusTypeDrop.Items.Insert(5, new ListItem(MultiLanguage.Get("SC_CS001897"), "5"));
// 管理番号 K20685 From
// 			ApprovalStatusTypeDrop.Items.Insert(6, new ListItem("決消", "6")); //K24546
			ApprovalStatusTypeDrop.Items.Insert(6, new ListItem(MultiLanguage.Get("SC_CS003246"), "6"));
// 管理番号 K20685 To
			ApprovalStatusTypeDrop.SelectedIndex = 0;
		}
// 管理番号 K25680 From
		private void setOriginTypeDrop()
		{
			DataTable dt = Slip.GetSlipTypeShortName(this.CommonData, SLIP_TYPE_CODE);
			string slipTypeShortName = (string)dt.Rows.Find(SLIP_TYPE_CODE)["SLIP_TYPE_SHORT_NAME"];

			// 共通BLで取得した伝票区分名をドロップダウンリストに追加。
			// 各リストアイテムは対応するインデックスを持つ。
			// 0:ブランク（全件検索）
			OriginTypeDrop.Items.Add(new ListItem(string.Empty, "0"));
			// 1:伝票区分マスタから取得した値（仕入入力により作成された伝票）
			OriginTypeDrop.Items.Add(new ListItem(slipTypeShortName, "1"));
			// 2:外部（EDI取込）
			OriginTypeDrop.Items.Add(new ListItem(MultiLanguage.Get("SC_CS006221"), "2"));	//「外部」
			// ドロップダウンリストに初期値のブランクをセットする
			OriginTypeDrop.SelectedIndex = 0;
		}
// 管理番号 K25680 To
// 管理番号K27154 From
		/// <summary>
		/// 取引区分のドロップダウンリスト設定
		/// </summary>
		private void setDealTypeDrop()
		{
			DealType.SetDataSource(this.CommonData, this.DealTypeDrop, "S");
			this.DealTypeDrop.DataBind();
		}
// 管理番号K27154 To

		#endregion

		#region HedderChangeEvent
		private void SuplCodeText_TextChanged(object sender, System.EventArgs e)
		{
			string SuplName = string.Empty;
			//基準日の設定（優先順位：仕入日（自）→仕入日（至）→本日日付）
			string compDate = DateTime.Today.ToString();
			if(PuDateToText.Text.Length!=0)
			{
				compDate = PuDateToText.Text;
			}
			else if(PuDateFromText.Text.Length!=0)
			{
				compDate = PuDateFromText.Text;
			}
			if (SuplCodeText.Text.Trim().Length != 0)
			{
				if (Supl.IsExistsSupl(CommonData, SuplCodeText.Text, (byte)CompanyCodeLength, out SuplName, compDate, false, "D", false))
				{
					FocusControl(SuplCodeText.NextControlID, sender);
				}
				else
				{
					FocusControl(SuplCodeText.ID, sender);
				}
			}
			else
			{
				FocusControl(SuplCodeText.NextControlID, sender);
			}
			SuplShortNameLabel.Text = SuplName;
		}

		private void DeptCodeText_TextChanged(object sender, System.EventArgs e)
		{
			string DeptName = string.Empty;
			if (DeptCodeText.Text.Trim().Length != 0)
			{
				//基準日の設定（優先順位：仕入日（自）→仕入日（至）→本日日付）
				string compareDate = DateTime.Today.ToString();
				if (PuDateToText.Text.Length != 0)
				{
					compareDate = PuDateToText.Text;
				}
				else if (PuDateFromText.Text.Length != 0)
				{
					compareDate = PuDateFromText.Text;
				}
				// 自部門権限時参照部門設定
				string lowerDept = this.DisclosureUnitType == "D" ? this.UserDeptCode : string.Empty;

				if (Dept.IsExists(CommonData, DeptCodeText.Text, out DeptName, compareDate, false, false, false, lowerDept, false, false))
				{
					FocusControl(DeptCodeText.NextControlID, sender);
				}
				else
				{
					FocusControl(DeptCodeText.ID, sender);
				}
			}
			else
			{
				FocusControl(DeptCodeText.NextControlID, sender);
			}
			DeptShortNameLabel.Text = DeptName;
		}

		private void EmpCodeText_TextChanged(object sender, System.EventArgs e)
		{
			string EmpName = string.Empty;
			//基準日の設定（優先順位：仕入日（自）→仕入日（至）→本日日付）
			string compareDate = DateTime.Today.ToString();
			if (PuDateToText.Text.Length != 0)
			{
				compareDate = PuDateToText.Text;
			}
			else if (PuDateFromText.Text.Length != 0)
			{
				compareDate = PuDateFromText.Text;
			}
			if (EmpCodeText.Text.Trim().Length != 0)
			{
				if (Emp.IsExists(CommonData, EmpCodeText.Text, out EmpName, false))
				{
					FocusControl(EmpCodeText.NextControlID, sender);
				}
				else
				{
					FocusControl(EmpCodeText.ID, sender);
				}
			}
			else
			{
				FocusControl(EmpCodeText.NextControlID, sender);
			}
			EmpShortNameLabel.Text = EmpName;
		}
// 管理番号 K22205 From
        private void InputEmpCodeText_TextChanged(object sender, System.EventArgs e)
        {
            string InputEmpName = string.Empty;
            if (InputEmpCodeText.Text.Trim().Length != 0)
            {
                if (Emp.IsExists(CommonData, InputEmpCodeText.Text, out InputEmpName))
                {
                    FocusControl(InputEmpCodeText.NextControlID, sender);
                }
                else
                {
                    FocusControl(InputEmpCodeText.ID, sender);
                }
            }
            else
            {
                FocusControl(InputEmpCodeText.NextControlID, sender);
            }
            InputEmpNameLabel.Text = InputEmpName;
        }
// 管理番号 K22205 To

		private void ProjCodeText_TextChanged(object sender, System.EventArgs e)
		{
			string projName = string.Empty ;
			//基準日の設定（優先順位：仕入日（自）→仕入日（至）→本日日付）
			string compareDate = DateTime.Today.ToString();
			if (PuDateToText.Text.Length != 0)
			{
				compareDate = PuDateToText.Text;
			}
			else if (PuDateFromText.Text.Length != 0)
			{
				compareDate = PuDateFromText.Text;
			}
			if (ProjCodeText.Text.Trim().Length != 0)
			{
				if(Proj.IsExists(this.CommonData,ProjCodeText.Text.Trim(),(byte)this.ProjectCodeLength, out projName, compareDate ,DeptCodeText.Text.ToString()))
				{
					FocusControl(ProjCodeText.NextControlID, sender);
				}
				else
				{
					FocusControl(ProjCodeText.ID, sender);
				}
			}
			else
			{
				FocusControl(ProjCodeText.NextControlID, sender);
			}
			ProjShortNameLabel.Text = projName;
		}

		private void ProdCodeText_TextChanged(object sender, System.EventArgs e)
		{
			string ProdName = string.Empty;
			if (ProdCodeText.Text.Trim().Length != 0)
			{
				if(Prod.IsExists(CommonData, ProdCodeText.Text, "PO", "all", out ProdName))
				{
					FocusControl(ProdCodeText.NextControlID, sender);
				}
				else
				{
					FocusControl(ProdCodeText.ID, sender);
				}
			}
			else
			{
				FocusControl(ProdCodeText.NextControlID, sender);
			}
			ProdNameLabel.Text = ProdName;
		}

		#endregion

		#region Lock Method
		// 悲観ロックＯＮ
		private bool getLock(string slipTypeCode, string slipNo)
		{
			string message = string.Empty;
			bool result = true ;
			try
			{
				result = Lock.GetLock(this.CommonData, Request, Session, slipTypeCode, slipNo, out message);
				if (result == false)
				{
// 管理番号K26528 From
//					string script = @"<script type=""text/javascript"">
//<!--
//	alert(""" + message + @""");
//// -->
//</script>";
//					ClientScript.RegisterStartupScript(this.GetType(), "alertLock", script);
					var script = new StringBuilder();
					script.Append("alert('" + message + "');");
					PageStartupScript.RegisterScript(this.GetType(), "alertLock", script.ToString());
// 管理番号K26528 To
				}
			}
			catch (AllegroException ex)
			{
				result = false ;
				setMessageLabel(ex.HtmlMessage);
			}
			return result;
		}

		// 悲観ロックＯＦＦ
		private bool releaseLock(string slipTypeCode, string releaseSlipNo)
		{
			bool result = true ;
			try
			{
				Lock.ReleaseLock(this.CommonData, Session, slipTypeCode, releaseSlipNo);
			}
			catch (AllegroException ex)
			{
				result = false ;
				setMessageLabel(ex.HtmlMessage);
			}
			return result;
		}
		#endregion

// 管理番号K26508 From
		#region 参照権限制御
		// 権限設定区分が"V"：参照権限の場合、データ更新不可となるようコントロールを制御する。
		private void viewAuthorityControls()
		{
			if (this.AuthoritySettingType == "V")
			{
				this.NewButton.Enabled = false;			// ヘッダ新規ボタン
				this.NewButton2.Enabled = false;		// フッタ新規ボタン
			}
		}

		// 権限設定区分が"V"：参照権限の場合、データ更新不可となるよう明細のコントロールを制御する。
		private void viewAuthorityGridControls(DataGridItem item)
		{
			if (this.AuthoritySettingType == "V")
			{
				((StyledButton) item.FindControl("CopyButton")).Enabled = false;		// コピーボタン
				((StyledButton) item.FindControl("DeleteButton")).Enabled = false;		// 削除ボタン
			}
		}
		#endregion
// 管理番号K26508 To
	}
}
