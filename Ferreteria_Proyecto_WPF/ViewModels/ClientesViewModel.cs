using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Ferreteria_Proyecto_WPF.Helpers;
using Ferreteria_Proyecto_WPF.Models;
using Ferreteria_Proyecto_WPF.Services;
using Ferreteria_Proyecto_WPF.Views;

namespace Ferreteria_Proyecto_WPF.ViewModels
{
    public class ClientesViewModel : BaseViewModel
    {
        private readonly IClienteService _service;

        public ObservableCollection<Cliente> Clientes { get; } = new();
        public ObservableCollection<Cliente> ClientesFiltrados { get; } = new();

        private string _busqueda;
        public string Busqueda
        {
            get => _busqueda;
            set { _busqueda = value; OnPropertyChanged(); Filtrar(); }
        }

        public ICommand AgregarCommand { get; }
        public ICommand EditarCommand { get; }
        public ICommand EliminarCommand { get; }

        public ClientesViewModel() : this(new ClienteService()) { }

        public ClientesViewModel(IClienteService service)
        {
            _service = service;

            AgregarCommand  = new RelayCommand(_  => Agregar());
            EditarCommand   = new RelayCommand(x  => Editar(x as Cliente), x => x is Cliente);
            EliminarCommand = new RelayCommand(x  => Eliminar(x as Cliente), x => x is Cliente);

            Cargar();
        }

        private void Cargar()
        {
            Clientes.Clear();
            foreach (var c in _service.ObtenerClientes())
                Clientes.Add(c);
            Filtrar();
        }

        private void Filtrar()
        {
            var term = (Busqueda ?? string.Empty).Trim().ToLowerInvariant();
            var fuente = string.IsNullOrWhiteSpace(term)
                ? Clientes
                : new ObservableCollection<Cliente>(Clientes.Where(c =>
                       ($"{c.Nombres} {c.Apellidos}".Trim()).ToLowerInvariant().Contains(term)
                    || (c.CedulaRNC ?? "").ToLowerInvariant().Contains(term)
                    || (c.Email ?? "").ToLowerInvariant().Contains(term)
                    || (c.Telefono ?? "").ToLowerInvariant().Contains(term)
                    || (c.Provincia ?? "").ToLowerInvariant().Contains(term)
                    || (c.Ciudad ?? "").ToLowerInvariant().Contains(term)));

            ClientesFiltrados.Clear();
            foreach (var c in fuente) ClientesFiltrados.Add(c);
        }

        private void Agregar()
        {
            var vm  = new ClienteFormViewModel(_service);
            var win = new ClienteFormWindow(vm) { Owner = Application.Current.MainWindow };

            vm.RequestClose += r => { win.DialogResult = r; win.Close(); };
            if (win.ShowDialog() == true) Cargar();
        }

        private void Editar(Cliente cli)
        {
            if (cli is null) return;

            var vm  = new ClienteFormViewModel(_service, cli.IdCliente);
            var win = new ClienteFormWindow(vm) { Owner = Application.Current.MainWindow };

            vm.RequestClose += r => { win.DialogResult = r; win.Close(); };
            if (win.ShowDialog() == true) Cargar();
        }

        private void Eliminar(Cliente cli)
        {
            if (cli is null) return;
            _service.Eliminar(cli.IdCliente);
            Cargar();
        }
    }
}
