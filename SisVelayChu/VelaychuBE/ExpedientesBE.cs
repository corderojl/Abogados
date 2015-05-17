using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VelaychuBE
{
    public class ExpedientesBE
    {
        public int CodigoExpediente { get; set; }
        public string NumeroExpediente { get; set; }
        public DateTime FechaRegistro { get; set; }
        public int CodigoContrato { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoMateria { get; set; }
        public int CodigoJuzgado { get; set; }
        public int CodigoEspecialista { get; set; }
        public int CodigoSala { get; set; }
        public bool Activo { get; set; }
    }
}
