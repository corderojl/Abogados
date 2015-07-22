using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuBE;
using VelaychuADO;


namespace VelaychuBL
{
    public class ListarExpedientesBL
    {
        ListarExpedienteADO _ListarExpedienteADO = new ListarExpedienteADO();

        public DataTable BuscarExpedienteByNombreCliente(string _nombreCliente)
        {
            return _ListarExpedienteADO.BuscarExpedienteByNombreCliente(_nombreCliente);
        }

        public DataTable BuscarExpedienteByNumeroExpedient(string _NroExpediente)
        {
            return _ListarExpedienteADO.BuscarExpedienteByNumeroExpedient(_NroExpediente);
        }
    }
}
