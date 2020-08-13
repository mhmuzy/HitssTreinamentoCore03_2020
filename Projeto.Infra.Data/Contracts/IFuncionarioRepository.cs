using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Contracts
{
    public interface IFuncionarioRepository : IBaseRepository<Funcionario>
    {
        Funcionario GetByCpf(string cpf);
    }
}
