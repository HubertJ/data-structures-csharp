
using System;
using data_structures_csharp.DoublyLinkedList;

namespace data_structures_csharp.Queue
{
  class Deque<T>
  {
    #region Construction

    public Deque()
    {
      _data = new LinkedList<T>();
    }

    #endregion

    #region Deque Interface

    /// <summary>
    /// Adds an item to the back of the queue
    /// Complexity : O(1)
    /// </summary>
    /// <param name="item"></param>
    public void PushBack(T item)
    {
      _data.AddBack(item);
    }

    /// <summary>
    /// Removes the last item from back of the queue
    /// Complexity : O(1)
    /// </summary>
    /// <returns>The value at front of the queue</returns>
    public T PopBack()
    {
      T item = _data.Back;
      _data.RemoveBack();
      return item;
    }

    /// <summary>
    /// Returns the value currently at the back of the queue
    /// Complexity : O(1)
    /// </summary>
    /// <returns>The value at the top of the stack</returns>
    public T PeekBack()
    {
      return _data.Back;
    }

    /// <summary>
    /// Adds an item to the back of the queue
    /// Complexity : O(1)
    /// </summary>
    /// <param name="item"></param>
    public void PushFront(T item)
    {
      _data.AddFront(item);
    }

    /// <summary>
    /// Removes the last item from back of the queue
    /// Complexity : O(1)
    /// </summary>
    /// <returns>The value at front of the queue</returns>
    public T PopFront()
    {
      T item = _data.Front;
      _data.RemoveFront();
      return item;
    }

    /// <summary>
    /// Returns the value currently at the back of the queue
    /// Complexity : O(1)
    /// </summary>
    /// <returns>The value at the top of the stack</returns>
    public T PeekFront()
    {
      return _data.Front;
    }

    /// <summary>
    /// The number of items currently stored on the stack
    /// </summary>
    public int Count
    {
      get { return _data.Count; }
    }

    #endregion

    #region Fields

    LinkedList<T> _data;

    #endregion
  }
}
