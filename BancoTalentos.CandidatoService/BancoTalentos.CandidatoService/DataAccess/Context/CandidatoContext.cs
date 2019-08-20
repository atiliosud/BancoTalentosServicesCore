using BancoTalentos.CandidatoService.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoTalentos.CandidatoService.DataAccess.Context
{
    public class CandidatoContext : DbContext
    {
        public DbSet<Candidato> Candidato { get; set; }
        public DbSet<Estado> Estado { get; set; }
        public DbSet<Cidade> Cidade { get; set; }
        public DbSet<Disponibilidade> Disponibilidade { get; set; }
        public DbSet<Horario> Horario { get; set; }

        public CandidatoContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisponibilidadeCandidato>()
             .HasKey(bc => new { bc.DisponibilidadeId, bc.CandidatoId });

            modelBuilder.Entity<DisponibilidadeCandidato>()
                .HasOne(bc => bc.Disponibilidade)
                .WithMany(b => b.Disponibilidades)
                .HasForeignKey(bc => bc.DisponibilidadeId);

            modelBuilder.Entity<DisponibilidadeCandidato>()
                 .HasOne(bc => bc.Candidato)
                 .WithMany(b => b.Disponibilidades)
                 .HasForeignKey(bc => bc.CandidatoId);

            modelBuilder.Entity<HorarioCandidato>()
            .HasKey(bc => new { bc.HorarioId, bc.CandidatoId });

            modelBuilder.Entity<HorarioCandidato>()
                .HasOne(bc => bc.Horario)
                .WithMany(b => b.Horarios)
                .HasForeignKey(bc => bc.HorarioId);

            modelBuilder.Entity<HorarioCandidato>()
                .HasOne(bc => bc.Candidato)
                .WithMany(b => b.Horarios)
                .HasForeignKey(bc => bc.CandidatoId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
