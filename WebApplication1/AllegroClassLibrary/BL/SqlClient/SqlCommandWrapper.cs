// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : SqlCommandWrapper.cs
// 機能名      : SqlCommand拡張
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 管理番号K27230 2021/07/28 脆弱性対応
// 3.2.0 2023/03/31

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infocom.Allegro.BL.SqlClient
{
	/// <summary>
	/// <see cref="SqlCommand"/>のラッパークラス
	/// </summary>
	public class SqlCommandWrapper : IDisposable
	{
		internal SqlCommand _cm;
		protected SqlPString sqlPText;

		/// <summary>
		/// <see cref="SqlCommandWrapper"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		public SqlCommandWrapper()
		{
			this._cm = new SqlCommand();
		}

		/// <summary>
		/// <see cref="SqlCommand"/>クラスのインスタンスから<see cref="SqlCommandWrapper"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="sqlCommand">
		/// SqlCommandクラスのインスタンス
		/// </param>
		internal SqlCommandWrapper(SqlCommand sqlCommand)
		{
			this._cm = sqlCommand ?? new SqlCommand();
		}

		/// <summary>
		/// <see cref="SqlCommandWrapper"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="sqlString">
		/// クエリテキスト
		/// </param>
		/// <param name="cn">
		/// コネクション
		/// </param>
		/// <param name="tx">
		/// トランザクション
		/// </param>
		public SqlCommandWrapper(SqlPString sqlString, SqlConnection cn, SqlTransaction tx = null)
		{
			this.sqlPText = sqlString;

			if (sqlString is object)
			{
				this._cm = tx is null ? new SqlCommand(sqlString.ToString(), cn) : new SqlCommand(sqlString.ToString(), cn, tx);
			}
			else
			{
				this._cm = tx is null ? new SqlCommand(null, cn) : new SqlCommand(null, cn, tx);
			}
		}

		/// <summary>
		/// <see cref="SqlCommand"/>のCommandTypeと同等
		/// </summary>
		public CommandType CommandType
		{
			get => this._cm.CommandType;
			set => this._cm.CommandType = value;
		}

		/// <summary>
		/// <see cref="SqlCommand"/>のParametersと同等
		/// </summary>
		public SqlParameterCollection Parameters
		{
			get => this._cm.Parameters;
		}

		/// <summary>
		/// <see cref="SqlCommand"/>のExecuteNonQuery()と同等
		/// </summary>
		public int ExecuteNonQuery()
		{
			return this._cm.ExecuteNonQuery();
		}

		/// <summary>
		/// <see cref="SqlCommand"/>のExecuteReader()と同等
		/// </summary>
		public SqlDataReader ExecuteReader()
		{
			return this._cm.ExecuteReader();
		}

		/// <summary>
		/// <see cref="SqlCommand"/>のExecuteScalar()と同等
		/// </summary>
		public object ExecuteScalar()
		{
			return this._cm.ExecuteScalar();
		}

		/// <summary>
		/// <see cref="IDisposable"/>のDispose()
		/// </summary>
		public void Dispose()
		{
			((IDisposable)_cm).Dispose();
		}

		/// <summary>
		/// <see cref="SqlCommand"/>のCommandTimeoutと同等
		/// </summary>
		public int CommandTimeout
		{
			get => this._cm.CommandTimeout;
			set => this._cm.CommandTimeout = value;
		}

		/// <summary>
		/// ステートメントまたはストアド プロシージャを取得または設定
		/// </summary>
		public SqlPString CommandText
		{
			get => this.sqlPText;
			set
			{
				if (value is object)
				{
					this._cm.CommandText = value.ToString();
				}
				else
				{
					this._cm.CommandText = null;
				}
			}
		}

		/// <summary>
		/// ステートメントまたはストアド プロシージャをリテラル文字列で取得または設定
		/// </summary>
		public string LiteralCommandText
		{
			get => this._cm.CommandText;
			set => this._cm.CommandText = value;
		}

		/// <summary>
		/// <see cref="SqlCommand"/>のConnectionと同等
		/// </summary>
		public SqlConnection Connection
		{
			get => this._cm.Connection;
			set => this._cm.Connection = value;
		}

		/// <summary>
		/// <see cref="SqlCommand"/>のTransactionと同等
		/// </summary>
		public SqlTransaction Transaction
		{
			get => this._cm.Transaction;
			set => this._cm.Transaction = value;
		}
	}
}
