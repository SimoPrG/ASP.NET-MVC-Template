namespace JokesCrawler
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using AngleSharp;

    using MvcTemplate.Data;
    using MvcTemplate.Data.Models;

    public static class Program
    {
        private static ApplicationDbContext db = new ApplicationDbContext();

        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, MvcTemplate.Data.Migrations.Configuration>());
            var configuration = Configuration.Default.WithDefaultLoader();
            var browsingContext = AngleSharp.BrowsingContext.New(configuration);
            for (int i = 1; i < 1000; i++)
            {
                var document = browsingContext.OpenAsync($"http://vicove.com/vic-{i}").Result;
                var content = document.QuerySelector("#content_box .post-content").TextContent.Trim();
                if (!string.IsNullOrWhiteSpace(content))
                {
                    var categoryName = document.QuerySelector(".thecategory a").TextContent.Trim();
                    var category = EnsureCategory(categoryName);
                    var joke = new Joke { Category = category, Content = content };
                    db.Jokes.Add(joke);
                    db.SaveChanges();
                    Console.WriteLine(i);
                }
            }
        }

        private static JokeCategory EnsureCategory(string name)
        {
            var category = db.JokeCategories.FirstOrDefault(x => x.Name == name);
            if (category != null)
            {
                return category;
            }

            category = new JokeCategory { Name = name };
            db.JokeCategories.Add(category);
            db.SaveChanges();
            return category;
        }
    }
}
