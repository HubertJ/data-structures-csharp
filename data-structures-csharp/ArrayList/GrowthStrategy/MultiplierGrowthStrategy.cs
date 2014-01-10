using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using data_structures_csharp.Interfaces;

namespace data_structures_csharp.ArrayList.GrowthStrategy
{
  public class MultiplierGrowthStrategy : IGrowthStrategy
  {
    #region Construction

    public MultiplierGrowthStrategy(double multiplier)
    {
      _multiplier = multiplier;
    }

    #endregion

    #region IGrowthStrategy Members

    /// <summary>
    /// Simply doubles the current size
    /// </summary>
    /// <param name="currentSize">The current size of the array</param>
    /// <returns>The new size</returns>
    public int NewSize(int currentSize)
    {
      return (int)Math.Ceiling(currentSize * _multiplier);
    }

    #endregion

    #region Fields

    double _multiplier;

    #endregion
  }
}
