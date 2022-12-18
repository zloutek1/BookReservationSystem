using AutoMapper;
using BookReservationSystem.DAL.Models;
using BookReservationSystem.Domain;

namespace BookReservationSystem.BL.Configs;

public class AutoMapperConfig
{
    public static void ConfigureMapping(IMapperConfigurationExpression config)
    {
        config.CreateMap<Address, AddressDto>().ReverseMap();
        
        config.CreateMap<Author, AuthorDto>().ReverseMap();
        
        config.CreateMap<Book, BookDto>().ReverseMap();
        config.CreateMap<Book, BookFilterDto>().ReverseMap();
        config.CreateMap<Book, BookCreateDto>().ReverseMap();
        config.CreateMap<Book, BookUpdateDto>().ReverseMap();
        config.CreateMap<Book, BookShortDto>().ReverseMap();
        
        config.CreateMap<BookQuantity, BookQuantityDto>().ReverseMap();
        config.CreateMap<BookQuantity, BookQuantityCreateDto>().ReverseMap();
        
        config.CreateMap<Genre, GenreDto>().ReverseMap();
        
        config.CreateMap<Library, LibraryShortDto>().ReverseMap();
        config.CreateMap<Library, LibraryDto>().ReverseMap();
        config.CreateMap<LibraryDto, LibraryShortDto>().ReverseMap();
        
        config.CreateMap<Publisher, PublisherDto>().ReverseMap();
        
        config.CreateMap<Reservation, ReservationDto>().ReverseMap();
        config.CreateMap<Reservation, ReservationUserFilterDto>().ReverseMap();
        config.CreateMap<Reservation, ReservationCreateDto>().ReverseMap();
        
        config.CreateMap<Review, ReviewDto>().ReverseMap();
        config.CreateMap<Review, ReviewUserFilterDto>().ReverseMap();
        config.CreateMap<Review, ReviewCreateDto>().ReverseMap();

        config.CreateMap<Role, RoleDto>().ReverseMap();
        
        config.CreateMap<User, UserDto>().ReverseMap();
        config.CreateMap<User, UserCreateDto>().ReverseMap();
        config.CreateMap<User, UserEditDto>().ReverseMap();
        config.CreateMap<User, UserFilterDto>().ReverseMap();
        config.CreateMap<User, UserShortDto>().ReverseMap();
    }
}