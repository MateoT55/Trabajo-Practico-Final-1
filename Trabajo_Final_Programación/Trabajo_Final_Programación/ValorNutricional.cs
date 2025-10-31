using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Programación
{
    public class ValorNutricional
    {
        private double _caloriasTotal;
        private double _proteinaTotal;
        private double _carbohidratosTotal;
        private double _grasasTotal;

        public ValorNutricional()
        {
            this.caloriasTotal = 0;
            this.proteinaTotal = 0;
            this.carbohidratosTotal = 0;
            this.grasasTotal = 0;

        }

        public ValorNutricional(double caloriasTotal, double proteinaTotal, double carbohidratosTotal, double grasasTotal)
        {
            this.caloriasTotal = caloriasTotal;
            this.proteinaTotal = proteinaTotal;
            this.carbohidratosTotal = carbohidratosTotal;
            this.grasasTotal = grasasTotal;
        }

        public double caloriasTotal
        {
            get { return _caloriasTotal; }
            set { _caloriasTotal = value; }
        }

        public double proteinaTotal
        {
            get { return _proteinaTotal; }
            set { _proteinaTotal = value; }
        }

        public double carbohidratosTotal
        {
            get { return _carbohidratosTotal; }
            set { _carbohidratosTotal = value; }
        }

        public double grasasTotal
        {
            get { return _grasasTotal; }
            set { _grasasTotal = value; }
        }


    }
}
