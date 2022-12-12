using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class SucursalEmpleadoo : Form
    {

        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public SucursalEmpleadoo()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM SucursalEmpleado ORDER BY idSucursalEmpleado");
        }

        private void SucursalEmpleadoo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idSucursal = textBox1.Text;
            string idEmpleado = textBox2.Text;
            string estatus = textBox3.Text;
            consulta = "INSERT INTO SucursalEmpleado (idSucursal, idEmpleado, estatus) values('" + idSucursal + "', '" + idEmpleado + "', '" + estatus + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idSucursalEmpleado = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE SucursalEmpleado SET Estatus = False WHERE idSucursalEmpleado = " + idSucursalEmpleado.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idSucursal = textBox1.Text;
            string idEmpleado = textBox2.Text;
            string estatus = textBox3.Text;
            int idSucursalEmpleado = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE SucursalEmpleado SET idSucursal = '" + idSucursal + "',idEmpleado = '" + idEmpleado + "', estatus = '" + estatus + "' WHERE idSucursalEmpleado = " + idSucursalEmpleado.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            ProductoVenta bode = new ProductoVenta();
            bode.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            TransportePaaquete bode = new TransportePaaquete();
            bode.Show();
        }
    }
}
