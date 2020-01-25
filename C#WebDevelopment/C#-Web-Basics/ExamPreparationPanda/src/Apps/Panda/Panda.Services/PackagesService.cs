using Panda.Data;
using Panda.Data.Models;
using System.Linq;

namespace Panda.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly PandaDbContext context;

        public PackagesService(PandaDbContext context)
        {
            this.context = context;
        }

        public void Create(string description, decimal weight, string shippingAddress, string recipientName)
        {
            var userId = this.context.Users
                .Where(user => user.Username == recipientName)
                .Select(user => user.Id)
                .FirstOrDefault();

            if (userId == null)
            {
                return;
            }

            var package = new Package
            {
                Description = description,
                Weight = weight,
                Status = PackageStatus.Pending,
                ShippingAddress = shippingAddress,
                RecipientId = userId
            };

            this.context.Packages.Add(package);
            this.context.SaveChanges();
        }

        public IQueryable<Package> GetAllByStatus(PackageStatus status)
        {
            var packages = this.context.Packages
                .Where(package => package.Status == status);

            return packages;
        }
    }
}
