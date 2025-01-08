// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : StringFormat.cs
// 機能名      : 文字列整形用静的クラス
// Version     : 3.2.0
// Last Update : 2023/03/31
// Copyright (c) 2004-2023 Grandit Corp. All Rights Reserved.
//
// 管理番号 K25928 2016/03/03 ActiveReportsバージョンアップ
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30
// 管理番号K26520 2018/01/09 マスタWF添付機能拡充
// 3.0.0 2018/04/30
// 管理番号K27057 2019/08/27 汎用項目追加
// 管理番号K27063 2019/08/27 客注番号／発注管理番号の全角入力対応
// 3.1.0 2020/06/30
// 管理番号K27230 2021/05/28 脆弱性対応
// 管理番号K27464 2021/08/19 得意先マスタ登録／仕入先マスタ登録の更新時にエラーが発生する
// 3.2.0 2023/03/31

// 管理番号K26520 From
using System;
// 管理番号K26520 To
// 管理番号K27230 From
using System.IO;
using System.Linq;
// 管理番号K27230 To
using System.Text;
// 管理番号K27057・K27063 From
using System.Text.RegularExpressions;
// 管理番号K27057・K27063 To

namespace Infocom.Allegro
{
	/// <summary>
	/// 文字列加工を行う静的メソッドを提供します。
	/// </summary>
	public static class StringFormat
	{
		/// <summary>
		/// 文字の間に指定された文字列を指定された回数だけ挿入します。
		/// </summary>
		/// <param name="baseStr">
		/// 文字列
		/// </param>
		/// <param name="insertStr">
		/// 挿入する文字列
		/// </param>
		/// <param name="repeatCount">
		/// 繰り返し回数
		/// </param>
		/// <returns>
		/// 整形された文字列
		/// </returns>
		public static string InsertBetweenCharacter(string baseStr, string insertStr, int repeatCount)
		{
			StringBuilder result = new StringBuilder();
			if (!string.IsNullOrEmpty(baseStr) && !string.IsNullOrEmpty(insertStr) && 0 < repeatCount)
			{
				string insertStrRepeat = new StringBuilder().Insert(0, insertStr, repeatCount).ToString();
				foreach(var c in baseStr)
				{
					if(result.Length > 0)
					{
						result.Append(insertStrRepeat);
					}
					result.Append(c);
				}
				return result.ToString();
			}
			else
			{
				return baseStr;
			}
		}

// 管理番号K26520 From
		/// <summary>
		/// ファイル名をエンコードします。
		/// 16進数は大文字になります。
		/// 使用目的は以下の通り
		/// ・ファイル名に使用できない文字（「\/:*?"|」、および半角の「＜＞」）をエンコードして保存できるようにする。
		/// ・半角スペースを%20にエンコードし、ファイル名に半角スペースを使用できるようにする。
		/// </summary>
		/// <param name="fileName">ファイル名</param>
		/// <returns>エンコードされた文字列</returns>
		/// <remarks>
		/// Uri.EscapeDataStringメソッドは.NET Framework 4.5以上と4.0以下でエンコードされる文字が異なります。
		/// 4.0以下では英字数字と「-_.!~*'()」がエンコードされません。（RFC2396準拠）
		/// 4.5以上では英字数字と「-_.~」がエンコードされません。（RFC3986、RFC3987準拠）
		/// </remarks>
		public static string UrlEncodeForFileName(string fileName)
		{
			return Uri.EscapeDataString(fileName).Replace("*","%2A");
		}
// 管理番号K26520 To

// 管理番号K27057・K27063 From
		/// <summary>
		/// 渡された文字列が半角文字何文字分の文字数に相当するかを算出します。
		/// ※MS明朝／MS GOTHICといった等幅フォント（全角文字1文字=半角文字2文字）での利用を想定
		/// </summary>
		/// <param name="targetStr">
		/// 処理の対象文字列
		/// </param>
		/// <param name="asHalfCharSize">
		/// 半角文字相当数（対象文字列が半角文字何文字分に等しい幅かの文字数）
		/// </param>
		/// <param name="halfCharCnt">
		/// 対象文字列に含まれる半角文字の文字数
		/// </param>
		/// <param name="dblCharCnt">
		/// 対象文字列に含まれる全角文字の文字数
		/// </param>
		public static void GetAsHalfCharSize(string targetStr, out int asHalfCharSize, out int halfCharCnt, out int dblCharCnt)
		{
			// 正規表現で半角文字を抽出、削除し、全角文字だけにする
			dblCharCnt = Regex.Replace(targetStr, "[0-9a-zA-Zｦ-ﾟ!-~\x20]", "").Length;

			// 対象文字列の文字数から全角文字列の文字数を減算し、半角文字の文字数を取得
			halfCharCnt = targetStr.Length - dblCharCnt;

			// 半角文字、全角文字の文字数から、半角文字相当の文字数を算出
			asHalfCharSize = halfCharCnt + (dblCharCnt * 2);
		}

