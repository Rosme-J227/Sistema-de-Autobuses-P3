using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace Capa_accesoDatos
{
    public class UsuariosDAL
    {
        private DataAccess dataAccess;

        public UsuariosDAL()
        {
            dataAccess = new DataAccess();
        }

        // Listar todos los usuarios (SP)
        public DataTable GetUsuarios()
        {
            return dataAccess.ExecuteReader("sp_GetUsuarios");
        }

        // Listar todos los roles (SP correcto)
        public DataTable GetRoles()
        {
            return dataAccess.ExecuteReader("sp_GetRoles");
        }

        // Insertar un usuario (SP)
        public void InsertUsuario(string nombreUsuario, string contrasena, int rolID)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@NombreUsuario", nombreUsuario),
                new SqlParameter("@Contrasena", contrasena),
                new SqlParameter("@RolID", rolID)
            };
            dataAccess.ExecuteNonQuery("sp_InsertUsuario", parametros);
        }

        // Validar login (SP)
        public DataTable Login(string nombreUsuario, string contrasena)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@NombreUsuario", nombreUsuario),
                new SqlParameter("@Contrasena", contrasena)
            };
            return dataAccess.ExecuteReader("sp_Login", parametros);
        }

        // Actualizar usuario (SP)
        public void UpdateUsuario(int usuarioID, string nombreUsuario, string contrasena, int rolID)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@UsuarioID", usuarioID),
                new SqlParameter("@NombreUsuario", nombreUsuario),
                new SqlParameter("@Contrasena", contrasena),
                new SqlParameter("@RolID", rolID)
            };
            dataAccess.ExecuteNonQuery("sp_UpdateUsuario", parametros);
        }

        // Eliminar usuario (SP)
        public void DeleteUsuario(int usuarioID)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@UsuarioID", usuarioID)
            };
            dataAccess.ExecuteNonQuery("sp_DeleteUsuario", parametros);
        }
    }
}
