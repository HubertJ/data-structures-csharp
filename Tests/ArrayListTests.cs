using System;
using data_structures_csharp.ArrayList;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
  [TestClass]
  public class ArrayListTests
  {
    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Construction_IncorrectSize_ArgumentOutOfRangeExceptionThrown()
    {
      var arrayList = new ArrayList<int>(-1);
    }
    
    [TestMethod]
    public void Construction_ValidSize_ConstructionWorks()
    {
      var arrayList = new ArrayList<int>(4);
    }
  }
}
