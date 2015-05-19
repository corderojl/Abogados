using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class DocumentoBL
    {
        DocumentoADO _DocumentoADO = new DocumentoADO();

        public DataTable ListarCON_Documento()
        {
            return _DocumentoADO.ListarDataTableDocumento_All();
        }
        public List<DocumentoBE> ListarCON_DocumentoOAct()
        {
            return _DocumentoADO.ListDocumento_All();
        }
        public DataTable ListarDocumentoByContrato(int _CodigoContrato)
        {
            return _DocumentoADO.ListarDocumentoByContrato(_CodigoContrato);
        }
    }
}
