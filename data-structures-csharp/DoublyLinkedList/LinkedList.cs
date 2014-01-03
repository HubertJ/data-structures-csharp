using System;
using System.Collections;
using System.Collections.Generic;

namespace data_structures_csharp.DoublyLinkedList
{
  public class LinkedList<T> : ICollection<T>
  {
    #region ICollection<T> Members

    /// <summary>
    /// Adds a new item to the end of the list. 
    /// Complexity: O(1)
    /// </summary>
    /// <param name="item">The item to add to the end of the LinkedList</param>
    public void Add(T item)
    {
      var node = new ListNode<T>(item);
      if (_head == null)
      {
        AddNodeEmptyList(node);
      }
      else
      {
        AddNodeToEnd(node);
      }
    }

    /// <summary>
    /// Clears the entire list.
    /// Complexity: O(n)
    /// </summary>
    public void Clear()
    {
      var current = _head;
      while (current != null)
      {
        var node = current;
        current = current.Next;
        node.Next = null;
        node.Prev = null;
      }

      _head = null;
      _tail = null;
      Count = 0;
    }

    /// <summary>
    /// Checks to see if the item is contained within the list 
    /// Complexity: O(n)
    /// </summary>
    /// <param name="item">The item to search for in the LinkedList</param>
    /// <returns>True if item found, otherwise false</returns>
    public bool Contains(T item)
    {
      var comparer = EqualityComparer<T>.Default;
      var current = _head;
      while (current != null)
      {
        if (comparer.Equals(current.Data, item) == true)
        {
          return true;
        }
        current = current.Next;
      }
      return false;
    }

    /// <summary>
    /// Copies the entire LinkedList to the array provided by the caller.
    /// Complexity: O(n)
    /// </summary>
    /// <param name="array">The array to populate</param>
    /// <param name="arrayIndex">The index of the array to start population at</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
      if (array.Length - arrayIndex < this.Count)
      {
        throw new ArgumentException("The array provided does not contain sufficient size after the arrayIndex to fill with contents of the LinkedList", "array");
      }

      if (arrayIndex < 0 || array.Length < arrayIndex)
      {
        throw new ArgumentOutOfRangeException("arrayIndex", "The array index provided is out of range with respect to the array provided");
      }

      if (array == null)
      {
        throw new ArgumentNullException("array", "The array provided to copy into cannot be null");
      }

      var current = _head;
      while (current != null)
      {
        array[++arrayIndex] = current.Data;
        current = current.Next;
      }
    }

    /// <summary>
    /// The number of items currently stored in the LinkedList
    /// Complexity: O(1)
    /// </summary>
    public int Count
    {
      get;
      private set;
    }

    /// <summary>
    /// Whether or not the list is read only
    /// Complexity: O(1)
    /// </summary>
    public bool IsReadOnly
    {
      get { return false; }
    }

    /// <summary>
    /// Removes the first item that matches the item passed in. 
    /// Complexity: O(n)
    /// </summary>
    /// <param name="item">The item to remove from the LinkedList</param>
    /// <returns>True if item removed, otherwise false</returns>
    public bool Remove(T item)
    {
      var comparer = EqualityComparer<T>.Default;

      var current = _head;
      while (current != null)
      {
        if (comparer.Equals(current.Data, item) == true)
        {
          if (current.Prev != null)
          {
            RemoveFromMiddle(current);
          }
          else
          {
            RemoveFromStart(current);
          }
          return true;
        }
        current = current.Next;
      }
      return false;
    }

    #endregion

    #region IEnumerable<T> Members

    /// <summary>
    /// Gets an enumerator instance to enumerate through the LinkedList
    /// </summary>
    /// <returns>The generic IEnumerator instance</returns>
    public IEnumerator<T> GetEnumerator()
    {
      var current = _head;
      while (current != null)
      {
        yield return current.Data;
        current = current.Next;
      }
    }

    #endregion

    #region IEnumerable Members

    /// <summary>
    /// Gets an enumerator instance to enumerate through the LinkedList
    /// </summary>
    /// <returns>The IEnumerator instance</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IEnumerable<T>)this).GetEnumerator();
    }

    #endregion

    #region Internal

    /// <summary>
    /// Adds the node to the head and tail of this empty list and updates the count
    /// </summary>
    /// <param name="node">The node to start the list off</param>
    private void AddNodeEmptyList(ListNode<T> node)
    {
      _head = node;
      _tail = node;
      ++Count;
    }

    /// <summary>
    /// Adds the node to the head and tail of this empty list and updates the count
    /// </summary>
    /// <param name="node">The node to add to the end</param>
    private void AddNodeToEnd(ListNode<T> node)
    {
      _tail.Next = node;
      node.Prev = _tail;
      _tail = node;
      ++Count;
    }

    /// <summary>
    /// Remove the node passed in and update the start of the list
    /// </summary>
    /// <param name="node">The node to remove from the list</param>
    private void RemoveFromStart(ListNode<T> node)
    {
      _head = node.Next;

      // If the list is now empty we need to remove the tail
      if (_head == null)
      {
        _tail = null;
      }
      else
      {
        _head.Prev = null;
        node.Prev = null;
        node.Next = null;
      }

      --Count;
    }

    /// <summary>
    /// Remove the node passed in and update the neighbours in the list
    /// </summary>
    /// <param name="node">The node to remove from the list</param>
    private void RemoveFromMiddle(ListNode<T> node)
    {
      // Bridge over the value to remove it from the list.
      node.Prev.Next = node.Next;

      // Special case, if the value was at the end we need to
      // update the tail we have stored.
      if (node.Next == null)
      {
        _tail = node.Prev;
        node.Prev = null;
      }
      else
      {
        node.Next.Prev = node.Prev;
        node.Prev = null;
        node.Next = null;
      }

      --Count;
    }

    #endregion

    #region Fields

    /// <summary>
    /// The start of the list
    /// </summary>
    private ListNode<T> _head;

    /// <summary>
    /// The end of the list
    /// </summary>
    private ListNode<T> _tail;

    #endregion
  }
}
