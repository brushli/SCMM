// Product     : Allegro
// Unit        : CM
// Module      : MS
// Function    : --
// File Name   : Supl.cs
// 機能名      : 仕入先共通機能（共通）
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 管理番号B11196 2004/08/23 EC使用フラグの検索条件を追加
// 1.1.2 2004/08/31
// 管理番号B12462 2004/09/14 雑コードの検索条件を追加
// 1.2.0 2004/09/30
// 管理番号K22198 2008/11/04 債権債務勘定振替
// 1.6.0 2009/09/30
// 管理番号K24278 2011/12/21 仕入先課税区分追加対応
// 管理番号K24392 2012/01/27 手形サイト計算対応
// 2.0.0 2012/10/31
// 管理番号B24264 2012/12/05 雑取引先の情報を都度入力できるように修正
// 2.1.0 2013/03/31
// 管理番号K24789 2013/05/08 消費税率の段階的引き上げ対応
// 管理番号K25679 2015/12/04 グループ対応
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;
using System.Data;
using System.Web;
using Infocom.Allegro;

namespace Infocom.Allegro.CM.MS
{
	/// <summary>
	/// 仕入先に関する共通機能を提供します。（共通）
	/// </summary>
	public sealed class Supl
	{
		#region Constructors
		private Supl()
		{
		}
		#endregion

		#region Methods
		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName)
		{
			return  IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, string.Empty, false);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, bool allSupl)
		{
			return  IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, string.Empty, allSupl);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date)
		{
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, false);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl)
		{
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, allSupl, string.Empty);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別（仕入先の場合："S"、支払先の場合："P"）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl, string suplType)
		{
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, allSupl, suplType, string.Empty);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別（仕入先の場合："S"、支払先の場合："P"）
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl, string suplType, string overSeasType)
		{
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, allSupl, suplType, overSeasType, false);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別（仕入先の場合："S"、支払先の場合："P"）
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg)
		{
			string temp;
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, allSupl, suplType, overSeasType, fabConsignSuplFlg, out temp);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別（仕入先の場合："S"、支払先の場合："P"）
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <param name="overSeasFlg">
		/// 海外フラグ（国内の場合： "0"、海外の場合： "1"）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg, out string overSeasFlg)
		{
			overSeasFlg = string.Empty;
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, allSupl, suplType, overSeasType, fabConsignSuplFlg, out overSeasFlg, false);
		}
// 管理番号B12462 From

		/// <summary>
		/// 仕入先の存在チェック及び仕入先情報を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別（仕入先の場合："S"、支払先の場合："P"）
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <param name="overSeasFlg">
		/// 海外フラグ（国内の場合： "0"、海外の場合： "1"）
		/// </param>
		/// <param name="ecFlg">
		/// ECフラグ（EC仕入先の場合：true、それ以外の場合：false）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg, out string overSeasFlg, bool ecFlg)
		{
			overSeasFlg = string.Empty;
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, allSupl, suplType, overSeasType, fabConsignSuplFlg, out overSeasFlg,ecFlg, false);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先情報を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別（仕入先の場合："S"、支払先の場合："P"）
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <param name="overSeasFlg">
		/// 海外フラグ（国内の場合： "0"、海外の場合： "1"）
		/// </param>
		/// <param name="ecFlg">
		/// ECフラグ（EC仕入先の場合：true、それ以外の場合：false）
		/// </param>
		/// <param name="tempCodeFlg">
		/// 雑コードフラグ（雑得意先の場合：true、それ以外の場合：false）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
//		public static bool IsExists(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg, out string overSeasFlg, bool ecFlg)
		public static bool IsExists(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg, out string overSeasFlg, bool ecFlg, bool tempCodeFlg)
