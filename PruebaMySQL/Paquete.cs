//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Paquete : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Paquete()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Paquete ORDER BY idPaquete");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            PagoServicio pago = new PagoServicio();
            pago.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Pasillo pedi = new Pasillo();
            pedi.Show();
        }

        private void Paquete_Load(object sender, EventArgs e)
        {
            MostrarDatos();

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string numero = textBox1.Text;
            string peso = textBox2.Text;
            string remitente = textBox3.Text;
            string destinatario = textBox4.Text;
            string idEnvio = textBox5.Text;
            string idPedidoLinea = textBox6.Text;
            string estatus = textBox8.Text;
            consulta = "INSERT INTO Paquete (numero, peso, remitente, destinatario, idEnvio, idPedido, idTransporte) values('" + numero + "', '" + peso + "', '" + remitente + "', '" + destinatario+"', '" +idEnvio + "', '" + idPedidoLinea + "', '"  + "', '" +estatus + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string numero = textBox1.Text;
            string peso = textBox2.Text;
            string remitente = textBox3.Text;
            string destinatario = textBox4.Text;
            string idEnvio = textBox5.Text;
            string idPedidoLinea = textBox6.Text;
            string estatus = textBox8.Text;
            int idPaquete = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Paquete SET numero = '" + numero + "',peso = '" + peso + "',remitente = '" + remitente + "',destinatario = '" + destinatario + "', idenvio = '" +idEnvio + "', idPedidoLinea = '" + idPedidoLinea + "', estatus = '" + estatus+ "' + WHERE idPaquete = " + idPaquete.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idPaquete = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Paquete SET Estatus = False WHERE idPaquete = " + idPaquete.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
