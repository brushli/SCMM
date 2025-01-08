// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : ClickableDataGrid.cs
// 機能名      : クリックイベントをサポートするデータグリッドカスタムコントロール
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 1.6.0 2009/09/30
// 管理番号 B24094 2012/04/09 多重リクエスト抑止対応
// 2.0.0 2012/10/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/04/11 UI見直し
// 3.0.0 2018/04/30

using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// クリックイベントをサポートするデータグリッドカスタムコントロール
	/// </summary>
	[
	DefaultEvent("ItemClick"),
	ToolboxData("<{0}:ClickableDataGrid runat=server></{0}:ClickableDataGrid>")
	]
	public class ClickableDataGrid : CustomDataGrid, IPostBackEventHandler
	{
		#region Property
		/// <summary>
		/// クリックされた時にサーバーへの自動ポストバックが発生するかどうか。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(true),
		Description("クリックした時に、自動的にサーバーにポストします。")
		]
		public virtual bool AutoPostBack
		{
			get
			{
				object o = ViewState["AutoPostBack"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["AutoPostBack"] = value;}
		}
		#endregion

		#region public event ItemClick
		private static readonly object itemClickEvent = new object();

		/// <summary>
		/// <see cref="ClickableDataGrid"/>の非編集行、もしくはフッタ行がクリックされたときに発生します。
		/// </summary>
		[
		Category("Action"),
		Description("ClickableDataGrid で行がクリックされたときに発生します。")
		]
		public event ItemClickEventHandler ItemClick
		{
			add {Events.AddHandler(itemClickEvent, value);}
			remove {Events.RemoveHandler(itemClickEvent, value);}
		}
		#endregion

		#region Virtual or Override Methods
		/// <summary>
		/// <see cref="DataGrid.ItemCreated"/>イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="DataGridItemEventArgs"/>オブジェクト。
		/// </param>
		protected override void OnItemCreated(DataGridItemEventArgs e)
		{
			if (AutoPostBack && (!(Page is InputPageBase) || ((InputPageBase) Page).Mode != PageMode.Reference))
			{
// 管理番号K26528 From
				var clickScript = "__customControl.handler.clickableControlClickHandler('" + this.UniqueID + "', '" + e.Item.ItemIndex.ToString() + "');";
// 管理番号K26528 To
				switch (e.Item.ItemType)
				{
					case ListItemType.Item:
					case ListItemType.AlternatingItem:
// 管理番号K26528 From
////管理番号 B24094 From
////						e.Item.Attributes.Add("onclick", new StringBuilder("if(forbidDuplicationSubmit())").Append(Page.ClientScript.GetPostBackEventReference(this, e.Item.ItemIndex.ToString())).ToString());
//						e.Item.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(this, e.Item.ItemIndex.ToString()));
////管理番号 B24094 To
						e.Item.Attributes.Add("onclick", clickScript);
// 管理番号K26528 To
						break;
					case ListItemType.Footer:
						if (EditItemIndex != -1)
						{
// 管理番号K26528 From
////管理番号 B24094 From
////							e.Item.Attributes.Add("onclick", new StringBuilder("if(forbidDuplicationSubmit())").Append(Page.ClientScript.GetPostBackEventReference(this, e.Item.ItemIndex.ToString())).ToString());
//							e.Item.Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(this, e.Item.ItemIndex.ToString()));
////管理番号 B24094 To
							e.Item.Attributes.Add("onclick", clickScript);
// 管理番号K26528 To
						}
						break;
				}
			}
			base.OnItemCreated(e);
		}

		/// <summary>
		/// <see cref="ItemClick"/>イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="ItemClickEventArgs"/>オブジェクト。
		/// </param>
		protected virtual void OnItemClick(ItemClickEventArgs e)
		{
			ItemClickEventHandler handler = (ItemClickEventHandler) Events[itemClickEvent];
			if (handler != null)
			{
				handler(this, e);
			}
		}
		#endregion

		#region Explicit Interface Implementations
		/// <summary>
		/// ポストバックイベントを発生させます。
		/// </summary>
		/// <param name="eventArgument">
		/// イベント引数
		/// </param>
		void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
		{
			int itemIndex = int.Parse(eventArgument);
			if (itemIndex == -1)
			{
				OnItemClick(new ItemClickEventArgs(itemIndex, ""));
			}
			else
			{
				OnItemClick(new ItemClickEventArgs(itemIndex, Items[itemIndex].ClientID));
			}
		}
		#endregion
	}

	#region public class ItemClickEventArgs
	/// <summary>
	/// <see cref="ClickableDataGrid"/>コントロールの<see cref="ClickableDataGrid.ItemClick"/>イベントのデータを提供します。
	/// </summary>
	public class ItemClickEventArgs : EventArgs
	{
		private int itemIndex;
		private string appendedIDPart;

		/// <summary>
		/// <see cref="ItemClickEventArgs"/>クラスのコンストラクタです。
		/// </summary>
		/// <param name="itemIndex">
		/// <see cref="ClickableDataGrid"/>内の項目のインデックス。
		/// </param>
		/// <param name="rowID">
		/// <see cref="ClickableDataGrid"/>内の<see cref="DataGridItem"/>のクライアントID。
		/// </param>
		public ItemClickEventArgs(int itemIndex, string rowID)
		{
			this.itemIndex = itemIndex;
			appendedIDPart = rowID + "_";
		}

		/// <summary>
		/// クリックされた<see cref="ClickableDataGrid"/>で参照された項目のインデックス。
		/// </summary>
		public int ItemIndex
		{
			get {return itemIndex;}
		}

		/// <summary>
		/// クリックされた<see cref="ClickableDataGrid"/>で参照された行にあるコントロールの<see cref="Control.ClientID"/>のうち、
		/// 親コントロールによって付加された部分。
		/// </summary>
		public string AppendedIDPart
		{
			get {return appendedIDPart;}
		}
	}
	#endregion

	#region public delegate void ItemClickEventHandler(object, ItemClickEventArgs)
	/// <summary>
	/// <see cref="ClickableDataGrid"/>の<see cref="ClickableDataGrid.ItemClick"/>イベントを処理するメソッドを表します。
	/// </summary>
	public delegate void ItemClickEventHandler(object sender, ItemClickEventArgs e);
	#endregion
}
