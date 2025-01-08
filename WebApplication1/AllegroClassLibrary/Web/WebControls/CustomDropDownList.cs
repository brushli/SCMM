// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : CustomDropDownList.cs
// 機能名      : ドロップダウンリストカスタムコントロール
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 管理番号 K22156 2008/08/26 1ページ内に複数のCM_KeyDownScript.jsが定義される問題を修正
// 管理番号 K22159 2008/08/26 onChangeイベントが2つ定義されてしまう問題を修正。
// 管理番号 K22192 2008/09/04 cashedSelectedIndexとcashedSelectedValueの不整合によるDataBind実行エラーの修正
// 管理番号 K22297 2008/10/27 ドロップダウンリストの値を変更せずにコントロール移動するとポストバックが発生する不具合対応
// 管理番号 B22713 2009/04/21  DropDownListのイベントと別オブジェクトのイベントが重なった際、画面が白くなり応答がなくなる
// 1.6.0 2009/09/30
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/17 UI見直し
// 3.0.0 2018/04/30

using System;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// ドロップダウンリストカスタムコントロール
	/// </summary>
	/// <remarks>
	/// <b>CustomDropDownList</b> は GRANDIT用に Enter キーによるフォーカス移動、ファンクションキーの割当等をサポートします。
	/// </remarks>
	[
	DefaultEvent("SelectedIndexChanged"),
	ToolboxData("<{0}:CustomDropDownList runat=server></{0}:CustomDropDownList>")
	]
	public class CustomDropDownList : System.Web.UI.WebControls.ListControl, IAllegroContorl, System.Web.UI.IPostBackDataHandler
// 管理番号K26528 From
		, IBlurHandleable
// 管理番号K26528 To
	{
		#region Instance Constructor
		/// <summary>
		/// ドロップダウンリストカスタムコントロールのコンストラクタです。
		/// </summary>
		public CustomDropDownList()
        {
//            SelectedIndex = 0;
            SelectedIndex = -1;
        }
		#endregion

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
		/// コントロールの境界線の色。常に<see cref="Color.Empty"/>を返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never),
		]
		public override System.Drawing.Color BorderColor
		{
			get {return System.Drawing.Color.Empty;}
		}

		/// <summary>
		/// コントロールの境界線スタイル。常に<see cref="System.Web.UI.WebControls.BorderStyle.NotSet"/>を返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never),
		]
		public override BorderStyle BorderStyle
		{
			get {return BorderStyle.NotSet;}
		}

		/// <summary>
		/// コントロールの境界線の幅。常に<see cref="Unit.Empty"/>を返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never),
		]
		public override Unit BorderWidth
		{
			get {return Unit.Empty;}
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
		/// コントロールの選択項目が変更された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("ドロップダウンリストの選択項目が変更された時に動作するクライアント スクリプトを指定します。")
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
		/// コントロールの高さ。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never),
		]
		public override Unit Height
		{
			get {return base.Height;}
			set {base.Height = value;}
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
		/// マウスポインタがコントロールの上を移動したときに表示される文字列。常に<see cref="string.Empty"/>を返します。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never),
		]
		public override string ToolTip
		{
			get {return string.Empty;}
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
		/// リストコントロールの選択されている項目の値。または、選択する項目の値。
		/// </summary>
		/// <remarks>
		/// 項目が選択されていない場合は空の文字列（""）が返されます。
		/// また、値を設定する時、指定した値がリストコントロール内にない場合は、最初の項目が選択されます。
		/// </remarks>
		public override string SelectedValue
		{
			get {return base.SelectedValue;}
			set
			{
				try
				{
					base.SelectedValue = value;
				}
#if DEBUG
				catch (ArgumentOutOfRangeException ex)
				{
					if (Page.ClientScript.IsClientScriptBlockRegistered("__DdlError_" + ID))
					{
						StringBuilder errorString = new StringBuilder(128);
						errorString.Append("<span style=\"color:red\">DropDownList: ");
						errorString.Append(ID);
// 						errorString.Append(" にリストにない値 “"); //K24546
						errorString.Append(MultiLanguage.Get("CM_AM000021"));
						errorString.Append(ex.ParamName);
// 						errorString.Append("” が設定されました。</span><br>"); //K24546
						errorString.Append(MultiLanguage.Get("CM_AM000408"));
                        Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "__DdlError_" + ID, errorString.ToString());
					}

                    if (Items.Count == 0)
                    {
                        SelectedIndex = -1;
                    }
                    else
                    {
                        SelectedIndex = 0;
                    }
				}
#else
                catch (ArgumentOutOfRangeException)
				{
                    if (Items.Count == 0)
                    {
                        SelectedIndex = -1;
                    }
                    else
                    {
                        SelectedIndex = 0;
                    }
                }
#endif
			}
		}

		/// <summary>
		/// 選択されている項目のインデックス。
		/// </summary>
        public override int SelectedIndex
		{
			get
			{
				return base.SelectedIndex;
			}
			set
			{
				if (Items.Count == 0)
				{
					base.SelectedIndex = -1;
				}
				else
				{
					base.SelectedIndex = value;
				}
			}
		}

		/// <summary>
		/// コントロール上でEnterキーが押された時のフォーカスの移動先として設定するコントロールの<see cref="Control.ClientID"/>。
		/// </summary>
		string IAllegroContorl.InnerNextControlID
		{
			get {return SearchInMyParent ? AppendedIDPart + NextControlID : NextControlID;}
		}
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
// 管理番号K26528 From
			AllegroControl.RegisterControlTypeAttribute(this);
