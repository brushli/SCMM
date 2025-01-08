// Product     : Allegro
// Unit        : SC
// Module      : MM
// Function    : 05
// File Name   : BL_SC_MM_05.cs
// 機能名      : 仕入管理
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 管理番号 B06162 2004/09/06 仕入数量桁数の修正
// 管理番号 B12528 2004/09/08 部門名取得ロジックの修正
// 管理番号 B12917 2004/09/22 日付に関する赤黒処理の修正
// 管理番号 B11723・B11796 2004/09/17 原価・粗利額等の丸め処理統一
// 1.2.2 2004/10/31
// 管理番号 B13500 2004/11/17 入荷省略のチェックボックス使用可に変更対応
// 管理番号 B13569 2004/11/19 発注参照時の予約区分「予約あり」対応
// 管理番号 B13469 2004/11/20 パラメータの桁数を変更
// 管理番号 B13500 2004/11/29 輸入業務の入荷対応
// 管理番号 B13798 2004/11/29 管理項目の追加
// 管理番号 B13502 2004/12/06 国内取引外貨決済対応
// 1.3.0 2004/12/31
// 管理番号 B14028 2004/01/10 オーバーフローに対する対応
// 1.3.1 2005/01/31
// 管理番号 B13877 2005/01/21 プロジェクト別在庫管理対応
// 管理番号 B13878 2005/02/10 売上・仕入時の単価未決対応
// 管理番号 B14315 2005/03/31 入荷省略しない海外仕入返品対応
// 管理番号 K00013 2005/02/22 明細消込対応
// 管理番号 B14455 2005/03/10 何も変更しない時の赤黒される不具合対応
// 管理番号 B14704 2005/03/19 入荷発生後の仕入の赤黒時の不具合対応
// 1.3.2 2005/03/31
// 管理番号 B12929 仕入先別単価設定対応
// 管理番号 B15804 2005/06/14 入荷参照時に新規行登録を行うと入荷されていない商品まで入荷済みになる不具合を修正
// 1.3.3 2005/06/30
// 管理番号 B15710 2005/08/03 レスポンス是正対応
// 管理番号 K16187 2005/09/06 支払機能拡張対応
// 1.4.0 2005/10/31
// 管理番号 B16573 2005/10/31 仕入入力、仕入一覧から伝票を修正モードで開こうとするとエラーになる不具合対応
// 管理番号 K16588 2005/11/14 プロジェクトコード桁数拡張対応
// 管理番号 K16590 2005/11/24 管理会計機能拡張（日付チェック機能強化対応）
// 管理番号 B17566 2006/03/15 赤黒されている入荷に紐付いている仕入伝票を返品しようとするとエラーになる不具合対応
// 管理番号 B17564 2006/03/28 残クローズされている発注を参照している伝票を削除できないよう修正
// 1.5.0 2006/03/31
// 管理番号 B17672 2006/05/11 入荷済みの仕入明細を削除すると、発注伝票の入荷数量の値が不正となる不具合対応
// 管理番号 B18174 2006/06/09 発注残クローズ後に仕入伝票を修正更新すると表示されるエラーメッセージが不正である不具合対応
// 管理番号 P18435 2007/01/10 パフォーマンス対応（2006年9月末分）：タイムアウト値延長
// 管理番号 B18394 2007/01/10 海外仕入の仕入返品で複数の入荷伝票が存在している仕入伝票を参照した際エラーが発生する不具合を修正
// 管理番号 B18267 2007/01/10 商品単位マスタが無効の場合の対応
// 管理番号 B18774 2007/01/10 海外仕入一覧で、履歴伝票参照ありで発注日を入れて検索した後に、印刷するとエラーとなる不具合対応用のメソッド追加
// 管理番号 B19111 2007/01/10 海外仕入入力にて、ロット管理する商品明細を含む伝票を修正で表示した際にエラーとなる不具合を修正
// 管理番号 B18702 2007/01/10 海外仕入入力にて国内発注伝票が参照できないよう修正
// 管理番号 B18703 2007/01/10 仕入入力にて海外発注伝票が参照できないよう修正
// 管理番号 B18904 2007/01/10 海外仕入更新時の税率チェック不具合対応
// 管理番号 B19191 2007/01/10 仕入返品を複数回行うと仕入返品伝票の在庫単位仕入数量が不正な値になる不具合対応
// 管理番号 B19369 2007/01/10 入荷省略しない海外仕入返品時は入荷参照とするよう修正
// 管理番号 B19475 2007/02/13 取引先別商品名対応
// 管理番号 B20244 2007/02/14 入数が複数の商品を登録し伝票を赤黒修正すると、新黒伝票の在庫単位仕入数量が画面で入力された数量で更新される不具合対応
// 1.5.1 2007/06/30
// 管理番号 K20687 2007/07/06 内部統制強化：計上基準追加対応
// 管理番号 K20685 2007/07/24 ワークフロー取消機能改善
// 管理番号 K20684 2007/08/07 承認機能追加
// 管理番号 B20741 2007/08/15 在庫を赤黒処理した場合に、在庫不足のチェックが行われない不具合の対応
// 1.5.2 2007/10/31
// 管理番号 B20818 2007/12/17 楽観ロック対応
// 管理番号 B20718 2008/01/07 無効商品時に行更新を行うとアプリケーションエラーが発生する不具合の対応
// 管理番号 B21602 2008/06/17 入荷参照して海外仕入返品を行うと、仕入先の支払条件がコピーされない不具合を修正
// 管理番号 K22205 2008/10/09 WF申請者以外の修正対応
// 管理番号 K22217 2008/10/09 WF伝票入力承認者変更
// 管理番号 B21571 2008/10/28 仕入時・仕入返品時は仕入ロット明細.未着品仕入数量にはゼロが登録されるよう修正
// 管理番号 K22196 2008/11/07 都度支払対応
// 管理番号 B21177 2009/03/03 仕入伝票を参照して返品する際、参照元の仕入日より前の日付で更新しようとした場合はエラーとするよう修正
// 管理番号 B21493 2009/03/17 商品コード（マスター）が無効となっている発注伝票を仕入入力すると仕入伝票の更新時にエラーが発生する不具合の対応
// 管理番号 B22191 2009/03/31 発注伝票との伝票日付の前後関係チェックを追加
// 管理番号 B22783 2009/06/08 在庫キー変更時の考慮不足により有効在庫が不正になる不具合を修正
// 管理番号 B21977 2009/08/10 一括請求の場合、請求処理日項目に請求締日が表示されるよう修正
// 管理番号 B21476 2009/08/10 入荷承認を使用する場合、発注伝票参照時に未承認の入荷を除外するよう修正
// 管理番号 B22414 2009/08/10 仕入入力からの発注参照画面で、参照できないデータが検索できてしまう不具合修正
// 1.6.0 2009/09/30
// 管理番号 B22635 2009/11/16 支払予定作成後に支払予定変更にて締日を変更すると、一覧に同一伝票が重複表示される不具合を修正
// 管理番号 B23139 2009/11/16 検索条件に履歴伝票表示：するの条件を指定して検索を行うとアプリケーションエラーが発生する不具合を修正
// 管理番号 B23181 2009/11/16 会計ユニットが未導入の環境にてアプリケーションエラーが発生する不具合を修正
// 管理番号 B22412 2010/05/11 不要な伝票日付の前後関係チェックが行われてしまっている不具合を修正
// 管理番号 B22625 2010/06/22 出荷期限・有効期限がDBサーバの許容値を超えるとエラーが発生する不具合を修正
// 管理番号 B22031 2010/09/06 銀行国コードが「JPN」以外で口座名義人に全角文字が含まれているとエラーとなる不具合を修正
// 管理番号 B23776 2010/10/12 入荷承認を使用する場合、修正時に未承認の入荷分に対して仕入計上が行えてしまう
// 管理番号 B23569 2010/11/11 DBアクセスエラー時のログ出力不備を修正
// 管理番号 B21440 2010/11/18 発注1明細に対して複数の仕入未計上の入荷明細が存在する場合に、発注参照を行った際にアプリケーションエラーが発生する不具合を修正
// 管理番号 B23849 2010/12/02 伝票更新エラーの後に仕入数量を変更して、伝票更新を行うと入荷との繋がりが外れる不具合を修正
// 管理番号 K24153 2011/07/23 検収基準増加対応
// 管理番号 K24274 2012/01/05 販売伝票間摘要連携対応
// 管理番号 K24278 2012/01/20 仕入先課税区分追加対応
// 管理番号 K24285 2012/01/16 売上・仕入マイナス数量入力対応
// 管理番号 K24382 2012/01/30 規格コード桁数拡張
// 管理番号 K24277 2012/02/08 社印・ロゴ追加対応
// 管理番号 B24051 2012/04/04 入荷参照している伝票の行を削除して新規行を登録すると有効在庫が不正になる不具合を修正
// 管理番号 B24057 2012/04/05 一括請求の支払処理日を取得する際、支払の黒データのみを取得対象とする
// 管理番号 B24188 2012/04/24 計上日の月度で債権債務締処理がされていると支払保留が解除できない。
// 管理番号 B24477 2012/08/07 返品時に入荷していないにも関わらず「入荷済」と表示される
// 2.0.0 2012/10/31
// 管理番号 B24787 2012/11/16 非課税取引先で内税商品を入力した場合の対応
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 管理番号 K24789 2013/05/13 消費税率の段階的引き上げ対応
// 管理番号 B25285 2014/01/29 入荷参照海外仕入返品にて在庫単価等が不正となる不具合を修正
// 管理番号 K25322 2014/04/17 ロット引当対応
// 管理番号 B23437 2014/07/22 出合にて支払保留の場合、債権へ連動すると支払保留解除ができない不具合を修正
// 2.2.0 2014/10/31
// 管理番号 K25647 2015/02/17 項目桁数拡張
// 管理番号 K25679 2015/09/17 グループ対応
// 管理番号 K25680 2015/09/17 外部連携
// 2.3.0 2016/06/30
// 管理番号B25370 2016/07/20 後続伝票が存在する場合は削除ボタンを押下不可とする修正
// 管理番号B25595 2016/09/05 ロット番号を変更すると入荷数より返品数が多くなる不具合を修正
// 管理番号B26347 2016/12/20 DBコネクション対応
// 管理番号B26652 2018/03/19 ロット管理する商品にて入荷がある状態で仕入を赤黒すると不正となる不具合を修正
// 管理番号B25771 2018/03/20 発注参照し、客先直送で入力すると「未着品入荷数量」に数量が設定される不具合を修正
// 3.0.0 2018/04/30
// 管理番号B26359 2018/05/08 消込管理区分明細単位時に明細がプラマイゼロの伝票の削除が行えない不具合を修正
// 管理番号B26746 2018/08/28 伝票参照時の明細金額合計にて、端数処理が不正となる
// 管理番号K27011 2019/02/21 項目桁数拡張：取引先・商品・勘定科目
// 管理番号K27058 2019/10/16 汎用区分追加
// 管理番号K27057 2019/12/06 汎用項目追加
// 3.1.0 2020/06/30
// 管理番号B27131 2020/07/01 計上日管理基準で伝票を参照した時、参照した伝票の取引日が初期表示される
// 管理番号K27154 2020/07/13 収益認識対応
// 管理番号B27082 2021/06/09 商品コードや倉庫等の入力欄が非活性となり修正できない不具合を修正
// 管理番号K27230 2021/07/20 脆弱性対応
// 管理番号K27441 2022/02/15 組織変更機能改善
// 管理番号K27525 2022/10/19 適格請求書等保存方式対応(仕入税額控除の要件対応)
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
	public sealed class BL_SC_MM_05 : MarshalByRefObject
	{
		#region Private struct Fields
		private struct OverseasFlg
		{
			public const string	DOMESTIC = "0";
			public const string	OVERSEAS = "1";
		}
		#endregion

		#region Constructors
		private BL_SC_MM_05()
		{
		}
		#endregion

		#region Static Methods
		public static IF_SC_MM_05_Base Select(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base rowData)
		{
//			SqlConnection cn         = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn         = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper headerCommand = null;	// 管理番号K27230
			SqlDataAdapterWrapper daDetail  = null;	// 管理番号K27230
			SqlDataAdapterWrapper daLot     = null;	// 管理番号K27230
			SqlDataReader dr         = null;
			SqlPString sqlDetail         = string.Empty;	// 管理番号K27230
			string sqlLotDetail      = string.Empty;
			bool isCommisionSlip     = false;		//預り伝票か否か
// 管理番号 B14315 From
//// 管理番号 B13500 From
//			bool isRcptSlip			 = false;		//入荷済仕入伝票か否か
//			bool isRcptInputNoNeedPu = false;		//入荷省略でない伝票か否か
//// 管理番号 B13500 To
			string rcptInputNoNeedflg = string.Empty;
// 管理番号 B14315 From

			try
			{
				cn.Open();
// 管理番号 B14315 From
				bool IsRcptInputNoNeedflg = true;
				if(keyColumn.OverseasFlg == "1")
				{
					IsRcptInputNoNeedflg = IsRcptInputNoNeedFlg(commonData, cn, keyColumn);
				}
// 管理番号 B14315 To
				switch (keyColumn.RefType)
				{
					//仕入(仕入参照も同じ)
					case "PU":
					case "NONE":
						headerCommand	= CreatePuHeaderCommand(commonData, cn, keyColumn);
//管理番号P18435 From
						DBTimeout.setTimeout(headerCommand, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
						sqlDetail		= CreatePuDetailString(commonData, keyColumn);
						sqlLotDetail	= CreatePuLotDetailString(commonData, keyColumn,IsRcptInputNoNeedflg);
// 管理番号B25370 From
						rowData.IsReferringSlipExists = IsRefPu(commonData, cn, keyColumn);
// 管理番号B25370 To
						break;
					case "COPY_PU":
						headerCommand	= CreatePuCopyHeaderCommand(commonData, cn, keyColumn);
//管理番号P18435 From
						DBTimeout.setTimeout(headerCommand, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
						sqlDetail		= CreatePuCopyDetailString(commonData, keyColumn);
						sqlLotDetail	= CreatePuCopyLotDetailString(commonData, keyColumn);
						break;
					case "REF_PU":
// 管理番号 B14315 From
//// 管理番号 B13500 From
//						if (keyColumn.OverseasFlg == "1")
//						{
//							// 仕入参照した伝票が入荷済伝票か否か判定
//							isRcptSlip = IsRcptSlip(commonData, cn, keyColumn);
//							if (isRcptSlip)
//							{
//								throw new AllegroException(commonData,ExceptionLevel.Warning, AllegroMessage.SC_MM_05_S02_03);
//							}
//							// 仕入参照した伝票が入荷省略でないか否か判定
//							isRcptInputNoNeedPu = IsRcptInputNoNeedPu(commonData, cn, keyColumn);
//							if (isRcptInputNoNeedPu)
//							{
//								throw new AllegroException(commonData,ExceptionLevel.Warning, AllegroMessage.SC_MM_05_S02_03);
//							}
//						}
//// 管理番号 B13500 To
// 管理番号 B14315 To
						//他伝票の参照有無を取得
						bool IsOtherReturnRef = IsRefPu(commonData, cn, keyColumn);

						if (IsOtherReturnRef)
						{
							//返品他伝票有
							headerCommand	= CreatePuRefOtherExistHeaderCommand(commonData, cn, keyColumn);
//管理番号P18435 From
							DBTimeout.setTimeout(headerCommand, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To 
							sqlDetail		= CreatePuRefOtherExistDetailString(commonData, cn, keyColumn);
							sqlLotDetail	= CreatePuRefOtherExistLotDetailString(commonData, cn, keyColumn, IsRcptInputNoNeedflg);
						}
						else
						{
							//返品他伝票無し
							headerCommand	= CreatePuRefHeaderCommand(commonData, cn, keyColumn);
//管理番号P18435 From
							DBTimeout.setTimeout(headerCommand, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To 
							sqlDetail		= CreatePuRefDetailString(commonData, keyColumn);
							sqlLotDetail	= CreatePuRefLotDetailString(commonData, keyColumn, IsRcptInputNoNeedflg);
						}
						headerCommand.Parameters.Add("@REF_PU_NO", SqlDbType.NVarChar).Value = keyColumn.SlipNo;
						break;
						//発注
					case "PO":
						//入荷の存在有無を取得
						bool isPoBalanceClose = IsPoBalanceClose(commonData, cn, keyColumn);
						isCommisionSlip = IsCommissionSlip(commonData, cn, keyColumn);
						if (isCommisionSlip)
						{
							throw new AllegroException(commonData,ExceptionLevel.Warning, AllegroMessage.SC_MM_05_S02_01);
						}
						headerCommand	= CreatePoHeaderCommand(commonData, cn, keyColumn);
//管理番号P18435 From
						DBTimeout.setTimeout(headerCommand, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To 
						if(isPoBalanceClose)
						{	//発注残クローズ
							sqlDetail	= CreatePoCloseDetailString(commonData, keyColumn);
						}
						else
						{	//発注残クローズでない
							sqlDetail	= CreatePoDetailString(commonData, keyColumn);
						}
						sqlLotDetail	= CreatePoLotDetailString(commonData, keyColumn);
						break;
						//入荷
					case "RCPT":
						isCommisionSlip = IsCommissionSlip(commonData, cn, keyColumn);
						if (isCommisionSlip)
						{
							throw new AllegroException(commonData,ExceptionLevel.Warning, AllegroMessage.SC_MM_05_S02_02);
						}
						headerCommand	= CreateRcptHeaderCommand(commonData, cn, keyColumn);
//管理番号P18435 From
						DBTimeout.setTimeout(headerCommand, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To 
						sqlDetail		= CreateRcptDetailString(commonData, keyColumn);
						sqlLotDetail	= CreateRcptLotDetailString(commonData, keyColumn);
						break;
// 管理番号 B19369 From
						//海外仕入返品時入荷参照
					case "REF_RETURN_RC":
						headerCommand	= CreateRefReturnRcptHeaderCommand(commonData, cn, keyColumn);
						DBTimeout.setTimeout(headerCommand, commonData);		//タイムアウト値変更メソッド呼出し

						sqlDetail		= CreateRefReturnRcptDetailString(commonData, keyColumn);
						sqlLotDetail	= CreateRefReturnRcptLotDetailString(commonData, keyColumn);
						headerCommand.Parameters.Add("@REF_RCPT_NO", SqlDbType.NVarChar).Value = keyColumn.SlipNo;
						break;
// 管理番号 B19369 To
					default:
						throw new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.S20001);
				}

				//ヘッダ
				headerCommand.Parameters.Add("@PARAM_TYPE"	, SqlDbType.NVarChar).Value		= ConvertDBData.ToNVarChar(keyColumn.ParamType);
				headerCommand.Parameters.Add("@DeptCode"	, SqlDbType.NVarChar, 10).Value	= ConvertDBData.ToNVarChar(keyColumn.UserDeptCode);
				headerCommand.Parameters.Add("@Date"		, SqlDbType.DateTime).Value		= ConvertDBData.ToDateTime(DateTime.Today.ToString());
// 管理番号 K16187 From
				headerCommand.Parameters.Add("@MYCOMP_CODE" , SqlDbType.NVarChar, 10).Value = ConvertDBData.ToNVarChar(commonData.CompCode);
// 管理番号 K16187 To
// 管理番号K27058 From
				// 入荷、仕入参照（返品）時に入力した仕入形態区分明細コードを引き継ぐ
				headerCommand.Parameters.Add("@PU_MODE_TYPE_DTIL_CODE"	, SqlDbType.NVarChar, 2).Value	= ConvertDBData.ToNVarChar(keyColumn.PuModeTypeDtilCode);
// 管理番号K27058 To

				dr = headerCommand.ExecuteReader();
				SetHeaderData(commonData, dr, rowData, keyColumn);
				if (dr != null && !dr.IsClosed)
				{
					dr.Close();
				}

// 管理番号 B19369 From
				// 海外仕入参照の返品は、入荷省略する海外仕入伝票のみとする
				if (keyColumn.PuModeType == "2" && keyColumn.OverseasFlg=="1" && keyColumn.RefType=="REF_PU" && rowData.RcptInputNoNeedFlg != "1")
				{
					throw new AllegroException(commonData,ExceptionLevel.Warning, AllegroMessage.SC_MM_05_S02_03);
				}
// 管理番号 B19369 To

				//海外売上
				if (keyColumn.OverseasFlg=="1")
				{
					//海外売上(受注)取引条件の取得
					SelectOversearsDt(commonData, cn, keyColumn, rowData);
				}

				//明細
				daDetail = new SqlDataAdapterWrapper(sqlDetail, cn);	// 管理番号K27230
//管理番号P18435 From
				DBTimeout.setTimeout(daDetail, commonData); 		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
				daDetail.SelectCommand.Parameters.Add("@MYCOMP_CODE",SqlDbType.NVarChar,10).Value = ConvertDBData.ToNVarChar(commonData.CompCode);
// 管理番号 B11723・B11796 From
				daDetail.SelectCommand.Parameters.Add("@SLIP_NO",SqlDbType.NVarChar,10).Value = ConvertDBData.ToNVarChar(keyColumn.SlipNo);
// 管理番号 B11723・B11796 To
// 管理番号 K24278 From
				daDetail.SelectCommand.Parameters.Add("@CtaxRoundType", SqlDbType.NVarChar, 1).Value = rowData.CtaxRoundType;
				daDetail.SelectCommand.Parameters.Add("@ImposeFlg",SqlDbType.NVarChar,10).Value = ConvertDBData.ToNVarChar(rowData.ImposeFlg);
// 管理番号 K24278 To
// 管理番号K27057 From
				daDetail.SelectCommand.Parameters.Add("@PU_DATE", SqlDbType.Date).Value = rowData.PuDate;
// 管理番号K27057 To
				daDetail.Fill(rowData.Dt);

				//ロット明細(発注参照時に入荷がなければ、ロット明細は作らない)
// 管理番号 K24285 From
//				if (rowData.HasRows && (rowData.SumPuQt>0M))
				if (rowData.HasRows &&
					(!(keyColumn.RefType=="PO" || keyColumn.RefType=="RCPT" || keyColumn.RefType=="REF_RETURN_RC") ||
					((keyColumn.RefType=="PO" || keyColumn.RefType=="RCPT" || keyColumn.RefType=="REF_RETURN_RC") && rowData.SumPuQt>0M)))
// 管理番号 K24285 To
				{
					if (sqlLotDetail.Length > 0)
					{
						daLot = new SqlDataAdapterWrapper(sqlLotDetail, cn);	// 管理番号K27230
//管理番号P18435 From
						DBTimeout.setTimeout(daLot, commonData); 		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
						daLot.SelectCommand.Parameters.Add("@MYCOMP_CODE",SqlDbType.NVarChar,10).Value = ConvertDBData.ToNVarChar(commonData.CompCode);

						DataColumn[] pk = rowData.LotDt.PrimaryKey;
						rowData.LotDt.PrimaryKey = null;
						daLot.Fill(rowData.LotDt);

						//発注参照(入荷有)以外
						if (!(keyColumn.RefType=="PO" && rowData.Dt.Compute("Count(PU_LINE_ID)", "IS_RCPT_EXECUTE = '1'").ToString() != "0" ))
						{
// 管理番号 B18394 From
							//rowData.LotDt.PrimaryKey = pk;

// 管理番号 K25322 From
//// 管理番号 B19111 From
////							if (keyColumn.OverseasFlg=="1")
//							if (keyColumn.OverseasFlg=="1" && rowData.RcptInputNoNeedFlg == "0")
//// 管理番号 B19111 To
							if (keyColumn.OverseasFlg=="1" && rowData.RcptInputNoNeedFlg == "0" && keyColumn.ParamType == "New")
// 管理番号 K25322 To
							{
								DataColumn[] refpk = new DataColumn[4];
								Array.Copy(pk,refpk, pk.Length);
								refpk[3] = rowData.LotDt.Columns["RCPT_NO"];
								rowData.LotDt.PrimaryKey = refpk;
							}
							else
							{
								rowData.LotDt.PrimaryKey = pk;
							}
// 管理番号 B18394 To
						}
					}
				}
				else
				{
					switch (keyColumn.RefType)
					{
						case "REF_PU":	//仕入参照
							throw new AllegroException(commonData,ExceptionLevel.Warning, AllegroMessage.SC_MM_05_S02_03);
						case "PO":		//発注参照
							throw new AllegroException(commonData,ExceptionLevel.Warning, AllegroMessage.SC_MM_05_S02_01);
						case "RCPT":	//入荷参照
							throw new AllegroException(commonData,ExceptionLevel.Warning, AllegroMessage.SC_MM_05_S02_02);
// 管理番号 B19369 From
						case "REF_RETURN_RC":   //海外仕入返品時入荷参照
							throw new AllegroException(commonData,ExceptionLevel.Warning, AllegroMessage.SC_MM_05_S04_05);
// 管理番号 B19369 To
						case "PU":		//仕入修正、仕入コピー
						case "COPY_PU":
						case "NONE":
						default:
							throw new AllegroException(commonData,ExceptionLevel.Warning, AllegroMessage.SC_MM_05_S02_04);
					}
				}

				rowData.Dt.AcceptChanges();
				rowData.LotDt.AcceptChanges();
// 管理番号 B24051 From
				// 現時点での明細最大行IDを保持する
				object maxLineID = rowData.Dt.Compute("MAX(PU_LINE_ID)", string.Empty);
				rowData.SetMaxLineID = (maxLineID is decimal) ? (decimal) maxLineID : 0M;
// 管理番号 B24051 To
			}
			catch (AllegroException ex)
			{
				throw (new AllegroException(commonData,ex.ExceptionLevel, ex.Message).WriteLog());
			}
			catch (SqlException sqlEx)
			{
				throw (new AllegroException(commonData, sqlEx).WriteLog());
			}
			catch (System.Exception sysEx)
			{
				//致命的エラー
				throw (new AllegroException(commonData, ExceptionLevel.FatalError,sysEx.Message).WriteLog());
			}
			finally
			{
// 管理番号B26347 From
//				if(cn!=null && cn.State!=ConnectionState.Closed)cn.Close();
				if(cn!=null && cn.State!=ConnectionState.Closed)
				{
					cn.Close();
				}
// 管理番号B26347 To
			}

			return rowData;
		}
		//仕入
		private static SqlCommandWrapper CreatePuHeaderCommand(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append("SELECT");
			sb.Append(" [PU].[PU_NO]                        AS [PU_NO]"                         );
			sb.Append(",[PU].[PU_NAME]                      AS [PU_NAME]"                       );
			sb.Append(",[PU].[PU_DATE]                      AS [PU_DATE]"                       );
// 管理番号 K16590 From
			sb.Append(",[PU].[DEAL_DATE]                    AS [DEAL_DATE]"                     );
// 管理番号 K16590 To
			sb.Append(",[PU].[PO_NO]                        AS [PO_NO]"                         );
			sb.Append(",[PU].[RCPT_NO]                      AS [RCPT_NO]"                       );
			sb.Append(",[PU].[PU_MODE_TYPE]                 AS [PU_MODE_TYPE]"                  );
// 管理番号K27058 From
			sb.Append(",[PU].[PU_MODE_TYPE_DTIL_CODE]		AS [PU_MODE_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			sb.Append(",[PU].[REF_PU_NO]                    AS [REF_PU_NO]"                     );
			sb.Append(",[PU].[CUR_CODE]                     AS [CUR_CODE]"                      );
			sb.Append(",[PU].[EXCHANGE_TYPE]                AS [EXCHANGE_TYPE]"                 );
			sb.Append(",[PU].[EXCHANGE_REZ_NO]              AS [EXCHANGE_REZ_NO]"               );
			sb.Append(",[PU].[RATE]                         AS [RATE]"                          );
			sb.Append(",[PU].[DEPT_CODE]                    AS [DEPT_CODE]"                     );
			sb.Append(",[O].[DEPT_SHORT_NAME]               AS [DEPT_SHORT_NAME]"               );
			sb.Append(",[PU].[ORIGIN_DEPT_CODE]             AS [ORIGIN_DEPT_CODE]"              );
			sb.Append(",[PU].[OLD_DEPT_CODE]                AS [OLD_DEPT_CODE]"                 );
			sb.Append(",[PU].[ORG_CHANGE_ID]                AS [ORG_CHANGE_ID]"                 );
			sb.Append(",[PU].[DATA_MIGRATE_DATETIME]        AS [DATA_MIGRATE_DATETIME]"         );
			sb.Append(",[PU].[EMP_CODE]                     AS [EMP_CODE]"                      );
			sb.Append(",[PU].[PROJ_CODE]                    AS [PROJ_CODE]"                     );
			sb.Append(",[PU].[PROJ_SBNO]                    AS [PROJ_SBNO]"                     );
			sb.Append(",[PU].[SUPL_CODE]                    AS [SUPL_CODE]"                     );
			sb.Append(",[PU].[SUPL_SBNO]                    AS [SUPL_SBNO]"                     );
			sb.Append(",[PU].[TEMP_CODE_FLG]                AS [TEMP_CODE_FLG]"                 );
			sb.Append(",[PU].[SUPL_NAME]                    AS [SUPL_NAME]"                     );
			sb.Append(",[PU].[SUPL_SHORT_NAME]              AS [SUPL_SHORT_NAME]"               );
			sb.Append(",[PU].[SUPL_DEPT_NAME_1]             AS [SUPL_DEPT_NAME_1]"              );
			sb.Append(",[PU].[SUPL_DEPT_NAME_2]             AS [SUPL_DEPT_NAME_2]"              );
			sb.Append(",[PU].[SUPL_COUNTRY_CODE]            AS [SUPL_COUNTRY_CODE]"             );
			sb.Append(",[PU].[SUPL_ZIP]                     AS [SUPL_ZIP]"                      );
			sb.Append(",[PU].[SUPL_STATE]                   AS [SUPL_STATE]"                    );
			sb.Append(",[PU].[SUPL_CITY]                    AS [SUPL_CITY]"                     );
			sb.Append(",[PU].[SUPL_ADDRESS1]                AS [SUPL_ADDRESS1]"                 );
			sb.Append(",[PU].[SUPL_ADDRESS2]                AS [SUPL_ADDRESS2]"                 );
			sb.Append(",[PU].[SUPL_PHONE]                   AS [SUPL_PHONE]"                    );
			sb.Append(",[PU].[SUPL_FAX]                     AS [SUPL_FAX]"                      );
			sb.Append(",[PU].[SUPL_USER_NAME]               AS [SUPL_USER_NAME]"                );
			sb.Append(",[PU].[AC_NO]                        AS [AC_NO]"                         );
			sb.Append(",[PU].[AC_HOLDER]                    AS [AC_HOLDER]"                     );
			sb.Append(",[PU].[AC_TYPE]                      AS [AC_TYPE]"                       );
			sb.Append(",[PU].[BANK_AC_TYPE]                 AS [BANK_AC_TYPE]"                  );
			sb.Append(",[PU].[BANK_COUNTRY_CODE]            AS [BANK_COUNTRY_CODE]"             );
			sb.Append(",[PU].[BANK_CODE]                    AS [BANK_CODE]"                     );
			sb.Append(",[PU].[BANK_BRANCH_CODE]             AS [BANK_BRANCH_CODE]"              );
			sb.Append(",[PU].[DELI_TYPE]                    AS [DELI_TYPE]"                     );
			sb.Append(",[PU].[WH_CODE]                      AS [WH_CODE]"                       );
			sb.Append(",[PU].[DELI_CUST_CODE]               AS [DELI_CUST_CODE]"                );
			sb.Append(",[PU].[DELI_CUST_SBNO]               AS [DELI_CUST_SBNO]"                );
			sb.Append(",[PU].[DELI_PLACE_CODE]              AS [DELI_PLACE_CODE]"               );
			sb.Append(",[PU].[DELI_PLACE_NAME]              AS [DELI_PLACE_NAME]"               );
			sb.Append(",[PU].[DELI_PLACE_COUNTRY_CODE]      AS [DELI_PLACE_COUNTRY_CODE]"       );
			sb.Append(",[PU].[DELI_PLACE_ZIP]               AS [DELI_PLACE_ZIP]"                );
			sb.Append(",[PU].[DELI_PLACE_STATE]             AS [DELI_PLACE_STATE]"              );
			sb.Append(",[PU].[DELI_PLACE_CITY]              AS [DELI_PLACE_CITY]"               );
			sb.Append(",[PU].[DELI_PLACE_ADDRESS1]          AS [DELI_PLACE_ADDRESS1]"           );
			sb.Append(",[PU].[DELI_PLACE_ADDRESS2]          AS [DELI_PLACE_ADDRESS2]"           );
			sb.Append(",[PU].[DELI_PLACE_PHONE]             AS [DELI_PLACE_PHONE]"              );
			sb.Append(",[PU].[DELI_PLACE_FAX]               AS [DELI_PLACE_FAX]"                );
			sb.Append(",[PU].[DELI_PLACE_USER_NAME]         AS [DELI_PLACE_USER_NAME]"          );
			sb.Append(",[PU].[DT_TYPE]                      AS [DT_TYPE]"                       );
			sb.Append(",[PU].[DT1_STTL_MTHD_CODE]           AS [DT1_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT1_BASIS_AMT]                AS [DT1_BASIS_AMT]"                 );
			sb.Append(",[PU].[DT2_STTL_MTHD_CODE]           AS [DT2_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT2_RATIO]                    AS [DT2_RATIO]"                     );
			sb.Append(",[PU].[DT3_STTL_MTHD_CODE]           AS [DT3_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT_SIGHT]                     AS [DT_SIGHT]"                      );
			sb.Append(",[PU].[CUTOFF_DATE]                  AS [CUTOFF_DATE]"                   );
// 管理番号 B23181 From
			if(keyColumn.ApModuleFlg)
			{
// 管理番号 B23181 To
// 管理番号 B21977 From
// 管理番号 B22635 From
//				sb.Append(",CASE WHEN [PU].[DT_TYPE]='L' AND [PU].[CUTOFF_FIN_FLG]='1' ");
				sb.Append(",CASE WHEN [PU].[CUTOFF_FIN_FLG]='1' ");
// 管理番号 B22635 To
				sb.Append("   THEN [PYMT].[PYMT_CUTOFF_DATE] ");
				sb.Append("   ELSE [PU].[CUTOFF_DATE] ");
				sb.Append(" END AS [CUTOFF_FIN_DATE] ");
// 管理番号 B21977 To
// 管理番号 B23181 From
			}
			else
			{
				sb.Append(",NULL AS [CUTOFF_FIN_DATE] ");
			}
// 管理番号 B23181 To
			sb.Append(",[PU].[PYMT_PLAN_DATE]               AS [PYMT_PLAN_DATE]"                );
			sb.Append(",[PU].[DT_NOTE]                      AS [DT_NOTE]"                       );
			sb.Append(",[POX].[DT_CUTOFF_CYCLE_TYPE]        AS [DT_CUTOFF_CYCLE_TYPE]"          );
			sb.Append(",[POX].[DT_CUTOFF_DAY]               AS [DT_CUTOFF_DAY]"                 );
			sb.Append(",[POX].[DT_TERM_MONTH_CNT]           AS [DT_TERM_MONTH_CNT]"             );
			sb.Append(",[POX].[DT_TERM_DAY]                 AS [DT_TERM_DAY]"                   );
// 管理番号 B22191 From
			sb.Append(",[POX].[PO_DATE]                     AS [PO_DATE]"                       );
// 管理番号 B22191 To
// 管理番号K27441 From
			sb.Append(",[POX].[DEPT_CODE]					AS [PO_DEPT_CODE]"					);
// 管理番号K27441 To
			sb.Append(",[PU].[SUPL_BILL_SLIP_NO]            AS [SUPL_BILL_SLIP_NO]"             );
			sb.Append(",[PU].[CANCELED_ORDER_FLG]           AS [CANCELED_ORDER_FLG]"            );
			sb.Append(",[PU].[OVERSEAS_FLG]                 AS [OVERSEAS_FLG]"                  );
			sb.Append(",[PU].[TENOR_CODE]                   AS [TENOR_CODE]"                    );
			sb.Append(",[PU].[FMONEY_STTL_PERIOD_STT_MONTH] AS [FMONEY_STTL_PERIOD_STT_MONTH]"  );
			sb.Append(",[PU].[FMONEY_STTL_PERIOD_END_MONTH] AS [FMONEY_STTL_PERIOD_END_MONTH]"  );
			sb.Append(",[PU].[LC_NO]                        AS [LC_NO]"                         );
// 管理番号 B13878 From
			sb.Append(",[PU].[HOLD_FLG]						AS [HOLD_FLG]"						);
// 管理番号 B13878 To
			sb.Append(",[PU].[REMARKS_CODE]                 AS [REMARKS_CODE]"                  );
			sb.Append(",[PU].[REMARKS]                      AS [REMARKS]"                       );
// 管理番号 B13798 From
			sb.Append(",[PU].[ADMIN_ITEM1]                  AS [ADMIN_ITEM1]"                   );
			sb.Append(",[PU].[ADMIN_ITEM2]                  AS [ADMIN_ITEM2]"                   );
			sb.Append(",[PU].[ADMIN_ITEM3]                  AS [ADMIN_ITEM3]"                   );
// 管理番号 B13798 To
// 管理番号 K20687 From
			sb.Append(",[PU].[BOOK_BASIS_TYPE]				AS [BOOK_BASIS_TYPE]"				);
// 管理番号 K20687 To
// 管理番号K27058 From
			sb.Append(",[PU].[BOOK_BASIS_TYPE_DTIL_CODE]	AS [BOOK_BASIS_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			sb.Append(",[PU].[OUTLAND_REMITTANCE_FLG]       AS [OUTLAND_REMITTANCE_FLG]"        );
			sb.Append(",[PU].[INTERNATIONAL_ITEM_NO]        AS [INTERNATIONAL_ITEM_NO]"         );
			sb.Append(",[PU].[REMITTANCE_PURPOSE]           AS [REMITTANCE_PURPOSE]"            );
			sb.Append(",[PU].[REMITTANCE_ALLOW_FLG]         AS [REMITTANCE_ALLOW_FLG]"          );
			sb.Append(",[PU].[REMITTANCE_ALLOW_NO]          AS [REMITTANCE_ALLOW_NO]"           );
			sb.Append(",[PU].[REMITTANCE_MESSAGE]           AS [REMITTANCE_MESSAGE]"            );
// 管理番号 B13500 From
			sb.Append(",[PU].[RCPT_INPUT_NO_NEED_FLG]		AS [RCPT_INPUT_NO_NEED_FLG]"		);
// 管理番号 B13500 To
			sb.Append(",[PU].[APPROVAL_STATUS_TYPE]         AS [APPROVAL_STATUS_TYPE]"          );
			sb.Append(",[PU].[PU_SLIP_OUTPUT_FLG]           AS [PU_SLIP_OUTPUT_FLG]"            );
			sb.Append(",[PU].[ETAX_DTIL_AMT_TTL]            AS [ETAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[ITAX_DTIL_AMT_TTL]            AS [ITAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[NTAX_DTIL_AMT_TTL]            AS [NTAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[ETAX_AMT_TTL]                 AS [ETAX_AMT_TTL]"                  );
			sb.Append(",[PU].[ITAX_AMT_TTL]                 AS [ITAX_AMT_TTL]"                  );
			sb.Append(",[PU].[GRAND_TTL]                    AS [GRAND_TTL]"                     );
			sb.Append(",[PU].[KEY_GRAND_TTL]                AS [KEY_GRAND_TTL]"                 );
			sb.Append(",[PU].[KO_AMT]                       AS [KO_AMT]"                        );
			sb.Append(",[PU].[LAST_KO_DATE]                 AS [LAST_KO_DATE]"                  );
			sb.Append(",[PU].[KO_COMPLETE_FLG]              AS [KO_COMPLETE_FLG]"               );
// 管理番号 K16187 From
			sb.Append(",[PU].[APPROVED_KO_AMT]              AS [APPROVED_KO_AMT]"               );
// 管理番号B26359 From
//			sb.Append(",[PD].[DTIL_KO_FLG]                  AS [DTIL_KO_FLG], "                 );
			// 削除できる条件として都度で伝票合計がゼロのパターンを追加
			sb.Append(",CASE WHEN [PU].[DT_TYPE] = N'E' "                                       );
			sb.Append("  AND [PU].[KO_AMT] = 0 AND [PU].[KO_COMPLETE_FLG] = N'1' "              );
			sb.Append("  AND [PU].[APPROVED_KO_AMT] = 0 AND [PU].[APPROVED_KO_COMPLETE_FLG] = N'1' ");
			sb.Append(" THEN N'0' ");
			sb.Append(" ELSE [PD].[DTIL_KO_FLG] END        AS [DTIL_KO_FLG], "                  );
// 管理番号B26359 To
			if(keyColumn.ApModuleFlg)
			{
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SC_MS_GetPymtStatus]"));
// 管理番号K22196 From
//				sb.Append("    ( @MYCOMP_CODE, [PU].[PYMT_NO], 'SM3')  AS [DELETE_ALLOW_FLG]");
				sb.Append("    ( @MYCOMP_CODE, [PU].[PU_NO], 'SM3')  AS [DELETE_ALLOW_FLG]");
// 管理番号K22196 To
			}
			else
			{
// 管理番号 B16573 From
//				sb.Append(",'0'                             AS [DELETE_ALLOW_FLG]");
				sb.Append("'0'                             AS [DELETE_ALLOW_FLG]");
// 管理番号 B16573 To
			}
// 管理番号 K16187 To
			sb.Append(",[PU].[EXCHANGE_GAIN_LOSS_AMT_TTL]   AS [EXCHANGE_GAIN_LOSS_AMT_TTL]"    );
			sb.Append(",[PU].[LAST_EXCHANGE_VALUATION_DATE] AS [LAST_EXCHANGE_VALUATION_DATE]"  );
			sb.Append(",[PU].[EXCHANGE_VALUATION_FIN_FLG]   AS [EXCHANGE_VALUATION_FIN_FLG]"    );
			sb.Append(",[PU].[PYMT_NO]                      AS [PYMT_NO]"                       );
			sb.Append(",[PU].[CUTOFF_FIN_FLG]               AS [CUTOFF_FIN_FLG]"                );
			sb.Append(",[PU].[CANCEL_FLG]                   AS [CANCEL_FLG]"                    );
			sb.Append(",[PU].[RED_SLIP_FLG]                 AS [RED_SLIP_FLG]"                  );
			sb.Append(",[PU].[ORIGIN_PU_NO]                 AS [ORIGIN_PU_NO]"                  );
			sb.Append(",[PU].[OPPOSITE_PU_NO]               AS [OPPOSITE_PU_NO]"                );
			sb.Append(",[PU].[LAST_JRNL_EXEC_DATETIME]      AS [LAST_JRNL_EXEC_DATETIME]"       );
			sb.Append(",[PU].[JRNL_FIN_FLG]                 AS [JRNL_FIN_FLG]"                  );
			sb.Append(",[PU].[PRG_UPDATE_DATETIME]          AS [PRG_UPDATE_DATETIME]"           );
// 管理番号 B20818 From
			sb.Append(", CASE ");
			sb.Append("    WHEN [PU].[PO_NO] IS NOT NULL THEN ISNULL([POX].[PRG_UPDATE_DATETIME],GETDATE()) ");
			sb.Append("    WHEN [PO_RETURN].[PO_NO] IS NOT NULL THEN ISNULL([PO_RETURN].[PRG_UPDATE_DATETIME],GETDATE()) ");
			sb.Append("    WHEN [PU].[REF_PU_NO] IS NOT NULL THEN ISNULL([PU_RETURN].[PRG_UPDATE_DATETIME],GETDATE()) ");
			sb.Append("    ELSE GETDATE()");
			sb.Append("  END AS [REF_PRG_UPDATE_DATETIME] ");
// 管理番号 B20818 To
// 管理番号 K22205 From
            sb.Append(",[PU].[INPUT_EMP_CODE]          AS [INPUT_EMP_CODE]"                     );
// 管理番号 K22205 To
			sb.Append(",[S].[SO_NO]                         AS [SO_NO]"                         );
			sb.Append(",[S].[SO_DATE]                       AS [SO_DATE]"                       );
			sb.Append(",[S].[CUST_SHORT_NAME]               AS [CUST_SHORT_NAME]"               );
// 管理番号 B13569 From
			sb.Append(",CASE [POX].[EXCHANGE_TYPE] WHEN '1' THEN '1' ELSE '0' END AS [REF_PO_EXCHANGE_TYPE]");
// 管理番号 B13569 To
// 管理番号 B13500 From
			sb.Append(", CASE WHEN [PU].[RCPT_INPUT_NO_NEED_FLG] = '1' THEN  ");
			sb.Append("	  CASE WHEN [R_PU].[PU_NO] IS NULL THEN  0  ELSE  1  END ");
			sb.Append("  ELSE ");
			sb.Append("      CASE WHEN [RCPT].[RCPT_NO] IS NULL THEN  0  ELSE  1 END ");
			sb.Append(" END ");
			sb.Append(" AS [TRANSIT_RCPT_QT_TTL]");
// 管理番号 B13500 To
// 管理番号 K24789 From
//// 管理番号 K24278 From
//			sb.Append(",[COMP].[CTAX_FRACTION_ROUND_TYPE]	AS [CTAX_FRACTION_ROUND_TYPE]"		);
//			sb.Append(",[SUPL].[CTAX_IMPOSE_FLG]			AS [CTAX_IMPOSE_FLG]"				);
//// 管理番号 K24278 To
			sb.Append(",[PU].[CTAX_IMPOSE_FLG]              AS [CTAX_IMPOSE_FLG]"               );
			sb.Append(",[PU].[CTAX_BUILDUP_TYPE]            AS [CTAX_BUILDUP_TYPE]"             );
			sb.Append(",[PU].[CTAX_FRACTION_ROUND_TYPE]     AS [CTAX_FRACTION_ROUND_TYPE]"      );
// 管理番号 K24789 To
// 管理番号 K25679 From
			sb.Append(",[PU].[PO_ADMIN_NO]                  AS [PO_ADMIN_NO]"                   );
			sb.Append(",[PU].[SUPL_SLIP_NO]                 AS [SUPL_SLIP_NO]"                  );
// 管理番号 K25679 To
// 管理番号 K25680 From
			sb.Append(",[PU].[IMPORT_SLIP_NO]               AS [IMPORT_SLIP_NO]"                );
// 管理番号 K25680 To
// 管理番号B25370 From
			sb.Append(" ,ISNULL([CHARGE_PU].[COUNT], 0) AS [CHARGE_COUNT] ");
// 管理番号B25370 To
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputHead, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PU", null, null, null);
// 管理番号K27057 To
// 管理番号K27154 From
			sb.Append(",[PU].[DEAL_TYPE_CODE]				AS [DEAL_TYPE_CODE] ");
// 管理番号K27154 To
			//仕入
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
// 管理番号 K16187 From
			sb.Append(" INNER JOIN ( ");
			sb.Append("            SELECT [PU_NO] ");
			sb.Append("                  ,CASE WHEN MAX(ABS([KO_AMT])) = 0 AND MAX(ABS([APPROVED_KO_AMT])) = 0 THEN 0 ELSE 1 END AS [DTIL_KO_FLG] ");
			sb.Append("              FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]"));
			sb.Append(" GROUP BY [PU_NO] ) AS [PD] ");
			sb.Append("     ON [PD].[PU_NO] = [PU].[PU_NO]");
// 管理番号 K16187 To
// 管理番号 B15710 From
			//組織図、組織変更
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHART]")).Append(" AS [O]");
			sb.Append(" ON [PU].[DEPT_CODE] = [O].[DEPT_CODE]");
			sb.Append(" AND [O].[ORG_CHANGE_ID] = ");
			sb.Append("(");
			sb.Append(" SELECT MAX([ORG_CHANGE].[ORG_CHANGE_ID]) FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHANGE]"));
			sb.Append(" [ORG_CHANGE] ");
			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= CASE WHEN [PU].[PU_DATE] < GETDATE() THEN GETDATE() ELSE [PU].[PU_DATE] END");
			sb.Append(")");
// 管理番号 B15710 To
// 管理番号B25370 From
			// 諸掛伝票に按分されているか
			sb.Append(" LEFT JOIN ");
			sb.Append(" ( ");
			sb.Append("   SELECT");
			sb.Append("       [CHARGE_PU_RELATION].[PU_NO]");
			sb.Append("     , COUNT(*) AS [COUNT] ");
			sb.Append("   FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[CHARGE_PU_RELATION]")).Append(" AS [CHARGE_PU_RELATION]");
			sb.Append("   WITH (NOLOCK) ");
			sb.Append("   GROUP BY [CHARGE_PU_RELATION].[PU_NO]");
			sb.Append(" ) AS [CHARGE_PU]");
			sb.Append(" ON [CHARGE_PU].[PU_NO] IN([PU].[PU_NO], [PU].[REF_PU_NO])");
// 管理番号B25370 To
// 管理番号 B13500 From
			// 返品仕入
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [R_PU]");
			sb.Append(" ON [PU].[PU_NO] = [R_PU].[REF_PU_NO] ");
			sb.Append("	AND [R_PU].[OPPOSITE_PU_NO] IS NULL ");
			// 入荷
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");
			sb.Append(" ON [PU].[PU_NO] = [RCPT].[PU_NO] ");
			sb.Append("	AND [RCPT].[DELETE_FLG] = '0'  ");
// 管理番号 B13500 To
			//発注
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(" AS [POX]");
			sb.Append(" ON [PU].[PO_NO] = [POX].[PO_NO]");
// 管理番号 B20818 From
			//仕入(返品)
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU_RETURN]");
			sb.Append(" ON  [PU].[REF_PU_NO] = [PU_RETURN].[PU_NO]");
			//発注(返品)
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(" AS [PO_RETURN]");
			sb.Append(" ON  [PU_RETURN].[PO_NO] = [PO_RETURN].[PO_NO] ");
// 管理番号 B20818 To
			//受注
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SO]")).Append(" AS [S]");
			sb.Append(" ON [POX].[SO_NO] = [S].[SO_NO]");
			sb.Append(" AND [S].[DELETE_FLG] <> '1'");
// 管理番号 B23181 From
			if(keyColumn.ApModuleFlg)
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
// 管理番号 B15710 From
//			//組織図、組織変更
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHART]")).Append(" AS [O]");
//			sb.Append(" ON [PU].[DEPT_CODE] = [O].[DEPT_CODE]");
//			sb.Append(" AND [O].[ORG_CHANGE_ID] = ");
//			sb.Append("(");
//			sb.Append(" SELECT MAX([ORG_CHANGE].[ORG_CHANGE_ID]) FROM ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHANGE]"));
//			sb.Append(" [ORG_CHANGE] ");
//// 管理番号 B12528 From
////			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= [PU].[PU_DATE] ");
//			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= CASE WHEN [PU].[PU_DATE] < GETDATE() THEN GETDATE() ELSE [PU].[PU_DATE] END");
//// 管理番号 B12528 To
//			sb.Append(")");
// 管理番号 B15710 To
// 管理番号 K24789 From
//// 管理番号 K24278 From
//			//取引先
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[COMP]")).Append(" AS [COMP]");
//			sb.Append(" ON  [PU].[SUPL_CODE] = [COMP].[COMP_CODE] ");
//			//仕入先
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]")).Append(" AS [SUPL]");
//			sb.Append(" ON  [PU].[SUPL_CODE] = [SUPL].[SUPL_CODE] ");
//			sb.Append(" AND [PU].[SUPL_SBNO] = [SUPL].[SUPL_SBNO] ");
//// 管理番号 K24278 To
// 管理番号 K24789 To

			// 管理番号 B13500 From
			wpb = new WherePhraseBuilder();
			// 管理番号 B13500 To
			wpb.AddFilter("[PU].[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[PU].[OVERSEAS_FLG]", SearchOperator.Equal, keyColumn.OverseasFlg);			//海外フラグ
			sb.Append(wpb);

			//自部門のみの権限の場合
			if (keyColumn.DisclosureUnitType == "D")
			{
				sb.Append(" AND EXISTS (SELECT [DEPT_CODE] FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetLowerDeptLevel](@DeptCode, @Date)"));
				sb.Append(" [TEMP_DEPTLEVEL] WHERE [PU].[DEPT_CODE] = [TEMP_DEPTLEVEL].[DEPT_CODE])");
			}
			return new SqlCommandWrapper(sb.ToSqlPString(),cn);	// 管理番号K27230
		}
		//仕入明細
		private static SqlPString CreatePuDetailString(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			string prodSpec1Name = string.Empty;
			string prodSpec2Name = string.Empty;
			string unitShortName = string.Empty;

			switch (keyColumn.OverseasFlg)
			{
				case OverseasFlg.DOMESTIC:
					prodSpec1Name = "PROD_SPEC_1_NAME";
					prodSpec2Name = "PROD_SPEC_2_NAME";
					unitShortName = "UNIT_SHORT_NAME";
					break;
				case OverseasFlg.OVERSEAS:
					prodSpec1Name = "PROD_SPEC_1_ENG_NAME";
					prodSpec2Name = "PROD_SPEC_2_ENG_NAME";
					unitShortName = "UNIT_ENG_NAME";
					break;
			}

			//在庫管理部門の取得
			sb.Append("DECLARE @STOCK_ADMIN_DEPT_CODE NVARCHAR(10) ");
			sb.Append("SELECT ");
			sb.Append("  @STOCK_ADMIN_DEPT_CODE = ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SC_MS_GetStockDeptCode]"));
			sb.Append("(@MYCOMP_CODE, [DEPT_CODE], GETDATE())");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]"));
			wpb.AddFilter("[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo );
			sb.Append(wpb);

// 管理番号 B15710 From
//// 管理番号 B11723・B11796 From
//			sb.Append(@"
//DECLARE @CUR_DIGIT      DECIMAL(1,0)
//DECLARE @CUR_ROUND_TYPE NVARCHAR(1)
//DECLARE @AMT_ROUND_TYPE NVARCHAR(1)
//
//SELECT
//	 @CUR_ROUND_TYPE = [MC].[CUR_FRACTION_ROUND_TYPE]
//	,@AMT_ROUND_TYPE = [MC].[AMT_TTL_FRACTION_ROUND_TYPE]
//FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[MYCOMP]")).Append(@" AS [MC]
//WHERE [MC].[MYCOMP_CODE] = @MYCOMP_CODE
//
//SELECT @CUR_DIGIT = [C].[DECIMAL_DIGIT]
//FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(@" AS [PU]
//INNER JOIN ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CUR]")).Append(@" AS [C]
//	ON [PU].[CUR_CODE] = [C].[CUR_CODE]
//WHERE [PU].[PU_NO] = @SLIP_NO
//");
//// 管理番号 B11723・B11796 To
// 管理番号 B15710 To

			wpb = new WherePhraseBuilder();

			sb.Append("SELECT ");
			sb.Append(" [PD].[PU_LINE_ID]                         AS [PU_LINE_ID]"                );
			sb.Append(",[PD].[PU_LINE_NO]                         AS [PU_LINE_NO]"                );
			sb.Append(",[PD].[PO_NO]                              AS [PO_NO]"                     );
			sb.Append(",[PD].[PO_LINE_ID]                         AS [PO_LINE_ID]"                );
			sb.Append(",[PD].[RCPT_NO]                            AS [RCPT_NO]"                   );
			sb.Append(",[PD].[RCPT_LINE_ID]                       AS [RCPT_LINE_ID]"              );
			sb.Append(",[PD].[SA_NO]                              AS [SA_NO]"                     );
			sb.Append(",[PD].[SA_LINE_ID]                         AS [SA_LINE_ID]"                );
			sb.Append(",[PD].[WH_CODE]                            AS [WH_CODE]"                   );
			sb.Append(",[W].[WH_SHORT_NAME]                       AS [WH_SHORT_NAME]"             );
			sb.Append(",[PD].[PROD_CODE]                          AS [PROD_CODE]"                 );
// 管理番号 B19475 From			
//			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_PO_NAME]"              );
			sb.Append(",[PD].[PROD_PO_NAME]						  AS [PROD_PO_NAME]"              );
// 管理番号 B19475 To			
			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_SHORT_NAME]"           );
			sb.Append(",[PD].[PROD_PO_NAME]                       AS [PROD_NAME]"                 );
			sb.Append(",[PD].[PROD_TYPE]                          AS [PROD_TYPE]"                 );
			sb.Append(",[PROD].[DISP_CONTROL_TYPE]                AS [DISP_CONTROL_TYPE]"         );
			sb.Append(",[PROD].[STOCK_ADMIN_FLG]                  AS [STOCK_ADMIN_FLG]"           );
			sb.Append(",[PROD].[LOT_ADMIN_FLG]                    AS [LOT_ADMIN_FLG]"             );
// 管理番号 K25322 From
			sb.Append(",[PROD].[LOT_STOCK_VALUATION_FLG]          AS [LOT_STOCK_VALUATION_FLG]");
// 管理番号 K25322 To
			sb.Append(",[U].[QT_DECIMAL_USE_FLG]                  AS [QT_DECIMAL_USE_FLG]"        );
			sb.Append(",[PD].[CTAX_CALC_TYPE]                     AS [CTAX_CALC_TYPE]"            );
// 管理番号 K24789 From
//// 管理番号 B24787 From
////// 管理番号 B18904 From
//////			sb.Append(",[PROD].[CTAX_RATE_CODE]                   AS [CTAX_RATE_CODE]"            );
////			if(keyColumn.OverseasFlg == "1")
////			{
////				sb.Append(",'0'									  AS [CTAX_RATE_CODE]"            );
////			}
////			else
////			{
////				sb.Append(",[PROD].[CTAX_RATE_CODE]               AS [CTAX_RATE_CODE]"            );
////			}
////// 管理番号 B18904 To
//			sb.Append(",[PROD].[CTAX_RATE_CODE]                   AS [CTAX_RATE_CODE]"            );
//// 管理番号 B24787 To
			sb.Append(",[PD].[CTAX_TYPE_CODE]                     AS [CTAX_TYPE_CODE]"            );
			sb.Append(",[PD].[CTAX_RATE_CODE]                     AS [CTAX_RATE_CODE]"            );
// 管理番号 K24789 To
			sb.Append(",[PD].[CTAX_RATE]                          AS [CTAX_RATE]"                 );
			sb.Append(",[PD].[PROD_SPEC_1_CODE]                   AS [PROD_SPEC_1_CODE]"          );
			sb.Append(",[PS1].[").Append(prodSpec1Name).Append("] AS [PROD_SPEC_1_NAME]"          );
			sb.Append(",[PD].[PROD_SPEC_2_CODE]                   AS [PROD_SPEC_2_CODE]"          );
			sb.Append(",[PS2].[").Append(prodSpec2Name).Append("] AS [PROD_SPEC_2_NAME]"          );
			sb.Append(",[PD].[PU_PLAN_PRICE]                      AS [PU_PLAN_PRICE]"             );
			sb.Append(",[PD].[STOCK_UNIT_STD_SELL_PRICE]          AS [STOCK_UNIT_STD_SELL_PRICE]" );
			sb.Append(",[PD].[UNIT_CODE]                          AS [UNIT_CODE]"                 );
			sb.Append(",[U].[").Append(unitShortName).Append("]   AS [UNIT_SHORT_NAME]"           );
			sb.Append(", CASE [PU].[PU_MODE_TYPE]"                                                );
			sb.Append(    " WHEN '2' THEN ([PD].[PU_QT] * -1)"                                    );
			sb.Append(    " ELSE [PD].[PU_QT]"                                                    );
			sb.Append( " END                                      AS [PU_QT]"                     );
			sb.Append(", CASE [PU].[PU_MODE_TYPE]"                                                );
			sb.Append(    " WHEN '2' THEN ([PD].[PU_QT] * -1)"                                    );
			sb.Append(    " ELSE [PD].[PU_QT]"                                                    );
			sb.Append( " END                                      AS [INIT_PU_QT]"                );
// 管理番号B26652 From
//// 管理番号 K20684 From
////			sb.Append(",[PD].[TRANSIT_RCPT_QT]                    AS [TRANSIT_RCPT_QT]"           );
//			if(keyColumn.RcptApprovalFlg && keyColumn.OverseasFlg == "1")
//			{
//				sb.Append(",[PD].[TRANSIT_RCPT_QT] + ISNULL([SUM_RCPT].[RCPT_QT],0) AS [TRANSIT_RCPT_QT] ");
//			}
//			else
//			{
//				sb.Append(",[PD].[TRANSIT_RCPT_QT]                    AS [TRANSIT_RCPT_QT]"           );
//			}
//// 管理番号 K20684 To
			sb.Append(",[PD].[TRANSIT_RCPT_QT]                    AS [TRANSIT_RCPT_QT]"           );
// 管理番号B26652 To
			sb.Append(",[PD].[RCPT_INPUT_NO_NEED_FLG]             AS [RCPT_INPUT_NO_NEED_FLG]"    );

			//1. 仕入数量上限値の設定ここから
			//返品時(元の仕入伝票を参照)上限は参照した仕入数量(ただし、他の仕入返品伝票で返品された数量は除く)
// 管理番号 B19369 From
//			sb.Append(  " ,CASE WHEN [PU].[PU_MODE_TYPE] = '2' THEN "                             );
			//国内仕入返品、海外仕入返品(入荷省略あり)
			sb.Append(  " ,CASE WHEN ([PU].[PU_MODE_TYPE] = '2' AND [PU].[OVERSEAS_FLG] <> '1') OR ([PU].[PU_MODE_TYPE] = '2' AND [PU].[OVERSEAS_FLG] = '1' AND [PD].[RCPT_INPUT_NO_NEED_FLG] <> '0') THEN " );
// 管理番号 B19369 To
// 管理番号 B15710 From

// 管理番号 B15710 コメント削除
// 管理番号 B14315 コメント削除

			sb.Append("		ISNULL([ORG_PUD].[PU_QT], 0) + ");
			sb.Append(  "			ISNULL((SELECT	SUM([RET_PU_D].[PU_QT]) FROM ");//他の返品伝票分の数量を減算(自伝票は除く)
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [RET_PU]");
			sb.Append(  "					INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [RET_PU_D]");
			sb.Append(  "					ON [RET_PU_D].[PU_NO] = [RET_PU].[PU_NO]"             );
			sb.Append(  "					WHERE [RET_PU].[REF_PU_NO]	= [PU].[REF_PU_NO]"       );
			sb.Append(  "						AND [RET_PU_D].[PU_LINE_ID] = [PD].[PU_LINE_ID]"  );
			sb.Append(  "						AND [RET_PU].[PU_MODE_TYPE] = '2'"                );
			sb.Append(  "						AND [RET_PU].[OPPOSITE_PU_NO] IS NULL"            );
			sb.Append(  "						AND [RET_PU].[PU_NO] <> [PD].[PU_NO]"             );
			sb.Append("		), 0)"                                                );
// 管理番号 B19369 From
			//海外仕入返品(入荷省略なし)、入荷参照時は、上限は(入荷数量-入荷返品数量)+仕入返品返品数量
			sb.Append(  "		WHEN ([PU].[PU_MODE_TYPE] = '2' AND [PU].[OVERSEAS_FLG] = '1' AND [PD].[RCPT_INPUT_NO_NEED_FLG] = '0') THEN ([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT]) + [PD].[PU_QT] * -1 " );
// 管理番号 B19369 To
			//入荷参照時、上限は参照した入荷数量
			sb.Append(  "		WHEN [PD].[RCPT_NO] IS NOT NULL THEN"                             );
			sb.Append(  "			  [RD].[RCPT_QT]"                                             );
			sb.Append(  "			- [RD].[RCPT_RETURN_QT]"                                      );
			sb.Append(  "			- [RD].[PU_QT]"                                               );
			sb.Append(  "			+ [PD].[PU_QT]"                                               );
			//受注参照時、上限は参照した入荷数量
// 管理番号 B23776 From
//			sb.Append(  " 		WHEN [PU].[OVERSEAS_FLG] = '0' AND [PD].[PO_NO] IS NOT NULL AND ([POD].[RCPT_QT] - [POD].[RCPT_RETURN_QT] - [POD].[DIRECT_PU_QT]) > 0 THEN ");
			sb.Append(  " 		WHEN [PU].[OVERSEAS_FLG] = '0' AND [PD].[PO_NO] IS NOT NULL AND ([POD].[RCPT_QT] - [POD].[RCPT_RETURN_QT] - [POD].[DIRECT_PU_QT] - (ISNULL([RD2].[RCPT_RETURN_QT],0) * [U].[INCLUDE_QT])) > 0 THEN ");
// 管理番号 B23776 To
// 管理番号 B15710 From
//			sb.Append(  "			ISNULL((SELECT	  SUM([R_L_D].[RCPT_QT])"                     );
//			sb.Append(  " 							- SUM([R_L_D].[RCPT_RETURN_QT])"              );
//			sb.Append(  " 							- SUM([R_L_D].[PU_QT])"                       );
//			sb.Append(  "					 FROM "                                               );
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [R_D]");
//			sb.Append(  "					INNER JOIN "                                          );
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_LOT_DTIL]")).Append(" AS [R_L_D]");
//			sb.Append(  "						ON  [R_D].[RCPT_NO]      = [R_L_D].[RCPT_NO]"     );
//			sb.Append(  "						AND [R_D].[RCPT_LINE_ID] = [R_L_D].[RCPT_LINE_ID]");
//			sb.Append(  "					INNER JOIN "                                          );
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R]");
//			sb.Append(  "						ON  [R].[RCPT_NO]        = [R_D].[RCPT_NO]"       );
//			sb.Append(  "						AND [R].[RCPT_MODE_TYPE] = '1'"                   );
//			sb.Append(  "					 WHERE  [R_D].[PO_NO]      = [PD].[PO_NO]"            );
//			sb.Append(  "						AND [R_D].[PO_LINE_ID] = [PD].[PO_LINE_ID]"       );
//			sb.Append(  "						AND [R_D].[DELETE_FLG] <> 1 "                     );
// 管理番号 B15710 To
			sb.Append(  "			ISNULL([WK_RCPT].[SUM_QT], 0) + [PD].[PU_QT] "     );
			sb.Append(  " 		WHEN [PU].[OVERSEAS_FLG] = '1' THEN "                             );
// 管理番号 K25647 From
//			sb.Append(  "			  [POD].[PO_QT] - ([POD].[RCPT_PU_QT] + [POD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT] + [PD].[PU_QT]");
			sb.Append(  "			  [POD].[PO_QT] - CAST(([POD].[RCPT_PU_QT] + [POD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT] AS DECIMAL(28, 5)) + [PD].[PU_QT]");
// 管理番号 K25647 To
			sb.Append(  "  ELSE 0 END                             AS [UPPER_LIMIT_PU_QT]"         );
			//1. 仕入数量上限値の設定ここまで

			sb.Append(",ISNULL([ST].[VALID_QT],0)                 AS [VALID_QT]"                  );
			sb.Append(",CASE WHEN [PU].[PU_MODE_TYPE] = '2' "                                     );
			sb.Append("    THEN [PD].[STOCK_UNIT_PU_QT] * -1 "                                    );
			sb.Append("    ELSE [PD].[STOCK_UNIT_PU_QT] "                                         );
			sb.Append(" END                                       AS [STOCK_UNIT_PU_QT] "         );

			//2. 在庫単位受注仕入数量の設定ここから
			//返品時(元の仕入伝票を参照)上限は参照した在庫単位受注売上数量
			sb.Append(  " ,CASE WHEN [PU].[PU_MODE_TYPE] = '2' THEN "                             );
// 管理番号 B15710 From
// 管理番号 B15710 コメント削除
			sb.Append("			ISNULL([ORG_PUD].[STOCK_UNIT_PO_PU_QT], 0) - "                                             );
// 管理番号 B15710 コメント削除
			sb.Append("			ISNULL([ORG_REF_PUD].[STOCK_UNIT_PO_PU_QT], 0) "                                               );
// 管理番号 B15710 To
			//入荷参照時、上限は参照した入荷数量
			sb.Append(  "		WHEN [PD].[RCPT_NO] IS NOT NULL THEN"                             );
			sb.Append(  "			([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - [RD].[PU_QT]) * [U].[INCLUDE_QT] ");
			//発注参照時、上限は参照した入荷数量
// 管理番号 B23776 From
//			sb.Append(  " 		WHEN [PU].[OVERSEAS_FLG] = '0' AND [PD].[PO_NO] IS NOT NULL AND ([POD].[RCPT_QT] - [POD].[RCPT_RETURN_QT] - [POD].[DIRECT_PU_QT]) > 0 THEN ");
			sb.Append(  " 		WHEN [PU].[OVERSEAS_FLG] = '0' AND [PD].[PO_NO] IS NOT NULL AND ([POD].[RCPT_QT] - [POD].[RCPT_RETURN_QT] - [POD].[DIRECT_PU_QT] - (ISNULL([RD2].[RCPT_RETURN_QT],0) * [U].[INCLUDE_QT])) > 0 THEN ");
// 管理番号 B23776 To
// 管理番号 B15710 From
//			sb.Append(  "			ISNULL((SELECT    SUM([R_L_D].[RCPT_QT])"                     );
//			sb.Append(  " 							- SUM([R_L_D].[RCPT_RETURN_QT])"              );
//			sb.Append(  " 							- SUM([R_L_D].[PU_QT])"                       );
//			sb.Append(  "					 FROM "                                               );
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [R_D]");
//			sb.Append(  "						INNER JOIN "                                      );
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_LOT_DTIL]")).Append(" AS [R_L_D]");
//			sb.Append(  "							ON  [R_D].[RCPT_NO]      = [R_L_D].[RCPT_NO]" );
//			sb.Append(  "							AND [R_D].[RCPT_LINE_ID] = [R_L_D].[RCPT_LINE_ID]");
//			sb.Append(  "						INNER JOIN "                                      );
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R]");
//			sb.Append(  "							ON  [R].[RCPT_NO]        = [R_D].[RCPT_NO]"   );
//			sb.Append(  "							AND [R].[RCPT_MODE_TYPE] = '1'"               );
//			sb.Append(  "						WHERE  [R_D].[PO_NO]      = [PD].[PO_NO]"         );
//			sb.Append(  "							AND [R_D].[PO_LINE_ID] = [PD].[PO_LINE_ID]"   );
//			sb.Append(  "							AND [R_D].[DELETE_FLG] <> 1 "                 );
// 管理番号 B15710 To
			sb.Append(  "			ISNULL([WK_RCPT].[SUM_QT], 0) * [U].[INCLUDE_QT] " );
// 管理番号 B23776 From
//			sb.Append(  " 		WHEN [PU].[OVERSEAS_FLG] = '0' AND [PD].[PO_NO] IS NOT NULL AND ([POD].[RCPT_QT] - [POD].[RCPT_RETURN_QT] - [POD].[DIRECT_PU_QT]) = 0 THEN ");
//			sb.Append(  "           [POD].[PO_QT] * [U].[INCLUDE_QT] - ([POD].[RCPT_PU_QT] + [POD].[DIRECT_PU_QT] - [POD].[RCPT_RETURN_QT]) ");
			sb.Append(  " 		WHEN [PU].[OVERSEAS_FLG] = '0' AND [PD].[PO_NO] IS NOT NULL AND ([POD].[RCPT_QT] - [POD].[RCPT_RETURN_QT] - [POD].[DIRECT_PU_QT] - (ISNULL([RD2].[RCPT_RETURN_QT],0) * [U].[INCLUDE_QT])) = 0 THEN ");
			sb.Append(  "           (([POD].[PO_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0)) * [U].[INCLUDE_QT]) - ([POD].[RCPT_PU_QT] + [POD].[DIRECT_PU_QT] - [POD].[RCPT_RETURN_QT]) ");
// 管理番号 B23776 To
			sb.Append(  " 		WHEN [PU].[OVERSEAS_FLG] = '1' THEN "                             );
			sb.Append(  "			[POD].[PO_QT] * [U].[INCLUDE_QT] - ([POD].[RCPT_PU_QT] + [POD].[DIRECT_PU_QT])  ");
			sb.Append(  "  ELSE 0 END + [PD].[STOCK_UNIT_PO_PU_QT] AS [STOCK_UNIT_PO_PU_QT]"      );
			//2. 在庫単位受注売上数量の設定ここまで

			sb.Append(",CASE WHEN [PU].[PU_MODE_TYPE] = '2' "                                     );
			sb.Append("    THEN [PD].[STOCK_UNIT_PO_ALLOC_PU_QT] * -1 "                           );
			sb.Append("    ELSE [PD].[STOCK_UNIT_PO_ALLOC_PU_QT] "                                );
			sb.Append(" END                                       AS [STOCK_UNIT_PO_ALLOC_PU_QT] ");
			sb.Append(",[PD].[PU_PRICE]                           AS [PU_PRICE]"                  );
			sb.Append(",[PD].[PU_PRICE]                           AS [INIT_PU_PRICE]"             );
			sb.Append(",[PD].[DISC_FLG]                           AS [DISC_FLG]"                  );
// 管理番号 B13878 From
			sb.Append(",[PD].[PRICE_UNDECIDED_FLG]				  AS [PRICE_UNDECIDED_FLG]"		  );
// 管理番号 B13878 To
			sb.Append(",[PD].[LINE_REMARKS_CODE]                  AS [LINE_REMARKS_CODE]"         );
			sb.Append(",[PD].[LINE_REMARKS]                       AS [LINE_REMARKS]"              );
// 管理番号K27525 From
			sb.Append(",[PD].[BOOK_DEDUCTION_REASON_CODE]         AS [BOOK_DEDUCTION_REASON_CODE]");
			sb.Append(",[BDR].[BOOK_DEDUCTION_REASON_NAME]        AS [BOOK_DEDUCTION_REASON_NAME]");
// 管理番号K27525 To
// 管理番号 K16671 From
			sb.Append(",[PD].[REF_CODE]                           AS [REF_CODE]"                  );
// 管理番号 K16671 To
// 管理番号 B20244 From
			sb.Append(",[U].[INCLUDE_QT]                          AS [INCLUDE_QT]"                );
// 管理番号 B20244To
			sb.Append(",[PD].[DTIL_AMT]                           AS [DTIL_AMT]"                  );
			sb.Append(",[PD].[ETAX_AMT]                           AS [ETAX_AMT]"                  );
			sb.Append(",[PD].[ITAX_AMT]                           AS [ITAX_AMT]"                  );
			sb.Append(",'0'                                       AS [PRICE_UPDATE_FLG]"          );
// 管理番号 B11723・B11796 From
//			sb.Append(", CASE [PU].[PU_MODE_TYPE]"                                                );
//			sb.Append(    " WHEN '2' THEN ([PD].[PU_QT] * -1) * [PD].[PU_PRICE]"                  );
//			sb.Append(    " ELSE [PD].[PU_QT] * [PD].[PU_PRICE]"                                  );
//			sb.Append( " END AS [PU_MONEY]"                                                       );
			sb.Append(", CASE [PU].[PU_MODE_TYPE] WHEN '2' THEN [PD].[DTIL_AMT]*(-1) ELSE [PD].[DTIL_AMT] END AS [PU_MONEY]");
// 管理番号 B11723・B11796 To
			sb.Append(",[PROD].[PROD_NAME_CORRECT_ALLOW_FLG]      AS [PROD_NAME_CORRECTION_FLG]"  );
			//商品変更可否
// 管理番号B27082 From
//			sb.Append(",CASE WHEN ([PD].[PO_NO] IS NULL) AND ([PD].[RCPT_NO] IS NULL) AND ([PU].[PU_MODE_TYPE] <> '2' )");
			sb.Append(",CASE WHEN ([PD].[PO_NO] IS NULL) AND ([PD].[RCPT_NO] IS NULL) AND ([PU].[PU_MODE_TYPE] <> N'2' OR ([PU].[PU_MODE_TYPE] = N'2' AND [PU].[REF_PU_NO] IS NULL))");
// 管理番号B27082 To
			sb.Append("     THEN '1'"                                                             );
			sb.Append("     ELSE '0'"                                                             );
			sb.Append(" END                                       AS [PROD_EDIT_FLG]"             );
			sb.Append(",CASE WHEN ([R_D].[RCPT_CNT] = 0 )"                                        );
			sb.Append("     THEN '0'"                                                             );
			sb.Append("     ELSE '1'"                                                             );
			sb.Append(" END                                       AS [IS_RCPT_EXECUTE]"           );
			sb.Append(",'R'                                       AS [ROW_STATE]"                 );
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputDetail, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PD", "CUSTOM_ITEM_TAG", "@PU_DATE", null, true);
// 管理番号K27057 To

			//仕入
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			//仕入明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PD]");
			sb.Append(" ON [PU].[PU_NO] = [PD].[PU_NO]");
// 管理番号 B15710 From
			//商品
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [PROD]");
			sb.Append(" ON  [PD].[PROD_CODE]   = [PROD].[PROD_CODE]");
			sb.Append(" AND [PROD].[PROD_TYPE] = '0' ");//通常商品のみ
			//商品規格1
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_1]")).Append(" AS [PS1]");
			sb.Append(" ON [PD].[PROD_SPEC_1_CODE] = [PS1].[PROD_SPEC_1_CODE]");
			//商品規格2
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_2]")).Append(" AS [PS2]");
			sb.Append(" ON [PD].[PROD_SPEC_2_CODE] = [PS2].[PROD_SPEC_2_CODE]");
			//単位別商品属性
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
			sb.Append(" ON [PD].[PROD_CODE] = [U].[PROD_CODE]");
			sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE] ");
// 管理番号 B15710 To
			//発注明細 入荷済み判定で使用
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO_DTIL]")).Append(" AS [POD]");
			sb.Append(" ON  [PD].[PO_NO]      = [POD].[PO_NO]");
			sb.Append(" AND [PD].[PO_LINE_ID] = [POD].[PO_LINE_ID]");
// 管理番号 B23776 From
//			//出荷明細
//			sb.Append(" LEFT OUTER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD]");
//			sb.Append(" ON  [PD].[RCPT_NO]      = [RD].[RCPT_NO]");
//			sb.Append(" AND [PD].[RCPT_LINE_ID] = [RD].[RCPT_LINE_ID]");
			// 入荷明細
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(" ( ");
			sb.Append("    SELECT ");
			sb.Append("     [R_D].[RCPT_NO]        AS [RCPT_NO] ");
			sb.Append("    ,[R_D].[RCPT_LINE_ID]   AS [RCPT_LINE_ID] ");
			sb.Append("    ,SUM([R_D].[RCPT_QT]) AS [RCPT_QT] ");
			sb.Append("    ,SUM([R_D].[RCPT_RETURN_QT]) AS [RCPT_RETURN_QT] ");
			sb.Append("    ,SUM([R_D].[PU_QT]) AS [PU_QT] ");
			sb.Append("	   FROM ");
			sb.Append("		( ");
			sb.Append("			SELECT ");
			sb.Append("			 [RCPT].[RCPT_NO] ");
			sb.Append("			,[RCPT_D].[RCPT_LINE_ID] ");
			sb.Append("			,[RCPT_D].[RCPT_QT] ");
			sb.Append("			,[RCPT_D].[RCPT_RETURN_QT] ");
			sb.Append("			,[RCPT_D].[PU_QT] ");
			sb.Append("			FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT] ");
			sb.Append("			INNER JOIN  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RCPT_D] ");
			sb.Append("			ON  [RCPT_D].[RCPT_NO] = [RCPT].[RCPT_NO]");
			WherePhraseBuilder wpbSub1 = new WherePhraseBuilder();
			wpbSub1.AddFilter("	[RCPT].[RCPT_MODE_TYPE]", SearchOperator.Equal, "1");
			wpbSub1.AddFilter("	[RCPT].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub1.AddFilter("	[RCPT].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "3");
			wpbSub1.AddFilter("	[RCPT_D].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub1);
			sb.Append("			UNION ALL ");
			sb.Append("			 SELECT ");
			sb.Append("           [RCPT].[REF_RCPT_NO] AS [RCPT_NO] ");
			sb.Append("			 ,[RCPT_D].[RCPT_LINE_ID] ");
			sb.Append("			 ,[RCPT_D].[RCPT_QT] ");
			sb.Append("			 ,[RCPT_D].[RCPT_RETURN_QT] ");
			sb.Append("			 ,[RCPT_D].[PU_QT] ");
			sb.Append("			 FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT] ");
			sb.Append("          INNER JOIN  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RCPT_D] ");
			sb.Append("          ON  [RCPT_D].[RCPT_NO] = [RCPT].[RCPT_NO]");
			WherePhraseBuilder wpbSub2 = new WherePhraseBuilder();
			wpbSub2.AddFilter("     [RCPT].[RCPT_MODE_TYPE]", SearchOperator.Equal, "2");
			wpbSub2.AddFilter("     [RCPT].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub2.AddFilter("     [RCPT].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "1");
			wpbSub2.AddFilter("     [RCPT_D].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub2);
			sb.Append("       ) AS [R_D] ");
			sb.Append(" GROUP BY ");
			sb.Append(" [R_D].[RCPT_NO], ");
			sb.Append(" [R_D].[RCPT_LINE_ID] ");
			sb.Append(" ) AS [RD] ");
			sb.Append(" ON  [PD].[RCPT_NO]      = [RD].[RCPT_NO]");
			sb.Append(" AND [PD].[RCPT_LINE_ID] = [RD].[RCPT_LINE_ID]");

			//入荷返品明細サマリ(未承認)
			sb.Append(" LEFT OUTER JOIN ( ");
			sb.Append("			SELECT ");
			sb.Append("			 [R].[PO_NO] ");
			sb.Append("			,[RD].[PO_LINE_ID] ");
			sb.Append("			,SUM([RD].[RCPT_QT])*-1 AS [RCPT_RETURN_QT] ");
			sb.Append("			FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R]");
			sb.Append("			INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD]");
			sb.Append("			ON [RD].[RCPT_NO]=[R].[RCPT_NO] ");
			WherePhraseBuilder wpbSub3 = new WherePhraseBuilder();
			wpbSub3.AddFilter("	[R].[RCPT_MODE_TYPE]", SearchOperator.Equal, "2");
			wpbSub3.AddFilter("	[R].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "1");
			wpbSub3.AddFilter("	[R].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub3.AddFilter("	[RD].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub3);
			sb.Append("			GROUP BY [R].[PO_NO],[RD].[PO_LINE_ID] ");
			sb.Append(" ) AS [RD2] ");
			sb.Append(" ON  [RD2].[PO_NO]=[PD].[PO_NO] ");
			sb.Append(" AND [RD2].[PO_LINE_ID]=[PD].[PO_LINE_ID] ");
// 管理番号 B23776 To
			//入荷
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R] ");
// 管理番号 B23776 From
//			sb.Append("  ON [R].[RCPT_NO]        = [RD].[RCPT_NO] "     );
			sb.Append("  ON [R].[RCPT_NO]        = [PD].[RCPT_NO] "     );
// 管理番号 B23776 To
			//入荷ロット数
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append("    (SELECT [PU_L_D].[PU_LINE_ID] AS [PU_LINE_ID], ");
			sb.Append("            COUNT([PU_L_D].[RCPT_NO]) AS [RCPT_CNT] ");
            sb.Append("     FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_LOT_DTIL]")).Append(" AS [PU_L_D]");
			wpb.AddFilter("[PU_L_D].[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			sb.Append(wpb);
			sb.Append("GROUP BY     [PU_L_D].[PU_LINE_ID]) [R_D]");
			sb.Append("ON [R_D].[PU_LINE_ID] = [PD].[PU_LINE_ID]");

// 管理番号 B15710 From
//			//商品
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [PROD]");
//			sb.Append(" ON  [PD].[PROD_CODE]   = [PROD].[PROD_CODE]");
//			sb.Append(" AND [PROD].[PROD_TYPE] = '0' ");//通常商品のみ
//			//商品規格1
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_1]")).Append(" AS [PS1]");
//			sb.Append(" ON [PD].[PROD_SPEC_1_CODE] = [PS1].[PROD_SPEC_1_CODE]");
//			//商品規格2
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_2]")).Append(" AS [PS2]");
//			sb.Append(" ON [PD].[PROD_SPEC_2_CODE] = [PS2].[PROD_SPEC_2_CODE]");
// 管理番号 B15710 To
			//倉庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[WH]")).Append(" AS [W]");
			sb.Append(" ON [PD].[WH_CODE] = [W].[WH_CODE]");
// 管理番号 B15710 From
//			//単位別商品属性
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
//			sb.Append(" ON [PD].[PROD_CODE] = [U].[PROD_CODE]");
//			sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE] ");
// 管理番号 B15710 To
			//在庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[STOCK]")).Append(" AS [ST]");
			sb.Append(" ON  [PD].[WH_CODE]          = [ST].[WH_CODE] ");
			sb.Append(" AND [PD].[PROD_CODE]        = [ST].[PROD_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [ST].[PROD_SPEC_1_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [ST].[PROD_SPEC_2_CODE] ");
			sb.Append(" AND [ST].[DEPT_CODE]        = @STOCK_ADMIN_DEPT_CODE ");
// 管理番号 B13877 From
			if (keyColumn.ProjectStockAdminUseFlg)
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ISNULL([PU].[PROJ_CODE],'')");
				sb.Append(" AND [ST].[PROJ_SBNO] = ISNULL([PU].[PROJ_SBNO],'')");
			}
			else
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ''");
				sb.Append(" AND [ST].[PROJ_SBNO] = ''");
			}
// 管理番号 B13877 To
// 管理番号K27525 From
			// 帳簿控除理由
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[BOOK_DEDUCTION_REASON]")).Append(" AS [BDR]");
			sb.Append(" ON [BDR].[BOOK_DEDUCTION_REASON_CODE] = [PD].[BOOK_DEDUCTION_REASON_CODE] ");
// 管理番号K27525 To
// 管理番号 B15710 From
			sb.Append(" LEFT OUTER JOIN ( ");
			sb.Append(" 					SELECT ");
			sb.Append(" 					    CASE ");
			sb.Append(" 					        WHEN [WK_PU].[RCPT_INPUT_NO_NEED_FLG] = '1' ");
			sb.Append(" 							THEN [ORG_PU_D].[PU_QT] ");
			sb.Append(" 					        ELSE [ORG_PU_D].[TRANSIT_RCPT_QT] ");
			sb.Append(" 					    END AS [PU_QT], ");
			sb.Append(" 						ISNULL([ORG_PU_D].[STOCK_UNIT_PO_PU_QT],0) AS [STOCK_UNIT_PO_PU_QT], ");
			sb.Append(" 						[ORG_PU_D].[PU_LINE_ID] ");
			sb.Append(" 					FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [ORG_PU] ");
			sb.Append(" 					INNER JOIN  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [ORG_PU_D] ");
			sb.Append(" 						ON [ORG_PU_D].[PU_NO] = [ORG_PU].[PU_NO] ");
			sb.Append(" 					INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [WK_PU] ");
			sb.Append(" 						ON [WK_PU].[REF_PU_NO] = [ORG_PU].[PU_NO] ");
			sb.Append(" 					WHERE ");
			sb.Append(" 					    [ORG_PU_D].[PU_NO] = [WK_PU].[REF_PU_NO] ");
			sb.Append(" 					AND [ORG_PU].[OPPOSITE_PU_NO] IS NULL ");
			sb.Append("						AND [WK_PU].[PU_NO] = '").Append((ParamString)keyColumn.SlipNo).Append("' ");	// 管理番号K27230
			sb.Append(" ) [ORG_PUD] ");
			sb.Append(" 	ON [ORG_PUD].[PU_LINE_ID] = [PD].[PU_LINE_ID] ");
			sb.Append(" LEFT OUTER JOIN ( ");
			sb.Append(" 					SELECT ");
			sb.Append(" 					    SUM(ISNULL([ORG_REF_PU_D].[STOCK_UNIT_PO_PU_QT],0)) AS [STOCK_UNIT_PO_PU_QT], ");
			sb.Append(" 						[ORG_REF_PU_D].[PU_LINE_ID] ");
			sb.Append(" 					FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [ORG_REF_PU] ");
			sb.Append(" 					INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [ORG_REF_PU_D] ");
			sb.Append(" 						ON [ORG_REF_PU].[PU_NO] = [ORG_REF_PU_D].[PU_NO] ");
			sb.Append(" 					INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [WK_PU] ");
			sb.Append(" 						ON [WK_PU].[REF_PU_NO] = [ORG_REF_PU].[REF_PU_NO] ");
			sb.Append(" 					WHERE ");
			sb.Append(" 					    [ORG_REF_PU].[REF_PU_NO] = [WK_PU].[REF_PU_NO] ");
			sb.Append(" 					AND [ORG_REF_PU].[OPPOSITE_PU_NO] IS NULL ");
			sb.Append("						AND [WK_PU].[PU_NO] = '").Append((ParamString)keyColumn.SlipNo).Append("' ");	// 管理番号K27230
			sb.Append(" 					GROUP BY ");
			sb.Append(" 						[ORG_REF_PU_D].[PU_LINE_ID] ");
			sb.Append(" ) [ORG_REF_PUD] ");
			sb.Append(" 	ON [ORG_REF_PUD].[PU_LINE_ID] = [PD].[PU_LINE_ID] ");
			sb.Append(" LEFT OUTER JOIN (");
			sb.Append(" 				SELECT ");
			sb.Append(" 					SUM(ISNULL([R_L_D].[RCPT_QT],0)) ");
			sb.Append(" 					- SUM(ISNULL([R_L_D].[RCPT_RETURN_QT],0)) ");
// 管理番号 B23776 From
			sb.Append(" 					- SUM(ISNULL([R_D2].[RCPT_RETURN_QT],0)) ");
// 管理番号 B23776 To
			sb.Append(" 					- SUM(ISNULL([R_L_D].[PU_QT],0)) AS [SUM_QT] ");
			sb.Append(" 					,[R_D].[PO_NO] ");
			sb.Append(" 					,[R_D].[PO_LINE_ID] ");
			sb.Append(" 				FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [R_D]");
			sb.Append(" 				INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_LOT_DTIL]")).Append(" AS [R_L_D]");
			sb.Append(" 					ON [R_D].[RCPT_NO] = [R_L_D].[RCPT_NO] ");
			sb.Append(" 					AND [R_D].[RCPT_LINE_ID] = [R_L_D].[RCPT_LINE_ID] ");
			sb.Append(" 				INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R]");
			sb.Append(" 					ON [R].[RCPT_NO] = [R_D].[RCPT_NO] ");
			sb.Append(" 					AND [R].[RCPT_MODE_TYPE] = '1' ");
			sb.Append(" 				INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [WK_PU_D] ");
			sb.Append(" 					ON [WK_PU_D].[PO_NO] = [R_D].[PO_NO] ");
			sb.Append(" 					AND [WK_PU_D].[PO_LINE_ID] = [R_D].[PO_LINE_ID] ");
// 管理番号 B23776 From
			//入荷返品明細サマリ(未承認)
			sb.Append(" LEFT OUTER JOIN ( ");
			sb.Append("					 SELECT ");
			sb.Append("						 [R].[REF_RCPT_NO] ");
			sb.Append("						,[RD].[RCPT_LINE_ID] ");
			sb.Append("						,[RLD].[LOT_NO] ");
			sb.Append("						,SUM([RLD].[RCPT_QT])*-1 AS [RCPT_RETURN_QT] ");
			sb.Append("					 FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R]");
			sb.Append("					 INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD]");
			sb.Append("					 ON [RD].[RCPT_NO]=[R].[RCPT_NO] ");
			sb.Append("					 INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_LOT_DTIL]")).Append(" AS [RLD]");
			sb.Append("					 ON  [RLD].[RCPT_NO]=[RD].[RCPT_NO] ");
			sb.Append("					 AND [RLD].[RCPT_LINE_ID]=[RD].[RCPT_LINE_ID] ");
			WherePhraseBuilder wpbSub_D2 = new WherePhraseBuilder();
			wpbSub_D2.AddFilter("		[R].[RCPT_MODE_TYPE]", SearchOperator.Equal, "2");
			wpbSub_D2.AddFilter("		[R].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "1");
			wpbSub_D2.AddFilter("		[R].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub_D2.AddFilter("		[RD].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub_D2.AddFilter("		[RLD].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub_D2);
			sb.Append("					 GROUP BY [R].[REF_RCPT_NO],[RD].[RCPT_LINE_ID],[RLD].[LOT_NO] ");
			sb.Append(" ) AS [R_D2] ");
			sb.Append(" ON  [R_D2].[REF_RCPT_NO]=[R_L_D].[RCPT_NO] ");
			sb.Append(" AND [R_D2].[RCPT_LINE_ID]=[R_L_D].[RCPT_LINE_ID] ");
			sb.Append(" AND [R_D2].[LOT_NO]=[R_L_D].[LOT_NO] ");
// 管理番号 B23776 To
			sb.Append(" 				WHERE ");
			sb.Append(" 					[R_D].[DELETE_FLG] = 0 ");
			sb.Append("					AND [WK_PU_D].[PU_NO] = '").Append((ParamString)keyColumn.SlipNo).Append("' ");	// 管理番号K27230
// 管理番号 B23776 From
			sb.Append(" 				AND [R].[RCPT_APPROVAL_STATUS_TYPE] = '3' ");
// 管理番号 B23776 To
			sb.Append(" 				GROUP BY ");
			sb.Append(" 					 [R_D].[PO_NO] ");
			sb.Append(" 					,[R_D].[PO_LINE_ID] ");
			sb.Append(" ) [WK_RCPT] ");
			sb.Append(" 	ON [WK_RCPT].[PO_NO] = [PD].[PO_NO] ");
			sb.Append(" 	AND [WK_RCPT].[PO_LINE_ID] = [PD].[PO_LINE_ID] ");
// 管理番号 B15710 To
// 管理番号B26652 From
//// 管理番号 K20684 From
//			if(keyColumn.RcptApprovalFlg && keyColumn.OverseasFlg == "1")
//			{
//				sb.Append(" LEFT OUTER JOIN (");
//				sb.Append(" 				SELECT ");
//				sb.Append(" 					[RD].[PU_NO] AS [PU_NO] ");
//				sb.Append(" 					,[RD].[PU_LINE_ID] AS [PU_LINE_ID] ");
//				sb.Append("                     ,[R].[RCPT_APPROVAL_STATUS_TYPE] AS [RCPT_APPROVAL_STATUS_TYPE] ");
//				sb.Append(" 					,SUM(ISNULL([RD].[RCPT_QT],0)) AS [RCPT_QT] ");
//				sb.Append(" 				FROM ");
//				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD] ");
//				sb.Append(" INNER JOIN ");
//				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R] ");
//				sb.Append(" 	ON [R].[RCPT_NO] = [RD].[RCPT_NO] ");
//				sb.Append(" 				WHERE ");
//				sb.Append("					    [RD].[PU_NO] = '").Append(keyColumn.SlipNo).Append("' ");
//				sb.Append(" 				AND [RD].[DELETE_FLG] = 0 ");
//				sb.Append(" 				AND [R].[RCPT_APPROVAL_STATUS_TYPE] = '1' ");
//				sb.Append(" 				GROUP BY ");
//				sb.Append("                      [RD].[PU_NO] ");
//				sb.Append("                     ,[RD].[PU_LINE_ID] ");
//				sb.Append("                     ,[R].[RCPT_APPROVAL_STATUS_TYPE] ");
//				sb.Append(" ) AS [SUM_RCPT] ");
//				sb.Append(" 	ON [PD].[PU_NO] = [SUM_RCPT].[PU_NO] ");
//				sb.Append("     AND [PD].[PU_LINE_ID] = [SUM_RCPT].[PU_LINE_ID] ");
//			}
//// 管理番号 K20684 To
// 管理番号B26652 To
			wpb = new WherePhraseBuilder();
			wpb.AddFilter("[PD].[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[PD].[PU_QT]", SearchOperator.NotEqual, 0);
			wpb.AddFilter("([R].[RCPT_MODE_TYPE]", SearchOperator.Equal, DBNull.Value);
			wpb.AppendFilter( ConnectionWord.Or,"[R].[RCPT_MODE_TYPE]", SearchOperator.Equal, "1");
			wpb.Append(")");
			sb.Append(wpb);
			sb.Append("ORDER BY [PD].[PU_LINE_NO] ASC ");

			return sb.ToSqlPString();	// 管理番号K27230
		}
		//仕入ロット明細
		private static string CreatePuLotDetailString(CommonData commonData,IF_SC_MM_05_KeyColumn keyColumn, bool rcptInputNoNeedFlg)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();

// 管理番号 B14315 From
			if(rcptInputNoNeedFlg)
			{
// 管理番号 B14315 To
				sb.Append("SELECT ");
				sb.Append(" [P_L_D].[PU_LINE_ID]          AS [ROW_ID]      ,");
				sb.Append(" [P_L_D].[LOT_NO]              AS [LOT_NO]      ,");
				sb.Append(" [LOT].[FAB_DATE]              AS [FAB_DATE]    ,");
// 管理番号 B22625 From
//				sb.Append(" DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE]) AS [TERM_DATE] ,");
				sb.Append(" CASE WHEN CONVERT(DATETIME,'9998/12/31') - [LOT].[FAB_DATE] < [P].[LOT_VALID_TERM_DAY_CNT]-1");
				sb.Append(   " THEN CONVERT(DATETIME,'9998/12/31')");
				sb.Append(   " ELSE DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE])");
				sb.Append(" END AS [TERM_DATE] ,");
// 管理番号 B22625 To
				sb.Append(" [P_L_D].[PU_LOT_ID]           AS [LOT_ID]      ,");
				sb.Append(" CASE WHEN [PU].[PU_MODE_TYPE] = '4' THEN '2' ELSE '1' END AS [STOCK_TYPE]  ,");
				sb.Append(" 0                             AS [STOCK_QT]    ,");
				sb.Append(" CASE [PU].[PU_MODE_TYPE]                        ");
				sb.Append(   " WHEN '2' THEN ([P_L_D].[PU_QT] * -1)         ");
				sb.Append(   " ELSE [P_L_D].[PU_QT]                         ");
				sb.Append(" END AS [INIT_QT]                               ,");
				sb.Append(" CASE [PU].[PU_MODE_TYPE]                        ");
				sb.Append(   " WHEN '2' THEN ([P_L_D].[PU_QT] * -1)         ");
				sb.Append(   " ELSE [P_L_D].[PU_QT]                         ");
				sb.Append(" END AS [EDIT_QT]                               ,");
				sb.Append(" [P_L_D].[TRANSIT_RCPT_QT]     AS [TRANSIT_RCPT_QT],");
				sb.Append(" [P_L_D].[RCPT_NO]             AS [RCPT_NO]     ,");
				sb.Append(" [P_L_D].[RCPT_LINE_ID]        AS [RCPT_LINE_ID],");
				sb.Append(" [P_L_D].[RCPT_LOT_ID]         AS [RCPT_LOT_ID] ,");
				sb.Append(" [P_L_D].[SA_NO]               AS [SA_NO]       ,");
				sb.Append(" [P_L_D].[SA_LINE_ID]          AS [SA_LINE_ID]  ,");
				sb.Append(" [P_L_D].[SA_LOT_ID]           AS [SA_LOT_ID]    ");
// 管理番号 K25322 From
				sb.Append(",CASE WHEN [PU].[PU_MODE_TYPE] = N'2'            ");
				sb.Append("    THEN [P_L_D].[STOCK_UNIT_PO_ALLOC_PU_QT] * -1");
				sb.Append("    ELSE [P_L_D].[STOCK_UNIT_PO_ALLOC_PU_QT]     ");
				sb.Append(" END                           AS [PO_ALLOC_RCPT_QT]"); //在庫単位発注引当仕入数量
// 管理番号 K25322 To

				//仕入
				sb.Append(" FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
				//仕入明細
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PD]");
				sb.Append(" ON  [PU].[PU_NO] = [PD].[PU_NO] ");
				//仕入ロット明細
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_LOT_DTIL]")).Append(" AS [P_L_D]");
				sb.Append(" ON  [PD].[PU_NO]      = [P_L_D].[PU_NO] ");
				sb.Append(" AND [PD].[PU_LINE_ID] = [P_L_D].[PU_LINE_ID] ");
				sb.Append(" AND (([P_L_D].[RCPT_NO] IS NOT NULL) OR ([P_L_D].[RCPT_NO] IS NULL AND [P_L_D].[LOT_NO] <> '9'))");
				//入荷
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");
				sb.Append(" ON  [P_L_D].[RCPT_NO] = [RCPT].[RCPT_NO] ");
				//商品
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [P]");
				sb.Append(" ON  [PD].[PROD_CODE] = [P].[PROD_CODE] ");
				//ロット
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[LOT]")).Append(" AS [LOT]");
				sb.Append(" ON  [PD].[PROD_CODE]        = [LOT].[PROD_CODE] ");
				sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [LOT].[PROD_SPEC_1_CODE] ");
				sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [LOT].[PROD_SPEC_2_CODE] ");
				sb.Append(" AND [P_L_D].[LOT_NO]        = [LOT].[LOT_NO] ");

				//単位別商品属性
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
				sb.Append(" ON  [PD].[PROD_CODE] = [U].[PROD_CODE] ");
				sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE]");

				wpb.AddFilter("[PU].[PU_NO]"    , SearchOperator.Equal, keyColumn.SlipNo);
				wpb.AddFilter("[P_L_D].[PU_QT]", SearchOperator.NotEqual, 0);
				sb.Append(wpb);
				sb.Append("ORDER BY [LOT].[FAB_DATE] ASC, [P_L_D].[PU_LOT_ID] ASC, [RCPT].[RCPT_DATE] ASC, [P_L_D].[RCPT_NO] ASC");
			}
			else
			{
				sb.Append("SELECT ");
// 管理番号 K25322 From
//				sb.Append(" [R_L_D].[PU_LINE_ID]          AS [ROW_ID]      ,");
//				sb.Append(" [R_L_D].[LOT_NO]              AS [LOT_NO]      ,");
				sb.Append(" [P_L_D].[PU_LINE_ID]          AS [ROW_ID]      ,");
				sb.Append(" [P_L_D].[LOT_NO]              AS [LOT_NO]      ,");
// 管理番号 K25322 To
				sb.Append(" [LOT].[FAB_DATE]              AS [FAB_DATE]    ,");
// 管理番号 B22625 From
//				sb.Append(" DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE]) AS [TERM_DATE] ,");
				sb.Append(" CASE WHEN CONVERT(DATETIME,'9998/12/31') - [LOT].[FAB_DATE] < [P].[LOT_VALID_TERM_DAY_CNT]-1");
				sb.Append(   " THEN CONVERT(DATETIME,'9998/12/31')");
				sb.Append(   " ELSE DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE])");
				sb.Append(" END AS [TERM_DATE] ,");
// 管理番号 B22625 To
				sb.Append(" [P_L_D].[PU_LOT_ID]           AS [LOT_ID]      ,");
				sb.Append(" CASE WHEN [PU].[PU_MODE_TYPE] = '4' THEN '2' ELSE '1' END AS [STOCK_TYPE]  ,");
				sb.Append(" 0                             AS [STOCK_QT]    ,");
				sb.Append(" CASE [PU].[PU_MODE_TYPE]                        ");
				sb.Append(   " WHEN '2' THEN ([P_L_D].[PU_QT] * -1)         ");
				sb.Append(   " ELSE [P_L_D].[PU_QT]                         ");
				sb.Append(" END AS [INIT_QT]                               ,");
				sb.Append(" CASE [PU].[PU_MODE_TYPE]                        ");
				sb.Append(   " WHEN '2' THEN ([P_L_D].[PU_QT] * -1)         ");
				sb.Append(   " ELSE [P_L_D].[PU_QT]                         ");
				sb.Append(" END AS [EDIT_QT]                               ,");
				sb.Append(" [P_L_D].[TRANSIT_RCPT_QT]     AS [TRANSIT_RCPT_QT],");
// 管理番号 K25322 From
//				sb.Append(" [R_L_D].[RCPT_NO]             AS [RCPT_NO]     ,");
//				sb.Append(" [R_L_D].[RCPT_LINE_ID]        AS [RCPT_LINE_ID],");
//				sb.Append(" [R_L_D].[RCPT_LOT_ID]         AS [RCPT_LOT_ID] ,");
				sb.Append(" [P_L_D].[RCPT_NO]             AS [RCPT_NO]     ,");
				sb.Append(" [P_L_D].[RCPT_LINE_ID]        AS [RCPT_LINE_ID],");
				sb.Append(" [P_L_D].[RCPT_LOT_ID]         AS [RCPT_LOT_ID] ,");
// 管理番号 K25322 To
				sb.Append(" NULL                          AS [SA_NO]       ,");
				sb.Append(" NULL                          AS [SA_LINE_ID]  ,");
				sb.Append(" NULL                          AS [SA_LOT_ID]    ");
// 管理番号 K25322 From
				sb.Append(",CASE WHEN [PU].[PU_MODE_TYPE] = N'2'            ");
				sb.Append("    THEN [P_L_D].[STOCK_UNIT_PO_ALLOC_PU_QT] * -1");
				sb.Append("    ELSE [P_L_D].[STOCK_UNIT_PO_ALLOC_PU_QT]     ");
				sb.Append(" END                           AS [PO_ALLOC_RCPT_QT]"); //在庫単位発注引当仕入数量
// 管理番号 K25322 To

				//仕入
				sb.Append(" FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
				//仕入明細
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PD]");
				sb.Append(" ON  [PU].[PU_NO] = [PD].[PU_NO] ");
				//仕入ロット明細
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_LOT_DTIL]")).Append(" AS [P_L_D]");
				sb.Append(" ON  [PD].[PU_NO]      = [P_L_D].[PU_NO] ");
				sb.Append(" AND [PD].[PU_LINE_ID] = [P_L_D].[PU_LINE_ID] ");
				sb.Append(" AND (([P_L_D].[RCPT_NO] IS NOT NULL) OR ([P_L_D].[RCPT_NO] IS NULL AND [P_L_D].[LOT_NO] <> '9'))");
// 管理番号 K25322 From
//				//入荷
//				sb.Append(" LEFT OUTER JOIN ");
//				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");
//				sb.Append(" ON  [PU].[PU_NO] = [RCPT].[PU_NO] ");
//				//入荷明細
//				sb.Append(" INNER JOIN ");
//				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD]");
//				sb.Append(" ON  [PD].[RCPT_NO] = [RD].[RCPT_NO] ");
//				sb.Append(" AND  [PD].[RCPT_LINE_ID] = [RD].[RCPT_LINE_ID] ");
//				//入荷ロット明細
//				sb.Append(" INNER JOIN ");
//				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_LOT_DTIL]")).Append(" AS [R_L_D]");
//				sb.Append(" ON  [P_L_D].[RCPT_NO]      = [R_L_D].[RCPT_NO] ");
//				sb.Append(" AND [P_L_D].[RCPT_LINE_ID] = [R_L_D].[RCPT_LINE_ID] ");
//				sb.Append(" AND [P_L_D].[RCPT_LOT_ID] = [R_L_D].[RCPT_LOT_ID] ");
// 管理番号 K25322 To
				//商品
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [P]");
				sb.Append(" ON  [PD].[PROD_CODE] = [P].[PROD_CODE] ");
				//ロット
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[LOT]")).Append(" AS [LOT]");
				sb.Append(" ON  [PD].[PROD_CODE]        = [LOT].[PROD_CODE] ");
				sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [LOT].[PROD_SPEC_1_CODE] ");
				sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [LOT].[PROD_SPEC_2_CODE] ");
// 管理番号 K25322 From
//				sb.Append(" AND [R_L_D].[LOT_NO]        = [LOT].[LOT_NO] ");
				sb.Append(" AND [P_L_D].[LOT_NO]        = [LOT].[LOT_NO] ");
// 管理番号 K25322 To
				//単位別商品属性
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
				sb.Append(" ON  [PD].[PROD_CODE] = [U].[PROD_CODE] ");
				sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE]");

				wpb.AddFilter("[PU].[PU_NO]"    , SearchOperator.Equal, keyColumn.SlipNo);
				wpb.AddFilter("[P_L_D].[PU_QT]", SearchOperator.NotEqual, 0);
				sb.Append(wpb);
// 管理番号 K25322 From
//				sb.Append("ORDER BY [LOT].[FAB_DATE] ASC, [P_L_D].[PU_LOT_ID] ASC, [RCPT].[RCPT_DATE] ASC, [P_L_D].[RCPT_NO] ASC");
				sb.Append("ORDER BY [LOT].[FAB_DATE] ASC, [P_L_D].[PU_LOT_ID] ASC ");
// 管理番号 K25322 To
			}
			return sb.ToString();
		}
		//仕入（コピー）
		private static SqlCommandWrapper CreatePuCopyHeaderCommand(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append("SELECT");
			sb.Append(" [PU].[PU_NO]                        AS [PU_NO]"                         );
			sb.Append(",[PU].[PU_NAME]                      AS [PU_NAME]"                       );
			sb.Append(",GETDATE()                           AS [PU_DATE]"                       );
// 管理番号 K16590 From
			sb.Append(",GETDATE()                           AS [DEAL_DATE]"                     );
// 管理番号 K16590 To
			sb.Append(",NULL                                AS [PO_NO]"                         );
			sb.Append(",NULL                                AS [RCPT_NO]"                       );
			sb.Append(",[PU].[PU_MODE_TYPE]                 AS [PU_MODE_TYPE]"                  );
// 管理番号K27058 From
			sb.Append(",[PU].[PU_MODE_TYPE_DTIL_CODE]		AS [PU_MODE_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			sb.Append(",NULL                                AS [REF_PU_NO]"                     );
			sb.Append(",[PU].[CUR_CODE]                     AS [CUR_CODE]"                      );
			sb.Append(",[PU].[EXCHANGE_TYPE]                AS [EXCHANGE_TYPE]"                 );
			sb.Append(",[PU].[EXCHANGE_REZ_NO]              AS [EXCHANGE_REZ_NO]"               );
			sb.Append(",[PU].[RATE]                         AS [RATE]"                          );
			sb.Append(",[PU].[DEPT_CODE]                    AS [DEPT_CODE]"                     );
			sb.Append(",[O].[DEPT_SHORT_NAME]               AS [DEPT_SHORT_NAME]"               );
			sb.Append(",[PU].[ORIGIN_DEPT_CODE]             AS [ORIGIN_DEPT_CODE]"              );
			sb.Append(",NULL                                AS [OLD_DEPT_CODE]"                 );
			sb.Append(",NULL                                AS [ORG_CHANGE_ID]"                 );
			sb.Append(",NULL                                AS [DATA_MIGRATE_DATETIME]"         );
			sb.Append(",[PU].[EMP_CODE]                     AS [EMP_CODE]"                      );
			sb.Append(",[PU].[PROJ_CODE]                    AS [PROJ_CODE]"                     );
			sb.Append(",[PU].[PROJ_SBNO]                    AS [PROJ_SBNO]"                     );
			sb.Append(",[PU].[SUPL_CODE]                    AS [SUPL_CODE]"                     );
			sb.Append(",[PU].[SUPL_SBNO]                    AS [SUPL_SBNO]"                     );
			sb.Append(",[PU].[TEMP_CODE_FLG]                AS [TEMP_CODE_FLG]"                 );
			sb.Append(",[PU].[SUPL_NAME]                    AS [SUPL_NAME]"                     );
			sb.Append(",[PU].[SUPL_SHORT_NAME]              AS [SUPL_SHORT_NAME]"               );
			sb.Append(",[PU].[SUPL_DEPT_NAME_1]             AS [SUPL_DEPT_NAME_1]"              );
			sb.Append(",[PU].[SUPL_DEPT_NAME_2]             AS [SUPL_DEPT_NAME_2]"              );
			sb.Append(",[PU].[SUPL_COUNTRY_CODE]            AS [SUPL_COUNTRY_CODE]"             );
			sb.Append(",[PU].[SUPL_ZIP]                     AS [SUPL_ZIP]"                      );
			sb.Append(",[PU].[SUPL_STATE]                   AS [SUPL_STATE]"                    );
			sb.Append(",[PU].[SUPL_CITY]                    AS [SUPL_CITY]"                     );
			sb.Append(",[PU].[SUPL_ADDRESS1]                AS [SUPL_ADDRESS1]"                 );
			sb.Append(",[PU].[SUPL_ADDRESS2]                AS [SUPL_ADDRESS2]"                 );
			sb.Append(",[PU].[SUPL_PHONE]                   AS [SUPL_PHONE]"                    );
			sb.Append(",[PU].[SUPL_FAX]                     AS [SUPL_FAX]"                      );
			sb.Append(",[PU].[SUPL_USER_NAME]               AS [SUPL_USER_NAME]"                );
			sb.Append(",[PU].[AC_NO]                        AS [AC_NO]"                         );
			sb.Append(",[PU].[AC_HOLDER]                    AS [AC_HOLDER]"                     );
			sb.Append(",[PU].[AC_TYPE]                      AS [AC_TYPE]"                       );
			sb.Append(",[PU].[BANK_AC_TYPE]                 AS [BANK_AC_TYPE]"                  );
			sb.Append(",[PU].[BANK_COUNTRY_CODE]            AS [BANK_COUNTRY_CODE]"             );
			sb.Append(",[PU].[BANK_CODE]                    AS [BANK_CODE]"                     );
			sb.Append(",[PU].[BANK_BRANCH_CODE]             AS [BANK_BRANCH_CODE]"              );
			sb.Append(",[PU].[DELI_TYPE]                    AS [DELI_TYPE]"                     );
			sb.Append(",[PU].[WH_CODE]                      AS [WH_CODE]"                       );
			sb.Append(",[PU].[DELI_CUST_CODE]               AS [DELI_CUST_CODE]"                );
			sb.Append(",[PU].[DELI_CUST_SBNO]               AS [DELI_CUST_SBNO]"                );
			sb.Append(",[PU].[DELI_PLACE_CODE]              AS [DELI_PLACE_CODE]"               );
			sb.Append(",[PU].[DELI_PLACE_NAME]              AS [DELI_PLACE_NAME]"               );
			sb.Append(",[PU].[DELI_PLACE_COUNTRY_CODE]      AS [DELI_PLACE_COUNTRY_CODE]"       );
			sb.Append(",[PU].[DELI_PLACE_ZIP]               AS [DELI_PLACE_ZIP]"                );
			sb.Append(",[PU].[DELI_PLACE_STATE]             AS [DELI_PLACE_STATE]"              );
			sb.Append(",[PU].[DELI_PLACE_CITY]              AS [DELI_PLACE_CITY]"               );
			sb.Append(",[PU].[DELI_PLACE_ADDRESS1]          AS [DELI_PLACE_ADDRESS1]"           );
			sb.Append(",[PU].[DELI_PLACE_ADDRESS2]          AS [DELI_PLACE_ADDRESS2]"           );
			sb.Append(",[PU].[DELI_PLACE_PHONE]             AS [DELI_PLACE_PHONE]"              );
			sb.Append(",[PU].[DELI_PLACE_FAX]               AS [DELI_PLACE_FAX]"                );
			sb.Append(",[PU].[DELI_PLACE_USER_NAME]         AS [DELI_PLACE_USER_NAME]"          );
			sb.Append(",[PU].[DT_TYPE]                      AS [DT_TYPE]"                       );
			sb.Append(",[PU].[DT1_STTL_MTHD_CODE]           AS [DT1_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT1_BASIS_AMT]                AS [DT1_BASIS_AMT]"                 );
			sb.Append(",[PU].[DT2_STTL_MTHD_CODE]           AS [DT2_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT2_RATIO]                    AS [DT2_RATIO]"                     );
			sb.Append(",[PU].[DT3_STTL_MTHD_CODE]           AS [DT3_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT_SIGHT]                     AS [DT_SIGHT]"                      );
			sb.Append(",[PU].[CUTOFF_DATE]                  AS [CUTOFF_DATE]"                   );
// 管理番号 B21977 From
			sb.Append(",[PU].[CUTOFF_DATE]                  AS [CUTOFF_FIN_DATE]"                   );
// 管理番号 B21977 To
			sb.Append(",[PU].[PYMT_PLAN_DATE]               AS [PYMT_PLAN_DATE]"                );
			sb.Append(",[PU].[DT_NOTE]                      AS [DT_NOTE]"                       );
			sb.Append(",NULL                                AS [DT_CUTOFF_CYCLE_TYPE]"          );
			sb.Append(",NULL                                AS [DT_CUTOFF_DAY]"                 );
			sb.Append(",NULL                                AS [DT_TERM_MONTH_CNT]"             );
			sb.Append(",NULL                                AS [DT_TERM_DAY]"                   );
// 管理番号 B22191 From
			sb.Append(",NULL                                AS [PO_DATE]"                       );
// 管理番号 B22191 To
// 管理番号K27441 From
			sb.Append(",NULL								AS [PO_DEPT_CODE]"					);
// 管理番号K27441 To
			sb.Append(",NULL                                AS [SUPL_BILL_SLIP_NO]"             );
			sb.Append(",[PU].[CANCELED_ORDER_FLG]           AS [CANCELED_ORDER_FLG]"            );
			sb.Append(",[PU].[OVERSEAS_FLG]                 AS [OVERSEAS_FLG]"                  );
			sb.Append(",[PU].[TENOR_CODE]                   AS [TENOR_CODE]"                    );
			sb.Append(",[PU].[FMONEY_STTL_PERIOD_STT_MONTH] AS [FMONEY_STTL_PERIOD_STT_MONTH]"  );
			sb.Append(",[PU].[FMONEY_STTL_PERIOD_END_MONTH] AS [FMONEY_STTL_PERIOD_END_MONTH]"  );
			sb.Append(",[PU].[LC_NO]                        AS [LC_NO]"                         );
// 管理番号 B13878 From
			sb.Append(",[PU].[HOLD_FLG]						AS [HOLD_FLG]"						);
// 管理番号 B13878 To
			sb.Append(",[PU].[REMARKS_CODE]                 AS [REMARKS_CODE]"                  );
			sb.Append(",[PU].[REMARKS]                      AS [REMARKS]"                       );
// 管理番号 B13798 From
			sb.Append(",[PU].[ADMIN_ITEM1]                  AS [ADMIN_ITEM1]"                   );
			sb.Append(",[PU].[ADMIN_ITEM2]                  AS [ADMIN_ITEM2]"                   );
			sb.Append(",[PU].[ADMIN_ITEM3]                  AS [ADMIN_ITEM3]"                   );
// 管理番号 B13798 To
// 管理番号 K20687 From
			sb.Append(",[PU].[BOOK_BASIS_TYPE]				AS [BOOK_BASIS_TYPE]"				);
// 管理番号 K20687 To
// 管理番号K27058 From
			sb.Append(",[PU].[BOOK_BASIS_TYPE_DTIL_CODE]	AS [BOOK_BASIS_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			sb.Append(",[PU].[OUTLAND_REMITTANCE_FLG]       AS [OUTLAND_REMITTANCE_FLG]"        );
			sb.Append(",[PU].[INTERNATIONAL_ITEM_NO]        AS [INTERNATIONAL_ITEM_NO]"         );
			sb.Append(",[PU].[REMITTANCE_PURPOSE]           AS [REMITTANCE_PURPOSE]"            );
			sb.Append(",[PU].[REMITTANCE_ALLOW_FLG]         AS [REMITTANCE_ALLOW_FLG]"          );
			sb.Append(",[PU].[REMITTANCE_ALLOW_NO]          AS [REMITTANCE_ALLOW_NO]"           );
			sb.Append(",[PU].[REMITTANCE_MESSAGE]           AS [REMITTANCE_MESSAGE]"            );
// 管理番号 B13500 From
			sb.Append(",[PU].[RCPT_INPUT_NO_NEED_FLG]		AS [RCPT_INPUT_NO_NEED_FLG]"		);
// 管理番号 B13500 To
			sb.Append(",[PU].[APPROVAL_STATUS_TYPE]         AS [APPROVAL_STATUS_TYPE]"          );
// 管理番号 K20685 From
			sb.Append(",'0'                                 AS [APPROVAL_CANCEL_FLG]"           );
// 管理番号 K20685 To
			sb.Append(",'0'                                 AS [PU_SLIP_OUTPUT_FLG]"            );
			sb.Append(",[PU].[ETAX_DTIL_AMT_TTL]            AS [ETAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[ITAX_DTIL_AMT_TTL]            AS [ITAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[NTAX_DTIL_AMT_TTL]            AS [NTAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[ETAX_AMT_TTL]                 AS [ETAX_AMT_TTL]"                  );
			sb.Append(",[PU].[ITAX_AMT_TTL]                 AS [ITAX_AMT_TTL]"                  );
			sb.Append(",[PU].[GRAND_TTL]                    AS [GRAND_TTL]"                     );
			sb.Append(",[PU].[KEY_GRAND_TTL]                AS [KEY_GRAND_TTL]"                 );
			sb.Append(",0                                   AS [KO_AMT]"                        );
			sb.Append(",NULL                                AS [LAST_KO_DATE]"                  );
			sb.Append(",'0'                                 AS [KO_COMPLETE_FLG]"               );
// 管理番号 K16187 From
			sb.Append(",0                                   AS [APPROVED_KO_AMT]"               );
			sb.Append(",'0'                                 AS [DTIL_KO_FLG]"                   );
			sb.Append(",'0'                                 AS [DELETE_ALLOW_FLG]");
// 管理番号 K16187 To
			sb.Append(",0                                   AS [EXCHANGE_GAIN_LOSS_AMT_TTL]"    );
			sb.Append(",NULL                                AS [LAST_EXCHANGE_VALUATION_DATE]"  );
			sb.Append(",'0'                                 AS [EXCHANGE_VALUATION_FIN_FLG]"    );
			sb.Append(",NULL                                AS [PYMT_NO]"                       );
			sb.Append(",'0'                                 AS [CUTOFF_FIN_FLG]"                );
			sb.Append(",'0'                                 AS [CANCEL_FLG]"                    );
			sb.Append(",'0'                                 AS [RED_SLIP_FLG]"                  );
			sb.Append(",NULL                                AS [ORIGIN_PU_NO]"                  );
			sb.Append(",NULL                                AS [OPPOSITE_PU_NO]"                );
			sb.Append(",NULL                                AS [LAST_JRNL_EXEC_DATETIME]"       );
			sb.Append(",'0'                                 AS [JRNL_FIN_FLG]"                  );
// 管理番号 B20818 From
//			sb.Append(",NULL                                AS [PRG_UPDATE_DATETIME]"           );
			sb.Append(",GETDATE()                           AS [PRG_UPDATE_DATETIME]"           );
			sb.Append(",GETDATE()                           AS [REF_PRG_UPDATE_DATETIME]"       );
// 管理番号 B20818 To
// 管理番号 K22205 From
            sb.Append(",NULL                                AS [INPUT_EMP_CODE]"                );
// 管理番号 K22205 To
			sb.Append(",NULL                                AS [SO_NO]"                         );
			sb.Append(",NULL                                AS [SO_DATE]"                       );
			sb.Append(",NULL                                AS [CUST_SHORT_NAME]"               );
// 管理番号 B13569 From
			sb.Append(",'0'                                 AS [REF_PO_EXCHANGE_TYPE]"          );
// 管理番号 B13569 To
// 管理番号 K24278 From
// 管理番号 K24789 From
//			sb.Append(",[COMP].[CTAX_FRACTION_ROUND_TYPE]	AS [CTAX_FRACTION_ROUND_TYPE]"		);
// 管理番号 K24789 To
			sb.Append(",[SUPL].[CTAX_IMPOSE_FLG]			AS [CTAX_IMPOSE_FLG]"				);
// 管理番号 K24278 To
// 管理番号 K24789 From
			sb.Append(",[PYMT_SUPL].[CTAX_BUILDUP_TYPE]         AS [CTAX_BUILDUP_TYPE]"         );
			sb.Append(",[PYMT_SUPL].[CTAX_FRACTION_ROUND_TYPE]  AS [CTAX_FRACTION_ROUND_TYPE]"  );
// 管理番号 K24789 To
// 管理番号 K25679 From
			sb.Append(",[PU].[PO_ADMIN_NO]                  AS [PO_ADMIN_NO]");
			sb.Append(",NULL                                AS [SUPL_SLIP_NO]"                  );
// 管理番号 K25679 To
// 管理番号 K25680 From
			sb.Append(",NULL                                AS [IMPORT_SLIP_NO]"                );
// 管理番号 K25680 To
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputHead, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PU", null, null, null);
// 管理番号K27057 To
// 管理番号K27154 From
			sb.Append(",[PU].[DEAL_TYPE_CODE]				AS [DEAL_TYPE_CODE]");
// 管理番号K27154 To
			//仕入
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			//組織図、組織変更
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHART]")).Append(" AS [O]");
			sb.Append(" ON	[PU].[DEPT_CODE] = [O].[DEPT_CODE]");
			sb.Append(" AND	[O].[ORG_CHANGE_ID] = ");
			sb.Append("(");
			sb.Append(" SELECT MAX([ORG_CHANGE].[ORG_CHANGE_ID]) FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHANGE]"));
			sb.Append(" [ORG_CHANGE] ");
// 管理番号 B12528 From
//			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= [PU].[PU_DATE] ");
			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= GETDATE()");
// 管理番号 B12528 To
			sb.Append(")");
// 管理番号 K24278 From
// 管理番号 K24789 From
//			//取引先
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[COMP]")).Append(" AS [COMP]");
//			sb.Append(" ON  [PU].[SUPL_CODE] = [COMP].[COMP_CODE] ");
// 管理番号 K24789 To
			//仕入先
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]")).Append(" AS [SUPL]");
			sb.Append(" ON  [PU].[SUPL_CODE] = [SUPL].[SUPL_CODE] ");
			sb.Append(" AND [PU].[SUPL_SBNO] = [SUPL].[SUPL_SBNO] ");
// 管理番号 K24278 To
// 管理番号 K24789 From
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]")).Append(" AS [PYMT_SUPL]");
			sb.Append(" ON  [SUPL].[PYMT_SUPL_CODE] = [PYMT_SUPL].[SUPL_CODE] ");
			sb.Append(" AND [SUPL].[PYMT_SUPL_SBNO] = [PYMT_SUPL].[SUPL_SBNO] ");
// 管理番号 K24789 To

			// 管理番号 B13500 From
			wpb = new WherePhraseBuilder();
			// 管理番号 B13500 To
			wpb.AddFilter("[PU].[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[PU].[OVERSEAS_FLG]", SearchOperator.Equal, keyColumn.OverseasFlg);			//海外フラグ
			sb.Append(wpb);

			//自部門のみの権限の場合
			if (keyColumn.DisclosureUnitType == "D")
			{
				sb.Append(" AND EXISTS (SELECT [DEPT_CODE] FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetLowerDeptLevel](@DeptCode, @Date)"));
				sb.Append(" [TEMP_DEPTLEVEL] WHERE [PU].[DEPT_CODE] = [TEMP_DEPTLEVEL].[DEPT_CODE])");
			}

			return new SqlCommandWrapper(sb.ToSqlPString(),cn);	// 管理番号K27230
		}
		//仕入明細（コピー）
		private static SqlPString CreatePuCopyDetailString(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			string prodSpec1Name = string.Empty;
			string prodSpec2Name = string.Empty;
			string unitShortName = string.Empty;

			switch (keyColumn.OverseasFlg)
			{
				case OverseasFlg.DOMESTIC:
					prodSpec1Name = "PROD_SPEC_1_NAME";
					prodSpec2Name = "PROD_SPEC_2_NAME";
					unitShortName = "UNIT_SHORT_NAME";
					break;
				case OverseasFlg.OVERSEAS:
					prodSpec1Name = "PROD_SPEC_1_ENG_NAME";
					prodSpec2Name = "PROD_SPEC_2_ENG_NAME";
					unitShortName = "UNIT_ENG_NAME";
					break;
			}

			//在庫管理部門の取得
			sb.Append("DECLARE @STOCK_ADMIN_DEPT_CODE NVARCHAR(10) ");
			sb.Append("SELECT ");
			sb.Append("  @STOCK_ADMIN_DEPT_CODE = ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SC_MS_GetStockDeptCode]"));
			sb.Append("(@MYCOMP_CODE, [DEPT_CODE], GETDATE())");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]"));
			wpb.AddFilter("[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo );
			sb.Append(wpb);

// 管理番号 B11723・B11796 From
			sb.Append(@"
DECLARE @CUR_DIGIT      DECIMAL(1,0)
DECLARE @CUR_ROUND_TYPE NVARCHAR(1)
DECLARE @AMT_ROUND_TYPE NVARCHAR(1)

SELECT
	 @CUR_ROUND_TYPE = [MC].[CUR_FRACTION_ROUND_TYPE]
	,@AMT_ROUND_TYPE = [MC].[AMT_TTL_FRACTION_ROUND_TYPE]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[MYCOMP]")).Append(@" AS [MC]
WHERE [MC].[MYCOMP_CODE] = @MYCOMP_CODE

SELECT @CUR_DIGIT = [C].[DECIMAL_DIGIT]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(@" AS [PU]
INNER JOIN ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CUR]")).Append(@" AS [C]
	ON [PU].[CUR_CODE] = [C].[CUR_CODE]
WHERE [PU].[PU_NO] = @SLIP_NO
");
// 管理番号 B11723・B11796 To

			wpb = new WherePhraseBuilder();

			sb.Append("SELECT ");
			sb.Append(" [PD].[PU_LINE_ID]                         AS [PU_LINE_ID]"                );
			sb.Append(",[PD].[PU_LINE_NO]                         AS [PU_LINE_NO]"                );
			sb.Append(",NULL                                      AS [PO_NO]"                     );
			sb.Append(",NULL                                      AS [PO_LINE_ID]"                );
			sb.Append(",NULL                                      AS [RCPT_NO]"                   );
			sb.Append(",NULL                                      AS [RCPT_LINE_ID]"              );
			sb.Append(",NULL                                      AS [SA_NO]"                     );
			sb.Append(",NULL                                      AS [SA_LINE_ID]"                );
			sb.Append(",[PD].[WH_CODE]                            AS [WH_CODE]"                   );
			sb.Append(",[W].[WH_SHORT_NAME]                       AS [WH_SHORT_NAME]"             );
			sb.Append(",[PD].[PROD_CODE]                          AS [PROD_CODE]"                 );
// 管理番号 B19475 From						
//			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_PO_NAME]"              );
			sb.Append(",[PD].[PROD_PO_NAME]						  AS [PROD_PO_NAME]"              );
// 管理番号 B19475 To			
			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_SHORT_NAME]"           );
			sb.Append(",[PD].[PROD_PO_NAME]                       AS [PROD_NAME]"                 );
			sb.Append(",[PD].[PROD_TYPE]                          AS [PROD_TYPE]"                 );
			sb.Append(",[PROD].[DISP_CONTROL_TYPE]                AS [DISP_CONTROL_TYPE]"         );
			sb.Append(",[PROD].[STOCK_ADMIN_FLG]                  AS [STOCK_ADMIN_FLG]"           );
			sb.Append(",[PROD].[LOT_ADMIN_FLG]                    AS [LOT_ADMIN_FLG]"             );
// 管理番号 K25322 From
			sb.Append(",[PROD].[LOT_STOCK_VALUATION_FLG]          AS [LOT_STOCK_VALUATION_FLG]"   );
// 管理番号 K25322 To
			sb.Append(",[U].[QT_DECIMAL_USE_FLG]                  AS [QT_DECIMAL_USE_FLG]"        );
			sb.Append(",[PD].[CTAX_CALC_TYPE]                     AS [CTAX_CALC_TYPE]"            );
// 管理番号 K24789 From
//			sb.Append(",[PROD].[CTAX_RATE_CODE]                   AS [CTAX_RATE_CODE]"            );
			sb.Append(",[PD].[CTAX_TYPE_CODE]                     AS [CTAX_TYPE_CODE]"            );
			sb.Append(",[PD].[CTAX_RATE_CODE]                     AS [CTAX_RATE_CODE]"            );
// 管理番号 K24789 To
			sb.Append(",[PD].[CTAX_RATE]                          AS [CTAX_RATE]"                 );
			sb.Append(",[PD].[PROD_SPEC_1_CODE]                   AS [PROD_SPEC_1_CODE]"          );
			sb.Append(",[PS1].[").Append(prodSpec1Name).Append("] AS [PROD_SPEC_1_NAME]"          );
			sb.Append(",[PD].[PROD_SPEC_2_CODE]                   AS [PROD_SPEC_2_CODE]"          );
			sb.Append(",[PS2].[").Append(prodSpec2Name).Append("] AS [PROD_SPEC_2_NAME]"          );
			sb.Append(",[PD].[PU_PLAN_PRICE]                      AS [PU_PLAN_PRICE]"             );
			sb.Append(",[PD].[STOCK_UNIT_STD_SELL_PRICE]          AS [STOCK_UNIT_STD_SELL_PRICE]" );
			sb.Append(",[PD].[UNIT_CODE]                          AS [UNIT_CODE]"                 );
			sb.Append(",[U].[").Append(unitShortName).Append("]   AS [UNIT_SHORT_NAME]"           );
			sb.Append(", CASE [PU].[PU_MODE_TYPE]"                                                );
			sb.Append(    " WHEN '2' THEN ([PD].[PU_QT] * -1)"                                    );
			sb.Append(    " ELSE [PD].[PU_QT]"                                                    );
			sb.Append( " END AS [PU_QT]"                                                          );
			sb.Append(", CASE [PU].[PU_MODE_TYPE]"                                                );
			sb.Append(    " WHEN '2' THEN ([PD].[PU_QT] * -1)"                                    );
			sb.Append(    " ELSE [PD].[PU_QT]"                                                    );
			sb.Append( " END AS [INIT_PU_QT]"                                                     );
			sb.Append(",0                                         AS [TRANSIT_RCPT_QT]"           );
			sb.Append(",[PD].[RCPT_INPUT_NO_NEED_FLG]             AS [RCPT_INPUT_NO_NEED_FLG]"    );

			//1. 仕入数量上限値の設定ここから
			sb.Append(", 0                                        AS [UPPER_LIMIT_PU_QT] "        );
			//1. 売上数量上限値の設定ここまで

			sb.Append(",ISNULL([ST].[VALID_QT],0)                 AS [VALID_QT]"                  );
			sb.Append(",[PD].[STOCK_UNIT_PU_QT]                   AS [STOCK_UNIT_PU_QT]"          );

			//2. 在庫単位受注仕入数量の設定ここから
			sb.Append(",0                                         AS [STOCK_UNIT_PO_PU_QT]"       );
			//2. 在庫単位受注売上数量の設定ここまで

			sb.Append(",0                                         AS [STOCK_UNIT_PO_ALLOC_PU_QT]" );
			sb.Append(",[PD].[PU_PRICE]                           AS [PU_PRICE]"                  );
			sb.Append(",[PD].[PU_PRICE]                           AS [INIT_PU_PRICE]"             );
			sb.Append(",[PD].[DISC_FLG]                           AS [DISC_FLG]"                  );
// 管理番号 B13878 From
			sb.Append(",[PD].[PRICE_UNDECIDED_FLG]				  AS [PRICE_UNDECIDED_FLG]"		  );
// 管理番号 B13878 To
			sb.Append(",[PD].[LINE_REMARKS_CODE]                  AS [LINE_REMARKS_CODE]"         );
			sb.Append(",[PD].[LINE_REMARKS]                       AS [LINE_REMARKS]"              );
// 管理番号K27525 From
			sb.Append(",[PD].[BOOK_DEDUCTION_REASON_CODE]         AS [BOOK_DEDUCTION_REASON_CODE]");
			sb.Append(",[BDR].[BOOK_DEDUCTION_REASON_NAME]        AS [BOOK_DEDUCTION_REASON_NAME]");
// 管理番号K27525 To
			sb.Append(",[U].[INCLUDE_QT]                          AS [INCLUDE_QT]"                );
			sb.Append(",[PD].[DTIL_AMT]                           AS [DTIL_AMT]"                  );
			sb.Append(",[PD].[ETAX_AMT]                           AS [ETAX_AMT]"                  );
			sb.Append(",[PD].[ITAX_AMT]                           AS [ITAX_AMT]"                  );
			sb.Append(",'0'                                       AS [PRICE_UPDATE_FLG]"          );
// 管理番号 K24278 From
//// 管理番号 B11723・B11796 From
////			sb.Append(", CASE [PU].[PU_MODE_TYPE]"                                                );
////			sb.Append(    " WHEN '2' THEN ([PD].[PU_QT] * -1) * [PD].[PU_PRICE]"                  );
////			sb.Append(    " ELSE [PD].[PU_QT] * [PD].[PU_PRICE]"                                  );
////			sb.Append( " END AS [PU_MONEY]"                                                       );
//			sb.Append(",").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound]")).Append(@"(
//	CASE WHEN [PU].[PU_MODE_TYPE] = '2'
//		THEN ([PD].[PU_QT]*(-1)) * [PD].[PU_PRICE]
//		ELSE  [PD].[PU_QT]       * [PD].[PU_PRICE]
//	END
//	, @CUR_DIGIT, @AMT_ROUND_TYPE
//) AS [PU_MONEY]");
//// 管理番号 B11723・B11796 To
			sb.Append(", CASE WHEN @ImposeFlg = '0' AND [PD].[CTAX_CALC_TYPE] = 'I' THEN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound([PD].[PU_PRICE]*[PD].[PU_QT],@CUR_DIGIT,@AMT_ROUND_TYPE) - "));
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound("));
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound([PD].[PU_PRICE]*[PD].[PU_QT],@CUR_DIGIT,@AMT_ROUND_TYPE) * "));
			sb.Append("([PD].[CTAX_RATE]/100)/(1+([PD].[CTAX_RATE]/100)),@CUR_DIGIT, @CtaxRoundType) ELSE ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound([PD].[PU_PRICE]*[PD].[PU_QT],@CUR_DIGIT,@AMT_ROUND_TYPE) END AS [PU_MONEY]"));
// 管理番号 K24278 To
			sb.Append(",[PROD].[PROD_NAME_CORRECT_ALLOW_FLG]      AS [PROD_NAME_CORRECTION_FLG]"  );

			//コピー時は商品変更可能、返品時は商品変更不可
			sb.Append(",'1'                                       AS [PROD_EDIT_FLG]"             );

			//入荷済判定
			sb.Append(",'0'           AS [IS_RCPT_EXECUTE]"  );
			sb.Append(",'C'           AS [ROW_STATE]"  );
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputDetail, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PD", "CUSTOM_ITEM_TAG", "@PU_DATE");
// 管理番号K27057 To

			//仕入
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			//仕入明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PD]");
			sb.Append(" ON [PU].[PU_NO] = [PD].[PU_NO]");
			//発注明細 入荷済み判定で使用
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO_DTIL]")).Append(" AS [POD]");
			sb.Append(" ON  [PD].[PO_NO]      = [POD].[PO_NO]");
			sb.Append(" AND [PD].[PO_LINE_ID] = [POD].[PO_LINE_ID]");

			//商品
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [PROD]");
			sb.Append(" ON  [PD].[PROD_CODE]   = [PROD].[PROD_CODE]");
			sb.Append(" AND [PROD].[PROD_TYPE] = '0' ");//通常商品のみ
			//商品規格1
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_1]")).Append(" AS [PS1]");
			sb.Append(" ON [PD].[PROD_SPEC_1_CODE] = [PS1].[PROD_SPEC_1_CODE]");
			//商品規格2
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_2]")).Append(" AS [PS2]");
			sb.Append(" ON [PD].[PROD_SPEC_2_CODE] = [PS2].[PROD_SPEC_2_CODE]");
			//倉庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[WH]")).Append(" AS [W]");
			sb.Append(" ON [PD].[WH_CODE] = [W].[WH_CODE]");
			//単位別商品属性
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
			sb.Append(" ON [PD].[PROD_CODE] = [U].[PROD_CODE]");
			sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE] ");
			//在庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[STOCK]")).Append(" AS [ST]");
			sb.Append(" ON  [PD].[WH_CODE]          = [ST].[WH_CODE] ");
			sb.Append(" AND [PD].[PROD_CODE]        = [ST].[PROD_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [ST].[PROD_SPEC_1_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [ST].[PROD_SPEC_2_CODE] ");
			sb.Append(" AND [ST].[DEPT_CODE]        = @STOCK_ADMIN_DEPT_CODE ");
// 管理番号 B13877 From
			if (keyColumn.ProjectStockAdminUseFlg)
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ISNULL([PU].[PROJ_CODE],'')");
				sb.Append(" AND [ST].[PROJ_SBNO] = ISNULL([PU].[PROJ_SBNO],'')");
			}
			else
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ''");
				sb.Append(" AND [ST].[PROJ_SBNO] = ''");
			}
// 管理番号 B13877 To
// 管理番号K27525 From
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[BOOK_DEDUCTION_REASON]")).Append(" AS [BDR]");
			sb.Append(" ON [BDR].[BOOK_DEDUCTION_REASON_CODE] = [PD].[BOOK_DEDUCTION_REASON_CODE] ");
// 管理番号K27525 To

			wpb.AddFilter("[PD].[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[PD].[PU_QT]", SearchOperator.NotEqual, 0);
			sb.Append(wpb);
			sb.Append("ORDER BY [PD].[PU_LINE_NO] ASC ");

			return sb.ToSqlPString();	// 管理番号K27230
		}
		//仕入ロット明細（コピー）
		private static string CreatePuCopyLotDetailString(CommonData commonData,IF_SC_MM_05_KeyColumn keyColumn)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			//仕入コピー、仕入参照(他伝票なし)、修正モード
			sb.Append("SELECT ");
			sb.Append(" [P_L_D].[PU_LINE_ID]          AS [ROW_ID]      ,");
			sb.Append(" [P_L_D].[LOT_NO]              AS [LOT_NO]      ,");
			sb.Append(" [LOT].[FAB_DATE]              AS [FAB_DATE]    ,");
// 管理番号 B22625 From
//			sb.Append(" DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE]) AS [TERM_DATE] ,");
			sb.Append(" CASE WHEN CONVERT(DATETIME,'9998/12/31') - [LOT].[FAB_DATE] < [P].[LOT_VALID_TERM_DAY_CNT]-1");
			sb.Append(   " THEN CONVERT(DATETIME,'9998/12/31')");
			sb.Append(   " ELSE DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE])");
			sb.Append(" END AS [TERM_DATE] ,");
// 管理番号 B22625 To
			sb.Append(" [P_L_D].[PU_LOT_ID]           AS [LOT_ID]      ,");
			sb.Append(" CASE [PU].[PU_MODE_TYPE] WHEN '4' THEN '2'  ELSE '1'  END AS [STOCK_TYPE],  ");
			sb.Append(" 0                             AS [STOCK_QT]    ,");
			sb.Append(" CASE [PU].[PU_MODE_TYPE]                        ");
			sb.Append(   " WHEN '2' THEN ([P_L_D].[PU_QT] * -1)         ");
			sb.Append(   " ELSE [P_L_D].[PU_QT]                         ");
			sb.Append(" END AS [INIT_QT]                               ,");
			sb.Append(" CASE [PU].[PU_MODE_TYPE]                        ");
			sb.Append(   " WHEN '2' THEN ([P_L_D].[PU_QT] * -1)         ");
			sb.Append(   " ELSE [P_L_D].[PU_QT]                         ");
			sb.Append(" END AS [EDIT_QT]                               ,");
			sb.Append(" 0                             AS [TRANSIT_RCPT_QT],");

			sb.Append(" NULL                          AS [RCPT_NO]     ,");
			sb.Append(" NULL                          AS [RCPT_LINE_ID],");
			sb.Append(" NULL                          AS [RCPT_LOT_ID] ,");
			sb.Append(" NULL                          AS [SA_NO]       ,");
			sb.Append(" NULL                          AS [SA_LINE_ID]  ,");
			sb.Append(" NULL                          AS [SA_LOT_ID]    ");
// 管理番号 K25322 From
			sb.Append(",0                             AS [PO_ALLOC_RCPT_QT] "); //在庫単位発注引当仕入数量
// 管理番号 K25322 To

			//仕入
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			//仕入明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PD]");
			sb.Append(" ON  [PU].[PU_NO] = [PD].[PU_NO] ");
			//仕入ロット明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_LOT_DTIL]")).Append(" AS [P_L_D]");
			sb.Append(" ON  [PD].[PU_NO]      = [P_L_D].[PU_NO] ");
			sb.Append(" AND [PD].[PU_LINE_ID] = [P_L_D].[PU_LINE_ID] ");
			sb.Append(" AND [P_L_D].[LOT_NO] <> '9'");
			//商品
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [P]");
			sb.Append(" ON  [PD].[PROD_CODE] = [P].[PROD_CODE] ");
			//ロット
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[LOT]")).Append(" AS [LOT]");
			sb.Append(" ON  [PD].[PROD_CODE]        = [LOT].[PROD_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [LOT].[PROD_SPEC_1_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [LOT].[PROD_SPEC_2_CODE] ");
			sb.Append(" AND [P_L_D].[LOT_NO]        = [LOT].[LOT_NO] ");

			//単位別商品属性
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
			sb.Append(" ON  [PD].[PROD_CODE] = [U].[PROD_CODE] ");
			sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE]");

			wpb.AddFilter("[PU].[PU_NO]"   , SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[P_L_D].[PU_QT]", SearchOperator.NotEqual, 0);
			sb.Append(wpb);
			sb.Append("ORDER BY [LOT].[FAB_DATE] ASC, [P_L_D].[PU_LOT_ID] ASC ");

			return sb.ToString();
		}
		//仕入（返品・他返品伝票あり）
		private static SqlCommandWrapper CreatePuRefOtherExistHeaderCommand(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append("SELECT");
			sb.Append(" NULL                                AS [PU_NO]"                         );
			sb.Append(",[PU].[PU_NAME]                      AS [PU_NAME]"                       );
			sb.Append(",CASE WHEN @PARAM_TYPE <> 'Mod' AND @PARAM_TYPE <> 'View'"               );
			sb.Append("		THEN GETDATE() "                                                    );
			sb.Append("		ELSE [PU].[PU_DATE] "                                               );
			sb.Append(" END                                 AS [PU_DATE]"                       );
// 管理番号 K24789 From
//// 管理番号 K16590 From
//			sb.Append(",CASE WHEN @PARAM_TYPE <> 'Mod' AND @PARAM_TYPE <> 'View'"               );
//			sb.Append("		THEN GETDATE() "                                                    );
//			sb.Append("		ELSE [PU].[DEAL_DATE] "                                             );
//			sb.Append(" END                                 AS [DEAL_DATE]"                     );
//// 管理番号 K16590 To
// 管理番号B27131 From
//			sb.Append(",[PU].[DEAL_DATE]                    AS [DEAL_DATE]"                      );
			if (keyColumn.DateAdminType == "1")     // 日付管理区分が「取引日管理基準」
			{
				sb.Append(",[PU].[DEAL_DATE]                AS [DEAL_DATE]"                     );
			}
			else
			{
				sb.Append(",GETDATE()                       AS [DEAL_DATE]"                     );
			}
// 管理番号B27131 To
// 管理番号 K24789 To
			sb.Append(",NULL                                AS [PO_NO]"                         );
			sb.Append(",NULL                                AS [RCPT_NO]"                       );
			sb.Append(",'2'                                 AS [PU_MODE_TYPE]"                  );
// 管理番号K27058 From
			sb.Append(",@PU_MODE_TYPE_DTIL_CODE				AS [PU_MODE_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			sb.Append(",@REF_PU_NO                          AS [REF_PU_NO]"                     );
// 管理番号 B21177 From
			sb.Append(",CASE WHEN @PARAM_TYPE <> 'Mod' AND @PARAM_TYPE <> 'View'"               );
			sb.Append("		THEN [PU].[PU_DATE] "                                               );
			sb.Append("		ELSE GETDATE() "                                                    );
			sb.Append(" END                                 AS [REF_PU_DATE]"                   );
// 管理番号 B21177 To
			sb.Append(",[PU].[CUR_CODE]                     AS [CUR_CODE]"                      );
			sb.Append(",[PU].[EXCHANGE_TYPE]                AS [EXCHANGE_TYPE]"                 );
			sb.Append(",[PU].[EXCHANGE_REZ_NO]              AS [EXCHANGE_REZ_NO]"               );
			sb.Append(",[PU].[RATE]                         AS [RATE]"                          );
			sb.Append(",[PU].[DEPT_CODE]                    AS [DEPT_CODE]"                     );
			sb.Append(",[O].[DEPT_SHORT_NAME]               AS [DEPT_SHORT_NAME]"               );
			sb.Append(",[PU].[ORIGIN_DEPT_CODE]             AS [ORIGIN_DEPT_CODE]"              );
			sb.Append(",[PU].[OLD_DEPT_CODE]                AS [OLD_DEPT_CODE]"                 );
			sb.Append(",[PU].[ORG_CHANGE_ID]                AS [ORG_CHANGE_ID]"                 );
			sb.Append(",[PU].[DATA_MIGRATE_DATETIME]        AS [DATA_MIGRATE_DATETIME]"         );
			sb.Append(",[PU].[EMP_CODE]                     AS [EMP_CODE]"                      );
			sb.Append(",[PU].[PROJ_CODE]                    AS [PROJ_CODE]"                     );
			sb.Append(",[PU].[PROJ_SBNO]                    AS [PROJ_SBNO]"                     );
			sb.Append(",[PU].[SUPL_CODE]                    AS [SUPL_CODE]"                     );
			sb.Append(",[PU].[SUPL_SBNO]                    AS [SUPL_SBNO]"                     );
			sb.Append(",[PU].[TEMP_CODE_FLG]                AS [TEMP_CODE_FLG]"                 );
			sb.Append(",[PU].[SUPL_NAME]                    AS [SUPL_NAME]"                     );
			sb.Append(",[PU].[SUPL_SHORT_NAME]              AS [SUPL_SHORT_NAME]"               );
			sb.Append(",[PU].[SUPL_DEPT_NAME_1]             AS [SUPL_DEPT_NAME_1]"              );
			sb.Append(",[PU].[SUPL_DEPT_NAME_2]             AS [SUPL_DEPT_NAME_2]"              );
			sb.Append(",[PU].[SUPL_COUNTRY_CODE]            AS [SUPL_COUNTRY_CODE]"             );
			sb.Append(",[PU].[SUPL_ZIP]                     AS [SUPL_ZIP]"                      );
			sb.Append(",[PU].[SUPL_STATE]                   AS [SUPL_STATE]"                    );
			sb.Append(",[PU].[SUPL_CITY]                    AS [SUPL_CITY]"                     );
			sb.Append(",[PU].[SUPL_ADDRESS1]                AS [SUPL_ADDRESS1]"                 );
			sb.Append(",[PU].[SUPL_ADDRESS2]                AS [SUPL_ADDRESS2]"                 );
			sb.Append(",[PU].[SUPL_PHONE]                   AS [SUPL_PHONE]"                    );
			sb.Append(",[PU].[SUPL_FAX]                     AS [SUPL_FAX]"                      );
			sb.Append(",[PU].[SUPL_USER_NAME]               AS [SUPL_USER_NAME]"                );
			sb.Append(",[PU].[AC_NO]                        AS [AC_NO]"                         );
			sb.Append(",[PU].[AC_HOLDER]                    AS [AC_HOLDER]"                     );
			sb.Append(",[PU].[AC_TYPE]                      AS [AC_TYPE]"                       );
			sb.Append(",[PU].[BANK_AC_TYPE]                 AS [BANK_AC_TYPE]"                  );
			sb.Append(",[PU].[BANK_COUNTRY_CODE]            AS [BANK_COUNTRY_CODE]"             );
			sb.Append(",[PU].[BANK_CODE]                    AS [BANK_CODE]"                     );
			sb.Append(",[PU].[BANK_BRANCH_CODE]             AS [BANK_BRANCH_CODE]"              );
			sb.Append(",[PU].[DELI_TYPE]                    AS [DELI_TYPE]"                     );
			sb.Append(",[PU].[WH_CODE]                      AS [WH_CODE]"                       );
			sb.Append(",[PU].[DELI_CUST_CODE]               AS [DELI_CUST_CODE]"                );
			sb.Append(",[PU].[DELI_CUST_SBNO]               AS [DELI_CUST_SBNO]"                );
			sb.Append(",[PU].[DELI_PLACE_CODE]              AS [DELI_PLACE_CODE]"               );
			sb.Append(",[PU].[DELI_PLACE_NAME]              AS [DELI_PLACE_NAME]"               );
			sb.Append(",[PU].[DELI_PLACE_COUNTRY_CODE]      AS [DELI_PLACE_COUNTRY_CODE]"       );
			sb.Append(",[PU].[DELI_PLACE_ZIP]               AS [DELI_PLACE_ZIP]"                );
			sb.Append(",[PU].[DELI_PLACE_STATE]             AS [DELI_PLACE_STATE]"              );
			sb.Append(",[PU].[DELI_PLACE_CITY]              AS [DELI_PLACE_CITY]"               );
			sb.Append(",[PU].[DELI_PLACE_ADDRESS1]          AS [DELI_PLACE_ADDRESS1]"           );
			sb.Append(",[PU].[DELI_PLACE_ADDRESS2]          AS [DELI_PLACE_ADDRESS2]"           );
			sb.Append(",[PU].[DELI_PLACE_PHONE]             AS [DELI_PLACE_PHONE]"              );
			sb.Append(",[PU].[DELI_PLACE_FAX]               AS [DELI_PLACE_FAX]"                );
			sb.Append(",[PU].[DELI_PLACE_USER_NAME]         AS [DELI_PLACE_USER_NAME]"          );
			sb.Append(",[PU].[DT_TYPE]                      AS [DT_TYPE]"                       );
			sb.Append(",[PU].[DT1_STTL_MTHD_CODE]           AS [DT1_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT1_BASIS_AMT]                AS [DT1_BASIS_AMT]"                 );
			sb.Append(",[PU].[DT2_STTL_MTHD_CODE]           AS [DT2_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT2_RATIO]                    AS [DT2_RATIO]"                     );
			sb.Append(",[PU].[DT3_STTL_MTHD_CODE]           AS [DT3_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT_SIGHT]                     AS [DT_SIGHT]"                      );
			sb.Append(",[PU].[CUTOFF_DATE]                  AS [CUTOFF_DATE]"                   );
// 管理番号 B21977 From
			sb.Append(",[PU].[CUTOFF_DATE]                  AS [CUTOFF_FIN_DATE]"               );
// 管理番号 B21977 To
			sb.Append(",[PU].[PYMT_PLAN_DATE]               AS [PYMT_PLAN_DATE]"                );
			sb.Append(",[PU].[DT_NOTE]                      AS [DT_NOTE]"                       );
			sb.Append(",[POX].[DT_CUTOFF_CYCLE_TYPE]        AS [DT_CUTOFF_CYCLE_TYPE]"          );
			sb.Append(",[POX].[DT_CUTOFF_DAY]               AS [DT_CUTOFF_DAY]"                 );
			sb.Append(",[POX].[DT_TERM_MONTH_CNT]           AS [DT_TERM_MONTH_CNT]"             );
			sb.Append(",[POX].[DT_TERM_DAY]                 AS [DT_TERM_DAY]"                   );
// 管理番号 B22191 From
			sb.Append(",[POX].[PO_DATE]                     AS [PO_DATE]"                       );
// 管理番号 B22191 To
// 管理番号K27441 From
			sb.Append(",NULL								AS [PO_DEPT_CODE]"					);
// 管理番号K27441 To
			sb.Append(",[PU].[SUPL_BILL_SLIP_NO]            AS [SUPL_BILL_SLIP_NO]"             );
			sb.Append(",[PU].[CANCELED_ORDER_FLG]           AS [CANCELED_ORDER_FLG]"            );
			sb.Append(",[PU].[OVERSEAS_FLG]                 AS [OVERSEAS_FLG]"                  );
			sb.Append(",[PU].[TENOR_CODE]                   AS [TENOR_CODE]"                    );
			sb.Append(",[PU].[FMONEY_STTL_PERIOD_STT_MONTH] AS [FMONEY_STTL_PERIOD_STT_MONTH]"  );
			sb.Append(",[PU].[FMONEY_STTL_PERIOD_END_MONTH] AS [FMONEY_STTL_PERIOD_END_MONTH]"  );
			sb.Append(",[PU].[LC_NO]                        AS [LC_NO]"                         );
// 管理番号 B13878 From
			sb.Append(",[PU].[HOLD_FLG]						AS [HOLD_FLG]"						);
// 管理番号 B13878 To
			sb.Append(",NULL                                AS [REMARKS_CODE]"                  );
			sb.Append(",NULL                                AS [REMARKS]"                       );
// 管理番号 B13798 From
			sb.Append(",[PU].[ADMIN_ITEM1]                  AS [ADMIN_ITEM1]"                   );
			sb.Append(",[PU].[ADMIN_ITEM2]                  AS [ADMIN_ITEM2]"                   );
			sb.Append(",[PU].[ADMIN_ITEM3]                  AS [ADMIN_ITEM3]"                   );
// 管理番号 B13798 To
// 管理番号 K20687 From
			sb.Append(",CASE WHEN [PU].[OVERSEAS_FLG] = '1' THEN 'A'"							);
			sb.Append(" ELSE [PU].[BOOK_BASIS_TYPE]	END		AS [BOOK_BASIS_TYPE]"				);
// 管理番号 K20687 To
// 管理番号K27058 From
			sb.Append(",[PU].[BOOK_BASIS_TYPE_DTIL_CODE]	AS [BOOK_BASIS_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			sb.Append(",[PU].[OUTLAND_REMITTANCE_FLG]       AS [OUTLAND_REMITTANCE_FLG]"        );
			sb.Append(",[PU].[INTERNATIONAL_ITEM_NO]        AS [INTERNATIONAL_ITEM_NO]"         );
			sb.Append(",[PU].[REMITTANCE_PURPOSE]           AS [REMITTANCE_PURPOSE]"            );
			sb.Append(",[PU].[REMITTANCE_ALLOW_FLG]         AS [REMITTANCE_ALLOW_FLG]"          );
			sb.Append(",[PU].[REMITTANCE_ALLOW_NO]          AS [REMITTANCE_ALLOW_NO]"           );
			sb.Append(",[PU].[REMITTANCE_MESSAGE]           AS [REMITTANCE_MESSAGE]"            );
// 管理番号 B13500 From
			sb.Append(",[PU].[RCPT_INPUT_NO_NEED_FLG]		AS [RCPT_INPUT_NO_NEED_FLG]"		);
// 管理番号 B13500 To
			sb.Append(",[PU].[APPROVAL_STATUS_TYPE]         AS [APPROVAL_STATUS_TYPE]"          );
// 管理番号 K20685 From
			sb.Append(",'0'                                 AS [APPROVAL_CANCEL_FLG]"           );
// 管理番号 K20685 To
			sb.Append(",'0'                                 AS [PU_SLIP_OUTPUT_FLG]"            );
			sb.Append(",[PU].[ETAX_DTIL_AMT_TTL]            AS [ETAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[ITAX_DTIL_AMT_TTL]            AS [ITAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[NTAX_DTIL_AMT_TTL]            AS [NTAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[ETAX_AMT_TTL]                 AS [ETAX_AMT_TTL]"                  );
			sb.Append(",[PU].[ITAX_AMT_TTL]                 AS [ITAX_AMT_TTL]"                  );
			sb.Append(",[PU].[GRAND_TTL]                    AS [GRAND_TTL]"                     );
			sb.Append(",[PU].[KEY_GRAND_TTL]                AS [KEY_GRAND_TTL]"                 );
			sb.Append(",0                                   AS [KO_AMT]"                        );
			sb.Append(",NULL                                AS [LAST_KO_DATE]"                  );
			sb.Append(",'0'                                 AS [KO_COMPLETE_FLG]"               );
// 管理番号 K16187 From
			sb.Append(",0                                   AS [APPROVED_KO_AMT]"               );
			sb.Append(",'0'                                 AS [DTIL_KO_FLG]"                   );
			sb.Append(",'0'                                 AS [DELETE_ALLOW_FLG]");
// 管理番号 K16187 To
			sb.Append(",0                                   AS [EXCHANGE_GAIN_LOSS_AMT_TTL]"    );
			sb.Append(",NULL                                AS [LAST_EXCHANGE_VALUATION_DATE]"  );
			sb.Append(",'0'                                 AS [EXCHANGE_VALUATION_FIN_FLG]"    );
			sb.Append(",NULL                                AS [PYMT_NO]"                       );
			sb.Append(",'0'                                 AS [CUTOFF_FIN_FLG]"                );
			sb.Append(",'0'                                 AS [CANCEL_FLG]"                    );
			sb.Append(",'0'                                 AS [RED_SLIP_FLG]"                  );
			sb.Append(",NULL                                AS [ORIGIN_PU_NO]"                  );
			sb.Append(",NULL                                AS [OPPOSITE_PU_NO]"                );
			sb.Append(",NULL                                AS [LAST_JRNL_EXEC_DATETIME]"       );
			sb.Append(",'0'                                 AS [JRNL_FIN_FLG]"                  );
// 管理番号 B20818 From
//			sb.Append(",NULL                                AS [PRG_UPDATE_DATETIME]"           );
			sb.Append(",GETDATE()                           AS [PRG_UPDATE_DATETIME]"           );
			sb.Append(",CASE ");
			sb.Append("   WHEN [PU].[PO_NO] IS NOT NULL THEN ISNULL([POX].[PRG_UPDATE_DATETIME],GETDATE()) ");
			sb.Append("   WHEN [PU].[PU_NO] IS NOT NULL THEN ISNULL([PU].[PRG_UPDATE_DATETIME],GETDATE()) ");
			sb.Append("   ELSE GETDATE()");
			sb.Append(" END AS [REF_PRG_UPDATE_DATETIME] ");
// 管理番号 B20818 To
// 管理番号 K22205 From
            sb.Append(",NULL                                AS [INPUT_EMP_CODE]"                );
// 管理番号 K22205 To
			sb.Append(",[S].[SO_NO]                         AS [SO_NO]"                         );
			sb.Append(",[S].[SO_DATE]                       AS [SO_DATE]"                       );
			sb.Append(",[S].[CUST_SHORT_NAME]               AS [CUST_SHORT_NAME]"               );
			// 管理番号 B13569 From
			sb.Append(",CASE [PU].[EXCHANGE_TYPE] WHEN '1' THEN '1' ELSE '0' END AS [REF_PO_EXCHANGE_TYPE]");
			// 管理番号 B13569 To
// 管理番号 K24789 From
//// 管理番号 K24278 From
//			sb.Append(",[COMP].[CTAX_FRACTION_ROUND_TYPE]	AS [CTAX_FRACTION_ROUND_TYPE]"		);
//			sb.Append(",[SUPL].[CTAX_IMPOSE_FLG]			AS [CTAX_IMPOSE_FLG]"				);
//// 管理番号 K24278 To
			sb.Append(",[PU].[CTAX_IMPOSE_FLG]              AS [CTAX_IMPOSE_FLG]"				);
			sb.Append(",[PU].[CTAX_BUILDUP_TYPE]            AS [CTAX_BUILDUP_TYPE]"             );
			sb.Append(",[PU].[CTAX_FRACTION_ROUND_TYPE]     AS [CTAX_FRACTION_ROUND_TYPE]"      );
// 管理番号 K24789 To
// 管理番号 K25679 From
			sb.Append(",[PU].[PO_ADMIN_NO]                  AS [PO_ADMIN_NO]"                   );
			sb.Append(",NULL                                AS [SUPL_SLIP_NO]"                  );
// 管理番号 K25679 To
// 管理番号 K25680 From
			sb.Append(",NULL                                AS [IMPORT_SLIP_NO]"                );
// 管理番号 K25680 To
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputHead, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PU", null, null, null);
// 管理番号K27057 To
// 管理番号K27154 From
			sb.Append(",[PU].[DEAL_TYPE_CODE]				AS [DEAL_TYPE_CODE]");
// 管理番号K27154 To
			//仕入
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			//発注
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(" AS [POX]");
			sb.Append(" ON [PU].[PO_NO] = [POX].[PO_NO]");
			//受注
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SO]")).Append(" AS [S]");
			sb.Append(" ON	[POX].[SO_NO] = [S].[SO_NO]");
			sb.Append(" AND	[S].[DELETE_FLG] <> '1'");
			//組織図、組織変更
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHART]")).Append(" AS [O]");
			sb.Append(" ON	[PU].[DEPT_CODE] = [O].[DEPT_CODE]");
			sb.Append(" AND	[O].[ORG_CHANGE_ID] = ");
			sb.Append("(");
			sb.Append(" SELECT MAX([ORG_CHANGE].[ORG_CHANGE_ID]) FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHANGE]"));
			sb.Append(" [ORG_CHANGE] ");
// 管理番号 B12528 To
//			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= [PU].[PU_DATE] ");
			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= CASE WHEN [PU].[PU_DATE] < GETDATE() THEN GETDATE() ELSE [PU].[PU_DATE] END");
// 管理番号 B12528 To
			sb.Append(")");
// 管理番号 K24789 From
//// 管理番号 K24278 From
//			//取引先
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[COMP]")).Append(" AS [COMP]");
//			sb.Append(" ON  [PU].[SUPL_CODE] = [COMP].[COMP_CODE] ");
//			//仕入先
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]")).Append(" AS [SUPL]");
//			sb.Append(" ON  [PU].[SUPL_CODE] = [SUPL].[SUPL_CODE] ");
//			sb.Append(" AND [PU].[SUPL_SBNO] = [SUPL].[SUPL_SBNO] ");
//// 管理番号 K24278 To
// 管理番号 K24789 To

			wpb.AddFilter("[PU].[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[PU].[OVERSEAS_FLG]", SearchOperator.Equal, keyColumn.OverseasFlg);		//海外フラグ
			wpb.AddFilter("[PU].[PU_MODE_TYPE]", SearchOperator.Equal, "1");						//仕入形態区分
			wpb.AddFilter("[PU].[APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "3");				//承認状況は決済のみ
			wpb.AddFilter("[PU].[OPPOSITE_PU_NO]", SearchOperator.Equal, System.DBNull.Value);		//相手仕入番号

			sb.Append(wpb);

			//自部門のみの権限の場合
			if (keyColumn.DisclosureUnitType == "D")
			{
				sb.Append(" AND EXISTS (SELECT [DEPT_CODE] FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetLowerDeptLevel](@DeptCode, @Date)"));
				sb.Append(" [TEMP_DEPTLEVEL] WHERE [PU].[DEPT_CODE] = [TEMP_DEPTLEVEL].[DEPT_CODE])");
			}

			return new SqlCommandWrapper(sb.ToSqlPString(),cn);	// 管理番号K27230
		}
		//仕入明細（返品・他返品伝票あり）
		private static SqlPString CreatePuRefOtherExistDetailString(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();
			string tableNameDetail    = "#PU_DETAIL_RETURN_TEMP";

			//返品伝票一時テーブル作成
			CreatePuDtilReturnTempTable(commonData, cn, keyColumn, tableNameDetail);

			string prodSpec1Name = string.Empty;
			string prodSpec2Name = string.Empty;
			string unitShortName = string.Empty;

			switch (keyColumn.OverseasFlg)
			{
				case OverseasFlg.DOMESTIC:
					prodSpec1Name = "PROD_SPEC_1_NAME";
					prodSpec2Name = "PROD_SPEC_2_NAME";
					unitShortName = "UNIT_SHORT_NAME";
					break;
				case OverseasFlg.OVERSEAS:
					prodSpec1Name = "PROD_SPEC_1_ENG_NAME";
					prodSpec2Name = "PROD_SPEC_2_ENG_NAME";
					unitShortName = "UNIT_ENG_NAME";
					break;
			}

			//在庫管理部門の取得
			sb.Append("DECLARE @STOCK_ADMIN_DEPT_CODE NVARCHAR(10) ");
			sb.Append("SELECT ");
			sb.Append("  @STOCK_ADMIN_DEPT_CODE = ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SC_MS_GetStockDeptCode]"));
			sb.Append("(@MYCOMP_CODE, [DEPT_CODE], GETDATE())");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]"));
			wpb.AddFilter("[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo );
			sb.Append(wpb);

// 管理番号 B11723・B11796 From
			sb.Append(@"
DECLARE @CUR_DIGIT      DECIMAL(1,0)
DECLARE @CUR_ROUND_TYPE NVARCHAR(1)
DECLARE @AMT_ROUND_TYPE NVARCHAR(1)

SELECT
	 @CUR_ROUND_TYPE = [MC].[CUR_FRACTION_ROUND_TYPE]
	,@AMT_ROUND_TYPE = [MC].[AMT_TTL_FRACTION_ROUND_TYPE]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[MYCOMP]")).Append(@" AS [MC]
WHERE [MC].[MYCOMP_CODE] = @MYCOMP_CODE

SELECT @CUR_DIGIT = [C].[DECIMAL_DIGIT]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(@" AS [PU]
INNER JOIN ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CUR]")).Append(@" AS [C]
	ON [PU].[CUR_CODE] = [C].[CUR_CODE]
WHERE [PU].[PU_NO] = @SLIP_NO
");
// 管理番号 B11723・B11796 To

			wpb = new WherePhraseBuilder();

			sb.Append("SELECT ");
			sb.Append(" [PD].[PU_LINE_ID]                         AS [PU_LINE_ID]"                );
			sb.Append(",[PD].[PU_LINE_NO]                         AS [PU_LINE_NO]"                );
			sb.Append(",[PD].[PO_NO]                              AS [PO_NO]"                     );
			sb.Append(",[PD].[PO_LINE_ID]                         AS [PO_LINE_ID]"                );
// 管理番号 B14315 From
//			sb.Append(",[PD].[RCPT_NO]                            AS [RCPT_NO]"                   );
//			sb.Append(",[PD].[RCPT_LINE_ID]                       AS [RCPT_LINE_ID]"              );
			if(keyColumn.OverseasFlg == "0")
			{
				sb.Append(",[PD].[RCPT_NO]                        AS [RCPT_NO]"                   );
				sb.Append(",[PD].[RCPT_LINE_ID]                   AS [RCPT_LINE_ID]"              );
			}
			else
			{
				sb.Append(",[RD].[RCPT_NO]                        AS [RCPT_NO]"                   );
				sb.Append(",[RD].[RCPT_LINE_ID]                   AS [RCPT_LINE_ID]"              );
			}
// 管理番号 B14315 From
			sb.Append(",[PD].[SA_NO]                              AS [SA_NO]"                     );
			sb.Append(",[PD].[SA_LINE_ID]                         AS [SA_LINE_ID]"                );
			sb.Append(",[PD].[WH_CODE]                            AS [WH_CODE]"                   );
			sb.Append(",[W].[WH_SHORT_NAME]                       AS [WH_SHORT_NAME]"             );
			sb.Append(",[PD].[PROD_CODE]                          AS [PROD_CODE]"                 );
			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_PO_NAME]"              );
			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_SHORT_NAME]"           );
			sb.Append(",[PD].[PROD_PO_NAME]                       AS [PROD_NAME]"                 );
			sb.Append(",[PD].[PROD_TYPE]                          AS [PROD_TYPE]"                 );
			sb.Append(",[PROD].[DISP_CONTROL_TYPE]                AS [DISP_CONTROL_TYPE]"         );
			sb.Append(",[PROD].[STOCK_ADMIN_FLG]                  AS [STOCK_ADMIN_FLG]"           );
			sb.Append(",[PROD].[LOT_ADMIN_FLG]                    AS [LOT_ADMIN_FLG]"             );
// 管理番号 K25322 From
			sb.Append(",[PROD].[LOT_STOCK_VALUATION_FLG]          AS [LOT_STOCK_VALUATION_FLG]"   );
// 管理番号 K25322 To
			sb.Append(",[U].[QT_DECIMAL_USE_FLG]                  AS [QT_DECIMAL_USE_FLG]"        );
			sb.Append(",[PD].[CTAX_CALC_TYPE]                     AS [CTAX_CALC_TYPE]"            );
// 管理番号 K24789 From
//// 管理番号 B24787 From
////// 管理番号 B18904 From
//////			sb.Append(",[PROD].[CTAX_RATE_CODE]                   AS [CTAX_RATE_CODE]"            );
////			if(keyColumn.OverseasFlg == "1")
////			{
////				sb.Append(",'0'									  AS [CTAX_RATE_CODE]"            );
////			}
////			else
////			{
////				sb.Append(",[PROD].[CTAX_RATE_CODE]               AS [CTAX_RATE_CODE]"            );
////			}
////// 管理番号 B18904 To
//			sb.Append(",[PROD].[CTAX_RATE_CODE]                   AS [CTAX_RATE_CODE]"            );
//// 管理番号 B24787 To
			sb.Append(",[PD].[CTAX_TYPE_CODE]                     AS [CTAX_TYPE_CODE]"            );
			sb.Append(",[PD].[CTAX_RATE_CODE]                     AS [CTAX_RATE_CODE]"            );
// 管理番号 K24789 To
			sb.Append(",[PD].[CTAX_RATE]                          AS [CTAX_RATE]"                 );
			sb.Append(",[PD].[PROD_SPEC_1_CODE]                   AS [PROD_SPEC_1_CODE]"          );
			sb.Append(",[PS1].[").Append(prodSpec1Name).Append("] AS [PROD_SPEC_1_NAME]"          );
			sb.Append(",[PD].[PROD_SPEC_2_CODE]                   AS [PROD_SPEC_2_CODE]"          );
			sb.Append(",[PS2].[").Append(prodSpec2Name).Append("] AS [PROD_SPEC_2_NAME]"          );
			sb.Append(",[PD].[PU_PLAN_PRICE]                      AS [PU_PLAN_PRICE]"             );
			sb.Append(",[PD].[STOCK_UNIT_STD_SELL_PRICE]          AS [STOCK_UNIT_STD_SELL_PRICE]" );
			sb.Append(",[PD].[UNIT_CODE]                          AS [UNIT_CODE]"                 );
			sb.Append(",[U].[").Append(unitShortName).Append("]   AS [UNIT_SHORT_NAME]"           );
// 管理番号  B14315 From
//			sb.Append(",[PD].[PU_QT] - ISNULL([REF_PU].[PU_QT], 0) AS [PU_QT]"                    );
			sb.Append(", CASE WHEN [PU].[RCPT_INPUT_NO_NEED_FLG] = '1' THEN "                     );
			sb.Append("  [PD].[PU_QT] - ISNULL([REF_PU].[PU_QT], 0) "                             );
			sb.Append("  ELSE "                                                                   );
			sb.Append("  [PD].[TRANSIT_RCPT_QT] - ISNULL([REF_PU].[PU_QT], 0) "                   );
			sb.Append("  END AS [PU_QT]"                                                          );
// 管理番号  B14315 To
			sb.Append(",[PD].[PU_QT] - ISNULL([REF_PU].[PU_QT], 0) AS [INIT_PU_QT]"               );
			sb.Append(",[PD].[TRANSIT_RCPT_QT]                    AS [TRANSIT_RCPT_QT]"           );
			sb.Append(",[PD].[RCPT_INPUT_NO_NEED_FLG]             AS [RCPT_INPUT_NO_NEED_FLG]"    );

// 管理番号  B14315 From
			//1. 仕入数量上限値の設定ここから
//			sb.Append(",[PD].[PU_QT] - ISNULL([REF_PU].[PU_QT], 0) AS [UPPER_LIMIT_PU_QT]"        );
			sb.Append(", CASE WHEN [PU].[RCPT_INPUT_NO_NEED_FLG] = '1' THEN "                     );
			sb.Append("  [PD].[PU_QT] - ISNULL([REF_PU].[PU_QT], 0) "                             );
			sb.Append("  ELSE "                                                                   );
			sb.Append("  [PD].[TRANSIT_RCPT_QT] - ISNULL([REF_PU].[PU_QT], 0) "                   );
			sb.Append("  END AS [UPPER_LIMIT_PU_QT]"                                              );
			//1. 売上数量上限値の設定ここまで
// 管理番号  B14315 To

			sb.Append(",ISNULL([ST].[VALID_QT],0)                 AS [VALID_QT]"                  );
// 管理番号 B19191 From
//			sb.Append(",[PD].[STOCK_UNIT_PU_QT] - ISNULL([REF_PU].[STOCK_UNIT_PO_PU_QT], 0) AS [STOCK_UNIT_PU_QT]");
			sb.Append(",[PD].[STOCK_UNIT_PU_QT] - ISNULL([REF_PU].[STOCK_UNIT_PU_QT], 0) AS [STOCK_UNIT_PU_QT]");
// 管理番号 B19191 To

			//2. 在庫単位受注仕入数量の設定ここから
			sb.Append(",[PD].[STOCK_UNIT_PO_PU_QT] - ISNULL([REF_PU].[STOCK_UNIT_PO_PU_QT], 0) AS [STOCK_UNIT_PO_PU_QT]");
			//2. 在庫単位受注売上数量の設定ここまで

			sb.Append(",0                                         AS [STOCK_UNIT_PO_ALLOC_PU_QT]" );
			sb.Append(",[PD].[PU_PRICE]                           AS [PU_PRICE]"                  );
			sb.Append(",[PD].[PU_PRICE]                           AS [INIT_PU_PRICE]"             );
			sb.Append(",[PD].[DISC_FLG]                           AS [DISC_FLG]"                  );
// 管理番号 B13878 From
			sb.Append(",[PD].[PRICE_UNDECIDED_FLG]				  AS [PRICE_UNDECIDED_FLG]"		  );
// 管理番号 B13878 To
			sb.Append(",NULL                                      AS [LINE_REMARKS_CODE]"         );
			sb.Append(",NULL                                      AS [LINE_REMARKS]"              );
// 管理番号K27525 From
			sb.Append(",[PD].[BOOK_DEDUCTION_REASON_CODE]         AS [BOOK_DEDUCTION_REASON_CODE]");
			sb.Append(",[BDR].[BOOK_DEDUCTION_REASON_NAME]        AS [BOOK_DEDUCTION_REASON_NAME]");
// 管理番号K27525 To
// 管理番号 K16671 From
			sb.Append(",NULL                                      AS [REF_CODE]"                  );
// 管理番号 K16671 To
			sb.Append(",[U].[INCLUDE_QT]                          AS [INCLUDE_QT]"                );
			sb.Append(",[PD].[DTIL_AMT]                           AS [DTIL_AMT]"                  );
			sb.Append(",[PD].[ETAX_AMT]                           AS [ETAX_AMT]"                  );
			sb.Append(",[PD].[ITAX_AMT]                           AS [ITAX_AMT]"                  );
			sb.Append(",'0'                                       AS [PRICE_UPDATE_FLG]"          );
// 管理番号 K24278 From
//// 管理番号 B11723・B11796 From
////			sb.Append(",([PD].[PU_QT] - ISNULL([REF_PU].[PU_QT], 0)) * [PD].[PU_PRICE] AS [PU_MONEY]");
//			sb.Append(",").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound]"));
//			sb.Append("(([PD].[PU_QT]-ISNULL([REF_PU].[PU_QT],0)) * [PD].[PU_PRICE], @CUR_DIGIT, @AMT_ROUND_TYPE) AS [PU_MONEY]");
//// 管理番号 B11723・B11796 To
			sb.Append(", CASE WHEN @ImposeFlg = '0' AND [PD].[CTAX_CALC_TYPE] = 'I' THEN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound([PD].[PU_PRICE]*([PD].[PU_QT]-ISNULL([REF_PU].[PU_QT],0)),@CUR_DIGIT,@AMT_ROUND_TYPE) - "));
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound("));
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound([PD].[PU_PRICE]*([PD].[PU_QT]-ISNULL([REF_PU].[PU_QT],0)),@CUR_DIGIT,@AMT_ROUND_TYPE) * "));
			sb.Append("([PD].[CTAX_RATE]/100)/(1+([PD].[CTAX_RATE]/100)),@CUR_DIGIT, @CtaxRoundType) ELSE ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound([PD].[PU_PRICE]*([PD].[PU_QT]-ISNULL([REF_PU].[PU_QT],0)),@CUR_DIGIT,@AMT_ROUND_TYPE) END AS [PU_MONEY]"));
// 管理番号 K24278 To
			sb.Append(",[PROD].[PROD_NAME_CORRECT_ALLOW_FLG]      AS [PROD_NAME_CORRECTION_FLG]"  );

			//コピー時は商品変更可能、返品時は商品変更不可
			sb.Append(",'0'                                       AS [PROD_EDIT_FLG]"       );

			//入荷済判定
			sb.Append(",CASE "                                                              );
			sb.Append("     WHEN [PU].[OVERSEAS_FLG] = '1' "                                );
			sb.Append("         THEN '0' "                                                  );
// 管理番号 B24477 From
//			sb.Append("     WHEN [POD].[RCPT_PU_QT] > 0 "                                   );
//			sb.Append("         THEN '1' "                                                  );
//			sb.Append("     ELSE "                                                          );
//			sb.Append("         CASE WHEN [POD].[RCPT_QT] - [POD].[RCPT_RETURN_QT] - [POD].[DIRECT_PU_QT] <> 0 ");
//			sb.Append("             THEN '1' "                                              );
//			sb.Append("             ELSE '0' "                                              );
//			sb.Append("         END "                                                       );
			sb.Append("     WHEN [RCPTED_PU_D].[PU_NO] IS NULL "                            );
			sb.Append("         THEN '0' "                                                  );
			sb.Append("     ELSE '1' "                                                      );
// 管理番号 B24477 To
			sb.Append(" END                                       AS [IS_RCPT_EXECUTE]"     );
			sb.Append(",'R'                                       AS [ROW_STATE]"           );
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputDetail, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PD", "CUSTOM_ITEM_TAG", "@PU_DATE", null, keyColumn.ParamType == "View" || keyColumn.ParamType == "Mod");
// 管理番号K27057 To

			//仕入
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			//仕入明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PD]");
			sb.Append(" ON [PU].[PU_NO] = [PD].[PU_NO]");
			//既存の返品伝票の一時集計テーブル
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append( tableNameDetail ).Append(" AS [REF_PU]");
			sb.Append(" ON [PD].[PU_LINE_ID] = [REF_PU].[PU_LINE_ID]");
// 管理番号 B24477 From
//			//発注明細 入荷済み判定で使用
//			sb.Append(" LEFT OUTER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO_DTIL]")).Append(" AS [POD]");
//			sb.Append(" ON  [PD].[PO_NO]      = [POD].[PO_NO]");
//			sb.Append(" AND [PD].[PO_LINE_ID] = [POD].[PO_LINE_ID]");
			//入荷済仕入判定用サブクエリ
			sb.Append(" LEFT OUTER JOIN (SELECT DISTINCT");
			sb.Append("			[PU_D].[PU_NO]			AS [PU_NO]		");
			sb.Append("			,[PU_D].[PU_LINE_ID]	AS [PU_LINE_ID]	");
			sb.Append("		FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PU_D]");
			sb.Append("			INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_LOT_DTIL]")).Append(" AS [PU_L_D]");
			sb.Append("				ON  [PU_D].[PU_NO]      = [PU_L_D].[PU_NO] "     );
			sb.Append("				AND [PU_D].[PU_LINE_ID] = [PU_L_D].[PU_LINE_ID] ");
			sb.Append("				AND [PU_L_D].[RCPT_NO] IS NOT NULL "             );
			sb.Append(" ) AS [RCPTED_PU_D] ");
			sb.Append(" ON  [PD].[PU_NO]      = [RCPTED_PU_D].[PU_NO] "     );
			sb.Append("	AND [PD].[PU_LINE_ID] = [RCPTED_PU_D].[PU_LINE_ID] ");
// 管理番号 B24477 To

			//商品
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [PROD]");
			sb.Append(" ON  [PD].[PROD_CODE]   = [PROD].[PROD_CODE]");
			sb.Append(" AND [PROD].[PROD_TYPE] = '0' ");//通常商品のみ
			//商品規格1
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_1]")).Append(" AS [PS1]");
			sb.Append(" ON [PD].[PROD_SPEC_1_CODE] = [PS1].[PROD_SPEC_1_CODE]");
			//商品規格2
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_2]")).Append(" AS [PS2]");
			sb.Append(" ON [PD].[PROD_SPEC_2_CODE] = [PS2].[PROD_SPEC_2_CODE]");
			//倉庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[WH]")).Append(" AS [W]");
			sb.Append(" ON [PD].[WH_CODE] = [W].[WH_CODE]");
			//単位別商品属性
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
			sb.Append(" ON [PD].[PROD_CODE] = [U].[PROD_CODE]");
			sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE] ");
			//在庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[STOCK]")).Append(" AS [ST]");
			sb.Append(" ON  [PD].[WH_CODE]          = [ST].[WH_CODE] ");
			sb.Append(" AND [PD].[PROD_CODE]        = [ST].[PROD_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [ST].[PROD_SPEC_1_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [ST].[PROD_SPEC_2_CODE] ");
			sb.Append(" AND [ST].[DEPT_CODE]        = @STOCK_ADMIN_DEPT_CODE ");
// 管理番号 B13877 From
			if (keyColumn.ProjectStockAdminUseFlg)
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ISNULL([PU].[PROJ_CODE],'')");
				sb.Append(" AND [ST].[PROJ_SBNO] = ISNULL([PU].[PROJ_SBNO],'')");
			}
			else
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ''");
				sb.Append(" AND [ST].[PROJ_SBNO] = ''");
			}
// 管理番号K27525 From
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[BOOK_DEDUCTION_REASON]")).Append(" AS [BDR]");
			sb.Append(" ON [BDR].[BOOK_DEDUCTION_REASON_CODE] = [PD].[BOOK_DEDUCTION_REASON_CODE] ");
// 管理番号K27525 To
// 管理番号 B13877 To
// 管理番号 B14315 From
			//入荷
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD]");
// 管理番号 B14704 From
//			sb.Append(" ON  [PD].[PU_NO] = [RD].[PU_NO] ");
//			sb.Append(" AND  [PD].[PU_LINE_ID] = [RD].[PU_LINE_ID] ");
			sb.Append(" ON  [PD].[RCPT_NO] = [RD].[RCPT_NO] ");
			sb.Append(" AND  [PD].[RCPT_LINE_ID] = [RD].[RCPT_LINE_ID] ");
// 管理番号 B14704 To
// 管理番号 B14315 To

			wpb.AddFilter("[PD].[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo);
// 管理番号 K24285 From
//			wpb.AddFilter("[PD].[PU_QT] - ISNULL([REF_PU].[PU_QT], 0)", SearchOperator.GreaterThan, 0);
			wpb.AddFilter("[PD].[PU_QT] - ISNULL([REF_PU].[PU_QT], 0)", SearchOperator.NotEqual, 0);
// 管理番号 K24285 To
			sb.Append(wpb);
			sb.Append("ORDER BY [PD].[PU_LINE_NO] ASC ");

			return sb.ToSqlPString();	// 管理番号K27230
		}
		//仕入ロット明細（返品・他返品伝票あり）
		private static string CreatePuRefOtherExistLotDetailString(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn, bool rcptInputNoNeedFlg)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();
			string tableNameLotDetail = "#PU_LOT_DETAIL_RETURN_TEMP";

			//返品伝票一時テーブル作成
			CreatePuLotDtilReturnTempTable(commonData, cn, keyColumn, tableNameLotDetail);

// 管理番号 B14315 From
			if(rcptInputNoNeedFlg)
			{
// 管理番号 B14315 To
				//返品で他伝票あり
				sb.Append("SELECT ");
				sb.Append(" [P_L_D].[PU_LINE_ID]          AS [ROW_ID]      ,");
				sb.Append(" [P_L_D].[LOT_NO]              AS [LOT_NO]      ,");
				sb.Append(" [P_L_D].[RCPT_NO]             AS [RCPT_NO]     ,");
				sb.Append(" [P_L_D].[RCPT_LINE_ID]        AS [RCPT_LINE_ID],");
				sb.Append(" [P_L_D].[RCPT_LOT_ID]         AS [RCPT_LOT_ID] ,");
				sb.Append(" [P_L_D].[SA_NO]               AS [SA_NO]       ,");
				sb.Append(" [P_L_D].[SA_LINE_ID]          AS [SA_LINE_ID]  ,");
				sb.Append(" [P_L_D].[SA_LOT_ID]           AS [SA_LOT_ID]   ,");
				sb.Append(" [LOT].[FAB_DATE]              AS [FAB_DATE]    ,");
// 管理番号 B22625 From
//				sb.Append(" DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE]) AS [TERM_DATE] ,");
				sb.Append(" CASE WHEN CONVERT(DATETIME,'9998/12/31') - [LOT].[FAB_DATE] < [P].[LOT_VALID_TERM_DAY_CNT]-1");
				sb.Append(   " THEN CONVERT(DATETIME,'9998/12/31')");
				sb.Append(   " ELSE DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE])");
				sb.Append(" END AS [TERM_DATE] ,");
// 管理番号 B22625 To
				sb.Append(" [P_L_D].[PU_LOT_ID]           AS [LOT_ID]      ,");
				sb.Append(" '1'                           AS [STOCK_TYPE]  ,");
				sb.Append(" 0                             AS [STOCK_QT]    ,");
				sb.Append(" [P_L_D].[TRANSIT_RCPT_QT]     AS [TRANSIT_RCPT_QT],");
				//集計値を引く
				sb.Append(" [P_L_D].[PU_QT]-ISNULL([REF_P_L_D].[PU_QT], 0) AS [INIT_QT],");
				sb.Append(" [P_L_D].[PU_QT]-ISNULL([REF_P_L_D].[PU_QT], 0) AS [EDIT_QT] ");
// 管理番号 K25322 From
				sb.Append(",0                             AS [PO_ALLOC_RCPT_QT] ");  //在庫単位発注引当仕入数量
// 管理番号 K25322 To

				//仕入
				sb.Append("FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
				//仕入明細
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PD]");
				sb.Append(" ON  [PU].[PU_NO] = [PD].[PU_NO] ");
				//仕入ロット明細
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_LOT_DTIL]")).Append(" AS [P_L_D]");
				sb.Append(" ON  [PD].[PU_NO]      = [P_L_D].[PU_NO] ");
				sb.Append(" AND [PD].[PU_LINE_ID] = [P_L_D].[PU_LINE_ID] ");
				sb.Append(" AND (([P_L_D].[RCPT_NO] IS NOT NULL) OR ([P_L_D].[RCPT_NO] IS NULL AND [P_L_D].[LOT_NO] <> '9'))");
				//入荷
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");
				sb.Append(" ON  [P_L_D].[RCPT_NO] = [RCPT].[RCPT_NO] ");
				//既存の返品伝票の一時集計テーブル
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append( tableNameLotDetail ).Append(" AS [REF_P_L_D]");
				sb.Append(" ON  [P_L_D].[PU_LINE_ID] = [REF_P_L_D].[PU_LINE_ID] ");
				sb.Append(" AND [P_L_D].[PU_LOT_ID]  = [REF_P_L_D].[PU_LOT_ID] ");
				//商品
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [P]");
				sb.Append(" ON  [PD].[PROD_CODE] = [P].[PROD_CODE] ");
				//ロット
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[LOT]")).Append(" AS [LOT]");
				sb.Append(" ON  [PD].[PROD_CODE]        = [LOT].[PROD_CODE] ");
				sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [LOT].[PROD_SPEC_1_CODE] ");
				sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [LOT].[PROD_SPEC_2_CODE] ");
				sb.Append(" AND [P_L_D].[LOT_NO]        = [LOT].[LOT_NO] ");

				//単位別商品属性
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
				sb.Append(" ON  [PD].[PROD_CODE] = [U].[PROD_CODE] ");
				sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE]");

				wpb.AddFilter("[PU].[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo);
// 管理番号 K24285 From
//				wpb.AddFilter("[P_L_D].[PU_QT] - ISNULL([REF_P_L_D].[PU_QT], 0)", SearchOperator.GreaterThan, 0);
				wpb.AddFilter("[P_L_D].[PU_QT] - ISNULL([REF_P_L_D].[PU_QT], 0)", SearchOperator.NotEqual, 0);
// 管理番号 K24285 To
				sb.Append(wpb);
				sb.Append("ORDER BY [LOT].[FAB_DATE] ASC, [P_L_D].[PU_LOT_ID] ASC, [RCPT].[RCPT_DATE] ASC, [P_L_D].[RCPT_NO] ASC");
			}
			else
			{
				sb.Append("SELECT ");
				sb.Append(" [R_L_D].[PU_LINE_ID]          AS [ROW_ID]      ,");
				sb.Append(" [R_L_D].[LOT_NO]              AS [LOT_NO]      ,");
				sb.Append(" [R_L_D].[RCPT_NO]             AS [RCPT_NO]     ,");
				sb.Append(" [R_L_D].[RCPT_LINE_ID]        AS [RCPT_LINE_ID],");
				sb.Append(" [R_L_D].[RCPT_LOT_ID]         AS [RCPT_LOT_ID] ,");
				sb.Append(" NULL                          AS [SA_NO]       ,");
				sb.Append(" NULL                          AS [SA_LINE_ID]  ,");
				sb.Append(" NULL                          AS [SA_LOT_ID]   ,");
				sb.Append(" [LOT].[FAB_DATE]              AS [FAB_DATE]    ,");
// 管理番号 B22625 From
//				sb.Append(" DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE]) AS [TERM_DATE] ,");
				sb.Append(" CASE WHEN CONVERT(DATETIME,'9998/12/31') - [LOT].[FAB_DATE] < [P].[LOT_VALID_TERM_DAY_CNT]-1");
				sb.Append(   " THEN CONVERT(DATETIME,'9998/12/31')");
				sb.Append(   " ELSE DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE])");
				sb.Append(" END AS [TERM_DATE] ,");
// 管理番号 B22625 To
				sb.Append(" [R_L_D].[RCPT_LOT_ID]         AS [LOT_ID]      ,");
				sb.Append(" '1'                           AS [STOCK_TYPE]  ,");
				sb.Append(" 0                             AS [STOCK_QT]    ,");
				sb.Append(" [P_L_D].[TRANSIT_RCPT_QT]     AS [TRANSIT_RCPT_QT],");
				//集計値を引く
				sb.Append(" [R_L_D].[RCPT_QT]-ISNULL([REF_P_L_D].[PU_QT], 0) AS [INIT_QT],");
				sb.Append(" [R_L_D].[RCPT_QT]-ISNULL([REF_P_L_D].[PU_QT], 0) AS [EDIT_QT] ");
// 管理番号 K25322 From
				sb.Append(",0                             AS [PO_ALLOC_RCPT_QT]  "); //在庫単位発注引当仕入数量
// 管理番号 K25322 To

				//仕入明細
				sb.Append("FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PD]");
				//仕入ロット明細
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_LOT_DTIL]")).Append(" AS [P_L_D]");
				sb.Append(" ON  [PD].[PU_NO]      = [P_L_D].[PU_NO] ");
				sb.Append(" AND [PD].[PU_LINE_ID] = [P_L_D].[PU_LINE_ID] ");
// 管理番号 B14704 From
				sb.Append(" AND [PD].[WH_CODE] IS NOT NULL ");
// 管理番号 B14704 To
				//入荷
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");
				sb.Append(" ON  [PD].[PU_NO] = [RCPT].[PU_NO] ");
// 管理番号 B17566 From
				sb.Append(" AND [RCPT].[DELETE_FLG] <> '1' ");
// 管理番号 B17566 To
				//入荷ロット明細
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_LOT_DTIL]")).Append(" AS [R_L_D]");
				sb.Append(" ON  [PD].[PU_NO]      = [R_L_D].[PU_NO] ");
				sb.Append(" AND [PD].[PU_LINE_ID] = [R_L_D].[PU_LINE_ID] ");
				//既存の返品伝票の一時集計テーブル
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append( tableNameLotDetail ).Append(" AS [REF_P_L_D]");
				sb.Append(" ON  [R_L_D].[RCPT_LINE_ID] = [REF_P_L_D].[PU_LINE_ID] ");
				sb.Append(" AND [R_L_D].[RCPT_LOT_ID]  = [REF_P_L_D].[PU_LOT_ID] ");
				//商品
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [P]");
				sb.Append(" ON  [PD].[PROD_CODE] = [P].[PROD_CODE] ");
				//ロット
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[LOT]")).Append(" AS [LOT]");
				sb.Append(" ON  [PD].[PROD_CODE]        = [LOT].[PROD_CODE] ");
				sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [LOT].[PROD_SPEC_1_CODE] ");
				sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [LOT].[PROD_SPEC_2_CODE] ");
				sb.Append(" AND [R_L_D].[LOT_NO]        = [LOT].[LOT_NO] ");

				//単位別商品属性
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
				sb.Append(" ON  [PD].[PROD_CODE] = [U].[PROD_CODE] ");
				sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE]");

				wpb.AddFilter("[PD].[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo);
				wpb.AddFilter("[P_L_D].[PU_QT] - ISNULL([REF_P_L_D].[PU_QT], 0)", SearchOperator.GreaterThan, 0);
// 管理番号 B17566 From
				wpb.AddFilter("[R_L_D].[DELETE_FLG]",SearchOperator.NotEqual, "1");
// 管理番号 B17566 From
				sb.Append(wpb);
				sb.Append("ORDER BY [LOT].[FAB_DATE] ASC, [R_L_D].[PU_LOT_ID] ASC, [RCPT].[RCPT_DATE] ASC, [R_L_D].[RCPT_NO] ASC");
			}
			return sb.ToString();
		}
		//仕入（返品・他返品伝票なし）
		private static SqlCommandWrapper CreatePuRefHeaderCommand(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append("SELECT");
			sb.Append(" NULL                                AS [PU_NO]"                         );
			sb.Append(",[PU].[PU_NAME]                      AS [PU_NAME]"                       );
			sb.Append(",CASE WHEN @PARAM_TYPE <> 'Mod' AND @PARAM_TYPE <> 'View'"               );
			sb.Append("		THEN GETDATE() "                                                    );
			sb.Append("		ELSE [PU].[PU_DATE] "                                               );
			sb.Append(" END                                 AS [PU_DATE]"                       );
// 管理番号 K24789 From
//// 管理番号 K16590 From
//			sb.Append(",CASE WHEN @PARAM_TYPE <> 'Mod' AND @PARAM_TYPE <> 'View'"               );
//			sb.Append("		THEN GETDATE() "                                                    );
//			sb.Append("		ELSE [PU].[DEAL_DATE] "                                             );
//			sb.Append(" END                                 AS [DEAL_DATE]"                     );
//// 管理番号 K16590 To
// 管理番号B27131 From
//			sb.Append(",[PU].[DEAL_DATE]                    AS [DEAL_DATE]"                      );
			if (keyColumn.DateAdminType == "1")     // 日付管理区分が「取引日管理基準」
			{
				sb.Append(",[PU].[DEAL_DATE]                AS [DEAL_DATE]"                     );
			}
			else
			{
				sb.Append(",GETDATE()                       AS [DEAL_DATE]"                     );
			}
// 管理番号B27131 To
// 管理番号 K24789 To
			sb.Append(",NULL                                AS [PO_NO]"                         );
// 管理番号 B14315 From
//			sb.Append(",NULL                                AS [RCPT_NO]"                       );
			if(keyColumn.OverseasFlg == "0")
			{
				sb.Append(",NULL                            AS [RCPT_NO]"                       );
			}
			else
			{
				sb.Append(",[RCPT].[RCPT_NO]                AS [RCPT_NO]"                       );
			}
// 管理番号 B14315 From
			sb.Append(",'2'                                 AS [PU_MODE_TYPE]"                  );
// 管理番号K27058 From
			sb.Append(",@PU_MODE_TYPE_DTIL_CODE				AS [PU_MODE_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			sb.Append(",@REF_PU_NO                          AS [REF_PU_NO]"                     );
// 管理番号 B21177 From
			sb.Append(",CASE WHEN @PARAM_TYPE <> 'Mod' AND @PARAM_TYPE <> 'View'"               );
			sb.Append("		THEN [PU].[PU_DATE] "                                               );
			sb.Append("		ELSE GETDATE() "                                                    );
			sb.Append(" END                                 AS [REF_PU_DATE]"                   );
// 管理番号 B21177 To
			sb.Append(",[PU].[CUR_CODE]                     AS [CUR_CODE]"                      );
			sb.Append(",[PU].[EXCHANGE_TYPE]                AS [EXCHANGE_TYPE]"                 );
			sb.Append(",[PU].[EXCHANGE_REZ_NO]              AS [EXCHANGE_REZ_NO]"               );
			sb.Append(",[PU].[RATE]                         AS [RATE]"                          );
			sb.Append(",[PU].[DEPT_CODE]                    AS [DEPT_CODE]"                     );
			sb.Append(",[O].[DEPT_SHORT_NAME]               AS [DEPT_SHORT_NAME]"               );
			sb.Append(",[PU].[ORIGIN_DEPT_CODE]             AS [ORIGIN_DEPT_CODE]"              );
			sb.Append(",[PU].[OLD_DEPT_CODE]                AS [OLD_DEPT_CODE]"                 );
			sb.Append(",[PU].[ORG_CHANGE_ID]                AS [ORG_CHANGE_ID]"                 );
			sb.Append(",[PU].[DATA_MIGRATE_DATETIME]        AS [DATA_MIGRATE_DATETIME]"         );
			sb.Append(",[PU].[EMP_CODE]                     AS [EMP_CODE]"                      );
			sb.Append(",[PU].[PROJ_CODE]                    AS [PROJ_CODE]"                     );
			sb.Append(",[PU].[PROJ_SBNO]                    AS [PROJ_SBNO]"                     );
			sb.Append(",[PU].[SUPL_CODE]                    AS [SUPL_CODE]"                     );
			sb.Append(",[PU].[SUPL_SBNO]                    AS [SUPL_SBNO]"                     );
			sb.Append(",[PU].[TEMP_CODE_FLG]                AS [TEMP_CODE_FLG]"                 );
			sb.Append(",[PU].[SUPL_NAME]                    AS [SUPL_NAME]"                     );
			sb.Append(",[PU].[SUPL_SHORT_NAME]              AS [SUPL_SHORT_NAME]"               );
			sb.Append(",[PU].[SUPL_DEPT_NAME_1]             AS [SUPL_DEPT_NAME_1]"              );
			sb.Append(",[PU].[SUPL_DEPT_NAME_2]             AS [SUPL_DEPT_NAME_2]"              );
			sb.Append(",[PU].[SUPL_COUNTRY_CODE]            AS [SUPL_COUNTRY_CODE]"             );
			sb.Append(",[PU].[SUPL_ZIP]                     AS [SUPL_ZIP]"                      );
			sb.Append(",[PU].[SUPL_STATE]                   AS [SUPL_STATE]"                    );
			sb.Append(",[PU].[SUPL_CITY]                    AS [SUPL_CITY]"                     );
			sb.Append(",[PU].[SUPL_ADDRESS1]                AS [SUPL_ADDRESS1]"                 );
			sb.Append(",[PU].[SUPL_ADDRESS2]                AS [SUPL_ADDRESS2]"                 );
			sb.Append(",[PU].[SUPL_PHONE]                   AS [SUPL_PHONE]"                    );
			sb.Append(",[PU].[SUPL_FAX]                     AS [SUPL_FAX]"                      );
			sb.Append(",[PU].[SUPL_USER_NAME]               AS [SUPL_USER_NAME]"                );
			sb.Append(",[PU].[AC_NO]                        AS [AC_NO]"                         );
			sb.Append(",[PU].[AC_HOLDER]                    AS [AC_HOLDER]"                     );
			sb.Append(",[PU].[AC_TYPE]                      AS [AC_TYPE]"                       );
			sb.Append(",[PU].[BANK_AC_TYPE]                 AS [BANK_AC_TYPE]"                  );
			sb.Append(",[PU].[BANK_COUNTRY_CODE]            AS [BANK_COUNTRY_CODE]"             );
			sb.Append(",[PU].[BANK_CODE]                    AS [BANK_CODE]"                     );
			sb.Append(",[PU].[BANK_BRANCH_CODE]             AS [BANK_BRANCH_CODE]"              );
			sb.Append(",[PU].[DELI_TYPE]                    AS [DELI_TYPE]"                     );
			sb.Append(",[PU].[WH_CODE]                      AS [WH_CODE]"                       );
			sb.Append(",[PU].[DELI_CUST_CODE]               AS [DELI_CUST_CODE]"                );
			sb.Append(",[PU].[DELI_CUST_SBNO]               AS [DELI_CUST_SBNO]"                );
			sb.Append(",[PU].[DELI_PLACE_CODE]              AS [DELI_PLACE_CODE]"               );
			sb.Append(",[PU].[DELI_PLACE_NAME]              AS [DELI_PLACE_NAME]"               );
			sb.Append(",[PU].[DELI_PLACE_COUNTRY_CODE]      AS [DELI_PLACE_COUNTRY_CODE]"       );
			sb.Append(",[PU].[DELI_PLACE_ZIP]               AS [DELI_PLACE_ZIP]"                );
			sb.Append(",[PU].[DELI_PLACE_STATE]             AS [DELI_PLACE_STATE]"              );
			sb.Append(",[PU].[DELI_PLACE_CITY]              AS [DELI_PLACE_CITY]"               );
			sb.Append(",[PU].[DELI_PLACE_ADDRESS1]          AS [DELI_PLACE_ADDRESS1]"           );
			sb.Append(",[PU].[DELI_PLACE_ADDRESS2]          AS [DELI_PLACE_ADDRESS2]"           );
			sb.Append(",[PU].[DELI_PLACE_PHONE]             AS [DELI_PLACE_PHONE]"              );
			sb.Append(",[PU].[DELI_PLACE_FAX]               AS [DELI_PLACE_FAX]"                );
			sb.Append(",[PU].[DELI_PLACE_USER_NAME]         AS [DELI_PLACE_USER_NAME]"          );
			sb.Append(",[PU].[DT_TYPE]                      AS [DT_TYPE]"                       );
			sb.Append(",[PU].[DT1_STTL_MTHD_CODE]           AS [DT1_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT1_BASIS_AMT]                AS [DT1_BASIS_AMT]"                 );
			sb.Append(",[PU].[DT2_STTL_MTHD_CODE]           AS [DT2_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT2_RATIO]                    AS [DT2_RATIO]"                     );
			sb.Append(",[PU].[DT3_STTL_MTHD_CODE]           AS [DT3_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT_SIGHT]                     AS [DT_SIGHT]"                      );
			sb.Append(",[PU].[CUTOFF_DATE]                  AS [CUTOFF_DATE]"                   );
// 管理番号 B21977 From
			sb.Append(",[PU].[CUTOFF_DATE]                  AS [CUTOFF_FIN_DATE]"               );
// 管理番号 B21977 To
			sb.Append(",[PU].[PYMT_PLAN_DATE]               AS [PYMT_PLAN_DATE]"                );
			sb.Append(",[PU].[DT_NOTE]                      AS [DT_NOTE]"                       );
			sb.Append(",[POX].[DT_CUTOFF_CYCLE_TYPE]        AS [DT_CUTOFF_CYCLE_TYPE]"          );
			sb.Append(",[POX].[DT_CUTOFF_DAY]               AS [DT_CUTOFF_DAY]"                 );
			sb.Append(",[POX].[DT_TERM_MONTH_CNT]           AS [DT_TERM_MONTH_CNT]"             );
			sb.Append(",[POX].[DT_TERM_DAY]                 AS [DT_TERM_DAY]"                   );
// 管理番号 B22191 From
			sb.Append(",[POX].[PO_DATE]                     AS [PO_DATE]"                   );
// 管理番号 B22191 To
// 管理番号K27441 From
			sb.Append(",NULL								AS [PO_DEPT_CODE]"					);
// 管理番号K27441 To
			sb.Append(",[PU].[SUPL_BILL_SLIP_NO]            AS [SUPL_BILL_SLIP_NO]"             );
			sb.Append(",[PU].[CANCELED_ORDER_FLG]           AS [CANCELED_ORDER_FLG]"            );
			sb.Append(",[PU].[OVERSEAS_FLG]                 AS [OVERSEAS_FLG]"                  );
			sb.Append(",[PU].[TENOR_CODE]                   AS [TENOR_CODE]"                    );
			sb.Append(",[PU].[FMONEY_STTL_PERIOD_STT_MONTH] AS [FMONEY_STTL_PERIOD_STT_MONTH]"  );
			sb.Append(",[PU].[FMONEY_STTL_PERIOD_END_MONTH] AS [FMONEY_STTL_PERIOD_END_MONTH]"  );
			sb.Append(",[PU].[LC_NO]                        AS [LC_NO]"                         );
// 管理番号 B13878 From
			sb.Append(",[PU].[HOLD_FLG]						AS [HOLD_FLG]"						);
// 管理番号 B13878 To
			sb.Append(",NULL                                AS [REMARKS_CODE]"                  );
			sb.Append(",NULL                                AS [REMARKS]"                       );
// 管理番号 B13798 From
			sb.Append(",[PU].[ADMIN_ITEM1]                  AS [ADMIN_ITEM1]"                   );
			sb.Append(",[PU].[ADMIN_ITEM2]                  AS [ADMIN_ITEM2]"                   );
			sb.Append(",[PU].[ADMIN_ITEM3]                  AS [ADMIN_ITEM3]"                   );
// 管理番号 B13798 To
// 管理番号 K20687 From
			sb.Append(",[PU].[BOOK_BASIS_TYPE]				AS [BOOK_BASIS_TYPE]"				);
// 管理番号 K20687 To
// 管理番号K27058 From
			sb.Append(",[PU].[BOOK_BASIS_TYPE_DTIL_CODE]	AS [BOOK_BASIS_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			sb.Append(",[PU].[OUTLAND_REMITTANCE_FLG]       AS [OUTLAND_REMITTANCE_FLG]"        );
			sb.Append(",[PU].[INTERNATIONAL_ITEM_NO]        AS [INTERNATIONAL_ITEM_NO]"         );
			sb.Append(",[PU].[REMITTANCE_PURPOSE]           AS [REMITTANCE_PURPOSE]"            );
			sb.Append(",[PU].[REMITTANCE_ALLOW_FLG]         AS [REMITTANCE_ALLOW_FLG]"          );
			sb.Append(",[PU].[REMITTANCE_ALLOW_NO]          AS [REMITTANCE_ALLOW_NO]"           );
			sb.Append(",[PU].[REMITTANCE_MESSAGE]           AS [REMITTANCE_MESSAGE]"            );
// 管理番号 B13500 From
			sb.Append(",[PU].[RCPT_INPUT_NO_NEED_FLG]		AS [RCPT_INPUT_NO_NEED_FLG]"		);
// 管理番号 B13500 To
			sb.Append(",[PU].[APPROVAL_STATUS_TYPE]         AS [APPROVAL_STATUS_TYPE]"          );
// 管理番号 K20685 From
			sb.Append(",'0'                                 AS [APPROVAL_CANCEL_FLG]"           );
// 管理番号 K20685 To
			sb.Append(",'0'                                 AS [PU_SLIP_OUTPUT_FLG]"            );
			sb.Append(",[PU].[ETAX_DTIL_AMT_TTL]            AS [ETAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[ITAX_DTIL_AMT_TTL]            AS [ITAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[NTAX_DTIL_AMT_TTL]            AS [NTAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[ETAX_AMT_TTL]                 AS [ETAX_AMT_TTL]"                  );
			sb.Append(",[PU].[ITAX_AMT_TTL]                 AS [ITAX_AMT_TTL]"                  );
			sb.Append(",[PU].[GRAND_TTL]                    AS [GRAND_TTL]"                     );
			sb.Append(",[PU].[KEY_GRAND_TTL]                AS [KEY_GRAND_TTL]"                 );
			sb.Append(",0                                   AS [KO_AMT]"                        );
			sb.Append(",NULL                                AS [LAST_KO_DATE]"                  );
			sb.Append(",'0'                                 AS [KO_COMPLETE_FLG]"               );
// 管理番号 K16187 From
			sb.Append(",0                                   AS [APPROVED_KO_AMT]"               );
			sb.Append(",'0'                                 AS [DTIL_KO_FLG]"                   );
			sb.Append(",'0'                                 AS [DELETE_ALLOW_FLG]");
// 管理番号 K16187 To
			sb.Append(",0                                   AS [EXCHANGE_GAIN_LOSS_AMT_TTL]"    );
			sb.Append(",NULL                                AS [LAST_EXCHANGE_VALUATION_DATE]"  );
			sb.Append(",'0'                                 AS [EXCHANGE_VALUATION_FIN_FLG]"    );
			sb.Append(",NULL                                AS [PYMT_NO]"                       );
			sb.Append(",'0'                                 AS [CUTOFF_FIN_FLG]"                );
			sb.Append(",'0'                                 AS [CANCEL_FLG]"                    );
			sb.Append(",'0'                                 AS [RED_SLIP_FLG]"                  );
			sb.Append(",NULL                                AS [ORIGIN_PU_NO]"                  );
			sb.Append(",NULL                                AS [OPPOSITE_PU_NO]"                );
			sb.Append(",NULL                                AS [LAST_JRNL_EXEC_DATETIME]"       );
			sb.Append(",'0'                                 AS [JRNL_FIN_FLG]"                  );
// 管理番号 B20818 From
//			sb.Append(",NULL                                AS [PRG_UPDATE_DATETIME]"           );
			sb.Append(",GETDATE()                           AS [PRG_UPDATE_DATETIME]"           );
			sb.Append(",CASE ");
			sb.Append("   WHEN [PU].[PO_NO] IS NOT NULL THEN ISNULL([POX].[PRG_UPDATE_DATETIME],GETDATE()) ");
			sb.Append("   WHEN [PU].[PU_NO] IS NOT NULL THEN ISNULL([PU].[PRG_UPDATE_DATETIME],GETDATE()) ");
			sb.Append("   ELSE GETDATE()");
			sb.Append(" END AS [REF_PRG_UPDATE_DATETIME] ");
// 管理番号 B20818 To
// 管理番号 K22205 From
            sb.Append(",NULL                                AS [INPUT_EMP_CODE]"                );
// 管理番号 K22205 To
			sb.Append(",[S].[SO_NO]                         AS [SO_NO]"                         );
			sb.Append(",[S].[SO_DATE]                       AS [SO_DATE]"                       );
			sb.Append(",[S].[CUST_SHORT_NAME]               AS [CUST_SHORT_NAME]"               );
// 管理番号 B13569 From
			sb.Append(",CASE [PU].[EXCHANGE_TYPE] WHEN '1' THEN '1' ELSE '0' END AS [REF_PO_EXCHANGE_TYPE]");
// 管理番号 B13569 To
// 管理番号 K24789 From
//// 管理番号 K24278 From
//			sb.Append(",[COMP].[CTAX_FRACTION_ROUND_TYPE]	AS [CTAX_FRACTION_ROUND_TYPE]"		);
//			sb.Append(",[SUPL].[CTAX_IMPOSE_FLG]			AS [CTAX_IMPOSE_FLG]"				);
//// 管理番号 K24278 To
			sb.Append(",[PU].[CTAX_IMPOSE_FLG]              AS [CTAX_IMPOSE_FLG]"               );
			sb.Append(",[PU].[CTAX_BUILDUP_TYPE]            AS [CTAX_BUILDUP_TYPE]"             );
			sb.Append(",[PU].[CTAX_FRACTION_ROUND_TYPE]     AS [CTAX_FRACTION_ROUND_TYPE]"      );
// 管理番号 K24789 To
// 管理番号 K25679 From
			sb.Append(",[PU].[PO_ADMIN_NO]                  AS [PO_ADMIN_NO]"                   );
			sb.Append(",NULL                                AS [SUPL_SLIP_NO]"                  );
// 管理番号 K25679 To
// 管理番号 K25680 From
			sb.Append(",NULL                                AS [IMPORT_SLIP_NO]"                );
// 管理番号 K25680 To
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputHead, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PU", null, null, null);
// 管理番号K27057 To
// 管理番号K27154 From
			sb.Append(",[PU].[DEAL_TYPE_CODE]				AS [DEAL_TYPE_CODE]");
// 管理番号K27154 To
			//仕入
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			//発注
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(" AS [POX]");
			sb.Append(" ON [PU].[PO_NO] = [POX].[PO_NO]");
			//受注
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SO]")).Append(" AS [S]");
			sb.Append(" ON	[POX].[SO_NO] = [S].[SO_NO]");
			sb.Append(" AND	[S].[DELETE_FLG] <> '1'");
			//組織図、組織変更
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHART]")).Append(" AS [O]");
			sb.Append(" ON	[PU].[DEPT_CODE] = [O].[DEPT_CODE]");
			sb.Append(" AND	[O].[ORG_CHANGE_ID] = ");
			sb.Append("(");
			sb.Append(" SELECT MAX([ORG_CHANGE].[ORG_CHANGE_ID]) FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHANGE]"));
			sb.Append(" [ORG_CHANGE] ");
// 管理番号 B12528 From
//			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= [PU].[PU_DATE] ");
			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= CASE WHEN [PU].[PU_DATE] < GETDATE() THEN GETDATE() ELSE [PU].[PU_DATE] END");
// 管理番号 B12528 To
			sb.Append(")");
// 管理番号 B14315 From
			//入荷
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");
			sb.Append(" ON  [PU].[PU_NO] = [RCPT].[PU_NO] ");
// 管理番号 B14315 To
// 管理番号 B17566 From
			sb.Append(" AND [RCPT].[DELETE_FLG] <> '1' ");
// 管理番号 B17566 To
// 管理番号 K24789 From
//// 管理番号 K24278 From
//			//取引先
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[COMP]")).Append(" AS [COMP]");
//			sb.Append(" ON  [PU].[SUPL_CODE] = [COMP].[COMP_CODE] ");
//			//仕入先
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]")).Append(" AS [SUPL]");
//			sb.Append(" ON  [PU].[SUPL_CODE] = [SUPL].[SUPL_CODE] ");
//			sb.Append(" AND [PU].[SUPL_SBNO] = [SUPL].[SUPL_SBNO] ");
//// 管理番号 K24278 To
// 管理番号 K24789 To

			wpb.AddFilter("[PU].[PU_NO]"				, SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[PU].[OVERSEAS_FLG]"			, SearchOperator.Equal, keyColumn.OverseasFlg);		//海外フラグ
			//返品時
			wpb.AddFilter("[PU].[PU_MODE_TYPE]"			, SearchOperator.Equal, "1");						//仕入形態区分
			wpb.AddFilter("[PU].[APPROVAL_STATUS_TYPE]"	, SearchOperator.Equal, "3");						//承認状況は決済のみ
			wpb.AddFilter("[PU].[OPPOSITE_PU_NO]"		, SearchOperator.Equal, System.DBNull.Value);		//相手仕入番号
			sb.Append(wpb);

			//自部門のみの権限の場合
			if (keyColumn.DisclosureUnitType == "D")
			{
				sb.Append(" AND EXISTS (SELECT [DEPT_CODE] FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetLowerDeptLevel](@DeptCode, @Date)"));
				sb.Append(" [TEMP_DEPTLEVEL] WHERE [PU].[DEPT_CODE] = [TEMP_DEPTLEVEL].[DEPT_CODE])");
			}

			return new SqlCommandWrapper(sb.ToSqlPString(),cn);	// 管理番号K27230
		}
		//仕入明細（返品・他返品伝票なし）
		private static SqlPString CreatePuRefDetailString(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			string prodSpec1Name = string.Empty;
			string prodSpec2Name = string.Empty;
			string unitShortName = string.Empty;

			switch (keyColumn.OverseasFlg)
			{
				case OverseasFlg.DOMESTIC:
					prodSpec1Name = "PROD_SPEC_1_NAME";
					prodSpec2Name = "PROD_SPEC_2_NAME";
					unitShortName = "UNIT_SHORT_NAME";
					break;
				case OverseasFlg.OVERSEAS:
					prodSpec1Name = "PROD_SPEC_1_ENG_NAME";
					prodSpec2Name = "PROD_SPEC_2_ENG_NAME";
					unitShortName = "UNIT_ENG_NAME";
					break;
			}

			//在庫管理部門の取得
			sb.Append("DECLARE @STOCK_ADMIN_DEPT_CODE NVARCHAR(10) ");
			sb.Append("SELECT ");
			sb.Append("  @STOCK_ADMIN_DEPT_CODE = ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SC_MS_GetStockDeptCode]"));
			sb.Append("(@MYCOMP_CODE, [DEPT_CODE], GETDATE())");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]"));
			wpb.AddFilter("[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo );
			sb.Append(wpb);

// 管理番号 B11723・B11796 From
			sb.Append(@"
DECLARE @CUR_DIGIT      DECIMAL(1,0)
DECLARE @CUR_ROUND_TYPE NVARCHAR(1)
DECLARE @AMT_ROUND_TYPE NVARCHAR(1)

SELECT
	 @CUR_ROUND_TYPE = [MC].[CUR_FRACTION_ROUND_TYPE]
	,@AMT_ROUND_TYPE = [MC].[AMT_TTL_FRACTION_ROUND_TYPE]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[MYCOMP]")).Append(@" AS [MC]
WHERE [MC].[MYCOMP_CODE] = @MYCOMP_CODE

SELECT @CUR_DIGIT = [C].[DECIMAL_DIGIT]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(@" AS [PU]
INNER JOIN ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CUR]")).Append(@" AS [C]
	ON [PU].[CUR_CODE] = [C].[CUR_CODE]
WHERE [PU].[PU_NO] = @SLIP_NO
");
// 管理番号 B11723・B11796 To

			wpb = new WherePhraseBuilder();

			sb.Append("SELECT ");
			sb.Append(" [PD].[PU_LINE_ID]                         AS [PU_LINE_ID]"                );
			sb.Append(",[PD].[PU_LINE_NO]                         AS [PU_LINE_NO]"                );
			sb.Append(",[PD].[PO_NO]                              AS [PO_NO]"                     );
			sb.Append(",[PD].[PO_LINE_ID]                         AS [PO_LINE_ID]"                );
// 管理番号 B14315 From
//			sb.Append(",[PD].[RCPT_NO]                            AS [RCPT_NO]"                   );
//			sb.Append(",[PD].[RCPT_LINE_ID]                       AS [RCPT_LINE_ID]"              );
			if(keyColumn.OverseasFlg == "0")
			{
				sb.Append(",[PD].[RCPT_NO]                        AS [RCPT_NO]"                   );
				sb.Append(",[PD].[RCPT_LINE_ID]                   AS [RCPT_LINE_ID]"              );
			}
			else
			{
				sb.Append(",[RD].[RCPT_NO]                        AS [RCPT_NO]"                   );
				sb.Append(",[RD].[RCPT_LINE_ID]                   AS [RCPT_LINE_ID]"              );
			}
// 管理番号 B14315 From
			sb.Append(",[PD].[SA_NO]                              AS [SA_NO]"                     );
			sb.Append(",[PD].[SA_LINE_ID]                         AS [SA_LINE_ID]"                );
			sb.Append(",[PD].[WH_CODE]                            AS [WH_CODE]"                   );
			sb.Append(",[W].[WH_SHORT_NAME]                       AS [WH_SHORT_NAME]"             );
			sb.Append(",[PD].[PROD_CODE]                          AS [PROD_CODE]"                 );
// 管理番号 B19475 From			
//			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_PO_NAME]"              );
			sb.Append(",[PD].[PROD_PO_NAME]						  AS [PROD_PO_NAME]"              );
// 管理番号 B19475 To						
			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_SHORT_NAME]"           );
			sb.Append(",[PD].[PROD_PO_NAME]                       AS [PROD_NAME]"                 );
			sb.Append(",[PD].[PROD_TYPE]                          AS [PROD_TYPE]"                 );
			sb.Append(",[PROD].[DISP_CONTROL_TYPE]                AS [DISP_CONTROL_TYPE]"         );
			sb.Append(",[PROD].[STOCK_ADMIN_FLG]                  AS [STOCK_ADMIN_FLG]"           );
			sb.Append(",[PROD].[LOT_ADMIN_FLG]                    AS [LOT_ADMIN_FLG]"             );
// 管理番号 K25322 From
			sb.Append(",[PROD].[LOT_STOCK_VALUATION_FLG]          AS [LOT_STOCK_VALUATION_FLG]"   );
// 管理番号 K25322 To
			sb.Append(",[U].[QT_DECIMAL_USE_FLG]                  AS [QT_DECIMAL_USE_FLG]"        );
			sb.Append(",[PD].[CTAX_CALC_TYPE]                     AS [CTAX_CALC_TYPE]"            );
// 管理番号 K24789 From
//// 管理番号 B24787 From
////// 管理番号 B18904 From
//////			sb.Append(",[PROD].[CTAX_RATE_CODE]                   AS [CTAX_RATE_CODE]"            );
////			if(keyColumn.OverseasFlg == "1")
////			{
////				sb.Append(",'0'									  AS [CTAX_RATE_CODE]"            );
////			}
////			else
////			{
////				sb.Append(",[PROD].[CTAX_RATE_CODE]               AS [CTAX_RATE_CODE]"            );
////			}
////// 管理番号 B18904 To
//			sb.Append(",[PROD].[CTAX_RATE_CODE]                   AS [CTAX_RATE_CODE]"            );
//// 管理番号 B24787 To
			sb.Append(",[PD].[CTAX_TYPE_CODE]                     AS [CTAX_TYPE_CODE]"            );
			sb.Append(",[PD].[CTAX_RATE_CODE]                     AS [CTAX_RATE_CODE]"            );
// 管理番号 K24789 To
			sb.Append(",[PD].[CTAX_RATE]                          AS [CTAX_RATE]"                 );
			sb.Append(",[PD].[PROD_SPEC_1_CODE]                   AS [PROD_SPEC_1_CODE]"          );
			sb.Append(",[PS1].[").Append(prodSpec1Name).Append("] AS [PROD_SPEC_1_NAME]"          );
			sb.Append(",[PD].[PROD_SPEC_2_CODE]                   AS [PROD_SPEC_2_CODE]"          );
			sb.Append(",[PS2].[").Append(prodSpec2Name).Append("] AS [PROD_SPEC_2_NAME]"          );
			sb.Append(",[PD].[PU_PLAN_PRICE]                      AS [PU_PLAN_PRICE]"             );
			sb.Append(",[PD].[STOCK_UNIT_STD_SELL_PRICE]          AS [STOCK_UNIT_STD_SELL_PRICE]" );
			sb.Append(",[PD].[UNIT_CODE]                          AS [UNIT_CODE]"                 );
			sb.Append(",[U].[").Append(unitShortName).Append("]   AS [UNIT_SHORT_NAME]"           );
// 管理番号  B14315 From
//			sb.Append(",[PD].[PU_QT]                              AS [PU_QT]"                     );
			sb.Append(", CASE WHEN [PU].[RCPT_INPUT_NO_NEED_FLG] = '1' THEN "                     );
			sb.Append("  [PD].[PU_QT] "                                                           );
			sb.Append("  ELSE "                                                                   );
			sb.Append("  [PD].[TRANSIT_RCPT_QT] "                                                 );
			sb.Append("  END AS [PU_QT]"                                                          );
// 管理番号  B14315 To
			sb.Append(",[PD].[PU_QT]                              AS [INIT_PU_QT]"                );
// 管理番号  B14315 From
			sb.Append(", CASE WHEN [PU].[PU_MODE_TYPE] = '2' THEN "                               );
			sb.Append("  0 "                                                                      );
			sb.Append("  ELSE "                                                                   );
			sb.Append("  [PD].[TRANSIT_RCPT_QT] "                                                 );
			sb.Append("  END AS [TRANSIT_RCPT_QT]"                                                );
// 管理番号  B14315 To
			sb.Append(",[PD].[RCPT_INPUT_NO_NEED_FLG]             AS [RCPT_INPUT_NO_NEED_FLG]"    );

			//1. 仕入数量上限値の設定ここから
// 管理番号  B14315 From
//			sb.Append(",[PD].[PU_QT]                              AS [UPPER_LIMIT_PU_QT] "        );
			sb.Append(", CASE WHEN [PU].[RCPT_INPUT_NO_NEED_FLG] = '1' THEN "                     );
			sb.Append("  [PD].[PU_QT] "                                                           );
			sb.Append("  ELSE "                                                                   );
			sb.Append("  [PD].[TRANSIT_RCPT_QT] "                                                 );
			sb.Append("  END AS [UPPER_LIMIT_PU_QT]"                                              );
			//1. 売上数量上限値の設定ここまで
// 管理番号  B14315 To

			sb.Append(",ISNULL([ST].[VALID_QT],0)                 AS [VALID_QT]"                  );
			sb.Append(",[PD].[STOCK_UNIT_PU_QT]                   AS [STOCK_UNIT_PU_QT]"          );

			//2. 在庫単位受注仕入数量の設定ここから
			//返品時(元の仕入伝票を参照)上限は参照した在庫単位受注売上数量
			sb.Append(",[PD].[STOCK_UNIT_PO_PU_QT]                AS [STOCK_UNIT_PO_PU_QT]"       );
			//2. 在庫単位受注売上数量の設定ここまで

			sb.Append(",0                                         AS [STOCK_UNIT_PO_ALLOC_PU_QT]" );
			sb.Append(",[PD].[PU_PRICE]                           AS [PU_PRICE]"                  );
			sb.Append(",[PD].[PU_PRICE]                           AS [INIT_PU_PRICE]"             );
			sb.Append(",[PD].[DISC_FLG]                           AS [DISC_FLG]"                  );
// 管理番号 B13878 From
			sb.Append(",[PD].[PRICE_UNDECIDED_FLG]				  AS [PRICE_UNDECIDED_FLG]"		  );
// 管理番号 B13878 To
			sb.Append(",NULL                                      AS [LINE_REMARKS_CODE]"         );
			sb.Append(",NULL                                      AS [LINE_REMARKS]"              );
// 管理番号K27525 From
			sb.Append(",[PD].[BOOK_DEDUCTION_REASON_CODE]         AS [BOOK_DEDUCTION_REASON_CODE]");
			sb.Append(",[BDR].[BOOK_DEDUCTION_REASON_NAME]        AS [BOOK_DEDUCTION_REASON_NAME]");
// 管理番号K27525 To
// 管理番号 K16671 From
			sb.Append(",NULL                                      AS [REF_CODE]"                  );
// 管理番号 K16671 To
			sb.Append(",[U].[INCLUDE_QT]                          AS [INCLUDE_QT]"                );
			sb.Append(",[PD].[DTIL_AMT]                           AS [DTIL_AMT]"                  );
			sb.Append(",[PD].[ETAX_AMT]                           AS [ETAX_AMT]"                  );
			sb.Append(",[PD].[ITAX_AMT]                           AS [ITAX_AMT]"                  );
			sb.Append(",'0'                                       AS [PRICE_UPDATE_FLG]"          );
// 管理番号 K24278 From
//// 管理番号 B11723・B11796 From
////			sb.Append(",[PD].[PU_QT] * [PD].[PU_PRICE]            AS [PU_MONEY]"                  );
//			sb.Append(",").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound]"));
//			sb.Append("([PD].[PU_QT] * [PD].[PU_PRICE], @CUR_DIGIT, @AMT_ROUND_TYPE) AS [PU_MONEY]");
//// 管理番号 B11723・B11796 To
			sb.Append(", CASE WHEN @ImposeFlg = '0' AND [PD].[CTAX_CALC_TYPE] = 'I' THEN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound([PD].[PU_PRICE]*[PD].[PU_QT],@CUR_DIGIT,@AMT_ROUND_TYPE) - "));
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound("));
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound([PD].[PU_PRICE]*[PD].[PU_QT],@CUR_DIGIT,@AMT_ROUND_TYPE) * "));
			sb.Append("([PD].[CTAX_RATE]/100)/(1+([PD].[CTAX_RATE]/100)),@CUR_DIGIT, @CtaxRoundType) ELSE ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound([PD].[PU_PRICE]*[PD].[PU_QT],@CUR_DIGIT,@AMT_ROUND_TYPE) END AS [PU_MONEY]"));
// 管理番号 K24278 To
			sb.Append(",[PROD].[PROD_NAME_CORRECT_ALLOW_FLG]      AS [PROD_NAME_CORRECTION_FLG]"  );

			//コピー時は商品変更可能、返品時は商品変更不可
			sb.Append(",'0'                                       AS [PROD_EDIT_FLG]"       );

			//入荷済判定
			sb.Append(",CASE "                                                              );
			sb.Append("     WHEN [PU].[OVERSEAS_FLG] = '1' "                                );
			sb.Append("         THEN '0' "                                                  );
// 管理番号 B24477 From
//			sb.Append("     WHEN [POD].[RCPT_PU_QT] > 0 "                                   );
//			sb.Append("         THEN '1' "                                                  );
//			sb.Append("     ELSE "                                                          );
//			sb.Append("         CASE WHEN [POD].[RCPT_QT] - [POD].[RCPT_RETURN_QT] - [POD].[DIRECT_PU_QT] <> 0 ");
//			sb.Append("             THEN '1' "                                              );
//			sb.Append("             ELSE '0' "                                              );
//			sb.Append("         END "                                                       );
			sb.Append("     WHEN [RCPTED_PU_D].[PU_NO] IS NULL "                            );
			sb.Append("         THEN '0' "                                                  );
			sb.Append("     ELSE '1' "                                                      );
// 管理番号 B24477 To
			sb.Append(" END                                       AS [IS_RCPT_EXECUTE]"     );
			sb.Append(",'R'                                       AS [ROW_STATE]"           );
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputDetail, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PD", "CUSTOM_ITEM_TAG", "@PU_DATE", null, keyColumn.ParamType == "View" || keyColumn.ParamType == "Mod");
// 管理番号K27057 To

			//仕入
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			//仕入明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PD]");
			sb.Append(" ON [PU].[PU_NO] = [PD].[PU_NO]");
// 管理番号 B24477 From
//			//発注明細 入荷済み判定で使用
//			sb.Append(" LEFT OUTER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO_DTIL]")).Append(" AS [POD]");
//			sb.Append(" ON  [PD].[PO_NO]      = [POD].[PO_NO]");
//			sb.Append(" AND [PD].[PO_LINE_ID] = [POD].[PO_LINE_ID]");
			//入荷済仕入判定用サブクエリ
			sb.Append(" LEFT OUTER JOIN (SELECT DISTINCT");
			sb.Append("			[PU_D].[PU_NO]			AS [PU_NO]		");
			sb.Append("			,[PU_D].[PU_LINE_ID]	AS [PU_LINE_ID]	");
			sb.Append("		FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PU_D]");
			sb.Append("			INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_LOT_DTIL]")).Append(" AS [PU_L_D]");
			sb.Append("				ON  [PU_D].[PU_NO]      = [PU_L_D].[PU_NO] "     );
			sb.Append("				AND [PU_D].[PU_LINE_ID] = [PU_L_D].[PU_LINE_ID] ");
			sb.Append("				AND [PU_L_D].[RCPT_NO] IS NOT NULL "             );
			sb.Append(" ) AS [RCPTED_PU_D] ");
			sb.Append(" ON  [PD].[PU_NO]      = [RCPTED_PU_D].[PU_NO] "     );
			sb.Append("	AND [PD].[PU_LINE_ID] = [RCPTED_PU_D].[PU_LINE_ID] ");
// 管理番号 B24477 To

			//商品
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [PROD]");
			sb.Append(" ON  [PD].[PROD_CODE]   = [PROD].[PROD_CODE]");
			sb.Append(" AND [PROD].[PROD_TYPE] = '0' ");//通常商品のみ
			//商品規格1
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_1]")).Append(" AS [PS1]");
			sb.Append(" ON [PD].[PROD_SPEC_1_CODE] = [PS1].[PROD_SPEC_1_CODE]");
			//商品規格2
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_2]")).Append(" AS [PS2]");
			sb.Append(" ON [PD].[PROD_SPEC_2_CODE] = [PS2].[PROD_SPEC_2_CODE]");
			//倉庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[WH]")).Append(" AS [W]");
			sb.Append(" ON [PD].[WH_CODE] = [W].[WH_CODE]");
			//単位別商品属性
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
			sb.Append(" ON [PD].[PROD_CODE] = [U].[PROD_CODE]");
			sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE] ");
			//在庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[STOCK]")).Append(" AS [ST]");
			sb.Append(" ON  [PD].[WH_CODE]          = [ST].[WH_CODE] ");
			sb.Append(" AND [PD].[PROD_CODE]        = [ST].[PROD_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [ST].[PROD_SPEC_1_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [ST].[PROD_SPEC_2_CODE] ");
			sb.Append(" AND [ST].[DEPT_CODE]        = @STOCK_ADMIN_DEPT_CODE ");
// 管理番号 B13877 From
			if (keyColumn.ProjectStockAdminUseFlg)
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ISNULL([PU].[PROJ_CODE],'')");
				sb.Append(" AND [ST].[PROJ_SBNO] = ISNULL([PU].[PROJ_SBNO],'')");
			}
			else
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ''");
				sb.Append(" AND [ST].[PROJ_SBNO] = ''");
			}
// 管理番号 B13877 To
// 管理番号K27525 From
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[BOOK_DEDUCTION_REASON]")).Append(" AS [BDR]");
			sb.Append(" ON [BDR].[BOOK_DEDUCTION_REASON_CODE] = [PD].[BOOK_DEDUCTION_REASON_CODE] ");
// 管理番号K27525 To
// 管理番号 B14315 From
			//入荷
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD]");
			sb.Append(" ON  [PD].[PU_NO] = [RD].[PU_NO] ");
			sb.Append(" AND  [PD].[PU_LINE_ID] = [RD].[PU_LINE_ID] ");
// 管理番号 B17566 From
			sb.Append(" AND [RD].[DELETE_FLG] <> '1' ");
// 管理番号 B17566 To
// 管理番号 B14315 To

			wpb.AddFilter("[PD].[PU_NO]", SearchOperator.Equal, keyColumn.SlipNo);
// 管理番号 K24285 From
//			wpb.AddFilter("[PD].[PU_QT]", SearchOperator.GreaterThan, 0);
			wpb.AddFilter("[PD].[PU_QT]", SearchOperator.NotEqual, 0);
// 管理番号 K24285 To
			sb.Append(wpb);
			sb.Append("ORDER BY [PD].[PU_LINE_NO] ASC ");

			return sb.ToSqlPString();	// 管理番号K27230
		}
		//仕入ロット明細（返品・他返品伝票なし）
		private static string CreatePuRefLotDetailString(CommonData commonData,IF_SC_MM_05_KeyColumn keyColumn, bool rcptInputNoNeedFlg)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();

// 管理番号 B14315 From
			if(rcptInputNoNeedFlg)
			{
// 管理番号 B14315 To
				//仕入コピー、仕入参照(他伝票なし)、修正モード
				sb.Append("SELECT ");
				sb.Append(" [P_L_D].[PU_LINE_ID]          AS [ROW_ID]      ,");
				sb.Append(" [P_L_D].[LOT_NO]              AS [LOT_NO]      ,");
				sb.Append(" [LOT].[FAB_DATE]              AS [FAB_DATE]    ,");
// 管理番号 B22625 From
//				sb.Append(" DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE]) AS [TERM_DATE],");
				sb.Append(" CASE WHEN CONVERT(DATETIME,'9998/12/31') - [LOT].[FAB_DATE] < [P].[LOT_VALID_TERM_DAY_CNT]-1");
				sb.Append(   " THEN CONVERT(DATETIME,'9998/12/31')");
				sb.Append(   " ELSE DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE])");
				sb.Append(" END AS [TERM_DATE] ,");
// 管理番号 B22625 To
				sb.Append(" [P_L_D].[PU_LOT_ID]           AS [LOT_ID]      ,");
				sb.Append(" '1'                           AS [STOCK_TYPE]  ,");
				sb.Append(" 0                             AS [STOCK_QT]    ,");
				sb.Append(" [P_L_D].[PU_QT]               AS [INIT_QT]     ,");
				sb.Append(" [P_L_D].[PU_QT]               AS [EDIT_QT]     ,");
				sb.Append(" 0                             AS [TRANSIT_RCPT_QT],");
				sb.Append(" [P_L_D].[RCPT_NO]             AS [RCPT_NO]     ,");
				sb.Append(" [P_L_D].[RCPT_LINE_ID]        AS [RCPT_LINE_ID],");
				sb.Append(" [P_L_D].[RCPT_LOT_ID]         AS [RCPT_LOT_ID] ,");
				sb.Append(" NULL                          AS [SA_NO]       ,");
				sb.Append(" NULL                          AS [SA_LINE_ID]  ,");
				sb.Append(" NULL                          AS [SA_LOT_ID]    ");
// 管理番号 K25322 From
				sb.Append(",0                             AS [PO_ALLOC_RCPT_QT] ");　//在庫単位発注引当仕入数量
// 管理番号 K25322 To

				//仕入
				sb.Append(" FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
				//仕入明細
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PD]");
				sb.Append(" ON  [PU].[PU_NO] = [PD].[PU_NO] ");
				//仕入ロット明細
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_LOT_DTIL]")).Append(" AS [P_L_D]");
				sb.Append(" ON  [PD].[PU_NO]      = [P_L_D].[PU_NO] ");
				sb.Append(" AND [PD].[PU_LINE_ID] = [P_L_D].[PU_LINE_ID] ");
				sb.Append(" AND (([P_L_D].[RCPT_NO] IS NOT NULL) OR ([P_L_D].[RCPT_NO] IS NULL AND [P_L_D].[LOT_NO] <> '9'))");
				//入荷
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");
				sb.Append(" ON  [P_L_D].[RCPT_NO] = [RCPT].[RCPT_NO] ");
// 管理番号 B17566 From
				sb.Append(" AND [RCPT].[DELETE_FLG] <> '1' ");
// 管理番号 B17566 To
				//商品
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [P]");
				sb.Append(" ON  [PD].[PROD_CODE] = [P].[PROD_CODE] ");
				//ロット
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[LOT]")).Append(" AS [LOT]");
				sb.Append(" ON  [PD].[PROD_CODE]        = [LOT].[PROD_CODE] ");
				sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [LOT].[PROD_SPEC_1_CODE] ");
				sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [LOT].[PROD_SPEC_2_CODE] ");
				sb.Append(" AND [P_L_D].[LOT_NO]        = [LOT].[LOT_NO] ");

				//単位別商品属性
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
				sb.Append(" ON  [PD].[PROD_CODE] = [U].[PROD_CODE] ");
				sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE]");

				wpb.AddFilter("[PU].[PU_NO]"   , SearchOperator.Equal, keyColumn.SlipNo);
// 管理番号 K24285 From
//				wpb.AddFilter("[P_L_D].[PU_QT]", SearchOperator.GreaterThan, 0);
				wpb.AddFilter("[P_L_D].[PU_QT]", SearchOperator.NotEqual, 0);
// 管理番号 K24285 To
//// 管理番号 B17566 From
//				wpb.AddFilter("[RCPT].[DELETE_FLG]", SearchOperator.NotEqual, "1");
//// 管理番号 B17566 To
				sb.Append(wpb);
				sb.Append("ORDER BY [LOT].[FAB_DATE] ASC, [P_L_D].[PU_LOT_ID] ASC, [RCPT].[RCPT_DATE] ASC, [P_L_D].[RCPT_NO] ASC");
			}
			else
			{
				sb.Append("SELECT ");
// 管理番号 B18394 From
				//sb.Append(" [R_L_D].[RCPT_LINE_ID]        AS [ROW_ID]      ,");
				if(keyColumn.OverseasFlg == "0")
				{
					sb.Append(" [R_L_D].[RCPT_LINE_ID]        AS [ROW_ID]      ,");
				}
				else
				{
					sb.Append(" [R_L_D].[PU_LINE_ID]          AS [ROW_ID]      ,");
				}
// 管理番号 B18394 To
				sb.Append(" [R_L_D].[LOT_NO]              AS [LOT_NO]      ,");
				sb.Append(" [LOT].[FAB_DATE]              AS [FAB_DATE]    ,");
// 管理番号 B22625 From
//				sb.Append(" DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE]) AS [TERM_DATE],");
				sb.Append(" CASE WHEN CONVERT(DATETIME,'9998/12/31') - [LOT].[FAB_DATE] < [P].[LOT_VALID_TERM_DAY_CNT]-1");
				sb.Append(   " THEN CONVERT(DATETIME,'9998/12/31')");
				sb.Append(   " ELSE DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE])");
				sb.Append(" END AS [TERM_DATE] ,");
// 管理番号 B22625 To
				sb.Append(" [R_L_D].[RCPT_LOT_ID]         AS [LOT_ID]      ,");
				sb.Append(" '1'                           AS [STOCK_TYPE]  ,");
				sb.Append(" 0                             AS [STOCK_QT]    ,");
				sb.Append(" [R_L_D].[RCPT_QT]             AS [INIT_QT]     ,");
				sb.Append(" [R_L_D].[RCPT_QT]             AS [EDIT_QT]     ,");
				sb.Append(" [R_L_D].[RCPT_QT]             AS [TRANSIT_RCPT_QT],");
				sb.Append(" [R_L_D].[RCPT_NO]             AS [RCPT_NO]     ,");
				sb.Append(" [R_L_D].[RCPT_LINE_ID]        AS [RCPT_LINE_ID],");
				sb.Append(" [R_L_D].[RCPT_LOT_ID]         AS [RCPT_LOT_ID] ,");
				sb.Append(" [P_L_D].[SA_NO]               AS [SA_NO]       ,");
				sb.Append(" [P_L_D].[SA_LINE_ID]          AS [SA_LINE_ID]  ,");
				sb.Append(" [P_L_D].[SA_LOT_ID]           AS [SA_LOT_ID]    ");
// 管理番号 K25322 From
				sb.Append(",0                             AS [PO_ALLOC_RCPT_QT] ");　//在庫単位発注引当仕入数量
// 管理番号 K25322 To

				//仕入
				sb.Append(" FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
				//仕入明細
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PD]");
				sb.Append(" ON  [PU].[PU_NO] = [PD].[PU_NO] ");
				//仕入ロット明細
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_LOT_DTIL]")).Append(" AS [P_L_D]");
				sb.Append(" ON  [PD].[PU_NO]      = [P_L_D].[PU_NO] ");
				sb.Append(" AND [PD].[PU_LINE_ID] = [P_L_D].[PU_LINE_ID] ");
				sb.Append(" AND (([P_L_D].[RCPT_NO] IS NOT NULL) OR ([P_L_D].[RCPT_NO] IS NULL AND [P_L_D].[LOT_NO] <> '9'))");
				//入荷
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");
				sb.Append(" ON  [PU].[PU_NO] = [RCPT].[PU_NO] ");
				//入荷明細
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD]");
				sb.Append(" ON  [PD].[PU_NO] = [RD].[PU_NO] ");
				sb.Append(" AND  [PD].[PU_LINE_ID] = [RD].[PU_LINE_ID] ");
// 管理番号 B18394 From
				sb.Append(" AND  [RCPT].[RCPT_NO] = [RD].[RCPT_NO] ");
// 管理番号 B18394 To
				//入荷ロット明細
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_LOT_DTIL]")).Append(" AS [R_L_D]");
				sb.Append(" ON  [RD].[RCPT_NO]      = [R_L_D].[RCPT_NO] ");
				sb.Append(" AND [RD].[RCPT_LINE_ID] = [R_L_D].[RCPT_LINE_ID] ");
				//商品
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [P]");
				sb.Append(" ON  [PD].[PROD_CODE] = [P].[PROD_CODE] ");
				//ロット
				sb.Append(" LEFT OUTER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[LOT]")).Append(" AS [LOT]");
				sb.Append(" ON  [PD].[PROD_CODE]        = [LOT].[PROD_CODE] ");
				sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [LOT].[PROD_SPEC_1_CODE] ");
				sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [LOT].[PROD_SPEC_2_CODE] ");
				sb.Append(" AND [R_L_D].[LOT_NO]        = [LOT].[LOT_NO] ");

				//単位別商品属性
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
				sb.Append(" ON  [PD].[PROD_CODE] = [U].[PROD_CODE] ");
				sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE]");

				wpb.AddFilter("[PU].[PU_NO]"   , SearchOperator.Equal, keyColumn.SlipNo);
				wpb.AddFilter("[R_L_D].[RCPT_QT]", SearchOperator.GreaterThan, 0);
				wpb.AddFilter("[RCPT].[DELETE_FLG]", SearchOperator.Equal, 0);
				wpb.AddFilter("[RD].[DELETE_FLG]", SearchOperator.Equal, 0);
				wpb.AddFilter("[R_L_D].[DELETE_FLG]", SearchOperator.Equal, 0);
				sb.Append(wpb);
				sb.Append("ORDER BY [LOT].[FAB_DATE] ASC, [R_L_D].[RCPT_LOT_ID] ASC, [RCPT].[RCPT_DATE] ASC, [R_L_D].[RCPT_NO] ASC");
			}
			return sb.ToString();
		}
		//仕入返品の明細の一時集計テーブル
		private static void CreatePuDtilReturnTempTable(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn, string TEMP_TABLE_NAME)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append(" SELECT ");
			sb.Append(  " [PU_DTIL].[PU_LINE_ID]						AS [PU_LINE_ID]	,");
			sb.Append(  " (SUM([PU_DTIL].[PU_QT]) * -1)					AS [PU_QT]		,");
// 管理番号 B19191 From
			sb.Append(  " (SUM([PU_DTIL].[STOCK_UNIT_PU_QT]) * -1)	AS [STOCK_UNIT_PU_QT],");
// 管理番号 B19191 To
			sb.Append(  " (SUM([PU_DTIL].[STOCK_UNIT_PO_PU_QT]) * -1)	AS [STOCK_UNIT_PO_PU_QT]");
			sb.Append(" INTO " ).Append(TEMP_TABLE_NAME);
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PU_DTIL]");
			sb.Append(" ON [PU].[PU_NO] = [PU_DTIL].[PU_NO] ");

			wpb.AddFilter("[PU].[PU_MODE_TYPE]"  , SearchOperator.Equal, "2");
			wpb.AddFilter("[PU].[REF_PU_NO]"     , SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[PU].[OPPOSITE_PU_NO]", SearchOperator.Equal, DBNull.Value);
			sb.Append(wpb);

			sb.Append(" GROUP BY ");
			sb.Append(" [PU_DTIL].[PU_LINE_ID] ");

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(),cn);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
			cm.ExecuteNonQuery();
			return;
		}
		//仕入返品のロット明細の一時集計テーブル
		private static void CreatePuLotDtilReturnTempTable(CommonData commonData,SqlConnection cn,IF_SC_MM_05_KeyColumn keyColumn, string TEMP_TABLE_NAME)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append(" SELECT ");
			sb.Append(  " [PU_L_D].[PU_LINE_ID]           ," );
			sb.Append(  " [PU_L_D].[PU_LOT_ID]            ," );
			sb.Append(  " (SUM([PU_L_D].[PU_QT]) * -1) AS [PU_QT] " );
			sb.Append(" INTO " ).Append(TEMP_TABLE_NAME);
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_LOT_DTIL]")).Append(" AS [PU_L_D]");
			sb.Append(" ON  [PU].[PU_NO] = [PU_L_D].[PU_NO] ");
			sb.Append(" AND (([PU_L_D].[RCPT_NO] IS NOT NULL) OR ([PU_L_D].[RCPT_NO] IS NULL AND [PU_L_D].[LOT_NO] <> '9'))");

			wpb.AddFilter("[PU].[PU_MODE_TYPE]"  , SearchOperator.Equal, "2");
			wpb.AddFilter("[PU].[REF_PU_NO]"     , SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[PU].[OPPOSITE_PU_NO]", SearchOperator.Equal, DBNull.Value);
			sb.Append(wpb);

			sb.Append(" GROUP BY ");
			sb.Append("   [PU_L_D].[PU_LINE_ID],");
			sb.Append("   [PU_L_D].[PU_LOT_ID]  ");

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(),cn);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
			cm.ExecuteNonQuery();
			return;
		}
		//発注
		private static SqlCommandWrapper CreatePoHeaderCommand(CommonData commonData,SqlConnection cn,IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append("SELECT");
			sb.Append(" NULL                                AS [PU_NO]"                         );
			sb.Append(",[PO].[PO_NAME]                      AS [PU_NAME]"                       );
			sb.Append(",GETDATE()                           AS [PU_DATE]"                       );
// 管理番号 B22191 From
			sb.Append(",[PO].[PO_DATE]                      AS [PO_DATE]"                       );
// 管理番号 B22191 To
// 管理番号 K24789 From
//// 管理番号 K16590 From
//			sb.Append(",GETDATE()                           AS [DEAL_DATE]"                     );
//// 管理番号 K16590 To
			if (keyColumn.DateAdminType == "1")		// 日付管理区分が「取引日管理基準」
			{
				sb.Append(",CASE [PO].[BOOK_BASIS_TYPE] WHEN N'A' ");
				sb.Append("     THEN [PO].[CTAX_BASIS_DATE]"       );
				sb.Append("     ELSE GETDATE() "                   );
				sb.Append("	END                             AS [DEAL_DATE]"                     );
			}
			else
			{
				sb.Append(",GETDATE()                       AS [DEAL_DATE]"                     );
			}
// 管理番号 K24789 To
			sb.Append(",[PO].[PO_NO]                        AS [PO_NO]"                         );
			sb.Append(",NULL                                AS [RCPT_NO]"                       );
			sb.Append(",'1'                                 AS [PU_MODE_TYPE]"                  );
// 管理番号K27058 From
			sb.Append(",[PO].[PO_MODE_TYPE_DTIL_CODE]		AS [PU_MODE_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			sb.Append(",NULL                                AS [REF_PU_NO]"                     );
			sb.Append(",[PO].[CUR_CODE]                     AS [CUR_CODE]"                      );
			sb.Append(",[PO].[EXCHANGE_TYPE]                AS [EXCHANGE_TYPE]"                 );
			sb.Append(",[PO].[EXCHANGE_REZ_NO]              AS [EXCHANGE_REZ_NO]"               );
			sb.Append(",ISNULL([PO].[RATE], '1')            AS [RATE]"                          );
			sb.Append(",[PO].[DEPT_CODE]                    AS [DEPT_CODE]"                     );
			sb.Append(",[O].[DEPT_SHORT_NAME]               AS [DEPT_SHORT_NAME]"               );
			sb.Append(",[PO].[ORIGIN_DEPT_CODE]             AS [ORIGIN_DEPT_CODE]"              );
			sb.Append(",[PO].[OLD_DEPT_CODE]                AS [OLD_DEPT_CODE]"                 );
			sb.Append(",[PO].[ORG_CHANGE_ID]                AS [ORG_CHANGE_ID]"                 );
			sb.Append(",NULL                                AS [DATA_MIGRATE_DATETIME]"         );
			sb.Append(",[PO].[EMP_CODE]                     AS [EMP_CODE]"                      );
			sb.Append(",[PO].[PROJ_CODE]                    AS [PROJ_CODE]"                     );
			sb.Append(",[PO].[PROJ_SBNO]                    AS [PROJ_SBNO]"                     );
			sb.Append(",[PO].[SUPL_CODE]                    AS [SUPL_CODE]"                     );
			sb.Append(",[PO].[SUPL_SBNO]                    AS [SUPL_SBNO]"                     );
			sb.Append(",[PO].[TEMP_CODE_FLG]                AS [TEMP_CODE_FLG]"                 );
			sb.Append(",[PO].[SUPL_NAME]                    AS [SUPL_NAME]"                     );
			sb.Append(",[PO].[SUPL_SHORT_NAME]              AS [SUPL_SHORT_NAME]"               );
			sb.Append(",[PO].[SUPL_DEPT_NAME_1]             AS [SUPL_DEPT_NAME_1]"              );
			sb.Append(",[PO].[SUPL_DEPT_NAME_2]             AS [SUPL_DEPT_NAME_2]"              );
			sb.Append(",[PO].[SUPL_COUNTRY_CODE]            AS [SUPL_COUNTRY_CODE]"             );
			sb.Append(",[PO].[SUPL_ZIP]                     AS [SUPL_ZIP]"                      );
			sb.Append(",[PO].[SUPL_STATE]                   AS [SUPL_STATE]"                    );
			sb.Append(",[PO].[SUPL_CITY]                    AS [SUPL_CITY]"                     );
			sb.Append(",[PO].[SUPL_ADDRESS1]                AS [SUPL_ADDRESS1]"                 );
			sb.Append(",[PO].[SUPL_ADDRESS2]                AS [SUPL_ADDRESS2]"                 );
			sb.Append(",[PO].[SUPL_PHONE]                   AS [SUPL_PHONE]"                    );
			sb.Append(",[PO].[SUPL_FAX]                     AS [SUPL_FAX]"                      );
			sb.Append(",[PO].[SUPL_USER_NAME]               AS [SUPL_USER_NAME]"                );
			sb.Append(",[PO].[AC_NO]                        AS [AC_NO]"                         );
			sb.Append(",[PO].[AC_HOLDER]                    AS [AC_HOLDER]"                     );
			sb.Append(",[PO].[AC_TYPE]                      AS [AC_TYPE]"                       );
			sb.Append(",[PO].[BANK_AC_TYPE]                 AS [BANK_AC_TYPE]"                  );
			sb.Append(",[PO].[BANK_COUNTRY_CODE]            AS [BANK_COUNTRY_CODE]"             );
			sb.Append(",[PO].[BANK_CODE]                    AS [BANK_CODE]"                     );
			sb.Append(",[PO].[BANK_BRANCH_CODE]             AS [BANK_BRANCH_CODE]"              );
			sb.Append(",[PO].[DELI_TYPE]                    AS [DELI_TYPE]"                     );
			sb.Append(",[PO].[WH_CODE]                      AS [WH_CODE]"                       );
			sb.Append(",[PO].[DELI_CUST_CODE]               AS [DELI_CUST_CODE]"                );
			sb.Append(",[PO].[DELI_CUST_SBNO]               AS [DELI_CUST_SBNO]"                );
			sb.Append(",[PO].[DELI_PLACE_CODE]              AS [DELI_PLACE_CODE]"               );
			sb.Append(",[PO].[DELI_PLACE_NAME]              AS [DELI_PLACE_NAME]"               );
			sb.Append(",[PO].[DELI_PLACE_COUNTRY_CODE]      AS [DELI_PLACE_COUNTRY_CODE]"       );
			sb.Append(",[PO].[DELI_PLACE_ZIP]               AS [DELI_PLACE_ZIP]"                );
			sb.Append(",[PO].[DELI_PLACE_STATE]             AS [DELI_PLACE_STATE]"              );
			sb.Append(",[PO].[DELI_PLACE_CITY]              AS [DELI_PLACE_CITY]"               );
			sb.Append(",[PO].[DELI_PLACE_ADDRESS1]          AS [DELI_PLACE_ADDRESS1]"           );
			sb.Append(",[PO].[DELI_PLACE_ADDRESS2]          AS [DELI_PLACE_ADDRESS2]"           );
			sb.Append(",[PO].[DELI_PLACE_PHONE]             AS [DELI_PLACE_PHONE]"              );
			sb.Append(",[PO].[DELI_PLACE_FAX]               AS [DELI_PLACE_FAX]"                );
			sb.Append(",[PO].[DELI_PLACE_USER_NAME]         AS [DELI_PLACE_USER_NAME]"          );
			sb.Append(",[PO].[DT_TYPE]                      AS [DT_TYPE]"                       );
			sb.Append(",[PO].[DT1_STTL_MTHD_CODE]           AS [DT1_STTL_MTHD_CODE]"            );
			sb.Append(",[PO].[DT1_BASIS_AMT]                AS [DT1_BASIS_AMT]"                 );
			sb.Append(",[PO].[DT2_STTL_MTHD_CODE]           AS [DT2_STTL_MTHD_CODE]"            );
			sb.Append(",[PO].[DT2_RATIO]                    AS [DT2_RATIO]"                     );
			sb.Append(",[PO].[DT3_STTL_MTHD_CODE]           AS [DT3_STTL_MTHD_CODE]"            );
			sb.Append(",[PO].[DT_SIGHT]                     AS [DT_SIGHT]"                      );
			sb.Append(",NULL                                AS [CUTOFF_DATE]"                   );
// 管理番号 B21977 From
			sb.Append(",NULL                                AS [CUTOFF_FIN_DATE]"               );
// 管理番号 B21977 To
			sb.Append(",NULL                                AS [PYMT_PLAN_DATE]"                );
			sb.Append(",[PO].[DT_NOTE]                      AS [DT_NOTE]"                       );
			sb.Append(",[PO].[DT_CUTOFF_CYCLE_TYPE]         AS [DT_CUTOFF_CYCLE_TYPE]"          );
			sb.Append(",[PO].[DT_CUTOFF_DAY]                AS [DT_CUTOFF_DAY]"                 );
			sb.Append(",[PO].[DT_TERM_MONTH_CNT]            AS [DT_TERM_MONTH_CNT]"             );
			sb.Append(",[PO].[DT_TERM_DAY]                  AS [DT_TERM_DAY]"                   );
// 管理番号 B22191 From
			sb.Append(",[PO].[PO_DATE]                      AS [PO_DATE]"                       );
// 管理番号 B22191 To
// 管理番号K27441 From
			sb.Append(",NULL								AS [PO_DEPT_CODE]"					);
// 管理番号K27441 To
			sb.Append(",NULL                                AS [SUPL_BILL_SLIP_NO]"             );
			sb.Append(",[PO].[CANCELED_ORDER_FLG]           AS [CANCELED_ORDER_FLG]"            );
			sb.Append(",[PO].[OVERSEAS_FLG]                 AS [OVERSEAS_FLG]"                  );
			sb.Append(",[OV].[TENOR_CODE]                   AS [TENOR_CODE]"                    );
			sb.Append(",[OV].[FMONEY_STTL_PERIOD_STT_MONTH] AS [FMONEY_STTL_PERIOD_STT_MONTH]"  );
			sb.Append(",[OV].[FMONEY_STTL_PERIOD_END_MONTH] AS [FMONEY_STTL_PERIOD_END_MONTH]"  );
			sb.Append(",[OV].[LC_NO]                        AS [LC_NO]"                         );
// 管理番号 B13878 From
			sb.Append(",'0'									AS [HOLD_FLG]"						);
// 管理番号 B13878 To
			sb.Append(",NULL                                AS [REMARKS_CODE]"                  );
// 管理番号 K24274 From
//			sb.Append(",NULL                                AS [REMARKS]"                       );
			sb.Append(",CASE WHEN [SLIP_TYPE].[REMARKS_COORDINATION_TYPE] = '1' ");
			sb.Append("		THEN SUBSTRING([PO].[REMARKS],1,100) ");
			sb.Append("		ELSE NULL ");
			sb.Append("	END AS [REMARKS] ");
// 管理番号 K24274 To
// 管理番号 B13798 From
			sb.Append(",[PO].[ADMIN_ITEM1]                  AS [ADMIN_ITEM1]"                   );
			sb.Append(",[PO].[ADMIN_ITEM2]                  AS [ADMIN_ITEM2]"                   );
			sb.Append(",[PO].[ADMIN_ITEM3]                  AS [ADMIN_ITEM3]"                   );
// 管理番号 B13798 To
// 管理番号 K20687 From
			sb.Append(",CASE WHEN [PO].[OVERSEAS_FLG] = '1' THEN 'A'"							);
			sb.Append(" ELSE [PO].[BOOK_BASIS_TYPE]	END		AS [BOOK_BASIS_TYPE]"				);
// 管理番号 K20687 To
// 管理番号K27058 From
			sb.Append(",[PO].[BOOK_BASIS_TYPE_DTIL_CODE]	AS [BOOK_BASIS_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			sb.Append(",'0'                                 AS [OUTLAND_REMITTANCE_FLG]"        );
			sb.Append(",NULL                                AS [INTERNATIONAL_ITEM_NO]"         );
			sb.Append(",NULL                                AS [REMITTANCE_PURPOSE]"            );
			sb.Append(",'0'                                 AS [REMITTANCE_ALLOW_FLG]"          );
			sb.Append(",NULL                                AS [REMITTANCE_ALLOW_NO]"           );
			sb.Append(",NULL                                AS [REMITTANCE_MESSAGE]"            );
// 管理番号 B13500 From
			sb.Append(",'1'									AS [RCPT_INPUT_NO_NEED_FLG]");
// 管理番号 B13500 To
			sb.Append(",'1'                                 AS [APPROVAL_STATUS_TYPE]"          );
// 管理番号 K20685 From
			sb.Append(",'0'									AS [APPROVAL_CANCEL_FLG]"           );
// 管理番号 K20685 To
			sb.Append(",'0'                                 AS [PU_SLIP_OUTPUT_FLG]"            );
			sb.Append(",0                                   AS [ETAX_DTIL_AMT_TTL]"             );
			sb.Append(",0                                   AS [ITAX_DTIL_AMT_TTL]"             );
			sb.Append(",0                                   AS [NTAX_DTIL_AMT_TTL]"             );
			sb.Append(",0                                   AS [ETAX_AMT_TTL]"                  );
			sb.Append(",0                                   AS [ITAX_AMT_TTL]"                  );
			sb.Append(",0                                   AS [GRAND_TTL]"                     );
			sb.Append(",0                                   AS [KEY_GRAND_TTL]"                 );
			sb.Append(",0                                   AS [KO_AMT]"                        );
			sb.Append(",NULL                                AS [LAST_KO_DATE]"                  );
			sb.Append(",'0'                                 AS [KO_COMPLETE_FLG]"               );
// 管理番号 K16187 From
			sb.Append(",0                                   AS [APPROVED_KO_AMT]"               );
			sb.Append(",'0'                                 AS [DTIL_KO_FLG]"                   );
			sb.Append(",'0'                                 AS [DELETE_ALLOW_FLG]");
// 管理番号 K16187 To
			sb.Append(",0                                   AS [EXCHANGE_GAIN_LOSS_AMT_TTL]"    );
			sb.Append(",NULL                                AS [LAST_EXCHANGE_VALUATION_DATE]"  );
			sb.Append(",'0'                                 AS [EXCHANGE_VALUATION_FIN_FLG]"    );
			sb.Append(",NULL                                AS [PYMT_NO]"                       );
			sb.Append(",'0'                                 AS [CUTOFF_FIN_FLG]"                );
			sb.Append(",'0'                                 AS [CANCEL_FLG]"                    );
			sb.Append(",'0'                                 AS [RED_SLIP_FLG]"                  );
			sb.Append(",NULL                                AS [ORIGIN_PU_NO]"                  );
			sb.Append(",NULL                                AS [OPPOSITE_PU_NO]"                );
			sb.Append(",NULL                                AS [LAST_JRNL_EXEC_DATETIME]"       );
			sb.Append(",'0'                                 AS [JRNL_FIN_FLG]"                  );
// 管理番号 B20818 From
//			sb.Append(",NULL                                AS [PRG_UPDATE_DATETIME]"           );
			sb.Append(",GETDATE()                           AS [PRG_UPDATE_DATETIME]"           );
			sb.Append(",[PO].[PRG_UPDATE_DATETIME]          AS [REF_PRG_UPDATE_DATETIME]"       );
// 管理番号 B20818 To
// 管理番号 K22205 From
            sb.Append(",NULL                                AS [INPUT_EMP_CODE]"                );
// 管理番号 K22205 To
			sb.Append(",[S].[SO_NO]                         AS [SO_NO]"                         );
			sb.Append(",[S].[SO_DATE]                       AS [SO_DATE]"                       );
			sb.Append(",[S].[CUST_SHORT_NAME]               AS [CUST_SHORT_NAME]"               );
// 管理番号 K24153 From
			sb.Append(",[S].[WH_CODE]                       AS [SO_WH_CODE]"                    );
			sb.Append(",[S].[CUST_CODE]                     AS [CUST_CODE]"                     );
			sb.Append(",[S].[CUST_SBNO]                     AS [CUST_SBNO]"                     );
// 管理番号 K24153 To
// 管理番号 B13569 From
			sb.Append(",CASE [PO].[EXCHANGE_TYPE] WHEN '1' THEN '1' ELSE '0' END AS [REF_PO_EXCHANGE_TYPE]");
// 管理番号 B13569 To
// 管理番号 K24278 From
// 管理番号 K24789 From
//			sb.Append(",[COMP].[CTAX_FRACTION_ROUND_TYPE]	AS [CTAX_FRACTION_ROUND_TYPE]"		);
// 管理番号 K24789 To
			sb.Append(",[SUPL].[CTAX_IMPOSE_FLG]			AS [CTAX_IMPOSE_FLG]"				);
// 管理番号 K24278 To
// 管理番号 K24789 From
			sb.Append(",[PYMT_SUPL].[CTAX_BUILDUP_TYPE]         AS [CTAX_BUILDUP_TYPE]"         );
			sb.Append(",[PYMT_SUPL].[CTAX_FRACTION_ROUND_TYPE]  AS [CTAX_FRACTION_ROUND_TYPE]"  );
// 管理番号 K24789 To
// 管理番号 K25679 From
			sb.Append(",[PO].[PO_ADMIN_NO]                  AS [PO_ADMIN_NO]"                   );
			sb.Append(",NULL                                AS [SUPL_SLIP_NO]"                  );
// 管理番号 K25679 To
// 管理番号 K25680 From
			sb.Append(",NULL                                AS [IMPORT_SLIP_NO]"                );
// 管理番号 K25680 To
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputHeadCommon, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PO", null, null, null);
// 管理番号K27057 To
// 管理番号K27154 From
			sb.Append(",[PO].[DEAL_TYPE_CODE]				AS [DEAL_TYPE_CODE]");
// 管理番号K27154 To
			//発注
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(" AS [PO]");
			//受注
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SO]")).Append(" AS [S]");
			sb.Append(" ON	[PO].[SO_NO] = [S].[SO_NO]");
			sb.Append(" AND	[S].[DELETE_FLG] <> '1'");
			//海外発注
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[OVERSEAS_PO]")).Append(" AS [OV]");
			sb.Append(" ON [PO].[PO_NO] = [OV].[PO_NO] ");
			//組織図、組織変更
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHART]")).Append(" AS [O]");
			sb.Append(" ON	[PO].[DEPT_CODE] = [O].[DEPT_CODE]");
			sb.Append(" AND	[O].[ORG_CHANGE_ID] = ");
			sb.Append("(");
			sb.Append(" SELECT MAX([ORG_CHANGE].[ORG_CHANGE_ID]) FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHANGE]"));
			sb.Append(" [ORG_CHANGE] ");
// 管理番号 B12528 To
//			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= [PO].[PO_DATE] ");
			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= GETDATE()");
// 管理番号 B12528 To
			sb.Append(")");
// 管理番号 K24274 From
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SLIP_TYPE]"));
			sb.Append(" ON [SLIP_TYPE].[SLIP_TYPE_CODE] = 'SM3' ");
// 管理番号 K24274 To
// 管理番号 K24278 From
// 管理番号 K24789 From
//			//取引先
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[COMP]")).Append(" AS [COMP]");
//			sb.Append(" ON  [PO].[SUPL_CODE] = [COMP].[COMP_CODE] ");
// 管理番号 K24789 To
			//仕入先
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]")).Append(" AS [SUPL]");
			sb.Append(" ON  [PO].[SUPL_CODE] = [SUPL].[SUPL_CODE] ");
			sb.Append(" AND [PO].[SUPL_SBNO] = [SUPL].[SUPL_SBNO] ");
// 管理番号 K24278 To
// 管理番号 K24789 From
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]")).Append(" AS [PYMT_SUPL]");
			sb.Append(" ON  [SUPL].[PYMT_SUPL_CODE] = [PYMT_SUPL].[SUPL_CODE] ");
			sb.Append(" AND [SUPL].[PYMT_SUPL_SBNO] = [PYMT_SUPL].[SUPL_SBNO] ");
// 管理番号 K24789 To

			wpb.AddFilter("[PO].[PO_NO]"     , SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[PO].[APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "3");
			wpb.AddFilter("[PO].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpb.AddFilter("[PO].[POST_TYPE]", SearchOperator.Equal, "1");

// 管理番号 B18702 From
			if(keyColumn.OverseasFlg == "1")
			{
				// 海外発注の場合
				wpb.AddFilter("[PO].[OVERSEAS_FLG]", SearchOperator.Equal, "1");

			}
// 管理番号 B18702 To
// 管理番号 B18703 From
			else
			{
				// 国内発注の場合
				wpb.AddFilter("[PO].[OVERSEAS_FLG]", SearchOperator.NotEqual, "1");
			}
// 管理番号 B18703 To

			sb.Append(wpb);

			//自部門のみの権限の場合
			if (keyColumn.DisclosureUnitType == "D")
			{
				sb.Append(" AND EXISTS (SELECT [DEPT_CODE] FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetLowerDeptLevel](@DeptCode, @Date)"));
				sb.Append(" [TEMP_DEPTLEVEL] WHERE [PO].[DEPT_CODE] = [TEMP_DEPTLEVEL].[DEPT_CODE])");
			}

			return new SqlCommandWrapper(sb.ToSqlPString(),cn);	// 管理番号K27230

		}
		//発注明細
		private static SqlPString CreatePoDetailString(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			string prodSpec1Name = string.Empty;
			string prodSpec2Name = string.Empty;
			string unitShortName = string.Empty;
// 管理番号 K25647 From
//// 管理番号 B22414 From
//			//全量計上済かどうか
//			string CASE_QT = " ([PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT] ) / [U].[INCLUDE_QT])) > 0 ";
//// 管理番号 B22414 To
			//全量計上済かどうか
			string CASE_QT = " ([PD].[PO_QT] - CAST((([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT] ) / [U].[INCLUDE_QT]) AS DECIMAL(28, 5))) > 0 ";
// 管理番号 K25647 To

			switch (keyColumn.OverseasFlg)
			{
				case OverseasFlg.DOMESTIC:
					prodSpec1Name = "PROD_SPEC_1_NAME";
					prodSpec2Name = "PROD_SPEC_2_NAME";
					unitShortName = "UNIT_SHORT_NAME";
					break;
				case OverseasFlg.OVERSEAS:
					prodSpec1Name = "PROD_SPEC_1_ENG_NAME";
					prodSpec2Name = "PROD_SPEC_2_ENG_NAME";
					unitShortName = "UNIT_ENG_NAME";
					break;
			}

			//在庫管理部門の取得
			sb.Append("DECLARE @STOCK_ADMIN_DEPT_CODE NVARCHAR(10) ");
			sb.Append("SELECT ");
			sb.Append("  @STOCK_ADMIN_DEPT_CODE = ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SC_MS_GetStockDeptCode]"));
			sb.Append("(@MYCOMP_CODE, [DEPT_CODE], GETDATE())");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]"));
			wpb.AddFilter("[PO_NO]", SearchOperator.Equal, keyColumn.SlipNo );
			sb.Append(wpb);

// 管理番号 B11723・B11796 From
			sb.Append(@"
DECLARE @CUR_DIGIT      DECIMAL(1,0)
DECLARE @CUR_ROUND_TYPE NVARCHAR(1)
DECLARE @AMT_ROUND_TYPE NVARCHAR(1)

SELECT
	 @CUR_ROUND_TYPE = [MC].[CUR_FRACTION_ROUND_TYPE]
	,@AMT_ROUND_TYPE = [MC].[AMT_TTL_FRACTION_ROUND_TYPE]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[MYCOMP]")).Append(@" AS [MC]
WHERE [MC].[MYCOMP_CODE] = @MYCOMP_CODE

SELECT @CUR_DIGIT = [C].[DECIMAL_DIGIT]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(@" AS [PO]
INNER JOIN ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CUR]")).Append(@" AS [C]
	ON [PO].[CUR_CODE] = [C].[CUR_CODE]
WHERE [PO].[PO_NO] = @SLIP_NO
");
// 管理番号 B11723・B11796 To

			wpb = new WherePhraseBuilder();

			sb.Append("SELECT ");
			sb.Append(" [PD].[PO_LINE_ID]                         AS [PU_LINE_ID]"                );
			sb.Append(",[PD].[PO_LINE_NO]                         AS [PU_LINE_NO]"                );
			sb.Append(",[PD].[PO_NO]                              AS [PO_NO]"                     );
			sb.Append(",[PD].[PO_LINE_ID]                         AS [PO_LINE_ID]"                );
			sb.Append(",NULL                                      AS [RCPT_NO]"                   );
			sb.Append(",NULL                                      AS [RCPT_LINE_ID]"              );
			sb.Append(",NULL                                      AS [SA_NO]"                     );
			sb.Append(",NULL                                      AS [SA_LINE_ID]"                );
			sb.Append(",[PD].[WH_CODE]                            AS [WH_CODE]"                   );
			sb.Append(",[W].[WH_SHORT_NAME]                       AS [WH_SHORT_NAME]"             );
			sb.Append(",[PD].[PROD_CODE]                          AS [PROD_CODE]"                 );
// 管理番号 B19475 From						
//			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_PO_NAME]"              );
			sb.Append(",[PD].[PROD_PO_NAME]						  AS [PROD_PO_NAME]"              );
// 管理番号 B19475 To						
			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_SHORT_NAME]"           );
			sb.Append(",[PD].[PROD_PO_NAME]                       AS [PROD_NAME]"                 );
			sb.Append(",[PD].[PROD_TYPE]                          AS [PROD_TYPE]"                 );
			sb.Append(",[PROD].[DISP_CONTROL_TYPE]                AS [DISP_CONTROL_TYPE]"         );
			sb.Append(",[PROD].[STOCK_ADMIN_FLG]                  AS [STOCK_ADMIN_FLG]"           );
			sb.Append(",[PROD].[LOT_ADMIN_FLG]                    AS [LOT_ADMIN_FLG]"             );
// 管理番号 K25322 From
			sb.Append(",[PROD].[LOT_STOCK_VALUATION_FLG]          AS [LOT_STOCK_VALUATION_FLG]"   );
// 管理番号 K25322 To
			sb.Append(",[U].[QT_DECIMAL_USE_FLG]                  AS [QT_DECIMAL_USE_FLG]"        );
			sb.Append(",[PD].[CTAX_CALC_TYPE]                     AS [CTAX_CALC_TYPE]"            );
// 管理番号 K24789 From
//// 管理番号 B24787 From
////// 管理番号 B18904 From
//////			sb.Append(",[PROD].[CTAX_RATE_CODE]                   AS [CTAX_RATE_CODE]"            );
////			if(keyColumn.OverseasFlg == "1")
////			{
////				sb.Append(",'0'									  AS [CTAX_RATE_CODE]"            );
////			}
////			else
////			{
////				sb.Append(",[PROD].[CTAX_RATE_CODE]               AS [CTAX_RATE_CODE]"            );
////			}
////// 管理番号 B18904 To
//			sb.Append(",[PROD].[CTAX_RATE_CODE]                   AS [CTAX_RATE_CODE]"            );
//// 管理番号 B24787 To
			sb.Append(",[PD].[CTAX_TYPE_CODE]                     AS [CTAX_TYPE_CODE]"            );
			sb.Append(",[PD].[CTAX_RATE_CODE]                     AS [CTAX_RATE_CODE]"            );
// 管理番号 K24789 To
			sb.Append(",[PD].[CTAX_RATE]                          AS [CTAX_RATE]"                 );
			sb.Append(",[PD].[PROD_SPEC_1_CODE]                   AS [PROD_SPEC_1_CODE]"          );
			sb.Append(",[PS1].[").Append(prodSpec1Name).Append("] AS [PROD_SPEC_1_NAME]"          );
			sb.Append(",[PD].[PROD_SPEC_2_CODE]                   AS [PROD_SPEC_2_CODE]"          );
			sb.Append(",[PS2].[").Append(prodSpec2Name).Append("] AS [PROD_SPEC_2_NAME]"          );
			sb.Append(",[PD].[PU_PLAN_PRICE]                      AS [PU_PLAN_PRICE]"             );
			sb.Append(",NULL                                      AS [STOCK_UNIT_STD_SELL_PRICE]" );
			sb.Append(",[PD].[UNIT_CODE]                          AS [UNIT_CODE]"                 );
			sb.Append(",[U].[").Append(unitShortName).Append("]   AS [UNIT_SHORT_NAME]"           );
			//仕入数量の計算：
			//入荷が発生している時：(発注.入荷数量 - 発注.入荷返品数量 - 発注.仕入数量 + 発注.仕入返品数量) / 単位別商品属性.入数
			sb.Append(",CASE WHEN [R_D].[PO_NO] IS NULL ");
// 管理番号 B22414 From
//// 管理番号 B21476 From
////			sb.Append("     THEN ([PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT]))");
//			sb.Append("     THEN ([PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT]) - ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) - ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0) )");
//// 管理番号 B21476 To
			sb.Append("		THEN ");
			sb.Append("			CASE ");
			sb.Append("				WHEN").Append(CASE_QT).Append(" THEN ");
// 管理番号 K25647 From
//			sb.Append("					([PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT]) - ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) - ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0) )");
//			sb.Append("				ELSE ");
//			sb.Append("					([PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]) / [U].[INCLUDE_QT]) - ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) - ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0) )");
			sb.Append("					([PD].[PO_QT] - CAST((([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT]) AS DECIMAL(28, 5)) - ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) - ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0) )");
			sb.Append("				ELSE ");
			sb.Append("					([PD].[PO_QT] - CAST((([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]) / [U].[INCLUDE_QT]) AS DECIMAL(28, 5)) - ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) - ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0) )");
// 管理番号 K25647 To
			sb.Append("			END ");
// 管理番号 B22414 To
			sb.Append("     ELSE [R_D].[RCPT_DTIL_SUM_PU_QT] ");
			sb.Append(" END                                 AS [PU_QT]"                     );

			sb.Append(",CASE WHEN [R_D].[PO_NO] IS NULL ");
// 管理番号 B22414 From
//// 管理番号 B21476 From
////			sb.Append("     THEN ([PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT]))");
//			sb.Append("     THEN ([PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT]) - ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) - ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0) )");
//// 管理番号 B21476 To
			sb.Append("		THEN ");
			sb.Append("			CASE ");
			sb.Append("				WHEN").Append(CASE_QT).Append(" THEN ");
// 管理番号 K25647 From
//			sb.Append("					([PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT]) - ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) - ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0) )");
//			sb.Append("				ELSE ");
//			sb.Append("					([PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]) / [U].[INCLUDE_QT]) - ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) - ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0) )");
			sb.Append("					([PD].[PO_QT] - CAST((([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT]) AS DECIMAL(28, 5)) - ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) - ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0) )");
			sb.Append("				ELSE ");
			sb.Append("					([PD].[PO_QT] - CAST((([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]) / [U].[INCLUDE_QT]) AS DECIMAL(28, 5)) - ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) - ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0) )");
// 管理番号 K25647 To
			sb.Append("			END ");
// 管理番号 B22414 To
			sb.Append("     ELSE [R_D].[RCPT_DTIL_SUM_PU_QT] ");
			sb.Append(" END                                 AS [INIT_PU_QT]"                );
			sb.Append(",0                                   AS [TRANSIT_RCPT_QT]"           );
			sb.Append(",'1'                                 AS [RCPT_INPUT_NO_NEED_FLG]"    );

			//上限値
			sb.Append(",CASE WHEN [R_D].[PO_NO] IS NULL ");
			sb.Append("     THEN ");	//発注明細から(入荷の無い発注参照は上限値なし)
			switch (keyColumn.OverseasFlg)
			{
				//国内仕入
				case OverseasFlg.DOMESTIC:
					sb.Append("0");
					break;
				//海外仕入
				case OverseasFlg.OVERSEAS:
// 管理番号 B22414 From
//					sb.Append("[PD].[PO_QT] - ([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT]");
					sb.Append("	CASE ");
					sb.Append("		WHEN").Append(CASE_QT).Append(" THEN ");
// 管理番号 K25647 From
//					sb.Append("[PD].[PO_QT] - ([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT]");
//					sb.Append("		ELSE ");
//					sb.Append("			[PD].[PO_QT] - ([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]) / [U].[INCLUDE_QT]");
					sb.Append("			[PD].[PO_QT] - CAST(([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT] AS DECIMAL(28, 5))");
					sb.Append("		ELSE ");
					sb.Append("			[PD].[PO_QT] - CAST(([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]) / [U].[INCLUDE_QT] AS DECIMAL(28, 5))");
// 管理番号 K25647 To
					sb.Append("	END ");
// 管理番号 B22414 To
					break;
			}
			sb.Append("     ELSE ");	//入荷明細から(上限値は出荷数を超えない数量)
			sb.Append("         [R_D].[RCPT_DTIL_SUM_PU_QT] "                               );
			sb.Append(" END                                 AS [UPPER_LIMIT_PU_QT] "        );

			sb.Append(",ISNULL([ST].[VALID_QT],0)           AS [VALID_QT]"                  );

			sb.Append(",CASE WHEN [R_D].[PO_NO] IS NULL ");
// 管理番号 B22414 From
//// 管理番号 B21476 From
////			sb.Append("     THEN ([PD].[PO_QT] * [U].[INCLUDE_QT]) - [PD].[RCPT_PU_QT] - [PD].[DIRECT_PU_QT]");
//			sb.Append("     THEN ([PD].[PO_QT] * [U].[INCLUDE_QT]) - [PD].[RCPT_PU_QT] - [PD].[DIRECT_PU_QT] - (ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) + ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0)) * [U].[INCLUDE_QT] ");
//// 管理番号 B21476 To
			sb.Append("		THEN ");
			sb.Append("			CASE ");
			sb.Append("				WHEN").Append(CASE_QT).Append(" THEN ");
			sb.Append("					([PD].[PO_QT] * [U].[INCLUDE_QT]) - [PD].[RCPT_PU_QT] - [PD].[DIRECT_PU_QT] - (ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) + ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0)) * [U].[INCLUDE_QT] ");
			sb.Append("				ELSE ");
			sb.Append("					([PD].[PO_QT] * [U].[INCLUDE_QT]) - [PD].[RCPT_PU_QT] - ([PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]) - (ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) + ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0)) * [U].[INCLUDE_QT] ");
			sb.Append("			END ");
// 管理番号 B22414 To
			sb.Append("     ELSE [R_D].[RCPT_DTIL_SUM_PU_QT] * [U].[INCLUDE_QT] ");
			sb.Append(" END                                 AS [STOCK_UNIT_PU_QT]"          );

			sb.Append(",CASE WHEN [R_D].[PO_NO] IS NULL ");
// 管理番号 B22414 From
//// 管理番号 B21476 From
////			sb.Append("     THEN ([PD].[PO_QT] * [U].[INCLUDE_QT]) - [PD].[RCPT_PU_QT] - [PD].[DIRECT_PU_QT]");
//			sb.Append("     THEN ([PD].[PO_QT] * [U].[INCLUDE_QT]) - [PD].[RCPT_PU_QT] - [PD].[DIRECT_PU_QT] - (ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) + ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0)) * [U].[INCLUDE_QT] ");
//// 管理番号 B21476 To
			sb.Append("		THEN ");
			sb.Append("			CASE ");
			sb.Append("				WHEN").Append(CASE_QT).Append(" THEN ");
			sb.Append("					([PD].[PO_QT] * [U].[INCLUDE_QT]) - [PD].[RCPT_PU_QT] - [PD].[DIRECT_PU_QT] - (ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) + ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0)) * [U].[INCLUDE_QT] ");
			sb.Append("				ELSE ");
			sb.Append("					([PD].[PO_QT] * [U].[INCLUDE_QT]) - [PD].[RCPT_PU_QT] - ([PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]) - (ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) + ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0)) * [U].[INCLUDE_QT] ");
			sb.Append("			END ");
// 管理番号 B22414 To
			sb.Append("     ELSE [R_D].[RCPT_DTIL_SUM_PU_QT] * [U].[INCLUDE_QT] ");
			sb.Append(" END                                 AS [STOCK_UNIT_PO_PU_QT]"       );

			sb.Append(",0                                   AS [STOCK_UNIT_PO_ALLOC_PU_QT]" );
			sb.Append(",[PD].[PO_PRICE]                     AS [PU_PRICE]"                  );
			sb.Append(",[PD].[PO_PRICE]                     AS [INIT_PU_PRICE]"             );
			sb.Append(",[PD].[DISC_FLG]                     AS [DISC_FLG]"                  );
// 管理番号 B13878 From
			sb.Append(",[PD].[PRICE_UNDECIDED_FLG]			AS [PRICE_UNDECIDED_FLG]"		);
// 管理番号 B13878 To
			sb.Append(",NULL                                AS [LINE_REMARKS_CODE]"         );
// 管理番号 K24274 From
//			sb.Append(",NULL                                AS [LINE_REMARKS]"              );
			sb.Append(",CASE WHEN [SLIP_TYPE].[REMARKS_COORDINATION_TYPE] = '1' ");
			sb.Append("		THEN [PD].[LINE_REMARKS] ");
			sb.Append("		ELSE NULL ");
			sb.Append("	END AS [LINE_REMARKS] ");
// 管理番号 K24274 To
// 管理番号K27525 From
			sb.Append(",[PD].[BOOK_DEDUCTION_REASON_CODE]   AS [BOOK_DEDUCTION_REASON_CODE]");
			sb.Append(",[BDR].[BOOK_DEDUCTION_REASON_NAME]  AS [BOOK_DEDUCTION_REASON_NAME]");
// 管理番号K27525 To
// 管理番号 K16671 From
			sb.Append(",[PD].[REF_CODE]                     AS [REF_CODE]"                  );
// 管理番号 K16671 To
			sb.Append(",[U].[INCLUDE_QT]                    AS [INCLUDE_QT]"                );
			sb.Append(",0                                   AS [DTIL_AMT]"                  );
			sb.Append(",0                                   AS [ETAX_AMT]"                  );
			sb.Append(",0                                   AS [ITAX_AMT]"                  );
			sb.Append(",'0'                                 AS [PRICE_UPDATE_FLG]"          );
// 管理番号 K24278 From
//// 管理番号 B11723・B11796 From
////			sb.Append(",CASE WHEN [R_D].[PO_NO] IS NULL ");
////			sb.Append("     THEN (([PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT])) * [PD].[PO_PRICE])");
////			sb.Append("     ELSE [R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE] ");
////			sb.Append(" END                                 AS [PU_MONEY]"                  );
//// 管理番号 B13502 From
//// 管理番号 B22414 From
////			sb.Append(",").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound]")).Append(@"(
////	CASE
////		WHEN [R_D].[PO_NO] IS NULL
////			THEN (
////				(
////					  [PD].[PO_QT] * [U].[INCLUDE_QT]
////					- ([PD].[RCPT_PU_QT]
////					+ [PD].[DIRECT_PU_QT])
////				)
////				/ [U].[INCLUDE_QT]
////			)
////			* [PD].[PO_PRICE]
////		ELSE
////			[R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE]
////	END
////	, @CUR_DIGIT, @AMT_ROUND_TYPE
////) AS [PU_MONEY]");
//			sb.Append( ",CASE ");
//			sb.Append( "	WHEN").Append(CASE_QT).Append(" THEN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound]")).Append(@"(
//	CASE
//		WHEN [R_D].[PO_NO] IS NULL
//			THEN (
//				(
//					  [PD].[PO_QT] * [U].[INCLUDE_QT]
//					- ([PD].[RCPT_PU_QT]
//					+ [PD].[DIRECT_PU_QT])
//				)
//				/ [U].[INCLUDE_QT]
//			)
//			* [PD].[PO_PRICE]
//		ELSE
//			[R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE]
//	END
//	, @CUR_DIGIT, @AMT_ROUND_TYPE
//) ");
//			sb.Append("     ELSE ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound]")).Append(@"(
//	CASE
//		WHEN [R_D].[PO_NO] IS NULL
//			THEN (
//				(
//					  [PD].[PO_QT] * [U].[INCLUDE_QT]
//					- ([PD].[RCPT_PU_QT]
//					+ ([PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]))
//				)
//				/ [U].[INCLUDE_QT]
//			)
//			* [PD].[PO_PRICE]
//		ELSE
//			[R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE]
//	END
//	, @CUR_DIGIT, @AMT_ROUND_TYPE
//) ");
//			sb.Append(" END AS [PU_MONEY] ");
//// 管理番号 B22414 To
//// 管理番号 B13502 To
////			sb.Append(",").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound]")).Append(@"(
////	CASE
////		WHEN [R_D].[PO_NO] IS NULL
////			THEN (
////				(
////					  [PD].[PO_QT] * [U].[INCLUDE_QT]
////					- [PD].[RCPT_PU_QT]
////					+ [PD].[DIRECT_PU_QT]
////				)
////				/ [U].[INCLUDE_QT]
////			)
////			* [PD].[PO_PRICE]
////		ELSE
////			[R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE]
////	END
////	, @CUR_DIGIT, @AMT_ROUND_TYPE
////) AS [PU_MONEY]");
//			// 管理番号 B11723・B11796 To
			sb.Append(",CASE  WHEN").Append(CASE_QT);
			sb.Append(" THEN ");
			// 計上残あり
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound](")).Append(@"
							CASE WHEN @ImposeFlg = '0' AND [PD].[CTAX_CALC_TYPE] = 'I' 
							THEN ");
			// 計上残あり：課税しない、かつ内税
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound](")).Append(@"
								CASE WHEN [R_D].[PO_NO] IS NULL
									THEN (
											(
												  [PD].[PO_QT] * [U].[INCLUDE_QT]
												- ([PD].[RCPT_PU_QT]
												+ [PD].[DIRECT_PU_QT])
											)
											/ [U].[INCLUDE_QT]
										)
										* [PD].[PO_PRICE]
									ELSE
										[R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE]
								END
								, @CUR_DIGIT, @AMT_ROUND_TYPE )
								- ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound]")).Append(@"
								(
									(
										CASE WHEN [R_D].[PO_NO] IS NULL
											THEN (
													(
														  [PD].[PO_QT] * [U].[INCLUDE_QT]
														- ([PD].[RCPT_PU_QT]
														+ [PD].[DIRECT_PU_QT])
													)
													/ [U].[INCLUDE_QT]
												)
												* [PD].[PO_PRICE]
											ELSE
												[R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE]
										END
									) * ([PD].[CTAX_RATE] / 100) / (1 + ([PD].[CTAX_RATE] / 100))
								,@CUR_DIGIT, @CtaxRoundType
								)
							ELSE ");
			// 計上残あり：課税する
// 管理番号B26746 From
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound](")).Append(@"
//								CASE WHEN [R_D].[PO_NO] IS NULL
//									THEN (
//											(
//												  [PD].[PO_QT] * [U].[INCLUDE_QT]
//												- ([PD].[RCPT_PU_QT]
//												+ [PD].[DIRECT_PU_QT])
//											)
//											/ [U].[INCLUDE_QT]
//										)
//										* [PD].[PO_PRICE]
//									ELSE
//										[R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE]
//								END
//								, @CUR_DIGIT, @AMT_ROUND_TYPE )
//							END 
//							,@CUR_DIGIT, @CtaxRoundType
//							)");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound](")).Append(@"
								CASE WHEN [R_D].[PO_NO] IS NULL
									THEN (
											(
												[PD].[PO_QT] * [U].[INCLUDE_QT]
												- ([PD].[RCPT_PU_QT]
												+ [PD].[DIRECT_PU_QT])
											)
											/ [U].[INCLUDE_QT]
										)
										* [PD].[PO_PRICE]
									ELSE
										[R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE]
								END
								, @CUR_DIGIT, @AMT_ROUND_TYPE )
							END
							,@CUR_DIGIT, @AMT_ROUND_TYPE
							)");
// 管理番号B26746 To

			sb.Append(" ELSE ");
			// 計上残なし
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound](")).Append(@"
							CASE WHEN @ImposeFlg = '0' AND [PD].[CTAX_CALC_TYPE] = 'I' 
							THEN ");
			// 計上残なし：課税しない、かつ内税
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound](")).Append(@"
								CASE WHEN [R_D].[PO_NO] IS NULL
									THEN (
											(
												  [PD].[PO_QT] * [U].[INCLUDE_QT]
												- ([PD].[RCPT_PU_QT]
												+ ([PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]))
											)
											/ [U].[INCLUDE_QT]
										)
										* [PD].[PO_PRICE]
									ELSE
										[R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE]
								END
								, @CUR_DIGIT, @AMT_ROUND_TYPE )
								- ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound]")).Append(@"
								(
									(
										CASE WHEN [R_D].[PO_NO] IS NULL
											THEN (
													(
														  [PD].[PO_QT] * [U].[INCLUDE_QT]
														- ([PD].[RCPT_PU_QT]
														+ ([PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]))
													)
													/ [U].[INCLUDE_QT]
												)
												* [PD].[PO_PRICE]
											ELSE
												[R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE]
										END
									) * ([PD].[CTAX_RATE] / 100) / (1 + ([PD].[CTAX_RATE] / 100))
								,@CUR_DIGIT, @CtaxRoundType
								) 
							ELSE ");
			// 計上残なし：課税する
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound](")).Append(@"
								CASE WHEN [R_D].[PO_NO] IS NULL
									THEN (
											(
												  [PD].[PO_QT] * [U].[INCLUDE_QT]
												- ([PD].[RCPT_PU_QT]
												+ ([PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]))
											)
											/ [U].[INCLUDE_QT]
										)
										* [PD].[PO_PRICE]
									ELSE
										[R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE]
								END
								, @CUR_DIGIT, @AMT_ROUND_TYPE
							)
							END, @CUR_DIGIT, @AMT_ROUND_TYPE
							)");
			sb.Append(" END AS [PU_MONEY] ");
// 管理番号 K24278 To
			sb.Append(",[PROD].[PROD_NAME_CORRECT_ALLOW_FLG] AS [PROD_NAME_CORRECTION_FLG]" );
			sb.Append(",'0'                                 AS [PROD_EDIT_FLG]"             );
			//入荷済判定
			sb.Append(",CASE WHEN [R_D].[PO_NO] IS NULL ");
			sb.Append("     THEN '0' "                                                      );
			sb.Append("     ELSE '1' "                                                      );
			sb.Append(" END                                 AS [IS_RCPT_EXECUTE]"           );

			sb.Append(",'R'                                 AS [ROW_STATE]"                 );
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputDetailCommon, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PD", "CUSTOM_ITEM_TAG", "@PU_DATE", null, false);
// 管理番号K27057 To

			//発注
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(" AS [PO]");
			//発注明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO_DTIL]")).Append(" AS [PD]");
			sb.Append(" ON [PO].[PO_NO] = [PD].[PO_NO]");
			//入荷明細サマリ
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(" ( ");
			sb.Append("    SELECT ");
			sb.Append("    [R_D].[PO_NO]        AS [PO_NO], "       );
			sb.Append("    [R_D].[PO_LINE_ID]   AS [PO_LINE_ID], "  );
			sb.Append("    SUM([R_D].[RCPT_QT]) - SUM([R_D].[RCPT_RETURN_QT]) - SUM([R_D].[PU_QT]) AS [RCPT_DTIL_SUM_PU_QT] ");
			sb.Append("    FROM ");
// 管理番号 B21476 From
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT] ");
//			sb.Append("    INNER JOIN  ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [R_D] ");
//			sb.Append("    ON  [RCPT].[RCPT_NO] = [R_D].[RCPT_NO]");
//			WherePhraseBuilder wpbSub = new  WherePhraseBuilder();
//			wpbSub.AddFilter("[RCPT].[RCPT_MODE_TYPE]"   , SearchOperator.Equal, "1");
//			wpbSub.AddFilter("[RCPT].[DELETE_FLG]"       , SearchOperator.NotEqual, "1");
//			wpbSub.AddFilter("[R_D].[PO_NO]"             , SearchOperator.Equal   , keyColumn.SlipNo);
//			wpbSub.AddFilter("[R_D].[DELETE_FLG]"        , SearchOperator.NotEqual, "1");
//			sb.Append(wpbSub);
			sb.Append("       ( ");
			sb.Append("          SELECT ");
			sb.Append("            [RCPT_D].[PO_NO] ");
			sb.Append("            ,[RCPT_D].[PO_LINE_ID] ");
			sb.Append("            ,[RCPT_D].[RCPT_QT] ");
			sb.Append("            ,[RCPT_D].[RCPT_RETURN_QT] ");
			sb.Append("            ,[RCPT_D].[PU_QT] ");
			sb.Append("          FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT] ");
			sb.Append("          INNER JOIN  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RCPT_D] ");
			sb.Append("          ON  [RCPT_D].[RCPT_NO] = [RCPT].[RCPT_NO]");
			WherePhraseBuilder wpbSub = new WherePhraseBuilder();
			wpbSub.AddFilter("     [RCPT].[RCPT_MODE_TYPE]", SearchOperator.Equal, "1");
			wpbSub.AddFilter("     [RCPT].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub.AddFilter("     [RCPT].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "3");
			wpbSub.AddFilter("     [RCPT_D].[PO_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpbSub.AddFilter("     [RCPT_D].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub);
			sb.Append("          UNION ALL ");
			sb.Append("          SELECT ");
			sb.Append("            [RCPT_D].[PO_NO] ");
			sb.Append("            ,[RCPT_D].[PO_LINE_ID] ");
			sb.Append("            ,[RCPT_D].[RCPT_QT] ");
			sb.Append("            ,[RCPT_D].[RCPT_RETURN_QT] ");
			sb.Append("            ,[RCPT_D].[PU_QT] ");
			sb.Append("          FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT] ");
			sb.Append("          INNER JOIN  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RCPT_D] ");
			sb.Append("          ON  [RCPT_D].[RCPT_NO] = [RCPT].[RCPT_NO]");
			WherePhraseBuilder wpbSub2 = new WherePhraseBuilder();
			wpbSub2.AddFilter("     [RCPT].[RCPT_MODE_TYPE]", SearchOperator.Equal, "2");
			wpbSub2.AddFilter("     [RCPT].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub2.AddFilter("     [RCPT].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "1");
			wpbSub2.AddFilter("     [RCPT_D].[PO_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpbSub2.AddFilter("     [RCPT_D].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub2);
			sb.Append("       ) AS [R_D] ");
// 管理番号 B21476 To
			sb.Append(" GROUP BY ");
			sb.Append(" [R_D].[PO_NO], "       );
			sb.Append(" [R_D].[PO_LINE_ID] "   );
			sb.Append(" HAVING ");
			sb.Append(" SUM([R_D].[RCPT_QT]) - SUM([R_D].[RCPT_RETURN_QT]) - SUM([R_D].[PU_QT]) > 0 ");
			sb.Append(" ) AS [R_D] ");
			sb.Append(" ON  [PD].[PO_NO]      = [R_D].[PO_NO]");
			sb.Append(" AND [PD].[PO_LINE_ID] = [R_D].[PO_LINE_ID]");
// 管理番号 B21476 From
			//入荷明細サマリ(未承認)
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(" ( ");
			sb.Append("    SELECT ");
			sb.Append("    [R_D].[PO_NO]        AS [PO_NO], ");
			sb.Append("    [R_D].[PO_LINE_ID]   AS [PO_LINE_ID], ");
			sb.Append("    SUM([R_D].[RCPT_QT]) - SUM([R_D].[RCPT_RETURN_QT]) - SUM([R_D].[PU_QT]) AS [RCPT_DTIL_SUM_PU_QT] ");
			sb.Append("    FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT] ");
			sb.Append("    INNER JOIN  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [R_D] ");
			sb.Append("    ON  [RCPT].[RCPT_NO] = [R_D].[RCPT_NO]");
			WherePhraseBuilder wpbSub3 = new WherePhraseBuilder();
			wpbSub3.AddFilter("[RCPT].[RCPT_MODE_TYPE]", SearchOperator.Equal, "1");
			wpbSub3.AddFilter("[RCPT].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub3.AddFilter("[RCPT].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "1");
			wpbSub3.AddFilter("[R_D].[PO_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpbSub3.AddFilter("[R_D].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub3);
			sb.Append(" GROUP BY ");
			sb.Append(" [R_D].[PO_NO], ");
			sb.Append(" [R_D].[PO_LINE_ID] ");
			sb.Append(" HAVING ");
			sb.Append(" SUM([R_D].[RCPT_QT]) - SUM([R_D].[RCPT_RETURN_QT]) - SUM([R_D].[PU_QT]) > 0 ");
			sb.Append(" ) AS [R_D2] ");
			sb.Append(" ON  [PD].[PO_NO]      = [R_D2].[PO_NO]");
			sb.Append(" AND [PD].[PO_LINE_ID] = [R_D2].[PO_LINE_ID]");

			//入荷返品明細サマリ(未承認)
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(" ( ");
			sb.Append("    SELECT ");
			sb.Append("    [R_D].[PO_NO]        AS [PO_NO], ");
			sb.Append("    [R_D].[PO_LINE_ID]   AS [PO_LINE_ID], ");
			sb.Append("    (SUM([R_D].[RCPT_QT]) - SUM([R_D].[RCPT_RETURN_QT]) - SUM([R_D].[PU_QT])) * -1 AS [RCPT_DTIL_SUM_PU_QT] ");
			sb.Append("    FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT] ");
			sb.Append("    INNER JOIN  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [R_D] ");
			sb.Append("    ON  [RCPT].[RCPT_NO] = [R_D].[RCPT_NO]");
			WherePhraseBuilder wpbSub4 = new WherePhraseBuilder();
			wpbSub4.AddFilter("[RCPT].[RCPT_MODE_TYPE]", SearchOperator.Equal, "2");
			wpbSub4.AddFilter("[RCPT].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub4.AddFilter("[RCPT].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "1");
			wpbSub4.AddFilter("[R_D].[PO_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpbSub4.AddFilter("[R_D].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub4);
			sb.Append(" GROUP BY ");
			sb.Append(" [R_D].[PO_NO], ");
			sb.Append(" [R_D].[PO_LINE_ID] ");
			sb.Append(" HAVING ");
			sb.Append(" SUM([R_D].[RCPT_QT]) - SUM([R_D].[RCPT_RETURN_QT]) - SUM([R_D].[PU_QT]) < 0 ");
			sb.Append(" ) AS [R_D3] ");
			sb.Append(" ON  [PD].[PO_NO]      = [R_D3].[PO_NO]");
			sb.Append(" AND [PD].[PO_LINE_ID] = [R_D3].[PO_LINE_ID]");
// 管理番号 B21476 To

			//商品
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [PROD]");
			sb.Append(" ON  [PD].[PROD_CODE]   = [PROD].[PROD_CODE]");
			sb.Append(" AND [PROD].[PROD_TYPE] = '0' ");//通常商品のみ
			//商品規格1
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_1]")).Append(" AS [PS1]");
			sb.Append(" ON [PD].[PROD_SPEC_1_CODE] = [PS1].[PROD_SPEC_1_CODE]");
			//商品規格2
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_2]")).Append(" AS [PS2]");
			sb.Append(" ON [PD].[PROD_SPEC_2_CODE] = [PS2].[PROD_SPEC_2_CODE]");
			//倉庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[WH]")).Append(" AS [W]");
			sb.Append(" ON [PD].[WH_CODE] = [W].[WH_CODE]");
			//単位別商品属性
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
			sb.Append(" ON [PD].[PROD_CODE] = [U].[PROD_CODE]");
			sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE] ");
			//在庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[STOCK]")).Append(" AS [ST]");
			sb.Append(" ON  [PD].[WH_CODE]          = [ST].[WH_CODE] ");
			sb.Append(" AND [PD].[PROD_CODE]        = [ST].[PROD_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [ST].[PROD_SPEC_1_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [ST].[PROD_SPEC_2_CODE] ");
			sb.Append(" AND [ST].[DEPT_CODE]        = @STOCK_ADMIN_DEPT_CODE ");
// 管理番号 B13877 From
			if (keyColumn.ProjectStockAdminUseFlg)
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ISNULL([PO].[PROJ_CODE],'')");
				sb.Append(" AND [ST].[PROJ_SBNO] = ISNULL([PO].[PROJ_SBNO],'')");
			}
			else
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ''");
				sb.Append(" AND [ST].[PROJ_SBNO] = ''");
			}
// 管理番号 B13877 To
// 管理番号K27525 From
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[BOOK_DEDUCTION_REASON]")).Append(" AS [BDR]");
			sb.Append(" ON [BDR].[BOOK_DEDUCTION_REASON_CODE] = [PD].[BOOK_DEDUCTION_REASON_CODE] ");
// 管理番号K27525 To
// 管理番号 K24274 From
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SLIP_TYPE]"));
			sb.Append(" ON [SLIP_TYPE].[SLIP_TYPE_CODE] = 'SM3' ");
// 管理番号 K24274 To

			wpb.AddFilter("[PD].[PO_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[PD].[DELETE_FLG]", SearchOperator.Equal, "0");
// 管理番号 K25647 From
//// 管理番号 B22414 From
////			wpb.AddFilter("[PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT])", SearchOperator.GreaterThan, 0);
//			wpb.AddFilter("[PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]) / [U].[INCLUDE_QT])", SearchOperator.GreaterThan, 0);
//// 管理番号 B22414 To
			wpb.AddFilter("[PD].[PO_QT] - CAST((([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]) / [U].[INCLUDE_QT]) AS DECIMAL(28, 5))", SearchOperator.GreaterThan, 0);
// 管理番号 K25647 To
			sb.Append(wpb);
// 管理番号 B21476 From
			sb.Append(" AND (                                   ");
			sb.Append("       [PROD].[STOCK_ADMIN_FLG]='0'      ");
			sb.Append("       OR (                              ");
			sb.Append("            [PROD].[STOCK_ADMIN_FLG]='1' ");
			sb.Append("            AND (                        ");
			sb.Append("                  [PD].[PO_QT] > ISNULL([R_D2].[RCPT_DTIL_SUM_PU_QT],0) + ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0) ");
			sb.Append("                  OR ([PD].[RCPT_QT] - [PD].[RCPT_RETURN_QT] - ISNULL([R_D3].[RCPT_DTIL_SUM_PU_QT],0)) > 0 ");
			sb.Append("                )                        ");
			sb.Append("          )                              ");
			sb.Append("     )                                   ");
// 管理番号 B21476 To
			sb.Append("ORDER BY [PD].[PO_LINE_NO] ASC ");

			return sb.ToSqlPString();	// 管理番号K27230
		}
		//発注ロット
		private static string CreatePoLotDetailString(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			//memo 発注参照時に入荷がなければ、ロット明細は作らない

			//発注参照時にROW_IDは発注行IDと一致する
			sb.Append(" SELECT DISTINCT ");
			sb.Append(" [PD].[PO_LINE_ID]             AS [ROW_ID]       ,");
			sb.Append(" [R_L_D].[LOT_NO]              AS [LOT_NO]       ,");
			sb.Append(" [LOT].[FAB_DATE]              AS [FAB_DATE]     ," );
// 管理番号 B22625 From
//			sb.Append(" DATEADD(Day,[PROD].[LOT_VALID_TERM_DAY_CNT]-1 ,[LOT].[FAB_DATE]) AS [TERM_DATE],");
			sb.Append(" CASE WHEN CONVERT(DATETIME,'9998/12/31') - [LOT].[FAB_DATE] < [PROD].[LOT_VALID_TERM_DAY_CNT]-1");
			sb.Append(   " THEN CONVERT(DATETIME,'9998/12/31')");
			sb.Append(   " ELSE DATEADD(Day,[PROD].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE])");
			sb.Append(" END AS [TERM_DATE] ,");
// 管理番号 B22625 To
			sb.Append(" [R_L_D].[RCPT_LOT_ID]         AS [LOT_ID]       ,");
			sb.Append(" '1'                           AS [STOCK_TYPE]   ,");
			sb.Append(" 0                             AS [STOCK_QT]     ,");
// 管理番号 B21476 From
//			sb.Append(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] - [R_L_D].[PU_QT] AS [INIT_QT],");
//			sb.Append(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] - [R_L_D].[PU_QT] AS [EDIT_QT]," );
			sb.Append(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] - ISNULL([R_D2].[RCPT_RETURN_QT],0) - [R_L_D].[PU_QT] AS [INIT_QT],");
			sb.Append(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] - ISNULL([R_D2].[RCPT_RETURN_QT],0) - [R_L_D].[PU_QT] AS [EDIT_QT],");
// 管理番号 B21476 To
			sb.Append(" 0                             AS [TRANSIT_RCPT_QT],");
			sb.Append(" [R_L_D].[RCPT_NO]             AS [RCPT_NO]      ," );
			sb.Append(" [R_L_D].[RCPT_LINE_ID]        AS [RCPT_LINE_ID] ," );
			sb.Append(" [R_L_D].[RCPT_LOT_ID]         AS [RCPT_LOT_ID]  ," );
			sb.Append(" [R].[RCPT_DATE]               AS [RCPT_DATE]    ," );
			sb.Append(" NULL                          AS [SA_NO]        ," );
			sb.Append(" NULL                          AS [SA_LINE_ID]   ," );
			sb.Append(" NULL                          AS [SA_LOT_ID]     " );
// 管理番号 K25322 From
			sb.Append(",0                             AS [PO_ALLOC_RCPT_QT]  "); //在庫単位発注引当仕入数量
// 管理番号 K25322 To

			//入荷ロット明細
			sb.Append(" FROM  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_LOT_DTIL]")).Append(" AS [R_L_D] ");
			//入荷明細
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD] ");
			sb.Append("  ON [RD].[RCPT_NO]      = [R_L_D].[RCPT_NO] "     );
			sb.Append(" AND [RD].[RCPT_LINE_ID] = [R_L_D].[RCPT_LINE_ID] ");
			//入荷
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R] ");
			sb.Append("  ON [R].[RCPT_NO]        = [RD].[RCPT_NO] "     );
			//発注明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO_DTIL]")).Append(" AS [PD] ");
			sb.Append(" ON  [RD].[PO_NO]      = [PD].[PO_NO] "    );
			sb.Append(" AND [RD].[PO_LINE_ID] = [PD].[PO_LINE_ID] ");
			//ロット
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[LOT]")).Append(" AS [LOT] ");
			sb.Append(" ON  [R_L_D].[LOT_NO]        = [LOT].[LOT_NO] ");
			sb.Append(" AND [PD].[PROD_CODE]        = [LOT].[PROD_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [LOT].[PROD_SPEC_1_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [LOT].[PROD_SPEC_2_CODE] ");
			//入荷明細サマリ
			sb.Append(" INNER JOIN ");
			sb.Append(" ( ");
			sb.Append("    SELECT ");
			sb.Append("    [R_D].[PO_NO]        AS [PO_NO], "       );
			sb.Append("    [R_D].[PO_LINE_ID]   AS [PO_LINE_ID], "  );
			sb.Append("    SUM([R_D].[RCPT_QT]) - SUM([R_D].[RCPT_RETURN_QT]) - SUM([R_D].[PU_QT]) AS [RCPT_DTIL_SUM_PU_QT] ");
			sb.Append("    FROM ");
// 管理番号 B21476 From
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT] ");
//			sb.Append("    INNER JOIN  ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [R_D] ");
//			sb.Append("    ON  [RCPT].[RCPT_NO] = [R_D].[RCPT_NO]");
//			WherePhraseBuilder wpbSub = new  WherePhraseBuilder();
//			wpbSub.AddFilter("[RCPT].[RCPT_MODE_TYPE]"   , SearchOperator.Equal, "1");
//			wpbSub.AddFilter("[RCPT].[DELETE_FLG]"       , SearchOperator.NotEqual, "1");
//			wpbSub.AddFilter("[R_D].[PO_NO]"             , SearchOperator.Equal   , keyColumn.SlipNo);
//			wpbSub.AddFilter("[R_D].[DELETE_FLG]"        , SearchOperator.NotEqual, "1");
//			sb.Append(wpbSub);
			sb.Append("       ( ");
			sb.Append("          SELECT ");
			sb.Append("            [RCPT_D].[PO_NO] ");
			sb.Append("            ,[RCPT_D].[PO_LINE_ID] ");
			sb.Append("            ,[RCPT_D].[RCPT_QT] ");
			sb.Append("            ,[RCPT_D].[RCPT_RETURN_QT] ");
			sb.Append("            ,[RCPT_D].[PU_QT] ");
			sb.Append("          FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT] ");
			sb.Append("          INNER JOIN  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RCPT_D] ");
			sb.Append("          ON  [RCPT_D].[RCPT_NO] = [RCPT].[RCPT_NO]");
			WherePhraseBuilder wpbSub = new WherePhraseBuilder();
			wpbSub.AddFilter("     [RCPT].[RCPT_MODE_TYPE]", SearchOperator.Equal, "1");
			wpbSub.AddFilter("     [RCPT].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub.AddFilter("     [RCPT].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "3");
			wpbSub.AddFilter("     [RCPT_D].[PO_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpbSub.AddFilter("     [RCPT_D].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub);
			sb.Append("          UNION ALL ");
			sb.Append("          SELECT ");
			sb.Append("            [RCPT_D].[PO_NO] ");
			sb.Append("            ,[RCPT_D].[PO_LINE_ID] ");
			sb.Append("            ,[RCPT_D].[RCPT_QT] ");
			sb.Append("            ,[RCPT_D].[RCPT_RETURN_QT] ");
			sb.Append("            ,[RCPT_D].[PU_QT] ");
			sb.Append("          FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT] ");
			sb.Append("          INNER JOIN  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RCPT_D] ");
			sb.Append("          ON  [RCPT_D].[RCPT_NO] = [RCPT].[RCPT_NO]");
			WherePhraseBuilder wpbSub2 = new WherePhraseBuilder();
			wpbSub2.AddFilter("     [RCPT].[RCPT_MODE_TYPE]", SearchOperator.Equal, "2");
			wpbSub2.AddFilter("     [RCPT].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub2.AddFilter("     [RCPT].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "1");
			wpbSub2.AddFilter("     [RCPT_D].[PO_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpbSub2.AddFilter("     [RCPT_D].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub2);
			sb.Append("       ) AS [R_D] ");
// 管理番号 B21476 To
			sb.Append(" GROUP BY ");
			sb.Append(" [R_D].[PO_NO], "       );
			sb.Append(" [R_D].[PO_LINE_ID] "   );
			sb.Append(" HAVING ");
			sb.Append(" SUM([R_D].[RCPT_QT]) - SUM([R_D].[RCPT_RETURN_QT]) - SUM([R_D].[PU_QT]) > 0 ");
			sb.Append(" ) AS [R_D] ");
			sb.Append(" ON  [PD].[PO_NO]      = [R_D].[PO_NO]");
			sb.Append(" AND [PD].[PO_LINE_ID] = [R_D].[PO_LINE_ID]");
// 管理番号 B21476 From
			//入荷返品明細サマリ(未承認)
			sb.Append(" LEFT OUTER JOIN ( ");
			sb.Append("                   SELECT ");
// 管理番号 B23776 From
//			sb.Append("                     [R].[PO_NO] ");
//			sb.Append("                     ,[RD].[PO_LINE_ID] ");
			sb.Append("                     [R].[REF_RCPT_NO] ");
			sb.Append("                     ,[RD].[RCPT_LINE_ID] ");
// 管理番号 B23776 To
			sb.Append("                     ,[RLD].[LOT_NO] ");
			sb.Append("                     ,SUM([RLD].[RCPT_QT])*-1 AS [RCPT_RETURN_QT] ");
			sb.Append("                   FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R]");
			sb.Append("                   INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD]");
			sb.Append("                   ON [RD].[RCPT_NO]=[R].[RCPT_NO] ");
			sb.Append("                   INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_LOT_DTIL]")).Append(" AS [RLD]");
			sb.Append("                   ON  [RLD].[RCPT_NO]=[RD].[RCPT_NO] ");
			sb.Append("                   AND [RLD].[RCPT_LINE_ID]=[RD].[RCPT_LINE_ID] ");
			WherePhraseBuilder wpbSub3 = new WherePhraseBuilder();
			wpbSub3.AddFilter("            [R].[PO_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpbSub3.AddFilter("            [R].[RCPT_MODE_TYPE]", SearchOperator.Equal, "2");
			wpbSub3.AddFilter("            [R].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "1");
			wpbSub3.AddFilter("            [R].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub3.AddFilter("            [RD].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub3.AddFilter("            [RLD].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub3);
// 管理番号 B23776 From
//			sb.Append("                   GROUP BY [R].[PO_NO],[RD].[PO_LINE_ID],[RLD].[LOT_NO] ");
			sb.Append("                   GROUP BY [R].[REF_RCPT_NO],[RD].[RCPT_LINE_ID],[RLD].[LOT_NO] ");
// 管理番号 B23776 To
			sb.Append(" ) AS [R_D2] ");
// 管理番号 B23776 From
//			sb.Append(" ON  [R_D2].[PO_NO]=[RD].[PO_NO] ");
//			sb.Append(" AND [R_D2].[PO_LINE_ID]=[RD].[PO_LINE_ID] ");
			sb.Append(" ON  [R_D2].[REF_RCPT_NO]=[R_L_D].[RCPT_NO] ");
			sb.Append(" AND [R_D2].[RCPT_LINE_ID]=[R_L_D].[RCPT_LINE_ID] ");
// 管理番号 B23776 To
			sb.Append(" AND [R_D2].[LOT_NO]=[R_L_D].[LOT_NO] ");
// 管理番号 B21476 To

			//商品
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [PROD] ");
			sb.Append(" ON [PD].[PROD_CODE] = [PROD].[PROD_CODE] ");
			//単位別商品属性
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U_P_ATTR] ");
			sb.Append(" ON  [PD].[PROD_CODE] = [U_P_ATTR].[PROD_CODE]");
			sb.Append(" AND [PD].[UNIT_CODE] = [U_P_ATTR].[UNIT_CODE]");

			wpb.AddFilter(" [RD].[PO_NO]"         , SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter(" [R_L_D].[DELETE_FLG]" , SearchOperator.Equal, "0"   );
			wpb.AddFilter("([R].[RCPT_MODE_TYPE]", SearchOperator.Equal, DBNull.Value);
			wpb.AppendFilter( ConnectionWord.Or,"[R].[RCPT_MODE_TYPE]", SearchOperator.Equal, "1");
			wpb.Append(")");
// 管理番号 K25647 From
//// 管理番号 B21440 From
//			wpb.AddFilter("[PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]) / [U_P_ATTR].[INCLUDE_QT])", SearchOperator.GreaterThan, 0);
//// 管理番号 B21440 To
			wpb.AddFilter("[PD].[PO_QT] - CAST((([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT] - [PD].[PU_RETURN_QT]) / [U_P_ATTR].[INCLUDE_QT]) AS DECIMAL(28, 5))", SearchOperator.GreaterThan, 0);
// 管理番号 K25647 To
// 管理番号 B21476 From
			wpb.AddFilter("[R].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "3");
// 管理番号 B21476 To
			sb.Append(wpb);

			//製造日昇順、ロット番号昇順、入荷番号
			sb.Append(" ORDER BY [LOT].[FAB_DATE] ASC, [R_L_D].[LOT_NO] ASC, [R].[RCPT_DATE] ASC, [R_L_D].[RCPT_NO] ASC");

			return sb.ToString();
		}
		//発注明細(残クローズ)
		private static SqlPString CreatePoCloseDetailString(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			string prodSpec1Name = string.Empty;
			string prodSpec2Name = string.Empty;
			string unitShortName = string.Empty;

			switch (keyColumn.OverseasFlg)
			{
				case OverseasFlg.DOMESTIC:
					prodSpec1Name = "PROD_SPEC_1_NAME";
					prodSpec2Name = "PROD_SPEC_2_NAME";
					unitShortName = "UNIT_SHORT_NAME";
					break;
				case OverseasFlg.OVERSEAS:
					prodSpec1Name = "PROD_SPEC_1_ENG_NAME";
					prodSpec2Name = "PROD_SPEC_2_ENG_NAME";
					unitShortName = "UNIT_ENG_NAME";
					break;
			}

			//在庫管理部門の取得
			sb.Append("DECLARE @STOCK_ADMIN_DEPT_CODE NVARCHAR(10) ");
			sb.Append("SELECT ");
			sb.Append("  @STOCK_ADMIN_DEPT_CODE = ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SC_MS_GetStockDeptCode]"));
			sb.Append("(@MYCOMP_CODE, [DEPT_CODE], GETDATE())");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]"));
			wpb.AddFilter("[PO_NO]", SearchOperator.Equal, keyColumn.SlipNo );
			sb.Append(wpb);

// 管理番号 B11723・B11796 From
			sb.Append(@"
DECLARE @CUR_DIGIT      DECIMAL(1,0)
DECLARE @CUR_ROUND_TYPE NVARCHAR(1)
DECLARE @AMT_ROUND_TYPE NVARCHAR(1)

SELECT
	 @CUR_ROUND_TYPE = [MC].[CUR_FRACTION_ROUND_TYPE]
	,@AMT_ROUND_TYPE = [MC].[AMT_TTL_FRACTION_ROUND_TYPE]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[MYCOMP]")).Append(@" AS [MC]
WHERE [MC].[MYCOMP_CODE] = @MYCOMP_CODE

SELECT @CUR_DIGIT = [C].[DECIMAL_DIGIT]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(@" AS [PO]
INNER JOIN ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CUR]")).Append(@" AS [C]
	ON [PO].[CUR_CODE] = [C].[CUR_CODE]
WHERE [PO].[PO_NO] = @SLIP_NO
");
// 管理番号 B11723・B11796 To

			wpb = new WherePhraseBuilder();

			sb.Append("SELECT ");
			sb.Append(" [PD].[PO_LINE_ID]                         AS [PU_LINE_ID]"                );
			sb.Append(",[PD].[PO_LINE_NO]                         AS [PU_LINE_NO]"                );
			sb.Append(",[PD].[PO_NO]                              AS [PO_NO]"                     );
			sb.Append(",[PD].[PO_LINE_ID]                         AS [PO_LINE_ID]"                );
			sb.Append(",NULL                                      AS [RCPT_NO]"                   );
			sb.Append(",NULL                                      AS [RCPT_LINE_ID]"              );
			sb.Append(",NULL                                      AS [SA_NO]"                     );
			sb.Append(",NULL                                      AS [SA_LINE_ID]"                );
			sb.Append(",[PD].[WH_CODE]                            AS [WH_CODE]"                   );
			sb.Append(",[W].[WH_SHORT_NAME]                       AS [WH_SHORT_NAME]"             );
			sb.Append(",[PD].[PROD_CODE]                          AS [PROD_CODE]"                 );
			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_PO_NAME]"              );
			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_SHORT_NAME]"           );
			sb.Append(",[PD].[PROD_PO_NAME]                       AS [PROD_NAME]"                 );
			sb.Append(",[PD].[PROD_TYPE]                          AS [PROD_TYPE]"                 );
			sb.Append(",[PROD].[DISP_CONTROL_TYPE]                AS [DISP_CONTROL_TYPE]"         );
			sb.Append(",[PROD].[STOCK_ADMIN_FLG]                  AS [STOCK_ADMIN_FLG]"           );
			sb.Append(",[PROD].[LOT_ADMIN_FLG]                    AS [LOT_ADMIN_FLG]"             );
// 管理番号 K25322 From
			sb.Append(",[PROD].[LOT_STOCK_VALUATION_FLG]          AS [LOT_STOCK_VALUATION_FLG]"   );
// 管理番号 K25322 To
			sb.Append(",[U].[QT_DECIMAL_USE_FLG]                  AS [QT_DECIMAL_USE_FLG]"        );
			sb.Append(",[PD].[CTAX_CALC_TYPE]                     AS [CTAX_CALC_TYPE]"            );
// 管理番号 K24789 From
//// 管理番号 B24787 From
////// 管理番号 B18904 From
//////			sb.Append(",[PROD].[CTAX_RATE_CODE]                   AS [CTAX_RATE_CODE]"            );
////			if(keyColumn.OverseasFlg == "1")
////			{
////				sb.Append(",'0'									  AS [CTAX_RATE_CODE]"            );
////			}
////			else
////			{
////				sb.Append(",[PROD].[CTAX_RATE_CODE]               AS [CTAX_RATE_CODE]"            );
////			}
////// 管理番号 B18904 To
//			sb.Append(",[PROD].[CTAX_RATE_CODE]                   AS [CTAX_RATE_CODE]"            );
//// 管理番号 B24787 To
			sb.Append(",[PD].[CTAX_TYPE_CODE]                     AS [CTAX_TYPE_CODE]"            );
			sb.Append(",[PD].[CTAX_RATE_CODE]                     AS [CTAX_RATE_CODE]"            );
// 管理番号 K24789 To
			sb.Append(",[PD].[CTAX_RATE]                          AS [CTAX_RATE]"                 );
			sb.Append(",[PD].[PROD_SPEC_1_CODE]                   AS [PROD_SPEC_1_CODE]"          );
			sb.Append(",[PS1].[").Append(prodSpec1Name).Append("] AS [PROD_SPEC_1_NAME]"          );
			sb.Append(",[PD].[PROD_SPEC_2_CODE]                   AS [PROD_SPEC_2_CODE]"          );
			sb.Append(",[PS2].[").Append(prodSpec2Name).Append("] AS [PROD_SPEC_2_NAME]"          );
			sb.Append(",[PD].[PU_PLAN_PRICE]                      AS [PU_PLAN_PRICE]"             );
			sb.Append(",NULL                                      AS [STOCK_UNIT_STD_SELL_PRICE]" );
			sb.Append(",[PD].[UNIT_CODE]                          AS [UNIT_CODE]"                 );
			sb.Append(",[U].[").Append(unitShortName).Append("]   AS [UNIT_SHORT_NAME]"           );
			//仕入数量の計算：
			sb.Append(",[R_D].[RCPT_DTIL_SUM_PU_QT]               AS [PU_QT]"                     );
			sb.Append(",[R_D].[RCPT_DTIL_SUM_PU_QT]               AS [INIT_PU_QT]"                );
			sb.Append(",0                                         AS [TRANSIT_RCPT_QT]"           );
			sb.Append(",'1'                                       AS [RCPT_INPUT_NO_NEED_FLG]"    );

			//上限値
			sb.Append(",[R_D].[RCPT_DTIL_SUM_PU_QT]               AS [UPPER_LIMIT_PU_QT] "        );
			sb.Append(",ISNULL([ST].[VALID_QT],0)                 AS [VALID_QT]"                  );
			sb.Append(",[R_D].[RCPT_DTIL_SUM_PU_QT] * [U].[INCLUDE_QT] AS [STOCK_UNIT_PU_QT]"     );
			sb.Append(",[R_D].[RCPT_DTIL_SUM_PU_QT] * [U].[INCLUDE_QT] AS [STOCK_UNIT_PO_PU_QT]"  );
			sb.Append(",0                                         AS [STOCK_UNIT_PO_ALLOC_PU_QT]" );
			sb.Append(",[PD].[PO_PRICE]                           AS [PU_PRICE]"                  );
			sb.Append(",[PD].[PO_PRICE]                           AS [INIT_PU_PRICE]"             );
			sb.Append(",[PD].[DISC_FLG]                           AS [DISC_FLG]"                  );
// 管理番号 B13878 From
			sb.Append(",[PD].[PRICE_UNDECIDED_FLG]				  AS [PRICE_UNDECIDED_FLG]"		  );
			//sb.Append(",'0'										  AS [PRICE_UNDECIDED_FLG]"		  );
// 管理番号 B13878 To
			sb.Append(",NULL                                      AS [LINE_REMARKS_CODE]"         );
// 管理番号 K24274 From
//			sb.Append(",NULL                                      AS [LINE_REMARKS]"              );
			sb.Append(",CASE WHEN [SLIP_TYPE].[REMARKS_COORDINATION_TYPE] = '1' ");
			sb.Append("		THEN [PD].[LINE_REMARKS] ");
			sb.Append("		ELSE NULL ");
			sb.Append("	END AS [LINE_REMARKS] ");
// 管理番号 K24274 To
// 管理番号K27525 From
			sb.Append(",[PD].[BOOK_DEDUCTION_REASON_CODE]         AS [BOOK_DEDUCTION_REASON_CODE]");
			sb.Append(",[BDR].[BOOK_DEDUCTION_REASON_NAME]        AS [BOOK_DEDUCTION_REASON_NAME]");
// 管理番号K27525 To
// 管理番号 K16671 From
			sb.Append(",[PD].[REF_CODE]                           AS [REF_CODE]"                  );
// 管理番号 K16671 To
			sb.Append(",[U].[INCLUDE_QT]                          AS [INCLUDE_QT]"                );
			sb.Append(",0                                         AS [DTIL_AMT]"                  );
			sb.Append(",0                                         AS [ETAX_AMT]"                  );
			sb.Append(",0                                         AS [ITAX_AMT]"                  );
			sb.Append(",'0'                                       AS [PRICE_UPDATE_FLG]"          );
// 管理番号 K24278 From
//// 管理番号 B11723・B11796 From
////			sb.Append(",[R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE] AS [PU_MONEY]"              );
//			sb.Append(",").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound]"));
//			sb.Append("([R_D].[RCPT_DTIL_SUM_PU_QT] * [PD].[PO_PRICE], @CUR_DIGIT, @AMT_ROUND_TYPE) AS [PU_MONEY]");
//// 管理番号 B11723・B11796 To
			sb.Append(", CASE WHEN @ImposeFlg = '0' AND [PD].[CTAX_CALC_TYPE] = 'I' THEN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "[CM_MS_GetRound]([PD].[PO_PRICE]*[R_D].[RCPT_DTIL_SUM_PU_QT],@CUR_DIGIT,@AMT_ROUND_TYPE) - "));
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "[CM_MS_GetRound]("));
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "[CM_MS_GetRound]([PD].[PO_PRICE]*[R_D].[RCPT_DTIL_SUM_PU_QT],@CUR_DIGIT,@AMT_ROUND_TYPE) * "));
			sb.Append("([PD].[CTAX_RATE]/100)/(1+([PD].[CTAX_RATE]/100)),@CUR_DIGIT, @CtaxRoundType) ELSE ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "[CM_MS_GetRound]([PD].[PO_PRICE]*[R_D].[RCPT_DTIL_SUM_PU_QT],@CUR_DIGIT,@AMT_ROUND_TYPE) END AS [PU_MONEY]"));
// 管理番号 K24278 To
			sb.Append(",[PROD].[PROD_NAME_CORRECT_ALLOW_FLG]      AS [PROD_NAME_CORRECTION_FLG]"  );
			sb.Append(",'0'                                       AS [PROD_EDIT_FLG]"             );
			//入荷済判定
			sb.Append(",'1'                                       AS [IS_RCPT_EXECUTE]"           );
			sb.Append(",'R'                                       AS [ROW_STATE]"                 );
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputDetailCommon, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PD", "CUSTOM_ITEM_TAG", "@PU_DATE", null, false);
// 管理番号K27057 To

			//発注
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(" AS [PO]");
			//発注明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO_DTIL]")).Append(" AS [PD]");
			sb.Append(" ON [PO].[PO_NO] = [PD].[PO_NO]");
			//入荷明細サマリ
			sb.Append(" INNER JOIN ");
			sb.Append(" ( ");
			sb.Append("    SELECT ");
			sb.Append("    [R_D].[PO_NO]        AS [PO_NO], "       );
			sb.Append("    [R_D].[PO_LINE_ID]   AS [PO_LINE_ID], "  );
			sb.Append("    SUM([R_D].[RCPT_QT]) - SUM([R_D].[RCPT_RETURN_QT]) - SUM([R_D].[PU_QT]) AS [RCPT_DTIL_SUM_PU_QT] ");
			sb.Append("    FROM ");
// 管理番号 B21476 From
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT] ");
//			sb.Append("    INNER JOIN  ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [R_D] ");
//			sb.Append("    ON  [RCPT].[RCPT_NO] = [R_D].[RCPT_NO]");
//			WherePhraseBuilder wpbSub = new  WherePhraseBuilder();
//			wpbSub.AddFilter("[RCPT].[RCPT_MODE_TYPE]"   , SearchOperator.Equal, "1");
//			wpbSub.AddFilter("[RCPT].[DELETE_FLG]"       , SearchOperator.NotEqual, "1");
//			wpbSub.AddFilter("[R_D].[PO_NO]"             , SearchOperator.Equal   , keyColumn.SlipNo);
//			wpbSub.AddFilter("[R_D].[DELETE_FLG]"        , SearchOperator.NotEqual, "1");
//			sb.Append(wpbSub);
			sb.Append("       ( ");
			sb.Append("          SELECT ");
			sb.Append("            [RCPT_D].[PO_NO] ");
			sb.Append("            ,[RCPT_D].[PO_LINE_ID] ");
			sb.Append("            ,[RCPT_D].[RCPT_QT] ");
			sb.Append("            ,[RCPT_D].[RCPT_RETURN_QT] ");
			sb.Append("            ,[RCPT_D].[PU_QT] ");
			sb.Append("          FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT] ");
			sb.Append("          INNER JOIN  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RCPT_D] ");
			sb.Append("          ON  [RCPT_D].[RCPT_NO] = [RCPT].[RCPT_NO]");
			WherePhraseBuilder wpbSub = new WherePhraseBuilder();
			wpbSub.AddFilter("     [RCPT].[RCPT_MODE_TYPE]", SearchOperator.Equal, "1");
			wpbSub.AddFilter("     [RCPT].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub.AddFilter("     [RCPT].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "3");
			wpbSub.AddFilter("     [RCPT_D].[PO_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpbSub.AddFilter("     [RCPT_D].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub);
			sb.Append("          UNION ALL ");
			sb.Append("          SELECT ");
			sb.Append("            [RCPT_D].[PO_NO] ");
			sb.Append("            ,[RCPT_D].[PO_LINE_ID] ");
			sb.Append("            ,[RCPT_D].[RCPT_QT] ");
			sb.Append("            ,[RCPT_D].[RCPT_RETURN_QT] ");
			sb.Append("            ,[RCPT_D].[PU_QT] ");
			sb.Append("          FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT] ");
			sb.Append("          INNER JOIN  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RCPT_D] ");
			sb.Append("          ON  [RCPT_D].[RCPT_NO] = [RCPT].[RCPT_NO]");
			WherePhraseBuilder wpbSub2 = new WherePhraseBuilder();
			wpbSub2.AddFilter("     [RCPT].[RCPT_MODE_TYPE]", SearchOperator.Equal, "2");
			wpbSub2.AddFilter("     [RCPT].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub2.AddFilter("     [RCPT].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "1");
			wpbSub2.AddFilter("     [RCPT_D].[PO_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpbSub2.AddFilter("     [RCPT_D].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub2);
			sb.Append("       ) AS [R_D] ");
// 管理番号 B21476 To
			sb.Append(" GROUP BY ");
			sb.Append(" [R_D].[PO_NO], "       );
			sb.Append(" [R_D].[PO_LINE_ID] "   );
			sb.Append(" HAVING ");
			sb.Append(" SUM([R_D].[RCPT_QT]) - SUM([R_D].[RCPT_RETURN_QT]) - SUM([R_D].[PU_QT]) > 0 ");
			sb.Append(" ) AS [R_D] ");
			sb.Append(" ON  [PD].[PO_NO]      = [R_D].[PO_NO]");
			sb.Append(" AND [PD].[PO_LINE_ID] = [R_D].[PO_LINE_ID]");

			//商品
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [PROD]");
			sb.Append(" ON  [PD].[PROD_CODE]   = [PROD].[PROD_CODE]");
			sb.Append(" AND [PROD].[PROD_TYPE] = '0' ");//通常商品のみ
			//商品規格1
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_1]")).Append(" AS [PS1]");
			sb.Append(" ON [PD].[PROD_SPEC_1_CODE] = [PS1].[PROD_SPEC_1_CODE]");
			//商品規格2
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_2]")).Append(" AS [PS2]");
			sb.Append(" ON [PD].[PROD_SPEC_2_CODE] = [PS2].[PROD_SPEC_2_CODE]");
			//倉庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[WH]")).Append(" AS [W]");
			sb.Append(" ON [PD].[WH_CODE] = [W].[WH_CODE]");
			//単位別商品属性
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
			sb.Append(" ON [PD].[PROD_CODE] = [U].[PROD_CODE]");
			sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE] ");
			//在庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[STOCK]")).Append(" AS [ST]");
			sb.Append(" ON  [PD].[WH_CODE]          = [ST].[WH_CODE] ");
			sb.Append(" AND [PD].[PROD_CODE]        = [ST].[PROD_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [ST].[PROD_SPEC_1_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [ST].[PROD_SPEC_2_CODE] ");
			sb.Append(" AND [ST].[DEPT_CODE]        = @STOCK_ADMIN_DEPT_CODE ");
// 管理番号 B13877 From
			if (keyColumn.ProjectStockAdminUseFlg)
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ISNULL([PO].[PROJ_CODE],'')");
				sb.Append(" AND [ST].[PROJ_SBNO] = ISNULL([PO].[PROJ_SBNO],'')");
			}
			else
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ''");
				sb.Append(" AND [ST].[PROJ_SBNO] = ''");
			}
// 管理番号 B13877 To
// 管理番号K27525 From
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[BOOK_DEDUCTION_REASON]")).Append(" AS [BDR]");
			sb.Append(" ON [BDR].[BOOK_DEDUCTION_REASON_CODE] = [PD].[BOOK_DEDUCTION_REASON_CODE] ");
// 管理番号K27525 To
// 管理番号 K24274 From
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SLIP_TYPE]"));
			sb.Append(" ON [SLIP_TYPE].[SLIP_TYPE_CODE] = 'SM3' ");
// 管理番号 K24274 To

			wpb.AddFilter("[PD].[PO_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[PD].[DELETE_FLG]", SearchOperator.Equal, "0");
// 管理番号 K25647 From
//			wpb.AddFilter("[PD].[PO_QT] - (([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT])", SearchOperator.GreaterThan, 0);
			wpb.AddFilter("[PD].[PO_QT] - CAST((([PD].[RCPT_PU_QT] + [PD].[DIRECT_PU_QT]) / [U].[INCLUDE_QT]) AS DECIMAL(28, 5))", SearchOperator.GreaterThan, 0);
// 管理番号 K25647 To
			sb.Append(wpb);
			sb.Append("ORDER BY [PD].[PO_LINE_NO] ASC ");

			return sb.ToSqlPString();	// 管理番号K27230
		}
		//入荷
		private static SqlCommandWrapper CreateRcptHeaderCommand(CommonData commonData,SqlConnection cn,IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append(" SELECT ");
			sb.Append(" NULL                                AS [PU_NO]"                         );
			sb.Append(",[PO].[PO_NAME]                      AS [PU_NAME]"                       );
			sb.Append(",GETDATE()                           AS [PU_DATE]"                       );
// 管理番号 K24789 From
//// 管理番号 K16590 From
//			sb.Append(",GETDATE()                           AS [DEAL_DATE]"                     );
//// 管理番号 K16590 To
			if (keyColumn.DateAdminType == "1")		// 日付管理区分が「取引日管理基準」
			{
				sb.Append(",CASE [PO].[BOOK_BASIS_TYPE] WHEN N'A' ");
				sb.Append("     THEN [PO].[CTAX_BASIS_DATE]"       );
				sb.Append("     ELSE GETDATE() "                   );
				sb.Append("	END                             AS [DEAL_DATE]"                     );
			}
			else
			{
				sb.Append(",GETDATE()                       AS [DEAL_DATE]"                     );
			}
// 管理番号 K24789 To
			sb.Append(",[PO].[PO_NO]                        AS [PO_NO]"                         );
			sb.Append(",[RCPT].[RCPT_NO]                    AS [RCPT_NO]"                       );
			// 管理番号 B13500 From
			// 入荷参照かつ仕入返品
			if (keyColumn.ParamType == "CopyRC" && keyColumn.PuModeType == "2")
			{
				sb.Append(",'2'                                 AS [PU_MODE_TYPE]"                  );
// 管理番号K27058 From
				sb.Append(",@PU_MODE_TYPE_DTIL_CODE				AS [PU_MODE_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			}
			else
			{
				sb.Append(",'1'                                 AS [PU_MODE_TYPE]"                  );
// 管理番号K27058 From
				sb.Append(",[PO].[PO_MODE_TYPE_DTIL_CODE]		AS [PU_MODE_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			}
			sb.Append(",NULL                                AS [REF_PU_NO]"                     );
			sb.Append(",[PO].[CUR_CODE]                     AS [CUR_CODE]"                      );
//管理番号 B13502 From
//			sb.Append(",NULL                                AS [EXCHANGE_TYPE]"                 );
//			sb.Append(",NULL                                AS [EXCHANGE_REZ_NO]"               );
//			sb.Append(",'1'                                 AS [RATE]"                          );
			sb.Append(",[PO].[EXCHANGE_TYPE]                AS [EXCHANGE_TYPE]"                 );
			sb.Append(",[PO].[EXCHANGE_REZ_NO]              AS [EXCHANGE_REZ_NO]"               );
			sb.Append(",[PO].[RATE]		                    AS [RATE]"                          );
//管理番号 B13502 To
			sb.Append(",[PO].[DEPT_CODE]                    AS [DEPT_CODE]"                     );
			sb.Append(",[O].[DEPT_SHORT_NAME]               AS [DEPT_SHORT_NAME]"               );
			sb.Append(",[PO].[ORIGIN_DEPT_CODE]             AS [ORIGIN_DEPT_CODE]"              );
			sb.Append(",[PO].[OLD_DEPT_CODE]                AS [OLD_DEPT_CODE]"                 );
			sb.Append(",[PO].[ORG_CHANGE_ID]                AS [ORG_CHANGE_ID]"                 );
			sb.Append(",NULL                                AS [DATA_MIGRATE_DATETIME]"         );
			sb.Append(",[PO].[EMP_CODE]                     AS [EMP_CODE]"                      );
			sb.Append(",[PO].[PROJ_CODE]                    AS [PROJ_CODE]"                     );
			sb.Append(",[PO].[PROJ_SBNO]                    AS [PROJ_SBNO]"                     );
			sb.Append(",[PO].[SUPL_CODE]                    AS [SUPL_CODE]"                     );
			sb.Append(",[PO].[SUPL_SBNO]                    AS [SUPL_SBNO]"                     );
			sb.Append(",[PO].[TEMP_CODE_FLG]                AS [TEMP_CODE_FLG]"                 );
			sb.Append(",[PO].[SUPL_NAME]                    AS [SUPL_NAME]"                     );
			sb.Append(",[PO].[SUPL_SHORT_NAME]              AS [SUPL_SHORT_NAME]"               );
			sb.Append(",[PO].[SUPL_DEPT_NAME_1]             AS [SUPL_DEPT_NAME_1]"              );
			sb.Append(",[PO].[SUPL_DEPT_NAME_2]             AS [SUPL_DEPT_NAME_2]"              );
			sb.Append(",[PO].[SUPL_COUNTRY_CODE]            AS [SUPL_COUNTRY_CODE]"             );
			sb.Append(",[PO].[SUPL_ZIP]                     AS [SUPL_ZIP]"                      );
			sb.Append(",[PO].[SUPL_STATE]                   AS [SUPL_STATE]"                    );
			sb.Append(",[PO].[SUPL_CITY]                    AS [SUPL_CITY]"                     );
			sb.Append(",[PO].[SUPL_ADDRESS1]                AS [SUPL_ADDRESS1]"                 );
			sb.Append(",[PO].[SUPL_ADDRESS2]                AS [SUPL_ADDRESS2]"                 );
			sb.Append(",[PO].[SUPL_PHONE]                   AS [SUPL_PHONE]"                    );
			sb.Append(",[PO].[SUPL_FAX]                     AS [SUPL_FAX]"                      );
			sb.Append(",[PO].[SUPL_USER_NAME]               AS [SUPL_USER_NAME]"                );
			sb.Append(",[PO].[AC_NO]                        AS [AC_NO]"                         );
			sb.Append(",[PO].[AC_HOLDER]                    AS [AC_HOLDER]"                     );
			sb.Append(",[PO].[AC_TYPE]                      AS [AC_TYPE]"                       );
			sb.Append(",[PO].[BANK_AC_TYPE]                 AS [BANK_AC_TYPE]"                  );
			sb.Append(",[PO].[BANK_COUNTRY_CODE]            AS [BANK_COUNTRY_CODE]"             );
			sb.Append(",[PO].[BANK_CODE]                    AS [BANK_CODE]"                     );
			sb.Append(",[PO].[BANK_BRANCH_CODE]             AS [BANK_BRANCH_CODE]"              );
			sb.Append(",[PO].[DELI_TYPE]                    AS [DELI_TYPE]"                     );
			sb.Append(",[PO].[WH_CODE]                      AS [WH_CODE]"                       );
			sb.Append(",[PO].[DELI_CUST_CODE]               AS [DELI_CUST_CODE]"                );
			sb.Append(",[PO].[DELI_CUST_SBNO]               AS [DELI_CUST_SBNO]"                );
			sb.Append(",[PO].[DELI_PLACE_CODE]              AS [DELI_PLACE_CODE]"               );
			sb.Append(",[PO].[DELI_PLACE_NAME]              AS [DELI_PLACE_NAME]"               );
			sb.Append(",[PO].[DELI_PLACE_COUNTRY_CODE]      AS [DELI_PLACE_COUNTRY_CODE]"       );
			sb.Append(",[PO].[DELI_PLACE_ZIP]               AS [DELI_PLACE_ZIP]"                );
			sb.Append(",[PO].[DELI_PLACE_STATE]             AS [DELI_PLACE_STATE]"              );
			sb.Append(",[PO].[DELI_PLACE_CITY]              AS [DELI_PLACE_CITY]"               );
			sb.Append(",[PO].[DELI_PLACE_ADDRESS1]          AS [DELI_PLACE_ADDRESS1]"           );
			sb.Append(",[PO].[DELI_PLACE_ADDRESS2]          AS [DELI_PLACE_ADDRESS2]"           );
			sb.Append(",[PO].[DELI_PLACE_PHONE]             AS [DELI_PLACE_PHONE]"              );
			sb.Append(",[PO].[DELI_PLACE_FAX]               AS [DELI_PLACE_FAX]"                );
			sb.Append(",[PO].[DELI_PLACE_USER_NAME]         AS [DELI_PLACE_USER_NAME]"          );
			sb.Append(",[PO].[DT_TYPE]                      AS [DT_TYPE]"                       );
			sb.Append(",[PO].[DT1_STTL_MTHD_CODE]           AS [DT1_STTL_MTHD_CODE]"            );
			sb.Append(",[PO].[DT1_BASIS_AMT]                AS [DT1_BASIS_AMT]"                 );
			sb.Append(",[PO].[DT2_STTL_MTHD_CODE]           AS [DT2_STTL_MTHD_CODE]"            );
			sb.Append(",[PO].[DT2_RATIO]                    AS [DT2_RATIO]"                     );
			sb.Append(",[PO].[DT3_STTL_MTHD_CODE]           AS [DT3_STTL_MTHD_CODE]"            );
			sb.Append(",[PO].[DT_SIGHT]                     AS [DT_SIGHT]"                      );
			sb.Append(",NULL                                AS [CUTOFF_DATE]"                   );
// 管理番号 B21977 From
			sb.Append(",NULL                                AS [CUTOFF_FIN_DATE]"               );
// 管理番号 B21977 To
			sb.Append(",NULL                                AS [PYMT_PLAN_DATE]"                );
			sb.Append(",[PO].[DT_NOTE]                      AS [DT_NOTE]"                       );
			sb.Append(",[PO].[DT_CUTOFF_CYCLE_TYPE]         AS [DT_CUTOFF_CYCLE_TYPE]"          );
			sb.Append(",[PO].[DT_CUTOFF_DAY]                AS [DT_CUTOFF_DAY]"                 );
			sb.Append(",[PO].[DT_TERM_MONTH_CNT]            AS [DT_TERM_MONTH_CNT]"             );
			sb.Append(",[PO].[DT_TERM_DAY]                  AS [DT_TERM_DAY]"                   );
// 管理番号 B22191 From
			sb.Append(",[PO_DATE]                           AS [PO_DATE]"                       );
// 管理番号 B22191 To
// 管理番号K27441 From
			sb.Append(",NULL								AS [PO_DEPT_CODE]"					);
// 管理番号K27441 To
			sb.Append(",NULL                                AS [SUPL_BILL_SLIP_NO]"             );
			sb.Append(",[PO].[CANCELED_ORDER_FLG]           AS [CANCELED_ORDER_FLG]"            );
			sb.Append(",[PO].[OVERSEAS_FLG]                 AS [OVERSEAS_FLG]"                  );
			sb.Append(",NULL                                AS [TENOR_CODE]"                    );
			sb.Append(",NULL                                AS [FMONEY_STTL_PERIOD_STT_MONTH]"  );
			sb.Append(",NULL                                AS [FMONEY_STTL_PERIOD_END_MONTH]"  );
			sb.Append(",NULL                                AS [LC_NO]"                         );
// 管理番号 B13878 From
			sb.Append(",'0'									AS [HOLD_FLG]"						);
// 管理番号 B13878 To
			sb.Append(",NULL                                AS [REMARKS_CODE]"                  );
// 管理番号 K24274 From
//			sb.Append(",NULL                                AS [REMARKS]"                       );
			sb.Append(",CASE WHEN [SLIP_TYPE].[REMARKS_COORDINATION_TYPE] = '1' ");
			sb.Append("		THEN SUBSTRING([PO].[REMARKS],1,100) ");
			sb.Append("		ELSE NULL ");
			sb.Append("	END AS [REMARKS] ");
// 管理番号 K24274 To
// 管理番号 B13798 From
			sb.Append(",[PO].[ADMIN_ITEM1]                  AS [ADMIN_ITEM1]"                   );
			sb.Append(",[PO].[ADMIN_ITEM2]                  AS [ADMIN_ITEM2]"                   );
			sb.Append(",[PO].[ADMIN_ITEM3]                  AS [ADMIN_ITEM3]"                   );
// 管理番号 B13798 To
// 管理番号 K20687 From
			sb.Append(",[PO].[BOOK_BASIS_TYPE]				AS [BOOK_BASIS_TYPE]"				);
// 管理番号 K20687 To
// 管理番号K27058 From
			sb.Append(",[PO].[BOOK_BASIS_TYPE_DTIL_CODE]	AS [BOOK_BASIS_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			sb.Append(",'0'                                 AS [OUTLAND_REMITTANCE_FLG]"        );
			sb.Append(",NULL                                AS [INTERNATIONAL_ITEM_NO]"         );
			sb.Append(",NULL                                AS [REMITTANCE_PURPOSE]"            );
			sb.Append(",'0'                                 AS [REMITTANCE_ALLOW_FLG]"          );
			sb.Append(",NULL                                AS [REMITTANCE_ALLOW_NO]"           );
			sb.Append(",NULL                                AS [REMITTANCE_MESSAGE]"            );
// 管理番号 B13500 From
			sb.Append(",'1'									AS [RCPT_INPUT_NO_NEED_FLG]"		);
// 管理番号 B13500 To
			sb.Append(",'1'                                 AS [APPROVAL_STATUS_TYPE]"          );
// 管理番号 K20685 From
			sb.Append(",'0'                                 AS [APPROVAL_CANCEL_FLG]"           );
// 管理番号 K20685 To
			sb.Append(",'0'                                 AS [PU_SLIP_OUTPUT_FLG]"            );
			sb.Append(",0                                   AS [ETAX_DTIL_AMT_TTL]"             );
			sb.Append(",0                                   AS [ITAX_DTIL_AMT_TTL]"             );
			sb.Append(",0                                   AS [NTAX_DTIL_AMT_TTL]"             );
			sb.Append(",0                                   AS [ETAX_AMT_TTL]"                  );
			sb.Append(",0                                   AS [ITAX_AMT_TTL]"                  );
			sb.Append(",0                                   AS [GRAND_TTL]"                     );
			sb.Append(",0                                   AS [KEY_GRAND_TTL]"                 );
			sb.Append(",0                                   AS [KO_AMT]"                        );
			sb.Append(",NULL                                AS [LAST_KO_DATE]"                  );
			sb.Append(",'0'                                 AS [KO_COMPLETE_FLG]"               );
// 管理番号 K16187 From
			sb.Append(",0                                   AS [APPROVED_KO_AMT]"               );
			sb.Append(",'0'                                 AS [DTIL_KO_FLG]"                   );
			sb.Append(",'0'                                 AS [DELETE_ALLOW_FLG]");
// 管理番号 K16187 To
			sb.Append(",0                                   AS [EXCHANGE_GAIN_LOSS_AMT_TTL]"    );
			sb.Append(",NULL                                AS [LAST_EXCHANGE_VALUATION_DATE]"  );
			sb.Append(",'0'                                 AS [EXCHANGE_VALUATION_FIN_FLG]"    );
			sb.Append(",NULL                                AS [PYMT_NO]"                       );
			sb.Append(",'0'                                 AS [CUTOFF_FIN_FLG]"                );
			sb.Append(",'0'                                 AS [CANCEL_FLG]"                    );
			sb.Append(",'0'                                 AS [RED_SLIP_FLG]"                  );
			sb.Append(",NULL                                AS [ORIGIN_PU_NO]"                  );
			sb.Append(",NULL                                AS [OPPOSITE_PU_NO]"                );
			sb.Append(",NULL                                AS [LAST_JRNL_EXEC_DATETIME]"       );
			sb.Append(",'0'                                 AS [JRNL_FIN_FLG]"                  );
// 管理番号 B20818 From
//			sb.Append(",NULL                                AS [PRG_UPDATE_DATETIME]"           );
			sb.Append(",GETDATE()                           AS [PRG_UPDATE_DATETIME]"           );
			sb.Append(",[PO].[PRG_UPDATE_DATETIME]          AS [REF_PRG_UPDATE_DATETIME]"       );
// 管理番号 B20818 To
// 管理番号 K22205 From
            sb.Append(",NULL                                AS [INPUT_EMP_CODE]"                );
// 管理番号 K22205 To
			sb.Append(",[S].[SO_NO]                         AS [SO_NO]"                         );
			sb.Append(",[S].[SO_DATE]                       AS [SO_DATE]"                       );
			sb.Append(",[S].[CUST_SHORT_NAME]               AS [CUST_SHORT_NAME]"               );
// 管理番号 B13569 From
			sb.Append(",CASE [PO].[EXCHANGE_TYPE] WHEN '1' THEN '1' ELSE '0' END AS [REF_PO_EXCHANGE_TYPE]");
// 管理番号 B13569 To
// 管理番号 K24278 From
// 管理番号 K24789 From
//			sb.Append(",[COMP].[CTAX_FRACTION_ROUND_TYPE]	AS [CTAX_FRACTION_ROUND_TYPE]"		);
// 管理番号 K24789 To
			sb.Append(",[SUPL].[CTAX_IMPOSE_FLG]			AS [CTAX_IMPOSE_FLG]"				);
// 管理番号 K24278 To
// 管理番号 K24789 From
			sb.Append(",[PYMT_SUPL].[CTAX_BUILDUP_TYPE]         AS [CTAX_BUILDUP_TYPE]"         );
			sb.Append(",[PYMT_SUPL].[CTAX_FRACTION_ROUND_TYPE]  AS [CTAX_FRACTION_ROUND_TYPE]"  );
// 管理番号 K24789 To
// 管理番号 K25679 From
			sb.Append(",[PO].[PO_ADMIN_NO]                  AS [PO_ADMIN_NO]"                   );
			sb.Append(",NULL                                AS [SUPL_SLIP_NO]"                  );
// 管理番号 K25679 To
// 管理番号 K25680 From
			sb.Append(",NULL                                AS [IMPORT_SLIP_NO]"                );
// 管理番号 K25680 To
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputHeadCommon, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "RCPT", null, null, null);
// 管理番号K27057 To
// 管理番号K27154 From
			sb.Append(",[PO].[DEAL_TYPE_CODE]				AS [DEAL_TYPE_CODE]");
// 管理番号K27154 To
			//入荷
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");
			//発注
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(" AS [PO]");
			sb.Append(" ON [RCPT].[PO_NO] = [PO].[PO_NO]");
			//受注
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SO]")).Append(" AS [S]");
			sb.Append(" ON	[PO].[SO_NO] = [S].[SO_NO]");
			sb.Append(" AND	[S].[DELETE_FLG] <> '1'");
// 管理番号 B13500 From
			//仕入
			// 入荷参照かつ仕入返品
			if (keyColumn.ParamType == "CopyRC" && keyColumn.PuModeType == "2")
			{
				sb.Append(" INNER JOIN ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
				sb.Append(" ON [RCPT].[PO_NO] = [PU].[PO_NO]");
			}
// 管理番号 B13500 To
			//組織図、組織変更
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHART]")).Append(" AS [O]");
			sb.Append(" ON	[PO].[DEPT_CODE] = [O].[DEPT_CODE]");
			sb.Append(" AND	[O].[ORG_CHANGE_ID] = ");
			sb.Append("(");
			sb.Append(" SELECT MAX([ORG_CHANGE].[ORG_CHANGE_ID]) FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHANGE]"));
			sb.Append(" [ORG_CHANGE] ");
// 管理番号 B12528 To
//			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= [PO].[PO_DATE] ");
			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= GETDATE()");
// 管理番号 B12528 To
			sb.Append(")");
// 管理番号 K24274 From
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SLIP_TYPE]"));
			sb.Append(" ON [SLIP_TYPE].[SLIP_TYPE_CODE] = 'SM3' ");
// 管理番号 K24274 To
// 管理番号 K24278 From
// 管理番号 K24789 From
//			//取引先
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[COMP]")).Append(" AS [COMP]");
//			sb.Append(" ON  [PO].[SUPL_CODE] = [COMP].[COMP_CODE] ");
// 管理番号 K24789 To
			//仕入先
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]")).Append(" AS [SUPL]");
			sb.Append(" ON  [PO].[SUPL_CODE] = [SUPL].[SUPL_CODE] ");
			sb.Append(" AND [PO].[SUPL_SBNO] = [SUPL].[SUPL_SBNO] ");
// 管理番号 K24278 To
// 管理番号 K24789 From
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]")).Append(" AS [PYMT_SUPL]");
			sb.Append(" ON  [SUPL].[PYMT_SUPL_CODE] = [PYMT_SUPL].[SUPL_CODE] ");
			sb.Append(" AND [SUPL].[PYMT_SUPL_SBNO] = [PYMT_SUPL].[SUPL_SBNO] ");
// 管理番号 K24789 To

			wpb.AddFilter("[RCPT].[RCPT_NO]"		, SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[RCPT].[RCPT_MODE_TYPE]" , SearchOperator.Equal, "1");
			wpb.AddFilter("[RCPT].[DELETE_FLG]"		, SearchOperator.NotEqual, "1");
// 管理番号 B13500 From
			// 入荷参照かつ仕入返品
			if (keyColumn.ParamType == "CopyRC" && keyColumn.PuModeType == "2")
			{
				wpb.AddFilter("[PO].[OVERSEAS_FLG]"		, SearchOperator.Equal, "1");
				wpb.AddFilter("[PU].[OVERSEAS_FLG]"		, SearchOperator.Equal, "1");
			}
// 管理番号 B13500 To
			sb.Append(wpb);

			//自部門のみの権限の場合
			if (keyColumn.DisclosureUnitType == "D")
			{
				sb.Append(" AND EXISTS (SELECT [DEPT_CODE] FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetLowerDeptLevel](@DeptCode, @Date)"));
				sb.Append(" [TEMP_DEPTLEVEL] WHERE [PO].[DEPT_CODE] = [TEMP_DEPTLEVEL].[DEPT_CODE])");
			}

			return new SqlCommandWrapper(sb.ToSqlPString(),cn);	// 管理番号K27230
		}
		//入荷明細
		private static SqlPString CreateRcptDetailString(CommonData commonData,IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			//在庫管理部門の取得
			sb.Append("DECLARE @STOCK_ADMIN_DEPT_CODE NVARCHAR(10) ");
			sb.Append("SELECT ");
			sb.Append("  @STOCK_ADMIN_DEPT_CODE = ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SC_MS_GetStockDeptCode]"));
			sb.Append("(@MYCOMP_CODE, [PO].[DEPT_CODE], GETDATE())");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(" AS [PO]");
			sb.Append(" ON [RCPT].[PO_NO] = [PO].[PO_NO]");
			wpb.AddFilter("[RCPT].[RCPT_NO]", SearchOperator.Equal, keyColumn.SlipNo );
			sb.Append(wpb);

// 管理番号 B11723・B11796 From
			sb.Append(@"
DECLARE @CUR_DIGIT      DECIMAL(1,0)
DECLARE @CUR_ROUND_TYPE NVARCHAR(1)
DECLARE @AMT_ROUND_TYPE NVARCHAR(1)

SELECT
	 @CUR_ROUND_TYPE = [MC].[CUR_FRACTION_ROUND_TYPE]
	,@AMT_ROUND_TYPE = [MC].[AMT_TTL_FRACTION_ROUND_TYPE]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[MYCOMP]")).Append(@" AS [MC]
WHERE [MC].[MYCOMP_CODE] = @MYCOMP_CODE

SELECT @CUR_DIGIT = [C].[DECIMAL_DIGIT]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(@" AS [RCPT]
INNER JOIN ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(@" AS [PO]
	ON [RCPT].[PO_NO] = [PO].[PO_NO]
INNER JOIN ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CUR]")).Append(@" AS [C]
	ON [PO].[CUR_CODE] = [C].[CUR_CODE]
WHERE [RCPT].[RCPT_NO] = @SLIP_NO
");
// 管理番号 B11723・B11796 To

			wpb = new WherePhraseBuilder();

			sb.Append(" SELECT ");
			sb.Append(" [RD].[RCPT_LINE_ID]                 AS [PU_LINE_ID]"                );
			sb.Append(",[RD].[RCPT_LINE_ID]                 AS [PU_LINE_NO]"                );
			sb.Append(",[RD].[PO_NO]                        AS [PO_NO]"                     );
			sb.Append(",[RD].[PO_LINE_ID]                   AS [PO_LINE_ID]"                );
			sb.Append(",[RD].[RCPT_NO]                      AS [RCPT_NO]"                   );
			sb.Append(",[RD].[RCPT_LINE_ID]                 AS [RCPT_LINE_ID]"              );
			sb.Append(",NULL                                AS [SA_NO]"                     );
			sb.Append(",NULL                                AS [SA_LINE_ID]"                );
			sb.Append(",[PD].[WH_CODE]                      AS [WH_CODE]"                   );
			sb.Append(",[W].[WH_SHORT_NAME]                 AS [WH_SHORT_NAME]"             );
			sb.Append(",[PD].[PROD_CODE]                    AS [PROD_CODE]"                 );
// 管理番号 B19475 From			
//			sb.Append(",[PD].[PROD_SHORT_NAME]              AS [PROD_PO_NAME]"              );
			sb.Append(",[PD].[PROD_PO_NAME] 				AS [PROD_PO_NAME]"              );
// 管理番号 B19475 To						
			sb.Append(",[PD].[PROD_SHORT_NAME]              AS [PROD_SHORT_NAME]"           );
			sb.Append(",[PD].[PROD_PO_NAME]                 AS [PROD_NAME]"                 );
			sb.Append(",[PD].[PROD_TYPE]                    AS [PROD_TYPE]"                 );
			sb.Append(",[PROD].[DISP_CONTROL_TYPE]          AS [DISP_CONTROL_TYPE]"         );
			sb.Append(",[PROD].[STOCK_ADMIN_FLG]            AS [STOCK_ADMIN_FLG]"           );
			sb.Append(",[PROD].[LOT_ADMIN_FLG]              AS [LOT_ADMIN_FLG]"             );
// 管理番号 K25322 From
			sb.Append(",[PROD].[LOT_STOCK_VALUATION_FLG]    AS [LOT_STOCK_VALUATION_FLG]"   );
// 管理番号 K25322 To
			sb.Append(",[U].[QT_DECIMAL_USE_FLG]            AS [QT_DECIMAL_USE_FLG]"        );
			sb.Append(",[PD].[CTAX_CALC_TYPE]               AS [CTAX_CALC_TYPE]"            );
// 管理番号 K24789 From
//			sb.Append(",[PROD].[CTAX_RATE_CODE]             AS [CTAX_RATE_CODE]"            );
			sb.Append(",[PD].[CTAX_TYPE_CODE]               AS [CTAX_TYPE_CODE]"            );
			sb.Append(",[PD].[CTAX_RATE_CODE]               AS [CTAX_RATE_CODE]"            );
// 管理番号 K24789 To
			sb.Append(",[PD].[CTAX_RATE]                    AS [CTAX_RATE]"                 );
			sb.Append(",[PD].[PROD_SPEC_1_CODE]             AS [PROD_SPEC_1_CODE]"          );
			sb.Append(",[PS1].[PROD_SPEC_1_NAME]            AS [PROD_SPEC_1_NAME]"          );
			sb.Append(",[PD].[PROD_SPEC_2_CODE]             AS [PROD_SPEC_2_CODE]"          );
			sb.Append(",[PS2].[PROD_SPEC_2_NAME]            AS [PROD_SPEC_2_NAME]"          );
			sb.Append(",[PD].[PU_PLAN_PRICE]                AS [PU_PLAN_PRICE]"             );
			sb.Append(",NULL                                AS [STOCK_UNIT_STD_SELL_PRICE]" );
			sb.Append(",[PD].[UNIT_CODE]                    AS [UNIT_CODE]"                 );
			sb.Append(",[U].[UNIT_SHORT_NAME]               AS [UNIT_SHORT_NAME]"           );
// 管理番号 B13500 From
			// 入荷参照かつ仕入返品
			if (keyColumn.ParamType == "CopyRC" && keyColumn.PuModeType == "2")
			{
				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT]) AS [PU_QT]" );
				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT]) AS [INIT_PU_QT]");
			}
			else
			{
// 管理番号 B21476 From
//				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - [RD].[PU_QT]) AS [PU_QT]" );
//				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - [RD].[PU_QT]) AS [INIT_PU_QT]");
				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) - [RD].[PU_QT]) AS [PU_QT]");
				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) - [RD].[PU_QT]) AS [INIT_PU_QT]");
// 管理番号 B21476 To
			}
// 管理番号 B13500 To
			sb.Append(",0                                   AS [TRANSIT_RCPT_QT]"           );//入荷参照時は、この値は無視してください
			sb.Append(",'1'                                 AS [RCPT_INPUT_NO_NEED_FLG]"    );//入荷参照時は、この値は無視してください
// 管理番号 B13500 From
			// 入荷参照かつ仕入返品
			if (keyColumn.ParamType == "CopyRC" && keyColumn.PuModeType == "2")
			{
				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT]) AS [UPPER_LIMIT_PU_QT]");//上限値は入荷数を超えない数量
			}
			else
			{
// 管理番号 B21476 From
//				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - [RD].[PU_QT]) AS [UPPER_LIMIT_PU_QT]");//上限値は入荷数を超えない数量
				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) - [RD].[PU_QT]) AS [UPPER_LIMIT_PU_QT]");//上限値は入荷数を超えない数量
// 管理番号 B21476 To
			}
// 管理番号 B13500 To
			sb.Append(",ISNULL([ST].[VALID_QT],0)           AS [VALID_QT]"                  );
// 管理番号 B13500 From
			// 入荷参照かつ仕入返品
			if (keyColumn.ParamType == "CopyRC" && keyColumn.PuModeType == "2")
			{
				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT]) * [U].[INCLUDE_QT] AS [STOCK_UNIT_PU_QT]");
				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT]) * [U].[INCLUDE_QT] AS [STOCK_UNIT_PO_PU_QT]");
			}
			else
			{
// 管理番号 B21476 From
//				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - [RD].[PU_QT]) * [U].[INCLUDE_QT] AS [STOCK_UNIT_PU_QT]");
//				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - [RD].[PU_QT]) * [U].[INCLUDE_QT] AS [STOCK_UNIT_PO_PU_QT]");
				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) - [RD].[PU_QT]) * [U].[INCLUDE_QT] AS [STOCK_UNIT_PU_QT]");
				sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) - [RD].[PU_QT]) * [U].[INCLUDE_QT] AS [STOCK_UNIT_PO_PU_QT]");
// 管理番号 B21476 To
			}
// 管理番号 B13500 To
			sb.Append(",0                                   AS [STOCK_UNIT_PO_ALLOC_PU_QT]" );
			sb.Append(",[PD].[PO_PRICE]                     AS [PU_PRICE]"                  );
			sb.Append(",[PD].[PO_PRICE]                     AS [INIT_PU_PRICE]"             );
			sb.Append(",[PD].[DISC_FLG]                     AS [DISC_FLG]"                  );
// 管理番号 B13878 From
			sb.Append(",[PD].[PRICE_UNDECIDED_FLG]			AS [PRICE_UNDECIDED_FLG]"		);
// 管理番号 B13878 To
			sb.Append(",NULL                                AS [LINE_REMARKS_CODE]"         );
// 管理番号 K24274 From
//			sb.Append(",NULL                                AS [LINE_REMARKS]"              );
			sb.Append(",CASE WHEN [SLIP_TYPE].[REMARKS_COORDINATION_TYPE] = '1' ");
			sb.Append("		THEN [PD].[LINE_REMARKS] ");
			sb.Append("		ELSE NULL ");
			sb.Append("	END AS [LINE_REMARKS] ");
// 管理番号 K24274 To
// 管理番号K27525 From
			sb.Append(",[PD].[BOOK_DEDUCTION_REASON_CODE]   AS [BOOK_DEDUCTION_REASON_CODE]");
			sb.Append(",[BDR].[BOOK_DEDUCTION_REASON_NAME]  AS [BOOK_DEDUCTION_REASON_NAME]");
// 管理番号K27525 To
			sb.Append(",[U].[INCLUDE_QT]                    AS [INCLUDE_QT]"                );
			sb.Append(",0                                   AS [DTIL_AMT]"                  );
			sb.Append(",0                                   AS [ETAX_AMT]"                  );
			sb.Append(",0                                   AS [ITAX_AMT]"                  );
			sb.Append(",'0'                                 AS [PRICE_UPDATE_FLG]"          );
// 管理番号 K24278 From
//// 管理番号 B11723・B11796 From
////			sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - [RD].[PU_QT]) * [PD].[PO_PRICE] AS [PU_MONEY]");
//			sb.Append(",").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound]"));
//// 管理番号 B21476 From
////			sb.Append("(([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - [RD].[PU_QT]) * [PD].[PO_PRICE], @CUR_DIGIT, @AMT_ROUND_TYPE) AS [PU_MONEY]");
//			sb.Append("(([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) - [RD].[PU_QT]) * [PD].[PO_PRICE], @CUR_DIGIT, @AMT_ROUND_TYPE) AS [PU_MONEY]");
//			// 管理番号 B21476 To
//// 管理番号 B11723・B11796 To
			sb.Append(", CASE WHEN @ImposeFlg = '0' AND [PD].[CTAX_CALC_TYPE] = 'I' THEN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound(([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) - [RD].[PU_QT]) * [PD].[PO_PRICE],@CUR_DIGIT,@AMT_ROUND_TYPE) - "));
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound("));
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound(([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) - [RD].[PU_QT]) * [PD].[PO_PRICE],@CUR_DIGIT,@AMT_ROUND_TYPE) * "));
			sb.Append("([PD].[CTAX_RATE]/100)/(1+([PD].[CTAX_RATE]/100)),@CUR_DIGIT, @CtaxRoundType) ELSE ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode , UnitID.CM, "CM_MS_GetRound(([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) - [RD].[PU_QT]) * [PD].[PO_PRICE],@CUR_DIGIT,@AMT_ROUND_TYPE) END AS [PU_MONEY]"));
// 管理番号 K24278 To
			sb.Append(",[PROD].[PROD_NAME_CORRECT_ALLOW_FLG]    AS [PROD_NAME_CORRECTION_FLG]"  );
			sb.Append(",'0'                                 AS [PROD_EDIT_FLG]"             );
			//入荷済判定
// 管理番号 B21476 From
//			sb.Append(",CASE WHEN [RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] > 0 "              );
			sb.Append(",CASE WHEN [RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) > 0 ");
// 管理番号 B21476 To
			sb.Append("     THEN '1' "                                                      );
			sb.Append("     ELSE '0' "                                                      );
			sb.Append(" END                                 AS [IS_RCPT_EXECUTE]"           );
			sb.Append(",'R'                                 AS [ROW_STATE]"                 );
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputDetailCommon, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "RD", "CUSTOM_ITEM_TAG", "@PU_DATE", null, false);
// 管理番号K27057 To

			//発注明細
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO_DTIL]")).Append(" AS [PD]");
			//発注
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(" AS [PO]");
			sb.Append(" ON [PO].[PO_NO] = [PD].[PO_NO]");
			//入荷明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD]");
			sb.Append(" ON [RD].[PO_NO] = [PD].[PO_NO]");
			sb.Append(" AND [RD].[PO_LINE_ID] = [PD].[PO_LINE_ID]");
			//入荷
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R]");
			sb.Append(  "						ON  [R].[RCPT_NO]        = [RD].[RCPT_NO]"       );
			sb.Append(  "						AND [R].[RCPT_MODE_TYPE] = '1'"                   );
// 管理番号 B21476 From
			//入荷返品明細サマリ(未承認)
			sb.Append(" LEFT OUTER JOIN ( ");
			sb.Append("                   SELECT ");
			sb.Append("                     [R].[REF_RCPT_NO] ");
			sb.Append("                     ,[RD].[PO_LINE_ID] ");
			sb.Append("                     ,SUM([RD].[RCPT_QT])*-1 AS [RCPT_RETURN_QT] ");
			sb.Append("                   FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R]");
			sb.Append("                   INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD]");
			sb.Append("                   ON [RD].[RCPT_NO]=[R].[RCPT_NO] ");
			WherePhraseBuilder wpbSub = new WherePhraseBuilder();
			wpbSub.AddFilter("            [R].[REF_RCPT_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpbSub.AddFilter("            [R].[RCPT_MODE_TYPE]", SearchOperator.Equal, "2");
			wpbSub.AddFilter("            [R].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "1");
			wpbSub.AddFilter("            [R].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub.AddFilter("            [RD].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub);
			sb.Append("                   GROUP BY [R].[REF_RCPT_NO],[RD].[PO_LINE_ID] ");
			sb.Append(" ) AS [RD2] ");
			sb.Append(" ON  [RD2].[REF_RCPT_NO]=[RD].[RCPT_NO] ");
			sb.Append(" AND [RD2].[PO_LINE_ID]=[RD].[PO_LINE_ID] ");
// 管理番号 B21476 To

			//商品
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [PROD]");
			sb.Append(" ON  [PD].[PROD_CODE]   = [PROD].[PROD_CODE]");
			sb.Append(" AND [PROD].[PROD_TYPE] = '0' ");//通常商品のみ
			//商品規格1
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_1]")).Append(" AS [PS1]");
			sb.Append(" ON [PD].[PROD_SPEC_1_CODE] = [PS1].[PROD_SPEC_1_CODE]");
			//商品規格2
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_2]")).Append(" AS [PS2]");
			sb.Append(" ON [PD].[PROD_SPEC_2_CODE] = [PS2].[PROD_SPEC_2_CODE]");
			//倉庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[WH]")).Append(" AS [W]");
			sb.Append(" ON [PD].[WH_CODE] = [W].[WH_CODE]");
			//単位別商品属性
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
			sb.Append(" ON [PD].[PROD_CODE] = [U].[PROD_CODE]");
			sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE] ");
			//在庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[STOCK]")).Append(" AS [ST]");
			sb.Append(" ON  [PD].[WH_CODE]          = [ST].[WH_CODE] ");
			sb.Append(" AND [PD].[PROD_CODE]        = [ST].[PROD_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [ST].[PROD_SPEC_1_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [ST].[PROD_SPEC_2_CODE] ");
			sb.Append(" AND [ST].[DEPT_CODE]        = @STOCK_ADMIN_DEPT_CODE ");
// 管理番号 B13877 From
			if (keyColumn.ProjectStockAdminUseFlg)
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ISNULL([PO].[PROJ_CODE],'')");
				sb.Append(" AND [ST].[PROJ_SBNO] = ISNULL([PO].[PROJ_SBNO],'')");
			}
			else
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ''");
				sb.Append(" AND [ST].[PROJ_SBNO] = ''");
			}
// 管理番号 B13877 To
// 管理番号K27525 From
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[BOOK_DEDUCTION_REASON]")).Append(" AS [BDR]");
			sb.Append(" ON [BDR].[BOOK_DEDUCTION_REASON_CODE] = [PD].[BOOK_DEDUCTION_REASON_CODE] ");
// 管理番号K27525 To
// 管理番号 K24274 From
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SLIP_TYPE]"));
			sb.Append(" ON [SLIP_TYPE].[SLIP_TYPE_CODE] = 'SM3' ");
// 管理番号 K24274 To

			wpb.AddFilter("[RD].[RCPT_NO]", SearchOperator.Equal, keyColumn.SlipNo);
// 管理番号 B13500 From
			// 入荷参照かつ仕入返品
			if (keyColumn.ParamType == "CopyRC" && keyColumn.PuModeType == "2")
			{
				wpb.AddFilter("[RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT]", SearchOperator.GreaterThan, 0);
			}
			else
			{
// 管理番号 B21476 From
//				wpb.AddFilter("[RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - [RD].[PU_QT]", SearchOperator.GreaterThan, 0);
				wpb.AddFilter("[RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) - [RD].[PU_QT]", SearchOperator.GreaterThan, 0);
// 管理番号 B21476 To
			}
// 管理番号 B13500 To
// 管理番号 K20684 From
			wpb.AddFilter("[R].[PU_STATUS_TYPE]"		, SearchOperator.NotEqual, "8");
// 管理番号 K20684 To
			sb.Append(wpb);
			sb.Append("ORDER BY [RD].[RCPT_LINE_ID] ASC ");

			return sb.ToSqlPString();	// 管理番号K27230
		}
		//入荷ロット明細
		private static string CreateRcptLotDetailString(CommonData commonData,IF_SC_MM_05_KeyColumn keyColumn)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append(" SELECT DISTINCT ");
			sb.Append(" [R_L_D].[RCPT_LINE_ID]        AS [ROW_ID]       ,");
			sb.Append(" [R_L_D].[LOT_NO]              AS [LOT_NO]       ,");
			sb.Append(" [LOT].[FAB_DATE]              AS [FAB_DATE]     ,");
// 管理番号 B22625 From
//			sb.Append(" DATEADD(Day,[PROD].[LOT_VALID_TERM_DAY_CNT]-1 ,[LOT].[FAB_DATE]) AS [TERM_DATE],");
			sb.Append(" CASE WHEN CONVERT(DATETIME,'9998/12/31') - [LOT].[FAB_DATE] < [PROD].[LOT_VALID_TERM_DAY_CNT]-1");
			sb.Append(   " THEN CONVERT(DATETIME,'9998/12/31')");
			sb.Append(   " ELSE DATEADD(Day,[PROD].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE])");
			sb.Append(" END AS [TERM_DATE] ,");
// 管理番号 B22625 To
			sb.Append(" [R_L_D].[RCPT_LOT_ID]         AS [LOT_ID]       ,");
			sb.Append(" '1'                           AS [STOCK_TYPE]   ,");
			sb.Append(" 0                             AS [STOCK_QT]     ,");
// 管理番号 B13500 From
			// 入荷参照かつ仕入返品
			if (keyColumn.ParamType == "CopyRC" && keyColumn.PuModeType == "2")
			{
				sb.Append(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] AS [INIT_QT]      ,");
				sb.Append(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] AS [EDIT_QT]      ,");
// 管理番号 K25322 From
//				sb.Append(" ([R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT]) [U].[INCLUDE_QT] AS [STOCK_UNIT_PU_QT] ,");
// 管理番号 K25322 To
			}
			else
			{
// 管理番号 B21476 From
//				sb.Append(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] - [R_L_D].[PU_QT] AS [INIT_QT]      ,");
//				sb.Append(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] - [R_L_D].[PU_QT] AS [EDIT_QT]      ,");
				sb.Append(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) - [R_L_D].[PU_QT] AS [INIT_QT]      ,");
				sb.Append(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) - [R_L_D].[PU_QT] AS [EDIT_QT]      ,");
// 管理番号 B21476 To
			}
// 管理番号 B13500 To
			sb.Append(" 0                             AS [TRANSIT_RCPT_QT],");
			sb.Append(" [R_L_D].[RCPT_NO]             AS [RCPT_NO]      ,");
			sb.Append(" [R_L_D].[RCPT_LINE_ID]        AS [RCPT_LINE_ID] ,");
			sb.Append(" [R_L_D].[RCPT_LOT_ID]         AS [RCPT_LOT_ID]  ,");
			sb.Append(" [R].[RCPT_DATE]               AS [RCPT_DATE]    ,");
			sb.Append(" NULL                          AS [SA_NO]        ,");
			sb.Append(" NULL                          AS [SA_LINE_ID]   ,");
			sb.Append(" NULL                          AS [SA_LOT_ID]     ");
// 管理番号 K25322 From
			sb.Append(",0                             AS [PO_ALLOC_RCPT_QT]  "); //在庫単位発注引当仕入数量
// 管理番号 K25322 To

			//入荷ロット明細
			sb.Append(" FROM  ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_LOT_DTIL]")).Append(" AS [R_L_D] ");
			//入荷明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD] ");
			sb.Append("  ON [RD].[RCPT_NO]      = [R_L_D].[RCPT_NO] "     );
			sb.Append(" AND [RD].[RCPT_LINE_ID] = [R_L_D].[RCPT_LINE_ID] ");
			//入荷
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R]");
			sb.Append(  "						ON  [R].[RCPT_NO]        = [RD].[RCPT_NO]"       );
			sb.Append(  "						AND [R].[RCPT_MODE_TYPE] = '1'"                   );
// 管理番号 B21476 From
			//入荷返品明細サマリ(未承認)
			sb.Append(" LEFT OUTER JOIN ( ");
			sb.Append("                   SELECT ");
			sb.Append("                     [R].[REF_RCPT_NO] ");
			sb.Append("                     ,[RD].[PO_LINE_ID] ");
			sb.Append("                     ,[RLD].[LOT_NO] ");
			sb.Append("                     ,SUM([RLD].[RCPT_QT])*-1 AS [RCPT_RETURN_QT] ");
			sb.Append("                   FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R]");
			sb.Append("                   INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD]");
			sb.Append("                   ON [RD].[RCPT_NO]=[R].[RCPT_NO] ");
			sb.Append("                   INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_LOT_DTIL]")).Append(" AS [RLD]");
			sb.Append("                   ON  [RLD].[RCPT_NO]=[RD].[RCPT_NO] ");
			sb.Append("                   AND [RLD].[RCPT_LINE_ID]=[RD].[RCPT_LINE_ID] ");
			WherePhraseBuilder wpbSub = new WherePhraseBuilder();
			wpbSub.AddFilter("            [R].[REF_RCPT_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpbSub.AddFilter("            [R].[RCPT_MODE_TYPE]", SearchOperator.Equal, "2");
			wpbSub.AddFilter("            [R].[RCPT_APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "1");
			wpbSub.AddFilter("            [R].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub.AddFilter("            [RD].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpbSub.AddFilter("            [RLD].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			sb.Append(wpbSub);
			sb.Append("                   GROUP BY [R].[REF_RCPT_NO],[RD].[PO_LINE_ID],[RLD].[LOT_NO] ");
			sb.Append(" ) AS [RD2] ");
			sb.Append(" ON  [RD2].[REF_RCPT_NO]=[RD].[RCPT_NO] ");
			sb.Append(" AND [RD2].[PO_LINE_ID]=[RD].[PO_LINE_ID] ");
			sb.Append(" AND [RD2].[LOT_NO]=[R_L_D].[LOT_NO] ");
// 管理番号 B21476 To

			//発注明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO_DTIL]")).Append(" AS [PD] ");
			sb.Append(" ON [RD].[PO_NO]       = [PD].[PO_NO] "     );
			sb.Append(" AND [RD].[PO_LINE_ID] = [PD].[PO_LINE_ID] ");
			//ロット
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[LOT]")).Append(" AS [LOT] ");
			sb.Append(" ON  [R_L_D].[LOT_NO]        = [LOT].[LOT_NO] ");
			sb.Append(" AND [PD].[PROD_CODE]        = [LOT].[PROD_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [LOT].[PROD_SPEC_1_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [LOT].[PROD_SPEC_2_CODE] ");
			//商品
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [PROD] ");
			sb.Append(" ON [PD].[PROD_CODE] = [PROD].[PROD_CODE] ");
			//単位別商品属性
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U_P_ATTR] ");
			sb.Append(" ON  [PD].[PROD_CODE] = [U_P_ATTR].[PROD_CODE]");
			sb.Append(" AND [PD].[UNIT_CODE] = [U_P_ATTR].[UNIT_CODE]");

			wpb.AddFilter(" [R_L_D].[RCPT_NO]"    , SearchOperator.Equal, keyColumn.SlipNo );
// 管理番号 B13500 From
			// 入荷参照かつ仕入返品
			if (keyColumn.ParamType == "CopyRC" && keyColumn.PuModeType == "2")
			{
				wpb.AddFilter(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT]", SearchOperator.GreaterThan, 0 );
			}
			else
			{
// 管理番号 B21476 From
//				wpb.AddFilter(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] - [R_L_D].[PU_QT]", SearchOperator.GreaterThan, 0 );
				wpb.AddFilter(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] - ISNULL([RD2].[RCPT_RETURN_QT],0) - [R_L_D].[PU_QT]", SearchOperator.GreaterThan, 0);
// 管理番号 B21476 To
			}
// 管理番号 B13500 To
// 管理番号 K20684 From
			wpb.AddFilter("[R].[PU_STATUS_TYPE]"		, SearchOperator.NotEqual, "8");
// 管理番号 K20684 To
			wpb.AddFilter(" [R_L_D].[DELETE_FLG]" , SearchOperator.Equal, "0"   );
			sb.Append(wpb);

			//製造日昇順、ロット番号昇順、入荷番号昇順
			sb.Append(" ORDER BY [LOT].[FAB_DATE] ASC, [R_L_D].[LOT_NO] ASC, [R].[RCPT_DATE] ASC, [R_L_D].[RCPT_NO] ASC");

			return sb.ToString();
		}

		//ヘッダデータ設定
		private static void SetHeaderData(CommonData commonData,SqlDataReader dr, IF_SC_MM_05_Base rowData, IF_SC_MM_05_KeyColumn keyColumn)
		{
			if (dr != null && dr.HasRows && dr.Read())
			{
				rowData.PuNo						= dr["PU_NO"].ToString();
				rowData.PuName						= dr["PU_NAME"].ToString();
				rowData.PuDate						= dr["PU_DATE"].ToString();
// 管理番号 K16590 From
				rowData.DealDate					= dr["DEAL_DATE"].ToString();
// 管理番号 K16590 To
				rowData.PoNo						= dr["PO_NO"].ToString();
				rowData.RcptNo						= dr["RCPT_NO"].ToString();
				rowData.PuModeType					= dr["PU_MODE_TYPE"].ToString();
// 管理番号K27058 From
				rowData.PuModeTypeDtilCode			= dr["PU_MODE_TYPE_DTIL_CODE"].ToString();
// 管理番号K27058 To
				rowData.RefPuNo						= dr["REF_PU_NO"].ToString();
// 管理番号 B21177 From
// 管理番号 B22412 From
//				if (keyColumn.RefType == "REF_PU")
				if (keyColumn.RefType == "REF_PU" || keyColumn.RefType == "REF_RETURN_RC")
// 管理番号 B22412 To
				{
					rowData.RefPuDate				= dr["REF_PU_DATE"].ToString();
				}
// 管理番号 B21177 To
				rowData.CurCode						= dr["CUR_CODE"].ToString();
				rowData.ExchangeType				= dr["EXCHANGE_TYPE"].ToString();
				rowData.ExchangeRezNo				= dr["EXCHANGE_REZ_NO"].ToString();
				rowData.Rate						= dr["RATE"].ToString();
				rowData.DeptCode					= dr["DEPT_CODE"].ToString();
				rowData.DeptShortName				= dr["DEPT_SHORT_NAME"].ToString();
				rowData.OriginDeptCode				= dr["ORIGIN_DEPT_CODE"].ToString();
				rowData.OldDeptCode					= dr["OLD_DEPT_CODE"].ToString();
				rowData.OrgChangeId					= dr["ORG_CHANGE_ID"].ToString();
				rowData.DataMigrateDatetime			= dr["DATA_MIGRATE_DATETIME"].ToString();
				rowData.EmpCode						= dr["EMP_CODE"].ToString();
				rowData.ProjCode					= dr["PROJ_CODE"].ToString();
				rowData.ProjSbno					= dr["PROJ_SBNO"].ToString();
				rowData.SuplCode					= dr["SUPL_CODE"].ToString();
				rowData.SuplSbno					= dr["SUPL_SBNO"].ToString();
				rowData.TempCodeFlg					= dr["TEMP_CODE_FLG"].ToString();
				rowData.SuplName					= dr["SUPL_NAME"].ToString();
				rowData.SuplShortName				= dr["SUPL_SHORT_NAME"].ToString();
				rowData.SuplDeptName1				= dr["SUPL_DEPT_NAME_1"].ToString();
				rowData.SuplDeptName2				= dr["SUPL_DEPT_NAME_2"].ToString();
				rowData.SuplCountryCode				= dr["SUPL_COUNTRY_CODE"].ToString();
				rowData.SuplZip						= dr["SUPL_ZIP"].ToString();
				rowData.SuplState					= dr["SUPL_STATE"].ToString();
				rowData.SuplCity					= dr["SUPL_CITY"].ToString();
				rowData.SuplAddress1				= dr["SUPL_ADDRESS1"].ToString();
				rowData.SuplAddress2				= dr["SUPL_ADDRESS2"].ToString();
				rowData.SuplPhone					= dr["SUPL_PHONE"].ToString();
				rowData.SuplFax						= dr["SUPL_FAX"].ToString();
				rowData.SuplUserName				= dr["SUPL_USER_NAME"].ToString();
				rowData.AcNo						= dr["AC_NO"].ToString();
// 管理番号 B22031 From
//				rowData.AcHolder					= dr["AC_HOLDER"].ToString();
// 管理番号 B22031 To
				rowData.AcType						= dr["AC_TYPE"].ToString();
				rowData.BankAcType					= dr["BANK_AC_TYPE"].ToString();
				rowData.BankCountryCode				= dr["BANK_COUNTRY_CODE"].ToString();
				rowData.BankCode					= dr["BANK_CODE"].ToString();
				rowData.BankBranchCode				= dr["BANK_BRANCH_CODE"].ToString();
// 管理番号 B22031 From
				rowData.JapanCountryCode			= keyColumn.JapanCountryCode;
				rowData.AcHolder					= dr["AC_HOLDER"].ToString();
// 管理番号 B22031 To
// 管理番号 K24153 From
//				rowData.DeliType					= dr["DELI_TYPE"].ToString();
//				rowData.WhCode						= dr["WH_CODE"].ToString();
//				rowData.DeliCustCode				= dr["DELI_CUST_CODE"].ToString();
//				rowData.DeliCustSbno				= dr["DELI_CUST_SBNO"].ToString();

				// 海外仕入、かつ海外発注参照の場合、海外発注が参照している受注の得意先コードを納入先コードとして取得
				if (keyColumn.OverseasFlg == OverseasFlg.OVERSEAS && keyColumn.RefType == "PO")
				{
					// 海外発注が受注参照していない
					if (dr["SO_NO"] == DBNull.Value)
					{
						// 海外発注の倉庫が直送を指定
						if (dr["WH_CODE"].ToString() == "99999")
						{
							rowData.DeliType        = "D";
							rowData.WhCode          = string.Empty;
							rowData.DeliCustCode    = dr["DELI_CUST_CODE"].ToString();
							rowData.DeliCustSbno    = dr["DELI_CUST_SBNO"].ToString();
						}
						else
						{
							rowData.DeliType        = "W";
							rowData.WhCode          = dr["WH_CODE"].ToString();
							rowData.DeliCustCode    = string.Empty;
							rowData.DeliCustSbno    = string.Empty;
						}
					}
					// 海外発注が受注参照している
					else
					{
						// 受注の倉庫が直送を指定
						if (dr["SO_WH_CODE"].ToString() == "99999")
						{
							rowData.DeliType        = "D";
							rowData.WhCode          = string.Empty;
							rowData.DeliCustCode    = dr["CUST_CODE"].ToString();
							rowData.DeliCustSbno    = dr["CUST_SBNO"].ToString();
						}
						else
						{
							rowData.DeliType        = "W";
							rowData.WhCode          = dr["SO_WH_CODE"].ToString();
							rowData.DeliCustCode    = string.Empty;
							rowData.DeliCustSbno    = string.Empty;
						}
					}
				}
				else
				{
					rowData.DeliType                = dr["DELI_TYPE"].ToString();
					rowData.WhCode                  = dr["WH_CODE"].ToString();
					rowData.DeliCustCode            = dr["DELI_CUST_CODE"].ToString();
					rowData.DeliCustSbno            = dr["DELI_CUST_SBNO"].ToString();
				}
// 管理番号 K24153 To
				rowData.DeliPlaceCode				= dr["DELI_PLACE_CODE"].ToString();
				rowData.DeliPlaceName				= dr["DELI_PLACE_NAME"].ToString();
				rowData.DeliPlaceCountryCode		= dr["DELI_PLACE_COUNTRY_CODE"].ToString();
				rowData.DeliPlaceZip				= dr["DELI_PLACE_ZIP"].ToString();
				rowData.DeliPlaceState				= dr["DELI_PLACE_STATE"].ToString();
				rowData.DeliPlaceCity				= dr["DELI_PLACE_CITY"].ToString();
				rowData.DeliPlaceAddress1			= dr["DELI_PLACE_ADDRESS1"].ToString();
				rowData.DeliPlaceAddress2			= dr["DELI_PLACE_ADDRESS2"].ToString();
				rowData.DeliPlacePhone				= dr["DELI_PLACE_PHONE"].ToString();
				rowData.DeliPlaceFax				= dr["DELI_PLACE_FAX"].ToString();
				rowData.DeliPlaceUserName			= dr["DELI_PLACE_USER_NAME"].ToString();
				rowData.DtType						= dr["DT_TYPE"].ToString();
				rowData.Dt1SttlMthdCode				= dr["DT1_STTL_MTHD_CODE"].ToString();
				rowData.Dt1BasisAmt					= dr["DT1_BASIS_AMT"].ToString();
				rowData.Dt2SttlMthdCode				= dr["DT2_STTL_MTHD_CODE"].ToString();
				rowData.Dt2Ratio					= dr["DT2_RATIO"].ToString();
				rowData.Dt3SttlMthdCode				= dr["DT3_STTL_MTHD_CODE"].ToString();
				rowData.DtSight						= dr["DT_SIGHT"].ToString();
				rowData.CutoffDate					= dr["CUTOFF_DATE"].ToString();
// 管理番号 B21977 From
				rowData.CutoffFinDate				= dr["CUTOFF_FIN_DATE"].ToString();
// 管理番号 B21977 To
				rowData.PymtPlanDate				= dr["PYMT_PLAN_DATE"].ToString();
				rowData.DtNote						= dr["DT_NOTE"].ToString();
				rowData.DtCutoffCycleType			= dr["DT_CUTOFF_CYCLE_TYPE"].ToString();
				rowData.DtCutoffDay					= dr["DT_CUTOFF_DAY"].ToString();
				rowData.DtTermMonthCnt				= dr["DT_TERM_MONTH_CNT"].ToString();
				rowData.DtTermDay					= dr["DT_TERM_DAY"].ToString();
// 管理番号 B22191 From
				rowData.PoDate		    		    = dr["PO_DATE"].ToString();
// 管理番号 B22191 To
// 管理番号K27441 From
				rowData.PoDeptCode					= dr["PO_DEPT_CODE"].ToString();
// 管理番号K27441 To
				rowData.SuplBillSlipNo				= dr["SUPL_BILL_SLIP_NO"].ToString();
				rowData.CanceledOrderFlg			= dr["CANCELED_ORDER_FLG"].ToString();
				rowData.OverseasFlg					= dr["OVERSEAS_FLG"].ToString();
				rowData.TenorCode					= dr["TENOR_CODE"].ToString();
				//表示上は年月迄
				if (dr["FMONEY_STTL_PERIOD_STT_MONTH"].ToString().Length!=0)
				{
					rowData.FmoneySttlPeriodSttMonth	= ((DateTime)dr["FMONEY_STTL_PERIOD_STT_MONTH"]).ToString("yyyy/MM");
				}
				if (dr["FMONEY_STTL_PERIOD_END_MONTH"].ToString().Length!=0)
				{
					rowData.FmoneySttlPeriodEndMonth	= ((DateTime)dr["FMONEY_STTL_PERIOD_END_MONTH"]).ToString("yyyy/MM");
				}
				rowData.LcNo						= dr["LC_NO"].ToString();
// 管理番号 B13878 From
				rowData.HoldFlg						= dr["HOLD_FLG"].ToString();
// 管理番号 B13878 To
				rowData.RemarksCode					= dr["REMARKS_CODE"].ToString();
				rowData.Remarks						= dr["REMARKS"].ToString();
// 管理番号 B13798 From
				rowData.AdminItem1					= dr["ADMIN_ITEM1"].ToString();
				rowData.AdminItem2					= dr["ADMIN_ITEM2"].ToString();
				rowData.AdminItem3					= dr["ADMIN_ITEM3"].ToString();
// 管理番号 B13798 To
// 管理番号 K20687 From
				rowData.BookBasisType				= dr["BOOK_BASIS_TYPE"].ToString();
// 管理番号 K20687 To
// 管理番号K27058 From
				rowData.BookBasisTypeDtilCode		= dr["BOOK_BASIS_TYPE_DTIL_CODE"].ToString();
// 管理番号K27058 To
				rowData.OutlandRemittanceFlg		= dr["OUTLAND_REMITTANCE_FLG"].ToString()=="1";
				rowData.InternationalItemNo			= dr["INTERNATIONAL_ITEM_NO"].ToString();
				rowData.RemittancePurpose			= dr["REMITTANCE_PURPOSE"].ToString();
				rowData.RemittanceAllowFlg			= dr["REMITTANCE_ALLOW_FLG"].ToString()=="1";
				rowData.RemittanceAllowNo			= dr["REMITTANCE_ALLOW_NO"].ToString();
				rowData.RemittanceMessage			= dr["REMITTANCE_MESSAGE"].ToString();
				rowData.ApprovalStatusType			= dr["APPROVAL_STATUS_TYPE"].ToString();
				rowData.PuSlipOutputFlg				= dr["PU_SLIP_OUTPUT_FLG"].ToString();
				rowData.EtaxDtilAmtTtl				= dr["ETAX_DTIL_AMT_TTL"].ToString();
				rowData.ItaxDtilAmtTtl				= dr["ITAX_DTIL_AMT_TTL"].ToString();
				rowData.NtaxDtilAmtTtl				= dr["NTAX_DTIL_AMT_TTL"].ToString();
				rowData.EtaxAmtTtl					= dr["ETAX_AMT_TTL"].ToString();
				rowData.ItaxAmtTtl					= dr["ITAX_AMT_TTL"].ToString();
// 管理番号 B14028 From
//				rowData.GrandTtl					= dr["GRAND_TTL"].ToString();
//				rowData.KeyGrandTtl					= dr["KEY_GRAND_TTL"].ToString();
// 管理番号 B14028 To
				rowData.KoAmt						= decimal.Parse(dr["KO_AMT"].ToString());
				rowData.LastKoDate					= dr["LAST_KO_DATE"].ToString();
				rowData.KoCompleteFlg				= dr["KO_COMPLETE_FLG"].ToString();
				rowData.ExchangeGainLossAmtTtl		= dr["EXCHANGE_GAIN_LOSS_AMT_TTL"].ToString();
				rowData.LastExchangeValuationDate	= dr["LAST_EXCHANGE_VALUATION_DATE"].ToString();
				rowData.ExchangeValuationFinFlg		= dr["EXCHANGE_VALUATION_FIN_FLG"].ToString();
				rowData.PymtNo						= dr["PYMT_NO"].ToString();
				rowData.CutoffFinFlg				= dr["CUTOFF_FIN_FLG"].ToString();
				rowData.CancelFlg					= dr["CANCEL_FLG"].ToString();
				rowData.RedSlipFlg					= dr["RED_SLIP_FLG"].ToString();
				rowData.OriginPuNo					= dr["ORIGIN_PU_NO"].ToString();
				rowData.OppositePuNo				= dr["OPPOSITE_PU_NO"].ToString();
				rowData.LastJrnlExecDatetime		= dr["LAST_JRNL_EXEC_DATETIME"].ToString();
				rowData.JrnlFinFlg					= dr["JRNL_FIN_FLG"].ToString();
				rowData.SoNo						= dr["SO_NO"].ToString();
				rowData.SoDate						= dr["SO_DATE"].ToString();
				rowData.CustName					= dr["CUST_SHORT_NAME"].ToString();
// 管理番号 B13500 From
				rowData.RcptInputNoNeedFlg			= dr["RCPT_INPUT_NO_NEED_FLG"].ToString();
// 管理番号 B13500 To
// 管理番号 B13569 From
				rowData.RefPoExchangeType			= dr["REF_PO_EXCHANGE_TYPE"].ToString();
// 管理番号 B13569 To
				rowData.ConsistsData                = true;
// 管理番号 B13500 From
				if (keyColumn.RefType == "PU" || keyColumn.RefType == "NONE")
				{
					rowData.TransitRcptQtTtl		= decimal.Parse(dr["TRANSIT_RCPT_QT_TTL"].ToString());
// 管理番号B25370 From
					rowData.ChargeCount = (int)dr["CHARGE_COUNT"];
// 管理番号B25370 To
				}
// 管理番号 B13500 To
// 管理番号 K16187 From
				rowData.ApprovedKoAmt               = decimal.Parse(dr["APPROVED_KO_AMT"].ToString());
				rowData.DtilKoFlg					= dr["DTIL_KO_FLG"].ToString();
				rowData.DeleteAllowFlg				= dr["DELETE_ALLOW_FLG"].ToString();
// 管理番号 K16187 To
// 管理番号 B20818 From
				rowData.UpdateDatetime				= (DateTime)dr["PRG_UPDATE_DATETIME"];
				rowData.RefUpdateDatetime			= (DateTime)dr["REF_PRG_UPDATE_DATETIME"];
// 管理番号 B20818 To
// 管理番号 K22205 From
                rowData.InputEmpCode                = dr["INPUT_EMP_CODE"].ToString();
// 管理番号 K22205 To
// 管理番号 K24278 From
				rowData.CtaxRoundType				= dr["CTAX_FRACTION_ROUND_TYPE"].ToString();
				rowData.ImposeFlg					= dr["CTAX_IMPOSE_FLG"].ToString();
// 管理番号 K24278 To
// 管理番号 K24789 From
				rowData.CtaxBuildupType				= dr["CTAX_BUILDUP_TYPE"].ToString();
// 管理番号 K24789 To
// 管理番号 K25679 From
				rowData.PoAdminNo					= dr["PO_ADMIN_NO"].ToString();
				rowData.SuplSlipNo					= dr["SUPL_SLIP_NO"].ToString();
// 管理番号 K25679 To
// 管理番号 K25680 From
				rowData.ImportSlipNo				= dr["IMPORT_SLIP_NO"].ToString();
				if (rowData.ImportSlipNo.Length != 0) // 取込伝票番号に値が入力されている場合
				{
					rowData.ProcType = rowData.SuplSlipNo.Length == 0 ? "1" : "2" ; // 1：EDI伝票 2:グループ間取引伝票
				}
				else
				{
					rowData.ProcType = "0";     // その他
				}
// 管理番号 K25680 To
// 管理番号K27057 From
				BL_CM_MS_CustomItem.SetSqlData(commonData, BL_CM_MS_CustomItem.InputHead, "SCMM05_PU", BL_CM_MS_CustomItem.Domestic, rowData.CustomItemHead, dr);
// 管理番号K27057 To
// 管理番号K27154 From
				rowData.DealTypeCode				= dr["DEAL_TYPE_CODE"].ToString();
// 管理番号K27154 To
			}
			else
			{
				rowData.ConsistsData = false;
				switch (keyColumn.RefType)
				{
					case "PU":		//仕入修正、仕入コピー
					case "COPY_PU":
					case "NONE":
						rowData.Message = AllegroMessage.SC_MM_05_S02_04;
						break;
					case "REF_PU":	//仕入参照
						rowData.Message = AllegroMessage.SC_MM_05_S02_03;
						break;
					case "PO":		//発注参照
						rowData.Message = AllegroMessage.SC_MM_05_S02_01;
						break;
					case "RCPT":	//入荷参照
						rowData.Message = AllegroMessage.SC_MM_05_S02_02;
						break;
// 管理番号 B19369 From
					case "REF_RETURN_RC":	//海外仕入返品時入荷参照
						rowData.Message = AllegroMessage.SC_MM_05_S04_05;
						break;
// 管理番号 B19369 To
				}
				throw new AllegroException(commonData,ExceptionLevel.Warning,rowData.Message);
			}
			return;
		}

		//預り伝票か否か？
		private static bool IsCommissionSlip(CommonData commonData, SqlConnection cn,IF_SC_MM_05_KeyColumn keyColumn)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();
			bool retult            = false;

			switch (keyColumn.RefType)
			{
				case "RCPT":	//入荷参照
					sb.Append("SELECT ");
					sb.Append(" COUNT(*) AS [COUNT] ");
					sb.Append("FROM ");
					sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]"));
					wpb.AddFilter("[RCPT_NO]"       , SearchOperator.Equal   , keyColumn.SlipNo);
					wpb.AddFilter("[RCPT_MODE_TYPE]", SearchOperator.Equal   , "4");
					wpb.AddFilter("[DELETE_FLG]"    , SearchOperator.NotEqual, "1");
					sb.Append(wpb);
					break;
				case "PO":		//発注参照
				default:
					sb.Append("SELECT ");
					sb.Append(" COUNT(*) AS [COUNT] ");
					sb.Append("FROM ");
					sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]"));
					wpb.AddFilter("[PO_NO]"       , SearchOperator.Equal   , keyColumn.SlipNo);
					wpb.AddFilter("[PO_MODE_TYPE]", SearchOperator.Equal   , "4");
					wpb.AddFilter("[DELETE_FLG]"  , SearchOperator.NotEqual, "1");
					sb.Append(wpb);
					break;
			}

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
			object scl = cm.ExecuteScalar();

			//発注又は、入荷の形態区分により預かり伝票か否か判定する
			if (scl != null)
			{
				int count = (int)scl;
				retult = (count > 0);
			}

			return retult;
		}
		//仕入返品伝票の存在有無
		private static bool IsRefPu(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();
			bool retult            = false;
			int count              = 0;

			//返品伝票が存在するかどうかチェックする
			sb.Append(" SELECT ");
			sb.Append("   COUNT(*) AS [COUNT]");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]"));
			wpb.AddFilter("	[PU_MODE_TYPE]"  , SearchOperator.Equal,"2");
			wpb.AddFilter("	[REF_PU_NO]"     , SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter(" [OPPOSITE_PU_NO]", SearchOperator.Equal, DBNull.Value);
			sb.Append(wpb);

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
			object scl = cm.ExecuteScalar();
			if (scl != null)
			{
				count = (int)scl;
				retult = count > 0;
			}

			return retult;
		}
// 管理番号 B14315 From
		private static bool IsRcptInputNoNeedFlg(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();
			bool retult            = true;

			sb.Append(" SELECT ");
			sb.Append("  [RCPT_INPUT_NO_NEED_FLG] AS [RCPT_INPUT_NO_NEED_FLG]");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]"));
			wpb.AddFilter("	[PU_NO]"     , SearchOperator.Equal, keyColumn.SlipNo);
			sb.Append(wpb);

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
			SqlDataReader dr = null;
			dr = cm.ExecuteReader();
			if (dr.Read())
			{
				retult = dr["RCPT_INPUT_NO_NEED_FLG"].ToString() == "1";
			}
			dr.Close();
			return retult;
		}
// 管理番号 B14315 To

		//発注残のクローズ状態
		private static bool IsPoBalanceClose(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();
			bool retult            = false;

			sb.Append("SELECT");
			sb.Append("  COUNT(*) AS [COUNT] ");
			sb.Append("FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]"));
			wpb.AddFilter(" [PO_NO]"               , SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter(" [PO_BALANCE_CLOSE_FLG]", SearchOperator.Equal, "1");
			wpb.AddFilter(" [DELETE_FLG]"          , SearchOperator.NotEqual, "1");
			sb.Append(wpb);

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
			object scl = cm.ExecuteScalar();

			//発注残クローズか否か判定する
			if (scl != null)
			{
				int count = (int)scl;
				retult = (count > 0);
			}

			return retult;
		}

		//海外取引条件
		public static void SelectOversearsDt(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base rowData)
		{
			SqlCommandWrapper cm = null;	// 管理番号K27230
			SqlDataReader dr = null;

			switch (keyColumn.RefType)
			{
				case "PU":
				case "REF_PU":
// 管理番号 B19369 From
// 管理番号 B21602 From
//				case "REF_RETURN_RC":
// 管理番号 B21602 To
// 管理番号 B19369 To
				case "COPY_PU":
				case "NONE":
					cm = CreatePuOversears(commonData, cn, keyColumn);
//管理番号P18435 From
					DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
					break;
					//発注
				case "PO":
					cm = CreatePoOversears(commonData, cn, keyColumn);
//管理番号P18435 From
					DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
					break;
					//入荷
				case "RCPT":
					cm = CreateRcptOversears(commonData, cn, keyColumn);
//管理番号P18435 From
					DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
					break;
// 管理番号 B21602 From
				case "REF_RETURN_RC":
					cm = CreateRcptReturnOversears(commonData, cn, rowData);
					DBTimeout.setTimeout(cm, commonData);
					break;
// 管理番号 B21602 To
			}

			dr = cm.ExecuteReader();
			if (dr.HasRows)
			{
				int index = 0;
				while(dr.Read())
				{
					rowData.Overseas[index].OverseasSoDtId = dr["OVERSEAS_PU_DT_ID"].ToString();
					rowData.Overseas[index].Ratio          = dr["RATIO"].ToString();
					rowData.Overseas[index].SttlMthdCode   = dr["STTL_MTHD_CODE"].ToString();
					rowData.Overseas[index].UsanceDayCnt   = dr["USANCE_DAY_CNT"].ToString();
					rowData.Overseas[index].SttlTimingCode = dr["STTL_TIMING_CODE"].ToString();
					rowData.Overseas[index].ClctPlanDate   = dr["PYMT_PLAN_DATE"].ToString();
					index++;
				}
			}
			if (dr!=null && !dr.IsClosed)
			{
				dr.Close();
			}
		}

		//海外仕入支払条件
		private static SqlCommandWrapper CreatePuOversears(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append(" SELECT TOP 3 ");
			sb.Append( "[OV].[PU_NO]             AS [SLIP_NO],"          );
			sb.Append( "[OV].[OVERSEAS_PU_DT_ID] AS [OVERSEAS_PU_DT_ID],");
			sb.Append( "[OV].[RATIO]             AS [RATIO], "           );
			sb.Append( "[OV].[STTL_MTHD_CODE]    AS [STTL_MTHD_CODE], "  );
			sb.Append( "[OV].[USANCE_DAY_CNT]    AS [USANCE_DAY_CNT], "  );
			sb.Append( "[OV].[STTL_TIMING_CODE]  AS [STTL_TIMING_CODE]," );
			sb.Append( "[OV].[PYMT_PLAN_DATE]    AS [PYMT_PLAN_DATE]  "  );

			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [P]");
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[OVERSEAS_PU_DT]")).Append(" AS [OV]");
			sb.Append(" ON [P].[PU_NO] = [OV].[PU_NO] ");
			wpb.AddFilter("[OV].[PU_NO]" , SearchOperator.Equal, keyColumn.SlipNo);
			sb.Append(wpb);

			sb.Append(" ORDER BY [OV].[OVERSEAS_PU_DT_ID] ASC");
			return new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
		}

		//海外仕入支払条件(発注参照時)
		private static SqlCommandWrapper CreatePoOversears(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append(" SELECT TOP 3 ");
			sb.Append( "[OV].[PO_NO]             AS [SLIP_NO],"          );
			sb.Append( "[OV].[OVERSEAS_PO_DT_ID] AS [OVERSEAS_PU_DT_ID],");
			sb.Append( "[OV].[RATIO]             AS [RATIO], "           );
			sb.Append( "[OV].[STTL_MTHD_CODE]    AS [STTL_MTHD_CODE], "  );
			sb.Append( "[OV].[USANCE_DAY_CNT]    AS [USANCE_DAY_CNT], "  );
			sb.Append( "[OV].[STTL_TIMING_CODE]  AS [STTL_TIMING_CODE]," );
			sb.Append( "[OV].[PYMT_PLAN_DATE]    AS [PYMT_PLAN_DATE]  "  );

			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(" AS [P]");
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[OVERSEAS_PO_DT]")).Append(" AS [OV]");
			sb.Append(" ON [P].[PO_NO] = [OV].[PO_NO] ");
			wpb.AddFilter("[OV].[PO_NO]" , SearchOperator.Equal, keyColumn.SlipNo);
			sb.Append(wpb);

			sb.Append(" ORDER BY [OV].[OVERSEAS_PO_DT_ID] ASC");
			return new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
		}

		//海外仕入支払条件(入荷参照時)
		private static SqlCommandWrapper CreateRcptOversears(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append(" SELECT TOP 3 ");
			sb.Append( "[OV].[PO_NO]             AS [SLIP_NO],"          );
			sb.Append( "[OV].[OVERSEAS_PO_DT_ID] AS [OVERSEAS_PU_DT_ID],");
			sb.Append( "[OV].[RATIO]             AS [RATIO], "           );
			sb.Append( "[OV].[STTL_MTHD_CODE]    AS [STTL_MTHD_CODE], "  );
			sb.Append( "[OV].[USANCE_DAY_CNT]    AS [USANCE_DAY_CNT], "  );
			sb.Append( "[OV].[STTL_TIMING_CODE]  AS [STTL_TIMING_CODE]," );
			sb.Append( "[OV].[PYMT_PLAN_DATE]    AS [PYMT_PLAN_DATE]  "  );

			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [R]");
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[OVERSEAS_PO_DT]")).Append(" AS [OV]");
			sb.Append(" ON [R].[PO_NO] = [OV].[PO_NO] ");
			wpb.AddFilter("[R].[RCPT_NO]" , SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[R].[RCPT_MODE_TYPE]"   , SearchOperator.Equal, "1");
			sb.Append(wpb);

			sb.Append(" ORDER BY [OV].[OVERSEAS_PO_DT_ID] ASC");
			return new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
		}
#region 管理番号 B19369 海外仕入返品時、入荷参照SQL生成
// 管理番号 B19369 From
		//海外仕入返品（入荷参照）
		private static SqlCommandWrapper CreateRefReturnRcptHeaderCommand(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append("SELECT");
			sb.Append(" NULL                                AS [PU_NO]"                         );
			sb.Append(",[PU].[PU_NAME]                      AS [PU_NAME]"                       );
			sb.Append(",CASE WHEN @PARAM_TYPE <> 'Mod' AND @PARAM_TYPE <> 'View'"               );
			sb.Append("		THEN GETDATE() "                                                    );
			sb.Append("		ELSE [PU].[PU_DATE] "                                               );
			sb.Append(" END                                 AS [PU_DATE]"                       );
// 管理番号 K24789 From
//			// 管理番号 K16590 From
//			sb.Append(",CASE WHEN @PARAM_TYPE <> 'Mod' AND @PARAM_TYPE <> 'View'"               );
//			sb.Append("		THEN GETDATE() "                                                    );
//			sb.Append("		ELSE [PU].[DEAL_DATE] "                                             );
//			sb.Append(" END                                 AS [DEAL_DATE]"                     );
//			// 管理番号 K16590 To
			sb.Append(",[PU].[DEAL_DATE]                    AS [DEAL_DATE]"                     );
// 管理番号 K24789 To
			sb.Append(",NULL                                AS [PO_NO]"                         );
			sb.Append(",[RCPT].[RCPT_NO]                    AS [RCPT_NO]"                       );
			sb.Append(",'2'                                 AS [PU_MODE_TYPE]"                  );
// 管理番号K27058 From
			sb.Append(",@PU_MODE_TYPE_DTIL_CODE				AS [PU_MODE_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			sb.Append(",[PU].[PU_NO]                        AS [REF_PU_NO]"                     );
// 管理番号 B22412 From
			sb.Append(",CASE WHEN @PARAM_TYPE <> 'Mod' AND @PARAM_TYPE <> 'View'"               );
			sb.Append("		THEN [PU].[PU_DATE] "                                               );
			sb.Append("		ELSE GETDATE() "                                                    );
			sb.Append(" END                                 AS [REF_PU_DATE]"                   );
// 管理番号 B22412 To
			sb.Append(",[PU].[CUR_CODE]                     AS [CUR_CODE]"                      );
			sb.Append(",[PU].[EXCHANGE_TYPE]                AS [EXCHANGE_TYPE]"                 );
			sb.Append(",[PU].[EXCHANGE_REZ_NO]              AS [EXCHANGE_REZ_NO]"               );
			sb.Append(",[PU].[RATE]                         AS [RATE]"                          );
			sb.Append(",[PU].[DEPT_CODE]                    AS [DEPT_CODE]"                     );
			sb.Append(",[O].[DEPT_SHORT_NAME]               AS [DEPT_SHORT_NAME]"               );
			sb.Append(",[PU].[ORIGIN_DEPT_CODE]             AS [ORIGIN_DEPT_CODE]"              );
			sb.Append(",[PU].[OLD_DEPT_CODE]                AS [OLD_DEPT_CODE]"                 );
			sb.Append(",[PU].[ORG_CHANGE_ID]                AS [ORG_CHANGE_ID]"                 );
			sb.Append(",[PU].[DATA_MIGRATE_DATETIME]        AS [DATA_MIGRATE_DATETIME]"         );
			sb.Append(",[PU].[EMP_CODE]                     AS [EMP_CODE]"                      );
			sb.Append(",[PU].[PROJ_CODE]                    AS [PROJ_CODE]"                     );
			sb.Append(",[PU].[PROJ_SBNO]                    AS [PROJ_SBNO]"                     );
			sb.Append(",[PU].[SUPL_CODE]                    AS [SUPL_CODE]"                     );
			sb.Append(",[PU].[SUPL_SBNO]                    AS [SUPL_SBNO]"                     );
			sb.Append(",[PU].[TEMP_CODE_FLG]                AS [TEMP_CODE_FLG]"                 );
			sb.Append(",[PU].[SUPL_NAME]                    AS [SUPL_NAME]"                     );
			sb.Append(",[PU].[SUPL_SHORT_NAME]              AS [SUPL_SHORT_NAME]"               );
			sb.Append(",[PU].[SUPL_DEPT_NAME_1]             AS [SUPL_DEPT_NAME_1]"              );
			sb.Append(",[PU].[SUPL_DEPT_NAME_2]             AS [SUPL_DEPT_NAME_2]"              );
			sb.Append(",[PU].[SUPL_COUNTRY_CODE]            AS [SUPL_COUNTRY_CODE]"             );
			sb.Append(",[PU].[SUPL_ZIP]                     AS [SUPL_ZIP]"                      );
			sb.Append(",[PU].[SUPL_STATE]                   AS [SUPL_STATE]"                    );
			sb.Append(",[PU].[SUPL_CITY]                    AS [SUPL_CITY]"                     );
			sb.Append(",[PU].[SUPL_ADDRESS1]                AS [SUPL_ADDRESS1]"                 );
			sb.Append(",[PU].[SUPL_ADDRESS2]                AS [SUPL_ADDRESS2]"                 );
			sb.Append(",[PU].[SUPL_PHONE]                   AS [SUPL_PHONE]"                    );
			sb.Append(",[PU].[SUPL_FAX]                     AS [SUPL_FAX]"                      );
			sb.Append(",[PU].[SUPL_USER_NAME]               AS [SUPL_USER_NAME]"                );
			sb.Append(",[PU].[AC_NO]                        AS [AC_NO]"                         );
			sb.Append(",[PU].[AC_HOLDER]                    AS [AC_HOLDER]"                     );
			sb.Append(",[PU].[AC_TYPE]                      AS [AC_TYPE]"                       );
			sb.Append(",[PU].[BANK_AC_TYPE]                 AS [BANK_AC_TYPE]"                  );
			sb.Append(",[PU].[BANK_COUNTRY_CODE]            AS [BANK_COUNTRY_CODE]"             );
			sb.Append(",[PU].[BANK_CODE]                    AS [BANK_CODE]"                     );
			sb.Append(",[PU].[BANK_BRANCH_CODE]             AS [BANK_BRANCH_CODE]"              );
			sb.Append(",[PU].[DELI_TYPE]                    AS [DELI_TYPE]"                     );
			sb.Append(",[PU].[WH_CODE]                      AS [WH_CODE]"                       );
			sb.Append(",[PU].[DELI_CUST_CODE]               AS [DELI_CUST_CODE]"                );
			sb.Append(",[PU].[DELI_CUST_SBNO]               AS [DELI_CUST_SBNO]"                );
			sb.Append(",[PU].[DELI_PLACE_CODE]              AS [DELI_PLACE_CODE]"               );
			sb.Append(",[PU].[DELI_PLACE_NAME]              AS [DELI_PLACE_NAME]"               );
			sb.Append(",[PU].[DELI_PLACE_COUNTRY_CODE]      AS [DELI_PLACE_COUNTRY_CODE]"       );
			sb.Append(",[PU].[DELI_PLACE_ZIP]               AS [DELI_PLACE_ZIP]"                );
			sb.Append(",[PU].[DELI_PLACE_STATE]             AS [DELI_PLACE_STATE]"              );
			sb.Append(",[PU].[DELI_PLACE_CITY]              AS [DELI_PLACE_CITY]"               );
			sb.Append(",[PU].[DELI_PLACE_ADDRESS1]          AS [DELI_PLACE_ADDRESS1]"           );
			sb.Append(",[PU].[DELI_PLACE_ADDRESS2]          AS [DELI_PLACE_ADDRESS2]"           );
			sb.Append(",[PU].[DELI_PLACE_PHONE]             AS [DELI_PLACE_PHONE]"              );
			sb.Append(",[PU].[DELI_PLACE_FAX]               AS [DELI_PLACE_FAX]"                );
			sb.Append(",[PU].[DELI_PLACE_USER_NAME]         AS [DELI_PLACE_USER_NAME]"          );
			sb.Append(",[PU].[DT_TYPE]                      AS [DT_TYPE]"                       );
			sb.Append(",[PU].[DT1_STTL_MTHD_CODE]           AS [DT1_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT1_BASIS_AMT]                AS [DT1_BASIS_AMT]"                 );
			sb.Append(",[PU].[DT2_STTL_MTHD_CODE]           AS [DT2_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT2_RATIO]                    AS [DT2_RATIO]"                     );
			sb.Append(",[PU].[DT3_STTL_MTHD_CODE]           AS [DT3_STTL_MTHD_CODE]"            );
			sb.Append(",[PU].[DT_SIGHT]                     AS [DT_SIGHT]"                      );
			sb.Append(",[PU].[CUTOFF_DATE]                  AS [CUTOFF_DATE]"                   );
// 管理番号 B21977 From
			sb.Append(",[PU].[CUTOFF_DATE]                  AS [CUTOFF_FIN_DATE]"               );
// 管理番号 B21977 To
			sb.Append(",[PU].[PYMT_PLAN_DATE]               AS [PYMT_PLAN_DATE]"                );
			sb.Append(",[PU].[DT_NOTE]                      AS [DT_NOTE]"                       );
			sb.Append(",[POX].[DT_CUTOFF_CYCLE_TYPE]        AS [DT_CUTOFF_CYCLE_TYPE]"          );
			sb.Append(",[POX].[DT_CUTOFF_DAY]               AS [DT_CUTOFF_DAY]"                 );
			sb.Append(",[POX].[DT_TERM_MONTH_CNT]           AS [DT_TERM_MONTH_CNT]"             );
			sb.Append(",[POX].[DT_TERM_DAY]                 AS [DT_TERM_DAY]"                   );
// 管理番号 B22191 From
			sb.Append(",[POX].[PO_DATE]                     AS [PO_DATE]"                       );
// 管理番号 B22191 To
// 管理番号K27441 From
			sb.Append(",NULL								AS [PO_DEPT_CODE]"					);
// 管理番号K27441 To
			sb.Append(",[PU].[SUPL_BILL_SLIP_NO]            AS [SUPL_BILL_SLIP_NO]"             );
			sb.Append(",[PU].[CANCELED_ORDER_FLG]           AS [CANCELED_ORDER_FLG]"            );
			sb.Append(",[PU].[OVERSEAS_FLG]                 AS [OVERSEAS_FLG]"                  );
			sb.Append(",[PU].[TENOR_CODE]                   AS [TENOR_CODE]"                    );
			sb.Append(",[PU].[FMONEY_STTL_PERIOD_STT_MONTH] AS [FMONEY_STTL_PERIOD_STT_MONTH]"  );
			sb.Append(",[PU].[FMONEY_STTL_PERIOD_END_MONTH] AS [FMONEY_STTL_PERIOD_END_MONTH]"  );
			sb.Append(",[PU].[LC_NO]                        AS [LC_NO]"                         );
			sb.Append(",[PU].[HOLD_FLG]						AS [HOLD_FLG]"						);
			sb.Append(",NULL                                AS [REMARKS_CODE]"                  );
			sb.Append(",NULL                                AS [REMARKS]"                       );
			sb.Append(",[PU].[ADMIN_ITEM1]                  AS [ADMIN_ITEM1]"                   );
			sb.Append(",[PU].[ADMIN_ITEM2]                  AS [ADMIN_ITEM2]"                   );
			sb.Append(",[PU].[ADMIN_ITEM3]                  AS [ADMIN_ITEM3]"                   );
// 管理番号 K20687 From
			sb.Append(",'A'									AS [BOOK_BASIS_TYPE]"				);
// 管理番号 K20687 To
// 管理番号K27058 From
			sb.Append(",[PU].[BOOK_BASIS_TYPE_DTIL_CODE]	AS [BOOK_BASIS_TYPE_DTIL_CODE]"		);
// 管理番号K27058 To
			sb.Append(",[PU].[OUTLAND_REMITTANCE_FLG]       AS [OUTLAND_REMITTANCE_FLG]"        );
			sb.Append(",[PU].[INTERNATIONAL_ITEM_NO]        AS [INTERNATIONAL_ITEM_NO]"         );
			sb.Append(",[PU].[REMITTANCE_PURPOSE]           AS [REMITTANCE_PURPOSE]"            );
			sb.Append(",[PU].[REMITTANCE_ALLOW_FLG]         AS [REMITTANCE_ALLOW_FLG]"          );
			sb.Append(",[PU].[REMITTANCE_ALLOW_NO]          AS [REMITTANCE_ALLOW_NO]"           );
			sb.Append(",[PU].[REMITTANCE_MESSAGE]           AS [REMITTANCE_MESSAGE]"            );
			sb.Append(",[PU].[RCPT_INPUT_NO_NEED_FLG]		AS [RCPT_INPUT_NO_NEED_FLG]"		);
			sb.Append(",[PU].[APPROVAL_STATUS_TYPE]         AS [APPROVAL_STATUS_TYPE]"          );
// 管理番号 K20685 From
			sb.Append(", '0'                                AS [APPROVAL_CANCEL_FLG]"           );
// 管理番号 K20685 To
			sb.Append(",'0'                                 AS [PU_SLIP_OUTPUT_FLG]"            );
			sb.Append(",[PU].[ETAX_DTIL_AMT_TTL]            AS [ETAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[ITAX_DTIL_AMT_TTL]            AS [ITAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[NTAX_DTIL_AMT_TTL]            AS [NTAX_DTIL_AMT_TTL]"             );
			sb.Append(",[PU].[ETAX_AMT_TTL]                 AS [ETAX_AMT_TTL]"                  );
			sb.Append(",[PU].[ITAX_AMT_TTL]                 AS [ITAX_AMT_TTL]"                  );
			sb.Append(",[PU].[GRAND_TTL]                    AS [GRAND_TTL]"                     );
			sb.Append(",[PU].[KEY_GRAND_TTL]                AS [KEY_GRAND_TTL]"                 );
			sb.Append(",0                                   AS [KO_AMT]"                        );
			sb.Append(",NULL                                AS [LAST_KO_DATE]"                  );
			sb.Append(",'0'                                 AS [KO_COMPLETE_FLG]"               );
			sb.Append(",0                                   AS [APPROVED_KO_AMT]"               );
			sb.Append(",'0'                                 AS [DTIL_KO_FLG]"                   );
			sb.Append(",'0'                                 AS [DELETE_ALLOW_FLG]");
			sb.Append(",0                                   AS [EXCHANGE_GAIN_LOSS_AMT_TTL]"    );
			sb.Append(",NULL                                AS [LAST_EXCHANGE_VALUATION_DATE]"  );
			sb.Append(",'0'                                 AS [EXCHANGE_VALUATION_FIN_FLG]"    );
			sb.Append(",NULL                                AS [PYMT_NO]"                       );
			sb.Append(",'0'                                 AS [CUTOFF_FIN_FLG]"                );
			sb.Append(",'0'                                 AS [CANCEL_FLG]"                    );
			sb.Append(",'0'                                 AS [RED_SLIP_FLG]"                  );
			sb.Append(",NULL                                AS [ORIGIN_PU_NO]"                  );
			sb.Append(",NULL                                AS [OPPOSITE_PU_NO]"                );
			sb.Append(",NULL                                AS [LAST_JRNL_EXEC_DATETIME]"       );
			sb.Append(",'0'                                 AS [JRNL_FIN_FLG]"                  );
// 管理番号 B20818 From
//			sb.Append(",NULL                                AS [PRG_UPDATE_DATETIME]"           );
			sb.Append(",GETDATE()                           AS [PRG_UPDATE_DATETIME]"           );
			sb.Append(",[POX].[PRG_UPDATE_DATETIME]         AS [REF_PRG_UPDATE_DATETIME]"       );
// 管理番号 B20818 To
// 管理番号 K22205 From
            sb.Append(",NULL                                AS [INPUT_EMP_CODE]"                );
// 管理番号 K22205 To
			sb.Append(",[S].[SO_NO]                         AS [SO_NO]"                         );
			sb.Append(",[S].[SO_DATE]                       AS [SO_DATE]"                       );
			sb.Append(",[S].[CUST_SHORT_NAME]               AS [CUST_SHORT_NAME]"               );
			sb.Append(",CASE [PU].[EXCHANGE_TYPE] WHEN '1' THEN '1' ELSE '0' END AS [REF_PO_EXCHANGE_TYPE]");
// 管理番号 K24789 From
//// 管理番号 K24278 From
//			sb.Append(",[COMP].[CTAX_FRACTION_ROUND_TYPE]	AS [CTAX_FRACTION_ROUND_TYPE]"		);
//			sb.Append(",[SUPL].[CTAX_IMPOSE_FLG]			AS [CTAX_IMPOSE_FLG]"				);
//// 管理番号 K24278 To
			sb.Append(",[PU].[CTAX_IMPOSE_FLG]              AS [CTAX_IMPOSE_FLG]"				);
			sb.Append(",[PU].[CTAX_BUILDUP_TYPE]            AS [CTAX_BUILDUP_TYPE]"             );
			sb.Append(",[PU].[CTAX_FRACTION_ROUND_TYPE]     AS [CTAX_FRACTION_ROUND_TYPE]"      );
// 管理番号 K24789 To
// 管理番号 K25679 From
			sb.Append(",[PU].[PO_ADMIN_NO]                  AS [PO_ADMIN_NO]"                   );
			sb.Append(",NULL                                AS [SUPL_SLIP_NO]"                  );
// 管理番号 K25679 To
// 管理番号 K25680 From
			sb.Append(",NULL                                AS [IMPORT_SLIP_NO]"                );
// 管理番号 K25680 To
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputHead, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PU", null, null, null);
// 管理番号K27057 To
// 管理番号K27154 From
			sb.Append(",[PU].[DEAL_TYPE_CODE]               AS [DEAL_TYPE_CODE]"                );
// 管理番号K27154 To
			
			sb.Append(" FROM ");
			//入荷
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");
			//仕入
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			sb.Append(" ON  [RCPT].[PU_NO] = [PU].[PU_NO] ");
			//発注
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO]")).Append(" AS [POX]");
			sb.Append(" ON [PU].[PO_NO] = [POX].[PO_NO]");
			//受注
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SO]")).Append(" AS [S]");
			sb.Append(" ON	[POX].[SO_NO] = [S].[SO_NO]");
			sb.Append(" AND	[S].[DELETE_FLG] <> '1'");
			//組織図、組織変更
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHART]")).Append(" AS [O]");
			sb.Append(" ON	[PU].[DEPT_CODE] = [O].[DEPT_CODE]");
			sb.Append(" AND	[O].[ORG_CHANGE_ID] = ");
			sb.Append("(");
			sb.Append(" SELECT MAX([ORG_CHANGE].[ORG_CHANGE_ID]) FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHANGE]"));
			sb.Append(" [ORG_CHANGE] ");
			sb.Append(" WHERE [ORG_CHANGE].[ORG_CHANGE_DATE] <= CASE WHEN [PU].[PU_DATE] < GETDATE() THEN GETDATE() ELSE [PU].[PU_DATE] END");
			sb.Append(")");
// 管理番号 K24789 From
//// 管理番号 K24278 From
//			//取引先
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[COMP]")).Append(" AS [COMP]");
//			sb.Append(" ON  [PU].[SUPL_CODE] = [COMP].[COMP_CODE] ");
//			//仕入先
//			sb.Append(" INNER JOIN ");
//			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[SUPL]")).Append(" AS [SUPL]");
//			sb.Append(" ON  [PU].[SUPL_CODE] = [SUPL].[SUPL_CODE] ");
//			sb.Append(" AND [PU].[SUPL_SBNO] = [SUPL].[SUPL_SBNO] ");
//// 管理番号 K24278 To
// 管理番号 K24789 To

			wpb.AddFilter("[RCPT].[RCPT_NO]"			, SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[RCPT].[DELETE_FLG]"			, SearchOperator.NotEqual, "1");
			wpb.AddFilter("[PU].[OVERSEAS_FLG]"			, SearchOperator.Equal, keyColumn.OverseasFlg);		//海外フラグ
			//返品時
			wpb.AddFilter("[PU].[PU_MODE_TYPE]"			, SearchOperator.Equal, "1");						//仕入形態区分
			wpb.AddFilter("[PU].[APPROVAL_STATUS_TYPE]"	, SearchOperator.Equal, "3");						//承認状況は決済のみ
			wpb.AddFilter("[PU].[OPPOSITE_PU_NO]"		, SearchOperator.Equal, System.DBNull.Value);		//相手仕入番号
			sb.Append(wpb);

			//自部門のみの権限の場合
			if (keyColumn.DisclosureUnitType == "D")
			{
				sb.Append(" AND EXISTS (SELECT [DEPT_CODE] FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetLowerDeptLevel](@DeptCode, @Date)"));
				sb.Append(" [TEMP_DEPTLEVEL] WHERE [PU].[DEPT_CODE] = [TEMP_DEPTLEVEL].[DEPT_CODE])");
			}

			return new SqlCommandWrapper(sb.ToSqlPString(),cn);	// 管理番号K27230
		}
		//海外仕入返品（入荷参照）
		private static SqlPString CreateRefReturnRcptDetailString(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn)	// 管理番号K27230
		{
			RealSqlBuilder sb       = new RealSqlBuilder();	// 管理番号K27230
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			string prodSpec1Name = string.Empty;
			string prodSpec2Name = string.Empty;
			string unitShortName = string.Empty;

			switch (keyColumn.OverseasFlg)
			{
				case OverseasFlg.DOMESTIC:
					prodSpec1Name = "PROD_SPEC_1_NAME";
					prodSpec2Name = "PROD_SPEC_2_NAME";
					unitShortName = "UNIT_SHORT_NAME";
					break;
				case OverseasFlg.OVERSEAS:
					prodSpec1Name = "PROD_SPEC_1_ENG_NAME";
					prodSpec2Name = "PROD_SPEC_2_ENG_NAME";
					unitShortName = "UNIT_ENG_NAME";
					break;
			}

			//在庫管理部門の取得
			sb.Append("DECLARE @STOCK_ADMIN_DEPT_CODE NVARCHAR(10) ");
			sb.Append("SELECT ");
			sb.Append("  @STOCK_ADMIN_DEPT_CODE = ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[SC_MS_GetStockDeptCode]"));
			sb.Append("(@MYCOMP_CODE, [DEPT_CODE], GETDATE())");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");;
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");;
			sb.Append(" ON  [RCPT].[PU_NO]      = [PU].[PU_NO]");
			wpb.AddFilter("[RCPT].[RCPT_NO]", SearchOperator.Equal, keyColumn.SlipNo );
			sb.Append(wpb);

			sb.Append(@"
DECLARE @CUR_DIGIT      DECIMAL(1,0)
DECLARE @CUR_ROUND_TYPE NVARCHAR(1)
DECLARE @AMT_ROUND_TYPE NVARCHAR(1)

SELECT
	 @CUR_ROUND_TYPE = [MC].[CUR_FRACTION_ROUND_TYPE]
	,@AMT_ROUND_TYPE = [MC].[AMT_TTL_FRACTION_ROUND_TYPE]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[MYCOMP]")).Append(@" AS [MC]
WHERE [MC].[MYCOMP_CODE] = @MYCOMP_CODE

SELECT @CUR_DIGIT = [C].[DECIMAL_DIGIT]
FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(@" AS [RCPT]
INNER JOIN ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(@" AS [PU]
	ON [RCPT].[PU_NO] = [PU].[PU_NO]
INNER JOIN ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CUR]")).Append(@" AS [C]
	ON [PU].[CUR_CODE] = [C].[CUR_CODE]
WHERE [RCPT].[RCPT_NO] = @SLIP_NO
");

			wpb = new WherePhraseBuilder();

			sb.Append("SELECT ");
			sb.Append(" [PD].[PU_LINE_ID]                         AS [PU_LINE_ID]"                );
			sb.Append(",[PD].[PU_LINE_NO]                         AS [PU_LINE_NO]"                );
			sb.Append(",[PD].[PO_NO]                              AS [PO_NO]"                     );
			sb.Append(",[PD].[PO_LINE_ID]                         AS [PO_LINE_ID]"                );
			sb.Append(",[RD].[RCPT_NO]                            AS [RCPT_NO]"                   );
			sb.Append(",[RD].[RCPT_LINE_ID]                       AS [RCPT_LINE_ID]"              );
			sb.Append(",[PD].[SA_NO]                              AS [SA_NO]"                     );
			sb.Append(",[PD].[SA_LINE_ID]                         AS [SA_LINE_ID]"                );
			sb.Append(",[PD].[WH_CODE]                            AS [WH_CODE]"                   );
			sb.Append(",[W].[WH_SHORT_NAME]                       AS [WH_SHORT_NAME]"             );
			sb.Append(",[PD].[PROD_CODE]                          AS [PROD_CODE]"                 );
			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_PO_NAME]"              );
			sb.Append(",[PD].[PROD_SHORT_NAME]                    AS [PROD_SHORT_NAME]"           );
			sb.Append(",[PD].[PROD_PO_NAME]                       AS [PROD_NAME]"                 );
			sb.Append(",[PD].[PROD_TYPE]                          AS [PROD_TYPE]"                 );
			sb.Append(",[PROD].[DISP_CONTROL_TYPE]                AS [DISP_CONTROL_TYPE]"         );
			sb.Append(",[PROD].[STOCK_ADMIN_FLG]                  AS [STOCK_ADMIN_FLG]"           );
			sb.Append(",[PROD].[LOT_ADMIN_FLG]                    AS [LOT_ADMIN_FLG]"             );
// 管理番号 K25322 From
			sb.Append(",[PROD].[LOT_STOCK_VALUATION_FLG]          AS [LOT_STOCK_VALUATION_FLG]"   );
// 管理番号 K25322 To
			sb.Append(",[U].[QT_DECIMAL_USE_FLG]                  AS [QT_DECIMAL_USE_FLG]"        );
			sb.Append(",[PD].[CTAX_CALC_TYPE]                     AS [CTAX_CALC_TYPE]"            );
// 管理番号 K24789 From
//			sb.Append(",'0'									  AS [CTAX_RATE_CODE]"            );
			sb.Append(",[PD].[CTAX_TYPE_CODE]                     AS [CTAX_TYPE_CODE]"            );
			sb.Append(",[PD].[CTAX_RATE_CODE]                     AS [CTAX_RATE_CODE]"            );
// 管理番号 K24789 To
			sb.Append(",[PD].[CTAX_RATE]                          AS [CTAX_RATE]"                 );
			sb.Append(",[PD].[PROD_SPEC_1_CODE]                   AS [PROD_SPEC_1_CODE]"          );
			sb.Append(",[PS1].[").Append(prodSpec1Name).Append("] AS [PROD_SPEC_1_NAME]"          );
			sb.Append(",[PD].[PROD_SPEC_2_CODE]                   AS [PROD_SPEC_2_CODE]"          );
			sb.Append(",[PS2].[").Append(prodSpec2Name).Append("] AS [PROD_SPEC_2_NAME]"          );
			sb.Append(",[PD].[PU_PLAN_PRICE]                      AS [PU_PLAN_PRICE]"             );
			sb.Append(",[PD].[STOCK_UNIT_STD_SELL_PRICE]          AS [STOCK_UNIT_STD_SELL_PRICE]" );
			sb.Append(",[PD].[UNIT_CODE]                          AS [UNIT_CODE]"                 );
			sb.Append(",[U].[").Append(unitShortName).Append("]   AS [UNIT_SHORT_NAME]"           );
			sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT])  AS [PU_QT]"                     );
			sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT])  AS [INIT_PU_QT]"                );
			sb.Append(",[PD].[TRANSIT_RCPT_QT] AS [TRANSIT_RCPT_QT]"                              );
			sb.Append(",[PD].[RCPT_INPUT_NO_NEED_FLG] AS [RCPT_INPUT_NO_NEED_FLG]"                );
			sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT]) AS [UPPER_LIMIT_PU_QT]"                            );

			sb.Append(",ISNULL([ST].[VALID_QT],0)                 AS [VALID_QT]"                  );
// 管理番号 B25285 From
//			sb.Append(",[PD].[STOCK_UNIT_PU_QT]                   AS [STOCK_UNIT_PU_QT]"          );
//
//			//2. 在庫単位受注仕入数量の設定ここから
//			//返品時(元の仕入伝票を参照)上限は参照した在庫単位受注売上数量
//			sb.Append(",[PD].[STOCK_UNIT_PO_PU_QT]                AS [STOCK_UNIT_PO_PU_QT]"       );
//			//2. 在庫単位受注売上数量の設定ここまで
			sb.Append(",([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT]) * [U].[INCLUDE_QT] AS [STOCK_UNIT_PU_QT]" );
			sb.Append(",0                                         AS [STOCK_UNIT_PO_PU_QT]"       );
// 管理番号 B25285 To

			sb.Append(",0                                         AS [STOCK_UNIT_PO_ALLOC_PU_QT]" );
			sb.Append(",[PD].[PU_PRICE]                           AS [PU_PRICE]"                  );
			sb.Append(",[PD].[PU_PRICE]                           AS [INIT_PU_PRICE]"             );
			sb.Append(",[PD].[DISC_FLG]                           AS [DISC_FLG]"                  );
			sb.Append(",[PD].[PRICE_UNDECIDED_FLG]				  AS [PRICE_UNDECIDED_FLG]"		  );
			sb.Append(",NULL                                      AS [LINE_REMARKS_CODE]"         );
			sb.Append(",NULL                                      AS [LINE_REMARKS]"              );
// 管理番号K27525 From
			sb.Append(",[PD].[BOOK_DEDUCTION_REASON_CODE]         AS [BOOK_DEDUCTION_REASON_CODE]");
			sb.Append(",[BDR].[BOOK_DEDUCTION_REASON_NAME]        AS [BOOK_DEDUCTION_REASON_NAME]");
// 管理番号K27525 To
			sb.Append(",[U].[INCLUDE_QT]                          AS [INCLUDE_QT]"                );
			sb.Append(",[PD].[DTIL_AMT]                           AS [DTIL_AMT]"                  );
			sb.Append(",[PD].[ETAX_AMT]                           AS [ETAX_AMT]"                  );
			sb.Append(",[PD].[ITAX_AMT]                           AS [ITAX_AMT]"                  );
			sb.Append(",'0'                                       AS [PRICE_UPDATE_FLG]"          );
			sb.Append(",").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[CM_MS_GetRound]"));
			sb.Append("(([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT]) * [PD].[PU_PRICE], @CUR_DIGIT, @AMT_ROUND_TYPE) AS [PU_MONEY]");
			sb.Append(",[PROD].[PROD_NAME_CORRECT_ALLOW_FLG]      AS [PROD_NAME_CORRECTION_FLG]"  );

			//コピー時は商品変更可能、返品時は商品変更不可
			sb.Append(",'0'                                       AS [PROD_EDIT_FLG]"       );

			//入荷済判定
			sb.Append(",CASE "                                                              );
			sb.Append("     WHEN [PU].[OVERSEAS_FLG] = '1' "                                );
			sb.Append("         THEN '0' "                                                  );
			sb.Append("     WHEN [POD].[RCPT_PU_QT] > 0 "                                   );
			sb.Append("         THEN '1' "                                                  );
			sb.Append("     ELSE "                                                          );
			sb.Append("         CASE WHEN [POD].[RCPT_QT] - [POD].[RCPT_RETURN_QT] - [POD].[DIRECT_PU_QT] <> 0 ");
			sb.Append("             THEN '1' "                                              );
			sb.Append("             ELSE '0' "                                              );
			sb.Append("         END "                                                       );
			sb.Append(" END                                       AS [IS_RCPT_EXECUTE]"     );
			sb.Append(",'R'                                       AS [ROW_STATE]"           );
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputDetail, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.MasterNotClear, "PD", "CUSTOM_ITEM_TAG", "@PU_DATE", null, keyColumn.ParamType == "View" || keyColumn.ParamType == "Mod");
// 管理番号K27057 To

			//入荷
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");
			//入荷明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD]");
			sb.Append(" ON  [RCPT].[RCPT_NO]      = [RD].[RCPT_NO]");
			sb.Append(" AND [RD].[DELETE_FLG] <> '1' ");

			//仕入
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			sb.Append(" ON  [RCPT].[PU_NO]      = [PU].[PU_NO]");
			//仕入明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PD]");
			sb.Append(" ON [PU].[PU_NO] = [PD].[PU_NO]");
			sb.Append(" AND [RD].[PU_LINE_ID] = [PD].[PU_LINE_ID]");
			//発注明細 入荷済み判定で使用
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PO_DTIL]")).Append(" AS [POD]");
			sb.Append(" ON  [PD].[PO_NO]      = [POD].[PO_NO]");
			sb.Append(" AND [PD].[PO_LINE_ID] = [POD].[PO_LINE_ID]");

			//商品
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [PROD]");
			sb.Append(" ON  [PD].[PROD_CODE]   = [PROD].[PROD_CODE]");
			sb.Append(" AND [PROD].[PROD_TYPE] = '0' ");//通常商品のみ
			//商品規格1
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_1]")).Append(" AS [PS1]");
			sb.Append(" ON [PD].[PROD_SPEC_1_CODE] = [PS1].[PROD_SPEC_1_CODE]");
			//商品規格2
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD_SPEC_2]")).Append(" AS [PS2]");
			sb.Append(" ON [PD].[PROD_SPEC_2_CODE] = [PS2].[PROD_SPEC_2_CODE]");
			//倉庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[WH]")).Append(" AS [W]");
			sb.Append(" ON [PD].[WH_CODE] = [W].[WH_CODE]");
			//単位別商品属性
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
			sb.Append(" ON [PD].[PROD_CODE] = [U].[PROD_CODE]");
			sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE] ");
			//在庫
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[STOCK]")).Append(" AS [ST]");
			sb.Append(" ON  [PD].[WH_CODE]          = [ST].[WH_CODE] ");
			sb.Append(" AND [PD].[PROD_CODE]        = [ST].[PROD_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [ST].[PROD_SPEC_1_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [ST].[PROD_SPEC_2_CODE] ");
			sb.Append(" AND [ST].[DEPT_CODE]        = @STOCK_ADMIN_DEPT_CODE ");

			if (keyColumn.ProjectStockAdminUseFlg)
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ISNULL([PU].[PROJ_CODE],'')");
				sb.Append(" AND [ST].[PROJ_SBNO] = ISNULL([PU].[PROJ_SBNO],'')");
			}
			else
			{
				sb.Append(" AND [ST].[PROJ_CODE] = ''");
				sb.Append(" AND [ST].[PROJ_SBNO] = ''");
			}
// 管理番号K27525 From
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[BOOK_DEDUCTION_REASON]")).Append(" AS [BDR]");
			sb.Append(" ON [BDR].[BOOK_DEDUCTION_REASON_CODE] = [PD].[BOOK_DEDUCTION_REASON_CODE] ");
// 管理番号K27525 To

			wpb.AddFilter("[RCPT].[RCPT_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[RCPT].[DELETE_FLG]", SearchOperator.NotEqual, "1");
			wpb.AddFilter("([RD].[RCPT_QT] - [RD].[RCPT_RETURN_QT])", SearchOperator.GreaterThan, 0);
// 管理番号 K20684 From
			wpb.AddFilter("[RCPT].[RCPT_APPROVAL_STATUS_TYPE]"	, SearchOperator.Equal, "3");
			wpb.AddFilter("[RCPT].[DELETE_FLG]", SearchOperator.NotEqual, "1");
// 管理番号 K20684 To
			sb.Append(wpb);
			sb.Append("ORDER BY [PD].[PU_LINE_NO] ASC ");

			return sb.ToSqlPString();	// 管理番号K27230
		}
		//海外仕入返品（入荷参照）
		private static string CreateRefReturnRcptLotDetailString(CommonData commonData,IF_SC_MM_05_KeyColumn keyColumn)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();

			sb.Append("SELECT ");
			sb.Append(" [R_L_D].[PU_LINE_ID]          AS [ROW_ID]      ,");
			sb.Append(" [R_L_D].[LOT_NO]              AS [LOT_NO]      ,");
			sb.Append(" [LOT].[FAB_DATE]              AS [FAB_DATE]    ,");
// 管理番号 B22625 From
//			sb.Append(" DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE]) AS [TERM_DATE],");
			sb.Append(" CASE WHEN CONVERT(DATETIME,'9998/12/31') - [LOT].[FAB_DATE] < [P].[LOT_VALID_TERM_DAY_CNT]-1");
			sb.Append(   " THEN CONVERT(DATETIME,'9998/12/31')");
			sb.Append(   " ELSE DATEADD(Day,[P].[LOT_VALID_TERM_DAY_CNT]-1,[LOT].[FAB_DATE])");
			sb.Append(" END AS [TERM_DATE] ,");
// 管理番号 B22625 To
			sb.Append(" [R_L_D].[RCPT_LOT_ID]         AS [LOT_ID]      ,");
			sb.Append(" '1'                           AS [STOCK_TYPE]  ,");
			sb.Append(" 0                             AS [STOCK_QT]    ,");
			sb.Append(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] AS [INIT_QT],");
			sb.Append(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] AS [EDIT_QT],");
			sb.Append(" [R_L_D].[RCPT_QT] - [R_L_D].[RCPT_RETURN_QT] AS [TRANSIT_RCPT_QT],");
			sb.Append(" [R_L_D].[RCPT_NO]             AS [RCPT_NO]     ,");
			sb.Append(" [R_L_D].[RCPT_LINE_ID]        AS [RCPT_LINE_ID],");
			sb.Append(" [R_L_D].[RCPT_LOT_ID]         AS [RCPT_LOT_ID] ,");
			sb.Append(" [P_L_D].[SA_NO]               AS [SA_NO]       ,");
			sb.Append(" [P_L_D].[SA_LINE_ID]          AS [SA_LINE_ID]  ,");
			sb.Append(" [P_L_D].[SA_LOT_ID]           AS [SA_LOT_ID]    ");
// 管理番号 K25322 From
			sb.Append(",0                             AS [PO_ALLOC_RCPT_QT]  ");//在庫単位発注引当仕入数量
// 管理番号 K25322 To

			//入荷
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]")).Append(" AS [RCPT]");

			//仕入
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			sb.Append(" ON  [RCPT].[PU_NO] = [PU].[PU_NO] ");
			//仕入明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]")).Append(" AS [PD]");
			sb.Append(" ON  [PU].[PU_NO] = [PD].[PU_NO] ");
			//仕入ロット明細
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_LOT_DTIL]")).Append(" AS [P_L_D]");
			sb.Append(" ON  [PD].[PU_NO]      = [P_L_D].[PU_NO] ");
			sb.Append(" AND [PD].[PU_LINE_ID] = [P_L_D].[PU_LINE_ID] ");
			sb.Append(" AND (([P_L_D].[RCPT_NO] IS NOT NULL) OR ([P_L_D].[RCPT_NO] IS NULL AND [P_L_D].[LOT_NO] <> '9'))");

			//入荷明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_DTIL]")).Append(" AS [RD]");
			sb.Append(" ON  [PD].[PU_NO] = [RD].[PU_NO] ");
			sb.Append(" AND  [PD].[PU_LINE_ID] = [RD].[PU_LINE_ID] ");
			sb.Append(" AND  [RCPT].[RCPT_NO] = [RD].[RCPT_NO] ");
			sb.Append(" AND  [RD].[DELETE_FLG] <> '1' ");

			//入荷ロット明細
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT_LOT_DTIL]")).Append(" AS [R_L_D]");
			sb.Append(" ON  [RD].[RCPT_NO]      = [R_L_D].[RCPT_NO] ");
			sb.Append(" AND [RD].[RCPT_LINE_ID] = [R_L_D].[RCPT_LINE_ID] ");
			//商品
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PROD]")).Append(" AS [P]");
			sb.Append(" ON  [PD].[PROD_CODE] = [P].[PROD_CODE] ");
			//ロット
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[LOT]")).Append(" AS [LOT]");
			sb.Append(" ON  [PD].[PROD_CODE]        = [LOT].[PROD_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_1_CODE] = [LOT].[PROD_SPEC_1_CODE] ");
			sb.Append(" AND [PD].[PROD_SPEC_2_CODE] = [LOT].[PROD_SPEC_2_CODE] ");
			sb.Append(" AND [R_L_D].[LOT_NO]        = [LOT].[LOT_NO] ");

			//単位別商品属性
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[UNIT_PROD_ATTRIBUTE]")).Append(" AS [U]");
			sb.Append(" ON  [PD].[PROD_CODE] = [U].[PROD_CODE] ");
			sb.Append(" AND [PD].[UNIT_CODE] = [U].[UNIT_CODE]");

			wpb.AddFilter("[RCPT].[RCPT_NO]"   , SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[R_L_D].[RCPT_QT]", SearchOperator.GreaterThan, 0);
			wpb.AddFilter("[RCPT].[DELETE_FLG]", SearchOperator.Equal, 0);

			sb.Append(wpb);
			sb.Append("ORDER BY [LOT].[FAB_DATE] ASC, [R_L_D].[RCPT_LOT_ID] ASC, [RCPT].[RCPT_DATE] ASC, [R_L_D].[RCPT_NO] ASC");

			return sb.ToString();
		}
// 管理番号 B19369 To
#endregion
// 管理番号 B13500 From
		// 仕入参照した伝票が入荷済伝票か否か判定
		private static bool IsRcptSlip(CommonData commonData, SqlConnection cn,IF_SC_MM_05_KeyColumn keyColumn)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();
			bool retult            = false;

			sb.Append("SELECT ");
			sb.Append(" COUNT(*) AS [COUNT] ");
			sb.Append("FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[RCPT]"));
			wpb.AddFilter("[PU_NO]"       , SearchOperator.Equal   , keyColumn.SlipNo);
			sb.Append(wpb);

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
			object scl = cm.ExecuteScalar();

			//入荷済伝票か否か判定する
			if (scl != null)
			{
				int count = (int)scl;
				retult = (count > 0);
			}

			return retult;
		}
		// 仕入参照した伝票が入荷省略でないか否か判定
		private static bool IsRcptInputNoNeedPu(CommonData commonData, SqlConnection cn, IF_SC_MM_05_KeyColumn keyColumn)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();
			bool retult            = false;
			int count              = 0;

			//返品伝票が存在するかどうかチェックする
			sb.Append(" SELECT ");
			sb.Append("   COUNT(*) AS [COUNT]");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]"));
			wpb.AddFilter(" [PU_NO]"         , SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter(" [RCPT_INPUT_NO_NEED_FLG]", SearchOperator.Equal,"0");
			wpb.AddFilter(" [PU_MODE_TYPE]", SearchOperator.Equal, "1");						//仕入形態区分
			wpb.AddFilter(" [APPROVAL_STATUS_TYPE]", SearchOperator.Equal, "3");				//承認状況は決済のみ
			wpb.AddFilter(" [OPPOSITE_PU_NO]", SearchOperator.Equal, System.DBNull.Value);		//相手仕入番号
			sb.Append(wpb);

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
			object scl = cm.ExecuteScalar();
			if (scl != null)
			{
				count = (int)scl;
				retult = count > 0;
			}

			return retult;
		}
// 管理番号 B13500 To
		//登録
		public static bool Insert(CommonData commonData, SqlConnection cn, SqlTransaction tr, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base rowData)
		{
			int return_value = -1;
			int ret          = -1;
			string resultInformation = string.Empty;
			bool result = false;
			SqlCommandWrapper cm     = null;	// 管理番号K27230

			try
			{
				//一時明細テーブル作成
// 管理番号 B15710 From
//				CreateTempTable(commonData, cn, tr, keyColumn);
// 管理番号 B15710 To
				InsertTempTable(commonData, cn, tr, keyColumn, rowData);

				//ストアド実行
				cm = CreateStoredCommand(commonData, cn, tr, keyColumn, rowData, "Insert");
				cm.ExecuteNonQuery();

// 管理番号 B15710 From
//				BL_SC_MM_05.DropTempTable(cn, tr);
// 管理番号 B15710 To

				//結果情報取得
// 管理番号 B12917 From
//				return_value = int.Parse(cm.Parameters["@RETURN_VALUE"].Value.ToString());
//				ret          = int.Parse(cm.Parameters["@RET"].Value.ToString());
				return_value = (int) cm.Parameters["@RETURN_VALUE"].Value;
				ret          = (int) (decimal) cm.Parameters["@RET"].Value;
// 管理番号 B12917 To
				resultInformation= cm.Parameters["@RESULT_INFORMATION"].Value.ToString();
				rowData.Ret = ret;
				rowData.ResultInformation = resultInformation;
				rowData.PuNo = cm.Parameters["@PU_NO"].Value.ToString();

				if (return_value != 0)
				{
					switch (ret)
					{
						case 14:
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10021).WriteLog());
						case 28:
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10028).WriteLog());
// 管理番号 B12917 From
						case 29:
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.S10013("仕入日", "前回仕入日")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.S10013(MultiLanguage.Get("SC_CS000806"), MultiLanguage.Get("SC_CS004581"))).WriteLog());
// 管理番号 B12917 To
						case 2301:
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10027).WriteLog());
						case 2304:
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MM_05_S02_09).WriteLog());
						case 2305:
// 							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10012("返品")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10012(MultiLanguage.Get("SC_CS001882"))).WriteLog());
						case 2306:
// 							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10029("返品")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10029(MultiLanguage.Get("SC_CS001882"))).WriteLog());
// 管理番号 B18267 From
						case 33:
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042("倉庫").ToString()).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042(MultiLanguage.Get("SC_CS001387")).ToString()).WriteLog());
						case 34:
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042("単位").ToString()).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042(MultiLanguage.Get("SC_CS001456")).ToString()).WriteLog());
// 管理番号 B18267 To
// 管理番号 B20818 From
						case 36:
// 							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10044("参照元伝票")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10044(MultiLanguage.Get("SC_CS003600"))).WriteLog());
						case 37:
// 							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10044("更新対象の伝票")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10044(MultiLanguage.Get("SC_CS003407"))).WriteLog());
						case 2309:
							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MM_05_S02_06).WriteLog());
// 管理番号 B20818 To
// 管理番号 B21493 From
						case 39:
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042("商品").ToString()).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042(MultiLanguage.Get("SC_CS001152")).ToString()).WriteLog());
// 管理番号 B21493 To
// 管理番号 K24789 From
						case 2314:
							//[仕入先]の消費税区分と明細の[消費税計算区分］の組合せが不正です。[仕入先］マスタが変更されていないかをご確認ください。
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.S20045(MultiLanguage.Get("SC_CS000784"), MultiLanguage.Get("CM_CS002952")).ToString()).WriteLog());
// 管理番号 K24789 To
// 管理番号 K25322 From
						case 45:
							//ロット評価時の複数ロット引当エラー (発注引当付替処理でチェック)
							//ロット別在庫評価をする商品の場合、複数のロットを引当できません。連動する受注を修正してから再度指示してください。
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10054).WriteLog());
						case 46:
							throw (new AllegroException(commonData, ExceptionLevel.Error, ErrInfoSet(commonData, cn, tr, keyColumn, ret)).WriteLog());
// 管理番号 K25322 To
						default:
							if (resultInformation.Trim().Length>0)
							{
								throw (new AllegroException(commonData, ExceptionLevel.Error, resultInformation).WriteLog());
							}
							else
							{
// 								throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.S20014("仕入伝票")).WriteLog()); //K24546
								throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.S20014(MultiLanguage.Get("SC_CS000804"))).WriteLog());
							}
					}
				}
				else
				{
					result = true;
				}
			}
			catch (AllegroException aEx)
			{
				throw (new AllegroException(commonData, ExceptionLevel.Warning, aEx.Message));
			}
			catch (SqlException sqlEx)
			{
				string errorMessage= "Procedure=[" + sqlEx.Procedure + "]\r\nLineNumber=[" + sqlEx.LineNumber + "]\r\nMessage=[" + sqlEx.Message + "]";
// 管理番号 K25647 From
				if (sqlEx.Number == 8115)	// 算術オーバーフロー
				{
					// 伝票の更新時にオーバーフローが発生しました。
					throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10057, sqlEx).WriteLog(errorMessage));
				}
				else
				{
// 管理番号 K25647 To
// 管理番号 B23569 From
//					throw (new AllegroException(commonData, ExceptionLevel.Error,errorMessage));
					throw (new AllegroException(commonData, sqlEx).WriteLog(errorMessage));
// 管理番号 B23569 To
// 管理番号 K25647 From
				}
// 管理番号 K25647 To
			}
			finally
			{
			}

			return result;
		}
		//登録
		public static bool Insert(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base rowData)
		{
			bool result = false;
//			SqlConnection cn  = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn  = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlTransaction tr = null;

			try
			{
				cn.Open();
				tr = cn.BeginTransaction();

				result = BL_SC_MM_05.Insert(commonData, cn, tr, keyColumn, rowData);

				tr.Commit();
			}
			catch (AllegroException aEx)
			{
				tr.Rollback();
				throw (new AllegroException(commonData, ExceptionLevel.Warning, aEx.Message));
			}
			finally
			{
// 管理番号B26347 From
//				if(cn!=null && cn.State!=ConnectionState.Closed)cn.Close();
				if(cn!=null && cn.State!=ConnectionState.Closed)
				{
					cn.Close();
				}
// 管理番号B26347 To
			}
			return result;
		}

		//更新
		public static bool Update(CommonData commonData, SqlConnection cn, SqlTransaction tr, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base rowData)
		{
			int return_value = -1;
			int ret          = -1;
			string resultInformation = string.Empty;
			bool result = false;
			SqlCommandWrapper cm = null;	// 管理番号K27230

			try
			{
				//一時明細テーブル作成
// 管理番号 B15710 From
//				CreateTempTable(commonData, cn, tr, keyColumn);
// 管理番号 B15710 To
				InsertTempTable(commonData, cn, tr, keyColumn, rowData);

				//ストアド実行
				cm = CreateStoredCommand(commonData, cn, tr, keyColumn, rowData, "Update");
				cm.ExecuteNonQuery();

// 管理番号 B15710 From
//				BL_SC_MM_05.DropTempTable(cn, tr);
// 管理番号 B15710 To

				//結果情報取得
// 管理番号 B12917 From
//				return_value = int.Parse(cm.Parameters["@RETURN_VALUE"].Value.ToString());
//				ret          = int.Parse(cm.Parameters["@RET"].Value.ToString());
				return_value = (int) cm.Parameters["@RETURN_VALUE"].Value;
				ret          = (int) (decimal) cm.Parameters["@RET"].Value;
// 管理番号 B12917 To
				resultInformation= cm.Parameters["@RESULT_INFORMATION"].Value.ToString();
				rowData.Ret = ret;
				rowData.ResultInformation = resultInformation;
// 管理番号 B23849 From
//				rowData.PuNo = cm.Parameters["@PU_NO"].Value.ToString();
// 管理番号 B23849 To

				if (return_value != 0)
				{
					switch (ret)
					{
						case 14:
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10021).WriteLog());
						case 28:
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10028).WriteLog());
// 管理番号 B12917 From
						case 29:
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.S10013("仕入日", "前回仕入日")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.S10013(MultiLanguage.Get("SC_CS000806"), MultiLanguage.Get("SC_CS004581"))).WriteLog());
// 管理番号 B12917 To
						case 2301:
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10027).WriteLog());
						case 2304:
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MM_05_S02_09).WriteLog());
						case 2305:
// 							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10012("返品")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10012(MultiLanguage.Get("SC_CS001882"))).WriteLog());
						case 2306:
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10029("返品")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10029(MultiLanguage.Get("SC_CS001882"))).WriteLog());
						case 2307:
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MM_05_S02_10).WriteLog());
// 管理番号 B13500 From
						case 2308:
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MM_05_S04_01).WriteLog());
// 管理番号 B13500 From
// 管理番号 B17672 From
						case 2310:
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MM_05_S04_04).WriteLog());
// 管理番号 B17672 To
// 管理番号 K20684 From
						case 2311:
							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MM_05_S04_06).WriteLog());
// 管理番号 K20684 To
// 管理番号 K24285 From
						case 2313:
// 							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10049("マイナス数量","返品")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10049(MultiLanguage.Get("SC_CS002850"),MultiLanguage.Get("SC_CS001882"))).WriteLog());
// 管理番号 K24285 To
// 管理番号 K24789 From
						case 2314:
							//[仕入先]の消費税区分と明細の[消費税計算区分］の組合せが不正です。[仕入先］マスタが変更されていないかをご確認ください。
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.S20045(MultiLanguage.Get("SC_CS000784"), MultiLanguage.Get("CM_CS002952")).ToString()).WriteLog());
// 管理番号 K24789 To
// 管理番号 B18174 From
						case 0031:
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10039).WriteLog());
// 管理番号 B18174 To
// 管理番号 B18267 From
						case 33:
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042("倉庫").ToString()).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042(MultiLanguage.Get("SC_CS001387")).ToString()).WriteLog());
						case 34:
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042("単位").ToString()).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042(MultiLanguage.Get("SC_CS001456")).ToString()).WriteLog());
// 管理番号 B18267 To
// 管理番号 B20818 From
						case 36:
// 							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10044("参照元伝票")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10044(MultiLanguage.Get("SC_CS003600"))).WriteLog());
						case 37:
// 							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10044("更新対象の伝票")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10044(MultiLanguage.Get("SC_CS003407"))).WriteLog());
// 管理番号 B20818 To
// 管理番号 B20718 From
						case 39:
							//商品無効エラー
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042("商品").ToString()).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042(MultiLanguage.Get("SC_CS001152")).ToString()).WriteLog());
// 管理番号 B20718 To	
// 管理番号 K25322 From
						case 45:
							//ロット評価時の複数ロット引当エラー (発注引当付替処理でチェック)
							//ロット別在庫評価をする商品の場合、複数のロットを引当できません。連動する受注を修正してから再度指示してください。
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10054).WriteLog());
						case 46:
							throw (new AllegroException(commonData, ExceptionLevel.Error, ErrInfoSet(commonData, cn, tr, keyColumn, ret)).WriteLog());
// 管理番号 K25322 To
// 管理番号B25595 From
						case 47:
							//後続処理が行われているため、[ロット番号]は変更できません。
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10060(MultiLanguage.Get("SC_CS000295"))).WriteLog());
// 管理番号B25595 To
						default:
							if (resultInformation.Trim().Length>0)
							{
								throw (new AllegroException(commonData, ExceptionLevel.Error, resultInformation).WriteLog());
							}
							else
							{
// 								throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.S20014("仕入伝票")).WriteLog()); //K24546
								throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.S20014(MultiLanguage.Get("SC_CS000804"))).WriteLog());
							}
					}
// 管理番号 K25322 From
					throw (new AllegroException(commonData, ExceptionLevel.Error, ErrInfoSet(commonData, cn, tr, keyColumn, ret)).WriteLog());
// 管理番号 K25322 To
				}
				else
				{
// 管理番号 B23849 From
					rowData.PuNo = cm.Parameters["@PU_NO"].Value.ToString();
// 管理番号 B23849 To
					result = true;
				}
			}
			catch (AllegroException aEx)
			{
				throw (new AllegroException(commonData, ExceptionLevel.Warning, aEx.Message));
			}
			catch (SqlException sqlEx)
			{
				string errorMessage= "Procedure=[" + sqlEx.Procedure + "]\r\nLineNumber=[" + sqlEx.LineNumber + "]\r\nMessage=[" + sqlEx.Message + "]";
// 管理番号 K25647 From
				if (sqlEx.Number == 8115)   // 算術オーバーフロー
				{
					// 伝票の更新時にオーバーフローが発生しました。
					throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10057, sqlEx).WriteLog(errorMessage));
				}
				else
				{
// 管理番号 K25647 To
// 管理番号 B23569 From
//					throw (new AllegroException(commonData, ExceptionLevel.Error,errorMessage));
					throw (new AllegroException(commonData, sqlEx).WriteLog(errorMessage));
// 管理番号 B23569 To
// 管理番号 K25647 From
				}
// 管理番号 K25647 To
			}
			finally
			{
			}
			return result;
		}
		public static bool Update(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base rowData)
		{
			bool result = false;
//			SqlConnection cn  = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn  = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlTransaction tr = null;

			try
			{
				cn.Open();
				tr = cn.BeginTransaction();

				result = BL_SC_MM_05.Update(commonData, cn, tr, keyColumn, rowData);

				tr.Commit();
			}
			catch (AllegroException aEx)
			{
				tr.Rollback();
				throw (new AllegroException(commonData, ExceptionLevel.Warning, aEx.Message));
			}
			finally
			{
// 管理番号B26347 From
//				if(cn!=null && cn.State!=ConnectionState.Closed)cn.Close();
				if(cn!=null && cn.State!=ConnectionState.Closed)
				{
					cn.Close();
				}
// 管理番号B26347 To
			}

			return result;
		}
		//削除
// 管理番号 B20818 From
//		public static bool Delete(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn)
		public static bool Delete(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base rowData)
// 管理番号 B20818 To
		{
			bool result = false;
//			SqlConnection cn  = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn  = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlTransaction tr = null;

			try
			{
				cn.Open();
				tr = cn.BeginTransaction();
// 管理番号 B20818 From
//				result = BL_SC_MM_05.Delete(commonData, cn, tr, keyColumn);
				result = BL_SC_MM_05.Delete(commonData, cn, tr, keyColumn, rowData);
// 管理番号 B20818 To

				tr.Commit();
			}
			catch (AllegroException aEx)
			{
				tr.Rollback();
				throw (new AllegroException(commonData, ExceptionLevel.Warning, aEx.Message));
			}
			finally
			{
// 管理番号B26347 From
//				if(cn!=null && cn.State!=ConnectionState.Closed)cn.Close();
				if(cn!=null && cn.State!=ConnectionState.Closed)
				{
					cn.Close();
				}
// 管理番号B26347 To
			}
			return result;
		}

		//削除
// 管理番号 B20818 From
//		public static bool Delete(CommonData commonData, SqlConnection cn, SqlTransaction tr, IF_SC_MM_05_KeyColumn keyColumn)
		public static bool Delete(CommonData commonData, SqlConnection cn, SqlTransaction tr, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base rowData)
// 管理番号 B20818 To
		{
			int return_value = 0;
			bool ret = false;
			string errMessage = string.Empty;
			int errNumber = 0;

			SqlCommandWrapper cm     = null;	// 管理番号K27230

			try
			{
				//ストアド実行
// 管理番号 B20818 From
//				cm = CreateStoredCommand(commonData, cn, tr, keyColumn, null, "Delete");
				cm = CreateStoredCommand(commonData, cn, tr, keyColumn, rowData, "Delete");
// 管理番号 B20818 To
				cm.ExecuteNonQuery();

				return_value = (int) cm.Parameters["@RETURN_VALUE"].Value;
// 管理番号 B12917 From
//				errNumber    = int.Parse(cm.Parameters["@RET"].Value.ToString());
				errNumber    = (int) (decimal) cm.Parameters["@RET"].Value;
// 管理番号 B12917 From
				errMessage   = cm.Parameters["@RESULT_INFORMATION"].Value.ToString();

				if (return_value != 0)
				{
					switch (errNumber)
					{
// 管理番号 B12917 From
						case 29:
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.S10013("仕入日", "前回仕入日")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.S10013(MultiLanguage.Get("SC_CS000806"), MultiLanguage.Get("SC_CS004581"))).WriteLog());
// 管理番号 B12917 To
						case 2305:
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10012("返品")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10012(MultiLanguage.Get("SC_CS001882"))).WriteLog());
// 管理番号 B13500 From
						case 2309:
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10012("入荷")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10012(MultiLanguage.Get("SC_CS001606"))).WriteLog());
// 管理番号 B13500 To

// 管理番号 B17564 From
						case 0031:
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10039).WriteLog());
// 管理番号 B17564 To
// 管理番号 B18267 From
						case 33:
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042("倉庫")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042(MultiLanguage.Get("SC_CS001387"))).WriteLog());
						case 34:
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042("単位")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042(MultiLanguage.Get("SC_CS001456"))).WriteLog());
// 管理番号 B18267 To
// 管理番号 B20818 From
						case 36:
// 							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10044("参照元伝票")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10044(MultiLanguage.Get("SC_CS003600"))).WriteLog());
						case 37:
// 							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10044("削除対象の伝票")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.SC_MS_S10044(MultiLanguage.Get("SC_CS003576"))).WriteLog());
// 管理番号 B20818 To
// 管理番号 B20718 From
						case 39:
							//商品無効エラー
// 							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042("商品")).WriteLog()); //K24546
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042(MultiLanguage.Get("SC_CS001152"))).WriteLog());
// 管理番号 B20718 To	
// 管理番号 K24789 From
						case 41:
							//伝票の中に、存在しないかまたは無効なマスタが含まれています。［消費税区分］
							throw (new AllegroException(commonData, ExceptionLevel.Error, AllegroMessage.SC_MS_S10042(MultiLanguage.Get("CM_CS000884"))).WriteLog());
// 管理番号 K24789 To	
						default:
							throw (new AllegroException(commonData, ExceptionLevel.Warning, errMessage).WriteLog());
					}
// 管理番号 K25322 From
					throw (new AllegroException(commonData, ExceptionLevel.Error, ErrInfoSet(commonData, cn, tr, keyColumn, errNumber)).WriteLog());
// 管理番号 K25322 To
				}
				else
				{
					ret = true;
				}
			}
			catch (AllegroException aEx)
			{
				throw (new AllegroException(commonData, ExceptionLevel.Error, aEx.Message));
			}
			catch (SqlException sqlEx)
			{
				string errorMessage= "Procedure=[" + sqlEx.Procedure + "]\r\nLineNumber=[" + sqlEx.LineNumber + "]\r\nMessage=[" + sqlEx.Message + "]";
// 管理番号 B23569 From
//				throw (new AllegroException(commonData, ExceptionLevel.Error,errorMessage));
				throw (new AllegroException(commonData, sqlEx).WriteLog(errorMessage));
// 管理番号 B23569 To
			}
			finally
			{
			}

			return ret;
		}
// 管理番号 K25322 From
		public static string ErrInfoSet(CommonData commonData, SqlConnection cn, SqlTransaction tr, IF_SC_MM_05_KeyColumn keyColumn, int errNumber)
		{
			//エラーメッセージを格納するための変数
			string errMessage = string.Empty;
			//エラーメッセージを一時的に格納するための変数
			string tempMessage = string.Empty;
			//エラー行が1行目かどうか判断するための変数
			decimal errCount = 0M;

			//ワーク仕入明細テーブルからエラーがある列を取得してくる
			#region	Select_Info
			StringBuilder sb = new StringBuilder();

			sb.Append("SELECT ");

			sb.Append(" [PU_LINE_ID] ");					//仕入行ID
			sb.Append(",[PU_LINE_NO] ");					//仕入行番号
			sb.Append(",[RET] ");							//エラーナンバー
			sb.Append(",[RESULT_INFORMATION] ");			//エラーメッセージ

			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[WK_PU_DTIL]"));
			sb.Append(" WITH (NOLOCK) ");
			sb.Append(" WHERE [RET] <> 0");
			sb.Append(" AND [WK_KEY] = @WK_KEY");
			#endregion

			SqlCommandWrapper tempCm = new SqlCommandWrapper(sb.ToString(), cn, tr);	// 管理番号K27230
			tempCm.Parameters.Add("@WK_KEY" , SqlDbType.NVarChar , 50  );
			tempCm.Parameters["@WK_KEY"].Value = ConvertDBData.ToNVarChar(keyColumn.WkKey);

			SqlDataAdapterWrapper da = new SqlDataAdapterWrapper(tempCm);	// 管理番号K27230
			DBTimeout.setTimeout(da, commonData); 		//タイムアウト値変更メソッド呼出し
			try
			{
				//エラー行を受け取るためのデータテーブル
				DataTable dt = new DataTable();

				da.Fill(dt);

				//メッセージを一時的に格納するための変数
				tempMessage = string.Empty;

				//エラーが有る行数分だけエラーメッセージを出す
				if (errNumber == 46)
				{
					foreach(DataRow row in dt.Rows)
					{
						//エラーメッセージを格納する
						if (decimal.Parse(row["RET"].ToString()) == 46)
						{
							tempMessage =  AllegroMessage.SC_MS_S10055(row["PU_LINE_NO"].ToString());
						}
						//1行目はメッセージを直接格納する、2行目以降はメッセージを付け足していく
						if (errCount == 0)
						{
							errMessage = tempMessage;
						}
						else
						{
							errMessage = errMessage + "\r\n" + tempMessage;
						}
						errCount = errCount + 1;

					}
				}

				return tempMessage;
			}
			catch (SqlException ex)
			{
				tr.Rollback();
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
		}
// 管理番号 K25322 To
		//一時テーブル削除
		private static void DropTempTable(SqlConnection cn, SqlTransaction tr)
		{
			try
			{
				SqlCommandWrapper cm = new SqlCommandWrapper("DROP TABLE [#PU_DTIL]" , cn, tr);	// 管理番号K27230
				cm.ExecuteNonQuery();
				cm.CommandText = "DROP TABLE [#PU_LOT_DTIL]";
				cm.ExecuteNonQuery();
			}
			catch(Exception)
			{
				//エラー無視
			}
		}

		//[SC_MM_05_Update_Check]パラメータ
		private static SqlCommandWrapper UpdateCommand(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base validRowData)	// 管理番号K27230
		{
			SqlCommandWrapper cm = new SqlCommandWrapper();	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To

			cm.Parameters.Add("@ORG_PU_NO"                    , SqlDbType.NVarChar, 10 );	// 修正元伝票の仕入番号
			cm.Parameters.Add("@DTIL_CHANGED_FLG"             , SqlDbType.NVarChar, 1  );	// 明細変更フラグ（0:変更なし、1:変更あり）
			cm.Parameters.Add("@PU_NAME"                      , SqlDbType.NVarChar , 30);	// 仕入件名
			cm.Parameters.Add("@PU_DATE"                      , SqlDbType.DateTime     ); 	// 仕入日
// 管理番号 K16590 From
			cm.Parameters.Add("@DEAL_DATE"                    , SqlDbType.DateTime     ); 	// 取引日
			cm.Parameters.Add("@RED_PU_DATE"                  , SqlDbType.DateTime     ); 	// 赤伝票の仕入日
// 管理番号 K16590 To
			cm.Parameters.Add("@PO_NO"                        , SqlDbType.NVarChar, 10 );	// 発注番号
			cm.Parameters.Add("@RCPT_NO"                      , SqlDbType.NVarChar, 10 );	// 入荷番号
			cm.Parameters.Add("@PU_MODE_TYPE"                 , SqlDbType.NVarChar, 1  );	// 仕入形態区分
			cm.Parameters.Add("@REF_PU_NO"                    , SqlDbType.NVarChar, 10 );	// 参照仕入番号
			cm.Parameters.Add("@CUR_CODE"                     , SqlDbType.NVarChar, 3  );	// 通貨コード
			cm.Parameters.Add("@EXCHANGE_TYPE"                , SqlDbType.NVarChar, 1  );	// 為替区分
			cm.Parameters.Add("@EXCHANGE_REZ_NO"              , SqlDbType.NVarChar, 10 );	// 為替予約番号
			cm.Parameters.Add("@RATE"                         , SqlDbType.Decimal , 6  );	// レート
			cm.Parameters.Add("@DEPT_CODE"                    , SqlDbType.NVarChar, 10 );	// 部門コード
			cm.Parameters.Add("@ORIGIN_DEPT_CODE"             , SqlDbType.NVarChar, 10 );	// 発生部門コード
			cm.Parameters.Add("@OLD_DEPT_CODE"                , SqlDbType.NVarChar, 10 );	// 旧部門コード
			cm.Parameters.Add("@ORG_CHANGE_ID"                , SqlDbType.Decimal , 10 );	// 組織変更ID
			cm.Parameters.Add("@DATA_MIGRATE_DATETIME"        , SqlDbType.DateTime     );	// データ移行日時
			cm.Parameters.Add("@EMP_CODE"                     , SqlDbType.NVarChar, 10 );	// 社員コード
// 管理番号 K16588 From
//			cm.Parameters.Add("@PROJ_CODE"                    , SqlDbType.NVarChar, 8  );	// プロジェクトコード
			cm.Parameters.Add("@PROJ_CODE"                    , SqlDbType.NVarChar, 20  );	// プロジェクトコード
// 管理番号 K16588 To
			cm.Parameters.Add("@PROJ_SBNO"                    , SqlDbType.NVarChar, 2  );	// プロジェクト枝番
// 管理番号K27011 From
//			cm.Parameters.Add("@SUPL_CODE"                    , SqlDbType.NVarChar, 8  );	// 仕入先コード
//			cm.Parameters.Add("@SUPL_SBNO"                    , SqlDbType.NVarChar, 2  );	// 仕入先枝番
			cm.Parameters.Add("@SUPL_CODE"						, SqlDbType.NVarChar, TypeLength.CompCode	);	// 仕入先コード
			cm.Parameters.Add("@SUPL_SBNO"						, SqlDbType.NVarChar, TypeLength.CompSbno	);	// 仕入先枝番
// 管理番号K27011 To
			cm.Parameters.Add("@TEMP_CODE_FLG"                , SqlDbType.NVarChar, 1  );	// 雑コードフラグ
// 管理番号K27011 From
//			cm.Parameters.Add("@SUPL_NAME"                    , SqlDbType.NVarChar, 50 );	// 仕入先名
//			cm.Parameters.Add("@SUPL_SHORT_NAME"              , SqlDbType.NVarChar, 10 );	// 仕入先略名
			cm.Parameters.Add("@SUPL_NAME"						, SqlDbType.NVarChar, TypeLength.CompName );	// 仕入先名
			cm.Parameters.Add("@SUPL_SHORT_NAME"				, SqlDbType.NVarChar, TypeLength.CompShortName );	// 仕入先略名
// 管理番号K27011 To
			cm.Parameters.Add("@SUPL_DEPT_NAME_1"             , SqlDbType.NVarChar, 25 );	// 仕入先部門名1
			cm.Parameters.Add("@SUPL_DEPT_NAME_2"             , SqlDbType.NVarChar, 25 );	// 仕入先部門名2
			cm.Parameters.Add("@SUPL_COUNTRY_CODE"            , SqlDbType.NVarChar, 3  );	// 仕入先国コード
			cm.Parameters.Add("@SUPL_ZIP"                     , SqlDbType.NVarChar, 10 );	// 仕入先郵便番号
			cm.Parameters.Add("@SUPL_STATE"                   , SqlDbType.NVarChar, 15 );	// 仕入先都道府県名
			cm.Parameters.Add("@SUPL_CITY"                    , SqlDbType.NVarChar, 15 );	// 仕入先市区町村名
			cm.Parameters.Add("@SUPL_ADDRESS1"                , SqlDbType.NVarChar, 30 );	// 仕入先町域名
			cm.Parameters.Add("@SUPL_ADDRESS2"                , SqlDbType.NVarChar, 30 );	// 仕入先ビル名
			cm.Parameters.Add("@SUPL_PHONE"                   , SqlDbType.NVarChar, 15 );	// 仕入先電話番号
			cm.Parameters.Add("@SUPL_FAX"                     , SqlDbType.NVarChar, 15 );	// 仕入先FAX番号
			cm.Parameters.Add("@SUPL_USER_NAME"               , SqlDbType.NVarChar, 10 );	// 仕入先担当者名
			cm.Parameters.Add("@AC_NO"                        , SqlDbType.NVarChar, 20 );	// 口座番号
			cm.Parameters.Add("@AC_HOLDER"                    , SqlDbType.NVarChar, 50 );	// 口座名義人
			cm.Parameters.Add("@AC_TYPE"                      , SqlDbType.NVarChar, 1  );	// 口座区分
			cm.Parameters.Add("@BANK_AC_TYPE"                 , SqlDbType.NVarChar, 1  );	// 銀行口座区分
			cm.Parameters.Add("@BANK_COUNTRY_CODE"            , SqlDbType.NVarChar, 3  );	// 銀行国コード
			cm.Parameters.Add("@BANK_CODE"                    , SqlDbType.NVarChar, 20 );	// 銀行コード
			cm.Parameters.Add("@BANK_BRANCH_CODE"             , SqlDbType.NVarChar, 20 );	// 銀行支店コード
			cm.Parameters.Add("@REMIT_FEE_TYPE"               , SqlDbType.NVarChar, 1  );	// 振込手数料区分
			cm.Parameters.Add("@REMIT_MTHD_1_DEAL_TYPE"       , SqlDbType.NVarChar, 1  );	// 振込方法1扱い区分
			cm.Parameters.Add("@REMIT_MTHD_2_TYPE"            , SqlDbType.NVarChar, 1  );	// 振込方法2区分
			cm.Parameters.Add("@DELI_TYPE"                    , SqlDbType.NVarChar, 1  );	// 納入区分
			cm.Parameters.Add("@WH_CODE"                      , SqlDbType.NVarChar, 5  );	// 倉庫コード
// 管理番号K27011 From
//			cm.Parameters.Add("@DELI_CUST_CODE"               , SqlDbType.NVarChar, 8  );	// 納入先コード
//			cm.Parameters.Add("@DELI_CUST_SBNO"               , SqlDbType.NVarChar, 2  );	// 納入先枝番
			cm.Parameters.Add("@DELI_CUST_CODE"					, SqlDbType.NVarChar, TypeLength.CompCode	);	// 納入先コード
			cm.Parameters.Add("@DELI_CUST_SBNO"					, SqlDbType.NVarChar, TypeLength.CompSbno	);	// 納入先枝番
// 管理番号K27011 To
			cm.Parameters.Add("@DELI_PLACE_CODE"              , SqlDbType.NVarChar, 2  );	// 受渡場所コード
			cm.Parameters.Add("@DELI_PLACE_NAME"              , SqlDbType.NVarChar, 30 );	// 受渡場所名
			cm.Parameters.Add("@DELI_PLACE_COUNTRY_CODE"      , SqlDbType.NVarChar, 3  );	// 受渡場所国コード
			cm.Parameters.Add("@DELI_PLACE_ZIP"               , SqlDbType.NVarChar, 10 );	// 受渡場所郵便番号
			cm.Parameters.Add("@DELI_PLACE_STATE"             , SqlDbType.NVarChar, 15 );	// 受渡場所都道府県名
			cm.Parameters.Add("@DELI_PLACE_CITY"              , SqlDbType.NVarChar, 15 );	// 受渡場所市区町村名
			cm.Parameters.Add("@DELI_PLACE_ADDRESS1"          , SqlDbType.NVarChar, 30 );	// 受渡場所町域名
			cm.Parameters.Add("@DELI_PLACE_ADDRESS2"          , SqlDbType.NVarChar, 30 );	// 受渡場所ビル名
			cm.Parameters.Add("@DELI_PLACE_PHONE"             , SqlDbType.NVarChar, 15 );	// 受渡場所電話番号
			cm.Parameters.Add("@DELI_PLACE_FAX"               , SqlDbType.NVarChar, 15 );	// 受渡場所FAX番号
			cm.Parameters.Add("@DELI_PLACE_USER_NAME"         , SqlDbType.NVarChar, 10 );	// 受渡場所担当者名
			cm.Parameters.Add("@DT_TYPE"                      , SqlDbType.NVarChar, 1  );	// 取引条件区分
			cm.Parameters.Add("@DT1_STTL_MTHD_CODE"           , SqlDbType.NVarChar, 3  );	// 取引条件1決済方法コード
			cm.Parameters.Add("@DT1_BASIS_AMT"                , SqlDbType.Decimal , 12 );	// 取引条件1基準金額
			cm.Parameters.Add("@DT2_STTL_MTHD_CODE"           , SqlDbType.NVarChar, 3  );	// 取引条件2決済方法コード
			cm.Parameters.Add("@DT2_RATIO"                    , SqlDbType.Decimal , 3  );	// 取引条件2比率
			cm.Parameters.Add("@DT3_STTL_MTHD_CODE"           , SqlDbType.NVarChar, 3  );	// 取引条件3決済方法コード
			cm.Parameters.Add("@DT_SIGHT"                     , SqlDbType.Decimal , 3  );	// 取引条件サイト
			cm.Parameters.Add("@CUTOFF_DATE"                  , SqlDbType.DateTime     );	// 締日
			cm.Parameters.Add("@PYMT_PLAN_DATE"               , SqlDbType.DateTime     );	// 支払予定日
			cm.Parameters.Add("@DT_NOTE"                      , SqlDbType.NVarChar, 50 );	// 取引条件表記
			cm.Parameters.Add("@SUPL_BILL_SLIP_NO"            , SqlDbType.NVarChar, 15 );	// 仕入先請求書番号
			cm.Parameters.Add("@CANCELED_ORDER_FLG"           , SqlDbType.NVarChar, 1  );	// 出合フラグ
			cm.Parameters.Add("@OVERSEAS_FLG"                 , SqlDbType.NVarChar, 1  );	// 海外フラグ
			cm.Parameters.Add("@TENOR_CODE"                   , SqlDbType.NVarChar, 3  );	// 建値コード
			cm.Parameters.Add("@FMONEY_STTL_PERIOD_STT_MONTH" , SqlDbType.DateTime     );	// 外貨決済期間開始月
			cm.Parameters.Add("@FMONEY_STTL_PERIOD_END_MONTH" , SqlDbType.DateTime     );	// 外貨決済期間終了月
			cm.Parameters.Add("@LC_NO"                        , SqlDbType.NVarChar, 16 );	// LC番号
// 管理番号 B13878 From
			cm.Parameters.Add("@HOLD_FLG"					  ,	SqlDbType.NVarChar, 1  );   // 保留フラグ
// 管理番号 B13878 To
			cm.Parameters.Add("@REMARKS_CODE"                 , SqlDbType.NVarChar, 3  );	// 摘要コード
			cm.Parameters.Add("@REMARKS"                      , SqlDbType.NVarChar, 100);	// 摘要
// 管理番号 B13798 From
			cm.Parameters.Add("@ADMIN_ITEM1"                  , SqlDbType.NVarChar , 30);	// 管理項目1
			cm.Parameters.Add("@ADMIN_ITEM2"                  , SqlDbType.NVarChar , 30);	// 管理項目2
			cm.Parameters.Add("@ADMIN_ITEM3"                  , SqlDbType.NVarChar , 30);	// 管理項目3			
// 管理番号 B13798 To
// 管理番号 K20687 From
			cm.Parameters.Add("@BOOK_BASIS_TYPE"			  , SqlDbType.NVarChar , 1 );	// 計上基準区分
// 管理番号 K20687 To
			cm.Parameters.Add("@OUTLAND_REMITTANCE_FLG"       , SqlDbType.NVarChar, 1  );	// 外国送金フラグ
			cm.Parameters.Add("@INTERNATIONAL_ITEM_NO"        , SqlDbType.NVarChar, 4  );	// 国際項目番号
			cm.Parameters.Add("@REMITTANCE_PURPOSE"           , SqlDbType.NVarChar, 20 );	// 送金目的
			cm.Parameters.Add("@REMITTANCE_ALLOW_FLG"         , SqlDbType.NVarChar, 1  );	// 送金許可フラグ
			cm.Parameters.Add("@REMITTANCE_ALLOW_NO"          , SqlDbType.NVarChar, 10 );	// 送金許可番号
			cm.Parameters.Add("@REMITTANCE_MESSAGE"           , SqlDbType.NVarChar, 60 );	// 送金メッセージ
			cm.Parameters.Add("@APPROVAL_STATUS_TYPE"         , SqlDbType.NVarChar, 1  );	// 承認状況区分
// 管理番号 B13500 From
			cm.Parameters.Add("@RCPT_INPUT_NO_NEED_FLG"       , SqlDbType.NVarChar, 1  );	// 入荷入力不要フラグ
// 管理番号 B13500 To
			cm.Parameters.Add("@MYCOMP_CODE"                  , SqlDbType.NVarChar, 10 );	// 自社コード
			cm.Parameters.Add("@UPDATE_USER_NAME"             , SqlDbType.NVarChar, 50 );	// 更新者名
			cm.Parameters.Add("@UPDATE_PRG_NAME"              , SqlDbType.NVarChar, 50 );	// 更新プログラム名
// 管理番号 B20818 From
			cm.Parameters.Add("@PRG_UPDATE_DATETIME"          , SqlDbType.DateTime     );	// プログラム更新日時(楽観ロックチェック)
			cm.Parameters.Add("@REF_PRG_UPDATE_DATETIME"      , SqlDbType.DateTime     );	// 参照元プログラム更新日時(楽観ロックチェック)
// 管理番号 B20818 To
// 管理番号 B15710 From
			cm.Parameters.Add("@WK_KEY"                       , SqlDbType.NVarChar, 50 );
// 管理番号 B15710 To
// 管理番号 K22217 From
			cm.Parameters.Add("@APPROVAL_PLAN_EMP_CODE"       , SqlDbType.NVarChar , 10 );
			cm.Parameters.Add("@CHANGE_APPROVAL_ROUTE_ID"     , SqlDbType.Decimal  , 10 );
// 管理番号 K22217 To
// 管理番号 K24789 From
			cm.Parameters.Add("@CTAX_IMPOSE_FLG"              , SqlDbType.NVarChar , 1   );	// 消費税課税フラグ
			cm.Parameters.Add("@CTAX_BUILDUP_TYPE"            , SqlDbType.NVarChar , 1   );	// 消費税積上区分
			cm.Parameters.Add("@CTAX_FRACTION_ROUND_TYPE"     , SqlDbType.NVarChar , 1   );	// 消費税端数丸め区分
// 管理番号 K24789 To
// 管理番号 K25680 From
			cm.Parameters.Add("@IMPORT_SLIP_NO"               ,SqlDbType.NVarChar , 50   );	// 取込伝票番号
// 管理番号 K25680 To
// 管理番号 K25679 From
			cm.Parameters.Add("@PO_ADMIN_NO"                  ,SqlDbType.NVarChar , 50   );	// 発注管理番号
			cm.Parameters.Add("@SUPL_SLIP_NO"                 , SqlDbType.NVarChar, 10   );	// 仕入先伝票番号
			cm.Parameters.Add("@PROC_TYPE"                    , SqlDbType.NVarChar, 1    );	// 処理区分
// 管理番号 K25679 To
// 管理番号K27058 From
			cm.Parameters.Add("@PU_MODE_TYPE_DTIL_CODE"			, SqlDbType.NVarChar , 2 );	// 仕入形態区分明細
			cm.Parameters.Add("@BOOK_BASIS_TYPE_DTIL_CODE"		, SqlDbType.NVarChar , 2 );	// 計上基準区分明細
// 管理番号K27058 To
			cm.Parameters.Add("@PU_NO"                        , SqlDbType.NVarChar, 10 );	// 仕入番号
			cm.Parameters.Add("@RET"                          , SqlDbType.Decimal , 5  );   // エラー番号
// 管理番号K27057 From
//			cm.Parameters.Add("@RESULT_INFORMATION"           , SqlDbType.NVarChar, 100);	// エラーメッセージ
			cm.Parameters.Add("@RESULT_INFORMATION"           , SqlDbType.NVarChar, -1);	// エラーメッセージ
			BL_CM_MS_CustomItem.SetSqlParameterCollection(commonData, BL_CM_MS_CustomItem.InputHead, "SCMM05_PU", validRowData.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, cm.Parameters);
// 管理番号K27057 To
// 管理番号K27154 From
			cm.Parameters.Add("@DEAL_TYPE_CODE"               , SqlDbType.NVarChar, 3    );	// 取引区分コード
// 管理番号K27154 To
			cm.Parameters["@PU_NO"].Direction              = ParameterDirection.Output;
			cm.Parameters["@RET"].Direction                = ParameterDirection.Output;
			cm.Parameters["@RESULT_INFORMATION"].Direction = ParameterDirection.Output;

			cm.Parameters["@ORG_PU_NO"].Value                    = ConvertDBData.ToNVarChar(validRowData.PuNo);
			cm.Parameters["@DTIL_CHANGED_FLG"].Value             = ConvertDBData.ToNVarChar(validRowData.DtilChangedFlg);
			cm.Parameters["@PU_NAME"].Value                      = ConvertDBData.ToNVarChar(validRowData.PuName);
			cm.Parameters["@PU_DATE"].Value                      = ConvertDBData.ToDateTime(validRowData.PuDate);
// 管理番号 K16590 From
			cm.Parameters["@DEAL_DATE"].Value                    = ConvertDBData.ToDateTime(validRowData.DealDate);
			cm.Parameters["@RED_PU_DATE"].Value                  = ConvertDBData.ToDateTime(keyColumn.DeleteDate);
// 管理番号 K16590 To
			cm.Parameters["@PO_NO"].Value                        = ConvertDBData.ToNVarChar(validRowData.PoNo);
			cm.Parameters["@RCPT_NO"].Value                      = ConvertDBData.ToNVarChar(validRowData.RcptNo);
			cm.Parameters["@PU_MODE_TYPE"].Value                 = ConvertDBData.ToNVarChar(validRowData.PuModeType);
			cm.Parameters["@REF_PU_NO"].Value                    = ConvertDBData.ToNVarChar(validRowData.RefPuNo);
			cm.Parameters["@CUR_CODE"].Value                     = ConvertDBData.ToNVarChar(validRowData.CurCode);
			cm.Parameters["@EXCHANGE_TYPE"].Value                = ConvertDBData.ToNVarChar(validRowData.ExchangeType);
			cm.Parameters["@EXCHANGE_REZ_NO"].Value              = ConvertDBData.ToNVarChar(validRowData.ExchangeRezNo);
			cm.Parameters["@RATE"].Value                         = ConvertDBData.ToDecimal(validRowData.Rate);
			cm.Parameters["@DEPT_CODE"].Value                    = ConvertDBData.ToNVarChar(validRowData.DeptCode);
			cm.Parameters["@ORIGIN_DEPT_CODE"].Value             = ConvertDBData.ToNVarChar(validRowData.OriginDeptCode);
			cm.Parameters["@OLD_DEPT_CODE"].Value                = ConvertDBData.ToNVarChar(validRowData.OldDeptCode);
			cm.Parameters["@ORG_CHANGE_ID"].Value                = ConvertDBData.ToDecimal(validRowData.OrgChangeId);
			cm.Parameters["@DATA_MIGRATE_DATETIME"].Value        = ConvertDBData.ToDateTime(validRowData.DataMigrateDatetime);
			cm.Parameters["@EMP_CODE"].Value                     = ConvertDBData.ToNVarChar(validRowData.EmpCode);
			cm.Parameters["@PROJ_CODE"].Value                    = ConvertDBData.ToNVarChar(validRowData.ProjCode);
			cm.Parameters["@PROJ_SBNO"].Value                    = ConvertDBData.ToNVarChar(validRowData.ProjSbno);
			cm.Parameters["@SUPL_CODE"].Value                    = ConvertDBData.ToNVarChar(validRowData.SuplCode);
			cm.Parameters["@SUPL_SBNO"].Value                    = ConvertDBData.ToNVarChar(validRowData.SuplSbno);
			cm.Parameters["@TEMP_CODE_FLG"].Value                = ConvertDBData.ToNVarChar(validRowData.TempCodeFlg);
			cm.Parameters["@SUPL_NAME"].Value                    = ConvertDBData.ToNVarChar(validRowData.SuplName);
			cm.Parameters["@SUPL_SHORT_NAME"].Value              = ConvertDBData.ToNVarChar(validRowData.SuplShortName);
			cm.Parameters["@SUPL_DEPT_NAME_1"].Value             = ConvertDBData.ToNVarChar(validRowData.SuplDeptName1);
			cm.Parameters["@SUPL_DEPT_NAME_2"].Value             = ConvertDBData.ToNVarChar(validRowData.SuplDeptName2);
			cm.Parameters["@SUPL_COUNTRY_CODE"].Value            = ConvertDBData.ToNVarChar(validRowData.SuplCountryCode);
			cm.Parameters["@SUPL_ZIP"].Value                     = ConvertDBData.ToNVarChar(validRowData.SuplZip);
			cm.Parameters["@SUPL_STATE"].Value                   = ConvertDBData.ToNVarChar(validRowData.SuplState);
			cm.Parameters["@SUPL_CITY"].Value                    = ConvertDBData.ToNVarChar(validRowData.SuplCity);
			cm.Parameters["@SUPL_ADDRESS1"].Value                = ConvertDBData.ToNVarChar(validRowData.SuplAddress1);
			cm.Parameters["@SUPL_ADDRESS2"].Value                = ConvertDBData.ToNVarChar(validRowData.SuplAddress2);
			cm.Parameters["@SUPL_PHONE"].Value                   = ConvertDBData.ToNVarChar(validRowData.SuplPhone);
			cm.Parameters["@SUPL_FAX"].Value                     = ConvertDBData.ToNVarChar(validRowData.SuplFax);
			cm.Parameters["@SUPL_USER_NAME"].Value               = ConvertDBData.ToNVarChar(validRowData.SuplUserName);
			cm.Parameters["@AC_NO"].Value                        = ConvertDBData.ToNVarChar(validRowData.AcNo);
			cm.Parameters["@AC_HOLDER"].Value                    = ConvertDBData.ToNVarChar(validRowData.AcHolder);
			cm.Parameters["@AC_TYPE"].Value                      = ConvertDBData.ToNVarChar(validRowData.AcType);
			cm.Parameters["@BANK_AC_TYPE"].Value                 = ConvertDBData.ToNVarChar(validRowData.BankAcType);
			cm.Parameters["@BANK_COUNTRY_CODE"].Value            = ConvertDBData.ToNVarChar(validRowData.BankCountryCode);
			cm.Parameters["@BANK_CODE"].Value                    = ConvertDBData.ToNVarChar(validRowData.BankCode);
			cm.Parameters["@BANK_BRANCH_CODE"].Value             = ConvertDBData.ToNVarChar(validRowData.BankBranchCode);
			cm.Parameters["@REMIT_FEE_TYPE"].Value               = ConvertDBData.ToNVarChar(validRowData.RemitFeeType);
			cm.Parameters["@REMIT_MTHD_1_DEAL_TYPE"].Value       = ConvertDBData.ToNVarChar(validRowData.RemitMthd1DealType);
			cm.Parameters["@REMIT_MTHD_2_TYPE"].Value            = ConvertDBData.ToNVarChar(validRowData.RemitMthd2Type);
			cm.Parameters["@DELI_TYPE"].Value                    = ConvertDBData.ToNVarChar(validRowData.DeliType);
			cm.Parameters["@WH_CODE"].Value                      = ConvertDBData.ToNVarChar(validRowData.WhCode);
			cm.Parameters["@DELI_CUST_CODE"].Value               = ConvertDBData.ToNVarChar(validRowData.DeliCustCode);
			cm.Parameters["@DELI_CUST_SBNO"].Value               = ConvertDBData.ToNVarChar(validRowData.DeliCustSbno);
			cm.Parameters["@DELI_PLACE_CODE"].Value              = ConvertDBData.ToNVarChar(validRowData.DeliPlaceCode);
			cm.Parameters["@DELI_PLACE_NAME"].Value              = ConvertDBData.ToNVarChar(validRowData.DeliPlaceName);
			cm.Parameters["@DELI_PLACE_COUNTRY_CODE"].Value      = ConvertDBData.ToNVarChar(validRowData.DeliPlaceCountryCode);
			cm.Parameters["@DELI_PLACE_ZIP"].Value               = ConvertDBData.ToNVarChar(validRowData.DeliPlaceZip);
			cm.Parameters["@DELI_PLACE_STATE"].Value             = ConvertDBData.ToNVarChar(validRowData.DeliPlaceState);
			cm.Parameters["@DELI_PLACE_CITY"].Value              = ConvertDBData.ToNVarChar(validRowData.DeliPlaceCity);
			cm.Parameters["@DELI_PLACE_ADDRESS1"].Value          = ConvertDBData.ToNVarChar(validRowData.DeliPlaceAddress1);
			cm.Parameters["@DELI_PLACE_ADDRESS2"].Value          = ConvertDBData.ToNVarChar(validRowData.DeliPlaceAddress2);
			cm.Parameters["@DELI_PLACE_PHONE"].Value             = ConvertDBData.ToNVarChar(validRowData.DeliPlacePhone);
			cm.Parameters["@DELI_PLACE_FAX"].Value               = ConvertDBData.ToNVarChar(validRowData.DeliPlaceFax);
			cm.Parameters["@DELI_PLACE_USER_NAME"].Value         = ConvertDBData.ToNVarChar(validRowData.DeliPlaceUserName);
			cm.Parameters["@DT_TYPE"].Value                      = ConvertDBData.ToNVarChar(validRowData.DtType);
			cm.Parameters["@DT1_STTL_MTHD_CODE"].Value           = ConvertDBData.ToNVarChar(validRowData.Dt1SttlMthdCode);
			cm.Parameters["@DT1_BASIS_AMT"].Value                = ConvertDBData.ToDecimal(validRowData.Dt1BasisAmt);
			cm.Parameters["@DT2_STTL_MTHD_CODE"].Value           = ConvertDBData.ToNVarChar(validRowData.Dt2SttlMthdCode);
			cm.Parameters["@DT2_RATIO"].Value                    = ConvertDBData.ToDecimal(validRowData.Dt2Ratio);
			cm.Parameters["@DT3_STTL_MTHD_CODE"].Value           = ConvertDBData.ToNVarChar(validRowData.Dt3SttlMthdCode);
			cm.Parameters["@DT_SIGHT"].Value                     = ConvertDBData.ToDecimal(validRowData.DtSight);
			cm.Parameters["@CUTOFF_DATE"].Value                  = ConvertDBData.ToDateTime(validRowData.CutoffDate);
			cm.Parameters["@PYMT_PLAN_DATE"].Value               = ConvertDBData.ToDateTime(validRowData.PymtPlanDate);
			cm.Parameters["@DT_NOTE"].Value                      = ConvertDBData.ToNVarChar(validRowData.DtNote);
			cm.Parameters["@SUPL_BILL_SLIP_NO"].Value            = ConvertDBData.ToNVarChar(validRowData.SuplBillSlipNo);
			cm.Parameters["@CANCELED_ORDER_FLG"].Value           = ConvertDBData.ToNVarChar(validRowData.CanceledOrderFlg);
			cm.Parameters["@OVERSEAS_FLG"].Value                 = ConvertDBData.ToNVarChar(validRowData.OverseasFlg);
			cm.Parameters["@TENOR_CODE"].Value                   = ConvertDBData.ToNVarChar(validRowData.TenorCode);
			cm.Parameters["@FMONEY_STTL_PERIOD_STT_MONTH"].Value = ConvertDBData.ToDateTime(validRowData.FmoneySttlPeriodSttMonth, DateTimeType.Month);
			cm.Parameters["@FMONEY_STTL_PERIOD_END_MONTH"].Value = ConvertDBData.ToDateTime(validRowData.FmoneySttlPeriodEndMonth, DateTimeType.Month);
			cm.Parameters["@LC_NO"].Value                        = ConvertDBData.ToNVarChar(validRowData.LcNo);
// 管理番号 B13878 From
			cm.Parameters["@HOLD_FLG"].Value					 = ConvertDBData.ToNVarChar(validRowData.HoldFlg);
// 管理番号 B13878 To
			cm.Parameters["@REMARKS_CODE"].Value                 = ConvertDBData.ToNVarChar(validRowData.RemarksCode);
			cm.Parameters["@REMARKS"].Value                      = ConvertDBData.ToNVarChar(validRowData.Remarks);
// 管理番号 B13798 From
			cm.Parameters["@ADMIN_ITEM1"].Value					= ConvertDBData.ToNVarChar(validRowData.AdminItem1);
			cm.Parameters["@ADMIN_ITEM2"].Value					= ConvertDBData.ToNVarChar(validRowData.AdminItem2);
			cm.Parameters["@ADMIN_ITEM3"].Value					= ConvertDBData.ToNVarChar(validRowData.AdminItem3);
// 管理番号 B13798 To
// 管理番号 K20687 From
			cm.Parameters["@BOOK_BASIS_TYPE"].Value				= ConvertDBData.ToNVarChar(validRowData.BookBasisType);
// 管理番号 K20687 To
			cm.Parameters["@OUTLAND_REMITTANCE_FLG"].Value       = ConvertDBData.ToNVarChar(validRowData.OutlandRemittanceFlg);
			cm.Parameters["@INTERNATIONAL_ITEM_NO"].Value        = ConvertDBData.ToNVarChar(validRowData.InternationalItemNo);
			cm.Parameters["@REMITTANCE_PURPOSE"].Value           = ConvertDBData.ToNVarChar(validRowData.RemittancePurpose);
			cm.Parameters["@REMITTANCE_ALLOW_FLG"].Value         = ConvertDBData.ToNVarChar(validRowData.RemittanceAllowFlg);
			cm.Parameters["@REMITTANCE_ALLOW_NO"].Value          = ConvertDBData.ToNVarChar(validRowData.RemittanceAllowNo);
			cm.Parameters["@REMITTANCE_MESSAGE"].Value           = ConvertDBData.ToNVarChar(validRowData.RemittanceMessage);
			cm.Parameters["@APPROVAL_STATUS_TYPE"].Value         = ConvertDBData.ToNVarChar(validRowData.ApprovalStatusType);
// 管理番号 B13500 From
			cm.Parameters["@RCPT_INPUT_NO_NEED_FLG"].Value       = ConvertDBData.ToNVarChar(validRowData.RcptInputNoNeedFlg);
// 管理番号 B13500 To
// 管理番号 B15710 From
			cm.Parameters["@WK_KEY"].Value                       = ConvertDBData.ToNVarChar(keyColumn.WkKey);
// 管理番号 B15710 To
// 管理番号 K22217 From
            cm.Parameters["@APPROVAL_PLAN_EMP_CODE"].Value        = ConvertDBData.ToNVarChar(validRowData.ApprovalPlanEmpCode);
            cm.Parameters["@CHANGE_APPROVAL_ROUTE_ID"].Value      = ConvertDBData.ToDecimal(validRowData.ChangeApprovalRouteId);
// 管理番号 K22217 To
// 管理番号 K24789 From
			cm.Parameters["@CTAX_IMPOSE_FLG"].Value              = ConvertDBData.ToNVarChar(validRowData.ImposeFlg);
			cm.Parameters["@CTAX_BUILDUP_TYPE"].Value            = ConvertDBData.ToNVarChar(validRowData.CtaxBuildupType);
			cm.Parameters["@CTAX_FRACTION_ROUND_TYPE"].Value     = ConvertDBData.ToNVarChar(validRowData.CtaxRoundType);
// 管理番号 K24789 To
// 管理番号 K25680 From
			cm.Parameters["@IMPORT_SLIP_NO"].Value               = ConvertDBData.ToNVarChar(validRowData.ImportSlipNo);
// 管理番号 K25680 To
// 管理番号 K25679 From
			cm.Parameters["@PO_ADMIN_NO"].Value                  = ConvertDBData.ToNVarChar(validRowData.PoAdminNo);
			cm.Parameters["@SUPL_SLIP_NO"].Value                 = ConvertDBData.ToNVarChar(validRowData.SuplSlipNo);
			cm.Parameters["@PROC_TYPE"].Value                    = ConvertDBData.ToNVarChar(validRowData.ProcType);
// 管理番号 K25679 To
// 管理番号K27058 From
			cm.Parameters["@PU_MODE_TYPE_DTIL_CODE"].Value			= ConvertDBData.ToNVarChar(validRowData.PuModeTypeDtilCode);
			cm.Parameters["@BOOK_BASIS_TYPE_DTIL_CODE"].Value		= ConvertDBData.ToNVarChar(validRowData.BookBasisTypeDtilCode);
// 管理番号K27058 To
			cm.Parameters["@MYCOMP_CODE"].Value                  = ConvertDBData.ToNVarChar(commonData.CompCode);
			cm.Parameters["@UPDATE_USER_NAME"].Value             = ConvertDBData.ToNVarChar(commonData.UserName);
			cm.Parameters["@UPDATE_PRG_NAME"].Value              = ConvertDBData.ToNVarChar(commonData.PageID);
// 管理番号 B20818 From
			cm.Parameters["@PRG_UPDATE_DATETIME"].Value		     = validRowData.UpdateDatetime;
			cm.Parameters["@REF_PRG_UPDATE_DATETIME"].Value      = validRowData.RefUpdateDatetime;
// 管理番号 B20818 To
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlParameterCollection(commonData, BL_CM_MS_CustomItem.InputHead, "SCMM05_PU", validRowData.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, cm.Parameters, validRowData.CustomItemHead);
// 管理番号K27057 To
// 管理番号K27154 From
			cm.Parameters["@DEAL_TYPE_CODE"].Value               = ConvertDBData.ToNVarChar(validRowData.DealTypeCode);
// 管理番号K27154 To

			return cm;
		}
		//[SC_MM_05_Insert]パラメータ
		private static SqlCommandWrapper InsertCommand(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base validRowData)	// 管理番号K27230
		{
			SqlCommandWrapper cm  = new SqlCommandWrapper();	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
			cm.Parameters.Add("@RCPT_CALL_FLG"                , SqlDbType.NVarChar , 1   );	// 入荷から呼ばれたかフラグ（0:入荷以外、1:入荷から呼ばれたとき）
			cm.Parameters.Add("@ORG_PU_NO"                    , SqlDbType.NVarChar , 10  );	// 修正元伝票の仕入番号（赤黒処理の黒伝Insert処理時のみ必要）
			cm.Parameters.Add("@PU_NAME"                      , SqlDbType.NVarChar , 30  ); // 仕入件名
			cm.Parameters.Add("@PU_DATE"                      , SqlDbType.DateTime       ); // 仕入日
// 管理番号 K16590 From
			cm.Parameters.Add("@DEAL_DATE"                    , SqlDbType.DateTime       ); // 取引日
// 管理番号 K16590 To
			cm.Parameters.Add("@PO_NO"                        , SqlDbType.NVarChar , 10  );	// 発注番号
			cm.Parameters.Add("@RCPT_NO"                      , SqlDbType.NVarChar , 10  );	// 入荷番号
			cm.Parameters.Add("@PU_MODE_TYPE"                 , SqlDbType.NVarChar , 1   );	// 仕入形態区分
			cm.Parameters.Add("@REF_PU_NO"                    , SqlDbType.NVarChar , 10  );	// 参照仕入番号
			cm.Parameters.Add("@CUR_CODE"                     , SqlDbType.NVarChar , 3   );	// 通貨コード
			cm.Parameters.Add("@EXCHANGE_TYPE"                , SqlDbType.NVarChar , 1   );	// 為替区分
			cm.Parameters.Add("@EXCHANGE_REZ_NO"              , SqlDbType.NVarChar , 10  );	// 為替予約番号
			cm.Parameters.Add("@RATE"                         , SqlDbType.Decimal  , 6   );	// レート
			cm.Parameters.Add("@DEPT_CODE"                    , SqlDbType.NVarChar , 10  );	// 部門コード
			cm.Parameters.Add("@ORIGIN_DEPT_CODE"             , SqlDbType.NVarChar , 10  );	// 発生部門コード
			cm.Parameters.Add("@OLD_DEPT_CODE"                , SqlDbType.NVarChar , 10  );	// 旧部門コード
			cm.Parameters.Add("@ORG_CHANGE_ID"                , SqlDbType.Decimal  , 10  );	// 組織変更ID
			cm.Parameters.Add("@DATA_MIGRATE_DATETIME"        , SqlDbType.DateTime       ); // データ移行日時
			cm.Parameters.Add("@EMP_CODE"                     , SqlDbType.NVarChar , 10  );	// 社員コード
// 管理番号 K16588 From
//			cm.Parameters.Add("@PROJ_CODE"                    , SqlDbType.NVarChar , 8   );	// プロジェクトコード
			cm.Parameters.Add("@PROJ_CODE"                    , SqlDbType.NVarChar , 20   );	// プロジェクトコード
// 管理番号 K16588 To
			cm.Parameters.Add("@PROJ_SBNO"                    , SqlDbType.NVarChar , 2   );	// プロジェクト枝番
// 管理番号 B20741 From
			cm.Parameters.Add("@PROJ_CHANGED_FLG"             , SqlDbType.NVarChar , 1   );	// プロジェクト変更フラグ
// 管理番号 B20741 To
// 管理番号K27011 From
//			cm.Parameters.Add("@SUPL_CODE"                    , SqlDbType.NVarChar , 8   );	// 仕入先コード
//			cm.Parameters.Add("@SUPL_SBNO"                    , SqlDbType.NVarChar , 2   );	// 仕入先枝番
			cm.Parameters.Add("@SUPL_CODE"						, SqlDbType.NVarChar , TypeLength.CompCode	);	// 仕入先コード
			cm.Parameters.Add("@SUPL_SBNO"						, SqlDbType.NVarChar , TypeLength.CompSbno	);	// 仕入先枝番
// 管理番号K27011 To
			cm.Parameters.Add("@TEMP_CODE_FLG"                , SqlDbType.NVarChar , 1   );	// 雑コードフラグ
// 管理番号K27011 From
//			cm.Parameters.Add("@SUPL_NAME"                    , SqlDbType.NVarChar , 50  );	// 仕入先名
//			cm.Parameters.Add("@SUPL_SHORT_NAME"              , SqlDbType.NVarChar , 10  );	// 仕入先略名\
			cm.Parameters.Add("@SUPL_NAME"						, SqlDbType.NVarChar , TypeLength.CompName	);	// 仕入先名
			cm.Parameters.Add("@SUPL_SHORT_NAME"				, SqlDbType.NVarChar , TypeLength.CompShortName	);	// 仕入先略名
// 管理番号K27011 To
			cm.Parameters.Add("@SUPL_DEPT_NAME_1"             , SqlDbType.NVarChar , 25  );	// 仕入先部門名1
			cm.Parameters.Add("@SUPL_DEPT_NAME_2"             , SqlDbType.NVarChar , 25  );	// 仕入先部門名2
			cm.Parameters.Add("@SUPL_COUNTRY_CODE"            , SqlDbType.NVarChar , 3   );	// 仕入先国コード
			cm.Parameters.Add("@SUPL_ZIP"                     , SqlDbType.NVarChar , 10  );	// 仕入先郵便番号
			cm.Parameters.Add("@SUPL_STATE"                   , SqlDbType.NVarChar , 15  );	// 仕入先都道府県名
			cm.Parameters.Add("@SUPL_CITY"                    , SqlDbType.NVarChar , 15  );	// 仕入先市区町村名
			cm.Parameters.Add("@SUPL_ADDRESS1"                , SqlDbType.NVarChar , 30  );	// 仕入先町域名
			cm.Parameters.Add("@SUPL_ADDRESS2"                , SqlDbType.NVarChar , 30  );	// 仕入先ビル名
			cm.Parameters.Add("@SUPL_PHONE"                   , SqlDbType.NVarChar , 15  );	// 仕入先電話番号
			cm.Parameters.Add("@SUPL_FAX"                     , SqlDbType.NVarChar , 15  );	// 仕入先FAX番号
			cm.Parameters.Add("@SUPL_USER_NAME"               , SqlDbType.NVarChar , 10  );	// 仕入先担当者名
			cm.Parameters.Add("@AC_NO"                        , SqlDbType.NVarChar , 20  );	// 口座番号
			cm.Parameters.Add("@AC_HOLDER"                    , SqlDbType.NVarChar , 50  );	// 口座名義人
			cm.Parameters.Add("@AC_TYPE"                      , SqlDbType.NVarChar , 1   );	// 口座区分
			cm.Parameters.Add("@BANK_AC_TYPE"                 , SqlDbType.NVarChar , 1   );	// 銀行口座区分
			cm.Parameters.Add("@BANK_COUNTRY_CODE"            , SqlDbType.NVarChar , 3   );	// 銀行国コード
			cm.Parameters.Add("@BANK_CODE"                    , SqlDbType.NVarChar , 20  );	// 銀行コード
			cm.Parameters.Add("@BANK_BRANCH_CODE"             , SqlDbType.NVarChar , 20  );	// 銀行支店コード
			cm.Parameters.Add("@REMIT_FEE_TYPE"               , SqlDbType.NVarChar , 1   );	// 振込手数料区分
			cm.Parameters.Add("@REMIT_MTHD_1_DEAL_TYPE"       , SqlDbType.NVarChar , 1   );	// 振込方法1扱い区分
			cm.Parameters.Add("@REMIT_MTHD_2_TYPE"            , SqlDbType.NVarChar , 1   );	// 振込方法2区分
			cm.Parameters.Add("@DELI_TYPE"                    , SqlDbType.NVarChar , 1   );	// 納入区分
			cm.Parameters.Add("@WH_CODE"                      , SqlDbType.NVarChar , 5   );	// 倉庫コード
// 管理番号K27011 From
//			cm.Parameters.Add("@DELI_CUST_CODE"               , SqlDbType.NVarChar , 8   );	// 納入先コード
//			cm.Parameters.Add("@DELI_CUST_SBNO"               , SqlDbType.NVarChar , 2   );	// 納入先枝番
			cm.Parameters.Add("@DELI_CUST_CODE"					, SqlDbType.NVarChar , TypeLength.CompCode	);	// 納入先コード
			cm.Parameters.Add("@DELI_CUST_SBNO"					, SqlDbType.NVarChar , TypeLength.CompSbno	);	// 納入先枝番
// 管理番号K27011 To
			cm.Parameters.Add("@DELI_PLACE_CODE"              , SqlDbType.NVarChar , 2   );	// 受渡場所コード
			cm.Parameters.Add("@DELI_PLACE_NAME"              , SqlDbType.NVarChar , 30  );	// 受渡場所名
			cm.Parameters.Add("@DELI_PLACE_COUNTRY_CODE"      , SqlDbType.NVarChar , 3   );	// 受渡場所国コード
			cm.Parameters.Add("@DELI_PLACE_ZIP"               , SqlDbType.NVarChar , 10  );	// 受渡場所郵便番号
			cm.Parameters.Add("@DELI_PLACE_STATE"             , SqlDbType.NVarChar , 15  );	// 受渡場所都道府県名
			cm.Parameters.Add("@DELI_PLACE_CITY"              , SqlDbType.NVarChar , 15  );	// 受渡場所市区町村名
			cm.Parameters.Add("@DELI_PLACE_ADDRESS1"          , SqlDbType.NVarChar , 30  );	// 受渡場所町域名
			cm.Parameters.Add("@DELI_PLACE_ADDRESS2"          , SqlDbType.NVarChar , 30  );	// 受渡場所ビル名
			cm.Parameters.Add("@DELI_PLACE_PHONE"             , SqlDbType.NVarChar , 15  );	// 受渡場所電話番号
			cm.Parameters.Add("@DELI_PLACE_FAX"               , SqlDbType.NVarChar , 15  );	// 受渡場所FAX番号
			cm.Parameters.Add("@DELI_PLACE_USER_NAME"         , SqlDbType.NVarChar , 10  );	// 受渡場所担当者名
			cm.Parameters.Add("@DT_TYPE"                      , SqlDbType.NVarChar , 1   );	// 取引条件区分
			cm.Parameters.Add("@DT1_STTL_MTHD_CODE"           , SqlDbType.NVarChar , 3   );	// 取引条件1決済方法コード
			cm.Parameters.Add("@DT1_BASIS_AMT"                , SqlDbType.Decimal  , 12  );	// 取引条件1基準金額
			cm.Parameters.Add("@DT2_STTL_MTHD_CODE"           , SqlDbType.NVarChar , 3   );	// 取引条件2決済方法コード
			cm.Parameters.Add("@DT2_RATIO"                    , SqlDbType.Decimal  , 3   );	// 取引条件2比率
			cm.Parameters.Add("@DT3_STTL_MTHD_CODE"           , SqlDbType.NVarChar , 3   );	// 取引条件3決済方法コード
			cm.Parameters.Add("@DT_SIGHT"                     , SqlDbType.Decimal  , 3   );	// 取引条件サイト
			cm.Parameters.Add("@CUTOFF_DATE"                  , SqlDbType.DateTime       );	// 締日
			cm.Parameters.Add("@PYMT_PLAN_DATE"               , SqlDbType.DateTime       );	// 支払予定日
			cm.Parameters.Add("@DT_NOTE"                      , SqlDbType.NVarChar , 50  );	// 取引条件表記
			cm.Parameters.Add("@SUPL_BILL_SLIP_NO"            , SqlDbType.NVarChar , 15  );	// 仕入先請求書番号
			cm.Parameters.Add("@CANCELED_ORDER_FLG"           , SqlDbType.NVarChar , 1   );	// 出合フラグ
			cm.Parameters.Add("@OVERSEAS_FLG"                 , SqlDbType.NVarChar , 1   );	// 海外フラグ
			cm.Parameters.Add("@TENOR_CODE"                   , SqlDbType.NVarChar , 3   );	// 建値コード
			cm.Parameters.Add("@FMONEY_STTL_PERIOD_STT_MONTH" , SqlDbType.DateTime       );	// 外貨決済期間開始月
			cm.Parameters.Add("@FMONEY_STTL_PERIOD_END_MONTH" , SqlDbType.DateTime       );	// 外貨決済期間終了月
			cm.Parameters.Add("@LC_NO"                        , SqlDbType.NVarChar , 16  );	// LC番号
// 管理番号 B13878 From
			cm.Parameters.Add("@HOLD_FLG"					  , SqlDbType.NVarChar , 1   ); // 保留フラグ
// 管理番号 B13878 To
			cm.Parameters.Add("@REMARKS_CODE"                 , SqlDbType.NVarChar , 3   );	// 摘要コード
			cm.Parameters.Add("@REMARKS"                      , SqlDbType.NVarChar , 100 );	// 摘要
// 管理番号 B13798 From
			cm.Parameters.Add("@ADMIN_ITEM1"                  , SqlDbType.NVarChar , 30);	// 管理項目1
			cm.Parameters.Add("@ADMIN_ITEM2"                  , SqlDbType.NVarChar , 30);	// 管理項目2
			cm.Parameters.Add("@ADMIN_ITEM3"                  , SqlDbType.NVarChar , 30);	// 管理項目3
// 管理番号 B13798 To
// 管理番号 K20687 From
			cm.Parameters.Add("@BOOK_BASIS_TYPE"			  , SqlDbType.NVarChar , 1 );	// 計上基準区分
// 管理番号 K20687 To
			cm.Parameters.Add("@OUTLAND_REMITTANCE_FLG"       , SqlDbType.NVarChar , 1   );	// 外国送金フラグ
			cm.Parameters.Add("@INTERNATIONAL_ITEM_NO"        , SqlDbType.NVarChar , 4   );	// 国際項目番号
			cm.Parameters.Add("@REMITTANCE_PURPOSE"           , SqlDbType.NVarChar , 20  );	// 送金目的
			cm.Parameters.Add("@REMITTANCE_ALLOW_FLG"         , SqlDbType.NVarChar , 1   );	// 送金許可フラグ
			cm.Parameters.Add("@REMITTANCE_ALLOW_NO"          , SqlDbType.NVarChar , 10  );	// 送金許可番号
			cm.Parameters.Add("@REMITTANCE_MESSAGE"           , SqlDbType.NVarChar , 60  );	// 送金メッセージ
			cm.Parameters.Add("@APPROVAL_STATUS_TYPE"         , SqlDbType.NVarChar , 1   );	// 承認状況区分
// 管理番号 B13500 From
			cm.Parameters.Add("@RCPT_INPUT_NO_NEED_FLG"       , SqlDbType.NVarChar , 1   );	// 入荷入力不要フラグ
// 管理番号 B13500 To
			cm.Parameters.Add("@MYCOMP_CODE"                  , SqlDbType.NVarChar , 10  );	// 自社コード
			cm.Parameters.Add("@UPDATE_USER_NAME"             , SqlDbType.NVarChar , 50  );	// 更新者名
			cm.Parameters.Add("@UPDATE_PRG_NAME"              , SqlDbType.NVarChar , 50  );	// 更新プログラム名
// 管理番号 B20818 From
			cm.Parameters.Add("@REF_PRG_UPDATE_DATETIME"      , SqlDbType.DateTime       ); // 参照元プログラム更新日時(楽観ロックチェック)
// 管理番号 B20818 To
// 管理番号 B15710 From
			cm.Parameters.Add("@WK_KEY"                       , SqlDbType.NVarChar , 50  );
// 管理番号 B15710 To
// 管理番号 K22205 From
            cm.Parameters.Add("@INPUT_EMP_CODE"               , SqlDbType.NVarChar, 10   );
// 管理番号 K22205 To
// 管理番号 K22217 From
			cm.Parameters.Add("@APPROVAL_PLAN_EMP_CODE"       , SqlDbType.NVarChar , 10  );
            cm.Parameters.Add("@CHANGE_APPROVAL_ROUTE_ID"     , SqlDbType.Decimal  , 10  );
// 管理番号 K22217 To
// 管理番号 K24789 From
			cm.Parameters.Add("@CTAX_IMPOSE_FLG"              , SqlDbType.NVarChar , 1   );	// 消費税課税フラグ
			cm.Parameters.Add("@CTAX_BUILDUP_TYPE"            , SqlDbType.NVarChar , 1   );	// 消費税積上区分
			cm.Parameters.Add("@CTAX_FRACTION_ROUND_TYPE"     , SqlDbType.NVarChar , 1   );	// 消費税端数丸め区分
// 管理番号 K24789 To
// 管理番号 K25680 From
			cm.Parameters.Add("@IMPORT_SLIP_NO"               ,SqlDbType.NVarChar , 50   );	// 取込伝票番号
// 管理番号 K25680 To
// 管理番号 K25679 From
			cm.Parameters.Add("@PO_ADMIN_NO"                  ,SqlDbType.NVarChar , 50   );	// 発注管理番号
			cm.Parameters.Add("@SUPL_SLIP_NO"                 , SqlDbType.NVarChar, 10   );	// 仕入先伝票番号
			cm.Parameters.Add("@PROC_TYPE"                    , SqlDbType.NVarChar, 1    );	// 処理区分
// 管理番号 K25679 To
// 管理番号K27058 From
			cm.Parameters.Add("@PU_MODE_TYPE_DTIL_CODE"			, SqlDbType.NVarChar , 2 );	// 仕入形態区分明細
			cm.Parameters.Add("@BOOK_BASIS_TYPE_DTIL_CODE"		, SqlDbType.NVarChar , 2 );	// 計上基準区分明細
// 管理番号K27058 To
			cm.Parameters.Add("@PU_NO"                        , SqlDbType.NVarChar , 10  );	// 仕入番号
			cm.Parameters.Add("@RET"                          , SqlDbType.Decimal  , 5   );	// エラー番号
			cm.Parameters.Add("@RESULT_INFORMATION"           , SqlDbType.NVarChar , 100 );	// エラーメッセージ
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlParameterCollection(commonData, BL_CM_MS_CustomItem.InputHead, "SCMM05_PU", validRowData.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, cm.Parameters);
// 管理番号K27057 To
// 管理番号K27154 From
			cm.Parameters.Add("@DEAL_TYPE_CODE"               , SqlDbType.NVarChar, 3    );	// 取引区分コード
// 管理番号K27154 To
			cm.Parameters["@PU_NO"].Direction              = ParameterDirection.Output;
			cm.Parameters["@RET"].Direction                = ParameterDirection.Output;
			cm.Parameters["@RESULT_INFORMATION"].Direction = ParameterDirection.Output;

			cm.Parameters["@RCPT_CALL_FLG"].Value                = ConvertDBData.ToNVarChar("0");
			cm.Parameters["@ORG_PU_NO"].Value                    = ConvertDBData.ToNVarChar(validRowData.PuNo);
			cm.Parameters["@PU_NAME"].Value                      = ConvertDBData.ToNVarChar(validRowData.PuName);
			cm.Parameters["@PU_DATE"].Value                      = ConvertDBData.ToDateTime(validRowData.PuDate);
// 管理番号 K16590 From
			cm.Parameters["@DEAL_DATE"].Value                    = ConvertDBData.ToDateTime(validRowData.DealDate);
// 管理番号 K16590 To
			cm.Parameters["@PO_NO"].Value                        = ConvertDBData.ToNVarChar(validRowData.PoNo);
			cm.Parameters["@RCPT_NO"].Value                      = ConvertDBData.ToNVarChar(validRowData.RcptNo);
			cm.Parameters["@PU_MODE_TYPE"].Value                 = ConvertDBData.ToNVarChar(validRowData.PuModeType);
			cm.Parameters["@REF_PU_NO"].Value                    = ConvertDBData.ToNVarChar(validRowData.RefPuNo);
			cm.Parameters["@CUR_CODE"].Value                     = ConvertDBData.ToNVarChar(validRowData.CurCode);
			cm.Parameters["@EXCHANGE_TYPE"].Value                = ConvertDBData.ToNVarChar(validRowData.ExchangeType);
			cm.Parameters["@EXCHANGE_REZ_NO"].Value              = ConvertDBData.ToNVarChar(validRowData.ExchangeRezNo);
			cm.Parameters["@RATE"].Value                         = ConvertDBData.ToDecimal(validRowData.Rate);
			cm.Parameters["@DEPT_CODE"].Value                    = ConvertDBData.ToNVarChar(validRowData.DeptCode);
			cm.Parameters["@ORIGIN_DEPT_CODE"].Value             = ConvertDBData.ToNVarChar(validRowData.OriginDeptCode);
			cm.Parameters["@OLD_DEPT_CODE"].Value                = ConvertDBData.ToNVarChar(validRowData.OldDeptCode);
			cm.Parameters["@ORG_CHANGE_ID"].Value                = ConvertDBData.ToDecimal(validRowData.OrgChangeId);
			cm.Parameters["@DATA_MIGRATE_DATETIME"].Value        = ConvertDBData.ToDateTime(validRowData.DataMigrateDatetime);
			cm.Parameters["@EMP_CODE"].Value                     = ConvertDBData.ToNVarChar(validRowData.EmpCode);
			cm.Parameters["@PROJ_CODE"].Value                    = ConvertDBData.ToNVarChar(validRowData.ProjCode);
			cm.Parameters["@PROJ_SBNO"].Value                    = ConvertDBData.ToNVarChar(validRowData.ProjSbno);
// 管理番号 B20741 From
			cm.Parameters["@PROJ_CHANGED_FLG"].Value             = ConvertDBData.ToNVarChar("0");
// 管理番号 B20741 To
			cm.Parameters["@SUPL_CODE"].Value                    = ConvertDBData.ToNVarChar(validRowData.SuplCode);
			cm.Parameters["@SUPL_SBNO"].Value                    = ConvertDBData.ToNVarChar(validRowData.SuplSbno);
			cm.Parameters["@TEMP_CODE_FLG"].Value                = ConvertDBData.ToNVarChar(validRowData.TempCodeFlg);
			cm.Parameters["@SUPL_NAME"].Value                    = ConvertDBData.ToNVarChar(validRowData.SuplName);
			cm.Parameters["@SUPL_SHORT_NAME"].Value              = ConvertDBData.ToNVarChar(validRowData.SuplShortName);
			cm.Parameters["@SUPL_DEPT_NAME_1"].Value             = ConvertDBData.ToNVarChar(validRowData.SuplDeptName1);
			cm.Parameters["@SUPL_DEPT_NAME_2"].Value             = ConvertDBData.ToNVarChar(validRowData.SuplDeptName2);
			cm.Parameters["@SUPL_COUNTRY_CODE"].Value            = ConvertDBData.ToNVarChar(validRowData.SuplCountryCode);
			cm.Parameters["@SUPL_ZIP"].Value                     = ConvertDBData.ToNVarChar(validRowData.SuplZip);
			cm.Parameters["@SUPL_STATE"].Value                   = ConvertDBData.ToNVarChar(validRowData.SuplState);
			cm.Parameters["@SUPL_CITY"].Value                    = ConvertDBData.ToNVarChar(validRowData.SuplCity);
			cm.Parameters["@SUPL_ADDRESS1"].Value                = ConvertDBData.ToNVarChar(validRowData.SuplAddress1);
			cm.Parameters["@SUPL_ADDRESS2"].Value                = ConvertDBData.ToNVarChar(validRowData.SuplAddress2);
			cm.Parameters["@SUPL_PHONE"].Value                   = ConvertDBData.ToNVarChar(validRowData.SuplPhone);
			cm.Parameters["@SUPL_FAX"].Value                     = ConvertDBData.ToNVarChar(validRowData.SuplFax);
			cm.Parameters["@SUPL_USER_NAME"].Value               = ConvertDBData.ToNVarChar(validRowData.SuplUserName);
			cm.Parameters["@AC_NO"].Value                        = ConvertDBData.ToNVarChar(validRowData.AcNo);
			cm.Parameters["@AC_HOLDER"].Value                    = ConvertDBData.ToNVarChar(validRowData.AcHolder);
			cm.Parameters["@AC_TYPE"].Value                      = ConvertDBData.ToNVarChar(validRowData.AcType);
			cm.Parameters["@BANK_AC_TYPE"].Value                 = ConvertDBData.ToNVarChar(validRowData.BankAcType);
			cm.Parameters["@BANK_COUNTRY_CODE"].Value            = ConvertDBData.ToNVarChar(validRowData.BankCountryCode);
			cm.Parameters["@BANK_CODE"].Value                    = ConvertDBData.ToNVarChar(validRowData.BankCode);
			cm.Parameters["@BANK_BRANCH_CODE"].Value             = ConvertDBData.ToNVarChar(validRowData.BankBranchCode);
			cm.Parameters["@REMIT_FEE_TYPE"].Value               = ConvertDBData.ToNVarChar(validRowData.RemitFeeType);
			cm.Parameters["@REMIT_MTHD_1_DEAL_TYPE"].Value       = ConvertDBData.ToNVarChar(validRowData.RemitMthd1DealType);
			cm.Parameters["@REMIT_MTHD_2_TYPE"].Value            = ConvertDBData.ToNVarChar(validRowData.RemitMthd2Type);
			cm.Parameters["@DELI_TYPE"].Value                    = ConvertDBData.ToNVarChar(validRowData.DeliType);
			cm.Parameters["@WH_CODE"].Value                      = ConvertDBData.ToNVarChar(validRowData.WhCode);
			cm.Parameters["@DELI_CUST_CODE"].Value               = ConvertDBData.ToNVarChar(validRowData.DeliCustCode);
			cm.Parameters["@DELI_CUST_SBNO"].Value               = ConvertDBData.ToNVarChar(validRowData.DeliCustSbno);
			cm.Parameters["@DELI_PLACE_CODE"].Value              = ConvertDBData.ToNVarChar(validRowData.DeliPlaceCode);
			cm.Parameters["@DELI_PLACE_NAME"].Value              = ConvertDBData.ToNVarChar(validRowData.DeliPlaceName);
			cm.Parameters["@DELI_PLACE_COUNTRY_CODE"].Value      = ConvertDBData.ToNVarChar(validRowData.DeliPlaceCountryCode);
			cm.Parameters["@DELI_PLACE_ZIP"].Value               = ConvertDBData.ToNVarChar(validRowData.DeliPlaceZip);
			cm.Parameters["@DELI_PLACE_STATE"].Value             = ConvertDBData.ToNVarChar(validRowData.DeliPlaceState);
			cm.Parameters["@DELI_PLACE_CITY"].Value              = ConvertDBData.ToNVarChar(validRowData.DeliPlaceCity);
			cm.Parameters["@DELI_PLACE_ADDRESS1"].Value          = ConvertDBData.ToNVarChar(validRowData.DeliPlaceAddress1);
			cm.Parameters["@DELI_PLACE_ADDRESS2"].Value          = ConvertDBData.ToNVarChar(validRowData.DeliPlaceAddress2);
			cm.Parameters["@DELI_PLACE_PHONE"].Value             = ConvertDBData.ToNVarChar(validRowData.DeliPlacePhone);
			cm.Parameters["@DELI_PLACE_FAX"].Value               = ConvertDBData.ToNVarChar(validRowData.DeliPlaceFax);
			cm.Parameters["@DELI_PLACE_USER_NAME"].Value         = ConvertDBData.ToNVarChar(validRowData.DeliPlaceUserName);
			cm.Parameters["@DT_TYPE"].Value                      = ConvertDBData.ToNVarChar(validRowData.DtType);
			cm.Parameters["@DT1_STTL_MTHD_CODE"].Value           = ConvertDBData.ToNVarChar(validRowData.Dt1SttlMthdCode);
			cm.Parameters["@DT1_BASIS_AMT"].Value                = ConvertDBData.ToDecimal(validRowData.Dt1BasisAmt);
			cm.Parameters["@DT2_STTL_MTHD_CODE"].Value           = ConvertDBData.ToNVarChar(validRowData.Dt2SttlMthdCode);
			cm.Parameters["@DT2_RATIO"].Value                    = ConvertDBData.ToDecimal(validRowData.Dt2Ratio);
			cm.Parameters["@DT3_STTL_MTHD_CODE"].Value           = ConvertDBData.ToNVarChar(validRowData.Dt3SttlMthdCode);
			cm.Parameters["@DT_SIGHT"].Value                     = ConvertDBData.ToDecimal(validRowData.DtSight);
			cm.Parameters["@CUTOFF_DATE"].Value                  = ConvertDBData.ToDateTime(validRowData.CutoffDate);
			cm.Parameters["@PYMT_PLAN_DATE"].Value               = ConvertDBData.ToDateTime(validRowData.PymtPlanDate);
			cm.Parameters["@DT_NOTE"].Value                      = ConvertDBData.ToNVarChar(validRowData.DtNote);
			cm.Parameters["@SUPL_BILL_SLIP_NO"].Value            = ConvertDBData.ToNVarChar(validRowData.SuplBillSlipNo);
			cm.Parameters["@CANCELED_ORDER_FLG"].Value           = ConvertDBData.ToNVarChar(validRowData.CanceledOrderFlg);
			cm.Parameters["@OVERSEAS_FLG"].Value                 = ConvertDBData.ToNVarChar(validRowData.OverseasFlg);
			cm.Parameters["@TENOR_CODE"].Value                   = ConvertDBData.ToNVarChar(validRowData.TenorCode);
			cm.Parameters["@FMONEY_STTL_PERIOD_STT_MONTH"].Value = ConvertDBData.ToDateTime(validRowData.FmoneySttlPeriodSttMonth, DateTimeType.Month);
			cm.Parameters["@FMONEY_STTL_PERIOD_END_MONTH"].Value = ConvertDBData.ToDateTime(validRowData.FmoneySttlPeriodEndMonth, DateTimeType.Month);
			cm.Parameters["@LC_NO"].Value                        = ConvertDBData.ToNVarChar(validRowData.LcNo);
// 管理番号 B13878 From
			cm.Parameters["@HOLD_FLG"].Value					 = ConvertDBData.ToNVarChar(validRowData.HoldFlg);
// 管理番号 B13878 To
			cm.Parameters["@REMARKS_CODE"].Value                 = ConvertDBData.ToNVarChar(validRowData.RemarksCode);
			cm.Parameters["@REMARKS"].Value                      = ConvertDBData.ToNVarChar(validRowData.Remarks);
// 管理番号 B13798 From
			cm.Parameters["@ADMIN_ITEM1"].Value					 = ConvertDBData.ToNVarChar(validRowData.AdminItem1);
			cm.Parameters["@ADMIN_ITEM2"].Value                  = ConvertDBData.ToNVarChar(validRowData.AdminItem2);
			cm.Parameters["@ADMIN_ITEM3"].Value                  = ConvertDBData.ToNVarChar(validRowData.AdminItem3);
// 管理番号 B13798 To
// 管理番号 K20687 From
			cm.Parameters["@BOOK_BASIS_TYPE"].Value				 = ConvertDBData.ToNVarChar(validRowData.BookBasisType);
// 管理番号 K20687 To
			cm.Parameters["@OUTLAND_REMITTANCE_FLG"].Value       = ConvertDBData.ToNVarChar(validRowData.OutlandRemittanceFlg);
			cm.Parameters["@INTERNATIONAL_ITEM_NO"].Value        = ConvertDBData.ToNVarChar(validRowData.InternationalItemNo);
			cm.Parameters["@REMITTANCE_PURPOSE"].Value           = ConvertDBData.ToNVarChar(validRowData.RemittancePurpose);
			cm.Parameters["@REMITTANCE_ALLOW_FLG"].Value         = ConvertDBData.ToNVarChar(validRowData.RemittanceAllowFlg);
			cm.Parameters["@REMITTANCE_ALLOW_NO"].Value          = ConvertDBData.ToNVarChar(validRowData.RemittanceAllowNo);
			cm.Parameters["@REMITTANCE_MESSAGE"].Value           = ConvertDBData.ToNVarChar(validRowData.RemittanceMessage);
			cm.Parameters["@APPROVAL_STATUS_TYPE"].Value         = ConvertDBData.ToNVarChar(validRowData.ApprovalStatusType);
// 管理番号 B13500 From
			if(validRowData.OverseasFlg.Equals("1"))
			{
				// 海外仕入時
				cm.Parameters["@RCPT_INPUT_NO_NEED_FLG"].Value       = ConvertDBData.ToNVarChar(validRowData.RcptInputNoNeedFlg);
			}
			else
			{
				// 国内仕入時
				cm.Parameters["@RCPT_INPUT_NO_NEED_FLG"].Value       = ConvertDBData.ToNVarChar("1");
			}
// 管理番号 B13500 To
// 管理番号 B15710 From
			cm.Parameters["@WK_KEY"].Value                       = ConvertDBData.ToNVarChar(keyColumn.WkKey);
// 管理番号 B15710 To
// 管理番号 K22205 From
            cm.Parameters["@INPUT_EMP_CODE"].Value               = ConvertDBData.ToNVarChar(validRowData.InputEmpCode);
// 管理番号 K22205 To
// 管理番号 K22217 From
            cm.Parameters["@APPROVAL_PLAN_EMP_CODE"].Value 　　　= ConvertDBData.ToNVarChar(validRowData.ApprovalPlanEmpCode);
            cm.Parameters["@CHANGE_APPROVAL_ROUTE_ID"].Value 　　= ConvertDBData.ToDecimal(validRowData.ChangeApprovalRouteId);
// 管理番号 K22217 To
// 管理番号 K24789 From
			cm.Parameters["@CTAX_IMPOSE_FLG"].Value              = ConvertDBData.ToNVarChar(validRowData.ImposeFlg);
			cm.Parameters["@CTAX_BUILDUP_TYPE"].Value            = ConvertDBData.ToNVarChar(validRowData.CtaxBuildupType);
			cm.Parameters["@CTAX_FRACTION_ROUND_TYPE"].Value     = ConvertDBData.ToNVarChar(validRowData.CtaxRoundType);
// 管理番号 K24789 To
// 管理番号 K25680 From
			cm.Parameters["@IMPORT_SLIP_NO"].Value               = ConvertDBData.ToNVarChar(validRowData.ImportSlipNo);
// 管理番号 K25680 To
// 管理番号 K25679 From
			cm.Parameters["@PO_ADMIN_NO"].Value                  = ConvertDBData.ToNVarChar(validRowData.PoAdminNo);
			cm.Parameters["@SUPL_SLIP_NO"].Value                 = ConvertDBData.ToNVarChar(validRowData.SuplSlipNo);
			cm.Parameters["@PROC_TYPE"].Value                    = ConvertDBData.ToNVarChar(validRowData.ProcType);
// 管理番号 K25679 To
// 管理番号K27058 From
			cm.Parameters["@PU_MODE_TYPE_DTIL_CODE"].Value			= ConvertDBData.ToNVarChar(validRowData.PuModeTypeDtilCode);
			cm.Parameters["@BOOK_BASIS_TYPE_DTIL_CODE"].Value		= ConvertDBData.ToNVarChar(validRowData.BookBasisTypeDtilCode);
// 管理番号K27058 To
			cm.Parameters["@MYCOMP_CODE"].Value                  = ConvertDBData.ToNVarChar(commonData.CompCode);
			cm.Parameters["@UPDATE_USER_NAME"].Value             = ConvertDBData.ToNVarChar(commonData.UserName);
			cm.Parameters["@UPDATE_PRG_NAME"].Value              = ConvertDBData.ToNVarChar(commonData.PageID);
// 管理番号 B20818 From
			cm.Parameters["@REF_PRG_UPDATE_DATETIME"].Value      = validRowData.RefUpdateDatetime;
// 管理番号 B20818 To
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlParameterCollection(commonData, BL_CM_MS_CustomItem.InputHead, "SCMM05_PU", validRowData.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, cm.Parameters, validRowData.CustomItemHead);
// 管理番号K27057 To
// 管理番号K27154 From
			cm.Parameters["@DEAL_TYPE_CODE"].Value               = ConvertDBData.ToNVarChar(validRowData.DealTypeCode);
// 管理番号K27154 To

			return cm;
		}
		//[SC_MM_05_Delete]パラメータ
		private static SqlCommandWrapper DeleteCommand(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base rowData)	// 管理番号K27230
		{
			SqlCommandWrapper cm = new SqlCommandWrapper();	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
			cm.Parameters.Add("@CANCEL_FLG"         , SqlDbType.NVarChar , 1  );	// 取消フラグ（0:修正用赤伝、1:削除用赤伝）
			cm.Parameters.Add("@RCPT_CALL_FLG"      , SqlDbType.NVarChar , 1  );	// 入荷から呼ばれたかフラグ（0:入荷以外、1:入荷から呼ばれたとき）
			cm.Parameters.Add("@ORG_PU_NO"          , SqlDbType.NVarChar , 10 );	// 削除される伝票の仕入番号
			cm.Parameters.Add("@PU_DATE"            , SqlDbType.DateTime      );	// 削除日
			cm.Parameters.Add("@MYCOMP_CODE"        , SqlDbType.NVarChar , 10 );	// 自社コード
			cm.Parameters.Add("@UPDATE_USER_NAME"   , SqlDbType.NVarChar , 50 );	// 更新者名
			cm.Parameters.Add("@UPDATE_PRG_NAME"    , SqlDbType.NVarChar , 50 );	// 更新プログラム名
// 管理番号 B20818 From
			cm.Parameters.Add("@PRG_UPDATE_DATETIME"     , SqlDbType.DateTime );
			cm.Parameters.Add("@REF_PRG_UPDATE_DATETIME" , SqlDbType.DateTime );
// 管理番号 B20818 To
// 管理番号 B15710 From
			cm.Parameters.Add("@WK_KEY"             , SqlDbType.NVarChar , 50 );
// 管理番号 B15710 To
// 管理番号 B20741 From
			cm.Parameters.Add("@PROJ_CHANGED_FLG"   , SqlDbType.NVarChar , 1   );	// プロジェクト変更フラグ
// 管理番号 B20741 To
// 管理番号 B22783 From
			cm.Parameters.Add("@DISP_PROJ_CODE"   , SqlDbType.NVarChar , 20 );	// プロジェクトコード
			cm.Parameters.Add("@DISP_PROJ_SBNO"   , SqlDbType.NVarChar , 2 );	// プロジェクト枝番
// 管理番号 B22783 To
// 管理番号 K25679 From
			cm.Parameters.Add("@SUPL_SLIP_NO"     , SqlDbType.NVarChar, 10   );	// 仕入先伝票番号
			cm.Parameters.Add("@PROC_TYPE"        , SqlDbType.NVarChar, 1    );	// 処理区分
// 管理番号 K25679 To
			cm.Parameters.Add("@RET"                , SqlDbType.Decimal  , 5  );	// エラー番号
			cm.Parameters.Add("@RESULT_INFORMATION" , SqlDbType.NVarChar , 100);	// エラーメッセージ
			cm.Parameters["@RET"].Direction                = ParameterDirection.Output;
			cm.Parameters["@RESULT_INFORMATION"].Direction = ParameterDirection.Output;

			cm.Parameters["@CANCEL_FLG"].Value       = "1";
			cm.Parameters["@RCPT_CALL_FLG"].Value    = "0";
			cm.Parameters["@ORG_PU_NO"].Value        = ConvertDBData.ToNVarChar(keyColumn.SlipNo);
			cm.Parameters["@PU_DATE"].Value          = ConvertDBData.ToDateTime(keyColumn.DeleteDate);
// 管理番号 B15710 From
			cm.Parameters["@WK_KEY"].Value           = ConvertDBData.ToNVarChar(keyColumn.WkKey);
// 管理番号 B15710 To
// 管理番号 B20741 From
			cm.Parameters["@PROJ_CHANGED_FLG"].Value = ConvertDBData.ToNVarChar("0");
// 管理番号 B20741 To
// 管理番号 B22783 From
			cm.Parameters["@DISP_PROJ_CODE"].Value   = ConvertDBData.ToNVarChar(rowData.ProjCode);
			cm.Parameters["@DISP_PROJ_SBNO"].Value   = ConvertDBData.ToNVarChar(rowData.ProjSbno);
// 管理番号 B22783 To
// 管理番号 K25679 From
			cm.Parameters["@SUPL_SLIP_NO"].Value     = ConvertDBData.ToNVarChar(rowData.SuplSlipNo);
			cm.Parameters["@PROC_TYPE"].Value        = ConvertDBData.ToNVarChar(rowData.ProcType);
// 管理番号 K25679 To
			cm.Parameters["@MYCOMP_CODE"].Value      = ConvertDBData.ToNVarChar(commonData.CompCode);
			cm.Parameters["@UPDATE_USER_NAME"].Value = ConvertDBData.ToNVarChar(commonData.UserName);
			cm.Parameters["@UPDATE_PRG_NAME"].Value  = ConvertDBData.ToNVarChar(commonData.PageID);
// 管理番号 B20818 From
			cm.Parameters["@PRG_UPDATE_DATETIME"].Value		= rowData.UpdateDatetime;
			cm.Parameters["@REF_PRG_UPDATE_DATETIME"].Value = rowData.RefUpdateDatetime;
// 管理番号 B20818 To

			return cm;
		}
		//更新系のストアドコマンド設定
		private static SqlCommandWrapper CreateStoredCommand(CommonData commonData, SqlConnection cn , SqlTransaction tr,IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base validRowData, string Process)	// 管理番号K27230
		{
			string procedureName = string.Empty;
			SqlCommandWrapper Command   = new SqlCommandWrapper();	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(Command, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To

			switch (Process)
			{
				case "Insert":	//新規
					procedureName = DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "SC_MM_05_Insert");
					Command       = InsertCommand(commonData, keyColumn, validRowData);
					break;
				case "Update":	//更新
					procedureName = DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "SC_MM_05_Update_Check");
					Command       = UpdateCommand(commonData, keyColumn, validRowData);
					break;
				case "Delete":	//削除
					procedureName = DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "SC_MM_05_Delete");
					Command       = DeleteCommand(commonData, keyColumn, validRowData);
					break;
			}

			//ストアド戻り値
			Command.Parameters.Add("@RETURN_VALUE", SqlDbType.Int);
			Command.Parameters["@RETURN_VALUE"].Direction = ParameterDirection.ReturnValue;
			Command.Connection  = cn;
			Command.Transaction = tr;
			Command.CommandText = procedureName;
			Command.CommandType = CommandType.StoredProcedure;
			return Command;
		}

		//一時テーブル作成
		private static void CreateTempTable(CommonData commonData, SqlConnection cn, SqlTransaction tr, IF_SC_MM_05_KeyColumn keyColumn)
		{
			//仕入明細
			StringBuilder sb = new StringBuilder();
			sb.Append(" CREATE TABLE [#PU_DTIL] ");
			sb.Append(" ( ");
			sb.Append("  [PU_LINE_ID]                [DECIMAL]  (10, 0) PRIMARY KEY ,");// 仕入行ID
			sb.Append("  [PU_LINE_NO]                [DECIMAL]  (10, 0) NULL ,");		// 仕入行番号
			sb.Append("  [PO_NO]                     [NVARCHAR] (10)    NULL ,");		// 発注番号
			sb.Append("  [PO_LINE_ID]                [DECIMAL]  (10, 0) NULL ,");		// 発注行ID
			sb.Append("  [RCPT_NO]                   [NVARCHAR] (10)    NULL ,");		// 入荷番号
			sb.Append("  [RCPT_LINE_ID]              [DECIMAL]  (10, 0) NULL ,");		// 入荷行ID
			sb.Append("  [SO_NO]                     [NVARCHAR] (10)    NULL ,");		// 受注番号
			sb.Append("  [SO_LINE_ID]                [DECIMAL]  (10, 0) NULL ,");		// 受注行ID
			sb.Append("  [SA_NO]                     [NVARCHAR] (10)    NULL ,");		// 売上番号
			sb.Append("  [SA_LINE_ID]                [DECIMAL]  (10, 0) NULL ,");		// 売上行ID
			sb.Append("  [WH_CODE]                   [NVARCHAR] (5)     NULL ,");		// 倉庫コード
// 管理番号K27011 From
//			sb.Append("  [PROD_CODE]                 [NVARCHAR] (20)    NULL ,");		// 商品コード
//			sb.Append("  [PROD_PO_NAME]              [NVARCHAR] (50)    NULL ,");		// 商品発注名
//			sb.Append("  [PROD_SHORT_NAME]           [NVARCHAR] (50)    NULL ,");		// 商品略名
			sb.Append("	[PROD_CODE]						[NVARCHAR] (").Append(TypeLength.ProdCode).Append(")		NULL ,");		// 商品コード
			sb.Append("	[PROD_PO_NAME]					[NVARCHAR] (").Append(TypeLength.ProdSlipName).Append(")	NULL ,");		// 商品発注名
			sb.Append("	[PROD_SHORT_NAME]				[NVARCHAR] (").Append(TypeLength.ProdShortName).Append(")	NULL ,");		// 商品略名
// 管理番号K27011 To
			sb.Append("  [PROD_TYPE]                 [NVARCHAR] (1)     NULL ,");		// 商品区分
			sb.Append("  [DISP_CONTROL_TYPE]         [NVARCHAR] (1)     NULL ,");		// 表示制御区分
			sb.Append("  [STOCK_ADMIN_FLG]           [NVARCHAR] (1)     NULL ,");		// 在庫管理フラグ
			sb.Append("  [CTAX_CALC_TYPE]            [NVARCHAR] (1)     NULL ,");		// 消費税計算区分
			sb.Append("  [CTAX_RATE]                 [DECIMAL]  (6,3)   NULL ,");		// 消費税率
// 管理番号 K24382 From
//			sb.Append("  [PROD_SPEC_1_CODE]          [NVARCHAR] (3)     NULL ,");		// 商品規格1コード
//			sb.Append("  [PROD_SPEC_2_CODE]          [NVARCHAR] (3)     NULL ,");		// 商品規格2コード
			sb.Append("  [PROD_SPEC_1_CODE]          [NVARCHAR] (15)    NULL ,");		// 商品規格1コード
			sb.Append("  [PROD_SPEC_2_CODE]          [NVARCHAR] (15)    NULL ,");		// 商品規格2コード
// 管理番号 K24382 To
// 管理番号 K25647 From
//			sb.Append("  [PU_PLAN_PRICE]             [DECIMAL]  (13,2)  NULL ,");		// 仕入予定単価
//			sb.Append("  [STOCK_UNIT_STD_SELL_PRICE] [DECIMAL]  (13,2)  NULL ,");		// 在庫単位標準販売単価
			sb.Append("  [PU_PLAN_PRICE]             [DECIMAL]  (16,5)  NULL ,");		// 仕入予定単価
			sb.Append("  [STOCK_UNIT_STD_SELL_PRICE] [DECIMAL]  (16,5)  NULL ,");		// 在庫単位標準販売単価
// 管理番号 K25647 To
			sb.Append("  [UNIT_CODE]                 [NVARCHAR] (3)     NULL ,");		// 単位コード
// 管理番号 K25647 From
//// 管理番号 B06261 From
////			sb.Append("  [PU_QT]                     [DECIMAL]  (9,3)   NULL ,");		// 仕入数量
//			sb.Append("  [PU_QT]                     [DECIMAL] (12,3)   NULL ,");		// 仕入数量
//// 管理番号 B06261 To
//			sb.Append("  [TRANSIT_RCPT_QT]           [DECIMAL] (12,3)   NOT NULL DEFAULT 0  ,");// 未着品入荷数量
			sb.Append("  [PU_QT]                     [DECIMAL] (15,4)   NULL ,");		// 仕入数量
			sb.Append("  [TRANSIT_RCPT_QT]           [DECIMAL] (15,4)   NOT NULL DEFAULT 0  ,");// 未着品入荷数量
// 管理番号 K25647 To
			sb.Append("  [RCPT_INPUT_NO_NEED_FLG]    [NVARCHAR] (1)     NOT NULL DEFAULT '1' ,");// 入荷入力不要フラグ
// 管理番号 K25647 From
//			sb.Append("  [STOCK_UNIT_PU_QT]          [DECIMAL]  (12,3)  NULL ,");		// 在庫単位仕入数量
//// 管理番号 B13469 From
////			sb.Append("  [STOCK_UNIT_PO_PU_QT]       [DECIMAL]  (12,2)  NULL ,");		// 在庫単位発注仕入数量
//			sb.Append("  [STOCK_UNIT_PO_PU_QT]       [DECIMAL]  (12,3)  NULL ,");		// 在庫単位発注仕入数量
//// 管理番号 B13469 To
//			sb.Append("  [STOCK_UNIT_PO_ALLOC_PU_QT] [DECIMAL]  (13,2)  NULL ,");		// 在庫単位発注引当仕入数量
//			sb.Append("  [PU_PRICE]                  [DECIMAL] (13,2)   NULL ,");		// 仕入単価
			sb.Append("  [STOCK_UNIT_PU_QT]          [DECIMAL]  (15,4)  NULL ,");		// 在庫単位仕入数量
			sb.Append("  [STOCK_UNIT_PO_PU_QT]       [DECIMAL]  (15,4)  NULL ,");		// 在庫単位発注仕入数量
			sb.Append("  [STOCK_UNIT_PO_ALLOC_PU_QT] [DECIMAL]  (15,4)  NULL ,");		// 在庫単位発注引当仕入数量
			sb.Append("  [PU_PRICE]                  [DECIMAL] (16,5)   NULL ,");		// 仕入単価
// 管理番号 K25647 To
			sb.Append("  [DISC_FLG]                  [NVARCHAR] (1)     NULL ,");		// 値引フラグ
// 管理番号 B13878 From
			sb.Append("  [PRICE_UNDECIDED_FLG]       [NVARCHAR] (1)     NULL ,");		// 単価未決フラグ
// 管理番号 B13878 To
// 管理番号 B12929 From
			sb.Append("  [PRICE_UPDATE_FLG]          [NVARCHAR](1)		NULL ,"); // 仕入単価更新フラグ
// 管理番号 B12929 To
			sb.Append("  [LINE_REMARKS_CODE]         [NVARCHAR] (3)     NULL ,");		// 行摘要コード
			sb.Append("  [LINE_REMARKS]              [NVARCHAR] (100)   NULL ,");		// 行摘要
// 管理番号K27525 From
			sb.Append("  [BOOK_DEDUCTION_REASON_CODE] [NVARCHAR] (2)    NULL ,");		// 帳簿控除理由コード
// 管理番号K27525 To
			sb.Append("  [DTIL_AMT]                  [DECIMAL]  (13,2)  NULL ,");		// 明細金額
			sb.Append("  [ETAX_AMT]                  [DECIMAL]  (13,2)  NULL ,");		// 外税金額
// 管理番号 K00013 From
//			sb.Append("  [ITAX_AMT]                  [DECIMAL]  (13,2)  NULL  ");		// 内税金額
			sb.Append("  [ITAX_AMT]                  [DECIMAL]  (13,2)  NULL ,");		// 内税金額
			sb.Append("  [GRAND_TTL]                 [DECIMAL]  (13,2)  NULL ,");		// 総合計
			sb.Append("  [KEY_GRAND_TTL]             [DECIMAL]  (13,2)  NULL  ");		// 基軸換算総合計
// 管理番号 K00013 To
// 管理番号 K24789 From
			sb.Append(", [CTAX_TYPE_CODE]            [NVARCHAR] (1)     NULL  ");		// 消費税区分コード
			sb.Append(", [CTAX_RATE_CODE]            [NVARCHAR] (1)     NULL  ");		// 消費税率コード
// 管理番号 K24789 To
			sb.Append(" )");

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn, tr);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
			cm.ExecuteNonQuery();

			//仕入ロット明細
			sb = new StringBuilder();
			sb.Append(" CREATE TABLE [#PU_LOT_DTIL] ");
			sb.Append(" ( ");
			sb.Append("  [PU_LINE_ID]       [DECIMAL]  (10, 0)      ,");	// 仕入行ID
			sb.Append("  [PU_LOT_ID]        [DECIMAL]  (10, 0)      ,");	// 仕入ロット行ID
			sb.Append("  [RCPT_NO]          [NVARCHAR] (10)    NULL ,");	// 入荷番号
			sb.Append("  [RCPT_LINE_ID]     [DECIMAL]  (10, 0) NULL ,");	// 入荷行ID
			sb.Append("  [RCPT_LOT_ID]      [DECIMAL]  (10, 0) NULL ,");	// 入荷ロット行ID
			sb.Append("  [SA_NO]            [NVARCHAR] (10)    NULL ,");	// 売上番号
			sb.Append("  [SA_LINE_ID]       [DECIMAL]  (10, 0) NULL ,");	// 売上行ID
			sb.Append("  [SA_LOT_ID]        [DECIMAL]  (10, 0) NULL ,");	// 売上ロット行ID
// 管理番号K27011 From
//			sb.Append("  [PROD_CODE]        [NVARCHAR] (20)    NULL ,");	// 商品コード
			sb.Append("	[PROD_CODE]			[NVARCHAR] (").Append(TypeLength.ProdCode).Append(")		NULL ,");	// 商品コード
// 管理番号K27011 To
// 管理番号 K24382 From
//			sb.Append("  [PROD_SPEC_1_CODE] [NVARCHAR] (3)     NULL ,");	// 商品規格1コード
//			sb.Append("  [PROD_SPEC_2_CODE] [NVARCHAR] (3)     NULL ,");	// 商品規格2コード
			sb.Append("  [PROD_SPEC_1_CODE] [NVARCHAR] (15)    NULL ,");	// 商品規格1コード
			sb.Append("  [PROD_SPEC_2_CODE] [NVARCHAR] (15)    NULL ,");	// 商品規格2コード
// 管理番号 K24382 To
			sb.Append("  [FAB_DATE]         [DATETIME]         NULL ,");	// 製造日
			sb.Append("  [LOT_NO]           [NVARCHAR] (15)    NULL ,");	// ロット番号
// 管理番号 K25647 From
//// 管理番号 B06261 From
////			sb.Append("  [PU_QT]            [DECIMAL]  (9,3)   NULL ,");	// 仕入数量
//			sb.Append("  [PU_QT]            [DECIMAL] (12,3)   NULL ,");	// 仕入数量
//// 管理番号 B06261 To
//			sb.Append("  [TRANSIT_RCPT_QT]  [DECIMAL] (12,3)   NOT NULL DEFAULT 0 ");	// 未着品入荷数量
			sb.Append("  [PU_QT]            [DECIMAL] (15,4)   NULL ,");	// 仕入数量
			sb.Append("  [TRANSIT_RCPT_QT]  [DECIMAL] (15,4)   NOT NULL DEFAULT 0 ");	// 未着品入荷数量
// 管理番号 K25647 To
			sb.Append("  PRIMARY KEY ([PU_LINE_ID], [PU_LOT_ID]) ");		// 仕入行ID、仕入ロットID
			sb.Append(" )");
			cm.CommandText = sb.ToString();
			cm.ExecuteNonQuery();

			//海外取引条件
			if (keyColumn.OverseasFlg=="1")
			{
				sb = new StringBuilder();
				sb.Append(" CREATE TABLE [#OVERSEAS_PU_DT]");
				sb.Append(" ( ");
				sb.Append( " [OVERSEAS_PU_DT_ID] [DECIMAL] (10,0) NULL, ");	//海外仕入取引条件ID
				sb.Append( " [RATIO]             [DECIMAL] ( 3,0) NULL, ");	//比率
				sb.Append( " [STTL_MTHD_CODE]    [NVARCHAR](3)    NULL, ");	//決済方法コード
				sb.Append( " [USANCE_DAY_CNT]    [DECIMAL] ( 5,0) NULL, ");	//ユーザンス日数
				sb.Append( " [STTL_TIMING_CODE]  [NVARCHAR](3)    NULL, ");	//決済タイミングコード
				sb.Append( " [PYMT_PLAN_DATE]    [DATETIME]       NULL ");	//回収予定日
				sb.Append(" )");
				cm.CommandText = sb.ToString();
				cm.ExecuteNonQuery();
			}
		}
		//一時テーブル更新
		private static void InsertTempTable(CommonData commonData, SqlConnection cn, SqlTransaction tr, IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base rowData)
		{
			//明細コマンド
// 管理番号K27057 From
//			SqlCommand puDetail    = CreatePuDetailInsertCommand(commonData, cn, tr);
			SqlCommandWrapper puDetail    = CreatePuDetailInsertCommand(commonData, cn, tr, keyColumn.OverseasFlg);	// 管理番号K27230
// 管理番号K27057 To
			SqlCommandWrapper PuLotDetail = CreatePuLotDetailInsertCommand(commonData, cn, tr);	// 管理番号K27230

			decimal lineId = 0M;
			decimal lotId  = 0M;
			decimal seqId  = 0M;

			foreach (DataRow row in rowData.Dt.Rows)
			{
				lineId = (decimal)row["PU_LINE_ID"];
				string rowState = row["ROW_STATE"].ToString();
				seqId++;

				//仕入ロットIDコントロール
				if(keyColumn.ParamType == "Mod")
				{
					object maxLotID = rowData.LotDt.Compute("Max(LOT_ID)", "[ROW_ID]=" + lineId);
					lotId = maxLotID is decimal ? (decimal)maxLotID : 0M;
				}
				else
				{
					lotId = 0M;
				}

				//明細パラメータをセット
// 管理番号K27057 From
////				puDetail = SetPuDetailParameters(puDetail, row, keyColumn, seqId);
//// 管理番号 B14455 From
////				puDetail = SetPuDetailParameters(puDetail, row, keyColumn, rowData, seqId);
//				puDetail = SetPuDetailParameters(puDetail, row, keyColumn, rowData, lineId);
//// 管理番号 B14455 To
				puDetail = SetPuDetailParameters(puDetail, row, keyColumn, rowData, lineId, commonData);
// 管理番号K27057 To

				DataRow [] lotRows = rowData.LotDt.Select("ROW_ID= " + lineId);
// 管理番号 B14315 From
// 管理番号 B13500 From
				if (lotRows.Length > 0)
//				if (lotRows.Length > 0 && rowData.RcptInputNoNeedFlg != "0")
// 管理番号 B13500 To
// 管理番号 B14315 To
				{
					foreach(DataRow lotRow in lotRows)
					{
						//数量0以上のレコードだけ一時テーブルに格納します
						decimal editQt = (decimal)lotRow["EDIT_QT"];
// 管理番号 K24285 From
//						if (editQt > 0)
						//在庫管理しない商品で発注・入荷参照しない、仕入形態が通常または返品の場合は、マイナス数量も一時テーブルに格納
						if ((editQt > 0) ||
							(row["STOCK_ADMIN_FLG"].ToString() == "0" &&
							 rowData.PoNo.Length == 0 && rowData.RcptNo.Length == 0 &&
							 (rowData.PuModeType == "1" || rowData.PuModeType == "2") &&
							 editQt < 0))
// 管理番号 K24285 To
						{
							//ロット明細更新
							PuLotDetail = SetPuLotDetailParameters(rowData, PuLotDetail, row, lotRow, keyColumn, puDetail.Parameters["@PU_LINE_ID"].Value.ToString(), ref lotId, rowState);
							PuLotDetail.ExecuteNonQuery();
						}
					}
				}
				else
				{
// 管理番号 B15710 From
					PuLotDetail.Parameters["@WK_KEY"].Value           = ConvertDBData.ToNVarChar(keyColumn.WkKey);
// 管理番号 B15710 To
					PuLotDetail.Parameters["@PU_LINE_ID"].Value       = ConvertDBData.ToDecimal(puDetail.Parameters["@PU_LINE_ID"].Value.ToString());
					PuLotDetail.Parameters["@PU_LOT_ID"].Value        = 1M;
// 管理番号 B15804 From
//					PuLotDetail.Parameters["@RCPT_NO"].Value          = ConvertDBData.ToNVarChar(rowData.RcptNo);
					PuLotDetail.Parameters["@RCPT_NO"].Value          = ConvertDBData.ToNVarChar(row["RCPT_NO"].ToString());
// 管理番号 B15804 To
					PuLotDetail.Parameters["@RCPT_LINE_ID"].Value     = ConvertDBData.ToDecimal(rowData.RcptNo.Length > 0 ? row["RCPT_LINE_ID"].ToString() : string.Empty);
					PuLotDetail.Parameters["@RCPT_LOT_ID"].Value      = ConvertDBData.ToNVarChar(rowData.RcptNo.Length > 0 ? "1" : string.Empty);
					PuLotDetail.Parameters["@SA_NO"].Value            = ConvertDBData.ToNVarChar(row["SA_NO"].ToString());
					PuLotDetail.Parameters["@SA_LINE_ID"].Value       = ConvertDBData.ToDecimal(row["SA_LINE_ID"].ToString());
					PuLotDetail.Parameters["@SA_LOT_ID"].Value        = ConvertDBData.ToNVarChar(row["SA_NO"].ToString().Length > 0 ? "1" : string.Empty);
					PuLotDetail.Parameters["@PROD_CODE"].Value        = ConvertDBData.ToNVarChar(row["PROD_CODE"].ToString());
					PuLotDetail.Parameters["@PROD_SPEC_1_CODE"].Value = ConvertDBData.ToNVarChar(row["PROD_SPEC_1_CODE"].ToString());
					PuLotDetail.Parameters["@PROD_SPEC_2_CODE"].Value = ConvertDBData.ToNVarChar(row["PROD_SPEC_2_CODE"].ToString());
					PuLotDetail.Parameters["@FAB_DATE"].Value         = ConvertDBData.ToDateTime(DateTime.MaxValue.AddDays(-1D).ToString());
					PuLotDetail.Parameters["@LOT_NO"].Value           = ConvertDBData.ToNVarChar("9");
					PuLotDetail.Parameters["@PU_QT"].Value            = ConvertDBData.ToDecimal(row["PU_QT"].ToString());
// 管理番号 B13500 From
//					PuLotDetail.Parameters["@TRANSIT_RCPT_QT"].Value  = ConvertDBData.ToDecimal("0");
// 管理番号 B14315 From
//					PuLotDetail.Parameters["@TRANSIT_RCPT_QT"].Value  = ConvertDBData.ToDecimal(row["TRANSIT_RCPT_QT"].ToString());
// 管理番号 B21571 From
//					if(keyColumn.PuModeType != "2")
//					{
//						PuLotDetail.Parameters["@TRANSIT_RCPT_QT"].Value  = ConvertDBData.ToDecimal(row["TRANSIT_RCPT_QT"].ToString());
//					}
//					else
//					{
//						PuLotDetail.Parameters["@TRANSIT_RCPT_QT"].Value  = 0;
//					}
					if (keyColumn.ParamType == "Mod" && rowData.PuModeType != "2")
					{
						PuLotDetail.Parameters["@TRANSIT_RCPT_QT"].Value = ConvertDBData.ToDecimal(row["TRANSIT_RCPT_QT"].ToString());
					}
					else
					{
						PuLotDetail.Parameters["@TRANSIT_RCPT_QT"].Value = 0;
					}
// 管理番号 K25322 From
					PuLotDetail.Parameters["@STOCK_UNIT_PU_QT"].Value            = ConvertDBData.ToDecimal(row["STOCK_UNIT_PU_QT"].ToString());
					PuLotDetail.Parameters["@STOCK_UNIT_PO_ALLOC_PU_QT"].Value   = 0M;
// 管理番号 K25322 To
// 管理番号 B21571 To
// 管理番号 B14315 To
// 管理番号 B13500 To
					PuLotDetail.ExecuteNonQuery();
				}
				//明細更新
				puDetail.ExecuteNonQuery();
			}

			//海外取引条件
			if (keyColumn.OverseasFlg=="1")
			{
				SqlCommandWrapper OsInsertCommand = CreateOverseasPUDTInsertCommand(commonData, cn, tr);	// 管理番号K27230
				decimal dtId = 0M;

				foreach (IF_SC_MS_OverseasDT os in rowData.Overseas)
				{
					dtId++;
					if (os.Ratio.Length!=0 && os.Ratio!="0")
					{
						foreach(SqlParameter p in OsInsertCommand.Parameters)
						{
							p.Value = System.DBNull.Value;
						}
// 管理番号 B15710 From
						OsInsertCommand.Parameters["@WK_KEY"].Value	= ConvertDBData.ToNVarChar(keyColumn.WkKey);
// 管理番号 B15710 To
						OsInsertCommand.Parameters["@OVERSEAS_PU_DT_ID"].Value = ConvertDBData.ToDecimal(dtId.ToString());
						OsInsertCommand.Parameters["@RATIO"].Value            = ConvertDBData.ToDecimal(os.Ratio);
						OsInsertCommand.Parameters["@STTL_MTHD_CODE"].Value   = ConvertDBData.ToNVarChar(os.SttlMthdCode);
						OsInsertCommand.Parameters["@USANCE_DAY_CNT"].Value   = ConvertDBData.ToDecimal(os.UsanceDayCnt);
						OsInsertCommand.Parameters["@STTL_TIMING_CODE"].Value = ConvertDBData.ToNVarChar(os.SttlTimingCode);
						OsInsertCommand.Parameters["@PYMT_PLAN_DATE"].Value   = ConvertDBData.ToDateTime(os.ClctPlanDate);
						OsInsertCommand.ExecuteNonQuery();
					}
				}
			}
		}
		//コマンド-仕入明細
// 管理番号K27057 From
//		private static SqlCommand CreatePuDetailInsertCommand(CommonData commonData, SqlConnection cn, SqlTransaction tr)
		private static SqlCommandWrapper CreatePuDetailInsertCommand(CommonData commonData, SqlConnection cn, SqlTransaction tr, string overseasFlg)	// 管理番号K27230
// 管理番号K27057 To
		{
			StringBuilder sb       = new StringBuilder();

// 管理番号 B15710 From
//			sb.Append(" INSERT INTO [#PU_DTIL] "       );
//			sb.Append(" ( "                            );
			sb.Append(" INSERT INTO ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[WK_PU_DTIL]"));
			sb.Append(" ( "                            );
			sb.Append("  [WK_KEY]                    ,");
			sb.Append("  [WK_ID]                     ,");
// 管理番号 B15710 To
			sb.Append("  [PU_LINE_ID]                ,");
			sb.Append("  [PU_LINE_NO]                ,");
			sb.Append("  [PO_NO]                     ,");
			sb.Append("  [PO_LINE_ID]                ,");
			sb.Append("  [RCPT_NO]                   ,");
			sb.Append("  [RCPT_LINE_ID]              ,");
			sb.Append("  [SO_NO]                     ,");
			sb.Append("  [SO_LINE_ID]                ,");
			sb.Append("  [SA_NO]                     ,");
			sb.Append("  [SA_LINE_ID]                ,");
			sb.Append("  [WH_CODE]                   ,");
			sb.Append("  [PROD_CODE]                 ,");
			sb.Append("  [PROD_PO_NAME]              ,");
			sb.Append("  [PROD_SHORT_NAME]           ,");
			sb.Append("  [PROD_TYPE]                 ,");
			sb.Append("  [DISP_CONTROL_TYPE]         ,");
			sb.Append("  [STOCK_ADMIN_FLG]           ,");
			sb.Append("  [CTAX_CALC_TYPE]            ,");
			sb.Append("  [CTAX_RATE]                 ,");
			sb.Append("  [PROD_SPEC_1_CODE]          ,");
			sb.Append("  [PROD_SPEC_2_CODE]          ,");
			sb.Append("  [PU_PLAN_PRICE]             ,");
			sb.Append("  [STOCK_UNIT_STD_SELL_PRICE] ,");
			sb.Append("  [UNIT_CODE]                 ,");
			sb.Append("  [PU_QT]                     ,");

			sb.Append("  [TRANSIT_RCPT_QT]           ,");
			sb.Append("  [RCPT_INPUT_NO_NEED_FLG]    ,");

			sb.Append("  [STOCK_UNIT_PU_QT]          ,");
			sb.Append("  [STOCK_UNIT_PO_PU_QT]       ,");
			sb.Append("  [STOCK_UNIT_PO_ALLOC_PU_QT] ,");
			sb.Append("  [PU_PRICE]                  ,");
			sb.Append("  [DISC_FLG]                  ,");
// 管理番号 B13878 From
			sb.Append("  [PRICE_UNDECIDED_FLG]		 ,");
// 管理番号 B13878 To
// 管理番号 B12929 From
			sb.Append("  [PRICE_UPDATE_FLG]          ,");
// 管理番号 B12929 To
			sb.Append("  [LINE_REMARKS_CODE]         ,");
			sb.Append("  [LINE_REMARKS]              ,");
// 管理番号K27525 From
			sb.Append("  [BOOK_DEDUCTION_REASON_CODE],");
// 管理番号K27525 To
// 管理番号 K16671 From
			sb.Append("  [REF_CODE]                  ,");
// 管理番号 K16671 To
			sb.Append("  [DTIL_AMT]                  ,");
			sb.Append("  [ETAX_AMT]                  ,");
// 管理番号 K00013 From
//			sb.Append("  [ITAX_AMT]                   ");
			sb.Append("  [ITAX_AMT]                  ,");
			sb.Append("  [GRAND_TTL]                 ,");
			sb.Append("  [KEY_GRAND_TTL]              ");
// 管理番号 K00013 To
// 管理番号 K24789 From
			sb.Append(", [CTAX_TYPE_CODE]             ");
			sb.Append(", [CTAX_RATE_CODE]             ");
// 管理番号 K24789 To
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlColumns(commonData, BL_CM_MS_CustomItem.InputDetail, "SCMM05_PU", overseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb, BL_CM_MS_CustomItem.Insert);
// 管理番号K27057 To

			sb.Append(" ) VALUES ( ");

// 管理番号 B15710 From
			sb.Append("  @WK_KEY                    ," );
			sb.Append("  NEWID()                    ," );
// 管理番号 B15710 To
			sb.Append("  @PU_LINE_ID                ," );
			sb.Append("  @PU_LINE_NO                ," );
			sb.Append("  @PO_NO                     ," );
			sb.Append("  @PO_LINE_ID                ," );
			sb.Append("  @RCPT_NO                   ," );
			sb.Append("  @RCPT_LINE_ID              ," );
			sb.Append("  @SO_NO                     ," );
			sb.Append("  @SO_LINE_ID                ," );
			sb.Append("  @SA_NO                     ," );
			sb.Append("  @SA_LINE_ID                ," );
			sb.Append("  @WH_CODE                   ," );
			sb.Append("  @PROD_CODE                 ," );
			sb.Append("  @PROD_PO_NAME              ," );
			sb.Append("  @PROD_SHORT_NAME           ," );
			sb.Append("  @PROD_TYPE                 ," );
			sb.Append("  @DISP_CONTROL_TYPE         ," );
			sb.Append("  @STOCK_ADMIN_FLG           ," );
			sb.Append("  @CTAX_CALC_TYPE            ," );
			sb.Append("  @CTAX_RATE                 ," );
			sb.Append("  @PROD_SPEC_1_CODE          ," );
			sb.Append("  @PROD_SPEC_2_CODE          ," );
			sb.Append("  @PU_PLAN_PRICE             ," );
			sb.Append("  @STOCK_UNIT_STD_SELL_PRICE ," );
			sb.Append("  @UNIT_CODE                 ," );
			sb.Append("  @PU_QT                     ," );

			sb.Append("  @TRANSIT_RCPT_QT           ," );
			sb.Append("  @RCPT_INPUT_NO_NEED_FLG    ," );

			sb.Append("  @STOCK_UNIT_PU_QT          ," );
			sb.Append("  @STOCK_UNIT_PO_PU_QT       ," );
			sb.Append("  @STOCK_UNIT_PO_ALLOC_PU_QT ," );
			sb.Append("  @PU_PRICE                  ," );
			sb.Append("  @DISC_FLG                  ," );
// 管理番号 B13878 From
			sb.Append("  @PRICE_UNDECIDED_FLG		," );
// 管理番号 B13878 To
// 管理番号 B12929 From
			sb.Append("  @PRICE_UPDATE_FLG          ," );
// 管理番号 B12929 To
			sb.Append("  @LINE_REMARKS_CODE         ," );
			sb.Append("  @LINE_REMARKS              ," );
// 管理番号K27525 From
			sb.Append("  @BOOK_DEDUCTION_REASON_CODE," );
// 管理番号K27525 To
// 管理番号 K16671 From
			sb.Append("  @REF_CODE                  ," );
// 管理番号 K16671 To
			sb.Append("  @DTIL_AMT                  ," );
			sb.Append("  @ETAX_AMT                  ," );
// 管理番号 K00013 From
//			sb.Append("  @ITAX_AMT                   " );
			sb.Append("  @ITAX_AMT                  ," );
			sb.Append("  0					        ," );
			sb.Append("  0                           " );
// 管理番号 K00013 To
// 管理番号 K24789 From
			sb.Append(", @CTAX_TYPE_CODE              ");
			sb.Append(", @CTAX_RATE_CODE              ");
// 管理番号 K24789 To
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlParameter(commonData, BL_CM_MS_CustomItem.InputDetail, "SCMM05_PU", overseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, sb);
// 管理番号K27057 To
			sb.Append(" ) ");

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn ,tr);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To

// 管理番号 B15710 From
			cm.Parameters.Add("@WK_KEY"                    , SqlDbType.NVarChar ,50);
// 管理番号 B15710 To
			cm.Parameters.Add("@PU_LINE_ID"                , SqlDbType.Decimal  ,10 );
			cm.Parameters.Add("@PU_LINE_NO"                , SqlDbType.Decimal  ,10 );
			cm.Parameters.Add("@PO_NO"                     , SqlDbType.NVarChar ,10 );
			cm.Parameters.Add("@PO_LINE_ID"                , SqlDbType.Decimal  ,10 );
			cm.Parameters.Add("@RCPT_NO"                   , SqlDbType.NVarChar ,10 );
			cm.Parameters.Add("@RCPT_LINE_ID"              , SqlDbType.Decimal  ,10 );
			cm.Parameters.Add("@SO_NO"                     , SqlDbType.NVarChar ,10 );
			cm.Parameters.Add("@SO_LINE_ID"                , SqlDbType.Decimal  ,10 );
			cm.Parameters.Add("@SA_NO"                     , SqlDbType.NVarChar ,10 );
			cm.Parameters.Add("@SA_LINE_ID"                , SqlDbType.Decimal  ,10 );
			cm.Parameters.Add("@WH_CODE"                   , SqlDbType.NVarChar ,5  );
// 管理番号K27011 From
//			cm.Parameters.Add("@PROD_CODE"                 , SqlDbType.NVarChar ,20 );
//			cm.Parameters.Add("@PROD_PO_NAME"              , SqlDbType.NVarChar ,50 );
//			cm.Parameters.Add("@PROD_SHORT_NAME"           , SqlDbType.NVarChar ,50 );
			cm.Parameters.Add("@PROD_CODE"					, SqlDbType.NVarChar ,TypeLength.ProdCode );
			cm.Parameters.Add("@PROD_PO_NAME"				, SqlDbType.NVarChar ,TypeLength.ProdSlipName );
			cm.Parameters.Add("@PROD_SHORT_NAME"			, SqlDbType.NVarChar ,TypeLength.ProdShortName );
// 管理番号K27011 To
			cm.Parameters.Add("@PROD_TYPE"                 , SqlDbType.NVarChar ,1  );
			cm.Parameters.Add("@DISP_CONTROL_TYPE"         , SqlDbType.NVarChar ,1  );
			cm.Parameters.Add("@STOCK_ADMIN_FLG"           , SqlDbType.NVarChar ,1  );
			cm.Parameters.Add("@CTAX_CALC_TYPE"            , SqlDbType.NVarChar ,1  );
			cm.Parameters.Add("@CTAX_RATE"                 , SqlDbType.Decimal  ,6  );
// 管理番号 K24382 From
//			cm.Parameters.Add("@PROD_SPEC_1_CODE"          , SqlDbType.NVarChar, 3  );
//			cm.Parameters.Add("@PROD_SPEC_2_CODE"          , SqlDbType.NVarChar, 3  );
			cm.Parameters.Add("@PROD_SPEC_1_CODE"          , SqlDbType.NVarChar, 15 );
			cm.Parameters.Add("@PROD_SPEC_2_CODE"          , SqlDbType.NVarChar ,15 );
// 管理番号 K24382 To
// 管理番号 K25647 From
//			cm.Parameters.Add("@PU_PLAN_PRICE", SqlDbType.Decimal, 13);
//			cm.Parameters.Add("@STOCK_UNIT_STD_SELL_PRICE" , SqlDbType.Decimal  ,13 );
			cm.Parameters.Add("@PU_PLAN_PRICE", SqlDbType.Decimal);
			cm.Parameters["@PU_PLAN_PRICE"].Precision = 16;
			cm.Parameters["@PU_PLAN_PRICE"].Scale = 5;
			cm.Parameters.Add("@STOCK_UNIT_STD_SELL_PRICE" , SqlDbType.Decimal);
			cm.Parameters["@STOCK_UNIT_STD_SELL_PRICE"].Precision = 16;
			cm.Parameters["@STOCK_UNIT_STD_SELL_PRICE"].Scale = 5;
// 管理番号 K25647 To
			cm.Parameters.Add("@UNIT_CODE"                 , SqlDbType.NVarChar ,3  );
// 管理番号 K25647 From
//			cm.Parameters.Add("@PU_QT"                     , SqlDbType.Decimal  ,9  );
//
//			cm.Parameters.Add("@TRANSIT_RCPT_QT"           , SqlDbType.Decimal  ,12 );
//			cm.Parameters.Add("@RCPT_INPUT_NO_NEED_FLG"    , SqlDbType.NVarChar ,1  );
//
//			cm.Parameters.Add("@STOCK_UNIT_PU_QT"          , SqlDbType.Decimal  ,12 );
//			cm.Parameters.Add("@STOCK_UNIT_PO_PU_QT"       , SqlDbType.Decimal  ,12 );
//			cm.Parameters.Add("@STOCK_UNIT_PO_ALLOC_PU_QT" , SqlDbType.Decimal  ,13 );
//			cm.Parameters.Add("@PU_PRICE"                  , SqlDbType.Decimal  ,13 );
			cm.Parameters.Add("@PU_QT"                     , SqlDbType.Decimal);
			cm.Parameters["@PU_QT"].Precision = 15;
			cm.Parameters["@PU_QT"].Scale = 4;

			cm.Parameters.Add("@TRANSIT_RCPT_QT"           , SqlDbType.Decimal);
			cm.Parameters["@TRANSIT_RCPT_QT"].Precision = 15;
			cm.Parameters["@TRANSIT_RCPT_QT"].Scale = 4;
			cm.Parameters.Add("@RCPT_INPUT_NO_NEED_FLG"    , SqlDbType.NVarChar ,1  );

			cm.Parameters.Add("@STOCK_UNIT_PU_QT"          , SqlDbType.Decimal);
			cm.Parameters["@STOCK_UNIT_PU_QT"].Precision = 15;
			cm.Parameters["@STOCK_UNIT_PU_QT"].Scale = 4;
			cm.Parameters.Add("@STOCK_UNIT_PO_PU_QT"       , SqlDbType.Decimal);
			cm.Parameters["@STOCK_UNIT_PO_PU_QT"].Precision = 15;
			cm.Parameters["@STOCK_UNIT_PO_PU_QT"].Scale = 4;
			cm.Parameters.Add("@STOCK_UNIT_PO_ALLOC_PU_QT" , SqlDbType.Decimal);
			cm.Parameters["@STOCK_UNIT_PO_ALLOC_PU_QT"].Precision = 15;
			cm.Parameters["@STOCK_UNIT_PO_ALLOC_PU_QT"].Scale = 4;
			cm.Parameters.Add("@PU_PRICE"                  , SqlDbType.Decimal);
			cm.Parameters["@PU_PRICE"].Precision = 16;
			cm.Parameters["@PU_PRICE"].Scale = 5;
// 管理番号 K25647 To
			cm.Parameters.Add("@DISC_FLG"                  , SqlDbType.NVarChar ,1  );
// 管理番号 B13878 From
			cm.Parameters.Add("@PRICE_UNDECIDED_FLG"       , SqlDbType.NVarChar ,1  );
// 管理番号 B13878 To
// 管理番号 B12929 From
			cm.Parameters.Add("@PRICE_UPDATE_FLG"          , SqlDbType.NVarChar ,1  );
// 管理番号 B12929 To
			cm.Parameters.Add("@LINE_REMARKS_CODE"         , SqlDbType.NVarChar ,3  );
			cm.Parameters.Add("@LINE_REMARKS"              , SqlDbType.NVarChar ,100);
// 管理番号K27525 From
			cm.Parameters.Add("@BOOK_DEDUCTION_REASON_CODE", SqlDbType.NVarChar ,2 );
// 管理番号K27525 To
// 管理番号 K16671 From
			cm.Parameters.Add("@REF_CODE"                  , SqlDbType.NVarChar ,20 );
// 管理番号 K16671 To
			cm.Parameters.Add("@DTIL_AMT"                  , SqlDbType.Decimal  ,13 );
			cm.Parameters.Add("@ETAX_AMT"                  , SqlDbType.Decimal  ,13 );
			cm.Parameters.Add("@ITAX_AMT"                  , SqlDbType.Decimal  ,13 );
// 管理番号 K24789 From
			cm.Parameters.Add("@CTAX_TYPE_CODE"            , SqlDbType.NVarChar ,1  );
			cm.Parameters.Add("@CTAX_RATE_CODE"            , SqlDbType.NVarChar ,1  );
// 管理番号 K24789 To
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlParameterCollection(commonData, BL_CM_MS_CustomItem.InputDetail, "SCMM05_PU", overseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, cm.Parameters);
// 管理番号K27057 To

			return cm;

		}
		//コマンド-仕入ロット明細
		private static SqlCommandWrapper CreatePuLotDetailInsertCommand(CommonData commonData, SqlConnection cn, SqlTransaction tr)	// 管理番号K27230
		{
			StringBuilder sb       = new StringBuilder();

// 管理番号 B15710 From
//			sb.Append(" INSERT INTO [#PU_LOT_DTIL] " );
//			sb.Append(" ( "              );
			sb.Append(" INSERT INTO ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[WK_PU_LOT_DTIL]"));
			sb.Append(" ( "              );
			sb.Append("  [WK_KEY]       ,");
			sb.Append("  [WK_ID]        ,");
// 管理番号 B15710 To
			sb.Append("  [PU_LINE_ID]   ,");
			sb.Append("  [PU_LOT_ID]    ,");
			sb.Append("  [RCPT_NO]      ,");
			sb.Append("  [RCPT_LINE_ID] ,");
			sb.Append("  [RCPT_LOT_ID]  ,");
			sb.Append("  [SA_NO]        ,");
			sb.Append("  [SA_LINE_ID]   ,");
			sb.Append("  [SA_LOT_ID]    ,");
			sb.Append("  [PROD_CODE]    ,");
			sb.Append("  [PROD_SPEC_1_CODE] ,");
			sb.Append("  [PROD_SPEC_2_CODE] ,");
			sb.Append("  [FAB_DATE]    ,");
			sb.Append("  [LOT_NO]      ,");
			sb.Append("  [PU_QT]       ,");
			sb.Append("  [TRANSIT_RCPT_QT] ");
// 管理番号 K25322 From
			sb.Append(", [STOCK_UNIT_PU_QT] ");
			sb.Append(", [STOCK_UNIT_PO_ALLOC_PU_QT] ");
// 管理番号 K25322 To
			sb.Append(" ) VALUES ( ");

// 管理番号 B15710 From
			sb.Append("  @WK_KEY   ," );
			sb.Append("  NEWID()   ," );
// 管理番号 B15710 To
			sb.Append("  @PU_LINE_ID   ," );
			sb.Append("  @PU_LOT_ID    ," );
			sb.Append("  @RCPT_NO      ," );
			sb.Append("  @RCPT_LINE_ID ," );
			sb.Append("  @RCPT_LOT_ID  ," );
			sb.Append("  @SA_NO        ," );
			sb.Append("  @SA_LINE_ID   ," );
			sb.Append("  @SA_LOT_ID    ," );
			sb.Append("  @PROD_CODE    ," );
			sb.Append("  @PROD_SPEC_1_CODE    ," );
			sb.Append("  @PROD_SPEC_2_CODE    ," );
			sb.Append("  @FAB_DATE    ," );

			sb.Append("  @LOT_NO       ," );
			sb.Append("  @PU_QT        ," );
			sb.Append("  @TRANSIT_RCPT_QT " );
// 管理番号 K25322 From
			sb.Append(", @STOCK_UNIT_PU_QT ");
			sb.Append(", @STOCK_UNIT_PO_ALLOC_PU_QT ");
// 管理番号 K25322 To

			sb.Append(" ) ");

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn, tr);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To

// 管理番号 B15710 From
			cm.Parameters.Add("@WK_KEY"           , SqlDbType.NVarChar ,50);
// 管理番号 B15710 To
			cm.Parameters.Add("@PU_LINE_ID"       , SqlDbType.Decimal  ,10);
			cm.Parameters.Add("@PU_LOT_ID"        , SqlDbType.Decimal  ,10);
			cm.Parameters.Add("@RCPT_NO"          , SqlDbType.NVarChar ,10);
			cm.Parameters.Add("@RCPT_LINE_ID"     , SqlDbType.Decimal  ,10);
			cm.Parameters.Add("@RCPT_LOT_ID"      , SqlDbType.Decimal  ,10);
			cm.Parameters.Add("@SA_NO"            , SqlDbType.NVarChar ,10);
			cm.Parameters.Add("@SA_LINE_ID"       , SqlDbType.Decimal  ,10);
			cm.Parameters.Add("@SA_LOT_ID"        , SqlDbType.Decimal  ,10);
// 管理番号K27011 From
//			cm.Parameters.Add("@PROD_CODE"        , SqlDbType.NVarChar ,20);
			cm.Parameters.Add("@PROD_CODE"			, SqlDbType.NVarChar ,TypeLength.ProdCode);
// 管理番号K27011 To
// 管理番号 K24382 From
//			cm.Parameters.Add("@PROD_SPEC_1_CODE" , SqlDbType.NVarChar, 3 );
//			cm.Parameters.Add("@PROD_SPEC_2_CODE" , SqlDbType.NVarChar, 3 );
			cm.Parameters.Add("@PROD_SPEC_1_CODE" , SqlDbType.NVarChar, 15);
			cm.Parameters.Add("@PROD_SPEC_2_CODE" , SqlDbType.NVarChar ,15);
// 管理番号 K24382 To
			cm.Parameters.Add("@FAB_DATE", SqlDbType.DateTime);
			cm.Parameters.Add("@LOT_NO"           , SqlDbType.NVarChar ,15);
// 管理番号 K25647 From
//			cm.Parameters.Add("@PU_QT"            , SqlDbType.Decimal  ,9 );
//			cm.Parameters.Add("@TRANSIT_RCPT_QT"  , SqlDbType.Decimal  ,12 );
//// 管理番号 K25322 From
//			cm.Parameters.Add("@STOCK_UNIT_PU_QT"  , SqlDbType.Decimal  ,12 );
//			cm.Parameters.Add("@STOCK_UNIT_PO_ALLOC_PU_QT"  , SqlDbType.Decimal  ,12 );
//// 管理番号 K25322 To
			cm.Parameters.Add("@PU_QT"            , SqlDbType.Decimal);
			cm.Parameters["@PU_QT"].Precision = 15;
			cm.Parameters["@PU_QT"].Scale = 4;
			cm.Parameters.Add("@TRANSIT_RCPT_QT"  , SqlDbType.Decimal);
			cm.Parameters["@TRANSIT_RCPT_QT"].Precision = 15;
			cm.Parameters["@TRANSIT_RCPT_QT"].Scale = 4;
			cm.Parameters.Add("@STOCK_UNIT_PU_QT"  , SqlDbType.Decimal);
			cm.Parameters["@STOCK_UNIT_PU_QT"].Precision = 15;
			cm.Parameters["@STOCK_UNIT_PU_QT"].Scale = 4;
			cm.Parameters.Add("@STOCK_UNIT_PO_ALLOC_PU_QT"  , SqlDbType.Decimal);
			cm.Parameters["@STOCK_UNIT_PO_ALLOC_PU_QT"].Precision = 15;
			cm.Parameters["@STOCK_UNIT_PO_ALLOC_PU_QT"].Scale = 4;
// 管理番号 K25647 To

			return cm;
		}

		private static SqlCommandWrapper CreateOverseasPUDTInsertCommand(CommonData commonData, SqlConnection cn, SqlTransaction tr)	// 管理番号K27230
		{
			StringBuilder sb = new StringBuilder();

// 管理番号 B15710 From
//			sb.Append("INSERT INTO [#OVERSEAS_PU_DT] ");
//			sb.Append("( ");
			sb.Append("INSERT INTO ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[WK_OVERSEAS_PU_DT]"));
			sb.Append( "( ");
			sb.Append( "[WK_KEY]            ,");
			sb.Append( "[WK_ID]             ,");
// 管理番号 B15710 To
			sb.Append( "[OVERSEAS_PU_DT_ID], ");
			sb.Append( "[RATIO], "            );
			sb.Append( "[STTL_MTHD_CODE], "   );
			sb.Append( "[USANCE_DAY_CNT], "   );
			sb.Append( "[STTL_TIMING_CODE], " );
			sb.Append( "[PYMT_PLAN_DATE] "    );
			sb.Append(" ) VALUES ( ");
// 管理番号 B15710 From
			sb.Append( "@WK_KEY            ,");
			sb.Append( "NEWID()            ,");
// 管理番号 B15710 To
			sb.Append( "@OVERSEAS_PU_DT_ID, ");
			sb.Append( "@RATIO, "            );
			sb.Append( "@STTL_MTHD_CODE, "   );
			sb.Append( "@USANCE_DAY_CNT, "   );
			sb.Append( "@STTL_TIMING_CODE, " );
			sb.Append( "@PYMT_PLAN_DATE "    );
			sb.Append(")");

			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn, tr);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
// 管理番号 B15710 From
			cm.Parameters.Add("@WK_KEY"           , SqlDbType.NVarChar ,50);
// 管理番号 B15710 To
			cm.Parameters.Add("@OVERSEAS_PU_DT_ID", SqlDbType.Decimal , 10);
			cm.Parameters.Add("@RATIO"            , SqlDbType.Decimal , 3 );
			cm.Parameters.Add("@STTL_MTHD_CODE"   , SqlDbType.NVarChar, 3 );
			cm.Parameters.Add("@USANCE_DAY_CNT"   , SqlDbType.Decimal , 5 );
			cm.Parameters.Add("@STTL_TIMING_CODE" , SqlDbType.NVarChar, 3 );
			cm.Parameters.Add("@PYMT_PLAN_DATE"   , SqlDbType.DateTime    );
			return cm;
		}

		// 管理番号 B13500 From
		//パラメタ-仕入明細
// 管理番号K27057 From
////		private static SqlCommand SetPuDetailParameters(SqlCommand puDetailCommand, DataRow puDetailRow , IF_SC_MM_05_KeyColumn keyColumn, decimal lineId)
//		private static SqlCommand SetPuDetailParameters(SqlCommand puDetailCommand, DataRow puDetailRow , IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base rowData, decimal lineId)
		private static SqlCommandWrapper SetPuDetailParameters(SqlCommandWrapper puDetailCommand, DataRow puDetailRow , IF_SC_MM_05_KeyColumn keyColumn, IF_SC_MM_05_Base rowData, decimal lineId, CommonData commonData)	// 管理番号K27230
// 管理番号K27057 To
		{
			//パラメータ初期化
			foreach(SqlParameter p in puDetailCommand.Parameters)
				p.Value = System.DBNull.Value;

// 管理番号 B15710 From
			puDetailCommand.Parameters["@WK_KEY"].Value                  = ConvertDBData.ToNVarChar(keyColumn.WkKey);
// 管理番号 B15710 To

			switch (keyColumn.RefType)
			{
				case "RCPT":	//入荷参照
					puDetailCommand.Parameters["@PU_LINE_ID"].Value	  = ConvertDBData.ToDecimal(lineId.ToString());
					puDetailCommand.Parameters["@PU_LINE_NO"].Value   = ConvertDBData.ToDecimal(puDetailRow["PU_LINE_NO"].ToString());
					puDetailCommand.Parameters["@PO_NO"].Value        = ConvertDBData.ToNVarChar(puDetailRow["PO_NO"].ToString());
					puDetailCommand.Parameters["@PO_LINE_ID"].Value   = ConvertDBData.ToDecimal(puDetailRow["PO_LINE_ID"].ToString());
					puDetailCommand.Parameters["@RCPT_NO"].Value      = ConvertDBData.ToNVarChar(puDetailRow["RCPT_NO"].ToString());
					puDetailCommand.Parameters["@RCPT_LINE_ID"].Value = ConvertDBData.ToDecimal(puDetailRow["RCPT_LINE_ID"].ToString());
					break;
				case "PO":		//発注参照
					puDetailCommand.Parameters["@PU_LINE_ID"].Value	  = ConvertDBData.ToDecimal(lineId.ToString());
					puDetailCommand.Parameters["@PU_LINE_NO"].Value   = ConvertDBData.ToDecimal(puDetailRow["PU_LINE_NO"].ToString());
					puDetailCommand.Parameters["@PO_NO"].Value        = ConvertDBData.ToNVarChar(puDetailRow["PO_NO"].ToString());
					puDetailCommand.Parameters["@PO_LINE_ID"].Value	  = ConvertDBData.ToDecimal(puDetailRow["PO_LINE_ID"].ToString());
					puDetailCommand.Parameters["@RCPT_NO"].Value	  = ConvertDBData.ToNVarChar(string.Empty);
					puDetailCommand.Parameters["@RCPT_LINE_ID"].Value = ConvertDBData.ToNVarChar(string.Empty);
					break;
// 管理番号 B19369 From
				case "REF_RETURN_RC":	//海外仕入返品入荷参照
// 管理番号 B19369 To
				case "REF_PU":	//仕入返品
					puDetailCommand.Parameters["@PU_LINE_ID"].Value	  = ConvertDBData.ToDecimal(puDetailRow["PU_LINE_ID"].ToString());
					puDetailCommand.Parameters["@PU_LINE_NO"].Value   = ConvertDBData.ToDecimal(puDetailRow["PU_LINE_NO"].ToString());
					puDetailCommand.Parameters["@PO_NO"].Value        = ConvertDBData.ToNVarChar(puDetailRow["PO_NO"].ToString());
					puDetailCommand.Parameters["@PO_LINE_ID"].Value   = ConvertDBData.ToDecimal(puDetailRow["PO_LINE_ID"].ToString());
					puDetailCommand.Parameters["@RCPT_NO"].Value      = ConvertDBData.ToNVarChar(puDetailRow["RCPT_NO"].ToString());
					puDetailCommand.Parameters["@RCPT_LINE_ID"].Value = ConvertDBData.ToDecimal(puDetailRow["RCPT_LINE_ID"].ToString());
					break;
				default://"NONE"(直接仕入？？／コピー／修正)
					if (keyColumn.ParamType=="Mod")
					{
						//仕入修正
						puDetailCommand.Parameters["@PU_LINE_ID"].Value	  = ConvertDBData.ToDecimal(puDetailRow["PU_LINE_ID"].ToString());
						puDetailCommand.Parameters["@PU_LINE_NO"].Value   = ConvertDBData.ToDecimal(puDetailRow["PU_LINE_NO"].ToString());
						puDetailCommand.Parameters["@PO_NO"].Value        = ConvertDBData.ToNVarChar(puDetailRow["PO_NO"].ToString());
						puDetailCommand.Parameters["@PO_LINE_ID"].Value   = ConvertDBData.ToDecimal(puDetailRow["PO_LINE_ID"].ToString());
						puDetailCommand.Parameters["@RCPT_NO"].Value      = ConvertDBData.ToNVarChar(puDetailRow["RCPT_NO"].ToString());
						puDetailCommand.Parameters["@RCPT_LINE_ID"].Value = ConvertDBData.ToDecimal(puDetailRow["RCPT_LINE_ID"].ToString());
					}
					else
					{
						//直接仕入(新規)、仕入コピー
						puDetailCommand.Parameters["@PU_LINE_ID"].Value	  = ConvertDBData.ToDecimal(lineId.ToString());
						puDetailCommand.Parameters["@PU_LINE_NO"].Value   = ConvertDBData.ToDecimal(puDetailRow["PU_LINE_NO"].ToString());
						puDetailCommand.Parameters["@PO_NO"].Value        = ConvertDBData.ToNVarChar(string.Empty);
						puDetailCommand.Parameters["@PO_LINE_ID"].Value   = ConvertDBData.ToNVarChar(string.Empty);
						puDetailCommand.Parameters["@RCPT_NO"].Value      = ConvertDBData.ToNVarChar(string.Empty);
						puDetailCommand.Parameters["@RCPT_LINE_ID"].Value = ConvertDBData.ToNVarChar(string.Empty);
					}
					break;
			}
			puDetailCommand.Parameters["@SO_NO"].Value                     = ConvertDBData.ToNVarChar(puDetailRow["SO_NO"].ToString());
			puDetailCommand.Parameters["@SO_LINE_ID"].Value                = ConvertDBData.ToDecimal(puDetailRow["SO_LINE_ID"].ToString());
			puDetailCommand.Parameters["@SA_NO"].Value                     = ConvertDBData.ToNVarChar(puDetailRow["SA_NO"].ToString());
			puDetailCommand.Parameters["@SA_LINE_ID"].Value                = ConvertDBData.ToDecimal(puDetailRow["SA_LINE_ID"].ToString());
			puDetailCommand.Parameters["@WH_CODE"].Value                   = ConvertDBData.ToNVarChar(puDetailRow["WH_CODE"].ToString());
			puDetailCommand.Parameters["@PROD_CODE"].Value                 = ConvertDBData.ToNVarChar(puDetailRow["PROD_CODE"].ToString());
// 管理番号 B13500 From
//			if(puDetailRow["PROD_PO_NAME"].ToString()==puDetailRow["PROD_SHORT_NAME"].ToString())
//			{
//				//商品名変更無し
//				puDetailCommand.Parameters["@PROD_PO_NAME"].Value          = ConvertDBData.ToNVarChar(puDetailRow["PROD_NAME"].ToString());
//				puDetailCommand.Parameters["@PROD_SHORT_NAME"].Value       = ConvertDBData.ToNVarChar(puDetailRow["PROD_SHORT_NAME"].ToString());
//			}
//			else
//			{
				//商品名変更無し
				puDetailCommand.Parameters["@PROD_PO_NAME"].Value          = ConvertDBData.ToNVarChar(puDetailRow["PROD_PO_NAME"].ToString());
// 管理番号 B19475 From
//			puDetailCommand.Parameters["@PROD_SHORT_NAME"].Value       = ConvertDBData.ToNVarChar(puDetailRow["PROD_PO_NAME"].ToString());
			if(keyColumn.OverseasFlg == "1")
			{
				puDetailCommand.Parameters["@PROD_SHORT_NAME"].Value       = ConvertDBData.ToNVarChar(puDetailRow["PROD_PO_NAME"].ToString());
			}
			else
			{
				puDetailCommand.Parameters["@PROD_SHORT_NAME"].Value       = ConvertDBData.ToNVarChar(puDetailRow["PROD_SHORT_NAME"].ToString());
			}
// 管理番号 B19475 To
//			}
// 管理番号 B13500 To
			puDetailCommand.Parameters["@PROD_TYPE"].Value                 = ConvertDBData.ToNVarChar(puDetailRow["PROD_TYPE"].ToString());
			puDetailCommand.Parameters["@DISP_CONTROL_TYPE"].Value         = ConvertDBData.ToNVarChar(puDetailRow["DISP_CONTROL_TYPE"].ToString());
			puDetailCommand.Parameters["@STOCK_ADMIN_FLG"].Value           = ConvertDBData.ToNVarChar(puDetailRow["STOCK_ADMIN_FLG"].ToString());
// 管理番号 B24787 From
//			puDetailCommand.Parameters["@CTAX_CALC_TYPE"].Value            = keyColumn.OverseasFlg!="1" ? ConvertDBData.ToNVarChar(puDetailRow["CTAX_CALC_TYPE"].ToString()) : "N";
			puDetailCommand.Parameters["@CTAX_CALC_TYPE"].Value            = ConvertDBData.ToNVarChar(puDetailRow["CTAX_CALC_TYPE"].ToString());
// 管理番号 B24787 To
			puDetailCommand.Parameters["@CTAX_RATE"].Value                 = ConvertDBData.ToDecimal(puDetailRow["CTAX_RATE"].ToString());
			puDetailCommand.Parameters["@PROD_SPEC_1_CODE"].Value          = ConvertDBData.ToNVarChar(puDetailRow["PROD_SPEC_1_CODE"].ToString());
			puDetailCommand.Parameters["@PROD_SPEC_2_CODE"].Value          = ConvertDBData.ToNVarChar(puDetailRow["PROD_SPEC_2_CODE"].ToString());
			puDetailCommand.Parameters["@PU_PLAN_PRICE"].Value             = ConvertDBData.ToDecimal(puDetailRow["PU_PLAN_PRICE"].ToString());
			puDetailCommand.Parameters["@STOCK_UNIT_STD_SELL_PRICE"].Value = ConvertDBData.ToDecimal(puDetailRow["STOCK_UNIT_STD_SELL_PRICE"].ToString());
			puDetailCommand.Parameters["@UNIT_CODE"].Value                 = ConvertDBData.ToNVarChar(puDetailRow["UNIT_CODE"].ToString());
			puDetailCommand.Parameters["@PU_QT"].Value                     = ConvertDBData.ToDecimal(puDetailRow["PU_QT"].ToString());
// 管理番号B25771 From
//// 管理番号 B14315 From
//// 管理番号 B13500 From
////			if (puDetailRow["TRANSIT_RCPT_QT"].ToString().Length == 0 || puDetailRow["WH_CODE"].ToString() == "99999"
////				|| puDetailRow["STOCK_ADMIN_FLG"].ToString() == "0" || rowData.RcptInputNoNeedFlg == "1")
//			if (puDetailRow["TRANSIT_RCPT_QT"].ToString().Length == 0 || puDetailRow["WH_CODE"].ToString() == "99999"
//				|| puDetailRow["STOCK_ADMIN_FLG"].ToString() == "0" || (rowData.RcptInputNoNeedFlg == "0" && rowData.PuModeType == "2"))
//// 管理番号 B13500 To
//// 管理番号 B14315 To
//			{
//// 管理番号 B14315 From
////				puDetailCommand.Parameters["@TRANSIT_RCPT_QT"].Value       = ConvertDBData.ToDecimal(puDetailRow["PU_QT"].ToString());
//				if(keyColumn.OverseasFlg == "0")
//				{
//					puDetailCommand.Parameters["@TRANSIT_RCPT_QT"].Value   = ConvertDBData.ToDecimal(puDetailRow["PU_QT"].ToString());
//				}
//				else
//				{
//					puDetailCommand.Parameters["@TRANSIT_RCPT_QT"].Value   = 0;
//				}
//// 管理番号 B14315 To
//			}
//			else
//			{
//				puDetailCommand.Parameters["@TRANSIT_RCPT_QT"].Value       = ConvertDBData.ToDecimal(puDetailRow["TRANSIT_RCPT_QT"].ToString());
//			}
			if (keyColumn.ParamType == "Mod" && rowData.PuModeType != "2")
			{
				puDetailCommand.Parameters["@TRANSIT_RCPT_QT"].Value = ConvertDBData.ToDecimal(puDetailRow["TRANSIT_RCPT_QT"].ToString());
			}
			else
			{
				puDetailCommand.Parameters["@TRANSIT_RCPT_QT"].Value = 0;
			}
// 管理番号B25771 To
			puDetailCommand.Parameters["@RCPT_INPUT_NO_NEED_FLG"].Value    = rowData.RcptInputNoNeedFlg;
			puDetailCommand.Parameters["@STOCK_UNIT_PU_QT"].Value          = ConvertDBData.ToDecimal(puDetailRow["STOCK_UNIT_PU_QT"].ToString());
			puDetailCommand.Parameters["@STOCK_UNIT_PO_PU_QT"].Value       = puDetailRow["PO_NO"].ToString().Length > 0 ? ConvertDBData.ToDecimal(puDetailRow["STOCK_UNIT_PU_QT"].ToString()) : 0;
			puDetailCommand.Parameters["@STOCK_UNIT_PO_ALLOC_PU_QT"].Value = ConvertDBData.ToDecimal(puDetailRow["STOCK_UNIT_PO_ALLOC_PU_QT"].ToString());
			puDetailCommand.Parameters["@PU_PRICE"].Value                  = ConvertDBData.ToDecimal(puDetailRow["PU_PRICE"].ToString());
			puDetailCommand.Parameters["@DISC_FLG"].Value                  = ConvertDBData.ToNVarChar(puDetailRow["DISC_FLG"].ToString());
// 管理番号 B13878 From
			puDetailCommand.Parameters["@PRICE_UNDECIDED_FLG"].Value	   = ConvertDBData.ToNVarChar(puDetailRow["PRICE_UNDECIDED_FLG"].ToString());
// 管理番号 B13878 To
// 管理番号 B12929 From
			puDetailCommand.Parameters["@PRICE_UPDATE_FLG"].Value	       = 
				ConvertDBData.ToNVarChar(puDetailRow["PRICE_UPDATE_FLG"].ToString());
// 管理番号 B12929 To
			puDetailCommand.Parameters["@LINE_REMARKS_CODE"].Value         = ConvertDBData.ToNVarChar(puDetailRow["LINE_REMARKS_CODE"].ToString());
			puDetailCommand.Parameters["@LINE_REMARKS"].Value              = ConvertDBData.ToNVarChar(puDetailRow["LINE_REMARKS"].ToString());
// 管理番号K27525 From
			puDetailCommand.Parameters["@BOOK_DEDUCTION_REASON_CODE"].Value = ConvertDBData.ToNVarChar(puDetailRow["BOOK_DEDUCTION_REASON_CODE"].ToString());
// 管理番号K27525 To
// 管理番号 K16671 From
			puDetailCommand.Parameters["@REF_CODE"].Value				   = ConvertDBData.ToNVarChar(puDetailRow["REF_CODE"].ToString());
// 管理番号 K16671 To
			puDetailCommand.Parameters["@DTIL_AMT"].Value                  = ConvertDBData.ToDecimal(puDetailRow["DTIL_AMT"].ToString());
			puDetailCommand.Parameters["@ETAX_AMT"].Value                  = ConvertDBData.ToDecimal(puDetailRow["ETAX_AMT"].ToString());
			puDetailCommand.Parameters["@ITAX_AMT"].Value                  = ConvertDBData.ToDecimal(puDetailRow["ITAX_AMT"].ToString());
// 管理番号 K24789 From
			puDetailCommand.Parameters["@CTAX_TYPE_CODE"].Value            = ConvertDBData.ToNVarChar(puDetailRow["CTAX_TYPE_CODE"].ToString());
			puDetailCommand.Parameters["@CTAX_RATE_CODE"].Value            = ConvertDBData.ToNVarChar(puDetailRow["CTAX_RATE_CODE"].ToString());
// 管理番号 K24789 To
// 管理番号K27057 From
			BL_CM_MS_CustomItem.SetSqlParameterCollection(commonData, BL_CM_MS_CustomItem.InputDetail, "SCMM05_PU", keyColumn.OverseasFlg == "0" ? BL_CM_MS_CustomItem.Domestic : BL_CM_MS_CustomItem.Overseas, puDetailCommand.Parameters, puDetailRow);
// 管理番号K27057 To
			return puDetailCommand;
		}
		// 管理番号 B13500 To
		//パラメタ-仕入ロット明細
		private static SqlCommandWrapper SetPuLotDetailParameters(IF_SC_MM_05_Base rowData, SqlCommandWrapper puLotDetailCommand, DataRow puDetailRow , DataRow puLotDetailRow , IF_SC_MM_05_KeyColumn keyColumn, string rowId, ref decimal lotId, string rowState)	// 管理番号K27230
		{
			//パラメータ初期化
			foreach(SqlParameter p in puLotDetailCommand.Parameters)
				p.Value = System.DBNull.Value;

// 管理番号 B15710 From
			puLotDetailCommand.Parameters["@WK_KEY"].Value           = ConvertDBData.ToNVarChar(keyColumn.WkKey);
// 管理番号 B15710 To

			//ロットID(修正時もしくは仕入参照返品時のみ、振り直しなし)
// 管理番号 B19369 From
//			if ((keyColumn.ParamType == "Mod" && (decimal)puLotDetailRow["LOT_ID"] > 0) || rowData.RefPuNo.Length > 0)
			if ((keyColumn.ParamType == "Mod" && (decimal)puLotDetailRow["LOT_ID"] > 0) || rowData.RefPuNo.Length > 0 ||
				keyColumn.RefType == "REF_RETURN_RC" )
// 管理番号 B19369 To
			{
				puLotDetailCommand.Parameters["@PU_LOT_ID"].Value    = ConvertDBData.ToDecimal(puLotDetailRow["LOT_ID"].ToString());
			}
			else
			{
				lotId++;
				puLotDetailCommand.Parameters["@PU_LOT_ID"].Value    = lotId;
			}

			puLotDetailCommand.Parameters["@PU_LINE_ID"].Value       = ConvertDBData.ToDecimal(rowId);
			puLotDetailCommand.Parameters["@RCPT_NO"].Value          = ConvertDBData.ToNVarChar(puLotDetailRow["RCPT_NO"].ToString());
			puLotDetailCommand.Parameters["@RCPT_LINE_ID"].Value     = ConvertDBData.ToDecimal(puLotDetailRow["RCPT_LINE_ID"].ToString());
			puLotDetailCommand.Parameters["@RCPT_LOT_ID"].Value      = ConvertDBData.ToDecimal(puLotDetailRow["RCPT_LOT_ID"].ToString());
			puLotDetailCommand.Parameters["@SA_NO"].Value            = ConvertDBData.ToNVarChar(puLotDetailRow["SA_NO"].ToString());
			puLotDetailCommand.Parameters["@SA_LINE_ID"].Value       = ConvertDBData.ToDecimal(puLotDetailRow["SA_LINE_ID"].ToString());
			puLotDetailCommand.Parameters["@SA_LOT_ID"].Value        = ConvertDBData.ToDecimal(puLotDetailRow["SA_LOT_ID"].ToString());
			puLotDetailCommand.Parameters["@PROD_CODE"].Value        = ConvertDBData.ToNVarChar(puDetailRow["PROD_CODE"].ToString());
			puLotDetailCommand.Parameters["@PROD_SPEC_1_CODE"].Value = ConvertDBData.ToNVarChar(puDetailRow["PROD_SPEC_1_CODE"].ToString());
			puLotDetailCommand.Parameters["@PROD_SPEC_2_CODE"].Value = ConvertDBData.ToNVarChar(puDetailRow["PROD_SPEC_2_CODE"].ToString());
			puLotDetailCommand.Parameters["@FAB_DATE"].Value         = ConvertDBData.ToDateTime(puLotDetailRow["FAB_DATE"].ToString());
			puLotDetailCommand.Parameters["@LOT_NO"].Value           = ConvertDBData.ToNVarChar(puLotDetailRow["LOT_NO"].ToString());
// 管理番号 B19369 From
//			puLotDetailCommand.Parameters["@PU_QT"].Value            = ConvertDBData.ToDecimal(puLotDetailRow["EDIT_QT"].ToString());
			if(rowData.OverseasFlg == "1" && rowData.PuModeType == "2" && rowData.RcptInputNoNeedFlg == "0" 
				&& puLotDetailRow["LOT_NO"].ToString() == "9")
			{
				puLotDetailCommand.Parameters["@PU_QT"].Value        = ConvertDBData.ToDecimal(puDetailRow["PU_QT"].ToString());
// 管理番号 K25322 From
				puLotDetailCommand.Parameters["@STOCK_UNIT_PU_QT"].Value  = ConvertDBData.ToDecimal(puDetailRow["STOCK_UNIT_PU_QT"].ToString());
// 管理番号 K25322 To
			}
			else
			{
				puLotDetailCommand.Parameters["@PU_QT"].Value        = ConvertDBData.ToDecimal(puLotDetailRow["EDIT_QT"].ToString());
// 管理番号 K25322 From
				puLotDetailCommand.Parameters["@STOCK_UNIT_PU_QT"].Value  = ConvertDBData.ToDecimal(((decimal)puLotDetailRow["EDIT_QT"]*(decimal)puDetailRow["INCLUDE_QT"]).ToString());
// 管理番号 K25322 To
			}
// 管理番号 B19369 To
// 管理番号 B14315 From
//// 管理番号 B13500 From
//			if (puDetailRow["TRANSIT_RCPT_QT"].ToString().Length == 0 || puDetailRow["WH_CODE"].ToString() == "99999"
//				|| puDetailRow["STOCK_ADMIN_FLG"].ToString() == "0"  || rowData.RcptInputNoNeedFlg == "1")
//			{
//				puLotDetailCommand.Parameters["@TRANSIT_RCPT_QT"].Value  = ConvertDBData.ToDecimal(puLotDetailRow["EDIT_QT"].ToString());
//			}
//			else
//			{
//				puLotDetailCommand.Parameters["@TRANSIT_RCPT_QT"].Value  = ConvertDBData.ToDecimal(puLotDetailRow["TRANSIT_RCPT_QT"].ToString());
//			}
//// 管理番号 B13500 To
// 管理番号 B21571 From
//			if(rowData.RcptInputNoNeedFlg == "0" && rowData.PuModeType != "2")
//			{
//				puLotDetailCommand.Parameters["@TRANSIT_RCPT_QT"].Value  = ConvertDBData.ToDecimal(puLotDetailRow["TRANSIT_RCPT_QT"].ToString());
//			}
//			else
//			{
//				if(keyColumn.OverseasFlg == "0")
//				{
//					puLotDetailCommand.Parameters["@TRANSIT_RCPT_QT"].Value  = ConvertDBData.ToDecimal(puLotDetailRow["EDIT_QT"].ToString());
//				}
//				else
//				{
//					puLotDetailCommand.Parameters["@TRANSIT_RCPT_QT"].Value  = 0;
//				}
//			}
			if (keyColumn.ParamType == "Mod" && rowData.PuModeType != "2" && puLotDetailRow["TRANSIT_RCPT_QT"].ToString().Length != 0)
			{
				puLotDetailCommand.Parameters["@TRANSIT_RCPT_QT"].Value = ConvertDBData.ToDecimal(puLotDetailRow["TRANSIT_RCPT_QT"].ToString());
			}
			else
			{
				puLotDetailCommand.Parameters["@TRANSIT_RCPT_QT"].Value = 0;
			}
// 管理番号 B21571 To
// 管理番号 B14315 To
// 管理番号 K25322 From
			puLotDetailCommand.Parameters["@STOCK_UNIT_PO_ALLOC_PU_QT"].Value = ConvertDBData.ToDecimal(puLotDetailRow["PO_ALLOC_RCPT_QT"].ToString());//在庫単位発注引当仕入数量
// 管理番号 K25322 To
			return puLotDetailCommand;
		}

		public static bool GetDeptEmp(CommonData commonData, string empCode, out string deptCode, out string deptShortName)
		{
			bool result = false;
			deptCode = string.Empty;
			deptShortName = string.Empty;

			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT ");
			sb.Append("[ED].[DEPT_CODE] AS [DEPT_CODE], ");
			sb.Append("[ORG].[DEPT_SHORT_NAME] AS [DEPT_SHORT_NAME] ");
			sb.Append("FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[EMP_DEPT]"));
			sb.Append(" AS [ED] ");
			sb.Append(" LEFT OUTER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHART]"));
			sb.Append(" AS [ORG] ");
			sb.Append("  ON [ORG].[DEPT_CODE] = [ED].[DEPT_CODE] ");
			sb.Append(" AND [ORG].[ORG_CHANGE_ID] =  ");
			sb.Append(" (SELECT MAX([ORG_CHANGE_ID]) FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHANGE]"));
			sb.Append("  WHERE [ORG_CHANGE_DATE] = ");
			sb.Append(" (SELECT MAX([ORG_CHANGE_DATE]) FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM, "[ORG_CHANGE]"));
			sb.Append(" WHERE [ORG_CHANGE_DATE] <= GETDATE())) ");
			sb.Append(" WHERE [ED].[EMP_CODE] = @Code");

//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
			DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To

			cm.Parameters.Add("@Code", SqlDbType.NVarChar, 10).Value = ConvertDBData.ToNVarChar(empCode);


			cn.Open();
			SqlDataReader dr = cm.ExecuteReader();
			try
			{
				if (dr.Read())
				{
					deptCode = dr["DEPT_CODE"].ToString();
					deptShortName = dr["DEPT_SHORT_NAME"].ToString();
					result = true;
				}
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
			finally
			{
				dr.Close();
				cn.Close();
			}
			return result;
		}

		//諸掛の有無
		public static bool IsChargePuExists(CommonData commonData, string puNo)
		{
			StringBuilder sb       = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();
//			SqlConnection cn       = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn       = new SqlConnection(DBAccess.GetConnectionString(commonData));
			SqlDataReader dr       = null;
			int cnt = 0;

			try
			{
				if (puNo.Length!=0)
				{
					cn.Open();

					sb.Append(" SELECT COUNT(*) AS COUNT ");
					sb.Append(" FROM ").Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[CHARGE_PU_RELATION]"));
					wpb.AddFilter("[PU_NO]", SearchOperator.Equal, puNo);
					sb.Append(wpb);

					SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
//管理番号P18435 From
					DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
//管理番号P18435 To
					dr = cm.ExecuteReader();

					if (dr.HasRows && dr.Read())
					{
						cnt = (int) dr["COUNT"];
					}
				}
			}
			catch(SqlException ex)
			{
// 管理番号 B23569 From
//				throw new AllegroException(commonData, ex);
				throw new AllegroException(commonData, ex).WriteLog();
// 管理番号 B23569 To
			}
			finally
			{
				if (dr!=null && !dr.IsClosed) dr.Close();
// 管理番号B26347 From
//				if (cn!=null && cn.State!=ConnectionState.Closed) cn.Close();
				if (cn!=null && cn.State!=ConnectionState.Closed)
				{
					cn.Close();
				}
// 管理番号B26347 To
			}
			return (cnt > 0);
		}

		#region 管理番号 B18774 の修正で使うメソッド（同一処理が分散してるので、ここに統合しておきます）
// 管理番号 B18774 From
		public static void setPoDateCondition(IF_SC_MM_05_S01_SearchCondition searchCondition, RealSqlBuilder refSb, out RealSqlBuilder sb)	// 管理番号K27230
		{
			sb = refSb;
			if (searchCondition.PoDateFrom.Length != 0)
			{
				sb.Append(" AND [NEWEST_PO].[PO_DATE] >= '").Append(Convert.ToDateTime(searchCondition.PoDateFrom)).Append("'");
			}
			if (searchCondition.PoDateTo.Length != 0)
			{
				sb.Append(" AND [NEWEST_PO].[PO_DATE] <= '").Append(Convert.ToDateTime(searchCondition.PoDateTo)).Append("'");
			}
		}
// 管理番号 B18774 To
		#endregion
// 管理番号 B21602 From
        private static SqlCommandWrapper CreateRcptReturnOversears(CommonData commonData, SqlConnection cn, IF_SC_MM_05_Base rowData)					// 管理番号K27230
        {				
            StringBuilder sb = new StringBuilder();				
            WherePhraseBuilder wpb = new WherePhraseBuilder();				
				
            sb.Append(" SELECT TOP 3 ");				
            sb.Append("[OV].[PU_NO]             AS [SLIP_NO],");				
            sb.Append("[OV].[OVERSEAS_PU_DT_ID] AS [OVERSEAS_PU_DT_ID],");				
            sb.Append("[OV].[RATIO]             AS [RATIO], ");				
            sb.Append("[OV].[STTL_MTHD_CODE]    AS [STTL_MTHD_CODE], ");				
            sb.Append("[OV].[USANCE_DAY_CNT]    AS [USANCE_DAY_CNT], ");				
            sb.Append("[OV].[STTL_TIMING_CODE]  AS [STTL_TIMING_CODE],");				
            sb.Append("[OV].[PYMT_PLAN_DATE]    AS [PYMT_PLAN_DATE]  ");				
				
            sb.Append(" FROM ");				
            sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [P]");				
            sb.Append(" LEFT OUTER JOIN ");				
            sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[OVERSEAS_PU_DT]")).Append(" AS [OV]");				
            sb.Append(" ON [P].[PU_NO] = [OV].[PU_NO] ");				
            wpb.AddFilter("[OV].[PU_NO]", SearchOperator.Equal, rowData.RefPuNo);				
            sb.Append(wpb);				
				
            sb.Append(" ORDER BY [OV].[OVERSEAS_PU_DT_ID] ASC");				
            return new SqlCommandWrapper(sb.ToString(), cn);					// 管理番号K27230
        }
// 管理番号 B21602 To
// 管理番号 K24277 From
		public static void GetCompSealLogoPath(CommonData commonData, string puNo, string reportId, string reportType, out string logoFilePath, out string compSealFilePath, out string outputType)
		{
			logoFilePath		= string.Empty;
			compSealFilePath	= string.Empty;
			outputType			= string.Empty;

//			SqlConnection cn		= new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn		= new SqlConnection(DBAccess.GetConnectionString(commonData));
			StringBuilder sb		= new StringBuilder();
			DataTable dt			= new DataTable();

			cn.Open();
			try
			{
				sb.Append(" SELECT ");
				sb.Append("		[APPROVAL_STATUS_TYPE] ");
				sb.Append("		,[APPROVAL_CANCEL_FLG] ");
				sb.Append(" FROM ");
				sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]"));
				sb.Append(" WHERE [PU_NO] = @PuNo ");

				SqlDataAdapterWrapper da = new SqlDataAdapterWrapper(sb.ToString(), cn);	// 管理番号K27230

				DBTimeout.setTimeout(da, commonData);

				da.SelectCommand.Parameters.Add("@PuNo", SqlDbType.NVarChar, 10).Value = ConvertDBData.ToNVarChar(puNo);

				da.Fill(dt);

				//社印・ロゴのファイルパスを取得
				CM.MS.Report.GetCompSealLogoPath(commonData, reportId, reportType, out logoFilePath, out compSealFilePath, out outputType);
				
				if(!(dt.Rows[0]["APPROVAL_STATUS_TYPE"].ToString() == "3" && dt.Rows[0]["APPROVAL_CANCEL_FLG"].ToString() == "0"))
				{
					//承認状況区分='3' かつ 決済取消フラグ='0'以外の場合、社印は非表示とする。
					compSealFilePath = string.Empty;
				}
			
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog());
			}
			finally
			{
				cn.Close();
			}

		}
// 管理番号 K24277 To
// 管理番号 B24188 From
		// 支払保留解除
		public static bool HoldRelease(CommonData commonData, IF_SC_MM_05_Base validRowData)
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("UPDATE ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU] "));
			sb.Append(" SET");
			sb.Append(" [HOLD_FLG] = '0' ");
			sb.Append(",[UPDATE_USER_NAME] = @UpdateUserName");
			sb.Append(",[USER_UPDATE_DATETIME] = GETDATE()");
			sb.Append(",[UPDATE_PRG_NAME] = @UpdatePrgName");
			sb.Append(",[PRG_UPDATE_DATETIME] = GETDATE()");
			WherePhraseBuilder wpb = new WherePhraseBuilder();
			wpb.AddFilter("[PU_NO]", SearchOperator.Equal, validRowData.PuNo);
			wpb.AddFilter("[HOLD_FLG]", SearchOperator.Equal, "1");
			wpb.AddFilter("[PRG_UPDATE_DATETIME]", IF.SearchOperator.Equal, validRowData.UpdateDatetime, DateTimeCompareType.Time);
			sb.Append(wpb);

			//トランザクションを開始します。
//			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			cn.Open();
			SqlTransaction tr = cn.BeginTransaction();
			bool result = false;

			try
			{
				SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn, tr);	// 管理番号K27230
				DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
				cm.Parameters.Add("@UpdateUserName", SqlDbType.NVarChar, 50).Value = commonData.UserName;
				cm.Parameters.Add("@UpdatePrgName", SqlDbType.NVarChar, 50).Value = commonData.PageID;

				int rowCount = cm.ExecuteNonQuery();
				if (rowCount == 0)
				{
					tr.Rollback();
					throw (new AllegroException(commonData, ExceptionLevel.Warning, AllegroMessage.S20003).WriteLog(sb.ToString()));
				}
				else
				{
					tr.Commit();
				}
				result = true;
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog());
			}
			finally
			{
				tr.Dispose();
				cn.Close();
			}
			return result;
		}
// 管理番号 B24188 To
// 管理番号 B23437 From
		public static string GetSaNo(CommonData commonData, string slipNo)
		{
			if (slipNo == string.Empty)
			{
				return string.Empty;
			}

			StringBuilder sb = new StringBuilder();
			sb.Append(" SELECT TOP 1 ");
			sb.Append(" [SA_NO] ");
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_DTIL]"));
			sb.Append(" WHERE [PU_NO] = @slipNo");

			SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
			cn.Open();

			string saNo = string.Empty;
			SqlCommandWrapper cm = null;	// 管理番号K27230
			SqlDataReader dr = null;

			try
			{
				cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230
				DBTimeout.setTimeout(cm, commonData);		//タイムアウト値変更メソッド呼出し
				cm.Parameters.Add("@slipNo", SqlDbType.NVarChar, 10).Value = ConvertDBData.ToNVarChar(slipNo);

				dr = cm.ExecuteReader();

				if (dr.Read())
				{
					saNo = dr["SA_NO"].ToString();
				}
			}
			catch (SqlException ex)
			{
				throw (new AllegroException(commonData, ex).WriteLog(sb.ToString()));
			}
			finally
			{
				dr.Close();
				cn.Close();
			}
			return saNo;
		}
// 管理番号 B23437 To
// 管理番号B25595 From
		public static int CheckPuLot(CommonData commonData, IF_SC_MM_05_KeyColumn keyColumn, decimal lineID, IF_SC_MM_05_RowData rowData)
		{
			SqlConnection cn = null;
			int ret = 0;

			try
			{
				cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
				cn.Open();
				ret = CheckPuLot(commonData, cn, null, keyColumn, lineID, rowData);
			}
			catch(System.Exception ex)
			{
				throw (new AllegroException(commonData, ExceptionLevel.Warning, ex.Message).WriteLog());
			}
			finally
			{
				cn.Close();
			}
			return ret;
		}

		private static int CheckPuLot(CommonData commonData, SqlConnection cn, SqlTransaction tr, IF_SC_MM_05_KeyColumn keyColumn, decimal lineID, IF_SC_MM_05_RowData rowData)
		{
			StringBuilder sb = new StringBuilder();
			WherePhraseBuilder wpb = new WherePhraseBuilder();
			SqlCommandWrapper cmd = null;	// 管理番号K27230
			SqlDataReader dr = null;
			int ret = 0;

			if (keyColumn.SlipNo.Length == 0) return ret;

			sb.Append(" SELECT DISTINCT");
			sb.Append("  [P_LOT_D].[PU_LOT_ID] AS [LOT_ID]");	// 入荷ロット明細.ロット行ID
			sb.Append(" ,[P_LOT_D].[LOT_NO]    AS [LOT_NO]");	// 入荷ロット明細.ロット番号
			sb.Append(" FROM ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU_LOT_DTIL]")).Append(" AS [P_LOT_D]");
			sb.Append(" INNER JOIN ");
			sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.SC, "[PU]")).Append(" AS [PU]");
			sb.Append(" ON [PU].[PU_NO] = [P_LOT_D].[PU_NO]");

			wpb.AddFilter("[PU].[REF_PU_NO]", SearchOperator.Equal, keyColumn.SlipNo);
			wpb.AddFilter("[P_LOT_D].[PU_LINE_ID]", SearchOperator.Equal, lineID);
			wpb.AddFilter("[PU].[OPPOSITE_PU_NO]", SearchOperator.Equal, DBNull.Value); // 未削除
			wpb.AddFilter("[PU].[RCPT_INPUT_NO_NEED_FLG]", SearchOperator.Equal, "1"); // 入荷入力不要
			wpb.AddFilter("[PU].[PU_MODE_TYPE]", SearchOperator.Equal, "2"); // 返品
			sb.Append(wpb);

			cmd = new SqlCommandWrapper(sb.ToString(), cn, tr);	// 管理番号K27230
			DBTimeout.setTimeout(cmd, commonData);		//タイムアウト値変更メソッド呼出し

			dr = cmd.ExecuteReader();
			if (dr.HasRows)
			{
				while (dr.Read())
				{
					string lotId = dr["LOT_ID"].ToString();
					string lotNo = dr["LOT_NO"].ToString();

					DataRow[] sRows = rowData.LotDt.Select("ROW_ID=" + lineID + " AND LOT_ID=" + lotId);
					DataRow sRow;
					if (sRows.Length == 1)
					{
						sRow = sRows[0];
					}
					else
					{
						continue;
					}

					if (lotNo != sRow["LOT_NO"].ToString())
					{
						ret = -1;
					}
				}
			}
			else
			{
				// 仕入返品伝票が存在しない場合、正常
				ret = 0;
			}
			if (dr != null && !dr.IsClosed) dr.Close();

			return ret;
		}
// 管理番号B25595 To

		#endregion
	}
}
