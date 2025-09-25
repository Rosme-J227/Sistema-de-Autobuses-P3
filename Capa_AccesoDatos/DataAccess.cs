using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Capa_accesoDatos
{
    public class DataAccess
    {
        private ConexionDB conexion;

        public DataAccess()
        {
            conexion = new ConexionDB();
        }

        public DataTable ExecuteReader(string storedProcedure, SqlParameter[] parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = conexion.GetConnection())
            using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                try
                {
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    reader.Close();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al ejecutar el procedimiento: " + ex.Message);
                }
            }
            return dt;
        }

        public int ExecuteNonQuery(string storedProcedure, SqlParameter[] parameters = null)
        {
            int affectedRows = 0;
            using (SqlConnection conn = conexion.GetConnection())
            using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                try
                {
                    conn.Open();
                    affectedRows = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al ejecutar el procedimiento: " + ex.Message);
                }
            }
            return affectedRows;
        }

        public object ExecuteScalar(string storedProcedure, SqlParameter[] parameters = null)
        {
            object result;
            using (SqlConnection conn = conexion.GetConnection())
            using (SqlCommand cmd = new SqlCommand(storedProcedure, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (parameters != null)
                    cmd.Parameters.AddRange(parameters);

                try
                {
                    conn.Open();
                    result = cmd.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al ejecutar el procedimiento: " + ex.Message);
                }
            }
            return result;
        }
    }
}
