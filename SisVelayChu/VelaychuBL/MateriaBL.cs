using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuADO;
using VelaychuBE;

namespace VelaychuBL
{
    public class MateriaBL
    {
        MateriaADO _MateriaADO = new MateriaADO();

        public DataTable ListarDataTableMateria_All()
        {
            return _MateriaADO.ListarDataTableMateria_All();
        }
        public List<MateriaBE> ListMateria_All()
        {
            return _MateriaADO.ListMateria_All();
        }
    }
}