// 管理番号B12462 To
		{
			overSeasFlg = string.Empty;

			if (string.Equals(suplCombinationCode, string.Empty))
			{
				suplShortName = string.Empty;
				return false;
			}

// 管理番号B12462 From
//			string temp = BL_CM_MS_Supl.GetShortName(commonData, suplCombinationCode, compCodeLength, date, allSupl, suplType, overSeasType, fabConsignSuplFlg, out overSeasFlg, ecFlg);
			string temp = BL_CM_MS_Supl.GetShortName(commonData, suplCombinationCode, compCodeLength, date, allSupl, suplType, overSeasType, fabConsignSuplFlg, out overSeasFlg, ecFlg, tempCodeFlg);
// 管理番号B12462 To
			if (string.Equals(temp, AllegroMessage.S10028))
			{
				suplShortName = temp;
				return false;
			}
			else
			{
				suplShortName = temp;
				return true;
			}
		}

// 管理番号K25679 From
		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="compCode">
		/// 取引先コード
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsGroup(CommonData commonData, string suplCombinationCode, byte compCodeLength, string compCode, string date, out string suplShortName)
		{
			if (string.Equals(suplCombinationCode, string.Empty))
			{
				suplShortName = string.Empty;
				return false;
			}

			string temp = string.Empty;
			bool ret = BL_CM_MS_Supl.GetGroupShortName(commonData, suplCombinationCode, compCodeLength, compCode, date, out temp);
			if (!ret)
			{
				suplShortName = temp;
				return false;
			}
			else
			{
				suplShortName = temp;
				return true;
			}
		}
