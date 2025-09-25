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
    public partial class FrmChoferes : Form
    {
        private ChoferesBL choferBL;

        public FrmChoferes()
        {
            InitializeComponent();
            choferBL = ChoferesBL.Instancia; // Usamos el singleton
            CargarChoferes();
        }

        private void FrmChoferes_Load(object sender, EventArgs e)
        {
            CargarChoferes();
        }

        private void CargarChoferes()
        {
            try
            {
                dgvChoferes.DataSource = choferBL.ListarChoferes();
                dgvChoferes.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar choferes: " + ex.Message);
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtApellido.Clear();
            txtCedula.Clear();
            dtpFechaNacimiento.Value = DateTime.Now;
            dgvChoferes.ClearSelection();
            errorProvider1.Clear();
        }

        private bool ValidarCampos()
        {
            bool valido = true;
            errorProvider1.Clear();

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                errorProvider1.SetError(txtNombre, "Ingrese el nombre.");
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(txtApellido.Text))
            {
                errorProvider1.SetError(txtApellido, "Ingrese el apellido.");
                valido = false;
            }
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                errorProvider1.SetError(txtCedula, "Ingrese la cédula.");
                valido = false;
            }
            return valido;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos()) return;

            try
            {
                choferBL.AgregarChofer(txtNombre.Text.Trim(),
                                        txtApellido.Text.Trim(),
                                        dtpFechaNacimiento.Value,
                                        txtCedula.Text.Trim());
                MessageBox.Show("Chofer insertado correctamente.");
                LimpiarCampos();
                CargarChoferes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al insertar chofer: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvChoferes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un chofer para modificar.");
                return;
            }

            if (!ValidarCampos()) return;

            try
            {
                int choferID = Convert.ToInt32(dgvChoferes.CurrentRow.Cells["ChoferID"].Value);
                choferBL.ModificarChofer(choferID,
                                         txtNombre.Text.Trim(),
                                         txtApellido.Text.Trim(),
                                         dtpFechaNacimiento.Value,
                                         txtCedula.Text.Trim());
                MessageBox.Show("Chofer modificado correctamente.");
                LimpiarCampos();
                CargarChoferes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar chofer: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvChoferes.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un chofer para eliminar.");
                return;
            }

            try
            {
                int choferID = Convert.ToInt32(dgvChoferes.CurrentRow.Cells["ChoferID"].Value);
                choferBL.EliminarChofer(choferID);
                MessageBox.Show("Chofer eliminado correctamente.");
                LimpiarCampos();
                CargarChoferes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar chofer: " + ex.Message);
            }
        }

        private void dgvChoferes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtNombre.Text = dgvChoferes.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
                txtApellido.Text = dgvChoferes.Rows[e.RowIndex].Cells["Apellido"].Value.ToString();
                dtpFechaNacimiento.Value = Convert.ToDateTime(dgvChoferes.Rows[e.RowIndex].Cells["FechaNacimiento"].Value);
                txtCedula.Text = dgvChoferes.Rows[e.RowIndex].Cells["Cedula"].Value.ToString();
            }
        }

        private void dgvChoferes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblCedula_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void lblFechaNacimiento_Click(object sender, EventArgs e)
        {

        }

        private void txtApellido_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblApellido_Click(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblNombre_Click(object sender, EventArgs e)
        {

        }

        private void dtpFechaNacimiento_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}

