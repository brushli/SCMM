// Product     : Allegro
// Unit        : SC
// Module      : MM
// Function    : 05
// File Name   : BL_SC_MM_05_S01.cs
// 機能名      : SC_MM_05_S01 仕入一覧
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 1.1.2 2004/08/31
// 管理番号 B12891 2004/09/22 伝票削除時に計上部門の存在をチェックするロジックの追加
// 管理番号 B13878 2005/02/03 売上・仕入時の単価未決対応
// 1.3.2 2005/03/31
// 管理番号 B15061 2005/04/13 部門・プロジェクト名称取得の不具合対応
// 1.3.3 2005/06/30
// 管理番号 K16187 2005/09/06 支払機能拡張対応
// 1.4.0 2005/10/31
// 管理番号 K16764 2006/01/11 支払保留伝票の絞込機能追加
// 1.5.0 2006/03/31
// 管理番号 P18435 2007/01/12 パフォーマンス対応（2006年9月末分）：タイムアウト値延長
// 管理番号 B18479 2007/01/12 一覧にて金額(残金額は除く)が、総額（税込)で表示されている不具合の修正
// 1.5.1 2007/06/30
// 管理番号 K20685 2007/07/25 ワークフロー取消機能改善
// 1.5.2 2007/10/31
// 管理番号 B20818 2007/12/17 楽観ロック対応
// 管理番号 B21232 2008/01/23 支払保留の条件に「全て」を指定し検索を行うと支払保留のデータが抽出対象にならない不具合対応
// 管理番号 K22196 2008/11/07 都度支払対応
// 管理番号 K22270 2008/10/01 Select時のクエリーヒントに[ WITH (NOLOCK) ]を追加
// 管理番号 K22205 2008/11/06 WF申請者以外の修正対応
// 管理番号 B22494 2009/08/10 ソート不備不具合対応
// 管理番号 B21977 2009/08/10 一括請求の場合、請求処理日項目に請求締日が表示されるよう修正
// 管理番号 B22516 2009/08/10 相殺による消込が行なわれているにも関わらず、伝票削除が行えてしまう不具合を修正
// 1.6.0 2009/09/30
// 管理番号 B22635 2009/11/16 支払予定作成後に支払予定変更にて締日を変更すると、一覧に同一伝票が重複表示される不具合を修正
// 管理番号 B23139 2009/11/16 検索条件に履歴伝票表示：するの条件を指定して検索を行うとアプリケーションエラーが発生する不具合を修正
// 管理番号 B23181 2009/11/16 会計ユニットが未導入の環境にてアプリケーションエラーが発生する不具合を修正
// 管理番号 B23183 2009/11/16 支払（請求）処理日でソートするとソート順が不正となる不具合を修正
// 管理番号 K24267 2012/02/04 合計行追加対応
// 管理番号 B24028 2012/03/26 配下部門の発注確認表が出力されない不具合を修正
// 管理番号 B24057 2012/04/05 一括請求の支払処理日を取得する際、支払の黒データのみを取得対象とする
// 管理番号 B24249 2012/05/07 採番体系が同じ諸掛伝票が決済済状態だと、削除ボタンが非表示となる
// 2.0.0 2012/10/31
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25679 2015/10/26 グループ対応
// 管理番号 K25680 2015/10/26 外部連携
// 管理番号 K25667 2016/01/26 WFファイル添付
// 2.3.0 2016/06/30
// 管理番号B25370 2016/07/20 後続伝票が存在する場合は削除ボタンを押下不可とする修正
// 3.0.0 2018/04/30
// 管理番号B26359 2018/05/08 消込管理区分明細単位時に明細がプラマイゼロの伝票の削除が行えない不具合を修正
// 管理番号B26700 2018/07/09 検索条件の通りに出力されない不具合を修正
// 管理番号K27058 2019/10/29 汎用区分追加
// 管理番号K27057 2019/12/02 汎用項目追加
// 3.1.0 2020/06/30
// 管理番号K27154 2020/07/13 収益認識対応
// 管理番号P27206 2020/07/21 収益認識関連機能のレスポンス改善
// 管理番号K27230 2021/07/20 脆弱性対応
// 管理番号K27441 2022/02/15 組織変更機能改善
// 管理番号K27524 2022/11/08 適格請求書等保存方式対応(支払明細書の記載事項対応)
// 3.2.0 2023/03/31

using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Infocom.Allegro.BL.SqlClient;
// 管理番号K27057 From
using Infocom.Allegro.CM.MS;
// 管理番号K27057 To
using Infocom.Allegro.IF;

namespace Infocom.Allegro.SC
{
	public sealed class BL_SC_MM_05_S01 : MarshalByRefObject
	{
		#region Constructors
		private BL_SC_MM_05_S01()
		{
		}
		#endregion

