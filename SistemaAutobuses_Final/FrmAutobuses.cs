using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Capa_negocio;


namespace SistemaAutobuses_Final
{
    public partial class FrmAutobuses : Form
    {
        // Cambia TU_SERVIDOR por tu servidor SQL real
        private string connectionString = "Server=localhost;Database=SistemaAutobuses1;Trusted_Connection=True;";

        public FrmAutobuses()
        {
            InitializeComponent();
        }

        private void FrmAutobuses_Load(object sender, EventArgs e)
        {
            CargarAutobuses();
        }

        // 1️⃣ Cargar DataGridView
        private void CargarAutobuses()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_GetAutobuses", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvAutobuses.DataSource = dt;
                }
            }
        }

        // 2️⃣ Botón Agregar
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertAutobus", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Marca", txtMarca.Text);
                    cmd.Parameters.AddWithValue("@Modelo", txtModelo.Text);
                    cmd.Parameters.AddWithValue("@Placa", txtPlaca.Text);
                    cmd.Parameters.AddWithValue("@Color", txtColor.Text);
                    cmd.Parameters.AddWithValue("@Ano", (int)nudAno.Value);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            CargarAutobuses();
            LimpiarCampos();
        }

        // 3️⃣ Botón Modificar
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvAutobuses.CurrentRow != null)
            {
                int autobusID = Convert.ToInt32(dgvAutobuses.CurrentRow.Cells["AutobusID"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_UpdateAutobus", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AutobusID", autobusID);
                        cmd.Parameters.AddWithValue("@Marca", txtMarca.Text);
                        cmd.Parameters.AddWithValue("@Modelo", txtModelo.Text);
                        cmd.Parameters.AddWithValue("@Placa", txtPlaca.Text);
                        cmd.Parameters.AddWithValue("@Color", txtColor.Text);
                        cmd.Parameters.AddWithValue("@Ano", (int)nudAno.Value);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                CargarAutobuses();
                LimpiarCampos();
            }
        }

        // 4️⃣ Botón Eliminar
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAutobuses.CurrentRow != null)
            {
                int autobusID = Convert.ToInt32(dgvAutobuses.CurrentRow.Cells["AutobusID"].Value);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_DeleteAutobus", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@AutobusID", autobusID);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                CargarAutobuses();
                LimpiarCampos();
            }
        }

        // 5️⃣ Click en DataGridView para llenar campos
        private void dgvAutobuses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvAutobuses.Rows[e.RowIndex];
                txtMarca.Text = row.Cells["Marca"].Value.ToString();
                txtModelo.Text = row.Cells["Modelo"].Value.ToString();
                txtPlaca.Text = row.Cells["Placa"].Value.ToString();
                txtColor.Text = row.Cells["Color"].Value.ToString();
                nudAno.Value = Convert.ToDecimal(row.Cells["Ano"].Value);
            }
        }

      
        // Limpiar TextBox y NumericUpDown
        private void LimpiarCampos()
        {
            txtMarca.Clear();
            txtModelo.Clear();
            txtPlaca.Clear();
            txtColor.Clear();
            nudAno.Value = DateTime.Now.Year;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}

