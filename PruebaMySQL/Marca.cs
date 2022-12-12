//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace PruebaMySQL
{
    public partial class Marca : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Marca()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Marca ORDER BY idMarca");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mantenimiento man = new Mantenimiento();
            man.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Marketing mark = new Marketing();
            mark.Show();
        }

        private void Marca_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string ciudad = textBox2.Text;
            consulta = "INSERT INTO Marca (nombre, modelo) values('" + nombre + "', '" + ciudad + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {

            //Modificar
            string nombre = textBox1.Text;
            string ciudad = textBox2.Text;
            int idMarca = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Marca SET nombre = '" + nombre + "',ciudad = '" + ciudad + "' WHERE idMarca = " + idMarca.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idMarca = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Marca SET Estatus = False WHERE idMarca = " + idMarca.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
