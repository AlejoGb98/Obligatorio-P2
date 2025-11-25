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

    public DateTime FechaDesde => _fechaDesde;

    public DateTime? FechaHasta => _fechaHasta;

    public bool Limite => _limite;

    public void ValidarPago()
    {
        ValidarFechasPago();
    }

    private void ValidarFechasPago()
    {
        /*if (_fechaHasta != null && _fechaHasta < DateTime.Today)
        {
            throw new Exception("La fecha de fin no puede ser antes de hoy.");
        }*/

        if (_fechaHasta == null && _limite)
        {
            throw new Exception("El pago con limite debe tener fecha de fin.");
        }
    }

    private int CalcularCuotasPendientes()
    {
        int cuotas = (_fechaHasta.Value.Year - DateTime.Today.Year) * 12 + _fechaHasta.Value.Month - DateTime.Today.Month;

        if (_fechaHasta.Value.Day >= _fechaDesde.Day) cuotas++;
        
        return cuotas;
    }

    public int CalcularCuotas()
    {
        return (_fechaHasta.Value.Year - _fechaDesde.Year) * 12 + (_fechaHasta.Value.Month - _fechaDesde.Month + 1);
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

    public override decimal CalcularPromocion()
    {
        decimal montoPago = MontoPago;
        if (!_limite)
        {
            montoPago *= 1.03m;
        }
        else if(_limite)
        {
            int cuotas = CalcularCuotas();
            if (cuotas >= 10)
            {
                montoPago *= 1.1m / cuotas;
            } else if (cuotas >= 6 && cuotas <= 9)
            {
                montoPago *= 1.05m / cuotas;
            }
        }
        return montoPago;
    }

    public override decimal CalcularMontoPago()
    {
        if (_limite)
        {
            return base.CalcularMontoPago() / CalcularCuotas();
        }
        return base.CalcularMontoPago();
    }

    public override string TipoPago()
    {
        return "Recurrente";
    }

    public override DateTime FechaDePago()
    {
        return _fechaDesde;
    }
}