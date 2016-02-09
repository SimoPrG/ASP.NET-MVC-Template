namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Models;

    public interface IJokesCategoriesService
    {
        IQueryable<JokeCategory> GetAll();
    }
}
