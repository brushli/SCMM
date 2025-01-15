// Product     : Allegro
// Unit        : CM
// Module      : MS
// Function    : --
// File Name   : BL_CM_MS_Supl.cs
// 機能名      : 仕入先共通機能（共通）
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 管理番号B11196 2004/08/23 EC使用フラグの検索条件を追加
// 1.1.2 2004/08/31
// 管理番号B12462 2004/09/14 雑仕入先コードの検索条件を追加
// 1.2.2 2004/10/31
// 管理番号P18435 2006/12/14 パフォーマンス対応（2006年9月末分）：タイムアウト値延長 (パフォーマンス考慮の為保留）
// 1.5.1 2007/06/30
// 管理番号K22198 2008/11/04 債権債務勘定振替
// 1.6.0 2009/09/30
// 管理番号K24278 2011/12/21 仕入先課税区分追加対応
// 管理番号K24392 2012/01/27 手形サイト計算対応
// 2.0.0 2012/10/31
// 管理番号B24264 2012/12/05 雑取引先の情報を都度入力できるように修正
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 管理番号K24789 2013/05/08 消費税率の段階的引き上げ対応
// 2.2.0 2014/10/31
// 管理番号K25679 2015/12/04 グループ対応
// 管理番号K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 3.0.0 2018/04/30
// 管理番号K27011 2019/01/23 項目桁数拡張：取引先・商品・勘定科目
// 3.1.0 2020/06/30
// 管理番号K27230 2021/07/20 脆弱性対応
// 管理番号K27445 2022/08/19 ログ管理強化
// 3.2.0 2023/03/31

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Infocom.Allegro.BL.SqlClient;
using Infocom.Allegro.IF;

namespace Infocom.Allegro.CM.MS
{
	/// <summary>
	/// 仕入先に関する共通機能を提供します。（共通）
	/// </summary>
	public sealed class BL_CM_MS_Supl : MarshalByRefObject
	{
		#region Constructors
		private BL_CM_MS_Supl()
		{
		}
		#endregion

		#region Static Methods
		/// <summary>
		/// 仕入先略名を取得します。
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
		/// 仕入先略名
		/// </returns>
		public static string GetShortName(CommonData commonData, string suplCombinationCode, byte compCodeLength)
		{
			return GetShortName(commonData, suplCombinationCode, compCodeLength, string.Empty, false);
		}

		/// <summary>
		/// 仕入先略名を取得します。
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
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 仕入先略名
		/// </returns>
		public static string GetShortName(CommonData commonData, string suplCombinationCode, byte compCodeLength, bool allSupl)
		{
			return GetShortName(commonData, suplCombinationCode, compCodeLength, string.Empty, allSupl);
		}

		/// <summary>
		/// 仕入先略名を取得します。
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
		/// 仕入先略名
		/// </returns>
		public static string GetShortName(CommonData commonData, string suplCombinationCode, byte compCodeLength, string date)
		{
			return GetShortName(commonData, suplCombinationCode, compCodeLength, date, false, string.Empty);
		}

		/// <summary>
		/// 仕入先略名を取得します。
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
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 仕入先略名
		/// </returns>
		public static string GetShortName(CommonData commonData, string suplCombinationCode, byte compCodeLength, string date, bool allSupl)
		{
			return GetShortName(commonData, suplCombinationCode, compCodeLength, date, allSupl, string.Empty);
		}

		/// <summary>
		/// 仕入先略名を取得します。
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
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別
		/// </param>
		/// <returns>
		/// 仕入先略名
		/// </returns>
		public static string GetShortName(CommonData commonData, string suplCombinationCode, byte compCodeLength, string date, bool allSupl, string suplType)
		{
			return GetShortName(commonData, suplCombinationCode, compCodeLength, date, allSupl, suplType, string.Empty);
		}

		/// <summary>
		/// 仕入先略名を取得します。
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
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分
		/// </param>
		/// <returns>
		/// 仕入先略名
		/// </returns>
		public static string GetShortName(CommonData commonData, string suplCombinationCode, byte compCodeLength, string date, bool allSupl, string suplType, string overSeasType)
		{
			return GetShortName(commonData, suplCombinationCode, compCodeLength, date, allSupl, suplType, string.Empty, false);
		}

		/// <summary>
		/// 仕入先略名を取得します。
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
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <returns>
		/// 仕入先略名
		/// </returns>
		public static string GetShortName(CommonData commonData, string suplCombinationCode, byte compCodeLength, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg)
		{
			string temp;
			return GetShortName(commonData, suplCombinationCode, compCodeLength, date, allSupl, suplType, string.Empty, false, out temp);
		}

		/// <summary>
		/// 仕入先略名及び海外フラグを取得します。
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
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <param name="overSeasFlg">
		/// 海外フラグ（国内の場合： "0"、海外の場合： "1"）
		/// </param>
		/// <returns>
		/// 仕入先略名
		/// </returns>
		public static string GetShortName(CommonData commonData, string suplCombinationCode, byte compCodeLength, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg, out string overSeasFlg)
		{
			overSeasFlg = string.Empty;
			return GetShortName(commonData, suplCombinationCode, compCodeLength, date, allSupl, suplType, string.Empty, false, out overSeasFlg, false);
		}

// 管理番号B12462 From
		/// <summary>
		/// 仕入先略名及び海外フラグを取得します。
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
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <param name="overSeasFlg">
		/// 海外フラグ（国内の場合： "0"、海外の場合： "1"）
		/// </param>
		/// <param name="ecFlg">
		/// ECフラグ
		/// </param>
		/// <returns>
		/// 仕入先略名
		/// </returns>
		public static string GetShortName(CommonData commonData, string suplCombinationCode, byte compCodeLength, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg, out string overSeasFlg, bool ecFlg)
		{
			overSeasFlg = string.Empty;
			return GetShortName(commonData, suplCombinationCode, compCodeLength, date, allSupl, suplType, string.Empty, false, out overSeasFlg, ecFlg, false);
		}

