using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuBE;
using VelaychuADO;

namespace VelaychuBL
{
    public class ClienteBL
    {
        ClienteADO _ClienteADO = new ClienteADO();

        public DataTable ListarCliente_All()
        {
            return _ClienteADO.ListarDataTableCliente_All();
        }

        public List<ClienteBE> ListarClienteO_Act()
        {
            return _ClienteADO.ListCliente_All();
        }

        public object BuscarClienteByNombres(string _nombres)
        {
            return _ClienteADO.BuscarClienyeByNombres(_nombres);
        }
        public ClienteBE TraerCliente(int _codigo)
        {
            return _ClienteADO.TraerCliente(_codigo);
        }
        public bool DeshabilitarCliente(int _codigo)
        {
            return _ClienteADO.DeshabilitarCliente(_codigo);
        }
        public bool HabilitarCliente(int _codigo)
        {
            return _ClienteADO.HabilitarCliente(_codigo);
        }
    }
}
