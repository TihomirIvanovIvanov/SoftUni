namespace PhotoShare.Services
{
    using PhotoShare.Data;
    using PhotoShare.Models;
    using System;
    using System.Linq;

    public class TownsService : ITownsService
    {
        private readonly PhotoShareContext context;

        public TownsService(PhotoShareContext context)
        {
            this.context = context;
        }

        public Town ByName(string name)
        {
            var town = this.context.Towns
                .FirstOrDefault(t => t.Name == name);

            return town;
        }

        public Town Create(string townName, string countryName)
        {
            var town = this.ByName(townName);

            if (town != null)
            {
                throw new ArgumentNullException($"Town {townName} was already added!");
            }

            town = new Town
            {
                Name = townName,
                Country = countryName,
            };

            this.context.Towns.Add(town);
            this.context.SaveChanges();

            return town;
        }
    }
}
