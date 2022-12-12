//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Compra : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Compra()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Compra ORDER BY idCompra");

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cliente cliente = new Cliente();
            cliente.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Comprobante consulta = new Comprobante();
            consulta.Show();
        }

        private void Compra_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string cantidad = textBox1.Text;
            string fecha = textBox2.Text;
            string idFacturaCliente = textBox3.Text;
            string idProducto = textBox4.Text;
            string estatus = textBox5.Text;
            consulta = "INSERT INTO Compra (cantidad, fecha, idFacturaCliente, idProducto) values('" + cantidad + "', '" + fecha + "', '" + idFacturaCliente + "', '" + idProducto + "', '"+ estatus+ "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string cantidad = textBox1.Text;
            string fecha = textBox2.Text;
            string idFacturaCliente = textBox3.Text;
            string idProducto = textBox4.Text;
            string estatus = textBox5.Text;
            int idCompra = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Compra SET cantidad = '" + cantidad + "',fecha = '" + fecha + "',idFacturaCliente = '" + idFacturaCliente + "',idProducto = '" + idProducto + "', estatus = '" + estatus+ "' WHERE idCompra = " + idCompra.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idCompra = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Compra SET Estatus = False WHERE idCompra = " + idCompra.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
