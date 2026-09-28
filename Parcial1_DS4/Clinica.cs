using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parcial1_DS4
{
    internal class Clinica
    {
        private Mascota[] _atenciones;
        private int _contador;

        public Clinica()
        {
            _atenciones = new Mascota[20];
            _contador = 0;
        }

        public int Contador
        {
            get { return _contador; }
        }

        public Mascota[] Atenciones
        {
            get { return _atenciones; }
        }

        public void Agregar(Mascota mascota)
        {
            if (mascota == null)
                throw new ArgumentException("La mascota no puede ser nula.");

            if (_contador >= 20)
                throw new InvalidOperationException("Cupo lleno. No se pueden registrar más de 20 atenciones.");

            _atenciones[_contador] = mascota;
            _contador++;
        }

        public Mascota BuscarPorCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula)) return null;

            for (int i = 0; i < _contador; i++)
            {
                if (_atenciones[i].Dueño.Cedula == cedula.Trim())
                    return _atenciones[i];
            }
            return null;
        }

        public void Eliminar(string cedula)
        {
            int indice = -1;
            for (int i = 0; i < _contador; i++)
            {
                if (_atenciones[i].Dueño.Cedula == cedula.Trim())
                {
                    indice = i;
                    break;
                }
            }

            if (indice == -1)
                throw new ArgumentException("No se encontró una atención con esa cédula.");

            // Reacomodar el arreglo
            for (int i = indice; i < _contador - 1; i++)
            {
                _atenciones[i] = _atenciones[i + 1];
            }

            _atenciones[_contador - 1] = null;
            _contador--;
        }

        public string ObtenerResumen()
        {
            int perros = 0, gatos = 0, aves = 0, reptiles = 0;
            decimal totalRecaudado = 0m;
            decimal totalItbms = 0m;

            for (int i = 0; i < _contador; i++)
            {
                Mascota m = _atenciones[i];

                switch (m.Tipo)
                {
                    case "Perro": perros++; break;
                    case "Gato": gatos++; break;
                    case "Ave": aves++; break;
                    case "Reptil": reptiles++; break;
                }

                totalRecaudado += m.CalcularTotal();
                totalItbms += m.CalcularITBMS();
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== RESUMEN DEL DÍA ===");
            sb.AppendLine($"Total de atenciones: {_contador}");
            sb.AppendLine($"Perros: {perros}");
            sb.AppendLine($"Gatos: {gatos}");
            sb.AppendLine($"Aves: {aves}");
            sb.AppendLine($"Reptiles: {reptiles}");
            sb.AppendLine($"Total recaudado: {totalRecaudado:C}");
            sb.AppendLine($"ITBMS cobrado: {totalItbms:C}");
            return sb.ToString();
        }
    }
}

