
using data_structures_csharp.Interfaces;
namespace data_structures_csharp.SinglyLinkedList
{
  /// <summary>
  /// Class to represent a node within the SinglyLinkedList.
  /// 
  /// As well as holding the data, this node will also hold 
  /// a reference to the next node in the list.
  /// 
  /// e.g. For a node storing integers
  /// | 1 | Next -|--> | 3 | Next -|--> null
  /// 
  /// </summary>
  /// <typeparam name="T">The datatype to be stored in this node</typeparam>
  public class ListNode<T> : IListNode<T>
  {
    /// <summary>
    /// The constructor for the list node. Takes the data in 
    /// and sets it in the node. 
    /// </summary>
    /// <param name="data">The data to be stored in the node</param>
    public ListNode(T data)
    {
      Data = data;
      Next = null;
    }

    /// <summary>
    /// The data stored within this node.
    /// </summary>
    public T Data
    {
      get;
      internal set;
    }

    /// <summary>
    /// The link to the next node in the list.
    /// Will be null if this is the last node in the list.
    /// </summary>
    public ListNode<T> Next
    {
      get;
      internal set;
    }
  }
}
