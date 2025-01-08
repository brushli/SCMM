// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : DMAccess.cs
// 機能名      : データマートDB接続情報
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 管理番号 K25403 2014/07/16 グループBI対応
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;
using System.Text;

namespace Infocom.Allegro.BL.SqlClient
{
	/// <summary>
	/// SQL Serverの接続文字列やスキーマ情報等に関する共通機能を提供します。このクラスは継承できません。
	/// </summary>
	public sealed class DMAccess
	{
		private DMAccess()
		{
		}

		/// <summary>
		/// データベースの接続文字列を取得します。
		/// </summary>
		/// <returns>
		/// データマートの接続文字列。
		/// </returns>
		public static string GetConnectionString()
		{
			return MyComp.GetDmConnectionString();
		}

		/// <summary>
		/// DBスキーマ名を取得します。
		/// </summary>
		/// <param name="tableName">
		/// テーブル名
		/// </param>
		/// <returns>
		/// データベース名とDBスキーマ名が付加されたテーブル名。
		/// </returns>
		public static string GetDMSchema(string tableName)
		{
			return MyComp.GetDMSchema("DM", tableName.TrimEnd(' ').TrimStart(' '));
		}
	}
}
