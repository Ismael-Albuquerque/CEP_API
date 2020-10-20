using ExercicioCEP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExercicioCEP.DAL
{
    public class CEPDao
    {
        private readonly Context _context;
        public CEPDao(Context context)
        {
            _context = context;
        }
        public void Cadastrar(CEP cep)
        {
            _context.Enderecos.Add(cep);
            _context.SaveChanges();
           
        }
        
        public List<CEP> Listar()
        {
            var list = _context.Enderecos.ToList();
            return list;
        }

        public CEP Listar(string cep)
        {
            string str1 = cep.Substring(0, 5);
            string str2 = cep.Substring(5, 3);
            string str = $"{str1}-{str2}";
            return _context.Enderecos.First(c => c.Cep == str);
        }

        public CEP Atualizar(CEP cep)
        {
            _context.Enderecos.Update(cep);
            _context.SaveChanges();
            return _context.Enderecos.First(c => c == cep);
        }
        
        public CEP Deletar(string enderecoid)
        {
            CEP cep = _context.Enderecos.Find(int.Parse(enderecoid));
            _context.Enderecos.Remove(cep);
            _context.SaveChanges();
            return cep;
        }
    }
}
