// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Copyright © 2020 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

namespace Cyotek.Tools.WadInfo.Commands
{
  internal abstract class Command<T>
      where T : class
  {
    #region Public Methods

    public abstract void Run(T options);

    #endregion Public Methods
  }
}