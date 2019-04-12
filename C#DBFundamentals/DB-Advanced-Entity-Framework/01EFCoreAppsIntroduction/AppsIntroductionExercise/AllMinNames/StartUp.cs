namespace AllMinNames
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class StartUp
    {
        public static void Main()
        {
            string connectionString = @"Server=.;Database=MinionsDB;Integrated Security=True";
            var connection = new SqlConnection(connectionString);
            connection.Open();

            using (connection)
            {
                try
                {
                    string query = "SELECT [Name] FROM Minions";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataReader reader = cmd.ExecuteReader();
                    List<string> names = new List<string>();
                    using (reader)
                    {
                        try
                        {
                            while (reader.Read())
                            {
                                names.Add(Convert.ToString(reader[0]));
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    for (int i = 0; i <= names.Count / 2; i++)
                    {
                        Console.WriteLine(names[i]);
                        if (i != names.Count - 1 - i)
                        {
                            Console.WriteLine(names[names.Count - 1 - i]);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
