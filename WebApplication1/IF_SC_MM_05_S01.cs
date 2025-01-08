// Product     : Allegro
// Unit        : SC
// Module      : MM
// Function    : 05
// File Name   : IF_SC_MM_05_S01.cs
// 機能名      : SC_MM_05_S01 仕入一覧
// Version     : 3.1.0
// Last Update : 2020/06/30
// Copyright (c) 2004-2020 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 管理番号 B13500 2004/11/29 輸入業務の入荷機能の対応
// 1.3.0 2004/12/31
// 管理番号 B13878 2005/02/03 売上・仕入時の単価未決対応
// 管理番号 B13877 2005/02/12 プロジェクト別在庫管理対応
// 1.3.2 2005/03/31
// 管理番号 K16187 2005/09/06 支払機能拡張対応
// 1.4.0 2005/10/31
// 管理番号 K16671 2005/12/20 貿易機能改善（参照コードの追加対応）
// 管理番号 K16764 2006/01/11 支払保留伝票の絞込機能追加
// 1.5.0 2006/03/31
// 1.5.2 2007/10/31
// 管理番号 B20818 2007/12/17 楽観ロック対応
// 管理番号 K22205 2008/11/06 WF申請者以外の修正対応
// 1.6.0 2009/09/30
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25679 2015/10/26 グループ対応
// 管理番号 K25680 2015/10/26 外部連携
// 2.3.0 2016/06/30
// 3.0.0 2018/04/30
// 管理番号K27063 2019/08/07 客注番号／発注管理番号の全角入力対応
// 管理番号K27058 2019/10/29 汎用区分追加
// 管理番号K27057 2019/12/02 汎用項目追加
// 3.1.0 2020/06/30
// 管理番号K27154 2020/07/13 収益認識対応

using System;
using System.Text;
using Infocom.Allegro.IF;
using Infocom.Allegro.CM.MS;
using Infocom.Allegro.SC.MS;

namespace Infocom.Allegro.SC
{
	[Serializable()]
	public class IF_SC_MM_05_S01_SearchCondition : Infocom.Allegro.IF.IFBase
	{
		#region Protected Fields
		protected string puDateFrom			= string.Empty;
		protected string puDateTo			= string.Empty;
		protected string puNoFrom			= string.Empty;
		protected string puNoTo				= string.Empty;
		protected string suplCode			= string.Empty;
		protected string suplSbNo			= string.Empty;
		protected string subDeptSearchFlg	= string.Empty;
		protected string deptCode			= string.Empty;
		protected string empCode			= string.Empty;
		protected string projCode			= string.Empty;
		protected string projSbNo			= string.Empty;
		protected string poDateFrom			= string.Empty;
		protected string poDateTo			= string.Empty;
		protected string poNoFrom			= string.Empty;
		protected string poNoTo				= string.Empty;
		protected string suplBillSlipNo		= string.Empty;
		protected string prodCode			= string.Empty;
		protected string puModeType			= string.Empty;
// 管理番号K27058 From
		protected string puModeTypeDtilCode = string.Empty;
		protected string bookBasisType = string.Empty; // 仕入計上基準区分
		protected string bookBasisTypeDtilCode = string.Empty; // 仕入計上基準区分明細コード
// 管理番号K27058 To
// 管理番号 K16671 From
		protected string refCodeWord		= string.Empty;
		protected string refCode			= string.Empty;
// 管理番号 K16671 To
		protected string approvalStatusType	= string.Empty;
		protected string redSlip			= string.Empty;
// 管理番号 B13878 From
		protected string priceUndecided		= string.Empty;
// 管理番号 B13878 To
// 管理番号 K16764 From
		protected string holdFlg            = string.Empty;
// 管理番号 K16764 To
// 管理番号 K22205 From
        protected string inputEmpCode       = string.Empty;
// 管理番号 K22205 To
// 管理番号 B13877 From
		protected bool projUseFlg;
// 管理番号 B13877 To
//管理番号B13500 From
		protected string rcptInputFlg		= string.Empty;
//管理番号B13500 To
		protected string overseasFlg		= "0";				// 海外フラグ初期値設定
// 管理番号 K16187 From
		protected bool apModuleFlg;
// 管理番号 K16187 To
// 管理番号 K25679 From
		protected string suplSlipNo = string.Empty; //仕入先伝票番号
		protected string poAdminNo = string.Empty; //発注管理番号
// 管理番号 K25679 To
// 管理番号 K25680 From
		protected string originType = string.Empty; //発生元
// 管理番号 K25680 To
// 管理番号K27154 From
		protected string dealTypeCode		= string.Empty;		// 取引区分コード
// 管理番号K27154 To
		#endregion

// 管理番号K27057 From
		#region Private Fields
		private IF_CM_MS_CustomItem customItemHead = new IF_CM_MS_CustomItem();
		private IF_CM_MS_CustomItem customItemDtil = new IF_CM_MS_CustomItem();
		#endregion
// 管理番号K27057 To

