//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class SucursalEmpleado : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public SucursalEmpleado()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Vigilancia ORDER BY idVigilancia");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Venta producto = new Venta();
            producto.Show();
        }

        private void SucursalEmpleado_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string caseta = textBox1.Text;
            string total = textBox2.Text;
            string idSucursal = textBox3.Text;
            string estatus = textBox4.Text;
            consulta = "INSERT INTO Vigilancia (caseta, total, idSucursal, estatus) values('" + caseta + "', '" + total + "', '" + idSucursal + "' , '" + estatus + "')";
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
            string caseta = textBox1.Text;
            string total = textBox2.Text;
            string idSucursal = textBox3.Text;
            string estatus = textBox4.Text;
            int idVigilancia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Vigilancia SET caseta = '" + caseta + "',total = '" + total + "',idSucursal = '" + idSucursal  + "',estatus = '" + estatus + "'  WHERE idVigilancia = " + idVigilancia.ToString();
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
            int idVigilancia = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Vigilancia SET Estatus = False WHERE idVigilancia = " + idVigilancia.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();

        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            BodegaInventario bode = new BodegaInventario();
            bode.Show();
        }
    }
}
