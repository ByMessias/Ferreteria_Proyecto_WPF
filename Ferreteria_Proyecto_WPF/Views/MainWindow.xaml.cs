using Ferreteria_Proyecto_WPF.Views;
using System.Windows;

namespace Ferreteria_Proyecto_WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarModulo(new DashboardView(), "Dashboard");
        }

        private void CargarModulo(object view, string titulo)
        {
            MainContent.Content = view;
            TituloModulo.Text = titulo;
            this.Title = $"Ferretería - {titulo}";
        }

        private void Dashboard_Click(object sender, RoutedEventArgs e)
        {
            CargarModulo(new DashboardView(), "Dashboard");
        }

        private void Clientes_Click(object sender, RoutedEventArgs e)
        {
            CargarModulo(new ClientesView(), "Clientes");
        }

        private void Productos_Click(object sender, RoutedEventArgs e)
        {
            CargarModulo(new ProductosView(), "Productos");
        }

        private void Facturacion_Click(object sender, RoutedEventArgs e)
        {
            CargarModulo(new FacturacionView(), "Facturación");
        }

        private void Reportes_Click(object sender, RoutedEventArgs e)
        {
            CargarModulo(new ReportesView(), "Reportes");
        }

        private void CerrarSesion_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
