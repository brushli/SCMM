// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : CustomImage.cs
// 機能名      : カスタムイメージコントロール
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/02/13 UI見直し
// 3.0.0 2018/04/30

using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// カスタムイメージコントロール
	/// </summary>
	public class CustomImage : Image
	{
		/// <summary>
		/// カスタムコントロールに必要なHTML属性やスタイル、イベントハンドラ等を追加します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			AllegroControl.RegisterControlTypeAttribute(this);

			// ツールチップが未設定の場合は代替テキストをツールチップとして設定する。
			if (string.IsNullOrEmpty(this.ToolTip))
			{
				this.ToolTip = this.AlternateText;
			}
			base.AddAttributesToRender(writer);
		}
	}
}