		/// <summary>
		/// 仕入先略名及び海外フラグを取得します。
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
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <param name="suplType">
		/// 仕入先種別
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <param name="overSeasFlg">
		/// 海外フラグ（国内の場合： "0"、海外の場合： "1"）
		/// </param>
		/// <param name="ecFlg">
		/// ECフラグ
		/// </param>
		/// <param name="tempCodeFlg">
		/// 雑コードフラグ
		/// </param>
		/// <returns>
		/// 仕入先略名
		/// </returns>
//		public static string GetShortName(CommonData commonData, string suplCombinationCode, byte compCodeLength, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg, out string overSeasFlg, bool ecFlg)
		public static string GetShortName(CommonData commonData, string suplCombinationCode, byte compCodeLength, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg, out string overSeasFlg, bool ecFlg, bool tempCodeFlg)
// 管理番号B12462 To
		{
			string keyCurCode = GetKeyCurCode(commonData);
			overSeasFlg = string.Empty;

			if (string.Equals(suplCombinationCode, string.Empty))
			{
				return string.Empty;
			}

			if (date != string.Empty)
			{
				DateTime dateTime;
				try
				{
					// TODO
					// dateTime = DateRange.ToDateTime(date);
					dateTime = Convert.ToDateTime(date);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			String[] words = suplCombinationCode.Split(new char[]{'-'}, 3);
			string code = string.Empty;
			string sbno = string.Empty;
			switch (words.Length)
			{
				case 1:
// 管理番号K27011 From
//					if (words[0].Length != compCodeLength + 2)
					if (words[0].Length != compCodeLength + TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
					{
						return AllegroMessage.S10028;
					}
					code = words[0].Substring(0, compCodeLength);
// 管理番号K27011 From
//					sbno = words[0].Substring(compCodeLength, 2);
					sbno = words[0].Substring(compCodeLength, TypeLength.CompSbnoInputDigit);
// 管理番号K27011 To
					break;
				case 2:
// 管理番号K27011 From
//					if (words[0].Length > compCodeLength || words[1].Length != 2)
					if (words[0].Length > compCodeLength || words[1].Length != TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
					{
						return AllegroMessage.S10028;
					}
					code = words[0];
					sbno = words[1];
					break;
				default:
					return AllegroMessage.S10028;
			}

			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT ");
			if (date != string.Empty)
			{
				sb.Append(" CASE WHEN [NEW_SUPL_NAME_CHANGE_DATE] > @Date ");
			}
			else
			{
				sb.Append(" CASE WHEN [NEW_SUPL_NAME_CHANGE_DATE] > GETDATE() ");
			}
			sb.Append(" THEN [SUPL_SHORT_NAME] ");
			sb.Append(" ELSE ISNULL([NEW_SUPL_SHORT_NAME], [SUPL_SHORT_NAME]) ");
			sb.Append(" END AS [SHORT_NAME] ");
			sb.Append(" ,[OVERSEAS_FLG] AS [OVERSEAS_FLG] ");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));
			sb.Append(" AS [SU] ");

			if (string.Equals(suplType, "P"))
			{   // 支払先取得
				sb.Append(" INNER JOIN (SELECT DISTINCT [PYMT_SUPL_CODE], [PYMT_SUPL_SBNO] FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));
				if (date != string.Empty)
				{
					sb.Append(" WHERE @Date BETWEEN [USE_STT_DATE] AND [USE_END_DATE]");
				}
				if (!allSupl)
				{
					sb.Append(date != string.Empty ? " AND" : " WHERE");
					sb.Append(" [VALID_FLG] = '1'");
				}
				sb.Append(" ) AS [PYMT]");
				sb.Append("  ON [SU].[SUPL_CODE] = [PYMT].[PYMT_SUPL_CODE] ");
				sb.Append(" AND [SU].[SUPL_SBNO] = [PYMT].[PYMT_SUPL_SBNO] ");
			}

			sb.Append(" WHERE [SUPL_CODE] = @SuplCode");
			sb.Append("   AND [SUPL_SBNO] = @SuplSbno");
			if (date != string.Empty)
			{
				sb.Append("   AND @Date BETWEEN [USE_STT_DATE] AND [USE_END_DATE]");
			}
			if (!allSupl)
			{
				sb.Append("   AND [VALID_FLG] = '1'");
			}
			if (overSeasType.Length != 0)
			{
				if (string.Equals(overSeasType, "D"))
				{
					sb.Append("   AND [OVERSEAS_FLG] = '0' ");
				}
				else if (string.Equals(overSeasType, "O"))
				{
					sb.Append("   AND [OVERSEAS_FLG] = '1' ");
				}
				else if (string.Equals(overSeasType, "B"))
				{
					sb.Append("   AND ([OVERSEAS_FLG] = '1' ");
					sb.Append("   OR [DEAL_CUR_CODE] <> @KeyCurCode");
					sb.Append(")");
				}			
			}
			if (fabConsignSuplFlg)
			{
				sb.Append("   AND [FAB_CONSIGN_SUPL_FLG] = '1' ");
			}
			if (string.Equals(suplType, "S"))
			{   // 仕入先取得
				sb.Append("  AND [SU].[SUPL_FLG] = '1' ");
			}
// 管理番号B11196 From
			if (ecFlg)
			{
				sb.Append("   AND [EC_USE_FLG] = '1' ");
			}
// 管理番号B11196 To
// 管理番号B12462 From
			// 雑フラグ
			if (tempCodeFlg)
			{   
				sb.Append("  AND [SU].[TEMP_CODE_FLG] = '1' ");
			}
// 管理番号B12462 To

//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
//			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To

// 管理番号K27011 From
//			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, 8).Value = ConvertDBData.ToNVarChar(code);
//			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, 2).Value = ConvertDBData.ToNVarChar(sbno);
			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, TypeLength.CompCode).Value = ConvertDBData.ToNVarChar(code);
			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, TypeLength.CompSbno).Value = ConvertDBData.ToNVarChar(sbno);
// 管理番号K27011 To

			if (overSeasType.Length != 0)
			{
				if (string.Equals(overSeasType, "B"))
				{
					cm.Parameters.Add("@KeyCurCode", SqlDbType.NVarChar, 3).Value = ConvertDBData.ToNVarChar(keyCurCode);
				}
			}

			if (date != string.Empty)
			{
				cm.Parameters.Add("@Date", SqlDbType.DateTime).Value = ConvertDBData.ToDateTime(date); //TODO 日付部分のみ
			}

			string shortName = string.Empty;
			cn.Open();
			SqlDataReader dr = cm.ExecuteReader();
			try
			{
				if (dr.Read())
				{
					shortName = dr["SHORT_NAME"].ToString();
					overSeasFlg = dr["OVERSEAS_FLG"].ToString();
				}
				else
				{
					shortName = AllegroMessage.S10028;
				}
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
			finally
			{
				dr.Close();
				cn.Close();
			}
			return shortName;
		}

// 管理番号K25679 From
		/// <summary>
		/// 指定された取引先と仕入先コードに紐づく仕入先が存在する場合、仕入先略名を取得します。
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
		/// <param name="shortName">
		/// 仕入先略名
		/// </param>
		/// <returns>
		/// データが存在するかどうか。
		/// </returns>
		public static bool GetGroupShortName(CommonData commonData, string suplCombinationCode, byte compCodeLength, string compCode, string date, out string shortName)
		{
			shortName = string.Empty;
			bool ret = false;

			if (string.Equals(suplCombinationCode, string.Empty))
			{
				return ret;
			}

			if (date != string.Empty)
			{
				DateTime dateTime;
				try
				{
					dateTime = Convert.ToDateTime(date);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			String[] words = suplCombinationCode.Split(new char[] { '-' }, 3);
			string code = string.Empty;
			string sbno = string.Empty;
			switch (words.Length)
			{
				case 1:
// 管理番号K27011 From
//					if (words[0].Length != compCodeLength + 2)
					if (words[0].Length != compCodeLength + TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
					{
						shortName = AllegroMessage.S10028;
						return ret;
					}
					code = words[0].Substring(0, compCodeLength);
// 管理番号K27011 From
//					sbno = words[0].Substring(compCodeLength, 2);
					sbno = words[0].Substring(compCodeLength, TypeLength.CompSbnoInputDigit);
// 管理番号K27011 To
					break;
				case 2:
// 管理番号K27011 From
//					if (words[0].Length > compCodeLength || words[1].Length != 2)
					if (words[0].Length > compCodeLength || words[1].Length != TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
					{
						shortName = AllegroMessage.S10028;
						return ret;
					}
					code = words[0];
					sbno = words[1];
					break;
				default:
					shortName = AllegroMessage.S10028;
					return ret;
			}

			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT ");
			if (date != string.Empty)
			{
				sb.Append(" CASE WHEN [SU].[NEW_SUPL_NAME_CHANGE_DATE] > @Date ");
			}
			else
			{
				sb.Append(" CASE WHEN [SU].[NEW_SUPL_NAME_CHANGE_DATE] > GETDATE() ");
			}
			sb.Append(" THEN [SU].[SUPL_SHORT_NAME] ");
			sb.Append(" ELSE ISNULL([SU].[NEW_SUPL_SHORT_NAME], [SU].[SUPL_SHORT_NAME]) ");
			sb.Append(" END AS [SHORT_NAME] ");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));
			sb.Append(" AS [SU] ");
			sb.Append(" WHERE [SU].[SUPL_CODE] = @SuplCode");
			sb.Append("   AND [SU].[SUPL_SBNO] = @SuplSbno");
			sb.Append("   AND [SU].[SUPL_CODE] = @CompCode");
			if (date != string.Empty)
			{
				sb.Append("   AND @Date BETWEEN [USE_STT_DATE] AND [USE_END_DATE]");
			}
			sb.Append("   AND [SU].[VALID_FLG] = N'1'");

			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230

// 管理番号K27011 From
//			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, 8).Value = ConvertDBData.ToNVarChar(code);
//			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, 2).Value = ConvertDBData.ToNVarChar(sbno);
//			cm.Parameters.Add("@CompCode", SqlDbType.NVarChar, 8).Value = ConvertDBData.ToNVarChar(compCode);
			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, TypeLength.CompCode).Value = ConvertDBData.ToNVarChar(code);
			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, TypeLength.CompSbno).Value = ConvertDBData.ToNVarChar(sbno);
			cm.Parameters.Add("@CompCode", SqlDbType.NVarChar, TypeLength.CompCode).Value = ConvertDBData.ToNVarChar(compCode);
// 管理番号K27011 To

			if (date != string.Empty)
			{
				cm.Parameters.Add("@Date", SqlDbType.DateTime).Value = ConvertDBData.ToDateTime(date); 
			}

			cn.Open();
			SqlDataReader dr = cm.ExecuteReader();
			try
			{
				if (dr.Read())
				{
					shortName = dr["SHORT_NAME"].ToString();
					ret = true;
				}
				else
				{
					shortName = AllegroMessage.S10028;
				}
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
			finally
			{
				dr.Close();
				cn.Close();
			}
			return ret;
		}
// 管理番号K25679 To

		/// <summary>
		/// 仕入先略名を取得します。
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
		/// 仕入先略名
		/// </returns>
		public static string GetShortNameSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength)
		{
			return GetShortNameSupl(commonData, suplCombinationCode, compCodeLength, string.Empty, false);
		}

		/// <summary>
		/// 仕入先略名を取得します。
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
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 仕入先略名
		/// </returns>
		public static string GetShortNameSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, bool allSupl)
		{
			return GetShortNameSupl(commonData, suplCombinationCode, compCodeLength, string.Empty, allSupl);
		}

		/// <summary>
		/// 仕入先略名を取得します。
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
		/// 仕入先略名
		/// </returns>
		public static string GetShortNameSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, string date)
		{
			return GetShortNameSupl(commonData, suplCombinationCode, compCodeLength, date, false);
		}

