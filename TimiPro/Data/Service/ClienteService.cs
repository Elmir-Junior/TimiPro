using System;
using System.Collections.Generic;
using System.Linq;
using TimiPro.Data.EF;
using TimiPro.Data.Service.Interface;
using TimiPro.Data.Service.Interfaces;
using TimiPro.Models;

namespace TimiPro.Data.Service
{
    public class ClienteService : IClienteService
    {
        //Deixei alguns codigos comentados propositalmente.
        
        readonly EFDBContext _context;

        public ClienteService(EFDBContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> ListarClientes()
        {
            return _context.clientes.ToList();
        }
        public IEnumerable<Cliente> ListarClientesPeloID(int id)
        {
            return _context.clientes.Where(i => i.ID == id).ToList();
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
            //if (_context.clientes.Any(c => c.Email == cliente.Email))
            //{
            //    return true;
            //}
            //return false;
        }
        public bool CPF(Cliente cliente)
        {
            if (_context.clientes.Any(c => c.CPF == cliente.CPF))
            {
                return true;
            }
            //else
            //{
            //    int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            //    int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            //    string tempCpf;
            //    string digito;
            //    string cpf = cliente.CPF;
            //    int soma;
            //    int resto;
            //    cpf = cpf.Trim();
            //    cpf = cpf.Replace(".", "").Replace("-", "");
            //    if (cpf.Length != 11)
            //        return false;
            //    tempCpf = cpf.Substring(0, 9);
            //    soma = 0;

            //    for (int i = 0; i < 9; i++)
            //        soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            //    resto = soma % 11;
            //    if (resto < 2)
            //        resto = 0;
            //    else
            //        resto = 11 - resto;
            //    digito = resto.ToString();
            //    tempCpf = tempCpf + digito;
            //    soma = 0;
            //    for (int i = 0; i < 10; i++)
            //        soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            //    resto = soma % 11;
            //    if (resto < 2)
            //        resto = 0;
            //    else
            //        resto = 11 - resto;
            //    digito = digito + resto.ToString();
            //    if (cpf.EndsWith(digito))
            //    {
            //        return false;
            //    }
            //    else
            //        return true;
            //}
            return false;
        }
    }


}
