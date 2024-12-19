using Microsoft.Extensions.Configuration;

namespace WorkshopManagement.BL.Utilities;

public class Connection
{
    public static string GetConnectionStr()
    {
        ConfigurationManager configurationManager = new ConfigurationManager();
        configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "WorkshopManagement.API"));
        configurationManager.AddJsonFile("appsettings.json");

        return configurationManager.GetConnectionString("MsSql");
    }
}
