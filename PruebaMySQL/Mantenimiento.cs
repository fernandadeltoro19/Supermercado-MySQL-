//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Mantenimiento : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Mantenimiento()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Mantenimiento ORDER BY idMantenimiento");
        }


        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Inventario ins = new Inventario();
            ins.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Marca marca = new Marca();
            marca.Show();
        }

        private void Mantenimiento_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string persona = textBox1.Text;
            string tipo = textBox2.Text;
            string fecha = textBox3.Text;
            string idSucursal = textBox4.Text;
            string estatus = textBox5.Text;
            consulta = "INSERT INTO Mantenimiento (persona, tipo, fecha, idSucursal, estatus) values('" + persona + "', '" + tipo + "', '" + fecha + "', '" + idSucursal + "', '"+estatus+ "')";
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
            string persona = textBox1.Text;
            string tipo = textBox2.Text;
            string fecha = textBox3.Text;
            string idSucursal = textBox4.Text;
            string estatus = textBox5.Text;
            int idMantenimiento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Mantenimiento SET persona = '" + persona + "',tipo = '" + tipo + "',fecha = '" + fecha + "',idSucursal = '" + idSucursal + "', estatus = '" +estatus + "' WHERE idMantenimiento = " + idMantenimiento.ToString();
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
            int idMantenimiento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Mantenimiento SET Estatus = False WHERE idMantenimiento = " + idMantenimiento.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
