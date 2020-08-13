using System;
using System.Collections.Generic;
using System.Text;
using Projeto.Infra.Data.Context;
using Projeto.Infra.Data.Contracts;
using Projeto.Infra.Data.Entities;
using System.Linq;

namespace Projeto.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        //atributo
        private readonly SqlServerContext context;

        public UsuarioRepository(SqlServerContext context) 
            : base(context)
        {
            this.context = context;
        }

        public Usuario GetByEmail(string email)
        {
            return context.Usuarios
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public Usuario GetByEmailESenha(string email, string senha)
        {
            return context.Usuarios
                .FirstOrDefault(u => u.Email.Equals(email)
                                && u.Senha.Equals(senha));
        }
    }
}
