using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures_csharp.Interfaces
{
  public interface IList<T> : IEnumerable<T>
  {
    void Add(T item);

    bool Remove(T item);

    IListNode<T> Get(T item);

    void Clear();

    bool Contains(T item);
    
    void CopyTo(T[] array, int arrayIndex);

    int Count
    {
      get;
    }

    T Front
    {
      get;
    }

    T Back
    {
      get;
    }
  }
}
