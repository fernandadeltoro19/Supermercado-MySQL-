using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class ProductoPedidoLinea : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public ProductoPedidoLinea()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM ProductoPedidoLinea ORDER BY idProductoPedidoLinea");
        }
        private void ProductoPedidoLinea_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idProducto = textBox1.Text;
            string idPedidoLinea = textBox2.Text;
            string fechapedidolinea = textBox3.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO ProductoPedidoLinea (idProducto, idPedidoLinea, fechapedidolinea, estatus) values('" + idProducto + "', '" + idPedidoLinea + "', '" + fechapedidolinea + "', '" + estatus + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idProductoPedidoLinea = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE ProductoPedidoLinea SET Estatus = False WHERE idProductoPedidoLinea = " + idProductoPedidoLinea.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idProducto = textBox1.Text;
            string idPedidoLinea = textBox2.Text;
            string fechapedidolinea = textBox3.Text;
            string estatus = textBox4.Text;
            int idProductoPedidoLinea = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE ProductoPedidoLinea SET idProducto = '" + idProducto + "',idPedidoLinea = '" + idPedidoLinea + "', fechapedidolinea = '" + fechapedidolinea + "', estatus ='" + estatus + "' WHERE idProductoPedidoLinea = " + idProductoPedidoLinea.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductoOferta bode = new ProductoOferta();
            bode.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductoVenta bode = new ProductoVenta();
            bode.Show();
        }
    }
}
