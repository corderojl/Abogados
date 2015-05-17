using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class PerfilBL
    {
        PerfilADO _PerfilADO = new PerfilADO();


        public DataTable ListarDataTablePerfil_All()
        {
            return _PerfilADO.ListarDataTablePerfil_All();
        }
        public List<PerfilBE> ListPerfil_All()
        {
            return _PerfilADO.ListPerfil_All();
        }
    }
}
