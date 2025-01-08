// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : EncodeLabel.cs
// 機能名      : ラベルカスタムコントロール
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25900 2015/11/19 EncodeLabelのツールチップ対応
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/15 UI見直し
// 3.0.0 2018/04/30

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// ラベルカスタムコントロール
	/// </summary>
	[ToolboxData("<{0}:EncodeLabel runat=server>EncodeLabel</{0}:EncodeLabel>")]
	public class EncodeLabel : System.Web.UI.WebControls.Label
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
		/// コントロールのサイズを超えた部分の表示方法（CSSにおけるoverflowに対応します）。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(Overflow.NotSet),
		Description("コントロールからはみ出た部分の表示方法です。")
		]
		public virtual Overflow Overflow
		{
			get
			{
				object o = ViewState["Overflow"];
				return (o != null) ? (Overflow) o : Overflow.NotSet;
			}
			set
			{
				if (!Enum.IsDefined(typeof(Overflow), value))
				{
// 					throw new ArgumentOutOfRangeException("value", "指定された引数は、有効な値の範囲内にありません。"); //K24546
					throw new ArgumentOutOfRangeException("value", MultiLanguage.Get("CM_AM001003"));
				}
				ViewState["Overflow"] = value;
			}
		}

		/// <summary>
		/// 文章の改行の方法（CSSにおけるword-breakに対応します）。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(WordBreak.NotSet),
		Description("改行の方法です。")
		]
		public virtual WordBreak WordBreak
		{
			get
			{
				object o = ViewState["WordBreak"];
				return (o != null) ? (WordBreak) o : WordBreak.NotSet;
			}
			set
			{
				if (!Enum.IsDefined(typeof(WordBreak), value))
				{
// 					throw new ArgumentOutOfRangeException("value", "指定された引数は、有効な値の範囲内にありません。"); //K24546
					throw new ArgumentOutOfRangeException("value", MultiLanguage.Get("CM_AM001003"));
				}
				ViewState["WordBreak"] = value;
			}
		}

		/// <summary>
		/// 連続する半角スペース・タブ・改行の表示方法（CSSにおけるwhite-spaceに対応します）。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(WhiteSpace.NotSet),
		Description("改行の方法です。")
		]
		public virtual WhiteSpace WhiteSpace
		{
			get
			{
				object o = ViewState["WhiteSpace"];
				return (o != null) ? (WhiteSpace) o : WhiteSpace.NotSet;
			}
			set
			{
				if (!Enum.IsDefined(typeof(WhiteSpace), value))
				{
// 					throw new ArgumentOutOfRangeException("value", "指定された引数は、有効な値の範囲内にありません。"); //K24546
					throw new ArgumentOutOfRangeException("value", MultiLanguage.Get("CM_AM001003"));
				}
				ViewState["WhiteSpace"] = value;
			}
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
			base.AddAttributesToRender(writer);
		
			switch (this.Overflow)
			{
				case Overflow.Visible:
					writer.AddStyleAttribute("overflow", "visible");
					break;
				case Overflow.Scroll:
					writer.AddStyleAttribute("overflow", "scroll");
					break;
				case Overflow.Hidden:
					writer.AddStyleAttribute("overflow", "hidden");
					break;
				case Overflow.Auto:
					writer.AddStyleAttribute("overflow", "auto");
					break;
			}
			switch (this.WordBreak)
			{
				case WordBreak.Normal:
					writer.AddStyleAttribute("word-break", "normal");
					break;
				case WordBreak.BreakAll:
					writer.AddStyleAttribute("word-break", "break-all");
					break;
				case WordBreak.KeepAll:
					writer.AddStyleAttribute("word-break", "keep-all");
					break;
			}
			switch (this.WhiteSpace)
			{
				case WhiteSpace.Normal:
					writer.AddStyleAttribute("white-space", "normal");
					break;
				case WhiteSpace.Pre:
					writer.AddStyleAttribute("white-space", "pre");
					break;
				case WhiteSpace.Nowrap:
					writer.AddStyleAttribute("white-space", "nowrap");
					break;
			}
		}

		/// <summary>
		/// コントロールを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void Render(HtmlTextWriter writer)
		{
// 管理番号 K25900 From
			// プロパティまたはスタイルが条件を満たすならツールチップの表示
			if((Width != Unit.Empty || !string.IsNullOrEmpty(Style["width"]))										// widthが設定されている
				&& (Overflow == Overflow.Hidden || string.Compare(Style["overflow"], "hidden", true) == 0)			// overflowがhidden
				&& (WhiteSpace == WhiteSpace.Nowrap || string.Compare(Style["white-space"], "nowrap", true) == 0)	// whitespaceがnowrap
				&& string.IsNullOrEmpty(ToolTip)																	// TollTipが未設定
			)
			{
				ToolTip = Text.Length > 2 && Text[0] == '\v' ? Text.Substring(1) : Text;
			}
// 管理番号 K25900 To
			if (Text.Length > 2 && Text[0] == '\v')
			{
				ForeColor = System.Drawing.Color.Red;
				base.RenderBeginTag(writer);
				System.Web.HttpUtility.HtmlEncode(Text.Substring(1), writer);
				base.RenderEndTag(writer);
			}
			else
			{
				base.RenderBeginTag(writer);
				System.Web.HttpUtility.HtmlEncode(Text, writer);
				base.RenderEndTag(writer);
			}
		}
		#endregion
	}
}
