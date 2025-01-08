// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : AllegroMessage.cs
// 機能名      : メッセージ定義
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 1.1.0 2004/06/30
// 1.1.2 2004/08/31
// 1.2.0 2004/09/30
// 1.2.2 2004/10/31
// 1.2.3 2004/11/15
// 1.2.4 2004/11/30
// 1.3.0 2004/12/31
// 1.3.2 2005/03/31
// 1.3.3 2005/06/30
// 1.4.0 2005/10/31
// 1.5.0 2006/03/31
// 1.5.1 2007/06/30
// 1.5.2 2007/10/31
// 1.6.0 2009/09/30
// 2.0.0 2012/10/31
// 2.1.0 2013/03/31
// 2.2.0 2014/10/31
// 2.3.0 2016/06/30
// 3.0.0 2018/04/30
// 3.1.0 2020/06/30
// 3.2.0 2023/03/31

using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Infocom.Allegro
{
	/// <summary>
	/// アプリケーションで使用されるメッセージを管理します。
	/// </summary>
	public sealed class AllegroMessage
	{
		#region Constructor
		private AllegroMessage()
		{
		}
		#endregion


// 		public static readonly string Default = "メッセージが指定されていない例外が発生しました。";
		public static string Default
		{
			get {return MultiLanguage.Get("CM_AM000669");}
		}


		#region 共通メッセージ（画面用）
		#region S00000
		/// <summary>
		/// 更新しました。
		/// </summary>

// 		public static readonly string S00001 = "更新しました。";
		public static string S00001
		{
			get {return MultiLanguage.Get("CM_AM000905");}
		}

		/// <summary>
		/// %s： %s を更新しました。
		/// </summary>
		/// <param name="name"></param>
		/// <param name="code"></param>
		/// <returns><paramref name="name"/>： <paramref name="code"/> を更新しました。</returns>
		public static string S00002(string name, string code)
		{

// 			return new StringBuilder(name, 32).Append("： ").Append(code).Append(" を更新しました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001618"), name, code);

		}
		/// <summary>
		/// 削除しました。
		/// </summary>

// 		public static readonly string S00003 = "削除しました。";
		public static string S00003
		{
			get {return MultiLanguage.Get("CM_AM000952");}
		}

		/// <summary>
		/// 検索対象データが %d 件あります。検索を実行しますか？
		/// </summary>
		/// <param name="count">件数</param>
		/// <returns>検索対象データが <paramref name="count"/> 件あります。検索を実行しますか？</returns>
		public static string S00004(int count)
		{

// 			return new StringBuilder("検索対象データが ").Append(count.ToString("#,##0")).Append(" 件あります。検索を実行しますか？").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001431"), count.ToString("#,##0"));

		}
		/// <summary>
		/// 検索対象データが %d %dあります。検索を実行しますか？
		/// </summary>
		/// <param name="count">件数</param>
		/// <param name="unit">単位</param>
		/// <returns>検索対象データが <paramref name="count"/> <paramref name="unit"/>あります。検索を実行しますか？</returns>
		public static string S00004(int count, string unit)
		{

// 			return new StringBuilder("検索対象データが ").Append(count.ToString("#,##0")).Append(" ").Append(unit).Append("あります。検索を実行しますか？").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001432"), count.ToString("#,##0"), unit);

		}
		/// <summary>
		/// %s： %s を削除しました。
		/// </summary>
		/// <param name="name"></param>
		/// <param name="code"></param>
		/// <returns><paramref name="name"/>： <paramref name="code"/> を削除しました。</returns>
		public static string S00005(string name, string code)
		{

// 			return new StringBuilder(name, 32).Append("： ").Append(code).Append(" を削除しました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001433"), name, code);

		}
		/// <summary>
		/// %d 件の %s を 登録しました。
		/// </summary>
		/// <param name="count">件数</param>
		/// <param name="name">項目名</param>
		/// <returns><paramref name="count"/> 件の <paramref name="item"/> を登録しました。</returns>
		public static string S00006(int count, string name)
		{

// 			return new StringBuilder(count.ToString("#,##0")).Append(" 件の ").Append(name).Append(" を登録しました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001434"), count.ToString("#,##0"), name);

		}
		/// <summary>
		/// 取消しました。
		/// </summary>

// 		public static readonly string S00007 = "取消しました。";
		public static string S00007
		{
			get {return MultiLanguage.Get("CM_AM001097");}
		}

		/// <summary>
		/// %s を取消しました。
		/// </summary>
		/// <param name="name"></param>
		/// <returns><paramref name="name"/> を取消しました。</returns>
		public static string S00008(string name)
		{

// 			return new StringBuilder(name, 32).Append(" ").Append(" を取消しました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001435"), name);

		}
		/// <summary>
		/// 実行しました。
		/// </summary>

// 		public static readonly string S00009 = "実行しました。";
		public static string S00009
		{
			get {return MultiLanguage.Get("CM_AM001077");}
		}

		/// <summary>
		/// %d 件の%sを取り込みました。
		/// </summary>
		/// <param name="count">件数</param>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="name"/> 件の<paramref name="name"/>を取り込みました。</returns>
		public static string S00010(int count, string item)
		{

// 			return new StringBuilder(count.ToString("#,##0"), 32).Append(" 件の ").Append(item).Append(" を取り込みました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001436"), count.ToString("#,##0"), item);

		}
		/// <summary>
		/// ［%s］が変更されています。破棄しますか？
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］が変更されています。破棄しますか？</returns>
		public static string S00011(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］が変更されています。破棄しますか？").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001437"), item);

		}
		/// <summary>
		/// %d 件コピーしました。
		/// </summary>
		/// <param name="count">件数</param>
		/// <returns><paramref name="count"/> 件コピーしました。</returns>
		public static string S00012(int count)
		{

// 			return new StringBuilder(count.ToString("#,##0")).Append(" 件コピーしました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001438"), count.ToString("#,##0"));

		}
		/// <summary>
		/// %sを作成しました。
		/// </summary>
		/// <param name="item">作成データ名</param>
		/// <returns><paramref name="item1"/>を作成しました。</returns>
		public static string S00013(string item)
		{

// 			return new StringBuilder(item, 32).Append("を作成しました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001439"), item);

		}
		/// <summary>
		/// スケジュールに登録しました。
		/// </summary>

// 		public static readonly string S00014 = "スケジュールに登録しました。";
		public static string S00014
		{
			get {return MultiLanguage.Get("CM_AM000574");}
		}

		/// <summary>
		/// 締処理を開始しました。
		/// </summary>

// 		public static readonly string S00015 = "締処理を開始しました。";
		public static string S00015
		{
			get {return MultiLanguage.Get("CM_AM001258");}
		}

		/// <summary>
		/// 承認しました。
		/// </summary>

// 		public static readonly string S00016 = "承認しました。";
		public static string S00016
		{
			get {return MultiLanguage.Get("CM_AM001147");}
		}

		/// <summary>
		/// 承認取消しました。
		/// </summary>

// 		public static readonly string S00017 = "承認取消しました。";
		public static string S00017
		{
			get {return MultiLanguage.Get("CM_AM001151");}
		}

		/// <summary>
		/// 承認処理を実行しました。
		/// </summary>

// 		public static readonly string S00018 = "承認処理を実行しました。";
		public static string S00018
		{
			get {return MultiLanguage.Get("CM_AM001153");}
		}

		/// <summary>
		/// 承認取消処理を実行しました。
		/// </summary>

// 		public static readonly string S00019 = "承認取消処理を実行しました。";
		public static string S00019
		{
			get {return MultiLanguage.Get("CM_AM001152");}
		}

		/// <summary>
		/// 更新してよろしいですか？
		/// </summary>
		public static string S00020
		{
			get {return MultiLanguage.Get("CM_AM001785");}
		}

		#endregion
		#region S10000
		/// <summary>
		/// 空きコードが取得できません。
		/// </summary>

// 		public static readonly string S10001 = "空きコードが取得できません。";
		public static string S10001
		{
			get {return MultiLanguage.Get("CM_AM000847");}
		}

		/// <summary>
		/// 対象データが見つかりません。
		/// </summary>

// 		public static readonly string S10002 = "対象データが見つかりません。";
		public static string S10002
		{
			get {return MultiLanguage.Get("CM_AM001230");}
		}

		/// <summary>
		/// 明細行が既に最大行数 %d 行まで登録されています。
		/// </summary>
		/// <param name="maxCount">最大明細行数</param>
		/// <returns>明細行が既に最大行数 <paramref name="maxCount"/> 行まで登録されています。</returns>
		public static string S10003(int maxCount)
		{

// 			return new StringBuilder("明細行が既に最大行数 ", 32).Append(maxCount).Append(" 行まで登録されています。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001440"), maxCount);

		}
		/// <summary>
		/// ［%s］ は既に登録されています。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ は既に登録されています。</returns>
		public static string S10004(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ は既に登録されています。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001441"), item);

		}
		/// <summary>
		/// ［%s］ を先に入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ を先に入力してください。</returns>
		public static string S10005(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ を先に入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001442"), item);

		}
		/// <summary>
		/// ［%s］ は必須です。
		/// </summary>
		/// <param name="item0">項目名</param>
		/// <returns>［<paramref name="item0"/>］ は必須です。</returns>
		public static string S10006(string item0)
		{

// 			return new StringBuilder("［", 16).Append(item0).Append("］ は必須です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001443"), item0);

		}
		/// <summary>
		/// ［%s］ と ［%s］ と ... は必須です。
		/// </summary>
		/// <param name="items">項目名</param>
		/// <returns>［<paramref name="items"/>］ と ［<paramref name="items"/>］ と ... は必須です。</returns>
		public static string S10006(params string[] items)
		{
			switch (items.Length)
			{
				case 0:
// 					return "必須です。"; 
					return MultiLanguage.Get("CM_AM001357");
				case 1:
					return S10006(items[0]);
				case 2:

// 					return new StringBuilder("［", 32).Append(items[0]).Append("］ と ［").Append(items[1]).Append("］ は必須です。").ToString(); 
					return string.Format(MultiLanguage.Get("CM_AM001444"), items[0], items[1]);

				default:
// 					StringBuilder sb = new StringBuilder("［", 64); 
					StringBuilder sb = new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64);
					foreach (string item in items)
					{
// 						sb.Append(item).Append("］ と ［"); 
						sb.Append(item).Append(MultiLanguage.Get("CM_AM000205"));
					}
					sb.Remove(sb.Length - 3, 3);
// 					sb.Append("は必須です。"); 
					sb.Append(MultiLanguage.Get("CM_AM000646"));
					return sb.ToString();
			}
		}
		/// <summary>
		/// %s 行目： ［%s］ は必須です。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item0">項目名</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item0"/>］ は必須です。</returns>
		public static string S10006(string lineNo, string item0)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item0).Append("］ は必須です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001445"), lineNo, item0);

		}
		/// <summary>
		/// %s 行目： ［%s］ と ［%s］は必須です。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ は必須です。</returns>
		public static string S10006(string lineNo, string item1, string item2)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item1).Append("］ と [").Append(item2).Append("] は必須です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001446"), lineNo, item1, item2);

		}
		/// <summary>
		/// ［%s］ と ［%s］ と ... のうち、どれかは必須です。
		/// </summary>
		/// <param name="items">項目名</param>
		/// <returns>［<paramref name="items"/>］ と ［<paramref name="items"/>］ と ... のうち、どれかは必須です。</returns>
		public static string S10007(params string[] items)
		{
			switch (items.Length)
			{
				case 0:
// 					return "必須です。"; 
					return MultiLanguage.Get("CM_AM001357");
				case 1:
					return S10006(items[0]);
				case 2:

// 					return new StringBuilder("［", 32).Append(items[0]).Append("］ と ［").Append(items[1]).Append("］ のどちらかは必須です。").ToString(); 
					return string.Format(MultiLanguage.Get("CM_AM001447"), items[0], items[1]);

				default:
// 					StringBuilder sb = new StringBuilder("［", 64); 
					StringBuilder sb = new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64);
					foreach (string item in items)
					{
// 						sb.Append(item).Append("］ と ［"); 
						sb.Append(item).Append(MultiLanguage.Get("CM_AM000205"));
					}
					sb.Remove(sb.Length - 3, 3);
// 					sb.Append("のうち、どれかは必須です。"); 
					sb.Append(MultiLanguage.Get("CM_AM000618"));
					return sb.ToString();
			}
		}
		/// <summary>
		/// ［%s］ 入力時に、 ［%s］ は必須です。
		/// </summary>
		/// <param name="condition">条件</param>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="condition"/>］ 入力時に、 ［<paramref name="item"/>］ は必須です。</returns>
		public static string S10008(string condition, string item)
		{

// 			return new StringBuilder("［", 32).Append(condition).Append("］ 入力時に、 ［").Append(item).Append("］ は必須です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001448"), condition, item);

		}
		/// <summary>
		/// ［%s］ 選択時に、 ［%s］ は必須です。
		/// </summary>
		/// <param name="condition">条件</param>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="condition"/>］ 選択時に、 ［<paramref name="item"/>］ は必須です。</returns>
		public static string S10009(string condition, string item)
		{

// 			return new StringBuilder("［", 32).Append(condition).Append("］ 選択時に、 ［").Append(item).Append("］ は必須です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001449"), condition, item);

		}
		/// <summary>
		/// ［%s］ は 1 つ以上選択してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ は 1 つ以上選択してください。</returns>
		public static string S10010(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ は 1 つ以上選択してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001450"), item);

		}
		/// <summary>
		/// ［%s］ の書式が不正です。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ の書式が不正です。</returns>
		public static string S10011(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ の書式が不正です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001451"), item);

		}
		/// <summary>
		/// ［%s］ は%s入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="expression">入力すべき表現</param>
		/// <returns>［<paramref name="item"/>］ は<paramref name="expression"/>入力してください。</returns>
		public static string S10012(string item, string expression)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ は").Append(expression).Append("入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001452"), item, expression);

		}
		/// <summary>
		/// ［%s］ は ［%s］ 以降の日付で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ は ［<paramref name="item2"/>］ 以降の日付で入力してください。</returns>
		public static string S10013(string item1, string item2)
		{

// 			return new StringBuilder("［", 64).Append(item1).Append("］ は ［").Append(item2).Append("］ 以降の日付で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001453"), item1, item2);

		}
		/// <summary>
		/// ［%s］ は ［%s］ 以降の番号で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ は ［<paramref name="item2"/>］ 以降の番号で入力してください。</returns>
		public static string S10014(string item1, string item2)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］ は ［").Append(item2).Append("］ 以降の番号で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001454"), item1, item2);

		}
		/// <summary>
		/// ［%s］ はオーバーフローしました。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ はオーバーフローしました。</returns>
		public static string S10015(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ はオーバーフローしました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001455"), item);

		}
		/// <summary>
		/// %s 行目： ［%s］ はオーバーフローしました。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item"/>］ はオーバーフローしました。</returns>
		public static string S10015(string lineNo, string item)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item).Append("］ はオーバーフローしました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001456"), lineNo, item);

		}
		/// <summary>
		/// ［%s］ は、 %s ～ %s の範囲で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="minValue">最小値</param>
		/// <param name="maxValue">最大値</param>
		/// <returns>［<paramref name="item"/>］ は、 <paramref name="minValue"/> ～ <paramref name="maxValue"/> の範囲で入力してください。</returns>
		public static string S10016(string item, string minValue, string maxValue)
		{

// 			return new StringBuilder("［", 64).Append(item).Append("］ は、 ").Append(minValue).Append(" ～ ").Append(maxValue).Append(" の範囲で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001457"), item, minValue, maxValue);

		}
		/// <summary>
		/// ［%s］ は ［%s］ 以上で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ は ［<paramref name="item2"/>］ 以上で入力してください。</returns>
		public static string S10017(string item1, string item2)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］ は ［").Append(item2).Append("］ 以上で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001458"), item1, item2);

		}
		/// <summary>
		///  %s 行目： ［%s］ は ［%s］ 以上で入力してください。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item1"/>］ は［ <paramref name="item2"/>］ 以上で入力してください。</returns>
		public static string S10017(string lineNo, string item1, string item2)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item1).Append("］ は ［").Append(item2).Append("］ 以上で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001459"), lineNo, item1, item2);

		}
		/// <summary>
		/// ［%s］ 以上で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ 以上で入力してください。</returns>
		public static string S10018(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ 以上で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001460"), item);

		}
		/// <summary>
		/// %s はシステムで予約されているコードです。
		/// </summary>
		/// <param name="code">予約されているコード</param>
		/// <returns><paramref name="code"/> はシステムで予約されているコードです。</returns>
		public static string S10019(string code)
		{

// 			return new StringBuilder(code, 32).Append(" はシステムで予約されているコードです。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001461"), code);

		}
		/// <summary>
		/// ［%s］ は %d 文字以内で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="maxLength">最大の長さ</param>
		/// <returns>［<paramref name="item"/>］ は <paramref name="maxLength"/> 文字以内で入力してください。</returns>
		public static string S10020(string item, int maxLength)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ は ").Append(maxLength).Append(" 文字以内で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001462"), item, maxLength);

		}
		/// <summary>
		/// ［%s］ は半角英数字で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ は半角英数字で入力してください。</returns>
		public static string S10021(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ は半角英数字で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001463"), item);

		}
		/// <summary>
		/// ［%s］ は半角カタカナで入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ は半角カタカナで入力してください。</returns>
		public static string S10022(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ は半角カタカナで入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001464"), item);

		}
		/// <summary>
		/// ［%s］ にマイナスの数は指定できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ にマイナスの数は指定できません。</returns>
		public static string S10023(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ にマイナスの数は指定できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001465"), item);

		}
		/// <summary>
		/// ［%s］ は %d 桁以内で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="precision">桁数</param>
		/// <returns>［<paramref name="item"/>］ は <paramref name="precision"/> 桁以内で入力してください。</returns>
		public static string S10024(string item, byte precision)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ は ").Append(precision).Append(" 桁以内で入力してください。（小数は使用できません。）").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001466"), item, precision);

		}
		/// <summary>
		/// ［%s］ は %d 桁（小数点以下 %d 桁）以内で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="precision">桁数</param>
		/// <param name="scale">小数部の桁数</param>
		/// <returns>［<paramref name="item"/>］ は <paramref name="precision"/> 桁（小数点以下 <paramref name="scale"/> 桁）以内で入力してください。</returns>
		public static string S10024(string item, byte precision, byte scale)
		{

// 			return new StringBuilder("［", 64).Append(item).Append("］ は ").Append(precision).Append(" 桁（小数点以下 ").Append(scale).Append(" 桁）以内で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001467"), item, precision, scale);

		}
		/// <summary>
		/// ［%s］ は %s 以降、 %s 以前の日付で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="minDate">最小値</param>
		/// <param name="maxDate">最大値</param>
		/// <returns>［<paramref name="item"/>］ は <paramref name="minDate"/> 以降、 <paramref name="maxDate"/> 以前の日付で入力してください。</returns>
		public static string S10025(string item, string minDate, string maxDate)
		{

// 			return new StringBuilder("［", 64).Append(item).Append("］ は ").Append(minDate).Append(" 以降、 ").Append(maxDate).Append(" 以前の日付で入力してください。").ToString();  
			return string.Format(MultiLanguage.Get("CM_AM001468"), item, minDate, maxDate);

		}
		/// <summary>
		/// ［%s］ の値が許容範囲外です。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ の値が許容範囲外です。</returns>
		public static string S10026(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ の値が許容範囲外です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001469"), item);

		}
		/// <summary>
		/// ［%s］ は親番 %d 文字、枝番 %d 文字で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="mainCodeLength">親番の桁数</param>
		/// <param name="subCodeLength">枝番の桁数</param>
		/// <returns>［<paramref name="item"/>］ は親番 <paramref name="mainCodeLength"/> 文字、枝番 <paramref name="subCodeLength"/> 文字で入力してください。</returns>
		public static string S10027(string item, byte mainCodeLength, byte subCodeLength)
		{

// 			return new StringBuilder("［", 64).Append(item).Append("］ は親番 ").Append(mainCodeLength).Append(" 文字、枝番 ").Append(subCodeLength).Append(" 文字で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001470"), item, mainCodeLength, subCodeLength);

		}
		/// <summary>
		/// \v該当データなし
		/// </summary>
		/// <remarks><see cref="Infocom.Allegro.Web.WebControls.EncodeLabel"/> の <b>Text</b> プロパティに指定すると赤い文字で「該当データなし」と表示されます。</remarks>

// 		public static readonly string S10028 = "\v該当データなし";
		public static string S10028
		{
			get {return MultiLanguage.Get("CM_AM000423");}
		}

		/// <summary>
		/// ［%s］ と ［%s］ が異なる場合、どちらかは基軸通貨を指定してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ が異なる場合、どちらかは基軸通貨を指定してください。</returns>
		public static string S10029(string item1, string item2)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］ と ［").Append(item2).Append("］ が異なる場合、どちらかは基軸通貨を指定してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001471"), item1, item2);

		}
		/// <summary>
		/// ［%s］ と ［%s］ の組合せが不正です。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ の組合せが不正です。</returns>
		public static string S10030(string item1, string item2)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］ と ［").Append(item2).Append("］ の組合せが不正です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001472"), item1, item2);

		}
		/// <summary>
		/// ［%s］ は%sで既に登録されています。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="value">登録場所</param>
		/// <returns>［<paramref name="item"/>］ は<paramref name="value"/>で既に登録されています。</returns>
		public static string S10031(string item, string value)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ は").Append(value).Append("で既に登録されています。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001473"), item, value);

		}
		/// <summary>
		/// %s 行目： ［%s］ はマスタにないか、有効ではありません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item"/>］ はマスタにないか、有効ではありません。</returns>
		public static string S10032(string lineNo, string item)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item).Append("］ はマスタにないか、有効ではありません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001474"), lineNo, item);

		}
		/// <summary>
		/// %s 行目： ［%s］ の ［%s］ にマイナスの数は指定できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item1"/>］ の ［<paramref name="item2"/>］ にマイナスの数は指定できません。</returns>
		public static string S10033(string lineNo, string item1, string item2)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item1).Append("］ の ［").Append(item2).Append("］ にマイナスの数は指定できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001475"), lineNo, item1, item2);

		}
		/// <summary>
		/// %s 行目： ［%s］ が存在しません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item"/>］ が存在しません。</returns>
		public static string S10034(string lineNo, string item)
		{

// 			return new StringBuilder(lineNo, 32).Append(" 行目： ［").Append(item).Append("］ が存在しません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001476"), lineNo, item);

		}
		/// <summary>
		/// %sは必須です。
		/// </summary>
		/// <param name="value">値</param>
		/// <returns><paramref name="value"/>は必須です。</returns>
		public static string S10035(string value)
		{

// 			return new StringBuilder(value, 16).Append("は必須です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001477"), value);

		}
		/// <summary>
		/// %d 件中 %d 件更新しました。
		/// </summary>
		/// <param name="totalCount">更新対象数</param>
		/// <param name="count">更新数</param>
		/// <returns><paramref name="totalCount"/> 件中 <paramref name="count"/> 件更新しました。</returns>
		public static string S10036(int totalCount, int count)
		{

// 			return new StringBuilder(totalCount.ToString("#,##0"), 32).Append(" 件中 ").Append(count.ToString("#,##0")).Append(" 件更新しました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001478"), totalCount.ToString("#,##0"), count.ToString("#,##0"));

		}
		/// <summary>
		/// %d 件中 %d 件更新しました。更新できなかった ［%s］ は以下の通りです。
		/// </summary>
		/// <param name="totalCount">更新対象数</param>
		/// <param name="count">更新数</param>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="totalCount"/> 件中 <paramref name="count"/> 件更新しました。更新できなかった ［<paramref name="item"/>］ は以下の通りです。</returns>
		public static string S10036(int totalCount, int count, string item)
		{

// 			return new StringBuilder(totalCount.ToString(), 64).Append(" 件中 ").Append(count.ToString("#,##0")).Append(" 件更新しました。更新できなかった ［").Append(item).Append("］ は以下の通りです。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001479"), totalCount.ToString("#,##0"), count.ToString("#,##0"), item);

		}
		/// <summary>
		/// ・%s （%s）
		/// </summary>
		/// <param name="code">コード</param>
		/// <param name="reason">理由</param>
		/// <returns>・<paramref name="code"/> （<paramref name="reason"/>）</returns>
		public static string S10037(string code, string reason)
		{

// 			return new StringBuilder("・", 32).Append(code).Append(" （").Append(reason).Append("）").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001480"), code, reason);

		}
		/// <summary>
		/// ・%s （他のユーザによって変更、もしくは削除されました。）
		/// </summary>
		/// <param name="code">コード</param>
		/// <returns>・<paramref name="code"/> （他のユーザによって変更、もしくは削除されました。）</returns>
		public static string S10038(string code)
		{

// 			return new StringBuilder("・", 32).Append(code).Append(" （他のユーザによって変更、もしくは削除されました。）").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001481"), code);

		}
		/// <summary>
		/// 更新対象の行が選択されていません。
		/// </summary>

// 		public static readonly string S10039 = "更新対象の行が選択されていません。";
		public static string S10039
		{
			get {return MultiLanguage.Get("CM_AM000912");}
		}

		/// <summary>
		/// \v未入力
		/// </summary>
		/// <remarks><see cref="Infocom.Allegro.Web.WebControls.EncodeLabel"/> の <b>Text</b> プロパティに指定すると赤い文字で「未入力」と表示されます。</remarks>

// 		public static readonly string S10040 = "\v未入力";
		public static string S10040
		{
			get {return MultiLanguage.Get("CM_AM000427");}
		}

		/// <summary>
		/// 対象データなし
		/// </summary>

// 		public static readonly string S10041 = "対象データなし";
		public static string S10041
		{
			get {return MultiLanguage.Get("CM_AM001231");}
		}

		/// <summary>
		/// ［%s］ と ［%s］ が一致しません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ が一致しません。</returns>
		public static string S10042(string item1, string item2)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］ と ［").Append(item2).Append("］ が一致しません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001482"), item1, item2);

		}
		/// <summary>
		/// ［%s］ と ［%s］ の%sが一致しません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="value">内容</param>
		/// <returns>［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ の<paramref name="value"/>が一致しません。</returns>
		public static string S10042(string item1, string item2, string value)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］ と ［").Append(item2).Append("］ の").Append(value).Append("が一致しません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001483"), item1, item2, value);

		}
		/// <summary>
		/// %s 行目： ［%s］ と ［%s］が一致しません。
		/// </summary>
		/// <param name="lineNo">項目名 1</param>
		/// <param name="item1">項目名 2</param>
		/// <param name="item2">内容</param>
		/// <returns><paramref name="lineNo"/> 行目：［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ が一致しません。</returns>
		public static string S10042(int lineNo, string item1, string item2)
		{

// 			return new StringBuilder(lineNo.ToString() , 64).Append("行目： ［").Append(item1).Append("］ と ［").Append(item2).Append("］ が一致しません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001484"), lineNo.ToString() , item1, item2);

		}
		/// <summary>
		/// %sとき、 ［%s］ は必須です。
		/// </summary>
		/// <param name="condition">条件</param>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="condition"/>とき、 ［<paramref name="item"/>］ は必須です。</returns>
		public static string S10043(string condition, string item)
		{

// 			return new StringBuilder(condition, 32).Append("とき、 ［").Append(item).Append("］ は必須です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001485"), condition, item);

		}
		/// <summary>
		/// ［%s］ が%sとき、 ［%s］ は必須です。
		/// </summary>
		/// <param name="conditionItem">条件の項目名</param>
		/// <param name="condition">条件</param>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="conditionItem"/>］ が<paramref name="condition"/>とき、 ［<paramref name="item"/>］ は必須です。</returns>
		public static string S10044(string conditionItem, string condition, string item)
		{

// 			return new StringBuilder("［", 64).Append(conditionItem).Append("］ が").Append(condition).Append("とき、 ［").Append(item).Append("］ は必須です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001486"), conditionItem, condition, item);

		}
		/// <summary>
		/// ［%s］ が使用中のため更新できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ が使用中のため更新できません。</returns>
		public static string S10045(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ が使用中のため更新できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001487"), item);

		}
		/// <summary>
		/// 同一の ［%s］ が複数個指定されています。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>同一の ［<paramref name="item"/>］ が複数個指定されています。</returns>
		public static string S10046(string item)
		{

// 			return new StringBuilder("同一の ［", 32).Append(item).Append("］ が複数個指定されています。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001488"), item);

		}
		/// <summary>
		/// \v該当なし
		/// </summary>

// 		public static readonly string S10047 = "\v該当なし";
		public static string S10047
		{
			get {return MultiLanguage.Get("CM_AM000424");}
		}

		/// <summary>
		/// ［%s］ に ［%s］ と同じ値は入力できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ に ［<paramref name="item2"/>］ と同じ値は入力できません。</returns>
		public static string S10048(string item1, string item2)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］ に ［").Append(item2).Append("］ と同じ値は入力できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001489"), item1, item2);

		}
		/// <summary>
		/// ［%s］ は ［%s］ 以降のコードで入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ は ［<paramref name="item2"/>］ 以降のコードで入力してください。</returns>
		public static string S10049(string item1, string item2)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］ は ［").Append(item2).Append("］ 以降のコードで入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001490"), item1, item2);

		}
		/// <summary>
		/// ［%s］ は 1 ～ 31 の範囲、または 99 （月末） を入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item1"/>］ は 1 ～ 31 の範囲、または 99 （月末） を入力してください。</returns>
		public static string S10050(string item)
		{

// 			return new StringBuilder("［", 64).Append(item).Append("］ は 1 ～ 31 の範囲、または 99 （月末） を入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001491"), item);

		}
		/// <summary>
		/// ［%s］ はオーバーフローしました。 ［%s］ の整数部が %d 桁以内で算出されるように入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="digit">桁数</param>
		/// <returns>［<paramref name="item"/>］ はオーバーフローしました。［<paramref name="item"/>］の整数部が <paramref name="digit"/> 桁以内で算出されるように入力してください。</returns>
		public static string S10051(string item, byte digit)
		{

// 			return new StringBuilder("［", 64).Append(item).Append("］ はオーバーフローしました。 ［").Append(item).Append("］ の整数部が ").Append(digit).Append(" 桁以内で算出されるように入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001492"), item, item, digit);

		}
		/// <summary>
		/// ［%s］ は ［%s］ 以下で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ は ［<paramref name="item2"/>］ 以下で入力してください。</returns>
		public static string S10052(string item1, string item2)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］ は ［").Append(item2).Append("］ 以下で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001493"), item1, item2);

		}
		/// <summary>
		/// ［%s］ 以下で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ 以下で入力してください。</returns>
		public static string S10053(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ 以下で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001494"), item);

		}
		/// <summary>
		/// %s 行目：［%s］ と ［%s］ のどちらかは必須です。
		/// </summary>
		/// <param name="lineNo"></param>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns></returns>
		public static string S10054(string lineNo, string item1, string item2)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item1).Append("］ と ［").Append(item2).Append("］ のどちらかは必須です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001495"), lineNo, item1, item2);

		}
		/// <summary>
		/// %s 行目： ［%s］ の値が許容範囲外です。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item"/>］ の値が許容範囲外です。</returns>
		public static string S10055(string lineNo, string item)
		{

// 			return new StringBuilder(lineNo, 32).Append(" 行目： ［").Append(item).Append("］ の値が許容範囲外です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001496"), lineNo, item);

		}
		/// <summary>
		/// %s 行目： ［%s］ と ［%s］ の組み合わせが不正です。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ の組み合わせが不正です。</returns>
		public static string S10056(string lineNo, string item1, string item2)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item1).Append("］ と ［").Append(item2).Append("］ の組み合わせが不正です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001497"), lineNo, item1, item2);

		}
		/// <summary>
		/// %s 行目： ［%s］ と ［%s］ が一致しません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ が一致しません。</returns>
		public static string S10057(string lineNo, string item1, string item2)
		{

// 			return new StringBuilder(lineNo, 32).Append(" 行目： ［").Append(item1).Append("］ と ［").Append(item2).Append("］ が一致しません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001498"), lineNo, item1, item2);

		}
		/// <summary>
		/// %s 行目： ［%s］ と ［%s］ の%sが一致しません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="value">内容</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ の<paramref name="value"/>が一致しません。</returns>
		public static string S10057(string lineNo, string item1, string item2, string value)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item1).Append("］ と ［").Append(item2).Append("］ の").Append(value).Append("が一致しません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001499"), lineNo, item1, item2, value);

		}
		/// <summary>
		/// ［%s］ と ［%s］ のどちらかは%s入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="value">内容</param>
		/// <returns>［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ のどちらかは<paramref name="value"/>入力してください。</returns>
		public static string S10058(string item1, string item2, string value)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］ と ［").Append(item2).Append("］ のどちらかは").Append(value).Append("入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001500"), item1, item2, value);

		}
		/// <summary>
		/// %s 行目： ［%s］ と ［%s］ のどちらかは%s入力してください。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="value">内容</param>
		/// <returns>%s 行目： ［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ のどちらかは<paramref name="value"/>入力してください。</returns>
		public static string S10059(string lineNo, string item1, string item2, string value)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item1).Append("］ と ［").Append(item2).Append("］ のどちらかは").Append(value).Append("入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001501"), lineNo, item1, item2, value);

		}
		/// <summary>
		/// ［%s］ にゼロは指定できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ にゼロは指定できません。</returns>
		public static string S10060(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ にゼロは指定できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001502"), item);

		}
		/// <summary>
		/// %s 行目： ［%s］ の ［%s］ にゼロは指定できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item1"/>］ にゼロは指定できません。</returns>
		public static string S10061(string lineNo, string item1)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item1).Append("］ にゼロは指定できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001503"), lineNo, item1);

		}
		/// <summary>
		/// %s 行目： ［%s］ の ［%s］ にゼロは指定できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item1"/>］ の ［<paramref name="item2"/>］ にゼロは指定できません。</returns>
		public static string S10061(string lineNo, string item1, string item2)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item1).Append("］ の ［").Append(item2).Append("］ にゼロは指定できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001504"), lineNo, item1, item2);

		}
		/// <summary>
		/// ［%s］ が%sとき、日本円以外の通貨は入力できません。
		/// </summary>
		/// <param name="conditionItem">条件の項目名</param>
		/// <param name="condition">条件</param>
		/// <returns>［<paramref name="conditionItem"/>］ が<paramref name="condition"/>とき、日本円以外の通貨は入力できません。。</returns>
		public static string S10062(string conditionItem, string condition)
		{

// 			return new StringBuilder("［", 64).Append(conditionItem).Append("］ が").Append(condition).Append("とき、日本円以外の通貨は入力できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001505"), conditionItem, condition);

		}
		/// <summary>
		/// %s 行目： ［%s］ は%s入力してください。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item">項目名</param>
		/// <param name="expression">入力すべき表現</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item"/>］ は<paramref name="expression"/>入力してください。</returns>
		public static string S10063(string lineNo, string item, string expression)
		{

// 			return new StringBuilder(lineNo, 32).Append(" 行目： ［").Append(item).Append("］ は").Append(expression).Append("入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001506"), lineNo, item, expression);


		}
		/// <summary>
		/// ［%s］ が%sとき、 ［%s］ は指示できません。
		/// </summary>
		/// <param name="conditionItem">条件の項目名</param>
		/// <param name="condition">条件</param>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="conditionItem"/>］ が<paramref name="condition"/>とき、 ［<paramref name="item"/>］ は指示できません。</returns>
		public static string S10064(string conditionItem, string condition, string item)
		{

// 			return new StringBuilder("［", 64).Append(conditionItem).Append("］ が").Append(condition).Append("とき、 ［").Append(item).Append("］ は指示できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001507"), conditionItem, condition, item);

		}
		/// <summary>
		/// ［%s］ が%sとき、 ［%s］に［%s］ は指示できません。
		/// </summary>
		/// <param name="conditionItem">条件の項目名</param>
		/// <param name="condition">条件</param>
		/// <param name="item1">項目名</param>
		/// /// <param name="item2">項目名</param>
		/// <returns>［<paramref name="conditionItem"/>］ が<paramref name="condition"/>とき、［<paramref name="item1"/>］に［<paramref name="item2"/>］ は指示できません。</returns>
		public static string S10065(string conditionItem, string condition, string item1, string item2)
		{

// 			return new StringBuilder("［", 64).Append(conditionItem).Append("］ が").Append(condition).Append("とき、 ［").Append(item1).Append("］に［").Append(item2).Append("］ は指示できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001508"), conditionItem, condition, item1, item2);

		}
		/// <summary>
		/// ［%s］ は銀行営業日を入力してください。
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ は銀行営業日を入力してください。</returns>
		/// </summary>
		public static string S10066(string item)
		{

// 			return new StringBuilder("［", 64).Append(item).Append("］ は銀行営業日を入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001509"), item);

		}
		/// <summary>
		/// 同一の［%s］ は指定できません。
		/// <param name="item">項目名</param>
		/// <returns>同一の［<paramref name="item"/>］ は指定できません。</returns>
		/// </summary>
		public static string S10067(string item)
		{

// 			return new StringBuilder("同一の［", 64).Append(item).Append("］ は指定できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001510"), item);

		}
		/// <summary>
		/// ［%s］ が使用中のため ［%s］ を変更できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ が使用中のため ［<paramref name="item2"/>］ を変更できません。</returns>
		public static string S10068(string item1, string item2)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］ が使用中のため ［").Append(item2).Append("］ を変更できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001511"), item1, item2);

		}
		/// <summary>
		/// %s は%s入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="expression">入力すべき表現</param>
		/// <returns><paramref name="item"/> は<paramref name="expression"/>入力してください。</returns>
		public static string S10069(string item, string expression)
		{

// 			return new StringBuilder(item).Append("は").Append(expression).Append("入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001512"), item, expression);

		}
		/// <summary>
		/// %s 行目： ［%s］ が%sとき、 ［%s］ は必須です。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="conditionItem">条件の項目名</param>
		/// <param name="condition">条件</param>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="conditionItem"/>］ が<paramref name="condition"/>とき、 ［<paramref name="item"/>］ は必須です。</returns>
		public static string S10070(string lineNo, string conditionItem, string condition, string item)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(conditionItem).Append("］ が").Append(condition).Append("とき、 ［").Append(item).Append("］ は必須です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001513"), lineNo, conditionItem, condition, item);

		}
		/// <summary>
		/// ［%s］ は ［%s］ 以前の日付で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ は ［<paramref name="item2"/>］ 以前の日付で入力してください。</returns>
		public static string S10071(string item1, string item2)
		{

// 			return new StringBuilder("［", 64).Append(item1).Append("］ は ［").Append(item2).Append("］ 以前の日付で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001514"), item1, item2);

		}
		/// <summary>
		/// ［%s］ は半角文字で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ は半角文字で入力してください。</returns>
		public static string S10072(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ は半角文字で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001515"), item);

		}
		/// <summary>
		/// ［%s］ は半角カタカナ（「ヲ」以外）または半角英数字で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ は半角カタカナ（「ヲ」以外）または半角英数字で入力してください。</returns>
		public static string S10073(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ は半角カタカナ（「ヲ」以外）または半角英数字で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001516"), item);

		}
		/// <summary>
		/// [%s]が%sのとき、[%s]は%sを選択してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="item3">項目名 3</param>
		/// <param name="item4">項目名 4</param>
		/// <returns>［<paramref name="item1"/>］が［<paramref name="item2"/>］のとき、［<paramref name="item3"/>］は［<paramref name="item4"/>］を選択してください。</returns>
		public static string S10074(string item1, string item2, string item3, string item4)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］が").Append(item2).Append("のとき、［").Append(item3).Append("］は").Append(item4).Append("を選択してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001517"), item1, item2, item3, item4);

		}
		/// <summary>
		/// %d 件中 %d 件承認しました。承認できなかった ［%s］ は以下の通りです。
		/// </summary>
		/// <param name="totalCount">承認対象数</param>
		/// <param name="count">承認数</param>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="totalCount"/> 件中 <paramref name="count"/> 件承認しました。承認できなかった ［<paramref name="item"/>］ は以下の通りです。</returns>
		public static string S10075(int totalCount, int count, string item)
		{

// 			return new StringBuilder(totalCount.ToString(), 64).Append(" 件中 ").Append(count.ToString("#,##0")).Append(" 件承認しました。承認できなかった ［").Append(item).Append("］ は以下の通りです。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001518"), totalCount.ToString("#,##0"), count.ToString("#,##0"), item);

		}

		/// <summary>
		/// %sが取得できませんでした。
		/// </summary>
		/// <param name="item"></param>
		/// <returns>［<paramref name="item"/>］ が取得できませんでした。</returns>
		public static string S10076(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001635"), item);
		}

		/// <summary>
		/// %s 行目： %sが取得できませんでした。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item"></param>
		/// <returns><paramref name="lineNo"/>行目：<paramref name="item"/>が取得できませんでした。</returns>
		public static string S10077(string lineNo, string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001636"), lineNo, item);
		}

		/// <summary>
		/// %sが取得できませんでした。%sのマスタをご確認ください。
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns>［<paramref name="item1"/>］ が取得できませんでした。［<paramref name="item2"/>］のマスタをご確認ください。</returns>
		public static string S10078(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001637"), item1, item2);
		}

		/// <summary>
		/// %s 行目： %sが取得できませんでした。%sのマスタをご確認ください。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns><paramref name="lineNo"/>行目：<paramref name="item1"/>が取得できませんでした。<paramref name="item2"/>のマスタをご確認ください。</returns>
		public static string S10079(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001638"), lineNo, item1, item2);
		}

		/// <summary>
		/// ［%s］が不正です。
		/// </summary>
		/// <param name="item">項目名</param>
		public static string S10080(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001646"), item);
		}

		/// <summary>
		/// %s 行目： ［%s］ 選択時に、 ［%s］ は必須です。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="condition">条件</param>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="condition"/>］ 選択時に、 ［<paramref name="item"/>］ は必須です。</returns>
		public static string S10081(string lineNo, string condition, string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001694"), lineNo, condition, item);
		}
		
		/// <summary>
		/// %s 行目：［%s］ は、 %s ～ %s の範囲で入力してください。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item">項目名</param>
		/// <param name="minValue">最小値</param>
		/// <param name="maxValue">最大値</param>
		/// <returns><paramref name="lineNo"/> 行目： ［<paramref name="item"/>］ は、 <paramref name="minValue"/> ～ <paramref name="maxValue"/> の範囲で入力してください。</returns>
		public static string S10082(string lineNo, string item, string minValue, string maxValue)
		{
			return string.Format(MultiLanguage.Get("CM_AM001695"), lineNo, item, minValue, maxValue);
		}

		/// <summary>
		/// 該当する［%s］が存在しません。
		/// </summary>
		/// <param name="item">項目名</param>
		public static string S10083(string item)
		{
			// 該当する［{0}］が存在しません。
			return string.Format(MultiLanguage.Get("CM_AM001702"), item);
		}

		/// <summary>
		/// 取込データが重複しています。
		/// </summary>
		public static string S10084
		{
			// 取込データが重複しています。
			get { return MultiLanguage.Get("CM_AM001703"); }
		}

		/// <summary>
		/// 存在しないファイル、または空のファイルが指定されました。
		/// </summary>
		public static string S10085
		{
			get { return MultiLanguage.Get("CM_AM001224"); }
		}
		/// <summary>
		/// ［{0}］は半角数字で入力して下さい。
		/// </summary>
		public static string S10086(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001707"), item);
		}

		/// <summary>
		/// [{0}]の入力に誤りがあります。
		/// </summary>
		public static string S10087(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001708"), item);
		}

		/// <summary>
		/// [{0}]は{1}桁で入力してください。
		/// </summary>
		public static string S10088(string item, int length)
		{
			return string.Format(MultiLanguage.Get("CM_AM001709"), item, length);
		}

		/// <summary>
		/// ［%s］ は ［%s］ より後の日付で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ は ［<paramref name="item2"/>］ より後の日付で入力してください。</returns>
		public static string S10089(string item1, string item2)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000241")).Append(item2).Append(MultiLanguage.Get("CM_AM000287")).ToString();
		}

		/// <summary>
		/// ［%s］ は ［%s］ 以降の値で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ は ［<paramref name="item2"/>］ 以降の値で入力してください。</returns>
		public static string S10090(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001774"), item1, item2);
		}

		/// <summary>
		/// %s行目
		/// </summary>
		/// <param name="item">埋込文字列</param>
		/// <returns>メッセージ</returns>
		public static string S10091(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001777"), item);
		}

		/// <summary>
		/// リクエストのJson形式が不正であるか、無効な値が含まれています。
		/// </summary>
		public static string S10092
		{
			get { return MultiLanguage.Get("CM_AM001780"); }
		}

		/// <summary>
		/// ［%s］ は半角カタカナまたは半角英数字で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ は半角カタカナまたは半角英数字で入力してください。</returns>
		public static string S10093(string item)
		{

			return string.Format(MultiLanguage.Get("CM_AM001847"), item);

		}

		#endregion
		#region S20000
		/// <summary>
		/// 呼び出し元が不正です。
		/// </summary>

// 		public static readonly string S20001 = "呼び出し元が不正です。";
		public static string S20001
		{
			get {return MultiLanguage.Get("CM_AM000890");}
		}

		/// <summary>
		/// このコードは既に登録されています。
		/// </summary>
		/// <returns>
		/// このコードは既に登録されています。
		/// </returns>
		public static string S20002()
		{
// 			return "このコードは既に登録されています。"; 
			return MultiLanguage.Get("CM_AM000540");
		}
		/// <summary>
		/// 更新対象の行は他のユーザによって変更、もしくは削除されました。
		/// </summary>

// 		public static readonly string S20003 = "更新対象の行は他のユーザによって変更、もしくは削除されました。";
		public static string S20003
		{
			get {return MultiLanguage.Get("CM_AM000913");}
		}

		/// <summary>
		/// 削除対象の行は他のユーザによって変更、もしくは削除されました。
		/// </summary>

// 		public static readonly string S20004 = "削除対象の行は他のユーザによって変更、もしくは削除されました。";
		public static string S20004
		{
			get {return MultiLanguage.Get("CM_AM000954");}
		}

		/// <summary>
		/// ［%s］ がマスタにないか、有効ではありません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ がマスタにないか、有効ではありません。</returns>
		public static string S20005(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ がマスタにないか、有効ではありません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001519"), item);

		}
		/// <summary>
		/// ［%s］ が存在しません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ が存在しません。</returns>
		public static string S20006(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ が存在しません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001520"), item);

		}
		/// <summary>
		/// ［%s］ が%sに存在しません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="value">内容</param>
		/// <returns>［<paramref name="item"/>］ が<paramref name="value"/>に存在しません。</returns>
		public static string S20007(string item, string value)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ が").Append(value).Append("に存在しません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001521"), item, value);

		}
		/// <summary>
		/// ［%s］ が%sで使用中のため削除できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="value">内容</param>
		/// <returns>［<paramref name="item1"/>］ が<paramref name="item2"/>で使用中のため削除できません。</returns>
		public static string S20008(string item, string value)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ が").Append(value).Append("で使用中のため削除できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001522"), item, value);

		}
		/// <summary>
		/// ［%s］ が使用中のため削除できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item1"/>］ が使用中のため削除できません。</returns>
		public static string S20009(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ が使用中のため削除できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001523"), item);

		}
		/// <summary>
		/// %sで使用中のため削除できません。
		/// </summary>
		/// <param name="value">内容</param>
		/// <returns><paramref name="item2"/>で使用中のため削除できません。</returns>
		public static string S20010(string value)
		{

// 			return new StringBuilder(value, 32).Append("で使用中のため削除できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001524"), value);

		}
		/// <summary>
		/// 更新対象の ［%s］ は他のユーザによって変更、もしくは削除されました。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>更新対象の ［<paramref name="item2"/>］ は他のユーザによって変更、もしくは削除されました。</returns>
		public static string S20011(string item)
		{

// 			return new StringBuilder("更新対象の ［", 64).Append(item).Append("］ は他のユーザによって変更、もしくは削除されました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001525"), item);

		}
		/// <summary>
		/// 削除対象の ［%s］ は他のユーザによって変更、もしくは削除されました。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>削除対象の ［<paramref name="item"/>］ は他のユーザによって変更、もしくは削除されました。</returns>
		public static string S20012(string item)
		{

// 			return new StringBuilder("削除対象の ［", 64).Append(item).Append("］ は他のユーザによって変更、もしくは削除されました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001526"), item);

		}
		/// <summary>
		/// 要求がタイムアウトになりました。
		/// </summary>

// 		public static readonly string S20013 = "要求がタイムアウトになりました。";
		public static string S20013
		{
			get {return MultiLanguage.Get("CM_AM001425");}
		}

		/// <summary>
		/// %sの更新時にエラーが発生しました。
		/// </summary>
		/// <param name="item">エラーの発生場所</param>
		/// <returns><paramref name="item"/>の更新時にエラーが発生しました。</returns>
		public static string S20014(string item)
		{

// 			return new StringBuilder(item, 32).Append("の更新時にエラーが発生しました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001527"), item);

		}
		/// <summary>
		/// ［%s］ が使用中のため更新できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ が使用中のため更新できません。</returns>
		public static string S20015(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ が使用中のため更新できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001487"), item);

		}
		/// <summary>
		/// %sのため%sできません。
		/// </summary>
		/// <param name="reason">理由</param>
		/// <param name="action">動作</param>
		/// <returns><paramref name="reason"/>のため<paramref name="action"/>できません。</returns>
		public static string S20016(string reason, string action)
		{

// 			return new StringBuilder(reason, 32).Append("のため").Append(action).Append("できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001529"), reason, action);

		}
		/// <summary>
		/// 為替予約ありの場合レートは変更できません。
		/// </summary>

// 		public static readonly string S20017 = "為替予約ありの場合レートは変更できません。";
		public static string S20017
		{
			get {return MultiLanguage.Get("CM_AM000719");}
		}

		/// <summary>
		/// 為替予約番号： %s の残高を上回っています。
		/// </summary>
		/// <param name="no">為替予約番号</param>
		/// <returns>為替予約番号： <paramref name="no"/> の残高を上回っています。</returns>
		public static string S20018(string no)
		{

// 			return new StringBuilder("為替予約番号： ").Append(no).Append(" の残高を上回っています。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001530"), no);

		}
		/// <summary>
		/// ［%s］ が為替予約番号： %s の残高を上回っています。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="no">為替予約番号</param>
		/// <returns>［<paramref name="item"/>］ が為替予約番号： <paramref name="no"/> の残高を上回っています。</returns>
		public static string S20018(string item, string no)
		{

// 			return new StringBuilder("［", 64).Append(item).Append("］ が").Append("為替予約番号： ").Append(no).Append(" の残高を上回っています。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001531"), item ,no);

		}
		/// <summary>
		/// ［%s］ は既に実行中です。
		/// </summary>
		/// <param name="batchName">バッチ名</param>
		/// <returns>［<paramref name="batchName"/>］ は既に実行中です。</returns>
		public static string S20019(string batchName)
		{

// 			return new StringBuilder("［", 32).Append(batchName).Append("］ は既に実行中です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001532"), batchName);

		}
		/// <summary>
		/// %s %sさんが、 %d月 %d日 %d時 %d分より更新処理中のため、データ更新は出来ません。
		/// </summary>
		/// <param name="deptName">部門名</param>
		/// <param name="empName">社員名</param>
		/// <param name="month">月 (1 から 12)</param>
		/// <param name="day">日 (1 から 31)</param>
		/// <param name="hour">時間 (0 から 23)</param>
		/// <param name="minute">分 (0 から 59)</param>
		/// <returns><paramref name="deptName"/> <paramref name="empName"/>さんが、 <paramref name="month"/>月 <paramref name="day"/>日 <paramref name="hour"/>時 <paramref name="minute"/>分より更新処理中のため、データ更新は出来ません。</returns>
		public static string S20020(string deptName, string empName, int month, int day, int hour, int minute)
		{

// 			return new StringBuilder(deptName, 64).Append(" ").Append(empName).Append("さんが、 ").Append(month).Append("月 ").Append(day).Append("日 ").Append(hour).Append("時 ").Append(minute).Append("分より更新処理中のため、データ更新は出来ません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001533"), deptName, empName, month, day, hour, minute);

		}
		/// <summary>
		/// ［%s］ が未算出のため登録できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ が未算出のため登録できません。</returns>
		public static string S20021(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ が未算出のため登録できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001534"), item);

		}
		/// <summary>
		/// ［%s］ が未算出のため更新できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ が未算出のため更新できません。</returns>
		public static string S20022(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ が未算出のため更新できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001535"), item);

		}
		/// <summary>
		/// ［%s］ が未設定のため登録できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ が未設定のため登録できません。</returns>
		public static string S20023(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ が未設定のため登録できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001536"), item);

		}
		/// <summary>
		/// ［%s］ の ［%s］ が未設定のため登録できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ の ［<paramref name="item2"/>］ が未設定のため登録できません。</returns>
		public static string S20023(string item1, string item2)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］ の ［").Append(item2).Append("］ が未設定のため登録できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001537"), item1, item2);

		}
		/// <summary>
		/// ［%s］ が未設定のため更新できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ が未設定のため更新できません。</returns>
		public static string S20024(string item)
		{

// 			return new StringBuilder("［", 32).Append(item).Append("］ が未設定のため更新できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001538"), item);

		}
		/// <summary>
		/// ［%s］ の ［%s］ が未設定のため更新できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ の ［<paramref name="item2"/>］ が未設定のため更新できません。</returns>
		public static string S20024(string item1, string item2)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］ の ［").Append(item2).Append("］ が未設定のため更新できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001539"), item1, item2);

		}
		/// <summary>
		/// データベースエラー：　%s
		/// </summary>
		/// <param name="message">メッセージ</param>
		public static string S20025(string message)
		{

// 			return new StringBuilder("データベースエラー：　").Append(message).ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001540"), message.ToString());

		}
		/// <summary>
		/// 致命的なエラーが発生しました。システム管理者へ連絡してください。
		/// </summary>

// 		public static string S20026 = "致命的なエラーが発生しました。システム管理者へ連絡してください。";
		public static string S20026
		{
			get {return MultiLanguage.Get("CM_AM001247");}
		}

		/// <summary>
		/// ［Undefined］ メッセージのレベルが定義されていません。
		/// </summary>

// 		public static string S20027 = "［Undefined］ メッセージのレベルが定義されていません。";
		public static string S20027
		{
			get {return MultiLanguage.Get("CM_AM000132");}
		}

		/// <summary> 
		/// メール送信に失敗しました。
		/// </summary>

// 		public static readonly string S20028 = "メール送信に失敗しました。";
		public static string S20028
		{
			get {return MultiLanguage.Get("CM_AM000668");}
		}

		/// <summary>
		/// [%s]のライセンス許諾がない為、この画面を使用する事はできません
		/// </summary>
		/// <param name="message">メッセージ</param>
		public static string S20029(string message)
		{
// 			return new StringBuilder("[").Append(message).Append("]の").Append("ライセンス許諾がない為、この画面を使用する事はできません。").ToString(); 
			return new StringBuilder("[").Append(message).Append(MultiLanguage.Get("CM_AM000351")).Append(MultiLanguage.Get("CM_AM000676")).ToString();
		}
		/// <summary>
		/// [%s]のライセンス許諾がない為、この画面を使用する事はできません
		/// </summary>
		/// <param name="message">メッセージ</param>
		public static string S20030(string message)
		{

// 			return new StringBuilder("アカウント[").Append(message).Append("]は、").Append("この画面を使用する権限がありません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001542"), message);

		}
		/// <summary>
		/// 現在処理が混み合っています。もう一度実行して下さい。
		/// </summary>

// 		public static readonly string S20031 = "現在処理が混み合っています。もう一度実行して下さい。";
		public static string S20031
		{
			get {return MultiLanguage.Get("CM_AM000887");}
		}

		/// <summary>
		/// 他ユーザが申請中のため、更新できません。
		/// </summary>

// 		public static readonly string S20032 = "他ユーザが申請中のため、更新できません。";
		public static string S20032
		{
			get {return MultiLanguage.Get("CM_AM001228");}
		}

		/// <summary>
		/// 承認途中のため、更新できません。
		/// </summary>

// 		public static readonly string S20033 = "承認途中のため、更新できません。";
		public static string S20033
		{
			get {return MultiLanguage.Get("CM_AM001157");}
		}

		/// <summary>
		/// 所属する[%s]が申請中のため、更新できません。
		/// </summary>
		/// <param name="message">メッセージ</param>
		public static string S20034(string message)
		{

// 			return new StringBuilder("所属する").Append(message).Append("が申請中のため、更新できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001543"), message);

		}
		/// <summary>
		/// 同一伝票を%d回以上更新することはできません。
		/// </summary>
		/// <param name="maxCount">最大伝票更新回数数</param>
		/// <returns> 同一伝票を <paramref name="maxCount"/> 回以上更新することはできません。</returns>
		public static string S20035(string maxCount)
		{

// 			return new StringBuilder("同一伝票を ").Append(maxCount).Append(" 回以上更新することはできません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001544"), maxCount);

		}
		/// <summary>
		/// %sと%sは同時に処理出来ません。
		/// </summary>
		/// <param name="item1">項目名１</param>
		/// <param name="item2">項目名２</param>
		public static string S20036(string item1, string item2)
		{

// 			return new StringBuilder(item1).Append("と").Append(item2).Append("は同時に処理出来ません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001545"), item1, item2);

		}
		/// <summary>
		/// %sが%sとき、%sは指定できません。
		/// </summary>
		/// <param name="conditionItem">条件の項目名</param>
		/// <param name="condition">条件</param>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="conditionItem"/>が<paramref name="condition"/>とき、<paramref name="item"/> は指定できません。</returns>
		public static string S20037(string conditionItem, string condition, string item)
		{

// 			return new StringBuilder("", 64).Append(conditionItem).Append("が").Append(condition).Append("とき、").Append(item).Append("は指定できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001546"), conditionItem, condition, item);

		}
		/// <summary>
		/// %sため%sできません。
		/// </summary>
		/// <param name="reason">理由</param>
		/// <param name="action">動作</param>
		/// <returns><paramref name="reason"/>ため<paramref name="action"/>できません。</returns>
		public static string S20038(string reason, string action)
		{

// 			return new StringBuilder(reason, 32).Append("ため").Append(action).Append("できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001547"), reason, action);

		}
		/// <summary>
		/// ［%s］ が変更されているため、更新できません。
		/// </summary>
		/// <param name="item"></param>
		/// <returns>［<paramref name="item"/>］ が変更されているため、更新できません。</returns>
		public static string S20039(string item)
		{

// 			return new StringBuilder("［", 64).Append(item).Append("］ が変更されているため、更新できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001548"), item);

		}
		/// <summary>
		/// %sに、%sが入力されています。
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns><paramref name="item1"/>に、<paramref name="item2"/>が入力されています。</returns>
		public static string S20040(string item1, string item2)
		{

// 			return new StringBuilder("［", 32).Append(item1).Append("］に、").Append(item2).Append("が入力されています。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001549"), item1, item2);

		}
		/// <summary>
		/// %s 行目： %sに、%sが入力されています。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns><paramref name="lineNo"/>行目：<paramref name="item1"/>に、<paramref name="item2"/>が入力されています。</returns>
		public static string S20040(string lineNo, string item1, string item2)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item1).Append("］に、").Append(item2).Append("が入力されています。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001550"), lineNo, item1, item2);

		}
        /// <summary>
        /// %sできません。
        /// </summary>
        /// <param name="value"></param>
        /// <returns><paramref name="value"/>できません。</returns>
        public static string S20041(string value)
        {

//             return new StringBuilder(value, 64).Append("できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001551"), value);

		}
		/// <summary>
		/// 為替予約番号： %s の%s充当済金額を上回っています。
		/// </summary>
		/// <param name="no">為替予約番号</param>
		/// <param name="item">項目名</param>
		/// <returns>為替予約番号： <paramref name="no"/> の<paramref name="item"/>充当済金額を上回っています。</returns>
		public static string S20042(string no, string item)
		{

// 			return new StringBuilder("為替予約番号： ").Append(no).Append(" の").Append(item).Append("充当済金額を上回っています。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001552"), no, item);

		}

		/// <summary>
		/// [%s]基準の税率と異なる税率の明細が存在します。[%s]を確認の上、更新してください。
		/// </summary>
		/// <param name="slipDate">伝票日付</param>
		/// <param name="ctaxBasisDate">計上基準日/取引日</param>
		/// <returns>[<paramref name="slipDate"/>]基準の税率と異なる税率の明細が存在します。[<paramref name="ctaxBasisDate"/>]を確認の上、更新してください。</returns>
		public static string S20043(string slipDate, string ctaxBasisDate)
		{
			return string.Format(MultiLanguage.Get("CM_AM001648"), slipDate, ctaxBasisDate);
		}

		/// <summary>
		/// 消費税区分の税科目がなしの場合、国内でかつ課税する[%s]は指定できません。
		/// </summary>
		/// <param name="item">得意先/仕入先</param>
		/// <returns>消費税区分の税科目がなしの場合、国内でかつ課税する[<paramref name="item"/>]は指定できません。</returns>
		public static string S20044(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001643"), item);
		}

		/// <summary>
		/// [%s]の消費税区分と明細の[%s]の組合せが不正です。[%s]マスタが変更されていないかをご確認ください。
		/// </summary>
		/// <param name="item1">得意先/仕入先</param>
		/// <param name="item2">消費税率コード/消費税計算区分</param>
		/// <returns>[<paramref name="item1"/>]の消費税区分と明細の[<paramref name="item2"/>］の組合せが不正です。[<paramref name="item1"/>］マスタが変更されていないかをご確認ください。</returns>
		public static string S20045(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001647"), item1, item2);
		}

		/// <summary>
		/// 取込に失敗しました。
		/// </summary>
		public static string S20046
		{
			// 取込に失敗しました。
			get { return MultiLanguage.Get("CM_AM001094"); }
		}
		
		/// <summary>
		/// %sが実行中のため、処理が実行できません。
		/// </summary>
		/// <param name="item">処理名</param>
		/// <returns><paramref name="item"/>が実行中のため、処理が実行できません。</returns>
		public static string S20048(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001733"), item);
		}

		/// <summary>
		/// %sを開始しました。
		/// </summary>
		/// <param name="item">処理名</param>
		/// <returns><paramref name="item"/>を開始しました。</returns>
		public static string S20049(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001585"), item);
		}

		/// <summary>
		/// %sを%s回以上更新することはできません。
		/// </summary>
		/// <param name="item1">伝票名</param>
		/// <param name="maxCount">最大伝票更新回数</param>
		/// <returns> <paramref name="item1"/>を <paramref name="maxCount"/> 回以上更新することはできません。</returns>
		public static string S20050(string item1, string maxCount)
		{
			return string.Format(MultiLanguage.Get("CM_AM001729"), item1, maxCount);
		}

		/// <summary>
		/// 入力された ［%s］ 時点で、元伝票の部門コードが有効な伝票入力許可部門ではありません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>入力された ［<paramref name="item"/>］ 時点で、元伝票の部門コードが有効な伝票入力許可部門ではありません。</returns>
		public static string S20051(string item)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM001306"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000312")).ToString();
		}
		/// <summary>
		/// 支払条件に、台帳が必要な決済方法は複数登録できません。
		/// </summary>
		public static string S20047
		{
			get { return MultiLanguage.Get("CM_AM001724"); }
		}

		/// <summary>
		/// ［{0}］ に設定する処理用固定値がマスタにないか、有効ではありません。システム管理者にご連絡ください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］に設定する処理用固定値がマスタにないか、有効ではありません。システム管理者にご連絡ください。</returns>
		public static string S20052(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001776"), item);
		}

		/// <summary>
		/// ［%s］は入力出来ません。
		/// </summary>
		/// <param name="item">埋込文字列</param>
		/// <returns>メッセージ</returns>
		public static string S20053(string item)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM000131")).Append(item).Append(MultiLanguage.Get("CM_AM000177")).Append(MultiLanguage.Get("CM_AM000044")).ToString();
		}

		/// <summary>
		/// レスポンスの件数が{0}件を超えています。
		/// </summary>
		/// <param name="value">件数</param>
		/// <returns></returns>
		public static string S20054(string value)
		{
			return string.Format(MultiLanguage.Get("CM_AM001781"), value);
		}

		/// <summary>
		/// レスポンスのサイズが{0}バイトを超えています。
		/// </summary>
		/// <param name="size">バイト数</param>
		/// <returns></returns>
		public static string S20055(string size)
		{
			return string.Format(MultiLanguage.Get("CM_AM001782"), size);
		}

		/// <summary>
		/// {0}が重複しています。
		/// </summary>
		/// <param name="item">埋め込み文字列</param>
		/// <returns></returns>
		public static string S20056(string item)
		{
			return new StringBuilder(item).Append(MultiLanguage.Get("CM_CS001947")).ToString();
		}

		/// <summary>
		/// 認証アプリケーションからのチケットが無効です。
		/// </summary>
		public static string S20057
		{
			get { return MultiLanguage.Get("CM_CS004290"); }
		}

		/// <summary>
		/// 認証者の情報が認証プロバイダーから正しく取得されていません。
		/// </summary>
		public static string S20058
		{
			get { return MultiLanguage.Get("CM_CS004284"); }
		}

		/// <summary>
		/// 「ログインアカウント」に認証者の情報と一致するものが存在しません。
		/// </summary>
		public static string S20059
		{
			get { return MultiLanguage.Get("CM_CS004285"); }
		}

		/// <summary>
		/// 認証後のログインプロセスでエラーが発生しました。
		/// </summary>
		public static string S20060
		{
			get { return MultiLanguage.Get("CM_CS004286"); }
		}

		/// <summary>
		/// 認証プロセスが完了し、ログインプロセスにリダイレクトされます。
		/// </summary>
		public static string S20061
		{
			get { return MultiLanguage.Get("CM_CS004287"); }
		}

		/// <summary>
		/// ecoDeliver連携に必要な情報がオプション情報に設定されていません。
		/// </summary>
		public static string S20062
		{
			// ecoDeliver連携に必要な情報がオプション情報に設定されていません。
			get { return MultiLanguage.Get("CM_CS004274"); }
		}

		/// <summary>
		/// %d件中 %d件取消しました。取消できなかった ［%s］ は以下の通りです。
		/// </summary>
		/// <param name="totalCount">更新対象数</param>
		/// <param name="count">取消数</param>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="totalCount"/>件中 <paramref name="count"/>件取消しました。取消できなかった [<paramref name="item"/>] は以下の通りです。</returns>
		public static string S20063(int totalCount, int count, string item)
		{
			// totalCount件中 count件取消しました。取消できなかった [item] は以下の通りです。
			return string.Format(MultiLanguage.Get("CM_AM001829"), totalCount.ToString("#,##0"), count.ToString("#,##0"), item);
		}
		#endregion
		#endregion

		#region 共通メッセージ（帳票用）
		#region R00000
		/// <summary>
		/// 帳票データ作成中です。しばらくお待ちください。
		/// </summary>

// 		public static readonly string R00001 = "帳票データ作成中です。しばらくお待ちください。";
		public static string R00001
		{
			get {return MultiLanguage.Get("CM_AM001248");}
		}

		/// <summary>
		/// 対象データが見つかりません。
		/// </summary>

// 		public static readonly string R00002 = "対象データが見つかりません。";
		public static string R00002
		{
			get {return MultiLanguage.Get("CM_AM001230");}
		}

		/// <summary>
		/// 出力対象データが %d 件あります。出力を実行しますか？
		/// </summary>
		/// <param name="count">出力件数</param>
		/// <returns>出力対象データが <paramref name="count"/> 件あります。出力を実行しますか？</returns>
		public static string R00003(int count)
		{
// 			return new StringBuilder("出力対象データが ", 32).Append(count.ToString("#,##0")).Append(" 件あります。出力を実行しますか？").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001129"), 32).Append(count.ToString("#,##0")).Append(MultiLanguage.Get("CM_AM000072")).ToString();
		}
		/// <summary>
		/// 出力対象データが %d %dあります。出力を実行しますか？
		/// </summary>
		/// <param name="count">出力件数</param>
		/// <param name="unit">単位</param>
		/// <returns>出力対象データが <paramref name="count"/> <paramref name="unit"/>あります。出力を実行しますか？</returns>
		public static string R00003(int count, string unit)
		{
// 			return new StringBuilder("出力対象データが ", 32).Append(count.ToString("#,##0")).Append(" ").Append(unit).Append("あります。出力を実行しますか？").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001129"), 32).Append(count.ToString("#,##0")).Append(" ").Append(unit).Append(MultiLanguage.Get("CM_AM000513")).ToString();
		}
		/// <summary>
		/// 印刷処理中です。 ［はい］ を押すと印刷がキャンセルされます。
		/// </summary>

// 		public static readonly string R00004 = "印刷処理中です。 ［はい］ を押すと印刷がキャンセルされます。";
		public static string R00004
		{
			get {return MultiLanguage.Get("CM_AM000731");}
		}

		/// <summary>
		/// 正常に帳票要求を完了しました。
		/// </summary>

// 		public static readonly string R00005 = "正常に帳票要求を完了しました。";
		public static string R00005
		{
			get {return MultiLanguage.Get("CM_AM001177");}
		}

		#endregion
		#endregion

		#region CM
		#region CM_AC
		#region CM_AC
		/// <summary>
		/// パスワードは %d 文字以上に制限されています。
		/// </summary>
		/// <param name="minLength">最小桁数</param>
		/// <returns>パスワードは <paramref name="minLength"/> 文字以上に制限されています。</returns>
		public static string CM_AC_S10001(int minLength)
		{
// 			return new StringBuilder("パスワードは ", 32).Append(minLength).Append(" 文字以上に制限されています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000636"), 32).Append(minLength).Append(MultiLanguage.Get("CM_AM000109")).ToString();
		}
		/// <summary>
		/// URL: %s へのアプリケーション変数設定要求が成功しました。\r\n
		/// </summary>
		/// <param name="url">URL</param>
		/// <returns>URL: <paramref name="url"/> へのアプリケーション変数設定要求が成功しました。\r\n</returns>
		public static string CM_AC_S10002(string url)
		{
// 			return new StringBuilder("URL: http://", 64).Append(ipAddress).Append(":").Append(portNo).Append(virtualFolderPath).Append(" へのアプリケーション変数設定要求が成功しました。\r\n").ToString(); 
			return new StringBuilder("URL: ", 64).Append(url).Append(MultiLanguage.Get("CM_AM000048")).ToString();
		}
		/// <summary>
		/// Webアプリケーションの初期化に失敗しました。自社コード： %s の %s テーブルの読み取りに失敗しました。
		/// </summary>
		/// <param name="myCompCode">自社コード</param>
		/// <param name="tableName">テーブル名</param>
		/// <returns>Webアプリケーションの初期化に失敗しました。自社コード： <paramref name="myCompCode"/> の <paramref name="tableName"/> テーブルの読み取りに失敗しました。</returns>
		public static string CM_AC_S20001(string myCompCode, string tableName)
		{
// 			return new StringBuilder("Webアプリケーションの初期化に失敗しました。自社コード： ", 64).Append(myCompCode).Append(" の ").Append(tableName).Append(" テーブルの読み取りに失敗しました。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000507"), 64).Append(myCompCode).Append(MultiLanguage.Get("CM_AM000024")).Append(tableName).Append(MultiLanguage.Get("CM_AM000017")).ToString();
		}
		/// <summary>
		/// セキュリティエラー 001 が発生しました。
		/// </summary>

// 		public static readonly string CM_AC_S20002 = "セキュリティエラー 001 が発生しました。";
		public static string CM_AC_S20002
		{
			get {return MultiLanguage.Get("CM_AM000575");}
		}

		/// <summary>
		/// セッション情報の取得に失敗にしました。セッションが切断された可能性があります。再ログインしてください。
		/// </summary>

// 		public static readonly string CM_AC_S20003 = "セッション情報の取得に失敗にしました。セッションが切断された可能性があります。再ログインしてください。";
		public static string CM_AC_S20003
		{
			get {return MultiLanguage.Get("CM_AM000577");}
		}

		/// <summary>
		/// アプリケーション情報の取得に失敗しました。 Web アプリケーションの初期化が必要です。
		/// </summary>

// 		public static readonly string CM_AC_S20004 = "アプリケーション情報の取得に失敗しました。 Web アプリケーションの初期化が必要です。";
		public static string CM_AC_S20004
		{
			get {return MultiLanguage.Get("CM_AM000511");}
		}

		/// <summary>
		/// 遷移先ページのアクセス権限がありません。
		/// </summary>

// 		public static readonly string CM_AC_S20005 = "遷移先ページのアクセス権限がありません。";
		public static string CM_AC_S20005
		{
			get {return MultiLanguage.Get("CM_AM001204");}
		}

		/// <summary>
		/// 遷移先ページは一時的に「使用不可」に設定されています。
		/// </summary>

// 		public static readonly string CM_AC_S20006 = "遷移先ページは一時的に「使用不可」に設定されています。";
		public static string CM_AC_S20006
		{
			get {return MultiLanguage.Get("CM_AM001205");}
		}

		/// <summary>
		/// 処理を実行するためのデータベース権限が不足してます。
		/// </summary>

// 		public static readonly string CM_AC_S20007 = "処理を実行するためのデータベース権限が不足してます。";
		public static string CM_AC_S20007
		{
			get {return MultiLanguage.Get("CM_AM001132");}
		}

		/// <summary>
		/// URL: %s へのアプリケーション変数設定要求が失敗しました。\r\n
		/// </summary>
		/// <param name="url">URL</param>
		/// <returns>URL: <paramref name="url"/> へのアプリケーション変数設定要求が失敗しました。\r\n</returns>
		public static string CM_AC_S20008(string url)
		{
// 			return new StringBuilder("URL: http://", 64).Append(ipAddress).Append(":").Append(portNo).Append(virtualFolderPath).Append(" へのアプリケーション変数設定要求が失敗しました。\r\n").ToString(); 
			return new StringBuilder("URL: ", 64).Append(url).Append(MultiLanguage.Get("CM_AM000047")).ToString();
		}
		/// <summary>
		/// URL: %s へのアプリケーション変数設定要求が失敗しました。 メッセージ：%s \r\n
		/// </summary>
		/// <param name="url">URL</param>
		/// <param name="message">メッセージ</param>
		/// <returns>URL: <paramref name="url"/> へのアプリケーション変数設定要求が失敗しました。 メッセージ：<paramref name="nessage"/>\r\n</returns>
		public static string CM_AC_S20008(string url, string message)
		{
// 			return new StringBuilder("URL: http://", 1024).Append(ipAddress).Append(":").Append(portNo).Append(virtualFolderPath).Append(" へのアプリケーション変数設定要求が失敗しました。 メッセージ：").Append(message).Append("\r\n").ToString(); 
			return new StringBuilder("URL: ", 1024).Append(url).Append(MultiLanguage.Get("CM_AM000046")).Append(message).Append("\r\n").ToString();
		}
		/// <summary>
		/// Webサーバの情報が設定されていません。
		/// </summary>

// 		public static readonly string CM_AC_S20009 = "Webサーバの情報が設定されていません。";
		public static string CM_AC_S20009
		{
			get {return MultiLanguage.Get("CM_AM000508");}
		}

		/// <summary>
		/// セッション変数［ %s : %s ］の取得に失敗しました。セッション値が設定されていない可能性があります。
		/// </summary>
		/// <param name="englishName">英語名</param>
		/// <param name="japaneseName">日本語名</param>
		/// <returns></returns>
		public static string CM_AC_S20010(string englishName, string japaneseName)
		{
// 			return new StringBuilder("セッション変数［", 128).Append(englishName).Append(":").Append(japaneseName).Append("］の取得に失敗しました。セッション値が設定されていない可能性があります。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000578"), 128).Append(englishName).Append(":").Append(japaneseName).Append(MultiLanguage.Get("CM_AM000369")).ToString();
		}
		/// <summary>
		/// REPORTテーブルにREPORT_IDのデータが存在しません。ReportID : %s
		/// </summary>
		/// <param name="ReportID">リポートID</param>
		/// <returns></returns>
		public static string CM_AC_S20011(string ReportID)
		{
// 			return new StringBuilder("REPORTテーブルにREPORT_IDのデータが存在しません。ReportID : ", 64).Append(ReportID).ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000497"), 64).Append(ReportID).ToString();
		}
		/// <summary>
		/// REPORTテーブルにREPORT_IDのデータが存在しません。ReportID : %s
		/// </summary>
		/// <param name="ReportID">リポートID</param>
		/// <returns></returns>
		public static string CM_AC_S20012(string ReportID)
		{
// 			return new StringBuilder("CACHE_TO_DISK_LOCATIONに存在しないフォルダを指定しています。ReportID : ", 64).Append(ReportID).ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000433"), 64).Append(ReportID).ToString();
		}
		/// <summary>
		/// REPORTテーブルにREPORT_IDのデータが存在しません。ReportID : %s
		/// </summary>
		/// <param name="ReportID">リポートID</param>
		/// <returns></returns>
		public static string CM_AC_S20013(string ReportID)
		{
// 			return new StringBuilder("CACHE_TO_DISKに'0'か'1'以外の値が指定されています。ReportID : ", 64).Append(ReportID).ToString(); 
			return new StringBuilder("" + MultiLanguage.Get("CM_AM000434") + "'0'" + MultiLanguage.Get("CM_AM000517") + "'1'" + MultiLanguage.Get("CM_AM000708") + "", 64).Append(ReportID).ToString();
		}
		#endregion
		#region CM_AC_01
		/// <summary>
		/// インラインフレームに表示する URL はローカルパスである必要があります。
		/// </summary>

// 		public static readonly string CM_AC_01_S01_01 = "インラインフレームに表示する URL はローカルパスである必要があります。";
		public static string CM_AC_01_S01_01
		{
			get {return MultiLanguage.Get("CM_AM000515");}
		}

		/// <summary>
		/// サーバアプリケーションでエラーが発生しました。
		/// </summary>

// 		public static readonly string CM_AC_01_S02_01 = "サーバアプリケーションでエラーが発生しました。";
		public static string CM_AC_01_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000561");}
		}

		/// <summary>
		/// セッションを切断しました。
		/// </summary>

// 		public static readonly string CM_AC_01_S02_02 = "セッションを切断しました。";
		public static string CM_AC_01_S02_02
		{
			get {return MultiLanguage.Get("CM_AM000576");}
		}

		/// <summary>
		/// セッションを切断しました。
		/// </summary>

// 		public static readonly string CM_AC_01_S02_03 = "ログアウトを行ってから、再度ログインし直して下さい。";
		public static string CM_AC_01_S02_03
		{
			get {return MultiLanguage.Get("CM_AM000683");}
		}

		#endregion
		#region CM_AC_03
		/// <summary>
		/// ログインに失敗しました。（大文字／小文字は区別されます。）
		/// </summary>

// 		public static readonly string CM_AC_03_S01_01 = "ログインに失敗しました。（大文字／小文字は区別されます。）";
		public static string CM_AC_03_S01_01
		{
			get {return MultiLanguage.Get("CM_AM000686");}
		}

		/// <summary>
		/// \r\n（ログインアカウントが正しい場合、）規定回数以上ログインを失敗したためこのアカウントはロックされます。アカウントを有効にするにはシステム管理者への連絡が必要です。
		/// </summary>

// 		public static readonly string CM_AC_03_S01_02 = "\r\n（ログインアカウントが正しい場合、）規定回数以上ログインを失敗したためこのアカウントはロックされます。アカウントを有効にするにはシステム管理者への連絡が必要です。";
		public static string CM_AC_03_S01_02
		{
			get {return MultiLanguage.Get("CM_AM000419");}
		}

		/// <summary>
		/// このアカウントはロックされています。アカウントを有効にするにはシステム管理者への連絡が必要です。
		/// </summary>

// 		public static readonly string CM_AC_03_S01_03 = "このアカウントはロックされています。アカウントを有効にするにはシステム管理者への連絡が必要です。";
		public static string CM_AC_03_S01_03
		{
			get {return MultiLanguage.Get("CM_AM000538");}
		}

		/// <summary>
		/// このアカウントは %s から %d 日以上パスワード変更されていません。パスワードの有効期限が切れました。
		/// </summary>
		/// <param name="date">日付</param>
		/// <param name="i">日数</param>
		/// <returns>このアカウントは <paramref name="date"/> から <paramref name="i"/> 日以上パスワード変更されていません。パスワードの有効期限が切れました。</returns>
		public static string CM_AC_03_S01_04(string date, int i)
		{
// 			return new StringBuilder("このアカウントは ", 128).Append(date).Append(" から ").Append(i.ToString("#,0")).Append(" 日以上パスワード変更されていません。パスワードの有効期限が切れました。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000537"), 128).Append(date).Append(MultiLanguage.Get("CM_AM000013")).Append(i.ToString("#,0")).Append(MultiLanguage.Get("CM_AM000104")).ToString();
		}
		/// <summary>
		/// 同一のセッションを使用したログインが既に行われています。新規に起動したブラウザウィンドウからログインしてください。
		/// </summary>

// 		public static readonly string CM_AC_03_S01_05 = "同一のセッションを使用したログインが既に行われています。新規に起動したブラウザウィンドウからログインしてください。";
		public static string CM_AC_03_S01_05
		{
			get {return MultiLanguage.Get("CM_AM001278");}
		}

		/// <summary>
		/// セッション情報の取得に失敗しました。セッションが失効した可能性があります。ページを再読み込みしてください。
		/// </summary>
		public static string CM_AC_03_S01_06
		{
			// セッション情報の取得に失敗しました。セッションが失効した可能性があります。ページを再読み込みしてください。
			get {return MultiLanguage.Get("CM_AM001844"); }
		}

		/// <summary>
		/// アカウント %s はパスワードの変更を要求されています。
		/// </summary>
		/// <param name="account">アカウント名</param>
		/// <returns>アカウント <paramref name="account"/> はパスワードの変更を要求されています。</returns>
		public static string CM_AC_03_S02_01(string account)
		{
// 			return new StringBuilder("アカウント ", 64).Append(account).Append(" はパスワードの変更を要求されています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000509"), 64).Append(account).Append(MultiLanguage.Get("CM_AM000038")).ToString();
		}
		/// <summary>
		/// 新パスワードが一致していません。
		/// </summary>

// 		public static readonly string CM_AC_03_S02_02 = "新パスワードが一致していません。";
		public static string CM_AC_03_S02_02
		{
			get {return MultiLanguage.Get("CM_AM001164");}
		}

		/// <summary>
		/// 旧パスワードは一致しません。
		/// </summary>

// 		public static readonly string CM_AC_03_S02_04 = "旧パスワードは一致しません。";
		public static string CM_AC_03_S02_04
		{
			get {return MultiLanguage.Get("CM_AM000839");}
		}

		/// <summary>
		/// このアカウントはロックされています。アカウントを有効にするにはシステム管理者への連絡が必要です。
		/// </summary>
//		public static readonly string CM_AC_03_S02_05 = CM_AC_03_S01_03;
		public static string CM_AC_03_S02_05
		{
			get {return MultiLanguage.Get("CM_AM000538");}
		}
		/// <summary>
		/// %s までパスワードの変更は禁止されています。
		/// </summary>
		/// <param name="term">期間</param>
		/// <returns><paramref name="minLength"/> までパスワードの変更は禁止されています。</returns>
		public static string CM_AC_03_S02_06(string term)
		{
// 			return new StringBuilder(term, 32).Append(" までパスワードの変更は禁止されています。").ToString(); 
			return new StringBuilder(term, 32).Append(MultiLanguage.Get("CM_AM000050")).ToString();
		}
		/// <summary>
		/// 過去 %d 回に使用したパスワードは再利用できません。
		/// </summary>
		/// <param name="count">回数</param>
		/// <returns>過去 <paramref name="count"/> 回に使用したパスワードは再利用できません。</returns>
		public static string CM_AC_03_S02_07(int count)
		{
// 			return new StringBuilder("過去 ", 32).Append(count).Append(" 回に使用したパスワードは再利用できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000746"), 32).Append(count).Append(MultiLanguage.Get("CM_AM000060")).ToString();
		}
		/// <summary>
		/// アカウント %s のパスワード有効期限は %s までです。パスワードの変更をお勧めします。
		/// </summary>
		/// <param name="account">アカウント名</param>
		/// <param name="endTirm">有効期限</param>
		/// <returns>アカウント <paramref name="account"/> のパスワード有効期限は <paramref name="endTirm"/> までです。パスワードの変更をお勧めします。</returns>
		public static string CM_AC_03_S02_08(string account, DateTime endTirm)
		{
// 			return new StringBuilder("アカウント ", 64).Append(account).Append(" のパスワード有効期限は ").Append(endTirm.ToString("yyyy/MM/dd HH:mm")).Append(" までです。パスワードの変更をお勧めします。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000509"), 64).Append(account).Append(MultiLanguage.Get("CM_AM000028")).Append(endTirm.ToString("yyyy/MM/dd HH:mm")).Append(MultiLanguage.Get("CM_AM000049")).ToString();
		}
		/// <summary>
		/// ログインアカウントが変更されたため、次回ログインまでパスワードを変更する事が出来ません。
		/// </summary>

// 		public static readonly string CM_AC_03_S02_09 = "ログインアカウントが変更されたため、次回ログインまでパスワードを変更する事が出来ません。";
		public static string CM_AC_03_S02_09
		{
			get {return MultiLanguage.Get("CM_AM000685");}
		}

		/// <summary>
		/// ロックアウトを解除しました。
		/// </summary>

// 		public static readonly string CM_AC_03_S04_01 = "ロックアウトを解除しました。";
		public static string CM_AC_03_S04_01
		{
			get {return MultiLanguage.Get("CM_AM000688");}
		}

		/// <summary>
		/// ログイン失敗履歴をクリアしました。
		/// </summary>

// 		public static readonly string CM_AC_03_S04_02 = "ログイン失敗履歴をクリアしました。";
		public static string CM_AC_03_S04_02
		{
			get {return MultiLanguage.Get("CM_AM000687");}
		}

		/// <summary>
		/// 指定したログインアカウントは既に使用されています。
		/// </summary>

// 		public static readonly string CM_AC_03_S05_01 = "指定したログインアカウントは既に使用されています。";
		public static string CM_AC_03_S05_01
		{
			get {return MultiLanguage.Get("CM_AM001030");}
		}

		/// <summary>
		/// カテゴリ %s ライセンス数を超えた為、登録できません。
		/// </summary>
		/// <param name="category">カテゴリ</param>
		/// <returns>カテゴリ"category"ライセンス数を超えた為、登録できません。</returns>
		public static string CM_AC_03_S05_02(int category)
		{
// 			return new StringBuilder("カテゴリ", 1).Append(category).Append("ライセンス数を超えた為、登録できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000520"), 1).Append(category).Append(MultiLanguage.Get("CM_AM000677")).ToString();
		}
		/// <summary>
		/// 更新しました。 カテゴリ１・カテゴリ２のライセンス合計数を超えています。
		/// </summary>

// 		public static readonly string CM_AC_03_S05_03 = "更新しました。 カテゴリ１・カテゴリ２のライセンス合計数を超えています。";
		public static string CM_AC_03_S05_03
		{
			get {return MultiLanguage.Get("CM_AM000906");}
		}

		/// <summary>
		/// カテゴリ１・カテゴリ２のライセンス合計数を超えての登録は出来ません。
		/// </summary>

// 		public static readonly string CM_AC_03_S05_04 = "カテゴリ１・カテゴリ２のライセンス合計数を超えての登録は出来ません。";
		public static string CM_AC_03_S05_04
		{
			get {return MultiLanguage.Get("CM_AM000521");}
		}

		/// <summary>
		/// 更新しました。 カテゴリ１のライセンス合計数を超えています。
		/// </summary>

// 		public static readonly string CM_AC_03_S05_05 = "更新しました。 カテゴリ１のライセンス合計数を超えています。";
		public static string CM_AC_03_S05_05
		{
			get {return MultiLanguage.Get("CM_AM000907");}
		}
		/// <summary>
		/// スマートデバイスのライセンス数を超えた為、登録できません。
		/// </summary>
// 		public static readonly string CM_AC_03_S05_06 = "スマートデバイスのライセンス数を超えた為、登録できません。";
		public static string CM_AC_03_S05_06
		{
			get {return MultiLanguage.Get("CM_AM001619");}
		}
		#endregion
		#region CM_AC_04
		/// <summary>
		/// メニューID の採番に失敗しました。
		/// </summary>

// 		public static readonly string CM_AC_04_S01_01 = "メニューID の採番に失敗しました。";
		public static string CM_AC_04_S01_01
		{
			get {return MultiLanguage.Get("CM_AM000670");}
		}

		/// <summary>
		/// 編集モードに失敗しました。
		/// </summary>

// 		public static readonly string CM_AC_04_S02_01 = "編集モードに失敗しました。";
		public static string CM_AC_04_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001381");}
		}

		/// <summary>
		/// このページの公開区分は［%s］ のみです。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>このページの公開区分は［<paramref name="item"/>］ のみです。</returns>
		public static string CM_AC_04_S02_02(string item)
		{
// 			return new StringBuilder("このページの公開区分は［", 32).Append(item).Append("］ のみです。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000542"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000224")).ToString();
		}
		/// <summary>
		/// メニューアイテムID の採番に失敗しました。
		/// </summary>

// 		public static readonly string CM_AC_04_S02_03 = "メニューアイテムID の採番に失敗しました。";
		public static string CM_AC_04_S02_03
		{
			get {return MultiLanguage.Get("CM_AM000671");}
		}

		/// <summary>
		/// メニュータブID の採番に失敗しました。
		/// </summary>

// 		public static readonly string CM_AC_04_S02_04 = "メニュータブID の採番に失敗しました。";
		public static string CM_AC_04_S02_04
		{
			get {return MultiLanguage.Get("CM_AM000673");}
		}

		/// <summary>
		/// 階層が 3 階層を越えるため貼り付けできません。
		/// </summary>

// 		public static readonly string CM_AC_04_S02_05 = "階層が 3 階層を越えるため貼り付けできません。";
		public static string CM_AC_04_S02_05
		{
			get {return MultiLanguage.Get("CM_AM000756");}
		}

		/// <summary>
		/// 表示順が最も高いメニューアイテムです。
		/// </summary>

// 		public static readonly string CM_AC_04_S02_06 = "表示順が最も高いメニューアイテムです。";
		public static string CM_AC_04_S02_06
		{
			get {return MultiLanguage.Get("CM_AM001359");}
		}

		/// <summary>
		/// 表示順が最も低いメニューアイテムです。
		/// </summary>

// 		public static readonly string CM_AC_04_S02_07 = "表示順が最も低いメニューアイテムです。";
		public static string CM_AC_04_S02_07
		{
			get {return MultiLanguage.Get("CM_AM001360");}
		}

		/// <summary>
		/// メニューアイテム最大表示順取得に失敗しました。
		/// </summary>

// 		public static readonly string CM_AC_04_S02_08 = "メニューアイテム最大表示順取得に失敗しました。";
		public static string CM_AC_04_S02_08
		{
			get {return MultiLanguage.Get("CM_AM000672");}
		}

		/// <summary>
		/// 公開単位区分取得に失敗しました。
		/// </summary>

// 		public static readonly string CM_AC_04_S02_09 = "公開単位区分取得に失敗しました。";
		public static string CM_AC_04_S02_09
		{
			get {return MultiLanguage.Get("CM_AM000901");}
		}

		/// <summary>
		/// 同一ページで異なる公開区分または権限設定は指定できません。
		/// </summary>

		public static string CM_AC_04_S02_10
		{
			get {return MultiLanguage.Get("CM_AM001764");}
		}

		#endregion
		#endregion
		#region CM_MS
		#region CM_MS
		/// <summary>
		/// ［%s］の桁数が自社マスタの設定値と異なります。（自社マスタでは、 %d 桁と設定されています。）
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="value">桁数</param>
		/// <returns>［<paramref name="item1"/>］ の桁数が自社マスタの設定値と異なります。（自社マスタでは、 <paramref name="value"/> 桁と設定されています。）</returns>
		public static string CM_MS_S10001(string item1, string value)
		{
// 			return new StringBuilder("［", 64).Append(item1).Append("］ の桁数が自社マスタの設定値と異なります。（自社マスタでは、").Append(value).Append(" 桁と設定されています。）").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000225")).Append(value).Append(MultiLanguage.Get("CM_AM000066")).ToString();
		}
		/// <summary>
		/// ［%s］の桁数が自社マスタの設定値と異なります。（自社マスタでは、親番 %d 桁、枝番 %d 桁と設定されています。）
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="value">桁数</param>
		/// <param name="value2">桁数 2</param>
		/// <returns>［<paramref name="item1"/>］ の桁数が自社マスタの設定値と異なります。（自社マスタでは、親番 <paramref name="value"/> 桁、枝番<paramref name="value2"/> 桁と設定されています。）</returns>
		public static string CM_MS_S10001(string item1, string value, string value2)
		{
// 			return new StringBuilder("［", 64).Append(item1).Append("］ の桁数が自社マスタの設定値と異なります。（自社マスタでは、親番 ").Append(value).Append(" 桁、枝番 ").Append(value2).Append(" 桁と設定されています。）").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000226")).Append(value).Append(MultiLanguage.Get("CM_AM000065")).Append(value2).Append(MultiLanguage.Get("CM_AM000066")).ToString();
		}
		/// <summary>
		/// ［%s］が使用中のため無効にできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ が使用中のため無効にできません。</returns>
		public static string CM_MS_S10002(string item)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］ が使用中のため無効にできません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000192")).ToString();
		}
		/// <summary>
		/// ファイルが指定されていません。
		/// </summary>

// 		public static readonly string CM_MS_S10003 = "ファイルが指定されていません。";
		public static string CM_MS_S10003
		{
			get {return MultiLanguage.Get("CM_AM000647");}
		}

		/// <summary>
		/// ファイル形式が正しくありません。
		/// </summary>

// 		public static readonly string CM_MS_S10004 = "ファイル形式が正しくありません。";
		public static string CM_MS_S10004
		{
			get {return MultiLanguage.Get("CM_AM000648");}
		}

		/// <summary>
		/// 個人番号情報が登録されているため削除できません。
		/// </summary>
		public static string CM_MS_S10005
		{
			get { return MultiLanguage.Get("CM_AM001706"); }
		}

		#endregion
		#region CM_MS_01
		/// <summary>
		/// 自動採番最大桁数 （%d） を超える設定はできません。
		/// </summary>
		/// <param name="count">最大桁数</param>
		/// <returns>自動採番最大桁数 （<paramref name="count"/>） を超える設定はできません。</returns>
		public static string CM_MS_01_S01_01(int count)
		{
// 			return new StringBuilder("自動採番最大桁数 （", 32).Append(count.ToString("#,##0")).Append("） を超える設定はできません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001071"), 32).Append(count.ToString("#,##0")).Append(MultiLanguage.Get("CM_AM000118")).ToString();
		}
		/// <summary>
		/// 自動採番選択時の連番桁数に 0 は入力できません。
		/// </summary>

// 		public static readonly string CM_MS_01_S01_02 = "自動採番選択時の連番桁数に 0 は入力できません。";
		public static string CM_MS_01_S01_02
		{
			get {return MultiLanguage.Get("CM_AM001072");}
		}

		/// <summary>
		/// 伝票区分記号に半角英字以外の文字を指定することはできません。
		/// </summary>

// 		public static readonly string CM_MS_01_S01_03 = "伝票区分記号に半角英字以外の文字を指定することはできません。";
		public static string CM_MS_01_S01_03
		{
			get {return MultiLanguage.Get("CM_AM001266");}
		}

		/// <summary>
		/// 自社マスタに設定されている %s 桁数と採番ルールによって決定される %s 桁数が異なるため更新できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>自社マスタに設定されている <paramref name="item"/> 桁数と採番ルールによって決定される <paramref name="item"/> 桁数が異なるため更新できません。</returns>
		public static string CM_MS_01_S01_04(string item)
		{
// 			return new StringBuilder("自社マスタに設定されている", 64).Append(item).Append("桁数と採番ルールによって決定される").Append(item).Append("桁数が異なるため更新できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001069"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000860")).Append(item).Append(MultiLanguage.Get("CM_AM000859")).ToString();
		}
		/// <summary>
		/// %s、%s、 ... は、同じ伝票区分記号は適用できません。
		/// </summary>
		/// <param name="items">項目名</param>
		/// <returns><paramref name="items"/>、<paramref name="items"/>、 ... は、同じ伝票区分記号は適用できません。</returns>
		public static string CM_MS_01_S01_05(params string[] items)
		{
			StringBuilder sb = new StringBuilder(64);
			foreach (string item in items)
			{
// 				sb.Append(item).Append("、"); 
				sb.Append(item).Append(MultiLanguage.Get("CM_AM000128"));
			}
			sb.Remove(sb.Length - 1, 1);

			switch (items.Length)
			{
				case 2:
// 					sb.Append("は、同じ伝票区分記号は適用できません。"); 
					sb.Append(MultiLanguage.Get("CM_AM000634"));
					break;
				default:
// 					sb.Append("は、いずれか1つでも同じ伝票区分記号は適用できません。"); 
					sb.Append(MultiLanguage.Get("CM_AM000633"));
					break;
			}
			return sb.ToString();
		}
		/// <summary>
		/// 対象マスタを変更できません。
		/// </summary>

// 		public static readonly string CM_MS_01_S02_01 = "対象マスタを変更できません。";
		public static string CM_MS_01_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001233");}
		}

		/// <summary>
		/// 編集モードに失敗しました。
		/// </summary>

// 		public static readonly string CM_MS_01_S03_01 = "編集モードに失敗しました。";
		public static string CM_MS_01_S03_01
		{
			get {return MultiLanguage.Get("CM_AM001381");}
		}

		/// <summary>
		/// 階層が 10 階層を越えるため貼り付けできません。
		/// </summary>

// 		public static readonly string CM_MS_01_S03_02 = "階層が 10 階層を越えるため貼り付けできません。";
		public static string CM_MS_01_S03_02
		{
			get {return MultiLanguage.Get("CM_AM000755");}
		}

		/// <summary>
		/// 指定されたページに対応する FAQ が存在しません。
		/// </summary>

// 		public static readonly string CM_MS_01_S04_01 = "指定されたページに対応する FAQ が存在しません。";
		public static string CM_MS_01_S04_01
		{
			get {return MultiLanguage.Get("CM_AM001001");}
		}

		/// <summary>
		/// プロジェクトコードが利用桁数と異なります。
		/// </summary>

// 		public static readonly string CM_MS_01_S05_02 = "プロジェクトコードが利用桁数と異なります。";
		public static string CM_MS_01_S05_02
		{
			get {return MultiLanguage.Get("CM_AM000657");}
		}

		/// <summary>
		/// 同一の日付および通貨コードを持つレコードが既に存在します。
		/// </summary>

// 		public static readonly string CM_MS_01_S09_01 = "同一の日付および通貨コードを持つレコードが既に存在します。";
		public static string CM_MS_01_S09_01
		{
			get {return MultiLanguage.Get("CM_AM001281");}
		}

		/// <summary>
		/// 既に本日の日付を持つレコードが登録されているか、レコードが 1 件も登録されていません。
		/// </summary>

// 		public static readonly string CM_MS_01_S09_02 = "既に本日の日付を持つレコードが登録されているか、レコードが 1 件も登録されていません。";
		public static string CM_MS_01_S09_02
		{
			get {return MultiLanguage.Get("CM_AM000835");}
		}

		#endregion
		#region CM_MS_02
		/// <summary>
		/// ［%s］ フラグの値が正しくありません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ フラグの値が正しくありません。</returns>
		public static string CM_MS_02_S13_01(string item)
		{
// 			return new StringBuilder("［", 32).Append(item).Append("］ フラグの値が正しくありません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000286")).ToString();
		}
		/// <summary>
		/// ［%s］ は ［前回%s］ 以降の日付で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ は ［前回<paramref name="item2"/>］ 以降の日付で入力してください。</returns>
		public static string CM_MS_02_S51_01(string item1, string item2)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］ は ［前回").Append(item2).Append("］ 以降の日付で入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000244")).Append(item2).Append(MultiLanguage.Get("CM_AM000303")).ToString();
		}
		/// <summary>
		/// 入力された ［%s］ 時点で、元伝票の部門コードが有効な伝票入力許可部門ではありません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>入力された ［<paramref name="item"/>］ 時点で、元伝票の部門コードが有効な伝票入力許可部門ではありません。</returns>
		public static string CM_MS_02_S51_02(string item)
		{
// 			return new StringBuilder("入力された ［", 64).Append(item).Append("］ 時点で、元伝票の部門コードが有効な伝票入力許可部門ではありません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001306"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000312")).ToString();
		}
		/// <summary>
		/// 入力された ［%s］ 時点で、部門コードが有効な伝票入力許可部門ではありません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>入力された ［<paramref name="item"/>］ 時点で、部門コードが有効な伝票入力許可部門ではありません。</returns>
		public static string CM_MS_02_S51_03(string item)
		{
// 			return new StringBuilder("入力された ［", 64).Append(item).Append("］ 時点で、部門コードが有効な伝票入力許可部門ではありません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001306"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000313")).ToString();
		}
		#endregion
		#region CM_MS_03
		/// <summary>
		/// ［%s］ の指定に誤りがあります。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ の指定に誤りがあります。</returns>
		public static string CM_MS_03_S01_01(string item)
		{
// 			return new StringBuilder("［", 32).Append(item).Append("］ の指定に誤りがあります。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000227")).ToString();
		}
		/// <summary>
		/// 仮会計期間開始月度には本会計期間終了月度の翌月以降を指定する必要があります。
		/// </summary>

// 		public static readonly string CM_MS_03_S01_02 = "仮会計期間開始月度には本会計期間終了月度の翌月以降を指定する必要があります。";
		public static string CM_MS_03_S01_02
		{
			get {return MultiLanguage.Get("CM_AM000743");}
		}

		/// <summary>
		/// 会計月度の開始日、終了日の算出ができませんでした。
		/// </summary>

// 		public static readonly string CM_MS_03_S01_03 = "会計月度の開始日、終了日の算出ができませんでした。";
		public static string CM_MS_03_S01_03
		{
			get {return MultiLanguage.Get("CM_AM000749");}
		}

		/// <summary>
		/// 決算期IDが他の行で使用されているため更新処理を中止します。
		/// </summary>

// 		public static readonly string CM_MS_03_S01_04 = "決算期IDが他の行で使用されているため更新処理を中止します。";
		public static string CM_MS_03_S01_04
		{
			get {return MultiLanguage.Get("CM_AM000863");}
		}

		/// <summary>
		/// 採番マスタに部門記号使用フラグが設定されている伝票が存在するため、部門記号を0桁に変更することはできません。
		/// </summary>

// 		public static readonly string CM_MS_03_S01_05 = "採番マスタに部門記号使用フラグが設定されている伝票が存在するため、部門記号を0桁に変更することはできません。";
		public static string CM_MS_03_S01_05
		{
			get {return MultiLanguage.Get("CM_AM000938");}
		}

		/// <summary>
		/// 既に他のマスタに基軸通貨以外の通貨が使用されているため、多通貨を使用しないに変更することはできません。
		/// </summary>

// 		public static readonly string CM_MS_03_S01_06 = "既に他のマスタに基軸通貨以外の通貨が使用されているため、多通貨を使用しないに変更することはできません。";
		public static string CM_MS_03_S01_06
		{
			get {return MultiLanguage.Get("CM_AM000812");}
		}

		/// <summary>
		/// 取引先コードまたはプロジェクトコードの固定桁数を変更しようとしましたが、変更前の桁数で登録された取引先またはプロジェクトが存在するため変更することはできません。
		/// </summary>

// 		public static readonly string CM_MS_03_S01_07 = "取引先コードまたはプロジェクトコードの固定桁数を変更しようとしましたが、変更前の桁数で登録された取引先またはプロジェクトが存在するため変更することはできません。";
		public static string CM_MS_03_S01_07
		{
			get {return MultiLanguage.Get("CM_AM001089");}
		}

		/// <summary>
		/// ［%s］  が自社マスタ（経理）の設定値より大きい値に設定されています。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］  が自社マスタ（経理）の設定値より大きい値に設定されています。</returns>
		public static string CM_MS_03_S01_08(string item)
		{
// 			return new StringBuilder("［", 32).Append(item).Append("］ が自社マスタ（経理）の設定値より大きい値に設定されています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000193")).ToString();
		}
		#endregion
		#region CM_MS_04
		/// <summary>
		/// 現行の組織変更情報より未来の情報は既に存在します。未来の組織変更情報を複数作成することはできません。
		/// </summary>

// 		public static readonly string CM_MS_04_S01_01 = "現行の組織変更情報より未来の情報は既に存在します。未来の組織変更情報を複数作成することはできません。";
		public static string CM_MS_04_S01_01
		{
			get {return MultiLanguage.Get("CM_AM000881");}
		}

		/// <summary>
		/// 最新の組織変更情報の組織変更日より未来の日付を指定してください。
		/// </summary>

// 		public static readonly string CM_MS_04_S01_02 = "最新の組織変更情報の組織変更日より未来の日付を指定してください。";
		public static string CM_MS_04_S01_02
		{
			get {return MultiLanguage.Get("CM_AM000937");}
		}

		/// <summary>
		/// 組織変更日は未来のものでなければなりません。
		/// </summary>

// 		public static readonly string CM_MS_04_S01_03 = "組織変更日は未来のものでなければなりません。";
		public static string CM_MS_04_S01_03
		{
			get {return MultiLanguage.Get("CM_AM001215");}
		}

		/// <summary>
		/// 階層の深さが制限を超えています。最大［%s］階層を超える設定はできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>階層の深さが制限を超えています。最大［<paramref name="item"/>］階層を超える設定はできません。</returns>
		public static string CM_MS_04_S02_01(string item)
		{
// 			return new StringBuilder("階層の深さが制限を超えています。最大［", 32).Append(item).Append("］階層を超える設定はできません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000759"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000401")).ToString();
		}
		/// <summary>
		/// 最上位階層の部門を移動することはできません。
		/// </summary>

// 		public static readonly string CM_MS_04_S02_02 = "最上位階層の部門を移動することはできません。";
		public static string CM_MS_04_S02_02
		{
			get {return MultiLanguage.Get("CM_AM000936");}
		}

		/// <summary>
		/// 自分自身、あるいはその子孫を移動先に指定することはできません。
		/// </summary>

// 		public static readonly string CM_MS_04_S02_03 = "自分自身、あるいはその子孫を移動先に指定することはできません。";
		public static string CM_MS_04_S02_03
		{
			get {return MultiLanguage.Get("CM_AM001076");}
		}

		/// <summary>
		/// 最上位階層にある部門は削除できません。
		/// </summary>

// 		public static readonly string CM_MS_04_S02_04 = "最上位階層にある部門は削除できません。";
		public static string CM_MS_04_S02_04
		{
			get {return MultiLanguage.Get("CM_AM000935");}
		}

		/// <summary>
		/// 子を持つ部門は削除できません。
		/// </summary>

// 		public static readonly string CM_MS_04_S02_05 = "子を持つ部門は削除できません。";
		public static string CM_MS_04_S02_05
		{
			get {return MultiLanguage.Get("CM_AM000996");}
		}

		/// <summary>
		/// 現行の組織変更番号に対応した部門は削除できません。\r\n（組織変更番号 0 を除く）
		/// </summary>

// 		public static readonly string CM_MS_04_S02_06 = "現行の組織変更番号に対応した部門は削除できません。\r\n（組織変更番号 0 を除く）";
		public static string CM_MS_04_S02_06
		{
			get {return MultiLanguage.Get("CM_AM000882");}
		}

		/// <summary>
		/// ［部門］が全社の場合、［在庫管理部門］も全社に限定されます。
		/// </summary>

// 		public static readonly string CM_MS_04_S02_07 = "［部門］が全社の場合、［在庫管理部門］も全社に限定されます。";
		public static string CM_MS_04_S02_07
		{
			get {return MultiLanguage.Get("CM_AM000174");}
		}

		/// <summary>
		/// 階層の深さが制限を超えています。
		/// </summary>

// 		public static readonly string CM_MS_04_S02_08 = "階層の深さが制限を超えています。";
		public static string CM_MS_04_S02_08
		{
			get {return MultiLanguage.Get("CM_AM000758");}
		}

		/// <summary>
		/// ［部門］が全社の場合、［出納管理部門］も全社に限定されます。
		/// </summary>

// 		public static readonly string CM_MS_04_S02_09 = "［部門］が全社の場合、［出納管理部門］も全社に限定されます。";
		public static string CM_MS_04_S02_09
		{
			get {return MultiLanguage.Get("CM_AM000175");}
		}

		/// <summary>
		/// ［%s］ではない場合、自分自身を［%s］に設定する事はできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ではない場合、自分自身を［<paramref name="item"/>］に設定する事はできません。</returns>
		public static string CM_MS_04_S02_10(string item)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］ではない場合、自分自身を［").Append(item).Append("］に設定する事はできません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000333")).Append(item).Append(MultiLanguage.Get("CM_AM000348")).ToString();
		}
		/// <summary>
		/// 部門記号の桁数が最大値を超えています。
		/// </summary>

// 		public static readonly string CM_MS_04_S02_11 = "部門記号の桁数が最大値を超えています。";
		public static string CM_MS_04_S02_11
		{
			get {return MultiLanguage.Get("CM_AM001369");}
		}

		/// <summary>
		/// 選択中の部門はすでに削除されています。
		/// </summary>

// 		public static readonly string CM_MS_04_S02_12 = "選択中の部門はすでに削除されています。";
		public static string CM_MS_04_S02_12
		{
			get {return MultiLanguage.Get("CM_AM001203");}
		}

		/// <summary>
		/// ［部門コード］ は既に廃止されています。
		/// </summary>
		public static string CM_MS_04_S02_13
		{
			get {return MultiLanguage.Get("CM_CS003906");}
		}
		/// <summary>
		/// ［部門コード］ は既に廃止されています。更新しますか？
		/// </summary>
		public static string CM_MS_04_S02_14
		{
			get {return MultiLanguage.Get("CM_CS003907");}
		}
		/// <summary>
		/// 現行の組織図とその次の組織図のいずれか、または両方のデータが存在しません。
		/// </summary>

// 		public static readonly string CM_MS_04_S03_01 = "現行の組織図とその次の組織図のいずれか、または両方のデータが存在しません。";
		public static string CM_MS_04_S03_01
		{
			get {return MultiLanguage.Get("CM_AM000880");}
		}

		/// <summary>
		/// 旧組織図から、変更元となる部門を先に選択してください。
		/// </summary>

// 		public static readonly string CM_MS_04_S03_02 = "旧組織図から、変更元となる部門を先に選択してください。";
		public static string CM_MS_04_S03_02
		{
			get {return MultiLanguage.Get("CM_AM000840");}
		}

		/// <summary>
		/// データ移行部門の設定を完了し、新組織を確定しました。
		/// </summary>

// 		public static readonly string CM_MS_04_S03_03 = "データ移行部門の設定を完了し、新組織を確定しました。";
		public static string CM_MS_04_S03_03
		{
			get {return MultiLanguage.Get("CM_AM000593");}
		}

		/// <summary>
		/// 組織変更日以降の日付の伝票が存在するため、新組織を確定できません。
		/// </summary>

// 		public static readonly string CM_MS_04_S03_04 = "組織変更日以降の日付での旧部門の伝票が存在するため、新組織を確定できません。";
		public static string CM_MS_04_S03_04
		{
			get {return MultiLanguage.Get("CM_AM001216");}
		}

		/// <summary>
		/// 組織変更日以降の計上日で履歴登録された資産台帳が存在します。
		/// </summary>
		public static string CM_MS_04_S03_05
		{
			get {return MultiLanguage.Get("CM_AM001698");}
		}

		#endregion
		#region CM_MS_05
		/// <summary>
		/// 枝番の新規採番が最大値を超えています。
		/// </summary>

// 		public static readonly string CM_MS_05_S02_01 = "枝番の新規採番が最大値を超えています。";
		public static string CM_MS_05_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001050");}
		}

		/// <summary>
		/// 階層の深さが制限を超えています。最大［%s］階層を超える設定はできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>階層の深さが制限を超えています。最大［<paramref name="item"/>］階層を超える設定はできません。</returns>
		public static string CM_MS_05_S02_02(string item)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM000759"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000401")).ToString();
		}

		/// <summary>
		/// 配下の［プロジェクトコード］ が使用中のため更新できません。
		/// </summary>
		public static string CM_MS_05_S02_03
		{
			get { return MultiLanguage.Get("CM_AM001772"); }
		}

		/// <summary>
		/// 無効チェックが上位プロジェクトと異なります。
		/// </summary>
		public static string CM_MS_05_S02_04
		{
			get { return MultiLanguage.Get("CM_AM001783"); }
		}

		/// <summary>
		/// 「無効」がチェックされているので、配下プロジェクトもすべて「無効」に設定されます。
		/// </summary>
		public static string CM_MS_05_S02_05
		{
			get { return MultiLanguage.Get("CM_AM001784"); }
		}

		#endregion
		#region CM_MS_06
		/// <summary>
		/// 同一の部門コードを持つ部門が複数個指定されています。 ［所属部門］ と ［兼務する部門］ の間でも重複は許されません。
		/// </summary>

// 		public static readonly string CM_MS_06_S02_01 = "同一の部門コードを持つ部門が複数個指定されています。 ［所属部門］ と ［兼務する部門］ の間でも重複は許されません。";
		public static string CM_MS_06_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001282");}
		}

		/// <summary>
		/// 「所属部門」を指定せずに、「兼務する部門」を指定することはできません。
		/// </summary>

// 		public static readonly string CM_MS_06_S02_02 = "「所属部門」を指定せずに、「兼務する部門」を指定することはできません。";
		public static string CM_MS_06_S02_02
		{
			get {return MultiLanguage.Get("CM_AM000409");}
		}

		#endregion
		#region CM_MS_07
		/// <summary>
		/// ［取引先コード］ にハイフン(-)を使用することはできません。
		/// </summary>

// 		public static readonly string CM_MS_07_S03_01 = "［取引先コード］ にハイフン(-)を使用することはできません。";
		public static string CM_MS_07_S03_01
		{
			get {return MultiLanguage.Get("CM_AM000149");}
		}

		/// <summary>
		/// %s の適用期間が、取引先の適用期間の範囲を越えています。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="item"/> の適用期間が、取引先の適用期間の範囲を越えています。</returns>
		public static string CM_MS_07_S03_02(string item)
		{
// 			return new StringBuilder("", 64).Append(item).Append(" の適用期間が、取引先の適用期間の範囲を越えています。").ToString(); 
			return new StringBuilder("", 64).Append(item).Append(MultiLanguage.Get("CM_AM000032")).ToString();
		}

		/// <summary>
		/// ［利用者番号]は 9桁で入力してください。
		/// </summary>
		public static string CM_MS_07_S03_03
		{
			get { return MultiLanguage.Get("CM_AM001680"); }
		}

		/// <summary>
		/// 無効チェックが取引先と異なります。
		/// </summary>

// 		public static readonly string CM_MS_07_S05_01 = "無効チェックが取引先と異なります。";
		public static string CM_MS_07_S05_01
		{
			get {return MultiLanguage.Get("CM_AM001397");}
		}

		/// <summary>
		/// 区分が海外の入力時は、請求締区分は都度請求都度回収のみの入力です。
		/// </summary>

// 		public static readonly string CM_MS_07_S05_02 = "区分が海外の入力時は、請求締区分は都度請求都度回収のみの入力です。";
		public static string CM_MS_07_S05_02
		{
			get {return MultiLanguage.Get("CM_AM000846");}
		}

		/// <summary>
		/// ［%s］ と ［%s］ と ［%s］ のいづれかのみでの入力はできません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="item3">項目名 3</param>
		/// <returns>［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ と ［<paramref name="item3"/>］ のいづれかのみでの入力はできません。</returns>
		public static string CM_MS_07_S05_03(string item1, string item2, string item3)
		{
// 			return new StringBuilder("［", 64).Append(item1).Append("］ と ［").Append(item2).Append("］ と ［").Append(item3).Append("］ のいづれかのみでの入力はできません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000205")).Append(item2).Append(MultiLanguage.Get("CM_AM000205")).Append(item3).Append(MultiLanguage.Get("CM_AM000219")).ToString();
		}
		/// <summary>
		/// 無効チェックが取引先と異なります。
		/// </summary>

// 		public static readonly string CM_MS_07_S08_01 = "無効チェックが取引先と異なります。";
		public static string CM_MS_07_S08_01
		{
			get {return MultiLanguage.Get("CM_AM001397");}
		}

		/// <summary>
		/// 口座コードが不正です。
		/// </summary>

// 		public static readonly string CM_MS_07_S08_02 = "口座コードが不正です。";
		public static string CM_MS_07_S08_02
		{
			get {return MultiLanguage.Get("CM_AM000902");}
		}

		/// <summary>
		/// 取引区分が海外の入力時に、支払締区分は都度のみの入力です。
		/// </summary>

// 		public static readonly string CM_MS_07_S08_03 = "取引区分が海外の入力時に、支払締区分は都度のみの入力です。";
		public static string CM_MS_07_S08_03
		{
			get {return MultiLanguage.Get("CM_AM001085");}
		}

		/// <summary>
		/// ［%s］ と ［%s］ と ［%s］ のいづれかのみでの入力はできません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="item3">項目名 3</param>
		/// <returns>［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ と ［<paramref name="item3"/>］ のいづれかのみでの入力はできません。</returns>
		public static string CM_MS_07_S08_04(string item1, string item2, string item3)
		{
			return CM_MS_07_S05_03(item1, item2, item3);
		}
		#endregion
		#region CM_MS_08
		/// <summary>
		/// 同一税率コードで標準税率と軽減税率を混在することはできません。
		/// </summary>
		public static string CM_MS_08_S01_01
		{
			get {return MultiLanguage.Get("CM_CS004078");}
		}

		/// <summary>
		/// 更新しようとした決済タイミングに関連する決済方法のうち、他のテーブルから参照されているためにチェックマークを外せないものが存在します。
		/// </summary>

// 		public static readonly string CM_MS_08_S04_01 = "更新しようとした決済タイミングに関連する決済方法のうち、他のテーブルから参照されているためにチェックマークを外せないものが存在します。";
		public static string CM_MS_08_S04_01
		{
			get {return MultiLanguage.Get("CM_AM000909");}
		}

		/// <summary>
		/// 更新しようとする決済方法タイミングの関連決済方法が１つも指定されていません。
		/// </summary>

// 		public static readonly string CM_MS_08_S04_02 = "更新しようとする決済方法タイミングの関連決済方法が１つも指定されていません。";
		public static string CM_MS_08_S04_02
		{
			get {return MultiLanguage.Get("CM_AM000910");}
		}

		/// <summary>
		/// ［消費税金額］は［金額］より小さい値で入力してください。
		/// </summary>
		public static string CM_MS_08_S51_01
		{
			get { return MultiLanguage.Get("CM_AM000155"); }
		}
		#endregion
		#region CM_MS_10
		/// <summary>
		/// 更新されました（ただし、［予約取消金額］が［予約残高］を超えています）。
		/// </summary>

// 		public static readonly string CM_MS_10_S02_01 = "更新されました（ただし、［予約取消金額］が［予約残高］を超えています）。";
		public static string CM_MS_10_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000903");}
		}

		#endregion
		#region CM_MS_09
		/// <summary>
		/// ［利用者番号]は 9桁で入力してください。
		/// </summary>
		public static string CM_MS_09_S04_01
		{
			get { return MultiLanguage.Get("CM_AM001680"); }
		}

		/// <summary>
		/// [新発生記録手数料]入力時は[新発生記録手数料改定日]は必須です。
		/// </summary>
		public static string CM_MS_09_S04_02
		{
			get { return MultiLanguage.Get("CM_AM001683"); }
		}

		/// <summary>
		/// 存在しないファイル、または空のファイルが指定されました。
		/// </summary>

// 		public static readonly string CM_MS_09_S98_01 = "存在しないファイル、または空のファイルが指定されました。";
		public static string CM_MS_09_S98_01
		{
			get {return MultiLanguage.Get("CM_AM001224");}
		}

		/// <summary>
		/// 全銀協データを銀行マスタに反映しました。
		/// </summary>

// 		public static readonly string CM_MS_09_S98_02 = "全銀協データを銀行マスタに反映しました。";
		public static string CM_MS_09_S98_02
		{
			get {return MultiLanguage.Get("CM_AM001213");}
		}

		#endregion
		#region CM_MS_11
		/// <summary>
		/// ［%s］ %s は予約されているコードです。更新のみが可能です。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ <paramref name="item2"/> は予約されているコードです。更新のみが可能です。</returns>
		public static string CM_MS_11_S02_01(string item1, string item2)
		{
// 			return new StringBuilder("［", 64).Append(item1).Append("］ ").Append(item2).Append(" は予約されているコードです。更新のみが可能です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000178")).Append(item2).Append(MultiLanguage.Get("CM_AM000045")).ToString();
		}
		/// <summary>
		/// 同一の通知グループが複数個指定されています。
		/// </summary>

// 		public static readonly string CM_MS_11_S02_02 = "同一の通知グループが複数個指定されています。";
		public static string CM_MS_11_S02_02
		{
			get {return MultiLanguage.Get("CM_AM001280");}
		}

		/// <summary>
		/// 通知処理を実施しました。
		/// </summary>

// 		public static readonly string CM_MS_11_S06_01 = "通知処理を実施しました。";
		public static string CM_MS_11_S06_01
		{
			get {return MultiLanguage.Get("CM_AM001256");}
		}

		/// <summary>
		/// メールサーバーの設定または、差出人アドレス（From）、宛先アドレス（To）が正しく設定されている事を確認して下さい。
		/// </summary>

// 		public static readonly string CM_MS_11_S06_02 = "メールサーバーの設定または、差出人アドレス（From）、宛先アドレス（To）が正しく設定されている事を確認して下さい。";
		public static string CM_MS_11_S06_02
		{
			get {return MultiLanguage.Get("CM_AM000667");}
		}

		#endregion
		#region CM_MS_12
		/// <summary>
		/// 保存期間を過ぎた為、ファイルが既に削除されています。
		/// </summary>
		public static string CM_MS_12_S12_01
		{
			// 保存期間を過ぎた為、ファイルが既に削除されています。
			get { return MultiLanguage.Get("CM_AM001790"); }
		}

		/// <summary>
		/// 監査ログファイルの保存先が複数設定されているため、監査ログの全件取得ができません。監査名を指定してください。
		/// </summary>
		public static string CM_MS_12_S14_01
		{
			// 監査ログファイルの保存先が複数設定されているため、監査ログの全件取得ができません。監査名を指定してください。
			get { return MultiLanguage.Get("CM_AM001842"); }
		}
		#endregion
		#region CM_MS_13
		/// <summary>
		/// 設定に不備があります。システム管理者に確認して下さい。
		/// </summary>

// 		public static readonly string CM_MS_13_S01_01 = "設定に不備があります。システム管理者に確認して下さい。";
		public static string CM_MS_13_S01_01
		{
			get {return MultiLanguage.Get("CM_AM001195");}
		}

		/// <summary>
		/// レポーティングサービスのレポートが削除されています。
		/// </summary>

// 		public static readonly string CM_MS_13_S05_01 = "レポーティングサービスのレポートが削除されています。";
		public static string CM_MS_13_S05_01
		{
			get {return MultiLanguage.Get("CM_AM000680");}
		}

		/// <summary>
		/// レポーティングサービスのレポートが削除されているため、権限の割当を解除して更新して下さい。
		/// </summary>

// 		public static readonly string CM_MS_13_S05_02 = "レポーティングサービスのレポートが削除されているため、権限の割当を解除して更新して下さい。";
		public static string CM_MS_13_S05_02
		{
			get {return MultiLanguage.Get("CM_AM000681");}
		}

		/// <summary>
		/// レポーティングサービスのレポートが存在しません。
		/// </summary>

// 		public static readonly string CM_MS_13_S05_03 = "レポーティングサービスのレポートが存在しません。";
		public static string CM_MS_13_S05_03
		{
			get {return MultiLanguage.Get("CM_AM000682");}
		}

		/// <summary>
		/// 明細は１つ以上選択してください。
		/// </summary>

// 		public static readonly string CM_MS_13_S07_01 = "明細は１つ以上選択してください。";
		public static string CM_MS_13_S07_01
		{
			get {return MultiLanguage.Get("CM_AM001401");}
		}

		/// <summary>
		/// レポート権限設定画面での設定内容が破棄されます。よろしいですか？
		/// </summary>

		public static string CM_MS_13_S08_01
		{
			get {return MultiLanguage.Get("CM_AM001704");}
		}

		/// <summary>
		/// 設定データの取込が終了しました。
		/// </summary>
		public static string CM_MS_13_S11_01
		{
			get { return MultiLanguage.Get("CM_AM001700"); }
		}

		/// <summary>
		/// 見出科目は取込対象外です。
		/// </summary>
		public static string CM_MS_13_S11_02
		{
			get { return MultiLanguage.Get("CM_AM001701"); }
		}

		#endregion
		#region CM_MS_15
		/// <summary>
		/// 該当の[%s]の個人番号は既に登録されています。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>該当の[<paramref name="item"/>]の個人番号は既に登録されています。</returns>
		public static string CM_MS_15_S02_02(string item)
		{
			return new StringBuilder("該当の[").Append(item).Append("］の個人番号は既に登録されています。").ToString();
		}
		/// <summary>
		/// %sファイルの削除に失敗しました。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="item"/>ファイルの削除に失敗しました。</returns>
		public static string CM_MS_15_S04_01(string item)
		{
			return new StringBuilder(item).Append("ファイルの削除に失敗しました。").ToString();
		}
		/// <summary>
		/// 該当の仕入先がWF削除申請中のため、更新できません。
		/// </summary>
		public static readonly string CM_MS_15_S07_01 = "該当の仕入先がWF申請中のため、更新できません。";

		/// <summary>
		/// 該当の仕入先の個人番号は既に登録されています。
		/// </summary>
		public static readonly string CM_MS_15_S07_02 = "該当の仕入先の個人番号は既に登録されています。";

		#endregion
		#region CM_MS_16
		/// <summary>
		/// 機能のチェックボックスは1つ以上選択してください。
		/// </summary>
		public static string CM_MS_16_S01_01
		{
			get { return MultiLanguage.Get("CM_AM001773"); }
		}
		/// <summary>
		/// コントロールがDropDownListの場合、汎用項目値設定の設定が必要です。
		/// </summary>
		public static string CM_MS_16_S01_02
		{
			get { return MultiLanguage.Get("CM_AM001770"); }
		}
		#endregion
		#endregion
		#region CM_WF
		#region CM_WF
		/// <summary>
		/// (仮) 合計金額が決裁権限を越えました。この伝票を承認することはできません。
		/// </summary>

// 		public static readonly string CM_WF_S10001 = "合計金額が決裁権限を越えました。この伝票を承認することはできません。";
		public static string CM_WF_S10001
		{
			get {return MultiLanguage.Get("CM_AM000924");}
		}

		#endregion
		#region CM_WF_01
		/// <summary>
		/// 経路には 1 名以上の承認者または合議者が必要です。
		/// </summary>

// 		public static readonly string CM_WF_01_S05_01 = "経路には 1 名以上の承認者または合議者が必要です。";
		public static string CM_WF_01_S05_01
		{
			get {return MultiLanguage.Get("CM_AM000853");}
		}

		/// <summary>
		/// 合議者は連続する階層の 1 名以上で構成してください。
		/// </summary>

// 		public static readonly string CM_WF_01_S05_02 = "合議者は連続する階層の 2 名以上で構成してください。";
		public static string CM_WF_01_S05_02
		{
			get {return MultiLanguage.Get("CM_AM000923");}
		}

		/// <summary>
		/// ［承認可能金額］ は前階層より大きい金額を入力してください。
		/// </summary>

// 		public static readonly string CM_WF_01_S05_03 = "［承認可能金額］ は前階層より大きい金額を入力してください。";
		public static string CM_WF_01_S05_03
		{
			get {return MultiLanguage.Get("CM_AM000154");}
		}

		/// <summary>
		/// 前階層の承認者を設定してください。
		/// </summary>

// 		public static readonly string CM_WF_01_S05_04 = "前階層の承認者を設定してください。";
		public static string CM_WF_01_S05_04
		{
			get {return MultiLanguage.Get("CM_AM001206");}
		}

		/// <summary>
		/// 下位の階層に合議者、報告者が含まれる場合は垂直代理承認者に設定できません。
		/// </summary>

// 		public static readonly string CM_WF_01_S05_05 = "下位の階層に合議者、報告者が含まれる場合は垂直代理承認者に設定できません。";
		public static string CM_WF_01_S05_05
		{
			get {return MultiLanguage.Get("CM_AM000739");}
		}

		/// <summary>
		/// ［%s］ は垂直代理承認者に設定できません。
		/// </summary>
		/// <param name="person">承認者</param>
		/// <returns>［<paramref name="person"/>］ は垂直代理承認者に設定できません。</returns>
		public static string CM_WF_01_S05_06(string person)
		{
// 			return new StringBuilder("［", 32).Append(person).Append("］ は垂直代理承認者に設定できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(person).Append(MultiLanguage.Get("CM_AM000267")).ToString();
		}
		/// <summary>
		/// 経路ID の採番に失敗しました。
		/// </summary>

// 		public static readonly string CM_WF_01_S05_07 = "経路ID の採番に失敗しました。";
		public static string CM_WF_01_S05_07
		{
			get {return MultiLanguage.Get("CM_AM000852");}
		}

		/// <summary>
		/// ［承認可能粗利率］ は前階層より小さい値を入力してください。
		/// </summary>

		public static string CM_WF_01_S05_08
		{
			get { return MultiLanguage.Get("CM_AM001652"); }
		}

		/// <summary>
		/// ［承認可能金額］ は前階層以上の値を入力してください。
		/// </summary>

		public static string CM_WF_01_S05_09
		{
			get { return MultiLanguage.Get("CM_AM001696"); }
		}

		/// <summary>
		/// ［承認可能金額］ と ［承認可能粗利率］ のどちらかは前階層と異なる値を入力してください。
		/// </summary>

		public static string CM_WF_01_S05_10
		{
			get { return MultiLanguage.Get("CM_AM001697"); }
		}

		#endregion
		#region CM_WF_03
		/// <summary>
		/// 承認添付資料IDの採番に失敗しました。
		/// </summary>

// 		public static readonly string CM_WF_03_S03_01 = "承認添付資料IDの採番に失敗しました。";
		public static string CM_WF_03_S03_01
		{
			get {return MultiLanguage.Get("CM_AM001156");}
		}

		/// <summary>
		/// 承認添付資料IDの採番に失敗しました。
		/// </summary>

// 		public static readonly string CM_WF_03_S03_02 = "保存先のパスが正しく設定されていません。";
		public static string CM_WF_03_S03_02
		{
			get {return MultiLanguage.Get("CM_AM001384");}
		}

		#endregion
		#region CM_WF_04
		/// <summary>
		/// 承認しました。
		/// </summary>

// 		public static readonly string CM_WF_04_S01_01 = "承認しました。";
		public static string CM_WF_04_S01_01
		{
			get {return MultiLanguage.Get("CM_AM001147");}
		}

		/// <summary>
		/// 承認対象の行が選択されていません。
		/// </summary>

// 		public static readonly string CM_WF_04_S01_02 = "承認対象の行が選択されていません。";
		public static string CM_WF_04_S01_02
		{
			get {return MultiLanguage.Get("CM_AM001155");}
		}

		#endregion
		#region CM_WF_05
		public static string CM_WF_05_S01_01(string item1)
		{
// 			return new StringBuilder(item1).Append("に").Append("変更前と同一の社員コードは入力できません。").ToString(); 
			return new StringBuilder(item1).Append(MultiLanguage.Get("CM_AM000612")).Append(MultiLanguage.Get("CM_AM001378")).ToString();
		}
		#endregion		
		#endregion
		#region CM_OC
		#region CM_OC
		/// <summary>
		/// 対象組織変更の振分設定が確定されたため更新できません。
		/// </summary>

// 		public static readonly string CM_OC_S20001 = "対象組織変更の振分設定が確定されたため更新できません。";
		public static string CM_OC_S20001
		{
			get {return MultiLanguage.Get("CM_AM001235");}
		}

		#endregion
		#region CM_OC_03
		/// <summary>
		/// ［%s］の振分設定を確定しました。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］の振分設定を確定しました。</returns>
		public static string CM_OC_03_S01_01(string item)
		{
// 			return new StringBuilder("［", 32).Append(item).Append("］の振分設定を確定しました。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000372")).ToString();
		}
		/// <summary>
		/// ［%s］の振分設定の確定を解除しました。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］の振分設定の確定を解除しました。</returns>
		public static string CM_OC_03_S01_02(string item)
		{
// 			return new StringBuilder("［", 32).Append(item).Append("］の振分設定の確定を解除しました。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000371")).ToString();
		}
		#endregion
		#endregion

		#region CM_HS
		#region CM_HS
		/// <summary>
		/// Excelテンプレートがありません。
		/// </summary>
		public static string CM_HS_S10001
		{
			get {return MultiLanguage.Get("CM_AM001749");}
		}

		/// <summary>
		/// テンプレートファイルの読込に失敗しました。
		/// </summary>
		public static string CM_HS_S10002
		{
			get {return MultiLanguage.Get("CM_AM001751");}
		}

		/// <summary>
		/// テンプレートファイルに設定可能な行数または列数を超えています。
		/// </summary>
		public static string CM_HS_S10003
		{
			get {return MultiLanguage.Get("CM_AM001752");}
		}

		/// <summary>
		/// 集計項目に集計キーが指定されていません。
		/// </summary>
		public static string CM_HS_S10004
		{
			get {return MultiLanguage.Get("CM_AM001753");}
		}

		/// <summary>
		/// フッタ項目を指定するとき、明細部または集計部は必須です。
		/// </summary>
		public static string CM_HS_S10005
		{
			get {return MultiLanguage.Get("CM_AM001754");}
		}

		/// <summary>
		/// 集計キーに対応する明細ブレイクキーが指定されていません。
		/// </summary>
		public static string CM_HS_S10006
		{
			get {return MultiLanguage.Get("CM_AM001755");}
		}

		/// <summary>
		/// 集計項目に対応する明細項目が指定されていません。
		/// </summary>
		public static string CM_HS_S10007
		{
			get {return MultiLanguage.Get("CM_AM001756");}
		}

		/// <summary>
		/// 集計項目に数値以外の文字列が指定されています。
		/// </summary>
		public static string CM_HS_S10008
		{
			get {return MultiLanguage.Get("CM_AM001757");}
		}

		/// <summary>
		/// 複数のテーブル項目IDに対して、同じテーブル項目名が設定されています。
		/// </summary>
		public static string CM_HS_S10009(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001758"), item);
		}

		/// <summary>
		/// 同一の明細が既に設定されています。
		/// </summary>
		public static string CM_HS_S10010
		{
			get { return MultiLanguage.Get("CM_AM001746"); }
		}

		/// <summary>
		/// カタログ項目の型が日付または数値の場合、条件に前方一致と部分一致は使用できません。
		/// </summary>
		public static string CM_HS_S10011
		{
			get { return MultiLanguage.Get("CM_AM001748"); }
		}

		/// <summary>
		/// 同じ画面項目を複数使用する場合は、必須チェックに同じ値を設定してください。
		/// </summary>
		public static string CM_HS_S10012
		{
			get { return MultiLanguage.Get("CM_AM001747"); }
		}

		/// <summary>
		/// 会社コード以外の[明細行]は必須です。
		/// </summary>
		public static string CM_HS_S10013
		{
			get { return MultiLanguage.Get("CM_AM001775"); }
		}
		#endregion
		#region CM_HS_03
		/// <summary>
		/// 出力対象データが %d 件を超えています。検索条件を見直してください。
		/// </summary>
		/// <param name="count">出力件数</param>
		/// <returns>出力対象データが <paramref name="count"/> 件を超えています。検索条件を見直してください。</returns>
		public static string CM_HS_03_S05_01(int count)
		{
// 			return new StringBuilder("出力対象データが ", 32).Append(count.ToString("#,##0")).Append(" 件を超えています。検索条件を見直してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001129"), 32).Append(count.ToString("#,##0")).Append(MultiLanguage.Get("CM_AM000082")).ToString();
		}
		/// <summary>
		/// 現在処理されている汎用出力指示が %d 件に達しているため、出力指示はできません。（オンライン出力は可能です。）
		/// </summary>
		/// <param name="count">同時実行件数</param>
		/// <returns>現在処理されている汎用出力指示が <paramref name="count"/> 件に達しているため、出力指示はできません。（オンライン出力は可能です。）</returns>
		public static string CM_HS_03_S05_02(int count)
		{
// 			return new StringBuilder("現在処理されている汎用出力指示が ", 32).Append(count.ToString("#,##0")).Append(" 件に達しているため、出力指示はできません。（オンライン出力は可能です。）").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000888"), 32).Append(count.ToString("#,##0")).Append(MultiLanguage.Get("CM_AM000076")).ToString();
		}
		/// <summary>
		/// 現在スケジュールされている汎用出力指示が %d 件に達しているため、出力指示のスケジュールはできません。（オンライン出力は可能です。）
		/// </summary>
		/// <param name="count">出力件数</param>
		/// <returns>現在スケジュールされている汎用出力指示が <paramref name="count"/> 件に達しているため、出力指示のスケジュールはできません。（オンライン出力は可能です。）</returns>
		public static string CM_HS_03_S05_03(int count)
		{
// 			return new StringBuilder("現在スケジュールされている汎用出力指示が ", 32).Append(count.ToString("#,##0")).Append(" 件に達しているため、出力指示のスケジュールはできません。（オンライン出力は可能です。）").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000884"), 32).Append(count.ToString("#,##0")).Append(MultiLanguage.Get("CM_AM000075")).ToString();
		}
		/// <summary>
		/// 出力対象データが %d 件を超えています。[出力指示]ボタンから汎用出力指示機能を使用してください。
		/// </summary>
		/// <param name="count">出力件数</param>
		/// <returns>出力対象データが <paramref name="count"/> 件を超えています。[出力指示]ボタンから汎用出力指示機能を使用してください。</returns>
		public static string CM_HS_03_S05_04(int count)
		{
// 			return new StringBuilder("出力対象データが ", 32).Append(count.ToString("#,##0")).Append(" 件を超えています。[出力指示]ボタンから汎用出力指示機能を使用してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001129"), 32).Append(count.ToString("#,##0")).Append(MultiLanguage.Get("CM_AM000081")).ToString();
		}
		/// <summary>
		/// 汎用出力指示を開始しました。
		/// </summary>

// 		public static readonly string CM_HS_03_S05_05 = "汎用出力指示を開始しました。";
		public static string CM_HS_03_S05_05
		{
			get {return MultiLanguage.Get("CM_AM001352");}
		}

		/// <summary>
		/// 汎用出力指示をスケジュールしました。
		/// </summary>

// 		public static readonly string CM_HS_03_S05_06 = "汎用出力指示をスケジュールしました。";
		public static string CM_HS_03_S05_06
		{
			get {return MultiLanguage.Get("CM_AM001351");}
		}

		/// <summary>
		/// Excelテンプレートを登録しました。
		/// </summary>
		public static string CM_HS_03_S05_07
		{
			get {return MultiLanguage.Get("CM_AM001744");}
		}

		/// <summary>
		/// Excelテンプレートを削除しました。
		/// </summary>
		public static string CM_HS_03_S05_08
		{
			get {return MultiLanguage.Get("CM_AM001745");}
		}

		/// <summary>
		/// カタログコードに、ファイル名に使用できない文字が含まれています。
		/// </summary>
		public static string CM_HS_03_S05_09
		{
			get {return MultiLanguage.Get("CM_AM001750");}
		}
		/// <summary>
		/// 出力対象データが %d 件を超えています。
		/// </summary>
		/// <param name="count">出力件数</param>
		/// <returns>出力対象データが <paramref name="count"/> 件を超えています。[出力指示]ボタンから汎用出力指示機能を使用してください。</returns>
		public static string CM_HS_03_S09_01(int count)
		{
			//return new StringBuilder("出力対象データが ", 32).Append(count.ToString("#,##0")).Append(" 件を超えています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001129"), 32).Append(count.ToString("#,##0")).Append(MultiLanguage.Get("CM_AM001759")).ToString();
		}
		/// <summary>
		/// ［%s］の検索値が不正です。
		/// </summary>
		/// <param name="item0">画面項目名</param>
		/// <returns>［<paramref name="item0"/>］ の検索値が不正です。</returns>
		public static string CM_HS_03_S09_02(string item0)
		{
			return string.Format(MultiLanguage.Get("CM_AM001760"), item0);
		}

		#endregion
		#endregion
		#region CM_XE
		#region CM_XE
		/// <summary>
		/// ecoDeliver連携に必要な情報がオプション情報に設定されていません。
		/// </summary>
		public static string CM_XE_R20001
		{
			// ecoDeliver連携に必要な情報がオプション情報に設定されていません。
			get { return MultiLanguage.Get("CM_CS004274"); }
		}

		/// <summary>
		/// ecoDeliver連携の認証に失敗しました：
		/// </summary>
		public static string CM_XE_R20002
		{
			// ecoDeliver連携の認証に失敗しました：
			get { return MultiLanguage.Get("CM_CS004276"); }
		}

		/// <summary>
		/// ecoDeliver連携に必要な情報がマスタ連携管理に設定されていません。
		/// </summary>
		public static string CM_XE_R20003
		{
			// ecoDeliver連携に必要な情報がマスタ連携管理に設定されていません。
			get { return MultiLanguage.Get("CM_CS004280"); }
		}

		/// <summary>
		/// ecoDeliver連携のAPIの呼び出しに失敗しました：
		/// </summary>
		public static string CM_XE_R20004
		{
			// ecoDeliver連携のAPIの呼び出しに失敗しました：
			get { return MultiLanguage.Get("CM_CS004275"); }
		}

		/// <summary>
		/// ecoDeliver連携の送付先登録・更新に失敗しました：
		/// </summary>
		public static string CM_XE_R20005
		{
			// ecoDeliver連携の送付先登録・更新に失敗しました：
			get { return MultiLanguage.Get("CM_CS004277"); }
		}

		/// <summary>
		/// メソッドのパラメータが未設定です。
		/// </summary>
		public static string CM_XE_R20006
		{
			// メソッドのパラメータが未設定です。
			get { return MultiLanguage.Get("CM_CS004282"); }
		}

		/// <summary>
		/// ecoDeliver連携の帳票ZIP用発番値の取得に失敗しました：
		/// </summary>
		public static string CM_XE_R20007
		{
			// ecoDeliver連携の帳票ZIP用発番値の取得に失敗しました：
			get { return MultiLanguage.Get("CM_CS004278"); }
		}

		/// <summary>
		/// ecoDeliver連携のZIP帳票登録に失敗しました：
		/// </summary>
		public static string CM_XE_R20008
		{
			// ecoDeliver連携のZIP帳票登録に失敗しました：
			get { return MultiLanguage.Get("CM_CS004279"); }
		}

		/// <summary>
		/// ecoDeliver連携の認証削除に失敗しました。
		/// </summary>
		public static string CM_XE_R20009
		{
			// ecoDeliver連携の認証削除に失敗しました。
			get { return MultiLanguage.Get("CM_CS004281"); }
		}
		#endregion
		#endregion

		#endregion

		#region FI
		#region FI_AP
		/// <summary>
		/// %d 件の定期支払申請データを作成しました。
		/// </summary>
		/// <param name="count">データ件数</param>
		/// <returns><paramref name="item"/> 件の定期支払申請データを作成しました。</returns>
		public static string FI_AP_S00001(int count)
		{
// 			return new StringBuilder(count.ToString("#,##0"), 32).Append(" 件の定期支払申請データを作成しました。").ToString(); 
			return new StringBuilder(count.ToString("#,##0"), 32).Append(MultiLanguage.Get("CM_AM000079")).ToString();
		}
		/// <summary>
		/// 支払締処理が完了しました。
		/// </summary>

// 		public static readonly string FI_AP_S00002 = "支払締処理が完了しました。";
		public static string FI_AP_S00002
		{
			get {return MultiLanguage.Get("CM_AM001044");}
		}

		/// <summary>
		/// 支払予定作成処理が完了しました。
		/// </summary>

// 		public static readonly string FI_AP_S00003 = "支払予定作成処理が完了しました。";
		public static string FI_AP_S00003
		{
			get {return MultiLanguage.Get("CM_AM001048");}
		}

		/// <summary>
		/// ［雑支払先の口座区分］ に無効な値が指定されています。外貨のときは、 ［口座区分］ に銀行かブランクを指定してください。
		/// </summary>

// 		public static readonly string FI_AP_S10001 = "［雑支払先の口座区分］ に無効な値が指定されています。外貨のときは、 ［口座区分］ に銀行かブランクを指定してください。";
		public static string FI_AP_S10001
		{
			get {return MultiLanguage.Get("CM_AM000141");}
		}

		/// <summary>
		/// %s が ［%s］ を上回っています。\r\n %s を修正してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="item3">項目名 3</param>
		/// <returns><paramref name="item1"/> が ［<paramref name="item2"/>］ を上回っています。\r\n <paramref name="item3"/>を修正してください。</returns>
		public static string FI_AP_S10002(string item1, string item2, string item3)
		{
// 			return new StringBuilder("", 64).Append(item1).Append(" が ［").Append(item2).Append("］ を上回っています。\r\n").Append(item3).Append(" を修正してください。").ToString(); 
			return new StringBuilder("", 64).Append(item1).Append(MultiLanguage.Get("CM_AM000012")).Append(item2).Append(MultiLanguage.Get("CM_AM000291")).Append(item3).Append(MultiLanguage.Get("CM_AM000055")).ToString();
		}
		/// <summary>
		/// ［%s］ が ［%s］ を上回っています。\r\n差額を振替えるか金額を修正してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ が ［<paramref name="item2"/>］ を上回っています。\r\n差額を振替えるか金額を修正してください。</returns>
		public static string FI_AP_S10003(string item1, string item2)
		{
// 			return new StringBuilder("［", 64).Append(item1).Append("］ が ［").Append(item2).Append("］ を上回っています。\r\n差額を振替えるか金額を修正してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000184")).Append(item2).Append(MultiLanguage.Get("CM_AM000292")).ToString();
		}
		/// <summary>
		/// 消込対象が選択されていません。
		/// </summary>

// 		public static readonly string FI_AP_S10004 = "消込対象の明細が選択されていません。";
		public static string FI_AP_S10004
		{
			get {return MultiLanguage.Get("CM_AM001161");}
		}

		/// <summary>
		/// 前渡金または債務振替に存在する為替予約番号と異なる為替予約番号を持つ伝票は消込できません。\r\n消込対象選択を変更してください。
		/// </summary>

// 		public static readonly string FI_AP_S10005 = "前渡金または債務振替に存在する為替予約番号と異なる為替予約番号を持つ伝票は消込できません。\r\n消込対象選択を変更してください。";
		public static string FI_AP_S10005
		{
			get {return MultiLanguage.Get("CM_AM001208");}
		}

		/// <summary>
		/// 課税しない仕入先、または海外仕入先の場合、税抜または税込の［明細コード］は指定できません。
		/// </summary>
		public static string FI_AP_S10006
		{
			get { return MultiLanguage.Get("CM_AM001644"); }
		}

		/// <summary>
		///  %s 行目： 課税しない仕入先、または海外仕入先の場合、税抜または税込の［明細コード］は指定できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns><paramref name="lineNo"/> 行目： 課税しない仕入先、または海外仕入先の場合、税抜または税込の［明細コード］は指定できません。</returns>
		public static string FI_AP_S10007(string lineNo)
		{
			return string.Format(MultiLanguage.Get("CM_AM001630"), lineNo);
		}

		/// <summary>
		/// ［口座区分］が銀行で［国コード］が%sのとき、［口座番号］は7桁以内で入力して下さい。
		/// </summary>
		/// <param name="code">国コード</param>
		/// <returns><paramref name="code"/>［口座区分］が銀行で［国コード］が%sのとき、［口座番号］は7桁以内で入力して下さい。</returns>
		public static string FI_AP_S10008(string code)
		{
			return string.Format(MultiLanguage.Get("CM_AM001712"), code);
		}

		/// <summary>
		/// ［口座区分］が銀行で［国コード］が%sのとき、［口座名義人］は48文字以内で入力して下さい。
		/// </summary>
		/// <param name="code">国コード</param>
		/// <returns><paramref name="code"/>［口座区分］が銀行で［国コード］が%sのとき、［口座名義人］は48文字以内で入力して下さい。</returns>
		public static string FI_AP_S10009(string code)
		{
			return string.Format(MultiLanguage.Get("CM_AM001713"), code);
		}

		/// <summary>
		/// [国コード]が%s以外のとき、[振込方法]にEBは選択できません。
		/// </summary>
		/// <param name="code">国コード</param>
		/// <returns><paramref name="code"/>[国コード]が%s以外のとき、[振込方法]にEBは選択できません。</returns>
		public static string FI_AP_S10010(string code)
		{
			return string.Format(MultiLanguage.Get("CM_AM001723"), code);
		}

		/// <summary>
		/// 消込対象に選択された %s に他のユーザによって変更、もしくは削除された明細があります。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>消込対象に選択された <paramref name="item"/> に他のユーザによって変更、もしくは削除された明細があります。</returns>
		public static string FI_AP_S20001(string item)
		{
// 			return new StringBuilder("消込対象に選択された ", 64).Append(item).Append(" に他のユーザによって変更、もしくは削除された明細があります。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001158"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000022")).ToString();
		}
		/// <summary>
		/// 前渡支払は、同一の支払より作成された前渡金と消込できません。
		/// </summary>

// 		public static readonly string FI_AP_S20002 = "前渡支払は、同一の支払より作成された前渡金と消込できません。";
		public static string FI_AP_S20002
		{
			get {return MultiLanguage.Get("CM_AM001209");}
		}

		/// <summary>
		/// 外貨建て前渡支払は複数の前渡金にまたがって消込できません。\r\n1つの前渡金で消込まれる様、消込対象選択を変更してください。
		/// </summary>

// 		public static readonly string FI_AP_S20003 = "外貨建て前渡支払は複数の前渡金にまたがって消込できません。\r\n1つの前渡金で消込まれる様、消込対象選択を変更してください。";
		public static string FI_AP_S20003
		{
			get {return MultiLanguage.Get("CM_AM000762");}
		}

		/// <summary>
		/// 債務計上が同時に発生する支払決済の決済レート、為替区分、為替予約番号は複数混在できません。
		/// </summary>

// 		public static readonly string FI_AP_S20004 = "債務計上が同時に発生する支払決済の決済レート、為替区分、為替予約番号は複数混在できません。";
		public static string FI_AP_S20004
		{
			get {return MultiLanguage.Get("CM_AM000929");}
		}

		/// <summary>
		/// 相殺指示した請求に未承認の回収消込が存在するため更新できません。
		/// </summary>

// 		public static readonly string FI_AP_S20005 = "相殺指示した請求に未承認の回収消込が存在するため更新できません。";
		public static string FI_AP_S20005
		{
			get {return MultiLanguage.Get("CM_AM001221");}
		}

		/// <summary>
		/// 取得済み明細データが失われました。再度、明細データを取得してください。
		/// </summary>

// 		public static readonly string FI_AP_01_S04_01 = "取得済み明細データが失われました。再度、明細データを取得してください。";
		public static string FI_AP_01_S04_01
		{
			get {return MultiLanguage.Get("CM_AM001100");}
		}

		/// <summary>
		/// 締条件が都度支払の支払先は登録できません。
		/// </summary>

// 		public static readonly string FI_AP_01_S05_01 = "締条件が都度支払の支払先は登録できません。";
		public static string FI_AP_01_S05_01
		{
			get {return MultiLanguage.Get("CM_AM001261");}
		}

		/// <summary>
		/// 雑支払先は登録できません。
		/// </summary>

// 		public static readonly string FI_AP_01_S05_02 = "雑支払先は登録できません。";
		public static string FI_AP_01_S05_02
		{
			get {return MultiLanguage.Get("CM_AM000957");}
		}

		/// <summary>
		/// %s の入力はできません。
		/// </summary>
		/// <param name="name"></param>
		/// <returns><paramref name="name"/> の入力はできません。</returns>
		public static string FI_AP_01_S09_01(string name)
		{
// 			return new StringBuilder("［").Append(name).Append("］の入力はできません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131")).Append(name).Append(MultiLanguage.Get("CM_AM000377")).ToString();
		}
		/// <summary>
		/// %s 明細 %s 入力可能です。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns> <paramref name="item1"/> 明細 <paramref name="item2"/> 入力可能です。</returns>
		public static string FI_AP_01_S09_02(string item1, string item2)
		{
// 			return new StringBuilder(item1).Append(" 明細 ").Append(item2).Append(" 入力可能です。").ToString(); 
			return new StringBuilder(item1).Append(MultiLanguage.Get("CM_AM000111")).Append(item2).Append(MultiLanguage.Get("CM_AM000105")).ToString();
		}

		/// <summary>
		/// ［%s］が控除外課税仕入の場合、［{%s］に雑仕入先は登録できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns> ［<paramref name="item1"/>］が控除外課税仕入の場合、［<paramref name="item2"/>］に雑仕入先は登録できません。</returns>
		public static string FI_AP_03_S02_01(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001830"), item1, item2);
		}

		/// <summary>
		/// ［%s］が控除外課税仕入の場合、［%s］は選択できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］が控除外課税仕入の場合、［<paramref name="item2"/>］は選択できません。</returns>
		public static string FI_AP_03_S02_02(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001832"), item1, item2);
		}

		/// <summary>
		/// %s 行目:［%s］が控除外課税仕入の場合、［%s］に雑仕入先は登録できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/>行目:［<paramref name="item1"/>］が控除外課税仕入の場合、［<paramref name="item2"/>］に雑仕入先は登録できません。</returns>
		public static string FI_AP_03_S02_03(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001831"), lineNo, item1, item2);
		}

		/// <summary>
		/// %s 行目:［%s］が控除外課税仕入の場合、［%s］は選択できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/>行目:［<paramref name="item1"/>］が控除外課税仕入の場合、［<paramref name="item2"/>］は選択できません。</returns>
		public static string FI_AP_03_S02_04(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001833"), lineNo, item1, item2);
		}

		/// <summary>
		/// %s 行目:［%s］に入場券等または自動サービス機を選択時に、［%s］に雑仕入先は登録できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/>行目:［<paramref name="item1"/>］に入場券等または自動サービス機を選択時に、［<paramref name="item2"/>］に雑仕入先は登録できません。</returns>
		public static string FI_AP_03_S02_05(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001813"), lineNo, item1, item2);
		}

		/// <summary>
		/// 支払集計部門階層が自部門階層より上位のため指示できません。
		/// </summary>

// 		public static readonly string FI_AP_04_S01_01 = "支払集計部門階層が自部門階層より上位のため指示できません。";
		public static string FI_AP_04_S01_01
		{
			get {return MultiLanguage.Get("CM_AM001040");}
		}

		/// <summary>
		/// 裏書／譲渡手形番号：%sは存在しないか、有効な未決済裏書手形または未決済譲渡手形ではありません。
		/// </summary>
		/// <param name="code">裏書／譲渡手形番号</param>
		/// <returns>裏書／譲渡手形番号： <paramref name="code"/> は存在しないか、有効な未決済裏書手形または未決済譲渡手形ではありません。</returns>
		public static string FI_AP_04_S05_01(string code)
		{
//// 			return new StringBuilder("裏書手形番号： ", 64).Append(code).Append(" は存在しないか、有効な未決済裏書手形ではありません。").ToString(); 
//			return new StringBuilder(MultiLanguage.Get("CM_AM001428"), 64).Append(code).Append(MultiLanguage.Get("CM_AM000043")).ToString();
			return string.Format(MultiLanguage.Get("CM_AM001668"), code);
		}
		/// <summary>
		/// 支払予定番号： %s は振込情報が確定されていないため、承認できません。
		/// </summary>
		/// <param name="code">支払予定番号</param>
		/// <returns>支払予定番号： <paramref name="code"/> は振込情報が確定されていないため、承認できません。</returns>
		public static string FI_AP_04_S23_01(string code)
		{
// 			return new StringBuilder("支払予定番号： ", 64).Append(code).Append(" は振込情報が確定されていないため、承認できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001049"), 64).Append(code).Append(MultiLanguage.Get("CM_AM000042")).ToString();
		}

		/// <summary>
		/// ・［%s］ （繰越元の支払予定が承認されていないため、データの更新ができません。）
		/// </summary>
		/// <param name="code">支払予定番号</param>
		/// <returns>・<paramref name="code"/> （繰越元の支払予定が承認されていないため、データの更新ができません。）</returns>
		public static string FI_AP_04_S23_02(string code)
		{
// 			return new StringBuilder("・", 64).Append(code).Append(" （繰越元の支払予定が承認されていないため、データの更新ができません。）").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000428"), 64).Append(code).Append(MultiLanguage.Get("CM_AM000005")).ToString();
		}
		/// <summary>
		/// ・［%s］ （繰越先の支払予定が承認済のため、データの更新ができません。）
		/// </summary>
		/// <param name="code">支払予定番号</param>
		/// <returns>・<paramref name="code"/> （繰越先の支払予定が承認済のため、データの更新ができません。）</returns>
		public static string FI_AP_04_S23_03(string code)
		{
// 			return new StringBuilder("・", 64).Append(code).Append(" （繰越先の支払予定が承認済のため、データの更新ができません。）").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000428"), 64).Append(code).Append(MultiLanguage.Get("CM_AM000007")).ToString();
		}
		/// <summary>
		/// ［%s］ が裏書手形番号： %s の %s と一致していません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="code">裏書手形番号</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ が裏書手形番号： <paramref name="code"/> の <paramref name="item2"/> と一致していません。</returns>
		public static string FI_AP_04_S05_02(string item1, string code, string item2)
		{
// 			return new StringBuilder("［", 64).Append(item1).Append("］ が裏書手形番号： ").Append(code).Append(" の ").Append(item2).Append(" と一致していません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000203")).Append(code).Append(MultiLanguage.Get("CM_AM000024")).Append(item2).Append(MultiLanguage.Get("CM_AM000020")).ToString();
		}
		/// <summary>
		/// ［%s］ が譲渡手形番号： %s の %s と一致していません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="code">譲渡手形番号</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ が譲渡手形番号： <paramref name="code"/> の <paramref name="item2"/> と一致していません。</returns>
		public static string FI_AP_04_S05_03(string item1, string code, string item2)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM001687")).Append(code).Append(MultiLanguage.Get("CM_AM000024")).Append(item2).Append(MultiLanguage.Get("CM_AM000020")).ToString();
		}
		/// <summary>
		/// 入力された裏書手形または譲渡手形が支払済みのため更新できません。
		/// </summary>
		public static string FI_AP_04_S05_04
		{
			get { return MultiLanguage.Get("CM_AM001667"); }
		}
		/// <summary>
		/// [%s]の支払先振込情報が設定されていません。仕入先マスタにて振込情報を設定して下さい。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <returns>［<paramref name="item1"/>］の支払先振込情報が設定されていません。仕入先マスタにて振込情報を設定して下さい。</returns>
		public static string FI_AP_05_S01_01(string item1)
		{
// 			return new StringBuilder("［", 64).Append(item1).Append("］の支払先の振込先情報が設定されていません。仕入先マスタにて振込先情報を設定して下さい。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000368")).ToString();
		}
		/// <summary>
		/// 決裁取消状態の伝票が含まれています。
		/// </summary>

// 		public static readonly string FI_AP_05_S01_02 = "決裁取消状態の伝票が含まれています。";
		public static string FI_AP_05_S01_02
		{
			get {return MultiLanguage.Get("CM_AM000862");}
		}

		/// <summary>
		/// 支払締時に作成された消込伝票は削除のみ可能です。
		/// </summary>

// 		public static readonly string FI_AP_05_S04_01 = "支払締時に作成された消込伝票は削除のみ可能です。";
		public static string FI_AP_05_S04_01
		{
			get {return MultiLanguage.Get("CM_AM001043");}
		}

		/// <summary>
		/// マイナス金額の支払振替は、プラス金額の支払振替及び前渡金と同時に入力できません。
		/// </summary>

// 		public static readonly string FI_AP_05_S04_02 = "マイナス金額の支払振替は、プラス金額の支払振替及び前渡金と同時に入力できません。";
		public static string FI_AP_05_S04_02
		{
			get {return MultiLanguage.Get("CM_AM000664");}
		}

		/// <summary>
		/// 消込対象に選択した債務は、消込金額にゼロを指定できません。
		/// </summary>

// 		public static readonly string FI_AP_05_S04_03 = "消込対象に選択した債務は、消込金額にゼロを指定できません。";
		public static string FI_AP_05_S04_03
		{
			get {return MultiLanguage.Get("CM_AM001159");}
		}

		/// <summary>
		/// ［%s］ が変更されているため、更新できません。
		/// </summary>
		/// <param name="item"></param>
		/// <returns>［<paramref name="item"/>］ が変更されているため、更新できません。</returns>
		public static string FI_AP_05_S04_04(string item)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］ が変更されているため、更新できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000198")).ToString();
		}
		/// <summary>
		/// 他の消込で相殺が決済された支払を含むため削除できません。
		/// </summary>

// 		public static readonly string FI_AP_05_S04_05 = "他の消込で相殺が決済された支払を含むため削除できません。";
		public static string FI_AP_05_S04_05
		{
			get {return MultiLanguage.Get("CM_AM001226");}
		}

		/// <summary>
		/// 履歴伝票は一部消込できません。
		/// </summary>

// 		public static readonly string FI_AP_05_S04_06 = "履歴伝票は一部消込できません。";
		public static string FI_AP_05_S04_06
		{
			get {return MultiLanguage.Get("CM_AM001427");}
		}

		/// <summary>
		/// 自動前渡金消込分の削除は支払承認取消後行ってください。
		/// </summary>

// 		public static readonly string FI_AP_05_S04_07 = "自動前渡金消込分の削除は支払承認取消後行ってください。";
		public static string FI_AP_05_S04_07
		{
			get {return MultiLanguage.Get("CM_AM001075");}
		}

		/// <summary>
		/// 支払書番号： %s 計上レートの為替予約番号と異なる為替予約番号を決済レートに指定できません。
		/// </summary>
		/// <param name="code">支払番号</param>
		/// <returns>支払書番号： <paramref name="code"/> 計上レートの為替予約番号と異なる為替予約番号を決済レートに指定できません。</returns>
		public static string FI_AP_05_S06_01(string code)
		{
// 			return new StringBuilder("支払書番号： ", 64).Append(code).Append(" 計上レートの為替予約番号と異なる為替予約番号を決済レートに指定できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 64).Append(code).Append(MultiLanguage.Get("CM_AM000062")).ToString();
		}
		/// <summary>
		/// 支払書番号： %s 支払予定の裏書手形番号： %s は存在しないか、有効な未決済裏書手形ではありません。
		/// </summary>
		/// <param name="code1">支払番号</param>
		/// <param name="code2">裏書手形番号</param>
		/// <returns>支払書番号： <paramref name="code1"/> 支払予定の裏書手形番号： <paramref name="code2"/> は存在しないか、有効な未決済裏書手形ではありません。</returns>
		public static string FI_AP_05_S06_02(string code1, string code2)
		{
// 			return new StringBuilder("支払書番号： ", 96).Append(code1).Append(" 支払予定の裏書手形番号： ").Append(code2).Append(" は存在しないか、有効な未決済裏書手形ではありません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM000102")).Append(code2).Append(MultiLanguage.Get("CM_AM000043")).ToString();
		}
		/// <summary>
		/// 支払書番号： %s 支払予定の %s が裏書手形番号： %s の %s と一致していません。
		/// </summary>
		/// <param name="code1">支払番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="code2">裏書手形番号</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>支払書番号： <paramref name="code1"/> 支払予定の <paramref name="item1"/> が裏書手形番号： <paramref name="code2"/> の <paramref name="item2"/> と一致していません。</returns>
		public static string FI_AP_05_S06_03(string code1, string item1, string code2, string item2)
		{
// 			return new StringBuilder("支払書番号： ", 96).Append(code1).Append(" 支払予定の ").Append(item1).Append(" が裏書手形番号： ").Append(code2).Append(" の ").Append(item2).Append(" と一致していません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM000101")).Append(item1).Append(MultiLanguage.Get("CM_AM000016")).Append(code2).Append(MultiLanguage.Get("CM_AM000024")).Append(item2).Append(MultiLanguage.Get("CM_AM000020")).ToString();
		}
		/// <summary>
		/// 支払書番号： %s 支払予定の裏書手形番号： %s は既に支払済みです。支払予定を修正してください。
		/// </summary>
		/// <param name="code1">支払番号</param>
		/// <param name="code2">裏書手形番号</param>
		/// <returns>支払書番号： <paramref name="code1"/> 支払予定の裏書手形番号： <paramref name="code2"/> は既に支払済みです。支払予定を修正してください。</returns>
		public static string FI_AP_05_S06_04(string code1, string code2)
		{
// 			return new StringBuilder("支払書番号： ", 96).Append(code1).Append(" 支払予定の裏書手形番号： ").Append(code2).Append(" は既に支払済みです。支払予定を修正してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM000102")).Append(code2).Append(MultiLanguage.Get("CM_AM000040")).ToString();
		}
		/// <summary>
		///  %d 件の支払決済データを確定しました。
		/// </summary>
		/// <param name="count">件数</param>
		/// <returns><paramref name="count"/> 件の支払決済データを確定しました。</returns>
		public static string FI_AP_05_S06_05(int count)
		{
// 			return new StringBuilder(count.ToString("#,##0")).Append(" 件の支払決済データを確定しました。").ToString(); 
			return new StringBuilder(count.ToString("#,##0")).Append(MultiLanguage.Get("CM_AM000078")).ToString();
		}
		/// <summary>
		/// 支払書番号： %s 台帳入力が必要な支払方法が複数存在するため支払決済確定できません。支払予定を修正してください。
		/// </summary>
		/// <param name="code1">支払番号</param>
		/// <returns>支払書番号： <paramref name="code1"/> 台帳入力が必要な支払方法が複数存在するため支払決済確定できません。支払予定を修正してください。</returns>
		public static string FI_AP_05_S06_06(string code1)
		{
// 			return new StringBuilder("支払書番号： ", 96).Append(code1).Append(" 台帳入力が必要な支払方法が複数存在するため支払決済確定できません。支払予定を修正してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM000103")).ToString();
		}
		/// <summary>
		/// EBデータ番号：%s　　同一のEBデータ番号を持つ支払書が検索条件圏外に存在します。
		/// </summary>
		/// <param name="code1">EBデータ番号</param>
		/// <returns>EBデータ番号：<paramref name="code1"/> 　　同一のEBデータ番号を持つ支払書が検索条件圏外に存在します。</returns>
		public static string FI_AP_05_S06_07(string code1)
		{
// 			return new StringBuilder("EBデータ番号：", 96).Append(code1).Append("　　同一のEBデータ番号を持つ支払書が検索条件圏外に存在します。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000440"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM000000")).ToString();
		}
		/// <summary>
		/// EBデータ番号：%s　　同一のEBデータ番号を持つ支払書は同時に決済確定してください。
		/// </summary>
		/// <param name="code1">EBデータ番号</param>
		/// <returns>EBデータ番号： <paramref name="code1"/>　　同一のEBデータ番号を持つ支払書は同時に決済確定してください。</returns>
		public static string FI_AP_05_S06_08(string code1)
		{
// 			return new StringBuilder("EBデータ番号：", 96).Append(code1).Append("　　同一のEBデータ番号を持つ支払書は同時に決済確定してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000440"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM000001")).ToString();
		}
		/// <summary>
		/// 支払書番号： %s 台帳入力が必要な支払方法で、[支払予定金額]ゼロの明細が存在するため支払決済確定できません。支払予定を修正してください。
		/// </summary>
		/// <param name="code1">支払番号</param>
		/// <returns>支払書番号： <paramref name="code1"/> 台帳入力が必要な支払方法で、[支払予定金額]ゼロの明細が存在するため支払決済確定できません。支払予定を修正してください。</returns>
		public static string FI_AP_05_S06_09(string code1)
		{
			//台帳入力が必要な支払方法で、[支払予定金額]ゼロの明細が存在するため支払決済確定できません。支払予定を修正してください。
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM001786")).ToString();
		}
		/// <summary>
		/// 支払書番号： %s ［支払方法］が %s で、［区分］がでんさい（営業）、でんさい（営業外）のとき、[出金口座]は必須です。
		/// </summary>
		/// <param name="code1">支払番号</param>
		/// <param name="code2">支払方法</param>
		/// <returns>支払書番号： <paramref name="code1"/> ［支払方法］が <paramref name="code2"/> で、［区分］がでんさい（営業）、でんさい（営業外）のとき、[出金口座]は必須です。</returns>
		public static string FI_AP_05_S06_10(string code1, string code2)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 96).Append(" ").Append(code1).Append(" ").Append(string.Format(MultiLanguage.Get("CM_AM001663"), code2)).ToString();
		}
		/// <summary>
		/// 支払書番号： %s ［支払方法］が %s で、[区分]がでんさい（営業）、でんさい（営業外）のとき、指定した出金口座はでんさいネットを使用できません。
		/// </summary>
		/// <param name="code1">支払番号</param>
		/// <param name="code2">支払方法</param>
		/// <returns>支払書番号： <paramref name="code1"/> ［支払方法］が <paramref name="code2"/> で、[区分]がでんさい（営業）、でんさい（営業外）のとき、指定した出金口座はでんさいネットを使用できません。</returns>
		public static string FI_AP_05_S06_11(string code1, string code2)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 96).Append(" ").Append(code1).Append(" ").Append(string.Format(MultiLanguage.Get("CM_AM001664"), code2)).ToString();
		}
		/// <summary>
		/// 支払書番号： %s [手形金額]が100億円以上です。
		/// </summary>
		/// <param name="code1">支払書番号</param>
		/// <returns>支払書番号： <paramref name="code1"/> [手形金額]が100億円以上です。</returns>
		public static string FI_AP_05_S06_12(string code1)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 64).Append(" ").Append(code1).Append(" ").Append(MultiLanguage.Get("CM_AM001661")).ToString();
		}
		/// <summary>
		/// 支払書番号： %s [手形期日]が[振出日]の3銀行営業日以内、または1年後の日付より後の日付です。
		/// </summary>
		/// <param name="code1">支払書番号</param>
		/// <returns>支払書番号： <paramref name="code1"/> [手形期日]が[振出日]の3銀行営業日以内、または1年後の日付より後の日付です。</returns>
		public static string FI_AP_05_S06_13(string code1)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 96).Append(" ").Append(code1).Append(" ").Append(MultiLanguage.Get("CM_AM001662")).ToString();
		}
		/// <summary>
		/// 支払書番号： %s 支払予定の裏書／譲渡手形番号： %s は存在しないか、有効な未決済裏書／譲渡手形ではありません。
		/// </summary>
		/// <param name="code1">支払番号</param>
		/// <param name="code2">裏書／譲渡手形番号</param>
		/// <returns>支払書番号： <paramref name="code1"/> 支払予定の裏書／譲渡手形番号： <paramref name="code2"/> は存在しないか、有効な未決済裏書／譲渡手形ではありません。</returns>
		public static string FI_AP_05_S06_14(string code1, string code2)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM001688")).Append(code2).Append(MultiLanguage.Get("CM_AM001689")).ToString();
		}
		/// <summary>
		/// 支払書番号： %s 支払予定の %s が裏書／譲渡手形番号： %s の %s と一致していません。
		/// </summary>
		/// <param name="code1">支払番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="code2">裏書／譲渡手形番号</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>支払書番号： <paramref name="code1"/> 支払予定の <paramref name="item1"/> が裏書／譲渡手形番号： <paramref name="code2"/> の <paramref name="item2"/> と一致していません。</returns>
		public static string FI_AP_05_S06_15(string code1, string item1, string code2, string item2)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM000101")).Append(item1).Append(MultiLanguage.Get("CM_AM001690")).Append(code2).Append(MultiLanguage.Get("CM_AM000024")).Append(item2).Append(MultiLanguage.Get("CM_AM000020")).ToString();
		}
		/// <summary>
		/// 支払書番号： %s 支払予定の裏書／譲渡手形番号： %s は既に支払済みです。支払予定を修正してください。
		/// </summary>
		/// <param name="code1">支払番号</param>
		/// <param name="code2">裏書／譲渡手形番号</param>
		/// <returns>支払書番号： <paramref name="code1"/> 支払予定の裏書／譲渡手形番号： <paramref name="code2"/> は既に支払済みです。支払予定を修正してください。</returns>
		public static string FI_AP_05_S06_16(string code1, string code2)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM001688")).Append(code2).Append(MultiLanguage.Get("CM_AM000040")).ToString();
		}
		/// <summary>
		/// 支払書番号： %s [支払方法] %s の台帳入力に誤りがあります。
		/// </summary>
		/// <param name="code1">支払番号</param>
		/// <param name="name1">決済方法名</param>
		/// <returns>支払書番号： <paramref name="code1"/> [支払方法] <paramref name="name1"/> の台帳入力に誤りがあります。</returns>
		public static string FI_AP_05_S06_17(string code1, string name1)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM001041"), 96).Append(" ").Append(code1).Append(" ").Append(string.Format(MultiLanguage.Get("CM_AM001735"), name1)).ToString();
		}
		/// <summary>
		/// 支払済みの %s が既に決済されているため、支払決済取消はできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>支払済みの <paramref name="item"/> が既に決済されているため、支払決済取消はできません。</returns>
		public static string FI_AP_05_S08_01(string item)
		{
// 			return new StringBuilder("支払済みの ", 64).Append(item).Append(" が既に決済されているため、支払決済取消はできません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001039"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000014")).ToString();
		}
		/// <summary>
		/// 決済番号：%s　　同一の決済番号を持つ支払書が検索条件圏外に存在します。
		/// </summary>
		/// <param name="code1">決済番号</param>
		/// <returns>決済番号： <paramref name="code1"/> 　　同一の決済番号を持つ支払書が検索条件圏外に存在します。</returns>
		public static string FI_AP_05_S08_02(string code1)
		{
// 			return new StringBuilder("決済番号：", 96).Append(code1).Append("　　同一の決済番号を持つ支払書が検索条件圏外に存在します。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000861"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM000002")).ToString();
		}
		/// <summary>
		/// 決済番号：%s　　同一の決済番号を持つ支払書は同時に決済取消をしてください。 
		/// </summary>
		/// <param name="code1">決済番号</param>
		/// <returns>決済番号： <paramref name="code1"/> 　　同一の決済番号を持つ支払書は同時に決済取消をしてください。</returns>
		public static string FI_AP_05_S08_03(string code1)
		{
// 			return new StringBuilder("決済番号：", 96).Append(code1).Append("　　同一の決済番号を持つ支払書は同時に決済取消をしてください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000861"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM000003")).ToString();
		}
		/// <summary>
		/// 取消対象の行が選択されていません。
		/// </summary>

// 		public static readonly string FI_AP_05_S08_04 = "取消対象の行が選択されていません。";
		public static string FI_AP_05_S08_04
		{
			get {return MultiLanguage.Get("CM_AM001098");}
		}

		/// <summary>
		///  %s は ［前回%s］ 以降の日付で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="item1"/> は ［前回<paramref name="item2"/>］ 以降の日付で入力してください。</returns>
		public static string FI_AP_05_S08_05(string item1, string item2)
		{
// 			return new StringBuilder(item1).Append("は ［前回").Append(item2).Append("］ 以降の日付で入力してください。").ToString(); 
			return new StringBuilder(item1).Append(MultiLanguage.Get("CM_AM000632")).Append(item2).Append(MultiLanguage.Get("CM_AM000303")).ToString();
		}

		/// <summary>
		///  [%s]が海外の場合、[%s]に電子債権（営業）、電子債権（営業外）、でんさい（営業）、でんさい（営業外）は選択できません。
		/// </summary>
		/// <param name="item1">項目名1 </param>
		/// <param name="item2">項目名2 </param>
		public static string FI_AP_06_S10001(string item1, string item2)
		{
			return new StringBuilder("[", 64).Append(item1).Append("］ が海外の場合、［").Append(item2).Append("］ に電子債権（営業）、電子債権（営業外）、でんさい（営業）、でんさい（営業外）は選択できません。").ToString();
		}

		/// <summary>
		///  指定した[%s]はでんさいネットを使用できません。
		/// </summary>
		/// <param name="item">項目名 </param>
		public static string FI_AP_06_S10002(string item)
		{
			return new StringBuilder("指定した ［", 64).Append(item).Append("］はでんさいネットを使用できません。").ToString();
		}

		/// <summary>
		///  手形整理番号：%s [%s]の[%s]が未設定のため更新できません。
		/// </summary>
		/// <param name="code1">手形整理番号 </param>
		/// <param name="item1">項目名1 </param>
		/// <param name="item2">項目名2 </param>
		public static string FI_AP_06_S10003(string code1, string item1, string item2)
		{
			return new StringBuilder("手形整理番号：", 64).Append(code1).Append(" [").Append(item1).Append("]の[").Append(item2).Append("]が未設定のため更新できません。").ToString();
		}

		/// <summary>
		///  手形整理番号：%s [%s]が[%s]の3銀行営業日以内、または1年後の日付より後の日付です。
		/// </summary>
		/// <param name="code1">手形整理番号 </param>
		/// <param name="item1">項目名1 </param>
		/// <param name="item2">項目名2 </param>
		public static string FI_AP_06_S10004(string code1, string item1, string item2)
		{
			return new StringBuilder("手形整理番号：", 64).Append(code1).Append(" [").Append(item1).Append("]が[").Append(item2).Append("]の3銀行営業日以内、または1年後の日付より後の日付です。").ToString();
		}

		/// <summary>
		///  手形整理番号：%s 名寄せした[%s]が100億円以上です。
		/// </summary>
		/// <param name="code1">手形整理番号 </param>
		/// <param name="item1">項目名1 </param>
		public static string FI_AP_06_S10005(string code1, string item1)
		{
			return new StringBuilder("手形整理番号：", 64).Append(code1).Append(" 名寄せした[").Append(item1).Append("]が100億円以上です。").ToString();
		}

		/// <summary>
		/// でんさいEBデータ番号：%s　　同一のでんさいEBデータ番号を持つ支払手形が検索条件圏外に存在します。
		/// </summary>
		/// <param name="code1">でんさいEBデータ番号</param>
		/// <returns>でんさいEBデータ番号：<paramref name="code1"/>　　同一のでんさいEBデータ番号を持つ支払手形が検索条件圏外に存在します。</returns>
		public static string FI_AP_06_S03_01(string code1)
		{
			return new StringBuilder("でんさいEBデータ番号：", 96).Append(code1).Append("　　同一のでんさいEBデータ番号を持つ支払手形が検索条件圏外に存在します。").ToString(); 
		}
		/// <summary>
		/// でんさいEBデータ番号：%s　　同一のでんさいEBデータ番号を持つ支払手形は同時に%sしてください。
		/// </summary>
		/// <param name="code1">でんさいEBデータ番号</param>
		/// <param name="item1">項目名</param>
		/// <returns>でんさいEBデータ番号： <paramref name="code1"/>　　同一のでんさいEBデータ番号を持つ支払手形は同時に<paramref name="item1"/>してください。</returns>
		public static string FI_AP_06_S03_02(string code1, string item1)
		{
			return new StringBuilder("でんさいEBデータ番号：", 96).Append(code1).Append("　　同一のでんさいEBデータ番号を持つ支払手形は同時に").Append(item1).Append("してください。").ToString();
		}
		/// <summary>
		///  %s は ［前回%s］ 以降の日付で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="item1"/> は ［前回<paramref name="item2"/>］ 以降の日付で入力してください。</returns>
		public static string FI_AP_06_S03_03(string item1, string item2)
		{
			return new StringBuilder(item1).Append("は ［前回").Append(item2).Append("］ 以降の日付で入力してください。").ToString(); 
		}

		/// <summary>
		/// [%s]の[%s]が未設定です。
		/// </summary>
		/// <param name="item1">項目名1 </param>
		/// <param name="item2">項目名2 </param>
		public static string FI_AP_06_S07_01(string item1, string item2)
		{
			return new StringBuilder("[", 64).Append(item1).Append("]の[").Append(item2).Append("]が未設定です。").ToString();
		}
		/// <summary>
		/// [%s]が[%s]の3銀行営業日以内、または1年後の日付より後の日付です。
		/// </summary>
		/// <param name="item1">項目名1 </param>
		/// <param name="item2">項目名2 </param>
		public static string FI_AP_06_S07_02(string item1, string item2)
		{
			return new StringBuilder("[", 64).Append(item1).Append("]が[").Append(item2).Append("]の3銀行営業日以内、または1年後の日付より後の日付です。").ToString();
		}

		/// <summary>
		/// 名寄せした[%s]が100億円以上です。
		/// </summary>
		/// <param name="item1">項目名1 </param>
		public static string FI_AP_06_S07_03(string item1)
		{
			return new StringBuilder("名寄せした[", 64).Append(item1).Append("]が100億円以上です。").ToString();
		}

		/// <summary>
		///  [%s]は[%s]から1か月後の日付以内で入力してください。
		/// </summary>
		/// <param name="item1">項目名1 </param>
		/// <param name="item2">項目名2 </param>
		public static string FI_AP_06_S08_01(string item1, string item2)
		{
			return new StringBuilder("［", 64).Append(item1).Append("］は［").Append(item2).Append("］から１か月後以内の日付で入力してください。").ToString();
		}

		/// <summary>
		///  手形整理番号：%s [%s]と支払手形の[%s]が一致しません。
		/// </summary>
		/// <param name="code1">手形整理番号 </param>
		/// <param name="item1">項目名1 </param>
		/// <param name="item2">項目名2 </param>
		public static string FI_AP_06_S08_02(string code1, string item1, string item2)
		{
			return new StringBuilder("手形整理番号：", 64).Append(code1).Append(" [").Append(item1).Append("]と支払手形の[").Append(item2).Append("]が一致しません。").ToString();
		}

		/// <summary>
		/// EBデータ番号：%s　　同一のEBデータ番号を持つ債務期日決済が検索条件圏外に存在します。
		/// </summary>
		/// <param name="code1">EBデータ番号</param>
		/// <returns>EBデータ番号：<paramref name="code1"/> 　　同一のEBデータ番号を持つ債務期日決済が検索条件圏外に存在します。</returns>
		public static string FI_AP_07_S03_01(string code1)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM000440"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM001719")).ToString();
		}
		/// <summary>
		/// EBデータ番号：%s　　同一のEBデータ番号を持つ債務期日決済は同時に決済をしてください。
		/// </summary>
		/// <param name="code1">EBデータ番号</param>
		/// <returns>EBデータ番号： <paramref name="code1"/>　　同一のEBデータ番号を持つ債務期日決済は同時に決済をしてください。</returns>
		public static string FI_AP_07_S03_02(string code1)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM000440"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM001720")).ToString();
		}
		/// <summary>
		/// EBデータ番号：%s　　同一のEBデータ番号を持つ債務期日決済は同時に決済取消をしてください。
		/// </summary>
		/// <param name="code1">EBデータ番号</param>
		/// <returns>EBデータ番号： <paramref name="code1"/>　　同一のEBデータ番号を持つ債務期日決済は同時に決済取消をしてください。</returns>
		public static string FI_AP_07_S03_03(string code1)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM000440"), 96).Append(code1).Append(MultiLanguage.Get("CM_AM001721")).ToString();
		}

		/// <summary>
		/// 検索時に［%s］ は必須です。
		/// </summary>
		public static string FI_AP_08_S04_01(string item)
		{
// 			return new StringBuilder("検索時に ［", 64).Append(item).Append("］ は必須です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000871"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000277")).ToString();
		}
		/// <summary>
		/// 合算時は2件以上選択して下さい。
		/// </summary>

// 		public static readonly string FI_AP_04_S14_01 = "合算時は2件以上選択して下さい。";
		public static string FI_AP_04_S14_01
		{
			get {return MultiLanguage.Get("CM_AM000927");}
		}

		/// <summary>
		/// 都度の支払は合算できません。
		/// </summary>

// 		public static readonly string FI_AP_04_S14_02 = "都度の支払は合算できません。";
		public static string FI_AP_04_S14_02
		{
			get {return MultiLanguage.Get("CM_AM001269");}
		}

		/// <summary>
		/// 合算は支払先、通貨、税率、支払区分が同一の場合のみ有効です。
		/// </summary>

// 		public static readonly string FI_AP_04_S14_03 = "合算は支払先、通貨、税率、支払区分が同一の場合のみ有効です。";
		public static string FI_AP_04_S14_03
		{
			get {return MultiLanguage.Get("CM_AM000926");}
		}

		/// <summary>
		/// 対象の支払に消込が存在するため合算できません。
		/// </summary>

// 		public static readonly string FI_AP_04_S14_04 = "対象の支払に消込が存在するため合算できません。";
		public static string FI_AP_04_S14_04
		{
			get {return MultiLanguage.Get("CM_AM001232");}
		}

		/// <summary>
		/// 予定変更対象の行が選択されていません
		/// </summary>

// 		public static readonly string FI_AP_04_S14_05 = "予定変更対象の行が選択されていません。";
		public static string FI_AP_04_S14_05
		{
			get {return MultiLanguage.Get("CM_AM001418");}
		}

		/// <summary>
		/// 合算は支払先、通貨、支払区分、取引条件区分が同一の場合のみ有効です。
		/// </summary>

		public static string FI_AP_04_S14_06
		{
			get {return MultiLanguage.Get("CM_AM001649");}
		}

		/// <summary>
		/// 支払の合算が発生する場合は支払先、支払区分が同一の場合のみ有効です。
		/// </summary>

		public static string FI_AP_04_S19_01
		{
			get {return MultiLanguage.Get("CM_AM001650");}
		}

		/// <summary>
		/// ［%s］ は、ゼロ以上で［%s］-［%s］以下の金額を入力してください。
		/// </summary>
		public static string FI_AP_04_S16_01(string item,string item2,string item3)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］ はゼロ以上で、［").Append(item2).Append("］-［").Append(item3).Append("］ 以下の金額を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000256")).Append(item2).Append(MultiLanguage.Get("CM_AM000319")).Append(item3).Append(MultiLanguage.Get("CM_AM000300")).ToString();
		}
		/// <summary>
		/// ［%s］ は、［%s］-［%s］以上でゼロ以下の金額を入力してください。
		/// </summary>
		public static string FI_AP_04_S16_02(string item,string item2,string item3)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］ は ［").Append(item2).Append("］-［").Append(item3).Append("］ 以上で、ゼロ以下の金額を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000241")).Append(item2).Append(MultiLanguage.Get("CM_AM000319")).Append(item3).Append(MultiLanguage.Get("CM_AM000308")).ToString();
		}

		/// <summary>
		/// 税率{0}%の合計行：{1}消費税額が{2}となる税額調整はできません。
		/// </summary>
		/// <param name="item">税率</param>
		/// <param name="item2">項目名2</param>
		/// <param name="item3">項目名3</param>
		/// <returns>税率<paramref name="item"/>%の合計行：<paramref name="item2"/>消費税額が<paramref name="item3"/>となる税額調整はできません。</returns>
		public static string FI_AP_04_S16_03(string item, string item2, string item3)
		{
			return string.Format(MultiLanguage.Get("CM_AM001826"),item, item2, item3);
		}

		/// <summary>
		/// 税率{0}%の合計行：税込明細金額を超過する税込消費税額の調整はできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>税率<paramref name="item"/>%の合計行：税込明細金額を超過する税込消費税額の調整はできません。</returns>
		public static string FI_AP_04_S16_04(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001821"), item);
		}

		/// <summary>
		/// 分割時は消費税額の調整内容は反映されません。
		/// </summary>
		/// <returns>分割時は消費税額の調整内容は反映されません。</returns>
		public static string FI_AP_04_S16_05
		{
			get { return MultiLanguage.Get("CM_AM001822"); }
		}

		/// <summary>
		/// 税率{0}%の合計行：{1}調整消費税額は必須です。
		/// </summary>
		/// <param name="item1">項目名</param>
		/// <param name="item2">項目名2</param>
		/// <returns>税率<paramref name="item1"/>%の合計行：<paramref name="item2"/>調整消費税額は必須です。</returns>
		public static string FI_AP_04_S16_06(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001827"), item1, item2);
		}

		/// <summary>
		/// 消費税端数伝票のみを支払とする分割はできません。
		/// </summary>
		/// <returns>消費税端数伝票のみを支払とする分割はできません。</returns>
		public static string FI_AP_04_S16_07
		{
			get { return MultiLanguage.Get("CM_AM001828"); }
		}

		/// <summary>
		/// ［%s］ のため更新・削除できません。
		/// </summary>
		public static string FI_AP_04_S19_02(string item)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］ のため更新・削除できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000220")).ToString();
		}
		/// <summary>
		/// 相殺対象の明細が選択されていません。
		/// </summary>

// 		public static readonly string FI_AP_04_S19_03 = "相殺対象の明細が選択されていません。";
		public static string FI_AP_04_S19_03
		{
			get {return MultiLanguage.Get("CM_AM001222");}
		}

		/// <summary>
		/// ［%s］ は、ゼロ以上で［%s］以下の金額を入力してください。
		/// </summary>
		public static string FI_AP_04_S19_04(string item,string item2)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］ はゼロ以上で、 [").Append(item2).Append("] 以下の金額を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000255")).Append(item2).Append(MultiLanguage.Get("CM_AM000301")).ToString();
		}
		/// <summary>
		/// ［%s］ は、［%s］以上でゼロ以下の金額を入力してください。
		/// </summary>
		public static string FI_AP_04_S19_05(string item,string item2)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］ は [").Append(item2).Append("] 以上で、ゼロ以下の金額を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000242")).Append(item2).Append(MultiLanguage.Get("CM_AM000309")).ToString();
		}
		/// <summary>
		/// 支払番号:［%s］の繰越額に算入されているため、修正・更新できません。
		/// </summary>
		public static string FI_AP_04_S19_06(string item)
		{
// 			return new StringBuilder("支払番号： ", 96).Append(item).Append(" の繰越額に算入されているため、修正・更新できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001045"), 96).Append(item).Append(MultiLanguage.Get("CM_AM000029")).ToString();
		}
		/// <summary>
		/// 承認状態が不正なため、更新・削除できません。
		/// </summary>

// 		public static readonly string FI_AP_04_S19_07 = "承認状態が不正なため、更新・削除できません。";
		public static string FI_AP_04_S19_07
		{
			get {return MultiLanguage.Get("CM_AM001154");}
		}

		/// <summary>
		/// ［%s］ はゼロ以外の値を入力する事ができません。
		/// </summary>
		public static string FI_AP_04_S19_08(string item)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］はゼロ以外の値を入力する事ができません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000383")).ToString();
		}
		/// <summary>
		/// 最新繰越支払書の支払締日以降での支払決済はできません。
		/// </summary>
		/// <param name="date">オペレーション日付</param>
		/// <param name="code">支払先コード</param>
		/// <param name="operation">オペレーション</param>
		/// <returns>入力された<paramref name="date"/>以降に対象支払先 ［<paramref name="code"/>］の繰越型支払書が締められているため、<paramref name="operation"/>できません。</returns>
		public static string FI_AP_S20006(string date, string code, string operation)
		{
// 			return new StringBuilder("入力された", 64).Append(date).Append("以降に対象支払先［").Append(code).Append("］の繰越型支払書が締められているため、").Append(operation).Append("できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001305"), 64).Append(date).Append(MultiLanguage.Get("CM_AM000710")).Append(code).Append(MultiLanguage.Get("CM_AM000366")).Append(operation).Append(MultiLanguage.Get("CM_AM000599")).ToString();
		}
		/// <summary>
		/// 最新繰越請求書の支払締日以降での相殺はできません。
		/// </summary>
		/// <param name="date">オペレーション日付</param>
		/// <param name="code">請求先コード</param>
		/// <param name="operation">オペレーション</param>
		/// <returns>入力された<paramref name="date"/>以降に対象請求先 ［<paramref name="code"/>］の繰越型請求書が締められているため、<paramref name="operation"/>できません。</returns>
		public static string FI_AP_S20007(string date, string code, string operation)
		{
// 			return new StringBuilder("入力された", 64).Append(date).Append("以降に相殺対象［").Append(code).Append("］の繰越型請求書が締められているため、").Append(operation).Append("できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001305"), 64).Append(date).Append(MultiLanguage.Get("CM_AM000709")).Append(code).Append(MultiLanguage.Get("CM_AM000367")).Append(operation).Append(MultiLanguage.Get("CM_AM000599")).ToString();
		}
		/// <summary>
		/// 同一のEBデータ番号を持つ[%s]がすでに決済されています。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>同一のEBデータ番号を持つ[<paramref name="item"/>]がすでに決済されています。</returns>
		public static string FI_AP_S20008(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001730"), item);
		}

		/// <summary>
		/// 支払先[{0}]が既に繰越済みのため、自動前渡金消込は削除できません。
		/// </summary>
		public static string FI_AP_S20009(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001732"), item);
		}

		/// <summary>
		/// 台帳入力が必要な支払方法が複数存在するため%sできません。
		/// </summary>
		/// <param name="operation">オペレーション</param>
		/// <returns>台帳入力が必要な支払方法が複数存在するため<paramref name="operation"/>できません。</returns>
		public static string FI_AP_S20010(string operation)
		{
			return string.Format(MultiLanguage.Get("CM_AM001741"), operation);
		}

		/// <summary>
		/// 支払先が異なる発注番号が指定されています。
		/// </summary>
		public static string FI_AP_S20011
		{
			get {return MultiLanguage.Get("FI_CS003784");}
		}

		/// <summary>
		/// 通貨が異なる発注番号が指定されています。
		/// </summary>
		public static string FI_AP_S20012
		{
			get {return MultiLanguage.Get("FI_CS003786");}
		}

		#endregion
		#region FI_AR
		/// <summary>
		/// 請求締処理が完了しました。
		/// </summary>

// 		public static readonly string FI_AR_S00002 = "請求締処理が完了しました。";
		public static string FI_AR_S00002
		{
			get {return MultiLanguage.Get("CM_AM001189");}
		}

		/// <summary>
		/// 請求予定作成処理が完了しました。
		/// </summary>

// 		public static readonly string FI_AR_S00003 = "請求予定作成処理が完了しました。";
		public static string FI_AR_S00003
		{
			get {return MultiLanguage.Get("CM_AM001191");}
		}

		/// <summary>
		/// ［%s］ が ［%s］ を上回っています。\r\n %s を修正してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="item3">項目名 3</param>
		/// <returns>［<paramref name="item1"/>］ が ［<paramref name="item2"/>］ を上回っています。\r\n <paramref name="item3"/>を修正してください。</returns>
		public static string FI_AR_S10001(string item1, string item2, string item3)
		{
// 			return new StringBuilder("", 64).Append(item1).Append(" が ［").Append(item2).Append("］ を上回っています。\r\n").Append(item3).Append(" を修正してください。").ToString(); 
			return new StringBuilder("", 64).Append(item1).Append(MultiLanguage.Get("CM_AM000012")).Append(item2).Append(MultiLanguage.Get("CM_AM000291")).Append(item3).Append(MultiLanguage.Get("CM_AM000055")).ToString();
		}
		/// <summary>
		/// マイナス金額の請求振替は、プラス金額の請求振替及び入金と同時に入力できません。
		/// </summary>

// 		public static readonly string FI_AR_S10002 = "マイナス金額の請求振替は、プラス金額の請求振替及び入金と同時に入力できません。";
		public static string FI_AR_S10002
		{
			get {return MultiLanguage.Get("CM_AM000665");}
		}

		/// <summary>
		/// 入金または請求振替に存在する為替予約番号と異なる為替予約番号を持つ伝票は消込できません。\r\n消込対象選択を変更してください。
		/// </summary>

// 		public static readonly string FI_AR_S10003 = "入金または請求振替に存在する為替予約番号と異なる為替予約番号を持つ伝票は消込できません。\r\n消込対象選択を変更してください。";
		public static string FI_AR_S10003
		{
			get {return MultiLanguage.Get("CM_AM001304");}
		}

		/// <summary>
		/// 一括請求消込処理で同時登録された入金データは削除されません。\r\n別途、入金データの削除が必要です。
		/// </summary>

// 		public static readonly string FI_AR_S10004 = "一括請求消込処理で同時登録された入金データは削除されません。\r\n別途、入金データの削除が必要です。";
		public static string FI_AR_S10004
		{
			get {return MultiLanguage.Get("CM_AM000729");}
		}

		/// <summary>
		/// 課税しない得意先、または海外得意先の場合、税抜または税込の［明細コード］は指定できません。
		/// </summary>
		public static string FI_AR_S10005
		{
			get { return MultiLanguage.Get("CM_AM001645"); }
		}
		/// <summary>
		///  %s 行目： 課税しない得意先、または海外得意先の場合、税抜または税込の［明細コード］は指定できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns><paramref name="lineNo"/> 行目： 課税しない得意先、または海外得意先の場合、税抜または税込の［明細コード］は指定できません。</returns>
		public static string FI_AR_S10006(string lineNo)
		{
			return string.Format(MultiLanguage.Get("CM_AM001631"), lineNo);
		}

		/// <summary>
		/// 消込対象に選択された %s に他のユーザによって変更、もしくは削除された明細があります。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>消込対象に選択された <paramref name="item"/> に他のユーザによって変更、もしくは削除された明細があります。</returns>
		public static string FI_AR_S20001(string item)
		{
// 			return new StringBuilder("消込対象に選択された ", 64).Append(item).Append(" に他のユーザによって変更、もしくは削除された明細があります。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001158"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000022")).ToString();
		}
		/// <summary>
		/// 前受請求は、同一の請求より作成された前受金と消込できません。
		/// </summary>

// 		public static readonly string FI_AR_S20002 = "前受請求は、同一の請求より作成された前受金と消込できません。";
		public static string FI_AR_S20002
		{
			get {return MultiLanguage.Get("CM_AM001207");}
		}

		/// <summary>
		/// 外貨建て前受金請求は入金、請求振替のレートが相違する場合は消込できません。
		/// </summary>

// 		public static readonly string FI_AR_S20003 = "外貨建て前受金請求は入金、請求振替のレートが相違する場合は消込できません。";
		public static string FI_AR_S20003
		{
			get {return MultiLanguage.Get("CM_AM000761");}
		}

		/// <summary>
		/// 選択した前受請求申請は、決済通貨が変更された実績があるため、追加消込できません。\r\n（強制完了のみ可能です。）
		/// </summary>

// 		public static readonly string FI_AR_S20004 = "選択した前受請求申請は、決済通貨が変更された実績があるため、追加消込できません。\r\n（強制完了のみ可能です。）";
		public static string FI_AR_S20004
		{
			get {return MultiLanguage.Get("CM_AM001201");}
		}

		/// <summary>
		/// 最新繰越請求書の請求締日以前での回収消込はできません。
		/// </summary>
		/// <param name="date">オペレーション日付</param>
		/// <param name="code">請求先コード</param>
		/// <param name="operation">オペレーション</param>
		/// <returns>入力された<paramref name="date"/>以降に対象請求先 ［<paramref name="code"/>］の繰越型請求書が締められているため、<paramref name="operation"/>できません。</returns>
		public static string FI_AR_S20005(string date, string code, string operation)
		{
// 			return new StringBuilder("入力された", 64).Append(date).Append("以降に対象請求先［").Append(code).Append("］の繰越型請求書が締められているため、").Append(operation).Append("できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001305"), 64).Append(date).Append(MultiLanguage.Get("CM_AM000711")).Append(code).Append(MultiLanguage.Get("CM_AM000367")).Append(operation).Append(MultiLanguage.Get("CM_AM000599")).ToString();
		}
		/// <summary>
		/// 選択した回収消込に、支払締された%s伝票が存在するため削除できません。
		/// </summary>
		/// <param name="slip">伝票</param>
		/// <returns>選択した回収消込に、支払締された<paramref name="date"/>伝票が存在するため削除できません。</returns>
		public static string FI_AR_S20006(string slip)
		{
// 			return new StringBuilder("選択した回収消込に、支払締された", 64).Append(slip).Append("伝票が存在するため削除できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001199"), 64).Append(slip).Append(MultiLanguage.Get("CM_AM001263")).ToString();
		}
		/// <summary>
		/// 対象回収消込に、相殺指示された請求書が存在するため削除できません。
		/// </summary>

// 		public static readonly string FI_AR_S20007 = "対象回収消込に、相殺指示された請求書が存在するため削除できません。";
		public static string FI_AR_S20007
		{
			get {return MultiLanguage.Get("CM_AM001234");}
		}

		/// <summary>
		/// 外貨建て預り金は入金、請求振替のレートが相違する場合は消込できません。
		/// </summary>

// 		public static readonly string FI_AR_S20008 = "外貨建て預り金は入金、請求振替のレートが相違する場合は消込できません。";
		public static string FI_AR_S20008
		{
			get {return MultiLanguage.Get("CM_AM000760");}
		}

		/// <summary>
		/// 請求先[{0}]が既に繰越済みのため、自動前受金消込は削除できません。
		/// </summary>
		public static string FI_AR_S20009(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001731"), item);
		}

		/// <summary>
		/// 外貨建て回収計上請求は複数レートの債権計上との相殺はできません。
		/// </summary>
		public static string FI_AR_S20010
		{
			get {return MultiLanguage.Get("CM_AM001762");}
		}

		/// <summary>
		/// 消込対象に選択された %s に、他のユーザによって変更、削除された明細 または、伝票内にマイナス明細が存在し伝票の消込残高がマイナスになる明細があります。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>消込対象に選択された <paramref name="item"/> に他のユーザによって変更、削除された明細 または、伝票内にマイナス明細が存在し伝票の消込残高がマイナスになる明細があります。</returns>
		public static string FI_AR_S20011(string item)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM001158"), 64).Append(item).Append(MultiLanguage.Get("CM_AM001763")).ToString();
		}

		/// <summary>
		/// 選択した回収消込に、支払締された%s伝票が存在するため消込できません。
		/// </summary>
		/// <param name="slip">伝票</param>
		/// <returns>選択した回収消込に、支払締された<paramref name="date"/>伝票が存在するため消込できません。</returns>
		public static string FI_AR_S20012(string slip)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM001199"), 64).Append(slip).Append(MultiLanguage.Get("CM_AM001767")).ToString();
		}

		/// <summary>
		/// 正常に帳票要求を完了しました。（出力指示{0}件、ecoDeliver配信指示{1}件）
		/// </summary>
		/// <param name="outputCnt">出力指示件数</param>
		/// <param name="edeCnt">ecoDeliver配信指示件数</param>
		/// <returns>正常に帳票要求を完了しました。（出力指示<paramref name="outputCnt"/>件、ecoDeliver配信指示<paramref name="edeCnt"/>件）</returns>
		public static string FI_AR_S20013(int outputCnt, int edeCnt)
		{
			// 正常に帳票要求を完了しました。（出力指示{0}件、ecoDeliver配信指示{1}件）
			return new StringBuilder(MultiLanguage.Get("CM_AM001177"), 96).Append(string.Format(MultiLanguage.Get("CM_AM001788"), outputCnt, edeCnt)).ToString();
		}

		/// <summary>
		/// 検索結果に他の人が発行中の請求書があります。時間を置いて再実行してください。
		/// </summary>
		public static string FI_AR_S20014
		{
			// 検索結果に他の人が発行中の請求書があります。時間を置いて再実行してください。
			get { return MultiLanguage.Get("CM_AM001789"); }
		}

		/// <summary>
		/// 請求先が異なる受注番号が指定されています。
		/// </summary>
		public static string FI_AR_S20015
		{
			get {return MultiLanguage.Get("FI_CS003785");}
		}

		/// <summary>
		/// 通貨が異なる受注番号が指定されています。
		/// </summary>
		public static string FI_AR_S20016
		{
			get {return MultiLanguage.Get("FI_CS003787");}
		}

		/// <summary>
		/// ［%s］が海外の場合、［%s］に電子債権（営業）、電子債権（営業外）、でんさい（営業）、でんさい（営業外）は選択できません。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns> ［<paramref name="item1"/>］ が海外の場合、［ <paramref name="item2"/> ］に電子債権（営業）、電子債権（営業外）、でんさい（営業）、でんさい（営業外）は選択できません。</returns>
		public static string FI_AR_07_S10001(string item1, string item2)
		{
			return new StringBuilder("［", 64).Append(item1).Append("］ が海外の場合、 ［").Append(item2).Append("］ に電子債権（営業）、電子債権（営業外）、でんさい（営業）、でんさい（営業外）は選択できません。").ToString();
		}

		/// <summary>
		/// [回収先]が海外の場合、[区分]に電子債権（営業）、電子債権（営業外）、でんさい（営業）、でんさい（営業外）は選択できません。
		/// </summary>
		public static string FI_AR_07_S10002
		{
			get { return MultiLanguage.Get("CM_AM001686"); }
		}

		/// <summary>
		/// 取得済み明細データが失われました。再度、明細データを取得してください。
		/// </summary>

// 		public static readonly string FI_AR_01_S04_01 = "取得済み明細データが失われました。再度、明細データを取得してください。";
		public static string FI_AR_01_S04_01
		{
			get {return MultiLanguage.Get("CM_AM001100");}
		}

		/// <summary>
		/// ［入金通貨］ が日本円以外のとき、［入金通貨］ に %s は入力できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［入金通貨］ が日本円以外のとき、［回収方法］ に <paramref name="item"/> は入力できません。</returns>
		public static string FI_AR_05_S01_01(string item)
		{
// 			return new StringBuilder("［入金通貨］ が日本円以外のとき、［回収方法］ に ", 64).Append(item).Append(" は入力できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000164"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000044")).ToString();
		}
		/// <summary>
		/// 締条件が都度請求の請求先は登録できません。
		/// </summary>

// 		public static readonly string FI_AR_01_S05_01 = "締条件が都度請求の請求先は登録できません。";
		public static string FI_AR_01_S05_01
		{
			get {return MultiLanguage.Get("CM_AM001262");}
		}

		/// <summary>
		/// 雑請求先は登録できません。
		/// </summary>

// 		public static readonly string FI_AR_01_S05_02 = "雑請求先は登録できません。";
		public static string FI_AR_01_S05_02
		{
			get {return MultiLanguage.Get("CM_AM000958");}
		}

		/// <summary>
		/// %s の入力はできません。
		/// </summary>
		/// <param name="name"></param>
		/// <returns><paramref name="name"/> の入力はできません。</returns>
		public static string FI_AR_01_S10_01(string name)
		{
// 			return new StringBuilder("［").Append(name).Append("］の入力はできません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131")).Append(name).Append(MultiLanguage.Get("CM_AM000377")).ToString();
		}
		/// <summary>
		/// %s 明細 %s 入力可能です。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns> <paramref name="item1"/> 明細 <paramref name="item2"/> 入力可能です。</returns>
		public static string FI_AR_01_S10_02(string item1, string item2)
		{
// 			return new StringBuilder(item1).Append(" 明細 ").Append(item2).Append(" 入力可能です。").ToString(); 
			return new StringBuilder(item1).Append(MultiLanguage.Get("CM_AM000111")).Append(item2).Append(MultiLanguage.Get("CM_AM000105")).ToString();
		}
		/// <summary>
		/// 請求集計部門階層が自部門階層より上位のため指示できません。
		/// </summary>

// 		public static readonly string FI_AR_04_S01_01 = "請求集計部門階層が自部門階層より上位のため指示できません。";
		public static string FI_AR_04_S01_01
		{
			get {return MultiLanguage.Get("CM_AM001186");}
		}

		/// <summary>
		/// 請求番号:［%s］の繰越額に算入されているため、修正・更新できません。
		/// </summary>
		public static string FI_AR_04_S05_01(string item)
		{
// 			return new StringBuilder("請求番号： ", 96).Append(item).Append(" の繰越額に算入されているため、修正・更新できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001190"), 96).Append(item).Append(MultiLanguage.Get("CM_AM000029")).ToString();
		}
		/// <summary>
		/// プラスとマイナスの回収予定金額が存在するため更新できません。 
		/// </summary>

// 		public static readonly string FI_AR_04_S05_02 = "プラスとマイナスの回収予定金額が存在するため更新できません。";
		public static string FI_AR_04_S05_02
		{
			get {return MultiLanguage.Get("CM_AM000651");}
		}

		/// <summary>
		/// 税率{0}%の合計行：{1}消費税額が{2}となる税額調整はできません。
		/// </summary>
		/// <param name="item">税率</param>
		/// <param name="item2">項目名2</param>
		/// <param name="item3">項目名3</param>
		/// <returns>税率<paramref name="item"/>%の合計行：<paramref name="item2"/>消費税額が<paramref name="item3"/>となる税額調整はできません。</returns>
		public static string FI_AR_04_S05_03(string item, string item2, string item3)
		{
			return string.Format(MultiLanguage.Get("CM_AM001826"),item, item2, item3);
		}

		/// <summary>
		/// 税率{0}%の合計行：税込明細金額を超過する税込消費税額の調整はできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>税率<paramref name="item"/>%の合計行：税込明細金額を超過する税込消費税額の調整はできません。</returns>
		public static string FI_AR_04_S05_04(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001821"), item);
		}

		/// <summary>
		/// 税率{0}%の合計行：{1}調整消費税額は必須です。
		/// </summary>
		/// <param name="item1">項目名</param>
		/// <param name="item2">項目名2</param>
		/// <returns>税率<paramref name="item1"/>%の合計行：<paramref name="item2"/>調整消費税額は必須です。</returns>
		public static string FI_AR_04_S05_05(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001827"), item1, item2);
		}

		/// <summary>
		/// ［回収予定金額合計］と［請求合計金額］が異なります。
		/// </summary>
		/// <returns>［回収予定金額合計］と［請求合計金額］が異なります。</returns>
		public static string FI_AR_04_S05_06
		{
			get {return MultiLanguage.Get("CM_AM001825");}
		}

		/// <summary>
		/// ・［%s］ （繰越元の請求予定が承認されていないため、データの更新ができません。）
		/// </summary>
		/// <param name="code">請求予定番号</param>
		/// <returns>・<paramref name="code"/> （繰越元の請求予定が承認されていないため、データの更新ができません。）</returns>
		public static string FI_AR_04_S12_01(string code)
		{
// 			return new StringBuilder("・", 96).Append(code).Append(" （繰越元の請求予定が承認されていないため、データの更新ができません。）").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000428"), 96).Append(code).Append(MultiLanguage.Get("CM_AM000006")).ToString();
		}
		/// <summary>
		/// ・［%s］ （繰越先の請求予定が承認済のため、データの更新ができません。）
		/// </summary>
		/// <param name="code">請求予定番号</param>
		/// <returns>・<paramref name="code"/> （繰越先の請求予定が承認済のため、データの更新ができません。）</returns>
		public static string FI_AR_04_S12_02(string code)
		{
// 			return new StringBuilder("・", 96).Append(code).Append(" （繰越先の請求予定が承認済のため、データの更新ができません。）").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000428"), 96).Append(code).Append(MultiLanguage.Get("CM_AM000008")).ToString();
		}
		/// <summary>
		/// 消込対象の明細が選択されていません。
		/// </summary>

// 		public static readonly string FI_AR_06_S02_01 = "消込対象の明細が選択されていません。";
		public static string FI_AR_06_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001161");}
		}

		/// <summary>
		/// ［%s］ が ［%s］ を上回っています。\r\n差額を振替えるか金額を修正してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ が ［<paramref name="item2"/>］ を上回っています。\r\n差額を振替えるか金額を修正してください。</returns>
		public static string FI_AR_06_S02_02(string item1, string item2)
		{
// 			return new StringBuilder("［", 64).Append(item1).Append("］ が ［").Append(item2).Append("］ を上回っています。\r\n差額を振替えるか金額を修正してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000184")).Append(item2).Append(MultiLanguage.Get("CM_AM000292")).ToString();
		}
		/// <summary>
		/// 請求締時に作成された消込伝票は削除のみ可能です。
		/// </summary>

// 		public static readonly string FI_AR_06_S02_03 = "請求締時に作成された消込伝票は削除のみ可能です。";
		public static string FI_AR_06_S02_03
		{
			get {return MultiLanguage.Get("CM_AM001188");}
		}

		/// <summary>
		/// 消込対象に選択した請求は、強制完了の場合を除き消込金額にゼロを指定できません。
		/// </summary>

// 		public static readonly string FI_AR_06_S02_04 = "消込対象に選択した請求は、強制完了の場合を除き消込金額にゼロを指定できません。";
		public static string FI_AR_06_S02_04
		{
			get {return MultiLanguage.Get("CM_AM001160");}
		}

		/// <summary>
		/// ［%s］ は日本円以外の通貨での同時消込はできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］ は日本円以外の通貨での同時消込はできません。</returns>
		public static string FI_AR_06_S02_05(string item)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］ は日本円以外の通貨での同時消込はできません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000271")).ToString();
		}
		/// <summary>
		/// 自社マスタ（債権）：［入金入力承認］が「未承認」の時、入金同時消込は行えません。
		/// </summary>

// 		public static readonly string FI_AR_06_S02_06 = "自社マスタ（債権）：［入金入力承認］が「未承認」の時、入金同時消込は行えません。";
		public static string FI_AR_06_S02_06
		{
			get {return MultiLanguage.Get("CM_AM001067");}
		}

		/// <summary>
		/// ［%s］ が変更されているため、更新できません。
		/// </summary>
		/// <param name="item"></param>
		/// <returns>［<paramref name="item"/>］ が変更されているため、更新できません。</returns>
		public static string FI_AR_06_S02_07(string item)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］ が変更されているため、更新できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000198")).ToString();
		}
		/// <summary>
		/// 履歴伝票は一部消込できません。
		/// </summary>

// 		public static readonly string FI_AR_06_S02_08 = "履歴伝票は一部消込できません。";
		public static string FI_AR_06_S02_08
		{
			get {return MultiLanguage.Get("CM_AM001427");}
		}

		/// <summary>
		/// 自動前受金消込分の削除は請求承認取消後行ってください。
		/// </summary>

// 		public static readonly string FI_AR_06_S02_09 = "自動前受金消込分の削除は請求承認取消後行ってください。";
		public static string FI_AR_06_S02_09
		{
			get {return MultiLanguage.Get("CM_AM001074");}
		}

		/// <summary>
		/// 支払申請伝票にて指定済（債務計上種別＝預り金返却）の請求申請伝票を含むため更新・削除できません。
		/// </summary>

// 		public static readonly string FI_AR_06_S02_10 = "支払申請伝票にて指定済（債務計上種別＝預り金返却）の請求申請伝票を含むため更新・削除できません。";
		public static string FI_AR_06_S02_10
		{
			get {return MultiLanguage.Get("CM_AM001042");}
		}

		/// <summary>
		/// ［%s］ が変更されているため、消込できません。
		/// </summary>
		/// <param name="item"></param>
		/// <returns>［<paramref name="item"/>］ が変更されているため、消込できません。</returns>
		public static string FI_AR_06_S02_11(string item)
		{
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM001766")).ToString();
		}

		/// <summary>
		/// 選択した前受請求申請は、決済通貨が変更された実績があるため、追加消込できません。\r\n（強制完了のみ可能です。）
		/// </summary>

// 		public static readonly string FI_AR_06_S04_01 = "選択した前受金は、決済通貨を変更して消しこんだ実績があるため、再度決済通貨を変更できません。";
		public static string FI_AR_06_S04_01
		{
			get {return MultiLanguage.Get("CM_AM001200");}
		}

		/// <summary>
		/// 伝票番号： %s の選択が不正です。
		/// </summary>
		/// <param name="code">伝票番号</param>
		/// <returns>伝票番号：［<paramref name="code"/>］の選択が不正です。</returns>
		public static string FI_AR_06_S06_01(string code)
		{
// 			return new StringBuilder("伝票番号： ", 64).Append(code).Append(" の選択が不正です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001267"), 64).Append(code).Append(MultiLanguage.Get("CM_AM000031")).ToString();
		}
       /// <summary>
        /// ［%s］ が %s ～ %s となるよう選択してください。
        /// </summary>
        /// <param name="item">項目名</param>
        /// <param name="minValue">最小値</param>
        /// <param name="maxValue">最大値</param>
        /// <returns>［<paramref name="item"/>］ が <paramref name="minValue"/> ～ <paramref name="maxValue"/> となるよう選択してください。</returns>
        public static string FI_AR_06_S06_02(string item, string minValue, string maxValue)
        {
//             return new StringBuilder("［", 64).Append(item).Append("］ が ").Append(minValue).Append(" ～ ").Append(maxValue).Append(" となるよう選択してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000183")).Append(minValue).Append(MultiLanguage.Get("CM_AM000011")).Append(maxValue).Append(MultiLanguage.Get("CM_AM000019")).ToString();
        }
        /// <summary>
		/// 更新対象の請求データがありません。
		/// </summary>

// 		public static readonly string FI_AR_06_S07_01 = "更新対象の請求データがありません。";
		public static string FI_AR_06_S07_01
		{
			get {return MultiLanguage.Get("CM_AM000914");}
		}

		/// <summary>
		/// ［顛末先］と［顛末先銀行］の両方を同時に指定することはできません。
		/// </summary>

// 		public static readonly string FI_AR_07_S08_01 = "［顛末先］と［顛末先銀行］の両方を同時に指定することはできません。";
		public static string FI_AR_07_S08_01
		{
			get {return MultiLanguage.Get("CM_AM000163");}
		}

		/// <summary>
		/// 自社マスタ（債権）：自社マスタ（債権）：［入金入力承認］が「未承認」の時、当該機能は利用できません。
		/// </summary>

// 		public static readonly string FI_AR_06_S08_01 = "自社マスタ（債権）：［入金入力承認］が「未承認」の時、当該機能は利用できません。";
		public static string FI_AR_06_S08_01
		{
			get {return MultiLanguage.Get("CM_AM001066");}
		}

		/// <summary>
		/// 選択された請求の回収予定に回収消込で使用しない決済方法が含まれる場合、一括請求消込は実行できません。
		/// </summary>

// 		public static readonly string FI_AR_06_S08_02 = "選択された請求の回収予定に回収消込で使用しない決済方法が含まれる場合、一括請求消込は実行できません。";
		public static string FI_AR_06_S08_02
		{
			get {return MultiLanguage.Get("CM_AM001198");}
		}

		/// <summary>
		/// 分割先の[%s]が0のため登録できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>分割先の［ <paramref name="item"/> ］が0のため登録できません。</returns>
		public static string FI_AR_07_S04_01(string item)
		{
			return new StringBuilder("分割先の ［", 64).Append(item).Append("］ が0のため登録できません。").ToString();
		}

		/// <summary>
		/// 分割先手形金額は分割前手形金額より少ない金額で入力して下さい。
		/// </summary>
		public static string FI_AR_07_S04_02
		{
			get { return "分割先手形金額は分割前手形金額より少ない金額で入力して下さい。"; }
		}

		/// <summary>
		/// 受取手形整理番号： %s は存在しないか、有効な未決済裏書手形ではありません。
		/// </summary>
		/// <param name="code"></param>
		/// <returns>受取手形整理番号： <paramref name="code"/> は存在しないか、有効な未決済裏書手形ではありません。</returns>
		public static string FI_AR_07_S55_01(string code)
		{
// 			return new StringBuilder("受取手形整理番号： ", 64).Append(code).Append(" は存在しないか、有効な未決済裏書手形ではありません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001101"), 64).Append(code).Append(MultiLanguage.Get("CM_AM000043")).ToString();
		}
		/// <summary>
		/// 検索時に［%s］ は必須です。
		/// </summary>
		public static string FI_AR_09_S05_01(string item)
		{
// 			return new StringBuilder("検索時に ［", 64).Append(item).Append("］ は必須です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000871"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000277")).ToString();
		}

		#endregion
		#region FI_EX
		#region S10000
		/// <summary>
		/// 明細を 1 行以上入力してください。
		/// </summary>

// 		public static readonly string FI_EX_S10001 = "明細を 1 行以上入力してください。";
		public static string FI_EX_S10001
		{
			get {return MultiLanguage.Get("CM_AM001402");}
		}

		/// <summary>
		/// ［%s］ と ［%s］ のどちらかは%s選択してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="value">内容</param>
		/// <returns>［<paramref name="item1"/>］ と ［<paramref name="item2"/>］ のどちらかは<paramref name="value"/>選択してください。</returns>
		public static string FI_EX_S10002(string item1, string item2, string value)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］ と ［").Append(item2).Append("］ のどちらかは").Append(value).Append("選択してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000205")).Append(item2).Append(MultiLanguage.Get("CM_AM000221")).Append(value).Append(MultiLanguage.Get("CM_AM001202")).ToString();
		}
		/// <summary>
		/// ［%s］ は ［%s］ より後の日付で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ は ［<paramref name="item2"/>］ より後の日付で入力してください。</returns>
		public static string FI_EX_S10003(string item1, string item2)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］ は ［").Append(item2).Append("］ より後の日付で入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000241")).Append(item2).Append(MultiLanguage.Get("CM_AM000287")).ToString();
		}
		/// <summary>
		/// 日当日数は出張期間日数以内の日数を入力してください。
		/// </summary>

// 		public static readonly string FI_EX_S10004 = "日当日数は出張期間日数以内の日数を入力してください。";
		public static string FI_EX_S10004
		{
			get {return MultiLanguage.Get("CM_AM001291");}
		}

		/// <summary>
		/// 入力された ［%s］ は、経費伝票入力が禁止されています。
		/// </summary>
		/// <param name="dateName">日付名</param>
		/// <returns>入力された［<paramref name="dateItem"/>］ は、経費伝票入力が禁止されています。</returns>
		public static string FI_EX_S10005(string dateName)
		{
// 			return new StringBuilder("入力された ［", 64).Append(dateName).Append("］ は、 経費伝票入力が禁止されています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001306"), 64).Append(dateName).Append(MultiLanguage.Get("CM_AM000250")).ToString();
		}
		/// <summary>
		/// ［消費税金額］は［金額］より小さい値で入力してください。
		/// </summary>

// 		public static readonly string FI_EX_S10006 = "［消費税金額］は［金額］より小さい値で入力してください。";
		public static string FI_EX_S10006
		{
			get {return MultiLanguage.Get("CM_AM000155");}
		}

		/// <summary>
		/// ［%s］に入場券等または自動サービス機を選択時に、［%s］は必須です。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		public static string FI_EX_S10007(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001810"), item1, item2);
		}

		/// <summary>
		/// %s 行目：［%s］に入場券等または自動サービス機を選択時に、［%s］は必須です。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/>行目：［<paramref name="item1"/>］に入場券等または自動サービス機を選択時に、［<paramref name="item2"/>］は必須です。</returns>
		public static string FI_EX_S10008(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001814"), lineNo, item1, item2);
		}

		/// <summary>
		/// 雑支払先は登録できません。
		/// </summary>
		public static string FI_EX_S10009
		{
			get { return MultiLanguage.Get("CM_AM000957"); }
		}

		/// <summary>
		/// ［{0}］が控除外課税仕入の場合、［{1}］は選択できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］が控除外課税仕入の場合、［<paramref name="item2"/>］は選択できません。</returns>
		public static string FI_EX_S10010(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001832"), item1, item2);
		}

		#endregion
		#region S20000
		/// <summary>
		/// 空きコードが取得できません。
		/// </summary>

// 		public static readonly string FI_EX_S20001 = "空きコードが取得できません。";
		public static string FI_EX_S20001
		{
			get {return MultiLanguage.Get("CM_AM000847");}
		}

		/// <summary>
		/// 100 日以上の出張期間は登録できません。
		/// </summary>

// 		public static readonly string FI_EX_S20005 = "100 日以上の出張期間は登録できません。";
		public static string FI_EX_S20005
		{
			get {return MultiLanguage.Get("CM_AM000429");}
		}

		/// <summary>
		/// 未承認伝票があります。
		/// </summary>

// 		public static readonly string FI_EX_S20007 = "未承認伝票があります。";
		public static string FI_EX_S20007
		{
			get {return MultiLanguage.Get("CM_AM001395");}
		}

		/// <summary>
		/// 未取込の自動仕訳伝票があります。自動仕訳実行処理を行ってください。
		/// </summary>

// 		public static readonly string FI_EX_S20008 = "未取込の自動仕訳伝票があります。自動仕訳実行処理を行ってください。";
		public static string FI_EX_S20008
		{
			get {return MultiLanguage.Get("CM_AM001388");}
		}

		/// <summary>
		/// 宿泊費が上限を超えています。
		/// </summary>

// 		public static readonly string FI_EX_S20010 = "宿泊費が上限を超えています。";
		public static string FI_EX_S20010
		{
			get {return MultiLanguage.Get("CM_AM001108");}
		}

		/// <summary>
		/// 入力された分類の組み合わせは既に登録されています。
		/// </summary>

// 		public static readonly string FI_EX_S20011 = "入力された分類の組み合わせは既に登録されています。";
		public static string FI_EX_S20011
		{
			get {return MultiLanguage.Get("CM_AM001317");}
		}

		/// <summary>
		/// 入力された勘定科目は指定できません。(補助指定の場合を除く)
		/// </summary>

// 		public static readonly string FI_EX_S20012 = "入力された勘定科目は指定できません。(補助指定の場合を除く)";
		public static string FI_EX_S20012
		{
			get {return MultiLanguage.Get("CM_AM001311");}
		}

		/// <summary>
		/// 精算金額0円の場合には調整金額の入力はできません。
		/// </summary>

// 		public static readonly string FI_EX_S20013 = "発生金額が0円の場合は調整金額の入力はできません。";
		public static string FI_EX_S20013
		{
			get {return MultiLanguage.Get("CM_AM001345");}
		}

		/// <summary>
		/// 基軸調整金額の値が不正です。
		/// </summary>

// 		public static readonly string FI_EX_S20014 = "基軸調整金額の値が不正です。";
		public static string FI_EX_S20014
		{
			get {return MultiLanguage.Get("CM_AM000781");}
		}

		/// <summary>
		/// 外貨調整金額の値が不正です。
		/// </summary>

// 		public static readonly string FI_EX_S20015 = "外貨調整金額の値が不正です。";
		public static string FI_EX_S20015
		{
			get {return MultiLanguage.Get("CM_AM000763");}
		}

		/// <summary>
		/// 経費計上確認が行われていない伝票があります。
		/// </summary>

// 		public static readonly string FI_EX_S20016 = "経費計上確認が行われていない伝票があります。";
		public static string FI_EX_S20016
		{
			get {return MultiLanguage.Get("CM_AM000850");}
		}


		#endregion
		#region FI_EX_03
		/// <summary>
		/// ［交通手段支給］が対象外の時は、［支払方法］にカードは使用できません。
		/// </summary>

// 		public static readonly string FI_EX_03_S05_01 = "［交通手段支給］が対象外の時は、［支払方法］にカードは使用できません。";
		public static string FI_EX_03_S05_01
		{
			get {return MultiLanguage.Get("CM_AM000140");}
		}

		#endregion
		#region FI_EX_04
		/// <summary>
		/// 不正な振込先銀行もしくは支店コードが含まれています。
		/// </summary>

// 		public static readonly string FI_EX_04_S02_01 = "不正な振込先銀行もしくは支店コードが含まれています。";
		public static string FI_EX_04_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001362");}
		}

		#endregion
		#endregion
		#region FI_FA
		/// <summary>
		/// 作成しました。
		/// </summary>

// 		public static readonly string FI_FA_S00001 = "作成しました。";
		public static string FI_FA_S00001
		{
			get {return MultiLanguage.Get("CM_AM000949");}
		}

		/// <summary>
		/// %d件の %s を取り込みました。
		/// </summary>
		/// <param name="count">取込件数</param>
		/// <param name="dataName">取込データ名</param>
		/// <returns><paramref name="count"/>件の <paramref name="dataName"/> を取り込みました。</returns>
		public static string FI_FA_S00002(int count, string dataName)
		{
// 			return new StringBuilder(count.ToString("#,##0"), 32).Append("件の ").Append(dataName).Append(" を取り込みました。").ToString(); 
			return new StringBuilder(count.ToString("#,##0"), 32).Append(MultiLanguage.Get("CM_AM000868")).Append(dataName).Append(MultiLanguage.Get("CM_AM000053")).ToString();
		}
		/// <summary>
		/// 移動による受入で登録されました。資産明細にも必ず一行以上、移動元申告自治体を登録して下さい
		/// </summary>

// 		public static readonly string FI_FA_S00003 = "移動による受入で登録されました。資産明細にも必ず一行以上、移動元申告自治体を登録して下さい";
		public static string FI_FA_S00003
		{
			get {return MultiLanguage.Get("CM_AM000722");}
		}

		/// <summary>
		/// 申告自治体一部移動先資産を削除しました。移動元の台帳にデータを戻す場合は、該当の「申告自治体一部移動」履歴を手動で取り消して下さい。
		/// </summary>

// 		public static readonly string FI_FA_S00004 = "申告自治体一部移動先資産を削除しました。移動元の台帳にデータを戻す場合は、該当の「申告自治体一部移動」履歴を手動で取り消して下さい。";
		public static string FI_FA_S00004
		{
			get {return MultiLanguage.Get("CM_AM001172");}
		}

		/// <summary>
		/// 更新しました。「別申告自治体に明細移動」対象の明細データは、この台帳から削除されました。対象明細データを、申告自治体移動先新規資産台帳に登録して下さい。
		/// </summary>

// 		public static readonly string FI_FA_S00005 = "更新しました。「別申告自治体に明細移動」対象の明細データは、この台帳から削除されました。対象明細データを、申告自治体移動先新規資産台帳に登録して下さい。";
		public static string FI_FA_S00005
		{
			get {return MultiLanguage.Get("CM_AM000908");}
		}

		/// <summary>
		/// 申告自治体一部移動元資産の履歴を取り消しました。該当履歴に紐づく、移動先の台帳明細データを作成している場合には、該当の「申告自治体一部移動先」資産台帳を手動で削除してください。
		/// </summary>

// 		public static readonly string FI_FA_S00006 = "申告自治体一部移動元資産の履歴を取り消しました。該当履歴に紐づく、移動先の台帳明細データを作成している場合には、該当の「申告自治体一部移動先」資産台帳を手動で削除してください。";
		public static string FI_FA_S00006
		{
			get {return MultiLanguage.Get("CM_AM001169");}
		}

		/// <summary>
		/// 申告自治体一部移動先資産の履歴を取り消しました。移動元の台帳にデータを戻す場合は、移動元台帳から、該当の「申告自治体一部移動」履歴を手動で取消してください。
		/// </summary>

// 		public static readonly string FI_FA_S00007 = "申告自治体一部移動先資産の履歴を取り消しました。移動元の台帳にデータを戻す場合は、移動元台帳から、該当の「申告自治体一部移動」履歴を手動で取消してください。";
		public static string FI_FA_S00007
		{
			get {return MultiLanguage.Get("CM_AM001171");}
		}

		/// <summary>
		/// 申告自治体一部移動元資産を削除しました。移動先の台帳明細データを作成している場合には、該当の「申告自治体一部移動先」資産台帳を手動で削除してください。
		/// </summary>

// 		public static readonly string FI_FA_S00008 = "申告自治体一部移動元資産を削除しました。移動先の台帳明細データを作成している場合には、該当の「申告自治体一部移動先」資産台帳を手動で削除してください。";
		public static string FI_FA_S00008
		{
			get {return MultiLanguage.Get("CM_AM001170");}
		}

		/// <summary>
		/// 作成対象の資産グループが選択されていません。
		/// </summary>

// 		public static readonly string FI_FA_S10001 = "作成対象の資産グループが選択されていません。";
		public static string FI_FA_S10001
		{
			get {return MultiLanguage.Get("CM_AM000950");}
		}

		/// <summary>
		/// 資産管理ラベル出力項目が入力されていません。
		/// </summary>

// 		public static readonly string FI_FA_S10002 = "資産管理ラベル出力項目が入力されていません。";
		public static string FI_FA_S10002
		{
			get {return MultiLanguage.Get("CM_AM001051");}
		}

		/// <summary>
		/// 指定されていない資産種別の分類種類が出力項目となっています。
		/// </summary>

// 		public static readonly string FI_FA_S10003 = "指定されていない資産種別の分類種類が出力項目となっています。";
		public static string FI_FA_S10003
		{
			get {return MultiLanguage.Get("CM_AM001029");}
		}

		/// <summary>
		/// 所属資産種類(大分類)を先に入力してください。
		/// </summary>

// 		public static readonly string FI_FA_S10004 = "所属資産種類(大分類)を先に入力してください。";
		public static string FI_FA_S10004
		{
			get {return MultiLanguage.Get("CM_AM001138");}
		}

		/// <summary>
		/// 指定された資産グループに資産台帳が登録されていません。
		/// </summary>

// 		public static readonly string FI_FA_S10005 = "指定された資産グループに資産台帳が登録されていません。";
		public static string FI_FA_S10005
		{
			get {return MultiLanguage.Get("CM_AM001009");}
		}

		/// <summary>
		/// 当決算期の日付を入力してください。
		/// </summary>

// 		public static readonly string FI_FA_S10006 = "当決算期の日付を入力してください。";
		public static string FI_FA_S10006
		{
			get {return MultiLanguage.Get("CM_AM001272");}
		}

		/// <summary>
		/// 地方税申告済の日付は指定できません。
		/// </summary>

// 		public static readonly string FI_FA_S10007 = "地方税申告済の日付は指定できません。";
		public static string FI_FA_S10007
		{
			get {return MultiLanguage.Get("CM_AM001246");}
		}

		/// <summary>
		/// 配分入力された減損損失額が資産グループ減損損失額と一致しません。
		/// </summary>

// 		public static readonly string FI_FA_S10008 = "配分入力された減損損失額が資産グループ減損損失額と一致しません。";
		public static string FI_FA_S10008
		{
			get {return MultiLanguage.Get("CM_AM001336");}
		}

		/// <summary>
		/// 配分済の減損損失額より大きい金額を入力してください。
		/// </summary>

// 		public static readonly string FI_FA_S10009 = "配分済の減損損失額より大きい金額を入力してください。";
		public static string FI_FA_S10009
		{
			get {return MultiLanguage.Get("CM_AM001335");}
		}

		/// <summary>
		/// 資産台帳(%s)の見積耐用年数は未償却年数以下の年数を入力してください。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <returns>資産台帳(<paramref name="assetListNo"/>) の見積耐用年数は未償却年数以下の年数を入力してください。</returns>
		public static string FI_FA_S10010(string assetListNo)
		{
// 			return new StringBuilder("資産台帳(", 64).Append(assetListNo).Append(")の見積耐用年数は未償却年数以下の年数を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001054"), 64).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000126")).ToString();
		}
		/// <summary>
		/// 資産台帳(%s)の減損後簿価は残存額以上になるよう減損損失額を入力してください。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <returns>資産台帳(<paramref name="assetListNo"/>)の減損後簿価は残存額以上になるよう減損損失額を入力してください。</returns>
		public static string FI_FA_S10011(string assetListNo)
		{
// 			return new StringBuilder("資産台帳(", 64).Append(assetListNo).Append(")の減損後簿価は残存額以上になるよう減損損失額を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001054"), 64).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000127")).ToString();
		}
		/// <summary>
		/// 指定された資産台帳は既に削除されています。
		/// </summary>

// 		public static readonly string FI_FA_S10012 = "指定された資産台帳は既に削除されています。";
		public static string FI_FA_S10012
		{
			get {return MultiLanguage.Get("CM_AM001016");}
		}

		/// <summary>
		/// 指定された資産台帳は有形固定資産ではありません。
		/// </summary>

// 		public static readonly string FI_FA_S10013 = "指定された資産台帳は有形固定資産ではありません。";
		public static string FI_FA_S10013
		{
			get {return MultiLanguage.Get("CM_AM001020");}
		}

		/// <summary>
		/// 指定された資産台帳は無形固定資産ではありません。
		/// </summary>

// 		public static readonly string FI_FA_S10014 = "指定された資産台帳は無形固定資産ではありません。";
		public static string FI_FA_S10014
		{
			get {return MultiLanguage.Get("CM_AM001019");}
		}

		/// <summary>
		/// 指定された資産台帳は繰延資産ではありません。
		/// </summary>

// 		public static readonly string FI_FA_S10015 = "指定された資産台帳は繰延資産ではありません。";
		public static string FI_FA_S10015
		{
			get {return MultiLanguage.Get("CM_AM001017");}
		}

		/// <summary>
		/// 指定された資産台帳はその他資産ではありません。
		/// </summary>

// 		public static readonly string FI_FA_S10016 = "指定された資産台帳はその他資産ではありません。";
		public static string FI_FA_S10016
		{
			get {return MultiLanguage.Get("CM_AM001013");}
		}

		/// <summary>
		/// 指定された資産台帳はリース資産ではありません。
		/// </summary>

// 		public static readonly string FI_FA_S10017 = "指定された資産台帳はリース資産ではありません。";
		public static string FI_FA_S10017
		{
			get {return MultiLanguage.Get("CM_AM001015");}
		}

		/// <summary>
		/// その他資産グループは指定できません。
		/// </summary>

// 		public static readonly string FI_FA_S10018 = "その他資産グループは指定できません。";
		public static string FI_FA_S10018
		{
			get {return MultiLanguage.Get("CM_AM000582");}
		}

		/// <summary>
		/// 階層と指定された部門の階層が一致しません。
		/// </summary>

// 		public static readonly string FI_FA_S10019 = "階層と指定された部門の階層が一致しません。";
		public static string FI_FA_S10019
		{
			get {return MultiLanguage.Get("CM_AM000757");}
		}

		/// <summary>
		/// 資産種類階層と指定された資産種類の階層が一致しません。
		/// </summary>

// 		public static readonly string FI_FA_S10020 = "資産種類階層と指定された資産種類の階層が一致しません。";
		public static string FI_FA_S10020
		{
			get {return MultiLanguage.Get("CM_AM001052");}
		}

		/// <summary>
		/// [%s] には0より大きい値を指定してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］には0より大きい値を指定してください。</returns>
		public static string FI_FA_S10021(string item)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］には0より大きい値を指定してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000346")).ToString();
		}
		/// <summary>
		/// %sがみつかりません。
		/// </summary>
		/// <param name="dataName">データ名</param>
		/// <returns><paramref name="dataName"/>がみつかりません。</returns>
		public static string FI_FA_S10022(string dataName)
		{
// 			return new StringBuilder(dataName, 64).Append("がみつかりません。").ToString(); 
			return new StringBuilder(dataName, 64).Append(MultiLanguage.Get("CM_AM000524")).ToString();
		}
		/// <summary>
		/// 資産台帳(%s)の[%s]は登録済の遊休期間以外の日付を入力してください。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <returns>資産台帳(<paramref name="assetListNo"/>)の[<paramref name="item"/>]は登録済の遊休期間以外の日付を入力してください。</returns>
		public static string FI_FA_S10023(string assetListNo, string item)
		{
// 			return new StringBuilder("資産台帳(", 64).Append(assetListNo).Append(")の[").Append(item).Append("]は登録済の遊休期間以外の日付を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001054"), 64).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000124")).Append(item).Append(MultiLanguage.Get("CM_AM000387")).ToString();
		}
		/// <summary>
		/// 資産台帳(%s)の一時償却後簿価は残存額以上になるよう一時償却金額を入力してください。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <returns>資産台帳(<paramref name="assetListNo"/>)の一時償却後簿価は残存額以上になるよう一時償却金額を入力してください。</returns>
		public static string FI_FA_S10024(string assetListNo)
		{
// 			return new StringBuilder("資産台帳(", 64).Append(assetListNo).Append(")の一時償却後簿価は残存額以上になるよう一時償却金額を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001054"), 64).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000125")).ToString();
		}
		/// <summary>
		/// 指定された資産台帳は%sではありません。
		/// </summary>
		/// <param name="item"></param>
		/// <returns>指定された資産台帳は<paramref name="item"/>ではありません。</returns>
		public static string FI_FA_S10025(string item)
		{
// 			return new StringBuilder("指定された資産台帳は", 64).Append(item).Append("ではありません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001012"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000601")).ToString();
		}
		/// <summary>
		/// 当年度簿価は残存額以上になるよう当年度減価償却費を入力してください。
		/// </summary>

// 		public static readonly string FI_FA_S10026 = "当年度簿価は残存額以上になるよう当年度減価償却費を入力してください。";
		public static string FI_FA_S10026
		{
			get {return MultiLanguage.Get("CM_AM001274");}
		}

		/// <summary>
		/// 資産台帳が選択されていません。
		/// </summary>

// 		public static readonly string FI_FA_S10027 = "資産台帳が選択されていません。";
		public static string FI_FA_S10027
		{
			get {return MultiLanguage.Get("CM_AM001055");}
		}

		/// <summary>
		/// 資産台帳明細が選択されていません。
		/// </summary>

// 		public static readonly string FI_FA_S10028 = "資産台帳明細が選択されていません。";
		public static string FI_FA_S10028
		{
			get {return MultiLanguage.Get("CM_AM001059");}
		}

		/// <summary>
		/// 固定資産処理履歴が選択されていません。
		/// </summary>

// 		public static readonly string FI_FA_S10029 = "固定資産処理履歴が選択されていません。";
		public static string FI_FA_S10029
		{
			get {return MultiLanguage.Get("CM_AM000891");}
		}

		/// <summary>
		/// ［%s］ は ［%s］ 以下で入力してください。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>[<paramref name="item1"/>] は [<paramref name="item"/>] 以下で入力してください。</returns>
		public static string FI_FA_S10030(string item1, string item2)
		{
// 			return new StringBuilder("[", 64).Append(item1).Append("] は [").Append(item2).Append("] 以下で入力してください。").ToString(); 
			return new StringBuilder("[", 64).Append(item1).Append(MultiLanguage.Get("CM_AM000243")).Append(item2).Append(MultiLanguage.Get("CM_AM000299")).ToString();
		}
		/// <summary>
		/// 指定された資産台帳は除却または売却済です。
		/// </summary>

// 		public static readonly string FI_FA_S10031 = "指定された資産台帳は除却または売却済です。";
		public static string FI_FA_S10031
		{
			get {return MultiLanguage.Get("CM_AM001018");}
		}

		/// <summary>
		/// 支払予定が選択されていません。
		/// </summary>

// 		public static readonly string FI_FA_S10032 = "支払予定が選択されていません。";
		public static string FI_FA_S10032
		{
			get {return MultiLanguage.Get("CM_AM001047");}
		}

		/// <summary>
		/// (資産台帳番号：%s) [%s] に不正な数値が入力されています。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>]に不正な数値が入力されています。</returns>
		public static string FI_FA_S10033(string assetListNo, string item)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item).Append("] に不正な数値が入力されています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000214")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s] に不正な日付が入力されています。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>]に不正な日付が入力されています。</returns>
		public static string FI_FA_S10034(string assetListNo, string item)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item).Append("] に不正な日付が入力されています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000215")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s] の文字数が %d 文字を超えています。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <param name="length">文字数</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>]の文字数が <paramref name="length"/> 文字を超えています。</returns>
		public static string FI_FA_S10035(string assetListNo, string item, int length)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item).Append("] の文字数が ").Append(length.ToString("#,##0")).Append(" 文字を超えています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000236")).Append(length.ToString("#,##0")).Append(MultiLanguage.Get("CM_AM000108")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s]は必須です。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>]は必須です。</returns>
		public static string FI_FA_S10036(string assetListNo, string item)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item).Append("] は必須です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000278")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s] は重複しています。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>]は重複しています。</returns>
		public static string FI_FA_S10037(string assetListNo, string item)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item).Append("] は重複しています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000265")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s] は［%s］以下で入力してください。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item1"/>] は [<paramref name="item2"/>] 以下で入力してください。</returns>
		public static string FI_FA_S10038(string assetListNo, string item1, string item2)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item1).Append("] は [").Append(item2).Append("] 以下で入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item1).Append(MultiLanguage.Get("CM_AM000243")).Append(item2).Append(MultiLanguage.Get("CM_AM000299")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s] は半角英数字で入力してください。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>] は半角英数字で入力してください。</returns>
		public static string FI_FA_S10039(string assetListNo, string item)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item).Append("] は半角英数字で入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000275")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s] は不正な区分です。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>] は不正な区分です。</returns>
		public static string FI_FA_S10040(string assetListNo, string item)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item).Append("] は不正な区分です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000280")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s] は %d 以上で入力して下さい。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <param name="minValue">最小値</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>]には <paramref name="minValue"/> 以上で入力して下さい。</returns>
		public static string FI_FA_S10041(string assetListNo, string item, decimal minValue)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item).Append("] は ").Append(minValue.ToString("#,##0.###")).Append(" 以上で入力して下さい。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000240")).Append(minValue.ToString("#,##0.###")).Append(MultiLanguage.Get("CM_AM000058")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s]には %d～%d の範囲で入力して下さい。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <param name="minValue">最小値</param>
		/// <param name="maxValue">最大値</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>]には <paramref name="minValue"/>～<paramref name="maxValue"/> の範囲で入力して下さい。</returns>
		public static string FI_FA_S10042(string assetListNo, string item, decimal minValue, decimal maxValue)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item).Append("] には ").Append(minValue.ToString("#,##0.###")).Append("～").Append(maxValue.ToString("#,##0.###")).Append(" の範囲で入力して下さい。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000210")).Append(minValue.ToString("#,##0.###")).Append(MultiLanguage.Get("CM_AM000407")).Append(maxValue.ToString("#,##0.###")).Append(MultiLanguage.Get("CM_AM000034")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s] は未登録です。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>] は未登録です。</returns>
		public static string FI_FA_S10043(string assetListNo, string item)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item).Append("] は未登録です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000285")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s] には [%s] 以降の日付で入力して下さい。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item1"/>] には [<paramref name="item2"/>] 以降の日付で入力してください。</returns>
		public static string FI_FA_S10044(string assetListNo, string item1, string item2)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item1).Append("] には [").Append(item2).Append("] 以降の日付で入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item1).Append(MultiLanguage.Get("CM_AM000211")).Append(item2).Append(MultiLanguage.Get("CM_AM000304")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s] は %d桁(少数点以下 %d桁)以内で入力して下さい。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <param name="precision">最大桁数</param>
		/// <param name="scale">少数以下の桁数</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>]には <paramref name="precision"/>桁(少数点以下 <paramref name="scale"/> 桁)以内で入力して下さい。</returns>
		public static string FI_FA_S10045(string assetListNo, string item, int precision, int scale)
		{
// 			return new StringBuilder("(資産台帳番号：", 128).Append(assetListNo).Append(") [").Append(item).Append("] には ").Append(precision.ToString("#,##0")).Append("桁(少数点以下 ").Append(scale.ToString("#,##0")).Append("桁)以内で入力して下さい").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 128).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000210")).Append(precision.ToString("#,##0")).Append(MultiLanguage.Get("CM_AM000857")).Append(scale.ToString("#,##0")).Append(MultiLanguage.Get("CM_AM000858")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s］ は%s入力してください。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <param name="expression">入力すべき表現</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>] は<paramref name="expression"/>入力してください。</returns>
		public static string FI_FA_S10046(string assetListNo, string item, string expression)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item).Append("] は").Append(expression).Append("入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000238")).Append(expression).Append(MultiLanguage.Get("CM_AM001320")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s)［%s］ と ［%s］ と ... のうち、どれかは必須です。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="items">項目名</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>)［<paramref name="items"/>］ と ［<paramref name="items"/>］ と ... のうち、どれかは必須です。</returns>
		public static string FI_FA_S10047(string assetListNo, params string[] items)
		{
			switch (items.Length)
			{
				case 0:
// 					return "必須です。"; 
					return MultiLanguage.Get("CM_AM001357");
				case 1:
					return FI_FA_S10036(assetListNo,items[0]);
				case 2:
// 					return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(")［").Append(items[0]).Append("］ と ［").Append(items[1]).Append("］ のどちらかは必須です。").ToString(); 
					return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000123")).Append(items[0]).Append(MultiLanguage.Get("CM_AM000205")).Append(items[1]).Append(MultiLanguage.Get("CM_AM000222")).ToString();
				default:
// 					StringBuilder sb = new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(")［"); 
					StringBuilder sb = new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000123"));
					foreach (string item in items)
					{
// 						sb.Append(item).Append("］ と ［"); 
						sb.Append(item).Append(MultiLanguage.Get("CM_AM000205"));
					}
					sb.Remove(sb.Length - 3, 3);
// 					sb.Append("のうち、どれかは必須です。"); 
					sb.Append(MultiLanguage.Get("CM_AM000618"));
					return sb.ToString();
			}
		}
		/// <summary>
		/// (資産台帳番号：%s) [%s］の%sが存在しません。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <param name="data">データ</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>] の<paramref name="data"/>が存在しません。</returns>
		public static string FI_FA_S10048(string assetListNo, string item, string data)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item).Append("] の").Append(data).Append("が存在しません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000217")).Append(data).Append(MultiLanguage.Get("CM_AM000529")).ToString();
		}
		/// <summary>
		/// [%s］の%sが存在しません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="data">データ</param>
		/// <returns>[<paramref name="item"/>] の<paramref name="data"/>が存在しません。</returns>
		public static string FI_FA_S10049(string item, string data)
		{
// 			return new StringBuilder("[",64).Append(item).Append("] の").Append(data).Append("が存在しません。").ToString(); 
			return new StringBuilder("[", 64).Append(item).Append(MultiLanguage.Get("CM_AM000217")).Append(data).Append(MultiLanguage.Get("CM_AM000529")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) %s
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="message">メッセージ</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) <paramref name="message"/></returns>
		public static string FI_FA_S10050(string assetListNo, string message)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") ").Append(message).ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") ").Append(message).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) 台帳取込エラー (%s)
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="message">メッセージ</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) 台帳取込エラー (<paramref name="message"/>)</returns>
		public static string FI_FA_S10051(string assetListNo, string message)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") 台帳取込エラー (").Append(message).Append(")").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000121")).Append(message).Append(")").ToString();
		}

		/// <summary>
		/// (資産台帳番号：%s 履歴順番：%s 履歴種類：%s) 履歴取込エラー (%s)
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="recordSeqno">履歴順番</param>
		/// <param name="recordClass">履歴種類</param>
		/// <param name="message">メッセージ</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/> 履歴順番：<paramref name="recordSeqno"/> 履歴種類：<paramref name="recordClass"/>) 履歴取込エラー (<paramref name="message"/>)</returns>
		public static string FI_FA_S10052(string assetListNo,string recordSeqno,string recordClass, string message)
		{
// 			return new StringBuilder("(資産台帳番号：", 128).Append(assetListNo).Append(" 履歴順番：").Append(recordSeqno).Append(" 履歴種類：").Append(recordClass).Append(") 履歴取込エラー (").Append(message).Append(")").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 128).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000113")).Append(recordSeqno).Append(MultiLanguage.Get("CM_AM000112")).Append(recordClass).Append(MultiLanguage.Get("CM_AM000122")).Append(message).Append(")").ToString();
		}
		/// <summary>
		/// 前年度の会計月度が登録されていません。
		/// </summary>

// 		public static readonly string FI_FA_S10053 = "前年度の会計月度が登録されていません。";
		public static string FI_FA_S10053
		{
			get {return MultiLanguage.Get("CM_AM001210");}
		}

		/// <summary>
		/// (資産台帳番号：%s) [%s] は 0 より大きい金額を入力してください。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="item">項目名</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>) [<paramref name="item"/>] は 0 より大きい金額を入力してください。</returns>
		public static string FI_FA_S10054(string assetListNo, string item)
		{
// 			return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(") [").Append(item).Append("] は 0 より大きい金額を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(") [").Append(item).Append(MultiLanguage.Get("CM_AM000245")).ToString();
		}
		/// <summary>
		/// 移動元申告自治体を指定した明細データを登録してから、履歴を登録してください。
		/// </summary>

// 		public static readonly string FI_FA_S10055 = "移動元申告自治体を指定した明細データを登録してから、履歴を登録してください。";
		public static string FI_FA_S10055
		{
			get {return MultiLanguage.Get("CM_AM000723");}
		}

		/// <summary>
		/// 取得区分 = 「移動による受け入れ」は、新規台帳登録時のみ、指定可能です。
		/// </summary>

// 		public static readonly string FI_FA_S10056 = "取得区分 = 「移動による受け入れ」は、新規台帳登録時のみ、指定可能です。";
		public static string FI_FA_S10056
		{
			get {return MultiLanguage.Get("CM_AM001099");}
		}

		/// <summary>
		/// 当該明細に紐づく、「申告自治体一部移動」履歴を取消してください。
		/// </summary>

// 		public static readonly string FI_FA_S10057 = "当該明細に紐づく、「申告自治体一部移動」履歴を取消してください。";
		public static string FI_FA_S10057
		{
			get {return MultiLanguage.Get("CM_AM001271");}
		}

		/// <summary>
		/// 資産台帳に紐づく明細データが1件のみのため、一括移動処理にて申告自治体変更を含む移動処理を行ってください。
		/// </summary>

// 		public static readonly string FI_FA_S10058 = "資産台帳に紐づく明細データが1件のみのため、一括移動処理にて申告自治体変更を含む移動処理を行ってください。";
		public static string FI_FA_S10058
		{
			get {return MultiLanguage.Get("CM_AM001056");}
		}

		/// <summary>
		/// 申告自治体が変更されています。申告自治体移動対象明細行の「別申告自治体に明細移動」チェックボックスにチェックを入れてください。
		/// </summary>

// 		public static readonly string FI_FA_S10059 = "申告自治体が変更されています。申告自治体移動対象明細行の「別申告自治体に明細移動」チェックボックスにチェックを入れてください。";
		public static string FI_FA_S10059
		{
			get {return MultiLanguage.Get("CM_AM001167");}
		}

		/// <summary>
		/// 資産台帳に紐づく明細データを全て申告自治体移動する場合には、一括移動処理にて申告自治体変更を含む移動処理を行ってください。
		/// </summary>

// 		public static readonly string FI_FA_S10060 = "資産台帳に紐づく明細データを全て申告自治体移動する場合には、一括移動処理にて申告自治体変更を含む移動処理を行ってください。";
		public static string FI_FA_S10060
		{
			get {return MultiLanguage.Get("CM_AM001057");}
		}

		/// <summary>
		/// 資産明細が一件のみしか登録されていないため、この履歴は取消出来ません。この資産台帳自体を削除してください。
		/// </summary>

// 		public static readonly string FI_FA_S10061 = "資産明細が一件のみしか登録されていないため、この履歴は取消出来ません。この資産台帳自体を削除してください。";
		public static string FI_FA_S10061
		{
			get {return MultiLanguage.Get("CM_AM001060");}
		}

		/// <summary>
		/// 遊休期間は、組織変更日をまたいで設定することはできません。
		/// </summary>

// 		public static readonly string FI_FA_S10062 = "遊休期間は、組織変更日をまたいで設定することはできません。";
		public static string FI_FA_S10062
		{
			get {return MultiLanguage.Get("CM_AM001417");}
		}

		/// <summary>
		/// 処理対象取得価額(台帳単位)と処理対象取得価額(明細単位の合計)の価額は同一にしてください。
		/// </summary>

// 		public static readonly string FI_FA_S10063 = "処理対象取得価額(台帳単位)と処理対象取得価額(明細単位の合計)の価額は同一にしてください。";
		public static string FI_FA_S10063
		{
			get {return MultiLanguage.Get("CM_AM001136");}
		}

		/// <summary>
		/// 売却金額(台帳単位)と売却金額(明細単位の合計)の金額は同一にしてください。
		/// </summary>

// 		public static readonly string FI_FA_S10064 = "売却金額(台帳単位)と売却金額(明細単位の合計)の金額は同一にしてください。";
		public static string FI_FA_S10064
		{
			get {return MultiLanguage.Get("CM_AM001337");}
		}

		/// <summary>
		/// 申告自治体一部移動対象明細の「管理部門」又は「計上部門」の移動は、申告自治体一部移動先資産台帳側にて、行ってください。
		/// </summary>

// 		public static readonly string FI_FA_S10065 = "申告自治体一部移動対象明細の「管理部門」又は「計上部門」の移動は、申告自治体一部移動先資産台帳側にて、行ってください。";
		public static string FI_FA_S10065
		{
			get {return MultiLanguage.Get("CM_AM001173");}
		}

		/// <summary>
		/// 圧縮記帳額は取得価額未満で入力してください。
		/// </summary>

// 		public static readonly string FI_FA_S10066 = "圧縮記帳額は取得価額未満で入力してください。";
		public static string FI_FA_S10066
		{
			get {return MultiLanguage.Get("CM_AM000706");}
		}

		/// <summary>
		/// 支払間隔×支払間隔月が9999以下となるように入力してください。
		/// </summary>

// 		public static readonly string FI_FA_S10067 = "支払間隔、支払間隔月に適切な値を入力してください。";
		public static string FI_FA_S10067
		{
			get {return MultiLanguage.Get("CM_AM001038");}
		}

		/// <summary>
		/// 支払額に適切な値を入力してください。
		/// </summary>

// 		public static readonly string FI_FA_S10068 = "支払額に適切な値を入力してください。";
		public static string FI_FA_S10068
		{
			get {return MultiLanguage.Get("CM_AM001037");}
		}

		/// <summary>
		/// 一括償却資産の場合、耐用年数短縮登録はできません。
		/// </summary>

// 		public static readonly string FI_FA_S10069 = "一括償却資産の場合、耐用年数短縮登録はできません。";
		public static string FI_FA_S10069
		{
			get {return MultiLanguage.Get("CM_AM000728");}
		}

		/// <summary>
		/// 一括償却資産の場合、資産配分入力はできません。
		/// </summary>

// 		public static readonly string FI_FA_S10070 = "一括償却を選択した場合、減損測定資グループおよび共有資産グループへの資産グループ登録はできません。";
		public static string FI_FA_S10070
		{
			get {return MultiLanguage.Get("CM_AM000726");}
		}

		/// <summary>
		/// 有形固定資産台帳以外、申告自治体を移動する事は出来ません。有形固定資産台帳のみ選択して下さい。
		/// </summary>

// 		public static readonly string FI_FA_S10071 = "有形固定資産台帳以外、申告自治体を移動する事は出来ません。有形固定資産台帳のみ選択して下さい。";
		public static string FI_FA_S10071
		{
			get {return MultiLanguage.Get("CM_AM001404");}
		}

		//管理番号B16206From
		/// <summary>
		/// 他のユーザが更新中の為、更新できません。しばらくお待ちになり更新をして下さい。
		/// </summary>

// 		public static readonly string FI_FA_S10072 = "他のユーザが更新中の為、更新できません。しばらくお待ちになり更新をして下さい。";
		public static string FI_FA_S10072
		{
			get {return MultiLanguage.Get("CM_AM001225");}
		}

		//管理番号B16206To
		/// <summary>
		/// 入力した計上日は減価償却費の差額調整が発生している期間の為、履歴登録は行えません。
		/// </summary>

// 		public static readonly string FI_FA_S10073 = "入力した計上日は減価償却費の差額調整が発生している期間の為、履歴登録は行えません。";
		public static string FI_FA_S10073
		{
			get {return MultiLanguage.Get("CM_AM001319");}
		}

		// 管理番号B19678 From
		/// <summary>
		/// ［%s］ は ［%s］ 以降の年度で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ は ［<paramref name="item2"/>］ 以降の年度で入力してください。</returns>
		public static string FI_FA_S10074(string item1, string item2)
		{
// 			return new StringBuilder("［", 64).Append(item1).Append("］ は ［").Append(item2).Append("］ 以降の年度で入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000241")).Append(item2).Append(MultiLanguage.Get("CM_AM000306")).ToString();
		}
// 管理番号B19678 To
		/// <summary>
		/// 仕訳計上済期間に資産台帳登録・固定資産履歴登録を行っている為、「仕訳計上済年月」の更新はできません。
		/// </summary>

// 		public static readonly string FI_FA_S10075 = "仕訳計上済期間に資産台帳登録・固定資産履歴登録を行っている為、「仕訳計上済年月」の更新はできません。";
		public static string FI_FA_S10075
		{
			get {return MultiLanguage.Get("CM_AM000993");}
		}

		/// <summary>
		/// 指定された資産台帳の会計償却は除却または売却済です。
		/// </summary>

// 		public static readonly string FI_FA_S10076 = "指定された資産台帳の会計償却は除却または売却済です。";
		public static string FI_FA_S10076
		{
			get {return MultiLanguage.Get("CM_AM001011");}
		}

		/// <summary>
		/// 一括償却資産の場合、減価償却費変更登録はできません。
		/// </summary>

// 		public static readonly string FI_FA_S10077 = "一括償却資産の場合、減価償却費変更登録はできません。";
		public static string FI_FA_S10077
		{
			get {return MultiLanguage.Get("CM_AM000727");}
		}

		/// <summary>
		/// 任意償却資産の場合、耐用年数短縮登録はできません。
		/// </summary>

// 		public static readonly string FI_FA_S10078 = "任意償却資産の場合、耐用年数短縮登録はできません。";
		public static string FI_FA_S10078
		{
			get {return MultiLanguage.Get("CM_AM001325");}
		}

		/// <summary>
		/// 均等償却を選択した場合、減損測定資グループおよび共有資産グループへの資産グループ登録はできません。
		/// </summary>

// 		public static readonly string FI_FA_S10079 = "均等償却を選択した場合、減損測定資グループおよび共有資産グループへの資産グループ登録はできません。";
		public static string FI_FA_S10079
		{
			get {return MultiLanguage.Get("CM_AM000845");}
		}

		/// <summary>
		/// ［処理対象取得価額］が［取得価額］未満のため［処理対象台帳数量］に［数量］と同じ値は指定できません。
		/// </summary>

// 		public static readonly string FI_FA_S10080 = "［処理対象取得価額］が［取得価額］未満のため［処理対象台帳数量］に［数量］と同じ値は指定できません。";
		public static string FI_FA_S10080
		{
			get {return MultiLanguage.Get("CM_AM000152");}
		}

		/// <summary>
		/// 資産台帳番号 [%s] は%sため償却限度額変更できません。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="reason">理由</param>
		/// <returns>資産台帳番号 [<paramref name="assetListNo"/>] は<paramref name="reason"/>ため償却限度額変更できません。</returns>
		public static string FI_FA_S10081(string assetListNo, string reason)
		{
// 			return new StringBuilder("資産台帳番号 [", 64).Append(assetListNo).Append("] は").Append(reason).Append("ため償却限度額変更できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001058"), 64).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000238")).Append(reason).Append(MultiLanguage.Get("CM_AM000585")).ToString();
		}
		/// <summary>
		/// 償却限度額変更履歴が存在するため、耐用年数短縮登録はできません。
		/// </summary>

// 		public static readonly string FI_FA_S10082 = "償却限度額変更履歴が存在するため、耐用年数短縮登録はできません。";
		public static string FI_FA_S10082
		{
			get {return MultiLanguage.Get("CM_AM001139");}
		}

		/// <summary>
		/// 当年度の日付を入力してください。
		/// </summary>

// 		public static readonly string FI_FA_S10083 = "当年度の日付を入力してください。";
		public static string FI_FA_S10083
		{
			get {return MultiLanguage.Get("CM_AM001273");}
		}

		/// <summary>
		/// 未承認履歴が存在します。承認処理後に%sして下さい。
		/// </summary>
		/// <param name="item"></param>
		/// <returns>未承認履歴が存在します。承認処理後に<paramref name="item"/>して下さい。</returns>
		public static string FI_FA_S10084(string item)
		{
// 			return new StringBuilder("未承認履歴が存在します。承認処理後に", 64).Append(item).Append("して下さい。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001396"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000573")).ToString();
		}
		/// <summary>
		/// 未承認状態の台帳が含まれています。承認処理を行ってから実施してください。
		/// </summary>

// 		public static readonly string FI_FA_S10085 = "未承認状態の台帳が含まれています。承認処理を行ってから実施してください。";
		public static string FI_FA_S10085
		{
			get {return MultiLanguage.Get("CM_AM001392");}
		}

		/// <summary>
		/// 承認処理を実行しました。
		/// </summary>

// 		public static readonly string FI_FA_S10086 = "承認処理を実行しました。";
		public static string FI_FA_S10086
		{
			get {return MultiLanguage.Get("CM_AM001153");}
		}

		/// <summary>
		/// 未承認状態の台帳のため、承認処理を行ってから実施してください。
		/// </summary>

// 		public static readonly string FI_FA_S10087 = "未承認状態の台帳のため、承認処理を行ってから実施してください。" ;
		public static string FI_FA_S10087
		{
			get {return MultiLanguage.Get("CM_AM001394");}
		}

		/// <summary>
		/// 申告自治体一部移動の受入により登録された履歴は取消出来ません。この資産台帳自体を削除してください。
		/// </summary>

// 		public static readonly string FI_FA_S10088 = "申告自治体一部移動の受入により登録された履歴は取消出来ません。この資産台帳自体を削除してください。";
		public static string FI_FA_S10088
		{
			get {return MultiLanguage.Get("CM_AM001168");}
		}

		/// <summary>
		/// %s が変更されていません。
		/// </summary>
		public static string FI_FA_S10089(string item)
		{
// 			return new StringBuilder(item, 64).Append("が変更されていません。").ToString(); 
			return new StringBuilder(item, 64).Append(MultiLanguage.Get("CM_AM000533")).ToString();
		}
		/// <summary>
		/// 指定された資産台帳はリース契約終了済です。
		/// </summary>

// 		public static readonly string FI_FA_S10090 = "指定された資産台帳はリース契約終了済です。";
		public static string FI_FA_S10090
		{
			get {return MultiLanguage.Get("CM_AM001014");}
		}

		/// <summary>
		/// 資産台帳番号 [%s] は%sためリース契約終了できません。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="reason">理由</param>
		/// <returns>資産台帳番号 [<paramref name="assetListNo"/>] は<paramref name="reason"/>ためリース契約終了できません。</returns>
		public static string FI_FA_S10091(string assetListNo, string reason)
		{
// 			return new StringBuilder("資産台帳番号 [", 64).Append(assetListNo).Append("] は").Append(reason).Append("ためリース契約終了できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001058"), 64).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000238")).Append(reason).Append(MultiLanguage.Get("CM_AM000584")).ToString();
		}
		/// <summary>
		/// 償却限度額変更履歴の計上日は会計期間開始日を指定して下さい。
		/// </summary>

// 		public static readonly string FI_FA_S10092 = "償却限度額変更履歴の計上日は会計期間開始日を指定して下さい。";
		public static string FI_FA_S10092
		{
			get {return MultiLanguage.Get("CM_AM001140");}
		}

		/// <summary>
		/// 計上日の年度の償却費計算処理が未実施の為、履歴を登録できません。
		/// 対象年度について、全件の償却費計算処理を実施して下さい。
		/// </summary>

// 		public static readonly string FI_FA_S10093 = "計上日の年度の償却費計算処理が未実施の為、履歴を登録できません。\r\n対象年度について、全件の償却費計算処理を実施して下さい。";
		public static string FI_FA_S10093
		{
			get {return MultiLanguage.Get("CM_AM000855");}
		}

		/// <summary>
		/// 入力された［利子率］をご確認下さい。（［支払明細）の支払最終月に［リース債務残高］が残っています。）。
		/// </summary>

// 		public static readonly string FI_FA_S10094 = "入力された［利子率］をご確認下さい。（［支払明細）の支払最終月に［リース債務残高］が残っています。）";
		public static string FI_FA_S10094
		{
			get {return MultiLanguage.Get("CM_AM001308");}
		}

		/// <summary>
		/// 入力された［利子率］をご確認下さい。（［支払明細）の支払最終月より前に支払が完了しています。）
		/// </summary>

// 		public static readonly string FI_FA_S10095 = "入力された［利子率］をご確認下さい。（［支払明細）の支払最終月より前に支払が完了しています。）";
		public static string FI_FA_S10095
		{
			get {return MultiLanguage.Get("CM_AM001309");}
		}

		public static string FI_FA_S10096(string assetListNo)
		{
// 			return new StringBuilder(" [", 64).Append(assetListNo).Append("] ").Append("指定された中途解約日は、既に資産台帳に存在するか、または契約終了日以降の日付がセットされています。").ToString(); 
			return new StringBuilder(" [", 64).Append(assetListNo).Append("] ").Append(MultiLanguage.Get("CM_AM001024")).ToString();
		}
		/// <summary>
		/// %s できません。
		/// </summary>
		public static string FI_FA_S10097(string item)
		{
// 			return new StringBuilder(item, 64).Append("できません。").ToString(); 
			return new StringBuilder(item, 64).Append(MultiLanguage.Get("CM_AM000599")).ToString();
		}
		/// <summary>
		/// 複数の決算期にまたがる［集計期間］は指定できません。
		/// </summary>

// 		public static readonly string FI_FA_S10098 = "複数の決算期にまたがる［集計期間］は指定できません。";
		public static string FI_FA_S10098
		{
			get {return MultiLanguage.Get("CM_AM001371");}
		}

		/// <summary>
		/// 同年同月に減価償却費変更履歴が存在します。
		/// </summary>

// 		public static readonly string FI_FA_S10099 = "同年同月に減価償却費変更履歴が存在します。";
		public static string FI_FA_S10099
		{
			get {return MultiLanguage.Get("CM_AM001286");}
		}

        /// <summary>
        /// 決算期が設定されていないため、当該機能は利用できません。
        /// </summary>

//      public static readonly string FI_FA_S10100 = "決算期が設定されていないため、当該機能は利用できません。";
		public static string FI_FA_S10100
		{
			get {return MultiLanguage.Get("CM_AM000864");}
		}

		/// <summary>
		/// 出力順序に同じ値が登録されています。
		/// </summary>

// 		public static readonly string FI_FA_S10101 = "出力順序に同じ値が登録されています。";
		public static string FI_FA_S10101
		{
			get {return MultiLanguage.Get("CM_AM001128");}
		}

		/// <summary>
		/// 項目間空白には 1 ～ 90 の値を入力してください。
		/// </summary>

// 		public static readonly string FI_FA_S10102 = "項目間空白には 1 ～ 90 の値を入力してください。";
		public static string FI_FA_S10102
		{
			get {return MultiLanguage.Get("CM_AM000921");}
		}

		/// <summary>
		/// 遡及調整が行われる期間中に償却が完了する資産に対して一部除売却は登録できません。
		/// </summary>

// 		public static readonly string FI_FA_S10103 = "遡及調整が行われる期間中に償却が完了する資産に対して一部除売却は登録できません。";
		public static string FI_FA_S10103
		{
			get {return MultiLanguage.Get("CM_AM001218");}
		}

		/// <summary>
		/// ［%s］がBS勘定科目のため、コスト計上部門は指定できません。
		/// </summary>
		/// <param name="deptFixType">貸方勘定科目/借方勘定科目</param>
		/// <returns>［<paramref name="deptFixType"/>］がBS勘定科目のため、コスト計上部門は指定できません。</returns>
		public static string FI_FA_S10104(string deptFixType)
		{
// 			return new StringBuilder("［",64).Append(deptFixType).Append("］がBS勘定科目のため、コスト計上部門は指定できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(deptFixType).Append(MultiLanguage.Get("CM_AM000323")).ToString();
		}
		/// <summary>
		/// [借方部門指定]と[貸方部門指定]の両方にコスト計上部門を指定することはできません。
		/// </summary>

// 		public static readonly string FI_FA_S10105 = "[借方部門指定]と[貸方部門指定]の両方にコスト計上部門を指定することはできません。";
		public static string FI_FA_S10105
		{
			get {return MultiLanguage.Get("CM_AM000148");}
		}

		/// <summary>
		/// %s為、資産分割登録はできません。
		/// </summary>
		/// <param name="reason">理由</param>
		/// <returns>［<paramref name="reason"/>］為、資産分割登録はできません。</returns>
		public static string FI_FA_S10107(string reason)
		{
// 			return new StringBuilder("", 64).Append(reason).Append("為、資産分割登録はできません。").ToString(); 
			return new StringBuilder("", 64).Append(reason).Append(MultiLanguage.Get("CM_AM000717")).ToString();
		}
		/// <summary>
		/// ［%s］ は［%s］より少ない［%s］で入力してください。
		/// </summary>
		public static string FI_FA_S10108(string item1, string item2, string item3)
		{
// 			return new StringBuilder(item1, 64).Append("は").Append(item2).Append("より少ない").Append(item3).Append("で入力してください。").ToString(); 
			return new StringBuilder(item1, 64).Append(MultiLanguage.Get("CM_AM000631")).Append(item2).Append(MultiLanguage.Get("CM_AM000675")).Append(item3).Append(MultiLanguage.Get("CM_AM000605")).ToString();
		}
		/// <summary>
		/// ［%s］ は［%s］以上になるようにしてください。
		/// </summary>
		public static string FI_FA_S10109(string item1, string item2)
		{
// 			return new StringBuilder(item1, 64).Append("は").Append(item2).Append("以上になるようにしてください。").ToString(); 
			return new StringBuilder(item1, 64).Append(MultiLanguage.Get("CM_AM000631")).Append(item2).Append(MultiLanguage.Get("CM_AM000716")).ToString();
		}
		/// <summary>
		/// ［%s］ は［%s］よりも小さい値を入力してください。
		/// </summary>
		public static string FI_FA_S10110(string item1, string item2)
		{
// 			return new StringBuilder(item1, 64).Append("は").Append(item2).Append("よりも小さい値を入力してください。").ToString(); 
			return new StringBuilder(item1, 64).Append(MultiLanguage.Get("CM_AM000631")).Append(item2).Append(MultiLanguage.Get("CM_AM000674")).ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s)［%s］ と ［%s］ と ... のうち、１項目は変更してください。
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="items">項目名</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/>)［<paramref name="items"/>］ と ［<paramref name="items"/>］ と ... のうち、１項目は変更してください。</returns>
		public static string FI_FA_S10111(string assetListNo, params string[] items)
		{
			switch (items.Length)
			{
				case 0:
// 					return "必須です。"; 
					return MultiLanguage.Get("CM_AM001357");
				case 1:
// 					return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(")［").Append(items[0]).Append("］ を変更してください。").ToString(); 
					return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000123")).Append(items[0]).Append(MultiLanguage.Get("CM_AM000296")).ToString();
				case 2:
// 					return new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(")［").Append(items[0]).Append("］ と ［").Append(items[1]).Append("］ のどちらかを変更してください。").ToString(); 
					return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000123")).Append(items[0]).Append(MultiLanguage.Get("CM_AM000205")).Append(items[1]).Append(MultiLanguage.Get("CM_AM000223")).ToString();
				default:
// 					StringBuilder sb = new StringBuilder("(資産台帳番号：", 64).Append(assetListNo).Append(")［"); 
					StringBuilder sb = new StringBuilder(MultiLanguage.Get("CM_AM000114"), 64).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000123"));
					foreach (string item in items)
					{
// 						sb.Append(item).Append("］ と ［"); 
						sb.Append(item).Append(MultiLanguage.Get("CM_AM000205"));
					}
					sb.Remove(sb.Length - 3, 3);
// 					sb.Append("のうち、１項目は変更してください。"); 
					sb.Append(MultiLanguage.Get("CM_AM000617"));
					return sb.ToString();
			}
		}
		/// <summary>
		/// 未承認の資産除去債務情報が存在します。承認処理後に[%s]して下さい。
		/// </summary>
		/// <param name="item1"></param>
		/// <returns></returns>
		public static string FI_FA_S10112(string item1)
		{
// 			return new StringBuilder("未承認の資産除去債務情報が存在します。承認処理後に", 64).Append(item1).Append("して下さい。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001390"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000573")).ToString();
		}
		/// <summary>
		/// 未承認状態の台帳のため、資産除去債務タブの情報は表示できません。
		/// </summary>

// 		public static readonly string FI_FA_S10113 = "未承認状態の台帳のため、資産除去債務タブの情報は表示できません。";
		public static string FI_FA_S10113
		{
			get {return MultiLanguage.Get("CM_AM001393");}
		}

		/// <summary>
		/// 再計算が行われていないため、月次残高を表示できません。
		/// </summary>

// 		public static readonly string FI_FA_S10114 = "再計算が行われていないため、月次残高を表示できません。";
		public static string FI_FA_S10114
		{
			get {return MultiLanguage.Get("CM_AM000930");}
		}

		/// <summary>
		/// 再計算が行われていません。
		/// </summary>

// 		public static readonly string FI_FA_S10115 = "再計算が行われていません。";
		public static string FI_FA_S10115
		{
			get {return MultiLanguage.Get("CM_AM000931");}
		}

		/// <summary>
		/// [%s]の[月額（合計）]と[%s]の[年額]に差異があるため更新できません。
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns></returns>
		public static string FI_FA_S10116(string item1, string item2)
		{
// 			return new StringBuilder("[", 64).Append(item1).Append("]の[月額（合計）]と[").Append(item2).Append("]の[年額]に差異があるため更新できません。").ToString(); 
			return new StringBuilder("[", 64).Append(item1).Append(MultiLanguage.Get("CM_AM000353")).Append(item2).Append(MultiLanguage.Get("CM_AM000354")).ToString();
		}
		/// <summary>
		/// 最終年度は[期末簿価]が%sとなるよう[減価償却費]を入力してください。
		/// </summary>
		/// <param name="item1"></param>
		/// <returns></returns>
		public static string FI_FA_S10117(string item1)
		{
// 			return new StringBuilder("最終年度は[期末簿価]が", 64).Append(item1).Append("となるよう[減価償却費]を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000933"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000610")).ToString();
		}
		/// <summary>
		/// 最終年度は[期末資産除去債務残高]が[割引前将来CF見積額]となるよう[時の経過による調整額]を入力してください。
		/// </summary>

// 		public static readonly string FI_FA_S10118 = "最終年度は[期末資産除去債務残高]が[割引前将来CF見積額]となるよう[時の経過による調整額]を入力してください。";
		public static string FI_FA_S10118
		{
			get {return MultiLanguage.Get("CM_AM000932");}
		}

		/// <summary>
		/// 入力した計上日は[%s]の為、[%s]は行えません。
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns></returns>
		public static string FI_FA_S10119(string item1, string item2)
		{
// 			return new StringBuilder("入力した計上日は[", 64).Append(item1).Append("]の為、[").Append(item2).Append("]は行えません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001318"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000363")).Append(item2).Append(MultiLanguage.Get("CM_AM000385")).ToString();
		}
		/// <summary>
		/// [%s]されていない資産のため、資産除去債務履行は登録できません。
		/// </summary>
		/// <param name="item1"></param>
		/// <returns></returns>
		public static string FI_FA_S10120(string item1)
		{
// 			return new StringBuilder("[", 64).Append(item1).Append("]されていない資産のため、資産除去債務履行は登録できません。").ToString(); 
			return new StringBuilder("[", 64).Append(item1).Append(MultiLanguage.Get("CM_AM000330")).ToString();
		}
		/// <summary>
		/// 指定された資産グループに有効な資産台帳が存在しません。
		/// </summary>

// 		public static readonly string FI_FA_S10121 = "指定された資産グループに有効な資産台帳が存在しません。";
		public static string FI_FA_S10121
		{
			get {return MultiLanguage.Get("CM_AM001010");}
		}

		/// <summary>
		/// 見積変更時、[期末簿価]が%s以上となるよう[将来CF見積額／割引率変更影響額]を入力してください。
		/// </summary>
		/// <param name="item1"></param>
		/// <returns></returns>
		public static string FI_FA_S10122(string item1)
		{
// 			return new StringBuilder("見積変更時、[期末簿価]が", 64).Append(item1).Append("以上となるよう[将来CF見積額／割引率変更影響額]を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000879"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000715")).ToString();
		}
		/// <summary>
		/// 計上日以降に固定資産処理履歴が存在するため、行取消できません。
		/// </summary>

// 		public static readonly string FI_FA_S10123 = "計上日以降に固定資産処理履歴が存在するため、行取消できません。";
		public static string FI_FA_S10123
		{
			get {return MultiLanguage.Get("CM_AM000856");}
		}

		/// <summary>
		/// %s1の[%s2]を下回る金額は入力できません。
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns></returns>
		public static string FI_FA_S10124(string item1, string item2)
		{
// 			return new StringBuilder(item1, 64).Append("の[").Append(item2).Append("]を下回る金額は入力できません。").ToString(); 
			return new StringBuilder(item1, 64).Append(MultiLanguage.Get("CM_AM000615")).Append(item2).Append(MultiLanguage.Get("CM_AM000393")).ToString();
		}
		/// <summary>
		/// 入力された計上日が、除却履歴計上日と同月ではありません。
		/// </summary>

// 		public static readonly string FI_FA_S10125 = "入力された計上日が、除却履歴計上日と同月ではありません。";
		public static string FI_FA_S10125
		{
			get {return MultiLanguage.Get("CM_AM001312");}
		}

		/// <summary>
		/// 資産除去債務履行が必要な資産があります。
		/// </summary>

// 		public static readonly string FI_FA_S10126 = "資産除去債務履行が必要な資産があります。";
		public static string FI_FA_S10126
		{
			get {return MultiLanguage.Get("CM_AM001053");}
		}

		/// <summary>
		/// (資産台帳番号：%s) 資産除去債務取込エラー (%s)
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="message">メッセージ</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/> ) 履歴取込エラー (<paramref name="message"/>)</returns>
		public static string FI_FA_S10127(string assetListNo, string message)
		{
// 			return new StringBuilder("(資産台帳番号：", 128).Append(assetListNo).Append(") 資産除去債務取込エラー (").Append(message).Append(")").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 128).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000120")).Append(message).Append(")").ToString();
		}
		/// <summary>
		/// (資産台帳番号：%s) 資産除去債務残高/償却費取込エラー(%s)
		/// </summary>
		/// <param name="assetListNo">資産台帳番号</param>
		/// <param name="interestClacMonth">年月</param>
		/// <param name="message">メッセージ</param>
		/// <returns>(資産台帳番号：<paramref name="assetListNo"/> ) 資産除去債務残高/償却費取込エラー (<paramref name="message"/>)</returns>
		public static string FI_FA_S10128(string assetListNo, string interestClacMonth, string message)
		{
// 			return new StringBuilder("(資産台帳番号：", 128).Append(assetListNo).Append(") 資産除去債務残高/償却費取込エラー [年月：").Append(interestClacMonth).Append("] (").Append(message).Append(")").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000114"), 128).Append(assetListNo).Append(MultiLanguage.Get("CM_AM000119")).Append(interestClacMonth).Append("] (").Append(message).Append(")").ToString();
		}
		/// <summary>
		/// 資産除去債務計上額が変更されています。時の経過による調整額をご確認下さい。
		/// </summary>

// 		public static readonly string FI_FA_S10129 = "[時の経過による調整額]をご確認下さい。（[資産除去債務計上額]が直接入力されています。）";
		public static string FI_FA_S10129
		{
			get {return MultiLanguage.Get("CM_AM000146");}
		}



		/// <summary>
		/// [%s1年度][期末簿価]が%s2以上となるよう[減価償却費]を入力してください。
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns></returns>
		public static string FI_FA_S10130(string item1, string item2)
		{
// 			return new StringBuilder("[", 128).Append(item1).Append("年度][期末簿価]が").Append(item2).Append("以上となるよう[減価償却費]を入力してください。").ToString(); 
			return new StringBuilder("[", 128).Append(item1).Append(MultiLanguage.Get("CM_AM001330")).Append(item2).Append(MultiLanguage.Get("CM_AM000714")).ToString();
		}
		/// <summary>
		/// [%s1年度][期末資産除去債務残高]が[割引前将来CF見積額]以下となるよう[時の経過による調整額]を入力してください。
		/// </summary>
		/// <param name="item1"></param>
		/// <returns></returns>
		public static string FI_FA_S10131(string item1)
		{
// 			return new StringBuilder("[", 128).Append(item1).Append("年度][期末資産除去債務残高]が[割引前将来CF見積額]以下となるよう[時の経過による調整額]を入力してください。").ToString(); 
			return new StringBuilder("[", 128).Append(item1).Append(MultiLanguage.Get("CM_AM001329")).ToString();
		}
		/// <summary>
		/// [%s]されている資産のため、見積変更は登録できません。
		/// </summary>
		/// <param name="item1"></param>
		/// <returns></returns>
		public static string FI_FA_S10132(string item1)
		{
// 			return new StringBuilder("[", 64).Append(item1).Append("]されている資産のため、見積変更は登録できません。").ToString(); 
			return new StringBuilder("[", 64).Append(item1).Append(MultiLanguage.Get("CM_AM000331")).ToString();
		}
		/// <summary>
		/// 仕訳計上済年月が正常に設定されていません。Webアプリケーションの再設定を行うか、再度ログインしてください。
		/// </summary>

// 		public static readonly string FI_FA_S10133 = "仕訳計上済年月が正常に設定されていません。Webアプリケーションの再設定を行うか、再度ログインしてください。";
		public static string FI_FA_S10133
		{
			get {return MultiLanguage.Get("CM_AM000994");}
		}

		/// <summary>
		/// 支払明細が再作成されました。[税率基準日]、[消費税]を確認してください。
		/// </summary>
		public static string FI_FA_S10134
		{
			get { return MultiLanguage.Get("CM_AM001641"); }
		}

		/// <summary>
		/// 支払明細の消費税率が前回更新時と異なります。［消費税率］マスタを確認の上、更新してください。
		/// </summary>
		public static string FI_FA_S10135
		{
			get { return MultiLanguage.Get("CM_AM001642"); }
		}

		/// <summary>
		/// ［{0}］が控除外課税仕入の場合、［{1}］に雑仕入先は登録できません。
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns>［<paramref name="item1"/>］が控除外課税仕入の場合、［<paramref name="item2"/>］に雑仕入先は登録できません。</returns>
		public static string FI_FA_S10136(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001830"), item1, item2);
		}

		#endregion
		#region FI_GL
		/// <summary>
		/// 入力された決算期と指定の期間が違います。
		/// </summary>

// 		public static readonly string FI_GL_S10001 = "入力された決算期と指定の期間が違います。";
		public static string FI_GL_S10001
		{
			get {return MultiLanguage.Get("CM_AM001314");}
		}

		/// <summary>
		/// 指定の期間は締処理が実行されていません。
		/// </summary>

// 		public static readonly string FI_GL_S10002 = "指定の期間は締処理が実行されていません。";
		public static string FI_GL_S10002
		{
			get {return MultiLanguage.Get("CM_AM001032");}
		}

		/// <summary>
		/// ［%s］ は%sのみ選択可能です。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="value">選択可能項目</param>
		/// <returns>［<paramref name="item"/>］ は<paramref name="value"/>のみ選択可能です。</returns>
		public static string FI_GL_S10003(string item, string value)
		{
// 			return new StringBuilder("［", 32).Append(item).Append("］ は").Append(value).Append("のみ選択可能です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000237")).Append(value).Append(MultiLanguage.Get("CM_AM000624")).ToString();
		}
		/// <summary>
		/// ［%s］ の場合は%sのみ選択可能です。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="value">選択可能項目</param>
		/// <returns>［<paramref name="item"/>］ の場合は<paramref name="value"/>のみ選択可能です。</returns>
		public static string FI_GL_S10004(string item, string value)
		{
// 			return new StringBuilder("［", 32).Append(item).Append("］ の場合は").Append(value).Append("のみ選択可能です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000229")).Append(value).Append(MultiLanguage.Get("CM_AM000624")).ToString();
		}
		/// <summary>
		/// %sのとき%sは指定できません。
		/// </summary>
		/// <param name="condition">条件</param>
		/// <param name="value">選択可能項目</param>
		/// <returns><paramref name="item"/>のとき<paramref name="value"/>は指定できません。</returns>
		public static string FI_GL_S10005(string condition, string value)
		{
// 			return new StringBuilder(condition).Append("のとき").Append(value).Append("は指定できません。").ToString(); 
			return new StringBuilder(condition).Append(MultiLanguage.Get("CM_AM000621")).Append(value).Append(MultiLanguage.Get("CM_AM000641")).ToString();
		}
		/// <summary>
		/// 期間（自）以前の締処理が実行されていません。
		/// </summary>

// 		public static readonly string FI_GL_S10006 = "期間（自）以前の締処理が実行されていません。";
		public static string FI_GL_S10006
		{
			get {return MultiLanguage.Get("CM_AM000836");}
		}

		/// <summary>
		/// 決算期が設定されていないため、当該機能は利用できません。
		/// </summary>

// 		public static readonly string FI_GL_S10007 = "決算期が設定されていないため、当該機能は利用できません。";
		public static string FI_GL_S10007
		{
			get {return MultiLanguage.Get("CM_AM000864");}
		}

		/// <summary>
		/// 指定日から決算期が取得できません。
		/// </summary>

// 		public static readonly string FI_GL_S10008 = "指定日から決算期が取得できません。";
		public static string FI_GL_S10008
		{
			get {return MultiLanguage.Get("CM_AM001034");}
		}

		/// <summary>
		/// 締処理後、伝票入力されている月のデータが含まれています。\n出力しますか？
		/// </summary>

// 		public static readonly string FI_GL_S10009 = @"締処理後、伝票入力されている月のデータが含まれています。\n出力しますか？";
		public static string FI_GL_S10009
		{
			get {return MultiLanguage.Get("CM_AM001260");}
		}

		/// <summary>
		/// 同一ツリー内に勘定科目コード： %s が存在するため指定できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>同一ツリー内に勘定科目コード：  <paramref name="item"/> が存在するため指定できません。</returns>
		public static string FI_GL_S10010(string item)
		{
// 			return new StringBuilder("同一ツリー内に勘定科目コード： ", 64).Append(item).Append(" が存在するため指定できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001275"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000015")).ToString();
		}
		/// <summary>
		/// 指定日から決算期が取得できません。
		/// </summary>

// 		public static readonly string FI_GL_S10011 = "指定した勘定科目コードの下位科目が同一ツリー内に存在するため指定できません。";
		public static string FI_GL_S10011
		{
			get {return MultiLanguage.Get("CM_AM001031");}
		}

		/// <summary>入力された計上日は、伝票入力が禁止されています。
		/// 入力された［%s］ は、［%s］ が禁止されています。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>入力された［<paramref name="item1"/>］ は、［<paramref name="item2"/>］ が禁止されています。</returns>
		public static string FI_GL_S10012(string item1, string item2)
		{
// 			return new StringBuilder("入力された［", 64).Append(item1).Append("］ は、［").Append(item2).Append("］ が禁止されています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001307"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000252")).Append(item2).Append(MultiLanguage.Get("CM_AM000188")).ToString();
		}
		/// <summary>
		/// ［%s］ を設定するには ［%s］ の設定が必須です。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ を登録するには ［<paramref name="item2"/>］ の登録が必須です。</returns>
		public static string FI_GL_S10013(string item1, string item2)
		{
// 			return new StringBuilder("［").Append(item1).Append("］ を設定するには ［").Append(item2).Append("］ の設定が必須です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131")).Append(item1).Append(MultiLanguage.Get("CM_AM000293")).Append(item2).Append(MultiLanguage.Get("CM_AM000231")).ToString();
		}
		/// <summary>
		/// 承認済のため［%s］できません。
		/// <param name="item1">項目名 1</param>
		/// </summary>
		/// <returns>承認済のため［<paramref name="item1"/>］ できません。</returns>
		public static  string FI_GL_S10014(string item1)
		{
// 			return new StringBuilder("承認済のため［").Append(item1).Append("］できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001148")).Append(item1).Append(MultiLanguage.Get("CM_AM000332")).ToString();
		}
		/// <summary>
		/// 経理締処理指示で伝票入力が許可されていないため、［%s］はできません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		public static string FI_GL_S10015(string item1)
		{
// 			return new StringBuilder("経理締処理指示で伝票入力が許可されていないため、［").Append(item1).Append("］はできません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000851")).Append(item1).Append(MultiLanguage.Get("CM_AM000384")).ToString();
		}
		/// <summary>
		/// 遡及締処理後、伝票入力されている月のデータが含まれています。\n出力しますか？
		/// </summary>

// 		public static readonly string FI_GL_S10016 = @"遡及締処理後、伝票入力されている月のデータが含まれています。\n出力しますか？";
		public static string FI_GL_S10016
		{
			get {return MultiLanguage.Get("CM_AM001219");}
		}

		/// <summary>
		/// 締処理及び遡及締処理後、伝票入力されている月のデータが含まれています。\n出力しますか？
		/// </summary>

// 		public static readonly string FI_GL_S10017 = @"締処理及び遡及締処理後、伝票入力されている月のデータが含まれています。\n出力しますか？";
		public static string FI_GL_S10017
		{
			get {return MultiLanguage.Get("CM_AM001259");}
		}

		/// <summary>
		/// 指定の期間は締処理が実行されていません。\n出力しますか？
		/// </summary>

// 		public static readonly string FI_GL_S10018 = @"指定の期間は締処理が実行されていません。\n出力しますか？";
		public static string FI_GL_S10018
		{
			get {return MultiLanguage.Get("CM_AM001033");}
		}

		/// <summary>
		/// ［%s］が不正です。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		public static string FI_GL_S10019(string item1)
		{
			return string.Format(MultiLanguage.Get("CM_AM001646"), item1);
		}

		/// <summary>
		/// %s 行目：［%s］が不正です。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		public static string FI_GL_S10020(string lineNo, string item1)
		{
			return string.Format(MultiLanguage.Get("CM_AM001632"), lineNo, item1);
		}

		/// <summary>
		/// %s 行目：［%s］が控除外課税仕入の場合に［%s］は必須です。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/>行目：［<paramref name="item1"/>］が控除外課税仕入の場合に［<paramref name="item2"/>］は必須です。</returns>
		public static string FI_GL_S10021(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001815"), lineNo, item1, item2);
		}

		/// <summary>
		/// %s 行目：［%s］が控除外課税仕入以外の場合に［%s］に免税事業者仕入は登録できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/>行目：［<paramref name="item1"/>］が控除外課税仕入以外の場合に［<paramref name="item2"/>］に免税事業者仕入は登録できません。</returns>
		public static string FI_GL_S10022(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001816"), lineNo, item1, item2);
		}

		/// <summary>
		/// %s 行目：［%s］に入場券等、自動サービス機または免税事業者仕入を選択時に、［%s］は必須です。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/>行目：［<paramref name="item1"/>］に入場券等、自動サービス機または免税事業者仕入を選択時に、［<paramref name="item2"/>］は必須です。</returns>
		public static string FI_GL_S10023(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001841"), lineNo, item1, item2);
		}

		/// <summary>
		/// %s 行目：［%s］に入場券等、自動サービス機または免税事業者仕入を選択時に、［%s］に雑仕入先は登録できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/>行目：［<paramref name="item1"/>］に入場券等、自動サービス機または免税事業者仕入を選択時に、［<paramref name="item2"/>］に雑仕入先は登録できません。</returns>
		public static string FI_GL_S10024(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001837"), lineNo, item1, item2);
		}

		/// <summary>
		/// ［%s］に入場券等、自動サービス機または免税事業者仕入を選択時に、［%s］に雑仕入先は登録できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="item1"/>に入場券等、自動サービス機または免税事業者仕入を選択時に、<paramref name="item2"/>に雑仕入先は登録できません</returns>
		public static string FI_GL_S10025(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001835"), item1, item2);
		}

		/// <summary>
		/// ［%s］が控除外課税仕入のとき［%s］は免税事業者仕入を選択してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="item1"/>が控除外課税仕入のとき<paramref name="item1"/>は免税事業者仕入を選択してください。</returns>
		public static string FI_GL_S10026(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001834"), item1, item2);
		}

		/// <summary>
		/// %s 行目:［%s］が控除外課税仕入のとき［%s］は免税事業者仕入を選択してください。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/>行目:［<paramref name="item1"/>］が控除外課税仕入のとき［<paramref name="item2"/>］は免税事業者仕入を選択してください。</returns>
		public static string FI_GL_S10027(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001836"), lineNo, item1, item2);
		}

		/// <summary>
		/// ［%s］に入場券等、自動サービス機または免税事業者仕入を選択時に、［%s］は必須です。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］に入場券等、自動サービス機または免税事業者仕入を選択時に、［<paramref name="item2"/>］は必須です。</returns>
		public static string FI_GL_S10028(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001840"), item1, item2);
		}

		/// <summary>
		/// ［%s］が控除外課税仕入の場合に［%s］は必須です。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］が控除外課税仕入の場合に［<paramref name="item2"/>］は必須です。</returns>
		public static string FI_GL_S10029(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001838"), item1, item2);
		}

		/// <summary>
		/// ［%s］が控除外課税仕入以外の場合に［%s］に免税事業者仕入は登録できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］が控除外課税仕入以外の場合に［<paramref name="item2"/>］に免税事業者仕入は登録できません。</returns>
		public static string FI_GL_S10030(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001839"), item1, item2);
		}

		/// <summary>
		/// ［%s］を選択時に［%s］が未入力の場合、帳簿保存の要件を満たせない可能性があります。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］を選択時に［<paramref name="item2"/>］が未入力の場合、帳簿保存の要件を満たせない可能性があります。</returns>
		public static string FI_GL_S10031(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001845"), item1, item2);
		}

		/// <summary>
		/// %s 行目：［%s］を選択時に［%s］が未入力の場合、帳簿保存の要件を満たせない可能性があります。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/> 行目：［<paramref name="item1"/>］を選択時に［<paramref name="item2"/>］が未入力の場合、帳簿保存の要件を満たせない可能性があります。</returns>
		public static string FI_GL_S10032(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001559"), lineNo, FI_GL_S10031(item1, item2));
		}

		/// <summary>
		/// ［%s］を選択時に［%s］が雑仕入先の場合、帳簿保存の要件を満たせない可能性があります。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］を選択時に［<paramref name="item2"/>］が雑仕入先の場合、帳簿保存の要件を満たせない可能性があります。</returns>
		public static string FI_GL_S10033(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001846"), item1, item2);
		}

		/// <summary>
		/// %s 行目：［%s］を選択時に［%s］が雑仕入先の場合、帳簿保存の要件を満たせない可能性があります。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/> 行目：［<paramref name="item1"/>］を選択時に［<paramref name="item2"/>］が雑仕入先の場合、帳簿保存の要件を満たせない可能性があります。</returns>
		public static string FI_GL_S10034(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001559"), lineNo, FI_GL_S10033(item1, item2));
		}

		/// <summary>
		/// ［%s］ は通常科目のみ選択可能です。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="code"/>］ は通常科目のみ選択可能です。</returns>
		public static string FI_GL_01_S01_01(string item)
		{
// 			return new StringBuilder("［", 32).Append(item).Append("］ は通常科目のみ選択可能です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000270")).ToString();
		}
		/// <summary>
		/// ［%s］ は%sのみ選択可能です。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="value">選択可能項目</param>
		/// <returns>［<paramref name="item"/>］ は<paramref name="value"/>のみ選択可能です。</returns>
		public static string FI_GL_01_S01_02(string item, string value)
		{
// 			return new StringBuilder("［", 32).Append(item).Append("］ は").Append(value).Append("のみ選択可能です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000237")).Append(value).Append(MultiLanguage.Get("CM_AM000624")).ToString();
		}
		/// <summary>
		/// ［%s］ の場合は%sのみ選択可能です。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="value">選択可能項目</param>
		/// <returns>［<paramref name="item"/>］ の場合は<paramref name="value"/>のみ選択可能です。</returns>
		public static string FI_GL_01_S01_03(string item, string value)
		{
// 			return new StringBuilder("［", 32).Append(item).Append("］ の場合は").Append(value).Append("のみ選択可能です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000229")).Append(value).Append(MultiLanguage.Get("CM_AM000624")).ToString();
		}
		/// <summary>
		/// 更新しました（ただし、勘定科目の［評価替区分］を［決算仕訳入力区分］の範囲内に修正してください）。
		/// </summary>

// 		public static readonly string FI_GL_01_S01_04 = "更新しました（ただし、勘定科目の［評価替区分］を［決算仕訳入力区分］の範囲内に修正してください）。";
		public static string FI_GL_01_S01_04
		{
			get {return MultiLanguage.Get("CM_AM000904");}
		}

		/// <summary>
		/// ［%s］  が自社マスタの設定値より小さい値に設定されています。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］  が自社マスタの設定値より小さい値に設定されています。</returns>
		public static string FI_GL_01_S01_05(string item)
		{
// 			return new StringBuilder("［", 32).Append(item).Append("］ が自社マスタの設定値より小さい値に設定されています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000194")).ToString();
		}
		/// <summary>
		/// [%S]で使用中のため、貸借区分または、補助科目種別を含めた更新はできません。
		/// </summary>
		public static string FI_GL_01_S03_01(string item)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］ で使用中のため、貸借区分または、補助科目種別を含めた更新はできません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000204")).ToString();
		}
		/// <summary>
		/// コピー元のデータが存在しません。
		/// </summary>

// 		public static readonly string FI_GL_01_S04_01 = "コピー元のデータが存在しません。";
		public static string FI_GL_01_S04_01
		{
			get {return MultiLanguage.Get("CM_AM000558");}
		}

		/// <summary>
		/// 既に補助科目が登録されているためコピーできません。
		/// </summary>

// 		public static readonly string FI_GL_01_S04_02 = "既に補助科目が登録されているためコピーできません。";
		public static string FI_GL_01_S04_02
		{
			get {return MultiLanguage.Get("CM_AM000834");}
		}

		/// <summary>
		/// 下位に集計科目が存在するため、削除できません。
		/// </summary>

// 		public static readonly string FI_GL_01_S07_01 = "下位に集計科目が存在するため、削除できません。";
		public static string FI_GL_01_S07_01
		{
			get {return MultiLanguage.Get("CM_AM000738");}
		}

		/// <summary>
		/// 編集モードに失敗しました。
		/// </summary>

// 		public static readonly string FI_GL_01_S07_02 = "編集モードに失敗しました。";
		public static string FI_GL_01_S07_02
		{
			get {return MultiLanguage.Get("CM_AM001381");}
		}

		/// <summary>
		/// 指定された決算期では四半期指定はできません。
		/// </summary>

// 		public static readonly string FI_GL_01_S10_01 = "指定された決算期では四半期指定はできません。";
		public static string FI_GL_01_S10_01
		{
			get {return MultiLanguage.Get("CM_AM001006");}
		}

		/// <summary>
		/// 指定された決算期では下半期指定はできません。
		/// </summary>

// 		public static readonly string FI_GL_01_S10_02 = "指定された決算期では下半期指定はできません。";
		public static string FI_GL_01_S10_02
		{
			get {return MultiLanguage.Get("CM_AM001005");}
		}

		/// <summary>
		/// 空コードが取得できません。手動でコードを入力してください。
		/// </summary>

// 		public static readonly string FI_GL_01_S14_02 = "空コードが取得できません。手動でコードを入力してください。";
		public static string FI_GL_01_S14_02
		{
			get {return MultiLanguage.Get("CM_AM000848");}
		}

		/// <summary>
		/// 勘定科目が既に登録されています。
		/// </summary>

// 		public static readonly string FI_GL_01_S14_03 = "勘定科目が既に登録されています。";
		public static string FI_GL_01_S14_03
		{
			get {return MultiLanguage.Get("CM_AM000780");}
		}

		/// <summary>
		/// 全ユーザ対象のため、管理用での編集はできません。
		/// </summary>

// 		public static readonly string FI_GL_01_S14_04 = "全ユーザ対象のため、管理用での編集はできません。";
		public static string FI_GL_01_S14_04
		{
			get {return MultiLanguage.Get("CM_AM001211");}
		}

		/// <summary>
		/// ファイルが指定されていません。
		/// </summary>

// 		public static readonly string FI_GL_01_S17_01 = "ファイルが指定されていません。";
		public static string FI_GL_01_S17_01
		{
			get {return MultiLanguage.Get("CM_AM000647");}
		}

		/// <summary>
		/// ファイル形式が正しくありません。
		/// </summary>

// 		public static readonly string FI_GL_01_S17_02 = "ファイル形式が正しくありません。";
		public static string FI_GL_01_S17_02
		{
			get {return MultiLanguage.Get("CM_AM000648");}
		}

		/// <summary>
		/// 指定されたファイルに取込可能なデータが存在しません。
		/// </summary>

// 		public static readonly string FI_GL_01_S17_03 = "指定されたファイルに取込可能なデータが存在しません。";
		public static string FI_GL_01_S17_03
		{
			get {return MultiLanguage.Get("CM_AM001000");}
		}

		/// <summary>
		/// 項目数が不足しているか、不正な項目が存在します。
		/// </summary>

// 		public static readonly string FI_GL_01_S17_04 = "項目数が不足しているか、不正な項目が存在します。";
		public static string FI_GL_01_S17_04
		{
			get {return MultiLanguage.Get("CM_AM000922");}
		}

		/// <summary>
		/// 不正な項目が存在します。
		/// </summary>

// 		public static readonly string FI_GL_01_S17_05 = "不正な項目が存在します。";
		public static string FI_GL_01_S17_05
		{
			get {return MultiLanguage.Get("CM_AM001361");}
		}

		/// <summary>
		/// 連結用勘定科目コードが重複しているため処理されませんでした。\r\nエラー対象コード %s
		/// </summary>
		/// <param name="code">エラー対象コード</param>
		/// <returns>連結用勘定科目コードが重複しているため処理されませんでした。\r\nエラー対象コード <paramref name="code"/></returns>
		public static string FI_GL_01_S17_06(string code)
		{
// 			return new StringBuilder("連結用勘定科目コードが重複しているため処理されませんでした。\r\nエラー対象コード ", 64).Append(code).ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001430"), 64).Append(code).ToString();
		}
		/// <summary>
		/// %d 件が正常に処理されました。
		/// </summary>
		/// <param name="count">件数</param>
		/// <returns><paramref name="count"/> 件が正常に処理されました。</returns>
		public static string FI_GL_01_S17_07(int count)
		{
// 			return new StringBuilder(count.ToString("#,##0")).Append(" 件が正常に処理されました。").ToString(); 
			return new StringBuilder(count.ToString("#,##0")).Append(MultiLanguage.Get("CM_AM000073")).ToString();
		}
		/// <summary>
		/// この伝票の計上日は、伝票入力が禁止されているため修正できません。
		/// </summary>

// 		public static readonly string FI_GL_03_S02_01 = "この伝票の計上日は、伝票入力が禁止されているため修正できません。";
		public static string FI_GL_03_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000556");}
		}

		/// <summary>
		/// 入力された計上日は、伝票入力が禁止されています。
		/// </summary>

// 		public static readonly string FI_GL_03_S02_02 = "入力された計上日は、伝票入力が禁止されています。";
		public static string FI_GL_03_S02_02
		{
			get {return MultiLanguage.Get("CM_AM001313");}
		}

		/// <summary>
		/// 為替差損益行の［通貨コード］が、他の行に存在しません。
		/// </summary>

// 		public static readonly string FI_GL_03_S02_03 = "為替差損益行の［通貨コード］が、他の行に存在しません。";
		public static string FI_GL_03_S02_03
		{
			get {return MultiLanguage.Get("CM_AM000718");}
		}

		/// <summary>
		/// 自社マスタ：［多通貨使用フラグ］が「使用しない」になっています。
		/// </summary>

// 		public static readonly string FI_GL_03_S02_04 = "自社マスタ：［多通貨使用フラグ］が「使用しない」になっています。";
		public static string FI_GL_03_S02_04
		{
			get {return MultiLanguage.Get("CM_AM001068");}
		}

		/// <summary>
		/// ［%s］が不正です。取引日時点で%sが有効かどうか確認してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		public static string FI_GL_03_S02_05(string item1)
		{
			return string.Format(MultiLanguage.Get("CM_AM001639"), item1);
		}

		/// <summary>
		/// %s 行目：［%s］が不正です。取引日時点で%sが有効かどうか確認してください。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		public static string FI_GL_03_S02_06(string lineNo, string item1)
		{
			return string.Format(MultiLanguage.Get("CM_AM001633"), lineNo, item1);
		}

		/// <summary>
		/// ［%s］に入場券等または自動サービス機を選択時に、雑仕入先は登録できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		public static string FI_GL_03_S05_01(string item1)
		{
			return string.Format(MultiLanguage.Get("CM_AM001809"), item1);
		}

		/// <summary>
		/// ［%s］に入場券等または自動サービス機を選択時に、［%s］は必須です。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		public static string FI_GL_03_S05_02(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001810"), item1, item2);
		}

		/// <summary>
		/// ［税区分］が控除外課税仕入の場合に［帳簿控除理由］は必須です。
		/// </summary>
		public static string FI_GL_03_S05_03
		{
			get { return MultiLanguage.Get("CM_AM001811"); }
		}

		/// <summary>
		/// ［税区分］が控除外課税仕入以外の場合に［帳簿控除理由］に免税事業者仕入は登録できません。
		/// </summary>
		public static string FI_GL_03_S05_04
		{
			get { return MultiLanguage.Get("CM_AM001812"); }
		}

		/// <summary>
		/// 定期計上予定が 99 回を越えました。
		/// </summary>

// 		public static readonly string FI_GL_04_S02_01 = "定期計上予定が 99 回を越えました。";
		public static string FI_GL_04_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001257");}
		}

		/// <summary>
		/// 仮仕訳伝票があります。転記処理を行ってください。
		/// </summary>

// 		public static readonly string FI_GL_05_S01_01 = "仮仕訳伝票があります。転記処理を行ってください。";
		public static string FI_GL_05_S01_01
		{
			get {return MultiLanguage.Get("CM_AM000744");}
		}

		/// <summary>
		/// 未承認伝票があります。
		/// </summary>

// 		public static readonly string FI_GL_05_S01_02 = "未承認伝票があります。";
		public static string FI_GL_05_S01_02
		{
			get {return MultiLanguage.Get("CM_AM001395");}
		}

		/// <summary>
		/// 未取込の自動仕訳伝票があります。自動仕訳実行処理を行ってください。
		/// </summary>

// 		public static readonly string FI_GL_05_S01_03 = "未取込の自動仕訳伝票があります。自動仕訳実行処理を行ってください。";
		public static string FI_GL_05_S01_03
		{
			get {return MultiLanguage.Get("CM_AM001388");}
		}

		/// <summary>
		/// 処理を実行しました。締処理履歴を確認して下さい。
		/// </summary>

// 		public static readonly string FI_GL_05_S01_04 = "処理を実行しました。締処理履歴を確認して下さい。";
		public static string FI_GL_05_S01_04
		{
			get {return MultiLanguage.Get("CM_AM001131");}
		}

		/// <summary>
		/// ［%s］で伝票入力が許可されています。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		public static string FI_GL_05_S01_05(string item1)
		{
// 			return new StringBuilder("［").Append(item1).Append("］で伝票入力が許可されています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131")).Append(item1).Append(MultiLanguage.Get("CM_AM000335")).ToString();
		}
		/// <summary>
		/// [%s]で伝票入力が許可されているため処理できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		public static string FI_GL_05_S01_06(string item1)
		{
// 			return new StringBuilder("［").Append(item1).Append("］で伝票入力が許可されているため処理できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131")).Append(item1).Append(MultiLanguage.Get("CM_AM000336")).ToString();
		}
		/// <summary>
		/// [%s]で本締されていないため処理できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		public static string FI_GL_05_S01_07(string item1)
		{
// 			return new StringBuilder("［").Append(item1).Append("］で本締されていないため処理できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131")).Append(item1).Append(MultiLanguage.Get("CM_AM000338")).ToString();
		}
		/// <summary>
		/// [%s]で締処理が実行されていないため処理できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		public static string FI_GL_05_S01_08(string item1)
		{
// 			return new StringBuilder("［").Append(item1).Append("］で締処理が実行されていないため処理できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131")).Append(item1).Append(MultiLanguage.Get("CM_AM000334")).ToString();
		}
		/// <summary>
		/// 新規に締処理の登録が行われているため、処理できません。
		/// </summary>

// 		public static readonly string FI_GL_05_S03_01 = "新規に締処理の登録が行われているため、処理できません。";
		public static string FI_GL_05_S03_01
		{
			get {return MultiLanguage.Get("CM_AM001165");}
		}

		/// <summary>
		/// ［%s］ を登録するには ［%s］ の登録が必須です。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ を登録するには ［<paramref name="item2"/>］ の登録が必須です。</returns>
		public static string FI_GL_05_S06_01(string item1, string item2)
		{
// 			return new StringBuilder("［").Append(item1).Append("］ を登録するには ［").Append(item2).Append("］ の登録が必須です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131")).Append(item1).Append(MultiLanguage.Get("CM_AM000295")).Append(item2).Append(MultiLanguage.Get("CM_AM000235")).ToString();
		}
		/// <summary>
		/// 出力項目が重複しています。
		/// </summary>

// 		public static readonly string FI_GL_05_S06_02 = "出力項目が重複しています。";
		public static string FI_GL_05_S06_02
		{
			get {return MultiLanguage.Get("CM_AM001126");}
		}

		/// <summary>
		/// 既に該当データが登録されています。再登録しますか
		/// </summary>

// 		public static readonly string FI_GL_05_S07_01 = "既に該当データが登録されています。再登録しますか？";
		public static string FI_GL_05_S07_01
		{
			get {return MultiLanguage.Get("CM_AM000785");}
		}

		/// <summary>
		/// 過去データに対する作成処理は出来ません。
		/// </summary>

// 		public static readonly string FI_GL_05_S07_02 = "過去データに対する作成処理は出来ません。";
		public static string FI_GL_05_S07_02
		{
			get {return MultiLanguage.Get("CM_AM000747");}
		}

		/// <summary>
		/// 変動金額が正しく入力されていません。
		/// </summary>

// 		public static readonly string FI_GL_05_S08_01 = "変動金額が正しく入力されていません。";
		public static string FI_GL_05_S08_01
		{
			get {return MultiLanguage.Get("CM_AM001380");}
		}

		/// <summary>
		/// 出力項目（カテゴリ）に同一カテゴリが存在しています。
		/// </summary>

// 		public static readonly string FI_GL_05_S09_01 = "出力項目（カテゴリ）に同一カテゴリが存在しています。";
		public static string FI_GL_05_S09_01
		{
			get {return MultiLanguage.Get("CM_AM001125");}
		}

		/// <summary>
		/// 配賦元勘定科目に指定された集計科目の集計対象となる下位勘定科目に貸借区分が異なるものが含まれているため登録できません。
		/// </summary>

// 		public static readonly string FI_GL_07_S03_01 = "配賦元勘定科目に指定された集計科目の集計対象となる下位勘定科目に貸借区分が異なるものが含まれているため登録できません。";
		public static string FI_GL_07_S03_01
		{
			get {return MultiLanguage.Get("CM_AM001334");}
		}

		/// <summary>
		/// 既に配賦先に%sされた行があるため、%sできません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>既に配賦先に<paramref name="item1"/>された行があるため、<paramref name="item2"/>できません。</returns>
		public static string FI_GL_07_S03_02(string item1, string item2)
		{
// 			return new StringBuilder("既に配賦先に").Append(item1).Append("された行があるため、").Append(item2).Append("できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000827")).Append(item1).Append(MultiLanguage.Get("CM_AM000562")).Append(item2).Append(MultiLanguage.Get("CM_AM000599")).ToString();
		}
		/// <summary>
		/// 既に配賦先にプロジェクトが指定された行があるため、 ［%s］ は選択できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>既に配賦先にプロジェクトが指定された行があるため、 ［<paramref name="item"/>］ は選択できません。</returns>
		public static string FI_GL_07_S03_03(string item)
		{
// 			return new StringBuilder("既に配賦先にプロジェクトが指定された行があるため、 ［", 64).Append(item).Append("］ は選択できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000828"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000268")).ToString();
		}
		/// <summary>
		/// ［%s］ 選択時、 ［%s］ に仕訳伝票プロジェクト入力必須の勘定科目は指定できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ 選択時、［<paramref name="item2"/>］ に仕訳伝票プロジェクト入力必須の勘定科目は指定できません。</returns>
		public static string FI_GL_07_S03_04(string item1, string item2)
		{
// 			return new StringBuilder("［").Append(item1).Append("］ 選択時、［").Append(item2).Append("］ に仕訳伝票プロジェクト入力必須の勘定科目は指定できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131")).Append(item1).Append(MultiLanguage.Get("CM_AM000314")).Append(item2).Append(MultiLanguage.Get("CM_AM000213")).ToString();
		}
		/// <summary>
		/// ［%s］ に仕訳伝票プロジェクト入力必須の勘定科目が指定されたため、 ［%s］ を自動的に変更しました。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ に仕訳伝票プロジェクト入力必須の勘定科目が指定されたため、［<paramref name="item2"/>］  を自動的に変更しました。</returns>
		public static string FI_GL_07_S03_05(string item1, string item2)
		{
// 			return new StringBuilder("［").Append(item1).Append("］に仕訳伝票プロジェクト入力必須の勘定科目が指定されたため、［").Append(item2).Append("］ を自動的に変更しました。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131")).Append(item1).Append(MultiLanguage.Get("CM_AM000347")).Append(item2).Append(MultiLanguage.Get("CM_AM000290")).ToString();
		}
		/// <summary>
		/// 現在の締状況で配賦指示は行えません。
		/// </summary>

// 		public static readonly string FI_GL_07_S06_01 = "現在の締状況で配賦指示は行えません。";
		public static string FI_GL_07_S06_01
		{
			get {return MultiLanguage.Get("CM_AM000886");}
		}

		/// <summary>
		/// 現在の締状況でその月度は指定できません。
		/// </summary>

// 		public static readonly string FI_GL_07_S06_02 = "現在の締状況でその月度は指定できません。";
		public static string FI_GL_07_S06_02
		{
			get {return MultiLanguage.Get("CM_AM000885");}
		}

		/// <summary>
		/// 削除しました（再配賦する場合は月次締処理を行ってください）。
		/// </summary>

// 		public static readonly string FI_GL_07_S06_03 = "削除しました（再配賦する場合は月次締処理を行ってください）。";
		public static string FI_GL_07_S06_03
		{
			get {return MultiLanguage.Get("CM_AM000951");}
		}

		/// <summary>
		/// 指定された決算期では四半期指定はできません。
		/// </summary>

// 		public static readonly string FI_GL_08_S10_01 = "指定された決算期では四半期指定はできません。";
		public static string FI_GL_08_S10_01
		{
			get {return MultiLanguage.Get("CM_AM001006");}
		}

		/// <summary>
		/// 指定された決算期では下半期指定はできません。
		/// </summary>

// 		public static readonly string FI_GL_08_S10_02 = "指定された決算期では下半期指定はできません。";
		public static string FI_GL_08_S10_02
		{
			get {return MultiLanguage.Get("CM_AM001005");}
		}
		/// <summary>
		/// 指定された決算期では%d指定はできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>指定された決算期では<paramref name="item"/>指定はできません。</returns>
		public static string FI_GL_08_S44_01(string item)
		{
			return new StringBuilder("指定された決算期では").Append(item).Append("指定はできません。").ToString();
		}
		/// <summary>
		/// 税区分 “00” は選択できません。
		/// </summary>

// 		public static readonly string FI_GL_08_S20_01 = "税区分 “00” は選択できません。";
		public static string FI_GL_08_S20_01
		{
			get {return MultiLanguage.Get("CM_AM001192");}
		}

		/// <summary>
		/// 出力資料を選択してください。
		/// </summary>

// 		public static readonly string FI_GL_08_S21_01 = "出力資料を選択してください。";
		public static string FI_GL_08_S21_01
		{
			get {return MultiLanguage.Get("CM_AM001127");}
		}

		/// <summary>
		/// [対象月]の決算期が存在しません。
		/// </summary>

// 		public static readonly string FI_GL_10_S05_01 = "[対象月]の決算期が存在しません。";
		public static string FI_GL_10_S05_01
		{
			get {return MultiLanguage.Get("CM_AM000160");}
		}

		/// <summary>
		/// [対象月]においてすでに本締されているため、%dできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>[対象月]においてすでに本締されているため、<paramref name="item"/> できません。</returns>
		public static string FI_GL_10_S05_02(string item)
		{
// 			return new StringBuilder("[対象月]においてすでに本締されているため、").Append(item).Append("できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000159")).Append(item).Append(MultiLanguage.Get("CM_AM000599")).ToString();
		}
		/// <summary>
		///[遡及実施年月]において遡及伝票入力が許可されていないため、%dできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>[遡及実施年月]において遡及伝票入力が許可されていないため、<paramref name="item"/> できません。</returns>
		public static string FI_GL_10_S05_03(string item)
		{
// 			return new StringBuilder("[遡及実施年月]において遡及伝票入力が許可されていないため、").Append(item).Append("できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000158")).Append(item).Append(MultiLanguage.Get("CM_AM000599")).ToString();
		}
		/// <summary>
		/// [対象月]の属する決算期が[遡及実施年月]の属する決算期と同じ、または未来の決算期のため登録できません。
		/// </summary>

// 		public static readonly string FI_GL_10_S05_04 = "[対象月]の属する決算期が[遡及実施年月]の属する決算期と同じ、または未来の決算期のため登録できません。";
		public static string FI_GL_10_S05_04
		{
			get {return MultiLanguage.Get("CM_AM000161");}
		}

		/// <summary>
		/// 指定された部門は現在、［会計予算管理］：しないに設定されています。
		/// </summary>

// 		public static readonly string FI_GL_11_S10001 = "指定された部門は現在、［会計予算管理］：しないに設定されています。";
		public static string FI_GL_11_S10001
		{
			get {return MultiLanguage.Get("CM_AM001027");}
		}

		/// <summary>
		/// 確定状態の予算・見込が存在するため削除できません。
		/// </summary>

// 		public static readonly string FI_GL_11_S03_01 = "確定状態の予算・見込が存在するため削除できません。";
		public static string FI_GL_11_S03_01
		{
			get {return MultiLanguage.Get("CM_AM000777");}
		}

		/// <summary>
		/// ［%s］ ： 入力桁数 %d 桁を超える月が発生しました。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="digit">桁数</param>
		/// <returns>［<paramref name="item"/>］：入力桁数 <paramref name="digit"/> 桁を超える月が発生しました。</returns>
		public static string FI_GL_11_S10002(string item, byte digit)
		{
// 			return new StringBuilder("［", 64).Append(item).Append("］ ：入力桁数 ").Append(digit).Append(" 桁を超える月が発生しました。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000181")).Append(digit).Append(MultiLanguage.Get("CM_AM000067")).ToString();
		}
		/// <summary>
		/// 入力桁数 %d 桁を超える月が発生しました。
		/// </summary>
		/// <param name="digit">桁数</param>
		/// <returns>入力桁数 <paramref name="digit"/> 桁を超える月が発生しました。</returns>
		public static string FI_GL_11_S10003(byte digit)
		{
// 			return new StringBuilder("［", 64).Append("入力桁数 ").Append(digit).Append(" 桁を超える月が発生しました。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(MultiLanguage.Get("CM_AM001322")).Append(digit).Append(MultiLanguage.Get("CM_AM000067")).ToString();
		}

		/// <summary>
		/// 指定されたプロジェクトは現在、［会計予算管理］：しないに設定されています。
		/// </summary>
		public static string FI_GL_11_S10004
		{
			get { return MultiLanguage.Get("CM_AM001769"); }
		}

		/// <summary>
		/// 残高金額が0の場合、振替残金額が0になるように入力して下さい。
		/// </summary>
		public static string FI_GL_14_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001806");}
		}

		/// <summary>
		/// 相手先国に、得意先マスタ・仕入先マスタに未設定の国コードが指定されています。
		/// </summary>

// 		public static readonly string FI_GL_13_S01_01 = "相手先国に、得意先マスタ・仕入先マスタに未設定の国コードが指定されています。";
		public static string FI_GL_13_S01_01
		{
			get {return MultiLanguage.Get("CM_AM001223");}
		}

		/// <summary>
		/// 以下のデータは更新処理中です。
		/// </summary>

// 		public static readonly string FI_GL_15_S03_01 = "以下のデータは更新処理中です。";
		public static string FI_GL_15_S03_01
		{
			get {return MultiLanguage.Get("CM_AM000707");}
		}

		/// <summary>
		/// 相手先国に、得意先マスタ・仕入先マスタに未設定の国コードが指定されています。
		/// </summary>
		public static string FI_GL_15_S03_02
		{
			get {return MultiLanguage.Get("CM_AM001223");}
		}

		/// <summary>
		/// 遡及締処理指示で伝票入力が許可されていないため、%dはできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>遡及締処理指示で伝票入力が許可されていないため、<paramref name="item"/> はできません。</returns>
		public static string FI_GL_16_S02_01(string item)
		{
// 			return new StringBuilder("遡及締処理指示で伝票入力が許可されていないため、").Append(item).Append("はできません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001220")).Append(item).Append(MultiLanguage.Get("CM_AM000637")).ToString();
		}

		/// <summary>
		/// ［%s］が不正です。取引日時点での%sを確認してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		public static string FI_GL_16_S02_02(string item1)
		{
			return string.Format(MultiLanguage.Get("CM_AM001640"), item1);
		}

		/// <summary>
		/// %s 行目：［%s］が不正です。取引日時点での%sを確認してください。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		public static string FI_GL_16_S02_03(string lineNo, string item1)
		{
			return string.Format(MultiLanguage.Get("CM_AM001634"), lineNo, item1);
		}

		/// <summary>
		/// 処理区分が変更されています。実行ボタンより遡及締処理を行って下さい。
		/// </summary>

// 		public static readonly string FI_GL_16_S04_01 = "処理区分が変更されています。実行ボタンより遡及締処理を行って下さい。";
		public static string FI_GL_16_S04_01
		{
			get {return MultiLanguage.Get("CM_AM001133");}
		}

		/// <summary>
		/// 変更前計上月において遡及仕訳伝票が登録されているため、計上月の変更はできません。
		/// </summary>

// 		public static readonly string FI_GL_16_S04_02 = "変更前計上月において遡及仕訳伝票が登録されているため、計上月の変更はできません。";
		public static string FI_GL_16_S04_02
		{
			get {return MultiLanguage.Get("CM_AM001379");}
		}

		/// <summary>
		/// 本決算期と遡及実施年月の属する決算期が異なるため、遡及締処理はできません。
		/// </summary>

// 		public static readonly string FI_GL_16_S04_03 = "本決算期と遡及実施年月の属する決算期が異なるため、遡及締処理はできません。";
		public static string FI_GL_16_S04_03
		{
			get {return MultiLanguage.Get("CM_AM001385");}
		}

		/// <summary>
		/// 削除対象の遡及実施年月において遡及仕訳伝票が登録されているため、削除できません。
		/// </summary>

// 		public static readonly string FI_GL_16_S04_04 = "削除対象の遡及実施年月において遡及仕訳伝票が登録されているため、削除できません。";
		public static string FI_GL_16_S04_04
		{
			get {return MultiLanguage.Get("CM_AM000955");}
		}

		/// <summary>
		/// 既に同じ遡及実施年月で登録されています。
		/// </summary>

// 		public static readonly string FI_GL_16_S04_05 = "既に同じ遡及実施年月で登録されています。";
		public static string FI_GL_16_S04_05
		{
			get {return MultiLanguage.Get("CM_AM000815");}
		}

		/// <summary>
		/// 処理区分が変更されていません。
		/// </summary>

// 		public static readonly string FI_GL_16_S04_06 = "処理区分が変更されていません。";
		public static string FI_GL_16_S04_06
		{
			get {return MultiLanguage.Get("CM_AM001134");}
		}

		/// <summary>
		/// 遡及可能な決算期が存在しないため、登録できません。
		/// </summary>

// 		public static readonly string FI_GL_16_S04_07 = "遡及可能な決算期が存在しないため、登録できません。";
		public static string FI_GL_16_S04_07
		{
			get {return MultiLanguage.Get("CM_AM001217");}
		}




		/// <summary>
		/// %d 件の定期請求申請データを作成しました。
		/// </summary>
		/// <param name="count">データ件数</param>
		/// <returns><paramref name="item"/> 件の定期請求申請データを作成しました。</returns>
		public static string FI_AR_S00001(int count)
		{
// 			return new StringBuilder(count.ToString("#,##0"), 32).Append(" 件の定期請求申請データを作成しました。").ToString(); 
			return new StringBuilder(count.ToString("#,##0"), 32).Append(MultiLanguage.Get("CM_AM000080")).ToString();
		}
		#endregion
		#region FI_MS
		/// <summary>
		/// 入力された ［%s］ は、債権債務伝票入力が禁止されています。
		/// </summary>
		/// <param name="dateItem">日付名</param>
		/// <returns>入力された［<paramref name="dateItem"/>］ は、債権債務伝票入力が禁止されています。</returns>
		public static string FI_MS_S20001(string dateItem)
		{
// 			return new StringBuilder("入力された ［", 64).Append(dateItem).Append("］ は、 債権債務伝票入力が禁止されています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001306"), 64).Append(dateItem).Append(MultiLanguage.Get("CM_AM000251")).ToString();
		}
		/// <summary>
		/// 組織変更対象の伝票の決済は、組織変更データ移行後に行ってください。
		/// </summary>

// 		public static readonly string FI_MS_S20002 = "組織変更対象の伝票の決済は、組織変更データ移行後に行ってください。";
		public static string FI_MS_S20002
		{
			get {return MultiLanguage.Get("CM_AM001214");}
		}

		/// <summary>
		/// %時、%sは使用できません。
		/// </summary>
		/// <param name="item1">項目名１</param>
		/// <param name="item2">項目名２</param>
		public static string FI_MS_S20003(string item1, string item2)
		{
// 			return new StringBuilder(item1).Append("時、").Append(item2).Append("は使用できません。").ToString(); 
			return new StringBuilder(item1).Append(MultiLanguage.Get("CM_AM001063")).Append(item2).Append(MultiLanguage.Get("CM_AM000640")).ToString();
		}
		/// <summary>
		/// 未承認伝票があります。
		/// </summary>

// 		public static readonly string FI_MS_03_S01_01 = "未承認伝票があります。";
		public static string FI_MS_03_S01_01
		{
			get {return MultiLanguage.Get("CM_AM001395");}
		}

		/// <summary>
		/// 処理が実行中、もしくは、スケジュールされています。
		/// </summary>

// 		public static readonly string FI_MS_03_S01_02 = "処理が実行中、もしくは、スケジュールされています。";
		public static string FI_MS_03_S01_02
		{
			get {return MultiLanguage.Get("CM_AM001130");}
		}

		/// <summary>
		/// 営業のみを伝票入力許可することはできません。
		/// </summary>

// 		public static readonly string FI_MS_03_S01_03 = "営業のみを伝票入力許可することはできません。";
		public static string FI_MS_03_S01_03
		{
			get {return MultiLanguage.Get("CM_AM000737");}
		}

		#endregion
		#region FI_XE
		/// <summary>
		/// 請求書フォーム区分
		/// </summary>
		public static string FI_XE_04_R00001
		{
			// 請求書フォーム区分
			get { return MultiLanguage.Get("FI_CS003511"); }
		}

		/// <summary>
		/// サーバー帳票出力エラー：
		/// </summary>
		public static string FI_XE_04_R20001
		{
			// サーバー帳票出力エラー：
			get { return MultiLanguage.Get("FI_CS001415"); }
		}

		/// <summary>
		/// サーバー帳票出力エラー (出力対象データなし)
		/// </summary>
		public static string FI_XE_04_R20002
		{
			// サーバー帳票出力エラー (出力対象データなし)
			get { return MultiLanguage.Get("FI_CS001414"); }
		}
		#endregion
		#endregion

		#region HR
		#region HR_MS
		/// <summary>
		/// ［配偶者手当］がなしのとき、［配偶者手当額］は入力できません。
		/// </summary>

// 		public static readonly string HR_MS_S10001 = "［配偶者手当］がなしのとき、［配偶者手当額］は入力できません。";
		public static string HR_MS_S10001
		{
			get {return MultiLanguage.Get("CM_AM000168");}
		}

		/// <summary>
		/// ［扶養人数 1］ と［扶養手当額 1］ は両方入力してください。
		/// </summary>

// 		public static readonly string HR_MS_S10002 = "［扶養人数 1］ と［扶養手当額 1］ は両方入力してください。";
		public static string HR_MS_S10002
		{
			get {return MultiLanguage.Get("CM_AM000171");}
		}

		/// <summary>
		/// ［扶養人数 2］ と［扶養手当額 2］ は両方入力してください。
		/// </summary>

// 		public static readonly string HR_MS_S10003 = "［扶養人数 1］ と［扶養手当額 2］ は両方入力してください。";
		public static string HR_MS_S10003
		{
			get {return MultiLanguage.Get("CM_AM000172");}
		}

		/// <summary>
		/// ［扶養人数］に矛盾があります。
		/// </summary>

// 		public static readonly string HR_MS_S10004 = "［扶養人数］に矛盾があります。";
		public static string HR_MS_S10004
		{
			get {return MultiLanguage.Get("CM_AM000173");}
		}

		/// <summary>
		/// [%s]より大きい金額を入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］より大きい金額を入力してください。</returns>
		public static string HR_MS_S10005(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］より大きい金額を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000392")).ToString();
		}
		/// <summary>
		/// ［変更不可区分］は、 1 ・ 2 以外エラーです。
		/// </summary>

// 		public static readonly string HR_MS_S10006 = "［変更不可区分］は、 1 ・ 2 以外エラーです。";
		public static string HR_MS_S10006
		{
			get {return MultiLanguage.Get("CM_AM000176");}
		}

		/// <summary>
		/// ［請求用連携詳細コード 1］ と［請求用連携詳細コード 2］ は両方入力してください。
		/// </summary>

// 		public static readonly string HR_MS_S10007 = "［請求用連携詳細コード 1］ と［請求用連携詳細コード 2］ は両方入力してください。";
		public static string HR_MS_S10007
		{
			get {return MultiLanguage.Get("CM_AM000157");}
		}

		/// <summary>
		/// ［配当用連携詳細コード 1］ と［配当用連携詳細コード 2］ は両方入力してください。
		/// </summary>

// 		public static readonly string HR_MS_S10008 = "［配当用連携詳細コード 1］ と［配当用連携詳細コード 2］ は両方入力してください。";
		public static string HR_MS_S10008
		{
			get {return MultiLanguage.Get("CM_AM000169");}
		}

		/// <summary>
		/// ［銀行コード］と［支店コード］は両方入力してください。
		/// </summary>

// 		public static readonly string HR_MS_S10009 = "［銀行コード］と［支店コード］は両方入力してください。";
		public static string HR_MS_S10009
		{
			get {return MultiLanguage.Get("CM_AM000138");}
		}

		/// <summary>
		/// [%s]より小さい金額を入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］より小さい金額を入力してください。</returns>
		public static string HR_MS_S10010(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］より小さい金額を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000391")).ToString();
		}
		/// <summary>
		/// ［%s］の範囲が不正です。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］の範囲が不正です。</returns>
		public static string HR_MS_S10011(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］の範囲が不正です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000379")).ToString();
		}
		/// <summary>
		/// 部門階層が違います。
		/// </summary>

// 		public static readonly string HR_MS_S10012 = "部門階層が違います。";
		public static string HR_MS_S10012
		{
			get {return MultiLanguage.Get("CM_AM001368");}
		}

		/// <summary>
		/// ［配偶者手当］がありのとき、［配偶者手当額］は必須です。
		/// </summary>

// 		public static readonly string HR_MS_S10013 = "［配偶者手当］がありのとき、［配偶者手当額］は必須です。";
		public static string HR_MS_S10013
		{
			get {return MultiLanguage.Get("CM_AM000167");}
		}

		/// <summary>
		/// 既に登録されています。
		/// </summary>

// 		public static readonly string HR_MS_S10014 = "既に登録されています。";
		public static string HR_MS_S10014
		{
			get {return MultiLanguage.Get("CM_AM000813");}
		}

		/// <summary>
		/// ［%s］の金額に矛盾があります。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］の金額に矛盾があります。</returns>
		public static string HR_MS_S10015(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］の金額に矛盾があります。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000365")).ToString();
		}
		/// <summary>
		/// ［%s］以前の日付で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］以前の日付で入力してください。</returns>
		public static string HR_MS_S10016(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］以前の日付で入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000397")).ToString();
		}
		/// <summary>
		/// ［%s］は［%s］より大きい金額を入力してください。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>［<paramref name="item1"/>］は［<paramref name="item2"/>］より大きい金額を入力してください。</returns>
		public static string HR_MS_S10017(string item1, string item2)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］ は ［").Append(item2).Append("］より大きい金額を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000241")).Append(item2).Append(MultiLanguage.Get("CM_AM000392")).ToString();
		}
		/// <summary>
		/// ［%s］は入力できない値です。 
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］は入力できない値です。 </returns>
		public static string HR_MS_S10019(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］は入力できない値です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000388")).ToString();
		}
		/// <summary>
		/// 暦日数選択の時、入力日数は入力できません。 
		/// </summary>

// 		public static readonly string HR_MS_S10020 = "暦日数選択の時、入力日数は入力できません。";
		public static string HR_MS_S10020
		{
			get {return MultiLanguage.Get("CM_AM001429");}
		}

		/// <summary>
		/// ［%s］は入力できません。 
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］は入力できません。  </returns>
		public static string HR_MS_S10021(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］は入力できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000389")).ToString();
		}
		/// <summary>
		/// 処理対象の［%s］が存在しません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>処理対象の ［<paramref name="item"/>］が存在しません。</returns>
		public static string HR_PY_S10001(string item)
		{
// 			return new StringBuilder("処理対象の ［", 32).Append(item).Append("］が存在しません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001135"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000327")).ToString();
		}
		/// <summary>
		/// ［%s］のオープンに失敗しました。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］のオープンに失敗しました。</returns>
		public static string HR_PY_S10002(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］のオープンに失敗しました。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000357")).ToString();
		}
		/// <summary>
		/// データフォーマットが不正です。［%s］の値が適当ではありません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>データフォーマットが不正です。［<paramref name="item"/>］の値が適当ではありません。</returns>
		public static string HR_PY_S10003(string item)
		{
// 			return new StringBuilder("データフォーマットが不正です。［", 32).Append(item).Append("］の値が適当ではありません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000591"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000375")).ToString();
		}
		/// <summary>
		/// データフォーマットが不正です。［%s］の位置が適当ではありません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>データフォーマットが不正です。［<paramref name="item"/>］の位置が適当ではありません。</returns>
		public static string HR_PY_S10004(string item)
		{
// 			return new StringBuilder("データフォーマットが不正です。［", 32).Append(item).Append("］の位置が適当ではありません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000591"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000362")).ToString();
		}
		/// <summary>
		/// ［%s］には［%s］を入力してください。 
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>［<paramref name="item1"/>］には［<paramref name="item2"/>］を入力してください。 </returns>
		public static string HR_PY_S10005(string item1, string item2)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］には［").Append(item2).Append("］を入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000345")).Append(item2).Append(MultiLanguage.Get("CM_AM000395")).ToString();
		}
		/// <summary>
		/// ［%s］が設定されていません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］が設定されていません。</returns>
		public static string HR_MS_S10022(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］が設定されていません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000326")).ToString();
		}
		/// <summary>
		/// ［支給控除詳細］が対象外です。
		/// </summary>

// 		public static readonly string HR_MS_S10023 = "［支給控除詳細］が対象外です。";
		public static string HR_MS_S10023
		{
			get {return MultiLanguage.Get("CM_AM000142");}
		}

		/// <summary>
		/// ［%s］は［%s］以内で入力してください。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>［<paramref name="item1"/>］は［<paramref name="item2"/>］以内で入力してください。 </returns>
		public static string HR_PY_S10006(string item1, string item2)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］は［").Append(item2).Append("］以内で入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000382")).Append(item2).Append(MultiLanguage.Get("CM_AM000400")).ToString();
		}
		/// <summary>
		/// ［%s］は［%s］の［%s］で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="item3">項目名 3</param>
		/// <returns>［<paramref name="item1"/>］は［<paramref name="item2"/>］の［<paramref name="item3"/>］で入力してください。</returns>
		public static string HR_PY_S10007(string item1, string item2, string item3)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］は［").Append(item2).Append("］の［").Append(item3).Append("］で入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000382")).Append(item2).Append(MultiLanguage.Get("CM_AM000352")).Append(item3).Append(MultiLanguage.Get("CM_AM000337")).ToString();
		}
		/// <summary>
		/// ［%s］が実行されていません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］が実行されていません。</returns>
		public static string HR_MS_S10024(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］が実行されていません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000325")).ToString();
		}
		/// <summary>
		/// ［%s］［%s］の定義が不正です。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>［<paramref name="item1"/>］［<paramref name="item2"/>］の定義が不正です。</returns>
		public static string HR_MS_S10025(string item1, string item2)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］［").Append(item2).Append("］の定義が不正です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000318")).Append(item2).Append(MultiLanguage.Get("CM_AM000376")).ToString();
		}
		/// <summary>
		/// ［%s］は［%s］ 以前の日付で入力してください。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>［<paramref name="item1"/>］は［<paramref name="item2"/>］ 以前の日付で入力してください。 </returns>
		public static string HR_MS_S10026(string item1, string item2)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］は［").Append(item2).Append("］ 以前の日付で入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000382")).Append(item2).Append(MultiLanguage.Get("CM_AM000311")).ToString();
		}
		/// <summary>
		/// ［%s］に 0 は入力できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］に 0 は入力できません。</returns>
		public static string HR_MS_S10027(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］に 0 は入力できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000341")).ToString();
		}
		/// <summary>
		/// ［%s］は %s］ 以降の年月で入力してください。 
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>［<paramref name="item1"/>］は［<paramref name="item2"/>］ 以降の年月で入力してください。  </returns>
		public static string HR_MS_S10028(string item1, string item2)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］は［").Append(item2).Append("］ 以降の年月で入力してください。 ").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000382")).Append(item2).Append(MultiLanguage.Get("CM_AM000305")).ToString();
		}
		/// <summary>
		/// %s が異なる［%s］が複数指定されています。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns><paramref name="item1"/> が異なる［<paramref name="item2"/>］ が複数指定されています。  </returns>
		public static string HR_MS_S10029(string item1, string item2)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］が異なる［").Append(item2).Append("］ が複数指定されています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000324")).Append(item2).Append(MultiLanguage.Get("CM_AM000197")).ToString();
		}
		/// <summary>
		/// この %s は %s できません。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>この <paramref name="item1"/> は <paramref name="item2"/> できません。</returns>
		public static string HR_MS_S10030(string item1, string item2)
		{
// 			return new StringBuilder("この ", 32).Append(item1).Append(" は ").Append(item2).Append(" できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000536"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000035")).Append(item2).Append(MultiLanguage.Get("CM_AM000018")).ToString();
		}
		/// <summary>
		/// %s 行目： %s のとき、［%s］は指定できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名1</param>
		///  <param name="item2">項目名2</param>
		/// <returns><paramref name="lineNo"/> 行目：  <paramref name="item1"/>  のとき、［<paramref name="item2"/>］は指定できません。</returns>
		public static string HR_MS_S10031(string lineNo,string item1,string item2)
		{
// 			return new StringBuilder(lineNo, 64).Append(" 行目： ").Append(item1).Append("のとき、[").Append(item2).Append("] は指定できません。").ToString(); 
			return new StringBuilder(lineNo, 64).Append(MultiLanguage.Get("CM_AM000089")).Append(item1).Append(MultiLanguage.Get("CM_AM000623")).Append(item2).Append(MultiLanguage.Get("CM_AM000264")).ToString();
		}
		/// <summary>
		/// 表［%s］に対する%s権限がありません。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>表[<paramref name="item1"/>]に対する<paramref name="item2"/>権限がありません。</returns>
		public static string HR_MS_S10032(string item1,string item2)
		{
// 			return new StringBuilder("表［", 64).Append(item1).Append("］に対する").Append(item2).Append("権限がありません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001358"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000349")).Append(item2).Append(MultiLanguage.Get("CM_AM000874")).ToString();
		}
		/// <summary>
		/// 表［%s］に%sを設定してください。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>表[<paramref name="item1"/>]に<paramref name="item2"/>を設定してください。</returns>
		public static string HR_MS_S10033(string item1,string item2)
		{
// 			return new StringBuilder("表［", 64).Append(item1).Append("］に").Append(item2).Append("を設定してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001358"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000340")).Append(item2).Append(MultiLanguage.Get("CM_AM000701")).ToString();
		}
		/// <summary>
		/// 使用テーブルは%s個以内で設定してください。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <returns>使用テーブルは<paramref name="item1"/>個以内で設定してください。</returns>
		public static string HR_MS_S10034(string item1)
		{
// 			return new StringBuilder("使用テーブルは", 64).Append(item1).Append("個以内で設定してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000995"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000889")).ToString();
		}
		/// <summary>
		/// 検索結果件数が上限値を超えています。条件を絞り込むか、検索対象テーブルを減らしてください。
		/// </summary>
		/// <returns>検索結果件数が上限値を超えています。条件を絞り込むか、検索対象テーブルを減らしてください。</returns>
		public static string HR_MS_S10035()
		{
// 			return new StringBuilder("検索結果件数が上限値を超えています。条件を絞り込むか、検索対象テーブルを減らしてください。", 64).ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000870"), 64).ToString();
		}
		/// <summary>
		/// 検索時間が上限値を超えています。条件を絞り込むか、検索対象テーブルを減らしてください。
		/// </summary>
		/// <returns>検索時間が上限値を超えています。条件を絞り込むか、検索対象テーブルを減らしてください。</returns>
		public static string HR_MS_S10036()
		{
// 			return new StringBuilder("検索時間が上限値を超えています。条件を絞り込むか、検索対象テーブルを減らしてください。", 64).ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000872"), 64).ToString();
		}
		/// <summary>
		/// 
		/// </summary>
		/// <returns>マスタテーブルに権限設定を使用するテーブルは連結できません。</returns>
		public static string HR_MS_S10037()
		{
// 			return new StringBuilder("マスタテーブルに権限設定を使用するテーブルは連結できません。", 64).ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000666"), 64).ToString();
		}
		/// <summary>
		/// 取込に失敗しました。（エラーリスト有）
		/// </summary>

// 		public static readonly string HR_MS_S10038 = "取込に失敗しました。（エラーリスト有）";		
		public static string HR_MS_S10038
		{
			get {return MultiLanguage.Get("CM_AM001095");}
		}

		/// <summary>
		/// 実行しました。（エラーリスト有）
		/// </summary>

// 		public static readonly string HR_MS_S10039 = "実行しました。（エラーリスト有）";		
		public static string HR_MS_S10039
		{
			get {return MultiLanguage.Get("CM_AM001078");}
		}

		/// <summary>
		/// 取込に失敗しました。
		/// </summary>

// 		public static readonly string HR_MS_S10040 = "取込に失敗しました。";		
		public static string HR_MS_S10040
		{
			get {return MultiLanguage.Get("CM_AM001094");}
		}

		/// <summary>
		/// 人事モジュール及び給与モジュールの両方がインストールされている時、当該機能が利用できます。
		/// </summary>

// 		public static readonly string HR_MS_S10041 = "人事モジュール及び給与モジュールの両方がインストールされている時、当該機能が利用できます。";		
		public static string HR_MS_S10041
		{
			get {return MultiLanguage.Get("CM_AM001174");}
		}

		/// <summary>
		/// ［%s］の対象者ではありません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>　<paramref name="item"/>の対象者ではありません。</returns>
		public static string HR_MS_S10042(string item)
		{			
// 			return new StringBuilder("［", 64).Append(item).Append("］の対象者ではありません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 64).Append(item).Append(MultiLanguage.Get("CM_AM000374")).ToString();
		}
		/// <summary>
		/// ［支給日］に銀行休日が指定されています。登録しますか？
		/// </summary>

// 		public static readonly string HR_MS_S10043 = "［支給日］に銀行休日が指定されています。登録しますか？";
		public static string HR_MS_S10043
		{
			get {return MultiLanguage.Get("CM_AM000144");}
		}

		/// <summary>
		/// %sの［%s］ は、 %s ～ %s の範囲で入力してください。
		/// </summary>
		/// <param name="value">値</param>
		/// <param name="item">項目名</param>
		/// <param name="minValue">最小値</param>
		/// <param name="maxValue">最大値</param>
		/// <returns><paramref name="value"/> の ［<paramref name="item"/>］ は、 <paramref name="minValue"/> ～ <paramref name="maxValue"/> の範囲で入力してください。</returns>
		public static string HR_MS_S10044(string value, string item, string minValue, string maxValue)
		{
// 			return new StringBuilder(value, 64).Append(" の ［").Append(item).Append("］ は、 ").Append(minValue).Append(" ～ ").Append(maxValue).Append(" の範囲で入力してください。").ToString(); 
			return new StringBuilder(value, 64).Append(MultiLanguage.Get("CM_AM000025")).Append(item).Append(MultiLanguage.Get("CM_AM000249")).Append(minValue).Append(MultiLanguage.Get("CM_AM000011")).Append(maxValue).Append(MultiLanguage.Get("CM_AM000033")).ToString();
		}
        /// <summary>
        /// ［計算単位］が%sで、支給体系条件マスタに複数の給与支給日が設定されています。
        /// </summary>
        /// <param name="group">給与計算方法区分</param>
        /// <returns>［計算単位］が<paramref name="group"/>で、支給体系条件マスタに複数の給与支給日が設定されています。</returns>
        public static string HR_MS_S10045(string group)
        {
//          return new StringBuilder("［計算単位］が").Append(group).Append("で、支給体系条件マスタに複数の給与支給日が設定されています。").ToString(); 
            return new StringBuilder(MultiLanguage.Get("CM_AM000139")).Append(group).Append(MultiLanguage.Get("CM_AM000589")).ToString();
        }
        /// <summary>
        /// ［計算単位］が%sで、支給体系条件マスタに給与支給日の当月と翌月が混在して設定されています。
        /// </summary>
        /// <param name="group">給与計算方法区分</param>
        /// <returns>［計算単位］が<paramref name="group"/>で、支給体系条件マスタに給与支給日の当月と翌月が混在して設定されています。</returns>
        public static string HR_MS_S10046(string group)
        {
//          return new StringBuilder("［計算単位］が").Append(group).Append("で、支給体系条件マスタに給与支給日の当月と翌月が混在して設定されています。").ToString(); 
            return new StringBuilder(MultiLanguage.Get("CM_AM000139")).Append(group).Append(MultiLanguage.Get("CM_AM000588")).ToString();
        }
		#endregion

		/// <summary>
		/// 同一の適用年月を持つ退職金税額表テーブルが存在します。
		/// </summary>
		public static readonly string HR_MS_S10047 = "同一の適用年月を持つ退職金税額表テーブルが存在します。";

		/// <summary>
		/// %s 行目： ［%s］は重複しないように入力してください。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="lineNo"/> 行目：<paramref name="item"/>は重複しないように入力してください。</returns>
		public static string HR_MS_S10048(string lineNo, string item)
		{
			return new StringBuilder(lineNo, 64).Append(" 行目： ［").Append(item).Append("］は重複しないように入力してください。").ToString(); 
		}

		/// <summary>
		/// 個人番号情報が登録されているため削除できません。
		/// </summary>
		public static string HR_MS_S10049
		{
			get { return MultiLanguage.Get("CM_AM001706"); }
		}

		#region HR_PA
		/// <summary>
		/// ［異動区分］が［%s］のとき、［異動日］は変更できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［異動区分］が［<paramref name="item"/>］のとき、［異動日］は変更できません。</returns>
		public static string HR_PA_S10001(string item)
		{
// 			return new StringBuilder("［異動区分］が［", 32).Append(item).Append("］のとき、［異動日］は変更できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000133"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000359")).ToString();
		}
		/// <summary>
		/// ［異動区分］が［%s］のとき、［%s］以前は削除できません。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>［異動区分］が［<paramref name="item1"/>］のとき、［<paramref name="item2"/>］以前は削除できません。 </returns>
		public static string HR_PA_S10002(string item1, string item2)
		{
// 			return new StringBuilder("［異動区分］が［", 32).Append(item1).Append("］のとき、［").Append(item2).Append("］以前は削除できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000133"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000358")).Append(item2).Append(MultiLanguage.Get("CM_AM000398")).ToString();
		}
		/// <summary>
		/// ［%s］のいずれかを選択して下さい。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］のいずれかを選択して下さい。</returns>
		public static string HR_PA_S10003(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］のいずれかを選択して下さい。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000355")).ToString();
		}
		/// <summary>
		/// ［入社日］以前の［異動日］は入力できません。
		/// </summary>

// 		public static readonly string HR_PA_S10004 = "［入社日］以前の［異動日］は入力できません。";
		public static string HR_PA_S10004
		{
			get {return MultiLanguage.Get("CM_AM000166");}
		}

		/// <summary>
		/// ［%s］中につき、現在の処理は実行できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］中につき、現在の処理は実行できません。</returns>
		public static string HR_PA_S10005(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］中につき、現在の処理は実行できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000405")).ToString();
		}
		/// <summary>
		/// ［異動区分］が［%s］のとき、［%s］以前は追加できません。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>［異動区分］が［<paramref name="item1"/>］のとき、［<paramref name="item2"/>］以前は追加できません。</returns>
		public static string HR_PA_S10006(string item1, string item2)
		{
// 			return new StringBuilder("［異動区分］が［", 32).Append(item1).Append("］のとき、［").Append(item2).Append("］以前は追加できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000133"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000358")).Append(item2).Append(MultiLanguage.Get("CM_AM000399")).ToString();
		}
		/// <summary>
		/// 未在籍中の為、現在の処理は実行できません。
		/// </summary>

// 		public static readonly string HR_PA_S10007 = "未在籍中の為、現在の処理は実行できません。";
		public static string HR_PA_S10007
		{
			get {return MultiLanguage.Get("CM_AM001387");}
		}

		/// <summary>
		/// 既に在籍中の為、現在の処理は実行できません。
		/// </summary>

// 		public static readonly string HR_PA_S10008 = "既に在籍中の為、現在の処理は実行できません。";
		public static string HR_PA_S10008
		{
			get {return MultiLanguage.Get("CM_AM000786");}
		}

		/// <summary>
		/// %s状態でない為、現在の処理は実行できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="item"/>状態でない為、現在の処理は実行できません。</returns>
		public static string HR_PA_S10009(string item)
		{			
// 			return new StringBuilder(item, 32).Append("状態でない為、現在の処理は実行できません。").ToString(); 
			return new StringBuilder(item, 32).Append(MultiLanguage.Get("CM_AM001163")).ToString();
		}
		/// <summary>
		/// ［%s］入力時に、［%s］か［%s］は必須です。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="item3">項目名 3</param>
		/// <returns>［<paramref name="item1"/>］入力時に、［<paramref name="item2"/>］か［<paramref name="item3"/>］は必須です。</returns>
		public static string HR_PA_S10010(string item1, string item2, string item3)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］入力時に、［").Append(item2).Append("］か［").Append(item3).Append("］は必須です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000406")).Append(item2).Append(MultiLanguage.Get("CM_AM000321")).Append(item3).Append(MultiLanguage.Get("CM_AM000390")).ToString();
		}
		/// <summary>
		/// ［%s］と［%s］の間に、重複している期間があります。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>［<paramref name="item1"/>］と［<paramref name="item2"/>］の間に、重複している期間があります。</returns>
		public static string HR_PA_S10011(string item1, string item2)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］と［").Append(item2).Append("］の間に、重複している期間があります。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000339")).Append(item2).Append(MultiLanguage.Get("CM_AM000364")).ToString();
		}
		/// <summary>
		/// ［異動区分］が［%s］のとき［異動日］と［入社日］は同じ日付を指定してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［異動区分］が［<paramref name="item"/>］のとき［異動日］と［入社日］は同じ日付を指定してください。</returns>
		public static string HR_PA_S10012(string item)
		{
// 			return new StringBuilder("［異動区分］が［", 32).Append(item).Append("］のとき［異動日］と［入社日］は同じ日付を指定してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000133"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000361")).ToString();
		}
		/// <summary>
		/// ［%s］のいずれかを入力して下さい。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］のいずれかを入力して下さい。</returns>
		public static string HR_PA_S10013(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］のいずれかを入力して下さい。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000356")).ToString();
		}
		/// <summary>
		/// ［%s］が複数指定されています。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］が複数指定されています。</returns>
		public static string HR_PA_S10014(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］が複数指定されています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000328")).ToString();
		}
		/// <summary>
		/// 登録できません。
		/// </summary>

// 		public static readonly string HR_PA_S10015 = "登録できません。";
		public static string HR_PA_S10015
		{
			get {return MultiLanguage.Get("CM_AM001268");}
		}

		/// <summary>
		/// \v算出不可
		/// </summary>

// 		public static readonly string HR_PA_S10016 = "\v算出不可";
		public static string HR_PA_S10016
		{
			get {return MultiLanguage.Get("CM_AM000426");}
		}


		/// <summary>
		/// ［%s］ と ［%s］ と ［%s］の組合せが不正です。 
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="item3">項目名 3</param>
		/// <returns>［<paramref name="item1"/>］と［<paramref name="item2"/>］と［<paramref name="item3"/>］の組合せが不正です。</returns>
		public static string HR_PA_S10017(string item1, string item2, string item3)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］と［").Append(item2).Append("］と［").Append(item3).Append("］の組合せが不正です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000339")).Append(item2).Append(MultiLanguage.Get("CM_AM000339")).Append(item3).Append(MultiLanguage.Get("CM_AM000373")).ToString();
		}
		/// <summary>
		/// [%s]が[%s]のとき、[%s]は[%s]を選択してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <param name="item3">項目名 3</param>
		/// <param name="item4">項目名 4</param>
		/// <returns>［<paramref name="item1"/>］が［<paramref name="item2"/>］のとき、［<paramref name="item3"/>］は［<paramref name="item4"/>］を選択してください。</returns>
		public static string HR_PA_S10018(string item1, string item2, string item3, string item4)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］が［").Append(item2).Append("］のとき、［").Append(item3).Append("］は［").Append(item4).Append("］を選択してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000322")).Append(item2).Append(MultiLanguage.Get("CM_AM000358")).Append(item3).Append(MultiLanguage.Get("CM_AM000382")).Append(item4).Append(MultiLanguage.Get("CM_AM000394")).ToString();
		}

		/// <summary>
		/// ［支給体系］が［%s］のとき［%s］は登録できません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［支給体系］が［<paramref name="item1"/>］のとき［<paramref name="item2"/>］は登録できません。</returns>
		public static string HR_PA_S10019(string item1, string item2)
		{
// 			return new StringBuilder("［支給体系］が［", 32).Append(item1).Append("］のとき［").Append(item2).Append("］は登録できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000143"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000360")).Append(item2).Append(MultiLanguage.Get("CM_AM000386")).ToString();
		}
		/// <summary>
		/// ［異動日］%s ： ［%s］ は変更必須です。
		/// </summary>
		/// <param name="item1">異動日</param>
		/// <param name="item2">項目名</param>
		/// <returns>[異動日]<paramref name="item1"/> ： ［<paramref name="item2"/>］ は変更必須です。</returns>
		public static string HR_PA_S10020(string item1, string item2)
		{
// 			return new StringBuilder("[異動日]", 64).Append(item1).Append("： ［").Append(item2).Append("］ は変更必須です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000135"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000130")).Append(item2).Append(MultiLanguage.Get("CM_AM000281")).ToString();
		}
		/// <summary>
		/// ［異動日］%s ： ［%s］ は変更不可です。
		/// </summary>
		/// <param name="item1">異動日</param>
		/// <param name="item2">項目名</param>
		/// <returns>[異動日]<paramref name="item1"/> ： ［<paramref name="item2"/>］ は変更不可です。</returns>
		public static string HR_PA_S10021(string item1, string item2)
		{
// 			return new StringBuilder("[異動日]", 64).Append(item1).Append("： ［").Append(item2).Append("］ は変更不可です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000135"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000130")).Append(item2).Append(MultiLanguage.Get("CM_AM000283")).ToString();
		}
		/// <summary>
		/// ［異動日］%s ： ［%s］ が未設定のため更新できません。
		/// </summary>
		/// <param name="item1">異動日</param>
		/// <param name="item2">項目名</param>
		/// <returns>[異動日]<paramref name="item1"/> ： ［<paramref name="item2"/>］ が未設定のため更新できません。</returns>
		public static string HR_PA_S10022(string item1, string item2)
		{
// 			return new StringBuilder("[異動日]", 64).Append(item1).Append("： ［").Append(item2).Append("］ が未設定のため更新できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000135"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000130")).Append(item2).Append(MultiLanguage.Get("CM_AM000201")).ToString();
		}
		/// <summary>
		/// ［異動日］%s ： ［%s］ は変更必須です。([異動履歴情報登録画面]にてご確認ください。)
		/// </summary>
		/// <param name="item1">異動日</param>
		/// <param name="item2">項目名</param>
		/// <returns>[異動日]<paramref name="item1"/> ： ［<paramref name="item2"/>］ は変更必須です。</returns>
		public static string HR_PA_S10023(string item1, string item2)
		{
// 			return new StringBuilder("[異動日]", 64).Append(item1).Append("： ［").Append(item2).Append("］ は変更必須です。([異動履歴情報登録画面]にてご確認ください。)").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000135"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000130")).Append(item2).Append(MultiLanguage.Get("CM_AM000282")).ToString();
		}
		/// <summary>
		/// ［異動日］%s ： ［%s］ は変更不可です。([異動履歴情報登録画面]にてご確認ください。)
		/// </summary>
		/// <param name="item1">異動日</param>
		/// <param name="item2">項目名</param>
		/// <returns>[異動日]<paramref name="item1"/> ： ［<paramref name="item2"/>］ は変更不可です。</returns>
		public static string HR_PA_S10024(string item1, string item2)
		{
// 			return new StringBuilder("[異動日]", 64).Append(item1).Append("： ［").Append(item2).Append("］ は変更不可です。([異動履歴情報登録画面]にてご確認ください。)").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000135"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000130")).Append(item2).Append(MultiLanguage.Get("CM_AM000284")).ToString();
		}
		/// <summary>
		/// ［異動区分］の組合せが不正です。
		/// </summary>
		/// <returns>［異動区分］の組合せが不正です。</returns>
		public static string HR_PA_S10025()
		{
// 			return new StringBuilder("［異動区分］の組合せが不正です。", 64).ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000134"), 64).ToString();
		}
		/// <summary>
		/// 異動履歴情報に矛盾が生じるため更新できません。
		/// </summary>
		/// <returns>異動履歴情報に矛盾が生じるため更新できません。</returns>
		public static string HR_PA_S10026()
		{
// 			return new StringBuilder("異動履歴情報に矛盾が生じるため更新できません。", 64).ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000721"), 64).ToString();
		}

		/// <summary>
		/// ［異動日］%s ： ［%s］ は必須です。
		/// </summary>
		/// <param name="item1">異動日</param>
		/// <param name="item2">項目名</param>
		/// <returns>[異動日]<paramref name="item1"/> ： ［<paramref name="item2"/>］ は必須です。</returns>
		public static string HR_PA_S10027(string item1, string item2)
		{
// 			return new StringBuilder("[異動日]", 64).Append(item1).Append("： ［").Append(item2).Append("］ は必須です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000135"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000130")).Append(item2).Append(MultiLanguage.Get("CM_AM000277")).ToString();
		}
		/// <summary>
		/// ［異動日］%s ： ［%s］ は必須です。([異動履歴情報登録画面]にてご確認ください。)
		/// </summary>
		/// <param name="item1">異動日</param>
		/// <param name="item2">項目名</param>
		/// <returns>[異動日]<paramref name="item1"/> ： ［<paramref name="item2"/>］ は必須です。</returns>
		public static string HR_PA_S10028(string item1, string item2)
		{
// 			return new StringBuilder("[異動日]", 64).Append(item1).Append("： ［").Append(item2).Append("］ は必須です。([異動履歴情報登録画面]にてご確認ください。)").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000135"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000130")).Append(item2).Append(MultiLanguage.Get("CM_AM000279")).ToString();
		}
		#endregion
		#region HR_PY
		/// <summary>
		/// ［%s］は［%s］以前で入力してください。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>［<paramref name="item1"/>］は［<paramref name="item2"/>］以前で入力してください。 </returns>
		public static string HR_PY_S10008(string item1, string item2)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］は［").Append(item2).Append("］以前で入力してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000382")).Append(item2).Append(MultiLanguage.Get("CM_AM000396")).ToString();
		}
		/// <summary>
		/// ［%s］に矛盾があります。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］に矛盾があります。</returns>
		public static string HR_PY_S10009(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］に矛盾があります。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000350")).ToString();
		}
		/// <summary>
		/// %s年の有給繰越処理は既に実行済です。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="item"/>年の有給繰越処理は既に実行済です。</returns>
		public static string HR_PY_S10010(string item)
		{			
// 			return new StringBuilder(item, 32).Append("年の有給繰越処理は既に実行済です。").ToString(); 
			return new StringBuilder(item, 32).Append(MultiLanguage.Get("CM_AM001326")).ToString();
		}
		/// <summary>
		/// ［%s］の入力内容が不正です。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］の入力内容が不正です。</returns>
		public static string HR_PY_S10011(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］の入力内容が不正です。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000378")).ToString();
		}
		/// <summary>
		/// ［%s］処理を開始しました。［%s］にて確認してください。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>［<paramref name="item1"/>］処理を開始しました。［<paramref name="item2"/>］にて確認してください。 </returns>
		public static string HR_PY_S10012(string item1, string item2)
		{
// 			return new StringBuilder("［", 32).Append(item1).Append("］処理を開始しました。［").Append(item2).Append("］にて確認してください。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item1).Append(MultiLanguage.Get("CM_AM000403")).Append(item2).Append(MultiLanguage.Get("CM_AM000344")).ToString();
		}
		/// <summary>
		/// ［%s］処理を開始しました。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［<paramref name="item"/>］処理を開始しました。</returns>
		public static string HR_PY_S10013(string item)
		{			
// 			return new StringBuilder("［", 32).Append(item).Append("］処理を開始しました。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000402")).ToString();
		}
		/// <summary>
		/// 60進法の時は小数点以下.60～.99は入力できません。
		/// </summary>

// 		public static readonly string HR_PY_S10014 = "60進法の時は小数点以下.60～.99は入力できません。";
		public static string HR_PY_S10014
		{
			get {return MultiLanguage.Get("CM_AM000430");}
		}

		/// <summary>
		/// ［社員番号］%s［氏名］%s さんは、%sされていません。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <param name="item3">項目名3</param>
		/// <returns>［社員番号］<paramref name="item1"/>［氏名］<paramref name="item2"/>さんは、<paramref name="item3"/>されていません。</returns>
		public static string HR_PY_S10015(string item1, string item2, string item3)
		{
// 			return new StringBuilder("［社員番号］", 64).Append(item1).Append("［氏名］").Append(item2).Append("さんは、").Append(item3).Append("されていません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000147"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000145")).Append(item2).Append(MultiLanguage.Get("CM_AM000572")).Append(item3).Append(MultiLanguage.Get("CM_AM000567")).ToString();
		}
		/// <summary>
		/// ［社員番号］%s［氏名］%s さんは、%sが終了していない為、実行できません。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <param name="item3">項目名3</param>
		/// <returns>［社員番号］<paramref name="item1"/>［氏名］<paramref name="item2"/>さんは、<paramref name="item3"/>が終了していない為、実行できません。</returns>
		public static string HR_PY_S10016(string item1, string item2, string item3)
		{
// 			return new StringBuilder("［社員番号］", 64).Append(item1).Append("［氏名］").Append(item2).Append("さんは、").Append(item3).Append("が終了していない為、実行できません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000147"), 64).Append(item1).Append(MultiLanguage.Get("CM_AM000145")).Append(item2).Append(MultiLanguage.Get("CM_AM000572")).Append(item3).Append(MultiLanguage.Get("CM_AM000527")).ToString();
		}
		/// <summary>
		/// ［%s］ は%sで設定されています。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="value">登録場所</param>
		/// <returns>［<paramref name="item"/>］ は<paramref name="value"/>で設定されています。</returns>
		public static string HR_PY_S10017(string item, string value)
		{
// 			return new StringBuilder("［", 32).Append(item).Append("］ は").Append(value).Append("で設定されています。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(item).Append(MultiLanguage.Get("CM_AM000237")).Append(value).Append(MultiLanguage.Get("CM_AM000604")).ToString();
		}
		/// <summary>
		/// 入力された ［%s］ は、伝票入力が禁止されています。
		/// </summary>
		/// <param name="dateName">日付名</param>
		/// <returns>入力された［<paramref name="dateItem"/>］ は、伝票入力が禁止されています。</returns>
		public static string HR_PY_S10018(string dateName)
		{
			return new StringBuilder("入力された[", 64).Append(dateName).Append("］ は、伝票入力が禁止されています。").ToString();
		}

		/// <summary>
		/// 同一の社員番号を持つ退職金実績が既に存在します。
		/// </summary>
		public static string HR_PY_S10019
		{
			get { return "同一の社員番号を持つ退職金実績が既に存在します。"; }
		}

		/// <summary>
		/// 支給体系に対応する退職金コントロールマスタが存在しません。
		/// </summary>
		public static string HR_PY_S10020
		{
			get { return "支給体系に対応する退職金コントロールマスタが存在しません。"; }
		}
		/// <summary>
		/// 差引支払額がマイナスになっています。
		/// </summary>
		public static string HR_PY_S10021
		{
			get { return "差引支払額がマイナスになっています。"; }
		}
		/// <summary>
		/// 振込額が変更されました。銀行振込データ作成済みのため、ご確認ください。
		/// </summary>
		public static string HR_PY_S10022
		{
			get { return "振込額が変更されました。銀行振込データ作成済みのため、ご確認ください。"; }
		}
		/// <summary>
		/// 銀行振込データ作成済みです。ご確認ください。
		/// </summary>
		public static string HR_PY_S10023
		{
			get { return "銀行振込データ作成済みです。ご確認ください。"; }
		}
		/// <summary>
		/// 退職履歴が変更されました。入社日を選択してください。
		/// </summary>
		public static string HR_PY_S10024
		{
			get { return "入社履歴または退職履歴が変更されました。"; }
		}
		/// <summary>
		/// [%s]が未設定の場合、[%s]は設定できません。
		/// </summary>
		public static string HR_PY_S10025(string itemName1, string itemName2)
		{
			return new StringBuilder("[", 64).Append(itemName1).Append("］が未設定の場合、").Append("[").Append(itemName2).Append("］は設定できません。").ToString();
		}
		/// <summary>
		/// ［%s］ は ［前回%s］ 以降の日付で入力してください。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ は ［前回<paramref name="item2"/>］ 以降の日付で入力してください。</returns>
		public static string HR_PY_S10026(string item1, string item2)
		{
 			return new StringBuilder("［", 32).Append(item1).Append("］ は ［前回").Append(item2).Append("］ 以降の日付で入力してください。").ToString(); 
		}

		/// <summary>
		/// 死亡退職で、税額調整額または控除調整額が入力されています。
		/// </summary>
		public static string HR_PY_S10027
		{
			get { return "死亡退職で、税額調整額または控除調整額が入力されています。"; }
		}

		/// <summary>
		/// 退職所得の受給に関する申告書が未提出で、控除調整額が入力されています。
		/// </summary>
		public static string HR_PY_S10028
		{
			get { return "退職所得の受給に関する申告書が未提出で、控除調整額が入力されています。"; }
		}

		/// <summary>
		/// 前回更新時から情報が変更されています。先に更新を行ってください。
		/// </summary>
		public static string HR_PY_S10029
		{
			get { return "前回更新時から情報が変更されています。更新処理を行ってください。"; }
		}

		/// <summary>
		/// 退職金税額計算処理でエラーが発生しました。
		/// </summary>
		public static string HR_PY_S10030
		{
			get { return "退職金税額計算処理でエラーが発生しました。"; }
		}

		/// <summary>
		/// 前回表示時から情報が変更されたため、再表示しました。更新処理を行ってください。
		/// </summary>
		public static string HR_PY_S10031
		{
			get { return "前回表示時から情報が変更されたため、再表示しました。更新処理を行ってください。"; }
		}

		#endregion
		#endregion

		#region SC
		#region SC_MM
		/// <summary>
		/// 指定された部門は在庫管理部門ではありません。
		/// </summary>

// 		public static readonly string SC_MM_S10001 = "指定された部門は在庫管理部門ではありません。";
		public static string SC_MM_S10001
		{
			get {return MultiLanguage.Get("CM_AM001028");}
		}

		/// <summary>
		/// 在庫部門のみ入力可
		/// </summary>

// 		public static readonly string SC_MM_S10002 = "\v在庫部門のみ入力可";
		public static string SC_MM_S10002
		{
			get {return MultiLanguage.Get("CM_AM000425");}
		}


		/// <summary>
		/// ［%s］が控除外課税仕入の場合、［%s］に雑仕入先は登録できません。
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns>［<paramref name="item1"/>］が控除外課税仕入の場合、［<paramref name="item2"/>］に雑仕入先は登録できません。</returns>
		public static string SC_MM_S10003(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001830"), item1, item2);
		}

		/// <summary>
		/// ［%s］が控除外課税仕入の場合、［%s］は選択できません。
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns>［<paramref name="item1"/>］が控除外課税仕入の場合、［<paramref name="item2"/>］は選択できません。</returns>
		public static string SC_MM_S10004(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001832"), item1, item2);
		}

		/// <summary>
		/// %s行目:［%s］が控除外課税仕入の場合、［%s］に雑仕入先は登録できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/>行目：［<paramref name="item1"/>］が控除外課税仕入の場合に［<paramref name="item2"/>］に雑仕入先は登録できません。</returns>
		public static string SC_MM_S10005(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001831"), lineNo, item1, item2);
		}

		/// <summary>
		/// %s行目:［%s］が控除外課税仕入の場合、［%s］は選択できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/>行目：［<paramref name="item1"/>］が控除外課税仕入の場合に［<paramref name="item2"/>］は選択できません。</returns>
		public static string SC_MM_S10006(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001833"), lineNo, item1, item2);
		}

		/// <summary>
		/// 既に入荷または仕入されているためこの明細を削除できません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_01 = "既に入荷または仕入されているためこの明細を削除できません。";
		public static string SC_MM_03_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000821");}
		}

		/// <summary>
		/// この商品は発注を許可されていません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_02 = "この商品は発注を許可されていません。";
		public static string SC_MM_03_S02_02
		{
			get {return MultiLanguage.Get("CM_AM000553");}
		}

		/// <summary>
		/// 既に引当されているため倉庫を変更できません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_03 = "既に引当されているため倉庫を変更できません。";
		public static string SC_MM_03_S02_03
		{
			get {return MultiLanguage.Get("CM_AM000784");}
		}

		/// <summary>
		/// 既に入荷または仕入されているため倉庫を変更できません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_04 = "既に入荷または仕入されているため倉庫を変更できません。";
		public static string SC_MM_03_S02_04
		{
			get {return MultiLanguage.Get("CM_AM000822");}
		}

		/// <summary>
		/// 既に入荷または仕入されているためこの発注を削除できません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_05 = "既に入荷または仕入されているためこの発注を削除できません。";
		public static string SC_MM_03_S02_05
		{
			get {return MultiLanguage.Get("CM_AM000820");}
		}

		/// <summary>
		/// 発注する明細を 1 行以上選択してください。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_06 = "直送時に、仕入計上基準は検収基準になります。";
		public static string SC_MM_03_S02_06
		{
			get {return MultiLanguage.Get("CM_AM001250");}
		}

		/// <summary>
		/// 仕入計上基準が入荷基準の場合、明細に在庫管理を行わない商品または単価未決の商品を含めることはできません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_07 = "仕入計上基準が入荷基準の場合、明細に在庫管理を行わない商品または単価未決の商品を含めることはできません。";
		public static string SC_MM_03_S02_07
		{
			get {return MultiLanguage.Get("CM_AM000979");}
		}

		/// <summary>
		/// 預託品発注時に、仕入計上基準は検収基準になります。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_08 = "預託品発注時に、仕入計上基準は検収基準になります。";
		public static string SC_MM_03_S02_08
		{
			get {return MultiLanguage.Get("CM_AM001424");}
		}

		/// <summary>
		/// 受注、社内受注を参照していない時に、直送を選択することはできません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_09 = "受注、社内受注を参照していない時に、直送を選択することはできません。";
		public static string SC_MM_03_S02_09
		{
			get {return MultiLanguage.Get("CM_AM001102");}
		}

		/// <summary>
		/// 既に入荷されているため受渡場所は変更できません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_10 = "既に入荷されているため受渡場所は変更できません。";
		public static string SC_MM_03_S02_10
		{
			get {return MultiLanguage.Get("CM_AM000818");}
		}

		/// <summary>
		/// 事後発注、通常発注の発注区分を変更することはできません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_11 = "事後発注、通常発注の発注区分を変更することはできません。";
		public static string SC_MM_03_S02_11
		{
			get {return MultiLanguage.Get("CM_AM001061");}
		}

		/// <summary>
		/// 既に入荷、仕入または引当されているため明細の商品、規格、単位、倉庫を変更することはできません。 
		/// </summary>

// 		public static readonly string SC_MM_03_S02_12 = "既に入荷、仕入または引当されているため明細の商品、規格、単位、倉庫を変更することはできません。";
		public static string SC_MM_03_S02_12
		{
			get {return MultiLanguage.Get("CM_AM000817");}
		}

		/// <summary>
		/// 在庫管理する商品を選択したときは倉庫は必須です。 
		/// </summary>

// 		public static readonly string SC_MM_03_S02_13 = "在庫管理する商品を選択したときは倉庫は必須です。";
		public static string SC_MM_03_S02_13
		{
			get {return MultiLanguage.Get("CM_AM000943");}
		}

		/// <summary>
		/// 既に入荷、仕入または引当されているため発注形態を変更できません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_14 = "既に入荷、仕入または引当されているため発注形態を変更できません。";
		public static string SC_MM_03_S02_14
		{
			get {return MultiLanguage.Get("CM_AM000816");}
		}

		/// <summary>
		/// 在庫管理する商品を選択したときは倉庫は必須です。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_15 = "在庫管理する商品を選択したときは倉庫は必須です。";
		public static string SC_MM_03_S02_15
		{
			get {return MultiLanguage.Get("CM_AM000943");}
		}

		/// <summary>
		/// 入荷または仕入された数量よりも小さな数量を入力できません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_16 = "入荷または仕入された数量よりも小さな数量を入力できません。";
		public static string SC_MM_03_S02_16
		{
			get {return MultiLanguage.Get("CM_AM001298");}
		}

		/// <summary>
		/// 社内受発注を参照しているときは預託品発注はできません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_17 = "社内受発注を参照しているときは預託品発注はできません。";
		public static string SC_MM_03_S02_17
		{
			get {return MultiLanguage.Get("CM_AM001082");}
		}

		/// <summary>
		/// 仕入計上基準が入荷基準の場合、明細に直送倉庫を含めることはできません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_18 = "仕入計上基準が入荷基準の場合、明細に直送倉庫を含めることはできません。";
		public static string SC_MM_03_S02_18
		{
			get {return MultiLanguage.Get("CM_AM000980");}
		}

		/// <summary>
		/// 発注形態が%sの場合、明細に在庫管理しない商品を含めることはできません。
		/// </summary>
		/// <param name="value">項目名</param>
		/// <returns>発注形態が<paramref name="value"/>の場合、明細に在庫管理しない商品を含めることはできません。</returns>
		public static string SC_MM_03_S02_19(string value)
		{

// 			return new StringBuilder("発注形態が［", 4).Append(value).Append("］の場合、明細に在庫管理しない商品を含めることはできません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001553"), value);

		}
		/// <summary>
		/// ［%s］ 数量は ［%s］  （入数  ［%s］  ）以上で入力してください。
		/// </summary>
		/// <param name="type">数量種別</param>
		/// <param name="amountunit">数量単位</param>
		/// <param name="includeqt">入数</param>
		/// <returns>［<paramref name="item"/>］ 数量は ［<paramref name="amountunit"/>］  （入数  ［<paramref name="includeqt"/>］  ）以上で入力してください。</returns>
		public static string SC_MM_03_S02_20(string type,string amountunit,string includeqt)
		{

// 			return new StringBuilder("［", 32).Append(type).Append("］数量は[").Append(amountunit).Append("］（入数［").Append(includeqt).Append("］ ）以上で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001554"), type, amountunit, includeqt);

		}

		/// <summary>
		/// ［%s］ 数量は ［%s］  （入数  ［%s］  ）単位で入力してください。
		/// </summary>
		/// <param name="type">数量種別</param>
		/// <param name="amountunit">数量単位</param>
		/// <param name="includeqt">入数</param>
		/// <returns>［<paramref name="item"/>］ 数量は ［<paramref name="amountunit"/>］  （入数  ［<paramref name="includeqt"/>］  ）以上で入力してください。</returns>
		public static string SC_MM_03_S02_21(string type,string amountunit,string includeqt)
		{

// 			return new StringBuilder("［", 32).Append(type).Append("］数量は[").Append(amountunit).Append("］（入数［").Append(includeqt).Append("］ ）単位で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001555"), type, amountunit, includeqt);

		}
		/// <summary>
		/// 既に発注数量を超えて入荷、または仕入数量が指示されているため、数量を変更できません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_22 = "既に発注数量を超えて入荷、または仕入数量が指示されているため、数量を変更できません。";
		public static string SC_MM_03_S02_22
		{
			get {return MultiLanguage.Get("CM_AM000832");}
		}
		/// <summary>
		/// 既に入荷または仕入されているため通貨、仕入先、プロジェクト、仕入計上基準を変更することはできません。
		/// </summary>
// 		public static readonly string SC_MM_03_S02_23 = "既に入荷または仕入されているため通貨、仕入先、プロジェクト、仕入計上基準を変更することはできません。";
		public static string SC_MM_03_S02_23
		{
//			get {return MultiLanguage.Get("CM_AM001620");}
			get {return MultiLanguage.Get("CM_AM001726");}
		}
		/// <summary>
		/// ［発注依頼参照］の場合、参照元の明細を全て削除することはできません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_24 = "［発注依頼参照］の場合、参照元の明細を全て削除することはできません。";
		public static string SC_MM_03_S02_24
		{
			get {return MultiLanguage.Get("CM_AM000170");}
		}

		/// <summary>
		/// 発注依頼制御で指示した数量より小さい数量は入力できません。
		/// </summary>

// 		public static readonly string SC_MM_03_S02_25 = "発注依頼制御で指示した数量より小さい数量は入力できません。";
		public static string SC_MM_03_S02_25
		{
			get {return MultiLanguage.Get("CM_AM001347");}
		}

		/// <summary>
		/// 明細に直送品や在庫管理対象でない商品を含む場合、異なる得意先の伝票を同時に選択することは出来ません。
		/// </summary>

// 		public static readonly string SC_MM_03_S05_01 = "明細に直送品や在庫管理対象でない商品を含む場合、異なる得意先の伝票を同時に選択することは出来ません。";
		public static string SC_MM_03_S05_01
		{
			get {return MultiLanguage.Get("CM_AM001399");}
		}

		/// <summary>
		/// 仕入済数量以下には変更できません。
		/// </summary>

// 		public static readonly string SC_MM_04_S02_01 = "仕入済数量以下には変更できません。";
		public static string SC_MM_04_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000982");}
		}

		/// <summary>
		/// 発注数量を超えて入荷数量を指示しています。
		/// </summary>

// 		public static readonly string SC_MM_04_S02_02 = "発注数量を超えて入荷数量を指示しています。";
		public static string SC_MM_04_S02_02
		{
			get {return MultiLanguage.Get("CM_AM001350");}
		}

		/// <summary>
		/// 返品済数量以下には変更できません。
		/// </summary>

// 		public static readonly string SC_MM_04_S02_03 = "返品済数量以下には変更できません。";
		public static string SC_MM_04_S02_03
		{
			get {return MultiLanguage.Get("CM_AM001382");}
		}

		/// <summary>
		/// 仕入計上済数量以上に指示しています。
		/// </summary>

//         public static readonly string SC_MM_04_S02_04 = "仕入計上済数量を超える入荷数量は指示できません。";
		public static string SC_MM_04_S02_04
		{
			get {return MultiLanguage.Get("CM_AM000981");}
		}

		/// <summary>
		/// 指定された発注伝票は参照できません。
		/// </summary>

// 		public static readonly string SC_MM_04_S02_05 = "指定された発注伝票は参照できません。";
		public static string SC_MM_04_S02_05
		{
			get {return MultiLanguage.Get("CM_AM001026");}
		}

		/// <summary>
		/// 指定された入荷伝票が存在しません。
		/// </summary>

// 		public static readonly string SC_MM_04_S02_06 = "指定された入荷伝票が存在しません。";
		public static string SC_MM_04_S02_06
		{
			get {return MultiLanguage.Get("CM_AM001025");}
		}

		/// <summary>
		/// ロット詳細入力で指示した数量と入荷数量が異なっています。
		/// </summary>

// 		public static readonly string SC_MM_04_S02_07 = "ロット詳細入力で指示した数量と入荷数量が異なっています。";
		public static string SC_MM_04_S02_07
		{
			get {return MultiLanguage.Get("CM_AM000694");}
		}

		/// <summary>
		/// 当該倉庫の明細がありません。
		/// </summary>

// 		public static readonly string SC_MM_04_S02_08 = "当該倉庫の明細がありません。";
		public static string SC_MM_04_S02_08
		{
			get {return MultiLanguage.Get("CM_AM001270");}
		}

		/// <summary>
		/// 仕入伝票が修正されているため変更を行いませんでした。別途仕入伝票を修正してください。
		/// </summary>

// 		public static readonly string SC_MM_04_S02_09 = "仕入伝票が修正されているため変更を行いませんでした。別途仕入伝票を修正してください。";
		public static string SC_MM_04_S02_09
		{
			get {return MultiLanguage.Get("CM_AM000987");}
		}

		/// <summary>
		/// 指定された仕入伝票は参照できません。
		/// </summary>

// 		public static readonly string SC_MM_04_S02_10 = "指定された仕入伝票は参照できません。";
		public static string SC_MM_04_S02_10
		{
			get {return MultiLanguage.Get("CM_AM001008");}
		}

		/// <summary>
		/// 仕入済数量及び入荷返品数量以下には変更できません。
		/// </summary>

// 		public static readonly string SC_MM_04_S02_11 = "仕入済数量及び入荷返品数量以下には変更できません。";
		public static string SC_MM_04_S02_11
		{
			get {return MultiLanguage.Get("CM_AM000983");}
		}

		/// <summary>
		/// 仕入未計上数量以上には返品はできません。
		/// </summary>

// 		public static readonly string SC_MM_04_S05_01 = "仕入未計上数量以上には返品はできません。";
		public static string SC_MM_04_S05_01
		{
			get {return MultiLanguage.Get("CM_AM000992");}
		}

		/// <summary>
		/// 参照している入荷に対して入荷返品指示できません。
		/// </summary>

// 		public static readonly string SC_MM_04_S05_02 = "参照している入荷に対して入荷返品指示できません。";
		public static string SC_MM_04_S05_02
		{
			get {return MultiLanguage.Get("CM_AM000973");}
		}

		/// <summary>
		/// 該当する入荷返品は存在しません。
		/// </summary>

// 		public static readonly string SC_MM_04_S05_03 = "該当する入荷返品は存在しません。";
		public static string SC_MM_04_S05_03
		{
			get {return MultiLanguage.Get("CM_AM000771");}
		}

		/// <summary>
		/// ロット詳細入力で指示した数量と入荷返品数量が異なっています。
		/// </summary>

// 		public static readonly string SC_MM_04_S05_04 = "ロット詳細入力で指示した数量と入荷返品数量が異なっています。";
		public static string SC_MM_04_S05_04
		{
			get {return MultiLanguage.Get("CM_AM000695");}
		}

		/// <summary>
		/// 入荷数量以上に返品指示できません。
		/// </summary>

// 		public static readonly string SC_MM_04_S05_05 = "入荷数量以上に返品指示できません。";
		public static string SC_MM_04_S05_05
		{
			get {return MultiLanguage.Get("CM_AM001300");}
		}

		/// <summary>
		/// 入力されたロット番号は指示できません。
		/// </summary>

// 		public static readonly string SC_MM_04_S05_06 = "入力されたロット番号は指示できません。";
		public static string SC_MM_04_S05_06
		{
			get {return MultiLanguage.Get("CM_AM001310");}
		}

		/// <summary>
		/// 入荷返品数量が入力されていません。
		/// </summary>

// 		public static readonly string SC_MM_04_S05_07 = "入荷返品数量が入力されていません。";
		public static string SC_MM_04_S05_07
		{
			get {return MultiLanguage.Get("CM_AM001303");}
		}

		/// <summary>
		/// 入荷承認を使用しない設定の為、当該機能は利用できません。
		/// </summary>

// 		public static readonly string SC_MM_04_S07_01 = "入荷承認を使用しない設定の為、当該機能は利用できません。";
		public static string SC_MM_04_S07_01
		{
			get {return MultiLanguage.Get("CM_AM001299");}
		}

		/// <summary>
		/// 参照している発注伝票が残クローズされています。
		/// </summary>

// 		public static readonly string SC_MM_04_S10001 = "参照している発注伝票が残クローズされています。";
		public static string SC_MM_04_S10001
		{
			get {return MultiLanguage.Get("CM_AM000976");}
		}

		/// <summary>
		/// 既に入荷返品・仕入が発生しているので入荷を削除できません。
		/// </summary>

// 		public static readonly string SC_MM_04_S10002 = "既に入荷返品・仕入が発生しているので入荷を削除できません。";
		public static string SC_MM_04_S10002
		{
			get {return MultiLanguage.Get("CM_AM000823");}
		}

		/// <summary>
		/// 仕入未計上数以上に返品指示はできません。
		/// </summary>

// 		public static readonly string SC_MM_04_S10003 = "仕入未計上数以上に返品指示はできません。";
		public static string SC_MM_04_S10003
		{
			get {return MultiLanguage.Get("CM_AM000991");}
		}

		/// <summary>
		/// 入荷数量以上に返品指示はできません。
		/// </summary>

// 		public static readonly string SC_MM_04_S10004 = "入荷数量以上に返品指示はできません。";
		public static string SC_MM_04_S10004
		{
			get {return MultiLanguage.Get("CM_AM001301");}
		}

		/// <summary>
		/// 仕入済数量以下には変更できません。
		/// </summary>

// 		public static readonly string SC_MM_04_S10005 = "仕入済数量以下には変更できません。";
		public static string SC_MM_04_S10005
		{
			get {return MultiLanguage.Get("CM_AM000982");}
		}

		/// <summary>
		/// 返品済数量以下には変更できません。
		/// </summary>

// 		public static readonly string SC_MM_04_S10006 = "返品済数量以下には変更できません。";
		public static string SC_MM_04_S10006
		{
			get {return MultiLanguage.Get("CM_AM001382");}
		}

		/// <summary>
		/// 有効な発注明細がありません。
		/// </summary>

// 		public static readonly string SC_MM_04_S10007 = "有効な発注明細がありません。";
		public static string SC_MM_04_S10007
		{
			get {return MultiLanguage.Get("CM_AM001411");}
		}

		/// <summary>
		/// 既に入荷返品・仕入が発生しているので入荷を承認取消できません。
		/// </summary>

// 		public static readonly string SC_MM_04_S10008 = "既に入荷返品・仕入が発生しているので入荷を承認取消できません。";
		public static string SC_MM_04_S10008
		{
			get {return MultiLanguage.Get("CM_AM000824");}
		}

		/// <summary>
		/// 明細に直送倉庫が指定されている場合、納入区分に [自社倉庫] は指定できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S10001 = "明細に直送倉庫が指定されている場合、納入区分に [自社倉庫] は指定できません。";
		public static string SC_MM_05_S10001
		{
			get {return MultiLanguage.Get("CM_AM001398");}
		}

		/// <summary>
		/// 参照している発注に対して仕入を計上できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S02_01 = "参照している発注に対して仕入を計上できません。";
		public static string SC_MM_05_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000975");}
		}

		/// <summary>
		/// 参照している入荷に対して仕入計上できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S02_02 = "参照している入荷に対して仕入を計上できません。";
		public static string SC_MM_05_S02_02
		{
			get {return MultiLanguage.Get("CM_AM000971");}
		}

		/// <summary>
		/// 参照している仕入に対して仕入返品できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S02_03 = "参照している仕入に対して仕入返品できません。";
		public static string SC_MM_05_S02_03
		{
			get {return MultiLanguage.Get("CM_AM000960");}
		}

		/// <summary>
		/// 該当する仕入伝票は存在しません。
		/// </summary>

// 		public static readonly string SC_MM_05_S02_04 = "該当する仕入伝票は存在しません。";
		public static string SC_MM_05_S02_04
		{
			get {return MultiLanguage.Get("CM_AM000767");}
		}

		/// <summary>
		/// 仕入数量は入荷数量以上には指示できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S02_05 = "仕入数量は入荷数量以上には指示できません。";
		public static string SC_MM_05_S02_05
		{
			get {return MultiLanguage.Get("CM_AM000985");}
		}

		/// <summary>
		/// 仕入返品数量は仕入数量以上には指示できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S02_06 = "仕入返品数量は仕入数量以上には指示できません。";
		public static string SC_MM_05_S02_06
		{
			get {return MultiLanguage.Get("CM_AM000989");}
		}

		/// <summary>
		/// 比率が100%以外の数値入力時は、支払方法3は必須です。
		/// </summary>

// 		public static readonly string SC_MM_05_S02_07 = "比率が100%以外の数値入力時は、支払方法3は必須です。";
		public static string SC_MM_05_S02_07
		{
			get {return MultiLanguage.Get("CM_AM001355");}
		}

		/// <summary>
		/// 支払方法が手形、期日決済を選択時は、サイトは必須です。
		/// </summary>

// 		public static readonly string SC_MM_05_S02_08 = "支払方法が手形、期日決済を選択時は、サイトは必須です。";
		public static string SC_MM_05_S02_08
		{
			get {return MultiLanguage.Get("CM_AM001046");}
		}

		/// <summary>
		/// 既に支払が発生しているので仕入は変更できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S02_09 = "既に支払が発生しているので仕入は変更できません。";
		public static string SC_MM_05_S02_09
		{
			get {return MultiLanguage.Get("CM_AM000787");}
		}

		/// <summary>
		/// 既に消込が発生しているので仕入は変更できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S02_10 = "既に消込が発生しているので仕入は変更できません。";
		public static string SC_MM_05_S02_10
		{
			get {return MultiLanguage.Get("CM_AM000806");}
		}

		/// <summary>
		/// 仕入返品数量は仕入数量以下には指示できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S02_11 = "仕入返品数量は仕入数量以下には指示できません。";
		public static string SC_MM_05_S02_11
		{
			get {return MultiLanguage.Get("CM_AM000988");}
		}

		/// <summary>
		/// マイナスの仕入数量に対してプラスの仕入返品数量は指示できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S02_12 = "マイナスの仕入数量に対してプラスの仕入返品数量は指定できません。";
		public static string SC_MM_05_S02_12
		{
			get {return MultiLanguage.Get("CM_AM000662");}
		}

		/// <summary>
		/// プラスの仕入数量に対してマイナスの仕入返品数量は指示できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S02_13 = "プラスの仕入数量に対してマイナスの仕入返品数量は指定できません。";
		public static string SC_MM_05_S02_13
		{
			get {return MultiLanguage.Get("CM_AM000652");}
		}

		/// <summary>
		/// 仕入数量は未着品数量以下には変更できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S04_01 = "仕入数量は入荷数量以下には変更できません。";
		public static string SC_MM_05_S04_01
		{
			get {return MultiLanguage.Get("CM_AM000984");}
		}

		/// <summary>
		/// 入荷対象明細がないときは入荷省略を設定して下さい。
		/// </summary>

// 		public static readonly string SC_MM_05_S04_02 = "入荷対象明細がないときは入荷省略に設定して下さい。";
		public static string SC_MM_05_S04_02
		{
			get {return MultiLanguage.Get("CM_AM001302");}
		}

		/// <summary>
		/// 仕入返品数量は入荷数量以上には指示できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S04_03 = "仕入返品数量は入荷数量以上には指示できません。";
		public static string SC_MM_05_S04_03
		{
			get {return MultiLanguage.Get("CM_AM000990");}
		}

		/// <summary>
		/// 既に入荷されているため伝票削除または行削除できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S04_04 = "既に入荷されているため伝票削除または行削除できません。";
		public static string SC_MM_05_S04_04
		{
			get {return MultiLanguage.Get("CM_AM000819");}
		}

		/// <summary>
		/// 参照している入荷に対して仕入返品できません。
		/// </summary>

// 		public static readonly string SC_MM_05_S04_05 = "参照している入荷に対して仕入返品できません。";
		public static string SC_MM_05_S04_05
		{
			get {return MultiLanguage.Get("CM_AM000972");}
		}

		/// <summary>
		/// 後続の入荷伝票が承認済のため、更新することはできません。
		/// </summary>

// 		public static readonly string SC_MM_05_S04_06 = "後続の入荷伝票が承認済のため、更新することはできません。";
		public static string SC_MM_05_S04_06
		{
			get {return MultiLanguage.Get("CM_AM000892");}
		}

		/// <summary>
		/// 他の明細行で異なる製造日が入力されています。
		/// </summary>

// 		public static readonly string SC_MM_05_S05_01 = "他の明細行で異なる製造日が入力されています。";
		public static string SC_MM_05_S05_01
		{
			get {return MultiLanguage.Get("CM_AM001227");}
		}

		/// <summary>
		/// 該当商品は在庫が存在するため削除できません。
		/// </summary>

// 		public static readonly string SC_MM_06_S07_01 = "該当商品は在庫が存在するため削除できません。";
		public static string SC_MM_06_S07_01
		{
			get {return MultiLanguage.Get("CM_AM000774");}
		}

		/// <summary>
		/// 重複する棚番は登録できません。
		/// </summary>

// 		public static readonly string SC_MM_06_S07_02 = "重複する棚番は登録できません。";
		public static string SC_MM_06_S07_02
		{
			get {return MultiLanguage.Get("CM_AM001107");}
		}

		/// <summary>
		/// 積送倉庫、直送・未計上倉庫は指示できません。
		/// </summary>

// 		public static readonly string SC_MM_07_S01_01 = "積送倉庫、直送・未計上倉庫は指示できません。";
		public static string SC_MM_07_S01_01
		{
			get {return MultiLanguage.Get("CM_AM001194");}
		}

		/// <summary>
		/// 未出荷数量以上の引当数量は指示できません。
		/// </summary>

// 		public static readonly string SC_MM_07_S02_01 = "未出荷数量以上の引当数量は指示できません。";
		public static string SC_MM_07_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001389");}
		}

		/// <summary>
		/// 有効在庫数量以上の在庫引当数量は指示できません。
		/// </summary>

// 		public static readonly string SC_MM_07_S02_02 = "有効在庫数量以上の在庫引当数量は指示できません。";
		public static string SC_MM_07_S02_02
		{
			get {return MultiLanguage.Get("CM_AM001414");}
		}

		/// <summary>
		/// 預り有効在庫数量以上の預り在庫引当数量は指示できません。
		/// </summary>

// 		public static readonly string SC_MM_07_S02_03 = "預り有効在庫数量以上の預り在庫引当数量は指示できません。";
		public static string SC_MM_07_S02_03
		{
			get {return MultiLanguage.Get("CM_AM001423");}
		}

		/// <summary>
		/// 有効発注数量以上の発注引当数量は指示できません。
		/// </summary>

// 		public static readonly string SC_MM_07_S02_04 = "有効発注数量以上の発注引当数量は指示できません。";
		public static string SC_MM_07_S02_04
		{
			get {return MultiLanguage.Get("CM_AM001416");}
		}

		/// <summary>
		/// 今回の引当指示がされていません。
		/// </summary>

// 		public static readonly string SC_MM_07_S02_05 = "今回の引当指示がされていません。";
		public static string SC_MM_07_S02_05
		{
			get {return MultiLanguage.Get("CM_AM000928");}
		}

		/// <summary>
		/// 在庫引当済数量以上のマイナスは指示できません。
		/// </summary>

// 		public static readonly string SC_MM_07_S02_06 = "在庫引当済数量以上のマイナスは指示できません。";
		public static string SC_MM_07_S02_06
		{
			get {return MultiLanguage.Get("CM_AM000942");}
		}

		/// <summary>
		/// 預り在庫引当済数量以上のマイナスは指示できません。
		/// </summary>

// 		public static readonly string SC_MM_07_S02_07 = "預り在庫引当済数量以上のマイナスは指示できません。";
		public static string SC_MM_07_S02_07
		{
			get {return MultiLanguage.Get("CM_AM001422");}
		}

		/// <summary>
		/// 発注引当済数量以上のマイナスは指示できません。
		/// </summary>

// 		public static readonly string SC_MM_07_S02_08 = "発注引当済数量以上のマイナスは指示できません。";
		public static string SC_MM_07_S02_08
		{
			get {return MultiLanguage.Get("CM_AM001348");}
		}

		/// <summary>
		/// 引当済数量のうち、出荷依頼していない数量のみ引当解除可能です。
		/// </summary>

// 		public static readonly string SC_MM_07_S02_09 = "引当済数量のうち、出荷依頼していない数量のみ引当解除可能です。";
		public static string SC_MM_07_S02_09
		{
			get {return MultiLanguage.Get("CM_AM000735");}
		}

		/// <summary>
		/// 引当数量は未引当数量を超えて指示できません。
		/// </summary>

//// 		public static readonly string SC_MM_07_S02_10 = "受注数を超えて引当することはできません。";
		public static string SC_MM_07_S02_10
		{
//			get {return MultiLanguage.Get("CM_AM001103");}
			// 引当数量は未引当数量を超えて指示できません。
			get {return MultiLanguage.Get("CM_AM001728");}
		}

		/// <summary>
		/// 引当処理を開始しました。
		/// </summary>

// 		public static readonly string SC_MM_07_S03_01 = "引当処理を開始しました。";
		public static string SC_MM_07_S03_01
		{
			get {return MultiLanguage.Get("CM_AM000736");}
		}

		/// <summary>
		/// 在庫種別以外の検索条件を１つ以上指定してください。
		/// </summary>
		public static string SC_MM_07_S04_01
		{
			get {return MultiLanguage.Get("CM_AM001699");}
		}

		/// <summary>
		/// 変更元在庫数量以上の状態変更はできません。
		/// </summary>

// 		public static readonly string SC_MM_08_S01_01 = "変更元在庫数量以上の状態変更はできません。";
		public static string SC_MM_08_S01_01
		{
			get {return MultiLanguage.Get("CM_AM001377");}
		}

		/// <summary>
		/// 有効数量以上の調整入力はできません。
		/// </summary>

// 		public static readonly string SC_MM_08_S01_02 = "有効数量以上の調整入力はできません。";
		public static string SC_MM_08_S01_02
		{
			get {return MultiLanguage.Get("CM_AM001415");}
		}

		/// <summary>
		/// ロット管理でない商品を指定することはできません。
		/// </summary>

// 		public static readonly string SC_MM_08_S01_03 = "ロット管理でない商品を指定することはできません。";
		public static string SC_MM_08_S01_03
		{
			get {return MultiLanguage.Get("CM_AM000690");}
		}

		/// <summary>
		/// 在庫が存在しない商品を指定することはできません。
		/// </summary>

// 		public static readonly string SC_MM_08_S01_04 = "在庫が存在しない商品を指定することはできません。";
		public static string SC_MM_08_S01_04
		{
			get {return MultiLanguage.Get("CM_AM000939");}
		}

		/// <summary>
		/// 直送倉庫に対して在庫の調整はできません。
		/// </summary>

// 		public static readonly string SC_MM_08_S01_05 = "直送倉庫に対して在庫の調整はできません。";
		public static string SC_MM_08_S01_05
		{
			get {return MultiLanguage.Get("CM_AM001252");}
		}

		/// <summary>
		/// ロット別在庫評価する商品を指定することはできません。
		/// </summary>

		public static string SC_MM_08_S01_06
		{
			get {return MultiLanguage.Get("CM_AM001672");}
		}

		/// <summary>
		/// 仮締されていないので単価調整できません。
		/// </summary>

// 		public static readonly string SC_MM_08_S02_01 = "指定された会計月度は仮締ではないので、単価調整できません。";
		public static string SC_MM_08_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001004");}
		}

		/// <summary>
		/// 単価調整されている繰越明細が一件もありません。
		/// </summary>

// 		public static readonly string SC_MM_08_S02_02 = "単価調整されている繰越明細が一件もありません。";
		public static string SC_MM_08_S02_02
		{
			get {return MultiLanguage.Get("CM_AM001245");}
		}

		/// <summary>
		/// 新日付は対象月度内の日付のみ指定可能です。
		/// </summary>

// 		public static readonly string SC_MM_08_S02_03 = "新日付は対象月度内の日付のみ指定可能です。";
		public static string SC_MM_08_S02_03
		{
			get {return MultiLanguage.Get("CM_AM001166");}
		}

		/// <summary>
		/// %s 行目： 商品が重複して指示されているため、更新できません。［%s］
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="value">在庫キー</param>
		/// <returns><paramref name="lineNo"/> 行目：商品が重複して指示されているため、更新できません。［<paramref name="value"/>］</returns>
		public static string SC_MM_08_S02_04(string lineNo, string value)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目：商品が重複して指示されているため、更新できません。［").Append(value).Append("］").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001556"), lineNo, value);

		}
		/// <summary>
		/// {0}行目： 同一キーの在庫単価調整伝票が未承認のため、更新できません。［{1}］
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="value">在庫キー</param>
		/// <returns><paramref name="lineNo"/> 行目： 同一キーの在庫単価調整伝票が未承認のため、更新できません。［<paramref name="value"/>］</returns>
		public static string SC_MM_08_S02_05(string lineNo, string value)
		{
			return string.Format(MultiLanguage.Get("CM_AM001734"), lineNo, value);
		}
		/// <summary>
		/// 繰越明細別在庫単価調整一覧表出力時は、先入先出法以外の商品は指定できません。
		/// </summary>

// 		public static readonly string SC_MM_08_S03_01 = "繰越明細別在庫単価調整一覧表出力時は、先入先出法以外の商品は指定できません。";
		public static string SC_MM_08_S03_01
		{
			get {return MultiLanguage.Get("CM_AM000849");}
		}

		/// <summary>
		/// 指定された%sは棚卸中です。
		/// </summary>
		/// <param name="value">項目名</param>
		/// <returns>指定された<paramref name="value"/>は棚卸中です。</returns>
		public static string SC_MM_08_S04_01(string value)
		{

// 			return new StringBuilder("指定された", 16).Append(value).Append("は棚卸中です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001557"), value);

		}
		/// <summary>
		/// 一部商品選択時は ［在庫変動分］ ［固定棚卸対象商品］ ［商品カテゴリ］ ［棚番 （自）］ ［棚番 （至）］ のうち、どれかは必須です。
		/// </summary>

// 		public static readonly string SC_MM_08_S04_02 = "一部商品選択時は ［在庫変動分］ ［固定棚卸対象商品］ ［商品カテゴリ］ ［棚番 （自）］ ［棚番 （至）］ のうち、どれかは必須です。";
		public static string SC_MM_08_S04_02
		{
			get {return MultiLanguage.Get("CM_AM000730");}
		}

		/// <summary>
		/// ［棚番 （自）］ と ［棚番 （至）］ は同じ桁数でなくてはいけません。
		/// </summary>

// 		public static readonly string SC_MM_08_S04_03 = "［棚番 （自）］ と ［棚番 （至）］ は同じ桁数でなくてはいけません。";
		public static string SC_MM_08_S04_03
		{
			get {return MultiLanguage.Get("CM_AM000162");}
		}

		/// <summary>
		/// 指定された倉庫には部門別に管理されている在庫データがありません。
		/// </summary>

// 		public static readonly string SC_MM_08_S04_04 = "指定された倉庫には部門別に管理されている在庫データがありません。";
		public static string SC_MM_08_S04_04
		{
			get {return MultiLanguage.Get("CM_AM001021");}
		}

		/// <summary>
		/// 既に部門別棚卸が登録されています。部門を指定してください。
		/// </summary>

// 		public static readonly string SC_MM_08_S04_05 = "既に部門別棚卸が登録されています。部門を指定してください。";
		public static string SC_MM_08_S04_05
		{
			get {return MultiLanguage.Get("CM_AM000833");}
		}

		/// <summary>
		/// 重複する［セグメント］は登録できません。
		/// </summary>

// 		public static readonly string SC_MM_08_S04_06 = "重複する［セグメント］は登録できません。";
		public static string SC_MM_08_S04_06
		{
			get {return MultiLanguage.Get("CM_AM001106");}
		}

		/// <summary>
		/// 対象データが %d 件あります。\n棚卸を開始してよろしいですか？
		/// </summary>
		/// <param name="count">件数</param>
		/// <returns>対象データが <paramref name="count"/> 件あります。\n棚卸を開始してよろしいですか？</returns>
		public static string SC_MM_08_S05_01(int count)
		{

// 			return new StringBuilder("対象データが ", 64).Append(count.ToString("#,##0")).Append(" 件あります。\\n棚卸を開始してよろしいですか？").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001558"), count.ToString("#,##0"));

		}
		/// <summary>
		/// 棚卸結果を在庫に反映しますか？
		/// </summary>

// 		public static readonly string SC_MM_08_S05_02 = "棚卸結果を在庫に反映しますか？";
		public static string SC_MM_08_S05_02
		{
			get {return MultiLanguage.Get("CM_AM001240");}
		}

		/// <summary>
		/// 棚卸を中止しますか？
		/// </summary>

// 		public static readonly string SC_MM_08_S05_03 = "棚卸を中止しますか？";
		public static string SC_MM_08_S05_03
		{
			get {return MultiLanguage.Get("CM_AM001238");}
		}

		/// <summary>
		/// 棚卸開始のための在庫データの待避が完了しました。
		/// </summary>

// 		public static readonly string SC_MM_08_S05_04 = "棚卸開始のための在庫データの待避が完了しました。";
		public static string SC_MM_08_S05_04
		{
			get {return MultiLanguage.Get("CM_AM001239");}
		}

		/// <summary>
		/// 棚卸データによる在庫の置き換え処理が完了しました。
		/// </summary>

// 		public static readonly string SC_MM_08_S05_05 = "棚卸データによる在庫の置き換え処理が完了しました。";
		public static string SC_MM_08_S05_05
		{
			get {return MultiLanguage.Get("CM_AM001236");}
		}

		/// <summary>
		/// 棚卸を中止しました。
		/// </summary>

// 		public static readonly string SC_MM_08_S05_06 = "棚卸を中止しました。";
		public static string SC_MM_08_S05_06
		{
			get {return MultiLanguage.Get("CM_AM001237");}
		}

		/// <summary>
		/// 本締されているので棚卸を開始できません。棚卸月度を選択しなおしてください。
		/// </summary>

// 		public static readonly string SC_MM_08_S05_07 = "本締されているので棚卸を開始できません。棚卸月度を選択しなおしてください。";
		public static string SC_MM_08_S05_07
		{
			get {return MultiLanguage.Get("CM_AM001386");}
		}

		/// <summary>
		/// 取込ファイルの棚卸番号と対象の棚卸番号が一致しません。
		/// </summary>

// 		public static readonly string SC_MM_08_S08_01 = "取込ファイルの棚卸番号と対象の棚卸番号が一致しません。";
		public static string SC_MM_08_S08_01
		{
			get {return MultiLanguage.Get("CM_AM001096");}
		}

		/// <summary>
		/// 指定された棚卸は開始されていないか、在庫反映または中止されているため取込を行うことはできません。
		/// </summary>

// 		public static readonly string SC_MM_08_S08_02 = "指定された棚卸は開始されていないか、在庫反映または中止されているため取込を行うことはできません。";
		public static string SC_MM_08_S08_02
		{
			get {return MultiLanguage.Get("CM_AM001023");}
		}

		/// <summary>
		/// 指定された棚卸は開始されていないか、在庫反映または中止されているため原票登録することはできません。
		/// </summary>

// 		public static readonly string SC_MM_08_S09_01 = "指定された棚卸は開始されていないか、在庫反映または中止されているため原票登録することはできません。";
		public static string SC_MM_08_S09_01
		{
			get {return MultiLanguage.Get("CM_AM001022");}
		}

		/// <summary>
		/// [棚卸差異理由コード]が複数指定されています。
		/// </summary>

// 		public static readonly string SC_MM_08_S99_01 = "[棚卸差異理由コード]が複数指定されています。";
		public static string SC_MM_08_S99_01
		{
			get { return new StringBuilder(MultiLanguage.Get("CM_AM000131"), 32).Append(MultiLanguage.Get("SC_CS004686")).Append(MultiLanguage.Get("CM_AM000328")).ToString(); }
		}

		/// <summary>
		/// 在庫調整承認を使用しない設定の為、当該機能は利用できません。
		/// </summary>

// 		public static readonly string SC_MM_08_S10_01 = "在庫調整承認を使用しない設定の為、当該機能は利用できません。";
		public static string SC_MM_08_S10_01
		{
			get {return MultiLanguage.Get("CM_AM000947");}
		}

		/// <summary>
		/// 参照している受注に対して出庫依頼指示できません。
		/// </summary>

// 		public static readonly string SC_MM_09_S02_01 = "参照している受注に対して出庫依頼指示できません。";
		public static string SC_MM_09_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000963");}
		}

		/// <summary>
		/// 既に出庫が発生しているため出庫依頼は削除できません。
		/// </summary>

// 		public static readonly string SC_MM_09_S02_02 = "既に出庫が発生しているため出庫依頼は削除できません。";
		public static string SC_MM_09_S02_02
		{
			get {return MultiLanguage.Get("CM_AM000805");}
		}

		/// <summary>
		/// ［出庫依頼数］は［移動可能数］を超えて指示しています。
		/// </summary>
		/// <returns>［出庫依頼数］は［移動可能数］を超えて指示しています。</returns>
		public static string SC_MM_09_S02_03()
		{
// 			return "［出庫依頼数］ は ［移動可能数］ を超えて指示しています。"; 
			return MultiLanguage.Get("CM_AM000150");
		}
		/// <summary>
		/// %s 行目： ［出庫依頼数］ は ［移動可能数］ を超えて指示しています。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns><paramref name="lineNo"/> 行目： ［出庫依頼数］ は ［移動可能数］ を超えて指示しています。</returns>
		public static string SC_MM_09_S02_03(string lineNo)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ").Append(SC_MM_09_S02_03()).ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001559"), lineNo, SC_MM_09_S02_03());

		}
		/// <summary>
		/// 移動元倉庫 %s （%s 行目）： ［出庫依頼数］は［移動可能数］を超えて指示しています。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="whCode">倉庫コード</param>
		/// <returns>移動元倉庫 <paramref name="whCode"/> （ <paramref name="lineNo"/> 行目）： ［出庫依頼数］は［移動可能数］を超えて指示しています。</returns>
		public static string SC_MM_09_S02_03(string lineNo, string whCode)
		{

// 			return new StringBuilder("移動元倉庫 ",64).Append(whCode).Append(" （").Append(lineNo).Append(" 行目）： ").Append(SC_MM_09_S02_03()).ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001560"), whCode, lineNo, SC_MM_09_S02_03());

		}
		/// <summary>
		/// 移動元倉庫と移動先倉庫が同じです。
		/// </summary>

// 		public static readonly string SC_MM_09_S02_04 = "移動元倉庫と移動先倉庫が同じです。";
		public static string SC_MM_09_S02_04
		{
			get {return MultiLanguage.Get("CM_AM000725");}
		}

		/// <summary>
		/// 既に出庫が発生しているため出庫依頼は更新できません。
		/// </summary>

// 		public static readonly string SC_MM_09_S02_05 = "既に出庫が発生しているため出庫依頼は更新できません。";
		public static string SC_MM_09_S02_05
		{
			get {return MultiLanguage.Get("CM_AM000804");}
		}

		/// <summary>
		/// ［在庫単位数量］の小数点以下の桁数が %d 桁を超える商品があるため、出庫依頼伝票を作成できませんでした。 ［出庫依頼区分］ を後日にして更新をしてください。
		/// </summary>
		/// <param name="decimalDigit">小数点以下の桁数</param>
		/// <returns>［在庫単位数量］ の小数点以下の桁数が <paramref name="decimalDigit"/> 桁を超える商品があるため、出庫依頼伝票を作成できませんでした。 ［出庫依頼区分］ を後日にして更新をしてください。</returns>
		public static string SC_MM_09_S02_06(decimal decimalDigit)
		{
			return string.Format(MultiLanguage.Get("CM_AM001738"), decimalDigit);
		}

		/// <summary>
		/// ［出庫依頼数］は［移動可能数］を超えて指示しています。
		/// </summary>

// 		public static readonly string SC_MM_09_S03_01 = "［出庫数］ は ［移動可能数］ を超えて指示しています。";
		public static string SC_MM_09_S03_01
		{
			get {return MultiLanguage.Get("CM_AM000151");}
		}

		/// <summary>
		/// 既に入庫が発生しているため出庫は更新できません。
		/// </summary>

// 		public static readonly string SC_MM_09_S03_02 = "既に入庫が発生しているため出庫は更新できません。";
		public static string SC_MM_09_S03_02
		{
			get {return MultiLanguage.Get("CM_AM000825");}
		}

		/// <summary>
		/// 既に入庫が発生しているため出庫は削除できません。
		/// </summary>

// 		public static readonly string SC_MM_09_S03_03 = "既に入庫が発生しているため出庫は削除できません。";
		public static string SC_MM_09_S03_03
		{
			get {return MultiLanguage.Get("CM_AM000826");}
		}

		/// <summary>
		/// 指示した商品は棚卸中のため、出庫指示できません。
		/// </summary>

// 		public static readonly string SC_MM_09_S03_04 = "指示した商品は棚卸中のため、出庫指示できません。";
		public static string SC_MM_09_S03_04
		{
			get {return MultiLanguage.Get("CM_AM000997");}
		}

		/// <summary>
		/// %s 行目： ［ロット番号］ は必須です。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns><paramref name="lineNo"/> 行目： ［ロット番号］ は必須です。</returns>
		public static string SC_MM_09_S03_05(string lineNo)
		{

// 			return new StringBuilder(lineNo, 32).Append(" 行目： ").Append(S10006("ロット番号")).ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001561"), lineNo);

		}
		/// <summary>
		/// 参照している出庫は入庫不要または入庫済みです。
		/// </summary>

// 		public static readonly string SC_MM_09_S04_01 = "参照している出庫は入庫不要または入庫済みです。";
		public static string SC_MM_09_S04_01
		{
			get {return MultiLanguage.Get("CM_AM000967");}
		}

		/// <summary>
		/// ［入庫数］は［移動可能数］を超えて指示しています。
		/// </summary>

// 		public static readonly string SC_MM_09_S04_02 = "［入庫数］ は ［移動可能数］ を超えて指示しています。";
		public static string SC_MM_09_S04_02
		{
			get {return MultiLanguage.Get("CM_AM000165");}
		}

		/// <summary>
		/// 有効な出庫依頼明細がありません。
		/// </summary>

// 		public static readonly string SC_MM_09_S05_01 = "有効な出庫依頼明細がありません。";
		public static string SC_MM_09_S05_01
		{
			get {return MultiLanguage.Get("CM_AM001408");}
		}

		/// <summary>
		/// 既に発注されているためこの明細を削除できません。
		/// </summary>

// 		public static readonly string SC_MM_10_S02_01 = "既に発注されているためこの明細を削除できません。";
		public static string SC_MM_10_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000830");}
		}

		/// <summary>
		/// 既に発注されているためこの発注依頼を削除できません。
		/// </summary>

// 		public static readonly string SC_MM_10_S02_02 = "既に発注されているためこの発注依頼を削除できません。";
		public static string SC_MM_10_S02_02
		{
			get {return MultiLanguage.Get("CM_AM000829");}
		}

		/// <summary>
		/// 既に発注されているため明細の商品、規格、単位、倉庫を変更することはできません。 
		/// </summary>

// 		public static readonly string SC_MM_10_S02_03 = "既に発注されているため明細の商品、規格、単位、倉庫を変更することはできません。";
		public static string SC_MM_10_S02_03
		{
			get {return MultiLanguage.Get("CM_AM000831");}
		}

		/// <summary>
		/// 在庫管理する商品を選択したときは倉庫は必須です。 
		/// </summary>

// 		public static readonly string SC_MM_10_S02_04 = "在庫管理する商品を選択したときは倉庫は必須です。";
		public static string SC_MM_10_S02_04
		{
			get {return MultiLanguage.Get("CM_AM000943");}
		}

		/// <summary>
		/// 発注された数量よりも小さな数量を入力できません。
		/// </summary>

// 		public static readonly string SC_MM_10_S02_05 = "発注された数量よりも小さな数量を入力できません。";
		public static string SC_MM_10_S02_05
		{
			get {return MultiLanguage.Get("CM_AM001346");}
		}

		/// <summary>
		/// ［%s］ 数量は ［%s］  （入数  ［%s］  ）以上で入力してください。
		/// </summary>
		/// <param name="type">数量種別</param>
		/// <param name="amountunit">数量単位</param>
		/// <param name="includeqt">入数</param>
		/// <returns>［<paramref name="item"/>］ 数量は ［<paramref name="amountunit"/>］  （入数  ［<paramref name="includeqt"/>］  ）以上で入力してください。</returns>
		public static string SC_MM_10_S02_06(string type, string amountunit, string includeqt)
		{

// 			return new StringBuilder("［", 32).Append(type).Append("］数量は[").Append(amountunit).Append("］（入数［").Append(includeqt).Append("］ ）以上で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001554"), type, amountunit, includeqt);

		}
		/// <summary>
		/// ［%s］ 数量は ［%s］  （入数  ［%s］  ）単位で入力してください。
		/// </summary>
		/// <param name="type">数量種別</param>
		/// <param name="amountunit">数量単位</param>
		/// <param name="includeqt">入数</param>
		/// <returns>［<paramref name="item"/>］ 数量は ［<paramref name="amountunit"/>］  （入数  ［<paramref name="includeqt"/>］  ）以上で入力してください。</returns>
		public static string SC_MM_10_S02_07(string type, string amountunit, string includeqt)
		{

// 			return new StringBuilder("［", 32).Append(type).Append("］数量は[").Append(amountunit).Append("］（入数［").Append(includeqt).Append("］ ）単位で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001555"), type, amountunit, includeqt);

		}
		/// <summary>
		/// %s件選択されています。選択できる最大の件数は、%s件です。
		/// </summary>
		/// <param name="selectCount">選択している件数</param>
		/// <param name="maxCount">選択できる最大の件数</param>
		/// <returns></returns>
		public static string SC_MM_10_S03_01(string selectCount, string maxCount)
		{

// 			return new StringBuilder(selectCount).Append("件選択されています。選択できる最大の件数は、").Append(maxCount).Append("件です。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001564"), selectCount, maxCount);

		}
		#endregion
		#region SC_MF
		/// <summary>
		/// 製造計画パターンが登録されていません。
		/// </summary>

// 		public static readonly string SC_MF_03_S10001 = "製造計画パターンが登録されていません。";
		public static string SC_MF_03_S10001
		{
			get {return MultiLanguage.Get("CM_AM001179");}
		}

		/// <summary>
		/// 製造計画が登録されていません。
		/// </summary>

// 		public static readonly string SC_MF_03_S10002 = "製造計画が登録されていません。";
		public static string SC_MF_03_S10002
		{
			get {return MultiLanguage.Get("CM_AM001178");}
		}

		/// <summary>
		/// 製造計画パターンの［出荷予測計算基準区分］が不正な値です。
		/// </summary>

// 		public static readonly string SC_MF_03_S10003 = "製造計画パターンの ［出荷予測計算基準区分］ が不正な値です。";
		public static string SC_MF_03_S10003
		{
			get {return MultiLanguage.Get("CM_AM001180");}
		}

		/// <summary>
		///  ［%s］ の構成品が登録されていません。
		/// </summary>
		/// <param name="prodCode">商品</param>
		/// <returns>［<paramref name="prodCode"/>］ の構成品が登録されていません。</returns>
		public static string SC_MF_03_S10004(string prodCode)
		{

// 			return new StringBuilder("［").Append(prodCode).Append("］ の").Append(SC_MF_03_S10005).ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001565"), prodCode, SC_MF_03_S10005);

		}
		/// <summary>
		/// 構成品が登録されていません。
		/// </summary>

// 		public static readonly string SC_MF_03_S10005 = "構成品が登録されていません。";
		public static string SC_MF_03_S10005
		{
			get {return MultiLanguage.Get("CM_AM000915");}
		}

		/// <summary>
		/// 既に製造計画が発生しているため製造計画パターンを削除できません。
		/// </summary>

// 		public static readonly string SC_MF_03_S01_01 = "既に製造計画が発生しているため製造計画パターンを削除できません。";
		public static string SC_MF_03_S01_01
		{
			get {return MultiLanguage.Get("CM_AM000809");}
		}

		/// <summary>
		/// 番号が MAX となりましたので、別の製造計画パターンを作成してください。
		/// </summary>

// 		public static readonly string SC_MF_03_S02_01 = "番号が MAX となりましたので、別の製造計画パターンを作成してください。";
		public static string SC_MF_03_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001353");}
		}

		/// <summary>
		/// 計算対象を 1 つ以上選択してください。
		/// </summary>

// 		public static readonly string SC_MF_03_S03_01 = "計算対象を 1 つ以上選択してください。";
		public static string SC_MF_03_S03_01
		{
			get {return MultiLanguage.Get("CM_AM000854");}
		}

		/// <summary>
		/// 構成品が登録されていません。
		/// </summary>

// 		public static readonly string SC_MF_04_S02_01 = "構成品が登録されていません。";
		public static string SC_MF_04_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000915");}
		}

		/// <summary>
		/// 既に製造が開始しているため製造指図を更新できません。
		/// </summary>

// 		public static readonly string SC_MF_04_S02_02 = "既に製造が開始しているため製造指図を更新できません。";
		public static string SC_MF_04_S02_02
		{
			get {return MultiLanguage.Get("CM_AM000807");}
		}

		/// <summary>
		/// 既に製造報告が発生しているため製造指図を更新できません。
		/// </summary>

// 		public static readonly string SC_MF_04_S02_03 = "既に製造報告が発生しているため製造指図を更新できません。";
		public static string SC_MF_04_S02_03
		{
			get {return MultiLanguage.Get("CM_AM000810");}
		}

		/// <summary>
		/// 既に製造が開始しているため製造指図を削除できません。
		/// </summary>

// 		public static readonly string SC_MF_04_S02_04 = "既に製造が開始しているため製造指図を削除できません。";
		public static string SC_MF_04_S02_04
		{
			get {return MultiLanguage.Get("CM_AM000808");}
		}

		/// <summary>
		/// 既に製造報告が発生しているため製造指図を削除できません。
		/// </summary>

// 		public static readonly string SC_MF_04_S02_05 = "既に製造報告が発生しているため製造指図を削除できません。";
		public static string SC_MF_04_S02_05
		{
			get {return MultiLanguage.Get("CM_AM000811");}
		}

		/// <summary>
		/// 有効な製造指図明細がありません。
		/// </summary>

// 		public static readonly string SC_MF_04_S02_06 = "有効な製造指図明細がありません。";
		public static string SC_MF_04_S02_06
		{
			get {return MultiLanguage.Get("CM_AM001409");}
		}

		/// <summary>
		/// 構成品に含まれる製品の製造指図を同時に作成しました。
		/// </summary>

// 		public static readonly string SC_MF_04_S02_07 = "構成品に含まれる製品の製造指図を同時に作成しました。";
		public static string SC_MF_04_S02_07
		{
			get {return MultiLanguage.Get("CM_AM000917");}
		}

		/// <summary>
		/// 一括引当更新しない場合、商品および規格が重複した明細は登録できません。
		/// </summary>
		public static string SC_MF_04_S02_08
		{
			get {return MultiLanguage.Get("CM_AM001691");}
		}

		/// <summary>
		/// [%s]行目：有効在庫が不足しています。同一商品の明細が存在するため、ロット番号を修正してから再度指示してください。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns>[<paramref name="lineNo"/>]行目：有効在庫が不足しています。同一商品の明細が存在するため、ロット番号を修正してから再度指示してください。</returns>
		public static string SC_MF_04_S02_09(string lineNo)
		{
			return string.Format(MultiLanguage.Get("CM_AM001692"), lineNo);
		}

		/// <summary>
		/// 有効な製造報告明細がありません。
		/// </summary>

// 		public static readonly string SC_MF_05_S02_01 = "有効な製造報告明細がありません。";
		public static string SC_MF_05_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001410");}
		}

		/// <summary>
		/// ［製造数量］ と ［ロス数量］ のうち、どちらかは 0 以上で入力してください。
		/// </summary>

// 		public static readonly string SC_MF_05_S02_02 = "［製造数量］ と ［ロス数量］ のうち、どちらかは 0 以上で入力してください。";
		public static string SC_MF_05_S02_02
		{
			get {return MultiLanguage.Get("CM_AM000156");}
		}

		#endregion
		#region SC_MS
		/// <summary>
		/// 選択された規格の組み合わせはありません。
		/// </summary>
		public static string SC_MS_S10001()
		{
// 			return new StringBuilder("選択された規格の組み合わせはありません。").ToString(); 
			return new StringBuilder(MultiLanguage.Get("CM_AM001196")).ToString();
		}
		/// <summary>
		///  %s 行目： 選択された規格の組み合わせはありません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns><paramref name="lineNo"/> 行目： 選択された規格の組み合わせはありません。</returns>
		public static string SC_MS_S10001(string lineNo)
		{

// 			return new StringBuilder(lineNo, 32).Append(" 行目： 選択された規格の組み合わせはありません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001566"), lineNo);

		}
		/// <summary>
		/// この商品には規格が登録されていません。
		/// </summary>
		public static string SC_MS_S10002()
		{
// 			return "この商品には規格が登録されていません。"; 
			return MultiLanguage.Get("CM_AM000550");
		}
		/// <summary>
		/// %s 行目： この商品には規格が登録されていません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns><paramref name="lineNo"/> 行目： この商品には規格が登録されていません。</returns>
		public static string SC_MS_S10002(string lineNo)
		{

// 			return new StringBuilder(lineNo, 32).Append(" 行目： この商品には規格が登録されていません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001567"), lineNo);

		}
		/// <summary>
		/// 在庫管理対象でない商品を指定することはできません。
		/// </summary>

// 		public static readonly string SC_MS_S10003 = "在庫管理対象でない商品を指定することはできません。";
		public static string SC_MS_S10003
		{
			get {return MultiLanguage.Get("CM_AM000944");}
		}

		/// <summary>
		/// %sされた数量よりも小さくすることはできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns><paramref name="item"/>された数量よりも小さくすることはできません。</returns>
		public static string SC_MS_S10004(string item)
		{

// 			return new StringBuilder(item, 32).Append("された数量よりも小さくすることはできません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001568"), item);

		}
		/// <summary>
		/// %s、%s、 ... された数量よりも小さくすることはできません。
		/// </summary>
		/// <param name="items">項目名</param>
		/// <returns><paramref name="items"/>、<paramref name="items"/>、 ... された数量よりも小さくすることはできません。</returns>
		public static string SC_MS_S10004(params string[] items)
		{
			switch (items.Length)
			{
				case 0:
// 					return "小さくすることはできません。"; 
					return MultiLanguage.Get("CM_AM001143");
				case 1:
					return SC_MS_S10004(items[0]);
				default:
					StringBuilder sb = new StringBuilder(64);
					foreach (string item in items)
					{
// 						sb.Append(item).Append("、"); 
						sb.Append(item).Append(MultiLanguage.Get("CM_AM000128"));
					}
					sb.Remove(sb.Length - 1, 1);
// 					sb.Append("された数量よりも小さくすることはできません。"); 
					sb.Append(MultiLanguage.Get("CM_AM000563"));
					return sb.ToString();
			}
		}
		/// <summary>
		/// 在庫数量が不足しています。
		/// </summary>

// 		public static readonly string SC_MS_S10005 = "在庫数量が不足しています。";
		public static string SC_MS_S10005
		{
			get {return MultiLanguage.Get("CM_AM000946");}
		}

		/// <summary>
		/// この商品は%sを許可されていません。
		/// </summary>
		/// <param name="value">伝票名</param>
		/// <returns>この商品は<paramref name="value"/>を許可されていません。</returns>
		public static string SC_MS_S10006(string value)
		{

// 			return new StringBuilder("この商品は", 64).Append(value).Append("を許可されていません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001570"), value);

		}
		/// <summary>
		/// %s 行目： この商品は%sを許可されていません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="value">伝票名</param>
		/// <returns><paramref name="lineNo"/> 行目： この商品は<paramref name="value"/>を許可されていません。</returns>
		public static string SC_MS_S10006(string lineNo, string value)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： この商品は").Append(value).Append("を許可されていません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001571"), lineNo, value);

		}
		/// <summary>
		/// 制御用の商品は%sできません。
		/// </summary>
		/// <param name="slip">伝票名</param>
		/// <returns>制御用の商品は<paramref name="slip"/>出来ません。</returns>
		public static string SC_MS_S10007(string slip)
		{

// 			return new StringBuilder("制御用の商品は").Append(slip).Append("できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001572"), slip);

		}
		/// <summary>
		/// 在庫が不足している為引当を行いませんでした。別途引当を行う必要があります。
		/// </summary>

// 		public static readonly string SC_MS_S10008 = "在庫が不足しているため引当を行いませんでした。別途引当を行う必要があります。";
		public static string SC_MS_S10008
		{
			get {return MultiLanguage.Get("CM_AM000940");}
		}

		/// <summary>
		/// 参照している%sに対して%s指示できません。
		/// </summary>
		/// <param name="refSlip">参照伝票名</param>
		/// <param name="slip">伝票名</param>
		/// <returns>参照している<paramref name="refSlip"/>に対して<paramref name="slip"/>指示できません。</returns>
		public static string SC_MS_S10009(string refSlip, string slip)
		{

// 			return new StringBuilder("参照している", 64).Append(refSlip).Append("に対して").Append(slip).Append("指示できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001573"), refSlip, slip);
			
		}
		/// <summary>
		/// 同一部門は指定できません。
		/// </summary>

// 		public static readonly string SC_MS_S10010 = "同一部門は指定できません。";
		public static string SC_MS_S10010
		{
			get {return MultiLanguage.Get("CM_AM001285");}
		}

		/// <summary>
		/// 在庫管理部門が設定されていません。
		/// </summary>

// 		public static readonly string SC_MS_S10011 = "在庫管理部門が設定されていません。";
		public static string SC_MS_S10011
		{
			get {return MultiLanguage.Get("CM_AM000945");}
		}

		/// <summary>
		/// 削除対象の伝票は%sされている為、削除できません。
		/// </summary>
		/// <param name="followSlip">伝票名</param>
		/// <returns>削除対象の伝票は<paramref name="followSlip"/>されている為、削除できません。</returns>
		public static string SC_MS_S10012(string followSlip)
		{

// 			return new StringBuilder("削除対象の伝票は", 64).Append(followSlip).Append("されている為、削除できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001574"), followSlip);

		}
		/// <summary>
		/// 製造対象でない商品は指定できません。
		/// </summary>

// 		public static readonly string SC_MS_S10013 = "製造対象でない商品は指定できません。";
		public static string SC_MS_S10013
		{
			get {return MultiLanguage.Get("CM_AM001182");}
		}

		/// <summary>
		/// この商品は部品として使用できません。
		/// </summary>

// 		public static readonly string SC_MS_S10014 = "この商品は部品として使用できません。";
		public static string SC_MS_S10014
		{
			get {return MultiLanguage.Get("CM_AM000555");}
		}

		/// <summary>
		/// ロットの使用は許可されていません。
		/// </summary>

// 		public static readonly string SC_MS_S10015 = "ロットの使用は許可されていません。";
		public static string SC_MS_S10015
		{
			get {return MultiLanguage.Get("CM_AM000689");}
		}

		/// <summary>
		/// 消費税率が取得できませんでした。消費税区分マスタをご確認ください。
		/// </summary>

// 		public static readonly string SC_MS_S10016 = "消費税率が取得できませんでした。消費税区分マスタをご確認ください。";
		public static string SC_MS_S10016
		{
			get {return MultiLanguage.Get("CM_AM001162");}
		}

		/// <summary>
		/// 回収条件を取得できませんでした。
		/// </summary>

// 		public static readonly string SC_MS_S10017 = "回収条件が取得できませんでした。";
		public static string SC_MS_S10017
		{
			get {return MultiLanguage.Get("CM_AM000751");}
		}

		/// <summary>
		/// %s： %s がマイナスになりました。
		/// </summary>
		public static string SC_MS_S10018(string name)
		{

// 			return new StringBuilder(name, 64).Append("がマイナスになりました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001575"), name);

		}
		/// <summary>
		/// %s： %s がありません。
		/// </summary>
		public static string SC_MS_S10019(string name)
		{

// 			return new StringBuilder(name, 64).Append("がありません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001576"), name);

		}
		/// <summary>
		/// 通常品でない商品を指定することはできません。
		/// </summary>

// 		public static readonly string SC_MS_S10020 = "通常品でない商品を指定することはできません。";
		public static string SC_MS_S10020
		{
			get {return MultiLanguage.Get("CM_AM001255");}
		}

		/// <summary>
		/// 選択された商品、規格、単位の組み合わせは存在しません。
		/// </summary>

// 		public static readonly string SC_MS_S10021 = "選択された商品、規格、単位の組み合わせは存在しません。";
		public static string SC_MS_S10021
		{
			get {return MultiLanguage.Get("CM_AM001197");}
		}

		/// <summary>
		/// 支払条件を取得できませんでした。
		/// </summary>

// 		public static readonly string SC_MS_S10022 = "支払い条件が取得できませんでした。";
		public static string SC_MS_S10022
		{
			get {return MultiLanguage.Get("CM_AM001035");}
		}

		/// <summary>
		/// %s： %s の範囲指定が誤っています。
		/// </summary>
		public static string SC_MS_S10023(string name)
		{

// 			return new StringBuilder(name, 64).Append("の範囲指定が誤っています。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001577"), name);

		}
		/// <summary>
		/// 伝票日付（自）： %sは、伝票日付（至）： %s 以降の日付で入力してください。
		/// </summary>
		/// <param name="slipDateFrom">伝票日付（自）</param>
		/// <param name="slipDateTo">伝票日付（至）</param>
		/// <returns>伝票日付（自）<paramref name="slipDateFrom"/>は<paramref name="slipDateTo"/>以降の日付で入力してください。</returns>
		public static string SC_MS_S10024(string slipDateFrom, string slipDateTo)
		{

// 			return new StringBuilder(slipDateFrom, 64).Append("は").Append(slipDateTo).Append("以降の日付で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001578"), slipDateFrom, slipDateTo);

		}
		/// <summary>
		/// %s： %s が入力されていません。システム管理者に連絡してください。
		/// </summary>
		public static string SC_MS_S10025(string name)
		{

// 			return new StringBuilder(name, 64).Append("が入力されていません。システム管理者に連絡してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001579"), name);

		}
		/// <summary>
		/// %s： 既に %s されているため、削除できません。
		/// </summary>
		public static string SC_MS_S10026(string item)
		{

// 			return new StringBuilder("既に", 64).Append(item).Append("されているため、削除できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001580"), item);

		}
		/// <summary>
		/// 最終販売締処理日以前の伝票を入力することはできません。
		/// </summary>

// 		public static readonly string SC_MS_S10027 = "入力された日付は、伝票入力が禁止されています。";
		public static string SC_MS_S10027
		{
			get {return MultiLanguage.Get("CM_AM001316");}
		}

		/// <summary>
		/// 指定された為替予約は使用できないか、残額が不足しています。
		/// </summary>

// 		public static readonly string SC_MS_S10028 = "指定された為替予約は使用できないか、残額が不足しています。";
		public static string SC_MS_S10028
		{
			get {return MultiLanguage.Get("CM_AM001002");}
		}

		/// <summary>
		/// %s： %s された数量よりも小さな数量を入力できません。
		/// </summary>
		public static string SC_MS_S10029(string item)
		{

// 			return new StringBuilder(item, 64).Append("された数量よりも小さな数量を入力できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001581"), item);

		}
		/// <summary>
		/// 単価更新時にオーバーフローがおきました。単価と単位（入数）を見直してください。
		/// </summary>

// 		public static readonly string SC_MS_S10030 = "単価更新時にオーバーフローがおきました。単価と単位 （入数） を見直してください。";
		public static string SC_MS_S10030
		{
			get {return MultiLanguage.Get("CM_AM001244");}
		}

		/// <summary>
		/// ロット管理対象でない商品を指定することはできません。
		/// </summary>

// 		public static readonly string SC_MS_S10031 = "ロット管理対象でない商品を指定することはできません。";
		public static string SC_MS_S10031
		{
			get {return MultiLanguage.Get("CM_AM000691");}
		}

		/// <summary>
		/// %s 数量は指示できません。
		/// </summary>
		public static string SC_MS_S10032(string item)
		{

// 			return new StringBuilder(item, 64).Append("数量は指示できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001582"), item);

		}
		/// <summary>
		///  %sを超えて%sを指示しています。
		/// </summary>
		/// <param name="compQtName">比較先名</param>
		/// <param name="targetQtName">比較元名</param>
		/// <returns><paramref name="compName"/>を超えて<paramref name="targetName"/>を指示しています。</returns>
		public static string SC_MS_S10033(string compQtName, string targetQtName)
		{

// 			return new StringBuilder(compQtName).Append("を超えて").Append(targetQtName).Append("を指示しています。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001583"), compQtName, targetQtName);

		}
		/// <summary>
		/// 既に出荷されている為、発注引当を解除できませんでした。
		/// </summary>

// 		public static readonly string SC_MS_S10034 = "既に出荷されている為、発注引当を解除できませんでした。";
		public static string SC_MS_S10034
		{
			get {return MultiLanguage.Get("CM_AM000792");}
		}

		/// <summary>
		///  %s が同じ商品は登録できません。
		/// </summary>
		/// <param name="prodCode">商品</param>
		/// <returns><paramref name="prodCode"/> が同じ商品は登録できません。</returns>
		public static string SC_MS_S10035(string prodCode)
		{

// 			return new StringBuilder(prodCode).Append("が同じ商品は登録できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001584"), prodCode);

		}
		/// <summary>
		/// 残クローズしているか残クローズを変更した時は明細情報を変更できません。
		/// </summary>

// 		public static readonly string SC_MS_S10036 = "残クローズしているか残クローズを変更した時は明細情報を変更できません。";
		public static string SC_MS_S10036
		{
			get {return MultiLanguage.Get("CM_AM000977");}
		}

		/// <summary>
		/// %s： %s を開始しました。
		/// </summary>
		public static string SC_MS_S10037(string item)
		{

// 			return new StringBuilder(item, 64).Append("を開始しました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001585"), item);

		}
		/// <summary>
		/// %s がマイナスのため、更新できません。
		/// </summary>
		public static string SC_MS_S10038(string item)
		{

// 			return new StringBuilder(item, 64).Append("がマイナスのため、更新できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001586"), item);

		}
		/// <summary>
		/// 参照している伝票は残クローズされている為、変更または削除できません。
		/// </summary>

// 		public static readonly string SC_MS_S10039 = "参照している伝票は残クローズされている為、変更または削除できません。";
		public static string SC_MS_S10039
		{
			get {return MultiLanguage.Get("CM_AM000968");}
		}

		/// <summary>
		/// 有効在庫が不足しています。
		/// </summary>

// 		public static readonly string SC_MS_S10040 = "有効在庫が不足しています。";
		public static string SC_MS_S10040
		{
			get {return MultiLanguage.Get("CM_AM001413");}
		}

		/// <summary>
		/// 伝票の中に、存在しないかまたは無効なマスタが含まれています。
		/// </summary>

// 		public static readonly string SC_MS_S10041 = "伝票の中に、存在しないかまたは無効なマスタが含まれています。";
		public static string SC_MS_S10041
		{
			get {return MultiLanguage.Get("CM_AM001265");}
		}

		/// <summary>
		/// 伝票の中に、存在しないかまたは無効なマスタが含まれています。［%s］
		/// </summary>
		public static string SC_MS_S10042(string name)
		{

// 			return new StringBuilder("伝票の中に、存在しないかまたは無効なマスタが含まれています。" ).Append("［").Append(name).Append("］").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001587"), name);

		}
		/// <summary>
		/// ECゲスト得意先のEC担当部門又はEC担当が登録されておりません。
		/// </summary>

// 		public static readonly string SC_MS_S10043 = "ECゲスト得意先のEC担当部門又はEC担当が登録されておりません。";
		public static string SC_MS_S10043
		{
			get {return MultiLanguage.Get("CM_AM000441");}
		}

		/// <summary>
		/// %s は他のユーザによって変更、もしくは削除されました。
		/// </summary>
		public static string SC_MS_S10044(string item)
		{

// 			return new StringBuilder(item, 64).Append("は他のユーザによって変更、もしくは削除されました。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001588"), item);

		}
		/// <summary>
		/// 製品と同一のコードを構成品に含めることはできません。 
		/// </summary>

// 		public static readonly string SC_MS_S10045 = "製品と同一のコードを構成品に含めることはできません。";
		public static string SC_MS_S10045
		{
			get {return MultiLanguage.Get("CM_AM001185");}
		}

		/// <summary>
		/// 伝票の中に、出荷期限を越えているロット番号が含まれています。
		/// </summary>

// 		public static readonly string SC_MS_S10046 = "伝票の中に、出荷期限を越えているロット番号が含まれています。";
		public static string SC_MS_S10046
		{
			get {return MultiLanguage.Get("CM_AM001264");}
		}

		/// <summary>
		/// 売上可能な在庫がありません。（売上可能数は、実在庫数量から社内仕入未確定分を除いた数量となります。）
		/// </summary>

// 		public static readonly string SC_MS_S10047 = "売上可能な在庫がありません。（売上可能数は、実在庫数量から社内仕入未確定分を除いた数量となります。）";
		public static string SC_MS_S10047
		{
			get {return MultiLanguage.Get("CM_AM001338");}
		}

		/// <summary>
		/// ［%s］ より前の ［%s］を指示しています。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns>［<paramref name="item1"/>］ より前の ［<paramref name="item2"/>］ を指示しています。</returns>
		public static string SC_MS_S10048(string item1, string item2)
		{

// 			return new StringBuilder("［", 64).Append(item1).Append("］ より前の ［").Append(item2).Append("］ を指示しています。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001589"), item1, item2);

		}
		/// <summary>
		/// %s の場合、%s された数量を超える数量を入力できません。
		/// </summary>
		public static string SC_MS_S10049(string item1, string item2)
		{

// 			return new StringBuilder(item1, 64).Append("の場合、").Append(item2).Append("された数量を超える数量を入力できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001590"), item1, item2);

		}
		/// <summary>
		/// 同一部門、同一プロジェクトは指定できません。
		/// </summary>

// 		public static readonly string SC_MS_S10050 = "同一部門、同一プロジェクトは指定できません。";
		public static string SC_MS_S10050
		{
			get {return MultiLanguage.Get("CM_AM001284");}
		}
      
        /// <summary>
        /// ロット別在庫評価をする商品の場合、1明細に複数のロットは指定できません。
        /// </summary>
        /// 
        // 		public static readonly string SC_MS_S10051 = "ロット別在庫評価をする商品の場合、1明細に複数のロットは指定できません。";
        public static string SC_MS_S10051
        {
            get { return MultiLanguage.Get("CM_AM001654"); }
        }

        /// <summary>
        /// %s 行目：ロット別在庫評価をする商品の場合、1明細に複数のロットは指定できません。
        /// </summary>
        /// <param name="lineNo">行番号</param>
        /// <returns><paramref name="lineNo"/> 行目： ロット別在庫評価をする商品の場合、1明細に複数のロットは指定できません。</returns>
        // 		public static readonly string SC_MS_S10052 = "%s 行目：ロット別在庫評価をする商品の場合、1明細に複数のロットは指定できません。";
        public static string SC_MS_S10052(string lineNo)
        {
            return string.Format(MultiLanguage.Get("CM_AM001655"), lineNo);
        }
		/// <summary>
		/// 残クローズしているか残クローズを変更した時はロット引当を変更できません。
		/// </summary>
		public static string SC_MS_S10053
		{
			get { return MultiLanguage.Get("CM_AM001657"); }
		}

		/// <summary>
		/// ロット別在庫評価をする商品の場合、複数のロットを引当できません。連動する受注を修正してから再度指示してください。
		/// </summary>
		public static string SC_MS_S10054
		{
			 get { return MultiLanguage.Get("CM_AM001681"); }
		}

		/// <summary>
		/// %s 行目：発注引当可能な入荷残数が不足しているため、発注引当を解除できませんでした。同一発注に紐づく入荷を修正または削除してから再度指示してください。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns><paramref name="lineNo"/> 行目： 発注引当可能な入荷残数が不足しているため、発注引当を解除できませんでした。同一発注に紐づく入荷を修正または削除してから再度指示してください。</returns>
		// 		public static readonly string SC_MS_S10055 = "%s 行目：発注引当可能な入荷残数が不足しているため、発注引当を解除できませんでした。同一発注に紐づく入荷を修正または削除してから再度指示してください。";
		public static string SC_MS_S10055(string lineNo)
		{
			return string.Format(MultiLanguage.Get("CM_AM001682"), lineNo);
		}

		/// <summary>
		/// ［在庫単位数量］の小数点以下の桁数が %d 桁を超えました。（入数［%d］）
		/// </summary>
		/// <param name="decimalDigit">小数点以下の桁数</param>
		/// <param name="includeQt">入数</param>
		/// <returns>［在庫単位数量］ の小数点以下の桁数が <paramref name="decimalDigit"/> 桁を超えました。（入数［<paramref name="includeQt"/>］）</returns>
		public static string SC_MS_S10056(decimal decimalDigit, decimal includeQt)
		{
			return string.Format(MultiLanguage.Get("CM_AM001705"), decimalDigit, includeQt.ToString("#,##0.00000"));
		}

		/// <summary>
		/// 伝票の更新時にオーバーフローが発生しました。
		/// </summary>
		public static string SC_MS_S10057
		{
			 get { return MultiLanguage.Get("CM_AM001710"); }
		}

		/// <summary>
		/// ［在庫単位数量］の小数点以下の桁数が %d 桁を超えました。（%d：入数［%d］）
		/// </summary>
		/// <param name="decimalDigit">小数点以下の桁数</param>
		/// <param name="targetItem">対象項目</param>
		/// <param name="includeQt">入数</param>
		/// <returns>［在庫単位数量］ の小数点以下の桁数が <paramref name="decimalDigit"/> 桁を超えました。（<paramref name="targetItem"/>：入数［<paramref name="includeQt"/>］）</returns>
		public static string SC_MS_S10058(decimal decimalDigit, string targetItem, decimal includeQt)
		{
			return string.Format(MultiLanguage.Get("CM_AM001736"), decimalDigit, targetItem, includeQt.ToString("#,##0.00000"));
		}

		/// <summary>
		/// ［在庫単位数量］の小数点以下の桁数が %d 桁を超えました。
		/// </summary>
		/// <param name="decimalDigit">小数点以下の桁数</param>
		/// <returns>［在庫単位数量］ の小数点以下の桁数が <paramref name="decimalDigit"/> 桁を超えました。
		public static string SC_MS_S10059(decimal decimalDigit)
		{
			return string.Format(MultiLanguage.Get("CM_AM001739"), decimalDigit);
		}
		/// <summary>
		/// 後続処理が行われているため、[%s]は変更できません。
		/// </summary>
		public static string SC_MS_S10060(string item)
		{
			return string.Format(MultiLanguage.Get("SC_CS006230"), item);
		}

		/// <summary>
		/// ［%s］が控除外課税仕入の場合、［%s］に雑仕入先は登録できません。
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns>［<paramref name="item1"/>］が控除外課税仕入の場合、［<paramref name="item2"/>］に雑仕入先は登録できません。</returns>
		public static string SC_MS_S10061(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001830"), item1, item2);
		}

		/// <summary>
		/// ［%s］が控除外課税仕入の場合、［%s］は選択できません。
		/// </summary>
		/// <param name="item1"></param>
		/// <param name="item2"></param>
		/// <returns>［<paramref name="item1"/>］が控除外課税仕入の場合、［<paramref name="item2"/>］は選択できません。</returns>
		public static string SC_MS_S10062(string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001832"), item1, item2);
		}

		/// <summary>
		/// %s行目:［%s］が控除外課税仕入の場合、［%s］に雑仕入先は登録できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/>行目：［<paramref name="item1"/>］が控除外課税仕入の場合に［<paramref name="item2"/>］に雑仕入先は登録できません。</returns>
		public static string SC_MS_S10063(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001831"), lineNo, item1, item2);
		}

		/// <summary>
		/// %s行目:［%s］が控除外課税仕入の場合、［%s］は選択できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="lineNo"/>行目：［<paramref name="item1"/>］が控除外課税仕入の場合に［<paramref name="item2"/>］は選択できません。</returns>
		public static string SC_MS_S10064(string lineNo, string item1, string item2)
		{
			return string.Format(MultiLanguage.Get("CM_AM001833"), lineNo, item1, item2);
		}

		/// <summary>
		/// 既に同じロット番号が指示されています。
		/// </summary>

// 		public static readonly string SC_MS_02_S07_01 = "既に同じロット番号が指示されています。";
		public static string SC_MS_02_S07_01
		{
			get {return MultiLanguage.Get("CM_AM000814");}
		}

		/// <summary>
		/// 部品表に登録されている商品は ［在庫評価法］ を変更できません。
		/// </summary>

// 		public static readonly string SC_MS_03_S03_01 = "部品表に登録されている商品は ［在庫評価法］ を変更できません。";
		public static string SC_MS_03_S03_01
		{
			get {return MultiLanguage.Get("CM_AM001364");}
		}

		/// <summary>
		/// 部品表に登録されている商品は ［製造許可］ を変更できません。
		/// </summary>

// 		public static readonly string SC_MS_03_S03_02 = "部品表に登録されている商品は ［製造許可］ を変更できません。";
		public static string SC_MS_03_S03_02
		{
			get {return MultiLanguage.Get("CM_AM001365");}
		}

		/// <summary>
		/// 部品表に登録されている商品は ［構成品使用許可］ を変更できません。
		/// </summary>

// 		public static readonly string SC_MS_03_S03_03 = "部品表に登録されている商品は ［部品として使用］ を変更できません。";
		public static string SC_MS_03_S03_03
		{
			get {return MultiLanguage.Get("CM_AM001366");}
		}

		/// <summary>
		/// %sの登録可能行数は、%s行までです。
		/// </summary>
		/// <param name="textName">コントロール名</param>
		/// <param name="lineCnt">行数</param>
		/// <returns><paramref name="textName"/>の登録可能行数は、<paramref name="lineCnt"/>行までです。</returns>
		public static string SC_MS_03_S03_04(string textName, string lineCnt)
		{

// 			return new StringBuilder(textName).Append("の登録可能行数は、").Append(lineCnt).Append("行までです。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001591"), textName, lineCnt);

		}
		/// <summary>
		///  %sと%sの組み合わせがマスタに存在しません。
		/// </summary>
		/// <param name="item1">項目名 1</param>
		/// <param name="item2">項目名 2</param>
		/// <returns><paramref name="item1"/>と<paramref name="item2"/>の組み合わせがマスタに存在しません。</returns>
		public static string SC_MS_03_S03_05(string item1, string item2)
		{

// 			return new StringBuilder(item1).Append("と").Append(item2).Append("の組み合わせがマスタに存在しません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001592"), item1, item2);

		}
		/// <summary>
		///  %sが国内のとき、 [消費税科目区分：なし]の消費税区分コードは指定できません。
		/// </summary>
		/// <param name="ctaxTypeName">消費税区分名</param>
		/// <returns><paramref name="ctaxTypeName"/>が国内のとき、 [消費税科目区分：なし]の消費税区分コードは指定できません。</returns>
		public static string SC_MS_03_S03_06(string ctaxTypeName)
		{

// 			return new StringBuilder(ctaxTypeName).Append("が国内のとき、 [消費税科目区分：なし]の消費税区分コードは指定できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001593"), ctaxTypeName);

		}
		/// <summary>
		///  ロット管理しない商品は ［%s］ でするを選択できません。
		/// </summary>
		/// <param name="lotFlgName">ロット関連フラグ名</param>
		/// <returns>ロット管理しない商品は ［<paramref name="lotFlgName"/>］ でするを選択できません。</returns>
		// 		public static readonly string SC_MS_03_S03_07 = ロット管理しない商品は ［%s］ でするを選択できません。";
		public static string SC_MS_03_S03_07(string lotFlgName)
		{
			return string.Format(MultiLanguage.Get("CM_AM001669"), lotFlgName);
		}
		/// <summary>
		/// 在庫引当しない商品は ［ロット引当］でするを選択できません。
		/// </summary>

// 		public static readonly string SC_MS_03_S03_08 = "在庫引当しない商品は ［ロット引当］でするを選択できません。";
		public static string SC_MS_03_S03_08
		{
			get {return MultiLanguage.Get("CM_AM001670");}
		}
		/// <summary>
		/// ロット別在庫評価する商品の ［在庫評価法］ は月次総平均法 しか選択できません。
		/// </summary>

// 		public static readonly string SC_MS_03_S03_09 = "ロット別在庫評価する商品の ［在庫評価法］ は月次総平均法 しか選択できません。";
		public static string SC_MS_03_S03_09
		{
			get {return MultiLanguage.Get("CM_AM001671");}
		}
		/// <summary>
		///  [[0：非課税(0%)]の消費税率]以外のとき、%sに[消費税科目区分：なし]の消費税区分コードは指定できません。
		/// </summary>
		/// <param name="ctaxTypeName">消費税区分名</param>
		/// <returns>[[0：非課税(0%)]の消費税率]以外のとき、<paramref name="ctaxTypeName"/>に[消費税科目区分：なし]の消費税区分コードは指定できません。</returns>
		public static string SC_MS_03_S03_10(string ctaxTypeName)
		{
			return string.Format(MultiLanguage.Get("CM_AM001740"), ctaxTypeName);
		}

		/// <summary>
		/// 規格は使用できません。
		/// </summary>

// 		public static readonly string SC_MS_03_S05_01 = "規格は使用できません。";
		public static string SC_MS_03_S05_01
		{
			get {return MultiLanguage.Get("CM_AM000837");}
		}

		/// <summary>
		/// 規格使用区分の値が不正です。
		/// </summary>

// 		public static readonly string SC_MS_03_S05_02 = "規格使用区分の値が不正です。";
		public static string SC_MS_03_S05_02
		{
			get {return MultiLanguage.Get("CM_AM000838");}
		}

		/// <summary>
		/// この単位は使用中のため ［入数］ は変更できません。
		/// </summary>

// 		public static readonly string SC_MS_03_S06_01 = "単位が使用中のため ［入数］ は変更できません。";
		public static string SC_MS_03_S06_01
		{
			get {return MultiLanguage.Get("CM_AM001242");}
		}

		/// <summary>
		/// 在庫表示単位は削除、または無効にできません。
		/// </summary>

// 		public static readonly string SC_MS_03_S06_02 = "在庫表示単位は削除、または無効にできません。";
		public static string SC_MS_03_S06_02
		{
			get {return MultiLanguage.Get("CM_AM000948");}
		}

		/// <summary>
		/// 単価が取得できませんでした。
		/// </summary>

// 		public static readonly string SC_MS_03_S07_01 = "単価が取得できませんでした。";
		public static string SC_MS_03_S07_01
		{
			get {return MultiLanguage.Get("CM_AM001243");}
		}

		/// <summary>
		/// この商品には規格がありません。
		/// </summary>

// 		public static readonly string SC_MS_03_S08_01 = "この商品には規格がありません。";
		public static string SC_MS_03_S08_01
		{
			get {return MultiLanguage.Get("CM_AM000549");}
		}

		/// <summary>
		/// この商品にこの規格の組み合わせは登録されていません。
		/// </summary>

// 		public static readonly string SC_MS_03_S08_02 = "この商品にこの規格の組み合わせは登録されていません。";
		public static string SC_MS_03_S08_02
		{
			get {return MultiLanguage.Get("CM_AM000548");}
		}

		/// <summary>
		/// 価格表の明細が１件も存在しないため、出力処理を実行することはできません。
		/// </summary>

// 		public static readonly string SC_MS_03_S11_01 = "価格表の明細が 1 件も存在しないため、出力処理を実行することはできません。";
		public static string SC_MS_03_S11_01
		{
			get {return MultiLanguage.Get("CM_AM000745");}
		}

		/// <summary>
		/// 製品と異なる在庫評価法を使用する部品は登録できません。
		/// </summary>

// 		public static readonly string SC_MS_03_S14_01 = "製品と異なる在庫評価法を使用する部品は登録できません。";
		public static string SC_MS_03_S14_01
		{
			get {return MultiLanguage.Get("CM_AM001184");}
		}

		/// <summary>
		/// 部品表を展開したときに部品中に製品と同じコードが見つかりました。部品表の中に製品は使用できません。
		/// </summary>

// 		public static readonly string SC_MS_03_S14_02 = "この部品を製造するのに必要な部品の中に製品のコードと同じものが見つかりました。部品表にその部品を登録することはできません。";
		public static string SC_MS_03_S14_02
		{
			get {return MultiLanguage.Get("CM_AM000557");}
		}

		/// <summary>
		/// 製品コードがない、もしくは製品の規格の組み合わせが不正です。
		/// </summary>

// 		public static readonly string SC_MS_03_S14_03 = "製品コードがない、もしくは製品の規格の組み合わせが不正です。";
		public static string SC_MS_03_S14_03
		{
			get {return MultiLanguage.Get("CM_AM001183");}
		}

		/// <summary>
		/// 構成品コードがない、もしくは構成品の規格の組み合わせが不正です。
		/// </summary>

// 		public static readonly string SC_MS_03_S14_04 = "構成品コードがない、もしくは構成品の規格の組み合わせが不正です。";
		public static string SC_MS_03_S14_04
		{
			get {return MultiLanguage.Get("CM_AM000916");}
		}

		/// <summary>
		/// 存在しないファイル、または空のファイルが指定されました。
		/// </summary>

// 		public static readonly string SC_MS_03_S98_01 = "存在しないファイル、または空のファイルが指定されました。";
		public static string SC_MS_03_S98_01
		{
			get {return MultiLanguage.Get("CM_AM001224");}
		}

		/// <summary>
		/// ［商品コード］ %s はマスタにないか、有効ではありません。
		/// </summary>
		/// <param name="prodCode">商品</param>
		/// <returns><paramref name="prodCode"/> はマスタにないか、有効ではありません。</returns>
		public static string SC_MS_03_S98_02(string prodCode)
		{

// 			return new StringBuilder("［商品コード］" + prodCode).Append("はマスタにないか、有効ではありません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001594"), prodCode);

		}
		/// <summary>
		/// 商品コード［%s］はマスタにないか、有効ではありません。
		/// </summary>
		public static string SC_MS_03_S98_03(string name, string unitcode)
		{

// 			return new StringBuilder("［商品コード］" + name, 64).Append(" の［単位］").Append(unitcode).Append(" はマスタにないか、有効ではありません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001595"), name, unitcode);

		}
		/// <summary>
		/// 商品コード［%s］又は規格はマスタにないか、有効ではありません。
		/// </summary>
		public static string SC_MS_03_S98_04(string name, string spec1, string spec2)
		{

// 			return new StringBuilder("［商品コード］" + name, 64).Append("の［規格］").Append(spec1).Append("、").Append(spec2).Append(" はマスタにないか、有効ではありません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001596"), name, spec1, spec2);

		}
		/// <summary>
		/// 該当伝票は受発注伝票ではありません。
		/// </summary>

// 		public static readonly string SC_MS_04_S01_01 = "該当伝票は受発注伝票ではありません。";
		public static string SC_MS_04_S01_01
		{
			get {return MultiLanguage.Get("CM_AM000775");}
		}
		/// <summary>
		/// 売上済みのため、仕入先を変更できません。
		/// </summary>
// 		public static readonly string SC_MS_04_S01_02 = "売上済みのため、仕入先を変更できません。";
		public static string SC_MS_04_S01_02
		{
			get {return MultiLanguage.Get("CM_AM001621");}
		}
		/// <summary>
		/// 仕入数量は預り在庫引当数量以上には指示できません。
		/// </summary>

// 		public static readonly string SC_MS_04_S02_01 = "仕入数量は預り在庫引当数量以上には指示できません。";
		public static string SC_MS_04_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000986");}
		}

		/// <summary>
		/// 社内受発注数量は受注の未引当数量以下で入力してください。
		/// </summary>
		public static string SC_MS_05_S03_01()
		{
// 			return "社内受発注数量は受注の未引当数量以下で入力してください。"; 
			return MultiLanguage.Get("CM_AM001083");
		}
		/// <summary>
		///  %s 行目： 社内受発注数量は受注の未引当数量以下で入力してください。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns><paramref name="lineNo"/> 行目： 社内受発注数量は受注の未引当数量以下で入力してください。</returns>
		public static string SC_MS_05_S03_01(string lineNo)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： 社内受発注数量は受注の未引当数量以下で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001597"), lineNo);

		}
		/// <summary>
		/// 確認解除した伝票は%sされています。
		/// </summary>
		/// <param name="followSlip">伝票名</param>
		/// <returns>確認解除した伝票は<paramref name="followSlip"/>されています。</returns>
		public static string SC_MS_05_S03_02(string followSlip)
		{

// 			return new StringBuilder("確認解除した伝票は", 64).Append(followSlip).Append("されています。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001598"), followSlip);

		}
		/// <summary>
		/// %sされている為、出荷倉庫を変更できません。
		/// </summary>
		/// <param name="followSlip">伝票名</param>
		/// <returns><paramref name="followSlip"/>%sされている為、出荷倉庫を変更できません。</returns>
		public static string SC_MS_05_S03_03(string followSlip)
		{

// 			return new StringBuilder(followSlip, 64).Append("されている為、出荷倉庫を変更できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001599"), followSlip);

		}
		/// <summary>
		/// %s 行目： %sされている為、出荷倉庫を変更できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <param name="followSlip">伝票名</param>
		/// <returns><paramref name="lineNo"/> 行目： <paramref name="followSlip"/>されている為、出荷倉庫を変更できません。</returns>
		public static string SC_MS_05_S03_03(string lineNo, string followSlip)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ").Append(followSlip).Append("されている為、出荷倉庫を変更できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001600"), lineNo, followSlip);

		}
		/// <summary>
		/// 出荷倉庫が直送倉庫入力時は出荷/出庫依頼は ［しない］ のみ指定可能です。
		/// </summary>

// 		public static readonly string SC_MS_05_S03_04 = "出荷倉庫が直送倉庫入力時は出荷/出庫依頼は ［しない］ のみ指定可能です。";
		public static string SC_MS_05_S03_04
		{
			get {return MultiLanguage.Get("CM_AM001121");}
		}

		/// <summary>
		/// 自社倉庫と出荷倉庫が同じ倉庫の場合には出荷/出庫依頼は ［しない］ のみ指定可能です。
		/// </summary>

// 		public static readonly string SC_MS_05_S03_05 = "自社倉庫と出荷倉庫が同じ倉庫の場合には出荷/出庫依頼は ［しない］ のみ指定可能です。";
		public static string SC_MS_05_S03_05
		{
			get {return MultiLanguage.Get("CM_AM001070");}
		}

		/// <summary>
		/// 既に出荷依頼、出庫依頼、または社内売買されているためこの明細を削除できません。
		/// </summary>

// 		public static readonly string SC_MS_05_S03_06 = "既に出荷依頼、出庫依頼、または社内売買されているためこの明細を削除できません。";
		public static string SC_MS_05_S03_06
		{
			get {return MultiLanguage.Get("CM_AM000800");}
		}

		/// <summary>
		/// 既に出荷依頼、出庫依頼、または社内売買されているためこの明細の商品、規格、単位を変更することはできません。
		/// </summary>

// 		public static readonly string SC_MS_05_S03_07 = "既に出荷依頼、出庫依頼、または社内売買されているためこの明細の商品、規格、単位を変更することはできません。";
		public static string SC_MS_05_S03_07
		{
			get {return MultiLanguage.Get("CM_AM000799");}
		}

		/// <summary>
		/// 出庫依頼伝票を作成しました。
		/// </summary>

// 		public static readonly string SC_MS_05_S03_08 = "出庫依頼伝票を作成しました。";
		public static string SC_MS_05_S03_08
		{
			get {return MultiLanguage.Get("CM_AM001124");}
		}

		/// <summary>
		/// <param name="lineNo">行番号</param>
		/// 納入先と参照している受注の倉庫が異なっているため社内発注指示できません。
		/// <returns><paramref name="lineNo"/> 納入先と参照している受注の倉庫が異なっているため社内発注指示できません。</returns>
		/// </summary>
		public static string SC_MS_05_S03_09(string lineNo)
		{

// 			return new StringBuilder(lineNo, 64).Append(" 行目： ").Append("納入先と参照している受注の倉庫が異なっているため社内発注指示できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001601"), lineNo);

		}
		/// <summary>
		/// 出庫依頼伝票は作成されませんでした。
		/// </summary>

// 		public static readonly string SC_MS_05_S03_10 = "出庫依頼伝票は作成されませんでした。";
		public static string SC_MS_05_S03_10
		{
			get {return MultiLanguage.Get("CM_AM001123");}
		}

		/// <summary>
		/// 参照している伝票は残クローズされている為確認解除できません。
		/// </summary>

// 		public static readonly string SC_MS_05_S03_11 = "参照している伝票は残クローズされている為確認解除できません。";
		public static string SC_MS_05_S03_11
		{
			get {return MultiLanguage.Get("CM_AM000969");}
		}

		/// <summary>
		/// 既に出荷依頼、出庫依頼、または社内売買されているため%sを変更することはできません。
		/// </summary>
		public static string SC_MS_05_S03_12(string item)
		{

// 			return new StringBuilder("既に出荷依頼、出庫依頼、または社内売買されているため").Append(item).Append("を変更することはできません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001602"), item);

		}
		/// <summary>
		/// 客先直送が指定されている場合、明細行を追加することはできません。
		/// </summary>
// 		public static readonly string SC_MS_05_S03_13 = "客先直送が指定されている場合、明細行を追加することはできません。";
		public static string SC_MS_05_S03_13
		{
			get {return MultiLanguage.Get("CM_AM001622");}
		}

		/// <summary>
		/// [%s]行目：未引当数量以上の引当数量は指示できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns>[<paramref name="lineNo"/>]行目：未引当数量以上の引当数量は指示できません。</returns>
		public static string SC_MS_05_S03_14(string lineNo)
		{
			return string.Format(MultiLanguage.Get("CM_AM001659"), lineNo);
		}

		/// <summary>
		/// [%s]行目：既に出荷依頼されている為、このロット引当を削除できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns>[<paramref name="lineNo"/>]行目：既に出荷依頼されている為、このロット引当を削除できません。</returns>
		public static string SC_MS_05_S03_15(string lineNo)
		{
			return new StringBuilder(lineNo, 32).Append(" 行目： 既に出荷依頼されている為、このロット引当を削除できません。").ToString(); 
		}

		/// <summary>
		/// [%s]行目：既に出庫依頼されている為、このロット引当を削除できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns>[<paramref name="lineNo"/>]行目：既に出庫依頼されている為、このロット引当を削除できません。</returns>
		public static string SC_MS_05_S03_16(string lineNo)
		{
			return new StringBuilder(lineNo, 32).Append(" 行目： 既に出庫依頼されている為、このロット引当を削除できません。").ToString(); 
		}

		/// <summary>
		/// [%s]行目：既に社内売買されている為、このロット引当を削除できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns>[<paramref name="lineNo"/>]行目：既に社内売買されている為、このロット引当を削除できません。</returns>
		public static string SC_MS_05_S03_17(string lineNo)
		{
			return new StringBuilder(lineNo, 32).Append(" 行目： 既に社内売買されている為、このロット引当を削除できません。").ToString(); 
		}

		/// <summary>
		/// [%s]行目：出荷依頼された数量よりも小さな引当数量を入力できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns>[<paramref name="lineNo"/>]行目：出荷依頼された数量よりも小さな引当数量を入力できません。</returns>
		public static string SC_MS_05_S03_18(string lineNo)
		{
			return new StringBuilder(lineNo, 32).Append(" 行目： 出荷依頼された数量よりも小さな引当数量を入力できません。").ToString(); 
		}

		/// <summary>
		/// [%s]行目：出庫依頼された数量よりも小さな引当数量を入力できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns>[<paramref name="lineNo"/>]行目：出庫依頼された数量よりも小さな引当数量を入力できません。</returns>
		public static string SC_MS_05_S03_19(string lineNo)
		{
			return new StringBuilder(lineNo, 32).Append(" 行目： 出庫依頼された数量よりも小さな引当数量を入力できません。").ToString(); 
		}

		/// <summary>
		/// [%s]行目：社内売買された数量よりも小さな引当数量を入力できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns>[<paramref name="lineNo"/>]行目：社内売買された数量よりも小さな引当数量を入力できません。。</returns>
		public static string SC_MS_05_S03_20(string lineNo)
		{
			return new StringBuilder(lineNo, 32).Append(" 行目： 社内売買された数量よりも小さな引当数量を入力できません。").ToString(); 
		}

		/// <summary>
		/// 未引当数量以上の引当数量は指示できません。
		/// </summary>
		public static readonly string SC_MS_05_S03_21 = "未引当数量以上の引当数量は指示できません。";

		/// <summary>		
		/// 社内売買数量は未計上数量以下で入力してください。
		/// </summary>
// 		public static readonly string SC_MS_05_S06_01 = "社内売買数量は未計上数量以下で入力してください。";
		public static string SC_MS_05_S06_01
		{
			get {return MultiLanguage.Get("CM_AM001084");}
		}

		/// <summary>
		/// 既に社内発注引当仕入数量分が、出荷依頼または出荷されているため解除できません。
		/// </summary>

// 		public static readonly string SC_MS_05_S06_02 = "既に社内発注引当仕入数量分が、出荷依頼または出荷されているため解除できません。";
		public static string SC_MS_05_S06_02
		{
			get {return MultiLanguage.Get("CM_AM000789");}
		}

		/// <summary>
		/// [客先倉庫] 選択時に、[社内受発注] の参照は必須です。
		/// </summary>

// 		public static readonly string SC_MS_05_S06_03 = "[客先倉庫] 選択時に、[社内受発注] の参照は必須です。";
		public static string SC_MS_05_S06_03
		{
			get {return MultiLanguage.Get("CM_AM000136");}
		}

		/// <summary>
		/// [客先倉庫] 選択時に、[社内受発注] の納入区分は [客先直送] としてください。
		/// </summary>

// 		public static readonly string SC_MS_05_S06_04 = "[客先倉庫] 選択時に、[社内受発注] の納入区分は [客先直送] としてください。";
		public static string SC_MS_05_S06_04
		{
			get {return MultiLanguage.Get("CM_AM000137");}
		}

		/// <summary>
		/// ロット引当をする商品の場合、社内受発注の引当済分を先に売上指示してください。
		/// </summary>
		public static readonly string SC_MS_05_S06_05 = "ロット引当をする商品の場合、社内受発注の引当済分を先に売上指示してください。";

		/// <summary>
		/// 該当する諸掛伝票は存在しません。
		/// </summary>

// 		public static readonly string SC_MS_06_S02_01 = "該当する諸掛伝票は存在しません。";
		public static string SC_MS_06_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000770");}
		}

		/// <summary>
		/// 複数のプロジェクトは入力できません。
		/// </summary>

// 		public static readonly string SC_MS_06_S02_02 = "複数のプロジェクトは入力できません。";
		public static string SC_MS_06_S02_02
		{
			get {return MultiLanguage.Get("CM_AM001370");}
		}

		/// <summary>
		/// 複数プロジェクトの仕入番号は入力できません。
		/// </summary>

// 		public static readonly string SC_MS_06_S02_03 = "複数プロジェクトの仕入番号は入力できません。";
		public static string SC_MS_06_S02_03
		{
			get {return MultiLanguage.Get("CM_AM001372");}
		}

		/// <summary>
		/// 該当する仕入伝票はまだ決裁されていません。
		/// </summary>

// 		public static readonly string SC_MS_06_S02_04 = "該当する仕入伝票はまだ決裁されていません。";
		public static string SC_MS_06_S02_04
		{
			get {return MultiLanguage.Get("CM_AM000766");}
		}

		/// <summary>
		/// 既に支払が発生しているので諸掛は削除できません。
		/// </summary>

// 		public static readonly string SC_MS_06_S02_05 = "既に支払が発生しているので諸掛は削除できません。";
		public static string SC_MS_06_S02_05
		{
			get {return MultiLanguage.Get("CM_AM000788");}
		}

		/// <summary>
		/// 確定区分が見込である為、為替予約を使用できません。
		/// </summary>

// 		public static readonly string SC_MS_06_S02_06 = "確定区分が見込である為、為替予約を使用できません。";
		public static string SC_MS_06_S02_06
		{
			get {return MultiLanguage.Get("CM_AM000776");}
		}

		/// <summary>
		/// 該当決算期のデータが見つかりません。
		/// </summary>

// 		public static readonly string SC_MS_07_S01_01 = "該当決算期のデータが見つかりません。";
		public static string SC_MS_07_S01_01
		{
			get {return MultiLanguage.Get("CM_AM000773");}
		}

		/// <summary>
		/// 未承認の伝票があるため、本締にできません。
		/// </summary>

// 		public static readonly string SC_MS_07_S01_02 = "未承認の伝票があるため、本締にできません。";
		public static string SC_MS_07_S01_02
		{
			get {return MultiLanguage.Get("CM_AM001391");}
		}

		/// <summary>
		/// その月度の本締は実行できません。
		/// </summary>

// 		public static readonly string SC_MS_07_S01_03 = "その月度の本締は実行できません。";
		public static string SC_MS_07_S01_03
		{
			get {return MultiLanguage.Get("CM_AM000580");}
		}

		/// <summary>
		/// 決算期が設定されていないため、当該機能は利用できません。
		/// </summary>

// 		public static readonly string SC_MS_07_S02_01 = "決算期が設定されていないため、当該機能は利用できません。";
		public static string SC_MS_07_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000864");}
		}

		/// <summary>
		/// 調整理由マスタが設定されていないため、自動仕訳マスタの設定をすることはできません。
		/// </summary>

// 		public static readonly string SC_MS_08_S02_01 = "調整理由マスタが設定されていないため、自動仕訳マスタの設定をすることはできません。";
		public static string SC_MS_08_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001249");}
		}

		/// <summary>
		/// 自動仕訳商品グループマスタが設定されていないため、自動仕訳マスタの設定をすることはできません。
		/// </summary>

// 		public static readonly string SC_MS_08_S02_02 = "自動仕訳商品グループマスタが設定されていないため、自動仕訳マスタの設定をすることはできません。";
		public static string SC_MS_08_S02_02
		{
			get {return MultiLanguage.Get("CM_AM001073");}
		}

		/// <summary>
		///  この仕訳で指定できる明細の数は%sつです。過不足は許されません。
		/// </summary>
		public static string SC_MS_08_S02_03(string count)
		{

// 			return new StringBuilder("この仕訳で指定できる明細の数は", 64).Append(count).Append("つです。過不足は許されません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001603"), count);

		}
		/// <summary>
		/// 棚卸差異理由マスタが設定されていないため、自動仕訳マスタの設定をすることはできません。
		/// </summary>

// 		public static readonly string SC_MS_08_S02_04 = "棚卸差異理由マスタが設定されていないため、自動仕訳マスタの設定をすることはできません。";
		public static string SC_MS_08_S02_04
		{
			get {return MultiLanguage.Get("CM_AM001241");}
		}

		/// <summary>
		/// 有効なセット品明細がありません。
		/// </summary>

// 		public static readonly string SC_MS_09_S02_01 = "有効なセット品明細がありません。";
		public static string SC_MS_09_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001405");}
		}

		#endregion
		#region SC_SD
		/// <summary>
		/// 取引先の与信限度額を超えています。更新しますか？
		/// </summary>

// 		public static readonly string SC_SD_S00001 = "取引先の与信限度額を超えています。更新しますか？";
		public static string SC_SD_S00001
		{
			get {return MultiLanguage.Get("CM_AM001092");}
		}

		/// <summary>
		/// 取引先グループの与信限度額を超えています。更新しますか？
		/// </summary>

// 		public static readonly string SC_SD_S00002 = "取引先グループの与信限度額を超えています。更新しますか？";
		public static string SC_SD_S00002
		{
			get {return MultiLanguage.Get("CM_AM001087");}
		}

		/// <summary>
		/// 取引先の与信限度額を超えています。
		/// </summary>

// 		public static readonly string SC_SD_S10001 = "取引先の与信限度額を超えています。";
		public static string SC_SD_S10001
		{
			get {return MultiLanguage.Get("CM_AM001091");}
		}

		/// <summary>
		/// 取引先グループの与信限度額を超えています。
		/// </summary>

// 		public static readonly string SC_SD_S10002 = "取引先グループの与信限度額を超えています。";
		public static string SC_SD_S10002
		{
			get {return MultiLanguage.Get("CM_AM001086");}
		}

		/// <summary>
		/// この商品は販売を許可されていません。
		/// </summary>

// 		public static readonly string SC_SD_S10003 = "この商品は販売を許可されていません。";
		public static string SC_SD_S10003
		{
			get {return MultiLanguage.Get("CM_AM000554");}
		}

		/// <summary>
		/// %s時に、値引商品は入力できません。
		/// </summary>
		/// <param name="condition">条件</param>
		/// <returns><paramref name="condition"/>時に、値引商品は入力できません。</returns>
		public static string SC_SD_S10004(string condition)
		{

// 			return new StringBuilder(condition, 32).Append("時に、値引商品は入力できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001604"), condition);

		}
		/// <summary>
		/// 出荷依頼伝票を作成しました。
		/// </summary>

// 		public static readonly string SC_SD_S10005 = "出荷依頼伝票を作成しました。";
		public static string SC_SD_S10005
		{
			get {return MultiLanguage.Get("CM_AM001115");}
		}

		/// <summary>
		/// 出荷依頼伝票は作成されませんでした。
		/// </summary>

// 		public static readonly string SC_SD_S10006 = "出荷依頼伝票は作成されませんでした。";
		public static string SC_SD_S10006
		{
			get {return MultiLanguage.Get("CM_AM001114");}
		}

		/// <summary>
		/// 会計月度が登録されていません。
		/// </summary>

// 		public static readonly string SC_SD_S10007 = "会計月度が登録されていません。";
		public static string SC_SD_S10007
		{
			get {return MultiLanguage.Get("CM_AM000748");}
		}

		/// <summary>
		/// 決算期が登録されていません。
		/// </summary>

// 		public static readonly string SC_SD_S10008 = "決算期が登録されていません。";
		public static string SC_SD_S10008
		{
			get {return MultiLanguage.Get("CM_AM000865");}
		}

		/// <summary>
		/// 取引先セグメントが登録されていません。
		/// </summary>

// 		public static readonly string SC_SD_S10009 = "取引先セグメントが登録されていません。";
		public static string SC_SD_S10009
		{
			get {return MultiLanguage.Get("CM_AM001090");}
		}

		/// <summary>
		/// 商品セグメントが登録されていません。
		/// </summary>

// 		public static readonly string SC_SD_S10010 = "商品セグメントが登録されていません。";
		public static string SC_SD_S10010
		{
			get {return MultiLanguage.Get("CM_AM001142");}
		}

		/// <summary>
		/// 保存先のパスが正しく設定されていません。
		/// </summary>

// 		public static readonly string SC_SD_S10011 = "保存先のパスが正しく設定されていません。";
		public static string SC_SD_S10011
		{
			get {return MultiLanguage.Get("CM_AM001384");}
		}

		/// <summary>
		/// 与信限度金額をオーバーしております。
		/// </summary>
		public static string SC_SD_S10012
		{
			get { return MultiLanguage.Get("CM_AM001778"); }
		}

		/// <summary>
		/// 該当する案件伝票は存在しません。
		/// </summary>

// 		public static readonly string SC_SD_03_S02_01 = "該当する案件伝票は存在しません。";
		public static string SC_SD_03_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000764");}
		}

		/// <summary>
		/// 指定された見積番号は存在しないか、既に他のプロスペクトに関連づけられています。
		/// </summary>

// 		public static readonly string SC_SD_03_S02_02 = "指定された見積番号は存在しないか、既に他のプロスペクトに関連づけられています。";
		public static string SC_SD_03_S02_02
		{
			get {return MultiLanguage.Get("CM_AM001007");}
		}

		/// <summary>
		/// プロスペクト添付資料ID の採番に失敗しました。
		/// </summary>

// 		public static readonly string SC_SD_03_S03_01 = "プロスペクト添付資料ID の採番に失敗しました。";
		public static string SC_SD_03_S03_01
		{
			get {return MultiLanguage.Get("CM_AM000658");}
		}

		/// <summary>
		/// 見積番号の新しい枝番を取得できませんでした。
		/// </summary>

// 		public static readonly string SC_SD_04_S02_01 = "見積番号の新しい枝番を取得できませんでした。";
		public static string SC_SD_04_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000878");}
		}

		/// <summary>
		/// この見積に対しては既に受注が発生しているので削除できません。
		/// </summary>

// 		public static readonly string SC_SD_04_S02_02 = "この見積に対しては既に受注が発生しているので削除できません。";
		public static string SC_SD_04_S02_02
		{
			get {return MultiLanguage.Get("CM_AM000545");}
		}

		/// <summary>
		/// 該当する見積伝票は存在しません。
		/// </summary>

// 		public static readonly string SC_SD_04_S02_03 = "該当する見積伝票は存在しません。";
		public static string SC_SD_04_S02_03
		{
			get {return MultiLanguage.Get("CM_AM000765");}
		}

		/// <summary>
		/// 見積依頼受付完了のご連絡
		/// </summary>

// 		public static readonly string SC_SD_04_S02_MailSubject = "見積依頼受付完了のご連絡";
		public static string SC_SD_04_S02_MailSubject
		{
			get {return MultiLanguage.Get("CM_AM000875");}
		}

		/// <summary>
		/// 御社よりご指示いただいた下記の見積依頼について承りました。
		/// </summary>

// 		public static readonly string SC_SD_04_S02_MailHeader = "御社よりご指示いただいた下記の見積依頼について承りました。";
		public static string SC_SD_04_S02_MailHeader
		{
			get {return MultiLanguage.Get("CM_AM000893");}
		}

		/// <summary>
		/// 以上
		/// </summary>

// 		public static readonly string SC_SD_04_S02_MailFooter = "以上";
		public static string SC_SD_04_S02_MailFooter
		{
			get {return MultiLanguage.Get("CM_AM000713");}
		}

		/// <summary>
		/// 見積添付資料ID の採番に失敗しました。
		/// </summary>

// 		public static readonly string SC_SD_04_S03_01 = "見積添付資料ID の採番に失敗しました。";
		public static string SC_SD_04_S03_01
		{
			get {return MultiLanguage.Get("CM_AM000876");}
		}

		/// <summary>
		/// 社内発注、出荷依頼、出荷または売上された数量よりも小さな数量を入力できません。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_01 = "社内発注、出荷依頼、出荷または売上された数量よりも小さな数量を入力できません。";
		public static string SC_SD_05_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001623");}
		}

		/// <summary>
		/// 既に社内発注、出荷依頼、出荷または売上されているためこの明細を削除できません。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_02 = "既に社内発注、出荷依頼、出荷または売上されているためこの明細を削除できません。";
		public static string SC_SD_05_S02_02
		{
			get {return MultiLanguage.Get("CM_AM001624");}
		}

		/// <summary>
		/// この商品は直送を選択できません。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_03 = "この商品は直送を選択できません。";
		public static string SC_SD_05_S02_03
		{
			get {return MultiLanguage.Get("CM_AM000552");}
		}

		/// <summary>
		/// 既に社内発注、出荷依頼、出荷または売上されているため明細の商品、規格、単位、倉庫を変更できません。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_04 = "既に社内発注、出荷依頼、出荷または売上されているため明細の商品、規格、単位、倉庫を変更できません。";
		public static string SC_SD_05_S02_04
		{
			get {return MultiLanguage.Get("CM_AM001625");}
		}

		/// <summary>
		/// 既に出荷依頼、出荷または売上されているためこの受注を削除できません。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_05 = "既に出荷依頼、出荷または売上されているためこの受注を削除できません。";
		public static string SC_SD_05_S02_05
		{
			get {return MultiLanguage.Get("CM_AM000793");}
		}

		/// <summary>
		/// 直送時に、売上計上基準は検収基準になります。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_06 = "直送時に、売上計上基準は検収基準になります。";
		public static string SC_SD_05_S02_06
		{
			get {return MultiLanguage.Get("CM_AM001251");}
		}

		/// <summary>
		/// 明細に預り在庫が引当られている商品、在庫管理をしない商品、制御商品、仮単価の商品がある時に、売上計上基準を出荷基準にできません。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_07 = "明細に預り在庫が引当られている商品、在庫管理をしない商品、制御商品、仮単価の商品がある時に、売上計上基準を出荷基準にできません。";
		public static string SC_SD_05_S02_07
		{
			get {return MultiLanguage.Get("CM_AM001400");}
		}

		/// <summary>
		/// 既に出荷依頼されているため受渡場所は変更できません。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_08 = "既に出荷依頼されているため受渡場所は変更できません。";
		public static string SC_SD_05_S02_08
		{
			get {return MultiLanguage.Get("CM_AM000802");}
		}

		/// <summary>
		/// 既に出荷依頼、売上されているためこの明細の商品、規格、単位、倉庫を変更することはできません。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_09 = "既に出荷依頼、売上されているためこの明細の商品、規格、単位、倉庫を変更することはできません。";
		public static string SC_SD_05_S02_09
		{
			get {return MultiLanguage.Get("CM_AM000801");}
		}

		/// <summary>
		/// %s は在庫が不足しているため引当を行いませんでした。別途引当を行う必要があります。
		/// </summary>
		/// <param name="value">商品名</param>
		/// <returns><paramref name="value"/> は在庫が不足しているため引当を行いませんでした。別途引当を行う必要があります。</returns>
		public static string SC_SD_05_S02_10(string value)
		{

// 			return new StringBuilder("商品 ", 64).Append(value).Append(" は在庫が不足しているため引当を行いませんでした。別途引当を行う必要があります。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001605"), value);

		}
		/// <summary>
		/// %s、%s、 ... は在庫が不足しているため引当を行いませんでした。別途引当を行う必要があります。
		/// </summary>
		/// <param name="values">商品名</param>
		/// <returns><paramref name="values"/>、<paramref name="values"/>、 ... は在庫が不足しているため引当を行いませんでした。別途引当を行う必要があります。</returns>
		public static string SC_SD_05_S02_10(params string[] values)
		{
			switch (values.Length)
			{
				case 0:
// 					return "在庫が不足しているため引当を行いませんでした。別途引当を行う必要があります。"; 
					return MultiLanguage.Get("CM_AM000940");
				case 1:
					return SC_SD_05_S02_10(values[0]);
				default:
// 					StringBuilder sb = new StringBuilder("商品 ", 64); 
					StringBuilder sb = new StringBuilder(MultiLanguage.Get("CM_AM001141"), 64);
					foreach (string value in values)
					{
// 						sb.Append(value).Append("、"); 
						sb.Append(value).Append(MultiLanguage.Get("CM_AM000128"));
					}
					sb.Remove(sb.Length - 1, 1);
// 					sb.Append(" は在庫が不足しているため引当を行いませんでした。別途引当を行う必要があります。"); 
					sb.Append(MultiLanguage.Get("CM_AM000041"));
					return sb.ToString();
			}
		}
		/// <summary>
		/// 通常受注、事後受注から仮受注へ変更することはできません。また、事後受注、通常受注の受注区分を変更することはできません。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_11 = "通常受注、事後受注から仮受注へ変更することはできません。また、事後受注、通常受注の受注区分を変更することはできません。";
		public static string SC_SD_05_S02_11
		{
			get {return MultiLanguage.Get("CM_AM001254");}
		}

		/// <summary>
		/// この受注に対して引当が行われていた発注、社内受発注、製造指図があります。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_12 = "この受注に対して引当が行われていた発注、社内受発注、製造指図があります。";
		public static string SC_SD_05_S02_12
		{
			get {return MultiLanguage.Get("CM_AM000547");}
		}

		/// <summary>
		/// 入力された得意先は得意先倉庫を持たないため %s は選択できません。
		/// </summary>
		/// <returns><paramref name="value"/>入力された得意先は得意先倉庫を持たないため</returns>
		/// <param name="value">委託受注文言</param>
		/// <returns><paramref name="value"/>は選択できません。</returns>
		public static string SC_SD_05_S02_13(string value)
		{

// 			return new StringBuilder("入力された得意先は得意先倉庫を持たないため ", 34).Append(value).Append("は選択できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001607"), value);

		}
		/// <summary>
		/// 既に社内発注、出荷依頼、出荷または売上されているため受注形態を変更できません。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_14 = "既に社内発注、出荷依頼、出荷または売上されているため受注形態を変更できません。";
		public static string SC_SD_05_S02_14
		{
			get {return MultiLanguage.Get("CM_AM001626");}
		}

		/// <summary>
		/// 在庫管理する商品を選択したときは倉庫は必須です。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_15 = "在庫管理する商品を選択したときは倉庫は必須です。";
		public static string SC_SD_05_S02_15
		{
			get {return MultiLanguage.Get("CM_AM000943");}
		}

		/// <summary>
		/// 在庫が不足している商品があるため出荷依頼伝票を作成できませんでした。出荷依頼区分を ［後日］ にして更新をしてください。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_16 = "在庫が不足している商品があるため出荷依頼伝票を作成できませんでした。 ［出荷依頼区分］ を後日にして更新をしてください。";
		public static string SC_SD_05_S02_16
		{
			get {return MultiLanguage.Get("CM_AM000941");}
		}

		/// <summary>
		/// 売上計上基準が出荷基準の場合、明細に直送倉庫を指定することはできません。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_17 = "売上計上基準が出荷基準の場合、明細に直送倉庫を指定することはできません。";
		public static string SC_SD_05_S02_17
		{
			get {return MultiLanguage.Get("CM_AM001339");}
		}

		/// <summary>
		/// 回収方法が手形、期日決済を選択時は、サイトは必須です。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_18 = "回収方法が手形、期日決済を選択時は、サイトは必須です。";
		public static string SC_SD_05_S02_18
		{
			get {return MultiLanguage.Get("CM_AM000753");}
		}

		/// <summary>
		/// 比率が100%以外の数値入力時は、回収方法3は必須です。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_19 = "比率が100%以外の数値入力時は、回収方法3は必須です。";
		public static string SC_SD_05_S02_19
		{
			get {return MultiLanguage.Get("CM_AM001354");}
		}

		/// <summary>
		/// 既に社内発注、出荷依頼、出荷または売上されているため得意先を変更できません。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_20 = "既に社内発注、出荷依頼、出荷または売上されているため得意先を変更できません。";
		public static string SC_SD_05_S02_20
		{
			get {return MultiLanguage.Get("CM_AM001627");}
		}

		/// <summary>
		/// 既に引当されているため%sを変更できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>既に引当されているため<paramref name="item"/>を変更できません。</returns>
		public static string SC_SD_05_S02_21(string item)
		{

// 			return new StringBuilder("既に引当されているため").Append(item).Append("を変更できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001608"), item);

		}
		/// <summary>
		/// 既に受注数量を超えて売上数量が指示されているため、数量を変更できません。
		/// </summary>

// 		public static readonly string SC_SD_05_S02_22 = "既に受注数量を超えて売上数量が指示されているため、数量を変更できません。";
		public static string SC_SD_05_S02_22
		{
			get {return MultiLanguage.Get("CM_AM000790");}
		}
		/// <summary>
		/// 既に社内発注、出荷依頼、出荷または売上されているためこの受注を削除できません。
		/// </summary>
// 		public static readonly string SC_SD_05_S02_23 = "既に社内発注、出荷依頼、出荷または売上されているためこの受注を削除できません。";
		public static string SC_SD_05_S02_23
		{
			get {return MultiLanguage.Get("CM_AM001628");}
		}
		/// <summary>
		/// 既に社内発注、出荷依頼、出荷または売上されているため、[%s]を変更できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>既に社内発注、出荷依頼、出荷または売上されているため、<paramref name="item"/>を変更できません。</returns>
		public static string SC_SD_05_S02_24(string item)
		{
//			return new StringBuilder("既に社内発注、出荷依頼、出荷または売上されているため、[").Append(item).Append("]を変更できません。").ToString();
			return string.Format(MultiLanguage.Get("CM_AM001629"), item);
		}
		/// <summary>
		/// 明細に預り在庫が引当られている商品がある時に、受注形態を委託にできません。
		/// </summary>
		public static string SC_SD_05_S02_25
		{
			get { return MultiLanguage.Get("CM_AM001666"); }
		}
		/// <summary>
		/// 売上計上基準が出荷基準、または受注形態区分が委託の場合、預り在庫を引当することはできません。
		/// </summary>
		public static string SC_SD_05_S02_26
		{
			get { return MultiLanguage.Get("CM_AM001676"); }
		}
		/// <summary>
		/// [%s]行目：既に社内発注、出庫依頼、出荷または売上されているためこのロット引当を削除できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>[<paramref name="item"/>]行目：既に社内発注、出庫依頼、出荷または売上されているためこのロット引当を削除できません。</returns>
		public static string SC_SD_05_S02_27(string item)
		{
			return string.Format(MultiLanguage.Get("CM_AM001656"), item);
		}
		/// <summary>
		/// 未引当数量以上の引当数量は指示できません。
		/// </summary>
		public static string SC_SD_05_S02_28
		{
			get { return MultiLanguage.Get("CM_AM001658"); }
		}
		/// <summary>
		/// [%s]行目：未引当数量以上の引当数量は指示できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns>[<paramref name="lineNo"/>]行目：未引当数量以上の引当数量は指示できません。</returns>
		public static string SC_SD_05_S02_29(string lineNo)
		{
			return string.Format(MultiLanguage.Get("CM_AM001659"), lineNo);
		}
		/// <summary>
		/// [%s]行目：社内発注、出荷依頼、出荷または売上された数量よりも小さな引当数量を入力できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns>[<paramref name="item"/>]行目：社内発注、出荷依頼、出荷または売上された数量よりも小さな引当数量を入力できません。</returns>
		public static string SC_SD_05_S02_30(string lineNo)
		{
			return string.Format(MultiLanguage.Get("CM_AM001693"), lineNo);
		}
		/// <summary>
		/// 比率の合計は100%になるように指定してください。
		/// </summary>

// 		public static readonly string SC_SD_05_S04_01 = "比率の合計は 100% になるように指定してください。";
		public static string SC_SD_05_S04_01
		{
			get {return MultiLanguage.Get("CM_AM001356");}
		}

		/// <summary>
		/// 出荷依頼数量は未依頼数量＋返品数量以上、出荷数量以下には変更できません。
		/// </summary>

// 		public static readonly string SC_SD_06_S02_01 = "出荷依頼数量は未依頼数量＋返品数量以上、出荷数量以下には変更できません。";
		public static string SC_SD_06_S02_01
		{
			get {return MultiLanguage.Get("CM_AM001112");}
		}

		/// <summary>
		/// 既に出荷が発生しているので出荷依頼を削除できません。
		/// </summary>

// 		public static readonly string SC_SD_06_S02_02 = "既に出荷が発生しているので出荷依頼を削除できません。";
		public static string SC_SD_06_S02_02
		{
			get {return MultiLanguage.Get("CM_AM000791");}
		}

		/// <summary>
		/// 参照している受注に対して出荷依頼指示できません。
		/// </summary>

// 		public static readonly string SC_SD_06_S02_03 = "参照している受注に対して出荷依頼指示できません。";
		public static string SC_SD_06_S02_03
		{
			get {return MultiLanguage.Get("CM_AM000962");}
		}

		/// <summary>
		/// 参照している社内受発注に対して出荷依頼指示できません。
		/// </summary>

// 		public static readonly string SC_SD_06_S02_04 = "参照している社内受発注に対して出荷依頼指示できません。";
		public static string SC_SD_06_S02_04
		{
			get {return MultiLanguage.Get("CM_AM000961");}
		}

		/// <summary>
		/// 出荷依頼金額が与信限度額を超えています。
		/// </summary>

// 		public static readonly string SC_SD_06_S02_05 = "出荷依頼金額が与信限度額を超えています。";
		public static string SC_SD_06_S02_05
		{
			get {return MultiLanguage.Get("CM_AM001110");}
		}

		/// <summary>
		/// 有効な出荷依頼明細がありません。
		/// </summary>

// 		public static readonly string SC_SD_06_S02_06 = "有効な出荷依頼明細がありません。";
		public static string SC_SD_06_S02_06
		{
			get {return MultiLanguage.Get("CM_AM001406");}
		}

		/// <summary>
		/// 出荷依頼数量は引当済数量以上に指示できません。
		/// </summary>

// 		public static readonly string SC_SD_06_S02_07 = "出荷依頼数量は引当済数量以上に指示できません。";
		public static string SC_SD_06_S02_07
		{
			get {return MultiLanguage.Get("CM_AM001111");}
		}

		/// <summary>
		/// 参照している伝票は残クローズされている為削除できません。
		/// </summary>

// 		public static readonly string SC_SD_06_S02_08 = "参照している伝票は残クローズされている為削除できません。";
		public static string SC_SD_06_S02_08
		{
			get {return MultiLanguage.Get("CM_AM000970");}
		}

		/// <summary>
		/// 出荷依頼数量は出荷数量未満には指示できません。
		/// </summary>

		public static string SC_SD_06_S02_09
		{
			get {return MultiLanguage.Get("CM_AM001675");}
		}

		/// <summary>
		/// ［在庫単位数量］の小数点以下の桁数が %d 桁を超える商品があるため、出荷依頼伝票を作成できませんでした。 ［出荷依頼区分］ を後日にして更新をしてください。
		/// </summary>
		/// <param name="decimalDigit">小数点以下の桁数</param>
		/// <returns>［在庫単位数量］ の小数点以下の桁数が <paramref name="decimalDigit"/> 桁を超える商品があるため、出荷依頼伝票を作成できませんでした。 ［出荷依頼区分］ を後日にして更新をしてください。</returns>
		public static string SC_SD_06_S02_10(decimal decimalDigit)
		{
			return string.Format(MultiLanguage.Get("CM_AM001737"), decimalDigit);
		}

		/// <summary>
		/// 出荷依頼数量は未依頼数量以上には変更できません。
		/// </summary>

// 		public static readonly string SC_SD_06_S03_01 = "出荷依頼数量は未依頼数量を超えて指示できません。";
		public static string SC_SD_06_S03_01
		{
			get {return MultiLanguage.Get("CM_AM001113");}
		}

		/// <summary>
		/// 既に出荷返品・売上が発生しているので出荷を削除できません。
		/// </summary>

// 		public static readonly string SC_SD_07_S02_01 = "既に出荷返品・売上が発生しているので出荷を削除できません。";
		public static string SC_SD_07_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000803");}
		}

		/// <summary>
		/// 有効な出荷明細がありません。
		/// </summary>

// 		public static readonly string SC_SD_07_S02_02 = "有効な出荷明細がありません。";
		public static string SC_SD_07_S02_02
		{
			get {return MultiLanguage.Get("CM_AM001407");}
		}

		/// <summary>
		/// その出荷依頼伝票に対して出荷指示できません。
		/// </summary>

// 		public static readonly string SC_SD_07_S02_03 = "その出荷依頼伝票に対して出荷指示できません。";
		public static string SC_SD_07_S02_03
		{
			get {return MultiLanguage.Get("CM_AM000581");}
		}

		/// <summary>
		/// ロット詳細入力で指示した数量と出荷数量が異なっています。
		/// </summary>

// 		public static readonly string SC_SD_07_S02_04 = "ロット詳細入力で指示した数量と出荷数量が異なっています。";
		public static string SC_SD_07_S02_04
		{
			get {return MultiLanguage.Get("CM_AM000692");}
		}

		/// <summary>
		/// 出荷依頼数量は引当済数量以上に指示できません。
		/// </summary>

// 		public static readonly string SC_SD_07_S02_05 = "出荷依頼数量は引当済数量以上に指示できません。";
		public static string SC_SD_07_S02_05
		{
			get {return MultiLanguage.Get("CM_AM001111");}
		}

		/// <summary>
		/// 出荷数量は未出荷数以上には指示できません。
		/// </summary>

// 		public static readonly string SC_SD_07_S02_06 = "出荷数量は未出荷数以上には指示できません。";
		public static string SC_SD_07_S02_06
		{
			get {return MultiLanguage.Get("CM_AM001120");}
		}

		/// <summary>
		/// 出荷数量は在庫引当数量以上には指示できません。
		/// </summary>

// 		public static readonly string SC_SD_07_S02_07 = "出荷数量は在庫引当数量以上には指示できません。";
		public static string SC_SD_07_S02_07
		{
			get {return MultiLanguage.Get("CM_AM001118");}
		}

		/// <summary>
		/// 該当する出荷伝票は存在しません。
		/// </summary>

// 		public static readonly string SC_SD_07_S02_08 = "該当する出荷伝票は存在しません。";
		public static string SC_SD_07_S02_08
		{
			get {return MultiLanguage.Get("CM_AM000768");}
		}

		/// <summary>
		/// 出荷数量は売上数量未満には指示できません。
		/// </summary>

// 		public static readonly string SC_SD_07_S02_09 = "出荷数量は売上数量未満には指示できません。";
		public static string SC_SD_07_S02_09
		{
			get {return MultiLanguage.Get("CM_AM001119");}
		}

		/// <summary>
		/// 返品数量は売上未計上数量以上には指示できません。
		/// </summary>

// 		public static readonly string SC_SD_07_S02_10 = "返品数量は売上未計上数量以上には指示できません。";
		public static string SC_SD_07_S02_10
		{
			get {return MultiLanguage.Get("CM_AM001383");}
		}

		/// <summary>
		/// 実在庫がマイナスになりました。
		/// </summary>

// 		public static readonly string SC_SD_07_S02_11 = "実在庫がマイナスになりました。";
		public static string SC_SD_07_S02_11
		{
			get {return MultiLanguage.Get("CM_AM001079");}
		}

		/// <summary>
		/// 売上伝票が修正されているため変更を行いませんでした。別途売上伝票を修正してください。
		/// </summary>

// 		public static readonly string SC_SD_07_S02_12 = "売上伝票が修正されているため変更を行いませんでした。別途売上伝票を修正してください。";
		public static string SC_SD_07_S02_12
		{
			get {return MultiLanguage.Get("CM_AM001342");}
		}

		/// <summary>
		/// 売上済数量及び出荷返品数量以下には変更できません。
		/// </summary>

// 		public static readonly string SC_SD_07_S02_13 = "売上済数量及び出荷返品数量以下には変更できません。";
		public static string SC_SD_07_S02_13
		{
			get {return MultiLanguage.Get("CM_AM001340");}
		}

		/// <summary>
		/// 出荷ロット明細に対応する出荷依頼ロット明細が存在しません。
		/// </summary>
		public static string SC_SD_07_S02_14
		{
			get {return MultiLanguage.Get("CM_AM001765");}
		}

		/// <summary>
		/// 出荷返品数が入力されていません。
		/// </summary>

// 		public static readonly string SC_SD_07_S04_01 = "出荷返品数が入力されていません。";
		public static string SC_SD_07_S04_01
		{
			get {return MultiLanguage.Get("CM_AM001122");}
		}

		/// <summary>
		/// 参照している出荷に対して出荷返品指示できません。
		/// </summary>

// 		public static readonly string SC_SD_07_S04_02 = "参照している出荷に対して出荷返品指示できません。";
		public static string SC_SD_07_S04_02
		{
			get {return MultiLanguage.Get("CM_AM000965");}
		}

		/// <summary>
		/// 該当する出荷返品伝票は存在しません。
		/// </summary>

// 		public static readonly string SC_SD_07_S04_03 = "該当する出荷返品伝票は存在しません。";
		public static string SC_SD_07_S04_03
		{
			get {return MultiLanguage.Get("CM_AM000769");}
		}

		/// <summary>
		/// ロット詳細入力で指示した数量と出荷返品数量が異なっています。
		/// </summary>

// 		public static readonly string SC_SD_07_S04_04 = "ロット詳細入力で指示した数量と出荷返品数量が異なっています。";
		public static string SC_SD_07_S04_04
		{
			get {return MultiLanguage.Get("CM_AM000693");}
		}

		/// <summary>
		/// 修正時は出荷返品数量を 0 にはできません。
		/// </summary>

// 		public static readonly string SC_SD_07_S04_05 = "修正時は出荷返品数量を 0 にはできません。";
		public static string SC_SD_07_S04_05
		{
			get {return MultiLanguage.Get("CM_AM001104");}
		}

		/// <summary>
		/// 納品書兼請求書の出力対象です。
		/// </summary>

// 		public static readonly string SC_SD_07_S05_01 = "納品書兼請求書の出力対象です。";
		public static string SC_SD_07_S05_01
		{
			get {return MultiLanguage.Get("CM_AM001332");}
		}

		/// <summary>
		/// 印刷対象行を選択してください。
		/// </summary>

// 		public static readonly string SC_SD_07_S05_02 = "印刷対象行を選択してください。";
		public static string SC_SD_07_S05_02
		{
			get {return MultiLanguage.Get("CM_AM000733");}
		}

		/// <summary>
		/// 納品書出力対象の得意先ではありません。
		/// </summary>

// 		public static readonly string SC_SD_07_S05_03 = "納品書出力対象の得意先ではありません。";
		public static string SC_SD_07_S05_03
		{
			get {return MultiLanguage.Get("CM_AM001333");}
		}

		/// <summary>
		/// 出荷処理を開始しました。
		/// </summary>

// 		public static readonly string SC_SD_07_S05_04 = "出荷処理を開始しました。";
		public static string SC_SD_07_S05_04
		{
			get {return MultiLanguage.Get("CM_AM001116");}
		}

		/// <summary>
		/// 印刷対象に運送業者が入力されていない伝票が存在する、または複数の運送業者が指示されています。運送業者を入力する、または運送業者を統一して印刷してください。
		/// </summary>

// 		public static readonly string SC_SD_07_S05_05 = "印刷対象に運送業者が入力されていない伝票が存在する、または複数の運送業者が指示されています。\r\n運送業者を入力する、または運送業者を統一して印刷してください。";
		public static string SC_SD_07_S05_05
		{
			get {return MultiLanguage.Get("CM_AM000732");}
		}

		/// <summary>
		/// 出荷承認を使用しない設定の為、当該機能は利用できません。
		/// </summary>

// 		public static readonly string SC_SD_07_S11_01 = "出荷承認を使用しない設定の為、当該機能は利用できません。";
		public static string SC_SD_07_S11_01
		{
			get {return MultiLanguage.Get("CM_AM001117");}
		}

		/// <summary>
		/// 参照している受注に対して売上計上できません。
		/// </summary>

// 		public static readonly string SC_SD_08_S02_01 = "参照している受注に対して売上を計上できません。";
		public static string SC_SD_08_S02_01
		{
			get {return MultiLanguage.Get("CM_AM000964");}
		}

		/// <summary>
		/// 参照している出荷に対して売上計上できません。
		/// </summary>

// 		public static readonly string SC_SD_08_S02_02 = "参照している出荷に対して売上を計上できません。";
		public static string SC_SD_08_S02_02
		{
			get {return MultiLanguage.Get("CM_AM000966");}
		}

		/// <summary>
		/// 参照している売上に対して売上返品できません。
		/// </summary>

// 		public static readonly string SC_SD_08_S02_03 = "参照している売上に対して売上返品できません。";
		public static string SC_SD_08_S02_03
		{
			get {return MultiLanguage.Get("CM_AM000974");}
		}

		/// <summary>
		/// 該当する売上伝票は存在しません。
		/// </summary>

// 		public static readonly string SC_SD_08_S02_04 = "該当する売上伝票は存在しません。";
		public static string SC_SD_08_S02_04
		{
			get {return MultiLanguage.Get("CM_AM000772");}
		}

		/// <summary>
		/// 最終販売締処理日以前の伝票を入力することはできません。
		/// </summary>

// 		public static readonly string SC_SD_08_S02_05 = "最終販売締処理日以前の伝票を入力することはできません。";
		public static string SC_SD_08_S02_05
		{
			get {return MultiLanguage.Get("CM_AM000934");}
		}

		/// <summary>
		/// 請求締の完了した伝票は削除不可です。
		/// </summary>

// 		public static readonly string SC_SD_08_S02_06 = "請求締の完了した伝票は削除不可です。";
		public static string SC_SD_08_S02_06
		{
			get {return MultiLanguage.Get("CM_AM001187");}
		}

		/// <summary>
		/// 売上数量は出荷数量以上には指示できません。
		/// </summary>
		//public static readonly string SC_SD_08_S02_07 = "売上数量は出荷数量以上には指示できません。";
		public static string SC_SD_08_S02_07(string lineNo)
		{
			if (lineNo.Length!=0)
			{

				// 				return new StringBuilder(lineNo, 32).Append(" 行目： 売上数量は出荷数量以上には指示できません。").ToString(); 
				return string.Format(MultiLanguage.Get("CM_AM001609"), lineNo);

			}
			else
			{
// 				return new StringBuilder("売上数量は出荷数量以上には指示できません。").ToString(); 
				return new StringBuilder(MultiLanguage.Get("CM_AM001341")).ToString();
			}
		}
		/// <summary>
		/// 売上返品数量は売上数量以上には指示できません。
		/// </summary>
		//public static readonly string SC_SD_08_S02_08 = "売上返品数量は売上数量以上には指示できません。";
		public static string SC_SD_08_S02_08(string lineNo)
		{
			if (lineNo.Length!=0)
			{
// 				return new StringBuilder(lineNo, 32).Append(" 行目： 売上返品数量は売上数量以上には指示できません。").ToString(); 
				return new StringBuilder(lineNo, 32).Append(MultiLanguage.Get("CM_AM000099")).ToString();
			}
			else
			{
// 				return new StringBuilder("売上返品数量は売上数量以上には指示できません。").ToString(); 
				return new StringBuilder(MultiLanguage.Get("CM_AM001344")).ToString();
			}
		}
		/// <summary>
		/// 入力された得意先は得意先倉庫を持たないため %s は選択できません。
		/// </summary>
		/// <returns><paramref name="value"/>入力された得意先は得意先倉庫を持たないため</returns>
		/// <param name="value">委託売上文言</param>
		/// <returns><paramref name="value"/>は選択できません。</returns>
		public static string SC_SD_08_S02_09(string value)
		{

// 			return new StringBuilder("入力された得意先は得意先倉庫を持たないため ", 34).Append(value).Append("は選択できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001611"), value);

		}
		/// <summary>
		/// 仕入計上が済んでいない、または海外未入荷分が存在するため指示できません。
		/// </summary>

// 		public static readonly string SC_SD_08_S02_10 = "仕入計上が済んでいない、または海外未入荷分が存在するため指示できません。";
		public static string SC_SD_08_S02_10
		{
			get {return MultiLanguage.Get("CM_AM000978");}
		}

		/// <summary>
		/// 承認済の請求が存在するため更新できません。
		/// </summary>

// 		public static readonly string SC_SD_08_S02_11 = "承認済の請求が存在するため更新できません。";
		public static string SC_SD_08_S02_11
		{
			get {return MultiLanguage.Get("CM_AM001149");}
		}

		/// <summary>
		/// 承認済の請求が存在するため削除できません。
		/// </summary>

// 		public static readonly string SC_SD_08_S02_12 = "承認済の請求が存在するため削除できません。";
		public static string SC_SD_08_S02_12
		{
			get {return MultiLanguage.Get("CM_AM001150");}
		}

		/// <summary>
		///  %s 行目： 売上返品数量は売上数量以下には指示できません。。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns><paramref name="lineNo"/> 行目： 売上返品数量は売上数量以下には指示できません。</returns>
		public static string SC_SD_08_S02_13(string lineNo)
		{
			if (lineNo.Length!=0)
			{

// 				return new StringBuilder(lineNo, 32).Append(" 行目： 売上返品数量は売上数量以下には指示できません。").ToString(); 
				return string.Format(MultiLanguage.Get("CM_AM001612"), lineNo);

			}
			else
			{
// 				return new StringBuilder("売上返品数量は売上数量以下には指示できません。").ToString(); 
				return new StringBuilder(MultiLanguage.Get("CM_AM001343")).ToString();
			}
		}
		/// <summary>
		///  %s 行目： マイナスの売上数量に対してプラスの売上返品数量は指定できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns><paramref name="lineNo"/> 行目： マイナスの売上数量に対してプラスの売上返品数量は指定できません。</returns>
		public static string SC_SD_08_S02_14(string lineNo)
		{
			if (lineNo.Length!=0)
			{

// 				return new StringBuilder(lineNo, 32).Append(" 行目： マイナスの売上数量に対してプラスの売上返品数量は指定できません。").ToString(); 
				return string.Format(MultiLanguage.Get("CM_AM001613"), lineNo);

			}
			else
			{
// 				return new StringBuilder("マイナスの売上数量に対してプラスの売上返品数量は指定できません。").ToString(); 
				return new StringBuilder(MultiLanguage.Get("CM_AM000663")).ToString();
			}
		}
		/// <summary>
		///  %s 行目： プラスの売上数量に対してマイナスの売上返品数量は指定できません。
		/// </summary>
		/// <param name="lineNo">行番号</param>
		/// <returns><paramref name="lineNo"/> 行目： プラスの売上数量に対してマイナスの売上返品数量は指定できません。</returns>
		public static string SC_SD_08_S02_15(string lineNo)
		{
			if (lineNo.Length!=0)
			{

// 				return new StringBuilder(lineNo, 32).Append(" 行目： プラスの売上数量に対してマイナスの売上返品数量は指示できません。").ToString(); 
				return string.Format(MultiLanguage.Get("CM_AM001614"), lineNo);

			}
			else
			{
// 				return new StringBuilder("プラスの売上数量に対してマイナスの売上返品数量は指定できません。").ToString(); 
				return new StringBuilder(MultiLanguage.Get("CM_AM000653")).ToString();
			}
		}
		/// <summary>
		/// ロット引当をする商品の場合、受注の引当済分を先に売上指示してください。
		/// </summary>
		public static string SC_SD_08_S02_16
		{
			get { return MultiLanguage.Get("CM_AM001685"); }
		}
		/// <summary>
		/// 消込が発生している伝票は削除不可です。
		/// </summary>
		public static string SC_SD_08_S02_17
		{
			get { return MultiLanguage.Get("CM_AM001787"); }
		}
		/// <summary>
		/// 比率の合計は100%になるように指定してください。
		/// </summary>

// 		public static readonly string SC_SD_08_S04_01 = "比率の合計は 100% になるように指定してください。";
		public static string SC_SD_08_S04_01
		{
			get {return MultiLanguage.Get("CM_AM001356");}
		}

		/// <summary>
		/// 回収条件は必須です。
		/// </summary>

// 		public static readonly string SC_SD_08_S04_02 = "回収条件は必須です。";
		public static string SC_SD_08_S04_02
		{
			get {return MultiLanguage.Get("CM_AM000752");}
		}

		/// <summary>
		/// 与信残高に不正な値が入力されています。
		/// </summary>

// 		public static readonly string SC_SD_09_S01_01 = "与信残高に不正な値が入力されています。";
		public static string SC_SD_09_S01_01
		{
			get {return MultiLanguage.Get("CM_AM001421");}
		}

		/// <summary>
		/// 同一の回収条件でなければコンバインできません。
		/// </summary>

// 		public static readonly string SC_SD_11_S01_01 = "同一の回収条件でなければコンバインできません。";
		public static string SC_SD_11_S01_01
		{
			get {return MultiLanguage.Get("CM_AM001279");}
		}

		/// <summary>
		/// L/C番号が異なるためコンバインできません。
		/// </summary>

// 		public static readonly string SC_SD_11_S01_02 = "L/C番号が異なるため、コンバインできません。";
		public static string SC_SD_11_S01_02
		{
			get {return MultiLanguage.Get("CM_AM000488");}
		}

		/// <summary>
		/// 分割船積不可の伝票は一部の明細を別の船積帳票とすることはできません。
		/// </summary>

// 		public static readonly string SC_SD_11_S01_03 = "分割船積不可の伝票は一部の明細を別の船積帳票とすることはできません。";
		public static string SC_SD_11_S01_03
		{
			get {return MultiLanguage.Get("CM_AM001375");}
		}

		/// <summary>
		/// 積換「有」と「無」の明細はコンバインできません。
		/// </summary>

// 		public static readonly string SC_SD_11_S01_04 = "積換「有」と「無」の明細はコンバインできません。";
		public static string SC_SD_11_S01_04
		{
			get {return MultiLanguage.Get("CM_AM001193");}
		}

		/// <summary>
		/// 得意先が異なるため、コンバイン出来ません。
		/// </summary>

// 		public static readonly string SC_SD_11_S01_05 = "得意先が異なるため、コンバイン出来ません。";
		public static string SC_SD_11_S01_05
		{
			get {return MultiLanguage.Get("CM_AM001287");}
		}

		/// <summary>
		/// 部門が異なるため、コンバイン出来ません。
		/// </summary>

// 		public static readonly string SC_SD_11_S01_06 = "部門が異なるため、コンバイン出来ません。";
		public static string SC_SD_11_S01_06
		{
			get {return MultiLanguage.Get("CM_AM001367");}
		}

		/// <summary>
		/// 通貨が異なるため、コンバイン出来ません。
		/// </summary>

// 		public static readonly string SC_SD_11_S01_07 = "通貨が異なるため、コンバイン出来ません。";
		public static string SC_SD_11_S01_07
		{
			get {return MultiLanguage.Get("CM_AM001253");}
		}

		/// <summary>
		/// %sは%s行以上入力できません。
		/// </summary>
		/// <param name="textName">コントロール名</param>
		/// <param name="lineCnt">行数</param>
		/// <returns><paramref name="textName"/>は<paramref name="lineCnt"/>行以上入力できません。</returns>
		public static string SC_SD_11_S03_01(string textName, string lineCnt)
		{

// 			return new StringBuilder(textName).Append("は").Append(lineCnt).Append("行以上入力できません。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001615"), textName, lineCnt);

		}
		/// <summary>
		/// ［%s］ は %d バイト以内で入力してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="maxByteLength">最大の長さ</param>
		/// <returns>［<paramref name="item"/>］ は <paramref name="maxByteLength"/> バイト以内で入力してください。</returns>
		public static string SC_SD_11_S03_02(string item, int maxByteLength)
		{

// 			return new StringBuilder("［").Append(item).Append("］ は ").Append(maxByteLength).Append(" バイト以内で入力してください。").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001616"), item, maxByteLength);

		}
		#endregion
		#region SC_EC
		/// <summary>
		/// %sのご連絡［%s］
		/// </summary>
		/// <param name="word">文言</param>
		/// <param name="slipNo">伝票番号</param>
		/// <returns></returns>
		public static string SC_EC_S10001(string word, string slipNo)
		{

// 			return new StringBuilder(word).Append("のご連絡［").Append(slipNo).Append("］").ToString(); 
			return string.Format(MultiLanguage.Get("CM_AM001617"), word, slipNo);

		}
		/// <summary>
		/// 御社より頂いた下記のご注文について承りました。
		/// </summary>

// 		public static readonly string SC_EC_S10002 = "御社より頂いた下記のご注文について承りました。";
		public static string SC_EC_S10002
		{
			get {return MultiLanguage.Get("CM_AM000900");}
		}

		/// <summary>
		/// 御社より頂いた下記のご注文について、取消し致しました。
		/// </summary>

// 		public static readonly string SC_EC_S10003 = "御社より頂いた下記のご注文について、取消し致しました。";
		public static string SC_EC_S10003
		{
			get {return MultiLanguage.Get("CM_AM000895");}
		}

		/// <summary>
		/// 御社より頂いた下記のご注文について、出荷指示を開始致しました。
		/// </summary>

// 		public static readonly string SC_EC_S10004 = "御社より頂いた下記のご注文について、出荷指示を開始致しました。";
		public static string SC_EC_S10004
		{
			get {return MultiLanguage.Get("CM_AM000897");}
		}

		/// <summary>
		/// 御社より頂いた下記のご注文について、出荷指示を取消し致しました。
		/// </summary>

// 		public static readonly string SC_EC_S10005 = "御社より頂いた下記のご注文について、出荷指示を取消し致しました。";
		public static string SC_EC_S10005
		{
			get {return MultiLanguage.Get("CM_AM000898");}
		}

		/// <summary>
		/// 御社より頂いた下記のご注文について、一部出荷を開始致しました。
		/// </summary>

// 		public static readonly string SC_EC_S10006 = "御社より頂いた下記のご注文について、一部出荷を開始致しました。";
		public static string SC_EC_S10006
		{
			get {return MultiLanguage.Get("CM_AM000894");}
		}
		/// <summary>
		/// 御社より頂いた下記のご注文について、全ての出荷を完了致しました。
		/// </summary>

// 		public static readonly string SC_EC_S10007 = "御社より頂いた下記のご注文について、全ての出荷を完了致しました。";
		public static string SC_EC_S10007
		{
			get {return MultiLanguage.Get("CM_AM000899");}
		}

		/// <summary>
		/// 御社より頂いた下記のご注文について、出荷を取消し致しました。
		/// </summary>

// 		public static readonly string SC_EC_S10008 = "御社より頂いた下記のご注文について、出荷を取消し致しました。";
		public static string SC_EC_S10008
		{
			get {return MultiLanguage.Get("CM_AM000896");}
		}

		/// <summary>
		/// 下記の発注を依頼致します。
		/// </summary>

// 		public static readonly string SC_EC_S10009 = "下記の発注を依頼致します。";
		public static string SC_EC_S10009
		{
			get {return MultiLanguage.Get("CM_AM000740");}
		}

		/// <summary>
		/// 下記の発注を変更しましたので、確認をお願い致します。
		/// </summary>

// 		public static readonly string SC_EC_S10010 = "下記の発注を変更しましたので、確認をお願い致します。";
		public static string SC_EC_S10010
		{
			get {return MultiLanguage.Get("CM_AM000742");}
		}

		/// <summary>
		/// 下記の発注を取消し致しました。
		/// </summary>

// 		public static readonly string SC_EC_S10011 = "下記の発注を取消し致しました。";
		public static string SC_EC_S10011
		{
			get {return MultiLanguage.Get("CM_AM000741");}
		}

		/// <summary>
		/// 現在、ゲストでのログインは出来ません。
		/// </summary>

// 		public static readonly string SC_EC_S10012 = "現在、ゲストでのログインは出来ません。";
		public static string SC_EC_S10012
		{
			get {return MultiLanguage.Get("CM_AM000883");}
		}

		/// <summary>
		/// カートには最大99商品まで登録が可能です。
		/// </summary>

		public static string SC_EC_S10013
		{
			get {return MultiLanguage.Get("CM_AM001742");}
		}

		/// <summary>
		/// 商品が99行を超えているため登録できません。
		/// </summary>

		public static string SC_EC_S10014
		{
			get {return MultiLanguage.Get("CM_AM001743");}
		}
		#endregion
		#region SC_XF
		/// <summary>
		/// 解約しました。
		/// </summary>
		public static readonly string SC_XF_S00001 = "解約しました。";
		/// <summary>
		/// 既に更新または削除されています。
		/// </summary>
		public static readonly string SC_XF_S10001 = "既に更新または削除されています。";
		/// <summary>
		/// ［端数桁］の指定が不正です。
		/// </summary>
		public static readonly string SC_XF_S10003 = "［端数桁］の指定が不正です。";
		/// <summary>
		/// 請求先マスタに［締日］が存在しません。
		/// </summary>
		public static readonly string SC_XF_S10006 = "請求先マスタに［締日］が存在しません。";
		/// <summary>
		/// 支払先マスタに［締日］が存在しません。
		/// </summary>
		public static readonly string SC_XF_S10007 = "支払先マスタに［締日］が存在しません。";
		/// <summary>
		/// ロット管理する商品は使用できません。
		/// </summary>
		public static readonly string SC_XF_S10008 = "ロット管理する商品は使用できません。";
		/// <summary>
		/// 請求先マスタに［前受締日］が存在しません。
		/// </summary>
		public static readonly string SC_XF_S10009 = "請求先マスタに［前受締日］が存在しません。";
		/// <summary>
		/// 支払先マスタに［前渡締日］が存在しません。
		/// </summary>
		public static readonly string SC_XF_S10010 = "支払先マスタに［前渡締日］が存在しません。";
		/// <summary>
		/// 該当する継続契約伝票は存在しません。
		/// </summary>
		public static readonly string SC_XF_03_S02_01 = "該当する継続契約伝票は存在しません。";
		/// <summary>
		/// 自動更新の対象となる継続契約は計上期間を12カ月以内にしてください。
		/// </summary>
		public static readonly string SC_XF_03_S02_02 = "［自動更新］設定時は［計上期間］は12ヶ月以内を選択してください。";
		/// <summary>
		/// ［明細行］は必須です。
		/// </summary>
		public static readonly string SC_XF_03_S02_03 = "［明細行］は必須です。";
		/// <summary>
		/// 売上が完了した受注伝票が存在するため、解約できません。
		/// </summary>
		public static readonly string SC_XF_03_S02_04 = "売上が完了した受注伝票が存在するため、解約できません。";
		/// <summary>
		/// 仕入が完了した発注伝票が存在するため、解約できません。
		/// </summary>
		public static readonly string SC_XF_03_S02_05 = "仕入が完了した発注伝票が存在するため、解約できません。";
		/// <summary>
		/// 承認ワークフローでエラーが発生しました。
		/// </summary>
		public static readonly string SC_XF_03_S02_06 = "承認ワークフローでエラーが発生しました。";
		/// <summary>
		/// 合算した与信チェックの金額がオーバーフローしました。与信チェックを行えません。
		/// </summary>
		public static readonly string SC_XF_03_S02_07 = "合算した与信チェックの金額がオーバーフローしました。与信チェックを行えません。";
		/// <summary>
		/// 金額が0円の場合は前受を指定できません。
		/// </summary>
		public static readonly string SC_XF_03_S03_01 = "金額が0円の場合は前受を指定できません。";
		/// <summary>
		/// 金額が0円の明細が作成されるため、前受を指定できません。
		/// </summary>
		public static readonly string SC_XF_03_S03_02 = "金額が0円の明細が作成されるため、前受を指定できません。";
		/// <summary>
		/// 適格請求書対応（自社（継続契約）で設定）の前受金を選択している場合、売上の回収条件に一括請求は選択できません。
		/// </summary>
		public static readonly string SC_XF_03_S03_03 = "適格請求書対応（自社（継続契約）で設定）の前受金を選択している場合、売上の回収条件に一括請求は選択できません。";
		/// <summary>
		/// 金額が0円の場合は前渡を指定できません。
		/// </summary>
		public static readonly string SC_XF_03_S04_01 = "金額が0円の場合は前渡を指定できません。";
		/// <summary>
		/// 金額が0円の明細が作成されるため、前渡を指定できません。
		/// </summary>
		public static readonly string SC_XF_03_S04_02 = "金額が0円の明細が作成されるため、前渡を指定できません。";
		/// <summary>
		/// 他のユーザが更新中につき、現在の処理は実行できません。
		/// </summary>
		public static readonly string SC_XF_03_S07_01 = "他のユーザが更新中につき、現在の処理を実行できません。";
		/// <summary>
		/// 他のユーザにより更新されたため、実行を中断しました。再度検索のうえ、あらためて実行ください。
		/// </summary>
		public static readonly string SC_XF_03_S07_02 = "他のユーザにより更新されたため、実行を中断しました。再度検索のうえ、あらためて実行ください。";
		/// <summary>
		/// 入力された年月は伝票入力が禁止されています。
		/// </summary>
		public static readonly string SC_XF_03_S51_01 = "入力された年月は伝票入力が禁止されています。";
		/// <summary>
		/// 計上開始月と計上終了月の間は99か月以内で入力してください。
		/// </summary>
		public static readonly string SC_XF_03_S98_01 = "計上開始月と計上終了月の間は99か月以内で入力してください。";
		/// <summary>
		/// ヘッダがありません。
		/// </summary>
		public static readonly string SC_XF_03_S98_02 = "ヘッダがありません。";
		/// <summary>
		/// 更新対象の継続契約データが存在しません。
		/// </summary>
		public static readonly string SC_XF_03_S98_04 = "更新対象の継続契約データが存在しません。";
		/// <summary>
		/// 継続契約処理前のデータのため解約はできません。
		/// </summary>
		public static readonly string SC_XF_03_S98_05 = "継続契約処理前のデータのため解約はできません。";
		/// <summary>
		/// 継続契約処理後のデータのため削除はできません。
		/// </summary>
		public static readonly string SC_XF_03_S98_06 = "継続契約処理後のデータのため削除はできません。";
		/// <summary>
		/// 継続契約処理後かつ更新申請中のデータのため解約はできません。
		/// </summary>
		public static readonly string SC_XF_03_S98_07 = "継続契約処理後かつ更新申請中のデータのため解約はできません。";
		/// <summary>
		/// 売上データ作成済みです。当該行の取込を行いません。
		/// </summary>
		public static readonly string SC_XF_03_S98_08 = "売上データ作成済みです。当該行の取込を行いません。";
		/// <summary>
		/// 仕入データ作成済みです。当該行の取込を行いません。
		/// </summary>
		public static readonly string SC_XF_03_S98_09 = "仕入データ作成済みです。当該行の取込を行いません。";
		/// <summary>
		/// 商品情報が取得できませんでした。商品コード、規格、単位の組み合わせが正しくありません。
		/// </summary>
		public static readonly string SC_XF_03_S98_13 = "商品情報が取得できませんでした。商品コード、規格、単位の組み合わせが正しくありません。";
		/// <summary>
		/// 更新区分は伝票単位で同じものを入力してください。
		/// </summary>
		public static readonly string SC_XF_03_S98_16 = "更新区分は伝票単位で同じものを入力してください。";
		/// <summary>
		/// 自動更新フラグが0：対象外の時、自動更新限度フラグは1：限度ありを入力することはできません。
		/// </summary>
		public static readonly string SC_XF_03_S98_17 = "自動更新フラグが0：対象外の時、自動更新限度フラグは1：限度ありを入力することはできません。";
		/// <summary>
		/// 既に削除されている継続契約です。
		/// </summary>
		public static readonly string SC_XF_03_S98_18 = "既に削除されている継続契約です。";
		/// <summary>
		/// 既に受注されているためこの明細を削除できません。
		/// </summary>
		public static readonly string SC_XF_03_S98_20 = "既に受注されているためこの明細を削除できません。";
		/// <summary>
		/// 既に解約されている継続契約です。
		/// </summary>
		public static readonly string SC_XF_03_S98_21 = "既に解約されている継続契約です。";

		/// <summary>
		/// に不正な日付が存在します。
		/// </summary>
		/// <param name="item">日付</param>
		/// <returns>itemに不正な日付が存在します。</returns>
		public static string SC_XF_S10002(string item)
		{
			return new StringBuilder("［", 32).Append(item).Append("］ に不正な日付が存在します。").ToString();
		}

		/// <summary>
		/// は計上期間内の日付を入力してください。
		/// </summary>
		/// <param name="item">日付</param>
		/// <returns>itemは計上期間内の日付を入力してください。</returns>
		public static string SC_XF_S10004(string item)
		{
			return new StringBuilder("［", 32).Append(item).Append("］ は計上期間内の日付を入力してください。").ToString();
		}

		/// <summary>
		/// ［%s］ の締サイクルが週単位の ［%s］ は使用できません。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>［item1］ の締サイクルが週単位の ［item2］ は使用できません。</returns>
		public static string SC_XF_S10005(string item1, string item2)
		{
			return new StringBuilder("［").Append(item1).Append("］ の締サイクルが週単位の ［").Append(item2).Append("］ は使用できません。").ToString();
		}

		/// <summary>
		/// ［%s］ は %s のいずれかを選択してください。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="choices">選択肢</param>
		/// <returns>［item］ は choices のいずれかを選択してください。</returns>
		public static string SC_XF_03_S98_10(string item, string choices)
		{
			return new StringBuilder("［").Append(item).Append("］ は ").Append(choices).Append(" のいずれかを選択してください。").ToString();
		}

		/// <summary>
		/// ［%s］ と ［%s］ の組み合わせが不正です。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <returns>［item1］ と ［item2］ の組み合わせが不正です。</returns>
		public static string SC_XF_03_S98_11(string item1, string item2)
		{
			return new StringBuilder("［").Append(item1).Append("］ と ［").Append(item2).Append("］ の組み合わせが不正です。").ToString();
		}

		/// <summary>
		/// ［%s］ と ［%s］ と ［%s］ の組み合わせが重複しています。
		/// </summary>
		/// <param name="item1">項目名1</param>
		/// <param name="item2">項目名2</param>
		/// <param name="item3">項目名3</param>
		/// <returns>［item1］ と ［item2］ と ［item3］ の組み合わせが重複しています。</returns>
		public static string SC_XF_03_S98_12(string item1, string item2, string item3)
		{
			return new StringBuilder("［").Append(item1).Append("］ と ［").Append(item2).Append("］ と ［").Append(item3).Append("］ の組み合わせが重複しています。").ToString();
		}

		/// <summary>
		/// ［%s］ は変更不可です。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>［item］ は変更不可です。</returns>
		public static string SC_XF_03_S98_19(string item)
		{
			return new StringBuilder("［").Append(item).Append("］ は変更不可です。").ToString();
		}
		/// <summary>
		/// 請求先マスタにて［%s］回収条件に都度が設定されているとき、一括を入力することはできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>請求先マスタにて［%s］回収条件に都度が設定されているとき、一括を入力することはできません。</returns>
		public static string SC_XF_03_S98_14(string item)
		{
			return new StringBuilder("請求先マスタにて").Append(item).Append("回収条件に都度が設定されているとき、一括を入力することはできません。").ToString();
		}
		/// <summary>
		/// 支払先マスタにて［%s］支払条件に都度が設定されているとき、一括を入力することはできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <returns>支払先マスタにて［%s］支払条件に都度が設定されているとき、一括を入力することはできません。</returns>
		public static string SC_XF_03_S98_15(string item)
		{
			return new StringBuilder("支払先マスタにて").Append(item).Append("支払条件に都度が設定されているとき、一括を入力することはできません。").ToString();
		}

		/// <summary>
		/// 削除済の明細に対し、 ［%s］ を%sへ更新できません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="condition">条件</param>
		/// <returns>削除済の明細に対し、 ［%s］ を%sへ更新できません。</returns>
		public static string SC_XF_03_S98_22(string item, string condition)
		{
			return new StringBuilder("削除済の明細に対し、 ［").Append(item).Append("］ を").Append(condition).Append("へ更新できません。").ToString();
		}

		/// <summary>
		/// ［%s］ が%sの明細を追加することはできません。
		/// </summary>
		/// <param name="item">項目名</param>
		/// <param name="condition">条件</param>
		/// <returns>［%s］ が%sの明細を追加することはできません。</returns>
		public static string SC_XF_03_S98_23(string item, string condition)
		{
			return new StringBuilder("［").Append(item).Append("］ が").Append(condition).Append("の明細を追加することはできません。").ToString();
		}
		#endregion
		#endregion
	}
}
