// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : HtmlMessage.cs
// 機能名      : 画面表示用HTMLメッセージ
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/04/04 UI見直し
// 3.0.0 2018/04/30

using System;
using System.IO;
using System.Web.UI;

namespace Infocom.Allegro.Web.Html
{
	/// <summary>
	/// 画面表示用HTMLメッセージ
	/// </summary>
	public sealed class HtmlNoticeMessage : HtmlConverterBase
	{
		/// <summary>
		/// 画面表示用HTMLメッセージ
		/// </summary>
		/// <param name="message">
		/// メッセージテキスト
		/// </param>
		/// <param name="exceptionLevel">
		/// 例外レベル
		/// </param>
		public HtmlNoticeMessage(string message, ExceptionLevel exceptionLevel)
			: base(message)
		{
			this.ExceptionLevel = exceptionLevel;
		}

		/// <summary>
		/// 画面表示用HTMLメッセージ
		/// </summary>
		/// <param name="message">
		/// メッセージテキスト
		/// </param>
		/// <param name="messageLevel">
		/// メッセージレベル
		/// </param>
		public HtmlNoticeMessage(string message, MessageLevel messageLevel)
			// 同じ名前の例外レベルに変換する
			: this(message, (ExceptionLevel)Enum.Parse(typeof(ExceptionLevel), messageLevel.ToString()))
		{
		}

		/// <summary>
		/// 例外レベル
		/// </summary>
		private ExceptionLevel ExceptionLevel { get; set; }

		/// <summary>
		/// <see cref="ExceptionLevel" />に応じたCSSクラスを持つspan要素への変換を行います。
		/// <para>末尾以外の改行はbr要素に変換されます。</para>
		/// </summary>
		/// <returns></returns>
		public override string ToHtml()
		{
			// 改行⇒br要素への変換はHtmlMultilineTextを使用する
			var message = new HtmlMultilineText(this.TextContent).ToHtml();
			if (this.ExceptionLevel == ExceptionLevel.Verbose)
			{
				return message;
			}

			using (var stringWriter = new StringWriter())
			using (var htmlWriter = new HtmlTextWriter(stringWriter))
			{
				var cssClass = "msg_lbl msg_lbl_" + this.ExceptionLevel.ToString().ToLower();
				htmlWriter.AddAttribute(HtmlTextWriterAttribute.Class, cssClass);
				htmlWriter.RenderBeginTag(HtmlTextWriterTag.Span);

				// 前書き
				string foreword = null;
				switch (this.ExceptionLevel)
				{
					case ExceptionLevel.Undefined:
						foreword = AllegroMessage.S20027;
						break;
					case ExceptionLevel.FatalError:
						foreword = AllegroMessage.S20026;
						break;
					case ExceptionLevel.Error:
						foreword = string.Empty;
						break;
				}

				// Error以上の場合は画像による確認メッセージを出力する
				if (foreword != null)
				{
					htmlWriter.Write(foreword);

					// img/CM_a3_error_info.gif
					var imgSrc = MultiLanguage.Get("CM_IM000121");
					// ご確認ください。
					var imgAlt = MultiLanguage.Get("CM_CS004040");

					htmlWriter.AddAttribute(HtmlTextWriterAttribute.Src, imgSrc);
					htmlWriter.AddAttribute(HtmlTextWriterAttribute.Alt, imgAlt);
					htmlWriter.AddAttribute(HtmlTextWriterAttribute.Title, imgAlt);
					htmlWriter.RenderBeginTag(HtmlTextWriterTag.Img);
					htmlWriter.RenderEndTag();
				}

				htmlWriter.Write(message);
				htmlWriter.RenderEndTag();

				return stringWriter.ToString();
			}
		}
	}
}
