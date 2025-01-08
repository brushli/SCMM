// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : AllegroException.cs
// 機能名      : 共通例外クラス
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 管理番号 P18434 2006/12/13 デットロック対応
// 1.5.1 2007/06/30
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26528 2017/04/03 UI見直し
// 3.0.0 2018/04/30
// 3.1.0 2020/06/30
// 管理番号K27230 2021/07/28 脆弱性対応
// 3.2.0 2023/03/31

using System;
using System.Data.SqlClient;
// 管理番号K26528 From
//using System.Text;
// 管理番号K26528 To
using System.Runtime.Serialization;
// 管理番号K26528 From
using Infocom.Allegro.Web.Html;
// 管理番号K26528 To

namespace Infocom.Allegro
{
	/// <summary>
	/// GRANDITで生成される独自例外。このクラスは継承できません。
	/// </summary>
	[Serializable]
	public sealed class AllegroException : ApplicationException
	{
		#region Private Fields
		private string machineName = Environment.MachineName;
		private CommonData commonData = null;
		private ExceptionLevel exceptionLevel = ExceptionLevel.Undefined;
		private string message = null;
		#endregion

		#region Constructors
		/// <summary>
		/// <see cref="AllegroException"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="exceptionLevel">
		/// 例外レベル
		/// </param>
		/// <remarks>
		/// <p>このコンストラクタは、新しいインスタンスの <see cref="Exception.Message" /> プロパティを初期化し、その値として "アプリケーション エラーが発生しました" などのエラーを説明するシステム提供のメッセージを指定します。このメッセージは、システムの現在のカルチャを考慮して指定します。</p>
		/// </remarks>
		public AllegroException(CommonData commonData, ExceptionLevel exceptionLevel) : base(AllegroMessage.Default)
		{
			this.commonData = commonData;
			this.exceptionLevel = exceptionLevel;
		}

		/// <summary>
		/// 指定したエラー メッセージを使用して、<see cref="AllegroException"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="exceptionLevel">
		/// 例外レベル
		/// </param>
		/// <param name="message">
		/// 例外の原因を説明するエラー メッセージ。
		/// </param>
		/// <remarks>
		/// <p><paramref name="message" /> パラメータの内容は、ユーザーが理解できる内容にします。このコンストラクタの呼び出し元では、この文字列が現在のシステムのカルチャに合わせてローカライズ済みであることを確認しておく必要があります。</p>
		/// <p>このメッセージは、システムの現在のカルチャを考慮して指定します。</p>
		/// </remarks>
		public AllegroException(CommonData commonData, ExceptionLevel exceptionLevel, string message) : base(message)
		{
			this.commonData = commonData;
//管理番号P18434 From
// 			if (message.ToString().IndexOf("デッドロック") >= 0  || //K24546
			if (message.ToString().IndexOf(MultiLanguage.Get("CM_AM000600")) >= 0 ||
			    message.ToUpper().IndexOf("DEADLOCK") >= 0 )
			{
				this.message = AllegroMessage.S20031;
				this.exceptionLevel = ExceptionLevel.Info;
			}
			else
			{
				this.exceptionLevel = exceptionLevel;
			}
//			this.exceptionLevel = exceptionLevel;
//管理番号P18434 To
		}

		/// <summary>
		/// 指定したエラー メッセージと、この例外の原因である内部例外への参照を使用して、<see cref="AllegroException"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="exceptionLevel">
		/// 例外レベル
		/// </param>
		/// <param name="message">
		/// 例外の原因を説明するエラー メッセージ。
		/// </param>
		/// <param name="innerException">
		/// 例外の原因とする内部例外。
		/// </param>
		/// <remarks>
		/// <p><paramref name="message" /> パラメータの内容は、ユーザーが理解できる内容にします。このコンストラクタの呼び出し元では、この文字列が現在のシステムのカルチャに合わせてローカライズ済みであることを確認しておく必要があります。</p>
		/// <p>前の例外の直接の結果としてスローされる例外については、 <see cref="Exception.InnerException" /> プロパティに、前の例外への参照が格納されます。 <b>InnerException</b> プロパティは、コンストラクタに渡されたものと同じ値を返します。 <b>InnerException</b> プロパティによって内部例外値がコンストラクタに渡されなかった場合は、null 参照を返します。</p>
		/// </remarks>
		public AllegroException(CommonData commonData, ExceptionLevel exceptionLevel, string message, Exception innerException) : base(message, innerException)
		{
			this.commonData = commonData;
//管理番号P18434 From
// 			if (message.ToString().IndexOf("デッドロック") >= 0  || //K24546
			if (message.ToString().IndexOf(MultiLanguage.Get("CM_AM000600")) >= 0 ||
			    message.ToUpper().IndexOf("DEADLOCK") >= 0 )
			{
				this.message = AllegroMessage.S20031;
				this.exceptionLevel = ExceptionLevel.Info;
			}
			else
			{
				this.exceptionLevel = exceptionLevel;
			}
//			this.exceptionLevel = exceptionLevel;
//管理番号P18434 To
		}

