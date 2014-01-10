
using System;
using data_structures_csharp.ArrayList;
namespace data_structures_csharp.Stack
{
  public class Stack<T>
  {
    #region Construction

    public Stack()
    {
      _data = new ArrayList<T>(8);
    }

    #endregion

    #region Stack Interface

    /// <summary>
    /// Pushes an item onto the top of the stack
    /// Complexity : O(1) amortized
    /// </summary>
    /// <param name="item"></param>
    public void Push(T item)
    {
      _data.Add(item);
    }

    /// <summary>
    /// Removes the item from the top of the stack and returns the value
    /// Complexity : O(1)
    /// </summary>
    /// <returns>The value at the top of the stack before removing</returns>
    public T Pop()
    {
      int index = _data.Count - 1;
      if (index < 0)
      {
        throw new InvalidOperationException("The stack is empty and there are no items to remove");
      }

      T item = _data[index];
      _data.RemoveAt(index);
      return item;
    }

    /// <summary>
    /// Returns the value currently on the top of the stack without removing it
    /// Complexity : O(1)
    /// </summary>
    /// <returns>The value at the top of the stack</returns>
    public T Peek()
    {
      int index = _data.Count - 1;
      if (index < 0)
      {
        throw new InvalidOperationException("The stack is empty and there are no items to peek");
      }
      return _data[index];
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

    ArrayList<T> _data;

    #endregion
  }
}
