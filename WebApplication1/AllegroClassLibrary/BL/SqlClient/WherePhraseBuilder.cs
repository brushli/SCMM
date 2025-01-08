// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : WherePhraseBuilder.cs
// 機能名      : SQLステートメントのWHERE句生成
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 1.6.0 2009/09/30
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 3.1.0 2020/06/30
// 管理番号K27230 2021/07/28 脆弱性対応
// 3.2.0 2023/03/31

using System;
using System.Data;
using System.Text;
using Infocom.Allegro.IF;

namespace Infocom.Allegro.BL.SqlClient
{
	/// <summary>
	/// SQLクエリのWHERE句を生成する機能を提供します。このクラスは継承できません。
	/// </summary>
	/// <remarks>
	/// <p><see cref="WherePhraseBuilder.AddFilter(string)"/> メソッドを利用して条件を登録するとその条件を基に WHERE 句を生成することができます。WHERE 句は全ての条件を AND で結合して生成されます。</p>
	/// <p><see cref="Append(string)"/> メソッドを利用すると任意の文字列を追加することができます。</p>
	/// </remarks>
	public sealed class WherePhraseBuilder
	{
		private StringBuilder wherePhrase;

		#region Constructors
		/// <summary>
		/// <see cref="WherePhraseBuilder"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		public WherePhraseBuilder() : this(64)
		{
		}

		/// <summary>
		/// 指定した容量を使用して、<see cref="WherePhraseBuilder"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="capacity">
		/// このインスタンスの初期容量。
		/// </param>
		public WherePhraseBuilder(int capacity)
		{
			wherePhrase = new StringBuilder(capacity);
		}

