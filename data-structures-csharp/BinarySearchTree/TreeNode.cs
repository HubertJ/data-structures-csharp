
using System;

namespace data_structures_csharp.BinarySearchTree
{
  public class TreeNode<T> where T : IComparable<T>
  {
    #region Construction

    /// <summary>
    /// Constructor of the binary tree node
    /// </summary>
    /// <param name="data">The data to store in this node</param>
    public TreeNode(T data)
    {
      Data = data;
      Left = null;
      Right = null;
    }

    #endregion

    #region Fields

    public T Data;

    public TreeNode<T> Left;

    public TreeNode<T> Right;

    #endregion
  }
}
