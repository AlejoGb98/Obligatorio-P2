namespace Classes;

public class Equipo
{
    private int _id;
    private static int _lastId = 0;
    private string _nombreEquipo;

    public int Id
    {
        get { return _id; }
    }

    public Equipo(string nombreEquipo)
    {
        _id = ++_lastId;
        _nombreEquipo = nombreEquipo;
    }

    public override bool Equals(object? obj)
    {
        return obj is Equipo equipo && _id == equipo._id ;
    }

    public override string ToString()
    {
        return $"{_nombreEquipo}";
    }
}