		/// <summary>
		/// 仕入先略名を取得します。
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
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 仕入先略名
		/// </returns>
		public static string GetShortNameSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, string date, bool allSupl)
		{
			return GetShortName(commonData, suplCombinationCode, compCodeLength, date, allSupl, "S");
		}

		/// <summary>
		/// 支払先略名を取得します。
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
		/// 支払先略名
		/// </returns>
		public static string GetShortNamePymtSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength)
		{
			return GetShortNamePymtSupl(commonData, suplCombinationCode, compCodeLength, string.Empty, false);
		}

		/// <summary>
		/// 支払先略名を取得します。
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
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 支払先略名
		/// </returns>
		public static string GetShortNamePymtSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, bool allSupl)
		{
			return GetShortNamePymtSupl(commonData, suplCombinationCode, compCodeLength, string.Empty, allSupl);
		}

		/// <summary>
		/// 支払先略名を取得します。
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
		/// 支払先略名
		/// </returns>
		public static string GetShortNamePymtSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, string date)
		{
			return GetShortNamePymtSupl(commonData, suplCombinationCode, compCodeLength, date, false);
		}

		/// <summary>
		/// 支払先略名を取得します。
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
		/// <param name="allSupl">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 支払先略名
		/// </returns>
		public static string GetShortNamePymtSupl(CommonData commonData, string suplCombinationCode, byte compCodeLength, string date, bool allSupl)
		{
			return GetShortName(commonData, suplCombinationCode, compCodeLength, date, allSupl, "P");
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
			return IsExists(commonData, suplCode, suplSbno, date, false, string.Empty);
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
		/// 仕入先種別
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
		/// 仕入先種別
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl, string suplType, string overSeasType)
		{
			return IsExists(commonData, suplCode, suplSbno, date, allSupl, suplType, string.Empty, false);
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
		/// 仕入先種別
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg)
		{
			return IsExists(commonData, suplCode, suplSbno, date, allSupl, suplType, string.Empty, false, false);
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
		/// 仕入先種別
		/// </param>
		/// <param name="overSeasType">
		/// 国内・海外区分
		/// </param>
		/// <param name="fabConsignSuplFlg">
		/// 製造委託先フラグ（製造委託先の場合：true、それ以外の場合：false）
		/// </param>
		/// <param name="ecFlg">
		/// ECフラグ
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl, string suplType, string overSeasType, bool fabConsignSuplFlg, bool ecFlg)
		{
			string keyCurCode = GetKeyCurCode(commonData);

			if (string.Equals(suplCode, string.Empty) || string.Equals(suplSbno, string.Empty))
			{
				return false;
			}

			if (date != string.Empty)
			{
				DateTime dateTime;
				try
				{
					dateTime = Convert.ToDateTime(date);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT [SUPL_CODE] FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));
			sb.Append(" AS [SU] ");

			if (string.Equals(suplType, "P"))
			{   // 支払先取得
				sb.Append(" INNER JOIN (SELECT DISTINCT [PYMT_SUPL_CODE], [PYMT_SUPL_SBNO] FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));
				if (date != string.Empty)
				{
					sb.Append(" WHERE @Date BETWEEN [USE_STT_DATE] AND [USE_END_DATE]");
				}
				if (!allSupl)
				{
					sb.Append(date != string.Empty ? " AND" : " WHERE");
					sb.Append(" [VALID_FLG] = '1'");
				}
				sb.Append(" ) AS [PYMT]");
				sb.Append("  ON [SU].[SUPL_CODE] = [PYMT].[PYMT_SUPL_CODE] ");
				sb.Append(" AND [SU].[SUPL_SBNO] = [PYMT].[PYMT_SUPL_SBNO] ");
			}

			sb.Append(" WHERE [SUPL_CODE] = @SuplCode");
			sb.Append("   AND [SUPL_SBNO] = @SuplSbno");
			if (date != string.Empty)
			{
				sb.Append("   AND @Date BETWEEN [USE_STT_DATE] AND [USE_END_DATE]");
			}
			if (!allSupl)
			{
				sb.Append("   AND [VALID_FLG] = '1'");
			}
			if (overSeasType.Length != 0)
			{
				if (string.Equals(overSeasType, "D"))
				{
					sb.Append("   AND [OVERSEAS_FLG] = '0' ");
				}
				else if (string.Equals(overSeasType, "O"))
				{
					sb.Append("   AND [OVERSEAS_FLG] = '1' ");
				}
				else if (string.Equals(overSeasType, "B"))
				{
					sb.Append("   AND ([OVERSEAS_FLG] = '1' ");
					sb.Append("   OR [DEAL_CUR_CODE] <> @KeyCurCode");
					sb.Append(")");
				}
			}
			if (fabConsignSuplFlg)
			{
				sb.Append("   AND [FAB_CONSIGN_SUPL_FLG] = '1' ");
			}
			if (string.Equals(suplType, "S"))
			{   // 仕入先取得
				sb.Append("  AND [SU].[SUPL_FLG] = '1' ");
			}
// 管理番号B11196 From
			if (ecFlg)
			{
				sb.Append("   AND [EC_USE_FLG] = '1' ");
			}
// 管理番号B11196 To

//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
//			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To

// 管理番号K27011 From
//			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, 8).Value = ConvertDBData.ToNVarChar(suplCode);
//			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, 2).Value = ConvertDBData.ToNVarChar(suplSbno);
			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, TypeLength.CompCode).Value = ConvertDBData.ToNVarChar(suplCode);
			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, TypeLength.CompSbno).Value = ConvertDBData.ToNVarChar(suplSbno);
