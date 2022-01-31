using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProiectASP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProiectASP.Data
{
    public class Context :  IdentityDbContext<User, Role, int,
             IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>, 
             IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public DbSet<SessionToken> SessionTokens { get; set; }
        public Context(DbContextOptions<Context> options) : base(options) { }
        public DbSet<Produs> Produse { get; set; }
        public DbSet<Clienti> Clienti { get; set; }
        public DbSet<Comenzi> Comenzi { get; set; }
        public DbSet<Angajati> Angajati { get; set; }
        public DbSet<Adrese> Adrese { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<UserRole> UserRole { get; set; }
        public DbSet<DetaliiComanda> DetaliiComanda { get; set; }
        public DbSet<Filament> Filament { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Imprimante> Imprimante { get; set; }
        public DbSet<ImprimanteFilament> ImprimanteFilament { get; set; }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<UserRole>(ur =>
            {
                ur.HasKey(ur => new { ur.UserId, ur.RoleId });

                ur.HasOne(ur => ur.Role).WithMany(r => r.UserRoles).HasForeignKey(ur => ur.RoleId);
                ur.HasOne(ur => ur.User).WithMany(u => u.UserRoles).HasForeignKey(ur => ur.UserId);

            });

            //One to Many
            modelBuilder.Entity<Clienti>()
            .HasMany(a => a.Comenzi)
            .WithOne(b => b.Clienti);

            modelBuilder.Entity<Filament>()
           .HasMany(f => f.Produse)
           .WithOne(p => p.Filamente);

            modelBuilder.Entity<Categorie>()
           .HasMany(c => c.Produse)
           .WithOne(p => p.Categorii);
           //.HasForeignKey<Produs>(c => c.IdCategorie);

           //One to One - Angajati - Adrese
            modelBuilder.Entity<Angajati>()
            .HasOne(ang => ang.Adrese)
            .WithOne(adr => adr.Angajati)
            .HasForeignKey<Adrese>(ang => ang.IdAngajat);

            //Many to Many (tabel asociativ) - Angajati - Comenzi - DetaliiComanda - Produse

            modelBuilder.Entity<DetaliiComanda>().HasKey(dc => new { dc.IdComanda, dc.IdProdus });
            modelBuilder.Entity<DetaliiComanda>()
            .HasOne(dc => dc.Produse)
            .WithMany(a => a.DetaliiComanda)
            .HasForeignKey(dc => dc.IdProdus);

            modelBuilder.Entity<DetaliiComanda>()
           .HasOne(dc => dc.Comenzi)
           .WithMany(c => c.DetaliiComanda)
           .HasForeignKey(dc => dc.IdComanda);

            modelBuilder.Entity<DetaliiComanda>()
           .HasOne(dc => dc.Angajati)
           .WithMany(a => a.DetaliiComanda)
           .HasForeignKey(dc => dc.IdExecutant);

            modelBuilder.Entity<DetaliiComanda>()
           .HasOne(dc => dc.Angajati)
           .WithMany(a => a.DetaliiComanda)
           .HasForeignKey(dc => dc.IdProiectant);

            //One To Many
            modelBuilder.Entity<ImprimanteFilament>().HasKey(impf => new { impf.IdFilament, impf.IdImprimanta });

            modelBuilder.Entity<ImprimanteFilament>()
           .HasOne(impf => impf.Filament)
           .WithMany(f => f.ImprimanteFilamente)
           .HasForeignKey(impf => impf.IdFilament);

            modelBuilder.Entity<ImprimanteFilament>()
           .HasOne(impf => impf.Imprimante)
           .WithMany(imp => imp.ImprimanteFilamente)
           .HasForeignKey(impf => impf.IdImprimanta);

            base.OnModelCreating(modelBuilder);
        }

      

    }
}