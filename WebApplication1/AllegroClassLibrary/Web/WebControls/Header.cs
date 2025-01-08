// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : Header.cs
// 機能名      : ヘッダカスタムコントロール
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号B19392 2006/12/13 ページIDの表示位置修正
// 1.5.1 2007/06/30
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 管理番号 K22156 2008/08/26 1ページ内に複数のCM_KeyDownScript.jsが定義される問題を修正
// 1.6.0 2009/09/30
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26344 2016/08/31 汎用出力拡張機能
// 管理番号K26528 2017/02/14 UI見直し
// 管理番号K26508 2017/06/14 アクセス権限の改善
// 3.0.0 2018/04/30
// 管理番号K27057 2020/01/28 汎用項目追加
// 3.1.0 2020/06/30
// 管理番号K27230 2021/05/20 脆弱性対応
// 管理番号K27445 2022/02/15 ログ管理強化
// 3.2.0 2023/03/31

using System;
using System.ComponentModel;
// 管理番号K26344 From
using System.Data;
// 管理番号K26344 To
using System.Text;
// 管理番号K26528 From
using System.Text.RegularExpressions;
using System.Threading;
// 管理番号K26528 To
// 管理番号K27230 From
using System.Web;
// 管理番号K27230 To
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// ヘッダカスタムコントロール
	/// </summary>
	[
	DefaultProperty("Title"),
	ToolboxData("<{0}:Header runat=server></{0}:Header>")
	]
	public class Header : System.Web.UI.Control
	{
		#region Properties
		/// <summary>
		/// F1キー用のボタンに表示する文字列。
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(""),
		Description("F1 キー用のボタンに表示するテキストです。")
		] 
		public string F01ButtonText
		{
			get
			{
				object o = ViewState["F1ButtonText"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["F1ButtonText"] = value;}
		}

		/// <summary>
		/// F2キー用のボタンに表示する文字列。
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(""),
		Description("F2 キー用のボタンに表示するテキストです。")
		] 
		public string F02ButtonText
		{
			get
			{
				object o = ViewState["F2ButtonText"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["F2ButtonText"] = value;}
		}

		/// <summary>
		/// F3キー用のボタンに表示する文字列。
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(""),
		Description("F3 キー用のボタンに表示するテキストです。")
		] 
		public string F03ButtonText
		{
			get
			{
				object o = ViewState["F3ButtonText"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["F3ButtonText"] = value;}
		}

		/// <summary>
		/// F4キー用のボタンに表示する文字列。
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(""),
		Description("F4 キー用のボタンに表示するテキストです。")
		] 
		public string F04ButtonText
		{
			get
			{
				object o = ViewState["F4ButtonText"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["F4ButtonText"] = value;}
		}

		/// <summary>
		/// F5キー用のボタンに表示する文字列。
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(""),
		Description("F5 キー用のボタンに表示するテキストです。")
		] 
		public string F05ButtonText
		{
			get
			{
				object o = ViewState["F5ButtonText"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["F5ButtonText"] = value;}
		}

		/// <summary>
		/// F6キー用のボタンに表示する文字列。
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(""),
		Description("F6 キー用のボタンに表示するテキストです。")
		] 
		public string F06ButtonText
		{
			get
			{
				object o = ViewState["F6ButtonText"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["F6ButtonText"] = value;}
		}

		/// <summary>
		/// F7キー用のボタンに表示する文字列。
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(""),
		Description("F7 キー用のボタンに表示するテキストです。")
		] 
		public string F07ButtonText
		{
			get
			{
				object o = ViewState["F7ButtonText"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["F7ButtonText"] = value;}
		}

		/// <summary>
		/// F8キー用のボタンに表示する文字列。
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(""),
		Description("F8 キー用のボタンに表示するテキストです。")
		] 
		public string F08ButtonText
		{
			get
			{
				object o = ViewState["F8ButtonText"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["F8ButtonText"] = value;}
		}

		/// <summary>
		/// F9キー用のボタンに表示する文字列。
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(""),
		Description("F9 キー用のボタンに表示するテキストです。")
		] 
		public string F09ButtonText
		{
			get
			{
				object o = ViewState["F9ButtonText"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["F9ButtonText"] = value;}
		}

		/// <summary>
		/// F10キー用のボタンに表示する文字列。
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(""),
		Description("F10 キー用のボタンに表示するテキストです。")
		] 
		public string F10ButtonText
		{
			get
			{
				object o = ViewState["F10ButtonText"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["F10ButtonText"] = value;}
		}

		/// <summary>
		/// F11キー用のボタンに表示する文字列。
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(""),
		Description("F11 キー用のボタンに表示するテキストです。")
		] 
		public string F11ButtonText
		{
			get
			{
				object o = ViewState["F11ButtonText"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["F11ButtonText"] = value;}
		}

		/// <summary>
		/// F12キー用のボタンに表示する文字列。
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(""),
		Description("F12 キー用のボタンに表示するテキストです。")
		] 
		public string F12ButtonText
		{
			get
			{
				object o = ViewState["F12ButtonText"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["F12ButtonText"] = value;}
		}

		/// <summary>
		/// F1キーを表示する：true、表示しない：false
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(true),
		Description("F01 キーを表示します。")
		] 
		public bool ShowF01Button
		{
			get
			{
				object o = ViewState["ShowF01Button"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["ShowF01Button"] = value;}
		}

		/// <summary>
		/// F2キーを表示する：true、表示しない：false
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(true),
		Description("F02 キーを表示します。")
		] 
		public bool ShowF02Button
		{
			get
			{
				object o = ViewState["ShowF02Button"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["ShowF02Button"] = value;}
		}

		/// <summary>
		/// F3キーを表示する：true、表示しない：false
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(true),
		Description("F03 キーを表示します。")
		] 
		public bool ShowF03Button
		{
			get
			{
				object o = ViewState["ShowF03Button"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["ShowF03Button"] = value;}
		}

		/// <summary>
		/// F4キーを表示する：true、表示しない：false
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(true),
		Description("F04 キーを表示します。")
		] 
		public bool ShowF04Button
		{
			get
			{
				object o = ViewState["ShowF04Button"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["ShowF04Button"] = value;}
		}

		/// <summary>
		/// F5キーを表示する：true、表示しない：false
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(true),
		Description("F05 キーを表示します。")
		] 
		public bool ShowF05Button
		{
			get
			{
				object o = ViewState["ShowF05Button"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["ShowF05Button"] = value;}
		}

		/// <summary>
		/// F6キーを表示する：true、表示しない：false
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(true),
		Description("F06 キーを表示します。")
		] 
		public bool ShowF06Button
		{
			get
			{
				object o = ViewState["ShowF06Button"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["ShowF06Button"] = value;}
		}

		/// <summary>
		/// F7キーを表示する：true、表示しない：false
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(true),
		Description("F07 キーを表示します。")
		] 
		public bool ShowF07Button
		{
			get
			{
				object o = ViewState["ShowF07Button"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["ShowF07Button"] = value;}
		}

		/// <summary>
		/// F8キーを表示する：true、表示しない：false
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(true),
		Description("F08 キーを表示します。")
		] 
		public bool ShowF08Button
		{
			get
			{
				object o = ViewState["ShowF08Button"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["ShowF08Button"] = value;}
		}

		/// <summary>
		/// F9キーを表示する：true、表示しない：false
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(true),
		Description("F09 キーを表示します。")
		] 
		public bool ShowF09Button
		{
			get
			{
				object o = ViewState["ShowF09Button"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["ShowF09Button"] = value;}
		}

		/// <summary>
		/// F10キーを表示する：true、表示しない：false
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(true),
		Description("F10 キーを表示します。")
		] 
		public bool ShowF10Button
		{
			get
			{
				object o = ViewState["ShowF10Button"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["ShowF10Button"] = value;}
		}

		/// <summary>
		/// F11キーを表示する：true、表示しない：false
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(true),
		Description("F11 キーを表示します。")
		] 
		public bool ShowF11Button
		{
			get
			{
				object o = ViewState["ShowF11Button"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["ShowF11Button"] = value;}
		}

		/// <summary>
		/// F12キーを表示する：true、表示しない：false
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(true),
		Description("F12 キーを表示します。")
		] 
		public bool ShowF12Button
		{
			get
			{
				object o = ViewState["ShowF12Button"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["ShowF12Button"] = value;}
		}

		/// <summary>
		/// ファンクションキーを表示する：true、表示しない：false
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(true),
		Description("ファンクションキーを表示します。")
		] 
		public bool ShowFunctionButton
		{
			get
			{
				object o = ViewState["ShowFunctionButton"];
				return (o != null) ? (bool) o : true;
			}
			set {ViewState["ShowFunctionButton"] = value;}
		}

		/// <summary>
		/// ページタイトルに表示する文字列。
		/// </summary>
		[
		Category("Appearance"), 
		DefaultValue(""),
		Description("ページタイトルを表します。")
		] 
		public string Title
		{
			get
			{
				object o = ViewState["Title"];
				return (o != null) ? (string) o : string.Empty;
			}
			set {ViewState["Title"] = value;}
		}

