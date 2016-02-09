namespace MvcTemplate.Services.Data
{
    using System;
    using System.Linq;

    using MvcTemplate.Data.Common;
    using MvcTemplate.Data.Models;

    public class JokesService : IJokesService
    {
        private readonly IDbRepository<Joke> jokes;

        public JokesService(IDbRepository<Joke> jokes)
        {
            this.jokes = jokes;
        }

        public IQueryable<Joke> GetRandomJokes(int count)
        {
            return this.jokes.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }
    }
}
