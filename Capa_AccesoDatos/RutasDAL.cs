using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_accesoDatos
{
    public class RutasDAL
    {
        private DataAccess dataAccess;

        public RutasDAL()
        {
            dataAccess = new DataAccess();
        }

        public DataTable GetRutas()
        {
            return dataAccess.ExecuteReader("sp_GetRutas");
        }

        public void InsertRuta(string nombre)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@Nombre", nombre)
            };
            dataAccess.ExecuteNonQuery("sp_InsertRuta", parametros);
        }

        public void UpdateRuta(int rutaID, string nombre)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@RutaID", rutaID),
                new SqlParameter("@Nombre", nombre)
            };
            dataAccess.ExecuteNonQuery("sp_UpdateRuta", parametros);
        }

        public void DeleteRuta(int rutaID)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@RutaID", rutaID)
            };
            dataAccess.ExecuteNonQuery("sp_DeleteRuta", parametros);
        }
    }
}
