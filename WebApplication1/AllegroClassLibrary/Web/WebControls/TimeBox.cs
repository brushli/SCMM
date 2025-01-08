﻿// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : TimeBox.cs
// 機能名      : 時刻入力用カスタムコントロール
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K20525 2007/04/23 IE7/Vista対応
// 1.5.1 2007/06/30
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 管理番号 K22156 2008/08/26 1ページ内に複数のCM_KeyDownScript.jsが定義される問題を修正
// 1.6.0 2009/09/30
// 管理番号 B24094 2012/04/09 多重リクエスト抑止対応
// 2.0.0 2012/10/31
// 2.2.0 2014/10/31
// 管理番号 K25901 2015/11/25 日付及び数値コントロールの入力補助機能追加対応
// 管理番号 K25903 2015/12/10 画面項目コピー＆ペースト機能追加対応
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/13 UI見直し
// 3.0.0 2018/04/30

using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// 時刻入力用カスタムコントロール
	/// </summary>
	[
	ToolboxData("<{0}:TimeBox runat=server></{0}:TimeBox>")
	]
	public class TimeBox : System.Web.UI.WebControls.TextBox, IAllegroContorl
// 管理番号K26528 From
		, IBlurHandleable
// 管理番号K26528 To
	{
// 管理番号K26528 From
//		#region Instance Constructor
//		public TimeBox()
//		{
//			base.Width = Unit.Pixel(55);
//		}
//		#endregion
// 管理番号K26528 To

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
		/// テキスト入力時のIMEの状態（CSSにおけるime-modeに対応します）。常に<see cref="Infocom.Allegro.Web.WebControls.ImeMode.Disabled"/>を返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		public virtual ImeMode ImeMode
		{
			get {return ImeMode.Disabled;}
		}

		/// <summary>
		/// テキストボックスに手動で入力できる最大文字数。常に5を返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		public override int MaxLength
		{
			get
			{
#if DEBUG
				return 0;
#else
				return 5;
#endif
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
		/// テキストボックスコントロールの動作モード。常に<see cref="TextBoxMode.SingleLine"/>を返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		public override TextBoxMode TextMode
		{
			get {return TextBoxMode.SingleLine;}
		}

		/// <summary>
		/// テキストの大文字表示・小文字表示（CSSにおけるtext-transformに対応します）。
		/// 常に<see cref="Infocom.Allegro.Web.WebControls.TextTransform.NotSet"/>を返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		public virtual TextTransform TextTransform
		{
			get {return TextTransform.NotSet;}
		}

		/// <summary>
		/// コントロールの幅。常に55ピクセルを返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		public override Unit Width
		{
			get {return Unit.Pixel(55);}
		}
		#endregion

		#region Methods
// 管理番号K25901 From
		/// <summary>
		/// スタートアップスクリプトを登録します。
		/// </summary>
		private void RegisterStartUpScript()
		{
			string key = ClientID + "registerKeyControl";
			string script = GetStartUpScript();
// 管理番号K26528 From
//			Page.ClientScript.RegisterStartupScript(this.GetType(), key , script, true);
			((PageBase)Page).ControlStartupScript.RegisterScript(this.GetType(), key , script);
// 管理番号K26528 To
		}

		/// <summary>
		/// コントロールを含む<see cref="Page"/>が表示された時に実行されるクライアントスクリプト。
		/// </summary>
		/// <returns>
		/// 実行するクライアントスクリプト。
		/// </returns>
		/// <remarks>
		/// このクラスの派生クラスを作成する時にコントロールに影響する起動スクリプトを登録する場合、
		/// ClientScriptManager.RegisterStartupScriptを使用するのではなくこのメソッドをオーバーライドすることで、
		/// このコントロールが意図しない順序でクライアントスクリプトが登録されることを防ぐことができます。
		/// 派生クラスでオーバーライドする場合は、基本クラスの本メソッドを呼び出してください。
		/// </remarks>
		protected virtual string GetStartUpScript()
		{
			// コントロールにキーボード制御用イベントの追加
			return "registerBoxKeyDownEvent(\"" + ClientID + "\", addTimeBoxOnKeyDown);";

		}
// 管理番号K25901 To
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

			base.AddAttributesToRender(writer);

			writer.AddStyleAttribute("ime-mode", "inactive");
// 管理番号K26528 From
////管理番号 K25901 From
//				StringBuilder script = new StringBuilder();
//				script.Append("if(this.getAttribute('data-skipOnchange')){return true;} ");
////管理番号 K25901 To
//#if DEBUG
//			if (ClientChangeScript.Length != 0)
//			{
////管理番号 K25901 From
////				StringBuilder changeScript = new StringBuilder(64);
////管理番号 K25901 To
//				if (AutoPostBack)
//				{
////管理番号 K25901 From
////					changeScript.Append("if(").Append(ClientChangeScript).Append("(this))").Append(Page.ClientScript.GetPostBackEventReference(this, string.Empty)).Append(';');
//					script.Append("if(").Append(ClientChangeScript).Append("(this))").Append(Page.ClientScript.GetPostBackEventReference(this, string.Empty)).Append(';');
////管理番号 K25901 To
//				}
//				else
//				{
////管理番号 K25901 From
////					changeScript.Append(ClientChangeScript).Append("(this)");
//					script.Append(ClientChangeScript).Append("(this)");
////管理番号 K25901 To
//				}
////管理番号 K25901 From
////				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, changeScript.ToString());
////管理番号 K25901 To
//			}
//			else if (AutoPostBack)
//			{
////管理番号 K25901 From
////				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, Page.ClientScript.GetPostBackEventReference(this, string.Empty));
//				script.Append(Page.ClientScript.GetPostBackEventReference(this, string.Empty));
////管理番号 K25901 To
//			}
//#else
//			if (ClientChangeScript.Length != 0)
//			{
////管理番号 K25901 From
////				StringBuilder script = new StringBuilder(64);
////管理番号 K25901 To
////管理番号K20525 From
//				script.Append("validateChecked=true;");
////管理番号K20525 To
//				if (AutoPostBack)
//				{
//					script.Append("if(");
//					script.Append(ClientChangeScript);
////管理番号 B24094 From
////					script.Append(IsRequiredField ? "(this) && validateTime(this,true)&&(!mouseOnButton||pressReturnKey)){allowPostBack=false;" : "(this) && validateTime(this,false)&&(!mouseOnButton||pressReturnKey)){allowPostBack=false;");
//					script.Append(IsRequiredField ? "(this) && validateTime(this,true)&&(!mouseOnButton||pressReturnKey)){" : "(this) && validateTime(this,false)&&(!mouseOnButton||pressReturnKey)){");
////管理番号 B24094 To
//					script.Append(Page.ClientScript.GetPostBackEventReference(this, string.Empty)).Append(";}");
//				}
//				else
//				{
//					script.Append(ClientChangeScript);
//					script.Append(IsRequiredField ? "(this);validateTime(this,true);" : "(this);validateTime(this,false);");
//				}
////管理番号 K25901 From
////				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, script.ToString());
////管理番号 K25901 To
//			}
//			else if (AutoPostBack)
//			{
////管理番号 K25901 From
//////管理番号 B24094 From
////////管理番号K20525 From
////////				StringBuilder script = new StringBuilder(IsRequiredField ? "textChanged=true;if(validateTime(this,true)&&(!mouseOnButton||pressReturnKey)){allowPostBack=false;" : "textChanged=true;if(validateTime(this,false)&&(!mouseOnButton||pressReturnKey)){allowPostBack=false;", 64);
//////				StringBuilder script = new StringBuilder(IsRequiredField ? "textChanged=true;validateChecked=true;if(validateTime(this,true)&&(!mouseOnButton||pressReturnKey)){allowPostBack=false;" : "textChanged=true;validateChecked=true;if(validateTime(this,false)&&(!mouseOnButton||pressReturnKey)){allowPostBack=false;", 64);
////////管理番号K20525 To
////				StringBuilder script = new StringBuilder(IsRequiredField ? "textChanged=true;validateChecked=true;if(validateTime(this,true)&&(!mouseOnButton||pressReturnKey)){" : "textChanged=true;validateChecked=true;if(validateTime(this,false)&&(!mouseOnButton||pressReturnKey)){", 64);
//////管理番号 B24094 To
//				script.Append(IsRequiredField ? "textChanged=true;validateChecked=true;if(validateTime(this,true)&&(!mouseOnButton||pressReturnKey)){" : "textChanged=true;validateChecked=true;if(validateTime(this,false)&&(!mouseOnButton||pressReturnKey)){");
////管理番号 K25901 To
//				script.Append(Page.ClientScript.GetPostBackEventReference(this, string.Empty));
//				script.Append(";}");
////管理番号 K25901 From
////				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, script.ToString());
////管理番号 K25901 To
//			}
//			else
//			{
////管理番号 K25901 From
//////管理番号K20525 From
//////				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, IsRequiredField ? "validateTime(this,true)" : "validateTime(this,false)");
////				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, IsRequiredField ? "validateChecked=true;validateTime(this,true)" : "validateChecked=true;validateTime(this,false)");
//////管理番号K20525 To
//				script.Append(IsRequiredField ? "validateChecked=true;validateTime(this,true)" : "validateChecked=true;validateTime(this,false)");
////管理番号 K25901 To
//			}
//#endif
////管理番号 K25901 From
//			writer.AddAttribute(HtmlTextWriterAttribute.Onchange, script.ToString());
////管理番号 K25901 To
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
//			script2.Append(IsRequiredField ? "validateTimeOnBlur(this,true);" : "validateTimeOnBlur(this,false);");
//			if (ClientBlurScript.Length != 0)
//			{
//				script2.Append(ClientBlurScript).Append("(this);");
//			}
//			writer.AddAttribute("onblur",script2.ToString());
////管理番号K20525 To
			AllegroControl.AddOnBlurScript(this, writer);
// 管理番号K26528 To
			AllegroControl.AddOnfocusScript(this, writer);
			if (AppendedIDPart.Length != 0)
			{
				writer.AddAttribute("appendedidpart", AppendedIDPart);
			}
// 管理番号K26528 From
//			writer.AddAttribute("onkeypress", "pressKeyTimeBox(this)");
			writer.AddAttribute("onkeypress", "pressKeyTimeBox(this);");
			// スペルチェックの抑制
			writer.AddAttribute("spellcheck", "false");
			// オートコンプリートの抑制
			writer.AddAttribute("autocomplete", "off");
// 管理番号K26528 To
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
// 管理番号K25901 From
			RegisterStartUpScript();
// 管理番号K25901 To
			base.OnPreRender(e);

#if DEBUG
			AllegroControl.AddDebugMark(this);
#endif
		}

// 管理番号K26528 From
//// 管理番号K25903 From
//		/// <summary>
//		/// コントロールを出力します。
//		/// </summary>
//		/// <param name="writer">
//		/// 出力先の<see cref="HtmlTextWriter"/>。
//		/// </param>
//		protected override void Render(HtmlTextWriter writer)
//		{
//			// 非活性状態でもマウスイベントを使用するためにspanで囲む
//			string spanId = this.ClientID + "_span";
//			writer.AddAttribute(HtmlTextWriterAttribute.Id, spanId);
//			writer.AddAttribute("onmouseenter", "changeTemporaryReadOnly(\"" + this.ClientID + "\")");
//			writer.AddAttribute("onmouseleave", "restoreTemporaryReadOnly(\"" + this.ClientID + "\")");
//			writer.RenderBeginTag(HtmlTextWriterTag.Span);
//			base.Render(writer);
//			writer.RenderEndTag();
//		}
//// 管理番号K25903 To
// 管理番号K26528 To
		#endregion
	}
}
