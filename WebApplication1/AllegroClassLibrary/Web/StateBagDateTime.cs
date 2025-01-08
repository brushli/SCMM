// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : StateBagDateTime.cs
// 機能名      : VIEWSTATE格納用DateTime
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;

namespace Infocom.Allegro.Web
{
	/// <summary>
	/// <see cref="DateTime"/>を<see cref="System.Web.UI.Control.ViewState"/>に保持するための機能を提供します。
	/// </summary>
	[Serializable]
	public class StateBagDateTime
	{
		private DateTime date;
		private TimeSpan time;

		/// <summary>
		/// ViewState格納用DateTimeのコンストラクタです。
		/// </summary>
		/// <param name="value">
		/// <see cref="System.Web.UI.Control.ViewState"/>に保持する<see cref="DateTime"/>。
		/// </param>
		public StateBagDateTime(DateTime value)
		{
			date = value.Date;
			time = value.TimeOfDay;
		}

		/// <summary>
		/// インスタンスの値を等価な<see cref="DateTime"/>に変換します。
		/// </summary>
		/// <returns>
		/// このインスタンスの値と等価な DateTime 構造体。
		/// </returns>
		public DateTime ToDateTime()
		{
			return date.Add(time);
		}

		/// <summary>
		/// インスタンスの値を等価な文字列形式に変換します。
		/// </summary>
		/// <returns>
		/// このインスタンスの値の文字列形式。
		/// </returns>
		public override string ToString()
		{
			return ToDateTime().ToString();
		}
	}
}
