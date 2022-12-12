using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class EmpleadoContrato : Form
    {

        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public EmpleadoContrato()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM EmpleadoContrato ORDER BY idEmpleadoContrato");

        }
        private void EmpleadoContrato_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idEmpleado = textBox1.Text;
            string idContrato = textBox2.Text;
            string fechaContrato = textBox3.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO EmpleadoContrato (idEmpleado, idContrato, fechaContrato, estatus) values('" + idEmpleado + "', '" + idContrato + "', '" + fechaContrato + "', '" + estatus + "')";
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
            int idEmpleadoContrato = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE EmpleadoContrato SET Estatus = False WHERE idEmpleadoContrato = " + idEmpleadoContrato.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idEmpleado = textBox1.Text;
            string idContrato = textBox2.Text;
            string fechaContrato = textBox3.Text;
            string estatus = textBox4.Text;
            int idEmpleadoContrato = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE EmpleadoContrato SET idEmpleado = '" + idEmpleado + "',idContrato = '" + idContrato + "', fechaContrato = '" + fechaContrato + "', estatus ='" + estatus + "' WHERE idEmpleadoContrato = " + idEmpleadoContrato.ToString();
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
            EmpleadoCapacitacion bode = new EmpleadoCapacitacion();
            bode.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            EmpleadoPrestacion bode = new EmpleadoPrestacion();
            bode.Show();
        }
    }
}
