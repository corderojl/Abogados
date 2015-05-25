using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;

namespace VelaychuBL
{
    public class DocumentoClienteBL
    {
        DocumentoClienteADO _DocumentoClienteADO = new DocumentoClienteADO();

        public DataTable BuscarDocumentoClienteByExpedienteContrato(int _CodigoExpedienteContrato)
        {
            return _DocumentoClienteADO.BuscarDocumentoClienteByExpedienteContrato(_CodigoExpedienteContrato);
        }
    }
}
