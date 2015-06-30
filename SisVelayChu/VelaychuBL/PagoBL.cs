using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;

namespace VelaychuBL
{
    public class PagoBL
    {
        PagoADO _PagoADO = new PagoADO();

        public DataTable BuscarPagoByClienteExpediente(int _CodigoCliente, int CodigoExpediente)
        {
            return _PagoADO.BuscarPagoByClienteExpediente(_CodigoCliente, CodigoExpediente);
        }
    }
}
