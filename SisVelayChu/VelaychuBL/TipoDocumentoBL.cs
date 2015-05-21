using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class TipoDocumentoBL
    {
        TipoDocumentoADO _TipoDocumentoADO = new TipoDocumentoADO();


        public DataTable ListarDataTableTipoDocumento_All()
        {
            return _TipoDocumentoADO.ListarDataTableTipoDocumento_All();
        }
        public List<TipoDocumentoBE> ListTipoDocumento_All()
        {
            return _TipoDocumentoADO.ListTipoDocumento_All();
        }
        public object BuscaTipoDocumentoByDescripcion(string _descripcion)
        {
            return _TipoDocumentoADO.BuscarTipoDocumentoByDescripcion(_descripcion);
        }
       
    }
}
