using System;
using System.Collections.Generic;
using System.IO.Pipelines;
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
                string urlApi = ($"https://gist.githubusercontent.com/MateoT55/8baf2b48f0832b058cb5be222e7691f4/raw/7ba8248eb0cc22832d7e1b899e503523398759e1/gistfile1.txt");
                Console.WriteLine("Cargando datos de ingredientes desde la API...");

                string datos = await client.GetStringAsync(urlApi);

                GestorRecetas Colrec = new GestorRecetas();

                Ing = JsonSerializer.Deserialize<Ingrediente>(datos);

                IngredienteApi apiData = JsonSerializer.Deserialize<IngredienteApi>(datos);
                Console.WriteLine("Datos cargados correctamente.");

                Console.ReadKey();

                Console.Clear();


                bool salir = false;
                int opcion = 0;

                while (!salir)
                {
                    Console.Clear();
                    Console.WriteLine("====================");
                    Console.WriteLine("-GESTOR RECETAS UTN-");
                    Console.WriteLine("====================");
                    Console.WriteLine("1- Crear Receta");
                    Console.WriteLine("2- Mostrar Recetas");
                    Console.WriteLine("3. Eliminar TODAS las Recetas");
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
                                Console.Clear();
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
                                    continue;
                                }

                                string eleccion = string.Empty;
                                int opeleccion = 0;
                                int cantIng = 0;

                                if (opcIng == 1)
                                {
                                    for (int i = 0; i < apiData.Proteina.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}- {apiData.Proteina[i].nombre} son 100 gramos cada unidad");
                                    }
                                    Console.WriteLine("Elegir ingrediente: ");
                                    eleccion = Console.ReadLine();

                                    Console.WriteLine("Elegir cantidad (unidad)");
                                    cantIng = int.Parse(Console.ReadLine());

                                    if (int.TryParse(eleccion, out opeleccion) && opeleccion > 0 && opeleccion <= apiData.Proteina.Count)
                                    {

                                        Ingrediente baseIng = apiData.Proteina[opeleccion - 1];
                                        Ingrediente nuevoIng = new Ingrediente(
                                            baseIng.nombre,
                                            cantIng,
                                            baseIng.calorias,
                                            baseIng.proteina,
                                            baseIng.carbohidratos,
                                            baseIng.grasas,
                                            baseIng.esVegano,
                                            baseIng.aptoCeliaco);


                                        r.ingrediente.Add(nuevoIng);
                                        Console.WriteLine($"Agregado nuevo ingrediente: {nuevoIng.nombre}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Selección no válida.");
                                    }

                                }
                                else if (opcIng == 2)
                                {
                                    for (int i = 0; i < apiData.Carbohidrato.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}- {apiData.Carbohidrato[i].nombre} son 100 gramos cada unidad");
                                    }
                                    Console.WriteLine("Elegir ingrediente: ");
                                    eleccion = Console.ReadLine();

                                    Console.WriteLine("Elegir cantidad (unidad)");
                                    cantIng = int.Parse(Console.ReadLine());
                                    if (int.TryParse(eleccion, out opeleccion) && opeleccion > 0 && opeleccion <= apiData.Carbohidrato.Count)
                                    {

                                        Ingrediente baseIng = apiData.Carbohidrato[opeleccion - 1];
                                        Ingrediente nuevoIng = new Ingrediente(
                                            baseIng.nombre,
                                            cantIng,
                                            baseIng.calorias,
                                            baseIng.proteina,
                                            baseIng.carbohidratos,
                                            baseIng.grasas,
                                            baseIng.esVegano,
                                            baseIng.aptoCeliaco);


                                        r.ingrediente.Add(nuevoIng);
                                        Console.WriteLine($"Agregado nuevo ingrediente: {nuevoIng.nombre}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Selección no válida.");
                                    }

                                }
                                else if (opcIng == 3)
                                {
                                    for (int i = 0; i < apiData.Vegetal.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}- {apiData.Vegetal[i].nombre} son 100 gramos cada unidad");
                                    }
                                    Console.WriteLine("Elegir ingrediente: ");
                                    eleccion = Console.ReadLine();

                                    Console.WriteLine("Elegir cantidad (unidad)");
                                    cantIng = int.Parse(Console.ReadLine());
                                    if (int.TryParse(eleccion, out opeleccion) && opeleccion > 0 && opeleccion <= apiData.Vegetal.Count)
                                    {

                                        Ingrediente baseIng = apiData.Vegetal[opeleccion - 1];
                                        Ingrediente nuevoIng = new Ingrediente(
                                            baseIng.nombre,
                                            cantIng,
                                            baseIng.calorias,
                                            baseIng.proteina,
                                            baseIng.carbohidratos,
                                            baseIng.grasas,
                                            baseIng.esVegano,
                                            baseIng.aptoCeliaco);


                                        r.ingrediente.Add(nuevoIng);
                                        Console.WriteLine($"Agregado nuevo ingrediente: {nuevoIng.nombre}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Selección no válida.");
                                    }


                                }
                                else if (opcIng == 4)
                                {
                                    for (int i = 0; i < apiData.Fruta.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}- {apiData.Fruta[i].nombre} son 100 gramos cada unidad");
                                    }
                                    Console.WriteLine("Elegir ingrediente: ");
                                    eleccion = Console.ReadLine();

                                    Console.WriteLine("Elegir cantidad (unidad)");
                                    cantIng = int.Parse(Console.ReadLine());
                                    if (int.TryParse(eleccion, out opeleccion) && opeleccion > 0 && opeleccion <= apiData.Fruta.Count)
                                    {

                                        Ingrediente baseIng = apiData.Fruta[opeleccion - 1];
                                        Ingrediente nuevoIng = new Ingrediente(
                                            baseIng.nombre,
                                            cantIng,
                                            baseIng.calorias,
                                            baseIng.proteina,
                                            baseIng.carbohidratos,
                                            baseIng.grasas,
                                            baseIng.esVegano,
                                            baseIng.aptoCeliaco);


                                        r.ingrediente.Add(nuevoIng);
                                        Console.WriteLine($"Agregado nuevo ingrediente: {nuevoIng.nombre}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Selección no válida.");
                                    }


                                }
                                else if (opcIng == 5)
                                {
                                    for (int i = 0; i < apiData.Lacteo.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}- {apiData.Lacteo[i].nombre} son 100 gramos cada unidad");
                                    }
                                    Console.WriteLine("Elegir ingrediente: ");
                                    eleccion = Console.ReadLine();

                                    Console.WriteLine("Elegir cantidad (unidad)");
                                    cantIng = int.Parse(Console.ReadLine());
                                    if (int.TryParse(eleccion, out opeleccion) && opeleccion > 0 && opeleccion <= apiData.Lacteo.Count)
                                    {

                                        Ingrediente baseIng = apiData.Lacteo[opeleccion - 1];
                                        Ingrediente nuevoIng = new Ingrediente(
                                            baseIng.nombre,
                                            cantIng,
                                            baseIng.calorias,
                                            baseIng.proteina,
                                            baseIng.carbohidratos,
                                            baseIng.grasas,
                                            baseIng.esVegano,
                                            baseIng.aptoCeliaco);


                                        r.ingrediente.Add(nuevoIng);
                                        Console.WriteLine($"Agregado nuevo ingrediente: {nuevoIng.nombre}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Selección no válida.");
                                    }


                                }
                                else if (opcIng == 6)
                                {
                                    for (int i = 0; i < apiData.Liquido.Count; i++)
                                    {
                                        Console.WriteLine($"{i + 1}- {apiData.Liquido[i].nombre} son 100 gramos cada unidad");
                                    }
                                    Console.WriteLine("Elegir ingrediente: ");
                                    eleccion = Console.ReadLine();

                                    Console.WriteLine("Elegir cantidad (unidad)");
                                    cantIng = int.Parse(Console.ReadLine());
                                    if (int.TryParse(eleccion, out opeleccion) && opeleccion > 0 && opeleccion <= apiData.Liquido.Count)
                                    {

                                        Ingrediente baseIng = apiData.Liquido[opeleccion - 1];
                                        Ingrediente nuevoIng = new Ingrediente(
                                            baseIng.nombre,
                                            cantIng,
                                            baseIng.calorias,
                                            baseIng.proteina,
                                            baseIng.carbohidratos,
                                            baseIng.grasas,
                                            baseIng.esVegano,
                                            baseIng.aptoCeliaco);


                                        r.ingrediente.Add(nuevoIng);
                                        Console.WriteLine($"Agregado nuevo ingrediente: {nuevoIng.nombre}");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Selección no válida.");
                                    }


                                }

                                else if (opcIng == 0)
                                {
                                    Console.Clear();
                                    Console.WriteLine("Quieres guardar la receta? (S/N)");
                                    string opgre = Console.ReadLine().ToUpper();
                                    if (opgre == "S")
                                    {
                                        Colrec.AgregarReceta(r); 
                                        Console.WriteLine($"Receta '{r.nombre}' creada y guardada en recetas.json.");

                                        s1 = true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Saliendo sin guardar receta...");
                                        Thread.Sleep(2000);
                                        s1 = true;
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("Opción no válida, intente de nuevo.");
                                }
                            }
                            break;


                        case 2:
                            Console.Clear();
                            Console.WriteLine("     MOSTRAR RECETAS    ");
                            Console.WriteLine($"============================");
                            List<Receta> recetasGuardadas = Colrec.ObtenerTodas();
                            if (recetasGuardadas.Count == 0)
                            {
                                Console.WriteLine("No hay recetas guardadas en el sistema.");
                            }
                            else
                            {
                                foreach (Receta re in recetasGuardadas)
                                {
                                    ValorNutricional valTotal = re.ICalcularValorNutricional();
                                    Console.WriteLine($"============================");
                                    Console.WriteLine($"\n Nombre: {re.nombre}");
                                    Console.WriteLine($"\n Descripcion: {re.desc}");
                                    Console.WriteLine($"\n Dificultad: {re.dificultad}");



                                    Console.WriteLine($"\n Calorias Totales: {valTotal.caloriasTotal}");
                                    Console.WriteLine($"\n Proteinas Totales: {valTotal.proteinaTotal}");
                                    Console.WriteLine($"\n Carbohidratos Totales: {valTotal.carbohidratosTotal}");
                                    Console.WriteLine($"\n Grasas Totales: {valTotal.grasasTotal}");


                                    Console.WriteLine("");
                                    for (int a = 0; a < re.ingrediente.Count; a++)
                                    {
                                        Console.Write($"Ingredientes: {re.ingrediente[a].nombre} - Cantidad: {re.ingrediente[a].cantidad} || ");
                                    }
                                    Console.WriteLine("");
                                    Console.WriteLine($"============================");
                                }
                            }
                            Console.ReadKey();
                                break;

                        case 3:
                            Console.WriteLine("¿Está seguro que desea ELIMINAR TODAS las recetas guardadas? (S/N)");
                            string confirmacion = Console.ReadLine().ToUpper();

                            if (confirmacion == "S")
                            {
                                if (Colrec.EliminarColeccion())
                                {
                                    Console.WriteLine("Colección de recetas eliminada exitosamente");
                                }
                                else
                                {
                                    Console.WriteLine("No se encontró el archivo de recetas, o hubo un error al borrar.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Operación de eliminación cancelada.");
                            }
                            break;
                        default:
                            Console.WriteLine("Opción no válida, intente de nuevo.");
                            break;
                    }

                }

            }
        
            catch (Exception ex)
            {
                Console.WriteLine($"Ocurrio un error...{ex.Message}");
            }
        

        }
    }
}