		/// <summary>
		/// この例外の原因である内部例外への参照を使用して、<see cref="AllegroException"/>クラスの新しいインスタンスを初期化します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="innerException">
		/// 例外の原因とする内部例外。<see cref="Message"/>には<see cref="SqlException.Number"/>の値に応じた<see cref="AllegroMessage"/>の値が設定されます。
		/// </param>
		public AllegroException(CommonData commonData, SqlException innerException) : base(innerException.Message, innerException)
		{
			this.commonData = commonData;

			switch (((SqlException) innerException).Number)
			{
				case 229:
					this.message = AllegroMessage.CM_AC_S20007;
					this.exceptionLevel = ExceptionLevel.Error;
					break;
				case 2627:
					this.message = AllegroMessage.S20002();
					this.exceptionLevel = ExceptionLevel.Error;
					break;
				case -2:	// SqlCommand オブジェクトのコマンド実行のタイムアウト
				case 844:	// バッファラッチ待機時間のタイムアウト
				case 845:	// バッファラッチ待機時間のタイムアウト
				case 1222:	// ロック要求のタイムアウト
				case 7214:	// リモートプロシージャのタイムアウト
				case 7604:	// フルテキスト操作のタイムアウト
				case 8628:	// クエリ最適化待機時間のタイムアウト
				case 8645:	// クエリ実行のためのメモリリソースを待機中にタイムアウト
					this.message = AllegroMessage.S20013;
					this.exceptionLevel = ExceptionLevel.Error;
					break;
				default:
					this.message = AllegroMessage.S20025(innerException.Message);
					this.exceptionLevel = ExceptionLevel.FatalError;
					break;
			}
//管理番号P18434 From
// 			if (((SqlException)innerException).Message.ToString().IndexOf("デッドロック") >= 0 || //K24546
			if (((SqlException)innerException).Message.ToString().IndexOf(MultiLanguage.Get("CM_AM000600")) >= 0 ||
				((SqlException)innerException).Message.ToUpper().IndexOf("DEADLOCK") >= 0 )
			{
				this.message = AllegroMessage.S20031;
				this.exceptionLevel = ExceptionLevel.Info;
			}
//管理番号P18434 To

		}
		#endregion

		#region Properties
		/// <summary>
		/// マシン名（<see cref="Environment.MachineName"/>）
		/// </summary>
		public string MachineName
		{
			get {return machineName;}
		}

		/// <summary>
		/// 共通データ
		/// </summary>
		public CommonData CommonData
		{
			get {return commonData;}
		}

		/// <summary>
		/// 例外レベル
		/// </summary>
		public ExceptionLevel ExceptionLevel
		{
			get {return exceptionLevel;}
		}

