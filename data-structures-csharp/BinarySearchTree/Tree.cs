using System;
using System.Collections.Generic;
using data_structures_csharp.Interfaces;

namespace data_structures_csharp.BinarySearchTree
{
  public class Tree<T> : ITree<T> where T : IComparable<T>, IEquatable<T>
  {
    #region Construction

    public Tree()
    {
      _root = null;
      var test = _root;
    }

    #endregion

    #region Interface

    public TreeNode<T> Root
    {
      get { return _root; }
    }

    #endregion

    #region ITree<T> Members

    public void Add(T item)
    {
      throw new NotImplementedException();
    }

    public bool Remove(T item)
    {
      throw new NotImplementedException();
    }

    public void Clear()
    {
      throw new NotImplementedException();
    }

    public bool Contains(T item)
    {
      throw new NotImplementedException();
    }

    public int Count
    {
      get { throw new NotImplementedException(); }
    }

    #endregion

    #region Fields

    TreeNode<T> _root;

    #endregion
  }
}
