using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VelaychuBE
{
    public class UsuarioBE
    {
        public int CodigoUsuario { get; set; }
        public string NombreCompleto { get; set; }

        public int CodigoTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Email { get; set; }
        public int CodigoCargo { get; set; }
        public int CodigoPerfil { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool Activo { get; set; }

        
    }
}