		#region Properties
		public string PuDateFrom
		{
			get {return puDateFrom;}
// 			set {puDateFrom = ValidateDateTimeString("仕入日（自）", value, false);} //K24546
			set {puDateFrom = ValidateDateTimeString(MultiLanguage.Get("SC_CS003726"), value, false);}
		}
		public string PuDateTo
		{
			get {return puDateTo;}
// 			set {puDateTo = ValidateDateTimeString("仕入日（至）", value, false);} //K24546
			set {puDateTo = ValidateDateTimeString(MultiLanguage.Get("SC_CS003725"), value, false);}
		}
		public string PuNoFrom
		{
			get {return puNoFrom;}
// 			set {puNoFrom = ValidateString("仕入番号（自）", value, false, 10, CheckOption.SingleByte);} //K24546
			set {puNoFrom = ValidateString(MultiLanguage.Get("SC_CS003729"), value, false, 10, CheckOption.SingleByte);}
		}
		public string PuNoTo
		{
			get {return puNoTo;}
// 			set {puNoTo = ValidateString("仕入番号（至）", value, false, 10, CheckOption.SingleByte);} //K24546
			set {puNoTo = ValidateString(MultiLanguage.Get("SC_CS003728"), value, false, 10, CheckOption.SingleByte);}
		}
		public string SuplCode
		{
			get {return suplCode;}
			set {suplCode = value;}
		}
		public string SuplSbNo
		{
			get {return suplSbNo;}
			set {suplSbNo = value;}
		}
		public string SubDeptSearchFlg
		{
			get {return subDeptSearchFlg;}
			set {subDeptSearchFlg = value;}
		}
		public string DeptCode
		{
			get {return deptCode;}
// 			set {deptCode = ValidateString("部門", value, false, 10, CheckOption.SingleByte);} //K24546
			set {deptCode = ValidateString(MultiLanguage.Get("SC_CS001858"), value, false, 10, CheckOption.SingleByte);}
		}
		public string EmpCode
		{
			get {return empCode;}
// 			set {empCode = ValidateString("担当者", value, false, 10, CheckOption.SingleByte);} //K24546
			set {empCode = ValidateString(MultiLanguage.Get("SC_CS001476"), value, false, 10, CheckOption.SingleByte);}
		}
		public string ProjCode
		{
			get {return projCode;}
			set {projCode = value;}
		}
		public string ProjSbNo
		{
			get {return projSbNo;}
			set {projSbNo = value;}
		}
		public string PoDateFrom
		{
			get {return poDateFrom;}
// 			set {poDateFrom = ValidateDateTimeString("発注日（自）", value, false);} //K24546
			set {poDateFrom = ValidateDateTimeString(MultiLanguage.Get("SC_CS005287"), value, false);}
		}
		public string PoDateTo
		{
			get {return poDateTo;}
// 			set {poDateTo = ValidateDateTimeString("発注日（至）", value, false);} //K24546
			set {poDateTo = ValidateDateTimeString(MultiLanguage.Get("SC_CS005285"), value, false);}
		}
		public string PoNoFrom
		{
			get {return poNoFrom;}
// 			set {poNoFrom = ValidateString("発注番号（自）", value, false, 10, CheckOption.SingleByte);} //K24546
			set {poNoFrom = ValidateString(MultiLanguage.Get("SC_CS005293"), value, false, 10, CheckOption.SingleByte);}
		}
		public string PoNoTo
		{
			get {return poNoTo;}
// 			set {poNoTo = ValidateString("発注番号（至）", value, false, 10, CheckOption.SingleByte);} //K24546
			set {poNoTo = ValidateString(MultiLanguage.Get("SC_CS005291"), value, false, 10, CheckOption.SingleByte);}
		}
		public string SuplBillSlipNo
		{
			get {return suplBillSlipNo;}
// 			set {suplBillSlipNo = ValidateString("仕入先請求書番号", value, false, 15, CheckOption.SingleByte);} //K24546
			set {suplBillSlipNo = ValidateString(MultiLanguage.Get("SC_CS000791"), value, false, 15, CheckOption.SingleByte);}
		}
		public string ProdCode
		{
			get {return prodCode;}
// 			set {prodCode = ValidateString("商品", value, false, 20, CheckOption.SingleByte);} //K24546
			set {prodCode = ValidateString(MultiLanguage.Get("SC_CS001152"), value, false, 20, CheckOption.SingleByte);}
		}

// 管理番号K27058 From
//		public string PuModeType
//		{
//			get {return puModeType;}
//			set {puModeType = value;}
//		}
		public string PuModeType
		{
			get { return puModeType; }
			// 仕入形態
			set { puModeType = ValidateString(MultiLanguage.Get("SC_CS000777"), value, false, 1); }
		}

