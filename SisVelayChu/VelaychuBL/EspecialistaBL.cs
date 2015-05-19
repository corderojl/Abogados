using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class EspecialistaBL
    {
        EspecialistaADO _EspecialistaADO = new EspecialistaADO();

        public DataTable ListarDataTableEspecialista_All()
        {
            return _EspecialistaADO.ListarDataTableEspecialista_All();
        }
        public List<EspecialistaBE> ListEspecialista_All()
        {
            return _EspecialistaADO.ListEspecialista_All();
        }
    }
}
