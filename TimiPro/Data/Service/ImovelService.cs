using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimiPro.Data.EF;
using TimiPro.Data.Service.Interface;
using TimiPro.Data.Service.Interfaces;
using TimiPro.Models;

namespace TimiPro.Data.Service
{
    public class ImovelService : IImovelService
    {
        readonly EFDBContext _context;

        public ImovelService(EFDBContext context)
        {
            _context = context;
        }

        public void Adicionar(Imovel imovel)
        {
            _context.imovel.Add(imovel);
            _context.SaveChanges();

        }

        public void Editar(Imovel imovel)
        {
            _context.imovel.Update(imovel);
            _context.SaveChanges();
        }

        public void Excluir(int id)
        {
            _context.imovel.Remove(ImovelPeloID(id));
            _context.SaveChanges();
        }

        public Imovel ImovelPeloID(int id)
        {
            return _context.imovel.Find(id);

        }

        public IEnumerable<Imovel> ListarImovel()
        {
            return _context.imovel.ToList();
        }
    }
}
