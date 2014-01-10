using System;
using data_structures_csharp.Interfaces;

namespace data_structures_csharp.ArrayList.GrowthStrategy
{
  public class GoldenGrowthStrategy : IGrowthStrategy
  {
    #region Construction

    public GoldenGrowthStrategy()
    {
      _multiple = (1 + Math.Sqrt(5)) / 2;
    }

    #endregion

    #region IGrowthStrategy Members

    /// <summary>
    /// The "ideal" strategy according to many. Hmmm!
    /// </summary>
    /// <param name="currentSize">The current size of the array</param>
    /// <returns>The new size</returns>
    public int NewSize(int currentSize)
    {
      return (int)Math.Ceiling(_multiple * currentSize);
    }

    #endregion

    #region Fields

    private readonly double _multiple;

    #endregion
  }
}
