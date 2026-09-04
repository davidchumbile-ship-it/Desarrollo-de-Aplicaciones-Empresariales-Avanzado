using System;
using System.Windows;
using System.Windows.Controls;

namespace seman03
{
    public partial class RegistroSalida : Window
    {
        public RegistroSalida()
        {
            InitializeComponent();
            dgRegistros.ItemsSource = DatosSistema.Salidas;
            txtFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
        }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            string tipoDoc = (cmbTipoDocumento.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Guía";
            string numDoc = txtNumeroDocumento.Text.Trim();
            string peso = txtPeso.Text.Trim();
            string tipoAuto = txtTipoAuto.Text.Trim();
            string nombreTransp = txtNombreTransportista.Text.Trim();
            string fechaHora = txtFechaHora.Text.Trim();
            string pesoIngreso = txtPesoIngreso.Text.Trim();
            string pesoSalida = txtPesoSalida.Text.Trim();

            if (string.IsNullOrEmpty(numDoc) || string.IsNullOrEmpty(peso) ||
                string.IsNullOrEmpty(tipoAuto) || string.IsNullOrEmpty(nombreTransp) ||
                string.IsNullOrEmpty(pesoIngreso) || string.IsNullOrEmpty(pesoSalida))
            {
                MessageBox.Show("Por favor complete todos los campos requeridos.", "Validación",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string fechaSolo = DateTime.Now.ToString("dd/MM/yyyy");
            if (fechaHora.Contains(" "))
            {
                fechaSolo = fechaHora.Split(' ')[0];
            }

            SalidaModel item = new SalidaModel
            {
                TipoDocumento = tipoDoc,
                NumeroDocumento = numDoc,
                Peso = peso.EndsWith("kg") ? peso : peso + " kg",
                TipoAuto = tipoAuto,
                NombreTransportista = nombreTransp,
                Fecha = fechaSolo,
                FechaYHora = fechaHora,
                PesoIngreso = pesoIngreso.EndsWith("kg") ? pesoIngreso : pesoIngreso + " kg",
                PesoSalida = pesoSalida.EndsWith("kg") ? pesoSalida : pesoSalida + " kg"
            };

            DatosSistema.Salidas.Add(item);

            MessageBox.Show("Registro de salida guardado correctamente.", "Éxito",
                MessageBoxButton.OK, MessageBoxImage.Information);

            LimpiarCampos();
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            LimpiarCampos();
        }

        private void LimpiarCampos()
        {
            cmbTipoDocumento.SelectedIndex = 0;
            txtNumeroDocumento.Clear();
            txtPeso.Clear();
            txtTipoAuto.Clear();
            txtNombreTransportista.Clear();
            txtFechaHora.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
            txtPesoIngreso.Clear();
            txtPesoSalida.Clear();
        }
    }
}