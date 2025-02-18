// Product     : Allegro
// Unit        : SC
// Module      : MM
// Function    : 05
// File Name   : IF_SC_MM_05.cs
// 機能名      : 仕入管理
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 管理番号 B11723・B11796 2004/09/24 原価・粗利額等の丸め処理統一
// 1.2.0 2004/09/30
// 管理番号 B13329 2004/10/19 小数制御に関する修正
// 管理番号 B13429 2004/10/25 課税対象金額の算出ロジックの修正
// 1.2.2 2004/10/31
// 管理番号 B13500 2004/11/17 入荷省略のチェックボックス使用可に変更対応
// 管理番号 B13569 2004/11/19 発注参照時の予約区分「予約あり」対応
// 管理番号 B13798 2004/11/30 管理項目の追加
// 管理番号 B13502 2004/12/17 国内取引外貨決済対応
// 1.3.0 2004/12/31
// 管理番号 B14028 2004/01/10 オーバーフローに対する対応
// 1.3.1 2005/01/31
// 管理番号 B13877 2005/02/01 プロジェクト別在庫管理対応
// 管理番号 B13878 2005/02/08 売上・仕入時の単価未決対応
// 管理番号 B14315 2005/03/31 入荷省略しない海外仕入返品対応
// 管理番号 B14465 2005/02/22 ヘッダ倉庫が直送の場合に入力チェックでエラーとなる不具合を修正
// 管理番号 B14298 2005/02/25 通貨途中変更による明細再計算対応
// 管理番号 B14477 2005/02/26 基軸換算時に、レート係数が加味されずに算出されている不具合を修正
// 管理番号 B14307 2005/03/11 算術オーバーフローの対応
// 1.3.2 2005/03/31
// 管理番号 B15297 2005/04/19 支払予定日と仕入日のチェックメッセージ変更
// 管理番号 B12929 2005/04/13 仕入先別単価設定対応
// 管理番号 B15414 2005/04/27 レート0チェックの追加
// 管理番号 B15722 2005/06/07 更新時に単価のの入力(少数)チェックがされない不具合対応
// 管理番号 B15804 2005/06/14 入荷参照時に新規行登録を行うと入荷されていない商品まで入荷済みになる不具合を修正
// 1.3.3 2005/06/30
// 管理番号 B15952 2005/07/22 単価0が入力できない不具合を修正
// 管理番号 B15710 2005/08/03 レスポンス是正対応
// 管理番号 B16171 2005/08/09 入荷済みの発注を参照した仕入を修正モードで開くと入荷済みになっていない不具合を修正
// 管理番号 K16187 2005/09/06 支払機能拡張対応
// 1.4.0 2005/10/31
// 管理番号 K16588 2005/11/14 プロジェクトコード桁数拡張対応
// 管理番号 K16590 2005/11/24 管理会計機能拡張（日付チェック機能強化対応）
// 管理番号 B16832 2005/12/13 振込依頼人・口座名義人チェックオプションの変更（半角数字(0～9)、半角英大文字(A～Z)、半角カタカナ(ヲ以外)、半角スペース、半角左右括弧を許容)
// 管理番号 K16671 2005/12/22 貿易機能改善（参照コードの追加対応）
// 管理番号 B17548 2006/03/11 仕入入力にて、行更新していないのにロット詳細の内容が確定され、DBに反映される不具合対応
// 管理番号 B17601 2006/03/23 手入力すると他外貨の予約番号でもレートを取得できてしまう不具合対応
// 1.5.0 2006/03/31
// 管理番号 B19369 2007/01/12 入荷省略しない海外仕入返品時は入荷参照とするよう修正
// 管理番号 B19475 2007/02/13 取引先別商品名対応
// 管理番号 B20392 2007/03/20 雑コード入力時のチェック対応
// 1.5.1 2007/06/30
// 管理番号 K20687 2007/07/06 内部統制強化：計上基準追加対応
// 管理番号 K20684 2007/08/24 承認機能追加
// 1.5.2 2007/10/31
// 管理番号 B20818 2007/12/17 楽観ロック対応
// 管理番号 B20946 2008/06/18 外貨決済期間のFrom-Toチェックを行うよう修正
// 管理番号 B21726 2008/06/19 仕入更新を行った場合、楽観ロックチェックを行うよう修正
// 管理番号 K22205 2008/10/09 WF申請者以外の伝票修正
// 管理番号 K22217 2008/10/09 WF伝票入力承認者変更
// 管理番号 B21177 2009/03/03 仕入伝票を参照して返品する際、参照元の仕入日より前の日付で更新しようとした場合はエラーとするよう修正
// 管理番号 B21516 2009/03/11 修正時の為替予約チェックが不正の不具合対応
// 管理番号 B22105 2009/03/26 仕入伝票と仕入確認票の商品名が異なる不具合対応
// 管理番号 B22191 2009/03/31 発注伝票との伝票日付の前後関係チェックを追加
// 管理番号 B21977 2009/08/10 一括請求の場合、請求処理日項目に請求締日が表示されるよう修正
// 管理番号 B22190 2009/08/10 返品入力時、明細行に100000以上の数量を登録できない不具合を修正
// 1.6.0 2009/09/30
// 管理番号 B22792 2010/03/25 行編集中に挿入ボタンを押下すると、ロット詳細の情報のみ保持されてしまう不具合を修正
// 管理番号 B21416 2010/04/12 商品名を変更後、再度明細行を更新すると、商品名（正式）が商品マスタから再取得される不具合を修正
// 管理番号 B22497 2010/04/12 商品名をスペースで登録できてしまう不具合を修正
// 管理番号 B22412 2010/05/11 不要な伝票日付の前後関係チェックが行われてしまっている不具合を修正
// 管理番号 B22031 2010/09/06 銀行国コードが「JPN」以外で口座名義人に全角文字が含まれているとエラーとなる不具合を修正
// 管理番号 B23588 2010/11/26 挿入行を編集中に明細に連動する項目を変更すると空の明細行が登録される不具合を修正
// 管理番号 B23717 2010/11/30 返品時（マイナス金額時）の為替予約チェック
// 管理番号 K24153 2011/07/23 検収基準増加対応
// 管理番号 K24278 2012/01/13 仕入先課税区分追加対応
// 管理番号 K24285 2012/01/16 売上・仕入マイナス数量入力対応
// 管理番号 K24284 2012/01/23 プロジェクト必須対応
// 管理番号 K24382 2012/01/30 規格コード桁数拡張
// 管理番号 K24389 2012/03/01 ボリュームディスカウント機能
// 管理番号 B24051 2012/04/04 入荷参照している伝票の行を削除して新規行を登録すると有効在庫が不正になる不具合を修正
// 管理番号 B23238 2012/05/17 99明細登録後、行更新でエラーが発生する不具合の修正
// 2.0.0 2012/10/31
// 管理番号 B24264 2012/12/03 雑取引先の情報を都度入力できるように修正
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 管理番号 K24789 2013/05/13 消費税率の段階的引き上げ対応
// 管理番号 B24959 2013/10/16 雑仕入先の場合、必須項目を入力せずに伝票が登録ができてしまう不具合を修正
// 管理番号 K25322 2014/04/17 ロット引当対応
// 2.2.0 2014/10/31
// 管理番号 B24873 2016/02/17 支払条件の決済方法を台帳が２つになるならエラーにするよう修正
// 管理番号 K25647 2015/03/10 項目桁数拡張
// 管理番号 K25679 2015/09/17 グループ対応
// 管理番号 K25680 2015/09/17 外部連携
// 管理番号 B26066 2015/12/11 仕入参照返品時の税区分取得不備
// 管理番号 K25665 2015/12/14 消費税区分初期表示
// 2.3.0 2016/06/30
// 管理番号B25370 2016/07/20 後続伝票が存在する場合は削除ボタンを押下不可とする修正
// 管理番号B26146 2018/02/19 仕入予定単価の取得タイミングが不正
// 3.0.0 2018/04/30
// 管理番号K27063 2019/08/07 客注番号／発注管理番号の全角入力対応
// 管理番号K27062 2019/10/04 受渡場所マスタの設定方法改善
// 管理番号K27058 2019/10/16 汎用区分追加
// 管理番号K27057 2019/12/05 汎用項目追加
// 3.1.0 2020/06/30
// 管理番号B27043 2020/07/01 仕入形態が預りの際に、発注しない商品が設定できてしまう
// 管理番号B27005 2020/07/01 支払条件の決済方法を同じ決済方法が複数あればエラーにするよう修正
// 管理番号K27154 2020/07/13 収益認識対応
// 管理番号K27441 2022/02/14 組織変更機能改善
// 管理番号B27422 2022/09/06 ロット管理しない商品にも関わらずロット番号付き在庫が発生する
// 管理番号K27522 2022/10/21 適格請求書等保存方式対応(税抜税込混在時の税額計算対応)
// 管理番号K27525 2022/10/21 適格請求書等保存方式対応(仕入税額控除の要件対応)
// 3.2.0 2023/03/31
// 管理番号B27219 2023/07/25 銀行国コードがJPNの場合は口座名義人の入力桁数チェックを48に修正

using System;
using System.Data;
// 管理番号 B24264 From
using System.Collections;
// 管理番号 B24264 To
using Infocom.Allegro.IF;
using Infocom.Allegro.CM.MS;
using Infocom.Allegro.SC.MS;

namespace Infocom.Allegro.SC
{
	[Serializable()]
	public abstract class IF_SC_MM_05_Base: Infocom.Allegro.IF.IFBase
	{
		#region struct
		protected struct ParamType
		{
			public const string NEW		     = "New";
			public const string MOD          = "Mod";
			public const string VIEW         = "View";
			public const string COPY         = "Copy";
			public const string COPY_SO      = "CopyPO";
			public const string COPY_SH      = "CopyRC";
			public const string NONE         = "";
		}
		protected struct RowState
		{
			public const string Create       = "C";
			public const string Ref          = "R";
			public const string Update       = "U";
			public const string Delete       = "D";
			public const string Temp         = "T";
		}
		#endregion

		#region Protected Fields
		//仕入テーブル
		protected string puNo						= string.Empty;		// 仕入番号
		protected string puName						= string.Empty;		// 件名
		protected string puDate						= string.Empty;		// 仕入日
// 管理番号 K16590 From
		protected string dealDate					= string.Empty;		// 取引日
// 管理番号 K16590 To
		protected string poNo						= string.Empty;		// 発注番号
		protected string rcptNo						= string.Empty;		// 入荷番号
		protected string puModeType					= string.Empty;		// 仕入形態区分
// 管理番号K27058 From
		protected string puModeTypeDtilCode			= string.Empty;		// 仕入形態区分明細コード
// 管理番号K27058 To
		protected string refPuNo					= string.Empty;		// 参照仕入番号
// 管理番号 B21177 From
		protected string refPuDate					= string.Empty;		// 参照元仕入日
// 管理番号 B21177 To
		// 管理番号 B14477 From
		protected string curCode					= string.Empty;		// 通貨コード
		protected string keyCurCode					= string.Empty;		// 通貨コード
		// 管理番号 B14477 To
		protected string exchangeType				= string.Empty;		// 為替区分
		protected string exchangeRezNo				= string.Empty;		// 為替予約番号
		protected string rate						= string.Empty;		// レート
		protected string deptCode					= string.Empty;		// 部門コード
		protected string deptShortName				= string.Empty;		// 部門略名
		protected string originDeptCode				= string.Empty;		// 発生部門コード
		protected string oldDeptCode				= string.Empty;		// 旧部門コード
		protected string orgChangeId				= string.Empty;		// 組織変更ID
		protected string dataMigrateDatetime		= string.Empty;		// データ移行日時
		protected string empCode					= string.Empty;		// 社員コード
		protected string projCode					= string.Empty;		// プロジェクトコード
		protected string projSbno					= string.Empty;		// プロジェクト枝番
		protected string suplCode					= string.Empty;		// 仕入先コード
		protected string suplSbno					= string.Empty;		// 仕入先枝番
		protected string tempCodeFlg				= string.Empty;		// 雑コードフラグ('1';雑コード '0':通常)
		protected string suplName					= string.Empty;		// 仕入先名
		protected string suplShortName				= string.Empty;		// 仕入先略名
		protected string suplDeptName1				= string.Empty;		// 仕入先部門名1
		protected string suplDeptName2				= string.Empty;		// 仕入先部門名2
		protected string suplCountryCode			= string.Empty;		// 仕入先国コード
		protected string suplZip					= string.Empty;		// 仕入先郵便番号
		protected string suplState					= string.Empty;		// 仕入先都道府県名
		protected string suplCity					= string.Empty;		// 仕入先市区町村名
		protected string suplAddress1				= string.Empty;		// 仕入先町域名
		protected string suplAddress2				= string.Empty;		// 仕入先ビル名
		protected string suplPhone					= string.Empty;		// 仕入先電話番号
		protected string suplFax					= string.Empty;		// 仕入先FAX番号
		protected string suplUserName				= string.Empty;		// 仕入先担当者名
		protected string acNo						= string.Empty;		// 口座番号
		protected string acHolder					= string.Empty;		// 口座名義人
		protected string acType						= string.Empty;		// 口座区分
		protected string bankAcType					= string.Empty;		// 銀行口座区分
		protected string bankCountryCode			= string.Empty;		// 銀行国コード
		protected string bankCode					= string.Empty;		// 銀行コード
		protected string bankBranchCode				= string.Empty;		// 銀行支店コード
		protected string remitFeeType				= string.Empty;		// 振込手数料区分
		protected string remitMthd1DealType			= string.Empty;		// 振込方法1扱い区分
		protected string remitMthd2Type				= string.Empty;		// 振込方法2区分
		protected string deliType					= "W";				// 納入区分（W：倉庫）
		protected string whCode						= string.Empty;		// 倉庫コード('99998':積送品 '99999':直送、得意先(出荷済未計上))
		protected string deliCustCode				= string.Empty;		// 納入先コード
		protected string deliCustSbno				= string.Empty;		// 納入先枝番
		protected string deliPlaceCode				= string.Empty;		// 受渡場所コード
		protected string deliPlaceName				= string.Empty;		// 受渡場所名
		protected string deliPlaceCountryCode		= string.Empty;		// 受渡場所国コード
		protected string deliPlaceZip				= string.Empty;		// 受渡場所郵便番号
		protected string deliPlaceState				= string.Empty;		// 受渡場所都道府県名
		protected string deliPlaceCity				= string.Empty;		// 受渡場所市区町村名
		protected string deliPlaceAddress1			= string.Empty;		// 受渡場所町域名
		protected string deliPlaceAddress2			= string.Empty;		// 受渡場所ビル名
		protected string deliPlacePhone				= string.Empty;		// 受渡場所電話番号
		protected string deliPlaceFax				= string.Empty;		// 受渡場所FAX番号
		protected string deliPlaceUserName			= string.Empty;		// 受渡場所担当者名
		protected string dtType						= string.Empty;		// 取引条件区分('L':一括 'E':都度)
		protected string dt1SttlMthdCode			= string.Empty;		// 取引条件1決済方法コード
		protected string dt1BasisAmt				= string.Empty;		// 取引条件1基準金額
		protected string dt2SttlMthdCode			= string.Empty;		// 取引条件2決済方法コード
		protected string dt2Ratio					= string.Empty;		// 取引条件2比率
		protected string dt3SttlMthdCode			= string.Empty;		// 取引条件3決済方法コード
		protected string dtSight					= string.Empty;		// 取引条件サイト
		protected string dtCutoffCycleType          = string.Empty;		// 回収条件サイクル区分
		protected string cutoffDate					= string.Empty;		// 締日
// 管理番号 B21977 From
		protected string cutoffFinDate				= string.Empty;		// 支払処理日
// 管理番号 B21977 To
		protected string pymtPlanDate				= string.Empty;		// 支払予定日
		// 管理番号 B13878 From
		//protected string holdFlg					= string.Empty;		// 保留フラグ
		protected string holdFlg					= "0";				// 保留フラグ
		// 管理番号 B13878 To
		protected string dtNote						= string.Empty;		// 取引条件表記
		protected string dtCutoffDay				= string.Empty;		// 取引条件締日付
		protected string dtTermMonthCnt				= string.Empty;		// 取引条件期限月数
		protected string dtTermDay					= string.Empty;		// 取引条件期限日付
// 管理番号 B22191 From
        protected string poDate					    = string.Empty;		// 発注日付
// 管理番号 B22191 To
// 管理番号K27441 From
		protected string poDeptCode					= string.Empty;		// 発注.部門コード
// 管理番号K27441 To
		protected string suplBillSlipNo				= string.Empty;		// 仕入先請求書番号
		protected string canceledOrderFlg			= string.Empty;		// 出合フラグ('1':該当する(出合) '0':該当しない)
		protected string overseasFlg				= string.Empty;		// 海外フラグ('1':該当する(海外) '0':該当しない)
		protected string tenorCode					= string.Empty;		// 建値コード
		protected string fmoneySttlPeriodSttMonth 	= string.Empty;		// 外貨決済期間開始月
		protected string fmoneySttlPeriodEndMonth 	= string.Empty;		// 外貨決済期間終了月
		protected string lcNo						= string.Empty;		// LC番号
		protected string remarksCode				= string.Empty;		// 摘要コード
		protected string remarks					= string.Empty;		// 摘要
		// 管理番号 B13798 From
		protected string adminItem1					= string.Empty;		// 管理項目1
		protected string adminItem2					= string.Empty;		// 管理項目2
		protected string adminItem3					= string.Empty;		// 管理項目3
		// 管理番号 B13798 To
		// 管理番号 K20687
		protected string bookBasisType              = string.Empty;		// 仕入.計上基準区分
		// 管理番号 K20687
// 管理番号K27058 From
		protected string bookBasisTypeDtilCode		= string.Empty;		// 仕入.計上基準区分明細コード
// 管理番号K27058 To
		protected bool	 outlandRemittanceFlg		= false;			// 外国送金フラグ
		protected string internationalItemNo		= string.Empty;		// 国際項目番号
		protected string remittancePurpose			= string.Empty;		// 送金目的
		protected bool   remittanceAllowFlg			= false;			// 送金許可フラグ
		protected string remittanceAllowNo			= string.Empty;		// 送金許可番号
		protected string remittanceMessage			= string.Empty;		// 送金メッセージ
		protected string approvalStatusType			= string.Empty;		// 承認状況区分('1':申請 '2':途中 '3':決裁 '4':差戻 '5':保留)
		protected string puSlipOutputFlg			= string.Empty;		// 仕入伝票出力フラグ('1':出力済 '0':未出力)
		protected string etaxDtilAmtTtl				= string.Empty;		// 税抜分明細金額合計
		protected string itaxDtilAmtTtl				= string.Empty;		// 税込分明細金額合計
		protected string ntaxDtilAmtTtl				= string.Empty;		// 非課税分明細金額合計
		protected string etaxAmtTtl					= string.Empty;		// 外税金額合計
		protected string itaxAmtTtl					= string.Empty;		// 内税金額合計
		// 管理番号 B14028 From
		//		protected string grandTtl					= string.Empty;		// 総合計
		//		protected string keyGrandTtl				= string.Empty;		// 基軸換算総合計
		protected decimal grandTtl					= 0M;				// 総合計
		protected decimal keyGrandTtl				= 0M;				// 基軸換算総合計
		// 管理番号 B14028 To
// 管理番号 K24789 From
		protected string amtRoundType				= string.Empty;
		protected decimal dtilAmtTtl				= 0M;
		protected decimal taxableAmtTtl				= 0M;
		protected decimal taxAmtTtl					= 0M;
// 管理番号 K24789 To
		protected decimal koAmt						= 0;				// 消込金額
		protected string lastKoDate					= string.Empty;		// 最終消込日
		protected string koCompleteFlg				= string.Empty;		// 消込完了フラグ('1':完了 '0':未完了)
// 管理番号 K16187 From
		protected decimal approvedKoAmt				= 0;		// 承認済消込金額
		protected string dtilKoFlg					= string.Empty;		// 明細承認済消込
		protected string deleteAllowFlg				= string.Empty;		// 伝票削除フラグ
// 管理番号 K16187 To
		protected string exchangeGainLossAmtTtl		= string.Empty;		// 為替差損益金額合計
		protected string lastExchangeValuationDate	= string.Empty;		// 最終為替評価日
		protected string exchangeValuationFinFlg	= string.Empty;		// 為替評価完了フラグ('1':完了 '0':未完了)
		protected string pymtNo						= string.Empty;		// 支払番号
		protected string cutoffFinFlg				= string.Empty;		// 締完了フラグ('1':完了 '0':未完了)
		protected string cancelFlg					= string.Empty;		// 取消フラグ('1':取消 '0':その他)
		protected string redSlipFlg					= string.Empty;		// 赤伝フラグ('1':赤伝 '0':黒伝)
		protected string originPuNo					= string.Empty;		// 発生仕入番号
		protected string oppositePuNo				= string.Empty;		// 相手仕入番号
		protected string lastJrnlExecDatetime		= string.Empty;		// 最終仕訳実行日時
		protected string jrnlFinFlg					= string.Empty;		// 仕訳完了フラグ('1':完了 '0':未完了)
		protected string soNo						= string.Empty;		// 受注番号
		protected string soDate						= string.Empty;		// 受注日
		protected string custName					= string.Empty;		// 得意先名
		// 管理番号 B13500 From
		protected string rcptInputNoNeedFlg			= string.Empty;		// 入荷入力不要フラグ
		// 管理番号 B13500 To
		// 管理番号 B13569 From
		protected string refPoExchangeType			= string.Empty;		// 発注参照時の為替区分（'1':予約あり '0':その他）
		// 管理番号 B13569 To

		//その他 SELECT項目以外
		protected bool consistsData					= false;			// データ有無

		protected string puCtaxTypeCode				= string.Empty;		// 仕入税区分コード
		protected string puReturnCtaxTypeCode		= string.Empty;		// 仕入返品税区分コード
// 管理番号 K24789 From
		// 明細単位に消費税区分コードを保持するため、ヘッダ部はコメントアウト
//		protected string ctaxTypeCode				= string.Empty;		// 仕入税区分コード
// 管理番号 K24789 To
		protected string ctaxBuildupType			= "1";				// 消費税積上区分
		protected string ctaxRoundType				= "R";				// 消費税丸め区分

		protected Int32 errNo						= 0;				// エラー番号を格納する変数
		protected string message					= string.Empty;		// エラーメッセージを格納する変数/* 0：無い、1：有る */
		//エラーメッセージ以外で表示するメッセージが有るかないか(0：無い、1：有る)
		protected DataTable dt						= null;
		protected DataTable lotDt					= null;

		protected IF_SC_MS_OverseasDT[] overseas    = null;				// 海外取引条件

		//更新時に使用
		protected string dtilChangedFlg             = "0";				// 明細変更フラグ
		protected string creditConfirm              = string.Empty;		// 与信チェック(0：未チェック、1：チェック済み)
		protected Int32 ret                         = 0;				// エラー番号を格納する変数
		protected string resultInformation          = string.Empty;		// エラーメッセージを格納する変数
		protected string informationFlg             = "0";				// エラーメッセージ以外で表示するメッセージが有るかないか 0：無い、1：有る
		protected string productSpecUseType         = string.Empty;		// 商品規格使用フラグ
		protected string prodSpec1CodeTitle	        = string.Empty;		// 規格１名称
		protected string prodSpec2CodeTitle	        = string.Empty;		// 規格２名称
		protected readonly int MAX_LINE_ID          = 99;				// 明細最大行数
		protected string	lowerDeptCode			= string.Empty;		// 自部門
		// 管理番号 B13500 From
		protected decimal transitRcptQtTtl			= 0;				// 未着品入荷数量
		// 管理番号 B13500 To

		// 管理番号 B14298 From
		protected bool priceDecimalUseFlg			= false;			// 自社.単価小数使用フラグ
		protected string curDigit					= string.Empty;		// 通貨.通貨小数桁数
		// 管理番号 B14298 To
// 管理番号 B20818 From
		protected DateTime updateDatetime;
		protected DateTime refUpdateDatetime;
// 管理番号 B20818 To
// 管理番号 K22205 From
        protected string inputEmpCode               = string.Empty;     // 入力社員コード
// 管理番号 K22205 To
// 管理番号 K22217 From
        protected string approvalPlanEmpCode        = string.Empty;     //承認予定社員コード
        protected string changeApprovalRouteId      = string.Empty;     //承認経路ID
// 管理番号 K22217 To
// 管理番号 B22031 From
		protected string japanCountryCode			= string.Empty;		//日本国コード
// 管理番号 B22031 To
// 管理番号 K24278 From
		protected string imposeFlg					= string.Empty;		//仕入先.消費税課税フラグ
// 管理番号 K24278 To
// 管理番号 B24051 From
		protected decimal maxLineID					= 0M;				// 現在の明細最大行数
// 管理番号 B24051 To
// 管理番号 K25647 From
		protected byte priceDecimalDigit			= (byte)0;
		protected bool myCompQtDecimalUseFlg  = false;					// 在庫チェック用自社マスタ数量使用フラグ
// 管理番号 K25647 To
// 管理番号 K25679 From
		protected string poAdminNo					= string.Empty;		// 発注管理番号
		protected string suplSlipNo					= string.Empty;		// 仕入先伝票番号
		protected string procType					= "0";				// 処理区分
// 管理番号 K25679 To
// 管理番号 K25680 From
		protected string importSlipNo				= string.Empty;		// 取込伝票番号
// 管理番号 K25680 To
// 管理番号B25370 From
		/// <summary>自身に対する返品伝票が存在するか</summary>
		protected bool isReferringSlipExists = false;
		/// <summary>仕入伝票を参照している諸掛伝票の件数</summary>
		protected int chargeCount = 0;
// 管理番号B25370 To
// 管理番号K27057 From
		protected IF_CM_MS_CustomItem customItemHead = new IF_CM_MS_CustomItem();
		protected IF_CM_MS_CustomItem customItemDtil = new IF_CM_MS_CustomItem();
// 管理番号K27057 To
// 管理番号K27154 From
		protected string dealTypeCode				= string.Empty;     // 取引区分コード
																		// 管理番号K27154 To

		//课题2 From
		/// <summary>
		/// 入力者名
		/// </summary>
		protected string inputEmpName = string.Empty;
		/// <summary>
		/// 消费税小数舍入区分
		/// </summary>
		protected string ctaxFractionRoundType = string.Empty;
		/// <summary>
		/// 承运人代码
		/// </summary>
		protected string carrierCode = string.Empty;
		//课题2 To
		#endregion

