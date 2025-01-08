// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : CurrencyList.cs
// 機能名      : 通貨用ドロップダウンリストカスタムコントロール
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号B22074 2009/03/30 セッションタイムアウト時のメッセージ対応
// 1.6.0 2009/09/30
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Win32;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// 通貨用ドロップダウンリストカスタムコントロール
	/// </summary>
	/// <remarks>
	/// <p><b>CurrencyList</b> は GRANDIT用に Enter キーによるフォーカス移動、ファンクションキーの割当等をサポートします。</p>
	/// <p>このコントロールはデータバインドをサポートしません。</p>
	/// </remarks>
	[
	ToolboxData("<{0}:CurrencyList runat=server></{0}:CurrencyList>")
	]
	public class CurrencyList : Infocom.Allegro.Web.WebControls.CustomDropDownList, IAllegroContorl
	{
		#region Properties
		/// <summary>
		/// バインドされるデータの一覧の名前。常に<see cref="string.Empty"/>を返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		public override string DataMember
		{
			get {return string.Empty;}
		}

		/// <summary>
		/// データ項目一覧を取得する際の取得元となるオブジェクト。常にnullを返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		public override object DataSource
		{
			get {return null;}
		}

		/// <summary>
		/// データソースのフィールド。常に<see cref="string.Empty"/>を返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		public override string DataTextField
		{
			get {return string.Empty;}
		}

		/// <summary>
		/// データの表示方法を制御するために使用する書式指定文字列。常に<see cref="string.Empty"/>を返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		public override string DataTextFormatString
		{
			get {return string.Empty;}
		}

		/// <summary>
		/// データソースのフィールド。常に<see cref="string.Empty"/>を返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		public override string DataValueField
		{
			get {return string.Empty;}
		}

		/// <summary>
		/// コントロール上でEnterキーが押された時のフォーカスの移動先として設定するコントロールの<see cref="Control.ClientID"/>。
		/// </summary>
		string IAllegroContorl.InnerNextControlID
		{
			get {return SearchInMyParent ? AppendedIDPart + NextControlID : NextControlID;}
		}

		/// <summary>
		/// 通貨リストにブランクを追加するかどうか。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(false),
		Description("ブランクをリストに加えます。")
		]
		public virtual bool UsesAll
		{
			get
			{
				object o = ViewState["UsesAll"];
				return (o != null) ? (bool) o : false;
			}
			set {ViewState["UsesAll"] = value;}
		}

		/// <summary>
		/// データバインドを実行するかどうか。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(false),
		Description("データバインドを実行します。")
		]
		public virtual bool UsesBind
		{
			get
			{
				object o = ViewState["UsesBind"];
				return (o != null) ? (bool) o : false;
			}
			set {ViewState["UsesBind"] = value;}
		}
		#endregion

		#region Override Methods
		/// <summary>
		/// <see cref="Control.Init"/>イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnInit(EventArgs e)
		{
			try
			{
				string myCompCode = (string) Page.Session["MyCompCode"];
				string[] currencyCodes = (string[]) Page.Application[new StringBuilder(myCompCode, 24).Append("_CurrencyCodes").ToString()];
				string keyCurrency = (string) Page.Application[new StringBuilder(myCompCode, 26).Append("_KeyCurrencyCode").ToString()];
				Items.Clear();
				if (UsesAll)
				{
					ListItem item = new ListItem(string.Empty, "*");
					Items.Add(item);
					item.Selected = true;
				}
				foreach (string code in currencyCodes)
				{
					ListItem item = new ListItem(code);
					Items.Add(item);
					if (!UsesAll)
					{
						item.Selected = keyCurrency.Equals(code);
					}
				}
			}
// 管理番号B22074 From
//			catch (Exception ex)
//			{
//				throw new NullReferenceException("セッション変数、またはアプリケーション変数が初期化されてません。", ex);
//			}
			catch
			{
			}
// 管理番号B22074 To
			base.OnInit(e);
		}

		/// <summary>
		/// <see cref="Control.DataBinding"/>イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnDataBinding(EventArgs e)
		{
			if (UsesBind)
			{
				base.OnDataBinding(e);
			}
		}
		#endregion
	}
}
