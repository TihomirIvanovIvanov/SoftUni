namespace PhotoShare.Services
{
    using PhotoShare.Models;

    public interface IAlbumsService
    {
        Tag CreateTag(string name);
    }
}
