using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class TipoClienteBL
    {
        TipoClienteADO _TipoClienteADO = new TipoClienteADO();

        public DataTable ListarDataTableTipoCliente_All()
        {
            return _TipoClienteADO.ListarDataTableTipoCliente_All();
        }
        public List<TipoClienteBE> ListTipoCliente_All()
        {
            return _TipoClienteADO.ListTipoCliente_All();
        }
        public object BuscaTipoClienteByDescripcion(string _descripcion)
        {
            return _TipoClienteADO.BuscarTipoClienteByDescripcion(_descripcion);
        }
    }
}
