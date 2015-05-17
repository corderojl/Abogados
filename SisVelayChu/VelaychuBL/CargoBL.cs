using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class CargoBL
    {
        CargoADO _CargoADO = new CargoADO();


        public DataTable ListarCON_Cargo()
        {
            return _CargoADO.ListarDataTableCargo_All();
        }
        public List<CargoBE> ListarCON_CargoOAct()
        {
            return _CargoADO.ListCargo_All();
        }
    }
}
