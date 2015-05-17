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

        public DataTable ListarUsuario_All()
        {
            return _ClienteADO.ListarDataTableCliente_All();
        }

        public List<ClienteBE> ListarUsuarioO_Act()
        {
            return _ClienteADO.ListCliente_All();
        }

        public object BuscarClienteByNombres(string _nombres)
        {
            return _ClienteADO.BuscarClienyeByNombres(_nombres);
        }
    }
}
