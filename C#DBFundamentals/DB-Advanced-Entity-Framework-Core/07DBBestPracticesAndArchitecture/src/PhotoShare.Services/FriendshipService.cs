using PhotoShare.Data;
using PhotoShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoShare.Services
{
    public class FriendshipService : IFriendshipService
    {
        private readonly PhotoShareContext context;

        private readonly IUsersService usersService;

        public FriendshipService(PhotoShareContext context, IUsersService usersService)
        {
            this.context = context;
            this.usersService = usersService;
        }

        public void AcceptFriend(string userUsername, string friendUsername)
        {
            var user = this.usersService.ByUsername(userUsername);

            if (user == null)
            {
                throw new ArgumentException($"{userUsername} not found!");
            }

            var friend = this.usersService.ByUsername(friendUsername);

            if (friend == null)
            {
                throw new ArgumentException($"{friendUsername} not found!");
            }

            var invitationSent = this.context.Friendships
                .Any(fr => fr.User == user && fr.Friend == friend);

            if (!invitationSent)
            {
                throw new InvalidOperationException($"{friend.Username} has not added {user.Username} as a friend");
            }

            var friendshipExists =
               this.context.Friendships
               .Any(fr => fr.User == user && fr.Friend == friend) &&
               this.context.Friendships
               .Any(fr => fr.User == friend && fr.Friend == user);

            if (friendshipExists)
            {
                throw new InvalidOperationException($"{friend.Username} is already a friend to {user.Username}!");
            }

            this.context.Friendships.Add(new Friendship { User = user, Friend = friend });
            this.context.SaveChanges();
        }

        public void AddFriend(string userUsername, string friendUsername)
        {
            var user = this.usersService.ByUsername(userUsername);

            if (user == null)
            {
                throw new ArgumentException($"{userUsername} not found!");
            }

            var friend = this.usersService.ByUsername(friendUsername);

            if (friend == null)
            {
                throw new ArgumentException($"{friendUsername} not found!");
            }

            var invitationSent = context.Friendships.Any(fr => fr.User == user && fr.Friend == friend);

            if (invitationSent)
            {
                throw new InvalidOperationException($"{user.Username} has already added {friend.Username} as a friend");
            }

            var friendshipExists =
                this.context.Friendships
                .Any(fr => fr.User == user && fr.Friend == friend) &&
                this.context.Friendships
                .Any(fr => fr.User == friend && fr.Friend == user);

            if (friendshipExists)
            {
                throw new InvalidOperationException($"{friend.Username} is already a friend to {user.Username}");
            }

            this.context.Friendships.Add(new Friendship { User = user, Friend = friend });
            this.context.SaveChanges();
        }

        public List<string> ListFriends(string username)
        {
            var user = this.usersService.ByUsername(username);

            if (user == null)
            {
                throw new ArgumentException($"User {username} not found!");
            }

            var addedFriends = this.context.Friendships
                .Where(f => f.User == user)
                .Select(f => f.Friend.Username)
                .ToList();

            var acceptedFriends = this.context.Friendships
                .Where(f => f.Friend == user)
                .Select(f => f.User.Username)
                .ToList();

            return addedFriends.Intersect(acceptedFriends).ToList();
        }
    }
}
