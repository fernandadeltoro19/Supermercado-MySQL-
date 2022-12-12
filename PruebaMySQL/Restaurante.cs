//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Restaurante : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Restaurante()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Restaurante ORDER BY idRestaurante");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Representante puesto = new Representante();
            puesto.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sucursal repre = new Sucursal();
            repre.Show();
        }

        private void Receta_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string mesas = textBox1.Text;
            string sillas = textBox2.Text;
            string comida = textBox3.Text;
            consulta = "INSERT INTO Restaurante (mesas, sillas, comida) values('" + mesas + "', '" + sillas + "', '" + comida + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
         
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string mesas = textBox1.Text;
            string sillas = textBox2.Text;
            string comida = textBox3.Text;
            int idRestaurante = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Restaurante SET mesas = '" + mesas + "',sillas = '" + sillas + "',comida = '" + comida +  "' WHERE idReceta = " + idRestaurante.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
           
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idRestaurante = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Restaurante SET Estatus = False WHERE idRestaurante = " + idRestaurante.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