		/// <summary>
		/// 指定した条件を使って、<see cref="WherePhraseBuilder"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子。可能な値はEqual、GreaterThan、GreaterThanEqual、LessThan、LessThanEqual、およびNotEqualです。
		/// </param>
		/// <param name="expression">
		/// 比較対象とする文字列。
		/// </param>
		/// <remarks>
		/// <paramref name="expression"/>の値が空の文字列（""）の場合は検索条件を生成せずにインスタンスの参照を返します。
		/// </remarks>
		/// <exception cref="ArgumentNullException"><paramref name="expression"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		public WherePhraseBuilder(string columnName, SearchOperator op, string expression) : this()
		{
			if (expression == null)
			{
// 				throw new ArgumentNullException("expression", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("expression", MultiLanguage.Get("CM_AM001376"));
			}
			if (expression.Length != 0)
			{
				StringBuilder sb = new StringBuilder(expression);
				sb.Replace("\'", "\'\'");
				wherePhrase.Append(" WHERE ");
				wherePhrase.Append(columnName);
				switch (op)
				{
					case SearchOperator.Equal:
						wherePhrase.Append("=N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.GreaterThan:
						wherePhrase.Append(">N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.GreaterThanEqual:
						wherePhrase.Append(">=N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.LessThan:
						wherePhrase.Append("<N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.LessThanEqual:
						wherePhrase.Append("<=N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.NotEqual:
						wherePhrase.Append("<>N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.FrontCoincidence:
						wherePhrase.Append(" LIKE N\'");
						wherePhrase.Append(sb.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]"));
						wherePhrase.Append("%\'");
						break;
					case SearchOperator.BackCoincidence:
						wherePhrase.Append(" LIKE N\'%");
						wherePhrase.Append(sb.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]"));
						wherePhrase.Append("\'");
						break;
					case SearchOperator.PartialCoincidence:
						wherePhrase.Append(" LIKE N\'%");
						wherePhrase.Append(sb.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]"));
						wherePhrase.Append("%\'");
						break;
					default:
// 						throw new ArgumentException("SearchOperator にない値です。", "op"); //K24546
						throw new ArgumentException(MultiLanguage.Get("CM_AM000498"), "op");
				}
			}
		}

		/// <summary>
		/// 指定した条件を使って、<see cref="WherePhraseBuilder"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子。可能な値はEqual、GreaterThan、GreaterThanEqual、LessThan、LessThanEqual、およびNotEqualです。
		/// </param>
		/// <param name="expression">
		/// 比較対象とする数値。
		/// </param>
		public WherePhraseBuilder(string columnName, SearchOperator op, decimal expression) : this()
		{
			wherePhrase.Append(" WHERE ");
			wherePhrase.Append(columnName);
			switch (op)
			{
				case SearchOperator.Equal:
					wherePhrase.Append('=');
					wherePhrase.Append(expression);
					break;
				case SearchOperator.GreaterThan:
					wherePhrase.Append('>');
					wherePhrase.Append(expression);
					break;
				case SearchOperator.GreaterThanEqual:
					wherePhrase.Append(">=");
					wherePhrase.Append(expression);
					break;
				case SearchOperator.LessThan:
					wherePhrase.Append('<');
					wherePhrase.Append(expression);
					break;
				case SearchOperator.LessThanEqual:
					wherePhrase.Append("<=");
					wherePhrase.Append(expression);
					break;
				case SearchOperator.NotEqual:
					wherePhrase.Append("<>");
					wherePhrase.Append(expression);
					break;
				default:
// 					throw new ArgumentException("与えられた SearchOperator はこのメソッドに対応していません。", "op"); //K24546
					throw new ArgumentException(MultiLanguage.Get("CM_AM001419"), "op");
			}
		}

		/// <summary>
		/// 指定した条件を使って、<see cref="WherePhraseBuilder"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子。可能な値はEqual、GreaterThan、GreaterThanEqual、LessThan、LessThanEqual、およびNotEqualです。
		/// </param>
		/// <param name="expression">
		/// 比較対象とする日付。
		/// </param>
		public WherePhraseBuilder(string columnName, SearchOperator op, DateTime expression) : this(columnName, op, expression, DateTimeCompareType.Date)
		{
		}

		/// <summary>
		/// 指定した条件を使って、<see cref="WherePhraseBuilder"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子。可能な値はEqual、GreaterThan、GreaterThanEqual、LessThan、LessThanEqual、およびNotEqualです。
		/// </param>
		/// <param name="expression">
		/// 比較対象とする日付。
		/// </param>
		/// <param name="type">
		/// 日付の精度。
		/// </param>
		public WherePhraseBuilder(string columnName, SearchOperator op, DateTime expression, DateTimeCompareType type) : this()
		{
			wherePhrase.Append(" WHERE ");
			wherePhrase.Append(columnName);
			switch (op)
			{
				case SearchOperator.Equal:
					if (type == DateTimeCompareType.Time)
					{
						wherePhrase.Append('=');
						wherePhrase.Append(formatDateTime(expression, type));
					}
					else
					{
						wherePhrase.Append(">=");
						wherePhrase.Append(formatDateTime(expression, type));
						wherePhrase.Append(" AND ");
						wherePhrase.Append(columnName);
						wherePhrase.Append('<');
						wherePhrase.Append(formatNextDateTime(expression, type));
					}
					break;
				case SearchOperator.GreaterThan:
					if (type == DateTimeCompareType.Time)
					{
						wherePhrase.Append('>');
						wherePhrase.Append(formatDateTime(expression, type));
					}
					else
					{
						wherePhrase.Append(">=");
						wherePhrase.Append(formatNextDateTime(expression, type));
					}
					break;
				case SearchOperator.GreaterThanEqual:
					wherePhrase.Append(">=");
					wherePhrase.Append(formatDateTime(expression, type));
					break;
				case SearchOperator.LessThan:
					wherePhrase.Append("<");
					wherePhrase.Append(formatDateTime(expression, type));
					break;
				case SearchOperator.LessThanEqual:
					if (type == DateTimeCompareType.Time)
					{
						wherePhrase.Append("<=");
						wherePhrase.Append(formatDateTime(expression, type));
					}
					else
					{
						wherePhrase.Append('<');
						wherePhrase.Append(formatNextDateTime(expression, type));
					}
					break;
				default:
// 					throw new ArgumentException("与えられた SearchOperator はこのメソッドに対応していません。", "op"); //K24546
					throw new ArgumentException(MultiLanguage.Get("CM_AM001419"), "op");
			}
		}
		#endregion

		#region Public Methods
		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="searchCondition">
		/// WHERE句に追加する検索条件。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="searchCondition"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
// 管理番号K27230 From
//		public WherePhraseBuilder AddFilter(string searchCondition)
		public WherePhraseBuilder AddFilter(SqlPString searchCondition)
// 管理番号K27230 To
		{
			if (searchCondition == null)
			{
// 				throw new ArgumentNullException("searchCondition", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("searchCondition", MultiLanguage.Get("CM_AM001376"));
			}
			if (searchCondition.Length != 0)
			{
				if (wherePhrase.Length == 0)
				{
					wherePhrase.Append(" WHERE ");
				}
				else
				{
					wherePhrase.Append(" AND ");
				}
// 管理番号K27230 From
//				wherePhrase.Append(searchCondition);
				wherePhrase.Append(searchCondition.Sanitizing());
// 管理番号K27230 To
			}
			return this;
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする文字列。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		/// <remarks>
		/// <paramref name="expression"/>の値が空の文字列（""）の場合は検索条件を追加せずにインスタンスの参照を返します。
		/// </remarks>
		/// <exception cref="ArgumentNullException"><paramref name="expression"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
// 管理番号K27230 From
//		public WherePhraseBuilder AddFilter(string columnName, SearchOperator op, string expression)
		public WherePhraseBuilder AddFilter(SqlPString columnName, SearchOperator op, SqlPString expression)
// 管理番号K27230 To
		{
			if (expression == null)
			{
// 				throw new ArgumentNullException("expression", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("expression", MultiLanguage.Get("CM_AM001376"));
			}
			if (expression.Length != 0)
			{
// 管理番号K27230 From
//				StringBuilder sb = new StringBuilder(expression);
				StringBuilder sb = new StringBuilder(expression.ToBareString());
// 管理番号K27230 To
				sb.Replace("\'", "\'\'");
				if (wherePhrase.Length == 0)
				{
					wherePhrase.Append(" WHERE ");
				}
				else
				{
					wherePhrase.Append(" AND ");
				}
// 管理番号K27230 From
//				wherePhrase.Append(columnName);
				wherePhrase.Append(columnName.Sanitizing());
// 管理番号K27230 To
				switch (op)
				{
					case SearchOperator.Equal:
						wherePhrase.Append("=N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.GreaterThan:
						wherePhrase.Append(">N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.GreaterThanEqual:
						wherePhrase.Append(">=N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.LessThan:
						wherePhrase.Append("<N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.LessThanEqual:
						wherePhrase.Append("<=N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.NotEqual:
						wherePhrase.Append("<>N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.FrontCoincidence:
						wherePhrase.Append(" LIKE N\'");
						wherePhrase.Append(sb.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]"));
						wherePhrase.Append("%\'");
						break;
					case SearchOperator.BackCoincidence:
						wherePhrase.Append(" LIKE N\'%");
						wherePhrase.Append(sb.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]"));
						wherePhrase.Append("\'");
						break;
					case SearchOperator.PartialCoincidence:
						wherePhrase.Append(" LIKE N\'%");
						wherePhrase.Append(sb.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]"));
						wherePhrase.Append("%\'");
						break;
					default:
// 						throw new ArgumentException("SearchOperator にない値です。", "op"); //K24546
						throw new ArgumentException(MultiLanguage.Get("CM_AM000498"), "op");
				}
			}
			return this;
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする値の文字列形式。
		/// </param>
		/// <param name="dbType">
		/// <paramref name="expression"/>のデータ型。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		/// <remarks>
		/// <paramref name="expression"/>の値が<paramref name="dbType" />に変換できない場合や空の文字列（""）の場合は検索条件を追加せずにインスタンスの参照を返します。
		/// </remarks>
		/// <exception cref="ArgumentNullException"><paramref name="expression"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
// 管理番号K27230 From
//		public WherePhraseBuilder AddFilter(string columnName, SearchOperator op, string expression, SqlDbType dbType)
		public WherePhraseBuilder AddFilter(string columnName, SearchOperator op, SqlPString expression, SqlDbType dbType)
// 管理番号K27230 To
		{
			return AddFilter(columnName, op, expression, dbType, DateTimeCompareType.Date);
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする値の文字列形式。
		/// </param>
		/// <param name="dbType">
		/// <paramref name="expression"/>のデータ型。
		/// </param>
		/// <param name="type">
		/// 日付の精度。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		/// <remarks>
		/// <paramref name="expression"/>の値が<paramref name="dbType" />に変換できない場合や空の文字列（""）の場合は検索条件を追加せずにインスタンスの参照を返します。
		/// </remarks>
		/// <exception cref="ArgumentNullException"><paramref name="expression"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
// 管理番号K27230 From
//		public WherePhraseBuilder AddFilter(string columnName, SearchOperator op, string expression, SqlDbType dbType, DateTimeCompareType type)
		public WherePhraseBuilder AddFilter(string columnName, SearchOperator op, SqlPString expression, SqlDbType dbType, DateTimeCompareType type)
// 管理番号K27230 To
		{
			if (expression == null)
			{
// 				throw new ArgumentNullException("expression", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("expression", MultiLanguage.Get("CM_AM001376"));
			}
			switch (dbType)
			{
				case SqlDbType.NVarChar:
					return AddFilter(columnName, op, expression);
				case SqlDbType.Decimal:
					try
					{
// 管理番号K27230 From
//						return AddFilter(columnName, op, decimal.Parse(expression));
						return AddFilter(columnName, op, decimal.Parse(expression.ToBareString()));
// 管理番号K27230 To
					}
					catch (FormatException)
					{
						return this;
					}
				case SqlDbType.DateTime:
					try
					{
// 管理番号K27230 From
//						return AddFilter(columnName, op, DateTime.Parse(expression), type);
						return AddFilter(columnName, op, DateTime.Parse(expression.ToBareString()), type);
// 管理番号K27230 To
					}
					catch (FormatException)
					{
						return this;
					}
					catch (ArgumentOutOfRangeException)
					{
						return this;
					}
				default:
// 					throw new ArgumentException("与えられた SqlDbType はこのメソッドに対応していません。", "dbType"); //K24546
					throw new ArgumentException(MultiLanguage.Get("CM_AM001420"), "dbType");
			}
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする数値。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		public WherePhraseBuilder AddFilter(string columnName, SearchOperator op, decimal expression)
		{
			if (wherePhrase.Length == 0)
			{
				wherePhrase.Append(" WHERE ");
			}
			else
			{
				wherePhrase.Append(" AND ");
			}
			wherePhrase.Append(columnName);
			switch (op)
			{
				case SearchOperator.Equal:
					wherePhrase.Append('=');
					wherePhrase.Append(expression);
					break;
				case SearchOperator.GreaterThan:
					wherePhrase.Append('>');
					wherePhrase.Append(expression);
					break;
				case SearchOperator.GreaterThanEqual:
					wherePhrase.Append(">=");
					wherePhrase.Append(expression);
					break;
				case SearchOperator.LessThan:
					wherePhrase.Append('<');
					wherePhrase.Append(expression);
					break;
				case SearchOperator.LessThanEqual:
					wherePhrase.Append("<=");
					wherePhrase.Append(expression);
					break;
				case SearchOperator.NotEqual:
					wherePhrase.Append("<>");
					wherePhrase.Append(expression);
					break;
				default:
// 					throw new ArgumentException("与えられた SearchOperator はこのメソッドに対応していません。", "op"); //K24546
					throw new ArgumentException(MultiLanguage.Get("CM_AM001419"), "op");
			}
			return this;
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする論理値。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		public WherePhraseBuilder AddFilter(string columnName, SearchOperator op, bool expression)
		{
			return expression ? AddFilter(columnName, op, "1") : AddFilter(columnName, op, "0");
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする日付。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		/// <remarks>
		/// <paramref name="expression"/>で与えられた値の日付部分を基にした検索条件を追加します。<paramref name="expression"/>の時刻は反映されません。
		/// </remarks>
		public WherePhraseBuilder AddFilter(string columnName, SearchOperator op, DateTime expression)
		{
			return AddFilter(columnName, op, expression, DateTimeCompareType.Date);
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする日付。
		/// </param>
		/// <param name="type">
		/// 日付の精度。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		public WherePhraseBuilder AddFilter(string columnName, SearchOperator op, DateTime expression, DateTimeCompareType type)
		{
			if (wherePhrase.Length == 0)
			{
				wherePhrase.Append(" WHERE ");
			}
			else
			{
				wherePhrase.Append(" AND ");
			}
			wherePhrase.Append(columnName);
			switch (op)
			{
				case SearchOperator.Equal:
					if (type == DateTimeCompareType.Time)
					{
						wherePhrase.Append('=');
						wherePhrase.Append(formatDateTime(expression, type));
					}
					else
					{
						wherePhrase.Append(">=");
						wherePhrase.Append(formatDateTime(expression, type));
						wherePhrase.Append(" AND ");
						wherePhrase.Append(columnName);
						wherePhrase.Append('<');
						wherePhrase.Append(formatNextDateTime(expression, type));
					}
					break;
				case SearchOperator.GreaterThan:
					if (type == DateTimeCompareType.Time)
					{
						wherePhrase.Append('>');
						wherePhrase.Append(formatDateTime(expression, type));
					}
					else
					{
						wherePhrase.Append(">=");
						wherePhrase.Append(formatNextDateTime(expression, type));
					}
					break;
				case SearchOperator.GreaterThanEqual:
					wherePhrase.Append(">=");
					wherePhrase.Append(formatDateTime(expression, type));
					break;
				case SearchOperator.LessThan:
					wherePhrase.Append("<");
					wherePhrase.Append(formatDateTime(expression, type));
					break;
				case SearchOperator.LessThanEqual:
					if (type == DateTimeCompareType.Time)
					{
						wherePhrase.Append("<=");
						wherePhrase.Append(formatDateTime(expression, type));
					}
					else
					{
						wherePhrase.Append('<');
						wherePhrase.Append(formatNextDateTime(expression, type));
					}
					break;
				default:
// 					throw new ArgumentException("与えられた SearchOperator はこのメソッドに対応していません。", "op"); //K24546
					throw new ArgumentException(MultiLanguage.Get("CM_AM001419"), "op");
			}
			return this;
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// <see cref="System.DBNull"/>クラスのインスタンス。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		/// <remarks>
		/// <paramref name="op"/>が<see cref="SearchOperator.Equal"/>のときはNULL値の行を検索し、
		/// <see cref="SearchOperator.NotEqual"/>のときはNULL値でない行を検索します。
		/// </remarks>
		public WherePhraseBuilder AddFilter(string columnName, SearchOperator op, DBNull expression)
		{
			if (wherePhrase.Length == 0)
			{
				wherePhrase.Append(" WHERE ");
			}
			else
			{
				wherePhrase.Append(" AND ");
			}
			wherePhrase.Append(columnName);
			switch (op)
			{
				case SearchOperator.Equal:
					wherePhrase.Append(" IS NULL");
					break;
				case SearchOperator.NotEqual:
					wherePhrase.Append(" IS NOT NULL");
					break;
				default:
// 					throw new ArgumentException("与えられた SearchOperator はこのメソッドに対応していません。", "op"); //K24546
					throw new ArgumentException(MultiLanguage.Get("CM_AM001419"), "op");
			}
			return this;
		}

		/// <summary>
		/// 指定した文字列をWHERE句の末尾に追加します。
		/// </summary>
		/// <param name="value">
		/// WHERE句の末尾に追加する文字列。
		/// </param>
		/// <returns>
		/// 文字列を追加した後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
// 管理番号K27230 From
//		public WherePhraseBuilder Append(string value)
//		{
//			wherePhrase.Append(value);
		public WherePhraseBuilder Append(SqlPString value)
		{
			wherePhrase.Append(value.Sanitizing());
// 管理番号K27230 To
			return this;
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="connectionWord">
		/// 接続語
		/// </param>
		/// <param name="searchCondition">
		/// WHERE句に追加する検索条件。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		/// <exception cref="ArgumentNullException"><paramref name="searchCondition"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
		public WherePhraseBuilder AppendFilter(ConnectionWord connectionWord, string searchCondition)
		{
			if (searchCondition == null)
			{
// 				throw new ArgumentNullException("searchCondition", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("searchCondition", MultiLanguage.Get("CM_AM001376"));
			}
			if (searchCondition.Length != 0)
			{
				if (wherePhrase.Length == 0)
				{
					wherePhrase.Append(" WHERE ");
				}
				else
				{
					switch (connectionWord)
					{
						case ConnectionWord.None:
							wherePhrase.Append(' ');
							break;
						case ConnectionWord.And:
							wherePhrase.Append(" AND ");
							break;
						case ConnectionWord.Or:
							wherePhrase.Append(" OR ");
							break;
					}
				}
				wherePhrase.Append(searchCondition);
			}
			return this;
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="connectionWord">
		/// 接続語
		/// </param>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする文字列。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		/// <remarks>
		/// <paramref name="expression"/>の値が空の文字列（""）の場合は検索条件を追加せずにインスタンスの参照を返します。
		/// </remarks>
		/// <exception cref="ArgumentNullException"><paramref name="expression"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
// 管理番号K27230 From
//		public WherePhraseBuilder AppendFilter(ConnectionWord connectionWord, string columnName, SearchOperator op, string expression)
		public WherePhraseBuilder AppendFilter(ConnectionWord connectionWord, string columnName, SearchOperator op, SqlPString expression)
// 管理番号K27230 To
		{
			if (expression == null)
			{
// 				throw new ArgumentNullException("expression", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("expression", MultiLanguage.Get("CM_AM001376"));
			}
			if (expression.Length != 0)
			{
// 管理番号K27230 From
//				StringBuilder sb = new StringBuilder(expression);
				StringBuilder sb = new StringBuilder(expression.ToBareString());
// 管理番号K27230 To
				sb.Replace("\'", "\'\'");
				if (wherePhrase.Length == 0)
				{
					wherePhrase.Append(" WHERE ");
				}
				else
				{
					switch (connectionWord)
					{
						case ConnectionWord.None:
							wherePhrase.Append(' ');
							break;
						case ConnectionWord.And:
							wherePhrase.Append(" AND ");
							break;
						case ConnectionWord.Or:
							wherePhrase.Append(" OR ");
							break;
					}
				}
				wherePhrase.Append(columnName);
				switch (op)
				{
					case SearchOperator.Equal:
						wherePhrase.Append("=N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.GreaterThan:
						wherePhrase.Append(">N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.GreaterThanEqual:
						wherePhrase.Append(">=N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.LessThan:
						wherePhrase.Append("<N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.LessThanEqual:
						wherePhrase.Append("<=N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.NotEqual:
						wherePhrase.Append("<>N\'");
						wherePhrase.Append(sb);
						wherePhrase.Append('\'');
						break;
					case SearchOperator.FrontCoincidence:
						wherePhrase.Append(" LIKE N\'");
						wherePhrase.Append(sb.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]"));
						wherePhrase.Append("%\'");
						break;
					case SearchOperator.BackCoincidence:
						wherePhrase.Append(" LIKE N\'%");
						wherePhrase.Append(sb.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]"));
						wherePhrase.Append("\'");
						break;
					case SearchOperator.PartialCoincidence:
						wherePhrase.Append(" LIKE N\'%");
						wherePhrase.Append(sb.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]"));
						wherePhrase.Append("%\'");
						break;
					default:
// 						throw new ArgumentException("SearchOperator にない値です。", "op"); //K24546
						throw new ArgumentException(MultiLanguage.Get("CM_AM000498"), "op");
				}
			}
			return this;
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="connectionWord">
		/// 接続語
		/// </param>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする値の文字列形式。
		/// </param>
		/// <param name="dbType">
		/// <paramref name="expression"/>のデータ型。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		/// <remarks>
		/// <paramref name="expression"/>の値が<paramref name="dbType" />に変換できない場合や空の文字列（""）の場合は検索条件を追加せずにインスタンスの参照を返します。
		/// </remarks>
		/// <exception cref="ArgumentNullException"><paramref name="expression"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
// 管理番号K27230 From
//		public WherePhraseBuilder AppendFilter(ConnectionWord connectionWord, string columnName, SearchOperator op, string expression, SqlDbType dbType)
		public WherePhraseBuilder AppendFilter(ConnectionWord connectionWord, string columnName, SearchOperator op, SqlPString expression, SqlDbType dbType)
// 管理番号K27230 To
		{
			return AppendFilter(connectionWord, columnName, op, expression, dbType, DateTimeCompareType.Date);
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="connectionWord">
		/// 接続語
		/// </param>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする値の文字列形式。
		/// </param>
		/// <param name="dbType">
		/// <paramref name="expression"/>のデータ型。
		/// </param>
		/// <param name="type">
		/// 日付の精度。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		/// <remarks>
		/// <paramref name="expression"/>の値が<paramref name="dbType" />に変換できない場合や空の文字列（""）の場合は検索条件を追加せずにインスタンスの参照を返します。
		/// </remarks>
		/// <exception cref="ArgumentNullException"><paramref name="expression"/> が null 参照 (Visual Basic では <b>Nothing</b>) です。</exception>
// 管理番号K27230 From
//		public WherePhraseBuilder AppendFilter(ConnectionWord connectionWord, string columnName, SearchOperator op, string expression, SqlDbType dbType, DateTimeCompareType type)
		public WherePhraseBuilder AppendFilter(ConnectionWord connectionWord, string columnName, SearchOperator op, SqlPString expression, SqlDbType dbType, DateTimeCompareType type)
// 管理番号K27230 To
		{
			if (expression == null)
			{
// 				throw new ArgumentNullException("expression", "文字列参照が文字列のインスタンスに設定されていません。"); //K24546
				throw new ArgumentNullException("expression", MultiLanguage.Get("CM_AM001376"));
			}
			switch (dbType)
			{
				case SqlDbType.NVarChar:
					return AppendFilter(connectionWord, columnName, op, expression);
				case SqlDbType.Decimal:
					try
					{
// 管理番号K27230 From
//						return AppendFilter(connectionWord, columnName, op, decimal.Parse(expression));
						return AppendFilter(connectionWord, columnName, op, decimal.Parse(expression.ToBareString()));
// 管理番号K27230 To
					}
					catch (FormatException)
					{
						return this;
					}
				case SqlDbType.DateTime:
					try
					{
// 管理番号K27230 From
//						return AppendFilter(connectionWord, columnName, op, DateTime.Parse(expression), type);
						return AppendFilter(connectionWord, columnName, op, DateTime.Parse(expression.ToBareString()), type);
// 管理番号K27230 To
					}
					catch (FormatException)
					{
						return this;
					}
					catch (ArgumentOutOfRangeException)
					{
						return this;
					}
				default:
// 					throw new ArgumentException("与えられた SqlDbType はこのメソッドに対応していません。", "dbType"); //K24546
					throw new ArgumentException(MultiLanguage.Get("CM_AM001420"), "dbType");
			}
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="connectionWord">
		/// 接続語
		/// </param>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする数値。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		public WherePhraseBuilder AppendFilter(ConnectionWord connectionWord, string columnName, SearchOperator op, decimal expression)
		{
			if (wherePhrase.Length == 0)
			{
				wherePhrase.Append(" WHERE ");
			}
			else
			{
				switch (connectionWord)
				{
					case ConnectionWord.None:
						wherePhrase.Append(' ');
						break;
					case ConnectionWord.And:
						wherePhrase.Append(" AND ");
						break;
					case ConnectionWord.Or:
						wherePhrase.Append(" OR ");
						break;
				}
			}
			wherePhrase.Append(columnName);
			switch (op)
			{
				case SearchOperator.Equal:
					wherePhrase.Append('=');
					wherePhrase.Append(expression);
					break;
				case SearchOperator.GreaterThan:
					wherePhrase.Append('>');
					wherePhrase.Append(expression);
					break;
				case SearchOperator.GreaterThanEqual:
					wherePhrase.Append(">=");
					wherePhrase.Append(expression);
					break;
				case SearchOperator.LessThan:
					wherePhrase.Append('<');
					wherePhrase.Append(expression);
					break;
				case SearchOperator.LessThanEqual:
					wherePhrase.Append("<=");
					wherePhrase.Append(expression);
					break;
				case SearchOperator.NotEqual:
					wherePhrase.Append("<>");
					wherePhrase.Append(expression);
					break;
				default:
// 					throw new ArgumentException("与えられた SearchOperator はこのメソッドに対応していません。", "op"); //K24546
					throw new ArgumentException(MultiLanguage.Get("CM_AM001419"), "op");
			}
			return this;
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="connectionWord">
		/// 接続語
		/// </param>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする論理値。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		public WherePhraseBuilder AppendFilter(ConnectionWord connectionWord, string columnName, SearchOperator op, bool expression)
		{
			return expression ? AppendFilter(connectionWord, columnName, op, "1") : AppendFilter(connectionWord, columnName, op, "0");
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="connectionWord">
		/// 接続語
		/// </param>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする日付。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		/// <remarks>
		/// <paramref name="expression"/>で与えられた値の日付部分を基にした検索条件を追加します。<paramref name="expression"/>の時刻は反映されません。
		/// </remarks>
		public WherePhraseBuilder AppendFilter(ConnectionWord connectionWord, string columnName, SearchOperator op, DateTime expression)
		{
			return AppendFilter(connectionWord, columnName, op, expression, DateTimeCompareType.Date);
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="connectionWord">
		/// 接続語
		/// </param>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// 比較対象とする日付。
		/// </param>
		/// <param name="type">
		/// 日付の精度。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		public WherePhraseBuilder AppendFilter(ConnectionWord connectionWord, string columnName, SearchOperator op, DateTime expression, DateTimeCompareType type)
		{
			if (wherePhrase.Length == 0)
			{
				wherePhrase.Append(" WHERE ");
			}
			else
			{
				switch (connectionWord)
				{
					case ConnectionWord.None:
						wherePhrase.Append(' ');
						break;
					case ConnectionWord.And:
						wherePhrase.Append(" AND ");
						break;
					case ConnectionWord.Or:
						wherePhrase.Append(" OR ");
						break;
				}
			}
			wherePhrase.Append(columnName);
			switch (op)
			{
				case SearchOperator.Equal:
					if (type == DateTimeCompareType.Time)
					{
						wherePhrase.Append('=');
						wherePhrase.Append(formatDateTime(expression, type));
					}
					else
					{
						wherePhrase.Append(">=");
						wherePhrase.Append(formatDateTime(expression, type));
						wherePhrase.Append(" AND ");
						wherePhrase.Append(columnName);
						wherePhrase.Append('<');
						wherePhrase.Append(formatNextDateTime(expression, type));
					}
					break;
				case SearchOperator.GreaterThan:
					if (type == DateTimeCompareType.Time)
					{
						wherePhrase.Append('>');
						wherePhrase.Append(formatDateTime(expression, type));
					}
					else
					{
						wherePhrase.Append(">=");
						wherePhrase.Append(formatNextDateTime(expression, type));
					}
					break;
				case SearchOperator.GreaterThanEqual:
					wherePhrase.Append(">=");
					wherePhrase.Append(formatDateTime(expression, type));
					break;
				case SearchOperator.LessThan:
					wherePhrase.Append('<');
					wherePhrase.Append(formatDateTime(expression, type));
					break;
				case SearchOperator.LessThanEqual:
					if (type == DateTimeCompareType.Time)
					{
						wherePhrase.Append("<=");
						wherePhrase.Append(formatDateTime(expression, type));
					}
					else
					{
						wherePhrase.Append('<');
						wherePhrase.Append(formatNextDateTime(expression, type));
					}
					break;
				default:
// 					throw new ArgumentException("与えられた SearchOperator はこのメソッドに対応していません。", "op"); //K24546
					throw new ArgumentException(MultiLanguage.Get("CM_AM001419"), "op");
			}
			return this;
		}

		/// <summary>
		/// 検索条件をWHERE句に追加します。
		/// </summary>
		/// <param name="connectionWord">
		/// 接続語
		/// </param>
		/// <param name="columnName">
		/// データベースの列名。[テーブル名].[列名]の形式で記述することも可能です。
		/// </param>
		/// <param name="op">
		/// 比較演算子
		/// </param>
		/// <param name="expression">
		/// <see cref="System.DBNull"/>クラスのインスタンス。
		/// </param>
		/// <returns>
		/// 検索条件登録後の<see cref="WherePhraseBuilder"/>。
		/// </returns>
		/// <remarks>
		/// <paramref name="op"/>が<see cref="SearchOperator.Equal"/>のときはNULL値の行を検索し、
		/// <see cref="SearchOperator.NotEqual"/>のときはNULL値でない行を検索します。
		/// </remarks>
		public WherePhraseBuilder AppendFilter(ConnectionWord connectionWord, string columnName, SearchOperator op, DBNull expression)
		{
			if (wherePhrase.Length == 0)
			{
				wherePhrase.Append(" WHERE ");
			}
			else
			{
				switch (connectionWord)
				{
					case ConnectionWord.None:
						wherePhrase.Append(' ');
						break;
					case ConnectionWord.And:
						wherePhrase.Append(" AND ");
						break;
					case ConnectionWord.Or:
						wherePhrase.Append(" OR ");
						break;
				}
			}
			wherePhrase.Append(columnName);
			switch (op)
			{
				case SearchOperator.Equal:
					wherePhrase.Append(" IS NULL");
					break;
				case SearchOperator.NotEqual:
					wherePhrase.Append(" IS NOT NULL");
					break;
				default:
// 					throw new ArgumentException("与えられた SearchOperator はこのメソッドに対応していません。", "op"); //K24546
					throw new ArgumentException(MultiLanguage.Get("CM_AM001419"), "op");
			}
			return this;
		}
		#endregion

		#region Override Methods
		/// <summary>
		/// 対象のインスタンスが、指定したオブジェクトに等しいかどうかを返します。大文字小文字の違いは無視されます。
		/// </summary>
		/// <param name="wpb">
		/// このインスタンスと比較するオブジェクト、またはnull。
		/// </param>
		/// <returns>
		/// このインスタンスと<paramref name="wpb"/>が同じ文字列を保持している場合：true、それ以外の場合：false
		/// </returns>
		public bool Equals(WherePhraseBuilder wpb)
		{
			return (wpb != null) ? (string.Compare(ToString(), wpb.ToString(), true) == 0) : false;
		}

		/// <summary>
		/// 登録された条件を基にWHERE句を生成します。
		/// </summary>
		/// <returns>
		/// 登録された検索条件を基に生成されたWHERE句。
		/// </returns>
		public override string ToString()
		{
			return wherePhrase.ToString();
		}
		#endregion

		#region Private Methods
		private string formatDateTime(DateTime value, DateTimeCompareType type)
		{
			switch (type)
			{
				case DateTimeCompareType.Time:
					return new StringBuilder("CONVERT(DATETIME, \'", 48).Append(value.ToString("yyyy-MM-dd HH:mm:ss.fff")).Append("\', 21)").ToString();
				case DateTimeCompareType.Date:
					return new StringBuilder("\'", 10).Append(value.ToString("yyyyMMdd")).Append('\'').ToString();
				case DateTimeCompareType.Month:
					return new StringBuilder("\'", 12).Append(value.ToString(@"yyyyMM\0\1")).Append('\'').ToString();
				default:
// 					throw new ArgumentException("SearchOperator にない値です。", "op"); //K24546
					throw new ArgumentException(MultiLanguage.Get("CM_AM000498"), "op");
			}
		}
		private string formatNextDateTime(DateTime value, DateTimeCompareType type)
		{
			switch (type)
			{
				case DateTimeCompareType.Time:
					return formatDateTime(value, type);
				case DateTimeCompareType.Date:
					return formatDateTime(value.AddDays(1), type);
				case DateTimeCompareType.Month:
					return formatDateTime(value.AddMonths(1), type);
				default:
// 					throw new ArgumentException("SearchOperator にない値です。", "op"); //K24546
					throw new ArgumentException(MultiLanguage.Get("CM_AM000498"), "op");
			}
		}
		#endregion
	}

	/// <summary>
	/// 日付の比較を行う際の精度の種類。
	/// </summary>
	public enum DateTimeCompareType
	{
		/// <summary>
		/// 年月日、時刻（ミリ秒）を対象とした比較。
		/// </summary>
		Time,
		/// <summary>
		/// 年月日を対象とした比較。
		/// </summary>
		Date,
		/// <summary>
		/// 年月を対象とした比較。
		/// </summary>
		Month
	}

	/// <summary>
	/// WHERE句に使用する接続語。
	/// </summary>
	public enum ConnectionWord
	{
		/// <summary>
		/// 付加しない。
		/// </summary>
		None,
		/// <summary>
		/// AND
		/// </summary>
		And,
		/// <summary>
		/// OR
		/// </summary>
		Or
	}
}
