using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

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
                string urlApi = ($"https://gist.githubusercontent.com/MateoT55/3cce622666762814a93ea2e43611900e/raw/8362506023614384852a81feedf54ea79dbd809c/gistfile1.txt");
                Console.WriteLine("Cargando datos de ingredientes desde la API...");

                string datos = await client.GetStringAsync(urlApi);


                Ing = JsonSerializer.Deserialize<Ingrediente>(datos);

                IngredienteApi apiData = JsonSerializer.Deserialize<IngredienteApi>(datos);
                Console.WriteLine("Datos cargados correctamente.");


                foreach (Proteina Pr in apiData.Proteina)
                {
                    Console.WriteLine($"Este es el nombre de la proteina {Pr.nombre}");
                    Console.WriteLine($"Esta es la cantidad: {Pr.cantidad}");
                }



                Console.ReadKey();

                Console.Clear();


                bool salir = false;
                int opcion = 0;

                while (!salir)
                {
                    Console.WriteLine("====================");
                    Console.WriteLine("-GESTOR RECETAS UTN-");
                    Console.WriteLine("====================");
                    Console.WriteLine("1- Crear Receta");
                    Console.WriteLine("2- Mostrar Recetas");
                    Console.WriteLine("0- Salir y Guardar");
                    Console.WriteLine("====================");
                    Console.Write("Opcion: ");

                    opcion = int.Parse(Console.ReadLine());

                    Console.Clear();

                    switch (opcion)
                    {
                        case 0:
                            salir = true;
                            Console.WriteLine("Saliendo y guardando...");
                            //Lógica para guardar antes de salir
                            break;
                        case 1:
                            Console.Clear();
                            Receta r = new Receta();
                            Console.WriteLine("-----Crear Receta-----");
                            Console.WriteLine("Ingrese el nombre de la receta:");
                            r.nombre = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("-----Crear Receta-----");
                            Console.WriteLine("Ingrese descripcion de la receta:");
                            r.desc = Console.ReadLine();
                            Console.Clear();
                            Console.WriteLine("-----Crear Receta-----");
                            Console.WriteLine("Seleccione la dificultad (0-Baja, 1-Media, 2-Dificil):");
                            int dif = int.Parse(Console.ReadLine());
                            while (dif < 0 || dif > 2)
                            {
                                Console.Clear();
                                Console.WriteLine("-----Crear Receta-----");
                                Console.WriteLine("Dificultad no válida. Ingrese 0, 1 o 2:");
                                dif = int.Parse(Console.ReadLine());
                            }
                            if (dif == 0) r.dificultad = Dificultad.Baja;
                            else if (dif == 1) r.dificultad = Dificultad.Media;
                            else r.dificultad = Dificultad.Dificil;

                            Console.Clear();

                            bool s1 = false;


                            while (!s1)
                            {
                                Console.WriteLine("-----Crear Receta-----");
                                Console.WriteLine("Ingrese el tipo de ingrediente a agregar:");
                                Console.WriteLine("1- Proteina");
                                Console.WriteLine("2- Carbohidrato");
                                Console.WriteLine("3- Vegetal");
                                Console.WriteLine("4- Fruta");
                                Console.WriteLine("5- Lacteo");
                                Console.WriteLine("6- Liquido");
                                Console.WriteLine("0- Salir");

                                if (!int.TryParse(Console.ReadLine(), out int opcIng))
                                {
                                    Console.WriteLine("-----Crear Receta-----");
                                    Console.WriteLine("Entrada no válida. Intente de nuevo.");
                                    continue; // Vuelve al inicio del bucle
                                }


                                switch (opcIng)
                                {
                                    case 0:
                                        s1 = true;
                                        break;
                                    case 1:

                                        break;
                                    case 2:

                                        break;
                                    case 3:

                                        break;
                                    case 4:

                                        break;
                                    case 5:

                                        break;
                                    case 6:

                                        break;
                                    default:
                                        Console.WriteLine("Opción no válida, intente de nuevo.");
                                        break;


                                }
                            }



                            break;
                        case 2:
                            Console.Clear();
                            Console.WriteLine("Mostrar Recetas");
                            //Lógica para mostrar recetas
                            break;                        
                        default:
                            Console.WriteLine("Opción no válida, intente de nuevo.");
                            break;
                    }

                }









            }
        
            catch 
            { 
            
            }
        

        }
    }
}


