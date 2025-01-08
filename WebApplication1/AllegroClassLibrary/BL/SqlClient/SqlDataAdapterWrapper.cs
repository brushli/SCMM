// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : SqlDataAdapterWrapper.cs
// 機能名      : SqlDataAdapter拡張
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
	/// <see cref="SqlDataAdapter"/>のラッパークラス
	/// </summary>
	public class SqlDataAdapterWrapper : IDisposable
	{
		internal SqlDataAdapter _da;
		protected SqlCommandWrapper _selectCommand;
		protected SqlCommandWrapper _updateCommand;
		protected SqlCommandWrapper _insertCommand;
		protected SqlCommandWrapper _deleteCommand;
		protected string sqlText;

		/// <summary>
		/// <see cref="SqlDataAdapterWrapper"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		public SqlDataAdapterWrapper()
		{
			this._da = new SqlDataAdapter();
		}

		/// <summary>
		/// <see cref="SqlCommandWrapper"/>クラスのインスタンスから<see cref="SqlDataAdapterWrapper"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="selectCommand">
		/// SqlCommandWrapperクラスのインスタンス
		/// </param>
		public SqlDataAdapterWrapper(SqlCommandWrapper selectCommand)
		{
			this._da = new SqlDataAdapter(selectCommand._cm);
			this._selectCommand = selectCommand;
		}

		/// <summary>
		/// <see cref="SqlDataAdapterWrapper"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="sqlString">
		/// クエリテキスト
		/// </param>
		/// <param name="cn">
		/// コネクション
		/// </param>
		public SqlDataAdapterWrapper(SqlPString sqlString, SqlConnection cn)
		{
			this.sqlText = sqlString?.ToString();
			this._da = new SqlDataAdapter(this.sqlText, cn);
		}

		/// <summary>
		/// データ ソース内のレコードを選択するための Transact-SQL ステートメントまたはストアド プロシージャを取得または設定
		/// </summary>
		public SqlCommandWrapper SelectCommand
		{
			get
			{
				if (this._selectCommand is null)
				{
					this._selectCommand = new SqlCommandWrapper(this._da.SelectCommand);
				}
				return this._selectCommand;
			}
			set
			{
				this._da.SelectCommand = value._cm;
				this._selectCommand = value;
			}
		}

		/// <summary>
		/// データ ソース内のレコードを更新するための Transact-SQL ステートメントまたはストアド プロシージャを取得または設定
		/// </summary>
		public SqlCommandWrapper UpdateCommand
		{
			get
			{
				if (this._updateCommand is null)
				{
					this._updateCommand = new SqlCommandWrapper(this._da.UpdateCommand);
				}
				return this._updateCommand;
			}
			set
			{
				this._da.UpdateCommand = value._cm;
				this._updateCommand = value;
			}
		}

		/// <summary>
		/// データ ソースに新しいレコードを挿入するための Transact-SQL ステートメントまたはストアド プロシージャを取得または設定
		/// </summary>
		public SqlCommandWrapper InsertCommand
		{
			get
			{
				if (this._insertCommand is null)
				{
					this._insertCommand = new SqlCommandWrapper(this._da.InsertCommand);
				}
				return this._insertCommand;
			}
			set
			{
				this._da.InsertCommand = value._cm;
				this._insertCommand = value;
			}
		}

		/// <summary>
		/// データ セットからレコードを削除するための Transact-SQL ステートメントまたはストアド プロシージャを取得または設定
		/// </summary>
		public SqlCommandWrapper DeleteCommand
		{
			get
			{
				if (this._deleteCommand is null)
				{
					this._deleteCommand = new SqlCommandWrapper(this._da.DeleteCommand);
				}
				return this._deleteCommand;
			}
			set
			{
				this._da.DeleteCommand = value._cm;
				this._deleteCommand = value;
			}
		}

		/// <summary>
		/// <see cref="SqlDataAdapter"/>のUpdateと同等
		/// </summary>
		/// <param name="dataTable">
		/// DataTable
		/// </param>
		/// <returns>
		/// 正常に更新された行の数
		/// </returns>
		public int Update(DataTable dataTable)
		{
			return this._da.Update(dataTable);
		}

		/// <summary>
		/// <see cref="SqlDataAdapter"/>のFillと同等
		/// </summary>
		/// <param name="dataTable">
		/// DataTable
		/// </param>
		/// <returns>
		/// 追加または更新された行数
		/// </returns>
		public int Fill(DataTable dataTable)
		{
			return this._da.Fill(dataTable);
		}

		/// <summary>
		/// <see cref="IDisposable"/>のDispose()
		/// </summary>
		public void Dispose()
		{
			((IDisposable)_da).Dispose();
		}
	}
}
