// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : ConvertStringData.cs
// 機能名      : DBデータの文字列変換
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

namespace Infocom.Allegro.BL.SqlClient
{
	/// <summary>
	/// データベースから取得した値を適切な文字列形式に変換するための共通機能を提供します。
	/// </summary>
	public sealed class ConvertStringData
	{
		private ConvertStringData()
		{
		}

		/// <summary>
		/// <see cref="DateTime"/>が格納された<see cref="object"/>を文字列に変換します。
		/// </summary>
		/// <param name="value">
		/// 変換する値。時刻以下は無視されます。
		/// </param>
		/// <returns>
		/// 変換後の文字列。
		/// </returns>
		public static string ToDateTimeString(object value)
		{
			return ToDateTimeString(value, DateTimeType.Date);
		}

		/// <summary>
		/// <see cref="DateTime"/>が格納された<see cref="object"/>を文字列に変換します。
		/// </summary>
		/// <param name="value">
		/// 変換する値。
		/// </param>
		/// <param name="type">
		/// 変換の種類。
		/// </param>
		/// <returns>
		/// 変換後の文字列。
		/// </returns>
		public static string ToDateTimeString(object value, DateTimeType type)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "オブジェクト参照がオブジェクト インスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM000516"));
			}
			if (value is DateTime)
			{
				switch (type)
				{
					case DateTimeType.DateTime:
						return ((DateTime) value).ToString("yyyy/MM/dd HH:mm:ss");
					case DateTimeType.Date:
						return ((DateTime) value).ToString("yyyy/MM/dd");
					case DateTimeType.Month:
						return ((DateTime) value).ToString("yyyy/MM");
					default:
// 						throw new ArgumentException("DateTimeType にない値です。", "type"); //K24546
						throw new ArgumentException(MultiLanguage.Get("CM_AM000439"), "type");
				}
			}
			else if (value is DBNull)
			{
				return string.Empty;
			}
			else
			{
// 				throw new ArgumentException("パラメータは DBNull クラスか DateTime 構造体のインスタンスでなくてはいけません。", "value"); //K24546
				throw new ArgumentException(MultiLanguage.Get("CM_AM000639"), "value");
			}
		}
	}

	/// <summary>
	/// <see cref="System.DateTime"/>型のオブジェクト内で有効な精度の種類。
	/// </summary>
	public enum DateTimeType
	{
		/// <summary>
		/// 日時
		/// </summary>
		DateTime,
		/// <summary>
		/// 日付
		/// </summary>
		Date,
		/// <summary>
		/// 年月
		/// </summary>
		Month
	}
}