		#region Constructors
		protected IF_SC_MM_05_Base()
		{
			dt = new DataTable();
			dt.Columns.Add("PU_LINE_ID"					, typeof(decimal));		// 仕入行ID
			dt.Columns.Add("PU_LINE_NO"					, typeof(decimal));		// 仕入行番号
			dt.Columns.Add("PO_NO"						, typeof(string));		// 発注番号
			dt.Columns.Add("PO_LINE_ID"					, typeof(decimal));		// 発注行ID
			dt.Columns.Add("RCPT_NO"					, typeof(string));		// 入荷番号
			dt.Columns.Add("RCPT_LINE_ID"				, typeof(decimal));		// 入荷行ID
			dt.Columns.Add("SO_NO"						, typeof(string));		// 受注番号
			dt.Columns.Add("SO_LINE_ID"					, typeof(decimal));		// 受注行ID
			dt.Columns.Add("SA_NO"						, typeof(string));		// 売上番号
			dt.Columns.Add("SA_LINE_ID"					, typeof(decimal));		// 売上行ID
			dt.Columns.Add("WH_CODE"					, typeof(string));		// 倉庫コード
			dt.Columns.Add("WH_SHORT_NAME"				, typeof(string));		// 倉庫名
			dt.Columns.Add("PROD_CODE"					, typeof(string));		// 商品コード
			dt.Columns.Add("PROD_PO_NAME"				, typeof(string));		// 商品発注名
			dt.Columns.Add("PROD_SHORT_NAME"			, typeof(string));		// 商品略名
			dt.Columns.Add("PROD_NAME"					, typeof(string));		// 商品名
			dt.Columns.Add("PROD_TYPE"					, typeof(string));		// 商品区分
			dt.Columns.Add("DISP_CONTROL_TYPE"			, typeof(string));		// 表示制御区分
			dt.Columns.Add("STOCK_ADMIN_FLG"			, typeof(string));		// 在庫管理フラグ
			dt.Columns.Add("LOT_ADMIN_FLG"				, typeof(string));		// ロット管理フラグ
			dt.Columns.Add("QT_DECIMAL_USE_FLG"			, typeof(string));		// 数量小数使用フラグ
			dt.Columns.Add("CTAX_CALC_TYPE"				, typeof(string));		// 消費税計算区分
			dt.Columns.Add("CTAX_RATE_CODE"				, typeof(string));		// 仕入消費税率コード
			dt.Columns.Add("CTAX_RATE"					, typeof(decimal));		// 消費税率
			dt.Columns.Add("PROD_SPEC_1_CODE"			, typeof(string));		// 商品規格1コード
			dt.Columns.Add("PROD_SPEC_1_NAME"			, typeof(string));		// 商品規格1名
			dt.Columns.Add("PROD_SPEC_2_CODE"			, typeof(string));		// 商品規格2コード
			dt.Columns.Add("PROD_SPEC_2_NAME"			, typeof(string));		// 商品規格2名
			dt.Columns.Add("PU_PLAN_PRICE"				, typeof(decimal));		// 仕入予定単価
			dt.Columns.Add("STOCK_UNIT_STD_SELL_PRICE"	, typeof(decimal));		// 在庫単位標準販売単価
			dt.Columns.Add("UNIT_CODE"					, typeof(string));		// 単位コード
			dt.Columns.Add("UNIT_SHORT_NAME"			, typeof(string));		// 単位名
			dt.Columns.Add("PU_QT"						, typeof(decimal));		// 仕入数量
			dt.Columns.Add("INIT_PU_QT"					, typeof(decimal));		// 仕入数量(初期値)
			dt.Columns.Add("TRANSIT_RCPT_QT"			, typeof(decimal));		// 未着品入荷数量
			dt.Columns["TRANSIT_RCPT_QT"].DefaultValue =0M;
			dt.Columns.Add("RCPT_INPUT_NO_NEED_FLG"		, typeof(string));		// 入荷入力不要フラグ
			dt.Columns["RCPT_INPUT_NO_NEED_FLG"].DefaultValue ="1";
			dt.Columns.Add("UPPER_LIMIT_PU_QT"			, typeof(decimal));		// 仕入数量（上限値）
			dt.Columns.Add("VALID_QT"					, typeof(decimal));		// 有効在庫数
			dt.Columns.Add("STOCK_UNIT_PU_QT"			, typeof(decimal));		// 在庫単位仕入数量
			dt.Columns.Add("STOCK_UNIT_PO_PU_QT"		, typeof(decimal));		// 在庫単位発注仕入数量
			dt.Columns.Add("STOCK_UNIT_PO_ALLOC_PU_QT"	, typeof(decimal));		// 在庫単位発注引当仕入数量
			dt.Columns.Add("PU_PRICE"					, typeof(decimal));		// 仕入単価
			dt.Columns.Add("INIT_PU_PRICE"				, typeof(decimal));		// 更新前の仕入単価（不必要な気が･･･）
			dt.Columns.Add("DISC_FLG"					, typeof(string));		// 値引フラグ
			// 管理番号 B13878 From
			dt.Columns.Add("PRICE_UNDECIDED_FLG"		, typeof(string));		// 単価未決フラグ
			// 管理番号 B13878 To
			dt.Columns.Add("LINE_REMARKS_CODE"			, typeof(string));		// 行摘要コード
			dt.Columns.Add("LINE_REMARKS"				, typeof(string));		// 行摘要
// 管理番号K27525 From
			dt.Columns.Add("BOOK_DEDUCTION_REASON_CODE"	, typeof(string));		// 帳簿控除理由コード
			dt.Columns.Add("BOOK_DEDUCTION_REASON_NAME"	, typeof(string));		// 帳簿控除理由
// 管理番号K27525 To
// 管理番号 K16671 From
			dt.Columns.Add("REF_CODE"                   , typeof(string));		// 参照コード
// 管理番号 K16671 To
			dt.Columns.Add("INCLUDE_QT"					, typeof(decimal));		// 入数
			dt.Columns.Add("DTIL_AMT"					, typeof(decimal));		// 明細金額
			dt.Columns.Add("ETAX_AMT"					, typeof(decimal));		// 外税金額
			dt.Columns.Add("ITAX_AMT"					, typeof(decimal));		// 内税金額
			dt.Columns.Add("PRICE_UPDATE_FLG"			, typeof(string));		// 得意先単価更新フラグ
			dt.Columns.Add("PU_MONEY"					, typeof(decimal));		// 仕入金額(計算値)
			dt.Columns.Add("PROD_NAME_CORRECTION_FLG"	, typeof(string));		// 商品名変更許可フラグ
			dt.Columns.Add("PROD_EDIT_FLG"				, typeof(string));		// 商品変更可能フラグ
			dt.Columns.Add("IS_RCPT_EXECUTE"			, typeof(string));		// 入荷済み
			dt.Columns.Add("MULTI_LOT_FLG"				, typeof(string));		// 複数ロットフラグ
			dt.Columns.Add("ROW_STATE"					, typeof(string));		// 行状態
// 管理番号 K24789 From
			dt.Columns.Add("CTAX_TYPE_CODE"				, typeof(string));		// 消費税区分コード
			dt.Columns.Add("TAXINFO_CHG_FLG"			, typeof(string));		// 1:消費税情報変更あり
			dt.Columns["TAXINFO_CHG_FLG"].DefaultValue = "0";
// 管理番号 K24789 To
// 管理番号 K25322 From
			dt.Columns.Add("LOT_STOCK_VALUATION_FLG"	, typeof(string));      //ロット別在庫評価フラグ
// 管理番号 K25322 To
//課題です 2 From
			dt.Columns.Add("INPUT_EMP_NAME", typeof(string));               //入力者
			dt.Columns.Add("INPUT_EMP_CODE", typeof(string));				//入力者
			dt.Columns.Add("CTAX_FRACTION_ROUND_TYPE", typeof(string));      //消費税端数区分
			dt.Columns.Add("CARRIER_CODE", typeof(string));					//運送業者コード
//課題です 2 From
			dt.Columns["PU_LINE_ID"].AutoIncrement = true;
			dt.PrimaryKey = new DataColumn[] {dt.Columns["PU_LINE_ID"]};

			//ロット明細共通インターフェース
// 管理番号 K25322 From
//			this.lotDt = new Infocom.Allegro.SC.IF_SC_MS_Lot().LotDt.Clone();
//			this.lotDt.Columns.Add("RCPT_NO"      ,typeof(string));
//			this.lotDt.Columns.Add("RCPT_LINE_ID" ,typeof(string));
//			this.lotDt.Columns.Add("RCPT_LOT_ID"  ,typeof(string));
//			this.lotDt.Columns.Add("SA_NO"        ,typeof(string));
//			this.lotDt.Columns.Add("SA_LINE_ID"   ,typeof(string));
//			this.lotDt.Columns.Add("SA_LOT_ID"    ,typeof(string));
//			this.lotDt.Columns.Add("TRANSIT_RCPT_QT", typeof(decimal));		// 未着品入荷数量
			this.lotDt = new Infocom.Allegro.SC.IF_SC_MS_Lot(true).LotDt.Clone();
// 管理番号 K25322 To

			//主キー設定
			this.lotDt.PrimaryKey = null;
			DataColumn idS1Column = this.lotDt.Columns["ROW_ID"];
			DataColumn idS2Column = this.lotDt.Columns["LOT_ID"];
			DataColumn idS3Column = this.lotDt.Columns["STOCK_TYPE"];
			DataColumn[] pk = new DataColumn[]{idS1Column, idS2Column, idS3Column};
			this.lotDt.PrimaryKey = pk;
		}
		#endregion

		#region Properties
		public virtual string PuNo
		{
			get {return puNo;}
// 			set {puNo = ValidateString("仕入番号", value , false, 10, CheckOption.SingleByte);} //K24546
			set {puNo = ValidateString(MultiLanguage.Get("SC_CS000809"), value , false, 10, CheckOption.SingleByte);}
		}
		public virtual string PuName
		{
			get {return puName;}
// 			set {puName = ValidateString("件名", value , false, 30, CheckOption.None);} //K24546
			set {puName = ValidateString(MultiLanguage.Get("SC_CS000536"), value , false, 30, CheckOption.None);}
		}
		public virtual string PuDate
		{
			get {return puDate;}
// 			set {puDate = ValidateDateTimeString("仕入日", value , true);} //K24546
			set {puDate = ValidateDateTimeString(MultiLanguage.Get("SC_CS000806"), value , true);}
		}
// 管理番号 K16590 From
		public virtual string DealDate
		{
			get {return dealDate;}
// 			set {dealDate = ValidateDateTimeString("取引日", value, true);} //K24546
			set {dealDate = ValidateDateTimeString(MultiLanguage.Get("SC_CS000939"), value, true);}
		}
// 管理番号 K16590 To
		public virtual string PoNo
		{
			get {return poNo;}
// 			set {poNo = ValidateString("発注番号", value , false, 10, CheckOption.SingleByte);} //K24546
			set {poNo = ValidateString(MultiLanguage.Get("SC_CS001795"), value , false, 10, CheckOption.SingleByte);}
		}
		public virtual string RcptNo
		{
			get {return rcptNo;}
// 			set {rcptNo = ValidateString("入荷番号", value , false, 10, CheckOption.SingleByte);} //K24546
			set {rcptNo = ValidateString(MultiLanguage.Get("SC_CS001626"), value , false, 10, CheckOption.SingleByte);}
		}
		public virtual string PuModeType
		{
			get {return puModeType;}
// 			set {puModeType = ValidateChoiceString("仕入形態区分", value , new String[] {"", "1", "2", "4"});} //K24546
			set {puModeType = ValidateChoiceString(MultiLanguage.Get("SC_CS003648"), value , new String[] {"", "1", "2", "4"});}
		}

// 管理番号K27058 From
		public string PuModeTypeDtilCode
		{
			get { return puModeTypeDtilCode; }
			// 仕入形態区分明細コード
			set { puModeTypeDtilCode = ValidateString(MultiLanguage.Get("SC_CS006323"), value, true, 2); }
		}
// 管理番号K27058 To

		public virtual string RefPuNo
		{
			get {return refPuNo;}
// 			set {refPuNo = ValidateString("参照仕入番号", value , false, 10, CheckOption.SingleByte);} //K24546
			set {refPuNo = ValidateString(MultiLanguage.Get("SC_CS003602"), value , false, 10, CheckOption.SingleByte);}
		}
// 管理番号 B21177 From
		public virtual string RefPuDate
		{
			get {return refPuDate;}
// 			set {refPuDate = ValidateDateTimeString("参照仕入日", value , true);} //K24546
			set {refPuDate = ValidateDateTimeString(MultiLanguage.Get("SC_CS003601"), value , true);}
		}
// 管理番号 B21177 To
		public virtual string CurCode
		{
			get {return curCode;}
// 			set {curCode = ValidateString("通貨", value , true, 3, CheckOption.SingleByte);} //K24546
			set {curCode = ValidateString(MultiLanguage.Get("SC_CS001520"), value , true, 3, CheckOption.SingleByte);}
		}
		// 管理番号 B14477 From
		public virtual string KeyCurCode
		{
			get {return keyCurCode;}
// 			set {keyCurCode = ValidateString("基軸通貨", value , true, 3, CheckOption.SingleByte);} //K24546
			set {keyCurCode = ValidateString(MultiLanguage.Get("SC_CS003119"), value , true, 3, CheckOption.SingleByte);}
		}
		// 管理番号 B14477 To
		public virtual string ExchangeType
		{
			get {return exchangeType;}
			//set {exchangeType = ValidateChoiceString("為替区分", value , new String[] {"1", "2", "3"});}
// 			set {exchangeType = ValidateString("為替区分", value ,false, 1, CheckOption.SingleByte);} //K24546
			set {exchangeType = ValidateString(MultiLanguage.Get("SC_CS000317"), value ,false, 1, CheckOption.SingleByte);}
		}
		public virtual string ExchangeRezNo
		{
			get {return exchangeRezNo;}
// 			set {exchangeRezNo = ValidateString("為替予約番号", value , false, 10, CheckOption.SingleByte);} //K24546
			set {exchangeRezNo = ValidateString(MultiLanguage.Get("SC_CS000319"), value , false, 10, CheckOption.SingleByte);}
		}
		public virtual string Rate
		{
			get {return rate;}
// 			set {rate = ValidateDecimalString("レート", value , true, false, 6, 2);} //K24546
			set {rate = ValidateDecimalString(MultiLanguage.Get("SC_CS000271"), value , true, false, 6, 2);}
		}
		public virtual string DeptCode
		{
			get {return deptCode;}
// 			set {deptCode = ValidateString("部門", value , true, 10, CheckOption.SingleByte);} //K24546
			set {deptCode = ValidateString(MultiLanguage.Get("SC_CS001858"), value , true, 10, CheckOption.SingleByte);}
		}
		public virtual string DeptShortName
		{
			get {return deptShortName;}
			set {deptShortName = value;}
		}
		public virtual string OriginDeptCode
		{
			get {return originDeptCode;}
			set {originDeptCode = value;}
		}
		public virtual string OldDeptCode
		{
			get {return oldDeptCode;}
			set {oldDeptCode = value;}
		}
		public virtual string OrgChangeId
		{
			get {return orgChangeId;}
			//set {orgChangeId = ValidateDecimalString("組織変更ID", value , false, true, 10, 0);}
			set {orgChangeId = value;}
		}
		public virtual string DataMigrateDatetime
		{
			get {return dataMigrateDatetime;}
			set {dataMigrateDatetime = value;}
		}
		public virtual string EmpCode
		{
			get {return empCode;}
// 			set {empCode = ValidateString("社員", value , true, 10, CheckOption.SingleByte);} //K24546
			set {empCode = ValidateString(MultiLanguage.Get("SC_CS000891"), value , true, 10, CheckOption.SingleByte);}
		}
		public virtual string ProjCode
		{
			get {return projCode;}
// 管理番号 K16588 From
//			set {projCode = ValidateString("プロジェクト", value , false, 8, CheckOption.SingleByte);}
// 			set {projCode = ValidateString("プロジェクト", value , false, 20, CheckOption.SingleByte);} //K24546
			set {projCode = ValidateString(MultiLanguage.Get("SC_CS000232"), value , false, 20, CheckOption.SingleByte);}
// 管理番号 K16588 To
		}
		public virtual string ProjSbno
		{
			get {return projSbno;}
// 			set {projSbno = ValidateString("プロジェクト", value , false, 2, CheckOption.SingleByte);} //K24546
			set {projSbno = ValidateString(MultiLanguage.Get("SC_CS000232"), value , false, 2, CheckOption.SingleByte);}
		}
		public virtual string SuplCode
		{
			get {return suplCode;}
// 			set {suplCode = ValidateString("仕入先", value , true, 8, CheckOption.SingleByte);} //K24546
			set {suplCode = ValidateString(MultiLanguage.Get("SC_CS000784"), value , true, 8, CheckOption.SingleByte);}
		}
		public virtual string SuplSbno
		{
			get {return suplSbno;}
// 			set {suplSbno = ValidateString("仕入先", value , true, 2, CheckOption.SingleByte);} //K24546
			set {suplSbno = ValidateString(MultiLanguage.Get("SC_CS000784"), value , true, 2, CheckOption.SingleByte);}
		}
		public virtual string TempCodeFlg
		{
			get {return tempCodeFlg;}
// 			set {tempCodeFlg = ValidateChoiceString("雑コードフラグ", value , new String[] {"0", "1"});} //K24546
			set {tempCodeFlg = ValidateChoiceString(MultiLanguage.Get("SC_CS003580"), value , new String[] {"0", "1"});}
		}
		public virtual string SuplName
		{
			get {return suplName;}
// 管理番号 B24264 From
//			set {suplName = ValidateString("仕入先名", value , false, 50, CheckOption.None);}
//			set {suplName = ValidateString("仕入先名", value , true, 50, CheckOption.None);} //K24546
			set {suplName = ValidateString(MultiLanguage.Get("SC_CS000798"), value , true, 50, CheckOption.None);}
// 管理番号 B24264 To
		}
		public virtual string SuplShortName
		{
			get {return suplShortName;}
// 管理番号 B24264 From
//			set {suplShortName = ValidateString("仕入先略名", value , false, 10, CheckOption.None);}
//			set { suplShortName = ValidateString("仕入先略名", value, true, 10, CheckOption.None); } //K24546
			set {suplShortName = ValidateString(MultiLanguage.Get("SC_CS000799"), value, true, 10, CheckOption.None);}
// 管理番号 B24264 To
		}
		public virtual string SuplDeptName1
		{
			get {return suplDeptName1;}
// 			set {suplDeptName1 = ValidateString("仕入先部門名1", value , false, 25, CheckOption.None);} //K24546
			set {suplDeptName1 = ValidateString(MultiLanguage.Get("SC_CS003703"), value , false, 25, CheckOption.None);}
		}
		public virtual string SuplDeptName2
		{
			get {return suplDeptName2;}
// 			set {suplDeptName2 = ValidateString("仕入先部門名2", value , false, 25, CheckOption.None);} //K24546
			set {suplDeptName2 = ValidateString(MultiLanguage.Get("SC_CS003705"), value , false, 25, CheckOption.None);}
		}
		public virtual string SuplCountryCode
		{
			get {return suplCountryCode;}
// 			set {suplCountryCode = ValidateString("仕入先国", value , false, 3, CheckOption.SingleByte);} //K24546
			set {suplCountryCode = ValidateString(MultiLanguage.Get("SC_CS003681"), value , false, 3, CheckOption.SingleByte);}
		}
		public virtual string SuplZip
		{
			get {return suplZip;}
// 			set {suplZip = ValidateString("仕入先郵便番号", value , false, 10, CheckOption.None);} //K24546
			set {suplZip = ValidateString(MultiLanguage.Get("SC_CS003709"), value , false, 10, CheckOption.None);}
		}
		public virtual string SuplState
		{
			get {return suplState;}
// 			set {suplState = ValidateString("仕入先都道府県名", value , false, 15, CheckOption.None);} //K24546
			set {suplState = ValidateString(MultiLanguage.Get("SC_CS003699"), value , false, 15, CheckOption.None);}
		}
		public virtual string SuplCity
		{
			get {return suplCity;}
// 			set {suplCity = ValidateString("仕入先市区町村名", value , false, 15, CheckOption.None);} //K24546
			set {suplCity = ValidateString(MultiLanguage.Get("SC_CS003683"), value , false, 15, CheckOption.None);}
		}
		public virtual string SuplAddress1
		{
			get {return suplAddress1;}
// 			set {suplAddress1 = ValidateString("仕入先町域名", value , false, 30, CheckOption.None);} //K24546
			set {suplAddress1 = ValidateString(MultiLanguage.Get("SC_CS003697"), value , false, 30, CheckOption.None);}
		}
		public virtual string SuplAddress2
		{
			get {return suplAddress2;}
// 			set {suplAddress2 = ValidateString("仕入先ビル名", value , false, 30, CheckOption.None);} //K24546
			set {suplAddress2 = ValidateString(MultiLanguage.Get("SC_CS003677"), value , false, 30, CheckOption.None);}
		}
		public virtual string SuplPhone
		{
			get {return suplPhone;}
// 			set {suplPhone = ValidateString("仕入先電話番号", value , false, 15, CheckOption.None);} //K24546
			set {suplPhone = ValidateString(MultiLanguage.Get("SC_CS003698"), value , false, 15, CheckOption.None);}
		}
		public virtual string SuplFax
		{
			get {return suplFax;}
// 			set {suplFax = ValidateString("仕入先FAX番号", value , false, 15, CheckOption.None);} //K24546
			set {suplFax = ValidateString(MultiLanguage.Get("SC_CS003669"), value , false, 15, CheckOption.None);}
		}
		public virtual string SuplUserName
		{
			get {return suplUserName;}
// 			set {suplUserName = ValidateString("仕入先担当者名", value , false, 10, CheckOption.None);} //K24546
			set {suplUserName = ValidateString(MultiLanguage.Get("SC_CS003696"), value , false, 10, CheckOption.None);}
		}
		public virtual string AcNo
		{
			get {return acNo;}
// 管理番号 B20392 From
//			set {acNo = ValidateString("口座番号", value , false, 20, CheckOption.None);}
// 			set {acNo = ValidateString("口座番号", value , false, 20, CheckOption.SingleByte);} //K24546
			set {acNo = ValidateString(MultiLanguage.Get("SC_CS000604"), value , false, 20, CheckOption.SingleByte);}
// 管理番号 B20392 To
		}
		public virtual string AcHolder
		{
			get {return acHolder;}
// 管理番号 B22031 From
////管理番号B16832 From
////			set {acHolder = ValidateString("口座名義人", value , false, 50, CheckOption.None);}
//			set {acHolder = ValidateString("口座名義人", value , false, 50, CheckOption.JBAAcHolder);}
////管理番号B16832 To
			set
			{
				if (this.bankCountryCode == this.japanCountryCode)
				{
// 					acHolder = ValidateString("口座名義人", value, false, 50, CheckOption.JBAAcHolder); //K24546
// 管理番号B27219 From
//					acHolder = ValidateString(MultiLanguage.Get("SC_CS000605"), value, false, 50, CheckOption.JBAAcHolder);
					acHolder = ValidateString(MultiLanguage.Get("SC_CS000605"), value, false, 48, CheckOption.JBAAcHolder);
// 管理番号B27219 To
				}
				else
				{
// 					acHolder = ValidateString("口座名義人", value, false, 50, CheckOption.None); //K24546
					acHolder = ValidateString(MultiLanguage.Get("SC_CS000605"), value, false, 50, CheckOption.None);
				}
			}
// 管理番号 B22031 To
		}
		public virtual string AcType
		{
			get {return acType;}
// 			set {acType = ValidateChoiceString("口座区分", value , new String[] {"", "B", "A", "P"});} //K24546
			set {acType = ValidateChoiceString(MultiLanguage.Get("SC_CS000602"), value , new String[] {"", "B", "A", "P"});}
		}
		public virtual string BankAcType
		{
			get {return bankAcType;}
// 			set {bankAcType = ValidateChoiceString("銀行口座区分", value , new String[] {"", "O", "C"});} //K24546
			set {bankAcType = ValidateChoiceString(MultiLanguage.Get("SC_CS003198"), value , new String[] {"", "O", "C"});}
		}
		public virtual string BankCountryCode
		{
			get {return bankCountryCode;}
			set {bankCountryCode = value;}
		}
		public virtual string BankCode
		{
			get {return bankCode;}
// 			set {bankCode = ValidateString("銀行コード", value , false, 20, CheckOption.SingleByte);} //K24546
			set {bankCode = ValidateString(MultiLanguage.Get("SC_CS000507"), value , false, 20, CheckOption.SingleByte);}
		}
		public virtual string BankBranchCode
		{
			get {return bankBranchCode;}
// 			set {bankBranchCode = ValidateString("支店コード", value , false, 20, CheckOption.SingleByte);} //K24546
			set {bankBranchCode = ValidateString(MultiLanguage.Get("SC_CS000843"), value , false, 20, CheckOption.SingleByte);}
		}
		public virtual string RemitFeeType
		{
			get {return remitFeeType;}
// 			set {remitFeeType = ValidateChoiceString("振込手数料区分", value , new String[] {"", "1", "2"});} //K24546
			set {remitFeeType = ValidateChoiceString(MultiLanguage.Get("SC_CS004390"), value , new String[] {"", "1", "2"});}
		}
		public virtual string RemitMthd1DealType
		{
			get {return remitMthd1DealType;}
// 			set {remitMthd1DealType = ValidateChoiceString("振込方法1扱い区分", value , new String[] {"", "1", "2"});} //K24546
			set {remitMthd1DealType = ValidateChoiceString(MultiLanguage.Get("SC_CS004392"), value , new String[] {"", "1", "2"});}
		}
		public virtual string RemitMthd2Type
		{
			get {return remitMthd2Type;}
// 			set {remitMthd2Type = ValidateChoiceString("振込方法2区分", value , new String[] {"", "1", "2", "3", "4"});} //K24546
			set {remitMthd2Type = ValidateChoiceString(MultiLanguage.Get("SC_CS004393"), value , new String[] {"", "1", "2", "3", "4"});}
		}
		public virtual string DeliType
		{
			get {return deliType;}
// 			set {deliType = ValidateChoiceString("納入区分", value , new String[] {"W", "D"});} //K24546
			set {deliType = ValidateChoiceString(MultiLanguage.Get("SC_CS001672"), value , new String[] {"W", "D"});}
		}
		public virtual string WhCode
		{
			get {return whCode;}
// 			set {whCode = ValidateString("倉庫", value , false, 5, CheckOption.SingleByte);} //K24546
			set {whCode = ValidateString(MultiLanguage.Get("SC_CS001387"), value , false, 5, CheckOption.SingleByte);}
		}
		public virtual string DeliCustCode
		{
			get {return deliCustCode;}
// 			set {deliCustCode = ValidateString("納入先", value , false, 8, CheckOption.SingleByte);} //K24546
			set {deliCustCode = ValidateString(MultiLanguage.Get("SC_CS001673"), value , false, 8, CheckOption.SingleByte);}
		}
		public virtual string DeliCustSbno
		{
			get {return deliCustSbno;}
// 			set {deliCustSbno = ValidateString("納入先", value , false, 2, CheckOption.SingleByte);} //K24546
			set {deliCustSbno = ValidateString(MultiLanguage.Get("SC_CS001673"), value , false, 2, CheckOption.SingleByte);}
		}
		public virtual string DeliPlaceCode
		{
			get {return deliPlaceCode;}
// 			set {deliPlaceCode = ValidateString("受渡場所", value , false, 2, CheckOption.SingleByte);} //K24546
			set {deliPlaceCode = ValidateString(MultiLanguage.Get("SC_CS001000"), value , false, 2, CheckOption.SingleByte);}
		}
		public virtual string DeliPlaceName
		{
			get {return deliPlaceName;}
// 			set {deliPlaceName = ValidateString("受渡場所名", value , false, 30, CheckOption.None);} //K24546
			set {deliPlaceName = ValidateString(MultiLanguage.Get("SC_CS001003"), value , false, 30, CheckOption.None);}
		}
		public virtual string DeliPlaceCountryCode
		{
			get {return deliPlaceCountryCode;}
			//set {deliPlaceCountryCode = ValidateString("受渡場所国コード", value , false, 3, CheckOption.SingleByte);}
			set {deliPlaceCountryCode = value;}
		}
		public virtual string DeliPlaceZip
		{
			get {return deliPlaceZip;}
// 			set {deliPlaceZip = ValidateString("受渡場所郵便番号", value , false, 10, CheckOption.None);} //K24546
			set {deliPlaceZip = ValidateString(MultiLanguage.Get("SC_CS004055"), value , false, 10, CheckOption.None);}
		}
		public virtual string DeliPlaceState
		{
			get {return deliPlaceState;}
// 			set {deliPlaceState = ValidateString("受渡場所都道府県名", value , false, 15, CheckOption.None);} //K24546
			set {deliPlaceState = ValidateString(MultiLanguage.Get("SC_CS004053"), value , false, 15, CheckOption.None);}
		}
		public virtual string DeliPlaceCity
		{
			get {return deliPlaceCity;}
// 			set {deliPlaceCity = ValidateString("受渡場所市区町村名", value , false, 15, CheckOption.None);} //K24546
			set {deliPlaceCity = ValidateString(MultiLanguage.Get("SC_CS004048"), value , false, 15, CheckOption.None);}
		}
		public virtual string DeliPlaceAddress1
		{
			get {return deliPlaceAddress1;}
// 			set {deliPlaceAddress1 = ValidateString("受渡場所町域名", value , false, 30, CheckOption.None);} //K24546
			set {deliPlaceAddress1 = ValidateString(MultiLanguage.Get("SC_CS004050"), value , false, 30, CheckOption.None);}
		}
		public virtual string DeliPlaceAddress2
		{
			get {return deliPlaceAddress2;}
// 			set {deliPlaceAddress2 = ValidateString("受渡場所ビル名", value , false, 30, CheckOption.None);} //K24546
			set {deliPlaceAddress2 = ValidateString(MultiLanguage.Get("SC_CS004045"), value , false, 30, CheckOption.None);}
		}
		public virtual string DeliPlacePhone
		{
			get {return deliPlacePhone;}
// 			set {deliPlacePhone = ValidateString("受渡場所電話番号", value , false, 15, CheckOption.PhoneNo);} //K24546
			set {deliPlacePhone = ValidateString(MultiLanguage.Get("SC_CS004051"), value , false, 15, CheckOption.PhoneNo);}
		}
		public virtual string DeliPlaceFax
		{
			get {return deliPlaceFax;}
// 			set {deliPlaceFax = ValidateString("受渡場所FAX番号", value , false, 15, CheckOption.PhoneNo);} //K24546
			set {deliPlaceFax = ValidateString(MultiLanguage.Get("SC_CS004042"), value , false, 15, CheckOption.PhoneNo);}
		}
		public virtual string DeliPlaceUserName
		{
			get {return deliPlaceUserName;}
// 			set {deliPlaceUserName = ValidateString("受渡場所担当者名", value , false, 10, CheckOption.None);} //K24546
			set {deliPlaceUserName = ValidateString(MultiLanguage.Get("SC_CS004049"), value , false, 10, CheckOption.None);}
		}
		public virtual string DtType
		{
			get {return dtType;}
// 			set {dtType = ValidateChoiceString("取引条件区分", value , new String[] {"L", "E"});} //K24546
			set {dtType = ValidateChoiceString(MultiLanguage.Get("SC_CS003942"), value , new String[] {"L", "E"});}
		}
		public virtual string Dt1SttlMthdCode
		{
			get {return dt1SttlMthdCode;}
// 			set {dt1SttlMthdCode = ValidateString("取引条件1決済方法", value , false, 3, CheckOption.SingleByte);} //K24546
			set {dt1SttlMthdCode = ValidateString(MultiLanguage.Get("SC_CS003931"), value , false, 3, CheckOption.SingleByte);}
		}
		public virtual string Dt1BasisAmt
		{
			get {return dt1BasisAmt;}
// 			set {dt1BasisAmt = ValidateDecimalString("取引条件1基準金額", value , false, true, 12, 0);} //K24546
			set {dt1BasisAmt = ValidateDecimalString(MultiLanguage.Get("SC_CS003930"), value , false, true, 12, 0);}
		}
		public virtual string Dt2SttlMthdCode
		{
			get {return dt2SttlMthdCode;}
// 			set {dt2SttlMthdCode = ValidateString("取引条件2決済方法", value , false, 3, CheckOption.SingleByte);} //K24546
			set {dt2SttlMthdCode = ValidateString(MultiLanguage.Get("SC_CS003933"), value , false, 3, CheckOption.SingleByte);}
		}
		public virtual string Dt2Ratio
		{
			get {return dt2Ratio;}
// 			set {dt2Ratio = ValidateDecimalString("取引条件2比率", value , false, true, 3, 0);} //K24546
			set {dt2Ratio = ValidateDecimalString(MultiLanguage.Get("SC_CS003935"), value , false, true, 3, 0);}
		}
		public virtual string Dt3SttlMthdCode
		{
			get {return dt3SttlMthdCode;}
// 			set {dt3SttlMthdCode = ValidateString("取引条件3決済方法", value , false, 3, CheckOption.SingleByte);} //K24546
			set {dt3SttlMthdCode = ValidateString(MultiLanguage.Get("SC_CS003936"), value , false, 3, CheckOption.SingleByte);}
		}
		public virtual string DtSight
		{
			get {return dtSight;}
// 			set {dtSight = ValidateDecimalString("取引条件サイト", value , false, true, 3, 0);} //K24546
			set {dtSight = ValidateDecimalString(MultiLanguage.Get("SC_CS003939"), value , false, true, 3, 0);}
		}
		public virtual string DtCutoffCycleType
		{
			get {return dtCutoffCycleType;}
			set {dtCutoffCycleType = value;}
		}
		public virtual string CutoffDate
		{
			get {return cutoffDate;}
// 			set {cutoffDate = ValidateDateTimeString("締日", value , false);} //K24546
			set {cutoffDate = ValidateDateTimeString(MultiLanguage.Get("SC_CS001536"), value , false);}
		}
// 管理番号 B21977 From
		public virtual string CutoffFinDate
		{
			get {return cutoffFinDate;}
// 			set {cutoffFinDate = ValidateDateTimeString("締日", value , false);} //K24546
			set {cutoffFinDate = ValidateDateTimeString(MultiLanguage.Get("SC_CS001536"), value , false);}
		}
// 管理番号 B21977 To
		public virtual string PymtPlanDate
		{
			get {return pymtPlanDate;}
// 			set {pymtPlanDate = ValidateDateTimeString("支払期限", value , false);} //K24546
			set {pymtPlanDate = ValidateDateTimeString(MultiLanguage.Get("SC_CS000845"), value , false);}
		}
// 管理番号 K24789 From
//		public string CtaxTypeCode
//		{
//			get {return ctaxTypeCode;}
//			set {ctaxTypeCode = value;}
//		}
// 管理番号 K24789 To
		public string CtaxBuildupType
		{
			get {return ctaxBuildupType;}
			set {ctaxBuildupType = value;}
		}
		public string CtaxRoundType
		{
			get {return ctaxRoundType;}
			set {ctaxRoundType = value;}
		}
		// 管理番号 B13878 From
		public virtual string HoldFlg
		{
			get {return holdFlg;}
			set {holdFlg = value;}
		}
		// 管理番号 B13878 To
		public virtual string DtNote
		{
			get {return dtNote;}
// 			set {dtNote = ValidateString("取引条件表記", value , false, 50, CheckOption.None);} //K24546
			set {dtNote = ValidateString(MultiLanguage.Get("SC_CS003946"), value , false, 50, CheckOption.None);}
		}
		public virtual string DtCutoffDay
		{
			get {return dtCutoffDay;}
			set {dtCutoffDay = value;}
		}
		public virtual string DtTermMonthCnt
		{
			get {return dtTermMonthCnt;}
			set {dtTermMonthCnt = value;}
		}
		public virtual string DtTermDay
		{
			get {return dtTermDay;}
			set {dtTermDay = value;}
		}
// 管理番号 B22191 From
		public virtual string PoDate
		{
			get {return poDate;}
			set {poDate = value;}
		}
// 管理番号 B22191 To

// 管理番号K27441 From
		public string PoDeptCode
		{
			get { return poDeptCode; }
			set { poDeptCode = value; }
		}
// 管理番号K27441 To
		public virtual string SuplBillSlipNo
		{
			get {return suplBillSlipNo;}
// 			set {suplBillSlipNo = ValidateString("仕入先請求書番号", value , false, 15, CheckOption.None);} //K24546
			set {suplBillSlipNo = ValidateString(MultiLanguage.Get("SC_CS000791"), value , false, 15, CheckOption.None);}
		}
		public virtual string CanceledOrderFlg
		{
			get {return canceledOrderFlg;}
			set {canceledOrderFlg = value;}
		}
		public virtual string OverseasFlg
		{
			get {return overseasFlg;}
			set {overseasFlg = value;}
		}
		public virtual string TenorCode
		{
			get {return tenorCode;}
// 			set {tenorCode = ValidateString("建値", value , false, 3, CheckOption.SingleByte);} //K24546
			set {tenorCode = ValidateString(MultiLanguage.Get("SC_CS000537"), value , false, 3, CheckOption.SingleByte);}
		}
		public virtual string FmoneySttlPeriodSttMonth
		{
			get {return fmoneySttlPeriodSttMonth;}
// 			set {fmoneySttlPeriodSttMonth = ValidateMonthString("外貨決済期間開始月", value , false);} //K24546
			set {fmoneySttlPeriodSttMonth = ValidateMonthString(MultiLanguage.Get("SC_CS003088"), value , false);}
		}
		public virtual string FmoneySttlPeriodEndMonth
		{
			get {return fmoneySttlPeriodEndMonth;}
// 			set {fmoneySttlPeriodEndMonth = ValidateMonthString("外貨決済期間終了月", value , false);} //K24546
			set {fmoneySttlPeriodEndMonth = ValidateMonthString(MultiLanguage.Get("SC_CS003089"), value , false);}
		}
		public virtual string LcNo
		{
			get {return lcNo;}
// 			set {lcNo = ValidateString("LC番号", value , false, 16, CheckOption.None);} //K24546
			set {lcNo = ValidateString(MultiLanguage.Get("SC_CS002568"), value , false, 16, CheckOption.None);}
		}
		public virtual string RemarksCode
		{
			get {return remarksCode;}
// 			set {remarksCode = ValidateString("摘要", value , false, 3, CheckOption.SingleByte);} //K24546
			set {remarksCode = ValidateString(MultiLanguage.Get("SC_CS001539"), value , false, 3, CheckOption.SingleByte);}
		}
		public virtual string Remarks
		{
			get {return remarks;}
// 			set {remarks = ValidateString("摘要", value , false, 100, CheckOption.None);} //K24546
			set {remarks = ValidateString(MultiLanguage.Get("SC_CS001539"), value , false, 100, CheckOption.None);}
		}
		// 管理番号 B13798 From
		public virtual string AdminItem1
		{
			get {return adminItem1;}
			set {adminItem1 = value;}
		}
		public virtual string AdminItem2
		{
			get {return adminItem2;}
			set {adminItem2 = value;}
		}
		public virtual string AdminItem3
		{
			get {return adminItem3;}
			set {adminItem3 = value;}
		}
		// 管理番号 B13798 To

