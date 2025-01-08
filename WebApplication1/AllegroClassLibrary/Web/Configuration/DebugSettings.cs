// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : DebugSettings.cs
// 機能名      : デバッグ用設定値取得クラス
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/08/29 UI見直し
// 3.0.0 2018/04/30

using System;
using System.Collections.Specialized;
using System.Configuration;

namespace Infocom.Allegro.Web.Configuration
{
	/// <summary>
	/// Web.configのdebugSettingsセクションに格納された設定値を取得します。
	/// </summary>
	internal static class DebugSettings
	{
		private static readonly NameValueCollection Settings = (NameValueCollection)ConfigurationManager.GetSection("debugSettings");

		/// <summary>
		/// 指定されたキーに対応する値を返します。
		/// 未設定時や戻り値の型への変換が失敗した場合、<paramref name="defaultValue"/>を返します。
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="key"></param>
		/// <param name="defaultValue"></param>
		/// <returns></returns>
		public static T Get<T>(string key, T defaultValue)
		{
			var value = Settings[key];
			try
			{
				var type = typeof(T);
				return (T)Convert.ChangeType(value, Nullable.GetUnderlyingType(type) ?? type);
			}
			catch (Exception)
			{
				return defaultValue;
			}
		}
	}
}