		/// <summary>
		/// 半角文字相当数の桁数で対象文字列を分割します。
		/// ※MS明朝／MS GOTHICといった等幅フォント（全角文字1文字=半角文字2文字）での利用を想定
		/// </summary>
		/// <param name="targetStr">
		/// 処理の対象文字列
		/// </param>
		/// <param name="asHalfCharSize">
		/// 半角文字相当数（対象文字列が半角文字何文字分に等しいかの文字数）
		/// </param>
		/// <param name="prevStr">
		/// 前半文字列（分割した文字列のうち前半分）
		/// </param>
		/// <param name="equivFlg">
		/// 前半文字列の半角文字相当の幅と、引数の半角文字相当数が等しいか
		/// </param>
		/// <returns>
		/// 対象文字列が分割されていればtrue、分割されてなければfalse
		/// </returns>
		public static bool SplitByNumOfChar(string targetStr, int asHalfCharSize, out string prevStr, out bool equivFlg)
		{
			// 再帰処理による文字列分割
			iterationSplit(targetStr, targetStr, asHalfCharSize, out prevStr);

			// 半角文字相当数と等しい位置で分割できているかどうか判定
			int equivHCS	= 0;	// 半角文字相当数（Half Character Size）
			int equivHCC	= 0;	// 半角文字数（Half Character Count）
			int equivDCC	= 0;	// 全角文字数（Double Character Count）
			GetAsHalfCharSize(prevStr, out equivHCS, out equivHCC, out equivDCC);
			equivFlg = asHalfCharSize == equivHCS;

			// 対象文字列と前半文字列が同じなら分割されていない
			return !(targetStr == prevStr);
		}

