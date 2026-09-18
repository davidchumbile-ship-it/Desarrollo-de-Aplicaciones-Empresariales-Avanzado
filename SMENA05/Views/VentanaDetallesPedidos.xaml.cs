using System;
using System.Windows;
using SEMANA04.Data;

namespace SEMANA04.Views
{
    public partial class VentanaDetallesPedidos : Window
    {
        private readonly DataService _dataService;

        public VentanaDetallesPedidos()
        {
            InitializeComponent();
            _dataService = new DataService();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dpFechaInicio.SelectedDate = new DateTime(1994, 1, 1);
            dpFechaFin.SelectedDate = new DateTime(1996, 12, 31);
            ConsultarDetalles();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            ConsultarDetalles();
        }

        private void ConsultarDetalles()
        {
            try
            {
                if (!dpFechaInicio.SelectedDate.HasValue || !dpFechaFin.SelectedDate.HasValue)
                {
                    MessageBox.Show("Seleccione ambas fechas.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                DateTime inicio = dpFechaInicio.SelectedDate.Value;
                DateTime fin = dpFechaFin.SelectedDate.Value;

                if (inicio > fin)
                {
                    MessageBox.Show("La fecha de inicio no puede ser mayor que la fecha fin.", "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                dgDetallesPedidos.ItemsSource = _dataService.ObtenerDetallesPorFecha(inicio, fin);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
