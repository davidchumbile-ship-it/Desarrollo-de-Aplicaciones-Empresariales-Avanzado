using System;
using System.Linq;
using System.Windows;

namespace seman03
{
    public partial class ReporteSalidasWindow : Window
    {
        public ReporteSalidasWindow()
        {
            InitializeComponent();
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgSalidas.ItemsSource = DatosSistema.Salidas;
            lblContador.Text = $"Total de registros: {DatosSistema.Salidas.Count}";
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string filtro = txtFiltroTransportista.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
            {
                CargarDatos();
                return;
            }

            var resultados = DatosSistema.Salidas
                .Where(s => s.NombreTransportista.Contains(filtro, StringComparison.OrdinalIgnoreCase))
                .ToList();

            dgSalidas.ItemsSource = resultados;
            lblContador.Text = $"Resultados encontrados: {resultados.Count} (Filtro: '{filtro}')";
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            txtFiltroTransportista.Clear();
            CargarDatos();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
