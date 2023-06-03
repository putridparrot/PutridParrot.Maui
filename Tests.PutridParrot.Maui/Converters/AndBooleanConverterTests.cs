using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Maui.Converters;

namespace Tests.PutridParrot.Maui.Converters;

[ExcludeFromCodeCoverage]
[TestFixture]
public class AndBooleanConverterTests
{
    [Test]
    public void AndBooleanConverter_IfContainNonBoolean_ReturnFalse()
    {
        var converter = new AndToBooleanConverter();

        var values = new object[] { true, false, 3 };

        object result = converter.Convert(values, null, null, null);
        Assert.False((bool)result);
    }

    [Test]
    public void AndBooleanConverter_IfTrueAndFalseBoolean_ReturnFalse()
    {
        var converter = new AndToBooleanConverter();

        var values = new object[] { true, false, true };

        object result = converter.Convert(values, null, null, null);
        Assert.False((bool)result);
    }

    [Test]
    public void AndBooleanConverter_IfAllFalseBoolean_ReturnFalse()
    {
        var converter = new AndToBooleanConverter();

        var values = new object[] { false, false, false };

        object result = converter.Convert(values, null, null, null);
        Assert.False((bool)result);
    }

    [Test]
    public void AndBooleanConverter_IfAllTrueBoolean_ReturnTrue()
    {
        var converter = new AndToBooleanConverter();

        var values = new object[] { true, true, true };

        object result = converter.Convert(values, null, null, null);
        Assert.True((bool)result);
    }
}