using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;

namespace ProyectoCrypto
{
    internal class Program
    {
        // Corregido: static async Task Main para usar await (Punto 8)
        static async Task Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // Para mostrar símbolos de moneda

            // 7. Cargar Cartera al inicio
            Cartera miCartera = Cartera.Cargar();

            // 4. Lista de monedas disponibles
            List<MonedaBase> monedas = new List<MonedaBase>
            {
                new Bitcoin(),
                new Ethereum()
            };

            // Lógica de arranque: actualizar precios al iniciar
            await ActualizarPrecios(monedas);

            // 10. Interfaz de usuario por consola: Iniciar menú
            await Menu(miCartera, monedas);

            // 7. Guardar Cartera al salir
            miCartera.Guardar();
            Console.WriteLine("Programa finalizado. Presione cualquier tecla para cerrar...");
            Console.ReadKey();
        }

        static async Task Menu(Cartera cartera, List<MonedaBase> monedas)
        {
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine($"--- Crypto Wallet Manager | Usuario: {cartera.NombreUsuario} ---");
                Console.WriteLine("1. Actualizar Precios (Llamar a APIs)");
                Console.WriteLine("2. Ver Cartera y Valor Actual");
                Console.WriteLine("3. Realizar Compra/Venta");
                Console.WriteLine("4. Ver Historial de Transacciones");
                Console.WriteLine("5. Salir y Guardar");
                Console.Write("Seleccione una opción: ");

                if (int.TryParse(Console.ReadLine(), out int opcion))
                {
                    switch (opcion)
                    {
                        case 1:
                            await ActualizarPrecios(monedas);
                            break;
                        case 2:
                            MostrarCartera(cartera, monedas);
                            break;
                        case 3:
                            RealizarTransaccion(cartera, monedas);
                            break;
                        case 4:
                            MostrarHistorial(cartera);
                            break;
                        case 5:
                            salir = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Entrada no válida. Intente de nuevo.");
                }

                if (!salir)
                {
                    Console.WriteLine("\nPresione cualquier tecla para volver al menú...");
                    Console.ReadKey();
                }
            }
        }

        // Lógica para actualizar los precios de todas las monedas (Punto 8)
        static async Task ActualizarPrecios(List<MonedaBase> monedas)
        {
            Console.WriteLine("\n--- Actualizando precios en tiempo real... ---");
            // Ejecución paralela de las APIs para mayor eficiencia (opcional)
            var tasks = monedas.Select(m => m.ObtenerPrecioUSD()).ToList();
            await Task.WhenAll(tasks);

            foreach (var moneda in monedas)
            {
                Console.WriteLine($"✅ Precio de {moneda.Nombre} ({moneda.Ticker}): ${moneda.PrecioUSDActual:N2} USD");
            }
        }

        // Lógica para mostrar la cartera (Punto 1, 4)
        static void MostrarCartera(Cartera cartera, List<MonedaBase> monedas)
        {
            Console.WriteLine("\n--- Resumen de Cartera ---");
            Console.WriteLine($"Saldo Disponible (USD): ${cartera.SaldoUSD:N2}");
            double valorTotalCripto = 0;

            foreach (var moneda in monedas)
            {
                if (cartera.Holdings.ContainsKey(moneda.Ticker) && cartera.Holdings[moneda.Ticker] > 0)
                {
                    double cantidad = cartera.Holdings[moneda.Ticker];
                    double valorMoneda = cantidad * moneda.PrecioUSDActual;
                    valorTotalCripto += valorMoneda;

                    Console.WriteLine($"- {moneda.Nombre} ({moneda.Ticker}): {cantidad:N8} unidades | Valor: ${valorMoneda:N2} USD (Precio: ${moneda.PrecioUSDActual:N2})");
                }
            }

            double valorTotal = cartera.SaldoUSD + valorTotalCripto;
            Console.WriteLine($"------------------------------------------");
            Console.WriteLine($"VALOR TOTAL DE ACTIVOS: ${valorTotal:N2} USD");
        }

