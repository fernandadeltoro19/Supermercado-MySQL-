//LIBRERIAS
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;


namespace PruebaMySQL
{
    public partial class Puesto : Form
    {
        SqlConnection conexion;
        string consulta;
        SqlCommand comando;
        public Puesto()
        {
            InitializeComponent();
            string cadena = @"Server=localhost\SQLEXPRESS;Database=Supermercado;Trusted_Connection=True";
            conexion = new SqlConnection(cadena);
            //conexion.Open();
        }
        private void MostrarDatos()
        {
            dataGridView1.DataSource = ConexionMySql.ejecutaConsultaSelect("SELECT *FROM Puesto ORDER BY idPuesto");
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            this.Hide();
            Proveedor provee = new Proveedor();
            provee.Show();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            this.Hide();
            Queja rece = new Queja();
            rece.Show();
        }

        private void Puesto_Load(object sender, EventArgs e)
        {
            MostrarDatos();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Agregar
            string tipopuesto = textBox1.Text;
            string idEmpleado = textBox2.Text;
            string estatus = textBox3.Text;
            consulta = "INSERT INTO Puesto (tipopuesto, idEmpleado, estatus) values('" + tipopuesto + "', '" + "', '" + idEmpleado + "', '" + estatus + "')";
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            //Modificar
            string tipopuesto = textBox1.Text;
            string idEmpleado = textBox2.Text;
            string estatus = textBox3.Text;
            int idPuesto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            consulta = "UPDATE Puesto SET tipopuesto = '" + tipopuesto +  "',idEmpleado = '" + idEmpleado + "',estatus = '" + estatus + "' WHERE idPuesto = " + idPuesto.ToString();
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();


            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
          
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            //Borrar
            int idPuesto = (int)dataGridView1.SelectedRows[0].Cells[0].Value;
            //consulta = "DELETE FROM HOTEL WHERE idHotel = " + idHotel.ToString();
            consulta = "UPDATE Puesto SET Estatus = False WHERE idPuesto = " + idPuesto.ToString(); ;
            ConexionMySql.ejecutaConsulta(consulta);
            MostrarDatos();
        }
    }
}
