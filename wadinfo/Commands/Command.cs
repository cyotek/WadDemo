using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyotek.Tools.WadInfo.Commands
{
  internal abstract class Command<T>
      where T : class
  {
    public abstract void Run(T options);
  }
}
