// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : CustomCheckBox.cs
// 機能名      : チェックボックスカスタムコントロール
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 管理番号 K22156 2008/08/26 1ページ内に複数のCM_KeyDownScript.jsが定義される問題を修正
// 1.6.0 2009/09/30
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/16 UI見直し
// 3.0.0 2018/04/30

using System;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// チェックボックスカスタムコントロール
	/// </summary>
	/// <remarks>
	/// <b>CustomCheckBox</b> は GRANDIT用に Enter キーによるフォーカス移動、ファンクションキーの割当等をサポートします。
	/// </remarks>
	[
	DefaultProperty("Text"),
	DefaultEvent("CheckedChanged"),
	ToolboxData("<{0}:CustomCheckBox runat=server></{0}:CustomCheckBox>")
	]
	public class CustomCheckBox : System.Web.UI.WebControls.CheckBox, IAllegroContorl
// 管理番号K26528 From
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
		/// コントロールがクリックされた時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// <para>メソッドの戻り値がfalseの場合、サーバーへのポストバックは中止されます。</para>
		/// </remarks>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("チェック ボックスがクリックされた時に動作するクライアント スクリプトを指定します。")
		]
		public virtual string ClientClickScript
		{
			get
			{
				object o = ViewState["ClientClickScript"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["ClientClickScript"] = value;}
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

		#region Override Methods
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
		protected override void Render(System.Web.UI.HtmlTextWriter writer)
		{
			// <span> タグの生成
			Label baseLabel = new Label();
			if (ToolTip.Length != 0)
			{
				writer.AddAttribute(HtmlTextWriterAttribute.Title, ToolTip);
			}
// 管理番号K26528 From
//			if (CssClass.Length != 0)
//			{
//				writer.AddAttribute(HtmlTextWriterAttribute.Class, CssClass);
//			}
			AllegroControl.RegisterControlTypeAttribute(baseLabel, this);
			// Styleプロパティをコンテナ要素に出力する
			baseLabel.Style.Value = this.Style.Value;
// 管理番号K26528 To
			baseLabel.ApplyStyle(ControlStyle);
			baseLabel.RenderBeginTag(writer);

			// <input type="checkbox" /> タグの生成
			writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
			writer.AddAttribute(HtmlTextWriterAttribute.Type, "checkbox");
			writer.AddAttribute(HtmlTextWriterAttribute.Name, UniqueID);
			if (Checked)
			{
				writer.AddAttribute(HtmlTextWriterAttribute.Checked, "checked");
			}
// 管理番号K26528 From
//			if (!Enabled)
			// 祖先コントロールを含めた有効状態を考慮する
			if (!IsEnabled)
// 管理番号K26528 To
			{
				writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
			}
			if (ClientClickScript.Length != 0)
			{
				StringBuilder script = new StringBuilder(64);
				if (AutoPostBack)
				{
					script.Append("if(").Append(ClientClickScript).Append("(this))").Append(Page.ClientScript.GetPostBackEventReference(this, string.Empty)).Append(';');
				}
				else
				{
					script.Append(ClientClickScript).Append("(this);");
				}
// 管理番号K26528 From
//				writer.AddAttribute(HtmlTextWriterAttribute.Onclick, script.ToString());
				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, script.ToString());
// 管理番号K26528 To
			}
			else if (AutoPostBack)
			{
// 管理番号K26528 From
//				writer.AddAttribute(HtmlTextWriterAttribute.Onclick, Page.ClientScript.GetPostBackEventReference(this, string.Empty) + ";");
				writer.AddAttribute(HtmlTextWriterAttribute.Onchange, Page.ClientScript.GetPostBackEventReference(this, string.Empty) + ";");
// 管理番号K26528 To
			}
// 管理番号K26528 From
//			if (ClientEnterKeyScript.Length != 0)
//			{
//				writer.AddAttribute("onkeydown", new StringBuilder("if(event.keyCode==13)", 32).Append(ClientEnterKeyScript).Append("(this);").ToString());
//			}
			AllegroControl.AddOnKeyDownScript(this, writer);
// 管理番号K26528 To
			if (AccessKey.Length != 0)
			{
				writer.AddAttribute(HtmlTextWriterAttribute.Accesskey, AccessKey);
			}
			if (TabIndex != 0)
			{
				writer.AddAttribute(HtmlTextWriterAttribute.Tabindex, TabIndex.ToString());
			}
			AllegroControl.AddOnfocusScript(this, writer);
			if (AppendedIDPart.Length != 0)
			{
				writer.AddAttribute("appendedidpart", AppendedIDPart);
			}
// 管理番号K26528 From
//			if (!AutoPostBack)
//			{
//				writer.AddAttribute("language", "javascript");
//			}
// 管理番号K26528 To
			writer.RenderBeginTag(HtmlTextWriterTag.Input);
			writer.RenderEndTag();

			// <label> タグの生成
			if (Text.Length != 0)
			{
				writer.AddAttribute(HtmlTextWriterAttribute.For, ClientID);
// 管理番号K26528 From
//				if (!Enabled)
//				{
//					writer.AddAttribute(HtmlTextWriterAttribute.Disabled, "disabled");
//				}
// 管理番号K26528 To
				writer.RenderBeginTag(HtmlTextWriterTag.Label);
				writer.Write(Text);
				writer.RenderEndTag();
			}
			writer.RenderEndTag();
		}
		#endregion
	}
}
