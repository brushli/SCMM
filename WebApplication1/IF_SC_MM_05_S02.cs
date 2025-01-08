// Product     : Allegro
// Unit        : SC
// Module      : MM
// Function    : 05
// File Name   : IF_SC_MM_05_S02.cs
// 機能名      : SC_MM_05_S02 仕入入力
// Version     : 2.1.0
// Last Update : 2013/03/31
// Copyright (c) 2004-2013 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 管理番号 K24285 2012/01/16 売上・仕入マイナス数量入力対応
// 2.0.0 2012/10/31
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31

using System;
using System.Data;
using Infocom.Allegro.IF;
using Infocom.Allegro.CM.MS;
using Infocom.Allegro.SC.MS;

namespace Infocom.Allegro.SC
{
	[Serializable()]
	public class IF_SC_MM_05_S02_RowData : IF_SC_MM_05_RowData
	{
		#region Protected Fields
		#endregion

		#region Constructors
		public IF_SC_MM_05_S02_RowData() : base(){}
		#endregion

		#region virtual Properties
		#endregion

		#region override Properties
		#endregion

		#region Methods
		//行更新時チェック(数量)
		protected override bool ValidateRowQt(IF_SC_MM_05_DetailRowData detail)
		{
			//入荷済み明細行、又は返品時
			if (detail.IsRcptExecute=="1" || this.puModeType=="2")
			{
				if (detail.UpperLimitPuQt > 0 && detail.PuQt > detail.UpperLimitPuQt)
				{
					if (this.puModeType=="2")
					{
						AddErrorMessage(AllegroMessage.SC_MM_05_S02_06);
					}
					else
					{
						AddErrorMessage(AllegroMessage.SC_MM_05_S02_05);
					}
					return false;
				}
			}
// 管理番号 K24285 From
			//仕入参照返品時
			if (this.puModeType == "2" && this.refPuNo.Length > 0)
			{
				if (detail.UpperLimitPuQt > 0 && detail.PuQt < 0)
				{
					//プラス仕入数(初期値)の場合、マイナス返品数量の入力不可
					AddErrorMessage(AllegroMessage.SC_MM_05_S02_13);
					return false;
				}
				else if (detail.UpperLimitPuQt < 0 && detail.PuQt < detail.UpperLimitPuQt)
				{
					//マイナス仕入数(初期値)の場合、初期値以下の入力不可
					AddErrorMessage(AllegroMessage.SC_MM_05_S02_11);
					return false;
				}
				else if (detail.UpperLimitPuQt < 0 && detail.PuQt > 0)
				{
					//マイナス仕入数(初期値)の場合、プラス返品数量の入力不可
					AddErrorMessage(AllegroMessage.SC_MM_05_S02_12);
					return false;
				}
			}
// 管理番号 K24285 To
			//明細の数量とロット明細の合計数量が不一致
			int count = this.lotDt.Select("ROW_ID =" + detail.PuLineId).Length;
			if (count > 0)
			{
				object objSum = this.lotDt.Compute("SUM([EDIT_QT])", "[ROW_ID]=" + detail.PuLineId);
				decimal lotSumQt = objSum is decimal ? (decimal)objSum : 0M;

				if (detail.PuQt != lotSumQt)
				{
// 					AddErrorMessage(AllegroMessage.S10042("明細の数量", "ロット明細の合計数量")); //K24546
					AddErrorMessage(AllegroMessage.S10042(MultiLanguage.Get("SC_CS005477"), MultiLanguage.Get("SC_CS002910")));
					return false;
				}
			}
			//入荷済み明細行、又は返品時
			//if (poNo.Length > 0 && this.puModeType!="2")
			if (detail.PoLineId != 0 && this.puModeType!="2")
			{
				if (detail.StockUnitPuQt > detail.StockUnitPoPuQt)
				{
					HasWarning = true;
// 					AddErrorMessage(AllegroMessage.SC_MS_S10033("発注数量", "仕入数量")); //K24546
					AddErrorMessage(AllegroMessage.SC_MS_S10033(MultiLanguage.Get("SC_CS001775"), MultiLanguage.Get("SC_CS003660")));
				}
			}
			return true;
		}
		#endregion
	}

	[Serializable()]
	public class IF_SC_MM_05_S02_DetailRowData : IF_SC_MM_05_DetailRowData
	{
		#region protected Fields
		#endregion
				
		#region Properties PU_DTIL
		#endregion

		#region Methods
		#endregion
	}

	[Serializable()]
	public class IF_SC_MM_05_S02_AmtTtlInfo : IF_SC_MM_05_AmtTtlInfo
	{
	}

	[Serializable()]
	public class IF_SC_MM_05_S02_KeyColumn : IF_SC_MM_05_KeyColumn
	{
		// 継承してるだけ
	}
}
