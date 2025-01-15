// Product     : Allegro
// Unit        : FI
// Module      : AP
// Function    : --
// File Name   : BL_FI_AP_Supl.cs
// 機能名      : 仕入先共通機能（債務）
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 1.1.1 2004/07/31
// 1.1.2 2004/08/31
// 管理番号B10079 2004/07/08 略名が新仕入先改定日をまたがる時、旧名称が表示される不具合修正
// 管理番号P18435 2006/12/22 パフォーマンス対応（2006年9月末分）：タイムアウト値延長
// 1.5.1 2007/06/30
// 管理番号K24278 2011/12/20 仕入先課税区分追加対応
// 2.0.0 2012/10/31
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 管理番号 K24789 2013/05/08 消費税率の段階的引き上げ対応
// 管理番号K25321 2014/03/19 電子債権対応
// 2.2.0 2014/10/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/21 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 3.0.0 2018/04/30
// 管理番号K27011 2018/12/27 項目桁数拡張：取引先・商品・勘定科目
// 3.1.0 2020/06/30
// 管理番号K27230 2021/07/20 脆弱性対応
// 3.2.0 2023/03/31

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Infocom.Allegro.BL.SqlClient;
using Infocom.Allegro.IF;

namespace Infocom.Allegro.FI.AP
{
	/// <summary>
	/// 仕入先（債務）に関する共通機能を提供します。
	/// </summary>
	public sealed class BL_FI_AP_Supl : MarshalByRefObject
	{
		#region Constructors
		private BL_FI_AP_Supl()
		{
		}
		#endregion

		#region Static Methods
		/// <summary>
		/// 仕入先と仕入先略名を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列。
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="pymtsuplCombinationCode_b">
		/// 支払先コードと支払先枝番の連結した文字列。
		/// </param>
		/// <param name="pymtsuplShortName_b">
		/// 支払先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool GetPymtSupl(CommonData commonData, string suplCombinationCode, int compCodeLength,out string pymtsuplCombinationCode_b,out string pymtsuplShortName_b,string date)
		{
			return GetPymtSupl(commonData, suplCombinationCode, compCodeLength, out pymtsuplCombinationCode_b, out pymtsuplShortName_b, date, false);
		}

		/// <summary>
		/// 仕入先と仕入先略名を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列。
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="pymtsuplCombinationCode_b">
		/// 支払先コードと支払先枝番の連結した文字列。
		/// </param>
		/// <param name="pymtsuplShortName_b">
		/// 支払先略名
		/// </param>
		/// <param name="date">
		/// 基準日
		/// </param>
		/// <param name="allSupl">
		/// 無効も含める場合：true。それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool GetPymtSupl(CommonData commonData, string suplCombinationCode, int compCodeLength,out string pymtsuplCombinationCode_b,out string pymtsuplShortName_b,string date, bool allSupl)
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