// 管理番号K26508 From
		/// <summary>
		/// 画面に表示する文字列。
		/// </summary>
		[
		Category("Appearance"),
		DefaultValue(""),
		Description("画面に表示するページタイトルを表します。")
		]
		public string DisplayTitle
		{
			get
			{
				string result = Title;
				if (((PageBase) Page).AuthoritySettingType == "V")
				{
					result += (MultiLanguage.Get("CM_CS004044"));  //(参照)
				}
				return result;
			}
		}
// 管理番号K26508 To

// 管理番号 K24546 From
		/// <summary>
		/// 多言語対応用の画面サイズで表示する場合：true、それ以外の場合：false
		/// </summary>
		[
		Category("Appearance"),
		DefaultValue(false),
		Description("多言語対応用の画面サイズで表示します。")
		]
		public bool MultiLanguageMode
		{
			get
			{
				object o = ViewState["MultiLanguageMode"];
				return (o != null) ? (bool)o : false;
			}
			set { ViewState["MultiLanguageMode"] = value; }
		}
// 管理番号 K24546 To
		#endregion

		#region Override Methods
		/// <summary>
		/// コントロールを出力します。
		/// </summary>
		/// <param name="writer">
		/// 出力先の<see cref="HtmlTextWriter"/>。
		/// </param>
		protected override void Render(HtmlTextWriter writer)
		{
// 管理番号K26528 From
//			writer.Write("<table id=\"");
//			writer.Write(ClientID);	
//			writer.Write("\" cellspacing=\"0\" cellpadding=\"0\" style=\"border: 0px; width: 100%\">\r\n");
//// 管理番号 K24546 From
////			writer.Write("<tr><td class=\"hd_bg_1\"><img src=\"img/CM_a1_space.gif\" style=\"border: 0pt; width: 1px; height:  5px\" alt=\"\"></td></tr>\r\n");
////			writer.Write("<tr><td class=\"hd_bg_2\"><img src=\"img/CM_a1_space.gif\" style=\"border: 0pt; width: 1px; height: 10pxt\" alt=\"\"></td></tr>\r\n");
//			writer.Write(MultiLanguage.Get("CM_CS003580"));
//			writer.Write(MultiLanguage.Get("CM_CS003581"));
//// 管理番号 K24546 To
//			if (ShowFunctionButton)
//			{
//				writer.Write("<tr>\r\n");
//				writer.Write("<td class=\"hd_bg_3\">\r\n");
//				writer.Write("<table cellspacing=\"0\" cellpadding=\"0\" style=\"border: 0px\">\r\n");
//				writer.Write("<tr>\r\n");
//// 管理番号 K24546 From
////				writer.Write("<td><img src=\"img/CM_a1_space.gif\" style=\"border: 0pt; width: 15px; height: 40px\" alt=\"\"></td>\r\n");
//				writer.Write(MultiLanguage.Get("CM_CS003582"));
//// 管理番号 K24546 To
//				writer.Write("<td>\r\n");
//				writer.Write("<table cellspacing=\"0\" cellpadding=\"0\" style=\"border: 0px\">\r\n");
//				writer.Write("<tr>\r\n");
//				if (ShowF01Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><span class=\"hd_fkey_text\">F1</span></td>\r\n");
//				}
//				if (ShowF02Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><span class=\"hd_fkey_text\">F2</span></td>\r\n");
//				}
//				if (ShowF03Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><span class=\"hd_fkey_text\">F3</span></td>\r\n");
//				}
//				if (ShowF04Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><span class=\"hd_fkey_text\">F4</span></td>\r\n");
//				}
//				if (ShowF05Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><span class=\"hd_fkey_text\">F5</span></td>\r\n");
//				}
//				if (ShowF06Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><span class=\"hd_fkey_text\">F6</span></td>\r\n");
//				}
//				if (ShowF07Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><span class=\"hd_fkey_text\">F7</span></td>\r\n");
//				}
//				if (ShowF08Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><span class=\"hd_fkey_text\">F8</span></td>\r\n");
//				}
//				if (ShowF09Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><span class=\"hd_fkey_text\">F9</span></td>\r\n");
//				}
//				if (ShowF10Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><span class=\"hd_fkey_text\">F10</span></td>\r\n");
//				}
//				if (ShowF11Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><span class=\"hd_fkey_text\">F11</span></td>\r\n");
//				}
//				if (ShowF12Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><span class=\"hd_fkey_text\">F12</span></td>\r\n");
//				}
//				writer.Write("</tr>\r\n");
//				writer.Write("<tr>\r\n");
//// 管理番号 K24546 From
//				string button = "\" class=\"" + (MultiLanguageMode ? "hd_btn_on2" : "hd_btn_on") + "\" onfocus=\"nextFocusElement=null\" onclick=\"pressFunctionKey({0})\" onmouseover=\"mouseOnButton=true\" onmouseout=\"mouseOnButton=false\"></td>\r\n";
//// 管理番号 K24546 To
//				if (ShowF01Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><input type=\"button\" id=\"F01Button\" value=\"");
//					writer.Write(F01ButtonText);
//// 管理番号 K24546 From
////					writer.Write("\" class=\"hd_btn_on\" onfocus=\"nextFocusElement=null\" onclick=\"pressFunctionKey(0)\" onmouseover=\"mouseOnButton=true\" onmouseout=\"mouseOnButton=false\"></td>\r\n");
//					writer.Write(string.Format(button, "0"));
//// 管理番号 K24546 To
//				}
//				if (ShowF02Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><input type=\"button\" id=\"F02Button\" value=\"");
//					writer.Write(F02ButtonText);
//// 管理番号 K24546 From
////					writer.Write("\" class=\"hd_btn_on\" onfocus=\"nextFocusElement=null\" onclick=\"pressFunctionKey(1)\" onmouseover=\"mouseOnButton=true\" onmouseout=\"mouseOnButton=false\"></td>\r\n");
//					writer.Write(string.Format(button, "1"));
//// 管理番号 K24546 To
//				}
//				if (ShowF03Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><input type=\"button\" id=\"F03Button\" value=\"");
//					writer.Write(F03ButtonText);
//// 管理番号 K24546 From
////					writer.Write("\" class=\"hd_btn_on\" onfocus=\"nextFocusElement=null\" onclick=\"pressFunctionKey(2)\" onmouseover=\"mouseOnButton=true\" onmouseout=\"mouseOnButton=false\"></td>\r\n");
//					writer.Write(string.Format(button, "2"));
//// 管理番号 K24546 To
//				}
//				if (ShowF04Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><input type=\"button\" id=\"F04Button\" value=\"");
//					writer.Write(F04ButtonText);
//// 管理番号 K24546 From
////					writer.Write("\" class=\"hd_btn_on\" onfocus=\"nextFocusElement=null\" onclick=\"pressFunctionKey(3)\" onmouseover=\"mouseOnButton=true\" onmouseout=\"mouseOnButton=false\"></td>\r\n");
//					writer.Write(string.Format(button, "3"));
//// 管理番号 K24546 To
//				}
//				if (ShowF05Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><input type=\"button\" id=\"F05Button\" value=\"");
//					writer.Write(F05ButtonText);
//// 管理番号 K24546 From
////					writer.Write("\" class=\"hd_btn_on\" onfocus=\"nextFocusElement=null\" onclick=\"pressFunctionKey(4)\" onmouseover=\"mouseOnButton=true\" onmouseout=\"mouseOnButton=false\"></td>\r\n");
//					writer.Write(string.Format(button, "4"));
//// 管理番号 K24546 To
//				}
//				if (ShowF06Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><input type=\"button\" id=\"F06Button\" value=\"");
//					writer.Write(F06ButtonText);
//// 管理番号 K24546 From
////					writer.Write("\" class=\"hd_btn_on\" onfocus=\"nextFocusElement=null\" onclick=\"pressFunctionKey(5)\" onmouseover=\"mouseOnButton=true\" onmouseout=\"mouseOnButton=false\"></td>\r\n");
//					writer.Write(string.Format(button, "5"));
//// 管理番号 K24546 To
//				}
//				if (ShowF07Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><input type=\"button\" id=\"F07Button\" value=\"");
//					writer.Write(F07ButtonText);
//// 管理番号 K24546 From
////					writer.Write("\" class=\"hd_btn_on\" onfocus=\"nextFocusElement=null\" onclick=\"pressFunctionKey(6)\" onmouseover=\"mouseOnButton=true\" onmouseout=\"mouseOnButton=false\"></td>\r\n");
//					writer.Write(string.Format(button, "6"));
//// 管理番号 K24546 To
//				}
//				if (ShowF08Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><input type=\"button\" id=\"F08Button\" value=\"");
//					writer.Write(F08ButtonText);
//// 管理番号 K24546 From
////					writer.Write("\" class=\"hd_btn_on\" onfocus=\"nextFocusElement=null\" onclick=\"pressFunctionKey(7)\" onmouseover=\"mouseOnButton=true\" onmouseout=\"mouseOnButton=false\"></td>\r\n");
//					writer.Write(string.Format(button, "7"));
//// 管理番号 K24546 To
//				}
//				if (ShowF09Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><input type=\"button\" id=\"F09Button\" value=\"");
//					writer.Write(F09ButtonText);
//// 管理番号 K24546 From
////					writer.Write("\" class=\"hd_btn_on\" onfocus=\"nextFocusElement=null\" onclick=\"pressFunctionKey(8)\" onmouseover=\"mouseOnButton=true\" onmouseout=\"mouseOnButton=false\"></td>\r\n");
//					writer.Write(string.Format(button, "8"));
//// 管理番号 K24546 To
//				}
//				if (ShowF10Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><input type=\"button\" id=\"F10Button\" value=\"");
//					writer.Write(F10ButtonText);
//// 管理番号 K24546 From
////					writer.Write("\" class=\"hd_btn_on\" onfocus=\"nextFocusElement=null\" onclick=\"pressFunctionKey(9)\" onmouseover=\"mouseOnButton=true\" onmouseout=\"mouseOnButton=false\"></td>\r\n");
//					writer.Write(string.Format(button, "9"));
//// 管理番号 K24546 To
//				}
//				if (ShowF11Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><input type=\"button\" id=\"F11Button\" value=\"");
//					writer.Write(F11ButtonText);
//// 管理番号 K24546 From
////					writer.Write("\" class=\"hd_btn_on\" onfocus=\"nextFocusElement=null\" onclick=\"pressFunctionKey(10)\" onmouseover=\"mouseOnButton=true\" onmouseout=\"mouseOnButton=false\"></td>\r\n");
//					writer.Write(string.Format(button, "10"));
//// 管理番号 K24546 To
//				}
//				if (ShowF12Button)
//				{
//					writer.Write("<td style=\"text-align: center\"><input type=\"button\" id=\"F12Button\" value=\"");
//					writer.Write(F12ButtonText);
//// 管理番号 K24546 From
////					writer.Write("\" class=\"hd_btn_on\" onfocus=\"nextFocusElement=null\" onclick=\"pressFunctionKey(11)\" onmouseover=\"mouseOnButton=true\" onmouseout=\"mouseOnButton=false\"></td>\r\n");
//					writer.Write(string.Format(button, "11"));
//// 管理番号 K24546 To
//				}
//				writer.Write("</tr>\r\n");
//				writer.Write("</table>\r\n");
//				writer.Write("</td>\r\n");
//				writer.Write("</tr>\r\n");
//				writer.Write("</table>\r\n");
//				writer.Write("</td>\r\n");
//				writer.Write("</tr>\r\n");
//			}
//			writer.Write("<tr style=\"width: 100%\">\r\n");
//			writer.Write("<td class=\"hd_bg_4\">\r\n");
//			writer.Write("<table cellspacing=\"3\" cellpadding=\"0\" style=\"border: 0px\">\r\n");
//			writer.Write("<tr>\r\n");
//// 管理番号 K24546 From
////			writer.Write("<td><img src=\"img/CM_a1_space.gif\" style=\"border: 0px; width: 10px; height: 1px\" alt=\"\"></td>\r\n");
//			writer.Write(MultiLanguage.Get("CM_CS003583"));
//// 管理番号 K24546 To
//// 			writer.Write("<td><img src=\"img/CM_a2_hd_title_point.gif\" style=\"border: 0px; width: 20px; height: 20px\" alt=\"■\"></td>\r\n"); //K24546
//			writer.Write(MultiLanguage.Get("CM_CS003591"));
			writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);
			writer.AddAttribute(HtmlTextWriterAttribute.Class, "layout_container");
			AllegroControl.AddControlTypeAttribute(writer, this);
			writer.RenderBeginTag(HtmlTextWriterTag.Table);

			// 上部の飾り罫
			writer.WriteLine("<tr><td class=\"hd_bg_1\"></td></tr>");
			writer.WriteLine("<tr><td class=\"hd_bg_2\"></td></tr>");

			// ファンクションキーボタン
			if (ShowFunctionButton)
			{
				writer.WriteLine("<tr>");
				writer.WriteLine("<td class=\"hd_bg_3 centering_container\">");
				writer.WriteLine("<table class=\"layout_container\">");

				// ラベル部分
				writer.WriteLine("<tr>");
				foreach (var item in new[] {
					new { ShowButton = ShowF01Button, Text = "F1" },
					new { ShowButton = ShowF02Button, Text = "F2" },
					new { ShowButton = ShowF03Button, Text = "F3" },
					new { ShowButton = ShowF04Button, Text = "F4" },
					new { ShowButton = ShowF05Button, Text = "F5" },
					new { ShowButton = ShowF06Button, Text = "F6" },
					new { ShowButton = ShowF07Button, Text = "F7" },
					new { ShowButton = ShowF08Button, Text = "F8" },
					new { ShowButton = ShowF09Button, Text = "F9" },
					new { ShowButton = ShowF10Button, Text = "F10" },
					new { ShowButton = ShowF11Button, Text = "F11" },
					new { ShowButton = ShowF12Button, Text = "F12" },
				})
				{
					if (item.ShowButton)
					{
						writer.Write("<td class=\"hd_fkey_text\">");
						writer.Write(item.Text);
						writer.WriteLine("</td>");
					}
				}
				writer.WriteLine("</tr>");

				// ボタン部分
				var keyId = 0;
				writer.WriteLine("<tr>");
				foreach (var item in new[] {
					new { ShowButton = ShowF01Button, Id="F01Button", ButtonText = F01ButtonText },
					new { ShowButton = ShowF02Button, Id="F02Button", ButtonText = F02ButtonText },
					new { ShowButton = ShowF03Button, Id="F03Button", ButtonText = F03ButtonText },
					new { ShowButton = ShowF04Button, Id="F04Button", ButtonText = F04ButtonText },
					new { ShowButton = ShowF05Button, Id="F05Button", ButtonText = F05ButtonText },
					new { ShowButton = ShowF06Button, Id="F06Button", ButtonText = F06ButtonText },
					new { ShowButton = ShowF07Button, Id="F07Button", ButtonText = F07ButtonText },
					new { ShowButton = ShowF08Button, Id="F08Button", ButtonText = F08ButtonText },
					new { ShowButton = ShowF09Button, Id="F09Button", ButtonText = F09ButtonText },
					new { ShowButton = ShowF10Button, Id="F10Button", ButtonText = F10ButtonText },
					new { ShowButton = ShowF11Button, Id="F11Button", ButtonText = F11ButtonText },
					new { ShowButton = ShowF12Button, Id="F12Button", ButtonText = F12ButtonText },
				})
				{
					if (item.ShowButton)
					{
						writer.Write("<td>");
						writer.Write(new StringBuilder("<input")
							.Append(" type=\"button\"")
							.Append(" id=\"").Append(item.Id).Append("\"")
							.Append(" class=\"hd_btn\"")
							.Append(" value=\"").Append(item.ButtonText).Append("\"")
// 管理番号K27445 From
//							.Append(" onfocus=\"nextFocusElement=null;\"")
							.Append(" onfocus=\"nextFocusElement=null; setFunctionKeyInfo(this);\"")
// 管理番号K27445 To
							.Append(" onclick=\"pressFunctionKey(").Append(keyId).Append(");\"")
							.Append(" />")
							);
						writer.WriteLine("</td>");
					}
					keyId++;
				}

				writer.WriteLine("</tr>");
				writer.WriteLine("</table>");
				writer.WriteLine("</td>");
				writer.WriteLine("</tr>");
			}

			// 機能名等表示部分
			writer.WriteLine("<tr>");
			writer.WriteLine("<td class=\"hd_bg_4 centering_container\">");
			writer.WriteLine("<table>");
			writer.WriteLine("<tr>");

			var titleImage = new CustomImage
			{
				// img/CM_a2_hd_title_point.gif
				ImageUrl = MultiLanguage.Get("CM_IM000118"),
				// ■
				AlternateText = MultiLanguage.Get("CM_CS000030"),
			};
			AllegroControl.RegisterControlSubtypeAttribute(titleImage, "TitlePointImage");
			writer.WriteLine("<td>");
			titleImage.RenderControl(writer);
			writer.WriteLine("</td>");
