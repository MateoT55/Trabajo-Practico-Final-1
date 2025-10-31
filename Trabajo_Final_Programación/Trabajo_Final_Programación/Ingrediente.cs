using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trabajo_Final_Programación
{
    public class Ingrediente
    {
        private string _Nombre;
        private double _cantidad;
        private double _calorias;
        private double _proteina;
        private double _carbohidratos;
        private double _grasas;
        private bool _esVegano;
        private bool _aptoCeliaco;



        public Ingrediente()
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

        public Ingrediente(string nombre, double cantidad, double calorias, double proteina, double carbohidratos, double grasas, bool esVegano, bool aptoCeliaco)
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

        public string Nombre
        {
            get { return this._Nombre; }
            set { this._Nombre = value; }
        }

        public double cantidad
        {
            get { return this._cantidad; }
            set { this._cantidad = value; }
        }
        public double calorias
        {
            get { return this._calorias; }
            set { this._calorias = value; }
        }
        public double proteina
        {
            get { return this._proteina; }
            set { this._proteina = value; }
        }
        public double carbohidratos
        {
            get { return this._carbohidratos; }
            set { this._carbohidratos = value; }
        }
        public double grasas
        {
            get { return this._grasas; }
            set { this._grasas = value; }
        }


        public bool esVegano
        {
            get { return this._esVegano; }
            set { this._esVegano = value; }
        }

        public bool aptoCeliaco
        {
            get { return this._aptoCeliaco; }
            set { this._aptoCeliaco = value; }
        }
    }
}