			String[] words = suplCombinationCode.Split(new char[]{'-'}, 3);
			string code = string.Empty;
			string sbno = string.Empty;
			switch (words.Length)
			{
				case 1:
// 管理番号K27011 From
//						if (words[0].Length != compCodeLength + 2)
						if (words[0].Length != compCodeLength + TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
						{
							return false;
						}
						code = words[0].Substring(0, compCodeLength);
// 管理番号K27011 From
//						sbno = words[0].Substring(compCodeLength, 2);
						sbno = words[0].Substring(compCodeLength, TypeLength.CompSbnoInputDigit);
// 管理番号K27011 To
						break;
				case 2:
// 管理番号K27011 From
//						if (words[0].Length > compCodeLength || words[1].Length != 2)
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
// 管理番号B10079 From
//			sb.Append("[B].[SUPL_SHORT_NAME] AS [PymtName]");
			sb.Append(" CASE WHEN [B].[NEW_SUPL_NAME_CHANGE_DATE] > @Date ");
			sb.Append(" THEN [B].[SUPL_SHORT_NAME] ");
			sb.Append(" ELSE ISNULL([B].[NEW_SUPL_SHORT_NAME],[B]. [SUPL_SHORT_NAME]) ");
			sb.Append(" END AS  [PymtName] ");
// 管理番号B10079 To
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
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To

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

		/// <summary>
		/// 雑コードフラグを取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列。
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="tempCodeFlg">
		/// 雑コードフラグ
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool GetTempCodeFlg(CommonData commonData, string suplCombinationCode, int compCodeLength, out bool tempCodeFlg)
		{
			tempCodeFlg = false;

			if (suplCombinationCode == string.Empty)
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
//						if (words[0].Length != compCodeLength + 2)
						if (words[0].Length != compCodeLength + TypeLength.CompSbnoInputDigit)
// 管理番号K27011 To
						{
							return false;
						}
						code = words[0].Substring(0, compCodeLength);
// 管理番号K27011 From
//						sbno = words[0].Substring(compCodeLength, 2);
						sbno = words[0].Substring(compCodeLength, TypeLength.CompSbnoInputDigit);
// 管理番号K27011 To
						break;
				case 2:
// 管理番号K27011 From
//						if (words[0].Length > compCodeLength || words[1].Length != 2)
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
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
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
					tempCodeFlg = (dr["TEMP_CODE_FLG"].ToString()=="1")? true:false;
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
		/// 仕入先情報を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列。
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <returns>
		/// 仕入先情報
		/// </returns>
		public static DataTable GetDtInfo(CommonData commonData, String suplCombinationCode, byte compCodeLength)
		{
			string[] words = suplCombinationCode.Split(new char[]{'-'}, 3);
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
						return null;
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
						return null;
					}
					code = words[0];
					sbno = words[1];
					break;
				default:
					return null;
			}

			StringBuilder sb = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append("SELECT");
			sb.Append(" [DT_TYPE], [DT1_STTL_MTHD_CODE], [DT1_BASIS_AMT]");
			sb.Append(",[DT2_STTL_MTHD_CODE], [DT2_RATIO], [DT3_STTL_MTHD_CODE]");
			sb.Append(",[DT_SIGHT], [DT_NOTE], [DT_CUTOFF_CYCLE_TYPE]");
			sb.Append(",[TEMP_CODE_FLG], [OVERSEAS_FLG], [DEAL_CUR_CODE]");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));

			wpb.AddFilter(" [SUPL_CODE]", SearchOperator.Equal, code);
			wpb.AddFilter(" [SUPL_SBNO]", SearchOperator.Equal, sbno);
			sb.Append(wpb);
			
//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To

