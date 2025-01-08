// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : RptCache.cs
// 機能名      : 帳票ディスクキャッシュ情報管理
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.

// 管理番号 K22634 2009/03/05 帳票ディスクキャッシュ対応
// 1.6.0 2009/09/30
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 3.1.0 2020/06/30
// 管理番号K27230 2021/09/06 脆弱性対応
// 3.2.0 2023/03/31

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using Infocom.Allegro.BL.SqlClient;
using Infocom.Allegro.IF;

namespace Infocom.Allegro.Report
{
	/// <summary>
	/// 帳票ディスクキャッシュ情報管理に関する共通機能を提供します。
	/// </summary>
	public class RptCache
	{
		/// <summary>
		/// ディスクキャッシュフラグ
		/// </summary>
		public bool CacheToDisk = false;
		/// <summary>
		/// ディスクキャッシュ保存場所
		/// </summary>
		public string CacheToDiskLocation = null;

		/// <summary>
		/// 帳票ディスクキャッシュ情報管理のコンストラクタです。
		/// </summary>
		/// <param name="PageID">
		/// ページID
		/// </param>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		public RptCache(string PageID, CommonData commonData)
		{
			Select(PageID,commonData);
		}

		/// <summary>
		/// 指定したレポートコードにおけるディスクキャッシュフラグとディスクキャッシュ保存場所を検索します。
		/// </summary>
		/// <param name="ReportID">
		/// レポートID
		/// </param>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		protected void Select(string ReportID, CommonData commonData)
		{
			string CacheToDisk = "0";
			string CacheToDiskLocation = null;

			StringBuilder sb = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();
//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			cn.Open();

			sb.Append("SELECT ");
			sb.Append("[CACHE_TO_DISK]");
			sb.Append(",[CACHE_TO_DISK_LOCATION] ");
			sb.Append("FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[REPORT]"));
			wpb = new WherePhraseBuilder();
			wpb.AddFilter("[REPORT_CODE]", SearchOperator.Equal, ReportID);
			sb.Append(wpb);
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
			DBTimeout.setTimeout(cm, commonData);
			SqlDataReader dr = cm.ExecuteReader();
			try
			{
				if (dr.Read())
				{
					CacheToDisk = dr["CACHE_TO_DISK"].ToString();
					CacheToDiskLocation = dr["CACHE_TO_DISK_LOCATION"].ToString();
				}
				else
				{
					AllegroLog.Write(commonData, ExceptionLevel.Info, AllegroMessage.CM_AC_S20011(ReportID));
				}
			}
			catch (SqlException ex)
			{
				new AllegroException(commonData, ex).WriteLog();
			}
			finally
			{
				dr.Close();
				cn.Close();
			}

			if (CacheToDisk.Equals("1"))
			{
				this.CacheToDisk = true;
				if (Directory.Exists(CacheToDiskLocation))
				{
					this.CacheToDiskLocation = CacheToDiskLocation;
				}
				else
				{
					AllegroLog.Write(commonData, ExceptionLevel.Info, AllegroMessage.CM_AC_S20012(ReportID));
				}
			}
			else if (!CacheToDisk.Equals("0"))
			{
				AllegroLog.Write(commonData, ExceptionLevel.Info, AllegroMessage.CM_AC_S20013(ReportID));
			}
		}
	}
}
