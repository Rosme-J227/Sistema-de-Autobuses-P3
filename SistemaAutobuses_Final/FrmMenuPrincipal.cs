using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_presentacion;
using Capa_negocio;




namespace SistemaAutobuses_Final
{
    public partial class FrmMenuPrincipal : Form
    {
        private string rolUsuario;

        public FrmMenuPrincipal(string rol)
        {
            InitializeComponent();
            rolUsuario = rol;
            ConfigurarMenu();
        }

        private void ConfigurarMenu()
        {
            lblBienvenida.Text = "Bienvenido - Rol: " + rolUsuario;

            // Solo el Administrador puede gestionar usuarios, choferes y autobuses
            if (rolUsuario == "Usuario")
            {
                btnGestUsuarios.Enabled = false;
                btnGestChoferes.Enabled = false;
                btnGestAutobuses.Enabled = false;
            }
        }

        private void btnGestChoferes_Click(object sender, EventArgs e)
        {
            FrmChoferes frm = new FrmChoferes();
            frm.ShowDialog();
        }

        private void btnGestAutobuses_Click(object sender, EventArgs e)
        {
            FrmAutobuses frm = new FrmAutobuses();
            frm.ShowDialog();
        }

        private void btnGestRutas_Click(object sender, EventArgs e)
        {
            FrmRutas frm = new FrmRutas();
            frm.ShowDialog();
        }

        private void btnGestAsignaciones_Click(object sender, EventArgs e)
        {
            FrmAsignaciones frm = new FrmAsignaciones();
            frm.ShowDialog();
        }

        private void btnGestUsuarios_Click(object sender, EventArgs e)
        {
            FrmUsuarios frm = new FrmUsuarios();
            frm.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmLogin login = new FrmLogin();
            login.Show();
        }

        private void lblBienvenida_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
