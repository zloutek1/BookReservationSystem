using Autofac;
using AutoMapper;

namespace BookReservationSystem.BL.Configs;

public class AutofacConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();

        builder.RegisterInstance(new Mapper(new MapperConfiguration(AutoMapperConfig.ConfigureMapping)))
            .As<IMapper>()
            .SingleInstance();

        return builder.Build();
    }
}