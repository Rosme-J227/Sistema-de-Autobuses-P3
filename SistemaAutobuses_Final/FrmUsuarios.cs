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
    public partial class FrmUsuarios : Form
    {
        private UsuariosBL usuarioBL;

        public FrmUsuarios()
        {
            InitializeComponent();
            usuarioBL = UsuariosBL.Instancia;
            CargarRoles();
            CargarUsuarios();
        }

        private void CargarRoles()
        {
            try
            {
                // Suponiendo que tu UsuariosDAL tiene método GetRoles()
                cboRol.DataSource = usuarioBL.ListarRoles();
                cboRol.DisplayMember = "NombreRol";
                cboRol.ValueMember = "RolID";
                cboRol.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar roles: " + ex.Message);
            }
        }

        private void CargarUsuarios()
        {
            try
            {
                dgvUsuarios.DataSource = usuarioBL.ListarUsuarios();
                dgvUsuarios.ClearSelection();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar usuarios: " + ex.Message);
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContrasena.Text) ||
                cboRol.SelectedIndex == -1)
            {
                MessageBox.Show("Todos los campos son obligatorios.");
                return;
            }

            try
            {
                usuarioBL.AgregarUsuario(txtNombreUsuario.Text, txtContrasena.Text, Convert.ToInt32(cboRol.SelectedValue));
                MessageBox.Show("Usuario agregado correctamente.");
                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar usuario: " + ex.Message);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario para modificar.");
                return;
            }

            int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["UsuarioID"].Value);

            try
            {
                usuarioBL.ModificarUsuario(id, txtNombreUsuario.Text, txtContrasena.Text, Convert.ToInt32(cboRol.SelectedValue));
                MessageBox.Show("Usuario modificado correctamente.");
                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar usuario: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
                return;
            }

            int id = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["UsuarioID"].Value);

            try
            {
                usuarioBL.EliminarUsuario(id);
                MessageBox.Show("Usuario eliminado correctamente.");
                CargarUsuarios();
                LimpiarCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar usuario: " + ex.Message);
            }
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsuarios.CurrentRow != null)
            {
                txtNombreUsuario.Text = dgvUsuarios.CurrentRow.Cells["NombreUsuario"].Value.ToString();
                txtContrasena.Text = dgvUsuarios.CurrentRow.Cells["Contrasena"].Value.ToString();
                cboRol.SelectedValue = Convert.ToInt32(dgvUsuarios.CurrentRow.Cells["RolID"].Value);
            }
        }

       
          

        private void LimpiarCampos()
        {
            txtNombreUsuario.Clear();
            txtContrasena.Clear();
            cboRol.SelectedIndex = -1;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void lblContrasena_Click(object sender, EventArgs e)
        {

        }

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {

        }
    }
}

