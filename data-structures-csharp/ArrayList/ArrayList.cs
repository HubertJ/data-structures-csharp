using System;
using System.Collections.Generic;
using data_structures_csharp.ArrayList.GrowthStrategy;
using data_structures_csharp.Interfaces;

namespace data_structures_csharp.ArrayList
{
  public class ArrayList<T> : IList<T>
  {
    #region Constructions

    /// <summary>
    /// Default constructor for an array list
    /// </summary>
    public ArrayList()
      :this(0)
    {
    }

    /// <summary>
    /// Create an array list with the allocated size
    /// </summary>
    /// <param name="size">The default size of the array</param>
    public ArrayList(int size)
      : this(size, new DoubleGrowthStrategy())
    {
    }

    /// <summary>
    /// Constructor if ArrayList taking the default size and 
    /// the growth strategy to use
    /// </summary>
    /// <param name="size">The size to start the array</param>
    /// <param name="growth">The growth strategy to use</param>
    public ArrayList(int size, IGrowthStrategy growth)
    {
      if (size < 0)
      {
        throw new ArgumentOutOfRangeException("size", "The size of the array must be 0 or greater");
      }

      _data = new T[size];
      _growth = growth;
      Count = 0;
    }

    #endregion 

    #region IList<T> Members

    /// <summary>
    /// Finds the index of an item in the list.
    /// Complexity : O(n) as we need to search the entire list for the item if
    /// it doesn't exist
    /// </summary>
    /// <param name="item">The item to search for</param>
    /// <returns>The index of the item if it is found, otherwise -1</returns>
    public int IndexOf(T item)
    {
      var comparer = EqualityComparer<T>.Default;
      int index = 0;
      while (index < _data.Length)
      {
        if (comparer.Equals(_data[index], item))
        {
          return index;
        }
      }
      return -1;
    }

    /// <summary>
    /// Inserts the given item at the the given index.
    /// Complexity : O(n) as we will have to move everything after the index
    /// into the new position to make way for the new item
    /// </summary>
    /// <param name="index">The index to add the new data item to</param>
    /// <param name="item">The item to add</param>
    public void Insert(int index, T item)
    {
      ValidateIndex(index);
      Count++;
      ResizeArray();

      Array.Copy(_data, index, _data, index + 1, _data.Length - index);
      _data[index] = item;
    }

    /// <summary>
    /// Removes the item at the given index. We will not resize the array
    /// as we may want to use this space later
    /// Complexity : O(n) as we will have to move everything after this
    /// index back to fill in the gap it has left.
    /// </summary>
    /// <param name="index">The index to remove</param>
    public void RemoveAt(int index)
    {
      ValidateIndex(index);
      Count--;
      Array.Copy(_data, index + 1, _data, index, _data.Length - index + 1);
    }

    /// <summary>
    /// Gets or sets the item at the given index
    /// Complexity : O(1) as we know exactly where the item is
    /// </summary>
    /// <param name="index">The index to return</param>
    /// <returns>The data at the given index</returns>
    public T this[int index]
    {
      get
      {
        ValidateIndex(index);
        return _data[index];
      }
      set
      {
        ValidateIndex(index);
        _data[index] = value;
      }
    }

    #endregion

    #region ICollection<T> Members

    /// <summary>
    /// Adds an item to the end of a list. 
    /// Complexity : O(1) amortized as although we may have to resize and 
    /// therefore shift everything from the old array to the new one, on 
    /// average this will not be more costly than the gains of having the
    /// extra space in the array
    /// </summary>
    /// <param name="item"></param>
    public void Add(T item)
    {
      Insert(Count, item);
    }

    /// <summary>
    /// Clear the entire list.
    /// Complexity : O(1)
    /// </summary>
    public void Clear()
    {
      _data = new T[0];
      Count = 0;
    }

    /// <summary>
    /// Checks whether an item is contained within the list.
    /// Complexity : O(n) worst, as we will have to visit each item in the list
    /// to know that something doesn't exist 
    /// </summary>
    /// <param name="item">The item to search the list for</param>
    /// <returns>Returns true if it exists, otherwise false</returns>
    public bool Contains(T item)
    {
      return IndexOf(item) != -1;
    }

    /// <summary>
    /// Copies all of the data in the list into a new array starting at a given
    /// array index
    /// </summary>
    /// <param name="array">The target array</param>
    /// <param name="arrayIndex">The index to start at</param>
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

      Array.Copy(_data, 0, array, arrayIndex, _data.Length);
    }

    /// <summary>
    /// Returns how many items are in the list
    /// Complexity : O(1)
    /// </summary>
    public int Count
    {
      get;
      private set;
    }

    /// <summary>
    /// Is the data in this array read only? (NO!)
    /// Complexity : O(1)
    /// </summary>
    public bool IsReadOnly
    {
      get { return false; }
    }

    /// <summary>
    /// Removes a given item from the list. 
    /// Complexity : O(n) as we are required to search through the list
    /// in order to find the index of the item. As the data is unsorted
    /// we can't do anything but look at every one.
    /// </summary>
    /// <param name="item">The item to remove from the list</param>
    /// <returns>True if an item was removed, otherwise false</returns>
    public bool Remove(T item)
    {
      var indexOf = IndexOf(item);

      if (indexOf != -1)
      {
        RemoveAt(indexOf);
        return true;
      }

      return false;
    }

    #endregion

    #region IEnumerable<T> Members

    public IEnumerator<T> GetEnumerator()
    {
      for (int i = 0; i < Count; ++i)
      {
        yield return _data[i];
      }
    }

    #endregion

    #region IEnumerable Members

    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
      throw new NotImplementedException();
    }

    #endregion

    #region Implementation

    /// <summary>
    /// Resize the array and move the data across
    /// </summary>
    private void ResizeArray()
    {
      if (Count > _data.Length)
      {
        // Backup the data before we move it
        T[] oldData = _data;

        // At the moment I will just double everything
        var newLength = _data.Length == 0 ? 8 : _growth.NewSize(_data.Length);
        _data = new T[newLength];

        // Try figure out how this works internally! 
        // It seems a bit inefficient to copy it all to the array without
        // leaving a gap when we know for an insert we will have to create 
        // a gap. Look into that as well
        Array.Copy(oldData,  _data, oldData.Length);
      }
    }

    /// <summary>
    /// Validate that the index supplied is within the range of this array
    /// </summary>
    /// <param name="index"></param>
    private void ValidateIndex(int index)
    {
      if (index < 0 || index >= Count)
      {
        throw new IndexOutOfRangeException();
      }
    }

    #endregion 

    #region Fields

    private T[] _data;

    private readonly IGrowthStrategy _growth;

    #endregion
  }
}
