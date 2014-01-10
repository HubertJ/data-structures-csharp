using System;
using data_structures_csharp.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{  
  [TestClass]
  public class MTFLinkedList_SelfOrganizingTests
  {
    [TestMethod]
    public void Organize_ItemsAreAlwaysMovedToFront()
    {
      var list = new data_structures_csharp.SelfOrganizingList.MTF.LinkedList<int>();

      list.Add(1);
      list.Add(2);
      list.Add(3);
      list.Add(4);
      list.Add(5);

      Assert.AreEqual(list.Front, 5, "The item at the start of the list should be the last item added");

      list.Contains(3);
      Assert.AreEqual(list.Front, 3, "The item at the start should have been updated to have the last one accessed");

      list.Contains(5);
      Assert.AreEqual(list.Front, 5, "The item at the start should have been updated to have the last one accessed");

      list.Contains(5);
      Assert.AreEqual(list.Front, 5, "The item at the start should have been updated to have the last one accessed");
    }
  }

  [TestClass]
  public class CountLinkedList_SelfOrganizingTests
  {
    [TestMethod]
    public void Organize_ItemsAreInOrderOfNumberOfAccesses()
    {
      var list = new data_structures_csharp.SelfOrganizingList.Count.LinkedList<int>();

      list.Add(1);
      list.Add(2);

      list.Contains(1);
      Assert.AreEqual(list.Front, 1, "The item at the start of the list should be the first item added");

      list.Contains(2);
      Assert.AreEqual(list.Front, 1, "The item at the start of the list should be the first item added");

      list.Contains(2);
      Assert.AreEqual(list.Front, 2, "The item at the start of the list should be the first item added");
    }
  }
}