// 管理番号K26528 To

			if ((ShowFunctionButton)
				&& (ShowF01Button)
				&& (ShowF02Button)
				&& (ShowF03Button)
				&& (ShowF04Button)
				&& (ShowF05Button)
				&& (ShowF06Button)
				&& (ShowF07Button)
				&& (ShowF08Button)
				&& (ShowF09Button)
				&& (ShowF10Button)
				&& (ShowF11Button)
				&& (ShowF12Button)
				)
			{
// 管理番号K26528 From
//// 管理番号 K24546 From
////				writer.Write("<td style=\"width: 250px\">");
////				writer.Write("<span class=\"hd_title\">");
////				writer.Write(Title);
////				writer.Write("</span>");
////				writer.Write("</td>\r\n");
//				// 画面名
//				writer.Write(string.Format("<td class=\"hd_title\" style=\"width: {0}px;\">", (MultiLanguageMode ? "506" : "250")));
//				writer.Write(Title);
//				writer.WriteLine("</td>");
//// 管理番号 K24546 To
				writer.Write("<td class=\"hd_title\">");
// 管理番号K26508 From
//				writer.Write(Title);
				writer.Write(DisplayTitle);
// 管理番号K26508 To
				writer.WriteLine("</td>");
// 管理番号K26528 To
				if (((PageBase) Page).ECLoginFlg)
				{
// 管理番号K26528 From
//					writer.Write("<td style=\"text-align: right\">");
//					writer.Write("<span style=\"width: 365px; text-align: right; overflow: hidden; white-space: nowrap; text-overflow: ellipsis\">");
					writer.Write("<td style=\"width: 315px;\">");
					var style =
						CreateStyleAttribute(true,
							new[] {
								"width: 315px",
								"text-align: right",
								"overflow: hidden",
								"white-space: nowrap",
								"text-overflow: ellipsis",
								"vertical-align: top",
							}
						);
					writer.Write(new StringBuilder("<span ").Append(style).Append(">"));
// 管理番号K26528 To
					writer.Write(((PageBase) Page).SC_EC_CompName);
					writer.Write(" ");
					writer.Write(((PageBase) Page).SC_EC_DeptShortName);
					writer.Write("</span>");
					writer.Write("</td>\r\n");
					writer.Write("<td style=\"width: 120px; text-align: right\">");
					writer.Write(((PageBase) Page).SC_EC_AccountName);
					writer.Write("</td>\r\n");
				}
				else
				{
// 管理番号K26528 From
//					writer.Write("<td style=\"text-align: right\">");
//// 管理番号K26344 From
////					writer.Write("<span style=\"width: 413px; text-align: right; overflow: hidden; white-space: nowrap; text-overflow: ellipsis\">");
//					writer.Write("<span style=\"width: 396px; text-align: right; overflow: hidden; white-space: nowrap; text-overflow: ellipsis\">");
//// 管理番号K26344 To
					writer.Write("<td style=\"width: 346px;\">");
					var style =
						CreateStyleAttribute(true,
							new[] {
								"width: 346px",
								"text-align: right",
								"overflow: hidden",
								"white-space: nowrap",
								"text-overflow: ellipsis",
								"vertical-align: top",
							}
						);
					writer.Write(new StringBuilder("<span ").Append(style).Append(">"));
// 管理番号K26528 To
// 管理番号K27230 From
//					writer.Write(((PageBase) Page).MyCompShortName);
					writer.Write(HttpUtility.HtmlEncode(((PageBase)Page).MyCompShortName));
// 管理番号K27230 To
					writer.Write("</span>");
					writer.Write("</td>\r\n");
					writer.Write("<td style=\"width: 72px; text-align: right\">");
// 管理番号K27230 From
//					writer.Write(((PageBase) Page).UserName);
					writer.Write(HttpUtility.HtmlEncode(((PageBase)Page).UserName));
// 管理番号K27230 To
					writer.Write("</td>\r\n");
				}
// 管理番号K26528 From
//				writer.Write("<td style=\"width: 65px; text-align: right\">");
//				writer.Write("<span id=\"HeaderDate\">");
//				writer.Write(DateTime.Today.ToString("yyyy/MM/dd"));
//				writer.Write("</span>");
//				writer.Write("</td>\r\n");
//// 管理番号B19392 From
////				writer.Write("<td style=\"width: 120px; text-align: right; vertical-align: middle\">");
//				writer.Write("<td style=\"width: 100px; text-align: right; vertical-align: middle\">");
//// 管理番号B19392 To
//				writer.Write(((PageBase) Page).PageID);
//// 管理番号B19392 From
//				writer.Write("</td>\r\n");
//				writer.Write("<td style=\"text-align: left\">");
//// 管理番号B19392 To
				// 日付
				writer.Write("<td style=\"width: 65px; text-align: right;\">");
				writer.Write("<span id=\"HeaderDate\">");
				writer.Write(DateTime.Today.ToString("yyyy/MM/dd"));
				writer.Write("</span>");
				writer.WriteLine("</td>");

				// ページID
				writer.Write("<td style=\"width: 100px; text-align: right;\">");
// 管理番号K27230 From
//				writer.Write(((PageBase)Page).PageID);
				writer.Write(HttpUtility.HtmlEncode(((PageBase)Page).PageID));
// 管理番号K27230 To
				writer.WriteLine("</td>");

				// 汎用出力ボタン
				writer.WriteLine("<td id=\"HsBtn\" style=\"width: 15px;\">");
// 管理番号K26528 To

				if (!((PageBase) Page).ECLoginFlg)
				{
// 管理番号K26344 From
					// 基幹ログインの場合のみ、汎用出力ボタンの表示制御
					DataRow[] row = ((PageBase)Page).HSControls;
					if (((PageBase)Page).EmpAllocFlg)
					{
						// 汎用出力ボタンで使用するscriptの組み立て
						StringBuilder script = new StringBuilder();
// 管理番号K27057 From
//						script.Append("openHsSelectionWindow(").Append("'" + ((PageBase)Page).PageID + "')");
						script.Append("setHsSelectButtonClickFlg(").Append("'" + ClientID + "')");
// 管理番号K27057 To

						// 汎用出力ボタンを設定
						var hsBtn = new StyledButton();
// 管理番号K26528 From
						AllegroControl.RegisterControlSubtypeAttribute(hsBtn, "HsButton");
// 管理番号K26528 To
						hsBtn.ImageUrl = "img/CM_b3_hs.gif";
						hsBtn.CssClass = "image";
// 管理番号K26528 From
//						hsBtn.AlternateText = MultiLanguage.Get("CM_CS004007"); // 汎用出力を呼び出します。
						hsBtn.ToolTip = MultiLanguage.Get("CM_CS004007"); // 汎用出力を呼び出します。
// 管理番号K26528 To
						hsBtn.Enabled = true;
						hsBtn.Visible = true;
// 管理番号K26528 From
//						hsBtn.ImageAlign = ImageAlign.AbsMiddle;
// 管理番号K26528 To
						hsBtn.ClientClickScript2 = script.ToString();
						// F1,F11,F12は元のファンクションを設定
						hsBtn.ClientF01Script = "functionKeyDownFunctions[0]";
						hsBtn.ClientF11Script = "functionKeyDownFunctions[10]";
						hsBtn.ClientF12Script = "functionKeyDownFunctions[11]";
						hsBtn.RenderControl(writer);

// 管理番号K26528 From
//						writer.Write("<td style=\"width: 2px\">");
//						// scriptに画面コントロールIDを設定（CM.jsで使用）
//						string[] controls = (string[])row[0]["HS_CONTROLS"];
//						writer.Write("<script>");
//						writer.Write("var _hs_condit = new Array(");
//						bool fst = false;
//						foreach (string acon in controls)
//						{
//							if (!fst)
//							{
//								fst = true;
//							}
//							else
//							{
//								writer.Write(",");
//							}
//							writer.Write("'");
//							writer.Write(acon);
//							writer.Write("'");
//						}
//						writer.Write(");</script>");]
						// scriptに画面コントロールIDを設定（CM.jsで使用）
						// writerに<script>を出力してしまうと描画が中断されてしまうので出力方法を変更する
						foreach (var item in (string[])row[0]["HS_CONTROLS"])
						{
							this.Page.ClientScript.RegisterArrayDeclaration("_hs_condit", "'" + item + "'");
						}
// 管理番号K26528 To
					}
// 管理番号K26528 From
//					else
//					{
//						writer.Write("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
//					}
// 管理番号K26528 To
// 管理番号K26344 To
// 管理番号K26528 From
//					if (((PageBase) Page).DisclosureUnitType == "C")
//					{
//// 						writer.Write("<img src=\"img/CM_c1_disclosure_unit_type_c.gif\" style=\"border: 0px\" alt=\"「全社」権限を所有しています。所属していない部門を入力して操作することができます。\"><br>"); //K24546
//						writer.Write(MultiLanguage.Get("CM_AM000415"));
//					}
//					else if (((PageBase) Page).DisclosureUnitType == "D")
//					{
//// 						writer.Write("<img src=\"img/CM_c1_disclosure_unit_type_d.gif\" style=\"border: 0px\" alt=\"「部門」権限のみ所有しています。所属している部門および配下の部門のみ入力可能です。\"><br>"); //K24546
//						writer.Write(MultiLanguage.Get("CM_AM000416"));
//					}
					writer.WriteLine("</td>");

					// 公開単位区分アイコン
					writer.WriteLine("<td style=\"width: 15px;\">");
					RenderDisclosureUnitTypeIcon(writer);
// 管理番号K26528 To
				}
				writer.Write("</td>\r\n");
			}
			else
			{
// 管理番号K26528 From
//				writer.Write("<td style=\"width: 70%\">");
//				writer.Write("<span class=\"hd_title\">");
//				writer.Write(Title);
//				writer.Write("</span>");
//				writer.Write("</td>\r\n");
//				writer.Write("<td style=\"width: 30%; text-align: right\">");
//				writer.Write(((PageBase) Page).PageID);
				// 画面名
				writer.Write("<td class=\"hd_title\" style=\"width: 70%\">");
// 管理番号K26508 From
//				writer.Write(Title);
				writer.Write(DisplayTitle);
// 管理番号K26508 To
				writer.WriteLine("</td>");

				// ページID・公開単位区分アイコン
				writer.Write("<td style=\"width: 30%; text-align: right\">");
// 管理番号K27230 From
//				writer.Write(((PageBase)Page).PageID);
				writer.Write(HttpUtility.HtmlEncode(((PageBase)Page).PageID));
// 管理番号K27230 To
// 管理番号K26528 To
				if (!((PageBase) Page).ECLoginFlg)
				{
// 管理番号K26528 From
//					if (((PageBase) Page).DisclosureUnitType == "C")
//					{
//// 						writer.Write("<img src=\"img/CM_c1_disclosure_unit_type_c.gif\" style=\"border: 0px\" alt=\"「全社」権限を所有しています。所属していない部門を入力して操作することができます。\"><br>"); //K24546
//						writer.Write(MultiLanguage.Get("CM_AM000415"));
//					}
//					else if (((PageBase) Page).DisclosureUnitType == "D")
//					{
//// 						writer.Write("<img src=\"img/CM_c1_disclosure_unit_type_d.gif\" style=\"border: 0px\" alt=\"「部門」権限のみ所有しています。所属している部門および配下の部門のみ入力可能です。\"><br>"); //K24546
//						writer.Write(MultiLanguage.Get("CM_AM000416"));
//					}
					RenderDisclosureUnitTypeIcon(writer);
// 管理番号K26528 To
				}
				writer.Write("</td>\r\n");
			}
			writer.Write("</tr>\r\n");
			writer.Write("</table>\r\n");
			writer.Write("</td>\r\n");
			writer.Write("</tr>\r\n");
			writer.Write("</table>\r\n");
