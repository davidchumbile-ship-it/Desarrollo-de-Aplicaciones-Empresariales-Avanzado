using System;
using System.Collections.Generic;
using System.Data;
using System.Windows;
using System.Windows.Input;
using SEMANA03.Data;
using SEMANA03.Models;
using SEMANA03.Views;

namespace SEMANA03
{
    public partial class MainWindow : Window
    {
        private readonly DataService _dataService;

        public MainWindow()
        {
            InitializeComponent();
            _dataService = new DataService();

            // Carga inicial de la primera pestaña para una mejor experiencia de usuario
            CargarTab1StudentsDT();
        }

        #region TAB 1: Students con DataTable (Modo Desconectado)

        private void CargarTab1StudentsDT()
        {
            try
            {
                DataTable dt = _dataService.ObtenerEstudiantesDataTable();
                dgTab1Students.ItemsSource = dt.DefaultView;
                txtGlobalStatus.Text = $"[TAB 1 - Desconectado] Se cargaron {dt.Rows.Count} estudiantes usando SqlDataAdapter y DataTable.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estudiantes (DataTable): {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtGlobalStatus.Text = "Error al consultar la base de datos.";
            }
        }

        private void btnTab1Cargar_Click(object sender, RoutedEventArgs e)
        {
            CargarTab1StudentsDT();
        }

        private void btnTab1Limpiar_Click(object sender, RoutedEventArgs e)
        {
            dgTab1Students.ItemsSource = null;
            txtGlobalStatus.Text = "[TAB 1] Datos limpiados.";
        }

        #endregion

        #region TAB 2: Students con DataReader (Modo Conectado)

        private void CargarTab2StudentsDR()
        {
            try
            {
                List<Student> lista = _dataService.ObtenerEstudiantesDataReader();
                dgTab2Students.ItemsSource = lista;
                txtGlobalStatus.Text = $"[TAB 2 - Conectado] Se leyeron {lista.Count} estudiantes como objetos List<Student> usando SqlDataReader.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar estudiantes (DataReader): {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtGlobalStatus.Text = "Error al consultar la base de datos.";
            }
        }

        private void btnTab2Cargar_Click(object sender, RoutedEventArgs e)
        {
            CargarTab2StudentsDR();
        }

        private void btnTab2Limpiar_Click(object sender, RoutedEventArgs e)
        {
            dgTab2Students.ItemsSource = null;
            txtGlobalStatus.Text = "[TAB 2] Datos limpiados.";
        }

        #endregion

        #region TAB 3: Buscar Students por Nombre (DataReader)

        private void EjecutarBusquedaTab3()
        {
            try
            {
                string filtro = txtTab3Buscar.Text.Trim();
                List<Student> lista = _dataService.BuscarEstudiantesPorNombreDataReader(filtro);
                dgTab3Resultados.ItemsSource = lista;
                txtGlobalStatus.Text = $"[TAB 3 - Búsqueda] Filtro '{filtro}': {lista.Count} registro(s) encontrados con SqlDataReader.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error en la búsqueda: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtGlobalStatus.Text = "Error en la búsqueda.";
            }
        }

        private void btnTab3Buscar_Click(object sender, RoutedEventArgs e)
        {
            EjecutarBusquedaTab3();
        }

        private void btnTab3MostrarTodos_Click(object sender, RoutedEventArgs e)
        {
            txtTab3Buscar.Text = string.Empty;
            EjecutarBusquedaTab3();
        }

        private void txtTab3Buscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                EjecutarBusquedaTab3();
            }
        }

        #endregion

        #region TAB 4: Products con DataTable (Modo Desconectado)

        private void CargarTab4ProductsDT()
        {
            try
            {
                DataTable dt = _dataService.ObtenerProductosDataTable();
                dgTab4Products.ItemsSource = dt.DefaultView;
                txtGlobalStatus.Text = $"[TAB 4 - Desconectado] Se cargaron {dt.Rows.Count} productos usando SqlDataAdapter y DataTable.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos (DataTable): {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtGlobalStatus.Text = "Error al consultar la base de datos.";
            }
        }

        private void btnTab4Cargar_Click(object sender, RoutedEventArgs e)
        {
            CargarTab4ProductsDT();
        }

        private void btnTab4Limpiar_Click(object sender, RoutedEventArgs e)
        {
            dgTab4Products.ItemsSource = null;
            txtGlobalStatus.Text = "[TAB 4] Datos limpiados.";
        }

        #endregion

        #region TAB 5: Products con DataReader (Modo Conectado)

        private void CargarTab5ProductsDR()
        {
            try
            {
                List<Product> lista = _dataService.ObtenerProductosDataReader();
                dgTab5Products.ItemsSource = lista;
                txtGlobalStatus.Text = $"[TAB 5 - Conectado] Se leyeron {lista.Count} productos como objetos List<Product> usando SqlDataReader.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar productos (DataReader): {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                txtGlobalStatus.Text = "Error al consultar la base de datos.";
            }
        }

        private void btnTab5Cargar_Click(object sender, RoutedEventArgs e)
        {
            CargarTab5ProductsDR();
        }

        private void btnTab5Limpiar_Click(object sender, RoutedEventArgs e)
        {
            dgTab5Products.ItemsSource = null;
            txtGlobalStatus.Text = "[TAB 5] Datos limpiados.";
        }

        #endregion

        #region Botones para abrir Ventanas Secundarias Independientes

        private void btnAbrirWinStudentsDT_Click(object sender, RoutedEventArgs e)
        {
            VentanaStudentsDataTable win = new VentanaStudentsDataTable();
            win.Show();
        }

        private void btnAbrirWinStudentsDR_Click(object sender, RoutedEventArgs e)
        {
            VentanaStudentsDataReader win = new VentanaStudentsDataReader();
            win.Show();
        }

        private void btnAbrirWinBuscarStudents_Click(object sender, RoutedEventArgs e)
        {
            VentanaBuscarStudents win = new VentanaBuscarStudents();
            win.Show();
        }

        private void btnAbrirWinProductsDT_Click(object sender, RoutedEventArgs e)
        {
            VentanaProductsDataTable win = new VentanaProductsDataTable();
            win.Show();
        }

        private void btnAbrirWinProductsDR_Click(object sender, RoutedEventArgs e)
        {
            VentanaProductsDataReader win = new VentanaProductsDataReader();
            win.Show();
        }

        #endregion
    }
}