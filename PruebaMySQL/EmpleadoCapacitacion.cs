using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class EmpleadoCapacitacion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public EmpleadoCapacitacion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM EmpleadoCapacitacion ORDER BY idEmpleadoCapacitacion");

        }
        private void EmpleadoCapacitacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idEmpleado = textBox1.Text;
            string idCapacitacion = textBox2.Text;
            string estatus = textBox3.Text;
            consulta = "INSERT INTO EmpleadoCapacitacion (idEmpleado, idCapacitacion, estatus) values('" + idEmpleado + "', '" + idCapacitacion + "', '"  + "', '" + estatus + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idEmpleadoCapacitacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE EmpleadoCapacitacion SET Estatus = False WHERE idEmpleadoCapacitacion = " + idEmpleadoCapacitacion.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idEmpleado = textBox1.Text;
            string idCapacitacion = textBox2.Text;
            string estatus = textBox3.Text;
            int idEmpleadoCapacitacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE idEmpleadoCapacitacion SET idEmpleado = '" + idEmpleado + "',idCapacitacion = '" + idCapacitacion + "',   '"  + "', estatus ='" + estatus + "' WHERE idEmpleadoCapacitacion = " + idEmpleadoCapacitacion.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            ClienteQueja bode = new ClienteQueja();
            bode.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpleadoContrato bode = new EmpleadoContrato();
            bode.Show();
        }
    }
}
