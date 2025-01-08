// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : ExceptionLevel.cs
// 機能名      : 例外レベル
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
	/// 例外レベル
	/// </summary>
	public enum ExceptionLevel
	{
		/// <summary>
		/// 冗長
		/// <para>デバッグに使用します。</para>
		/// </summary>
		Verbose,
		/// <summary>
		/// 情報
		/// </summary>
		Info,
		/// <summary>
		/// 警告
		/// </summary>
		Warning,
		/// <summary>
		/// エラー
		/// </summary>
		Error,
		/// <summary>
		/// 致命的エラー
		/// </summary>
		FatalError,
		/// <summary>
		/// 未定義
		/// <para>使用されません。</para>
		/// </summary>
		Undefined,
	}
}
