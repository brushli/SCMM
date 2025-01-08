// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : CustomCalendar.cs
// 機能名      : カスタムカレンダーコントロール
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
	/// カスタムカレンダーコントロール
	/// </summary>
	public class CustomCalendar : Calendar
	{
		/// <summary>
		/// コントロールを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void Render(HtmlTextWriter writer)
		{
			// 【参考情報】CalendarクラスにAddAttributesToRenderの定義がないため、Renderメソッドで属性の追加を行う。
			AllegroControl.RegisterControlTypeAttribute(this);
			base.Render(writer);
		}
	}
}
