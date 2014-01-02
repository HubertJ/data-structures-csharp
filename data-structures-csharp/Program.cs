
using System;
using data_structures_csharp.SinglyLinkedList;

namespace data_structures_csharp
{
  class Program
  {
    static void Main(string[] args)
    {
      var list = new LinkedList<int>();

      list.Add(1);
      list.Add(2);
      list.Add(3);
      list.Add(4);
      list.Add(5);

      Console.WriteLine("Number of items in list : {0}", list.Count);
      Console.WriteLine("Does the list contain 0 : {0}", list.Contains(0));
      Console.WriteLine("Does the list contain 3 : {0}", list.Contains(3));

      Console.WriteLine("Removing 3 from the list");
      list.Remove(3);

      Console.WriteLine("Does the list contain 3 : {0}", list.Contains(3));
    }
  }
}