// 管理番号K26528 To
			CssClass = (Enabled ? ((IsRequiredField && SelectedValue.Length == 0) ? "input_bg_2" : "input_bg_1") : "input_bg_3");

//			if (!Enabled)
//			{
//				BackColor = Color.Empty;
//				writer.AddStyleAttribute(HtmlTextWriterStyle.BackgroundColor, "buttonface");
//			}
			writer.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID);
// 管理番号K22159 From
            bool orgAutoPostBack = AutoPostBack;
            AutoPostBack = false;
            base.AddAttributesToRender(writer);
            AutoPostBack = orgAutoPostBack;
// 管理番号K22159 To
// 管理番号K26528 From
//            if (ClientChangeScript.Length != 0)
//			{
//// 管理番号 B22713 From
////				StringBuilder script = new StringBuilder(64);
//				StringBuilder script = new StringBuilder(128);
//                script.Append("if(__postbackFlg==0){");
//// 管理番号 B22713 To
//				script.Append(ClientChangeScript).Append("(this)");
//				script.Append(" && validateText(this,");
//				script.Append(IsRequiredField ? "true," : "false,");
//// 管理番号 B22713 From
////				script.Append(" 0)");
//				script.Append(" 0)}");
//// 管理番号 B22713 To
//				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, script.ToString());
//			}
//			else
//			{
//				StringBuilder script = new StringBuilder(64);
//				script.Append("validateText(this,");
//				script.Append(IsRequiredField ? "true," : "false,");
//				script.Append(" 0)");
//				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, script.ToString());
//			}
//			if (AutoPostBack)
//			{
//				StringBuilder script = new StringBuilder(64);
//				script.Append("if(changedDropDownList(this," + ((ClientBlurScript.Length == 0) ? "null" : ClientBlurScript) + "))" + Page.ClientScript.GetPostBackEventReference(this, string.Empty) + ";");
//				writer.AddAttribute("onblur", script.ToString());
//			}
//			else if (ClientBlurScript.Length != 0)
//			{
//				writer.AddAttribute("onblur", new StringBuilder(ClientBlurScript).Append("(this)").ToString());
//			}
			AllegroControl.AddOnBlurScript(this, writer);
// 管理番号K26528 To
			AllegroControl.AddOnfocusScript(this, writer);
			if (AppendedIDPart.Length != 0)
			{
				writer.AddAttribute("appendedidpart", AppendedIDPart);
			}
// 管理番号K26528 From
//			writer.AddAttribute("language", "javascript");
// 管理番号K26528 To
		}

		/// <summary>
		/// <see cref="CustomDropDownList"/>にデータ ソースをバインドします。
		/// </summary>
		public override void DataBind()
		{
			try
			{
// 管理番号K22192 From
				int orgSelectedIndex = SelectedIndex;
				SelectedIndex = -1;                       //キャッシュ不整合回避
// 管理番号K22192 To
				base.DataBind();
// 管理番号K22192 From
				SelectedIndex = orgSelectedIndex;
// 管理番号K22192 To
			}
			catch (ArgumentOutOfRangeException)
			{
				SelectedIndex = -1;
			}

			if (Items.Count != 0 && SelectedIndex == -1)
			{
				SelectedIndex = 0;
			}

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
//			if (!Page.ClientScript.IsClientScriptBlockRegistered(Page.GetType(),"AllegroControl"))
//			{
//                //Page.ClientScript.RegisterClientScriptBlock(this.GetType(), "AllegroControl", AllegroControl.OnKeyDownScript);
//                Page.ClientScript.RegisterClientScriptBlock(Page.GetType(), "AllegroControl", AllegroControl.OnKeyDownScript);
//			}
//// 管理番号K22156 To
// 管理番号K26528 To
			base.OnPreRender (e);
//            if (SelectedIndex == -1)
//            {
//                SelectedIndex = 0;
//            }
// 管理番号K22297 From
            if (SelectedIndex == -1 && Items.Count > 0)
            {
                SelectedIndex = 0;
            }
// 管理番号K22297 To
// 管理番号K26528 From
//            if (AutoPostBack)
//			{
//				Page.ClientScript.RegisterHiddenField("__" + ClientID + "_VALUE", SelectedValue);
//			}
// 管理番号K26528 To
#if DEBUG
			AllegroControl.AddDebugMark(this);
#endif
		}

		/// <summary>
		/// コントロールの内容を出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
			foreach (ListItem item in Items)
			{
				// <option> タグの生成
				writer.Write("<option value=\"");
				writer.Write(HttpUtility.HtmlEncode(item.Value));
				writer.Write(item.Selected ? "\" selected=\"selected\">" : "\">");
				writer.Write(HttpUtility.HtmlEncode(item.Text));
				writer.WriteLine("</option>");
			}
		}
		#endregion

		#region Explicit Interface Implementations
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
			bool isChanged = false;
			string postedValue = postCollection[postDataKey];
			foreach (ListItem item in Items)
			{
				if (item.Selected)
				{
					if (!postedValue.Equals(item.Value))
					{
						item.Selected = false;
						isChanged = true;
					}
				}
				else
				{
					if (postedValue.Equals(item.Value))
					{
						item.Selected = true;
						isChanged = true;
					}
				}

			}
			return isChanged;
		}

		/// <summary>
		/// 変更イベントを発生させます。
		/// </summary>
		void IPostBackDataHandler.RaisePostDataChangedEvent()
		{
			OnSelectedIndexChanged(EventArgs.Empty);
		}
		#endregion
	}
}
