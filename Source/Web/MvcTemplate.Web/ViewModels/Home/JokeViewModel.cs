namespace MvcTemplate.Web.ViewModels.Home
{
    using AutoMapper;

    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;

    public class JokeViewModel : IMapFrom<Joke>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CategoryName { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Joke, JokeViewModel>()
                .ForMember(x => x.CategoryName, opt => opt.MapFrom(x => x.Category.Name));
        }
    }
}