		/// <summary>
		/// 例外レベルに応じてマークアップを行ったHTML形式のメッセージ。
		/// </summary>
		public string HtmlMessage
		{
			get
			{
// 管理番号K26528 From
//				StringBuilder sb = new StringBuilder(1024);
//
//				switch (exceptionLevel)
//				{
//					case Infocom.Allegro.ExceptionLevel.Undefined:
//						sb.Append("<table cellspacing=\"0\" cellpadding=\"1\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_4_1\">");
//						sb.Append("<table cellspacing=\"1\" cellpadding=\"3\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_4_2\">");
//						sb.Append(AllegroMessage.S20027).Append("<br>");
//// 						sb.Append("<img src=\"img/CM_a3_error_info.gif\" alt=\"ご確認ください。\" style=\"border: 0px\"><br>"); //K24546
//						sb.Append(MultiLanguage.Get("CM_AM000414"));
//						sb.Append("<span class=\"msg_fnt_4\">");
//						sb.Append(Message.Replace("\r\n", "<br>"));
//						sb.Append("</span><br>");
//						sb.Append("</td></tr></table>");
//						sb.Append("</td></tr></table>");
//						break;
//					case Infocom.Allegro.ExceptionLevel.FatalError:
//						sb.Append("<table cellspacing=\"0\" cellpadding=\"1\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_4_1\">");
//						sb.Append("<table cellspacing=\"1\" cellpadding=\"3\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_4_2\">");
//						sb.Append(AllegroMessage.S20026).Append("<br>");
//// 						sb.Append("<img src=\"img/CM_a3_error_info.gif\" alt=\"ご確認ください。\" style=\"border: 0px\"><br>"); //K24546
//						sb.Append(MultiLanguage.Get("CM_AM000414"));
//						sb.Append("<span class=\"msg_fnt_4\">");
//						sb.Append(Message.Replace("\r\n", "<br>"));
//						sb.Append("</span><br>");
//						sb.Append("</td></tr></table>");
//						sb.Append("</td></tr></table>");
//						break;
//					case Infocom.Allegro.ExceptionLevel.Error:
//						sb.Append("<table cellspacing=\"0\" cellpadding=\"1\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_3_1\">");
//						sb.Append("<table cellspacing=\"1\" cellpadding=\"3\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_3_2\">");
//// 						sb.Append("<img src=\"img/CM_a3_error_info.gif\" alt=\"ご確認ください。\" style=\"border: 0px\"><br>"); //K24546
//						sb.Append(MultiLanguage.Get("CM_AM000414"));
//						sb.Append("<span class=\"msg_fnt_3\">");
//						sb.Append(Message.Replace("\r\n", "<br>"));
//						sb.Append("</span><br>");
//						sb.Append("</td></tr></table>");
//						sb.Append("</td></tr></table>");
//						break;
//					case Infocom.Allegro.ExceptionLevel.Warning:
//						sb.Append("<table cellspacing=\"0\" cellpadding=\"1\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_2_1\">");
//						sb.Append("<table cellspacing=\"1\" cellpadding=\"3\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_2_2\">");
//						sb.Append("<span class=\"msg_fnt_2\">");
//						sb.Append(Message.Replace("\r\n", "<br>"));
//						sb.Append("</span><br>");
//						sb.Append("</td></tr></table>");
//						sb.Append("</td></tr></table>");
//						break;
//					case Infocom.Allegro.ExceptionLevel.Info:
//						sb.Append("<table cellspacing=\"0\" cellpadding=\"1\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_1_1\">");
//						sb.Append("<table cellspacing=\"1\" cellpadding=\"3\" style=\"border: 0px; width: 100%\"><tr><td class=\"msg_bg_1_2\">");
//						sb.Append("<span class=\"msg_fnt_1\">");
//						sb.Append(Message.Replace("\r\n", "<br>"));
//						sb.Append("</span><br>");
//						sb.Append("</td></tr></table>");
//						sb.Append("</td></tr></table>");
//						break;
//					case Infocom.Allegro.ExceptionLevel.Verbose:
//						sb.Append(Message.Replace("\r\n", "<br>"));
//						break;
//					default:
//						sb.Append(Message.Replace("\r\n", "<br>"));
//						break;
//				}
//				return sb.ToString();
				return new HtmlNoticeMessage(this.Message, exceptionLevel).ToHtml();
// 管理番号K26528 To
			}
		}

		/// <summary>
		/// 例外を説明するメッセージ。
		/// </summary>
		public override string Message
		{
			get
			{
				if (this.message != null)
				{
					return message;
				}
				else
				{
					return base.Message;
				}
			}
		}

		#endregion

		#region Methods
		/// <summary>
		/// 例外をログに出力します。
		/// </summary>
		/// <returns>
		/// ログ出力後のこのインスタンスへの参照。
		/// </returns>
		public AllegroException WriteLog()
		{
			AllegroLog.Write(this);
			return this;
		}

		/// <summary>
		/// 参考情報とともに例外をログに出力します。
		/// </summary>
		/// <param name="referenceInformation">
		/// 参考情報
		/// </param>
		/// <returns>
		/// ログ出力後のこのインスタンスへの参照。
		/// </returns>
// 管理番号K27230 From
//		public AllegroException WriteLog(string referenceInformation)
//		{
//			AllegroLog.Write(this, referenceInformation);
		public AllegroException WriteLog(BL.SqlClient.SqlPString referenceInformation)
		{
			AllegroLog.Write(this, (string)referenceInformation);
// 管理番号K27230 To
			return this;
		}
		#endregion

		#region Override Methods
		/// <summary>
		/// 現在の例外に関する情報を使用して<see cref="SerializationInfo"/>を設定します。
		/// </summary>
		/// <param name="info">
		/// スローされている例外に関するシリアル化済みオブジェクト データを保持している<see cref="SerializationInfo"/>。
		/// </param>
		/// <param name="context">
		/// 転送元または転送先に関するコンテキスト情報を含んでいる<see cref="StreamingContext"/>。
		/// </param>
		public override void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			info.AddValue("machineName", machineName, typeof(string));
			info.AddValue("commonData", commonData, typeof(CommonData));
			info.AddValue("exceptionLevel", exceptionLevel, typeof(ExceptionLevel));
			info.AddValue("message", message, typeof(string));
			base.GetObjectData(info, context);
		}
		
		#endregion
	}
}
