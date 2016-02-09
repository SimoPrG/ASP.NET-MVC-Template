namespace MvcTemplate.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using MvcTemplate.Services.Data;
    using MvcTemplate.Web.Infrastructure.Mapping;
    using MvcTemplate.Web.ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IJokesService jokes;

        private readonly IJokesCategoriesService jokeCategories;

        public HomeController(IJokesService jokes, IJokesCategoriesService jokeCategories)
        {
            this.jokes = jokes;
            this.jokeCategories = jokeCategories;
        }

        public ActionResult Index()
        {
            var randomJokes = this.jokes.GetRandomJokes(3).To<JokeViewModel>().ToList();
            var categories = this.CacheService.Get(
                "CategoriesList",
                () => this.jokeCategories.GetAll().To<JokeCategoryViewModel>().ToList(),
                60 * 60);
            var viewModel = new IndexViewModel { RandomJokes = randomJokes, Categories = categories };
            return this.View(viewModel);
        }
    }
}
