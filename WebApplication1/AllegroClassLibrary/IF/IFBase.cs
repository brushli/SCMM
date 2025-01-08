// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : IFBase.cs
// 機能名      : IF基底クラス
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.4.0 2005/10/31
// 管理番号B16832 2005/12/13 ①半角文字チェックオプションの追加(半角英数字・記号、半角カタカナ、半角スペース）
//							 ②EB振込依頼人・口座名義人用チェックオプションの追加
// 管理番号B17674 2006/03/28 半角カナの拗音、促音を自動変換しないチェックオプションの追加
// 1.5.0 2006/03/31
// 管理番号B20080 2007/03/23 EB振込依頼人・口座名義人にカンマを許容する
// 管理番号B20390 2007/03/29 EB振込依頼人・口座名義人にスラッシュ："/"を許容する
// 1.5.1 2007/06/30
// 管理番号 B21907 2009/04/23 .NETバージョンアップToString不具合
// 1.6.0 2009/09/30
// 管理番号B23834 2010/11/11 手動採番時に伝票番号に「-」が指定できてしまう不具合対応
// 2.0.0 2012/10/31
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 管理番号 B25484 2014/06/25 decimalの文字列変換フォーマット不備
// 2.2.0 2014/10/31
// 管理番号 K25879 2016/02/15 マイナンバー対応
// 管理番号 K25647 2015/02/13 項目桁数拡張
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号B25854 2016/07/13 電話番号、FAX番号に全角文字を登録できてしまう不具合対応
// 管理番号K26528 2017/04/03 UI見直し
// 3.0.0 2018/04/30
// 管理番号K27095 2020/04/01 全銀EDI対応
// 管理番号K27057 2020/04/23 汎用項目追加
// 3.1.0 2020/06/30
// 3.2.0 2023/03/31
// 管理番号K27625 2023/07/25 全銀仕様変更_ヲ許容対応

using System;
using System.Globalization;
using System.Text;
// 管理番号K26528 From
//using Infocom.Allegro.IF;
using Infocom.Allegro.Web.Html;
// 管理番号K26528 To

namespace Infocom.Allegro.IF
{
	/// <summary>
	/// 入力値の検証に関する共通機能を提供する抽象クラスです。
	/// </summary>
	/// <remarks>
	/// インターフェースクラスを実装する場合は、独自のクラスを作成するのではなく、この基本クラスを拡張してください。
	/// </remarks>
	[Serializable()]
	public abstract class IFBase
	{
		#region Private Fields
		private StringBuilder errorMessage = new StringBuilder(256);
		private bool hasErrors = false;
		#endregion

		#region Properties
		/// <summary>
		/// 検証結果に対するエラーの有無。
		/// </summary>
		public bool HasErrors
		{
			get {return hasErrors;}
		}

		/// <summary>
		/// 検証結果に対するHTML形式のエラーメッセージ。
		/// </summary>
		public string ErrorMessage
		{
			get
			{
				if (errorMessage.Length != 0)
				{
					StringBuilder message = new StringBuilder(errorMessage.ToString());
					if (message.Length >= 2 && message.ToString(message.Length - 2, 2).Equals("\r\n"))
					{
						message.Remove(message.Length - 2, 2);
					}
// 管理番号K26528 From
//					StringBuilder sb = new StringBuilder(512);
//					sb.Append("<table cellspacing=\"0\" cellpadding=\"1\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_2_1\">");
//					sb.Append("<table cellspacing=\"1\" cellpadding=\"3\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_2_2\">");
//					sb.Append("<span class=\"msg_fnt_2\">");
//					sb.Append(message.Replace("\r\n", "<br>").ToString());
//					sb.Append("</span><br>");
//					sb.Append("</td></tr></table>");
//					sb.Append("</td></tr></table>");
//					return sb.ToString();
					return new HtmlNoticeMessage(message.ToString(), MessageLevel.Warning).ToHtml();
// 管理番号K26528 To
				}
				return string.Empty;
			}
		}

		/// <summary>
		/// 検証結果に対するエラーメッセージ。
		/// </summary>
		public string InnerMessage
		{
			get
			{
				if (errorMessage.Length >= 2 && errorMessage.ToString(errorMessage.Length - 2, 2).Equals("\r\n"))
				{
					return errorMessage.ToString(0, errorMessage.Length - 2);
				}
				else
				{
					return errorMessage.ToString();
				}
			}
		}
		#endregion

		#region String Validators
		/// <summary>
		/// 文字列項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="maxLength">
		/// 許容する最大桁数。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected string ValidateString(string name, string value, bool isRequiredField, int maxLength)
		{
			return ValidateString(name, value, isRequiredField, maxLength, CheckOption.None);
		}

