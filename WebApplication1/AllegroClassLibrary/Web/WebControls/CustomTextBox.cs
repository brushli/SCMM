// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : CustomTextBox.cs
// 機能名      : テキストボックスカスタムコントロール
// Version     : 3.1.0
// Last Update : 2020/06/30
// Copyright (c) 2004-2020 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 B03757 2004/10/18 TEXTAREAの最大行数の設定とフォーカス制御の対応
// 管理番号 K20525 2007/04/23 IE7/Vista対応
// 1.5.1 2007/06/30
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 管理番号 K22156 2008/08/26 1ページ内に複数のCM_KeyDownScript.jsが定義される問題を修正
// 管理番号 K22158 2008/08/26 ポストバック時にフォーカスが予期しない項目へ移動してしまう問題を修正
// 1.6.0 2009/09/30
// 管理番号 B24094 2012/04/09 多重リクエスト抑止対応
// 2.0.0 2012/10/31
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25903 2015/12/10 画面項目コピー＆ペースト機能追加対応
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/14 UI見直し
// 3.0.0 2018/04/30
// 3.1.0 2020/06/30
// 管理番号K27241 2020/08/26 開発環境バージョンアップ対応

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// テキストボックスカスタムコントロール
	/// </summary>
	/// <remarks>
	/// <b>CustomRadioButtonList</b> は GRANDIT用に Enter キーによるフォーカス移動、ファンクションキーの割当等をサポートします。
	/// </remarks>
	[
	DefaultProperty("Text"),
	DefaultEvent("TextChanged"),
	ToolboxData("<{0}:CustomTextBox runat=server></{0}:CustomTextBox>")
	]
	public class CustomTextBox : System.Web.UI.WebControls.TextBox, IAllegroContorl, IPostBackDataHandler
// 管理番号K26528 From
		, IBlurHandleable
		, IEnterKeyDownHandleable
