// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : NumberBoxPreset.cs
// 機能名      : 数値カスタムコントロール用書式設定ヘルパー
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 管理番号 K25647 2015/02/27 項目桁数拡張
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using Infocom.Allegro.Web.WebControls;

namespace Infocom.Allegro.Web
{
	/// <summary>
	/// <see cref="NumberBox"/>における伝票単位数量、在庫表示単位数量、伝票単価、原単価、在庫単価の入力書式を設定する共通関数を提供します。
	/// このクラスは継承できません。
	/// </summary>
	public sealed class NumberBoxPreset
	{
		#region Constructors
		private NumberBoxPreset()
		{
		}
		#endregion Constructors

		#region Methods
		/// <summary>
		/// 伝票単位数量の入力書式を設定します。
		/// </summary>
		/// <param name="numberBox">
		/// 設定対象となる<see cref="NumberBox"/>。
		/// </param>
		/// <param name="quantityType">
		/// 整数部の桁数を設定するための伝票単位数量の種類。
		/// </param>
		/// <param name="allowNegative">
		/// 負数を許可する：true、負数を許可しない：false
		/// </param>
		/// <param name="qtDecimalDigit">
		/// 自社マスタ.数量小数桁数
		/// </param>
		public static void SetSlipQuantityMode(NumberBox numberBox, SlipQuantity quantityType, bool allowNegative, byte qtDecimalDigit)
		{
			numberBox.Scale = qtDecimalDigit;

			switch(quantityType)
			{
				case SlipQuantity.SCSD:
				case SlipQuantity.FIAR:
				case SlipQuantity.FIAP:
					numberBox.Precision = (byte)(6 + qtDecimalDigit);
					break;
				case SlipQuantity.SCMM:
				case SlipQuantity.FIGL:
					numberBox.Precision = (byte)(9 + qtDecimalDigit);
					break;
			}

			numberBox.AllowDecimal = numberBox.Scale > 0;
			numberBox.AllowNegative = allowNegative;
			SetMaxLength(numberBox);
		}

		/// <summary>
		/// 在庫表示単位数量の入力書式を設定します。
		/// </summary>
		/// <param name="numberBox">
		/// 設定対象となる<see cref="NumberBox"/>。
		/// </param>
		/// <param name="allowNegative">
		/// 負数を許可する：true、負数を許可しない：false
		/// </param>
		/// <param name="qtDecimalUseFlg">
		/// 小数桁を使用する：true、小数桁を使用しない：false
		/// </param>
		public static void SetStockQuantityMode(NumberBox numberBox, bool allowNegative, bool qtDecimalUseFlg)
		{
			numberBox.Scale = (byte)(qtDecimalUseFlg ? 4 : 0);
			numberBox.Precision = (byte)(qtDecimalUseFlg ? 13 : 9);
			numberBox.AllowDecimal = numberBox.Scale > 0;
			numberBox.AllowNegative = allowNegative;
			SetMaxLength(numberBox);
		}

		/// <summary>
		/// 伝票単価の入力書式を設定します。
		/// </summary>
		/// <param name="numberBox">
		/// 設定対象となる<see cref="NumberBox"/>。
		/// </param>
		/// <param name="allowNegative">
		/// 負数を許可する：true、負数を許可しない：false
		/// </param>
		/// <param name="priceDecimalDigit">
		/// 自社マスタ.単価小数桁数
		/// </param>
		/// <param name="currencyDigit">
		/// 通貨マスタ.小数桁数
		/// </param>
		public static void SetSlipPriceMode(NumberBox numberBox, bool allowNegative, byte priceDecimalDigit, byte currencyDigit)
		{
			numberBox.Scale = priceDecimalDigit == 0 ? currencyDigit : priceDecimalDigit;
			numberBox.Precision = (byte)(11 + numberBox.Scale);
			numberBox.AllowDecimal = numberBox.Scale > 0;
			numberBox.AllowNegative = allowNegative;
			SetMaxLength(numberBox);
		}

		/// <summary>
		/// 原単価、在庫単価の入力書式を設定します。
		/// </summary>
		/// <param name="numberBox">
		/// 設定対象となる<see cref="NumberBox"/>。
		/// </param>
		/// <param name="allowNegative">
		/// 負数を許可する：true、負数を許可しない：false
		/// </param>
		public static void SetStockPriceMode(NumberBox numberBox, bool allowNegative)
		{
			numberBox.Scale = 5;
			numberBox.Precision = 16;
			numberBox.AllowDecimal = true;
			numberBox.AllowNegative = allowNegative;
			SetMaxLength(numberBox);
		}

		/// <summary>
		/// NumberBox.Precision
		/// NumberBox.AllowDecimal
		/// NumberBox.AllowNegative
		/// の状態からNumberBox.MaxLengthを設定します。
		/// </summary>
		/// <param name="numberBox">
		/// 設定対象となる<see cref="NumberBox"/>。
		/// </param>
		public static void SetMaxLength(NumberBox numberBox)
		{
			//小数桁を使用する場合、"."を入力する為、1桁増やす
			//マイナスの値を許可する場合、"-"を入力する為、1桁増やす
			numberBox.MaxLength = numberBox.Precision + (numberBox.AllowDecimal ? 1 : 0) + (numberBox.AllowNegative ? 1 : 0);
		}
		#endregion Methods

		/// <summary>
		/// 整数部の桁数を決定するために用いる伝票単位数量の種類。
		/// <para>呼び出し元のモジュールとは必ずしも一致しません。</para>
		/// </summary>
		public enum SlipQuantity
		{
			/// <summary>販売数量</summary>
			SCSD,
			/// <summary>調達在庫数量</summary>
			SCMM,
			/// <summary>債権数量</summary>
			FIAR,
			/// <summary>債務数量</summary>
			FIAP,
			/// <summary>経理数量</summary>
			FIGL,
		}
	}
}