		// 管理番号 K20687 From
		public virtual string BookBasisType
		{
			get {return bookBasisType;}
// 			set {bookBasisType = ValidateChoiceString("計上基準区分", value , new String[] {"A", "S"});} //K24546
			set {bookBasisType = ValidateChoiceString(MultiLanguage.Get("SC_CS003226"), value , new String[] {"A", "S"});}
		}
		// 管理番号 K20687 To

// 管理番号K27058 From
		public string BookBasisTypeDtilCode
		{
			get { return bookBasisTypeDtilCode; }
			// 計上基準区分明細コード
			set { bookBasisTypeDtilCode = ValidateString(MultiLanguage.Get("SC_CS006317"), value, true, 2); }
		}
// 管理番号K27058 To

		public bool OutlandRemittanceFlg
		{
			get {return outlandRemittanceFlg;}
			set {outlandRemittanceFlg = value;}
		}
		public string InternationalItemNo
		{
			get {return internationalItemNo;}
// 			set {internationalItemNo = ValidateDecimalString("国際項目番号", value, false, false, 4, 0);} //K24546
			set {internationalItemNo = ValidateDecimalString(MultiLanguage.Get("SC_CS000640"), value, false, false, 4, 0);}
		}
		public string RemittancePurpose
		{
			get {return remittancePurpose;}
// 			set {remittancePurpose = ValidateString("送金目的", value, false, 20, CheckOption.EnglishName);} //K24546
			set {remittancePurpose = ValidateString(MultiLanguage.Get("SC_CS001419"), value, false, 20, CheckOption.EnglishName);}
		}
		public bool RemittanceAllowFlg
		{
			get {return remittanceAllowFlg;}
			set {remittanceAllowFlg = value;}
		}
		public string RemittanceAllowNo
		{
			get {return remittanceAllowNo;}
// 			set {remittanceAllowNo = ValidateString("送金許可番号", value, false, 10, CheckOption.EnglishName);} //K24546
			set {remittanceAllowNo = ValidateString(MultiLanguage.Get("SC_CS001418"), value, false, 10, CheckOption.EnglishName);}
		}
		public string RemittanceMessage
		{
			get {return remittanceMessage;}
// 			set {remittanceMessage = ValidateString("メッセージ", value, false, 60, CheckOption.EnglishName);} //K24546
			set {remittanceMessage = ValidateString(MultiLanguage.Get("SC_CS000266"), value, false, 60, CheckOption.EnglishName);}
		}
		public virtual string ApprovalStatusType
		{
			get {return approvalStatusType;}
// 			set {approvalStatusType = ValidateChoiceString("承認状況区分", value , new String[] {"1", "2", "3", "4", "5"});} //K24546
			set {approvalStatusType = ValidateChoiceString(MultiLanguage.Get("SC_CS004351"), value , new String[] {"1", "2", "3", "4", "5"});}
		}
		public virtual string PuSlipOutputFlg
		{
			get {return puSlipOutputFlg;}
			set {puSlipOutputFlg = value;}
		}
		public virtual string EtaxDtilAmtTtl
		{
			get {return etaxDtilAmtTtl;}
			set {etaxDtilAmtTtl = value;}
		}
		public virtual string ItaxDtilAmtTtl
		{
			get {return itaxDtilAmtTtl;}
			set {itaxDtilAmtTtl = value;}
		}
		public virtual string NtaxDtilAmtTtl
		{
			get {return ntaxDtilAmtTtl;}
			set {ntaxDtilAmtTtl = value;}
		}
		public virtual string EtaxAmtTtl
		{
			get {return etaxAmtTtl;}
			set {etaxAmtTtl = value;}
		}
		public virtual string ItaxAmtTtl
		{
			get {return itaxAmtTtl;}
			set {itaxAmtTtl = value;}
		}
		// 管理番号 B14028 From
		//		public virtual string GrandTtl
		//		{
		//			get {return grandTtl;}
		//			set {grandTtl = value;}
		//		}
		//		public virtual string KeyGrandTtl
		//		{
		//			get {return keyGrandTtl;}
		//			set {keyGrandTtl = value;}
		//		}
		// 管理番号 B14028 To
// 管理番号 K24789 From
		public virtual string AmtRoundType
		{
			get { return amtRoundType; }
			set { amtRoundType = value; }
		}
		public virtual decimal DtilAmtTtl
		{
			get { return dtilAmtTtl; }
		}
		public virtual decimal TaxableAmtTtl
		{
			get { return taxableAmtTtl; }
		}
		public virtual decimal TaxAmtTtl
		{
			get { return taxAmtTtl; }
		}
		public virtual decimal GrandTtl
		{
			get { return grandTtl; }
		}
		public virtual decimal KeyGrandTtl
		{
			get { return keyGrandTtl; }
		}
// 管理番号 K24789 To
		public virtual decimal KoAmt
		{
			get {return koAmt;}
			set {koAmt = value;}
		}
		public virtual string LastKoDate
		{
			get {return lastKoDate;}
			set {lastKoDate = value;}
		}
		public virtual string KoCompleteFlg
		{
			get {return koCompleteFlg;}
			set {koCompleteFlg = value;}
		}
// 管理番号 K16187 From
		public virtual decimal ApprovedKoAmt
		{
			get {return approvedKoAmt;}
			set {approvedKoAmt = value;}
		}
		public virtual string DtilKoFlg
		{
			get {return dtilKoFlg;}
			set {dtilKoFlg = value;}
		}
		public virtual string DeleteAllowFlg
		{
			get {return deleteAllowFlg;}
			set {deleteAllowFlg = value;}
		}
// 管理番号 K16187 To
		public virtual string ExchangeGainLossAmtTtl
		{
			get {return exchangeGainLossAmtTtl;}
			set {exchangeGainLossAmtTtl = value;}
		}
		public virtual string LastExchangeValuationDate
		{
			get {return lastExchangeValuationDate;}
			set {lastExchangeValuationDate = value;}
		}
		public virtual string ExchangeValuationFinFlg
		{
			get {return exchangeValuationFinFlg;}
			set {exchangeValuationFinFlg = value;}
		}
		public virtual string PymtNo
		{
			get {return pymtNo;}
			set {pymtNo = value;}
		}
		public virtual string CutoffFinFlg
		{
			get {return cutoffFinFlg;}
			set {cutoffFinFlg = value;}
		}
		public virtual string CancelFlg
		{
			get {return cancelFlg;}
			set {cancelFlg = value;}
		}
		public virtual string RedSlipFlg
		{
			get {return redSlipFlg;}
			set {redSlipFlg = value;}
		}
		public virtual string OriginPuNo
		{
			get {return originPuNo;}
			set {originPuNo = value;}
		}
		public virtual string OppositePuNo
		{
			get {return oppositePuNo;}
			set {oppositePuNo = value;}
		}
		public virtual string LastJrnlExecDatetime
		{
			get {return lastJrnlExecDatetime;}
			set {lastJrnlExecDatetime = value;}
		}
		public virtual string JrnlFinFlg
		{
			get {return jrnlFinFlg;}
			set {jrnlFinFlg = value;}
		}
		//仕入税区分コード
		public virtual string PuCtaxTypeCode
		{
			get {return puCtaxTypeCode;}
			set {puCtaxTypeCode = value;}
		}
		//仕入返品税区分コード
		public virtual string PuReturnCtaxTypeCode
		{
			get{return puReturnCtaxTypeCode;}
			set{puReturnCtaxTypeCode = value;}
		}
		//データ存在有無
		public bool ConsistsData
		{
			get {return consistsData;}
			set {consistsData = value;}
		}
		//エラー番号
		public Int32 ErrNo
		{
			get {return errNo;}
			set {errNo = value;}
		}
		public string Message
		{
			get {return message;}
			set {message = value;}
		}
		public string SoNo
		{
			get {return soNo;}
// 			set {soNo = ValidateString("受注番号", value , false, 10, CheckOption.None);} //K24546
			set {soNo = ValidateString(MultiLanguage.Get("SC_CS000993"), value , false, 10, CheckOption.None);}
		}
		public string SoDate
		{
			get {return soDate;}
// 			set {soDate = ValidateDateTimeString("受注日", value , false);} //K24546
			set {soDate = ValidateDateTimeString(MultiLanguage.Get("SC_CS000987"), value , false);}
		}
		public string CustName
		{
			get {return custName;}
// 			set {custName = ValidateString("得意先名", value , false, 50, CheckOption.None);} //K24546
			set {custName = ValidateString(MultiLanguage.Get("SC_CS001590"), value , false, 50, CheckOption.None);}
		}
		// 管理番号 B13500 From
		public string RcptInputNoNeedFlg
		{
			get {return rcptInputNoNeedFlg;}
			set {rcptInputNoNeedFlg = value;}
		}
		// 管理番号 B13500 To
		// 管理番号 B13569 From
		public string RefPoExchangeType
		{
			get {return refPoExchangeType;}
			set {refPoExchangeType = value;}
		}
		// 管理番号 B13569 To
		public virtual DataTable Dt
		{
			get {return dt;}
		}
		public virtual DataTable LotDt
		{
			get {return lotDt;}
			set {lotDt = value;}
		}
		//明細変更フラグ
		public virtual string DtilChangedFlg
		{
			get{return dtilChangedFlg;}
			set{dtilChangedFlg = value;}
		}
		//エラー番号
		public Int32 Ret
		{
			get {return ret;}
			set {ret = value;}
		}
		//エラーメッセージID
		public string ResultInformation
		{
			get {return resultInformation;}
			set {resultInformation = value;}
		}
		//エラーメッセージ以外で表示するメッセージが有るかないか
		public virtual string InformationFlg
		{
			get {return informationFlg;}
			set {informationFlg = value;}
		}
		//与信チェック
		public virtual string CreditConfirm
		{
			get {return creditConfirm;}
			set {creditConfirm = value;}
		}
		//商品規格使用区分
		public virtual string ProductSpecUseType
		{
			get {return productSpecUseType;}
			set {productSpecUseType = value;}
		}
		//規格1名称
		public virtual string ProdSpec1CodeTitle
		{
			get {return prodSpec1CodeTitle;}
			set {prodSpec1CodeTitle = value;}
		}
		//規格2名称
		public virtual string ProdSpec2CodeTitle
		{
			get {return prodSpec2CodeTitle;}
			set {prodSpec2CodeTitle = value;}
		}
		//自部門コード
		public virtual string LowerDeptCode
		{
			get {return lowerDeptCode;}
// 			set {lowerDeptCode = ValidateString("自部門", value , false, 10, CheckOption.SingleByte);} //K24546
			set {lowerDeptCode = ValidateString(MultiLanguage.Get("SC_CS003838"), value , false, 10, CheckOption.SingleByte);}
		}
		//行データの有無
		public virtual bool HasRows
		{
			get
			{
				int rows = Count;
				return rows > 0;
			}
		}
		//行データの件数
		public virtual int Count
		{
			get
			{
				int rowCount = 0;
				if(this.dt != null)
				{
					rowCount = this.dt.Rows.Count;
				}
				return rowCount;
			}
		}
		//有効行データ有無
		public virtual bool HasValidRows
		{
			get
			{
				int rows = ValidCount;
				return rows > 0 ;
			}
		}
		//有効行データ件数
		public virtual int ValidCount
		{
			get
			{
				int rowCount = 0;
				if(this.dt != null)
				{
					//DataRow[] Rows = this.dt.Select("ROW_STATE <> '" + RowState.Delete + "'");
					DataRow[] deleteRows = this.dt.Select(string.Empty, string.Empty, DataViewRowState.Deleted);
					rowCount = dt.Rows.Count - deleteRows.Length;
				}
				return rowCount;
			}
		}
		//新規行のLineID
		public virtual decimal NewRowLineID
		{
			get
			{
// 管理番号 B24051 From
//				decimal lineId = 0M;
//				if(this.Dt != null)
//				{
//					object maxLineID = this.dt.Compute("MAX(PU_LINE_ID)", string.Empty);
//					lineId = (maxLineID is decimal) ? ((decimal) maxLineID + 1M) : 1M;
//				}
//				return lineId;

				return maxLineID + 1M;
// 管理番号 B24051 To
			}
		}
// 管理番号 B24051 From
		//明細の最大LineIDを設定する
		public virtual decimal SetMaxLineID
		{
			set
			{
				maxLineID = value;
			}
		}
// 管理番号 B24051 To
		//仮データの存在有無
		public virtual bool IsExistsTemporary
		{
			get
			{
				bool result = false;
				if(this.dt != null)
				{
					DataRow[] Rows = this.dt.Select("ROW_STATE = '" + RowState.Temp + "'");
					result = Rows.Length > 0;
				}
				return result;
			}
		}
		public IF_SC_MS_OverseasDT[] Overseas
		{
			get{return overseas;}
		}
		//合計数量
		public virtual decimal SumPuQt
		{
			get
			{
				decimal redQt = 1;
				if(redSlipFlg == "1")
				{
					redQt = -1;
				}
				object o = this.dt.Compute("SUM([PU_QT])", "ROW_STATE<>'" + RowState.Temp + "'");
				return o is decimal ? (decimal)o * redQt : 0M;
			}
		}
		// 管理番号 B13500 From
		public virtual decimal TransitRcptQtTtl
		{
			get {return transitRcptQtTtl;}
			set {transitRcptQtTtl = value;}
		}
		// 管理番号 B13500 To
		// 管理番号 B14298 From
		public virtual bool PriceDecimalUseFlg
		{
			get {return priceDecimalUseFlg;}
			set {priceDecimalUseFlg = value;}		
		}
		public virtual string CurDigit
		{
			get {return curDigit;}
			set {curDigit = value;}		
		}
		// 管理番号 B14298 To
// 管理番号 B20818 From
		public DateTime UpdateDatetime
		{
			get {return updateDatetime;}
			set {updateDatetime = value;}
		}
		public DateTime RefUpdateDatetime
		{
			get {return refUpdateDatetime;}
			set {refUpdateDatetime = value;}
		}
// 管理番号 B20818 To
// 管理番号 K22205 From
        public virtual string InputEmpCode
        {
            get { return inputEmpCode;}
            set { inputEmpCode = value;}
        }
// 管理番号 K22205 To
// 管理番号 K22217 From
        public virtual string ApprovalPlanEmpCode
        {
            get { return approvalPlanEmpCode; }
            set { approvalPlanEmpCode = value; }
        }
        public virtual string ChangeApprovalRouteId
        {
            get { return changeApprovalRouteId; }
            set { changeApprovalRouteId = value; }
        }
// 管理番号 K22217 To
//管理番号 B22031 From
		public virtual string JapanCountryCode
		{
			get {return japanCountryCode;}
			set {japanCountryCode = value;}
		}
//管理番号 B22031 To
// 管理番号 K24278 From
		public virtual string ImposeFlg
		{
			get { return imposeFlg; }
			set { imposeFlg = value; }
		}
// 管理番号 K24278 To
// 管理番号 K25647 From
		public virtual byte PriceDecimalDigit        // 単価小数桁数
		{
			get { return priceDecimalDigit; }
			set { priceDecimalDigit = value; }
		}
		public virtual bool MyCompQtDecimalUseFlg
		{
			get { return myCompQtDecimalUseFlg; }
			set { myCompQtDecimalUseFlg = value; }
		}
// 管理番号 K25647 To
// 管理番号 K25679 From
		public virtual string PoAdminNo
		{
			get {return poAdminNo; }
			// SC_CS006200:発注管理番号
// 管理番号K27063 From
//			set { poAdminNo = ValidateString(MultiLanguage.Get("SC_CS006200"), value, false, 30, CheckOption.SingleByte); }
			set { poAdminNo = ValidateString(MultiLanguage.Get("SC_CS006200"), value, false, 30, CheckOption.None); }
// 管理番号K27063 To
		}
		public virtual string SuplSlipNo
		{
			get { return suplSlipNo; }
			set { suplSlipNo = value; }
		}
		public virtual string ProcType
		{
			get { return procType; }
			set { procType = value; }
		}
// 管理番号 K25679 To
// 管理番号 K25680 From
		public virtual string ImportSlipNo
		{
			get {return importSlipNo; }
			set { importSlipNo = value; }
		}
// 管理番号 K25680 To
// 管理番号B25370 From
		/// <summary>自身に対する返品伝票が存在するか</summary>
		public bool IsReferringSlipExists
		{
			get { return isReferringSlipExists; }
			set { isReferringSlipExists = value; }
		}
		/// <summary>仕入伝票を参照している諸掛伝票の件数</summary>
		public int ChargeCount
		{
			get { return chargeCount; }
			set { chargeCount = value; }
		}
// 管理番号B25370 To
// 管理番号K27057 From
		/// <summary>
		/// 汎用項目共通部品IF(ヘッダ)
		/// </summary
		public IF_CM_MS_CustomItem CustomItemHead
		{
			get { return customItemHead; }
			set { customItemHead = value; }
		}
		/// <summary>
		/// 汎用項目共通部品IF(明細)
		/// </summary
		public IF_CM_MS_CustomItem CustomItemDtil
		{
			get { return customItemDtil; }
			set { customItemDtil = value; }
		}
// 管理番号K27057 To
// 管理番号K27154 From
		public virtual string DealTypeCode
		{
			get {return dealTypeCode;}
			// 取引区分
			set {dealTypeCode = ValidateString(MultiLanguage.Get("SC_CS006354"), value, true, 3, CheckOption.SingleByte);}
		}
		// 管理番号K27154 To

		//课题2 Form
		/// <summary>
		/// 入力者名
		/// </summary>
		public virtual string InputEmpName
		{
			get { return inputEmpName; }
			set { inputEmpName = value; }
		}
		/// <summary>
		/// 消費税端数丸め区分
		/// </summary>
		public virtual string CtaxFractionRoundType
		{
			get { return ctaxFractionRoundType; }
			set { ctaxFractionRoundType = value; }
		}
		/// <summary>
		/// 運送業者コード
		/// </summary>
		public virtual string CarrierCode
		{
			get { return carrierCode; }
			set { carrierCode = value; }
		}
		//课题2 To
		#endregion

		#region メソッド
		#endregion
	}

	[Serializable()]
	public abstract class IF_SC_MM_05_RowData : IF_SC_MM_05_Base
	{
		#region Protected Fields
		protected DataTable lotDtBackUp	        = null;		// ロット明細(退避用)
		protected bool realStockMinusAllowFlg   = false;	// 自社マスタ・実在庫マイナス許可フラグ
		protected bool validStockMinusAllowFlg  = false;	// 自社マスタ・有効在庫マイナス許可フラグ
		protected bool myCompLotAdminFlg        = false;	// 自社マスタ・ロット管理フラグ
		protected int defaultRowCount           = 0;		// 初期行数
		protected bool isPoRef                  = false;	// 発注参照の有無
		protected bool keepCanceledOrderFlg		= false;	// 参照した伝票の出合フラグ保存用
		protected bool hasWarning				= false;	// ワーニングフラグ
		private readonly string DirectWhCode    = "99999";	// 直送倉庫コード

// 管理番号 B14307 From
		protected string curRoundType = string.Empty;
// 管理番号 B14307 To
// 管理番号 K24284 From
		private bool projInputScIndisFlg;
		private bool projImplementFlg;
// 管理番号 K24284 To
// 管理番号 B24264 From
		private Hashtable tempSuplHt = null;				// 雑仕入先
// 管理番号 B24264 To
// 管理番号 K24789 From
		private string checkFlg = string.Empty;
// 管理番号 K24789 To
		#endregion

		#region Constructors
		protected IF_SC_MM_05_RowData() : base()
		{
			//退避用の仕入ロット明細
			this.lotDtBackUp = this.lotDt.Clone();
		}
		#endregion

		#region virtual Properties
		public virtual DataTable LotDtBackUp
		{
			get{return lotDtBackUp;}
			set{lotDtBackUp = value;}
		}
		public virtual bool RealStockMinusAllowFlg
		{
			get{return realStockMinusAllowFlg;}
			set{realStockMinusAllowFlg = value;}
		}
		public virtual bool ValidStockMinusAllowFlg
		{
			get{return validStockMinusAllowFlg;}
			set{validStockMinusAllowFlg = value;}
		}
		public virtual bool MyCompLotAdminFlg
		{
			get {return myCompLotAdminFlg;}
			set {myCompLotAdminFlg = value;}
		}
		public virtual int DefaultRowCount
		{
			get {return defaultRowCount;}
			set {defaultRowCount = value;}
		}
		public virtual bool IsPoRef
		{
			get {return isPoRef;}
			set {isPoRef = value;}
		}
		public virtual bool KeepCanceledOrderFlg
		{
			get {return keepCanceledOrderFlg;}
			set {keepCanceledOrderFlg = value;}
		}
		public virtual bool HasWarning
		{
			get {return hasWarning;}
			set {hasWarning = value;}
		}
// 管理番号 B14307 From
		public string CurRoundType
		{
			get {return curRoundType;}
			set {curRoundType = value;}
		}
// 管理番号 B14307 To
// 管理番号 K24284 From
		public bool ProjInputScIndisFlg
		{
			get { return projInputScIndisFlg; }
			set { projInputScIndisFlg = value; }
		}
		public bool ProjImplementFlg
		{
			get { return projImplementFlg; }
			set { projImplementFlg = value; }
		}
// 管理番号 K24284 To
// 管理番号 B24264 From
		// 雑仕入先
		public Hashtable TempSuplHt
		{
			get { return tempSuplHt; }
			set { tempSuplHt = value; }
		}
// 管理番号 B24264 To
// 管理番号 K24789 From
		public string CheckFlg
		{
			get {return checkFlg;}
			set {checkFlg = value;}
		}
// 管理番号 K24789 To

		//指定された行のデータ
		public virtual IF_SC_MM_05_DetailRowData this[decimal lineId]
		{
			get
			{
				decimal id = lineId;
				IF_SC_MM_05_DetailRowData detail = new IF_SC_MM_05_DetailRowData();
				DataRow currentRow = this.dt.Rows.Find(lineId);
				if(currentRow!=null)
				{
					detail.SetPuLineId(currentRow["PU_LINE_ID"].ToString());
					detail.WhCode        = currentRow["WH_CODE"].ToString();
					detail.ProdCode      = currentRow["PROD_CODE"].ToString();
					detail.ProdSpec1Code = currentRow["PROD_SPEC_1_CODE"].ToString();
					detail.ProdSpec2Code = currentRow["PROD_SPEC_2_CODE"].ToString();
					detail.UnitCode      = currentRow["UNIT_CODE"].ToString();
					detail.LotAdminFlg   = currentRow["LOT_ADMIN_FLG"].ToString();
// 管理番号 K25322 From
					detail.LotStockValuationFlg	= currentRow["LOT_STOCK_VALUATION_FLG"].ToString();
// 管理番号 K25322 To
					detail.StockAdminFlg = currentRow["STOCK_ADMIN_FLG"].ToString();
					detail.SetPuQt(currentRow["PU_QT"].ToString(),detail.QtDecimalUseFlg=="1" ? true : false);
					detail.PoNo          = currentRow["PO_NO"].ToString();
					detail.SetPoLineId(currentRow["PO_LINE_ID"].ToString());
					detail.RcptNo        = currentRow["RCPT_NO"].ToString();
					detail.SetRcptLineId(currentRow["RCPT_LINE_ID"].ToString());
					detail.IsRcptExecute = currentRow["IS_RCPT_EXECUTE"].ToString();
				}
				return detail;
			}
		}
		#endregion

