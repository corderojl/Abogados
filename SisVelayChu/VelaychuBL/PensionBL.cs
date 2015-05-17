using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;


namespace VelaychuBL
{
    public class PensionBL
    {
        PensionADO _PensionADO = new PensionADO();

        public DataTable ListarDataTablePension_All()
        {
            return _PensionADO.ListarDataTablePension_All();
        }
        public List<PensionBE> ListPension_All()
        {
            return _PensionADO.ListPension_All();
        }
    }
}
