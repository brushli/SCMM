// Product     : Allegro
// Unit        : SC
// Module      : MM
// Function    : 05
// File Name   : SC_MM_05_S02.js
// 機能名      : SC_MM_05_S02 仕入入力
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 管理番号 B12891 2004/09/22 伝票削除時に計上部門の存在をチェックするロジックの追加
// 管理番号 B12975 2004/09/24 データグリッド既存行のファンクションキーの動作の修正
// 1.2.0 2004/09/30
// 管理番号 B13083 2004/10/13 伝票入力しない部門を表示しないように伝票入力許可フラグ追加
// 管理番号 B13382 2004/10/21 ファンクションキー制御の修正
// 1.2.2 2004/10/31
// 管理番号 B13798 2004/12/03 管理項目の追加
// 管理番号 B13502 2004/12/31 国内取引外貨決済対応
// 1.3.0 2004/12/31
// 1.3.1 2005/01/31
// 管理番号 B13877 2005/02/01 プロジェクト別在庫管理対応
// 管理番号 B13879 2005/02/03 管理帳票の追加
// 管理番号 B14788 2005/03/14 スクリプトエラーを修正
// 管理番号 B14308 2005/03/15 管理項目画面でデータ変更してもダーティチェックがされない不具合を修正
// 1.3.2 2005/03/31
// 管理番号 B15296 2005/04/25 伝票取消ダイアログの初期日付を計上日付に変更
// 管理番号 B15397 2005/04/25 プロジェクト別在庫管理対応不具合対応
// 管理番号 B15412 2005/04/27 為替番号検索から戻った時のフォーカス制御対応
// 管理番号 B15581 2005/05/17 明細の倉庫検索後に画面をポストバックさせるように修正
// 1.3.3 2005/06/30
// 管理番号 K16193 2005/10/07 振込情報参照機能追加
// 1.4.0 2005/10/31
// 管理番号 B16475 2005/11/10 仕入返品伝票登録時に、検索ウィンドウに売上仕入伝票が表示されない不具合対応
// 管理番号 B16699 2005/11/17 仕入返品時に仕入先単価更新確認メッセージが表示されないように修正
// 管理番号 K16590 2005/11/24 管理会計機能拡張（日付チェック機能強化対応）
// 管理番号 B16804 2006/01/18 決済方法マスタにて「000」の決済方法コードを登録すると伝票の支払条件のJSに生じる不具合対応
// 1.5.0 2006/03/31
// 管理番号 B19472 2007/01/12 カレンダーを参照して日付を変更した場合に、締日が変更した日付に連動した日付に変わらない対応
// 管理番号 B19805 2007/02/08 修正時伝票番号のみを変更して更新ボタンを押した時、読み込み直しのダイアログを表示させる
// 管理番号 B18952 2007/02/15 明細の商品コード未入力時にF4行登録ボタンが押下可能となっている不具合対応
// 管理番号 B20392 2007/03/20 雑コード入力時のチェック対応
// 管理番号 B20479 2007/04/16 発注参照及び入荷参照テキストボックスに存在しない伝票番号を入力した際に、仕入先と部門が入力できてしまう不具合対応
// 1.5.1 2007/06/30
// 管理番号 B21658 2008/05/28 修正モードで伝票番号を手入力し他伝票に遷移したときに、元伝票の悲観ロックが解除されない不具合対応
// 管理番号 B21594 2008/06/19 レート検索画面で選択したレート及び為替予約番号をセットし、フォーカスが消失しないよう修正
// 管理番号 K22217 2008/10/09 WF伝票入力承認者変更
// 管理番号 B22255 2009/04/03 ロット詳細参照時に参照元の伝票が削除されている場合、明細が表示されない不具合を修正 
// 管理番号 B21145 2009/04/07 赤黒修正時の赤日付チェック対応
// 管理番号 B22309 2009/08/10 担当者・部門変更時、優先倉庫の住所等を再取得する
// 管理番号 B22291 2009/08/24 イベントが多重起動してしまう不具合を修正
// 1.6.0 2009/09/30
// 管理番号 B22526 2010/07/21 全部返品を行った参照不可な伝票を参照できる不具合を修正
// 管理番号 K24285 2012/01/16 売上・仕入マイナス数量入力対応
// 管理番号 K24284 2012/01/23 プロジェクト必須対応
// 管理番号 B24188 2012/04/24 計上日の月度で債権債務締処理がされている支払保留が解除できない
// 2.0.0 2012/10/31
// 管理番号 B24292 2012/11/19 明細入力後のF6更新対応
// 管理番号 B24264 2012/12/03 雑取引先の情報を都度入力できるように修正
// 管理番号 K24546 2013/02/26 多言語化対応
// 2.1.0 2013/03/31
// 管理番号 K24789 2013/05/13 消費税率の段階的引き上げ対応
// 管理番号 B24839 2013/08/19 数量入力時の不要な0置換処理を削除
// 管理番号 B24749 2013/08/19 ヘッダ項目の変更時、明細破棄が実施されない不具合の対応
// 管理番号 K25202 2013/09/11 IE10対応
// 2.2.0 2014/10/31
// 管理番号 K25679 2015/09/17 グループ対応
// 管理番号 K25667 2016/03/25 WFファイル添付
// 2.3.0 2016/06/30
// 管理番号B25752 2017/01/19 仕入にてロット詳細更新後、行更新でAPエラーが発生する不具合を修正
// 管理番号K26528 2017/02/13 UI見直し
// 管理番号K26508 2017/09/06 アクセス権限の改善
// 3.0.0 2018/04/30
// 管理番号K27059 2019/10/01 マスタの絞り込み機能追加
// 管理番号K27062 2019/10/04 受渡場所マスタの設定方法改善
// 管理番号K27058 2019/10/16 汎用区分追加
// 管理番号K27057 2019/12/05 汎用項目追加
// 3.1.0 2020/06/30
// 管理番号B27043 2020/07/01 仕入形態が預りの場合に、発注しない商品が登録できてしまう
// 管理番号K27441 2022/02/14 組織変更機能改善
// 管理番号B27435 2022/09/06 仕入返品の新規行と挿入行より表示するロット詳細入力画面の表示方法が異なる
// 3.2.0 2023/03/31

var g_beforeValue; //入力前値(Focus時に設定する)

//-------------------------------------------------------------------
//ファンクションキーボタンイベント 
//-------------------------------------------------------------------
// F2 キャンセル
function clickCancelButton(sender) {
	document.getElementById("CancelButton").click();
}
// F3 削除
function clickDeleteButton(sender) {
	document.getElementById("DeleteButton").click();
}
// F3 行削除
// 管理番号 B12975 From

// 管理番号 B12975 コメント削除

function clickItemDeleteButton(sender) {
// 管理番号K26528 From
//	document.getElementById(sender.appendedidpart + "ItemDeleteButton").click();
	document.getElementById(sender.getAttribute("appendedidpart") + "ItemDeleteButton").click();
// 管理番号K26528 To
}
function clickEditDeleteButton(sender) {
// 管理番号K26528 From
//	document.getElementById(sender.appendedidpart + "EditDeleteButton").click();
	document.getElementById(sender.getAttribute("appendedidpart") + "EditDeleteButton").click();
// 管理番号K26528 To
}
// 管理番号 B12975 To
// F4 行登録
function clickRegistButton(sender) {
	document.getElementById("RegistButton").click();
}
// F4 行更新
function clickItemUpdateButton(sender) {
// 管理番号K26528 From
//	document.getElementById(sender.appendedidpart + "EditUpdateButton").click();
	document.getElementById(sender.getAttribute("appendedidpart") + "EditUpdateButton").click();
// 管理番号K26528 To
}
// F4 新規 
function openNewWindow(sender) {
	if (checkDirty()) {
		document.getElementById("__ParamType").value  = "New";
		locationWindow();
	}
	return false;
}
// F4 修正
function openModWindow(sender) {
	if (checkDirty()) {
		var includeLowerDept = "";
		if (document.getElementById("__DisclosureUnitType").value == "D") // 自部門のみの場合 
		{
			includeLowerDept = document.getElementById("__LoginDeptCode").value;
		}
		var compDate = document.getElementById("PuDateText").value != "" ? document.getElementById("PuDateText").value : document.getElementById("__TodayDate").value;
// 管理番号K26528 From
//// 管理番号B13502 From
////		callPuSearchWindow(document.getElementById("PuNoText"), document.getElementById("DeptCodeText").value, "2", "0", "", "0", "", includeLowerDept, compDate);
////		document.all["__ParamType"].value = "Mod";
////		document.all["__SlipNo"].value = document.getElementById("PuNoText").value;
////		locationWindow();
//		if (callPuSearchWindow(document.getElementById("PuNoText"), document.getElementById("DeptCodeText").value, "2", "0", "", "0", "", includeLowerDept, compDate)) {
//			document.all["__ParamType"].value = "Mod";
//			document.all["__SlipNo"].value = document.getElementById("PuNoText").value;
//			locationWindow();
//		}
//// 管理番号B13502 To
		callPuSearchWindow(document.getElementById("PuNoText"), document.getElementById("DeptCodeText").value, "2", "0", "", "0", "", includeLowerDept, compDate);
		lazyTask.add(
			function (lazyArg) {
				if (lazyArg) {
					document.getElementById("__ParamType").value = "Mod";
					document.getElementById("__SlipNo").value = document.getElementById("PuNoText").value;
					locationWindow();
				}
			}
		);
// 管理番号K26528 To
	}
// 管理番号K26528 From
//	return false;
// 管理番号K26528 To
}

//管理番号 B13502 From
// F5 参照（レート）


function openRateWindow(sender) {
	// コントロール取得



	var proj			= document.getElementById("ProjCodeText");
	// コントロールの値取得



	var exchangeType	= document.getElementById("ExchangeTypeList").value;
	var exchangeRezNo	= document.getElementById("ExchangeRezNoText").value;
	var curCode			= document.getElementById("CurCodeList").value;
	var poDate			= document.getElementById("PuDateText").value;
	var deptCode		= document.getElementById("DeptCodeText").value;
	var projCode		= null;
	
	if (proj != null) {
		projCode = proj.value;
	}
	
	if (exchangeType == "0") {
		exchangeType = "3";
	}
	if (sender.id == "RateText")
	{
// 管理番号K26528 From
//		var result = callRateWindowForRateText("RateText", curCode, "S", exchangeRezNo, exchangeType, poDate, deptCode, projCode, "0", "B")
//		document.getElementById("RateText").focus();
//		if (result != false) {
//			document.getElementById("RateText").onchange();
//		}
		callRateWindowForRateText("RateText", curCode, "S", exchangeRezNo, exchangeType, poDate, deptCode, projCode, "0", "B");
		lazyTask.add(
			function () {
				document.getElementById("RateText").focus();
			}
		);
// 管理番号K26528 To
	}
	else
	{
		document.getElementById("RateText").disabled =false;
// 管理番号K26528 From
//		var result = callRateWindowForExchangeRezNoText("RateText", "ExchangeTypeList", "ExchangeRezNoText", curCode, "S", exchangeRezNo, exchangeType, poDate, deptCode, projCode, "0", "B")
//		if (result != false) {
//			__doPostBack(sender.name,'');
//		}
//		document.getElementById("RateText").disabled =true;
		callRateWindowForExchangeRezNoText("RateText", "ExchangeTypeList", "ExchangeRezNoText", curCode, "S", exchangeRezNo, exchangeType, poDate, deptCode, projCode, "0", "B");
		lazyTask.add(
			function (result) {
				if (result != false) {
					__doPostBack(sender.name,'');
				}
				document.getElementById("RateText").disabled =true;
			}
		);
// 管理番号K26528 To
	}
}
// ===========================================
// レート検索ウインドウ
// 戻り：	レート			= result[0]
// 引数 :	通貨コード(*)	= CurCode
//			為替区分		= ExchangeType（"1"：予約あり、"2"：予約なし[先方]、"3"：予約なし[自社]）

//			売買区分(*)		= ExchangeRezType（"S"：売予約、"P"：買予約）

//			為替予約番号	= ExchangeRezNo
//			伝票日付		= DateTimeTo 
//			伝票部門コード	= DeptCode（部門固定予約の検索用）

//			伝票プロジェクト= ProjCode（プロジェクト固定予約の検索用）

//			全てから		= allFlg（"1"：部門固定、プロジェクト固定関係なく全てから）

//			売買区分		= BookSttl（"S"：決済、"B"：計上）

// -------------------------------------------
function callRateWindowForRateText(controlID1, CurCode, ExchangeRezType, ExchangeRezNo, ExchangeType,  DateTimeTo,  DeptCode, ProjCode, allFlg, BookSttl) {
	var beforeRate = document.getElementById(controlID1).value;
// 管理番号K26528 From
//// 管理番号 K24546 From
////	var result = CM_openModalDialog("CM_MS_02_S07", "CurCode="+ CurCode +"&DateTimeTo=" + DateTimeTo + "&ExchangeRezNo=" + ExchangeRezNo + "&ExchangeType=" + ExchangeType + "&ExchangeRezType=" + ExchangeRezType + "&DeptCode=" + DeptCode + "&ProjCode=" + ProjCode + "&flg=" + allFlg + "&BookSttl=" + BookSttl, 452, 685);
//	var result = CM_openModalDialog("CM_MS_02_S07", "CurCode="+ CurCode +"&DateTimeTo=" + DateTimeTo + "&ExchangeRezNo=" + ExchangeRezNo + "&ExchangeType=" + ExchangeType + "&ExchangeRezType=" + ExchangeRezType + "&DeptCode=" + DeptCode + "&ProjCode=" + ProjCode + "&flg=" + allFlg + "&BookSttl=" + BookSttl, 672, 685);
//// 管理番号 K24546 To
//	document.all(controlID1).focus();
//
//	if(result == null) {
//		return false;
//	} else if(beforeRate == result[0]) {
//		return false
//	} else {
//		document.all(controlID1).value = result[0]; 
//// 管理番号 B15412 From
//		document.all["__ReturnValue"].value = "RateText";
//// 管理番号 B15412 To
//		return true;
//	}
//	return false;
	CM_popupPage("CM_MS_02_S07", "CurCode="+ CurCode +"&DateTimeTo=" + DateTimeTo + "&ExchangeRezNo=" + ExchangeRezNo + "&ExchangeType=" + ExchangeType + "&ExchangeRezType=" + ExchangeRezType + "&DeptCode=" + DeptCode + "&ProjCode=" + ProjCode + "&flg=" + allFlg + "&BookSttl=" + BookSttl, 672, 685);
	lazyTask.add(
		function (result) {
			document.getElementById(controlID1).focus();
			if(result == null) {
				return false;
			} else if(beforeRate == result[0]) {
				return false;
			} else {
				document.getElementById(controlID1).value = result[0]; 
				document.getElementById("__ReturnValue").value = "RateText";
				return true;
			}
		}
	);
// 管理番号K26528 To
}
function callRateWindowForExchangeRezNoText(controlID1, controlID2, controlID3, CurCode, ExchangeRezType, ExchangeRezNo, ExchangeType,  DateTimeTo,  DeptCode, ProjCode, allFlg, BookSttl) {
	var beforeExchangeRezNo = document.getElementById(controlID3).value;
// 管理番号K26528 From
//// 管理番号 K24546 From
////	var result = CM_openModalDialog("CM_MS_02_S07", "CurCode="+ CurCode +"&DateTimeTo=" + DateTimeTo + "&ExchangeRezNo=" + ExchangeRezNo + "&ExchangeType=" + ExchangeType + "&ExchangeRezType=" + ExchangeRezType + "&DeptCode=" + DeptCode + "&ProjCode=" + ProjCode + "&flg=" + allFlg + "&BookSttl=" + BookSttl, 452, 685);
//	var result = CM_openModalDialog("CM_MS_02_S07", "CurCode="+ CurCode +"&DateTimeTo=" + DateTimeTo + "&ExchangeRezNo=" + ExchangeRezNo + "&ExchangeType=" + ExchangeType + "&ExchangeRezType=" + ExchangeRezType + "&DeptCode=" + DeptCode + "&ProjCode=" + ProjCode + "&flg=" + allFlg + "&BookSttl=" + BookSttl, 672, 685);
//// 管理番号 K24546 To
//	document.all(controlID3).focus();
//
//	if(result == null) {
//		return false;
//// 管理番号 B21594 From 		
////	} else if(beforeExchangeRezNo == result[2]) {
//	} else if(beforeExchangeRezNo == result[2] && beforeExchangeRezNo != "") {
//// 管理番号 B21594 To
//		return false
//	} else {
//		document.all(controlID1).value = result[0]; 
//		document.all(controlID2).value = result[1];
//		document.all(controlID3).value = result[2];
//// 管理番号 B15412 From
//		document.all["__ReturnValue"].value = "ExchangeRezNoText";
//// 管理番号 B15412 To
//		return true;
//	}
//	return false;
	CM_popupPage("CM_MS_02_S07", "CurCode="+ CurCode +"&DateTimeTo=" + DateTimeTo + "&ExchangeRezNo=" + ExchangeRezNo + "&ExchangeType=" + ExchangeType + "&ExchangeRezType=" + ExchangeRezType + "&DeptCode=" + DeptCode + "&ProjCode=" + ProjCode + "&flg=" + allFlg + "&BookSttl=" + BookSttl, 672, 685);
	lazyTask.add(
		function (result) {
			document.getElementById(controlID3).focus();
			if(result == null) {
				return false;
			} else if(beforeExchangeRezNo == result[2] && beforeExchangeRezNo != "") {
				return false;
			} else {
				document.getElementById(controlID1).value = result[0];
				document.getElementById(controlID2).value = result[1];
				document.getElementById(controlID3).value = result[2];
				document.getElementById("__ReturnValue").value = "ExchangeRezNoText";
				return true;
			}
		}
	);
// 管理番号K26528 To
}
//管理番号 B13502 From

