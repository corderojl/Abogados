using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VelaychuBE
{
    public class ClienteBE
    {
        public int CodigoCliente { get; set; }
        public string NombreCompleto { get; set; }
        public int CodigoTipoDocumento { get; set; }
        public int CodigoAsociacion { get; set; }
        public string NombreAsociaccion { get; set; }
        public int CodigoTipoCliente { get; set; }
        public int CodigoGrado { get; set; }
        public string DescripcionGrado { get; set; }
        public int CodigoInstitucion { get; set; }
        public string DescripcionInstitucion { get; set; }
        public int CodigoPension { get; set; }
        public string DescripcionPension { get; set; }
        public string NumeroDocumento { get; set; }
        public string DirecccionCompleta { get; set; }
        public string CodigoDepartamento { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoCelular1 { get; set; }
        public string TelefonoCelular2 { get; set; }
        public string Email { get; set; }
        public bool Activo { get; set; }
    }
}
