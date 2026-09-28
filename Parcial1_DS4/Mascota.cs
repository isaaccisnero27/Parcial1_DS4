using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_DS4
{
    internal class Mascota
    {
        // Un struct
        private Dueño _dueño; 
        private string _nombre;
        private string _tipo;
        private decimal _peso;
        private int _edad;
        private bool _vacunada;
        private bool _bano;
        private bool _desparasitacion;
        private bool _corteUnas;

        public Dueño Dueño
        {
            get { return _dueño; }
            set
            {
                if (value == null)
                    throw new ArgumentException("El dueño no puede ser nulo.");
                _dueño = value;
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre de la mascota no puede estar vacío.");
                _nombre = value.Trim();
            }
        }

        public string Tipo
        {
            get { return _tipo; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El tipo no puede estar vacío.");

                string t = value.Trim();
                if (t != "Perro" && t != "Gato" && t != "Ave" && t != "Reptil")
                    throw new ArgumentException("Tipo inválido. Solo: Perro, Gato, Ave o Reptil.");

                _tipo = t;
            }
        }

        public decimal Peso
        {
            get { return _peso; }
            set
            {
                if (value <= 0 || value > 100)
                    throw new ArgumentOutOfRangeException(nameof(Peso), "El peso debe ser mayor que 0 y hasta 100 kg.");
                _peso = value;
            }
        }

        public int Edad
        {
            get { return _edad; }
            set
            {
                if (value < 0 || value > 30)
                    throw new ArgumentOutOfRangeException(nameof(Edad), "La edad debe estar entre 0 y 30 años.");
                _edad = value;
            }
        }

        public bool Vacunada
        {
            get { return _vacunada; }
            set { _vacunada = value; }
        }

        public bool Bano
        {
            get { return _bano; }
            set { _bano = value; }
        }

        public bool Desparasitacion
        {
            get { return _desparasitacion; }
            set { _desparasitacion = value; }
        }

        public bool CorteUnas
        {
            get { return _corteUnas; }
            set { _corteUnas = value; }
        }

        public Mascota(Dueño dueño, string nombre, string tipo, decimal peso, int edad,
                       bool vacunada, bool bano, bool desparasitacion, bool corteUnas)
        {
            Dueño = dueño;
            Nombre = nombre;
            Tipo = tipo;
            Peso = peso;
            Edad = edad;
            Vacunada = vacunada;
            Bano = bano;
            Desparasitacion = desparasitacion;
            CorteUnas = corteUnas;
        }

        public decimal CalcularConsultaBase()
        {
            switch (Tipo)
            {
                case "Perro": return 25.00m;
                case "Gato": return 20.00m;
                case "Ave": return 15.00m;
                case "Reptil": return 30.00m;
                default: return 0m;
            }
        }

        public decimal CalcularCargoGeriatico()
        {
            if (Edad <= 8) return 0m;
            // No se suman: si pesa más de 20 kg se cobra 25, sino 15
            return (Peso > 20m) ? 25.00m : 15.00m;
        }

        public decimal CalcularVacunacion()
        {
            if (Vacunada) return 0m;

            if (Tipo == "Perro" || Tipo == "Gato") return 35.00m;
            return 20.00m; // Ave o Reptil
        }

        public decimal CalcularServiciosAdicionales()
        {
            decimal total = 0m;
            if (Bano) total += 12.00m;
            if (Desparasitacion) total += 10.00m;
            if (CorteUnas) total += 8.00m;
            return total;
        }

        public decimal CalcularITBMS()
        {
            // ITBMS 7% SOLO sobre servicios adicionales
            return CalcularServiciosAdicionales() * 0.07m;
        }

        public decimal CalcularTotal()
        {
            decimal subtotal = CalcularConsultaBase()
                             + CalcularCargoGeriatico()
                             + CalcularVacunacion()
                             + CalcularServiciosAdicionales();
            return subtotal + CalcularITBMS();
        }
    }
}
