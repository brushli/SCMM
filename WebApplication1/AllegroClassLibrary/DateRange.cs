// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : DateRange.cs
// 機能名      : 日付範囲チェック
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

namespace Infocom.Allegro
{
	/// <summary>
	/// 日付範囲チェックに関する共通機能を提供します。このクラスは継承できません。
	/// </summary>
	public sealed class DateRange
	{
		/// <summary>
		/// GRANDITにおける有効な日付の最小値（1900/01/01）。
		/// </summary>
		public static readonly DateTime MinValue = new DateTime(1900, 1, 1);

		/// <summary>
		/// GRANDITにおける有効な日付の最大値（9998/12/31）。
		/// </summary>
		public static readonly DateTime MaxValue = new DateTime(9998, 12, 31);

		#region Constructors
		private DateRange()
		{
		}
		#endregion

		#region Properties
// 管理番号K25904 From
//		public static DateTime DefaultValue
		private static DateTime DefaultValue
// 管理番号K25904 To
		{
// 			get {throw new FormatException("日付の書式が不正です。");} //K24546
			get { throw new FormatException(MultiLanguage.Get("CM_AM001292")); }
		}
		#endregion

		#region Methods
		/// <summary>
		/// 文字列をGRANDITで有効な日付に変換します。変換できなかった場合、例外が発生します。
		/// </summary>
		/// <param name="s">
		/// 変換する日付の文字列形式。
		/// </param>
		/// <returns>
		/// 変換後の日付。
		/// </returns>
		public static DateTime ToDateTime(string s)
		{
			if (s == null)
			{
// 				throw new ArgumentNullException("s", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("s", MultiLanguage.Get("CM_AM001376"));
			}
			if (s.Length == 0)
			{
				return DefaultValue;
			}
			string[] yearMonthDate = s.Split(new char[] {'/', '-', '.'}, 3);
			if (yearMonthDate.Length == 1)
			{
				if (s.Length == 8)
				{
					for (int i = 0; i < 8; i++)
					{
						if (s[i] < '0' || '9' < s[i])
						{
							return DefaultValue;
						}
					}
					int year = int.Parse(s.Substring(0, 4));
					try
					{
						DateTime result = new DateTime(year, int.Parse(s.Substring(4, 2)), int.Parse(s.Substring(6, 2)));
						if (year < 1900)
						{
							return new DateTime(1900, 1, 1);
						}
						else if (9998 < year)
						{
							return new DateTime(9998, 12, 31);
						}
						return result;
					}
					catch (ArgumentOutOfRangeException)
					{
						return DefaultValue;
					}
				}
			}
			else if (yearMonthDate.Length == 3)
			{
				for (int i = 0; i < 3; i++)
				{
					foreach (char c in yearMonthDate[i])
					{
						if (c < '0' || '9' < c)
						{
							return DefaultValue;
						}
					}
				}
				int year = int.Parse(yearMonthDate[0]);
				switch (yearMonthDate[0].Length)
				{
					case 2:
						year += (year < 50 ? 2000 : 1900);
						try
						{
							return new DateTime(year, int.Parse(yearMonthDate[1]), int.Parse(yearMonthDate[2]));
						}
						catch (ArgumentOutOfRangeException)
						{
							return DefaultValue;
						}
					case 4:
						try
						{
							DateTime result = new DateTime(year, int.Parse(yearMonthDate[1]), int.Parse(yearMonthDate[2]));
							if (year < 1900)
							{
								return new DateTime(1900, 1, 1);
							}
							else if (9998 < year)
							{
								return new DateTime(9998, 12, 31);
							}
							return result;
						}
						catch (ArgumentOutOfRangeException)
						{
							return DefaultValue;
						}
				}
			}
			return DefaultValue;
		}

		/// <summary>
		/// 文字列をGRANDITで有効な日付に変換します。変換できなかった場合、<see cref="DateTime.MinValue"/>を返します。
		/// </summary>
		/// <param name="s">
		/// 変換する日付の文字列形式。
		/// </param>
		/// <returns>
		/// 変換後の日付。
		/// </returns>
		internal static DateTime ToDateTimeNoException(string s)
		{
			if (s == null)
			{
// 				throw new ArgumentNullException("s", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("s", MultiLanguage.Get("CM_AM001376"));
			}
			if (s.Length == 0)
			{
				return DateTime.MinValue;
			}
			string[] yearMonthDate = s.Split(new char[] {'/', '-', '.'}, 3);
			if (yearMonthDate.Length == 1)
			{
				if (s.Length == 8)
				{
					for (int i = 0; i < 8; i++)
					{
						if (s[i] < '0' || '9' < s[i])
						{
							return DateTime.MinValue;
						}
					}
					int year = int.Parse(s.Substring(0, 4));
					try
					{
						DateTime result = new DateTime(year, int.Parse(s.Substring(4, 2)), int.Parse(s.Substring(6, 2)));
						if (year < 1900)
						{
							return new DateTime(1900, 1, 1);
						}
						else if (9998 < year)
						{
							return new DateTime(9998, 12, 31);
						}
						return result;
					}
					catch (ArgumentOutOfRangeException)
					{
						return DateTime.MinValue;
					}
				}
			}
			else if (yearMonthDate.Length == 3)
			{
				for (int i = 0; i < 3; i++)
				{
					foreach (char c in yearMonthDate[i])
					{
						if (c < '0' || '9' < c)
						{
							return DateTime.MinValue;
						}
					}
				}
				int year = int.Parse(yearMonthDate[0]);
				switch (yearMonthDate[0].Length)
				{
					case 2:
						year += (year < 50 ? 2000 : 1900);
						try
						{
							return new DateTime(year, int.Parse(yearMonthDate[1]), int.Parse(yearMonthDate[2]));
						}
						catch (ArgumentOutOfRangeException)
						{
							return DateTime.MinValue;
						}
					case 4:
						try
						{
							DateTime result = new DateTime(year, int.Parse(yearMonthDate[1]), int.Parse(yearMonthDate[2]));
							if (year < 1900)
							{
								return new DateTime(1900, 1, 1);
							}
							else if (9998 < year)
							{
								return new DateTime(9998, 12, 31);
							}
							return result;
						}
						catch (ArgumentOutOfRangeException)
						{
							return DateTime.MinValue;
						}
				}
			}
			return DateTime.MinValue;
		}
		#endregion
	}
}
