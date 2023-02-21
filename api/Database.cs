using Npgsql;

class Database {
    private static NpgsqlDataSource? dataSource = null;
    private static NpgsqlConnection? cnn = null;
    public static void openConnectDb() {
        var connectionString = "Server=db;Port=5432;Database=loli;User Id=postgres;Password=078098;";
        dataSource = NpgsqlDataSource.Create(connectionString);
        
        try {
            cnn = dataSource.OpenConnection();
            Console.WriteLine("connect to db");
        } catch (Exception ex) {
            dataSource = null;
            Console.WriteLine("error connection to db:" + ex);
        }
    }   

    public static string request() {
        string response = "";
        if (dataSource != null) {
            var cmd = dataSource.CreateCommand("SELECT * from users");
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                response += reader.GetString(0);
        }  
        return response;
    }

    public static void closeConnectDb() {
        try {
            cnn?.Close();
            dataSource?.Dispose();
            Console.WriteLine("Close connection to db");
        } catch (Exception ex) {
            Console.WriteLine("Error close connection to db" + ex);
        }
    }
}