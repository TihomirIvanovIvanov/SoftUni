namespace Mishmash.App.Controllers
{
    using Data;
    using Models;
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

        [HttpGet(Url = "/Channels/Followed")]
        public ActionResult Followed()
        {
            if (this.User == null)
            {
                return this.Redirect(GlobalConstants.UsersLoginPath);
            }

            var followedChannels = this.dbContext.Channels
                 .Where(ch => ch.Followers.Any(f => f.User.Username == this.User.Username))
                 .Select(ch => new FollowedChannelViewModel
                 {
                     Id = ch.Id,
                     Type = ch.Type,
                     Name = ch.Name,
                     FollowersCount = ch.Followers.Count()
                 })
                 .ToList();

            var viewModel = new FollowedChannelsViewModel
            {
                FollowedChannels = followedChannels
            };

            return this.View(viewModel);
        }

        [HttpGet(Url = "/Channels/Follow")]
        public ActionResult Follow(string id)
        {
            var user = this.dbContext.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user == null)
            {
                return this.Redirect(GlobalConstants.UsersLoginPath);
            }

            if (!this.dbContext.UserInChannel.Any(u => u.UserId == user.Id && u.ChannelId == id))
            {
                this.dbContext.UserInChannel.Add(new UserInChannel
                {
                    ChannelId = id,
                    UserId = user.Id,
                });

                this.dbContext.SaveChanges();
            }

            return this.Redirect("/Channels/Followed");
        }

        [HttpGet(Url = "/Channels/Unfollow")]
        public ActionResult Unfollow(string id)
        {
            var user = this.dbContext.Users.FirstOrDefault(u => u.Username == this.User.Username);

            if (user == null)
            {
                return this.Redirect(GlobalConstants.UsersLoginPath);
            }

            var userInChannel = this.dbContext.UserInChannel
                .FirstOrDefault(u => u.UserId == user.Id && u.ChannelId == id);

            if (userInChannel != null)
            {
                this.dbContext.UserInChannel.Remove(userInChannel);
                this.dbContext.SaveChanges();
            }
             
            return this.Redirect("/Channels/Followed");
        }
    }
}
