using Xunit;

namespace WebServerSharp.ConfigLib.Test;

public class WebServerSharpConfigTest
{
    private WebServerSharpConfig _expectedConfigDefault;
    private WebServerSharpConfig _expectedConfig;

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
    public void ImportFromJson_Test_NotFile()
    {
        var actualConfig = WebServerSharpConfig.ImportFromJson("1234");
        Assert.Equal(_expectedConfigDefault, actualConfig);
    }

    [Fact]
    public void ImportFromJson_Test_ConfigJson()
    {
        var actualConfig = WebServerSharpConfig.ImportFromJson();
        Assert.Equal(_expectedConfig, actualConfig);
    }
}
