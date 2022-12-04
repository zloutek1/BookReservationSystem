using AutoMapper;
using BookReservationSystem.BL.Helpers;
using BookReservationSystem.BL.Services;
using BookReservationSystem.DAL.Data;
using BookReservationSystem.Infrastructure.EFCore.Query;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.EFCore.UnitOfWork;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace BookReservationSystem.BL.Configs;

public static class DependencyInjectionConfig
{
    public static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<IMapper>(new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping)));
        services.AddSingleton(new SecurityHelper());

        services.AddDbContext<BookReservationSystemDbContext>();

        services.AddScoped(typeof(IQuery<>), typeof(GenericQuery<>));
        services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        
        services.AddScoped<IUnitOfWork, GenericUnitOfWork>();
        services.AddSingleton(provider => new Func<IUnitOfWork>(() => provider.GetService<IUnitOfWork>()!));
        
        services.AddScoped<BookService>();
        services.AddScoped<LibraryService>();
    }
}