// 管理番号K27062 From
// F5 参照（受渡場所）
function callDeliPlaceCodeWindow(sender) {
	var custCode = CM_getTextValue(document.getElementById("DeliCustCodeText"));	// 得意先コード
	var custName = CM_getTextValue(document.getElementById("DeliCustNameLabel"));	// 得意先名
	callDeliPlaceSearchWindow(sender, document.getElementById("DeliPlaceNameText"), custCode, custName, "");
}
// 管理番号K27062 To
// F6 更新
function clickUpdateButton(sender) {
	document.getElementById("UpdateButton").click();
}
// F9タブ切換 
function changeTabSelecter(sender) {
	var selectedTabIndex = document.getElementById("__TabSelector1_State").value;
	switch (selectedTabIndex) {
		case '0':
			// 詳細タブ選択 
			document.getElementById("TabItem2").click();
			// フォーカスコントロール
			//返品時の明細行処理変更対応-INSERT-START
			if (document.getElementById("InpProdCodeText") != null && !document.getElementById("InpProdCodeText").disabled) {
			//返品時の明細行処理変更対応-INSERT-END
				document.getElementById("InpProdCodeText").focus();
			}
			else if (!document.getElementById("UpdateButton").disabled) {
				document.getElementById("UpdateButton").focus();
			} else {
				document.getElementById("CloseButton").focus();
			}
			break;
		case '1':
			// 基本タブ選択 
			document.getElementById("TabItem1").click();
			// フォーカスコントロール
			if (!document.getElementById("PuNameText").disabled) {
				document.getElementById("PuNameText").focus();
			} else {
				document.getElementById("CloseButton").focus();
			}
	}
}
// F10 仕入一覧表印刷
function clickPuSlipButton(sender) {
	document.getElementById("PuSlipButton").click();
}
// F12 閉じる 
function closeWindow(sender) {
	document.getElementById("CloseButton").click();
}

// 管理番号 B24264 From
// 雑仕入先情報入力画面オープン
function openSuplWindow(sender) {
	if (document.getElementById("__TempCodeFlg").value == "1") {
		if (document.getElementById("CurCodeList") != null) {
			var CurCode = document.getElementById("CurCodeList").value;
		} else {
			var CurCode = document.getElementById("__CurCode").value;
		}
// 管理番号K26528 From
//		var codeText = document.all["SuplCodeText"];
//		var nameLabel = document.all["SuplNameText"];
		var codeText = document.getElementById("SuplCodeText");
		var nameLabel = document.getElementById("SuplNameText");
// 管理番号K26528 To
		if (codeText.value.length == 0) {
		    return false;
		}

		var viewFlg = "1";
		if (!codeText.disabled) {
			viewFlg = "0";
		}
// 管理番号K26528 From
//// 管理番号 K24546 From
////		var result = CM_openModalDialog("SC_MS_02_S20", "ViewFlg=" + escape(viewFlg) + "&CurCode=" + escape(CurCode), 1024, 620);
//		var result = CM_openModalDialog("SC_MS_02_S20", "ViewFlg=" + escape(viewFlg) + "&CurCode=" + escape(CurCode), 1280, 620);
//// 管理番号 K24546 To
//		if (result != null) {
//			nameLabel.value = result[0];
//			if (result[1] == "true") {
//				makeWithChange(sender);
//			}
//		}
//		document.all["__ReturnValue"].value = "openSuplWindow"
		CM_popupPage("SC_MS_02_S20", "ViewFlg=" + escape(viewFlg) + "&CurCode=" + escape(CurCode), 1280, 620);
		lazyTask.add(
			function (result) {
				if (result != null) {
					nameLabel.value = result[0];
					if (result[1] == "true") {
						makeWithChange(sender);
					}
				}
				document.getElementById("__ReturnValue").value = "openSuplWindow";
			}
		);
// 管理番号K26528 To
	}
}
// 管理番号 B24264 To

//-------------------------------------------------------------------
//ファンクションキー設定関連
//-------------------------------------------------------------------
//ファンクションキー設定 
function defaultFunctionKey(type, sender) {

	if (sender!=null) {
		g_beforeValue = sender.value;
	} else {
		g_beforeValue = "";
	}

	functionKeyDownFunctions[0] = showHelp;
	if (!document.getElementById("CancelButton").disabled) {
		functionKeyDownFunctions[1] = clickCancelButton;
	}
// 管理番号 B12975 From
//	if (type != "Body") {
//		if (!document.getElementById("DeleteButton").disabled) {
//			changeF03Text("削除");
//			functionKeyDownFunctions[2] = clickDeleteButton;
//		}
//	} else (type == "Body") {
//		if (document.all["__ParamType"].value != "View") {
//			changeF03Text("行削除");
//			functionKeyDownFunctions[2] = clickItemDeleteButton;
//		}
//	}
//	if (type == "Header") {
//		if (document.all["__ParamType"].value == "Mod"|| document.all["__ParamType"].value == "View") {
//			changeF04Text("新規");
//			if (sender.type != "select-one") {
//				functionKeyDownFunctions[3] = openNewWindow;
//			}
//		} else if (document.all["__ParamType"].value == "New" || document.all["__ParamType"].value == "Copy" || document.all["__ParamType"].value == "CopyPO") {
//			changeF04Text("修正");
//			if (sender.type != "select-one") {
//				functionKeyDownFunctions[3] = openModWindow;
//			}
//		}
//	} else if (type == "Body") {
//		changeF04Text("行更新");
//		if (document.getElementById(sender.appendedidpart + "EditUpdateButton") != null) {
//			if (sender.type != "select-one") {
//				functionKeyDownFunctions[3] = clickItemUpdateButton;
//			}
//		}
//	} else if (type == "Regist") {
//		if (!document.getElementById("RegistButton").disabled) {
//			changeF04Text("行登録");
//			if (sender.type != "select-one") {
//				functionKeyDownFunctions[3] = clickRegistButton;
//			}
//		}
//	}
	var paramType = document.getElementById("__ParamType").value;
	if (type == "Header") {
// 管理番号 B13382 From
// 		changeF03Text("削除"); //K24546
		changeF03Text(Resources.ZZ_FC000073);
// 管理番号 B13382 To
		if (!document.getElementById("DeleteButton").disabled) {
// 管理番号 B13382 From
//			changeF03Text("削除");
// 管理番号 B13382 To
			functionKeyDownFunctions[2] = clickDeleteButton;
		}
		if (paramType == "Mod" || paramType == "View") {
// 			changeF04Text("新規"); //K24546
			changeF04Text(Resources.ZZ_FC000115);
// 管理番号 B13382 From
			if (sender.type != "select-one") {
				functionKeyDownFunctions[3] = openNewWindow;
			}
// 管理番号 B13382 To
		} else if (paramType == "New" || paramType == "Copy" || paramType == "CopyPO") {
// 			changeF04Text("修正"); //K24546
			changeF04Text(Resources.ZZ_FC000097);
			if (sender.type != "select-one") {
				functionKeyDownFunctions[3] = openModWindow;
			}
		}
	}
	else if (type == "Item") {
// 管理番号 B13382 From
// 		changeF03Text("行削除"); //K24546
		changeF03Text(Resources.ZZ_FC000064);
		functionKeyDownFunctions[3] = null;
// 管理番号 B13382 To
// 管理番号K26508 From
//		if (paramType != "View") {
		if (document.getElementById(sender.getAttribute("appendedidpart") + "ItemDeleteButton") != null
			&& !document.getElementById(sender.getAttribute("appendedidpart") + "ItemDeleteButton").disabled) {
// 管理番号K26508 To
// 管理番号 B13382 From
//			changeF03Text("行削除");
// 管理番号 B13382 To
			functionKeyDownFunctions[2] = clickItemDeleteButton;
		}
// 		changeF04Text("行更新"); //K24546
		changeF04Text(Resources.ZZ_FC000063);
	}
	else if (type == "Body") {
// 管理番号 B13382 From
// 		changeF03Text("行削除"); //K24546
		changeF03Text(Resources.ZZ_FC000064);
// 管理番号 B13382 To
		if (paramType != "View") {
// 管理番号 B13382 From
//			changeF03Text("行削除");
// 管理番号 B13382 To
			functionKeyDownFunctions[2] = clickEditDeleteButton;
		}
// 		changeF04Text("行更新"); //K24546
		changeF04Text(Resources.ZZ_FC000063);
// 管理番号K26528 From
//		if (document.getElementById(sender.appendedidpart + "EditUpdateButton") != null) {
		if (document.getElementById(sender.getAttribute("appendedidpart") + "EditUpdateButton") != null) {
// 管理番号K26528 To
			if (sender.type != "select-one") {
// 管理番号 B18952 From
//				functionKeyDownFunctions[3] = clickItemUpdateButton;
// 管理番号K26528 From
//				if(!document.getElementById(sender.appendedidpart + "EditUpdateButton").disabled) {
				if(!document.getElementById(sender.getAttribute("appendedidpart") + "EditUpdateButton").disabled) {
// 管理番号K26528 To
					functionKeyDownFunctions[3] = clickItemUpdateButton;
				}
// 管理番号 B18952 To
			}
		}
	}
	else if (type == "Regist") {
// 管理番号 B13382 From
// 		changeF03Text("削除"); //K24546
		changeF03Text(Resources.ZZ_FC000073);
// 		changeF04Text("行登録"); //K24546
		changeF04Text(Resources.ZZ_FC000066);
// 管理番号 B13382 To
		if (!document.getElementById("DeleteButton").disabled) {
// 管理番号 B13382 From
//			changeF03Text("削除");
// 管理番号 B13382 To
			functionKeyDownFunctions[2] = clickDeleteButton;
		}
		if (!document.getElementById("RegistButton").disabled) {
// 管理番号 B13382 From
//			changeF04Text("行登録");
// 管理番号 B13382 To
			if (sender.type != "select-one") {
				functionKeyDownFunctions[3] = clickRegistButton;
			}
		}
	}
// 管理番号 B12975 To
	if (!document.getElementById("UpdateButton").disabled) {
		functionKeyDownFunctions[5] = clickUpdateButton;
	}
	functionKeyDownFunctions[6] = null;
	functionKeyDownFunctions[7] = null;
	functionKeyDownFunctions[8] = changeTabSelecter;
	if (!document.getElementById("PuSlipButton").disabled) {
		functionKeyDownFunctions[9] = clickPuSlipButton;
	}
	functionKeyDownFunctions[10] = printWindow;
	functionKeyDownFunctions[11] = closeWindow;
	changeHeaderState();
}
// ファンクションキー設定(標準コントロール)
function defaultFunctionKeyHeader(sender) {
	defaultFunctionKey("Header", sender);
}
// 管理番号 B12975 From
// ファンクションキー設定(表示行)
function defaultFunctionKeyItem(sender) {
	defaultFunctionKey("Item", sender);
}
// 管理番号 B12975 To
// ファンクションキー設定(編集行)
function defaultFunctionKeyBody(sender) {
	defaultFunctionKey("Body", sender);
}
// ファンクションキー設定(新規行)
function defaultFunctionKeyRegist(sender) {
	defaultFunctionKey("Regist", sender);
}

