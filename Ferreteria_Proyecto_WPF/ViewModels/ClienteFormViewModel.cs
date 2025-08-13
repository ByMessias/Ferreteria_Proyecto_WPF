using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Ferreteria_Proyecto_WPF.Helpers;
using Ferreteria_Proyecto_WPF.Models;
using Ferreteria_Proyecto_WPF.Services;

namespace Ferreteria_Proyecto_WPF.ViewModels
{
    public class ClienteFormViewModel : BaseViewModel
    {
        private readonly IClienteService _service;

        public string Title { get; set; } = "Cliente";
        private bool _isBusy;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged(); } }

        public Cliente Entidad { get; set; } = new Cliente();

        //public ObservableCollection<RefItem> Generos { get; } = new();
        //public ObservableCollection<RefItem> Provincias { get; } = new();
        //public ObservableCollection<RefItem> Ciudades { get; } = new();

        public ICommand GuardarCommand { get; }
        public ICommand CancelarCommand { get; }

        public event Action<bool> RequestClose;

        public ClienteFormViewModel(IClienteService service)
        {
            _service = service;
            Title = "Nuevo cliente";
            GuardarCommand = new RelayCommand(_ => Guardar());
            CancelarCommand = new RelayCommand(_ => RequestClose?.Invoke(false));
            CargarCatalogos();
        }

        public ClienteFormViewModel(IClienteService service, int idCliente) : this(service)
        {
            Title = "Editar cliente";
            CargarCliente(idCliente);
        }

        private void CargarCliente(int id)
        {
            var cli = _service.ObtenerPorId(id);
            if (cli != null) Entidad = cli;
            OnPropertyChanged(nameof(Entidad));
            CargarCiudades();
        }

        private void CargarCatalogos()
        {
            Generos.Clear();
            foreach (var g in _service.ObtenerGeneros()) Generos.Add(g);

            Provincias.Clear();
            foreach (var p in _service.ObtenerProvincias()) Provincias.Add(p);

            CargarCiudades();
        }

        private void CargarCiudades()
        {
            Ciudades.Clear();
            if (Entidad.IdProvincia.HasValue)
                foreach (var c in _service.ObtenerCiudadesPorProvincia(Entidad.IdProvincia.Value))
                    Ciudades.Add(c);
        }

        private void Guardar()
        {
            IsBusy = true;
            try
            {
                _service.Guardar(Entidad);
                RequestClose?.Invoke(true);
            }
            finally { IsBusy = false; }
        }
    }
}
