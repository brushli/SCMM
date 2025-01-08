// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : CustomDataGrid.cs
// 機能名      : データグリッドカスタムコントロール
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 1.6.0 2009/09/30
// 2.2.0 2014/10/31
// 管理番号 K25902 2015/09/30 データグリッドCSV出力機能追加対応
// 管理番号 K25899 2015/11/16 スクロールバー位置制御対応
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/15 UI見直し
// 3.0.0 2018/04/30
// 3.1.0 2020/06/30
// 管理番号K27230 2021/05/27 脆弱性対応
// 3.2.0 2023/03/31

using System;
using System.Data;
// 管理番号 K25899 From
using System.Configuration;
// 管理番号 K25899 To
// 管理番号K26528 From
using System.Globalization;
using System.Linq;
// 管理番号K26528 To
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// データグリッドカスタムコントロール
	/// </summary>
	/// <remarks>
	/// <b>CustomDataGrid</b> は GRANDIT用に縦スクロールバーの表示、楽観的ロック用に更新日時の保持をサポートします。
	/// </remarks>
	[ToolboxData("<{0}:CustomDataGrid runat=server></{0}:CustomDataGrid>")]
	public class CustomDataGrid : System.Web.UI.WebControls.DataGrid
	{
		#region Fields
// 管理番号K26528 From
		public static readonly Unit ScrollBarWidth = Unit.Pixel(17);
// 管理番号K26528 To
// 管理番号 K25899 From
		private bool restoreScrollPosition = true;
// 管理番号 K25899 To
// 管理番号K26528 From
		/// <summary>
		/// データグリッドの各行に対して内部で採番するコントロールIDの接頭辞。
		/// <para>XhtmlConformanceModeの影響を受けずに後方互換を維持するため、旧来のID付与方法を内部で実装する。</para>
		/// </summary>
        private const string idPrefix = "_ctl";

		/// <summary>
		/// データグリッドの各行に対して内部で採番するコントロールIDの連番。
		/// <para>XhtmlConformanceModeの影響を受けずに後方互換を維持するため、旧来のID付与方法を内部で実装する。</para>
		/// </summary>
		private int idSeqNo;
// 管理番号K26528 To
		#endregion

		#region Properties
		/// <summary>
		/// <see cref="CustomDataGrid"/>の高さの最大値。
		/// </summary>
		[
		Category("Layout"),
		DefaultValue(""),
		Description("コントロールの高さの最大値です。")
		]
		public virtual Unit MaxHeight
		{
			get
			{
				object o = ViewState["MaxHeight"];
				return (o != null) ? (Unit) o :  Unit.Empty;
			}
			set {ViewState["MaxHeight"] = value;}
		}

		/// <summary>
		/// スクロールバーを表示しない最大の件数。この件数を超えるとスクロールバーが表示されます。
		/// </summary>
		[
		Category("Layout"),
		DefaultValue(0),
		Description("この件数を超えるとスクロールバーが表示されます。")
		]
		public virtual int ScrollItemsCount
		{
			get
			{
				object o = ViewState["ScrollItemsCount"];
				return (o != null) ? (int) o : 0;
			}
			set {ViewState["ScrollItemsCount"] = value;}
		}

		/// <summary>
		/// 楽観ロックを使用するかどうか。
		/// <para>
		/// trueを設定した場合、<see cref="CustomDataGrid"/>はデータソースの"PRG_UPDATE_DATETIME"列の値を取得して行ごとにビューステートに保持します。
		/// </para>
		/// <para>
		/// 保持された値は<see cref="GetUpdateDateTime"/>で取得することができます。
		/// </para>
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(false),
		Description("楽観ロックを使用します。")
		]
		public bool UsesUpdateDateTime
		{
			get
			{
				object o = ViewState["UsesUpdateDateTime"];
				return (o != null) ? (bool) o : false;
			}
			set {ViewState["UsesUpdateDateTime"] = value;}
		}

// 管理番号 K25899 From
		/// <summary>
		/// 画面表示時に前回のスクロールバーの位置を復元するかどうか。
		/// </summary>
		/// <remarks>
		/// このプロパティの値は保存されず、ポストバック毎に既定値及びaspx上での定義に基づいて初期化されます。
		/// </remarks>
		public virtual bool RestoreScrollPosition
		{
			get
			{
				return restoreScrollPosition;
			}
			set
			{
				restoreScrollPosition = value;
			}
		}