		#region Static Methods
		public static DataTable Select(IF_SC_MM_05_S01_SearchCondition searchCondition, CommonData commonData, SqlConnection cn, bool selectType)
		{
			//検索用のSELECT文の発行
			RealSqlBuilder sb = new RealSqlBuilder();	// 管理番号K27230

			if (selectType)
			{
				sb.Append("SELECT DISTINCT ");
// 管理番号K27058 From
//				sb.Append("[PU].[PU_NO], [PU].[PU_DATE], [PU].[PO_NO], [PU].[PU_MODE_TYPE], [PU].[CUR_CODE], ");
				sb.Append("[PU].[PU_NO], [PU].[PU_DATE], [PU].[PO_NO], [PU].[PU_MODE_TYPE], ");
				sb.Append(" LEFT([MP].[TYPE_DTIL_NAME], 4) AS [PU_MODE_TYPE_NAME], ");
				sb.Append(" [PU].[CUR_CODE], ");
// 管理番号K27058 To
				// 管理番号 B12891 From
//				sb.Append("[PU].[ORIGIN_DEPT_CODE], [PU].[EMP_CODE], [PU].[SUPL_CODE], [PU].[SUPL_SBNO], ");
				sb.Append("[PU].[DEPT_CODE], [PU].[ORIGIN_DEPT_CODE], [PU].[EMP_CODE], [PU].[SUPL_CODE], [PU].[SUPL_SBNO], ");
				// 管理番号 B12891 To
				sb.Append("ISNULL([PU].[SUPL_SHORT_NAME], '') AS [SUPL_SHORT_NAME], ");
				sb.Append("ISNULL([PU].[SUPL_BILL_SLIP_NO], '') AS [SUPL_BILL_SLIP_NO], [PU].[CANCELED_ORDER_FLG], [PU].[APPROVAL_STATUS_TYPE], ");
				sb.Append("CASE [PU].[PU_MODE_TYPE] ");
//管理番号 B18479 From
//				sb.Append(  "WHEN '2' THEN ([PU].[GRAND_TTL] * -1) ");
//				sb.Append(  "ELSE [PU].[GRAND_TTL] ");
				sb.Append(  "WHEN '2' THEN (([PU].[ETAX_DTIL_AMT_TTL]+[PU].[ITAX_DTIL_AMT_TTL]+[PU].[NTAX_DTIL_AMT_TTL]) * -1) ");
				sb.Append(  "ELSE ([PU].[ETAX_DTIL_AMT_TTL]+[PU].[ITAX_DTIL_AMT_TTL]+[PU].[NTAX_DTIL_AMT_TTL]) ");
//管理番号 B18479 To
				sb.Append("END AS [GRAND_TTL], ");
// 管理番号 B22516 From
				sb.Append("[PU].[DT_TYPE], ");
				sb.Append("[NEWEST_CAR].[CARRIER_NAME],[NEWEST_CAR].[CARRIER_CODE], ");
				// 管理番号 B22516 To
				// 管理番号 B23181 From
				if (searchCondition.ApModuleFlg)
				{
// 管理番号 B23181 To
// 管理番号 B22494 From
//					sb.Append("[PU].[CUTOFF_DATE], [PU].[CUTOFF_FIN_FLG], ");
// 管理番号 B23183 From
//					sb.Append("CASE WHEN [PU].[CUTOFF_FIN_FLG] = '1' ");
//// 管理番号 B21977 From
////					sb.Append(" THEN [PU].[CUTOFF_DATE] ");
//// 管理番号 B22635 From
////					sb.Append(" THEN CASE WHEN [PU].[DT_TYPE] = 'L' ");
//// 管理番号 B22635 To
//					sb.Append(" 	  THEN [PYMT].[PYMT_CUTOFF_DATE] ");
//					sb.Append(" 	  ELSE [PU].[CUTOFF_DATE] ");
//					sb.Append(" 	 END ");
//// 管理番号 B21977 To
//					sb.Append(" ELSE '' ");

					sb.Append("CASE WHEN [PU].[CUTOFF_FIN_FLG] = '1' ");
// 管理番号K27524 From
//					sb.Append("   THEN [PYMT].[PYMT_CUTOFF_DATE] ");
					sb.Append("   THEN ISNULL(CONVERT(NVARCHAR, [PYMT].[PYMT_CUTOFF_DATE], 111), NULL) ");
// 管理番号K27524 To
					sb.Append("   ELSE NULL ");
// 管理番号 B23183 To
					sb.Append("END  AS [CUTOFF_DATE], ");
// 管理番号 B23181 From
				}
				else
				{
					sb.Append(" NULL AS [CUTOFF_DATE], ");
				}
// 管理番号 B23181 To
				sb.Append("[PU].[CUTOFF_FIN_FLG], ");
// 管理番号 B22494 To
				sb.Append("[PU].[RED_SLIP_FLG], [PU].[ORIGIN_PU_NO], [PU].[OPPOSITE_PU_NO], ");
// 管理番号 K16187 From
//				sb.Append("CASE WHEN ([PU].[KO_AMT] > 0) THEN '1' ELSE '0' END AS [KO_FLG], ");
				if(searchCondition.ApModuleFlg)
				{
// 管理番号B26359 From
//					sb.Append("CASE WHEN ([PU].[KO_AMT] > 0 OR [PU].[APPROVED_KO_AMT] > 0 ");
					sb.Append("CASE WHEN [PU].[DT_TYPE] = N'E' ");
					sb.Append("      AND [PU].[KO_AMT] = 0 AND [PU].[KO_COMPLETE_FLG] = N'1' ");
					sb.Append("      AND [PU].[APPROVED_KO_AMT] = 0 AND [PU].[APPROVED_KO_COMPLETE_FLG] = N'1' ");
					sb.Append("      THEN N'0' ");
					sb.Append("     WHEN ([PU].[KO_AMT] > 0 OR [PU].[APPROVED_KO_AMT] > 0 ");
// 管理番号B26359 To
// 管理番号K22196 From
//					sb.Append("OR [PD].[DTIL_KO_FLG] = '1' OR [PS].[DELETE_ALLOW_FLG] = '1') THEN '1' ELSE '0' END AS [KO_FLG], ");
					sb.Append("OR [PD].[DTIL_KO_FLG] = '1' OR [PS].[DELETE_ALLOW_FLG] <> '0') THEN '1' ELSE '0' END AS [KO_FLG], ");
// 管理番号K22196 To
				}
				else
				{
					sb.Append("'0' AS [KO_FLG], ");
				}
// 管理番号 K16187 To
				sb.Append("ISNULL([PUD].[SA_NO], '') AS [SA_NO],");
				sb.Append("[PO].[PO_DATE],");
// 管理番号K27441 From
				sb.Append("CASE WHEN [PU].[PO_NO] IS NOT NULL ");
				sb.Append(" AND [PO].[DEPT_CODE] <> [PU].[DEPT_CODE] THEN N'1' ");
				sb.Append(" ELSE N'0' ");
				sb.Append(" END AS [PO_DEPT_CODE_FLG], ");
// 管理番号K27441 To
				sb.Append("[E].[EMP_SHORT_NAME], ");
// 管理番号 K20685 From
				sb.Append("[PU].[APPROVAL_CANCEL_FLG],");
// 管理番号 K20685 To
				sb.Append("[O].[DEPT_SHORT_NAME] ");
// 管理番号 B20818 From
				sb.Append(",[PU].[PRG_UPDATE_DATETIME] AS [PRG_UPDATE_DATETIME]");
				sb.Append(",CASE ");
				sb.Append("   WHEN [PU].[PO_NO] IS NOT NULL THEN ISNULL([PO].[PRG_UPDATE_DATETIME],GETDATE()) ");
				sb.Append("   WHEN [R_PO].[PO_NO] IS NOT NULL THEN ISNULL([R_PO].[PRG_UPDATE_DATETIME],GETDATE()) ");
				sb.Append("   WHEN [PU].[REF_PU_NO] IS NOT NULL THEN ISNULL([R_PU].[PRG_UPDATE_DATETIME],GETDATE()) ");
				sb.Append("   ELSE GETDATE()");
				sb.Append(" END AS [REF_PRG_UPDATE_DATETIME] ");
// 管理番号 B20818 To
// 管理番号K24267 From
				sb.Append(",CASE [PU].[PU_MODE_TYPE] ");
				sb.Append("  WHEN '2' THEN ([PU].[KEY_GRAND_TTL] * -1) ");
				sb.Append("  ELSE [PU].[KEY_GRAND_TTL] ");
				sb.Append("END AS [KEY_GRAND_TTL] ");
// 管理番号K24267 To
// 管理番号 K25679 From
				//発注管理番号の取得
				sb.Append(",[PU].[PO_ADMIN_NO] ");
				sb.Append(",[PU].[SUPL_SLIP_NO] ");
				//仕入先伝票番号がNULLでなければ仕入先伝票番号フラグ1とする
				sb.Append(",CASE ");
				sb.Append("		WHEN [PU].[SUPL_SLIP_NO] IS NOT NULL THEN N'1' ");
				sb.Append("		ELSE N'0' ");
				sb.Append("END AS [SUPL_SLIP_NO_FLG] ");
// 管理番号 K25679 To
// 管理番号 K25680 From
				// 取込伝票番号がNULLでなければEDI取込フラグ1とする
				sb.Append(",CASE ");
				sb.Append("		WHEN [PU].[IMPORT_SLIP_NO] IS NOT NULL THEN N'1' ");
				sb.Append("		ELSE N'0' ");
				sb.Append("END AS [IMPORT_SLIP_NO_FLG] ");
// 管理番号 K25680 To
// 管理番号 K25667 From
				sb.Append(", CASE ");
				sb.Append("  WHEN [PU].[RED_SLIP_FLG] = N'1' THEN N'0' ");
				sb.Append("  WHEN [AAF].[SLIP_NO] IS NULL THEN N'0' ");
				sb.Append("  ELSE N'1' ");
				sb.Append("  END AS [ATTACHMENT_EXISTS_FLG] ");
// 管理番号 K25667 To
// 管理番号B25370 From
// 管理番号P27206 From
//				sb.Append(" ,ISNULL([CHARGE_PU].[COUNT], 0) AS [CHARGE_COUNT] ");
				sb.Append(" ,ISNULL([CHARGE_PU].[COUNT], 0) + ISNULL([CHARGE_PU2].[COUNT], 0) AS [CHARGE_COUNT] ");
// 管理番号P27206 To
				sb.Append(" ,ISNULL([PU_REFERRING_TO_I].[COUNT], 0) AS [REFERRING_COUNT] ");
// 管理番号B25370 To
// 管理番号K27057 From
				BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.Header, "SCMM05_PU", searchCondition.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PU", null, null, null);
// 管理番号K27057 To
			}
			else
			{
				sb.Append("SELECT ");
				sb.Append("COUNT(DISTINCT [PU].[PU_NO]) AS [DATACOUNT] ");
			}
			sb.Append("FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]"));
			sb.Append("AS [PU]");
// 管理番号 K22270 From
			sb.Append(" WITH (NOLOCK) ");
			//加入运输
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_ADD]"));
			sb.Append("AS [PUA] WITH (NOLOCK) ON ");
			sb.Append("[PUA].[PU_NO] = [PU].[PU_NO]");
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[CARRIER]"));
			sb.Append(" AS [NEWEST_CAR] WITH (NOLOCK) ON ");
			sb.Append("[NEWEST_CAR].[CARRIER_CODE] = [NEWEST_PUA].[CARRIER_CODE]");		
			// 管理番号 K22270 To
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]"));
// 管理番号 K22270 From
//			sb.Append("AS [PUD] ON ");
			sb.Append(" AS [PUD] WITH (NOLOCK) ON ");
