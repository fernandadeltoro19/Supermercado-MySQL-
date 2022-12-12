using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class TransportePaaquete : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public TransportePaaquete()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM TransportePaquete ORDER BY idTransportePaquete");
        }

        private void TransportePaaquete_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string idTransporte = textBox1.Text;
            string idPaquete = textBox2.Text;
            string estatus = textBox3.Text;
            consulta = "INSERT INTO TransportePaquete (idTransporte, idPaquete, estatus) values('" + idTransporte + "', '" + idPaquete + "', '" + estatus + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idTransportePaquete = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE TransportePaquete SET Estatus = False WHERE idTransportePaquete = " + idTransportePaquete.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string idTransporte = textBox1.Text;
            string idPaquete = textBox2.Text;
            string estatus = textBox3.Text;
            int idTransportePaquete = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE TransportePaquete SET idTransporte = '" + idTransporte + "',idPaquete = '" + idPaquete + "', estatus = '" + estatus + "' WHERE idTransportePaquete = " + idTransportePaquete.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            SucursalEmpleadoo bode = new SucursalEmpleadoo();
            bode.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {

        }
    }
}
