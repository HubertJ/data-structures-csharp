using System;
using data_structures_csharp.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
  [TestClass]
  public class SinglyLinkedList_IndexTests : IndexListTests
  {
    protected override IIndexList<T> CreateIndexList<T>()
    {
      return new data_structures_csharp.SinglyLinkedList.LinkedList<T>();
    }
  }
 
  [TestClass]
  public class DoublyLinkedList_IndexTests : IndexListTests
  {
    protected override IIndexList<T> CreateIndexList<T>()
    {
      return new data_structures_csharp.DoublyLinkedList.LinkedList<T>();
    }
  }

  public abstract class IndexListTests
  {
    [TestMethod]
    public void AddFront_ItemsAddedToFront()
    {
      var linkedList = CreateIndexList<int>();

      linkedList.AddFront(1);
      Assert.AreEqual(linkedList.Front, 1, "The value should have been added to the front of the list");

      linkedList.AddFront(2);
      Assert.AreEqual(linkedList.Front, 2, "The value should have been added to the front of the list");
    }

    [TestMethod]
    public void AddBack_ItemsAddedToBack()
    {
      var linkedList = CreateIndexList<int>();

      linkedList.AddBack(1);
      Assert.AreEqual(linkedList.Back, 1, "The value should have been added to the back of the list");

      linkedList.AddBack(2);
      Assert.AreEqual(linkedList.Back, 2, "The value should have been added to the back of the list");
    }

    [TestMethod]
    public void AddIndex_IndexAtFront_ItemAddedToFront()
    {
      var linkedList = CreateIndexList<int>();

      linkedList.AddBack(1);
      linkedList.AddBack(2);
      linkedList.AddBack(3);
      linkedList.AddBack(4);

      linkedList.AddIndex(5, 0);

      Assert.AreEqual(linkedList.Front, 5, "The value should have been added to the front of the list");
    }

    [TestMethod]
    public void AddIndex_IndexAtBack_ItemAddedToBack()
    {
      var linkedList = CreateIndexList<int>();

      linkedList.AddBack(1);
      linkedList.AddBack(2);
      linkedList.AddBack(3);
      linkedList.AddBack(4);

      linkedList.AddIndex(5, 4);

      Assert.AreEqual(linkedList.Back, 5, "The value should have been added to the back of the list");
    }

    [TestMethod]
    public void AddIndex_IndexInMiddle_ItemAddedToMiddle()
    {
      var linkedList = CreateIndexList<int>();

      linkedList.AddBack(1);
      linkedList.AddBack(2);
      linkedList.AddBack(3);

      linkedList.AddIndex(5, 1);

      Assert.AreEqual(linkedList.Get(1), 5, "The value should be in the correct position in the array after adding it at a specific index");
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void AddIndex_IndexOutOfRange_IndexOutOfRangeExceptionThrown()
    {
      var linkedList = CreateIndexList<int>();

      linkedList.AddIndex(1, 8); // Throws exception because the index (8) is out of range
    }

    [TestMethod]
    [ExpectedException(typeof(InvalidOperationException))]
    public void Remove_ListEmpty_InvalidOperationExceptionThrown()
    {
      var linkedList = CreateIndexList<int>();

      linkedList.Remove(1); // Throws exception because the list is empty
    }

    [TestMethod]
    [ExpectedException(typeof(IndexOutOfRangeException))]
    public void RemoveIndex_InvalidIndex_IndexOutOfRangeExceptionThrown()
    {
      var linkedList = CreateIndexList<int>();
      linkedList.Add(1);

      linkedList.RemoveIndex(-1); // Throws exception because the index (-1) is out of range
    }
    
    [TestMethod]
    public void RemoveFront_ItemRemovedFromFront()
    {
      var linkedList = CreateIndexList<int>();

      linkedList.AddBack(1);
      linkedList.AddBack(2);
      linkedList.AddBack(3);

      Assert.AreEqual(linkedList.Front, 1, "The value at the front should be the last value added to the front at this stage");

      linkedList.RemoveFront();

      Assert.AreEqual(linkedList.Front, 2, "The value at the front should have been updated after removal of the front");
    }

    [TestMethod]
    public void RemoveBack_ItemRemovedFromBack()
    {
      var linkedList = CreateIndexList<int>();

      linkedList.AddBack(1);
      linkedList.AddBack(2);
      linkedList.AddBack(3);

      Assert.AreEqual(linkedList.Back, 3, "The value at the back should be the last value added to the back at this stage");

      linkedList.RemoveBack();

      Assert.AreEqual(linkedList.Back, 2, "The value at the back should have been updated after removal of the back");
    }

    [TestMethod]
    public void RemoveIndex_IndexAtFront_ItemRemovedFromFront()
    {
      var linkedList = CreateIndexList<int>();

      linkedList.AddBack(1);
      linkedList.AddBack(2);
      linkedList.AddBack(3);

      Assert.AreEqual(linkedList.Front, 1, "The value at the front should be the first value added to the back at this stage");

      linkedList.RemoveIndex(0);

      Assert.AreEqual(linkedList.Front, 2, "The value at the front should have been updated after removal of index 0");
    }

    [TestMethod]
    public void RemoveIndex_IndexAtBack_ItemRemovedFromBack()
    {
      var linkedList = CreateIndexList<int>();

      linkedList.AddBack(1);
      linkedList.AddBack(2);
      linkedList.AddBack(3);

      Assert.AreEqual(linkedList.Back, 3, "The value at the back should be the last value added to the back at this stage");

      linkedList.RemoveIndex(2);

      Assert.AreEqual(linkedList.Back, 2, "The value at the back should have been updated after removal of the last index");
    }

    [TestMethod]
    public void RemoveIndex_IndexInMiddle_ItemRemovedFromMiddle()
    {
      var linkedList = CreateIndexList<int>();

      linkedList.AddBack(0);
      linkedList.AddBack(1);
      linkedList.AddBack(2);
      linkedList.AddBack(3);
      linkedList.AddBack(4);

      Assert.IsTrue(linkedList.Contains(3), "The value we added should be contained in the list");

      linkedList.RemoveIndex(3);

      Assert.IsFalse(linkedList.Contains(3), "The value we added should not longer be contained in the list after removing its index");
    }

    #region Implementation Factory

    protected abstract IIndexList<T> CreateIndexList<T>();
    
    #endregion 
  }
}