		/// <summary>
		/// 文字列項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="maxLength">
		/// 許容する最大桁数。
		/// </param>
		/// <param name="option">
		/// チェックの種類。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected virtual string ValidateString(string name, string value, bool isRequiredField, int maxLength, CheckOption option)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (isRequiredField && value.Length == 0)
			{
				errorMessage.Append(AllegroMessage.S10006(name)).Append("\r\n");
				hasErrors = true;
				return string.Empty;
			}
			if (maxLength < value.Length)
			{
				errorMessage.Append(AllegroMessage.S10020(name, maxLength)).Append("\r\n").ToString();
				hasErrors = true;
				return string.Empty;
			}
			switch (option)
			{
				case CheckOption.SingleByte:
					for (int i = 0; i < value.Length; i++)
					{
						// 「 (スペース)」、「"(ダブルクウォート)」、「'(シングルクウォート)」、「\(バックスラッシュ)」を禁止
						if (value[i] <= 0x0020 || 0x007f <= value[i] || value[i] == 0x0022 || value[i] == 0x0027 || value[i] == 0x005c)
						{
							errorMessage.Append(AllegroMessage.S10021(name)).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
					}
					break;
				case CheckOption.EnglishName:
					for (int i = 0; i < value.Length; i++)
					{
						if (value[i] <= 0x001f || 0x007f <= value[i])
						{
							errorMessage.Append(AllegroMessage.S10021(name)).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
					}
					break;
#if DEBUG
				case CheckOption.FullSizeKatakana:
					for (int i = 0; i < value.Length; i++)
					{
						if ((value[i] <= 0x30a0) || (0x3100 < value[i]))
						{
// 							errorMessage.Append(AllegroMessage.S10012(name, "全角カタカナで")).Append("\r\n"); //K24546
							errorMessage.Append(AllegroMessage.S10012(name, MultiLanguage.Get("CM_AM001212"))).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
					}
					break;
#endif
				case CheckOption.SingleByteKatakana:
					StringBuilder convertValue = new StringBuilder(value, value.Length);
					for (int i = 0; i < value.Length; i++)
					{
						if (value[i] != 0x0020 && (value[i] < 0x0028 || value[i] == 0x002b || 0x0039 < value[i]) && (value[i] < 0x0041 || 0x005a < value[i]) && (value[i] < 0xff62 || value[i] == 0xff64 || 0xff9f < value[i]))
						{
							errorMessage.Append(AllegroMessage.S10022(name)).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
						switch (value[i])
						{
							case 'ｧ':
							case 'ｨ':
							case 'ｩ':
							case 'ｪ':
							case 'ｫ':
								convertValue[i] = (char) (value[i] + 0x000a);
								break;
							case 'ｬ':
							case 'ｭ':
							case 'ｮ':
								convertValue[i] = (char) (value[i] + 0x0028);
								break;
							case 'ｯ':
								convertValue[i] = 'ﾂ';
								break;
							case '･': //0xff65
								convertValue[i] = '.';
								break;
						}

					}
					value = convertValue.ToString();
					break;
// 管理番号B16832 From
				case CheckOption.HalfWidthANK:
					StringBuilder convertValue2 = new StringBuilder(value, value.Length);
					for (int i = 0; i < value.Length; i++)
					{
						if ((value[i] <= 0x001f || 0x007f <= value[i]) && (value[i] != 0x0020 && (value[i] < 0x0028 || value[i] == 0x002b || 0x0039 < value[i]) && (value[i] < 0x0041 || 0x005a < value[i]) && (value[i] < 0xff62 || value[i] == 0xff64 || 0xff9f < value[i])))
						{
							errorMessage.Append(AllegroMessage.S10072(name)).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
						switch (value[i])
						{
							case 'ｧ':
							case 'ｨ':
							case 'ｩ':
							case 'ｪ':
							case 'ｫ':
								convertValue2[i] = (char) (value[i] + 0x000a);
								break;
							case 'ｬ':
							case 'ｭ':
							case 'ｮ':
								convertValue2[i] = (char) (value[i] + 0x0028);
								break;
							case 'ｯ':
								convertValue2[i] = 'ﾂ';
								break;
							case '･': //0xff65
								convertValue2[i] = '.';
								break;
						}

					}
					value = convertValue2.ToString();
					break;

				case CheckOption.JBAAcHolder:
					StringBuilder convertValue3 = new StringBuilder(value, value.Length);
					for (int i = 0; i < value.Length; i++)
					{
// 管理番号K27625 From
//						if (value[i] <= 0x001f || (0x007b <= value[i] && value[i] <= 0xff61) || 0xff9f < value[i] || value[i] == 0xff64 || value[i] == 0xff66
						if (value[i] <= 0x001f || (0x007b <= value[i] && value[i] <= 0xff61) || 0xff9f < value[i] || value[i] == 0xff64
// 管理番号K27625 To
// 管理番号B20390 From
//// 管理番号B20080 From
////						|| (0x0021 <= value[i] && value[i] <= 0x0027) || (0x002a <= value[i] && value[i] <= 0x002c) || value[i] == 0x002f 
//							|| (0x0021 <= value[i] && value[i] <= 0x0027) || (0x002a <= value[i] && value[i] <= 0x002b) || value[i] == 0x002f 
//// 管理番号B20080 To
							|| (0x0021 <= value[i] && value[i] <= 0x0027) || (0x002a <= value[i] && value[i] <= 0x002b)
// 管理番号B20390 To
							|| (0x003a <= value[i] && value[i] <= 0x0040) || (0x005b <= value[i] && value[i] <= 0x0060)						)
						{
// 管理番号K27625 From
//							errorMessage.Append(AllegroMessage.S10073(name)).Append("\r\n");
							errorMessage.Append(AllegroMessage.S10093(name)).Append("\r\n");
// 管理番号K27625 To
							hasErrors = true;
							return string.Empty;
						}
						switch (value[i])
						{
							case 'ｧ':
							case 'ｨ':
							case 'ｩ':
							case 'ｪ':
							case 'ｫ':
								convertValue3[i] = (char) (value[i] + 0x000a);
								break;
							case 'ｬ':
							case 'ｭ':
							case 'ｮ':
								convertValue3[i] = (char) (value[i] + 0x0028);
								break;
							case 'ｯ':
								convertValue3[i] = 'ﾂ';
								break;
							case '･': //0xff65
								convertValue3[i] = '.';
								break;
							case 'a':
							case 'b':
							case 'c':
							case 'd':
							case 'e':
							case 'f':
							case 'g':
							case 'h':
							case 'i':
							case 'j':
							case 'k':
							case 'l':
							case 'm':
							case 'n':
							case 'o':
							case 'p':
							case 'q':
							case 'r':
							case 's':
							case 't':
							case 'u':
							case 'v':
							case 'w':
							case 'x':
							case 'y':
							case 'z':
								convertValue3[i] = (char) (value[i] - 0x0020);
								break;
							case 'ｰ':
								convertValue3[i] = '-';
								break;
						}

					}
					value = convertValue3.ToString();
					break;
// 管理番号B16832 To
// 管理番号B17674 From
				case CheckOption.SingleByteKatakana2:
					for (int i = 0; i < value.Length; i++)
					{
						if (value[i] != 0x0020 && (value[i] < 0x0028 || value[i] == 0x002b || 0x0039 < value[i]) && (value[i] < 0x0041 || 0x005a < value[i]) && (value[i] < 0xff62 || value[i] == 0xff64 || 0xff9f < value[i]))
						{
							errorMessage.Append(AllegroMessage.S10022(name)).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
					}
					break;
// 管理番号B17674 To
// 管理番号B23834 From
                case CheckOption.SingleByteHyphen:
					for (int i = 0; i < value.Length; i++)
					{
						// 「 (スペース)」、「"(ダブルクウォート)」、「'(シングルクウォート)」、「\(バックスラッシュ)」を禁止
						if (value[i] <= 0x0020 || 0x007f <= value[i] || value[i] == 0x0022 || value[i] == 0x0027 || value[i] == 0x005c)
						{
							errorMessage.Append(AllegroMessage.S10021(name)).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
					}
                    for (int icnt = 0; icnt < value.Length; icnt++)
					{
						// 「-(ハイフン)」を禁止
                        if (value[icnt] == 0x002d)
						{
// 							errorMessage.Append(AllegroMessage.S20041("ハイフン(-)は使用")).Append("\r\n"); //K24546
							errorMessage.Append(AllegroMessage.S20041(MultiLanguage.Get("CM_AM000635"))).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
					}
					break;
// 管理番号B23834 To
// 管理番号K25879 From
				case CheckOption.SingleByteDigit:
					for (int i = 0; i < value.Length; i++)
					{
						//半角数字の0～9以外を禁止
						if (value[i] < 0x0030 || 0x0039 < value[i])
						{
							errorMessage.Append(AllegroMessage.S10086(name)).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
					}
					break;
// 管理番号K25879 To
// 管理番号B25854 From
				case CheckOption.PhoneNo:
					for (int i = 0; i < value.Length; i++)
					{
						//半角数字の0～9、()、-、+以外を禁止
						if (value[i] != 0x002d && value[i] != 0x002b && (value[i] < 0x0030 || 0x0039 < value[i]) && value[i] != 0x0028 && value[i] != 0x0029)
						{
							//半角数字0～9、 ( 、 )、-、+で
							errorMessage.Append(AllegroMessage.S10012(name, MultiLanguage.Get("CM_AM001727"))).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
					}
					break;
// 管理番号B25854 To
// 管理番号K27095 From
				case CheckOption.XMLEbAttributeC:

					value = xmlEbConvertValue(value); //文字変換(小文字→大文字)

					for (int i = 0; i < value.Length; i++)
					{
						// 全銀協XML項目属性(C属性)チェック
						if (!(value[i] >= 0x0030 && value[i] <= 0x0039 || // 数字(0～9)
							value[i] >= 0x0041 && value[i] <= 0x005a || // 英字(大文字(A～Z))
							value[i] >= 0xff71 && value[i] <= 0xff9d || // 半角カタカナ(大文字(ｱ～ﾝ)) ｦを除く
							value[i] == 0xff66 || // 半角カタカナ(ｦ)
							value[i] >= 0xff9e && value[i] <= 0xff9f || // 濁点(ﾞ)/半濁点(ﾟ)
							value[i] == 0x005c || // 記号(\)
							value[i] == 0xff62 || // 記号(｢)
							value[i] == 0xff63 || // 記号(｣)
							value[i] == 0x0028 || // 記号(()
							value[i] == 0x0029 || // 記号())
							value[i] == 0x002d || // 記号(-)
							value[i] == 0x002f || // 記号(/)
							value[i] == 0x002e || // 記号(.)
							value[i] == 0x002c || // 記号(,)
							value[i] == 0x002b || // 記号(+)
							value[i] == 0x003f || // 記号(?)
							value[i] == 0x003a || // 記号(:)
							value[i] == 0x0027 || // 記号(')
							value[i] == 0x0020 )) // 半角スペース
						{
							errorMessage.Append(AllegroMessage.S10080(name)).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
					}
					break;

				case CheckOption.XMLEbAttributeEDI:

					value = xmlEbConvertValue(value); //文字変換(小文字→大文字)

					for (int i = 0; i < value.Length; i++)
					{
						// 全銀協XML項目属性(EDI属性)チェック
						if (!(value[i] >= 0x0030 && value[i] <= 0x0039 || // 数字(0～9)
							value[i] >= 0x0041 && value[i] <= 0x005a || // 英字(大文字(A～Z))
							value[i] >= 0xff71 && value[i] <= 0xff9d || // 半角カタカナ(大文字(ｱ～ﾝ)) ｦを除く
							value[i] == 0xff66 || // 半角カタカナ(ｦ)
							value[i] >= 0xff9e && value[i] <= 0xff9f || // 濁点(ﾞ)/半濁点(ﾟ)
							value[i] == 0x005c || // 記号(\)
							value[i] == 0xff62 || // 記号(｢)
							value[i] == 0xff63 || // 記号(｣)
							value[i] == 0x0028 || // 記号(()
							value[i] == 0x0029 || // 記号())
							value[i] == 0x002d || // 記号(-)
							value[i] == 0x002f || // 記号(/)
							value[i] == 0x002e || // 記号(.)
							value[i] == 0x0020 )) // 半角スペース
						{
							errorMessage.Append(AllegroMessage.S10080(name)).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
					}
					break;

				case CheckOption.XMLEbAttributeName:

					value = xmlEbConvertValue(value); //文字変換(小文字→大文字)

					for (int i = 0; i < value.Length; i++)
					{
						// 全銀協XML項目属性(名称属性)チェック
						if (!(value[i] >= 0x0030 && value[i] <= 0x0039 || // 数字(0～9)
							value[i] >= 0x0041 && value[i] <= 0x005a || // 英字(大文字(A～Z))
							value[i] >= 0xff71 && value[i] <= 0xff9d || // 半角カタカナ(大文字(ｱ～ﾝ)) ｦを除く
// 管理番号K27625 From
							value[i] == 0xff66 || // 半角カタカナ(ｦ)
// 管理番号K27625 To
							value[i] >= 0xff9e && value[i] <= 0xff9f || // 濁点(ﾞ)/半濁点(ﾟ)
							value[i] == 0x0028 || // 記号(()
							value[i] == 0x0029 || // 記号())
							value[i] == 0x002d || // 記号(-)
							value[i] == 0x002e || // 記号(.)
							value[i] == 0x0020 )) // 半角スペース
						{
							errorMessage.Append(AllegroMessage.S10080(name)).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
					}
					break;

				case CheckOption.XMLEbAttributeStoreName:

					value = xmlEbConvertValue(value); //文字変換(小文字→大文字)

					for (int i = 0; i < value.Length; i++)
					{
						// 全銀協XML項目属性(店舗名称属性)チェック
						if (!(value[i] >= 0x0030 && value[i] <= 0x0039 || // 数字(0～9)
							value[i] >= 0x0041 && value[i] <= 0x005a || // 英字(大文字(A～Z))
							value[i] >= 0xff71 && value[i] <= 0xff9d || // 半角カタカナ(大文字(ｱ～ﾝ)) ｦを除く
// 管理番号K27625 From
							value[i] == 0xff66 || // 半角カタカナ(ｦ)
// 管理番号K27625 To
							value[i] >= 0xff9e && value[i] <= 0xff9f || // 濁点(ﾞ)/半濁点(ﾟ)
							value[i] == 0x002d || // 記号(-)
							value[i] == 0x0020 )) // 半角スペース
						{
							errorMessage.Append(AllegroMessage.S10080(name)).Append("\r\n");
							hasErrors = true;
							return string.Empty;
						}
					}
					break;
// 管理番号K27095 To
			}
			return value;
		}

		/// <summary>
		/// 文字列項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="maxLength">
		/// 許容する最大桁数。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="DBNull.Value"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected object ValidateStringForSqlParameter(string name, string value, bool isRequiredField, int maxLength)
		{
			return ValidateStringForSqlParameter(name, value, isRequiredField, maxLength, CheckOption.None);
		}

		/// <summary>
		/// 文字列項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="maxLength">
		/// 許容する最大桁数。
		/// </param>
		/// <param name="option">
		/// チェックの種類。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="DBNull.Value"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected virtual object ValidateStringForSqlParameter(string name, string value, bool isRequiredField, int maxLength, CheckOption option)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (value.Length == 0)
			{
				if (isRequiredField)
				{
					errorMessage.Append(AllegroMessage.S10006(name)).Append("\r\n");
					hasErrors = true;
				}
				return DBNull.Value;
			}
			if (maxLength < value.Length)
			{
				errorMessage.Append(AllegroMessage.S10020(name, maxLength)).Append("\r\n");
				hasErrors = true;
				return DBNull.Value;
			}
			switch (option)
			{
				case CheckOption.SingleByte:
					for (int i = 0; i < value.Length; i++)
					{
						// 「 (スペース)」、「"(ダブルクウォート)」、「'(シングルクウォート)」、「\(バックスラッシュ)」を禁止
						if (value[i] <= 0x0020 || 0x007f <= value[i] || value[i] == 0x0022 || value[i] == 0x0027 || value[i] == 0x005c)
						{
							errorMessage.Append(AllegroMessage.S10021(name)).Append("\r\n");
							hasErrors = true;
							return DBNull.Value;
						}
					}
					break;
				case CheckOption.EnglishName:
					for (int i = 0; i < value.Length; i++)
					{
						if (value[i] <= 0x001f || 0x007f <= value[i])
						{
							errorMessage.Append(AllegroMessage.S10021(name)).Append("\r\n");
							hasErrors = true;
							return DBNull.Value;
						}
					}
					break;
#if DEBUG
				case CheckOption.FullSizeKatakana:
					for (int i = 0; i < value.Length; i++)
					{
						if ((value[i] <= 0x30a0) || (0x3100 < value[i]))
						{
// 							errorMessage.Append(AllegroMessage.S10012(name, "全角カタカナで")).Append("\r\n"); //K24546
							errorMessage.Append(AllegroMessage.S10012(name, MultiLanguage.Get("CM_AM001212"))).Append("\r\n");
							hasErrors = true;
							return DBNull.Value;
						}
					}
					break;
#endif
				case CheckOption.SingleByteKatakana:
					StringBuilder convertValue = new StringBuilder(value, value.Length);
					for (int i = 0; i < value.Length; i++)
					{
						if (value[i] != 0x0020 && (value[i] < 0x0028 || value[i] == 0x002b || 0x0039 < value[i]) && (value[i] < 0xff62 || value[i] == 0xff64 || 0xff9f < value[i]))
						{
							errorMessage.Append(AllegroMessage.S10022(name)).Append("\r\n");
							hasErrors = true;
							return DBNull.Value;
						}
						switch (value[i])
						{
							case 'ｧ':
							case 'ｨ':
							case 'ｩ':
							case 'ｪ':
							case 'ｫ':
								convertValue[i] = (char) (value[i] + 0x000a);
								break;
							case 'ｬ':
							case 'ｭ':
							case 'ｮ':
								convertValue[i] = (char) (value[i] + 0x0028);
								break;
							case 'ｯ':
								convertValue[i] = 'ﾂ';
								break;
						}
					}
					value = convertValue.ToString();
					break;
			}
			return value;
		}
		// 管理番号 K25879 From
		/// <summary>
		/// 個人番号及び法人番号のチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="type">
		/// 個人番号のチェック対象。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		public string ValidateMyNumber(string name, string value, bool isRequiredField, MyNumberType type)
		{
			int checkdigit = 0;
			int calcdigit = 0;
			int sum = 0;
			int intparse = 0;
			int length = 0;

			if (value == null)
			{
				// 文字列参照が文字列のインスタンスに設定されていません。
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}

			// 桁数チェック
			switch (type)
			{
				case MyNumberType.MyNumber:
					length = 12;
					break;
				case MyNumberType.CorpNumber:
					length = 13;
					break;
			}
			
			if (isRequiredField && value.Length == 0)
			{
				// [{0}]は{1}桁で入力してください。
				errorMessage.Append(AllegroMessage.S10088(name, length)).Append("\r\n");
				hasErrors = true;
				return string.Empty;
			}

			if (!(value.Length == length || value.Length == 0))
			{
				// [{0}]は{1}桁で入力してください。
				errorMessage.Append(AllegroMessage.S10088(name, length)).Append("\r\n");
				hasErrors = true;
				return string.Empty;
			}

			// 0桁の場合、チェック不要
			if (value.Length == 0)
			{
				return value;
			}

			// 半角数値チェック
			if (ValidateString(name, value, isRequiredField, length, CheckOption.SingleByteDigit) == string.Empty)
			{
				// ValidateStringでerrorMessage設定済み
				return string.Empty;
			}

			switch (type)
			{
				case MyNumberType.MyNumber:

					// 12桁目(checkdigit)
					intparse = int.Parse(value.Substring(11, 1));
					checkdigit = intparse;


					// 1桁目
					intparse = int.Parse(value.Substring(0, 1));
					sum += (intparse * 6);

					// 2桁目
					intparse = int.Parse(value.Substring(1, 1));
					sum += (intparse * 5);

					// 3桁目
					intparse = int.Parse(value.Substring(2, 1));
					sum += (intparse * 4);

					// 4桁目
					intparse = int.Parse(value.Substring(3, 1));
					sum += (intparse * 3);

					// 5桁目
					intparse = int.Parse(value.Substring(4, 1));
					sum += (intparse * 2);

					// 6桁目
					intparse = int.Parse(value.Substring(5, 1));
					sum += (intparse * 7);

					// 7桁目
					intparse = int.Parse(value.Substring(6, 1));
					sum += (intparse * 6);

					// 8桁目
					intparse = int.Parse(value.Substring(7, 1));
					sum += (intparse * 5);

					// 9桁目
					intparse = int.Parse(value.Substring(8, 1));
					sum += (intparse * 4);

					// 10桁目
					intparse = int.Parse(value.Substring(9, 1));
					sum += (intparse * 3);

					// 11桁目
					intparse = int.Parse(value.Substring(10, 1));
					sum += (intparse * 2);

					calcdigit = 11 - (sum % 11);
					if (calcdigit >= 10)
					{
						calcdigit = 0;
					}

					break;


				case MyNumberType.CorpNumber:

					intparse = int.Parse(value.Substring(0, 1));	// 1桁目
					checkdigit = intparse;

					for (int i = 1; i <= 11; i += 2) // 2桁目～12桁目
					{
						intparse = int.Parse(value.Substring(i, 1));
						sum += (intparse * 2);

						intparse = int.Parse(value.Substring(i + 1, 1));
						sum += intparse;
					}

					calcdigit = 9 - (sum % 9);

					break;
			}

			if (!calcdigit.Equals(checkdigit))
			{
				// [{0}]の入力に誤りがあります。
				errorMessage.Append(AllegroMessage.S10087(name)).Append("\r\n");
				hasErrors = true;
				return string.Empty;
			}
			return value;
		}
		// 管理番号 K25879 To
		#endregion

		#region Decimal Validators
		/// <summary>
		/// 数値項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
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
		/// エラーがなければ<paramref name="value"/>を<see cref="decimal"/>に変換した値。エラーがあった場合は<see cref="DBNull.Value"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected virtual object ValidateDecimalForSqlParameter(string name, string value, bool isRequiredField, bool allowNegative, byte precision, byte scale)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (value.Length == 0)
			{
				if (isRequiredField)
				{
					errorMessage.Append(AllegroMessage.S10006(name)).Append("\r\n");
					hasErrors = true;
				}
				return DBNull.Value;
			}
// 管理番号 B21907 From
			string tmpValue = value;
			// 小数桁がゼロのString（例：.00～）が引き渡された場合、一度decimalに変換することによって小数桁を省く
			try
			{
// 管理番号 B25484 From
//				value = decimal.Parse(value).ToString("G29");
				value = CutoffDigit(value);
// 管理番号 B25484 To
			}
			catch (FormatException)
			{
				return DBNull.Value;
			}
// 管理番号 B21907 To
			int index = 0;
			byte precisionCount = 0;
			byte scaleCount = 0;
			if (value[0] == '-')
			{
				if (allowNegative)
				{
					if (value.Length > 1)
					{
						index++;
					}
					else
					{
						return "0";
					}
				}
				else
				{
					errorMessage.Append(AllegroMessage.S10023(name)).Append("\r\n");
					hasErrors = true;
					return DBNull.Value;
				}
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
						if (scale == 0)
						{
							errorMessage.Append(AllegroMessage.S10024(name, precision)).Append("\r\n");
						}
						else
						{
							errorMessage.Append(AllegroMessage.S10024(name, precision, scale)).Append("\r\n");
						}
						hasErrors = true;
						return DBNull.Value;
					}
				}
				precisionCount++;
				index++;
			}
			while (index < value.Length)
			{
				if (value[index] < '0' || '9' < value[index])
				{
					if (scale == 0)
					{
						errorMessage.Append(AllegroMessage.S10024(name, precision)).Append("\r\n");
					}
					else
					{
						errorMessage.Append(AllegroMessage.S10024(name, precision, scale)).Append("\r\n");
					}
					hasErrors = true;
					return DBNull.Value;
				}
				scaleCount++;
				index++;
			}
			if (precision - scale < precisionCount || scale < scaleCount)
			{
				if (scale == 0)
				{
					errorMessage.Append(AllegroMessage.S10024(name, precision)).Append("\r\n");
				}
				else
				{
					errorMessage.Append(AllegroMessage.S10024(name, precision, scale)).Append("\r\n");
				}
				hasErrors = true;
				return DBNull.Value;
			}
			
// 管理番号 B21907 From
			value = tmpValue;
// 管理番号 B21907 To
			return (value[value.Length - 1] == '.') ? ((value == "-." || value == ".") ? 0M : decimal.Parse(value.Substring(0, value.Length - 1))) : decimal.Parse(value);
		}

		/// <summary>
		/// 数値項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。末尾に垂直タブが付与されている場合はフォーマットエラー時に検証結果をエラーとし、エラーメッセージを作成します。垂直タブは除去されます。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
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
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected virtual string ValidateDecimalString(string name, string value, bool isRequiredField, bool allowNegative, byte precision, byte scale)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
// 管理番号K27057 From
			bool setHasError = false;
			if (name.Length > 0 && name[name.Length - 1] == '\v')
			{
				setHasError = true;
				name = name.Substring(0, name.Length - 1);
			}
// 管理番号K27057 To
			if (value.Length == 0)
			{
				if (isRequiredField)
				{
					errorMessage.Append(AllegroMessage.S10006(name)).Append("\r\n");
					hasErrors = true;
				}
				return string.Empty;
			}
// 管理番号 B21907 From
			string tmpValue = value;
			// 小数桁がゼロのString（例：.00～）が引き渡された場合、一度decimalに変換することによって小数桁を省く
			try
			{
// 管理番号 B25484 From
//				value = decimal.Parse(value).ToString("G29");
				value = CutoffDigit(value);
// 管理番号 B25484 To
			}
			catch (FormatException)
			{
// 管理番号K27057 From
				if (setHasError)
				{
					errorMessage.Append(AllegroMessage.S10011(name)).Append("\r\n");
					hasErrors = true;
				}
// 管理番号K27057 To
				return string.Empty;
			}
// 管理番号 B21907 To
			int index = 0;
			byte precisionCount = 0;
			byte scaleCount = 0;
			if (value[0] == '-')
			{
				if (allowNegative)
				{
					if (value.Length > 1)
					{
						index++;
					}
					else
					{
						return "0";
					}
				}
				else
				{
					errorMessage.Append(AllegroMessage.S10023(name)).Append("\r\n");
					hasErrors = true;
					return string.Empty;
				}
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
						if (scale == 0)
						{
							errorMessage.Append(AllegroMessage.S10024(name, precision)).Append("\r\n");
						}
						else
						{
							errorMessage.Append(AllegroMessage.S10024(name, precision, scale)).Append("\r\n");
						}
						hasErrors = true;
						return string.Empty;
					}
				}
				precisionCount++;
				index++;
			}
			while (index < value.Length)
			{
				if (value[index] < '0' || '9' < value[index])
				{
					if (scale == 0)
					{
						errorMessage.Append(AllegroMessage.S10024(name, precision)).Append("\r\n");
					}
					else
					{
						errorMessage.Append(AllegroMessage.S10024(name, precision, scale)).Append("\r\n");
					}
					hasErrors = true;
					return string.Empty;
				}
				scaleCount++;
				index++;
			}
			if (precision - scale < precisionCount || scale < scaleCount)
			{
				if (scale == 0)
				{
					errorMessage.Append(AllegroMessage.S10024(name, precision)).Append("\r\n");
				}
				else
				{
					errorMessage.Append(AllegroMessage.S10024(name, precision, scale)).Append("\r\n");
				}
				hasErrors = true;
				return string.Empty;
			}
// 管理番号 B21907 From
			value = tmpValue;
// 管理番号 B21907 To
			return ((value[value.Length - 1] == '.') ? ((value == "-." || value == ".") ? "0" : value.Substring(0, value.Length - 1)) : value);
		}

		// 管理番号 K25647 From
		/// <summary>
		/// 伝票単位数量としての書式チェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="allowNegative">
		/// 負数を許可する：true、負数を許可しない：false
		/// </param>
		/// <param name="qtDecimalDigit">
		/// 伝票単位数量の小数桁数。
		/// </param>
		/// <param name="quantityType">
		/// 整数部の桁数を設定するための伝票単位数量の種類。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>を<see cref="decimal"/>に変換した値。エラーがあった場合は<see cref="DBNull.Value"/>。
		/// </returns>
		protected object ValidateSlipQuantityForSqlParameter(
			string name
			, string value
			, bool isRequiredField
			, bool allowNegative
			, byte qtDecimalDigit
			, SlipQuantity quantityType
			)
		{
			return
				this.ValidateDecimalForSqlParameter(
					name
					, value
					, isRequiredField
					, allowNegative
					, (byte)(this.GetIntegerDigit(quantityType) + qtDecimalDigit)
					, qtDecimalDigit
					);
		}

		/// <summary>
		/// 伝票単位数量としての書式チェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="allowNegative">
		/// 負数を許可する：true、負数を許可しない：false
		/// </param>
		/// <param name="qtDecimalDigit">
		/// 伝票単位数量の小数桁数。
		/// </param>
		/// <param name="quantityType">
		/// 整数部の桁数を設定するための伝票単位数量の種類。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		protected string ValidateSlipQuantity(
			string name
			, string value
			, bool isRequiredField
			, bool allowNegative
			, byte qtDecimalDigit
			, SlipQuantity quantityType
			)
		{
			return
				this.ValidateDecimalString(
					name
					, value
					, isRequiredField
					, allowNegative
					, (byte)(this.GetIntegerDigit(quantityType) + qtDecimalDigit)
					, qtDecimalDigit
					);
		}

		/// <summary>伝票単位数量の種類に応じた整数部の桁数を返す</summary>
		/// <param name="quantityType">伝票単位数量の種類</param>
		/// <returns></returns>
		private int GetIntegerDigit(SlipQuantity quantityType)
		{
			switch (quantityType)
			{
				case SlipQuantity.SCSD:
				case SlipQuantity.FIAR:
				case SlipQuantity.FIAP:
					return 6;
				case SlipQuantity.SCMM:
				case SlipQuantity.FIGL:
					return 9;
				default:
					throw new ArgumentException();
			}
		}

		/// <summary>
		/// 在庫表示単位数量としての書式チェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="allowNegative">
		/// 負数を許可する：true、負数を許可しない：false
		/// </param>
		/// <param name="qtDecimalUseFlg">
		/// 小数桁を使用する：true、小数桁を使用しない：false
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>を<see cref="decimal"/>に変換した値。エラーがあった場合は<see cref="DBNull.Value"/>。
		/// </returns>
		protected object ValidateStockQuantityForSqlParameter(
			string name
			, string value
			, bool isRequiredField
			, bool allowNegative
			, bool qtDecimalUseFlg
			)
		{
			var scale = (byte)(qtDecimalUseFlg ? 4 : 0);
			return
				this.ValidateDecimalForSqlParameter(
					name
					, value
					, isRequiredField
					, allowNegative
					, (byte)(9 + scale)
					, scale
					);
		}

		/// <summary>
		/// 伝票単位数量としての書式チェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="allowNegative">
		/// 負数を許可する：true、負数を許可しない：false
		/// </param>
		/// <param name="qtDecimalUseFlg">
		/// 小数桁を使用する：true、小数桁を使用しない：false
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		protected string ValidateStockQuantity(
			string name
			, string value
			, bool isRequiredField
			, bool allowNegative
			, bool qtDecimalUseFlg
			)
		{
			var scale = (byte)(qtDecimalUseFlg ? 4 : 0);
			return
				this.ValidateDecimalString(
					name
					, value
					, isRequiredField
					, allowNegative
					, (byte)(9 + scale)
					, scale
					);
		}

		/// <summary>
		/// 伝票単価としての書式チェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="allowNegative">
		/// 負数を許可する：true、負数を許可しない：false
		/// </param>
		/// <param name="priceDecimalDigit">
		/// 自社.単価小数桁数。
		/// </param>
		/// <param name="currencyDigit">
		/// 当該通貨の通貨.小数桁数。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>を<see cref="decimal"/>に変換した値。エラーがあった場合は<see cref="DBNull.Value"/>。
		/// </returns>
		protected object ValidateSlipPriceForSqlParameter(
			string name
			, string value
			, bool isRequiredField
			, bool allowNegative
			, byte priceDecimalDigit
			, byte currencyDigit
			)
		{
			var scale = (byte)(priceDecimalDigit == 0 ? currencyDigit : priceDecimalDigit);
			return
				this.ValidateDecimalForSqlParameter(
					name
					, value
					, isRequiredField
					, allowNegative
					, (byte)(11 + scale)
					, scale
					);
		}

		/// <summary>
		/// 伝票単価としての書式チェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="allowNegative">
		/// 負数を許可する：true、負数を許可しない：false
		/// </param>
		/// <param name="priceDecimalDigit">
		/// 自社.単価小数桁数。
		/// </param>
		/// <param name="currencyDigit">
		/// 当該通貨の通貨.小数桁数。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		protected string ValidateSlipPrice(
			string name
			, string value
			, bool isRequiredField
			, bool allowNegative
			, byte priceDecimalDigit
			, byte currencyDigit
			)
		{
			var scale = (byte)(priceDecimalDigit == 0 ? currencyDigit : priceDecimalDigit);
			return
				this.ValidateDecimalString(
					name
					, value
					, isRequiredField
					, allowNegative
					, (byte)(11 + scale)
					, scale
					);
		}

		/// <summary>
		/// 在庫単価としての書式チェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="allowNegative">
		/// 負数を許可する：true、負数を許可しない：false
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>を<see cref="decimal"/>に変換した値。エラーがあった場合は<see cref="DBNull.Value"/>。
		/// </returns>
		protected object ValidateStockPriceForSqlParameter(
			string name
			, string value
			, bool isRequiredField
			, bool allowNegative
			)
		{
			return
				this.ValidateDecimalForSqlParameter(
					name
					, value
					, isRequiredField
					, allowNegative
					, 16
					, 5
					);
		}

		/// <summary>
		/// 在庫単価としての書式チェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="allowNegative">
		/// 負数を許可する：true、負数を許可しない：false
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		protected string ValidateStockPrice(
			string name
			, string value
			, bool isRequiredField
			, bool allowNegative
			)
		{
			return
				this.ValidateDecimalString(
					name
					, value
					, isRequiredField
					, allowNegative
					, 16
					, 5
					);
		}
		// 管理番号 K25647 To
		#endregion

		#region DateTime Validators
		/// <summary>
		/// 日付項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>を<see cref="DateTime"/>に変換した値。エラーがあった場合は<see cref="DBNull.Value"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected object ValidateDateTimeForSqlParameter(string name, string value, bool isRequiredField)
		{
			return ValidateDateTimeForSqlParameter(name, value, isRequiredField, DateRange.MinValue, DateRange.MaxValue);
		}

		/// <summary>
		/// 日付項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="minValue">
		/// 許容する日付の最小値。
		/// </param>
		/// <param name="maxValue">
		/// 許容する日付の最大値。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>を<see cref="DateTime"/>に変換した値。エラーがあった場合は<see cref="DBNull.Value"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected virtual object ValidateDateTimeForSqlParameter(string name, string value, bool isRequiredField, DateTime minValue, DateTime maxValue)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (value.Length == 0)
			{
				if (isRequiredField)
				{
					errorMessage.Append(AllegroMessage.S10006(name)).Append("\r\n");
					hasErrors = true;
				}
				return DBNull.Value;
			}
			string[] yearMonthDate = value.Split(new char[] {'/', '-', '.'}, 3);
			if (yearMonthDate.Length != 3)
			{
// 				errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06/01）\r\n"); //K24546
				errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000116"));
				hasErrors = true;
				return DBNull.Value;
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
// 						errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06/01）\r\n"); //K24546
						errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000116"));
						hasErrors = true;
						return DBNull.Value;
					}
					break;
				case 4:
					break;
				default:
// 					errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06/01）\r\n"); //K24546
					errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000116"));
					hasErrors = true;
					return DBNull.Value;
			}
			// TODO 日本語カルチャのみ
			try
			{
				DateTime date = DateTime.Parse(century + value, CultureInfo.CreateSpecificCulture("ja-JP"));
				if (date < minValue || maxValue < date)
				{
					errorMessage.Append(AllegroMessage.S10025(name, minValue.ToString("yyyy/MM/dd"), maxValue.ToString("yyyy/MM/dd"))).Append("\r\n");
					hasErrors = true;
					return DBNull.Value;
				}
				return date;
			}
			catch (FormatException)
			{
// 				errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06/01）\r\n"); //K24546
				errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000116"));
				hasErrors = true;
				return DBNull.Value;
			}
		}

		/// <summary>
		/// 日付項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected string ValidateDateTimeString(string name, string value, bool isRequiredField)
		{
			return ValidateDateTimeString(name, value, isRequiredField, DateRange.MinValue, DateRange.MaxValue);
		}

		/// <summary>
		/// 日付項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="minValue">
		/// 許容する日付の最小値。
		/// </param>
		/// <param name="maxValue">
		/// 許容する日付の最大値。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>の標準日付形式の文字列（yyyy/MM/dd）。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected virtual string ValidateDateTimeString(string name, string value, bool isRequiredField, DateTime minValue, DateTime maxValue)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (value.Length == 0)
			{
				if (isRequiredField)
				{
					errorMessage.Append(AllegroMessage.S10006(name)).Append("\r\n");
					hasErrors = true;
				}
				return string.Empty;
			}
			string[] yearMonthDate = value.Split(new char[] {'/', '-', '.'}, 3);
			if (yearMonthDate.Length != 3)
			{
// 				errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06/01）\r\n"); //K24546
				errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000116"));
				hasErrors = true;
				return string.Empty;
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
// 						errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06/01）\r\n"); //K24546
						errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000116"));
						hasErrors = true;
						return string.Empty;
					}
					break;
				case 4:
					break;
				default:
// 					errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06/01）\r\n"); //K24546
					errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000116"));
					hasErrors = true;
					return string.Empty;
			}
			// TODO 日本語カルチャのみ
			try
			{
				DateTime date = DateTime.Parse(century + value, CultureInfo.CreateSpecificCulture("ja-JP"));
				if (date < minValue || maxValue < date)
				{
					errorMessage.Append(AllegroMessage.S10025(name, minValue.ToString("yyyy/MM/dd"), maxValue.ToString("yyyy/MM/dd"))).Append("\r\n");
					hasErrors = true;
					return string.Empty;
				}
				return date.ToString("yyyy/MM/dd");
			}
			catch (FormatException)
			{
// 				errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06/01）\r\n"); //K24546
				errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000116"));
				hasErrors = true;
				return string.Empty;
			}
		}

