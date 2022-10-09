using Xunit;

namespace WebServerSharp.ConfigLib.Test;

public class WebServerSharpConfigTest
{
    private readonly WebServerSharpConfig _expectedConfigDefault;
    private readonly WebServerSharpConfig _expectedConfig;

    public WebServerSharpConfigTest()
    {
        _expectedConfigDefault = new WebServerSharpConfig();
        _expectedConfig = new WebServerSharpConfig
        {
            Scheme = "https",
            Host = "localhost",
            Port = 8007,
            LocalPath = @"C:\WebServerSharp"
        };
    }

    [Fact]
    public void ImportFromJsonTestNotFile()
    {
        var actualConfig = WebServerSharpConfig.ImportFromJson("1234");
        Assert.Equal(_expectedConfigDefault, actualConfig);
    }

    [Fact]
    public void ImportFromJsonTestConfigJson()
    {
        var actualConfig = WebServerSharpConfig.ImportFromJson();
        Assert.Equal(_expectedConfig, actualConfig);
    }
}
