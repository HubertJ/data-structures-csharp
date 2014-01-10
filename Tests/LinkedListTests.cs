using System;
using data_structures_csharp.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
  [TestClass]
  public class SinglyLinkedList_ListTests : LinkedListTests
  {
    protected override ILinkedList<T> CreateList<T>()
    {
      return new data_structures_csharp.SinglyLinkedList.LinkedList<T>();
    }
  }

  [TestClass]
  public class DoublyLinkedList_ListTests : LinkedListTests
  {
    protected override ILinkedList<T> CreateList<T>()
    {
      return new data_structures_csharp.DoublyLinkedList.LinkedList<T>();
    }
  }

  [TestClass]
  public class MTFLinkedList_ListTests : LinkedListTests
  {
    protected override ILinkedList<T> CreateList<T>()
    {
      return new data_structures_csharp.SelfOrganizingList.MTF.LinkedList<T>();
    }

    [TestMethod]
    public override void CopyTo_ValidArray_ItemsCopiedToArray()
    {
      // Do nothing at the momento
      Assert.Fail();
    }
  }

  [TestClass]
  public class CountLinkedList_ListTests : LinkedListTests
  {
    protected override ILinkedList<T> CreateList<T>()
    {
      return new data_structures_csharp.SelfOrganizingList.Count.LinkedList<T>();
    }
  }

  public abstract class LinkedListTests
  {
    [TestMethod]
    public virtual void Clear_ListIsEmptied()
    {
      var linkedList = CreateList<int>();

      linkedList.Add(1);
      linkedList.Add(2);
      linkedList.Add(3);

      linkedList.Clear();

      Assert.AreEqual(linkedList.Count, 0, "The list should be empty after clearing it");
    }

    [TestMethod]
    public virtual void Contains_ItemInList_ItemFound()
    {
      var linkedList = CreateList<int>();

      linkedList.Add(1);

      Assert.IsTrue(linkedList.Contains(1), "The list should contain the value added");
    }

    [TestMethod]
    public virtual void Contains_ItemNotInList_ItemNotFound()
    {
      var linkedList = CreateList<int>();

      linkedList.Add(1);

      Assert.IsFalse(linkedList.Contains(4), "The list should not contain the value if it has not been added");
    }

    [TestMethod]
    public virtual void CopyTo_ValidArray_ItemsCopiedToArray()
    {
      var list = CreateList<int>();

      list.Add(1);
      list.Add(2);
      list.Add(3);

      int[] array = new int[3];
      list.CopyTo(array, 0);

      Assert.AreEqual(array[0], 1, "The value at the index should represent the position in the list");
      Assert.AreEqual(array[1], 2, "The value at the index should represent the position in the list");
      Assert.AreEqual(array[2], 3, "The value at the index should represent the position in the list");
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public virtual void CopyTo_InvalidArrayIndex_ArgumentOutOfRangeExceptionThrown()
    {
      var list = CreateList<int>();

      list.Add(1);
      list.Add(2);
      list.Add(3);

      int[] array = new int[3];
      list.CopyTo(array, -1); // Should throw an exception because index is outside the range allowed
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public virtual void CopyTo_NullArray_ArgumentNullExceptionThrown()
    {
      var list = CreateList<int>();

      list.Add(1);
      list.Add(2);
      list.Add(3);

      int[] array = null;
      list.CopyTo(array, 2); // Should throw an exception because the array is null
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentException))]
    public virtual void CopyTo_ArrayTooSmall_ArgumentExceptionThrown()
    {
      var list = CreateList<int>();

      list.Add(1);
      list.Add(2);
      list.Add(3);

      int[] array = new int[2];
      list.CopyTo(array, 0); // Should throw an exception because the array isn't big enough
    }


    [TestMethod]
    public virtual void Count_NumberOfItemsReturned()
    {
      var list = CreateList<int>();

      list.Add(1);
      list.Add(2);
      list.Add(3);

      Assert.AreEqual(list.Count, 3, "The count of the list should be equal to all the items added and not removed");
    }

    [TestMethod]
    public virtual void Get_ItemsInList_ItemsReturned()
    {
      var list = CreateList<int>();

      list.Add(1);
      list.Add(2);
      list.Add(3);
      list.Add(4);
      list.Add(5);
      list.Add(6);

      Assert.IsNotNull(list.Get(1), "Item should have been found in the list");
      Assert.IsNotNull(list.Get(2), "Item should have been found in the list");
      Assert.IsNotNull(list.Get(3), "Item should have been found in the list");
      Assert.IsNotNull(list.Get(4), "Item should have been found in the list");
      Assert.IsNotNull(list.Get(5), "Item should have been found in the list");
      Assert.IsNotNull(list.Get(6), "Item should have been found in the list");
    }

    [TestMethod]
    public virtual void Get_ItemsNotInList_NullReturned()
    {
      var list = CreateList<int>();

      list.Add(1);
      list.Add(2);
      list.Add(3);
      list.Add(4);
      list.Add(5);
      list.Add(6);

      Assert.IsNull(list.Get(7), "Item should not have been found in the list");
      Assert.IsNull(list.Get(8), "Item should not have been found in the list");
      Assert.IsNull(list.Get(9), "Item should not have been found in the list");
    }

    #region Implementation Factory

    protected abstract ILinkedList<T> CreateList<T>();

    #endregion 
  }
}
