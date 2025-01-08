// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : DateValidator.cs
// 機能名      : 日付チェック
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;
using System.Globalization;

namespace Infocom.Allegro
{
	/// <summary>
	/// 日付チェックに関する共通機能を提供します。このクラスは継承できません。
	/// </summary>
	public sealed class DateValidator
	{
		#region Constructors
		private DateValidator()
		{
		}
		#endregion

		#region Methods
		/// <summary>
		/// 指定された文字列が日付として妥当かどうかを示します。範囲チェックは行っていません。
		/// </summary>
		/// <param name="value">
		/// 評価する文字列。
		/// </param>
		/// <returns>
		/// 妥当な日付の場合：true、それ以外の場合：false
		/// </returns>
		public static bool IsDate(string value)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (value.Length == 0)
			{
				return false;
			}
			string[] yearMonthDate = value.Split(new char[] {'/', '-', '.'}, 3);
			if (yearMonthDate.Length != 3)
			{
				return false;
			}
			string century = string.Empty;
			switch (yearMonthDate[0].Length)
			{
				case 2:
					try
					{
						int year = int.Parse(yearMonthDate[0]);
						century = (year < 50 ? "20" : "19");
					}
					catch (FormatException)
					{
						return false;
					}
					break;
				case 4:
					break;
				default:
					return false;
			}
			// TODO 日本語カルチャのみ
			try
			{
				DateTime date = DateTime.Parse(century + value, CultureInfo.CreateSpecificCulture("ja-JP"));
				return true;
			}
			catch (FormatException)
			{
				return false;
			}
		}
		#endregion
	}
}
