using System.Text.Json;

namespace WebServerSharp.ConfigLib;

public record WebServerSharpConfig()
{
    public string Scheme { get; set; } = "http";
    public string Host { get; set; } = "localhost";
    public int Port { get; set; } = 8005;
    public string LocalPath { get; set; } = @"C:\WebServerSharp";

    public override string ToString()
    {
        return $"{Scheme}://{Host}:{Port}/";
    }

    public static WebServerSharpConfig ImportFromJson(string path = "config.json")
    {
        if (!File.Exists(path))
        {
            return new WebServerSharpConfig();
        }

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
