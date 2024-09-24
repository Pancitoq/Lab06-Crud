using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Lab06
{
    /// <summary>
    /// Lógica de interacción para CrearCliente.xaml
    /// </summary>
    public partial class CrearCliente : Window
    {
        public CrearCliente()
        {
            InitializeComponent();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "Data Source=DESKTOP-QHI4LVF; Initial Catalog=Neptuno; User ID=usuario01; Password=142857**;";
                using (SqlConnection connection = new SqlConnection(cadena))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("CrearCategoria", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        SqlParameter sqlParameter1 = new SqlParameter("@idcategoria", SqlDbType.Int);
                        sqlParameter1.Value = Convert.ToInt32(txtIdCategoria.Text);
                        command.Parameters.Add(sqlParameter1);

                        SqlParameter sqlParameter2 = new SqlParameter("@nombrecategoria", SqlDbType.NVarChar, 50);
                        sqlParameter2.Value = txtNombreCategoria.Text;
                        command.Parameters.Add(sqlParameter2);

                        SqlParameter sqlParameter3 = new SqlParameter("@descripcion", SqlDbType.NVarChar, 50);
                        sqlParameter3.Value = txtDescripcion.Text;
                        command.Parameters.Add(sqlParameter3);

                        SqlParameter sqlParameter4 = new SqlParameter("@CodCategoria", SqlDbType.NVarChar, 50);
                        sqlParameter4.Value = txtCodCategoria.Text;
                        command.Parameters.Add(sqlParameter4);

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Categoria registrada correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al registrar la categoria.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }
    }
}

