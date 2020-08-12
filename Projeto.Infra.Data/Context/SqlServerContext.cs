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
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        //REGRA 4) Sobrescrita (OVERRIDE) do método OnModelCreating
        //Utilizado para registrar todos os mapeamentos do projeto..
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //registrar cada classe de mapeamento do projeto..
            modelBuilder.ApplyConfiguration(new FornecedorMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new FuncionarioMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());

            //mapeamento de índices (UNIQUE)
            modelBuilder.Entity<Fornecedor>(entity =>
                {
                    entity.HasIndex(f => f.Cnpj).IsUnique();
                    entity.HasIndex(f => f.Nome).IsUnique();
                });
            modelBuilder.Entity<Usuario>(entity =>
                {

                    entity.HasIndex(u => u.Nome).IsUnique();
                    entity.HasIndex(u => u.Email).IsUnique();
                });
            modelBuilder.Entity<Funcionario>(entity =>
                {
                    entity.HasIndex(fu => fu.Cpf).IsUnique();
                    entity.HasIndex(fu => fu.Nome).IsUnique();
                });
            modelBuilder.Entity<Cliente>(entity => 
                {
                    entity.HasIndex(c => c.Cpf).IsUnique();
                    entity.HasIndex(c => c.Nome).IsUnique();
                });
        }
    }
}
