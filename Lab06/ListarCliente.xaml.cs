using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace Lab06
{
    /// <summary>
    /// Lógica de interacción para ListarCliente.xaml
    /// </summary>
    public partial class ListarCliente : Window
    {
        public ListarCliente()
        {
            InitializeComponent();
        }

        private void btnListarCategorias_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string cadena = "Data Source=DESKTOP-QHI4LVF; Initial Catalog=Neptuno; User ID=usuario01; Password=142857**;";
                using (SqlConnection connection = new SqlConnection(cadena))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("ListarCategorias", connection);
                    command.CommandType = CommandType.StoredProcedure;

                    List<Categoria> listaCategoria = new List<Categoria>();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Categoria categoria = new Categoria
                        {
                            IdCategoria = reader["idcategoria"].ToString(),
                            NombreCategoria = reader["nombrecategoria"].ToString(),
                            Descripcion = reader["descripcion"].ToString(),
                            Activo = reader["Activo"].ToString(),
                            CodCategoria = reader["CodCategoria"].ToString()
                        };
                        listaCategoria.Add(categoria);
                    }

                    dgvCategorias.ItemsSource = listaCategoria;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        public class Categoria
        {
            public string IdCategoria { get; set; }
            public string NombreCategoria { get; set; }
            public string Descripcion { get; set; }
            public string Activo { get; set; }
            public string CodCategoria { get; set; }
        }
    }
}