        // Lógica para realizar transacciones (Punto 4, 6)
        static void RealizarTransaccion(Cartera cartera, List<MonedaBase> monedas)
        {
            Console.WriteLine("\n--- Realizar Transacción ---");

            Console.WriteLine("Seleccione una moneda para operar (ej: BTC, ETH):");
            string ticker = Console.ReadLine()?.ToUpperInvariant();
            MonedaBase monedaSeleccionada = monedas.FirstOrDefault(m => m.Ticker == ticker);

            if (monedaSeleccionada == null)
            {
                Console.WriteLine("Moneda no válida.");
                return;
            }

            Console.WriteLine($"Precio actual de {ticker}: ${monedaSeleccionada.PrecioUSDActual:N2}");

            Console.WriteLine("¿Comprar o Vender? (C/V):");
            string tipoStr = Console.ReadLine()?.ToUpperInvariant();

            if (tipoStr != "C" && tipoStr != "V")
            {
                Console.WriteLine("Opción no válida.");
                return;
            }

            TipoTransaccion tipo = (tipoStr == "C") ? TipoTransaccion.Compra : TipoTransaccion.Venta;

            Console.WriteLine($"Ingrese la cantidad de {ticker} a {tipo}:");
            if (!double.TryParse(Console.ReadLine(), out double cantidad) || cantidad <= 0)
            {
                Console.WriteLine("Cantidad no válida.");
                return;
            }

            // Validación de saldo/holdings (Lógica de Cartera)
            if (tipo == TipoTransaccion.Compra)
            {
                double costo = cantidad * monedaSeleccionada.PrecioUSDActual;
                if (cartera.SaldoUSD < costo)
                {
                    Console.WriteLine($"ERROR: Saldo USD insuficiente. Necesitas ${costo:N2} y tienes ${cartera.SaldoUSD:N2}.");
                    return;
                }
            }
            else // Venta
            {
                double holdingsActual = 0;

                // CÓDIGO CORREGIDO PARA COMPATIBILIDAD CON NET FRAMEWORK
                if (cartera.Holdings.ContainsKey(ticker))
                {
                    holdingsActual = cartera.Holdings[ticker];
                }

                // Opcional: usando TryGetValue, más limpio pero más verborrágico
                // cartera.Holdings.TryGetValue(ticker, out double holdingsActual);

                if (holdingsActual < cantidad)
                {
                    Console.WriteLine($"ERROR: Holdings insuficientes. Tienes {holdingsActual:N8} {ticker} y quieres vender {cantidad:N8}.");
                    return;
                }
            }

            // Crea y agrega la transacción
            Transaccion nuevaTransaccion = new Transaccion
            {
                Fecha = DateTime.Now,
                Tipo = tipo,
                TickerMoneda = ticker,
                Cantidad = cantidad,
                PrecioEjecucion = monedaSeleccionada.PrecioUSDActual
            };

            cartera.AgregarTransaccion(nuevaTransaccion);
            Console.WriteLine($"\n✅ Transacción de {tipo} exitosa: {cantidad:N8} {ticker} ejecutada a ${monedaSeleccionada.PrecioUSDActual:N2}.");
        }

        // Lógica para mostrar historial (Punto 4)
        static void MostrarHistorial(Cartera cartera)
        {
            Console.WriteLine("\n--- Historial de Transacciones ---");
            if (cartera.Historial.Count == 0)
            {
                Console.WriteLine("El historial está vacío.");
                return;
            }

            // Muestra las últimas 10 transacciones
            foreach (var t in cartera.Historial.OrderByDescending(t => t.Fecha).Take(10))
            {
                string accion = (t.Tipo == TipoTransaccion.Compra) ? "COMPRA" : "VENTA";
                string valor = (t.Cantidad * t.PrecioEjecucion).ToString("N2");
                Console.WriteLine($"{t.Fecha:dd/MM/yy HH:mm} | {accion,-6} | {t.Cantidad:N8} {t.TickerMoneda} @ ${t.PrecioEjecucion:N2} | Total: ${valor}");
            }
            if (cartera.Historial.Count > 10) Console.WriteLine($"... y {cartera.Historial.Count - 10} transacciones más.");
        }
    }
}