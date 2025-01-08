// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : DBTimeout.cs
// 機能名      : タイムアウト値制御
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.4.1 2006/09/30
// 管理番号 P19345 2006/12/13 タイムアウト値取得メソッド追加
// 1.5.1 2007/06/30
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25879 2016/02/16 マイナンバー対応
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 3.1.0 2020/06/30
// 管理番号K27230 2021/07/28 脆弱性対応
// 管理番号K27445 2022/08/10 ログ管理強化
// 3.2.0 2023/03/31

using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;


namespace Infocom.Allegro.BL.SqlClient
{
	/// <summary>
	/// 画面毎にSQL Serverタイムアウト値を取得するためのメソッドを提供します。
	/// また、バッチ起動における排他チェックをしています。このクラスは継承できません。
	/// </summary>
	public sealed class DBTimeout
	{
// 管理番号K25879 From
//		public DBTimeout()
		private DBTimeout()
// 管理番号K25879 To
		{
		}

		/// <summary>
		/// <see cref="SqlCommandWrapper"/>に対し、<see cref="CommonData.PageID"/>に対応するタイムアウト値を設定します。
		/// </summary>
		/// <param name="sc">
		/// 実行する<see cref="SqlCommandWrapper"/>。
		/// </param>
		/// <param name="cd">
		/// 共通データ
		/// </param>
// 管理番号K27230 From
//		public static void setTimeout(SqlCommand sc, CommonData cd)
		public static void setTimeout(SqlCommandWrapper sc, CommonData cd)
// 管理番号K27230 To
		{ 
			if (cd == null)		//CommonDataが空の場合、無処理
			{
				return;
			}
// 管理番号K27445 From
//			sc.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S);
			sc.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S, cd.UserHostName);
// 管理番号K27445 To
		}

		/// <summary>
		/// <see cref="SqlCommandWrapper"/>に対し、<see cref="CommonData.PageID"/>に対応するタイムアウト値を設定します。
		/// </summary>
		/// <param name="sc">
		/// 実行する<see cref="SqlCommandWrapper"/>。
		/// </param>
		/// <param name="cd">
		/// 共通データ
		/// </param>
		/// <param name="isBatch">
		/// バッチ処理かどうか。
		/// </param>
// 管理番号K27230 From
//		public static void setTimeout(SqlCommand sc, CommonData cd, bool isBatch)
		public static void setTimeout(SqlCommandWrapper sc, CommonData cd, bool isBatch)
// 管理番号K27230 To
		{ 
			if (cd == null)		//CommonDataが空の場合、無処理
			{
				return;
			}

			if (isBatch)
			{
// 管理番号K27445 From
//				sc.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.B);			
				sc.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.B, cd.UserHostName);
// 管理番号K27445 To
			} 
			else 
			{
// 管理番号K27445 From
//				sc.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S);			
				sc.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S, cd.UserHostName);
// 管理番号K27445 To
			}
		}

		/// <summary>
		/// <see cref="SqlCommandWrapper"/>に対し、<see cref="CommonData.PageID"/>に対応するタイムアウト値を設定します。
		/// </summary>
		/// <param name="sc">
		/// 実行する<see cref="SqlCommandWrapper"/>。
		/// </param>
		/// <param name="pagecode">
		/// ページコード
		/// </param>
		/// <param name="compcode">
		/// 自社コード
		/// </param>
// 管理番号K27230 From
//		public static void setTimeout(SqlCommand sc, string pagecode, string compcode)
		public static void setTimeout(SqlCommandWrapper sc, string pagecode, string compcode)
// 管理番号K27230 To
		{ 
			sc.CommandTimeout = getTimeout(compcode, pagecode, null, PageType.S);
		}

		/// <summary>
		/// <see cref="SqlDataAdapterWrapper"/>に対し、<see cref="CommonData.PageID"/>に対応するタイムアウト値を設定します。
		/// </summary>
		/// <param name="sda">
		/// 実行する<see cref="SqlDataAdapterWrapper"/>。
		/// </param>
		/// <param name="cd">
		/// 共通データ
		/// </param>
// 管理番号K27230 From
//		public static void setTimeout(SqlDataAdapter sda, CommonData cd)
		public static void setTimeout(SqlDataAdapterWrapper sda, CommonData cd)
// 管理番号K27230 To
		{
			if (cd == null)		//CommonDataが空の場合、無処理
			{
				return;
			}
			if (sda.SelectCommand != null)
			{
// 管理番号K27445 From
//				sda.SelectCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S);
				sda.SelectCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S, cd.UserHostName);
// 管理番号K27445 To
			}
			else if (sda.UpdateCommand != null)
			{
// 管理番号K27445 From
//				sda.UpdateCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S);
				sda.UpdateCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S, cd.UserHostName);
