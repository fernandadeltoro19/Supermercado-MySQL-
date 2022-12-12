//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Departamento : Form
    {

        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Departamento()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Departamento ORDER BY idDepartamento");

        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Delivery deli = new Delivery();
            deli.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Devolucion devo = new Devolucion();
            devo.Show();
        }

        private void Departamento_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string categoria = textBox2.Text;
            string idSucursal = textBox3.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO Departamento (nombre, categoria, idSucursal, estatus) values('" + nombre + "', '" + categoria + "', '" + idSucursal + "', + estatus)";
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
            string nombre = textBox1.Text;
            string categoria = textBox2.Text;
            string idSucursal = textBox3.Text;
            string estatus = textBox4.Text;
            int idDepartamento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Departamento SET nombre = '" + nombre + "',categoria = '" + categoria + "',idSucursal = '" + idSucursal  +"',estatus = '" + estatus + "' WHERE idDepartamento = " + idDepartamento.ToString();
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
            int idDepartamento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Departamento SET Estatus = False WHERE idDepartamento = " + idDepartamento.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


        }
    }
}
