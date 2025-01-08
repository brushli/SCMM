// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : HtmlMultilineText.cs
// 機能名      : HTML出力可能な複数行のテキスト
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/04/04 UI見直し
// 3.0.0 2018/04/30

namespace Infocom.Allegro.Web.Html
{
	/// <summary>
	/// HTML出力可能な複数行のテキスト
	/// </summary>
	public sealed class HtmlMultilineText : HtmlConverterBase
	{
		/// <summary>
		/// HTML出力可能な複数行のテキスト
		/// </summary>
		/// <param name="textContent">
		/// テキストの内容。
		/// </param>
		public HtmlMultilineText(string textContent) : base(textContent)
		{
		}

		/// <summary>
		/// HTMLへの変換を行います。
		/// <para>末尾以外の改行はbr要素に変換されます。</para>
		/// </summary>
		/// <returns></returns>
		public override string ToHtml()
		{
			return this.TextContent
				.TrimEnd(' ', '\r', '\n')
				.Replace("\r\n", "<br/>");
		}
	}
}
