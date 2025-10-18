using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrypto
{
    // 1. Clase: Representa una acción en la cartera
    public class Transaccion
    {
        public DateTime Fecha { get; set; }
        public TipoTransaccion Tipo { get; set; } // Usa el Enum
        public string TickerMoneda { get; set; } // BTC, ETH, USD
        public double Cantidad { get; set; }
        public double PrecioEjecucion { get; set; }
    }
}