// 管理番号 K22270 To
			sb.Append("[PUD].[PU_NO] = [PU].[PU_NO]");
// 管理番号 K16187 From
			sb.Append(" INNER JOIN ( ");
			sb.Append("            SELECT [PU_NO] ");
			sb.Append("                  ,CASE WHEN MAX(ABS([KO_AMT])) = 0 AND MAX(ABS([APPROVED_KO_AMT])) = 0 THEN 0 ELSE 1 END AS [DTIL_KO_FLG] ");
			sb.Append("              FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]"));
// 管理番号 K22270 From
			sb.Append(" WITH (NOLOCK) ");
// 管理番号 K22270 To
			sb.Append(" GROUP BY [PU_NO] ) AS [PD] ");
			sb.Append("     ON [PD].[PU_NO] = [PU].[PU_NO]");
			if(searchCondition.ApModuleFlg)
			{
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.FI, "[PYMT_STATUS]")).Append(" AS [PS] ");
// 管理番号 K22270 From
				sb.Append(" WITH (NOLOCK) ");
// 管理番号 K22270 To
// 管理番号K22196 From
//				sb.Append("ON [PS].[PYMT_NO] = [PU].[PYMT_NO]");
				sb.Append("ON [PS].[SLIP_NO] = [PU].[PU_NO]");
// 管理番号K22196 To
// 管理番号B24249 From
				sb.Append("	AND [PS].[SLIP_TYPE_CODE]='SM3' ");
// 管理番号B24249 To
			}
// 管理番号 K16187 To
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]"));
// 管理番号 K22270 From
//			sb.Append("[PO] ON ");
			sb.Append("[PO] WITH (NOLOCK) ON ");
// 管理番号 K22270 To
			sb.Append("[PO].[PO_NO] = [PU].[PO_NO]");
			if (searchCondition.RedSlip.Equals("0") && searchCondition.PoDateFrom.Length != 0)
			{
				sb.Append(" AND [PO].[PO_DATE] >= @PO_DATE_FROM ");
			}
			if (searchCondition.RedSlip.Equals("0") && searchCondition.PoDateTo.Length != 0)
			{
				sb.Append(" AND [PO].[PO_DATE] <= @PO_DATE_TO ");
			}
// 管理番号B25370 From
			// 諸掛伝票に按分されているか
			sb.Append(" LEFT JOIN ");
			sb.Append(" ( ");
			sb.Append("   SELECT");
			sb.Append("       [CHARGE_PU_RELATION].[PU_NO]");
// 管理番号P27206 From
//			sb.Append("     , COUNT(*) AS [COUNT] ");
			sb.Append("     , CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END AS [COUNT] ");
// 管理番号P27206 To
			sb.Append("   FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[CHARGE_PU_RELATION]")).Append(" AS [CHARGE_PU_RELATION]");
			sb.Append("   WITH (NOLOCK) ");
			sb.Append("   GROUP BY [CHARGE_PU_RELATION].[PU_NO]");
			sb.Append(" ) AS [CHARGE_PU]");
