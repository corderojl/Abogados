using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using VelaychuBE;
using VelaychuADO;

namespace VelaychuBL
{
    public class UsuarioBL
    {
        UsuarioADO _UsuarioADO = new UsuarioADO();

        public DataTable ListarUsuario_All()
        {
            return _UsuarioADO.ListarUsuario_All();
        }
        public DataTable ListarUsuario_Act()
        {
            return _UsuarioADO.ListarUsuario_Act();
        }
        public List<UsuarioBE> ListarUsuarioO_Act()
        {
            return _UsuarioADO.ListarUsuarioO_Act();
        }
        public UsuarioBE LoguearUsuario(string _Usuario, string _Password)
        {
            return _UsuarioADO.LoguearUsuario(_Usuario, _Password);
        }
        public UsuarioBE TraerFnc_Usuario(int _Usuario_id)
        {
            return _UsuarioADO.TraerUsuario(_Usuario_id);
        }

        public object BuscarUsuarioByNombres(string _nombres)
        {
            return _UsuarioADO.BuscarUsuarioByNombres(_nombres);
        }

        public int InsertarUsuario(UsuarioBE _UsuarioBE)
        {
            return _UsuarioADO.InsertarUsuario(_UsuarioBE);
        }

        public bool ActualizarUsuario(UsuarioBE _UsuarioBE)
        {
            return _UsuarioADO.ActualizarUsuario(_UsuarioBE);
        }

        public bool DeshabilitarUsuario(int vcod)
        {
            return _UsuarioADO.DeshabilitarUsuario(vcod);
        }
    }
}
