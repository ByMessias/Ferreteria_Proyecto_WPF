using System.Collections.Generic;
using Ferreteria_Proyecto_WPF.Models;

namespace Ferreteria_Proyecto_WPF.Services
{
    public interface IClienteService
    {
        IEnumerable<Cliente> ObtenerClientes();
        Cliente ObtenerPorId(int idCliente);
        void Guardar(Cliente cliente);
        void Eliminar(int idCliente);

        //IEnumerable<RefItem> ObtenerGeneros();
       //IEnumerable<RefItem> ObtenerProvincias();
        //IEnumerable<RefItem> ObtenerCiudadesPorProvincia(int idProvincia);
    }
}
