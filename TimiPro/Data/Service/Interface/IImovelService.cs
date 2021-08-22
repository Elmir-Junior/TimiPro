using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimiPro.Models;

namespace TimiPro.Data.Service.Interface
{
    public interface IImovelService
    {
        public IEnumerable<Imovel> ListarImovel();
        public Imovel ImovelPeloID(int id);
        public void Adicionar(Imovel imovel);
        public void Editar(Imovel imovel);
        public void Excluir(int id);
    }
}
