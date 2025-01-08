// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : SqlString.cs
// 機能名      : SQLステートメント構築用文字列
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 管理番号K27230 2021/07/28 脆弱性対応
// 3.2.0 2023/03/31

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Infocom.Allegro.BL.SqlClient
{
	/// <summary>
	/// SQLクエリ作成用のクラス
	/// </summary>
	public class SqlPString
	{
		#region field
		/// <summary>
		/// 内部文字列要素
		/// </summary>
		internal List<(string, Type)> parts = new List<(string, Type)>();
		#endregion

		#region property
		/// <summary>
		/// 文字列としての長さ
		/// </summary>
		public int Length
		{
			get
			{
				return ((string)this).Length;
			}
		}
		#endregion

		#region operator
		/// <summary>
		/// <see cref="SqlPString"/>から<see cref="string"/>への変換
		/// </summary>
		/// <param name="ps">変換対象</param>
		/// <returns><see cref="SqlPString"/>を<see cref="string"/>に変換した結果</returns>
		public static explicit operator string(SqlPString ps)
		{
			switch (ps)
			{
				case null:
					return null;
				default:
					StringBuilder sb = new StringBuilder();
					ps.parts.ForEach(p =>
					{
						sb.Append(p.Item2 == typeof(string) ? p.Item1 : p.Item1.Replace("'", "''"));
					});
					return sb.ToString();
			}
		}

		/// <summary>
		/// <see cref="string"/>から<see cref="SqlPString"/>への暗黙変換
		/// </summary>
		/// <param name="s">変換対象</param>
		/// <returns><see cref="string"/>を<see cref="SqlPString"/>に変換した結果</returns>
		public static implicit operator SqlPString(string s)
		{
			switch (s)
			{
				case null:
					return null;
				default:
					SqlPString ps = new SqlPString();
					if (s.Length > 0)
					{
						ps.parts.Add((s, typeof(string)));
					}
					return ps;
			}
		}

		/// <summary>
		/// <see cref="SqlPString"/>と<see cref="SqlPString"/>の結合
		/// </summary>
		/// <param name="ps1">結合対象1</param>
		/// <param name="ps2">変換対象2</param>
		/// <returns>結合結果となる新しい<see cref="SqlPString"/></returns>
		public static SqlPString operator +(SqlPString ps1, SqlPString ps2)
		{
			if (ps1 is null)
			{
				ps1 = new SqlPString();
			}
			if (ps2 is null)
			{
				ps2 = new SqlPString();
			}

			var ps1Copy = new SqlPString();
			var ps2Copy = new SqlPString();
			ps1Copy.parts.AddRange(ps1.parts);
			ps2Copy.parts.AddRange(ps2.parts);

			SqlPString ps0 = new SqlPString();

			if (ps1Copy.parts.Count > 0 && ps2Copy.parts.Count > 0
				&& ps1Copy.parts.Last().Item2 == typeof(string) && ps2Copy.parts.First().Item2 == typeof(string))
			{
				string s = ps1Copy.parts.Last().Item1 + ps2Copy.parts.First().Item1;
				ps1Copy.parts.RemoveAt(ps1Copy.parts.Count - 1);
				ps2Copy.parts.RemoveAt(0);
				ps1Copy.parts.Add((s, typeof(string)));
			}

			ps0.parts.AddRange(ps1Copy.parts);
			ps0.parts.AddRange(ps2Copy.parts);

			return ps0;
		}

		/// <summary>
		/// <see cref="decimal"/>と<see cref="SqlPString"/>の結合
		/// </summary>
		/// <param name="n">結合対象1</param>
		/// <param name="ps">変換対象2</param>
		/// <returns>結合結果となる新しい<see cref="SqlPString"/></returns>
		public static SqlPString operator +(decimal n, SqlPString ps)
		{
			// stringは暗黙変換され、SqlPString + SqlPStringの結合になる
			return n.ToString() + ps;
		}

		/// <summary>
		/// <see cref="SqlPString"/>と<see cref="decimal"/>の結合
		/// </summary>
		/// <param name="ps">変換対象2</param>
		/// <param name="n">結合対象1</param>
		/// <returns>結合結果となる新しい<see cref="SqlPString"/></returns>
		public static SqlPString operator +(SqlPString ps, decimal n)
		{
			// stringは暗黙変換され、SqlPString + SqlPStringの結合になる
			return ps + n.ToString();
		}

		/// <summary>
		/// <see cref="DateTime"/>と<see cref="SqlPString"/>の結合
		/// </summary>
		/// <param name="dt">変換対象2</param>
		/// <param name="ps">結合対象1</param>
		/// <returns>結合結果となる新しい<see cref="SqlPString"/></returns>
		public static SqlPString operator +(DateTime dt, SqlPString ps)
		{
			// stringは暗黙変換され、SqlPString + SqlPStringの結合になる
			return dt.ToString() + ps;
		}

		/// <summary>
		/// <see cref="SqlPString"/>と<see cref="DateTime"/>の結合
		/// </summary>
		/// <param name="ps">結合対象1</param>
		/// <param name="dt">変換対象2</param>
		/// <returns>結合結果となる新しい<see cref="SqlPString"/></returns>
		public static SqlPString operator +(SqlPString ps, DateTime dt)
		{
			// stringは暗黙変換され、SqlPString + SqlPStringの結合になる
			return ps + dt.ToString();
		}

		/// <summary>
		/// <see cref="SqlPString"/>と<see cref="string"/>の値が同じ文字列であるかどうかを判定
		/// </summary>
		/// <param name="ps">比較対象1</param>
		/// <param name="s">比較対象2</param>
		/// <returns>同じ場合は true。それ以外の場合は false。</returns>
		public static bool operator ==(SqlPString ps, string s)
		{
			return s == (ps is null ? null : (string)ps);
		}

		/// <summary>
		/// <see cref="SqlPString"/>と<see cref="string"/>の値が異なる文字列であるかどうかを判定
		/// </summary>
		/// <param name="ps">比較対象1</param>
		/// <param name="s">比較対象2</param>
		/// <returns>異なる場合は true。それ以外の場合は false。</returns>
		public static bool operator !=(SqlPString ps, string s)
		{
			return s != (ps is null ? null : (string)ps);
		}
		#endregion

		#region method
		/// <summary>
		/// 指定された文字列の書式項目を、指定した<see cref="SqlPString"/>をサニタイジングされた文字列で置換
		/// </summary>
		/// <param name="format">
		/// 書式文字列
		/// </param>
		/// <param name="args">
		/// パラメータ
		/// </param>
		/// <returns>
		/// 文字列表記に置換された新しい文字列
		/// </returns>
		/// <seealso cref="string.Format(string, object[])"/>
		public static string Format(string format, params SqlPString[] args)
		{
			List<string> sanitizedArgs = new List<string>();

			foreach (SqlPString arg in args)
			{
				sanitizedArgs.Add(arg.Sanitizing());
			}

			return string.Format(format, sanitizedArgs.ToArray());
		}

		/// <summary>
		/// この文字列のハッシュ コードを返します。
		/// </summary>
		/// <returns>
		/// ハッシュ コード
		/// </returns>
		public override int GetHashCode()
		{
			return ((string)this).GetHashCode();
		}

		/// <summary>
		/// この<see cref="SqlPString"/>と<paramref name="o"/>が同じ文字列であるかどうかを判定
		/// </summary>
		/// <param name="o">
		/// 比較対象
		/// </param>
		/// <returns>
		/// 同じ場合は true。それ以外の場合は false。
		/// </returns>
		public override bool Equals(object o)
		{
			return (string)this == o?.ToString();
		}

		/// <summary>
		/// 部分文字列を置換
		/// </summary>
		/// <param name="oldValue">
		/// 置換前の部分文字列
		/// </param>
		/// <param name="newValue">
		/// 置換後の部分文字列
		/// </param>
		/// <returns>
		/// 置換が行われた新しい<see cref="SqlPString"/>
		/// </returns>
		/// <seealso cref="string.Replace(string, string)"/>
		public SqlPString Replace(string oldValue, string newValue)
		{
			// 引数がnullだった場合の挙動をstring.Replaceと同じにする
			if (oldValue == null)
			{
				throw new ArgumentNullException();
			}
			// 引数が""だった場合の挙動をstring.Replaceと同じにする
			if (oldValue == string.Empty)
			{
				throw new ArgumentException();
			}

			SqlPString result = new SqlPString();

			// Replaceを行った各要素を登録
			this.parts.ForEach(p =>
			{
				string replaced = p.Item1.Replace(oldValue, newValue);
				if (replaced.Length > 0 || p.Item2 != typeof(string))
				{
					result.parts.Add((replaced, p.Item2));
				}
			});

			return result;
		}

		/// <summary>
		/// この<seealso cref="SqlPString"/>の最初の要素が通常の文字列だった場合、その文字列の先頭から指定された文字セットをすべて削除
		/// </summary>
		/// <param name="trimChars">
		/// 削除する文字の配列
		/// </param>
		/// <returns>
		/// 残った文字列
		/// </returns>
		/// <seealso cref="string.TrimStart(char[])"/>
		public SqlPString TrimStart(params char[] trimChars)
		{
			var thisCopy = new SqlPString();
			thisCopy.parts.AddRange(this.parts);

			if (thisCopy.parts.Count > 0 && thisCopy.parts.First().Item2 == typeof(string))
			{
				// 最初の要素がstringならばTrimしたものに入れ替える
				string trimmedFirstPart = thisCopy.parts.First().Item1.TrimStart(trimChars);
				thisCopy.parts.RemoveAt(0);
				if (trimmedFirstPart.Length > 0)
				{
					thisCopy.parts.Insert(0, (trimmedFirstPart, typeof(string)));
				}
			}

			return thisCopy;
		}

		/// <summary>
		/// この<seealso cref="SqlPString"/>の最後の要素が通常の文字列だった場合、文字列の末尾から指定された文字セットをすべて削除
		/// </summary>
		/// <param name="trimChars">
		/// 削除する文字の配列
		/// </param>
		/// <returns>
		/// 残った文字列
		/// </returns>
		/// <seealso cref="string.TrimEnd(char[])"/>
		public SqlPString TrimEnd(params char[] trimChars)
		{
			var thisCopy = new SqlPString();
			thisCopy.parts.AddRange(this.parts);

			if (thisCopy.parts.Count > 0 && thisCopy.parts.Last().Item2 == typeof(string))
			{
				// 最後の要素がstringならばTrimしたものに入れ替える
				string trimmedLastPart = thisCopy.parts.Last().Item1.TrimEnd(trimChars);
				thisCopy.parts.RemoveAt(thisCopy.parts.Count - 1);
				if (trimmedLastPart.Length > 0)
				{
					thisCopy.parts.Add((trimmedLastPart, typeof(string)));
				}
			}

			return thisCopy;
		}

		/// <summary>
		/// この<see cref="SqlPString"/>をサニタイジングした文字列を返す
		/// </summary>
		/// <returns>
		/// サニタイジングされた文字列
		/// </returns>
		public override string ToString()
		{
			return this.Sanitizing();
		}
		#endregion
	}

	#region SqlPStringに関連する拡張メソッド
	/// <summary>
	/// <see cref="SqlPString"/>に対する拡張メソッド
	/// </summary>
	public static class SqlPStringExtensions
	{
		#region method
		/// <summary>
		/// ParamStringへの変換
		/// </summary>
		/// <param name="o">
		/// 元の文字列を表すobject
		/// </param>
		/// <returns>
		/// ParamStringに変換された値
		/// </returns>
		/// <remarks>
		/// このメソッドは<c><paramref name="o"/>.ToString()</c>した後<see cref="ParamString"/>にキャストする事と等価です
		/// </remarks>
		//戻り値がobjectであるConvertDBData.ToNVarCharをAppendしている箇所への対策
		public static ParamString ToParamString(this object o)
		{
			return (ParamString)(o is null ? "" : o.ToString());
		}

		/// <summary>
		/// <see cref="SqlPString"/>をParamStringへの変換
		/// </summary>
		/// <param name="ps">
		/// 元の文字列を表すSqlPString
		/// </param>
		/// <returns>
		/// ParamStringに変換された値
		/// </returns>
		/// <remarks>
		/// このメソッドは<c><paramref name="ps"/>.ToBareString()</c>した後<see cref="ParamString"/>にキャストする事と等価です
		/// </remarks>
		//親クラスからの変換
		public static ParamString ToParamString(this SqlPString ps)
		{
			return (ParamString)(ps is null ? "" : ps.ToBareString());
		}

		/// <summary>
		/// ParamNoStringへの変換
		/// </summary>
		/// <param name="o">
		/// 元の文字列を表すobject
		/// </param>
		/// <returns>
		/// ParamNoStringに変換された値
		/// </returns>
		/// <remarks>
		/// このメソッドは<c><paramref name="o"/>.ToString()</c>した後<see cref="ParamNoString"/>にキャストする事と等価です
		/// </remarks>
		//戻り値がobjectであるConvertDBData.ToNVarCharをAppendしている箇所への対策
		public static ParamNoString ToParamNoString(this object o)
		{
			return (ParamNoString)(o is null ? "" : o.ToString());
		}

		/// <summary>
		/// サニタイズした文字列を返す
		/// </summary>
		/// <param name="ps">
		/// 元のクエリ文字列を表すSqlPString
		/// </param>
		/// <returns>
		/// サニタイズにより変換された文字列
		/// </returns>
		public static string Sanitizing(this SqlPString ps)
		{
			if (ps is null)
			{
				return null;
			}

			StringBuilder sanitizedString = new StringBuilder();

			ps.parts.ForEach(p =>
			{
				// 要素の型に応じて適切な変換を行う
				if (p.Item2 == typeof(string))
				{
					// 変換なし
					sanitizedString.Append(p.Item1);
				}
				else if (p.Item2 == typeof(ParamString))
				{
					// シングルクオートを２重化
					sanitizedString.Append(p.Item1.Replace("'", "''"));
				}
				else if (p.Item2 == typeof(ParamNumericString))
				{
					// 数値に変換可能であることを確認、文字列nullは除外
					if (p.Item1.Trim().ToLower() == "null" || decimal.TryParse(p.Item1, out _))
					{
						sanitizedString.Append(p.Item1);
					}
					else
					{
						throw new Exception("SQLクエリのパラメータが不正です。");
					}
				}
				else if (p.Item2 == typeof(ParamNoString))
				{
					// 数値に変換可能であることを確認、文字列nullは除外
					if (p.Item1.Trim().ToLower() == "null" || decimal.TryParse(p.Item1, out _))
					{
						sanitizedString.Append(p.Item1);
					}
					else
					{
						throw new Exception("SQLクエリのパラメータが不正です。");
					}
				}
				else
				{
					sanitizedString.Append("'");
					sanitizedString.Append(p.Item1.Replace("'", "''"));
					sanitizedString.Append("'");
				}
			});

			return sanitizedString.ToString();
		}

		/// <summary>
		/// この<see cref="SqlPString"/>に保持される各要素を加工せずに結合した文字列を返します。
		/// </summary>
		/// <param name="ps">
		/// 元のクエリ文字列を表す<see cref="SqlPString"/>
		/// </param>
		/// <returns>
		/// 加工なしでstringに変換した文字列
		/// </returns>
		public static string ToBareString(this SqlPString ps)
		{
			if (ps is null)
			{
				return null;
			}

			// 要素を取り出してそのまま結合
			StringBuilder sb = new StringBuilder();
			ps.parts.ForEach(p =>
			{
				sb.Append(p.Item1);
			});

			return sb.ToString();
		}
		#endregion
	}
	#endregion

	#region SQL用パラメータクラス
	/// <summary>
	/// パラメータ保持用のクラス(シングルクオートで囲む文字列)
	/// </summary>
	public class ParamString : SqlPString
	{
		#region operator
		/// <summary>
		/// <see cref="string"/>から<see cref="ParamString"/>への変換
		/// <example>
		/// シングルクオートで囲む必要がある変数をSQLに組み込む場合
		/// <code>
		/// string deptCode = "d1";
		/// sb.Append("N'" + (ParamString)deptCode + "'");
		/// </code>
		/// </example>
		/// </summary>
		/// <param name="s">文字列</param>
		/// <returns>SQL文に組み込むための文字列</returns>
		public static explicit operator ParamString(string s)
		{
			ParamString ps = new ParamString();
			ps.parts.Add((ConvertDBData.ToNVarCharForEmpty(s), typeof(ParamString)));

			return ps;
		}
		#endregion

		#region method
		/// <summary>
		/// 指定された区切り文字を使用して、stringの配列をパラメータとして結合
		/// </summary>
		/// <param name="separator">
		/// 区切り文字
		/// </param>
		/// <param name="item">
		/// パラメータとなる文字列の配列
		/// </param>
		/// <returns>
		/// 結合された新しい<see cref="SqlPString"/>
		/// </returns>
		/// <seealso cref="string.Join(string, string[])"/>
		public static SqlPString Join(string separator, string[] item)
		{
			SqlPString ps = new SqlPString();

			if (item.Length > 0)
			{
				for (int i = 0; i < item.Length - 1; i++)
				{
					ps.parts.Add((ConvertDBData.ToNVarCharForEmpty(item[i]), typeof(ParamString)));
					if (separator is object && separator.Length > 0)
					{
						ps.parts.Add((separator, typeof(string)));
					}
				}
				ps.parts.Add((ConvertDBData.ToNVarCharForEmpty(item[item.Length - 1]), typeof(ParamString)));
			}

			return ps;
		}
		#endregion
	}

	/// <summary>
	/// パラメータ保持用のクラス(シングルクオートで囲まない数値をnvarcharの項目に対応させる場合)
	/// </summary>
	public class ParamNumericString : SqlPString
	{
		#region operator
		/// <summary>
		/// <para>
		/// <see cref="string"/>から<see cref="ParamNumericString"/>への変換
		/// </para>
		/// <example>
		/// 数字のみで構成され、シングルクオートで囲む必要がない変数をnvarchar項目に対応させてSQLに組み込む場合
		/// <code>
		/// string year = "2020";
		/// sb.Append("[YEAR] = " + (ParamNumericString)year + " AND ");
		/// </code>
		/// </example>
		/// </summary>
		/// <param name="s">文字列</param>
		/// <returns>SQL文に組み込むための文字列</returns>
		public static explicit operator ParamNumericString(string s)
		{
			ParamNumericString ps = new ParamNumericString();
			ps.parts.Add((ConvertDBData.ToNVarCharForEmpty(s), typeof(ParamNumericString)));

			return ps;
		}
		#endregion
	}

	/// <summary>
	/// パラメータ保持用のクラス(シングルクオートで囲まない数値をdecimalの項目に対応させる場合)
	/// </summary>
	public class ParamNoString : SqlPString
	{
		#region operator
		/// <summary>
		/// <para>
		/// <see cref="string"/>から<see cref="ParamNoString"/>への変換
		/// </para>
		/// <example>
		/// 数字のみで構成され、シングルクオートで囲む必要がない変数をdecimal項目に対応させてSQLに組み込む場合
		/// <code>
		/// string amt = "100";
		/// sb.Append("[AMT] = " + (ParamNoString)amt + " AND ");
		/// </code>
		/// </example>
		/// </summary>
		/// <param name="s">文字列</param>
		/// <returns>SQL文に組み込むための文字列</returns>
		public static explicit operator ParamNoString(string s)
		{
			ParamNoString ps = new ParamNoString();
			ps.parts.Add((ConvertDBData.ToNVarCharForEmpty(s), typeof(ParamNoString)));

			return ps;
		}
		#endregion
	}

	/// <summary>
	/// パラメータ保持用のクラス(シングルクオートで囲むLIKE条件)
	/// </summary>
	public class ParamLikeString : SqlPString
	{
		#region operator
		/// <summary>
		/// <para>
		/// <see cref="string"/>から<see cref="ParamLikeString"/>への変換
		/// </para>
		/// <example>
		/// シングルクオートで囲む必要がある変数をLIKE条件としてSQLに組み込む場合
		/// <code>
		/// string empNameFrom = "ABC";
		/// sb.Append("[EMP_NAME] LIKE N'" + (ParamLikeString)empNameFrom + "%'");
		/// </code>
		/// </example>
		/// </summary>
		/// <param name="s">文字列</param>
		/// <returns>SQL文に組み込むための文字列</returns>
		public static explicit operator ParamLikeString(string s)
		{
			ParamLikeString ps = new ParamLikeString();
			// エスケープ済みとなるためstring型として追加
			ps.parts.Add((ConvertDBData.ToNVarCharForEmpty(s.LikeEscape().Replace("'", "''")), typeof(string)));

			return ps;
		}
		#endregion
	}

	/// <summary>
	/// パラメータ保持用のクラス(各項目がシングルクオートで囲まれ、カンマで区切りとなっている文字列)
	/// </summary>
	public class ParamStringSplit : SqlPString
	{
		#region operator
		/// <summary>
		/// <para>
		/// <see cref="string"/>から<see cref="ParamStringSplit"/>への変換
		/// </para>
		/// <example>
		/// 文字列のIN句全体（各要素がシングルクオートで囲まれ、カンマ区切りとなっている文字列）をSQLに組み込む場合
		/// <code>
		/// string slipNo = "N'S000000001', N'S000000002', N'S000000003'";
		/// sb.Append(" IN (" + (ParamStringSplit)slipNo + ")");
		/// </code>
		/// </example>
		/// </summary>
		/// <param name="s">文字列</param>
		/// <returns>SQL文に組み込むための文字列</returns>
		public static explicit operator ParamStringSplit(string s)
		{
			ParamStringSplit ps = new ParamStringSplit();
			bool inParam = false;
			StringBuilder sb = new StringBuilder();

			if (s is object)
			{
				for (int i = 0; i < s.Length; i++)
				{
					if (!inParam)
					{
						if (s[i] == ' ' || s[i] == '\t' || s[i] == ',')
						{
						}
						else if ((i < s.Length - 1 && s[i] == 'N' && s[i + 1] == '\'' && ++i > 0) || s[i] == '\'')
						{
							inParam = true;
							string nPrefix = (i > 0 && s[i - 1] == 'N') ? "N" : "";

							if (ps.parts.Count > 0)
							{
								// パラメータとパラメータの区切り部（閉じシングルクオート + カンマ + 開始シングルクオート）
								ps.parts.RemoveAt(ps.parts.Count - 1);
								// リテラルなのでstring型として追加
								ps.parts.Add(("', " + nPrefix + "'", typeof(string)));
							}
							else
							{
								// 最初のパラメータの開始部
								// リテラルなのでstring型として追加
								ps.parts.Add((nPrefix + "'", typeof(string)));
							}
						}
						else
						{
							throw new Exception("SQLクエリのカンマ区切りの文字列パラメータが不正です。");
						}
					}
					else
					{
						if (i < s.Length - 1 && s[i] == '\'' && s[i + 1] == '\'' && ++i > 0)
						{
							sb.Append("'");
						}
						else if (s[i] == '\'')
						{
							inParam = false;

							ps.parts.Add((sb.ToString(), typeof(ParamString)));
							ps.parts.Add(("'", typeof(string)));
							sb.Length = 0;
						}
						else
						{
							sb.Append(s[i]);
						}
					}
				}

				if (inParam)
				{
					throw new Exception("SQLクエリのカンマ区切りの文字列パラメータが不正です。");
				}
			}

			return ps;
		}
		#endregion
	}

	/// <summary>
	/// パラメータ保持用のクラス(各項目がシングルクオートで囲まれず、カンマで区切りとなっている数値)
	/// </summary>
	public class ParamNoStringSplit : SqlPString
	{
		#region operator
		/// <summary>
		/// <para>
		/// <see cref="string"/>から<see cref="ParamNoStringSplit"/>への変換
		/// </para>
		/// <example>
		/// 数値のIN句全体（各要素がシングルクオートで囲まれず、カンマ区切りとなっている数値）をSQLに組み込む場合
		/// <code>
		/// string id = "1, 2, 3";
		/// sb.Append(" IN (" + (ParamNoStringSplit)id + ")");
		/// </code>
		/// </example>
		/// </summary>
		/// <param name="s">文字列</param>
		/// <returns>SQL文に組み込むための文字列</returns>
		public static explicit operator ParamNoStringSplit(string s)
		{
			ParamNoStringSplit ps = new ParamNoStringSplit();
			bool inParam = true;
			StringBuilder sb = new StringBuilder();

			if (s is object)
			{
				for (int i = 0; i < s.Length; i++)
				{
					if (!inParam)
					{
						if (s[i] == ' ' || s[i] == '\t')
						{
						}
						else if (s[i] == ',')
						{
							inParam = true;
						}
						else
						{
							throw new Exception("SQLクエリのカンマ区切りの数値文字列パラメータが不正です。");
						}
					}
					else if (s[i] == ' ' || s[i] == '\t' || s[i] == ',')
					{
						if (sb.Length > 0)
						{
							if (ps.parts.Count > 0)
							{
								ps.parts.Add((", ", typeof(string)));
							}

							ps.parts.Add((sb.ToString(), typeof(ParamNoString)));
							sb.Length = 0;

							if (s[i] != ',')
							{
								inParam = false;
							}
						}
					}
					else
					{
						sb.Append(s[i]);
					}
				}

				if (sb.Length > 0)
				{
					if (ps.parts.Count > 0)
					{
						ps.parts.Add((", ", typeof(string)));
					}

					ps.parts.Add((sb.ToString(), typeof(ParamNoString)));
				}
			}

			return ps;
		}
		#endregion
	}
	#endregion

	/// <summary>
	/// SQL文構築用クラス
	/// </summary>
	/// <seealso cref="StringBuilder"/>
	public class RealSqlBuilder
	{
		#region field
		/// <summary>
		/// 内部文字列要素
		/// </summary>
		internal List<(string, Type)> parts = new List<(string, Type)>();
		#endregion

		#region constructor
		/// <summary>
		/// <see cref="RealSqlBuilder"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <seealso cref="StringBuilder()"/>
		public RealSqlBuilder()
		{
		}

		/// <summary>
		/// <see cref="RealSqlBuilder"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="item">
		/// 初期文字列
		/// </param>
		/// <seealso cref="StringBuilder(string)"/>
		public RealSqlBuilder(string item)
		{
			if (item is object && item.Length > 0)
			{
				this.parts.Add((item, typeof(string)));
			}
		}

		/// <summary>
		/// <see cref="RealSqlBuilder"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="capacity">
		/// 未使用パラメータ（互換性用）
		/// </param>
		/// <remarks>
		/// 引数の付いたStringBuilderのコンストラクタからの置き換えの互換用
		/// </remarks>
		/// <seealso cref="StringBuilder(int)"/>
#pragma warning disable IDE0060 // 未使用のパラメーターを削除します
		public RealSqlBuilder(int capacity)
#pragma warning restore IDE0060 // 未使用のパラメーターを削除します
		{
		}

		/// <summary>
		/// <see cref="RealSqlBuilder"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="item">
		/// 初期SqlPString文字列
		/// </param>
		/// <seealso cref="StringBuilder(string)"/>
		public RealSqlBuilder(SqlPString item)
		{
			if (item is object)
			{
				this.parts.AddRange(item.parts);
			}
		}
		#endregion

		#region enum
		/// <summary>
		/// InsertのIndexを0(冒頭)に限定するためのenum変数
		/// </summary>
		//InsertのIndexは0(冒頭)に限定
		public enum RealSqlBuilderInsertIndex
		{
			First = 0
		}
		#endregion

		#region property
		/// <summary>
		/// 文字列としての長さ
		/// </summary>
		/// <remarks>
		/// 長さを再設定する場合は0のみをサポート
		/// </remarks>
		public int Length
		{
			get
			{
				return ((string)this).Length;
			}

			set
			{
				if (value != 0)
				{
					throw new Exception("RealSqlBuilderの長さを0以外に再設定することはできません。");
				}
				else
				{
					this.parts.Clear();
				}
			}
		}
		#endregion

		#region operator
		/// <summary>
		/// <see cref="string"/>から<see cref="RealSqlBuilder"/>への暗黙変換
		/// </summary>
		/// <param name="s">変換対象</param>
		/// <returns><see cref="string"/>を<see cref="RealSqlBuilder"/>に変換した結果</returns>
		public static implicit operator RealSqlBuilder(string s)
		{
			return s is null ? null : new RealSqlBuilder(s);
		}

		/// <summary>
		/// <see cref="StringBuilder"/>から<see cref="RealSqlBuilder"/>への暗黙変換
		/// </summary>
		/// <param name="sb">変換対象</param>
		/// <returns><see cref="StringBuilder"/>を<see cref="RealSqlBuilder"/>に変換した結果</returns>
		public static implicit operator RealSqlBuilder(StringBuilder sb)
		{
			return sb is null ? null : new RealSqlBuilder(sb.ToString());
		}

		/// <summary>
		/// <see cref="RealSqlBuilder"/>から<see cref="SqlPString"/>への暗黙変換
		/// </summary>
		/// <param name="sb">変換対象</param>
		/// <returns><see cref="RealSqlBuilder"/>を<see cref="SqlPString"/>に変換した結果</returns>
		public static implicit operator SqlPString(RealSqlBuilder sb)
		{
			switch (sb)
			{
				case null:
					return null;
				default:
					SqlPString ps = new SqlPString();
					sb.parts.ForEach(p =>
					{
						if (p.Item2 != typeof(string))
						{
							ps.parts.Add(p);
						}
						else if (p.Item1 is object && p.Item1.Length > 0)
						{
							if (ps.parts.Count > 0 && ps.parts.Last().Item2 == typeof(string))
							{
								string s = ps.parts.Last().Item1 + p.Item1;
								ps.parts.RemoveAt(ps.parts.Count - 1);
								ps.parts.Add((s, typeof(string)));
							}
							else
							{
								ps.parts.Add(p);
							}
						}
					});
					return ps;
			}
		}

		/// <summary>
		/// <see cref="RealSqlBuilder"/>から<see cref="StringBuilder"/>への変換
		/// </summary>
		/// <param name="sb">変換対象</param>
		/// <returns><see cref="RealSqlBuilder"/>を<see cref="StringBuilder"/>に変換した結果</returns>
		public static explicit operator StringBuilder(RealSqlBuilder sb)
		{
			return sb is null ? null : new StringBuilder((string)sb.ToSqlPString());
		}

		/// <summary>
		/// <see cref="RealSqlBuilder"/>から<see cref="string"/>への変換
		/// </summary>
		/// <param name="sb">変換対象</param>
		/// <returns><see cref="RealSqlBuilder"/>を<see cref="string"/>に変換した結果</returns>
		public static explicit operator string(RealSqlBuilder sb)
		{
			return sb is null ? null : (string)sb.ToSqlPString();
		}

		/// <summary>
		/// <see cref="RealSqlBuilder"/>と<see cref="RealSqlBuilder"/>の値が同一かどうかを判断
		/// </summary>
		/// <param name="ss1">比較対象1</param>
		/// <param name="ss2">比較対象2</param>
		/// <returns>同じ場合は true。それ以外の場合は false。</returns>
		public static bool operator ==(RealSqlBuilder ss1, RealSqlBuilder ss2)
		{
			return (ss1 is null ? null : (string)ss1) == (ss2 is null ? null : (string)ss2);
		}

		/// <summary>
		/// <see cref="RealSqlBuilder"/>と<see cref="RealSqlBuilder"/>の値が異なるかどうかを判断
		/// </summary>
		/// <param name="ss1">比較対象1</param>
		/// <param name="ss2">比較対象2</param>
		/// <returns>異なる場合は true。それ以外の場合は false。</returns>
		public static bool operator !=(RealSqlBuilder ss1, RealSqlBuilder ss2)
		{
			return (ss1 is null ? null : (string)ss1) != (ss2 is null ? null : (string)ss2);
		}
		#endregion

		#region method
		/// <summary>
		/// 指定のインデックスに文字列を挿入
		/// </summary>
		/// <param name="index">
		/// インデックス
		/// </param>
		/// <param name="item">
		/// 挿入する文字列
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Insert(int, string)"/>
		public RealSqlBuilder Insert(RealSqlBuilderInsertIndex index, string item)
		{
			this.parts.Insert((int)index, (item, typeof(string)));
			return this;
		}

		/// <summary>
		/// 部分文字列の削除
		/// </summary>
		/// <param name="index">
		/// 開始インデックス
		/// </param>
		/// <param name="removeLength">
		/// 削除する文字列の長さ
		/// </param>
		/// <returns>
		/// 削除した後のこのインスタンスへの参照
		/// </returns>
		/// <remarks>
		/// 全文字列の削除、およびSQLパラメータを含まない末尾からのRealSqlBuilderの部分文字列削除のみをサポート
		/// </remarks>
		/// <seealso cref="StringBuilder.Remove(int, int)"/>
		public RealSqlBuilder Remove(int index, int removeLength)
		{
			if (index + removeLength == this.Length)
			{
				SqlPString ps = this;
				this.parts.Clear();

				if (index != 0 && ps.parts.Count > 0)
				{
					string s = ps.parts.Last().Item1;

					if (ps.parts.Last().Item2 == typeof(string) && s.Length >= removeLength)
					{
						ps.parts.RemoveAt(ps.parts.Count - 1);
						if (s.Length > removeLength)
						{
							s = s.Remove(s.Length - removeLength, removeLength);
							ps.parts.Add((s, typeof(string)));
						}
					}
					else if (removeLength != 0)
					{
						throw new Exception("SQLパラメータを含む末尾からのRealSqlBuilderの部分文字列削除はサポートしていません。");
					}

					this.parts.AddRange(ps.parts);
				}
			}
			else
			{
				throw new Exception("全文字列の削除、およびSQLパラメータを含まない末尾からのRealSqlBuilderの部分文字列削除のみをサポートしています。");
			}

			return this;
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// DateTime
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Append(object)"/>
		public RealSqlBuilder Append(DateTime item)
		{
			return this.Append(item.ToString());
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// ParamString
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Append(string)"/>
		public RealSqlBuilder Append(ParamString item)
		{
			this.parts.AddRange(item.parts);
			return this;
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// ParamNoString
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Append(string)"/>
		public RealSqlBuilder Append(ParamNoString item)
		{
			this.parts.AddRange(item.parts);
			return this;
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// ParamNumericString
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Append(string)"/>
		public RealSqlBuilder Append(ParamNumericString item)
		{
			this.parts.AddRange(item.parts);
			return this;
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// ParamLikeString
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Append(string)"/>
		public RealSqlBuilder Append(ParamLikeString item)
		{
			this.parts.AddRange(item.parts);
			return this;
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// SqlPString
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Append(string)"/>
		public RealSqlBuilder Append(SqlPString item)
		{
			if (item is object)
			{
				this.parts.AddRange(item.parts);
			}
			return this;
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// string
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Append(string)"/>
		public RealSqlBuilder Append(string item)
		{
			if (item is object && item.Length > 0)
			{
				this.parts.Add((item, typeof(string)));
			}
			return this;
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// int
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Append(int)"/>
		public RealSqlBuilder Append(int item)
		{
			return this.Append(item.ToString());
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// decimal
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Append(decimal)"/>
		public RealSqlBuilder Append(decimal item)
		{
			return this.Append(item.ToString());
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// WherePhraseBuilder
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Append(object)"/>
		public RealSqlBuilder Append(WherePhraseBuilder item)
		{
			return this.Append(item?.ToString());
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// UnitID
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Append(object)"/>
		public RealSqlBuilder Append(UnitID item)
		{
			return this.Append(item.ToString());
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// object
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <remarks>
		/// パラメタライズ化の必要がないかどうかを判断するため参照箇所を個別に要確認
		/// </remarks>
		/// <seealso cref="StringBuilder.Append(object)"/>
		public RealSqlBuilder Append(object item)
		{
			return this.Append(item?.ToString());
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// StringBuilder
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Append(object)"/>
		public RealSqlBuilder Append(StringBuilder item)
		{
			return this.Append(item?.ToString());
		}

		/// <summary>
		/// 末尾に文字列を追加
		/// </summary>
		/// <param name="item">
		/// RealSqlBuilder
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.Append(object)"/>
		public RealSqlBuilder Append(RealSqlBuilder item)
		{
			if (item is object)
			{
				this.parts.AddRange(item.parts);
			}
			return this;
		}

		/// <summary>
		/// 末尾にFormatした文字列を追加
		/// </summary>
		/// <param name="format">
		/// 書式文字列
		/// </param>
		/// <param name="args">
		/// パラメータの配列
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.AppendFormat(string, object[])"/>
		public RealSqlBuilder AppendFormat(string format, string[] args)
		{
			return this.Append(string.Format(format, args));
		}

		/// <summary>
		/// 末尾にFormatした文字列を追加
		/// </summary>
		/// <param name="format">
		/// string型の書式文字列
		/// </param>
		/// <param name="args">
		/// SqlPString型のパラメータの配列
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <seealso cref="StringBuilder.AppendFormat(string, object[])"/>
		public RealSqlBuilder AppendFormat(string format, params SqlPString[] args)
		{
			List<string> sanitizedArgs = new List<string>();

			foreach (SqlPString ps in args)
			{
				sanitizedArgs.Add(ps.Sanitizing());
			}

			return this.Append(string.Format(format, sanitizedArgs.ToArray()));
		}

		/// <summary>
		/// 末尾にFormatした文字列を追加
		/// </summary>
		/// <param name="item">
		/// string型の(書式)文字列
		/// </param>
		/// <returns>
		/// 追加した後のこのインスタンスへの参照
		/// </returns>
		/// <remarks>
		/// StringBuilderからの置き換えの互換用であり、パラメータがないので書式文字列そのままで追加される。
		/// </remarks>
		/// <seealso cref="StringBuilder.AppendFormat(string, object[])"/>
		public RealSqlBuilder AppendFormat(string item)
		{
			return this.Append(item);
		}

		/// <summary>
		/// リテラル文字列への変換
		/// </summary>
		/// <returns>
		/// 変換後の文字列
		/// </returns>
		/// <remarks>
		/// 使用箇所はコンパイルエラーとなる。ToSTring()の使用の抑止用。
		/// </remarks>
		[Obsolete("SQLI RealSqlBuilder ToString", true)]
		public new string ToString()
		{
			return (string)this;
		}

		/// <summary>
		/// SqlPStringへの変換
		/// </summary>
		/// <returns>
		/// 変換された結果のSqlPString
		/// </returns>
		public SqlPString ToSqlPString()
		{
			return this;
		}

		/// <summary>
		/// オブジェクトの値が同一かどうかを判断
		/// </summary>
		/// <param name="o">
		/// object
		/// </param>
		/// <returns>
		/// 同じ場合は true。それ以外の場合は false。
		/// </returns>
		public override bool Equals(object o)
		{
			return (string)this == o?.ToString();
		}

		/// <summary>
		/// この文字列のハッシュ コードを返します。
		/// </summary>
		/// <returns>
		/// ハッシュ コード
		/// </returns>
		public override int GetHashCode()
		{
			return ((string)this).GetHashCode();
		}
		#endregion
	}
}

namespace Infocom.Allegro
{
	/// <summary>
	/// 拡張メソッド
	/// </summary>
	public static class SqlStringExtensions
	{
		#region method
		/// <summary>
		/// <paramref name="s"/>が整数を表している場合そのまま返す
		/// </summary>
		/// <param name="s">
		/// 検証対象の文字列
		/// </param>
		/// <returns>
		/// 整数でない場合には空文字にして返す文字列
		/// </returns>
		public static string ToSqlIntString(this string s)
		{
			if (int.TryParse(s, out _))
			{
				return s;
			}
			else
			{
				return "";
			}
		}

		/// <summary>
		/// テーブル名として安全な形の文字列にする
		/// <paramref name="s"/>に含まれる"]"を"]]"に変換し、"[]"で囲まれてなければ囲む。
		/// <paramref name="s"/>がDB上の単一の識別子を表す場合に使用する。
		/// </summary>
		/// <param name="s">
		/// テーブル名
		/// </param>
		/// <returns>
		/// 安全な形にしたテーブル名の文字列
		/// </returns>
		public static string ToSafeTableNameString(this string s)
		{
			if (string.IsNullOrWhiteSpace(s))
			{
				return s;
			}

			s = s.Trim();

			if (s.Length > 2 && s[0] == '[' && s[s.Length - 1] == ']')
			{
				s = s.Substring(1, s.Length - 2);
			}

			return "[" + s.Replace("]", "]]") + "]";
		}

		/// <summary>
		/// カラム名として安全な形の文字列にする。
		/// <paramref name="s"/>に含まれる"]"を"]]"に変換し、"[]"で囲まれてなければ囲む。
		/// <paramref name="s"/>は、[テーブル名].[列名]形式や別名が付与されている場合にも使用可能。
		/// <paramref name="s"/>が複雑な計算式の場合には使用不可だが、COUNT(*)やCOUNT(列名)、COUNT([列名])の場合は使用可能
		/// </summary>
		/// <param name="s">
		/// 検証対象のカラム名
		/// </param>
		/// <returns>
		/// 安全な形にしたカラム名の文字列
		/// </returns>
		public static string ToSafeColumnNameString(this string s)
		{
			if (string.IsNullOrWhiteSpace(s))
			{
				return s;
			}
			if (s.Trim().StartsWith("ISNULL("))
			{
				return s;
			}

			string table = null;
			string column = s;
			string alias = null;
			string notColumn = null;

			// ASと周辺の空白を検出し、エイリアス部を分割
			MatchCollection asMatch = Regex.Matches(s, @"\s+(A|a)(S|s)\s+");
			if (asMatch.Count > 0)
			{
				column = s.Substring(0, asMatch[0].Index);
				alias = s.Substring(asMatch[0].Index + asMatch[0].Value.Length);
			}

			// [テーブル名].[カラム名] になっている場合は、テーブルとカラムに分割
			if (column.IndexOf('.') >= 0)
			{
				table = column.Substring(0, column.IndexOf('.'));
				column = column.Substring(column.IndexOf('.') + 1);
			}

			// カラム名相当の部分に関数等が指定されていた場合退避 ※現状はCOUNTのみ対応
			if (Regex.Match(column, @"^\s*COUNT\s*\(\s*\*\s*\)\s*$", RegexOptions.IgnoreCase).Success)
			{
				// COUNT(*)の場合
				notColumn = column;
			}
			else if (Regex.Match(column, @"^\s*COUNT\s*\(\s*\w+\s*\)\s*$", RegexOptions.IgnoreCase).Success)
			{
				// COUNT(カラム名)の場合
				notColumn = column;
			}
			else if (Regex.Match(column, @"^\s*COUNT\s*\(\s*\[\s*\w+\s*\]\s*\)\s*$", RegexOptions.IgnoreCase).Success)
			{
				// COUNT([カラム名])の場合
				notColumn = column;
			}

			table = table?.Trim();
			column = column.Trim();
			alias = alias?.Trim();

			// 各要素の[]の中を取り出す
			if (table is object && table.Length > 2 && table[0] == '[' && table[table.Length - 1] == ']')
			{
				table = table.Substring(1, table.Length - 2);
			}
			if (column.Length > 2 && column[0] == '[' && column[column.Length - 1] == ']')
			{
				column = column.Substring(1, column.Length - 2);
			}
			if (alias is object && alias.Length > 2 && alias[0] == '[' && alias[alias.Length - 1] == ']')
			{
				alias = alias.Substring(1, alias.Length - 2);
			}

			// ]を2重化してエスケープ
			table = table?.Replace("]", "]]");
			column = column.Replace("]", "]]");
			alias = alias?.Replace("]", "]]");

			// []で囲む
			if (table is object)
			{
				table = "[" + table + "]";
			}
			column = "[" + column + "]";
			if (alias is object)
			{
				alias = "[" + alias + "]";
			}

			// 関数だった場合はカラム部に上書き
			if (notColumn is object)
			{
				column = notColumn;
			}

			// テーブル部があるならば結合し[テーブル].[カラム]形式にする
			if (table is object)
			{
				column = table + "." + column;
			}

			// エイリアスがある場合は「AS」と共に結合し、[カラム] AS [エイリアス]形式にする
			if (alias is object)
			{
				column = column + asMatch[0].Value + alias;
			}

			return column;
		}

		/// <summary>
		/// 識別子として使用できない文字を除去した安全な文字列にして返す。
		/// カラム名の一部など[]で全体を囲むことが出来ない場合に使用する。
		/// </summary>
		/// <param name="s">
		/// 検証対象の文字列
		/// </param>
		/// <returns>
		/// 安全な形にした文字列
		/// </returns>
		public static string ToSafePartialColumnNameString(this string s)
		{
			return s is null ? null : Regex.Replace(s, @"[^\w#]", "");
		}

		/// <summary>
		/// LIKE文の対象の文字列に対して必要なエスケープ処理を行う
		/// </summary>
		/// <param name="s">
		/// 対象の文字列
		/// </param>
		/// <returns>
		/// エスケープされた文字列
		/// </returns>
		public static string LikeEscape(this string s)
		{
			return s is null ? "" : s.Replace("[", "[[]").Replace("%", "[%]").Replace("_", "[_]");
		}

		/// <summary>
		/// objectをその実際の型に応じてSqlPStringに変換する
		/// </summary>
		/// <param name="o">
		/// object
		/// </param>
		/// <returns>
		/// SqlPString型の値はそのまま、nullは空文字、その他はstring文字列としたものをSqlPString型で返す。
		/// </returns>
		public static BL.SqlClient.SqlPString ToSqlPString(this object o)
		{
			if (o is BL.SqlClient.SqlPString ps)
			{
				return ps;
			}
			else if (o is string s)
			{
				return s;
			}
			else if (o is object)
			{
				return o.ToString();
			}
			else
			{
				return "";
			}
		}
		#endregion
	}
}
