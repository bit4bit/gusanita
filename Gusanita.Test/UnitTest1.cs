namespace Gusanita.Test;

using Gusanita.Core;

public class Tests
{
    [SetUp]
    public void Setup()
    {
        new Gusanita();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}
