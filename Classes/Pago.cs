namespace Classes;

public enum MetodoPago {Credito, Debito, Efectivo}
public abstract class Pago
{
    private int _id;
    private static int _ultimoId = 0;
    private TipoGasto _tipoGasto;
    private MetodoPago _metodoPago;
    private Usuario _usuario;
    private string _descripcion;
    private decimal _montoPago;
    

    public Usuario Usuario
    {
        get { return _usuario; }
    }

    public MetodoPago MetodoPago
    {
        get { return _metodoPago; }
    }

    public Pago(MetodoPago metodoPago, TipoGasto tipoGasto, Usuario usuario, string descripcion, decimal montoPago)
    {
        _id = ++_ultimoId;
        _tipoGasto = tipoGasto;
        _metodoPago = metodoPago;
        _usuario = usuario;
        _descripcion = descripcion;
        _montoPago = montoPago;
    }

    public override bool Equals(object? obj)
    {
        return obj is Pago pago && _usuario == pago._usuario;
    }

    public override string ToString()
    {
        return $"Metodo de Pago: {_metodoPago} \nTipo de Gasto: {_tipoGasto.Nombre} \nDescripcion: {_descripcion} \nPago Total: ${_montoPago} \n";
    }

    
}