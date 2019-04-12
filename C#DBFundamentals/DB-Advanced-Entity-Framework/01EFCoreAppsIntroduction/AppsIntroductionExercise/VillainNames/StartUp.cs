namespace VillainNames
{
    using System;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=True";
            var connection = new SqlConnection(connectionString);
            connection.Open();

            string query = @"SELECT v.Name, COUNT(vm.VillainId) AS MinionsCount FROM Villains AS v
                               JOIN MinionsVillains AS vm
                                 ON v.Id = vm.VillainId
                           GROUP BY v.Name
                             HAVING COUNT(vm.VillainId) > 3
                           ORDER BY MinionsCount DESC";
            SqlCommand cmd = new SqlCommand(query, connection);

            using (connection)
            {
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string villainName = (string)reader["Name"];
                    int minionsCount = (int)reader["MinionsCount"];

                    Console.WriteLine($"{villainName} - {minionsCount}");
                }
            }
        }
    }
}
