// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : CustomItemPanel.cs
// 機能名      : 汎用項目パネル
// Version     : 3.1.0
// Last Update : 2020/06/30
// Copyright (c) 2004-2020 Grandit Corp. All Rights Reserved.
//
// 管理番号K27057 2019/08/15 汎用項目追加
// 3.1.0 2020/06/30

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// 汎用項目パネル
	/// </summary>
	/// <remarks>
	/// <b>CustomItemPanel</b> は GRANDITの汎用項目を表示するパネルです。
	/// </remarks>
	[
	ToolboxData("<{0}:CustomItemPanel runat=server></{0}:CustomItemPanel>")
	]
	public class CustomItemPanel : Table
	{
		private readonly string[] CustomItemDetailType =
		{
			"inputedit",
			"inputnew",
			"listdetail",
			"detail",
			"inputdetailcommon",
			"reportdetail"
		};

		private int tableDataCount = 0;
		private int columnCount = 2;
		private string titleWidthString = "";
		private int titleWidth = 10;
		private int inputAreaCharacter = 100;
		private List<ControlRelation> controlRelationList = new List<ControlRelation>();
		private List<ControlRelation> controlHiddenList = new List<ControlRelation>();
		private bool enableFlg = true;
		private CustomTextBox tb_0;
		private CustomItemInfo info = null;
		private int title1lineCharacter = 10;

		/// <summary>
		/// 個別画面から委譲されるPageBaseのFocusControl
		/// </summary>
		/// <param name="str">
		/// コントロールID
		/// </param>
		public delegate void FocusControl(string str);

		/// <summary>
		/// CustomItem.csから委譲されるGetShortName、TextChangeで使用します。
		/// </summary>
		/// <param name="code">
		/// 変更されたTextBoxの値
		/// </param>
		/// <param name="refTable">
		/// 名称取得テーブル
		/// </param>
		/// <param name="validFlg">
		/// 有効無効フラグ
		/// </param>
		/// <param name="basisDate">
		/// 基準日
		/// </param>
		/// <returns>略名を戻します。</returns>
		public delegate string GetShortName(string code, string refTable, bool validFlg, string basisDate);

		/// <summary>
		/// CustomItem.csから連携される汎用項目、汎用機能別設定、汎用項目値設定、ページの情報と委譲されるメソッドの情報
		/// </summary>
		/// <param name="CustomItem">
		/// 汎用項目、汎用機能別設定
		/// </param>
		public class CustomItemInfo
		{
			/// <summary>
			/// 汎用項目、汎用機能別設定
			/// </summary>
			public DataTable CustomItem;
			/// <summary>
			/// 汎用項目値設定
			/// </summary>
			public DataTable ValueSetting;
			/// <summary>
			/// ページの汎用項目開閉フラグ
			/// </summary>
			public bool OpenMode;
			/// <summary>
			/// PageBaseのフォーカスコントロールメソッド
			/// </summary>
			public FocusControl FocusControl;
			/// <summary>
			/// CustomItem.csのGetShortNameのメソッド
			/// </summary>
			public GetShortName GetShortName;
		}

		/// <summary>
		/// 名称取得テーブルの種類か、表示しているラベルの選択
		/// </summary>
		public enum ControlType
		{
			RefTable,
			LabelText
		}

		/// <summary>
		/// 汎用項目パネル全体の活性、非活性
		/// </summary>
		public bool Enable
		{
			get
			{
				return enableFlg;
			}

			set
			{
				enableFlg = value;
				foreach (ControlRelation controlRelation in controlRelationList)
				{
					bool enabled = controlRelation.Enabled ? value : false;
					if (controlRelation.TextBox != null)
					{
						controlRelation.TextBox.Enabled = enabled;
						if (!enabled && 0 < controlRelation.TextBox.Text.Length)
						{
							controlRelation.TextBox.ToolTip = controlRelation.TextBox.Text;
						}
						else
						{
							controlRelation.TextBox.ToolTip = "";
						}
						if (controlRelation.FromTo)
						{
							controlRelation.TextBoxTo.Enabled = enabled;
							if (!enabled && 0 < controlRelation.TextBoxTo.Text.Length)
							{
								controlRelation.TextBoxTo.ToolTip = controlRelation.TextBoxTo.Text;
							}
							else
							{
								controlRelation.TextBoxTo.ToolTip = "";
							}
						}
					}
					else if (controlRelation.NumberBox != null)
					{
						controlRelation.NumberBox.Enabled = enabled;
						if (controlRelation.FromTo)
						{
							controlRelation.NumberBoxTo.Enabled = enabled;
						}
					}
					else if (controlRelation.DateBox != null)
					{
						controlRelation.DateBox.Enabled = enabled;
						if (controlRelation.FromTo)
						{
							controlRelation.DateBoxTo.Enabled = enabled;
						}
					}
					else if (controlRelation.DropDownList != null)
					{
						controlRelation.DropDownList.Enabled = enabled;
						if (!enabled && controlRelation.DropDownList.SelectedItem != null && 0 < controlRelation.DropDownList.SelectedItem.Text.Length)
						{
							controlRelation.DropDownList.Attributes.Add("Title",controlRelation.DropDownList.SelectedItem.Text);
						}
						else
						{
							controlRelation.DropDownList.Attributes.Remove("Title");
						}
					}
				}
			}
		}

		/// <summary>
		/// 汎用項目パネル全体の無効、有効
		/// </summary>
		public override bool Visible
		{
			set
			{
				foreach (ControlRelation controlRelation in controlRelationList)
				{
					if (controlRelation.TextBox != null)
					{
						controlRelation.TextBox.Visible = value;
					}
					else if (controlRelation.NumberBox != null)
					{
						controlRelation.NumberBox.Visible = value;
					}
					else if (controlRelation.DateBox != null)
					{
						controlRelation.DateBox.Visible = value;
					}
					else if (controlRelation.DropDownList != null)
					{
						controlRelation.DropDownList.Visible = value;
					}
				}
			}
		}

		private string PageID
		{
			get
			{
				string pageID = this.Page.Request.QueryString.Get("PageID");
				return string.IsNullOrEmpty(pageID) ? ASPXFileCode : pageID.ToUpper();
			}
		}

		private string ASPXFileCode
		{
			get
			{
				string url = this.Page.Request.CurrentExecutionFilePath;
				int slashIndex = url.LastIndexOf('/');
				slashIndex++;
				return url.Substring(slashIndex, url.Length - slashIndex - 5).ToUpper();
			}
		}

		/// <summary>
		/// 汎用項目パネル中の項目名のリストを取得します。
		/// </summary>
		/// <param name="useMaster">
		/// false: マスタ利用に関係なく項目名を取得します。 true: マスタ利用する項目を取得します。
		/// </param>
		/// <returns>項目名のリストを戻します。</returns>
		public List<string> GetList(bool useMaster = false)
		{
			return GetList(controlRelationList, useMaster);
		}

		/// <summary>
		/// 汎用項目パネル中のマスタ利用を使用しない、共通項目名のリストを取得します。
		/// </summary>
		/// <returns>項目名のリストを戻します。</returns>
		public List<string> GetNoMasterUseList()
		{
			return GetNoMasterUseList(controlRelationList);
		}

		/// <summary>
		/// 汎用項目パネル中の非表示にしている汎用項目のリストを取得します。
		/// </summary>
		/// <param name="useMaster">
		/// false: マスタ利用に関係なく項目名を取得します。 true: マスタ利用する項目を取得します。
		/// </param>
		/// <returns>非表示にしている汎用項目のリストを戻します。</returns>
		public List<string> GetHiddenList(bool useMaster = false)
		{
			return GetList(controlHiddenList, useMaster);
		}

		/// <summary>
		/// 汎用項目パネル中の非表示にしているマスタ利用を使用しない、共通項目名のリストを取得します。
		/// </summary>
		/// <returns>非表示にしている汎用項目のリストを戻します。</returns>
		public List<string> GetHiddenNoMasterUseList()
		{
			return GetNoMasterUseList(controlHiddenList);
		}

		/// <summary>
		/// 汎用項目パネルが持つ子のカスタムコントロールのTo(至)を取得します。
		/// </summary>
		/// <param name="columnName">
		/// 汎用項目名を指定します。
		/// </param>
		/// <returns>カスタムコントロールを戻します。</returns>
		public object GetControl(string columnName)
		{
			ControlRelation cr = controlRelationList.Find(m => m.ColumnName == columnName);
			string type = cr.ControlType;
			object obj = null;
			switch (type)
			{
				case "1":
					obj = cr.TextBoxTo;
					break;
				case "2":
					obj = cr.NumberBoxTo;
					break;
				case "3":
					obj = cr.DateBoxTo;
					break;
			}
			return obj;
		}

		/// <summary>
		/// 汎用項目パネルが持つ子のカスタムコントロールを取得します。
		/// </summary>
		/// <param name="columnName">
		/// 汎用項目名を指定します。
		/// </param>
		/// <param name="type">
		/// カスタムコントロールのタイプを戻します。
		/// </param>
		/// <returns>カスタムコントロールを戻します。typeによってCASTしてください。</returns>
		public object GetControl(string columnName, out string type)
		{
			ControlRelation cr = controlRelationList.Find(m => m.ColumnName == columnName);
			if (cr == null)
			{
				cr = controlHiddenList.Find(m => m.ColumnName == columnName);
			}
			type = cr.ControlType;
			object obj = null;
			switch (type)
			{
				case "1":
					obj = cr.TextBox;
					break;
				case "2":
					obj = cr.NumberBox;
					break;
				case "3":
					obj = cr.DateBox;
					break;
				case "4":
					obj = cr.DropDownList;
					break;
				case "0":
					obj = cr.Hidden;
					break;
				default:
					break;
			}
			return obj;
		}

		/// <summary>
		/// 名称取得テーブルの種類か、表示しているラベルを取得します。
		/// </summary>
		/// <param name="columnName">
		/// 汎用項目名を指定します。
		/// </param>
		/// <param name="item">
		/// ControlType.RefTable:名称取得テーブル、ControlType.LabelText:ラベル
		/// </param>
		/// <returns>名称取得テーブルの種類か、表示しているラベル</returns>
		public string GetControl(string columnName, ControlType item)
		{
			ControlRelation cr = controlRelationList.Find(m => m.ColumnName == columnName);
			return item == ControlType.RefTable ? cr.RefTableType : cr.Label.Text;
		}

		/// <summary>
		/// 汎用項目カスタムパネルが持つ子の隠し項目のカスタムコントロールを取得します。
		/// </summary>
		/// <param name="columnName">
		/// 汎用項目名を指定します。
		/// </param>
		/// <returns>カスタムコントロールを戻します。</returns>
		public HiddenField GetHiddenControl(string columnName)
		{
			ControlRelation cr = controlHiddenList.Find(m => m.ColumnName == columnName);
			return cr.Hidden;
		}

		/// <summary>
		/// マスタ利用を取得します。
		/// </summary>
		/// <returns>マスタ利用</returns>
		public string GetMasterType()
		{
			return Attributes["MasterType"].ToLower();
		}

		/// <summary>
		/// 表示種別を取得します。
		/// </summary>
		/// <returns>表示種別</returns>
		public string GetDisplayType()
		{
			return Attributes["DisplayType"].ToLower();
		}

		/// <summary>
		/// 機能コードを取得します。
		/// </summary>
		/// <returns>機能コード</returns>
		public string GetFunctionCode()
		{
			return Attributes["FunctionCode"].ToLower();
		}

		/// <summary>
		/// 国内海外区分を取得します。
		/// </summary>
		/// <returns>国内海外区分</returns>
		public string GetOverseasType()
		{
			string overseas = Attributes["OverseasType"];
			return overseas == null ? "D" : overseas.ToLower();
		}

		/// <summary>
		/// 基準日を取得します。
		/// </summary>
		/// <param name="columnName">
		/// 汎用項目名を指定します。
		/// </param>
		/// <returns>基準日の文字列</returns>
		public string GetBasisDate(string columnName)
		{
			return GetBasisDate(controlRelationList.Find(m => m.ColumnName == columnName));
		}

		/// <summary>
		/// フォーカスの次項目を設定します。
		/// </summary>
		/// <param name="nextElement">
		/// フォーカスの次項目。
		/// </param>
		public void SetNextElement(string nextElement)
		{
			if (controlRelationList.Count == 0)
			{
				tb_0.SearchInMyParent = false;
				tb_0.NextControlID = nextElement;
				return;
			}
			ControlRelation controlRelation = controlRelationList[controlRelationList.Count - 1]; // 最後の要素
			if (controlRelation.FromTo)
			{
				if (controlRelation.TextBoxTo != null)
				{
					controlRelation.TextBoxTo.NextControlID = nextElement;
				}
				else if (controlRelation.NumberBoxTo != null)
				{
					controlRelation.NumberBoxTo.NextControlID = nextElement;
				}
				else if (controlRelation.DateBoxTo != null)
				{
					controlRelation.DateBoxTo.NextControlID = nextElement;
				}
			}
			else
			{
				if (controlRelation.TextBox != null)
				{
					controlRelation.TextBox.SearchInMyParent = false;
					controlRelation.TextBox.NextControlID = nextElement;
				}
				else if (controlRelation.NumberBox != null)
				{
					controlRelation.NumberBox.SearchInMyParent = false;
					controlRelation.NumberBox.NextControlID = nextElement;
				}
				else if (controlRelation.DateBox != null)
				{
					controlRelation.DateBox.SearchInMyParent = false;
					controlRelation.DateBox.NextControlID = nextElement;
				}
				else if (controlRelation.DropDownList != null)
				{
					controlRelation.DropDownList.SearchInMyParent = false;
					controlRelation.DropDownList.NextControlID = nextElement;
				}
			}
		}

		/// <summary>
		/// 名称取得時のイベントを追加します。
		/// </summary>
		/// <param name="eh">
		/// イベント受け取るハンドラ
		/// </param>
		public void SetEvent(System.EventHandler eh)
		{
			foreach (ControlRelation crl in controlRelationList)
			{
				if (crl.ControlType == "1" && crl.RefTableType != "0")
				{
					CustomTextBox tb = crl.TextBox;
					tb.TextChanged += eh;
				}
			}
		}

		/// <summary>
		/// 汎用項目パネルが持つ子のカスタムコントロールをクリアします。
		/// </summary>
		public void Reset()
		{
			foreach (ControlRelation controlRelation in controlRelationList)
			{
				if (controlRelation.TextBox != null)
				{
					controlRelation.TextBox.Text = "";
					if (controlRelation.Label != null)
					{
						controlRelation.Label.Text = "";
					}
				}
				else if (controlRelation.NumberBox != null)
				{
					controlRelation.NumberBox.Text = "";
				}
				else if (controlRelation.DateBox != null)
				{
					controlRelation.DateBox.Text = "";
				}
				else if (controlRelation.DropDownList != null)
				{
					controlRelation.DropDownList.Text = "";
				}
				if (controlRelation.TextBoxTo != null)
				{
					controlRelation.TextBoxTo.Text = "";
				}
				else if (controlRelation.NumberBoxTo != null)
				{
					controlRelation.NumberBoxTo.Text = "";
				}
				else if (controlRelation.DateBoxTo != null)
				{
					controlRelation.DateBoxTo.Text = "";
				}
			}
		}

		/// <summary>
		/// 略名を取得し、関連するラベルに設定します。
		/// </summary>
		/// <param name="textBox">
		/// コードを入力するテキストボックス
		/// </param>
		/// <param name="basisDate">
		/// 基準日
		/// </param>
		/// <param name="fromDBFlg">
		/// true:DBから取得 false:画面から入力
		/// </param>
		public void SetLabelText(CustomTextBox textBox, string basisDate = null, bool fromDBFlg = false)
		{
			var controlRelation = controlRelationList.Find(m => m.Id == textBox.ID);
			if (controlRelation.Label != null)
			{
				string shortname = info.GetShortName(textBox.Text, controlRelation.RefTableType, fromDBFlg ? true : controlRelation.ValidFlg, basisDate == null ? GetBasisDate(controlRelation) : basisDate);
				controlRelation.Label.Text = shortname;
			}
		}

		/// <summary>
		/// 汎用項目マスタのDB情報を設定する。
		/// </summary>
		/// <param name="info">
		/// 汎用項目マスタの情報
		/// </param>
		public void SetCustomItemInfo(CustomItemInfo info)
		{
			this.info = info;
		}

		#region Override Methods
		/// <summary>
		/// <see cref="OnInit"/>汎用項目パネル作成時に呼び出されます。OnChangeはOnInitで作成しないとイベントが受け取れません。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnInit(EventArgs e)
		{
			AllegroControl.RegisterControlTypeAttribute(this);
			// aspxで指定された属性を取得します。
			// 表示種別、タイトル域class、入力部品域クラス
			string displayType = Attributes["DisplayType"].ToLower();
			string headClass = Attributes["HeadClass"];
			string bodyClass = Attributes["BodyClass"];
			// 入力域表示文字数、設定されていなければ100
			string inputAreaCharactorString = Attributes["MaxCharacter"];
			inputAreaCharacter = string.IsNullOrEmpty(inputAreaCharactorString) ? 100 : int.Parse(inputAreaCharactorString);
			// タイトル表示文字数、設定されていなければ10
			string title1lineCharacterString = Attributes["Title1LineCharacter"];
			title1lineCharacter = string.IsNullOrEmpty(title1lineCharacterString) ? 10 : int.Parse(title1lineCharacterString);
			CalculationStyleWidth();
			// 基準日使用フラグ、優先1基準日使用コントロールID、優先2基準日使用コントロールID
			string useBasisDateString = Attributes["UseBasisDateFlg"];
			bool useBasisDate = string.IsNullOrEmpty(useBasisDateString) ? false : useBasisDateString.ToLower() == "true";
			string firstBasisDate = null;
			string secondBasisDate = null;
			if (useBasisDate)
			{
				firstBasisDate = Attributes["FirstBasisDate"];
				secondBasisDate = Attributes["SecondBasisDate"];
			}
			string commonIds = Attributes["CommonIDs"];
			string specificIds = Attributes["SpecificIDs"];
			string[] commonIdsList = null;
			string[] specificIdsList = null;
			if (commonIds != null)
			{
				commonIdsList = commonIds.Split(',');
				for (int i = 0; i < commonIdsList.Length; i++)
				{
					commonIdsList[i] = commonIdsList[i].Trim();
				}
			}
			if (specificIds != null)
			{
				specificIdsList = specificIds.Split(',');
				for (int i = 0; i < specificIdsList.Length; i++)
				{
					specificIdsList[i] = specificIdsList[i].Trim();
				}

			}
			// 汎用項目マスタから取得
			if (displayType == "inputedit") // 明細行はデータグリッドのため、インスタンス作成前に渡せないのでセッション経由でもらう
			{
				info = (CustomItemInfo)Page.Session[PageID + "_Temporary_CustomItemInformation_" + ID];
				if (info == null)
				{
					info = (CustomItemInfo)Page.Session[PageID + "_Temporary_CustomItemInformation"];
				}
			}

			if (info == null)
			{
#if DEBUG
				// EncodeLabelが表示されれば設定ミス
				TableRow rowError = new TableRow();
				TableCell title = new TableCell();
				EncodeLabel el = new EncodeLabel { Text = "\vUnable to get CustomItem" };
				title.Controls.Add(el);
				rowError.Cells.Add(title);
				Rows.Add(rowError);
#endif
				return;
			}
			DataTable dt = info.CustomItem;
			// 表示されているものだけNextControlID用に取得
			DataRow[] list = null;
			if (commonIdsList == null && specificIdsList == null)
			{
				list = dt.Select("DISP_FLG = '1' AND VALID_FLG = '1'");
			}
			else
			{
				string or = "";
				string orList = "";
				if (commonIdsList != null)
				{
					foreach (string customId in commonIdsList)
					{
						orList += or + "COLUMN_NAME = 'COMMON_ITEM" + customId + "'";
						or = " OR ";
					}
				}
				if (specificIdsList != null) // リストが無ければ対象内
				{
					foreach (string customId in specificIdsList)
					{
						orList += or + "COLUMN_NAME = 'SPECIFIC_ITEM" + customId + "'";
						or = " OR ";
					}
				}
				list = dt.Select("DISP_FLG = '1' AND VALID_FLG = '1' AND (" + orList + ")","TBNO,SORT_ORDER_TEXT");
			}
			int listCount = 0;
			List<string> requiredList = new List<string>();
			List<string> enabledList = new List<string>();
			List<string[]> hiddenList = new List<string[]>();
			TableRow row = new TableRow();
			foreach (DataRow dr in dt.Rows)
			{
				if (dr["VALID_FLG"].ToString() == "0")
				{
					continue;
				}
				if (IsOutOfRange(dr["COLUMN_NAME"].ToString(), dr["CUSTOM_ITEM_ID"].ToString(), commonIdsList, specificIdsList))
				{
					continue;
				}
				// 非表示は機能間の連携のために共通、固有とも隠し項目にする
				if (dr["DISP_FLG"].ToString() == "0")
				{
					hiddenList.Add(new string[] { dr["COLUMN_NAME"].ToString(), dr["MST_USE_TYPE"].ToString() });
					continue;
				}
				TableCell title = new TableCell();
				CreateTitle(title, dr["DISP_NAME"].ToString(), displayType, title1lineCharacter);
				title.CssClass = headClass;
				CalculationStyleWidth(title);
				row.Cells.Add(title);
				TableCell field = new TableCell();
				string nextElement = ++listCount == list.Length ? Attributes["NextControlID"] : this.ID + list[listCount]["COLUMN_NAME"].ToString();
				CreateItem(field, dr, displayType, requiredList,enabledList, Attributes["ClientChangeScript"], Attributes["ClientFocusScriptTextBox"], Attributes["ClientFocusScriptListBox"], nextElement, useBasisDate, firstBasisDate, secondBasisDate, listCount == list.Length ? listCount % columnCount : 0);
				field.CssClass = bodyClass;
				if (list.Length > 1) // 1項目しか汎用項目ないときはwidthやspanの設定はしない
				{
					CalculationStyleWidth(field);
					if (listCount == list.Length && list.Length % columnCount > 0) // すべての表示項目を出力後に、余分なセルをまとめる。
					{
						field.ColumnSpan = ((columnCount - (list.Length % columnCount)) * 2) + 1;
					}
				}
				row.Cells.Add(field);
				if ((columnCount * 2) <= row.Cells.Count) // 1行埋まったので<table>に追加して次の行を準備
				{
					Rows.Add(row);
					row = new TableRow();
				}
			}
			if (0 < row.Cells.Count) // 最後の行を<table>に追加
			{
				Rows.Add(row);
			}
			// 汎用項目の制御のために見えない行に情報を保管する。必須のダイアログの文言はrequiredを参照する。
			// フォーカス制御用の_0もあわせて保管する。
			row = new TableRow();
			row.Style.Add("display","none");
			TableCell cell = new TableCell();
			cell.Style.Add("display", "none");
			cell.ColumnSpan = columnCount * 2;
			tb_0 = new CustomTextBox { ID = this.ID + "_0" ,Enabled = false };
			tb_0.Style.Add("display", "none");
			tb_0.SearchInMyParent = true;
			tb_0.NextControlID = controlRelationList.Count == 0 ? Attributes["NextControlID"] : this.ID + controlRelationList[0].ColumnName;
			tb_0.Attributes.Add("FirstControlID",controlRelationList.Count == 0 ? Attributes["NextControlID"] : this.ID + controlRelationList[0].ColumnName);
			tb_0.Attributes.Add("tablename", this.ID);
			if (controlRelationList.Count == 0)
			{
				tb_0.Attributes.Add("LastControlID", Attributes["NextControlID"]);
			}
			else
			{
				ControlRelation lastControl = controlRelationList[controlRelationList.Count - 1];
				if (lastControl.FromTo)
				{
					tb_0.Attributes.Add("LastControlID", this.ID + lastControl.ColumnName + "To");
				}
				else
				{
					tb_0.Attributes.Add("LastControlID", this.ID + lastControl.ColumnName);
				}
			}
			cell.Controls.Add(tb_0);

			HiddenField required = new HiddenField { ID = this.ID + "REQUIRED" };
			required.Value = string.Join("\t",requiredList.ToArray());
			cell.Controls.Add(required);
			HiddenField enabled = new HiddenField { ID = this.ID + "ENABLED" };
			enabled.Value = string.Join("\t",enabledList.ToArray());
			cell.Controls.Add(enabled);
			foreach (string[] hiddenfield in hiddenList)
			{
				HiddenField hidden = new HiddenField { ID = this.ID + hiddenfield[0] };
				controlHiddenList.Add(new ControlRelation { Id = this.ID + hiddenfield[0], Hidden = hidden, ColumnName = hiddenfield[0], ControlType = "0", UseMaster = hiddenfield[1] != "0" });
				cell.Controls.Add(hidden);
			}
			row.Cells.Add(cell);
			Rows.Add(row);
			if (controlRelationList.Count == 0)
			{
				this.Style.Add("display", "none"); //表示する汎用項目がないなら、テーブルも非表示にする
			}
		}

		/// <summary>
		/// コントロールを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void Render(HtmlTextWriter writer)
		{
			bool useAcc = false;
			var useAccString = Attributes["UseAccordionFlg"];
			if (useAccString != null && 0 < controlRelationList.Count)
			{
				useAcc = Attributes["UseAccordionFlg"].ToLower() == "true";
			}
			string[] checkBoxHidden = this.Page.Request.Form.GetValues(this.ID + "HiddenAccordionCheckBox");
			bool checkBox = false;
			if (useAcc)
			{
				// アコーディオンの開閉状態を保持する隠し項目
				if (checkBoxHidden == null)
				{
					checkBox = info.OpenMode;
				}
				else
				{
					checkBox = checkBoxHidden[0] == "1";
				}
				writer.AddAttribute(HtmlTextWriterAttribute.Type, "hidden");
				writer.AddAttribute(HtmlTextWriterAttribute.Name,this.ID + "HiddenAccordionCheckBox");
				writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ID + "HiddenAccordionCheckBox");
				writer.AddAttribute(HtmlTextWriterAttribute.Value, checkBox ? "1" : "0");
				writer.RenderBeginTag(HtmlTextWriterTag.Input);
				writer.RenderEndTag();
				// DIVその１
				writer.AddAttribute(HtmlTextWriterAttribute.Class, "ac-container");
				writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ID + "ac-container");
				writer.RenderBeginTag(HtmlTextWriterTag.Div);
				// チェックボックス
				writer.AddAttribute(HtmlTextWriterAttribute.Type, "checkbox");
				writer.AddAttribute(HtmlTextWriterAttribute.Name,this.ID + "AccordionCheckBox");
				writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ID + "AccordionCheckBox");
				writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "clickAccordionCheckBox(\"" + this.ID + "\")");
				if ((enableFlg || GetDisplayType() == "inputhead") && checkBox)
				{
					writer.AddAttribute(HtmlTextWriterAttribute.Checked, "checked");
				}
				writer.RenderBeginTag(HtmlTextWriterTag.Input);
				writer.RenderEndTag();
				writer.AddAttribute(HtmlTextWriterAttribute.For, this.ID + "AccordionCheckBox");
				writer.RenderBeginTag(HtmlTextWriterTag.Label);
				string displayName = Attributes["TitleName"];
				if (displayName == null)
				{
					// 汎用項目
					displayName = MultiLanguage.Get("CM_CS004113");
				}
				writer.Write(displayName);
				writer.RenderEndTag();
				// DIVその２
				writer.RenderBeginTag(HtmlTextWriterTag.Div);
			}
			base.Render(writer);
			if (useAcc)
			{
				writer.RenderEndTag(); // DIVその２閉じる
				writer.RenderEndTag(); // DIVその１閉じる
			}
		}
		#endregion

		/// <summary>
		/// <see cref="Control.PreRender"/>イベントを発生させます。/>
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
#if DEBUG
			AllegroControl.AddDebugMark(this);