		/// <summary>
		/// 年月項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>を<see cref="DateTime"/>に変換した値。エラーがあった場合は<see cref="DBNull.Value"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected object ValidateMonthForSqlParameter(string name, string value, bool isRequiredField)
		{
			return ValidateMonthForSqlParameter(name, value, isRequiredField, DateRange.MinValue, DateRange.MaxValue);
		}

		/// <summary>
		/// 年月項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="minValue">
		/// 許容する年月の最小値。
		/// </param>
		/// <param name="maxValue">
		/// 許容する年月の最大値。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>を<see cref="DateTime"/>に変換した値。エラーがあった場合は<see cref="DBNull.Value"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected virtual object ValidateMonthForSqlParameter(string name, string value, bool isRequiredField, DateTime minValue, DateTime maxValue)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (value.Length == 0)
			{
				if (isRequiredField)
				{
					errorMessage.Append(AllegroMessage.S10006(name)).Append("\r\n");
					hasErrors = true;
				}
				return DBNull.Value;
			}
			string[] yearMonth = value.Split(new char[] {'/', '-', '.'}, 2);
			if (yearMonth.Length != 2)
			{
// 				errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06）\r\n"); //K24546
				errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000115"));
				hasErrors = true;
				return DBNull.Value;
			}
			string century = string.Empty;
			switch (yearMonth[0].Length)
			{
				case 2:
					try
					{
						int year = int.Parse(yearMonth[0]);
						century = (year < 50 ? "20" : "19");
					}
					catch (FormatException)
					{
// 						errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06）\r\n"); //K24546
						errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000115"));
						hasErrors = true;
						return DBNull.Value;
					}
					break;
				case 4:
					break;
				default:
// 					errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06）\r\n"); //K24546
					errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000115"));
					hasErrors = true;
					return DBNull.Value;
			}
			// TODO 日本語カルチャのみ
			try
			{
				DateTime date = DateTime.Parse(century + value + "01", CultureInfo.CreateSpecificCulture("ja-JP"));
				if (date < minValue || maxValue < date)
				{
					errorMessage.Append(AllegroMessage.S10025(name, minValue.ToString("yyyy/MM"), maxValue.ToString("yyyy/MM")));
					hasErrors = true;
					return DBNull.Value;
				}
				return date;
			}
			catch (FormatException)
			{
// 				errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06）\r\n"); //K24546
				errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000115"));
				hasErrors = true;
				return DBNull.Value;
			}
		}

		/// <summary>
		/// 年月項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected string ValidateMonthString(string name, string value, bool isRequiredField)
		{
			return ValidateMonthString(name, value, isRequiredField, DateRange.MinValue, DateRange.MaxValue);
		}

		/// <summary>
		/// 年月項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="isRequiredField">
		/// 必須項目：true、非必須項目：false
		/// </param>
		/// <param name="minValue">
		/// 許容する年月の最小値。
		/// </param>
		/// <param name="maxValue">
		/// 許容する年月の最大値。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>の標準日付形式の文字列（yyyy/MM）。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected virtual string ValidateMonthString(string name, string value, bool isRequiredField, DateTime minValue, DateTime maxValue)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (value.Length == 0)
			{
				if (isRequiredField)
				{
					errorMessage.Append(AllegroMessage.S10006(name)).Append("\r\n");
					hasErrors = true;
				}
				return string.Empty;
			}
			string[] yearMonth = value.Split(new char[] {'/', '-', '.'}, 2);
			if (yearMonth.Length != 2)
			{
// 				errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06）\r\n"); //K24546
				errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000115"));
				hasErrors = true;
				return string.Empty;
			}
			string century = string.Empty;
			switch (yearMonth[0].Length)
			{
				case 2:
					try
					{
						int year = int.Parse(yearMonth[0]);
						century = (year < 50 ? "20" : "19");
					}
					catch (FormatException)
					{
// 						errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06）\r\n"); //K24546
						errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000115"));
						hasErrors = true;
						return string.Empty;
					}
					break;
				case 4:
					break;
				default:
// 					errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06）\r\n"); //K24546
					errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000115"));
					hasErrors = true;
					return string.Empty;
			}
			// TODO 日本語カルチャのみ
			try
			{
				DateTime date = DateTime.Parse(century + value + "/01", CultureInfo.CreateSpecificCulture("ja-JP"));
				if (date < minValue || maxValue < date)
				{
					errorMessage.Append(AllegroMessage.S10025(name, minValue.ToString("yyyy/MM"), maxValue.ToString("yyyy/MM")));
					hasErrors = true;
					return string.Empty;
				}
				return date.ToString("yyyy/MM");
			}
			catch (FormatException)
			{
// 				errorMessage.Append(AllegroMessage.S10011(name)).Append("（例: 2004/06）\r\n"); //K24546
				errorMessage.Append(AllegroMessage.S10011(name)).Append(MultiLanguage.Get("CM_AM000115"));
				hasErrors = true;
				return string.Empty;
			}
		}
		#endregion

		#region Enum Validators
		/// <summary>
		/// 選択項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="choices">
		/// 選択肢に含まれる項目の配列。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected string ValidateChoiceString(string name, string value, string[] choices)
		{
			return ValidateChoiceString(name, value, choices, string.Empty);
		}

		/// <summary>
		/// 選択項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="choices">
		/// 選択肢に含まれる項目の配列。
		/// </param>
		/// <param name="defaultValue">
		/// デフォルト値
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<paramref name="defaultValue"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected virtual string ValidateChoiceString(string name, string value, string[] choices, string defaultValue)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			foreach (string choice in choices)
			{
				if (value.Equals(choice))
				{
					return value;
				}
			}
			errorMessage.Append(AllegroMessage.S10026(name)).Append("\r\n");
			hasErrors = true;
			return defaultValue;
		}

		/// <summary>
		/// 選択項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="choices">
		/// 選択肢に含まれる項目の配列。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="DBNull.Value"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected object ValidateChoiceStringForSqlParameter(string name, string value, string[] choices)
		{
			return ValidateChoiceStringForSqlParameter(name, value, choices, DBNull.Value);
		}

		/// <summary>
		/// 選択項目のエラーチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="choices">
		/// 選択肢に含まれる項目の配列。
		/// </param>
		/// <param name="defaultValue">
		/// デフォルト値
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<paramref name="defaultValue"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		protected virtual object ValidateChoiceStringForSqlParameter(string name, string value, string[] choices, object defaultValue)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			foreach (string choice in choices)
			{
				if (value.Equals(choice))
				{
					return value;
				}
			}
			errorMessage.Append(AllegroMessage.S10026(name)).Append("\r\n");
			hasErrors = true;
			return defaultValue;
		}

		/// <summary>
		/// 使用可能な<see cref="SearchOperator"/>の値であるかのチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする<see cref="SearchOperator"/>の値。
		/// </param>
		/// <param name="choices">
		/// 選択可能な<see cref="SearchOperator"/>の値の論理和。
		/// </param>
		/// <returns>
		/// <paramref name="value"/>が<paramref name="choices"/>に含まれていれば<paramref name="value"/>。
		/// 含まれていなければ<see cref="SearchOperator.FrontCoincidence"/>。
		/// </returns>
		protected SearchOperator ValidateSearchOperator(string name, SearchOperator value, SearchOperator choices)
		{
			return ValidateSearchOperator(name, value, choices, SearchOperator.FrontCoincidence);
		}

		/// <summary>
		/// 使用可能な<see cref="Infocom.Allegro.IF.SearchOperator"/>の値であるかのチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする<see cref="Infocom.Allegro.IF.SearchOperator"/>の値。
		/// </param>
		/// <param name="choices">
		/// 選択可能な<see cref="Infocom.Allegro.IF.SearchOperator"/>の値の論理和。
		/// </param>
		/// <param name="defaultValue">
		/// デフォルト値
		/// </param>
		/// <returns>
		/// <paramref name="value"/>が<paramref name="choices"/>に含まれていれば<paramref name="value"/>。
		/// 含まれていなければ<paramref name="defaultValue"/>。
		/// </returns>
		protected virtual SearchOperator ValidateSearchOperator(string name, SearchOperator value, SearchOperator choices, SearchOperator defaultValue)
		{
			if ((value & choices) == value)
			{
				return value;
			}
			errorMessage.Append(AllegroMessage.S10026(name)).Append("\r\n");
			hasErrors = true;
			return defaultValue;
		}

		/// <summary>
		/// <see cref="SearchTarget"/>の値のチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする<see cref="SearchTarget"/>の値。
		/// </param>
		/// <returns>
		/// <paramref name="value"/>が<see cref="SearchTarget.Code"/>もしくは<see cref="SearchTarget.Kana"/>であれば<paramref name="value"/>。
		/// それ以外の場合は<see cref="SearchTarget.Code"/>。
		/// </returns>
		protected SearchTarget ValidateSearchTarget(string name, SearchTarget value)
		{
			switch (value)
			{
				case SearchTarget.Code:
				case SearchTarget.Kana:
					return value;
				default:
					errorMessage.Append(AllegroMessage.S10026(name)).Append("\r\n");
					hasErrors = true;
					return SearchTarget.Code;
			}
		}

		/// <summary>
		/// 使用可能な<see cref="SearchTarget"/>の値であるかのチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする<see cref="SearchTarget"/>の値。
		/// </param>
		/// <param name="choices">
		/// 選択可能な<see cref="SearchTarget"/>の値の論理和。
		/// </param>
		/// <returns>
		/// <paramref name="value"/>が<paramref name="choices"/>に含まれていれば<paramref name="value"/>。
		/// 含まれていなければ<see cref="SearchTarget.Code"/>。
		/// </returns>
		protected SearchTarget ValidateSearchTarget(string name, SearchTarget value, SearchTarget choices)
		{
			return ValidateSearchTarget(name, value, choices, SearchTarget.Code);
		}

		/// <summary>
		/// 使用可能な<see cref="SearchTarget"/>の値であるかのチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする<see cref="SearchTarget"/>の値。
		/// </param>
		/// <param name="choices">
		/// 選択可能な<see cref="SearchTarget"/>の値の論理和。
		/// </param>
		/// <param name="defaultValue">
		/// デフォルト値
		/// </param>
		/// <returns>
		/// <paramref name="value"/>が<paramref name="choices"/>に含まれていれば<paramref name="value"/>。
		/// 含まれていなければ<paramref name="defaultValue"/>。
		/// </returns>
		protected virtual SearchTarget ValidateSearchTarget(string name, SearchTarget value, SearchTarget choices, SearchTarget defaultValue)
		{
			if ((value & choices) == value)
			{
				return value;
			}
			errorMessage.Append(AllegroMessage.S10026(name)).Append("\r\n");
			hasErrors = true;
			return defaultValue;
		}

		/// <summary>
		/// 指定された列挙体に含まれる値かどうかのチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする値。
		/// </param>
		/// <param name="enumType">
		/// チェックする列挙体を表す<see cref="Type"/>。
		/// </param>
		/// <returns>
		/// <paramref name="value"/>が<paramref name="enumType"/>で定義されていれば<paramref name="value"/>。定義されていなければ<see cref="DBNull.Value"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> または <paramref name="enumType"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		/// <exception cref="ArgumentException"><p><paramref name="enumType"/> が <b>Enum</b> ではありません。</p><p>または</p><p><paramref name="value"/> の型が <paramref name="enumType"/> ではありません。</p><p>または</p><p><paramref name="value"/> の型が、 <paramref name="enumType"/> の基になる型ではありません。</p></exception>
		/// <exception cref="InvalidOperationException"><paramref name="value"/> が型 <see cref="System.SByte"/> 、 <see cref="System.Int16"/> 、 <see cref="System.Int32"/> 、 <see cref="System.Int64"/> 、 <see cref="System.Byte"/> 、 <see cref="System.UInt16"/> 、 <see cref="System.UInt32"/> 、 <see cref="System.UInt64"/> または <see cref="System.String"/> ではありません。</exception>
		protected object ValidateEnum(string name, object value, Type enumType)
		{
			return ValidateEnum(name, value, enumType, DBNull.Value);
		}

		/// <summary>
		/// 指定された列挙体に含まれる値かどうかのチェックを行います。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="value">
		/// チェックする値。
		/// </param>
		/// <param name="enumType">
		/// チェックする列挙体を表す<see cref="Type"/>。
		/// </param>
		/// <param name="defaultValue">
		/// デフォルト値
		/// </param>
		/// <returns>
		/// <paramref name="value"/>が<paramref name="enumType"/>で定義されていれば<paramref name="value"/>。定義されていなければ<paramref name="defaultValue"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> または <paramref name="enumType"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		/// <exception cref="ArgumentException"><p><paramref name="enumType"/> が <b>Enum</b> ではありません。</p><p>または</p><p><paramref name="value"/> の型が <paramref name="enumType"/> ではありません。</p><p>または</p><p><paramref name="value"/> の型が、 <paramref name="enumType"/> の基になる型ではありません。</p></exception>
		/// <exception cref="InvalidOperationException"><paramref name="value"/> が型 <see cref="System.SByte"/> 、 <see cref="System.Int16"/> 、 <see cref="System.Int32"/> 、 <see cref="System.Int64"/> 、 <see cref="System.Byte"/> 、 <see cref="System.UInt16"/> 、 <see cref="System.UInt32"/> 、 <see cref="System.UInt64"/> または <see cref="System.String"/> ではありません。</exception>
		protected virtual object ValidateEnum(string name, object value, Type enumType, object defaultValue)
		{
			if (Enum.IsDefined(enumType, value))
			{
				return value;
			}
			errorMessage.Append(AllegroMessage.S10026(name)).Append("\r\n");
			hasErrors = true;
			return defaultValue;
		}

		#endregion

		#region Other Methods
		/// <summary>
		/// エラーメッセージを追加します。
		/// </summary>
		/// <param name="message">
		/// エラーメッセージ
		/// </param>
		/// <remarks>
		/// エラーがあった場合はこのメソッドを使ってエラーメッセージを登録します。
		/// このメソッドは引数で与えられた値の後に&lt;br&gt;を追加した文字列をエラーメッセージとして追加し、<see cref="HasErrors"/>をtrueに設定します。
		/// </remarks>
		public void AddErrorMessage(string message)
		{
			errorMessage.Append(message).Append("\r\n");
			hasErrors = true;
		}

		/// <summary>
		/// エラーを全てクリアします。
		/// </summary>
		public void ClearErrors()
		{
			hasErrors = false;
			errorMessage = new StringBuilder();
		}

		/// <summary>
		/// ハイフンで連結されたコードと枝番を分割します。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="combinationCode">
		/// ハイフンで連結された文字列。
		/// </param>
		/// <param name="codeLength">
		/// コードの長さ。
		/// </param>
		/// <param name="code">
		/// コード
		/// </param>
		/// <param name="sbno">
		/// 枝番
		/// </param>
		/// <param name="option">
		/// コードの種類。
		/// </param>
		protected virtual void DivideCombinationCode(string name, string combinationCode, byte codeLength, out string code, out string sbno, CombinationCodeOption option)
		{
			if (combinationCode == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}

			code = string.Empty;
			sbno = string.Empty;
			byte sbnoLength = 0;
			string messageWord = string.Empty;

			switch (option)
			{
				case CombinationCodeOption.Comp:
					sbnoLength = 2;
// 					messageWord = "取引先コード"; //K24546
					messageWord = MultiLanguage.Get("CM_AM001088");
					break;
				case CombinationCodeOption.Proj:
					sbnoLength = 2;
// 					messageWord = "プロジェクトコード"; //K24546
					messageWord = MultiLanguage.Get("CM_AM000656");
					break;
				case CombinationCodeOption.Quote:
					sbnoLength = 2;
// 					messageWord = "見積番号"; //K24546
					messageWord = MultiLanguage.Get("CM_AM000877");
					break;
				case CombinationCodeOption.FabDictate:
					sbnoLength = 3;
// 					messageWord = "製造指図番号"; //K24546
					messageWord = MultiLanguage.Get("CM_AM001181");
					break;
			}

			string[] words = combinationCode.Split(new char[]{'-'}, 3);
			switch (words.Length)
			{
				case 1:
					if (words[0].Length != codeLength + sbnoLength)
					{
						errorMessage.Append(AllegroMessage.S10027(name, codeLength, sbnoLength)).Append("\r\n");
						hasErrors = true;
					}
					else
					{
						code = combinationCode.Substring(0, codeLength);
						sbno = combinationCode.Substring(codeLength, sbnoLength);
					}
					break;
				case 2:
					if ((words[0].Length != codeLength) || (words[1].Length != sbnoLength))
					{
						errorMessage.Append(AllegroMessage.S10027(name, codeLength, sbnoLength)).Append("\r\n");
						hasErrors = true;
					}
					else
					{
						code = words[0];
						sbno = words[1];
					}
					break;
				default:
					errorMessage.Append(AllegroMessage.S10027(name, codeLength, sbnoLength)).Append("\r\n");
					hasErrors = true;
					break;
			}
		}

		/// <summary>
		/// 消費税コードを消費税区分コードと消費税率コードに分割します。
		/// </summary>
		/// <param name="name">
		/// エラーメッセージに表示する項目名。
		/// </param>
		/// <param name="ctaxCode">
		/// 消費税コード
		/// </param>
		/// <param name="ctaxTypeCode">
		/// 消費税区分コード
		/// </param>
		/// <param name="ctaxRateCode">
		/// 消費税率コード
		/// </param>
		protected virtual void DivideCtaxCode(string name, string ctaxCode, out string ctaxTypeCode, out string ctaxRateCode)
		{
			if (ctaxCode.Length != 2)
			{
// 				errorMessage.Append('［').Append(name).Append("］ は 2 文字で入力してください。\r\n"); //K24546
				errorMessage.Append('［').Append(name).Append(MultiLanguage.Get("CM_AM000248"));
				hasErrors = true;

				ctaxTypeCode = string.Empty;
				ctaxRateCode = string.Empty;
			}
			else
			{
				ctaxTypeCode = ctaxCode[0].ToString();
				ctaxRateCode = ctaxCode[1].ToString();
			}
		}
		#endregion

		#region Static Methods
		/// <summary>
		/// 文字列項目のエラーチェックを行います。
		/// </summary>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="maxLength">
		/// 許容する最大桁数。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		public static string ValidateString(string value, int maxLength)
		{
			return ValidateString(value, maxLength, CheckOption.None);
		}

		/// <summary>
		/// 文字列項目のエラーチェックを行います。
		/// </summary>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="maxLength">
		/// 許容する最大桁数。
		/// </param>
		/// <param name="option">
		/// チェックの種類。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		public static string ValidateString(string value, int maxLength, CheckOption option)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (value.Length == 0)
			{
				return string.Empty;
			}
			if (maxLength < value.Length)
			{
				return string.Empty;
			}
			switch (option)
			{
				case CheckOption.SingleByte:
					for (int i = 0; i < value.Length; i++)
					{
						// 「 (スペース)」、「"(ダブルクウォート)」、「'(シングルクウォート)」、「\(バックスラッシュ)」を禁止
						if (value[i] <= 0x0020 || 0x007f <= value[i] || value[i] == 0x0022 || value[i] == 0x0027 || value[i] == 0x005c)
						{
							return string.Empty;
						}
					}
					break;
				case CheckOption.EnglishName:
					for (int i = 0; i < value.Length; i++)
					{
						if (value[i] <= 0x001f || 0x007f <= value[i])
						{
							return string.Empty;
						}
					}
					break;
#if DEBUG
				case CheckOption.FullSizeKatakana:
					for (int i = 0; i < value.Length; i++)
					{
						if ((value[i] <= 0x30a0) || (0x3100 < value[i]))
						{
							return string.Empty;
						}
					}
					break;
#endif
				case CheckOption.SingleByteKatakana:
					StringBuilder convertValue = new StringBuilder(value, value.Length);
					for (int i = 0; i < value.Length; i++)
					{
						if (value[i] != 0x0020 && (value[i] < 0x0028 || value[i] == 0x002b || 0x0039 < value[i]) && (value[i] < 0x0041 || 0x005a < value[i]) && (value[i] < 0xff62 || value[i] == 0xff64 || 0xff9f < value[i]))
						{
							return string.Empty;
						}
						switch (value[i])
						{
							case 'ｧ':
							case 'ｨ':
							case 'ｩ':
							case 'ｪ':
							case 'ｫ':
								convertValue[i] = (char) (value[i] + 0x000a);
								break;
							case 'ｬ':
							case 'ｭ':
							case 'ｮ':
								convertValue[i] = (char) (value[i] + 0x0028);
								break;
							case 'ｯ':
								convertValue[i] = 'ﾂ';
								break;
						}
					}
					value = convertValue.ToString();
					break;
// 管理番号B16832 From
				case CheckOption.HalfWidthANK:
					StringBuilder convertValue2 = new StringBuilder(value, value.Length);
					for (int i = 0; i < value.Length; i++)
					{
						if ((value[i] <= 0x001f || 0x007f <= value[i]) || (value[i] != 0x0020 && (value[i] < 0x0028 || value[i] == 0x002b || 0x0039 < value[i]) && (value[i] < 0x0041 || 0x005a < value[i]) && (value[i] < 0xff62 || value[i] == 0xff64 || 0xff9f < value[i])))
						{
							return string.Empty;
						}
						switch (value[i])
						{
							case 'ｧ':
							case 'ｨ':
							case 'ｩ':
							case 'ｪ':
							case 'ｫ':
								convertValue2[i] = (char) (value[i] + 0x000a);
								break;
							case 'ｬ':
							case 'ｭ':
							case 'ｮ':
								convertValue2[i] = (char) (value[i] + 0x0028);
								break;
							case 'ｯ':
								convertValue2[i] = 'ﾂ';
								break;
							case '･': //0xff65
								convertValue2[i] = '.';
								break;
						}

					}
					value = convertValue2.ToString();
					break;

				case CheckOption.JBAAcHolder:
					StringBuilder convertValue3 = new StringBuilder(value, value.Length);
					for (int i = 0; i < value.Length; i++)
					{
						if (value[i] <= 0x001f || (0x007b <= value[i] && value[i] <= 0xff61) || 0xff9f < value[i] || value[i] == 0xff64 || value[i] == 0xff66 
// 管理番号B20390 From
//// 管理番号B20080 From
////						|| (0x0021 <= value[i] && value[i] <= 0x0027) || (0x002a <= value[i] && value[i] <= 0x002c) || value[i] == 0x002f 
//							|| (0x0021 <= value[i] && value[i] <= 0x0027) || (0x002a <= value[i] && value[i] <= 0x002b) || value[i] == 0x002f 
//// 管理番号B20080 To
							|| (0x0021 <= value[i] && value[i] <= 0x0027) || (0x002a <= value[i] && value[i] <= 0x002b)
// 管理番号B20390 To
							|| (0x003a <= value[i] && value[i] <= 0x0040) || (0x005b <= value[i] && value[i] <= 0x0060)						)
						{
							return string.Empty;
						}
						switch (value[i])
						{
							case 'ｧ':
							case 'ｨ':
							case 'ｩ':
							case 'ｪ':
							case 'ｫ':
								convertValue3[i] = (char) (value[i] + 0x000a);
								break;
							case 'ｬ':
							case 'ｭ':
							case 'ｮ':
								convertValue3[i] = (char) (value[i] + 0x0028);
								break;
							case 'ｯ':
								convertValue3[i] = 'ﾂ';
								break;
							case '･': //0xff65
								convertValue3[i] = '.';
								break;
							case 'a':
							case 'b':
							case 'c':
							case 'd':
							case 'e':
							case 'f':
							case 'g':
							case 'h':
							case 'i':
							case 'j':
							case 'k':
							case 'l':
							case 'm':
							case 'n':
							case 'o':
							case 'p':
							case 'q':
							case 'r':
							case 's':
							case 't':
							case 'u':
							case 'v':
							case 'w':
							case 'x':
							case 'y':
							case 'z':
								convertValue3[i] = (char) (value[i] - 0x0020);
								break;
							case 'ｰ':
								convertValue3[i] = '-';
								break;
						}

					}
					value = convertValue3.ToString();
					break;
// 管理番号B16832 To
// 管理番号B17674 From
				case CheckOption.SingleByteKatakana2:
					for (int i = 0; i < value.Length; i++)
					{
						if (value[i] != 0x0020 && (value[i] < 0x0028 || value[i] == 0x002b || 0x0039 < value[i]) && (value[i] < 0x0041 || 0x005a < value[i]) && (value[i] < 0xff62 || value[i] == 0xff64 || 0xff9f < value[i]))
						{
							return string.Empty;
						}
					}
					break;
// 管理番号B17674 To
// 管理番号B23834 From
                case CheckOption.SingleByteHyphen:
					for (int i = 0; i < value.Length; i++)
					{
						// 「 (スペース)」、「"(ダブルクウォート)」、「'(シングルクウォート)」、「\(バックスラッシュ)」を禁止
						if (value[i] <= 0x0020 || 0x007f <= value[i] || value[i] == 0x0022 || value[i] == 0x0027 || value[i] == 0x005c)
						{
							return string.Empty;
						}
					}
                    for (int icnt = 0; icnt < value.Length; icnt++)
					{
						// 「-(ハイフン)」を禁止
                        if (value[icnt] == 0x002d)
						{
							return string.Empty;
						}
					}
					break;
// 管理番号B23834 To
			}
			return value;
		}

		/// <summary>
		/// 数値項目のエラーチェックを行います。
		/// </summary>
		/// <param name="value">
		/// チェックする文字列。
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
		/// エラーがなければ<paramref name="value"/>。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		public static string ValidateDecimalString(string value, bool allowNegative, byte precision, byte scale)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (value.Length == 0)
			{
				return string.Empty;
			}