//-------------------------------------------------------------------
//検索ウィンドウ呼び出し 
//-------------------------------------------------------------------
// 管理番号K26528 From
// 不要なロジックのため削除
//// F5 参照(仕入番号)
//function openPuNoWindow(sender) {
//	if (checkDirty()) {
//		var includeLowerDept = "";
//		if (document.all["__DisclosureUnitType"].value == "D") // 自部門のみの場合 
//		{
//			includeLowerDept = document.all["__LoginDeptCode"].value;
//		}
//		var compDate = document.all["PuDateText"].value != "" ? document.all["PuDateText"].value : document.all["__TodayDate"].value;
//		if (callPuSearchWindow(document.getElementById("PuNoText"), document.getElementById("DeptCodeText").value, "2", "0", "0", "2", "", includeLowerDept, compDate)) {
//			puNoTextChanged(sender);
//			locationWindow();
//		}
//	}
//}
// 管理番号K26528 To
// F5 参照(発注参照)
function openPoNoWindow(sender) {
	if (checkDirty()) {
		var includeLowerDept = "";
		if (document.getElementById("__DisclosureUnitType").value == "D") // 自部門のみの場合 
		{
			includeLowerDept = document.getElementById("__LoginDeptCode").value;
		}
		var compDate = document.getElementById("PuDateText").value != "" ? document.getElementById("PuDateText").value : document.getElementById("__TodayDate").value;
// 管理番号K26528 From
//		var result = callPoSearchWindow(sender, "SM3", document.getElementById("DeptCodeText").value, "0", "", "", includeLowerDept, compDate);
//		if (result) {
//			codeChange(sender, 1);
//		}
		callPoSearchWindow(sender, "SM3", document.getElementById("DeptCodeText").value, "0", "", "", includeLowerDept, compDate);
		lazyTask.add(
			function (result) {
				if (result) {
					codeChange(sender, 1);
				}
			}
		);
// 管理番号K26528 To
	}
}
// F5 参照(入荷参照)
function openRcptNoWindow(sender) {
	if (checkDirty()) {
		//返品以外が対象
		var includeLowerDept = "";
		if (document.getElementById("__DisclosureUnitType").value == "D") // 自部門のみの場合 
		{
			includeLowerDept = document.getElementById("__LoginDeptCode").value;
		}
		var compDate = document.getElementById("PuDateText").value != "" ? document.getElementById("PuDateText").value : document.getElementById("__TodayDate").value;
// 管理番号K26528 From
//		var result = callRcptSearchWindow(sender, "SM3", "1", document.getElementById("DeptCodeText").value, "0", "", includeLowerDept, compDate);
//		if (result) {
//			codeChange(sender, 2);
//		}
		callRcptSearchWindow(sender, "SM3", "1", document.getElementById("DeptCodeText").value, "0", "", includeLowerDept, compDate);
		lazyTask.add(
			function (result) {
				if (result) {
					codeChange(sender, 2);
				}
			}
		);
// 管理番号K26528 To
	}
}
// F5 参照(仕入参照)
function openRefPuNoWindow(sender) {
	if (checkDirty()) {
		var includeLowerDept = "";
		if (document.getElementById("__DisclosureUnitType").value == "D") // 自部門のみの場合 
		{
			includeLowerDept = document.getElementById("__LoginDeptCode").value;
		}
		var compDate = document.getElementById("PuDateText").value != "" ? document.getElementById("PuDateText").value : document.getElementById("__TodayDate").value;
// 管理番号K26528 From
//// 管理番号 B22526 From
////// 管理番号 B16475 From
//////	var result = callPuSearchWindow(sender, document.getElementById("DeptCodeText").value, "0", "0", "0", "0", "", includeLowerDept, compDate);
////		var result = callPuSearchWindow(sender, document.getElementById("DeptCodeText").value, "0", "0", "2", "0", "", includeLowerDept, compDate);
////// 管理番号 B16475 To
//		var result = callPuSearchWindow(sender, document.getElementById("DeptCodeText").value, "0", "0", "2", "0", "", includeLowerDept, compDate, "SM3");
//// 管理番号 B22526 To
//		if (result) {
//			codeChange(sender, 3);
//		}
		callPuSearchWindow(sender, document.getElementById("DeptCodeText").value, "0", "0", "2", "0", "", includeLowerDept, compDate, "SM3");
		lazyTask.add(
			function (result) {
				if (result) {
					codeChange(sender, 3);
				}
			}
		);
// 管理番号K26528 To
	}
}
// F5 参照(カレンダー)
function openCalenderWindow(sender) {
	var baseDate = sender.value;
	var deptCode = document.getElementById("DeptCodeText").value;
	var clType = "C";
// 管理番号K26528 From
//// 管理番号 B19472 From
////	callCalendarWindow(sender, baseDate, deptCode, clType);
//
//	var result = callCalendarWindow(sender, baseDate, deptCode, clType);
//	//売上日変更時はPostBack
//	if (sender==document.all["PuDateText"]) {
//		if (result) { 
//			if (baseDate!=sender.value) { 
//				sender.onchange();
//			}
//		}
//	}
//// 管理番号 B19472 To
//// 管理番号 K24789 From
//	//取引日変更時はPostBack
//	if (sender == document.all["DealDateText"]) {
//	    if (result) {
//	        if (baseDate != sender.value) {
//	            sender.onchange();
//	        }
//	    }
//	}
//// 管理番号 K24789 To
	callCalendarWindow(sender, baseDate, deptCode, clType);
// 管理番号K26528 To
}
// F5 参照(仕入先)
function openSuplCodeWindow(sender) {
	var beforeValue = sender.value;
	var compDate = document.getElementById("PuDateText").value != "" ? document.getElementById("PuDateText").value : document.getElementById("__TodayDate").value;
// 管理番号K26528 From
//// 管理番号 K16193 From
////    var result = callSuplDateSearchWindowForText(sender, document.all["SuplNameText"], compDate, "S", "0", "");
//    var result = callSuplDateSearchWindowForText(sender, document.all["SuplNameText"], compDate, "S", "0", "", "", "", "1");
//// 管理番号 K16193 To
//	if (result) {
//		if (sender.value != beforeValue){
//			document.all["__ReturnValue"].value = "Supl";
//			sender.onchange();
//		}
//	}
// 管理番号K27059 From
//	callSuplDateSearchWindowForText(sender, document.getElementById("SuplNameText"), compDate, "S", "0", "", "", "", "1");
	var deptCode = "";
	var empCode = "";

	//自社．仕入先検索初期値使用フラグが1：使用する、かつ、ページ．仕入先検索初期値使用フラグが1：使用する の場合
	if (document.getElementById("__InitSuplSearchWindowUseFlg").value == "1" && document.getElementById("__PageInitSuplSearchWindowUseFlg").value == "1") {
		deptCode = document.getElementById("DeptCodeText").value;
		empCode = document.getElementById("EmpCodeText").value;
	}

	callSuplDateSearchWindowForText(sender, document.getElementById("SuplNameText"), compDate, "S", "0", "", "", "", "1", deptCode, empCode);
// 管理番号K27059 To
	lazyTask.add(
		function (result) {
			if (result) {
				if (sender.value != beforeValue){
					document.getElementById("__ReturnValue").value = "Supl";
				}
			}
		}
	);
// 管理番号K26528 To
}
// F5 参照(担当者)
function openEmpCodeWindow(sender) {
// 管理番号K26528 From
//	if (callEmpSearchWindow(sender, document.all["EmpNameLabel"])) {
//		if (g_beforeValue != sender.value) {
//			document.all["__ReturnValue"].value = "Emp";
//			sender.onchange();
//		}
//	}
	callEmpSearchWindow(sender, document.getElementById("EmpNameLabel"));
	lazyTask.add(
		function (lazyArg) {
			if (lazyArg) {
				if (g_beforeValue != sender.value) {
					document.getElementById("__ReturnValue").value = "Emp";
				}
			}
		}
	);
// 管理番号K26528 To
}
// F5 参照(入力者)
function openInputEmpCodeWindow(sender) {
	// 管理番号K26528 From
	//	if (callEmpSearchWindow(sender, document.all["EmpNameLabel"])) {
	//		if (g_beforeValue != sender.value) {
	//			document.all["__ReturnValue"].value = "Emp";
	//			sender.onchange();
	//		}
	//	}
	callEmpSearchWindow(sender, document.getElementById("InputEmpNameLable"));
	lazyTask.add(
		function (lazyArg) {
			if (lazyArg) {
				if (g_beforeValue != sender.value) {
					document.getElementById("__ReturnValue").value = "InputEmp";
				}
			}
		}
	);
	// 管理番号K26528 To
}

// F5 参照(部門)
function openDeptCodeWindow(sender) {
	var includeLowerDept = "";
	if (document.getElementById("__DisclosureUnitType").value == "D") // 自部門のみの場合 
	{
		includeLowerDept = document.getElementById("__LoginDeptCode").value;
	}
	var compDate = document.getElementById("PuDateText").value != "" ? document.getElementById("PuDateText").value : document.getElementById("__TodayDate").value;
// 管理番号K26528 From
//// 管理番号 B13083 From
////	if (callDeptDateSearchWindow(sender, document.all["DeptNameLabel"], compDate, "", includeLowerDept , "", "", "")) {
//	if (callDeptDateSearchWindow(sender, document.all["DeptNameLabel"], compDate, "1", includeLowerDept , "", "", "")) {
//// 管理番号 B13083 To
//		if (g_beforeValue != sender.value) {
//			document.all["__ReturnValue"].value = "Dept";
//			sender.onchange();
//		}
//	}
	callDeptDateSearchWindow(sender, document.getElementById("DeptNameLabel"), compDate, "1", includeLowerDept , "", "", "");
	lazyTask.add(
		function (lazyArg) {
			if (lazyArg) {
				if (g_beforeValue != sender.value) {
					document.getElementById("__ReturnValue").value = "Dept";
				}
			}
		}
	);
// 管理番号K26528 To
}
// F5 参照(プロジェクト)
function openProjCodeWindow(sender) {
	var compDate = document.getElementById("PuDateText").value != "" ? document.getElementById("PuDateText").value : document.getElementById("__TodayDate").value;
// 管理番号K26528 From
//// 管理番号 B24749 From
////	callProjDateSearchWindow(sender, document.all["ProjNameLabel"], compDate, document.all["DeptCodeText"].value);
//	var result = callProjDateSearchWindow(sender, document.all["ProjNameLabel"], compDate, document.all["DeptCodeText"].value);
//// 管理番号 B24749 To
//	if (g_beforeValue != sender.value) {
//		makeWithChange(sender);
//	}
//// 管理番号 B24749 From
//	if (result) {
//		sender.onchange();
//	}
//// 管理番号 B24749 To
	callProjDateSearchWindow(sender, document.getElementById("ProjNameLabel"), compDate, document.getElementById("DeptCodeText").value);
	lazyTask.add(
		function () {
			if (g_beforeValue != sender.value) {
				makeWithChange(sender);
			}
		}
	);
// 管理番号K26528 To
}
// F5 参照(倉庫)
function openWarehouseWindow(sender) {
	var directWhUseFlg = "0";
	if (!document.getElementById("DeliTypeWRadio").checked) {
		directWhUseFlg = "1";
	}
// 管理番号K26528 From
//	if (callWhSearchWindow(sender, document.all["WhShortNameLabel"], "0", directWhUseFlg, "1", "1", "1")) {
//		if (g_beforeValue != sender.value) {
//			document.all["__ReturnValue"].value = "WhHeader";
//			sender.onchange();
//		}
//	}
	callWhSearchWindow(sender, document.getElementById("WhShortNameLabel"), "0", directWhUseFlg, "1", "1", "1");
	lazyTask.add(
		function (lazyArg) {
			if (lazyArg) {
				if (g_beforeValue != sender.value) {
					document.getElementById("__ReturnValue").value = "WhHeader";
				}
			}
		}
	);
// 管理番号K26528 To
}
function openEditWarehouseWindow(sender) {
// 管理番号K26528 From
//// 管理番号 B15581 From
////	callWhSearchWindow(sender, document.all(sender.appendedidpart + "EditWhShortNameLabel"), "0", "1", "1", "1", "1");
//	var res = callWhSearchWindow(sender, document.all(sender.appendedidpart + "EditWhShortNameLabel"), "0", "1", "1", "1", "1");
//	
//	if (res) {
//		sender.onchange();
//	}
//// 管理番号 B15581 To
	callWhSearchWindow(sender, document.getElementById(sender.getAttribute("appendedidpart") + "EditWhShortNameLabel"), "0", "1", "1", "1", "1");
// 管理番号K26528 To
}
function openInpWarehouseWindow(sender) {
// 管理番号K26528 From
//// 管理番号 B15581 From
////	callWhSearchWindow(sender, document.all["InpWhShortNameLabel"], "0", "1", "1", "1", "1");
//	var res = callWhSearchWindow(sender, document.all["InpWhShortNameLabel"], "0", "1", "1", "1", "1");
//	
//	if (res) {
//		sender.onchange();
//	}
//// 管理番号 B15581 To
	callWhSearchWindow(sender, document.getElementById("InpWhShortNameLabel"), "0", "1", "1", "1", "1");
// 管理番号K26528 To
}
// F5 参照(納入先)
function openCustCodeWindow(sender) {
	var compDate = document.getElementById("PuDateText").value != "" ? document.getElementById("PuDateText").value : document.getElementById("__TodayDate").value;
// 管理番号K26528 From
//	if (callCustDateSearchWindow(sender, document.all["DeliCustNameLabel"], compDate, "", "")) {
//		if (g_beforeValue != sender.value) {
//			document.all["__ReturnValue"].value = "DeliCust";
//			sender.onchange();
//		}
//	}
// 管理番号K27059 From
//	callCustDateSearchWindow(sender, document.getElementById("DeliCustNameLabel"), compDate, "", "");
	var deptCode = "";
	var empCode = "";

	//自社．得意先検索初期値使用フラグが1：使用する、かつ、ページ．得意先検索初期値使用フラグが1：使用する の場合
	if (document.getElementById("__InitCustSearchWindowUseFlg").value == "1" && document.getElementById("__PageInitCustSearchWindowUseFlg").value == "1") {
		deptCode = document.getElementById("DeptCodeText").value;
		empCode = document.getElementById("EmpCodeText").value;
	}

	callCustDateSearchWindow(sender, document.getElementById("DeliCustNameLabel"), compDate, "", "", "", "", deptCode, empCode);
// 管理番号K27059 To
	lazyTask.add(
		function (lazyArg) {
			if (lazyArg) {
				if (g_beforeValue != sender.value) {
					document.getElementById("__ReturnValue").value = "DeliCust";
				}
			}
		}
	);
// 管理番号K26528 To
}
// 管理番号K26528 From
// 不要なロジックのため削除
//// F5 参照(銀行コード)
//function openBankCodeWindow(sender) {
//	var beforeValue = sender.value;
//	callBankBranchWindow(sender, document.all["BankNameLabel"], document.all["BankBranchCodeText"], document.all["BankBranchNameLabel"]);
//	if (sender.value != beforeValue){
//		document.all["__ReturnValue"].value = "Bank";
//		sender.onchange();
//	}
//}
//// F5 参照(支店コード)
//function openBankBranchCodeWindow(sender) {
//	var beforeValue = sender.value;
//	callBankBranchWindow(document.all["BankCodeText"], document.all["BankNameLabel"], sender, document.all["BankBranchNameLabel"]);
//	if (sender.value != beforeValue){
//		document.all["__ReturnValue"].value = "BankBranch";
//		sender.onchange();
//	}
//}
// 管理番号K26528 To
// F5 参照(摘要)
function openRemarksWindow(sender, nameLabel, RLDivision) {
// 管理番号K26528 From
//	if (document.all["PuModeTypeList"].value != "2") {
//		return callRemarksSearchWindow(sender, document.all["RemarksText"], "SM3", "R");
//	} else {
//		return callReturnReasonSearchWindow(sender, document.all["RemarksText"], "s");
//	}
// 管理番号K27058 From
//	if (document.getElementById("PuModeTypeList").value != "2") {
	var puModeType = document.getElementById("PuModeTypeList").value;
	if (puModeType.substr(0, 1) != "2") {
// 管理番号K27058 To
		callRemarksSearchWindow(sender, document.getElementById("RemarksText"), "SM3", "R");
	} else {
		callReturnReasonSearchWindow(sender, document.getElementById("RemarksText"), "s");
	}
// 管理番号K26528 To
}
function openEditRemarksWindow(sender) {
// 管理番号K26528 From
//	callRemarksSearchWindow(sender, document.all(sender.appendedidpart + "EditRemarksText"), "SM3", "L");
	callRemarksSearchWindow(sender, document.getElementById(sender.getAttribute("appendedidpart") + "EditRemarksText"), "SM3", "L");
// 管理番号K26528 To
}
function openInpRemarksWindow(sender) {
// 管理番号K26528 From
//	callRemarksSearchWindow(sender, document.all["InpRemarksText"], "SM3", "L");
	callRemarksSearchWindow(sender, document.getElementById("InpRemarksText"), "SM3", "L");
// 管理番号K26528 To
}
// F5 参照(商品)
function openEditProdWindow(sender) {
	var compDate = document.getElementById("PuDateText").value != "" ? document.getElementById("PuDateText").value : document.getElementById("__TodayDate").value;
	var suplCode = document.getElementById("SuplCodeText").value;
// 管理番号K27059 From
	var deptCode = "";
	var empCode = "";

	//自社（SC）．商品検索初期値使用フラグが1：使用する、かつ、ページ．商品検索初期値使用フラグが1：使用する の場合
	if (document.getElementById("__InitProdSearchWindowUseFlg").value == "1" && document.getElementById("__PageInitProdSearchWindowUseFlg").value == "1") {
		deptCode = document.getElementById("DeptCodeText").value;
		empCode = document.getElementById("EmpCodeText").value;
	}
// 管理番号K27059 To
// 管理番号K26528 From
//	if (document.all["PuModeTypeList"].value != "4") {
//		if (callProdSearchWindow(sender, document.all(sender.appendedidpart + "EditProdNameText"), "S", "PO", compDate, "0", suplCode)) {
//			if (g_beforeValue != sender.value) {
//				document.all["__ReturnValue"].value = "Prod";
//				sender.onchange();
//			}
//		}
//	} else {
//		if (callProdSearchWindow(sender, document.all(sender.appendedidpart + "EditProdNameText"), "S", "STK", compDate, "0", suplCode)) {
//			if (g_beforeValue != sender.value) {
//				document.all["__ReturnValue"].value = "Prod";
//				sender.onchange();
//			}
//		}
//	}
// 管理番号K27058 From
//	if (document.getElementById("PuModeTypeList").value != "4") {
	var puModeType = document.getElementById("PuModeTypeList").value;
	if (puModeType.substr(0, 1) != "4") {
// 管理番号K27058 To
// 管理番号K27059 From
//		callProdSearchWindow(sender, document.getElementById(sender.getAttribute("appendedidpart") + "EditProdNameText"), "S", "PO", compDate, "0", suplCode);
		callProdSearchWindow(sender, document.getElementById(sender.getAttribute("appendedidpart") + "EditProdNameText"), "S", "PO", compDate, "0", suplCode, "", "1", deptCode, empCode);
// 管理番号K27059 To
		lazyTask.add(
			function (lazyArg) {
				if (lazyArg) {
					if (g_beforeValue != sender.value) {
						document.getElementById("__ReturnValue").value = "Prod";
					}
				}
			}
		);
	} else {
// 管理番号B27043 From
//// 管理番号K27059 From
////	callProdSearchWindow(sender, document.getElementById(sender.getAttribute("appendedidpart") + "EditProdNameText"), "S", "STK", compDate, "0", suplCode);
//		callProdSearchWindow(sender, document.getElementById(sender.getAttribute("appendedidpart") + "EditProdNameText"), "S", "STK", compDate, "0", suplCode, "", "1", deptCode, empCode);
//// 管理番号K27059 To
		callProdSearchWindow(sender, document.getElementById(sender.getAttribute("appendedidpart") + "EditProdNameText"), "S", "COMPO", compDate, "0", suplCode, "", "1", deptCode, empCode);
// 管理番号B27043 To
		lazyTask.add(
			function (lazyArg) {
				if (lazyArg) {
					if (g_beforeValue != sender.value) {
						document.getElementById("__ReturnValue").value = "Prod";
					}
				}
			}
		);
	}
// 管理番号K26528 To
}
function openInpProdWindow(sender) {
	var compDate = document.getElementById("PuDateText").value != "" ? document.getElementById("PuDateText").value : document.getElementById("__TodayDate").value;
	var suplCode = document.getElementById("SuplCodeText").value;
// 管理番号K27059 From
	var deptCode = "";
	var empCode = "";

	//自社（SC）．商品検索初期値使用フラグが1：使用する、かつ、ページ．商品検索初期値使用フラグが1：使用する の場合
	if (document.getElementById("__InitProdSearchWindowUseFlg").value == "1" && document.getElementById("__PageInitProdSearchWindowUseFlg").value == "1") {
		deptCode = document.getElementById("DeptCodeText").value;
		empCode = document.getElementById("EmpCodeText").value;
	}
// 管理番号K27059 To
// 管理番号K26528 From
//	if (document.all["PuModeTypeList"].value != "4") {
//		if (callProdSearchWindow(sender,document.all["InpProdNameText"],"S", "PO", compDate, "0", suplCode)) {
//			if (g_beforeValue != sender.value) {
//				document.all["__ReturnValue"].value = "Prod";
//				sender.onchange();
//			}
//		}
//	} else {
//		if (callProdSearchWindow(sender,document.all["InpProdNameText"],"S", "STK", compDate, "0", suplCode)) {
//			if (g_beforeValue != sender.value) {
//				document.all["__ReturnValue"].value = "Prod";
//				sender.onchange();
//			}
//		}
//	}
// 管理番号K27058 From
//	if (document.getElementById("PuModeTypeList").value != "4") {
	var puModeType = document.getElementById("PuModeTypeList").value;
	if (puModeType.substr(0, 1) != "4") {
// 管理番号K27058 To
// 管理番号K27059 From
//		callProdSearchWindow(sender,document.getElementById("InpProdNameText"),"S", "PO", compDate, "0", suplCode);
		callProdSearchWindow(sender,document.getElementById("InpProdNameText"),"S", "PO", compDate, "0", suplCode, "", "1", deptCode, empCode);
// 管理番号K27059 To
		lazyTask.add(
			function (lazyArg) {
				if (lazyArg) {
					if (g_beforeValue != sender.value) {
						document.getElementById("__ReturnValue").value = "Prod";
					}
				}
			}
		);
	} else {
// 管理番号B27043 From
//// 管理番号K27059 From
////	callProdSearchWindow(sender,document.getElementById("InpProdNameText"),"S", "STK", compDate, "0", suplCode);
//		callProdSearchWindow(sender,document.getElementById("InpProdNameText"),"S", "STK", compDate, "0", suplCode, "", "1", deptCode, empCode);
//// 管理番号K27059 To
		callProdSearchWindow(sender,document.getElementById("InpProdNameText"),"S", "COMPO", compDate, "0", suplCode, "", "1", deptCode, empCode);
// 管理番号B27043 To
		lazyTask.add(
			function (lazyArg) {
				if (lazyArg) {
					if (g_beforeValue != sender.value) {
						document.getElementById("__ReturnValue").value = "Prod";
					}
				}
			}
		);
	}
// 管理番号K26528 To
}

