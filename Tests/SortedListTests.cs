using System;
using data_structures_csharp.DoublyLinkedList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
  [TestClass]
  public class SortedListTests
  {
    [TestMethod]
    public void TestMethod1()
    {
      var list = new SortedLinkedList<int>();

      list.Add(5);
      list.Add(1);
      list.Add(3);
      list.Add(6);
      list.Add(10);
      list.Add(3);
      list.Add(5);
    }
  }
}
