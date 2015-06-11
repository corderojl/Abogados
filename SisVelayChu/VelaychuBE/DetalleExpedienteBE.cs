using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VelaychuBE
{
    public class DetalleExpedienteBE
    {
        public int CodigoDetalleExpediente { get; set; }
        public int CodigoExpedienteContrato { get; set; }
        public int CodigoEvento { get; set; }
        public int CodigoEtapa { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int CodigoUsuario { get; set; }
        public DateTime FechaImpulso { get; set; }
        public int CodigoUsuarioImpulso { get; set; }
        public int DiasAlerta { get; set; }
        
    }
}