//-------------------------------------------------------------------
// ロケーション関連処理 
//-------------------------------------------------------------------
// 管理番号K26528 From
// 不要なロジックのため削除
//// 発注参照
//function poNoTextChange(sender) {
//	if (checkDirty()) {
//		var result = callSoSearchWindow(sender, "SM3");
//		if (result) {
//			codeChange(sender, 1);
//		}
//	}
//}
//// 入荷参照
//function searchRcptNoWindow(sender) {
//	if (checkDirty()) {
//		//返品以外が対象
//		var result = callRcptSearchWindow(sender, "SM3","1");
//		if (result) {
//			codeChange(sender, 2);
//		}
//	}
//}
//// 仕入返品
//function searchRefSaNoWindow(sender) {
//	if (checkDirty()) {
//		var includeLowerDept = "";
//		if (document.all["__DisclosureUnitType"].value == "D") // 自部門のみの場合
//
//
//
//
//
//
//		{
//			includeLowerDept = document.all["__LoginDeptCode"].value;
//		}
//		var compDate = document.all["PuDateText"].value != "" ? document.all["PuDateText"].value : document.all["__TodayDate"].value;
//		var result = callPuSearchWindow(sender, document.getElementById("DeptCodeText").value, "1", "0", "0", "1", "", includeLowerDept, compDate);
//		if (result) {
//			codeChange(sender, 3);
//		}
//	}
//}
// 管理番号K26528 To
//-------------------------------------------------------------------
//  ロケーション
//-------------------------------------------------------------------
// ロケーション共通 
function locationWindow() {
	var lockedPuNo = escape(document.getElementById("__LockedPuNo").value);
// 管理番号K26528 From
//// 管理番号 B22291 From
////	window.location.href = "SC_MM_05_S02.aspx?ParamType=" + document.all["__ParamType"].value + "&SlipNo=" + document.all["__SlipNo"].value + "&LockedPuNo=" + lockedPuNo;
//	if (__PostBackFlg == 0) {
//		__PostBackFlg = 1;
//		window.location.href = "SC_MM_05_S02.aspx?ParamType=" + document.all["__ParamType"].value + "&SlipNo=" + document.all["__SlipNo"].value + "&LockedPuNo=" + lockedPuNo;
//	}
//// 管理番号 B22291 To
	var strURL = "SC_MM_05_S02.aspx?ParamType=" + document.getElementById("__ParamType").value + "&SlipNo=" + document.getElementById("__SlipNo").value + "&LockedPuNo=" + lockedPuNo;
	CM_changeLocation(strURL);
// 管理番号K26528 To
}
function checkCancel(sender) {
// 管理番号K26528 From
//	if (document.readyState == "complete" || document.readyState == "interactive"){
// 管理番号K26528 To
	var paramType  = document.getElementById("__ParamType").value;
	var refType    = document.getElementById("__RefType").value;
	var puNo       = document.getElementById("__SlipNo").value;
	var refPoNo    = document.getElementById("__RefPoNo").value;
	var refRcptNo  = document.getElementById("__RefRcptNo").value;
	var refPuNo    = document.getElementById("__RefPuNo").value;
	var lockedPuNo = document.getElementById("__LockedPuNo").value;
	var SlipTp     = "";
	var SlipNo     = "";

	if (checkDirty()) {
		switch (paramType) {
			case "New":
				break;
			case "Mod":
			case "View":
				SlipNo =  puNo;
				SlipTp = "SlipNo";
				break;
			case "Copy":
				SlipNo =  puNo;
				SlipTp = "PuNo";
				break;
			case "CopyPO":
				SlipNo =  refPoNo;
				SlipTp = "PoNo";
				break;
			case "CopyRC":
				SlipNo =  refRcptNo;
				SlipTp = "RcptNo";
				break;
			case "RefPU":
				SlipNo =  refPuNo;
				SlipTp = "RefPuNo";
				break;
			default:
				paramType = "New";
				break;
		}
		var strURL =  "sc_mm_05_s02.aspx?ParamType=" + paramType + "&LockedPuNo=" + lockedPuNo;
		if (SlipTp.length > 0 ) {
			strURL += "&" + SlipTp + "=" + SlipNo;
		}
// 管理番号K26528 From
//		if(document.readyState == "interactive"){
		// スタートアップスクリプトで動作したクリックか？
		var cancelByScript = document.getElementById('cancelByScriptHidden').value === '1';
		document.getElementById('cancelByScriptHidden').value = '';
		if (cancelByScript) {
// 管理番号K26528 To
			strURL += "&EmpCode="		+ escape(document.getElementById("EmpCodeText").value);
// 管理番号K26528 From
//			strURL += "&EmpShortName="	+ escape(document.all["EmpNameLabel"].innerText);
			strURL += "&EmpShortName="	+ escape(CM_getTextValue(document.getElementById("EmpNameLabel")));
// 管理番号K26528 To
			strURL += "&DeptCode="		+ escape(document.getElementById("DeptCodeText").value);
// 管理番号K26528 From
//			strURL += "&DeptShortName=" + escape(document.all["DeptNameLabel"].innerText);
			strURL += "&DeptShortName=" + escape(CM_getTextValue(document.getElementById("DeptNameLabel")));
// 管理番号K26528 To
// 管理番号 B22309 From
			strURL += "&WhCode=" + escape(document.getElementById("WhCodeText").value);
// 管理番号K26528 From
//			strURL += "&WhShortName=" + escape(document.all["WhShortNameLabel"].innerText);
			strURL += "&WhShortName=" + escape(CM_getTextValue(document.getElementById("WhShortNameLabel")));
// 管理番号K26528 To
// 管理番号 B22309 To
// 管理番号 B24749 From
			if (document.getElementById("ProjCodeText") != null){
				strURL += "&ProjCode=" + escape(document.getElementById("ProjCodeText").value);
// 管理番号K26528 From
//				strURL += "&ProjName=" + escape(document.all["ProjNameLabel"].innerText);
				strURL += "&ProjName=" + escape(document.getElementById("ProjNameLabel").innerText);
// 管理番号K26528 To
			}
// 管理番号 B24749 To
		}
// 管理番号K26528 From
//		event.cancelBubble = true;
//		event.returnValue = false;
//// 管理番号 B22291 From
////		location.replace(strURL);
//		if (__PostBackFlg == 0) {
//			__PostBackFlg = 1;
//			location.replace(strURL);
//		}
//// 管理番号 B22291 To
		event.preventDefault();
		CM_changeLocation(strURL);
// 管理番号K26528 To
	}
	return false;
// 管理番号K26528 From
//	}
// 管理番号K26528 To
}
//-------------------------------------------------------------------
// ダイアログ等 
//-------------------------------------------------------------------
// コンファーム(行削除)
function checkDeleteRow(sender) {
// 管理番号K26528 From
//	event.cancelBubble = true;
// 管理番号K26528 To
	return true;
}
// コンファーム(削除)
function checkDelete(sender) {
// 管理番号K26528 From
// 不要なロジックのため削除
//// 管理番号 B19805 From
////	if (!postBackCheck()) {
//	if (!postBackCheck(sender)) {
//// 管理番号 B19805 To
//		return false;
//	}
// 管理番号K26528 To
	//削除日確認ウィンドウ
// 管理番号K26528 From
//	if (!openDeleteWindow()){
//		return false;
//	}
// 管理番号K27441 From
	var ret = false;
	// 発注部門コード確認
	ret = checkPoDeptCode();
	if (!ret) return false;
// 管理番号K27441 To
	openDeleteWindow();
	lazyTask.add(
		function (lazyArg) {
			if (!lazyArg) {
				return false;
			}
		}
	);
// 管理番号K26528 To
}

// 管理番号K27441 From
// 発注部門コード確認
function checkPoDeptCode() {
	var deptCode = document.getElementById("DeptCodeText").value;
	var poDeptCode = document.getElementById("__PoDeptCode").value;
	if (document.getElementById("retryHidden").value != "R") {
		if (deptCode != poDeptCode && poDeptCode != "") {
			// 発注残数が発生する場合、旧部門で発注伝票が作成されているため発注伝票の計上部門が変更されます。\nよろしいですか？
			if (confirm(Resources.SC_JS000858) == false) {
				return false;
			}
		}
		return true;
	}
	return true;
}
// 管理番号K27441 To
//削除入力日設定画面オープン
function openDeleteWindow() {
	try{
// 管理番号K26528 From
//		event.cancelBubble = true;
//// 管理番号 K16590 From
////// 管理番号 B12891 From
//////		var puDate = escape(document.all["PuDateText"].value)
//////		var result = callRedSlipPostingDateWindow(puDate, "PU", "D", null, document.all["deleteDate"], "1", "SC", "取消伝票の起票日を指定してください", "仕入伝票", null, null, null); 
////// 管理番号 B15296 From
//////		var result = callRedSlipPostingDateWindow(document.getElementById("OriginPuDate").innerHTML, "PU", "D", null, document.all["deleteDate"], "1", "SC", "取消伝票の起票日を指定してください", "仕入伝票", null, null, null, null, document.all["DeptCodeText"].value); 
////		var result = callRedSlipPostingDateWindow(document.getElementById("OriginPuDate").innerHTML, "PU", "D", null, document.all["deleteDate"], "1", "SM3", "取消伝票の起票日を指定してください", "仕入伝票", null, null, null, null, document.all["DeptCodeText"].value); 
////// 管理番号 B15296 To
////// 管理番号 B12891 To
//// 		var result = callRedSlipPostingDateWindow(document.getElementById("OriginPuDate").innerHTML, "PU", "D", null, document.all["deleteDate"], "1", "SM3", "取消伝票の計上日を指定してください", "仕入伝票", null, null, null, null, document.all["DeptCodeText"].value);  //K24546
//		var result = callRedSlipPostingDateWindow(document.getElementById("OriginPuDate").innerHTML, "PU", "D", null, document.all["deleteDate"], "1", "SM3", Resources.SC_JS000648, Resources.SC_JS000613, null, null, null, null, document.all["DeptCodeText"].value); 
//// 管理番号 K16590 To
//		if(document.all["deleteDate"].value.length > 0 && result){
//			return true;
//		}
//		return false;
		callRedSlipPostingDateWindow(document.getElementById("OriginPuDate").innerHTML, "PU", "D", null, document.getElementById("deleteDate"), "1", "SM3", Resources.SC_JS000648, Resources.SC_JS000613, null, null, null, null, document.getElementById("DeptCodeText").value);
		lazyTask.add(
			function (result) {
				if(document.getElementById("deleteDate").value.length > 0 && result){
					return true;
				}
				return false;
			}
		);
		lazyTask.addErrorHandler(false);
// 管理番号K26528 To
	} catch(e) {
		return false;
	}
}
//印刷確認ダイアログ
// 管理番号 B24292 From

// 管理番号 B24292 コメント削除
// 管理番号 K16590 コメント削除
// 管理番号 B13879 コメント削除
// 管理番号 B21145 コメント削除

function showOrderSlipP(sender) {
	return showOrderSlip("0");
}
function showOrderSlip(X) {
	var callType = X;
	var str = "SlipType=SM3";
		str  += "&OverSeasFlg=0";
		str  += "&CallType=" + callType;
		str  += "&ParamType=" + document.getElementById("__ParamType").value;
		str  += "&OriginBookDate=" + document.getElementById("OriginPuDate").innerHTML;
		str  += "&DeptCode=" + document.getElementById("DeptCodeText").value;
	var modeType = document.getElementById("PuModeTypeList").value;
// 管理番号K27058 From
//		str  += "&ModeType=" + modeType;
		str  += "&ModeType=" + modeType.substr(0, 1);
// 管理番号K27058 To
		str  += "&NewBookDate1=" + document.getElementById("PuDateText").value;
// 管理番号K26528 From
//	var result = CM_openModalDialog("SC_MS_04_S53", str , 400, 250);
//	if (result != null) {
//		document.all["printListHidden"].value=result[1];	//一覧表印刷フラグ
//		document.all["clickHidden"].value=result[4];		//プレビューorダイレクト 
//		document.all["printHidden"].value=result[9];	//伝票印刷フラグ
//		document.all["deleteDate"].value=result[11];	//赤伝票用の仕入日
//		return true;
//	}
//	return false;
	CM_popupPage("SC_MS_04_S53", str , 400, 250);
	lazyTask.add(
		function (result) {
			if (result != null) {
				document.getElementById("printListHidden").value=result[1];	//一覧表印刷フラグ
				document.getElementById("clickHidden").value=result[4];		//プレビューorダイレクト 
				document.getElementById("printHidden").value=result[9];	//伝票印刷フラグ
				document.getElementById("deleteDate").value=result[11];	//赤伝票用の仕入日
				return true;
			}
			return false;
		}
	);
// 管理番号K26528 To
}
// 管理番号 B24292 To
//ロット詳細(表示行)
function __openLotDetailWindowItemRow(appendedidpart,
		mode          ,
		puLineId      ,
		prodCode      ,
		prodSpec1     ,
		prodSpec2     ,
		unitCode      ,
		whCode        ,
		refSlipNo     ,
		refSlipType   ,
		refSlipLineId ,
		qt            ,
// 管理番号 B22255 From
//		inputQt       ){
		inputQt       ,
		slipNo        ,
		historyFlg    ){
// 管理番号 B22255 To
	var paramType = "View";
	if (document.getElementById("__ParamType").value == "Mod") {
		paramType = "ModView";
	} else if (document.getElementById("__ParamType").value == "View") {
		paramType = "View";
	} else {
		paramType = "NewView";
	}
	var compDate    = document.getElementById("PuDateText").value;
	if (compDate.length==0) {
		compDate = document.getElementById("__TodayDate").value;
	}
	var puModeType = document.getElementById("PuModeTypeList").value;
	var stockType = "1";
// 管理番号K27058 From
//	if (puModeType=="4") {
	if (puModeType.substr(0, 1) == "4") {
// 管理番号K27058 To
		stockType="2";
	}
// 管理番号 B15397 From
// 管理番号 B13877 From
//	var projCode = document.getElementById("ProjCodeText").value;
// 管理番号 B13877 To
	var projCode = "";
	if(document.getElementById("ProjCodeText")!=null){
		projCode = document.getElementById("ProjCodeText").value;
	}
// 管理番号 B15397 To
	
	var parameter = "ParamType="      + escape(paramType);
	parameter    += "&Mode="          + escape(mode);
	parameter    += "&RowId="         + escape(puLineId);
	parameter    += "&ProdCode="      + escape(prodCode);
	parameter    += "&ProdSpec1Code=" + escape(prodSpec1);
	parameter    += "&ProdSpec2Code=" + escape(prodSpec2);
	parameter    += "&UnitCode="      + escape(unitCode);
	parameter    += "&DeptCode="      + escape(document.getElementById("DeptCodeText").value);
	parameter    += "&WhCode="        + escape(whCode);
	parameter    += "&FabDate="       + compDate;
	parameter    += "&RefSlipType="   + escape(refSlipType);
	parameter    += "&RefSlipNo="     + escape(refSlipNo);
	parameter    += "&RefSlipRowId="  + escape(refSlipLineId);
	parameter    += "&Qt="            + qt;
	parameter    += "&InputQt="       + "0";
	parameter    += "&StockType="     + escape(stockType);
// 管理番号 B13877 From
	parameter +=    "&ProjCode="         + escape(projCode);
// 管理番号 B13877 To	
// 管理番号 B22255 From
	parameter    += "&SlipNo="        + escape(slipNo);
	parameter    += "&HistoryFlg="    + escape(historyFlg);
// 管理番号 B22255 To
// 管理番号K26528 From
//// 管理番号 K24546 From
////	var result = CM_openModalDialog("SC_MS_02_S07", parameter, 750, 500);
//	var result = CM_openModalDialog("SC_MS_02_S07", parameter, 1006, 500);
//// 管理番号 K24546 To
//	event.cancelBubble = true;
//	return false;
	CM_popupPage("SC_MS_02_S07", parameter, 1006, 500);
	lazyTask.add(false);
// 管理番号K26528 To
}

