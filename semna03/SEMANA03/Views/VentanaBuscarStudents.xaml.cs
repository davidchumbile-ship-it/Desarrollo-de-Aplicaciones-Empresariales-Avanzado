using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using SEMANA03.Data;
using SEMANA03.Models;

namespace SEMANA03.Views
{
    public partial class VentanaBuscarStudents : Window
    {
        private readonly DataService _dataService;

        public VentanaBuscarStudents()
        {
            InitializeComponent();
            _dataService = new DataService();
        }

        private void RealizarBusqueda()
        {
            try
            {
                string filtro = txtBuscar.Text.Trim();
                List<Student> lista = _dataService.BuscarEstudiantesPorNombreDataReader(filtro);
                dgResultados.ItemsSource = lista;
                txtEstado.Text = $"Búsqueda para '{filtro}': se encontraron {lista.Count} registro(s) con SqlDataReader.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante la búsqueda: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEstado.Text = "Error al ejecutar la búsqueda.";
            }
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            RealizarBusqueda();
        }

        private void btnMostrarTodos_Click(object sender, RoutedEventArgs e)
        {
            txtBuscar.Text = string.Empty;
            RealizarBusqueda();
        }

        private void txtBuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                RealizarBusqueda();
            }
        }
    }
}
