using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Maui.Converters;

namespace Tests.PutridParrot.Maui.Converters;

[ExcludeFromCodeCoverage]
[TestFixture]
public class XorBooleanConverterTests
{
    [Test]
    public void XorBooleanConverter_IfContainNonBoolean_ReturnTrue()
    {
        var converter = new XorBooleanConverter();

        var values = new object[] { true, false, 3 };

        object result = converter.Convert(values, null, null, null);
        Assert.True((bool)result);
    }

    [Test]
    public void XorBooleanConverter_IfTrueAndFalseBoolean_ReturnTrue()
    {
        var converter = new XorBooleanConverter();

        var values = new object[] { true, false, true };

        object result = converter.Convert(values, null, null, null);
        Assert.True((bool)result);
    }

    [Test]
    public void XorBooleanConverter_IfAllFalseBoolean_ReturnFalse()
    {
        var converter = new XorBooleanConverter();

        var values = new object[] { false, false, false };

        object result = converter.Convert(values, null, null, null);
        Assert.False((bool)result);
    }

    [Test]
    public void XorBooleanConverter_IfAllTrueBoolean_ReturnFalse()
    {
        var converter = new XorBooleanConverter();

        var values = new object[] { true, true, true };

        object result = converter.Convert(values, null, null, null);
        Assert.False((bool)result);
    }
}