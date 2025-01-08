// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : NubmerBox.cs
// 機能名      : 数値入力カスタムコントロール
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K20525 2007/04/23 IE7/Vista対応
// 1.5.1 2007/06/30
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 管理番号 K22156 2008/08/26 1ページ内に複数のCM_KeyDownScript.jsが定義される問題を修正
// 管理番号K22206 2009/04/23 回収消込入力（マイナス請求一部消込）
// 1.6.0 2009/09/30
// 管理番号 B24094 2012/04/09 多重リクエスト抑止対応
// 2.0.0 2012/10/31
// 2.2.0 2014/10/31
// 管理番号 K25901 2015/11/25 日付及び数値コントロールの入力補助機能追加対応
// 管理番号 K25903 2015/12/10 画面項目コピー＆ペースト機能追加対応
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/14 UI見直し
// 3.0.0 2018/04/30

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// 数値入力カスタムコントロール
	/// </summary>
	[
	ToolboxData("<{0}:NumberBox runat=server></{0}:NumberBox>")
	]
	public class NumberBox : System.Web.UI.WebControls.TextBox, IAllegroContorl
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
		/// 小数を許可する：true、小数を許可しない：false
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(false),
		Description("小数を許容するかを示します。")
		]
		public virtual bool AllowDecimal
		{
			get
			{
				object o = ViewState["AllowDecimal"];
				return (o != null) ? (bool) o : false;
			}
			set {ViewState["AllowDecimal"] = value;}
		}

		/// <summary>
		/// 負数を許可する：true、負数を許可しない：false
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(false),
		Description("負の数を許容するかを示します。")
		]
		public virtual bool AllowNegative
		{
			get
			{
				object o = ViewState["AllowNegative"];
				return (o != null) ? (bool) o : false;
			}
			set {ViewState["AllowNegative"] = value;}
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
		/// テキスト入力時のIMEの状態（CSSにおけるime-modeに対応します）。常に<see cref="Infocom.Allegro.Web.WebControls.ImeMode.Disabled"/>を返します。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(ImeMode.NotSet),
		Description("入力時の IME の設定です。")
		]
		public virtual ImeMode ImeMode
		{
			get {return ImeMode.Disabled;}
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
		/// 入力可能な数値の最大値。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(0),
		Description("許容する最大の数値です。")
		]
		public virtual decimal MaxValue
		{
			get
			{
				object o = ViewState["MaxValue"];
				return (o != null) ? (decimal) o : 0;
			}
			set {ViewState["MaxValue"] = value;}
		}

		/// <summary>
		/// 入力可能な数値の最小値。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(0),
		Description("許容する最小の数値です。")
		]
		public virtual decimal MinValue
		{
			get
			{
				object o = ViewState["MinValue"];
				return (o != null) ? (decimal) o : 0;
			}
			set {ViewState["MinValue"] = value;}
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
		/// 数値全体の最大桁数。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue((byte) 0),
		Description("小数点の左右両側にとることのできる最大有効桁数。")
		]
		public virtual byte Precision
		{
			get
			{
				object o = ViewState["Precision"];
				return (o != null) ? (byte) o : (byte) 0;
			}
			set {ViewState["Precision"] = value;}
		}

		/// <summary>
		/// 数値の小数点以下の最大桁数。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue((byte) 0),
		Description("小数点の右側にとることのできる最大桁数。")
		]
		public virtual byte Scale
		{
			get
			{
				object o = ViewState["Scale"];
				return (o != null) ? (byte) o : (byte) 0;
			}
			set {ViewState["Scale"] = value;}
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
		Category("Behavior"),
		DefaultValue(TextTransform.NotSet),
		Description("テキストの大文字・小文字の指定です。")
		]
		public virtual TextTransform TextTransform
		{
			get {return TextTransform.NotSet;}
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
			return "registerBoxKeyDownEvent(\"" + ClientID + "\", addNumberBoxOnKeyDown);";
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
//管理番号K22206 From
            bool readonlyFlg = false;
            try
            {
                readonlyFlg = Attributes["readonly"].Equals("readonly");
            }
            catch (System.NullReferenceException)
            {
                readonlyFlg = false;
            }
            finally
            {
            }
            if (readonlyFlg)
            {
                CssClass = "input_bg_3";
            }
//管理番号K22206 To
// 管理番号K26528 From
			AllegroControl.RegisterControlTypeAttribute(this);
// 管理番号K26528 To

			if (Width == Unit.Empty)
			{
				Width = Unit.Pixel(MaxLength * 7 + 10);
			}

			base.AddAttributesToRender(writer);

			writer.AddStyleAttribute("ime-mode", "inactive");
// 管理番号K26528 From
////管理番号 K25901 From
//			StringBuilder script = new StringBuilder();
//			script.Append("if(this.getAttribute('data-skipOnchange')){return true;} ");
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
//					script.Append(AllowNegative ? "(this) && validateNumber(this,true," : "(this) && validateNumber(this,false,");
//					script.Append(Precision).Append(',').Append(Scale);
//					script.Append(IsRequiredField ? ",true," : ",false,");
//					script.Append(MinValue).Append(',').Append(MaxValue);
////管理番号 B24094 From
////					script.Append(")&&(!mouseOnButton||pressReturnKey)){allowPostBack=false;");
//					script.Append(")&&(!mouseOnButton||pressReturnKey)){");
////管理番号 B24094 To
//					script.Append(Page.ClientScript.GetPostBackEventReference(this, string.Empty)).Append(";}");
//				}
//				else
//				{
//					script.Append(ClientChangeScript);
//					script.Append(AllowNegative ? "(this);validateNumber(this,true," : "(this);validateNumber(this,false,");
//					script.Append(Precision).Append(',').Append(Scale);
//					script.Append(IsRequiredField ? ",true," : ",false,");
//					script.Append(MinValue).Append(',').Append(MaxValue).Append(");");
//				}
////管理番号 K25901 From
////				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, script.ToString());
////管理番号 K25901 To
//			}
//			else if (AutoPostBack)
//			{
////管理番号 K25901 From
//////管理番号K20525 From
//////				StringBuilder script = new StringBuilder(AllowNegative ? "textChanged=true;if(validateNumber(this,true," : "textChanged=true;if(validateNumber(this,false,", 64);
////				StringBuilder script = new StringBuilder(AllowNegative ? "textChanged=true;validateChecked=true;if(validateNumber(this,true," : "textChanged=true;validateChecked=true;if(validateNumber(this,false,", 64);
//////管理番号K20525 To
//				script.Append(AllowNegative ? "textChanged=true;validateChecked=true;if(validateNumber(this,true," : "textChanged=true;validateChecked=true;if(validateNumber(this,false,");
////管理番号 K25901 To
//				script.Append(Precision).Append(',').Append(Scale);
//				script.Append(IsRequiredField ? ",true," : ",false,");
//				script.Append(MinValue).Append(',').Append(MaxValue);
////管理番号 B24094 From
////				script.Append(")&&(!mouseOnButton||pressReturnKey)){allowPostBack=false;");
//				script.Append(")&&(!mouseOnButton||pressReturnKey)){");
////管理番号 B24094 To
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
//////				StringBuilder script = new StringBuilder(AllowNegative ? "validateNumber(this,true," : "validateNumber(this,false,", 64);
////				StringBuilder script = new StringBuilder(AllowNegative ? "validateChecked=true;validateNumber(this,true," : "validateChecked=true;validateNumber(this,false,", 64);
//////管理番号K20525 To
//				script.Append(AllowNegative ? "validateChecked=true;validateNumber(this,true," : "validateChecked=true;validateNumber(this,false,");
////管理番号 K25901 To
//				script.Append(Precision).Append(',').Append(Scale);
//				script.Append(IsRequiredField ? ",true," : ",false,");
//				script.Append(MinValue).Append(',').Append(MaxValue).Append(')');
////管理番号 K25901 From
////				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, script.ToString());
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
//			script2.Append(AllowNegative ? "validateNumberOnBlur(this,true," : "validateNumberOnBlur(this,false,");
//			script2.Append(Precision).Append(",").Append(Scale);
//			script2.Append(IsRequiredField ? ",true," : ",false,");
//			script2.Append(MinValue).Append(",").Append(MaxValue).Append(");");
//			if(ClientBlurScript.Length != 0)
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
			writer.AddAttribute("allowdecimal", this.AllowDecimal.ToString().ToLower());
			writer.AddAttribute("allownegative", this.AllowNegative.ToString().ToLower());
			writer.AddAttribute("maxvalue", this.MaxValue.ToString("G"));
			writer.AddAttribute("minvalue", this.MinValue.ToString("G"));
			writer.AddAttribute("precision", this.Precision.ToString("G"));
			writer.AddAttribute("scale", this.Scale.ToString("G"));
			AllegroControl.AddOnBlurScript(this, writer);
			AllegroControl.AddOnKeyDownScript(this, writer);
// 管理番号K26528 To
			AllegroControl.AddOnfocusScript(this, writer);
			if (AppendedIDPart.Length != 0)
			{
				writer.AddAttribute("appendedidpart", AppendedIDPart);
			}
// 管理番号K26528 From
//			StringBuilder onKeyPressScript = new StringBuilder(AllowNegative ? "pressKeyNumberBox(this,true," : "pressKeyNumberBox(this,false,", 64);
//			onKeyPressScript.Append(AllowDecimal ? "true)" : "false)");
//			writer.AddAttribute("onkeypress", onKeyPressScript.ToString());
//			writer.AddStyleAttribute("text-align", "right");
			var onKeyPressScript =
				new StringBuilder()
				.Append("pressKeyNumberBox(this")
				.Append(",").Append(AllowNegative.ToString().ToLower())
				.Append(",").Append(AllowDecimal.ToString().ToLower())
				.Append(");")
				.ToString();
			writer.AddAttribute("onkeypress", onKeyPressScript);

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
			bool tmpAllowDecimal = AllowDecimal;
			bool tmpAllowNegative = AllowNegative;
			byte tmpPrecision = Precision;
			byte tmpScale = Scale;

			MaxLength = 0;
			AllowDecimal = true;
			AllowNegative = true;
			Precision = 0;
			Scale = 0;
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
			base.Render(writer);
// 管理番号K26528 To
#if DEBUG
			MaxLength = tmpMaxLength;
			AllowDecimal = tmpAllowDecimal;
			AllowNegative = tmpAllowNegative;
			Precision = tmpPrecision;
			Scale = tmpScale;
#endif

		}
		#endregion
	}
}
