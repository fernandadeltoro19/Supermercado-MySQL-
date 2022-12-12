//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Capacitacion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Capacitacion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Capacitacion ORDER BY idCapacitacion");

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Capacitacion caja = new Capacitacion();
            caja.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Cliente cliente = new Cliente();
            cliente.Show();
        }

        private void Capacitacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string tipo = textBox2.Text;
            string numero = textBox3.Text;
            consulta = "INSERT INTO Capacitacion (nombre, tipo, numero) values('" + nombre + "', '" + tipo + "', '" + numero + "')";
            ConexionMySql.ejecutaConsulta(consulta);

            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string nombre = textBox1.Text;
            string tipo = textBox2.Text;
            string numero = textBox3.Text;
            int idCapacitacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Capacitacion SET nombre = '" + nombre + "',tipo = '" + tipo + "',numero = '" + numero + "' WHERE idCapacitacion = " + idCapacitacion.ToString();
            ConexionMySql.ejecutaConsulta(consulta); 
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idCapacitacion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Capacitacion SET Estatus = False WHERE idCapacitacion = " + idCapacitacion.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
