using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class EmpleadoPrestacion : Form
    {

        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public EmpleadoPrestacion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();

        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM EmpleadoPrestacion ORDER BY idEmpleadoPrestacion");

        }

        private void EmpleadoPrestacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idEmpleado = textBox1.Text;
            string idPrestacion = textBox2.Text;
            string estatus = textBox3.Text;
            consulta = "INSERT INTO EmpleadoPrestacion (idEmpleado, idPrestacion, estatus) values('" + idEmpleado + "', '" + idPrestacion + "', '"  + "', '" + estatus + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idEmpleadoPrestacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE EmpleadoPrestacion SET Estatus = False WHERE idEmpleadoPrestacion = " + idEmpleadoPrestacion.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idEmpleado = textBox1.Text;
            string idPrestacion = textBox2.Text;
            string estatus = textBox3.Text;
            int idEmpleadoPrestacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE EmpleadoPrestacion SET idEmpleado = '" + idEmpleado + "',idPrestacion = '" + idPrestacion + "',  = '"  + "', estatus ='" + estatus + "' WHERE idEmpleadoPrestacion = " + idEmpleadoPrestacion.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpleadoContrato bode = new EmpleadoContrato();
            bode.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductoEnvio bode = new ProductoEnvio();
            bode.Show();
        }
    }
}
