using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text.Json;

namespace ProyectoCrypto
{
    // 2. Herencia: Ethereum hereda de MonedaBase
    public class Ethereum : MonedaBase
    {
        // 6. Enum (usado para el símbolo de la API)
        public enum ApiSymbol { ETHUSDT }

        public Ethereum() : base("Ethereum", "ETH") { }

        // 8. Conexión a una API externa (Binance)
        public override async Task<double> ObtenerPrecioUSD()
        {
            string urlApi = $"https://api.binance.com/api/v3/ticker/price?symbol={ApiSymbol.ETHUSDT}";

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    string datos = await client.GetStringAsync(urlApi);
                    var precioData = JsonSerializer.Deserialize<CryptoPriceModel>(datos);

                    // 3. Encapsulamiento: Actualiza el precio a través del setter protected
                    PrecioUSDActual = precioData.Precio;
                    return PrecioUSDActual;
                }
                catch (HttpRequestException)
                {
                    Console.WriteLine($"[ERROR API] No se pudo conectar a la API de {Nombre}. Usando último precio conocido.");
                    return PrecioUSDActual;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[ERROR] Fallo en la obtención del precio de {Nombre}: {ex.Message}");
                    return PrecioUSDActual;
                }
            }
        }
    }
}