// 管理番号P27206 From
//			sb.Append(" ON [CHARGE_PU].[PU_NO] IN([PU].[PU_NO], [PU].[REF_PU_NO])");
			sb.Append(" ON [CHARGE_PU].[PU_NO] = [PU].[PU_NO]");
			// 諸掛伝票に仕入返品伝票が按分されているか
			sb.Append(" LEFT JOIN ");
			sb.Append(" ( ");
			sb.Append("   SELECT");
			sb.Append("       [CHARGE_PU_RELATION].[PU_NO]");
			sb.Append("     , CASE WHEN COUNT(*) > 0 THEN 1 ELSE 0 END AS [COUNT] ");
			sb.Append("   FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[CHARGE_PU_RELATION]")).Append(" AS [CHARGE_PU_RELATION]");
			sb.Append("   WITH (NOLOCK) ");
			sb.Append("   GROUP BY [CHARGE_PU_RELATION].[PU_NO]");
			sb.Append(" ) AS [CHARGE_PU2]");
			sb.Append(" ON [CHARGE_PU2].[PU_NO] = [PU].[REF_PU_NO]");
// 管理番号P27206 To

			// 自分を返品した伝票の存在有無を得る
			sb.Append(" LEFT JOIN ");
			sb.Append(" ( ");
			sb.Append("   SELECT");
			sb.Append("       [PU].[REF_PU_NO]");
			sb.Append("     , COUNT(*) AS [COUNT] ");
			sb.Append("   FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			sb.Append("   WITH (NOLOCK) ");
			sb.Append("   WHERE [PU].[OPPOSITE_PU_NO] IS NULL");
			sb.Append("   GROUP BY [PU].[REF_PU_NO]");
			sb.Append(" ) AS [PU_REFERRING_TO_I]");
			sb.Append(" ON [PU_REFERRING_TO_I].[REF_PU_NO] = [PU].[PU_NO]");
// 管理番号B25370 To
// 管理番号K27058 From
			sb.Append(" LEFT JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[MULTIPURPOSE_TYPE]"));
			sb.Append(" AS [MP] WITH (NOLOCK) ON ");
			sb.Append(" [PU].[PU_MODE_TYPE] = [MP].[TYPE_CODE] AND ");
			sb.Append(" [PU].[PU_MODE_TYPE_DTIL_CODE] = [MP].[TYPE_DTIL_CODE] AND ");
			sb.Append(" [MP].[SC_USE_TYPE] = N'1' ");
// 管理番号K27058 To
// 管理番号 B20818 From
			// 仕入(返品)
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [R_PU]");
// 管理番号 K22270 From
			sb.Append(" WITH (NOLOCK) ");
// 管理番号 K22270 To
			sb.Append(" ON  [R_PU].[PU_NO] = [PU].[REF_PU_NO] ");
			// 発注(返品)
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(" AS [R_PO]");
// 管理番号 K22270 From
			sb.Append(" WITH (NOLOCK) ");
// 管理番号 K22270 To
			sb.Append(" ON  [R_PU].[PO_NO] = [R_PO].[PO_NO] ");
// 管理番号 B20818 To
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[EMP]"));
// 管理番号 K22270 From
//			sb.Append("AS [E] ON ");
			sb.Append("AS [E] WITH (NOLOCK) ON ");
// 管理番号 K22270 To
			sb.Append("[E].[EMP_CODE] = [PU].[EMP_CODE]");
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHART]"));
// 管理番号 K22270 From
//			sb.Append("AS [O] ON ");
			sb.Append("AS [O] WITH (NOLOCK) ON ");
// 管理番号 K22270 To
// 管理番号 B15061 From
//			sb.Append("[O].[DEPT_CODE] = [PU].[ORIGIN_DEPT_CODE]");
			sb.Append("[O].[DEPT_CODE] = [PU].[DEPT_CODE]");
