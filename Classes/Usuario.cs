using System.ComponentModel.DataAnnotations;

namespace Classes;

public class Usuario
{
    private string _nombre;
    private string _apellido;
    private string _contrasena;
    private string _email;
    private Equipo _equipo;
    private DateTime _fechaIngreso;

    public Usuario(string nombre, string apellido, string contrasena, string email, Equipo equipo, DateTime fechaIngreso )
    {
        _nombre = nombre;
        _apellido = apellido;
        _contrasena = contrasena;
        _email = email;
        _equipo = equipo;
        _fechaIngreso = fechaIngreso;
    }

    public string Email { get => _email; }
    public string Nombre { get => _nombre; }

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
        ValidarUsuario();
        ValidarContrasena();
        ValidarFechaIngreso();
    }

    private void ValidarUsuario()
    {
        if (_nombre.Length == 0) throw new Exception("El nombre no puede ser vacio.");
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
        if (email == _email.Substring(0, 6)) return true;
        return false;
    }

    public bool PerteneceAlEquipo(int idEquipo)
    {
        return idEquipo == _equipo.Id;
    }
    
}