using Microsoft.EntityFrameworkCore;
using Senai.InLock.WebApi.CodeFirst.Domains;
using System;

namespace Senai.InLock.WebApi.CodeFirst.Context
{
    //Essa class é responsavel pelo contexto do projeto
    //Faz a comunicação entre API e Banco de Dados
    public class InLockContext : DbContext
    {
        //Define as entidades do banco de dados
        public DbSet<TiposUsuarios> TiposUsuario { get; set; }

        public DbSet<Usuarios> Usuarios { get; set; }

        public DbSet<Estudios> Estudios { get; set; }

        public DbSet<Jogos> Jogos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DEV201\\SQLEXPRESS; Database=InLock_Games_CodeFirst; user Id=sa; pwd=sa@132");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposUsuarios>().HasData(
                new TiposUsuarios
                {
                    IdTipoUsuario = 1,
                    Titulo = "Administrador"
                },
                new TiposUsuarios
                {
                    IdTipoUsuario = 2,
                    Titulo = "Cliente"
                });

            modelBuilder.Entity<Usuarios>().HasData(
                new Usuarios
                {
                    IdUsuario = 1,
                    Email = "Admin@Admin.com",
                    Senha = "admin",
                    IdTipoUsuario = 1,
                },
                new Usuarios
                {
                    IdUsuario = 2,
                    Email = "cliente@cliente.com",
                    Senha = "cliente",
                    IdTipoUsuario = 2
                });

            modelBuilder.Entity<Estudios>().HasData(
                new Estudios {
                    IdEstudio = 1,
                    NomeEstudio = "Blizzard"
                },
                new Estudios {
                    IdEstudio = 2,
                    NomeEstudio = "'Rockstar"
                },
                new Estudios {
                    IdEstudio = 3,
                    NomeEstudio = "Square Enix"
                });

            modelBuilder.Entity<Jogos>().HasData(
                new Jogos {
                    IdJogo = 1,
                    NomeJogo = "Diablo 3",
                    DataLancamento = Convert.ToDateTime("15/05/2012"),
                    Descricao = "É um jogo que contem bastanet ação e é viciante, seja você ",
                    Valor = Convert.ToDecimal("99,00"),
                    IdEstudio = 1
                },
                 new Jogos
                 {
                     IdJogo = 2,
                     NomeJogo = "Red Dead Redemption 2",
                     DataLancamento = Convert.ToDateTime("26/10/2018"),
                     Descricao = "Jogo eletronico de ação e aventura western ",
                     Valor = Convert.ToDecimal("120,00"),
                     IdEstudio = 2
                 });

            base.OnModelCreating(modelBuilder);
        }
    }
}
