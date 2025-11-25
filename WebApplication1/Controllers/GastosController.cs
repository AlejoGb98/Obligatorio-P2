using Classes;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class GastosController : Controller
{
    Sistema system = Sistema.Instancia;
    
    // GET
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("Usuario") == null || HttpContext.Session.GetString("Usuario") == "Empleado") return Redirect("/Users/Login");
        return View();
    }

    public IActionResult AgregarGasto()
    {
        if (HttpContext.Session.GetString("Usuario") == null || HttpContext.Session.GetString("Usuario") == "Empleado") return Redirect("/Users/Login");
        return View();
    }

    [HttpPost]

    public IActionResult AgregarGasto(string nombre, string descripcion)
    {
        try
        {
            system.AgregarTipoGasto(nombre, descripcion);
            TempData["MensajeAgregado"] = $"El gasto {nombre} fue agregado con exito.";
            return Redirect("/Gastos/AgregarGasto");
        }
        catch (Exception e)
        {
            TempData["MensajeError"] = e.Message;
            return Redirect("/Gastos/AgregarGasto");
        }
    }

    public IActionResult EliminarGasto()
    {
        if (HttpContext.Session.GetString("Usuario") == null || HttpContext.Session.GetString("Usuario") == "Empleado") return Redirect("/Users/Login");
        ViewBag.Gastos = system.TiposDeGastos;
        return View();
    }

    [HttpPost]

    public IActionResult EliminarGasto(int indexTipoGasto)
    {
        try
        {
            system.EliminarTipoGasto(indexTipoGasto);
            TempData["MensajeEliminado"] = "El gasto fue eliminado.";
            return Redirect("/Gastos/EliminarGasto");
        }
        catch (Exception e)
        {
            ViewBag.Error = e.Message;
        }
        ViewBag.Gastos = system.TiposDeGastos;
        return View();
    }
}