			DataTable dt = new DataTable();
			cn.Open();
			SqlDataReader dr =  cm.ExecuteReader();
			try
			{
				if (dr.Read())
				{
					if (dr["OVERSEAS_FLG"].ToString() == "1")
					{
						string dtType			= dr["DT_TYPE"].ToString();
						string overseaseFlg 	= dr["OVERSEAS_FLG"].ToString();
						string tempCodeFlg 		= dr["TEMP_CODE_FLG"].ToString();
						string dealCurCode 		= dr["DEAL_CUR_CODE"].ToString();
						string dtNote			= dr["DT_NOTE"].ToString();
						string dtCutoffCycleType= dr["DT_CUTOFF_CYCLE_TYPE"].ToString();

						dr.Close();

						sb = new StringBuilder();
						wpb = new WherePhraseBuilder();

						sb.Append("SELECT");
						sb.Append(" [SUPL_CODE], [SUPL_SBNO], [OVERSEAS_SUPL_DT_ID], [RATIO]");
						sb.Append(",[STTL_MTHD_CODE], [USANCE_DAY_CNT], [STTL_TIMING_CODE]");
						sb.Append(" FROM ");
						sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[OVERSEAS_SUPL_DT]"));
			
						wpb.AddFilter(" [SUPL_CODE]", SearchOperator.Equal, code);
						wpb.AddFilter(" [SUPL_SBNO]", SearchOperator.Equal, sbno);
						sb.Append(wpb);

						dt.Columns.Add("OVERSEAS_FLG", typeof(string));
						dt.Columns.Add("TEMP_CODE_FLG", typeof(string));
						dt.Columns.Add("DEAL_CUR_CODE", typeof(string));
						dt.Columns.Add("DT_TYPE", typeof(string));
						dt.Columns.Add("DT_NOTE", typeof(string));
						dt.Columns.Add("DT_CUTOFF_CYCLE_TYPE", typeof(string));
						dt.Columns.Add("OVERSEAS_SUPL_DT_ID", typeof(string));
						dt.Columns.Add("RATIO", typeof(string));
						dt.Columns.Add("STTL_MTHD_CODE", typeof(string));
						dt.Columns.Add("USANCE_DAY_CNT", typeof(string));
						dt.Columns.Add("STTL_TIMING_CODE", typeof(string));
						dt.Columns.Add("PYMT_PLAN_DATE", typeof(string));

						cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
						DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
						dr =  cm.ExecuteReader();
						if (dr.HasRows)
						{
							while (dr.Read())
							{
								DataRow row = dt.NewRow();
								row["DT_TYPE"] 				= dtType;
								row["OVERSEAS_FLG"] 		= overseaseFlg;
								row["TEMP_CODE_FLG"] 		= tempCodeFlg;
								row["DEAL_CUR_CODE"] 		= dealCurCode;
								row["DT_NOTE"]				= dtNote;
								row["DT_CUTOFF_CYCLE_TYPE"] = dtCutoffCycleType;
								row["OVERSEAS_SUPL_DT_ID"]	= dr["OVERSEAS_SUPL_DT_ID"].ToString();
								row["RATIO"] 				= dr["RATIO"].ToString();
								row["STTL_MTHD_CODE"] 		= dr["STTL_MTHD_CODE"].ToString();
								row["USANCE_DAY_CNT"] 		= dr["USANCE_DAY_CNT"].ToString();
								row["STTL_TIMING_CODE"] 	= dr["STTL_TIMING_CODE"].ToString();
								row["PYMT_PLAN_DATE"] 		= string.Empty;
								dt.Rows.Add(row);
							}
						}
						else
						{
							DataRow row = dt.NewRow();
							row["DT_TYPE"] 				= dtType;
							row["OVERSEAS_FLG"] 		= overseaseFlg;
							row["TEMP_CODE_FLG"] 		= tempCodeFlg;
							row["DEAL_CUR_CODE"] 		= dealCurCode;
							row["DT_NOTE"]				= dtNote;
							row["DT_CUTOFF_CYCLE_TYPE"] = dtCutoffCycleType;
							row["OVERSEAS_SUPL_DT_ID"]	= string.Empty;
							row["RATIO"] 				= string.Empty;
							row["STTL_MTHD_CODE"] 		= string.Empty;
							row["USANCE_DAY_CNT"] 		= string.Empty;
							row["STTL_TIMING_CODE"] 	= string.Empty;
							row["PYMT_PLAN_DATE"] 		= string.Empty;
							dt.Rows.Add(row);
						}
					}
					else
					{
						dt.Columns.Add("OVERSEAS_FLG", typeof(string));
						dt.Columns.Add("TEMP_CODE_FLG", typeof(string));
						dt.Columns.Add("DEAL_CUR_CODE", typeof(string));
						dt.Columns.Add("DT_TYPE", typeof(string));
						dt.Columns.Add("DT_NOTE", typeof(string));
						dt.Columns.Add("DT_CUTOFF_CYCLE_TYPE", typeof(string));
						dt.Columns.Add("DT1_STTL_MTHD_CODE", typeof(string));
						dt.Columns.Add("DT1_BASIS_AMT", typeof(string));
						dt.Columns.Add("DT2_STTL_MTHD_CODE", typeof(string));
						dt.Columns.Add("DT2_RATIO", typeof(string));
						dt.Columns.Add("DT3_STTL_MTHD_CODE", typeof(string));
						dt.Columns.Add("DT_SIGHT", typeof(string));

						DataRow row = dt.NewRow();
						row["DT_TYPE"] 				= dr["DT_TYPE"].ToString();
						row["OVERSEAS_FLG"] 		= dr["OVERSEAS_FLG"].ToString();
						row["TEMP_CODE_FLG"] 		= dr["TEMP_CODE_FLG"].ToString();
						row["DEAL_CUR_CODE"] 		= dr["DEAL_CUR_CODE"].ToString();
						row["DT_NOTE"]				= dr["DT_NOTE"].ToString();
						row["DT_CUTOFF_CYCLE_TYPE"]	= dr["DT_CUTOFF_CYCLE_TYPE"].ToString();
						row["DT1_STTL_MTHD_CODE"] 	= dr["DT1_STTL_MTHD_CODE"].ToString();
						row["DT1_BASIS_AMT"]		= dr["DT1_BASIS_AMT"].ToString();
						row["DT2_STTL_MTHD_CODE"] 	= dr["DT2_STTL_MTHD_CODE"].ToString();
						row["DT2_RATIO"] 			= dr["DT2_RATIO"].ToString();
						row["DT3_STTL_MTHD_CODE"] 	= dr["DT3_STTL_MTHD_CODE"].ToString();
						row["DT_SIGHT"] 			= dr["DT_SIGHT"].ToString();
						dt.Rows.Add(row);
					}
				}
				dt.AcceptChanges();
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
			return dt;
		}

// 管理番号 K24789 コメント削除
// 管理番号 K24278 コメント削除
// 管理番号 P18435 コメント削除

