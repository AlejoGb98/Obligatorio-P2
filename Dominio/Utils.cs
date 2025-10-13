using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Classes;

namespace Dominio
{
    static class Utils
    {
        static public void Titulo(string titulo)
        {
            Console.Write($"{titulo}: ");
        }


        static public DateTime PedirFecha(string mensaje = "Ingrese fecha.")
        {
            DateTime fechaADevolver;
            bool exito;
            do
            {
                Titulo(mensaje);
                exito = DateTime.TryParse(Console.ReadLine(), out fechaADevolver);
                if (!exito)
                {
                    MensajeError("Debe escribir una fecha correcta.");
                }
            } while (!exito);

            return fechaADevolver;
        }
        
        static public int PedirNumero(string mensaje = "Ingrese número.")
        {
            int numero;
            bool exito;
            do
            {
                Titulo(mensaje);
                exito = int.TryParse(Console.ReadLine(), out numero);
                if (!exito)
                {
                    MensajeError("Debe escribir solo numeros.");
                }
            } while (!exito);

            return numero;
        }

        static public decimal PedirImporte(string mensaje = "Ingrese importe.")
        {
            decimal importe;
            bool exito;
            do
            {
                Titulo(mensaje);
                exito = decimal.TryParse(Console.ReadLine(), out importe);
                if (!exito)
                {
                    MensajeError("Debe escribir solo numeros.");
                }
            } while (!exito);

            return importe;
        }

        static public string PedirLetras(string mensaje = "Ingrese el nombre.")
        {
            Titulo(mensaje);
            string texto = Console.ReadLine();
            return texto;
        }
        
        static public void MensajeError(string mensaje)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine($"---Error----> {mensaje}");
            Console.BackgroundColor = ConsoleColor.Black;
        }

        public static int LeerEquipo(List<Equipo> equipos)
        {
            
            int idEquipo;
            bool exito = false;
            string? valorAParsear;
            
            do
            {
                Console.WriteLine("Equipo:");
                int i = 1;
                foreach (Equipo eq in equipos)
                {
                    Console.WriteLine($"{i} - {eq}");
                    i++;
                }
                valorAParsear = Console.ReadLine();
                
                bool esNumero = int.TryParse(valorAParsear, out int tipoEntero);
                idEquipo = tipoEntero;
                if (esNumero && tipoEntero <= equipos.Count() && tipoEntero > 0)
                {
                    exito = true;
                }
            }
            while (!exito);
            return idEquipo;
        }
    }
}
