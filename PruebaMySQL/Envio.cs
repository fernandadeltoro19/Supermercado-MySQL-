//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace PruebaMySQL
{
    public partial class Envio : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Envio()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Envio ORDER BY idEnvio");

        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Empresa emp = new Empresa();
            emp.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            EquipoInformatico est = new EquipoInformatico();
            est.Show();
        }

        private void Envio_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string apellidopaterno = textBox2.Text;
            string apellidomaterno = textBox3.Text;
            string calle = textBox4.Text;
            string estado = textBox5.Text;
            string numero = textBox6.Text;
            string colonia = textBox7.Text;
            string ciudad = textBox8.Text; 
            string cantidad = textBox9.Text;
            string categoria = textBox10.Text;
            string fecha = textBox11.Text;
            consulta = "INSERT INTO Envio (nombre, apellidopaterno, apellidomaterno, calle, estado, numero, colonia, ciudad, cantidad, categoria, fecha) values('" + nombre + "', '" + apellidopaterno + "', '" + apellidomaterno + "', '" + calle + "', '" + estado + "' , '" + numero + "' , '" + colonia + "' , '" + ciudad + "' , '" + cantidad + "' , '" + categoria + "' , '" + fecha + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string nombre = textBox1.Text;
            string apellidopaterno = textBox2.Text;
            string apellidomaterno = textBox3.Text;
            string calle = textBox4.Text;
            string estado = textBox5.Text;
            string numero = textBox6.Text;
            string colonia = textBox7.Text;
            string ciudad = textBox8.Text;
            string cantidad = textBox9.Text;
            string categoria = textBox10.Text;
            string fecha = textBox11.Text;
            int idEnvio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Envio SET nombre = '" + nombre + "',apellidopaterno= '" + apellidopaterno + "',apellidomaterno = '" + apellidomaterno + "',calle = '" + calle + "',estado= '" + estado + "',numero= '" + numero + "',colonia= '" + colonia + "',ciudad= '" + ciudad + "',cantidad= '" + cantidad + "',categoria= '" + categoria + "',fecha= '" + fecha +  "' WHERE idEnvio = " + idEnvio.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idEnvio = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Envio SET Estatus = False WHERE idEnvio = " + idEnvio.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