// 管理番号 K25899 To

// 管理番号 K25902 From
		/// <summary>
		/// データグリッドがダウンロード機能を使用するかどうか。
		/// </summary>
		public bool UseDownLoad
		{
			get
			{
				object o = ViewState["__UseDownLoad"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["__UseDownLoad"] = value;}
		}

		/// <summary>
		/// <see cref="CustomDataGrid"/>がダウンロード機能の使用条件を満たしているかどうか。
		/// </summary>
		public bool EnableDownLoad
		{
			get
			{
				return ((PageBase)Page).IsUseDataGridDownLoad && UseDownLoad && AllowPaging;
			}
		}

		/// <summary>
		/// ダウンロード実行指示用隠し項目のID。
		/// </summary>
		protected string DownLoadExecFlgId
		{
			get
			{
				return "__" + this.ClientID + "_DownLoadExecFlg";
			}
		}

		/// <summary>
		/// データソースをセッションに保存した時間。
		/// </summary>
		private DateTime DataSourceStoredTime
		{
			get; set;
		}
// 管理番号 K25902 To
// 管理番号K26528 From
		/// <summary>
		/// スクロール位置を保持する隠しフィールドのID
		/// </summary>
		protected string ScrollPositionKey { get; private set; }

		/// <summary>
		/// スクロール用div要素に与えるID
		/// </summary>
		protected string ScrollerId { get; private set; }

		/// <summary>
		/// ポストバック時に前回のスクロール位置を復帰するか
		/// </summary>
		protected bool MaintainScrollBar
		{
			get
			{
				var appSettingValue = ConfigurationManager.AppSettings.Get("MaintainDataGridScrollPositionOnPostBack");
				return string.Compare(appSettingValue, bool.TrueString, true) == 0;
			}
		}
// 管理番号K26528 To
		#endregion

// 管理番号K26528 From
		public CustomDataGrid()
		{
			// コンストラクタにてパーツごとのCSSクラスやレイアウトの既定値を定義する
			this.CssClass = "grid_container bd_table_bg";
			HeaderStyle.CssClass = "header bd_item_ttl_bg";
			PagerStyle.CssClass = "pager bd_td_bg_1";
			ItemStyle.CssClass = "item bd_item_val_bg_1";
			AlternatingItemStyle.CssClass = "alternating_item bd_item_val_bg_2";
			FooterStyle.CssClass = "footer";

			PagerStyle.Position = PagerPosition.TopAndBottom;
			PagerStyle.Mode = PagerMode.NumericPages;

			AllegroControl.RegisterControlTypeAttribute(this);
		}
// 管理番号K26528 To

		#region Methods
// 管理番号K26528 From
		/// <summary>
		/// 新しいコントロール スタイルを作成します。
		/// </summary>
		/// <returns>
		/// 新しいスタイルを表す<see cref="Style" />。
		/// </returns>
		// 【参考情報】CreateControlStyleをoverrideすることでCellSpacingの内部値が-1となる。
		// これによってborder-collapseプロパティが出力されるのを防いでいる。
		protected override Style CreateControlStyle()
		{
			// rules属性を出力させないようにするため、GridLines.Noneを指定する
			return new TableStyle { GridLines = GridLines.None };
		}
// 管理番号K26528 To

		/// <summary>
		/// 指定した行の楽観ロック用プログラム更新日時を取得します。
		/// </summary>
		/// <param name="itemIndex">
		/// 行番号
		/// </param>
		/// <returns>
		/// 指定した行の楽観ロック用プログラム更新日時（"PRG_UPDATE_DATETIME"列の値）。
		/// 取得できなかった場合、<see cref="DateTime.MaxValue"/>。
		/// </returns>
		public DateTime GetUpdateDateTime(int itemIndex)
		{
			object o = ViewState["UpdateDateTime" + itemIndex.ToString()];
			return (o != null) ? ((StateBagDateTime) o).ToDateTime() : DateTime.MaxValue;
		}

		/// <summary>
		/// <see cref="DataGrid.ItemCreated"/>イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="DataGridItemEventArgs"/>オブジェクト。
		/// </param>
		protected override void OnItemCreated(DataGridItemEventArgs e)
		{
			base.OnItemCreated (e);
// 管理番号K26528 From
			// XhtmlConformanceModeの影響を受けずに後方互換を維持するため、旧来のID付与方法を内部で実装する。
			e.Item.ID = idPrefix + (++idSeqNo).ToString(NumberFormatInfo.InvariantInfo);

			// 選択行・編集行のCSSクラスは基準となる行のCSSクラスをコピーしてから設定する
			if (e.Item.ItemType == ListItemType.SelectedItem
				|| e.Item.ItemType == ListItemType.EditItem)
			{
				e.Item.CssClass = e.Item.ItemIndex % 2 != 0
						? this.AlternatingItemStyle.CssClass
						: this.ItemStyle.CssClass
						;

				if (e.Item.ItemIndex == this.SelectedIndex)
				{
					var selectedItemCssClass = string.IsNullOrEmpty(this.SelectedItemStyle.CssClass)
						? "selected_item "
						: this.SelectedItemStyle.CssClass + " "
						;
					e.Item.CssClass = selectedItemCssClass + e.Item.CssClass;
				}

				if (e.Item.ItemIndex == this.EditItemIndex)
				{
					var editItemCssClass = string.IsNullOrEmpty(this.EditItemStyle.CssClass)
						? "edit_item "
						: this.EditItemStyle.CssClass + " "
						;
					e.Item.CssClass = editItemCssClass + e.Item.CssClass;
				}
			}
// 管理番号K26528 To
			if (e.Item.ItemType == ListItemType.Pager)
			{
				LinkButton prev = new LinkButton();
				LinkButton next = new LinkButton();
				prev.Text = "&lt;";
				next.Text = "&gt;";
				prev.EnableViewState = false;
				next.EnableViewState = false;
				prev.Click += new EventHandler(previousLink_Click);
				next.Click += new EventHandler(nextLink_Click);
				prev.PreRender += new EventHandler(previousLink_PreRender);
				next.PreRender += new EventHandler(nextLink_PreRender);
				e.Item.Cells[0].Controls.Add(prev);
				e.Item.Cells[0].Controls.Add(next);
// 管理番号 K25902 From
				if (EnableDownLoad)
				{
					var btn = CreateDownloadButton();
					e.Item.Cells[0].Controls.Add(new LiteralControl("&nbsp;"));
					e.Item.Cells[0].Controls.Add(btn);
				}
// 管理番号 K25902 To
// 管理番号K26528 From
//				int intColumnCount = this.Columns.Count;
//				e.Item.Cells[0].Attributes.Add("colspan", intColumnCount.ToString());
// 管理番号K26528 To
			}
		}

		/// <summary>
		/// <see cref="DataGrid.ItemDataBound"/>イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="DataGridItemEventArgs"/>オブジェクト。
		/// </param>
		protected override void OnItemDataBound(DataGridItemEventArgs e)
		{
			base.OnItemDataBound (e);
			switch (e.Item.ItemType)
			{
				case ListItemType.Item:
				case ListItemType.AlternatingItem:
				case ListItemType.EditItem:
				case ListItemType.SelectedItem:
					if (UsesUpdateDateTime && e.Item.DataItem is DataRowView)
					{
						DataRowView drv = (DataRowView) e.Item.DataItem;
						DateTime updateDateTime = (DateTime) drv["PRG_UPDATE_DATETIME"];
						ViewState["UpdateDateTime" + e.Item.ItemIndex.ToString()] = new StateBagDateTime(updateDateTime);
					}
					break;
			}
		}

// 管理番号 K25902 From
		/// <summary>
		/// <see cref="Control.DataBinding"/>イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnDataBinding(EventArgs e)
		{
// 管理番号K26528 From
			// コントロールの削除を明示的に行う。
			// 基底クラスのOnDataBinding内でもコントロールの削除は行われるが、
			// 削除処理中にOnItemCreatedが発火する場合があるため、基底クラスより先に削除を行っておく。
			this.Controls.Clear();
			// バインドによってデータグリッドを再生成するため、内部連番を初期化する。
			idSeqNo = 0;
// 管理番号K26528 To
			// ダウンロード使用条件を満たし、ダウンロード指示があった場合
			if (EnableDownLoad && Page.Request.Form[DownLoadExecFlgId] == "1")
			{
				DataTable src = GetDataSourceAsTable();
				// DataTableに変換できた場合はセッションに登録
				if (src != null)
				{
					// データソースを登録したタイムスタンプを記録
					DataSourceStoredTime = DateTime.Now;

					// データソースキーを生成
					string key = CreateDataSourceKey(
									((PageBase)Page).PageID
									, this.ID
									, DataSourceStoredTime.Ticks.ToString()
								);
					Page.Session.Add(key, src);
				}
			}
			base.OnDataBinding(e);
		}
// 管理番号 K25902 To

// 管理番号 K25899 From
		/// <summary>
		/// <see cref="Control.PreRender"/>イベントを発生させます。/>
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
// 管理番号K26528 From
//			// スクロールバーの維持
//			string maintainScrollBar = ConfigurationManager.AppSettings.Get("MaintainDataGridScrollPositionOnPostBack");
//			if (string.Compare(maintainScrollBar, bool.TrueString, true) == 0 && RestoreScrollPosition)
//			{

			this.ScrollPositionKey = "__" + this.ID + "_ScrollPosition";
			this.ScrollerId = "__" + this.ID + "_Scroller";

			// web.configに設定されたスクロールバー維持フラグと、データグリッドの復元フラグが共にTrueならスクリプトを出力
			if (this.MaintainScrollBar && this.RestoreScrollPosition)
			{
				// 前回のスクロールバー位置
				var topPosition = Page.Request.Form[this.ScrollPositionKey];
// 管理番号K27230 From
//				if (!string.IsNullOrEmpty(topPosition) && topPosition != "0")
				if (!string.IsNullOrEmpty(topPosition) && topPosition != "0" && int.TryParse(topPosition, out int pos))
// 管理番号K27230 To
				{
					// scrollIntoViewを置き換えるscriptタグをデータグリッド本体の直後に出力
					this.Page.ClientScript.RegisterClientScriptBlock(
						this.GetType(),
						this.ID + "__ScrollIntoViewRewrite",
						this.GetScrollIntoViewRewriteScript(),
						true);

					// 取得位置復元用スクリプト実行
					((PageBase)Page).ImmediateStartupScript.RegisterScript(
						this.GetType(),
						this.ID + "__RestoreDataGridScrollPosition",
						GetScrollPositionRestoreScript(this.ScrollerId, topPosition)
						);
				}
// 管理番号K26528 To

				// scrollIntoView代替関数の定義を出力
				string key = "NewScrollIntoViewFunction";
				if (!Page.ClientScript.IsStartupScriptRegistered(key))
				{
					Page.ClientScript.RegisterClientScriptBlock(this.GetType(), key, GetNewScrollIntoViewDefineScript(), true);
				}
			}
// 管理番号K26528 From
			if (EnableDownLoad)
			{
				// ダウンロード実行指示用隠し項目
				Page.ClientScript.RegisterHiddenField(DownLoadExecFlgId, "0");

				// 次のレンダリング時にダウンロードを実行する場合
				if (Page.Request.Form[DownLoadExecFlgId] == "1")
				{
					string query = "?targetPageId=" + HttpUtility.UrlEncode(((PageBase)Page).PageID)
								+ "&datagridId="   + HttpUtility.UrlEncode(ID)
								+ "&timeStamp="    + HttpUtility.UrlEncode(DataSourceStoredTime.Ticks.ToString());

					((PageBase)Page).ControlStartupScript.RegisterScript(GetType(), "DownLoadFrame" + ID, "CM_openDownLoadPage('CM_MS_99_S01', '" + query + "')");
				}
			}
// 管理番号K26528 To
		}
		// 管理番号 K25899 To

