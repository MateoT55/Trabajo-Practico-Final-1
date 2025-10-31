using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Programación
{
    public class IngredienteApi
    {
        
        private List<Proteina> _Proteina = new List<Proteina>();
        private List<Carbohidrato> _Carbohidrato = new List<Carbohidrato>();
        private List<Vegetal> _Vegetal = new List<Vegetal>();
        private List<Fruta> _Fruta = new List<Fruta>();
        private List<Lacteo> _Lacteo = new List<Lacteo>();
        private List<Liquido> _Liquido = new List<Liquido>();
        
        
        public List<Proteina> Proteina
        {
            get { return this._Proteina; }
            set { this._Proteina = value; }
        }
        public List<Carbohidrato> Carbohidrato
        {
            get { return this._Carbohidrato; }
            set { this._Carbohidrato = value; }
        }
        public List<Vegetal> Vegetal
        {
            get { return this._Vegetal; }
            set { this._Vegetal = value; }
        }
        public List<Fruta> Fruta
        {
            get { return this._Fruta; }
            set { this._Fruta = value; }
        }
        public List<Lacteo> Lacteo
        {
            get { return this._Lacteo; }
            set { this._Lacteo = value; }
        }
        public List<Liquido> Liquido
        {
            get { return this._Liquido; }
            set { this._Liquido = value; }
        }
    }
}
