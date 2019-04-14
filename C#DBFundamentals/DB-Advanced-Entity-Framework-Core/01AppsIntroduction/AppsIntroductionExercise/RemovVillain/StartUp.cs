namespace RemovVillain
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
                try
                {
                    string nameQuery = "SELECT [Name] FROM Villains WHERE Id = @villainId";
                    SqlCommand nameCmd = new SqlCommand(nameQuery, connection);
                    nameCmd.Parameters.AddWithValue("@villainId", villainId);

                    SqlDataReader reader = nameCmd.ExecuteReader();
                    if (!reader.Read())
                    {
                        throw new ArgumentException("No such villain was found.");
                    }
                    string villainName = Convert.ToString(reader[0]);
                    reader.Close();

                    string mvQuery = "DELETE FROM MinionsVillains WHERE VillainId = @villainId";
                    SqlCommand mvCommand = new SqlCommand(mvQuery, connection);
                    mvCommand.Parameters.AddWithValue("@villainId", villainId);
                    int minionsReleased = mvCommand.ExecuteNonQuery();

                    string villainQuery = "DELETE FROM Villains WHERE Id = @villainId";
                    SqlCommand villainCmd = new SqlCommand(villainQuery, connection);
                    villainCmd.Parameters.AddWithValue("@villainId", villainId);
                    villainCmd.ExecuteNonQuery();

                    Console.WriteLine($"{villainName} was deleted.");
                    Console.WriteLine($"{minionsReleased} minions were released.");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
