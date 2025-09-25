using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace Capa_accesoDatos
{
    public class AutobusesDAL
    {
        private DataAccess dataAccess;

        public AutobusesDAL()
        {
            dataAccess = new DataAccess();
        }

        public DataTable GetAutobuses()
        {
            return dataAccess.ExecuteReader("sp_GetAutobuses");
        }

        public void InsertAutobus(string marca, string modelo, string placa, string color, int ano)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@Marca", marca),
                new SqlParameter("@Modelo", modelo),
                new SqlParameter("@Placa", placa),
                new SqlParameter("@Color", color),
                new SqlParameter("@Ano", ano)
            };
            dataAccess.ExecuteNonQuery("sp_InsertAutobus", parametros);
        }

        public void UpdateAutobus(int autobusID, string marca, string modelo, string placa, string color, int ano)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@AutobusID", autobusID),
                new SqlParameter("@Marca", marca),
                new SqlParameter("@Modelo", modelo),
                new SqlParameter("@Placa", placa),
                new SqlParameter("@Color", color),
                new SqlParameter("@Ano", ano)
            };
            dataAccess.ExecuteNonQuery("sp_UpdateAutobus", parametros);
        }

        public void DeleteAutobus(int autobusID)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@AutobusID", autobusID)
            };
            dataAccess.ExecuteNonQuery("sp_DeleteAutobus", parametros);
        }
    }
}