// 管理番号K27011 To

			if (overSeasType.Length != 0)
			{
				if (string.Equals(overSeasType, "B"))
				{
					cm.Parameters.Add("@KeyCurCode", SqlDbType.NVarChar, 3).Value = ConvertDBData.ToNVarChar(keyCurCode);
				}
			}

			if (date != string.Empty)
			{
				cm.Parameters.Add("@Date", SqlDbType.DateTime).Value = ConvertDBData.ToDateTime(date); //TODO 日付部分のみ
			}

			bool result = false;
			cn.Open();
			SqlDataReader dr = cm.ExecuteReader();
			try
			{
				if (dr.HasRows)
				{
					result = true;
				}
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
			finally
			{
				dr.Close();
				cn.Close();
			}
			return result;
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
			return IsExists(commonData, suplCode, suplSbno, date, allSupl ,"S");
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
		/// <param name="ecFlg">
		/// ECフラグ（EC仕入先の場合：true、それ以外の場合：false）
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExistsSupl(CommonData commonData, string suplCode, string suplSbno, string date, bool allSupl, bool ecFlg)
		{
			return IsExists(commonData, suplCode, suplSbno, date, allSupl ,"S", string.Empty, false, ecFlg);
		}

		/// <summary>
		/// 支払先の存在チェックを行います。
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
		/// 支払先の存在チェックを行います。
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
		/// 支払先の存在チェックを行います。
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
		/// 支払先の存在チェックを行います。
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
			return IsExists(commonData, suplCode, suplSbno, date, allSupl ,"P");
		}


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
		public static DataTable GetDtData(CommonData commonData, String suplCode , String suplSbno)
		{
			StringBuilder sb = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append("SELECT");
			sb.Append(" [SDT].[DT_TYPE], [SDT].[AC_NO]");
			sb.Append(",[SDT].[AC_HOLDER], [SDT].[AC_TYPE], [SDT].[BANK_AC_TYPE], [SDT].[BANK_COUNTRY_CODE]");
			sb.Append(",[SDT].[BANK_CODE], [SDT].[BANK_BRANCH_CODE], [SDT].[DT1_STTL_MTHD_CODE]");
			sb.Append(",[SDT].[DT1_BASIS_AMT], [SDT].[DT2_STTL_MTHD_CODE], [SDT].[DT2_RATIO]");
			sb.Append(",[SDT].[DT3_STTL_MTHD_CODE], [SDT].[DT_SIGHT], [SDT].[DT_CUTOFF_CYCLE_TYPE]");
			sb.Append(",[SDT].[DT_NOTE]");
			sb.Append(",[S].[SUPL_NAME], [S].[TEMP_CODE_FLG], [S].[SUPL_SHORT_NAME], [S].[SUPL_COUNTRY_CODE]");
			sb.Append(",[S].[PU_CTAX_TYPE_CODE], [S].[PU_RETURN_CTAX_TYPE_CODE]");
// 管理番号 K24789 From
//			sb.Append(",[S].[CTAX_FRACTION_ROUND_TYPE], [S].[CTAX_BUILDUP_TYPE], [S].[DEAL_CUR_CODE]");
			sb.Append(",[S].[CTAX_IMPOSE_FLG]");
			sb.Append(",[SDT].[CTAX_FRACTION_ROUND_TYPE]");
			sb.Append(",[SDT].[CTAX_BUILDUP_TYPE]");
			sb.Append(",[S].[DEAL_CUR_CODE]");
// 管理番号 K24789 To
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]")).Append(" AS [S]");
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]")).Append(" AS [SDT]");
			sb.Append(" ON [S].[PYMT_SUPL_CODE] = [SDT].[SUPL_CODE]");
			sb.Append(" AND [S].[PYMT_SUPL_SBNO] = [SDT].[SUPL_SBNO]");
			sb.Append(" WHERE [S].[SUPL_CODE] = @SuplCode");
			sb.Append(" AND [S].[SUPL_SBNO] = @SuplSbno");
			
//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
//			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
// 管理番号K27011 From
//			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, 8).Value = suplCode;
//			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, 2).Value = suplSbno;
			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, TypeLength.CompCode).Value = suplCode;
			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, TypeLength.CompSbno).Value = suplSbno;
// 管理番号K27011 To

			DataTable dt = new DataTable();
			cn.Open();
			SqlDataReader dr =  cm.ExecuteReader();
			try
			{
				dt.Columns.Add("SUPL_NAME", typeof(string));
				dt.Columns.Add("SUPL_SHORT_NAME", typeof(string));
				dt.Columns.Add("SUPL_COUNTRY_CODE", typeof(string));
				dt.Columns.Add("DT_TYPE", typeof(string));

				dt.Columns.Add("AC_NO", typeof(string));
				dt.Columns.Add("AC_HOLDER", typeof(string));
				dt.Columns.Add("AC_TYPE", typeof(string));
				dt.Columns.Add("BANK_AC_TYPE", typeof(string));
				dt.Columns.Add("BANK_COUNTRY_CODE", typeof(string));
				dt.Columns.Add("BANK_CODE", typeof(string));
				dt.Columns.Add("BANK_BRANCH_CODE", typeof(string));
				
				dt.Columns.Add("DT1_STTL_MTHD_CODE", typeof(string));
				dt.Columns.Add("DT1_BASIS_AMT", typeof(string));
				dt.Columns.Add("DT2_STTL_MTHD_CODE", typeof(string));
				dt.Columns.Add("DT2_RATIO", typeof(string));
				dt.Columns.Add("DT3_STTL_MTHD_CODE", typeof(string));
				dt.Columns.Add("DT_SIGHT", typeof(string));
				dt.Columns.Add("DT_CUTOFF_CYCLE_TYPE", typeof(string));
				dt.Columns.Add("DT_NOTE", typeof(string));
				dt.Columns.Add("TEMP_CODE_FLG", typeof(string));
				dt.Columns.Add("PU_CTAX_TYPE_CODE", typeof(string));
				dt.Columns.Add("PU_RETURN_CTAX_TYPE_CODE", typeof(string));
// 管理番号 K24789 From
				dt.Columns.Add("CTAX_IMPOSE_FLG", typeof(string));
// 管理番号 K24789 To
				dt.Columns.Add("CTAX_FRACTION_ROUND_TYPE", typeof(string));
				dt.Columns.Add("CTAX_BUILDUP_TYPE", typeof(string));
				dt.Columns.Add("DEAL_CUR_CODE", typeof(string));
				while (dr.Read())
				{
					DataRow row = dt.NewRow();
					row["SUPL_NAME"]				= dr["SUPL_NAME"].ToString();
					row["SUPL_SHORT_NAME"]			= dr["SUPL_SHORT_NAME"].ToString();
					row["SUPL_COUNTRY_CODE"]		= dr["SUPL_COUNTRY_CODE"].ToString();
					row["DT_TYPE"] 					= dr["DT_TYPE"].ToString();

					row["AC_NO"] 					= dr["AC_NO"].ToString();
					row["AC_HOLDER"] 				= dr["AC_HOLDER"].ToString();
					row["AC_TYPE"] 					= dr["AC_TYPE"].ToString();
					row["BANK_AC_TYPE"] 			= dr["BANK_AC_TYPE"].ToString();
					row["BANK_COUNTRY_CODE"] 		= dr["BANK_COUNTRY_CODE"].ToString();
					row["BANK_CODE"] 				= dr["BANK_CODE"].ToString();
					row["BANK_BRANCH_CODE"] 		= dr["BANK_BRANCH_CODE"].ToString();
					
					row["DT1_STTL_MTHD_CODE"] 		= dr["DT1_STTL_MTHD_CODE"].ToString();
					row["DT1_BASIS_AMT"]			= dr["DT1_BASIS_AMT"].ToString();
					row["DT2_STTL_MTHD_CODE"] 		= dr["DT2_STTL_MTHD_CODE"].ToString();
					row["DT2_RATIO"] 				= dr["DT2_RATIO"].ToString();
					row["DT3_STTL_MTHD_CODE"] 		= dr["DT3_STTL_MTHD_CODE"].ToString();
					row["DT_SIGHT"] 				= dr["DT_SIGHT"].ToString();
					row["DT_CUTOFF_CYCLE_TYPE"] 	= dr["DT_CUTOFF_CYCLE_TYPE"].ToString();
					row["DT_NOTE"]					= dr["DT_NOTE"].ToString();
					row["TEMP_CODE_FLG"] 			= dr["TEMP_CODE_FLG"].ToString();
					row["PU_CTAX_TYPE_CODE"] 		= dr["PU_CTAX_TYPE_CODE"].ToString();
					row["PU_RETURN_CTAX_TYPE_CODE"] = dr["PU_RETURN_CTAX_TYPE_CODE"].ToString();
// 管理番号 K24789 From
					row["CTAX_IMPOSE_FLG"]			= dr["CTAX_IMPOSE_FLG"].ToString();
// 管理番号 K24789 To
					row["CTAX_FRACTION_ROUND_TYPE"] = dr["CTAX_FRACTION_ROUND_TYPE"].ToString();
					row["CTAX_BUILDUP_TYPE"]		= dr["CTAX_BUILDUP_TYPE"].ToString();
					row["DEAL_CUR_CODE"]	    	= dr["DEAL_CUR_CODE"].ToString();
					dt.Rows.Add(row);
				}
				dt.AcceptChanges();
			}
			finally
			{
				dr.Close();
				cn.Close();
			}
			return dt;
		}

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
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <returns>
		/// 取引条件
		/// </returns>
		public static DataTable GetDtData(CommonData commonData, String suplCode , String suplSbno, String date)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "CM_MS_GetBillPymtCutOff"));

