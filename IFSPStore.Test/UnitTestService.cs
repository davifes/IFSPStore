using AutoMapper;
using IFSPSotore.Service.Services;
using IFSPSotore.Service.Validators;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Repository.Context;
using ISFPStore.Repository;
using ISFPStore.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IFSPStore.Test
{
    [TestClass]
    public class UnitTestService
    {
        private ServiceCollection? services;

        public ServiceProvider ConfigureServices()
        {
            services = new ServiceCollection();
            services.AddDbContext<MySqlContext>(options =>
            {
                var server = "localhost";
                var port = "3306";
                var database = "IFSPStoreBD";
                var username = "root";
                var password = "12345678";
                var strCon = $"Server={server}; Port={port}; Database={database};" +
                             $"Uid={username}; Pwd={password}";
                options.UseMySql(strCon, ServerVersion.AutoDetect(strCon), opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });

            services.AddScoped<IBaseRepository<Cidade>, BaseRepository<Cidade>>();
            services.AddScoped<IBaseServices<Cidade>, BaseService<Cidade>>();

            services.AddScoped<IBaseRepository<Cliente>, BaseRepository<Cliente>>();
            services.AddScoped<IBaseServices<Cliente>, BaseService<Cliente>>();

            services.AddScoped<IBaseRepository<Grupo>, BaseRepository<Grupo>>();
            services.AddScoped<IBaseServices<Grupo>, BaseService<Grupo>>();

            services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto>>();
            services.AddScoped<IBaseServices<Produto>, BaseService<Produto>>();

            services.AddScoped<IBaseRepository<Usuario>, BaseRepository<Usuario>>();
            services.AddScoped<IBaseServices<Usuario>, BaseService<Usuario>>();

            services.AddScoped<IBaseRepository<Venda>, BaseRepository<Venda>>();
            services.AddScoped<IBaseServices<Venda>, BaseService<Venda>>();

            // Configuração do AutoMapper
            services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Cidade, Cidade>();
                config.CreateMap<Cliente, Cliente>();
                config.CreateMap<Grupo, Grupo>();
                config.CreateMap<Produto, Produto>();
                config.CreateMap<Usuario, Usuario>();
                config.CreateMap<Venda, Venda>();
            }).CreateMapper());

            return services.BuildServiceProvider();
        }

        // CIDADE
        [TestMethod]
        public void TestInsertCidade()
        {
            var sp = ConfigureServices();
            var cidadeService = sp.GetService<IBaseServices<Cidade>>();

            var cidade = new Cidade
            {
                Nome = "Birigui",
                Estado = "SP"
            };

            var result = cidadeService.Add<Cidade, Cidade, CidadeValidator>(cidade);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestSelectCidade()
        {
            var sp = ConfigureServices();
            var cidadeService = sp.GetService<IBaseServices<Cidade>>();

            var result = cidadeService.Get<Cidade>();
            Console.Write(JsonSerializer.Serialize(result));
        }

        // CLIENTE
        [TestMethod]
        public void TestInsertCliente()
        {
            var sp = ConfigureServices();
            var clienteService = sp.GetService<IBaseServices<Cliente>>();
            var cidadeService = sp.GetService<IBaseServices<Cidade>>();

            var cidade = cidadeService.Get<Cidade>().FirstOrDefault(c => c.Id == 1);
            if (cidade == null)
            {
                Console.WriteLine("Cidade não encontrada.");
                return;
            }

            var cliente = new Cliente
            {
                Nome = "Davi",
                Endereco = "Rua Domingos Agostinho",
                Bairro = "Jandaia II",
                Documento = "448.282.908-00",
                Cidade = cidade
            };

            var result = clienteService.Add<Cliente, Cliente, ClienteValidator>(cliente);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestSelectCliente()
        {
            var sp = ConfigureServices();
            var clienteService = sp.GetService<IBaseServices<Cliente>>();

            var result = clienteService.Get<Cliente>();
            Console.WriteLine(JsonSerializer.Serialize(result));
        }

        // GRUPO
        [TestMethod]
        public void TestInsertGrupo()
        {
            var sp = ConfigureServices();
            var grupoService = sp.GetService<IBaseServices<Grupo>>();

            var grupo = new Grupo
            {
                Nome = "Alimento"
            };

            var result = grupoService.Add<Grupo, Grupo, GrupoValidator>(grupo);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestSelectGrupo()
        {
            var sp = ConfigureServices();
            var grupoService = sp.GetService<IBaseServices<Grupo>>();

            var result = grupoService.Get<Grupo>();
            Console.WriteLine(JsonSerializer.Serialize(result));
        }

        // PRODUTO
        [TestMethod]
        public void TestInsertProduto()
        {
            var sp = ConfigureServices();
            var produtoService = sp.GetService<IBaseServices<Produto>>();
            var grupoService = sp.GetService<IBaseServices<Grupo>>();

            var grupo = grupoService.Get<Grupo>().FirstOrDefault(g => g.Id == 1);
            if (grupo == null)
            {
                Console.WriteLine("Grupo não encontrado.");
                return;
            }

            var produto = new Produto
            {
                Nome = "Banana",
                Preco = 10,
                Quantidade = 100,
                DataCompra = DateTime.Now,
                UnidadeVenda = "10",
                Grupo = grupo
            };

            var result = produtoService.Add<Produto, Produto, ProdutoValidator>(produto);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestSelectProduto()
        {
            var sp = ConfigureServices();
            var produtoService = sp.GetService<IBaseServices<Produto>>();

            var result = produtoService.Get<Produto>();
            Console.WriteLine(JsonSerializer.Serialize(result));
        }

        // USUARIO
        [TestMethod]
        public void TestInsertUsuario()
        {
            var sp = ConfigureServices();
            var usuarioService = sp.GetService<IBaseServices<Usuario>>();

            var usuario = new Usuario()
            {
                Nome = "Davi",
                Login = "davifes",
                Email = "davi@gmail.com",
                Senha = "Davifes!229121997",
                DataCadastro = DateTime.Now,
                Ativo = false
            };

            var result = usuarioService.Add<Usuario, Usuario, UsuarioValidator>(usuario);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestSelectUsuario()
        {
            var sp = ConfigureServices();
            var usuarioService = sp.GetService<IBaseServices<Usuario>>();

            var result = usuarioService.Get<Usuario>();
            Console.Write(JsonSerializer.Serialize(result));
        }

        // VENDA
        [TestMethod]
        public void TestInsertVenda()
        {
            var sp = ConfigureServices();
            var vendaService = sp.GetService<IBaseServices<Venda>>();
            var produtoService = sp.GetService<IBaseServices<Produto>>();
            var clienteService = sp.GetService<IBaseServices<Cliente>>();

            var cliente = clienteService.Get<Cliente>().FirstOrDefault();
            if (cliente == null)
            {
                Console.WriteLine("Cliente não encontrado.");
                return;
            }

            var produto = produtoService.Get<Produto>().FirstOrDefault(p => p.Id == 1);
            if (produto == null)
            {
                Console.WriteLine("Produto não encontrado.");
                return;
            }

            var venda = new Venda
            {
                Data = DateTime.Now,
                ValorTotal = (float)produto.Preco,
                Cliente = cliente,
                Itens = new List<VendaItem>
                {
                    new VendaItem
                    {
                        Produto = produto,
                        Quantidade = 1,
                        ValorUnitario = (float)produto.Preco,
                        ValorTotal = (float)produto.Preco
                    }
                }
            };

            var result = vendaService.Add<Venda, Venda, VendaValidator>(venda);
            Console.Write(JsonSerializer.Serialize(result));
        }

        [TestMethod]
        public void TestSelectVenda()
        {
            var sp = ConfigureServices();
            var vendaService = sp.GetService<IBaseServices<Venda>>();

            var result = vendaService.Get<Venda>();
            Console.WriteLine(JsonSerializer.Serialize(result));
        }
    }
}
