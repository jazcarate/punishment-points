namespace PunishmentPointsApp.Configurations
{
    public class DatabaseMangler
    {
        public static string mangle(string dbEnv){
            string[] parts = dbEnv.Split(":");
            string[] passwordHost = parts[2].Split("@");
            string[] portBase = parts[3].Split("/");
            
            string user = parts[1].Substring(2);;
            string password = passwordHost[0];
            string host = passwordHost[1];
            string port = portBase[0];
            string database = portBase[1];

            return $"Server={host};Port={port};Database={database};User Id={user};Password={password};";
        }
    }
}