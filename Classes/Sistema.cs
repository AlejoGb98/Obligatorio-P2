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
        AgregarTipoGasto("Servicios", "Facturas del hoga.");
        AgregarTipoGasto("Entretenimiento", "Gastos de ocio, salidas, suscripciones.");
        AgregarTipoGasto("Educacion", "Cursos, Facultad, Lenguas.");

        AgregarUsuario("Martin", "Gonzalez", "12312312", 3, new DateTime(23, 11, 09));
        AgregarUsuario("Laura", "Fernandez", "45645612", 2, new DateTime(22, 05, 15));
        AgregarUsuario("Santiago", "Perez", "78978912", 4, new DateTime(24, 01, 20));
        AgregarUsuario("Valeria", "Rodriguez", "32132112", 2, new DateTime(21, 07, 03));
        AgregarUsuario("Diego", "Lopez", "65465412", 3, new DateTime(25, 03, 12));
        AgregarUsuario("Marcos", "Gonzalez", "11122233", 1, new DateTime(24, 02, 10)); 
        AgregarUsuario("Martina", "Gonzalez", "22233344", 2, new DateTime(24, 04, 21)); 
        AgregarUsuario("Mariano", "Gonzalez", "33344455", 4, new DateTime(23, 12, 01)); 
        AgregarUsuario("Laura", "Fernandez", "44455566", 1, new DateTime(23, 09, 30)); 
        AgregarUsuario("Laura", "Fernandez", "44455567", 2, new DateTime(25, 01, 05)); 
        AgregarUsuario("Santiago", "Perez", "55566677", 2, new DateTime(22, 11, 11)); 
        AgregarUsuario("Santiago", "Peres", "55566678", 1, new DateTime(24, 06, 18)); 
        AgregarUsuario("Valentino", "Rodriguez", "66677788", 3, new DateTime(24, 08, 09)); 
        AgregarUsuario("Valeria", "Rodriguez", "66677789", 1, new DateTime(23, 03, 27)); 
        AgregarUsuario("Diego", "Lopez", "77788899", 4, new DateTime(24, 05, 02)); 
        AgregarUsuario("Diego", "Lopez", "65426412", 3, new DateTime(25, 03, 12)); 
        AgregarUsuario("Ana", "Gomez", "88899900", 1, new DateTime(23, 07, 14)); 
        AgregarUsuario("Andres", "Gomez", "99900011", 2, new DateTime(25, 02, 28)); 
        AgregarUsuario("Florencia", "Martinez", "10101010", 2, new DateTime(24, 10, 07)); 
        AgregarUsuario("Federico", "Martinez", "12121212", 1, new DateTime(23, 05, 19)); 
        AgregarUsuario("Camila", "Santos", "13131313", 3, new DateTime(22, 12, 25)); 


        // ---------------------------
        // 19 Pagos Únicos (solo Debito | Efectivo)
        // ---------------------------
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "margon@ribuk.com", "Pago Alquiler — Piso A",
            new DateTime(2025, 09, 01), 20000, 500);
        AgregarPagoUnico(MetodoPago.Efectivo, "Comida", "laufer@ribuk.com", "Compra supermercado - quincena",
            new DateTime(2025, 08, 28), 8400, 120);
        AgregarPagoUnico(MetodoPago.Debito, "Transporte", "sanper@ribuk.com", "Mudanza local",
            new DateTime(2025, 07, 10), 7200, 300);
        AgregarPagoUnico(MetodoPago.Efectivo, "Servicios", "valrod@ribuk.com", "Pago agua - factura extra",
            new DateTime(2025, 09, 22), 1600, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "dielop1@ribuk.com", "Concierto - entrada VIP",
            new DateTime(2025, 06, 21), 12000, 250);
        AgregarPagoUnico(MetodoPago.Efectivo, "Comida", "dielop@ribuk.com", "Catering evento",
            new DateTime(2025, 05, 04), 9800, 400);
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "margon1@ribuk.com", "Pago Alquiler — Local B",
            new DateTime(2025, 06, 01), 15000, 300);
        AgregarPagoUnico(MetodoPago.Efectivo, "Comida", "margon2@ribuk.com", "Compra supermercado - emergencia",
            new DateTime(2025, 03, 12), 5600, 70);
        AgregarPagoUnico(MetodoPago.Debito, "Transporte", "laufer1@ribuk.com", "Servicio taxi - traslado especial",
            new DateTime(2025, 04, 18), 2100, 0);
        AgregarPagoUnico(MetodoPago.Efectivo, "Servicios", "laufer2@ribuk.com", "Reparación eléctrica - urgencia",
            new DateTime(2025, 02, 27), 4300, 50);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "sanper1@ribuk.com", "Entrada festival música",
            new DateTime(2025, 09, 05), 5200, 150);
        AgregarPagoUnico(MetodoPago.Efectivo, "Comida", "valrod1@ribuk.com", "Cena empresarial",
            new DateTime(2025, 07, 02), 11000, 200);
        AgregarPagoUnico(MetodoPago.Debito, "Servicios", "dielop@ribuk.com", "Servicio técnico electrodoméstico",
            new DateTime(2025, 01, 15), 2600, 20);
        AgregarPagoUnico(MetodoPago.Efectivo, "Entretenimiento", "margon3@ribuk.com", "Clase de pintura - sesión única",
            new DateTime(2025, 06, 05), 1400, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Comida", "anagom@ribuk.com", "Almuerzo corporativo especial",
            new DateTime(2025, 08, 07), 4700, 60);
        AgregarPagoUnico(MetodoPago.Efectivo, "Transporte", "andgom@ribuk.com", "Traslado aeropuerto",
            new DateTime(2025, 05, 30), 3200, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Alquiler", "valrod2@ribuk.com", "Pago Alquiler — Bodega",
            new DateTime(2025, 09, 15), 13000, 400);
        AgregarPagoUnico(MetodoPago.Efectivo, "Servicios", "flomar@ribuk.com", "Pago jardinería - corte anual",
            new DateTime(2025, 03, 09), 2700, 0);
        AgregarPagoUnico(MetodoPago.Debito, "Entretenimiento", "fedmar@ribuk.com", "Taller gastronómico - plaza",
            new DateTime(2025, 04, 11), 2300, 30);

        // ---------------------------
        // 25 Pagos Recurrentes (todos Credito) — incluyen monto y bool (activo)
        // Al menos 3 de estos tienen fecha de fin anterior al 23/09/2025 (marcados abajo).
        // ---------------------------
        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "margon@ribuk.com", "Internet hogar - plan anual",
        12000, new DateTime(2025, 01, 01), new DateTime(2025, 12, 31), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "laufer@ribuk.com", "Streaming música - plan familiar", 
            260, new DateTime(2024, 01, 01), null, false); 

        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "sanper@ribuk.com", "Suscripción comidas - oficina",
            9000, new DateTime(2025, 03, 01), new DateTime(2025, 09, 30), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "valrod@ribuk.com", "Tarjeta transporte - mensual",
            2000, new DateTime(2025, 02, 01), new DateTime(2025, 08, 15), true); // FIN EN PASADO (mantenido si querés simular histórico)

        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "dielop2@ribuk.com", "Alquiler local - contrato anual",
           35000, new DateTime(2025, 05, 01), new DateTime(2026, 04, 30), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "dielop@ribuk.com", "Gas domiciliario - plan",
            2500, new DateTime(2025, 01, 15), null, true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "margon1@ribuk.com", "Viandas semanales - empleado",
          2500, new DateTime(2025, 04, 01), new DateTime(2025, 10, 01), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "laufer1@ribuk.com", "Servidor cloud - plan mensual",
           690, new DateTime(2025, 02, 01), new DateTime(2025, 11, 30), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "sanper1@ribuk.com", "Suscripción videojuegos - mensual",
          690, new DateTime(2025, 06, 01), null, true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "valrod1@ribuk.com", "Mantenimiento flota - mensual",
          15000 , new DateTime(2025, 03, 01), new DateTime(2025, 09, 01), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "dielop@ribuk.com", "Alquiler bodega - contrato 6 meses",
            60000, new DateTime(2025, 01, 01), new DateTime(2025, 06, 30), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "margon2@ribuk.com", "Mantenimiento web - plan anual",
            490, new DateTime(2025, 04, 01), new DateTime(2026, 03, 31), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "dielop1@ribuk.com", "Catering mensual - eventos",
            12000, new DateTime(2025, 05, 01), new DateTime(2025, 11, 30), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "flomar@ribuk.com", "Cineclub - suscripción",
            990, new DateTime(2025, 02, 01), null, false); 

        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "fedmar@ribuk.com", "Backup mensual - empresa",
            690, new DateTime(2025, 01, 01), new DateTime(2025, 12, 31), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "camsan@ribuk.com", "Plan viandas - suscripción",
            4500, new DateTime(2025, 03, 15), new DateTime(2025, 09, 15), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Transporte", "margon3@ribuk.com", "Servicio logística - mensual",
            4600, new DateTime(2025, 06, 01), new DateTime(2025, 12, 31), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Alquiler", "valrod2@ribuk.com", "Alquiler oficina - plan anual",
           15000 , new DateTime(2025, 07, 01), new DateTime(2026, 06, 30), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "dielop2@ribuk.com", "Mantenimiento ascensor - contrato",
           5600, new DateTime(2025, 08, 01), new DateTime(2025, 12, 31), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Entretenimiento", "margon3@ribuk.com", "Suscripción revista digital",
            690, new DateTime(2025, 09, 01), null, false);

        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "laufer2@ribuk.com", "Limpieza oficinas - plan mensual",
            7000, new DateTime(2025, 01, 10), new DateTime(2025, 12, 10), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "sanper1@ribuk.com", "Desayunos corporativos - suscripción",
            15000, new DateTime(2025, 02, 01), new DateTime(2025, 07, 31), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Servicios", "margon@ribuk.com", "Soporte técnico - plan anual",
            9980, new DateTime(2025, 03, 01), new DateTime(2026, 02, 28), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Comida", "valrod1@ribuk.com", "Comidas - suscripción premium",
            10000, new DateTime(2025, 05, 01), new DateTime(2026, 04, 30), true);

        AgregarPagoRecurrente(MetodoPago.Credito, "Educacion", "dielop1@ribuk.com", "Plataforma formación - anual", 
            25000, new DateTime(2025, 06, 01), new DateTime(2026, 05, 31), true);
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
    
    public void AgregarUsuario(string nombre, string apellido, string contrasena, int equipo, DateTime fechaIngreso)
    {
        string email = ValidarEmail(nombre, apellido);
        Usuario user = new Usuario(nombre, apellido, contrasena, email, ObtenerEquipo(equipo), fechaIngreso);
        user.Validar();
        _usuarios.Add(user);
    }

    public void AgregarEquipo(string nombre)
    {
        Equipo eq = new Equipo(nombre);
        _equipos.Add(eq);
    }

    public void AgregarTipoGasto(string nombre, string descripcion)
    {
        TipoGasto nuevoTipoGasto = new TipoGasto(nombre, descripcion);
        _tiposDeGastos.Add(nuevoTipoGasto);
    }

    public void AgregarPagoUnico(MetodoPago metodoPago, string tipoGasto, string email, string descr, DateTime fecha, decimal montoPago, int nroRecibo )
    {
        PagoUnico pago = new PagoUnico(metodoPago, ObtenerTipoGasto(tipoGasto), ObtenerUsuario(email), descr, montoPago, fecha, nroRecibo);
        pago.ValidarPago();
        _pagos.Add(pago);
    }

    public void AgregarPagoRecurrente(MetodoPago metodoPago, string tipoGasto, string email, string descr, decimal montoPago, DateTime fechaDesde, DateTime? fechaHasta, bool limite)
    {
        PagoRecurrente pago = new PagoRecurrente(metodoPago, ObtenerTipoGasto(tipoGasto), ObtenerUsuario(email), descr, montoPago ,fechaDesde, fechaHasta, limite);
        //pago.ValidarPago();
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
                aux.Add(pago);
            }
        }

        return aux;
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
        string email = $"{nombre.Substring(0,3).ToLower()}{apellido.Substring(0,3).ToLower()}@ribuk.com";;
        
        int cantExistente = 0;
        foreach (Usuario user in _usuarios)
        {
            if (user.MailEsIgual(email.Substring(0, 6)))
            {
                cantExistente++;
            }
        }

        if (cantExistente != 0)
        {
            email = $"{nombre.Substring(0,3).ToLower()}{apellido.Substring(0,3).ToLower()}{cantExistente}@ribuk.com";
        }
       
        return email;
    }
}