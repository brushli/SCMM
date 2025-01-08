// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : StyledButton.cs
// 機能名      : スタイル定義済みボタンカスタムコントロール
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/03/30 UI見直し
// 3.0.0 2018/04/30

using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// スタイル定義済みボタンカスタムコントロール
	/// </summary>
	[DefaultProperty("Text")]
	[DefaultEvent("Click")]
	[ParseChildren(false)]
	[ToolboxData("<{0}:StyledButton runat=server />")]
	public class StyledButton : CustomButton
	{
		/// <summary>
		/// コントロールに表示する画像のURL。
		/// </summary>
		[UrlProperty]
		public virtual string ImageUrl
		{
			get { return (string)ViewState["ImageUrl"] ?? string.Empty; }
			set { ViewState["ImageUrl"] = value; }
		}

		/// <summary>
		/// コントロールに対応する<see cref="HtmlTextWriterTag" />の値。
		/// 常に<see cref="HtmlTextWriterTag.Button"/>を返します。
		/// </summary>
		protected override HtmlTextWriterTag TagKey
		{
			get { return HtmlTextWriterTag.Button; }
		}

		/// <summary>
		/// コントロールの内容を出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter" />。
		/// </param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
			writer.AddAttribute(HtmlTextWriterAttribute.Onclick, "return __customControl.handler.buttonRootElementClickHandler(this);");
			writer.RenderBeginTag(HtmlTextWriterTag.Span);

			// ImageUrlが設定されている場合はCustomImageコントロールを使用してimg要素を出力する
			if (!string.IsNullOrEmpty(this.ImageUrl))
			{
				new Image { ImageUrl = this.ImageUrl, GenerateEmptyAlternateText = true }.RenderControl(writer);
			}

			if (!string.IsNullOrEmpty(this.Text))
			{
				// Textプロパティの設定値を優先する
				writer.Write(HttpUtility.HtmlEncode(this.Text));
			}
			else
			{
				// 子コントロールを持つ場合
				foreach (Control item in this.Controls)
				{
					if (item is DataBoundLiteralControl)
					{
						writer.Write(HttpUtility.HtmlEncode(((DataBoundLiteralControl)item).Text.Trim()));
					}
					else if (item is LiteralControl)
					{
						writer.Write(HttpUtility.HtmlEncode(((LiteralControl)item).Text));
					}
					else
					{
						// リテラルテキスト以外の場合はコントロール自身に描画させる
						item.RenderControl(writer);
					}
				}
			}

			writer.RenderEndTag();
		}
	}
}
