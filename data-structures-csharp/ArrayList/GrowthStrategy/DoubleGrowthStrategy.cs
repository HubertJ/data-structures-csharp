using data_structures_csharp.Interfaces;

namespace data_structures_csharp.ArrayList.GrowthStrategy
{
  public class DoubleGrowthStrategy : IGrowthStrategy
  {
    #region IGrowthStrategy Members

    /// <summary>
    /// Simply doubles the current size
    /// </summary>
    /// <param name="currentSize">The current size of the array</param>
    /// <returns>The new size</returns>
    public int NewSize(int currentSize)
    {
      return currentSize * 2;
    }

    #endregion
  }
}
