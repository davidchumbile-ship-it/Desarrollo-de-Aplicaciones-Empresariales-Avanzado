using System;
using System.Collections.Generic;
using System.Windows;
using SEMANA03.Data;
using SEMANA03.Models;

namespace SEMANA03.Views
{
    public partial class VentanaProductsDataReader : Window
    {
        private readonly DataService _dataService;

        public VentanaProductsDataReader()
        {
            InitializeComponent();
            _dataService = new DataService();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                List<Product> lista = _dataService.ObtenerProductosDataReader();
                dgProducts.ItemsSource = lista;
                txtEstado.Text = $"Se cargaron {lista.Count} objetos Product usando SqlDataReader (Modo Conectado).";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos con DataReader: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEstado.Text = "Error al consultar la base de datos.";
            }
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            dgProducts.ItemsSource = null;
            txtEstado.Text = "Datos limpiados.";
        }
    }
}
