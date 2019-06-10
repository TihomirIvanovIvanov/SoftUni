namespace Mishmash.App.Controllers
{
    using Data;
    using SIS.HTTP.Common;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;
    using System.Linq;
    using ViewModels.Channels;
    using ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly MishmashDbContext dbContext;

        public HomeController(MishmashDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Url = GlobalConstants.HomeRedirectPath)]
        public ActionResult IndexSlash()
        {
            return this.Index();
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult HomeIndex()
        { 
            var user = this.dbContext.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user != null)
            {
                var viewModel = new LoggedInIndexViewModel();
                viewModel.UserRole = user.Role.ToString();

                viewModel.YourChannel = this.dbContext.Channels
                    .Where(ch => ch.Followers.Any(f => f.User.Username == this.User.Username))
                    .Select(ch => new FollowedChannelViewModel
                    {
                        Id = ch.Id,
                        Type = ch.Type,
                        Name = ch.Name,
                        FollowersCount = ch.Followers.Count()
                    })
                    .ToList();

                var follwedChannelsTags = this.dbContext.Channels
                    .Where(ch => ch.Followers.Any(f => f.User.Username == this.User.Username))
                    .SelectMany(ch => ch.Tags.Select(t => t.Id))
                    .ToList();

                viewModel.SuggestedChannels = this.dbContext.Channels
                    .Where(ch => !ch.Followers.Any(f => f.User.Username == this.User.Username)
                    && ch.Tags.Any(t => follwedChannelsTags.Contains(t.Id)))
                    .Select(ch => new FollowedChannelViewModel
                    {
                        Id = ch.Id,
                        Type = ch.Type,
                        Name = ch.Name,
                        FollowersCount = ch.Followers.Count()
                    })
                    .ToList();

                var ids = viewModel.YourChannel.Select(ch => ch.Id).ToList();
                ids = ids.Concat(viewModel.SuggestedChannels.Select(ch => ch.Id)).ToList();
                ids = ids.Distinct().ToList();

                viewModel.SeeOtherChannels = this.dbContext.Channels
                    .Where(ch => !ids.Contains(ch.Id))
                    .Select(ch => new FollowedChannelViewModel
                    {
                        Id = ch.Id,
                        Type = ch.Type,
                        Name = ch.Name,
                        FollowersCount = ch.Followers.Count()
                    })
                    .ToList();

                return this.View("Home/LoggedInIndex");
            }
            else
            {
                return this.View("Home/Index");
            }
        }
    }
}
