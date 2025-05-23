using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymDev.Shared.Modelos
{
   public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public string Endereco { get; set; }
        public DateTime Fecha_Ncimiento { get; set; }
        public DateTime Fecha_Apertura { get; set; }
        public DateTime Fecha_Vencimiento { get; set; }
        public string Sexo { get; set; }

    }
}
