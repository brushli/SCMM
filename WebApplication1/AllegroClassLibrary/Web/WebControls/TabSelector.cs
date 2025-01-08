// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : TabSelector.cs
// 機能名      : タブカスタムコントロール
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 1.6.0 2009/09/30
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/15 UI見直し
// 3.0.0 2018/04/30
// 3.1.0 2020/06/30
// 管理番号K27230 2021/05/21 脆弱性対応
// 3.2.0 2023/03/31

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text;
using System.Drawing;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// タブ表示用カスタムコントロール
	/// </summary>
	[
	ToolboxData("<{0}:TabSelector runat=server></{0}:TabSelector>"),
	ParseChildren(true, "Items")
	]
	public class TabSelector : System.Web.UI.Control, IPostBackDataHandler
	{
		#region public event SelectedIndexChanged
		private static readonly object selectedIndexChangedEvent = new object();

		/// <summary>
		/// コントロールがクリックされたときに発生します。
		/// </summary>
		[
		Category("Action"),
		Description("TabSelector がクリックされたときに発生します。")
		]
		public event EventHandler SelectedIndexChanged
		{
			add {Events.AddHandler(selectedIndexChangedEvent, value);}
			remove {Events.RemoveHandler(selectedIndexChangedEvent, value);}
		}
		#endregion

		#region Private Field
		private TabItemCollection items;
		#endregion

		#region Constructor
		/// <summary>
		/// タブ表示用カスタムコントロールのコンストラクタです。
		/// </summary>
		public TabSelector()
		{
			items = new TabItemCollection(this);
		}
		#endregion

		#region Properties
		/// <summary>
		/// コントロールがクリックされた時に内部で実行されるクライアントスクリプトの関数宣言。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		protected virtual string ClientScriptBlock
		{
			get
			{
// 管理番号K26528 From
//				StringBuilder script = new StringBuilder(
//@"	function change", 512).Append(ClientID).Append(@"Visibility(index) {
//		for (i = 0; i < ").Append(ClientID).Append(@"Pages.length; i++) {
//			").Append(ClientID).Append(@"Pages[i].style.display = (i == index) ? ""block"" : ""none"";
//			").Append(ClientID).Append(@"Selectors[i].style.cursor = (i == index) ? ""auto"" : ""Hand"";
//			").Append(ClientID).Append(@"Selectors[i].className = (i == index) ? ""tab_on_1"" : ""tab_off_1"";
//			").Append(ClientID).Append(@"Selectors_2[i].className = (i == index) ? ""tab_on_2"" : ""tab_off_2"";
//			").Append(ClientID).Append(@"Selectors_3[i].className = (i == index) ? ""tab_on_3"" : ""tab_off_3"";
//		}
//		document.all[""").Append(HiddenName).Append(@"""].value = index.toString();
//	}");
//				return script.ToString();
				return new StringBuilder()
					.Append("function change").Append(ClientID).AppendLine("Visibility(index) {")
					.Append("	for (var i = 0; i < ").Append(ClientID).AppendLine("Pages.length; i++) {")
					// display属性を初期値かnoneで切り替える
					.Append("		").Append(ClientID).AppendLine("Pages[i].style.display = (i == index) ? '' : 'none';")
					.Append("		if (i == index) {").AppendLine()
					.Append("			").Append(ClientID).AppendLine("Selectors[i].classList.add('selected');")
					.Append("		} else {").AppendLine()
					.Append("			").Append(ClientID).AppendLine("Selectors[i].classList.remove('selected');")
					.Append("		}").AppendLine()
					.Append("	}").AppendLine()
					.Append("	document.getElementById('").Append(HiddenName).AppendLine("').value = index;")
					.Append("}").AppendLine()
					.ToString();
// 管理番号K26528 To
			}
		}
		/// <summary>
		/// 選択されているタブのインデックス。
		/// </summary>
		public virtual int SelectedIndex
		{
			get
			{
				for (int i = 0; i < items.Count; i++)
				{
					if (items[i].Selected)
					{
						return i;
					}
				}
				return -1;
			}
			set
			{
				for (int i = 0; i < items.Count; i++)
				{
					items[i].Selected = (i == value);
				}
			}
		}

		/// <summary>
		/// 選択されているタブ。
		/// </summary>
		public virtual TabItem SelectedItem
		{
			get {return items[SelectedIndex];}
		}

		/// <summary>
		/// タブ項目のコレクション。
		/// </summary>
		public virtual TabItemCollection Items
		{
			get {return items;}
		}

		/// <summary>
		/// <see cref="SelectedIndex"/>を格納している隠し項目の名前。
		/// </summary>
		protected virtual string HiddenName
		{
			get {return new StringBuilder("__", 32).Append(ClientID).Append("_State").ToString();}
		}
		#endregion

		#region Override Methods
		/// <summary>
		/// <see cref="Control.PreRender"/>イベントを発生させます。/>
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnPreRender(EventArgs e)
		{
			StringBuilder tabPageArray = new StringBuilder(256);
			StringBuilder tabSelectorArray = new StringBuilder(256);
// 管理番号K26528 From
//			StringBuilder tabSelector2Array = new StringBuilder(256);
//			StringBuilder tabSelector3Array = new StringBuilder(256);
// 管理番号K26528 To
			foreach (TabItem item in items)
			{
				tabPageArray.Append("document.getElementById(\"");
				tabPageArray.Append(item.TabPageID);
				tabPageArray.Append("\"),");

				tabSelectorArray.Append("document.getElementById(\"");
				tabSelectorArray.Append(item.ClientID);
				tabSelectorArray.Append("\"),");

// 管理番号K26528 From
//				tabSelector2Array.Append("document.getElementById(\"");
//				tabSelector2Array.Append(item.ClientID);
//				tabSelector2Array.Append("__tab_2\"),");
//
//				tabSelector3Array.Append("document.getElementById(\"");
//				tabSelector3Array.Append(item.ClientID);
//				tabSelector3Array.Append("__tab_3\"),");
// 管理番号K26528 To
			}
			if (tabPageArray.Length != 0)
			{
				tabPageArray.Remove(tabPageArray.Length - 1, 1);
			}
			if (tabSelectorArray.Length != 0)
			{
				tabSelectorArray.Remove(tabSelectorArray.Length - 1, 1);
			}
// 管理番号K26528 From
//			if (tabSelector2Array.Length != 0)
//			{
//				tabSelector2Array.Remove(tabSelector2Array.Length - 1, 1);
//			}
//			if (tabSelector3Array.Length != 0)
//			{
//				tabSelector3Array.Remove(tabSelector3Array.Length - 1, 1);
//			}
// 管理番号K26528 To
			Page.ClientScript.RegisterArrayDeclaration(ClientID + "Pages", tabPageArray.ToString());
			Page.ClientScript.RegisterArrayDeclaration(ClientID + "Selectors", tabSelectorArray.ToString());
// 管理番号K26528 From
//			Page.ClientScript.RegisterArrayDeclaration(ClientID + "Selectors_2", tabSelector2Array.ToString());
//			Page.ClientScript.RegisterArrayDeclaration(ClientID + "Selectors_3", tabSelector3Array.ToString());
//
//			if (!Page.ClientScript.IsStartupScriptRegistered(ClientID + "_StartScript"))
//			{
//				StringBuilder script = new StringBuilder(
//					@"<script type=""text/javascript"">
//").Append(ClientScriptBlock).Append(@"
//	change").Append(ClientID).Append(@"Visibility(").Append(SelectedIndex.ToString()).Append(@");
//</script>");
//				Page.ClientScript.RegisterStartupScript(this.GetType(), ClientID + "_StartScript", script.ToString());
//			}
			if (!Page.ClientScript.IsClientScriptBlockRegistered(ClientID + "_ScriptBlock"))
			{
				Page.ClientScript.RegisterClientScriptBlock(this.GetType(), ClientID + "_ScriptBlock", ClientScriptBlock, true);
			}
			if (!((PageBase)Page).ImmediateStartupScript.IsScriptRegistered(ClientID + "_StartScript"))
			{
				var script = new StringBuilder().Append("change").Append(ClientID).Append(@"Visibility(").Append(SelectedIndex).AppendLine(");");
				((PageBase)Page).ImmediateStartupScript.RegisterScript(this.GetType(), ClientID + "_StartScript", script.ToString());
			}
// 管理番号K26528 To
			Page.ClientScript.RegisterHiddenField(HiddenName, SelectedIndex.ToString());
			base.OnPreRender(e);
			Page.RegisterRequiresPostBack(this);
			for (int i = 0; i < items.Count; i++)
			{
// 管理番号K26528 From
//				if (items[i].Enabled)
//				{
//					if (items[i].ClientClickScript.Length != 0)
//					{
//						StringBuilder script = new StringBuilder("if(document.readyState==\"complete\"){change", 64);
//						script.Append(ClientID);
//						script.Append(@"Visibility(");
//						script.Append(i.ToString());
//						script.Append(");");
//						script.Append(items[i].ClientClickScript);
//						script.Append("(this);}");
//						items[i].Attributes.Add("onclick", script.ToString());
//					}
//					else
//					{
//						StringBuilder script = new StringBuilder("if(document.readyState==\"complete\"){change", 64);
//						script.Append(ClientID);
//						script.Append(@"Visibility(");
//						script.Append(i.ToString());
//						script.Append(");}");
//						items[i].Attributes.Add("onclick", script.ToString());
//					}
//				}
				var script = new StringBuilder("if(document.readyState==\"complete\"){");
				script.Append("change").Append(ClientID).Append("Visibility(").Append(i).Append(");");

// 管理番号K27230 From
//				var clientClickScript = items[i].ClientClickScript;
				var clientClickScript = System.Web.HttpUtility.JavaScriptStringEncode(items[i].ClientClickScript);
// 管理番号K27230 To
				if (!string.IsNullOrEmpty(clientClickScript))
				{
					script.Append(clientClickScript).Append("(this);");
				}

				script.Append("}");
				items[i].Attributes.Add("onclick", script.ToString());
// 管理番号K26528 To
			}
		}

		/// <summary>
		/// コントロールのHTML開始タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public virtual void RenderBeginTag(HtmlTextWriter writer)
		{
// 管理番号K26528 From
//			writer.WriteLine("<table cellspacing=\"0\" cellpadding=\"0\" style=\"BORDER: 0px\">");
//			writer.WriteLine("\t<tr>");
			AllegroControl.AddControlTypeAttribute(writer, this);
			writer.RenderBeginTag(HtmlTextWriterTag.Div);
// 管理番号K26528 To
		}

		/// <summary>
		/// コントロールのHTML終了タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public virtual void RenderEndTag(HtmlTextWriter writer)
		{
// 管理番号K26528 From
//			writer.WriteLine("\t</tr>");
//			writer.WriteLine("</table>");
			writer.RenderEndTag();
// 管理番号K26528 To
		}

		/// <summary>
		/// コントロールの内容を出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected virtual void RenderContents(HtmlTextWriter writer)
		{
			base.Render(writer);
		}

		/// <summary>
		/// コントロールを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void Render(HtmlTextWriter writer)
		{
			RenderBeginTag(writer);
			RenderContents(writer);
			RenderEndTag(writer);
		}

		/// <summary>
		/// <see cref="SelectedIndexChanged" /> イベントを発生させます。この機能により、イベントのカスタム ハンドラを作成できます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected virtual void OnSelectedIndexChanged(EventArgs e)
		{
			EventHandler handler = (EventHandler) Events[selectedIndexChangedEvent];
			if (handler != null)
			{
				handler(this, e);
			}
		}
		#endregion

		#region Explicit Interface Implementations
		/// <summary>
		/// サーバー コントロールのポストバック データを処理します。
		/// </summary>
		/// <param name="postDataKey">
		/// コントロールのキー識別子。
		/// </param>
		/// <param name="postCollection">
		/// 受信する名前と値すべてのコレクション。
		/// </param>
		/// <returns>
		/// ポストバックの結果、サーバー コントロールの状態が変化する場合：true、それ以外の場合：false。
		/// </returns>
		bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
		{
			string value = postCollection[HiddenName];

			if (value != null)
			{
				int newValue = -1;

				try
				{
					newValue = int.Parse(value);
				}
				catch (FormatException)
				{
					newValue = -1;
				}
				int oldValue = SelectedIndex;

				SelectedIndex = newValue;

				return (newValue != oldValue);
			}
			return false;
		}

		/// <summary>
		/// 変更イベントを発生させます。
		/// </summary>
		void IPostBackDataHandler.RaisePostDataChangedEvent()
		{
			OnSelectedIndexChanged(new EventArgs());
		}
		#endregion
	}

	/// <summary>
	/// 内包用タブ項目コレクション
	/// </summary>
	public class TabItemCollection : IList, ICollection, IEnumerable
	{
		#region Private Fields
		private ArrayList list;
		private readonly TabSelector parent;
		#endregion

		#region Constructor
		/// <summary>
		/// 内包用タブ項目コレクションのコンストラクタです。
		/// </summary>
		/// <param name="parent">
		/// コレクションを所属させる<see cref="TabSelector"/>。
		/// </param>
		internal TabItemCollection(TabSelector parent)
		{
			list = new ArrayList(4);
			this.parent = parent;
		}
		#endregion

		#region Properties
		/// <summary>
		/// コレクション内の要素の合計数。
		/// </summary>
		public virtual int Count
		{
			get {return list.Count;}
		}

		/// <summary>
		/// コレクションが読み取り専用かどうか。
		/// </summary>
		public virtual bool IsReadOnly
		{
			get {return false;}
		}

		/// <summary>
		/// コレクションが同期がとられているかどうか。常にfalseを返します。
		/// </summary>
		public virtual bool IsSynchronized
		{
			get {return false;}
		}

		/// <summary>
		/// コレクションへのアクセスを同期するために使用できるオブジェクト。
		/// </summary>
		public virtual object SyncRoot
		{
			get {return list.SyncRoot;}
		}

		/// <summary>
		/// 指定したインデックス位置にある<see cref="TabItem"/>。
		/// </summary>
		public TabItem this[int index]
		{
			get {return (TabItem) list[index];}
			set {list[index] = value;}
		}
		#endregion

		#region Method
		/// <summary>
		/// 指定した<see cref="TabItem"/>をコレクションに追加します。
		/// </summary>
		/// <param name="value">
		/// コレクションに追加する<see cref="TabItem"/>。
		/// </param>
		/// <returns>
		/// 新しい要素が挿入された位置。
		/// </returns>
		public int Add(TabItem value)
		{
			int index = list.Add(value);
			parent.Controls.Add(value);
			value.Selector = parent;
			return index;
		}

		/// <summary>
		/// コレクションからすべての<see cref="TabItem"/>を削除します。
		/// </summary>
		public virtual void Clear()
		{
			list.Clear();
			parent.Controls.Clear();
		}

		/// <summary>
		/// 指定した<see cref="TabItem"/>がコレクションに格納されているかどうかを判断します。
		/// </summary>
		/// <param name="value">
		/// コレクション内で検索される<see cref="TabItem"/>。
		/// </param>
		/// <returns>
		/// コレクションにある場合：true、それ以外の場合：false
		/// </returns>
		public bool Contains(TabItem value)
		{
			return list.Contains(value);
		}

		/// <summary>
		/// コレクションに格納されている<see cref="TabItem"/>を、<see cref="Array"/>オブジェクトに、
		/// <see cref="Array"/>内の指定したインデックス位置からコピーします。
		/// </summary>
		/// <param name="array">
		/// コピー先の<see cref="Array"/>。
		/// </param>
		/// <param name="index">
		/// コピーの開始位置となる、<paramref name="array"/>の0から始まる相対インデックス番号。
		/// </param>
		public virtual void CopyTo(Array array, int index)
		{
			list.CopyTo(array, index);
		}

		/// <summary>
		/// コレクションを反復処理できる列挙子を取得します。
		/// </summary>
		/// <returns>
		/// コレクションを反復処理する列挙子。
		/// </returns>
		public virtual IEnumerator GetEnumerator()
		{
			return list.GetEnumerator();
		}

		/// <summary>
		/// コレクション内の指定した<see cref="TabItem"/>のインデックスを取得します。
		/// </summary>
		/// <param name="value">
		/// インデックスを返す対象となる<see cref="TabItem"/>。
		/// </param>
		/// <returns>
		/// 指定した<see cref="TabItem"/>のインデックス。
		/// </returns>
		public int IndexOf(TabItem value)
		{
			return list.IndexOf(value);
		}

		/// <summary>
		/// コレクションから、指定した<see cref="TabItem"/>を削除します。
		/// </summary>
		/// <param name="value">
		/// コレクションから削除する<see cref="TabItem"/>。
		/// </param>
		public void Remove(TabItem value)
		{
			list.Remove(value);
			parent.Controls.Remove(value);
		}

		/// <summary>
		/// コレクションから、指定したインデックス位置にある<see cref="TabItem"/>を削除します。
		/// </summary>
		/// <param name="index">
		/// コレクションから削除する<see cref="TabItem"/>の配列内の位置。
		/// </param>
		public virtual void RemoveAt(int index)
		{
			list.RemoveAt(index);
			parent.Controls.RemoveAt(index);
		}
		#endregion

		#region Explicit Interface Implementations
		/// <summary>
		/// 指定したインデックス位置にある要素。
		/// </summary>
		object IList.this[int index]
		{
			get {return list[index];}
			set {list[index] = (TabItem) value;}
		}

		/// <summary>
		/// 指定した要素をコレクションに追加します。
		/// </summary>
		/// <param name="value">
		/// コレクションに追加する要素。
		/// </param>
		/// <returns>
		/// 新しい要素が挿入された位置。
		/// </returns>
		int IList.Add(object value)
		{
			int index = list.Add((TabItem) value);
			parent.Controls.Add((TabItem) value);
			return index;
		}

		/// <summary>
		/// 指定した要素がコレクションに格納されているかどうかを判断します。
		/// </summary>
		/// <param name="value">
		/// コレクション内で検索される要素。
		/// </param>
		/// <returns>
		/// コレクションにある場合：true、それ以外の場合：false
		/// </returns>
		bool IList.Contains(object value)
		{
			return list.Contains((TabItem) value);
		}

		/// <summary>
		/// コレクション内の指定した要素のインデックスを取得します。
		/// </summary>
		/// <param name="value">
		/// インデックスを返す対象となる要素。
		/// </param>
		/// <returns>
		/// 指定した要素のインデックス。
		/// </returns>
		int IList.IndexOf(object value)
		{
			return list.IndexOf((TabItem) value);
		}

		/// <summary>
		/// コレクション内の指定したインデックスの位置に要素を挿入します。
		/// </summary>
		/// <param name="index">
		/// <paramref name="value"/>を挿入する位置の、0から始まるインデックス番号。
		/// </param>
		/// <param name="value">
		/// 挿入する要素。
		/// </param>
		void IList.Insert(int index, object value)
		{
			list.Insert(index, (TabItem) value);
			parent.Controls.AddAt(index, (TabItem) value);
		}

		/// <summary>
		/// コレクションが固定サイズかどうかを示す値。常にfalseを返します。
		/// </summary>
		bool IList.IsFixedSize
		{
			get {return false;}
		}

		/// <summary>
		/// コレクションから、指定した要素を削除します。
		/// </summary>
		/// <param name="value">
		/// コレクションから削除する要素。
		/// </param>
		void IList.Remove(object value)
		{
			list.Remove((TabItem) value);
			parent.Controls.Remove((TabItem) value);
		}
		#endregion
	}

	/// <summary>
	/// タブ表示用カスタムコントロールのアイテム
	/// </summary>
	[
	DefaultProperty("Text"),
	ToolboxData("<{0}:TabItem runat=server></{0}:TabItem>")
	]
	public class TabItem : WebControl
	{
		#region Constructor
		/// <summary>
		/// タブ表示用カスタムコントロールのアイテムのコンストラクタです。
		/// </summary>
// 管理番号K26528 From
//		public TabItem() : base(HtmlTextWriterTag.Td)
		public TabItem() : base(HtmlTextWriterTag.Unknown)
// 管理番号K26528 To
		{
		}

		/// <summary>
		/// タブ表示用カスタムコントロールのアイテムのコンストラクタです。
		/// </summary>
		/// <param name="tag">
		/// HTMLタグ
		/// </param>
		protected TabItem(HtmlTextWriterTag tag) : base(tag)
		{
		}

		/// <summary>
		/// タブ表示用カスタムコントロールのアイテムのコンストラクタです。
		/// </summary>
		/// <param name="tag">
		/// HTMLタグ
		/// </param>
		protected TabItem(string tag) : base(tag)
		{
		}
		#endregion

		private TabSelector selector;

		#region Properties
		/// <summary>
		/// コントロールがクリックされた時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// <para>メソッドの戻り値がfalseの場合、サーバーへのポストバックは中止されます。</para>
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("チェック ボックスがクリックされた時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientClickScript
		{
			get
			{
				object o = ViewState["ClientClickScript"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientClickScript"] = value;}
		}

		/// <summary>
		/// 項目が属している<see cref="TabSelector"/>。
		/// </summary>
		public TabSelector Selector
		{
			get {return selector;}
			set {selector = value;}
		}

		/// <summary>
		/// 項目が選択されているかどうか。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(false),
		Description("")
		]
		public virtual bool Selected
		{
			get
			{
				object o = ViewState["Selected"];
				return (o != null) ? (bool) o : false;
			}
			set {ViewState["Selected"] = value;}
		}

		/// <summary>
		/// タブ選択時に表示するHTMLの要素に定義されたID属性の値。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("")
		]
		public virtual string TabPageID
		{
			get
			{
				object o = ViewState["TabPageID"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["TabPageID"] = value;}
		}

		/// <summary>
		/// コントロールに表示される文字列。
		/// </summary>
		[
		Category("Appearance"),
		DefaultValue(""),
		Description("")
		]
		public virtual string Text
		{
			get
			{
				object o = ViewState["Text"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["Text"] = value;}
		}
		#endregion

// 管理番号K26528 From
//		#region Override Methods
//		/// <summary>
//		/// コントロールのHTML開始タグを出力します。
//		/// </summary>
//		/// <param name="writer">
//		/// 出力先の<see cref="HtmlTextWriter"/>。
//		/// </param>
//		public override void RenderBeginTag(HtmlTextWriter writer)
//		{
//			AddStartupTag(writer);
//			base.RenderBeginTag(writer);
//		}
//
//		/// <summary>
//		/// コントロールのHTML終了タグを出力します。
//		/// </summary>
//		/// <param name="writer">
//		/// 出力先の<see cref="HtmlTextWriter"/>。
//		/// </param>
//		public override void RenderEndTag(HtmlTextWriter writer)
//		{
//			base.RenderEndTag(writer);
//			AddEndoffTag(writer);
//		}
//
//		/// <summary>
//		/// コントロールの内容を出力します。
//		/// </summary>
//		/// <param name="writer">
//		/// 出力先の<see cref="HtmlTextWriter"/>。
//		/// </param>
//		protected override void RenderContents(HtmlTextWriter writer)
//		{
//			writer.Write(Text);
//		}
//
//		/// <summary>
//		/// カスタムコントロールに必要なHTML属性やスタイル、イベントハンドラ等を追加します。
//		/// </summary>
//		/// <param name="writer">
//		/// 出力先の<see cref="HtmlTextWriter"/>。
//		/// </param>
//		protected override void AddAttributesToRender(HtmlTextWriter writer)
//		{
//			AddAttributes();
//			base.AddAttributesToRender(writer);
//		}
//
//		/// <summary>
//		/// カスタムコントロールに必要なHTML属性やスタイル、イベントハンドラ等を追加します。
//		/// </summary>
//		protected virtual void AddAttributes()
//		{
//			CssClass = "tab_on_1";
//
//			Style.Add("text-align", "Center");
//			if (!Selected)
//			{
//				Style.Add("cursor", "Hand");
//			}
//		}
//
//		/// <summary>
//		/// コントロールのHTML開始タグを出力します。
//		/// </summary>
//		/// <param name="writer">
//		/// 出力先の<see cref="HtmlTextWriter"/>。
//		/// </param>
//		protected virtual void AddStartupTag(HtmlTextWriter writer)
//		{
//			writer.WriteLine("<td><table cellspacing=\"0\" cellpadding=\"0\" style=\"border:0px\">");
//			writer.WriteLine("\t<tr>");
//			writer.Write("\t\t<td id=\"");
//			writer.Write(ClientID);
//// 管理番号 K24546 From
////			writer.WriteLine("__tab_2\" class=\"tab_on_2\"><img src=\"img/CM_a1_space.gif\" style=\"border:0px;width:100px;height:2px\" alt=\"\"></td>");
//			writer.WriteLine(MultiLanguage.Get("CM_CS003585"));
//// 管理番号 K24546 To
//			writer.Write("\t\t<td rowspan=\"2\"><span id=\"");
//			writer.Write(ClientID);
//			writer.WriteLine("__tab_3\" class=\"tab_on_3\" style=\"border:0px;width:12px;height:26px\"></span></td>");
//			writer.WriteLine("\t</tr>");
//			writer.WriteLine("\t<tr>");
//		}
//
//		/// <summary>
//		/// コントロールのHTML終了タグを出力します。
//		/// </summary>
//		/// <param name="writer">
//		/// 出力先の<see cref="HtmlTextWriter"/>。
//		/// </param>
//		protected virtual void AddEndoffTag(HtmlTextWriter writer)
//		{
//			writer.WriteLine();
//			writer.WriteLine("\t</tr>");
//			writer.WriteLine("</table></td>");
//		}
//		#endregion

		/// <summary>
		/// コントロールのHTML開始タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public override void RenderBeginTag(HtmlTextWriter writer)
		{
			// タグが不定の場合は開始タグは描画しない
			if (!string.IsNullOrEmpty(this.TagName))
			{
				base.RenderBeginTag(writer);
			}
		}

		/// <summary>
		/// コントロールのHTML終了タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public override void RenderEndTag(HtmlTextWriter writer)
		{
			// タグが不定の場合は終了タグは描画しない
			if (!string.IsNullOrEmpty(this.TagName))
			{
				base.RenderEndTag(writer);
			}
		}

		/// <summary>
		/// コントロールの内容を出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
			var button = new StyledButton();
			button.CopyBaseAttributes(this);
			button.MergeStyle(this.ControlStyle);

			button.ID = this.ID;
			button.UseSubmitBehavior = false;
			button.Enabled = this.IsEnabled;
			button.Text = this.Text;

			// 選択タブの場合はselectedクラスを付与する
			button.CssClass = "tab_item" + (this.Selected ? " selected" : string.Empty);

			// フォーカス遷移を抑止する
			button.TabIndex = -1;
			button.Attributes.Add("onfocus", string.Empty);

			button.RenderControl(writer);
		}
// 管理番号K26528 To
	}
}
