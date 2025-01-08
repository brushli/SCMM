// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : Enums.cs
// 機能名      : 共通列挙型定義（カスタムコントロール）
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;

namespace Infocom.Allegro.Web.WebControls
{
	#region enum ImeMode
	/// <summary>
	/// テキスト入力時のIMEの状態（CSSにおけるime-modeに対応します）。
	/// </summary>
	public enum ImeMode
	{
		/// <summary>
		/// IME入力モードを指定しません。
		/// </summary>
		NotSet = 0,
		/// <summary>
		/// IMEの状態を変更しません。
		/// </summary>
		Auto = 1,
		/// <summary>
		/// IME入力モードをオンにします。
		/// </summary>
		Active = 2,
		/// <summary>
		/// IME入力モードをオフにします。
		/// </summary>
		Inactive = 3,
		/// <summary>
		/// IMEの使用を禁止します。
		/// </summary>
		Disabled = 4
	}
	#endregion

	#region enum TextTransform
	/// <summary>
	/// テキストの大文字表示・小文字表示（CSSにおけるtext-transformに対応します）。
	/// </summary>
	public enum TextTransform
	{
		/// <summary>
		/// 表示方法を指定しません。
		/// </summary>
		NotSet = 0,
		/// <summary>
		/// 記述したとおりに表示します。
		/// </summary>
		None = 1,
		/// <summary>
		/// 各単語の先頭のみ大文字で表示します。
		/// </summary>
		Capitalize = 2,
		/// <summary>
		/// すべて小文字で表示します。
		/// </summary>
		LowerCase = 3,
		/// <summary>
		/// すべて大文字で表示します。
		/// </summary>
		UpperCase = 4
	}
	#endregion

	#region enum Overflow
	/// <summary>
	/// コントロールのサイズを超えた部分の表示方法（CSSにおけるoverflowに対応します）。
	/// </summary>
	public enum Overflow
	{
		/// <summary>
		/// 表示方法を指定しません。
		/// </summary>
		NotSet = 0,
		/// <summary>
		/// すべて表示します。
		/// </summary>
		Visible = 1,
		/// <summary>
		/// 表示するためにスクロールバーを表示します。
		/// </summary>
		Scroll = 2,
		/// <summary>
		/// 表示しません。
		/// </summary>
		Hidden = 3,
		/// <summary>
		/// 自動的に処理されます。
		/// </summary>
		Auto = 4
	}
	#endregion

	#region enum WordBreak
	/// <summary>
	/// 文章の改行の方法（CSSにおけるword-breakに対応します）。
	/// </summary>
	public enum WordBreak
	{
		/// <summary>
		/// 改行の方法が設定されていません。
		/// </summary>
		NotSet = 0,
		/// <summary>
		/// 英字等は単語の途中では改行されませんが、日本語などは幅に合わせて改行されます。
		/// </summary>
		Normal = 1,
		/// <summary>
		/// 言語にかかわらず表示幅で改行されます。
		/// </summary>
		BreakAll = 2,
		/// <summary>
		/// 言語にかかわらず単語の途中では改行しません。
		/// </summary>
		KeepAll = 3
	}
	#endregion

	#region enum WhiteSpace
	/// <summary>
	/// 連続する半角スペース・タブ・改行の表示方法（CSSにおけるwhite-spaceに対応します）。
	/// </summary>
	public enum WhiteSpace
	{
		/// <summary>
		/// 連続する半角スペース・タブ・改行の表示方法が設定されていません。
		/// </summary>
		NotSet = 0,
		/// <summary>
		/// 連続する半角スペース・タブ・改行を、1つの半角スペースとして表示します。コントールの大きさが指定されている場合には、その大きさに応じて自動的に改行されます。
		/// </summary>
		Normal = 1,
		/// <summary>
		/// 連続する半角スペース・タブ・改行を、そのまま表示します。
		/// </summary>
		Pre = 2,
		/// <summary>
		/// 連続する半角スペース・タブ・改行を、1つの半角スペースとして表示します。コントールの大きさが指定されている場合にも、自動的に改行されません。
		/// </summary>
		Nowrap = 3
	}
	#endregion
}
