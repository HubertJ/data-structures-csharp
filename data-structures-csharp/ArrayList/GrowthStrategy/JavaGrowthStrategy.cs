using data_structures_csharp.Interfaces;

namespace data_structures_csharp.ArrayList.GrowthStrategy
{
  public class JavaGrowthStrategy : IGrowthStrategy
  {
    #region IGrowthStrategy Members

    /// <summary>
    /// Strategy used by Java ArrayLists
    /// </summary>
    /// <param name="currentSize">The current size of the array</param>
    /// <returns>The new size</returns>
    public int NewSize(int currentSize)
    {
      return ((currentSize * 3) / 2) + 1;
    }

    #endregion
  }
}
