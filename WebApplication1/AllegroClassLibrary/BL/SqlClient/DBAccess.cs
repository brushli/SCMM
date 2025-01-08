// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : DBAccess.cs
// 機能名      : DB接続情報
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 3.1.0 2020/06/30
// 管理番号K27230 2021/07/28 脆弱性対応
// 管理番号K27445 2022/08/10 ログ管理強化
// 3.2.0 2023/03/31

using System;
using System.Text;
// 管理番号K27445 From
using System.Data.SqlClient;
// 管理番号K27445 To

namespace Infocom.Allegro.BL.SqlClient
{
	/// <summary>
	/// SQL Serverの接続文字列やスキーマ情報等に関する共通機能を提供します。このクラスは継承できません。
	/// </summary>
	public sealed class DBAccess
	{
		private DBAccess()
		{
		}
// 管理番号 K24546 From
		/// <summary>
		/// 言語設定文字列が付加されたデータベースの接続文字列を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <returns>
		/// 指定された自社コードにおける言語設定文字列が付加された接続文字列。
		/// </returns>
		public static string GetConnectionString(CommonData commonData)
		{
			if (commonData == null)
			{
				throw new ArgumentException();
			}
			else
			{
				string connectionStringLnaguage = "Language=" + GetConnectionLanguageString(commonData) + ";";
// 管理番号K27445 From
//				return GetConnectionString(commonData.CompCode) + connectionStringLnaguage;
				return GetConnectionString(commonData.CompCode, commonData.PageID, commonData.UserHostName) + connectionStringLnaguage;
// 管理番号K27445 To
			}
		}
// 管理番号 K24546 To
		/// <summary>
		/// データベースの接続文字列を取得します。
		/// </summary>
		/// <param name="myCompCode">
		/// 自社コード
		/// </param>
		/// <param name="pageId">
		/// 機能ID
		/// </param>
		/// <param name="userHostName">
		/// GRANDITアクセス中のクライアントホスト名
		/// </param>
		/// <returns>
		/// 指定された自社コードにおける接続文字列。
		/// </returns>
// 管理番号K27445 From
//		public static string GetConnectionString(string myCompCode)
		public static string GetConnectionString(string myCompCode, string pageId, string userHostName)
// 管理番号K27445 To
		{
			if (myCompCode == null)
			{
				throw new ArgumentException();
			}
			else
			{
// 管理番号K27445 From
//				return MyComp.GetConnectionString(myCompCode);
				string connectionString = MyComp.GetConnectionString(myCompCode);
				SqlConnectionStringBuilder scsb = new SqlConnectionStringBuilder(connectionString)
				{
					ApplicationName = pageId ?? string.Empty,		// 監査ログのアプリケーション名更新
					WorkstationID = userHostName ?? string.Empty	// 監査ログのホスト名更新
				};

				return scsb.ConnectionString + ";";
// 管理番号K27445 To
			}
		}

		/// <summary>
		/// DBスキーマ名を取得します。
		/// </summary>
		/// <param name="myCompCode">
		/// 自社コード
		/// </param>
		/// <param name="unitID">
		/// ユニットID
		/// </param>
		/// <param name="tableName">
		/// テーブル名
		/// </param>
		/// <returns>
		/// データベース名とDBスキーマ名が付加されたテーブル名。
		/// </returns>
		public static string GetDBSchema(string myCompCode, UnitID unitID, string tableName)
		{
// 管理番号K27230 From
//			return MyComp.GetDBSchema(myCompCode, unitID, tableName.TrimEnd(' ').TrimStart(' '));
			return (string)GetDBSchema(myCompCode, unitID, (SqlPString)tableName);
		}

		/// <summary>
		/// DBスキーマ名を取得します。
		/// </summary>
		/// <param name="myCompCode">
		/// 自社コード
		/// </param>
		/// <param name="unitID">
		/// ユニットID
		/// </param>
		/// <param name="tableName">
		/// SqlPString型のテーブル名
		/// </param>
		/// <returns>
		/// データベース名とDBスキーマ名が付加されたSqlPString型のテーブル名。
		/// </returns>
		public static SqlPString GetDBSchema(string myCompCode, UnitID unitID, SqlPString tableName)
		{
			string schema = MyComp.GetDBSchema(myCompCode, unitID, "$$DUMMY_TABLE_NAME$$");

			if (schema.Length > 0)
			{
				return schema.Replace("$$DUMMY_TABLE_NAME$$", "") + tableName.TrimEnd(' ').TrimStart(' ');
			}
			else
			{
				return "";
			}
// 管理番号K27230 To
		}

// 管理番号 K24546 From
		/// <summary>
		/// ウェブブラウザから取得する言語設定からDB接続に使用する言語設定文字列を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <returns>
		/// 現在のカルチャに対応する言語設定文字列。
		/// </returns>
		/// <remarks>
		/// <paramref name="commonData"/>は使用していません。
		/// </remarks>
		public static string GetConnectionLanguageString(CommonData commonData)
		{
			if (MultiLanguage.Get("CM_CS003579") != string.Empty)
			{
				return MultiLanguage.Get("CM_CS003579");
			}
			else
			{
				return "日本語";
			}
		}

		/// <summary>
		/// SQL Serverのローカル言語識別子からカルチャ文字列を取得します。
		/// </summary>
		/// <param name="langId">
		/// 言語ID
		/// </param>
		/// <returns>
		/// 指定された言語IDに対応するカルチャ文字列。
		/// </returns>
		public static string GetConnectionLanguageString(int langId)
		{
			switch (langId)
			{
				case 0:
					return "en-US";
				case 3:
					return "ja-JP";
				case 30:
					return "zh-CN";
				case 11:
					return "sv-SE";
				default:
					return "ja-JP";
			}
		}
// 管理番号 K24546 To

	}
}