// 管理番号K27445 To
			}
			else if (sda.DeleteCommand != null)
			{
// 管理番号K27445 From
//				sda.DeleteCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S);
				sda.DeleteCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S, cd.UserHostName);
// 管理番号K27445 To
			}
			else if (sda.InsertCommand != null)
			{
// 管理番号K27445 From
//				sda.InsertCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S);
				sda.InsertCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S, cd.UserHostName);
// 管理番号K27445 To
			}
		}

		/// <summary>
		/// <see cref="SqlDataAdapterWrapper"/>に対し、<see cref="CommonData.PageID"/>に対応するタイムアウト値を設定します。
		/// </summary>
		/// <param name="sda">
		/// 実行する<see cref="SqlDataAdapterWrapper"/>。
		/// </param>
		/// <param name="cd">
		/// 共通データ
		/// </param>
		/// <param name="isBatch">
		/// バッチ処理かどうか。
		/// </param>
// 管理番号K27230 From
//		public static void setTimeout(SqlDataAdapter sda, CommonData cd, bool isBatch)
		public static void setTimeout(SqlDataAdapterWrapper sda, CommonData cd, bool isBatch)
// 管理番号K27230 To
		{
			if (cd == null)		//CommonDataが空の場合、無処理
			{
				return;
			}
			if (sda.SelectCommand != null)
			{
				if (isBatch)
				{
// 管理番号K27445 From
//					sda.SelectCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.B);
					sda.SelectCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.B, cd.UserHostName);
// 管理番号K27445 To
				} 
				else 
				{
// 管理番号K27445 From
//					sda.SelectCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S);
					sda.SelectCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S, cd.UserHostName);
// 管理番号K27445 To
				}				
			}
			else if (sda.UpdateCommand != null)
			{
				if (isBatch)
				{
// 管理番号K27445 From
//					sda.UpdateCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.B);
					sda.UpdateCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.B, cd.UserHostName);
// 管理番号K27445 To
				} 
				else 
				{
// 管理番号K27445 From
//					sda.UpdateCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S);
					sda.UpdateCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S, cd.UserHostName);
// 管理番号K27445 To
				}
			}
			else if (sda.DeleteCommand != null)
			{
				if (isBatch)
				{
// 管理番号K27445 From
//					sda.DeleteCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.B);
					sda.DeleteCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.B, cd.UserHostName);
// 管理番号K27445 To
				} 
				else 
				{
// 管理番号K27445 From
//					sda.DeleteCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S);
					sda.DeleteCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S, cd.UserHostName);
// 管理番号K27445 To
				}				
			}
			else if (sda.InsertCommand != null)
			{
				if (isBatch)
				{
// 管理番号K27445 From
//					sda.InsertCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.B);
					sda.InsertCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.B, cd.UserHostName);
// 管理番号K27445 To
				} 
				else 
				{
// 管理番号K27445 From
//					sda.InsertCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S);
					sda.InsertCommand.CommandTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S, cd.UserHostName);
// 管理番号K27445 To
				}				
			}
		}
		// 管理番号 P19345 From
		/// <summary>
		/// <see cref="SqlDataAdapterWrapper"/>に対し、<see cref="CommonData.PageID"/>に対応するタイムアウト値を設定します。
		/// </summary>
		/// <param name="sda">
		/// 実行する<see cref="SqlDataAdapterWrapper"/>。
		/// </param>
		/// <param name="pagecode">
		/// ページコード
		/// </param>
		/// <param name="compcode">
		/// 自社コード
		/// </param>
		/// <param name="isBatch">
		/// バッチ処理かどうか。
		/// </param>
// 管理番号K27230 From
//		public static void setTimeout(SqlDataAdapter sda, string pagecode, string compcode, bool isBatch)
		public static void setTimeout(SqlDataAdapterWrapper sda, string pagecode, string compcode, bool isBatch)
