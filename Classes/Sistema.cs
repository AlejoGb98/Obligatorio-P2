using System.Runtime.InteropServices.JavaScript;

namespace Classes;

public class Sistema
{
    private List<Usuario> _usuarios = new List<Usuario>();
    private List<Pago> _pagos = new List<Pago>();
    private List<Equipo> _equipos = new List<Equipo>();
    private List<TipoGasto> _tiposDeGastos = new List<TipoGasto>();

    public List<Equipo> Equipos
    {
        get { return _equipos; }
    }

    public List<TipoGasto> TiposDeGastos => _tiposDeGastos;

    //SINGLETON PASO 2: Me creo un atributo privado y estatico de tipo Sistema llamado "instancia"
    private static Sistema _instancia;

    //SINGLETON PASO 1: Hago privado el constructor
    private Sistema()
    {
        PrecargaDatos();
    }

    //PASO 3: Creo una propery para retornar la instancia, verificando que si aun no se creó una instancia, la tengo que crear
    public static Sistema Instancia
    {
        get
        {
            if (_instancia == null) _instancia = new Sistema();
            return _instancia;
        }
    }

    private void PrecargaDatos()
    {
        AgregarEquipo("Recursos Humanos");
        AgregarEquipo("Administracion");
        AgregarEquipo("Contable");
        AgregarEquipo("Sistemas");

        AgregarTipoGasto("Alquiler", "Pago mensual de vivienda.");
        AgregarTipoGasto("Comida", "Super, feria, salidas.");
        AgregarTipoGasto("Transporte", "Boletos de bus, Nafta, Patente.");
        AgregarTipoGasto("Servicios", "Facturas del hogar.");
        AgregarTipoGasto("Entretenimiento", "Gastos de ocio, salidas, suscripciones.");
        AgregarTipoGasto("Educacion", "Cursos, Facultad, Lenguas.");

        AgregarUsuario("Martin", "Gonzalez", "12312312", 3, new DateTime(23, 11, 09),"Empleado");
        AgregarUsuario("Laura", "Fernandez", "45645612", 2, new DateTime(22, 05, 15),"Empleado");
        AgregarUsuario("Santiago", "Perez", "78978912", 4, new DateTime(24, 01, 20),"Empleado");
        AgregarUsuario("Valeria", "Rodriguez", "32132112", 2, new DateTime(21, 07, 03),"Empleado");
        AgregarUsuario("Diego", "Lopez", "65465412", 3, new DateTime(25, 03, 12),"Empleado");
        AgregarUsuario("Marcos", "Gonzalez", "11122233", 1, new DateTime(24, 02, 10),"Empleado"); 
        AgregarUsuario("Martina", "Gonzalez", "22233344", 2, new DateTime(24, 04, 21),"Empleado"); 
        AgregarUsuario("Mariano", "Gonzalez", "33344455", 4, new DateTime(23, 12, 01),"Empleado"); 
        AgregarUsuario("Laura", "Ferman", "44455566", 1, new DateTime(23, 09, 30),"Empleado"); 
        AgregarUsuario("Laura", "Fernandez", "44455567", 2, new DateTime(25, 01, 05),"Empleado"); 
        AgregarUsuario("Santiago", "Perez", "55566677", 2, new DateTime(22, 11, 11),"Empleado"); 
        AgregarUsuario("Santiago", "Peres", "55566678", 1, new DateTime(24, 06, 18),"Empleado"); 
        AgregarUsuario("Valentino", "Rodriguez", "66677788", 3, new DateTime(24, 08, 09),"Empleado"); 
        AgregarUsuario("Valeria", "Rodriguez", "66677789", 1, new DateTime(23, 03, 27),"Empleado"); 
        AgregarUsuario("Diego", "Lopez", "77788899", 4, new DateTime(24, 05, 02),"Empleado"); 
        AgregarUsuario("Diego", "Lopez", "65426412", 3, new DateTime(25, 03, 12),"Empleado"); 
        AgregarUsuario("Ana", "Gomez", "88899900", 1, new DateTime(23, 07, 14),"Empleado"); 
        AgregarUsuario("Andres", "Gomez", "99900011", 2, new DateTime(25, 02, 28),"Empleado"); 
        AgregarUsuario("Florencia", "Martinez", "10101010", 2, new DateTime(24, 10, 07),"Empleado"); 
        AgregarUsuario("Federico", "Martinez", "12121212", 1, new DateTime(23, 05, 19),"Empleado"); 
        AgregarUsuario("Camila", "Santos", "13131313", 3, new DateTime(22, 12, 25),"Empleado");
        AgregarUsuario("Marcelo", "Aguirre", "123123123", 1, new DateTime(09, 12, 25),"Gerente");


        // ---------------------------
        // 19 Pagos Únicos (solo Debito | Efectivo)
        // --------------------------- 
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "margon@ribuk.com", "Pago Alquiler — Piso A", new DateTime(2025, 11, 07), 20000, 500);
        AgregarPagoUnico(MetodoPago.Efectivo, "Comida", "laufer@ribuk.com", "Compra supermercado - quincena", new DateTime(2025, 08, 28), 8400, 120);
        AgregarPagoUnico(MetodoPago.Debito, "Transporte", "sanper@ribuk.com", "Mudanza local", new DateTime(2025, 07, 10), 7200, 300);
        AgregarPagoUnico(MetodoPago.Efectivo, "Servicios", "valrod@ribuk.com", "Pago agua - factura extra", new DateTime(2025, 09, 22), 1600, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "dielop1@ribuk.com", "Concierto - entrada VIP", new DateTime(2025, 06, 21), 12000, 250);
        AgregarPagoUnico(MetodoPago.Efectivo, "Comida", "dielop@ribuk.com", "Catering evento", new DateTime(2025, 11, 04), 9800, 400);
        AgregarPagoUnico(MetodoPago.Debito, "Transporte", "margon1@ribuk.com", "Cuota del auto", new DateTime(2025, 11, 07), 20000, 500);
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "margon1@ribuk.com", "Pago Alquiler — Piso A", new DateTime(2025, 11, 06), 50000, 500);
        AgregarPagoUnico(MetodoPago.Efectivo, "Comida", "margon2@ribuk.com", "Compra supermercado - emergencia", new DateTime(2025, 03, 12), 5600, 70);
        AgregarPagoUnico(MetodoPago.Debito, "Transporte", "laufer1@ribuk.com", "Servicio taxi - traslado especial", new DateTime(2025, 04, 18), 2100, 0);
        AgregarPagoUnico(MetodoPago.Efectivo, "Servicios", "laufer2@ribuk.com", "Reparación eléctrica - urgencia", new DateTime(2025, 02, 27), 4300, 50);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "sanper1@ribuk.com", "Entrada festival música", new DateTime(2025, 09, 05), 5200, 150);
        AgregarPagoUnico(MetodoPago.Efectivo, "Comida", "valrod1@ribuk.com", "Cena empresarial", new DateTime(2025, 11, 02), 11000, 200);
        AgregarPagoUnico(MetodoPago.Debito, "Servicios", "dielop@ribuk.com", "Servicio técnico electrodoméstico", new DateTime(2025, 01, 15), 2600, 20);
        AgregarPagoUnico(MetodoPago.Efectivo, "Entretenimiento", "margon3@ribuk.com", "Clase de pintura - sesión única", new DateTime(2025, 06, 05), 1400, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Comida", "anagom@ribuk.com", "Almuerzo corporativo especial", new DateTime(2025, 11, 07), 4700, 60);
        AgregarPagoUnico(MetodoPago.Debito, "Servicios", "anagom@ribuk.com", "Servicio celular", new DateTime(2025, 11, 07), 6000, 70);
        AgregarPagoUnico(MetodoPago.Efectivo, "Transporte", "andgom@ribuk.com", "Traslado aeropuerto", new DateTime(2025, 05, 30), 3200, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "valrod2@ribuk.com", "Pago Alquiler — Bodega", new DateTime(2025, 09, 15), 13000, 400);
        AgregarPagoUnico(MetodoPago.Efectivo, "Servicios", "flomar@ribuk.com", "Pago jardinería - corte anual", new DateTime(2025, 03, 09), 2700, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "fedmar@ribuk.com", "Taller gastronómico - plaza", new DateTime(2025, 04, 11), 2300, 30);
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "margon1@ribuk.com", "Pago alquiler — Piso 1A", new DateTime(2025, 01, 03), 18000, 500);
        AgregarPagoUnico(MetodoPago.Debito, "Comida", "laufer@ribuk.com", "Supermercado — compra semanal", new DateTime(2025, 01, 06), 3200, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Transporte", "sanper@ribuk.com", "Recarga transporte — mes", new DateTime(2025, 01, 08), 900, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Servicios", "valrod@ribuk.com", "Pago UTE — factura", new DateTime(2025, 01, 10), 2400, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "dielop@ribuk.com", "Entrada concierto — VIP", new DateTime(2025, 01, 12), 4800, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Educacion", "margon@ribuk.com", "Libro técnico — compra", new DateTime(2025, 01, 15), 1900, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "laufer@ribuk.com", "Pago alquiler — Anexo 2B", new DateTime(2025, 02, 01), 19500, 500);
        AgregarPagoUnico(MetodoPago.Debito, "Comida", "sanper@ribuk.com", "Cena restaurante — evento", new DateTime(2025, 02, 03), 4200, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Transporte", "valrod@ribuk.com", "Taxi — traslado urgente", new DateTime(2025, 02, 05), 1200, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Servicios", "dielop@ribuk.com", "Pago agua — factura", new DateTime(2025, 02, 07), 1100, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "margon1@ribuk.com", "Suscripción videojuego — compra única", new DateTime(2025, 02, 11), 3200, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Educacion", "laufer@ribuk.com", "Inscripción taller presencial", new DateTime(2025, 02, 14), 2500, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "sanper@ribuk.com", "Pago alquiler — Piso C", new DateTime(2025, 03, 01), 18200, 500);
        AgregarPagoUnico(MetodoPago.Debito, "Comida", "valrod@ribuk.com", "Compra mercado — mensual", new DateTime(2025, 03, 04), 3500, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Transporte", "dielop@ribuk.com", "Peaje ruta interdepartamental", new DateTime(2025, 03, 06), 450, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Servicios", "margon1@ribuk.com", "Internet — pago anual (único)", new DateTime(2025, 03, 09), 12000, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "laufer@ribuk.com", "Cine — función especial", new DateTime(2025, 03, 10), 700, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Educacion", "sanper@ribuk.com", "Material escolar — compra", new DateTime(2025, 03, 15), 1600, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "valrod@ribuk.com", "Pago alquiler — Local Comercial", new DateTime(2025, 04, 01), 20000, 500);
        AgregarPagoUnico(MetodoPago.Debito, "Comida", "dielop@ribuk.com", "Mercado orgánico — compra mensual", new DateTime(2025, 04, 03), 2800, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Transporte", "margon1@ribuk.com", "Reparación bici — taller", new DateTime(2025, 04, 06), 950, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Servicios", "laufer@ribuk.com", "Carga de gas — botella", new DateTime(2025, 04, 07), 1300, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "sanper2@ribuk.com", "Compra vinilos — edición limitada", new DateTime(2025, 04, 11), 2200, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Educacion", "valrod@ribuk.com", "Curso online — pago único", new DateTime(2025, 04, 12), 4800, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "dielop@ribuk.com", "Pago alquiler — Departamento E", new DateTime(2025, 05, 01), 18500, 500);
        AgregarPagoUnico(MetodoPago.Debito, "Comida", "margon@ribuk.com", "Delivery — cena por aniversario", new DateTime(2025, 05, 04), 1500, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Transporte", "laufer@ribuk.com", "Repuesto coche — compra única", new DateTime(2025, 05, 06), 5600, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Servicios", "sanper@ribuk.com", "Mantenimiento eléctrico puntual", new DateTime(2025, 05, 08), 2100, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "valrod@ribuk.com", "Juego digital — compra", new DateTime(2025, 05, 10), 3200, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Educacion", "dielop@ribuk.com", "Pago examen de certificación — única", new DateTime(2025, 05, 14), 7000, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "margon@ribuk.com", "Pago alquiler — Piso F", new DateTime(2025, 06, 01), 18800, 500);
        AgregarPagoUnico(MetodoPago.Debito, "Comida", "laufer@ribuk.com", "Supermercado — compra temporal", new DateTime(2025, 06, 03), 3400, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Transporte", "sanper2@ribuk.com", "Uber — traslado evento", new DateTime(2025, 06, 06), 1100, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Servicios", "valrod@ribuk.com", "Limpieza hogar — servicio puntual", new DateTime(2025, 06, 08), 2500, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "dielop@ribuk.com", "Clases guitarra — sesión única", new DateTime(2025, 06, 10), 1200, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Educacion", "margon1@ribuk.com", "Compra cuadernos y material", new DateTime(2025, 06, 13), 600, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "laufer2@ribuk.com", "Pago alquiler — Local G", new DateTime(2025, 07, 01), 20300, 500);
        AgregarPagoUnico(MetodoPago.Debito, "Comida", "sanper2@ribuk.com", "Cena familiar — pago único", new DateTime(2025, 07, 04), 2700, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Transporte", "valrod2@ribuk.com", "Servicio remis — ida y vuelta", new DateTime(2025, 07, 06), 1600, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Servicios", "dielop1@ribuk.com", "Reparación termoeléctrico — único", new DateTime(2025, 07, 08), 4300, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "margon@ribuk.com", "Festival — entrada VIP", new DateTime(2025, 07, 10), 9500, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Educacion", "laufer1@ribuk.com", "Material digital — curso puntual", new DateTime(2025, 07, 15), 2200, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "sanper1@ribuk.com", "Pago alquiler — Piso H", new DateTime(2025, 08, 01), 18750, 500);
        AgregarPagoUnico(MetodoPago.Debito, "Comida", "valrod@ribuk.com", "Super — compra agosto", new DateTime(2025, 08, 03), 3600, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Transporte", "dielop1@ribuk.com", "Revisión coche — taller", new DateTime(2025, 08, 06), 7200, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Servicios", "margon@ribuk.com", "Pago agua extraordinaria — reparación", new DateTime(2025, 08, 08), 900, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "laufer2@ribuk.com", "Teatro — entrada única", new DateTime(2025, 08, 10), 1800, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Educacion", "sanper@ribuk.com", "Taller presencial — pago único", new DateTime(2025, 08, 15), 3000, 0);
        

        // ---------------------------
        // 25 Pagos Recurrentes (todos Credito) — incluyen monto y bool (activo)
        // Al menos 3 de estos tienen fecha de fin anterior al 23/09/2025 (marcados abajo).
        // ---------------------------
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "margon@ribuk.com", "Internet hogar - plan anual",
        12000, new DateTime(2025, 01, 01), new DateTime(2025, 12, 31), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "laufer@ribuk.com", "Streaming música - plan familiar", 
            260, new DateTime(2024, 01, 01), null, false); 

        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "sanper@ribuk.com", "Suscripción comidas - oficina",
            9000, new DateTime(2025, 03, 01), new DateTime(2025, 12, 30), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "valrod@ribuk.com", "Tarjeta transporte - mensual",
            2000, new DateTime(2025, 02, 01), new DateTime(2025, 08, 15), true); // FIN EN PASADO (mantenido si querés simular histórico)

        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "dielop2@ribuk.com", "Alquiler local - contrato anual",
           35000, new DateTime(2025, 10, 01), new DateTime(2026, 04, 30), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "dielop@ribuk.com", "Gas domiciliario - plan",
            2500, new DateTime(2025, 01, 15), null, false);

        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "margon1@ribuk.com", "Viandas semanales - empleado",
          2500, new DateTime(2025, 04, 01), new DateTime(2025, 10, 01), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "laufer1@ribuk.com", "Servidor cloud - plan mensual",
           690, new DateTime(2025, 02, 01), new DateTime(2025, 11, 30), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "sanper1@ribuk.com", "Suscripción videojuegos - mensual",
          690, new DateTime(2025, 06, 01), null, false);

        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "valrod1@ribuk.com", "Mantenimiento flota - mensual", 15000 , new DateTime(2025, 03, 01), new DateTime(2025, 12, 01), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "dielop@ribuk.com", "Alquiler bodega - contrato 6 meses", 60000, new DateTime(2025, 01, 01), new DateTime(2025, 06, 30), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "margon2@ribuk.com", "Mantenimiento web - plan anual", 490, new DateTime(2025, 04, 01), new DateTime(2026, 03, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "dielop1@ribuk.com", "Catering mensual - eventos", 12000, new DateTime(2025, 05, 01), new DateTime(2025, 11, 30), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "flomar@ribuk.com", "Cineclub - suscripción", 990, new DateTime(2025, 02, 01), null, false); 
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "fedmar@ribuk.com", "Backup mensual - empresa", 690, new DateTime(2025, 01, 01), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "camsan@ribuk.com", "Plan viandas - suscripción", 4500, new DateTime(2025, 03, 15), new DateTime(2025, 09, 15), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "margon3@ribuk.com", "Servicio logística - mensual", 4600, new DateTime(2025, 06, 01), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "valrod2@ribuk.com", "Alquiler oficina - plan anual", 15000 , new DateTime(2025, 07, 01), new DateTime(2026, 06, 30), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "dielop2@ribuk.com", "Mantenimiento ascensor - contrato", 5600, new DateTime(2025, 08, 01), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "margon3@ribuk.com", "Suscripción revista digital", 690, new DateTime(2025, 09, 01), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "laufer2@ribuk.com", "Limpieza oficinas - plan mensual", 7000, new DateTime(2025, 01, 10), new DateTime(2025, 12, 10), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "sanper1@ribuk.com", "Desayunos corporativos - suscripción", 15000, new DateTime(2025, 02, 01), new DateTime(2025, 07, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "margon@ribuk.com", "Soporte técnico - plan anual", 9980, new DateTime(2025, 03, 01), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "valrod1@ribuk.com", "Comidas - suscripción premium",10000, new DateTime(2025, 05, 01), new DateTime(2026, 04, 30), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Educacion", "dielop1@ribuk.com", "Plataforma formación - anual",25000, new DateTime(2025, 06, 01), new DateTime(2026, 05, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "margon2@ribuk.com", "Internet hogar básico", 1200, new DateTime(2025, 01, 01), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "laufer1@ribuk.com", "Alquiler mensual departamento B2", 20000, new DateTime(2025, 01, 01), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "sanper@ribuk.com", "Plan de viandas semanal", 2200, new DateTime(2025, 01, 03), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "valrod1@ribuk.com", "Tarjeta STM automática", 1000, new DateTime(2025, 01, 05), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "dielop2@ribuk.com", "Netflix HD", 450, new DateTime(2025, 01, 06), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Educacion", "margon3@ribuk.com", "Curso desarrollo web", 1500, new DateTime(2025, 01, 07), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "margon@ribuk.com", "Internet hogar — mensual", 1200, new DateTime(2025, 01, 01), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "laufer1@ribuk.com", "Alquiler local — mensual", 20000, new DateTime(2025, 01, 01), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "sanper@ribuk.com", "Viandas semanales — plan", 2200, new DateTime(2025, 01, 03), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "valrod@ribuk.com", "Recarga automática transporte", 1000, new DateTime(2025, 01, 05), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "dielop@ribuk.com", "Streaming — plan familiar", 450, new DateTime(2025, 01, 06), new DateTime(2026, 01, 05), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Educacion", "margon@ribuk.com", "Curso mensual — desarrollo web", 1500, new DateTime(2025, 01, 07), new DateTime(2025, 06, 30), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "laufer@ribuk.com", "Antivirus — suscripción anual", 500, new DateTime(2025, 01, 10), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "sanper@ribuk.com", "Cajas de frutas — semanal", 900, new DateTime(2025, 01, 12), new DateTime(2025, 06, 30), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "valrod@ribuk.com", "Mantenimiento caldera — mensual", 800, new DateTime(2025, 02, 01), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "dielop@ribuk.com", "Cuenta gaming — premium", 600, new DateTime(2025, 02, 03), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Educacion", "margon@ribuk.com", "Membresía plataforma cursos", 1200, new DateTime(2025, 02, 05), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "laufer1@ribuk.com", "Seguro hogar — cuota mensual", 1800, new DateTime(2025, 02, 07), new DateTime(2026, 01, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "sanper@ribuk.com", "Alquiler habitación — mensual", 12500, new DateTime(2025, 03, 01), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "valrod@ribuk.com", "Box cenas mensuales", 3000, new DateTime(2025, 03, 04), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "dielop@ribuk.com", "Membresía coche compartido", 750, new DateTime(2025, 03, 06), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "margon@ribuk.com", "Internet — plan anual", 12000, new DateTime(2025, 01, 01), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "laufer@ribuk.com", "Plataforma música — familiar", 800, new DateTime(2025, 03, 10), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Educacion", "sanper@ribuk.com", "Revistas técnicas — suscripción", 400, new DateTime(2025, 03, 15), new DateTime(2025, 08, 15), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "valrod@ribuk.com", "Jardinería — mantenimiento mensual", 650, new DateTime(2025, 04, 01), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "dielop@ribuk.com", "Alquiler local — contrato mensual", 22000, new DateTime(2025, 04, 01), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "margon@ribuk.com", "Catering oficina — mensual", 5200, new DateTime(2025, 04, 03), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "laufer1@ribuk.com", "Abono transporte — mensual", 1400, new DateTime(2025, 04, 05), new DateTime(2025, 09, 30), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "sanper@ribuk.com", "Podcast premium — suscripción", 200, new DateTime(2025, 04, 06), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Educacion", "valrod@ribuk.com", "Talleres mensuales — membresía", 2800, new DateTime(2025, 05, 01), new DateTime(2025, 11, 30), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "dielop@ribuk.com", "Limpieza doméstica — semanal", 4000, new DateTime(2025, 05, 02), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "margon@ribuk.com", "Cochera — pago mensual", 3500, new DateTime(2025, 05, 05), new DateTime(2025, 11, 30), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "laufer@ribuk.com", "Caja verduras — mensual", 1100, new DateTime(2025, 05, 07), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "sanper@ribuk.com", "Bicis públicas — membresía", 300, new DateTime(2025, 06, 01), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "valrod@ribuk.com", "Seguro auto — cuota", 2500, new DateTime(2025, 06, 03), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "dielop@ribuk.com", "Streaming cine — suscripción", 650, new DateTime(2025, 06, 05), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Educacion", "margon@ribuk.com", "Cuota academia arte — mensual", 900, new DateTime(2025, 06, 10), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "laufer1@ribuk.com", "Mantenimiento piscina — temporada", 1800, new DateTime(2025, 06, 15), new DateTime(2025, 09, 15), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "sanper@ribuk.com", "Alquiler departamento — contrato", 19500, new DateTime(2025, 07, 01), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "valrod@ribuk.com", "Box desayuno — mensual", 1300, new DateTime(2025, 07, 03), new DateTime(2026, 01, 03), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "dielop@ribuk.com", "Suscripción taxi premium", 2200, new DateTime(2025, 07, 05), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "margon@ribuk.com", "Suministro electricidad — plan", 1900, new DateTime(2025, 07, 06), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "laufer@ribuk.com", "Club lectura — membresía", 150, new DateTime(2025, 07, 10), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Educacion", "sanper@ribuk.com", "Curso intensivo — mensual", 3500, new DateTime(2025, 07, 15), new DateTime(2025, 12, 15), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "valrod@ribuk.com", "Soporte técnico — mensual", 900, new DateTime(2025, 08, 01), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "dielop@ribuk.com", "Alquiler espacio evento — mensual", 40000, new DateTime(2025, 08, 01), new DateTime(2025, 08, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "margon@ribuk.com", "Plan comidas fitness — mensual", 2600, new DateTime(2025, 08, 03), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "laufer@ribuk.com", "Parking — abono mensual", 600, new DateTime(2025, 08, 05), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "sanper@ribuk.com", "Museo — pase mensual", 220, new DateTime(2025, 08, 07), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Educacion", "valrod@ribuk.com", "Plataforma educativa — suscripción anual", 1400, new DateTime(2025, 09, 01), new DateTime(2026, 08, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "dielop@ribuk.com", "Mantenimiento informático — mensual", 1100, new DateTime(2025, 09, 03), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "margon@ribuk.com", "Bodega — alquiler mensual", 7200, new DateTime(2025, 09, 05), new DateTime(2025, 12, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "laufer@ribuk.com", "Snacks oficina — caja mensual", 700, new DateTime(2025, 09, 07), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "sanper@ribuk.com", "Taxi empresa — suscripción", 1800, new DateTime(2025, 10, 01), new DateTime(2026, 03, 31), true);
        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "valrod@ribuk.com", "Club de cine — cuota anual", 330, new DateTime(2025, 10, 05), null, false);
        AgregarPagoRecurrente(MetodoPago.Credito, "Educacion", "dielop@ribuk.com", "Biblioteca técnica — membresía anual", 250, new DateTime(2025, 10, 10), new DateTime(2026, 10, 09), true);
    }

    public List<Usuario> ListarUsuarios()
    {
        List<Usuario> aux = new List<Usuario>();

        foreach (Usuario usuario in _usuarios)
        {
            aux.Add(usuario);
        }
        return aux;
    }
    
    public void AgregarUsuario(string nombre, string apellido, string contrasena, int equipo, DateTime fechaIngreso, string rol)
    {
        string email = ValidarEmail(nombre, apellido);
        Usuario user = new Usuario(nombre, apellido, contrasena, email, ObtenerEquipo(equipo), fechaIngreso, rol);
        user.Validar();
        _usuarios.Add(user);
    }

    public Usuario? DevolverUsuario(string email)
    {
        Usuario user = null;
        foreach (Usuario u in _usuarios)
        {
            if (u.Email == email) user = u;
        }
        
        return user;
    }
    public void AgregarEquipo(string nombre)
    {
        Equipo eq = new Equipo(nombre);
        _equipos.Add(eq);
    }

    public void AgregarTipoGasto(string nombre, string descripcion)
    {
        if(string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(descripcion)) throw new Exception("Nombre y Descripcion no pueden ser vacios.");
        TipoGasto nuevoTipoGasto = new TipoGasto(nombre, descripcion);
        if (_tiposDeGastos.Contains(nuevoTipoGasto)) throw new Exception("Ya existe un gasto con este nombre.");
        _tiposDeGastos.Add(nuevoTipoGasto);
    }

    public void EliminarTipoGasto(int i)
    {
        ExistePagoConGasto(i);
        _tiposDeGastos.RemoveAt(i);
    }

    private void ExistePagoConGasto(int i)
    {
        foreach (Pago pago in _pagos)
        {
            if (pago.TipoGasto == _tiposDeGastos.ElementAt(i))
            {
                throw new Exception("No se puede eliminar. Existen gastos con este tipo.");
            }
        }
    }
    
    public void AgregarPagoUnico(MetodoPago metodoPago, string tipoGasto, string email, string descr, DateTime fecha, decimal montoPago, int nroRecibo)
    {
        PagoUnico pago = new PagoUnico(metodoPago, ObtenerTipoGasto(tipoGasto), ObtenerUsuario(email), descr, montoPago, fecha, nroRecibo);
        pago.ValidarPago();
        _pagos.Add(pago);
    }

    public void AgregarPagoRecurrente(MetodoPago metodoPago, string tipoGasto, string email, string descr, decimal montoPago, DateTime fechaDesde, DateTime? fechaHasta, bool limite)
    {
        PagoRecurrente pago = new PagoRecurrente(metodoPago, ObtenerTipoGasto(tipoGasto), ObtenerUsuario(email), descr, montoPago ,fechaDesde, fechaHasta, limite);
        pago.ValidarPago();
        _pagos.Add(pago);
    }

    public List<Pago> ObtenerPagosPorPersona(string email)
    {
        List<Pago> aux = new List<Pago>();
        Usuario user = ObtenerUsuario(email);

        foreach (Pago pago in _pagos)
        {
            if(user == pago.Usuario)
            {
                if(pago is PagoUnico pu && pu.FechaPago.Year == DateTime.Today.Year && pu.FechaPago.Month == DateTime.Today.Month)
                {
                    aux.Add(pago);
                }
                else if (pago is PagoRecurrente pr)
                {
                    if(!pr.Limite && pr.FechaDesde.Year <= DateTime.Today.Year)
                    {
                        aux.Add(pago);
                    }
                    else if (pr.FechaDesde.Year <= DateTime.Today.Year && pr.FechaHasta.Value.Month >= DateTime.Today.Month)
                    {
                        aux.Add(pago);
                    }
                }
            }
        }
        aux.Sort();
        return aux;
    }

    public List<Pago> ObtenerPagosPorEquipo(int idEquipo)
    {
        List<Pago> aux = new List<Pago>();

        foreach (Pago pago in _pagos)
        {
            if (pago.Usuario.Equipo.Id == idEquipo)
            {
                 if(pago is PagoUnico pu && pu.FechaPago.Year == DateTime.Today.Year && pu.FechaPago.Month == DateTime.Today.Month)
                    {
                        aux.Add(pago);
                    }
                else if (pago is PagoRecurrente pr)
                {
                     if(!pr.Limite && pr.FechaDesde.Year <= DateTime.Today.Year)
                    {
                        aux.Add(pago);
                    }
                    else if (pr.FechaDesde.Year <= DateTime.Today.Year && pr.FechaHasta.Value.Month == DateTime.Today.Month)
                    {
                        aux.Add(pago);
                    }
                }
            }
        }
        aux.Sort();
        return aux;
    }

    public List<Pago> ObtenerPagosPorEquipoFecha(int idEquipo, int mesPago, int anoPago)
    {
        List<Pago> aux = new List<Pago>();

        foreach (Pago pago in _pagos)
        {
            if (pago.Usuario.Equipo.Id == idEquipo)
            {
                if(pago is PagoUnico pu && pu.FechaPago.Year == anoPago && pu.FechaPago.Month == mesPago)
                {
                    aux.Add(pago);
                }
                else if (pago is PagoRecurrente pr)
                {
                    if(!pr.Limite && pr.FechaDesde.Year <= anoPago)
                    {
                        aux.Add(pago);
                    }
                    else if (pr.FechaDesde.Year <= anoPago && pr.FechaHasta.Value.Month == mesPago)
                    {
                        aux.Add(pago);
                    }
                }
                
            }
        }
        aux.Sort();
        return aux;
    }
    
    public decimal ObtenerGastoMesCorriente(string email)
    {
        decimal monto = 0;
        Usuario user = ObtenerUsuario(email);
        
        foreach (Pago pago in _pagos)
        {
            if (pago.Usuario == user)
            {
                if (pago is PagoUnico pu && pu.FechaPago.Month == DateTime.Today.Month && pu.FechaPago.Year == DateTime.Today.Year) 
                monto += pu.CalcularPromocion(); //20000
                else if (pago is PagoRecurrente pr && pr.Limite && pr.FechaHasta > DateTime.Today && pr.FechaDesde < DateTime.Today )
                {
                    monto += pr.CalcularPromocion() / pr.CalcularCuotas(); //1000
                }
                else
                {
                    monto += pago.CalcularPromocion(); //9980
                }
            }
        }
 
        return monto;
    }
    
    public List<Usuario> ObtenerUsuariosPorEquipo(int idEquipo)
    {
        List<Usuario> aux = new List<Usuario>();
        foreach (Usuario user in _usuarios)
        {
            if(user.PerteneceAlEquipo(idEquipo)) aux.Add(user);
        }
        
        return aux;
    }
 
    private Usuario ObtenerUsuario(string email)
    {
        foreach (Usuario user in _usuarios)
        {
            if (user.Email == email) return user;
        }

        throw new Exception("El usuario no existe.");
    }
    
    private Equipo ObtenerEquipo(int idEquipo)
    {
        foreach (Equipo eq in _equipos)
        {
            if (eq.Id == idEquipo) return eq;
        }

        throw new Exception("El equipo seleccionado no existe.");
    }

    private TipoGasto ObtenerTipoGasto(string tipoGasto)
    {
        foreach (TipoGasto tipo in _tiposDeGastos)
        {
            if (tipo.Nombre == tipoGasto) return tipo;
        }

        throw new Exception("El tipo de gasto no es valido");
    }
    
    
    
    //METODOS DE VALIDACIÓN
    private string ValidarEmail(string nombre, string apellido)
    {
        string nombreValido = nombre.Length > 3 ? nombre.Substring(0, 3) : nombre;
        string apellidoValido = apellido.Length > 3 ? apellido.Substring(0, 3) : apellido;
        
        string email = $"{nombreValido.ToLower()}{apellidoValido.ToLower()}@ribuk.com";
        
        int cantExistente = 1;
        
        foreach (Usuario user in _usuarios)
        { 
            if (user.MailEsIgual(email))
            {
                email = $"{nombreValido.ToLower()}{apellidoValido.ToLower()}{cantExistente++}@ribuk.com";
            }
        }
       
        return email;
    }

    public Usuario? UsuarioValido(string user, string pass)
    {
        foreach (Usuario usuario in _usuarios)
        {
            if (user == usuario.Email)
            {
                if (pass == usuario.Contrasena)
                {
                    return usuario;
                }
                break;
            }
        }
        return null;
    }
}