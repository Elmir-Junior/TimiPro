using System.Collections.Generic;
using System.Linq;
using TimiPro.Data.EF;
using TimiPro.Data.Service.Interface;
using TimiPro.Models;

namespace TimiPro.Data.Service
{
    public class ClienteService : IClienteService
    {
        readonly EFDBContext _context;

        public ClienteService(EFDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> ListarClientes()
        {
            return _context.clientes.ToList();
        }

        public Cliente ClientesPeloID(int id)
        {
            return _context.clientes.Find(id);
        }
        public void Adicionar(Cliente cliente)
        {
            _context.clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Editar(Cliente cliente)
        {
            _context.clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            _context.clientes.Remove(ClientesPeloID(id));
            _context.SaveChanges();
        }

        public bool Email(Cliente cliente)
        {
            foreach (Cliente cliente1 in _context.clientes)
            {
                if (cliente.Email.Equals(cliente1.Email))
                {
                    return true;
                }
            }
            return false;
        }
        public bool CPF(Cliente cliente)
        {
            if (_context.clientes.Any(c => c.CPF == cliente.CPF))
            {
                return true;
            }
            return false;
        }
    }


}
