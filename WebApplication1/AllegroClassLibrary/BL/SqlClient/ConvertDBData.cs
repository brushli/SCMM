// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : ConvertDBData.cs
// 機能名      : SQLパラメータへの型変換
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 3.1.0 2020/06/30
// 管理番号K27230 2020/12/16 脆弱性対応
// 3.2.0 2023/03/31

using System;

namespace Infocom.Allegro.BL.SqlClient
{
	/// <summary>
	/// <see cref="System.Data.SqlClient.SqlParameter"/>の<see cref="System.Data.SqlClient.SqlParameter.Value"/>に渡すためのデータを生成するための共通機能を提供します。
	/// </summary>
	public sealed class ConvertDBData
	{
		private ConvertDBData()
		{
		}

		/// <summary>
		/// 文字列を<see cref="System.Data.SqlClient.SqlParameter"/>の<see cref="System.Data.SqlClient.SqlParameter.Value"/>に渡すために適切な型変換を実行します。
		/// </summary>
		/// <param name="value">
		/// 変換する文字列。
		/// </param>
		/// <returns>
		/// <paramref name="value"/>が空の文字列もしくはnullの場合、<see cref="DBNull.Value"/>。それ以外の場合は<paramref name="value"/>。
		/// </returns>
		/// <remarks>
		/// NVARCHAR型の列に空の文字列でなくNULLを挿入したい場合、このメソッドを使用してください。
		/// </remarks>
		public static object ToNVarChar(string value)
		{
			if (value == null || value.Length == 0)
			{
				return DBNull.Value;
			}
			else
			{
				return value;
			}
		}

// 管理番号K27230 From
		/// <summary>
		/// 文字列を<see cref="System.Data.SqlClient.SqlParameter"/>の<see cref="System.Data.SqlClient.SqlParameter.Value"/>に渡すために適切な型変換を実行します。
		/// </summary>
		/// <param name="value">
		/// 変換する文字列。
		/// </param>
		/// <returns>
		/// <paramref name="value"/>がnullの場合、空の文字列。それ以外の場合は<paramref name="value"/>。
		/// </returns>
		/// <remarks>
		/// NVARCHAR型の列にNULLでなく空の文字列を挿入したい場合、このメソッドを使用してください。
		/// </remarks>
		public static string ToNVarCharForEmpty(string value)
		{
			if (value == null)
			{
				return string.Empty;
			}
			else
			{
				return value;
			}
		}

// 管理番号K27230 To
		/// <summary>
		/// 論理値を<see cref="System.Data.SqlClient.SqlParameter"/>の<see cref="System.Data.SqlClient.SqlParameter.Value"/>に渡すために適切な型変換を実行します。
		/// </summary>
		/// <param name="value">
		/// 変換する論理値。
		/// </param>
		/// <returns>
		/// <paramref name="value"/>がtrueの場合、"1"。それ以外の場合は"0"。
		/// </returns>
		/// <remarks>
		/// フラグの値をNVARCHAR(1)の列に挿入したい場合、このメソッドを使用してください。
		/// </remarks>
		public static object ToNVarChar(bool value)
		{
			return value ? "1" : "0";
		}

		/// <summary>
		/// 日付が格納された文字列を<see cref="System.Data.SqlClient.SqlParameter"/>の
		/// <see cref="System.Data.SqlClient.SqlParameter.Value"/>に渡すために適切な型変換を実行します。
		/// </summary>
		/// <param name="value">
		/// 変換する文字列。
		/// </param>
		/// <returns>
		/// <paramref name="value"/>が空の文字列もしくはnullの場合、<see cref="DBNull.Value"/>。
		/// それ以外の場合は<paramref name="value"/>を<see cref="System.DateTime"/>に変換した値。
		/// </returns>
		public static object ToDateTime(string value)
		{
			return ToDateTime(value, DateTimeType.Date);
		}

		/// <summary>
		/// 日付が格納された文字列を<see cref="System.Data.SqlClient.SqlParameter"/>の
		/// <see cref="System.Data.SqlClient.SqlParameter.Value"/>に渡すために適切な型変換を実行します。
		/// </summary>
		/// <param name="value">
		/// 変換する文字列。
		/// </param>
		/// <param name="type">
		/// <see cref="DateTime"/>型のオブジェクト内で有効な精度の種類。
		/// </param>
		/// <returns>
		/// <paramref name="value"/>が空の文字列もしくはnullの場合、<see cref="DBNull.Value"/>。
		/// それ以外の場合は<paramref name="value"/>を<see cref="DateTime"/>に変換した値。
		/// </returns>
		public static object ToDateTime(string value, DateTimeType type)
		{
			if (value == null || value.Length == 0)
			{
				return DBNull.Value;
			}
			else
			{
				switch (type)
				{
					case DateTimeType.DateTime:
					case DateTimeType.Date:
						return DateTime.Parse(value);
					case DateTimeType.Month:
						return DateTime.Parse(value + "/01");
					default:
// 						throw new ArgumentException("DateTimeType にない値です。", "type"); //K24546
						throw new ArgumentException(MultiLanguage.Get("CM_AM000439"), "type");
				}
			}
		}

		/// <summary>
		/// 数値が格納された文字列を<see cref="System.Data.SqlClient.SqlParameter"/>の
		/// <see cref="System.Data.SqlClient.SqlParameter.Value"/>に渡すために適切な型変換を実行します。
		/// </summary>
		/// <param name="value">
		/// 変換する文字列。
		/// </param>
		/// <returns>
		/// <paramref name="value"/>が空の文字列もしくはnullの場合、<see cref="DBNull.Value"/>。
		/// それ以外の場合は<paramref name="value"/>を<see cref="decimal"/>に変換した値。
		/// </returns>
		/// <exception cref="FormatException"><paramref name="value"/> の書式が正しくありません。</exception>
		/// <exception cref="OverflowException"><paramref name="value"/> が <see cref="System.Decimal.MinValue"/> 未満の数値か、 <see cref="System.Decimal.MaxValue"/> より大きい数値を表しています。</exception>
		public static object ToDecimal(string value)
		{
			if (value == null || value.Length == 0)
			{
				return DBNull.Value;
			}
			else
			{
				return decimal.Parse(value);
			}
		}
	}
}
