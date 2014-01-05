using data_structures_csharp.Interfaces;

namespace data_structures_csharp.SelfOrganizingList.Count
{
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
      Prev = null;
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

    /// <summary>
    /// The link to the previous node in the list.
    /// Will be null if this is the first node in the list.
    /// </summary>
    public ListNode<T> Prev
    {
      get;
      internal set;
    }

    /// <summary>
    /// Keeps count of the number of times this node is accessed
    /// </summary>
    public int Count
    {
      get;
      internal set;
    }
  }
}
