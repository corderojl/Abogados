using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
   public class JuzgadoBL
    {
        JuzgadoADO _JuzgadoADO = new JuzgadoADO();

        public DataTable ListarDataTableJuzgado_All()
        {
            return _JuzgadoADO.ListarDataTableJuzgado_All();
        }
        public List<JuzgadoBE> ListJuzgado_All()
        {
            return _JuzgadoADO.ListJuzgado_All();
        }
    }
}