// 管理番号K25679 To


		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName)
		{
			return  IsExistsSupl(commonData, suplCombinationCode, compCodeLength, out suplShortName, string.Empty, false);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, bool allSupl)
		{
			return  IsExistsSupl(commonData, suplCombinationCode, compCodeLength, out suplShortName, string.Empty, allSupl);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date)
		{
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, false);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl)
		{
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, allSupl, "S");
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl, string overSeasType)
		{
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, allSupl, "S", overSeasType);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl, string overSeasType, bool fabConsignSuplFlg)
		{
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, allSupl, "S", overSeasType, fabConsignSuplFlg);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先情報を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <param name="overSeasFlg">
		/// 海外フラグ（国内の場合： "0"、海外の場合： "1"）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl, string overSeasType, bool fabConsignSuplFlg, out string overSeasFlg)
		{
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, allSupl, "S", overSeasType, fabConsignSuplFlg, out overSeasFlg);
		}

		/// <summary>
		/// 仕入先の存在チェック及び仕入先略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <param name="ecFlg">
		/// ECフラグ（EC仕入先の場合：true、それ以外の場合：false）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl, string overSeasType, bool fabConsignSuplFlg, bool ecFlg)
		{
			string overSeasFlg = string.Empty;
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, allSupl, "S", overSeasType, fabConsignSuplFlg, out overSeasFlg, ecFlg);
		}


		/// <summary>
		/// 指定された仕入先に紐づく支払先の存在チェック及び支払先略名を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsPymtSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName)
		{
			return  IsExistsPymtSupl(commonData, suplCombinationCode, compCodeLength, out suplShortName, string.Empty, false);
		}

		/// <summary>
		/// 指定された仕入先に紐づく支払先の存在チェック及び支払先略名を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsPymtSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, bool allSupl)
		{
			return  IsExistsPymtSupl(commonData, suplCombinationCode, compCodeLength, out suplShortName, string.Empty, allSupl);
		}

		/// <summary>
		/// 指定された仕入先に紐づく支払先の存在チェック及び支払先略名を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsPymtSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date)
		{
			return IsExistsPymtSupl(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, false);
		}

		/// <summary>
		/// 指定された仕入先に紐づく支払先の存在チェック及び支払先略名を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsPymtSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl)
		{
			return IsExistsPymtSupl(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, allSupl, string.Empty);
		}

		/// <summary>
		/// 指定された仕入先に紐づく支払先の存在チェック及び支払先略名を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="suplShortName">
		/// 仕入先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsPymtSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string suplShortName, string date, bool allSupl, string overSeasType)
		{
			return IsExists(commonData, suplCombinationCode, compCodeLength, out suplShortName, date, allSupl, "P", overSeasType);
		}


		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCode, string suplSbno)
		{
			return IsExists(commonData, suplCode, suplSbno, string.Empty, false);
		}

		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCode, string suplSbno, bool allSupl)
		{
			return IsExists(commonData, suplCode, suplSbno, string.Empty, allSupl);
		}

		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCode, string suplSbno, string date)
		{
			return IsExists(commonData, suplCode, suplSbno, date, false);
		}

		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl)
		{
			return IsExists(commonData, suplCode, suplSbno, date, allSupl, string.Empty);
		}

		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別（仕入先の場合："S"、支払先の場合："P"）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl, string suplType)
		{
			return IsExists(commonData, suplCode, suplSbno, date, allSupl, suplType, string.Empty);
		}

		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別（仕入先の場合："S"、支払先の場合："P"）
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl, string suplType, string overSeasType)
		{
			return IsExists(commonData, suplCode, suplSbno, date, allSupl, suplType, overSeasType, false);
		}

		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別（仕入先の場合："S"、支払先の場合："P"）
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg)
		{
			return IsExists(commonData, suplCode, suplSbno, date, allSupl, suplType, overSeasType, false, false);
		}

		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別（仕入先の場合："S"、支払先の場合："P"）
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <param name="ecFlg">
		/// ECフラグ（EC仕入先の場合：true、それ以外の場合：false）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg, bool ecFlg)
		{
			if (string.Equals(suplCode, string.Empty) || string.Equals(suplSbno, string.Empty))
			{
				return false;
			}
			return BL_CM_MS_Supl.IsExists(commonData, suplCode, suplSbno, date, allSupl, suplType, overSeasType, fabConsignSuplFlg, ecFlg);
		}


		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCode, string suplSbno)
		{
			return IsExistsSupl(commonData, suplCode, suplSbno, string.Empty, false);
		}

		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCode, string suplSbno, bool allSupl)
		{
			return IsExistsSupl(commonData, suplCode, suplSbno, string.Empty, allSupl);
		}

		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCode, string suplSbno, string date)
		{
			return IsExistsSupl(commonData, suplCode, suplSbno, date, false);
		}

		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl)
		{
			return IsExists(commonData, suplCode, suplSbno, date, allSupl, "S");
		}

		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl, string overSeasType)
		{
			return IsExists(commonData, suplCode, suplSbno, date, allSupl, "S", overSeasType);
		}

		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl, string overSeasType, bool fabConsignSuplFlg)
		{
			return IsExists(commonData, suplCode, suplSbno, date, allSupl, "S", overSeasType, fabConsignSuplFlg);
		}

		/// <summary>
		/// 仕入先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分（国内の場合："D"、海外の場合："O"、全ての場合：""）
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <param name="ecFlg">
		/// ECフラグ（EC仕入先の場合：true、それ以外の場合：false）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl, string overSeasType, bool fabConsignSuplFlg, bool ecFlg)
		{
			return IsExists(commonData, suplCode, suplSbno, date, allSupl, "S", overSeasType, fabConsignSuplFlg, ecFlg);
		}


		/// <summary>
		/// 仕入先に紐づく支払先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsPymtSupl(CommonData commonData, string suplCode, string suplSbno)
		{
			return IsExistsPymtSupl(commonData, suplCode, suplSbno, string.Empty, false);
		}

		/// <summary>
		/// 仕入先に紐づく支払先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsPymtSupl(CommonData commonData, string suplCode, string suplSbno, bool allSupl)
		{
			return IsExistsPymtSupl(commonData, suplCode, suplSbno, string.Empty, allSupl);
		}

		/// <summary>
		/// 仕入先に紐づく支払先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsPymtSupl(CommonData commonData, string suplCode, string suplSbno, string date)
		{
			return IsExistsPymtSupl(commonData, suplCode, suplSbno, date, false);
		}

		/// <summary>
		/// 仕入先に紐づく支払先の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsPymtSupl(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl)
		{
			return IsExists(commonData, suplCode, suplSbno, date, allSupl, "P");
		}


// 管理番号 K24789 From
// 管理番号 K24789 コメント削除

