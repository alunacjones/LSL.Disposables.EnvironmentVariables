using System;
using FluentAssertions;

namespace LSL.Disposables.EnvironmentVariables.Tests;

public class DisposableEnvironmentVariablesTests
{
    [Test]
    public void GivenStuff()
    {
        Environment.SetEnvironmentVariable("First", "aValue");
        Environment.SetEnvironmentVariable("Second", "secondOne");

        using (var environment = new DisposableEnvironmentVariables())
        {
            Environment.SetEnvironmentVariable("Test", "hello");
            Environment.SetEnvironmentVariable("First", "Another");
            Environment.SetEnvironmentVariable("Second", null);

            Environment.GetEnvironmentVariable("Test").Should().Be("hello");
            Environment.GetEnvironmentVariable("First").Should().Be("Another");
            Environment.GetEnvironmentVariable("Second").Should().Be(null);
        }

        Environment.GetEnvironmentVariable("Test").Should().BeNull();
        Environment.GetEnvironmentVariable("First").Should().Be("aValue");
        Environment.GetEnvironmentVariable("Second").Should().Be("secondOne");
    }
}