//ロット詳細(編集行)
function __openLotDetailWindowEditRow(appendedidpart,
		mode          ,
		refSlipNo     ,
		refSlipType   ,
// 管理番号B25752 From
		slipNo        ,
// 管理番号B25752 To
		qt            ){
	var paramType   = document.getElementById("__ParamType").value;
	if (!(paramType=="Mod" || paramType=="View")){
		paramType="New";
	}

	var ProdSpec1 = "999";
	var ProdSpec2 = "999";
// 管理番号K26528 From
//	if (document.all[appendedidpart + "EditProdSpec1List"] != null) {
	if (document.getElementById(appendedidpart + "EditProdSpec1List") != null) {
// 管理番号K26528 To
		ProdSpec1 = document.getElementById(appendedidpart + "EditProdSpec1List").value;
	}
// 管理番号K26528 From
//	if (document.all[appendedidpart + "EditProdSpec2List"] != null) {
	if (document.getElementById(appendedidpart + "EditProdSpec2List") != null) {
// 管理番号K26528 To
		ProdSpec2 = document.getElementById(appendedidpart + "EditProdSpec2List").value;
	}
	var puModeType = document.getElementById("PuModeTypeList").value;
	var stockType = "1";
// 管理番号K27058 From
//	if (puModeType=="4") {
	if (puModeType.substr(0, 1) == "4") {
// 管理番号K27058 To
		stockType="2";
// 管理番号B27435 From
		mode="10"	// 預り時の新規行と同じモードを設定
// 管理番号B27435 To
	}
// 管理番号B27435 From
	// 仕入形態が2:返品で、仕入参照無しの場合
	if (puModeType.substr(0, 1) == "2" && document.getElementById("RefPuText").value == "") {
		mode="11";	// 返品時の新規行と同じモードを設定
	}
// 管理番号B27435 To
	
// 管理番号 B15397 From
// 管理番号 B13877 From
//	var projCode = document.getElementById("ProjCodeText").value;
// 管理番号 B13877 To
	var projCode = "";
	if(document.getElementById("ProjCodeText")!=null){
		projCode = document.getElementById("ProjCodeText").value;
	}
// 管理番号 B15397 To

	var parameter = "ParamType="      + escape(paramType);
	parameter    += "&Mode="          + escape(mode);
	parameter    += "&RowId="         + escape(document.getElementById("editRowPuLineIdHidden").value);
	parameter    += "&ProdCode="      + escape(document.getElementById(appendedidpart + "EditProdCodeText").value);
	parameter    += "&ProdSpec1Code=" + escape(ProdSpec1);
	parameter    += "&ProdSpec2Code=" + escape(ProdSpec2);
	parameter    += "&UnitCode="      + escape(document.getElementById(appendedidpart + "EditUnitList").value);
	parameter    += "&DeptCode="      + escape(document.getElementById("DeptCodeText").value);
	parameter    += "&WhCode="        + escape(document.getElementById(appendedidpart + "EditWhCodeText").value);
	parameter    += "&FabDate="       + document.getElementById("__TodayDate").value;
	parameter    += "&RefSlipType="   + escape(refSlipType);
	parameter    += "&RefSlipNo="     + escape(refSlipNo);
	parameter    += "&RefSlipRowId="  + escape(document.getElementById("editRowRcptLineIdHidden").value);
	parameter    += "&Qt="            + escape(qt);
	parameter    += "&InputQt="       + document.getElementById(appendedidpart + "EditPuQtText").value;
	parameter    += "&StockType="     + escape(stockType);
// 管理番号 B13877 From
	parameter +=    "&ProjCode="         + escape(projCode);
// 管理番号 B13877 To	
// 管理番号B25752 From
	parameter    += "&SlipNo="        + escape(slipNo);
// 管理番号B25752 To

// 管理番号K26528 From
//// 管理番号 K24546 From
////	var result = CM_openModalDialog("SC_MS_02_S07", parameter, 750, 500);
//	var result = CM_openModalDialog("SC_MS_02_S07", parameter, 1006, 500);
//// 管理番号 K24546 To
//
//	if(result!=null){
//		document.all[appendedidpart + "EditPuQtText"].value = result[3];
//		return true;
//	}
//	event.cancelBubble = true;
//	return false;
	CM_popupPage("SC_MS_02_S07", parameter, 1006, 500);
	lazyTask.add(
		function (result) {
			if(result!=null){
				document.getElementById(appendedidpart + "EditPuQtText").value = result[3];
				return true;
			}
			return false;
		}
	);
// 管理番号K26528 To
}

//ロット詳細(新規行)
function __openLotDetailWindowInsRow(sender) {
	var paramType   = "New";
	var mode        = "4";
	var refSlipType = "SM3";
	var refSlipNo   = document.getElementById("PuNoText").value;
	//仕入形態

	var puModeType = document.getElementById("PuModeTypeList").value;
	var stockType = "1";
// 管理番号K27058 From
//	if (puModeType=="4") {
	if (puModeType.substr(0, 1) == "4") {
// 管理番号K27058 To
		mode = "10";
		stockType="2";
// 管理番号K27058 From
//	} else if (puModeType=="2" && document.getElementById("RefPuText").value == "") {
	} else if (puModeType.substr(0, 1) == "2" && document.getElementById("RefPuText").value == "") {
// 管理番号K27058 To
		mode = "11";
		stockType="1";
	}
	var ProdSpec1 = "999";
	var ProdSpec2 = "999";
// 管理番号K26528 From
//	if (document.all["InpProdSpec1List"] != null) {
	if (document.getElementById("InpProdSpec1List") != null) {
// 管理番号K26528 To
		ProdSpec1 = document.getElementById("InpProdSpec1List").value;
	}
// 管理番号K26528 From
//	if (document.all["InpProdSpec2List"] != null) {
	if (document.getElementById("InpProdSpec2List") != null) {
// 管理番号K26528 To
		ProdSpec2 = document.getElementById("InpProdSpec2List").value;
	}
// 管理番号 B15397 From
// 管理番号 B13877 From
//	var projCode = document.getElementById("ProjCodeText").value;
// 管理番号 B13877 To
	var projCode = "";
	if(document.getElementById("ProjCodeText")!=null){
		projCode = document.getElementById("ProjCodeText").value;
	}
// 管理番号 B15397 To

	var parameter = "ParamType="      + escape(paramType);
	parameter    += "&Mode="          + escape(mode);
	parameter    += "&RowId="         + document.getElementById("__LineId").value;
	parameter    += "&ProdCode="      + escape(document.getElementById("InpProdCodeText").value);
	parameter    += "&ProdSpec1Code=" + escape(ProdSpec1);
	parameter    += "&ProdSpec2Code=" + escape(ProdSpec2);
	parameter    += "&UnitCode="      + escape(document.getElementById("InpUnitList").value);
	parameter    += "&DeptCode="      + escape(document.getElementById("DeptCodeText").value);
	parameter    += "&WhCode="        + escape(document.getElementById("InpWhCodeText").value);
	parameter    += "&FabDate="       + document.getElementById("__TodayDate").value;
	parameter    += "&RefSlipType="   + escape(refSlipType);
	parameter    += "&RefSlipNo="     + escape(refSlipNo);
	parameter    += "&RefSlipRowId="  + document.getElementById("__LineId").value;
	parameter    += "&Qt="            + document.getElementById("inputRowInitPuQtTextHidden").value;
	parameter    += "&InputQt="       + document.getElementById("InpPuQtText").value;
	//parameter    += "&StockType="     + escape("1");
	parameter    += "&StockType="     + escape(stockType);
// 管理番号 B13877 From
	parameter +=    "&ProjCode="         + escape(projCode);
// 管理番号 B13877 To	

// 管理番号K26528 From
//// 管理番号 K24546 From
////	var result = CM_openModalDialog("SC_MS_02_S07", parameter, 750, 500);
//	var result = CM_openModalDialog("SC_MS_02_S07", parameter, 1006, 500);
//// 管理番号 K24546 To
//
//	event.cancelBubble = true;
//	if(result!=null){
//		document.all["InpPuQtText"].value = result[3];
//		return true;
//	}
//	return false;
	CM_popupPage("SC_MS_02_S07", parameter, 1006, 500);
	lazyTask.add(
		function (result) {
			if(result!=null){
				document.getElementById("InpPuQtText").value = result[3];
				return true;
			}
			return false;
		}
	);
// 管理番号K26528 To
}
// 管理番号 K24789 From
// 消費税情報入力画面オープン
// 新規行、編集行
function __openCtaxSearchWindowInputRow() {
	if (document.getElementById("SuplCodeText").value.length == 0) {
		//［仕入先］は必須です。
		alert(Resources.SC_JS000146);
		document.getElementById("SuplCodeText").focus();
// 管理番号K26528 From
//		event.cancelBubble = true;
// 管理番号K26528 To
		return false;
	}

	var compDate = document.getElementById("DealDateText").value != "" ? document.getElementById("DealDateText").value : document.getElementById("__TodayDate").value;
	var originCtaxTypeCode = document.getElementById("CtaxTypeCodeHdn").value;
	var originCtaxRateCode = document.getElementById("CtaxRateCodeHdn").value;

// 管理番号K26528 From
//	var result = callCalcCtaxInputWindow(
//											"1"
//											, "1"
//											, compDate
//											, document.getElementById("CtaxCalcTypeHdn").value
//											, document.getElementById("CtaxTypeCodeHdn")
//											, document.getElementById("CtaxRateCodeHdn")
//											, "0"
//										);
//
//	if (result) {
//		if (originCtaxTypeCode != document.getElementById("CtaxTypeCodeHdn").value
//			|| originCtaxRateCode != document.getElementById("CtaxRateCodeHdn").value) {
//			document.getElementById("TaxInfoChgFlgHdn").value = "1";
//		}
//		return true;
//	} else {
//		event.cancelBubble = true;
//	}
//	return false;
	callCalcCtaxInputWindow(
											"1"
											, "1"
											, compDate
											, document.getElementById("CtaxCalcTypeHdn").value
											, document.getElementById("CtaxTypeCodeHdn")
											, document.getElementById("CtaxRateCodeHdn")
											, "0"
										);
	lazyTask.add(
		function (result) {
			if (result) {
				if (originCtaxTypeCode != document.getElementById("CtaxTypeCodeHdn").value
					|| originCtaxRateCode != document.getElementById("CtaxRateCodeHdn").value) {
					document.getElementById("TaxInfoChgFlgHdn").value = "1";
				}
				return true;
			}
			return false;
		}
	);
// 管理番号K26528 To
}
// 表示行
function __openCtaxWindowItemRow(
	modeType
	, refPageType
	, dealDate
	, ctaxCalcType
	, ctaxTypeCode
	, ctaxRateCode
	, ctaxRate
) {
	if (document.getElementById("SuplCodeText").value.length == 0) {
		//［仕入先］は必須です。
		alert(Resources.SC_JS000146);
		document.getElementById("SuplCodeText").focus();
// 管理番号K26528 From
//		event.cancelBubble = true;
// 管理番号K26528 To
		return false;
	}

// 管理番号K26528 From
//	var result = callCalcCtaxInputWindow(
//											modeType
//											, refPageType
//											, dealDate
//											, ctaxCalcType
//											, ctaxTypeCode
//											, ctaxRateCode
//											, ctaxRate
//										);
//	event.cancelBubble = true;
//	return false;
	callCalcCtaxInputWindow(
											modeType
											, refPageType
											, dealDate
											, ctaxCalcType
											, ctaxTypeCode
											, ctaxRateCode
											, ctaxRate
										);
	lazyTask.add(false);
// 管理番号K26528 To
}
// 管理番号 K24789 To
// 管理番号 K22217 From
// 承認情報変更画面へ遷移
function openApprovalChangeWindow(sender) {
    var puNo = document.getElementById("PuNoText").value;
    var appDeptCode = document.getElementById("DeptCodeText").value;
    var appEmpCode = document.getElementById("EmpCodeText").value;
    var puDate = document.getElementById("PuDateText").value;
// 管理番号 K25679 From
    var slipType = document.getElementById("__SlipTypeCode").value;
// 管理番号 K25679 To

//     if (!CM_checkRequired("PuDateText", "仕入日")) { //K24546
    if (!CM_checkRequired("PuDateText", Resources.SC_JS000614)) {
        return false;
    }
//     if (!CM_checkRequired("EmpCodeText", "担当者")) { //K24546
    if (!CM_checkRequired("EmpCodeText", Resources.SC_JS000723)) {
        return false;
    }
//     if (!CM_checkRequired("DeptCodeText", "部門")) { //K24546
    if (!CM_checkRequired("DeptCodeText", Resources.SC_JS000793)) {
        return false;
    }

// 管理番号 K25679 From
//    var queryString = "ApprovalRouteType=" + "SM3" + "&SlipNo=" + puNo + "&AppDeptCode=" + appDeptCode + "&AppEmpCode=" + appEmpCode + "&KeyGrandTtlAmt=0" + "&AppDate=" + puDate;
    var queryString = "ApprovalRouteType=" + slipType + "&SlipNo=" + puNo + "&AppDeptCode=" + appDeptCode + "&AppEmpCode=" + appEmpCode + "&KeyGrandTtlAmt=0" + "&AppDate=" + puDate;
// 管理番号 K25679 To
// 管理番号K26528 From
//// 管理番号 K24546 From
////    CM_openModalDialog('CM_WF_03_S08', queryString, 452, 250);
//      CM_openModalDialog('CM_WF_03_S08', queryString, 550, 250);
//// 管理番号 K24546 To
//    return true;
	CM_popupPage('CM_WF_03_S08', queryString, 550, 250);
	lazyTask.add(true);
// 管理番号K26528 To
}
// 管理番号 K22217 To
// 諸掛閲覧ボタン
function clickChargeBrowseButton(sender) {
// 管理番号K26528 From
//// 管理番号 K24546 From
////	CM_openModalDialog("SC_MS_06_S01", "ChargeType=I&PuNo=" + document.getElementById("PuNoText").value);
//	CM_openModalDialog("SC_MS_06_S01", "ChargeType=I&PuNo=" + document.getElementById("PuNoText").value, 1280);
//// 管理番号 K24546 To
	CM_transitionPage("SC_MS_06_S01", "ChargeType=I&PuNo=" + document.getElementById("PuNoText").value);
// 管理番号K26528 To
}
// 管理番号 B12929 From
// 仕入先単価更新
function checkPuPriceUpdateStatus(sender, priceTextObject, rowType) {
	var ret = "0";
// 管理番号 B16699 From
// 管理番号K27058 From
//	if (document.getElementById("PuModeTypeList").value == "2") {
	var puModeType = document.getElementById("PuModeTypeList").value;
	if (puModeType.substr(0, 1) == "2") {
// 管理番号K27058 To
		document.getElementById("PriceUpdateFlgHdn").value = ret;
		return;
	}
// 管理番号 B16699 To
	// 仕入先別単価更新フラグ
	var suplPriceUpdateFlg = document.getElementById("_SuplPriceUpdateFlg").value;
	// 商品区分


	var prodType;
	// 初期仕入単価
	var initPuPrice = document.getElementById("InitPuPriceHdn").value;
	
	if (rowType == "0") {
		// 新規行


		prodType = document.getElementById("inputRowProdTypeHidden").value;
	} else {
		// 編集行


		prodType = document.getElementById("editRowProdTypeHidden").value;
	}
	if (prodType == "0") {
		// 通常品でない場合は無視


		var editPrice = Number(priceTextObject.value.replace(",", ""));
		var initPrice = Number(escape(initPuPrice));
		
		if (editPrice != initPrice && suplPriceUpdateFlg == "1") {
// 			if (confirm("仕入先の仕入単価を更新しますか？")) { //K24546
			if (confirm(Resources.SC_JS000607)) {
				ret = "1";
			}
		} else {
			ret = document.getElementById("PriceUpdateFlgHdn").value;
		}
	}
	document.getElementById("PriceUpdateFlgHdn").value = ret;
}
// 管理番号 B12929 To
//-------------------------------------------------------------------
// アイテムチェンジ
//-------------------------------------------------------------------
// テキストチェンジ(仕入番号)

