using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Maui.Converters;

namespace Tests.PutridParrot.Maui.Converters;

[ExcludeFromCodeCoverage]
[TestFixture]
public class OrToBooleanConverterTests
{
    [Test]
    public void OrToBooleanConverter_IfContainNonBoolean_ReturnTrue()
    {
        var converter = new OrToBooleanConverter();

        var values = new object[] { true, false, 3 };

        object result = converter.Convert(values, null, null, null);
        Assert.True((bool)result);
    }

    [Test]
    public void OrToBooleanConverter_IfTrueAndFalseBoolean_ReturnTrue()
    {
        var converter = new OrToBooleanConverter();

        var values = new object[] { true, false, true };

        object result = converter.Convert(values, null, null, null);
        Assert.True((bool)result);
    }

    [Test]
    public void OrToBooleanConverter_IfAllFalseBoolean_ReturnFalse()
    {
        var converter = new OrToBooleanConverter();

        var values = new object[] { false, false, false };

        object result = converter.Convert(values, null, null, null);
        Assert.False((bool)result);
    }

    [Test]
    public void OrToBooleanConverter_IfAllTrueBoolean_ReturnTrue()
    {
        var converter = new OrToBooleanConverter();

        var values = new object[] { true, true, true };

        object result = converter.Convert(values, null, null, null);
        Assert.True((bool)result);
    }
}