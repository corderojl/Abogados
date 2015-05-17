using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VelaychuBE
{
    public class ContratoBE
    {
        public int CodigoContrato { get; set; }
        public string DescripcionContrato { get; set; }
        public string AbreviaturaContrato { get; set; }
        public decimal Porcentaje { get; set; }
        public bool Activo { get; set; }
    }
}
