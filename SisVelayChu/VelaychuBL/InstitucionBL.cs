using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;


namespace VelaychuBL
{
    public class InstitucionBL
    {
        InstitucionADO _InstitucionADO = new InstitucionADO();

        public DataTable ListarDataTableInstitucion_All()
        {
            return _InstitucionADO.ListarDataTableInstitucion_All();
        }
        public List<InstitucionBE> ListInstitucion_All()
        {
            return _InstitucionADO.ListInstitucion_All();
        }
    }
}