// 管理番号K26528 From
//// 管理番号 K24546 From
//			string hiddenField = "<input id=\"{0}\" type=\"hidden\" runat=\"server\" name=\"{1}\" value=\"{2}\">\r\n";
//			writer.Write(string.Format(hiddenField, "__HeaderButtonOnCssClassName", "__HeaderButtonOnCssClassName", (MultiLanguageMode ? "hd_btn_on2" : "hd_btn_on")));
//			writer.Write(string.Format(hiddenField, "__HeaderButtonOffCssClassName", "__HeaderButtonOffCssClassName", (MultiLanguageMode ? "hd_btn_off2" : "hd_btn_off")));
//// 管理番号 K24546 To
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
// 管理番号K27057 From
			string[] clickFlg = this.Page.Request.Form.GetValues("HsSelectButtonClickFlg");
			if (clickFlg != null)
			{
				string sessionId = Guid.NewGuid().ToString("N");
				Page.Session.Add(sessionId, System.Web.HttpUtility.ParseQueryString(clickFlg[0].ToString(),Encoding.UTF8));
				StringBuilder script = new StringBuilder();
// 管理番号K27230 From
//				script.Append("addEvent(window, 'load', function() { openHsSelectionWindow(").Append("'").Append(((PageBase)Page).PageID).Append("','").Append(sessionId).Append("'); });");
				string pageId = HttpUtility.JavaScriptStringEncode(((PageBase)Page).PageID);
				script.Append("addEvent(window, 'load', function() { openHsSelectionWindow(").Append("'").Append(pageId).Append("','").Append(sessionId).Append("'); });");
// 管理番号K27230 To
				Page.ClientScript.RegisterStartupScript(this.GetType(), "openHsSelectionWindow", script.ToString(), true);
			}
