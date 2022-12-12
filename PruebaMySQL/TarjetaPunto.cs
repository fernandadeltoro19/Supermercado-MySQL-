//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class TarjetaPunto : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public TarjetaPunto()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM TarjetaPunto ORDER BY idTarjetaPunto");
        }
        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sucursal producto = new Sucursal();
            producto.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Transporte sucursal = new Transporte();
            sucursal.Show();
        }

        private void ProductoVenta_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string punto = textBox1.Text;
            string beneficios = textBox2.Text;
            string idSucursal = textBox3.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO TarjetaPunto (punto, beneficios, idSucursal, estatus) values('" + punto + "', '" + beneficios + "', '" + idSucursal + "' , '" + estatus + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string punto = textBox1.Text;
            string beneficios = textBox2.Text;
            string idSucursal = textBox3.Text;
            string estatus = textBox4.Text;
            int idTarjetaPunto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE TarjetaPunto SET punto = '" + punto + "',beneficios = '" + beneficios + "',idSucursal = '" + idSucursal + "',estatus = '" + estatus + "' WHERE idTarjetaPunto = " + idTarjetaPunto.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idTarjetaPunto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE TarjetaPunto SET Estatus = False WHERE idTarjetaPunto = " + idTarjetaPunto.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


        }
    }
}
