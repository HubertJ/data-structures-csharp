using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data_structures_csharp.Interfaces
{
  /// <summary>
  /// The simplest interface for the list node. Each different list node has
  /// slightly different requirements (Next, Prev, Count, List, etc.) but all
  /// of them will contain access to the data.
  /// </summary>
  /// <typeparam name="T">The datatype to store in the list</typeparam>
  public interface IListNode<T>
  {
    T Data
    {
      get;
    }
  }
}
