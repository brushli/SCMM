// Product     : Allegro
// Unit        : CM
// Module      : MS
// Function    : --
// File Name   : SustAppl.cs
// 機能名      : 仕入先（申請）共通機能
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 管理番号K20126 2007/02/08 主要マスタWF対応
// 1.5.1 2007/06/30
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;
using System.Web;
using Infocom.Allegro;

namespace Infocom.Allegro.CM.MS
{
	/// <summary>
	/// 仕入先（申請）に関する共通機能を提供します。
	/// </summary>
	public sealed class SuplAppl
	{
		#region Constructors
		private SuplAppl()
		{
		}
		#endregion

		#region Methods
		/// <summary>
		/// 仕入先（申請）の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCode)
		{
			return IsExists(commonData, suplCode, string.Empty);
		}

		/// <summary>
		/// 仕入先（申請）の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="suplCode">
		/// 仕入先コード
		/// </param>
		/// <param name="suplSbno">
		/// 仕入先枝番
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string suplCode, string suplSbno)
		{
			if (suplCode == string.Empty)
			{
				return false;
			}

			return BL_CM_MS_SuplAppl.IsExists(commonData, suplCode, suplSbno);
		}

		#endregion
	}
}
