using System;
using System.Windows;
using SEMANA04.Data;

namespace SEMANA04.Views
{
    public partial class VentanaCategorias : Window
    {
        private readonly DataService _dataService;

        public VentanaCategorias()
        {
            InitializeComponent();
            _dataService = new DataService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgCategorias.ItemsSource = _dataService.ObtenerCategorias();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
