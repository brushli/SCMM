// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : ControlFormat.cs
// 機能名      : 数値項目整形
// Version     : 3.1.0
// Last Update : 2020/06/30
// Copyright (c) 2004-2020 Grandit Corp. All Rights Reserved.
//
// 管理番号 K25647 2015/02/27 項目桁数拡張
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 3.0.0 2018/04/30
// 管理番号K27057 2019/09/10 汎用項目追加
// 3.1.0 2020/06/30

using System;

namespace Infocom.Allegro.Web
{
	/// <summary>
	/// 伝票単位数量、在庫表示単位数量、伝票単価、原単価、在庫単価の書式の取得、及び書式設定後の文字列を取得する共通関数を提供します。
	/// このクラスは継承できません。
	/// </summary>
	public sealed class ControlFormat
	{
		#region Constructors
		private ControlFormat()
		{
		}
		#endregion Constructors

		#region Methods
		/// <summary>
		/// 伝票単位数量の書式設定後の文字列を取得します。
		/// </summary>
		/// <param name="value">
		/// 書式設定対象の数値。
		/// </param>
		/// <param name="qtDecimalDigit">
		/// 数量小数桁数
		/// </param>
		/// <param name="formatType">
		/// 書式タイプ
		/// </param>
		/// <returns>
		/// 伝票単位数量の書式設定後の文字列。
		/// </returns>
		public static string ToSlipQt(decimal value, byte qtDecimalDigit, FormatType formatType)
		{
			return value.ToString(GetSlipQtFormat(qtDecimalDigit, formatType));
		}

		/// <summary>
		/// 在庫表示単位数量の書式設定後の文字列を取得します。
		/// </summary>
		/// <param name="value">
		/// 書式設定対象の数値。
		/// </param>
		/// <param name="qtDecimalUseFlg">
		/// 小数桁を使用する：true、小数桁を使用しない：false
		/// </param>
		/// <param name="formatType">
		/// 書式タイプ
		/// </param>
		/// <returns>
		/// 在庫表示単位数量の書式設定後の文字列。
		/// </returns>
		public static string ToStockQt(decimal value, bool qtDecimalUseFlg, FormatType formatType)
		{
			return value.ToString(GetStockQtFormat(qtDecimalUseFlg, formatType));
		}

		/// <summary>
		/// 伝票単価の書式設定後の文字列を取得します。
		/// </summary>
		/// <param name="value">
		/// 書式設定対象の数値。
		/// </param>
		/// <param name="priceDecimalDigit">
		/// 単価小数桁数
		/// </param>
		/// <param name="currencyDigit">
		/// 通貨小数桁数
		/// </param>
		/// <param name="formatType">
		/// 書式タイプ
		/// </param>
		/// <returns>
		/// 伝票単価の書式設定後の文字列。
		/// </returns>
		public static string ToSlipPrice(decimal value, byte priceDecimalDigit, byte currencyDigit, FormatType formatType)
		{
			return value.ToString(GetSlipPriceFormat(priceDecimalDigit, currencyDigit, formatType));
		}

		/// <summary>
		/// 原単価、在庫単価の書式設定後の文字列を取得します。
		/// </summary>
		/// <param name="value">
		/// 書式設定対象の数値。
		/// </param>
		/// <param name="formatType">
		/// 書式タイプ
		/// </param>
		/// <returns>
		/// 原単価、在庫単価の書式設定後の文字列。
		/// </returns>
		public static string ToStockPrice(decimal value, FormatType formatType)
		{
			return value.ToString(GetStockPriceFormat(formatType));
		}

		/// <summary>
		/// 伝票単位数量の書式設定後の文字列を取得します。
		/// </summary>
		/// <param name="value">
		/// 書式設定対象の文字列。
		/// </param>
		/// <param name="qtDecimalDigit">
		/// 数量小数桁数
		/// </param>
		/// <param name="formatType">
		/// 書式タイプ
		/// </param>
		/// <returns>
		/// 伝票単位数量の書式設定後の文字列。
		/// </returns>
		public static string ToSlipQt(string value, byte qtDecimalDigit, FormatType formatType)
		{
			decimal decimalValue = 0M;
			if (value.Length == 0)
			{
				//空白の場合
				return value;
			}
			
			if (!decimal.TryParse(value, out decimalValue))
			{
				//数値ではない場合
				return value;
			}

			return decimalValue.ToString(GetSlipQtFormat(qtDecimalDigit, formatType));
		}