		#region override Properties
		public override string CutoffDate
		{
			//TODO 国内は必須
			get {return cutoffDate;}
			//set {cutoffDate = ValidateDateTimeString("締日", value , true);}
// 			set {cutoffDate = ValidateDateTimeString("締日", value , false);} //K24546
			set {cutoffDate = ValidateDateTimeString(MultiLanguage.Get("SC_CS001536"), value , false);}
		}
		public override string PymtPlanDate
		{
			//TODO 国内は必須
			get {return pymtPlanDate;}
			//set {pymtPlanDate = ValidateDateTimeString("支払期限", value , true);}
// 			set {pymtPlanDate = ValidateDateTimeString("支払期限", value , false);} //K24546
			set {pymtPlanDate = ValidateDateTimeString(MultiLanguage.Get("SC_CS000845"), value , false);}
		}
		#endregion

		#region Methods

		//行登録
// 管理番号K27057 From
//		// 管理番号 B11723・B11796 From
//		//		public bool InsertDetailRow(CommonData commonData, IF_SC_MM_05_DetailRowData detail)
//		public bool InsertDetailRow(CommonData commonData, IF_SC_MM_05_DetailRowData detail, double curDigit, string amtRoundType)
//			// 管理番号 B11723・B11796 To
		public bool InsertDetailRow(CommonData commonData, IF_SC_MM_05_DetailRowData detail, double curDigit, string amtRoundType, string tag = null)
// 管理番号K27057 To
		{
			bool IsNewRow = detail.PuLineId == this.NewRowLineID;
			string rowState = RowState.Temp;

			DeleteTempRow();
// 管理番号 B23238 From
			//行数チェックは新規行登録時・行挿入時に実施
			this.ValidateRowCount(commonData);
// 管理番号 B23238 To
			//行挿入時はノーチェック
			if (IsNewRow)
			{
				//ロット明細作成
				CreateLotDtil(commonData, detail);

				rowState = RowState.Create;
				this.ValidateRow(commonData, detail);
				if(this.HasErrors)
				{
					return false;
				}
			}

			DataRow insertRow = dt.NewRow();
			insertRow["PU_LINE_ID"]						= this.NewRowLineID;
// 			insertRow["WH_CODE"]						= ValidateStringForSqlParameter("倉庫コード", detail.WhCode, false, 5, CheckOption.SingleByte); //K24546
			insertRow["WH_CODE"]						= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS001389"), detail.WhCode, false, 5, CheckOption.SingleByte);
			insertRow["WH_SHORT_NAME"]					= detail.WhShortName;
// 			insertRow["PROD_CODE"]						= ValidateStringForSqlParameter("商品コード", detail.ProdCode, IsNewRow, 20, CheckOption.SingleByte); //K24546
			insertRow["PROD_CODE"]						= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS001158"), detail.ProdCode, IsNewRow, 20, CheckOption.SingleByte);
// 管理番号 B22497 From
//// 管理番号 B21416 From
////// 管理番号 B19475 From
//////			insertRow["PROD_PO_NAME"]					= ValidateStringForSqlParameter("商品発注名", detail.ProdPuName, IsNewRow, 50, CheckOption.None);
//////			insertRow["PROD_SHORT_NAME"]				= detail.ProdShortName;
////			
////			// もし商品略名が手で打ちかえられていたら商品名、商品略名を画面の値で上書きする
////			// ※ただし、手で入力された商品略名がNULLもしくは空文字の時は変更しない
////			if ((detail.ProdShortName != detail.ProdPuName) && (detail.ProdPuName.Length > 0))
////			{
////				insertRow["PROD_PO_NAME"]			= detail.ProdPuName;
////				insertRow["PROD_SHORT_NAME"]		= detail.ProdPuName;
////			}
////			else
////			{
////				insertRow["PROD_PO_NAME"]			= detail.ProdName;
////				insertRow["PROD_SHORT_NAME"]		= detail.ProdShortName;
////			}
////// 管理番号 B19475 To
////			insertRow["PROD_NAME"]						= detail.ProdName;
//			// もし商品略名が手で打ちかえられていたら商品名、商品略名を画面の値で上書きする
//			// ※ただし、手で入力された商品略名がNULLもしくは空文字の時は変更しない
//			if ((detail.ProdShortName != detail.ProdPuName) && (detail.ProdPuName.Length > 0))
//			{
//				insertRow["PROD_PO_NAME"]			= detail.ProdPuName;
//				insertRow["PROD_SHORT_NAME"]		= detail.ProdPuName;
//				insertRow["PROD_NAME"]				= detail.ProdPuName;
//			}
//			else
//			{
//				insertRow["PROD_PO_NAME"]			= detail.ProdName;
//				insertRow["PROD_SHORT_NAME"]		= detail.ProdShortName;
//				insertRow["PROD_NAME"]				= detail.ProdName;
//			}
//// 管理番号 B21416 To
			// もし商品略名が手で打ちかえられていたら商品名、商品略名を画面の値で上書きする
			if (detail.ProdShortName != detail.ProdPuName)
			{
// 				insertRow["PROD_PO_NAME"]					= ValidateStringForSqlParameter("商品名", detail.ProdPuName, IsNewRow, 50, CheckOption.None); //K24546
				insertRow["PROD_PO_NAME"]					= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS001198"), detail.ProdPuName, IsNewRow, 50, CheckOption.None);
				insertRow["PROD_SHORT_NAME"]				= detail.ProdPuName;
				insertRow["PROD_NAME"]						= detail.ProdPuName;
			}
			else
			{
// 				insertRow["PROD_PO_NAME"]			= ValidateStringForSqlParameter("商品正式名", detail.ProdName, IsNewRow, 50, CheckOption.None); //K24546
				insertRow["PROD_PO_NAME"]			= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS004325"), detail.ProdName, IsNewRow, 50, CheckOption.None);
// 				insertRow["PROD_SHORT_NAME"]		= ValidateStringForSqlParameter("商品略名", detail.ProdShortName, IsNewRow, 50, CheckOption.None); //K24546
				insertRow["PROD_SHORT_NAME"]		= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS001200"), detail.ProdShortName, IsNewRow, 50, CheckOption.None);
				insertRow["PROD_NAME"]				= detail.ProdName;
			}
// 管理番号 B22497 To
			insertRow["PROD_TYPE"]						= detail.ProdType;
			insertRow["DISP_CONTROL_TYPE"]				= detail.DispControlType;
			insertRow["STOCK_ADMIN_FLG"]				= detail.StockAdminFlg;
			insertRow["LOT_ADMIN_FLG"]					= detail.LotAdminFlg;
// 管理番号 K25322 From
			insertRow["LOT_STOCK_VALUATION_FLG"]		= detail.LotStockValuationFlg;
// 管理番号 K25322 To
			insertRow["QT_DECIMAL_USE_FLG"]				= detail.QtDecimalUseFlg;
			insertRow["CTAX_CALC_TYPE"]					= detail.CtaxCalcType;
			insertRow["CTAX_RATE_CODE"]					= detail.CtaxRateCode;
			insertRow["CTAX_RATE"]						= detail.CtaxRate;
// 管理番号 K24382 From
//			insertRow["PROD_SPEC_1_CODE"]				= ValidateStringForSqlParameter(this.prodSpec1CodeTitle, detail.ProdSpec1Code, false, 3, CheckOption.SingleByte);
			insertRow["PROD_SPEC_1_CODE"]				= ValidateStringForSqlParameter(this.prodSpec1CodeTitle, detail.ProdSpec1Code, false, 15, CheckOption.SingleByte);
// 管理番号 K24382 To
			insertRow["PROD_SPEC_1_NAME"]				= ValidateStringForSqlParameter(this.prodSpec1CodeTitle, detail.ProdSpec1Name, false, overseasFlg == "0" ? 3 : 10, CheckOption.None);
// 管理番号 K24382 From
//			insertRow["PROD_SPEC_2_CODE"]				= ValidateStringForSqlParameter(this.ProdSpec2CodeTitle, detail.ProdSpec2Code, false, 3, CheckOption.SingleByte);
			insertRow["PROD_SPEC_2_CODE"]				= ValidateStringForSqlParameter(this.ProdSpec2CodeTitle, detail.ProdSpec2Code, false, 15, CheckOption.SingleByte);
// 管理番号 K24382 To
			insertRow["PROD_SPEC_2_NAME"]				= ValidateStringForSqlParameter(this.ProdSpec2CodeTitle, detail.ProdSpec2Name, false, overseasFlg == "0" ? 3 : 10, CheckOption.None);
			insertRow["PU_PLAN_PRICE"]					= detail.PuPlanPrice;
			insertRow["STOCK_UNIT_STD_SELL_PRICE"]		= detail.StdSellPrice;
// 			insertRow["UNIT_CODE"]						= ValidateStringForSqlParameter("単位", detail.UnitCode, false, 3, CheckOption.SingleByte); //K24546
			insertRow["UNIT_CODE"]						= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS001456"), detail.UnitCode, false, 3, CheckOption.SingleByte);
			insertRow["UNIT_SHORT_NAME"]				= detail.UnitShortName;
			insertRow["PU_QT"]							= detail.PuQt;
// 管理番号 B22190 From
//			insertRow["INIT_PU_QT"]						= 99999M;
//			insertRow["UPPER_LIMIT_PU_QT"]				= 99999M;	//6桁の最大値
// 管理番号 K25647 From
//			insertRow["INIT_PU_QT"]						= 999999999.999M;
//			insertRow["UPPER_LIMIT_PU_QT"]				= 999999999.999M;	//DBが許容する最大値
			insertRow["INIT_PU_QT"]						= 999999999.9999M;
			insertRow["UPPER_LIMIT_PU_QT"]				= 999999999.9999M;	//DBが許容する最大値
// 管理番号 K25647 To
// 管理番号 B22190 To
			insertRow["VALID_QT"]						= detail.ValidQt;
			insertRow["STOCK_UNIT_PU_QT"]				= detail.PuQt * detail.IncludeQt;
			insertRow["STOCK_UNIT_PO_PU_QT"]			= 0M;
			insertRow["STOCK_UNIT_PO_ALLOC_PU_QT"]		= 0M;
			insertRow["PU_PRICE"]						= detail.PuPrice;
			insertRow["INIT_PU_PRICE"]					= detail.InitPuPrice;
			insertRow["DISC_FLG"]						= detail.DiscFlg;
			// 管理番号 B13878 From
			insertRow["PRICE_UNDECIDED_FLG"]			= detail.PriceUndecidedFlg;
			// 管理番号 B13878 To
// 			insertRow["LINE_REMARKS_CODE"]				= ValidateStringForSqlParameter("行摘要コード", detail.LineRemarksCode, false, 3, CheckOption.SingleByte); //K24546
			insertRow["LINE_REMARKS_CODE"]				= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS003416"), detail.LineRemarksCode, false, 3, CheckOption.SingleByte);
// 			insertRow["LINE_REMARKS"]					= ValidateStringForSqlParameter("行摘要", detail.LineRemarks, false, 30, CheckOption.None); //K24546
			insertRow["LINE_REMARKS"]					= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS003415"), detail.LineRemarks, false, 30, CheckOption.None);
// 管理番号K27525 From
			// 帳簿控除理由コード
			insertRow["BOOK_DEDUCTION_REASON_CODE"]		= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS006633"), detail.BookDeductionReasonCode, false, 2, CheckOption.SingleByte);
			insertRow["BOOK_DEDUCTION_REASON_NAME"]		= detail.BookDeductionReasonName;
// 管理番号K27525 To
			insertRow["INCLUDE_QT"]						= detail.IncludeQt;
			insertRow["DTIL_AMT"]						= 0M;
			insertRow["ETAX_AMT"]						= 0M;
			insertRow["ITAX_AMT"]						= 0M;
			insertRow["PRICE_UPDATE_FLG"]				= detail.PriceUpdateFlg;
// 管理番号 K24789 From
			insertRow["CTAX_TYPE_CODE"]					= detail.CtaxTypeCode;
			insertRow["TAXINFO_CHG_FLG"]				= detail.TaxInfoChgFlg;
// 管理番号 K24789 To

// 管理番号 B14307 From
			//insertRow["PU_MONEY"]						= Round.GetRound(commonData, detail.PuQt * detail.PuPrice, curDigit, amtRoundType);

// 管理番号 K24789 From
//// 管理番号 K24278 From
////			decimal dtilAmt = Round.GetRound(commonData, detail.PuQt * detail.PuPrice, curDigit, amtRoundType);
//			decimal dtilAmt = 0;
//			if (this.imposeFlg == "0" && detail.CtaxCalcType == "I")
//			{
//				decimal itaxAmt	= CalcCtax.GetCalcCtax(commonData, detail.CtaxCalcType, detail.CtaxRate, curDigit, detail.PuQt * detail.PuPrice, this.ctaxRoundType);
//				dtilAmt			= Round.GetRound(commonData, detail.PuQt * detail.PuPrice - itaxAmt, curDigit, amtRoundType);
//			}
//			else
//			{
//				dtilAmt			= Round.GetRound(commonData, detail.PuQt * detail.PuPrice, curDigit, amtRoundType);
//			}
//// 管理番号 K24278 To
			decimal dtilAmt	= Round.GetRound(commonData, detail.PuQt * detail.PuPrice, curDigit, amtRoundType);
// 管理番号 K24789 To
			decimal totalDtilAmt = detail.CtaxCalcType.Equals("E") ? dtilAmt * (1M + detail.CtaxRate / 100M) : dtilAmt;
			decimal curRate = (rate.Length != 0) ? decimal.Parse(rate) : 1M;
			double keyDecimalDigit	= double.Parse(Cur.GetDecimalDigit(commonData, keyCurCode));
			decimal keyGrandTotal	= ForeignCurConv.GetForeignCurConv(commonData, keyCurCode, curCode, keyCurCode, totalDtilAmt, curRate, curRoundType);

			if (totalDtilAmt  >= 100000000000M || 100000000000M < keyGrandTotal)
			{
// 				AddErrorMessage(AllegroMessage.S10015("仕入金額")); //K24546
				AddErrorMessage(AllegroMessage.S10015(MultiLanguage.Get("SC_CS000775")));
			}
			else
			{
				insertRow["PU_MONEY"] = dtilAmt;
			}	


// 管理番号 B14307 To


			insertRow["PROD_NAME_CORRECTION_FLG"]		= detail.AllowProdName;
			insertRow["PROD_EDIT_FLG"]					= detail.ProdEditFlg;
			insertRow["IS_RCPT_EXECUTE"]				= "0";
			insertRow["MULTI_LOT_FLG"]					= detail.MultLotFlg;
			insertRow["RCPT_INPUT_NO_NEED_FLG"]			= detail.RcptInputNoNeedFlg;
			insertRow["ROW_STATE"]						= rowState;
// 管理番号K27057 From
			customItemDtil.SetDataRow(insertRow, "CUSTOM_ITEM_TAG", tag);
// 管理番号K27057 To

			if(HasErrors)
			{
				this.RollBack(false);
				return false;
			}

			if(IsNewRow)
			{
				//数量チェック時に必要なパラメータの設定
// 管理番号 K25647 From
//// 管理番号 B22190 From
////				detail.InitQt = 99999M;
//				detail.InitQt = 999999999.999M;
//// 管理番号 B22190 To
				detail.InitQt = 999999999.9999M;
// 管理番号 K25647 To
				detail.UpperLimitPuQt = (decimal) insertRow["UPPER_LIMIT_PU_QT"];
				detail.StockUnitPoPuQt = (decimal) insertRow["STOCK_UNIT_PO_PU_QT"];
				detail.IsRcptExecute = "0";

				//数量チェック
				bool result = this.ValidateRowQt(commonData, detail);
				if(!result) return false;

				dt.Rows.Add(insertRow);
			}
			else
			{
				int lineID = int.Parse(detail.PuLineId.ToString());
				dt.Rows.InsertAt(insertRow, lineID);
			}

			//更新確定
			this.SetLineNo();
// 管理番号 B22792 From
//			this.Commit();
			//行挿入時はlotDtBackUpの内容を更新しない
			if (IsNewRow)
			{
				this.Commit();
// 管理番号 B24051 From
				this.SetMaxLineID = this.NewRowLineID;								// 行登録時、現在の最大行IDを１つ繰り上げる
// 管理番号 B24051 To
			}
			else
			{
				this.CommitI();
			}
// 管理番号 B22792 To

			return true;
		}

		//行更新
// 管理番号K27057 From
//		// 管理番号 B11723・B11796 From
//		//		public bool EditDetailRow(CommonData commonData, IF_SC_MM_05_DetailRowData detail)
//		public bool EditDetailRow(CommonData commonData, IF_SC_MM_05_DetailRowData detail, double curDigit, string amtRoundType)// 管理番号 B11723・B11796 To
		public bool EditDetailRow(CommonData commonData, IF_SC_MM_05_DetailRowData detail, double curDigit, string amtRoundType, string tag = null)
// 管理番号K27057 To
		{
			bool result = false;
			string state	= string.Empty;
			DataRow editedRow;

			//ロット明細作成
			CreateLotDtil(commonData, detail);

			//99件、存在チェック
			this.ValidateRow(commonData, detail);
			if(this.HasErrors) return false;

			//編集
			editedRow = this.dt.Rows.Find(detail.PuLineId);
			if (editedRow != null)
			{
				state = editedRow["ROW_STATE"].ToString();
				editedRow.BeginEdit();
// 				editedRow["WH_CODE"]					= ValidateStringForSqlParameter("倉庫コード", detail.WhCode, false, 5, CheckOption.SingleByte); //K24546
				editedRow["WH_CODE"]					= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS001389"), detail.WhCode, false, 5, CheckOption.SingleByte);
				editedRow["WH_SHORT_NAME"]				= detail.WhShortName;
// 				editedRow["PROD_CODE"]					= ValidateStringForSqlParameter("商品コード", detail.ProdCode, true, 20, CheckOption.SingleByte); //K24546
				editedRow["PROD_CODE"]					= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS001158"), detail.ProdCode, true, 20, CheckOption.SingleByte);
// 管理番号 B22497 From
//// 管理番号 B21416 From
////// 管理番号 B19475 From
//////				editedRow["PROD_PO_NAME"]				= ValidateStringForSqlParameter("商品発注名", detail.ProdPuName, true, 50, CheckOption.None);
//////				editedRow["PROD_SHORT_NAME"]			= detail.ProdShortName;
////// 管理番号 B22105 From				
//////				// もし商品略名が手で打ちかえられていたら商品名、商品略名を画面の値で上書きする
//////				// ※ただし、手で入力された商品略名がNULLもしくは空文字の時は変更しない
//////				if ((detail.ProdShortName != detail.ProdPuName) && (detail.ProdPuName.Length > 0))
////				// 手で入力された商品略名がNULLもしくは空文字の時は変更しない
////				if (detail.ProdPuName.Length > 0)
////// 管理番号 B22105 To
////				{
////					editedRow["PROD_PO_NAME"]			= detail.ProdPuName;
////					editedRow["PROD_SHORT_NAME"]		= detail.ProdPuName;
////				}
////				else
////				{
////					editedRow["PROD_PO_NAME"]			= detail.ProdName;
////					editedRow["PROD_SHORT_NAME"]		= detail.ProdShortName;
////				}
////// 管理番号 B19475 To
////				editedRow["PROD_NAME"]					= detail.ProdName;
//				// もし商品略名が手で打ちかえられていたら商品名、商品略名を画面の値で上書きする
//				// ※ただし、手で入力された商品略名がNULLもしくは空文字の時は変更しない
//				if ((detail.ProdShortName != detail.ProdPuName) && (detail.ProdPuName.Length > 0))
//				{
//					editedRow["PROD_PO_NAME"]			= detail.ProdPuName;
//					editedRow["PROD_SHORT_NAME"]		= detail.ProdPuName;
//					editedRow["PROD_NAME"]				= detail.ProdPuName;
//				}
//				else
//				{
//					editedRow["PROD_PO_NAME"]			= detail.ProdName;
//					editedRow["PROD_SHORT_NAME"]		= detail.ProdShortName;
//					editedRow["PROD_NAME"]				= detail.ProdName;
//				}
//// 管理番号 B21416 To
				// もし商品略名が手で打ちかえられていたら商品名、商品略名を画面の値で上書きする
				if (detail.ProdShortName != detail.ProdPuName)
				{
// 					editedRow["PROD_PO_NAME"]					= ValidateStringForSqlParameter("商品名", detail.ProdPuName, true, 50, CheckOption.None); //K24546
					editedRow["PROD_PO_NAME"]					= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS001198"), detail.ProdPuName, true, 50, CheckOption.None);
					editedRow["PROD_SHORT_NAME"]				= detail.ProdPuName;
					editedRow["PROD_NAME"]						= detail.ProdPuName;
				}
				else
				{
// 					editedRow["PROD_PO_NAME"]			= ValidateStringForSqlParameter("商品正式名", detail.ProdName, true, 50, CheckOption.None); //K24546
					editedRow["PROD_PO_NAME"]			= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS004325"), detail.ProdName, true, 50, CheckOption.None);
// 					editedRow["PROD_SHORT_NAME"]		= ValidateStringForSqlParameter("商品略名", detail.ProdShortName, true, 50, CheckOption.None); //K24546
					editedRow["PROD_SHORT_NAME"]		= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS001200"), detail.ProdShortName, true, 50, CheckOption.None);
					editedRow["PROD_NAME"]				= detail.ProdName;
				}
// 管理番号 B22497 To
				editedRow["PROD_TYPE"]					= detail.ProdType;
				editedRow["DISP_CONTROL_TYPE"]			= detail.DispControlType;
				editedRow["STOCK_ADMIN_FLG"]			= detail.StockAdminFlg;
				editedRow["LOT_ADMIN_FLG"]				= detail.LotAdminFlg;
// 管理番号 K25322 From
				editedRow["LOT_STOCK_VALUATION_FLG"]	= detail.LotStockValuationFlg;
// 管理番号 K25322 To
				editedRow["QT_DECIMAL_USE_FLG"]			= detail.QtDecimalUseFlg;
				editedRow["CTAX_CALC_TYPE"]				= detail.CtaxCalcType;
				editedRow["CTAX_RATE_CODE"]				= detail.CtaxRateCode;
				editedRow["CTAX_RATE"]					= detail.CtaxRate;
// 管理番号 K24382 From
//				editedRow["PROD_SPEC_1_CODE"] = ValidateStringForSqlParameter(this.prodSpec1CodeTitle, detail.ProdSpec1Code, false, 3, CheckOption.SingleByte);
				editedRow["PROD_SPEC_1_CODE"] = ValidateStringForSqlParameter(this.prodSpec1CodeTitle, detail.ProdSpec1Code, false, 15, CheckOption.SingleByte);
// 管理番号 K24382 To
				editedRow["PROD_SPEC_1_NAME"] = ValidateStringForSqlParameter(this.prodSpec1CodeTitle, detail.ProdSpec1Name, false, overseasFlg == "0" ? 3 : 10, CheckOption.None);
// 管理番号 K24382 From
//				editedRow["PROD_SPEC_2_CODE"] = ValidateStringForSqlParameter(this.ProdSpec2CodeTitle, detail.ProdSpec2Code, false, 3, CheckOption.SingleByte);
				editedRow["PROD_SPEC_2_CODE"] = ValidateStringForSqlParameter(this.ProdSpec2CodeTitle, detail.ProdSpec2Code, false, 15, CheckOption.SingleByte);
// 管理番号 K24382 To
				editedRow["PROD_SPEC_2_NAME"] = ValidateStringForSqlParameter(this.ProdSpec2CodeTitle, detail.ProdSpec2Name, false, overseasFlg == "0" ? 3 : 10, CheckOption.None);
				editedRow["PU_PLAN_PRICE"]				= detail.PuPlanPrice;
				editedRow["STOCK_UNIT_STD_SELL_PRICE"]	= detail.StdSellPrice;
// 				editedRow["UNIT_CODE"]					= ValidateStringForSqlParameter("単位", detail.UnitCode, false, 3, CheckOption.SingleByte); //K24546
				editedRow["UNIT_CODE"]					= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS001456"), detail.UnitCode, false, 3, CheckOption.SingleByte);
				editedRow["UNIT_SHORT_NAME"]			= detail.UnitShortName;
				editedRow["PU_QT"]						= detail.PuQt;
				editedRow["STOCK_UNIT_PU_QT"]			= detail.PuQt * detail.IncludeQt;

				editedRow["STOCK_UNIT_PO_ALLOC_PU_QT"]	= 0M;
				editedRow["PU_PRICE"]					= detail.PuPrice;
				editedRow["INIT_PU_PRICE"]				= 0M;
				editedRow["DISC_FLG"]					= detail.DiscFlg;
				// 管理番号 B13878 From
				editedRow["PRICE_UNDECIDED_FLG"]		= detail.PriceUndecidedFlg;
				// 管理番号 B13878 To
// 				editedRow["LINE_REMARKS_CODE"]			= ValidateStringForSqlParameter("行摘要コード", detail.LineRemarksCode, false, 3, CheckOption.SingleByte); //K24546
				editedRow["LINE_REMARKS_CODE"]			= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS003416"), detail.LineRemarksCode, false, 3, CheckOption.SingleByte);
// 				editedRow["LINE_REMARKS"]				= ValidateStringForSqlParameter("行摘要", detail.LineRemarks, false, 30, CheckOption.None); //K24546
				editedRow["LINE_REMARKS"]				= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS003415"), detail.LineRemarks, false, 30, CheckOption.None);
// 管理番号K27525 From
				// 帳簿控除理由コード
				editedRow["BOOK_DEDUCTION_REASON_CODE"]	= ValidateStringForSqlParameter(MultiLanguage.Get("SC_CS006633"), detail.BookDeductionReasonCode, false, 2, CheckOption.SingleByte);
				editedRow["BOOK_DEDUCTION_REASON_NAME"]	= detail.BookDeductionReasonName;
// 管理番号K27525 To
// 管理番号 K16671 From
				editedRow["REF_CODE"]					= ValidateStringForSqlParameter(detail.RefCodeWord, detail.RefCode, false, 20, CheckOption.SingleByte);
// 管理番号 K16671 To
				editedRow["INCLUDE_QT"]					= detail.IncludeQt;
// 管理番号 B12929 From
				editedRow["PRICE_UPDATE_FLG"]			= detail.PriceUpdateFlg;
// 管理番号 B12929 To
// 管理番号 K24789 From
				editedRow["CTAX_TYPE_CODE"]				= detail.CtaxTypeCode;
				editedRow["TAXINFO_CHG_FLG"]			= detail.TaxInfoChgFlg;
// 管理番号 K24789 To
				// 管理番号 B11723・B11796 From
				//				editedRow["PU_MONEY"]					= detail.PuQt * detail.PuPrice;
// 管理番号 K24789 From
//// 管理番号 K24278 From
////				decimal dtilAmt = Round.GetRound(commonData, detail.PuQt * detail.PuPrice, curDigit, amtRoundType);
//				decimal dtilAmt = 0;
//				if (this.imposeFlg == "0" && detail.CtaxCalcType == "I")
//				{
//					decimal itaxAmt = CalcCtax.GetCalcCtax(commonData, detail.CtaxCalcType, detail.CtaxRate, curDigit, detail.PuQt * detail.PuPrice, this.ctaxRoundType);
//					dtilAmt = Round.GetRound(commonData, detail.PuQt * detail.PuPrice - itaxAmt, curDigit, amtRoundType);
//				}
//				else
//				{
//					dtilAmt = Round.GetRound(commonData, detail.PuQt * detail.PuPrice, curDigit, amtRoundType);
//				}
//// 管理番号 K24278 To
				decimal dtilAmt = Round.GetRound(commonData, detail.PuQt * detail.PuPrice, curDigit, amtRoundType);
// 管理番号 K24789 To
				// 管理番号 B14028 From
				//				if (dtilAmt <= -100000000000M || 100000000000M <= dtilAmt)
				//				{
				//					AddErrorMessage(AllegroMessage.S10051("仕入金額", (byte) 11));
				//				}
				decimal totalDtilAmt = detail.CtaxCalcType.Equals("E") ? dtilAmt * (1M + detail.CtaxRate / 100M) : dtilAmt;
				decimal curRate = (rate.Length != 0) ? decimal.Parse(rate) : 1M;
// 管理番号 B14307 From
//				if (totalDtilAmt < -99999999999M || 99999999999M < dtilAmt || totalDtilAmt * curRate < -99999999999M || 99999999999M < dtilAmt * curRate)
				double keyDecimalDigit	= double.Parse(Cur.GetDecimalDigit(commonData, keyCurCode));
				decimal keyGrandTotal	= ForeignCurConv.GetForeignCurConv(commonData, keyCurCode, curCode, keyCurCode, totalDtilAmt, curRate, curRoundType);

				if (totalDtilAmt  >= 100000000000M || 100000000000M < keyGrandTotal)
// 管理番号 B14307 To
				{
// 					AddErrorMessage(AllegroMessage.S10015("仕入金額")); //K24546
					AddErrorMessage(AllegroMessage.S10015(MultiLanguage.Get("SC_CS000775")));
				}
					// 管理番号 B14028 To
				else
				{
					editedRow["PU_MONEY"] = dtilAmt;
				}
				// 管理番号 B11723・B11796 To
				editedRow["PROD_NAME_CORRECTION_FLG"]	= detail.AllowProdName;
				editedRow["PROD_EDIT_FLG"]				= detail.ProdEditFlg;
				editedRow["MULTI_LOT_FLG"]				= detail.MultLotFlg;
				editedRow["RCPT_INPUT_NO_NEED_FLG"]		= detail.RcptInputNoNeedFlg;

				editedRow["ROW_STATE"]					= state != RowState.Create ? RowState.Update : RowState.Create;

// 管理番号 K25322 From
				//ロット評価対象&複数ロット入力時はエラー
				if (detail.LotStockValuationFlg == "1")
				{
					DataView lotDv	= new DataView(this.lotDt);
					lotDv.RowFilter	= "ROW_ID =" + detail.PuLineId + " AND EDIT_QT > 0";
					DataTable distinctLotdt = lotDv.ToTable("distinctLotdt", true, new string[] { "LOT_NO" });

					// 複数ロットが引当されている場合、エラー
					if (distinctLotdt.Rows.Count > 1)
					{
						// ロット別在庫評価をする商品の場合、1明細に複数のロットは指定できません。
						AddErrorMessage(AllegroMessage.SC_MS_S10051);
					}
				}
// 管理番号 K25322 To
// 管理番号K27057 From
				customItemDtil.SetDataRow(editedRow, "CUSTOM_ITEM_TAG", tag);
// 管理番号K27057 To

				//エラー時は終了
				if(HasErrors)
				{
					editedRow.CancelEdit();
					RollBack(false);
				}
				else
				{
					//チェック時に必要なパラメータの設定
					detail.InitQt = (decimal) editedRow["INIT_PU_QT"];
					detail.UpperLimitPuQt = (decimal) editedRow["UPPER_LIMIT_PU_QT"];
					detail.StockUnitPoPuQt = (decimal) editedRow["STOCK_UNIT_PO_PU_QT"];
					detail.IsRcptExecute = editedRow["IS_RCPT_EXECUTE"].ToString();

					//数量チェック
					result = this.ValidateRowQt(commonData, detail);
					if(!result)
					{
						editedRow.CancelEdit();
// 管理番号B27422 From
//// 管理番号 B16171 From
//						this.RollBack(false);
//// 管理番号 B16171 To
// 管理番号B27422 To
						return false;
					}

					//確定
					editedRow.EndEdit();
					this.Commit();
					result = true;
// 管理番号 B24051 From
					if(state == RowState.Temp)
					{
						// 行挿入の更新時
						this.SetMaxLineID = this.NewRowLineID;								// 行挿入時、現在の最大行IDを１つ繰り上げる
					}
// 管理番号 B24051 To
				}
			}
			else
			{
				result = false;
// 				AddErrorMessage(AllegroMessage.S10034(detail.PuLineId.ToString(), "有効な明細")); //K24546
				AddErrorMessage(AllegroMessage.S10034(detail.PuLineId.ToString(), MultiLanguage.Get("SC_CS005493")));
			}
			return result;
		}


