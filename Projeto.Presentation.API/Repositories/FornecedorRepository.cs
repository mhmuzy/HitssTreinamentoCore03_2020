using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Presentation.API.Repositories
{
    public class FornecedorRepository
    {
        private readonly List<FornecedorEntity> fornecedores;

        //construtor
        public FornecedorRepository()
        {
            fornecedores = new List<FornecedorEntity>();
        }

        public void Add(FornecedorEntity entity)
        {
            fornecedores.Add(entity);
        }

        public void Remove(FornecedorEntity entity)
        {
            fornecedores.Remove(entity);
        }

        public List<FornecedorEntity> GetAll()
        {
            return fornecedores.OrderBy(f => f.Nome).ToList();
        }

        public FornecedorEntity GetById(int id)
        {
            return fornecedores.FirstOrDefault(c => c.IdFornecedor == id);
        }
    }
}
