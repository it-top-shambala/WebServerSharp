using System.Text.Json;

namespace WebServerSharp.ConfigLib;

public class WebServerSharpConfig
{
    public string Scheme { get; set; }
    public string Host { get; set; }
    public int Port { get; set; }
    public string LocalPath { get; set; }

    public WebServerSharpConfig()
    {
        Scheme = "http";
        Host = "localhost";
        Port = 8005;
        LocalPath = @"C:\WebServerSharp";
    }

    public static WebServerSharpConfig ImportFromJson(string path = "config.json")
    {
        if (!File.Exists(path)) return new WebServerSharpConfig();

        try
        {
            var json = File.ReadAllText(path);
            var config = JsonSerializer.Deserialize<WebServerSharpConfig>(json);
            return config;
        }
        catch (Exception)
        {
            return new WebServerSharpConfig();
        }
    }
}
