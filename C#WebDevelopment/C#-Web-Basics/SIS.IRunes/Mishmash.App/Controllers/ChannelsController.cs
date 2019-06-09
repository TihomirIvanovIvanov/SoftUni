namespace Mishmash.App.Controllers
{
    using Data;
    using SIS.HTTP.Common;
    using SIS.MvcFramework;
    using SIS.MvcFramework.Attributes.Http;
    using SIS.MvcFramework.Result;
    using System.Linq;
    using ViewModels.Channels;

    public class ChannelsController : Controller
    {
        private readonly MishmashDbContext dbContext;

        public ChannelsController(MishmashDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet(Url = "/Channels/Details")]
        public ActionResult Details(string id)
        {
            if (this.User == null)
            {
                return this.Redirect(GlobalConstants.UsersLoginPath);
            }

            var channelViewModel = this.dbContext.Channels
                .Where(ch => ch.Id == id)
                .Select(ch => new ChannelViewModel
                {
                    Type = ch.Type,
                    Name = ch.Name,
                    Tags = ch.Tags.Select(t => t.Tag.Name),
                    Description = ch.Description,
                    FollowersCount = ch.Followers.Count()
                })
                .FirstOrDefault();

            return this.View(channelViewModel);
        }
    }
}
