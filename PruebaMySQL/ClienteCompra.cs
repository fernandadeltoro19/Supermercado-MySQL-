using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class ClienteCompra : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public ClienteCompra()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();

        }


        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM ClienteCompra ORDER BY idClienteCompra");

        }

        private void ClienteCompra_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idBodega = textBox1.Text;
            string idInventario = textBox2.Text;
            string fechaInventario = textBox3.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO BodegaInventario (idBodega, idInventario, fechaInventario, estatus) values('" + idBodega + "', '" + idInventario + "', '" + fechaInventario + "', '" + estatus + "')";
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
            int idBodegaInventario = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE BodegaInventario SET Estatus = False WHERE idBodegaInventario = " + idBodegaInventario.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idBodega = textBox1.Text;
            string idInventario = textBox2.Text;
            string fechaInventario = textBox3.Text;
            string estatus = textBox4.Text;
            int idBodegaInventario = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE BodegaInventario SET idBodega = '" + idBodega + "',idInventario = '" + idInventario + "', fechaInventario = '" + fechaInventario + "', estatus ='" + estatus + "' WHERE idBodegaInventario = " + idBodegaInventario.ToString();
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
            BodegaInventario bode = new BodegaInventario();
            bode.Show();
            
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClienteCotizacion bode = new ClienteCotizacion();
            bode.Show();
        }
    }
}
