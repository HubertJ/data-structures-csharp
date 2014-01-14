
using System;
namespace data_structures_csharp.Interfaces
{
  public interface ITree<T> where T : IComparable<T>, IEquatable<T>
  {
    void Add(T item);

    bool Remove(T item);
    
    void Clear();

    bool Contains(T item);

    int Count
    {
      get;
    }
  }
}
