﻿// Reading DOOM WAD files
// https://www.cyotek.com/blog/reading-doom-wad-files

// Writing DOOM WAD files
// https://www.cyotek.com/blog/writing-doom-wad-files

// Copyright © 2020-2022 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.TXT for the full text

// Found this example useful?
// https://www.cyotek.com/contribute

using System.Collections.ObjectModel;
using System.IO;

namespace Cyotek.Data
{
  public class WadLumpCollection : Collection<WadLump>
  {
    #region Private Fields

    private Stream _container;

    #endregion Private Fields

    #region Internal Constructors

    internal WadLumpCollection()
    {
    }

    #endregion Internal Constructors

    #region Internal Properties

    internal Stream Container
    {
      get => _container;
      set => _container = value;
    }

    #endregion Internal Properties

    #region Protected Methods

    protected override void ClearItems()
    {
      for (int i = 0; i < this.Count; i++)
      {
        this[i].SetContainer(null);
      }

      base.ClearItems();
    }

    protected override void InsertItem(int index, WadLump item)
    {
      item.SetContainer(_container);

      base.InsertItem(index, item);

      this.SetIndexes(index);
    }

    protected override void RemoveItem(int index)
    {
      this[index].SetContainer(null);

      base.RemoveItem(index);

      this.SetIndexes(index);
    }

    protected override void SetItem(int index, WadLump item)
    {
      this[index].SetContainer(null);
      item.SetContainer(_container);

      base.SetItem(index, item);

      this.SetIndexes(index);
    }

    #endregion Protected Methods

    #region Private Methods

    private void SetIndexes(int index)
    {
      for (int i = index; i < this.Count; i++)
      {
        this[i].Index = i;
      }
    }

    #endregion Private Methods
  }
}