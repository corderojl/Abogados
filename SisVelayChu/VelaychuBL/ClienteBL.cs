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

        public DataTable BuscarClienteByNombres(string _nombres)
        {
            return _ClienteADO.BuscarClienyeByNombres(_nombres);
        }
        public ClienteBE TraerCliente(int _codigo)
        {
            return _ClienteADO.TraerCliente(_codigo);
        }

        public ClienteBE TraerInformacionCliente(int codigoCliente)
        {
            return _ClienteADO.TraerInformacionCliente(codigoCliente);
        }

        public bool DeshabilitarCliente(int _codigo)
        {
            return _ClienteADO.DeshabilitarCliente(_codigo);
        }
        public bool HabilitarCliente(int _codigo)
        {
            return _ClienteADO.HabilitarCliente(_codigo);
        }

        public int InsertarCliente(ClienteBE _ClienteBE)
        {
            return _ClienteADO.InsertarCliente(_ClienteBE);
        }
        public List<ClienteBE> BuscarClienteByExpedienteO(int _codigo)
        {
            return _ClienteADO.BuscarClienteByExpedienteO(_codigo);
        }
        public List<TmpClienteBE> BuscarClienteByNombresO(string _nombres)
        {
            return _ClienteADO.BuscarClienyeByNombresO(_nombres);
        }

        public DataTable BuscarClienteByExpediente(int _CodigoExpediente)
        {
            return _ClienteADO.BuscarClienteByExpediente(_CodigoExpediente);
        }
    }
}
