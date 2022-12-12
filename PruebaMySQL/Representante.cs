//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Representante : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Representante()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Representante ORDER BY idRepresentante");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Restaurante rece = new Restaurante();
            rece.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Restaurante trans = new Restaurante();
            trans.Show();
        }

        private void Representante_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string apellidoPaterno = textBox2.Text;
            string apellidoMaterno = textBox3.Text;
            string telefono = textBox4.Text;
            string empresa = textBox5.Text;
            consulta = "INSERT INTO Representante (nombre, apellidoPaterno, apellidoMaterno, telefono, empresa) values('" + nombre + "', '" + apellidoPaterno + "', '" + apellidoMaterno + "', '" + telefono + "', '" + empresa +"')";
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
            string nombre = textBox1.Text;
            string apellidoPaterno = textBox2.Text;
            string apellidoMaterno = textBox3.Text;
            string telefono = textBox4.Text;
            string empresa = textBox5.Text;
            int idRepresentante = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Representante SET nombre = '" + nombre + "',apellidoPaterno = '" + apellidoPaterno + "',apellidoMaterno = '" + apellidoMaterno + "',telefno = '" + telefono + "', empresa = '" + empresa + "' WHERE idRepresentante = " + idRepresentante.ToString();
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
            int idRepresentante = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Representante SET Estatus = False WHERE idRepresentante = " + idRepresentante.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
