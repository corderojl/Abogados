using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class ContratoBL
    {
        ContratoADO _ContratoADO = new ContratoADO();

        public DataTable ListarCON_Contrato()
        {
            return _ContratoADO.ListarDataTableContrato_All();
        }
        public List<ContratoBE> ListarCON_ContratoOAct()
        {
            return _ContratoADO.ListContrato_All();
        }
        public DataTable BuscarContratoByExpediente(int _CodigoExpediente)
        {
            return _ContratoADO.BuscarContratoByExpediente(_CodigoExpediente);
        }
    }
}
