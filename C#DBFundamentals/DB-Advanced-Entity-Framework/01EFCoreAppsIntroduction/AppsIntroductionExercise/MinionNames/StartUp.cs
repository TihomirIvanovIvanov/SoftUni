namespace MinionNames
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

            int villainId = int.Parse(Console.ReadLine());

            using (connection)
            {
                string villainQuery = "SELECT [Name] FROM Villains WHERE Id = @villainId";
                var villainCommand = new SqlCommand(villainQuery, connection);

                villainCommand.Parameters.AddWithValue("@villainId", villainId);
                var reader = villainCommand.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Villain: {reader[0]}");
                }
                reader.Close();

                string minionsQuery = @"SELECT [Name], Age FROM Minions AS m
                                          JOIN MinionsVillains AS mv
                                            ON m.Id = mv.MinionId
                                         WHERE mv.VillainId = @villainId";
                var minionsCommand = new SqlCommand(minionsQuery, connection);
                minionsCommand.Parameters.AddWithValue("@villainId", villainId);

                reader = minionsCommand.ExecuteReader();
                int count = 1;

                while (reader.Read())
                {
                    Console.WriteLine($"{count}. {reader[0]} {reader[1]}");
                    count++;
                }
                reader.Close();
            }
        }
    }
}
