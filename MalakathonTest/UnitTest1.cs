using FluentAssertions;

namespace MalakathonTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void Test1()
    {
        false.Should().BeTrue();
    }
}