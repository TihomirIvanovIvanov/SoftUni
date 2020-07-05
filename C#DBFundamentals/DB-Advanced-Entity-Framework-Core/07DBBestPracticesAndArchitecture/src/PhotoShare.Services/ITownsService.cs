namespace PhotoShare.Services
{
    using PhotoShare.Models;

    public interface ITownsService
    {
        Town Create(string townName, string countryName);

        Town ByName(string name);
    }
}
