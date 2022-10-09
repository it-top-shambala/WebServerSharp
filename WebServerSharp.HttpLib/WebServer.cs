using System.Net;
using System.Text;
using WebServerSharp.ConfigLib;

namespace WebServerSharp.HttpLib;

public class WebServer
{
    private readonly HttpListener _httpListener;
    private readonly string _localPath;

    public WebServer()
    {
        var serverConfig = WebServerSharpConfig.ImportFromJson();

        _httpListener = new HttpListener();
        _httpListener.Prefixes.Add(serverConfig.ToString());

        _localPath = serverConfig.LocalPath;
    }

    public async Task StartAsync()
    {
        _httpListener.Start();

        while (true)
        {
            var context = await _httpListener.GetContextAsync();
            var response = context.Response;

            var url = context.Request.RawUrl?[1..];
            var fullPath = $@"{_localPath}\{url}";

            if (!Directory.Exists(fullPath))
            {
                OutputError(response, $"{fullPath} - not find");
            }
            else
            {
                Output(response, fullPath);
            }
        }
    }

    private void OutputError(HttpListenerResponse response, string message)
    {
        var responseString = $"<html><head><meta charset='utf8'></head><body><h1>Error</h1><hr><p>{message}</p></body></html>";
        var buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.LongLength;
        using var output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
    }

    private void Output(HttpListenerResponse response, string path)
    {
        var responseString = File.ReadAllText($"{path}/index.html");
        var buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.LongLength;
        using var output = response.OutputStream;
        output.Write(buffer, 0, buffer.Length);
    }
}
