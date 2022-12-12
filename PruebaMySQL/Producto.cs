//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{

    public partial class Producto : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Producto()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Producto ORDER BY idProducto");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Produccion produ = new Produccion();
            produ.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Proveedor provee = new Proveedor();
            provee.Show();
        }

        private void Producto_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string cantidad = textBox2.Text;
            string categoria = textBox3.Text;
            string idBodega = textBox4.Text;
            string idDevolucion = textBox5.Text;
            string idProduccion = textBox6.Text;
            string estatus = textBox7.Text;
            consulta = "INSERT INTO Producto (nombre, cantidad, categoria, idBodega, idDevolucion, idProduccion, estatus) values('" + nombre + "', '" + cantidad + "', '" + categoria + "', '" + idBodega + "', '" + idDevolucion + "', '" + idProduccion + "', '" + estatus +  "')";
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
            string cantidad = textBox2.Text;
            string categoria = textBox3.Text;
            string idBodega = textBox4.Text;
            string idDevolucion = textBox5.Text;
            string idProduccion = textBox6.Text;
            string estatus = textBox7.Text;
            int idProducto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Producto SET nombre = '" + nombre + "',cantidad = '" + cantidad + "',categoria = '" + categoria + "',idBodega = '" + idBodega + "', idDevolucion = '" + idDevolucion + "', idProduccion = '" + idProduccion + "', estatus = '" + estatus +"' WHERE idProducto = " + idProducto.ToString();
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
            int idProducto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Producto SET Estatus = False WHERE idProducto = " + idProducto.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
