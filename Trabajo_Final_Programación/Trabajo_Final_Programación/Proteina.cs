using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Programación
{
    public enum origen
    { 
        Animal,
        Vegetal
    }
    public class Proteina: Ingrediente, ICalcular
    {
        private origen _origin;






        public void ICalcularValorNutricional()
        {
            throw new NotImplementedException();
        }
    }
}
