using Datos_.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos_.Acceso
{
    public class PedidoAD
    {
        readonly string cadena = "Server=localhost; Port=3306; Database=examen2parcial; Uid=root; Pwd=;";

        MySqlConnection conn;
        MySqlCommand cmd;

        public bool InsertarPedido(Pedido pedido)
        {
            bool inserto = false;

            try
            {
                string sql = "INSERT INTO pedido VALUES (@Id, @Cantidad, @Precio, @Total, @CodigoProducto, @Descripcion);";
                
                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@Id", pedido.Id);
                cmd.Parameters.AddWithValue("@Cantidad", pedido.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", pedido.Precio);
                cmd.Parameters.AddWithValue("@Total", pedido.Total);
                cmd.Parameters.AddWithValue("@CodigoProducto", pedido.CodigoProducto);
                cmd.Parameters.AddWithValue("@Descripcion", pedido.Descripcion);

                cmd.ExecuteNonQuery();
                inserto = true;

                conn.Close();
            }
            catch (Exception)
            {
            }
            return inserto;
        }

    }
}