// 管理番号 B15061 To
// 管理番号 B23181 From
			if(searchCondition.ApModuleFlg)
			{
// 管理番号 B23181 To
// 管理番号 B21977 From
				//支払
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(" ( ");
				sb.Append("		SELECT ");
				sb.Append("			[PYMT_D].[SLIP_NO] ");
// 管理番号 B22635 From
//				sb.Append("			,[PYMT].[PYMT_CUTOFF_DATE] ");
				sb.Append("			,MAX([PYMT].[PYMT_CUTOFF_DATE]) AS [PYMT_CUTOFF_DATE] ");
// 管理番号 B22635 To
				sb.Append("		FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.FI, "[PYMT_DTIL]")).Append(" AS [PYMT_D]");
				sb.Append("		INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.FI, "[PYMT]")).Append(" AS [PYMT]");
				sb.Append("			ON [PYMT].[PYMT_NO]=[PYMT_D].[PYMT_NO]");
// 管理番号 B24057 From
				sb.Append("			AND (([PYMT].[DT_TYPE] = 'L' AND [PYMT].[OPPOSITE_PYMT_NO] IS NULL) OR [PYMT].[DT_TYPE] = 'E')");
// 管理番号 B24057 To
				sb.Append("		WHERE ");
				sb.Append("			[PYMT_D].[SLIP_TYPE_CODE]='SM3' ");
// 管理番号 B23139 From
//				sb.Append("		AND	[PYMT].[OPPOSITE_PYMT_NO] IS NULL");
// 管理番号 B23139 To
// 管理番号 B22635 From
				sb.Append("		AND	[PYMT].[VALID_FLG] = '1' ");
				sb.Append("		GROUP BY ");
				sb.Append("			[PYMT_D].[SLIP_NO] ");
// 管理番号 B22635 To
				sb.Append(" ) AS [PYMT] ");
				sb.Append(" ON [PYMT].[SLIP_NO]=[PU].[PU_NO] ");
// 管理番号 B21977 To
// 管理番号 B23181 From
			}
// 管理番号 B23181 To
// 管理番号 K25667 From
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(" (SELECT ");
			sb.Append("  [SLIP_NO] ");
			sb.Append(" ,[APPROVAL_ROUTE_TYPE] ");
			sb.Append(" FROM  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[APPROVAL_ATTACHMENT_FILE]"));
			sb.Append(" GROUP BY  ");
			sb.Append("  [SLIP_NO] ");
			sb.Append(" ,[APPROVAL_ROUTE_TYPE] ");
			sb.Append(" ) [AAF] ");
			sb.Append(" ON [PU].[PU_NO] = [AAF].[SLIP_NO] ");
			sb.Append(" AND [AAF].[APPROVAL_ROUTE_TYPE] = ");
			sb.Append(" 	CASE WHEN [PU].[SUPL_SLIP_NO] IS NOT NULL THEN N'CG2' ");
			sb.Append("          ELSE N'SM3' ");
			sb.Append(" 	END ");
// 管理番号 K25667 To

			//検索条件の追加
			WherePhraseBuilder wpb = new WherePhraseBuilder();
			wpb.AddFilter("[NEWEST_PUA].[CARRIER_CODE]", SearchOperator.Equal, searchCondition.CarrierCode);
			// 管理番号K27058 From
			// 仕入計上基準区分
			if (!searchCondition.BookBasisType.Equals("0"))
			{
				wpb.AddFilter("[PU].[BOOK_BASIS_TYPE]", SearchOperator.Equal, searchCondition.BookBasisType);
				wpb.AddFilter("[PU].[BOOK_BASIS_TYPE_DTIL_CODE]", SearchOperator.Equal, searchCondition.BookBasisTypeDtilCode);
			}
// 管理番号K27058 To

			if (searchCondition.RedSlip.Equals("0"))
			{
				if (searchCondition.PuDateFrom.Length != 0)
				{
					wpb.AddFilter("[PU].[PU_DATE]", SearchOperator.GreaterThanEqual, Convert.ToDateTime(searchCondition.PuDateFrom));
				}
				if (searchCondition.PuDateTo.Length != 0)
				{
					wpb.AddFilter("[PU].[PU_DATE]", SearchOperator.LessThanEqual, Convert.ToDateTime(searchCondition.PuDateTo));
				}
				wpb.AddFilter("[PU].[PU_NO]", SearchOperator.GreaterThanEqual, searchCondition.PuNoFrom);
				wpb.AddFilter("[PU].[PU_NO]", SearchOperator.LessThanEqual, searchCondition.PuNoTo);
				wpb.AddFilter("[PU].[SUPL_CODE]", SearchOperator.Equal, searchCondition.SuplCode);
				wpb.AddFilter("[PU].[SUPL_SBNO]", SearchOperator.Equal, searchCondition.SuplSbNo);
				//配下部門を含まない場合
				if (searchCondition.SubDeptSearchFlg.Equals("0"))
				{
// 管理番号 B15061 From
//					wpb.AddFilter("[PU].[ORIGIN_DEPT_CODE]", SearchOperator.Equal, searchCondition.DeptCode);
					wpb.AddFilter("[PU].[DEPT_CODE]", SearchOperator.Equal, searchCondition.DeptCode);
// 管理番号 B15061 To
				}
				wpb.AddFilter("[PU].[EMP_CODE]", SearchOperator.Equal, searchCondition.EmpCode);
// 管理番号 K22205 From
                wpb.AddFilter("[PU].[INPUT_EMP_CODE]", SearchOperator.Equal, searchCondition.InputEmpCode);
// 管理番号 K22205 To
				wpb.AddFilter("[PU].[PROJ_CODE]", SearchOperator.Equal, searchCondition.ProjCode);
				wpb.AddFilter("[PU].[PROJ_SBNO]", SearchOperator.Equal, searchCondition.ProjSbNo);
				wpb.AddFilter("[PU].[PO_NO]", SearchOperator.GreaterThanEqual, searchCondition.PoNoFrom);
				wpb.AddFilter("[PU].[PO_NO]", SearchOperator.LessThanEqual, searchCondition.PoNoTo);
				if (searchCondition.PoDateFrom.Length != 0 || searchCondition.PoDateTo.Length != 0)
				{
					wpb.AddFilter("[PO].[PO_DATE]", SearchOperator.NotEqual, DBNull.Value);
				}
				wpb.AddFilter("[PU].[SUPL_BILL_SLIP_NO]", SearchOperator.Equal, searchCondition.SuplBillSlipNo);
				wpb.AddFilter("[PUD].[PROD_CODE]", SearchOperator.Equal, searchCondition.ProdCode);
				if (!searchCondition.PuModeType.Equals("0"))
				{
					wpb.AddFilter("[PU].[PU_MODE_TYPE]", SearchOperator.Equal, searchCondition.PuModeType);
// 管理番号K27058 From
					wpb.AddFilter("[PU].[PU_MODE_TYPE_DTIL_CODE]", SearchOperator.Equal, searchCondition.PuModeTypeDtilCode);
// 管理番号K27058 To
				}
				if (!searchCondition.ApprovalStatusType.Equals("0"))
				{
// 管理番号 K20685 From
//					wpb.AddFilter("[PU].[APPROVAL_STATUS_TYPE]", SearchOperator.Equal, searchCondition.ApprovalStatusType);
					if(!searchCondition.ApprovalStatusType.Equals("6"))
					{
						wpb.AddFilter("[PU].[APPROVAL_STATUS_TYPE]", SearchOperator.Equal, searchCondition.ApprovalStatusType);
					}
					else
					{
						wpb.AddFilter("[PU].[APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "3");
						wpb.AddFilter("[PU].[APPROVAL_CANCEL_FLG]", SearchOperator.Equal, "1");
					}
// 管理番号 K20685 To
				}
				wpb.AddFilter("[PU].[OPPOSITE_PU_NO]", SearchOperator.Equal, DBNull.Value);
				wpb.AddFilter("[PU].[OVERSEAS_FLG]", SearchOperator.Equal, searchCondition.OverseasFlg);
// 管理番号 B13878 From
				wpb.AddFilter("[PUD].[PRICE_UNDECIDED_FLG]",SearchOperator.Equal,searchCondition.PriceUndecided);
// 管理番号 B13878 To
// 管理番号 B21232 From
//// 管理番号 K16764 From
//				wpb.AddFilter("[PU].[HOLD_FLG]",SearchOperator.Equal,searchCondition.HoldFlg);
//// 管理番号 K16764 To
				//支払保留フラグが'0':全ての場合は検索条件に含めない
				if (!searchCondition.HoldFlg.Equals("0"))
				{
					wpb.AddFilter("[PU].[HOLD_FLG]",SearchOperator.Equal,searchCondition.HoldFlg);
				}
// 管理番号 B21232 To
// 管理番号 K25679 From
				//仕入先伝票番号が入力されていれば検索条件に追加
				if(searchCondition.SuplSlipNo.Length != 0)
				{
					wpb.AddFilter("[PU].[SUPL_SLIP_NO]", SearchOperator.Equal, searchCondition.SuplSlipNo);
				}
				//発注管理番号が入力されていれば検索条件に追加
				if(searchCondition.PoAdminNo.Length != 0)
				{
					wpb.AddFilter("[PU].[PO_ADMIN_NO]",SearchOperator.Equal,searchCondition.PoAdminNo);
				}
// 管理番号 K25679 To
// 管理番号 K25680 From
				//発生元ドロップダウンリストの値に応じて検索条件を追加。ブランクのときは追加しない
				switch(searchCondition.OriginType)
				{
					//1:「仕入」が選択されていたら取込伝票番号がNULLのデータのみ取得
					case "1":
						wpb.AddFilter("[PU].[IMPORT_SLIP_NO]", SearchOperator.Equal, DBNull.Value);
						break;
					//2:「外部」が選択されていたら取込伝票番号がNULLでないデータのみ取得
					case "2":
						wpb.AddFilter("[PU].[IMPORT_SLIP_NO]", SearchOperator.NotEqual, DBNull.Value);
						break;
				}
// 管理番号 K25680 To
// 管理番号K27057 From
				BL_CM_MS_CustomItem.SetSqlCondition(commonData, BL_CM_MS_CustomItem.ListHead, "SCMM05_PU", searchCondition.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, searchCondition.CustomItemHead, wpb, "PU");
				BL_CM_MS_CustomItem.SetSqlCondition(commonData, BL_CM_MS_CustomItem.ListDetail, "SCMM05_PU", searchCondition.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, searchCondition.CustomItemDtil, wpb, "PUD");
// 管理番号K27057 To
// 管理番号K27154 From
				// 取引区分
				wpb.AddFilter("[PU].[DEAL_TYPE_CODE]", SearchOperator.Equal, searchCondition.DealTypeCode);
// 管理番号K27154 To
				sb.Append(wpb);

				//配下部門を含む場合
// 管理番号 B24028 From
//				if (searchCondition.SubDeptSearchFlg.Equals("1"))
				if (searchCondition.SubDeptSearchFlg.Equals("1") && searchCondition.DeptCode.Length != 0)
// 管理番号 B24028 To
				{
					sb.Append(" AND EXISTS (SELECT [DEPT_CODE] FROM ");
					sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetLowerDeptLevel]"));
// 管理番号 B15061 From
//					sb.Append("(@DeptCode, @Date) [TEMP_DEPTLEVEL] WHERE [PU].[ORIGIN_DEPT_CODE] = [TEMP_DEPTLEVEL].[DEPT_CODE]) ");
					sb.Append("(@DeptCode, @Date) [TEMP_DEPTLEVEL] WHERE [PU].[DEPT_CODE] = [TEMP_DEPTLEVEL].[DEPT_CODE]) ");
// 管理番号 B15061 To
				}
				sb.Append(" AND [O].[ORG_CHANGE_ID] = ");
				sb.Append("(");
				sb.Append("SELECT MAX([ORG_CHANGE].[ORG_CHANGE_ID]) FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHANGE]"));
				sb.Append(" AS [ORG_CHANGE] ");
// 管理番号 B15061 From
//				sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= GETDATE()");
				sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <  '9998/12/31' ");
// 管理番号 B15061 To
				sb.Append(")");

				if (selectType)
				{
					//ORDER句の追加
					sb.Append(" ORDER BY [PU].[PU_DATE] DESC, [PU].[PU_NO] DESC");
				}
			}
			else
			{
				sb.Append("WHERE [PU].[ORIGIN_PU_NO] IN (");

				sb.Append("SELECT DISTINCT ");
				sb.Append("[NEWEST_PU].[ORIGIN_PU_NO] ");
				sb.Append("FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]"));
				sb.Append("AS [NEWEST_PU]");
