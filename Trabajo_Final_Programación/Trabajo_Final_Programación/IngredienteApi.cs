using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Programación
{
    public class IngredienteApi
    {
        public List<Proteina> Proteina { get; set; } = new List<Proteina>();
        public List<Carbohidrato> Carbohidrato { get; set; } = new List<Carbohidrato>();
        public List<Vegetal> Vegetal { get; set; } = new List<Vegetal>();
        public List<Fruta> Fruta { get; set; } = new List<Fruta>();
        public List<Lacteo> Lacteo { get; set; } = new List<Lacteo>();
        public List<Liquido> Liquido { get; set; } = new List<Liquido>();
    }
}
