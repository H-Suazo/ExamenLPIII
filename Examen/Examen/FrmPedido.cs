using Datos_.Acceso;
using Datos_.Entidades;
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
    public partial class FrmPedido : Form
    {
        public FrmPedido()
        {
            InitializeComponent();
        }

        ProductoAD productoAD = new ProductoAD();
        Pedido pedido = new Pedido();
        Producto producto;
        PedidoAD pedidoAD = new PedidoAD();

        List<Pedido> pedidoLista = new List<Pedido>();

        decimal subtotal = decimal.Zero;
        decimal impuesto = decimal.Zero;
        decimal totalAPagar = decimal.Zero;

        private void txtCodigoP_TextChanged(object sender, EventArgs e)
        {

        }



        private void txtCantidadP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter && !string.IsNullOrEmpty(txtCantidadP.Text))
            {
                pedido.CodigoProducto = producto.Codigo;
                pedido.Descripcion = producto.Descripcion;
                pedido.Cantidad = Convert.ToInt32(txtCantidadP.Text);
                pedido.Precio = producto.Precio;
                pedido.Total = producto.Precio * Convert.ToInt32(txtCantidadP.Text);

                subtotal += pedido.Total;
                impuesto = subtotal * 0.15M;
                totalAPagar = subtotal + impuesto;

                pedidoLista.Add(pedido);
                dataGVPedidos.DataSource = null;
                dataGVPedidos.DataSource = pedidoLista;
            }
           
        }

        private void txtCodigoP_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (e.KeyChar == (char)Keys.Enter) {
                producto = new Producto();
                producto = productoAD.GetProductoCodigo(txtCodigoP.Text);
                txtDescripcionP.Text = producto.Descripcion;
                txtCantidadP.Focus();
            }
            else
            {
                producto = null;
                txtDescripcionP.Clear();
                txtCantidadP.Clear();
            }
        }

        private void FrmPedido_Load(object sender, EventArgs e)
        {
            dataGVPedidos.DataSource = pedidoLista;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            pedido.CodigoProducto = txtCodigoP.Text;
            pedido.Descripcion = txtDescripcionP.Text;
            pedido.Cantidad = Convert.ToInt32(txtCantidadP.Text);
            pedido.Precio = producto.Precio;
            pedido.Total = producto.Precio * Convert.ToInt32(txtCantidadP.Text);

            int id = 0;

        }
    }
}
