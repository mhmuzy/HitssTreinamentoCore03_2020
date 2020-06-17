using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Infra.Data.Entities;

namespace Projeto.Infra.Data.Mappings
{
    public class FornecedorMap : IEntityTypeConfiguration<Fornecedor>
    {
        public void Configure(EntityTypeBuilder<Fornecedor> builder)
        {
            builder.ToTable("Fornecedor");

            builder.HasKey(f => f.IdFornecedor);

            builder.Property(f => f.IdFornecedor)
                .HasColumnName("IdFornecedor");

            builder.Property(f => f.Nome)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(f => f.Cnpj)
                .HasMaxLength(14)
                .IsRequired();
    
        }
    }
}
