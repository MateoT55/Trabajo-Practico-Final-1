using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrypto
{
    public interface IPrecioActualizable
    {
        // Define el contrato para obtener el precio de una fuente externa
        Task<double> ObtenerPrecioUSD();
    }
}
