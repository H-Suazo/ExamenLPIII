using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Examen
{
    public partial class FrmMenu : Syncfusion.Windows.Forms.Office2010Form
    {
        public FrmMenu()
        {
            InitializeComponent();
        }

        FrmProducto frmProducto = null;
        FrmPedido frmPedido = null;

        private void ProductosToolStripButton_Click(object sender, EventArgs e)
        {
            if (frmProducto == null)
            {
               frmProducto = new FrmProducto();
               frmProducto.MdiParent = this;
               frmProducto.FormClosed += FrmProducto_FormClosed;
               frmProducto.Show();
            }
            else
            {
                frmProducto.Activate();
            }
        }

        private void FrmProducto_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmProducto = null;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (frmPedido == null)
            {
                frmPedido = new FrmPedido();
                frmPedido.MdiParent = this;
                frmPedido.FormClosed += FrmPedido_FormClosed;       
                frmPedido.Show();
            }
            else
            {
                frmPedido.Activate();
            }
        }

        private void FrmPedido_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPedido = null;
        }
    }
}
