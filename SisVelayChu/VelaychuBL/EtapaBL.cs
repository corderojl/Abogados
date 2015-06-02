using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class EtapaBL
    {
        EtapaADO _EtapaADO = new EtapaADO();

        public DataTable ListarCON_Etapa()
        {
            return _EtapaADO.ListarDataTableEtapa_All();
        }
        public List<EtapaBE> ListarCON_EtapaAct()
        {
            return _EtapaADO.ListEtapa_All();
        }
        public object BuscaEtapaByDescripcion(string _descripcion)
        {
            return _EtapaADO.BuscarEtapaByDescripcion(_descripcion);
        }
    }
}
