using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class AsociacionBL
    {
        AsociacionADO _AsociacionADO = new AsociacionADO();

        public DataTable ListarDataTableAsociacon_All()
        {
            return _AsociacionADO.ListarDataTableAsociacion_All();
        }
        public List<AsociacionBE> ListAsociacion_All()
        {
            return _AsociacionADO.ListAsociacion_All();
        }

        public object BuscarAsociacionByDescripcion(string _descripcion)
        {
            return _AsociacionADO.BuscarAsociacionByDescripcion(_descripcion);
        }
    }
}
