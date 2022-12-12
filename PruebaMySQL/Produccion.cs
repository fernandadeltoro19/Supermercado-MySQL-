//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Produccion : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Produccion()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Produccion ORDER BY idProduccion");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Prestacion pre = new Prestacion();
            pre.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Producto produ = new Producto();
            produ.Show();
        }

        private void Produccion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string fecha = textBox1.Text;
            string total = textBox2.Text;
            string idMarca = textBox3.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO Produccion (fecha, total, idMarca, estatus) values('" + fecha + "', '" + total + "', '" + idMarca + "', '" + estatus + "')";
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
            string fecha = textBox1.Text;
            string total = textBox2.Text;
            string idMarca = textBox3.Text;
            string estatus = textBox4.Text;
            int idProduccion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Produccion SET fecha = '" + fecha + "',total = '" + total + "',idMarca = '" + idMarca + "',estatus = '" + estatus +  "' WHERE idProduccion = " + idProduccion.ToString();
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
            int idProduccion = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Produccion SET Estatus = False WHERE idProduccion = " + idProduccion.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