// 管理番号 B21907 From
			string tmpValue = value;
			// 小数桁がゼロのString（例：.00～）が引き渡された場合、一度decimalに変換することによって小数桁を省く
			try
			{
// 管理番号 B25484 From
//				value = decimal.Parse(value).ToString("G29");
				value = CutoffDigit(value);
// 管理番号 B25484 To
			}
			catch (FormatException)
			{
				return string.Empty;
			}
// 管理番号 B21907 To
			int index = 0;
			byte precisionCount = 0;
			byte scaleCount = 0;
			if (value[0] == '-')
			{
				if (allowNegative)
				{
					index++;
				}
				else
				{
					return string.Empty;
				}
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
						return string.Empty;
					}
				}
				precisionCount++;
				index++;
			}
			while (index < value.Length)
			{
				if (value[index] < '0' || '9' < value[index])
				{
					return string.Empty;
				}
				scaleCount++;
				index++;
			}
			if (precision - scale < precisionCount || scale < scaleCount)
			{
				return string.Empty;
			}
// 管理番号 B21907 From
			value = tmpValue;
// 管理番号 B21907 To
			return ((value[value.Length - 1] == '.') ? ((value == "-." || value == ".") ? "0" : value.Substring(0, value.Length - 1)) : value);
		}

		/// <summary>
		/// 日付項目のエラーチェックを行います。
		/// </summary>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>の標準日付形式の文字列（yyyy/MM/dd）。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		public static string ValidateDateTimeString(string value)
		{
			return ValidateDateTimeString(value, DateRange.MinValue, DateRange.MaxValue);
		}

		/// <summary>
		/// 日付項目のエラーチェックを行います。
		/// </summary>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="minValue">
		/// 許容する日付の最小値。
		/// </param>
		/// <param name="maxValue">
		/// 許容する日付の最大値。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>の標準日付形式の文字列（yyyy/MM/dd）。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		public static string ValidateDateTimeString(string value, DateTime minValue, DateTime maxValue)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (value.Length == 0)
			{
				return string.Empty;
			}
			string[] yearMonthDate = value.Split(new char[] {'/', '-', '.'}, 3);
			if (yearMonthDate.Length != 3)
			{
				return string.Empty;
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
						return string.Empty;
					}
					break;
				case 4:
					break;
				default:
					return string.Empty;
			}
			// TODO 日本語カルチャのみ
			try
			{
				DateTime date = DateTime.Parse(century + value, CultureInfo.CreateSpecificCulture("ja-JP"));
				if (date < minValue || maxValue < date)
				{
					return string.Empty;
				}
				return date.ToString("yyyy/MM/dd");
			}
			catch (FormatException)
			{
				return string.Empty;
			}
		}

		/// <summary>
		/// 年月項目のエラーチェックを行います。
		/// </summary>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>の標準日付形式の文字列（yyyy/MM）。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		public static string ValidateMonthString(string value)
		{
			return ValidateMonthString(value, DateRange.MinValue, DateRange.MaxValue);
		}

		/// <summary>
		/// 年月項目のエラーチェックを行います。
		/// </summary>
		/// <param name="value">
		/// チェックする文字列。
		/// </param>
		/// <param name="minValue">
		/// 許容する年月の最小値。
		/// </param>
		/// <param name="maxValue">
		/// 許容する年月の最大値。
		/// </param>
		/// <returns>
		/// エラーがなければ<paramref name="value"/>の標準日付形式の文字列（yyyy/MM）。エラーがあった場合は<see cref="string.Empty"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="value"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		public static string ValidateMonthString(string value, DateTime minValue, DateTime maxValue)
		{
			if (value == null)
			{
// 				throw new ArgumentNullException("value", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("value", MultiLanguage.Get("CM_AM001376"));
			}
			if (value.Length == 0)
			{
				return string.Empty;
			}
			string[] yearMonth = value.Split(new char[] {'/', '-', '.'}, 2);
			if (yearMonth.Length != 2)
			{
				return string.Empty;
			}
			string century = string.Empty;
			switch (yearMonth[0].Length)
			{
				case 2:
					try
					{
						int year = int.Parse(yearMonth[0]);
						century = (year < 50 ? "20" : "19");
					}
					catch (FormatException)
					{
						return string.Empty;
					}
					break;
				case 4:
					break;
				default:
					return string.Empty;
			}
			// TODO 日本語カルチャのみ
			try
			{
				DateTime date = DateTime.Parse(century + value + "/01", CultureInfo.CreateSpecificCulture("ja-JP"));
				if (date < minValue || maxValue < date)
				{
					return string.Empty;
				}
				return date.ToString("yyyy/MM");
			}
			catch (FormatException)
			{
				return string.Empty;
			}
		}