//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			cn.Open();

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
//			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
			cm.CommandType = CommandType.StoredProcedure;

			cm.Parameters.Add("@TRAN_TYPE", SqlDbType.NVarChar, 1).Value = "2";

// 管理番号K27011 From
//			cm.Parameters.Add("@CODE", SqlDbType.NVarChar, 10).Value = ConvertDBData.ToNVarChar(suplCode);
//			cm.Parameters.Add("@SBNO", SqlDbType.NVarChar, 3).Value = ConvertDBData.ToNVarChar(suplSbno);
			cm.Parameters.Add("@CODE", SqlDbType.NVarChar, TypeLength.CompCode).Value = ConvertDBData.ToNVarChar(suplCode);
			cm.Parameters.Add("@SBNO", SqlDbType.NVarChar, TypeLength.CompSbno).Value = ConvertDBData.ToNVarChar(suplSbno);
// 管理番号K27011 To
			cm.Parameters.Add("@DATE", SqlDbType.NVarChar, 10).Value = ConvertDBData.ToNVarChar(date);

			//アウトパラメーター
// 管理番号K27011 From
//			cm.Parameters.Add("@NAME", SqlDbType.NVarChar, 50);
			cm.Parameters.Add("@NAME", SqlDbType.NVarChar, TypeLength.CompName);
// 管理番号K27011 To
			cm.Parameters["@NAME"].Direction								= ParameterDirection.Output;
// 管理番号K27011 From
//			cm.Parameters.Add("@SHORT_NAME", SqlDbType.NVarChar, 10);
			cm.Parameters.Add("@SHORT_NAME", SqlDbType.NVarChar, TypeLength.CompShortName);
// 管理番号K27011 To
			cm.Parameters["@SHORT_NAME"].Direction						= ParameterDirection.Output;

			cm.Parameters.Add("@DEPT_NAME_1", SqlDbType.NVarChar, 25);
			cm.Parameters["@DEPT_NAME_1"].Direction					= ParameterDirection.Output;
			cm.Parameters.Add("@DEPT_NAME_2", SqlDbType.NVarChar, 25);
			cm.Parameters["@DEPT_NAME_2"].Direction					= ParameterDirection.Output;
			cm.Parameters.Add("@USER_NAME", SqlDbType.NVarChar, 10);
			cm.Parameters["@USER_NAME"].Direction						= ParameterDirection.Output;

			cm.Parameters.Add("@AC_NO", SqlDbType.NVarChar, 20);
			cm.Parameters["@AC_NO"].Direction								= ParameterDirection.Output;
			cm.Parameters.Add("@AC_HOLDER", SqlDbType.NVarChar, 50);
			cm.Parameters["@AC_HOLDER"].Direction						= ParameterDirection.Output;
			cm.Parameters.Add("@AC_TYPE", SqlDbType.NVarChar, 1);
			cm.Parameters["@AC_TYPE"].Direction							= ParameterDirection.Output;
			cm.Parameters.Add("@BANK_AC_TYPE", SqlDbType.NVarChar, 1);
			cm.Parameters["@BANK_AC_TYPE"].Direction					= ParameterDirection.Output;
			cm.Parameters.Add("@BANK_COUNTRY_CODE", SqlDbType.NVarChar, 3);
			cm.Parameters["@BANK_COUNTRY_CODE"].Direction		= ParameterDirection.Output;
			cm.Parameters.Add("@BANK_CODE", SqlDbType.NVarChar, 20);
			cm.Parameters["@BANK_CODE"].Direction						= ParameterDirection.Output;
			cm.Parameters.Add("@BANK_BRANCH_CODE", SqlDbType.NVarChar, 20);
			cm.Parameters["@BANK_BRANCH_CODE"].Direction			= ParameterDirection.Output;

			cm.Parameters.Add("@DT_TYPE1", SqlDbType.NVarChar, 1);
			cm.Parameters["@DT_TYPE1"].Direction							= ParameterDirection.Output;
			cm.Parameters.Add("@DT_TYPE2", SqlDbType.NVarChar, 1);
			cm.Parameters["@DT_TYPE2"].Direction							= ParameterDirection.Output;
			cm.Parameters.Add("@DT1_STTL_MTHD_CODE", SqlDbType.NVarChar, 3);
			cm.Parameters["@DT1_STTL_MTHD_CODE"].Direction		= ParameterDirection.Output;
			cm.Parameters.Add("@DT1_BASIS_AMT", SqlDbType.Decimal);
			cm.Parameters["@DT1_BASIS_AMT"].Direction					= ParameterDirection.Output;
			cm.Parameters.Add("@DT2_STTL_MTHD_CODE", SqlDbType.NVarChar, 3);
			cm.Parameters["@DT2_STTL_MTHD_CODE"].Direction		= ParameterDirection.Output;
			cm.Parameters.Add("@DT2_RATIO", SqlDbType.Decimal);
			cm.Parameters["@DT2_RATIO"].Direction							= ParameterDirection.Output;
			cm.Parameters.Add("@DT3_STTL_MTHD_CODE", SqlDbType.NVarChar, 3);
			cm.Parameters["@DT3_STTL_MTHD_CODE"].Direction		= ParameterDirection.Output;
			cm.Parameters.Add("@DT_SIGHT", SqlDbType.Decimal);
			cm.Parameters["@DT_SIGHT"].Direction							= ParameterDirection.Output;
			cm.Parameters.Add("@DT_CUTOFF_CYCLE_TYPE", SqlDbType.NVarChar, 1);
			cm.Parameters["@DT_CUTOFF_CYCLE_TYPE"].Direction	= ParameterDirection.Output;
			cm.Parameters.Add("@DT_NOTE", SqlDbType.NVarChar, 50);
			cm.Parameters["@DT_NOTE"].Direction							= ParameterDirection.Output;
			cm.Parameters.Add("@TEMP_CODE_FLG", SqlDbType.NVarChar, 1);
			cm.Parameters["@TEMP_CODE_FLG"].Direction				= ParameterDirection.Output;
			cm.Parameters.Add("@CTAX_IMPOSE_FLG", SqlDbType.NVarChar, 1);
			cm.Parameters["@CTAX_IMPOSE_FLG"].Direction				= ParameterDirection.Output;
			cm.Parameters.Add("@CTAX_TYPE_CODE", SqlDbType.NVarChar, 1);
			cm.Parameters["@CTAX_TYPE_CODE"].Direction				= ParameterDirection.Output;
			cm.Parameters.Add("@RETURN_CTAX_TYPE_CODE", SqlDbType.NVarChar, 1);
			cm.Parameters["@RETURN_CTAX_TYPE_CODE"].Direction	= ParameterDirection.Output;
			cm.Parameters.Add("@CTAX_FRACTION_ROUND_TYPE", SqlDbType.NVarChar, 1);
			cm.Parameters["@CTAX_FRACTION_ROUND_TYPE"].Direction	= ParameterDirection.Output;
			cm.Parameters.Add("@CTAX_BUILDUP_TYPE", SqlDbType.NVarChar, 1);
			cm.Parameters["@CTAX_BUILDUP_TYPE"].Direction			= ParameterDirection.Output;
			cm.Parameters.Add("@DT_CUTOFF_DAY", SqlDbType.NVarChar, 2);
			cm.Parameters["@DT_CUTOFF_DAY"].Direction				= ParameterDirection.Output;
			cm.Parameters.Add("@DT_TERM_MONTH_CNT", SqlDbType.Decimal);
			cm.Parameters["@DT_TERM_MONTH_CNT"].Direction		= ParameterDirection.Output;
			cm.Parameters.Add("@DT_TERM_DAY", SqlDbType.NVarChar, 2);
			cm.Parameters["@DT_TERM_DAY"].Direction					= ParameterDirection.Output;

			cm.Parameters.Add("@RET", SqlDbType.Decimal);
			cm.Parameters["@RET"].Direction		= ParameterDirection.Output;
			cm.Parameters.Add("@RESULT_INFORMATION", SqlDbType.NVarChar, 100);
			cm.Parameters["@RESULT_INFORMATION"].Direction		= ParameterDirection.Output;

			cm.Parameters.Add("RETURN_VALUE", SqlDbType.Int);
			cm.Parameters["RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;


			DataTable dt = new DataTable();
			try
			{
				cm.ExecuteNonQuery();
				dt.Columns.Add("SUPL_NAME", typeof(string));
				dt.Columns.Add("SUPL_SHORT_NAME", typeof(string));

				dt.Columns.Add("DEPT_NAME_1", typeof(string));
				dt.Columns.Add("DEPT_NAME_2", typeof(string));
				dt.Columns.Add("USER_NAME", typeof(string));

				dt.Columns.Add("AC_NO", typeof(string));
				dt.Columns.Add("AC_HOLDER", typeof(string));
				dt.Columns.Add("AC_TYPE", typeof(string));
				dt.Columns.Add("BANK_AC_TYPE", typeof(string));
				dt.Columns.Add("BANK_COUNTRY_CODE", typeof(string));
				dt.Columns.Add("BANK_CODE", typeof(string));
				dt.Columns.Add("BANK_BRANCH_CODE", typeof(string));

				dt.Columns.Add("DT_TYPE", typeof(string));
				dt.Columns.Add("DT1_STTL_MTHD_CODE", typeof(string));
				dt.Columns.Add("DT1_BASIS_AMT", typeof(string));
				dt.Columns.Add("DT2_STTL_MTHD_CODE", typeof(string));
				dt.Columns.Add("DT2_RATIO", typeof(string));
				dt.Columns.Add("DT3_STTL_MTHD_CODE", typeof(string));
				dt.Columns.Add("DT_SIGHT", typeof(string));
				dt.Columns.Add("DT_CUTOFF_CYCLE_TYPE", typeof(string));
				dt.Columns.Add("DT_NOTE", typeof(string));
				dt.Columns.Add("TEMP_CODE_FLG", typeof(string));
				dt.Columns.Add("PU_CTAX_TYPE_CODE", typeof(string));
				dt.Columns.Add("PU_RETURN_CTAX_TYPE_CODE", typeof(string));
				dt.Columns.Add("CTAX_FRACTION_ROUND_TYPE", typeof(string));
				dt.Columns.Add("CTAX_BUILDUP_TYPE", typeof(string));
				dt.Columns.Add("DT_CUTOFF_DAY", typeof(string));
				dt.Columns.Add("DT_TERM_MONTH_CNT", typeof(string));
				dt.Columns.Add("DT_TERM_DAY", typeof(string));
// 管理番号 K24789 From
				dt.Columns.Add("CTAX_IMPOSE_FLG", typeof(string));
// 管理番号 K24789 To

				DataRow row = dt.NewRow();
				row["SUPL_NAME"]								= cm.Parameters["@NAME"].Value.ToString();
				row["SUPL_SHORT_NAME"]					= cm.Parameters["@SHORT_NAME"].Value.ToString();

				row["DEPT_NAME_1"]							= cm.Parameters["@DEPT_NAME_1"].Value.ToString();
				row["DEPT_NAME_2"]							= cm.Parameters["@DEPT_NAME_2"].Value.ToString();
				row["USER_NAME"]								= cm.Parameters["@USER_NAME"].Value.ToString();

				row["AC_NO"] 									= cm.Parameters["@AC_NO"].Value.ToString();
				row["AC_HOLDER"] 								= cm.Parameters["@AC_HOLDER"].Value.ToString();
				row["AC_TYPE"] 									= cm.Parameters["@AC_TYPE"].Value.ToString();
				row["BANK_AC_TYPE"] 						= cm.Parameters["@BANK_AC_TYPE"].Value.ToString();
				row["BANK_COUNTRY_CODE"]				= cm.Parameters["@BANK_COUNTRY_CODE"].Value.ToString();
				row["BANK_CODE"] 							= cm.Parameters["@BANK_CODE"].Value.ToString();
				row["BANK_BRANCH_CODE"] 				= cm.Parameters["@BANK_BRANCH_CODE"].Value.ToString();

				row["DT_TYPE"] 									= cm.Parameters["@DT_TYPE1"].Value.ToString();
				row["DT1_STTL_MTHD_CODE"] 				= cm.Parameters["@DT1_STTL_MTHD_CODE"].Value.ToString();
				row["DT1_BASIS_AMT"]						= cm.Parameters["@DT1_BASIS_AMT"].Value.ToString();
				row["DT2_STTL_MTHD_CODE"] 				= cm.Parameters["@DT2_STTL_MTHD_CODE"].Value.ToString();
				row["DT2_RATIO"] 								= cm.Parameters["@DT2_RATIO"].Value.ToString();
				row["DT3_STTL_MTHD_CODE"] 				= cm.Parameters["@DT3_STTL_MTHD_CODE"].Value.ToString();
				row["DT_SIGHT"] 								= cm.Parameters["@DT_SIGHT"].Value.ToString();
				row["DT_CUTOFF_CYCLE_TYPE"]			= cm.Parameters["@DT_CUTOFF_CYCLE_TYPE"].Value.ToString();
				row["DT_NOTE"]									= cm.Parameters["@DT_NOTE"].Value.ToString();
				row["TEMP_CODE_FLG"] 						= cm.Parameters["@TEMP_CODE_FLG"].Value.ToString();
				row["PU_CTAX_TYPE_CODE"] 				= cm.Parameters["@CTAX_TYPE_CODE"].Value.ToString();
				row["PU_RETURN_CTAX_TYPE_CODE"]	= cm.Parameters["@RETURN_CTAX_TYPE_CODE"].Value.ToString();
				row["CTAX_FRACTION_ROUND_TYPE"]	= cm.Parameters["@CTAX_FRACTION_ROUND_TYPE"].Value.ToString();
				row["CTAX_BUILDUP_TYPE"]				= cm.Parameters["@CTAX_BUILDUP_TYPE"].Value.ToString();
				row["DT_CUTOFF_DAY"]						= cm.Parameters["@DT_CUTOFF_DAY"].Value.ToString();
				row["DT_TERM_MONTH_CNT"]				= cm.Parameters["@DT_TERM_MONTH_CNT"].Value.ToString();
				row["DT_TERM_DAY"]							= cm.Parameters["@DT_TERM_DAY"].Value.ToString();
// 管理番号 K24789 From
				row["CTAX_IMPOSE_FLG"]					= cm.Parameters["@CTAX_IMPOSE_FLG"].Value.ToString();
// 管理番号 K24789 To

				dt.Rows.Add(row);

				dt.AcceptChanges();
			}
			finally
			{
				cn.Close();
			}
			return dt;
		}

