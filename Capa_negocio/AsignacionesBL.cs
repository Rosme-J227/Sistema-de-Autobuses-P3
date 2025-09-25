using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_accesoDatos;



namespace Capa_negocio
{
    public class AsignacionesBL
    {
        private static AsignacionesBL instancia;
        private AsignacionesDAL asignacionDAL;

        private AsignacionesBL()
        {
            asignacionDAL = new AsignacionesDAL();
        }

        public static AsignacionesBL Instancia
        {
            get
            {
                if (instancia == null) instancia = new AsignacionesBL();
                return instancia;
            }
        }

        public DataTable ListarAsignaciones() => asignacionDAL.GetAsignaciones();

        public void AgregarAsignacion(int choferID, int autobusID, int rutaID)
        {
            asignacionDAL.InsertAsignacion(choferID, autobusID, rutaID);
        }

        public void ModificarAsignacion(int asignacionID, bool activa)
        {
            asignacionDAL.UpdateAsignacion(asignacionID, activa);
        }

        public void EliminarAsignacion(int asignacionID)
        {
            asignacionDAL.DeleteAsignacion(asignacionID);
        }

        public object ListarAsignacionesDisponibles(string tipo)
        {
            switch (tipo.ToLower())
            {
                case "chofer": return asignacionDAL.GetChoferesDisponibles();
                case "autobus": return asignacionDAL.GetAutobusesDisponibles();
                case "ruta": return asignacionDAL.GetRutasDisponibles();
                default: throw new Exception("Tipo no válido");
            }
        }
    }
}

