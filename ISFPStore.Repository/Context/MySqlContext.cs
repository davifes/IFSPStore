﻿using IFSPStore.Domain.Entities;
using ISFPStore.Repository.Mapping;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFPStore.Repository.Context
{
    public class MySqlContext : DbContext
    {
        public MySqlContext(DbContextOptions<MySqlContext>options):
            base(options)
        {
            Database.EnsureCreated();//criar banco caso nao exista
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cidade> Cidades { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Grupo> Grupos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VendaItem> VendaItens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(new UsuarioMap().Configure);
            modelBuilder.Entity<Cidade>(new CidadeMap().Configure);
            modelBuilder.Entity<Cliente>(new ClienteMap().Configure);
            modelBuilder.Entity<Grupo>(new GrupoMap().Configure);
            modelBuilder.Entity<Produto>(new ProdutoMap().Configure);
            modelBuilder.Entity<Venda>(new VendaMap().Configure);
            modelBuilder.Entity<VendaItem>(new VendaItemMap().Configure);
        }
    }
}