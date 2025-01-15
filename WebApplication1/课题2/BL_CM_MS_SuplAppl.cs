// Product     : Allegro
// Unit        : CM
// Module      : MS
// Function    : --
// File Name   : BL_CM_MS_SuplAppl.cs
// 機能名      : 仕入先（申請）共通機能
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 管理番号K20126 2007/02/08 主要マスタWF対応
// 管理番号P20395 2007/03/15 パフォーマンス対応（2007年4月末分）：タイムアウト値延長
// 1.5.1 2007/06/30
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 3.0.0 2018/04/30
// 管理番号K27011 2019/01/23 項目桁数拡張：取引先・商品・勘定科目
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

namespace Infocom.Allegro.CM.MS
{
	/// <summary>
	/// 仕入先（申請）に関する共通機能を提供します。
	/// </summary>
	public sealed class BL_CM_MS_SuplAppl : MarshalByRefObject
	{
		#region Constructors
		private BL_CM_MS_SuplAppl()
		{
		}
		#endregion

		#region Static Methods
		/// <summary>
		/// 仕入先（申請）の存在チェックを行います。
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
			if (suplCode == string.Empty)
			{
				return false;
			}

			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT [SUPL_CODE] FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL_APPL]"));
			sb.Append(" WHERE [SUPL_CODE] = @SuplCode");
			if (suplSbno != string.Empty)
			{
				sb.Append(" AND [SUPL_SBNO] = @SuplSbno");
			}

//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P20395 From
			DBTimeout.setTimeout(cm, commonData); 		//タイムアウト値変更メソッド呼出し
//管理番号P20395 To

// 管理番号K27011 From
//			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, 8).Value = ConvertDBData.ToNVarChar(suplCode);
			cm.Parameters.Add("@SuplCode", SqlDbType.NVarChar, TypeLength.CompCode).Value = ConvertDBData.ToNVarChar(suplCode);
// 管理番号K27011 To
			if (suplSbno != string.Empty)
			{
// 管理番号K27011 From
//				cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, 2).Value = ConvertDBData.ToNVarChar(suplSbno);
				cm.Parameters.Add("@SuplSbno", SqlDbType.NVarChar, TypeLength.CompSbno).Value = ConvertDBData.ToNVarChar(suplSbno);
// 管理番号K27011 To
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
		#endregion
	}
}
