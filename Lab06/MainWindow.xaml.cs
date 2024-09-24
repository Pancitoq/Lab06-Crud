using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab06
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CrearCategoria_Click(object sender, RoutedEventArgs e)
        {
            CrearCliente crearClienteWindow = new CrearCliente();
            crearClienteWindow.Show();  
        }

        private void ActualizarCategoria_Click(object sender, RoutedEventArgs e)
        {
            ActualizarCliente actualizarClienteWindow = new ActualizarCliente();
            actualizarClienteWindow.Show();
        }

        private void BorrarCategoria_Click(object sender, RoutedEventArgs e)
        {
            BorrarCliente borrarClienteWindow = new BorrarCliente();
            borrarClienteWindow.Show();
        }

        private void ListarCategoria_Click(object sender, RoutedEventArgs e)
        {
            ListarCliente listarClienteWindow = new ListarCliente();
            listarClienteWindow.Show();
        }
    }
}