//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class DevolucionProveedor : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public DevolucionProveedor()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM DevolucionProveedor ORDER BY idDevolucionProveedor");

        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Devolucion devo = new Devolucion();
            devo.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Empleado emp = new Empleado();
            emp.Show();
        }

        private void Doctor_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string producto = textBox1.Text;
            string cantidad = textBox2.Text;
            string cantidadmonetaria = textBox3.Text;
            string fecha = textBox4.Text;
            string idProveedor = textBox5.Text;
            string estatus = textBox6.Text;
            consulta = "INSERT INTO DevolucionProveedor (producto, cantidad, cantidadmonetaria, fecha, idProveedor, estatus) values('" + producto + "', '" + cantidad + "', '" + cantidadmonetaria + "', '" + fecha + "', '" + idProveedor + "' , '" + estatus + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string producto = textBox1.Text;
            string cantidad = textBox2.Text;
            string cantidadmonetaria = textBox3.Text;
            string fecha = textBox4.Text;
            string idProveedor = textBox5.Text;
            string estatus = textBox6.Text;
            int idDevolucionProveedor = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE DevolucionProveedor SET producto = '" + producto + "',cantidad = '" + cantidad + "',cantidadmonetaria = '" + cantidadmonetaria + "',fecha = '" + fecha + "',idProveedor = '" + idProveedor +"',estatus = '" + estatus + "' WHERE idDevolucionProveedor = " + idDevolucionProveedor.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idDevolucionProveedor = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE DevolucionProveedor SET Estatus = False WHERE idDevolucionProveedor = " + idDevolucionProveedor.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
