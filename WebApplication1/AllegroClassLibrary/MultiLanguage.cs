// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : MultiLanguage.cs
// 機能名      : 多言語関連共通機能
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号 K24546 2013/03/29 多言語化対応
// 2.1.0 2013/03/31
// 管理番号 B25012 2013/07/03 数値フォーマット統一
// 管理番号 K25163 2013/07/03 言語リソース分離対応
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/11/22 UI見直し
// 3.0.0 2018/04/30

using System;
using System.Globalization;
using System.Threading;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using Infocom.Allegro.Web.WebControls;
using System.Web.SessionState;
using System.Collections.Generic;

namespace Infocom.Allegro
{
	/// <summary>
	/// 多言語に関する共通機能を提供します。このクラスは継承できません。
	/// </summary>
	public sealed class MultiLanguage
	{
		/// <summary>
		/// 既定のカルチャ名。
		/// </summary>
		public const string DEFAULT_CULTURE_NAME = "ja-JP";
		private const string NotFoundMessage = "{0} not found.";
		private static Dictionary<string, string> LoadedResource = new Dictionary<string,string>();
		private static Object LOCK = new Object();

		/// <summary>
		/// 指定したリソースキーに対応する文字列を取得します。
		/// </summary>
		/// <param name="key">
		/// リソースキー
		/// </param>
		/// <returns>
		/// 指定したリソースキーに対応する文字列。
		/// </returns>
		public static string Get(string key)
		{
			return Get(key, Thread.CurrentThread.CurrentUICulture);
		}

		/// <summary>
		/// 指定したリソースキーに対応する文字列を取得します。
		/// </summary>
		/// <param name="key">
		/// リソースキー
		/// </param>
		/// <param name="selectCulture">
		/// カルチャ
		/// </param>
		/// <returns>
		/// 指定したリソースキーに対応する文字列。
		/// </returns>
		public static string Get(string key, string selectCulture)
		{
			CultureInfo culture = new CultureInfo(selectCulture, true);
			return Get(key, culture);
		}

		/// <summary>
		/// 指定したリソースキーに対応する文字列を取得します。
		/// </summary>
		/// <param name="key">
		/// リソースキー
		/// </param>
		/// <param name="culture">
		/// カルチャ
		/// </param>
		/// <returns>
		/// 指定したリソースキーに対応する文字列。
		/// </returns>
		public static string Get(string key, CultureInfo culture)
		{
// 管理番号K26528 From
//			return GetServerReport(key);
			return GetServerReport(key, culture);
// 管理番号K26528 To
		}

// 管理番号K26528 From
//		/// <summary>
//		/// 指定したリソースキーに対応する文字列を取得します。
//		/// </summary>
//		/// <param name="key">
//		/// リソースキー
//		/// </param>
//		/// <returns>
//		/// 指定したリソースキーに対応する文字列。
//		/// </returns>
//		public static string GetServerReport(string key)
//		{
//			CultureInfo ci = Thread.CurrentThread.CurrentUICulture;
//			string fullKey = ci.Name + key;
		/// <summary>
		/// 指定したリソースキーに対応する文字列を取得します。
		/// </summary>
		/// <param name="key">
		/// リソースキー
		/// </param>
		/// <param name="culture">
		/// カルチャ
		/// </param>
		/// <returns>
		/// 指定したリソースキーに対応する文字列。
		/// </returns>
		public static string GetServerReport(string key, CultureInfo culture)
		{
			var fullKey = culture.Name + key;
// 管理番号K26528 To
			if (!LoadedResource.ContainsKey(fullKey))
			{
				System.Reflection.Assembly asm;
				asm = System.Reflection.MethodBase.GetCurrentMethod().DeclaringType.Assembly;
// 管理番号 K25163　From
//				System.Resources.ResourceManager rm = new System.Resources.ResourceManager("Infocom.Allegro.Resources." + ci.Name, asm);
				System.Resources.ResourceManager rm = new System.Resources.ResourceManager("AllegroResource", asm);
// 管理番号 K25163　To

// 管理番号K26528 From
//				string o = rm.GetString(key);
				var o = rm.GetString(key, culture);
// 管理番号K26528 To
				if (o != null)
				{
					// 半角スペースの代替文字としてリソース内に登録されている特殊文字("&#160;")を" "に置換する
					if (o.IndexOf("&#160;") >= 0)
					{
						// 160は半角スペースのASCIIコード
						char halfSpace = Convert.ToChar(160);
						o = o.Replace("&#160;", halfSpace.ToString());
					}
					//①@"\\"を変換用代替文字に置換し、
					//②表示に影響のある「エスケープあり制御文字」を「エスケープなしの制御文字」に置換後、
					//③代替文字を「エスケープありの\」に置換
					o = o.Replace(@"\\", "&#160;");
					o = o.Replace(@"\r", "\r").Replace(@"\n", "\n").Replace(@"\v", "\v").Replace(@"\t", "\t");
					o = o.Replace("&#160;", "\\");

					// 重複実行を避けるために排他制御をかける
					lock (LOCK)
					{
						if (!LoadedResource.ContainsKey(fullKey))
						{
							// 排他制御をかけた状態で再度存在チェックを行い、なければ登録
							LoadedResource.Add(fullKey, o);
						}
					}
				}
				else
				{
					throw new ApplicationException(string.Format(NotFoundMessage, key));
				}
			}
			return LoadedResource[fullKey];
		}

// 管理番号K26528 From
		/// <summary>
		/// 指定したリソースキーに対応する文字列を取得します。
		/// </summary>
		/// <param name="key">
		/// リソースキー
		/// </param>
		/// <returns>
		/// 指定したリソースキーに対応する文字列。
		/// </returns>
		public static string GetServerReport(string key)
		{
			return GetServerReport(key, Thread.CurrentThread.CurrentUICulture);
		}
// 管理番号K26528 To

