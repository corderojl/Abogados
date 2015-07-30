using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VelaychuBE
{
    public class PagoBE
    {
        public int CodigoPago { get; set; }
        public int CodigoExpediente { get; set; }
        public int CodigoCliente { get; set; }
        public int CodigoContrato { get; set; }
        public float Porcentaje { get; set; }
        public decimal Monto { get; set; }
        public bool Activo { get; set; }
    }
}
