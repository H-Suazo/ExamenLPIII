using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text))
            {
                errorProvider1.SetError(txtUsuario, "Ingrese el usuario");
                txtUsuario.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtClave.Text))
            {
                errorProvider1.SetError(txtClave, "Ingrese una clave");
                txtClave.Focus();
                return;
            }

            FrmMenu frmMenu = new FrmMenu();
            frmMenu.Show();
            this.Hide();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