// 管理番号K26528 From
		/// <summary>
		/// コントロールの内容を出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
			// コントロールが描画されない場合、以下の処理はスキップする
			if (this.Controls.Count > 0)
			{
				var childTable = (Table)this.Controls[0];
				// 表示されている列の合計をページャのcolspanに設定する
				// すべてのコントロールが決定し、描画が行われる直前に再設定を行う
				var colspan = this.Columns.Cast<DataGridColumn>().Count(column => column.Visible);
				if (colspan > 1)
				{
					foreach (var item in childTable.Rows.Cast<DataGridItem>().Where(x => x.ItemType == ListItemType.Pager))
					{
						item.Cells[0].ColumnSpan = colspan;
					}
				}
			}
			base.RenderContents(writer);
		}
// 管理番号K26528 To

		/// <summary>
		/// コントロールを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
// 管理番号K26528 From
//// 管理番号 K25899 From
//			string scrollPosition = "__" + this.ID + "_ScrollPosition";
//			string scrollerId = "__" + this.ID + "_Scroller";
//			bool maintainScrollBar = string.Compare(
//										  ConfigurationManager.AppSettings.Get("MaintainDataGridScrollPositionOnPostBack")
//										, bool.TrueString, true
//									) == 0;
//// 管理番号 K25899 To
			var scrollPosition = this.ScrollPositionKey;
			var scrollerId = this.ScrollerId;
			var maintainScrollBar = this.MaintainScrollBar;
