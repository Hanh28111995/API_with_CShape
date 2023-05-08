using AutoMapper;
using MyApiNetCore6.Data;
using MyApiNetCore6.Models;

namespace MyApiNetCore6.Helpers
{
    public class AppMapper : Profile

    {
        public AppMapper()
        {
            CreateMap<Book, BookModel>().ReverseMap();
        }
    }
}
