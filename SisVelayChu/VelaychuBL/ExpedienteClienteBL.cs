using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class ExpedienteClienteBL
    {
        ExpedienteClienteADO _ExpedienteClienteADO = new ExpedienteClienteADO();

        public DataTable ListarUsuario_All()
        {
            return _ExpedienteClienteADO.ListarDataTableExpedienteCliente_All();
        }
        public List<ExpedienteClienteBE> ListarUsuarioO_Act()
        {
            return _ExpedienteClienteADO.ListExpedienteCliente_All();
        }
        public int InsertarExpedienteClientes(ExpedienteClienteBE _ExpedienteClienteBE)
        {
            return _ExpedienteClienteADO.InsertarExpedienteCliente(_ExpedienteClienteBE);
        }
        public int InsertarExpedienteClientes(List<ExpedienteClienteBE> ltExpedienteClientesBE)
        {
            return _ExpedienteClienteADO.InsertarExpedienteCliente(ltExpedienteClientesBE);
        }
    }
}
