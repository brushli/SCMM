// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : TraceLevel.cs
// 機能名      : トレースレベル定義
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;

namespace Infocom.Allegro
{
	/// <summary>
	/// トレースレベル
	/// </summary>
	public enum TraceLevel
	{
		/// <summary>
		/// 冗長
		/// <para>全ての例外レベルをトレースします。</para>
		/// </summary>
		Verbose,
		/// <summary>
		/// 情報
		/// <para>例外レベル「情報」以上の例外をトレースします。</para>
		/// </summary>
		Info,
		/// <summary>
		/// 警告
		/// <para>例外レベル「警告」以上の例外をトレースします。</para>
		/// </summary>
		Warning,
		/// <summary>
		/// エラー
		/// <para>例外レベル「エラー」以上の例外をトレースします。</para>
		/// </summary>
		Error,
		/// <summary>
		/// 致命的エラー
		/// <para>例外レベル「致命的エラー」以上の例外をトレースします。</para>
		/// </summary>
		FatalError,
		/// <summary>
		/// 未定義
		/// <para>例外レベル「未定義」の例外のみをトレースします。</para>
		/// </summary>
		Undefined,
		/// <summary>
		/// トレースを行いません。
		/// </summary>
		Off,
	}
}
