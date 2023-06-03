using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Maui.Converters;

namespace Tests.PutridParrot.Maui.Converters;

[ExcludeFromCodeCoverage]
[TestFixture]
public class NotBooleanConverterTests
{
    [Test]
    public void NotBooleanConverter_IfContainsNoBoolean_IgnoreActAsNotAroundAndAnd()
    {
        var converter = new NotBooleanConverter();

        var values = new object[] { true, false, 3 };

        object result = converter.Convert(values, null, null, null);
        Assert.True((bool)result);
    }

    [Test]
    public void NotBooleanConverter_IfTrueAndFalseBoolean_ReturnTrue()
    {
        var converter = new NotBooleanConverter();

        var values = new object[] { true, false, true };

        object result = converter.Convert(values, null, null, null);
        Assert.True((bool)result);
    }

    [Test]
    public void NotBooleanConverter_IfAllFalseBoolean_ReturnTrue()
    {
        var converter = new NotBooleanConverter();

        var values = new object[] { false, false, false };

        object result = converter.Convert(values, null, null, null);
        Assert.True((bool)result);
    }

    [Test]
    public void NotBooleanConverter_IfAllTrueBoolean_ReturnFalse()
    {
        var converter = new NotBooleanConverter();

        var values = new object[] { true, true, true };

        object result = converter.Convert(values, null, null, null);
        Assert.False((bool)result);
    }
}