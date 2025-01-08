// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : StringChecker.cs
// 機能名      : 文字列チェック
// Version     : 3.1.0
// Last Update : 2020/06/30
// Copyright (c) 2004-2020 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.4.0 2005/10/31
// 管理番号B16832 2005/12/13 ①半角文字チェックオプションの追加(半角英数字・記号、半角カタカナ、半角スペース）
//				　			 ②EB振込依頼人・口座名義人用チェックオプションの追加
// 管理番号B17674 2006/03/28 半角カナの拗音、促音を自動変換しないチェックオプションの追加
// 1.5.0 2006/03/31　
// 1.6.0 2009/09/30
// 管理番号B23834 2010/11/11 手動採番時に伝票番号に「-」が指定できてしまう不具合対応
// 2.0.0 2012/10/31
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25879 2016/02/15 マイナンバー対応
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 3.0.0 2018/04/30
// 管理番号K27095 2020/04/01 全銀EDI対応
// 3.1.0 2020/06/30

using System;
using System.Text;

namespace Infocom.Allegro.IF
{
	/// <summary>
	/// 文字列チェックに関する共通機能を提供します。
	/// </summary>
	public class StringChecker
	{
		#region Private Fields
		private string code;
		private int maxLength;
		private bool isRequiredField;
		private CheckOption option;
		#endregion

		#region Constructors
		/// <summary>
		/// 指定した文字列に対するチェックを行う<see cref="StringChecker"/>のコンストラクタです。
		/// </summary>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		public StringChecker(string value) : this(value, 0, false, CheckOption.None)
		{
		}

		/// <summary>
		/// 指定した文字列に対するチェックを行う<see cref="StringChecker"/>のコンストラクタです。
		/// </summary>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="maxLength">
		/// 許容する最大桁数。
		/// </param>
		public StringChecker(string value, int maxLength) : this(value, maxLength, false, CheckOption.None)
		{
		}

		/// <summary>
		/// 指定した文字列に対するチェックを行う<see cref="StringChecker"/>のコンストラクタです。
		/// </summary>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="maxLength">
		/// 許容する最大桁数。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		public StringChecker(string value, int maxLength, bool isRequiredField) : this(value, maxLength, isRequiredField, CheckOption.None)
		{
		}

		/// <summary>
		/// 指定した文字列に対するチェックを行う<see cref="StringChecker"/>のコンストラクタです。
		/// </summary>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="maxLength">
		/// 許容する最大桁数。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="option">
		/// チェックの種類。
		/// </param>
		public StringChecker(string value, int maxLength, bool isRequiredField, CheckOption option)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (maxLength < 0)
			{
// 				throw new ArgumentOutOfRangeException("maxLength", "maxLength は 0 以上の整数でなくてはいけません。"); //K24546
				throw new ArgumentOutOfRangeException("maxLength", MultiLanguage.Get("CM_AM000491"));
			}
			this.code = value;
			this.maxLength = maxLength;
			this.isRequiredField = isRequiredField;
			this.option = option;
		}
		#endregion

		#region Methods
		/// <summary>
		/// コンストラクタで指定した文字列に対してチェックを行います。
		/// </summary>
		/// <param name="type">
		/// エラーの種類。
		/// </param>
		/// <returns>
		/// 文字列がチェック内容を満たしている場合：true、それ以外の場合：false
		/// </returns>
		public bool Validates(out ErrorType type)
		{
			if ((maxLength != 0) && (maxLength < code.Length))
			{
				type = ErrorType.Length;
				return false;
			}
			if ((code.Length == 0) && isRequiredField)
			{
				type = ErrorType.Require;
				return false;
			}
			switch (option)
			{
				case CheckOption.SingleByte:
					type = ErrorType.Option;
					return IsAllSingleByte();
				case CheckOption.FullSizeKatakana:
					type = ErrorType.Option;
					return IsAllKatakana();
			}
			type = ErrorType.None;
			return true;
		}

		/// <summary>
		/// コンストラクタで指定した文字列に対してチェックを行います。
		/// </summary>
		/// <returns>
		/// 文字列がチェック内容を満たしている場合：true、それ以外の場合：false
		/// </returns>
		public bool Validates()
		{
			ErrorType type;
			return Validates(out type);
		}

