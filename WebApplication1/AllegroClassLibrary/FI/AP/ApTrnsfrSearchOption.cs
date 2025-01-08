// Product     : Allegro
// Unit        : FI
// Module      : AP
// Function    : --
// File Name   : ApTrnsfrSearchOption.cs
// 機能名      : 債務振替の検索オプション
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;

namespace Infocom.Allegro.FI.AP
{
	/// <summary>
	/// 債務振替の検索オプション。
	/// </summary>
	public enum ApTrnsfrSearchOption
	{
		/// <summary>
		/// 支払
		/// </summary>
		Pymt,
		/// <summary>
		/// 前渡金
		/// </summary>
		Adpm,
	}
}
