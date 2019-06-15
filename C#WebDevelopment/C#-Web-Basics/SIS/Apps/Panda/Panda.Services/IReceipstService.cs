namespace Panda.Services
{
    public interface IReceipstService
    {
        void CreateFromPackage(decimal weight, string packageId, string recipientId);
    }
}
