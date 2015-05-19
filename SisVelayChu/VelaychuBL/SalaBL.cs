using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class SalaBL
    {
        SalaADO _SalaADO = new SalaADO();

        public DataTable ListarCON_Sala()
        {
            return _SalaADO.ListarDataTableSala_All();
        }
        public List<SalaBE> ListarCON_SalaOAct()
        {
            return _SalaADO.ListSala_All();
        }
    }
}
