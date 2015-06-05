using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class GradoBL
    {
        GradoADO _GradoADO = new GradoADO();

        public DataTable ListarDataTableGrado_All()
        {
            return _GradoADO.ListarDataTableGrado_All();
        }
        public List<GradoBE> ListGrado_All()
        {
            return _GradoADO.ListGrado_All();
        }
        public object BuscaGradoByDescripcion(string _descripcion)
        {
            return _GradoADO.BuscarGradoByDescripcion(_descripcion);
        }

        public int InsertarGrado(GradoBE _GradoBE)
        {
            return _GradoADO.InsertarGrado(_GradoBE);
        }
    }
}
