using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;

namespace Trabajo_Final_Programación
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            
            try
            {
                HttpClient client = new HttpClient();


                Ingrediente Ing = new Ingrediente();
                string urlApi = ($"https://jsonreader-5pkg.onrender.com/ingredientes");
                string datos = await client.GetStringAsync(urlApi);


                Ing = JsonSerializer.Deserialize<Ingrediente>(datos);

                IngredienteApi apiData = JsonSerializer.Deserialize<IngredienteApi>(datos);

                foreach (Proteina Pr in apiData.Proteina)
                {
                    Console.WriteLine($"Este es el nombre de la proteina {Pr.Nombre}");
                    Console.WriteLine($"Esta es la cantidad: {Pr.cantidad}");
                }



                Console.ReadKey();



            }
        
            catch 
            { 
            
            }
        

        }
    }
}