// 管理番号K27230 To
		{
			if (sda.SelectCommand != null)
			{
				if (isBatch)
				{
					sda.SelectCommand.CommandTimeout = getTimeout(compcode, pagecode, null, PageType.B);
				} 
				else 
				{
					sda.SelectCommand.CommandTimeout = getTimeout(compcode, pagecode, null, PageType.S);
				}				
			}
			else if (sda.UpdateCommand != null)
			{
				if (isBatch)
				{
					sda.UpdateCommand.CommandTimeout = getTimeout(compcode, pagecode, null, PageType.B);
				} 
				else 
				{
					sda.UpdateCommand.CommandTimeout = getTimeout(compcode, pagecode, null, PageType.S);
				}
			}
			else if (sda.DeleteCommand != null)
			{
				if (isBatch)
				{
					sda.DeleteCommand.CommandTimeout = getTimeout(compcode, pagecode, null, PageType.B);
				} 
				else 
				{
					sda.DeleteCommand.CommandTimeout = getTimeout(compcode, pagecode, null, PageType.S);
				}				
			}
			else if (sda.InsertCommand != null)
			{
				if (isBatch)
				{
					sda.InsertCommand.CommandTimeout = getTimeout(compcode, pagecode, null, PageType.B);
				} 
				else 
				{
					sda.InsertCommand.CommandTimeout = getTimeout(compcode, pagecode, null, PageType.S);
				}				
			}			
		}
		// 管理番号 P19345 

		/// <summary>
		/// <see cref="SqlDataAdapterWrapper"/>に対し、<see cref="CommonData.PageID"/>に対応するタイムアウト値を設定します。
		/// </summary>
		/// <param name="sda">
		/// 実行する<see cref="SqlDataAdapterWrapper"/>。
		/// </param>
		/// <param name="pagecode">
		/// ページコード
		/// </param>
		/// <param name="compcode">
		/// 自社コード
		/// </param>
// 管理番号K27230 From
//		public static void setTimeout(SqlDataAdapter sda,string pagecode, string compcode)
		public static void setTimeout(SqlDataAdapterWrapper sda,string pagecode, string compcode)
// 管理番号K27230 To
		{ 
			if (sda.SelectCommand != null)
			{
				sda.SelectCommand.CommandTimeout = getTimeout(compcode, pagecode, null, PageType.S);
			}
			else if (sda.UpdateCommand != null)
			{
				sda.UpdateCommand.CommandTimeout = getTimeout(compcode, pagecode, null, PageType.S);
			}
			else if (sda.DeleteCommand != null)
			{
				sda.DeleteCommand.CommandTimeout = getTimeout(compcode, pagecode, null, PageType.S);
			}
			else if (sda.InsertCommand != null)
			{
				sda.InsertCommand.CommandTimeout = getTimeout(compcode, pagecode, null, PageType.S);
			}
		}

		// 管理番号 K25879 From
		/// <summary>
		/// <see cref="SqlBulkCopy"/>に対し、<see cref="CommonData.PageID"/>に対応するタイムアウト値を設定します。
		/// </summary>
		/// <param name="sbc">
		/// 実行する<see cref="SqlBulkCopy"/>。
		/// </param>
		/// <param name="cd">
		/// 共通データ
		/// </param>
		public static void setTimeout(SqlBulkCopy sbc, CommonData cd)
		{ 
			if (cd == null)		//CommonDataが空の場合、無処理
			{
				return;
			}
// 管理番号K27445 From
//			sbc.BulkCopyTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S);
			sbc.BulkCopyTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S, cd.UserHostName);
// 管理番号K27445 To
		}

		/// <summary>
		/// <see cref="SqlBulkCopy"/>に対し、<see cref="CommonData.PageID"/>に対応するタイムアウト値を設定します。
		/// </summary>
		/// <param name="sbc">
		/// 実行する<see cref="SqlBulkCopy"/>。
		/// </param>
		/// <param name="cd">
		/// 共通データ
		/// </param>
		/// <param name="isBatch">
		/// バッチ処理かどうか。
		/// </param>
		public static void setTimeout(SqlBulkCopy sbc, CommonData cd, bool isBatch)
		{ 
			if (cd == null)		//CommonDataが空の場合、無処理
			{
				return;
			}

			if (isBatch)
			{
// 管理番号K27445 From
//				sbc.BulkCopyTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.B);			
				sbc.BulkCopyTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.B, cd.UserHostName);
// 管理番号K27445 To
			} 
			else 
			{
// 管理番号K27445 From
//				sbc.BulkCopyTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S);			
				sbc.BulkCopyTimeout = getTimeout(cd.CompCode, cd.PageID, cd.UserName, PageType.S, cd.UserHostName);
// 管理番号K27445 To
			}
		}

		/// <summary>
		/// <see cref="SqlBulkCopy"/>に対し、<see cref="CommonData.PageID"/>に対応するタイムアウト値を設定します。
		/// </summary>
		/// <param name="sbc">
		/// 実行する<see cref="SqlBulkCopy"/>。
		/// </param>
		/// <param name="pagecode">
		/// ページコード
		/// </param>
		/// <param name="compcode">
		/// 自社コード
		/// </param>
		public static void setTimeout(SqlBulkCopy sbc, string pagecode, string compcode)
		{ 
			sbc.BulkCopyTimeout = getTimeout(compcode, pagecode, null, PageType.S);
		}