		//行削除
		public bool DeleteDetailRow(CommonData commonData, int puLineId)
		{
			bool ret = false;

			DataRow deleteRow = dt.Rows.Find(puLineId);
			if(deleteRow == null) return ret;

			deleteRow.Delete();

			//ロット詳細
			this.DeleteLotDetailRow(puLineId, true);

			//行番号再設定
			this.SetLineNo();

			//確定
			this.Commit();
			ret = true;
			return ret;
		}

		//対象行のロット明細追加
		private void CreateLotDtil(CommonData commonData, IF_SC_MM_05_DetailRowData detail)
		{
			int count = this.lotDt.Select("ROW_ID = " + detail.PuLineId).Length;
			//直送倉庫 or ロット管理フラグ==0
// 管理番号 K25322 From
//			if (count==0 && (detail.WhCode == this.DirectWhCode || detail.StockAdminFlg != "1" || detail.LotAdminFlg != "1"))
			if (count==0 && ((detail.LotStockValuationFlg =="0"&&detail.WhCode == this.DirectWhCode) || detail.StockAdminFlg != "1" || detail.LotAdminFlg != "1"))
// 管理番号 K25322 To
			{
				//ロット明細を作成する必要なし（一時テーブルにセットする寸前にBLにて作成）
			}
			else
			{
				//ロット明細数量の合計値 lotSumQt
				object  obj = this.lotDt.Compute("SUM([EDIT_QT])", "ROW_ID = " + detail.PuLineId);
				decimal lotSumQt    = obj is decimal ? (decimal)obj : 0M;
				//明細の仕入数量 detailSumQt
				decimal detailSumQt = detail.PuQt;

				//ロット明細と明細の数量を比較して、異なればロット明細振りなおし
				if ((detail.IsRcptExecute == "1" || (this.puModeType == "2" && this.refPuNo.Length > 0)) && lotSumQt != detailSumQt)
				{
					//ロット振り直し処理
					Infocom.Allegro.SC.IF_SC_MS_Lot lotData = new Infocom.Allegro.SC.IF_SC_MS_Lot(true);
					lotData.DeptCode        = this.deptCode;
					// 管理番号 B13877 From
					lotData.ProjCode = this.projCode;
					lotData.ProjSbno = this.projSbno;
					// 管理番号 B13877 To
					lotData.WhCode          = detail.WhCode;
					lotData.ProdCode        = detail.ProdCode;
					lotData.ProdSpec_1_Code = detail.ProdSpec1Code;
					lotData.ProdSpec_2_Code = detail.ProdSpec2Code;
					lotData.UnitCode        = detail.UnitCode;
					lotData.StockType       = "1";
					lotData.StockStatusType = "1";
					lotData.SlipDate        = string.Empty;
					lotData.DtilLineId      = detail.PuLineId.ToString();
					lotData.DtilQt          = detail.PuQt.ToString();
					lotData.LotDt           = this.lotDt;
// 管理番号 K25322 From
//					// 管理番号 B13500 From
//					//					lotData.LotAdminFlg     = (detail.LotAdminFlg=="1" && detail.WhCode != this.DirectWhCode);
//					lotData.LotAdminFlg     = (detail.LotAdminFlg=="1" && detail.WhCode != this.DirectWhCode && detail.RcptInputNoNeedFlg == "1");
//					// 管理番号 B13500 To
					lotData.LotAdminFlg     = (detail.LotAdminFlg=="1" && detail.WhCode != this.DirectWhCode && detail.RcptInputNoNeedFlg == "1")||detail.LotStockValuationFlg =="1";
// 管理番号 K25322 To
					lotData.SlipType        = "SM3";
					lotData.SlipNo          = this.puNo;

					//参照返品
					if (this.refPuNo.Length > 0)
					{
						// 管理番号 B14315 From
						//						lotData.Mode            = detail.IsRcptExecute == "1" ? "12" : "6";
						//						lotData.RefSlipNo       = this.refPuNo;
						//						lotData.RefSlipRowId    = detail.PuLineId.ToString();

						if (detail.RcptInputNoNeedFlg == "1")
						{
							lotData.Mode            = detail.IsRcptExecute == "1" ? "12" : "6";
							lotData.RefSlipNo       = this.refPuNo;
							lotData.RefSlipRowId    = detail.PuLineId.ToString();
						}
						else
						{
							lotData.Mode            = lotData.SlipNo.Length == 0 ? "5" : "2";
							lotData.SlipNo          = lotData.SlipNo.Length == 0 ? this.puNo : detail.RcptNo;
							lotData.RefSlipNo       = lotData.SlipNo.Length == 0 ? detail.RcptNo : this.puNo;
// 管理番号 K25322 From
//							lotData.RefSlipRowId    = detail.RcptLineId.ToString();
							lotData.RefSlipRowId    = lotData.SlipNo.Length == 0 ? detail.RcptLineId.ToString() : detail.PuLineId.ToString();
// 管理番号 K25322 To
						}
						// 管理番号 B14315 To
					}
						//入荷参照
// 管理番号 B15804 From
//					else if (detail.RcptNo.Length > 0)
					else if (detail.RcptNo.Length > 0 && detail.RcptLineId.ToString().Length > 0)
// 管理番号 B15804 To
					{
						lotData.Mode            = "5";
						lotData.RefSlipNo       = detail.RcptNo;
						lotData.RefSlipRowId    = detail.RcptLineId.ToString();
					}
						//発注参照（入荷あり）
					else
					{
						lotData.Mode            = "7";
						lotData.RefSlipNo       = detail.PoNo;
						lotData.RefSlipRowId    = detail.PoLineId.ToString();
					}

					//ロット振り直し処理
					Lot.GetMMLotDtil(commonData, lotData, this.RealStockMinusAllowFlg);
				}
			}
		}

		//対象行のロット明細削除
		public void DeleteLotDetailRow(decimal puLineId, bool IsCommit)
		{
			if(this.lotDt.Rows.Count >0)
			{
				DataRow[] sRows = this.lotDt.Select("[ROW_ID]=" + puLineId);
				foreach(DataRow sRow in sRows)
				{
					sRow.Delete();
				}
				this.lotDt.AcceptChanges();
				//バックアップを上書
				if(IsCommit)
				{
					this.lotDtBackUp=this.lotDt.Copy();
				}
			}
		}

		//仮挿入データ削除
		private void DeleteTempRow()
		{
			if(this.dt.Rows.Count > 0)
			{
				DataRow[] tRows = dt.Select("[ROW_STATE]='" + RowState.Temp + "'");
				foreach(DataRow tRow in tRows)
				{
					tRow.Delete();
				}
			}
		}

		//コミット
		private void Commit()
		{
			this.dt.AcceptChanges();
			this.lotDt.AcceptChanges();
			this.lotDtBackUp = this.lotDt.Copy();
			this.lotDtBackUp.AcceptChanges();
		}

// 管理番号 B22792 From
		public void CommitI()
		{
			this.dt.AcceptChanges();
			this.lotDt.AcceptChanges();
		}
// 管理番号 B22792 To

		//ロールバック
		public void RollBack(bool IsTempDelete)
		{
			this.dt.RejectChanges();
			this.lotDt.RejectChanges();

			if(IsTempDelete)
			{
				this.DeleteTempRow();
				this.SetLineNo();
			}

			this.lotDt = this.lotDtBackUp.Copy();
			this.Commit();
		}

		public void Delete()
		{
			this.dt.Clear();
			this.lotDt.Clear();
			this.lotDtBackUp.Clear();
			this.Commit();
		}

		//行番号の再設定
		public void SetLineNo()
		{
			int lineNo = 1;
			foreach(DataRow editRow in this.dt.Rows)
			{
				if(editRow.RowState!=DataRowState.Deleted)
				{
					editRow.BeginEdit();
					editRow["PU_LINE_NO"] = (decimal)lineNo++;
					if (editRow["ROW_STATE"].ToString() == RowState.Ref)
					{
						editRow["ROW_STATE"] = RowState.Update;
					}
					editRow.EndEdit();
				}
			}
		}

		//明細情報の削除
		public void DeleteDetailAll()
		{
			this.dt.Rows.Clear();
			this.lotDt.Rows.Clear();
			this.Commit();
		}

		//各合計金額算出
// 管理番号 K24789 From

// 管理番号 K24789 コメント削除
// 管理番号 B13502 コメント削除
// 管理番号 B13429 コメント削除
// 管理番号 B14298 コメント削除
// 管理番号 B14477 コメント削除
// 管理番号 B23588 コメント削除
// 管理番号 K24278 コメント削除
// 管理番号 B14028 コメント削除



		public void GetCurAmtTtl(CommonData commonData)
		{
			CalcPrice util = new CalcPrice(commonData);

			util.CurCode			= curCode;
			util.KeyCurCode			= keyCurCode;
			util.CurDigit			= double.Parse(Cur.GetDecimalDigit(commonData, curCode));
			util.KeyCurDigit		= double.Parse(Cur.GetDecimalDigit(commonData, keyCurCode));
			util.Rate				= decimal.Parse(rate);
			util.AmtRoundType		= amtRoundType;
			util.CurRoundType		= curRoundType;
			util.CtaxRoundType		= ctaxRoundType;
			util.CtaxImposeFlg		= imposeFlg;
			util.CtaxBuildupType	= ctaxBuildupType;
			util.IsSampleMode		= false;

			// 仮データ削除
			if (IsExistsTemporary)
			{
				RollBack(true);
			}

			foreach (DataRow row in dt.Rows)
			{
				if (row["ROW_STATE"].ToString() == RowState.Delete)
				{
					continue;
				}

				DataRow insertRow = util.PriceDtilDt.NewRow();

				insertRow["LINE_ID"]			= (decimal)row["PU_LINE_ID"];
				insertRow["PROD_TYPE"]			= row["PROD_TYPE"].ToString();
				insertRow["DISP_CONTROL_TYPE"]	= row["DISP_CONTROL_TYPE"].ToString();
				insertRow["CTAX_CALC_TYPE"]		= row["CTAX_CALC_TYPE"].ToString();
				insertRow["CTAX_RATE"]			= (decimal)row["CTAX_RATE"];
				insertRow["COST_PRICE"]			= 0M;
				insertRow["BASE_PRICE"]			= 0M;
				insertRow["TRAN_PRICE"]			= (decimal)row["PU_PRICE"];
				insertRow["TRAN_QT"]			= (decimal)row["PU_QT"];
// 管理番号K27522 From
				insertRow["RTAX_FLG"]			= CtaxRate.GetRtaxFlg(commonData, row["CTAX_RATE_CODE"].ToString());
// 管理番号K27522 To

				util.PriceDtilDt.Rows.Add(insertRow);
			}
			// 合計金額算出
			util.calcAmt();

			this.dtilAmtTtl		= util.DtilAmtTotal;
			this.taxableAmtTtl	= util.TaxableTotal;
			this.taxAmtTtl		= util.TaxTotal;
			this.grandTtl		= util.GrandTotal;
			this.keyGrandTtl	= util.KeyGrandTotal;
		}
// 管理番号 K24789 To


		//倉庫の更新
		public void SetDefaultWareHouse(CommonData commonData, string whCode, string whShortName)
		{
			if (whCode.Length==0 || whShortName.Length==0) return;

			foreach(DataRow row in this.dt.Rows)
			{
				if (row["WH_CODE"]==System.DBNull.Value || row["WH_CODE"].ToString().Trim().Length==0)
				{
					row["WH_CODE"]       = whCode;
					row["WH_SHORT_NAME"] = whShortName;
				}
			}
			this.dt.AcceptChanges();
		}

		//商品価格更新(現在は、得意先変更時のみ呼ばれる)
// 管理番号 K24789 From
//		public virtual bool ReloadProdPrice(CommonData commonData, string curCode, string custCombiCode, byte companyCodeLength, string deptCode, string targetDate, double curDigit, string amtRoundType)
		public virtual bool ReloadProdPrice(CommonData commonData, string curCode, string custCombiCode, byte companyCodeLength, string deptCode, string targetDate, double curDigit, string amtRoundType, string dealDate, string getType)
// 管理番号 K24789 To
		{
			bool ret = false;
			string custCode = string.Empty;
			string custSbno = string.Empty;
// 管理番号B26146 From
//			DateTime trgtD  = DateTime.Parse(targetDate.Length > 0 ? DateTime.Today.ToString("yyyy/MM/dd"):targetDate);
			DateTime trgtD	= DateTime.Parse(DateValidator.IsDate(targetDate) ? targetDate : DateTime.Today.ToString("yyyy/MM/dd")).Date;
// 管理番号B26146 To

			if (custCombiCode.Length > 0)
			{
// 管理番号 K24789 From
//				this.DivideDeliCustCode(custCombiCode, companyCodeLength);
				this.DivideSuplCode(custCombiCode, companyCodeLength);
// 管理番号 K24789 To
			}

			foreach(DataRow row in this.dt.Rows)
			{
				//明細表示行のPU_LINE_IDを取得
				int puLineId = int.Parse(row["PU_LINE_ID"].ToString());
				//PU_LINE_IDを渡す
// 管理番号 K24789 From
//				ret = this.GetProdPrice(commonData, puLineId, curCode, this.deliCustCode, this.deliCustSbno, deptCode, trgtD, curDigit, amtRoundType);
				ret = this.GetProdPrice(commonData, puLineId, curCode, this.suplCode, this.suplSbno, deptCode, trgtD, curDigit, amtRoundType, dealDate, getType);
// 管理番号 K24789 To
			}
			this.dt.AcceptChanges();
			return ret;
		}

		//商品価格取得
// 管理番号 K24789 From
//		// 管理番号 B11723・B11796 From
//		//		protected bool GetProdPrice(CommonData commonData, int puLineId, string curCode, string suplCode, string suplSbno,string deptCode, DateTime targetDate)
//		protected bool GetProdPrice(CommonData commonData, int puLineId, string curCode, string suplCode, string suplSbno,string deptCode, DateTime targetDate, double curDigit, string amtRoundType)
//			// 管理番号 B11723・B11796 To
		protected bool GetProdPrice(CommonData commonData, int puLineId, string curCode, string suplCode, string suplSbno,string deptCode, DateTime targetDate, double curDigit, string amtRoundType, string dealDate, string getType)
// 管理番号 K24789 To
		{
			bool ret = false;;

			DataRow editedRow = this.dt.Rows.Find(puLineId);
			editedRow.BeginEdit();

// 管理番号 K24789 From
			string ctaxRate			= string.Empty;
			string ctaxSubjectType	= string.Empty;
			string ctaxTypeCode		= string.Empty;
			string ctaxRateCode		= string.Empty;
// 管理番号 K25665 From
			string ctaxTypeName		= string.Empty;
// 管理番号 K25665 To
			dealDate				= dealDate.Length != 0 ? dealDate : DateTime.Today.ToString();

// 管理番号B26146 From
//			if (getType == "S" || getType == "RR" || getType == "P")
			if (getType == "S" || getType == "RR" || getType == "P" || getType == "PB")
// 管理番号B26146 To
			{
// 管理番号 K24789 To
				IF_SC_MS_Prod prodInfo = new IF_SC_MS_Prod();
// 管理番号 B26066 From
//				prodInfo.IsOverseas    = "0";
				// 計上日、仕入先、通貨変更時は海外フラグが未設定
				// 但し、計上日変更が商品情報に影響するのは国内の場合のみ
				// 伝票参照時は仕入先、通貨の変更が不可のため、国内仕入単独計上の場合のみ
				prodInfo.IsOverseas    = (this.overseasFlg.Length == 0) ? "0" : this.overseasFlg;
// 管理番号 B26066 To
				prodInfo.PriceType     = "2";	//購入価格
				prodInfo.CurCode       = curCode;
				prodInfo.CustSpulCode  = suplCode;
// 管理番号 K24389 From
//				prodInfo.CustSpulCode  = suplSbno;
				prodInfo.CustSpulSbno = suplSbno;
// 管理番号 K24389 To
				prodInfo.DeptCode      = deptCode;
				prodInfo.TargetDate    = targetDate.ToString();
				prodInfo.ProdCode      = editedRow["PROD_CODE"].ToString();
				prodInfo.ProdSpec1Code = editedRow["PROD_SPEC_1_CODE"].ToString();
				prodInfo.ProdSpec2Code = editedRow["PROD_SPEC_2_CODE"].ToString();
				prodInfo.UnitCode      = editedRow["UNIT_CODE"].ToString();
// 管理番号 K24389 From
				prodInfo.BasisQt = editedRow["PU_QT"].ToString();
// 管理番号 K24389 To
				// 管理番号 B13877 From
				prodInfo.ProjCode = projCode;
				prodInfo.ProjSbno = projSbno;
				// 管理番号 B13877 To
// 管理番号 K24789 From
				prodInfo.ModeType = (this.puModeType.Length > 0) ? this.puModeType : "1";
				prodInfo.CtaxImposeFlg = this.imposeFlg;
// 管理番号 K24789 To

				//共通BL
				ret = Infocom.Allegro.SC.MS.Prod.GetPrice(commonData, prodInfo);
				// 管理番号 B14298 From
				//			editedRow["PU_PRICE"]                 = prodInfo.Price;
				// 管理番号 B11723・B11796 From
				//			editedRow["PU_MONEY"]                 = prodInfo.Price * (decimal)editedRow["PU_QT"];
				//			editedRow["PU_MONEY"] = Round.GetRound(commonData, prodInfo.Price * (decimal)editedRow["PU_QT"], curDigit, amtRoundType);
// 管理番号 K24789 From
				if (getType != "RR")
				{
// 管理番号 K24789 To
					// 通貨などが変更されたら仕入予定単価、仕入明細金額を再算出する
					editedRow["PU_PLAN_PRICE"] = prodInfo.Price;
// 管理番号 K24278 From
//				editedRow["PU_MONEY"] = Round.GetRound(commonData, (decimal) editedRow["PU_PRICE"] * (decimal)editedRow["PU_QT"], curDigit, amtRoundType);
// 管理番号 K24278 To
					// 管理番号 B14298 To
					// 管理番号 B11723・B11796 To
					editedRow["PROD_NAME_CORRECTION_FLG"] = prodInfo.AllowProdNameCorrection ? "1" : "0";
					
// 管理番号 K24789 From
//					editedRow["CTAX_CALC_TYPE"]           = prodInfo.CtaxCalcType;
//					string ctaxRate     = string.Empty;
//					string ctaxTypeCode = this.puModeType!="2" ? puCtaxTypeCode : puReturnCtaxTypeCode;
//					if (CtaxTypeCtaxRateRelation.GetCtaxRate(commonData, ctaxTypeCode, prodInfo.CtaxRateCode, puDate, "0", out ctaxRate))
//					{
//						editedRow["CTAX_RATE"] = ctaxRate;
//					}
//					else
//					{
//						AddErrorMessage(AllegroMessage.SC_MS_S10016);
//						ret = false;
//					}
// 管理番号 K24789 To

					editedRow["INCLUDE_QT"] = prodInfo.IncludeQt;
// 管理番号 K24789 From
//// 管理番号 K24278 From
//					if (this.imposeFlg == "0" && prodInfo.CtaxCalcType == "I")
//					{
//						decimal itaxAmt			= CalcCtax.GetCalcCtax(commonData, prodInfo.CtaxCalcType, decimal.Parse(ctaxRate), curDigit, ((decimal)editedRow["PU_PRICE"] * (decimal)editedRow["PU_QT"]), ctaxRoundType);
//						editedRow["PU_MONEY"]	= Round.GetRound(commonData, ((decimal)editedRow["PU_PRICE"] * (decimal)editedRow["PU_QT"]) - itaxAmt, curDigit, amtRoundType);
//					}
//					else
//					{
//						editedRow["PU_MONEY"]	= Round.GetRound(commonData, ((decimal)editedRow["PU_PRICE"] * (decimal)editedRow["PU_QT"]), curDigit, amtRoundType);
//					}
//// 管理番号 K24278 To
					editedRow["PU_MONEY"]	= Round.GetRound(commonData, ((decimal)editedRow["PU_PRICE"] * (decimal)editedRow["PU_QT"]), curDigit, amtRoundType);
				}

				if (getType == "S")
				{
					editedRow["CTAX_CALC_TYPE"] = prodInfo.CtaxCalcType;					// 消費税計算区分
					editedRow["CTAX_TYPE_CODE"] = ctaxTypeCode = prodInfo.CtaxTypeCode;		// 消費区分コード
					editedRow["CTAX_RATE_CODE"] = ctaxRateCode = prodInfo.CtaxRateCode;		// 消費税率コード
					// 消費税情報変更フラグ初期化
					editedRow["TAXINFO_CHG_FLG"] = "0";
				}
				else if (getType == "RR")
				{
					editedRow["CTAX_TYPE_CODE"] = ctaxTypeCode = prodInfo.CtaxTypeCode;		// 消費区分コード
// 管理番号 K25665 From
//					ctaxRateCode = editedRow["CTAX_RATE_CODE"].ToString();
					CtaxType.IsExists(commonData, prodInfo.CtaxTypeCode, out ctaxTypeName, out ctaxSubjectType);
					if (ctaxSubjectType == "N")
					{
						// 消費税科目区分が"N"の場合、消費税率コードに"0"を設定
						editedRow["CTAX_RATE_CODE"] = ctaxRateCode = "0";
					}
					else
					{
						ctaxRateCode = editedRow["CTAX_RATE_CODE"].ToString();
					}
// 管理番号 K25665 To
					// 消費税情報変更フラグ初期化
					editedRow["TAXINFO_CHG_FLG"] = "0";
				}
// 管理番号B26146 From
				else if (getType == "PB")
				{
					ctaxTypeCode = editedRow["CTAX_TYPE_CODE"].ToString();
					ctaxRateCode = editedRow["CTAX_RATE_CODE"].ToString();
				}
// 管理番号B26146 To
			}
			else
			{
				ret = true;
				ctaxTypeCode = editedRow["CTAX_TYPE_CODE"].ToString();
				ctaxRateCode = editedRow["CTAX_RATE_CODE"].ToString();
			}

			// 伝票参照('R')、仕入参照返品('RR')、仕入先コード変更('S')、取引日変更('B')、計上日変更('PB')
// 管理番号B26146 From
//			if (getType == "R" || getType == "RR" || getType == "S" || getType == "B")
			if (getType == "R" || getType == "RR" || getType == "S" || getType == "B" || getType == "PB")
// 管理番号B26146 To
			{
				//消費税率の取得
				if (CtaxTypeCtaxRateRelation.GetCtaxRate(commonData, ctaxTypeCode + ctaxRateCode, dealDate, false, out ctaxRate, out ctaxSubjectType))
				{
					editedRow["CTAX_RATE"] = decimal.Parse(ctaxRate);
				}
				else
				{
					// 消費税率が取得できない場合、0%として伝票金額を算出する。※行更新、伝票更新時にエラー
					editedRow["CTAX_RATE"] = 0M;
				}
			}
// 管理番号 K24789 To

			editedRow.EndEdit();
			return ret;
		}

		//仕入形態にサンプルが選択されたときの処理
		public void PuModeSampleSelected()
		{
			foreach(DataRow row in this.dt.Rows)
			{
				row["PU_PRICE"] = 0M;
				row["PU_MONEY"] = 0M;
			}
			this.Commit();
		}

// 管理番号 K24789 From
		// 消費税率チェック
		public string CtaxRateDtilChkMessage(CommonData commonData)
		{
			DataView dv = new DataView(dt);
			dv.Sort = "CTAX_RATE_CODE";

			// 明細行のチェック
			string returnMess		= string.Empty;
			string puDateCtaxRate	= string.Empty;
			string ctaxSubjectType	= string.Empty;

			if (this.PuDate == this.DealDate)
			{
				return returnMess;	// 仕入日と取引日が同じ場合、チェックしない
			}

			for (int i = 0; i < dv.Count; i++)
			{
				if (dv[i]["ROW_STATE"].ToString() != RowState.Delete && dv[i]["PU_LINE_ID"] != DBNull.Value)
				{
					if (i != 0 && dv[i-1]["CTAX_RATE_CODE"].ToString() == dv[i]["CTAX_RATE_CODE"].ToString())
					{
						// 消費税率コードが同じ場合、チェックしない
						continue;
					}

					if (!CtaxTypeCtaxRateRelation.GetCtaxRate(commonData, dv[i]["CTAX_TYPE_CODE"].ToString() + dv[i]["CTAX_RATE_CODE"], this.puDate, false, out puDateCtaxRate, out ctaxSubjectType))
					{
						// 仕入日時点の消費税率が取得できない場合、0とする
						puDateCtaxRate = "0";
					}

					// 仕入日時点の消費税率と明細の消費税率を比較
					if (decimal.Parse(puDateCtaxRate) != (decimal)dv[i]["CTAX_RATE"])
					{
						//[仕入日]基準の税率と異なる税率の明細が存在します。[取引日]を確認の上、更新してください。
						returnMess = AllegroMessage.S20043(MultiLanguage.Get("SC_CS000806"),MultiLanguage.Get("SC_CS000939"));
						break;
					}
				}
			}
			if (returnMess.Length > 0)
			{
				CheckFlg = "1";
			}
			return returnMess;
		}
// 管理番号 K24789 To

