using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_accesoDatos
{
    public class ChoferesDAL
    {
        private DataAccess dataAccess;

        public ChoferesDAL()
        {
            dataAccess = new DataAccess();
        }

        public DataTable GetChoferes()
        {
            return dataAccess.ExecuteReader("sp_GetChoferes");
        }

        public void InsertChofer(string nombre, string apellido, DateTime fechaNacimiento, string cedula)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Apellido", apellido),
                new SqlParameter("@FechaNacimiento", fechaNacimiento),
                new SqlParameter("@Cedula", cedula)
            };
            dataAccess.ExecuteNonQuery("sp_InsertChofer", parametros);
        }

        public void UpdateChofer(int choferID, string nombre, string apellido, DateTime fechaNacimiento, string cedula)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@ChoferID", choferID),
                new SqlParameter("@Nombre", nombre),
                new SqlParameter("@Apellido", apellido),
                new SqlParameter("@FechaNacimiento", fechaNacimiento),
                new SqlParameter("@Cedula", cedula)
            };
            dataAccess.ExecuteNonQuery("sp_UpdateChofer", parametros);
        }

        public void DeleteChofer(int choferID)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@ChoferID", choferID)
            };
            dataAccess.ExecuteNonQuery("sp_DeleteChofer", parametros);
        }
    }
}

