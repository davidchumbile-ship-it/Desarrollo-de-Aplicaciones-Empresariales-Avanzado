using System.Windows;

namespace seman03
{
    public partial class RegistroCamion : Window
    {
        public RegistroCamion()
        {
            InitializeComponent();
            dgCamiones.ItemsSource = DatosSistema.Camiones;
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string placa = txtPlaca.Text.Trim();
            string pesoMaximo = txtPesoMaximo.Text.Trim();
            string pesoVacio = txtPesoVacio.Text.Trim();

            if (string.IsNullOrEmpty(placa) || string.IsNullOrEmpty(pesoMaximo) || string.IsNullOrEmpty(pesoVacio))
            {
                MessageBox.Show("Por favor complete todos los campos (Placa, Peso Máximo y Peso Vacío).",
                    "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DatosSistema.Camiones.Add(new CamionModel
            {
                Placa = placa.ToUpper(),
                PesoMaximo = pesoMaximo.EndsWith("kg") ? pesoMaximo : pesoMaximo + " kg",
                PesoVacio = pesoVacio.EndsWith("kg") ? pesoVacio : pesoVacio + " kg"
            });

            MessageBox.Show($"Camión con placa {placa.ToUpper()} guardado correctamente.", "Éxito",
                MessageBoxButton.OK, MessageBoxImage.Information);

            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            txtPlaca.Clear();
            txtPesoMaximo.Clear();
            txtPesoVacio.Clear();
        }
    }
}