// 管理番号 K24789 コメント削除
// 管理番号 P18435 コメント削除
// 管理番号 K24278 コメント削除

		/// <summary>
		/// 指定された仕入先が存在する場合、消費税情報を取得します。
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
		/// <param name="ctaxBuildupType_b">
		/// 消費税積上区分
		/// </param>
		/// <param name="roundType_b">
		/// 丸め区分
		/// </param>
		/// <param name="imposeFlg_b">
		/// 消費税課税フラグ
		/// </param>
		/// <returns>
		/// データが存在するかどうか。
		/// </returns>
		public static bool GetCtaxInfo(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string ctaxBuildupType_b, out string roundType_b, out string imposeFlg_b)
		{
			bool result = false;
			ctaxBuildupType_b = string.Empty;
			roundType_b = string.Empty;
			imposeFlg_b = string.Empty;

			String[] words = suplCombinationCode.Split(new char[] { '-' }, 3);
			string code = string.Empty;
			string sbno = string.Empty;
			switch (words.Length)
			{
				case 1:
// 管理番号K27011 From
//					if (words[0].Length != compCodeLength + 2)
					if (words[0].Length != compCodeLength + TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
					{
						return false;
					}
					code = words[0].Substring(0, compCodeLength);
// 管理番号K27011 From
//					sbno = words[0].Substring(compCodeLength, 2);
					sbno = words[0].Substring(compCodeLength, TypeLength.CompSbnoInputDigit);
// 管理番号K27011 To
					break;
				case 2:
// 管理番号K27011 From
//					if (words[0].Length > compCodeLength || words[1].Length != 2)
					if (words[0].Length > compCodeLength || words[1].Length != TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
					{
						return false;
					}
					code = words[0];
					sbno = words[1];
					break;
				default:
					return false;
			}
			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append(" [S].[CTAX_IMPOSE_FLG] ");
			sb.Append(",[SDT].[CTAX_BUILDUP_TYPE] ");
			sb.Append(",[SDT].[CTAX_FRACTION_ROUND_TYPE] ");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));
			sb.Append(" AS [S] ");
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));
			sb.Append(" AS [SDT] ");
			sb.Append(" ON  [S].[PYMT_SUPL_CODE] = [SDT].[SUPL_CODE] ");
			sb.Append(" AND [S].[PYMT_SUPL_SBNO] = [SDT].[SUPL_SBNO] ");
			sb.Append(" WHERE [S].[SUPL_CODE] = @SuplCode");
			sb.Append("   AND [S].[SUPL_SBNO] = @SuplSbno");

			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し


