using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_accesoDatos;

namespace Capa_negocio
{
    public class ChoferesBL
    {
        private static ChoferesBL instancia;
        private ChoferesDAL choferDAL;

        // Singleton
        private ChoferesBL()
        {
            choferDAL = new ChoferesDAL();
        }

        public static ChoferesBL Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ChoferesBL();
                return instancia;
            }
        }

        public DataTable ListarChoferes()
        {
            return choferDAL.GetChoferes();
        }

        public void AgregarChofer(string nombre, string apellido, DateTime fechaNacimiento, string cedula)
        {
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(cedula))
                throw new Exception("Todos los campos son obligatorios.");

            choferDAL.InsertChofer(nombre, apellido, fechaNacimiento, cedula);
        }

        public void ModificarChofer(int choferID, string nombre, string apellido, DateTime fechaNacimiento, string cedula)
        {
            choferDAL.UpdateChofer(choferID, nombre, apellido, fechaNacimiento, cedula);
        }

        public void EliminarChofer(int choferID)
        {
            choferDAL.DeleteChofer(choferID);
        }
    }
}
