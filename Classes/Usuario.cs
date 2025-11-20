using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Classes;

public class Usuario
{
    private string _nombre;
    private string _apellido;
    private string _contrasena;
    private string _email;
    private Equipo _equipo;
    private DateTime _fechaIngreso;
    private string _rol;

    public Usuario(string nombre, string apellido, string contrasena, string email, Equipo equipo, DateTime fechaIngreso, string rol )
    {
        _nombre = nombre;
        _apellido = apellido;
        _contrasena = contrasena;
        _email = email;
        _equipo = equipo;
        _fechaIngreso = fechaIngreso;
        _rol = rol;
    }

    public string Email { get => _email; }
    public string Nombre { get => _nombre; }
    public string Apellido => _apellido;
    public string Contrasena { get => _contrasena; }
    public DateTime FechaIngreso => _fechaIngreso;

    public Equipo Equipo => _equipo;

    public string Rol { get => _rol; }

    public override string ToString()
    {
        return $"Nombre: {_nombre} {_apellido}, Email: {_email}, Grupo: {_equipo} ";
    }

    public override bool Equals(object? obj)
    {
        return obj is Usuario user && _email == user._email;
    }

    public void Validar()
    {
        ValidarNombre();
        ValidarApellido();
        ValidarContrasena();
        ValidarFechaIngreso();
    }

    private void ValidarNombre()
    {
        if (_nombre.Length == 0) throw new Exception("El nombre no puede ser vacio.");
    }
    
    private void ValidarApellido()
    {
        if (_apellido.Length == 0) throw new Exception("El apellido no puede ser vacio.");
    }

    private void ValidarContrasena()
    {
        if (_contrasena.Length <= 7) throw new Exception("La contraseña debe tener un minimo de 8 caracteres.");
    }

    private void ValidarFechaIngreso()
    {
        if (_fechaIngreso > DateTime.Today) throw new Exception("La fecha de ingreso no puede ser en el futuro.");
    }

    public bool MailEsIgual(string email)
    {
        if (email == _email) return true;
        return false;
    }

    public bool PerteneceAlEquipo(int idEquipo)
    {
        return idEquipo == _equipo.Id;
    }
    
}