// 管理番号K26528 To
	{
		#region Properties
		/// <summary>
		/// <see cref="Control.ClientID"/>のうち、親コントロールによって付加された部分。
		/// </summary>
		/// <remarks>
		/// 同一の<see cref="Control.ID"/>を持つコントロールがひとつの画面に複数生成される場合（たとえば、データグリッドの明細行）、
		/// <see cref="Control.ClientID"/>にはそれぞれのコントロールを区別するために<see cref="Control.NamingContainer"/>の
		/// <see cref="Control.ClientID"/>が付加されます。
		/// <see cref="AppendedIDPart"/>によって、同じ親を持つコントロール（たとえば、データグリッドの同じ明細行のコントロール）の
		/// <see cref="Control.ClientID"/>に共通する部分のみを取得することができます。
		/// </remarks>
		[Browsable(false)]
		public virtual string AppendedIDPart
		{
			get {return (ClientID != null && ID != null) ? ClientID.Substring(0, ClientID.Length - ID.Length) : string.Empty;}
		}

		/// <summary>
		/// コントロールがフォーカスを失った時に、サーバーへのポストバックが自動的に発生するかどうか。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(false),
		Description("テキストが変更された後、自動的にサーバーにポストします。")
		]
		new public virtual bool AutoPostBack
		{
			get
			{
				object o = ViewState["AutoP"];
				return (o != null) ? (bool) o : false;
			}
			set {ViewState["AutoP"] = value;}
		}

		/// <summary>
		/// コントロールがフォーカスを失った時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// <para>
		/// コントロール内のテキストに変更があった場合、
		/// <see cref="ClientBlurScript"/>は<see cref="ClientChangeScript"/>の後に実行されます（ブラウザの仕様）。
		/// </para>
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("テキストボックスがフォーカスを失った時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientBlurScript
		{
			get
			{
				object o = ViewState["ClientBlurScript"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientBlurScript"] = value;}
		}

		/// <summary>
		/// コントロールのテキストが変更され、フォーカスを失った時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// <para><see cref="ClientChangeScript"/>は<see cref="ClientBlurScript"/>の前に実行されます（ブラウザの仕様）。</para>
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("テキストボックスの内容が変更された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientChangeScript
		{
			get
			{
				object o = ViewState["ClientChangeScript"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientChangeScript"] = value;}
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF1キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("F1 キーを押された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientF01Script
		{
			get
			{
				object o = ViewState["ClientF01Script"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientF01Script"] = value;}
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF2キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("F2 キーを押された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientF02Script
		{
			get
			{
				object o = ViewState["ClientF02Script"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientF02Script"] = value;}
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF3キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("F3 キーを押された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientF03Script
		{
			get
			{
				object o = ViewState["ClientF03Script"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientF03Script"] = value;}
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF4キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("F4 キーを押された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientF04Script
		{
			get
			{
				object o = ViewState["ClientF04Script"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientF04Script"] = value;}
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF5キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("F5 キーを押された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientF05Script
		{
			get
			{
				object o = ViewState["ClientF05Script"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientF05Script"] = value;}
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF6キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("F6 キーを押された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientF06Script
		{
			get
			{
				object o = ViewState["ClientF06Script"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientF06Script"] = value;}
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF7キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("F7 キーを押された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientF07Script
		{
			get
			{
				object o = ViewState["ClientF07Script"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientF07Script"] = value;}
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF8キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("F8 キーを押された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientF08Script
		{
			get
			{
				object o = ViewState["ClientF08Script"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientF08Script"] = value;}
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF9キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("F9 キーを押された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientF09Script
		{
			get
			{
				object o = ViewState["ClientF09Script"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientF09Script"] = value;}
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF10キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("F10 キーを押された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientF10Script
		{
			get
			{
				object o = ViewState["ClientF10Script"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientF10Script"] = value;}
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF11キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("F11 キーを押された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientF11Script
		{
			get
			{
				object o = ViewState["ClientF11Script"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientF11Script"] = value;}
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF12キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("F12 キーを押された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientF12Script
		{
			get
			{
				object o = ViewState["ClientF12Script"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientF12Script"] = value;}
		}

		/// <summary>
		/// コントロールがフォーカスを得た時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// <para>
		/// コントロールがフォーカスを得た場合、まず<see cref="ClientF01Script"/>～<see cref="ClientF12Script"/>や
		/// <see cref="NextControlID"/>の設定をセットする処理が実行されます。
		/// <see cref="ClientFocusScript"/>で指定されたクライアントスクリプトはその次に実行されます。
		/// </para>
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("テキストボックスがフォーカスを得た時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientFocusScript
		{
			get
			{
				object o = ViewState["ClientFocusScript"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientFocusScript"] = value;}
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でEnterキーが押された時に動作するクライアントスクリプトを指定します。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("Enter キーを押された時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientEnterKeyScript
		{
			get
			{
				object o = ViewState["ClientEnterKeyScript"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientEnterKeyScript"] = value;}
		}

		/// <summary>
		/// <see cref="InputPageBase.Mode"/>によって画面が参照モードに設定された時に、非活性にする処理を行わないかどうか。
		/// 閉じるボタンなど、参照モードであっても有効にするコントロールにはtrueを設定してください。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(false),
		Description("ページのモードにかかわらず常にコントロールを有効にします。")
		]
		public virtual bool DisregardsMode
		{
			get
			{
				object o = ViewState["DisregardsMode"];
				return (o != null) ? (bool) o : false;
			}
			set {ViewState["DisregardsMode"] = value;}
		}

		/// <summary>
		/// テキスト入力時のIMEの状態（CSSにおけるime-modeに対応します）。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(ImeMode.NotSet),
		Description("入力時の IME の設定です。")
		]
		public virtual ImeMode ImeMode
		{
			get
			{
				object o = ViewState["ImeMode"];
				return (o != null) ? (ImeMode) o : ImeMode.NotSet;
			}
			set
			{
				if (!Enum.IsDefined(typeof(ImeMode), value))
				{
// 					throw new ArgumentOutOfRangeException("value", "指定された引数は、有効な値の範囲内にありません。"); //K24546
					throw new ArgumentOutOfRangeException("value", MultiLanguage.Get("CM_AM001003"));
				}
				ViewState["ImeMode"] = value;
			}
		}

		/// <summary>
		/// コントロール上でEnterキーが押された時のフォーカスの移動先として設定するコントロールの<see cref="Control.ClientID"/>。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("Enter キーを押された時に移動するコントロールの ID です。"),
		TypeConverter(typeof(Infocom.Allegro.ComponentModel.ControlConverter))
		]
		public virtual string NextControlID
		{
			get
			{
				object o = ViewState["NextControlID"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["NextControlID"] = value;}
		}

		/// <summary>
		/// 必須項目：true、非必須項目：false
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(false),
		Description("入力必須項目に指定します。")
		]
		public virtual bool IsRequiredField
		{
			get
			{
				object o = ViewState["IsRequiredField"];
				return (o != null) ? (bool) o : false;
			}
			set {ViewState["IsRequiredField"] = value;}
		}

		/// <summary>
		/// 入力を許可する文字の種類。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(Infocom.Allegro.IF.CheckOption.None),
		Description("入力チェックの方法です。")
		]
		public virtual Infocom.Allegro.IF.CheckOption CheckOption
		{
			get
			{
				object o = ViewState["CheckOption"];
				return (o != null) ? (Infocom.Allegro.IF.CheckOption) o : Infocom.Allegro.IF.CheckOption.None;
			}
			set {ViewState["CheckOption"] = value;}
		}

		/// <summary>
		/// <see cref="NextControlID"/>で指定するコントロールを、自分と同じ親を持つコントロールのみから検索するかどうか。
		/// <para>
		/// trueを設定した場合、<see cref="NextControlID"/>は自分と同じ親を持つコントロール
		/// （たとえば、データグリッドの同じ明細行のコントロール）であることを表します。
		/// </para>
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(false),
		Description("NextControlID で同じ親を持つコントロールのみを指定します。")
		]
		public virtual bool SearchInMyParent
		{
			get
			{
				object o = ViewState["SearchInMyParent"];
				return (o != null) ? (bool) o : false;
			}
			set {ViewState["SearchInMyParent"] = value;}
		}

		/// <summary>
		/// コントロール上でEnterキーが押された時のフォーカスの移動先として設定するコントロールの<see cref="Control.ClientID"/>。
		/// </summary>
		string IAllegroContorl.InnerNextControlID
		{
			get {return SearchInMyParent ? AppendedIDPart + NextControlID : NextControlID;}
		}

		/// <summary>
		/// コントロールのテキストの内容。取得する場合、<see cref="TextTransform"/>の値に応じて大文字もしくは小文字に変換されます。
		/// </summary>
		/// <remarks>
		/// <see cref="CustomTextBox.TextTransform"/>が<see cref="Infocom.Allegro.Web.WebControls.TextTransform.UpperCase"/>の場合は大文字に変換された値。
		/// <see cref="Infocom.Allegro.Web.WebControls.TextTransform.LowerCase"/>の場合は小文字に変換された値。それ以外の場合は変換を行いません。
		/// </remarks>
		public override string Text
		{
			get
			{
				switch (this.TextTransform)
				{
					case TextTransform.UpperCase:
						return base.Text.ToUpper();
					case TextTransform.LowerCase:
						return base.Text.ToLower();
					default:
						return base.Text;
				}
			}
			set {base.Text = value;}
		}

		/// <summary>
		/// テキストの大文字表示・小文字表示（CSSにおけるtext-transformに対応します）。
		/// </summary>
		/// <remarks>
		/// <see cref="Infocom.Allegro.Web.WebControls.TextTransform.UpperCase"/>もしくは<see cref="Infocom.Allegro.Web.WebControls.TextTransform.LowerCase"/>を設定した場合、
		/// <see cref="Text"/>の値も大文字、小文字に変換されます。
		/// ただし、<see cref="Infocom.Allegro.Web.WebControls.TextTransform.Capitalize"/>を設定した場合、<see cref="Text"/>の値は影響を受けません。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(TextTransform.NotSet),
		Description("テキストの大文字・小文字の指定です。")
		]
		public virtual TextTransform TextTransform
		{
			get
			{
				object o = ViewState["TextTransform"];
				return (o != null) ? (TextTransform) o : TextTransform.NotSet;
			}
			set
			{
				if (!Enum.IsDefined(typeof(TextTransform), value))
				{
// 					throw new ArgumentOutOfRangeException("value", "指定された引数は、有効な値の範囲内にありません。"); //K24546
					throw new ArgumentOutOfRangeException("value", MultiLanguage.Get("CM_AM001003"));
				}
				ViewState["TextTransform"] = value;
			}
		}

		#region 管理番号 B03757
// 管理番号 B03757 From
		/// <summary>
		/// <see cref="TextBox.TextMode"/>が<see cref="TextBoxMode.MultiLine"/>の時に、Enterキーの押下によって入力可能な行数。
		/// このプロパティは<see cref="NextControlID"/>が指定されている場合のみ有効です。
		/// </summary>
		/// <remarks>
		/// 入力されたテキストの行数が<see cref="MaxRowCount"/>の値を超えた場合にEnterキーを押下した場合は
		/// <see cref="NextControlID"/>にフォーカスが移動します。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue((byte) 0),
		Description("複数行のテキストボックスで Enter キーによって入力可能な行の数です。")
		]
		public virtual byte MaxRowCount
		{
			get
			{
				object o = ViewState["MaxRowCount"];
				return (o != null) ? (byte) o : (byte) 0;
			}
			set {ViewState["MaxRowCount"] = value;}
		}
// 管理番号 B03757 To
		#endregion
		#endregion

		#region Override Methods
		/// <summary>
		/// カスタムコントロールに必要なHTML属性やスタイル、イベントハンドラ等を追加します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			if (Enabled && !ReadOnly)
			{
				CssClass = ((IsRequiredField && (Text.Length == 0 || TextMode == TextBoxMode.Password)) ? "input_bg_2" : "input_bg_1");
			}
			else
			{
				CssClass = "input_bg_3";
			}
// 管理番号K26528 From
			AllegroControl.RegisterControlTypeAttribute(this);
// 管理番号K26528 To

			if (Width == Unit.Empty)
			{
				switch (ImeMode)
				{
					case Infocom.Allegro.Web.WebControls.ImeMode.Inactive:
					case Infocom.Allegro.Web.WebControls.ImeMode.Disabled:
						if ((CheckOption == Infocom.Allegro.IF.CheckOption.SingleByte) && (TextTransform == Infocom.Allegro.Web.WebControls.TextTransform.UpperCase) && (MaxLength >= 7))
						{
							Width = Unit.Pixel(MaxLength * 7 + 10);
						}
						else
						{
							Width = Unit.Pixel(MaxLength * 9 + 10);
						}
						break;
					default:
						Width = Unit.Pixel(MaxLength * 12 + 10);
						break;
				}
			}

			base.AddAttributesToRender(writer);

			switch (this.ImeMode)
			{
				case ImeMode.Auto:
					writer.AddStyleAttribute("ime-mode", "auto");
					break;
				case ImeMode.Active:
					writer.AddStyleAttribute("ime-mode", "active");
					break;
				case ImeMode.Inactive:
					writer.AddStyleAttribute("ime-mode", "inactive");
					break;
				case ImeMode.Disabled:
					writer.AddStyleAttribute("ime-mode", "inactive");
					break;
			}
			switch (this.TextTransform)
			{
				case TextTransform.None:
					writer.AddStyleAttribute("text-transform", "none");
					break;
				case TextTransform.Capitalize:
					writer.AddStyleAttribute("text-transform", "capitalize");
					break;
				case TextTransform.UpperCase:
					writer.AddStyleAttribute("text-transform", "uppercase");
					break;
				case TextTransform.LowerCase:
					writer.AddStyleAttribute("text-transform", "lowercase");
					break;
			}
// 管理番号K26528 From
//			if (ClientChangeScript.Length != 0)
//			{
////管理番号K20525 From
////				StringBuilder script = new StringBuilder(64);
//				StringBuilder script = new StringBuilder(128);
//				script.Append("validateChecked=true;");
////管理番号K20525 To
//				if (AutoPostBack)
//				{
//					script.Append("textChanged=true;if(").Append(ClientChangeScript);
//					script.Append("(this) && validateText(this,");
//					script.Append(IsRequiredField ? "true," : "false,");
//					script.Append((int) CheckOption);
////管理番号 B24094 From
////					script.Append(")&&(!mouseOnButton||pressReturnKey)){allowPostBack=false;").Append(Page.ClientScript.GetPostBackEventReference(this, string.Empty)).Append(";}");
//					script.Append(")&&(!mouseOnButton||pressReturnKey)){").Append(Page.ClientScript.GetPostBackEventReference(this, string.Empty)).Append(";}");
////管理番号 B24094 To
//				}
//				else
//				{
//					script.Append(ClientChangeScript);
//					script.Append("(this);validateText(this,");
//					script.Append(IsRequiredField ? "true," : "false,");
//					script.Append((int) CheckOption).Append(");");
//				}
//				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, script.ToString());
//			}
//			else if (AutoPostBack)
//			{
////管理番号K20525 From
////				StringBuilder script = new StringBuilder("textChanged=true;if(validateText(this,", 64);
//				StringBuilder script = new StringBuilder("textChanged=true;validateChecked=true;if(validateText(this,", 64);
////管理番号K20525 To
//				script.Append(IsRequiredField ? "true," : "false,");
////管理番号 B24094 From
////				script.Append((int) CheckOption).Append(")&&(!mouseOnButton||pressReturnKey)){allowPostBack=false;");
//				script.Append((int) CheckOption).Append(")&&(!mouseOnButton||pressReturnKey)){");
////管理番号 B24094 To
//				script.Append(Page.ClientScript.GetPostBackEventReference(this, string.Empty));
//				script.Append(";}");
//				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, script.ToString());
//			}
//			else
//			{
////管理番号K20525 From
////				StringBuilder script = new StringBuilder("validateText(this,", 64);
//				StringBuilder script = new StringBuilder("validateChecked=true;validateText(this,", 64);
////管理番号K20525 To
//				script.Append(IsRequiredField ? "true," : "false,");
//				script.Append((int) CheckOption).Append(")");
//				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, script.ToString());
//			}
////管理番号K20525 From
////			if (ClientBlurScript.Length != 0)
////			{
////				StringBuilder script = new StringBuilder(32);
////				if (IsRequiredField)
////				{
////					script.Append("checkRequired(this);");
////				}
////				script.Append(ClientBlurScript).Append("(this);");
////				writer.AddAttribute("onblur", script.ToString());
////			}
////			else if (IsRequiredField)
////			{
////				writer.AddAttribute("onblur", "checkRequired(this)");
////			}
//			StringBuilder script2 = new StringBuilder(64);
//			script2.Append(IsRequiredField ? "validateTextOnBlur(this,true," : "validateTextOnBlur(this,false,");
//			script2.Append((int) CheckOption).Append(");");
//			if (ClientBlurScript.Length != 0)
//			{
//				script2.Append(ClientBlurScript).Append("(this);");
//			}
//			writer.AddAttribute("onblur",script2.ToString());
////管理番号K20525 To
//			if (ClientEnterKeyScript.Length != 0)
//			{
//				writer.AddAttribute("onkeydown", new StringBuilder("if(event.keyCode==13)", 32).Append(ClientEnterKeyScript).Append("(this);").ToString());
//			}
			// チェック処理に必要なプロパティを属性として出力する
			writer.AddAttribute("checkoption", ((int)this.CheckOption).ToString());
			AllegroControl.AddOnBlurScript(this, writer);
			AllegroControl.AddOnKeyDownScript(this, writer);
// 管理番号K26528 To
			AllegroControl.AddOnfocusScript(this, writer);
			if (AppendedIDPart.Length != 0)
			{
				writer.AddAttribute("appendedidpart", AppendedIDPart);
			}
// 管理番号K26528 From
			// スペルチェックの抑制
			writer.AddAttribute("spellcheck", "false");
			// オートコンプリートの抑制
			writer.AddAttribute("autocomplete", "off");
// 管理番号K26528 To

		#region 管理番号 B03757
// 管理番号 B03757 From
			object maxRowCount = ViewState["MaxRowCount"];
			if (TextMode == System.Web.UI.WebControls.TextBoxMode.MultiLine && maxRowCount != null)
			{
				if ((byte) maxRowCount != 0)
				{
					writer.AddAttribute("maxrowcount", maxRowCount.ToString());
				}
			}
// 管理番号 B03757 To
		#endregion
		}

		/// <summary>
		/// <see cref="Control.PreRender"/>イベントを発生させます。/>
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnPreRender(EventArgs e)
		{
// 管理番号K26528 From
//// 管理番号K22156 From
//            //if (!Page.ClientScript.IsClientScriptBlockRegistered("AllegroControl"))
//            if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(), "AllegroControl"))
//            {
//                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "AllegroControl", AllegroControl.OnKeyDownScript);
//                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "AllegroControl", AllegroControl.OnKeyDownScript);
//            }
//// 管理番号K22156 To
// 管理番号K26528 To
			base.OnPreRender(e);

#if DEBUG
			AllegroControl.AddDebugMark(this);
#endif
		}

		/// <summary>
		/// コントロールを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void Render(HtmlTextWriter writer)
		{
#if DEBUG
			int tmpMaxLength = MaxLength;
			Infocom.Allegro.IF.CheckOption tmpCheckOption = CheckOption;

			MaxLength = 0;
			CheckOption = Infocom.Allegro.IF.CheckOption.None;
#endif
// 管理番号K26528 From
//// 管理番号K25903 From
//			// 非活性状態でもマウスイベントを使用するためにspanで囲む
//			string spanId = this.ClientID + "_span";
//			writer.AddAttribute(HtmlTextWriterAttribute.Id, spanId);
//			writer.AddAttribute("onmouseenter", "changeTemporaryReadOnly(\"" + this.ClientID + "\")");
//			writer.AddAttribute("onmouseleave", "restoreTemporaryReadOnly(\"" + this.ClientID + "\")");
//			writer.RenderBeginTag(HtmlTextWriterTag.Span);
//// 管理番号K25903 To
//			base.Render (writer);
//// 管理番号K25903 From
//			writer.RenderEndTag();
//// 管理番号K25903 To
			// 描画直前に垂直タブを取り除く
			var text = this.Text;
			if (text.StartsWith("\v"))
			{
				this.Text = text.Substring(1);
			}

// 管理番号K27241 From
//			base.Render(writer);
			if (TextMode != TextBoxMode.MultiLine)
			{
				base.Render(writer);
			}
			else
			{
				RenderBeginTag(writer);
				System.Web.HttpUtility.HtmlEncode(Text, writer);
				RenderEndTag(writer);
			}
// 管理番号K27241 To

			// 描画後に参照した場合の値が変わるのは挙動として相応しくないため、描画後に垂直タブを復帰する
			this.Text = text;
// 管理番号K26528 To
#if DEBUG

			MaxLength = tmpMaxLength;
			CheckOption = tmpCheckOption;
#endif
		}
		#endregion

		#region Explicit Interface Implementations
		/// <summary>
		/// 変更イベントを発生させます。
		/// </summary>
		void IPostBackDataHandler.RaisePostDataChangedEvent()
		{
			OnTextChanged(EventArgs.Empty);
		}

		/// <summary>
		/// サーバー コントロールのポストバック データを処理します。
		/// </summary>
		/// <param name="postDataKey">
		/// コントロールのキー識別子。
		/// </param>
		/// <param name="postCollection">
		/// 受信する名前と値すべてのコレクション。
		/// </param>
		/// <returns>
		/// ポストバックの結果、サーバー コントロールの状態が変化する場合：true、それ以外の場合：false。
		/// </returns>
		bool IPostBackDataHandler.LoadPostData(string postDataKey, System.Collections.Specialized.NameValueCollection postCollection)
		{
			if (!Text.Equals(postCollection[postDataKey]))
			{
				Text = postCollection[postDataKey];
				return true;
			}
// 管理番号K26528 From
//// 管理番号K22158 From
////			else if (postDataKey.Equals(postCollection["__EVENTTARGET"]))
//            else if (postDataKey.Equals(changeIDSeparator(postCollection["__EVENTTARGET"])))
//// 管理番号K22158 To
            else if (postDataKey.Equals(postCollection["__EVENTTARGET"]))
// 管理番号K26528 To
			{
				return true;
			}
			return false;
		}
		#endregion
// 管理番号K26528 From
//// 管理番号K22158 From
//        private string changeIDSeparator(string controlID)
//        {
//            if (controlID == null || controlID == string.Empty)
//            {
//                return controlID;
//            }
//            else
//            {
//                return controlID.Replace("$", ":");
//            }
//        }
//// 管理番号K22158 To
// 管理番号K26528 To
	}
}