// 管理番号 K24278 コメント削除

		/// <summary>
		/// 仕入先の消費税関連情報を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="ctaxBuildupType">
		/// 消費税積上区分
		/// </param>
		/// <param name="roundType">
		/// 丸め区分
		/// </param>
		/// <param name="imposeFlg">
		/// 消費税課税フラグ
		/// </param>
		/// <returns>
		/// データが存在するかどうか。
		/// </returns>
		public static bool GetCtaxInfo(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string ctaxBuildupType, out string roundType, out string imposeFlg)
		{
			ctaxBuildupType = string.Empty;
			roundType		= string.Empty;
			imposeFlg		= string.Empty;

			if (string.Equals(suplCombinationCode, string.Empty))
			{
				return false;
			}
			string ctaxBuildupType_b;
			string roundType_b;
			string imposeFlg_b;

			if (BL_CM_MS_Supl.GetCtaxInfo(commonData, suplCombinationCode, compCodeLength, out ctaxBuildupType_b, out roundType_b, out imposeFlg_b))
			{
				ctaxBuildupType = ctaxBuildupType_b;
				roundType		= roundType_b;
				imposeFlg		= imposeFlg_b;

				return true;
			}
			else
			{
				return false;
			}
		}
// 管理番号 K24789 To

		/// <summary>
		/// 仕入先に紐づく支払先の取引条件を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <returns>
		/// 取引条件
		/// </returns>
		public static DataTable SetDtData(CommonData commonData, string suplCode, string suplSbno)
		{
			return BL_CM_MS_Supl.GetDtData(commonData, suplCode, suplSbno);
		}

		/// <summary>
		/// 仕入先に紐づく支払先の取引条件を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <returns>
		/// 取引条件
		/// </returns>
		public static DataTable SetDtData(CommonData commonData, string suplCombinationCode , byte compCodeLength, string date)
		{
			String code = string.Empty;
			String sbno = string.Empty;
			SuplCombination(commonData, suplCombinationCode, compCodeLength, out code, out sbno);

			return BL_CM_MS_Supl.GetDtData(commonData, code, sbno, date);
		}

		/// <summary>
		/// 指定された仕入先が存在する場合、雑コードを取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="tempCodeFlg">
		/// 雑コードフラグ
		/// </param>
		/// <returns>
		/// データが存在するかどうか。
		/// </returns>
		public static bool GetTempCodeFlg(CommonData commonData, string suplCombinationCode, int compCodeLength, out bool tempCodeFlg)
		{
			tempCodeFlg = false;

			if (string.Equals(suplCombinationCode, string.Empty))
			{
				return false;
			}

			return BL_CM_MS_Supl.GetTempCodeFlg(commonData, suplCombinationCode, compCodeLength, out tempCodeFlg);
		}

		/// <summary>
		/// 仕入先の取引通貨コードを取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <returns>
		/// 取引通貨コード
		/// </returns>
		public static string GetDealCurCode(CommonData commonData, string suplCombinationCode , byte compCodeLength)
		{
			String code = string.Empty;
			String sbno = string.Empty;
			SuplCombination(commonData, suplCombinationCode, compCodeLength, out code, out sbno);

			return BL_CM_MS_Supl.GetDealCurCode(commonData, code, sbno);
		}

		/// <summary>
		/// 仕入先コード＋仕入先枝番より、仕入先コードと仕入先枝番に分割します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="code">
		/// 仕入先コード
		/// </param>
		/// <param name="sbno">
		/// 仕入先枝番
		/// </param>
		/// <returns>
		/// 分割に成功したかどうか。
		/// </returns>
		public static bool SuplCombination(CommonData commonData, String suplCombinationCode, byte compCodeLength ,out string code ,out string sbno)
		{
			String[] words = suplCombinationCode.Split(new char[]{'-'}, 3);
			code = string.Empty;
			sbno = string.Empty;
			switch (words.Length)
			{
				case 1:
					if (words[0].Length != compCodeLength + 2)
					{
						return false;
					}
					code = words[0].Substring(0, compCodeLength);
					sbno = words[0].Substring(compCodeLength, 2);
					break;
				case 2:
					if (words[0].Length > compCodeLength || words[1].Length != 2)
					{
						return false;
					}
					code = words[0];
					sbno = words[1];
					break;
				default:
					return false;
			}
			return true;
		}

