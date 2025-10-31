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

        public GestorRecetas()
        {
            CargarReceta();
        }
        public List<Receta> coleccionRecetas
        { 
            get { return this._recetas; }
            set { this._recetas = value; }
        }

        public bool EliminarColeccion()
        {
            try
            {
                if (File.Exists(ArchivoRecetas))
                {
                    File.Delete(ArchivoRecetas); 
                    _recetas = new List<Receta>(); 
                    return true;
                }
                return false; 
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al intentar eliminar el archivo: {ex.Message}");
                return false;
            }
        }
        public void GuardarReceta()
        {
            string jsonString = JsonSerializer.Serialize(coleccionRecetas, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(ArchivoRecetas, jsonString);
        }

        public void AgregarReceta(Receta nuevaReceta)
        {
            coleccionRecetas.Add(nuevaReceta);
            GuardarReceta(); 
        }

        public void CargarReceta()
        {
            if (File.Exists(ArchivoRecetas))
            {
                string jsonString = File.ReadAllText(ArchivoRecetas);
                coleccionRecetas = JsonSerializer.Deserialize<List<Receta>>(jsonString);
            }
            else
            {
                coleccionRecetas = new List<Receta>(); 
            }
        }

        public List<Receta> ObtenerTodas()
        {
            return coleccionRecetas;
        }
    }
}
