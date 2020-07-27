using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public class FornecedorRepository : BaseRepository<Fornecedor>, IFornecedorRepository
    {
        //atributo
        private readonly SqlServerContext context;

        public FornecedorRepository(SqlServerContext context) 
            : base(context)
        {
            this.context = context;
        }

        public Fornecedor GetByCnpj(string cnpj)
        {
            return context.Fornecedores
                    .FirstOrDefault(f => f.Cnpj.Equals(cnpj));
        }
    }
}
