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
    public partial class FrmRutas : Form
    {
        private RutasBL rutaBL;

        public FrmRutas()
        {
            InitializeComponent();
            rutaBL = RutasBL.Instancia;
            CargarRutas();
        }

        private void CargarRutas()
        {
            try
            {
                dgvRutas.DataSource = rutaBL.ListarRutas();
                dgvRutas.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar rutas: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            dgvRutas.ClearSelection();
            errorProvider1.Clear();
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Ingrese el nombre de la ruta.");
                valido = false;
            }

            return valido;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                rutaBL.AgregarRuta(txtNombre.Text.Trim());
                MessageBox.Show("Ruta insertada correctamente.");
                LimpiarCampos();
                CargarRutas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar ruta: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una ruta para modificar.");
                return;
            }

            if (!ValidarCampos()) return;

            try
            {
                int rutaID = Convert.ToInt32(dgvRutas.CurrentRow.Cells["RutaID"].Value);
                rutaBL.ModificarRuta(rutaID, txtNombre.Text.Trim());
                MessageBox.Show("Ruta modificada correctamente.");
                LimpiarCampos();
                CargarRutas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar ruta: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvRutas.CurrentRow == null)
            {
                MessageBox.Show("Seleccione una ruta para eliminar.");
                return;
            }

            try
            {
                int rutaID = Convert.ToInt32(dgvRutas.CurrentRow.Cells["RutaID"].Value);
                rutaBL.EliminarRuta(rutaID);
                MessageBox.Show("Ruta eliminada correctamente.");
                LimpiarCampos();
                CargarRutas();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar ruta: " + ex.Message);
            }
        }

        private void dgvRutas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombre.Text = dgvRutas.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
