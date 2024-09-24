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
    /// Lógica de interacción para BorrarCliente.xaml
    /// </summary>
    public partial class BorrarCliente : Window
    {
        public BorrarCliente()
        {
            InitializeComponent();
        }

        private void btnBorrarCategoria_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "Data Source=DESKTOP-QHI4LVF; Initial Catalog=Neptuno; User ID=usuario01; Password=142857**;";
                using (SqlConnection connection = new SqlConnection(cadena))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("BorrarCategoria", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;


                        SqlParameter sqlParameter1 = new SqlParameter("@idcategoria", SqlDbType.Int);
                        sqlParameter1.Value = Convert.ToInt32(txtIdCategoria.Text);
                        command.Parameters.Add(sqlParameter1);

                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Categoria borrada correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al borrar la categoria.");
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

