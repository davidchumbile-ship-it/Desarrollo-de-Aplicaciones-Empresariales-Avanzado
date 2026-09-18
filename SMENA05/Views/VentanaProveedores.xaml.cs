using System;
using System.Windows;
using SEMANA04.Data;

namespace SEMANA04.Views
{
    public partial class VentanaProveedores : Window
    {
        private readonly DataService _dataService;

        public VentanaProveedores()
        {
            InitializeComponent();
            _dataService = new DataService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            EjecutarBusqueda();
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            EjecutarBusqueda();
        }

        private void BtnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtNombreContacto.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            EjecutarBusqueda();
        }

        private void EjecutarBusqueda()
        {
            try
            {
                string nombreContacto = txtNombreContacto.Text?.Trim() ?? string.Empty;
                string ciudad = txtCiudad.Text?.Trim() ?? string.Empty;
                dgProveedores.ItemsSource = _dataService.BuscarProveedores(nombreContacto, ciudad);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
