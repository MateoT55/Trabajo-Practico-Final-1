using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrypto
{
    // 2. Herencia: Clase base abstracta
    public abstract class MonedaBase : IPrecioActualizable
    {
        // 3. Encapsulamiento: Atributos privados con acceso por propiedades
        private string _nombre;
        private string _ticker;
        private double _precioUSDActual;

        public string Nombre
        {
            get => _nombre;
            private set => _nombre = value;
        }

        public string Ticker
        {
            get => _ticker;
            private set => _ticker = value;
        }

        public double PrecioUSDActual
        {
            get => _precioUSDActual;
            // protected: permite a las clases hijas actualizar el precio, pero no a otros
            protected set => _precioUSDActual = value;
        }

        protected MonedaBase(string nombre, string ticker)
        {
            _nombre = nombre;
            _ticker = ticker;
        }

        // 5. Interfaz: Forzado a ser implementado por las clases hijas
        public abstract Task<double> ObtenerPrecioUSD();
    }
}