		/// <summary>
		/// 電子債権を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCombinationCode">
		/// 仕入先コードと仕入先枝番の連結した文字列。
		/// </param>
		/// <param name="compCodeLength">
		/// 取引先コード固定桁数
		/// </param>
		/// <param name="tradeNoteType">
		/// 営業手形区分
		/// </param>
		/// <param name="electronicNrBankCountryCode">
		/// 電子債権銀行国コード
		/// </param>
		/// <param name="electronicNrBankCode">
		/// 電子債権銀行コード
		/// </param>
		/// <param name="electronicNrBankBranchCode">
		/// 電子債権銀行支店コード
		/// </param>
		/// <param name="electronicNrBankAcType">
		/// 電子債権口座区分
		/// </param>
		/// <param name="electronicNrAcNo">
		/// 電子債権口座番号
		/// </param>
		/// <param name="densaiUserId">
		/// 利用者番号
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
// 管理番号K25321 From
		public static bool GetDensaiInfo(CommonData commonData, string suplCombinationCode, int compCodeLength, out string tradeNoteType, out string electronicNrBankCountryCode, out string electronicNrBankCode, out string electronicNrBankBranchCode, out string electronicNrBankAcType, out string electronicNrAcNo, out string densaiUserId)
		{
			tradeNoteType = string.Empty;
			electronicNrBankCountryCode = string.Empty;
			electronicNrBankCode = string.Empty;
			electronicNrBankBranchCode = string.Empty;
			electronicNrBankAcType = string.Empty;
			electronicNrAcNo = string.Empty;
			densaiUserId = string.Empty;

			if (suplCombinationCode == string.Empty)
			{
				return false;
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
			sb.Append("SELECT");
			sb.Append(" [S].[TRADE_NOTE_TYPE]");
			sb.Append(" ,[S].[ELECTRONIC_NR_BANK_COUNTRY_CODE]");
			sb.Append(" ,[S].[ELECTRONIC_NR_BANK_CODE]");
			sb.Append(" ,[S].[ELECTRONIC_NR_BANK_BRANCH_CODE]");
			sb.Append(" ,[S].[ELECTRONIC_NR_BANK_AC_TYPE]");
			sb.Append(" ,[S].[ELECTRONIC_NR_AC_NO]");
			sb.Append(" ,[C].[DENSAI_USER_ID]");

			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]"));
			sb.Append(" AS [S]");
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[COMP]"));
			sb.Append(" AS [C] ON ");
			sb.Append(" [S].[SUPL_CODE] = [C].[COMP_CODE]");

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

			bool result = false;
			cn.Open();
			SqlDataReader dr = cm.ExecuteReader();
			try
			{
				if (dr.Read())
				{
					tradeNoteType = dr["TRADE_NOTE_TYPE"].ToString();
					electronicNrBankCountryCode = dr["ELECTRONIC_NR_BANK_COUNTRY_CODE"].ToString();
					electronicNrBankCode = dr["ELECTRONIC_NR_BANK_CODE"].ToString();
					electronicNrBankBranchCode = dr["ELECTRONIC_NR_BANK_BRANCH_CODE"].ToString();
					electronicNrBankAcType = dr["ELECTRONIC_NR_BANK_AC_TYPE"].ToString();
					electronicNrAcNo = dr["ELECTRONIC_NR_AC_NO"].ToString();
					densaiUserId = dr["DENSAI_USER_ID"].ToString();

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
// 管理番号K25321 To
		#endregion
	}
}