		/// <summary>
		/// 在庫表示単位数量の書式設定後の文字列を取得します。
		/// </summary>
		/// <param name="value">
		/// 書式設定対象の文字列。
		/// </param>
		/// <param name="qtDecimalUseFlg">
		/// 小数桁を使用する：true、小数桁を使用しない：false
		/// </param>
		/// <param name="formatType">
		/// 書式タイプ
		/// </param>
		/// <returns>
		/// 在庫表示単位数量の書式設定後の文字列。
		/// </returns>
		public static string ToStockQt(string value, bool qtDecimalUseFlg, FormatType formatType)
		{
			decimal decimalValue = 0M;
			if (value.Length == 0)
			{
				//空白の場合
				return value;
			}
			
			if (!decimal.TryParse(value, out decimalValue))
			{
				//数値ではない場合
				return value;
			}

			return decimalValue.ToString(GetStockQtFormat(qtDecimalUseFlg, formatType));
		}

		/// <summary>
		/// 伝票単価の書式設定後の文字列を取得します。
		/// </summary>
		/// <param name="value">
		/// 書式設定対象の文字列。
		/// </param>
		/// <param name="priceDecimalDigit">
		/// 単価小数桁数
		/// </param>
		/// <param name="currencyDigit">
		/// 通貨小数桁数
		/// </param>
		/// <param name="formatType">
		/// 書式タイプ
		/// </param>
		/// <returns>
		/// 伝票単価の書式設定後の文字列。
		/// </returns>
		public static string ToSlipPrice(string value, byte priceDecimalDigit, byte currencyDigit, FormatType formatType)
		{
			decimal decimalValue = 0M;
			if (value.Length == 0)
			{
				//空白の場合
				return value;
			}

			if (!decimal.TryParse(value, out decimalValue))
			{
				//数値ではない場合
				return value;
			}

			return decimalValue.ToString(GetSlipPriceFormat(priceDecimalDigit, currencyDigit, formatType));
		}

		/// <summary>
		/// 原単価、在庫単価の書式設定後の文字列を取得します。
		/// </summary>
		/// <param name="value">
		/// 書式設定対象の文字列。
		/// </param>
		/// <param name="formatType">
		/// 書式タイプ
		/// </param>
		/// <returns>
		/// 原単価、在庫単価の書式設定後の文字列。
		/// </returns>
		public static string ToStockPrice(string value, FormatType formatType)
		{
			decimal decimalValue = 0M;
			if (value.Length == 0)
			{
				//空白の場合
				return value;
			}

			if (!decimal.TryParse(value, out decimalValue))
			{
				//数値ではない場合
				return value;
			}

			return decimalValue.ToString(GetStockPriceFormat(formatType));
		}

// 管理番号K27057 From
		/// <summary>
		/// 汎用項目の数値項目の書式設定後の文字列を取得します。
		/// </summary>
		/// <param name="value">
		/// 書式設定対象の文字列。
		/// </param>
		/// <param name="ttl">
		/// 桁数（総数）
		/// </param>
		/// <param name="acc">
		/// 桁数（精度）
		/// </param>
		/// <param name="formatType">
		/// 書式タイプ
		/// </param>
		/// <returns>
		/// 書式設定後の文字列。
		/// </returns>
		public static string ToCustomItemNumber(string value, byte ttl, byte acc, FormatType formatType)
		{
			decimal decimalValue = 0M;
			if (value.Length == 0)
			{
				//空白の場合
				return value;
			}
			if (!decimal.TryParse(value, out decimalValue))
			{
				//数値ではない場合
				return value;
			}
			return decimalValue.ToString(CreateFormatString(acc, ttl, formatType));
		}
// 管理番号K27057 To

