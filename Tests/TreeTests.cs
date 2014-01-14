using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using data_structures_csharp.BinarySearchTree;

namespace Tests
{
  [TestClass]
  public class TreeTests
  {
    [TestMethod]
    public void Add_EmptyTree_ValueAtRoot()
    {
      Tree<int> tree = new Tree<int>();

      tree.Add(100);

      Assert.AreEqual(100, tree.Root.Data, "The value added should be the root value");
    }

    [TestMethod]
    public void Add_ValueLessThanRoot_ValueIsRootLeftChild()
    {
      Tree<int> tree = new Tree<int>();

      tree.Add(100);
      tree.Add(50);

      Assert.AreEqual(50, tree.Root.Left.Data, "The value added should be the left child of the root");
    }

    [TestMethod]
    public void Add_ValueGreaterThanRoot_ValueIsRootRightChild()
    {
      Tree<int> tree = new Tree<int>();

      tree.Add(100);
      tree.Add(150);

      Assert.AreEqual(150, tree.Root.Left.Data, "The value added should be the left child of the root");
    }

    [TestMethod]
    public void Add_GreaterThanRootLeftChild_ValueIsRightChild()
    {
      Tree<int> tree = new Tree<int>();

      tree.Add(100);
      tree.Add(50);
      tree.Add(75);

      Assert.AreEqual(75, tree.Root.Left.Right.Data, "The value added should be the right child of the roots left child");
    }

    [TestMethod]
    public void Add_GreaterThanRootRightChild_ValueIsRightChild()
    {
      Tree<int> tree = new Tree<int>();

      tree.Add(100);
      tree.Add(150);
      tree.Add(175);

      Assert.AreEqual(175, tree.Root.Right.Right.Data, "The value added should be the right child of the roots right child");
    }

    [TestMethod]
    public void Add_LessThanRootRightChild_ValueIsLeftChild()
    {
      Tree<int> tree = new Tree<int>();

      tree.Add(100);
      tree.Add(150);
      tree.Add(125);

      Assert.AreEqual(125, tree.Root.Right.Left.Data, "The value added should be the left child of the roots right child");
    }

    [TestMethod]
    public void Add_LessThanRootLeftChild_ValueIsLeftChild()
    {
      Tree<int> tree = new Tree<int>();

      tree.Add(100);
      tree.Add(50);
      tree.Add(25);

      Assert.AreEqual(25, tree.Root.Left.Left.Data, "The value added should be the left child of the roots left child");
    }

    [TestMethod]
    public void Remove_Root_LeftChildShouldBeRoot()
    {
      Tree<int> tree = new Tree<int>();

      tree.Add(100);
      tree.Add(50);

      tree.Remove(100);

      Assert.AreEqual(50, tree.Root.Data, "The new root should be the old roots left child");
    }

    [TestMethod]
    public void Remove_Root_RightChildShouldBeRoot()
    {
      Tree<int> tree = new Tree<int>();

      tree.Add(100);
      tree.Add(50);
      tree.Add(150);

      tree.Remove(100);

      Assert.AreEqual(150, tree.Root.Data, "The new root should be the old roots right child");
    }

    [TestMethod]
    public void Remove_Root_RightMinChildShouldBeRoot()
    {
      Tree<int> tree = new Tree<int>();

      tree.Add(100);
      tree.Add(50);
      tree.Add(150);
      tree.Add(125);

      tree.Remove(100);

      Assert.AreEqual(125, tree.Root.Data, "The new root should be the old roots minimum right child");
    }
  }
}
