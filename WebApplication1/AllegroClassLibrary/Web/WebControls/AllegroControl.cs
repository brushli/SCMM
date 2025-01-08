// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : AllegroControl.cs
// 機能名      : カスタムコントロールから利用する静的メソッド定義
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 1.6.0 2009/09/30
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/13 UI見直し
// 3.0.0 2018/04/30
// 3.1.0 2020/06/30
// 管理番号K27445 2022/02/15 ログ管理強化
// 3.2.0 2023/03/31

using System;
// 管理番号K26528 From
using System.Collections.Generic;
using System.Linq;
// 管理番号K26528 To
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// カスタムコントロールから利用する静的メソッドの定義です。
	/// </summary>
	internal sealed class AllegroControl
	{
// 管理番号K26528 From
		/// <summary>
		/// コントロールの属性名の接頭辞。
		/// </summary>
		private static readonly string ControlAttributePrefix = "allegrocontrol-";

		/// <summary>
		/// コントロールの種別を表す属性名。
		/// </summary>
		private static readonly string ControlTypeAttribute = ControlAttributePrefix + "type";

		/// <summary>
		/// コントロールの副種別を表す属性名。
		/// </summary>
		private static readonly string ControlSubtypeAttribute = ControlAttributePrefix + "subtype";
// 管理番号K26528 To

		private AllegroControl()
		{
		}

		/// <summary>
		/// ポストバック前の画面でフォーカスがセットされていたコントロールIDを格納する隠しフィールドのID。
		/// </summary>
		public const string LastControlHiddenName = "__LastActiveControl";
// 管理番号K27445 From
		public const string FunctionKeyControlHiddenName = "__FunctionKeyControlName";
		public const string FunctionKeyControlHiddenValue = "__FunctionKeyControlValue";
// 管理番号K27445 To
// 管理番号K26528 From
//		/// <summary>
//		/// キー押下時の共通処理を行うクライアントスクリプトを定義したscript要素。
//		/// </summary>
//		public const string OnKeyDownScript = "<script src=\"js/CM_KeyDownScript.js\" type=\"text/javascript\"></script>";
// 管理番号K26528 To

		/// <summary>
		/// 指定したコントロールに対してonfocus属性を追加します。
		/// </summary>
		/// <param name="control">
		/// onfocus属性を追加するコントロール。
		/// </param>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public static void AddOnfocusScript(IAllegroContorl control, HtmlTextWriter writer)
		{
			StringBuilder script = new StringBuilder("setValiables(this,", 128);
			if (control.InnerNextControlID.Length != 0)
			{
				script.Append('\'').Append(control.InnerNextControlID).Append("',");
				writer.AddAttribute("nextelement", control.InnerNextControlID);
			}
			else
			{
				script.Append("null,");
			}
			script.Append((control.ClientF01Script.Length != 0) ? control.ClientF01Script : "null").Append(',');
			script.Append((control.ClientF02Script.Length != 0) ? control.ClientF02Script : "null").Append(',');
			script.Append((control.ClientF03Script.Length != 0) ? control.ClientF03Script : "null").Append(',');
			script.Append((control.ClientF04Script.Length != 0) ? control.ClientF04Script : "null").Append(',');
			script.Append((control.ClientF05Script.Length != 0) ? control.ClientF05Script : "null").Append(',');
			script.Append((control.ClientF06Script.Length != 0) ? control.ClientF06Script : "null").Append(',');
			script.Append((control.ClientF07Script.Length != 0) ? control.ClientF07Script : "null").Append(',');
			script.Append((control.ClientF08Script.Length != 0) ? control.ClientF08Script : "null").Append(',');
			script.Append((control.ClientF09Script.Length != 0) ? control.ClientF09Script : "null").Append(',');
			script.Append((control.ClientF10Script.Length != 0) ? control.ClientF10Script : "null").Append(',');
			script.Append((control.ClientF11Script.Length != 0) ? control.ClientF11Script : "null").Append(',');
			script.Append((control.ClientF12Script.Length != 0) ? control.ClientF12Script : "null").Append(");");
			if (control.ClientFocusScript.Length != 0)
			{
				script.Append(control.ClientFocusScript);
				script.Append("(this);");
			}
			writer.AddAttribute("onfocus", script.ToString());
		}

// 管理番号K26528 From
		/// <summary>
		/// 指定したコントロールに対してonblur属性を追加します。
		/// </summary>
		/// <typeparam name="T">
		/// onblurイベントをハンドリングするコントロール。
		/// </typeparam>
		/// <param name="control">
		/// onblur属性を追加するコントロール。
		/// </param>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		internal static void AddOnBlurScript<T>(T control, HtmlTextWriter writer)
			where T: Control, IBlurHandleable
		{
			if (control.AutoPostBack)
			{
				writer.AddAttribute("postback", "auto");
			}
			if (control.IsRequiredField)
			{
				writer.AddAttribute("required", "required");
			}

			var defaultChangeScript = control is TextBox && control.AutoPostBack
				// textChangedはrunServerChangeEvent（CM_KeyDownScript.js）の実行フラグ
				? "function () { textChanged = true; return true; }"
				: "function () { return true; }"
				;
			var clientChangeScript = !string.IsNullOrEmpty(control.ClientChangeScript)
				? control.ClientChangeScript
				: defaultChangeScript
				;

			var clientBlurScript = !string.IsNullOrEmpty(control.ClientBlurScript)
				? control.ClientBlurScript
				: "function () { return true; }"
				;

			writer.AddAttribute("onblur", new StringBuilder()
				.Append("__customControl.handler.blurHandler(this")
				.Append(", ").Append(clientChangeScript)
				.Append(", ").Append(clientBlurScript)
				.Append(");")
				.ToString()
				);
		}

		/// <summary>
		/// 指定したコントロールに対してonkeydown属性を追加します。
		/// </summary>
		/// <typeparam name="T">
		/// onkeydownイベントをハンドリングするコントロール。
		/// </typeparam>
		/// <param name="control">
		/// onkeydown属性を追加するコントロール。
		/// </param>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		internal static void AddOnKeyDownScript<T>(T control, HtmlTextWriter writer)
			where T: Control, IKeyDownHandleable
		{
			// CM_CustomControl.jsに定義されたキーコードに対応するハンドラと、実行するクライアントスクリプトを対応付けるDictionary
			var handlers = new Dictionary<string, string>();

			// 他のキーコードを受け取るハンドラも同様に実装することができる
			// （IEnterKeyDownHandleableはIKeyDownHandleableを継承している）
			var enterKeyDownHandleable = control as IEnterKeyDownHandleable;
			if (enterKeyDownHandleable != null)
			{
				handlers.Add("enterKeyDownHandler", enterKeyDownHandleable.ClientEnterKeyScript);
			}

			// 他のキーコードを受け取るハンドラが増えた場合でも、onkeydown属性への出力処理は変更不要
			writer.AddAttribute("onkeydown",
				string.Join(string.Empty, handlers
					.Where(handler => !string.IsNullOrEmpty(handler.Value))
					.Select(handler => "__customControl.handler." + handler.Key + "(this, " + handler.Value + ");")
					.ToArray()
					)
				);
		}

		/// <summary>
		/// コントロールの種別を表す属性値を適用します。
		/// </summary>
		/// <param name="webControl">
		/// 適用を行うコントロール。
		/// </param>
		internal static void RegisterControlTypeAttribute(WebControl webControl)
		{
			RegisterControlTypeAttribute(webControl, webControl);
		}

		/// <summary>
		/// コントロールの種別を表す属性値を適用します。
		/// <para>コントロールが別のコントロールに内包されている場合、このメソッドを使用します。</para>
		/// </summary>
		/// <param name="webControl">
		/// 適用を行うコントロール。
		/// </param>
		/// <param name="baseControl">
		/// コントロール種別名の生成元となるコントロール。
		/// </param>
		internal static void RegisterControlTypeAttribute(WebControl webControl, Control baseControl)
		{
			webControl.Attributes.Add(ControlTypeAttribute, baseControl.GetType().Name);
		}

		/// <summary>
		/// コントロールの副種別を表す属性値を適用します。
		/// <para>コントロールが別のコントロールに内包されている場合、このメソッドを使用します。</para>
		/// </summary>
		/// <param name="webControl">
		/// 適用を行うコントロール。
		/// </param>
		/// <param name="subtype">
		/// コントロール種別を表す値。
		/// </param>
		internal static void RegisterControlSubtypeAttribute(WebControl webControl, string subtype)
		{
			webControl.Attributes.Add(ControlSubtypeAttribute, subtype);
		}

		/// <summary>
		/// コントロールの種別を表す属性値を適用します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		/// <param name="control">
		/// 適用を行うコントロール。
		/// </param>
		internal static void AddControlTypeAttribute(HtmlTextWriter writer, Control control)
		{
			writer.AddAttribute(ControlTypeAttribute, control.GetType().Name);
		}

		/// <summary>
		/// コントロールの副種別を表す属性値を適用します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		/// <param name="subtype">
		/// コントロール名
		/// </param>
		internal static void AddControlSubtypeAttribute(HtmlTextWriter writer, string subtype)
		{
			writer.AddAttribute(ControlSubtypeAttribute, subtype);
		}
// 管理番号K26528 To
#if DEBUG
		/// <summary>
		/// デバッグビルドされたAllegroClassLibraryが動作していることを画面に通知します。
		/// </summary>
		/// <param name="control">通知するコントロール。</param>
		public static void AddDebugMark(WebControl control)
		{
			if (!control.Page.ClientScript.IsClientScriptBlockRegistered("__ForDegug"))
			{
//                 control.Page.ClientScript.RegisterClientScriptBlock(control.GetType(), "__ForDegug", "<span style=\"color: #FF0000\">デバッグ用のコントロールを使用してます。<br></span>"); //K24546
                control.Page.ClientScript.RegisterClientScriptBlock(control.GetType(), "__ForDegug", MultiLanguage.Get("CM_AM000417"));
			}
		}
#endif
	}
}