// 管理番号K27057 To
			// 多言語モードであることをform要素に属性として埋め込む
			if (this.MultiLanguageMode)
			{
				this.Page.Form.Attributes.Add("multilanguage", Thread.CurrentThread.CurrentUICulture.Name);
			}

			// title要素の書き換え
			if (Page.Header != null)
			{
// 管理番号K26508 From
//				Page.Header.Title = EscapeTitle(this.Title);
				Page.Header.Title = EscapeTitle(this.DisplayTitle);
// 管理番号K26508 To
			}
// 管理番号K26528 To
			base.OnPreRender(e);
		}
		#endregion

// 管理番号K26528 From
		/// <summary>
		/// 公開単位区分アイコンを描画します。
		/// </summary>
		/// <param name="writer"></param>
		private void RenderDisclosureUnitTypeIcon(HtmlTextWriter writer)
		{
			var image = new CustomImage();
			AllegroControl.RegisterControlSubtypeAttribute(image, "UnitTypeImage");
			var disclosureUnitType = ((PageBase)Page).DisclosureUnitType;
			if (disclosureUnitType == "C")
			{
				// img/CM_c1_disclosure_unit_type_c.gif
				image.ImageUrl = MultiLanguage.Get("CM_IM000119");
				// 「全社」権限を所有しています。所属していない部門を入力して操作することができます。
				image.AlternateText = MultiLanguage.Get("CM_CS004028");
			}
			else if (disclosureUnitType == "D")
			{
				// img/CM_c1_disclosure_unit_type_d.gif
				image.ImageUrl = MultiLanguage.Get("CM_IM000120");
				// 「部門」権限のみ所有しています。所属している部門および配下の部門のみ入力可能です。
				image.AlternateText = MultiLanguage.Get("CM_CS004029");
			}
			image.RenderControl(writer);
		}

		/// <summary>
		/// style属性を生成します。
		/// </summary>
		/// <param name="addStyleAttribute">style属性で括る場合は<c>true</c>。</param>
		/// <param name="style"><c>property: value</c>形式のスタイル。</param>
		/// <returns></returns>
		private static string CreateStyleAttribute(bool addStyleAttribute, params string[] style)
		{
			var sb = new StringBuilder();
			if (addStyleAttribute)
			{
				sb.Append("style=\"");
			}
			sb.Append(string.Join("; ", style)).Append(";");
			if (addStyleAttribute)
			{
				sb.Append("\"");
			}
			return sb.ToString();
		}

		/// <summary>
		/// 指定された文字列をtitle要素に記載するために変換します。
		/// </summary>
		/// <param name="text"></param>
		/// <returns>title要素に記載可能な文字列</returns>
		private static string EscapeTitle(string text)
		{
			return Regex.Replace(text.Trim(), @"<\s*/?\s*br\s*/?\s*>", string.Empty, RegexOptions.IgnoreCase);
		}
// 管理番号K26528 To
	}
}
