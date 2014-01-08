using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures_csharp.Interfaces
{
  public interface IGrowthStrategy
  {
    int NewSize(int currentSize);
  }
}
