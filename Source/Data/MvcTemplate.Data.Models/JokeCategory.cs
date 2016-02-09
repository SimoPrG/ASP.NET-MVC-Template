namespace MvcTemplate.Data.Models
{
    using MvcTemplate.Data.Common.Models;

    public class JokeCategory : BaseModel<int>
    {
        public string Name { get; set; }
    }
}
