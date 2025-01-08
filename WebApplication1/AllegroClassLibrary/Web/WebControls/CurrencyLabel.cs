// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : CurrencyLabel.cs
// 機能名      : 金額表示用ラベルコントロール
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号 K25678 2015/09/15 金額項目の小数桁数統一
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/15 UI見直し
// 3.0.0 2018/04/30

using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// 金額表示用ラベルコントロール
	/// </summary>
	public class CurrencyLabel : EncodeLabel
	{
		/// <summary>GRANDITとして表示する最大の金額小数桁数</summary>
		private static readonly int MaxCurrencyDigits = 2;

// 管理番号K26528 From
//		/// <summary>
//		/// <see cref="Control.Load"/>イベントを発生させます。
//		/// </summary>
//		/// <param name="e">
//		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
//		/// </param>
//		protected override void OnLoad(EventArgs e)
//		{
//			CurrencyLabel.RegisterClientScriptBlock(this.Page.ClientScript);
//			base.OnLoad(e);
//		}
// 管理番号K26528 To

		/// <summary>
		/// <see cref="Control.PreRender"/>イベントを発生させます。/>
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnPreRender(EventArgs e)
		{
// 管理番号K26528 From
//			CurrencyLabel.RegisterStartupScript(this.Page.ClientScript, this.ClientID);
			this.RegisterClientScript();
// 管理番号K26528 To
			base.OnPreRender(e);
		}

		/// <summary>
		/// コントロールを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void Render(HtmlTextWriter writer)
		{
			var text = this.Text;
			if (text.StartsWith("\v"))
			{
				// 垂直タブで始まる場合、文字色を赤にして表示する
				this.ForeColor = Color.Red;
				text = text.Substring(1);
			}

			base.RenderBeginTag(writer);
			// テキストの内容を描画する
			writer.WriteEncodedText(text);
			// 小数点位置を揃えて表示するための文字列を描画する
			writer.Write(CurrencyLabel.CreateHiddenString(text));
			base.RenderEndTag(writer);
		}

		/// <summary>
		/// 小数点位置を揃えて表示するための非表示文字列を返します
		/// </summary>
		/// <param name="text">ラベルに描画される文字列</param>
		/// <returns>小数点位置を揃えて表示するための非表示文字列</returns>
		static string CreateHiddenString(string text)
		{
			var work = decimal.Zero;
			if (!decimal.TryParse(text, out work))
			{
				// 文字列が数値でなかった場合は何も返さない
				return string.Empty;
			}

			// 小数点に続く数値を取得して小数桁数を得る
			var digits = Regex.Match(text, @"(?<=\.)\d*?$").Length;
			if (CurrencyLabel.MaxCurrencyDigits <= digits)
			{
				// 小数桁数が金額の小数桁数を超えていた場合は描画する文字列が存在しないので何も返さない
				return string.Empty;
			}

			var hiddenString =
				digits == 0
					// 整数である場合、小数点+金額小数桁数分のゼロを描画する
					? "." + new string('0', CurrencyLabel.MaxCurrencyDigits)
					// 整数でない場合、金額小数桁数に満たないゼロを描画する
					: new string('0', CurrencyLabel.MaxCurrencyDigits - digits)
					;

			return "<span style=\"visibility:hidden;\">" + hiddenString + "</span>";
		}

// 管理番号K26528 From
//		/// <summary>
//		/// クライアント側で小数点位置を揃えるためのメソッドを登録するスクリプトを生成します
//		/// <para>同一画面に複数の<see cref="CurrencyLabel"/>が存在する場合、スクリプトは1回だけ生成されます</para>
//		/// </summary>
//		/// <param name="clientScript">スクリプトを埋め込むページの<see cref="ClientScriptManager" />オブジェクト</param>
//		static void RegisterClientScriptBlock(ClientScriptManager clientScript)
//		{
//			// setCurrencyValueの処理概要：
//			// 1: innerHTMLに値をセットする
//			// 2: innerHTMLにセットした値が10進数値文字列だった場合（正規表現で判定）、桁揃えを行うための非表示文字列をinnerHTMLに追記する
//			clientScript.RegisterClientScriptBlock(
//				typeof(CurrencyLabel)
//				, "RegisterClientScriptBlock"
//				, @"
//function registerSetCurrencyValue(id){
//	var zeroString = '" + new string('0', CurrencyLabel.MaxCurrencyDigits) + @"';
//	var element = document.getElementById(id);
//	if(element) {
//		element.setCurrencyValue =
//			function(value) {
//				this.innerHTML = '' + value;
//				if(this.innerHTML == '') {
//					return this.innerHTML;
//				}
//
//				var match = this.innerHTML.match(/^([-+]?(?:\d*|\d{1,3}(?:,\d{3})+))(?:\.(\d+))?$/);
//				if(!match) {
//					return this.innerHTML;
//				}
//
//				var digits = match[2].length;
//				if(zeroString.length <= digits) {
//					return this.innerHTML;
//				}
//
//				var hiddenString =
//					digits == 0
//						? '.' + zeroString
//						: zeroString.substring(0, digits)
//						;
//
//				return this.innerHTML += '<span style=""visibility:hidden;"">' + hiddenString + '</span>';
//			};
//	}
//}"
//				, true
//				);
//		}
//
//		/// <summary>
//		/// 生成した<see cref="CurrencyLabel"/>に対してクライアント側で小数点位置を揃えるためのメソッドを登録します
//		/// <para>
//		/// <see cref="RegisterClientScriptBlock"/>で生成されたスクリプトを実行することで
//		/// <see cref="CurrencyLabel"/>に対して<c>setCurrencyValue</c>メソッドが登録されます
//		/// </para>
//		/// </summary>
//		/// <param name="clientScript">スクリプトを埋め込むページの<see cref="ClientScriptManager" />オブジェクト</param>
//		/// <param name="clientID">埋め込み対象のコントロールID</param>
//		static void RegisterStartupScript(ClientScriptManager clientScript, string clientID)
//		{
//			clientScript.RegisterStartupScript(
//				typeof(CurrencyLabel)
//				, clientID
//				, @"registerSetCurrencyValue('" + clientID + @"');"
//				, true
//				);
//		}

		/// <summary>
		/// クライアントスクリプトを登録します。
		/// </summary>
		private void RegisterClientScript()
		{
			var parameter = new[]
			{
				"'" + this.ClientID + "'",
				"'" + new string('0', CurrencyLabel.MaxCurrencyDigits) + "'",
			};

			var script = "__customControl.initializer.currencyLabelInitializer(" + string.Join(", ", parameter) + ");";
			((PageBase)this.Page).ImmediateStartupScript.RegisterScript(this.GetType(), this.UniqueID + "StartupScript", script);
		}
// 管理番号K26528 To
	}
}
