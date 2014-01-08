using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures_csharp.Interfaces
{
  /// <summary>
  /// The IIteratorList interface allows for methods that require a node to be
  /// provided. Such as insertion and removal at arbitrary points in the 
  /// interface.
  /// 
  /// If however you just want to run through the different structures to see
  /// how they work feel free! 
  /// 
  /// These interfaces aren't of any use for a real list class. I am only using
  /// them to make testing easier as I am duplicating a lot of logic for each
  /// different list implementation and they should all behave the same apart 
  /// from for the complexity.
  /// </summary>
  /// <typeparam name="T"></typeparam>
  public interface IIteratorList<T> : ILinkedList<T>
  {
    void AddAfter(IListNode<T> node, T data);

    void AddBefore(IListNode<T> node, T data);

    void Remove(IListNode<T> node);
  }
}
