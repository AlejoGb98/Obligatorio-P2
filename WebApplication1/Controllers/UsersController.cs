using System.Net;
using Classes;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

public class UsersController : Controller
{
    Sistema system = Sistema.Instancia;
    
    // GET
    public IActionResult Index()
    {
        if (HttpContext.Session.GetString("Usuario") == null) return Redirect("/Users/Login");
        return View();
    }
    
    //LOGIN Y SESION
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]

    public IActionResult Login(string user, string pass)
    {
        Usuario? usuarioEsValido = system.UsuarioValido(user, pass);

        if (usuarioEsValido != null)
        {
           HttpContext.Session.SetString("Usuario", usuarioEsValido.Email);
           HttpContext.Session.SetString("Rol", usuarioEsValido.Rol);
           HttpContext.Session.SetString("Equipo", usuarioEsValido.Equipo.Id.ToString());
           ViewBag.Mensaje = "Logueado con exito";
           ViewBag.Rol = usuarioEsValido.Rol;
           return RedirectToAction("Index");
        }
        else
        {
            ViewBag.Mensaje = "Los datos ingresados no son correctos. Por favor, reintentar";
            return View();
        }
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return Redirect("/users/login");
    }
    
    //PERFIL
    public IActionResult VerPerfil()
    {
        if (HttpContext.Session.GetString("Usuario") == null) return Redirect("/Users/Login");
        string? email = HttpContext.Session.GetString("Usuario");
        Usuario user = system.DevolverUsuario(email);

        decimal gastoMesCorriente = system.ObtenerGastoMesCorriente(email);

        ViewBag.Usuario = user;
        ViewBag.Gasto = gastoMesCorriente;
        
        return View();
    }
    
}