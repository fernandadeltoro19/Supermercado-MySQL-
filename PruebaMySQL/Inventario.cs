//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace PruebaMySQL
{
    public partial class Inventario : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Inventario()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }

        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Inventario ORDER BY idInventario");
        }


        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            HorarioTrabajo hor = new HorarioTrabajo();
            hor.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Mantenimiento man = new Mantenimiento();
            man.Show();
        }

        private void Instrumento_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string nombre = textBox1.Text;
            string tipo = textBox2.Text;
            string fecha = textBox3.Text;
            consulta = "INSERT INTO Inventario (nombre, tipo, fecha) values('" + nombre + "', '" + tipo + "' , '" + fecha + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();


        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string nombre = textBox1.Text;
            string tipo = textBox2.Text;
            string fecha = textBox3.Text;
            int idInventario = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Inventario SET nombre = '" + nombre + "',tipo = '" + tipo + "',fecha = '" + fecha +"' WHERE idInvetario = " + idInventario.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idInstrumento = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Inventario SET Estatus = False WHERE idInstrumento = " + idInstrumento.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();

        }
    }
}
