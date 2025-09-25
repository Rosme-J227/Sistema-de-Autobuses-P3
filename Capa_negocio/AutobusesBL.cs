using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Capa_accesoDatos;


namespace Capa_negocio
{
    public class AutobusesBL
    {
        private static AutobusesBL instancia;
        private AutobusesDAL autobusDAL;

        private AutobusesBL()
        {
            autobusDAL = new AutobusesDAL();
        }

        public static AutobusesBL Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new AutobusesBL();
                return instancia;
            }
        }

        public DataTable ListarAutobuses()
        {
            return autobusDAL.GetAutobuses();
        }

        public void AgregarAutobus(string marca, string modelo, string placa, string color, int ano)
        {
            if (string.IsNullOrWhiteSpace(marca) || string.IsNullOrWhiteSpace(modelo) || string.IsNullOrWhiteSpace(placa))
                throw new Exception("Marca, modelo y placa son obligatorios.");

            autobusDAL.InsertAutobus(marca, modelo, placa, color, ano);
        }

        public void ModificarAutobus(int autobusID, string marca, string modelo, string placa, string color, int ano)
        {
            autobusDAL.UpdateAutobus(autobusID, marca, modelo, placa, color, ano);
        }

        public void EliminarAutobus(int autobusID)
        {
            autobusDAL.DeleteAutobus(autobusID);
        }
    }
}

