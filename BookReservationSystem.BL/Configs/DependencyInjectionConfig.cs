using AutoMapper;
using BookReservationSystem.BL.IServices;
using BookReservationSystem.BL.Services;
using BookReservationSystem.DAL.Data;
using BookReservationSystem.Infrastructure.EFCore.Query;
using BookReservationSystem.Infrastructure.EFCore.Repository;
using BookReservationSystem.Infrastructure.EFCore.UnitOfWork;
using BookReservationSystem.Infrastructure.Query;
using BookReservationSystem.Infrastructure.Repository;
using BookReservationSystem.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

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
    }

    private static void AddIdentity(IServiceCollection services)
    {
        services.TryAddSingleton<ISystemClock, SystemClock>();
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
        services.AddScoped(provider => new Func<IUnitOfWork>(() => provider.GetService<IUnitOfWork>()!));
    }

    private static void AddServices(IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IReservationService, ReservationService>();
        services.AddScoped<IReviewService, ReviewService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IIdentityService, IdentityService>();
    }
}