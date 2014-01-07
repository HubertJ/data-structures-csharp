using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures_csharp.ArrayList
{
  public class ArrayList<T> : IList<T>
  {
    T[] _data;

    #region Constructions

    public ArrayList(int size)
    {
      if (size < 0)
      {
        throw new ArgumentOutOfRangeException("size", "The size of the array must be 0 or greater");
      }

      _data = new T[size];
      Count = 0;
    }

    #endregion 

    #region IList<T> Members

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

    public void Insert(int index, T item)
    {
      ValidateIndex(index);
      Count++;
      ResizeArray();

      Array.Copy(_data, index, _data, index + 1, _data.Length - index);
      _data[index] = item;
    }

    public void RemoveAt(int index)
    {
      ValidateIndex(index);
      Count--;
      Array.Copy(_data, index + 1, _data, index, _data.Length - index + 1);
    }

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

    public void Add(T item)
    {
      Insert(Count, item);
    }

    public void Clear()
    {
      Array.Clear(_data, 0, Count);
      Count = 0;
    }

    public bool Contains(T item)
    {
      return IndexOf(item) != -1;
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
      Array.Copy(_data, 0, array, arrayIndex, _data.Length);
    }

    public int Count
    {
      get;
      private set;
    }

    public bool IsReadOnly
    {
      get { return false; }
    }

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

    private void ResizeArray()
    {
      if (Count > _data.Length)
      {
        // Backup the data before we move it
        T[] oldData = _data;

        // At the moment I will just double everything
        var newLength = _data.Length == 0 ? 1 : _data.Length * 2;
        _data = new T[newLength];

        // Try figure out how this works internally! 
        // It seems a bit inefficient to copy it all to the array without
        // leaving a gap when we know for an insert we will have to create 
        // a gap. Look into that as well
        Array.Copy(oldData, _data, oldData.Length);
      }
    }

    private void ValidateIndex(int index)
    {
      if (index < 0 || index >= Count)
      {
        throw new IndexOutOfRangeException();
      }
    }
  }
}