#endif
		}

		/// <summary>
		/// 有効な基準日を取得します。優先1、優先2、現在日付の順で取得します。基準日を使わない場合は日付を返しません。
		/// </summary>
		/// <param name="cr">
		/// 汎用項目名を指定します。
		/// </param>
		/// <returns>基準日の文字列</returns>
		private string GetBasisDate(ControlRelation cr)
		{
			string basisDate = "";
			if (cr.UseBasisDate)
			{
				if (cr.FirstBasisDate != null && 0 < cr.FirstBasisDate.Length)
				{
					string[] basis = this.Page.Request.Form.GetValues(cr.FirstBasisDate);
					if (basis != null && 0 < basis[0].Length)
					{
						return basis[0];
					}
				}
				if (cr.SecondBasisDate != null && 0 < cr.SecondBasisDate.Length)
				{
					string[] basis = this.Page.Request.Form.GetValues(cr.SecondBasisDate);
					if (basis != null && 0 < basis[0].Length)
					{
						return basis[0];
					}
				}
				string idpart = "";
				if (cr.TextBox.AppendedIDPart != null)
				{
					idpart = cr.TextBox.AppendedIDPart;
				}
				DateTime dt = DateTime.Now;
				return dt.ToString("yyyy/MM/dd");
			}
			return basisDate;
		}

		private void CustomItemPanel_TextChanged(object sender, System.EventArgs e)
		{
			CustomTextBox textBox = (CustomTextBox)sender;
			var controlRelation = controlRelationList.Find(m => m.Id == textBox.ID);
			if (controlRelation == null)
			{
				controlRelation = controlRelationList.Find(m => m.TextBoxTo.ID == textBox.ID);
			}
			if (controlRelation.Label != null)
			{
				string shortname = info.GetShortName(textBox.Text,controlRelation.RefTableType, controlRelation.ValidFlg, GetBasisDate(controlRelation));
				controlRelation.Label.Text = shortname;
				if (shortname == AllegroMessage.S10028)
				{
					info.FocusControl(textBox.AppendedIDPart + textBox.ID);
				}
				else
				{
					info.FocusControl(textBox.SearchInMyParent ? textBox.AppendedIDPart + textBox.NextControlID : textBox.NextControlID);
				}
			}
			else
			{
				info.FocusControl(textBox.SearchInMyParent ? textBox.AppendedIDPart + textBox.NextControlID : textBox.NextControlID);
			}
		}

		private void CalculationStyleWidth()
		{
			string columnCountString = Attributes["ColumnCount"];
			columnCount = string.IsNullOrEmpty(columnCountString) ? 2 : int.Parse(columnCountString);
			titleWidthString = Attributes["TitleWidth"];
			titleWidth = string.IsNullOrEmpty(titleWidthString) ? 10 : int.Parse(titleWidthString);
		}

		private void CalculationStyleWidth(TableCell cell)
		{
			if (tableDataCount < (columnCount * 2) - 1) // ２行目からwidthを設定しない。正確には１行目の最後から設定しない。
			{
				// タイトル幅はそのまま、内容の幅はパーセンテージを計算して出します。
				cell.Style.Add("width", (tableDataCount % 2 == 0 ? titleWidthString : ((100 / columnCount) - titleWidth).ToString()) + "%");
			}
			tableDataCount++;
		}

		private int GetTextWidth(int maxLength, bool fromTo, bool withLabel, int count)
		{
			int areaCharNumber = inputAreaCharacter;
			if (count != 0)
			{
				int remnantCount = columnCount - count;
				areaCharNumber = (inputAreaCharacter * (remnantCount + 1)) + (title1lineCharacter * remnantCount);
			}
			if (fromTo)
			{
				if ((areaCharNumber - 1) / 2 < maxLength)
				{
					maxLength = (byte)((areaCharNumber - 1) / 2);
				}
			}
			else if (withLabel)
			{
				if (areaCharNumber / 2 < maxLength)
				{
					maxLength = (byte)(areaCharNumber / 2);
				}
			}
			else
			{
				if (areaCharNumber < maxLength)
				{
					maxLength = areaCharNumber;
				}
			}
			return maxLength == 0 ? fromTo ? (areaCharNumber / 2) : areaCharNumber : maxLength;
		}

		private string GetSearchScript(string refTable)
		{
			string searchScript = "";
			switch (refTable)
			{
				case "1":
					searchScript = "callEmpSearchWindowForCustomItem";
					break;
				case "2":
					searchScript = "callDeptSearchWindowForCustomItem";
					break;
				case "3":
					searchScript = "callProjSearchWindowForCustomItem";
					break;
				case "4":
					searchScript = "callSuplSearchWindowForCustomItem";
					break;
				case "5":
					searchScript = "callPymtSearchWindowForCustomItem";
					break;
				case "6":
					searchScript = "callCustSearchWindowForCustomItem";
					break;
				case "7":
					searchScript = "callBillSearchWindowForCustomItem";
					break;
				case "8":
					searchScript = "callClctSearchWindowForCustomItem";
					break;
				case "9":
					searchScript = "callProdSearchWindowForCustomItem";
					break;
				case "10":
					searchScript = "callWhSearchWindowForCustomItem";
					break;
				default:
#if DEBUG
					searchScript = "alert(\"NAME_REF_TBL_TYPE ERROR\")";
#endif
					break;
			}
			return searchScript;
		}

		/// <summary>
		/// コントロール区分がテキストボックスの設定を行います。
		/// </summary>
		/// <param name="tb">
		/// テキストボックス
		/// </param>
		/// <param name="type">
		/// 表示種別
		/// </param>
		/// <param name="attribute">
		/// テキストボックスの属性、0:全角、1:半角
		/// </param>
		/// <param name="refTable">
		/// 名称取得区分
		/// </param>
		/// <param name="fromTo">
		/// 範囲検索
		/// </param>
		/// <param name="required">
		/// 必須
		/// </param>
		/// <param name="enabled">
		/// 修正許可
		/// </param>
		/// <param name="length">
		/// テキストボックスの幅、残りがEncodeLabelの幅になる
		/// </param>
		/// <param name="count">
		/// 最終行の設定数、0の場合は最終行でないか、すべて設定済
		/// </param>
		/// <returns>名称取得区分が0以外の入力画面か、一覧で範囲検索でない場合にEncodeLabelが作成され戻されます。該当しないときはnullが戻されます。</returns>
		private EncodeLabel SettingCustomTextBox(CustomTextBox tb, string type, string attribute, string refTable, bool fromTo, bool required, bool enabled, int length, int count)
		{
			EncodeLabel label = null;
			tb.Attributes.Add("tablename", this.ID);
			if (refTable != "0")
			{
				tb.ImeMode = ImeMode.Inactive;
				if (!fromTo)
				{
					tb.AutoPostBack = true;
					tb.TextChanged += CustomItemPanel_TextChanged;
				}
				tb.ClientF05Script = GetSearchScript(refTable);
				tb.TextTransform = TextTransform.UpperCase;
				tb.ImeMode = ImeMode.Inactive;
				tb.CheckOption = IF.CheckOption.SingleByte;
				if (type.StartsWith("input") || !fromTo)
				{
					int areaCharNumber = inputAreaCharacter;
					if (count != 0)
					{
						int remnantCount = columnCount - count;
						areaCharNumber = (inputAreaCharacter * (remnantCount + 1)) + (title1lineCharacter * remnantCount);
					}
					label = new EncodeLabel { ID = tb.ID + "Label",Width = Unit.Pixel((areaCharNumber - length) * 12) };
					AllegroControl.RegisterControlSubtypeAttribute(label, "NameLabel");
					label.Style.Add("margin-left","3px");
					label.Style.Add("vertical-align","middle");
				}
			}
			else
			{
				tb.ImeMode = attribute == "1" ? ImeMode.Inactive : ImeMode.Active;
			}
			if (type.StartsWith("input"))
			{
				if (required)
				{
					tb.IsRequiredField = true;
				}
				tb.Enabled = enabled;
				if (type == "inputedit")
				{
					tb.SearchInMyParent = true;
				}
			}
			if (attribute == "1")
			{
				tb.CheckOption = IF.CheckOption.SingleByte;
			}
			return label;
		}

		/// <summary>
		/// コントロール区分がナンバーボックスの設定を行います。
		/// </summary>
		/// <param name="nb">
		/// ナンバーボックス
		/// </param>
		/// <param name="type">
		/// 表示種別
		/// </param>
		/// <param name="required">
		/// 必須
		/// </param>
		/// <param name="enabled">
		/// 修正許可
		/// </param>
		private void SettingNumberBox(NumberBox nb, string type, bool required, bool enabled)
		{
			nb.Attributes.Add("tablename", this.ID);
			if (type.StartsWith("input"))
			{
				if (required)
				{
					nb.IsRequiredField = true;
				}
				nb.Enabled = enabled;
				if (type == "inputedit")
				{
					nb.SearchInMyParent = true;
				}
			}
		}

		/// <summary>
		/// コントロール区分がデイトボックスの設定を行います。
		/// </summary>
		/// <param name="db">
		/// テキストボックス
		/// </param>
		/// <param name="type">
		/// 表示種別
		/// </param>
		/// <param name="required">
		/// 必須
		/// </param>
		/// <param name="enabled">
		/// 修正許可
		/// </param>
		private void SettingDateBox(DateBox db, string type, bool required, bool enabled)
		{
			db.Attributes.Add("tablename", this.ID);
			db.ClientF05Script = "callCalendarWindow";
			if (type.StartsWith("input"))
			{
				if (required)
				{
					db.IsRequiredField = true;
				}
				db.Enabled = enabled;
				if (type == "inputedit")
				{
					db.SearchInMyParent = true;
				}
			}
		}

		/// <summary>
		/// コントロール区分がドロップダウンリストの設定を行います。
		/// </summary>
		/// <param name="ddl">
		/// ドロップダウンリスト
		/// </param>
		/// <param name="type">
		/// 表示種別
		/// </param>
		/// <param name="required">
		/// 必須
		/// </param>
		/// <param name="enabled">
		/// 修正許可
		/// </param>
		/// <param name="functionCode">
		/// 機能を指定します。
		/// </param>
		/// <param name="id">
		/// 汎用項目ID
		/// </param>
		/// <param name="count">
		/// 最終行の設定数、0の場合は最終行でないか、すべて設定済
		/// </param>
		private void SettingDropDownList(CustomDropDownList ddl, string type, bool required, bool enabled, string functionCode, string id, int count)
		{
			ddl.Attributes.Add("tablename", this.ID);
			if (type.StartsWith("input"))
			{
				if (required)
				{
					ddl.IsRequiredField = true;
				}
				ddl.Enabled = enabled;
				if (type == "inputedit")
				{
					ddl.SearchInMyParent = true;
				}
			}
			List<string> valueList = new List<string>();
			DataTable dt = info.ValueSetting;
			DataRow[] list = dt.Select("FUNCTION_CODE = '" + functionCode + "' AND TARGET_SCOPE_TYPE = '" + GetTargetScope(type, functionCode) + "' AND CUSTOM_ITEM_ID = '" + id + "'");
			foreach (DataRow dr in list)
			{
				string value = dr["VALUE_ITEM_NAME"].ToString();
				ddl.Items.Add(new ListItem { Value = dr["VALUE_ITEM_CODE"].ToString(), Text = value });
				if (inputAreaCharacter - 2 < value.Length)
				{
					valueList.Add(value);
				}
			}
			foreach (string value in valueList)
			{
				int areaCharNumber = inputAreaCharacter;
				if (count != 0)
				{
					int remnantCount = columnCount - count;
					areaCharNumber = (inputAreaCharacter * (remnantCount + 1)) + (title1lineCharacter * remnantCount);
				}
				int size = 0, half = 0, full = 0;
				StringFormat.GetAsHalfCharSize(value, out size, out half, out full);
				if ((half * 7) + (full * 12) + 22 > areaCharNumber * 12)
				{
					ddl.Width = (areaCharNumber * 12) + 10;
					break;
				}
			}
		}

		/// <summary>
		/// 汎用項目の表示名の設定を行います。
		/// </summary>
		/// <param name="cell">
		/// 表示名を設定するセル
		/// </param>
		/// <param name="text">
		/// 必須
		/// </param>
		/// <param name="type">
		/// 表示種別
		/// </param>
		/// <param name="lineCharactor">
		/// 折り返す文字数
		/// </param>
		private void CreateTitle(TableCell cell, string text, string type, int lineCharactor)
		{
			EncodeLabel el = new EncodeLabel { Text = text,Width = Unit.Pixel(lineCharactor * 12) };
			el.WhiteSpace = WhiteSpace.Normal;
			el.WordBreak = WordBreak.BreakAll;
			AllegroControl.RegisterControlSubtypeAttribute(el, "Title");
			cell.Controls.Add(el);
		}

		/// <summary>
		/// 汎用項目の共通的な設定を行います。
		/// </summary>
		/// <param name="cell">
		/// 汎用項目を設定するセル
		/// </param>
		/// <param name="dr">
		/// 汎用項目情報
		/// </param>
		/// <param name="type">
		/// 表示種別
		/// </param>
		/// <param name="requiredList">
		/// 必須項目を保管するリスト
		/// </param>
		/// <param name="enabledList">
		/// 活性項目を保管するリスト
		/// </param>
		/// <param name="changeScript">
		/// ダーティオンスクリプト
		/// </param>
		/// <param name="focusScript">
		/// フォーカススクリプト(カスタムテキストボックス)
		/// </param>
		/// <param name="focusScriptList">
		/// フォーカススクリプト(カスタムドロップダウンリスト)
		/// </param>
		/// <param name="nextElement">
		/// フォーカスを移すクライアントID
		/// </param>
		/// <param name="useBasisDate">
		/// 基準日使用フラグ
		/// </param>
		/// <param name="firstBasisDate">
		/// 優先1基準日コントロールID
		/// </param>
		/// <param name="secondBasisDate">
		/// 優先2基準日コントロールID
		/// </param>
		/// <param name="count">
		/// 最終行の設定数、0の場合は最終行でないか、すべて設定済
		/// </param>
		private void CreateItem(TableCell cell, DataRow dr, string type, List<string> requiredList, List<string> enabledList, string changeScript, string focusScript, string focusScriptList, string nextElement, bool useBasisDate, string firstBasisDate, string secondBasisDate, int count)
		{
			bool fromTo = type.StartsWith("input") ? false : dr["SCOPE_SEARCH_USE_FLG"].ToString() == "1";
			bool required = dr["INDIS_FLG"].ToString() == "1";
			bool enabled = dr["CORRECT_ALLOW_FLG"].ToString() == "1";
			bool withLabel = dr["NAME_REF_TBL_TYPE"].ToString() != "0";
			int maxLength = int.Parse(dr["LENGTH_TTL"].ToString());
			int width = GetTextWidth(maxLength, fromTo, withLabel, count);
			string columnId = this.ID + dr["COLUMN_NAME"].ToString();
			string customItemFocusScript = "CustomItemFocusScript(this);";
			bool validFlg = false;
			if (type.StartsWith("list"))
			{
				string functionCode = GetFunctionCode();
				if (functionCode == "cmms07_cust" || functionCode == "cmms07_supl" || functionCode == "scms03_prod") // ファンクションコードがマスタなら有効無効関係なく取得する
				{
					validFlg = true;
				}
			}
			ControlRelation cr = new ControlRelation
									{
										Id = columnId,
										ColumnName = dr["COLUMN_NAME"].ToString(),
										ControlType = dr["CONTROL_TYPE"].ToString(),
										UseMaster = dr["MST_USE_TYPE"].ToString() != "0",
										Enabled = enabled ,FromTo = fromTo,
										RefTableType = dr["NAME_REF_TBL_TYPE"].ToString(),
										ValidFlg = validFlg,
										UseBasisDate = useBasisDate,
										FirstBasisDate = firstBasisDate,
										SecondBasisDate = secondBasisDate
									};
			switch (dr["CONTROL_TYPE"].ToString())
			{
				case "1":
					CustomTextBox tb = new CustomTextBox
										{
											ID = columnId,Text = "",
											Width = (width * 12) + 10,
											MaxLength = maxLength,
											ClientChangeScript = changeScript,
											ClientFocusScript = customItemFocusScript + focusScript
										};
					AllegroControl.RegisterControlSubtypeAttribute(tb, "Input");
					EncodeLabel label = SettingCustomTextBox(tb, type, dr["ATTRIBUTE_TYPE"].ToString(), dr["NAME_REF_TBL_TYPE"].ToString(), fromTo, required, enabled, width, count);
					if (fromTo)
					{
						tb.NextControlID = columnId + "To";
						cell.Controls.Add(tb);
						// ～
						EncodeLabel el = new EncodeLabel { Text = MultiLanguage.Get("CM_CS003796") };
						AllegroControl.RegisterControlSubtypeAttribute(el, "Separator");
						el.Style.Add("margin-left","2px");
						el.Style.Add("margin-right","2px");
						cell.Controls.Add(el);
						CustomTextBox tbto = new CustomTextBox
											{
												ID = columnId + "To",
												Text = "", Width = (width * 12) + 10,
												MaxLength = maxLength,
												ClientChangeScript = changeScript,
												ClientFocusScript = focusScript
											};
						AllegroControl.RegisterControlSubtypeAttribute(tbto, "InputTo");
						SettingCustomTextBox(tbto, type, dr["ATTRIBUTE_TYPE"].ToString(), dr["NAME_REF_TBL_TYPE"].ToString(), fromTo, required, enabled, width, count);
						tbto.NextControlID = nextElement;
						cell.Controls.Add(tbto);
						cr.TextBoxTo = tbto;
					}
					else
					{
						tb.NextControlID = nextElement;
						cell.Controls.Add(tb);
						if (label != null)
						{
							cell.Controls.Add(label);
						}
					}
					cr.TextBox = tb;
					cr.Label = label;
					break;
				case "2":
					byte precision = byte.Parse(dr["LENGTH_TTL"].ToString());
					NumberBox nb = new NumberBox
									{
										ID = columnId,
										Text = "",
										Width = (width * 12) < (precision * 7) ? (width * 12) + 10 : (precision * 7) + 10,
										MaxLength = maxLength + 2, // 符号(-)と小数点(.)分長くする。
										AllowNegative = true,
										AllowDecimal = true,
										Precision = precision,
										Scale = byte.Parse(dr["LENGTH_ACC"].ToString()),
										ClientChangeScript = changeScript,
										ClientFocusScript = customItemFocusScript + focusScript
									};
					AllegroControl.RegisterControlSubtypeAttribute(nb, "Input");
					SettingNumberBox(nb, type, required, enabled);
					if (fromTo)
					{
						nb.NextControlID = columnId + "To";
						cell.Controls.Add(nb);
						// ～
						EncodeLabel el = new EncodeLabel { Text = MultiLanguage.Get("CM_CS003796") };
						AllegroControl.RegisterControlSubtypeAttribute(el, "Separator");
						el.Style.Add("margin-left","2px");
						el.Style.Add("margin-right","2px");
						cell.Controls.Add(el);
						NumberBox nbto = new NumberBox
										{
											ID = columnId + "To",
											Text = "",
											Width = (width * 12) < (precision * 7) ? (width * 12) + 10 : (precision * 7) + 10,
											MaxLength = maxLength + 2, // 符号(-)と小数点(.)分長くする。
											AllowNegative = true,
											AllowDecimal = true,
											Precision = precision,
											Scale = byte.
											Parse(dr["LENGTH_ACC"].ToString()),
											ClientChangeScript = changeScript,
											ClientFocusScript = focusScript
										};
						AllegroControl.RegisterControlSubtypeAttribute(nbto, "InputTo");
						SettingNumberBox(nbto, type, required, enabled);
						nbto.NextControlID = nextElement;
						cell.Controls.Add(nbto);
						cr.NumberBoxTo = nbto;
					}
					else
					{
						nb.NextControlID = nextElement;
						cell.Controls.Add(nb);
					}
					cr.NumberBox = nb;
					break;
				case "3":
					DateBox db = new DateBox
									{
										ID = columnId,
										ClientChangeScript = changeScript,
										ClientFocusScript = customItemFocusScript + focusScript
									};
					AllegroControl.RegisterControlSubtypeAttribute(db, "Input");
					SettingDateBox(db, type, required, enabled);
					if (fromTo)
					{
						db.NextControlID = columnId + "To";
						cell.Controls.Add(db);
						// ～
						EncodeLabel el = new EncodeLabel { Text = MultiLanguage.Get("CM_CS003796") };
						AllegroControl.RegisterControlSubtypeAttribute(el, "Separator");
						el.Style.Add("margin-left","2px");
						el.Style.Add("margin-right","2px");
						cell.Controls.Add(el);
						DateBox dbto = new DateBox
										{
											ID = columnId + "To",Text = "",
											ClientChangeScript = changeScript,
											ClientFocusScript = focusScript
										};
						AllegroControl.RegisterControlSubtypeAttribute(dbto, "InputTo");
						SettingDateBox(dbto, type, required, enabled);
						dbto.NextControlID = nextElement;
						cell.Controls.Add(dbto);
						cr.DateBoxTo = dbto;
					}
					else
					{
						db.NextControlID = nextElement;
						cell.Controls.Add(db);
					}
					cr.DateBox = db;
					break;
				case "4":
					CustomDropDownList ddl = new CustomDropDownList
											{
												ID = columnId,
												ClientChangeScript = changeScript,
												ClientFocusScript = customItemFocusScript + focusScriptList
											};
					AllegroControl.RegisterControlSubtypeAttribute(ddl, "Input");
					SettingDropDownList(ddl, type, required, enabled,dr["FUNCTION_CODE"].ToString(), dr["CUSTOM_ITEM_ID"].ToString(), count);
					ddl.NextControlID = nextElement;
					cell.Controls.Add(ddl);
					cr.DropDownList = ddl;
					break;
			}
			controlRelationList.Add(cr);
			if (required)
			{
				requiredList.Add(columnId);
				requiredList.Add(dr["DISP_NAME"].ToString());
			}
			if (enabled || type.StartsWith("list"))
			{
				enabledList.Add(columnId);
				if (fromTo)
				{
					enabledList.Add(columnId + "To");
				}
			}
		}

		private string GetTargetScope(string type, string functionCode)
		{
			string scope = "1";
			if (0 <= Array.IndexOf(CustomItemDetailType,type))
			{
				scope = "2";
			}
			if (GetFunctionCode() == "scms03_prod" && functionCode.ToLower() == "common")
			{
				scope = "2";
			}
			return scope;
		}

		private bool IsOutOfRange(string columnName, string id, string[] commonList, string[] specificList)
		{
			if (commonList != null) // リストが無ければ対象内
			{
				if (columnName.StartsWith("COMMON_ITEM"))
				{
					if (Array.IndexOf(commonList, id) < 0)
					{
						return true; // リストになければ対象外
					}
				}
			}
			if (specificList != null) // リストが無ければ対象内
			{
				if (columnName.StartsWith("SPECIFIC_ITEM"))
				{
					if (Array.IndexOf(specificList, id) < 0)
					{
						return true; // リストになければ対象外
					}
				}
			}
			return false;
		}

		private List<string> GetList(List<ControlRelation> source, bool useMaster = false)
		{
			List<string> list = new List<string>();
			foreach (ControlRelation crl in source)
			{
				if (useMaster)
				{
					if (!crl.UseMaster) // マスタ連携時でマスタ利用しないものは除外
					{
						continue;
					}
				}
				list.Add(crl.ColumnName);
			}
			return list;
		}

		private List<string> GetNoMasterUseList(List<ControlRelation> source)
		{
			List<string> list = new List<string>();
			foreach (ControlRelation crl in source)
			{
				if (crl.UseMaster || !crl.ColumnName.StartsWith("COMMON_ITEM")) // マスタ利用するもの、共通項目でないものはリストに加えない
				{
					continue;
				}
				list.Add(crl.ColumnName);
			}
			return list;
		}

		private class ControlRelation
		{
			public string Id { get; set; }

			public string ColumnName { get; set; }

			public bool UseMaster { get; set; }

			public string ControlType { get; set; }

			public CustomTextBox TextBox { get; set; }

			public EncodeLabel Label { get; set; }

			public NumberBox NumberBox { get; set; }

			public DateBox DateBox { get; set; }

			public CustomTextBox TextBoxTo { get; set; }

			public NumberBox NumberBoxTo { get; set; }

			public DateBox DateBoxTo { get; set; }

			public CustomDropDownList DropDownList { get; set; }

			public bool Enabled { get; set; }

			public bool FromTo { get; set; }

			public string RefTableType { get; set; }

			public bool ValidFlg { get; set; }

			public bool UseBasisDate { get; set; }

			public string FirstBasisDate { get; set; }

			public string SecondBasisDate { get; set; }

			public HiddenField Hidden { get; set; }
		}
	}
}
