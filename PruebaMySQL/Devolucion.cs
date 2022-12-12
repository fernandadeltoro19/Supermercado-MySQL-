//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Devolucion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Devolucion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Devolucion ORDER BY idDevolucion");

        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Departamento depa = new Departamento();
            depa.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            DevolucionProveedor doc = new DevolucionProveedor();
            doc.Show();
        }

        private void Devolucion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string producto = textBox1.Text;
            string cantidad = textBox2.Text;
            string cantidadmonetaria = textBox3.Text;
            string idCliente = textBox4.Text;
            string estatus = textBox5.Text;
            consulta = "INSERT INTO Devolucion (producto, cantidad, cantidadmonetaria, idCliente, estatus) values('" + producto + "', '" + cantidad + "', '" + cantidadmonetaria + "', '" + idCliente + "', '" + estatus + "')";
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
            string producto = textBox1.Text;
            string cantidad = textBox2.Text;
            string cantidadmonetaria = textBox3.Text;
            string idCliente = textBox4.Text;
            string estatus = textBox5.Text;
            int idDevolucion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Devolucion SET producto = '" + producto + "',cantidad = '" + cantidad + "',cantidadmonetaria = '" + cantidadmonetaria + "',idCliente = '" + idCliente + "', estatus = '" + estatus + "' WHERE idDevolucion = " + idDevolucion.ToString();
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
            int idDevolucion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Devolucion SET fecha = False WHERE idDevolucion = " + idDevolucion.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
