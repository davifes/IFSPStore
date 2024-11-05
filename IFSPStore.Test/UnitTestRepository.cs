using IFSPStore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IFSPStore.Test
{
    [TestClass]
    public class UnitTestRepository
    {
        DateTime data = new DateTime(2024, 10, 29, 13, 0, 0);
        public partial class MyDbContext : DbContext
        {
            
            public DbSet<Usuario> Usuarios { get; set; }
            public DbSet<Cidade> Cidades { get; set; }
            public DbSet<Cliente> Clientes { get; set; }
            public DbSet<Grupo> Grupos { get; set; }
            public DbSet<Produto> Produtos { get; set; }
            public DbSet<Venda> Vendas { get; set; }
            public DbSet<VendaItem> VendaItens { get; set; }

            public MyDbContext()
            {
                Database.EnsureCreated();
            }

            // override: sobrescrever a configuração para adequá-la ao banco
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var server = "localhost";
                var port = "3306";
                var database = "IFSPStore";
                var username = "root";
                var password = "K@gaya011526";
                var strCon = $"Server={server};Port={port};Database={database};" +
                    $"Uid={username};Pwd={password}";

                if (!optionsBuilder.IsConfigured)
                {
                    optionsBuilder.UseMySql(strCon, ServerVersion.AutoDetect(strCon));
                }
            }
        }

        [TestMethod]
        public void TestInsertCidades()
        {
            using (var context = new MyDbContext())
            {
                var cidade = new Cidade()
                {
                    Nome = "Birigui",
                    Estado = "SP"
                };
                context.Cidades.Add(cidade);

                cidade = new Cidade()
                {
                    Nome = "Araçatuba",
                    Estado = "SP"
                };
                context.Cidades.Add(cidade);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestInsertClientes()
        {
            using (var context = new MyDbContext())
            {
                var cidade = context.Cidades.FirstOrDefault(context => context.Id == 1);
                var cliente = new Cliente()
                {
                    Nome = "Kayky",
                    Cidade = cidade,
                    Endereco = "Rua Noroeste",
                    Bairro = "Vila Roberto",
                    Documento = "475.795.968-06"
                };
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestInsertGrupos()
        {
            using (var context = new MyDbContext())
            {
                var grupo = new Grupo()
                {
                    Nome = "Grupo 1"
                };
                context.Grupos.Add(grupo);

                grupo = new Grupo()
                {
                    Nome = "Grupo 2"
                };
                context.Grupos.Add(grupo);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestInsertUsuario()
        {
            using (var context = new MyDbContext())
            {
                var usuario = new Usuario()
                {
                    Nome = "Kayky",
                    Senha = "K@gaya011526",
                    Login = "Kagaya",
                    Email = "kaykyogaya@gmail.com",
                    DataCadastro = data,
                    DataLogin = data,
                    Ativo = true
                };
                context.Usuarios.Add(usuario);

                usuario = new Usuario()
                {
                    Nome = "Analice",
                    Senha = "analice321",
                    Login = "Anarodan",
                    Email = "analicerodrigues@gmail.com",
                    DataCadastro = data,
                    DataLogin = data,
                    Ativo = true
                };
                context.Usuarios.Add(usuario);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestInsertProdutos()
        {
            using (var context = new MyDbContext())
            {
                var grupo = context.Grupos.FirstOrDefault(context => context.Id == 1);
                var produto = new Produto()
                {
                    Nome = "Caneta",
                    Preco = 2.00f,
                    Quantidade = 5,
                    DataCompra = data,
                    UnidadeVenda = "Unidade",
                    Grupo = grupo
                };
                context.Produtos.Add(produto);

                produto = new Produto()
                {
                    Nome = "Sorvete",
                    Preco = 30.00f,
                    Quantidade = 1,
                    DataCompra = data,
                    UnidadeVenda = "Kg",
                    Grupo = grupo
                };
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestInsertVenda()
        {
            using (var context = new MyDbContext())
            {
                var usuario = context.Usuarios.FirstOrDefault(context => context.Id == 1);
                var cliente = context.Clientes.FirstOrDefault(context => context.Id == 1);
                var produto1 = context.Produtos.FirstOrDefault(context => context.Id == 1);
                var produto2 = context.Produtos.FirstOrDefault(context => context.Id == 2);

                Venda venda = new Venda()
                {
                    Data = data,
                    Usuario = usuario,
                    Cliente = cliente
                };
                var lista = new List<VendaItem>()
                {
                    new VendaItem
                    {
                        Produto = produto1,
                        Quantidade = 5,
                        ValorUnitario = (float)produto1.Preco,
                        ValorTotal = (float)(5*produto1.Preco),
                        Venda = venda
                    },
                    new VendaItem
                    {
                        Produto = produto2,
                        Quantidade = 1,
                        ValorUnitario = (float)produto2.Preco,
                        ValorTotal = (float)(produto2.Preco),
                        Venda = venda
                    }
                };

                float valorTotal = 0.00f;
                foreach(VendaItem v in lista)
                {
                    valorTotal += (float)v.ValorTotal;
                }
                venda.Itens = lista;
                venda.ValorTotal = valorTotal;
                context.Add(venda);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestListCidades()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cidade in context.Cidades)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cidade));
                }
            }
        }

        [TestMethod]
        public void TestListClientes()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cliente in context.Clientes)
                {
                    Console.WriteLine(JsonSerializer.Serialize(cliente));
                }
            }
        }

        [TestMethod]
        public void TestListGrupos()
        {
            using (var context = new MyDbContext())
            {
                foreach (var grupo in context.Grupos)
                {
                    Console.WriteLine(JsonSerializer.Serialize(grupo));
                }
            }
        }

        [TestMethod]
        public void TestListProdutos()
        {
            using (var context = new MyDbContext())
            {
                foreach (var produto in context.Produtos)
                {
                    Console.WriteLine(JsonSerializer.Serialize(produto));
                }
            }
        }

        [TestMethod]
        public void TestListUsuarios()
        {
            using (var context = new MyDbContext())
            {
                foreach (var usuario in context.Usuarios)
                {
                    Console.WriteLine(JsonSerializer.Serialize(usuario));
                }
            }
        }

        [TestMethod]
        public void TestListVendaItens()
        {
            using (var context = new MyDbContext())
            {
                foreach (var vendaItem in context.VendaItens)
                {
                    Console.WriteLine(JsonSerializer.Serialize(vendaItem));
                }
            }
        }

        [TestMethod]
        public void TestListVendas()
        {
            using (var context = new MyDbContext())
            {
                foreach (var venda in context.Vendas)
                {
                    Console.WriteLine(JsonSerializer.Serialize(venda));
                }
            }
        }
        
        [TestMethod]
        public void TestDeleteCidades()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cidade in context.Cidades)
                {
                    if (cidade.Id == 10)
                    {
                        context.Cidades.Remove(cidade);
                        break;
                    }
                }
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteClientes()
        {
            using (var context = new MyDbContext())
            {
                foreach (var cliente in context.Clientes)
                {
                    if (cliente.Id == 10)
                    {
                        context.Clientes.Remove(cliente);
                        break;
                    }
                }
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteGrupos()
        {
            using (var context = new MyDbContext())
            {
                foreach (var grupo in context.Grupos)
                {
                    if (grupo.Id == 10)
                    {
                        context.Grupos.Remove(grupo);
                        break;
                    }
                }
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteProdutos()
        {
            using (var context = new MyDbContext())
            {
                foreach (var produto in context.Produtos)
                {
                    if (produto.Id == 10)
                    {
                        context.Produtos.Remove(produto);
                        break;
                    }
                }
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteUsuarios()
        {
            using (var context = new MyDbContext())
            {
                foreach (var usuario in context.Usuarios)
                {
                    if (usuario.Id == 10)
                    {
                        context.Usuarios.Remove(usuario);
                        break;
                    }
                }
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteVendaItens()
        {
            using (var context = new MyDbContext())
            {
                foreach (var vendaItem in context.VendaItens)
                {
                    if (vendaItem.Id == 10)
                    {
                        context.VendaItens.Remove(vendaItem);
                        break;
                    }
                }
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestDeleteVendas()
        {
            using (var context = new MyDbContext())
            {
                foreach (var venda in context.Vendas)
                {
                    if (venda.Id == 10)
                    {
                        context.Vendas.Remove(venda);
                        break;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
