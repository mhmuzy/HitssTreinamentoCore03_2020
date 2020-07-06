using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produto");

            builder.HasKey(p => p.IdProduto);

            builder.Property(p => p.IdProduto)
                .HasColumnName("IdProduto");

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150);

            builder.Property(p => p.Preco)
                .HasColumnName("Preco")
                .HasColumnType("decimal(18, 2)");

            builder.Property(p => p.Quantidade)
                .HasColumnName("Quantidade");

        }
    }
}
