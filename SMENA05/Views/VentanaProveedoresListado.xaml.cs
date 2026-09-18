using System;
using System.Windows;
using SEMANA04.Data;

namespace SEMANA04.Views
{
    public partial class VentanaProveedoresListado : Window
    {
        private readonly DataService _dataService;

        public VentanaProveedoresListado()
        {
            InitializeComponent();
            _dataService = new DataService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgProveedores.ItemsSource = _dataService.ObtenerProveedores();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
