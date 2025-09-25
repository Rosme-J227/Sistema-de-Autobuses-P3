using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Capa_accesoDatos
{
    public class ConexionDB
    {
        private readonly string connectionString;

        public ConexionDB()
        {
            // Ajusta tu servidor y autenticación
            connectionString = @"Server=localhost;Database=SistemaAutobuses1;Trusted_Connection=True;";
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
