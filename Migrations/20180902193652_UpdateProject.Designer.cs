﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using osnet.Models;

namespace osnet.Migrations
{
    [DbContext(typeof(OsNetContext))]
    [Migration("20180902193652_UpdateProject")]
    partial class UpdateProject
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("osnet.Models.Cliente", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("Projetoid");

                    b.Property<string>("cnpj");

                    b.Property<string>("cpf");

                    b.Property<string>("email");

                    b.Property<string>("enderecoBairro");

                    b.Property<string>("enderecoCep");

                    b.Property<string>("enderecoCidade");

                    b.Property<string>("enderecoNumero");

                    b.Property<string>("enderecoRua");

                    b.Property<string>("nome")
                        .IsRequired();

                    b.Property<string>("telefone");

                    b.HasKey("id");

                    b.HasIndex("Projetoid");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("osnet.Models.OrdemServico", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<int>("ProjetoId");

                    b.Property<int>("ServicoId");

                    b.Property<int>("StatusId");

                    b.Property<int>("TipoOrdemServicoId");

                    b.Property<DateTime>("dataCadastro");

                    b.Property<DateTime>("dataInicio");

                    b.Property<DateTime>("dataTermino");

                    b.Property<string>("descricao");

                    b.Property<string>("justificativa");

                    b.Property<string>("observacao");

                    b.Property<string>("resolucao");

                    b.Property<string>("resumo");

                    b.Property<string>("titulo")
                        .IsRequired();

                    b.HasKey("id");

                    b.HasIndex("ClienteId");

                    b.HasIndex("ProjetoId");

                    b.HasIndex("ServicoId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TipoOrdemServicoId");

                    b.ToTable("OrdemServico");
                });

            modelBuilder.Entity("osnet.Models.Projeto", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("dataCadastro");

                    b.Property<DateTime>("dataInicio");

                    b.Property<DateTime>("dataTermino");

                    b.Property<string>("nome")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Projeto");
                });

            modelBuilder.Entity("osnet.Models.Servico", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nome")
                        .IsRequired();

                    b.Property<float>("valor");

                    b.HasKey("id");

                    b.ToTable("Servico");
                });

            modelBuilder.Entity("osnet.Models.Status", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nome")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("Status");
                });

            modelBuilder.Entity("osnet.Models.TipoOrdemServico", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("nome")
                        .IsRequired();

                    b.HasKey("id");

                    b.ToTable("TipoOrdemServico");
                });

            modelBuilder.Entity("osnet.Models.Cliente", b =>
                {
                    b.HasOne("osnet.Models.Projeto")
                        .WithMany("Clientes")
                        .HasForeignKey("Projetoid");
                });

            modelBuilder.Entity("osnet.Models.OrdemServico", b =>
                {
                    b.HasOne("osnet.Models.Cliente", "cliente")
                        .WithMany("ClienteOrdemServico")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("osnet.Models.Projeto", "projeto")
                        .WithMany()
                        .HasForeignKey("ProjetoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("osnet.Models.Servico", "servico")
                        .WithMany("Servicos")
                        .HasForeignKey("ServicoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("osnet.Models.Status", "status")
                        .WithMany("Statuses")
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("osnet.Models.TipoOrdemServico", "tipoOrdemServico")
                        .WithMany("TiposOrdemServico")
                        .HasForeignKey("TipoOrdemServicoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
