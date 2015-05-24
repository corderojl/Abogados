using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class ExpedienteBL
    {
        ExpedienteADO _ExpedienteADO = new ExpedienteADO();

        public DataTable ListarUsuario_All()
        {
            return _ExpedienteADO.ListarDataTableExpediente_All();
        }
        public List<ExpedientesBE> ListarUsuarioO_Act()
        {
            return _ExpedienteADO.ListExpediente_All();
        }
        public DataTable BuscarExpedienteByCliente(int _CodigoCliente)
        {
            return _ExpedienteADO.BuscarExpedienteByCliente(_CodigoCliente);
        }
        public ExpedientesBE TraerExpediente(int _codigo)
        {
            return _ExpedienteADO.TraerExpediente(_codigo);
        }
        public int InsertarExpedientes(ExpedientesBE _ExpedientesBE)
        {
            return _ExpedienteADO.InsertarExpedientes(_ExpedientesBE);
        }
        public bool ActualizarExpedientes(ExpedientesBE _ExpedientesBE)
        {
            return _ExpedienteADO.ActualizarExpedientes(_ExpedientesBE);
        }
    }
}
