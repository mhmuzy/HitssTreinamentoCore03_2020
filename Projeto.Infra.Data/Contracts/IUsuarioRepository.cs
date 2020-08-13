using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Contracts
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario GetByEmail(string email);
        Usuario GetByEmailESenha(string email, string senha);
    }
}
