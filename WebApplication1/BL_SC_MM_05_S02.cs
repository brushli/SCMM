// Product     : Allegro
// Unit        : SC
// Module      : MM
// Function    : 05
// File Name   : BL_SC_MM_05_S02.cs
// 機能名      : SC_MM_05_S02 仕入入力
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 1.6.0 2009/09/30
// 管理番号 B24188 2012/04/24 計上日の月度で債権債務締処理がされていると支払保留が解除できない。
// 2.0.0 2012/10/31
// 管理番号 B23437 2014/07/22 出合にて支払保留の場合、債権へ連動すると支払保留解除ができない不具合を修正
// 2.2.0 2014/10/31
// 2.3.0 2016/06/30
// 管理番号B25595 2016/09/05 ロット番号を変更すると入荷数より返品数が多くなる不具合を修正
// 3.0.0 2018/04/30

using System;
using System.Collections;
using System.Data;
using System.Text;
using Infocom.Allegro.BL.SqlClient;
using Infocom.Allegro.IF;

namespace Infocom.Allegro.SC
{
	public sealed class BL_SC_MM_05_S02 : MarshalByRefObject
	{
		#region Constructors
		private BL_SC_MM_05_S02()
		{
		}
		#endregion

		#region Static Methods
		//参照
		public static IF_SC_MM_05_S02_RowData Select(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn)
		{
			IF_SC_MM_05_S02_RowData rowData = new IF_SC_MM_05_S02_RowData();

			keyColumn.OverseasFlg      = "0";	//海外フラグ
			//			keyColumn.CanceledOrderFlg = "0";	//出合フラグ
			rowData = (IF_SC_MM_05_S02_RowData) BL_SC_MM_05.Select(commonData, keyColumn, rowData);

			//行番号設定
			rowData.SetLineNo();

			//デフォルト行数
			rowData.DefaultRowCount = rowData.Count;

			//ロット初期値
			rowData.LotDtBackUp = rowData.LotDt.Copy();

			return rowData;
		}

		//更新
		public static IF_SC_MM_05_S02_RowData Insert_Update(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_S02_RowData validRowData)
		{
			IF_SC_MM_05_S02_RowData rowData = new IF_SC_MM_05_S02_RowData();
			bool ret = false;

			//更新前チェック
			string errorMsg = Validate(commonData, keyColumn, validRowData);
			if (errorMsg != null)
			{
				throw new AllegroException(commonData, ExceptionLevel.Error, errorMsg);
			}

			if (keyColumn.ParamType=="Mod")
			{
				//変更有無のチェック（明細変更フラグ）
				if (validRowData.DefaultRowCount != validRowData.ValidCount)
				{
					validRowData.DtilChangedFlg = "1";
				}

				//更新
				ret = BL_SC_MM_05.Update(commonData, keyColumn, validRowData);
				if (ret)
				{
					//赤黒伝票が発生している場合
					if (validRowData.PuNo.Length!=0)
					{
						keyColumn.SlipNo = validRowData.PuNo;
					}
					rowData = Select(commonData, keyColumn);
				}
			}
			else
			{
				//登録
				ret = BL_SC_MM_05.Insert(commonData, keyColumn, validRowData);
				rowData = validRowData;
			}
			return rowData;
		}
		//更新前チェック
		private static string Validate(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_RowData rowData)
		{
			return null;
		}
// 管理番号 B24188 From
		// 支払保留解除
		public static IF_SC_MM_05_S02_RowData HoldRelease(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_S02_RowData validRowData)
		{
			IF_SC_MM_05_S02_RowData rowData = new IF_SC_MM_05_S02_RowData();
			bool ret = false;

			//保留解除
			ret = BL_SC_MM_05.HoldRelease(commonData, validRowData);
			if (ret)
			{
				rowData = Select(commonData, keyColumn);
			}
			else
			{
				rowData = validRowData;
			}
			return rowData;
		}
// 管理番号 B24188 To
// 管理番号 B23437 From
		public static string GetSaNo(CommonData commonData, string slipNo)
		{
			return BL_SC_MM_05.GetSaNo(commonData, slipNo);
		}
// 管理番号 B23437 To
// 管理番号B25595 From
		public static int CheckPuLot(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn, decimal lineID, IF_SC_MM_05_RowData rowData)
		{
			return BL_SC_MM_05.CheckPuLot(commonData, keyColumn, lineID, rowData);
		}
// 管理番号B25595 To
		#endregion
	}
}
