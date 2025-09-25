using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;



namespace Capa_accesoDatos
{
    public class AsignacionesDAL
    {
        private DataAccess dataAccess;

        public AsignacionesDAL()
        {
            dataAccess = new DataAccess();
        }

        // Asignaciones
        public DataTable GetAsignaciones() => dataAccess.ExecuteReader("sp_GetAsignaciones");

        public void InsertAsignacion(int choferID, int autobusID, int rutaID)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@ChoferID", choferID),
                new SqlParameter("@AutobusID", autobusID),
                new SqlParameter("@RutaID", rutaID)
            };
            dataAccess.ExecuteNonQuery("sp_InsertAsignacion", parametros);
        }

        public void UpdateAsignacion(int asignacionID, bool activa)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@AsignacionID", asignacionID),
                new SqlParameter("@Activa", activa)
            };
            dataAccess.ExecuteNonQuery("sp_UpdateAsignacion", parametros);
        }

        public void DeleteAsignacion(int asignacionID)
        {
            SqlParameter[] parametros = {
                new SqlParameter("@AsignacionID", asignacionID)
            };
            dataAccess.ExecuteNonQuery("sp_DeleteAsignacion", parametros);
        }

        // Combos disponibles
        public DataTable GetChoferesDisponibles() => dataAccess.ExecuteReader("sp_GetChoferesDisponibles");

        public DataTable GetAutobusesDisponibles() => dataAccess.ExecuteReader("sp_GetAutobusesDisponibles");

        public DataTable GetRutasDisponibles() => dataAccess.ExecuteReader("sp_GetRutasDisponibles");
    }
}