// 管理番号 K22270 From
			sb.Append(" WITH (NOLOCK) ");
// 管理番号 K22270 To
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]"));
// 管理番号 K22270 From
//				sb.Append("AS [NEWEST_PUD] ON ");
				sb.Append("AS [NEWEST_PUD] WITH (NOLOCK) ON ");
// 管理番号 K22270 To
				sb.Append("[NEWEST_PUD].[PU_NO] = [NEWEST_PU].[PU_NO]");
				
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]"));
// 管理番号 K22270 From
//				sb.Append("[NEWEST_PO] ON ");
				sb.Append("[NEWEST_PO] WITH (NOLOCK) ON ");
// 管理番号 K22270 To
				sb.Append("[NEWEST_PO].[PO_NO] = [NEWEST_PU].[PO_NO]");
				if (searchCondition.PoDateFrom.Length != 0)
				{
					sb.Append(" AND [NEWEST_PO].[PO_DATE] >= @PO_DATE_FROM ");
				}
				if (searchCondition.PoDateTo.Length != 0)
				{
					sb.Append(" AND [NEWEST_PO].[PO_DATE] <= @PO_DATE_TO ");
				}
				if (searchCondition.PuDateFrom.Length != 0)
				{
					wpb.AddFilter("[NEWEST_PU].[PU_DATE]", SearchOperator.GreaterThanEqual, Convert.ToDateTime(searchCondition.PuDateFrom));
				}
				if (searchCondition.PuDateTo.Length != 0)
				{
					wpb.AddFilter("[NEWEST_PU].[PU_DATE]", SearchOperator.LessThanEqual, Convert.ToDateTime(searchCondition.PuDateTo));
				}
				wpb.AddFilter("[NEWEST_PU].[PU_NO]",		SearchOperator.GreaterThanEqual, searchCondition.PuNoFrom);
				wpb.AddFilter("[NEWEST_PU].[PU_NO]",		SearchOperator.LessThanEqual, searchCondition.PuNoTo);
				wpb.AddFilter("[NEWEST_PU].[SUPL_CODE]",	SearchOperator.Equal, searchCondition.SuplCode);
				wpb.AddFilter("[NEWEST_PU].[SUPL_SBNO]",	SearchOperator.Equal, searchCondition.SuplSbNo);

				//配下部門を含まない場合
				if (searchCondition.SubDeptSearchFlg.Equals("0"))
				{
// 管理番号 B15061 From
//					wpb.AddFilter("[NEWEST_PU].[ORIGIN_DEPT_CODE]", SearchOperator.Equal, searchCondition.DeptCode);
					wpb.AddFilter("[NEWEST_PU].[DEPT_CODE]", SearchOperator.Equal, searchCondition.DeptCode);
// 管理番号 B15061 From
				}
				wpb.AddFilter("[NEWEST_PU].[EMP_CODE]",		SearchOperator.Equal, searchCondition.EmpCode);
