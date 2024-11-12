using AutoMapper;
using IFSPSotore.Service.Services;
using IFSPSotore.Service.Validators;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Repository.Context;
using ISFPStore.Repository;
//using ISFPStore.Repository.Context;
using ISFPStore.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;


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
                var port = "3307";
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

            services.AddScoped<IBaseRepository<Usuario>, BaseRepository<Usuario>>();
            services.AddScoped<IBaseServices<Usuario>, BaseService<Usuario>>();
            services.AddSingleton(new MapperConfiguration(config =>
                                {
                                    config.CreateMap<Usuario, Usuario>();
                                }).CreateMapper());
            return services.BuildServiceProvider();
        }
        [TestMethod]
        public void TestarUsuario()
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
            var UsuarioServices = sp.GetService<IBaseServices<Usuario>>();

            var result = UsuarioServices.Get<Usuario>();
            Console.Write(JsonSerializer.Serialize(result));
        }
    }
}
