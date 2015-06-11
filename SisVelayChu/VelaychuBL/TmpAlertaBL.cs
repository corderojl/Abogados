using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class TmpAlertaBL
    {
        TmpAlertaADO _TmpAlertaADO = new TmpAlertaADO();

        public List<TmpAlertaBE> TraerAlerta()
        {
            return _TmpAlertaADO.TraerAlerta();
        }
    }
}
