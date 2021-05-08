﻿using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Mapeamento
{
    public class SaqueMapping : IEntityTypeConfiguration<Saque>
    {
        public void Configure(EntityTypeBuilder<Saque> builder)
        {
            builder.ToTable("Saque");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.IdConta)
                   .HasColumnName("IdConta")
                   .HasColumnType("UNIQUEIDENTIFIER")
                   .IsRequired();
            builder.Property(x => x.IdentificadorCaixaEletronico)
                   .HasColumnName("IdentificadorCaixaEletronico")
                   .HasColumnType("varchar(100)")
                   .IsRequired();
            builder.Property(x => x.Valor)
                   .HasColumnName("Valor")
                   .HasColumnType("numeric")
                   .IsRequired();
            builder.Property(x => x.IdMovimentacao)
                  .HasColumnName("IdMovimentacao")
                  .HasColumnType("UNIQUEIDENTIFIER")
                  .IsRequired();
            builder.HasOne(x => x.Movimentacao)
                   .WithMany(x => x.Saques)
                   .HasForeignKey(x => x.IdMovimentacao)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
