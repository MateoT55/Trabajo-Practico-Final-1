using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrypto
{
    // 6. Enumeraciones: Define los tipos fijos de transacciones
    public enum TipoTransaccion
    {
        Compra,
        Venta,
        DepositoUSD, // Opcional, para simular ingreso de capital
        RetiroUSD
    }
}