		//行更新時チェック(値)
		private void ValidateRow(CommonData commonData, IF_SC_MM_05_DetailRowData detail)
		{
// 管理番号 B23238 From
//			//有効件数99件
//			int rowCount = ValidCount + 1;
//			if(rowCount > MAX_LINE_ID)
//			{
//				AddErrorMessage(AllegroMessage.S10003(99));
//				return;
//			}

			//件数チェックは新規行登録時・行挿入時のみ実施

// 管理番号 B23238 To
			//商品
			if(detail.ProdCode.Length > 0)
			{
				if(!Infocom.Allegro.SC.MS.Prod.IsExists(commonData, detail.ProdCode))
				{
// 					AddErrorMessage(AllegroMessage.S20005("商品コード")); //K24546
					AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001158")));
				}
			}
			//規格1
			if(this.productSpecUseType !="0")
			{
				if(!Infocom.Allegro.SC.MS.Spec.IsExists(commonData,detail.ProdSpec1Code,"1"))
				{
					AddErrorMessage(AllegroMessage.S20005(this.prodSpec1CodeTitle));
				}
			}
			//規格2
			if(this.productSpecUseType =="2")
			{
				if(!Infocom.Allegro.SC.MS.Spec.IsExists(commonData,detail.ProdSpec2Code,"2"))
				{
					AddErrorMessage(AllegroMessage.S20005(this.ProdSpec2CodeTitle));
				}
			}
			//倉庫
			if(detail.StockAdminFlg=="1")
			{
				if(detail.WhCode.Length > 0)
				{
					bool directWhUseFlg = this.puModeType != "4";
					if (!Infocom.Allegro.SC.MS.Wh.IsExists(commonData, detail.WhCode, false, directWhUseFlg, true, true, true))
					{
// 						AddErrorMessage(AllegroMessage.S20005("倉庫")); //K24546
						AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001387")));
					}
// 管理番号 K24153 From
                                        // 明細倉庫コードが直送倉庫を指定し、かつヘッダ納入区分が自社倉庫の場合
                                        else if (detail.WhCode == this.DirectWhCode && this.deliType == "W")
                                        {
	                                        AddErrorMessage(AllegroMessage.SC_MM_05_S10001);
                                        }
// 管理番号 K24153 To
                                }
			}
			// 数量0チェック
			if(detail.PuQt == 0)
			{
// 				AddErrorMessage(AllegroMessage.S10060("数量")); //K24546
				AddErrorMessage(AllegroMessage.S10060(MultiLanguage.Get("SC_CS001259")));
			}
			//単位
			if(!Infocom.Allegro.SC.MS.Unit.IsExists(commonData,detail.ProdCode, detail.UnitCode))
			{
// 				AddErrorMessage(AllegroMessage.S20005("単位")); //K24546
				AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001456")));
			}

			//ロット明細
			int count = this.lotDt.Select("ROW_ID =" + detail.PuLineId).Length;
// 管理番号 K25322 From
//			// 管理番号 B13500 From
//			//			if (count == 0 && !(detail.WhCode == this.DirectWhCode || detail.StockAdminFlg != "1" || detail.LotAdminFlg != "1"))
//			if (count == 0 && !(detail.WhCode == this.DirectWhCode || detail.StockAdminFlg != "1" || (detail.LotAdminFlg != "1" || detail.RcptInputNoNeedFlg != "1")))
//				// 管理番号 B13500 To
			if (count == 0 && !((detail.WhCode == this.DirectWhCode && detail.LotStockValuationFlg!="1")  || detail.StockAdminFlg != "1" || (detail.LotAdminFlg != "1" || detail.RcptInputNoNeedFlg != "1")))
// 管理番号 K25322 To
			{
// 				AddErrorMessage(AllegroMessage.S10006("ロット明細")); //K24546
				AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS002909")));
			}
// 管理番号 K25647 From
			// 明細数量（在庫単位数量：数量×入数）のオーバーフローチェック
			if (detail.PuQt * detail.IncludeQt >= 1000000000M || detail.PuQt * detail.IncludeQt <= -1000000000M)
			{
				// ［%s］ はオーバーフローしました。 ［%s］ の整数部が %d 桁以内で算出されるように入力してください。
				AddErrorMessage(AllegroMessage.S10051(MultiLanguage.Get("SC_CS003536"), (byte)9));	// SC_CS003536:在庫単位数量
			}

			// 在庫単位換算数量チェック
			if(!StockUnitConversionCheck(detail.PuQt, detail.IncludeQt))
			{
				// ［在庫単位数量］の小数点以下の桁数が %d 桁を超えました。（入数［%d］）
				AddErrorMessage(AllegroMessage.SC_MS_S10056(this.myCompQtDecimalUseFlg ? 4 : 0, detail.IncludeQt));
			}
// 管理番号 K25647 To
// 管理番号K27525 From
			// 帳簿控除理由コード(国内のみ)
			if (this.overseasFlg != "1" && detail.BookDeductionReasonCode.Length > 0)
			{
				// 帳簿控除理由コードの存在チェック
				if (!BookDeductionReason.IsExists(commonData, detail.BookDeductionReasonCode, "SM3"))
				{
					// ［帳簿控除理由］ がマスタにないか、有効ではありません。
					AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS006632")));
				}
				// 消費税区分コードとの関連チェック
				else if (detail.CtaxTypeCode == "T")
				{
					// ［消費税区分］が控除外課税仕入の場合、［帳簿控除理由］は選択できません。
					AddErrorMessage(AllegroMessage.SC_MM_S10004(MultiLanguage.Get("CM_CS000884"), MultiLanguage.Get("SC_CS006632")));
				}
			}
// 管理番号K27525 To
// 管理番号K27057 From
			DateTime dt = DateTime.Now;
			customItemDtil.Validate(PuDate == string.Empty ? dt.ToString("yyyy/MM/dd") : PuDate, AddErrorMessage);
// 管理番号K27057 To
		}

		//行更新時チェック(数量)
		private bool ValidateRowQt(CommonData commonData, IF_SC_MM_05_DetailRowData detail)
		{
			//ロット
			int lotCnt = this.LotDt.Select("[ROW_ID]=" + detail.PuLineId).Length;
// 管理番号 K25322 From
//			// 管理番号 B13500 From
//			//			if (detail.WhCode!="99999" && detail.LotAdminFlg=="1" && lotCnt==0)
//			if (detail.WhCode!="99999" && detail.LotAdminFlg=="1" && lotCnt==0 && detail.RcptInputNoNeedFlg == "1")
//				// 管理番号 B13500 To
			if (lotCnt==0 &&((detail.WhCode!="99999"&& detail.LotAdminFlg=="1" && detail.RcptInputNoNeedFlg == "1")||detail.LotStockValuationFlg=="1"))
// 管理番号 K25322 To
			{
// 				AddErrorMessage(AllegroMessage.SC_MS_S10019("有効なロット番号")); //K24546
				AddErrorMessage(AllegroMessage.SC_MS_S10019(MultiLanguage.Get("SC_CS005492")));
				return false;
			}

			return ValidateRowQt(detail);
		}

		//行更新時チェック(数量)
		protected abstract bool ValidateRowQt(IF_SC_MM_05_DetailRowData detail);

// 管理番号 B23238 From
		//行更新時チェック(件数)
		public void ValidateRowCount(CommonData commonData)
		{
			//有効件数99件
			if (ValidCount >= MAX_LINE_ID)
			{
				AddErrorMessage(AllegroMessage.S10003(MAX_LINE_ID));
				return;
			}
		}
// 管理番号 B23238 To

