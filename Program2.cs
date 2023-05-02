internal class Program
{
    private static void Main(string[] args)
    {
        int opcionElegida;
        opcionElegida = opcion("Eligue una opcion");
        while (opcionElegida > 0 && opcionElegida < 5)
        {
            switch (opcionElegida)
            {
                case 1:
                    nuevaInscripcion();
                    break;
                case 2:
                    obtenerEstadisticasDelEvento();
                    break;
                case 3:
                    buscarCliente();
                    break;
                case 4:
                    cambiarEntrada();
                    break;
            }
            opcionElegida = opcion("Eligue una opcion");
        }

        void cambiarEntrada()
        {
            int idEntrada = ingresarInt("Ingresa el ID de la entrada que tienes");
            int nuevoTipoDeEntrada = ingresarInt("Ingresa el nuevo tipo de entrada, para que dias queres");
            int precioNuevaEntrada = calcularTotal(nuevoTipoDeEntrada);
            bool pudo = tiquetera.CambiarEntrada(idEntrada, nuevoTipoDeEntrada, precioNuevaEntrada);
            if(pudo==true){
            Console.WriteLine("pudo");
            }else{
            Console.WriteLine("No se pudo cambiar la entrada, porquen la que quieres comprar en de menor precio a la que ya tenias anteriormente");
            }
        }

        void buscarCliente()
        {
            int personaABuscar=ingresarInt("ingresa el ID de la entrada");
            Cliente personaEncontrada = tiquetera.BuscarCliente(personaABuscar);
            if (personaEncontrada != null)
            {
                Console.WriteLine("La informacion sobre la inscripcion de este cliente es:");
                Console.WriteLine("DNI: " +personaEncontrada.DNI);
                Console.WriteLine("Nombre " +personaEncontrada.Nombre);
                Console.WriteLine("Apellido: " +personaEncontrada.Apellido);
                Console.WriteLine("Fecha de inscripcion: " + personaEncontrada.FechaInscripcion);
                Console.WriteLine("Dia de la entrada: " +personaEncontrada.TipoEntrada);
                Console.WriteLine("Total abonado: $" +personaEncontrada.TotalAbono);
            }else
            {
                Console.WriteLine("No se encontro la entrada");
            }

        }
        void obtenerEstadisticasDelEvento()
        {
            List<string> estadisticas = tiquetera.obtenerEstadisticas();
            foreach (var item in estadisticas)
            {
                Console.WriteLine(item);
            }
        }

        int opcion(string mensaje)
        {
            int num;
            Console.WriteLine(mensaje);
            Console.WriteLine("1- Nueva Inscripción");
            Console.WriteLine("2- Obtener Estadísticas del Evento");
            Console.WriteLine("3- Buscar Cliente");
            Console.WriteLine("4- Cambiar entrada de un Cliente");
            Console.WriteLine("5- Salir");
            num = int.Parse(Console.ReadLine());
            return num;
        }


        int ingresarInt(string mensaje)
        {
            int num;
            Console.WriteLine(mensaje);
            num = int.Parse(Console.ReadLine());
            return num;
        }

        string ingresarTexto(string mensaje)
        {
            string texto;
            Console.WriteLine(mensaje);
            texto = Console.ReadLine();
            return texto;
        }
        int ingresarentrada(string mensaje)
        {
            int num;
            Console.WriteLine(mensaje);
            num = int.Parse(Console.ReadLine());
            while (num > 4)
            {
                Console.WriteLine("La opcion maxima es 4, ingresade nuevo la entrada");
                num = int.Parse(Console.ReadLine());
            }
            return num;
        }


        void nuevaInscripcion()
        {
            int dni, tipoEn, totalAbo;
            string ape, nom;
            dni = ingresarInt("Ingrese su DNI");
            ape = ingresarTexto("Ingrese su apellido");
            nom = ingresarTexto("Ingrese su nombre");
            tipoEn = ingresarentrada("Ingrese para que dia quiere sacar la entrada o si quiere el Full Pass, ponga 4");
            DateTime fechaIn = DateTime.Today;
            totalAbo = calcularTotal(tipoEn);
            Cliente unCliente = new Cliente(dni, ape, nom, fechaIn, tipoEn, totalAbo);
            int id = tiquetera.AgregarCliente(unCliente);
        }

        int calcularTotal(int tipoEn)
        {
            int total;
            if (tipoEn == 1)
            {
                total = 15000;
            }
            else if (tipoEn == 2)
            {
                total = 30000;
            }
            else if (tipoEn == 3)
            {
                total = 10000;
            }
            else
            {
                total = 40000;
            }
            return total;
        }
    }



}