using System;
using System.Collections.Generic;
using Api.Trello.Data.Entity.Model;
using Api.Trello.DAta.Context.Contrat;
using Microsoft.EntityFrameworkCore;

namespace Api.Trello.Data.Entity;

public partial class TrelloDBContext : DbContext, ITrelloDBContext
{
    public TrelloDBContext()
    {
    }

    public TrelloDBContext(DbContextOptions<TrelloDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Model.Action> Actions { get; set; }

    public virtual DbSet<MembreProjet> MembreProjet { get; set; }

    public virtual DbSet<Projet> Projet { get; set; }

    public virtual DbSet<StatutTache> StatutTache { get; set; }

    public virtual DbSet<Tache> Tache { get; set; }

    public virtual DbSet<Utilisateur> Utilisateur { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Model.Action>(entity =>
        {
            entity.HasKey(e => e.Idaction).HasName("PRIMARY");

            entity.HasIndex(e => e.Idtache, "IDTache");

            entity.Property(e => e.Idaction)
                .HasColumnType("int(11)")
                .HasColumnName("IDAction");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Idtache)
                .HasColumnType("int(11)")
                .HasColumnName("IDTache");

            entity.HasOne(d => d.IdtacheNavigation).WithMany(p => p.Actions)
                .HasForeignKey(d => d.Idtache)
                .HasConstraintName("actions_ibfk_1");
        });

        modelBuilder.Entity<MembreProjet>(entity =>
        {
            entity.HasKey(e => e.IdmembreProjet).HasName("PRIMARY");

            entity.ToTable("MembreProjet");

            entity.HasIndex(e => e.Idprojet, "IDProjet");

            entity.HasIndex(e => e.Idutilisateur, "IDUtilisateur");

            entity.Property(e => e.IdmembreProjet)
                .HasColumnType("int(11)")
                .HasColumnName("IDMembreProjet");
            entity.Property(e => e.Idprojet)
                .HasColumnType("int(11)")
                .HasColumnName("IDProjet");
            entity.Property(e => e.Idutilisateur)
                .HasColumnType("int(11)")
                .HasColumnName("IDUtilisateur");

            entity.HasOne(d => d.IdprojetNavigation).WithMany(p => p.MembreProjets)
                .HasForeignKey(d => d.Idprojet)
                .HasConstraintName("membreprojet_ibfk_2");

            entity.HasOne(d => d.IdutilisateurNavigation).WithMany(p => p.MembreProjets)
                .HasForeignKey(d => d.Idutilisateur)
                .HasConstraintName("membreprojet_ibfk_1");
        });

        modelBuilder.Entity<Projet>(entity =>
        {
            entity.HasKey(e => e.Idprojet).HasName("PRIMARY");

            entity.ToTable("Projet");

            entity.HasIndex(e => e.Idresponsable, "IDResponsable");

            entity.Property(e => e.Idprojet)
                .HasColumnType("int(11)")
                .HasColumnName("IDProjet");
            entity.Property(e => e.DetailsDuProjet).HasColumnType("text");
            entity.Property(e => e.Idresponsable)
                .HasColumnType("int(11)")
                .HasColumnName("IDResponsable");
            entity.Property(e => e.NomProjet).HasMaxLength(255);

            entity.HasOne(d => d.IdresponsableNavigation).WithMany(p => p.Projets)
                .HasForeignKey(d => d.Idresponsable)
                .HasConstraintName("projet_ibfk_1");
        });

        modelBuilder.Entity<StatutTache>(entity =>
        {
            entity.HasKey(e => e.IdstatutTache).HasName("PRIMARY");

            entity.ToTable("StatutTache");

            entity.Property(e => e.IdstatutTache)
                .HasColumnType("int(11)")
                .HasColumnName("IDStatutTache");
            entity.Property(e => e.LibelleStatut).HasMaxLength(255);
        });

        modelBuilder.Entity<Tache>(entity =>
        {
            entity.HasKey(e => e.Idtache).HasName("PRIMARY");

            entity.ToTable("Tache");

            entity.HasIndex(e => e.Idprojet, "IDProjet");

            entity.HasIndex(e => e.Idresponsable, "IDResponsable");

            entity.HasIndex(e => e.IdstatutTache, "IDStatutTache");

            entity.Property(e => e.Idtache)
                .HasColumnType("int(11)")
                .HasColumnName("IDTache");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Idprojet)
                .HasColumnType("int(11)")
                .HasColumnName("IDProjet");
            entity.Property(e => e.Idresponsable)
                .HasColumnType("int(11)")
                .HasColumnName("IDResponsable");
            entity.Property(e => e.IdstatutTache)
                .HasColumnType("int(11)")
                .HasColumnName("IDStatutTache");
            entity.Property(e => e.PourcentageProgression).HasColumnType("int(11)");
            entity.Property(e => e.Titre).HasMaxLength(255);

            entity.HasOne(d => d.IdprojetNavigation).WithMany(p => p.Taches)
                .HasForeignKey(d => d.Idprojet)
                .HasConstraintName("tache_ibfk_2");

            entity.HasOne(d => d.IdresponsableNavigation).WithMany(p => p.Taches)
                .HasForeignKey(d => d.Idresponsable)
                .HasConstraintName("tache_ibfk_1");

            entity.HasOne(d => d.IdstatutTacheNavigation).WithMany(p => p.Taches)
                .HasForeignKey(d => d.IdstatutTache)
                .HasConstraintName("tache_ibfk_3");
        });

        modelBuilder.Entity<Utilisateur>(entity =>
        {
            entity.HasKey(e => e.Idutilisateur).HasName("PRIMARY");

            entity.ToTable("Utilisateur");

            entity.Property(e => e.Idutilisateur)
                .HasColumnType("int(11)")
                .HasColumnName("IDUtilisateur");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.MotDePasse).HasMaxLength(255);
            entity.Property(e => e.Nom).HasMaxLength(255);
            entity.Property(e => e.Photo).HasMaxLength(255);
            entity.Property(e => e.Poste).HasMaxLength(255);
            entity.Property(e => e.Prenom).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