// 管理番号K26528 To

			if (MaxHeight != Unit.Empty && ScrollItemsCount <= Items.Count)
			{
// 管理番号 K25899 From
				// スクロールバーの位置を保持する為の隠し項目の定義
				writer.AddAttribute(HtmlTextWriterAttribute.Type, "hidden");
				writer.AddAttribute(HtmlTextWriterAttribute.Name, scrollPosition);
				writer.AddAttribute(HtmlTextWriterAttribute.Id, scrollPosition);
				writer.AddAttribute(HtmlTextWriterAttribute.Value, "0");
				writer.RenderBeginTag(HtmlTextWriterTag.Input);
				writer.RenderEndTag();

				// スクロールバー表示用div
				writer.AddAttribute(HtmlTextWriterAttribute.Id, scrollerId);
				if(maintainScrollBar)
				{
					writer.AddAttribute("onscroll", "document.getElementById('" + scrollPosition + "').value = this.scrollTop;");
				}
// 管理番号 K25899 To
				writer.AddStyleAttribute(HtmlTextWriterStyle.Height, MaxHeight.ToString());
// 管理番号K26528 From
//				if ((Width != Unit.Empty) && (Width.Type != UnitType.Percentage))
//				{
//					writer.AddStyleAttribute(HtmlTextWriterStyle.Width, Width.ToString());
//				}
				if (!this.Width.IsEmpty && (this.Width.Type != UnitType.Percentage))
				{
					// div要素に対してスクロールバーの幅を考慮する
					var width = "calc(" + this.Width + " + " + CustomDataGrid.ScrollBarWidth + ")";
					writer.AddStyleAttribute(HtmlTextWriterStyle.Width, width);
				}
// 管理番号K26528 To
				writer.AddStyleAttribute("overflow-y", "auto");
				writer.RenderBeginTag(HtmlTextWriterTag.Div);
			}

			base.Render(writer);

			if (MaxHeight != Unit.Empty && ScrollItemsCount <= Items.Count)
			{
				writer.RenderEndTag();
			}

