// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : BottomLevelMenuNode.cs
// 機能名      : メニュー小項目
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K24546 2013/03/07 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/15 UI見直し
// 3.0.0 2018/04/30

using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// メニュー小項目
	/// </summary>
	public class BottomLevelMenuNode : BaseMenuNode
	{
		#region Constructors
		/// <summary>
		/// メニュー小項目のコンストラクタです。
		/// </summary>
		public BottomLevelMenuNode() : base()
		{
		}

		/// <summary>
		/// メニュー小項目のコンストラクタです。
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
		public BottomLevelMenuNode(string text, MenuItemType itemType, bool enabled, string pageUrl) : base(text, itemType, enabled, pageUrl)
		{
		}

		/// <summary>
		/// メニュー小項目のコンストラクタです。
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
		public BottomLevelMenuNode(string text, string itemType, bool enabled, string pageUrl) : base(text, itemType, enabled, pageUrl)
		{
		}
// 管理番号 K24546 From

		/// <summary>
		/// メニュー小項目のコンストラクタです。
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
		public BottomLevelMenuNode(string text, MenuItemType itemType, bool enabled, bool multiLanguage, string pageUrl)
			: base(text, itemType, enabled, multiLanguage, pageUrl)
		{
		}

		/// <summary>
		/// メニュー小項目のコンストラクタです。
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
		public BottomLevelMenuNode(string text, string itemType, bool enabled, bool multiLanguage, string pageUrl)
			: base(text, itemType, enabled, multiLanguage, pageUrl)
		{
		}
// 管理番号 K24546 To
		#endregion

		#region Override Methods
		/// <summary>
		/// コントロールのHTML開始タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public override void RenderBeginTag(HtmlTextWriter writer)
		{
		}

		/// <summary>
		/// コントロールの内容を出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
// 管理番号K26528 From
			if (this.ItemType != MenuItemType.Separator)
			{
				if(!this.Enabled)
				{
					writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
				}
			}
			AllegroControl.AddControlTypeAttribute(writer, this);
			AllegroControl.AddControlSubtypeAttribute(writer, Enum.GetName(typeof(MenuItemType), ItemType));
// 管理番号K26528 To
			switch (ItemType)
			{
				case MenuItemType.Title:
// 管理番号K26528 From
//// 管理番号 K24546 From 
////					writer.Write(Enabled
////					    ? "<span style=\"width: 161px; margin-left: 15px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\">"
////					    : "<span style=\"width: 161px; margin-left: 15px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\" disabled=\"disabled\">");
//					writer.Write(Enabled
//						? "<span style=\"width: 209px; margin-left: 18px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\">"
//						: "<span style=\"width: 209px; margin-left: 18px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\" disabled=\"disabled\">");
//// 管理番号 K24546 To
//					writer.Write(Text);
//					writer.WriteLine("</span><br>");
					writer.RenderBeginTag(HtmlTextWriterTag.Span);
					writer.Write(Text);
					writer.RenderEndTag();
// 管理番号K26528 To
					break;
				case MenuItemType.Page:
// 管理番号K26528 From
//// 管理番号 K24546 From
////					writer.Write("<a href=\"javascript:callWindow('");
//					if (MultiLanguage)
//					{
//						writer.Write("<a href=\"javascript:callWindowForMultiLanguage('");
//					}
//					else
//					{
//						writer.Write("<a href=\"javascript:callWindow('");
//					}
//// 管理番号 K24546 To
//					writer.Write(PageUrl);
//// 管理番号 K24546 From
////					writer.Write(Enabled
////					    ? "')\" style=\"width: 161px; margin-left: 15px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\">"
////					    : "')\" style=\"width: 161px; margin-left: 15px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\" disabled=\"disabled\">");
//					writer.Write(Enabled
//						? "')\" style=\"width: 209px; margin-left: 18px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\">"
//						: "')\" style=\"width: 209px; margin-left: 18px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\" disabled=\"disabled\">");
//// 管理番号 K24546 To
//					writer.Write(Text);
//					writer.WriteLine("</a><br>");
					if (this.Enabled)
					{
						var url = "javascript:callWindow" + (MultiLanguage ? "ForMultiLanguage" : string.Empty) + "('" + PageUrl + "')";
						writer.AddAttribute(HtmlTextWriterAttribute.Href, url);
					}
					writer.RenderBeginTag(HtmlTextWriterTag.A);
					writer.Write(Text);
					writer.RenderEndTag();
// 管理番号K26528 To
					break;
				case MenuItemType.Separator:
// 管理番号K26528 From
//// 管理番号 K24546 From
////					writer.WriteLine("<span style=\"width: 176px; padding: 3px\"></span><br>");
//					writer.WriteLine("<span style=\"width: 228px; padding: 3px\"></span><br>");
//// 管理番号 K24546 To
					writer.RenderBeginTag(HtmlTextWriterTag.Span);
					writer.RenderEndTag();
// 管理番号K26528 To
					break;
			}
// 管理番号K26528 From
			writer.WriteLine("<br/>");
// 管理番号K26528 To
		}

		/// <summary>
		/// コントロールのHTML終了タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public override void RenderEndTag(HtmlTextWriter writer)
		{
		}
		#endregion
	}
}
