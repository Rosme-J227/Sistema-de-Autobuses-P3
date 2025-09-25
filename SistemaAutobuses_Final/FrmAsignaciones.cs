using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_negocio;

namespace SistemaAutobuses_Final
{
    public partial class FrmAsignaciones : Form
    {
        private AsignacionesBL asignacionBL;

        public FrmAsignaciones()
        {
            InitializeComponent();
            asignacionBL = AsignacionesBL.Instancia;
            CargarCombos();
            CargarAsignaciones();
        }

        private void CargarCombos()
        {
            try
            {
                // Choferes
                var choferes = asignacionBL.ListarAsignacionesDisponibles("chofer") as DataTable;
                if (choferes != null && choferes.Rows.Count > 0)
                {
                    choferes.Columns.Add("NombreCompleto", typeof(string));
                    foreach (DataRow row in choferes.Rows)
                        row["NombreCompleto"] = row["Nombre"].ToString() + " " + row["Apellido"].ToString();

                    cboChofer.DataSource = choferes;
                    cboChofer.DisplayMember = "NombreCompleto";
                    cboChofer.ValueMember = "ChoferID";
                    cboChofer.SelectedIndex = -1;
                }

                // Autobuses
                var autobuses = asignacionBL.ListarAsignacionesDisponibles("autobus") as DataTable;
                if (autobuses != null && autobuses.Rows.Count > 0)
                {
                    autobuses.Columns.Add("PlacaMarca", typeof(string));
                    foreach (DataRow row in autobuses.Rows)
                        row["PlacaMarca"] = row["Placa"].ToString() + " - " + row["Marca"].ToString();

                    cboAutobus.DataSource = autobuses;
                    cboAutobus.DisplayMember = "PlacaMarca";
                    cboAutobus.ValueMember = "AutobusID";
                    cboAutobus.SelectedIndex = -1;
                }

                // Rutas
                var rutas = asignacionBL.ListarAsignacionesDisponibles("ruta") as DataTable;
                if (rutas != null && rutas.Rows.Count > 0)
                {
                    cboRuta.DataSource = rutas;
                    cboRuta.DisplayMember = "Nombre";
                    cboRuta.ValueMember = "RutaID";
                    cboRuta.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar combos: " + ex.Message);
            }
        }


        private void CargarAsignaciones()
        {
            try
            {
                dgvAsignaciones.DataSource = asignacionBL.ListarAsignaciones();
                dgvAsignaciones.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar asignaciones: " + ex.Message);
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (cboChofer.SelectedIndex == -1 || cboAutobus.SelectedIndex == -1 || cboRuta.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar chofer, autobús y ruta.");
                return;
            }

            try
            {
                asignacionBL.AgregarAsignacion(
                    Convert.ToInt32(cboChofer.SelectedValue),
                    Convert.ToInt32(cboAutobus.SelectedValue),
                    Convert.ToInt32(cboRuta.SelectedValue)
                );
                MessageBox.Show("Asignación creada correctamente.");
                CargarCombos();
                CargarAsignaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnActivar_Click(object sender, EventArgs e)
        {
            if (dgvAsignaciones.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una asignación para activar/desactivar.");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvAsignaciones.CurrentRow.Cells["AsignacionID"].Value);
                bool activa = Convert.ToBoolean(dgvAsignaciones.CurrentRow.Cells["Activa"].Value);
                asignacionBL.ModificarAsignacion(id, !activa);
                CargarCombos();
                CargarAsignaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar asignación: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAsignaciones.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una asignación para eliminar.");
                return;
            }

            try
            {
                int id = Convert.ToInt32(dgvAsignaciones.CurrentRow.Cells["AsignacionID"].Value);
                asignacionBL.EliminarAsignacion(id);
                CargarCombos();
                CargarAsignaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar asignación: " + ex.Message);
            }
        }

        private void lblChofer_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblAutobus_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dgvAsignaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

