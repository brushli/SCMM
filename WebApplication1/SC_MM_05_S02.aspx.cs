// Product     : Allegro
// Unit        : SC
// Module      : MM
// Function    : 05
// File Name   : SC_MM_05_S02.aspx.cs
// 機能名      : SC_MM_05_S02 仕入入力
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 管理番号 B12891 2004/09/22 伝票削除時に計上部門の存在をチェックするロジックの追加
// 管理番号 B11723・B11796 2004/09/24 原価・粗利額等の丸め処理統一
// 1.2.0 2004/09/30
// 管理番号 B11840 2004/11/01 フォーカス制御の修正
// 1.2.2 2004/10/31
// 管理番号 B13230 2004/11/02 仕入形態が返品の場合、摘要のタイトルヘッダを返品理由に変更する
// 管理番号 B13502 2004/11/26 国内取引外貨決済対応
// 管理番号 B13798 2004/12/03 管理項目の追加
// 1.3.0 2004/12/31
// 管理番号 Bxxxxx 2005/02/01 仕入先変更の制限の緩和（売上に合わせる）
// 管理番号 B13877 2005/02/01 プロジェクト別在庫管理対応
// 管理番号 B13878 2005/02/08 売上・仕入時の単価未決対応
// 管理番号 B13879 2005/02/03 管理帳票の追加
// 管理番号 B14298 2005/02/25 通貨途中変更による明細再計算対応
// 管理番号 B14477 2005/02/26 基軸換算時に、レート係数が加味されずに算出されている不具合を修正
// 管理番号 B14641 2005/03/08 レートを引継がず計上日のレートを取得
// 管理番号 B14340 2005/03/15 レートを検索ウィンドウで検索するとフォーカスが移動するのを修正 
// 管理番号 B14800 2005/03/15 返品時仕入先を入力すると発注入荷が入力可能になるのを修正。
// 管理番号 B14307 2005/03/22 オーバーフローの対応
// 管理番号 B14936 2005/03/23 発注参照時の修正時にプロジェクトコードが修正できる問題を修正
// 管理番号 B14982 2005/03/24 初期化されない項目があるのを修正 
// 1.3.2 2005/03/31
// 管理番号 B15061 2005/04/14 部門・プロジェクト名称取得の不具合対応
// 管理番号 B12929 2005/03/14 仕入先別単価設定対応
// 管理番号 B14549 2005/04/26 レートのフォーマット統一
// 管理番号 B15394 2005/04/27 レートがブランクの時の動作を統一
// 管理番号 B15445 2005/05/13 参照モード時マスタからデータを取り直す不具合対応
// 管理番号 B15586 2005/05/19 コピーモードの場合取引先の回収条件を再取得されていない不具合対応
// 管理番号 B15657 2005/05/30 修正モード時、明細で行挿入を行うとエラーになる不具合対応
// 管理番号 B15806 2005/06/14 回収条件が一括請求の時サイトが入力可能になっている不具合を修正
// 管理番号 B15855 2005/06/17 伝票を修正モードで開いたときに外貨が基軸に戻ってしまう不具合を修正
// 1.3.3 2005/06/30
// 管理番号 B15710 2005/07/19 レスポンス是正対応
// 管理番号 B16212 2005/08/09 標準動作準拠対応（郵便番号）
// 管理番号 K16187 2005/09/06 支払機能拡張対応
// 1.4.0 2005/10/31
// 管理番号 B16565 2005/11/01 仕入先と異なる支払先指定時に口座情報が仕入先マスタから取得される不具合を修正
// 管理番号 B16693 2005/11/17 参照モードの伝票の為替区分・予約番号・レートが入力可能になる不具合を修正
// 管理番号 K16590 2005/11/24 管理会計機能拡張（日付チェック機能強化対応）
// 管理番号 B16517 2006/02/07 伝票コピー時に、通貨がコピーされない不具合を修正
// 管理番号 B17614 2006/03/22 新規登録にて発注参照又は入荷参照した伝票を修正モードで表示すると編集可になる不具合対応
// 管理番号 B17601 2006/03/23 手入力すると他外貨の予約番号でもレートを取得できてしまう不具合対応
// 管理番号 B17215 2006/03/27 数量小数を使用しない場合の、小数桁表示不具合対応
// 管理番号 B17665 2006/03/27 為替予約ありの場合のレート項目の制御と取得に関する不具合対応
// 1.5.0 2006/03/31
// 管理番号 B18691 2007/01/12 承認管理画面にて、相手先と件名が表示されない不具合を修正
// 管理番号 B18516 2007/01/12 レートのフォーマットを修正
// 管理番号 B19446 2007/01/12 F4からの修正モードで、伝票参照（発注等）の伝票でも仕入先が編集可能になってしまう不具合を修正
// 管理番号 B19458 2007/01/12 通貨を基軸通貨以外にしてレートを手入力した仕入伝票をコピーしたとき、基軸換算合計の計算がおかしくなる不具合を修正
// 管理番号 B18953 2007/01/12 商品コード未入力時の明細行におけるコントロールの使用可否状態を修正
// 管理番号 B18951 2007/01/12 商品コード未入力時の明細行におけるフォーカス制御を修正
// 管理番号 B19534 2007/01/12 締日がセットされていない状態で入力不可の場合は、<>も使用不可になるよう修正
// 管理番号 B18736 2007/01/15 入力桁数統一対応
// 管理番号 B18058 2007/01/15 行挿入時及び商品コード入力時に内税商品の場合、「*」表示が行われ、金額欄にはゼロが表示されていない不具合を修正
// 管理番号 B18049 2007/01/15 帳票印刷時のレポートマスタメンテナンス参照設定の不具合対応
// 管理番号 B20065 2007/02/13 カレンダマスタ未登録の場合の回収/支払期限の算出が不正であること、及び請求締/支払締が都度の場合に回収/支払期限の算出が不正である不具合対応
// 管理番号 B19467 2007/02/13 支払条件区分の表示制御不具合対応
// 管理番号 B20324 2007/03/08 計上日変更時に消費税率の再計算が行われない不具合の修正
// 管理番号 B20392 2007/03/20 雑コード入力時のチェック対応
// 管理番号 B20479 2007/04/16 発注参照及び入荷参照テキストボックスに存在しない伝票番号を入力したさいに、仕入先と部門が入力できてしまう不具合対応
// 1.5.1 2007/06/30
// 管理番号 K20687 2007/07/06 内部統制強化：計上基準追加対応
// 管理番号 K20685 2007/07/24 ワークフロー取消機能改善
// 管理番号 B20853 2007/08/14 出合の場合は紐づく売上伝票から承認状態を取得するよう修正
// 管理番号 B20859 2007/08/23 担当者変更時に経路が再作成されない、または更新直後に参照モードとならない不具合
// 1.5.2 2007/10/31
// 管理番号 B20818 2007/12/17 楽観ロック対応
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 管理番号 B21172 2008/05/26 自社マスタ（共通）の日付管理区分が「取引日管理基準」の場合は、「取引日」、「計上日管理基準」の場合は、取引日が使用不可になるため、次の項目にフォーカスが遷移するよう修正
// 管理番号 B21666 2008/05/29 為替区分が非活性の場合、件名でエンターキーを押下したら仕入先正式名にフォーカスが遷移するよう修正
// 管理番号 B21313 2008/06/03 発注参照、入荷参照のテキストボックスで一度エラーを表示させた後で伝票更新しようとするとアプリケーションエラーとなる不具合の対応
// 管理番号 B21182 2008/06/04 参照モードで閲覧しているにもかかわらず、銀行コード、口座種別、支店コードが入力可となっている不具合対応
// 管理番号 B21175 2008/06/13 返品伝票更新後に新規伝票を入力しようとすると、新規行が非活性のままになってしまう不具合の対応
// 管理番号 B21076 2008/06/16 明細行に存在しない商品を入力し、ポストバックせずに登録しようとするとエラーになる不具合の対応
// 管理番号 B20039 2008/06/19 編集行状態にて行確定する前に通貨コード等を変更しても、編集行がキャンセルされない不具合の対応
// 管理番号 B21594 2008/06/19 レート検索画面で選択したレート及び為替予約番号をセットし、フォーカスが消失しないよう修正
// 管理番号 B21695 2008/06/23 修正モードにて伝票番号をクリアにし新規モードにしてから更新しようとするとエラーになる不具合の対応
// 管理番号 B20298 2008/06/24 都度支払の得意先について、参照伝票の締日未入力の場合に回収条件より算出される回収期限がセットされない不具合対応
// 管理番号 B21691 2008/06/25 サイトを使用しない決済条件のみの場合、サイトが非活性かつクリアされるよう修正
// 管理番号 B20713 2008/10/29 自社マスタ(販売)でロット管理を行わない設定をしている場合に、ロット番号のタイトル表示有無が統一するよう修正
// 管理番号 K22196 2008/11/28 都度支払対応
// 管理番号 K22205 2008/10/09 WF申請者以外の修正対応
// 管理番号 K22217 2008/10/09 WF伝票入力承認者変更
// 管理番号 K22270 2008/11/11 パフォーマンス改善（ページング対応）
// 管理番号 K22158 2008/12/17 ポストバック時にフォーカスが予期しない項目へ移動してしまう問題を修正
// 管理番号 B22050 2009/03/23 単位入力後にロット入力となるように、カーソルの移動順を修正
// 管理番号 B22138 2009/03/30 雑コード指定時、口座区分をブランクに自動選択
// 管理番号 B22107 2009/04/01 自部門制限時に別部門担当者で申請した場合の不具合対応
// 管理番号 B22231 2009/04/02 ＋記号についてDBには登録が出来るが照会するとブランクになってしまう不具合対応
// 管理番号 B22255 2009/04/03 ロット詳細参照時に参照元の伝票が削除されている場合、明細が表示されない不具合を修正 
// 管理番号 B21841 2009/04/10 組織変更後に旧部門の伝票を参照すると「該当データなし」と表示される不具合を修正
// 管理番号 B21977 2009/08/10 一括請求の場合、請求処理日項目に請求締日が表示されるよう修正
// 管理番号 B22672 2009/08/10 仕入伝票のコピー時に口座区分が引き継がれない不具合を改善
// 管理番号 B22079 2009/08/10 都度請求の受注を参照した際に、回収期限の初期値がセットされない不具合対応
// 管理番号 B22309 2009/08/10 担当者・部門変更時、優先倉庫の住所等を再取得する
// 管理番号 B22425 2009/08/10 伝票参照登録後、連続して新規登録を実行するとエラーとなる不具合を修正
// 管理番号 B22403 2009/08/11 伝票修正後に参照モードに切り替わると、フォーカスアウトしてしまいファンクションキーが使用できない不具合を修正
// 1.6.0 2009/09/30
// 管理番号 B23172 2010/04/05 納入区分を変更して倉庫コードを入力したところでフォーカスが無くなる不具合を修正
// 管理番号 B22497 2010/04/16 商品名をスペースで登録できてしまう不具合を修正
// 管理番号 B23136 2010/04/19 外貨で為替区分がNULLの仕入データが作成される不具合を改善
// 管理番号 B23304 2010/05/21 残額0円状態でポストバックすると、為替予約のレートからスポットレートに変わってしまう不具合を修正
// 管理番号 B22971 2010/06/09 プロジェクト名称取得不備を修正
// 管理番号 B21324 2010/06/09 システム日付がプロジェクト終了日以降の状態でプロジェクトを入力した場合、プロジェクト名称が取得できない不具合を修正
// 管理番号 B23547 2010/06/23 一括から都度に変更した時、回収期限が再計算されない
// 管理番号 B21051 2010/08/23 WFを使用しない社員で更新すると、決裁となってしまう不具合を修正
// 管理番号 B22031 2010/09/06 銀行国コードが「JPN」以外で口座名義人に全角文字が含まれているとエラーとなる不具合を修正
// 管理番号 B21550 2010/11/22 在庫管理部門が同じ場合の制御
// 管理番号 B23588 2010/11/26 挿入行を編集中に明細に連動する項目を変更すると空の明細行が登録される不具合を修正
// 管理番号 B23717 2010/11/30 返品時（マイナス金額時）の為替予約チェック
// 管理番号 B23856 2011/01/11 受渡場所変更後に得意先をクリアした時の動作不備を修正
// 管理番号 B23801 2011/01/21 表示制御不具合対応
// 管理番号 B23974 2011/03/17 伝票日付が名称改定前にもかかわらず新名称が表示される不具合の修正
// 管理番号 K24153 2011/07/23 検収基準増加対応
// 管理番号 K24278 2012/01/12 仕入先課税区分追加対応
// 管理番号 K24285 2012/01/16 売上・仕入マイナス数量入力対応
// 管理番号 K24284 2012/01/23 プロジェクト必須対応
// 管理番号 K24389 2012/03/01 ボリュームディスカウント機能
// 管理番号 K24390 2012/03/01 ユーザビリティ対応
// 管理番号 B24188 2012/04/24 計上日の月度で債権債務締処理がされていると支払保留が解除できない。
// 管理番号 B24246 2012/05/07 諸掛閲覧から他部門の伝票を参照すると伝票印刷ボタンが活性化される不具合を修正
// 管理番号 B24179 2012/05/14 通貨を切り換えた際、表示金額が不正になる不具合対応
// 管理番号 B23282 2012/05/16 売上入力と仕入入力で挙動があわない不具合の修正
// 管理番号 B23893 2012/05/16 明細行が存在する状態で、売上形態を変更（通常⇒サンプル⇒返品）すると挿入ボタンが消える不具合の対処
// 管理番号 B24235 2012/05/17 新規行編集中（行登録前）に更新すると、編集中の新規登録行の情報が残ってしまう不具合を修正
// 管理番号 B24164 2012/05/18 伝票コピー時に雑取引先であっても仕入先住所がマスタから取得される不具合を修正
// 管理番号 B24440 2012/05/18 伝票コピー時にレートと取引条件の初期値が不正
// 2.0.0 2012/10/31
// 管理番号 B24714 2012/11/14 赤黒伝票の承認状態の表示がデータと異なる不具合対応
// 管理番号 B24292 2012/11/19 明細入力後のF6更新対応
// 管理番号 B24732 2012/11/19 B24292の修正不備対応
// 管理番号 B24264 2012/12/03 雑取引先の情報を都度入力できるように修正
// 管理番号 K24546 2013/02/25 多言語化対応
// 2.1.0 2013/03/31
// 管理番号 K24789 2013/05/13 消費税率の段階的引き上げ対応
// 管理番号 B24749 2013/08/16 ヘッダ項目の変更時、明細破棄が実施されない不具合の対応
// 管理番号 B24781 2013/08/16 参照ありの返品伝票の編集時、挿入ボタンが表示されてしまう
// 管理番号 B24918 2013/08/16 参照ありの場合、担当者コードを直接修正するとフォーカスが喪失する
// 管理番号 B24959 2013/10/16 雑仕入先の場合、必須項目を入力せずに伝票が登録ができてしまう不具合を修正
// 管理番号 K25322 2014/04/17 ロット引当対応
// 管理番号 B25337 2014/07/22 返品入力で伝票参照した場合に通貨コードが変更可能になる不具合を修正
// 管理番号 B25365 2014/07/22 雑取引先の伝票を参照モードで開いた場合にファンクションキーの制御ができない不具合を修正
// 管理番号 B23437 2014/07/22 出合にて支払保留の場合、債権へ連動すると支払保留解除ができない不具合を修正
// 管理番号 B25542 2014/10/02 組織変更後プロジェクト名称が表示されない
// 管理番号 K25514 2014/10/03 数量変更時におけるボリュームディスカウント機能の修正
// 2.2.0 2014/10/31
// 管理番号 B24845 2016/02/17 仕入入力で修正時にレートが変更できないとなる不具合の修正
// 管理番号 B25845 2016/02/17 ヘッダ項目の更新と明細の登録・更新の連続イベント発生に伴う不具合の対応
// 管理番号 B25848 2016/02/15 ボリュームディスカウント単価の設定がない商品でAPエラーが発生する不具合を修正
// 管理番号 B25883 2016/02/18 数量変更時、販売単価にボリュームディスカウントが適用されない
// 管理番号 B26242 2016/03/28 部門コードの変更時に画面の承認状態が不正となる不具合を修正
// 管理番号 K25647 2015/04/08 項目桁数拡張
// 管理番号 K25679 2015/09/17 グループ対応
// 管理番号 K25680 2015/09/17 外部連携
// 管理番号 K25656 2015/11/26 担当者変更時の部門変更
// 管理番号 K25667 2016/01/06 WFファイル添付
// 2.3.0 2016/06/30
// 管理番号B25370 2016/07/20 後続伝票が存在する場合は削除ボタンを押下不可とする修正
// 管理番号B25595 2016/09/05 ロット番号を変更すると入荷数より返品数が多くなる不具合を修正
// 管理番号B25752 2017/01/19 仕入にてロット詳細更新後、行更新でAPエラーが発生する不具合を修正
// 管理番号B26565 2018/02/16 部門変更を行うと添付資料が削除されてしまう
// 管理番号B26146 2018/02/19 仕入予定単価の取得タイミングが不正
// 管理番号K26528 2017/02/13 UI見直し
// 管理番号K26508 2017/09/06 アクセス権限の改善
// 3.0.0 2018/04/30
// 管理番号B23625 2018/05/09 多通貨使用しない時海外発注入力に多通貨使用されてしまう不具合を修正
// 管理番号B26278 2018/05/23 伝票参照にてエラー発生後、続けて伝票登録行うとアプリケーションエラーが発生する不具合を修正
// 管理番号B26678 2018/07/13 為替予約の残高が不足している場合、不正なレートが設定される
// 管理番号K27064 2019/08/07 請求／支払締後の伝票修正許可
// 管理番号K27059 2019/10/01 マスタの絞り込み機能追加
// 管理番号K27062 2019/10/04 受渡場所マスタの設定方法改善
// 管理番号K27058 2019/10/16 汎用区分追加
// 管理番号K27057 2019/12/05 汎用項目追加
// 3.1.0 2020/06/30
// 管理番号B27043 2020/07/01 仕入形態が預りの際に、発注しない商品が設定できてしまう
// 管理番号K27154 2020/07/15 収益認識対応
// 管理番号K27478 2022/03/01 脆弱性対応（XSS）
// 管理番号K27441 2022/02/14 組織変更機能改善
// 管理番号B27422 2022/09/06 ロット管理しない商品にも関わらずロット番号付き在庫が発生する
// 管理番号K27525 2022/10/20 適格請求書等保存方式対応(仕入税額控除の要件対応)
// 3.2.0 2023/03/31
// 管理番号B27587 2023/07/24 仕入入力で納入区分設定後のフォーカス遷移でフォーカスロストする
// 管理番号B27219 2023/07/24 口座名義人に長音を入力するとそのまま登録されてEBデータ送信時にエラーとなる。

using System;
using System.Collections;
// 管理番号 K25667 From
using System.Configuration;
// 管理番号 K25667 To
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Web;
// 管理番号 K25667 From
using System.Web.UI;
// 管理番号 K25667 To
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
// 管理番号K26528 From
using System.Collections.Generic;
// 管理番号K26528 To
// 管理番号 K25667 From
using Infocom.Allegro.CM;
// 管理番号 K25667 To
using Infocom.Allegro.CM.MS;
using Infocom.Allegro.SC.MS;
using Infocom.Allegro.Web.WebControls;
// 管理番号 K25647 From
using Infocom.Allegro.Web;
// 管理番号 K25647 To

namespace Infocom.Allegro.SC
{
	public class SC_MM_05_S02 : Infocom.Allegro.Web.InputPageBase
	{
		#region Private struct Fields
		private struct ViewStateType
		{
			public const string	KEY_COLUMN		= "keyColumn";
			public const string	PARAM_TYPE		= "ParamType";
			public const string	REF_TYPE		= "RefType";
			public const string	SLIP_NO			= "SlipNo";
			public const string	LOCK_PU_NO		= "LockedPuNo";
			public const string	INSERT_FLAG		= "InsertFlag";
			public const string CUR_DIGIT		= "CurDigit";
			public const string APPROVAL_FLG	= "ApprovalFlg";
			public const string IS_CHARGE_EXISTS= "IsChargeExists";
		}
		private struct HiddenFieldType
		{
			public const string PARAM_TYPE		= "__ParamType";
			public const string REF_TYPE		= "__RefType";
			public const string SLIP_NO			= "__SlipNo";
			public const string REF_PO_NO		= "__RefPoNo";
			public const string REF_RCPT_NO		= "__RefRcptNo";
			public const string REF_PU_NO		= "__RefPuNo";
			public const string LOCK_PU_NO		= "__LockedPuNo";
			//返品時の明細行処理変更対応-INSERT-START
			public const string PU_MODE_TYPE	= "__PuModeType";
			//返品時の明細行処理変更対応-INSERT-END
			public const string TODAY_DATE		= "__TodayDate";
			public const string RETURN_VAL		= "__ReturnValue";
			public const string STTL_TYPE1		= "SttlType1";
			public const string STTL_TYPE2		= "SttlType2";
			public const string STTL_TYPE3		= "SttlType3";
// 管理番号 B24264 From
			public const string CUR_CODE		= "__CurCode";
			public const string TEMP_CODE_FLG	= "__TempCodeFlg";
// 管理番号 B24264 To
		}
		private struct ParamCodeType
		{
			public const string NEW				= "New";
			public const string MOD				= "Mod";
			public const string VIEW			= "View";
			public const string COPY			= "Copy";		// 仕入コピー
			public const string COPY_PO			= "CopyPO";		// 発注コピー
			public const string COPY_RC			= "CopyRC";		// 入荷コピー
			public const string REF_PU			= "RefPU";		// 仕入参照
		}
		private struct RefCodeType
		{
			public const string NONE			= "NONE";
			public const string PO				= "PO";			// 発注入力
			public const string RCPT			= "RCPT";		// 入荷参照
			public const string REF_PU			= "REF_PU";		// 仕入参照
			public const string COPY_PU			= "COPY_PU";	// 仕入参照(コピー)
		}
		private struct RowStateType
		{
			public const string Create			= "C";
			public const string Ref				= "R";
			public const string Update			= "U";
			public const string Delete			= "D";
			public const string Temp			= "T";
		}
		private enum CutOffDateType
		{
			//Get_PreNext_Cutoff_Date()へのパラメータの為、値変更は不可
			Previous  = 1,	//前回
			Now　　　 = 2,	//今回
			Next      = 3,	//次回
			Whenever  = 4	//都度(取引条件締日付を本日の日から取得する)
		}
		#endregion

		#region Private Fields
		private IF_SC_MM_05_S02_KeyColumn keyColumn	= new IF_SC_MM_05_S02_KeyColumn();
		private IF_SC_MM_05_S02_RowData	rowData		= null;
		private SC_MM_05_S02_ROW_CONTROLS rowCtl	= null;
		private const string pageCode				= "SM3";
		protected string paramType					= string.Empty;
		private string refType						= RefCodeType.NONE;
		private string slipNo						= string.Empty;
		private string lockedPuNo					= string.Empty;
		private string returnValue					= string.Empty;
		protected string curDigit					= string.Empty;
		//管理番号 B13502 From
		//		private string todayDate					= DateTime.Today.ToString();
		//管理番号 B13502 To
		private bool useBind						= false;
		private readonly string qtMaxValue			= "999999999";
		private readonly string directWhCode		= "99999";
		private bool isClose						= false;
		private bool lotDiff						= false; //ロット明細が退避用の明細と差分を保つ場合はtrue
		private bool dtlChangeFlg					= false;
		protected bool approvalFlg					= false; //ワークフロー対象フラグ
		private bool isStockAdminDeptChange			= false; //在庫管理部門変更フラグ
// 管理番号 B24749 From
		private bool isProjChange					= false; //プロジェクト変更フラグ
// 管理番号 B24749 To
		private bool isChargePuExists               = false; //諸掛閲覧ボタン使用可否
		private bool insertFlg						= false; //挿入フラグ(新規挿入行がある場合True)
// 管理番号 K22217 From
        private string appEmpCode                   = string.Empty;   //承認予定社員コード
        private string appRouteId                   = string.Empty;   //承認経路ID
// 管理番号 K22217 To
// 管理番号 K22270 From
// 管理番号 K24390 From
//		private int PageSize = 3;
// 管理番号 K24390 To
		private int viewnum;
		private string CurrentPage;
// 管理番号 K22270 To
// 管理番号 B24264 From
		private bool closeFlg = false;
		private Hashtable tempRowData = new Hashtable();
// 管理番号 B24264 To
// 管理番号 B23437 From
		private bool holdReleaseFlg = false;
// 管理番号 B23437 To
// 管理番号 K25679 From
		private string slipType						= "SM3";	//伝票区分
		private bool correctAllowFlg				= false;	//修正許可フラグ
// 管理番号 K25679 To
// 管理番号K27058 From
		private string puModeTypeDtilCodeHidden = string.Empty;
// 管理番号K27058 To
// 管理番号 K25667 From
		private string attachmentCancelFlg = string.Empty;
		private string attachmentRedSlipFlg = string.Empty;
		/// <summary>承認添付資料情報</summary>
		private CM.WF.IF_CM_WF_AttachmentFiles attachmentFiles
		{
			get { return (CM.WF.IF_CM_WF_AttachmentFiles)Session[this.PageID + "_ApprovalAttachmentFiles"]; }
			set { Session[this.PageID + "_ApprovalAttachmentFiles"] = value; }
		}
// 管理番号 K25667 To

// 管理番号K27058 From
		private string puModeType
		{
			// 仕入形態の区分コード（ドロップダウンリストの値の先頭から1文字）
			get
			{
				if (PuModeTypeList.SelectedValue == string.Empty)
				{
					return "0";
				}
				else
				{
					return PuModeTypeList.SelectedValue.Substring(0, 1);
				}
			}
		}

		private string puModeTypeDtilCode
		{
			// 仕入形態の区分明細コード（ドロップダウンリストの値の2文字目から2文字）
			get
			{
				if (PuModeTypeList.SelectedValue == string.Empty)
				{
					return "00";
				}
				else
				{
					return PuModeTypeList.SelectedValue.Substring(1, PuModeTypeList.SelectedValue.Length - 1);
				}
			}
		}

		private string bookBasisType
		{
			// 計上基準の区分コード（ドロップダウンリストの値の先頭から1文字）
			get
			{
				if (BookBasisTypeList.SelectedValue == string.Empty)
				{
					return "0";
				}
				else
				{
					return BookBasisTypeList.SelectedValue.Substring(0, 1);
				}
			}
		}

		private string bookBasisTypeDtilCode
		{
			// 計上基準の区分明細コード（ドロップダウンリストの値の2文字目から2文字）
			get
			{
				if (BookBasisTypeList.SelectedValue == string.Empty)
				{
					return "00";
				}
				else
				{
					return BookBasisTypeList.SelectedValue.Substring(1, BookBasisTypeList.SelectedValue.Length - 1);
				}
			}
		}
// 管理番号K27058 To
		#endregion

		#region Protected Fields
		protected Infocom.Allegro.Web.WebControls.Header Header1;
		protected System.Web.UI.WebControls.Label MessageLabel;
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList StatusDropdownlist;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox PoRefText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox RcptRefText;
		protected Infocom.Allegro.Web.WebControls.DateBox PuDateText;
// 管理番号 K16590 From
		protected Infocom.Allegro.Web.WebControls.DateBox DealDateText;
// 管理番号 K16590 To
		protected Infocom.Allegro.Web.WebControls.EncodeLabel LastSlipNoLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel StatusTitleLabel;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox SuplCodeText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox SuplNameText;
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList PuModeTypeList;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox RefPuText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox SuplBillSlipNoText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox EmpCodeText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel EmpNameLabel;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox DeptCodeText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel DeptNameLabel;
		//在庫管理部門変更対応-INSERT-START
		protected System.Web.UI.HtmlControls.HtmlInputHidden OrgDeptCodeHdn;
		protected System.Web.UI.HtmlControls.HtmlInputHidden OrgDeptNameHdn;
		//在庫管理部門変更対応-INSERT-END
// 管理番号 B24749 From
		protected System.Web.UI.HtmlControls.HtmlInputHidden OrgProjCodeHdn;
		protected System.Web.UI.HtmlControls.HtmlInputHidden OrgProjNameHdn;
// 管理番号 B24749 To
		protected Infocom.Allegro.Web.WebControls.EncodeLabel ProjTitleLabel;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox ProjCodeText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel ProjNameLabel;
		protected Infocom.Allegro.Web.WebControls.CustomRadioButton DeliTypeWRadio;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox WhCodeText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel WhShortNameLabel;
		protected Infocom.Allegro.Web.WebControls.CustomRadioButton DeliTypeDRadio;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox DeliCustCodeText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel DeliCustNameLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel SoNoLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel SoDateLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel CustNameLabel;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox PuNameText;
// 管理番号K27062 From
//		protected Infocom.Allegro.Web.WebControls.CustomDropDownList DeliPlaceCodeList;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox DeliPlaceCodeText;
// 管理番号K27062 To
		protected Infocom.Allegro.Web.WebControls.CustomTextBox DeliPlaceNameText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel DeliPlaceCountryCode;
// 管理番号 B24264 From
//		protected Infocom.Allegro.Web.WebControls.CustomTextBox SuplFormalNameText;
//		protected Infocom.Allegro.Web.WebControls.CustomTextBox SuplUserNameText;
//		protected Infocom.Allegro.Web.WebControls.CustomTextBox SuplDeptName1Text;
//		protected Infocom.Allegro.Web.WebControls.CustomTextBox SuplDeptName2Text;
		protected Infocom.Allegro.Web.WebControls.StyledButton SuplDtilButton;
// 管理番号 B24264 To
		protected Infocom.Allegro.Web.WebControls.CustomTextBox ZipText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox StateText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox CityText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox Address1Text;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox Address2Text;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox PhoneText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox FaxText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox DeliUserNameText;
		protected Infocom.Allegro.Web.WebControls.CustomRadioButtonList DtTypeList;
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList Dt1SttlMthdCodeList;
		protected Infocom.Allegro.Web.WebControls.NumberBox Dt1BasisAmtText;
		protected Infocom.Allegro.Web.WebControls.NumberBox Dt2RatioText;
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList Dt2SttlMthdCodeList;
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList Dt3SttlMthdCodeList;
		protected Infocom.Allegro.Web.WebControls.NumberBox DtSightText;
		protected Infocom.Allegro.Web.WebControls.DateBox CutoffDateText;
		protected Infocom.Allegro.Web.WebControls.DateBox PymtPlanDateText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel CutOffDateConditionNote;
// 管理番号 B24264 From
//		protected System.Web.UI.HtmlControls.HtmlTable AcTable;
//		protected Infocom.Allegro.Web.WebControls.CustomDropDownList AcTypeList;
//		protected Infocom.Allegro.Web.WebControls.CustomTextBox BankCodeText;
//		protected Infocom.Allegro.Web.WebControls.EncodeLabel BankNameLabel;
//		protected Infocom.Allegro.Web.WebControls.CustomTextBox BankBranchCodeText;
//		protected Infocom.Allegro.Web.WebControls.EncodeLabel BankBranchNameLabel;
//		protected Infocom.Allegro.Web.WebControls.CustomDropDownList BankAcTypeList;
//		protected Infocom.Allegro.Web.WebControls.CustomTextBox AcHolderText;
//		protected Infocom.Allegro.Web.WebControls.CustomTextBox AcNoText;
// 管理番号 B24264 To

		// 管理番号 13878 From
		protected Infocom.Allegro.Web.WebControls.CustomCheckBox HoldCheck;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox DtNoteText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel PaymentDateLabel;
		// 管理番号 B13230 From
		protected Infocom.Allegro.Web.WebControls.EncodeLabel RemarksLabel;
		// 管理番号 B13230 To
		protected Infocom.Allegro.Web.WebControls.CustomTextBox RemarksCodeText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox RemarksText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel HeaderSpec1NameLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel HeaderSpec2NameLabel;
		protected Infocom.Allegro.Web.WebControls.ClickablePanel InpPanel;
		protected Infocom.Allegro.Web.WebControls.StyledButton UpdateButton;
		protected Infocom.Allegro.Web.WebControls.StyledButton CancelButton;
		protected Infocom.Allegro.Web.WebControls.StyledButton DeleteButton;
		protected Infocom.Allegro.Web.WebControls.StyledButton ChargeBrowseButton;
		protected Infocom.Allegro.Web.WebControls.StyledButton PuSlipButton;
		protected System.Web.UI.WebControls.LinkButton BasicTabLinkBtn;
		protected System.Web.UI.WebControls.LinkButton DetailTabLinkBtn;
		protected Infocom.Allegro.Web.WebControls.ClickableDataGrid DataGrid1;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel PoMoneyLabel2;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel DtilAmtTtlLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel EtaxDtilAmtTtlLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel EtaxAmtTtlLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel GrandTtlLabel;
		protected Infocom.Allegro.Web.WebControls.TabItem TabItem1;
		protected Infocom.Allegro.Web.WebControls.TabItem TabItem2;
		protected Infocom.Allegro.Web.WebControls.TabSelector TabSelector1;
		protected System.Web.UI.HtmlControls.HtmlGenericControl BasicTab;
		protected System.Web.UI.HtmlControls.HtmlGenericControl DetailTab;
		//管理番号 B13502 From
		//		protected Infocom.Allegro.Web.WebControls.EncodeLabel CurCodeLabel;
		protected Infocom.Allegro.Web.WebControls.CurrencyList CurCodeList;
		//管理番号 B13502 To
		protected System.Web.UI.HtmlControls.HtmlForm FORM_SC_MM_05_S02;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel ModeLabel;

		protected Infocom.Allegro.Web.WebControls.StyledButton CloseButton;
		protected System.Web.UI.HtmlControls.HtmlTable HeaderTable;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox InpProdCodeText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox InpProdNameText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpProdShortNameLabel;
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList InpProdSpec1List;
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList InpProdSpec2List;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox InpWhCodeText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpWhShortNameLabel;
		protected Infocom.Allegro.Web.WebControls.NumberBox InpPuQtText;
		protected Infocom.Allegro.Web.WebControls.NumberBox InpInitPuPriceText;
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList InpUnitList;
		protected Infocom.Allegro.Web.WebControls.StyledButton RegistButton;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox InpRemarksCodeText;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox InpRemarksText;
// 管理番号K27525 From
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList InpBookDeductionReasonCodeList;
// 管理番号K27525 To
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpIsRcptExecuteFlg;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpStockAdminFlg;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpLotAdminFlg;
// 管理番号 K25322 From
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpLotStockValuationFlg;
// 管理番号 K25322 To
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpQtDecimalUseFlg;
		protected Infocom.Allegro.Web.WebControls.NumberBox InpPuPriceText;
		// 管理番号 B13878 From
		protected Infocom.Allegro.Web.WebControls.CustomCheckBox InpPriceUndecidedFlgCheck;
		// 管理番号 B13878 To
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpPuPlanPriceLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpPoMoneyLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpCtaxRate;
// 管理番号 K24789 From
//		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpCtaxRateCode;
// 管理番号 K24789 To
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpProdType;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpDispControlType;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpIncludeQt;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpAllowProdName;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpCtaxCalcTypeLabel;
// 管理番号 K24789 From
//		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpCtaxCalcType;
// 管理番号 K24789 To
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpDiscFlg;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpStdSellPrice;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpProdEditFlg;
		protected System.Web.UI.HtmlControls.HtmlTable InputTable;
		protected System.Web.UI.HtmlControls.HtmlInputHidden inpProdTypeHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden inpDispTypeHidden;
		protected Infocom.Allegro.Web.WebControls.StyledButton InpLotDtilButton;
		protected System.Web.UI.HtmlControls.HtmlInputHidden editProdTypeHidden;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox PuNoText;
		protected Infocom.Allegro.Web.WebControls.StyledButton CutoffDateBackButton;
		protected Infocom.Allegro.Web.WebControls.StyledButton CutoffDateAdvanceButton;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel InpPuMoneyLabel;
// 管理番号 K24789 From
		protected Infocom.Allegro.Web.WebControls.StyledButton InpTaxInfoButton;
// 管理番号 K24789 To

		protected System.Web.UI.HtmlControls.HtmlInputHidden editRowPuLineIdHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden editRowInitPuQtHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden editRowInitPuPriceHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden editRowStockAdminFlgHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden editRowRcptLineIdHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden editRowPoLineIdHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden editRowProdTypeHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden editRowDispTypeHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden inputRowProdTypeHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden inputRowDispTypeHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden inputRowInitPuQtTextHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden inputRowInitPuPriceHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden inputRowStockAdminFlgHidden;

		//管理番号 B13502 From
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList ExchangeTypeList;
		protected Infocom.Allegro.Web.WebControls.CustomTextBox ExchangeRezNoText;
		protected Infocom.Allegro.Web.WebControls.NumberBox RateText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel RateLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel ConvertDtilAmtTtlLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel ConvertEtaxDtilAmtTtlLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel ConvertEtaxAmtTtlLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel ConvertGrandTtlLabel;
		//管理番号 B13502 To
		// 管理番号 B13798 From
		protected System.Web.UI.HtmlControls.HtmlInputHidden AdminItem1Hidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden AdminItem2Hidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden AdminItem3Hidden;
		// 管理番号 B13798 To
// 管理番号K27058 From
//		//管理番号K20687 From
//		protected Infocom.Allegro.Web.WebControls.CustomRadioButtonList BookBasisTypeRadio;
//		//管理番号K20687 To
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList BookBasisTypeList;
// 管理番号K27058 To
// 管理番号K27154 From
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList DealTypeList;
// 管理番号K27154 To
// 管理番号 K22217 From
        protected Infocom.Allegro.Web.WebControls.StyledButton RouteChangeButton;
// 管理番号 K22217 To
		//隠しコントロール(一時退避用)
		protected System.Web.UI.HtmlControls.HtmlInputHidden ProdNameHdn;				// 商品名
		protected System.Web.UI.HtmlControls.HtmlInputHidden ProdShortNameHdn;			// 商品略名
		protected System.Web.UI.HtmlControls.HtmlInputHidden SellPriceHdn;		// 販売単価
		protected System.Web.UI.HtmlControls.HtmlInputHidden IncludeQtHdn;				// 入数
		protected System.Web.UI.HtmlControls.HtmlInputHidden LotAdminFlgHdn;			// ロット管理フラグ(商品別)
// 管理番号 K25322 From
		protected System.Web.UI.HtmlControls.HtmlInputHidden LotStockValuationFlg;			// ロット別在庫評価フラグ(商品別)
// 管理番号 K25322 To
		protected System.Web.UI.HtmlControls.HtmlInputHidden ProdNameCorrectAllowFlgHdn;// 商品名訂正許可フラグ(商品別)
		protected System.Web.UI.HtmlControls.HtmlInputHidden QtDecimalUseFlgHdn;		// 数量小数点使用フラグ(商品別)
		protected System.Web.UI.HtmlControls.HtmlInputHidden StockAdminFlgHdn;			// 在庫管理フラグ(商品別)
		protected System.Web.UI.HtmlControls.HtmlInputHidden ProdTypeHdn;				// 商品区分(商品別)
		protected System.Web.UI.HtmlControls.HtmlInputHidden ProdEditFlgHdn;			// コード変更許可フラグ
// 管理番号 B12929 From
		protected System.Web.UI.HtmlControls.HtmlInputHidden InitPuPriceHdn;
		protected System.Web.UI.HtmlControls.HtmlInputHidden PriceUpdateFlgHdn;
// 管理番号 B12929 To
// 管理番号 K24789 From
		protected System.Web.UI.HtmlControls.HtmlInputHidden CtaxCalcTypeHdn;
		protected System.Web.UI.HtmlControls.HtmlInputHidden CtaxRateCodeHdn;
		protected System.Web.UI.HtmlControls.HtmlInputHidden CtaxTypeCodeHdn;
		protected System.Web.UI.HtmlControls.HtmlInputHidden TaxInfoChgFlgHdn;
		protected System.Web.UI.HtmlControls.HtmlInputHidden UpdateFlg;
// 管理番号 K24789 To

		protected System.Web.UI.HtmlControls.HtmlInputHidden deleteDate; // 削除日格納用
		// 管理番号 B12891 From
		protected System.Web.UI.WebControls.Label OriginPuDate;
		// 管理番号 B12891 To
		//印刷に必要な追加項目
		protected System.Web.UI.HtmlControls.HtmlInputHidden printListHidden;
		protected System.Web.UI.HtmlControls.HtmlInputHidden clickHidden;
// 管理番号K26528 From
//		protected System.Web.UI.WebControls.Literal ShowsPrintDialogLabel;
// 管理番号K26528 To
		protected System.Web.UI.HtmlControls.HtmlInputHidden reportMessHidden;
		// 管理番号 B13879 From
		protected System.Web.UI.HtmlControls.HtmlInputHidden printHidden;
		// 管理番号 B13879 To
// 管理番号 B20713 From
		protected Infocom.Allegro.Web.WebControls.EncodeLabel LotDtilLabel;
// 管理番号 B20713 To
// 管理番号 B24188 From
		protected Infocom.Allegro.Web.WebControls.StyledButton HoldReleaseButton;
// 管理番号 B24188 To
// 管理番号 B24292 From
		//再処理用のリトライフラグ
		protected System.Web.UI.HtmlControls.HtmlInputHidden retryHidden;
// 管理番号 B24292 To
// 管理番号 K25679 From
		protected Infocom.Allegro.Web.WebControls.CustomTextBox PoAdminNoText;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel SuplSlipNoTitleLabel;
		protected Infocom.Allegro.Web.WebControls.EncodeLabel SuplSlipNoLabel;
// 管理番号 K25679 To
// 管理番号 K25667 From
		protected Infocom.Allegro.Web.WebControls.StyledButton AttachmentFileButton;
// 管理番号 K25667 To
// 管理番号K27057 From
		protected Infocom.Allegro.Web.WebControls.CustomItemPanel CustomItemPanel;
		protected Infocom.Allegro.Web.WebControls.CustomItemPanel InpCustomItemPanel;
		// 管理番号K27057 To

		//2025-01-10 19:31:14 Add by Form
		protected Infocom.Allegro.Web.WebControls.CustomTextBox InputEmpCodeText;
		protected Infocom.Allegro.Web.WebControls.CustomDropDownList CarrierCodeDrop;
		protected Infocom.Allegro.Web.WebControls.CustomRadioButtonList CtaxFractionRoundTypeList;
		//2025-01-10 19:31:14 Add by To
		#endregion

		#region Web フォーム デザイナで生成されたコード
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: この呼び出しは、ASP.NET Web フォーム デザイナで必要です。
			//
			InitializeComponent();
			base.OnInit(e);
		}

// 管理番号K27057 From
		protected override void OnPreInit(EventArgs e)
		{
			// CustomItemPanelは略名取得のイベントハンドラを設定するためにOnInitで部品を構築する。
			// 個別機能のOnPreInit→CustomItemPanelのOnInit→個別機能のOnInitの順で実行されるため
			// 汎用項目、汎用項目機能別設定、汎用項目値設定の情報をCustomItemPanelに渡すタイミングを、OnPreInitにする必要がある。
			// 各情報の取得、CustomItemPanelはCustomItemが行う。
			CustomItem.InitCustomItem(CommonData, ProjectCodeLength, CompanyCodeLength, CustomItemPanel, FocusControl);
			CustomItem.InitCustomItem(CommonData, ProjectCodeLength, CompanyCodeLength, InpCustomItemPanel, FocusControl);
			// 明細編集行用 EditCustomItemControlはインスタンスがないのでInpCustomItemControlから項目を作る。
			CustomItem.InitCustomItem(CommonData, ProjectCodeLength, CompanyCodeLength, InpCustomItemPanel, FocusControl, Page);
		}
// 管理番号K27057 To
		/// <summary>
		/// デザイナ サポートに必要なメソッドです。このメソッドの内容を
		/// コード エディタで変更しないでください。
		/// </summary>
		private void InitializeComponent()
		{
			this.PuDateText.TextChanged += new EventHandler(this.PuDateText_TextChanged);
			this.SuplCodeText.TextChanged += new System.EventHandler(this.SuplCodeText_TextChanged);
			this.PuModeTypeList.SelectedIndexChanged += new System.EventHandler(this.PuModeTypeList_SelectedIndexChanged);
			this.EmpCodeText.TextChanged += new System.EventHandler(this.EmpCodeText_TextChanged);
			this.DeptCodeText.TextChanged += new System.EventHandler(this.DeptCodeText_TextChanged);
			this.ProjCodeText.TextChanged += new System.EventHandler(this.ProjCodeText_TextChanged);
			this.DeliTypeWRadio.CheckedChanged += new System.EventHandler(this.DeliType_CheckedChanged);
			this.WhCodeText.TextChanged += new System.EventHandler(this.WhCodeText_TextChanged);
			this.DeliTypeDRadio.CheckedChanged += new System.EventHandler(this.DeliType_CheckedChanged);
			this.DeliCustCodeText.TextChanged += new System.EventHandler(this.DeliCustCodeText_TextChanged);
// 管理番号K27062 From
//			this.DeliPlaceCodeList.SelectedIndexChanged += new System.EventHandler(this.DeliPlaceCodeList_SelectedIndexChanged);
			this.DeliPlaceCodeText.TextChanged += new System.EventHandler(this.DeliPlaceCodeText_TextChanged);
// 管理番号K27062 To
			this.ZipText.TextChanged += new System.EventHandler(this.ZipText_TextChanged);
			this.DtTypeList.SelectedIndexChanged += new System.EventHandler(this.DtTypeList_SelectedIndexChanged);
			this.Dt1SttlMthdCodeList.SelectedIndexChanged += new System.EventHandler(this.Dt1SttlMthdCodeList_SelectedIndexChanged);
			this.Dt2SttlMthdCodeList.SelectedIndexChanged += new System.EventHandler(this.Dt2SttlMthdCodeList_SelectedIndexChanged);
			this.Dt3SttlMthdCodeList.SelectedIndexChanged += new System.EventHandler(this.Dt3SttlMthdCodeList_SelectedIndexChanged);
			this.CutoffDateBackButton.Click += this.CutoffDateBackButton_Click;
			this.CutoffDateAdvanceButton.Click += this.CutoffDateAdvanceButton_Click;
// 管理番号 B24264 From
//			this.AcTypeList.SelectedIndexChanged += new System.EventHandler(this.AcTypeList_SelectedIndexChanged);
//			this.BankCodeText.TextChanged += new System.EventHandler(this.BankCodeText_TextChanged);
//			this.BankBranchCodeText.TextChanged += new System.EventHandler(this.BankBranchCodeText_TextChanged);
// 管理番号 B24264 To
			this.RemarksCodeText.TextChanged += new System.EventHandler(this.RemarksCodeText_TextChanged);
			this.DataGrid1.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(this.DataGrid1_ItemDataBound);
			this.DataGrid1.ItemClick += new Infocom.Allegro.Web.WebControls.ItemClickEventHandler(this.DataGrid1_ItemClick);
			this.DataGrid1.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(this.DataGrid1_ItemCommand);
			this.InpProdCodeText.TextChanged += new System.EventHandler(this.ProdCode_TextChanged);
			this.InpProdSpec1List.SelectedIndexChanged += new System.EventHandler(this.ProdSpec1List_SelectedIndexChanged);
			this.InpProdSpec2List.SelectedIndexChanged += new System.EventHandler(this.ProdSpec2List_SelectedIndexChanged);
			this.InpWhCodeText.TextChanged += new System.EventHandler(this.RowWhCodeText_TextChanged);
			this.InpUnitList.SelectedIndexChanged += new System.EventHandler(this.UnitList_SelectedIndexChanged);
			this.RegistButton.Click += this.RegistButton_Click;
			this.InpRemarksCodeText.TextChanged += new System.EventHandler(this.LineRemarksCodeText_TextChanged);
			this.InpPanel.Click += new System.EventHandler(this.InpPanel_Click);
			this.InpLotDtilButton.Click += this.InpLotDtilButton_Click;
			this.UpdateButton.Click += this.UpdateButton_Click;
			this.DeleteButton.Click += this.DeleteButton_Click;
			this.PuSlipButton.Click += this.PuSlipButton_Click;
			this.CloseButton.Click += this.CloseButton_Click;
			//管理番号 B13502 From
			this.CurCodeList.SelectedIndexChanged += new System.EventHandler(this.CurCodeList_SelectedIndexChanged);
			this.ExchangeTypeList.SelectedIndexChanged += new System.EventHandler(this.ExchangeTypeList_SelectedIndexChanged);
			this.ExchangeRezNoText.TextChanged += new System.EventHandler(this.ExchangeRezNoText_TextChanged);
			this.RateText.TextChanged += new System.EventHandler(this.RateText_TextChanged);
			//管理番号 B13502 To
			this.Load += new System.EventHandler(this.Page_Load);
			this.PreRender += new System.EventHandler(this.Page_PreRender);
// 管理番号 K22217 From
            this.StatusDropdownlist.SelectedIndexChanged += new System.EventHandler(StatusDropdownlist_SelectedIndexChanged);
            this.RouteChangeButton.Click += this.RouteChangeButton_Click;
// 管理番号 K22217 To
// 管理番号 K22270 From
			this.DataGrid1.PageIndexChanged += new System.Web.UI.WebControls.DataGridPageChangedEventHandler(this.DataGrid_PageIndexChanged);
// 管理番号 K22270 To
// 管理番号 K24389 From
			this.InpPuQtText.TextChanged += new System.EventHandler(this.InpPuQtText_TextChanged);
// 管理番号 K24389 To
// 管理番号 B24188 From
			this.HoldReleaseButton.Click += this.HoldReleaseButton_Click;
// 管理番号 B24188 To
// 管理番号 K24789 From
			this.DealDateText.TextChanged += new System.EventHandler(this.DealDateText_TextChanged);
			this.InpTaxInfoButton.Click += this.InpTaxInfoButton_Click;
// 管理番号 K24789 To
// 管理番号 K25667 From
			this.AttachmentFileButton.Click += this.AttachmentFileButton_Click;
			// 管理番号 K25667 To

			this.InputEmpCodeText.TextChanged += new System.EventHandler(this.InputEmpCodeText_TextChanged);
		}
		#endregion

		#region 初期動作
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!IsPostBack)
			{
				HtmlTableRow InpTable;
				switch (this.ProductSpecUseType)
				{
					case "0":
						HeaderTable.Rows[0].Cells[2].Visible	= false;
// 管理番号K26528 From
//// 管理番号 K24546 From
////						DataGrid1.Columns[1].ItemStyle.Width	= System.Web.UI.WebControls.Unit.Pixel(226);
//						DataGrid1.Columns[1].ItemStyle.Width	= System.Web.UI.WebControls.Unit.Pixel(361);
//// 管理番号 K24546 To
// 管理番号K26528 To
						DataGrid1.Columns[2].Visible			= false;
						InpTable = ((HtmlTable)InpPanel.FindControl(InputTable.ID)).Rows[0];
						InpTable.Cells[2].Visible				= false;
						InpProdCodeText.NextControlID			= InpProdNameText.ID;
						break;
					case "1":
						HeaderTable.Rows[0].Cells[2].Visible	= true;
// 管理番号K26528 From
//// 管理番号 K24546 From
////						DataGrid1.Columns[1].ItemStyle.Width	= System.Web.UI.WebControls.Unit.Pixel(153);
//						DataGrid1.Columns[1].ItemStyle.Width	= System.Web.UI.WebControls.Unit.Pixel(288);
//// 管理番号 K24546 To
// 管理番号K26528 To
						DataGrid1.Columns[2].Visible			= true;
						InpTable = ((HtmlTable)InpPanel.FindControl(InputTable.ID)).Rows[0];
						InpTable.Cells[2].Visible				= true;
						InpProdCodeText.NextControlID			= InpProdNameText.ID;
						HeaderSpec1NameLabel.Text				= this.ProductSpec1Name;
						HeaderSpec2NameLabel.Text				= string.Empty;
						InpProdSpec2List.Visible				= false;
						break;
					case "2":
						HeaderTable.Rows[0].Cells[2].Visible	= true;
// 管理番号K26528 From
//// 管理番号 K24546 From
////						DataGrid1.Columns[1].ItemStyle.Width	= System.Web.UI.WebControls.Unit.Pixel(153);
//						DataGrid1.Columns[1].ItemStyle.Width	= System.Web.UI.WebControls.Unit.Pixel(288);
//// 管理番号 K24546 To
// 管理番号K26528 To
						DataGrid1.Columns[2].Visible			= true;
						InpTable = ((HtmlTable)InpPanel.FindControl(InputTable.ID)).Rows[0];
						InpTable.Cells[2].Visible				= true;
						HeaderSpec1NameLabel.Text				= this.ProductSpec1Name;
						HeaderSpec2NameLabel.Text				= this.ProductSpec2Name;
						break;
				}

				this.paramType	= keyColumn.ParamType = Request.QueryString[ViewStateType.PARAM_TYPE];
				this.refType	= keyColumn.RefType   = Request.QueryString[ViewStateType.REF_TYPE] == null ? RefCodeType.NONE : Request.QueryString[ViewStateType.REF_TYPE];
				this.slipNo		= keyColumn.SlipNo    = Request.QueryString[ViewStateType.SLIP_NO] == null ? string.Empty : Request.QueryString[ViewStateType.SLIP_NO];
				this.lockedPuNo						  = Request.QueryString[ViewStateType.LOCK_PU_NO] == null ? string.Empty : Request.QueryString[ViewStateType.LOCK_PU_NO];
// 管理番号K27058 From
				this.puModeTypeDtilCodeHidden			= Request.QueryString["PuModeTypeDtilCodeHidden"] == null ? string.Empty : Request.QueryString["PuModeTypeDtilCodeHidden"];
// 管理番号K27058 To
// 管理番号 B19446 From
				// 参照コードタイプNone、パラムタイプMOD、参照伝票番号あり　これは修正の伝票参照なので、RefTypeにPUを設定
				if ( RefCodeType.NONE.Equals(this.refType) && ParamCodeType.MOD.Equals(this.paramType) && this.slipNo != string.Empty )
				{
					this.refType	= keyColumn.RefType   = "PU";
				}
// 管理番号 B19446 To
// 管理番号 K22217 From
                SessionRemove();
// 管理番号 K22217 To
				curDigit = Cur.GetDecimalDigit(this.CommonData, this.KeyCurrencyCode);

				//ページ権限・ログインユーザ部門セット
				keyColumn.DisclosureUnitType	= this.DisclosureUnitType;
				keyColumn.UserDeptCode			= this.UserDeptCode;
// 管理番号 K24789 From
				// 日付管理区分セット
				keyColumn.DateAdminType			= this.DateAdminType;
// 管理番号 K24789 To
// 管理番号K27058 From
				// 仕入参照（返品）時に入力された仕入形態区分明細コードを引き継ぐ
				keyColumn.PuModeTypeDtilCode	= this.puModeTypeDtilCodeHidden;
// 管理番号K27058 To

				//【例外】修正モードにも関わらず受注番号が空で渡ってきた場合は新規モードに切換える
				if (this.slipNo.Length == 0 && this.paramType == ParamCodeType.MOD)
				{
					this.paramType = ParamCodeType.NEW;
// 管理番号 B21695 From
                    keyColumn.ParamType = ParamCodeType.NEW;
// 管理番号 B21695 To
				}

				// 画面が最初に開かれた場合なのでロックを解除
				if (this.lockedPuNo.Length > 0)
				{
					if (!releaseLock(this.lockedPuNo))
					{
						return;
					}
				}
// 管理番号 K22270 From
				DataGrid1.CurrentPageIndex = 0;
// 管理番号 K24390 From
//				viewnum = PageSize;
				//詳細タブ　表示明細数の規定値は3明細
				if (this.SC_MM_05_S02_DtilNumber < 3 || 99 < this.SC_MM_05_S02_DtilNumber)
				{
					viewnum = 3;
				}
				else
				{
					viewnum = this.SC_MM_05_S02_DtilNumber;
				}
// 管理番号 K24390 To
// 管理番号 K22270 To
				setDefaultData();

				try
				{
					if (paramType==ParamCodeType.MOD || paramType==ParamCodeType.VIEW)
					{
						//諸掛存在有無チェック
						isChargePuExists = BL_SC_MM_05.IsChargePuExists(this.CommonData, slipNo);
					}
				}
				catch(AllegroException ex)
				{
					setMessageLabel(HtmlMessage(ex.Message, MessageLevel.Warning));
				}

				switch (paramType)
				{
					case ParamCodeType.MOD:
					case ParamCodeType.VIEW:
// 管理番号 K25667 From
						// 添付資料情報のセッションを新規作成する
						this.attachmentFiles = new CM.WF.IF_CM_WF_AttachmentFiles();
// 管理番号 K25667 To
						if (searchExecute())
						{
// 管理番号 K25679 From
							if (rowData.SuplSlipNo.Length != 0)
							{
								correctAllowFlg = (Allegro.CM.MS.FileImportPrg.GetCorrectFlg(this.CommonData,"CM_GR_PU") == "1")? true:false;
							}
// 管理番号 K25679 To
// 管理番号 K25680 From
							if (rowData.ImportSlipNo.Length != 0 && rowData.SuplSlipNo.Length == 0)
							{
								correctAllowFlg = (Allegro.CM.MS.FileImportPrg.GetCorrectFlg(this.CommonData, "SC_MM_PU") == "1")? true:false;
							}
// 管理番号 K25680 To
							if (this.paramType == ParamCodeType.MOD)
							{
// 管理番号 K25679 From			
								// グループ間取引伝票で修正許可フラグが許可でない場合
								if (rowData.SuplSlipNo.Length != 0 && !correctAllowFlg)
								{
									paramType = ParamCodeType.VIEW;
								}
// 管理番号 K25679 To
// 管理番号 K25680 From
								// EDI伝票で修正許可フラグが許可でない場合
								if (rowData.ImportSlipNo.Length != 0 && rowData.SuplSlipNo.Length == 0 && !correctAllowFlg)
								{
									paramType = ParamCodeType.VIEW;
								}
// 管理番号 K25680 To
								// 承認対象でかつ発注部門時にワークフローで申請者以外だった時だったら参照モードにする
// 管理番号 K25679 From
//								if (approvalFlg && !Infocom.Allegro.CM.WF.Common.IsApplicant(this.CommonData, pageCode, slipNo, this.UserDeptCode, this.UserCode))
								if (approvalFlg && !Infocom.Allegro.CM.WF.Common.IsApplicant(this.CommonData, slipType, slipNo, this.UserDeptCode, this.UserCode))
// 管理番号 K25679 To
								{
									this.paramType = ParamCodeType.VIEW;
								}
								else
								{
									//参照モード
									// １.消込あり
									// ２.相手仕入番号が入っている
									// ３.ワークフロー対象伝票で申請者以外が開いた時
									// ４.ワークフロー対象伝票で承認状況区分が途中または決裁
									// ５.悲観ロック失敗
									// ６.出合フラグ = 1 のデータは「修正」モードで開けない。
// 管理番号 K16187 From
//									if((rowData.DtType == "L" && rowData.CutoffFinFlg == "1") || (rowData.DtType == "E" && rowData.KoAmt > 0))
// 管理番号K27064 From
//									if((rowData.DtType == "L" && rowData.CutoffFinFlg == "1") 
//										|| rowData.KoAmt > 0 || rowData.ApprovedKoAmt > 0 
									if (rowData.KoAmt > 0 || rowData.ApprovedKoAmt > 0
// 管理番号K27064 To
// 管理番号 K22196 From
//										|| rowData.DtilKoFlg == "1" || rowData.DeleteAllowFlg == "1")
										|| rowData.DtilKoFlg == "1" || rowData.DeleteAllowFlg != "0")
// 管理番号 K22196 To
// 管理番号 K16187 To
									{
										this.paramType = ParamCodeType.VIEW;
									}
// 管理番号 B23437 From
//									else if (rowData.CanceledOrderFlg=="1")
//									{
//										this.paramType = ParamCodeType.VIEW;
//									}
// 管理番号 B23437 To
									else if (rowData.OppositePuNo.Length > 0)
									{
										this.paramType = ParamCodeType.VIEW;
									}
// 管理番号 K25679 From
//									else if (approvalFlg && !Infocom.Allegro.CM.WF.Common.IsApplicant(this.CommonData, pageCode, slipNo, rowData.DeptCode ,this.UserCode))
									else if (approvalFlg && !Infocom.Allegro.CM.WF.Common.IsApplicant(this.CommonData, slipType, slipNo, rowData.DeptCode ,this.UserCode))
// 管理番号 K25679 To
									{
										this.paramType = ParamCodeType.VIEW;
									}
// 管理番号 K20685 From
									else if (approvalFlg && ((this.StatusDropdownlist.SelectedValue == "2")||(this.StatusDropdownlist.SelectedValue == "3")))
									{
										this.paramType = ParamCodeType.VIEW;
									}
// 管理番号 K20685 To
// 管理番号 B23437 From
									else if (rowData.CanceledOrderFlg=="1")
									{
										this.paramType = ParamCodeType.VIEW;
										string saNo = getSaNo(slipNo);
										if (approvalFlg && !Infocom.Allegro.CM.WF.Common.IsApplicant(this.CommonData, "SD6", saNo, rowData.DeptCode, this.UserCode))
										{
											holdReleaseFlg = false;
										}
										else
										{
											holdReleaseFlg = true;
										}
									}
// 管理番号 B23437 To
									else if (!getLock(slipNo))
									{
										this.paramType = ParamCodeType.VIEW;
									}
								}								
							}
							this.InputEmpCodeText.Text = rowData.InputEmpCode;
							this.InputEmpNameLable.Text = string.Empty;
							CarrierCodeDrop.SelectedValue = rowData.CtaxFractionRoundType; 
							CtaxFractionRoundTypeList.SelectedValue = rowData.CtaxFractionRoundType;
							this.CarrierCodeDrop.SelectedValue = rowData.CarrierCode;
                            if (this.paramType == ParamCodeType.VIEW)
                            {
								InputEmpCodeText.Enable = false;
								CtaxFractionRoundTypeList.Enable = false;
								CarrierCodeDrop.Enable = false;
							}
						}
						else
						{
							this.paramType	   = string.Empty;
							this.PuNoText.Text = slipNo;
							slipNo             = string.Empty;
// 管理番号 B20853 From
							setApproval(Request.QueryString["DeptCode"] !=null ? Request.QueryString["DeptCode"] : this.UserDeptCode);
// 管理番号 B20853 To
						}
						break;
					case ParamCodeType.NEW:
					case ParamCodeType.COPY:
					case ParamCodeType.COPY_PO:
					case ParamCodeType.COPY_RC:
					case ParamCodeType.REF_PU:
						//在庫管理部門変更対応-INSERT-START
						//新規モードで参照なし(部門が変更された場合)
						if(Request.QueryString["DeptCode"]!=null)
						{
							this.EmpCodeText.Text   = Request.QueryString["EmpCode"]		== null ? this.UserCode		: Request.QueryString["EmpCode"].ToString() ;
							this.EmpNameLabel.Text  = Request.QueryString["EmpShortName"]	== null ? this.UserName		: Request.QueryString["EmpShortName"].ToString() ;
							this.DeptCodeText.Text  = Request.QueryString["DeptCode"]		== null ? this.UserDeptCode : Request.QueryString["DeptCode"].ToString() ;
							this.DeptNameLabel.Text = Request.QueryString["DeptShortName"]	== null ? this.UserDeptName : Request.QueryString["DeptShortName"].ToString() ;
// 管理番号 B22309 From
							this.WhCodeText.Text  = Request.QueryString["WhCode"];
							this.WhShortNameLabel.Text = Request.QueryString["WhShortName"];
							setWhPlace(this.WhCodeText.Text);
// 管理番号 B22309 To
						}
						//在庫管理部門変更対応-INSERT-END
// 管理番号 B24749 From
						if (Request.QueryString["ProjCode"]!=null)
						{
							this.ProjCodeText.Text  = Request.QueryString["ProjCode"]	== null ? string.Empty : Request.QueryString["ProjCode"].ToString() ;
							this.ProjNameLabel.Text = Request.QueryString["ProjName"]	== null ? string.Empty : Request.QueryString["ProjName"].ToString() ;
						}
// 管理番号 B24749 To
						if (refType != RefCodeType.NONE && keyColumn.SlipNo.Length!=0)
						{
							if (!searchExecute())
							{
								switch (refType)
								{
									case RefCodeType.PO:
										this.PoRefText.Text = slipNo;
										FocusControl(this.PoRefText.UniqueID);
										break;
									case RefCodeType.RCPT:
										this.RcptRefText.Text = slipNo;
										FocusControl(this.RcptRefText.UniqueID);
										break;
									case RefCodeType.REF_PU:
										this.RefPuText.Text = slipNo;
										FocusControl(this.RefPuText.UniqueID);
										break;
								}
								slipNo = string.Empty;
								if (paramType != ParamCodeType.COPY)
								{
									paramType = ParamCodeType.NEW;
								}
							}
						}
// 管理番号 B21051 From
//// 管理番号 B20853 From
//						setApproval(Request.QueryString["DeptCode"] !=null ? Request.QueryString["DeptCode"] : this.UserDeptCode);
//// 管理番号 B20853 To
						setApproval(Request.QueryString["DeptCode"] != null ? Request.QueryString["DeptCode"] : (rowData != null ? rowData.DeptCode : this.UserDeptCode));
// 管理番号 B21051 To
// 管理番号 K25667 From
						// 添付資料情報のセッションを新規作成する
						this.attachmentFiles = new CM.WF.IF_CM_WF_AttachmentFiles();
                        // 管理番号 K25667 To
                        if (this.paramType==ParamCodeType.NEW)
                        {
							this.InputEmpCodeText.Text = this.UserCode;
							this.InputEmpNameLable.Text = this.UserName;
							this.CtaxFractionRoundTypeList.SelectedIndex = 0;
							this.CarrierCodeDrop.SelectedIndex = 0;
						}
                        else if (this.paramType == ParamCodeType.COPY)
                        {
							this.InputEmpCodeText.Text = this.UserCode;
							this.InputEmpNameLable.Text = this.UserName;
                            if (rowData!=null)
                            {
								this.CtaxFractionRoundTypeList.SelectedValue = rowData.CtaxFractionRoundType;
								this.CarrierCodeDrop.SelectedValue = rowData.CarrierCode;
							}
						}
						else if (this.paramType == ParamCodeType.COPY_PO)
						{
							this.InputEmpCodeText.Text = this.UserCode;
							this.InputEmpNameLable.Text = this.UserName;
							if (rowData != null)
							{
								//·消费税尾数：从订购发票的采购处取得并设定消费税尾数。 TODO
								//this.CtaxFractionRoundTypeList.SelectedValue = rowData.CtaxFractionRoundType;
								this.CarrierCodeDrop.SelectedIndex = 0;
							}
						}
						else if (this.paramType == ParamCodeType.COPY_RC)
						{
							this.InputEmpCodeText.Text = this.UserCode;
							this.InputEmpNameLable.Text = this.UserName;
							this.CarrierCodeDrop.SelectedIndex = 0;
							
						}
						break;
				}

				setNewControlCondition(true);
// 管理番号 B24188 From
				SetDispHoldReleaseButton();
// 管理番号 B24188 To
				this.DataGrid1.AutoPostBack = (paramType != ParamCodeType.VIEW && paramType.Length > 0);
				this.InpPanel.DataBind();

				if (rowData == null)
				{
					rowData = new IF_SC_MM_05_S02_RowData();
// 管理番号K27057 From
//				}
					CustomItem.SetDataColumnCollection(InpCustomItemPanel, "CUSTOM_ITEM_TAG", rowData.Dt.Columns);
				}
				CustomItem.SetValidateInfo(CommonData, CustomItemPanel, rowData.CustomItemHead);
				CustomItem.SetValidateInfo(CommonData, InpCustomItemPanel, rowData.CustomItemDtil);
// 管理番号K27057 To
				Session.Add(PageID + "_IF", rowData);

				rowData.ProdSpec1CodeTitle = this.ProductSpec1Name;
				rowData.ProdSpec2CodeTitle = this.ProductSpec2Name;
			}
			else
			{
				this.keyColumn		= (IF_SC_MM_05_S02_KeyColumn) ViewState[ViewStateType.KEY_COLUMN];
				this.rowData		= (IF_SC_MM_05_S02_RowData) Session[PageID + "_IF"];
				this.paramType		= (string) ViewState[ViewStateType.PARAM_TYPE];
				this.refType		= (string) ViewState[ViewStateType.REF_TYPE];
				this.slipNo			= (string) ViewState[ViewStateType.SLIP_NO];
				this.lockedPuNo		= (string) ViewState[ViewStateType.LOCK_PU_NO];
				this.curDigit		= (string) ViewState[ViewStateType.CUR_DIGIT];
				this.approvalFlg	= (bool) ViewState[ViewStateType.APPROVAL_FLG];
				this.isChargePuExists = (bool) ViewState[ViewStateType.IS_CHARGE_EXISTS];
// 管理番号 K25679 From
				this.correctAllowFlg  = (bool)ViewState["CorrectAllowFlg"];
// 管理番号 K25679 To
// 管理番号 K22217 From
                appEmpCode = Session["CM_WF_03_S08_AppEmp"] == null ? string.Empty: (string)Session["CM_WF_03_S08_AppEmp"];
                appRouteId = Session["CM_WF_03_S08_AppRouteId"] == null ? string.Empty : (string)Session["CM_WF_03_S08_AppRouteId"];
// 管理番号 K22217 To
				this.insertFlg		= (bool) ViewState["InsertFlg"];
				this.returnValue	= Request.Form["__ReturnValue"]; //ポップアップ次画面の戻り値取得

				if (Request.Form["__EVENTTARGET"] == DtTypeList.ID)
				{
					FocusControl(new StringBuilder(DtTypeList.ID).Append("_").Append(DtTypeList.SelectedIndex.ToString()).ToString());
				}

				setMessageLabel(string.Empty);
// 管理番号 K22270 From
				viewnum = (int)ViewState["ViewNum"];
// 管理番号 K22270 To
// 管理番号 K25667 From
				attachmentCancelFlg = (string)ViewState["AttachmentCancelFlg"];
				attachmentRedSlipFlg = (string)ViewState["AttachmentRedSlipFlg"];
				slipType = (string)ViewState["SlipType"];
// 管理番号 K25667 To
// 管理番号 B24264 From
			tempRowData = (Hashtable)Session["SC_MS_02_S20_TempSuplData"];
// 管理番号 B24264 To
// 管理番号K27057 From
				CustomItem.SetValidateInfo(CommonData, CustomItemPanel, rowData.CustomItemHead);
				CustomItem.SetValidateInfo(CommonData, InpCustomItemPanel, rowData.CustomItemDtil);
// 管理番号K27057 To
			}

			//印刷に必要な追加項目
// 管理番号 B18049 From
//			this.ShowsPrintDialogLabel.Text=Infocom.Allegro.CM.MS.Report.ShowsPrintDialog(this.CommonData,"SC_MM_05_R03",Infocom.Allegro.Report.ScreenType.ReportPrint).ToString();			
// 管理番号 B18049 To
// 管理番号 K24390 From
//// 管理番号 K22270 From
//			DataGrid1.PageSize = PageSize;
//// 管理番号 K22270 To
// 管理番号 K24390 To
// 管理番号K27057 From
			if (-1 < DataGrid1.EditItemIndex)
			{
				InpCustomItemPanel.Enable = false;
				CustomItemPanel cip = (CustomItemPanel)DataGrid1.Items[this.DataGrid1.EditItemIndex].FindControl("EditCustomItemPanel");
				cip.SetEvent(CustomItemPanel_TextChanged);
			}
			else
			{
				InpCustomItemPanel.SetEvent(CustomItemPanel_TextChanged);
			}
			CustomItemPanel.SetEvent(CustomItemPanel_TextChanged);
// 管理番号K27057 To
		}		
		private void Page_PreRender(object sender, System.EventArgs e)
		{
			string focusControl = this.CloseButton.ID;

			if (useBind)
			{
// 管理番号K26508 From
				// 参照権限時のデータグリッド制御
				viewAuthorityUnclickableDataGrid(this.DataGrid1);
// 管理番号K26508 To
				DataGrid1.DataBind();
			}
// 管理番号 B23588 From
			if (rowData.Dt.Select("ROW_STATE = 'T'").Length == 0)
			{
				insertFlg = false;
			}
// 管理番号 B23588 To

			//伝票番号は常に自動採番
			PuNoText.ReadOnly		= true;

			//ボタン初期制御
			DeleteButton.Enabled	= false;
			PuSlipButton.Enabled	= false;

			switch(paramType)
			{
				case ParamCodeType.NEW:	//新規
				case ParamCodeType.COPY:
				case ParamCodeType.COPY_PO:
				case ParamCodeType.COPY_RC:
				case ParamCodeType.REF_PU:
// 					this.ModeLabel.Text = "新規"; //K24546
					this.ModeLabel.Text = MultiLanguage.Get("SC_CS001236");
					if (refType != RefCodeType.NONE && slipNo.Length != 0)
					{
						switch(refType)
						{
							case RefCodeType.PO:
								this.PoRefText.Text = slipNo;
// 管理番号K27058 From
////管理番号K20687 From
//								this.BookBasisTypeRadio.Enabled = false;//発注参照
////管理番号K20687 To
								this.BookBasisTypeList.Enabled = false; //発注参照
// 管理番号K27058 To
								break;
							case RefCodeType.RCPT:
								this.PoRefText.Text		= rowData.PoNo;
								this.RcptRefText.Text	= slipNo;
// 管理番号K27058 From
////管理番号K20687 From
//								this.BookBasisTypeRadio.Enabled = false;//入荷参照
////管理番号K20687 To
								this.BookBasisTypeList.Enabled = false; //入荷参照
// 管理番号K27058 To
								break;
							case RefCodeType.REF_PU:
								this.RefPuText.Text = slipNo;
// 管理番号K27058 From
////管理番号K20687 From
//								this.BookBasisTypeRadio.Enabled = false;//仕入参照
////管理番号K20687 To
								this.BookBasisTypeList.Enabled = false; //仕入参照
// 管理番号K27058 To
								break;
						}
						this.PoRefText.Enabled		= false;
						this.RcptRefText.Enabled	= false;
						this.RefPuText.Enabled		= false;

					}
					else
					{
						this.PoRefText.Enabled		= true;
						this.RcptRefText.Enabled	= true;
						this.RefPuText.Enabled		= true;
// 管理番号K27058 From
////管理番号K20687 From
//						this.BookBasisTypeRadio.Enabled = true;//新規時参照なしは活性
////管理番号K20687 To
						this.BookBasisTypeList.Enabled = true; //新規時参照なしは活性
// 管理番号K27058 To
					}
					//諸掛閲覧
					this.ChargeBrowseButton.Enabled  = false;

					if (this.PoRefText.Enabled)
					{
						focusControl = this.PoRefText.ID;
					}
					else
					{
						focusControl = this.PuDateText.ID;
					}
// 管理番号B23625 From
					this.CurCodeList.Enabled = this.MultiCurUseFlg;
// 管理番号B23625 To
// 管理番号 B23136 From
					if((this.PoRefText.Text.Length != 0 || this.RcptRefText.Text.Length != 0))
					{
						this.CurCodeList.Enabled = false;
					}
// 管理番号 B23136 To
// 管理番号 K25667 From
					// 新規モード時は活性にする
					this.AttachmentFileButton.Visible = true;
// 管理番号 K25667 To
					break;
				case ParamCodeType.MOD:	//修正
// 					this.ModeLabel.Text		  = "修正"; //K24546
					this.ModeLabel.Text		  = MultiLanguage.Get("SC_CS001014");
					this.PuNoText.Text		  = slipNo;
					this.PuNoText.ReadOnly	  = false;
					this.PoRefText.Text       = rowData.PoNo;
					this.PoRefText.Enabled	  = false;		//参照禁止
					this.RcptRefText.Text     = rowData.RcptNo;
					this.RcptRefText.Enabled  = false;		//参照禁止
					this.RefPuText.Text       = rowData.RefPuNo;
					this.RefPuText.Enabled	  = false;		//参照禁止
					this.PuSlipButton.Enabled = !(IsDirty);	//ダーティー時に帳票出力は押下不可
// 管理番号B23625 From
					this.CurCodeList.Enabled  = this.MultiCurUseFlg;
// 管理番号B23625 To
// 管理番号 B17614 From
// 管理番号 B23136 From
//					if((this.PoRefText.Text.Length != 0 || this.RcptRefText.Text.Length != 0) && this.KeyCurrencyCode != this.CurCodeList.SelectedValue.Trim() )
					if((this.PoRefText.Text.Length != 0 || this.RcptRefText.Text.Length != 0))
// 管理番号 B23136 To
					{
						this.CurCodeList.Enabled = false;
// 管理番号 B24845 From
						if (this.ExchangeRezNoText.Text.Length > 0 && rowData.RefPoExchangeType == "1")
						{
// 管理番号 B24845 To
							this.ExchangeTypeList.Enabled = false;
							this.ExchangeRezNoText.Enabled = false;
							this.RateText.Enabled = false;
// 管理番号 B24845 From
						}
// 管理番号 B24845 To
					}
// 管理番号 B17614 To
//管理番号K20687 From
					if(this.PoRefText.Text.Length != 0)
					{
// 管理番号K27058 From
//						this.BookBasisTypeRadio.Enabled = false;//発注参照
						this.BookBasisTypeList.Enabled = false; //発注参照
// 管理番号K27058 To
					}
					else if(this.RcptRefText.Text.Length != 0)
					{
// 管理番号K27058 From
//						this.BookBasisTypeRadio.Enabled = false;//入荷参照
						this.BookBasisTypeList.Enabled = false; //入荷参照
// 管理番号K27058 To
					}
					else if(this.RefPuText.Text.Length != 0)
					{
// 管理番号K27058 From
//						this.BookBasisTypeRadio.Enabled = false;//入荷参照
						this.BookBasisTypeList.Enabled = false; //仕入参照
// 管理番号K27058 To
					}
					else
					{
// 管理番号K27058 From
//						this.BookBasisTypeRadio.Enabled = true;
						this.BookBasisTypeList.Enabled = true;
// 管理番号K27058 To
					}


//管理番号K20687 To
					//削除ボタン制御
					// 管理番号 B11723・B11796 From
					//					this.DeleteButton.Enabled = !(decimal.Parse(Common.FormatAmt(rowData.KoAmt, curDigit ,false ,"2")) > 0M);
// 管理番号 K16187 From
//					this.DeleteButton.Enabled = (rowData.KoAmt == 0M);
					this.DeleteButton.Enabled = (rowData.KoAmt == 0M && rowData.ApprovedKoAmt == 0M && rowData.DtilKoFlg == "0");
// 管理番号 K16187 To
// 管理番号B25370 From
					if (0 < rowData.ChargeCount
						|| rowData.IsReferringSlipExists
						)
					{
						// 諸掛伝票に按分されている仕入伝票、返品が発生している仕入伝票は削除ボタン押下不可
						this.DeleteButton.Enabled = false;
					}
// 管理番号B25370 To
					// 管理番号 B11723・B11796 To
					//諸掛閲覧
					this.ChargeBrowseButton.Enabled  = isChargePuExists;

// 管理番号 B22403 From
//					focusControl = PuNoText.ID;
					FocusControl(PuNoText.ID);
// 管理番号 B22403 To
// 管理番号 K25667 From
					if (attachmentCancelFlg == "1" || attachmentRedSlipFlg == "1")
					{
						// 赤伝票の場合は添付資料ボタンを非表示とする
						this.AttachmentFileButton.Visible = false;
					}
					else if (!correctAllowFlg)
					{
						if (rowData.SuplSlipNo.Length != 0)
						{
							// グループ間取引伝票の場合
							bool WorkflowUseFlg = (string.IsNullOrEmpty(this.DeptCodeText.Text.Trim())
								? CM.WF.Common.IsApp(this.CommonData, slipType)
								: CM.WF.Common.IsApp(this.CommonData, slipType, this.DeptCodeText.Text.Trim()))
									? true
									: false;
							if (WorkflowUseFlg == true)
							{
								//ワークフロー使用する場合は表示
								this.AttachmentFileButton.Visible = true;
							}
							else
							{
								//ワークフロー使用しない場合は非表示
								this.AttachmentFileButton.Visible = false;
							}
						}
						else if (rowData.ImportSlipNo.Length != 0)
						{
							// EDI伝票の場合
							this.AttachmentFileButton.Visible = false;
						}
						else
						{
							this.AttachmentFileButton.Visible = true;
						}
					}
					else if (rowData.CanceledOrderFlg == "1")
					{
						// 出合の場合
						this.AttachmentFileButton.Visible = false;
					}
					else
					{
						this.AttachmentFileButton.Visible = true;
					}
// 管理番号 K25667 To
					break;
				case ParamCodeType.VIEW: //参照
				default: //例外
					if (paramType == ParamCodeType.VIEW )
					{
// 管理番号 B23437 From
//// 						this.ModeLabel.Text					= "参照"; //K24546
//						this.ModeLabel.Text					= MultiLanguage.Get("SC_CS000765");
						if (holdReleaseFlg)
						{
							//"修正"
							this.ModeLabel.Text = MultiLanguage.Get("SC_CS001014");
						}
						else
						{
							//"参照"
							this.ModeLabel.Text = MultiLanguage.Get("SC_CS000765");
							if (this.lockedPuNo.Length > 0)
							{
								releaseLock(this.lockedPuNo);
							}
						}
// 管理番号 B23437 To
						this.PuNoText.Text		            = slipNo;
						this.PuSlipButton.Enabled = true;
// 管理番号 B22403 From
//						FocusControl(PuSlipButton.ID);
						FocusControl(PuNoText.ID);
// 管理番号 B22403 To
// 管理番号 K25667 From
						if (attachmentCancelFlg == "1" || attachmentRedSlipFlg == "1")
						{
							// 赤伝票の場合は添付資料ボタンを非表示とする
							this.AttachmentFileButton.Visible = false;
						}
						else if (rowData.CanceledOrderFlg == "1")
						{
							// 出合の場合
							this.AttachmentFileButton.Visible = false;
						}
						//修正許可しない場合
						else if (!correctAllowFlg)
						{
							if (rowData.SuplSlipNo.Length != 0)
							{
								// グループ間取引伝票の場合
								bool WorkflowUseFlg = (string.IsNullOrEmpty(this.DeptCodeText.Text.Trim())
									? CM.WF.Common.IsApp(this.CommonData, slipType)
									: CM.WF.Common.IsApp(this.CommonData, slipType, this.DeptCodeText.Text.Trim()))
										? true
										: false;
								if (WorkflowUseFlg == true)
								{
									//ワークフロー使用する場合は表示
									this.AttachmentFileButton.Visible = true;
								}
								else
								{
									//ワークフロー使用しない場合は非表示
									this.AttachmentFileButton.Visible = false;
								}
							}
							else if (rowData.ImportSlipNo.Length != 0)
							{
								// EDI伝票の場合
								this.AttachmentFileButton.Visible = false;
							}
							else
							{
								this.AttachmentFileButton.Visible = true;
							}
						}
						else
						{
							this.AttachmentFileButton.Visible = true;
						}
// 管理番号 K25667 To
					}
					else
					{
						this.ModeLabel.Text				= string.Empty;
						this.PuSlipButton.Enabled			= false;
						FocusControl(PuNoText.ID);
// 管理番号 K25667 From
						// データがない場合は添付資料ボタンを非表示とする
						this.AttachmentFileButton.Visible = false;
// 管理番号 K25667 To
					}
					this.PuNoText.ReadOnly	            = false;
					this.PoRefText.Text                 = rowData.PoNo;
					this.PoRefText.Enabled	            = false;		//参照禁止
					this.RcptRefText.Text               = rowData.RcptNo;
					this.RcptRefText.Enabled            = false;		//参照禁止
					this.RefPuText.Text                 = rowData.RefPuNo;
					this.RefPuText.Enabled	            = false;		//参照禁止
					this.PuNoText.NextControlID			= this.CloseButton.UniqueID;
// 管理番号K27058 From
////管理番号K20687 From
//					this.BookBasisTypeRadio.Enabled = false;//参照時は非活性
////管理番号K20687 To
					this.BookBasisTypeList.Enabled = false; //参照時は非活性
// 管理番号K27058 To
// 管理番号 K16590 From
					this.DealDateText.Enabled			= false;
// 管理番号 K16590 To
					this.UpdateButton.Enabled			= false;
					this.CancelButton.Enabled			= false;
// 管理番号 B24264 From
//					// ヘッダ(タブ外)、データグリッドのコントロールを非活性化
//					base.Mode = Infocom.Allegro.Web.PageMode.Reference;
// 管理番号 B24264 To
					// タブ内のコントロールを非活性化
					this.PuNameText.Enabled				= false;
// 管理番号 B16693 From
					this.ExchangeTypeList.Enabled		= false;
					this.ExchangeRezNoText.Enabled		= false;
					this.RateText.Enabled				= false;
// 管理番号 B16693 To
// 管理番号K27062 From
//					this.DeliPlaceCodeList.Enabled      = false;
					this.DeliPlaceCodeText.Enabled		= false;
// 管理番号K27062 To
					this.DeliPlaceNameText.Enabled      = false;
// 管理番号 B24264 From
//					this.SuplFormalNameText.Enabled = false;
//					this.SuplUserNameText.Enabled       = false;
//					this.SuplDeptName1Text.Enabled      = false;
//					this.SuplDeptName2Text.Enabled      = false;
// 管理番号 B24264 To
					this.ZipText.Enabled				= false;
					this.StateText.Enabled				= false;
					this.CityText.Enabled				= false;
					this.Address1Text.Enabled			= false;
					this.Address2Text.Enabled			= false;
					this.PhoneText.Enabled				= false;
					this.FaxText.Enabled				= false;
					this.DeliUserNameText.Enabled		= false;
					this.CutoffDateText.Enabled			= false;
					this.CutoffDateBackButton.Enabled	= false;
					this.CutoffDateAdvanceButton.Enabled = false;
					this.PymtPlanDateText.Enabled		= false;
					this.DtTypeList.Enabled				= false;
					this.Dt1SttlMthdCodeList.Enabled	= false;
					this.Dt1BasisAmtText.Enabled		= false;
					this.Dt2RatioText.Enabled			= false;
					this.Dt2SttlMthdCodeList.Enabled	= false;
					this.Dt3SttlMthdCodeList.Enabled	= false;
					this.DtSightText.Enabled			= false;
// 管理番号 B24264 From
//					this.AcTypeList.Enabled = false;
//					this.BankCodeText.Enabled			= false;
//					this.BankBranchCodeText.Enabled		= false;
//					this.BankAcTypeList.Enabled			= false;
//					this.AcHolderText.Enabled			= false;
//					this.AcNoText.Enabled				= false;
// 管理番号 B24264 To
					// 管理番号 B13878 From
					this.HoldCheck.Enabled			    = false;
					// 管理番号 B13878 To
					this.DtNoteText.Enabled				= false;
					this.RemarksCodeText.Enabled		= false;
					this.RemarksText.Enabled			= false;
// 管理番号K27154 From
					this.DealTypeList.Enabled			= false;
// 管理番号K27154 To
					// 新登録行
					setNewControlCondition(false);
					this.InpPanel.AutoPostBack			= false;

					//締完了で参照の場合は削除可能
					this.DeleteButton.Enabled = false;
					//諸掛閲覧
// 管理番号 B24246 From
//					this.ChargeBrowseButton.Enabled  = isChargePuExists;
					if (paramType == ParamCodeType.VIEW)
					{
						this.ChargeBrowseButton.Enabled = isChargePuExists;
					}
					else
					{
						this.ChargeBrowseButton.Enabled = false;
					}
// 管理番号 B24246 To
// 管理番号 K22217 From
                    this.RouteChangeButton.Visible = false;
// 管理番号 K22217 To
// 管理番号K27057 From
					CustomItemPanel.Enable = false;
// 管理番号K27057 To
					break;
			}

			//ロット詳細
			this.InpLotDtilButton.Visible = this.LotAdminFlg;
// 管理番号 B20713 From
			this.LotDtilLabel.Visible = this.LotAdminFlg;
// 管理番号 B20713 To
			if(!this.LotAdminFlg || !this.InpLotDtilButton.Enabled)
			{
// 管理番号 B22050 From
//				this.InpWhCodeText.NextControlID = this.InpPuQtText.ID;
				this.InpUnitList.NextControlID = this.InpPuPriceText.ID;
// 管理番号 B22050 To
			}

			// 仕入形態区分
			if (returnValue=="PuModeType")
			{
// 管理番号K27058 From
//// 管理番号 B14800 From
////				if (this.PuModeTypeList.SelectedValue=="2")
//				if (this.PuModeTypeList.SelectedValue=="2" || this.PuModeTypeList.SelectedValue == "4")
//// 管理番号 B14800 To
				if (this.puModeType == "2" || this.puModeType == "4")
// 管理番号K27058 To
				{
					this.PoRefText.Text		= string.Empty;
					this.RcptRefText.Text	= string.Empty;
				}
// 管理番号K27058 From
//// 管理番号B26278 From
////				else
//				if (this.PuModeTypeList.SelectedValue != "2")
//// 管理番号B26278 To
				if (this.puModeType != "2")
// 管理番号K27058 To
				{
					this.RefPuText.Text		= string.Empty;
				}
// 管理番号K27058 From
//				this.PoRefText.Enabled		= this.PuModeTypeList.SelectedValue == "1";
//				this.RcptRefText.Enabled	= this.PuModeTypeList.SelectedValue == "1";
//				this.RefPuText.Enabled		= this.PuModeTypeList.SelectedValue == "2";
				this.PoRefText.Enabled		= this.puModeType == "1";
				this.RcptRefText.Enabled	= this.puModeType == "1";
				this.RefPuText.Enabled		= this.puModeType == "2";
// 管理番号K27058 To
			}
			else
			{
// 管理番号K27058 From
//// 管理番号 B14800 From
////				this.PoRefText.Enabled		= this.PoRefText.Enabled	? this.PuModeTypeList.SelectedValue != "2" : false;
////				this.RcptRefText.Enabled	= this.RcptRefText.Enabled	? this.PuModeTypeList.SelectedValue != "2" : false;
////				this.RefPuText.Enabled		= this.RefPuText.Enabled	? this.PuModeTypeList.SelectedValue == "2" : false;
//				this.PoRefText.Enabled		= this.PoRefText.Enabled	? this.PuModeTypeList.SelectedValue != "2" && this.PuModeTypeList.SelectedValue != "4" : false;
//				this.RcptRefText.Enabled	= this.RcptRefText.Enabled	? this.PuModeTypeList.SelectedValue != "2" && this.PuModeTypeList.SelectedValue != "4" : false;
//				this.RefPuText.Enabled		= this.RefPuText.Enabled	? this.PuModeTypeList.SelectedValue == "2" && this.PuModeTypeList.SelectedValue != "4" : false;
//
//// 管理番号 B14800 To
				this.PoRefText.Enabled		= this.PoRefText.Enabled	? this.puModeType != "2" && this.puModeType != "4" : false;
				this.RcptRefText.Enabled	= this.RcptRefText.Enabled	? this.puModeType != "2" && this.puModeType != "4" : false;
				this.RefPuText.Enabled		= this.RefPuText.Enabled	? this.puModeType == "2" && this.puModeType != "4" : false;
// 管理番号K27058 To
			}

			//ヘッダ.納入区分制御
// 管理番号K27058 From
//			if (this.PuModeTypeList.SelectedValue == "4")
			if (this.puModeType == "4")
// 管理番号K27058 To
			{
				this.DeliTypeWRadio.Enabled = false;
				this.DeliTypeDRadio.Enabled = false;
			}
			else
			{
				this.DeliTypeWRadio.Enabled = true;
				this.DeliTypeDRadio.Enabled = true;
			}

			if (paramType != ParamCodeType.VIEW)
			{
				this.WhCodeText.Enabled		  = this.DeliTypeWRadio.Checked;
				this.DeliCustCodeText.Enabled = this.DeliTypeDRadio.Checked;
			}


			//仕入形態区分
			bool enable = (refType==RefCodeType.NONE || refType==RefCodeType.COPY_PU || !rowData.ConsistsData) && paramType!=ParamCodeType.MOD;
			this.PuModeTypeList.Enabled = enable;
			// 管理番号 Bxxxxx From
			//			this.SuplCodeText.Enabled   = enable;
			bool enable2 = (refType == RefCodeType.NONE || refType == RefCodeType.COPY_PU || (rowData.PoNo.Length == 0 && rowData.RefPuNo.Length == 0));
			this.SuplCodeText.Enabled   = enable2;
			// 管理番号 Bxxxxx To
			this.DeptCodeText.Enabled   = enable;
// 管理番号 B24749 From
//			// 管理番号 B13877 From
//			ProjCodeText.Enabled = enable2;
//			// 管理番号 B13877 To
			ProjCodeText.Enabled = enable;
// 管理番号 B24749 To
// 管理番号K27058 From
//			// 管理番号 B13230 From
//// 			this.RemarksLabel.Text		= (PuModeTypeList.SelectedValue == "2") ? "返品理由" : "摘要"; //K24546
//			this.RemarksLabel.Text		= (PuModeTypeList.SelectedValue == "2") ? MultiLanguage.Get("SC_CS001889") : MultiLanguage.Get("SC_CS001539");
//			// 管理番号 B13230 To
			// 返品理由 : 摘要
			this.RemarksLabel.Text		= (puModeType == "2") ? MultiLanguage.Get("SC_CS001889") : MultiLanguage.Get("SC_CS001539");
// 管理番号K27058 To

// 管理番号 B21313 From
// 管理番号B26278 From
//            if ((refType == RefCodeType.PO && PoRefText.Text.Equals(string.Empty)) || (refType == RefCodeType.RCPT && RcptRefText.Text.Equals(string.Empty)))
			if ((refType == RefCodeType.PO && PoRefText.Text.Equals(string.Empty)) || (refType == RefCodeType.RCPT && RcptRefText.Text.Equals(string.Empty)) || (refType == RefCodeType.REF_PU && RefPuText.Text.Equals(string.Empty)))
// 管理番号B26278 To
            {
                keyColumn.RefType = "NONE";
            }
// 管理番号 B21313 To

// 管理番号 K16590 From
			if (paramType != ParamCodeType.VIEW)
			{
				//日付管理区分が「取引日管理基準」の場合のみ入力可
				this.DealDateText.Enabled = (this.DateAdminType == "1");
			}
// 管理番号 K16590 To

			//新規行の表示有無
// 管理番号K27058 From
//			if (this.PuModeTypeList.SelectedValue == "2" && this.RefPuText.Text.Length != 0)
			if (this.puModeType == "2" && this.RefPuText.Text.Length != 0)
// 管理番号K27058 To
			{
				this.InpPanel.Visible = false;
// 管理番号B23625 From
//// 管理番号 B25337 From
//				this.CurCodeList.Enabled = !rowData.ConsistsData;
//// 管理番号 B25337 To
				this.CurCodeList.Enabled = this.MultiCurUseFlg && !rowData.ConsistsData;
// 管理番号B23625 To
			}
			else
			{
				this.InpPanel.Visible = true;
			}
// 管理番号 B20479 From
			if(refType == RefCodeType.RCPT)
			{
				if(rowData.RcptNo.Length == 0 && this.RcptRefText.Text.Trim().Length > 0)
				{
					this.SuplCodeText.Enabled   = false;
					this.DeptCodeText.Enabled   = false;
				}
			}
// 管理番号 B20479 To

			//管理番号 B13502 From
			//発注参照時のみ
			if (refType == RefCodeType.PO)
			{
				this.CurCodeList.Enabled =false;
// 管理番号 B17665 From
//				if(this.ExchangeRezNoText.Text.Length>0)
				if(this.ExchangeRezNoText.Text.Length>0 && rowData.RefPoExchangeType =="1")
// 管理番号 B17665 To
				{
					this.ExchangeTypeList.Enabled =false;
					this.ExchangeRezNoText.Enabled =false;
					this.RateText.Enabled =false;
				}
// 管理番号 B20479 From
				if(rowData.PoNo.Length == 0 && this.PoRefText.Text.Trim().Length > 0 )
				{
					this.SuplCodeText.Enabled   = false;
					this.DeptCodeText.Enabled   = false;
				}
// 管理番号 B20479 To
			}
			//管理番号 B13502 To
//管理番号 B14936 From
			if(this.PoRefText.Text.Length > 0)
			{
				this.ProjCodeText.Enabled = false;
			}
//管理番号 B14936 To

// 管理番号 B24264 From
			if (paramType == ParamCodeType.VIEW)
			{
				if (rowData.TempCodeFlg == "1")
				{
					// 詳細ボタン以外のヘッダ(タブ外)、データグリッドのコントロールを非活性化
					setHeaderControlCondition(false);
// 管理番号 B25365 From
					//仕入番号のコントロールを活性化
					PuNoText.Enabled = true;
// 管理番号 B25365 To
				}
				else
				{
					// ヘッダ(タブ外)、データグリッドのコントロールを非活性化
					base.Mode = Infocom.Allegro.Web.PageMode.Reference;
				}
			}

			SuplNameText.Enabled = false;
			SuplNameText.ReadOnly = false;

			// 雑の場合は詳細ボタンを表示する
			if (rowData.TempCodeFlg == "1")
			{
				SuplDtilButton.Visible = true;
				SuplDtilButton.ClientClickScript = "openSuplWindow";
			}
			else
			{
				SuplDtilButton.Visible = false;
			}

			if (Request.Form["__ReturnValue"] == "openSuplWindow")
			{
				SuplNameText.Text = tempRowData["TEMP_SUPL_SHORT_NAME"].ToString();

				if (SuplCodeText.Enabled)
				{
					OverRideFocus(SuplCodeText.ClientID);
				}
			}
// 管理番号 B24264 To

			setNextControlId();
			setTabCondition();
			keyColumn.ClearErrors();
			rowData.ClearErrors();

// 管理番号 B24264 From
//// 管理番号 B20392 From
//// 管理番号 B21182 From
////			if(AcTable.Visible)
//			if(paramType != ParamCodeType.VIEW && AcTable.Visible)
//// 管理番号 B21182 To
//			{
//				setAcInfoControl();
//			}
//// 管理番号 B20392 To
// 管理番号 B24264 To

			//隠しフィールドへ値の設定
			if (rowCtl!=null)
			{
				if (rowCtl.Inp=="1")
				{
					//新規
					//__LineId
					this.inputRowProdTypeHidden.Value		= rowCtl.ProdType.Text;
					this.inputRowDispTypeHidden.Value		= rowCtl.DispControlType.Text;
					this.inputRowInitPuQtTextHidden.Value	= qtMaxValue.ToString();
					this.inputRowInitPuPriceHidden.Value	= rowCtl.InitPuPriceText.Text;
					this.inputRowStockAdminFlgHidden.Value	= rowCtl.StockAdminFlg.Text;
				}
				else
				{
					this.editRowPuLineIdHidden.Value		= rowCtl.PuLineId;
					//明細
// 管理番号K27058 From
//					if (this.PuModeTypeList.SelectedValue == "2" && this.RefPuText.Text.Length > 0)
					if (this.puModeType == "2" && this.RefPuText.Text.Length > 0)
// 管理番号K27058 To
					{
						this.editRowRcptLineIdHidden.Value	= rowCtl.PuLineId;
					}
					else if (this.RcptRefText.Text.Length > 0)
					{
						this.editRowRcptLineIdHidden.Value  = rowCtl.RcptLineId;
					}
					else if (this.PoRefText.Text.Length > 0)
					{
						this.editRowRcptLineIdHidden.Value  = rowCtl.PoLineId;
					}
					this.editRowProdTypeHidden.Value		= rowCtl.ProdType.Text;
					this.editRowDispTypeHidden.Value		= rowCtl.DispControlType.Text;
					this.editRowInitPuQtHidden.Value		= rowCtl.InitPuQtText.Text;
					this.editRowInitPuPriceHidden.Value		= rowCtl.InitPuPriceText.Text;
					this.editRowStockAdminFlgHidden.Value	= rowCtl.StockAdminFlg.Text;
				}

			}

			ClearControls(rowCtl);
			rowCtl = null;

			ViewState[ViewStateType.KEY_COLUMN]			= keyColumn;
			ViewState[ViewStateType.PARAM_TYPE]			= paramType;
			ViewState[ViewStateType.REF_TYPE]			= refType;
			ViewState[ViewStateType.SLIP_NO]			= slipNo;
			ViewState[ViewStateType.LOCK_PU_NO]			= lockedPuNo;
			ViewState[ViewStateType.CUR_DIGIT]			= curDigit;
			ViewState[ViewStateType.APPROVAL_FLG]		= approvalFlg;
			ViewState[ViewStateType.IS_CHARGE_EXISTS]   = isChargePuExists;
			ViewState["InsertFlg"]						= insertFlg;
// 管理番号 K22270 From
			ViewState["ViewNum"] = viewnum;
// 管理番号 K22270 To
// 管理番号 K25679 From
			ViewState["CorrectAllowFlg"]				= correctAllowFlg;
// 管理番号 K25679 To
// 管理番号 K25667 From
			ViewState["AttachmentCancelFlg"]			= attachmentCancelFlg;
			ViewState["AttachmentRedSlipFlg"]			= attachmentRedSlipFlg;
			ViewState["SlipType"]						= slipType;
// 管理番号 K25667 To
			Session[PageID + "_IF"]		= rowData;
			Session["SC_Input_LotDt"]	= rowData.LotDt;

// 管理番号 B24264 From
			if (!closeFlg)
			{
				if (tempRowData != null)
				{
					Session.Add("SC_MS_02_S20_TempSuplData", tempRowData);
				}
			}
// 管理番号 B24264 To

			ClientScript.RegisterHiddenField(HiddenFieldType.PARAM_TYPE , this.paramType);
			ClientScript.RegisterHiddenField(HiddenFieldType.SLIP_NO	   , this.slipNo);
			ClientScript.RegisterHiddenField(HiddenFieldType.REF_PO_NO  , this.PoRefText.Text);
			ClientScript.RegisterHiddenField(HiddenFieldType.REF_RCPT_NO, this.RcptRefText.Text);
			ClientScript.RegisterHiddenField(HiddenFieldType.REF_PU_NO  , this.RefPuText.Text);
			ClientScript.RegisterHiddenField(HiddenFieldType.LOCK_PU_NO , this.lockedPuNo);
			//返品時の明細行処理変更対応-INSERT-START
			ClientScript.RegisterHiddenField(HiddenFieldType.PU_MODE_TYPE, this.PuModeTypeList.SelectedValue);
			//返品時の明細行処理変更対応-INSERT-END
			ClientScript.RegisterHiddenField(HiddenFieldType.TODAY_DATE , this.todayDate);
			ClientScript.RegisterHiddenField("__RefType"	               , this.refType);
			ClientScript.RegisterHiddenField("__LineId"	               , this.rowData.NewRowLineID.ToString());
			ClientScript.RegisterHiddenField(HiddenFieldType.RETURN_VAL , string.Empty);
			//配下部門
			ClientScript.RegisterHiddenField("__DisclosureUnitType"	, this.DisclosureUnitType);
			ClientScript.RegisterHiddenField("__LoginDeptCode"		, this.UserDeptCode);
// 管理番号 B12929 From
			ClientScript.RegisterHiddenField("_SuplPriceUpdateFlg"		, this.SuplPriceUpdateFlg ? "1" : "0");
// 管理番号 B12929 To
// 管理番号 K22270 From
			ClientScript.RegisterHiddenField("__CurrentPage", CurrentPage);
// 管理番号 K22270 To
// 管理番号 K24284 From
			ClientScript.RegisterHiddenField("__ProjImplementFlg", this.ProjImplementFlg.ToString());
			ClientScript.RegisterHiddenField("__ProjInputScIndisFlg", this.ProjInputScIndisFlg.ToString());
// 管理番号 K24284 To
// 管理番号 B24264 From
			ClientScript.RegisterHiddenField(HiddenFieldType.CUR_CODE, CurCodeList.SelectedValue);
			ClientScript.RegisterHiddenField(HiddenFieldType.TEMP_CODE_FLG, rowData.TempCodeFlg);
// 管理番号 B24264 To
// 管理番号 K25679 From
			ClientScript.RegisterHiddenField("__SlipTypeCode"	, rowData.SuplSlipNo.Length != 0 ? "CG2" : pageCode);
// 管理番号 K25679 To
// 管理番号K27059 From
			ClientScript.RegisterHiddenField("__InitCustSearchWindowUseFlg", this.InitCustSearchWindowUseFlg ? "1" : "0");
			ClientScript.RegisterHiddenField("__PageInitCustSearchWindowUseFlg", this.PageInitCustSearchWindowUseFlg ? "1" : "0");
			ClientScript.RegisterHiddenField("__InitSuplSearchWindowUseFlg", this.InitSuplSearchWindowUseFlg ? "1" : "0");
			ClientScript.RegisterHiddenField("__PageInitSuplSearchWindowUseFlg", this.PageInitSuplSearchWindowUseFlg ? "1" : "0");
			ClientScript.RegisterHiddenField("__InitProdSearchWindowUseFlg", this.InitProdSearchWindowUseFlg ? "1" : "0");
			ClientScript.RegisterHiddenField("__PageInitProdSearchWindowUseFlg", this.PageInitProdSearchWindowUseFlg ? "1" : "0");
// 管理番号K27059 To
// 管理番号K27441 From
			ClientScript.RegisterHiddenField("__PoDeptCode", rowData.PoDeptCode.ToString());
// 管理番号K27441 To

			//在庫管理部門変更対応-INSERT-START
			//変更前の部門コード
			if(!isStockAdminDeptChange)
			{
				OrgDeptCodeHdn.Value = DeptCodeText.Text.Trim();
				OrgDeptNameHdn.Value = DeptNameLabel.Text.Trim();
			}
			//在庫管理部門変更対応-INSERT-END
// 管理番号 B24749 From
			//変更前のプロジェクトコード
			if (!isProjChange)
			{
				OrgProjCodeHdn.Value = ProjCodeText.Text.Trim();
				OrgProjNameHdn.Value = ProjNameLabel.Text.Trim();
			}
// 管理番号 B24749 To
			if (!isClose)
			{
				//ロット明細(セッションへのロット更新はここだけ)
				if(!lotDiff)
				{
					rowData.LotDt = rowData.LotDtBackUp.Copy();
				}
				Session.Add("SC_Input_LotDt", rowData.LotDt);
			}
			else
			{
				Session.Remove("SC_Input_LotDt");
				Session.Remove(PageID + "_IF");
			}

// 管理番号B19534 From
			// 締日に値が入っていない場合は締日<>ボタンを押下不可にする
			if(CutoffDateText.Text == string.Empty)
			{
				CutoffDateBackButton.Enabled = false;
				CutoffDateAdvanceButton.Enabled = false;
			}
// 管理番号B19534 To
// 管理番号 K25679 From
			// 修正許可しない かつ 履歴伝票でない場合
			if(!correctAllowFlg && rowData.OppositePuNo.Length == 0)
			{
				// グループ間取引伝票の場合
				if(rowData.SuplSlipNo.Length != 0)
				{
					// SC_CS006202:グループ間取引伝票, SC_CS003401:更新・削除
					setMessageLabel(HtmlMessage(AllegroMessage.S20016(MultiLanguage.Get("SC_CS006202"), MultiLanguage.Get("SC_CS003401")), MessageLevel.Info));
				}
// 管理番号 K25680 From
				// EDI伝票の場合
				else if(rowData.ImportSlipNo.Length != 0)
				{
					// SC_CS002536:EDI伝票, SC_CS003401:更新・削除
					setMessageLabel(HtmlMessage(AllegroMessage.S20016(MultiLanguage.Get("SC_CS002536"), MultiLanguage.Get("SC_CS003401")), MessageLevel.Info));
				}
// 管理番号 K25680 To
			}
// 管理番号 K25679 To
// 管理番号K26528 From
//// 管理番号 K25667 From
//			// 申請資料が添付されている場合は、設定済ボタンイメージを使用する
//			this.AttachmentFileButton.ImageUrl =
//				this.attachmentFiles == null || this.attachmentFiles.Count == 0
//					? MultiLanguage.Get("SC_IM000185")
//					: MultiLanguage.Get("SC_IM000186")
//					;
//// 管理番号 K25667 To
			// 申請資料が添付されている場合は、設定済ボタンイメージを使用する
			// 添付資料
			this.AttachmentFileButton.Text = MultiLanguage.Get("ZZ_BN000008");
			this.AttachmentFileButton.CssClass =
				this.attachmentFiles == null || this.attachmentFiles.Count == 0
					? "normal"
					: "normal_changed"
					;
// 管理番号K26528 To

			FocusControl(this.PoRefText.Enabled ? this.PoRefText.ID : this.PuDateText.ID);
// 管理番号K26508 From
			// 参照権限時のコントロール制御
			viewAuthorityControls();
// 管理番号K26508 To
		}

		private void setDefaultData()
		{
			this.PuNoText.Enabled           = true;
			this.PoRefText.Enabled          = true;
			this.RcptRefText.Enabled        = true;
			this.PuDateText.Enabled         = true;
// 管理番号 K16590 From
			this.DealDateText.Enabled       = true;
// 管理番号 K16590 To
// 管理番号 K25679 From
			this.PoAdminNoText.Enabled      = true;
// 管理番号 K25679 To
			this.SuplCodeText.Enabled       = true;
			this.SuplNameText.Enabled       = false;
			this.RefPuText.Enabled          = true;
			this.SuplBillSlipNoText.Enabled = true;
			this.EmpCodeText.Enabled        = true;
			this.DeptCodeText.Enabled       = true;
			this.ProjCodeText.Enabled       = true;
			this.WhCodeText.Enabled         = true;
			this.DeliCustCodeText.Enabled   = true;
			this.PuModeTypeList.Enabled     = true;

			
// 管理番号 B20853 From
			//ワークフロー設定
//			setApproval(Request.QueryString["DeptCode"] !=null ? Request.QueryString["DeptCode"] : this.UserDeptCode);
// 管理番号 B20853 From

			this.PuNoText.Text					= string.Empty;
			this.ModeLabel.Text					= string.Empty;
			this.PoRefText.Text					= string.Empty;
			this.RcptRefText.Text				= string.Empty;
			this.PuDateText.Text				= DateTime.Today.ToString("yyyy/MM/dd");
// 管理番号 K16590 From
			this.DealDateText.Text				= DateTime.Today.ToString("yyyy/MM/dd");
// 管理番号 K16590 To
// 管理番号 K25679 From
			this.PoAdminNoText.Text				= string.Empty;
// 管理番号 K25679 To
			this.SuplCodeText.Text				= string.Empty;
			this.SuplNameText.Text				= string.Empty;
			this.RefPuText.Text					= string.Empty;
			this.SuplBillSlipNoText.Text		= string.Empty;
			//管理番号 B13502 From
			//			this.CurCodeLabel.Text				= this.KeyCurrencyCode;
			CurCodeList.SelectedValue			= this.KeyCurrencyCode;
			//管理番号 B13502 To
			this.EmpCodeText.Text				= this.UserCode;
			this.EmpNameLabel.Text				= this.UserName;
			this.DeptCodeText.Text				= this.UserDeptCode;
			this.DeptNameLabel.Text				= this.UserDeptName;
// 			this.ProjTitleLabel.Text            = this.ProjImplementFlg ? "プロジェクト" : string.Empty; //K24546
			this.ProjTitleLabel.Text            = this.ProjImplementFlg ? MultiLanguage.Get("SC_CS000232") : string.Empty;
// 管理番号 K24284 From
			ProjCodeText.IsRequiredField		= this.ProjInputScIndisFlg;
// 管理番号 K24284 To
			this.ProjCodeText.Text				= string.Empty;
			this.ProjNameLabel.Text				= string.Empty;
			this.ProjCodeText.Visible			= this.ProjImplementFlg;
			this.ProjNameLabel.Visible			= this.ProjImplementFlg;

			//優先倉庫
			this.DeliTypeWRadio.Checked			= true;
			this.DeliTypeDRadio.Checked			= false;
			setPriorityWh(this.DeptCodeText.Text.Trim());
			this.DeliCustCodeText.Text			= string.Empty;
			this.DeliCustNameLabel.Text			= string.Empty;

			//基本タブ
			this.SoNoLabel.Text					= string.Empty;
			this.SoDateLabel.Text				= string.Empty;
			this.CustNameLabel.Text				= string.Empty;
			this.PuNameText.Text				= string.Empty;

// 管理番号 B14982 From
			// レート
			this.RateLabel.Text					= string.Empty;
			this.RateText.Text					= string.Empty;
// 管理番号 B14982　To
			//管理番号 B13502 From

// 管理番号 B24264 From
			tempRowData = new Hashtable();
// 管理番号 B24264 To

			//Enabled設定
			if(this.CurCodeList.SelectedValue == this.KeyCurrencyCode)
			{
				this.ExchangeTypeList.Enabled =false;
				this.ExchangeRezNoText.Enabled =false;
				this.RateText.Enabled =false;
			}
			else
			{
				this.ExchangeTypeList.Enabled =true;
				this.ExchangeRezNoText.Enabled =false;
				this.RateText.Enabled =true;
			}

			this.ExchangeTypeList.SelectedValue		= "0";	//ブランク
			this.ExchangeRezNoText.Enabled =false;
			this.ExchangeRezNoText.Text				= string.Empty;
			//			this.RateText.Text						= "1";
			//管理番号 B13502 To


			//仕入形態
// 管理番号K27058 From
//			this.PuModeTypeList.Items.Clear();
//			this.puModeTypeListItemsAdd(this.ModeTypeUsuallyUseType   , this.ModeTypeUsuallyWord, "1");
//			this.puModeTypeListItemsAdd(this.ModeTypeReturnUseType    , this.ModeTypeReturnWord , "2");
//			this.puModeTypeListItemsAdd(this.ModeTypeCommissionUseType, this.ModeTypeCommissionWord, "4");
			MultipurposeType.GetModeTypeListDataSource(CommonData, PuModeTypeList,
				this.ModeTypeUsuallyUseType, this.ModeTypeReturnUseType, false, this.ModeTypeCommissionUseType, false, false);
			PuModeTypeList.SelectedIndex = 0;
// 管理番号K27058 To
			if (refType == RefCodeType.REF_PU)
			{
// 管理番号K27058 From
//				this.PuModeTypeList.SelectedValue = "2";
				// rowDataが存在しない場合を考慮し固定値で値をセット
				if (rowData == null)
				{
					// 仕入参照（返品）時、新規入力された仕入形態区分明細コードがリセットされるため、引き継いだ値を再セットする
					this.PuModeTypeList.SelectedValue = "2" + puModeTypeDtilCodeHidden;
				}
				else
				{
					this.PuModeTypeList.SelectedValue = rowData.PuModeType + rowData.PuModeTypeDtilCode;
				}
// 管理番号K27058 To
			}

			//受渡場所
// 管理番号K27062 From
//			this.DeliPlaceCodeList.Items.Clear();
//			this.DeliPlaceCodeList.Enabled		= DeliTypeDRadio.Checked;
//
//			this.DeliPlaceNameText.Text			= string.Empty;
			this.DeliPlaceCodeText.Text			= string.Empty;
			this.DeliPlaceCodeText.Enabled		= false;
			this.DeliPlaceNameText.Text			= string.Empty;
			this.DeliPlaceNameText.Enabled		= DeliTypeDRadio.Checked;
// 管理番号K27062 To
			this.ZipText.Text					= string.Empty;
			this.StateText.Text					= string.Empty;
			this.CityText.Text					= string.Empty;
			this.Address1Text.Text				= string.Empty;
			this.Address2Text.Text				= string.Empty;
			this.PhoneText.Text					= string.Empty;
			this.FaxText.Text					= string.Empty;
			this.DeliUserNameText.Text			= string.Empty;

			setWhPlace(this.WhCodeText.Text);

			//支払条件
			setDefaultListItem();
			this.DtTypeList.SelectedIndex			= 0;
			this.Dt1SttlMthdCodeList.SelectedIndex	= 0;
			this.Dt1BasisAmtText.Text				= string.Empty;
			this.Dt2RatioText.Text					= string.Empty;
			this.Dt2SttlMthdCodeList.SelectedIndex	= 0;
			this.Dt3SttlMthdCodeList.SelectedIndex	= 0;
			this.DtSightText.Text					= string.Empty;
			this.CutoffDateText.Text				= string.Empty;
			this.PymtPlanDateText.Text				= string.Empty;
			setDtControlCondition(this.DtTypeList.SelectedValue == "E");

// 管理番号 B24264 From
//			this.SuplFormalNameText.Text			= string.Empty;
//			this.SuplUserNameText.Text				= string.Empty;
//			this.SuplDeptName1Text.Text				= string.Empty;
//			this.SuplDeptName2Text.Text				= string.Empty;
//			this.AcTypeList.SelectedIndex			= 0;
//			this.BankCodeText.Text					= string.Empty;
//			this.BankNameLabel.Text					= string.Empty;
//			this.BankBranchCodeText.Text			= string.Empty;
//			this.BankBranchNameLabel.Text			= string.Empty;
//			this.BankAcTypeList.SelectedIndex		= 0;
//			this.AcHolderText.Text					= string.Empty;
//			this.AcNoText.Text						= string.Empty;
//			this.SuplFormalNameText.Enabled			= true;
//			this.SuplUserNameText.Enabled			= true;
//			this.SuplDeptName1Text.Enabled			= true;
//			this.SuplDeptName2Text.Enabled			= true;
//			this.AcTypeList.Enabled					= true;
//			this.BankCodeText.Enabled				= true;
//			this.BankBranchCodeText.Enabled			= true;
//			this.BankAcTypeList.Enabled				= true;
//			this.AcHolderText.Enabled				= true;
//			this.AcNoText.Enabled					= true;
//			this.AcTable.Visible					= false;
// 管理番号 B24264 To

			this.DtNoteText.Text					= string.Empty;
			this.CutOffDateConditionNote.Text		= string.Empty;
			this.PaymentDateLabel.Text				= string.Empty;
			// 管理番号 B13878 From
			this.HoldCheck.Checked					= false;
			this.HoldCheck.Enabled					= true;
			// 管理番号 B13878 To

			this.RemarksCodeText.Enabled            = true;
			this.RemarksText.Enabled 			    = true;
			this.RemarksCodeText.Text				= string.Empty;
			this.RemarksText.Text					= string.Empty;

// 管理番号K27058 From
//// 管理番号 K20687 From
//			this.BookBasisTypeRadio.Enabled			= true;
//			this.BookBasisTypeRadio.SelectedValue	= this.PUBookBasisType;//アプリケーション変数
//// 管理番号 K20687 To
			this.BookBasisTypeList.Enabled			= true;
			MultipurposeType.GetBookBasisTypeListDataSource(CommonData, BookBasisTypeList, "5", true, true, false);
			this.BookBasisTypeList.SelectedValue	= PUBookBasisType == "A" ? "AZZ" : "SZZ"; //アプリケーション変数PUBookBasisType
// 管理番号K27058 To
// 管理番号K27154 From
			this.DealTypeList.SelectedIndex			= 0;
// 管理番号K27154 To
// 管理番号 K25679 From
			// 「CMGR：グループ連携」モジュールが有効な場合、仕入先伝票番号を表示
			if (CM.MS.Module.CheckModule(this.CommonData, "CMGR"))
			{
				this.SuplSlipNoTitleLabel.Visible	= true;
				this.SuplSlipNoLabel.Visible		= true;
			}
// 管理番号 K25679 To

			//詳細タブ
			setDataGridProperty(new IF_SC_MM_05_S02_RowData().Dt);

			clearNewControlValue();
			setAmtTtl(false);

			// 今後パターンが増えるようなのでswitchにしました。
			switch (this.SOTabDefaultType)
			{
				case "0":
				default:
					this.TabSelector1.SelectedIndex = 0;
					break;
				case "1":
					this.TabSelector1.SelectedIndex = 1;
					break;
			}
// 管理番号 K25647 From
//			this.InpPuQtText.AllowDecimal			= this.QtDecimalUseFlg;
//			this.InpPuQtText.MaxLength				= this.QtDecimalUseFlg ? 13 : 9;
//			this.InpPuQtText.Precision				= this.QtDecimalUseFlg ? (byte)12 : (byte)9;
//			this.InpPuQtText.Scale					= this.QtDecimalUseFlg ? (byte)3 : (byte)0;
			NumberBoxPreset.SetSlipQuantityMode(this.InpPuQtText, NumberBoxPreset.SlipQuantity.SCMM, this.InpPuQtText.AllowNegative, this.QtDecimalDigit);
// 管理番号 K25647 To

			//管理番号 B13502 From
			//			this.InpPuPriceText.AllowDecimal		= this.PriceDecimalUseFlg;
			//			this.InpPuPriceText.MaxLength			= this.PriceDecimalUseFlg ? 14 : 11;
			//			this.InpPuPriceText.Precision			= this.PriceDecimalUseFlg ? (byte)13 : (byte)11;
			//			this.InpPuPriceText.Scale				= this.PriceDecimalUseFlg ? (byte)2 : (byte)0;
// 管理番号 B18736 From
//			this.InpPuPriceText.AllowDecimal		= true;
//			this.InpPuPriceText.MaxLength			= 14;
//			this.InpPuPriceText.Precision			= 13;
//			this.InpPuPriceText.Scale				= 2;
			curDigit = Cur.GetDecimalDigit(this.CommonData, this.CurCodeList.SelectedValue);
			setCurDigit();
// 管理番号 B18736 To
			//管理番号 B13502 To

			switch (this.PUTabDefaultType)
			{
				case "0":
				default:
					this.TabSelector1.SelectedIndex = 0;
					break;
				case "1":
					this.TabSelector1.SelectedIndex = 1;
					break;
			}

			//管理番号 B13502 From
			this.ConvertDtilAmtTtlLabel.Text		= string.Empty;
			this.ConvertEtaxDtilAmtTtlLabel.Text	= string.Empty;
			this.ConvertEtaxAmtTtlLabel.Text		= string.Empty;
			this.ConvertGrandTtlLabel.Text			= string.Empty;
			//管理番号 B13502 To
			// 管理番号 B13798 From
			this.AdminItem1Hidden.Value				= string.Empty;
			this.AdminItem2Hidden.Value				= string.Empty;
			this.AdminItem3Hidden.Value				= string.Empty;
			// 管理番号 B13798 To

			
		}

		private void setTabCondition()
		{
			string condition = TabSelector1.SelectedIndex == 0 ? "BasicTab" : "DetailTab";
			switch(condition)
			{
				case "BasicTab":
					DetailTab.Style.Add("display", "none");
// 管理番号K26528 From
//					BasicTab.Style.Add("display", "inline");
					BasicTab.Style.Remove("display");
// 管理番号K26528 To
					break;
				case "DetailTab":
// 管理番号K26528 From
//					DetailTab.Style.Add("display", "inline");
					DetailTab.Style.Remove("display");
// 管理番号K26528 To
					BasicTab.Style.Add("display", "none");
					break;
			}
		}

		private void setNextControlId()
		{
			this.PuDateText.NextControlID		= this.StatusDropdownlist.Visible ? this.StatusDropdownlist.ID : this.SuplCodeText.ID;
// 管理番号 B24918 From
//			this.DeptCodeText.NextControlID		= this.ProjImplementFlg ? this.ProjCodeText.ID : this.ProjCodeText.NextControlID;
			// プロジェクトを使用する場合で活性時はプロジェクトコード
			// そうでない場合、倉庫コードor納入先コード
			this.DeptCodeText.NextControlID =
				(this.ProjImplementFlg && this.ProjCodeText.Enabled)
					? this.ProjCodeText.ID
					: this.WhCodeText.Enabled
						? this.WhCodeText.ID
						: this.DeliCustCodeText.ID;
// 管理番号 B24918 To
			this.InpPuQtText.NextControlID		= this.InpUnitList.Enabled ? this.InpUnitList.ID : this.RegistButton.Enabled ? this.RegistButton.ID : this.UpdateButton.Enabled ? this.UpdateButton.ID : this.CloseButton.ID;
// 管理番号K27057 From
//			this.InpRemarksText.NextControlID	= this.RegistButton.Enabled ? this.RegistButton.ID : this.UpdateButton.Enabled ? this.UpdateButton.ID : this.CloseButton.ID;
			this.InpCustomItemPanel.SetNextElement(this.RegistButton.Enabled ? this.RegistButton.ID : this.UpdateButton.Enabled ? this.UpdateButton.ID : this.CloseButton.ID);
// 管理番号K27057 To
		}


		//在庫管理部門変更対応-INSERT-START
		//画面遷移(在庫管理部門変更)
		private void callResponseRedirect(string deptCode)
		{
// 管理番号 K25667 From
			if (deptCode == OrgDeptCodeHdn.Value)
			{
				// ポストバック前後で部門の変更がない場合、以降の処理を行わない
				return;
			}
// 管理番号 K25667 To

//管理番号 B21550 From
//			if(!Dept.IsStockAdminDeptCodeEqual(this.CommonData, deptCode, OrgDeptCodeHdn.Value))
			if(!Dept.IsStockAdminDeptCodeEqual(this.CommonData, deptCode, OrgDeptCodeHdn.Value, PuDateText.Text))
//管理番号 B21550 To
			{
				//部門に変更があった場合読み直すか確認のダイアログを表示
// 管理番号K26528 From
//				if (!ClientScript.IsStartupScriptRegistered("reloadCheck"))
				if (!PageStartupScript.IsScriptRegistered("reloadCheck"))
// 管理番号K26528 To
				{
					//（Scriptで警告メッセージを表示します）
					StringBuilder script = new StringBuilder();
					//警告ダイアログを表示する。
// 管理番号K26528 From
//					script.Append("<script type=\"text/javascript\">\n");
//					script.Append("<!--\n");
// 管理番号K26528 To
					script.Append("	if (confirm(\"");
// 					script.Append(AllegroMessage.S00011("部門")); //K24546
					script.Append(AllegroMessage.S00011(MultiLanguage.Get("SC_CS001858")));
					script.Append("\"))\n");
					script.Append("	{\n");
					//確認ダイアログで、「はい」が押された場合はリロード(キャンセル扱い)
					script.Append("		document.getElementById(\"__isDirty\").value = \"false\" ;\n");
// 管理番号K26528 From
					// スクリプトによるキャンセルボタン押下であることを明示する
					script.AppendLine("     document.getElementById('cancelByScriptHidden').value = '1';");
// 管理番号K26528 To
					script.Append("		document.getElementById(\"CancelButton\").click();\n");
					script.Append("	}\n	else\n	{\n");
					//確認ダイアログで、「キャンセル」が押された場合は部門を変更前の状態に戻す
					script.Append("		document.getElementById(\"DeptCodeText\").value = document.getElementById(\"OrgDeptCodeHdn\").value ;\n");
// 管理番号K26528 From
//					script.Append("		document.all[\"DeptNameLabel\"].innerText = document.all[\"OrgDeptNameHdn\"].value ;\n");
					script.Append("		CM_setTextValue(document.getElementById(\"DeptNameLabel\"), document.getElementById(\"OrgDeptNameHdn\").value);\n");
// 管理番号K26528 To
					script.Append("}\n");
// 管理番号K26528 From
//					script.Append("-->\n");
//					script.Append("</script>");
//					Page.ClientScript.RegisterStartupScript(this.GetType(), "reloadCheck", script.ToString());
					PageStartupScript.RegisterScript(this.GetType(), "reloadCheck", script.ToString());
// 管理番号K26528 To
					isStockAdminDeptChange = true;
				}
			}
// 管理番号 B26242 From
			else
			{
				// 在庫管理部門が同じ場合はリロードされないため、承認対象伝票かどうかチェックする
				setApproval(deptCode);
// 管理番号B26565 From
//// 管理番号 K25667 From
//				// セッションをクリアする（空のインスタンスで初期化する）
//				this.attachmentFiles = new CM.WF.IF_CM_WF_AttachmentFiles();
//// 管理番号 K25667 To
// 管理番号B26565 To
			}
// 管理番号 B26242 To
		}
		//在庫管理部門変更対応-INSERT-END

// 管理番号 B24749 From
		private void callProjResponseRedirect(object sender, string newProjCode)
		{
			//プロジェクト別在庫管理を行わない場合は、確認ダイアログを表示しない
			if (!this.ProjectStockAdminUseFlg)
			{
				return;
			}
			//明細行がない場合は、確認ダイアログを表示しない
			//ただし新規行が編集中の場合は、確認ダイアログを表示する
			if (rowData.Dt.Rows.Count == 0 && this.InpProdCodeText.Text.Length == 0)
			{
				return;
			}
			//親番と枝番間のハイフンの有無を同値とみなすため、置換を実施
			string projCode = newProjCode.Replace("-","");
			string projCodeHdn = this.OrgProjCodeHdn.Value.Replace("-","");

			if (!(projCode.Equals(projCodeHdn)))
			{
				//プロジェクトに変更があった場合読み直すか確認のダイアログを表示
// 管理番号K26528 From
//				if (!ClientScript.IsStartupScriptRegistered("reloadProjCheck"))
				if (!PageStartupScript.IsScriptRegistered("reloadProjCheck"))
// 管理番号K26528 To
				{
					//（Scriptで警告メッセージを表示します）
					StringBuilder script = new StringBuilder();
					//警告ダイアログを表示する。
// 管理番号K26528 From
//					script.Append("<script type=\"text/javascript\">\n");
//					script.Append("<!--\n");
// 管理番号K26528 To
					script.Append("	if (confirm(\"");
//					script.Append(AllegroMessage.S00011("プロジェクト"));
					script.Append(AllegroMessage.S00011(MultiLanguage.Get("SC_CS000232")));
					script.Append("\"))\n");
					script.Append("	{\n");
					//確認ダイアログで、「はい」が押された場合はリロード(キャンセル扱い)
					script.Append("		document.getElementById(\"__isDirty\").value = \"false\" ;\n");
// 管理番号K26528 From
					// スクリプトによるキャンセルボタン押下であることを明示する
					script.AppendLine("     document.getElementById('cancelByScriptHidden').value = '1';");
// 管理番号K26528 To
					script.Append("		document.getElementById(\"CancelButton\").click();\n");
					script.Append("	}\n	else\n	{\n");
					//確認ダイアログで、「キャンセル」が押された場合はプロジェクトを変更前の状態に戻す
					script.Append("		document.getElementById(\"ProjCodeText\").value = document.getElementById(\"OrgProjCodeHdn\").value ;\n");
// 管理番号K26528 From
//					script.Append("		document.all[\"ProjNameLabel\"].innerText = document.all[\"OrgProjNameHdn\"].value ;\n");
					script.Append("		CM_setTextValue(document.getElementById(\"ProjNameLabel\"), document.getElementById(\"OrgProjNameHdn\").value);\n");
// 管理番号K26528 To
					script.Append("}\n");
// 管理番号K26528 From
//					script.Append("-->\n");
//					script.Append("</script>");
//					Page.ClientScript.RegisterStartupScript(this.GetType(), "reloadProjCheck", script.ToString());
					PageStartupScript.RegisterScript(this.GetType(), "reloadProjCheck", script.ToString());
// 管理番号K26528 To
					isProjChange = true;
				}
			}
		}
// 管理番号 B24749 To

// 管理番号K27058 From
//		private void puModeTypeListItemsAdd(bool useFlg, string text, string value)
//		{
//			if (useFlg)
//			{
//				this.PuModeTypeList.Items.Add(new ListItem(text, value));
//			}
//		}
// 管理番号K27058 To
// 管理番号K27057 From
		protected int GetCustomControlCount()
		{
			return InpCustomItemPanel.GetList().Count;
		}

// 管理番号K27525 From
//		protected string ConcatenateTag(string remark, string customItem)
//		{
//			if (remark.Length > 0)
//			{
//				// 【摘要】
//				remark = MultiLanguage.Get("SC_CS002366") + remark;
//			}
//			return remark + (remark.Length > 0 ? customItem.Length > 0 ? "\n" : "" : "") + customItem.Trim();
//		}
// 管理番号K27525 To
// 管理番号K27057 To
// 管理番号K27525 From
		protected string ConcatenateTag(string remark, string bookDeductionReason, string customItem)
		{
			string tag	= string.Empty;
			if (remark.Length > 0)
			{
				// 【摘要】
				remark = MultiLanguage.Get("SC_CS002366") + remark;
			}
			if (bookDeductionReason.Length > 0)
			{
				// 【帳簿控除理由】
				bookDeductionReason = MultiLanguage.Get("SC_CS006649") + bookDeductionReason;
			}
			tag = remark + (remark.Length > 0 ? bookDeductionReason.Length > 0 ? "\n" : "" : "") + bookDeductionReason;
			return tag + (tag.Length > 0 ? customItem.Length > 0 ? "\n" : "" : "") + customItem.Trim();
		}
// 管理番号K27525 To

		#endregion

		#region 画面とIFのI/F
		private void setDispData()
		{
			string empShortName		= string.Empty;
			string projCode			= string.Empty;
			string projShortName	= string.Empty;
			string WhName			= string.Empty;
			string deliCustCode		= string.Empty;
			string deliCustName		= string.Empty;
			string deptShortName	= string.Empty;
			string compareDate      = string.Empty;
			string bankName			= string.Empty;
			string bankBranchName   = string.Empty;
// 管理番号 K22205 From
            if (paramType == ParamCodeType.MOD || paramType == ParamCodeType.VIEW)
            {
                string inputEmpShortName = string.Empty;
                Emp.IsExists(this.CommonData, rowData.InputEmpCode, out inputEmpShortName, true);
//                 this.LastSlipNoLabel.Text = "入力者 " + inputEmpShortName; //K24546
                this.LastSlipNoLabel.Text = MultiLanguage.Get("SC_CS005074") + inputEmpShortName;
                this.LastSlipNoLabel.Style.Add("text-decoration", "underline");
            }
            else
            {
                this.LastSlipNoLabel.Text = string.Empty;
            }
// 管理番号 K22205 To

			// ヘッダ ///////////////////////////////////////////////////////////////////////////////////////////////////
			this.PuDateText.Text	= rowData.PuDate;
			// 管理番号 B12891 From
			OriginPuDate.Text = rowData.PuDate;
			// 管理番号 B12891 To
// 管理番号 K16590 From
			this.DealDateText.Text	= rowData.DealDate;
// 管理番号 K16590 To

			//管理番号 B13502 From
			//			this.CurCodeLabel.Text	= rowData.CurCode.Length > 0 ? rowData.CurCode : this.KeyCurrencyCode;
			this.CurCodeList.SelectedValue  	= rowData.CurCode.Length > 0 ? rowData.CurCode : this.KeyCurrencyCode;
			//管理番号 B13502 To
// 管理番号 B14549 From
			curDigit = Cur.GetDecimalDigit(this.CommonData, this.CurCodeList.SelectedValue);
// 管理番号 B14549 To
// 管理番号 B18736 From
			setCurDigit();
// 管理番号 B18736 To

			// 仕入先
			if (rowData.SuplCode.Length > 0 && rowData.SuplSbno.Length > 0)
			{
				this.SuplCodeText.Text = rowData.SuplCode+ "-" + rowData.SuplSbno;
// 管理番号 K24789 From
//				//消費税情報取得
//				string ctaxRoundType = string.Empty;
//				string ctaxBuildupType = string.Empty;
//				string ctaxPuTypeCode = string.Empty;
//				string ctaxPuReturnTypeCode = string.Empty;
//
//// 管理番号 B15855 From
////// 管理番号 B15586 From
////				setDtData(true);
////// 管理番号 B15586 To
//// 管理番号 B15855 To
//
//				if(!Supl.GetCtaxInfo(this.CommonData, rowData.SuplCode+"-"+rowData.SuplSbno, this.CompanyCodeLength, out ctaxBuildupType, out ctaxRoundType, out ctaxPuTypeCode, out ctaxPuReturnTypeCode))
//				{
//					setMessageLabel(HtmlMessage(AllegroMessage.S20024("仕入先", "消費税率"), MessageLevel.Warning));
//				}
//				rowData.CtaxRoundType				= ctaxRoundType;
//				rowData.CtaxBuildupType				= ctaxBuildupType;
//				rowData.PuCtaxTypeCode			= ctaxPuTypeCode;
//				rowData.PuReturnCtaxTypeCode	= ctaxPuReturnTypeCode;
// 管理番号 K24789 To
			}
			this.SuplNameText.Text		  = rowData.SuplShortName;
			this.SuplNameText.Enabled	  = rowData.TempCodeFlg == "1";

			//仕入形態区分
// 管理番号K27058 From
//			if (refType == RefCodeType.REF_PU)
//			{
//				this.PuModeTypeList.SelectedValue = "2";
//			}
//			else
//			{
//				this.PuModeTypeList.SelectedValue = rowData.PuModeType;
//			}
			// rowDataが存在しない場合を考慮し固定値で値をセット
			if (rowData == null)
			{
				this.PuModeTypeList.SelectedValue = "2ZZ";
			}
			else
			{
				this.PuModeTypeList.SelectedValue = rowData.PuModeType + rowData.PuModeTypeDtilCode;
			}
// 管理番号K27058 To

			this.SuplBillSlipNoText.Text	  = rowData.SuplBillSlipNo;

			//担当者
			if (rowData.EmpCode.Length > 0)
			{
				Emp.IsExists(this.CommonData, rowData.EmpCode, out empShortName, false);
				this.EmpCodeText.Text  = rowData.EmpCode;
				this.EmpNameLabel.Text = empShortName;
			}

			//部門
			compareDate = DateValidator.IsDate(PuDateText.Text) ? PuDateText.Text : todayDate;
// 管理番号 B15061 From
			string date =  Convert.ToDateTime(compareDate) > System.DateTime.Today ? compareDate : todayDate;
// 管理番号 B15061 To
			if (rowData.DeptCode.Length > 0)
			{
				// 自部門権限時参照部門設定
				string lowerDept = this.DisclosureUnitType == "D" ? this.UserDeptCode : string.Empty;

// 管理番号 B21841 From
//// 管理番号 B15061 From
////				Dept.IsExists(this.CommonData, rowData.DeptCode, out deptShortName, compareDate, false, true, false, lowerDept, false, false);
//				Dept.IsExists(this.CommonData, rowData.DeptCode, out deptShortName, date, false, true, false, lowerDept, false, false);
//// 管理番号 B15061 To
				// 修正・参照モード時は有効フラグを考慮せずに部門名称を取得する
				bool allDept = (paramType == ParamCodeType.MOD || paramType == ParamCodeType.VIEW) ? true : false;
				Dept.IsExists(this.CommonData, rowData.DeptCode, out deptShortName, date, allDept, true, false, lowerDept, false, false);
// 管理番号 B21841 To
				//Dept.IsExists(this.CommonData, rowData.DeptCode, out deptShortName, compareDate, false, true, false);
				this.DeptCodeText.Text  = rowData.DeptCode;
				this.DeptNameLabel.Text = deptShortName;
			}

			//プロジェクト
			if (rowData.ProjCode.Length > 0 && rowData.ProjSbno.Length > 0)
			{
				projCode = rowData.ProjCode + "-" + rowData.ProjSbno;

				this.ProjCodeText.Text = projCode;
// 管理番号 B15061 From
//				if (Proj.IsExists(this.CommonData, projCode, this.ProjectCodeLength, out projShortName, compareDate, this.DeptCodeText.Text))
//				{
//					this.ProjNameLabel.Text = projShortName;
//				}
// 管理番号 B22971 From
//				Proj.IsExists(this.CommonData, projCode, this.ProjectCodeLength, out projShortName, date, this.DeptCodeText.Text);
				// 修正・参照モード時は有効フラグを考慮せずにプロジェクト名称を取得する
				bool allProj = (paramType == ParamCodeType.MOD || paramType == ParamCodeType.VIEW) ? true : false;
// 管理番号 B25542 From
				if(allProj)
				{
					Proj.GetShortName(this.CommonData, projCode, this.ProjectCodeLength, out projShortName);
				}
				else
				{
// 管理番号 B25542 To
					Proj.IsExists(this.CommonData, projCode, this.ProjectCodeLength, out projShortName, compareDate, allProj, this.DeptCodeText.Text);
// 管理番号 B25542 From
				}
// 管理番号 B25542 To
// 管理番号 B22971 To
				this.ProjNameLabel.Text = projShortName;
// 管理番号 B15061 To
			}
// 管理番号 B24188 From
			else
			{
				this.ProjCodeText.Text = string.Empty;
				this.ProjNameLabel.Text = string.Empty;
			}
// 管理番号 B24188 To
			//納入区分
			if (rowData.DeliType.Length > 0)
			{
				this.DeliTypeWRadio.Checked = rowData.DeliType == "W";
				this.DeliTypeDRadio.Checked = rowData.DeliType == "D";
			}
			else
			{
				this.DeliTypeWRadio.Checked = true;
				this.DeliTypeDRadio.Checked = false;
			}
			// 納入先＆受渡場所
			if (this.DeliTypeWRadio.Checked)
			{
				if (rowData.WhCode.Length > 0)
				{
					this.WhCodeText.Text = rowData.WhCode;
					Wh.IsExists(this.CommonData, rowData.WhCode, false, false, true, true, true, out WhName);
					this.WhShortNameLabel.Text	= WhName;
				}
				else if (paramType == ParamCodeType.MOD || paramType == ParamCodeType.VIEW)
				{
					this.WhCodeText.Text		= rowData.WhCode;
					this.WhShortNameLabel.Text	= string.Empty;
				}
				this.DeliCustCodeText.Text  = string.Empty;
				this.DeliCustNameLabel.Text = string.Empty;
			}
			else
			{
				if (rowData.DeliCustCode.Length > 0 && rowData.DeliCustSbno.Length > 0)
				{
					deliCustCode = rowData.DeliCustCode + "-" + rowData.DeliCustSbno;
// 管理番号 B23974 From
//					Cust.IsExists(this.CommonData, deliCustCode, this.CompanyCodeLength, out deliCustName);
					Cust.IsExists(this.CommonData, deliCustCode, this.CompanyCodeLength, out deliCustName, compareDate);
// 管理番号 B23974 To
					this.DeliCustCodeText.Text	= deliCustCode;
					this.DeliCustNameLabel.Text	= deliCustName;
// 管理番号K27062 From
//					this.setDeliPlaceDropDown(deliCustCode);
					this.setDeliPlaceTextBox(deliCustCode);
// 管理番号K27062 To
				}
				this.WhCodeText.Text		= string.Empty;
				this.WhShortNameLabel.Text	= string.Empty;
			}
			//　承認状態
			setApproval(rowData.DeptCode);
// 管理番号 K25679 From
			this.PoAdminNoText.Text			= rowData.PoAdminNo;
			this.SuplSlipNoLabel.Text		= rowData.SuplSlipNo;
// 管理番号 K25679 To
// 管理番号 K20685 From 
//			if(approvalFlg)	{ this.StatusDropdownlist.SelectedValue = rowData.ApprovalStatusType; }
// 管理番号 K20685 To
			// 基本タブ ///////////////////////////////////////////////////////////////////////////////////////////////////
			this.SoNoLabel.Text     = rowData.SoNo;
			this.SoDateLabel.Text   = rowData.SoDate;
			this.CustNameLabel.Text = rowData.CustName;
			this.PuNameText.Text	= rowData.PuName;

			//管理番号 B13502 From
			this.ExchangeTypeList.SelectedValue = rowData.ExchangeType;
			this.ExchangeRezNoText.IsRequiredField = this.ExchangeTypeList.SelectedValue=="1";
			this.ExchangeRezNoText.Text			= rowData.ExchangeRezNo;

// 管理番号 B14641 From
			//string rate = rowData.Rate;
			string rate = string.Empty;

// 管理番号 B15445 From
//			if (paramType == ParamCodeType.MOD)
			if (paramType == ParamCodeType.MOD || paramType == ParamCodeType.VIEW)
// 管理番号 B15445 To
			{
				rate = rowData.Rate;
			}
			else
			{
				if (ExchangeTypeList.SelectedValue == "1")
				{
// 管理番号B26678 From
//					string code = string.Empty;
//					string sbNo = string.Empty;
//// 管理番号 B23717 From
//					bool checkExchangeRez = false;
//// 管理番号 B23717 To
//
//					//為替予約ありのときは予約番号でレートを抽出
//					if(ProjCodeText.Text.Length > 0)
//					{
//						rowData.DivideProjCode(this.ProjCodeText.Text.Trim(), this.ProjectCodeLength);
//
//						code = rowData.ProjCode.ToString();		//コード
//						sbNo = rowData.ProjSbno.ToString();		//サブナンバー
//					}
//// 管理番号 B23717 From
////// 管理番号 B17601 From
//////					if (ExchangeRez.IsExists(this.CommonData, this.ExchangeRezNoText.Text, this.DeptCodeText.Text, code, sbNo, this.PuDateText.Text, out rate, "S"))
////					if (ExchangeRez.IsExists(this.CommonData, this.ExchangeRezNoText.Text, this.DeptCodeText.Text, code, sbNo, this.PuDateText.Text, out rate, "S", this.CurCodeList.SelectedValue.Trim()))
////// 管理番号 B17601 To
//					if (this.PuModeTypeList.SelectedValue != "2")
//					{
//						checkExchangeRez = ExchangeRez.IsExists(this.CommonData, this.ExchangeRezNoText.Text, this.DeptCodeText.Text, code, sbNo, this.PuDateText.Text, out rate, "S", this.CurCodeList.SelectedValue.Trim());
//					}
//					else
//					{
//						checkExchangeRez = ExchangeRez.IsExistsReturn(this.CommonData, this.ExchangeRezNoText.Text, this.DeptCodeText.Text, code, sbNo, this.PuDateText.Text, out rate, "S", "B", this.CurCodeList.SelectedValue.Trim());
//					}
//
//					if (checkExchangeRez)
//// 管理番号 B23717 To
//					{
//// 管理番号 B14549 From
////						this.RateText.Text = rate;
//						if(rate.Length != 0)
//						{
//// 管理番号 B18516 From
////							this.RateText.Text = Common.FormatAmt(decimal.Parse(rate), curDigit, false, "1");
//							this.RateText.Text = decimal.Parse(rate).ToString("#0.00");
//// 管理番号 B18516 To
//						}
//						else
//						{
//							this.RateText.Text = string.Empty;
//						}
//						//ボディ：詳細タブ：レート にボディ：基本タブ：レートの値を設定する。
//						RateLabel.Text = RateText.Text;
//// 管理番号 B14549 To
//					}
					rate = rowData.Rate;
// 管理番号B26678 To
				}
				else if(ExchangeTypeList.SelectedValue == "2" || ExchangeTypeList.SelectedValue == "3")
				{
					rate = Rate.GetRate(this.CommonData, this.CurCodeList.SelectedValue, generalDateTime, RateSaerchOption.Book);
				}
// 管理番号 B19458 From
				// rateの取り直しをしているので、rowDataを上書きする（以降の計算に影響するため）
				if ( !"".Equals(rate) ) 
				{
					rowData.Rate = rate;
				}
// 管理番号 B19458 To
			}
// 管理番号 B14661 To
			decimal curRate = rate.Length > 0 ? decimal.Parse(rate) : 1M;
// 管理番号 B14549 From
// 管理番号 B18516 From
//			this.RateText.Text =  Common.FormatAmt(curRate, curDigit, false, "1");
			this.RateText.Text = curRate.ToString("#0.00");
// 管理番号 B18516 To
// 管理番号 B14549 To
			this.RateLabel.Text					= RateText.Text;

			//Enabled制御処理（参照モード以外）
			//Enabled設定
			if(this.CurCodeList.SelectedValue == this.KeyCurrencyCode)
			{
				this.ExchangeTypeList.Enabled =false;
				this.ExchangeRezNoText.Enabled =false;
				this.RateText.Enabled =false;
			}
			else
			{
				switch (paramType)
				{
					case ParamCodeType.NEW :
					case ParamCodeType.COPY :
					case ParamCodeType.MOD :
					case ParamCodeType.COPY_PO:
					case ParamCodeType.COPY_RC:

						this.ExchangeTypeList.Enabled =true;
						this.ExchangeRezNoText.Enabled =false;
						this.RateText.Enabled =true;

						this.ExchangeRezNoText.Enabled = this.ExchangeTypeList.SelectedValue=="1";
						this.RateText.Enabled				= this.ExchangeTypeList.SelectedValue!="1";

						//入荷参照時
						if (refType == RefCodeType.RCPT)
						{
							this.CurCodeList.Enabled =false;
							//為替予約番号が設定されているならば
							if(this.ExchangeRezNoText.Text.Length>0)
							{
								this.ExchangeTypeList.Enabled =false;
								this.ExchangeRezNoText.Enabled =false;
							}
						}


						break;
				}
			}

			//管理番号 B13502 To

// 管理番号K27062 From
//			//受渡場所
//			setListItem(this.DeliPlaceCodeList, rowData.DeliPlaceCode);
			this.DeliPlaceCodeText.Text = rowData.DeliPlaceCode;
// 管理番号K27062 To
			this.DeliPlaceNameText.Text = rowData.DeliPlaceName;
// 管理番号 B24164 From
			this.DeliPlaceCountryCode.Text = rowData.DeliPlaceCountryCode;
// 管理番号 B24164 To
			this.ZipText.Text				= rowData.DeliPlaceZip;
			this.StateText.Text			= rowData.DeliPlaceState;
			this.CityText.Text			= rowData.DeliPlaceCity;
			this.Address1Text.Text	= rowData.DeliPlaceAddress1;
			this.Address2Text.Text	= rowData.DeliPlaceAddress2;
			this.PhoneText.Text		= rowData.DeliPlacePhone;
			this.FaxText.Text			= rowData.DeliPlaceFax;
			this.DeliUserNameText.Text = rowData.DeliPlaceUserName;

// 管理番号 B24264 From
//			//仕入先情報
//			this.AcTable.Visible = rowData.TempCodeFlg == "1";
//			if (AcTable.Visible)
//			{
//				this.SuplFormalNameText.Text = rowData.SuplName;
//				this.SuplUserNameText.Text = rowData.SuplUserName;
//				this.SuplDeptName1Text.Text = rowData.SuplDeptName1;
//				this.SuplDeptName2Text.Text = rowData.SuplDeptName2;
//				this.AcTypeList.SelectedValue = rowData.AcType;
//				if (rowData.BankCode.Length > 0)
//				{
//// 管理番号 B20392 From
////					Bank.IsExists(this.CommonData, this.CountryCode, rowData.BankCode, out bankName);
//					Bank.IsExists(this.CommonData, this.JapanCountryCode, rowData.BankCode, out bankName);
//// 管理番号 B20392 To
//					this.BankCodeText.Text	= rowData.BankCode;
//					this.BankNameLabel.Text	= bankName.Length > 10 ? bankName.Substring(0,10) : bankName;
//				}
//				else
//				{
//					this.BankNameLabel.Text	= string.Empty;
//				}

//				if (rowData.BankBranchCode.Length > 0)
//				{
//// 管理番号 B20392 From
////					BankBranch.IsExists(this.CommonData, this.CountryCode, rowData.BankCode, rowData.BankBranchCode, out bankBranchName);
//					BankBranch.IsExists(this.CommonData, this.JapanCountryCode, rowData.BankCode, rowData.BankBranchCode, out bankBranchName);
//// 管理番号 B20392 To
//					this.BankBranchCodeText.Text	= rowData.BankBranchCode;
//					this.BankBranchNameLabel.Text	= bankBranchName.Length > 10 ? bankBranchName.Substring(0,10) : bankBranchName;
//				}
//				else
//				{
//					this.BankBranchCodeText.Text	= string.Empty;
//					this.BankBranchNameLabel.Text	= string.Empty;
//				}

//				this.BankAcTypeList.SelectedValue = rowData.BankAcType == string.Empty ? "O" : rowData.BankAcType;
//				this.AcHolderText.Text            = rowData.AcHolder;
//				this.AcNoText.Text                = rowData.AcNo;
//			}
// 管理番号 B24264 To

			// 支払条件
// 管理番号 B15586 From
// 管理番号 B24440 From
//			if(this.paramType != ParamCodeType.COPY)
			if(this.paramType != ParamCodeType.COPY || rowData.TempCodeFlg == "1") // コピーでない　または　雑取引先の場合
// 管理番号 B24440 To
			{
				this.DtTypeList.SelectedValue          = rowData.DtType == "E" || rowData.TempCodeFlg == "1" ? "E" : "L";
// 管理番号 B19467 From
//				this.DtTypeList.Enabled                = rowData.DtType == "E" || rowData.TempCodeFlg == "1" ? false : true;
				rowData.DivideSuplCode(SuplCodeText.Text.Trim(), this.CompanyCodeLength);
				string cDate = DateValidator.IsDate(PuDateText.Text.Trim()) ? PuDateText.Text.Trim() : todayDate;
				DataTable suplData = Supl.SetDtData(this.CommonData, this.SuplCodeText.Text.Trim(), this.CompanyCodeLength, cDate);
				DataRow[] Rows = suplData.Select();

				if (!suplData.HasErrors && Rows.Length==1)
				{
					DataRow dtRow = Rows[0];
					this.DtTypeList.Enabled			   = dtRow["DT_TYPE"].ToString() == "E" || dtRow["TEMP_CODE_FLG"].ToString() == "1" ? false : true;
				}
				else
				{
					setMessageLabel(HtmlMessage(AllegroMessage.SC_MS_S10022, MessageLevel.Warning));
					this.setDtControlCondition(DtTypeList.SelectedValue == "E");
					OverRideFocus(SuplCodeText.ClientID);
				}
// 管理番号 B19467 To
				this.Dt1SttlMthdCodeList.SelectedValue = rowData.Dt1SttlMthdCode;
				this.Dt1BasisAmtText.Text              = rowData.Dt1BasisAmt;
				this.Dt2RatioText.Text                 = rowData.Dt2Ratio;
				this.Dt2SttlMthdCodeList.SelectedValue = rowData.Dt2SttlMthdCode;
				this.Dt3SttlMthdCodeList.SelectedValue = rowData.Dt3SttlMthdCode;
				this.DtSightText.Text                  = rowData.DtSight;
			}
// 管理番号 B15586 To
// 管理番号 B15855 From
			else
			{
// 管理番号 B16517 From
//				setDtData(true);
				string tempCurCodeList = string.Empty;		//通貨コード退避用
				tempCurCodeList = rowData.CurCode.Length > 0 ? rowData.CurCode : this.KeyCurrencyCode;
				setDtData(true);

				//通貨コードが支払条件取得により変わってしまうためコピー元通貨を上書きする
				this.CurCodeList.SelectedValue  	= tempCurCodeList;
// 管理番号 B16517 To
			}
// 管理番号 B15855 To

			//締日
			if (paramType==ParamCodeType.MOD || paramType==ParamCodeType.VIEW)
			{
				this.CutoffDateText.Text   = rowData.CutoffDate;
				this.PymtPlanDateText.Text = rowData.PymtPlanDate;
			}
			else
			{
				//setCutoffDate("2");
				SetCutOffDataInfo(null, CutOffDateType.Now);
			}
			setDtControlCondition(this.DtTypeList.SelectedValue=="E");

			//締日条件翻訳
			this.CutOffDateConditionNote.Text = string.Empty;
			//this.CutOffDateConditionNote.Text = getDtConditionString(rowData.DtCutoffCycleType, rowData.DtCutoffDay, rowData.DtTermMonthCnt, rowData.DtTermDay);
			// 管理番号 B13878 From
			if (rowData.HoldFlg == "1")
			{
				this.HoldCheck.Checked = true;
			}
			else
			{
				this.HoldCheck.Checked = false;
			}
			// 管理番号 B13878 To
			// 支払条件表記
			this.DtNoteText.Text      = rowData.DtNote;
			// 支払処理日
// 管理番号 B21977 From
//			this.PaymentDateLabel.Text= rowData.CutoffFinFlg == "1" ? rowData.CutoffDate : string.Empty;
			this.PaymentDateLabel.Text= rowData.CutoffFinFlg == "1" ? rowData.CutoffFinDate : string.Empty;
// 管理番号 B21977 To

			// 摘要
			this.RemarksCodeText.Text = rowData.RemarksCode;
			this.RemarksText.Text     = rowData.Remarks;

// 管理番号 B22231 From
//			// 管理番号 B13798 From
//			AdminItem1Hidden.Value						= rowData.AdminItem1;
//			AdminItem2Hidden.Value						= rowData.AdminItem2;
//			AdminItem3Hidden.Value						= rowData.AdminItem3;
//			// 管理番号 B13798 To
			AdminItem1Hidden.Value 						= Server.UrlEncode(rowData.AdminItem1);
			AdminItem2Hidden.Value 						= Server.UrlEncode(rowData.AdminItem2);
			AdminItem3Hidden.Value 						= Server.UrlEncode(rowData.AdminItem3);
// 管理番号 B22231 To

// 管理番号K27058 From
//// 管理番号 K20687 From
//			this.BookBasisTypeRadio.SelectedValue		= rowData.BookBasisType;
//// 管理番号 K20687 To
			this.BookBasisTypeList.SelectedValue		= rowData.BookBasisType + rowData.BookBasisTypeDtilCode;
// 管理番号K27058 To
// 管理番号K27154 From
			this.DealTypeList.SelectedValue				= rowData.DealTypeCode;
// 管理番号K27154 To

// 管理番号 K25667 From
			attachmentCancelFlg = rowData.CancelFlg;
			attachmentRedSlipFlg = rowData.RedSlipFlg;
			// 添付資料情報を取得してセッションに保持する
			if(this.paramType != ParamCodeType.COPY) // コピーモードの時は取得しない
			{
				if (rowData.SuplSlipNo.Length != 0)
				{
					this.attachmentFiles =
					CM.WF.Common.SelectAttachmentFile(this.CommonData, "CG2", slipNo);
				}
				else
				{
					this.attachmentFiles =
					CM.WF.Common.SelectAttachmentFile(this.CommonData, slipType, slipNo);
				}
			}
// 管理番号 K25667 To

			// 詳細タブ
			setAmtTtl(true);
			setDataGridProperty(rowData.Dt);
// 管理番号K27057 From
			CustomItem.SetCustomItem(CustomItemPanel, rowData.CustomItemHead, rowData.PuDate, paramType == ParamCodeType.MOD || paramType == ParamCodeType.VIEW);
// 管理番号K27057 To
			if (rowData.InputEmpCode.Length > 0)
			{
				string inputEmpShortName = string.Empty;
				Emp.IsExists(this.CommonData, rowData.InputEmpCode, out inputEmpShortName, false);
				this.InputEmpCodeText.Text = rowData.InputEmpCode;
				this.InputEmpCodeLabel.Text = inputEmpShortName;
			}
		}

		private void setRowData()
		{
// 管理番号 K22205 From
            //入力社員コード
            rowData.InputEmpCode        = this.UserCode;
// 管理番号 K22205 To
			rowData.PuDate				= this.PuDateText.Text.Trim();
			//売上番号
			rowData.PuNo				= this.PuNoText.Text.Trim();
			//参照番号は設定しない
			rowData.PuDate				= this.PuDateText.Text.Trim();
// 管理番号 K16590 From
			rowData.DealDate			= this.DealDateText.Text.Trim();
// 管理番号 K16590 To
// 管理番号 K20685 From
//			rowData.ApprovalStatusType	= this.StatusDropdownlist.SelectedValue;
			if(this.StatusDropdownlist.SelectedValue == "6")
			{
				rowData.ApprovalStatusType = "3" ;
			}
			else
			{
				rowData.ApprovalStatusType = this.StatusDropdownlist.SelectedValue;
			}
// 管理番号 K20685 To
			string suplCode				= this.SuplCodeText.Text.Trim();
			if (suplCode.Length > 0)
			{
				rowData.DivideSuplCode(suplCode, this.CompanyCodeLength);
// 管理番号 K24789 From
// 仕入先コード変更時のみ再取得ため、コメントアウト
//				//雑コードが取れていない時
//				if (rowData.TempCodeFlg.Length == 0)
//				{
//					rowData.DivideSuplCode(suplCode, this.CompanyCodeLength);
//					DataTable dt = Supl.SetDtData(this.CommonData, rowData.SuplCode, rowData.SuplSbno);
//					if (!dt.HasErrors && dt.Rows.Count == 1)
//					{
//						rowData.TempCodeFlg					= dt.Rows[0]["TEMP_CODE_FLG"].ToString();
//						rowData.PuCtaxTypeCode			= dt.Rows[0]["PU_CTAX_TYPE_CODE"].ToString();
//						rowData.PuReturnCtaxTypeCode	= dt.Rows[0]["PU_RETURN_CTAX_TYPE_CODE"].ToString();
//						rowData.CtaxRoundType				= dt.Rows[0]["CTAX_FRACTION_ROUND_TYPE"].ToString();
//						rowData.CtaxBuildupType				= dt.Rows[0]["CTAX_BUILDUP_TYPE"].ToString();
//					}
//				}
// 管理番号 K24789 To
			}
			else
			{
				rowData.SuplCode = string.Empty;
				rowData.SuplSbno = string.Empty;
			}
// 管理番号 B24264 From
//			rowData.SuplName       = SuplNameText.Text.Trim();
// 管理番号 B24264 To
// 管理番号B18691 From
//			rowData.SuplShortName  = string.Empty;
			rowData.SuplShortName  = SuplNameText.Text.Trim();
// 管理番号B18691 To
// 管理番号K27058 From
//			rowData.PuModeType     = this.PuModeTypeList.SelectedValue;
			rowData.PuModeType			= this.puModeType;
			rowData.PuModeTypeDtilCode	= this.puModeTypeDtilCode;
// 管理番号K27058 To
			rowData.RefPuNo        = this.RefPuText.Text.Trim();
			rowData.SuplBillSlipNo = this.SuplBillSlipNoText.Text.Trim();
			//管理番号 B13502 From
			//			rowData.CurCode        = this.CurCodeLabel.Text.Trim();
			rowData.CurCode        = CurCodeList.SelectedValue;
			//管理番号 B13502 To

			rowData.EmpCode        = this.EmpCodeText.Text.Trim();
			rowData.DeptCode       = this.DeptCodeText.Text.Trim();
			if (this.ProjImplementFlg)
			{
				string projCode = this.ProjCodeText.Text.Trim();
				if (projCode.Length > 0)
				{
					rowData.DivideProjCode(projCode, this.ProjectCodeLength);
				}
				else
				{
					rowData.ProjCode = string.Empty;
					rowData.ProjSbno = string.Empty;
				}
			}
			rowData.DeliType = this.DeliTypeWRadio.Checked ? "W" : "D";
			rowData.WhCode   = this.DeliTypeWRadio.Checked ? this.WhCodeText.Text.Trim() : string.Empty;

			if (DeliTypeDRadio.Checked)
			{
				string deliCustCode = DeliCustCodeText.Text.Trim();
				if (deliCustCode.Length > 0)
				{
					rowData.DivideDeliCustCode(deliCustCode, this.CompanyCodeLength);
				}
			}
			else
			{
				rowData.DeliCustCode = string.Empty;
				rowData.DeliCustSbno = string.Empty;
			}

			rowData.PuName				 = this.PuNameText.Text.Trim();

			//受渡場所
// 管理番号K27062 From
//			rowData.DeliPlaceCode		 = this.DeliPlaceCodeList.SelectedValue.Length!=0 ? this.DeliPlaceCodeList.SelectedValue : "00";
			rowData.DeliPlaceCode		 = this.DeliPlaceCodeText.Text.Trim();
// 管理番号K27062 To
			rowData.DeliPlaceName		 = this.DeliPlaceNameText.Text.Trim();
			rowData.DeliPlaceCountryCode = this.DeliPlaceCountryCode.Text.Trim();
			rowData.DeliPlaceZip		 = this.ZipText.Text.Trim();
			rowData.DeliPlaceState		 = this.StateText.Text.Trim();
			rowData.DeliPlaceCity		 = this.CityText.Text.Trim();
			rowData.DeliPlaceAddress1	 = this.Address1Text.Text.Trim();
			rowData.DeliPlaceAddress2	 = this.Address2Text.Text.Trim();
			rowData.DeliPlacePhone		 = this.PhoneText.Text.Trim();
			rowData.DeliPlaceFax		 = this.FaxText.Text.Trim();
			rowData.DeliPlaceUserName	 = this.DeliUserNameText.Text.Trim();

// 管理番号 B24264 From
//			if (AcTable.Visible)
//			{
//				rowData.SuplName        = this.SuplFormalNameText.Text.Trim();
//				rowData.SuplShortName	= this.SuplNameText.Text.Trim();
//				rowData.SuplUserName	= this.SuplUserNameText.Text.Trim();
//				rowData.SuplDeptName1	= this.SuplDeptName1Text.Text.Trim();
//				rowData.SuplDeptName2	= this.SuplDeptName2Text.Text.Trim();
//				rowData.AcNo            = this.AcNoText.Text.Trim();
//				rowData.AcHolder        = this.AcHolderText.Text.Trim();
//				rowData.AcType          = this.AcTypeList.SelectedValue;
//				rowData.BankAcType      = this.BankAcTypeList.SelectedValue;
//// 管理番号 B20392 From
////				rowData.BankCountryCode = this.CountryCode;
//				rowData.BankCountryCode = this.JapanCountryCode;
//// 管理番号 B20392 To
//				rowData.BankCode        = this.BankCodeText.Text.Trim();
//				rowData.BankBranchCode  = this.BankBranchCodeText.Text.Trim();
//			}
// 管理番号 B24264 To

			//支払条件
			rowData.DtType          = this.DtTypeList.SelectedValue;
			rowData.Dt1SttlMthdCode = this.Dt1SttlMthdCodeList.SelectedValue;
			rowData.Dt1BasisAmt     = this.Dt1BasisAmtText.Text.Trim();
			rowData.Dt2Ratio        = this.Dt2RatioText.Text.Trim();
			rowData.Dt2SttlMthdCode = this.Dt2SttlMthdCodeList.SelectedValue;
			rowData.Dt3SttlMthdCode = this.Dt3SttlMthdCodeList.SelectedValue;
			rowData.DtSight         = this.DtSightText.Text.Trim();

			if(this.DtTypeList.SelectedValue=="L")
			{
				rowData.CutoffDate = this.CutoffDateText.Text.Trim();
			}
			else
			{
				rowData.CutoffDate = this.PuDateText.Text.Trim();
			}
			rowData.PymtPlanDate = this.PymtPlanDateText.Text.Trim();
			// 管理番号 B13878 From
			if(this.HoldCheck.Checked)
			{
				rowData.HoldFlg = "1";
			}
			else
			{
				rowData.HoldFlg = "0";
			}
			// 管理番号 B13878 To
			rowData.DtNote      = this.DtNoteText.Text.Trim();
			rowData.RemarksCode = this.RemarksCodeText.Text.Trim();
			rowData.Remarks     = this.RemarksText.Text.Trim();
// 管理番号 B22231 From
//			// 管理番号 B13798 From
//			rowData.AdminItem1					= AdminItem1Hidden.Value;
//			rowData.AdminItem2					= AdminItem2Hidden.Value;
//			rowData.AdminItem3					= AdminItem3Hidden.Value;
//			// 管理番号 B13798 To
			rowData.AdminItem1	= Server.UrlDecode(AdminItem1Hidden.Value);
			rowData.AdminItem2	= Server.UrlDecode(AdminItem2Hidden.Value);
			rowData.AdminItem3	= Server.UrlDecode(AdminItem3Hidden.Value);
// 管理番号 B22231 To

// 管理番号K27058 From
//// 管理番号 K20687 From
//			rowData.BookBasisType		= this.BookBasisTypeRadio.SelectedValue;
//// 管理番号 K20687 To
			rowData.BookBasisType			= this.bookBasisType;
			rowData.BookBasisTypeDtilCode	= this.bookBasisTypeDtilCode;
// 管理番号K27058 To
// 管理番号K27154 From
			rowData.DealTypeCode		= this.DealTypeList.SelectedValue;
// 管理番号K27154 To


			//その他//////////
			//組織変更ID
			rowData.OrgChangeId	= this.CurrentOrganizationChangeId.ToString();

			//その他固定パラメータ
			rowData.CreditConfirm		 = string.Empty;

			//管理番号 B13502 From
			//			rowData.ExchangeType		 = string.Empty;
			//			rowData.ExchangeRezNo		 = string.Empty;
			//			rowData.Rate				 = "1";
			rowData.ExchangeType			= this.ExchangeTypeList.SelectedValue;
			rowData.ExchangeRezNo			= this.ExchangeRezNoText.Text.Trim();
			rowData.Rate					= this.RateText.Text.Trim() ;
			//管理番号 B13502 To



			rowData.OriginDeptCode		 = rowData.DeptCode;
			rowData.OldDeptCode			 = string.Empty;
			rowData.DataMigrateDatetime	 = string.Empty;
			rowData.CustName			 = string.Empty;

			//仕入先は変更時以外は初期値で転送
			if (paramType!="Mod")
			{
				rowData.SuplCountryCode = string.Empty;
				rowData.SuplZip = string.Empty;
				rowData.SuplState = string.Empty;
				rowData.SuplCity = string.Empty;
				rowData.SuplAddress1 = string.Empty;
				rowData.SuplAddress2 = string.Empty;
				rowData.SuplPhone = string.Empty;
				rowData.SuplPhone = string.Empty;
			}

// 管理番号 B24264 From
			if (rowData.TempCodeFlg == "1")
			{
				// 雑仕入先登録画面で入力した情報を格納する（略名は取得済みのため除く）
				rowData.SuplName		= tempRowData["TEMP_SUPL_NAME"].ToString();
				rowData.SuplDeptName1	= tempRowData["TEMP_SUPL_DEPT_NAME_1"].ToString();
				rowData.SuplDeptName2	= tempRowData["TEMP_SUPL_DEPT_NAME_2"].ToString();
				rowData.SuplCountryCode = tempRowData["TEMP_SUPL_COUNTRY_CODE"].ToString();
				rowData.SuplZip			= tempRowData["TEMP_SUPL_ZIP"].ToString();
				rowData.SuplState		= tempRowData["TEMP_SUPL_STATE"].ToString();
				rowData.SuplCity		= tempRowData["TEMP_SUPL_CITY"].ToString();
				rowData.SuplAddress1	= tempRowData["TEMP_SUPL_ADDRESS1"].ToString();
				rowData.SuplAddress2	= tempRowData["TEMP_SUPL_ADDRESS2"].ToString();
				rowData.SuplPhone		= tempRowData["TEMP_SUPL_PHONE"].ToString();
				rowData.SuplFax			= tempRowData["TEMP_SUPL_FAX"].ToString();
				rowData.SuplUserName	= tempRowData["TEMP_SUPL_USER_NAME"].ToString();
				rowData.AcNo			= tempRowData["AC_NO"].ToString();
// 管理番号B27219 From
				rowData.JapanCountryCode = this.JapanCountryCode;
				rowData.BankCountryCode = tempRowData["BANK_COUNTRY_CODE"].ToString();
// 管理番号B27219 To
				rowData.AcHolder		= tempRowData["AC_HOLDER"].ToString();
				rowData.AcType			= tempRowData["AC_TYPE"].ToString();
				rowData.BankAcType		= tempRowData["BANK_AC_TYPE"].ToString();
// 管理番号B27219 From
//				rowData.BankCountryCode = tempRowData["BANK_COUNTRY_CODE"].ToString();
// 管理番号B27219 To
				rowData.BankCode		= tempRowData["BANK_CODE"].ToString();
				rowData.BankBranchCode = tempRowData["BANK_BRANCH_CODE"].ToString();
			}
// 管理番号 B24264 To
			rowData.CanceledOrderFlg		 = "0";
			rowData.OverseasFlg				 = "0";
			rowData.TenorCode				 = string.Empty;
			rowData.FmoneySttlPeriodSttMonth = string.Empty;
			rowData.FmoneySttlPeriodEndMonth = string.Empty;
			rowData.LcNo					 = string.Empty;

			// 管理番号 B14298 From
			rowData.PriceDecimalUseFlg       = this.PriceDecimalUseFlg;
			rowData.CurDigit				 = this.curDigit;
			// 管理番号 B14298 To
// 管理番号 B20818 From
// 管理番号 B21313 From
//			if (paramType == "New" && keyColumn.RefType == "NONE")
			if ((paramType == "New" && keyColumn.RefType == "NONE") || paramType == "Copy")
// 管理番号 B21313 To
			{
				rowData.RefUpdateDatetime = DateTime.Now;
			}
// 管理番号 B20818 To
// 管理番号 K22217 From
            rowData.ApprovalPlanEmpCode = appEmpCode;
            rowData.ChangeApprovalRouteId = appRouteId;
// 管理番号 K22217 To
// 管理番号 K24284 From
			rowData.ProjInputScIndisFlg		= this.ProjInputScIndisFlg;
			rowData.ProjImplementFlg		= this.ProjImplementFlg;
// 管理番号 K24284 To
// 管理番号 K25647 From
			rowData.PriceDecimalDigit = this.PriceDecimalDigit;
			rowData.MyCompQtDecimalUseFlg = this.QtDecimalUseFlg;
// 管理番号 K25647 To
// 管理番号 K25679 From
			rowData.PoAdminNo		= this.PoAdminNoText.Text.Trim();
// 管理番号 K25679 To
			rowData.InputEmpCode = this.InputEmpCodeText.Text.Trim();
			rowData.CtaxFractionRoundType = this.CtaxFractionRoundTypeList.SelectedValue;
			rowData.CarrierCode = this.CarrierCodeDrop.SelectedValue;
			return;
		}

// 管理番号K27057 From
		private void CustomItemPanel_TextChanged(object sender, System.EventArgs e)
		{
			lotDiff = true;
			return;
		}
// 管理番号K27057 To
		#endregion

		#region イベントコントロール(ヘッダ)
		private void PuDateText_TextChanged(object sender, EventArgs e)
		{
// 管理番号 B25845 From
			//本イベントとボタンイベントが連続した場合に、ボタン側の処理を止めるため、
			//明細行の項目更新時と更新と同様にフラグを立てる。
			dtlChangeFlg = true;
// 管理番号 B25845 To

			if (SuplCodeText.Text.Length != 0)
			{
				SetCutOffDataInfo(sender, CutOffDateType.Now);
			}

			//管理番号 B13502 From
			//為替区分が予約あり以外のとき
			if(this.ExchangeTypeList.SelectedValue != "1")
			{
				//計上レートを取得する。
				SetRate(sender);
			}
// 管理番号 B23304 From
//			else
//			{
//				// 変更された受注日に対する予約番号のチェックを行う
//// 管理番号 B17665 From
////				ExchangeRezNoTextChanged();
//				ExchangeRezNoTextChanged(sender);
//// 管理番号 B17665 To
//			}
// 管理番号 B23304 To
// 管理番号 B20324 From
			// 計上日を設定
			rowData.PuDate = PuDateText.Text.Trim();
			// 明細行（登録済み行）の標準単価の読み直し
			string compareDate = DateValidator.IsDate(this.PuDateText.Text) ? this.PuDateText.Text : todayDate;
			curDigit = Cur.GetDecimalDigit(CommonData, this.CurCodeList.SelectedValue);
// 管理番号 K24789 From
//			rowData.ReloadProdPrice(this.CommonData, CurCodeList.SelectedValue, SuplCodeText.Text, this.CompanyCodeLength, this.DeptCodeText.Text.Trim(), compareDate, double.Parse(curDigit), AmtRoundType);
			string dealDate = DateValidator.IsDate(this.DealDateText.Text) ? this.DealDateText.Text : todayDate;
			// 日付管理区分が「計上日管理基準」の場合
			// B:取引日基準で取引日変更		消費税情報のみ再取得
			// PB:計上日基準で仕入日変更	消費税と商品単価再取得
			// P:取引日基準で仕入日変更		商品単価のみ再取得
			if (this.DateAdminType == "2")
			{
				// 取引日に計上日を設定
				DealDateText.Text = rowData.DealDate = dealDate = PuDateText.Text.Trim();
// 管理番号B26146 From
//				rowData.ReloadProdPrice(this.CommonData, CurCodeList.SelectedValue, SuplCodeText.Text, this.CompanyCodeLength, this.DeptCodeText.Text.Trim(), compareDate, double.Parse(curDigit), AmtRoundType, dealDate, "B");
				rowData.ReloadProdPrice(this.CommonData, CurCodeList.SelectedValue, SuplCodeText.Text, this.CompanyCodeLength, this.DeptCodeText.Text.Trim(), compareDate, double.Parse(curDigit), AmtRoundType, dealDate, "PB");
// 管理番号B26146 To
			}
			else
			{
				rowData.ReloadProdPrice(this.CommonData, CurCodeList.SelectedValue, SuplCodeText.Text, this.CompanyCodeLength, this.DeptCodeText.Text.Trim(), compareDate, double.Parse(curDigit), AmtRoundType, dealDate, "P");
			}
// 管理番号 K24789 To
// 管理番号 B20324 To
			// 合計金額再計算
			setAmtTtl(true);
			setDataGridProperty(rowData.Dt);
			//管理番号 B13502 To
// 管理番号 B23588 From
			clearNewControlValue();
			setNewControlCondition(true);
// 管理番号 B23588 To

			if (returnValue.Length != 0)
			{
				OverRideFocus(returnValue);
			}
			else
			{
				string nextControlID = string.Empty;
				if(this.StatusDropdownlist.Visible)
				{
					nextControlID = this.StatusDropdownlist.ID;
				}
				else if(this.SuplCodeText.Enabled)
				{
					nextControlID = SuplCodeText.ID;
				}
// 管理番号 K16590 From
				else if(this.DealDateText.Enabled)
				{
					nextControlID = DealDateText.ID;
				}
// 管理番号 K16590 To
				else
				{
					nextControlID = SuplBillSlipNoText.ID;
				}
				FocusControl(nextControlID, sender);
			}
// 管理番号 K24789 From
//// 管理番号 K16590 From
//			//日付管理基準が「計上日管理基準」の場合、「仕入日」をセットする
//			DealDateText.Text = (this.DateAdminType == "2") ? PuDateText.Text : DealDateText.Text;
//// 管理番号 K16590 To
// 管理番号 K24789 To
		}

// 管理番号 K22217 From
        private void StatusDropdownlist_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            if (StatusDropdownlist.SelectedValue == "1")
            {
                RouteChangeButton.Visible = true;
            }
            else if (StatusDropdownlist.SelectedValue == "5")
            {
                RouteChangeButton.Visible = false;
            }
            SessionRemove();

            FocusControl(SuplCodeText.ID, sender);
        }
// 管理番号 K22217 To

		private void SuplCodeText_TextChanged(object sender, System.EventArgs e)
		{
// 管理番号 B25845 From
			//本イベントとボタンイベントが連続した場合に、ボタン側の処理を止めるため、
			//明細行の項目更新時と更新と同様にフラグを立てる。
			dtlChangeFlg = true;
// 管理番号 B25845 To

			string suplCode	   = this.SuplCodeText.Text.Trim();
			string suplName	   = string.Empty;
			string suplCtaxFractionRoundType = string.Empty;
			string compareDate = DateValidator.IsDate(this.PuDateText.Text) ? this.PuDateText.Text : todayDate;
// 管理番号 K24789 From
			string dealDate = DateValidator.IsDate(this.DealDateText.Text) ? this.DealDateText.Text : todayDate;
// 管理番号 K24789 To
			string focusControl = this.SuplCodeText.NextControlID;

// 管理番号 B24264 From
			tempRowDataClear();
// 管理番号 B24264 To

			if (suplCode.Length > 0)
			{
				if (Supl.IsExistsSupl(this.CommonData, suplCode, this.CompanyCodeLength, out suplName,out suplCtaxFractionRoundType, compareDate, false, "D", false))
				{
					this.SuplNameText.Text = rowData.SuplShortName = suplName;
					this.CtaxFractionRoundTypeList.SelectedValue = suplCtaxFractionRoundType;
					// 支払条件の取得
					setDtData(true);

					//管理番号 B13502 From
					// 通貨コードに仕入先通貨コードがセットされたため通貨コード変更イベント起動

					CurCodeListChanged();
					//管理番号 B13502 To

// 管理番号 K24789 From
//// 管理番号 K24278 From
//					string ctaxBuildupType		= string.Empty;
//					string roundType			= string.Empty;
//					string puCtaxType			= string.Empty;
//					string puReturnCtaxType		= string.Empty;
//					string imposeFlg			= string.Empty;
//					// 仕入先課税区分取得
//					if (Supl.GetCtaxInfo(this.CommonData, suplCode, this.CompanyCodeLength, out ctaxBuildupType, out roundType, out puCtaxType, out puReturnCtaxType, out imposeFlg))
//					{
//						rowData.ImposeFlg		= imposeFlg;
//					}
//// 管理番号 K24278 To
// 管理番号 K24789 To

					// 明細行がある場合 全明細行の価格・消費税率を更新
					if (rowData.HasRows)
					{
						//仮データは削除
						if (rowData.IsExistsTemporary)
						{
							rowData.RollBack(true);
						}
						insertFlg = false;
// 管理番号 K24789 From
//						// 管理番号 B11723・B11796・B13502　From
//						//						rowData.ReloadProdPrice(this.CommonData, CurCodeLabel.Text, suplCode, this.CompanyCodeLength, this.DeptCodeText.Text.Trim());
//						//						rowData.ReloadProdPrice(this.CommonData, CurCodeLabel.Text, suplCode, this.CompanyCodeLength, this.DeptCodeText.Text.Trim(), compareDate, double.Parse(curDigit), AmtRoundType);
//						rowData.ReloadProdPrice(this.CommonData, CurCodeList.SelectedValue, suplCode, this.CompanyCodeLength, this.DeptCodeText.Text.Trim(), compareDate, double.Parse(curDigit), AmtRoundType);
//						// 管理番号 B11723・B11796・B13502 To
						rowData.ReloadProdPrice(this.CommonData, CurCodeList.SelectedValue, suplCode, this.CompanyCodeLength, this.DeptCodeText.Text.Trim(), compareDate, double.Parse(curDigit), AmtRoundType, dealDate, "S");
// 管理番号 K24789 To



						setDataGridProperty(rowData.Dt);
						DataGrid1.EditItemIndex = -1;
						setNewControlCondition(true);
						setAmtTtl(true);
					}
// 管理番号K27057 From
					CustomItem.SetMasterUse(CommonData, CustomItemPanel, rowData.SuplCode, rowData.SuplSbno);
// 管理番号K27057 To
// 管理番号 K25679 From
//// 管理番号 K16590 From
////					focusControl = this.SuplNameText.Enabled ? this.SuplNameText.ID : this.PuModeTypeList.Enabled ? this.PuModeTypeList.ID : this.SuplBillSlipNoText.ID;
//					focusControl = this.SuplNameText.Enabled ? this.SuplNameText.ID : this.DealDateText.Enabled ? this.DealDateText.ID : this.PuModeTypeList.Enabled ? this.PuModeTypeList.ID : this.SuplBillSlipNoText.ID;
//// 管理番号 K16590 To
					focusControl = this.SuplNameText.Enabled ? this.SuplNameText.ID : this.DealDateText.Enabled ? this.DealDateText.ID : this.PoAdminNoText.ID;
// 管理番号 K25679 To

// 管理番号 B24264 From
					if (rowData.TempCodeFlg == "1")
					{
						focusControl = SuplDtilButton.ID;
					}
// 管理番号 B24264 To

					this.SuplCodeText.NextControlID = focusControl;

				}
				else
				{
// 管理番号 B24264 From
					// 無効な仕入先の場合は雑コードフラグをOFF
					rowData.TempCodeFlg = "0";
// 管理番号 B24264 To
// 					setMessageLabel(HtmlMessage(AllegroMessage.S20005("仕入先"), MessageLevel.Warning)); //K24546
					setMessageLabel(HtmlMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS000784")), MessageLevel.Warning));
					this.SuplNameText.Enabled = false;
					suplName = string.Empty;
					focusControl = this.SuplCodeText.ID;
// 管理番号K27057 From
					CustomItem.SetMasterUse(CommonData, CustomItemPanel);
// 管理番号K27057 To
				}
			}
			else
			{
// 管理番号 B24264 From
				// 無効な仕入先の場合は雑コードフラグをOFF
				rowData.TempCodeFlg = "0";
// 管理番号 B24264 To
				SuplNameText.Text = string.Empty;
				SuplNameText.Enabled = false;

// 管理番号 B24264 From
//				AcTable.Visible = false;
//				setAcTableCondition(false);
//				setAcTableClear();
// 管理番号 B24264 To

// 管理番号 K25679 From
//// 管理番号 K16590 From
////				focusControl = this.SuplNameText.Enabled ? this.SuplNameText.ID : this.PuModeTypeList.Enabled ? this.PuModeTypeList.ID : this.SuplBillSlipNoText.ID;
//				focusControl = this.SuplNameText.Enabled ? this.SuplNameText.ID : this.DealDateText.Enabled ? this.DealDateText.ID : this.PuModeTypeList.Enabled ? this.PuModeTypeList.ID : this.SuplBillSlipNoText.ID;
//// 管理番号 K16590 To
					focusControl = this.SuplNameText.Enabled ? this.SuplNameText.ID : this.DealDateText.Enabled ? this.DealDateText.ID : this.PoAdminNoText.ID;
// 管理番号 K25679 To
				this.SuplCodeText.NextControlID = focusControl;
// 管理番号K27057 From
				CustomItem.SetMasterUse(CommonData, CustomItemPanel);
// 管理番号K27057 To
			}
			this.SuplNameText.Text = suplName;

			// 締日の取得
			SetCutOffDataInfo(sender, CutOffDateType.Now);
			lotDiff = true;

// 管理番号 B21172 From
			//// 検索ウィンドウから戻ってきたときは自コントロールにフォーカスを当てる
            //if(returnValue == "Supl")
            //{
            //    focusControl= this.SuplCodeText.ID;
            //}
// 管理番号 B21172 To

            FocusControl(focusControl, sender);

		}

// 管理番号 K24789 From
		private void DealDateText_TextChanged(object sender, EventArgs e)
		{
// 管理番号 B25845 From
			//本イベントとボタンイベントが連続した場合に、ボタン側の処理を止めるため、
			//明細行の項目更新時と更新と同様にフラグを立てる。
			dtlChangeFlg = true;
// 管理番号 B25845 To

			// 取引日を設定
			rowData.DealDate = DealDateText.Text.Trim();

			string compareDate = DateValidator.IsDate(PuDateText.Text) ? PuDateText.Text : todayDate;
			string dealDate = DateValidator.IsDate(DealDateText.Text) ? DealDateText.Text : todayDate;
// 管理番号 K25679 From
//			string focusControl = this.PuModeTypeList.Enabled ? this.PuModeTypeList.ID : this.SuplBillSlipNoText.ID;
			string focusControl = this.PoAdminNoText.ID;
// 管理番号 K25679 To

			// 明細行（登録済み行）の消費税率を再取得
			rowData.ReloadProdPrice(CommonData, CurCodeList.SelectedValue, SuplCodeText.Text.Trim(), this.CompanyCodeLength, DeptCodeText.Text, compareDate, double.Parse(curDigit), AmtRoundType, dealDate, "B");
			setDataGridProperty(rowData.Dt);

			// 合計の再設定
			setAmtTtl(true);

			clearNewControlValue();
			setNewControlCondition(true);

			if (returnValue.Length != 0)
			{
				OverRideFocus(returnValue);
			}
			else
			{
				FocusControl(focusControl, sender);
			}
		}
// 管理番号 K24789 To

		private void PuModeTypeList_SelectedIndexChanged(object sender,System.EventArgs e)
		{
			//IFに仕入形態をセット
// 管理番号K27058 From
//			rowData.PuModeType = this.PuModeTypeList.SelectedValue;
//			if(this.PuModeTypeList.SelectedValue == "4")	//預り
			rowData.PuModeType			= this.puModeType;
			rowData.PuModeTypeDtilCode	= this.puModeTypeDtilCode;
			if (this.puModeType == "4")	//預り
// 管理番号K27058 To
			{
				DeliTypeWRadio.Checked = true;
				DeliTypeDRadio.Checked = false;
				DeliType_CheckedChanged(DeliTypeWRadio, e);
			}

			//フォーカス制御（返品時は仕入参照）
// 管理番号K27058 From
//			this.RefPuText.Enabled = this.PuModeTypeList.SelectedValue == "2";
			this.RefPuText.Enabled = this.puModeType == "2";
// 管理番号K27058 To
			if (this.RefPuText.Enabled)
			{
				this.PuModeTypeList.NextControlID = this.RefPuText.ID;
			}
			else
			{
				this.PuModeTypeList.NextControlID = this.SuplBillSlipNoText.ID;
			}
			// 管理番号 B11840 From
			//			string focusControl = this.PuModeTypeList.NextControlID;
			// 管理番号 B11840 To

			//明細クリア（通常・返品・預かり）
			rowData.DeleteDetailAll();
			setDataGridProperty(rowData.Dt);
			setAmtTtl(false);
// 管理番号 B23588 From
			clearNewControlValue();
			setNewControlCondition(true);
// 管理番号 B23588 To
// 管理番号 K24285 From
			bool allowNegative = false;
			if (this.InpProdCodeText.Text.Length > 0)
			{
				//在庫管理しない商品
				if (this.inputRowStockAdminFlgHidden.Value == "0")
				{
					//発注・入荷参照しない、仕入形態が通常または返品の場合、マイナス数量を許可
					if (this.PoRefText.Text.Length == 0 && this.RcptRefText.Text.Length == 0 &&
// 管理番号K27058 From
//						(this.PuModeTypeList.SelectedValue == "1" || this.PuModeTypeList.SelectedValue == "2"))
						(this.puModeType == "1" || this.puModeType == "2"))
// 管理番号K27058 To
					{
						allowNegative = true;
					}
				}
			}
			this.InpPuQtText.AllowNegative = allowNegative;
// 管理番号 K24285 To

			// 管理番号 B11840 From
			//			if(returnValue == "PuModeType")
			//			{
			//				focusControl = this.PuModeTypeList.ID;
			//			}
			//
			//			FocusControl(focusControl);
// 管理番号K26528 From
//			FocusControl("PuModeTypeList", sender);
			OverRideFocus(this.RefPuText.ClientID);
// 管理番号K26528 To
			// 管理番号 B11840 To
		}

		private void EmpCodeText_TextChanged(object sender, System.EventArgs e)
		{
			string empCode = this.EmpCodeText.Text.Trim();
			string empShortName = string.Empty;
			string deptCode      = string.Empty;
			string deptShortName = string.Empty;
			//管理番号 B13502 From
			//			string focusControl = this.EmpCodeText.NextControlID;
			string focusControl = string.Empty;
			if(this.DeptCodeText.Enabled==true)
			{
				focusControl = this.EmpCodeText.NextControlID;
			}
			else
			{
				focusControl = this.DeptCodeText.NextControlID;
			}
			//管理番号 B13502 To
			//在庫管理部門変更対応-INSERT-START
			bool   isDeptChange  = false;
			//在庫管理部門変更対応-INSERT-END

			if (empCode.Length > 0)
			{
				if (Emp.IsExists(this.CommonData, empCode, out empShortName, false))
				{
// 管理番号 K25656 From
//					if (paramType != ParamCodeType.MOD && refType == RefCodeType.NONE)
					if (paramType != ParamCodeType.MOD && (refType == RefCodeType.NONE || refType == RefCodeType.COPY_PU))
// 管理番号 K25656 To
					{
						if (Dept.GetEmpDept(this.CommonData, empCode, out deptCode, out deptShortName))
						{
							//在庫管理部門変更対応-INSERT-START
							//部門に変更があるか判定
							isDeptChange  = (DeptCodeText.Text.Trim() != deptCode);
							//在庫管理部門変更対応-INSERT-END
// 管理番号 K25656 From
							//部門名称取得
							string compareDate   = DateValidator.IsDate(PuDateText.Text) ? PuDateText.Text : todayDate;
							string lowerDept = this.DisclosureUnitType == "D" ? this.UserDeptCode : string.Empty;
							Dept.IsExists(this.CommonData, deptCode, out deptShortName, compareDate, false, true, false, lowerDept, false, false);
// 管理番号 K25656 To
							this.DeptCodeText.Text  = deptCode;
							this.DeptNameLabel.Text = deptShortName;
							if (this.DeliTypeWRadio.Checked && this.WhCodeText.Text.Length == 0)
							{
								setPriorityWh(deptCode);
							}
						}
					}
				}
				else
				{
					focusControl = EmpCodeText.ID;
				}
			}

			this.EmpNameLabel.Text = empShortName;
			lotDiff = true;

			//在庫管理部門変更対応-INSERT-START
			if(isDeptChange)
			{
				//部門に変更があった場合リロード
// 管理番号 B24292 From
//				callResponseRedirect(deptCode);
				if(rowData.Dt.Rows.Count != 0)
				{
					callResponseRedirect(deptCode);
				}
//管理番号 B24732 From
				else
				{
					setApproval(deptCode);
// 管理番号B26565 From
//// 管理番号 K25667 From
//					// 部門の変更によってWF使用区分が変わる可能性があるため、セッションをクリアする（空のインスタンスで初期化する）
//					this.attachmentFiles = new CM.WF.IF_CM_WF_AttachmentFiles();
//// 管理番号 K25667 To
// 管理番号B26565 To
				}
//管理番号 B24732 To
// 管理番号 B24292 To
			}
			//在庫管理部門変更対応-INSERT-END
// 管理番号 K22217 From
               SessionRemove();
// 管理番号 K22217 To 
			// 検索ウィンドウから戻ってきたときは自コントロールにフォーカスを当てる
			if (returnValue == "Emp")
			{
				focusControl = EmpCodeText.ID;
			}
			FocusControl(focusControl, sender);
		}
		private void InputEmpCodeText_TextChanged(object sender, System.EventArgs e)
		{
			string inputEmpCode = this.InputEmpCodeText.Text.Trim();
			string inputEmpShortName = string.Empty;
			string focusControl = string.Empty;
			if (inputEmpCode.Length > 0)
			{
				if (Emp.IsExists(this.CommonData, inputEmpCode, out inputEmpShortName, false))
				{
					this.InputEmpNameLable.Text = inputEmpShortName;
					focusControl = this.InputEmpCodeText.NextControlID;
				}
				else
				{
					this.InputEmpNameLable.Test = string.Empty;
					focusControl = this.InputEmpCodeText.ID;
				}
			}
			FocusControl(focusControl, sender);
		}

		//管理番号 B24292 From

		//管理番号 B24292 コメント削除

		private void DeptCodeText_TextChanged(object sender, System.EventArgs e)
		{
			deptCodeChange(sender);
		}
		private void deptCodeChange(object sender)
		{
			string deptCode = DeptCodeText.Text.Trim();
			string deptShortName = string.Empty;
			string compareDate   = DateValidator.IsDate(PuDateText.Text) ? PuDateText.Text : todayDate;
			string focusControl = this.DeptCodeText.NextControlID;

			if (deptCode.Length > 0)
			{
				// 自部門権限時参照部門設定
				string lowerDept = this.DisclosureUnitType == "D" ? this.UserDeptCode : string.Empty;

				if (Dept.IsExists(this.CommonData, deptCode, out deptShortName, compareDate, false, true, false, lowerDept, false, false))
				{
//管理番号 B24732 From
//					// 承認対象伝票かどうかのチェック(セッションの部門コードから変更があれば伝票の部門コード)
//					setApproval(deptCode);
//管理番号 B24732 To
					if (this.DeliTypeWRadio.Checked && this.WhCodeText.Text.Length == 0)
					{
						setPriorityWh(deptCode);
					}
				}
				else
				{
					focusControl = this.DeptCodeText.ID;
				}
			}

			this.DeptNameLabel.Text = deptShortName;
			lotDiff = true;

			if(rowData.Dt.Rows.Count != 0)
			{
				callResponseRedirect(deptCode);
			}
//管理番号 B24732 From
			else
			{
			    // 承認対象伝票かどうかのチェック(セッションの部門コードから変更があれば伝票の部門コード)
			    setApproval(deptCode);
// 管理番号B26565 From
//// 管理番号 K25667 From
//				// 部門の変更によってWF使用区分が変わる可能性があるため、セッションをクリアする（空のインスタンスで初期化する）
//				this.attachmentFiles = new CM.WF.IF_CM_WF_AttachmentFiles();
//// 管理番号 K25667 To
// 管理番号B26565 To
			}
//管理番号 B24732 To
			// 検索ウィンドウから戻ってきたときは自コントロールにフォーカスを当てる
			if (returnValue == "Dept")
			{
				focusControl = this.DeptCodeText.ID;
			}

			FocusControl(focusControl, sender);
		}
//管理番号 B24292 To
		private void ProjCodeText_TextChanged(object sender, System.EventArgs e)
		{
			string projCode = ProjCodeText.Text.Trim();
			string projShortName = string.Empty;
			string compareDate = DateValidator.IsDate(PuDateText.Text) ? PuDateText.Text : todayDate;
			if (projCode.Length > 0)
			{
// 管理番号 B21324 From
//				if (Proj.IsExists(this.CommonData, projCode, this.ProjectCodeLength, out projShortName, todayDate, DeptCodeText.Text))
				if (Proj.IsExists(this.CommonData, projCode, this.ProjectCodeLength, out projShortName, compareDate, DeptCodeText.Text))
// 管理番号 B21324 To
				{
					// 管理番号 B13877 From
					rowData.DivideProjCode(projCode, this.ProjectCodeLength);
					// 管理番号 B13877 To
					if(this.WhCodeText.Enabled)
					{
						FocusControl(this.WhCodeText.ID, sender);
					}
					else
					{
						FocusControl(this.DeliCustCodeText.ID, sender);
					}
				}
				else
				{
					// 管理番号 B13877 From
					rowData.ProjCode = rowData.ProjSbno = string.Empty;
					// 管理番号 B13877 To
					FocusControl(ProjCodeText.ID, sender);
				}
			}
				// 管理番号 B13877 From
			else
			{
				rowData.ProjCode = rowData.ProjSbno = string.Empty;
			}
// 管理番号 B24749 From
			callProjResponseRedirect(sender, projCode);
// 管理番号 B24749 To
			// 管理番号 B13877 To
			ProjNameLabel.Text = projShortName;
			lotDiff = true;
		}

		private void DeliType_CheckedChanged(object sender, System.EventArgs e)
		{
			string focusControl = string.Empty;

			bool isWhSelect = this.DeliTypeWRadio.Checked;

			this.WhCodeText.Enabled				= isWhSelect;
			this.DeliCustCodeText.Enabled		= !isWhSelect;
			this.DeliPlaceNameText.Enabled	= !isWhSelect;

			if (isWhSelect)
			{
// 管理番号 B22309 From
//				setPriorityWh(this.UserDeptCode);
				// 納入区分変更時は画面の部門コードから優先倉庫を取得
				setPriorityWh(this.DeptCodeText.Text);
// 管理番号 B22309 To

				DeliCustCodeText.Text			= string.Empty;
				DeliCustNameLabel.Text			= string.Empty;
// 管理番号K27062 From
//				DeliPlaceCodeList.Enabled		= false;
//				DeliPlaceCodeList.Items.Clear();
//				DeliPlaceNameText.Text			= string.Empty;
				DeliPlaceCodeText.Enabled		= false;
				DeliPlaceCodeText.Text			= string.Empty;
				DeliPlaceNameText.Enabled		= false;
				DeliPlaceNameText.Text			= string.Empty;
// 管理番号K27062 To

				if(this.InpProdCodeText.Text.Length > 0  && this.InpStockAdminFlg.Text=="1")
				{
					this.InpWhCodeText.Text       = this.WhCodeText.Text;
					this.InpWhShortNameLabel.Text = this.WhShortNameLabel.Text;
				}

				focusControl = this.WhCodeText.ID;
			}
			else
			{
				WhCodeText.Text					= string.Empty;
				WhShortNameLabel.Text			= string.Empty;

				clearPlace();

				if(this.InpProdCodeText.Text.Trim().Length > 0 && this.InpStockAdminFlg.Text=="1")
				{
					this.InpWhCodeText.Text       = directWhCode;
					setWhName(this.InpWhShortNameLabel, directWhCode, false);
				}
				focusControl = this.DeliCustCodeText.ID;
			}

			//新規行のロットを制御
			SetLotInfo(false, rowData.NewRowLineID);
// 管理番号 K25322 From
			// 新規行のEnabled制御
			rowCtl = this.GetControls(null);
			string prodName = string.Empty;
			bool IsExists = Prod.IsExists(this.CommonData, rowCtl.ProdCodeText.Text, "PO", string.Empty, out prodName);
			SetRowControlCondition(rowCtl, IsExists);
// 管理番号 K25322 To
			lotDiff = true;
			FocusControl(focusControl);
		}

		private void DeliCustCodeText_TextChanged(object sender, System.EventArgs e)
		{
			string deliCustCode	= this.DeliCustCodeText.Text.Trim();
			string deliCustName = string.Empty;
			string focusControl  = string.Empty;
			bool  isExists = true;
// 管理番号 B23974 From
			string compareDate = DateValidator.IsDate(PuDateText.Text.Trim()) ? PuDateText.Text.Trim() : todayDate;
// 管理番号 B23974 To

			if (deliCustCode.Length > 0)
			{
// 管理番号 B23974 From
//				isExists = Cust.IsExists(this.CommonData, deliCustCode, this.CompanyCodeLength, out deliCustName);
				isExists = Cust.IsExists(this.CommonData, deliCustCode, this.CompanyCodeLength, out deliCustName, compareDate);
// 管理番号 B23974 To
				if (!isExists)
				{
// 					setMessageLabel(HtmlMessage(AllegroMessage.S20005("納入先"), MessageLevel.Warning)); //K24546
					setMessageLabel(HtmlMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001673")), MessageLevel.Warning));
					focusControl = this.DeliCustCodeText.ID;
				}
			}

			//受渡場所
// 管理番号K27062 From
//			setDeliPlaceDropDown(isExists ? deliCustCode : string.Empty);
			this.DeliPlaceCodeText.Text = "00";
			setDeliPlaceTextBox(isExists ? deliCustCode : string.Empty);
// 管理番号K27062 To
			setDeliPlace();

// 管理番号B27587 From
////管理番号 B23282 From
////		//次フォーカス(タブ手前)
////		focusControl = getNextFocusControlID(isExists, this.DeliCustCodeText.ID);
//			//明細編集行にフォーカスは遷移させず、新規入力行または更新ボタンへ遷移させる
//			if (DataGrid1.EditItemIndex==-1 && this.InpPanel.Visible == true)
//			{
//				focusControl = this.InpProdCodeText.ID;
//			}
//			else
//			{
//				focusControl = this.UpdateButton.ID;
//			}
////管理番号 B23282 To

			if (focusControl == String.Empty)
			{
				// 基本タブが選択されている場合
				if (TabSelector1.SelectedIndex == 0)
				{
					focusControl = this.PuNameText.ID;	//件名にフォーカスを当てる
				}
				// 詳細タブが選択されている場合
				else
				{
					// 明細行が新規モードの場合
					if (DataGrid1.EditItemIndex == -1 && this.InpPanel.Visible == true)
					{
						focusControl = this.InpProdCodeText.ID;	// 商品コードにフォーカスを当てる
					}
					else
					{
						focusControl = this.UpdateButton.ID;	// 更新ボタンにフォーカスを当てる
					}
				}
			}
// 管理番号B27587 To
			this.DeliCustNameLabel.Text = deliCustName;
			lotDiff = true;

			// 検索ウィンドウから戻ってきたときは自コントロールにフォーカスを当てる
			if (returnValue == "DeliCust")
			{
				focusControl = this.DeliCustCodeText.ID;
			}

			FocusControl(focusControl, sender);
		}

		private void WhCodeText_TextChanged(object sender, System.EventArgs e)
		{
			string focusControl = string.Empty;
			bool result = setWhName(WhShortNameLabel, WhCodeText.Text.Trim(), true);

			if (result)
			{
				setWhPlace(WhCodeText.Text.Trim());
// 管理番号B27587 From
////管理番号 B23282 From
////				//次フォーカス(タブ手前)
////				focusControl = getNextFocusControlID(result, this.WhCodeText.ID);
//				//明細編集行にフォーカスは遷移させず、新規入力行または更新ボタンへ遷移させる
//				if (DataGrid1.EditItemIndex==-1 && this.InpPanel.Visible == true)
//				{
//					focusControl = this.InpProdCodeText.ID;
//				}
//				else
//				{
//					focusControl = this.UpdateButton.ID;
//				}
////管理番号 B23282 To

				// 基本タブが選択されている場合
				if (TabSelector1.SelectedIndex == 0)
				{
					focusControl = this.PuNameText.ID;	// 件名にフォーカスを当てる
				}
				// 詳細タブが選択されている場合
				else
				{
					// 明細行が新規モードの場合
					if (DataGrid1.EditItemIndex == -1 && this.InpPanel.Visible == true)
					{
						focusControl = this.InpProdCodeText.ID;	// 商品コードにフォーカスを当てる
					}
					else
					{
						focusControl = this.UpdateButton.ID;	// 更新ボタンにフォーカスを当てる
					}
				}
// 管理番号B27587 To
				//障害番号2194 INSERT-START
				if(InpProdCodeText.Text.Length > 0 && InpStockAdminFlg.Text == "1")
				{
					this.InpWhCodeText.Text = this.WhCodeText.Text;
					setWhName(InpWhShortNameLabel, WhCodeText.Text, false);
				}
				//障害番号2194 INSERT-END
			}
			else
			{
				focusControl = this.WhCodeText.ID;
			}

			lotDiff = true;

			// 検索ウィンドウから戻ってきたときは自コントロールにフォーカスを当てる
			if (returnValue == "WhHeader")
			{
				focusControl = this.WhCodeText.ID;
			}
			FocusControl(focusControl, sender);
		}

// 管理番号K27062 From
//		private void DeliPlaceCodeList_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			setDeliPlace();
//			if (returnValue == "DeliPlace")
//			{
//// 管理番号K26528 From
////				// リストアイテムチェンジときは自コントロールにフォーカスを当てる
////				FocusControl(DeliPlaceCodeList.ID);
//				FocusControl(this.DeliPlaceNameText.ClientID);
//// 管理番号K26528 To
//			}
//			else
//			{
//				FocusControl(DeliPlaceCodeList.NextControlID);
//			}
//		}
		private void DeliPlaceCodeText_TextChanged(object sender, System.EventArgs e)
		{
			if (DeliPlaceCodeText.Text.Length > 0)
			{
				if (DeliPlace.IsExists(CommonData, DeliCustCodeText.Text.Trim(), this.CompanyCodeLength, DeliPlaceCodeText.Text.Trim()))
				{
					setDeliPlace();
					FocusControl(this.DeliPlaceNameText.ID, sender);
				}
				else
				{
					clearDeliPlaceInfo();
					// 受渡場所
					setMessageLabel(HtmlMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001000")), MessageLevel.Warning));
					FocusControl(this.DeliPlaceCodeText.ID, sender);
				}
			}
			else
			{
				clearDeliPlaceInfo();
				FocusControl(this.DeliPlaceNameText.ID, sender);
			}
			lotDiff = true;
		}

		// 受渡場所に関連する情報をクリア
		private void clearDeliPlaceInfo()
		{
			this.DeliPlaceNameText.Text		= string.Empty;	// 受渡場所名
			this.ZipText.Text				= string.Empty;	// 郵便番号
			this.StateText.Text				= string.Empty;	// 都道府県名
			this.CityText.Text				= string.Empty;	// 市区町村名
			this.Address1Text.Text			= string.Empty;	// 町域名
			this.Address2Text.Text			= string.Empty;	// ビル名
			this.PhoneText.Text				= string.Empty;	// 電話番号
			this.FaxText.Text				= string.Empty;	// FAX番号
			this.DeliUserNameText.Text		= string.Empty;	// 担当者名
		}
// 管理番号K27062 To

		//郵便番号入力時動作
		private void ZipText_TextChanged(object sender, System.EventArgs e)
		{
			string zipCode ;
			ZipDic.ZipClass zipDic = new ZipDic.ZipClassClass();
			zipCode = ZipText.Text.Trim();
			zipCode = zipCode.Replace("-","");
			// 国コードが日本の時のみ郵便番号検索
			//			if(zipCode.Length!=0 && DeliPlaceCountryCode.Text == this.JapanCountryCode)
			//			{
//管理番号 B16212 From
			this.StateText.Text = string.Empty;
			this.CityText.Text = string.Empty;
			this.Address1Text.Text = string.Empty;
			this.Address2Text.Text = string.Empty;

//			if(zipCode.Length!=0 && StateText.Text.Trim().Length == 0 && CityText.Text.Trim().Length == 0 && Address1Text.Text.Trim().Length == 0)
			if(zipCode.Length!=0)
//管理番号 B16212 To
			{
				//都道府県、市町村、町域名がすべてブランクの場合
				string state = string.Empty;
				state = (string) zipDic.GetKen(zipCode);
				if(state.Length != 0)
				{
					//対象データありの場合：　値を戻し、フォーカスを町域名に移す
					StateText.Text = state;
					CityText.Text =  (string) zipDic.GetAddress(zipCode);
					Address1Text.Text = (string) zipDic.GetAddress2(zipCode);
					FocusControl("Address1Text",sender);
				}
				else
				{
					//対象データなしの場合：　そのまま都道府県に抜ける
					FocusControl("StateText",sender);
				}
			}
			else
			{
				//すでに入力項目がある場合：　そのまま都道府県に抜ける
				FocusControl("StateText",sender);
			}
			//			}
			//			else
			//			{
			//				//国コードが日本では無い場合：　そのまま都道府県に抜ける
			//				FocusControl("StateText",sender);
			//			}
		}

		private void DtTypeList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string selected = this.DtTypeList.SelectedValue;

			if (selected == "L")
			{
				setDtData(false);
				//setCutoffDate("2");
				SetCutOffDataInfo(sender, CutOffDateType.Now);
			}
			else
			{
				this.CutoffDateText.Text = this.PuDateText.Text;
				if(rowData.PoNo.Length != 0)
				{
					this.Dt1SttlMthdCodeList.SelectedValue	= rowData.Dt1SttlMthdCode;
					this.Dt1BasisAmtText.Text				= rowData.Dt1BasisAmt;
					this.Dt2SttlMthdCodeList.SelectedValue	= rowData.Dt2SttlMthdCode;
					this.Dt2RatioText.Text					= rowData.Dt2Ratio;
					this.Dt3SttlMthdCodeList.SelectedValue	= rowData.Dt3SttlMthdCode;
					this.DtSightText.Text					= rowData.DtSight;
					//setCutoffDate("2");
// 管理番号 B23547 From
//					SetCutOffDataInfo(sender, CutOffDateType.Now);
// 管理番号 B23547 To
				}
// 管理番号 B23547 From
				SetCutOffDataInfo(sender, CutOffDateType.Now);
// 管理番号 B23547 To
			}

			setDtControlCondition(selected == "E");

			OverRideFocus(new StringBuilder(DtTypeList.ID).Append("_").Append(DtTypeList.SelectedIndex.ToString()).ToString());
		}

		private void Dt1SttlMthdCodeList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			setDtControlCondition(DtTypeList.SelectedValue == "E");
			OverRideFocus(Dt1BasisAmtText.ClientID);
		}
		private void Dt2SttlMthdCodeList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			setDtControlCondition(DtTypeList.SelectedValue == "E");
			OverRideFocus(Dt3SttlMthdCodeList.ClientID);
		}
		private void Dt3SttlMthdCodeList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			setDtControlCondition(DtTypeList.SelectedValue == "E");
			if (DtSightText.Enabled)
			{
				OverRideFocus(DtSightText.ClientID);
			}
			else if (CutoffDateText.Enabled)
			{
				OverRideFocus(CutoffDateText.ClientID);
			}
			else
			{
				OverRideFocus(PymtPlanDateText.ClientID);
			}
		}
		private void CutoffDateBackButton_Click(object sender, EventArgs e)
		{
			SetCutOffDataInfo(sender, CutOffDateType.Previous);
			FocusControl(CutoffDateBackButton.ID);
		}

		private void CutoffDateAdvanceButton_Click(object sender, EventArgs e)
		{
			SetCutOffDataInfo(sender, CutOffDateType.Next);
			FocusControl(CutoffDateAdvanceButton.ID);
		}

// 管理番号 B24264 コメント削除
// 管理番号 B20392 コメント削除

		private void RemarksCodeText_TextChanged(object sender, System.EventArgs e)
		{
			if (Request.Form["__EVENTTARGET"] == RemarksCodeText.UniqueID)
			{
				string remarks		= string.Empty;
				string focus		= this.RemarksText.ID;
				string remarksCode	= this.RemarksCodeText.Text.Trim();

				if (remarksCode.Length > 0)
				{
// 管理番号K27058 From
//					if (this.PuModeTypeList.SelectedValue != "2")
					if (this.puModeType != "2")
// 管理番号K27058 To
					{
						remarks = Remarks.GetRemarks(this.CommonData, pageCode, remarksCode);
					}
					else
					{
						remarks = ReturnReason.GetReturnReason(this.CommonData, remarksCode);
					}

					if (remarks.Length > 0)
					{
						RemarksText.Text = remarks;
					}
				}

				FocusControl(focus , sender);
			}
		}
// 管理番号K26528 From
// 不要なロジックのため削除
//		//タブの手前フォーカス
//		private string getNextFocusControlID(bool isExists, string senderId)
//		{
//			if (!isExists) return senderId;
//
//			string focusControl = senderId;
//
//			switch(this.TabSelector1.SelectedIndex)
//			{
//				case 0:
//					focusControl = this.PuNameText.ID;
//					break;
//				case 1:
//
//					if (this.DataGrid1.EditItemIndex!=-1)
//					{
//						CustomTextBox prodCode   = (CustomTextBox)this.DataGrid1.Items[this.DataGrid1.EditItemIndex].FindControl("EditProdCodeText");
//						CustomTextBox prodName   = (CustomTextBox)this.DataGrid1.Items[this.DataGrid1.EditItemIndex].FindControl("EditProdNameText");
//						CustomTextBox whCode     = (CustomTextBox)this.DataGrid1.Items[this.DataGrid1.EditItemIndex].FindControl("EditWhCodeText");
//						NumberBox puQt           = (NumberBox)this.DataGrid1.Items[this.DataGrid1.EditItemIndex].FindControl("EditPuQtText");
//						NumberBox puPrice        = (NumberBox)this.DataGrid1.Items[this.DataGrid1.EditItemIndex].FindControl("EditPuPriceText");
//						if (prodCode.Enabled)
//						{
//							focusControl = prodCode.UniqueID;
//						}
//						else if (prodName.Enabled)
//						{
//							focusControl = prodName.UniqueID;
//						}
//						else if (whCode.Enabled)
//						{
//							focusControl = whCode.UniqueID;
//						}
//						else if (puQt.Enabled)
//						{
//							focusControl = puQt.UniqueID;
//						}
//						else if (puPrice.Enabled)
//						{
//							focusControl = puPrice.UniqueID;
//						}
//						else if (this.UpdateButton.Enabled)
//						{
//							focusControl = this.UpdateButton.ID;
//						}
//						else
//						{
//							focusControl = this.CloseButton.ID;
//						}
//					}
//					else
//					{
//// 管理番号 B23172 From
////						if (this.InpProdCodeText.Enabled)
//						if (this.InpProdCodeText.Enabled && this.InpPanel.Visible != false)
//// 管理番号 B23172 To
//						{
//							focusControl = this.InpProdCodeText.ID;
//						}
//						else if (this.RegistButton.Enabled)
//						{
//							focusControl = this.RegistButton.ID;
//						}
//						else if (this.UpdateButton.Enabled)
//						{
//							focusControl = this.UpdateButton.ID;
//						}
//						else
//						{
//							focusControl = this.CloseButton.ID;
//						}
//					}
//					break;
//			}
//
//			return focusControl;
//		}
// 管理番号K26528 To

		//管理番号 B13502 From
		/// <summary>
		/// 通貨プルダウンのチェンジ
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void CurCodeList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CurCodeListChanged();
// 管理番号K26528 From
//			OverRideFocus("CurCodeList");
			OverRideFocus(this.EmpCodeText.ClientID);
// 管理番号K26528 To
		}
		//管理番号 B13502 To

		//管理番号 B13502 From
		/// <summary>
		/// 為替区分変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExchangeTypeList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//為替区分変更時
			ExchangeTypeListChanged();

			if (returnValue == "ExchangeType")
			{
// 管理番号K26528 From
//				OverRideFocus(this.ExchangeTypeList.ID);
				OverRideFocus(this.ExchangeRezNoText.ClientID);
// 管理番号K26528 To
			}
		}

		/// <summary>
		/// 為替予約番号変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void ExchangeRezNoText_TextChanged(object sender, System.EventArgs e)
		{
// 管理番号 B17665 From
//			ExchangeRezNoTextChanged();
			ExchangeRezNoTextChanged(sender);
// 管理番号 B17665 To
		}

		/// <summary>
		/// レート変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void RateText_TextChanged(object sender, System.EventArgs e)
		{
// 管理番号 B15394 From
//			string date		= DateValidator.IsDate(PuDateText.Text.Trim()) ? PuDateText.Text.Trim() : todayDate;
//			string rate = IF.IFBase.ValidateDecimalString(this.RateText.Text.Trim(), false, 6, 2);
//			if(rate=="0")
//			{
//				//RateText.Text = rowData.Rate;
//				setMessageLabel(HtmlMessage(AllegroMessage.S10060("レート"), MessageLevel.Warning));
//				FocusControl(this.RateText.ID, sender);
//			}
//			else if(rate.Length==0)
//			{
//// 管理番号 B14549 From
////				RateText.Text = rowData.Rate;
//				if(rowData.Rate.Length != 0)
//				{
//					RateText.Text = Common.FormatAmt(decimal.Parse(rowData.Rate), curDigit, false, "1");
//				}
//				else
//				{
//					RateText.Text = string.Empty;
//				}
//// 管理番号 B14549 To
//				setMessageLabel(HtmlMessage(AllegroMessage.S10006("レート"), MessageLevel.Warning));
//				FocusControl(this.RateText.ID, sender);
//			}
//			else
//			{
//				//ボディ：詳細タブ：レート にボディ：基本タブ：レートの値を設定する。
//// 管理番号 B14549 From
////				RateLabel.Text =rowData.Rate = RateText.Text;
//				RateLabel.Text = rowData.Rate = Common.FormatAmt(decimal.Parse(RateText.Text), curDigit, false, "1");
//// 管理番号 B14549 To
//				//発注金額合計、課税対象額計、消費税合計、総合計を再計算する。
//				setAmtTtl(true);
//				OverRideFocus(this.RateText.NextControlID);
//			}
//
//// 管理番号 B14340 From
//			if (returnValue == "RateText")	//検索ウィンドウの戻り
//			{
//				OverRideFocus(this.RateText.ClientID);
//			}
//// 管理番号 B14340 To
//// 管理番号 B15412 From
//			if (returnValue == "ExchangeRezNoText")	//検索ウィンドウの戻り
//			{
//				OverRideFocus(this.ExchangeRezNoText.ClientID);
//			}
//// 管理番号 B15412 To
			decimal rate = 0M;
			if (RateText.Text.Trim().Length != 0)
			{
				rate = decimal.Parse(RateText.Text.Trim());
				if (rate == 0M)
				{
// 					setMessageLabel(HtmlMessage(AllegroMessage.S10060("レート"), MessageLevel.Warning)); //K24546
					setMessageLabel(HtmlMessage(AllegroMessage.S10060(MultiLanguage.Get("SC_CS000271")), MessageLevel.Warning));
					FocusControl(this.RateText.ID, sender);
				}
// 管理番号 B18516 From
//				RateLabel.Text = Common.FormatAmt(rate, curDigit, false, "1");
				RateLabel.Text	= rate.ToString("#0.00");
				RateText.Text	= rate.ToString("#0.00");
// 管理番号 B18516 To
			}
			else
			{
				RateLabel.Text = string.Empty;
			}

			rowData.Rate = (RateText.Text.Trim().Length != 0) ? RateText.Text.Trim() : "1.00";
			setAmtTtl(true);
// 管理番号 B23588 From
			setDataGridProperty(rowData.Dt);
			clearNewControlValue();
			setNewControlCondition(true);
// 管理番号 B23588 To

			if (rate != 0M || RateText.Text.Trim().Length == 0)
			{
// 管理番号 B24264 From
//				if (this.SuplFormalNameText.Visible)
//				{
//					OverRideFocus(this.SuplFormalNameText.ID);
//				}
//				else
//				{
// 管理番号 B24264 To

// 管理番号K27062 From
//				if(this.DeliPlaceCodeList.Enabled ==true)
//				{
//					OverRideFocus(this.DeliPlaceCodeList.ID);
//				}
				if (this.DeliPlaceCodeText.Enabled == true)
				{
					OverRideFocus(this.DeliPlaceCodeText.ID);
				}
// 管理番号K27062 To
				else
				{
					OverRideFocus(this.DeliPlaceNameText.ID);
				}
// 管理番号 B24264 From
//					}
// 管理番号 B24264 To
				if (returnValue == "RateText")	//検索ウィンドウの戻り
				{
					OverRideFocus(this.RateText.ClientID);
				}
				else if (returnValue == "ExchangeRezNoText")	//検索ウィンドウの戻り
				{
// 管理番号 B21594 From
//					OverRideFocus(this.ExchangeRezNoText.ClientID);
					if (this.ExchangeRezNoText.Enabled)
					{
						OverRideFocus(this.ExchangeRezNoText.ClientID);
					}
					else
					{
						OverRideFocus(this.RateText.ClientID);
					}
				}
// 管理番号 B21594 To
			}
// 管理番号 B15394 To
		}
		//管理番号 B13502 To
		#endregion

		#region イベントコントロール(明細/新規行)
		protected void ProdCode_TextChanged(object sender,EventArgs e)
		{
			bool IsExists	= false;
			bool IsPrice	= false;
			int prodState	= 99;

			CustomTextBox ProdCodeText = (CustomTextBox) sender;
			string prodCode		= ProdCodeText.Text.Trim();
			string prodName		= string.Empty;
// 管理番号K26528 From
//			string focusControl	= ProdCodeText.UniqueID;
			string focusControl	= ProdCodeText.ClientID;
// 管理番号K26528 To

			DataGridItem gItem = null;
			if (ProdCodeText.UniqueID != this.InpProdCodeText.UniqueID)
			{
				gItem = (DataGridItem) ProdCodeText.Parent.Parent;
			}
			rowCtl = GetControls(gItem);


			//単価を初期化
			rowCtl.PuPriceText.Text = string.Empty;

// 管理番号 B18058 From
			//行挿入時には金額をゼロ表示する
			if(!insertFlg)
			{
// 管理番号 B18058 To
				rowCtl.PuMoneyLabel.Text = string.Empty;
// 管理番号 B18058 From
			}
			else
			{
				rowCtl.PuMoneyLabel.Text = "0";
				rowCtl.PuMoneyLabel.Text = Common.FormatAmt(decimal.Parse(rowCtl.PuMoneyLabel.Text), curDigit, false, "1");
			}
// 管理番号 B18058 To

			//存在チェック
			prodState = -1;
// 管理番号K27058 From
//			if (this.PuModeTypeList.SelectedValue != "4")
			if (this.puModeType != "4")
// 管理番号K27058 To
			{
				IsExists = Prod.IsExists(this.CommonData, prodCode, "PO", string.Empty, out prodName);
			}
			else
			{
// 管理番号B27043 From
//				IsExists = Prod.IsExists(this.CommonData, prodCode, "STK", string.Empty, out prodName);
				IsExists = Prod.IsExists(this.CommonData, prodCode, "PO", string.Empty, out prodName)
					&& (Prod.GetStockAdminFlg(this.CommonData, prodCode) == "1");
// 管理番号B27043 To
			}

			if (IsExists)
			{
				setProdDropDown(prodCode, rowCtl.ProdSpec1List, rowCtl.ProdSpec2List, rowCtl.UnitList);

				//価格取得
				IsPrice = SetProdPrice(sender, rowCtl);

				//仕入で入力可能は通常商品のみ
				if (rowCtl.ProdType.Text == "0")
				{
					if (!IsPrice)
					{
						rowCtl.ProdPuNameText.Text = prodName;
						prodState = 1;
					}
					else
					{
						prodState = rowCtl.CtaxRate.Text.Length > 0 ? 0 : 1;
					}
				}
				else
				{
					prodState = -2;
				}
			}
// 管理番号 B18058 From
			else
			{
				// 商品が存在しない場合税込み表示を消す
				rowCtl.CtaxCalcTypeLabel.Text = string.Empty;
			}
// 管理番号 B18058 To

			switch (prodState)
			{
				case 0:	//商品あり、価格あり
				case 1:	//商品あり、価格なし
					//デフォルト倉庫
					if(this.DeliTypeWRadio.Checked)
					{
						rowCtl.WhCodeText.Text       = this.WhCodeText.Text;
						rowCtl.WhNameLabel.Text = this.WhShortNameLabel.Text;
					}
					else
					{
						rowCtl.WhCodeText.Text     = directWhCode;
						setWhName(rowCtl.WhNameLabel, directWhCode, false);
					}

					SetRowControlCondition(rowCtl, true);
					focusControl = getProdCodeChengedRowFocusControl(rowCtl);
					break;
				case -1: //商品なし
				case -2: //仕入では入力不可
					if (ProdCodeText.Text.Trim().Length !=0 )
					{
// 						setMessageLabel(HtmlMessage(AllegroMessage.S20005("商品コード"), MessageLevel.Warning)); //K24546
						setMessageLabel(HtmlMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001158")), MessageLevel.Warning));
					}
					rowCtl.ProdPuNameText.Text = string.Empty;
					rowCtl.WhCodeText.Text		  = string.Empty;
					rowCtl.WhNameLabel.Text		  = string.Empty;

					setProdDropDown(string.Empty, rowCtl.ProdSpec1List, rowCtl.ProdSpec2List, rowCtl.UnitList);
					SetRowControlCondition(rowCtl, false);

					rowCtl.ProdType.Text		= string.Empty;
					rowCtl.DispControlType.Text	= string.Empty;
					rowCtl.LotAdminFlg.Text		= string.Empty;
					rowCtl.StockAdminFlg.Text	= string.Empty;
					rowCtl.CtaxCalcTypeLabel.Text	= string.Empty;
// 管理番号 K24789 From
//					rowCtl.CtaxCalcType.Text	= string.Empty;
//					rowCtl.CtaxRateCode.Text	= string.Empty;
// 管理番号 K24789 To
					rowCtl.AllowProdName.Text	= "1";
// 管理番号 K24789 From
					rowCtl.CtaxCalcTypeHdn.Value	= string.Empty;
					rowCtl.CtaxRateCodeHdn.Value	= string.Empty;
					rowCtl.CtaxTypeCodeHdn.Value	= string.Empty;
					rowCtl.TaxInfoChgFlgHdn.Value	= "0";
					//img/SC_c1_ctax_off.gif
					rowCtl.TaxInfoButton.CssClass = "tiny";
// 管理番号 K24789 To
					break;
			}

			//ロット制御
			SetLotInfo(false, rowCtl.PuLineId);

// 管理番号K26528 From
//			if (rowCtl.Inp=="1")
//			{
//				ScrollBottom();
//			}
//			else
//			{
//				ScrollRow(rowCtl.ProdCodeText.ClientID);
//			}
// 管理番号K26528 To
			// 検索ウィンドウから戻ってきたときは自コントロールにフォーカスを当てる
			if(returnValue == "Prod")
			{
// 管理番号K26528 From
//				FocusControl(rowCtl.ProdCodeText.UniqueID, sender);
				FocusControl(rowCtl.ProdCodeText.ClientID, sender);
// 管理番号K26528 To
			}
			else
			{
				FocusControl(focusControl, sender);
			}
			dtlChangeFlg = true;
// 管理番号K27057 From
			if (rowCtl.Inp != "1")
			{
				rowCtl.CustomItemPanel.SetNextElement(rowCtl.UpdateButton.Enabled ? rowCtl.UpdateButton.ClientID : UpdateButton.ID);
			}
			if (prodState < 0)
			{
				CustomItem.SetMasterUse(CommonData, rowCtl.CustomItemPanel);
			}
			else
			{
				CustomItem.SetMasterUse(CommonData, rowCtl.CustomItemPanel, ProdCodeText.Text);
			}
// 管理番号K27057 To
		}

		protected void ProdSpec1List_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CustomDropDownList prodSpec1List = (CustomDropDownList) sender;
			string prodCode		= string.Empty;
			string spec1Code	= string.Empty;
// 管理番号K26528 From
//			string focusControl	= string.Empty;
// 管理番号K26528 To

			DataGridItem gItem	= null;
			if (prodSpec1List.UniqueID != this.InpProdSpec1List.UniqueID)
			{
				gItem = (DataGridItem) ((CustomDropDownList) sender).Parent.Parent.Parent;
			}
			rowCtl = GetControls(gItem);

			Spec.SetDataSource2(rowCtl.ProdSpec2List, rowCtl.ProdCodeText.Text.Trim(), rowCtl.ProdSpec1List.SelectedValue, this.CommonData);
			rowCtl.ProdSpec2List.DataBind();

// 管理番号K26528 From
//			focusControl = rowCtl.ProdCodeText.UniqueID;
//			if (SetProdPrice(sender, rowCtl))
//			{
//				focusControl = rowCtl.ProdSpec1List.UniqueID;
//			}
			SetProdPrice(sender, rowCtl);
// 管理番号K26528 To

			//Enabled制御
			SetRowControlCondition(rowCtl, true);

			//ロット制御
			SetLotInfo(false, rowCtl.PuLineId);

// 管理番号K26528 From
//			if (rowCtl.Inp=="1")
//			{
//				ScrollBottom();
//			}
//			else
//			{
//				ScrollRow(rowCtl.ProdCodeText.ClientID);
//			}
// 管理番号K26528 To
			// 検索ウィンドウから戻ってきたときは自コントロールにフォーカスを当てる
			if(returnValue == "ProdSpec1")
			{
// 管理番号K26528 From
//				FocusControl(rowCtl.ProdSpec1List.UniqueID);
				FocusControl(rowCtl.ProdSpec1List.ClientID);
// 管理番号K26528 To
			}
			else
			{
// 管理番号K26528 From
//				FocusControl(focusControl);
				FocusControl(this.ProductSpecUseType == "2" ? rowCtl.ProdSpec2List.ClientID : rowCtl.WhCodeText.ClientID, sender);
// 管理番号K26528 To
			}
			dtlChangeFlg = true;
		}
		protected void ProdSpec2List_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CustomDropDownList ProdSpec2List = (CustomDropDownList) sender;
// 管理番号K26528 From
//			string focusControl = string.Empty;
// 管理番号K26528 To

			DataGridItem gItem = null;
			if (ProdSpec2List.UniqueID != this.InpProdSpec2List.UniqueID)
			{
				gItem = (DataGridItem) ((CustomDropDownList) sender).Parent.Parent.Parent;
			}
			rowCtl = GetControls(gItem);
// 管理番号K26528 From
//			focusControl = rowCtl.ProdCodeText.UniqueID;
//			if (SetProdPrice(sender, rowCtl))
//			{
//				focusControl = rowCtl.ProdSpec2List.UniqueID;
//			}
			SetProdPrice(sender, rowCtl);
// 管理番号K26528 To

			//Enabled制御
			SetRowControlCondition(rowCtl, true);

			//ロット制御
			SetLotInfo(false, rowCtl.PuLineId);

// 管理番号K26528 From
//			if (rowCtl.Inp=="1")
//			{
//				ScrollBottom();
//			}
//			else
//			{
//				ScrollRow(rowCtl.ProdCodeText.ClientID);
//			}
// 管理番号K26528 To

			// 検索ウィンドウから戻ってきたときは自コントロールにフォーカスを当てる
			if(returnValue == "ProdSpec2")
			{
// 管理番号K26528 From
//				FocusControl(rowCtl.ProdSpec2List.UniqueID);
				FocusControl(rowCtl.ProdSpec2List.ClientID);
// 管理番号K26528 To
			}
			else
			{
// 管理番号K26528 From
//				FocusControl(focusControl);
				FocusControl(rowCtl.WhCodeText.ClientID, sender);
// 管理番号K26528 To
			}
			dtlChangeFlg = true;
		}

		protected void RowWhCodeText_TextChanged(object sender, System.EventArgs e)
		{
			CustomTextBox WhCodeText	= (CustomTextBox) sender ;
			string appendedIDPart		= WhCodeText.AppendedIDPart;
// 管理番号K26528 From
//			string focusControl			= WhCodeText.UniqueID ;
			string focusControl			= WhCodeText.ClientID;
// 管理番号K26528 To

			DataGridItem gItem			= null;
			if (WhCodeText.UniqueID	!= this.InpWhCodeText.UniqueID)
			{
				gItem = (DataGridItem)((CustomTextBox) sender).Parent.Parent;
			}
			rowCtl = this.GetControls(gItem);

			//Enabled制御
			SetRowControlCondition(rowCtl, true);

			if (this.setWhName(rowCtl.WhNameLabel, WhCodeText.Text.Trim(), false))
			{
				if (rowCtl.LotDtilButton.Visible && rowCtl.LotDtilButton.Enabled)
				{
					focusControl = appendedIDPart + rowCtl.LotDtilButton.ID;
				}
				else
				{
					focusControl = appendedIDPart + rowCtl.PuQtText.ID;
				}
			}

			//ロット制御
			SetLotInfo(false, rowCtl.PuLineId);

// 管理番号K26528 From
//			if (rowCtl.Inp=="1")
//			{
//				ScrollBottom();
//			}
//			else
//			{
//				ScrollRow(rowCtl.ProdCodeText.ClientID);
//			}
// 管理番号K26528 To

			FocusControl(focusControl, sender);
			dtlChangeFlg = true;
		}
		protected void UnitList_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			CustomDropDownList UnitList = (CustomDropDownList)sender;
// 管理番号K26528 From
//			string focusControl = string.Empty;
// 管理番号K26528 To

			DataGridItem gItem = null;
			if (UnitList.UniqueID != this.InpUnitList.UniqueID)
			{
				gItem = (DataGridItem) ((CustomDropDownList) sender).Parent.Parent;
			}
			rowCtl = GetControls(gItem);

// 管理番号K26528 From
//			if (SetProdPrice(sender, rowCtl))
//			{
//				focusControl = rowCtl.UnitList.UniqueID;
//			}
//			else
//			{
//				focusControl = rowCtl.ProdCodeText.UniqueID;
//			}
			SetProdPrice(sender, rowCtl);
// 管理番号K26528 To

			//Enabled制御
			SetRowControlCondition(rowCtl, true);

			//ロット制御
			SetLotInfo(false, rowCtl.PuLineId);

// 管理番号K26528 From
//			if (rowCtl.Inp=="1")
//			{
//				ScrollBottom();
//			}
//			else
//			{
//				ScrollRow(rowCtl.ProdCodeText.ClientID);
//			}
// 管理番号K26528 To

			// 検索ウィンドウから戻ってきたときは自コントロールにフォーカスを当てる
			if(returnValue == "ProdUnit")
			{
// 管理番号K26528 From
//				FocusControl(rowCtl.UnitList.UniqueID);
				FocusControl(rowCtl.UnitList.ClientID);
// 管理番号K26528 To
			}
			else
			{
// 管理番号K26528 From
//				FocusControl(focusControl);
				FocusControl(rowCtl.Inp == "1"
					? rowCtl.UnitList.NextControlID
					: rowCtl.UnitList.AppendedIDPart + rowCtl.UnitList.NextControlID
					);
// 管理番号K26528 To
			}
			dtlChangeFlg = true;
		}

		protected void LineRemarksCodeText_TextChanged(object sender, EventArgs e)
		{
			CustomTextBox RemarksCode	= (CustomTextBox) sender;
// 管理番号K26528 From
//// 管理番号 K22158 From
////			if (Request.Form["__EVENTTARGET"] == RemarksCode.UniqueID)
//            if (changeIDSeparator(Request.Form["__EVENTTARGET"]) == RemarksCode.UniqueID)
//// 管理番号 K22158 To
			if (Request.Form["__EVENTTARGET"] == RemarksCode.UniqueID)
// 管理番号K26528 To
			{
				string remarks = string.Empty;

				DataGridItem gItem			= null;
				if (RemarksCode.UniqueID != this.InpRemarksCodeText.UniqueID)
				{
					gItem = (DataGridItem)RemarksCode.Parent.Parent;
				}
				rowCtl = GetControls(gItem);

				if (rowCtl.RemarksCodeText.Text.Trim().Length > 0)
				{
					remarks = Infocom.Allegro.CM.MS.LineRemarks.GetRemarks(this.CommonData, pageCode, rowCtl.RemarksCodeText.Text.Trim());
					if (remarks.Length > 0)
					{
						rowCtl.RemarksText.Text = remarks;
					}
				}

// 管理番号K26528 From
//				if (rowCtl.Inp=="1")
//				{
//					ScrollBottom();
//				}
//				else
//				{
//					ScrollRow(rowCtl.ProdCodeText.ClientID);
//				}
// 管理番号K26528 To

				lotDiff = true;
// 管理番号K26528 From
//				FocusControl(rowCtl.RemarksCodeText.UniqueID, sender);
				FocusControl(rowCtl.RemarksCodeText.ClientID, sender);
// 管理番号K26528 To
				dtlChangeFlg = true;
			}
		}

// 管理番号 K24389 From
		/// <summary>
		/// 新規行数量チェンジイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void InpPuQtText_TextChanged(object sender, System.EventArgs e)
		{
			puQtTextChange(sender);
		}

		/// <summary>
		/// 編集行数量チェンジイベント
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		protected void EditPuQtText_TextChanged(object sender, System.EventArgs e)
		{
			puQtTextChange(sender);
// 管理番号B27422 From
			lotDiff = true;	// 退避用ロット明細との差分を保つ
// 管理番号B27422 To
		}

		/// <summary>
		/// 数量変更
		/// </summary>
		/// <param name="sender"></param>
		private void puQtTextChange(object sender)
		{
			NumberBox PuQtText = (NumberBox)sender;
			DataGridItem gItem = null;

			if (PuQtText.UniqueID != this.InpPuQtText.UniqueID)
			{
				gItem = (DataGridItem)PuQtText.Parent.Parent;
			}

			rowCtl = GetControls(gItem);

			bool IsProdEditFlg = rowCtl.ProdEditLabel.Text.Trim() != "0";		//参照伝票の明細行の商品 or 制御用商品
			string nextFocusId = string.Empty;

			if (gItem == null)
			{
// 管理番号 B25848 From
//				nextFocusId = rowCtl.UnitList.Enabled ? rowCtl.UnitList.ClientID : rowCtl.PuPriceText.Enabled ? rowCtl.PuPriceText.ClientID : rowCtl.RegistButton.ClientID;
				nextFocusId = rowCtl.UnitList.Enabled ? rowCtl.UnitList.ClientID : rowCtl.PuPriceText.Enabled ? rowCtl.PuPriceText.ClientID : rowCtl.RegistButton.Enabled ? rowCtl.RegistButton.ClientID : this.UpdateButton.ID;
// 管理番号 B25848 To
			}
			else
			{
// 管理番号 B25848 From
//				nextFocusId = rowCtl.UnitList.Enabled ? rowCtl.UnitList.ClientID : rowCtl.PuPriceText.Enabled ? rowCtl.PuPriceText.ClientID : rowCtl.UpdateButton.ClientID;
				nextFocusId = rowCtl.UnitList.Enabled ? rowCtl.UnitList.ClientID : rowCtl.PuPriceText.Enabled ? rowCtl.PuPriceText.ClientID : rowCtl.UpdateButton.Enabled ? rowCtl.UpdateButton.ClientID : this.UpdateButton.ID;
// 管理番号 B25848 To
			}

			if (IsProdEditFlg)
			{
// 管理番号 K25514 From
//				if (!SetProdPrice(sender, rowCtl))
				if (!GetVolumeDiscount(sender, rowCtl))
// 管理番号 K25514 To
				{
					nextFocusId = rowCtl.PuQtText.ClientID;
				}
			}

			FocusControl(nextFocusId);
		}
// 管理番号 K24389 To
// 管理番号 K25514 From
		private bool GetVolumeDiscount(object sender, SC_MM_05_S02_ROW_CONTROLS ctl)
		{
			//価格取得用パラメータセット
			string curCode			= CurCodeList.SelectedValue;
			string prodCode			= ctl.ProdCodeText.Text;
			string prodSpec1Code	= ctl.ProdSpec1List.SelectedValue;
			string prodSpec2Code	= ctl.ProdSpec2List.SelectedValue;
			string unitCode			= ctl.UnitList.SelectedValue;
			string suplCode			= string.Empty;
			string suplSbno			= string.Empty;
			if (SuplCodeText.Text.Trim().Length > 0)
			{
				rowData.DivideSuplCode(SuplCodeText.Text.Trim(), this.CompanyCodeLength);
				suplCode = rowData.SuplCode;
				suplSbno = rowData.SuplSbno;
			}
			string deptCode			= DeptCodeText.Text.Trim();
			string compareDate		= DateValidator.IsDate(PuDateText.Text) ? PuDateText.Text.Trim() : todayDate;
			Infocom.Allegro.SC.IF_SC_MS_Prod prodInfo = new IF_SC_MS_Prod();
			prodInfo.PriceType		= "2";
			prodInfo.CurCode		= curCode;
			prodInfo.ProdCode		= prodCode;
			prodInfo.ProdSpec1Code	= prodSpec1Code;
			prodInfo.ProdSpec2Code	= prodSpec2Code;
			prodInfo.UnitCode		= unitCode;
			prodInfo.CustSpulCode	= suplCode;
			prodInfo.CustSpulSbno	= suplSbno;
			prodInfo.DeptCode		= deptCode;
			prodInfo.TargetDate		= compareDate;
			prodInfo.BasisQt		= ctl.PuQtText.Text.Trim();

			//価格取得
			if (Prod.GetVolumeDiscount(CommonData, prodInfo))
			{
				decimal puQt = ctl.PuQtText.Text.Trim() != string.Empty ? decimal.Parse(ctl.PuQtText.Text) : 0M;
				if (puQt > 0M)
				{
					if (prodInfo.Price > 0M)
					{
// 管理番号 K25647 From
//						ctl.PuPriceText.Text		= Common.FormatAmt(prodInfo.Price, curDigit, PriceDecimalUseFlg, "2");
						ctl.PuPriceText.Text		= ControlFormat.ToSlipPrice(prodInfo.Price, this.PriceDecimalDigit, byte.Parse(this.curDigit), ControlFormat.FormatType.Input);
// 管理番号 K25647 To
// 管理番号 B25883 From
						ctl.InitPuPriceHdn.Value	= ctl.PuPriceText.Text;
// 管理番号 B25883 To
						ctl.PuPlanPriceLabel.Text	= prodInfo.Price.ToString();
						ctl.PuMoneyLabel.Text		= Common.FormatAmt(Round.GetRound(CommonData, prodInfo.Price * puQt, double.Parse(curDigit), AmtRoundType), curDigit, false, "1");
					}
					else
					{
// 管理番号 B25848 From
						if (ctl.PuPriceText.Text != null && ctl.PuPriceText.Text.Length != 0)
						{
// 管理番号 B25848 To
							ctl.PuMoneyLabel.Text		= Common.FormatAmt(Round.GetRound(CommonData, decimal.Parse(ctl.PuPriceText.Text.Trim()) * puQt, double.Parse(curDigit), AmtRoundType), curDigit, false, "1");
// 管理番号 B25848 From
						}
// 管理番号 B25848 To
					}
				}
				return true;
			}
			else
			{
				return false;
			}
		}
// 管理番号 K25514 To
		#endregion

		#region イベントコントロール(フッタ)
// 管理番号 K22217 From
        private void RouteChangeButton_Click(object sender, EventArgs e)
        { 
            if (appEmpCode.Length != 0 && appRouteId.Length != 0)
            {
// 管理番号 K24546 From
//				RouteChangeButton.ImageUrl = "img/CM_b2_route_change_on.gif";
				RouteChangeButton.CssClass = "normal_changed";
// 管理番号 K24546 To
            }
            else
            {
// 管理番号 K24546 From
//				RouteChangeButton.ImageUrl = "img/CM_b2_route_change_off.gif";
				RouteChangeButton.CssClass = "normal";
// 管理番号 K24546 To
            }

        }
// 管理番号 K22217 To
		private void UpdateButton_Click(object sender, EventArgs e)
		{
// 管理番号 B24292 From
			//破棄対象項目の差異確認
			//部門
			if (OrgDeptCodeHdn.Value != DeptCodeText.Text.Trim())
			{
				deptCodeChange(sender);
				return;
			}

            if (this.InputEmpCodeText.Text.Length>0)
            {
				string inputEmpName = string.Empty;
				if (!Emp.IsExists(this.CommonData, InputEmpCodeText.Text, out inputEmpName, false))
				{
					setMessageLabel(HtmlMessage(AllegroMessage.S20005("入力者"), MessageLevel.Warning));
					return;
				}
				
			}
// 管理番号 B24292 To
// 管理番号 K24789 From
			if (UpdateFlg.Value.ToString() == string.Empty)
			{
				//リトライ判定
				if (retryHidden.Value.Equals("R"))
				{
					//（ここの処理は二回目（ダイアログが表示されて、「はい」が押下された場合）に通ります。
					//二回目の場合は、Hidden値を戻してチェック処理を抜けます）
					//Hidden設定を戻す
					retryHidden.Value = string.Empty;
				}
				else
				{
// 管理番号K26528 From
//					if (!ClientScript.IsStartupScriptRegistered("updCheck"))
					if (!PageStartupScript.IsScriptRegistered("updCheck"))
// 管理番号K26528 To
					{
						//（Scriptで警告メッセージを表示します）
						StringBuilder script = new StringBuilder();
						//警告ダイアログを表示する。
// 管理番号K26528 From
//						script.Append("<script  type=\"text/javascript\">\n");
//						script.Append("<!--\n");
//						script.Append("	if (showOrderSlip(\"1\"))\n"); 
//						script.Append("	{\n");
//						//（確認ダイアログで、「はい」が押された場合は、更新ボタン押下を再実行）
//						script.Append("		document.getElementById(\"UpdateButton\").click();\n");
//						script.Append("	}\n	else\n	{\n");
//						//（キャンセルが押下された場合には、リトライ判定のHidden値をクリア）
//						script.Append("		document.getElementById(\"retryHidden\").value=\"\";\n");
//						script.Append("}\n");
//						script.Append("-->\n");
//						script.Append("</script>");
//						Page.ClientScript.RegisterStartupScript(this.GetType(), "updCheck", script.ToString());
						script.AppendLine("	showOrderSlip('1');");
						script.AppendLine("	lazyTask.add(");
						script.AppendLine("		function (lazyArg) {");
						script.AppendLine("			if (lazyArg) {");
						//（確認ダイアログで、「はい」が押された場合は、更新ボタン押下を再実行）
						script.AppendLine("				document.getElementById('UpdateButton').click();");
						script.AppendLine("			} else {");
						//（キャンセルが押下された場合には、リトライ判定のHidden値をクリア）
						script.AppendLine("				document.getElementById('retryHidden').value='';");
						script.AppendLine("			}");
						script.AppendLine("		}");
						script.AppendLine("	);");
						PageStartupScript.RegisterScript(this.GetType(), "updCheck", script.ToString());
// 管理番号K26528 To
					}
					//Hidden値設定をリトライに設定
					retryHidden.Value = "R";
					//（二度目の更新押下かを判定するHiddenを設定）
					return;
				}
			}
// 管理番号 K24789 To
			if(!dtlChangeFlg)
			{
				string printPuNo  = string.Empty;
				string reportMess = string.Empty;
				// 管理番号 B13879 From
				string puModeType       = string.Empty;
				// 管理番号 B13879 To
				StringBuilder resultMsg = new StringBuilder();

				if (rowData.IsExistsTemporary)
				{
					rowData.RollBack(true);
				}
				insertFlg = false;

// 管理番号 B15710 From
				keyColumn.WkKey = this.Session.SessionID + DateTime.Now.ToString("yyyyMMddhhmmssfff");
// 管理番号 B15710 To
// 管理番号 K16590 From
				//修正モード時のみ赤伝票用の仕入日をセット
				if (paramType == ParamCodeType.MOD)
				{
					keyColumn.DeleteDate = deleteDate.Value;
				}
// 管理番号 K16590 To

// 管理番号 B24264 From
				rowData.TempSuplHt = tempRowData;
// 管理番号 B24264 To

				setRowData();
// 管理番号K27057 From
				rowData.SetCustomItemValidator(rowData.CustomItemHead);
				CustomItem.SetIF(CommonData, CustomItemPanel, rowData.CustomItemHead);
// 管理番号K27057 To

// 管理番号 B24959 From
				if (!rowData.HasErrors)
				{
// 管理番号 B24959 To
// 管理番号 K25647 From
					rowData.PriceDecimalDigit	= this.PriceDecimalDigit;
					rowData.CurDigit			= this.curDigit;
// 管理番号 K25647 To
					//エラーチェック
					rowData.Validate(this.CommonData, this.DisclosureUnitType, this.UserDeptCode);
// 管理番号 B24959 From
				}
				else
				{
					setMessageLabel(rowData.ErrorMessage);
					return;
				}

// 管理番号 K25667 From
				//パラメータ.元黒伝票番号に新規の場合：empty、修正の場合、修正前伝票番号をセットする為の変数。
				string oldSlipNo = rowData.PuNo;
				//パラメータ.伝票番号に新規の場合：前回伝票番号、修正の場合、修正後伝票番号をセットする為の変数。
				string newSlipNo = string.Empty;
// 管理番号 K25667 To
				//雑仕入先の入力チェック
				rowData.tempSuplInfoValidate(this.CommonData);
// 管理番号 B24959 To
				if (!rowData.HasErrors)
				{
					try
					{
// 管理番号 B22107 From
						//ログインユーザと伝票の担当者が等しくないときのみ
						if(this.UserCode != EmpCodeText.Text.Trim())
						{
							string disclosureUnitType = string.Empty;
	
							disclosureUnitType = CM.MS.Emp.getDisclosureUnitType(this.CommonData, EmpCodeText.Text.Trim(), this.PageID);

							//WF対象時、伝表の担当者の公開単位区分自部門のみ
							if(this.approvalFlg && disclosureUnitType == "D")
							{
								DataTable dt = CM.MS.Dept.GetEmpDeptList(this.CommonData, EmpCodeText.Text.Trim(), PuDateText.Text.Trim());
								bool deptFlg = false;

								foreach (DataRow dr in dt.Rows)
								{
									string belongingDeptCode = dr["DEPT_CODE"].ToString();

									// 自部門チェック
									if(CM.MS.Dept.IsOwnDept(this.CommonData, belongingDeptCode, DeptCodeText.Text.Trim(), PuDateText.Text.Trim()))
									{
										deptFlg = true;
									}
									if(deptFlg)
									{
										break;
									}
								}
								if(!deptFlg)
								{
// 									setMessageLabel(HtmlMessage(AllegroMessage.S10042("担当者の所属部門","部門"), MessageLevel.Warning)); //K24546
									setMessageLabel(HtmlMessage(AllegroMessage.S10042(MultiLanguage.Get("SC_CS004744"),MultiLanguage.Get("SC_CS001858")), MessageLevel.Warning));
									return;
								}
							}
						}
// 管理番号 B22107 To 
// 管理番号 K24789 From
// Validateチェックの前に処理移動
//// 管理番号 B24292 From
//						//リトライ判定
//						if (retryHidden.Value.Equals("R"))
//						{
//							//（ここの処理は二回目（ダイアログが表示されて、「はい」が押下された場合）に通ります。
//							//二回目の場合は、Hidden値を戻してチェック処理を抜けます）
//							//Hidden設定を戻す
//							retryHidden.Value = string.Empty;
//						}
//						else
//						{
//							if (!ClientScript.IsStartupScriptRegistered("updCheck"))
//							{
//								//（Scriptで警告メッセージを表示します）
//								StringBuilder script = new StringBuilder();
//								//警告ダイアログを表示する。
//								script.Append("<script  type=\"text/javascript\">\n");
//								script.Append("<!--\n");
//								script.Append("	if (showOrderSlip(\"1\"))\n"); 
//								script.Append("	{\n");
//								//（確認ダイアログで、「はい」が押された場合は、更新ボタン押下を再実行）
//								script.Append("		document.getElementById(\"UpdateButton\").click();\n");
//								script.Append("	}\n	else\n	{\n");
//								//（キャンセルが押下された場合には、リトライ判定のHidden値をクリア）
//								script.Append("		document.getElementById(\"retryHidden\").value=\"\";\n");
//								script.Append("}\n");
//								script.Append("-->\n");
//								script.Append("</script>");
//								Page.ClientScript.RegisterStartupScript(this.GetType(), "updCheck", script.ToString());
//							}
//							//Hidden値設定をリトライに設定
//							retryHidden.Value = "R";
//							//（二度目の更新押下かを判定するHiddenを設定）
//							return;
//						}
//// 管理番号 B24292 To

						if (UpdateFlg.Value.ToString() != "1")
						{
							rowData.CheckFlg		= string.Empty;
							string outPutMessage	= string.Empty;
							string chkRateMessage	= string.Empty;
							string chkQtMessage		= string.Empty;

							// 消費税率チェック
							chkRateMessage = rowData.CtaxRateDtilChkMessage(this.CommonData);
							if (chkRateMessage.Length != 0)
							{
								setMessageLabel(HtmlMessage(chkRateMessage, MessageLevel.Info));
							}
						}

						if (UpdateFlg.Value.ToString() != "1" && UpdateFlg.Value.ToString() != "0" && rowData.CheckFlg == "1")
						{
// 管理番号K26528 From
//							string script = @"<script type=""text/javascript"">
//<!--
////更新してよろしいですか?
//if(confirm(""" + MultiLanguage.Get("SC_CS003402") + @""")){
//	document.all[""UpdateFlg""].value = ""1"";
//	document.getElementById(""UpdateButton"").click();
//} 
//else
//{
//	document.all[""UpdateFlg""].value = ""0"";
//	document.getElementById(""UpdateButton"").click();
//} 
//// -->
//</script>";
//							ClientScript.RegisterStartupScript(this.GetType(), "updateCheck", script);
							var script = new StringBuilder();
							// 更新してよろしいですか?
							script.AppendLine("	if(confirm('" + MultiLanguage.Get("SC_CS003402") + "')){");
							script.AppendLine("		document.getElementById('UpdateFlg').value = '1';");
							script.AppendLine("		document.getElementById('UpdateButton').click();");
							script.AppendLine("	} else {");
							script.AppendLine("		document.getElementById('UpdateFlg').value = '0';");
							script.AppendLine("		document.getElementById('UpdateButton').click();");
							script.AppendLine("	}");
							PageStartupScript.RegisterScript(this.GetType(), "updateCheck", script.ToString());
// 管理番号K26528 To
						}

						if(rowData.CheckFlg == "")
						{
							UpdateFlg.Value = "1";
						}

						if (UpdateFlg.Value.ToString() == "1")
						{
							UpdateButton.ClientClickScript = "checkValueUpdate";
// 管理番号 K24789 To
							rowData = BL_SC_MM_05_S02.Insert_Update(this.CommonData, this.keyColumn, this.rowData);
							//正常終了メッセージ表示
							if (paramType =="Mod")
							{
								//赤黒発生
								if (keyColumn.SlipNo!=slipNo)
								{
// 									resultMsg.Append(AllegroMessage.S00002("仕入番号", slipNo)); //K24546
									resultMsg.Append(AllegroMessage.S00002(MultiLanguage.Get("SC_CS000809"), slipNo));

									if (DataGrid1.EditItemIndex!=-1)
									{
										rowData.RollBack(true);
									}

									if (!getLock(keyColumn.SlipNo))
									{
										paramType = "View";
// 管理番号 B24264 From
										// PreRenderで制御するため不要
//										base.Mode = Infocom.Allegro.Web.PageMode.Reference;
// 管理番号 B24264 To
										return ;
									}
									if (!releaseLock(slipNo))
									{
										return;
									}
									lockedPuNo = keyColumn.SlipNo;
								}
								else
								{
									resultMsg.Append(AllegroMessage.S00001);
								}

								slipNo = keyColumn.SlipNo;
								printPuNo = keyColumn.SlipNo;
// 管理番号 K25667 From
								newSlipNo = slipNo;
								try
								{
									CM.WF.Common.ApplyAttachmentFile(
										this.CommonData,
										slipType,
										oldSlipNo,
										newSlipNo,
										ConfigurationManager.AppSettings.Get("attachmentFileSavePath"),
										this.attachmentFiles
										);
								}
								catch (AllegroException ex)
								{
									// 例外発生時は一時的に例外メッセージを保存しておく。
									resultMsg.Append("<br>" + ex.Message);
								}
								// 添付資料情報のセッションをクリアする（空のインスタンスで初期化する）
								this.attachmentFiles = new CM.WF.IF_CM_WF_AttachmentFiles();
// 管理番号 K25667 To
								// 管理番号 B13879 From
								puModeType = rowData.PuModeType;
								// 管理番号 B13879 To
// 管理番号 B20859 From
								// ワークフロー対象で申請者以外だった時だったら参照モードにする
// 管理番号 K25679 From
//								if (CM.WF.Common.IsApp(this.CommonData, pageCode, this.UserDeptCode) && 
//									!CM.WF.Common.IsApplicant(this.CommonData, pageCode, slipNo, this.UserDeptCode, this.UserCode))
								slipType = (rowData.SuplSlipNo.Length != 0) ? "CG2" : pageCode;
								if (CM.WF.Common.IsApp(this.CommonData, slipType, this.UserDeptCode) && 
									!CM.WF.Common.IsApplicant(this.CommonData, slipType, slipNo, this.UserDeptCode, this.UserCode))
// 管理番号 K25679 To
								{
									this.paramType = ParamCodeType.VIEW;
									this.DataGrid1.AutoPostBack = false;

									// ロックの解除
									if (!releaseLock(slipNo))
									{
										return;
									}
								}
// 管理番号 B20859 To
								setDispData();
								setApproval(rowData.DeptCode);
// 管理番号 B22403 From
//								FocusControl(PuDateText.ID);
								FocusControl(PuNoText.ID);
// 管理番号 B22403 To
							}
							else
							{
								resultMsg.Append(AllegroMessage.S00001);
// 								LastSlipNoLabel.Text = "（前回番号 " + rowData.PuNo + "）"; //K24546
								LastSlipNoLabel.Text = MultiLanguage.Get("SC_CS002065") + rowData.PuNo + MultiLanguage.Get("SC_CS000049");
								paramType	= ParamCodeType.NEW;
								slipNo		= string.Empty;
								printPuNo	= rowData.PuNo;
								refType		= RefCodeType.NONE;
// 管理番号 K25667 From
								newSlipNo = rowData.PuNo;
								try
								{
									CM.WF.Common.ApplyAttachmentFile(
										this.CommonData,
										slipType,
										oldSlipNo,
										newSlipNo,
										ConfigurationManager.AppSettings.Get("attachmentFileSavePath"),
										this.attachmentFiles
										);
								}
								catch (AllegroException ex)
								{
									// 例外発生時は一時的に例外メッセージを保存しておく。
									resultMsg.Append("<br>" + ex.Message);
								}
								// 添付資料情報のセッションをクリアする（空のインスタンスで初期化する）
								this.attachmentFiles = new CM.WF.IF_CM_WF_AttachmentFiles();
// 管理番号 K25667 To
								// 管理番号 B13879 From
								puModeType = rowData.PuModeType;
								// 管理番号 B13879 To
								rowData.Delete();
								rowData = new IF_SC_MM_05_S02_RowData();
								setDefaultData();
								setApproval(this.UserDeptCode);
// 管理番号 B22425 From
								keyColumn			= new IF_SC_MM_05_S02_KeyColumn();
								keyColumn.ParamType = paramType;
								keyColumn.RefType   = refType;
								keyColumn.SlipNo    = slipNo;
								keyColumn.DisclosureUnitType		= this.DisclosureUnitType;
								keyColumn.UserDeptCode				= this.UserDeptCode;
// 管理番号 B22425 To
// 管理番号K27057 From
								CustomItem.SetDataColumnCollection(InpCustomItemPanel, "CUSTOM_ITEM_TAG", rowData.Dt.Columns);
								CustomItem.SetCustomItem(CustomItemPanel, new IF_CM_MS_CustomItem(), null);
// 管理番号K27057 To
								FocusControl(PoRefText.ID);
							}

							// 管理番号 B13879 From
							//						printList(sender, printPuNo, out reportMess);
							printList(sender, printPuNo, puModeType, out reportMess);
							// 管理番号 B13879 To

							IsDirty = false;
							DataGrid1.EditItemIndex = -1;

// 管理番号 B24235 From
							clearNewControlValue();
// 管理番号 B24235 To
// 管理番号 B21175 From
							setNewControlCondition(true);
// 管理番号 B21175 To
// 管理番号 B24188 From
							SetDispHoldReleaseButton();
// 管理番号 B24188 To
// 管理番号 K22217 From
							SessionRemove();
// 管理番号 K22217 To   
							resultMsg.Append(reportMess);
							if (resultMsg.Length>0)
							{
								setMessageLabel(HtmlMessage(resultMsg.ToString(), MessageLevel.Info));
							}
// 管理番号 K24789 From
							UpdateFlg.Value = "";
						}
						else if (UpdateFlg.Value.ToString() == "0")
						{
							UpdateButton.ClientClickScript = "checkValueUpdate";
							UpdateFlg.Value = "";
						}
						else 
						{
							UpdateButton.ClientClickScript = "";
						}
// 管理番号 K24789 To

					}
					catch (AllegroException ex)
					{
						setMessageLabel(ex.HtmlMessage);
// 管理番号 K24789 From
						UpdateFlg.Value = "";
// 管理番号 K24789 To
						return;
					}
				}
				else
				{
					setDataGridProperty(rowData.Dt);
					setMessageLabel(rowData.ErrorMessage);
					return;
				}
			}
		}

// 管理番号 K25667 From
		/// <summary>
		/// 添付資料ボタンの押下
		/// </summary>
		/// <param name="sender">イベントのソース</param>
		/// <param name="e">イベント データを格納しているオブジェクト</param>
		private void AttachmentFileButton_Click(object sender, EventArgs e)
		{
			if (Request["__EVENTARGUMENT"] == "AttachmentFileButton_Click")
			{
				// 添付資料画面が閉じられたあとのポストバックで発生したイベントの場合は以降の処理は実行しない
				// （実質、空のポストバックを発生させたようなもの）
				return;
			}

			// パラメータ区分は画面の値をそのまま渡せない場合があるので処理を分ける
			string parameterType = string.Empty;
			switch (paramType)
			{
				case ParamCodeType.NEW:
				case ParamCodeType.COPY:
				case ParamCodeType.COPY_PO:
				case ParamCodeType.COPY_RC:
				case ParamCodeType.REF_PU:
					parameterType = "New";

					// 部門コードの存在チェックを行う（エラー時は添付資料画面を起動しない）
					var date = PuDateText.Text.Trim();
					if (string.IsNullOrEmpty(date))
					{
						date = this.todayDate;
					}

					var includeLowerDept = this.DisclosureUnitType == "C" ? string.Empty : this.UserDeptCode;
					if (!Dept.IsExists(this.CommonData, this.DeptCodeText.Text.Trim(), date, false, true, false, includeLowerDept, false, false))
					{
						// [部門]がマスタにないか、有効ではありません。
						setMessageLabel(HtmlMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001858")), MessageLevel.Warning));
						return;
					}
					break;
				case ParamCodeType.MOD:
					parameterType = "Mod";
					break;
				case ParamCodeType.VIEW:
				default:
					parameterType = "View";
					break;
			}

// 管理番号K26508 From
			// 権限設定区分が"V"：参照権限の場合、参照モードで起動
			parameterType = this.AuthoritySettingType == "V" ? "View" : parameterType;
// 管理番号K26508 To
			var parameter = new IF_CM_WF_03_S09_Parameter
			{
				Amount = rowData.Dt.Rows.Count == 0 ? 0 : rowData.KeyGrandTtl,
				ApprovalMatterShortName = string.Empty,
				ChangeType = base.IsDirty ? "1" : "0",
				CustSuplShortName = this.SuplNameText.Text,
				Description = this.PuNameText.Text,
				EmpName = this.EmpNameLabel.Text,
				PageID = this.PageID,
				SlipNo = this.PuNoText.Text.Trim(),
				SlipType = slipType,
				WorkflowUseType =
					CM.WF.Common.IsApp(this.CommonData, slipType, this.DeptCodeText.Text.Trim())
							// EDI伝票の場合、"0"：使用しない を渡す
							?(rowData != null && rowData.ImportSlipNo.Length != 0 && rowData.SuplSlipNo.Length == 0)
								? "0"
								: "1"
							: "0",
				ParameterType = parameterType,
			};

			// セッションにパラメータを格納した上で添付資料画面を呼び出す
			Session["CM_WF_03_S09_Parameter"] = parameter;

			// 添付資料画面が閉じられたあと、空のポストバックを発生させるようなコードを記述する
			// （参照モードの場合は添付内容は変更されないのでポストバックを発生させる必要はない）
			// また、添付資料画面側で変更があったかどうかがreturnValueで通知されるので
			// __isDirtyの値がブランクでなければ添付資料画面の戻り値で更新する
			var postBackScript = ClientScript.GetPostBackEventReference((Control)sender, "AttachmentFileButton_Click");
// 管理番号K26528 From
//			var script = @"
//(function(returnValue){
//	var isDirtyHidden = document.getElementById('__isDirty');
//	isDirtyHidden.value = isDirtyHidden.value || returnValue;
//" + (parameter.ParameterType == "View" ? string.Empty : postBackScript) + @"
//})(CM_openModalDialog('CM_WF_03_S09', '', 1280));";
//			ClientScript.RegisterStartupScript(sender.GetType(), "AttachmentFileButton_Click", script, true);
			var sb = new StringBuilder();
			sb.AppendLine("CM_transitionPage('CM_WF_03_S09');");
			sb.AppendLine("lazyTask.add(");
			sb.AppendLine("	function (returnValue) {");
			sb.AppendLine("		var isDirtyHidden = document.getElementById('__isDirty');");
			sb.AppendLine("		isDirtyHidden.value = isDirtyHidden.value || returnValue;");
			sb.AppendLine("		" + (parameter.ParameterType == "View" ? string.Empty : postBackScript + ";"));
			sb.AppendLine("	}");
			sb.AppendLine(");");
			PageStartupScript.RegisterScript(this.GetType(), "AttachmentFileButton_Click", sb.ToString());
// 管理番号K26528 To
		}
// 管理番号 K25667 To

		private void DeleteButton_Click(object sender, EventArgs e)
		{
			IF_SC_MM_05_S02_KeyColumn keyColumnPuNo = new IF_SC_MM_05_S02_KeyColumn();

			keyColumn.SlipNo		= PuNoText.Text.Trim();
			keyColumn.DeleteDate	= this.deleteDate.Value;
// 管理番号 B15710 From
			keyColumn.WkKey = this.Session.SessionID + DateTime.Now.ToString("yyyyMMddhhmmssfff");
// 管理番号 B15710 To

			if (!keyColumn.HasErrors)
			{
				try
				{
// 管理番号 B20818 From
//					bool ret = BL_SC_MM_05.Delete(this.CommonData, keyColumn);
					bool ret = BL_SC_MM_05.Delete(this.CommonData, keyColumn, rowData);
// 管理番号 B20818 To
// 管理番号 K22217 From
                    SessionRemove();
// 管理番号 K22217 To
					if (!releaseLock(lockedPuNo))
					{
						return;
					}
// 管理番号 B24264 From
					Session.Remove("SC_MS_02_S20_TempSuplData");
					closeFlg = true;
// 管理番号 B24264 To
					CloseWindow();
				}
				catch (AllegroException ex)
				{
					setMessageLabel(ex.HtmlMessage);
					return;
				}
			}
			else
			{
				setMessageLabel(keyColumn.ErrorMessage);
				return;
			}
// 管理番号 K25667 From
			// 添付資料情報のセッションをクリアする（画面を閉じるので破棄する）
			Session.Remove(this.PageID + "_ApprovalAttachmentFiles");
// 管理番号 K25667 To
		}

		//仕入一覧表
		private void PuSlipButton_Click(object sender, EventArgs e)
		{
			string reportMess = string.Empty;
// 管理番号K27058 From
//			// 管理番号 B13879 From
//			//			printList(sender, this.slipNo, out reportMess);
//			printList(sender, this.slipNo, this.PuModeTypeList.SelectedValue, out reportMess);
//			// 管理番号 B13879 To
			printList(sender, this.slipNo, this.puModeType, out reportMess);
// 管理番号K27058 To
		}

		private void CloseButton_Click(object sender, EventArgs e)
		{
			if (paramType == ParamCodeType.MOD)
			{
				if (!releaseLock(lockedPuNo))
				{
					return;
				}
			}
// 管理番号 K22217 From
            SessionRemove();
// 管理番号 K22217 To

			isClose = true;
// 管理番号 B24264 From
			Session.Remove("SC_MS_02_S20_TempSuplData");
			closeFlg = true;
// 管理番号 B24264 To
// 管理番号 K25667 From
			// 添付資料情報のセッションをクリアする（画面を閉じるので破棄する）
			Session.Remove(this.PageID + "_ApprovalAttachmentFiles");
// 管理番号 K25667 To
			CloseWindow();
		}
// 管理番号 B24188 From
		// 保留解除ボタン押下時の保留フラグ更新メソッド呼び出し
		private void HoldReleaseButton_Click(object sender, EventArgs e)
		{
			rowData.PuNo = this.PuNoText.Text.Trim();
			keyColumn.WkKey = this.Session.SessionID + DateTime.Now.ToString("yyyyMMddhhmmssfff");

			try
			{
				rowData = BL_SC_MM_05_S02.HoldRelease(this.CommonData, this.keyColumn, this.rowData);
				setMessageLabel(HtmlMessage(AllegroMessage.S00001, MessageLevel.Info));

				setDispData();
				FocusControl(PuNoText.ID);
				IsDirty = false;
				DataGrid1.EditItemIndex = -1;

				setNewControlCondition(true);
				SetDispHoldReleaseButton();
				SessionRemove();
			}
			catch (AllegroException ex)
			{
				setMessageLabel(ex.HtmlMessage);
				return;
			}
		}
// 管理番号 B24188 To

		#endregion

		#region ドロップダウン関連
		private void setListItem(CustomDropDownList targetList, string defaultText)
		{
			foreach (ListItem item in targetList.Items)
			{
				item.Selected = item.Value.Equals(defaultText);
			}
		}
		//初期設定
		private void setDefaultListItem()
		{
			//国内
			CustomDropDownList dropDownList			= new CustomDropDownList();
			SttlMthd.SetDataSource(dropDownList, this.CommonData, SttleMthdSearchOption.DomesticPymt);
			//支払条件方法1
			this.Dt1SttlMthdCodeList.DataSource		= dropDownList.DataSource;
			this.Dt1SttlMthdCodeList.DataValueField	= dropDownList.DataValueField;
			this.Dt1SttlMthdCodeList.DataTextField	= dropDownList.DataTextField;
			this.Dt1SttlMthdCodeList.DataBind();
			this.Dt1SttlMthdCodeList.Items.Insert(0,new ListItem("",""));
			//支払条件方法2
			this.Dt2SttlMthdCodeList.DataSource		= dropDownList.DataSource;
			this.Dt2SttlMthdCodeList.DataValueField	= dropDownList.DataValueField;
			this.Dt2SttlMthdCodeList.DataTextField	= dropDownList.DataTextField;
			this.Dt2SttlMthdCodeList.DataBind();
			this.Dt2SttlMthdCodeList.Items.Insert(0,new ListItem("",""));
			//支払条件方法3
			this.Dt3SttlMthdCodeList.DataSource		= dropDownList.DataSource;
			this.Dt3SttlMthdCodeList.DataValueField	= dropDownList.DataValueField;
			this.Dt3SttlMthdCodeList.DataTextField	= dropDownList.DataTextField;
			this.Dt3SttlMthdCodeList.DataBind();
			this.Dt3SttlMthdCodeList.Items.Insert(0,new ListItem("",""));

// 管理番号K27154 From
			// 取引区分
			DealType.SetDataSource(this.CommonData, this.DealTypeList, "I");
			this.DealTypeList.DataBind();
// 管理番号K27154 To
// 管理番号K27525 From
			// 帳簿控除理由 SM3：仕入
			BookDeductionReason.SetDataSource(this.CommonData, this.InpBookDeductionReasonCodeList, "SM3");
			this.InpBookDeductionReasonCodeList.DataBind();

			Carrier.SetDataSource(this.CommonData, this.CarrierCodeDrop);
			CarrierCodeDrop.Items.Insert(0, new ListItem("", ""));
		}

// 管理番号K27062 From
//		//受渡場所ドロップダウン設定
//		private void setDeliPlaceDropDown(string custCode)
//		{
//			if (custCode.Length > 0)
//			{
//				DeliPlace.SetDeliPlaceDataSource(this.DeliPlaceCodeList,custCode,this.CompanyCodeLength,this.CommonData);
//				this.DeliPlaceCodeList.Enabled = true;
//				this.DeliPlaceCodeList.DataBind();
//			}
//			else
//			{
//				DeliPlaceCodeList.Enabled = false;
//				DeliPlaceCodeList.Items.Clear();
//			}
//		}
		//受渡場所コードの設定
		private void setDeliPlaceTextBox(string custCode)
		{
			if (custCode.Length > 0)
			{
				this.DeliPlaceCodeText.Enabled = true;
				this.DeliPlaceNameText.Enabled = true;
				setDeliPlace();
			}
			else
			{
				DeliPlaceCodeText.Enabled = false;
				DeliPlaceCodeText.Text = string.Empty;
			}
		}
// 管理番号K27062 To

		//商品規格,単位コードのドロップダウン制御
		private void setProdDropDown(string prodCodeText, CustomDropDownList prodSpec1List, CustomDropDownList prodSpec2List, CustomDropDownList unitCodeList)
		{
			if (prodCodeText.Length > 0)
			{
				string prodSpecUseType = Prod.GetProdSpecUseType(this.CommonData, prodCodeText);

				//規格1
				prodSpec1List.Enabled = (prodSpecUseType != "0");
				Spec.SetDataSource1(prodSpec1List, prodCodeText, this.CommonData, this.ProductSpecUseType);
				prodSpec1List.DataBind();
				//規格2
				prodSpec2List.Enabled = (prodSpecUseType == "2");
				Spec.SetDataSource2(prodSpec2List, prodCodeText, prodSpec1List.SelectedValue, this.ProductSpecUseType, this.CommonData);
				prodSpec2List.DataBind();
				//単位
				unitCodeList.Enabled = true;
				Infocom.Allegro.SC.MS.Unit.SetDataSource(unitCodeList, this.CommonData, prodCodeText);
				unitCodeList.DataBind();
			}
			else
			{
				prodSpec1List.Items.Clear();
				prodSpec2List.Items.Clear();
				unitCodeList.Items.Clear();
				prodSpec1List.Enabled	= false;
				prodSpec2List.Enabled	= false;
				unitCodeList.Enabled	= false;
			}
		}
		//商品規格,単位コードのドロップダウン制御
		private void setProdDropDown(string prodCode, string prodSpec1Code, string prodSpec2Code, string unitCode,
			CustomDropDownList prodSpec1List, CustomDropDownList prodSpec2List, CustomDropDownList unitCodeList)
		{
			if (prodCode.Length > 0 )
			{
				string prodSpecUseType = Prod.GetProdSpecUseType(this.CommonData, prodCode);

				//規格1
				prodSpec1List.Enabled = (prodSpecUseType != "0");
				Spec.SetDataSource1(prodSpec1List, prodCode, this.CommonData, this.ProductSpecUseType);
				prodSpec1List.DataBind();
				if (prodSpec1Code.Length > 0)
				{
					prodSpec1List.SelectedValue = prodSpec1Code;
				}

				//規格2
				prodSpec2List.Enabled = (prodSpecUseType == "2");
				Spec.SetDataSource2(prodSpec2List, prodCode, prodSpec1Code, this.ProductSpecUseType, this.CommonData);
				prodSpec2List.DataBind();
				if (prodSpec2Code.Length > 0)
				{
					prodSpec2List.SelectedValue = prodSpec2Code;
				}

				//単位
				unitCodeList.Enabled = true;
				Infocom.Allegro.SC.MS.Unit.SetDataSource(unitCodeList, this.CommonData, prodCode);
				unitCodeList.DataBind();
				if (unitCode.Length > 0)
				{
					unitCodeList.SelectedValue = unitCode;
				}
			}
		}
		#endregion

		#region DB検索
		private IF_SC_MM_05_S02_RowData getDataSource()
		{
			return BL_SC_MM_05_S02.Select(this.CommonData, keyColumn);
		}

// 管理番号 B24440 From
		/// <summary>
		/// 条件に応じて伝票データの内容を置き換える
		/// </summary>
		private void replaceRowData()
		{
			if (rowData == null) 
			{
				return;
			}

			// コピーで通常取引先の場合、一部の項目をマスタから読み直す
			if (paramType == ParamCodeType.COPY && rowData.TempCodeFlg != "1")
			{
				string compareDate	= DateValidator.IsDate(this.rowData.PoDate) ? this.rowData.PoDate : todayDate;
				string suplCode		= null;
				if (rowData.SuplCode.Length > 0 && rowData.SuplSbno.Length > 0)
				{
					suplCode = rowData.SuplCode + "-" + rowData.SuplSbno;
				}
				DataTable dtData	= Supl.SetDtData(this.CommonData, suplCode, this.CompanyCodeLength, compareDate);

				if (!dtData.HasErrors && dtData.Rows.Count != 0)
				{
					DataRow dtRow = dtData.Rows[0];

					rowData.DtType				= dtRow["DT_TYPE"].ToString();
					rowData.Dt1SttlMthdCode		= dtRow["DT1_STTL_MTHD_CODE"].ToString();
					rowData.Dt1BasisAmt			= dtRow["DT1_BASIS_AMT"].ToString();
					rowData.Dt2SttlMthdCode		= dtRow["DT2_STTL_MTHD_CODE"].ToString();
					rowData.Dt2Ratio			= dtRow["DT2_RATIO"].ToString();
					rowData.Dt3SttlMthdCode		= dtRow["DT3_STTL_MTHD_CODE"].ToString();
					rowData.DtSight				= dtRow["DT_SIGHT"].ToString();
				}
			}
		}
// 管理番号 B24440 To

		private bool searchExecute()
		{
			// 管理番号 B13877 From
			keyColumn.StockAdminUnitType = this.StockAdminUnitType;
			keyColumn.ProjectStockAdminUseFlg = this.ProjectStockAdminUseFlg;
			// 管理番号 B13877 To
// 管理番号 K16187 From
			keyColumn.ApModuleFlg = Module.CheckModule(this.CommonData, "FIAP");
// 管理番号 K16187 To
// 管理番号 B22031 From
			keyColumn.JapanCountryCode = this.JapanCountryCode;
// 管理番号 B22031 To

			if (keyColumn.HasErrors)
			{
				setMessageLabel(keyColumn.ErrorMessage);
				return false;
			}
			try
			{
				rowData = getDataSource();

				if (rowData.HasErrors)
				{
					setMessageLabel(rowData.ErrorMessage);
					return false;
				}

// 管理番号 B24264 From
				Hashtable ht = new Hashtable();
				rowData.TempSuplHt = ht;

				ht["TEMP_SUPL_CODE"]			= rowData.SuplCode + "-" + rowData.SuplSbno;
				ht["TEMP_SUPL_NAME"]			= rowData.SuplName;
				ht["TEMP_SUPL_SHORT_NAME"]		= rowData.SuplShortName;
				ht["TEMP_SUPL_COUNTRY_CODE"]	= rowData.SuplCountryCode;
				ht["TEMP_SUPL_ZIP"]				= rowData.SuplZip;
				ht["TEMP_SUPL_STATE"]			= rowData.SuplState;
				ht["TEMP_SUPL_CITY"]			= rowData.SuplCity;
				ht["TEMP_SUPL_ADDRESS1"]		= rowData.SuplAddress1;
				ht["TEMP_SUPL_ADDRESS2"]		= rowData.SuplAddress2;
				ht["TEMP_SUPL_PHONE"]			= rowData.SuplPhone;
				ht["TEMP_SUPL_FAX"]				= rowData.SuplFax;
				ht["TEMP_SUPL_DEPT_NAME_1"]		= rowData.SuplDeptName1;
				ht["TEMP_SUPL_DEPT_NAME_2"]		= rowData.SuplDeptName2;
				ht["TEMP_SUPL_USER_NAME"]		= rowData.SuplUserName;
				ht["AC_TYPE"]					= rowData.AcType;
				ht["BANK_AC_TYPE"]				= rowData.BankAcType;
				ht["BANK_COUNTRY_CODE"]			= rowData.BankCountryCode;
				ht["BANK_CODE"]					= rowData.BankCode;
				ht["BANK_BRANCH_CODE"]			= rowData.BankBranchCode;
				ht["AC_HOLDER"]					= rowData.AcHolder;
				ht["AC_NO"]						= rowData.AcNo;

				tempRowData = (Hashtable)rowData.TempSuplHt;
// 管理番号 B24264 To

// 管理番号 K24789 From
				// 消費税率再取得
				string suplCode = rowData.SuplCode+ "-" +rowData.SuplSbno;
				string getType = string.Empty;
				
				switch (refType)
				{
					case RefCodeType.PO:
					case RefCodeType.RCPT:
						getType = "R";
						break;
					case RefCodeType.REF_PU:
						getType = "RR";
						break;
					case RefCodeType.COPY_PU:
						getType = "B";
						break;
					default:
						break;
				}
				
				if (getType != string.Empty)
				{
					rowData.ReloadProdPrice(
						this.CommonData, rowData.CurCode, suplCode, this.CompanyCodeLength, rowData.DeptCode,
						rowData.PuDate.Length == 0 ? todayDate : rowData.PuDate,
						double.Parse(curDigit), AmtRoundType,
						rowData.DealDate.Length == 0 ? todayDate : rowData.DealDate,
						getType);
				}
// 管理番号 K24789 To

				//if (!rowData.ConsistsData) { return false; }
				setDataGridProperty(rowData.Dt);
// 管理番号 B24440 From
				// 検索結果の一部の項目を置き換える
				replaceRowData();
// 管理番号 B24440 To
				setDispData();
			}
			catch(AllegroException ex)
			{
				setDefaultData();
				rowData = new IF_SC_MM_05_S02_RowData();
				setMessageLabel(ex.HtmlMessage);
				return false;
			}
			return true;
		}

		private void setDataGridProperty(DataTable dt)
		{
			DataView dv = new DataView(dt);
			dv.RowFilter = "ROW_STATE <> '"+RowStateType.Delete+"'";
			dv.Sort = "PU_LINE_NO ASC";
			DataGrid1.DataSource = dv;

			useBind = true;
			if (dv.Count != 0)
			{
				DataGrid1.Visible = true;
			}
			else
			{
				DataGrid1.Visible = false;
			}
// 管理番号 K22270 From
			DataGrid1.PageSize = viewnum;
			if (dt.Rows.Count < (DataGrid1.PageSize * DataGrid1.CurrentPageIndex))
				DataGrid1.CurrentPageIndex = (int)(dt.Rows.Count / DataGrid1.PageSize);
			if ((dt.Rows.Count == (DataGrid1.PageSize * DataGrid1.CurrentPageIndex)) && (dt.Rows.Count != 0))
				DataGrid1.CurrentPageIndex = DataGrid1.CurrentPageIndex - 1;

			if ((dt.Rows.Count >= (DataGrid1.PageSize * DataGrid1.CurrentPageIndex)) && (dt.Rows.Count <= (DataGrid1.PageSize * (DataGrid1.CurrentPageIndex + 1))) && (dt.Rows.Count != 0))
			{
				CurrentPage = "MAX";
				if ((dt.Rows.Count <= DataGrid1.PageSize) && (dt.Rows.Count != 0))
				{
					CurrentPage = "MIN";
		}
			}
// 管理番号 K22270 To
		}
// 管理番号 B23437 From
		// 出合の場合に売上番号の取得
		private string getSaNo(string slipNo)
		{
			return BL_SC_MM_05_S02.GetSaNo(this.CommonData, slipNo);
		}
// 管理番号 B23437 To
		#endregion

		#region データグリッド
		private void DataGrid1_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
		{
			DataRowView drv = (DataRowView) e.Item.DataItem;
// 管理番号K27058 From
//// 管理番号 B24781 From
//			// 返品参照時
//			bool isReturnMode = this.PuModeTypeList.SelectedValue == "2" && 0 < rowData.RefPuNo.Length;
//// 管理番号 B24781 To
			bool isReturnMode = this.puModeType == "2" && 0 < rowData.RefPuNo.Length;
// 管理番号K27058 To
			switch (e.Item.ItemType)
			{
				case ListItemType.Item:
				case ListItemType.AlternatingItem:
					var lotDtil	= (StyledButton)e.Item.FindControl("LotDtilButtonItem");
					//返品時の明細行処理変更対応-INSERT-START
					var registBtn	= (StyledButton)e.Item.FindControl("ItemRegistButton");
					//返品時の明細行処理変更対応-INSERT-END
					bool lotAdminFlg			= drv["LOT_ADMIN_FLG"].ToString() == "1";		//ロット管理
					bool stockAdminFlg			= drv["STOCK_ADMIN_FLG"].ToString() == "1";		//在庫管理
					bool IsDirectWh				= drv["WH_CODE"].ToString() != "99999";			//直送倉庫以外
// 管理番号 K25322 From
					bool lotStockValuationFlg	= drv["LOT_STOCK_VALUATION_FLG"].ToString() == "1";		//ロット別在庫評価
// 管理番号 K25322 To
					// 管理番号 B13878 From
					EncodeLabel priceUndecidedFlg = (EncodeLabel)e.Item.FindControl("PriceUndecidedLabel");
					if(this.PriceUndecidedUseFlg)
					{
						priceUndecidedFlg.Visible = true;
					}
					else
					{
						priceUndecidedFlg.Visible = false;
					}
					// 管理番号 B13878 To
					//複数ロット
					lotDtil.Visible = this.LotAdminFlg;
// 管理番号 K25322 From
//					lotDtil.Enabled = this.LotAdminFlg && IsDirectWh && lotAdminFlg && IsDirectWh;
					lotDtil.Enabled = this.LotAdminFlg && (lotStockValuationFlg || (lotAdminFlg && IsDirectWh));
// 管理番号 K25322 To
					if (lotDtil.Enabled)
					{
						//ロット詳細
// 管理番号K26528 From
//						lotDtil.ClientClickScript2 = lotDetailForItemRow(e.Item.UniqueID, drv, false);
						lotDtil.ClientClickScript2 = lotDetailForItemRow(e.Item.ClientID, drv, false);
// 管理番号K26528 To
					}
// 管理番号 K24789 From
					var taxInfoBtn = (StyledButton)e.Item.FindControl("ItemTaxInfoButton");
					if (drv["TAXINFO_CHG_FLG"].ToString() == "1")
					{
						//img/SC_c1_ctax_on.gif
						taxInfoBtn.CssClass = "tiny_changed";
					}
// 管理番号K26528 From
//					taxInfoBtn.ClientClickScript2 = getTaxInfoParameter(e.Item.UniqueID, drv, false);
					taxInfoBtn.ClientClickScript2 = getTaxInfoParameter(e.Item.ClientID, drv, false);
// 管理番号K26528 To
// 管理番号 K24789 To
// 管理番号 B24781 From
////管理番号 B23893 From
////					//返品時の明細行処理変更対応-INSERT-START
////					//返品時は挿入ボタン非表示
////					registBtn.Visible = PuModeTypeList.SelectedValue != "2";
////					//返品時の明細行処理変更対応-INSERT-END
//
//					//挿入ボタンは基本、表示する。ただし、仕入参照している場合は非表示とする。
//					registBtn.Visible = (refType == RefCodeType.REF_PU ? false :true);
////管理番号 B23893 To
					registBtn.Visible = !isReturnMode;
// 管理番号 B24781 To
// 管理番号K26508 From
					// 参照権限時の明細コントロール制御
					viewAuthorityGridControls(e.Item);
// 管理番号K26508 To
					break;
				case ListItemType.EditItem:
					DataGridItem gItem = (DataGridItem)e.Item;

					rowCtl = GetControls(gItem);
					string prodCode		= drv["PROD_CODE"].ToString();
					string Spec1Code	= drv["PROD_SPEC_1_CODE"].ToString();
					string Spec2Code	= drv["PROD_SPEC_2_CODE"].ToString();
					string unitCode		= drv["UNIT_CODE"].ToString();

					rowCtl.ProdNameHdn.Value			= drv["PROD_NAME"].ToString();
					rowCtl.ProdShortNameHdn.Value	= drv["PROD_SHORT_NAME"].ToString();

					//ドロップダウンリスト設定
					setProdDropDown(prodCode, Spec1Code, Spec2Code, unitCode, rowCtl.ProdSpec1List, rowCtl.ProdSpec2List, rowCtl.UnitList);
// 管理番号K27525 From
					// ドロップダウンリスト設定(帳簿控除理由)
					BookDeductionReason.SetDataSource(this.CommonData, rowCtl.BookDeductionReasonCodeList, "SM3");
					rowCtl.BookDeductionReasonCodeList.DataBind();
					rowCtl.BookDeductionReasonCodeList.SelectedValue = drv["BOOK_DEDUCTION_REASON_CODE"].ToString();
// 管理番号K27525 To

					//商品変更可能フラグ(修正以外の伝票参照明細行)
					bool IsProdEditFlg	= rowCtl.ProdEditLabel.Text != "0";
// 管理番号 B12929 From
					rowCtl.InitPuPriceHdn.Value		= rowCtl.PuPriceText.Text;
					rowCtl.PriceUpdateFlgHdn.Value	= drv["PRICE_UPDATE_FLG"].ToString();
// 管理番号 B12929 To

					//ロット制御
					rowCtl.LotDtilButton.Visible = LotAdminFlg;

// 管理番号 B18953 From
					//Enabled制御
//					SetRowControlCondition(rowCtl, true);
					string prodName = string.Empty;
					bool IsExists	= Prod.IsExists(this.CommonData, rowCtl.ProdCodeText.Text, "PO", string.Empty, out prodName);
					SetRowControlCondition(rowCtl, IsExists);
// 管理番号 B18953 To

					if(!LotAdminFlg || !rowCtl.LotDtilButton.Enabled)
					{
// 管理番号 B22050 From
//						rowCtl.WhCodeText.NextControlID = rowCtl.PuQtText.ID;
						rowCtl.UnitList.NextControlID = rowCtl.PuPriceText.ID;
// 管理番号 B22050 To
					}

					if (rowCtl.LotDtilButton.Enabled)
					{
						//ロット詳細
						rowCtl.LotDtilButton.ClientClickScript2 = lotDetailForItemRow(gItem.ClientID + "_", drv, true);
					}
// 管理番号 K24789 From
					rowCtl.CtaxCalcTypeHdn.Value	= drv["CTAX_CALC_TYPE"].ToString();
					rowCtl.CtaxRateCodeHdn.Value	= drv["CTAX_RATE_CODE"].ToString();
					rowCtl.CtaxTypeCodeHdn.Value	= drv["CTAX_TYPE_CODE"].ToString();
					rowCtl.TaxInfoChgFlgHdn.Value	= drv["TAXINFO_CHG_FLG"].ToString();
					if (rowCtl.TaxInfoChgFlgHdn.Value == "1")
					{
						//img/SC_c1_ctax_on.gif
						rowCtl.TaxInfoButton.CssClass = "tiny_changed";
					}
// 管理番号K26528 From
//					rowCtl.TaxInfoButton.ClientClickScript2 = getTaxInfoParameter(e.Item.UniqueID, drv, true);
					rowCtl.TaxInfoButton.ClientClickScript2 = getTaxInfoParameter(e.Item.ClientID, drv, true);
// 管理番号K26528 To
// 管理番号 K24789 To
// 管理番号K27057 From
					if (!IsExists)
					{
						rowCtl.CustomItemPanel.SetNextElement(rowCtl.UpdateButton.Enabled ? rowCtl.UpdateButton.ClientID : UpdateButton.ID);
					}
					CustomItem.SetCustomItem(rowCtl.CustomItemPanel, drv, null, paramType == ParamCodeType.MOD || paramType == ParamCodeType.VIEW);
// 管理番号K27057 To
// 管理番号 B24781 From
////管理番号 B23893 From
////					//返品時の明細行処理変更対応-INSERT-START
////					//返品時は挿入ボタン非表示
////					rowCtl.RegistButton.Visible = PuModeTypeList.SelectedValue != "2";
////					//返品時の明細行処理変更対応-INSERT-END
////					//挿入ボタンは基本、表示する。ただし、仕入参照している場合は非表示とする。
//					rowCtl.RegistButton.Visible = (refType == RefCodeType.REF_PU ? false :true);
////管理番号 B23893 To
					rowCtl.RegistButton.Visible = !isReturnMode;
// 管理番号 B24781 To
// 管理番号K26528 From
//					if(IsProdEditFlg)
//					{
//						FocusControl(rowCtl.ProdCodeText.UniqueID);
//					}
//					else
//					{
//						FocusControl(rowCtl.PuQtText.UniqueID);
//					}
//					ScrollRow(rowCtl.ProdCodeText.ClientID);
					if(IsProdEditFlg)
					{
						FocusControl(rowCtl.ProdCodeText.ClientID);
					}
					else
					{
						FocusControl(rowCtl.PuQtText.ClientID);
					}
// 管理番号K26528 To
					break;
			}
		}

		private void DataGrid1_ItemClick(object sender, Infocom.Allegro.Web.WebControls.ItemClickEventArgs e)
		{
			if (!dtlChangeFlg)
			{
				int itemIndex = e.ItemIndex;
				//仮データは削除
				if (rowData.IsExistsTemporary)
				{
					rowData.RollBack(true);
					if (itemIndex > DataGrid1.EditItemIndex)
					{
						itemIndex = itemIndex - 1;
					}
				}
				insertFlg = false;

				setDataGridProperty(rowData.Dt);

				// 新規行初期化
				clearNewControlValue();
				setNewControlCondition(false);

				DataGrid1.EditItemIndex = itemIndex;
			}
		}

		private void DataGrid1_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
		{
// 管理番号 K22270 From
			if (e.Item.ItemIndex == -1)
				return;
// 管理番号 K22270 To
			int editNo			= int.Parse(DataGrid1.DataKeys[e.Item.ItemIndex].ToString());
			int itemIndex		= e.Item.ItemIndex;
			int editItemIndex	= 0;
			bool result			= false;
// 管理番号 B15657 From
			rowData.KeyCurCode	= this.KeyCurrencyCode;
// 管理番号 B15657 To

// 管理番号 K24153 From
			// 明細のコマンド実行時、チェックに利用する納入区分の値を最新化する
			rowData.DeliType = this.DeliTypeWRadio.Checked ? "W" : "D";
// 管理番号 K24153 To

			if (!dtlChangeFlg)
			{
				//挿入中に行更新ボタン以外を押下した場合、挿入をキャンセルする
// 管理番号 K24789 From
//				if (rowData.IsExistsTemporary && (e.CommandName!="Update" && e.CommandName!="LotDtil"))
				if (rowData.IsExistsTemporary && (e.CommandName!="Update" && e.CommandName!="LotDtil" && e.CommandName!="TaxInfo"))
// 管理番号 K24789 To
				{
					rowData.RollBack(true);
				}

				switch (e.CommandName)
				{
						// 行挿入
					case "Insert":
// 管理番号K27057 From
						rowData.CustomItemDtil.Clear();
// 管理番号K27057 To
						if (insertFlg == true && this.DataGrid1.EditItemIndex != -1 && itemIndex > this.DataGrid1.EditItemIndex)
						{
							itemIndex-- ;
// 管理番号 B23801 From
							result = insertDetailRow(e.Item.DataSetIndex-1);
// 管理番号 B23801 To
						}
// 管理番号 B23801 From
//// 管理番号 K22270 From
////                      result = insertDetailRow(itemIndex);
//                        result = insertDetailRow(e.Item.DataSetIndex);
//// 管理番号 K22270 To
						else
						{
							result = insertDetailRow(e.Item.DataSetIndex);
						}
// 管理番号 B23801 To
						editItemIndex = itemIndex;
						// insertFlgを立てるのはここのみ
						insertFlg = true;
						break;
						// 行更新
					case "Update":
						result = editDetailRow(itemIndex);
						if(result)
						{
							editItemIndex = -1;
						}
						insertFlg = false;
						break;
						// 行削除
					case "Delete":
						result = deleteDetailRow(editNo);
						editItemIndex = -1;
						insertFlg = false;
						break;
						//ロット詳細
					case "LotDtil":
						result = true;
						lotDiff = true;
						break;
// 管理番号 K24789 From
						// 税情報
					case "TaxInfo":
						result = true;
						lotDiff = true;
						DataGridItem editRow = DataGrid1.Items[e.Item.ItemIndex];
						var taxInfoBtn	= (StyledButton)editRow.FindControl("EditTaxInfoButton");

						if (this.TaxInfoChgFlgHdn.Value == "1")
						{
							//img/SC_c1_ctax_on.gif
							taxInfoBtn.CssClass = "tiny_changed";
						}
						break;
// 管理番号 K24789 To
				}
			}
			if (result)
			{
// 管理番号 K24789 From
//				if (e.CommandName!="LotDtil")
				if (e.CommandName!="LotDtil" && e.CommandName!="TaxInfo")
// 管理番号 K24789 To
				{
					if (e.CommandName != "Insert")
					{
						IsDirty = true;
// 管理番号 B23588 From
						setAmtTtl(true);
// 管理番号 B23588 To
					}
// 管理番号 B23588 From
//					setAmtTtl(true);
// 管理番号 B23588 To
					setDataGridProperty(rowData.Dt);
					DataGrid1.EditItemIndex = editItemIndex;
// 管理番号 B23801 From
					clearNewControlValue();
// 管理番号 B23801 To
					if (editItemIndex == -1)
					{
						if(InpPanel.Visible)
						{
							setNewControlCondition(true);
							FocusControl(InpProdCodeText.ID);
						}
						else
						{
							FocusControl(UpdateButton.ID);
						}
					}
					else
					{
						setNewControlCondition(false);
						FocusControl(DataGrid1.Items[editItemIndex].ClientID + "_EditProdCodeText");
					}
				}
// 管理番号 K24789 From
				else if (e.CommandName == "TaxInfo")
				{
					FocusControl(DataGrid1.Items[itemIndex].ClientID + "_EditUpdateButton");
				}
// 管理番号 K24789 To
				else
				{
// 管理番号K27058 From
//					if(PuModeTypeList.SelectedValue == "2")
					if (puModeType == "2")
// 管理番号K27058 To
					{
						FocusControl(DataGrid1.Items[itemIndex].ClientID + "_EditUpdateButton");
					}
// 管理番号 B22050 From
//					else if(((CustomDropDownList)e.Item.FindControl("EditUnitList")).Enabled)
//					{
//						FocusControl(DataGrid1.Items[itemIndex].ClientID + "_EditUnitList");
//					}
// 管理番号 B22050 To
					else
					{
						FocusControl(DataGrid1.Items[itemIndex].ClientID + "_EditPuPriceText");
					}
				}
			}
			else
			{
				lotDiff = true;
			}
		}
// 管理番号 K22270 From
		private void DataGrid_PageIndexChanged(object source, System.Web.UI.WebControls.DataGridPageChangedEventArgs e)
		{
				DataGrid1.CurrentPageIndex  = e.NewPageIndex;
				rowData.RollBack(true);
				this.insertFlg  = false;
// 管理番号 B23801 From
				clearNewControlValue();
// 管理番号 B23801 To
				setNewControlCondition(true);
                DataGrid1.EditItemIndex = -1;
			    setDataGridProperty(rowData.Dt);
			    useBind = true;
		}
// 管理番号 K22270 To
		#endregion

		#region 行更新(画面をＩＦへ設定)
		private void RegistButton_Click(object sender, EventArgs e)
		{
// 管理番号 K24153 From
			// 行更新時、チェックに利用する納入区分の値を最新化する
			rowData.DeliType = this.DeliTypeWRadio.Checked ? "W" : "D";
// 管理番号 K24153 To
// 管理番号 B21076 From
			if (!dtlChangeFlg)
			{
// 管理番号 B21076 To
				bool result = false;
				string focusControl = InpProdCodeText.UniqueID;

				//IFにデータ設定
				rowCtl = GetControls(null);
				IF_SC_MM_05_S02_DetailRowData detail = setDetailRowData(rowCtl);

				if (detail.HasErrors)
				{
					setMessageLabel(detail.ErrorMessage);
				}
				else
				{
					//登録
// 管理番号K27057 From
//					// 管理番号 B11723・B11796 From
//					//				result = rowData.InsertDetailRow(this.CommonData, detail);
//					result = rowData.InsertDetailRow(this.CommonData, detail, double.Parse(curDigit), AmtRoundType);
//					// 管理番号 B11723・B11796 To
					result = rowData.InsertDetailRow(this.CommonData, detail, double.Parse(curDigit), AmtRoundType, CustomItem.CreateTag(CommonData,rowCtl.CustomItemPanel));
// 管理番号K27057 To
					if (result)
					{
						setAmtTtl(true);
						setDataGridProperty(rowData.Dt);
						IsDirty = true;
						clearNewControlValue();

// 管理番号K26528 From
//						ScrollBottom();
// 管理番号K26528 To

						setNewControlCondition(true);
					}
					if (rowData.HasErrors)
					{
						setMessageLabel(rowData.ErrorMessage);
					}
// 管理番号 K22270 From
					else
					{
						if (DataGrid1.Items.Count == DataGrid1.PageSize)
						{
							DataGrid1.DataBind();
							DataGrid1.CurrentPageIndex = DataGrid1.PageCount - 1;
						}
					}
// 管理番号 K22270 To
				}

				//エラーの場合はロットの差分を保持する
				lotDiff = !result;
				FocusControl(focusControl);

// 管理番号 B21076 From
			}
// 管理番号 B21076 To
		}

		private bool insertDetailRow(int insertItemId)
		{
			IF_SC_MM_05_S02_DetailRowData detail = new IF_SC_MM_05_S02_DetailRowData();
			detail.SetPuLineId(insertItemId.ToString());
			// 管理番号 B11723・B11796 From
			//			rowData.InsertDetailRow(this.CommonData, detail);
			rowData.InsertDetailRow(this.CommonData, detail, double.Parse(curDigit), AmtRoundType);
			// 管理番号 B11723・B11796 To
			if (rowData.HasErrors)
			{
				setMessageLabel(rowData.ErrorMessage);
				return false;
			}

			return true;
		}

		private bool editDetailRow(int editIndex)
		{
			string strFocusID;
			bool result = false;
			DataGridItem editRow = DataGrid1.Items[editIndex];

			//IFにデータ設定
			rowCtl = GetControls(editRow);
			IF_SC_MM_05_S02_DetailRowData detail = setDetailRowData(rowCtl);

			if (detail.HasErrors)
			{
				setMessageLabel(detail.ErrorMessage);
				strFocusID = rowCtl.PuQtText.Enabled ? rowCtl.PuQtText.ClientID : rowCtl.PuPriceText.ClientID ;
				FocusControl(strFocusID);
				return false;
			}

			//更新
			rowData.IsPoRef = refType == RefCodeType.PO;
// 管理番号K27057 From
//			// 管理番号 B11723・B11796 From
//			//			result = rowData.EditDetailRow(this.CommonData, detail);
//			result = rowData.EditDetailRow(this.CommonData, detail, double.Parse(curDigit), AmtRoundType);
//			// 管理番号 B11723・B11796 To
			result = rowData.EditDetailRow(this.CommonData, detail, double.Parse(curDigit), AmtRoundType, CustomItem.CreateTag(CommonData,rowCtl.CustomItemPanel));
// 管理番号K27057 To
			if (!result)
			{
				setMessageLabel(rowData.ErrorMessage);
// 管理番号 B22497 From
//				strFocusID = rowCtl.PuQtText.Enabled ? rowCtl.PuQtText.ClientID : rowCtl.PuPriceText.ClientID ;
                strFocusID = rowCtl.ProdCodeText.ClientID;
// 管理番号 B22497 To
                FocusControl(strFocusID);
				return false;
			}
// 管理番号B25595 From
			// 修正かつ返品ではない場合のみチェックを行う
// 管理番号K27058 From
//			if ((paramType == ParamCodeType.MOD) && (this.PuModeTypeList.SelectedValue != "2" && this.RefPuText.Text.Length == 0))
			if ((paramType == ParamCodeType.MOD) && (this.puModeType != "2" && this.RefPuText.Text.Length == 0))
// 管理番号K27058 To
			{
				int ret = 0;
				decimal editId = (decimal)DataGrid1.DataKeys[editIndex];
				ret = BL_SC_MM_05_S02.CheckPuLot(CommonData, keyColumn, editId, rowData);
				if (ret < 0)
				{
					//後続処理が行われているため、[ロット番号]は変更できません。
					setMessageLabel(HtmlMessage(AllegroMessage.SC_MS_S10060(MultiLanguage.Get("SC_CS000295")), MessageLevel.Warning));
					strFocusID = rowCtl.ProdCodeText.ClientID;
					FocusControl(strFocusID);
					return false;
				}
			}
// 管理番号B25595 To
			if (rowData.HasErrors)
			{
				if(rowData.HasWarning)
				{
					setMessageLabel(HtmlMessage(rowData.InnerMessage,MessageLevel.Info));
				}
				else
				{
					setMessageLabel(rowData.ErrorMessage);
					strFocusID = rowCtl.PuQtText.Enabled ? rowCtl.PuQtText.ClientID : rowCtl.PuPriceText.ClientID ;
					FocusControl(strFocusID);
				}
			}
			return true;
		}

		private bool deleteDetailRow(int deleteIndex)
		{
			rowData.DeleteDetailRow(this.CommonData, deleteIndex);

			if (rowData.HasErrors)
			{
				setMessageLabel(rowData.ErrorMessage);
				return false;
			}
			return true;
		}
		//IFにデータ設定
		private IF_SC_MM_05_S02_DetailRowData setDetailRowData(SC_MM_05_S02_ROW_CONTROLS ctl)
		{
			bool isNewRow			= ctl.Inp == "1";
			bool qtDecimalUseFlg	= ctl.QtDecimalUseFlg.Text=="1";
			string prodType			= ctl.ProdType.Text.Trim();

// 管理番号 K24285 From
			rowData.RefPuNo = RefPuText.Text.Trim();
// 管理番号 K24285 To
// 管理番号 K25647 From
			rowData.MyCompQtDecimalUseFlg = this.QtDecimalUseFlg;
// 管理番号 K25647 To

			IF_SC_MM_05_S02_DetailRowData detail = new IF_SC_MM_05_S02_DetailRowData();

			//規格、フラグを設定
			detail.ProductSpecUseType	= ProductSpecUseType;
			detail.ProdSpec1CodeTitle	= ProductSpec1Name;
			detail.ProdSpec2CodeTitle	= ProductSpec2Name;
			detail.QtDecimalUseFlg		= ctl.QtDecimalUseFlg.Text.Trim();
			detail.IsMod                = paramType==ParamCodeType.MOD;
// 管理番号 K24285 From
			bool allowNegative = false;
			//在庫管理しない商品
			if (ctl.StockAdminFlg.Text == "0")
			{
				//発注・入荷参照しない、仕入形態が通常または返品の場合、マイナス数量を許可
				if (this.PoRefText.Text.Length == 0 && this.RcptRefText.Text.Length == 0 &&
// 管理番号K27058 From
//					(this.PuModeTypeList.SelectedValue == "1" || this.PuModeTypeList.SelectedValue == "2"))
					(this.puModeType == "1" || this.puModeType == "2"))
// 管理番号K27058 To
				{
					allowNegative = true;
				}
			}
// 管理番号 K24285 To
// 管理番号 K25647 From
			detail.QtDecimalDigit	= this.QtDecimalDigit;
			detail.CurDigit			= this.curDigit;
			detail.PriceDecimalDigit= this.PriceDecimalDigit;
// 管理番号 K25647 To

			//行ID
			detail.SetPuLineId(ctl.PuLineId);
			if(ctl.RcptLineId.Length > 0)
			{
				detail.RcptNo = this.RcptRefText.Text.Trim();
				detail.SetRcptLineId(ctl.RcptLineId);
			}
			if(ctl.PoLineId.Length > 0)
			{
				detail.PoNo = this.PoRefText.Text.Trim();
				detail.SetPoLineId(ctl.PoLineId);
			}

			//商品
			detail.ProdCode			= ctl.ProdCodeText.Text.Trim();

			detail.ProdPuName		= ctl.ProdPuNameText.Text.Trim();
			detail.ProdName			= ctl.ProdNameHdn.Value;
			detail.ProdShortName	= ctl.ProdShortNameHdn.Value;

			detail.ProdType			= ctl.ProdType.Text.Trim();

			//規格
			detail.ProdSpec1Code	= ctl.ProdSpec1List.SelectedValue;
			detail.ProdSpec1Name	= ctl.ProdSpec1List.SelectedItem.Text;
			detail.ProdSpec2Code	= ctl.ProdSpec2List.SelectedValue;
			detail.ProdSpec2Name	= ctl.ProdSpec2List.SelectedItem.Text;

			//倉庫
			detail.WhCode			= ctl.WhCodeText.Text.Trim();
			detail.WhShortName		= ctl.WhNameLabel.Text;

			//数量、単位
// 管理番号 K24285 From
//			detail.SetPuQt(prodType == "2" ? "1" : ctl.PuQtText.Text.Trim(), qtDecimalUseFlg);
			detail.SetPuQt(prodType == "2" ? "1" : ctl.PuQtText.Text.Trim(), allowNegative, qtDecimalUseFlg);
// 管理番号 K24285 To
			detail.UnitCode			= ctl.UnitList.SelectedValue;
			detail.UnitShortName	= ctl.UnitList.SelectedItem.Text.Trim();
			// 管理番号 B11723・B11796 From
			//			detail.SetPuPrice(Common.FormatAmt(ctl.PuPriceText.Text.Trim(), curDigit ,this.PriceDecimalUseFlg, "2"), this.PriceDecimalUseFlg);
			//			detail.SetInitPuPrice(Common.FormatAmt(ctl.InitPuPriceText.Text.Trim(), curDigit, this.PriceDecimalUseFlg, "2"), this.PriceDecimalUseFlg);
			//			detail.SetPuPlanPrice(Common.FormatAmt(ctl.PuPlanPriceLabel.Text.Trim(), curDigit, this.PriceDecimalUseFlg, "2"), this.PriceDecimalUseFlg);
			// 管理番号 B13502 From
			//			detail.SetPuPrice(ctl.PuPriceText.Text.Trim(), curDigit != "0" || this.PriceDecimalUseFlg);
// 管理番号 K25647 From
//			byte precision = 13;
//			byte scale = 2;
//			if (!PriceDecimalUseFlg)
//			{
//				switch (curDigit)
//				{
//					case "0":
//						precision = 11;
//						scale = 0;
//						break;
//					case "1":
//						precision = 12;
//						scale = 1;
//						break;
//					case "2":
//						break;
//				}
//			}
//			detail.SetPuPrice(ctl.PuPriceText.Text.Trim(), precision, scale);
			detail.SetPuPrice(ctl.PuPriceText.Text.Trim());
// 管理番号 K25647 To
			// 管理番号 B13502 To
			detail.SetInitPuPrice(ctl.InitPuPriceText.Text, this.PriceDecimalUseFlg);
			detail.SetPuPlanPrice(ctl.PuPlanPriceLabel.Text, this.PriceDecimalUseFlg);
			// 管理番号 B11723・B11796 To

			// 管理番号 B13878 From
			// 単価未決
			if (ctl.PriceUndecidedFlgCheck.Checked)
			{
				detail.PriceUndecidedFlg = "1";
			}
			else
			{
				detail.PriceUndecidedFlg = "0";
			}
			// 管理番号 B13878 To
			//行摘要
			detail.LineRemarksCode	= ctl.RemarksCodeText.Text.Trim();
			detail.LineRemarks		= ctl.RemarksText.Text.Trim();
// 管理番号K27525 From
			// 帳簿控除理由
			detail.BookDeductionReasonCode	= ctl.BookDeductionReasonCodeList.SelectedValue;
			if (ctl.BookDeductionReasonCodeList.SelectedValue.Length > 0)
			{
				detail.BookDeductionReasonName	= ctl.BookDeductionReasonCodeList.SelectedItem.Text;
			}
			else
			{
				detail.BookDeductionReasonName = string.Empty;
			}
// 管理番号K27525 To

			//消費税計算区分、税率、入数
// 管理番号 K24789 From
//			detail.CtaxCalcType		= ctl.CtaxCalcType.Text;
//			detail.CtaxRateCode		= ctl.CtaxRateCode.Text;
			detail.CtaxCalcType		= ctl.CtaxCalcTypeHdn.Value;
			detail.CtaxRateCode		= ctl.CtaxRateCodeHdn.Value;
			detail.CtaxTypeCode		= ctl.CtaxTypeCodeHdn.Value;
			detail.TaxInfoChgFlg	= ctl.TaxInfoChgFlgHdn.Value;
// 管理番号 K24789 To
			detail.SetIncludeQt(ctl.IncludeQt.Text);

			//値引フラグ
			detail.DiscFlg = detail.PuPlanPrice > detail.PuPrice ? "1" : "0";

			//その他隠しフィールド
			detail.DispControlType	= ctl.DispControlType.Text;
			detail.AllowProdName	= ctl.AllowProdName.Text;
			detail.StockAdminFlg	= ctl.StockAdminFlg.Text;
			detail.LotAdminFlg		= ctl.LotAdminFlg.Text;
// 管理番号 K25322 From
			detail.LotStockValuationFlg	= ctl.LotStockValuationFlg.Text;		//ロット別在庫評価
// 管理番号 K25322 To
			detail.SetStockUnitStdSellPrice(ctl.StdSellPrice.Text.Replace(",", string.Empty), curDigit != "0" || PriceDecimalUseFlg);
			detail.ProdEditFlg      = ctl.ProdEditLabel.Text;
			detail.IsRcptExecute	= ctl.IsRcptExecuteFlg.Text;

			//有効在庫数量(仕入では未使用)
			detail.SetValidQt("0", qtDecimalUseFlg);
// 管理番号 B14307 From
			rowData.CurCode		= CurCodeList.SelectedValue;
			rowData.KeyCurCode = this.KeyCurrencyCode;
			rowData.CurRoundType = this.CurRoundType;
// 管理番号 B14307 To

			// 消費税率取得
			if (ctl.ProdType.Text == "0")
			{
				string compareDate = DateValidator.IsDate(PuDateText.Text.Trim()) ? PuDateText.Text.Trim() : todayDate;
				string suplShortName = string.Empty;

				if(!Supl.IsExistsSupl(this.CommonData, SuplCodeText.Text.Trim(), this.CompanyCodeLength, out suplShortName, compareDate, false, "0", false))
				{
// 					detail.AddErrorMessage(AllegroMessage.S20005("仕入先")); //K24546
					detail.AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS000784")));
					if(SuplCodeText.Enabled)
					{
						FocusControl(SuplCodeText.ID);
					}
				}
				else
				{
// 管理番号 K24789 From
//					string ctaxRate = string.Empty;
//					string ctaxTypeCode = this.PuModeTypeList.SelectedValue=="2" ? rowData.PuReturnCtaxTypeCode : rowData.PuCtaxTypeCode ;
//					if (CtaxTypeCtaxRateRelation.GetCtaxRate(CommonData, ctaxTypeCode, ctl.CtaxRateCode.Text, compareDate, "0", out ctaxRate))
					
					if (
						   (rowData.ImposeFlg == "1" && detail.CtaxCalcType == "N")	// 課税する、かつ消費税計算区分が「計算しない」
						|| (rowData.ImposeFlg == "0" && detail.CtaxCalcType != "N")	// 課税しない、かつ消費税計算区分が「外税」「内税」
					)
					{
						//[仕入先]の消費税区分と明細の[消費税計算区分］の組合せが不正です。[仕入先］マスタが変更されていないかをご確認ください。
						detail.AddErrorMessage(AllegroMessage.S20045(MultiLanguage.Get("SC_CS000784"), MultiLanguage.Get("CM_CS002952")));
						return detail;
					}

					string ctaxRate			= string.Empty;
					string ctaxSubjectType	= string.Empty;
					string dealDate	= DateValidator.IsDate(DealDateText.Text.Trim()) ? DealDateText.Text.Trim() : todayDate;

					if (CtaxTypeCtaxRateRelation.GetCtaxRate(CommonData, ctl.CtaxTypeCodeHdn.Value + ctl.CtaxRateCodeHdn.Value, dealDate, false, out ctaxRate, out ctaxSubjectType))
// 管理番号 K24789 To
					{
// 管理番号 K24789 From
						if (ctaxSubjectType == "N" && detail.CtaxCalcType != "N")
						{
							// 消費税科目区分が「なし」、かつ消費税計算区分が「外税」「内税」
							//消費税区分の税科目がなしの場合、国内でかつ課税する[仕入先]は指定できません。
							detail.AddErrorMessage(AllegroMessage.S20044(MultiLanguage.Get("SC_CS000784")));
						}
// 管理番号 K24789 To
						// 税率(商品+仕入先)
						detail.SetCtaxRate(ctaxRate);
					}
					else
					{
// 管理番号 K24789 From
//						detail.AddErrorMessage(AllegroMessage.SC_MS_S10016);
						//［消費税率］ が取得できませんでした。［消費税］のマスタをご確認ください。
						detail.AddErrorMessage(AllegroMessage.S10078(MultiLanguage.Get("SC_CS001210"),MultiLanguage.Get("CM_CS002946")));
// 管理番号 K24789 To
					}
				}
			}
			else
			{
				detail.SetCtaxRate("0");
			}
// 管理番号 B12929 From
			detail.PriceUpdateFlg = ctl.PriceUpdateFlgHdn.Value;
// 管理番号 B12929 To
// 管理番号K27057 From
			rowData.SetCustomItemValidator(rowData.CustomItemDtil);
			CustomItem.SetIF(CommonData, rowCtl.CustomItemPanel, rowData.CustomItemDtil);
// 管理番号K27057 To

			return detail;
		}
		#endregion

		#region 新規行制御
		//詳細ロットの戻り
		private void InpLotDtilButton_Click(object sender, EventArgs e)
		{
			lotDiff = true;
// 管理番号 B22050 From
//			FocusControl(this.InpUnitList.ID);
			FocusControl(this.InpPuPriceText.ID);
// 管理番号 B22050 To
		}

// 管理番号 K24789 From
		//税情報の戻り
		private void InpTaxInfoButton_Click(object sender, EventArgs e)
		{
			lotDiff = true;
			if (this.TaxInfoChgFlgHdn.Value == "1")
			{
				//img/SC_c1_ctax_on.gif
				this.InpTaxInfoButton.CssClass = "tiny_changed";
			}
			FocusControl(RegistButton.ClientID);
		}
// 管理番号 K24789 To

		private void InpPanel_Click(object sender, System.EventArgs e)
		{
			if (!dtlChangeFlg)
			{
				//仮データは削除
				if (rowData.IsExistsTemporary)
				{
					rowData.RollBack(true);
				}
				insertFlg = false;

				setDataGridProperty(rowData.Dt);
				DataGrid1.EditItemIndex = -1;
				if (paramType != ParamCodeType.VIEW)
				{
					setNewControlCondition(true);
					setMessageLabel(string.Empty);
				}
				FocusControl(InpProdCodeText.ClientID);
			}
		}

		private void setNewControlCondition(bool condition)
		{
			string prodName = string.Empty;
			bool condition2 = Prod.IsExists(this.CommonData, InpProdCodeText.Text, "PO", string.Empty, out prodName);
			bool directWh   = this.DeliTypeDRadio.Checked;
			bool isLotOk	=
				this.InpProdSpec1List.SelectedValue.Length > 0	&&
				this.InpProdSpec2List.SelectedValue.Length > 0	&&
				this.InpUnitList.SelectedValue.Length > 0		&&
				this.InpWhCodeText.Text.Trim().Length > 0		&&
				this.InpWhCodeText.Text.Trim()!="99999";

			// 新規エリアのEnable制御
			InpProdCodeText.Enabled = condition;
			InpProdNameText.Enabled = condition && condition2;
			switch (ProductSpecUseType)
			{
				case "0":
					InpProdSpec1List.Enabled = false;
					InpProdSpec2List.Enabled = false;
					break;
				case "1":
					InpProdSpec1List.Enabled = condition && condition2;
					InpProdSpec2List.Enabled = false;
					break;
				case "2":
					InpProdSpec1List.Enabled = condition && condition2;
					InpProdSpec2List.Enabled = condition && condition2;
					break;
			}

			if (directWh)
			{
				InpWhCodeText.Text			= string.Empty;
				InpWhShortNameLabel.Text	= string.Empty;
				InpLotDtilButton.Enabled	= false;
			}
			else
			{
				InpLotDtilButton.Enabled	= condition && condition2 && isLotOk;
				InpLotDtilButton.Visible	= this.LotAdminFlg;

			}

			InpWhCodeText.Enabled		    = false;
			InpPuQtText.Enabled				= condition;
			InpUnitList.Enabled				= condition && condition2;
			InpPuPriceText.Enabled			= condition && condition2;
			// 管理番号 B13878 From
			if (this.PriceUndecidedUseFlg)
			{
				//自社マスタ（販売）の単価未決フラグが使用するときのみ表示
				InpPriceUndecidedFlgCheck.Enabled = condition && condition2;
			}
			else
			{
				InpPriceUndecidedFlgCheck.Visible = false;
			}
			// 管理番号 B13878 To
			InpRemarksCodeText.Enabled		= condition;
			InpRemarksText.Enabled			= condition;
// 管理番号K27525 From
			InpBookDeductionReasonCodeList.Enabled	= condition;
// 管理番号K27525 To
// 管理番号 K24789 From
			InpTaxInfoButton.Enabled		= condition && condition2;
// 管理番号 K24789 To
			RegistButton.Enabled			= condition && condition2;

			InpPanel.AutoPostBack = !condition;

			if (condition)
			{
				DataGrid1.EditItemIndex = -1;
			}
// 管理番号K27057 From
			InpCustomItemPanel.Enable = condition;
// 管理番号K27057 To
		}

		private void clearNewControlValue()
		{
			this.InpProdCodeText.Text		= string.Empty;
			this.InpProdNameText.Text	= string.Empty;
			this.InpWhCodeText.Text			= string.Empty;
			this.InpWhShortNameLabel.Text	= string.Empty;
			this.InpPuQtText.Text			= string.Empty;
			this.InpPuPriceText.Text		= string.Empty;
			// 管理番号 B13878 From
			this.InpPriceUndecidedFlgCheck.Checked = false;
			// 管理番号 B13878 To
			this.InpPuMoneyLabel.Text		= string.Empty;
			this.InpRemarksCodeText.Text	= string.Empty;
			this.InpRemarksText.Text		= string.Empty;
// 管理番号K27525 From
			this.InpBookDeductionReasonCodeList.SelectedIndex = 0;
// 管理番号K27525 To

			setProdDropDown(string.Empty, InpProdSpec1List, InpProdSpec2List, InpUnitList);
// 管理番号K27057 From
			InpCustomItemPanel.Reset();
// 管理番号K27057 To
		}

		#endregion

		#region 商品関連の制御
		//商品価格取得
		private bool SetProdPrice(object sender, SC_MM_05_S02_ROW_CONTROLS ctl)
		{
			string suplCode = string.Empty;
			string suplSbno = string.Empty;
			rowData.DivideSuplCode(this.SuplCodeText.Text.Trim(), this.CompanyCodeLength, out suplCode, out suplSbno);

			//商品情報
			Infocom.Allegro.SC.IF_SC_MS_Prod prodInfo = new Infocom.Allegro.SC.IF_SC_MS_Prod();
			DateTime puDate	= this.PuDateText.Text == string.Empty ? DateTime.Today: DateTime.Parse(this.PuDateText.Text);
			prodInfo.PriceType		= "2";//購入価格
			prodInfo.IsOverseas		= "0";
			prodInfo.ProdCode		= ctl.ProdCodeText.Text.Trim();
			prodInfo.ProdSpec1Code	= ctl.ProdSpec1List.SelectedValue;
			prodInfo.ProdSpec2Code	= ctl.ProdSpec2List.SelectedValue;
			prodInfo.UnitCode		= ctl.UnitList.SelectedValue;
			//管理番号 B13502 From
			//			prodInfo.CurCode		= this.CurCodeLabel.Text.Trim();
			prodInfo.CurCode		= CurCodeList.SelectedValue;
			//管理番号 B13502 To
			prodInfo.CustSpulCode	= suplCode;
			prodInfo.CustSpulSbno	= suplSbno;
			prodInfo.DeptCode		= this.DeptCodeText.Text.Trim();
			prodInfo.TargetDate		= puDate.ToString();
			// 管理番号 B13877 From
// 管理番号 K24389 From
			prodInfo.BasisQt = ctl.PuQtText.Text.Trim();
// 管理番号 K24389 To

			if (ProjCodeText.Text.Trim().Length > 0)
			{
				rowData.DivideProjCode(this.ProjCodeText.Text.Trim(), this.ProjectCodeLength);
				prodInfo.ProjCode = rowData.ProjCode;
				prodInfo.ProjSbno = rowData.ProjSbno;
			}
			else
			{
				prodInfo.ProjCode = rowData.ProjCode = string.Empty;
				prodInfo.ProjSbno = rowData.ProjSbno = string.Empty;
			}
			// 管理番号 B13877 To
// 管理番号 K24789 From
			prodInfo.CtaxImposeFlg	= rowData.ImposeFlg;
// 管理番号K27058 From
//			prodInfo.ModeType		= this.PuModeTypeList.SelectedValue;
			prodInfo.ModeType		= this.puModeType;
// 管理番号K27058 To
// 管理番号 K24789 To

			//商品共通
			bool ret = Prod.GetPrice(this.CommonData, prodInfo);
			if (ret)
			{
				decimal puQt = ctl.PuQtText.Text.Trim() != string.Empty ? decimal.Parse(ctl.PuQtText.Text) : 0M;
				if (sender == ctl.ProdCodeText)
				{
					ctl.ProdPuNameText.Text = prodInfo.ProdShortName;
					ctl.ProdPuNameText.Text	   = prodInfo.ProdShortName;

					ctl.ProdNameHdn.Value			= prodInfo.ProdName;
					ctl.ProdShortNameHdn.Value	= prodInfo.ProdShortName;
// 管理番号 K24789 From
					ctl.CtaxCalcTypeHdn.Value		= prodInfo.CtaxCalcType;
					ctl.CtaxTypeCodeHdn.Value		= prodInfo.CtaxTypeCode;
					ctl.CtaxRateCodeHdn.Value		= prodInfo.CtaxRateCode;
					ctl.TaxInfoChgFlgHdn.Value		= "0";
					//img/SC_c1_ctax_off.gif
					ctl.TaxInfoButton.CssClass = "tiny";
// 管理番号 K24789 To
				}
				// 管理番号 B11723・B11796 From
				//				decimal stockUnitStdSellPrice = prodInfo.StdPrice * prodInfo.IncludeQt;
				//				ctl.StdSellPrice.Text		= Common.FormatAmt(Round.GetRound(this.CommonData, stockUnitStdSellPrice, double.Parse(curDigit), this.StockValuationFractionRoundType), curDigit, false, "1");
				//				ctl.PuPriceText.Text		= Common.FormatAmt(prodInfo.Price.ToString(), curDigit, PriceDecimalUseFlg, "1");
				//				ctl.PuPlanPriceLabel.Text   = Common.FormatAmt(prodInfo.Price.ToString(), curDigit, PriceDecimalUseFlg, "1");
				ctl.StdSellPrice.Text		= prodInfo.StdPrice.ToString();
// 管理番号 K25647 From
//				ctl.PuPriceText.Text		= Common.FormatAmt(prodInfo.Price, curDigit, PriceDecimalUseFlg, "2");
				ctl.PuPriceText.Text		= ControlFormat.ToSlipPrice(prodInfo.Price, this.PriceDecimalDigit, byte.Parse(this.curDigit), ControlFormat.FormatType.Input);
// 管理番号 K25647 To
				ctl.PuPlanPriceLabel.Text   = prodInfo.Price.ToString();
				if (puQt > 0M)
				{
// 管理番号 K25514 From
//					ctl.PuMoneyLabel.Text = Common.FormatAmt(Round.GetRound(CommonData, prodInfo.Price * puQt, double.Parse(curDigit), AmtRoundType), curDigit, this.PriceDecimalUseFlg, "1");
					ctl.PuMoneyLabel.Text = Common.FormatAmt(Round.GetRound(CommonData, prodInfo.Price * puQt, double.Parse(curDigit), AmtRoundType), curDigit, false, "1");
// 管理番号 K25514 To
				}
				// 管理番号 B11723・B11796 To

// 管理番号 B18058 From
//				ctl.CtaxCalcTypeLabel.Text	= prodInfo.CtaxCalcType=="I" ? "＊" : string.Empty;
// 管理番号 B18058 To
// 管理番号 K24789 From
//				ctl.CtaxCalcType.Text		= prodInfo.CtaxCalcType;
//				ctl.CtaxRateCode.Text		= prodInfo.CtaxRateCode;
// 管理番号 K24789 To
				ctl.ProdType.Text			= prodInfo.ProdType;
				ctl.IncludeQt.Text			= prodInfo.IncludeQt.ToString();
				ctl.DispControlType.Text	= prodInfo.DispControlType;
				ctl.AllowProdName.Text		= prodInfo.AllowProdNameCorrection ? "1" : "0";
				ctl.ProdTypeHidden.Value	= prodInfo.ProdType;
				ctl.DispTypeHidden.Value	= prodInfo.DispControlType;
				ctl.StockAdminFlg.Text		= prodInfo.StockAdminFlg ? "1" : "0";
				ctl.LotAdminFlg.Text		= prodInfo.LotAdminFlg ? "1" : "0";
// 管理番号 K25322 From
				ctl.LotStockValuationFlg.Text	= prodInfo.LotStockValuationFlg;
// 管理番号 K25322 To
				ctl.QtDecimalUseFlg.Text	= prodInfo.QtDecimalUseFlg ? "1": "0";

				// 管理番号 B11723・B11796 From
				//				if (prodInfo.Price > 0M)
				//				{
				//					ctl.PuPriceText.Text = Common.FormatAmt(prodInfo.Price, curDigit, this.PriceDecimalUseFlg, "2");
				//					if (puQt > 0M)
				//					{
				//						ctl.PuMoneyLabel.Text = Common.FormatQt(Round.GetRound(CommonData, prodInfo.Price * puQt, double.Parse(curDigit), AmtRoundType), this.QtDecimalUseFlg, "2");
				//					}
				//				}
				// 管理番号 B11723・B11796 To

				if (!prodInfo.StockAdminFlg)
				{
					ctl.WhCodeText.Text		= string.Empty;
					ctl.WhNameLabel.Text	= string.Empty;
				}
// 管理番号 B12929 From
				ctl.InitPuPriceHdn.Value = ctl.PuPriceText.Text;
// 管理番号 B12929 To
			}
			else
			{
				ctl.ProdPuNameText.Text	= string.Empty;
				ctl.ProdPuNameText.Text		= string.Empty;
// 管理番号 K25647 From
//				ctl.PuPriceText.Text		= Common.FormatQt(0M, this.QtDecimalUseFlg, "2");
				ctl.PuPriceText.Text = ControlFormat.ToSlipPrice(0M, this.PriceDecimalDigit, byte.Parse(this.curDigit), ControlFormat.FormatType.Input);
// 管理番号 K25647 To
// 管理番号 K25514 From
//				// 管理番号 B11723・B11796 From
//				//				ctl.PuMoneyLabel.Text		= Common.FormatQt(0M, this.QtDecimalUseFlg, "2");
//				ctl.PuMoneyLabel.Text		= Common.FormatAmt(0M, curDigit, this.PriceDecimalUseFlg, "1");
//				// 管理番号 B11723・B11796 To
				ctl.PuMoneyLabel.Text		= Common.FormatAmt(0M, curDigit, false, "1");
// 管理番号 K25514 To
				ctl.CtaxCalcTypeLabel.Text	= string.Empty;
// 管理番号 K24789 From
//				ctl.CtaxCalcType.Text		= string.Empty;
// 管理番号 K24789 To
				ctl.CtaxRate.Text			= string.Empty;
// 管理番号 K24789 From
//				ctl.CtaxRateCode.Text		= string.Empty; //消費税率コード
// 管理番号 K24789 To
				ctl.ProdType.Text			= string.Empty;
				ctl.DispControlType.Text	= string.Empty;
				ctl.IncludeQt.Text			= string.Empty;
				ctl.AllowProdName.Text		= "1";
				ctl.StockAdminFlg.Text		= string.Empty;
				ctl.LotAdminFlg.Text		= string.Empty;
// 管理番号 K25322 From
				ctl.LotStockValuationFlg.Text	= string.Empty;
// 管理番号 K25322 To
				ctl.QtDecimalUseFlg.Text	= string.Empty;
				ctl.ProdTypeHidden.Value	= string.Empty;
				ctl.DispTypeHidden.Value	= string.Empty;
// 管理番号 B12929 From
				ctl.InitPuPriceHdn.Value	= string.Empty;
// 管理番号 B12929 To
// 管理番号 K24789 From
				ctl.CtaxCalcTypeHdn.Value	= string.Empty;	//消費税計算区分
				ctl.CtaxRateCodeHdn.Value	= string.Empty; //消費税率コード
				ctl.CtaxTypeCodeHdn.Value	= string.Empty; //消費税区分コード
				ctl.TaxInfoChgFlgHdn.Value	= "0";			//税情報変更フラグ
				//img/SC_c1_ctax_off.gif
				ctl.TaxInfoButton.CssClass = "tiny";
// 管理番号 K24789 To
			}

			//初期値の保存
			ctl.InitPuPriceText.Text		= ctl.PuPriceText.Text;
			ctl.PriceUpdateFlgHdn.Value		= "0";

			return (ret);
		}
		//使用可否制御
		private void SetRowControlCondition(SC_MM_05_S02_ROW_CONTROLS ctl, bool IsExists)
		{
			string prodType		= ctl.ProdType.Text.Trim();					//商品区分
			bool isNomalProd	= ctl.ProdType.Text.Trim() == "0";			//商品区分
			bool IsDispType		= ctl.DispControlType.Text.Trim() == "D";	//表示制御区分
			bool IsAllowName	= ctl.AllowProdName.Text.Trim() == "1";		//商品名訂正許可フラグ
			bool IsLotAdmin		= ctl.LotAdminFlg.Text.Trim() == "1";		//ロット管理フラグ
			bool IsStockAdmin	= ctl.StockAdminFlg.Text.Trim() == "1";		//在庫管理フラグ
			bool IsDirectWh		= ctl.WhCodeText.Text.Trim() == "99999";	//直送倉庫"99999"か否か
// 管理番号 K25322 From
			bool IsLotStockValuation = ctl.LotStockValuationFlg.Text.Trim() == "1";		//ロット別在庫評価
// 管理番号 K25322 To
			bool IsProdEditFlg	= ctl.ProdEditLabel.Text.Trim() != "0";		//参照伝票の明細行の商品 or 制御用商品
			string prodSpecUseType = Prod.GetProdSpecUseType(this.CommonData, ctl.ProdCodeText.Text);
			bool lotDetailOk	= false;
// 管理番号K27058 From
//			bool IsReturnMode	= this.PuModeTypeList.SelectedValue=="2" && this.RefPuText.Text.Length > 0; //返品
			bool IsReturnMode	= this.puModeType == "2" && this.RefPuText.Text.Length > 0; //返品
// 管理番号K27058 To

			//商品情報あり
			if (IsExists)
			{
				//制御用商品
				if(prodType=="2")
				{
					ctl.ProdCodeText.Enabled	= IsProdEditFlg && !IsReturnMode;
					ctl.ProdPuNameText.Enabled	= IsAllowName;
					ctl.ProdSpec1List.Enabled	= false;
					ctl.ProdSpec2List.Enabled	= false;
					ctl.WhCodeText.Enabled		= false;
					ctl.LotDtilButton.Enabled	= false;
					ctl.PuQtText.Enabled		= false;
					ctl.UnitList.Enabled		= false;
					ctl.PuPriceText.Enabled		= IsDispType && !IsReturnMode;
					// 管理番号 B13878 From
					ctl.PriceUndecidedFlgCheck.Enabled = false;
					// 管理番号 B13878 To
					ctl.RemarksCodeText.Enabled	= false;
					ctl.RemarksText.Enabled		= false;
// 管理番号 K24789 From
					ctl.TaxInfoButton.Enabled	= false;
// 管理番号 K24789 To
					if(ctl.UpdateButton != null)
					{
						ctl.UpdateButton.Enabled = true;
					}
					ctl.RegistButton.Enabled	= true;

					ctl.WhCodeText.Text			= string.Empty;
					ctl.WhNameLabel.Text		= string.Empty;
					ctl.RemarksCodeText.Text	= string.Empty;
					ctl.RemarksText.Text		= string.Empty;
				}
				else
				{
					ctl.ProdCodeText.Enabled		= IsProdEditFlg                         && !IsReturnMode;
					ctl.ProdPuNameText.Enabled	= IsAllowName          && !IsReturnMode;
					ctl.ProdSpec1List.Enabled		= IsProdEditFlg && prodSpecUseType!="0" && !IsReturnMode;
					ctl.ProdSpec2List.Enabled		= IsProdEditFlg && prodSpecUseType=="2" && !IsReturnMode;
					ctl.WhCodeText.Enabled			= IsProdEditFlg && IsStockAdmin         && !IsReturnMode;
					ctl.UnitList.Enabled			= IsProdEditFlg                         && !IsReturnMode;
					//ロット詳細ボタン
					lotDetailOk =
// 管理番号 K25322 From
//						IsLotAdmin && IsStockAdmin && !IsDirectWh &&
						IsLotAdmin && (IsLotStockValuation || (IsStockAdmin && !IsDirectWh)) &&
// 管理番号 K25322 To
						ctl.ProdSpec1List.SelectedValue.Length > 0 &&
						ctl.ProdSpec2List.SelectedValue.Length > 0 &&
						ctl.UnitList.SelectedValue.Length > 0 &&
						ctl.WhCodeText.Text.Trim().Length > 0 ;
					ctl.LotDtilButton.Enabled	= lotDetailOk;
					if (!ctl.LotDtilButton.Visible || !ctl.LotDtilButton.Enabled)
					{
// 管理番号 B22050 From
//						ctl.WhCodeText.NextControlID = ctl.PuQtText.ID;
						ctl.UnitList.NextControlID = ctl.PuPriceText.ID;
// 管理番号 B22050 To
					}
					else
					{
// 管理番号 B22050 From
//						ctl.WhCodeText.NextControlID = ctl.LotDtilButton.ID;
						ctl.UnitList.NextControlID = ctl.LotDtilButton.ID;
// 管理番号 B22050 To
					}
					if (ctl.Inp!="1" && ctl.LotDtilButton.Enabled && ctl.LotDtilButton.ClientClickScript2.Trim().Length==0)
					{
						//編集行でかつ直接売上の場合だけ。
						StringBuilder sb = new StringBuilder();
						sb.Append("__openLotDetailWindowEditRow( ");
						sb.Append("'").Append(ctl.LotDtilButton.AppendedIDPart	).Append("',");
						sb.Append("'").Append("4"								).Append("',");
						sb.Append("'").Append(this.PuNoText.Text				).Append("',");
						sb.Append("'").Append("SM3"								).Append("',");
						sb.Append("'").Append("0"								).Append("')");
						ctl.LotDtilButton.ClientClickScript2 = sb.ToString();
					}
					ctl.PuQtText.Enabled		= true;
					ctl.PuPriceText.Enabled		= !IsReturnMode;
					// 管理番号 B13878 From
					if (rowData.CutoffFinFlg == "1")
					{
						ctl.PriceUndecidedFlgCheck.Enabled = false;
					}
					else
					{
						ctl.PriceUndecidedFlgCheck.Enabled = true;
					}
					// 管理番号 B13878 To
					ctl.RemarksCodeText.Enabled	= true;
					ctl.RemarksText.Enabled		= true;
// 管理番号 K24789 From
					ctl.TaxInfoButton.Enabled	= true;
// 管理番号 K24789 To
					if(ctl.UpdateButton!=null)
					{
						ctl.UpdateButton.Enabled = true;
					}
					ctl.RegistButton.Enabled	= true;

					if(!IsStockAdmin)
					{
						ctl.WhCodeText.Text		= string.Empty;
						ctl.WhNameLabel.Text	= string.Empty;
					}

					if (ctl.WhCodeText.Enabled)
					{
						ctl.ProdSpec2List.NextControlID = ctl.WhCodeText.ID;
					}
					else
					{
						if (ctl.LotDtilButton.Enabled)
						{
							ctl.ProdSpec2List.NextControlID = ctl.LotDtilButton.ID;
						}
						else
						{
							ctl.ProdSpec2List.NextControlID = ctl.PuQtText.ID;
						}
					}
				}
			}
			else
			{
				ctl.ProdCodeText.Enabled	= true;
				ctl.ProdPuNameText.Enabled	= false;
				ctl.ProdSpec1List.Enabled	= false;
				ctl.ProdSpec2List.Enabled	= false;
				ctl.WhCodeText.Enabled		= false;
				ctl.UnitList.Enabled		= false;
				ctl.LotDtilButton.Enabled	= false;
// 管理番号 B18953 From
//				ctl.PuQtText.Enabled		= false;
				ctl.PuQtText.Enabled		= true;
// 管理番号 B18953 To
				ctl.PuPriceText.Enabled		= false;
				// 管理番号 B13878 From
				ctl.PriceUndecidedFlgCheck.Enabled = false;
				// 管理番号 B13878 To
				ctl.RemarksCodeText.Enabled	= true;
				ctl.RemarksText.Enabled		= true;
// 管理番号 K24789 From
				ctl.TaxInfoButton.Enabled	= false;
// 管理番号 K24789 To
				if(ctl.UpdateButton != null)
				{
					ctl.UpdateButton.Enabled = false;
				}
				ctl.RegistButton.Enabled	= false;
			}
// 管理番号 B18951 From
				// 商品が存在しない場合、フッタの更新ボタンをEnterキーの遷移先とする
				ctl.PuQtText.SearchInMyParent	= IsExists;
				ctl.PuQtText.NextControlID		= IsExists ? ctl.UnitList.ID : this.UpdateButton.ID;
// 管理番号 B18951 To

			//小数点設定
			if(ctl.PuQtText.Enabled)
			{
// 管理番号 K25647 From
//				ctl.PuQtText.AllowDecimal	= this.QtDecimalUseFlg;
//				ctl.PuQtText.MaxLength		= this.QtDecimalUseFlg ? 13 : 9;
//				ctl.PuQtText.Precision		= this.QtDecimalUseFlg ? (byte)12 : (byte)9;
//				ctl.PuQtText.Scale			= this.QtDecimalUseFlg ? (byte)3 : (byte)0;
// 管理番号 K25647 To
// 管理番号 K24285 From
				//仕入数量マイナス入力制御
				bool allowNegative = false;
				if (ctl.StockAdminFlg.Text == "0")
				{
					//発注・入荷参照しない、仕入形態が通常または返品の場合、マイナス数量を許可
					if (PoRefText.Text.Length == 0 && RcptRefText.Text.Length == 0 &&
// 管理番号K27058 From
//						(PuModeTypeList.SelectedValue == "1" || PuModeTypeList.SelectedValue == "2"))
						(puModeType == "1" || puModeType == "2"))
// 管理番号K27058 To
					{
						allowNegative = true;
					}
				}
				ctl.PuQtText.AllowNegative = allowNegative;
// 管理番号 K24285 To
// 管理番号 K25647 From
				NumberBoxPreset.SetSlipQuantityMode(ctl.PuQtText, NumberBoxPreset.SlipQuantity.SCMM, ctl.PuQtText.AllowNegative, this.QtDecimalDigit);
// 管理番号 K25647 To
			}

			if(ctl.PuPriceText.Enabled)
			{
				//管理番号 B13502 From
				//				ctl.PuPriceText.AllowDecimal	= this.PriceDecimalUseFlg;
				//				ctl.PuPriceText.MaxLength		= this.PriceDecimalUseFlg ? 14 : 11;
				//				ctl.PuPriceText.Precision		= this.PriceDecimalUseFlg ? (byte)13 : (byte)11;
				//				ctl.PuPriceText.Scale			= this.PriceDecimalUseFlg ? (byte)2 : (byte)0;
// 管理番号 B18736 From
//				ctl.PuPriceText.AllowDecimal	= true;
//				ctl.PuPriceText.MaxLength		= 14;
//				ctl.PuPriceText.Precision		= 13;
//				ctl.PuPriceText.Scale			= 2;
				//使用可能な単価小数桁数の最大値は2とする
				if(int.Parse(curDigit) >= 3)
				{
					curDigit = "2";
				}
// 管理番号 K25647 From
//				ctl.PuPriceText.AllowDecimal	= (this.PriceDecimalUseFlg || curDigit != "0");
//				// 11 + 小数桁 + (0 or 1：小数使用可能な場合は小数点の分)
//
//				if(curDigit != "0" || this.PriceDecimalUseFlg == true)
//				{
//					ctl.PuPriceText.MaxLength		= 11 + (this.PriceDecimalUseFlg ? 3 : int.Parse(curDigit) + 1);
//				}
//				else
//				{
//					ctl.PuPriceText.MaxLength		= 11;
//				}
//				ctl.PuPriceText.Precision		= 
//					(byte) (11 + (this.PriceDecimalUseFlg ? 2 : int.Parse(curDigit)));
//				ctl.PuPriceText.Scale			= this.PriceDecimalUseFlg ? (byte) 2 : byte.Parse(curDigit);
				NumberBoxPreset.SetSlipPriceMode(ctl.PuPriceText, ctl.PuPriceText.AllowNegative, this.PriceDecimalDigit, byte.Parse(this.curDigit));
// 管理番号 K25647 To
// 管理番号 B18736 To

				//管理番号 B13502 To
			}
		}

		//次フォーカス取得
		private string getProdCodeChengedRowFocusControl(SC_MM_05_S02_ROW_CONTROLS ctl)
		{
			string focusControl = string.Empty;
			bool isInputRow = ctl.Inp=="1";

			if (isInputRow)
			{
				if (ctl.ProdType.Text.Trim() != "2" && ctl.ProdType.Text.Trim() != string.Empty)
				{
					if (ctl.ProdPuNameText.Enabled)
					{
						focusControl = ctl.ProdPuNameText.UniqueID;
					}
					else if (ctl.ProdSpec1List.Enabled && ctl.ProdSpec1List.Visible)
					{
						focusControl = ctl.ProdSpec1List.UniqueID;
					}
					else if(ctl.WhCodeText.Enabled)
					{
						focusControl = ctl.WhCodeText.UniqueID;
					}
					else if (ctl.PuQtText.Enabled)
					{
						focusControl = ctl.PuQtText.UniqueID;
					}
					else
					{
						focusControl = ctl.PuPriceText.UniqueID;
					}
				}
				else
				{
					if (ctl.PuPriceText.Enabled)
					{
						focusControl = ctl.PuPriceText.UniqueID;
					}
					else
					{
						focusControl = ctl.RegistButton.UniqueID;
					}
				}
			}
			else
			{
// 管理番号K26528 From
//				if (ctl.ProdType.Text.Trim() != "2" && ctl.ProdType.Text.Trim() != string.Empty)
//				{
//					if (ctl.ProdPuNameText.Enabled)
//					{
//						focusControl = ctl.ProdPuNameText.UniqueID;
//					}
//					else if (ctl.ProdSpec1List.Enabled && ctl.ProdSpec1List.Visible)
//					{
//						focusControl = ctl.ProdSpec1List.UniqueID;
//					}
//					else if(ctl.WhCodeText.Enabled)
//					{
//						focusControl = ctl.WhCodeText.UniqueID;
//					}
//					else if (ctl.PuQtText.Enabled)
//					{
//						focusControl = ctl.PuQtText.UniqueID;
//					}
//					else
//					{
//						focusControl = ctl.PuPriceText.UniqueID;
//					}
//				}
//				else
//				{
//					if (ctl.PuPriceText.Enabled)
//					{
//						focusControl = ctl.PuPriceText.UniqueID;
//					}
//					else if (ctl.UpdateButton.Enabled)
//					{
//						focusControl = ctl.UpdateButton.UniqueID;
//					}
//					else
//					{
//						//【例外】
//						focusControl = ctl.RegistButton.UniqueID;
//					}
//				}
				if (ctl.ProdType.Text.Trim() != "2" && ctl.ProdType.Text.Trim() != string.Empty)
				{
					if (ctl.ProdPuNameText.Enabled)
					{
						focusControl = ctl.ProdPuNameText.ClientID;
					}
					else if (ctl.ProdSpec1List.Enabled && ctl.ProdSpec1List.Visible)
					{
						focusControl = ctl.ProdSpec1List.ClientID;
					}
					else if(ctl.WhCodeText.Enabled)
					{
						focusControl = ctl.WhCodeText.ClientID;
					}
					else if (ctl.PuQtText.Enabled)
					{
						focusControl = ctl.PuQtText.ClientID;
					}
					else
					{
						focusControl = ctl.PuPriceText.ClientID;
					}
				}
				else
				{
					if (ctl.PuPriceText.Enabled)
					{
						focusControl = ctl.PuPriceText.ClientID;
					}
					else if (ctl.UpdateButton.Enabled)
					{
						focusControl = ctl.UpdateButton.ClientID;
					}
					else
					{
						//【例外】
						focusControl = ctl.RegistButton.ClientID;
					}
				}
// 管理番号K26528 To
			}
			return focusControl;
		}
		#endregion

		#region 支払条件関連
		//支払情報セット
		private void setDtData(bool SuplChanged)
		{
			rowData.DivideSuplCode(SuplCodeText.Text.Trim(), this.CompanyCodeLength);
			string compareDate = DateValidator.IsDate(PuDateText.Text.Trim()) ? PuDateText.Text.Trim() : todayDate;
			DataTable suplData = Supl.SetDtData(this.CommonData, this.SuplCodeText.Text.Trim(), this.CompanyCodeLength, compareDate);
			DataRow[] Rows = suplData.Select();

			if (!suplData.HasErrors && Rows.Length==1)
			{
				DataRow dtRow = Rows[0];
				if (SuplChanged)
				{
					this.DtTypeList.SelectedValue = dtRow["DT_TYPE"].ToString() == "E" || dtRow["TEMP_CODE_FLG"].ToString() == "1" ? "E" : "L";
					if(dtRow["TEMP_CODE_FLG"].ToString() == "1" || dtRow["DT_TYPE"].ToString() == "E")
					{
						this.DtTypeList.Enabled = false;
					}
					else
					{
						this.DtTypeList.Enabled = true;
					}
				}
				this.SuplNameText.Text					= dtRow["SUPL_SHORT_NAME"].ToString();
// 管理番号 B24164 From
//				rowData.SuplName						= dtRow["SUPL_NAME"].ToString();
//				rowData.SuplShortName					= dtRow["SUPL_SHORT_NAME"].ToString();
				if (rowData.TempCodeFlg != "1" || paramType != ParamCodeType.COPY)
				{
					rowData.SuplName 					= dtRow["SUPL_NAME"].ToString();
					rowData.SuplShortName 				= dtRow["SUPL_SHORT_NAME"].ToString();
				}
// 管理番号 B24164 To
				this.Dt1SttlMthdCodeList.SelectedValue	= dtRow["DT1_STTL_MTHD_CODE"].ToString();
				this.Dt1BasisAmtText.Text				= dtRow["DT1_BASIS_AMT"].ToString();
				this.Dt2SttlMthdCodeList.SelectedValue	= dtRow["DT2_STTL_MTHD_CODE"].ToString();
				this.Dt2RatioText.Text					= dtRow["DT2_RATIO"].ToString();
				this.Dt3SttlMthdCodeList.SelectedValue	= dtRow["DT3_STTL_MTHD_CODE"].ToString();
				this.DtSightText.Text					= dtRow["DT_SIGHT"].ToString();

				if(SuplChanged)
				{
					this.DtNoteText.Text				= dtRow["DT_NOTE"].ToString();
// 管理番号 K24789 From
					rowData.CtaxRoundType				= dtRow["CTAX_FRACTION_ROUND_TYPE"].ToString();
					rowData.CtaxBuildupType				= dtRow["CTAX_BUILDUP_TYPE"].ToString();
					rowData.ImposeFlg					= dtRow["CTAX_IMPOSE_FLG"].ToString();
// 管理番号 K24789 To
				}
				rowData.TempCodeFlg						= dtRow["TEMP_CODE_FLG"].ToString();
// 管理番号 K24789 From
//				rowData.CtaxRoundType					= dtRow["CTAX_FRACTION_ROUND_TYPE"].ToString();
//				rowData.CtaxBuildupType					= dtRow["CTAX_BUILDUP_TYPE"].ToString();
//				rowData.PuCtaxTypeCode				= dtRow["PU_CTAX_TYPE_CODE"].ToString();
//				rowData.PuReturnCtaxTypeCode		= dtRow["PU_RETURN_CTAX_TYPE_CODE"].ToString();
// 管理番号 K24789 To

// 管理番号 B24264 From
//				this.AcTable.Visible					= rowData.TempCodeFlg == "1";
// 管理番号 B24264 To
				this.SuplNameText.Enabled				= rowData.TempCodeFlg == "1";

				//管理番号 B13502 From
				if (SuplChanged)
				{
					// 取引通貨コードを取得
					rowData.CurCode = Supl.GetDealCurCode(this.CommonData,SuplCodeText.Text.Trim(), this.CompanyCodeLength);
					CurCodeList.SelectedValue = rowData.CurCode;

				}
				//管理番号 B13502 To

// 管理番号 B24264 From
//				//口座情報表示（仕入先が雑コードの場合表示）
//// 管理番号 B16565 From
////			if (rowData.TempCodeFlg == "1")
////			{
//// 管理番号 B16565 To
//					this.SuplFormalNameText.Text		= rowData.SuplName;
//// 管理番号 B24164 From
////				this.SuplUserNameText.Text			= dtRow["USER_NAME"].ToString();
////				this.SuplDeptName1Text.Text			= dtRow["DEPT_NAME_1"].ToString();
////				this.SuplDeptName2Text.Text			= dtRow["DEPT_NAME_2"].ToString();
//					if (rowData.TempCodeFlg != "1" || paramType != ParamCodeType.COPY)
//					{
//						this.SuplUserNameText.Text 		= dtRow["USER_NAME"].ToString();
//						this.SuplDeptName1Text.Text 	= dtRow["DEPT_NAME_1"].ToString();
//						this.SuplDeptName2Text.Text 	= dtRow["DEPT_NAME_2"].ToString();
//					}
//					else
//					{
//						this.SuplUserNameText.Text 		= rowData.SuplUserName;
//						this.SuplDeptName1Text.Text 	= rowData.SuplDeptName1;
//						this.SuplDeptName2Text.Text 	= rowData.SuplDeptName2;
//					}
//// 管理番号 B24164 To
//					this.SuplNameText.Text			    = rowData.SuplShortName;

//					setAcTableCondition(true);
//// 管理番号 B22138 From
////				this.AcTypeList.SelectedValue		= dtRow["AC_TYPE"].ToString();
//					// 雑コード指定
//					if ("1" == rowData.TempCodeFlg && ParamCodeType.NEW.Equals(this.paramType))
//					{
//						this.AcTypeList.SelectedValue		= "";
//					}
//					else if ("1" == rowData.TempCodeFlg && ParamCodeType.COPY.Equals(this.paramType))
//					{
//						this.AcTypeList.SelectedValue		= rowData.AcType;
//					}
//					else
//					{
//						this.AcTypeList.SelectedValue		= dtRow["AC_TYPE"].ToString();
//					}
//// 管理番号 B22138 To
//// 管理番号 B22672 From
//					// コピーモードの場合、元伝票から口座情報を引き継ぐ
//					if (ParamCodeType.COPY.Equals(this.paramType))
//					{
//						this.AcTypeList.SelectedValue = rowData.AcType;
//						dtRow["BANK_CODE"] = rowData.BankCode;
//						dtRow["BANK_BRANCH_CODE"] = rowData.BankBranchCode;
//						dtRow["BANK_AC_TYPE"] = rowData.BankAcType;
//						dtRow["AC_HOLDER"] = rowData.AcHolder;
//						dtRow["AC_NO"] = rowData.AcNo;
//					}
//// 管理番号 B22672 To
//					string bankCode = dtRow["BANK_CODE"].ToString();
//					this.BankCodeText.Text				= bankCode;
//					if (bankCode.Length > 0)
//					{
//						string bankName					= string.Empty;
//// 管理番号 B20392 From
////					Bank.IsExists(this.CommonData, this.CountryCode, bankCode, out bankName);
//						Bank.IsExists(this.CommonData, this.JapanCountryCode, bankCode, out bankName);
//// 管理番号 B20392 To
//						BankNameLabel.Text			= bankName.Length > 10 ? bankName.Substring(0,10) : bankName;
//					}
//					else
//					{
//						BankNameLabel.Text			= string.Empty;
//					}
//					string bankBranchCode				= dtRow["BANK_BRANCH_CODE"].ToString();
//					this.BankBranchCodeText.Text		= bankBranchCode;
//					if (bankCode.Length > 0 && bankBranchCode.Length > 0)
//					{
//						string bankBranchName		= string.Empty;
//// 管理番号 B20392 From
////					BankBranch.IsExists(this.CommonData, this.CountryCode, bankCode, bankBranchCode, out bankBranchName);
//						BankBranch.IsExists(this.CommonData, this.JapanCountryCode, bankCode, bankBranchCode, out bankBranchName);
//// 管理番号 B20392 To
//						BankBranchNameLabel.Text		= bankBranchName.Length > 10 ? bankBranchName.Substring(0,10) : bankBranchName;
//					}
//					else
//					{
//						BankBranchNameLabel.Text		= string.Empty;
//					}
//					this.BankAcTypeList.SelectedValue	= dtRow["BANK_AC_TYPE"].ToString();
//					this.AcHolderText.Text				= dtRow["AC_HOLDER"].ToString();
//					this.AcNoText.Text					= dtRow["AC_NO"].ToString();
//// 管理番号 B16565 From
////			}
////			else
////			{
////				this.SuplFormalNameText.Text				= rowData.SuplShortName;
////				setAcTableCondition(false);
////				setAcTableClear();
////			}

//				if (rowData.TempCodeFlg == "0")
//				{
//					this.SuplFormalNameText.Text				= rowData.SuplShortName;
//					setAcTableCondition(false);
//				}
// 管理番号 B16565 To
// 管理番号 B24264 To
				this.setDtControlCondition(dtRow["DT_TYPE"].ToString() == "E");
			}
			else
			{
				setMessageLabel(HtmlMessage(AllegroMessage.SC_MS_S10022, MessageLevel.Warning));
				this.setDtControlCondition(DtTypeList.SelectedValue == "E");
				OverRideFocus(SuplCodeText.ClientID);
			}
			this.setDtControlCondition(this.DtTypeList.SelectedValue == "E");
		}
		//支払情報項目表示制御
		private void setDtControlCondition(bool val)
		{
			Dt1SttlMthdCodeList.Enabled		= val;
			Dt1BasisAmtText.Enabled			= val;
			Dt2RatioText.Enabled			= val;
			Dt2SttlMthdCodeList.Enabled		= val;
			Dt3SttlMthdCodeList.Enabled		= val;
			DtSightText.Enabled				= val;
			CutoffDateBackButton.Enabled	= !val;
			CutoffDateAdvanceButton.Enabled	= !val;
			PymtPlanDateText.Enabled		= val;
			// 管理番号 B13878 From
// 管理番号K27064 From
//			HoldCheck.Enabled				= !val;
			//支払締後は支払保留は非活性
			HoldCheck.Enabled = !val && (rowData != null ? rowData.CutoffFinFlg != "1" : true);
// 管理番号K27064 To
			if(!HoldCheck.Enabled)
			{
				HoldCheck.Checked			= false;
			}
			// 管理番号 B13878 To

			// 必須設定
			// 基準金額、比率、支払方法２
			bool flg = (Dt1BasisAmtText.Text.Length != 0
				|| Dt2RatioText.Text.Length != 0
				|| Dt2SttlMthdCodeList.SelectedValue.Length != 0);
			Dt1BasisAmtText.IsRequiredField = flg;
			Dt2RatioText.IsRequiredField = flg;
			Dt2SttlMthdCodeList.IsRequiredField = flg;
			// 支払方法３
			Dt3SttlMthdCodeList.IsRequiredField = (Dt2RatioText.Text.Length != 0 && Decimal.Parse(Dt2RatioText.Text) < 100);
			// サイト
			string type1 = SttlMthd.GetSttlType(this.CommonData, Dt1SttlMthdCodeList.SelectedValue);
			string type2 = SttlMthd.GetSttlType(this.CommonData, Dt2SttlMthdCodeList.SelectedValue);
			string type3 = SttlMthd.GetSttlType(this.CommonData, Dt3SttlMthdCodeList.SelectedValue);
// 管理番号 B15806 From
//			DtSightText.Enabled =
//				(type1 == "N" || type1 == "D" || type2 == "N" || type2 == "D" || type3 == "N" || type3 == "D");
			DtSightText.Enabled =
				(type1 == "N" || type1 == "D" || type2 == "N" || type2 == "D" || type3 == "N" || type3 == "D") && val;
// 管理番号 B15806 To
			DtSightText.IsRequiredField =
				(type1 == "N" || type1 == "D" || type2 == "N" || type2 == "D" || type3 == "N" || type3 == "D");
// 管理番号 B21691 From
			if (!((type1 == "N") || (type1 == "D") || (type2 == "N") || (type2 == "D") || (type3 == "N") || (type3 == "D")))
			{
				DtSightText.Text = "";
			}
// 管理番号 B21691 To
			// 決済区分を保存
			ClientScript.RegisterHiddenField(HiddenFieldType.STTL_TYPE1, type1);
			ClientScript.RegisterHiddenField(HiddenFieldType.STTL_TYPE2, type2);
			ClientScript.RegisterHiddenField(HiddenFieldType.STTL_TYPE3, type3);
		}

		//支払期限の設定
		private void SetCutOffDataInfo(object sender, CutOffDateType cType)
		{
			bool isRef = this.IsReference();			//伝票を参照しているかフラグ
			IF_SC_GetCutoffDate_PreNext suplDt = null;	//仕入先から取得する支払条件
			IF_SC_GetCutoffDate_PreNext poDt = null;	//発注情報から取得する支払条件
			string DtType                    = this.DtTypeList.SelectedValue;
			string cDate = DateValidator.IsDate(PuDateText.Text) ? PuDateText.Text : todayDate ;//締日
			string pDate = string.Empty;	//支払期限

			suplDt = GetCutOffDataInfo(cType, true);
// 管理番号 B15586 From
			if(this.paramType != ParamCodeType.COPY)
			{
				poDt = GetCutOffDataInfo(cType, false);
			}
			else
			{
				poDt = GetCutOffDataInfo(cType, true);
			}
// 管理番号 B15586 To
// 管理番号 B22079 From
//			if (suplDt.Ret==0M)
//			{
// 管理番号 B22079 To
				if (isRef)
				{
					if (DtType=="L")
					{
						cDate = suplDt.CutoffDate;
						pDate = suplDt.ClctPlanDate;
					}
					else
					{
						pDate = poDt.ClctPlanDate;
					}
				}
				else
				{
					if (DtType=="L")
					{
						cDate = suplDt.CutoffDate;
						pDate = suplDt.ClctPlanDate;
					}
					else
					{
						pDate = suplDt.ClctPlanDate;
					}
				}
// 管理番号 B22079 From
//			}
// 管理番号 B22079 To
			this.CutoffDateText.Text   = cDate;//締日 -- 都度請求が選択されている場合は、締日に固定で仕入日を表示。
			this.PymtPlanDateText.Text = pDate;//支払期限
		}

		//支払条件情報を取得
		private IF_SC_GetCutoffDate_PreNext GetCutOffDataInfo(CutOffDateType cType, bool IsParameterGet)
		{
			IF_SC_GetCutoffDate_PreNext cutOffInfo = new IF_SC_GetCutoffDate_PreNext();
// 管理番号 B22079 From
			string DtType   = this.DtTypeList.SelectedValue;
// 管理番号 B22079 To
			string bookDate = DateValidator.IsDate(PuDateText.Text.Trim()) ? PuDateText.Text.Trim() : todayDate;
			if (cType!=CutOffDateType.Now)
			{
				bookDate = this.CutoffDateText.Text.Trim();
			}

			string suplCode = this.SuplCodeText.Text.Trim();
			string code = string.Empty;
			string sbNo = string.Empty;
			rowData.DivideSuplCode(suplCode, this.CompanyCodeLength, out code, out sbNo);

			cutOffInfo.BookDate        = bookDate;
			cutOffInfo.PreNextType     = ((int)cType).ToString();
			cutOffInfo.CustCode        = code;
			cutOffInfo.CustSbno        = sbNo;
			cutOffInfo.DeptCode        = this.DeptCodeText.Text.Trim();
			cutOffInfo.CalenderType    = "C";
// 管理番号 B20065 From
//			cutOffInfo.GetTypeP        = "3";	//仕入先
			cutOffInfo.GetTypeP        = this.DtTypeList.SelectedValue == "E"?"4":"3";	//仕入先		
// 管理番号 B20065 To
			if (IsParameterGet)	//パラメーター取得区分(取引条件を 0：取得しない、1：取得する)
			{
				//発注を参照していない場合は仕入先マスタの支払条件を参照
				cutOffInfo.ParamGetType    = "1";
				cutOffInfo.CutoffCycleType = string.Empty;
				cutOffInfo.CutoffDay       = string.Empty;
				cutOffInfo.TermMonthCnt    = "0";
				cutOffInfo.TermDay         = "0";
			}
			else
			{
// 管理番号 B22079 From
				if (DtType == "E")
				{
					rowData.DtCutoffDay    = bookDate.Substring(8,2);
				}
// 管理番号 B22079 To

// 管理番号 B20298 From
                if (rowData.DtCutoffCycleType != string.Empty && rowData.DtCutoffDay != string.Empty)
                {
// 管理番号 B20298 To				
				    //発注を参照している場合は発注の支払条件を参照
					cutOffInfo.ParamGetType    = "0";
					cutOffInfo.CutoffCycleType = rowData.DtCutoffCycleType;	//取引条件サイクル区分
					cutOffInfo.CutoffDay       = rowData.DtCutoffDay;		//取引条件締日付
					cutOffInfo.TermMonthCnt    = rowData.DtTermMonthCnt;	//取引条件期限月数
					cutOffInfo.TermDay         = rowData.DtTermDay;			//取引条件期限日付
// 管理番号 B20298 From
                }
                else
                {
                    cutOffInfo.ParamGetType = "1";
                    cutOffInfo.CutoffCycleType = string.Empty;
                    cutOffInfo.CutoffDay = string.Empty;
                    cutOffInfo.TermMonthCnt = "0";
                    cutOffInfo.TermDay = "0";

                }
// 管理番号 B20298 To					
			}

			CutoffDate.Get_PreNext_Cutoff_Date(this.CommonData, cutOffInfo);
			return cutOffInfo;
		}

		// 決済条件翻訳名取得
		private string getDtConditionString(string cType, string cDay, string tCnt, string tDay)
		{
			string sss   = string.Empty;
			string sCday = DtCutoffDay.GetName(cType, cDay);
			string sTCnt = DtCutoffMonthCnt.GetName(cType, tCnt);
			string sTDay = DtCutoffDay.GetName(cType, tDay);

			if ((sCday.Length > 0) && (sTCnt.Length > 0) && (sTDay.Length > 0))
			{
// 				sss = sCday + "締 " + sTCnt + " " + sTDay + "払い"; //K24546
				sss = sCday + MultiLanguage.Get("SC_CS004840") + sTCnt + " " + sTDay + MultiLanguage.Get("SC_CS005392");
			}
			return sss;
		}

		//モード取得
		private bool IsReference()
		{
			if (rowData==null)
			{
				return false;
			}

			//ここでは返品は無視
			bool val1 = (refType==RefCodeType.PO || refType==RefCodeType.RCPT || refType==RefCodeType.COPY_PU);
			bool val2 = (rowData.PoNo.Length!=0 || rowData.RcptNo.Length!=0);
			return (val1 || val2);
		}


// 管理番号 B24264 コメント削除
// 管理番号 B21666 コメント削除
// 管理番号 B13502 コメント削除

		#endregion

		#region その他の処理
		//承認状態設定
		private void setApproval(string deptCode)
		{
			string slipNo = string.Empty;
			if (this.paramType=="Mod"||this.paramType=="View")
			{
				slipNo = this.slipNo;
// 管理番号 B20853 From
				if (rowData.CanceledOrderFlg=="1")
				{
					if(rowData.Dt.Rows.Count >0)
					{
						slipNo = rowData.Dt.Rows[0]["SA_NO"].ToString();

					}
				}
// 管理番号 B20853 To
			}

			this.StatusDropdownlist.Items.Clear();

// 管理番号 K25680 From
//			if(Infocom.Allegro.CM.WF.Common.IsApp(this.CommonData, pageCode, deptCode)) //ワークフロー対象の時
			bool ediFlg = false;
			if (rowData != null)
			{
				ediFlg = (rowData.ImportSlipNo.Length != 0 && rowData.SuplSlipNo.Length == 0);
				slipType = (rowData.SuplSlipNo.Length != 0) ? "CG2" : pageCode;
			}
			//ワークフロー対象且つEDI伝票でない時
			if (Infocom.Allegro.CM.WF.Common.IsApp(this.CommonData, slipType, deptCode) && !ediFlg)
// 管理番号 K25680 To
			{
				StatusTitleLabel.Visible	= true;
// 				StatusTitleLabel.Text		= "承認状態"; //K24546
				StatusTitleLabel.Text		= MultiLanguage.Get("SC_CS001206");
				StatusDropdownlist.Visible	= true;
				// 承認状態リストボックスの作成
// 管理番号 B20853 From
				if (paramType == ParamCodeType.MOD || paramType == ParamCodeType.VIEW)
				{
// 管理番号 B24714 From
					if (slipNo.Length > 0 && rowData.OppositePuNo.Length > 0)
					{
						// 赤黒伝票は仕入データの承認状況から取得
						Infocom.Allegro.SC.MS.ApprovalStatusType.SetAppStatusList(StatusDropdownlist, rowData.ApprovalStatusType);
					}
					else
					{
// 管理番号 B24714 To
						if (rowData.CanceledOrderFlg=="1")
						{
							Infocom.Allegro.CM.WF.Common.SetAppStatusList(StatusDropdownlist, this.CommonData,  "SD6", slipNo);
						
						}
						else
						{
// 管理番号 B20853 To
// 管理番号 K25679 From
//							Infocom.Allegro.CM.WF.Common.SetAppStatusList(StatusDropdownlist, this.CommonData,  pageCode, slipNo);
							Infocom.Allegro.CM.WF.Common.SetAppStatusList(StatusDropdownlist, this.CommonData, slipType, slipNo);
// 管理番号 K25679 To
// 管理番号 B20853 From
						}
// 管理番号 B24714 From
					}
// 管理番号 B24714 To
				}
				else
				{
// 管理番号 K25679 From
//					Infocom.Allegro.CM.WF.Common.SetAppStatusList(StatusDropdownlist, this.CommonData,  pageCode, string.Empty);
					Infocom.Allegro.CM.WF.Common.SetAppStatusList(StatusDropdownlist, this.CommonData, slipType, string.Empty);
// 管理番号 K25679 To
				}
// 管理番号 B20853 To
				approvalFlg = true;
// 管理番号 K22217 From
                if (StatusDropdownlist.SelectedValue == "3" || StatusDropdownlist.SelectedValue == "5" || StatusDropdownlist.SelectedValue == "6")
                {
                    this.RouteChangeButton.Visible = false;
			}
			else
			{
                    this.RouteChangeButton.Visible = true;
                }
// 管理番号 K22217 To
			}
			else
			{
				StatusTitleLabel.Visible	= false;
				StatusDropdownlist.Visible	= false;
				// ワークフロー対象でないときは決裁に設定しておく
// 				StatusDropdownlist.Items.Insert(0, new ListItem("決裁", "3")); //K24546
				StatusDropdownlist.Items.Insert(0, new ListItem(MultiLanguage.Get("SC_CS003243"), "3"));
				StatusDropdownlist.SelectedValue = "3";
				approvalFlg = false;
// 管理番号 K22217 From
                this.RouteChangeButton.Visible = false;
// 管理番号 K22217 To
			}
		}

		private void setMessageLabel(string errorMassage)
		{
			MessageLabel.Text = errorMassage;
		}

		//合計金額セット
		private void setAmtTtl(bool IsReCalc)
		{
			//合計取得
			if (IsReCalc)
			{
// 管理番号 K24789 From
//				// 明細計算
//				decimal dtilAmtTtl		= 0;
//				decimal etaxDtilAmtTtl	= 0;
//				decimal etaxAmtTtl		= 0;
//				decimal grandTtl		= 0;
//				// 管理番号B13502 From
//				decimal dtilCurAmtTtl		= 0;
//				decimal etaxCurDtilAmtTtl	= 0;
//				decimal etaxCurAmtTtl		= 0;
//				decimal grandCurTtl			= 0;
//				string	roundType			= string.Empty;
//				string	keycurDigit			= string.Empty;
// 管理番号 K24789 To

				// 管理番号 B14477 From
				//				if (this.CurCodeList.SelectedValue == this.KeyCurrencyCode)
				//				{
				//					roundType = this.AmtRoundType;
				//				}
				//				else
				//				{
				//					roundType = this.CurRoundType;
				//				}
				// 管理番号 B14477 To
// 管理番号 K24789 From
//				curDigit = Cur.GetDecimalDigit(CommonData, this.CurCodeList.SelectedValue);
//				keycurDigit = Cur.GetDecimalDigit(CommonData, this.KeyCurrencyCode);
//
//				if (rowData.Dt.Rows.Count > 0)
//				{
//					//					rowData.GetAmtTtl(this.CommonData, curDigit, out dtilAmtTtl, out etaxDtilAmtTtl, out etaxAmtTtl, out grandTtl);
//					// 管理番号 B14477 From
//					//					rowData.GetCurAmtTtl(this.CommonData, curDigit, keycurDigit, out dtilAmtTtl, out etaxDtilAmtTtl, out etaxAmtTtl
//					//						, out grandTtl, out dtilCurAmtTtl, out etaxCurDtilAmtTtl, out etaxCurAmtTtl, out grandCurTtl, roundType);
//					rowData.GetCurAmtTtl(this.CommonData, curDigit, keycurDigit, out dtilAmtTtl, out etaxDtilAmtTtl, out etaxAmtTtl
//						, out grandTtl, out dtilCurAmtTtl, out etaxCurDtilAmtTtl, out etaxCurAmtTtl, out grandCurTtl, this.CurRoundType, this.CurCodeList.SelectedValue, this.KeyCurrencyCode);
//
//					// 管理番号 B14477 To
//				}
//				//管理番号 B13502 To
//				// 管理番号 B11723・B11796 From
//				//				// 受注金額合計
//				//				DtilAmtTtlLabel.Text		= Common.FormatAmt(Round.GetRound(this.CommonData, dtilAmtTtl, double.Parse(curDigit), this.AmtRoundType), curDigit, false, "1");
//				//				// 課税対象額計
//				//				EtaxDtilAmtTtlLabel.Text	= Common.FormatAmt(Round.GetRound(this.CommonData, etaxDtilAmtTtl, double.Parse(curDigit), this.AmtRoundType), curDigit, false, "1");
//				//				// 消費税合計
//				//				EtaxAmtTtlLabel.Text		= Common.FormatAmt(Round.GetRound(this.CommonData, etaxAmtTtl, double.Parse(curDigit), this.AmtRoundType), curDigit, false, "1");
//				//				// 総合計
//				//				GrandTtlLabel.Text			= Common.FormatAmt(Round.GetRound(this.CommonData, grandTtl, double.Parse(curDigit), this.AmtRoundType), curDigit, false, "1");
//
//				// 受注金額合計
//				DtilAmtTtlLabel.Text		= Common.FormatAmt(dtilAmtTtl, curDigit, false, "1");
//				// 課税対象額計
//				EtaxDtilAmtTtlLabel.Text	= Common.FormatAmt(etaxDtilAmtTtl, curDigit, false, "1");
//				// 消費税合計
//				EtaxAmtTtlLabel.Text		= Common.FormatAmt(etaxAmtTtl, curDigit, false, "1");
//				// 総合計
//				GrandTtlLabel.Text			= Common.FormatAmt(grandTtl, curDigit, false, "1");
//				// 管理番号 B11723・B11796 To
//
//
//				//管理番号 B13502 From
//				// 発注金額合計
//				ConvertDtilAmtTtlLabel.Visible = false;
//				if (RateText.Text.Length!=0)
//				{
//					ConvertDtilAmtTtlLabel.Text	= this.KeyCurrencyCode + "(" + Common.FormatAmt(dtilCurAmtTtl, keycurDigit, false, "1") + ")";
//				}
//
//				// 課税対象額計
//				ConvertEtaxDtilAmtTtlLabel.Visible = false;
//				if (RateText.Text.Length!=0)
//				{
//					ConvertEtaxDtilAmtTtlLabel.Text	=this.KeyCurrencyCode + "(" + Common.FormatAmt(etaxCurDtilAmtTtl, keycurDigit, false, "1") + ")";
//				}
//				// 消費税合計
//				ConvertEtaxAmtTtlLabel.Visible = false;
//				if (RateText.Text.Length!=0)
//				{
//					ConvertEtaxAmtTtlLabel.Text		= this.KeyCurrencyCode + "(" + Common.FormatAmt(etaxCurAmtTtl, keycurDigit, false, "1") + ")";
//				}
//				// 総合計
//				ConvertGrandTtlLabel.Visible =(CurCodeList.SelectedValue != this.KeyCurrencyCode);
//// 管理番号 B15394 From
////				if (RateText.Text.Length!=0)
////				{
////					ConvertGrandTtlLabel.Text		= this.KeyCurrencyCode + "(" + Common.FormatAmt(grandCurTtl, keycurDigit, false, "1") +")";
////				}
//				ConvertGrandTtlLabel.Text		= this.KeyCurrencyCode + "(" + Common.FormatAmt(grandCurTtl, keycurDigit, false, "1") +")";
//// 管理番号 B15394 To
//				//管理番号 B13502 To

				string keycurDigit = Cur.GetDecimalDigit(CommonData, KeyCurrencyCode);
				ConvertGrandTtlLabel.Visible = (CurCodeList.SelectedValue != this.KeyCurrencyCode);

				if (rowData.Dt.Rows.Count > 0)
				{
					rowData.CurCode			= CurCodeList.SelectedValue;
					rowData.KeyCurCode		= this.KeyCurrencyCode;
					rowData.AmtRoundType	= this.AmtRoundType;
					rowData.CurRoundType	= this.CurRoundType;

					// 合計金額算出
					rowData.GetCurAmtTtl(this.CommonData);

					// 仕入金額合計
					DtilAmtTtlLabel.Text		= Common.FormatAmt(rowData.DtilAmtTtl, curDigit, false, "1");
					// 課税対象額計
					EtaxDtilAmtTtlLabel.Text	= Common.FormatAmt(rowData.TaxableAmtTtl, curDigit, false, "1");
					// 消費税合計
					EtaxAmtTtlLabel.Text		= Common.FormatAmt(rowData.TaxAmtTtl, curDigit, false, "1");
					// 総合計
					GrandTtlLabel.Text			= Common.FormatAmt(rowData.GrandTtl, curDigit, false, "1");
					// 基軸換算総合計
					ConvertGrandTtlLabel.Text	= this.KeyCurrencyCode + "(" + Common.FormatAmt(rowData.KeyGrandTtl, keycurDigit, false, "1") + ")";
					
				}
				else
				{
					// 仕入金額合計
					DtilAmtTtlLabel.Text		= "0";
					// 課税対象額計
					EtaxDtilAmtTtlLabel.Text	= "0";
					// 消費税合計
					EtaxAmtTtlLabel.Text		= "0";
					// 総合計
					GrandTtlLabel.Text			= "0";
				}
// 管理番号 K24789 To

			}
			else
			{
				DtilAmtTtlLabel.Text		= string.Empty;
				EtaxDtilAmtTtlLabel.Text	= string.Empty;
				EtaxAmtTtlLabel.Text		= string.Empty;
				GrandTtlLabel.Text			= string.Empty;
// 管理番号 K24789 From
				ConvertGrandTtlLabel.Text	= string.Empty;
// 管理番号 K24789 To
			}
		}

		//優先倉庫取得
		private void setPriorityWh(string deptCode)
		{
			string whCode			= string.Empty;
			string whShortName		= string.Empty;
			Wh.GetPriorityWh(this.CommonData, deptCode, this.CurrentOrganizationChangeId, out whCode, out whShortName);
			WhCodeText.Text			= whCode;
			WhShortNameLabel.Text	= whShortName;

			if (setWhName(this.WhShortNameLabel, whCode, true))
			{
				if (this.DeliTypeWRadio.Checked)
				{
					setWhPlace(whCode);
				}
			}
		}
		// 倉庫名称取得
		private bool setWhName(EncodeLabel whNameLabel, string whCode, bool val)
		{
			string	whName = whNameLabel.Text = string.Empty;
// 管理番号K27058 From
//			bool	puMode = (this.PuModeTypeList.SelectedValue != "4"); // 預り発注の場合は直送を許さない
			bool	puMode = (this.puModeType != "4"); // 預り発注の場合は直送を許さない
// 管理番号K27058 To
			bool	retVal = true;

			if (whCode.Length > 0)
			{
				if(val) //ヘッダ倉庫の場合は必ず直送を許さない
				{
					if (!Wh.IsExists(this.CommonData, whCode, false, false, true, true, true, out whName))
					{
						retVal = false;
					}
				}
				else
				{
					if (!Wh.IsExists(this.CommonData, whCode, false, puMode, true, true, true, out whName))
					{
						retVal = false;
					}
				}
			}
			whNameLabel.Text = whName;
			return retVal;
		}

		// 納入先住所セット
		private void setDeliPlace()
		{
			if (DeliCustCodeText.Text.Trim().Length > 0)
			{
// 管理番号K27062 From
//				DataTable deliPlaceData = DeliPlace.SetDataSource(this.CommonData,DeliCustCodeText.Text.Trim(),(byte) this.CompanyCodeLength,DeliPlaceCodeList.SelectedValue);
				DataTable deliPlaceData = DeliPlace.SetDataSource(this.CommonData,DeliCustCodeText.Text.Trim(), (byte)this.CompanyCodeLength, DeliPlaceCodeText.Text.Trim());
// 管理番号K27062 To
				if(deliPlaceData.Rows.Count > 0)
				{
					DeliPlaceNameText.Text		= deliPlaceData.Rows[0]["DELI_PLACE_NAME"].ToString() ;
					ZipText.Text	= deliPlaceData.Rows[0]["DELI_PLACE_ZIP"].ToString() ;
					DeliPlaceCountryCode.Text = deliPlaceData.Rows[0]["DELI_PLACE_COUNTRY_CODE"].ToString() ;
					StateText.Text		= deliPlaceData.Rows[0]["DELI_PLACE_STATE"].ToString() ;
					CityText.Text		= deliPlaceData.Rows[0]["DELI_PLACE_CITY"].ToString() ;
					Address1Text.Text	= deliPlaceData.Rows[0]["DELI_PLACE_ADDRESS1"].ToString() ;
					Address2Text.Text	= deliPlaceData.Rows[0]["DELI_PLACE_ADDRESS2"].ToString() ;
					PhoneText.Text		= deliPlaceData.Rows[0]["DELI_PLACE_PHONE"].ToString() ;
					FaxText.Text		= deliPlaceData.Rows[0]["DELI_PLACE_FAX"].ToString() ;
					DeliUserNameText.Text		= deliPlaceData.Rows[0]["DELI_PLACE_USER_NAME"].ToString() ;
				}
// 管理番号 B23856 From
				else
				{
					DeliPlaceNameText.Text = string.Empty;
// 管理番号K27062 From
					clearPlace();
// 管理番号K27062 To
				}
// 管理番号 B23856 To
			}
			else
			{
// 管理番号 B23856 From
				DeliPlaceNameText.Text = string.Empty;
// 管理番号 B23856 To
				clearPlace();
			}
		}
		// 倉庫住所セット
		private void setWhPlace(string whCode)
		{
			if (whCode.Length > 0)
			{
				DataTable whPlace = Wh.GetPlace(this.CommonData, whCode);
				if (!whPlace.HasErrors)
				{
					DeliPlaceCountryCode.Text	= whPlace.Rows[0]["WH_COUNTRY_CODE"].ToString();
					ZipText.Text				= whPlace.Rows[0]["WH_ZIP"].ToString();
					StateText.Text				= whPlace.Rows[0]["WH_STATE"].ToString();
					CityText.Text				= whPlace.Rows[0]["WH_CITY"].ToString();
					Address1Text.Text			= whPlace.Rows[0]["WH_ADDRESS1"].ToString();
					Address2Text.Text			= whPlace.Rows[0]["WH_ADDRESS2"].ToString();
					PhoneText.Text				= whPlace.Rows[0]["WH_PHONE"].ToString();
					FaxText.Text				= whPlace.Rows[0]["WH_FAX"].ToString();
				}
				else
				{
					clearPlace();
				}
			}
			DeliUserNameText.Text		= string.Empty ;
		}
		// 住所情報クリア
		private void clearPlace()
		{
			DeliPlaceCountryCode.Text	= string.Empty ;
			ZipText.Text				= string.Empty ;
			StateText.Text				= string.Empty ;
			CityText.Text				= string.Empty ;
			Address1Text.Text			= string.Empty ;
			Address2Text.Text			= string.Empty ;
			PhoneText.Text				= string.Empty ;
			FaxText.Text				= string.Empty ;
			DeliUserNameText.Text		= string.Empty ;
		}

		// 管理番号 B18736 From
		// 入力単価桁数制御
		private void setCurDigit()
		{
			//使用可能な単価小数桁数の最大値は2とする
			if(int.Parse(curDigit) >= 3)
			{
				curDigit = "2";
			}
// 管理番号 K25647 From
//			InpPuPriceText.AllowDecimal	= (this.PriceDecimalUseFlg || curDigit != "0");
//			// 11 + 小数桁 + (0 or 1：小数使用可能な場合は小数点の分)
//
//			if(curDigit != "0" || this.PriceDecimalUseFlg == true)
//			{
//				InpPuPriceText.MaxLength		= 11 + (this.PriceDecimalUseFlg ? 3 : int.Parse(curDigit) + 1);
//			}
//			else
//			{
//				InpPuPriceText.MaxLength		= 11;
//			}
//			InpPuPriceText.Precision		= 
//				(byte) (11 + (this.PriceDecimalUseFlg ? 2 : int.Parse(curDigit)));
//			InpPuPriceText.Scale			= this.PriceDecimalUseFlg ? (byte) 2 : byte.Parse(curDigit);
			NumberBoxPreset.SetSlipPriceMode(this.InpPuPriceText, this.InpPuPriceText.AllowNegative, this.PriceDecimalDigit, byte.Parse(this.curDigit));
// 管理番号 K25647 To
			
		}
		// 管理番号 B18736 To

		//管理番号 B13502 From
		/// <summary>
		/// 通貨プルダウンのチェンジ(共通用)
		/// </summary>
		private void CurCodeListChanged()
		{
// 管理番号 B14549 From
			curDigit = Cur.GetDecimalDigit(this.CommonData, this.CurCodeList.SelectedValue);
// 管理番号 B14549 To
// 管理番号 B18736 From
			setCurDigit();
// 管理番号 B18736 To
			//ボディ：基本タブ：為替予約番号 を空にする
			this.ExchangeRezNoText.Text = string.Empty;
			//ボディ：基本タブ：為替区分 を初期値にする
			this.ExchangeTypeList.SelectedValue		= "0";

			//Enabled設定
			if(this.CurCodeList.SelectedValue == this.KeyCurrencyCode)
			{
				this.ExchangeTypeList.Enabled =false;
				this.ExchangeRezNoText.Enabled =false;
				this.RateText.Enabled =false;
			}
			else
			{
				this.ExchangeTypeList.Enabled =true;
				this.ExchangeRezNoText.Enabled =false;
				this.RateText.Enabled =true;
			}

			//ボディ： BL「レート取得」を実行し計上レートを取得しボディ：基本タブ：レートに設定する。
			SetRate();
			//「基本タブ：レートのテキストチェンジ」を行う
			///ボディ：詳細タブ：レート にボディ：基本タブ：レートの値を設定する。
			RateLabel.Text =RateText.Text;
// 管理番号 B24179 From
			// 明細行（登録済み行）の標準単価の読み直し
			string compareDate = DateValidator.IsDate(this.PuDateText.Text) ? this.PuDateText.Text : todayDate;
// 管理番号 K24789 From
//			rowData.ReloadProdPrice(this.CommonData, CurCodeList.SelectedValue, SuplCodeText.Text, this.CompanyCodeLength, this.DeptCodeText.Text.Trim(), compareDate, double.Parse(curDigit), AmtRoundType);
			string dealDate = DateValidator.IsDate(this.DealDateText.Text) ? this.DealDateText.Text : todayDate;
			rowData.ReloadProdPrice(this.CommonData, CurCodeList.SelectedValue, SuplCodeText.Text, this.CompanyCodeLength, this.DeptCodeText.Text.Trim(), compareDate, double.Parse(curDigit), AmtRoundType, dealDate, "P");
// 管理番号 K24789 To
// 管理番号 B24179 To

			//グリッドの再描画
			setDataGridProperty(rowData.Dt);

			///発注金額合計、課税対象額計、消費税合計、総合計を再計算する。
			setAmtTtl(true);
// 管理番号 B20039 From
			clearNewControlValue();
			setNewControlCondition(true);
// 管理番号 B20039 To
		}

		/// <summary>
		/// 為替区分変更時
		/// </summary>
		private void ExchangeTypeListChanged()
		{
			//「予約あり」以外が選択された場合は為替予約番号を消去する
			if (this.ExchangeTypeList.SelectedValue!="1")
			{
// 管理番号 B21594 From
				if (returnValue != "ExchangeRezNoText")
				{
// 管理番号 B21594 To
					this.ExchangeRezNoText.Text = string.Empty;
					//管理番号 B13502 From
					//計上レートを取得する。
					SetRate();
// 管理番号 B21594 From
				}
// 管理番号 B21594 To
				// 合計金額再計算
				setAmtTtl(true);
				setDataGridProperty(rowData.Dt);
				//管理番号 B13502 TO
// 管理番号 B23588 From
				clearNewControlValue();
				setNewControlCondition(true);
// 管理番号 B23588 To
			}

			//「予約あり」の場合必須
			this.ExchangeRezNoText.IsRequiredField = this.ExchangeTypeList.SelectedValue=="1";
			this.ExchangeRezNoText.Enabled = this.ExchangeTypeList.SelectedValue=="1";
			this.RateText.Enabled = this.ExchangeTypeList.SelectedValue!="1";

		}

		/// <summary>
		/// 為替予約番号変更時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
// 管理番号 B17665 From
//		private void ExchangeRezNoTextChanged()
		private void ExchangeRezNoTextChanged(object sender)
// 管理番号 B17665 To
		{
			string rate = string.Empty;
			string code = string.Empty , sbNo = string.Empty;
			// 管理番号 B13877 From
			string projCode = this.ProjCodeText.Text.Trim();
// 管理番号 B23717 From
			bool checkExchangeRez = false;
// 管理番号 B23717 To

			if(projCode.Length > 0)
			{
				rowData.DivideProjCode(this.ProjCodeText.Text.Trim(), this.ProjectCodeLength);

				code = rowData.ProjCode.ToString();		//コード
				sbNo = rowData.ProjSbno.ToString();		//サブナンバー
			}
			// 管理番号 B13877 To

// 管理番号 B23717 From
// 管理番号B26678 From
////// 管理番号 B17601 From
//////			if (ExchangeRez.IsExists(this.CommonData, this.ExchangeRezNoText.Text, this.DeptCodeText.Text, code, sbNo, this.PuDateText.Text, out rate, "S"))
////			if (ExchangeRez.IsExists(this.CommonData, this.ExchangeRezNoText.Text, this.DeptCodeText.Text, code, sbNo, this.PuDateText.Text, out rate, "S", this.CurCodeList.SelectedValue.Trim()))
////// 管理番号 B17601 To
//			if (this.PuModeTypeList.SelectedValue != "2")
//			{
//				checkExchangeRez = ExchangeRez.IsExists(this.CommonData, this.ExchangeRezNoText.Text, this.DeptCodeText.Text, code, sbNo, this.PuDateText.Text, out rate, "S", this.CurCodeList.SelectedValue.Trim());
//			}
//			else
//			{
//				checkExchangeRez = ExchangeRez.IsExistsReturn(this.CommonData, this.ExchangeRezNoText.Text, this.DeptCodeText.Text, code, sbNo, this.PuDateText.Text, out rate, "S", "B", this.CurCodeList.SelectedValue.Trim());
//			}
			checkExchangeRez = ExchangeRez.IsExistsGetExchangeRezRate(this.CommonData, this.ExchangeRezNoText.Text, this.DeptCodeText.Text, code, sbNo, "S", this.CurCodeList.SelectedValue.Trim(), out rate);
// 管理番号B26678 To

			if (checkExchangeRez)
// 管理番号 B23717 To
			{
// 管理番号 B14549 From
//				this.RateText.Text = rate;
				if(rate.Length != 0)
				{
// 管理番号 B18516 From
//					this.RateText.Text = Common.FormatAmt(decimal.Parse(rate), curDigit, false, "1");
					this.RateText.Text = decimal.Parse(rate).ToString("#0.00");
// 管理番号 B18516 To
				}
				else
				{
					this.RateText.Text = string.Empty;
				}
// 管理番号 B14549 To
				//ボディ：詳細タブ：レート にボディ：基本タブ：レートの値を設定する。
				RateLabel.Text =RateText.Text;
				//発注金額合計、課税対象額計、消費税合計、総合計を再計算する。
// 管理番号 B17665 From
//				setAmtTtl(false);
				rowData.Rate = rate;
				setAmtTtl(true);
// 管理番号 B23588 From
				setDataGridProperty(rowData.Dt);
				clearNewControlValue();
				setNewControlCondition(true);
// 管理番号 B23588 To

//				FocusControl(this.RateText.NextControlID);
				FocusControl(this.RateText.NextControlID, sender);
// 管理番号 B17665 To
// 管理番号 B15412 From
				if (returnValue == "ExchangeRezNoText")	//検索ウィンドウの戻り
				{
					OverRideFocus(this.ExchangeRezNoText.ClientID);
				}
// 管理番号 B15412 To
			}
			else
			{
// 管理番号 B21594 From
				if (returnValue != "ExchangeRezNoText")
				{
// 管理番号 B21594 To
					this.RateText.Text = string.Empty;
					RateLabel.Text = RateText.Text;
					// 管理番号 B17665 From
					SetRate();
// 管理番号 B21594 From
				}
// 管理番号 B21594 To
				setAmtTtl(true);
// 管理番号 B17665 To
// 管理番号 B23588 From
				setDataGridProperty(rowData.Dt);
				clearNewControlValue();
				setNewControlCondition(true);
// 管理番号 B23588 To

				if (this.ExchangeRezNoText.Text.Length > 0)
				{
// 					setMessageLabel(HtmlMessage(AllegroMessage.S20005("為替予約番号"), MessageLevel.Warning)); //K24546
					setMessageLabel(HtmlMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS000319")), MessageLevel.Warning));
					// 管理番号 B21594 From
					FocusControl(this.ExchangeRezNoText.ID);
					// 管理番号 B21594 To
				}
// 管理番号 B21594 From
//				FocusControl(this.ExchangeRezNoText.ID);
				else
				{
					if (returnValue == "ExchangeRezNoText")			//検索ウィンドウの戻り
					{
						if (this.ExchangeRezNoText.Enabled)
						{
							FocusControl(this.ExchangeRezNoText.ID);
						}
						else
						{
							FocusControl(this.RateText.ID);
						}
					}
					else
					{
						FocusControl(this.RateText.NextControlID);
					}
				}
// 管理番号 B21594 To
			}
		}

		//原単価の計算に使うレートを取得
		private void SetRate()
		{
			string rate;
			rate = Rate.GetRate(this.CommonData, this.CurCodeList.SelectedValue, generalDateTime, RateSaerchOption.Book);
			decimal curRate = rate.Length > 0 ? decimal.Parse(rate) : 1M;
// 管理番号 B14549 From
// 管理番号 B18516 From
//			RateText.Text = Common.FormatAmt(curRate, curDigit, false, "1");
//			RateLabel.Text = Common.FormatAmt(curRate, curDigit, false, "1");
			RateText.Text = curRate.ToString("#0.00");
			RateLabel.Text = curRate.ToString("#0.00");
// 管理番号 B18516 To

// 管理番号 B14549 To
			rowData.Rate = RateText.Text;
		}

		private void SetRate(object sender)
		{
			bool Exex = true;
			if (sender==this.PuDateText)
			{
				Exex = !ExchangeRezIsExists();//為替予約番号でレート取得している
			}
			else if (sender==this.ExchangeRezNoText || sender==this.RateText)
			{
				Exex = false;
			}

			string rate;
			if (Exex)
			{
				rate = Rate.GetRate(this.CommonData, this.CurCodeList.SelectedValue, generalDateTime, RateSaerchOption.Book);
			}
			else
			{
				rate = this.RateText.Text.Trim();
			}

			//rowData.Rate = rate;
			decimal curRate = rate.Length > 0 ? decimal.Parse(rate) : 1M;
// 管理番号 B14549 From
// 管理番号 B18516 From
//			RateText.Text = Common.FormatAmt(curRate, curDigit, false, "1");
//			RateLabel.Text = Common.FormatAmt(curRate, curDigit, false, "1");
			RateText.Text = curRate.ToString("#0.00");
			RateLabel.Text = curRate.ToString("#0.00");
// 管理番号 B18516 To

// 管理番号 B14549 To
			rowData.Rate = RateText.Text;
		}
		//為替予約番号存在チェックⅠ
		private bool ExchangeRezIsExists()
		{
			string r = string.Empty;
			string c = string.Empty;
			return ExchangeRezIsExists(out r, out c);
		}
		//為替予約番号存在チェックⅡ
		private bool ExchangeRezIsExists(out string cur)
		{
			string r = string.Empty;
			cur = string.Empty;
			return ExchangeRezIsExists(out r, out cur);
		}
		//為替予約番号存在チェックⅢ
		private bool ExchangeRezIsExists(out string rate, out string cur)
		{
			//出力パラメータ初期化
			rate = string.Empty;
			cur  = string.Empty;

			string exRezNo = this.ExchangeRezNoText.Text.Trim();
			bool isExists  = false;
			if (exRezNo.Length !=0)
			{
				string pCode, pSbNo;
				string projCode = ProjCodeText.Text.Trim();
				if (projCode.Length > 0)
				{
					rowData.DivideProjCode(projCode, this.ProjectCodeLength);
				}
				//プロジェクトコード
				pCode = rowData.ProjCode;
				//プロジェクトサブコード
				pSbNo = rowData.ProjSbno;
				isExists = ExchangeRez.IsExists(this.CommonData, exRezNo, this.DeptCodeText.Text, pCode, pSbNo, generalDateString, out rate, out cur, "S");
			}
			return isExists;
		}
		//管理番号 B13502 To

// 管理番号 B24188 From
		// 保留解除ボタンの表示、非表示制御
		private void SetDispHoldReleaseButton()
		{
			if (paramType == ParamCodeType.MOD && HoldCheck.Checked == true && HoldCheck.Enabled == true)
			{
				HoldReleaseButton.Visible = true;
// 管理番号 B23437 From
				holdReleaseFlg = false;
// 管理番号 B23437 To
			}
// 管理番号 B23437 From
			else if(paramType == ParamCodeType.VIEW && HoldCheck.Checked && HoldCheck.Enabled && holdReleaseFlg)
			{
				if (!getLock(slipNo))
				{
					HoldReleaseButton.Visible = false;
					holdReleaseFlg = false;
				}
				else
				{
					HoldReleaseButton.Visible = true;
					holdReleaseFlg = true;
				}
			}
// 管理番号 B23437 To
			else
			{
				HoldReleaseButton.Visible = false;
// 管理番号 B23437 From
				holdReleaseFlg = false;
// 管理番号 B23437 To
			}
		}
// 管理番号 B24188 To

// 管理番号 B24264 From
		//雑仕入先クリア
		private void tempRowDataClear()
		{
			tempRowData = new Hashtable();
			tempRowData["TEMP_SUPL_CODE"] = SuplCodeText.Text;
			tempRowData["TEMP_SUPL_NAME"] = string.Empty;
			tempRowData["TEMP_SUPL_SHORT_NAME"] = string.Empty;
			tempRowData["TEMP_SUPL_DEPT_NAME_1"] = string.Empty;
			tempRowData["TEMP_SUPL_DEPT_NAME_2"] = string.Empty;
			tempRowData["TEMP_SUPL_COUNTRY_CODE"] = this.CountryCode;
			tempRowData["TEMP_SUPL_ZIP"] = string.Empty;
			tempRowData["TEMP_SUPL_STATE"] = string.Empty;
			tempRowData["TEMP_SUPL_CITY"] = string.Empty;
			tempRowData["TEMP_SUPL_ADDRESS1"] = string.Empty;
			tempRowData["TEMP_SUPL_ADDRESS2"] = string.Empty;
			tempRowData["TEMP_SUPL_PHONE"] = string.Empty;
			tempRowData["TEMP_SUPL_FAX"] = string.Empty;
			tempRowData["TEMP_SUPL_USER_NAME"] = string.Empty;
			tempRowData["AC_TYPE"] = string.Empty;
			tempRowData["AC_HOLDER"] = string.Empty;
			tempRowData["AC_NO"] = string.Empty;
			tempRowData["BANK_AC_TYPE"] = string.Empty;
			tempRowData["BANK_COUNTRY_CODE"] = string.Empty;
			tempRowData["BANK_CODE"] = string.Empty;
			tempRowData["BANK_BRANCH_CODE"] = string.Empty;
			//発注では使用しないが共通ダイアログとのI/F用に設定
			tempRowData["REMIT_FEE_TYPE"] = "1";
			tempRowData["REMIT_MTHD_1_DEAL_TYPE"] = "1";
			tempRowData["REMIT_MTHD_2_TYPE"] = "1";
		}

		/// <summary>
		/// ヘッダ活性制御
		/// </summary>
		/// <param name="condition"></param>
		private void setHeaderControlCondition(bool condition)
		{
			PuNoText.Enabled			= condition;
			PoRefText.Enabled			= condition;
			RcptRefText.Enabled			= condition;
			PuDateText.Enabled			= condition;
			StatusDropdownlist.Enabled	= condition;
			SuplCodeText.Enabled		= condition;
			SuplNameText.Enabled		= condition;
			DealDateText.Enabled		= condition;
			PuModeTypeList.Enabled		= condition;
			RefPuText.Enabled			= condition;
			SuplBillSlipNoText.Enabled	= condition;
			CurCodeList.Enabled			= condition;
			EmpCodeText.Enabled			= condition;
			DeptCodeText.Enabled		= condition;
			ProjCodeText.Enabled		= condition;
			DeliTypeWRadio.Enabled		= condition;
			WhCodeText.Enabled			= condition;
			DeliTypeDRadio.Enabled		= condition;
			DeliCustCodeText.Enabled	= condition;
		}
// 管理番号 B24264 To

// 管理番号 K24789 From
		// 税情報入力画面へのパラメータ取得
		private string getTaxInfoParameter(string appendedidpart, DataRowView drv, bool edit)
		{
			string compareDate = DateValidator.IsDate(DealDateText.Text.Trim()) ? DealDateText.Text.Trim() : todayDate;

			StringBuilder sb = new StringBuilder();
			if (edit)
			{
				//編集行の税ボタン
				sb.Append("__openCtaxSearchWindowInputRow()");	// 新規行と共通
			}
			else
			{
				//表示行の税ボタン
				sb.Append("__openCtaxWindowItemRow(");
				sb.Append("'2',");
				sb.Append("'1',");
				sb.Append("'").Append(compareDate).Append("',");
				sb.Append("'").Append(drv["CTAX_CALC_TYPE"].ToString()).Append("',");
				sb.Append("'").Append(drv["CTAX_TYPE_CODE"].ToString()).Append("',");
				sb.Append("'").Append(drv["CTAX_RATE_CODE"].ToString()).Append("',");
				sb.Append("'").Append(drv["CTAX_RATE"].ToString()).Append("'");
				sb.Append(")");
			}
			return sb.ToString();
		}
// 管理番号 K24789 To
		#endregion

		#region ロット関連の制御
		private string lotDetailForItemRow(string appendedidpart, DataRowView drv, bool edit)
		{
			string mode			= "4";
			string compDate		= this.PuDateText.Text.Trim().Length==0 ? DateTime.Today.ToString() : this.PuDateText.Text.Trim();
			string deptCode		= this.DeptCodeText.Text.Trim();
			string isRcptExe	= drv["IS_RCPT_EXECUTE"].ToString();
			// 管理番号 B11723・B11796 From
			//			string initQt		= Infocom.Allegro.SC.MS.Common.FormatQt(drv["UPPER_LIMIT_PU_QT"].ToString(), false, "2");
			string initQt		= drv["UPPER_LIMIT_PU_QT"].ToString();
			// 管理番号 B11723・B11796 To
			string refSlipNo	= "dummy";
			string refSlipType	= "SM3";
			string lineId		= string.Empty;
			string myCompQt		= this.qtMaxValue;
			// 管理番号 B11723・B11796 From
			//			string puQt			= Infocom.Allegro.SC.MS.Common.FormatQt(drv["PU_QT"].ToString(), false, "2");
			string puQt			= drv["PU_QT"].ToString();
			// 管理番号 B11723・B11796 To

			//預り以外
// 管理番号K27058 From
//			if (this.PuModeTypeList.SelectedValue!="4")
			if (this.puModeType != "4")
// 管理番号K27058 To
			{
				string refPuNo = string.Empty;

// 管理番号K27058 From
//				if (this.PuModeTypeList.SelectedValue=="2")
				if (this.puModeType == "2")
// 管理番号K27058 To
				{
					if (paramType==ParamCodeType.MOD || paramType==ParamCodeType.VIEW)
					{
						refPuNo = rowData.RefPuNo;
					}
					else
					{
						refPuNo = keyColumn.SlipNo;
					}
				}

				if(rowData.RefPuNo.Length != 0 || refPuNo.Length!=0)	//返品
				{
					refSlipNo   = refPuNo;
					refSlipType = "SM3";
					lineId      = drv["PU_LINE_ID"].ToString();
					myCompQt    = initQt;
					mode        = isRcptExe == "1" ? "12" : "6";
				}
// 管理番号K27058 From
//				else if(this.PuModeTypeList.SelectedValue == "2")		//参照なし返品
				else if (this.puModeType == "2")		//参照なし返品
// 管理番号K27058 To
				{
					refSlipNo   = refPuNo;
					refSlipType = "SM3";
					lineId      = drv["PU_LINE_ID"].ToString();
					//myCompQt    = myCompQt;
					mode        = "11";
				}
				else if (drv["RCPT_NO"]!=System.DBNull.Value)			//入荷参照
				{
					refSlipNo   = drv["RCPT_NO"].ToString();
					refSlipType = "SM2";
					lineId      = drv["RCPT_LINE_ID"].ToString();
					myCompQt    = initQt;
					mode        = "5";
				}
				else if(drv["PO_NO"]!=System.DBNull.Value)				//発注参照
				{
					refSlipNo   = drv["PO_NO"].ToString();
					refSlipType = "SM1";
					lineId      = drv["PO_LINE_ID"].ToString();
					myCompQt    = isRcptExe=="1" ? initQt : myCompQt;
					mode        = isRcptExe=="1" ? "7" : "9";
				}
				else
				{
					refSlipNo = slipNo;
					lineId = drv["PU_LINE_ID"].ToString();
					myCompQt = initQt;
					mode = "4";
				}
			}
			else
			{
				refSlipNo = slipNo;
				lineId   = drv["PU_LINE_ID"].ToString();
				mode     = "10";
			}

			StringBuilder sb = new StringBuilder();
			if(edit)
			{
				sb.Append("__openLotDetailWindowEditRow( ");
				sb.Append("'").Append(appendedidpart					).Append("',");
				sb.Append("'").Append(mode								).Append("',");
				sb.Append("'").Append(refSlipNo							).Append("',");
				sb.Append("'").Append(refSlipType						).Append("',");
// 管理番号B25752 From
				sb.Append("'").Append(slipNo							).Append("',");
// 管理番号B25752 To
				sb.Append("'").Append(myCompQt							).Append("' )");
			}
			else
			{
				sb.Append("__openLotDetailWindowItemRow( ");
				sb.Append("'").Append(appendedidpart					).Append("',");
				sb.Append("'").Append(mode								).Append("',");
				sb.Append("'").Append(drv["PU_LINE_ID"].ToString()		).Append("',");
				sb.Append("'").Append(drv["PROD_CODE"].ToString()		).Append("',");
				sb.Append("'").Append(drv["PROD_SPEC_1_CODE"].ToString()).Append("',");
				sb.Append("'").Append(drv["PROD_SPEC_2_CODE"].ToString()).Append("',");
				sb.Append("'").Append(drv["UNIT_CODE"].ToString()		).Append("',");
				sb.Append("'").Append(drv["WH_CODE"].ToString()			).Append("',");
				sb.Append("'").Append(refSlipNo							).Append("',");
				sb.Append("'").Append(refSlipType						).Append("',");
				sb.Append("'").Append(lineId		                    ).Append("',");
				sb.Append("'").Append(myCompQt							).Append("',");
// 管理番号 B22255 From
//				sb.Append("'").Append(puQt								).Append("' )");
				sb.Append("'").Append(puQt								).Append("',");
				sb.Append("'").Append(slipNo                            ).Append("',");
				sb.Append("'").Append(rowData.OppositePuNo.Length==0?"0":"1").Append("')");
// 管理番号 B22255 To
			}
			return sb.ToString();
		}

		private bool SetLotInfo(bool isCreate, object lineId)
		{
			decimal id = 0M;
			id = lineId is decimal ? (decimal)lineId : decimal.Parse(lineId.ToString());
			if (!isCreate)
			{
				rowData.DeleteLotDetailRow(id, false);
				//ロット差分
				lotDiff = true;
			}
			else
			{
				//今のところ処理なし
			}
			return true;
		}
		#endregion

		#region 明細行コントロール
		private SC_MM_05_S02_ROW_CONTROLS GetControls(DataGridItem gItem)
		{
			SC_MM_05_S02_ROW_CONTROLS controls = new SC_MM_05_S02_ROW_CONTROLS();

			try
			{
				if (gItem == null)	//登録行
				{
					controls.Inp				= "1";
					controls.PuLineId			= rowData.NewRowLineID.ToString();
					controls.ProdEditLabel		= InpProdEditFlg;
					controls.ProdCodeText		= InpProdCodeText;
					controls.ProdShortNameLabel	= InpProdShortNameLabel;
					controls.ProdPuNameText		= InpProdNameText;
					controls.ProdSpec1List		= InpProdSpec1List;
					controls.ProdSpec2List		= InpProdSpec2List;
					controls.WhCodeText			= InpWhCodeText;
					controls.WhNameLabel		= InpWhShortNameLabel;
					controls.LotDtilButton		= InpLotDtilButton;
					controls.PuQtText			= InpPuQtText;
					controls.UnitList			= InpUnitList;
					controls.PuPriceText		= InpPuPriceText;
					controls.PuPlanPriceLabel   = InpPuPlanPriceLabel;
					// 管理番号 B13878 From
					controls.PriceUndecidedFlgCheck = InpPriceUndecidedFlgCheck;
					if(this.PriceUndecidedUseFlg)
					{
						controls.PriceUndecidedFlgCheck.Visible = true;
					}
					else
					{
						controls.PriceUndecidedFlgCheck.Visible = false;
						controls.PuPriceText.NextControlID = controls.PriceUndecidedFlgCheck.NextControlID;
					}
					// 管理番号 B13878 To
					controls.InitPuPriceText	= InpInitPuPriceText;
					controls.PuMoneyLabel		= InpPuMoneyLabel;
					controls.RemarksCodeText	= InpRemarksCodeText;
					controls.RemarksText		= InpRemarksText;
// 管理番号K27525 From
					controls.BookDeductionReasonCodeList = InpBookDeductionReasonCodeList;
// 管理番号K27525 To
					controls.IsRcptExecuteFlg	= InpIsRcptExecuteFlg;
					controls.StockAdminFlg		= InpStockAdminFlg;
					controls.LotAdminFlg		= InpLotAdminFlg;
// 管理番号 K25322 From
					controls.LotStockValuationFlg= InpLotStockValuationFlg;		//ロット別在庫評価
// 管理番号 K25322 To
					controls.QtDecimalUseFlg	= InpQtDecimalUseFlg;
					controls.CtaxCalcTypeLabel	= InpCtaxCalcTypeLabel;
// 管理番号 K24789 From
//					controls.CtaxCalcType		= InpCtaxCalcType;
// 管理番号 K24789 To
					controls.CtaxRate			= InpCtaxRate;
// 管理番号 K24789 From
//					controls.CtaxRateCode		= InpCtaxRateCode;
// 管理番号 K24789 To
					controls.ProdType			= InpProdType;
					controls.DispControlType	= InpDispControlType;
					controls.IncludeQt			= InpIncludeQt;
					controls.AllowProdName		= InpAllowProdName;
					//初期値
					controls.DiscFlg			= InpDiscFlg;
					controls.StdSellPrice		= InpStdSellPrice;
// 管理番号 K24789 From
					controls.TaxInfoButton		= InpTaxInfoButton;
// 管理番号 K24789 To
					controls.UpdateButton		= null;
					controls.RegistButton		= RegistButton;
					controls.ProdTypeHidden		= inputRowProdTypeHidden;
					controls.DispTypeHidden		= inputRowDispTypeHidden;
					controls.RcptLineId			    = string.Empty;
					controls.PoLineId				= string.Empty;
// 管理番号K27057 From
					controls.CustomItemPanel = this.InpCustomItemPanel;
// 管理番号K27057 To
				}
				else	//明細行
				{
					controls.Inp				= "0";
					controls.PuLineId			= DataGrid1.DataKeys[gItem.ItemIndex].ToString();
					controls.ProdEditLabel		= (EncodeLabel)gItem.FindControl("ProdEditFlg");
					controls.ProdCodeText		= (CustomTextBox)gItem.FindControl("EditProdCodeText");
					controls.ProdShortNameLabel	= (EncodeLabel)gItem.FindControl("EditProdShortNameLabel");
					controls.ProdPuNameText		= (CustomTextBox)gItem.FindControl("EditProdNameText");
					controls.ProdSpec1List		= (CustomDropDownList)gItem.FindControl("EditProdSpec1List");
					controls.ProdSpec2List		= (CustomDropDownList)gItem.FindControl("EditProdSpec2List");
					controls.WhCodeText			= (CustomTextBox)gItem.FindControl("EditWhCodeText");
					controls.WhNameLabel		= (EncodeLabel)gItem.FindControl("EditWhShortNameLabel");
					controls.LotDtilButton		= (StyledButton)gItem.FindControl("LotDtilButtonEdit");
					controls.PuQtText			= (NumberBox)gItem.FindControl("EditPuQtText");
					controls.InitPuQtText		= (EncodeLabel)gItem.FindControl("EditInitPuQt");
					controls.UnitList			= (CustomDropDownList)gItem.FindControl("EditUnitList");
					controls.PuPriceText		= (NumberBox)gItem.FindControl("EditPuPriceText");
					controls.PuPlanPriceLabel   = (EncodeLabel)gItem.FindControl("EditPuPlanPriceLabel");
					// 管理番号 B13878 From
					controls.PriceUndecidedFlgCheck	= (CustomCheckBox)gItem.FindControl("EditPriceUndecidedCheck");
					if(this.PriceUndecidedUseFlg)
					{
						controls.PriceUndecidedFlgCheck.Visible = true;
					}
					else
					{
						controls.PriceUndecidedFlgCheck.Visible = false;
						controls.PuPriceText.NextControlID = controls.PriceUndecidedFlgCheck.NextControlID;
					}
					// 管理番号 B13878 To
					controls.InitPuPriceText	= (NumberBox)gItem.FindControl("EditInitPuPriceText");
					controls.PuMoneyLabel		= (EncodeLabel)gItem.FindControl("PuMoneyLabel2");
					controls.RemarksCodeText	= (CustomTextBox)gItem.FindControl("EditRemarksCodeText");
					controls.RemarksText		= (CustomTextBox)gItem.FindControl("EditRemarksText");
// 管理番号K27525 From
					controls.BookDeductionReasonCodeList = (CustomDropDownList)gItem.FindControl("EditBookDeductionReasonCodeList");
// 管理番号K27525 To
					controls.IsRcptExecuteFlg	= (EncodeLabel)gItem.FindControl("EditIsRcptExecuteFlg");
					controls.StockAdminFlg		= (EncodeLabel)gItem.FindControl("EditStockAdminFlg");
					controls.LotAdminFlg		= (EncodeLabel)gItem.FindControl("EditLotAdminFlg");
// 管理番号 K25322 From
					controls.LotStockValuationFlg	= (EncodeLabel)gItem.FindControl("EditLotStockValuationFlg");
// 管理番号 K25322 To
					controls.QtDecimalUseFlg	= (EncodeLabel)gItem.FindControl("EditQtDecimalUseFlg");
// 管理番号 B18058 From
//					controls.CtaxCalcTypeLabel	= (EncodeLabel)gItem.FindControl("EditCtaxCalcType");
					controls.CtaxCalcTypeLabel	= (EncodeLabel)gItem.FindControl("CtaxCalcType2");
// 管理番号 B18058 To
// 管理番号 K24789 From
//					controls.CtaxCalcType		= (EncodeLabel)gItem.FindControl("EditCtaxCalcType");
// 管理番号 K24789 To
					controls.CtaxRate			= (EncodeLabel)gItem.FindControl("EditCtaxRate");
// 管理番号 K24789 From
//					controls.CtaxRateCode		= (EncodeLabel)gItem.FindControl("EditCtaxRateCode");
// 管理番号 K24789 To
					controls.ProdType			= (EncodeLabel)gItem.FindControl("EditProdType");
					controls.DispControlType	= (EncodeLabel)gItem.FindControl("EditDispControlType");
					controls.IncludeQt			= (EncodeLabel)gItem.FindControl("EditIncludeQt");
					controls.AllowProdName		= (EncodeLabel)gItem.FindControl("EditAllowProdName");
					controls.DiscFlg			= (EncodeLabel)gItem.FindControl("EditDispFlg");
					controls.StdSellPrice		= (EncodeLabel)gItem.FindControl("EditStdSellPrice");
// 管理番号 K24789 From
					controls.TaxInfoButton		= (StyledButton)gItem.FindControl("EditTaxInfoButton");
// 管理番号 K24789 To
					controls.UpdateButton		= (StyledButton)gItem.FindControl("EditUpdateButton");
					controls.RegistButton		= (StyledButton)gItem.FindControl("EditRegistButton");
					controls.ProdTypeHidden		= editRowProdTypeHidden;
					controls.DispTypeHidden		= editRowDispTypeHidden;
					controls.RcptLineId         = ((EncodeLabel)gItem.FindControl("RcptLineIdEdit")).Text;
					controls.PoLineId			= ((EncodeLabel)gItem.FindControl("PoLineIdEdit")).Text;
// 管理番号K27057 From
					controls.CustomItemPanel = (CustomItemPanel)gItem.FindControl("EditCustomItemPanel");
// 管理番号K27057 To
				}
				controls.ProdNameHdn   				= ProdNameHdn;
				controls.ProdShortNameHdn		= ProdShortNameHdn;
// 管理番号 B12929 From
				controls.InitPuPriceHdn			= InitPuPriceHdn;
				controls.PriceUpdateFlgHdn		= PriceUpdateFlgHdn;
// 管理番号 B12929 To
// 管理番号 K24789 From
				controls.CtaxCalcTypeHdn		= CtaxCalcTypeHdn;
				controls.CtaxTypeCodeHdn		= CtaxTypeCodeHdn;
				controls.CtaxRateCodeHdn		= CtaxRateCodeHdn;
				controls.TaxInfoChgFlgHdn		= TaxInfoChgFlgHdn;
// 管理番号 K24789 To
			}
			catch (System.Exception)
			{
				controls = null;
			}
			return controls;
		}

		private void ClearControls(SC_MM_05_S02_ROW_CONTROLS ctl)
		{
			if (ctl == null) return;

			ctl.Inp					= null;
			ctl.PuLineId			= null;
			ctl.ProdEditLabel		= null;
			ctl.ProdCodeText		= null;
			ctl.ProdShortNameLabel	= null;
			ctl.ProdPuNameText		= null;
			ctl.ProdSpec1List		= null;
			ctl.ProdSpec2List		= null;
			ctl.WhCodeText			= null;
			ctl.WhNameLabel			= null;
			ctl.LotDtilButton		= null;
			ctl.PuQtText			= null;
			ctl.UnitList			= null;
			ctl.PuPriceText			= null;
			ctl.PuPlanPriceLabel    = null;
			ctl.InitPuPriceText		= null;
			ctl.PuMoneyLabel		= null;
			ctl.RemarksCodeText		= null;
			ctl.RemarksText			= null;
// 管理番号K27525 From
			ctl.BookDeductionReasonCodeList = null;
// 管理番号K27525 To
			ctl.StockAdminFlg		= null;
			ctl.LotAdminFlg			= null;
// 管理番号 K25322 From
            ctl.LotStockValuationFlg= null;
// 管理番号 K25322 To
			ctl.QtDecimalUseFlg		= null;
			ctl.CtaxCalcTypeLabel	= null;
// 管理番号 K24789 From
//			ctl.CtaxCalcType		= null;
// 管理番号 K24789 To
			ctl.CtaxRate			= null;
			ctl.ProdType			= null;
			ctl.DispControlType		= null;
			ctl.IncludeQt			= null;
			ctl.AllowProdName		= null;
			ctl.DiscFlg				= null;
			ctl.StdSellPrice		= null;
			ctl.UpdateButton		= null;
			ctl.RegistButton		= null;
			ctl.ProdTypeHidden		= null;
			ctl.DispTypeHidden		= null;
			ctl.ProdNameHdn   		= null;
			ctl.ProdShortNameHdn= null;
// 管理番号 B12929 From
			ctl.InitPuPriceHdn		= null;
			ctl.PriceUpdateFlgHdn	= null;
// 管理番号 B12929 To
// 管理番号 K24789 From
			ctl.TaxInfoButton		= null;	// 税情報ボタン
			ctl.CtaxCalcTypeHdn		= null;	// 税計算区分(商品)
			ctl.CtaxTypeCodeHdn		= null;	// 税区分コード(商品)
			ctl.CtaxRateCodeHdn		= null;	// 税率コード(商品)
			ctl.TaxInfoChgFlgHdn	= null;	// 税情報変更フラグ
// 管理番号 K24789 To
		}

		#endregion

		#region Print Method
		// 管理番号 B13879 From
		//		private void printList(object sender, string printPuNo, out string reportMess)
		private void printList(object sender, string printPuNo, string puModeType, out string reportMess)
			// 管理番号 B13879 To
		{
			reportMess = string.Empty;

			// 印刷が未チェック時は終了
			// 管理番号 B13879 From
			//			bool isPrint = this.printListHidden.Value=="1";
			bool isPrint = this.printListHidden.Value=="1" || printHidden.Value=="1";
			// 管理番号 B13879 To
			if (!isPrint) return;
// 管理番号K26528 From
//// 管理番号 B18049 From
//			// 印刷ダイアログの出力制御
//			// 仕入一覧表
//			if (printListHidden.Value=="1")
//			{
//				this.ShowsPrintDialogLabel.Text	=Infocom.Allegro.CM.MS.Report.ShowsPrintDialog(this.CommonData,"SC_MM_05_R03",Infocom.Allegro.Report.ScreenType.Input).ToString();
//			}
//
//			// 仕入伝票
//			else if (printHidden.Value=="1")
//			{
//				this.ShowsPrintDialogLabel.Text	=Infocom.Allegro.CM.MS.Report.ShowsPrintDialog(this.CommonData,"SC_MM_05_R01",Infocom.Allegro.Report.ScreenType.Input).ToString();
//			}
//
//			// どちらにもチェックが入っていない場合はfalse
//			else
//			{
//				this.ShowsPrintDialogLabel.Text	= "false";
//			}
//// 管理番号 B18049 To
// 管理番号K26528 To

			//仕入一覧表の出力時
			// 管理番号 B13879 From
			//			if (printListHidden.Value == "1")
			if (printListHidden.Value == "1" || printHidden.Value=="1")
				// 管理番号 B13879 To
			{
				IF_SC_MM_05_S01_SearchCondition searchCondition = new IF_SC_MM_05_S01_SearchCondition();
				searchCondition.OverseasFlg = "0";
				searchCondition.PuNoFrom = searchCondition.PuNoTo = printPuNo;
				//出力条件の設定
				Session.Add(Report.Constants.SessionName, searchCondition);
			}
// 管理番号K26528 From
//			//プレビュー
//			if (clickHidden.Value=="1")
//			{
//				//帳票出力要求からの呼び出し
//				if (!ClientScript.IsStartupScriptRegistered("executePrint"))
//				{
//					//プレビュー画面の呼び出し
//					StringBuilder script = new StringBuilder();
//
//					script.Append("<script type=\"text/javascript\">\n");
//					script.Append("<!--\n");
//					script.Append("	CM_openModalDialog(\"SC_MM_05_R03\",");
//					script.Append("\"");
//					script.Append(Report.Constants.PrevTerm).Append("=").Append(Report.Constants.ReportPrint);
//					//出力条件の設定
//					script.Append("&PuNo=").Append(printPuNo);
//					script.Append("&CurrencyCode=").Append(this.KeyCurrencyCode);
//					script.Append("&PuListOutputFlg=").Append(printListHidden.Value);
//					// 管理番号 B13879 From
//					script.Append("&PuOutputFlg=").Append(printHidden.Value);
//					script.Append("&PuModeType=").Append(puModeType);
//					// 管理番号 B13879 To
//// 管理番号 B17215 From
//					script.Append("&MycompQtDecimalUseFlg=").Append(this.QtDecimalUseFlg ? "1" : "0");
//// 管理番号 B17215 To
//					script.Append("\");\n");
//					script.Append("-->\n");
//					script.Append("</script>");
//					Page.ClientScript.RegisterStartupScript(this.GetType(), "executePrint",script.ToString());
//				}
//			}
//			else
//			{
//				//帳票出力要求からの呼び出し
//				if (!ClientScript.IsStartupScriptRegistered("executePrint"))
//				{
//					//印刷データを取得する
//					StringBuilder script = new StringBuilder();
//					script.Append("<script type=\"text/vbscript\">\n");
//					script.Append("<!--\n");
//					script.Append("sub arv_ControlLoaded()\n");
//					script.Append("	Form1.arv.DataPath = \"SC_MM_05_R03.aspx?");
//					script.Append(Report.Constants.PrintTerm);
//					script.Append("=");
//					script.Append(Report.Constants.ReportPrint);
//					// 管理番号 B13879 From
//					script.Append("&PuListOutputFlg=").Append(printListHidden.Value);
//					script.Append("&PuOutputFlg=").Append(printHidden.Value);
//					script.Append("&PuModeType=").Append(puModeType);
//					// 管理番号 B13879 To
//// 管理番号 B17215 From
//					script.Append("&MycompQtDecimalUseFlg=").Append(this.QtDecimalUseFlg ? "1" : "0");
//// 管理番号 B17215 To
//					script.Append("\"\n");
//					//マウスポインタのカーソル設定
//					script.Append("	document.body.style.cursor=\"wait\"\n");
//					script.Append("	printingFlg=true\n");
//					script.Append("end sub\n");
//					script.Append("-->\n");
//					script.Append("</script>");
//					Page.ClientScript.RegisterStartupScript(this.GetType(), "executePrint",script.ToString());
//				}
//			}
//
//			if (sender!=this.UpdateButton)
//			{
//				if (clickHidden.Value!="1")
//				{
//					// 帳票ボタン
//					reportMess = "<span id=\"reportMess\" name=\"reportMess\">"+AllegroMessage.R00001+"</span>";
//					setMessageLabel(HtmlMessage(reportMess, MessageLevel.Info));
//				}
//				this.reportMessHidden.Value = "0";
//			}
//			else
//			{
//				// 更新ボタン
//				reportMess = "<span id=\"reportMess\" name=\"reportMess\"><br>"+AllegroMessage.R00001+"</span>";
//				this.reportMessHidden.Value = "1";
//			}
			if (!PageStartupScript.IsScriptRegistered("executePrint"))
			{
				StringBuilder script = new StringBuilder();
				PDFType pdfExportType = PDFType.Save;
				if (clickHidden.Value == "1")
				{
					script.Append(Report.Constants.PrevTerm).Append("=").Append(Report.Constants.ReportPrint).Append("&");
					pdfExportType = PDFType.View;
				}
				//出力条件の設定
// 管理番号K27478 From
//				script.Append("PuListOutputFlg=").Append(printListHidden.Value);
//				script.Append("&PuOutputFlg=").Append(printHidden.Value);
//				script.Append("&PuModeType=").Append(puModeType);
				script.Append("PuListOutputFlg=").Append(Server.UrlEncode(printListHidden.Value));
				script.Append("&PuOutputFlg=").Append(Server.UrlEncode(printHidden.Value));
				script.Append("&PuModeType=").Append(Server.UrlEncode(puModeType));
// 管理番号K27478 To
				script.Append("&MycompQtDecimalUseFlg=").Append(this.QtDecimalUseFlg ? "1" : "0");
				string reportName = CM.MS.Report.GetReportName(this.CommonData, getFileName(printListHidden.Value, printHidden.Value));
				string printScript = ReportExport.MakePrintScript("SC_MM_05_R03", script.ToString(), pdfExportType, reportName);
				PageStartupScript.RegisterScript(this.GetType(), "executePrint", printScript);
			}
// 管理番号K26528 To
		}

// 管理番号K26528 From
		private string[] getFileName(string puListOutputFlg, string puOutputFlg)
		{
			List<string> list = new List<string>();
			// 仕入確認票
			if (puListOutputFlg == "1")
			{
				list.Add("SC_MM_05_R03");
			}
			// 仕入伝票
			if (puOutputFlg == "1")
			{
				list.Add("SC_MM_05_R01");
			}
			return list.ToArray();
		}
// 管理番号K26528 To
		#endregion

// 管理番号K26528 From
//		#region Scroll Method
//		private void ScrollBottom()
//		{
//			if (!ClientScript.IsStartupScriptRegistered("ForScroll"))
//			{
//				ClientScript.RegisterStartupScript(this.GetType(), "ForScroll", "<script type=\"text/javascript\">\r\n<!--\r\n\tscrollBottom(\"" + DataGrid1.ID + "\");\r\n// -->\r\n</script>");
//			}
//		}
//
//		//グリッド表示位置移動
//		private void ScrollRow(string item)
//		{
//			if (!ClientScript.IsStartupScriptRegistered("ForScroll"))
//			{
//				string script = new StringBuilder("<script type=\"text/javascript\">\r\n<!--\r\n\tscrollBottomSelect(\"").Append(item).Append("\");\r\n// -->\r\n</script>").ToString();
//				ClientScript.RegisterStartupScript(this.GetType(), "ForScroll", script);
//			}
//		}
//		#endregion
// 管理番号K26528 To

		#region Lock Method
		private bool getLock(string lockSlipNo)
		{
			string message = string.Empty;
			bool result = true;
			try
			{
// 管理番号K26508 From
				// 権限設定区分が"U"：更新権限の場合、悲観ロックを取得する
				if (this.AuthoritySettingType == "U")
				{
// 管理番号K26508 To
					result = Lock.GetLock(this.CommonData, Request, Session, pageCode, lockSlipNo, out message);
					if (!result)
					{
// 管理番号K26528 From
//					string script = @"<script type=""text/javascript"">
//					<!--
//						alert(""" + message + @""");
//					// -->
//					</script>";
//					ClientScript.RegisterStartupScript(this.GetType(), "alertLock", script);
						var script = new StringBuilder();
						script.Append("alert('" + message + "');");
						PageStartupScript.RegisterScript(this.GetType(), "alertLock", script.ToString());
// 管理番号K26528 To
					}
					else
					{
						lockedPuNo = slipNo;
					}
// 管理番号K26508 From
				}
// 管理番号K26508 To
			}
			catch (AllegroException ex)
			{
				result = false;
				setMessageLabel(ex.HtmlMessage);
			}
			return result;
		}

		private bool releaseLock(string releaseCode)
		{
			bool result = true;
			try
			{
// 管理番号K26508 From
//				Lock.ReleaseLock(this.CommonData, Session, pageCode, releaseCode);
				// 権限設定区分が"U"：更新権限の場合、悲観ロックを開放する
				if (this.AuthoritySettingType == "U")
				{
					Lock.ReleaseLock(this.CommonData, Session, pageCode, releaseCode);
				}
// 管理番号K26508 To
			}
			catch (AllegroException ex)
			{
				result = false;
				setMessageLabel(ex.HtmlMessage);
			}
			return result;
		}
		#endregion

		#region クラス
		private class SC_MM_05_S02_ROW_CONTROLS
		{
			internal string Inp			= "0";	// "0":編集行、"1":登録行
			internal string PuLineId	= null;	// 仕入行ID

			internal EncodeLabel		ProdEditLabel		= null;	// 商品変更可否
			internal CustomTextBox		ProdCodeText		= null;	// 商品コード
			internal CustomTextBox		ProdPuNameText		= null;	// 商品名
			internal EncodeLabel		ProdShortNameLabel	= null;	// 商品略名
			internal CustomDropDownList	ProdSpec1List		= null;	// 商品規格1
			internal CustomDropDownList	ProdSpec2List		= null;	// 商品規格2
			internal CustomTextBox		WhCodeText			= null;	// 倉庫コード
			internal EncodeLabel		WhNameLabel			= null;	// 倉庫名
			internal StyledButton	LotDtilButton		= null;	// ロット詳細ボタン
			internal NumberBox			PuQtText			= null;	// 仕入数量
			internal EncodeLabel		InitPuQtText		= null;	//
			internal CustomDropDownList	UnitList			= null;	// 商品単位
			internal NumberBox			PuPriceText			= null;	// 仕入単価
			internal EncodeLabel        PuPlanPriceLabel    = null;	// 仕入予定単価
			internal NumberBox			InitPuPriceText		= null;	//
			// 管理番号 B13878 From
			internal CustomCheckBox		PriceUndecidedFlgCheck = null; // 単価未決フラグ
			// 管理番号 B13878 To
			internal EncodeLabel		PuMoneyLabel		= null;	// 仕入金額
			internal CustomTextBox		RemarksCodeText		= null;	// 行摘要コード
			internal CustomTextBox		RemarksText			= null;	// 行摘要
// 管理番号K27525 From
			internal CustomDropDownList	BookDeductionReasonCodeList = null;	// 帳簿控除理由
// 管理番号K27525 To
			internal EncodeLabel		IsRcptExecuteFlg	= null;	// 入荷済フラグ
			internal EncodeLabel		StockAdminFlg		= null;	// 在庫管理フラグ
			internal EncodeLabel		LotAdminFlg			= null;	// ロット管理フラグ
// 管理番号 K25322 From
			internal EncodeLabel		LotStockValuationFlg= null;	// ロット別在庫評価フラグ
// 管理番号 K25322 To
			internal EncodeLabel		QtDecimalUseFlg		= null;	// 小数使用フラグ
			internal EncodeLabel		CtaxCalcTypeLabel	= null;	// 税計算区分表記
// 管理番号 K24789 From
//			internal EncodeLabel		CtaxCalcType		= null;	// 税計算区分
// 管理番号 K24789 To
			internal EncodeLabel		CtaxRate			= null;	// 消費税率
// 管理番号 K24789 From
//			internal EncodeLabel        CtaxRateCode		= null;	// 消費税計算区分
// 管理番号 K24789 To
			internal EncodeLabel		ProdType			= null;	// 商品区分
			internal EncodeLabel		DispControlType		= null;	// 表示制御区分
			internal EncodeLabel		IncludeQt			= null;	// 入数
			internal EncodeLabel		AllowProdName		= null;	// 商品名訂正許可フラグ
			internal EncodeLabel		DiscFlg				= null;	// 値引フラグ
			internal EncodeLabel		StdSellPrice		= null;	// 販売単価？？？？
// 管理番号 K24789 From
			internal StyledButton	TaxInfoButton		= null;	// 税ボタン
// 管理番号 K24789 To
			internal StyledButton	UpdateButton		= null;	// 更新ボタン
			internal StyledButton	RegistButton		= null;	// 登録ボタン
			internal HtmlInputHidden	ProdTypeHidden		= null;	//
			internal HtmlInputHidden	DispTypeHidden		= null;	//

			internal HtmlInputHidden	ProdNameHdn			= null;	// 商品.商品名
			internal HtmlInputHidden	ProdShortNameHdn	= null;	// 商品.商品略名
// 管理番号 B12929 From
			internal HtmlInputHidden	InitPuPriceHdn		= null;	// 初期仕入単価
			internal HtmlInputHidden	PriceUpdateFlgHdn	= null;	// 単価更新フラグ
// 管理番号 B12929 To
// 管理番号 K24789 From
			internal HtmlInputHidden	CtaxCalcTypeHdn		= null;	// 税計算区分(商品)
			internal HtmlInputHidden	CtaxRateCodeHdn		= null;	// 税率コード(商品)
			internal HtmlInputHidden	CtaxTypeCodeHdn		= null;	// 税区分コード(商品)
			internal HtmlInputHidden	TaxInfoChgFlgHdn	= null;	// 税情報変更フラグ(1:変更あり)
// 管理番号 K24789 To
			internal string				RcptLineId 	        = null;	// 入荷行ID
			internal string				PoLineId 	        = null;	// 発注行ID
// 管理番号K27057 From
			internal CustomItemPanel CustomItemPanel = null;
// 管理番号K27057 To
		}

		#endregion

		#region その他
		//管理番号 B13502 From
		private string generalDateString
		{
			get
			{
				return DateValidator.IsDate(this.PuDateText.Text.Trim()) ? this.PuDateText.Text.Trim() : this.todayDate;
			}
		}
		private DateTime generalDateTime
		{
			get
			{
				return DateValidator.IsDate(this.PuDateText.Text.Trim()) ? DateTime.Parse(this.PuDateText.Text.Trim()) : DateTime.Parse(this.todayDate);
			}
		}
		private string todayDate
		{
			get
			{
				return DateTime.Today.ToString("yyyy/MM/dd");
			}
		}
		//管理番号 B13502 To
// 管理番号 K22217 From
        //承認経路情報のセッションデータを削除する
        private void SessionRemove()
        {
            Session.Remove("CM_WF_03_S08_AppEmp");
            Session.Remove("CM_WF_03_S08_AppRouteId");
// 管理番号 K24546 From
//			RouteChangeButton.ImageUrl = "img/CM_b2_route_change_off.gif";
			RouteChangeButton.CssClass = "normal";
// 管理番号 K24546 To
        }
// 管理番号 K22217 To
		#endregion
// 管理番号K26508 From
		#region 参照権限制御
		// 権限設定区分が"V"：参照権限の場合、データ更新不可となるようデータグリッドを制御する。
		private void viewAuthorityUnclickableDataGrid(ClickableDataGrid dataGrid)
		{
			if (this.AuthoritySettingType == "V")
			{
				// データグリッドをクリック無効にする
				dataGrid.AutoPostBack = false;
			}
		}
		// 権限設定区分が"V"：参照権限の場合、データ更新不可となるようコントロールを制御する。
		private void viewAuthorityControls()
		{
			if (this.AuthoritySettingType == "V")
			{
				// モード名表示を変更
				this.ModeLabel.Text = MultiLanguage.Get("SC_CS000765");		// 参照

				// 指定以外のコントロールを非活性にする
				// PageMode.Referenceの対象外となる項目はaspxで指定
				base.Mode = PageMode.Reference;

				// 以下のコントロールを非表示にする
				// フッタ
				this.RouteChangeButton.Visible = false;				// 経路変更ボタン

				// フォーカス遷移設定
				this.PuNoText.NextControlID = this.CloseButton.ID;	// 閉じるボタン

				// 仕入番号が読取専用の場合
				if (this.PuNoText.ReadOnly)
				{
					OverRideFocus(this.CloseButton.ID);				// 閉じるボタン
				}
				else
				{
					OverRideFocus(this.PuNoText.ID);				// 仕入番号
				}
// 管理番号K27057 From
				CustomItemPanel.Enable = false;
				InpCustomItemPanel.Enable = false;
// 管理番号K27057 To
			}
		}
		// 権限設定区分が"V"：参照権限の場合、データ更新不可となるよう明細のコントロールを制御する。
		// DataGridにはPageMode設定が反映されないため、コントロールを個別に制御する。
		// 参照権限時は編集行にならないため、表示行のコントロールのみ制御する。
		private void viewAuthorityGridControls(DataGridItem item)
		{
			if (this.AuthoritySettingType == "V")
			{
				// 詳細タブ制御
				((StyledButton) item.FindControl("ItemRegistButton")).Enabled = false;			// 表示行挿入ボタン
				((StyledButton) item.FindControl("ItemDeleteButton")).Enabled = false;			// 表示行削除ボタン
			}
		}
		#endregion
// 管理番号K26508 To
	}
}
