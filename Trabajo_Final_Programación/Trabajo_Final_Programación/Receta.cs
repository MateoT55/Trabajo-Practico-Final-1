using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Programación
{
    public enum Dificultad
    { 
        Baja,
        Media,
        Dificil
    }

    public class Receta: Ingrediente, ICalcular
    {
        private string _nombre;
        private string _desc;
        private Dificultad _dificultad;
        private List<Ingrediente> _ingrediente;

        
        public Receta()
        {
            this.nombre = string.Empty;
            this.desc = string.Empty;
            this.dificultad = Dificultad.Baja;
            this.ingrediente = new List<Ingrediente>();
        }

        public Receta(string nombre, string desc, Dificultad dificultad, List<Ingrediente> ingrediente)
        {
            this.nombre = nombre;
            this.desc = desc;
            this.dificultad = dificultad;
            this.ingrediente = ingrediente;
        }

        public string nombre
        {
            get { return this._nombre; }
            set { this._nombre = value; }
        }

        public string desc
        {
            get { return this._desc; }
            set { this._desc = value; }
        }

        public Dificultad dificultad
        {
            get { return this._dificultad; }
            set { this._dificultad = value; }
        }

        public List<Ingrediente> ingrediente
        {
            get { return this._ingrediente; }
            set { this._ingrediente = value; }
        }



        public ValorNutricional ICalcularValorNutricional()
        {
            ValorNutricional valretotal = new ValorNutricional();
            foreach (Ingrediente ing in ingrediente)
            { 
                ValorNutricional valreing = ing.ICalcularValorNutricional();
                valretotal.caloriasTotal += valreing.caloriasTotal;
                valretotal.proteinaTotal += valreing.proteinaTotal;
                valretotal.carbohidratosTotal += valreing.carbohidratosTotal;
                valretotal.grasasTotal += valreing.grasasTotal;

            }
            return valretotal;
        }
    }
}
