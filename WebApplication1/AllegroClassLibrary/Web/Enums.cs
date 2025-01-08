// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : Enums.cs
// 機能名      : 共通列挙型定義（Web）
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;

namespace Infocom.Allegro.Web
{
	/// <summary>
	/// Webページの画面モード。
	/// </summary>
	public enum PageMode
	{
		/// <summary>
		/// 新規モード
		/// </summary>
		Insert,
		/// <summary>
		/// 修正モード
		/// </summary>
		Update,
		/// <summary>
		/// 参照モード
		/// </summary>
		Reference,
	}
}
