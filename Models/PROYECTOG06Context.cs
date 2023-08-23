using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProyectoGrupalG06.Models
{
    public partial class PROYECTOG06Context : DbContext
    {
        public PROYECTOG06Context()
        {
        }

        public PROYECTOG06Context(DbContextOptions<PROYECTOG06Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Agente> Agentes { get; set; } = null!;
        public virtual DbSet<Caso> Casos { get; set; } = null!;
        public virtual DbSet<Empresa> Empresas { get; set; } = null!;
        public virtual DbSet<Encuesta> Encuestas { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Solicitude> Solicitudes { get; set; } = null!;
        public virtual DbSet<Sugerencia> Sugerencias { get; set; } = null!;
        public virtual DbSet<Usuario> Usuarios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:conn");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agente>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaId).HasColumnName("EmpresaID");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                /*entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Agentes)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK__Agentes__Empresa__5070F446");*/
            });

            modelBuilder.Entity<Caso>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.AgenteId).HasColumnName("AgenteID");

                entity.Property(e => e.DescripcionCaso)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EstadoCaso)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.PrioridadCaso)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.SolicitudId).HasColumnName("SolicitudID");

                /*entity.HasOne(d => d.Agente)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.AgenteId)
                    .HasConstraintName("FK__Casos__AgenteID__5812160E");

                entity.HasOne(d => d.Solicitud)
                    .WithMany(p => p.Casos)
                    .HasForeignKey(d => d.SolicitudId)
                    .HasConstraintName("FK__Casos__Solicitud__571DF1D5");*/
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descripcion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Direccion)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NombreEmpresa)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Telefono)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Encuesta>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Pregunta1)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pregunta2)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pregunta3)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.NombreRol)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Solicitude>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.ClienteId).HasMaxLength(100).HasColumnName("ClienteID");

                entity.Property(e => e.DescripcionSolicitud)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EmpresaId).HasMaxLength(100).HasColumnName("EmpresaID");

                entity.Property(e => e.EstadoSolicitud)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                /*entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Solicitud__Clien__534D60F1");

                entity.HasOne(d => d.Empresa)
                    .WithMany(p => p.Solicitudes)
                    .HasForeignKey(d => d.EmpresaId)
                    .HasConstraintName("FK__Solicitud__Empre__5441852A");*/
            });

            modelBuilder.Entity<Sugerencia>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID");

                entity.Property(e => e.ClienteId).HasMaxLength(100).HasColumnName("Cliente");

                entity.Property(e => e.Comentario)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("Comentario");

                entity.Property(e => e.Detalles).HasMaxLength(500).HasColumnName("Detalles");

                /*entity.HasOne(d => d.Cliente)
                    .WithMany(p => p.Sugerencia)
                    .HasForeignKey(d => d.ClienteId)
                    .HasConstraintName("FK__Sugerenci__Clien__5CD6CB2B");

                entity.HasOne(d => d.Encuesta)
                    .WithMany(p => p.Sugerencia)
                    .HasForeignKey(d => d.EncuestaId)
                    .HasConstraintName("FK__Sugerenci__Encue__5DCAEF64");*/
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("ID");

                entity.Property(e => e.Contraseña)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CorreoElectronico)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NombreUsuario)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("Nombre_usuario");

                entity.Property(e => e.RolId).HasColumnName("RolID");

                /*entity.HasOne(d => d.Rol)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.RolId)
                    .HasConstraintName("FK__Usuarios__RolID__4BAC3F29");*/
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
