using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_DS4
{
    internal class Dueño
    {
        private String _nombre;
        private String _cedula;
        private String _telefono;

        public string Nombre
        {
            get { return _nombre; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El nombre del dueño no puede estar vacío.");
                _nombre = value.Trim();
            }
        }

        public string Cedula
        {
            get { return _cedula; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("La cédula no puede estar vacía.");
                _cedula = value.Trim();
            }
        }

        public string Telefono
        {
            get { return _telefono; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("El teléfono no puede estar vacío.");

                if (value.Trim().Length != 8 || !EsSoloNumeros(value.Trim()))
                    throw new ArgumentException("El teléfono debe tener 8 dígitos numéricos.");

                _telefono = value.Trim();
            }
        }

        public Dueño(string nombre, string cedula, string telefono)
        {
            Nombre = nombre;
            Cedula = cedula;
            Telefono = telefono;
        }

        public string ObtenerDatos()
        {
            return $"Dueño: {Nombre} | Cédula: {Cedula} | Teléfono: {Telefono}";
        }

        private bool EsSoloNumeros(string texto)
        {
            foreach (char c in texto)
            {
                if (!char.IsDigit(c)) return false;
            }
            return true;
        }

    }
}
