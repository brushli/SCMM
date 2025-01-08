// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : Attribute.cs
// 機能名      : 属性定義
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;
using System.Collections.Specialized;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace Infocom.Allegro.ComponentModel
{
	/// <summary>
	/// カスタムコントロール内で使用する型コンバータ
	/// </summary>
	public class ControlConverter : StringConverter
	{
		/// <summary>
		/// カスタムコントロール内で使用する型コンバータのコンストラクタです。
		/// </summary>
		public ControlConverter()
		{
		}

		/// <summary>
		/// 書式指定コンテキストが指定されている場合、型コンバータがデザインされた対象のデータ型の標準値のコレクションを返します。
		/// </summary>
		/// <param name="context">
		/// 書式指定コンテキストを提供する<see cref="ITypeDescriptorContext"/>。
		/// このパラメータは、コンバータが呼び出される環境に関する追加情報を抽出するために使用できます。
		/// このパラメータまたはこのパラメータのプロパティには、nullを指定できます。
		/// </param>
		/// <returns>
		/// 有効値の標準セットを保持している<see cref="TypeConverter.StandardValuesCollection"/>。
		/// データ型が標準値セットをサポートしていない場合はnull。
		/// </returns>
		public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			StringCollection idList = new StringCollection();
			foreach (IComponent comp in context.Container.Components)
			{
				if (comp is Control)
				{
					idList.Add(((Control) comp).ClientID);
				}
			}
			return new StandardValuesCollection(idList);
		}

		/// <summary>
		/// 指定したコンテキストを使用して、リストから選択できる標準値セットをオブジェクトがサポートするかどうかを返します。
		/// </summary>
		/// <param name="context">
		/// 書式指定コンテキストを提供する<see cref="ITypeDescriptorContext"/>。
		/// </param>
		/// <returns>
		/// オブジェクトがサポートしている標準値セットを見つけるためにTypeConverter.GetStandardValuesを呼び出す必要がある場合はtrue。それ以外の場合はfalse。
		/// </returns>
		public override bool GetStandardValuesSupported(System.ComponentModel.ITypeDescriptorContext context)
		{
			return true;
		}
	}
}
