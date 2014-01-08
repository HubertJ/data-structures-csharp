using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures_csharp.Interfaces
{
  /// <summary>
  /// The IList interface that I have created also implements the IEnumerable
  /// interface so we can still use these data structures in place of other
  /// C# ones, but that would be very silly, as although I am trying to make
  /// the algorithms are roughly as efficient as possible in terms of the 
  /// overall design, some of the decisions made in the classes will be sub
  /// optimal. 
  /// 
  /// If however you just want to run through the different structures to see
  /// how they work feel free! 
  /// 
  /// These interfaces aren't of any use for a real list class. I am only using
  /// them to make testing easier as I am duplicating a lot of logic for each
  /// different list implementation and they should all behave the same apart 
  /// from for the complexity.
  /// </summary>
  /// <typeparam name="T">The datatype to store in the list</typeparam>
  public interface ILinkedList<T> : IEnumerable<T>
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
