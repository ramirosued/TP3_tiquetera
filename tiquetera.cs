static class tiquetera
{
    private static Dictionary<int, Cliente> tiqueteraDic = new Dictionary<int, Cliente>();
    private static int UltimoIDEntrada = 0;
     
    public static int DevolverUltimoID()
    {
        return UltimoIDEntrada;

    }
    public static int AgregarCliente(Cliente Cliente)
    {
        UltimoIDEntrada++;

        tiqueteraDic.Add(UltimoIDEntrada, Cliente);
        return UltimoIDEntrada;
    }

    public static Cliente BuscarCliente(int idEntrada)
    {
        Cliente clienteABuscar = null;
        if (tiqueteraDic.ContainsKey(idEntrada))
        {
            clienteABuscar = tiqueteraDic[idEntrada];
        }
        return clienteABuscar;

    }
    public static bool CambiarEntrada(int id, int tipo, int total)
    {
        bool pudo = false;
        int precioEntradaOriginal = tiqueteraDic[id].TotalAbono;
        if (precioEntradaOriginal < total)
        {
            pudo = true;
            tiqueteraDic[id].TotalAbono = total;
            tiqueteraDic[id].TipoEntrada = tipo;
        }
        return pudo;
    }


    public static List<string> obtenerEstadisticas()
    {
        int tipo = 0;
        int totalPorDia = 0;
        int total = 0;
        List<string> listarEstadisticas = new List<string>();
        int cantInscriptos = tiqueteraDic.Count();
        listarEstadisticas.Add("La cantidad de inscriptos es " + cantInscriptos);
        int[] cantidadDeEntradasPorDia = { 0, 0, 0, 0 };
        int[] recaudaccionDeEntradasPorDia = { 0, 0, 0, 0 };

        foreach (Cliente item in tiqueteraDic.Values)
        {
            tipo = item.TipoEntrada;
            cantidadDeEntradasPorDia[tipo - 1] += 1;
            totalPorDia = item.TotalAbono;
            recaudaccionDeEntradasPorDia[tipo - 1] = cantidadDeEntradasPorDia[tipo - 1] + totalPorDia;
            total = total + totalPorDia;
        }
        listarEstadisticas.Add("De las entradas que se vendieron " + (cantidadDeEntradasPorDia[0] / Convert.ToDouble(cantInscriptos)) * 100 + "% son del dia 1");
        listarEstadisticas.Add("De las entradas que se vendieron " + (cantidadDeEntradasPorDia[1] / Convert.ToDouble(cantInscriptos)) * 100 + "% son del dia 2");
        listarEstadisticas.Add("De las entradas que se vendieron " + (cantidadDeEntradasPorDia[2] / Convert.ToDouble(cantInscriptos)) * 100 + "% son del dia 3");
        listarEstadisticas.Add("De las entradas que se vendieron " + (cantidadDeEntradasPorDia[3] / Convert.ToDouble(cantInscriptos)) * 100 + "% son del dia 4");
        listarEstadisticas.Add("Del dia 1 se recaudaron $" + recaudaccionDeEntradasPorDia[0]);
        listarEstadisticas.Add("Del dia 2 se recaudaron $" + recaudaccionDeEntradasPorDia[1]);
        listarEstadisticas.Add("Del dia 3 se recaudaron $" + recaudaccionDeEntradasPorDia[2]);
        listarEstadisticas.Add("Del dia 4 se recaudaron $" + recaudaccionDeEntradasPorDia[3]);
        listarEstadisticas.Add("En total se recaudaron $" + total);
        return listarEstadisticas;
    }


}


