using Microsoft.Extensions.Configuration;

namespace HospitalManagement.DL.Utilities;

public static class Connection
{
    public static string GetConnectionString(string key = "MsSql")
    {
        ConfigurationManager configurationManager = new();
        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "HospitalManagement.API"));
        configurationManager.AddJsonFile("appsettings.json");

        return
            configurationManager.GetConnectionString(key) ??
            throw new Exception("Connection string not found!");
    }
}
