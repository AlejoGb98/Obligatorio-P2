using System.Runtime.InteropServices.JavaScript;

namespace Classes;

internal class PagoRecurrente : Pago
{
    private DateTime _fechaDesde;
    private DateTime? _fechaHasta; //puede ser DateTime o null
    private bool _limite; 

    public PagoRecurrente(MetodoPago metodoPago, TipoGasto tipoGasto, Usuario usuario, string descripcion, decimal montoPago, DateTime fechaDesde, DateTime? fechaHasta, bool limite)
        :base(metodoPago, tipoGasto, usuario, descripcion, montoPago)
    {
        _fechaDesde = fechaDesde;
        _fechaHasta = fechaHasta;
        _limite = limite;
    }

    public void ValidarPago()
    {
        ValidarFechasPago();
    }

    private void ValidarFechasPago()
    {
        if (_fechaHasta != null && _fechaHasta < DateTime.Today)
        {
            throw new Exception("La fecha de fin no puede ser antes de hoy.");
        }
    }

    private int CalcularCuotasPendientes()
    {
        int cuotas = (_fechaHasta.Value.Year - DateTime.Today.Year) * 12 + _fechaHasta.Value.Month - DateTime.Today.Month;

        if (_fechaHasta.Value.Day >= _fechaDesde.Day) cuotas++;
        
        return cuotas;
    }

    public override string ToString()
    {
        string aux = $"Fecha Final: {_fechaHasta?.ToString("dd/MM/yyyy")} \n";
        if (_fechaHasta != null)
        {
            if (_fechaHasta > DateTime.Today)
            {
                aux += $"Cuotas Pendientes: {CalcularCuotasPendientes()}";
            }
            else
            {
                aux += $"El pago ha sido completado.";
            }
        }
        
        return $"{base.ToString()}" +
               $"Fecha Incial: {_fechaDesde.ToString("dd/MM/yyyy")}\n" +
               (_fechaHasta != null ? aux : "");
    }

    /*private decimal CalcularMontoAPagar(decimal montoPago)
    {
        if (_limite)
        {
            if (_cuotasPendientes >= 10)
            {
                return montoPago * 1.1m;
            } else if (_cuotasPendientes >= 6)
            {
                return montoPago * 1.05m;
            }
        }
        return montoPago * 1.03m;

    }*/
}