function puNoTextChanged(sender) {
	if (checkDirty()) {
		codeChange(sender, 0);
	} else {
		var puNo = escape(document.getElementById("__SlipNo").value);
		document.getElementById("PuNoText").value = puNo;
		document.getElementById("PoRefText").focus();
		return false;
	}
	return true;
}

// テキストチェンジ(発注参照)
function poNoTextChanged(sender) {
	if (checkDirty()) {
		codeChange(sender, 1);
	} else {
		var refPoNo = escape(document.getElementById("__RefPoNo").value);
		document.getElementById("PoRefText").value = refPoNo;
		document.getElementById("PoRefText").focus();
		return false;
	}
	return true;
}
// テキストチェンジ(入荷参照)
function rcptNoTextChanged(sender) {
	if (checkDirty()) {
		codeChange(sender, 2);
	} else {
		var refShipNo = escape(document.getElementById("__RefRcptNo").value);
		document.getElementById("RcptRefText").value = refShipNo;
		document.getElementById("RcptRefText").focus();
		return false;
	}
	return true;
}
// テキストチェンジ(仕入参照)
function refPuNoTextChange(sender) {
	if (checkDirty()) {
		codeChange(sender, 3);
	} else {
		var refPuNo = escape(document.getElementById("__RefPuNo").value);
		document.getElementById("RefPuText").value = refPuNo;
		document.getElementById("RefPuText").focus();
		return false;
	}
	return true;
}
// 管理番号K26528 From
// 不要なロジックのため削除
//// テキストチェンジ(受注日を前日に)
//function bookDatePreviousButtonClick(sender) {
//	setPreviousDate(document.getElementById('PuDateText'),sender);
//	if (document.getElementById('PuDateText').value!="") {
//		document.all["__ReturnValue"].value = sender.name;
//		document.getElementById("PuDateText").onchange();
//	} else {
//		return false;
//	}
//}
//// テキストチェンジ(受注日を翌日に)
//function bookDateNextButtonClick(sender) {
//	setNextDate(document.getElementById('PuDateText'),sender);
//	if (document.getElementById('PuDateText').value!="") {
//		document.all["__ReturnValue"].value = sender.name;
//		document.getElementById("PuDateText").onchange();
//	} else {
//		return false;
//	}
//}
// 管理番号K26528 To
/* セレクトチェンジ ///////////////////////////////////////////////////////////////////////////////////////*/
// 仕入形態 
function puModeTypeChange(sender) {
	//返品時の明細行処理変更対応-INSERT-START
	if (document.getElementById("DataGrid1")) {
// 		if (!window.confirm("［明細行］が変更されています。読み込みなおしますか？")) { //K24546
		if (!window.confirm(Resources.SC_JS000461)) {
			var puModeType = escape(document.getElementById("__PuModeType").value);
			document.getElementById("PuModeTypeList").value = puModeType;
			document.getElementById("PuModeTypeList").focus();
// 管理番号K26528 From
//			event.cancelBubble = true;
// 管理番号K26528 To
			return false;
		}
	}
	//返品時の明細行処理変更対応-INSERT-END
	document.getElementById("__ReturnValue").value = "PuModeType";
// 管理番号K26528 From
//	__doPostBack(sender.name,'');
// 管理番号K26528 To
}
// 管理番号K26528 From
// 不要なロジックのため削除
//// 受渡場所
//function deliPlaceChange(sender) {
//	document.getElementById("__ReturnValue").value = "DeliPlace";
//	__doPostBack(sender.name,'');
//}
//// Edit行規格1
//function spec1CodeChange(sender) {
//	document.getElementById("__ReturnValue").value = "ProdSpec1";
//	__doPostBack(sender.name,'');
//}
//// Edit行規格2
//function spec2CodeChange(sender) {
//	document.getElementById("__ReturnValue").value = "ProdSpec2";
//	__doPostBack(sender.name,'');
//}
//// Edit行単位 
//function unitCodeChange(sender) {
//	document.getElementById("__ReturnValue").value = "ProdUnit";
//	__doPostBack(sender.name,'');
//}
//// 登録行規格1
//function insSpec1CodeChange(sender) {
//	document.getElementById("__ReturnValue").value = "ProdSpec1";
//	__doPostBack(sender.name,'');
//}
//// 登録行規格2
//function insSpec2CodeChange(sender) {
//	document.getElementById("__ReturnValue").value = "ProdSpec2";
//	__doPostBack(sender.name,'');
//}
//// 登録行単位 
//function insUnitCodeChange(sender) {
//	document.getElementById("__ReturnValue").value = "ProdUnit";
//	__doPostBack(sender.name,'');
//}
// 管理番号K26528 To

function codeChange(changedValue, searchType) {
	changedValue = escape(changedValue.value);
	//var strURL = "SC_MM_05_S02.aspx?ParamType=" + document.all["__ParamType"].value + "&RefType=";
	var strURL = "SC_MM_05_S02.aspx?";
	switch (searchType) {
		case 0: //仕入番号変更
			//strURL += "NONE";
			strURL += "ParamType=Mod&RefType=NONE";
			break;
		case 1: //発注番号変更
			//strURL += "PO";
			strURL += "ParamType=New&RefType=PO";
			break;
		case 2: //入荷番号変更
			//strURL += "RCPT";
			strURL += "ParamType=New&RefType=RCPT";
			break;
		case 3: //返品参照番号変更
			//strURL += "REF_PU";
			strURL += "ParamType=New&RefType=REF_PU";
// 管理番号K27058 From
			var puModeType = document.getElementById("PuModeTypeList").value;
			strURL += "&PuModeTypeDtilCodeHidden=" + puModeType.substr(1, puModeType.length - 1);
// 管理番号K27058 To
			break;
	}
	strURL += "&SlipNo=" + changedValue;
// 管理番号 B21658 From	
	strURL += "&LockedPuNo=" + escape(document.getElementById("__LockedPuNo").value);
// 管理番号 B21658 To	
// 管理番号K26528 From
//// 管理番号 B22291 From
////	location.replace(strURL);
//	if (__PostBackFlg == 0) {
//		__PostBackFlg = 1;
//		location.replace(strURL);
//	}
//// 管理番号 B22291 To
	CM_changeLocation(strURL);
// 管理番号K26528 To
}

// セレクトチェンジ(受渡場所)
function deliPlaceChange(sender)
{
// 管理番号K27062 From
	makeWithChange(sender);
// 管理番号K27062 To
	if (g_beforeValue != sender.value) {
		document.getElementById("__ReturnValue").value = "DeliPlace";
		//sender.onchange();
// 管理番号K26528 From
//		__doPostBack(sender.name,'');
// 管理番号K26528 To
	}
}
// セレクトチェンジ(Edit行規格1)
function spec1CodeChange(sender)
{
	if (g_beforeValue != sender.value) {
		document.getElementById("__ReturnValue").value = "Spec1Code";
		//sender.onchange();
// 管理番号K26528 From
//		__doPostBack(sender.name,'');
// 管理番号K26528 To
	}
}
// セレクトチェンジ(Edit行規格2)
function spec2CodeChange(sender)
{
	if (g_beforeValue != sender.value) {
		document.getElementById("__ReturnValue").value = "Spec2Code";
		//sender.onchange();
// 管理番号K26528 From
//		__doPostBack(sender.name,'');
// 管理番号K26528 To
	}
}
// セレクトチェンジ(Edit行単位)
function unitCodeChange(sender)
{
	if (g_beforeValue != sender.value) {
		document.getElementById("__ReturnValue").value = "UnitCode";
		//sender.onchange();
// 管理番号K26528 From
//		__doPostBack(sender.name,'');
// 管理番号K26528 To
	}
}
// セレクトチェンジ(登録行規格1)
function insSpec1CodeChange(sender)
{
	if (g_beforeValue != sender.value) {
		document.getElementById("__ReturnValue").value = "InsSpec1Code";
		//sender.onchange();
// 管理番号K26528 From
//		__doPostBack(sender.name,'');
// 管理番号K26528 To
	}
}
// セレクトチェンジ(登録行規格2)
function insSpec2CodeChange(sender)
{
	if (g_beforeValue != sender.value) {
		document.getElementById("__ReturnValue").value = "InsSpec2Code";
		//sender.onchange();
// 管理番号K26528 From
//		__doPostBack(sender.name,'');
// 管理番号K26528 To
	}
}
// セレクトチェンジ(登録行単位)
function insUnitCodeChange(sender)
{
	if (g_beforeValue != sender.value) {
		document.getElementById("__ReturnValue").value = "UnitCode";
		//sender.onchange();
// 管理番号K26528 From
//		__doPostBack(sender.name,'');
// 管理番号K26528 To
	}
}

// 管理番号 K22217 From
// セレクトチェンジ（承認区分）

function statusChange(sender) {
// 管理番号K26528 From
//    __doPostBack(sender.name, '');
// 管理番号K26528 To
}
// 管理番号 K22217 To

//管理番号 B13502 From
// セレクトチェンジ（通貨）


function curCodeChange(sender) {
	makeWithChange(sender);
	document.getElementById("__ReturnValue").value = "CurCode";
// 管理番号K26528 From
//	__doPostBack(sender.name,'');
// 管理番号K26528 To
}

// 為替区分


