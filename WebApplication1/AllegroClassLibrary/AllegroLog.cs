// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : AllegroLog.cs
// 機能名      : ログ出力
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// Plat002 ログ機能バージョンアップ 2004/10/04
// Plat002-001 ログ機能バージョンアップテストによるトレースレベル不具合の修正 2004/10/26
// 1.2.2 2004/10/31
// Plat014 イベントログメッセージの文字数制限 2004/11/25
// 1.2.4 2004/11/30
// Plat016 ログ書出し順を [イベントログ] -> [SQLServer] の順に変更 2004/12/07
// 1.3.0 2004/12/31
// 管理番号 K21502 2009/03/31 .NETバージョンアップ
// 1.6.0 2009/09/30
// 管理番号 K24546 2012/08/01 多言語化対応
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 3.1.0 2020/06/30
// 管理番号K27230 2021/09/06 脆弱性対応
// 管理番号K27445 2022/10/12 ログ管理強化
// 3.2.0 2023/03/31

using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
//TODO using Infocom.Allegro.CM.AC;
using Infocom.Allegro.BL.SqlClient;
// Plat002 From
using System.Diagnostics;
// Plat002 To

namespace Infocom.Allegro
{
	/// <summary>
	/// ログ出力に関する共通機能を提供します。このクラスは継承できません。
	/// </summary>
	public sealed class AllegroLog
	{
		#region Constructors
		private AllegroLog()
		{
		}
		#endregion
		
		#region Private Const Fileds
// Plat002 From
		private const string MySourceName = "GRANDIT";
// Plat002 To
		#endregion

		#region Methods
		/// <summary>
		/// 例外レベルとメッセージをログに出力します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="exceptionLevel">
		/// 例外レベル
		/// </param>
		/// <param name="message">
		/// メッセージ
		/// </param>
		public static void Write(CommonData commonData, ExceptionLevel exceptionLevel, string message)
		{
			Write(commonData, message, exceptionLevel, string.Empty, string.Empty);
		}

		/// <summary>
		/// 例外と例外レベルをログに出力します。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="ex">
		/// 例外
		/// </param>
		/// <param name="exceptionLevel">
		/// 例外レベル
		/// </param>
		public static void Write(CommonData commonData, Exception ex, ExceptionLevel exceptionLevel)
		{
			StringBuilder sb = new StringBuilder(2048);

			//例外のソース Exception.Source
// 			sb.Append("Exception Source：").Append(ex.Source); //K24546
			sb.Append(MultiLanguage.Get("CM_AM000445")).Append(ex.Source);
			//例外型 Object.GetType から取得される Type.FullName
// 			sb.Append("\r\n").Append("Exception Type：").Append(ex.GetType().FullName); //K24546
			sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000447")).Append(ex.GetType().FullName);
			//例外メッセージ Exception.Message
// 			sb.Append("\r\n").Append("Message：").Append(ex.Message); //K24546
			sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000492")).Append(ex.Message);
// 			sb.Append("\r\n").Append("HelpLink：").Append(ex.HelpLink); //K24546
			sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000485")).Append(ex.HelpLink);
// 			sb.Append("\r\n").Append("TargetSite：").Append(ex.TargetSite.ToString()); //K24546
			sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000503")).Append(ex.TargetSite.ToString());
			//例外スタック トレース Exception.StackTrace - このトレースは、例外が送出された時点から開始され、呼び出しスタック上で伝播される過程でポピュレートされていきます。
// 			sb.Append("\r\n").Append("StackTrace：").Append(ex.StackTrace); //K24546
			sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000501")).Append(ex.StackTrace);
			
			StringBuilder sb2 = new StringBuilder(1024);
			//例外の日付と時刻 DateTime.Now
// 			sb2.Append("DateTime：").Append(DateTime.Now); //K24546
			sb2.Append(MultiLanguage.Get("CM_AM000438")).Append(DateTime.Now);
			//マシン名 Environment.MachineName
// 			sb2.Append("\r\n").Append("MachineName：").Append(Environment.MachineName); //K24546
			sb2.Append("\r\n").Append(MultiLanguage.Get("CM_AM000490")).Append(Environment.MachineName);
			//アプリケーション ドメイン名 AppDomain.FriendlyName				
// 			sb2.Append("\r\n").Append("ApplicationDomainName：").Append(AppDomain.CurrentDomain.FriendlyName); //K24546
			sb2.Append("\r\n").Append(MultiLanguage.Get("CM_AM000431")).Append(AppDomain.CurrentDomain.FriendlyName);
			//アセンブリ名 System.Reflection 名前空間の中の AssemblyName.FullName
			//アセンブリ バージョン AssemblyName.FullName に含まれています。
// 			sb2.Append("\r\n").Append("AssemblyName：").Append(Assembly.GetCallingAssembly().FullName); //K24546
			sb2.Append("\r\n").Append(MultiLanguage.Get("CM_AM000432")).Append(Assembly.GetCallingAssembly().FullName);
			//スレッド ID AppDomain.GetCurrentThreadId
// 			sb2.Append("\r\n").Append("Thread ID：").Append(Thread.CurrentThread.ManagedThreadId.ToString()); //K24546
			sb2.Append("\r\n").Append(MultiLanguage.Get("CM_AM000504")).Append(Thread.CurrentThread.ManagedThreadId.ToString());
			//スレッド ユーザー System.Threading 名前空間の中の Thread.CurrentPrincipal
// 			sb2.Append("\r\n").Append("Thread User：").Append(Thread.CurrentPrincipal); //K24546
			sb2.Append("\r\n").Append(MultiLanguage.Get("CM_AM000505")).Append(Thread.CurrentPrincipal);

			Write(commonData, ex.Message, exceptionLevel, sb.ToString(), sb2.ToString());
		}

