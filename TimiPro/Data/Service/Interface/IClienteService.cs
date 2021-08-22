using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimiPro.Models;

namespace TimiPro.Data.Service.Interface
{
    public interface IClienteService
    {
        public IEnumerable<Cliente> ListarClientes();
        public Cliente ClientesPeloID(int id);
        public void Adicionar(Cliente cliente);
        public void Editar(Cliente cliente);
        public void Excluir(int id);
        public IEnumerable<Cliente> ListarClientesPeloID(int id);
        public bool Email(Cliente cliente);
        public bool CPF(Cliente cliente);
    }
}