// 管理番号K22198 From
		/// <summary>
		/// 指定された仕入先が存在する場合、支払先情報を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="pymtsuplCombinationCode">
		/// 支払先コードと支払先枝番の連結した文字列
		/// </param>
		/// <param name="pymtsuplShortName">
		/// 支払先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <returns>
		/// データが存在するかどうか。
		/// </returns>
		public static bool GetPymtSupl(CommonData commonData, string suplCombinationCode, int compCodeLength, out string pymtsuplCombinationCode, out string pymtsuplShortName, string date)
		{
			return GetPymtSupl(commonData, suplCombinationCode, compCodeLength, out pymtsuplCombinationCode, out pymtsuplShortName, date, false);
		}

		/// <summary>
		/// 指定された仕入先が存在する場合、支払先情報を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="pymtsuplCombinationCode">
		/// 支払先コードと支払先枝番の連結した文字列
		/// </param>
		/// <param name="pymtsuplShortName">
		/// 支払先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// データが存在するかどうか。
		/// </returns>
		public static bool GetPymtSupl(CommonData commonData, string suplCombinationCode, int compCodeLength, out string pymtsuplCombinationCode, out string pymtsuplShortName, string date, bool allSupl)
		{
			pymtsuplCombinationCode = string.Empty;
			pymtsuplShortName = string.Empty;

			if (suplCombinationCode == string.Empty)
			{
				return false;
			}
			string pymtsuplCombinationCode_b = string.Empty;
			string pymtsuplShortName_b = string.Empty;
			if (BL_CM_MS_Supl.GetPymtSupl(commonData, suplCombinationCode, compCodeLength, out pymtsuplCombinationCode_b, out pymtsuplShortName_b, date, allSupl))
			{
				pymtsuplCombinationCode = pymtsuplCombinationCode_b;
				pymtsuplShortName = pymtsuplShortName_b;

				return true;
			}
			else
			{
				return false;
			}
		}
// 管理番号K22198 To

		/// <summary>
		/// 仕入先が存在する場合、サイト計算区分と期日休日回避区分を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <param name="sightCalcType">
		/// サイト計算区分
		/// </param>
		/// <param name="dueHolidayAvoidanceType">
		/// 期日休日回避区分
		/// </param>
		/// <returns>
		/// データが存在するかどうか。
		/// </returns>
// 管理番号K24392 From
		public static bool GetSightDueDate(CommonData commonData, string suplCode, string suplSbno, out string sightCalcType, out string dueHolidayAvoidanceType)
		{
			return BL_CM_MS_Supl.GetSightDueDate(commonData, suplCode, suplSbno, out sightCalcType, out dueHolidayAvoidanceType);
		}
// 管理番号K24392 To

		/// <summary>
		/// 仕入先住所情報を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <returns>
		/// 仕入先住所情報
		/// </returns>
// 管理番号 B24264 From
		public static DataTable GetAddress(CommonData commonData, string suplCode, string suplSbno)
		{
			return BL_CM_MS_Supl.GetAddress(commonData, suplCode, suplSbno);
		}
// 管理番号 B24264 To

		/// <summary>
		/// 仕入先が存在する場合、消費税関連情報を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="ctaxBuildupType">
		/// 消費税積上区分
		/// </param>
		/// <param name="roundType">
		/// 丸め区分
		/// </param>
		/// <returns>
		/// データが存在するかどうか。
		/// </returns>
// 管理番号 K24789 From
		public static bool GetPymtCtaxInfo(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string ctaxBuildupType, out string roundType)
		{
			ctaxBuildupType = string.Empty;
			roundType		= string.Empty;

			if (string.Equals(suplCombinationCode, string.Empty))
			{
				return false;
			}
			string ctaxBuildupType_b;
			string roundType_b;

			if (BL_CM_MS_Supl.GetPymtCtaxInfo(commonData, suplCombinationCode, compCodeLength, out ctaxBuildupType_b, out roundType_b))
			{
				ctaxBuildupType = ctaxBuildupType_b;
				roundType		= roundType_b;

				return true;
			}
			else
			{
				return false;
			}
		}
// 管理番号 K24789 To
		#endregion
	}
}
