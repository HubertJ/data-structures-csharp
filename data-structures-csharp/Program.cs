
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace data_structures_csharp
{
  class Program
  {
    static void Main(string[] args)
    {
      var test = new LinkedList<int>();
      
      SinglyLinkedListTests();
      DoublyLinkedListTests();

      Console.ReadKey();
    }

    static void SinglyLinkedListTests()
    {
      var list = new SinglyLinkedList.LinkedList<int?>();

      list.Add(1);
      list.Add(2);
      list.Add(1);
      list.Add(4);

      Debug.Assert(list.Count == 4, "The count should equal the number of items added to the list");
      Debug.Assert(list.Contains(0) == false, "The contains method should return false if the item is not in the list");

      Debug.Assert(list.Contains(1) == true, "The contains method should return true if the item is in the list");
      Debug.Assert(list.Remove(1) == true, "It should be possible to remove an item in the list");
      Debug.Assert(list.Count == 3, "The count should equal the number of items in the list");
      Debug.Assert(list.Remove(1) == true, "It should be possible to remove an item in the list");
      Debug.Assert(list.Count == 2, "The count should equal the number of items in the list");
      Debug.Assert(list.Contains(1) == false, "The contains method should return false if the item is no longer in the list");

      list.Clear();
      Debug.Assert(list.Count == 0, "The list should be empty after calling clear");

      list.Add(null);
      list.Add(null);
      Debug.Assert(list.Count == 2, "The count should equal the number of items added to the list");
      Debug.Assert(list.Contains(null) == true, "The contains method should return true if the item is in the list");
      Debug.Assert(list.Remove(null) == true, "It should be possible to remove an item in the list");
      Debug.Assert(list.Count == 1, "The count should equal the number of items in the list");
    }

    static void DoublyLinkedListTests()
    {
      var list = new DoublyLinkedList.LinkedList<int?>();

      list.Add(1);
      list.Add(2);
      list.Add(1);
      list.Add(4);

      Debug.Assert(list.Count == 4, "The count should equal the number of items added to the list");
      Debug.Assert(list.Contains(0) == false, "The contains method should return false if the item is not in the list");

      Debug.Assert(list.Contains(1) == true, "The contains method should return true if the item is in the list");
      Debug.Assert(list.Remove(1) == true, "It should be possible to remove an item in the list");
      Debug.Assert(list.Count == 3, "The count should equal the number of items in the list");
      Debug.Assert(list.Remove(1) == true, "It should be possible to remove an item in the list");
      Debug.Assert(list.Count == 2, "The count should equal the number of items in the list");
      Debug.Assert(list.Contains(1) == false, "The contains method should return false if the item is no longer in the list");

      list.Clear();
      Debug.Assert(list.Count == 0, "The list should be empty after calling clear");

      list.Add(null);
      list.Add(null);
      Debug.Assert(list.Count == 2, "The count should equal the number of items added to the list");
      Debug.Assert(list.Contains(null) == true, "The contains method should return true if the item is in the list");
      Debug.Assert(list.Remove(null) == true, "It should be possible to remove an item in the list");
      Debug.Assert(list.Count == 1, "The count should equal the number of items in the list");
    }
  }
}