// 管理番号K26528 From
//// 管理番号 K25899 From
//			// スクロールバーの維持
//			if (maintainScrollBar && RestoreScrollPosition)
//			{
//				// web.configに設定されたスクロールバー維持フラグと、データグリッドの復元フラグが共にTrueならスクリプトを出力
//
//				// 前回のスクロールバー位置
//				string topPosition = Page.Request.Form[scrollPosition];
//				if (!string.IsNullOrEmpty(topPosition) && topPosition != "0")
//				{
//					// scrollIntoViewを置き換えるscriptタグをデータグリッド本体の直後に出力
//					writer.AddAttribute(HtmlTextWriterAttribute.Type, "text/javascript");
//					writer.RenderBeginTag(HtmlTextWriterTag.Script);
//					writer.WriteLine(GetScrollIntoViewRewriteScript());
//					writer.RenderEndTag();
//
//					// 取得位置復元用スクリプト実行
//					Page.ClientScript.RegisterStartupScript(this.GetType(), this.ID + "__RestoreDataGridScrollPosition"
//						, GetScrollPositionRestoreScript(scrollerId, topPosition), true);
//				}
//			}
//// 管理番号 K25899 To
//// 管理番号 K25902 From
//			if (EnableDownLoad)
//			{
//				// ダウンロード実行指示用隠し項目
//				writer.AddAttribute(HtmlTextWriterAttribute.Id   , DownLoadExecFlgId);
//				writer.AddAttribute(HtmlTextWriterAttribute.Name , DownLoadExecFlgId);
//				writer.AddAttribute(HtmlTextWriterAttribute.Type , "hidden");
//				writer.AddAttribute(HtmlTextWriterAttribute.Value, "0");
//				writer.RenderBeginTag(HtmlTextWriterTag.Input);
//				writer.RenderEndTag();
//
//				// ダウンロード実行用隠しフレーム
//				if (Page.Request.Form[DownLoadExecFlgId] == "1")
//				{
//					string requestUrl = "CM_MS_99_S01.aspx"
//									  + "?targetPageId=" + HttpUtility.UrlEncode(((PageBase)Page).PageID)
//									  + "&datagridId="   + HttpUtility.UrlEncode(ID)
//									  + "&timeStamp="    + HttpUtility.UrlEncode(DataSourceStoredTime.Ticks.ToString());
//					writer.AddAttribute(HtmlTextWriterAttribute.Src, requestUrl);
//					writer.AddStyleAttribute(HtmlTextWriterStyle.Display, "none");
//					writer.RenderBeginTag(HtmlTextWriterTag.Iframe);
//					writer.RenderEndTag();
//				}
//			}
//// 管理番号 K25902 To
// 管理番号K26528 To
		}

		private void previousLink_Click(object sender, EventArgs e)
		{
			OnPageIndexChanged(new DataGridPageChangedEventArgs(sender, CurrentPageIndex - ((0 < CurrentPageIndex) ? 1 : 0)));
		}
		private void nextLink_Click(object sender, EventArgs e)
		{
			OnPageIndexChanged(new DataGridPageChangedEventArgs(sender, CurrentPageIndex + ((CurrentPageIndex < PageCount - 1) ? 1 : 0)));
		}
		private void previousLink_PreRender(object sender, EventArgs e)
		{
			LinkButton prev = (LinkButton) sender;
			StringBuilder scriptKey = new StringBuilder(UniqueID, UniqueID.Length + 16).Append("_PrevPagerScript");
// 管理番号K26528 From
//			if (!Page.ClientScript.IsStartupScriptRegistered(scriptKey.ToString()))
//			{
//				StringBuilder script = new StringBuilder("<script type=\"text/javascript\">\r\nfunction show", 128);
//				script.Append(ID);
//				script.Append("PrevPage() {\r\n\t");
//				script.Append(Page.ClientScript.GetPostBackEventReference(prev, string.Empty));
//				script.Append(";\r\n}\r\n</script>");
//				Page.ClientScript.RegisterStartupScript(this.GetType(), scriptKey.ToString(), script.ToString());
//			}
			if (!Page.ClientScript.IsClientScriptBlockRegistered(scriptKey.ToString()))
			{
				var script = new StringBuilder()
					.Append("function show").Append(ID).AppendLine("PrevPage() {")
					.Append("	").Append(Page.ClientScript.GetPostBackEventReference(prev, string.Empty)).AppendLine(";")
					.Append("}").AppendLine();
				Page.ClientScript.RegisterClientScriptBlock(this.GetType(), scriptKey.ToString(), script.ToString(), true);
			}
// 管理番号K26528 To
			prev.Visible = false;
		}
		private void nextLink_PreRender(object sender, EventArgs e)
		{
			LinkButton next = (LinkButton) sender;
			StringBuilder scriptKey = new StringBuilder(UniqueID, UniqueID.Length + 16).Append("_NextPagerScript");
// 管理番号K26528 From
//			if (!Page.ClientScript.IsStartupScriptRegistered(scriptKey.ToString()))
//			{
//				StringBuilder script = new StringBuilder("<script type=\"text/javascript\">\r\nfunction show", 128);
//				script.Append(ID);
//				script.Append("NextPage() {\r\n\t");
//				script.Append(Page.ClientScript.GetPostBackEventReference(next, string.Empty));
//				script.Append(";\r\n}\r\n</script>");
//				Page.ClientScript.RegisterStartupScript(this.GetType(), scriptKey.ToString(), script.ToString());
//			}
			if (!Page.ClientScript.IsClientScriptBlockRegistered(scriptKey.ToString()))
			{
				var script = new StringBuilder()
					.Append("function show").Append(ID).AppendLine("NextPage() {")
					.Append("	").Append(Page.ClientScript.GetPostBackEventReference(next, string.Empty)).AppendLine(";")
					.Append("}").AppendLine();
				Page.ClientScript.RegisterClientScriptBlock(this.GetType(), scriptKey.ToString(), script.ToString(), true);
			}
// 管理番号K26528 To
			next.Visible = false;
		}
