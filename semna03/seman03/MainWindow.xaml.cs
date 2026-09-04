using System.Windows;

namespace seman03
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
            string usuario = txtUsuario.Text.Trim();
            string password = txtPassword.Password.Trim();

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese el usuario y la contraseña.", "Validación requerida",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (usuario == "admin" && password == "1234")
            {
                MenuWindow menu = new MenuWindow();
                menu.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Verifique sus credenciales.", "Error de validación",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}