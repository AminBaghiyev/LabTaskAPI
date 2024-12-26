using Microsoft.Extensions.Configuration;

namespace ECommerce.BL.Utilities;

public class Connection
{
    public static string GetConnectionString()
    {
        ConfigurationManager configurationManager = new();
        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "ECommerce.API"));
        configurationManager.AddJsonFile("appsettings.json");

        return
            configurationManager.GetConnectionString("MsSql") ??
            throw new Exception("Connection string not found!");
    }
}
