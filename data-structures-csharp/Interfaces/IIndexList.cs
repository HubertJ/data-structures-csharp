
namespace data_structures_csharp.Interfaces
{
  /// <summary>
  /// An interface for my List classes to implement when accessing elements 
  /// through an index is required. I am using this in order to get more 
  /// experience and understanding of the implementation of the methods in 
  /// a List class. 
  /// 
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
  /// <typeparam name="T">The datatype to store in the List</typeparam>
  public interface IIndexList<T> : ILinkedList<T>
  {
    void AddFront(T item);

    void AddBack(T item);

    void AddIndex(T item, int index);

    void RemoveFront();

    void RemoveBack();

    void RemoveIndex(int index);

    int FirstIndexOf(T item);

    int LastIndexOf(T item);

    T Get(int index);
  }
}
