﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VelaychuBE
{
    public class DetalleExpedienteBE
    {
        public int CodigoDetalleExpediente { get; set; }
        public int CodigoContrato { get; set; }
        public int CodigoEvento { get; set; }
        public int CodigoEtapa { get; set; }
        public DateTime Fecha { get; set; }
        public string Estado { get; set; }
        public int CodigoUsuario { get; set; }
    }
}