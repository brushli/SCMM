// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : HtmlConverterBase.cs
// 機能名      : HTML変換抽象クラス
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/04/04 UI見直し
// 3.0.0 2018/04/30

using System.Text.RegularExpressions;

namespace Infocom.Allegro.Web.Html
{
	/// <summary>
	/// HTML変換抽象クラス
	/// </summary>
	public abstract class HtmlConverterBase
	{
		private string _textContent;

		/// <summary>
		/// HTML変換抽象クラス
		/// </summary>
		/// <param name="textContent">
		/// テキストの内容。
		/// </param>
		protected HtmlConverterBase(string textContent)
		{
			this.TextContent = textContent;
		}

		/// <summary>
		/// テキストの内容。
		/// </summary>
		public string TextContent
		{
			get { return _textContent; }
			// 垂直タブは削除する
			// （EncodeLabelで警告であることを表すための予約文字。HTMLに混入すると意図しない出力になる）
			set { _textContent = Regex.Replace(value, @"\v", string.Empty); }
		}

		/// <summary>
		/// HTMLへの変換を行います。
		/// </summary>
		/// <returns></returns>
		public abstract string ToHtml();
	}
}
