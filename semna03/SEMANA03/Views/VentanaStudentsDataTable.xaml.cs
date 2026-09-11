using System;
using System.Data;
using System.Windows;
using SEMANA03.Data;

namespace SEMANA03.Views
{
    public partial class VentanaStudentsDataTable : Window
    {
        private readonly DataService _dataService;

        public VentanaStudentsDataTable()
        {
            InitializeComponent();
            _dataService = new DataService();
            CargarDatos();
        }

        private void CargarDatos()
        {
            try
            {
                DataTable tabla = _dataService.ObtenerEstudiantesDataTable();
                dgStudents.ItemsSource = tabla.DefaultView;
                txtEstado.Text = $"Se cargaron {tabla.Rows.Count} estudiantes exitosamente usando DataTable (Modo Desconectado).";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estudiantes: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtEstado.Text = "Error al consultar la base de datos.";
            }
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            dgStudents.ItemsSource = null;
            txtEstado.Text = "Datos limpiados.";
        }
    }
}
