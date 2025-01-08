// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : Enums.cs
// 機能名      : 共通列挙型定義（帳票）
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;

namespace Infocom.Allegro.Report
{
	/// <summary>
	/// 帳票に関する定数の定義です。
	/// </summary>
	public class Constants
	{
		/// <summary>
		/// 帳票画面に検索条件等を渡す場合に使用するセッション名。セッションを複数使用する場合は<see cref="Report.Constants.SessionName"/>＋"_"＋固有値としてください。
		/// </summary>
		public const string SessionName = "ReportSession";
		/// <summary>
		/// 帳票画面の動作を制御するための定数値。
		/// </summary>
		public const string PrintTerm = "PrintTerm";
		/// <summary>
		/// 帳票画面の動作を制御するための定数値。
		/// </summary>
		public const string PrevTerm = "PrevTerm";
		/// <summary>
		/// 帳票画面の動作を制御するための定数値。
		/// </summary>
		public const string Input = "Input";
		/// <summary>
		/// 帳票画面の動作を制御するための定数値。
		/// </summary>
		public const string ReportPrint = "ReportPrint";
	}

	/// <summary>
	/// 帳票出力を指示した画面の種類。
	/// </summary>
	public enum ScreenType
	{
		/// <summary>
		/// 入力画面
		/// </summary>
		Input,
		/// <summary>
		/// 帳票出力画面
		/// </summary>
		ReportPrint
	}
}
