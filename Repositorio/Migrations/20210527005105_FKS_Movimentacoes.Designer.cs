﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Repositorio.Contexto;

namespace Repositorio.Migrations
{
    [DbContext(typeof(ContextoBanco))]
    [Migration("20210527005105_FKS_Movimentacoes")]
    partial class FKS_Movimentacoes
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Dominio.Entidades.Agencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnName("Numero")
                        .HasColumnType("varchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Agencia");
                });

            modelBuilder.Entity("Dominio.Entidades.Cartao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<bool>("Ativo")
                        .HasColumnName("Ativo")
                        .HasColumnType("Bit");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdCliente")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnName("Numero")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnName("Tipo")
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime>("Vencimento")
                        .HasColumnName("Vencimento")
                        .HasColumnType("date");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente")
                        .IsUnique();

                    b.ToTable("Cartao");
                });

            modelBuilder.Entity("Dominio.Entidades.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnName("Cpf")
                        .HasColumnType("varchar(11)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("DataCriacao")
                        .HasColumnType("Datetime");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnName("Nome")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Telefone")
                        .IsRequired()
                        .HasColumnName("Telefone")
                        .HasColumnType("varchar(11)");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Dominio.Entidades.Conta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("DataCriacao")
                        .HasColumnType("Datetime");

                    b.Property<Guid>("IdCliente")
                        .HasColumnName("IdCliente")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Numero")
                        .IsRequired()
                        .HasColumnName("Numero")
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("Saldo")
                        .HasColumnName("Saldo")
                        .HasColumnType("numeric(19,2)");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnName("Tipo")
                        .HasColumnType("varchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("IdCliente")
                        .IsUnique();

                    b.ToTable("Conta");
                });

            modelBuilder.Entity("Dominio.Entidades.Deposito", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Credenciador")
                        .IsRequired()
                        .HasColumnName("Credenciador")
                        .HasColumnType("varchar(50)");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("DataCriacao")
                        .HasColumnType("Datetime");

                    b.Property<Guid>("IdMovimentacao")
                        .HasColumnName("IdMovimentacao")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("NumeroBoleto")
                        .IsRequired()
                        .HasColumnName("NumeroBoleto")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdMovimentacao");

                    b.ToTable("Deposito");
                });

            modelBuilder.Entity("Dominio.Entidades.Movimentacao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Evento")
                        .IsRequired()
                        .HasColumnName("Evento")
                        .HasColumnType("varchar(20)");

                    b.Property<Guid>("IdConta")
                        .HasColumnName("IdConta")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("Tipo")
                        .IsRequired()
                        .HasColumnName("Tipo")
                        .HasColumnType("varchar(10)");

                    b.Property<decimal>("Valor")
                        .HasColumnName("Valor")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("IdConta");

                    b.ToTable("Movimentacao");
                });

            modelBuilder.Entity("Dominio.Entidades.Saque", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("DataCriacao")
                        .HasColumnType("Datetime");

                    b.Property<Guid>("IdMovimentacao")
                        .HasColumnName("IdMovimentacao")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<string>("IdentificadorCaixaEletronico")
                        .IsRequired()
                        .HasColumnName("IdentificadorCaixaEletronico")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("IdMovimentacao");

                    b.ToTable("Saque");
                });

            modelBuilder.Entity("Dominio.Entidades.Transferencia", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Id")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnName("DataCriacao")
                        .HasColumnType("Datetime");

                    b.Property<Guid>("IdContaDestino")
                        .HasColumnName("IdContaDestino")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.Property<Guid>("IdMovimentacao")
                        .HasColumnName("IdMovimentacao")
                        .HasColumnType("UNIQUEIDENTIFIER");

                    b.HasKey("Id");

                    b.HasIndex("IdContaDestino");

                    b.HasIndex("IdMovimentacao");

                    b.ToTable("Transferencia");
                });

            modelBuilder.Entity("Dominio.Entidades.Cartao", b =>
                {
                    b.HasOne("Dominio.Entidades.Cliente", "Cliente")
                        .WithOne("Cartao")
                        .HasForeignKey("Dominio.Entidades.Cartao", "IdCliente")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Conta", b =>
                {
                    b.HasOne("Dominio.Entidades.Cliente", "Cliente")
                        .WithOne("Conta")
                        .HasForeignKey("Dominio.Entidades.Conta", "IdCliente")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Deposito", b =>
                {
                    b.HasOne("Dominio.Entidades.Movimentacao", "Movimentacao")
                        .WithMany("Depositos")
                        .HasForeignKey("IdMovimentacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Movimentacao", b =>
                {
                    b.HasOne("Dominio.Entidades.Conta", "Conta")
                        .WithMany("Movimentacoes")
                        .HasForeignKey("IdConta")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Saque", b =>
                {
                    b.HasOne("Dominio.Entidades.Movimentacao", "Movimentacao")
                        .WithMany("Saques")
                        .HasForeignKey("IdMovimentacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Dominio.Entidades.Transferencia", b =>
                {
                    b.HasOne("Dominio.Entidades.Conta", "ContaDestino")
                        .WithMany("TransferenciasRecebidas")
                        .HasForeignKey("IdContaDestino")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Dominio.Entidades.Movimentacao", "Movimentacao")
                        .WithMany("Transferencias")
                        .HasForeignKey("IdMovimentacao")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
