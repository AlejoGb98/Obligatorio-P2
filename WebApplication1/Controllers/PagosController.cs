using System.Net;
using Classes;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class PagosController : Controller
{
    Sistema system = Sistema.Instancia;
    // GET
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("Usuario") == null) return Redirect("/Users/Login");
        return View();
    }

    public IActionResult VerPagosUsuario()
    {
        if (HttpContext.Session.GetString("Usuario") == null) return Redirect("/Users/Login");
        string email = HttpContext.Session.GetString("Usuario");
        List<Pago> pagosPorUsuario = system.ObtenerPagosPorPersona(email);
        ViewBag.Pagos = pagosPorUsuario;
        return View();
    }
    
    public IActionResult VerTodosLosPagos()
    {
        if (HttpContext.Session.GetString("Usuario") == null) return Redirect("/Users/Login");
        int idEquipo = int.Parse(HttpContext.Session.GetString("Equipo"));

        ViewBag.Pagos = system.ObtenerPagosPorEquipo(idEquipo);
        
        return View(); 
    }
    [HttpPost]
    public IActionResult VerTodosLosPagos(int mesPago, int anoPago)
    {
        if (HttpContext.Session.GetString("Usuario") == null) return Redirect("/Users/Login");
        int idEquipo = int.Parse(HttpContext.Session.GetString("Equipo"));
        
        ViewBag.Pagos = system.ObtenerPagosPorEquipoFecha(idEquipo, mesPago, anoPago);
        
        return View();
    }
    
    //AGREGAR PAGOS
    public IActionResult AgregarPagoUnico()
    {
        if (HttpContext.Session.GetString("Usuario") == null) return Redirect("/Users/Login");
        ViewBag.TiposDeGasto = system.TiposDeGastos;

        return View();
    }    
    
    [HttpPost]
    public IActionResult AgregarPagoUnico(MetodoPago metodoPago, string tipoGasto, string descr, DateTime fecha, decimal montoPago, int nroRecibo)
    {
            string? usuario = HttpContext.Session.GetString("Usuario");
            try
            {
                system.AgregarPagoUnico(metodoPago, tipoGasto, usuario, descr, fecha, montoPago, nroRecibo);
                return Redirect("/Pagos/VerPagosUsuario");
            }
            catch (Exception e)
            {
                TempData["MensajeError"] = e.Message;
            }

            return Redirect("/Pagos/AgregarPagoUnico");
    }
    
    public IActionResult AgregarPagoRecurrente()
    {
        if (HttpContext.Session.GetString("Usuario") == null) return Redirect("/Users/Login");
        ViewBag.TiposDeGasto = system.TiposDeGastos;
        return View();
    }    
    
    [HttpPost]
    public IActionResult AgregarPagoRecurrente(string tipoGasto, string descr, decimal montoPago, DateTime fechaDesde, DateTime? fechaHasta, bool limite )
    {
        if (!limite) fechaHasta = null;
        MetodoPago metodoPago = MetodoPago.Credito;
        string? usuario = HttpContext.Session.GetString("Usuario");

        try
        {
            system.AgregarPagoRecurrente(metodoPago, tipoGasto, usuario, descr, montoPago, fechaDesde, fechaHasta, limite);
            return Redirect("/Pagos/VerPagosUsuario");
        }
        catch (Exception e)
        {
            TempData["MensajeError"] = e.Message;
        }

        return Redirect("/Pagos/AgregarPagoRecurrente");
    }
    
    
 
}