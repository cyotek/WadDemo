using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Cyotek.Data.Wad
{
  public class WadLumpCollection : Collection<WadLump>
  {
    #region Private Fields

    private readonly Stream _container;

    #endregion Private Fields

    #region Internal Constructors

    internal WadLumpCollection(Stream container)
    {
      _container = container;
    }

    #endregion Internal Constructors

    #region Internal Properties

    internal Stream Container
    {
      get { return _container; }
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

    private void SetIndexes(int index)
    {
      for (int i = index; i < this.Count; i++)
      {
        this[i].Index = i;
      }
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
  }
}