// 管理番号K27011 From
//			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, 8).Value = ConvertDBData.ToNVarChar(code);
//			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, 2).Value = ConvertDBData.ToNVarChar(sbno);
			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, TypeLength.CompCode).Value = ConvertDBData.ToNVarChar(code);
			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, TypeLength.CompSbno).Value = ConvertDBData.ToNVarChar(sbno);
// 管理番号K27011 To

			cn.Open();
			SqlDataReader dr = cm.ExecuteReader();
			try
			{
				if (dr.Read())
				{
					imposeFlg_b			= dr["CTAX_IMPOSE_FLG"].ToString();
					ctaxBuildupType_b	= dr["CTAX_BUILDUP_TYPE"].ToString();
					roundType_b			= dr["CTAX_FRACTION_ROUND_TYPE"].ToString();
					result = true;
				}
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
			finally
			{
				dr.Close();
				cn.Close();
			}
			return result;
		}
// 管理番号 K24789 To

		private static string GetKeyCurCode(CommonData commonData)
		{
			string keyCurCode = string.Empty;

			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT");
			sb.Append(" [KEY_CUR_CODE]");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[MYCOMP]"));

			WherePhraseBuilder wpb = new WherePhraseBuilder();
			wpb.AddFilter("[MYCOMP_CODE]", IF.SearchOperator.Equal, commonData.CompCode);
			sb.Append(wpb);

//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
//			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To

			cn.Open();
			SqlDataReader dr = cm.ExecuteReader();
			try
			{
				if (dr.Read())
					keyCurCode = dr["KEY_CUR_CODE"].ToString();
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
			finally
			{
				dr.Close();
				cn.Close();
			}
			return keyCurCode;
		}

		/// <summary>
		/// 仕入先の取引通貨コード取得します。
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
		/// 取引通貨コード
		/// </returns>
		public static string GetDealCurCode(CommonData commonData, string suplCode, string suplSbno)
		{
			string dealCurCode = string.Empty;

			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT");
			sb.Append(" [DEAL_CUR_CODE]");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));

			WherePhraseBuilder wpb = new WherePhraseBuilder();
			wpb.AddFilter("[SUPL_CODE]", IF.SearchOperator.Equal, suplCode);
			wpb.AddFilter("[SUPL_SBNO]", IF.SearchOperator.Equal, suplSbno);
			sb.Append(wpb);

//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
//			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To

			cn.Open();
			SqlDataReader dr = cm.ExecuteReader();
			try
			{
				if (dr.Read())
					dealCurCode = dr["DEAL_CUR_CODE"].ToString();
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
			finally
			{
				dr.Close();
				cn.Close();
			}
			return dealCurCode;
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

			String[] words = suplCombinationCode.Split(new char[]{'-'}, 3);
			string code = string.Empty;
			string sbno = string.Empty;
			switch (words.Length)
			{
				case 1:
// 管理番号K27011 From
//					if (words[0].Length != compCodeLength + 2)
					if (words[0].Length != compCodeLength + TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
					{
						return false;
					}
					code = words[0].Substring(0, compCodeLength);
// 管理番号K27011 From
//					sbno = words[0].Substring(compCodeLength, 2);
					sbno = words[0].Substring(compCodeLength, TypeLength.CompSbnoInputDigit);
// 管理番号K27011 To
					break;
				case 2:
// 管理番号K27011 From
//					if (words[0].Length > compCodeLength || words[1].Length != 2)
					if (words[0].Length > compCodeLength || words[1].Length != TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
					{
						return false;
					}
					code = words[0];
					sbno = words[1];
					break;
				default:
					return false;
			}

			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT [TEMP_CODE_FLG]");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));

			sb.Append(" WHERE [SUPL_CODE] = @SuplCode");
			sb.Append("   AND [SUPL_SBNO] = @SuplSbno");

//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
//			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To

// 管理番号K27011 From
//			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, 8).Value = ConvertDBData.ToNVarChar(code);
//			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, 2).Value = ConvertDBData.ToNVarChar(sbno);
			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, TypeLength.CompCode).Value = ConvertDBData.ToNVarChar(code);
			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, TypeLength.CompSbno).Value = ConvertDBData.ToNVarChar(sbno);
// 管理番号K27011 To

			bool result = false;
			cn.Open();
			SqlDataReader dr = cm.ExecuteReader();
			try
			{
				if (dr.Read())
				{
					tempCodeFlg = string.Equals(dr["TEMP_CODE_FLG"].ToString(), "1") ? true : false;
					result = true;
				}
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
			finally
			{
				dr.Close();
				cn.Close();
			}
			return result;
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
		/// <param name="pymtsuplCombinationCode_b">
		/// 支払先コードと支払先枝番の連結した文字列
		/// </param>
		/// <param name="pymtsuplShortName_b">
		/// 支払先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <returns>
		/// データが存在するかどうか。
		/// </returns>
		public static bool GetPymtSupl(CommonData commonData, string suplCombinationCode, int compCodeLength, out string pymtsuplCombinationCode_b, out string pymtsuplShortName_b, string date)
		{
			return GetPymtSupl(commonData, suplCombinationCode, compCodeLength, out pymtsuplCombinationCode_b, out pymtsuplShortName_b, date, false);
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
		/// <param name="pymtsuplCombinationCode_b">
		/// 支払先コードと支払先枝番の連結した文字列
		/// </param>
		/// <param name="pymtsuplShortName_b">
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
		public static bool GetPymtSupl(CommonData commonData, string suplCombinationCode, int compCodeLength, out string pymtsuplCombinationCode_b, out string pymtsuplShortName_b, string date, bool allSupl)
		{
			pymtsuplCombinationCode_b = string.Empty;
			pymtsuplShortName_b = string.Empty;

			if (suplCombinationCode == string.Empty)
			{
				return false;
			}

			if (date != string.Empty)
			{
				DateTime dateTime;
				try
				{
					dateTime = Convert.ToDateTime(date);
				}
				catch (Exception ex)
				{
					throw ex;
				}
			}

			String[] words = suplCombinationCode.Split(new char[] { '-' }, 3);
			string code = string.Empty;
			string sbno = string.Empty;
			switch (words.Length)
			{
				case 1:
// 管理番号K27011 From
//					if (words[0].Length != compCodeLength + 2)
					if (words[0].Length != compCodeLength + TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
					{
						return false;
					}
					code = words[0].Substring(0, compCodeLength);
// 管理番号K27011 From
//					sbno = words[0].Substring(compCodeLength, 2);
					sbno = words[0].Substring(compCodeLength, TypeLength.CompSbnoInputDigit);
// 管理番号K27011 To
					break;
				case 2:
// 管理番号K27011 From
//					if (words[0].Length > compCodeLength || words[1].Length != 2)
					if (words[0].Length > compCodeLength || words[1].Length != TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
					{
						return false;
					}
					code = words[0];
					sbno = words[1];
					break;
				default:
					return false;
			}

			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT [A].[PYMT_SUPL_CODE]+'-'+[A].[PYMT_SUPL_SBNO] AS [PYMT_SUPL],");
			sb.Append(" CASE WHEN [B].[NEW_SUPL_NAME_CHANGE_DATE] > @Date ");
			sb.Append(" THEN [B].[SUPL_SHORT_NAME] ");
			sb.Append(" ELSE ISNULL([B].[NEW_SUPL_SHORT_NAME],[B]. [SUPL_SHORT_NAME]) ");
			sb.Append(" END AS  [PymtName] ");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));
			sb.Append(" AS [A]");
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));
			sb.Append(" AS [B] ON");
			sb.Append(" [A].PYMT_SUPL_CODE = [B].SUPL_CODE AND");
			sb.Append(" [A].PYMT_SUPL_SBNO = [B].SUPL_SBNO");

			sb.Append(" WHERE [A].[SUPL_CODE] = @SuplCode");
			sb.Append("   AND [A].[SUPL_SBNO] = @SuplSbno");
			if (date != string.Empty)
			{
				sb.Append("   AND @Date BETWEEN [B].[USE_STT_DATE] AND [B].[USE_END_DATE]");
			}
			if (!allSupl)
			{
				sb.Append("   AND [B].[VALID_FLG] = '1'");
			}

//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し

// 管理番号K27011 From
//			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, 8).Value = ConvertDBData.ToNVarChar(code);
//			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, 2).Value = ConvertDBData.ToNVarChar(sbno);
			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, TypeLength.CompCode).Value = ConvertDBData.ToNVarChar(code);
			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, TypeLength.CompSbno).Value = ConvertDBData.ToNVarChar(sbno);
