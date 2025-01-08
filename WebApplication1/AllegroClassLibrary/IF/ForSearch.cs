// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : ForSearch.cs
// 機能名      : 検索用列挙型定義
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;

namespace Infocom.Allegro.IF
{
	/// <summary>
	/// 検索する際に用いる比較演算子
	/// </summary>
	[Flags]
	public enum SearchOperator
	{
		/// <summary>
		/// 等しいかどうかの比較。
		/// </summary>
		Equal = 0x0001,
		/// <summary>
		/// より大きいかどうかの比較。
		/// </summary>
		GreaterThan = 0x0002,
		/// <summary>
		/// 等しいまたはより大きいかどうかの比較。
		/// </summary>
		GreaterThanEqual = 0x0004,
		/// <summary>
		/// より小さいかどうかの比較。
		/// </summary>
		LessThan = 0x0008,
		/// <summary>
		/// 等しいまたはより小さいかの比較。
		/// </summary>
		LessThanEqual = 0x0010,
		/// <summary>
		/// 等しくないかどうかの比較。
		/// </summary>
		NotEqual = 0x0020,
		/// <summary>
		/// 前方一致による比較。
		/// </summary>
		FrontCoincidence = 0x0040,
		/// <summary>
		/// 後方一致による比較。
		/// </summary>
		BackCoincidence = 0x0080,
		/// <summary>
		/// 部分一致による比較。
		/// </summary>
		PartialCoincidence = 0x0100
	}

	/// <summary>
	/// 検索の対象
	/// </summary>
	[Flags]
	public enum SearchTarget
	{
		/// <summary>
		/// コード検索
		/// </summary>
		Code = 0x01,
		/// <summary>
		/// カナ検索
		/// </summary>
		Kana = 0x02,
		/// <summary>
		/// 得意先カナ名検索
		/// </summary>
		CustKana = 0x04,
		/// <summary>
		/// 部門コード検索
		/// </summary>
		DeptCode = 0x08,
		/// <summary>
		/// 名称検索
		/// </summary>
		Name = 0x10
	}
}