		/// <summary>
		/// 例外をログに出力します。
		/// </summary>
		/// <param name="ex">
		/// 例外
		/// </param>
		internal static void Write(AllegroException ex)
		{
			Write(ex, string.Empty);
		}

		/// <summary>
		/// 例外と参考情報をログに出力します。
		/// </summary>
		/// <param name="ex">
		/// 例外
		/// </param>
		/// <param name="referenceInformation">
		/// 参考情報
		/// </param>
		internal static void Write(AllegroException ex, string referenceInformation)
		{
			StringBuilder sb = new StringBuilder(2048);
			if (ex.InnerException is SqlException)
			{
// 				sb.Append("Exception Source：").Append(((SqlException) ex.InnerException).Source); //K24546
				sb.Append(MultiLanguage.Get("CM_AM000445")).Append(((SqlException)ex.InnerException).Source);
// 				sb.Append("\r\n").Append("Exception Type：").Append(((SqlException) ex.InnerException).GetType().FullName); //K24546
				sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000447")).Append(((SqlException)ex.InnerException).GetType().FullName);
// 				sb.Append("\r\n").Append("Message：").Append(((SqlException) ex.InnerException).Message); //K24546
				sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000492")).Append(((SqlException)ex.InnerException).Message);
// 				sb.Append("\r\n").Append("HelpLink：").Append(((SqlException) ex.InnerException).HelpLink); //K24546
				sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000485")).Append(((SqlException)ex.InnerException).HelpLink);
// 				sb.Append("\r\n").Append("TargetSite：").Append(((SqlException) ex.InnerException).TargetSite.ToString()); //K24546
				sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000503")).Append(((SqlException)ex.InnerException).TargetSite.ToString());
// 				sb.Append("\r\n").Append("Exception StackTrace：").Append(((SqlException) ex.InnerException).StackTrace); //K24546
				sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000446")).Append(((SqlException)ex.InnerException).StackTrace);
// 				sb.Append("\r\n").Append("Server：").Append(((SqlException) ex.InnerException).Server); //K24546
				sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000500")).Append(((SqlException)ex.InnerException).Server);
// 				sb.Append("\r\n").Append("Procedure：").Append(((SqlException) ex.InnerException).Procedure); //K24546
				sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000496")).Append(((SqlException)ex.InnerException).Procedure);
// 				sb.Append("\r\n").Append("LineNumber：").Append(((SqlException) ex.InnerException).LineNumber); //K24546
				sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000489")).Append(((SqlException)ex.InnerException).LineNumber);
// 				sb.Append("\r\n").Append("Class：").Append(((SqlException) ex.InnerException).Class); //K24546
				sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000435")).Append(((SqlException)ex.InnerException).Class);
// 				sb.Append("\r\n").Append("Number：").Append(((SqlException) ex.InnerException).Number); //K24546
				sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000495")).Append(((SqlException)ex.InnerException).Number);
// 				sb.Append("\r\n").Append("State：").Append(((SqlException) ex.InnerException).State);		 //K24546
				sb.Append("\r\n").Append(MultiLanguage.Get("CM_AM000502")).Append(((SqlException)ex.InnerException).State);
			}
			Write(ex.CommonData, ex.Message, ex.ExceptionLevel, sb.ToString(), referenceInformation);
		}		
// Plat002 From

// Plat002 コメント削除
		/// <summary>
		/// ログ出力処理の本体です。
		/// </summary>
		/// <param name="commonData">
		/// 共通データ
		/// </param>
		/// <param name="message">
		/// メッセージ
		/// </param>
		/// <param name="exceptionLevel">
		/// 例外レベル
		/// </param>
		/// <param name="exceptionDesc">
		/// 例外内容
		/// </param>
		/// <param name="referenceInformation">
		/// 参考情報
		/// </param>
		private static void Write(CommonData commonData, string message, ExceptionLevel exceptionLevel, string exceptionDesc, string referenceInformation)
		{
//Plat002-001 From
//			if ((commonData.TraceLevel == TraceLevel.Verbose) ||
//				((commonData.TraceLevel == TraceLevel.Info) && (exceptionLevel <= ExceptionLevel.Info)) || 
//				((commonData.TraceLevel == TraceLevel.Warning) && (exceptionLevel <= ExceptionLevel.Warning)) || 
//				((commonData.TraceLevel == TraceLevel.Error) && (exceptionLevel <= ExceptionLevel.Error)) || 
//				((commonData.TraceLevel == TraceLevel.FatalError) && (exceptionLevel <= ExceptionLevel.FatalError)) || 
//				((commonData.TraceLevel == TraceLevel.Undefined) && (exceptionLevel <= ExceptionLevel.Undefined)))
			
			if ((commonData.TraceLevel == TraceLevel.Verbose) ||
				((commonData.TraceLevel == TraceLevel.Info) && (exceptionLevel >= ExceptionLevel.Info)) || 
				((commonData.TraceLevel == TraceLevel.Warning) && (exceptionLevel >= ExceptionLevel.Warning)) || 
				((commonData.TraceLevel == TraceLevel.Error) && (exceptionLevel >= ExceptionLevel.Error)) || 
				((commonData.TraceLevel == TraceLevel.FatalError) && (exceptionLevel >= ExceptionLevel.FatalError)) || 
				((commonData.TraceLevel == TraceLevel.Undefined) && (exceptionLevel >= ExceptionLevel.Undefined)))
//Plat002-001 To	
			{	
				bool myBool = false;
				
// Plat016 From
				//ログのイベントログ書込み処理
				try
				{
					myBool = MyComp.GetIsLogWriteToEventLog( commonData.CompCode );
				}
				catch ( Exception )
				{
					myBool = false;	//初期値はfalse
				}
				if ( myBool )
				{
					try
					{					
						EventLogEntryType myEventLogEntryType;
						//例外レベルの変換
						switch( exceptionLevel )
						{
								//冗長->情報
							case ExceptionLevel.Verbose:
								myEventLogEntryType = EventLogEntryType.Information;
								break;
								//情報->情報
							case ExceptionLevel.Info:
								myEventLogEntryType = EventLogEntryType.Information;
								break;						
								//警告->警告
							case ExceptionLevel.Warning:
								myEventLogEntryType = EventLogEntryType.Warning;
								break;
								//エラー->エラー
							case ExceptionLevel.Error:
								myEventLogEntryType = EventLogEntryType.Error;
								break;
								//致命的エラー->エラー
							case ExceptionLevel.FatalError:
								myEventLogEntryType = EventLogEntryType.Error;
								break;
								//未定義->情報
							case ExceptionLevel.Undefined:
								myEventLogEntryType = EventLogEntryType.Information;
								break;
								//デフォルト->情報
							default:
								myEventLogEntryType = EventLogEntryType.Information;
								break;
						}
						//メッセージに会社コード,プログラム,利用者名の情報を埋め込む
						StringBuilder sb = new StringBuilder();
// 						sb.Append( "会社コード [ " ); //K24546
						sb.Append(MultiLanguage.Get("CM_AM000750"));
						sb.Append( (string) commonData.CompCode );
						sb.Append( " ]\n" );
// 						sb.Append( "プログラム [ " ); //K24546
						sb.Append(MultiLanguage.Get("CM_AM000655"));
						sb.Append( (string) commonData.PageID );
						sb.Append( " ]\n" );
// 						sb.Append( "利用者名 [ " ); //K24546
						sb.Append(MultiLanguage.Get("CM_AM001426"));
						sb.Append( (string) commonData.UserName );
						sb.Append( " ]\n" );
// 管理番号K27445 From
						// 例外レベル [ 
						sb.Append(MultiLanguage.Get("CM_AM001843"));
						sb.Append(exceptionLevel.ToString().ToUpper());
						sb.Append(" ]\n");
// 管理番号K27445 To
						sb.Append( message );
						//message = "会社コード [ " + ( (string) commonData.CompCode ) + " ] : " + message;

						//Plat014 From
						//						EventLog.WriteEntry( MySourceName, sb.ToString(), myEventLogEntryType );
						
						//メッセージの文字数を約1024とする
						string str1023 = sb.ToString();
						if ( str1023.Length >= 1023 )
						{
							str1023 = str1023.Substring( 0,1022 );
						}						
						EventLog.WriteEntry( MySourceName, str1023, myEventLogEntryType );
						//Plat014 To

					}
					catch( Exception )
					{
					}
				}
// Plat016 To

				//ログのDB書込み処理
				try
				{
					myBool = MyComp.GetIsLogWriteToDatabase( commonData.CompCode );
				}
				catch ( Exception )
				{
					myBool = true;	//初期値はtrue
				}				
				if ( myBool )
				{
					//TODO BL_CM_AC_Log.Write(commonData, message, exceptionLevel, exceptionDesc, referenceInformation);
					StringBuilder sb = new StringBuilder(512);
					sb.Append("INSERT INTO ");
					sb.Append(DBAccess.GetDBSchema(commonData.CompCode, UnitID.CM,"[LOG]"));
					sb.Append("([MESSAGE]");
					sb.Append(",[EXCEPTION_LEVEL]");
					sb.Append(",[EXCEPTION_DESC]");
					sb.Append(",[REF_INFO]");
					sb.Append(",[INSERT_USER_NAME]");
					sb.Append(",[INSERT_PRG_NAME])");
					sb.Append(" VALUES ");
					sb.Append("(@Message");
					sb.Append(",@ExceptionLevel");
					sb.Append(",@ExceptionDesc");
					sb.Append(",@RefInfo");
					sb.Append(",@InsertUserName");
					sb.Append(",@InsertPrgName)");
				
//					SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData.CompCode)); //K24546
					SqlConnection cn = new SqlConnection(DBAccess.GetConnectionString(commonData));
					SqlCommandWrapper cm = new SqlCommandWrapper(sb.ToString(), cn);	// 管理番号K27230

					cm.Parameters.Add("@Message", SqlDbType.NVarChar, 500).Value = ConvertDBData.ToNVarChar(message);
					cm.Parameters.Add("@ExceptionLevel", SqlDbType.NVarChar, 10).Value = ConvertDBData.ToNVarChar(exceptionLevel.ToString());
					cm.Parameters.Add("@ExceptionDesc", SqlDbType.NVarChar, 2000).Value = ConvertDBData.ToNVarChar(exceptionDesc);
					cm.Parameters.Add("@RefInfo", SqlDbType.NVarChar, 1000).Value = ConvertDBData.ToNVarChar(referenceInformation);
					cm.Parameters.Add("@InsertUserName", SqlDbType.NVarChar, 50).Value = ConvertDBData.ToNVarChar(commonData.UserName);
					cm.Parameters.Add("@InsertPrgName", SqlDbType.NVarChar, 50).Value = ConvertDBData.ToNVarChar(commonData.PageID);

					cn.Open();
					try
					{
						cm.ExecuteNonQuery();
					}
					catch (SqlException ex)
					{
						throw (ex);
					}
					finally
					{
						cn.Close();
					}
				}				
				
				//ログのテキストファイル書込み処理
				try
				{
					myBool = MyComp.GetIsLogWriteToTextFile( commonData.CompCode );
				}
				catch ( Exception )
				{
					myBool = false;	//初期値はfalse
				}				
				if ( myBool )
				{
					//実装未定
				}				
			}
		}
// Plat002 To
		#endregion
	}
}
