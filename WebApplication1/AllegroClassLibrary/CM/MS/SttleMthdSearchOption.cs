// Product     : Allegro
// Unit        : CM
// Module      : MS
// Function    : --
// File Name   : SttleMthdSearchOption.cs
// 機能名      : 決済方法の検索オプション
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
	/// 決済方法の検索オプション。
	/// </summary>
	public enum SttleMthdSearchOption
	{
		/// <summary>
		/// 回収
		/// </summary>
		Clct,
		/// <summary>
		/// 回収消込
		/// </summary>
		ClctKo,
		/// <summary>
		/// 回収台帳（期日決済）
		/// </summary>
		ClctLedger,
		/// <summary>
		/// 支払
		/// </summary>
		Pymt,
		/// <summary>
		/// 支払台帳（期日決済）
		/// </summary>
		PymtLedger,
		/// <summary>
		/// 国内回収
		/// </summary>
		DomesticClct,
		/// <summary>
		/// 国内支払
		/// </summary>
		DomesticPymt,
		/// <summary>
		/// 海外回収
		/// </summary>
		OverseasClct,
		/// <summary>
		/// 海外支払
		/// </summary>
		OverseasPymt,
	}
}
