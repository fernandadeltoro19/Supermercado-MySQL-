//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Membresia : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Membresia()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Membresia ORDER BY idMembresia");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            MateriaPrima empleado = new MateriaPrima();
            empleado.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            MetodoPago producto = new MetodoPago();
            producto.Show();
        }

        private void MarcaProducto_Load(object sender, EventArgs e)
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
            string colonia = textBox5.Text;
            string ciudad = textBox6.Text;
            string numero = textBox7.Text;
            string idSucursal = textBox8.Text;
            string estatus = textBox9.Text;
            consulta = "INSERT INTO Membresia (nombre, apellidopaterno, apellidomaterno, calle, colonia, ciudad, numero, idSucursal, estatus) values('" + nombre + "', '" + apellidopaterno + "', '" + apellidomaterno + "' , '" + calle + "' , '" + colonia + "' , '" + ciudad + "' , '" + numero + "' , '" + idSucursal + "' , '" + estatus + "')";
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
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string nombre = textBox1.Text;
            string apellidopaterno = textBox2.Text;
            string apellidomaterno = textBox3.Text;
            string calle = textBox4.Text;
            string colonia = textBox5.Text;
            string ciudad = textBox6.Text;
            string numero = textBox7.Text;
            string idSucursal = textBox8.Text;
            string estatus = textBox9.Text;
            int idMembresia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Membresia SET nombre = '" + nombre + "',apellidopaterno = '" + apellidopaterno + "',apellidomaterno = '" + apellidomaterno + "' ,calle = '" + calle + "' ,colonia = '" + colonia + "' ,ciudad = '" + ciudad + "',numero = '" + numero + "',idSucursal = '" + idSucursal + "' ,estatus = '" + estatus + "'WHERE idMembresia = " + idMembresia.ToString();
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
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idMembresia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Membresia SET Estatus = False WHERE idMembresia = " + idMembresia.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
