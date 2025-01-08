﻿// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : MiddleLevelMenuNode.cs
// 機能名      : メニュー中項目
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
// 管理番号K26528 2017/02/17 UI見直し
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
	/// メニュー中項目
	/// </summary>
	public class MiddleLevelMenuNode : BaseMenuNode
	{
		#region Constructors
		/// <summary>
		/// メニュー中項目のコンストラクタです。
		/// </summary>
		public MiddleLevelMenuNode() : base()
		{
		}

		/// <summary>
		/// メニュー中項目のコンストラクタです。
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
		public MiddleLevelMenuNode(string text, MenuItemType itemType, bool enabled, string pageUrl) : base(text, itemType, enabled, pageUrl)
		{
		}

		/// <summary>
		/// メニュー中項目のコンストラクタです。
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
		public MiddleLevelMenuNode(string text, string itemType, bool enabled, string pageUrl) : base(text, itemType, enabled, pageUrl)
		{
		}
// 管理番号 K24546 From
		/// <summary>
		/// メニュー中項目のコンストラクタです。
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
		public MiddleLevelMenuNode(string text, MenuItemType itemType, bool enabled, bool multiLanguage, string pageUrl)
			: base(text, itemType, enabled, multiLanguage, pageUrl)
		{
		}

		/// <summary>
		/// メニュー中項目のコンストラクタです。
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
		public MiddleLevelMenuNode(string text, string itemType, bool enabled, bool multiLanguage, string pageUrl)
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
				CreatePointImage().RenderControl(writer);
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
//					writer.Write(Enabled
//// 						? "<img src=\"img/CM_a2_hd_title_point.gif\" style=\"width: 17px; height: 17px\" align=\"absmiddle\" alt=\"■\"><span style=\"width: 159px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\">" //K24546
//						? Infocom.Allegro.MultiLanguage.Get("CM_AM000413")
//// 						: "<img src=\"img/CM_a2_hd_title_point.gif\" style=\"width: 17px; height: 17px\" align=\"absmiddle\" alt=\"■\"><span style=\"width: 159px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\" disabled=\"disabled\">"); //K24546
//						: Infocom.Allegro.MultiLanguage.Get("CM_AM000412"));
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
////					writer.Write("<img src=\"img/CM_a2_hd_title_point.gif\" style=\"width: 17px; height: 17px\" align=\"AbsMiddle\" alt=\"■\"><a href=\"javascript:callWindow('");
//					if (MultiLanguage)
//					{
//						writer.Write("" + Infocom.Allegro.MultiLanguage.Get("ZZ_CS000034") + "'");
//					}
//					else
//					{
//						writer.Write("" + Infocom.Allegro.MultiLanguage.Get("CM_AM000411") + "'");
//					}
//// 管理番号 K24546 To
//					writer.Write(PageUrl);
//// 管理番号 K24546 From 
////					writer.Write(Enabled
////					    ? "')\" style=\"width: 159px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\">"
////					    : "')\" style=\"width: 159px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\" disabled=\"disabled\">");
//					writer.Write(Enabled
//						? "')\" style=\"width: 206px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\">"
//						: "')\" style=\"width: 206px; overflow: hidden; word-break: keep-all; white-space: nowrap; padding: 2px\" disabled=\"disabled\">");
//// 管理番号 K24546 To
//					writer.Write(Text);
//					writer.WriteLine("</a><br>");
					if(this.Enabled)
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
//
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


#region Methods
// 管理番号K26528 From
		private CustomImage CreatePointImage()
		{
			var pointImg = new CustomImage
			{
				// img/CM_a2_hd_title_point.gif
				ImageUrl = Infocom.Allegro.MultiLanguage.Get("CM_IM000118"),
				// ■
				AlternateText = Infocom.Allegro.MultiLanguage.Get("CM_CS000030")
			};
			AllegroControl.RegisterControlSubtypeAttribute(pointImg, "PointImage");
			return pointImg;
		}
// 管理番号K26528 To
#endregion

	}
}
