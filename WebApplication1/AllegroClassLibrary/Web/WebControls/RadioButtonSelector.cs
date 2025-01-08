// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : RadioButtonSelector.cs
// 機能名      : ラジオボタン連動タブカスタムコントロール
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/16 UI見直し
// 3.0.0 2018/04/30

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Text;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// ラジオボタン型タブ表示用カスタムコントロール
	/// </summary>
	[ToolboxData("<{0}:RadioButtonSelector runat=server></{0}:RadioButtonSelector>")]
	public class RadioButtonSelector : TabSelector, IAllegroContorl
	{
		#region Properties
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
		/// 常にfalseを返します。値のセットは無視されます。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(false),
		Description("ページのモードにかかわらず常にコントロールを有効にします。")
		]
		bool IAllegroContorl.DisregardsMode
		{
			get {return false;}
			set {}
		}

		/// <summary>
		/// コントロールを有効にするかどうか。常にtrueを返します。値のセットは無視されます。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(true),
		Description("有効になったコントロールの状態です。")
		]
		bool IAllegroContorl.Enabled
		{
			get {return true;}
			set {}
		}

		/// <summary>
		/// コントロール上でEnterキーが押された時のフォーカスの移動先として設定するコントロールの<see cref="Control.ClientID"/>。
		/// </summary>
		string IAllegroContorl.InnerNextControlID
		{
			get {return NextControlID;}
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
		/// リストコントロールの選択されている項目の値。
		/// </summary>
		public virtual string SelectedValue
		{
			get
			{
				if (SelectedItem is RadioButtonItem)
				{
					return ((RadioButtonItem) SelectedItem).Value;
				}
				else
				{
// 					throw new NotSupportedException("SelectedValue プロパティは SelectedItem が RadioButtonItem の場合しか利用できません。"); //K24546
					throw new NotSupportedException(MultiLanguage.Get("CM_AM000499"));
				}
			}
		}

		/// <summary>
		/// コントロールがクリックされた時に内部で実行されるクライアントスクリプトの関数宣言。
		/// </summary>
		[
		Browsable(false),
		EditorBrowsable(EditorBrowsableState.Never)
		]
		protected override string ClientScriptBlock
		{
			get
			{
// 管理番号K26528 From
//				StringBuilder script = new StringBuilder(
//@"	function change", 384).Append(ClientID).Append(@"Visibility(index) {
//		for (i = 0; i < ").Append(ClientID).Append(@"Pages.length; i++) {
//			").Append(ClientID).Append(@"Pages[i].style.display = (i == index) ? ""block"" : ""none"";
//		}
//		document.all[""").Append(HiddenName).Append(@"""].value = index.toString();
//	}");
//				return script.ToString();
				return new StringBuilder()
					.Append("function change").Append(ClientID).AppendLine("Visibility(index) {")
					.Append("	for (var i = 0; i < ").Append(ClientID).AppendLine(@"Pages.length; i++) {")
					// display属性を初期値かnoneで切り替える
					.Append("		").Append(ClientID).AppendLine("Pages[i].style.display = (i == index) ? '' : 'none';")
					.Append("	}").AppendLine()
					.Append("	document.getElementById('").Append(HiddenName).AppendLine("').value = index;")
					.Append("}").AppendLine()
					.ToString();
// 管理番号K26528 To
			}
		}

		#endregion
		/// <summary>
		/// コントロールのHTML開始タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public override void RenderBeginTag(HtmlTextWriter writer)
		{
// 管理番号K26528 From
			writer.AddAttribute(HtmlTextWriterAttribute.Id, this.ClientID);
			AllegroControl.AddControlTypeAttribute(writer, this);
			writer.RenderBeginTag(HtmlTextWriterTag.Fieldset);
// 管理番号K26528 To
		}

		/// <summary>
		/// コントロールのHTML終了タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public override void RenderEndTag(HtmlTextWriter writer)
		{
// 管理番号K26528 From
			writer.RenderEndTag();
// 管理番号K26528 To
		}
	}

	/// <summary>
	/// ラジオボタン連動タブカスタムコントロールのアイテム。
	/// </summary>
	[ToolboxData("<{0}:RadioButtonItem runat=server></{0}:RadioButtonItem>")]
	public class RadioButtonItem : TabItem
	{
		#region Constructor
		/// <summary>
		/// ラジオボタン連動タブカスタムコントロールのアイテムのコンストラクタです。
		/// </summary>
		public RadioButtonItem() : base(HtmlTextWriterTag.Input)
		{
		}
		#endregion

		#region Properties
		/// <summary>
		/// アイテムに関連付けられた値。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(""),
		Description("")
		]
		public virtual string Value
		{
			get
			{
				object o = ViewState["Value"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["Value"] = value;}
		}
		#endregion

		#region Override Methods
// 管理番号K26528 From
		/// <summary>
		/// <see cref="Control.Init" />イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs" />オブジェクト。
		/// </param>
		protected override void OnInit(EventArgs e)
		{
			base.OnInit(e);
			if (this.ID == null)
			{
				this.ID = this.Selector.ID + "_" + this.Selector.Items.IndexOf(this).ToString();
			}
		}
// 管理番号K26528 To

		/// <summary>
		/// コントロールのHTML開始タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public override void RenderBeginTag(HtmlTextWriter writer)
		{
// 管理番号K26528 From
//			if (ID == null)
//			{
//				writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
//			}
			AllegroControl.AddControlTypeAttribute(writer, this);
// 管理番号K26528 To
			writer.AddAttribute(HtmlTextWriterAttribute.Type, "radio");
			writer.AddAttribute(HtmlTextWriterAttribute.Name, Parent.ClientID);
			writer.AddAttribute(HtmlTextWriterAttribute.Value, Value);
			if (Selected)
			{
				writer.AddAttribute(HtmlTextWriterAttribute.Checked, "checked");
			}
			AllegroControl.AddOnfocusScript((RadioButtonSelector) Selector, writer);
			base.RenderBeginTag(writer);
		}

		/// <summary>
		/// コントロールの内容を出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
		}

		/// <summary>
		/// コントロールのHTML終了タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public override void RenderEndTag(HtmlTextWriter writer)
		{
			base.RenderEndTag (writer);
			writer.AddAttribute(HtmlTextWriterAttribute.For, ClientID);
			writer.RenderBeginTag(HtmlTextWriterTag.Label);
			writer.Write(Text);
			writer.RenderEndTag();
		}

// 管理番号K26528 From
//		/// <summary>
//		/// コントロールのHTML開始タグを出力します。
//		/// </summary>
//		/// <param name="writer">
//		/// 出力先の<see cref="HtmlTextWriter"/>。
//		/// </param>
//		protected override void AddStartupTag(HtmlTextWriter writer)
//		{
//		}
//
//		/// <summary>
//		/// コントロールのHTML終了タグを出力します。
//		/// </summary>
//		/// <param name="writer">
//		/// 出力先の<see cref="HtmlTextWriter"/>。
//		/// </param>
//		protected override void AddEndoffTag(HtmlTextWriter writer)
//		{
//		}
//
//		/// <summary>
//		/// カスタムコントロールに必要なHTML属性やスタイル、イベントハンドラ等を追加します。
//		/// </summary>
//		protected override void AddAttributes()
//		{
//		}
// 管理番号K26528 To
		#endregion
	}
}
