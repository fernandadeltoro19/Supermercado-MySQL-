//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Comprobante : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Comprobante()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Comprobante ORDER BY idComprobante");

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Compra consulta = new Compra();
            consulta.Show();

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Contador cont = new Contador();
            cont.Show();
        }

        private void Comprobante_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string fecha = textBox1.Text;
            string cantidad = textBox2.Text;
            string productos = textBox3.Text;
            consulta = "INSERT INTO Comprobante (fecha, cantidad, productos) values('" + fecha + "', '" + cantidad + "', '" + productos + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string fecha = textBox1.Text;
            string cantidad = textBox2.Text;
            string productos = textBox3.Text;
            int idComprobante = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Comprobante SET fecha = '" + fecha + "',cantidad = '" + cantidad + "',productos = '" + productos + "' WHERE idComprobante = " + idComprobante.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear(); ;
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idComprobante = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Comprobante SET Estatus = False WHERE idComprobante = " + idComprobante.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
