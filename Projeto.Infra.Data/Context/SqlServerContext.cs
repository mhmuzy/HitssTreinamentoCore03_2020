using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Projeto.Infra.Data.Entities;
using Projeto.Infra.Data.Mappings;


namespace Projeto.Infra.Data.Context
{
    //REGRA 1) Herdar DbContext
    public class SqlServerContext : DbContext
    {
        //REGRA 2) Construtor para inicializar a classe DbContext
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options) //construtor da superclasse (DbContext)
        {

        }

        //REGRA 3) Declarar uma propriedade DbSet para cada entidade do projeto
        public DbSet<Fornecedor> Fornecedores { get; set; } //CRUD..
        public DbSet<Produto> Produtos { get; set; } //CRUD..

        //REGRA 4)
    }
}
