//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class HorarioTrabajo : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public HorarioTrabajo()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM HorarioTrabajador ORDER BY idHorarioTrabajador");

        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            FacturaProveedor fac = new FacturaProveedor();
            fac.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventario ins = new Inventario();
            ins.Show();
        }

        private void HorarioTrabajo_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string entrada = textBox1.Text;
            string salida = textBox2.Text;
            string idEmpleado = textBox3.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO HORARIOTRABAJADOR (entrada, salida, idEmpleado, estatus) values('" + entrada + "', '" + salida + "', '" + "', '" + idEmpleado + "', '" +estatus+ "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string entrada = textBox1.Text;
            string salida = textBox2.Text;
            string idEmpleado = textBox3.Text;
            string estatus = textBox4.Text;
            int idHorariotrabajador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE HORARIOTRABAJADOR SET entrada = '" + entrada + "',salida = '" + salida + "',idEmpleado = '" + idEmpleado + "', estatus = '" +estatus + "'' WHERE idHorariotrabajador = " + idHorariotrabajador.ToString();
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
            int idHorariotrabajador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE HORARIOTRABAJADOR SET Estatus = False WHERE idHorariotrabajador = " + idHorariotrabajador.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
