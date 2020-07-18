using System;
using System.IO;

namespace Cyotek.Data.Wad
{
  public class WadLump : IEquatable<WadLump>
  {
    #region Private Fields

    private Stream _container;

    private int _index;

    private string _name;

    private int _offset;

    private string _pendingFileName;

    private int _size;

    #endregion Private Fields

    #region Public Properties

    public int Index
    {
      get { return _index; }
      internal set { _index = value; }
    }

    public string Name
    {
      get { return _name; }
      set { _name = value; }
    }

    public int Offset
    {
      get { return _offset; }
      set { _offset = value; }
    }

    public int Size
    {
      get { return _size; }
      set { _size = value; }
    }

    #endregion Public Properties

    #region Internal Properties

    internal string PendingFileName
    {
      get { return _pendingFileName; }
      set { _pendingFileName = value; }
    }

    #endregion Internal Properties

    #region Public Methods

    public bool Equals(WadLump other)
    {
      return !(other is null)
         && (object.ReferenceEquals(this, other)
         || (
 string.Equals(_name, other._name)
 && _offset.Equals(other._offset)
 && _size.Equals(other._size)
         ));
    }

    public override bool Equals(object obj)
    {
      return obj is WadLump other && this.Equals(other);
    }

    public Stream GetInputStream()
    {
      Stream result;

      if (string.IsNullOrEmpty(_pendingFileName))
      {
        result = _container != null
           ? new OffsetStream(_container, _offset, _size)
           : null;
      }
      else
      {
        result = File.OpenRead(_pendingFileName);
      }

      return result;
    }

    public byte[] ToArray()
    {
      byte[] buffer;

      buffer = new byte[_size];

      if (_size > 0)
      {
        using (Stream stream = this.GetInputStream())
        {
          stream.Read(buffer, 0, _size);
        }
      }

      return buffer;
    }

    public override string ToString()
    {
      return _name;
    }

    #endregion Public Methods

    #region Internal Methods

    internal void SetContainer(Stream container)
    {
      _container = container;
    }

    #endregion Internal Methods
  }
}