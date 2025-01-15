// Product     : Allegro
// Unit        : CM
// Module      : MS
// Function    : --
// File Name   : Emp.cs
// 機能名      : 社員共通機能
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 管理番号B22215 2009/03/31 担当者の自部門チェック
// 1.6.0 2009/09/30
// 管理番号B22452,B22453,B22454 2010/06/07 メニューの公開区分による伝票登録不備
// 管理番号K24270 2011/12/16 ドリルスルー対応
// 2.0.0 2012/10/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 3.1.0 2020/06/30
// 管理番号K27443 2022/02/15 アカウント管理強化
// 3.2.0 2023/03/31

using System;
using System.Web;
using Infocom.Allegro;

namespace Infocom.Allegro.CM.MS
{
	/// <summary>
	/// 社員に関する共通機能を提供します。
	/// </summary>
	public sealed class Emp
	{
		#region Constructors
		private Emp()
		{
		}
		#endregion

		#region Methods
		/// <summary>
		/// 社員の存在チェック及び社員略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="empCode">
		/// 社員コード
		/// </param>
		/// <param name="empShortName">
		/// 社員略名
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string empCode, out string empShortName)
		{
			return IsExists(commonData, empCode, out empShortName, false);
		}

		/// <summary>
		/// 社員の存在チェック及び社員略名の取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="empCode">
		/// 社員コード
		/// </param>
		/// <param name="empShortName">
		/// 社員略名
		/// </param>
		/// <param name="allEmp">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string empCode, out string empShortName, bool allEmp)
		{
			if (string.Equals(empCode, string.Empty))
			{
				empShortName = string.Empty;
				return false;
			}

			string temp = BL_CM_MS_Emp.GetShortName(commonData, empCode, allEmp);
			if (string.Equals(temp, AllegroMessage.S10028))
			{
				empShortName = temp;
				return false;
			}
			else
			{
				empShortName = temp;
				return true;
			}
		}

		/// <summary>
		/// 社員の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="empCode">
		/// 社員コード
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string empCode)
		{
			return IsExists(commonData, empCode, false);
		}

		/// <summary>
		/// 社員の存在チェックを行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="empCode">
		/// 社員コード
		/// </param>
		/// <param name="allEmp">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool IsExists(CommonData commonData, string empCode, bool allEmp)
		{
			if (string.Equals(empCode, string.Empty))
			{
				return false;
			}

			return BL_CM_MS_Emp.IsExists(commonData, empCode, allEmp);
		}
// 管理番号B22215 From		
		/// <summary>
		/// 社員の公開単位区分を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="empCode">
		/// 社員コード
		/// </param>
		/// <param name="pageCode">
		/// ページコード
		/// </param>
		/// <returns>
		/// 公開区分
		/// </returns>
		/// <remarks>
		/// 本メソッドは全社："C"を固定で返します。
		/// </remarks>
		public static string getDisclosureUnitType(CommonData commonData, string empCode, string pageCode)
		{
// 管理番号B22452,B22453,B22454 From		
//			return BL_CM_MS_Emp.getDisclosureUnitType(commonData, empCode, pageCode);
            return "C";
// 管理番号B22452,B22453,B22454 To	
        }
// 管理番号B22215 To
// 管理番号K24270 From
		/// <summary>
		/// 社員の公開単位区分を取得します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="empCode">
		/// 社員コード
		/// </param>
		/// <param name="pageCode">
		/// ページコード
		/// </param>
		/// <returns>
		/// 公開区分
		/// </returns>
		/// <remarks>
		/// 全社の場合："C"、部門（自部門のみ）の場合："D"、両方(複数メニューで区分が異なる場合)："B"
		/// </remarks>
        public static string getLoginDisclosureUnitType(CommonData commonData, string empCode, string pageCode)
        {
            return BL_CM_MS_Emp.getDisclosureUnitType(commonData, empCode, pageCode);
        }
// 管理番号K24270 To
// 管理番号K27443 From
		/// <summary>
		/// 社員メールアドレスの取得を行います。（社員コードが有効な場合のみ）
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="empCode">
		/// 社員コード
		/// </param>
		/// <param name="empMailAccount">
		/// 社員メールアカウント
		/// </param>
		/// <param name="empMailDomain">
		/// 社員メールドメイン
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool GetMail(CommonData commonData, string empCode, out string empMailAccount, out string empMailDomain)
		{
			return GetMail(commonData, empCode, out empMailAccount, out empMailDomain, false);
		}

		/// <summary>
		/// 社員メールアドレスの取得を行います。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="empCode">
		/// 社員コード
		/// </param>
		/// <param name="empMailAccount">
		/// 社員メールアカウント
		/// </param>
		/// <param name="empMailDomain">
		/// 社員メールドメイン
		/// </param>
		/// <param name="allEmp">
		/// 無効も含める場合：true、それ以外の場合：false
		/// </param>
		/// <returns>
		/// 存在有無
		/// </returns>
		public static bool GetMail(CommonData commonData, string empCode, out string empMailAccount, out string empMailDomain, bool allEmp)
		{
			if (string.Equals(empCode, string.Empty))
			{
				empMailAccount = string.Empty;
				empMailDomain = string.Empty;
				return false;
			}
			// 社員メールアドレスの取得
			return BL_CM_MS_Emp.GetMail(commonData, empCode, out empMailAccount, out empMailDomain, allEmp);
		}
// 管理番号K27443 To
		#endregion
	}
}
