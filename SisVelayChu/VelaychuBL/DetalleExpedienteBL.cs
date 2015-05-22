using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class DetalleExpedienteBL
    {
        DetalleExpedienteADO _DetalleExpedienteADO = new DetalleExpedienteADO();

        public DataTable ListarCON_DetalleExpediente()
        {
            return _DetalleExpedienteADO.ListarDataTableDetalleExpediente_All();
        }
        public List<DetalleExpedienteBE> ListarCON_DetalleExpedienteOAct()
        {
            return _DetalleExpedienteADO.ListDetalleExpediente_All();
        }
        public DataTable ListarDetalleExpedienteByContrato(int _CodigoContrato)
        {
            return _DetalleExpedienteADO.ListarDetalleExpedienteByContrato(_CodigoContrato);
        }
    }
}
