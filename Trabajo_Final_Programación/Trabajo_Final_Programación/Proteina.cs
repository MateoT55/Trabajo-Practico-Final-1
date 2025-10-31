using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Programación
{
    public class Proteina: Ingrediente, ICalcular
    {



        public Proteina()
        {
            this.Nombre = string.Empty;
            this.cantidad = 0;
            this.calorias = 0;
            this.proteina = 0;
            this.carbohidratos = 0;
            this.grasas = 0;
            this.esVegano = false;
            this.aptoCeliaco = false;
        }

        public Proteina(string nombre, double cantidad, double calorias, double proteina, double carbohidratos, double grasas, bool esVegano, bool aptoCeliaco)
        {
            this.Nombre = nombre;
            this.cantidad = cantidad;
            this.calorias = calorias;
            this.proteina = proteina;
            this.carbohidratos = carbohidratos;
            this.grasas = grasas;
            this.esVegano = esVegano;
            this.aptoCeliaco = aptoCeliaco;
        }



        public void ICalcularValorNutricional()
        {
            throw new NotImplementedException();
        }
    }
}