// 管理番号 K25879 To


		#region Private Methods
// 管理番号K27445 From
//		private static int getTimeout(string compcode, string pagecode, string username, PageType pt)
		private static int getTimeout(string compcode, string pagecode, string username, PageType pt, string userhostname = "system")
// 管理番号K27445 To
		{
			if (compcode == null)
			{
				return 120;					//デフォルト値を戻す
			}

			if (pagecode == null)
			{
				return 120;					//デフォルト値を戻す
			}

			//CommonDataの作成
			if (username == null)
			{
				username = "ADMIN";
			}

// 管理番号K27445 From
//			CommonData cd = new CommonData(compcode, username, pagecode);
			CommonData cd = new CommonData(compcode, username, pagecode, userhostname);
// 管理番号K27445 To

			int timeout = 0;

			StringBuilder sb = new StringBuilder();

			sb.Append(DBAccess.GetDBSchema(compcode, UnitID.CM, "CM_MS_Get_Timeout_Value"));	//タイムアウト値取得ストアドプロシージャ

// 管理番号K27445 From
//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(compcode));
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(cd));
// 管理番号K27445 To
			cn.Open();

// 管理番号K27230 From
//			SqlCommand cm = new SqlCommand(sb.ToString(), cn);
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);
// 管理番号K27230 To
			cm.CommandType = CommandType.StoredProcedure;
			//ページID(I)
			cm.Parameters.Add("@PAGE_CODE", SqlDbType.NVarChar, 12).Value = pagecode.Trim();
			//自社コード(I)
			cm.Parameters.Add("@MYCOMP_CODE", SqlDbType.NVarChar, 8).Value = compcode.Trim();
			//タイムアウト値(O)
			cm.Parameters.Add("@TIMEOUT_VALUE", SqlDbType.Decimal , 5 );
			//エラー番号(O)
			cm.Parameters.Add("@RET", SqlDbType.Decimal, 5);
			//インフォメーション(O)
			cm.Parameters.Add("@RESULT_INFORMATION", SqlDbType.NVarChar, 100);
			//タイムアウト値:出力パラメータ指定
			cm.Parameters["@TIMEOUT_VALUE"].Direction = ParameterDirection.Output;
			//エラー番号:出力パラメータ指定
			cm.Parameters["@RET"].Direction = ParameterDirection.Output;
			//インフォメーション:出力パラメータ指定
			cm.Parameters["@RESULT_INFORMATION"].Direction = ParameterDirection.Output;
			//ページ種類(I)
			switch(pt)
			{
				case PageType.S:
					cm.Parameters.Add("@PAGE_TYPE", SqlDbType.NVarChar,1).Value = "S";
					break;
				case PageType.B:
					cm.Parameters.Add("@PAGE_TYPE", SqlDbType.NVarChar,1).Value = "B";
					break;
				default:
					cm.Parameters.Add("@PAGE_TYPE", SqlDbType.NVarChar,1).Value = "S";
					break;
			}

			try
			{
				//ストアドプロシージャ実行
				cm.ExecuteNonQuery();
				//エラー番号取得
				int ret = Int32.Parse(cm.Parameters["@RET"].Value.ToString());
				//インフォメーション取得
				string resultInformation = cm.Parameters["@RESULT_INFORMATION"].Value.ToString();

				if (ret != 0)
				{
					throw (new AllegroException(cd, ExceptionLevel.Warning, resultInformation).WriteLog(resultInformation.ToString()));
				}

				timeout    = Int32.Parse(cm.Parameters["@TIMEOUT_VALUE"].Value.ToString());

			}
			catch (SqlException ex)
			{
				string errorMessage= "Procedure=[" + ex.Procedure + "]\r\nLineNumber=[" + ex.LineNumber + "]\r\nMessage=[" + ex.Message + "]";
				throw (new AllegroException(cd, ExceptionLevel.Error, errorMessage).WriteLog(errorMessage.ToString()));
			}
			finally
			{
				cn.Close();
			}

			return timeout;

		}
		#endregion

		/// <summary>
		/// タイムアウト値を取得するためのページ種類。
		/// </summary>
		public enum PageType
		{
			/// <summary>
			/// 画面・クライアント帳票
			/// </summary>
			S,
			/// <summary>
			/// バッチ帳票
			/// </summary>
			B
		}
	}
}
