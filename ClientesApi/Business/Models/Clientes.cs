using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
   public class Clientes
    {
        public int idCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string CUIT { get; set; }
        public string Domicilio { get; set; }
        public string telefonoCelular { get; set; }
        public string email { get; set; }
    }
}