		public virtual string PuModeTypeDtilCode
		{
			get { return puModeTypeDtilCode; }
			// 仕入形態区分明細コード
			set { puModeTypeDtilCode = ValidateString(MultiLanguage.Get("SC_CS006323"), value, false, 2); }
		}

		public string BookBasisType
		{
			get { return bookBasisType; }
			// 計上基準区分
			set { bookBasisType = ValidateString(MultiLanguage.Get("SC_CS003226"), value, false, 1); }
		}

		public string BookBasisTypeDtilCode
		{
			get { return bookBasisTypeDtilCode; }
			// 計上基準区分明細コード
			set { bookBasisTypeDtilCode = ValidateString(MultiLanguage.Get("SC_CS006317"), value, false, 2); }
		}
// 管理番号K27058 To

// 管理番号 K16671 From
		public string RefCodeWord
		{
			set {refCodeWord = value;}
		}

		public string RefCode
		{
			get {return refCode;}
			set {refCode = ValidateString(refCodeWord, value, false, 20, CheckOption.SingleByte);}
		}
// 管理番号 K16671 To

		public string ApprovalStatusType
		{
			get {return approvalStatusType;}
			set {approvalStatusType = value;}
		}
		public string RedSlip
		{
			get {return redSlip;}
			set {redSlip = value;}
		}
// 管理番号 B13878 From
		public string PriceUndecided
		{
			get {return priceUndecided;}
			set {priceUndecided = value;}
		}
// 管理番号 B13878 To
// 管理番号 K16764 From
		public string HoldFlg
		{
			get {return holdFlg;}
			set {holdFlg = value;}
		}
// 管理番号 K16764 To
// 管理番号 K22205 From
		public virtual string InputEmpCode
		{
			get {return inputEmpCode;}
//             set { inputEmpCode = ValidateString("入力者", value, false, 10, CheckOption.SingleByte); } //K24546
            set { inputEmpCode = ValidateString(MultiLanguage.Get("SC_CS001657"), value, false, 10, CheckOption.SingleByte); }
		}
// 管理番号 K22205 To
// 管理番号 B13877 From
		public bool ProjUseFlg
		{
			get {return projUseFlg;}
			set {projUseFlg = value;}
		}
// 管理番号 B13877 To
//管理番号B13500 From
		public string RcptInputFlg
		{
			get {return rcptInputFlg;}
			set {rcptInputFlg = value;}
		}
//管理番号B13500 To
		public string OverseasFlg
		{
			get {return overseasFlg;}
			set {overseasFlg = value;}
		}
// 管理番号 K16187 From
		public bool ApModuleFlg
		{
			get {return apModuleFlg;}
			set {apModuleFlg = value;}
		}
// 管理番号 K16187 To
// 管理番号 K25679 From
		public string SuplSlipNo
		{
			get { return suplSlipNo; }
			set { suplSlipNo = ValidateString(MultiLanguage.Get("SC_CS006219"), value, false, 10, CheckOption.SingleByte); } //"仕入先伝票番号"
		}
		public string PoAdminNo
		{
			get { return poAdminNo; }
// 管理番号K27063 From
//			set { poAdminNo = ValidateString(MultiLanguage.Get("SC_CS006200"), value, false, 30, CheckOption.SingleByte); } //"発注管理番号"
			set { poAdminNo = ValidateString(MultiLanguage.Get("SC_CS006200"), value, false, 30, CheckOption.None); } //"発注管理番号"
// 管理番号K27063 To
		}
// 管理番号 K25679 To
// 管理番号 K25680 From
		//発生元ドロップダウンリストの値をチェックする
		public string OriginType
		{
			get { return originType; }
			set { originType = ValidateChoiceString(MultiLanguage.Get("SC_CS006220"), value, new string[] { "0", "1", "2" }); } //"発生元"
		}
// 管理番号 K25680 To
// 管理番号K27154 From
		public virtual string DealTypeCode
		{
			get {return dealTypeCode;}
			set {dealTypeCode = ValidateString(MultiLanguage.Get("SC_CS006354"), value, false, 3, CheckOption.SingleByte);}	//取引区分
		}
// 管理番号K27154 To

// 管理番号K27057 From
		/// <summary>
		/// 汎用項目共通部品IF(ヘッダ)
		/// </summary>
		public IF_CM_MS_CustomItem CustomItemHead
		{
			get { return customItemHead; }
			set { customItemHead = value; }
		}
		/// <summary>
		/// 汎用項目共通部品IF(明細)
		/// </summary>
		public IF_CM_MS_CustomItem CustomItemDtil
		{
			get { return customItemDtil; }
			set { customItemDtil = value; }
		}
// 管理番号K27057 To
		#endregion

