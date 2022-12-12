//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace PruebaMySQL
{
    public partial class Caja : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Caja()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Caja ORDER BY idCaja");

        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Agenda bodega = new Agenda();
            bodega.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Capacitacion capa = new Capacitacion();
            capa.Show();
        }

        private void Caja_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Caja ORDER BY idCaja");
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string numero = textBox1.Text;
            string persona = textBox2.Text;
            string computadora = textBox3.Text;
            string idSucursal = textBox4.Text;
            string estatus = textBox5.Text;
            consulta = "INSERT INTO Caja (numero, persona, computadora, idSucursal, estatus) values('" + numero + "', '" + persona + "', '" + computadora + "', '" + idSucursal+ "' , '" + estatus + "')";
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
            string numer = textBox1.Text;
            string persona = textBox2.Text;
            string computadora = textBox3.Text;
            string idSucursal = textBox4.Text;
            string estatus = textBox5.Text;
            int idCaja = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Caja SET numer = '" + numer + "',persona = '" + persona + "',computadora = '" + computadora + "', idSucursal = '" + idSucursal + "',estatus = '" + estatus + "' WHERE idCaja = " + idCaja.ToString();
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
            int idCaja = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Caja SET Estatus = False WHERE idCaja = " + idCaja.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