		//フッタ更新時のチェック
		public virtual void Validate(CommonData commonData, string disclosureUnitType, string userDeptCode)
		{
			if(this.HasErrors) return;
			// 管理番号 B13500 From
			int ttlCnt = 0;
			int errCnt = 0;
			// 管理番号 B13500 To

			//修正時、仕入番号の存在チェック
			if(this.puNo.Length > 0)
			{
				if(!Infocom.Allegro.SC.MS.ScSlip.IsExists(commonData, "SM3", this.puNo))
				{
// 					AddErrorMessage(AllegroMessage.S20005("仕入番号")); //K24546
					AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS000809")));
				}
			}
			//参照時の発注番号の存在チェック
			if(this.poNo.Length > 0)
			{
				if(!Infocom.Allegro.SC.MS.ScSlip.IsExists(commonData, "SM1", this.poNo))
				{
// 					AddErrorMessage(AllegroMessage.S20005("発注参照")); //K24546
					AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001766")));
				}
			}
			//参照時、入荷番号の存在チェック
			if(this.rcptNo.Length > 0)
			{
// 管理番号 B21726 From				
//				if(!Infocom.Allegro.SC.MS.ScSlip.IsExists(commonData, "SM2", this.rcptNo))
				if(!Infocom.Allegro.SC.MS.ScSlip.IsExists(commonData, "SM2", this.rcptNo, true))
// 管理番号 B21726 To					
				{
// 					AddErrorMessage(AllegroMessage.S20005("入荷参照")); //K24546
					AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001613")));
				}
			}
			//参照時、仕入参照の存在チェック
			if(this.refPuNo.Length > 0)
			{
// 管理番号 B21726 From				
//				if(!Infocom.Allegro.SC.MS.ScSlip.IsExists(commonData, "SM3", this.refPuNo))
				if(!Infocom.Allegro.SC.MS.ScSlip.IsExists(commonData, "SM3", this.refPuNo, true))
// 管理番号 B21726 To					
				{
// 					AddErrorMessage(AllegroMessage.S20005("仕入参照")); //K24546
					AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS000781")));
				}
			}
			//仕入先コードの存在チェック
			if(this.suplCode.Length >0 )
			{
				string overSeasType = string.Empty;
				if (this.overseasFlg == "0")
				{
					overSeasType = "D";
				}
				else if (this.overseasFlg == "1")
				{
					overSeasType = "O";
				}
				if (!Infocom.Allegro.CM.MS.Supl.IsExistsSupl(commonData, this.suplCode, this.suplSbno, this.puDate, false, overSeasType, false))
				{
// 					AddErrorMessage(AllegroMessage.S20005("仕入先")); //K24546
					AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS000784")));
				}
			}
// 管理番号 K16590 From
			//仕入日 以下の日付を入力
			if (this.dealDate.Length > 0 && this.puDate.Length > 0 && DateTime.Parse(this.DealDate) > DateTime.Parse(this.puDate))
			{
// 				AddErrorMessage(AllegroMessage.S10071("取引日", "仕入日")); //K24546
				AddErrorMessage(AllegroMessage.S10071(MultiLanguage.Get("SC_CS000939"), MultiLanguage.Get("SC_CS000806")));
			}
// 管理番号 K16590 To
// 管理番号 B21177 From
			// 返品日の日付チェック
			if(this.refPuNo.Length > 0 && this.RefPuDate.Length > 0 && DateTime.Parse(this.RefPuDate) > DateTime.Parse(this.puDate))
			{
// 				AddErrorMessage(AllegroMessage.S10013("返品日", "仕入日")); //K24546
				AddErrorMessage(AllegroMessage.S10013(MultiLanguage.Get("SC_CS001887"), MultiLanguage.Get("SC_CS000806")));
			}
// 管理番号 B21177 To
// 管理番号 B22191 From
			// 発注日の日付チェック
// 管理番号 B22412 From
//			if(this.PoDate.Length > 0 && DateTime.Parse(this.PoDate) > DateTime.Parse(this.puDate))
			if(this.puModeType != "2" && this.PoDate.Length > 0 && DateTime.Parse(this.PoDate) > DateTime.Parse(this.puDate))
// 管理番号 B22412 To
			{
// 				AddErrorMessage(AllegroMessage.S10013("仕入日", "発注日")); //K24546
				AddErrorMessage(AllegroMessage.S10013(MultiLanguage.Get("SC_CS000806"), MultiLanguage.Get("SC_CS001788")));
			}
// 管理番号 B22191 To
			//担当者コードの存在チェック
			if(this.empCode.Length > 0)
			{
				if(!Infocom.Allegro.CM.MS.Emp.IsExists(commonData, this.empCode, false))
				{
// 					AddErrorMessage(AllegroMessage.S20005("担当者")); //K24546
					AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001476")));
				}
			}
			//部門コードの存在チェック (優先順位：仕入日→本日日付)
			if(this.deptCode.Length > 0)
			{
				string compareDate = DateTime.Today.ToString();
				if (this.puDate.Length > 0 && this.puDate != "9998/12/31")
				{
					compareDate = this.puDate;
				}

				// 自部門権限時参照部門設定
				string lowerDept = disclosureUnitType == "D" ? userDeptCode : string.Empty;

				if (!Infocom.Allegro.CM.MS.Dept.IsExists(commonData, this.deptCode, compareDate, false, true, false, lowerDept, false, false))
					//if (!Infocom.Allegro.CM.MS.Dept.IsExists(commonData, this.deptCode, compareDate, false, true, false, this.lowerDeptCode, false, false ))
				{
// 					AddErrorMessage(AllegroMessage.S20005("部門")); //K24546
					AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001858")));
				}
			}
			//プロジェクトコードの存在チェック
			if(this.projCode.Length > 0)
			{
				if(!Infocom.Allegro.CM.MS.Proj.IsExists(commonData, this.projCode, this.projSbno, this.puDate, false, this.deptCode))
				{
// 					AddErrorMessage(AllegroMessage.S20005("プロジェクト")); //K24546
					AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS000232")));
				}
			}
// 管理番号 K24284 From
			else
			{
				// 「自社マスタ使用する」且つ「必須の場合のみ必須チェック」
				if (ProjImplementFlg && ProjInputScIndisFlg)
				{
// 					AddErrorMessage(AllegroMessage.S10006("プロジェクト")); //K24546
					AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS000232")));
				}
			}
// 管理番号 K24284 To
// 管理番号K27062 From
			// 受渡場所コードの存在チェック
			if (this.deliPlaceCode.Length > 0)
			{
				if (!DeliPlace.IsExists(commonData, this.deliCustCode, this.deliCustSbno, this.deliPlaceCode))
				{
					// 受渡場所
					AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001000")));
				}
			}
// 管理番号K27062 To
			//倉庫コードの存在チェック
			if(this.whCode.Length > 0)
			{
				// 管理番号 B14465 From
				//				if(!Infocom.Allegro.SC.MS.Wh.IsExists(commonData, this.whCode, false, false, true, true, true))
				//				{
				//					AddErrorMessage(AllegroMessage.S20005("自社倉庫"));
				//				}
				if(!Infocom.Allegro.SC.MS.Wh.IsExists(commonData, this.whCode, false, true, true, true, true))
				{
// 					AddErrorMessage(AllegroMessage.S20005("自社倉庫")); //K24546
					AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS000866")));
				}
				// 管理番号 B14465 To
			}
			//納入先コードの存在チェック
// 管理番号 K24153 From
//                        if(this.deliCustCode.Length > 0 && this.overseasFlg!="1")
                        if (this.deliCustCode.Length > 0)
// 管理番号 K24153 To
                        {
				if (!Infocom.Allegro.CM.MS.Cust.IsExistsSaleCust(commonData, this.deliCustCode, this.deliCustSbno, this.puDate, false))
				{
// 					AddErrorMessage(AllegroMessage.S20005("納入先")); //K24546
					AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001673")));
				}
			}
// 管理番号 B20946 From
			if (this.fmoneySttlPeriodSttMonth.Length > 0 && this.fmoneySttlPeriodEndMonth.Length > 0)
			{
				if (this.fmoneySttlPeriodEndMonth.CompareTo(this.fmoneySttlPeriodSttMonth) < 0)					
				{
// 					AddErrorMessage(AllegroMessage.S10013("外貨決済期間終了月","外貨決済期間開始月")); //K24546
					AddErrorMessage(AllegroMessage.S10013(MultiLanguage.Get("SC_CS003089"),MultiLanguage.Get("SC_CS003088")));
				}
			}
// 管理番号 B20946 To			
// 管理番号 B21516 From
//// 管理番号 B17601 From
//			// 為替予約番号
//			if(this.ExchangeRezNo.Length > 0)
//			{
//				string strRate = string.Empty;
//				if(!ExchangeRez.IsExists(commonData, this.ExchangeRezNo, this.DeptCode, this.ProjCode, this.ProjSbno
//					, this.PuDate, out strRate, "S", this.CurCode))
//				{
//					AddErrorMessage(AllegroMessage.S20005("為替予約番号"));
//				}
//			}
//// 管理番号 B17601 To
// 管理番号 B23717 From
//			//仕入形態区分が返品の場合
//			if (this.puModeType=="2")
//			{
//				// 為替予約番号
//				if(this.ExchangeRezNo.Length > 0)
//				{
//					string strRate = string.Empty;
//					if(!ExchangeRez.IsExists(commonData, this.ExchangeRezNo, this.DeptCode, this.ProjCode, this.ProjSbno
//						, this.PuDate, out strRate, "S", this.CurCode))
//					{
//						AddErrorMessage(AllegroMessage.S20005("為替予約番号"));
//					}
//				}
//			}
// 管理番号 B23717 To
			//為替予約番号の存在チェック
			if (this.exchangeType == "1")
			{
				if (this.exchangeRezNo.Length == 0)
				{
					// 為替区分が"予約あり"で、予約番号がブランクはエラー
// 					AddErrorMessage(AllegroMessage.S10044("為替区分", "予約ありの", "為替予約番号")); //K24546
					AddErrorMessage(AllegroMessage.S10044(MultiLanguage.Get("SC_CS000317"), MultiLanguage.Get("SC_CS005515"), MultiLanguage.Get("SC_CS000319")));
				}
			}
// 管理番号 B21516 To
// 管理番号 B15414 From
			decimal decRate = 0M;
			decRate = decimal.Parse(this.Rate);
			if(decRate == 0M)
			{
// 				AddErrorMessage(AllegroMessage.S10060("レート")); //K24546
				AddErrorMessage(AllegroMessage.S10060(MultiLanguage.Get("SC_CS000271")));
			}
// 管理番号 B15414 To

// 管理番号 B24264 From
//			//支払先情報
//			if (this.tempCodeFlg == "1")
//			{
//				//銀行コードの必須・存在チェック
//				if (this.bankCode.Length > 0)
//				{
//					if(!Infocom.Allegro.CM.MS.Bank.IsExists(commonData, this.bankCountryCode, this.bankCode))
//					{
//						AddErrorMessage(AllegroMessage.S20005("銀行コード"));
//					}
//				}
//// 管理番号 B20392 From
////				else if (this.acType == "B")
//				else if (this.acType == "B" || this.acType == "A")
//// 管理番号 B20392 To
//				{
//					AddErrorMessage(AllegroMessage.S10006("銀行コード"));
//				}
//				//支店コードの必須・存在チェック
//				if (this.bankBranchCode.Length > 0)
//				{
//					if(!Infocom.Allegro.CM.MS.BankBranch.IsExists(commonData, this.bankCountryCode, this.bankCode, this.bankBranchCode))
//					{
//						AddErrorMessage(AllegroMessage.S20005("支店コード"));
//					}
//				}
//// 管理番号 B20392 From
////				else if (this.acType == "B")
//				else if (this.acType == "B" || this.acType == "A")
//// 管理番号 B20392 To
//				{
//					AddErrorMessage(AllegroMessage.S10006("支店コード"));
//				}
//				//口座名義人の必須チェック
//				if (this.acType != "" && this.acHolder.Length == 0)
//				{
//					AddErrorMessage(AllegroMessage.S10006("口座名義人"));
//				}
//// 管理番号 B20392 From
//				if (this.acType != "" && this.acHolder.Length > 48)
//				{
//					AddErrorMessage(AllegroMessage.S10020("口座名義人", 48));
//				}
//// 管理番号 B20392 To
//				//口座番号の必須チェック
//				if (this.acType != "" && this.acNo.Length == 0)
//				{
//					AddErrorMessage(AllegroMessage.S10006("口座番号"));
//				}
//// 管理番号 B20392 From
//				if (this.acType == "B")
//				{
//					if (this.acNo.Length > 7)
//					{
//						AddErrorMessage(AllegroMessage.S10020("口座区分］ が銀行のとき、 ［口座番号",7));
//					}
//				}
//				else if (this.acType == "A")
//				{
//					if (this.acNo.Length > 7)
//					{
//						AddErrorMessage(AllegroMessage.S10020("口座区分］ が農協のとき、 ［口座番号",7));
//					}
//				}
//				else if (this.acType == "P")
//				{
//					if (this.acNo.Length > 15)
//					{
//						AddErrorMessage(AllegroMessage.S10020("口座区分］ が郵便局のとき、 ［口座番号",15));
//					}
//				}
//// 管理番号 B20392 To
//			}
//			//海外取引条件
//			if (this.overseasFlg=="1")
//			{
//				decimal ratio1 = decimal.Parse(this.overseas[0].Ratio);
//				decimal ratio2 = decimal.Parse(this.overseas[1].Ratio);
//				decimal ratio3 = decimal.Parse(this.overseas[2].Ratio);
//				decimal sum = ratio1 + ratio2 + ratio3;
//				if (sum!=100M)
//				{
//					AddErrorMessage(AllegroMessage.SC_SD_08_S04_01);
//				}
//				else if(sum==0M)
//				{
//					AddErrorMessage(AllegroMessage.SC_SD_08_S04_02);
//				}
//// 管理番号 B15297 From
//				//仕入日・支払予定日整合性チェック
//				if(this.overseas[0].ClctPlanDate.Length != 0)
//				{
//					if (Convert.ToDateTime(this.PuDate) > Convert.ToDateTime(this.overseas[0].ClctPlanDate))
//					{
//						AddErrorMessage(AllegroMessage.S10013("支払条件1(支払予定日)", "仕入日"));
//					}
//				}
//				if(this.overseas[1].ClctPlanDate.Length != 0)
//				{
//					if (Convert.ToDateTime(this.PuDate) > Convert.ToDateTime(this.overseas[1].ClctPlanDate))
//					{
//						AddErrorMessage(AllegroMessage.S10013("支払条件2(支払予定日)", "仕入日"));
//					}
//				}
//				if(this.overseas[2].ClctPlanDate.Length != 0)
//				{
//					if (Convert.ToDateTime(this.PuDate) > Convert.ToDateTime(this.overseas[2].ClctPlanDate))
//					{
//						AddErrorMessage(AllegroMessage.S10013("支払条件3(支払予定日)", "仕入日"));
//					}
//				}
//// 管理番号 B15297 To
//			}
//
//// 管理番号 B15297 From
//			if (this.overseasFlg=="0")
//			{
//// 管理番号 B15297 To
//				//締日
//				if (this.cutoffDate.Length == 0)
//				{
//					AddErrorMessage(AllegroMessage.S10006("締日"));
//				}
//					//仕入日・締日整合性チェック
//				else if (Convert.ToDateTime(this.puDate) > Convert.ToDateTime(this.cutoffDate))
//				{
//					AddErrorMessage(AllegroMessage.S10013("締日", "仕入日"));
//				}
//				//支払期限
//				if (this.PymtPlanDate.Length == 0)
//				{
//					AddErrorMessage(AllegroMessage.S10006("支払期限"));
//				}
//					//締日・支払期限整合性チェック
//				else if (Convert.ToDateTime(this.cutoffDate) > Convert.ToDateTime(this.pymtPlanDate))
//				{
//					AddErrorMessage(AllegroMessage.S10013("支払期限", "締日"));
//				}
//// 管理番号 B15297 From
//			}
//// 管理番号 B15297 To
//
// 管理番号 B24264 To
// 管理番号K27057 From
			customItemHead.Validate(puDate, AddErrorMessage);
// 管理番号K27057 To
			//明細有効行の存在チェック
			if(!HasValidRows)
			{
// 				AddErrorMessage(AllegroMessage.S10006("明細")); //K24546
				AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS001939")));
			}
			// 管理番号 B14028 From
			bool hasOverFlow = false;
			// 管理番号 B14028 To
// 管理番号 K24789 From
			bool hasCtaxCombinationError = false;
// 管理番号 K24789 To
			//ロット詳細、明細の相関チェック
			foreach(DataRow dRow in this.dt.Rows)
			{
				decimal lineId = (decimal)dRow["PU_LINE_ID"];
				decimal puQt   = (decimal)dRow["PU_QT"];
				decimal initQt = (decimal)dRow["UPPER_LIMIT_PU_QT"];
				string isRcptExe = dRow["IS_RCPT_EXECUTE"].ToString();
				string errorNo = dRow["PU_LINE_NO"].ToString();
				// 管理番号 B14315 From
				decimal transitRcptQt   = (decimal)dRow["TRANSIT_RCPT_QT"];
				// 管理番号 B14315 To
				//必須
// 管理番号B27043 From
				// 商品の存在チェック
				// (明細行更新時のチェック処理に合わせて、国内のみ行う)
				if (this.overseasFlg == "0")
				{
					if (this.puModeType != "4")
					{
						// 発注する商品でない場合、エラーとする
						if (!Prod.IsExists(commonData, dRow["PROD_CODE"].ToString(), "PO", string.Empty))
						{
							// 行目：商品
							AddErrorMessage(AllegroMessage.S20005(errorNo + MultiLanguage.Get("SC_CS003427")));
						}
					}
					else
					{
						// 仕入形態が預りかつ、発注する商品かつ在庫管理する商品でない場合、エラーとする
						if (!(Prod.IsExists(commonData,  dRow["PROD_CODE"].ToString(), "PO", string.Empty)
								&& (Prod.GetStockAdminFlg(commonData, dRow["PROD_CODE"].ToString()) == "1")))
						{
							// 行目：商品
							AddErrorMessage(AllegroMessage.S20005(errorNo + MultiLanguage.Get("SC_CS003427")));
						}
					}
				}
// 管理番号B27043 To
				if (puQt == 0)
				{
// 					AddErrorMessage(AllegroMessage.S10017(errorNo, "数量","0")); //K24546
					AddErrorMessage(AllegroMessage.S10017(errorNo, MultiLanguage.Get("SC_CS001259"),"0"));
					return;
				}
// 管理番号 K24285 From
				//仕入形態が通常・返品以外の場合、マイナス数量は許可しない
				if ((this.puModeType!="1" && this.puModeType!="2") && puQt < 0)
				{
// 					AddErrorMessage(AllegroMessage.S10023("数量")); //K24546
					AddErrorMessage(AllegroMessage.S10023(MultiLanguage.Get("SC_CS001259")));
					return;
				}
// 管理番号 K24285 To

// 管理番号 K24153 From
                                // 明細倉庫コードが直送倉庫を指定し、かつヘッダ納入区分が自社倉庫の場合
                                if (dRow["WH_CODE"].ToString() == this.DirectWhCode && this.deliType == "W")
                                {
                                        AddErrorMessage(AllegroMessage.SC_MM_05_S10001);
                                        return;
                                }
// 管理番号 K24153 To

				//上限値
				if (initQt < puQt )
				{
// 管理番号 K24285 From
//					if (this.puModeType=="2" && this.refPuNo.Length > 0)
//					{
//						AddErrorMessage(AllegroMessage.SC_MM_05_S02_06);
//						return;
//					}
//					else if(isRcptExe =="1")
					if(isRcptExe =="1")
// 管理番号 K24285 To
					{
						AddErrorMessage(AllegroMessage.SC_MM_05_S02_05);
						return;
					}
				}
// 管理番号 K24285 From
				// 仕入参照返品時の数量上限・下限チェック
				if(this.puModeType=="2" && this.refPuNo.Length > 0)
				{
					if (initQt < 0)
					{
						if (puQt > 0)
						{
							//マイナス仕入数(初期値)の場合、プラス返品数量の入力不可
							AddErrorMessage(AllegroMessage.SC_MM_05_S02_12);
							return;
						}
						else if (puQt < initQt)
						{
							//マイナス仕入数(初期値)の場合、初期値以下の入力不可
							AddErrorMessage(AllegroMessage.SC_MM_05_S02_11);
							return;
						}
					}
					else if (initQt > 0)
					{
						if (puQt < 0)
						{
							//プラス仕入数(初期値)の場合、マイナス返品数量の入力不可
							AddErrorMessage(AllegroMessage.SC_MM_05_S02_13);
							return;
						}
						else if (initQt < puQt)
						{
							//プラス仕入数(初期値)の場合、初期値以上の入力不可
							AddErrorMessage(AllegroMessage.SC_MM_05_S02_06);
							return;
						}
					}
				}
// 管理番号 K24285 To
				// 管理番号 B14298 From
// 管理番号 K24789 From
//				// 消費税区分の存在チェック
//				string tmpCtaxTypeCode = this.puModeType == "2" ? this.puReturnCtaxTypeCode : this.puCtaxTypeCode;
//				if (!CtaxTypeCtaxRateRelation.IsExists(commonData, tmpCtaxTypeCode + dRow["CTAX_RATE_CODE"].ToString()))
//				{
//					AddErrorMessage(lineId + " 行目："+ AllegroMessage.SC_MS_S10016);
//				}
				
				if (!hasCtaxCombinationError
					&& (this.overseasFlg == "1" || this.imposeFlg == "0"))	
				{
					if (dRow["CTAX_CALC_TYPE"].ToString() != "N")				// 海外または課税しない、かつ消費税計算区分が「外税」「内税」
					{
						//[仕入先]の消費税区分と明細の[消費税計算区分］の組合せが不正です。[仕入先］マスタが変更されていないかをご確認ください。
						AddErrorMessage(AllegroMessage.S20045(MultiLanguage.Get("SC_CS000784"), MultiLanguage.Get("CM_CS002952")));
						hasCtaxCombinationError = true;
					}
				}
				else if (!hasCtaxCombinationError && this.imposeFlg == "1")
				{
					if (dRow["CTAX_CALC_TYPE"].ToString() == "N")				// 課税する、かつ消費税計算区分が「計算しない」
					{
						//[仕入先]の消費税区分と明細の[消費税計算区分］の組合せが不正です。[仕入先］マスタが変更されていないかをご確認ください。
						AddErrorMessage(AllegroMessage.S20045(MultiLanguage.Get("SC_CS000784"), MultiLanguage.Get("CM_CS002952")));
						hasCtaxCombinationError = true;
					}
				}
				string ctaxRate = string.Empty;
				string ctaxSubjectType = string.Empty;
				if (CtaxTypeCtaxRateRelation.GetCtaxRate(commonData, dRow["CTAX_TYPE_CODE"].ToString() + dRow["CTAX_RATE_CODE"].ToString(),
					dealDate.ToString(), false, out ctaxRate, out ctaxSubjectType))
				{
					if (ctaxSubjectType == "N" && dRow["CTAX_CALC_TYPE"].ToString() != "N")
					{
						// 消費税科目区分が「なし」、かつ消費税計算区分が「外税」「内税」
						//errorNo 行目：  消費税区分の税科目がなしの場合、国内でかつ課税する[仕入先]は指定できません。
						AddErrorMessage(errorNo + MultiLanguage.Get("SC_CS003420") + AllegroMessage.S20044(MultiLanguage.Get("SC_CS000784")));
					}
				}
				else
				{
					//errorNo行目：<消費税率>が取得できませんでした。<消費税>のマスタをご確認ください。
					AddErrorMessage(AllegroMessage.S10079(errorNo, MultiLanguage.Get("SC_CS001210"), MultiLanguage.Get("CM_CS002946")));
				}
// 管理番号 K24789 To
// 管理番号 B15722 From
				// 単価小数チェック
				//				if (priceDecimalUseFlg)
				//				{
				//					ValidateDecimalForSqlParameter("仕入単価", 
				//						dRow["PU_PRICE"].ToString(), true, false, (byte) 13, (byte) 2);
				//				}
				//				else
				//				{
				//					ValidateDecimalForSqlParameter("仕入単価", dRow["PU_PRICE"].ToString(), true, false, 
				//						(byte) (11 + int.Parse(curDigit.ToString())), byte.Parse(curDigit));
				//				}			
				// 単価小数チェック
				if (priceDecimalUseFlg)
				{
// 管理番号 K25647 From
//// 					ValidateDecimalForSqlParameter("仕入単価",  //K24546
//					ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS000802"), 
//						dRow["PU_PRICE"].ToString(), true, false, (byte) 13, (byte) 2);
					ValidateSlipPriceForSqlParameter(MultiLanguage.Get("SC_CS000802"),　
						dRow["PU_PRICE"].ToString(), true, false, this.priceDecimalDigit, byte.Parse(this.curDigit));
// 管理番号 K25647 To
				}
				else
				{
					decimal puPrice = decimal.Parse(dRow["PU_PRICE"].ToString());
// 管理番号 K25647 From
//// 管理番号 B15952 From
////					ValidateDecimalForSqlParameter("仕入単価", puPrice.ToString("#.##"), true, false, 
////						(byte) (11 + int.Parse(curDigit.ToString())), byte.Parse(curDigit));
//// 					ValidateDecimalForSqlParameter("仕入単価", puPrice.ToString("0.##"), true, false,  //K24546
//					ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS000802"), puPrice.ToString("0.##"), true, false, 
//						(byte) (11 + int.Parse(curDigit.ToString())), byte.Parse(curDigit));
//// 管理番号 B15952 To
					ValidateSlipPriceForSqlParameter(MultiLanguage.Get("SC_CS000802"), puPrice.ToString("#0.#####"), true, false, 
						this.priceDecimalDigit, byte.Parse(this.curDigit));
// 管理番号 K25647 To
				}			
// 管理番号 B15722 To
				// 管理番号 B14298 To

				// 管理番号 B14315 From
				// 入荷数量との数量比較
//管理番号 B19369 From
//				if (overseasFlg == "1" && puModeType == "2" && transitRcptQt > 0 && puQt > transitRcptQt)
//				{
//					//入荷数量以上の返品はエラー
//					AddErrorMessage(AllegroMessage.SC_MM_05_S04_03);
//					return;
//				}

				if ((this.OverseasFlg == "1" && this.PuModeType == "2" && this.RcptInputNoNeedFlg == "1" &&
						transitRcptQt > 0 && puQt > transitRcptQt) ||
					(this.OverseasFlg == "1" && this.PuModeType == "2" && this.RcptInputNoNeedFlg == "0" &&
						initQt > 0 && puQt > initQt)) 
				{
					//入荷数量以上の返品はエラー
					AddErrorMessage(AllegroMessage.SC_MM_05_S04_03);
					return;
				}
//管理番号 B19369 To
				// 管理番号 B14315 To

				//ロット明細
				int lotCnt = this.lotDt.Select("[ROW_ID]=" + lineId).Length;
				if (lotCnt == 0)
				{
// 管理番号 B22792 From
//					// 管理番号 B13500 From
//					//					if(dRow["LOT_ADMIN_FLG"].ToString() == "1" && dRow["WH_CODE"].ToString() != DirectWhCode)
//					if(dRow["LOT_ADMIN_FLG"].ToString() == "1" && dRow["WH_CODE"].ToString() != DirectWhCode
//// 管理番号 B17548 From
////						&& this.RcptInputNoNeedFlg == "1" && this.PuModeType == "1")
//						&& this.RcptInputNoNeedFlg == "1")
//// 管理番号 B17548 To
//						// 管理番号 B13500 To
//					{
//						AddErrorMessage(AllegroMessage.S10006(errorNo , "ロット明細"));
//					}

					if (this.OverseasFlg == "1")
					{
// 管理番号 K25322 From
//						if(dRow["LOT_ADMIN_FLG"].ToString() == "1" && dRow["WH_CODE"].ToString() != DirectWhCode
//							&& this.RcptInputNoNeedFlg == "1")
						if((dRow["LOT_ADMIN_FLG"].ToString() == "1" && dRow["WH_CODE"].ToString() != DirectWhCode
							&& this.RcptInputNoNeedFlg == "1") || dRow["LOT_STOCK_VALUATION_FLG"].ToString() == "1")
// 管理番号 K25322 To
						{
// 							AddErrorMessage(AllegroMessage.S10006(errorNo , "ロット明細")); //K24546
							AddErrorMessage(AllegroMessage.S10006(errorNo , MultiLanguage.Get("SC_CS002909")));
						}
					}
					else
					{
// 管理番号 K25322 From
//						if(dRow["LOT_ADMIN_FLG"].ToString() == "1" && dRow["WH_CODE"].ToString() != DirectWhCode)
						if((dRow["LOT_ADMIN_FLG"].ToString() == "1" && dRow["WH_CODE"].ToString() != DirectWhCode) || dRow["LOT_STOCK_VALUATION_FLG"].ToString() == "1")
// 管理番号 K25322 To
						{
// 							AddErrorMessage(AllegroMessage.S10006(errorNo , "ロット明細")); //K24546
							AddErrorMessage(AllegroMessage.S10006(errorNo , MultiLanguage.Get("SC_CS002909")));
						}
					}
// 管理番号 B22792 To
				}
				else
				{
					object objSum = this.lotDt.Compute("SUM([EDIT_QT])", "[ROW_ID]=" + lineId);
					decimal lotSumQt = objSum is decimal ? (decimal)objSum : 0M;

// 管理番号 B22792 From
//					// 管理番号 B13500 From
//					//					if (puQt != lotSumQt && this.RcptInputNoNeedFlg == "1")
//// 管理番号 B17548 From
////					if (puQt != lotSumQt && this.RcptInputNoNeedFlg == "1" && this.PuModeType == "1")
//					if (puQt != lotSumQt && this.RcptInputNoNeedFlg == "1")
//// 管理番号 B17548 To
//						// 管理番号 B13500 To
//					{
//						AddErrorMessage(AllegroMessage.S10042(Int32.Parse(errorNo), "明細の数量", "ロット明細の合計数量"));
//					}

					if (this.OverseasFlg == "1")
					{
// 管理番号 K25322 From
//						if (puQt != lotSumQt && this.RcptInputNoNeedFlg == "1")
						if (puQt != lotSumQt && (this.RcptInputNoNeedFlg == "1" || dRow["LOT_STOCK_VALUATION_FLG"].ToString() == "1"))
// 管理番号 K25322 To
						{
// 							AddErrorMessage(AllegroMessage.S10042(Int32.Parse(errorNo), "明細の数量", "ロット明細の合計数量")); //K24546
							AddErrorMessage(AllegroMessage.S10042(Int32.Parse(errorNo), MultiLanguage.Get("SC_CS005477"), MultiLanguage.Get("SC_CS002910")));
						}
					}
					else
					{
						if (puQt != lotSumQt)
						{
// 							AddErrorMessage(AllegroMessage.S10042(Int32.Parse(errorNo), "明細の数量", "ロット明細の合計数量")); //K24546
							AddErrorMessage(AllegroMessage.S10042(Int32.Parse(errorNo), MultiLanguage.Get("SC_CS005477"), MultiLanguage.Get("SC_CS002910")));
						}
					}
// 管理番号 B22792 To
// 管理番号 K25322 From
					//ロット評価対象商品
					if (dRow["LOT_STOCK_VALUATION_FLG"].ToString() == "1")
					{
						//ロット評価対象&複数ロット入力時はエラー
						DataView lotDv	= new DataView(this.lotDt);
						lotDv.RowFilter	= "ROW_ID =" + lineId + " AND EDIT_QT > 0";
						DataTable distinctLotdt = lotDv.ToTable("distinctLotdt", true, new string[] { "LOT_NO" });

						// 複数ロットが引当されている場合、エラー
						if (distinctLotdt.Rows.Count > 1)
						{
							// ロット別在庫評価をする商品の場合、1明細に複数のロットは指定できません。
							AddErrorMessage(AllegroMessage.SC_MS_S10052(dRow["PU_LINE_NO"].ToString())); 
						}
					}
// 管理番号 K25322 To
				}
				// 管理番号 B13500 From
				if(this.RcptInputNoNeedFlg == "0" && (dRow["STOCK_ADMIN_FLG"].ToString() == "0" ||dRow["WH_CODE"].ToString() == DirectWhCode))
				{
					errCnt++;
				}

				// 管理番号 B14028 From
				// オーバーフロー
				if (!hasOverFlow)
				{
					decimal curRate = (rate.Length != 0) ? decimal.Parse(rate) : 1M;
					decimal taxRate = dRow["CTAX_RATE"] is decimal ? (decimal) dRow["CTAX_RATE"] : 0M;
					decimal dtilAmt = dRow["PU_MONEY"] is decimal ? (decimal) dRow["PU_MONEY"] : 0M;
					decimal dtilPrice = (dRow["CTAX_CALC_TYPE"].Equals("E") ? (dtilAmt * (1M + taxRate / 100M)) : dtilAmt) * curRate;
					if (dtilPrice < -99999999999M || 99999999999M < dtilPrice)
					{
// 						AddErrorMessage(AllegroMessage.S10015("仕入金額")); //K24546
						AddErrorMessage(AllegroMessage.S10015(MultiLanguage.Get("SC_CS000775")));
						hasOverFlow = true;
						break;
					}
				}
				// 管理番号 B14028 To
// 管理番号 K25647 From
					// 入数
					decimal includeQt = Unit.GetIncludeQt(commonData, dRow["PROD_CODE"].ToString(), dRow["UNIT_CODE"].ToString());

					// 在庫単位換算数量チェック
					if (!StockUnitConversionCheck((decimal)dRow["PU_QT"], includeQt))
					{
						//%s 行目：［在庫単位数量］の小数点以下の桁数が %d 桁を超えました。（入数［%d］）
						AddErrorMessage(errorNo + MultiLanguage.Get("SC_CS003420") + AllegroMessage.SC_MS_S10056(this.myCompQtDecimalUseFlg ? 4 : 0, includeQt));
					}
// 管理番号 K25647 To
// 管理番号K27525 From
					// 帳簿控除理由コード(国内のみ)
					if (this.overseasFlg != "1" && dRow["BOOK_DEDUCTION_REASON_CODE"].ToString().Length > 0)
					{
						// 帳簿控除理由コードの存在チェック
						if (!BookDeductionReason.IsExists(commonData, dRow["BOOK_DEDUCTION_REASON_CODE"].ToString(), "SM3"))
						{
							// %s 行目：［帳簿控除理由］ がマスタにないか、有効ではありません。
							AddErrorMessage(errorNo + MultiLanguage.Get("SC_CS003420") + AllegroMessage.S20005(MultiLanguage.Get("SC_CS006632")));
						}
						// 消費税区分コードとの関連チェック
						else if (dRow["CTAX_TYPE_CODE"].ToString() == "T")
						{
							// %s 行目：［消費税区分］が控除外課税仕入の場合、［帳簿控除理由］は選択できません。
							AddErrorMessage(AllegroMessage.SC_MM_S10006(errorNo, MultiLanguage.Get("CM_CS000884"), MultiLanguage.Get("SC_CS006632")));
						}
					}
// 管理番号K27525 To
// 管理番号K27057 From
				// 明細汎用項目のバリデートを行うためにダミーのIFにセットします。customItemDtilを参照してデータ更新は行いません。
				SetCustomItemValidator(customItemDtil);
				// 行目：
				customItemDtil.Validate(dRow, PuDate, AddErrorMessage, errorNo + MultiLanguage.Get("SC_CS003420"));
// 管理番号K27057 To
				ttlCnt++;
			}
			if (errCnt == ttlCnt)
			{
				AddErrorMessage(AllegroMessage.SC_MM_05_S04_02);
			}
			// 管理番号 B13500 To
			// 支払条件チェック
			if (this.dtType == "E")
			{
				// 基準金額、比率、支払方法2をチェック
				if (this.dt1BasisAmt.Length != 0)
				{
					if (this.dt2Ratio.Length == 0)
					{
// 						AddErrorMessage(AllegroMessage.S10008("基準金額", "比率")); //K24546
						AddErrorMessage(AllegroMessage.S10008(MultiLanguage.Get("SC_CS003122"), MultiLanguage.Get("SC_CS005323")));
					}
					if (this.dt2SttlMthdCode.Length == 0)
					{
// 						AddErrorMessage(AllegroMessage.S10008("基準金額", "支払方法2")); //K24546
						AddErrorMessage(AllegroMessage.S10008(MultiLanguage.Get("SC_CS003122"), MultiLanguage.Get("SC_CS003806")));
					}
				}
				if (this.dt2Ratio.Length != 0)
				{
					if (this.dt1BasisAmt.Length == 0)
					{
// 						AddErrorMessage(AllegroMessage.S10008("比率", "基準金額")); //K24546
						AddErrorMessage(AllegroMessage.S10008(MultiLanguage.Get("SC_CS005323"), MultiLanguage.Get("SC_CS003122")));
					}
					if (this.dt2SttlMthdCode.Length == 0)
					{
// 						AddErrorMessage(AllegroMessage.S10008("比率", "支払方法2")); //K24546
						AddErrorMessage(AllegroMessage.S10008(MultiLanguage.Get("SC_CS005323"), MultiLanguage.Get("SC_CS003806")));
					}
				}
				if (this.dt2SttlMthdCode.Length != 0)
				{
					if (this.dt1BasisAmt.Length == 0)
					{
// 						AddErrorMessage(AllegroMessage.S10009("支払方法2", "基準金額")); //K24546
						AddErrorMessage(AllegroMessage.S10009(MultiLanguage.Get("SC_CS003806"), MultiLanguage.Get("SC_CS003122")));
					}
					if (this.dt2Ratio.Length == 0)
					{
// 						AddErrorMessage(AllegroMessage.S10009("支払方法2", "比率")); //K24546
						AddErrorMessage(AllegroMessage.S10009(MultiLanguage.Get("SC_CS003806"), MultiLanguage.Get("SC_CS005323")));
					}
				}
				// 支払方法3をチェック
				if (this.dt2Ratio.Length != 0 && Decimal.Parse(this.dt2Ratio) < 100)
				{
					if (this.dt3SttlMthdCode.Length == 0)
					{
						AddErrorMessage(AllegroMessage.SC_MM_05_S02_07);
					}
				}
				// サイトをチェック
				string type1 = SttlMthd.GetSttlType(commonData, this.dt1SttlMthdCode);
				string type2 = SttlMthd.GetSttlType(commonData, this.dt2SttlMthdCode);
				string type3 = SttlMthd.GetSttlType(commonData, this.dt3SttlMthdCode);
				if (type1 == "N" || type1 == "D" || type2 == "N" || type2 == "D" || type3 == "N" || type3 == "D")
				{
					if (this.dtSight.Length == 0)
					{
						AddErrorMessage(AllegroMessage.SC_MM_05_S02_08);
					}
				}
//管理番号 B24873 From
				if (this.OverseasFlg == "0")
				{
					if ((this.Dt2Ratio.Length != 0) && (this.Dt2Ratio != "100") &&
						(this.Dt2SttlMthdCode.Length != 0) && (this.Dt3SttlMthdCode.Length != 0))
					{
// 管理番号B27005 From
						if (!CM.MS.SttlMthd.CheckMultiSttlType(commonData, new string[] { this.Dt2SttlMthdCode, this.Dt3SttlMthdCode }))
						{
							// 決済方法(決済パターン)
							AddErrorMessage(AllegroMessage.S10046(MultiLanguage.Get("SC_CS006355") + "(" + MultiLanguage.Get("SC_CS006356") + ")"));
						}
// 管理番号B27005 To
						if (!CM.MS.SttlMthd.CheckMultiLedger(commonData, new string[] { this.Dt2SttlMthdCode, this.Dt3SttlMthdCode }))
						{
							AddErrorMessage(AllegroMessage.S20047);
						}
					}
				}
				else 
				{
					ArrayList al = new ArrayList();
					foreach (IF_SC_MS_OverseasDT overseasDt in overseas)
					{
						if (overseasDt.SttlMthdCode.Length != 0) al.Add(overseasDt.SttlMthdCode);
					}
					if (al.Count > 1)
					{
// 管理番号B27005 From
						if (!CM.MS.SttlMthd.CheckMultiSttlType(commonData, (string[])al.ToArray(typeof(string))))
						{
							// 決済方法(決済パターン)
							AddErrorMessage(AllegroMessage.S10046(MultiLanguage.Get("SC_CS006355") + "(" + MultiLanguage.Get("SC_CS006356") + ")"));
						}
// 管理番号B27005 To
						if (!CM.MS.SttlMthd.CheckMultiLedger(commonData, (string[])al.ToArray(typeof(string))))
						{
							AddErrorMessage(AllegroMessage.S20047);
						}
					}
				}
//管理番号 B24873 To
			}
// 管理番号K27154 From
			// 取引区分
			if (!DealType.IsExists(commonData, this.dealTypeCode))
			{
				// 取引区分
				AddErrorMessage(AllegroMessage.S20006(MultiLanguage.Get("SC_CS006354")));
			}
// 管理番号K27154 To
			// 管理番号 B14028 From
			if (grandTtl <= -1000000000000 || 1000000000000 <= grandTtl || keyGrandTtl <= -1000000000000 || 1000000000000 <= keyGrandTtl)
			{
// 				AddErrorMessage(AllegroMessage.S10015("総合計")); //K24546
				AddErrorMessage(AllegroMessage.S10015(MultiLanguage.Get("SC_CS001410")));
			}
			// 管理番号 B14028 To
		}
// 管理番号 K25647 From
		/// <summary>
		/// 在庫単位換算チェック
		/// </summary>
		/// <param name="decimalQt">数量</param>
		/// <param name="includeQt">入数</param>
		/// <returns>小数の桁数が範囲内に収まっている場合true</returns>
		private bool StockUnitConversionCheck(decimal decimalQt, decimal includeQt)
		{
			// 数量小数を使用する場合、小数部を5位で丸めた値と比較する
			// 一致しない場合、小数部が4桁に収まっていない
			// 数量小数を使用しない場合、小数部を丸めた値と比較する
			// 一致しない場合、小数部が0ではない
			return (decimalQt * includeQt) == decimal.Round(decimalQt * includeQt, this.myCompQtDecimalUseFlg ? 4 : 0);
		}
// 管理番号 K25647 To
		//仕入先コード分割
		public void DivideSuplCode(string code, byte codeLength)
		{
// 			DivideCombinationCode("仕入先コード", code, codeLength, out this.suplCode, out this.suplSbno, CombinationCodeOption.Comp); //K24546
			DivideCombinationCode(MultiLanguage.Get("SC_CS000786"), code, codeLength, out this.suplCode, out this.suplSbno, CombinationCodeOption.Comp);
		}
		public void DivideSuplCode(string suplCode, byte suplCodeLength, out string suplC, out string suplS)
		{
// 			DivideCombinationCode("仕入先コード", suplCode, suplCodeLength, out suplC, out suplS, CombinationCodeOption.Comp); //K24546
			DivideCombinationCode(MultiLanguage.Get("SC_CS000786"), suplCode, suplCodeLength, out suplC, out suplS, CombinationCodeOption.Comp);
		}
		//プロジェクトコード分割
		public void DivideProjCode(string code, byte projCodeLength)
		{
// 			DivideCombinationCode("プロジェクトコード", code, projCodeLength, out this.projCode, out this.projSbno, CombinationCodeOption.Proj); //K24546
			DivideCombinationCode(MultiLanguage.Get("SC_CS000233"), code, projCodeLength, out this.projCode, out this.projSbno, CombinationCodeOption.Proj);
		}
		public void DivideProjCode(string code, byte projCodeLength, out string projCode, out string projSbNo)
		{
// 			DivideCombinationCode("プロジェクトコード", code, projCodeLength, out projCode, out projSbNo, CombinationCodeOption.Proj); //K24546
			DivideCombinationCode(MultiLanguage.Get("SC_CS000233"), code, projCodeLength, out projCode, out projSbNo, CombinationCodeOption.Proj);
		}
		//納入先コード分割
		public void DivideDeliCustCode(string deliCustCode, byte deliCustCodeLength)
		{
// 			DivideCombinationCode("納入先コード", deliCustCode, deliCustCodeLength, out this.deliCustCode, out this.deliCustSbno, CombinationCodeOption.Comp); //K24546
			DivideCombinationCode(MultiLanguage.Get("SC_CS005104"), deliCustCode, deliCustCodeLength, out this.deliCustCode, out this.deliCustSbno, CombinationCodeOption.Comp);
		}

// 管理番号 B24959 From
		//雑仕入先情報チェック
		public void tempSuplInfoValidate(CommonData commonData)
		{
			if (tempCodeFlg == "1")
			{
				//必須チェック
				if (tempSuplHt["TEMP_SUPL_NAME"].ToString().Length == 0)
				{
					//雑仕入先の仕入先名
					AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003587")));
				}
				if (tempSuplHt["TEMP_SUPL_SHORT_NAME"].ToString().Length == 0)
				{
					//雑仕入先の仕入先略名
					AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003588")));
				}
				if (tempSuplHt["TEMP_SUPL_COUNTRY_CODE"].ToString().Length == 0)
				{
					//雑仕入先の国コード
					AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003586")));
				}
				if (tempSuplHt["TEMP_SUPL_ZIP"].ToString().Length == 0)
				{
					//雑仕入先の郵便番号
					AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003596")));
				}
				if (tempSuplHt["TEMP_SUPL_STATE"].ToString().Length == 0)
				{
					//雑仕入先の都道府県
					AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003595")));
				}
				if (tempSuplHt["TEMP_SUPL_CITY"].ToString().Length == 0)
				{
					//雑仕入先の市区町村
					AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003589")));
				}
				if (tempSuplHt["TEMP_SUPL_ADDRESS1"].ToString().Length == 0)
				{
					//雑仕入先の町域名
					AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003593")));
				}
				if (tempSuplHt["TEMP_SUPL_PHONE"].ToString().Length == 0)
				{
					//雑仕入先の電話番号
					AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003594")));
				}
				switch (tempSuplHt["AC_TYPE"].ToString())
				{
					case "B":
						if (tempSuplHt["AC_HOLDER"].ToString().Length == 0)
						{
							//雑仕入先の口座名義人
							AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003585")));
						}
						if (tempSuplHt["AC_NO"].ToString().Length == 0)
						{
							//雑仕入先の口座番号
							AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003584")));
						}
						if (tempSuplHt["BANK_AC_TYPE"].ToString().Length == 0)
						{
							//雑仕入先の口座種別
							AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003583")));
						}
						if (tempSuplHt["BANK_COUNTRY_CODE"].ToString().Length == 0)
						{
							//雑仕入先の銀行国コード
							AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003582")));
						}
						if (tempSuplHt["BANK_CODE"].ToString().Length == 0)
						{
							//雑仕入先の銀行コード
							AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003581")));
						}
						if (tempSuplHt["BANK_BRANCH_CODE"].ToString().Length == 0)
						{
							//雑仕入先の支店コード
							AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003590")));
						}
						break;
					case "A":
						if (this.keyCurCode != this.curCode)
						{
							AddErrorMessage(AllegroMessage.FI_AP_S10001);
							return;
						}
						if (tempSuplHt["AC_HOLDER"].ToString().Length == 0)
						{
							//雑仕入先の口座名義人
							AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003585")));
						}
						if (tempSuplHt["AC_NO"].ToString().Length == 0)
						{
							//雑仕入先の口座番号
							AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003584")));
						}
						if (tempSuplHt["BANK_COUNTRY_CODE"].ToString().Length == 0)
						{
							//雑仕入先の銀行国コード
							AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003582")));
						}
						if (tempSuplHt["BANK_CODE"].ToString().Length == 0)
						{
							//雑仕入先の銀行コード
							AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003581")));
						}
						if (tempSuplHt["BANK_BRANCH_CODE"].ToString().Length == 0)
						{
							//雑仕入先の支店コード
							AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003590")));
						}
						break;
					case "P":
						if (this.keyCurCode != this.curCode)
						{
							AddErrorMessage(AllegroMessage.FI_AP_S10001);
							return;
						}
						if (tempSuplHt["AC_HOLDER"].ToString().Length == 0)
						{
							//雑仕入先の口座名義人
							AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003585")));
						}
						if (tempSuplHt["AC_NO"].ToString().Length == 0)
						{
							//雑仕入先の口座番号
							AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS003584")));
						}
						break;
				}

				//存在チェック
				if (tempSuplHt["TEMP_SUPL_COUNTRY_CODE"].ToString().Length > 0)
				{
					if (!CM.MS.Country.IsExists(commonData, tempSuplHt["TEMP_SUPL_COUNTRY_CODE"].ToString()))
					{
						//雑仕入先の国コード
						AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS003586")));
					}
				}
				if (tempSuplHt["BANK_COUNTRY_CODE"].ToString().Length > 0)
				{
					if (!CM.MS.Country.IsExists(commonData, tempSuplHt["BANK_COUNTRY_CODE"].ToString()))
					{
						//雑仕入先の銀行国コード
						AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS003582")));
					}
					if (tempSuplHt["BANK_CODE"].ToString().Length > 0)
					{
						if (!CM.MS.Bank.IsExists(commonData, tempSuplHt["BANK_COUNTRY_CODE"].ToString(), tempSuplHt["BANK_CODE"].ToString()))
						{
							//雑仕入先の銀行コード
							AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS003581")));
						}
						if (tempSuplHt["BANK_BRANCH_CODE"].ToString().Length > 0)
						{
							if (!CM.MS.BankBranch.IsExists(commonData, tempSuplHt["BANK_COUNTRY_CODE"].ToString(), tempSuplHt["BANK_CODE"].ToString(), tempSuplHt["BANK_BRANCH_CODE"].ToString()))
							{
								//雑仕入先の支店コード
								AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS003590")));
							}
						}
					}
				}
			}
		}
// 管理番号 B24959 To
// 管理番号K27057 From
		/// <summary>
		/// 汎用項目のIFにバリデータを委譲する。
		/// </summary>
		/// <param name="customItem">
		/// 汎用項目のIF
		/// </param>
		public void SetCustomItemValidator(IF_CM_MS_CustomItem customItem)
		{
			customItem.SetValidator(ValidateDecimalString, ValidateString, ValidateChoiceString, ValidateDateTimeString);
		}
// 管理番号K27057 To
		#endregion
	}