		/// <summary>
		/// 半角文字相当数より後ろの文字列を、省略記号に置き換えて返します。
		/// ※MS明朝／MS GOTHICといった等幅フォント（全角文字1文字=半角文字2文字）での利用を想定
		/// </summary>
		/// <param name="targetStr">
		/// 処理の対象文字列
		/// </param>
		/// <param name="asHalfCharSize">
		/// 半角文字相当数（対象文字列が半角文字何文字分に等しいかの文字数）
		/// </param>
		/// <param name="ellipsis">
		/// 省略記号
		/// </param>
		/// <param name="resultStr">
		/// 結果文字列
		/// </param>
		public static void ReplaceWithEllipsis(string targetStr, int asHalfCharSize, string ellipsis, out string resultStr)
		{
			if (targetStr.Length == 0)
			{
				resultStr = string.Empty;
			}
			else
			{
				string prevStr = string.Empty;
				bool equivFlg = false;

				// 対象文字列を分割し、省略せずに表示する文字列を取得
				if (SplitByNumOfChar(targetStr, asHalfCharSize, out prevStr, out equivFlg))
				{
					// 半角文字相当数で分割できなかった場合、不足分を半角スペースでパディング
					resultStr = prevStr + (equivFlg ? string.Empty : " ") + ellipsis;
				}
				// 対象文字列が分割されない場合はそのままの文字列を返す
				else
				{
					resultStr = prevStr;
				}
			}
		}

// 管理番号K27230 From
		/// <summary>
		/// ファイル名の無効文字を除外する
		/// </summary>
		/// <param name="fileName">ファイル名</param>
		/// <returns>除外後ファイル名</returns>
		public static string RemoveInvalidCharsFromFileName(string fileName)
		{
			var invalidChars = Path.GetInvalidFileNameChars();
			return string.Concat(fileName.Where(c => !invalidChars.Contains(c)));
		}

// 管理番号K27230 To
		// 再帰処理による文字列分割関数
		private static void iterationSplit(string orgStr, string targetStr, int asHalfCharSize, out string prevStr)
		{
			prevStr = string.Empty;

			if (targetStr.Length != 0 && asHalfCharSize > 1)
			{
				// 基準位置算出用変数
				string baseStr		= string.Empty;
				int baseHCS			= 0;			// 半角文字相当数（Half Character Size）
				int baseHCC			= 0;			// 半角文字数（Half Character Count）
				int baseDCC			= 0;			// 全角文字数（Double Character Count）
				// 再帰処理用変数
				string recStr		= string.Empty;
				string recOutStr	= string.Empty;

				// 基準位置算出
				// 全て全角／全て半角で考えた場合、文字列の幅は最大で倍になるため、2で除算（切り捨て）
				int basePos = (int)Math.Truncate((decimal)asHalfCharSize / 2);

				// 基準位置が対象文字列の長さより小さければ分割処理を実施
				if (basePos < targetStr.Length)
				{
					// 基準位置で対象文字列を分割し、前半分に半角文字／全角文字が何文字含まれるかを取得
					baseStr = targetStr.Substring(0, basePos);
					GetAsHalfCharSize(baseStr, out baseHCS, out baseHCC, out baseDCC);

					// 半角文字相当数が半角1文字分より大きい場合は再帰的に分割処理を実行
					recStr = targetStr.Substring(baseStr.Length, targetStr.Length - baseStr.Length);
					iterationSplit(orgStr, recStr, asHalfCharSize - baseHCS, out recOutStr);
					prevStr = baseStr + recOutStr;

					// 処理終了時の最終調整
					if (recOutStr.Length == 0 && asHalfCharSize != baseHCS)
					{
						// 後半文字列の1文字目処理用変数
						string lastStr	= string.Empty;
						int lastHCS		= 0;			// 半角文字相当数（Half Character Size）
						int lastHCC		= 0;			// 半角文字数（Half Character Count）
						int lastDCC		= 0;			// 全角文字数（Double Character Count）

						// 後半文字列の1文字目が半角文字の場合、前半文字列に結合
						int lastPos = (basePos > targetStr.Length) ? targetStr.Length - 1 : basePos;
						lastStr = (lastPos == targetStr.Length) ? string.Empty : targetStr.Substring(lastPos, 1);
						GetAsHalfCharSize(lastStr, out lastHCS, out lastHCC, out lastDCC);
						prevStr = (lastHCC == 1) ? (prevStr + lastStr) : prevStr;
					}
				}
				// 基準位置が対象文字列の長さ以上なら文字列をそのまま返す
				else
				{
					prevStr = targetStr;
				}
			}
		}
// 管理番号K27057・K27063 To

#region 拡張メソッド
// 管理番号K27464 From
		/// <summary>
		/// objectの文字列表記をUTF8エンコードの16進数表記文字列に変換する
		/// </summary>
		/// <param name="src">元のオブジェクト</param>
		/// <returns>変換後の文字列</returns>
		public static string ToHexString(this object src)
		{
			// 指定されたオブジェクトがnullや空文字の場合はそのまま返す
			if (string.IsNullOrEmpty(src?.ToString()))
			{
				return src?.ToString();
			}

			byte[] bytes = Encoding.UTF8.GetBytes(src.ToString());
			return BitConverter.ToString(bytes).Replace("-", "");
		}

		/// <summary>
		/// UTF8エンコードの16進数表記文字列を元の文字列に戻す
		/// </summary>
		/// <param name="hex">16進数表記文字列</param>
		/// <returns>デコードされた文字列</returns>
		public static string FromHexString(this string hex)
		{
			// 指定されたオブジェクトがnullや空文字の場合はそのまま返す
			if (string.IsNullOrEmpty(hex?.ToString()))
			{
				return hex?.ToString();
			}

			byte[] bytes = new byte[hex.Length / 2];
			for (int i = 0; i < hex.Length; i += 2)
			{
				bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
			}
			return Encoding.UTF8.GetString(bytes);
		}
// 管理番号K27464 To
#endregion
	}
}
