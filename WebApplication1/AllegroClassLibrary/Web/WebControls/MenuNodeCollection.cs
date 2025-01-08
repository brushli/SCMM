// Product     : Allegro
// Unit        : --
// Module      : --
// Function    : --
// File Name   : MenuNodeCollection.cs
// 機能名      : 内包用メニュー項目コレクション
// Version     : 2.3.0
// Last Update : 2016/06/30
// Copyright (c) 2004-2016 Grandit Corp. All Rights Reserved.
//
// 1.0.0 2004/04/01
// 2.2.0 2014/10/31
// 管理番号 K25904 2016/04/22 共通関数ドキュメント化
// 2.3.0 2016/06/30

using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using Infocom.Allegro.Web.WebControls;
using Infocom.Allegro;

namespace Infocom.Allegro.Web.WebControls
{
	/// <summary>
	/// 内包用メニュー項目コレクション
	/// </summary>
	public class MenuNodeCollection : IList, ICollection, IEnumerable
	{
		#region Private Fields
		private ArrayList list;
		#endregion

		#region Constructor
		/// <summary>
		/// 内包用メニュー項目コレクションのコンストラクタです。
		/// </summary>
		public MenuNodeCollection()
		{
			list = new ArrayList(4);
		}
		#endregion

		#region Properties
		/// <summary>
		/// コレクション内の要素の合計数。
		/// </summary>
		public virtual int Count
		{
			get {return list.Count;}
		}

		/// <summary>
		/// コレクションが読み取り専用かどうか。常にfalseを返します。
		/// </summary>
		public virtual bool IsReadOnly
		{
			get {return false;}
		}

		/// <summary>
		/// コレクションが同期がとられているかどうか。常にfalseを返します。
		/// </summary>
		public virtual bool IsSynchronized
		{
			get {return false;}
		}

		/// <summary>
		/// コレクションへのアクセスを同期するために使用できるオブジェクト。
		/// </summary>
		public virtual object SyncRoot
		{
			get {return list.SyncRoot;}
		}

		/// <summary>
		/// 指定したインデックス位置にある<see cref="BaseMenuNode"/>。
		/// </summary>
		public BaseMenuNode this[int index]
		{
			get {return (BaseMenuNode) list[index];}
			set {list[index] = value;}
		}
		#endregion

		#region Method
		/// <summary>
		/// 指定した<see cref="BaseMenuNode"/>をコレクションに追加します。
		/// </summary>
		/// <param name="value">
		/// コレクションに追加する<see cref="BaseMenuNode"/>。
		/// </param>
		/// <returns>
		/// 新しい要素が挿入された位置。
		/// </returns>
		public int Add(BaseMenuNode value)
		{
			int index = list.Add(value);
			return index;
		}

		/// <summary>
		/// 指定したインデックス位置に、指定した<see cref="BaseMenuNode"/>を追加します。
		/// </summary>
		/// <param name="index">
		/// <see cref="BaseMenuNode"/>を追加する配列内の位置。
		/// </param>
		/// <param name="value">
		/// コレクションに追加する<see cref="BaseMenuNode"/>。
		/// </param>
		public void AddAt(int index, BaseMenuNode value)
		{
			list.Insert(index, value);
		}

		/// <summary>
		/// コレクションからすべての<see cref="BaseMenuNode"/>を削除します。
		/// </summary>
		public virtual void Clear()
		{
			list.Clear();
		}

		/// <summary>
		/// 指定した<see cref="BaseMenuNode"/>がコレクションに格納されているかどうかを判断します。
		/// </summary>
		/// <param name="value">
		/// コレクション内で検索される<see cref="BaseMenuNode"/>。
		/// </param>
		/// <returns>
		/// コレクションにある場合：true、それ以外の場合：false
		/// </returns>
		public bool Contains(BaseMenuNode value)
		{
			return list.Contains(value);
		}