		/// <summary>
		/// コンストラクタで指定した文字列がすべて半角文字であるかどうかを示します。
		/// </summary>
		/// <returns>
		/// 指定された文字列がすべて半角文字の場合：true、それ以外の場合：false
		/// </returns>
		public bool IsAllSingleByte()
		{
			for (int i = 0; i < code.Length; i++)
			{
				if (127 < code[i])
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// コンストラクタで指定した文字列がすべてひらがな・カタカナであるかどうかを示します。
		/// </summary>
		/// <returns>
		/// 指定された文字列がすべてひらがな・カタカナの場合：true、それ以外の場合：false
		/// </returns>
		public bool IsAllKana()
		{
			for (int i = 0; i < code.Length; i++)
			{
				if (((0x0080 <= code[i]) && (code[i] <= 0x3040)) || (0x3100 < code[i]))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// コンストラクタで指定した文字列がすべてカタカナであるかどうかを示します。
		/// </summary>
		/// <returns>
		/// 指定された文字列がすべてカタカナの場合：true、それ以外の場合：false
		/// </returns>
		public bool IsAllKatakana()
		{
			for (int i = 0; i < code.Length; i++)
			{
				if ((code[i] <= 0x30a0) || (0x3100 < code[i]))
				{
					return false;
				}
			}
			return true;
		}

		/// <summary>
		/// コンストラクタで指定した文字列を大文字に変換します。
		/// </summary>
		public void ToUpper()
		{
			code = code.ToUpper();
		}
		#endregion
	}

	/// <summary>
	/// 文字列に対するチェックの種類。
	/// </summary>
	[Flags]
	public enum CheckOption
	{
		/// <summary>
		/// チェックを行いません。
		/// </summary>
		None = 0x0000,
		/// <summary>
		/// コードとして使用可能な半角文字のみ許容します。
		/// </summary>
		SingleByte = 0x0001,
		/// <summary>
		/// 半角文字のみ許容します。
		/// </summary>
		EnglishName = 0x0002,
		/// <summary>
		/// 全角カタカナのみ許容します。
		/// </summary>
		FullSizeKatakana = 0x0004,
		/// <summary>
		/// 半角カタカナと半角スペースのみ許容します。
		/// <para>拗音、促音は自動変換されます。</para>
		/// </summary>
		SingleByteKatakana = 0x0008,
		/// <summary>
		/// 郵便番号チェックを行います。
		/// </summary>
		ZipCode = 0x0010,
		/// <summary>
		/// 電話番号・FAX番号チェックを行います。
		/// </summary>
		PhoneNo = 0x0020,
		/// <summary>
		/// ロット番号チェックを行います。
		/// </summary>
		LotNo = 0x0040,
// 管理番号B16832 From
		/// <summary>
		/// 半角英数字・半角カタカナ・半角記号・半角スペースを許容します。
		/// <para><see cref="EnglishName"/>＋<see cref="SingleByteKatakana"/>のチェックです。</para>
		/// </summary>
		HalfWidthANK = 0x0080,
		/// <summary>
		/// EBデータ用の振込依頼人・口座名義人に使用可能な文字のみ許容します。
		/// <para>半角カタカナの拗音、促音や半角英小文字は自動変換されます。</para>
		/// </summary>
		JBAAcHolder = 0x0100,
// 管理番号B16832 To
// 管理番号B17674 From
		/// <summary>
		/// 半角カタカナと半角スペースのみ許容します。
		/// <para>拗音、促音を自動変換しません。</para>
		/// </summary>
// 管理番号B23834 From
//		SingleByteKatakana2 = 0x0200
		SingleByteKatakana2 = 0x0200,
// 管理番号B23834 To
// 管理番号B17674 To
// 管理番号B23834 From
		/// <summary>
		/// ハイフン（-）を除く、コードとして使用可能な半角文字のみ許容します。
		/// </summary>
// 管理番号K25879 From
//      SingleByteHyphen = 0x0400
		SingleByteHyphen = 0x0400,
// 管理番号K25879 To
// 管理番号B23834 To
// 管理番号K25879 From
		/// <summary>
		/// 半角数字のみ許容します。
		/// </summary>
		SingleByteDigit = 0x0800,
// 管理番号K25879 To
// 管理番号K27095 From
		/// <summary>全銀協XML項目属性(C属性)</summary>
		XMLEbAttributeC = 0x1000,
		/// <summary>全銀協XML項目属性(EDI属性)</summary>
		XMLEbAttributeEDI = 0x2000,
		/// <summary>全銀協XML項目属性(名称属性)</summary>
		XMLEbAttributeName = 0x4000,
		/// <summary>全銀協XML項目属性(店舗名称属性)</summary>
		XMLEbAttributeStoreName = 0x8000
// 管理番号K27095 To
	}

	/// <summary>
	/// エラーの種類。
	/// </summary>
	public enum ErrorType
	{
		/// <summary>
		/// エラーなし
		/// </summary>
		None,
		/// <summary>
		/// 文字数超過エラー
		/// </summary>
		Length,
		/// <summary>
		/// 必須エラー
		/// </summary>
		Require,
		/// <summary>
		/// 文字種エラー
		/// </summary>
		Option
	}

// 管理番号K25879 From
	/// <summary>
	/// 個人番号のチェック対象。
	/// </summary>
	public enum MyNumberType
	{
		/// <summary>
		/// 個人番号
		/// </summary>
		MyNumber = 1,
		/// <summary>
		/// 法人番号
		/// </summary>
		CorpNumber = 2
	}
// 管理番号K25879 To
}
