using AutoMapper;
using BookReservationSystem.BL.Helpers;
using BookReservationSystem.BL.Services;
using BookReservationSystem.DAL.Data;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Infrastructure.EFCore.Query;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.EFCore.UnitOfWork;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace BookReservationSystem.BL.Configs;

public static class DependencyInjectionConfig
{
    public static void ConfigureServices(IServiceCollection services)
    { 
        AddUtilities(services);
        AddIdentity(services);
        services.AddDbContext<BookReservationSystemDbContext>();
        AddRepositories(services);
        AddQueries(services);
        AddUnitOfWork(services);
        AddServices(services);
    }

    private static void AddUtilities(IServiceCollection services)
    {
        services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping)));
        services.AddSingleton<SecurityHelper>();
    }

    private static void AddIdentity(IServiceCollection services)
    {
        services
            .AddIdentityCore<User>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<BookReservationSystemDbContext>()
            .AddDefaultTokenProviders();
    }
    
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
    }

    private static void AddQueries(IServiceCollection services)
    {
        services.AddScoped(typeof(IQuery<>), typeof(GenericQuery<>));
    }

    private static void AddUnitOfWork(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, GenericUnitOfWork>();
        services.AddSingleton(provider => new Func<IUnitOfWork>(() => provider.GetService<IUnitOfWork>()!));
    }
    
    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<BookService>();
        services.AddScoped<LibraryService>();
    }
}