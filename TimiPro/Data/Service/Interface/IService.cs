using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimiPro.Models;

namespace TimiPro.Data.Service.Interfaces
{
    public interface IService<T>
    {
        public IEnumerable<T> ListarClientes();
        public T ClientesPeloID(int id);
        public void Adicionar(T Titem);
        public void Editar(T item);
        public void Excluir(int id);
    }
}
