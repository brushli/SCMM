// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : TypeLength.cs
// 機能名      : 項目桁数定義
// Version     : 3.1.0
// Last Update : 2020/06/30
// Copyright (c) 2004-2020 Grandit Corp. All Rights Reserved.
//
// 管理番号K27011 2019/01/18 項目桁数拡張：取引先・商品・勘定科目
// 3.1.0 2020/06/30

namespace Infocom.Allegro
{
	/// <summary>
	/// 項目桁数を定義します。このクラスは継承できません。
	/// </summary>
	public static class TypeLength
	{
		/// <summary>
		/// 取引先コード固定桁数の桁数
		/// </summary>
		public const int CompCodeFixedDigit = 2;

		/// <summary>
		/// 取引先コードの桁数
		/// </summary>
		public const int CompCode = 30;

		/// <summary>
		/// 得意先／仕入先枝番の桁数
		/// </summary>
		public const int CompSbno = 20;

		/// <summary>
		/// 得意先／仕入先枝番の入力桁数
		/// </summary>
		public const int CompSbnoInputDigit = 2;

		/// <summary>
		/// 取引先名の桁数
		/// </summary>
		public const int CompName = 100;

		/// <summary>
		/// 取引先カナ名の桁数
		/// </summary>
		public const int CompKanaName = 100;

		/// <summary>
		/// 取引先英字名の桁数
		/// </summary>
		public const int CompEngName = 100;

		/// <summary>
		/// 取引先略名の桁数
		/// </summary>
		public const int CompShortName = 100;

		/// <summary>
		/// 商品コードの桁数
		/// </summary>
		public const int ProdCode = 50;

		/// <summary>
		/// 商品名の桁数
		/// </summary>
		public const int ProdName = 100;

		/// <summary>
		/// 商品カナ名の桁数
		/// </summary>
		public const int ProdKanaName = 100;

		/// <summary>
		/// 商品英字名の桁数
		/// </summary>
		public const int ProdEngName = 100;

		/// <summary>
		/// 商品伝票名の桁数
		/// </summary>
		public const int ProdSlipName = 100;

		/// <summary>
		/// 商品略名の桁数
		/// </summary>
		public const int ProdShortName = 100;

		/// <summary>
		/// SKUコードの桁数
		/// </summary>
		public const int SkuCode = 100;

		/// <summary>
		/// 勘定科目コードの桁数
		/// </summary>
		public const int AccountCode = 50;

		/// <summary>
		/// 補助科目コードの桁数
		/// </summary>
		public const int AuxAccountCode = 50;

		/// <summary>
		/// 補助科目略名の桁数
		/// </summary>
		public const int AuxAccountShortName = 100;

		/// <summary>
		/// 債権計上明細コードの桁数
		/// </summary>
		public const int ArBookDtilCode = 50;

		/// <summary>
		/// 債権計上明細名の桁数
		/// </summary>
		public const int ArBookDtilName = 100;

		/// <summary>
		/// 債務計上明細コードの桁数
		/// </summary>
		public const int ApBookDtilCode = 50;

		/// <summary>
		/// 債務計上明細名の桁数
		/// </summary>
		public const int ApBookDtilName = 100;

		/// <summary>
		/// 任意集計KEYの桁数
		/// </summary>
		public const int OptionalSummaryCode = 185;
	}
}