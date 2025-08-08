using System.Windows;
using System.Windows.Input;
using Ferreteria_Proyecto_WPF.Views;
using Ferreteria_Proyecto_WPF.Themes;

namespace Ferreteria_Proyecto_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetModule(new DashboardView(), "Dashboard");
        }

        private void ThemesToggle_Click(object sender, RoutedEventArgs e)
        {
            var isDark = ThemesToggle.IsChecked == true;
            ThemesController.SetTheme(isDark ? ThemesController.ThemeTypes.Dark
                                             : ThemesController.ThemeTypes.Light);
        }

        private void SetModule(object view, string title)
        {
            MainFrame.Navigate(view);
            TituloModulo.Text = title;
            this.Title = $"Ferretería - {title}";
        }

        private void Dashboard_Click(object s, RoutedEventArgs e) => SetModule(new DashboardView(), "Dashboard");
        private void Clientes_Click(object s, RoutedEventArgs e) => SetModule(new ClientesView(), "Clientes");
        private void Productos_Click(object s, RoutedEventArgs e) => SetModule(new ProductosView(), "Productos");
        private void Facturacion_Click(object s, RoutedEventArgs e) => SetModule(new FacturacionView(), "Facturación");
        private void Reportes_Click(object s, RoutedEventArgs e) => SetModule(new ReportesView(), "Reportes");

        private void Close_Click(object s, RoutedEventArgs e) => Close();
        private void Minimize_Click(object s, RoutedEventArgs e) => WindowState = WindowState.Minimized;
        private void Restore_Click(object s, RoutedEventArgs e) => WindowState = (WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;

        // Drag window desde el header
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (e.ButtonState == MouseButtonState.Pressed) DragMove();
        }
    }
}
