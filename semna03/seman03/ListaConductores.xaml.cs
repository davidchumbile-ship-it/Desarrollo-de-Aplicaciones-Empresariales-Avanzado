using System.Windows;

namespace seman03
{
    public partial class ListaConductores : Window
    {
        public ListaConductores()
        {
            InitializeComponent();
            dgConductores.ItemsSource = DatosSistema.Conductores;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombreConductor.Text.Trim();
            string licencia = txtLicencia.Text.Trim();
            string placa = txtPlaca.Text.Trim();
            string pesoMaximo = txtPesoMaximo.Text.Trim();
            string pesoVacio = txtPesoVacio.Text.Trim();

            if (string.IsNullOrEmpty(placa) || string.IsNullOrEmpty(pesoMaximo) || string.IsNullOrEmpty(pesoVacio))
            {
                MessageBox.Show("Por favor complete los campos obligatorios (Placa, Peso Máximo y Peso Vacío).",
                    "Validación", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            DatosSistema.Conductores.Add(new ConductorModel
            {
                NombreConductor = string.IsNullOrEmpty(nombre) ? "Sin asignar" : nombre,
                Licencia = string.IsNullOrEmpty(licencia) ? "Sin licencia" : licencia,
                Placa = placa,
                PesoMaximo = pesoMaximo.EndsWith("kg") ? pesoMaximo : pesoMaximo + " kg",
                PesoVacio = pesoVacio.EndsWith("kg") ? pesoVacio : pesoVacio + " kg"
            });

            MessageBox.Show("Conductor agregado con éxito.", "Registro exitoso",
                MessageBoxButton.OK, MessageBoxImage.Information);

            txtNombreConductor.Clear();
            txtLicencia.Clear();
            txtPlaca.Clear();
            txtPesoMaximo.Clear();
            txtPesoVacio.Clear();
        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
