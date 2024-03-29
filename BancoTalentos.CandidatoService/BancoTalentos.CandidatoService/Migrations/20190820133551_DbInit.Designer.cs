﻿// <auto-generated />
using System;
using BancoTalentos.CandidatoService.DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BancoTalentos.CandidatoService.Migrations
{
    [DbContext(typeof(CandidatoContext))]
    [Migration("20190820133551_DbInit")]
    partial class DbInit
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BancoTalentos.CandidatoService.Model.Candidato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CidadeId");

                    b.Property<DateTime>("DataCriacao");

                    b.Property<string>("Email");

                    b.Property<string>("Nome");

                    b.Property<string>("Password");

                    b.Property<string>("Portfolio");

                    b.Property<decimal>("Pretensao");

                    b.Property<string>("Skype");

                    b.Property<string>("Telefone");

                    b.Property<string>("UltimoNome");

                    b.HasKey("Id");

                    b.HasIndex("CidadeId")
                        .IsUnique()
                        .HasFilter("[CidadeId] IS NOT NULL");

                    b.ToTable("Candidato");
                });

            modelBuilder.Entity("BancoTalentos.CandidatoService.Model.Cidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EstadoId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("EstadoId");

                    b.ToTable("Cidade");
                });

            modelBuilder.Entity("BancoTalentos.CandidatoService.Model.Disponibilidade", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Disponibilidade");
                });

            modelBuilder.Entity("BancoTalentos.CandidatoService.Model.DisponibilidadeCandidato", b =>
                {
                    b.Property<int>("DisponibilidadeId");

                    b.Property<int>("CandidatoId");

                    b.HasKey("DisponibilidadeId", "CandidatoId");

                    b.HasIndex("CandidatoId");

                    b.ToTable("DisponibilidadeCandidato");
                });

            modelBuilder.Entity("BancoTalentos.CandidatoService.Model.Estado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Codigo");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Estado");
                });

            modelBuilder.Entity("BancoTalentos.CandidatoService.Model.Horario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.HasKey("Id");

                    b.ToTable("Horario");
                });

            modelBuilder.Entity("BancoTalentos.CandidatoService.Model.HorarioCandidato", b =>
                {
                    b.Property<int>("HorarioId");

                    b.Property<int>("CandidatoId");

                    b.HasKey("HorarioId", "CandidatoId");

                    b.HasIndex("CandidatoId");

                    b.ToTable("HorarioCandidato");
                });

            modelBuilder.Entity("BancoTalentos.CandidatoService.Model.Candidato", b =>
                {
                    b.HasOne("BancoTalentos.CandidatoService.Model.Cidade", "Cidade")
                        .WithOne("Candidato")
                        .HasForeignKey("BancoTalentos.CandidatoService.Model.Candidato", "CidadeId");
                });

            modelBuilder.Entity("BancoTalentos.CandidatoService.Model.Cidade", b =>
                {
                    b.HasOne("BancoTalentos.CandidatoService.Model.Estado", "Estado")
                        .WithMany()
                        .HasForeignKey("EstadoId");
                });

            modelBuilder.Entity("BancoTalentos.CandidatoService.Model.DisponibilidadeCandidato", b =>
                {
                    b.HasOne("BancoTalentos.CandidatoService.Model.Candidato", "Candidato")
                        .WithMany("Disponibilidades")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BancoTalentos.CandidatoService.Model.Disponibilidade", "Disponibilidade")
                        .WithMany("Disponibilidades")
                        .HasForeignKey("DisponibilidadeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BancoTalentos.CandidatoService.Model.HorarioCandidato", b =>
                {
                    b.HasOne("BancoTalentos.CandidatoService.Model.Candidato", "Candidato")
                        .WithMany("Horarios")
                        .HasForeignKey("CandidatoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BancoTalentos.CandidatoService.Model.Horario", "Horario")
                        .WithMany("Horarios")
                        .HasForeignKey("HorarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
