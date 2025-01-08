// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : FileUploader.cs
// 機能名      : ファイルアップロードカスタムコントロール
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 管理番号K26528 2017/02/27 UI見直し
// 3.0.0 2018/04/30

using System;
using System.ComponentModel;
using System.Configuration;
using System.Reflection;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Infocom.Allegro.Web.HttpHandler;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// ファイルアップロードカスタムコントロール
	/// </summary>
	[ToolboxData("<{0}:FileUploader runat=server />")]
	public class FileUploader : WebControl, INamingContainer, IAllegroContorl
	{
		/// <summary>
		/// 最大要求サイズ（単位：キロバイト）。
		/// </summary>
		protected static readonly int MaxRequestLength;

		/// <summary>
		/// 入力ストリームのバッファリングの閾値（単位：キロバイト）。
		/// <para>この値を超えるサイズのファイルはディスクにキャッシュされてしまう。</para>
		/// </summary>
		protected static readonly int RequestLengthDiskThreshold;

		/// <summary>
		/// ファイルアップロードカスタムコントロールのコンストラクタです。
		/// </summary>
		public FileUploader() : base(HtmlTextWriterTag.Fieldset)
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// ファイルアップロードカスタムコントロールのコンストラクタです。
		/// </summary>
		static FileUploader()
		{
			var httpRuntimeSection = ConfigurationManager.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
			FileUploader.MaxRequestLength = httpRuntimeSection.MaxRequestLength;
			FileUploader.RequestLengthDiskThreshold = httpRuntimeSection.RequestLengthDiskThreshold;
		}

		/// <summary>
		/// アップロードを中断するためのa要素。
		/// </summary>
		public HtmlAnchor CancelAnchor { get; private set; }

		/// <summary>
		/// ファイル選択ダイアログを表示するためのボタン。
		/// </summary>
		public StyledButton ChooseButton { get; private set; }

		/// <summary>
		/// <see cref="HtmlInputFile"/>との互換性のため。
		/// 通常は<see cref="WebControl.Enabled"/>を使うため、エディタには表示させない。
		/// </summary>
		[Browsable(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public virtual bool Disabled
		{
			get { return !base.Enabled; }
			set { base.Enabled = !value; }
		}

		/// <summary>
		/// クライアントからアップロードされたファイル名やファイルサイズを表示する領域。
		/// </summary>
		public EncodeLabel FileNameLabel { get; private set; }

		/// <summary>
		/// ファイルをアップロードするためのinput要素。
		/// </summary>
		public HtmlInputFile InputFile { get; private set; }

		/// <summary>
		/// クライアントからアップロードされたファイル。
		/// ファイルがアップロードされていない場合は、空のインスタンス。
		/// </summary>
		public HttpPostedFile PostedFile
		{
			get
			{
				var requestedFile = this.InputFile.PostedFile;
				if (requestedFile != null && !string.IsNullOrEmpty(requestedFile.FileName))
				{
					return requestedFile;
				}
				return this.Page.Session[this.SessionKey] as HttpPostedFile ?? FileUploader.CreateEmptyHttpPostedFile();
			}
		}

		/// <summary>
		/// アップロード状況をクライアントに表示するためのprogress要素。
		/// </summary>
		public HtmlGenericControl ProgressBar { get; private set; }

		/// <summary>
		/// クライアントからアップロードされたファイルのパス。
		/// </summary>
		public virtual string Value
		{
			get { return this.PostedFile.FileName; }
		}

		/// <summary>
		/// 非同期でアップロードされたファイルにアクセスするためのセッションキー。
		/// </summary>
		private string SessionKey
		{
			get { return FileUploadHandler.CreateSessionKey(this); }
		}

		#region IAllegroControl
		/// <summary>
		/// コントロールにフォーカスがある状態でF1キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		public string ClientF01Script
		{
			get { return this.ChooseButton.ClientF01Script; }
			set { this.ChooseButton.ClientF01Script = value; }
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF2キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		public string ClientF02Script
		{
			get { return this.ChooseButton.ClientF02Script; }
			set { this.ChooseButton.ClientF02Script = value; }
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF3キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		public string ClientF03Script
		{
			get { return this.ChooseButton.ClientF03Script; }
			set { this.ChooseButton.ClientF03Script = value; }
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF4キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		public string ClientF04Script
		{
			get { return this.ChooseButton.ClientF04Script; }
			set { this.ChooseButton.ClientF04Script = value; }
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF5キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		public string ClientF05Script
		{
			get { return this.ChooseButton.ClientF05Script; }
			set { this.ChooseButton.ClientF05Script = value; }
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF6キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		public string ClientF06Script
		{
			get { return this.ChooseButton.ClientF06Script; }
			set { this.ChooseButton.ClientF06Script = value; }
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF7キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		public string ClientF07Script
		{
			get { return this.ChooseButton.ClientF07Script; }
			set { this.ChooseButton.ClientF07Script = value; }
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF8キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		public string ClientF08Script
		{
			get { return this.ChooseButton.ClientF08Script; }
			set { this.ChooseButton.ClientF08Script = value; }
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF9キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		public string ClientF09Script
		{
			get { return this.ChooseButton.ClientF09Script; }
			set { this.ChooseButton.ClientF09Script = value; }
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF10キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		public string ClientF10Script
		{
			get { return this.ChooseButton.ClientF10Script; }
			set { this.ChooseButton.ClientF10Script = value; }
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF11キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		public string ClientF11Script
		{
			get { return this.ChooseButton.ClientF11Script; }
			set { this.ChooseButton.ClientF11Script = value; }
		}

		/// <summary>
		/// コントロールにフォーカスがある状態でF12キーが押された時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// </remarks>
		public string ClientF12Script
		{
			get { return this.ChooseButton.ClientF12Script; }
			set { this.ChooseButton.ClientF12Script = value; }
		}

		/// <summary>
		/// コントロールがフォーカスを得た時に動作するクライアントスクリプト。
		/// クライアントスクリプトには引数を1つ取るメソッドの名前を設定してください。
		/// </summary>
		/// <remarks>
		/// メソッドの引数には呼び出し元のHTMLInputElementオブジェクトが渡されます。
		/// この引数の値を利用してクリックされたコントロールを識別したり、コントロールの状態を確認することができます。
		/// <para>
		/// コントロールがフォーカスを得た場合、まず<see cref="IAllegroContorl.ClientF01Script" />～<see cref="IAllegroContorl.ClientF12Script" />や
		/// NextControlIDの設定をセットする処理が実行されます。
		/// <see cref="IAllegroContorl.ClientFocusScript" />で指定されたクライアントスクリプトはその次に実行されます。
		/// </para></remarks>
		public string ClientFocusScript
		{
			get { return this.ChooseButton.ClientFocusScript; }
			set { this.ChooseButton.ClientFocusScript = value; }
		}

		/// <summary>
		/// <see cref="InputPageBase.Mode" />によって画面が参照モードに設定された時に、非活性にする処理を行わないかどうか。
		/// 閉じるボタンなど、参照モードであっても有効にするコントロールにはtrueを設定してください。
		/// </summary>
		public bool DisregardsMode
		{
			get { return this.ChooseButton.DisregardsMode; }
			set { this.ChooseButton.DisregardsMode = value; }
		}

		/// <summary>
		/// コントロール上でEnterキーが押された時のフォーカスの移動先として設定するコントロールの<see cref="Control.ClientID" />。
		/// 常に<see cref="string.Empty"/>を返します。
		/// </summary>
		string IAllegroContorl.InnerNextControlID
		{
			get { return string.Empty; }
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
			base.RenderBeginTag(writer);
			this.InputFile.RenderControl(writer);

			writer.WriteLine();
			writer.AddAttribute(HtmlTextWriterAttribute.Class, "layout_container");
			writer.RenderBeginTag(HtmlTextWriterTag.Table);
			writer.RenderBeginTag(HtmlTextWriterTag.Tr);
		}

		/// <summary>
		/// コントロールのHTML終了タグを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		public override void RenderEndTag(HtmlTextWriter writer)
		{
			writer.RenderEndTag();
			writer.RenderEndTag();
			base.RenderEndTag(writer);
		}

		/// <summary>
		/// カスタムコントロールに必要なHTML属性やスタイル、イベントハンドラ等を追加します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void AddAttributesToRender(HtmlTextWriter writer)
		{
			AllegroControl.AddControlTypeAttribute(writer, this);
			base.AddAttributesToRender(writer);
		}

		/// <summary>
		/// <see cref="Control.PreRender" />イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs" />。
		/// </param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			this.RegisterClientScript();
			this.Page.Session.Remove(this.SessionKey);
			// <form>要素に出力されたカルチャ、もしくは既定のカルチャでボタン文言を設定する
			var culture = this.Page.Form.Attributes["multilanguage"] ?? MultiLanguage.DEFAULT_CULTURE_NAME;
			// 選択
			this.ChooseButton.Text = MultiLanguage.Get("CM_CS004041", culture);
			// キャンセル
			this.CancelAnchor.InnerText = MultiLanguage.Get("CM_CS000115", culture);
		}

		/// <summary>
		/// コントロールの内容を出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void RenderContents(HtmlTextWriter writer)
		{
			WriteTableCell(writer, this.ChooseButton);
			writer.WriteLine();
			WriteTableCell(writer, this.CancelAnchor, this.FileNameLabel);
			writer.WriteLine();
			WriteTableCell(writer, this.ProgressBar);
		}

		/// <summary>
		/// 空の<see cref="HttpPostedFile"/>のインスタンスを生成します。
		/// </summary>
		private static HttpPostedFile CreateEmptyHttpPostedFile()
		{
			var assembly = typeof(HttpPostedFile).Assembly;
			var typeHttpInputStream = assembly.GetType("System.Web.HttpInputStream");
			var typeHttpRawUploadedContent = assembly.GetType("System.Web.HttpRawUploadedContent");

			//コンストラクタからインスタンス生成
			var ctor = typeHttpInputStream.GetConstructor(
				BindingFlags.NonPublic | BindingFlags.Instance,
				null,
				new[] { typeHttpRawUploadedContent, typeof(int), typeof(int) },
				null);

			var emptyHttpInputStream = ctor.Invoke(new object[] { null, 0, 0 });

			return (HttpPostedFile)Activator.CreateInstance(
				typeof(HttpPostedFile),
				BindingFlags.NonPublic | BindingFlags.Instance,
				null,
				new object[] { string.Empty, "application/octet-stream", emptyHttpInputStream },
				null
			);
		}

		/// <summary>
		/// テーブルセルを描画します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		/// <param name="controls">
		/// 描画するコントロール
		/// </param>
		private static void WriteTableCell(HtmlTextWriter writer, params Control[] controls)
		{
			writer.RenderBeginTag(HtmlTextWriterTag.Td);
			foreach (var item in controls)
			{
				item.RenderControl(writer);
			}
			writer.RenderEndTag();
		}

		/// <summary>
		/// 内部コントロールを設定します。
		/// </summary>
		private void InitializeComponent()
		{
			this.InputFile = new HtmlInputFile { ID = "InputFile" };
			this.InputFile.Style.Add(HtmlTextWriterStyle.Display, "none");

			this.ChooseButton = new StyledButton
			{
				ID = "ChooseButton",
				CssClass = "normal",
				UseSubmitBehavior = false,
				OnClientClick = "return false;"
			};
			AllegroControl.RegisterControlSubtypeAttribute(this.ChooseButton, "ChooseButton");

			this.CancelAnchor = new HtmlAnchor
			{
				ID = "CancelAnchor",
				HRef = "#"
			};

			this.FileNameLabel = new EncodeLabel { ID = "FileName" };
			AllegroControl.RegisterControlSubtypeAttribute(this.FileNameLabel, "FileNameLabel");

			this.ProgressBar = new HtmlGenericControl("progress") { ID = "ProgressBar" };
			this.ProgressBar.Attributes.Add("max", "100");
			this.ProgressBar.Attributes.Add("value", "0");

			this.Controls.Add(this.InputFile);
			this.Controls.Add(this.ChooseButton);
			this.Controls.Add(this.CancelAnchor);
			this.Controls.Add(this.FileNameLabel);
			this.Controls.Add(this.ProgressBar);
		}

		/// <summary>
		/// クライアントスクリプトを登録します。
		/// </summary>
		private void RegisterClientScript()
		{
			var elementIdList = new[]
			{
				"'container': '" + this.ClientID + "'",
				"'inputFile': '" + this.InputFile.ClientID + "'",
				"'chooseButton': '" + this.ChooseButton.ClientID + "'",
				"'cancelAnchor': '" + this.CancelAnchor.ClientID + "'",
				"'fileName': '" + this.FileNameLabel.ClientID + "'",
				"'progressBar': '" + this.ProgressBar.ClientID + "'",
			};

			var parameter = new[]
			{
				"{" + string.Join(", ", elementIdList) + "}",
				(FileUploader.RequestLengthDiskThreshold * 1024).ToString(),
			};

			var script = "__customControl.initializer.fileUploaderInitializer(" + string.Join(", ", parameter) + ");";
			((PageBase)this.Page).ImmediateStartupScript.RegisterScript(this.GetType(), this.UniqueID + "StartupScript", script);
		}
	}
}