		/// <summary>
		/// コレクションに格納されている<see cref="BaseMenuNode"/>を、<see cref="Array"/>オブジェクトに、<see cref="Array"/>内の指定したインデックス位置からコピーします。
		/// </summary>
		/// <param name="array">
		/// コピー先の<see cref="Array"/>。
		/// </param>
		/// <param name="index">
		/// コピーの開始位置となる、<paramref name="array"/>の0から始まる相対インデックス番号。
		/// </param>
		public virtual void CopyTo(Array array, int index)
		{
			list.CopyTo(array, index);
		}

		/// <summary>
		/// コレクションを反復処理できる列挙子を取得します。
		/// </summary>
		/// <returns>
		/// コレクションを反復処理する列挙子。
		/// </returns>
		public virtual IEnumerator GetEnumerator()
		{
			return list.GetEnumerator();
		}

		/// <summary>
		/// コレクション内の指定した<see cref="BaseMenuNode"/>のインデックスを取得します。
		/// </summary>
		/// <param name="value">
		/// インデックスを返す対象となる<see cref="BaseMenuNode"/>。
		/// </param>
		/// <returns>
		/// 指定した<see cref="BaseMenuNode"/>のインデックス。
		/// </returns>
		public int IndexOf(BaseMenuNode value)
		{
			return list.IndexOf(value);
		}

		/// <summary>
		/// コレクションから、指定した<see cref="BaseMenuNode"/>を削除します。
		/// </summary>
		/// <param name="value">
		/// コレクションから削除する<see cref="BaseMenuNode"/>。
		/// </param>
		public void Remove(BaseMenuNode value)
		{
			list.Remove(value);
		}

		/// <summary>
		/// コレクションから、指定したインデックス位置にある<see cref="BaseMenuNode"/>を削除します。
		/// </summary>
		/// <param name="index">
		/// コレクションから削除する<see cref="BaseMenuNode"/>の配列内の位置。
		/// </param>
		public virtual void RemoveAt(int index)
		{
			list.RemoveAt(index);
		}
		#endregion

		#region Explicit Interface Implementations
		/// <summary>
		/// 指定したインデックス位置にある要素。
		/// </summary>
		object IList.this[int index]
		{
			get {return list[index];}
			set {list[index] = (TabItem) value;}
		}

		/// <summary>
		/// 指定した要素をコレクションに追加します。
		/// </summary>
		/// <param name="value">
		/// コレクションに追加する要素。
		/// </param>
		/// <returns>
		/// 新しい要素が挿入された位置。
		/// </returns>
		int IList.Add(object value)
		{
			int index = list.Add((TabItem) value);
			return index;
		}

		/// <summary>
		/// 指定した要素がコレクションに格納されているかどうかを判断します。
		/// </summary>
		/// <param name="value">
		/// コレクション内で検索される要素。
		/// </param>
		/// <returns>
		/// コレクションにある場合：true、それ以外の場合：false
		/// </returns>
		bool IList.Contains(object value)
		{
			return list.Contains((TabItem) value);
		}

		/// <summary>
		/// コレクション内の指定した要素のインデックスを取得します。
		/// </summary>
		/// <param name="value">
		/// インデックスを返す対象となる要素。
		/// </param>
		/// <returns>
		/// 指定した要素のインデックス。
		/// </returns>
		int IList.IndexOf(object value)
		{
			return list.IndexOf((TabItem) value);
		}

		/// <summary>
		/// コレクション内の指定したインデックスの位置に要素を挿入します。
		/// </summary>
		/// <param name="index">
		/// <paramref name="value"/>を挿入する位置の、0から始まるインデックス番号。
		/// </param>
		/// <param name="value">
		/// 挿入する要素。
		/// </param>
		void IList.Insert(int index, object value)
		{
			list.Insert(index, (TabItem) value);
		}

		/// <summary>
		/// コレクションが固定サイズかどうかを示す値。常にfalseを返します。
		/// </summary>
		bool IList.IsFixedSize
		{
			get {return false;}
		}

		/// <summary>
		/// コレクションから、指定した要素を削除します。
		/// </summary>
		/// <param name="value">
		/// コレクションから削除する要素。
		/// </param>
		void IList.Remove(object value)
		{
			list.Remove((TabItem) value);
		}
		#endregion
	}
}
