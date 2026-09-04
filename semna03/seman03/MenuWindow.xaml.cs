using System.Windows;

namespace seman03
{
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        // Operaciones
        private void Salida_Click(object sender, RoutedEventArgs e)
        {
            RegistroSalida ventana = new RegistroSalida();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void Ingresos_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Módulo de Registro de Ingresos.\n(Próxima implementación de la empresa)",
                "Operaciones - Ingresos", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Mantenimientos
        private void Conductores_Click(object sender, RoutedEventArgs e)
        {
            ListaConductores ventana = new ListaConductores();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void Camiones_Click(object sender, RoutedEventArgs e)
        {
            RegistroCamion ventana = new RegistroCamion();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void Transportistas_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mantenimiento de Empresas Transportistas.\n(Gestión de RUC, Razón Social y Estado)",
                "Mantenimientos - Transportistas", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Productos_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Mantenimiento del Catálogo de Productos y Mercaderías.",
                "Mantenimientos - Productos", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Reportes
        private void ReporteSalidas_Click(object sender, RoutedEventArgs e)
        {
            ReporteSalidasWindow ventana = new ReporteSalidasWindow();
            ventana.Owner = this;
            ventana.ShowDialog();
        }

        private void Cargas_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Módulo de Reportes: Cargas y Distribución por Zona.",
                "Reportes - Cargas", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ReporteIngresos_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Módulo de Reportes: Historial de Ingresos de Vehículos.",
                "Reportes - Ingresos", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        // Sesión
        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void Salir_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}