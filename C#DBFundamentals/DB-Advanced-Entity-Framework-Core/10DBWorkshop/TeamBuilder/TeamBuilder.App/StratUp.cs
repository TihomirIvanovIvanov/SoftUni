using TeamBuilder.Data;

namespace TeamBuilder.App
{
    public class StratUp
    {
        static void Main(string[] args)
        {
            using (var context = new TeamBuilderContext())
            {
                context.Database.EnsureCreated();
            }
        }
    }
}
