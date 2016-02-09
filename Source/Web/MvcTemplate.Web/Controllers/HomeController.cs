namespace MvcTemplate.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;
    using MvcTemplate.Web.Infrastructure.Mapping;
    using MvcTemplate.Web.ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IDbRepository<Joke> jokes;

        private readonly IDbRepository<JokeCategory> jokeCategories;

        public HomeController(IDbRepository<Joke> jokes, IDbRepository<JokeCategory> jokeCategories)
        {
            this.jokes = jokes;
            this.jokeCategories = jokeCategories;
        }

        public ActionResult Index()
        {
            var randomJokes = this.jokes.All().OrderBy(x => Guid.NewGuid()).To<JokeViewModel>().Take(3).ToList();
            var categories = this.jokeCategories.All().OrderBy(x => x.Name).To<JokeCategoryViewModel>().ToList();
            var viewModel = new IndexViewModel { RandomJokes = randomJokes, Categories = categories };
            return this.View(viewModel);
        }
    }
}
