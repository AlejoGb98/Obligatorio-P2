using System.Runtime.InteropServices.JavaScript;

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

    public DateTime FechaPago => _fechaPago;

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

    public override decimal CalcularPromocion()
    {
        decimal montoConPromocion = MontoPago;

        if (MetodoPago == MetodoPago.Efectivo)
        {
            montoConPromocion *= .8m;
        }
        else
        {
            montoConPromocion *= .9m;
        }

        return montoConPromocion;
    }

    public override decimal CalcularMontoPago()
    {
        return base.CalcularMontoPago();
    }
}