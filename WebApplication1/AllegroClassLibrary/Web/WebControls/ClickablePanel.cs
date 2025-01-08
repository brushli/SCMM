// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : ClickablePanel.cs
// 機能名      : クリックイベントをサポートするパネルカスタムコントロール
// Version     : 3.0.0
// Last Update : 2018/04/30
// Copyright (c) 2004-2018 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 1.6.0 2009/09/30
// 管理番号 B24094 2012/04/09 多重リクエスト抑止対応
// 2.0.0 2012/10/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/02/16 UI見直し
// 3.0.0 2018/04/30

using System;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// クリックイベントをサポートするパネルカスタムコントロール
	/// </summary>
	[
	ToolboxData("<{0}:ClickablePanel runat=\"server\">ClickablePanel</{0}:ClickablePanel>"),
	DefaultEvent("Click")
	]
	public class ClickablePanel : System.Web.UI.WebControls.Panel, IPostBackEventHandler
	{
		#region public event Click
		private static readonly object clickEvent = new object();

		/// <summary>
		/// <see cref="ClickablePanel"/>がクリックされたときに発生します。
		/// </summary>
		[
		Category("Action"),
		Description("ClickablePanel がクリックされたときに発生します。")
		]
		public event EventHandler Click
		{
			add {Events.AddHandler(clickEvent, value);}
			remove {Events.RemoveHandler(clickEvent, value);}
		}
		#endregion

		#region Property
		/// <summary>
		/// クリックされた時にサーバーへの自動ポストバックが発生するかどうか。
		/// </summary>
		[
		Category("Behavior"),
		DefaultValue(false),
		Description("クリックした時に、自動的にサーバーにポストします。")
		]
		public virtual bool AutoPostBack
		{
			get
			{
				object o = ViewState["AutoPostBack"];
				return (o != null) ? (bool) o : false;
			}
			set {ViewState["AutoPostBack"] = value;}
		}
		#endregion

		#region Virtual or Override Methods
		/// <summary>
		/// <see cref="Control.PreRender"/>イベントを発生させます。/>
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected override void OnPreRender(EventArgs e)
		{
// 管理番号K26528 From
			AllegroControl.RegisterControlTypeAttribute(this);
// 管理番号K26528 To
			if (AutoPostBack)
			{
// 管理番号K26528 From
////管理番号 B24094 From
////				Attributes.Add("onclick", new StringBuilder("if(forbidDuplicationSubmit())").Append(Page.ClientScript.GetPostBackEventReference(this, string.Empty)).ToString());
//				Attributes.Add("onclick", Page.ClientScript.GetPostBackEventReference(this, string.Empty) + ";");
////管理番号 B24094 To
				Attributes.Add("onclick", "__customControl.handler.clickableControlClickHandler('" + this.UniqueID + "', '');");
// 管理番号K26528 To
			}
			else
			{
				Attributes.Remove("onclick");
			}
			base.OnPreRender(e);
			if (!Enabled)
			{
				foreach (Control ctl in Controls)
				{
					if (ctl is WebControl)
					{
						((WebControl) ctl).Enabled = false;
					}
				}
			}
		}

		/// <summary>
		/// <see cref="ClickablePanel.Click"/>イベントを発生させます。
		/// </summary>
		/// <param name="e">
		/// イベント データを格納している<see cref="EventArgs"/>オブジェクト。
		/// </param>
		protected virtual void OnClick(EventArgs e)
		{
			EventHandler handler = (EventHandler) Events[clickEvent];
			if (handler != null)
			{
				handler(this, e);
			}
		}
		#endregion

		#region Explicit Interface Implementations
		/// <summary>
		/// ポストバックイベントを発生させます。
		/// </summary>
		/// <param name="eventArgument">
		/// イベント引数
		/// </param>
		void IPostBackEventHandler.RaisePostBackEvent(string eventArgument)
		{
			OnClick(new EventArgs());
		}
		#endregion
	}
}
