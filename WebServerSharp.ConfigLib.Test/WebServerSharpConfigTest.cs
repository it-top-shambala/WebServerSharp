using Xunit;

namespace WebServerSharp.ConfigLib.Test;

public class WebServerSharpConfigTest
{
    private WebServerSharpConfig ExpectedConfigDefault { get => new(); }

    [Fact]
    public void ImportFromJson_Test_NotFile()
    {
        var actualConfig = WebServerSharpConfig.ImportFromJson("1234");
        Assert.Equal(ExpectedConfigDefault, actualConfig);
    }
}
