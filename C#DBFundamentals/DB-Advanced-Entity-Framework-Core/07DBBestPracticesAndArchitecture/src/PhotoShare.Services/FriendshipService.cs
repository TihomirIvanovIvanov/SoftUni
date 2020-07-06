﻿using PhotoShare.Data;
using PhotoShare.Models;
using System;
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
    }
}