	[Serializable()]
	public class IF_SC_MM_05_DetailRowData : Infocom.Allegro.IF.IFBase
	{
		#region protected Fields
		//仕入明細テーブル
		protected decimal	puLineId				= 0M;				// 行ID
		protected string	prodCode				= string.Empty;		// 商品コード
		protected string	prodPuName				= string.Empty;		// 商品発注名
		protected string	prodShortName			= string.Empty;		// 商品略名
		protected string	prodName					= string.Empty;		// 商品名
		protected string	prodSpec1Code			= string.Empty;		// 商品規格1コード
		protected string	prodSpec2Code			= string.Empty;		// 商品規格2コード
		protected string	prodSpec1Name			= string.Empty;		// 商品規格1名
		protected string	prodSpec2Name			= string.Empty;		// 商品規格2名
		protected string	whCode					= string.Empty;		// 倉庫コード
		protected string	whShortName				= string.Empty;		// 倉庫名
		protected decimal	puQt					= 0M;				// 仕入数量
		protected decimal   upperLimitPuQt			= 0M;				// 仕入数量(上限値)
		protected decimal   stockUnitPoPuQt			= 0M;				// 発注仕入数量
		protected string	unitCode				= string.Empty;		// 単位コード
		protected string	unitShortName			= string.Empty;		// 単位名
		protected decimal	stdSellPrice			= 0M;				// 標準単価
		protected decimal	puPrice					= 0M;				// 仕入単価(入力値)
		protected decimal	initPuPrice				= 0M;				// 仕入単価(変更前)
		protected decimal	puPlanPrice				= 0M;				// 仕入予定単価
		protected string	prodType				= string.Empty;		// 商品区分
		protected string	stockAdminFlg			= string.Empty;		// 在庫管理フラグ
		protected string	lotAdminFlg				= string.Empty;		// ロット管理フラグ
// 管理番号 K25322 From
		protected string	lotStockValuationFlg	= string.Empty;		// ロット別在庫評価フラグ
// 管理番号 K25322 To
		protected string	qtDecimalUseFlg			= string.Empty;		// 数量小数使用フラグ
		protected string	ctaxCalcType			= string.Empty;		// 消費税計算区分
		protected decimal	ctaxRate				= 0M;				// 消費税率
		protected string	ctaxRateCode			= string.Empty;		// 仕入税区分コード
		protected string	discFlg					= string.Empty;		// 値引フラグ
		// 管理番号 B13878 From
		protected string	priceUndecidedFlg		= string.Empty;		// 単価未決フラグ
		// 管理番号 B13878 To
		protected string	lineRemarksCode			= string.Empty;		// 行摘要コード
		protected string	lineRemarks				= string.Empty;		// 行摘要
// 管理番号K27525 From
		protected string	bookDeductionReasonCode	= string.Empty;		// 帳簿控除理由コード
		protected string	bookDeductionReasonName	= string.Empty;		// 帳簿控除理由
// 管理番号K27525 To
// 管理番号 K16671 From
		protected string	refCodeWord				= string.Empty;		// 参照コード文言
		protected string	refCode					= string.Empty;		// 参照コード
// 管理番号 K16671 To
		protected decimal	dtilAmt					= 0M;				// 明細金額
		protected decimal	etaxAmt					= 0M;				// 外税金額
		protected decimal	itaxAmt					= 0M;				// 内税金額
// 管理番号 B12929 From
//		protected string	priceUpdateFlg			= string.Empty;		// 得意先単価更新フラグ
		protected string	priceUpdateFlg			= "0";				// 仕入先単価更新フラグ
// 管理番号 B12929 To
		protected decimal	includeQt				= 0M;				// 入数
		protected decimal	validQt					= 0M;				// 有効在庫数量
		protected string	dispControlType			= string.Empty;		// 画面制御区分
		protected string	prodEditFlg				= string.Empty;		// 商品変更フラグ
		protected string	prodNameCorrectAllowFlg	= string.Empty;		// 商品名訂正許可フラグ
		protected string	multLotFlg				= string.Empty;		// 複数ロットフラグ
		protected string	isRcptExecute			= string.Empty;		// 入荷済み
		protected string    rcptInputNoNeedFlg		= "1";				// 入荷入力不要フラグ(デフォルト省略)
		protected string    poNo                    = string.Empty;		// 発注番号
		protected decimal   poLineId				= 0M;				// 発注行ID
		protected string    rcptNo                  = string.Empty;		// 入荷番号
		protected decimal   rcptLineId				= 0M;				// 入荷行ID
		//行更新チェック時のみ使用
		protected string	rowState				= string.Empty;		// RowState
		protected decimal	initQt					= 0M;				// 仕入数初期値
		protected decimal	myCompStockAllockQt		= 0M;				// 自社在庫引当数量
		//商品規格
		protected string	productSpecUseType		= string.Empty;		// Session["商品規格使用フラグ"]
		protected string	prodSpec1CodeTitle		= string.Empty;		// 規格１名称
		protected string	prodSpec2CodeTitle		= string.Empty;		// 規格２名称

		protected bool      isMod                   = false;			// 修正モード

		// 管理番号 B14315 From
		protected decimal   transitRcptQt			= 0M;				// 仕入数量(上限値)
		// 管理番号 B14315 To
// 管理番号 K24789 From
		protected string	ctaxTypeCode			= string.Empty;		// 仕入税区分コード
		protected string	taxInfoChgFlg			= string.Empty;		// 消費税情報変更フラグ
// 管理番号 K24789 To
// 管理番号 K25647 From
		protected byte		qtDecimalDigit				= (byte)0;
		protected string	curDigit					= string.Empty;		// 通貨.通貨小数桁数
		protected byte		priceDecimalDigit			= (byte)0;
// 管理番号 K25647 To
		//课题2 From
		/// <summary>
		/// 入力者名
		/// </summary>
		protected string inputEmpCode = string.Empty;
		/// <summary>
		/// 消费税小数舍入区分
		/// </summary>
		protected string ctaxFractionRoundType = string.Empty;
		/// <summary>
		/// 承运人代码
		/// </summary>
		protected string carrierCode = string.Empty;
		//课题2 To
		#endregion

		#region Properties PU_DTIL
		public virtual decimal PuLineId
		{
			get {return puLineId;}
		}
		public virtual string ProdCode
		{
			get {return prodCode;}
			set {prodCode = value;}
		}
		public virtual string ProdPuName
		{
			get {return prodPuName;}
			set {prodPuName = value;}
		}
		public virtual string ProdShortName
		{
			get {return prodShortName;}
			set {prodShortName = value;}
		}
		public virtual string ProdName
		{
			get {return prodName;}
			set {prodName = value;}
		}
		public virtual string ProdSpec1Code
		{
			get {return prodSpec1Code;}
			set {prodSpec1Code = value;}
		}
		public virtual string ProdSpec2Code
		{
			get {return prodSpec2Code;}
			set {prodSpec2Code = value;}
		}
		public virtual string ProdSpec1Name
		{
			get {return prodSpec1Name;}
			set {prodSpec1Name = value;}
		}
		public virtual string ProdSpec2Name
		{
			get {return prodSpec2Name;}
			set {prodSpec2Name = value;}
		}
		public virtual string WhCode
		{
			get {return whCode;}
			set {whCode = value;}
		}
		public virtual string WhShortName
		{
			get {return whShortName;}
			set {whShortName = value;}
		}
		public virtual string ProdType
		{
			get {return prodType;}
			set {prodType = value;}
		}
		public virtual string StockAdminFlg
		{
			get {return stockAdminFlg;}
			set {stockAdminFlg = value;}
		}
		public virtual string LotAdminFlg
		{
			get {return lotAdminFlg;}
			set {lotAdminFlg = value;}
		}
// 管理番号 K25322 From
		public virtual string LotStockValuationFlg
		{
			get {return lotStockValuationFlg;}
			set {lotStockValuationFlg = value;}
		}
// 管理番号 K25322 To
		public virtual string QtDecimalUseFlg
		{
			get {return qtDecimalUseFlg;}
			set {qtDecimalUseFlg = value;}
		}
		//消費税計算区分
		public virtual string CtaxCalcType
		{
			get {return ctaxCalcType;}
			set {ctaxCalcType = value;}
		}
		//消費税率
		public virtual decimal CtaxRate
		{
			get {return ctaxRate;}
		}
		public string CtaxRateCode
		{
			get {return ctaxRateCode;}
			set {ctaxRateCode = value;}
		}
		public virtual decimal PuPlanPrice
		{
			get {return puPlanPrice;}
		}
		public virtual string UnitCode
		{
			get {return unitCode;}
			set {unitCode = value;}
		}
		public virtual string UnitShortName
		{
			get {return unitShortName;}
			set {unitShortName = value;}
		}
		public virtual decimal PuQt
		{
			get {return puQt;}
		}
		public virtual decimal UpperLimitPuQt
		{
			get {return upperLimitPuQt;}
			set {upperLimitPuQt = value;}
		}
		public virtual decimal StockUnitPoPuQt
		{
			get {return stockUnitPoPuQt;}
			set {stockUnitPoPuQt = value;}
		}
		public virtual decimal StdSellPrice
		{
			get {return stdSellPrice;}
		}
		public virtual decimal PuPrice
		{
			get {return puPrice;}
		}
		public virtual decimal InitPuPrice
		{
			get {return initPuPrice;}
		}
		public virtual string DiscFlg
		{
			get {return discFlg;}
			set {discFlg = value;}
		}
		// 管理番号 B13878 From
		public virtual string PriceUndecidedFlg
		{
			get {return priceUndecidedFlg;}
			set {priceUndecidedFlg = value;}
		}
		// 管理番号 B13878 To
		public virtual string LineRemarksCode
		{
			get {return lineRemarksCode;}
			set {lineRemarksCode = value;}
		}
		public virtual string LineRemarks
		{
			get {return lineRemarks;}
			set {lineRemarks = value;}
		}
// 管理番号K27525 From
		public virtual string BookDeductionReasonCode
		{
			get {return bookDeductionReasonCode;}
			set {bookDeductionReasonCode = value;}
		}
		public virtual string BookDeductionReasonName
		{
			get {return bookDeductionReasonName;}
			set {bookDeductionReasonName = value;}
		}
// 管理番号K27525 To
// 管理番号 K16671 From
		public virtual string RefCodeWord
		{
			get {return refCodeWord;}
			set {refCodeWord = value;}
		}
		public virtual string RefCode
		{
			get {return refCode;}
			set {refCode = value;}
		}
// 管理番号 K16671 To
		public virtual decimal DtilAmt
		{
			get {return dtilAmt;}
			set {dtilAmt = value;}
		}
		public virtual decimal EtaxAmt
		{
			get {return etaxAmt;}
			set {etaxAmt = value;}
		}
		public virtual decimal ItaxAmt
		{
			get {return itaxAmt;}
			set {itaxAmt = value;}
		}
		public virtual string PriceUpdateFlg
		{
			get {return priceUpdateFlg;}
			set {priceUpdateFlg = value;}
		}
		public virtual decimal IncludeQt
		{
			get {return includeQt;}
		}
		public virtual decimal ValidQt
		{
			get {return validQt;}
		}
		public virtual decimal StockUnitPuQt
		{
			get {return puQt * includeQt;}
		}
		public virtual string DispControlType
		{
			get {return dispControlType;}
			set {dispControlType = value;}
		}
		public virtual string ProdEditFlg
		{
			get {return prodEditFlg;}
			set {prodEditFlg= value;}
		}
		public virtual string AllowProdName
		{
			get {return prodNameCorrectAllowFlg;}
			set {prodNameCorrectAllowFlg = value;}
		}
		public virtual string MultLotFlg
		{
			get {return multLotFlg;}
			set {multLotFlg = value;}
		}
		public virtual string IsRcptExecute
		{
			get {return isRcptExecute;}
			set {isRcptExecute = value;}
		}
		public virtual string RcptInputNoNeedFlg
		{
			get {return rcptInputNoNeedFlg;}
			set {rcptInputNoNeedFlg= value;}
		}
		public virtual string RowState
		{
			get{return rowState;}
			set{rowState = value;}
		}
		public virtual decimal InitQt
		{
			get{return initQt;}
			set{initQt = value;}
		}
		public virtual decimal MyCompStockAllockQt
		{
			get{return myCompStockAllockQt;}
			set{myCompStockAllockQt = value;}
		}
		public virtual string ProductSpecUseType
		{
			set {productSpecUseType = value;}
		}
		public virtual string ProdSpec1CodeTitle
		{
			set {prodSpec1CodeTitle = value;}
		}
		public virtual string ProdSpec2CodeTitle
		{
			set {prodSpec2CodeTitle = value;}
		}
		public virtual bool IsMod
		{
			get{return isMod;}
			set {isMod = value;}
		}
		public virtual string PoNo
		{
			get{return poNo;}
			set{poNo = value;}
		}
		public virtual decimal PoLineId
		{
			get{return poLineId;}
		}
		public virtual string RcptNo
		{
			get{return rcptNo;}
			set{rcptNo = value;}
		}
		public virtual decimal RcptLineId
		{
			get{return rcptLineId;}
		}

		// 管理番号 B14315 From
		public virtual decimal TransitRcptQt
		{
			get {return transitRcptQt;}
			set {transitRcptQt = value;}
		}
		// 管理番号 B14315 To
// 管理番号 K24789 From
		public virtual string CtaxTypeCode
		{
			get { return ctaxTypeCode; }
			set { ctaxTypeCode = value; }
		}
		public virtual string TaxInfoChgFlg
		{
			get { return taxInfoChgFlg; }
			set { taxInfoChgFlg = value; }
		}
// 管理番号 K24789 To
// 管理番号 K25647 From
		public virtual byte QtDecimalDigit        // 数量小数桁数
		{
			get { return qtDecimalDigit; }
			set { qtDecimalDigit = value; }
		}
		public virtual string CurDigit
		{
			get {return curDigit;}
			set {curDigit = value;}
		}
		public virtual byte PriceDecimalDigit
		{
			get { return priceDecimalDigit; }
			set { priceDecimalDigit = value; }
		}
		// 管理番号 K25647 To
		#endregion
		#region Properties PU_ADD
		//课题2 From 
		/// <summary>
		/// 入力者名
		/// </summary>
		public virtual string InputEmpCode
		{
			get { return inputEmpCode; }
			set { inputEmpCode = value; }
		}
		/// <summary>
		/// 消費税端数丸め区分
		/// </summary>
		public virtual string CtaxFractionRoundType
		{
			get { return ctaxFractionRoundType; }
			set { ctaxFractionRoundType = value; }
		}
		/// <summary>
		/// 運送業者コード
		/// </summary>
		public virtual string CarrierCode
		{
			get { return carrierCode; }
			set { carrierCode = value; }
		}
		//课题2 To
		#endregion
		#region Methods
		public virtual void SetPuLineId(string value)
		{
// 			object obj = ValidateDecimalForSqlParameter("行ID", value, true, false, 10, 0); //K24546
			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS000621"), value, true, false, 10, 0);
			puLineId = obj is decimal ? (decimal) obj : 0M;
		}
		public virtual void SetPuLineId(decimal value)
		{
			puLineId = value;
		}
		public virtual void SetPuQt(string value, bool allowDecimal)
		{
// 管理番号 K25647 From
//// 			object obj = ValidateDecimalForSqlParameter("数量", value, true, false, (byte) (allowDecimal ? 12 : 9), (byte) (allowDecimal ? 3 : 0)); //K24546
//			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS001259"), value, true, false, (byte) (allowDecimal ? 12 : 9), (byte) (allowDecimal ? 3 : 0));
			object obj = ValidateSlipQuantityForSqlParameter(MultiLanguage.Get("SC_CS001259"), value, true, false, allowDecimal ? this.qtDecimalDigit : (byte)0, IFBase.SlipQuantity.SCMM);
// 管理番号 K25647 To
			puQt = obj is decimal ? (decimal) obj : 0M;
		}
// 管理番号 K24285 From
		public virtual void SetPuQt(string value, bool allowNegative, bool allowDecimal)
		{
// 管理番号 K25647 From
//// 			object obj = ValidateDecimalForSqlParameter("数量", value, true, allowNegative, (byte)(allowDecimal ? 12 : 9), (byte)(allowDecimal ? 3 : 0)); //K24546
//			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS001259"), value, true, allowNegative, (byte)(allowDecimal ? 12 : 9), (byte)(allowDecimal ? 3 : 0));
			object obj = ValidateSlipQuantityForSqlParameter(MultiLanguage.Get("SC_CS001259"), value, true, allowNegative, allowDecimal ? this.qtDecimalDigit : (byte)0, IFBase.SlipQuantity.SCMM);
// 管理番号 K25647 To
			puQt = obj is decimal ? (decimal) obj : 0M;
		}
// 管理番号 K24285 To
		public virtual void SetStockUnitStdSellPrice(string value, bool allowDecimal)
		{
// 管理番号 K25647 From
//			// 管理番号 B13329 From
//			//			object obj = ValidateDecimalForSqlParameter("在庫単位標準販売単価", value, false, false, (byte) (allowDecimal ? 13 : 11), (byte) (allowDecimal ? 2 : 0));
//			// ユーザ入力項目でないのでチェックは最小限にする
//// 			object obj = ValidateDecimalForSqlParameter("在庫単位標準販売単価", value, false, false, (byte) 13, (byte) 2); //K24546
//			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS003539"), value, false, false, (byte) 13, (byte) 2);
//			// 管理番号 B13329 To
			// ユーザ入力項目でないのでチェックは最小限にする
			// 在庫単位標準販売単価
			object obj = ValidateStockPriceForSqlParameter(MultiLanguage.Get("SC_CS003539"), value, false, false);
// 管理番号 K25647 To
			stdSellPrice = obj is decimal ? (decimal) obj : 0M;
		}
		//管理番号 B13502 From

//管理番号 B13502 コメント削除

// 管理番号 K25647 From
//		public virtual void SetPuPrice(string value, byte precision, byte scale)
//		{
//// 			object obj = ValidateDecimalForSqlParameter("仕入単価", value, false, false, precision, scale); //K24546
//			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS000802"), value, false, false, precision, scale);
//			puPrice = obj is decimal ? (decimal) obj : 0M;
//		}
		public virtual void SetPuPrice(string value)
		{
			// 仕入単価
			object obj = ValidateSlipPriceForSqlParameter(MultiLanguage.Get("SC_CS000802"), value, false, false, this.priceDecimalDigit, byte.Parse(this.curDigit));
			puPrice = obj is decimal ? (decimal) obj : 0M;
		}
// 管理番号 K25647 To
		//管理番号 B13502 To
		public virtual void SetPuPlanPrice(string value, bool allowDecimal)
		{
// 管理番号 K25647 From
//			// 管理番号 B13329 From
//			//			object obj = ValidateDecimalForSqlParameter("仕入予定単価", value, false, true, (byte) (allowDecimal ? 13 : 11), (byte) (allowDecimal ? 2 : 0));
//			// ユーザ入力項目でないのでチェックは最小限にする
//// 			object obj = ValidateDecimalForSqlParameter("仕入予定単価", value, false, true, (byte) 13, (byte) 2); //K24546
//			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS003737"), value, false, true, (byte) 13, (byte) 2);
//			puPlanPrice = obj is decimal ? (decimal) obj : 0M;
//			// 管理番号 B13329 To
			// ユーザ入力項目でないのでチェックは最小限にする
			// 仕入予定単価
			object obj = ValidateStockPriceForSqlParameter(MultiLanguage.Get("SC_CS003737"), value, false, true);
			puPlanPrice = obj is decimal ? (decimal) obj : 0M;
// 管理番号 K25647 To
		}
		public virtual void SetUpperLimitPuQt(string value)
		{
// 管理番号 K25647 From
//// 			object obj = ValidateDecimalForSqlParameter("仕入数量(上限値)", value, false, true, 12, 3); //K24546
//			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS003661"), value, false, true, 12, 3);
			object obj = ValidateStockQuantityForSqlParameter(MultiLanguage.Get("SC_CS003661"), value, false, true, true);
// 管理番号 K25647 To
			upperLimitPuQt = obj is decimal ? (decimal) obj : 0M;
		}
		public virtual void SetInitPuPrice(string value, bool allowDecimal)
		{
// 管理番号 K25647 From
//			//管理番号 B13502 From
//			//			object obj = ValidateDecimalForSqlParameter("仕入単価(初期値)", value, false, true, (byte) (allowDecimal ? 13 : 11), (byte) (allowDecimal ? 2 : 0));
//			// ユーザ入力項目でないのでチェックは最小限にする
//// 			object obj = ValidateDecimalForSqlParameter("仕入単価(初期値)", value, false, true, (byte) 13, (byte) 2); //K24546
//			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS003718"), value, false, true, (byte) 13, (byte) 2);
//			//管理番号 B13502 To
			// ユーザ入力項目でないのでチェックは最小限にする
			// 仕入単価(初期値)
			object obj = ValidateStockPriceForSqlParameter(MultiLanguage.Get("SC_CS003718"), value, false, true);
// 管理番号 K25647 To
			initPuPrice = obj is decimal ? (decimal) obj : 0M;
		}
		public virtual void SetIncludeQt(string value)
		{
// 管理番号 K25647 From
//// 			object obj = ValidateDecimalForSqlParameter("入数", value, false, false, 7, 0); //K24546
//			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS001651"), value, false, false, 7, 0);
			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS001651"), value, false, false, 12, 5);
// 管理番号 K25647 To
			includeQt = obj is decimal ? (decimal) obj : 1M;
		}
		public virtual void SetCtaxRate(string value)
		{
// 			object obj = ValidateDecimalForSqlParameter("消費税率", value, false, false, 6, 3); //K24546
			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS001210"), value, false, false, 6, 3);
			ctaxRate = obj is decimal ? (decimal) obj : 0M;
		}
		public virtual void SetValidQt(string value, bool allowDecimal)
		{
// 管理番号 K25647 From
//// 			object obj = ValidateDecimalForSqlParameter("在庫有効数量", value, false, true , (byte) (allowDecimal ? 12 : 9), (byte) (allowDecimal ? 3 : 0)); //K24546
//			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS003564"), value, false, true , (byte) (allowDecimal ? 12 : 9), (byte) (allowDecimal ? 3 : 0));
			object obj = ValidateSlipQuantityForSqlParameter(MultiLanguage.Get("SC_CS003564"), value, false, true , allowDecimal ? this.qtDecimalDigit : (byte)0, IFBase.SlipQuantity.SCMM);
// 管理番号 K25647 To
			validQt = obj is decimal ? (decimal) obj : 0M;
		}
		public virtual void SetPoLineId(string value)
		{
// 			object obj = ValidateDecimalForSqlParameter("発注行ID", value, true, false, 10, 0); //K24546
			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS005259"), value, true, false, 10, 0);
			poLineId = obj is decimal ? (decimal) obj : 0M;
		}
		public virtual void SetPoLineId(decimal value)
		{
			poLineId = value;
		}
		public virtual void SetRcptLineId(string value)
		{
// 			object obj = ValidateDecimalForSqlParameter("入荷行ID", value, true, false, 10, 0); //K24546
			object obj = ValidateDecimalForSqlParameter(MultiLanguage.Get("SC_CS005012"), value, true, false, 10, 0);
			rcptLineId = obj is decimal ? (decimal) obj : 0M;
		}
		public virtual void SetRcptLineId(decimal value)
		{
			rcptLineId = value;
		}

		#endregion
	}

	[Serializable()]
	public class IF_SC_MM_05_AmtTtlInfo : Infocom.Allegro.IF.IFBase
	{
		protected decimal dtilAmtTtl      = 0M;	//仕入金額合計
		protected decimal etaxDtilAmtTtl  = 0M;	//課税対象額合計
		protected decimal etaxAmtTtl      = 0M;	//消費税合計
		protected decimal grandTtl        = 0M;	//総合計

		public decimal DtilAmtTtl
		{
			get{return dtilAmtTtl;}
			set{dtilAmtTtl = value;}
		}
		public decimal EtaxDtilAmtTtl
		{
			get{return etaxDtilAmtTtl;}
			set{etaxDtilAmtTtl = value;}
		}

		public decimal EtaxAmtTtl
		{
			get{return etaxAmtTtl;}
			set{etaxAmtTtl = value;}
		}
		public decimal GrandTtl
		{
			get{return grandTtl;}
			set{grandTtl = value;}
		}
	}

	[Serializable()]
	public class IF_SC_MM_05_KeyColumn : Infocom.Allegro.IF.IFBase
	{
		#region Protected Fields
		protected string paramType	        = string.Empty; // 参照モード
		protected string slipNo		        = string.Empty; // 伝票番号
		protected string refType	        = string.Empty; // 参照タイプ
		protected string puModeType	        = string.Empty; // 仕入形態区分
		protected string deleteDate         = string.Empty;	// 削除日
		protected string errorMessage       = string.Empty; // 削除時のエラーメッセージ
		protected string stockAdminUnitType = string.Empty;	// 在庫管理単位区分('C':全社 'D':部門)
		// 管理番号 B13877 From
		protected bool projectStockAdminUseFlg = false;	// プロジェクト別在庫管理使用フラグ
		// 管理番号 B13877 To
		protected string canceledOrderFlg	= string.Empty;	// 出合フラグ('1':該当する（出合） '0':該当しない)
		protected string overseasFlg		= string.Empty;	// 海外フラグ('1':該当する（海外） '0':該当しない)

		// 自部門のみのチェック
		protected string disclosureUnitType	= string.Empty;
		protected string userDeptCode		= string.Empty;
// 管理番号 B15710 From
		protected string wkKey = string.Empty;
// 管理番号 B15710 To
// 管理番号 K16187 From
		protected bool apModuleFlg;
// 管理番号 K16187 To
// 管理番号 K20684 From
		protected bool rcptApprovalFlg;
// 管理番号 K20684 To
// 管理番号 B22031 From
		protected string japanCountryCode	= string.Empty;	//日本国コード
// 管理番号 B22031 To
// 管理番号 K24789 From
		protected string dateAdminType		= string.Empty;	// 日付管理区分
// 管理番号 K24789 To
// 管理番号K27058 From
		protected string puModeTypeDtilCode	= string.Empty;	// 仕入形態区分明細コード
// 管理番号K27058 To

		#endregion

		#region Properties
		public string ParamType
		{
			get {return paramType;}
// 管理番号 B19369 From
//			set {paramType = ValidateChoiceString("パラメータ区分", value, new String[] {"New", "Mod", "View", "Copy", "CopyPO", "CopyRC","RefPU"});}
// 			set {paramType = ValidateChoiceString("パラメータ区分", value, new String[] {"New", "Mod", "View", "Copy", "CopyPO", "CopyRC","RefPU","RefReturnRC"});} //K24546
			set {paramType = ValidateChoiceString(MultiLanguage.Get("SC_CS002807"), value, new String[] {"New", "Mod", "View", "Copy", "CopyPO", "CopyRC","RefPU","RefReturnRC"});}
// 管理番号 B19369 To
		}
		public string SlipNo
		{
			get {return slipNo;}
			set
			{
				string slipName = string.Empty;
				switch (paramType)
				{
					case "CopyPO":
// 						slipName = "発注参照"; //K24546
						slipName = MultiLanguage.Get("SC_CS001766");
						break;
					case "CopyRC":
// 						slipName = "入荷参照"; //K24546
						slipName = MultiLanguage.Get("SC_CS001613");
						break;
					case "RefPU":
// 						slipName = "仕入参照"; //K24546
						slipName = MultiLanguage.Get("SC_CS000781");
						break;
// 管理番号 B19369 From
					case "RefReturnRC":
// 						slipName = "入荷参照"; //K24546
						slipName = MultiLanguage.Get("SC_CS001613");
						break;
// 管理番号 B19369 To
					default:
// 						slipName = "仕入番号"; //K24546
						slipName = MultiLanguage.Get("SC_CS000809");
						break;
				}
				slipNo = ValidateString(slipName, value , true, 10, CheckOption.SingleByte);
			}
		}
		public string RefType
		{
			get {return refType;}
			set {refType = value;}
		}
		public string PuModeType
		{
			get {return puModeType;}
			// 管理番号 B13500 From
			//			set {puModeType = ValidateChoiceString("仕入形態区分", value , new string[]{"0","1","4"});}
// 			set {puModeType = ValidateChoiceString("仕入形態区分", value , new string[]{"0","1","2","4"});} //K24546
			set {puModeType = ValidateChoiceString(MultiLanguage.Get("SC_CS003648"), value , new string[]{"0","1","2","4"});}
			// 管理番号 B13500 To
		}
		public string StockAdminUnitType
		{
			get {return stockAdminUnitType;}
// 			set {stockAdminUnitType = ValidateChoiceString("在庫管理単位区分", value , new String[] {"C", "D"});} //'C':全社 'D':部門 //K24546
			set {stockAdminUnitType = ValidateChoiceString(MultiLanguage.Get("SC_CS003521"), value , new String[] {"C", "D"});} //'C':全社 'D':部門
		}
		// 管理番号 B13877 From
		public bool ProjectStockAdminUseFlg
		{
			get {return projectStockAdminUseFlg;}
			set {projectStockAdminUseFlg = value;}
		}
		// 管理番号 B13877 To
		public string DeleteDate
		{
			get {return deleteDate;}
// 			set {deleteDate = ValidateDateTimeString("削除日", value , true);} //K24546
			set {deleteDate = ValidateDateTimeString(MultiLanguage.Get("SC_CS003579"), value , true);}
		}
		public string CanceledOrderFlg
		{
			get {return canceledOrderFlg;}
// 			set {canceledOrderFlg = ValidateChoiceString("出合フラグ", value , new string[]{"0","1"});} //K24546
			set {canceledOrderFlg = ValidateChoiceString(MultiLanguage.Get("SC_CS004233"), value , new string[]{"0","1"});}
		}
		public string OverseasFlg
		{
			get {return overseasFlg;}
// 			set {overseasFlg = ValidateChoiceString("海外フラグ", value , new string[]{"0","1"});} //K24546
			set {overseasFlg = ValidateChoiceString(MultiLanguage.Get("SC_CS003060"), value , new string[]{"0","1"});}
		}
		public string DisclosureUnitType
		{
			get {return disclosureUnitType;}
			set {disclosureUnitType = value;}
		}
		public string UserDeptCode
		{
			get {return userDeptCode;}
// 			set {userDeptCode = ValidateString("ユーザ部門", value, false, 10, CheckOption.SingleByte);} //K24546
			set {userDeptCode = ValidateString(MultiLanguage.Get("SC_CS002874"), value, false, 10, CheckOption.SingleByte);}
		}
// 管理番号 B15710 From
		public string WkKey
		{
			get {return wkKey;}
			set {wkKey = value;}
		}
// 管理番号 B15710 To
// 管理番号 K16187 From
		public bool ApModuleFlg
		{
			get {return apModuleFlg;}
			set {apModuleFlg = value;}
		}
// 管理番号 K16187 To
// 管理番号 K20684 From
		public bool RcptApprovalFlg
		{
			get {return rcptApprovalFlg;}
			set {rcptApprovalFlg = value;}
		}
// 管理番号 K20684 To
//管理番号 B22031 From
		public string JapanCountryCode
		{
			get {return japanCountryCode;}
			set {japanCountryCode = value;}
		}
//管理番号 B22031 To
// 管理番号 K24789 From
		public string DateAdminType
		{
			get {return dateAdminType;}
			set {dateAdminType = value;}
		}
// 管理番号 K24789 To
// 管理番号K27058 From
		public string PuModeTypeDtilCode
		{
			get { return puModeTypeDtilCode; }
			set { puModeTypeDtilCode = value; }
		}
// 管理番号K27058 To

		#endregion
	}

}
