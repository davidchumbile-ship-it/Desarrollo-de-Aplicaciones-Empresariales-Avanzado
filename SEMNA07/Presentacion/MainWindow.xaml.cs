using Entidades;
using Negocio;
using System.Windows;
using System.Windows.Controls;

namespace Presentacion
{
    public partial class MainWindow : Window
    {
        private readonly NPersona nPersona = new NPersona();
        private readonly NProducto nProducto = new NProducto();

        private int idPersonaSeleccionada;
        private int idProductoSeleccionado;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarPersonas();
            CargarProductos();
        }

        private static void MostrarError(Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void CargarPersonas()
        {
            try
            {
                dgPersonas.ItemsSource = nPersona.Buscar(txtBuscarPersona.Text);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private Persona LeerFormularioPersona()
        {
            return new Persona
            {
                IdPersona = idPersonaSeleccionada,
                Nombres = txtNombres.Text.Trim(),
                Apellidos = txtApellidos.Text.Trim(),
                Dni = txtDni.Text.Trim(),
                Telefono = string.IsNullOrWhiteSpace(txtTelefono.Text) ? null : txtTelefono.Text.Trim(),
                Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim()
            };
        }

        private void LimpiarPersona()
        {
            idPersonaSeleccionada = 0;
            txtNombres.Clear();
            txtApellidos.Clear();
            txtDni.Clear();
            txtTelefono.Clear();
            txtEmail.Clear();
            dgPersonas.SelectedItem = null;
            txtNombres.Focus();
        }

        private void BtnPersonaNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarPersona();
        }

        private void BtnPersonaRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nPersona.Registrar(LeerFormularioPersona());
                MessageBox.Show("Persona registrada correctamente.");
                LimpiarPersona();
                CargarPersonas();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void BtnPersonaActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nPersona.Actualizar(LeerFormularioPersona());
                MessageBox.Show("Persona actualizada correctamente.");
                LimpiarPersona();
                CargarPersonas();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void BtnPersonaEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (idPersonaSeleccionada <= 0)
            {
                MessageBox.Show("Seleccione una persona de la lista.");
                return;
            }

            if (MessageBox.Show("¿Desea eliminar a la persona seleccionada?", "Confirmar",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            try
            {
                nPersona.Eliminar(idPersonaSeleccionada);
                MessageBox.Show("Persona eliminada correctamente.");
                LimpiarPersona();
                CargarPersonas();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void TxtBuscarPersona_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded) CargarPersonas();
        }

        private void DgPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgPersonas.SelectedItem is not Persona persona) return;

            idPersonaSeleccionada = persona.IdPersona;
            txtNombres.Text = persona.Nombres;
            txtApellidos.Text = persona.Apellidos;
            txtDni.Text = persona.Dni;
            txtTelefono.Text = persona.Telefono;
            txtEmail.Text = persona.Email;
        }

        private void CargarProductos()
        {
            try
            {
                dgProductos.ItemsSource = nProducto.Buscar(txtBuscarProducto.Text);
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private Producto LeerFormularioProducto()
        {
            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                throw new ArgumentException("Ingrese un precio válido.");

            if (!short.TryParse(txtStock.Text, out short stock))
                throw new ArgumentException("Ingrese un stock válido (número entero).");

            return new Producto
            {
                IdProducto = idProductoSeleccionado,
                NombreProducto = txtNombreProducto.Text.Trim(),
                CantidadPorUnidad = string.IsNullOrWhiteSpace(txtCantidadPorUnidad.Text) ? null : txtCantidadPorUnidad.Text.Trim(),
                PrecioUnidad = precio,
                UnidadesEnExistencia = stock
            };
        }

        private void LimpiarProducto()
        {
            idProductoSeleccionado = 0;
            txtNombreProducto.Clear();
            txtCantidadPorUnidad.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            dgProductos.SelectedItem = null;
            txtNombreProducto.Focus();
        }

        private void BtnProductoNuevo_Click(object sender, RoutedEventArgs e)
        {
            LimpiarProducto();
        }

        private void BtnProductoRegistrar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nProducto.Registrar(LeerFormularioProducto());
                MessageBox.Show("Producto registrado correctamente.");
                LimpiarProducto();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void BtnProductoActualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                nProducto.Actualizar(LeerFormularioProducto());
                MessageBox.Show("Producto actualizado correctamente.");
                LimpiarProducto();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void BtnProductoEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (idProductoSeleccionado <= 0)
            {
                MessageBox.Show("Seleccione un producto de la lista.");
                return;
            }

            if (MessageBox.Show("¿Desea eliminar el producto seleccionado?", "Confirmar",
                    MessageBoxButton.YesNo, MessageBoxImage.Question) != MessageBoxResult.Yes)
                return;

            try
            {
                nProducto.Eliminar(idProductoSeleccionado);
                MessageBox.Show("Producto eliminado correctamente.");
                LimpiarProducto();
                CargarProductos();
            }
            catch (Exception ex)
            {
                MostrarError(ex);
            }
        }

        private void TxtBuscarProducto_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (IsLoaded) CargarProductos();
        }

        private void DgProductos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgProductos.SelectedItem is not Producto producto) return;

            idProductoSeleccionado = producto.IdProducto;
            txtNombreProducto.Text = producto.NombreProducto;
            txtCantidadPorUnidad.Text = producto.CantidadPorUnidad;
            txtPrecio.Text = producto.PrecioUnidad.ToString();
            txtStock.Text = producto.UnidadesEnExistencia.ToString();
        }
    }
}
