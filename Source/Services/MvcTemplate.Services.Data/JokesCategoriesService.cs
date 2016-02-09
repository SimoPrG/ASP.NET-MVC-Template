namespace MvcTemplate.Services.Data
{
    using System.Linq;

    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class JokesCategoriesService : IJokesCategoriesService
    {
        private readonly IDbRepository<JokeCategory> jokeCategories;

        public JokesCategoriesService(IDbRepository<JokeCategory> jokeCategories)
        {
            this.jokeCategories = jokeCategories;
        }

        public IQueryable<JokeCategory> GetAll()
        {
            return this.jokeCategories.All().OrderBy(x => x.Name);
        }
    }
}
