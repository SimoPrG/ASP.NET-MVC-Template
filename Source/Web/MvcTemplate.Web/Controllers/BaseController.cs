namespace MvcTemplate.Web.Controllers
{
    using System.Web.Mvc;

    using MvcTemplate.Services.Common;

    public class BaseController : Controller
    {
        public ICacheService CacheService { protected get; set; }
    }
}
