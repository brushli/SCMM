// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : StartupScriptManager.cs
// 機能名      : スタートアップスクリプト管理クラス
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/02/14 UI見直し
// 3.0.0 2018/04/30

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace Infocom.Allegro.Web
{
	/// <summary>
	/// 登録された順に実行されるように、スタートアップスクリプトを管理します。
	/// </summary>
	public class StartupScriptManager
	{
		/// <summary>
		/// スクリプトの登録先となるページ
		/// </summary>
		protected Page Owner { get; set; }

		/// <summary>
		/// ページ全体からこのStartupScriptManagerを識別するためのインスタンス固有のキー
		/// </summary>
		protected string UniqueKey { get; private set; }

		/// <summary>
		/// スタートアップ時に実行する関数名を保持するIList
		/// </summary>
		protected IList<string> FunctionNames { get; private set; }

		/// <summary>
		/// 登録済みスクリプトを全て実行するためのクライアントスクリプト用ステートメント。
		/// </summary>
		public virtual IEnumerable<string> CallStatements
		{
			get { return this.FunctionNames.Select(funcName => funcName + "();"); }
		}

		/// <summary>
		/// 登録済みスクリプトの数
		/// </summary>
		public int ScriptCount
		{
			get { return FunctionNames.Count; }
		}

		/// <summary>
		/// 指定されたページに対してスタートアップスクリプトを登録するための<see cref="StartupScriptManager"/>を作成します。
		/// </summary>
		/// <param name="owner">登録先ページ</param>
		public StartupScriptManager(Page owner)
		{
			this.Owner = owner;
			this.UniqueKey = Guid.NewGuid().ToString("N");
			this.FunctionNames = new List<string>();
		}

		/// <summary>
		/// スタートアップスクリプトを登録します。スクリプトタグは不要です。
		/// このメソッドを異なる<see cref="StartupScriptManager"/>のインスタンスから実行された場合、
		/// <paramref name="type"/>と<paramref name="key"/>が同一であっても、異なるスクリプトとして登録されます。
		/// </summary>
		/// <param name="type">登録するクライアント スクリプトの型。</param>
		/// <param name="key">登録するクライアント スクリプトを一意に識別するためのキー。</param>
		/// <param name="script">登録するクライアント スクリプト リテラル。</param>
		public virtual void RegisterScript(Type type, string key, string script)
		{
			if (!this.IsScriptRegistered(type, key))
			{
				// 一意な関数名を生成し関数名リストに追加
				var requestFunctionName = "startup" + UniqueKey + ScriptCount;
				FunctionNames.Add(requestFunctionName);

				// 指定されたスクリプトを関数化
				var scriptBody = new StringBuilder()
					.AppendLine()
					.Append("function ").Append(requestFunctionName).AppendLine("() {")
					.AppendLine(Regex.Replace(script.Trim(), "^", "\t", RegexOptions.Multiline))
					.AppendLine("}")
					.ToString();

				this.Owner.ClientScript.RegisterStartupScript(type, GenerateScriptKey(key), scriptBody, true);
			}
		}

		/// <summary>
		/// スタートアップスクリプトが登録済みかどうかを確認します。
		/// </summary>
		/// <param name="key">登録済みかどうか確認するクライアント スクリプトのキー。</param>
		/// <returns>スクリプトが登録済みかどうか</returns>
		public virtual bool IsScriptRegistered(string key)
		{
			return this.IsScriptRegistered(this.Owner.GetType(), key);
		}

		/// <summary>
		/// スタートアップスクリプトが登録済みかどうかを確認します。
		/// </summary>
		/// <param name="type">登録するクライアント スクリプトの型。</param>
		/// <param name="key">登録済みかどうか確認するクライアント スクリプトのキー。</param>
		/// <returns>スクリプトが登録済みかどうか</returns>
		public virtual bool IsScriptRegistered(Type type, string key)
		{
			return this.Owner.ClientScript.IsStartupScriptRegistered(type, GenerateScriptKey(key));
		}

		/// <summary>
		/// ページにスクリプトを登録する際に使用するキー文字列を生成します。
		/// 同一の<see cref="StartupScriptManager"/>インスタンスで、同一の<paramref name="requestKey"/>が指定された場合、このメソッドは常に同じ値を返します。
		/// </summary>
		/// <param name="requestKey"></param>
		/// <returns></returns>
		private string GenerateScriptKey(string requestKey) {
			return UniqueKey + requestKey;
		}
	}
}
