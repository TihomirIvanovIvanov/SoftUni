using Panda.Data;
using Panda.Models;
using System.Linq;

namespace Panda.Services
{
    public class PackagesService : IPackagesService
    {
        private readonly PandaDbContext pandaDbContext;

        private readonly IReceipstService receipstService;

        public PackagesService(PandaDbContext pandaDbContext, IReceipstService receipstService)
        {
            this.pandaDbContext = pandaDbContext;
            this.receipstService = receipstService;
        }

        public void Create(string description, decimal weight, string shippingAddress, string recipientName)
        {
            var userId = this.pandaDbContext.Users
                .Where(u => u.Username == recipientName)
                .Select(x => x.Id).FirstOrDefault();

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
                RecipientId = userId,
            };

            this.pandaDbContext.Packages.Add(package);
            this.pandaDbContext.SaveChanges();
        }

        public void Deliver(string id)
        {
            var package = this.pandaDbContext.Packages.FirstOrDefault(x => x.Id == id);

            if (package == null)
            {
                return;
            }

            package.Status = PackageStatus.Delivered;
            this.pandaDbContext.SaveChanges();

            this.receipstService.CreateFromPackage(package.Weight, package.Id, package.RecipientId);
        }

        public IQueryable<Package> GetAllByStatus(PackageStatus status)
        {
            var packages = this.pandaDbContext.Packages.Where(x => x.Status == status);
            return packages;
        }
    }
}
