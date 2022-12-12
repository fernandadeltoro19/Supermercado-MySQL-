//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Sucursal : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Sucursal()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Sucursal ORDER BY idSucursal");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Restaurante trans = new Restaurante();
            trans.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            TarjetaPunto venta = new TarjetaPunto();
            venta.Show();
        }

        private void Sucursal_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string telefono = textBox2.Text;
            string calle = textBox3.Text;
            string estado = textBox4.Text;
            string numero = textBox5.Text;
            string colonia = textBox6.Text;
            string ciudad = textBox7.Text;
            consulta = "INSERT INTO Sucursal (nombre, telefono, calle, estado, numero, colonia, ciudad) values('" + nombre + "', '" + telefono + "', '" + calle + "', '" + estado + "', '" + numero + "', '" + colonia + "' , '" + ciudad + "')";
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
            string telefono = textBox2.Text;
            string calle = textBox3.Text;
            string estado = textBox4.Text;
            string numero = textBox5.Text;
            string colonia = textBox6.Text;
            string ciudad = textBox7.Text;
            int idSucursal = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Sucursal SET nombre = '" + nombre + "',telefono = '" + telefono + "',calle = '" + calle + "',estado = '" + estado + "', numero = '" + numero + "', colonia = '" + colonia + "' , ciudad = '" + ciudad + "' WHERE idSucursal = " + idSucursal.ToString();
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
            int idSucursal = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Sucursal SET Estatus = False WHERE idSucursal = " + idSucursal.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
