// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : CustomTreeView.cs
// 機能名      : カスタムツリービューコントロール
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
	/// カスタムツリービューコントロール
	/// </summary>
	public class CustomTreeView : TreeView
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
			base.AddAttributesToRender(writer);
		}

		/// <summary>
		/// コントロールのHTML開始タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public override void RenderBeginTag(HtmlTextWriter writer)
		{
			// スクリーンリーダー用のリンクがブラウザに余白を生じさせるため、出力を抑止する
			this.SkipLinkText = string.Empty;
			base.RenderBeginTag(writer);
		}
	}
}
