//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Cliente : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Cliente()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Cliente ORDER BY idCliente");

        }


        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Caja caja = new Caja();
            caja.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Compra Compra = new Compra();
            Compra.Show();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = textBox1.Text;
            string apellidoPaterno = textBox2.Text;
            string apellidoMaterno = textBox3.Text;
            string telefono = textBox4.Text;
            string idMembresia = textBox5.Text;
            string idTarjetaPunto = textBox6.Text;
            string Estatus = textBox7.Text;
            consulta = "INSERT INTO Cliente (nombre, apellidoPaterno, apellidoMaterno, telefono, calle, idMembresia, idTarjetaPunto, Estatus) values('" + nombre + "', '" + apellidoPaterno + "', '" + apellidoMaterno + "', '" + telefono + "', '" + idMembresia + "', '" +idTarjetaPunto +"', '" +Estatus + "')";
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
            string apellidoPaterno = textBox2.Text;
            string apellidoMaterno = textBox3.Text;
            string telefono = textBox4.Text;
            string idMembresia = textBox5.Text;
            string idTarjetaPunto = textBox6.Text;
            string Estatus = textBox7.Text;
            int idCliente = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Cliente SET nombre = '" + nombre + "',apellidoPaterno = '" + apellidoPaterno + "',apellidoMaterno = '" + apellidoMaterno + "',telefono = '" + telefono + "', idMembresia = '" +idMembresia + "', idTarjetaPunto = '" + idTarjetaPunto + "', Estatus = '" + Estatus +"' WHERE idCliente = " + idCliente.ToString();
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
            int idCliente = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Cliente SET Estatus = False WHERE idCliente = " + idCliente.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
