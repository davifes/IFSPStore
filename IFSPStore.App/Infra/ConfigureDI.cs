using AutoMapper;
using IFSPSotore.Service.Services;
using IFSPStore.App.Cadastro;
using IFSPStore.App.Models;
using IFSPStore.Domain.Base;
using IFSPStore.Domain.Entities;
using IFSPStore.Repository.Context;
using ISFPStore.Repository;
using ISFPStore.Repository.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.App.Infra
{
    public static class ConfigureDI
    {
        public static ServiceCollection? Services;
        public static IServiceProvider? ServiceProvider;

        public static void ConfigureServices()
        {
            Services = new ServiceCollection();
            Services.AddDbContext<MySqlContext>(options =>
            {
                var strCon = File.ReadAllText("Config/ConfigBanco.txt");
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging();

                options.UseMySql(strCon, ServerVersion.AutoDetect(strCon), opt =>
                {
                    opt.CommandTimeout(180);
                    opt.EnableRetryOnFailure(5);
                });
            });
            // Repositories
            Services.AddScoped<IBaseRepository<Usuario>, BaseRepository<Usuario>>();
            Services.AddScoped<IBaseRepository<Cidade>, BaseRepository<Cidade>>();
            Services.AddScoped<IBaseRepository<Cliente>, BaseRepository<Cliente>>();
            Services.AddScoped<IBaseRepository<Grupo>, BaseRepository<Grupo>>();
            Services.AddScoped<IBaseRepository<Produto>, BaseRepository<Produto>>();
            Services.AddScoped<IBaseRepository<Venda>, BaseRepository<Venda>>();

            // Services
            Services.AddScoped<IBaseServices<Usuario>, BaseService<Usuario>>();
            Services.AddScoped<IBaseServices<Cidade>, BaseService<Cidade>>();
            Services.AddScoped<IBaseServices<Cliente>, BaseService<Cliente>>();
            Services.AddScoped<IBaseServices<Grupo>, BaseService<Grupo>>();
            Services.AddScoped<IBaseServices<Produto>, BaseService<Produto>>();
            Services.AddScoped<IBaseServices<Venda>, BaseService<Venda>>();

            // Formulários
            Services.AddTransient<Login, Login>();
            Services.AddTransient<CadastroUsuario, CadastroUsuario>();
            Services.AddTransient<CadastroGrupo, CadastroGrupo>();
            Services.AddTransient<CadastroProduto, CadastroProduto>();
            Services.AddTransient<CadastroCidade, CadastroCidade>();
            Services.AddTransient<CadastroCliente, CadastroCliente>();
            Services.AddTransient<CadastroVenda, CadastroVenda>();

            // Mapping
            Services.AddSingleton(new MapperConfiguration(config =>
            {
                config.CreateMap<Usuario, UsuarioModel>();
                config.CreateMap<Cidade, CidadeModel>()
                    .ForMember(d => d.NomeEstado, d => d.MapFrom(x => $"{x.Nome}/{x.Estado}"));
                config.CreateMap<Cliente, ClienteModel>()
                    .ForMember(d => d.Cidade, d => d.MapFrom(x => $"{x.Cidade!.Nome}/{x.Cidade!.Estado}"))
                    .ForMember(d => d.IdCidade, d => d.MapFrom(x => x.Cidade!.Id));
                config.CreateMap<Grupo, Grupo>();
                config.CreateMap<Produto, ProdutoModel>()
                    .ForMember(d => d.Grupo, d => d.MapFrom(x => x.Grupo!.Nome))
                    .ForMember(d => d.IdGrupo, d => d.MapFrom(x => x.Grupo!.Id));
                config.CreateMap<Venda, VendaModel>()
                    .ForMember(d => d.IdCliente, d => d.MapFrom(x => x.Cliente!.Id))
                    .ForMember(d => d.Cliente, d => d.MapFrom(x => x.Cliente!.Nome))
                    .ForMember(d => d.IdUsuario, d => d.MapFrom(x => x.Usuario!.Id))
                    .ForMember(d => d.Usuario, d => d.MapFrom(x => x.Usuario!.Nome));

                config.CreateMap<VendaItem, VendaItemModel>()
                    .ForMember(d => d.IdProduto, d => d.MapFrom(x => x.Produto!.Id))
                    .ForMember(d => d.Produto, d => d.MapFrom(x => x.Produto!.Nome));

            }).CreateMapper());

            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
            

