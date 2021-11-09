using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Books.Domain;
using Books.Application.DTO;

namespace Books.API.Profiles
{
    public class BooksProfile:Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookReadDTO>()
                .ForMember(dest => dest.Author,
                opt => opt.MapFrom(src => $"{src.Author.FirstName} {src.Author.LastName}"));

            CreateMap<BookCreateDTO, Book>();
        }
    }
}
