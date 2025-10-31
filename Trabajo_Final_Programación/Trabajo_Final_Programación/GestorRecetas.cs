using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Trabajo_Final_Programación
{
    internal class GestorRecetas
    {
        private List<Receta> _recetas = new List<Receta>();
        private const string ArchivoRecetas = "recetas.json";





        public List<Receta> coleccionRecetas
        { 
            get { return this._recetas; }
            set { this._recetas = value; }
        }





        public void AgregarReceta(Receta nuevaReceta)
        {
            coleccionRecetas.Add(nuevaReceta);
            GuardarReceta(); // Guarda automáticamente al agregar
        }

        public void GuardarReceta()
        {
            string jsonString = JsonSerializer.Serialize(coleccionRecetas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ArchivoRecetas, jsonString);
        }

        public void CargarReceta()
        {
            if (File.Exists(ArchivoRecetas))
            {
                string jsonString = File.ReadAllText(ArchivoRecetas);
                // Deserialización: convierte el texto JSON a la lista de objetos Receta
                coleccionRecetas = JsonSerializer.Deserialize<List<Receta>>(jsonString);
            }
            else
            {
                coleccionRecetas = new List<Receta>(); // Crea una lista vacía si el archivo no existe
            }
        }

        public List<Receta> ObtenerTodas()
        {
            return coleccionRecetas;
        }
    }
}