// 管理番号 K25902 From
		/// <summary>
		/// ダウンロードボタンクリック時の処理です。（<see cref="DataGrid.OnPageIndexChanged"/>を呼び出します）。
		/// </summary>
		/// <param name="sender">
		/// イベントのソース。
		/// </param>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected void DownloadButton_Click(object sender, EventArgs e)
		{
			// 現在と同一ページにページ変更
			OnPageIndexChanged(new DataGridPageChangedEventArgs(sender, CurrentPageIndex));
		}

		/// <summary>
		/// ダウンロードボタンを作成します。
		/// </summary>
		/// <returns>
		/// 作成した<see cref="StyledButton"/>。
		/// </returns>
		protected StyledButton CreateDownloadButton()
		{

			// ボタン押下時に起動するファンクションを出力
			string scriptKey = UniqueID + "__DownLoadScript";
			string clickFunctionName = "__DownLoad" + ID;
// 管理番号K26528 From
//			if (!Page.ClientScript.IsStartupScriptRegistered(scriptKey))
//			{
//				StringBuilder script = new StringBuilder();
//				script.Append("<script type=\"text/javascript\">\r\nfunction ").Append(clickFunctionName).Append("() {\r\n");
//				script.Append("document.getElementById('").Append(DownLoadExecFlgId).Append("').value = '1';");
//				script.Append(";\r\n}\r\n</script>");
//				Page.ClientScript.RegisterClientScriptBlock(this.GetType(), scriptKey, script.ToString());
//			}
			if (!Page.ClientScript.IsClientScriptBlockRegistered(scriptKey))
			{
				var script = new StringBuilder()
					.Append("function ").Append(clickFunctionName).AppendLine("() {")
					.Append("	document.getElementById('").Append(DownLoadExecFlgId).AppendLine("').value = '1';")
					.Append("}").AppendLine();
				Page.ClientScript.RegisterClientScriptBlock(this.GetType(), scriptKey.ToString(), script.ToString(), true);
			}
// 管理番号K26528 To

			// ボタン生成
			var btn = new StyledButton();
// 管理番号K26528 From
			AllegroControl.RegisterControlSubtypeAttribute(btn, "DownloadButton");
// 管理番号K26528 To
			// img/CM_b3_download.gif
			btn.ImageUrl = "img/CM_b3_download.gif";
			btn.CssClass = "image";
			// CSVをダウンロードします。
// 管理番号K26528 From
//			btn.AlternateText = MultiLanguage.Get("CM_CS003951");
			btn.ToolTip = MultiLanguage.Get("CM_CS003951");
// 管理番号K26528 To
			btn.Enabled = true;
			btn.Visible = true;
// 管理番号K26528 From
//			btn.ImageAlign = ImageAlign.AbsMiddle;
// 管理番号K26528 To
			btn.ClientClickScript = clickFunctionName;
			btn.Click += DownloadButton_Click;

			// F1,F11,F12は元のファンクションを設定
			btn.ClientF01Script = "functionKeyDownFunctions[0]";
			btn.ClientF11Script = "functionKeyDownFunctions[10]";
			btn.ClientF12Script = "functionKeyDownFunctions[11]";

			return btn;
		}

		/// <summary>
		/// DataSourceをDataTableに変換して取得します。
		/// </summary>
		/// <returns>DataTableに変換したDataSource、DataTableに変換できない場合はnull</returns>
		private DataTable GetDataSourceAsTable()
		{
			DataTable source = null;
			if (DataSource == null)
			{
				source = null;
			}
			else if (DataSource is DataTable)
			{
				source = (DataTable)DataSource;
			}
			else if (DataSource is DataView)
			{
				source = ((DataView)DataSource).ToTable();
			}
			return source;
		}

		/// <summary>
		/// データソースをセッションに登録する際のセッションキーを作成します。
		/// </summary>
		/// <param name="pageId">
		/// ページID
		/// </param>
		/// <param name="datagridId">
		/// <see cref="CustomDataGrid"/>の<see cref="Control.ID"/>。
		/// </param>
		/// <param name="timestamp">
		/// <see cref="DataSourceStoredTime"/>の<see cref="DateTime.Ticks"/>。
		/// </param>
		/// <returns>
		/// データソースをセッションに登録する際のセッションキー。
		/// </returns>
		public static string CreateDataSourceKey(string pageId, string datagridId, string timestamp)
		{
			return pageId + "_" + datagridId + "_" + timestamp+ "_GridExportData";
		}
