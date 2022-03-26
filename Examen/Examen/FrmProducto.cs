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
    public partial class FrmProducto : Form
    {
        public FrmProducto()
        {
            InitializeComponent();
        }

        ProductoAD productoAD = new ProductoAD();
        string operacion = string.Empty;
        Producto producto = new Producto();


        private void FrmProducto_Load(object sender, EventArgs e)
        {
            ListarProductos();
        }

        private void ListarProductos()
        {
            dataGVProductos.DataSource = productoAD.ListarProductos();
        }

        private void HabilitarControles()
        {
            txtCodigo.Enabled = true;
            txtDescripcion.Enabled = true;
            txtPrecio.Enabled = true;
            txtExistencia.Enabled = true;

            btnNuevo.Enabled = false;
            btnGuardar.Enabled = true;
            btnCancelar.Enabled = true;
        }

        private void DeshabilitarControles()
        {
            txtCodigo.Enabled = false;
            txtDescripcion.Enabled = false;
            txtPrecio.Enabled = false;
            txtExistencia.Enabled = false;

            btnNuevo.Enabled = true;
            btnGuardar.Enabled = false;
            btnCancelar.Enabled = false;
        }

        private void LimpiarControles()
        {
            txtCodigo.Clear();
            txtDescripcion.Clear();
            txtPrecio.Clear();
            txtExistencia.Clear();
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            HabilitarControles();
            operacion = "Nuevo";
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            producto.Codigo = txtCodigo.Text;
            producto.Descripcion = txtDescripcion.Text;
            producto.Precio = Convert.ToDecimal(txtPrecio.Text);
            producto.Existencia = Convert.ToInt32(txtExistencia.Text);
           

            if (operacion == "Nuevo")
            {

                bool inserto = productoAD.InsertarProducto(producto);

                if (inserto)
                {
                    MessageBox.Show("Producto insertado");
                    ListarProductos();
                    LimpiarControles();
                    DeshabilitarControles();
                }
                else
                {
                    MessageBox.Show("Producto no insertado");
                }
            }
            else if (operacion == "Modificar")
            {
                bool modifico = productoAD.ModificarProducto(producto);

                if (modifico)
                {
                    MessageBox.Show("Producto modificado");
                    ListarProductos();
                    LimpiarControles();
                    DeshabilitarControles();
                }
                else
                {
                    MessageBox.Show("Producto no modificado");
                }
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            operacion = "Modificar";

            if (dataGVProductos.SelectedRows.Count > 0)
            {
                txtCodigo.Text = dataGVProductos.CurrentRow.Cells["Codigo"].Value.ToString();
                txtDescripcion.Text = dataGVProductos.CurrentRow.Cells["Descripcion"].Value.ToString();
                txtPrecio.Text = dataGVProductos.CurrentRow.Cells["Precio"].Value.ToString();
                txtExistencia.Text = dataGVProductos.CurrentRow.Cells["Existencia"].Value.ToString();
               
                HabilitarControles();
            }

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGVProductos.SelectedRows.Count > 0)
            {
                bool elimino = productoAD.EliminarProducto(dataGVProductos.CurrentRow.Cells["Codigo"].Value.ToString());

                if (elimino)
                {
                    MessageBox.Show("Producto eliminado");
                    ListarProductos();
                }
                else
                {
                    MessageBox.Show("Producto no eliminado");
                }
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DeshabilitarControles();
            LimpiarControles();
        }
    }
}
