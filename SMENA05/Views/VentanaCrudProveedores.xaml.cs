using System.Windows;
using System.Windows.Controls;
using SEMANA04.Data;
using SEMANA04.Models;

namespace SEMANA04.Views
{
    public partial class VentanaCrudProveedores : Window
    {
        private DataService dataService;
        private bool esNuevo = false;

        public VentanaCrudProveedores()
        {
            InitializeComponent();
            dataService = new DataService();
            CargarDatos();
        }

        private void CargarDatos()
        {
            dgProveedores.ItemsSource = dataService.ObtenerProveedoresActivos();
            LimpiarFormulario();
        }

        private void LimpiarFormulario()
        {
            txtId.Text = string.Empty;
            txtCompania.Text = string.Empty;
            txtContacto.Text = string.Empty;
            txtCargo.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtRegion.Text = string.Empty;
            txtCodPostal.Text = string.Empty;
            txtPais.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtFax.Text = string.Empty;
            esNuevo = false;
            txtId.IsEnabled = false;
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarFormulario();
            esNuevo = true;
            txtId.IsEnabled = true;
        }

        private void BtnGuardar_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text) || string.IsNullOrWhiteSpace(txtCompania.Text))
            {
                MessageBox.Show("El ID y la Compañía son obligatorios.");
                return;
            }

            if (!int.TryParse(txtId.Text, out int idProveedor))
            {
                MessageBox.Show("El ID debe ser un número válido.");
                return;
            }

            var proveedor = new Proveedor
            {
                idProveedor = idProveedor,
                nombreCompañia = txtCompania.Text,
                nombrecontacto = txtContacto.Text,
                cargocontacto = txtCargo.Text,
                direccion = txtDireccion.Text,
                ciudad = txtCiudad.Text,
                region = txtRegion.Text,
                codPostal = txtCodPostal.Text,
                pais = txtPais.Text,
                telefono = txtTelefono.Text,
                fax = txtFax.Text
            };

            if (esNuevo)
            {
                dataService.InsertarProveedor(proveedor);
            }
            else
            {
                dataService.ActualizarProveedor(proveedor);
            }

            CargarDatos();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgProveedores.SelectedItem is Proveedor p)
            {
                dataService.EliminarProveedor(p.idProveedor);
                CargarDatos();
            }
            else
            {
                MessageBox.Show("Seleccione un proveedor para eliminar.");
            }
        }

        private void DgProveedores_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProveedores.SelectedItem is Proveedor p)
            {
                txtId.Text = p.idProveedor.ToString();
                txtCompania.Text = p.nombreCompañia;
                txtContacto.Text = p.nombrecontacto;
                txtCargo.Text = p.cargocontacto;
                txtDireccion.Text = p.direccion;
                txtCiudad.Text = p.ciudad;
                txtRegion.Text = p.region;
                txtCodPostal.Text = p.codPostal;
                txtPais.Text = p.pais;
                txtTelefono.Text = p.telefono;
                txtFax.Text = p.fax;
                esNuevo = false;
                txtId.IsEnabled = false;
            }
        }
    }
}
