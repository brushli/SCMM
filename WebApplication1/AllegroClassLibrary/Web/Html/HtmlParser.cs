// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : HtmlParser.cs
// 機能名      : HTML解析用クラス
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2018/01/04 UI見直し
// 3.0.0 2018/04/30

using System;
using System.Text.RegularExpressions;

namespace Infocom.Allegro.Web.Html
{
	/// <summary>
	/// HTML解析用クラス
	/// </summary>
	public class HtmlParser
	{
		/// <summary>
		/// 入力されたHTMLからタグを除去したテキスト要素を返します。
		/// </summary>
		/// <param name="inputHtml">入力HTML</param>
		/// <returns>テキスト要素を保持する配列</returns>
		public static string[] GetTextContents(string inputHtml) {
			string delimiter = "\t";

			string replaced = inputHtml;

			// 属性値として"<"や">"が存在する可能性があるため属性値を除去する（"及び'とそれに囲まれた部分を削除）
			Regex attributeRemove = new Regex("([\"']).*?\\1");
			replaced = attributeRemove.Replace(replaced, string.Empty);

			// タグ削除
			Regex tagRemove = new Regex("\\s*<.*?>\\s*");
			replaced = tagRemove.Replace(replaced, delimiter);

			// 空要素を除去して分割
			string[] result = replaced.Split(new [] { delimiter }, StringSplitOptions.RemoveEmptyEntries);

			return result;
		}
	}
}
