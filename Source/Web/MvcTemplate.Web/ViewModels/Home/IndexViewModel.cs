namespace MvcTemplate.Web.ViewModels.Home
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<JokeViewModel> RandomJokes { get; set; }

        public IEnumerable<JokeCategoryVIewModel> Categories { get; set; }
    }
}
