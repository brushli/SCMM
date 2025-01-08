// Product     : Allegro
// Unit        : CM
// Module      : MS
// Function    : --
// File Name   : RateSaerchOption.cs
// 機能名      : レート検索オプション
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;

namespace Infocom.Allegro.CM.MS
{
	/// <summary>
	/// レートの検索オプション。
	/// </summary>
	public enum RateSaerchOption
	{
		/// <summary>
		/// 計上
		/// </summary>
		Book,
		/// <summary>
		/// 決済
		/// </summary>
		Sttl,
	}
}