// 管理番号 B25484 From
		/// <summary>
		/// 整数部の先頭の0や小数部の末尾の0を削除します。
		/// </summary>
		/// <param name="src">
		/// 変換する文字列。
		/// </param>
		/// <returns>
		/// 数値として不要な桁が取り除かれた文字列。
		/// </returns>
		/// <remarks>
		/// <para>小数部末尾の0を削除したことで末尾が小数点になった場合はこれも削除します。</para>
		/// <para>指定された文字列が数値に変換できない場合は例外が発生します。</para>
		/// </remarks>
		public static string CutoffDigit(string src)
		{
			string value = null;
			value = decimal.Parse(src).ToString("G");
			if (value.Contains("."))
			{
				value = value.TrimEnd('0').TrimEnd('.');
			}
			return value;
		}
// 管理番号 B25484 To
		#endregion

// 管理番号 K25647 From
		/// <summary>
		/// 整数部の桁数を決定するために用いる伝票単位数量の種類。
		/// <para>呼び出し元のモジュールとは必ずしも一致しません。</para>
		/// </summary>
		protected enum SlipQuantity
		{
			/// <summary>
			/// 販売数量
			/// </summary>
			SCSD,
			/// <summary>
			/// 調達在庫数量
			/// </summary>
			SCMM,
			/// <summary>
			/// 債権数量
			/// </summary>
			FIAR,
			/// <summary>
			/// 債務数量
			/// </summary>
			FIAP,
			/// <summary>
			/// 経理数量
			/// </summary>
			FIGL,
		}
