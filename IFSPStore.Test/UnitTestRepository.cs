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
            
            public DbSet<Usuario> Usuario { get; set; }
            public DbSet<Cidade> Cidade { get; set; }
            public DbSet<Cliente> Cliente { get; set; }
            public DbSet<Grupo> Grupo { get; set; }
            public DbSet<Produto> Produto { get; set; }
            public DbSet<Venda> Venda { get; set; }
            public DbSet<VendaItem> VendaItem { get; set; }

            public MyDbContext()
            {
                Database.EnsureCreated();
            }

            // override: sobrescrever a configuração para adequá-la ao banco
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                var server = "localhost";
                var port = "3306";
                var database = "IFSPStoreBD";
                var username = "root";
                var password = "12345678";
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
                context.Cidade.Add(cidade);

                cidade = new Cidade()
                {
                    Nome = "Araçatuba",
                    Estado = "SP"
                };
                context.Cidade.Add(cidade);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestInsertClientes()
        {
            using (var context = new MyDbContext())
            {
                var cidade = context.Cidade.FirstOrDefault(context => context.Id == 1);
                var cliente = new Cliente()
                {
                    Nome = "Davi",
                    Cidade = cidade,
                    Endereco = "Rua Domingos Agostinho",
                    Bairro = "Jandaia II",
                    Documento = "448.282.908-00"
                };
                context.Cliente.Add(cliente);
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
                context.Grupo.Add(grupo);

                grupo = new Grupo()
                {
                    Nome = "Grupo 2"
                };
                context.Grupo.Add(grupo);
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
                    Nome = "Davi",
                    Senha = "Davi!229121997",
                    Login = "davifes",
                    Email = "davifes@gmail.com",
                    DataCadastro = data,
                    DataLogin = data,
                    Ativo = true
                };
                context.Usuario.Add(usuario);

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
                context.Usuario.Add(usuario);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestInsertProdutos()
        {
            using (var context = new MyDbContext())
            {
                var grupo = context.Grupo.FirstOrDefault(context => context.Id == 1);
                var produto = new Produto()
                {
                    Nome = "Caneta",
                    Preco = 2.00f,
                    Quantidade = 5,
                    DataCompra = data,
                    UnidadeVenda = "Unidade",
                    Grupo = grupo
                };
                context.Produto.Add(produto);

                produto = new Produto()
                {
                    Nome = "Sorvete",
                    Preco = 30.00f,
                    Quantidade = 1,
                    DataCompra = data,
                    UnidadeVenda = "Kg",
                    Grupo = grupo
                };
                context.Produto.Add(produto);
                context.SaveChanges();
            }
        }

        [TestMethod]
        public void TestInsertVenda()
        {
            using (var context = new MyDbContext())
            {
                var usuario = context.Usuario.FirstOrDefault(context => context.Id == 1);
                var cliente = context.Cliente.FirstOrDefault(context => context.Id == 1);
                var produto1 = context.Produto.FirstOrDefault(context => context.Id == 1);
                var produto2 = context.Produto.FirstOrDefault(context => context.Id == 2);

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
                foreach (var cidade in context.Cidade)
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
                foreach (var cliente in context.Cliente)
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
                foreach (var grupo in context.Grupo)
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
                foreach (var produto in context.Produto)
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
                foreach (var usuario in context.Usuario)
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
                foreach (var vendaItem in context.VendaItem)
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
                foreach (var venda in context.Venda)
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
                foreach (var cidade in context.Cidade)
                {
                    if (cidade.Id == 10)
                    {
                        context.Cidade.Remove(cidade);
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
                foreach (var cliente in context.Cliente)
                {
                    if (cliente.Id == 10)
                    {
                        context.Cliente.Remove(cliente);
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
                foreach (var grupo in context.Grupo)
                {
                    if (grupo.Id == 10)
                    {
                        context.Grupo.Remove(grupo);
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
                foreach (var produto in context.Produto)
                {
                    if (produto.Id == 10)
                    {
                        context.Produto.Remove(produto);
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
                foreach (var usuario in context.Usuario)
                {
                    if (usuario.Id == 10)
                    {
                        context.Usuario.Remove(usuario);
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
                foreach (var vendaItem in context.VendaItem)
                {
                    if (vendaItem.Id == 10)
                    {
                        context.VendaItem.Remove(vendaItem);
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
                foreach (var venda in context.Venda)
                {
                    if (venda.Id == 10)
                    {
                        context.Venda.Remove(venda);
                        break;
                    }
                }
                context.SaveChanges();
            }
        }
    }
}
