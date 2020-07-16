using System.IO;

namespace Cyotek.Data.Wad
{
  public class WadFile
  {
    #region Private Fields

    private Stream _inputStream;

    private WadLumpCollection _lumps;

    private WadType _type;

    #endregion Private Fields

    #region Public Constructors

    public WadFile()
    {
      _type = WadType.Internal;
      _lumps = new WadLumpCollection(_inputStream);
    }

    #endregion Public Constructors

    #region Public Properties

    public Stream InputStream
    {
      get { return _inputStream; }
    }

    public WadLumpCollection Lumps
    {
      get { return _lumps; }
    }

    public WadType Type
    {
      get { return _type; }
      set { _type = value; }
    }

    #endregion Public Properties

    #region Public Methods

    public static WadFile LoadFrom(string fileName)
    {
      return WadFile.LoadFrom(File.OpenRead(fileName));
    }

    public static WadFile LoadFrom(Stream stream)
    {
      WadFile result;

      result = new WadFile();
      result.Load(stream);

      return result;
    }

    public WadLump Find(string name)
    {
      return this.Find(name, 0);
    }

    public WadLump Find(string name, int start)
    {
      WadLump result;

      result = null;

      for (int i = start; i < _lumps.Count; i++)
      {
        WadLump lump;

        lump = _lumps[i];

        if (string.Equals(lump.Name, name))
        {
          result = lump;
          break;
        }
      }

      return result;
    }

    public void Load(Stream stream)
    {
      using (WadReader reader = new WadReader(stream, true))
      {
        WadLump lump;

        _inputStream = stream;
        _lumps = new WadLumpCollection(stream);
        _type = reader.Type;

        while ((lump = reader.GetNextLump()) != null)
        {
          _lumps.Add(lump);
        }
      }
    }

    public void Load(string fileName)
    {
      this.Load(File.OpenRead(fileName));
    }

    #endregion Public Methods
  }
}