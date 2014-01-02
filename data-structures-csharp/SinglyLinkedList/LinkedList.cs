using System.Collections;
using System.Collections.Generic;

namespace data_structures_csharp.SinglyLinkedList
{
  public class LinkedList<T> : ICollection<T>
  {
    #region ICollection<T> Members

    /// <summary>
    /// Adds a new item to the end of the list. 
    /// 
    /// Steps:
    /// 1) Allocates the new ListNode to store the item provided
    /// 
    /// 2) If this is the first node in the list, set both the head and 
    ///    tail of the LinkedList to the node created in step 1)
    ///    If this is not the first item, point the current tail to the
    ///    new node and update the tail to the new node.
    ///    
    /// 3) Update the count of items
    /// 
    /// Performance: O(1)
    /// </summary>
    /// <param name="item">The item to add to the end of the LinkedList</param>
    public void Add(T item)
    {
      var node = new ListNode<T>(item);
      if (_head == null)
      {
        _head = node;
        _tail = node;
      }
      else
      {
        _tail.Next = node;
        _tail = node;
      }
      ++Count;
    }

    /// <summary>
    /// Clears the entire list.
    /// 
    /// By setting the head and tail to null we allow the garbage collector
    /// to do it's thing and clear up the objects so we don't have to.
    /// 
    /// Performance: O(1)
    /// </summary>
    public void Clear()
    {
      _head = null;
      _tail = null;
      Count = 0;
    }

    /// <summary>
    /// Checks to see if the item is contained within the list 
    /// 
    /// Steps:
    /// 1) Loop through the list until we reach the end.
    /// 
    /// 2) For each node in the list we check to see if the data it stores
    ///    is equal to the item that was passed in.
    ///    
    /// 3) If item was found in step 2) return true
    /// 
    /// Performance: O(n)
    /// </summary>
    /// <param name="item">The item to search for in the LinkedList</param>
    /// <returns>True if item found, otherwise false</returns>
    public bool Contains(T item)
    {
      var current = _head;
      while (current != null)
      {
        if (current.Data.Equals(item) == true)
        {
          return true;
        }
        current = current.Next;
      }
      return false;
    }

    /// <summary>
    /// Copies the entire LinkedList to the array provided by the caller.
    /// Assumes that the array supplied will be of the correct size to hold
    /// this list
    /// 
    /// Performance: O(n)
    /// </summary>
    /// <param name="array">The array to populate</param>
    /// <param name="arrayIndex">The index of the array to start population at</param>
    public void CopyTo(T[] array, int arrayIndex)
    {
      var current = _head;
      while (current != null)
      {
        array[++arrayIndex] = current.Data;
        current = current.Next;
      }
    }

    /// <summary>
    /// The number of items currently stored in the LinkedList
    /// 
    /// Performance: O(1)
    /// </summary>
    public int Count
    {
      get;
      private set;
    }

    /// <summary>
    /// Whether or not the list is read only
    /// 
    /// Performance: O(1)
    /// </summary>
    public bool IsReadOnly
    {
      get { return false; }
    }

    /// <summary>
    /// Removes the first item that matches the item passed in. 
    /// 
    /// Steps:
    /// 1) Loop through the list until we reach the end.
    /// 
    /// 2) For each node in the list we check to see if the data it stores
    ///    is equal to the item that was passed in
    ///    
    /// 3) Decide where in the list this item falls.
    /// 
    ///    if the item was at the start of the list both head and tail are set to null 
    ///    if the item is in the middle or end we fill the gap and update the tail if needed
    /// 
    /// Performance: O(n)
    /// </summary>
    /// <param name="item">The item to remove from the LinkedList</param>
    /// <returns>True if item removed, otherwise false</returns>
    public bool Remove(T item)
    {
      // We keep hold of the previous node in the list so that 
      // we can fill in the gap when we remove the item 
      ListNode<T> previous = null;
      var current = _head;
      while (current != null)
      {
        if (current.Data.Equals(item) == true)
        {
          // if we have a previous value we can't be at the start of the
          // list. This will probably be the most likely scenario 
          if (previous != null)
          {
            // Bridge over the value to remove it from the list.
            // The garbage collector will handle the rest
            previous.Next = current.Next;

            // Special case, if the value was at the end we need to
            // update the tail we have stored.
            if (current.Next == null)
            {
              _tail = previous;
            }
          }
          else
          {
            _head = _head.Next;

            // Special case, if the value was at the start we need to
            // update the tail to be null as well (i.e. empty list)
            if (_head == null)
            {
              _tail = null;
            }
          }
          --Count;

          // We can bail out early as we only wanted to find 
          // the first occurance of the value
          return true;
        }

        previous = current;
        current = current.Next;
      }
      return false;
    }

    #endregion

    #region IEnumerable<T> Members

    /// <summary>
    /// Gets an enumerator instance to enumerate through the LinkedList
    /// 
    /// Performance (Enumeration): O(n)
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
    /// 
    /// Performance (Enumeration): O(n)
    /// </summary>
    /// <returns>The IEnumerator instance</returns>
    IEnumerator IEnumerable.GetEnumerator()
    {
      return ((IEnumerable<T>)this).GetEnumerator();
    }

    #endregion

    #region Fields

    /// <summary>
    /// The start of the list.
    /// 
    /// Note:
    /// 1) Will be null if the list is empty
    /// 
    /// 2) If this is the only item in the list then _head->Next will be null
    /// 
    /// 3) If multiple items in the list _head->Next will point to the second item
    /// </summary>
    private ListNode<T> _head;

    /// <summary>
    /// The end of the list
    /// 
    /// Note:
    /// 1) Will be null if the list is empty.
    /// 
    /// 2) Will be the same as _head if the list has one item in
    /// 
    /// 3) _tail->Next will always be null
    /// </summary>
    private ListNode<T> _tail;

    #endregion
  }
}
