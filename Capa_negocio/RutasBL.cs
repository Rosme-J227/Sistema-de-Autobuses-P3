using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_accesoDatos;

namespace Capa_negocio
{
    public class RutasBL
    {
        private static RutasBL instancia;
        private RutasDAL rutaDAL;

        private RutasBL()
        {
            rutaDAL = new RutasDAL();
        }

        public static RutasBL Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new RutasBL();
                return instancia;
            }
        }

        public DataTable ListarRutas()
        {
            return rutaDAL.GetRutas();
        }

        public void AgregarRuta(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre))
                throw new Exception("El nombre de la ruta es obligatorio.");

            rutaDAL.InsertRuta(nombre);
        }

        public void ModificarRuta(int rutaID, string nombre)
        {
            rutaDAL.UpdateRuta(rutaID, nombre);
        }

        public void EliminarRuta(int rutaID)
        {
            rutaDAL.DeleteRuta(rutaID);
        }
    }
}

