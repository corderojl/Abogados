using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class EventoBL
    {
        EventoADO _EventoADO = new EventoADO();

        public DataTable ListarEvento()
        {
            return _EventoADO.ListarDataTableEvento_All();
        }
        public List<EventoBE> ListarEventoObj()
        {
            return _EventoADO.ListEventoObj();
        }
       
    }
}
