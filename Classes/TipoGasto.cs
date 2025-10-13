namespace Classes;

public class TipoGasto
{
    private string _nombre;
    private string _descripcion;

    public string Nombre
    {
        get { return _nombre; }
    }

    public TipoGasto(string nombre, string descripcion)
    {
        _nombre = nombre;
        _descripcion = descripcion;
    }

    public override string ToString()
    {
        return $"Tipo de Gasto: {_nombre}";
    }

    public override bool Equals(object? obj)
    {
        return obj is TipoGasto tipoGasto && _nombre == tipoGasto._nombre;
    }
}