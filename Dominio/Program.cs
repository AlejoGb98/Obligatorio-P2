using Classes;
namespace Dominio;

class Program
{
    private static Sistema system;
    
    static void Main(string[] args)
    {
        system = Sistema.Instancia;
        
        int opcion = 0;
                    // menu
                    string[] opc = { "Listar Usuarios", "Listado de Pagos por Usuario", "Alta de Usuario", "Listado de Integrantes por Equipo"};
                    // solicita numeros hasta que se ponga 0
                    do
                    {
                        Menu(opc);
                        opcion = Utils.PedirNumero("Opcion");
                        switch (opcion)
                        {
                            case 1:
                                ListarUsuarios();
                                break;
                            case 2:
                                ListarPagosPorUsuario();
                                break;
                            case 3:
                                AgregarUsuario();
                                break;
                            case 4:
                                MostrarUsuariosPorEquipos();
                                break;
                        }
                        if (opcion != 0)
                        {
                            Console.Write("Cualquier tecla para seguir...");
                            Console.ReadKey();
                        }
        
                    } while (opcion != 0);
    }
    static public void Menu(string[] opciones)
    {
        Console.Clear();
        int numero = 1;
        Console.WriteLine("Ingresa una de las siguientes opciones (0 para finalizar)");
        foreach (string opcion in opciones)
        {
            Console.WriteLine(numero + " - " + opcion);
            numero++;
        }
    }
    static public void ListarUsuarios()
    {
        List<Usuario> listaUsuarios = system.ListarUsuarios();

        if (listaUsuarios.Count == 0) throw new Exception("No hay usuarios registados.");

        try
        {
            foreach (Usuario user in listaUsuarios)
            {
                Console.WriteLine(user);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static public void AgregarUsuario()
    {
        Console.WriteLine("Alta de Usuario");
        Console.WriteLine();
        
        string nombre = Utils.PedirLetras("Nombre");
        string apellido = Utils.PedirLetras("Apellido");
        string contrasena = Utils.PedirLetras("Contraseña");
        int equipo = Utils.LeerEquipo(system.Equipos);
        DateTime fechaIngreso = Utils.PedirFecha("Fecha de Ingreso");
        
        if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(contrasena)) throw new Exception("Todos los campos son obligatorios.");

        try
        {
            system.AgregarUsuario(nombre, apellido, contrasena, equipo, fechaIngreso);
            Console.WriteLine("Usuario agregado exitosamente.");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static public void ListarPagosPorUsuario()
    {
        Console.Write("Usuario: ");
        string usuario = Console.ReadLine();

        List<Pago> pagos = system.ObtenerPagosPorPersona(usuario);

        if (pagos.Count > 0)
        {
            foreach (Pago pago in pagos)
            {
                Console.Write("------------------------------\n");
                Console.WriteLine(pago);
            }
        }
        else
        {
            Console.WriteLine("El usuario no tiene pagos registrados.");
        }
        
    }

    static public void MostrarUsuariosPorEquipos()
    {
        int idEquipo = Utils.LeerEquipo(system.Equipos);
        List<Usuario> usuarios = system.ObtenerUsuariosPorEquipo(idEquipo);
        int i = 1;
        if (usuarios.Count > 0)
        {
            Console.WriteLine("        EMAIL    |    NOMBRE");
            foreach (Usuario user in usuarios)
            {
                Console.WriteLine($"{i} {user.Email}   {user.Nombre}");
                i++;
            }
        }
    }
}
