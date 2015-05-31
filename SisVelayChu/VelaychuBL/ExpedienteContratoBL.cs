using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class ExpedienteContratoBL
    {
        ExpedienteContratoADO _ExpedienteContratoADO = new ExpedienteContratoADO();

        public int InsertarExpedienteContrato(ExpedienteContratoBE _ExpedienteContratoBE)
        {
           return _ExpedienteContratoADO.InsertarExpedienteContrato(_ExpedienteContratoBE);
        }

        public bool EliminarExpedienteContrato(int _CodigoExpedienteContrato)
        {
            return _ExpedienteContratoADO.EliminarExpedienteContrato(_CodigoExpedienteContrato);
        }
    }
}