// 管理番号 K22205 From
                wpb.AddFilter("[NEWEST_PU].[INPUT_EMP_CODE]", SearchOperator.Equal, searchCondition.InputEmpCode);
// 管理番号 K22205 To
				wpb.AddFilter("[NEWEST_PU].[PROJ_CODE]",	SearchOperator.Equal, searchCondition.ProjCode);
				wpb.AddFilter("[NEWEST_PU].[PROJ_SBNO]",	SearchOperator.Equal, searchCondition.ProjSbNo);
				wpb.AddFilter("[NEWEST_PU].[PO_NO]",		SearchOperator.GreaterThanEqual, searchCondition.PoNoFrom);
				wpb.AddFilter("[NEWEST_PU].[PO_NO]",		SearchOperator.LessThanEqual, searchCondition.PoNoTo);
				if (searchCondition.PoDateFrom.Length != 0 || searchCondition.PoDateTo.Length != 0)
				{
					wpb.AddFilter("[NEWEST_PO].[PO_DATE]", SearchOperator.NotEqual, DBNull.Value);
				}
				wpb.AddFilter("[NEWEST_PU].[SUPL_BILL_SLIP_NO]", SearchOperator.Equal, searchCondition.SuplBillSlipNo);
				wpb.AddFilter("[NEWEST_PUD].[PROD_CODE]", SearchOperator.Equal, searchCondition.ProdCode);
				if (!searchCondition.PuModeType.Equals("0"))
				{
					wpb.AddFilter("[NEWEST_PU].[PU_MODE_TYPE]", SearchOperator.Equal, searchCondition.PuModeType);
// 管理番号K27058 From
					wpb.AddFilter("[NEWEST_PU].[PU_MODE_TYPE_DTIL_CODE]", SearchOperator.Equal, searchCondition.PuModeTypeDtilCode);
// 管理番号K27058 To
				}
// 管理番号K27058 From
				// 仕入計上基準区分
				if (!searchCondition.BookBasisType.Equals("0"))
				{
					wpb.AddFilter("[NEWEST_PU].[BOOK_BASIS_TYPE]", SearchOperator.Equal, searchCondition.BookBasisType);
					wpb.AddFilter("[NEWEST_PU].[BOOK_BASIS_TYPE_DTIL_CODE]", SearchOperator.Equal, searchCondition.BookBasisTypeDtilCode);
				}
// 管理番号K27058 To
				if (!searchCondition.ApprovalStatusType.Equals("0"))
				{
// 管理番号 K20685 From
//					wpb.AddFilter("[NEWEST_PU].[APPROVAL_STATUS_TYPE]", SearchOperator.Equal, searchCondition.ApprovalStatusType);
					if(!searchCondition.ApprovalStatusType.Equals("6"))
					{
						wpb.AddFilter("[NEWEST_PU].[APPROVAL_STATUS_TYPE]", SearchOperator.Equal, searchCondition.ApprovalStatusType);
					}
					else
					{
						wpb.AddFilter("[NEWEST_PU].[APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "3");
						wpb.AddFilter("[NEWEST_PU].[APPROVAL_CANCEL_FLG]", SearchOperator.Equal, "1");
					}
// 管理番号 K20685 To
				}
				wpb.AddFilter("[NEWEST_PU].[OVERSEAS_FLG]", SearchOperator.Equal, searchCondition.OverseasFlg);

// 管理番号 B13878 From
				wpb.AddFilter("[NEWEST_PUD].[PRICE_UNDECIDED_FLG]",SearchOperator.Equal,searchCondition.PriceUndecided);
// 管理番号 B13878 To
// 管理番号 B21232 From
//// 管理番号 K16764 From
//				wpb.AddFilter("[NEWEST_PU].[HOLD_FLG]",SearchOperator.Equal,searchCondition.HoldFlg);
//// 管理番号 K16764 To
				//支払保留フラグが'0':全ての場合は検索条件に含めない
				if (!searchCondition.HoldFlg.Equals("0"))
				{
					wpb.AddFilter("[NEWEST_PU].[HOLD_FLG]",SearchOperator.Equal,searchCondition.HoldFlg);
				}
// 管理番号 B21232 To
// 管理番号 K25679 From
				//仕入先伝票番号が入力されていれば検索条件に追加
				if(searchCondition.SuplSlipNo.Length != 0)
				{
// 管理番号B26700 From
//					wpb.AddFilter("[PU].[SUPL_SLIP_NO]", SearchOperator.Equal, searchCondition.SuplSlipNo);
					wpb.AddFilter("[NEWEST_PU].[SUPL_SLIP_NO]", SearchOperator.Equal, searchCondition.SuplSlipNo);
// 管理番号B26700 To
				}
				//発注管理番号が入力されていれば検索条件に追加
				if(searchCondition.PoAdminNo.Length != 0)
				{
// 管理番号B26700 From
//					wpb.AddFilter("[PU].[PO_ADMIN_NO]",SearchOperator.Equal,searchCondition.PoAdminNo);
					wpb.AddFilter("[NEWEST_PU].[PO_ADMIN_NO]", SearchOperator.Equal, searchCondition.PoAdminNo);
// 管理番号B26700 To
				}
// 管理番号 K25679 To
// 管理番号 K25680 From
				//発生元ドロップダウンリストの値に応じて検索条件を追加。ブランクのときは追加しない
				switch(searchCondition.OriginType)
				{
					//1:「仕入」が選択されていたら取込伝票番号がNULLのデータのみ取得
					case "1":
// 管理番号B26700 From
//						wpb.AddFilter("[PU].[IMPORT_SLIP_NO]", SearchOperator.Equal, DBNull.Value);
						wpb.AddFilter("[NEWEST_PU].[IMPORT_SLIP_NO]", SearchOperator.Equal, DBNull.Value);
// 管理番号B26700 To
						break;
					//2:「外部」が選択されていたら取込伝票番号がNULLでないデータのみ取得
					case "2":
// 管理番号B26700 From
//						wpb.AddFilter("[PU].[IMPORT_SLIP_NO]", SearchOperator.NotEqual, DBNull.Value);
						wpb.AddFilter("[NEWEST_PU].[IMPORT_SLIP_NO]", SearchOperator.NotEqual, DBNull.Value);
// 管理番号B26700 To
						break;
				}
// 管理番号 K25680 To
// 管理番号K27057 From
				BL_CM_MS_CustomItem.SetSqlCondition(commonData, BL_CM_MS_CustomItem.ListHead, "SCMM05_PU", searchCondition.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, searchCondition.CustomItemHead, wpb, "NEWEST_PU");
				BL_CM_MS_CustomItem.SetSqlCondition(commonData, BL_CM_MS_CustomItem.ListDetail, "SCMM05_PU", searchCondition.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, searchCondition.CustomItemDtil, wpb, "NEWEST_PUD");
// 管理番号K27057 To
// 管理番号K27154 From
				// 取引区分
				wpb.AddFilter("[NEWEST_PU].[DEAL_TYPE_CODE]", SearchOperator.Equal, searchCondition.DealTypeCode);
// 管理番号K27154 To
				sb.Append(wpb);
// 管理番号B26700 From
//				sb.Append(")");
// 管理番号B26700 To

				//配下部門を含む場合
// 管理番号 B24028 From
//				if (searchCondition.SubDeptSearchFlg.Equals("1"))
				if (searchCondition.SubDeptSearchFlg.Equals("1") && searchCondition.DeptCode.Length != 0)
// 管理番号 B24028 To
				{
					sb.Append(" AND EXISTS (SELECT [DEPT_CODE] FROM ");
					sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetLowerDeptLevel]"));
// 管理番号B26700 From
//// 管理番号 B15061 From
////					sb.Append("(@DeptCode, @Date) [TEMP_DEPTLEVEL] WHERE [PU].[ORIGIN_DEPT_CODE] = [TEMP_DEPTLEVEL].[DEPT_CODE]) ");
//					sb.Append("(@DeptCode, @Date) [TEMP_DEPTLEVEL] WHERE [PU].[DEPT_CODE] = [TEMP_DEPTLEVEL].[DEPT_CODE]) ");
//// 管理番号 B15061 To
					sb.Append("(@DeptCode, @Date) [TEMP_DEPTLEVEL] WHERE [NEWEST_PU].[DEPT_CODE] = [TEMP_DEPTLEVEL].[DEPT_CODE]) ");
// 管理番号B26700 To
				}
				sb.Append(" AND [O].[ORG_CHANGE_ID] = ");
				sb.Append("(");
				sb.Append("SELECT MAX([ORG_CHANGE].[ORG_CHANGE_ID]) FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHANGE]"));
				sb.Append(" AS [ORG_CHANGE] ");