function exchangeTypeChange(sender) {
	makeWithChange(sender);
	document.getElementById("__ReturnValue").value = "ExchangeType";
// 管理番号K26528 From
//	__doPostBack(sender.name,'');
// 管理番号K26528 To
}
//管理番号 B13502 To
//-------------------------------------------------------------------
//入力チェック
//-------------------------------------------------------------------
// 入力チェック(一括納期回答)
function checkValueSlipDate(sender) {
	if (document.getElementById("DelivSlipDate").value.length == 0) {
// 		alert("［一括納期］は必須です。"); //K24546
		alert(Resources.SC_JS000050);
		document.getElementById("DelivSlipDate").focus();
		return false;
	}
}
// 入力チェック(更新)
function checkValueUpdate(sender) {
// 管理番号K26528 From
//// 不要なロジックのため削除
//// 管理番号 B19805 From
//	//キー項目チェック
//	ret = postBackCheck(sender);
//	if (!ret) return false;
//// 管理番号 B19805 To
// 管理番号K26528 To
// 	if (!CM_checkRequired("PuDateText", "仕入日")) { //K24546
	if (!CM_checkRequired("PuDateText", Resources.SC_JS000614)) {
		return false;
	}
// 	if (!CM_checkRequired("SuplCodeText", "仕入先コード")) { //K24546
	if (!CM_checkRequired("SuplCodeText", Resources.SC_JS000606)) {
		return false;
	}
// 管理番号 B14788 From
	if (document.getElementById("SuplNameText").disabled)
	{
		if(document.getElementById("SuplNameText").value.length == 0)
		{
// 			window.alert("[仕入先名]は必須です。"); //K24546
			window.alert(Resources.SC_JS000154);
			document.getElementById("SuplCodeText").focus();
			return false;
		}
	}
	else
	{
// 		if (!CM_checkRequired("SuplNameText", "仕入先名")) { //K24546
		if (!CM_checkRequired("SuplNameText", Resources.SC_JS000610)) {
			return false;
		}
	}
//	if (!CM_checkRequired("SuplNameText", "仕入先名")) {
//	return false;
//	}
// 管理番号 B14788 To		
// 管理番号 K16590 From
	if (document.getElementById("DealDateText").disabled==false) {
// 		if (!CM_checkRequired("DealDateText", "取引日")) { //K24546
		if (!CM_checkRequired("DealDateText", Resources.SC_JS000647)) {
			return false;
		}
	}
// 管理番号 K16590 To
// 	if (!CM_checkRequired("EmpCodeText", "担当者")) { //K24546
	if (!CM_checkRequired("EmpCodeText", Resources.SC_JS000723)) {
		return false;
	}
// 	if (!CM_checkRequired("DeptCodeText", "部門")) { //K24546
	if (!CM_checkRequired("DeptCodeText", Resources.SC_JS000793)) {
		return false;
	}
// 管理番号 K24284 From
	if (document.getElementById("__ProjImplementFlg").value == "True" && document.getElementById("__ProjInputScIndisFlg").value == "True") {
// 		if (!CM_checkRequired("ProjCodeText", "プロジェクト")) { //K24546
		if (!CM_checkRequired("ProjCodeText", Resources.SC_JS000526)) {
			return false;
		}
	}
// 管理番号 K24284 To
	if (!document.getElementById("DeliTypeWRadio").checked) {
// 		if (!CM_checkRequired("DeliCustCodeText", "納入先")) { //K24546
		if (!CM_checkRequired("DeliCustCodeText", Resources.SC_JS000754)) {
			return false;
		}
	}
	
// 管理番号K27062 From
	// 受渡場所
	if (!document.getElementById("DeliTypeWRadio").checked) {
		if (!CM_checkRequired("DeliPlaceCodeText", Resources.SC_JS000653)) {
			document.getElementById("TabItem1").click();
			document.getElementById("DeliPlaceCodeText").focus();
			return false;
		}
	}
// 管理番号K27062 To
	
//管理番号 B13502 From
	if (document.getElementById("ExchangeTypeList").disabled==false) 
	{
		if (document.getElementById("ExchangeTypeList").value.length == 0) {
// 			alert("［為替区分］は必須です。"); //K24546
			alert(Resources.SC_JS000042);
			document.getElementById("TabItem1").click();
			document.getElementById("ExchangeTypeList").focus();
			return false;
		}
		//予約あり


		if (document.getElementById("ExchangeTypeList").value == "1") 
		{
			if (document.getElementById("ExchangeRezNoText").value.length == 0) 
			{
// 				alert("［為替予約番号］は必須です。"); //K24546
				alert(Resources.SC_JS000045);
				document.getElementById("TabItem1").click();
				document.getElementById("ExchangeRezNoText").focus();
				return false;
			}
		}
		else
		{
			if (document.getElementById("RateText").value.length == 0) 
			{
// 				alert("［レート］は必須です。"); //K24546
				alert(Resources.SC_JS000033);
				document.getElementById("TabItem1").click();
				document.getElementById("RateText").focus();
				return false;
			}
		}
	}
//管理番号 B13502 To

// 管理番号 B24264 From
//	if (document.all["AcTypeList"] != null) {
//		if (document.all["SuplNameText"].value.length == 0){
//			alert("［仕入先正式名］は必須です。");
//			document.all["TabItem1"].click();
//			document.all["SuplNameText"].focus();
//			return false;
//		}

//// 管理番号 B20392 From
////	if (document.all["AcTypeList"].value == "B") {
//		if (document.all["AcTypeList"].value == "B" || document.all["AcTypeList"].value == "A") {
//// 管理番号 B20392 To
//			if (document.all["BankCodeText"].value.length == 0) {
//				alert("［銀行コード］は必須です。");
//				document.all["TabItem1"].click();
//				document.all["BankCodeText"].focus();
//				return false;
//			}
//			if (document.all["BankBranchCodeText"].value.length == 0) {
//				alert("［支店コード］は必須です。");
//				document.all["TabItem1"].click();
//				document.all["BankBranchCodeText"].focus();
//				return false;
//			}
//		}
//		if (document.all["AcTypeList"].value != "") {
//			if (document.all["AcHolderText"].value.length == 0) {
//				alert("［口座名義人］は必須です。");
//				document.all["TabItem1"].click();
//				document.all["AcHolderText"].focus();
//				return false;
//			}
//// 管理番号 B20392 From
//			else {
//				if (document.all["AcHolderText"].value.length > 48) {
//					alert("［口座名義人］は48文字以内で入力して下さい。");
//					document.getElementById("AcHolderText").focus();
//					return false;
//				}
//			}
//// 管理番号 B20392 To			
//			if (document.all["AcNoText"].value.length == 0) {
//				alert("［口座番号］は必須です。");
//				document.all["TabItem1"].click();
//				document.all["AcNoText"].focus();
//				return false;
//			}
//// 管理番号 B20392 From
//			else {
//				//銀行

//				if (document.all["AcTypeList"].value == "B") {
//					if (document.all["AcNoText"].value.length > 7) {
//						alert("［口座区分］が銀行のとき、［口座番号］は7桁以内で入力して下さい。");
//						document.getElementById("AcNoText").focus();
//						return false;
//					}
//				}
//				//農協

//				if (document.all["AcTypeList"].value == "A") {
//					if (document.all["AcNoText"].value.length > 7) {
//						alert("［口座区分］が農協のとき、［口座番号］は7桁以内で入力して下さい。");
//						document.getElementById("AcNoText").focus();
//						return false;
//					}
//				}
//				//郵便局
//				if (document.all["AcTypeList"].value == "P") {
//					if (document.all["AcNoText"].value.length > 15) {
//						alert("［口座区分］が郵便局のとき、［口座番号］は15桁以内で入力して下さい。");
//						document.getElementById("AcNoText").focus();
//						return false;
//					}
//				}
//			}
//// 管理番号 B20392 To			
//		}
//	}
// 管理番号 B24264 To


	//都度請求時に以下のチェックを行う
	if (document.getElementById("DtTypeList_1").checked) {
		//支払条件1
// 管理番号 B16804 From
//		if (document.all["Dt1SttlMthdCodeList"].value == 0) {
		if (document.getElementById("Dt1SttlMthdCodeList").value.length == 0) {
// 管理番号 B16804 To
// 			alert("［支払方法1］は必須です。"); //K24546
			alert(Resources.SC_JS000203);
			document.getElementById("TabItem1").click();
			document.getElementById("Dt1SttlMthdCodeList").focus();
			return false;
		}

		if (document.getElementById("Dt1BasisAmtText").value.replace(" ","").length != 0) {
			//回収条件比率
			if (document.getElementById("Dt2RatioText").value.length == 0) {
// 				alert("［基準金額］入力時は、［比率］は必須です。"); //K24546
				alert(Resources.SC_JS000096);
				document.getElementById("TabItem1").click();
				document.getElementById("Dt2RatioText").focus();
				return false;
			}
			//比率に対する条件
// 管理番号 B16804 From
//			if (document.all["Dt2SttlMthdCodeList"].value == 0) {
			if (document.getElementById("Dt2SttlMthdCodeList").value.length == 0) {
// 管理番号 B16804 To
// 				alert("［基準金額］入力時は、［支払方法2］は必須です。"); //K24546
				alert(Resources.SC_JS000095);
				document.getElementById("TabItem1").click();
				document.getElementById("Dt2SttlMthdCodeList").focus();
				return false;
			}
		}
		//比率値チェック
		if (document.getElementById("Dt2RatioText").value.replace(" ","") != "") {
			if ((isNaN(document.getElementById("Dt2RatioText").value)) || 
// 管理番号K26528 From
//					(eval(document.all["Dt2RatioText"].value) < 1 || eval(document.all["Dt2RatioText"].value) > 100)) {
					(Number(document.getElementById("Dt2RatioText").value) < 1 || Number(document.getElementById("Dt2RatioText").value) > 100)) {
// 管理番号K26528 To
// 				alert("［比率］は、1～100の範囲で入力してください。"); //K24546
				alert(Resources.SC_JS000432);
				document.getElementById("TabItem1").click();
				document.getElementById("Dt2RatioText").focus();
				return false;
			}
		}
		//支払条件3
		if (document.getElementById("Dt2RatioText").value.length > 0 &&
			document.getElementById("Dt2RatioText").value != "100"     && 
// 管理番号 B16804 From
//			document.all["Dt3SttlMthdCodeList"].value == 0) {
			document.getElementById("Dt3SttlMthdCodeList").value.length == 0) {
// 管理番号 B16804 To
// 				alert("［比率］に100%以外の数値入力時は、［支払方法3］は必須です。"); //K24546
				alert(Resources.SC_JS000430);
				document.getElementById("TabItem1").click();
				document.getElementById("Dt3SttlMthdCodeList").focus();
				return false;
		}
		//サイト




		var type1 = "";
		var type2 = "";
		var type3 = "";
// 管理番号K26528 From
//		if (document.all["SttlType1"])
		if (document.getElementById("SttlType1"))
// 管理番号K26528 To
		{
			type1 = document.getElementById("SttlType1").value;
		}
// 管理番号K26528 From
//		if (document.all["SttlType2"])
		if (document.getElementById("SttlType2"))
// 管理番号K26528 To
		{
			type2 = document.getElementById("SttlType2").value;
		}
// 管理番号K26528 From
//		if (document.all["SttlType3"])
		if (document.getElementById("SttlType3"))
// 管理番号K26528 To
		{
			type3 = document.getElementById("SttlType3").value;
		}
		if (type1 == "N" || type1 == "D" || type2 == "N" || type2 == "D" || type3 == "N" || type3 == "D")
		{
			if (document.getElementById("DtSightText").value.length == 0)
			{
// 				alert("［回収方法］のいずれかが 手形、期日決済 入力時は、［サイト］は必須です。"); //K24546
				alert(Resources.SC_JS000078);
				document.getElementById("TabItem1").click();
				document.getElementById("DtSightText").focus();
				return false;
			}
		}
	}
	//支払期限 
	if (document.getElementById("PymtPlanDateText").value.length	==0) {
// 		alert("［支払期限］は必須です。"); //K24546
		alert(Resources.SC_JS000173);
		document.getElementById("TabItem1").click();
		document.getElementById("PymtPlanDateText").focus();
		return false;
	}
	//支払条件表記 
	if (document.getElementById("DtNoteText").value == 0) {
// 		alert("［支払条件表記］は必須です。"); //K24546
		alert(Resources.SC_JS000192);
		document.getElementById("TabItem1").click();
		document.getElementById("DtNoteText").focus();
		return false;
	}

	//相関チェック等 
	ret = LogicalCheck();
	if (!ret) return false;

	if (!document.getElementById("DataGrid1")) {
// 		alert("［明細行］は必須です。"); //K24546
		alert(Resources.SC_JS000462);
		document.getElementById("TabItem2").click();
		return false;
	}
// 管理番号K27057 From
	if (!CustomItemRequiredCheck("CustomItemPanel","TabItem1")) {
		return false;
	}
// 管理番号K27057 To

// 管理番号K27441 From
	// 受注部門コード確認
	ret = checkPoDeptCode();
	if (!ret) return false;
// 管理番号K27441 To
// 管理番号 B19805 From
	//キー項目チェック
//	ret = postBackCheck();
//	if (!ret) return false;
// 管理番号 B19805 To
// 管理番号 B24292 From
//	return showOrderSlip(sender);
	//確認ダイアログの起動はCS側に移動になったので、そのままTrueを返却
	return true;
// 管理番号 B24292 To
}

//相関チェック等 
function LogicalCheck(){
	var PuDate     = document.getElementById("PuDateText").value;
	var CutOffDate = "";
	var PlanDate   = "";
// 管理番号K26528 From
//	var Date       = document.getElementById("__TodayDate").value;
// 管理番号K26528 To

	if (document.getElementById("CutoffDateText").value.length!=0) {
		CutOffDate = document.getElementById("CutoffDateText").value;
	}
	if (document.getElementById("PymtPlanDateText").value.length!=0) {
		PlanDate = document.getElementById("PymtPlanDateText").value;
	}

	//一括請求時
	if (document.getElementById("DtTypeList_0").checked) {

		//①締日、仕入日
		if (CutOffDate < PuDate) {
// 			alert("［締日］は、［仕入日］より前の日は入力できません。"); //K24546
			alert(Resources.SC_JS000358);
			document.getElementById("TabItem1").click();
// 管理番号K26528 From
//			if (document.all["PuDateText"]!=null){
//				if (document.all["PuDateText"].isDisabled) {
			if (document.getElementById("PuDateText")!=null){
				if (document.getElementById("PuDateText").disabled) {
// 管理番号K26528 To
					document.getElementById("PuDateText").focus();
				}
			}
			return false;
		}

		//②回収期限は締日から算出の為、チェック省略

	//都度請求時
	} else {
		//①都度請求時は、締日に仕入日を自動設定の為、チェックなし 
		//②回収期限、仕入日
		if (PlanDate < PuDate ) {
// 			alert("［支払期限］は、［仕入日］より前の日は入力できません。"); //K24546
			alert(Resources.SC_JS000171);
			document.getElementById("TabItem1").click();
// 管理番号K26528 From
//			if (document.all["PymtPlanDateText"]!=null){
//				if (document.all["PymtPlanDateText"].isDisabled) {
			if (document.getElementById("PymtPlanDateText")!=null){
				if (document.getElementById("PymtPlanDateText").disabled) {
// 管理番号K26528 To
					document.getElementById("PymtPlanDateText").focus();
				}
			}
			return false;
		}
	}
	return true;
}

//回収条件制御(得意先マスタ登録(CM_MS_07_S05)からコピー)
function domesticRequiredCheck(sender) {
	if (document.getElementById("Dt1BasisAmtText").value == "0") {
		document.getElementById("Dt1BasisAmtText").value = "";
	}
	if (document.getElementById("Dt2RatioText").value == "0") {
		document.getElementById("Dt2RatioText").value = "";
	}
	if (document.getElementById("Dt2RatioText").value == "0") {
		document.getElementById("Dt2RatioText").value = "";
	}
	// 基準金額、比率、決済方法２はセットで入力




	if ((document.getElementById("Dt1BasisAmtText").value.length != 0)||(document.getElementById("Dt2RatioText").value.length != 0)||(document.getElementById("Dt2SttlMthdCodeList").value.length != 0)) {
		if (document.getElementById("Dt1BasisAmtText").value.length == 0) {
			document.getElementById("Dt1BasisAmtText").className = "input_bg_2";
		} else {
			document.getElementById("Dt1BasisAmtText").className = "input_bg_1";
		}
		if (document.getElementById("Dt2RatioText").value.length == 0) {
			document.getElementById("Dt2RatioText").className = "input_bg_2";
		} else {
			document.getElementById("Dt2RatioText").className = "input_bg_1";
		}
		if (document.getElementById("Dt2SttlMthdCodeList").value.length == 0) {
			document.getElementById("Dt2SttlMthdCodeList").className = "input_bg_2";
		} else {
			document.getElementById("Dt2SttlMthdCodeList").className = "input_bg_1";
		}
	} else {
		document.getElementById("Dt1BasisAmtText").className = "input_bg_1";
		document.getElementById("Dt2RatioText").className = "input_bg_1";
		document.getElementById("Dt2SttlMthdCodeList").className = "input_bg_1";
	}
	// 比率が 100 以外の入力時は、決済方法３は必須




	if ((document.getElementById("Dt2RatioText").value != 100) && (document.getElementById("Dt2RatioText").value.length != 0)) {
		if (document.getElementById("Dt3SttlMthdCodeList").value.length == 0) {
			document.getElementById("Dt3SttlMthdCodeList").className = "input_bg_2";
		} else {
			document.getElementById("Dt3SttlMthdCodeList").className = "input_bg_1";
		}
	} else {
			document.getElementById("Dt3SttlMthdCodeList").className = "input_bg_1";
	}
	makeWithChange(sender);
	return true;
}

// 入力チェック(明細行登録)
function checkValueRegist(sender) {

	var prodSpec1Title = "";
	var prodSpec2Title = "";
// 管理番号K26528 From
//	if (document.all["HeaderSpec1NameLabel"]!=null)
	if (document.getElementById("HeaderSpec1NameLabel")!=null)
// 管理番号K26528 To
	{
		prodSpec1Title = document.getElementById("HeaderSpec1NameLabel").innerHTML;
		prodSpec2Title = document.getElementById("HeaderSpec2NameLabel").innerHTML;
	}

	if (document.getElementById("SuplCodeText").value == "") {
// 		alert("［仕入先］を先に入力してください。"); //K24546
		alert(Resources.SC_JS000147);
// 管理番号 B20479 From
//		document.all["SuplCodeText"].focus();
// 管理番号K26528 From
//		if(document.all["SuplCodeText"].isDisabled){
		if(document.getElementById("SuplCodeText").disabled){
// 管理番号K26528 To
			document.getElementById("PoRefText").focus();
		}else{
			document.getElementById("SuplCodeText").focus();
		}
// 管理番号 B20479 To
		return false;
	}
// 	if (!CM_checkRequired("InpProdCodeText", "商品コード")) { //K24546
	if (!CM_checkRequired("InpProdCodeText", Resources.SC_JS000677)) {
		return false;
	}

	if (document.getElementById("inputRowProdTypeHidden").value != "2") {

// 		if (!CM_checkRequired("InpProdNameText", "商品名")) { //K24546
		if (!CM_checkRequired("InpProdNameText", Resources.SC_JS000681)) {
			return false;
		}
// 管理番号K26528 From
//		if (document.all["InpProdSpec1List"] != null && !document.all["InpProdSpec1List"].isDisabled) {
		if (document.getElementById("InpProdSpec1List") != null && !document.getElementById("InpProdSpec1List").disabled) {
// 管理番号K26528 To
			if (!CM_checkRequired("InpProdSpec1List", prodSpec1Title)) {
				return false;
			}
		}
// 管理番号K26528 From
//		if (document.all["InpProdSpec2List"]!=null && !document.all["InpProdSpec2List"].isDisabled) {
		if (document.getElementById("InpProdSpec2List")!=null && !document.getElementById("InpProdSpec2List").disabled) {
// 管理番号K26528 To
			if (!CM_checkRequired("InpProdSpec2List", prodSpec2Title)) {
				return false;
			}
		}
// 管理番号K26528 From
//		if (!document.all["InpWhCodeText"].isDisabled){
		if (!document.getElementById("InpWhCodeText").disabled){
// 管理番号K26528 To
// 			if (!CM_checkRequired("InpWhCodeText", "倉庫")) { //K24546
			if (!CM_checkRequired("InpWhCodeText", Resources.SC_JS000713)) {
				return false;
			}
		}
// 		if (!CM_checkRequired("InpPuQtText", "数量")) { //K24546
		if (!CM_checkRequired("InpPuQtText", Resources.SC_JS000692)) {
			return false;
		}
		if (document.getElementById("InpPuQtText").value.replace(/,/g,"") == 0) {
// 			alert("［数量］にゼロは指定できません。"); //K24546
			alert(Resources.SC_JS000301);
			document.getElementById("InpPuQtText").focus();
			return false;
		}
// 		if (!CM_checkRequired("InpPuPriceText", "仕入単価")) { //K24546
		if (!CM_checkRequired("InpPuPriceText", Resources.SC_JS000611)) {
			return false;
		}
	} else {
		if (document.getElementById("inpDispTypeHidden").value == "D") {
// 			if (!CM_checkRequired("InpPuPriceText", "仕入単価")) { //K24546
			if (!CM_checkRequired("InpPuPriceText", Resources.SC_JS000611)) {
				return false;
			}
		}
	}
// 管理番号K27057 From
	if (!CustomItemRequiredCheck("InpCustomItemPanel")) {
		return false;
	}
// 管理番号K27057 To
// 管理番号K26528 From
//// 管理番号 B12929 From
//	checkPuPriceUpdateStatus(sender, document.all["InpPuPriceText"], "0");
//// 管理番号 B12929 To
	checkPuPriceUpdateStatus(sender, document.getElementById("InpPuPriceText"), "0");
// 管理番号K26528 To
}