// 管理番号K27011 To
			if (date != string.Empty)
			{
				cm.Parameters.Add("@Date", SqlDbType.DateTime).Value = ConvertDBData.ToDateTime(date);
			}

			bool result = false;
			cn.Open();
			SqlDataReader dr = cm.ExecuteReader();
			try
			{
				if (dr.Read())
				{
					pymtsuplCombinationCode_b = dr["PYMT_SUPL"].ToString();
					pymtsuplShortName_b = dr["PymtName"].ToString();
					result = true;
				}
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
			finally
			{
				dr.Close();
				cn.Close();
			}
			return result;
		}
// 管理番号K22198 To

// 管理番号K24392 From
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
		public static bool GetSightDueDate(CommonData commonData, string suplCode, string suplSbno, out string sightCalcType, out string dueHolidayAvoidanceType)
		{
			sightCalcType = string.Empty;
			dueHolidayAvoidanceType = string.Empty;
			bool result = false;

			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append(" [SIGHT_CALC_TYPE] AS [SIGHT_CALC_TYPE] ");
			sb.Append(" ,[DUE_HOLIDAY_AVOIDANCE_TYPE] AS [DUE_HOLIDAY_AVOIDANCE_TYPE] ");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));
			sb.Append(" WHERE [SUPL_CODE] = @SuplCode ");
			sb.Append(" AND [SUPL_SBNO] = @SuplSbno ");

//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230

			cn.Open();

// 管理番号K27011 From
//			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, 8).Value = ConvertDBData.ToNVarChar(suplCode);
//			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, 2).Value = ConvertDBData.ToNVarChar(suplSbno);
			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, TypeLength.CompCode).Value = ConvertDBData.ToNVarChar(suplCode);
			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, TypeLength.CompSbno).Value = ConvertDBData.ToNVarChar(suplSbno);
// 管理番号K27011 To

			SqlDataReader dr = cm.ExecuteReader();
			try
			{
				if (dr.Read())
				{
					sightCalcType = dr["SIGHT_CALC_TYPE"].ToString();
					dueHolidayAvoidanceType = dr["DUE_HOLIDAY_AVOIDANCE_TYPE"].ToString();
					result = true;
				}
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
			finally
			{
				dr.Close();
				cn.Close();
			}
			return result;
		}
// 管理番号K24392 To

// 管理番号 B24264 From
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
		public static DataTable GetAddress(CommonData commonData, string suplCode, string suplSbno)
		{
			StringBuilder sb = new StringBuilder();

			sb.Append(" SELECT ");
			sb.Append("     [SUPL_COUNTRY_CODE] ");
			sb.Append("    ,[SUPL_ZIP] ");
			sb.Append("    ,[SUPL_STATE] ");
			sb.Append("    ,[SUPL_CITY] ");
			sb.Append("    ,[SUPL_ADDRESS1] ");
			sb.Append("    ,[SUPL_ADDRESS2] ");
			sb.Append("    ,[SUPL_PHONE] ");
			sb.Append("    ,[SUPL_FAX] ");
			sb.Append("FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));
			sb.Append(" WHERE [SUPL_CODE] = @SuplCode ");
			sb.Append(" AND [SUPL_SBNO] = @SuplSbno ");

// 管理番号K27445 From
//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode));
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
// 管理番号K27445 To
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230

			cn.Open();

// 管理番号K27011 From
//			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, 8).Value = ConvertDBData.ToNVarChar(suplCode);
//			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, 2).Value = ConvertDBData.ToNVarChar(suplSbno);
			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, TypeLength.CompCode).Value = ConvertDBData.ToNVarChar(suplCode);
			cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, TypeLength.CompSbno).Value = ConvertDBData.ToNVarChar(suplSbno);
// 管理番号K27011 To

			DataTable dt = new DataTable();
			SqlDataAdapterWrapper da = new SqlDataAdapterWrapper(cm);	// 管理番号K27230
			DBTimeout.setTimeout(da, commonData); 		//タイムアウト値変更メソッド呼出し

			try
			{
				da.Fill(dt);
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
			finally
			{
				cn.Close();
			}

			return dt;
		}
// 管理番号 B24264 To

// 管理番号 K24789 From
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
		/// <param name="ctaxBuildupType_b">
		/// 消費税積上区分
		/// </param>
		/// <param name="roundType_b">
		/// 丸め区分
		/// </param>
		/// <returns>
		/// データが存在するかどうか。
		/// </returns>
		public static bool GetPymtCtaxInfo(CommonData commonData, string suplCombinationCode, byte compCodeLength, out string ctaxBuildupType_b, out string roundType_b)
		{
			bool result = false;
			ctaxBuildupType_b = string.Empty;
			roundType_b = string.Empty;

			String[] words = suplCombinationCode.Split(new char[] { '-' }, 3);
			string code = string.Empty;
			string sbno = string.Empty;
			switch (words.Length)
			{
				case 1:
// 管理番号K27011 From
//					if (words[0].Length != compCodeLength + 2)
					if (words[0].Length != compCodeLength + TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
					{
						return false;
					}
					code = words[0].Substring(0, compCodeLength);
// 管理番号K27011 From
//					sbno = words[0].Substring(compCodeLength, 2);
					sbno = words[0].Substring(compCodeLength, TypeLength.CompSbnoInputDigit);
// 管理番号K27011 To
					break;
				case 2:
// 管理番号K27011 From
//					if (words[0].Length > compCodeLength || words[1].Length != 2)
					if (words[0].Length > compCodeLength || words[1].Length != TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
					{
						return false;
					}
					code = words[0];
					sbno = words[1];
					break;
				default:
					return false;
			}
			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append(" [S].[CTAX_BUILDUP_TYPE] ");
			sb.Append(",[S].[CTAX_FRACTION_ROUND_TYPE] ");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));
			sb.Append(" AS [S] ");
			sb.Append(" WHERE [S].[SUPL_CODE] = @PymtSuplCode");
			sb.Append("   AND [S].[SUPL_SBNO] = @PymtSuplSbno");

			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230

// 管理番号K27011 From
//			cm.Parameters.Add("@PymtSuplCode", SqlDbType.NVarChar, 8).Value = ConvertDBData.ToNVarChar(code);
//			cm.Parameters.Add("@PymtSuplSbno", SqlDbType.NVarChar, 2).Value = ConvertDBData.ToNVarChar(sbno);
			cm.Parameters.Add("@PymtSuplCode", SqlDbType.NVarChar, TypeLength.CompCode).Value = ConvertDBData.ToNVarChar(code);
			cm.Parameters.Add("@PymtSuplSbno", SqlDbType.NVarChar, TypeLength.CompSbno).Value = ConvertDBData.ToNVarChar(sbno);
// 管理番号K27011 To

			cn.Open();
			SqlDataReader dr = cm.ExecuteReader();
			try
			{
				if (dr.Read())
				{
					ctaxBuildupType_b	= dr["CTAX_BUILDUP_TYPE"].ToString();
					roundType_b			= dr["CTAX_FRACTION_ROUND_TYPE"].ToString();
					result = true;
				}
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
			finally
			{
				dr.Close();
				cn.Close();
			}
			return result;
		}
// 管理番号 K24789 To
		#endregion
	}
}
