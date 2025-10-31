using System.Data.Common;
using backend.Models;
using backend.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace TapAndSend.Data
{
    public class AppDb : DbContext
    {
        //construtor para o Entity Framework Core
        public AppDb(DbContextOptions<AppDb> options) : base(options) { }

        //tabelas da base de dados
        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Estafeta> Estafetas {get; set;}
        public DbSet<Encomenda> Encomendas {get; set;}
        public DbSet<Entrega> Entregas {get; set;}
        public DbSet<Avaliacao_Entrega> Avaliacoes {get; set;}
        public DbSet<Disponibilidade_Estafeta> Disponibilidades {get; set;}
        public DbSet<Localizacoes> Localizacao {get; set;}
        public DbSet<Administrador> Administradores {get; set;}
        public DbSet<LogCliente> LogClientes {get; set;}
        public DbSet<LogEstafeta> LogEstafetas {get; set;}
        public DbSet<LogAdmin> LogAdministradores {get; set;}

        //configurações adicionais - relacionamentos, chaves primárias e estrangeiras
       /*protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);*/

            //relação Cliente -> Login_Cliente (1:1)
            /*modelBuilder.Entity<LogCliente>()
                .HasOne(lc => lc.Cliente)
                .WithOne(c => c.Login_Cliente)
                .HasForeignKey<LogCliente>(lc => lc.cliente_ID)
                .OnDelete(DeleteBehavior.Cascade);*/

            //relação Cliente -> Encomenda (1:N)
            /*modelBuilder.Entity<Encomenda>()
                .HasOne(e => e.Cliente)
                .WithMany(c => c.Encomenda)
                .HasForeignKey(e => e.cliente_ID)
                .OnDelete(DeleteBehavior.Cascade);*/

            //relação Entrega -> Disponibilidade_Estafeta (1:1)
            /*modelBuilder.Entity<Entrega>()
                .HasOne(e => e.Disponibilidade_Estafeta)
                .WithOne(d => d.Entrega)
                .HasForeignKey<Disponibilidade_Estafeta>(d => d.entrega_ID)
                .OnDelete(DeleteBehavior.Cascade);*/

            //relação Disponibilidade_Estafeta -> Entrega (1:1 ou 1:N)
            /*modelBuilder.Entity<Disponibilidade_Estafeta>()
                .HasOne(d => d.Entrega)
                .WithOne(e => e.Disponibilidade_Estafeta)
                .HasForeignKey<Disponibilidade_Estafeta>(d => d.entrega_ID)
                .OnDelete(DeleteBehavior.Cascade);*/

            //relação Localizacoes -> Estafeta (N:1)
            /*modelBuilder.Entity<Localizacoes>()
                .HasOne(l => l.Estafeta)
                .WithMany(e => e.Localizacoes)
                .HasForeignKey(l => l.estafeta_ID)
                .OnDelete(DeleteBehavior.Cascade);*/

            //relação Avaliacao_Entrega -> Entrega (N:1)
            /*modelBuilder.Entity<Avaliacao_Entrega>()
                .HasOne(a => a.Entrega)
                .WithMany(e => e.Avaliacoes)
                .HasForeignKey(a => a.entrega_ID)
                .OnDelete(DeleteBehavior.Cascade);*/

            //relação Avaliacao_Entrega -> Cliente (N:1)
           /* modelBuilder.Entity<Avaliacao_Entrega>()
                .HasOne(a => a.Cliente)
                .WithMany(c => c.Avaliacoes)
                .HasForeignKey(a => a.cliente_ID)
                .OnDelete(DeleteBehavior.Cascade);*/

            //relação Avaliacao_Entrega -> Entrega (N:1)
            /*modelBuilder.Entity<Avaliacao_Entrega>()
                .HasOne(a => a.Estafeta)
                .WithMany(e => e.Avaliacoes)
                .HasForeignKey(a => a.estafeta_ID)
                .OnDelete(DeleteBehavior.Cascade);*/

            //relação Estafeta -> Login_Estafeta (1:1)
            /*modelBuilder.Entity<LogEstafeta>()
                .HasOne(le => le.Estafeta)
                .WithOne(e => e.Login_Estafeta)
                .HasForeignKey<LogEstafeta>(le => le.estafeta_ID)
                .OnDelete(DeleteBehavior.Cascade);*/

            //relação Administrador -> Login_Administrador (1:1)
           /* modelBuilder.Entity<LogAdmin>()
                .HasOne(la => la.Administrador)
                .WithOne(a => a.Login_Administrador)
                .HasForeignKey<LogAdmin>(la => la.administrador_ID)
                .OnDelete(DeleteBehavior.Cascade);*/

            
        //}

    }
}