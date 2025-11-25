namespace Classes;

public enum MetodoPago {Credito, Debito, Efectivo}
public abstract class Pago : IComparable<Pago>
{
    private int _id;
    private static int _ultimoId = 0;
    private TipoGasto _tipoGasto;
    private MetodoPago _metodoPago;
    private Usuario _usuario;
    private string _descripcion;
    private decimal _montoPago;
    

    public Usuario Usuario => _usuario;
    public MetodoPago MetodoPago => _metodoPago; 
    public string Descripcion => _descripcion;
    public decimal MontoPago => _montoPago;
    public TipoGasto TipoGasto => _tipoGasto;

    public Pago(MetodoPago metodoPago, TipoGasto tipoGasto, Usuario usuario, string descripcion, decimal montoPago)
    {
        _id = ++_ultimoId;
        _tipoGasto = tipoGasto;
        _metodoPago = metodoPago;
        _usuario = usuario;
        _descripcion = descripcion;
        _montoPago = montoPago;
    }

    public int CompareTo(Pago otroPago)
    {
        return -_montoPago.CompareTo(otroPago._montoPago) ;
    }

    public override bool Equals(object? obj)
    {
        return obj is Pago pago && _usuario == pago._usuario;
    }

    public abstract decimal CalcularPromocion();

    public virtual decimal CalcularMontoPago()
    {
        return _montoPago;
    }

    public abstract string TipoPago();

    public abstract DateTime FechaDePago();
    public override string ToString()
    {
        return $"Metodo de Pago: {_metodoPago} \nTipo de Gasto: {_tipoGasto.Nombre} \nDescripcion: {_descripcion} \nPago Total: ${_montoPago} \n";
    }

    
}