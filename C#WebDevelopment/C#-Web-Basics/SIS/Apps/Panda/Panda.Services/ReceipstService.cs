using Panda.Data;
using Panda.Models;
using System;

namespace Panda.Services
{
    public class ReceipstService : IReceipstService
    {
        private readonly PandaDbContext pandaDbContext;

        public ReceipstService(PandaDbContext pandaDbContext)
        {
            this.pandaDbContext = pandaDbContext;
        }

        public void CreateFromPackage(decimal weight, string packageId, string recipientId)
        {
            var receipt = new Receipt
            {
                PackageId = packageId,
                RecipientId = recipientId,
                Fee = weight * 2.67M,
                IssuedOn = DateTime.UtcNow
            };

            this.pandaDbContext.Receipts.Add(receipt);
            this.pandaDbContext.SaveChanges();
        }
    }
}
