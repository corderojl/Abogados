using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class DepartamentoBL
    {
        DepartamentoADO _DepartamentoADO = new DepartamentoADO();

        public DataTable ListarCON_Departamento()
        {
            return _DepartamentoADO.ListarDataTableDepartamento_All();
        }
        public List<DepartamentoBE> ListarCON_DepartamentoOAct()
        {
            return _DepartamentoADO.ListDepartamento_All();
        }
        //public DataTable BuscarDepartamentoByExpediente(int _CodigoExpediente)
        //{
        //    return _DepartamentoADO.BuscarDepartamentoByExpediente(_CodigoExpediente);
        //}
    }
}
