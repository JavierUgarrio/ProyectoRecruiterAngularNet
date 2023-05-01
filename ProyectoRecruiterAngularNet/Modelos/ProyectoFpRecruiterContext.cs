using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProyectoRecruiterAngularNet.Modelos;

public partial class ProyectoFpRecruiterContext : DbContext
{
    public ProyectoFpRecruiterContext()
    {
    }

    public ProyectoFpRecruiterContext(DbContextOptions<ProyectoFpRecruiterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Candidatura> Candidaturas { get; set; }

    public virtual DbSet<DetalleCandidaturaB> DetalleCandidaturaBs { get; set; }

    public virtual DbSet<Proceso> Procesos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioApi> UsuarioApis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("SQL"));

        //    #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        //=> optionsBuilder.UseSqlServer("Data Source=DESKTOP-52FC49J;Initial Catalog=ProyectoFpRecruiter;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

    }
        

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidatura>(entity =>
        {
            entity.HasKey(e => e.IdCandidatura);

            entity.ToTable("Candidatura");

            entity.Property(e => e.Empresa)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Candidaturas)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Candidatura_Usuario");
        });

        modelBuilder.Entity<DetalleCandidaturaB>(entity =>
        {
            entity.HasKey(e => e.IdDetalleCandidatura);

            entity.ToTable("DetalleCandidaturaB");

            entity.Property(e => e.IdDetalleCandidatura).ValueGeneratedNever();

            entity.HasOne(d => d.IdCandidaturaNavigation).WithMany(p => p.DetalleCandidaturaBs)
                .HasForeignKey(d => d.IdCandidatura)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCandidaturaB_Candidatura");

            entity.HasOne(d => d.IdProcesoNavigation).WithMany(p => p.DetalleCandidaturaBs)
                .HasForeignKey(d => d.IdProceso)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_DetalleCandidaturaB_Proceso");
        });

        modelBuilder.Entity<Proceso>(entity =>
        {
            entity.HasKey(e => e.IdProceso);

            entity.ToTable("Proceso");

            entity.Property(e => e.Cliente)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Descripcion)
                .HasMaxLength(1000)
                .IsFixedLength();
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("Usuario");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.FechaAlta).HasColumnType("datetime");
            entity.Property(e => e.FechaBaja).HasColumnType("datetime");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        modelBuilder.Entity<UsuarioApi>(entity =>
        {
            entity.ToTable("UsuarioApi");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.FechaAlta)
                .HasMaxLength(100)
                .IsFixedLength();
            entity.Property(e => e.FechaBaja)
                .HasMaxLength(100)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
