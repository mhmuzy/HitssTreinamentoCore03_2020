using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        //atributo
        private readonly SqlServerContext context;
        public ClienteRepository(SqlServerContext context) 
            : base(context)
        {
            this.context = context;
        }

        public Cliente GetByCpf(string cpf)
        {
            return context.Clientes
                .FirstOrDefault(c => c.Cpf.Equals(cpf));
        }
    }
}
