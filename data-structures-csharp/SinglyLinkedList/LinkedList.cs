using System;
using System.Collections;
using System.Collections.Generic;
using data_structures_csharp.Interfaces;

namespace data_structures_csharp.SinglyLinkedList
{
  public class LinkedList<T> : IIndexList<T>, IIteratorList<T>
  {
    #region IList<T> Members

    /// <summary>
    /// Add an item to the end of the list.
    /// Complexity : O(1) best, worst, average as we always add to a known
    /// position (the end)
    /// </summary>
    /// <param name="item">The data to add to the list</param>
    public void Add(T item)
    {
      AddBack(item);
    }

    /// <summary>
    /// Removes the first item that matches the item passed in. 
    /// Complexity: O(n)
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
            RemoveFromMiddle(current, previous);
          }
          else
          {
            RemoveFromStart(current);
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
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
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
    /// Complexity: O(n)
    /// </summary>
    public void Clear()
    {
      var current = _front;
      while (current != null)
      {
        var node = current;
        current = current.Next;
        node.Next = null;
      }

      _front = null;
      _back = null;
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
      return Get(item) != null ? true : false;
    }

    /// <summary>
    /// Copies the entire LinkedList to the array provided by the caller.
    /// Complexity: O(n)
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
    /// Complexity: O(1)
    /// </summary>
    public int Count
    {
      get;
      private set;
    }

    /// <summary>
    /// The value at the front of the list
    /// </summary>
    public T Front
    {
      get { return _front.Data; }
    }

    /// <summary>
    /// The value at the back of the list
    /// </summary>
    public T Back
    {
      get { return _back.Data; }
    }

    #endregion

    #region IIndexList<T> Members

    /// <summary>
    /// Adds a new item to the front of the list. 
    /// Complexity: O(1)
    /// </summary>
    /// <param name="item">The item to add to the front of the LinkedList</param>
    public void AddFront(T item)
    {
      var node = new ListNode<T>(item);
      AddFront(node);

      ++Count;
    }

    /// <summary>
    /// Adds a new item to the back of the list. 
    /// Complexity: O(1)
    /// </summary>
    /// <param name="item">The item to add to the back of the LinkedList</param>
    public void AddBack(T item)
    {
      var node = new ListNode<T>(item);
      AddBack(node);

      ++Count;
    }
    
    /// <summary>
    /// Adds a new item to the middle of the list at the given index
    /// Complexity: O(n)
    /// </summary>
    /// <param name="item">The item to add to the back of the LinkedList</param>
    public void AddIndex(T item, int index)
    {
      ValidateIndex(index);

      var node = new ListNode<T>(item);
      AddNodeAtIndex(node, index);

      ++Count;
    }

    /// <summary>
    /// Remove the item at the front of the list
    /// Complexity: O(1)
    /// </summary>
    public void RemoveFront()
    {
      ValidateNotEmpty();

      RemoveFromStart(_front);

      --Count;
    }

    /// <summary>
    /// Remove the item at the back of the list
    /// Complexity: O(n)
    /// </summary>
    public void RemoveBack()
    {
      ValidateNotEmpty();

      var current = _front;
      while (current != null)
      {
        if (current.Next.Next == null)
        {
          RemoveAllAfterNode(current);
        }
        current = current.Next;
      }

      --Count;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    public void RemoveIndex(int index)
    {
      ValidateNotEmpty();
      ValidateIndex(index);

      if (index == 0)
      {
        RemoveFront();
      }
      else if (index == Count - 1)
      {
        RemoveBack();
      }
      else
      {
        RemoveMiddle(index);

        --Count;
      }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int FirstIndexOf(T item)
    {
      int index = 0;
      var comparer = EqualityComparer<T>.Default;
      var current = _front;
      while (current != null)
      {
        if (comparer.Equals(current.Data, item) == true)
        {
          return index;
        }
        current = current.Next;
        ++index;
      }
      return -1;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    /// <returns></returns>
    public int LastIndexOf(T item)
    {
      int itemIndex = -1;
      int currentIndex = 0;

      var comparer = EqualityComparer<T>.Default;
      var current = _front;
      while (current != null)
      {
        if (comparer.Equals(current.Data, item) == true)
        {
          itemIndex = currentIndex;
        }
        current = current.Next;
        ++currentIndex;
      }
      return itemIndex;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public T Get(int index)
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

      return current.Data;
    }

    #endregion

    #region IIteratorList<T> Members

    /// <summary>
    /// Adds a node to the list after the node supplied
    /// 
    /// Note: This implementation is unsafe as there are no checks to ensure 
    /// that the supplied node is actually a part of this list. In order to 
    /// do that we would need to keep a reference to the parent list within 
    /// the node as well. I haven't done that yet. :) 
    /// 
    /// Complexity: O(1) as we have everything we need to update the list
    /// </summary>
    /// <param name="node">The node to add the new node after</param>
    /// <param name="data">The data to add to the node</param>
    public void AddAfter(IListNode<T> node, T data)
    {
      var oldNode = node as ListNode<T>;
      var newNode = new ListNode<T>(data);
      if (oldNode == null)
      {
        AddNodeToFront(newNode);
      }
      else if (oldNode.Next == null)
      {
        AddNodeToBack(newNode);
      }
      else
      {
        newNode.Next = oldNode.Next;
        oldNode.Next = newNode;
        ++Count;
      }
    }

    /// <summary>
    /// Adds a node to the list before the node supplied
    /// 
    /// Note: This implementation is unsafe as there are no checks to ensure 
    /// that the supplied node is actually a part of this list. In order to 
    /// do that we would need to keep a reference to the parent list within 
    /// the node as well. I haven't done that yet. :) 
    /// 
    /// Complexity: O(n) as we have to traverse the list to get the previous node
    /// </summary>
    /// <param name="node">The node to add the new node before</param>
    /// <param name="data">The data to add to the node</param>
    public void AddBefore(IListNode<T> node, T data)
    {
      var oldNode = node as ListNode<T>;
      var newNode = new ListNode<T>(data);
      if (oldNode == null)
      {
        AddNodeToBack(newNode);
      }
      else if (oldNode == _front)
      {
        AddNodeToFront(newNode);
      }
      else
      {
        var current = _front;
        while (current != null)
        {
          if (current.Next == oldNode)
          {
            newNode.Next = current.Next;
            current.Next = newNode;
            ++Count;
            return;
          }
          current = current.Next;
        }
      }
    }

    /// <summary>
    /// Removes the supplied node from the list
    /// 
    /// Note: This implementation is unsafe as there are no checks to ensure 
    /// that the supplied node is actually a part of this list. In order to 
    /// do that we would need to keep a reference to the parent list within 
    /// the node as well. I haven't done that yet. :) 
    /// 
    /// Complexity: O(n) worst as we have to traverse the list to get the
    /// neighbours
    /// </summary>
    /// <param name="node"></param>
    public void Remove(IListNode<T> node)
    {
      ValidateNotEmpty();

      var oldNode = node as ListNode<T>;
      if (oldNode == _back)
      {
        RemoveBack();
      }
      else if (oldNode == _front)
      {
        RemoveFront();
      }
      else
      {
        var current = _front;
        while (current != null)
        {
          if (current.Next == oldNode)
          {
            current.Next = oldNode.Next;
            --Count;
            return;
          }
          current = current.Next;
        }
      }
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
      _front = node;
    }

    /// <summary>
    /// Adds the node to the back of an already populated list
    /// </summary>
    /// <param name="node">The node to add to the end</param>
    private void AddNodeToBack(ListNode<T> node)
    {
      _back.Next = node;
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
        if (currentIndex == index - 1)
        {
          node.Next = current.Next;
          current.Next = node;
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
    private void RemoveFromStart(ListNode<T> node)
    {
      _front = node.Next;

      // If the list is now empty we need to remove the tail
      if (_front == null)
      {
        _back = null;
      }
      else
      {
        node.Next = null;
      }
    }
    
    /// <summary>
    /// Updates the back of the list to put the value passed in at the end.
    /// Everything to the right of this node in the list will be lost
    /// </summary>
    /// <param name="penultimate">The value to put at the end</param>
    private void RemoveAllAfterNode(ListNode<T> newBack)
    {
      newBack.Next = null;
      _back = newBack;
    }

    /// <summary>
    /// Remove the node passed in and update the neighbours in the list
    /// </summary>
    /// <param name="node">The node to remove from the list</param>
    /// <param name="previous">The previous node in the list</param>
    private void RemoveFromMiddle(ListNode<T> node, ListNode<T> previous)
    {
      // Bridge over the value to remove it from the list.
      previous.Next = node.Next;

      // Special case, if the value was at the end we need to
      // update the tail we have stored.
      if (previous.Next == null)
      {
        _back = previous;
      }
      else
      {
        node.Next = null;
      }
    }

    /// <summary>
    /// Add a node into the middle of the list
    /// </summary>
    /// <param name="node">The node to add</param>
    /// <param name="index">The index position to add the node</param>
    private void RemoveMiddle(int index)
    {
      int currentIndex = 0;
      var current = _front;

      while (current != null)
      {
        if (currentIndex == index - 1)
        {
          RemoveFromMiddle(current.Next, current);
          break;
        }
        ++currentIndex;
        current = current.Next;
      }
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
