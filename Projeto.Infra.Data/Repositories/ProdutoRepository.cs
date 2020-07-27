using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        //atributo
        private readonly SqlServerContext context;

        public ProdutoRepository(SqlServerContext context) 
            : base(context)
        {
            this.context = context;
        }
    }
}
