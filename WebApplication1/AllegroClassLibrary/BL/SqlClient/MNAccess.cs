// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : MNAccess.cs
// 機能名      : 個人番号DB接続情報
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 2.2.0 2014/10/31
// 管理番号 K25879 2016/02/15 マイナンバー対応
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;
using System.Text;

namespace Infocom.Allegro.BL.SqlClient
{
	/// <summary>
	/// SQL Serverの接続文字列やスキーマ情報等に関する共通機能を提供します。このクラスは継承できません。
	/// </summary>
	public sealed class MNAccess
	{
		/// <summary>
		/// 個人番号DBのID。
		/// </summary>
		public const string MN_ID = "MN";

		private MNAccess()
		{
		}

		/// <summary>
		/// データベースの接続文字列を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <returns>
		/// 指定された共通データ.自社コードにおける接続文字列。
		/// </returns>
		public static string GetConnectionString(CommonData commonData)
		{
			if (commonData == null)
			{
				throw new ArgumentException();
			}
			else
			{
				return GetConnectionString(commonData.CompCode);
			}
		}


		/// <summary>
		/// データベースの接続文字列を取得します。
		/// </summary>
		/// <param name="myCompCode">
		/// 自社コード
		/// </param>
		/// <returns>
		/// 指定された自社コードにおける接続文字列。
		/// </returns>
		public static string GetConnectionString(string myCompCode)
		{
			if (myCompCode == null)
			{
				throw new ArgumentException();
			}
			else
			{
				return MyComp.GetMnConnectionString(myCompCode);
			}
		}

		/// <summary>
		/// DBスキーマ名を取得します。
		/// </summary>
		/// <param name="myCompCode">
		/// 自社コード
		/// </param>
		/// <param name="dbId">
		/// 個人番号データベースID
		/// </param>
		/// <param name="tableName">
		/// テーブル名
		/// </param>
		/// <returns>
		/// データベース名とDBスキーマ名が付加されたテーブル名。
		/// </returns>
		public static string GetSchema(string myCompCode, string dbId, string tableName)
		{
			return MyComp.GetMnSchema(myCompCode, dbId, tableName.TrimEnd(' ').TrimStart(' '));
		}
	}
}