// 管理番号 K25647 To
// 管理番号K27095 From
		/// <summary>
		/// 文字変換
		/// 小文字を大文字に変換する。
		/// </summary>
		/// <param name="value">変換前の文字列</param>
		/// <returns>変換後の文字列</returns>
		private string xmlEbConvertValue(string value)
		{

			StringBuilder convertValue = new StringBuilder(value,value.Length);

			for(int i=0; i<value.Length; i++)
			{
				switch (value[i])
				{
					case 'ｧ':
					case 'ｨ':
					case 'ｩ':
					case 'ｪ':
					case 'ｫ':
						convertValue[i] = (char)(value[i] + 0x000a);
						break;
					case 'ｬ':
					case 'ｭ':
					case 'ｮ':
						convertValue[i] = (char)(value[i] + 0x0028);
						break;
					case 'ｯ':
						convertValue[i] = 'ﾂ';
						break;
					case '･': //0xff65
						convertValue[i] = '.';
						break;
					case 'a':
					case 'b':
					case 'c':
					case 'd':
					case 'e':
					case 'f':
					case 'g':
					case 'h':
					case 'i':
					case 'j':
					case 'k':
					case 'l':
					case 'm':
					case 'n':
					case 'o':
					case 'p':
					case 'q':
					case 'r':
					case 's':
					case 't':
					case 'u':
					case 'v':
					case 'w':
					case 'x':
					case 'y':
					case 'z':
						convertValue[i] = (char)(value[i] - 0x0020);
						break;
					case 'ｰ': // 0xff70
						convertValue[i] = '-'; // 0x002d
						break;
				}
			}
			return convertValue.ToString();
		}
// 管理番号K27095 To
	}

	/// <summary>
	/// ハイフンで連結されるコードの種類。
	/// </summary>
	public enum CombinationCodeOption
	{
		/// <summary>
		/// 得意先・仕入先
		/// </summary>
		Comp,
		/// <summary>
		/// プロジェクトコード
		/// </summary>
		Proj,
		/// <summary>
		/// 見積番号
		/// </summary>
		Quote,
		/// <summary>
		/// 製造指図番号
		/// </summary>
		FabDictate
	}
}
