// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : BaseMenuNode.cs
// 機能名      : メニュー項目基底クラス
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// メニュー項目基底クラス
	/// </summary>
	public abstract class BaseMenuNode : Control
	{
		#region Private Fields
		private bool enabled;
		private MenuItemType itemType;
		private MenuNodeCollection nodes;
		private string pageUrl;
		private string text;
// 管理番号 K24546 From
		private bool multiLanguage = false;
// 管理番号 K24546 To
		#endregion

		#region Constructors
		/// <summary>
		/// メニュー項目基底クラスのコンストラクタです。
		/// </summary>
		public BaseMenuNode() : base()
		{
			this.enabled = true;
			this.itemType = MenuItemType.Separator;
			nodes = new MenuNodeCollection();
		}

		/// <summary>
		/// メニュー項目基底クラスのコンストラクタです。
		/// </summary>
		/// <param name="text">
		/// メニューに表示する文字列。
		/// </param>
		/// <param name="itemType">
		/// メニューアイテム区分
		/// </param>
		/// <param name="enabled">
		/// コントロールを有効にするかどうかを示す値。
		/// </param>
		/// <param name="pageUrl">
		/// ページURL
		/// </param>
		protected BaseMenuNode(string text, MenuItemType itemType, bool enabled, string pageUrl) : base()
		{
			this.enabled = enabled;
			this.itemType = itemType;
			nodes = new MenuNodeCollection();
			this.pageUrl = pageUrl;
			this.text = text;
		}

		/// <summary>
		/// メニュー項目基底クラスのコンストラクタです。
		/// </summary>
		/// <param name="text">
		/// メニューに表示する文字列。
		/// </param>
		/// <param name="itemType">
		/// メニューアイテム区分（タイトル："T"、ページ："P"、セパレータ："S"）
		/// </param>
		/// <param name="enabled">
		/// コントロールを有効にするかどうかを示す値。
		/// </param>
		/// <param name="pageUrl">
		/// ページURL
		/// </param>
		protected BaseMenuNode(string text, string itemType, bool enabled, string pageUrl) : base()
		{
			this.enabled = enabled;
			switch (itemType)
			{
				case "T":
					this.itemType = MenuItemType.Title;
					break;
				case "P":
					this.itemType = MenuItemType.Page;
					break;
				case "S":
					this.itemType = MenuItemType.Separator;
					break;
				default:
// 管理番号 K24546 From
// 					throw new ArgumentException("itemType の値が不正です。", "itemType");
					throw new ArgumentException(Infocom.Allegro.MultiLanguage.Get("CM_AM000487"), "itemType");
// 管理番号 K24546 To
			}
			nodes = new MenuNodeCollection();
			this.pageUrl = pageUrl;
			this.text = text;
		}
// 管理番号 K24546 From

		/// <summary>
		/// メニュー項目基底クラスのコンストラクタです。
		/// </summary>
		/// <param name="text">
		/// メニューに表示する文字列。
		/// </param>
		/// <param name="itemType">
		/// メニューアイテム区分
		/// </param>
		/// <param name="enabled">
		/// コントロールを有効にするかどうかを示す値。
		/// </param>
		/// <param name="multiLanguage">
		/// 多言語対応用の画面サイズで表示する場合：true、それ以外の場合：false
		/// </param>
		/// <param name="pageUrl">
		/// ページURL
		/// </param>
		protected BaseMenuNode(string text, MenuItemType itemType, bool enabled, bool multiLanguage, string pageUrl)
			: this(text, itemType, enabled, pageUrl)
		{
			this.multiLanguage = multiLanguage;
		}

		/// <summary>
		/// メニュー項目基底クラスのコンストラクタです。
		/// </summary>
		/// <param name="text">
		/// メニューに表示する文字列。
		/// </param>
		/// <param name="itemType">
		/// メニューアイテム区分（タイトル："T"、ページ："P"、セパレータ："S"）
		/// </param>
		/// <param name="enabled">
		/// コントロールを有効にするかどうかを示す値。
		/// </param>
		/// <param name="multiLanguage">
		/// 多言語対応用の画面サイズで表示する場合：true、それ以外の場合：false
		/// </param>
		/// <param name="pageUrl">
		/// ページURL
		/// </param>
		protected BaseMenuNode(string text, string itemType, bool enabled, bool multiLanguage, string pageUrl)
			: this(text, itemType, enabled, pageUrl)
		{
			this.multiLanguage = multiLanguage;
		}
// 管理番号 K24546 To
		#endregion

		#region Properties
		/// <summary>
		/// コントロールを有効にするかどうか。
		/// </summary>
		public virtual bool Enabled
		{
			get {return enabled;}
			set {enabled = value;}
		}

		/// <summary>
		/// メニューアイテム区分
		/// </summary>
		public MenuItemType ItemType
		{
			get {return itemType;}
			set {itemType = value;}
		}

		/// <summary>
		/// 親メニューを表す<see cref="MenuNodeCollection"/>。
		/// </summary>
		public MenuNodeCollection Nodes
		{
			get {return nodes;}
		}

		/// <summary>
		/// ページURL
		/// </summary>
		public virtual string PageUrl
		{
			get {return (pageUrl != null) ? pageUrl : string.Empty;}
			set {pageUrl = value;}
		}

		/// <summary>
		/// メニューに表示する文字列。
		/// </summary>
		public virtual string Text
		{
			get {return (text != null) ? text : string.Empty;}
			set {text = value;}
		}
// 管理番号 K24546 From
		/// <summary>
		/// 多言語対応用の画面サイズで表示する場合：true、それ以外の場合：false
		/// </summary>
		public virtual bool MultiLanguage
		{
			get { return multiLanguage; }
			set { multiLanguage = value; }
		}
// 管理番号 K24546 To
		#endregion

		#region Override Methods
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
			foreach (BaseMenuNode node in nodes)
			{
				node.RenderControl(writer);
			}
			RenderEndTag(writer);
		}

		/// <summary>
		/// コントロールのHTML開始タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public abstract void RenderBeginTag(HtmlTextWriter writer);

		/// <summary>
		/// コントロールの内容を出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected abstract void RenderContents(HtmlTextWriter writer);

		/// <summary>
		/// コントロールのHTML終了タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public abstract void RenderEndTag(HtmlTextWriter writer);
		#endregion
	}

	/// <summary>
	/// メニューアイテム区分
	/// </summary>
	public enum MenuItemType
	{
		/// <summary>
		/// タイトル
		/// </summary>
		Title,
		/// <summary>
		/// ページ
		/// </summary>
		Page,
		/// <summary>
		/// セパレータ
		/// </summary>
		Separator
	}
}
