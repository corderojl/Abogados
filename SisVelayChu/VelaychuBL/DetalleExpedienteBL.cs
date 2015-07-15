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
        public DetalleExpedienteBE TraerExpediente(int _CodigoDetalleExpediente)
        {
            return _DetalleExpedienteADO.TraerExpediente(_CodigoDetalleExpediente);
        }
        public int InsertarDetalleExpediente(DetalleExpedienteBE _DetalleExpedienteBE)
        {
            return _DetalleExpedienteADO.InsertarDetalleExpediente(_DetalleExpedienteBE);
        }
        public bool ActualizarDetalleExpediente(DetalleExpedienteBE _DetalleExpedienteBE)
        {
            return _DetalleExpedienteADO.ActualizarDetalleExpediente(_DetalleExpedienteBE);
        }

        public bool EliminarDetalleExpediente(int _CodigoDetalle)
        {
            return _DetalleExpedienteADO.EliminarDetalleExpediente(_CodigoDetalle);
        }
    }
}
