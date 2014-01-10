using System;
using data_structures_csharp.ArrayList.GrowthStrategy;
using data_structures_csharp.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
  [TestClass]
  public class GrowthStrategyTests
  {
    [TestMethod]
    public void DoubleGrowthStrategy_SizeOfArrayIsDoublePreviousSize()
    {
      var gs = new DoubleGrowthStrategy();
      
      int size = 2;

      size = gs.NewSize(size);
      Assert.AreEqual(size, 4);

      size = gs.NewSize(size);
      Assert.AreEqual(size, 8);

      size = gs.NewSize(size);
      Assert.AreEqual(size, 16);

      size = gs.NewSize(size);
      Assert.AreEqual(size, 32);

      size = gs.NewSize(size);
      Assert.AreEqual(size, 64);

      size = gs.NewSize(size);
      Assert.AreEqual(size, 128);

      size = gs.NewSize(size);
      Assert.AreEqual(size, 256);

      size = gs.NewSize(size);
      Assert.AreEqual(size, 512);

      size = gs.NewSize(size);
      Assert.AreEqual(size, 1024);

      size = gs.NewSize(size);
      Assert.AreEqual(size, 2048);
    }

    [TestMethod]
    public void JavaGrowthStrategy_SizeOfArrayIsRoughlyOneAndAHalfPreviousSize()
    {
      var gs = new JavaGrowthStrategy();

      int size = 2;

      size = gs.NewSize(size);
      Assert.IsTrue(size <= 4);

      size = gs.NewSize(size);
      Assert.IsTrue(size <= 8);

      size = gs.NewSize(size);
      Assert.IsTrue(size <= 16);

      size = gs.NewSize(size);
      Assert.IsTrue(size <= 32);

      size = gs.NewSize(size);
      Assert.IsTrue(size <= 64);

      size = gs.NewSize(size);
      Assert.IsTrue(size <= 128);

      size = gs.NewSize(size);
      Assert.IsTrue(size <= 256);

      size = gs.NewSize(size);
      Assert.IsTrue(size <= 512);

      size = gs.NewSize(size);
      Assert.IsTrue(size <= 1024);

      size = gs.NewSize(size);
      Assert.IsTrue(size <= 2048);
    }

  }
}
