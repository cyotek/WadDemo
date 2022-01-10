using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyotek.Data
{
  [Flags]
  public enum WadFormatFlag
  {
    None = 0,
    DirectorySize = 1,
    CompressionMode = 2,
    FileType = 4
  }
}
