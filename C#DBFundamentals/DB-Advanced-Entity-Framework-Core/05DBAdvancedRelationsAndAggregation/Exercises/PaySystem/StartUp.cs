using PaySystem.Data;

namespace PaySystem
{
    public class StartUp
    {
        public static void Main()
        {
            using var dbContext = new BillsPaymentSystemContext();
            dbContext.Database.EnsureCreated();
        }
    }
}
