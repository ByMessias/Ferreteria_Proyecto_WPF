using Ferreteria_Proyecto_WPF.Models;
using Ferreteria_Proyecto_WPF.Services;
using Ferreteria_Proyecto_WPF.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Linq;

namespace Ferreteria_Proyecto_WPF.ViewModels
{
    public class ClientesViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Cliente> Clientes { get; set; } = new();
        public ObservableCollection<Cliente> ClientesFiltrados { get; set; } = new();

        private string _busqueda;
        public string Busqueda
        {
            get => _busqueda;
            set
            {
                _busqueda = value;
                OnPropertyChanged();
                FiltrarClientes();
            }
        }

        public ICommand EliminarCommand { get; }
        public ICommand EditarCommand { get; }
        public ICommand AgregarCommand { get; }

        public ClientesViewModel()
        {
            CargarClientes();

            EliminarCommand = new RelayCommand(EliminarCliente);
            EditarCommand = new RelayCommand(EditarCliente);
            AgregarCommand = new RelayCommand(AgregarCliente);
        }

        private void CargarClientes()
        {
            var clientes = ClienteService.ObtenerClientes();
            Clientes.Clear();
            foreach (var cliente in clientes)
                Clientes.Add(cliente);

            FiltrarClientes();
        }

        private void FiltrarClientes()
        {
            var filtro = string.IsNullOrWhiteSpace(Busqueda)
                ? Clientes
                : new ObservableCollection<Cliente>(
                    Clientes.Where(c =>
                        $"{c.Nombre} {c.Apellido}".ToLower().Contains(Busqueda.ToLower()) ||
                        (c.Cedula?.ToLower().Contains(Busqueda.ToLower()) ?? false)
                    )
                );

            ClientesFiltrados.Clear();
            foreach (var c in filtro)
                ClientesFiltrados.Add(c);
        }

        private void EliminarCliente(object clienteObj)
        {
            // TODO: lógica de eliminación real con confirmación
            if (clienteObj is Cliente cliente)
                ClientesFiltrados.Remove(cliente);
        }

        private void EditarCliente(object clienteObj)
        {
            // TODO: lógica de edición (abrir modal, formulario, etc.)
            if (clienteObj is Cliente cliente)
            {
                // Aquí puedes abrir ventana de edición
            }
        }

        private void AgregarCliente(object obj)
        {
            // TODO: lógica de agregar nuevo cliente
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = "") =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}