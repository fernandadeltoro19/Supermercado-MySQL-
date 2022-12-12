using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Agenda : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Agenda()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }
        private void MostrarDatos()
        {

            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Bodega ORDER BY idBodega");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string numero = textBox1.Text;
            string total = textBox2.Text;
            consulta = "INSERT INTO Bodega (numero, total) values('" + numero + "', '" + total + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            int idBodega = (int) dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Bodega SET Estatus = False WHERE idBodega = " + idBodega.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string numero = textBox1.Text;
            string total = textBox2.Text;
            int idBodega = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Bodega SET numero = '" + numero + "',total = '" + total +  "' WHERE idBodega = "+ idBodega.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            Caja apar = new Caja();
            this.Hide();
            apar.Show();

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
