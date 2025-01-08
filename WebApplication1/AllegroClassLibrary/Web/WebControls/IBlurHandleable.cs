// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : IBlurHandleable.cs
// 機能名      : onblurイベントをハンドリングすることを示すインターフェース
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/02/13 UI見直し
// 3.0.0 2018/04/30

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// onblurイベントをハンドリングすることを示すインターフェース
	/// </summary>
	public interface IBlurHandleable
	{
		/// <summary>
		/// コントロールがフォーカスを失った時に、サーバーへのポストバックが自動的に発生するかどうか。
		/// </summary>
		bool AutoPostBack { get; set; }

		/// <summary>
		/// コントロールがフォーカスを失った時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// <para>
		/// コントロール内のテキストに変更があった場合、
		/// <see cref="ClientBlurScript"/>は<see cref="ClientChangeScript"/>の後に実行されます。
		/// </para>
		/// </remarks>
		string ClientBlurScript { get; set; }

		/// <summary>
		/// コントロールのテキストが変更され、フォーカスを失った時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// <para>
		/// <see cref="ClientChangeScript"/>は<see cref="ClientBlurScript"/>の前に実行されます。
		/// </para>
		/// </remarks>
		string ClientChangeScript { get; set; }

		/// <summary>
		/// 必須項目：true、非必須項目：false
		/// </summary>
		bool IsRequiredField { get; set; }
	}
}
