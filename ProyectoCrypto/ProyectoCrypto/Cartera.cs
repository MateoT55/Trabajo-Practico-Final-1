using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;

namespace ProyectoCrypto
{
    // 2. Agregación: Contiene colecciones de objetos Transaccion
    public class Cartera
    {
        // 4. Listas: Para el historial de transacciones
        public List<Transaccion> Historial { get; set; } = new List<Transaccion>();

        // Dictionary: Almacena los saldos de criptos (Ticker -> Cantidad)
        public Dictionary<string, double> Holdings { get; set; } = new Dictionary<string, double>();

        public double SaldoUSD { get; set; } = 1000.00; // Saldo inicial simulado
        public string NombreUsuario { get; set; } = "Inversor Ejemplo";

        // 7. Serialización y Deserialización en JSON
        private const string ArchivoDatos = "cartera.json";

        public void Guardar()
        {
            try
            {
                var json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(ArchivoDatos, json);
                Console.WriteLine("\n✅ Datos de la cartera guardados en cartera.json.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[ERROR] Fallo al guardar la cartera: {ex.Message}");
            }
        }

        public static Cartera Cargar()
        {
            if (File.Exists(ArchivoDatos))
            {
                try
                {
                    var json = File.ReadAllText(ArchivoDatos);
                    // 7. Deserialización
                    var cartera = JsonSerializer.Deserialize<Cartera>(json);
                    Console.WriteLine("✅ Cartera cargada exitosamente desde cartera.json.");
                    return cartera ?? new Cartera();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Fallo al cargar la cartera. Creando nueva: {ex.Message}");
                    return new Cartera();
                }
            }
            // Si no existe, devuelve una cartera nueva (con saldo inicial simulado)
            return new Cartera();
        }

        public void AgregarTransaccion(Transaccion transaccion)
        {
            Historial.Add(transaccion);
            // Lógica de actualización de Holdings (simplificada)
            if (transaccion.Tipo == TipoTransaccion.Compra)
            {
                if (Holdings.ContainsKey(transaccion.TickerMoneda))
                    Holdings[transaccion.TickerMoneda] += transaccion.Cantidad;
                else
                    Holdings.Add(transaccion.TickerMoneda, transaccion.Cantidad);

                SaldoUSD -= transaccion.Cantidad * transaccion.PrecioEjecucion;
            }
            else if (transaccion.Tipo == TipoTransaccion.Venta)
            {
                Holdings[transaccion.TickerMoneda] -= transaccion.Cantidad;
                SaldoUSD += transaccion.Cantidad * transaccion.PrecioEjecucion;
            }
        }
    }
}