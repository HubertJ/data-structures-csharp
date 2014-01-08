using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data_structures_csharp.Interfaces;

namespace data_structures_csharp.SelfOrganizingList.Count
{
  public class LinkedList<T> : Interfaces.ILinkedList<T>
  {
    #region IList<T> Members

    public void Add(T item)
    {
      var node = new ListNode<T>(item);
      AddBack(node);

      ++Count;
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
          UpdateCountAndMove(current);
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
      int currentIndex = 0;
      var current = _front;

      while (current != null)
      {
        if (currentIndex == index)
        {
          RemoveFromMiddle(current);
          break;
        }
        ++currentIndex;
        current = current.Next;
      }
    }

    /// <summary>
    /// Moves the node to the front of the list
    /// </summary>
    /// <param name="current"></param>
    private void UpdateCountAndMove(ListNode<T> node)
    {
      node.Count++;
      
      while (node.Prev != null && node.Prev.Count < node.Count)
      {
        node = ShiftLeft(node);
      }
    }

    private ListNode<T> ShiftLeft(ListNode<T> node)
    {
      ListNode<T> prevprev = null;
      var previous = node.Prev;
      var next = node.Next;

      if (previous == null)
      {
        return _front; // Already as far left as can be
      }
      else
      {
        prevprev = previous.Prev;
        previous.Next = next;
        previous.Prev = node;
      }

      if (prevprev != null)
      {
        prevprev.Next = node;
      }
      else
      {
        _front = node;
      }

      if (next != null)
      {
        next.Prev = previous;
      }
      else
      {
        _back = previous;
      }

      node.Prev = prevprev;
      node.Next = previous;

      return node;
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
