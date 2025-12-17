

using AutoMapper;
using EFCoreOperation.Data.Model;
using EFCoreOperation.DTO;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Source -> Destination
        CreateMap<BookDTO, Book>()
            .ForMember(dest => dest.CreatedOn, opt => opt.Ignore()); // Prevent overwriting date on updates

        CreateMap<Book, BookDTO>();
    }

}