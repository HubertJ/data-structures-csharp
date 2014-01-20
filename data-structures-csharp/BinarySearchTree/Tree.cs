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

    /// <summary>
    /// Adds an item to the tree.
    /// Complexity : O(log n) average, O(n) worst as the topology of the tree
    /// may require a search through all the contents of the tree (if each 
    /// addition to the tree so far has been greater than the last) as this is
    /// not a balanced tree
    /// </summary>
    /// <param name="item">The item to add</param>
    public void Add(T item)
    {
      var node = new TreeNode<T>(item);
      AddNewNode(ref _root, node);
      ++Count;
    }

    /// <summary>
    /// Removes an item from the tree
    /// Complexity : O(log n) average, O(n) worst
    /// </summary>
    /// <param name="item">The item to remove from the tree</param>
    /// <returns>bool if an item has been removed, otherwise false</returns>
    public bool Remove(T item)
    {
      if (RemoveData(_root, null, item) == true)
      {
        --Count;
        return true;
      }
      else
      {
        return false;
      }
    }

    /// <summary>
    /// Clears the tree.
    /// Complexity : O(1) Sets the root to null and lets the garbage collector 
    /// handle the rest
    /// </summary>
    public void Clear()
    {
      _root = null;
    }

    /// <summary>
    /// Checks whether an item exists in the tree. 
    /// Complexity : O(log n) average, O(n) worst case
    /// </summary>
    /// <param name="item">The item to check the tree for</param>
    /// <returns>True if the item is found, otherwise false</returns>
    public bool Contains(T item)
    {
      return FindItem(item) != null;
    }

    /// <summary>
    /// Gets the count of the number of items in the tree
    /// </summary>
    public int Count
    {
      get;
      internal set;
    }

    #endregion

    #region Implementation

    /// <summary>
    /// Calls itself recursively until the correct position for the new node
    /// is found within the tree and it is added
    /// </summary>
    /// <param name="parent">The parent node to try adding to</param>
    /// <param name="node">The node to add</param>
    private void AddNewNode(ref TreeNode<T> parent, TreeNode<T> node)
    {
      if (parent == null)
      {
        parent = node;
      }
      else
      {
        if (parent.Data.CompareTo(node.Data) > 0)
        {
          AddNewNode(ref parent.Left, node);
        }
        else
        {
          AddNewNode(ref parent.Right, node);
        }
      }
    }

    /// <summary>
    /// Search for the data and remove it if found
    /// </summary>
    /// <param name="data">The data to remove</param>
    private bool RemoveData(TreeNode<T> node, TreeNode<T> parent, T data)
    {
      if (node == null)
      {
        return false;
      }

      int comparison = data.CompareTo(node.Data);
      if (comparison == 0)
      {
        RemoveNode(node, parent);
        return true;
      }
      else if (comparison == -1)
      {
        return RemoveData(node.Left, node, data);
      }
      else
      {
        return RemoveData(node.Right, node, data);
      }
    }

    private void RemoveNode(TreeNode<T> node, TreeNode<T> parent)
    {
      if (node.Right == null)
      {
        RemoveNodeNoRightChild(node, parent);
      }
      else if (node.Right.Left == null)
      {
        RemoveNodeNoRightLeftChild(node, parent);
      }
      else
      {
        RemoveNodeRightLeftChild(node, parent);
      }
    }

    private void RemoveNodeNoRightChild(TreeNode<T> node, TreeNode<T> parent)
    {
      if (parent == null)
      {
        _root = node.Left;
      }
      else
      {
        int comparison = node.Data.CompareTo(parent.Data);
        if (comparison < 0)
        {
          parent.Left = node.Left;
        }
        else
        {
          parent.Right = node.Left;
        }
      }
    }

    private void RemoveNodeNoRightLeftChild(TreeNode<T> node, TreeNode<T> parent)
    {
      if (parent == null)
      {
        _root = node.Right;
        _root.Left = node.Left; 
      }
      else
      {
        int comparison = node.Data.CompareTo(parent.Data);
        if (comparison < 0)
        {
          parent.Left = node.Right;
          parent.Left.Left = node.Left;
        }
        else
        {
          parent.Right = node.Right;
          parent.Right.Left = node.Left;
        }
      }
    }

    private void RemoveNodeRightLeftChild(TreeNode<T> node, TreeNode<T> parent)
    {
      var minimumLeft = node.Right.Left;
      var currentLeft = node.Right;
      while (minimumLeft.Left != null)
      {
        currentLeft = minimumLeft;
        minimumLeft = minimumLeft.Left;
      }

      // Replace the minimum 
      currentLeft.Left = minimumLeft.Right;
      
      if (parent == null)
      {
        _root = minimumLeft;
        _root.Left = node.Left;
        _root.Right = node.Right;
      }
      else
      {
        int comparison = node.Data.CompareTo(parent.Data);
        if (comparison < 0)
        {
          parent.Left = node.Right;
          parent.Left.Left = node.Left;
          parent.Left.Right = node.Right;
        }
        else
        {
          parent.Right = node.Right;
          parent.Right.Left = node.Left;
          parent.Right.Right = node.Right;
        }
      }

    }

    /// <summary>
    /// Searches through the tree to find the item and returns the node if it 
    /// is found.
    /// </summary>
    /// <param name="item">The item to search for in the tree</param>
    /// <returns>The node if it is found, otherwise false</returns>
    private TreeNode<T> FindItem(T item)
    {
      TreeNode<T> parentDummy = null; // Not needed!
      return FindItemAndParent(item, out parentDummy);
    }

    /// <summary>
    /// Searches through the tree to find the item and returns the node if it 
    /// is found along with the parent node as an out parameter if needed
    /// </summary>
    /// <param name="item">The item to search for</param>
    /// <param name="parent">The parent of the item if found. Or null if not found or root node</param>
    /// <returns>The node if item is found, otherwise null</returns>
    private TreeNode<T> FindItemAndParent(T item, out TreeNode<T> parent)
    {
      parent = null;
      var current = _root;

      while (current != null)
      {
        var comparison = current.Data.CompareTo(item);
        if (comparison == 0)
        {
          return current;
        }
        else if (comparison < 0)
        {      
          parent = current;
          current = current.Right;
        }
        else
        {
          parent = current;
          current = current.Left;
        }
      }

      // If we are here, the value was never found, so we return null for both
      parent = null;
      return null; 
    }

    #endregion

    #region Fields

    TreeNode<T> _root;

    #endregion
  }
}