// 管理番号 K22270 From
			sb.Append(" WITH (NOLOCK) ");
// 管理番号 K22270 To
// 管理番号 B15061 From
//				sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= GETDATE()");
				sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <  '9998/12/31' ");
// 管理番号 B15061 To
				sb.Append(")");
// 管理番号B26700 From
				sb.Append(")");
// 管理番号B26700 To

				if (selectType)
				{
					//ORDER句の追加
					sb.Append(" ORDER BY [PU].[ORIGIN_PU_NO] DESC, [PU].[PU_NO] DESC");
				}
			}

			DataTable dt = new DataTable();
			SqlDataAdapterWrapper da;

			try
            {
				string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "output.txt");
                try
                {
					System.IO.File.WriteAllText(filePath,sb.ToSqlPString().toString());
				}
                catch 
                {
                }
				da = new SqlDataAdapterWrapper(sb.ToSqlPString(), cn);    // 管理番号K27230
			}
            catch (Exception ex)
            {
                throw new Exception(sb.ToSqlPString().ToString());
            }
// 管理番号 P18435 From
			DBTimeout.setTimeout(da, commonData);
// 管理番号 P18435 To
			da.SelectCommand.Parameters.Add("@DeptCode",SqlDbType.NVarChar,10).Value	= ConvertDBData.ToNVarChar(searchCondition.DeptCode);
// 管理番号 B24028 From
//			da.SelectCommand.Parameters.Add("@Date",SqlDbType.DateTime).Value			= ConvertDBData.ToDateTime(DateTime.Today.ToString());
			if (searchCondition.PuDateTo != string.Empty)
			{
				da.SelectCommand.Parameters.Add("@Date", SqlDbType.DateTime).Value =
					ConvertDBData.ToNVarChar(searchCondition.PuDateTo);
			}
			else if (searchCondition.PuDateFrom != string.Empty)
			{
				da.SelectCommand.Parameters.Add("@Date", SqlDbType.DateTime).Value =
					ConvertDBData.ToNVarChar(searchCondition.PuDateFrom);
			}
			else
			{
				da.SelectCommand.Parameters.Add("@Date", SqlDbType.DateTime).Value =
					ConvertDBData.ToDateTime(DateTime.Today.ToString("yyyy/MM/dd"));
			}
// 管理番号 B24028 To
			da.SelectCommand.Parameters.Add("@PO_DATE_FROM",SqlDbType.DateTime).Value	= ConvertDBData.ToDateTime(searchCondition.PoDateFrom);
			da.SelectCommand.Parameters.Add("@PO_DATE_TO",SqlDbType.DateTime).Value		= ConvertDBData.ToDateTime(searchCondition.PoDateTo);
            try
            {
				da.Fill(dt);
			}
            catch (Exception ex)
            {
				throw new Exception(ex.Message + ex.StackTrace);
            }
			return dt;
		}
		/// <summary>
		/// 
		/// </summary>
		/// <param name="commonData"></param>
		/// <param name="control"></param>
		/// <returns></returns>
		public static DataTable GetCarriers(CommonData commonData, Web.WebControls.CustomDropDownList control)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT CARRIER_CODE,CARRIER_NAME FROM [R_1_1_0_SC].[dbo].[CARRIER] order by CARRIER_CODE");
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			DataTable dt=new DataTable ();
			cn.Open();
			SqlDataAdapterWrapper da = new SqlDataAdapterWrapper(sb.ToString(), cn);
			DBTimeout.setTimeout(da, commonData);
			try
			{
				da.Fill(dt);
				control.DataSource = dt;
				control.DataValueField = "CARRIER_CODE";
				control.DataTextField = "CARRIER_NAME";
				control.DataBind();                
			}
			finally
			{
				cn.Close();
			}
			return dt;

		}
		public static DataTable Select(IF_SC_MM_05_S01_SearchCondition searchCondition, CommonData commonData, bool selectType)
		{
//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			DataTable dt;
			cn.Open();
			try
			{
				dt = Select(searchCondition, commonData, cn, selectType);
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				cn.Close();
			}
			return dt;
		}
		#endregion
	}
}