// 管理番号 K25902 To

// 管理番号 K25899 From
		/// <summary>
		/// データグリッドをスクロールさせるための、scrollIntoViewの代替関数の定義を取得します。
		/// </summary>
		/// <returns>scrollIntoViewの代替関数の定義スクリプト</returns>
		private string GetNewScrollIntoViewDefineScript()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("function newScrollIntoView(flg) {");
			sb.AppendLine("	if (!flg) {");
			sb.AppendLine("		this.disallowMaintainScrollPosition = true;");
			sb.AppendLine("	}");
			sb.AppendLine("	this.oldScrollIntoView(flg);");
			sb.AppendLine("}");
			return sb.ToString();
		}

		/// <summary>
		/// scrollIntoViewの書き換えを行うスクリプトを取得します。
		/// </summary>
		/// <returns>scrollIntoViewの書き換えを行うスクリプト</returns>
		private string GetScrollIntoViewRewriteScript()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("if(document.getElementById(\"" + ClientID +  "\")) {");
			sb.AppendLine("	document.getElementById(\"" + ClientID +  "\").oldScrollIntoView = document.getElementById(\"" + ClientID + "\").scrollIntoView;");
			sb.AppendLine("	document.getElementById(\"" + ClientID +  "\").scrollIntoView = newScrollIntoView;");
			sb.AppendLine("}");
			return sb.ToString();
		}

		/// <summary>
		/// スクロールバーの位置を復元するスクリプトを出力します。
		/// </summary>
		/// <param name="scrollerId">スクロールバーを表示させる要素のId</param>
		/// <param name="position">スクロールバーの位置</param>
		/// <returns>スクロールバーの位置を復元するスクリプト</returns>
		private string GetScrollPositionRestoreScript(string scrollerId, string position)
		{
// 管理番号K26528 From
//			StringBuilder sb = new StringBuilder();
//			sb.AppendLine("window.attachEvent('onload', ");
//			sb.AppendLine("	function(){");
//			sb.AppendLine("		var disAllow = document.getElementById(\"" + ClientID + "\").disallowMaintainScrollPosition;");
//			sb.AppendLine("		if (!disAllow) {");
//			sb.AppendLine("			document.getElementById('" + scrollerId + "').scrollTop = " + position + ";");
//			sb.AppendLine("			document.activeElement.focus();");
//			sb.AppendLine("		}");
//			sb.AppendLine("	}");
//			sb.AppendLine(");");
//			return sb.ToString();
			// データグリッド、またはスクロールバーが存在する場合のみ、スクロールバーの位置を復元する
			return new StringBuilder()
				.AppendLine("(function() {")
				.AppendLine("	var dataGrid = document.getElementById('" + ClientID + "');")
				.AppendLine("	if (dataGrid != null && !dataGrid.disallowMaintainScrollPosition) {")
				.AppendLine("		var scroller = document.getElementById('" + scrollerId + "');")
				.AppendLine("		if(scroller != null) {")
				.AppendLine("			scroller.scrollTop = " + position + ";")
				.AppendLine("			document.activeElement.focus && document.activeElement.focus();")
				.AppendLine("		}")
				.AppendLine("	}")
				.AppendLine("})();")
				.ToString()
				;
// 管理番号K26528 To
		}
// 管理番号 K25899 To
		#endregion
	}
}
