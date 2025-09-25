using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_accesoDatos;



namespace Capa_negocio
{
    public class UsuariosBL
    {
        private static UsuariosBL instancia;
        private readonly UsuariosDAL usuarioDAL;

        private UsuariosBL()
        {
            usuarioDAL = new UsuariosDAL();
        }

        public static UsuariosBL Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new UsuariosBL();
                return instancia;
            }
        }

        public DataTable ListarUsuarios()
        {
            return usuarioDAL.GetUsuarios();
        }

        public DataTable ListarRoles()
        {
            return usuarioDAL.GetRoles();
        }

        public void AgregarUsuario(string nombreUsuario, string contrasena, int rolID)
        {
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
                throw new Exception("Usuario y contraseña son obligatorios.");
            if (rolID <= 0)
                throw new Exception("Debe seleccionar un rol.");

            usuarioDAL.InsertUsuario(nombreUsuario, contrasena, rolID);
        }

        public DataTable ValidarLogin(string nombreUsuario, string contrasena)
        {
            return usuarioDAL.Login(nombreUsuario, contrasena);
        }

        public void ModificarUsuario(int usuarioID, string nombreUsuario, string contrasena, int rolID)
        {
            if (usuarioID <= 0) throw new Exception("UsuarioID inválido.");
            if (string.IsNullOrWhiteSpace(nombreUsuario) || string.IsNullOrWhiteSpace(contrasena))
                throw new Exception("Usuario y contraseña son obligatorios.");
            if (rolID <= 0)
                throw new Exception("Debe seleccionar un rol.");

            usuarioDAL.UpdateUsuario(usuarioID, nombreUsuario, contrasena, rolID);
        }

        public void EliminarUsuario(int usuarioID)
        {
            if (usuarioID <= 0) throw new Exception("UsuarioID inválido.");
            usuarioDAL.DeleteUsuario(usuarioID);
        }
    }
}
