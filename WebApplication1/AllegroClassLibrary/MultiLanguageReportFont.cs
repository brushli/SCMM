// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : MultiLanguageReportFont.cs
// 機能名      : 帳票フォント切り替え
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25928 2015/08/10 ActiveReports9バージョンアップ対応
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;
using System.Drawing;
using GrapeCity.ActiveReports;
using GrapeCity.ActiveReports.SectionReportModel;

namespace Infocom.Allegro
{
	/// <summary>
	/// 帳票フォント切り替えに関する共通機能を提供します。このクラスは継承できません。
	/// </summary>
	public sealed class MultiLanguageReportFont
	{
		/// <summary>
		/// 指定したレポートのセクション内のコントロールに対して、リソースキーに対応したフォントを設定します。
		/// </summary>
		/// <param name="key">
		/// リソースキー
		/// </param>
		/// <param name="section">
		/// レポートセクション
		/// </param>
		public void Set(string key, Section section)
		{
			foreach (ARControl control in section.Controls)
			{
				if (control.GetType() == typeof(TextBox))
				{
					((TextBox)control).Font =
						new System.Drawing.Font(MultiLanguage.Get(key), ((TextBox)control).Font.Size, ((TextBox)control).Font.Style);
				}

				if (control.GetType() == typeof(Label))
				{
					((Label)control).Font =
						new System.Drawing.Font(MultiLanguage.Get(key), ((Label)control).Font.Size, ((Label)control).Font.Style);
				}
			}
		}

		/// <summary>
		/// 指定したレポートのセクション内のコントロールに対して、リソースキーに対応したフォントを設定します。
		/// </summary>
		/// <param name="key">
		/// リソースキー
		/// </param>
		/// <param name="section">
		/// レポートセクション
		/// </param>
		public void SetServerReport(string key, Section section)
		{
			foreach (ARControl control in section.Controls)
			{
				if (control.GetType() == typeof(TextBox))
				{
					((TextBox)control).Font =
						new System.Drawing.Font(MultiLanguage.GetServerReport(key), ((TextBox)control).Font.Size, ((TextBox)control).Font.Style);
				}

				if (control.GetType() == typeof(Label))
				{
					((Label)control).Font =
						new System.Drawing.Font(MultiLanguage.GetServerReport(key), ((Label)control).Font.Size, ((Label)control).Font.Style);
				}
			}
		}
	}
}
