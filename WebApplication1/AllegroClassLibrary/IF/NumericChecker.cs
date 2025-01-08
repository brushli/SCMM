// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : NumericChecker.cs
// 機能名      : 数値判定
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

namespace Infocom.Allegro.IF
{
	/// <summary>
	/// 数値チェックに関する共通機能を提供します。
	/// </summary>
	public class NumericChecker
	{
		/// <summary>
		/// 指定した文字列に対して数値チェックを行います。
		/// </summary>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="allowEmpty">
		/// ブランクを許容する：true、ブランクを許可しない：false
		/// </param>
		/// <param name="allowNegative">
		/// 負数を許可する：true、負数を許可しない：false
		/// </param>
		/// <param name="precision">
		/// 数値全体の最大桁数。
		/// </param>
		/// <param name="scale">
		/// 数値の小数点以下の最大桁数。
		/// </param>
		/// <returns>
		/// 文字列がチェック内容を満たす数値の場合：true、それ以外の場合：false
		/// </returns>
		public static bool IsNumeric(string value, bool allowEmpty, bool allowNegative, byte precision, byte scale)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (value.Length == 0)
			{
				return allowEmpty;
			}
			int index = 0;
			byte precisionCount = 0;
			byte scaleCount = 0;
			if (allowNegative && value[0] == '-')
			{
				index++;
			}
			while (index < value.Length)
			{
				if (value[index] < '0' || '9' < value[index])
				{
					if (value[index] == '.')
					{
						index++;
						break;
					}
					else
					{
						return false;
					}
				}
				precisionCount++;
				index++;
			}
			while (index < value.Length)
			{
				if (value[index] < '0' || '9' < value[index])
				{
					return false;
				}
				scaleCount++;
				index++;
			}
			if (precision - scale < precisionCount || scale < scaleCount)
			{
				return false;
			}
			return true;
		}
	}
}
