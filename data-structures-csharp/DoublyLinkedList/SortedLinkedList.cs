using System;
using System.Collections;
using System.Collections.Generic;
using data_structures_csharp.Interfaces;

namespace data_structures_csharp.DoublyLinkedList
{
  public class SortedLinkedList<T> : ILinkedList<T> where T : IComparable<T>
  {
    #region IList<T> Members

    /// <summary>
    /// Add an item to the end of the list.
    /// Complexity : O(n) as we need to search the list to find the position
    /// to insert
    /// </summary>
    /// <param name="item">The item to add</param>
    public void Add(T item)
    {
      var node = new ListNode<T>(item);
      if (_front == null)
      {
        AddNodeEmptyList(node);
      }
      else
      {
        int index = 0;
        var current = _front;
        while (current != null)
        {
          if (item.CompareTo(current.Data) < 0)
          {
            break;
          }
          ++index;
          current = current.Next;
        }
        AddNodeAtIndex(node, index);
      }
      ++Count;
    }

    /// <summary>
    /// Removes the first item that matches the item passed in. 
    /// Complexity: O(n) worst, average as we don't know position in list
    /// </summary>
    /// <param name="item">The item to remove from the LinkedList</param>
    /// <returns>True if item removed, otherwise false</returns>
    public bool Remove(T item)
    {
      ValidateNotEmpty();
      var comparer = EqualityComparer<T>.Default;

      ListNode<T> previous = null;
      var current = _front;
      while (current != null)
      {
        if (comparer.Equals(current.Data, item) == true)
        {
          if (previous != null)
          {
            RemoveFromMiddle(current);
          }
          else
          {
            RemoveFromStart();
          }

          --Count;
          return true;
        }
        previous = current;
        current = current.Next;
      }
      return false;
    }

    /// <summary>
    /// Returns the node for the item passed in if it exists.
    /// Complexity: O(n) worst, average. As we need to traverse the list to
    /// get the item
    /// </summary>
    /// <param name="item">The item we want the node for</param>
    /// <returns>The node if it exists, otherwise false</returns>
    public IListNode<T> Get(T item)
    {
      var comparer = EqualityComparer<T>.Default;
      var current = _front;
      while (current != null)
      {
        if (comparer.Equals(current.Data, item) == true)
        {
          return current;
        }
        current = current.Next;
      }
      return null;
    }

    /// <summary>
    /// Clears the entire list.
    /// Complexity: O(1) worst. We just remove all references at the front and back
    /// and let the GC handle the rest. 
    /// </summary>
    public void Clear()
    {
      _front = null;
      _back = null;
      Count = 0;
    }

    /// <summary>
    /// Checks to see if the item is contained within the list 
    /// Complexity: O(n) worst. Traverses the list until the item is found.
    /// </summary>
    /// <param name="item">The item to search for in the LinkedList</param>
    /// <returns>True if item found, otherwise false</returns>
    public bool Contains(T item)
    {
      return Get(item) != null ? true : false;
    }

    /// <summary>
    /// Copies the entire LinkedList to the array provided by the caller.
    /// Complexity: O(n) worst. Must traverse the entire list to copy all itms
    /// into the array
    /// </summary>
    /// <param name="array">The array to populate</param>
    /// <param name="arrayIndex">The index of the array to start population at</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
      if (array == null)
      {
        throw new ArgumentNullException("array", "The array provided to copy into cannot be null");
      }

      if (arrayIndex < 0 || array.Length < arrayIndex)
      {
        throw new ArgumentOutOfRangeException("arrayIndex", "The array index provided is out of range with respect to the array provided");
      }

      if (array.Length - arrayIndex < this.Count)
      {
        throw new ArgumentException("The array provided does not contain sufficient size after the arrayIndex to fill with contents of the LinkedList", "array");
      }

      var current = _front;
      while (current != null)
      {
        array[arrayIndex++] = current.Data;
        current = current.Next;
      }
    }

    /// <summary>
    /// The number of items currently stored in the LinkedList
    /// Complexity: O(1) worst. We keep a count as things are added and removed
    /// </summary>
    public int Count
    {
      get;
      private set;
    }

    /// <summary>
    /// The value at the front of the list
    /// Complexity: O(1) worst. We keep a reference to this at all times to 
    /// make access easier
    /// </summary>
    public T Front
    {
      get { return _front.Data; }
    }

    /// <summary>
    /// The value at the back of the list
    /// Complexity: O(1) worst. We keep a reference to this at all times to 
    /// make access easier
    /// </summary>
    public T Back
    {
      get { return _back.Data; }
    }

    #endregion

    #region IEnumerable<T> Members

    public IEnumerator<T> GetEnumerator()
    {
      var current = _front;
      while (current != null)
      {
        yield return current.Data;
        current = current.Next;
      }
    }

    #endregion

    #region IEnumerable Members

    IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IEnumerable<T>)this).GetEnumerator();
    }

    #endregion

    #region Internal

    /// <summary>
    /// Validates that the index provided is within the valid range and throws
    /// and IndexOutOfRangeException if it is not.
    /// </summary>
    /// <param name="index">The index to validate</param>
    public void ValidateIndex(int index)
    {
      if (index < 0 || index > Count)
      {
        throw new IndexOutOfRangeException("The index provided is not within the valid range for this list");
      }
    }

    /// <summary>
    /// Validate that the list is not empty. Used for operations like removal
    /// where we must have at least one thing in the list.
    /// </summary>
    public void ValidateNotEmpty()
    {
      if (Count == 0)
      {
        throw new InvalidOperationException("The list is empty");
      }
    }

    /// <summary>
    /// Adds a new node to the front of the list
    /// </summary>
    /// <param name="node">The node to add</param>
    private void AddFront(ListNode<T> node)
    {
      if (_front == null)
      {
        AddNodeEmptyList(node);
      }
      else
      {
        AddNodeToFront(node);
      }
    }

    /// <summary>
    /// Adds a new node to the back of the list
    /// </summary>
    /// <param name="node">The node to add</param>
    private void AddBack(ListNode<T> node)
    {
      if (_front == null)
      {
        AddNodeEmptyList(node);
      }
      else
      {
        AddNodeToBack(node);
      }
    }

    /// <summary>
    /// Adds the node to the head and tail of this empty list and updates the count
    /// </summary>
    /// <param name="node">The node to start the list off</param>
    private void AddNodeEmptyList(ListNode<T> node)
    {
      _front = node;
      _back = node;
    }

    /// <summary>
    /// Adds the node to the front of an already populated list
    /// </summary>
    /// <param name="node">The node to add to the end</param>
    private void AddNodeToFront(ListNode<T> node)
    {
      node.Next = _front;
      _front.Prev = node;
      _front = node;
    }

    /// <summary>
    /// Adds the node to the back of an already populated list
    /// </summary>
    /// <param name="node">The node to add to the end</param>
    private void AddNodeToBack(ListNode<T> node)
    {
      _back.Next = node;
      node.Prev = _back;
      _back = node;
    }

    /// <summary>
    /// Finds the current node occupying the index and then inserst the new 
    /// node in place. After this operation the node at the index will be 
    /// the new node. The node that previously occupied this position will
    /// be at index + 1
    /// </summary>
    /// <param name="node">The node to add</param>
    /// <param name="index">The index position to add the node</param>
    private void AddNodeAtIndex(ListNode<T> node, int index)
    {
      if (index == 0)
      {
        AddFront(node);
      }
      else if (index == Count)
      {
        AddBack(node);
      }
      else
      {
        AddMiddle(node, index);
      }
    }

    /// <summary>
    /// Add a node into the middle of the list
    /// </summary>
    /// <param name="node">The node to add</param>
    /// <param name="index">The index position to add the node</param>
    private void AddMiddle(ListNode<T> node, int index)
    {
      int currentIndex = 0;
      var current = _front;

      while (current != null)
      {
        if (currentIndex == index)
        {
          node.Next = current;
          node.Prev = current.Prev;
          current.Prev.Next = node;
          current.Prev = node;
          break;
        }
        ++currentIndex;
        current = current.Next;
      }
    }

    /// <summary>
    /// Remove the node passed in and update the start of the list
    /// </summary>
    /// <param name="node">The node to remove from the list</param>
    private void RemoveFromStart()
    {
      var backup = _front;
      _front = _front.Next;

      // If the list is now empty we need to remove the tail
      if (_front == null)
      {
        _back = null;
      }
      else
      {
        _front.Prev = null;
        backup.Next = null;
      }
    }

    /// <summary>
    /// Updates the back of the list to put the value passed in at the end.
    /// Everything to the right of this node in the list will be lost
    /// </summary>
    /// <param name="penultimate">The value to put at the end</param>
    private void RemoveAllAfterNode(ListNode<T> newBack)
    {
      newBack.Next.Prev = null;
      newBack.Next = null;

      _back = newBack;
    }

    /// <summary>
    /// Remove the node passed in and update the neighbours in the list
    /// </summary>
    /// <param name="node">The node to remove from the list</param>
    /// <param name="previous">The previous node in the list</param>
    private void RemoveFromMiddle(ListNode<T> node)
    {
      var previous = node.Prev;
      previous.Next = node.Next;

      // Special case, if the value was at the end we need to
      // update the tail we have stored.
      if (previous.Next == null)
      {
        _back = previous;
      }
      else
      {
        previous.Next.Prev = previous;
        node.Next = null;
        node.Prev = null;
      }
    }

    /// <summary>
    /// Add a node into the middle of the list
    /// </summary>
    /// <param name="node">The node to add</param>
    /// <param name="index">The index position to add the node</param>
    private void RemoveMiddle(int index)
    {
      var node = GetAtIndex(index);
      RemoveFromMiddle(node);
    }

    private ListNode<T> GetAtIndex(int index)
    {
      int currentIndex = 0;
      var current = _front;
      while (current != null)
      {
        if (currentIndex == index)
        {
          break;
        }
        ++currentIndex;
        current = current.Next;
      }
      return current;
    }

    #endregion

    #region Fields

    /// <summary>
    /// The start of the list
    /// </summary>
    private ListNode<T> _front;

    /// <summary>
    /// The end of the list
    /// </summary>
    private ListNode<T> _back;

    #endregion

  }
}