// 入力チェック(明細行更新)
function gridUpdateCheck(sender) {

	var prodSpec1Title = "";
	var prodSpec2Title = "";
// 管理番号K26528 From
//	if (document.all["HeaderSpec1NameLabel"]!=null)
	if (document.getElementById("HeaderSpec1NameLabel")!=null)
// 管理番号K26528 To
	{
		prodSpec1Title = document.getElementById("HeaderSpec1NameLabel").innerHTML;
		prodSpec2Title = document.getElementById("HeaderSpec2NameLabel").innerHTML;
	}

	if (document.getElementById("SuplCodeText").value == "") {
// 		alert("［仕入先］を先に入力してください。"); //K24546
		alert(Resources.SC_JS000147);
		document.getElementById("SuplCodeText").focus();
		return false;
	}
// 管理番号K26528 From
//// 	if (!CM_checkRequired(sender.appendedidpart + "EditProdCodeText", "商品コード")) { //K24546
//	if (!CM_checkRequired(sender.appendedidpart + "EditProdCodeText", Resources.SC_JS000677)) {
	if (!CM_checkRequired(sender.getAttribute("appendedidpart") + "EditProdCodeText", Resources.SC_JS000677)) {
// 管理番号K26528 To
		return false;
	}
	if (document.getElementById("editRowProdTypeHidden").value != "2") {
// 管理番号K26528 From
//// 		if (!CM_checkRequired(sender.appendedidpart + "EditProdNameText", "商品名")) { //K24546
//		if (!CM_checkRequired(sender.appendedidpart + "EditProdNameText", Resources.SC_JS000681)) {
		if (!CM_checkRequired(sender.getAttribute("appendedidpart") + "EditProdNameText", Resources.SC_JS000681)) {
// 管理番号K26528 To
			return false;
		}
// 管理番号K26528 From
//		if (document.all[sender.appendedidpart + "EditProdSpec1List"]!=null && !document.all[sender.appendedidpart + "EditProdSpec1List"].isDisabled){
//			if (!CM_checkRequired(sender.appendedidpart + "EditProdSpec1List", prodSpec1Title)){
		if (document.getElementById(sender.getAttribute("appendedidpart") + "EditProdSpec1List")!=null && !document.getElementById(sender.getAttribute("appendedidpart") + "EditProdSpec1List").disabled){
			if (!CM_checkRequired(sender.getAttribute("appendedidpart") + "EditProdSpec1List", prodSpec1Title)){
// 管理番号K26528 To
				return false;
			}
		}
// 管理番号K26528 From
//		if (document.all[sender.appendedidpart + "EditProdSpec2List"]!=null && !document.all[sender.appendedidpart + "EditProdSpec2List"].isDisabled){
//			if (!CM_checkRequired(sender.appendedidpart + "EditProdSpec2List", prodSpec2Title)) {
		if (document.getElementById(sender.getAttribute("appendedidpart") + "EditProdSpec2List")!=null && !document.getElementById(sender.getAttribute("appendedidpart") + "EditProdSpec2List").disabled){
			if (!CM_checkRequired(sender.getAttribute("appendedidpart") + "EditProdSpec2List", prodSpec2Title)) {
// 管理番号K26528 To
				return false;
			}
		}
// 管理番号K26528 From
//		if (!document.all[sender.appendedidpart + "EditWhCodeText"].isDisabled){
//// 			if (!CM_checkRequired(sender.appendedidpart + "EditWhCodeText", "倉庫")) { //K24546
//			if (!CM_checkRequired(sender.appendedidpart + "EditWhCodeText", Resources.SC_JS000713)) {
		if (!document.getElementById(sender.getAttribute("appendedidpart") + "EditWhCodeText").disabled){
			if (!CM_checkRequired(sender.getAttribute("appendedidpart") + "EditWhCodeText", Resources.SC_JS000713)) {
// 管理番号K26528 To
				return false;
			}
		}
// 管理番号K26528 From
//// 		if (!CM_checkRequired(sender.appendedidpart + "EditPuQtText", "数量")) { //K24546
//		if (!CM_checkRequired(sender.appendedidpart + "EditPuQtText", Resources.SC_JS000692)) {
		if (!CM_checkRequired(sender.getAttribute("appendedidpart") + "EditPuQtText", Resources.SC_JS000692)) {
// 管理番号K26528 To
			return false;
		}
// 管理番号K26528 From
//		if (document.all[sender.appendedidpart + "EditPuQtText"].value.replace(/,/g,"") == 0) {
		if (document.getElementById(sender.getAttribute("appendedidpart") + "EditPuQtText").value.replace(/,/g,"") == 0) {
// 管理番号K26528 To
// 			alert("［数量］にゼロは指定できません。"); //K24546
			alert(Resources.SC_JS000301);
// 管理番号K26528 From
//			document.all[sender.appendedidpart + "EditPuQtText"].focus();
			document.getElementById(sender.getAttribute("appendedidpart") + "EditPuQtText").focus();
// 管理番号K26528 To
			return false;
		}
// 管理番号K26528 From
//// 		if (!CM_checkRequired(sender.appendedidpart + "EditPuPriceText","仕入単価")) { //K24546
//		if (!CM_checkRequired(sender.appendedidpart + "EditPuPriceText",Resources.SC_JS000611)) {
		if (!CM_checkRequired(sender.getAttribute("appendedidpart") + "EditPuPriceText",Resources.SC_JS000611)) {
// 管理番号K26528 To
			return false;
		}

	} else {
		if (document.getElementById("editRowDispTypeHidden").value == "D") {
// 管理番号K26528 From
//// 			if (!CM_checkRequired(sender.appendedidpart + "EditPuPriceText","仕入単価")) { //K24546
//			if (!CM_checkRequired(sender.appendedidpart + "EditPuPriceText",Resources.SC_JS000611)) {
			if (!CM_checkRequired(sender.getAttribute("appendedidpart") + "EditPuPriceText",Resources.SC_JS000611)) {
// 管理番号K26528 To
				return false;
			}
		}
	}
// 管理番号K27057 From
	if (!CustomItemRequiredCheck("EditCustomItemPanel", null, sender.getAttribute("appendedidpart"))) {
		return false;
	}
// 管理番号K27057 To

// 管理番号K26528 From
//// 管理番号 B12929 From
//	checkPuPriceUpdateStatus(sender, document.all[sender.appendedidpart + "EditPuPriceText"], "1");
//// 管理番号 B12929 To
	checkPuPriceUpdateStatus(sender, document.getElementById(sender.getAttribute("appendedidpart") + "EditPuPriceText"), "1");
// 管理番号K26528 To
	return true;
}
// 管理番号 K25667 From
function validateAttachmentFileButtonClick(sender) {
	// 部門コードがブランクの場合は添付資料画面を起動しない
	if (!CM_checkRequired("DeptCodeText", Resources.SC_JS000793)) {
		return false;
	}
	return true;
}
// 管理番号 K25667 To
//-------------------------------------------------------------------
// コントロール制御
//-------------------------------------------------------------------
//プロジェクトコード次コントロール制御
function setProjCodeTextNextControl(sender) {

	var nextControl = "DeliTypeWRadio";
	if (!document.getElementById("DeliTypeWRadio").checked) {
		nextControl = "DeliTypeDRadio";
	}
	return nextControl;
}

// 次コントロール制御(タブ前)
function setNextCtrlTab(sender) {

	defaultFunctionKeyHeader(sender);

	var selectedIndex = document.getElementById("__TabSelector1_State").value;

	switch (selectedIndex) {
		case "0":
			nextFocusElement = document.getElementById("PuNameText");
			break;
		case "1":
			//返品時の明細行処理変更対応-INSERT-START
			//if (!document.getElementById("InpProdCodeText").disabled) {
			if (document.getElementById("InpProdCodeText") != null && !document.getElementById("InpProdCodeText").disabled) {
			//返品時の明細行処理変更対応-INSERT-END
				nextFocusElement = document.getElementById("InpProdCodeText");
			} else if (!document.getElementById("UpdateButton").disabled) {
				nextFocusElement = document.getElementById("UpdateButton");
			} else {
				nextFocusElement = document.getElementById("CloseButton");
			}
			break;
	}
}

// 次コントロール制御(件名)
function setNextCtrlPuName(sender) {
	defaultFunctionKeyHeader(sender);

// 管理番号K27062 From
//// 管理番号 B24264 From
////	if (document.getElementById("SuplFormalNameText") != null) {
////		nextFocusElement = document.getElementById("SuplFormalNameText");
////  } else if (!document.getElementById("DeliPlaceCodeList").disabled) {
//	if (!document.getElementById("DeliPlaceCodeList").disabled) {
//// 管理番号 B24264 To
//		nextFocusElement = document.getElementById("DeliPlaceCodeList");
	if (!document.getElementById("DeliPlaceCodeText").disabled) {
		nextFocusElement = document.getElementById("DeliPlaceCodeText");
// 管理番号K27062 To
	} else if (!document.getElementById("DeliPlaceNameText").disabled) {
		nextFocusElement = document.getElementById("DeliPlaceNameText");
// 管理番号K27062 From
	} else if (!document.getElementById("ZipText").disabled) {
		nextFocusElement = document.getElementById("ZipText");
// 管理番号K27062 To
	} else if (!document.getElementById("DtTypeList").disabled){
		nextFocusElement = document.getElementById("DtTypeList");
	} else {
		nextFocusElement = document.getElementById("CloseButton");
	}
}
function clickBase(sender) {
	var paramType = document.getElementById("__ParamType").value;
// 管理番号K26508 From
//	if (paramType!="View") {
	// ※権限設定区分が"V"：参照権限の場合は参照モードと同様のフォーカス設定を行う
	if (paramType!="View" && document.getElementById("__AuthoritySettingType").value != "V") {
// 管理番号K26508 To
		if (!document.getElementById("PuNameText").disabled) {
			document.getElementById("PuNameText").focus();
		}
	} else
	{
		document.getElementById("CloseButton").focus();
	}
}

function clickDetail(sender) {
	var paramType = document.getElementById("__ParamType").value;
// 管理番号K26508 From
//	if (paramType!="View") {
	// ※権限設定区分が"V"：参照権限の場合は参照モードと同様のフォーカス設定を行う
	if (paramType!="View" && document.getElementById("__AuthoritySettingType").value != "V") {
// 管理番号K26508 To
		//返品時の明細行処理変更対応-INSERT-START
		//if (!document.getElementById("InpProdCodeText").disabled) {
		if (document.getElementById("InpProdCodeText") != null && !document.getElementById("InpProdCodeText").disabled) {
		//返品時の明細行処理変更対応-INSERT-START
			document.getElementById("InpProdCodeText").focus();
		} else if(document.getElementById("EditRowElement") != null && !document.getElementById(document.getElementById("EditRowElement").value).disabled) {
			document.getElementById(document.getElementById("EditRowElement").value).focus();
		} else if (!document.getElementById("UpdateButton").disabled) {
			document.getElementById("UpdateButton").focus();
		} else {
			document.getElementById("CloseButton").focus();
		}
	} else {
		document.getElementById("CloseButton").focus();
	}
}
//-------------------------------------------------------------------
//　ダーティ制御
//-------------------------------------------------------------------
// ダーティ オン
function makeWithChange(sender) {
	document.getElementById("__isDirty").value = "true";
	//伝票印刷ボタン
	document.getElementById("PuSlipButton").disabled = true;
// 管理番号K26528 From
//// 管理番号 K25202 From
////	document.getElementById("PuSlipButton").style.filter="alpha(opacity=50) gray()";
//	document.getElementById("PuSlipButton").style.filter="alpha(opacity=40)";
//// 管理番号 K25202 To
//	document.getElementById("PuSlipButton").style.cursor="default";
// 管理番号K26528 To
	functionKeyDownFunctions[9] = null;
	changeHeaderState();
	return true;
}
// ダーティチェック
function checkDirty(sender) {
	if (checkDirty()) {
		return true;
	}
	return false;
}
// ダーティチェック
function checkDirty(msg) {
	if (document.getElementById("__isDirty").value == "true") {
		if (!window.confirm(msg)) {
			return false;
		}
	}
	return true;
}
// ダーティチェック
function checkDirty() {
	if (document.getElementById("__isDirty").value == "true") {
// 		if (!window.confirm("表示中のデータは更新されていません。\n破棄しますか？")) { //K24546
		if (!window.confirm(Resources.SC_JS000784)) {
			return false;
		}
	}
	return true;
}
// 管理番号K26528 From
// 不要なロジックのため削除
//// 更新時値変更(伝票番号)
//function IsDirtyCheck(sender) {
//	if (document.all["__isDirty"].value == "true") {
//// 		return window.confirm("[" + sender + "]が変更されています。読み込みなおしますか？"); //K24546
//		return window.confirm("[" + sender + Resources.SC_JS000471);
//	}
//	event.cancelBubble = true;
//	event.returnValue = false;
//	return true;
//}
//
//// 更新時値変更(受渡場所)
//function IsDirtyCheck2(sender) {
//	if (document.all["__isDirty"].value == "true") {
//// 		return window.alert("[" + sender + "]が変更されています。読み込みなおします。"); //K24546
//		return window.alert("[" + sender + Resources.SC_JS000469);
//	}
//	event.cancelBubble = false;
//	event.returnValue = false;
//	return false;
//}
// 管理番号K26528 To

/* ポストバックチェック処理 ///////////////////////////////////////////////////////////////////////////////*/
// 管理番号K26528 From
// 不要なロジックのため削除
//// 更新・削除イベント前のチェック(ポストバックが発生していない場合を想定)
//// 管理番号 B19805 From
////function postBackCheck() {
//function postBackCheck(sender) {
//// 管理番号 B19805 To
//	var paramType = document.all["__ParamType"].value;
//	var puNo      = document.all["__SlipNo"].value.toUpperCase();
//// 管理番号 B19805 From
//	sender.value  = document.all["PuNoText"].value
//// 管理番号 B19805 To
//
//	if (paramType=="Mod") {
//		if (document.all["PuNoText"].value != puNo) {
//// 管理番号 B19805 From
//
//// 管理番号 B19805 コメント削除
//
//// 			alert("［仕入番号］が変更されています。読み直します。"); //K24546
//			alert(Resources.SC_JS000157);
//				event.cancelBubble = true;
//				codeChange(sender, 0);
//				return false;
//// 管理番号 B19805 To
//		}
//	}
//	return true;
//}
// 管理番号K26528 To
// 管理番号 B13798 From
function openAdminItemWindow(sender) {
// 管理番号K26528 From
//	var AdminItem1 = document.all["AdminItem1Hidden"];
//	var AdminItem2 = document.all["AdminItem2Hidden"];
//	var AdminItem3 = document.all["AdminItem3Hidden"];
	var AdminItem1 = document.getElementById("AdminItem1Hidden");
	var AdminItem2 = document.getElementById("AdminItem2Hidden");
	var AdminItem3 = document.getElementById("AdminItem3Hidden");
// 管理番号K26528 To
// 管理番号 B14308 From
	var tempAdminItem1 = AdminItem1.value;
	var tempAdminItem2 = AdminItem2.value;
	var tempAdminItem3 = AdminItem3.value;
// 管理番号 B14308 To

	var paramType  = document.getElementById("__ParamType").value;
// 管理番号K26508 From
//	if (paramType == "Pymt")
	// パラメータ区分が"Pymt"：支払、もしくは権限設定区分が"V"：参照権限の場合
	if (paramType == "Pymt" || document.getElementById("__AuthoritySettingType").value == "V")
// 管理番号K26508 To
	{
		paramType = "View";
	}
	callAdminItemWindow(AdminItem1, AdminItem2, AdminItem3, paramType);
// 管理番号K26528 From
//// 管理番号 B14308 From
//	if (AdminItem1.value != tempAdminItem1 || AdminItem2.value != tempAdminItem2 || AdminItem3.value != tempAdminItem3) {
//		document.all["__isDirty"].value = "true";
//	}
//// 管理番号 B14308 To
//
//	return false;
	lazyTask.add(
		function () {
			if (AdminItem1.value != tempAdminItem1 || AdminItem2.value != tempAdminItem2 || AdminItem3.value != tempAdminItem3) {
				document.getElementById("__isDirty").value = "true";
			}
			return false;
		}
	);
// 管理番号K26528 To
}
// 管理番号 B13798 To

// 管理番号 B24839 コメント削除
// 管理番号 K24285 コメント削除

// 管理番号 B24188 From
// [保留解除ボタン]
function callHoldRelease(sender) {
// 		return window.confirm("　支払保留を解除しますか？\n（編集中のデータは破棄されます。）"); //K24546
		return window.confirm(Resources.SC_JS000000);
}
// 管理番号 B24188 To
