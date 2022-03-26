using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos_.Entidades
{
    public class Pedido
    {
        public int Id { get; set; }
        public string CodigoProducto { get; set; }
        public string Descripcion { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Total { get; set; }

        public Pedido()
        {
        }

        public Pedido(int id, string codigoProducto, string descripcion, int cantidad, decimal precio, decimal total)
        {
            Id = id;
            CodigoProducto = codigoProducto;
            Descripcion = descripcion;
            Cantidad = cantidad;
            Precio = precio;
            Total = total;
        }
    }
}
