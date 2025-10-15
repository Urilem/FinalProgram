using System;
using System.Windows.Forms;

namespace FinalProgram
{
    public partial class FrmInicio : Form
    {
        public FrmInicio()
        {
            InitializeComponent();
            
            // Conectar eventos
            btnAgregar.Click += btnAgregar_Click;
            btnListar.Click += btnListar_Click;
            btnModificar.Click += btnModificar_Click;
            btnVender.Click += btnVender_Click;
            btnSalir.Click += btnSalir_Click;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var frmAgregar = new FrmAgregar())
            {
                frmAgregar.ShowDialog();
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            using (var frmListar = new FrmListar())
            {
                frmListar.ShowDialog();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            using (var frmModificar = new FrmModificar())
            {
                frmModificar.ShowDialog();
            }
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            using (var frmVender = new FrmVender())
            {
                frmVender.ShowDialog();
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Método vacío
        }
    }
}
