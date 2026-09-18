using System.Windows;
using SEMANA04.Views;

namespace SEMANA04
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MenuProductos_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new VentanaProductos();
            ventana.Show();
        }

        private void MenuCategorias_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new VentanaCategorias();
            ventana.Show();
        }

        private void MenuProveedoresGeneral_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new VentanaProveedoresListado();
            ventana.Show();
        }

        private void MenuProveedoresBuscar_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new VentanaProveedores();
            ventana.Show();
        }

        private void MenuDetallesPedidos_Click(object sender, RoutedEventArgs e)
        {
            var ventana = new VentanaDetallesPedidos();
            ventana.Show();
        }

        private void MenuSalir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}