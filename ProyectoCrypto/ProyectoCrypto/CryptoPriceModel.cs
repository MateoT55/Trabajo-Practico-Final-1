using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using System.Globalization;

namespace ProyectoCrypto
{
    // Clase para mapear la respuesta de la API
    public class CryptoPriceModel
    {
        [JsonPropertyName("symbol")]
        public string symbol { get; set; }

        [JsonPropertyName("price")]
        public string price { get; set; }

        // Propiedad de solo lectura para convertir el string de la API a double
        public double Precio
        {
            get
            {
                // Usamos CultureInfo.InvariantCulture para asegurar que el punto sea el separador decimal
                if (double.TryParse(price, NumberStyles.Any, CultureInfo.InvariantCulture, out double valor))
                {
                    return valor;
                }
                return 0.0;
            }
        }
    }
}