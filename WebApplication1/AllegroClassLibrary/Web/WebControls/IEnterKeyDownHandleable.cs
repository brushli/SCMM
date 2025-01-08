// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : IEnterKeyDownHandleable.cs
// 機能名      : onkeydownイベントによるエンターキー押下をハンドリングすることを示すインターフェース
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/08/08 UI見直し
// 3.0.0 2018/04/30

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// onkeydownイベントによるエンターキー押下をハンドリングすることを示すインターフェース
	/// </summary>
	public interface IEnterKeyDownHandleable : IKeyDownHandleable
	{
		/// <summary>
		/// コントロールにフォーカスがある状態でEnterキーが押された時に動作するクライアントスクリプトを指定します。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		string ClientEnterKeyScript { get; set; }
	}
}