		/// <summary>
		/// 現在のスレッドのカルチャを設定します。ただし、日付および数値のフォーマットは<see cref="DEFAULT_CULTURE_NAME"/>の値が設定されます。
		/// </summary>
		/// <param name="cultureName">
		/// 変更後のカルチャ名。
		/// </param>
		public static void SetCurrentThreadCulture(string cultureName)
		{
			// 指定されたカルチャを作成し、現在のスレッドのカルチャとして設定
			System.Threading.Thread.CurrentThread.CurrentCulture =
			System.Globalization.CultureInfo.CreateSpecificCulture(cultureName);

			// CurrentUICultureはCurrentCultureと同一にする
			System.Threading.Thread.CurrentThread.CurrentUICulture =
			System.Threading.Thread.CurrentThread.CurrentCulture;

			// 日付フォーマットはデフォルトカルチャのものと同一
			System.Threading.Thread.CurrentThread.CurrentCulture.DateTimeFormat =
			System.Globalization.CultureInfo.CreateSpecificCulture(DEFAULT_CULTURE_NAME).DateTimeFormat;

			System.Threading.Thread.CurrentThread.CurrentUICulture.DateTimeFormat =
			System.Globalization.CultureInfo.CreateSpecificCulture(DEFAULT_CULTURE_NAME).DateTimeFormat;

// 管理番号 B25012 From
			// 数値フォーマットはデフォルトカルチャのものと同一
			System.Threading.Thread.CurrentThread.CurrentCulture.NumberFormat =
			System.Globalization.CultureInfo.CreateSpecificCulture(DEFAULT_CULTURE_NAME).NumberFormat;
// 管理番号 B25012 To

		}

// 管理番号K26528 From
		/// <summary>
		/// 指定されたカルチャに対応する、システムが許容する有効なカルチャを返します。
		/// </summary>
		/// <param name="requestCulture"></param>
		/// <returns><paramref name="requestCulture"/>に対応する有効なカルチャ文字列</returns>
		public static string GetValidCulture(string requestCulture)
		{
			// 許容する中国語カルチャ
			string[] validCultureZh = 
			{
				"ZH"
				,"ZH-CN"
				,"ZH-HANS"
				,"ZH-SG"
				,"ZH-HANS-CN"
				,"ZH-HANS-SG"
			};
			// 許容するリソースキー確認用カルチャ
			string[] validCultureResourceKey = 
			{
				"SV"
				,"SV-SE"
			};


			// 未指定判定
			if (string.IsNullOrEmpty(requestCulture))
			{
				// 未指定なら既定
				return DEFAULT_CULTURE_NAME; 
			}

			// 有効なカルチャを取得
			string requestUpperCultureName = requestCulture.ToUpper();
			string validCulture = null;
			if (requestUpperCultureName.Substring(0, 2) == "EN")
			{
				// 英語
				validCulture = "en-US";
			}
			else if(-1 < Array.IndexOf(validCultureZh, requestUpperCultureName))
			{
				// 中国語
				validCulture = "zh-CN";
			}
			else if (-1 < Array.IndexOf(validCultureResourceKey, requestUpperCultureName))
			{
				// リソースキー確認用
				validCulture = "sv-SE";
			}
			else
			{
				// 日本語（既定）
				validCulture = DEFAULT_CULTURE_NAME;
			}
			return validCulture;
		}
// 管理番号K26528 To
	}
}
