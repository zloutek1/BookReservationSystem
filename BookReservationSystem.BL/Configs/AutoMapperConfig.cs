using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;
using Microsoft.AspNetCore.Identity;

namespace BookReservationSystem.BL.Configs;

public class AutoMapperConfig
{
    public static void ConfigureMapping(IMapperConfigurationExpression config)
    {
        config.CreateMap<Address, AddressDto>().ReverseMap();
        config.CreateMap<Author, AuthorDto>().ReverseMap();
        config.CreateMap<Book, BookDto>().ReverseMap();
        config.CreateMap<BookQuantity, BookDto>().ReverseMap();
        config.CreateMap<Genre, GenreDto>().ReverseMap();
        config.CreateMap<Library, LibraryDto>().ReverseMap();
        config.CreateMap<Publisher, PublisherDto>().ReverseMap();
        config.CreateMap<Reservation, ReservationDto>().ReverseMap();
        config.CreateMap<Review, ReviewDto>().ReverseMap();
        config.CreateMap<IdentityRole, RoleDto>().ReverseMap();
        config.CreateMap<User, UserDto>().ReverseMap();
        config.CreateMap<User, UserCreateDto>().ReverseMap();
    }
}