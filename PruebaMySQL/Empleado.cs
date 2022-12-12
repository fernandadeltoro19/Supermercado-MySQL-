//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Empleado : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Empleado()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Empleado ORDER BY idEmpleado");

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            DevolucionProveedor compra = new DevolucionProveedor();
            compra.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Empresa marca = new Empresa();
            marca.Show();
        }

        private void EmpleadoCapacitacion_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string apellidopaterno = textBox2.Text;
            string apellidomaterno = textBox3.Text;
            string curp = textBox4.Text;
            string telefono = textBox5.Text;
            string calle = textBox6.Text;
            string numero = textBox7.Text;
            string colonia = textBox8.Text;
            string ciudad = textBox9.Text;
            consulta = "INSERT INTO Empleado (nombre, apellidopaterno, apellidomaterno, curp, telefono, calle, numero, colonia, ciudad ) values ('" + nombre + "', '" + apellidopaterno + "', '" + apellidomaterno + "', '" + curp + "', '" + telefono + "'  '" + calle + "', '" + numero + "', '" + colonia + "', '" + ciudad + "')";
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
            string curp = textBox4.Text;
            string telefono = textBox5.Text;
            string calle = textBox6.Text;
            string numero = textBox7.Text;
            string colonia = textBox8.Text;
            string ciudad = textBox9.Text;
            int idEmpleado = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Empleado SET nombre = '" + nombre + "',apellidopaterno = '" + apellidopaterno + "',apelllidomaterno = '" + apellidomaterno + "',curp = '" + curp + "',telefono = '" + telefono + "',calle = '" + calle + "',numero = '" + numero + "',colonia = '" + colonia + "',ciudad = '" + ciudad + "' WHERE idEmpleado = " + idEmpleado.ToString();
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
            int idEmpleado = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Empleado SET Estatus = False WHERE idEmpleado = " + idEmpleado.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
