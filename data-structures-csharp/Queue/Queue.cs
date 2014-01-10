
using System;
using data_structures_csharp.DoublyLinkedList;

namespace data_structures_csharp.Queue
{
  public class Queue<T>
  {
    #region Construction

    public Queue()
    {
      _data = new LinkedList<T>();
    }

    #endregion

    #region Queue Interface

    /// <summary>
    /// Adds an item to the back of the queue
    /// Complexity : O(1)
    /// </summary>
    /// <param name="item"></param>
    public void Push(T item)
    {
      _data.AddBack(item);
    }

    /// <summary>
    /// Removes the first item from the queue
    /// Complexity : O(1)
    /// </summary>
    /// <returns>The value at front of the queue</returns>
    public T Pop()
    {
      T item = _data.Front;
      _data.RemoveFront();
      return item;
    }

    /// <summary>
    /// Returns the value currently at the front of the queue
    /// Complexity : O(1)
    /// </summary>
    /// <returns>The value at the top of the stack</returns>
    public T Peek()
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