		#region Methods
		public void DivideSuplCode(string SuplCode, byte SuplCodeLength)
		{
// 			DivideCombinationCode("仕入先", SuplCode, SuplCodeLength, out this.suplCode, out this.suplSbNo, CombinationCodeOption.Comp); //K24546
			DivideCombinationCode(MultiLanguage.Get("SC_CS000784"), SuplCode, SuplCodeLength, out this.suplCode, out this.suplSbNo, CombinationCodeOption.Comp);
		}
		public void DivideProjCode(string ProjCode, byte ProjCodeLength)
		{
// 			DivideCombinationCode("プロジェクト", ProjCode, ProjCodeLength, out this.projCode, out this.projSbNo, CombinationCodeOption.Proj); //K24546
			DivideCombinationCode(MultiLanguage.Get("SC_CS000232"), ProjCode, ProjCodeLength, out this.projCode, out this.projSbNo, CombinationCodeOption.Proj);
		}
		public void Validate(CommonData commonData, string disclosureUnitType, string userDeptCode)
		{
			//仕入日の範囲チェック
			if (this.puDateFrom.Length != 0 && this.puDateTo.Length != 0)
			{
				if (Convert.ToDateTime(this.puDateFrom) > Convert.ToDateTime(this.puDateTo))
				{
// 					AddErrorMessage(AllegroMessage.S10013("仕入日（至）", "仕入日（自）")); //K24546
					AddErrorMessage(AllegroMessage.S10013(MultiLanguage.Get("SC_CS003725"), MultiLanguage.Get("SC_CS003726")));
				}
			}
			//仕入番号の範囲チェック
			if (this.puNoFrom.Length != 0 && this.puNoTo.Length != 0)
			{
				if (this.puNoTo.CompareTo(this.puNoFrom) < 0)
				{
// 					AddErrorMessage(AllegroMessage.S10014("仕入番号（至）", "仕入番号（自）")); //K24546
					AddErrorMessage(AllegroMessage.S10014(MultiLanguage.Get("SC_CS003728"), MultiLanguage.Get("SC_CS003729")));
				}
			}
			//ページ公開単位区分（「全社」/「部門」）部門の時、部門コード必須チェック
			if(disclosureUnitType == "D")
			{
				if (this.deptCode.Length == 0) 
				{
// 					AddErrorMessage(AllegroMessage.S10006("部門")); //K24546
					AddErrorMessage(AllegroMessage.S10006(MultiLanguage.Get("SC_CS001858")));
				}
				else
				{
					//基準日の決定（優先順位：仕入日（至）→仕入日（自）→本日日付）
					string compareDate = DateTime.Today.ToString();
					if (this.puDateTo.Length != 0)
					{
						compareDate = this.puDateTo;
					}
					else if (this.puDateFrom.Length != 0)
					{
						compareDate = this.puDateFrom;
					}
					if(!Dept.IsExists(commonData, this.deptCode, compareDate, false, false, false, userDeptCode, false, false))
					{
// 						AddErrorMessage(AllegroMessage.S20005("部門")); //K24546
						AddErrorMessage(AllegroMessage.S20005(MultiLanguage.Get("SC_CS001858")));
					}
				}
			}
			//発注日の範囲チェック
			if (this.poDateFrom.Length != 0 && this.poDateTo.Length != 0)
			{
				if (Convert.ToDateTime(this.poDateFrom) > Convert.ToDateTime(this.poDateTo))
				{
// 					AddErrorMessage(AllegroMessage.S10013("発注日（至）", "発注日（自）")); //K24546
					AddErrorMessage(AllegroMessage.S10013(MultiLanguage.Get("SC_CS005285"), MultiLanguage.Get("SC_CS005287")));
				}
			}
			//発注番号の範囲チェック
			if (this.poNoFrom.Length != 0 && this.poNoTo.Length != 0)
			{
				if (this.poNoTo.CompareTo(this.poNoFrom) < 0)
				{
// 					AddErrorMessage(AllegroMessage.S10014("発注番号（至）", "発注番号（自）")); //K24546
					AddErrorMessage(AllegroMessage.S10014(MultiLanguage.Get("SC_CS005291"), MultiLanguage.Get("SC_CS005293")));
				}
			}
// 管理番号K27057 From
			CustomItemHead.Validate(null, AddErrorMessage);
			CustomItemDtil.Validate(null, AddErrorMessage);
// 管理番号K27057 To
		}

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
// 管理番号 B20818 From
	[Serializable()]
	public class IF_SC_MM_05_S01_RowData : IF_SC_MM_05_Base
	{
		#region Constructors
		public IF_SC_MM_05_S01_RowData():base()
		{}
		#endregion
	}
// 管理番号 B20818 To

}
