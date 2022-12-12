//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{

    public partial class Contador : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Contador()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Contador ORDER BY idContador");

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Comprobante comp = new Comprobante();
            comp.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Contrato cont = new Contrato();
            cont.Show();
        }

        private void Contador_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string apellidopaterno = textBox2.Text;
            string apellidomaterno = textBox3.Text;
            string calle = textBox4.Text;
            string numero = textBox5.Text;
            string ciudad = textBox6.Text;
            string telefono = textBox7.Text;
            consulta = "INSERT INTO Contador (nombre, apellidopaterno , apellidomaterno , calle, numero, ciudad, telefono) values('" + nombre + "', '" + apellidopaterno + "', '" + apellidomaterno + "', '" + calle + "' , '" +numero+ "', '" + ciudad + "', '" +telefono + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string nombre = textBox1.Text;
            string apellidopaterno = textBox2.Text;
            string apellidomaterno = textBox3.Text;
            string calle = textBox4.Text;
            string numero = textBox5.Text;
            string ciudad = textBox6.Text;
            string telefono = textBox7.Text;
            int idContador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Contador SET nombre = '" + nombre + "',apellidopaterno = '" + apellidopaterno + "',apellidomaterno = '" + apellidomaterno + "',calle = '" + calle +"', numero = '" + numero + "', ciudad = '" +ciudad + "', telefono = '" + telefono +  "' WHERE idContador = " + idContador.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idContador = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Contador SET Estatus = False WHERE idContador = " + idContador.ToString(); 
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
