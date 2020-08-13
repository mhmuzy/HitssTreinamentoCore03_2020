using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public class FuncionarioRepository : BaseRepository<Funcionario>, IFuncionarioRepository
    {
        //atributo
        private readonly SqlServerContext context;

        public FuncionarioRepository(SqlServerContext context) 
            : base(context)
        {
            this.context = context;
        }

        public Funcionario GetByCpf(string cpf)
        {
            return context.Funcionarios
                .FirstOrDefault(fu => fu.Cpf.Equals(cpf));
        }
    }
}
