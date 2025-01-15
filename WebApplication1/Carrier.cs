// Product     : Allegro
// Unit        : SC
// Module      : MS
// Function    : --
// File Name   : Carrier.cs
// 機能名      : 運送業者共通機能
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/21 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;
using System.Data;
using System.Web.UI.WebControls;
using Infocom.Allegro;

namespace Infocom.Allegro.SC.MS
{
	/// <summary>
	/// 運送業者に関する共通機能を提供します。
	/// </summary>
	public sealed class Carrier
	{
		#region Constructors
		private Carrier()
		{
		}
		#endregion

		#region Methods
		/// <summary>
		/// 運送業者名を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="carrierCode">
		/// 運送業者コード
		/// </param>
		/// <returns>
		/// 運送業者名
		/// </returns>
		public static string GetName(CommonData commonData, string carrierCode)
		{
			return BL_SC_MS_Carrier.GetName(commonData, carrierCode);
		}
		/// <summary>
		/// 運送業者リストのデータソースを設定します。
		/// </summary>
		/// <param name="control">
		/// リストコントロール
		/// </param>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		public static void SetDataSource(ListControl control, CommonData commonData)
		{
			control.DataSource = BL_SC_MS_Carrier.GetDataSource(commonData);
			control.DataValueField = "CODE";
			control.DataTextField = "NAME";
		}
		/// <summary>
		/// 送付状リストのデータソースを設定します。
		/// </summary>
		/// <param name="control">
		/// リストコントロール
		/// </param>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		public static void SetCoveringLetterDataSource(ListControl control, CommonData commonData)
		{
			control.DataSource = BL_SC_MS_Carrier.GetCoveringLetterDataSource(commonData);
			control.DataValueField = "CODE";
			control.DataTextField = "NAME";
		}
		#endregion
	}
}
