using System;
using System.Windows;
using SEMANA04.Data;

namespace SEMANA04.Views
{
    public partial class VentanaProductos : Window
    {
        private readonly DataService _dataService;

        public VentanaProductos()
        {
            InitializeComponent();
            _dataService = new DataService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgProductos.ItemsSource = _dataService.ObtenerProductos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
