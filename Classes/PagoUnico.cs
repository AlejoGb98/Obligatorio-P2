namespace Classes;

internal class PagoUnico : Pago
{
    private DateTime _fechaPago;
    private int _nroRecibo;
 
    public PagoUnico
        (MetodoPago metodoPago, TipoGasto tipoGasto, Usuario usuario, string descripcion, decimal montoPago, DateTime fechaPago, int nroRecibo)
        :base(metodoPago, tipoGasto, usuario, descripcion, montoPago)
    {
        _fechaPago = fechaPago;
        _nroRecibo = nroRecibo;
    }

    public void ValidarPago()
    {
        ValidarFecha();
    }

    private void ValidarFecha()
    {
        if (_fechaPago > DateTime.Now) throw new Exception("La fecha no puede ser mayor a hoy.");
    }

    public override string ToString()
    {
        return $"{base.ToString()}Fecha de Pago: {_fechaPago.ToString("dd/MM/yyyy")} \nNumero de Recibo: {_nroRecibo}";
    }

    //VA EN EL METODO ABSTRACTO
    /*private decimal CalcularMontoAPagar(decimal montoPago)
    {
        decimal monto = montoPago;
        decimal montoFinal = montoPago * 0.9m;
        if (MetodoPago == MetodoPago.Efectivo)
        {
            montoFinal = monto * 0.8m;
        }

        return montoFinal;
    }*/
}