// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : InputPageBase.cs
// 機能名      : 入力画面用基底クラス
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 1.6.0 2009/09/30
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26508 2017/06/14 アクセス権限の改善
// 3.0.0 2018/04/30

using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
// 管理番号K26508 From
using System.Web.UI.WebControls;
// 管理番号K26508 To
using Infocom.Allegro.Web.WebControls;

namespace Infocom.Allegro.Web
{
	/// <summary>
	/// すべての入力画面への共通機能を提供します。
	/// </summary>
	public class InputPageBase : PageBase
	{
		#region Private Fields
		private PageMode mode = PageMode.Insert;
		private bool isDirty = false;
		private const string hiddenName = "__isDirty";
		#endregion

		#region Methods
		/// <summary>
		/// Webページの画面モード。<see cref="PageMode.Reference"/>を設定すると、
		/// 画面上の<see cref="IAllegroContorl"/>を実装する全てのコントロールを無効表示にすることができます。
		/// </summary>
		public PageMode Mode
		{
			get {return mode;}
			set
			{
				if (!Enum.IsDefined(typeof(PageMode), value))
				{
// 					throw new ArgumentOutOfRangeException("value", "指定された引数は、有効な値の範囲内にありません。"); //K24546
					throw new ArgumentOutOfRangeException("value", MultiLanguage.Get("CM_AM001003"));
				}
				mode = value;
			}
		}

		/// <summary>
		/// 画面の入力項目の値が変更されているかどうか。
		/// </summary>
		public bool IsDirty
		{
			get {return isDirty;}
			set {isDirty = value;}
		}

		/// <summary>
		/// <see cref="Control.Init"/>イベントを発生させてページを初期化します。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnInit(EventArgs e)
		{
			string hidden = Request.Form[hiddenName];
			if (hidden != null)
			{
				isDirty = hidden.Equals("true");
			}

			base.OnInit(e);
		}

		/// <summary>
		/// <see cref="Control.PreRender"/>イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnPreRender(EventArgs e)
		{
			base.OnPreRender(e);
			if (Mode == PageMode.Reference)
			{
				foreach (Control control in Controls)
				{
					if (control is HtmlForm)
					{
// 管理番号K26508 From
//						foreach (Control childControl in control.Controls)
//						{
//							if (childControl is IAllegroContorl)
//							{
//								IAllegroContorl allegroControl = (IAllegroContorl) childControl;
//								if (!allegroControl.DisregardsMode)
//								{
//									allegroControl.Enabled = false;
//								}
//							}
////TODO
////							if (childControl is ClickableDataGrid)
////							{
////								((ClickableDataGrid) childControl).AutoPostBack = false;
////							}
//							if (childControl is ClickablePanel)
//							{
//								foreach (Control grandChildControl in childControl.Controls)
//								{
//									if (grandChildControl is IAllegroContorl)
//									{
//										IAllegroContorl allegroControl = (IAllegroContorl) grandChildControl;
//										if (!allegroControl.DisregardsMode)
//										{
//											allegroControl.Enabled = false;
//										}
//									}
//								}
//							}
//						}
//						break;
						DisableChildControl(control);
// 管理番号K26508 To
					}
				}
			}
			ClientScript.RegisterHiddenField(hiddenName, (isDirty ? "true" : string.Empty));
		}

// 管理番号K26508 From
		/// <summary>
		/// 下位のコントロールを非活性にします。
		/// </summary>
		/// <param name="control">コントロール</param>
		private void DisableChildControl(Control control)
		{
			foreach (Control childControl in control.Controls)
			{
				// 最下層まで処理を再帰的に実行する
				if ((childControl is HtmlContainerControl || childControl is Panel) && 0 < childControl.Controls.Count)
				{
					DisableChildControl(childControl);
				}

				// コントロールを非活性にする
				if (childControl is IAllegroContorl)
				{
					IAllegroContorl allegroControl = (IAllegroContorl) childControl;
					if (!allegroControl.DisregardsMode)
					{
						allegroControl.Enabled = false;
					}
				}
			}
		}
// 管理番号K26508 To
		#endregion
	}
}