		/// <summary>
		/// 伝票単位数量の書式設定文字列を取得します。
		/// </summary>
		/// <param name="qtDecimalDigit">
		/// 数量小数桁数
		/// </param>
		/// <param name="formatType">
		/// 書式タイプ
		/// </param>
		/// <returns>
		/// 伝票単位数量の書式設定文字列。
		/// </returns>
		public static string GetSlipQtFormat(byte qtDecimalDigit, FormatType formatType)
		{
			return CreateFormatString(qtDecimalDigit, 4, formatType);
		}

		/// <summary>
		/// 在庫表示単位数量の書式設定文字列を取得します。
		/// </summary>
		/// <param name="qtDecimalUseFlg">
		/// 小数桁を使用する：true、小数桁を使用しない：false
		/// </param>
		/// <param name="formatType">
		/// 書式タイプ
		/// </param>
		/// <returns>
		/// 在庫表示単位数量の書式設定文字列。
		/// </returns>
		public static string GetStockQtFormat(bool qtDecimalUseFlg, FormatType formatType)
		{
			return CreateFormatString(qtDecimalUseFlg ? (byte)4 : (byte)0, 4, formatType);
		}

		/// <summary>
		/// 伝票単価の書式設定文字列を取得します。
		/// </summary>
		/// <param name="priceDecimalDigit">
		/// 単価小数桁数
		/// </param>
		/// <param name="currencyDigit">
		/// 通貨小数桁数
		/// </param>
		/// <param name="formatType">
		/// 書式タイプ
		/// </param>
		/// <returns>
		/// 伝票単価の書式設定文字列。
		/// </returns>
		public static string GetSlipPriceFormat(byte priceDecimalDigit, byte currencyDigit, FormatType formatType)
		{
			return CreateFormatString(priceDecimalDigit == 0 ? currencyDigit : priceDecimalDigit, 5, formatType);
		}

		/// <summary>
		/// 原単価、在庫単価の書式設定文字列を取得します。
		/// </summary>
		/// <param name="formatType">
		/// 書式タイプ
		/// </param>
		/// <returns>
		/// 原単価、在庫単価の書式設定文字列。
		/// </returns>
		public static string GetStockPriceFormat(FormatType formatType)
		{
			return CreateFormatString(5, 5, formatType);
		}

		/// <summary>
		/// 書式設定する為の文字列を生成します。
		/// </summary>
		/// <param name="digit">小数桁数</param>
		/// <param name="maxDigit">最大小数桁数</param>
		/// <param name="formatType">書式タイプ</param>
		/// <returns>書式設定文字列</returns>
		private static string CreateFormatString(byte digit, byte maxDigit, FormatType formatType)
		{
			switch (formatType)
			{
				case FormatType.Display:
					//表示項目の場合
					//整数部はカンマ区切りする、小数部はゼロパディングする

					//小数桁数分0埋めし、最大小数桁まで#埋めする
					return "#,0." + new string('0', digit).PadRight(maxDigit, '#');
				case FormatType.Input:
					//入力項目の場合
					//整数部はカンマ区切りしない、小数部はゼロサプレスする

					//最大小数桁まで#埋めする
					return "#0." + new string('#', maxDigit);
				case FormatType.Export:
// 管理番号K27057 From
				case FormatType.DataBase:
// 管理番号K27057 To
					//出力項目の場合
					//整数部はカンマ区切りしない、小数部はゼロパディングする

					//小数桁数分0埋めし、最大小数桁まで#埋めする
					return "#0." + new string('0', digit).PadRight(maxDigit, '#');
			}

			return string.Empty;
		}
		#endregion Methods

		/// <summary>
		/// 書式タイプ
		/// </summary>
		public enum FormatType
		{
			/// <summary>
			/// 表示項目
			/// </summary>
			Display,
			/// <summary>
			/// 入力項目
			/// </summary>
			Input,
			/// <summary>
			/// 出力項目
			/// </summary>
			Export,
// 管理番号K27057 From
			/// <summary>
			/// DB項目
			/// </summary>
			DataBase,
// 管理番号K27057 To
		}
	}
}
