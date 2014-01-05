using System;
using data_structures_csharp.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
  [TestClass]
  public class SinglyLinkedList_ListTests : ListTests
  {
    protected override IList<T> CreateList<T>()
    {
      return new data_structures_csharp.SinglyLinkedList.LinkedList<T>();
    }
  }

  [TestClass]
  public class DoublyLinkedList_ListTests : ListTests
  {
    protected override IList<T> CreateList<T>()
    {
      return new data_structures_csharp.DoublyLinkedList.LinkedList<T>();
    }
  }

  [TestClass]
  public class MTFLinkedList_ListTests : ListTests
  {
    protected override IList<T> CreateList<T>()
    {
      return new data_structures_csharp.SelfOrganizingList.MTF.LinkedList<T>();
    }
  }

  [TestClass]
  public class CountLinkedList_ListTests : ListTests
  {
    protected override IList<T> CreateList<T>()
    {
      return new data_structures_csharp.SelfOrganizingList.Count.LinkedList<T>();
    }
  }

  public abstract class ListTests
  {
    [TestMethod]
    public void Clear()
    {
      var linkedList = CreateList<int>();

      linkedList.Add(1);
      linkedList.Add(2);
      linkedList.Add(3);

      linkedList.Clear();

      Assert.AreEqual(linkedList.Count, 0, "The list should be empty after clearing it");
    }

    [TestMethod]
    public void Contains()
    {
      var linkedList = CreateList<int>();

      linkedList.Add(1);

      Assert.IsTrue(linkedList.Contains(1), "The list should contain the value added");
      Assert.IsFalse(linkedList.Contains(4), "The list should not contain the value if it has not been added");
    }

    [TestMethod]
    public void CopyTo()
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
    public void CopyToIncorrectArrayIndex()
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
    public void CopyToNullArray()
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
    public void CopyToArrayTooSmall()
    {
      var list = CreateList<int>();

      list.Add(1);
      list.Add(2);
      list.Add(3);

      int[] array = new int[2];
      list.CopyTo(array, 0); // Should throw an exception because the array isn't big enough
    }


    [TestMethod]
    public void Count()
    {
      var list = CreateList<int>();

      list.Add(1);
      list.Add(2);
      list.Add(3);

      Assert.AreEqual(list.Count, 3, "The count of the list should be equal to all the items added and not removed");
    }

    [TestMethod]
    public void Get()
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

      Assert.IsNull(list.Get(7), "Item should not have been found in the list");
      Assert.IsNull(list.Get(8), "Item should not have been found in the list");
      Assert.IsNull(list.Get(9), "Item should not have been found in the list");

    }

    #region Implementation Factory

    protected abstract IList<T> CreateList<T>();

    #endregion 
  }
}
