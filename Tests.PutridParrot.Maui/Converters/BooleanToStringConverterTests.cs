using System.Diagnostics.CodeAnalysis;
using NUnit.Framework;
using PutridParrot.Maui.Converters;

namespace Tests.PutridParrot.Maui.Converters;

[ExcludeFromCodeCoverage]
[TestFixture]
public class BooleanToStringConverterTests
{
    [Test]
    public void Constructor_Default_ExpectWhenTrueToBeTrue()
    {
        var c = new BooleanToStringConverter();
        Assert.AreEqual("True", c.WhenTrue);
    }

    [Test]
    public void Constructor_Default_ExpectWhenFalseToBeFalse()
    {
        var c = new BooleanToStringConverter();
        Assert.AreEqual("False", c.WhenFalse);
    }

    [Test]
    public void Constructor_WithArgs_WhenTrueChanged_ExpectChangedValue()
    {
        var c = new BooleanToStringConverter("T", "F");
        Assert.AreEqual("T", c.WhenTrue);
    }

    [Test]
    public void Constructor_WithArgs_WhenFalseChanged_ExpectChangedValue()
    {
        var c = new BooleanToStringConverter("T", "F");
        Assert.AreEqual("F", c.WhenFalse);
    }

    [Test]
    public void Convert_NonBooleanToString_ExpectNull()
    {
        var c = new BooleanToStringConverter();
        Assert.AreEqual(BindableProperty.UnsetValue, c.Convert("NotBoolean", typeof(string), null, null));
    }

    [Test]
    public void Convert_BooleanTrue_ExpectWhenTrueValue()
    {
        var c = new BooleanToStringConverter();
        Assert.AreEqual("True", c.Convert(true, typeof(bool), null, null));
    }

    [Test]
    public void Convert_BooleanFalse_ExpectWhenFalseValue()
    {
        var c = new BooleanToStringConverter();
        Assert.AreEqual("False", c.Convert(false, typeof(bool), null, null));
    }

    [Test]
    public void ConvertBack_NonStringToBoolean_ExpectFalse()
    {
        var c = new BooleanToStringConverter();
        Assert.AreEqual(BindableProperty.UnsetValue, c.ConvertBack(true, typeof(bool), null, null));
    }

    [Test]
    public void Convert_StringTrue_ExpectTrue()
    {
        var c = new BooleanToStringConverter();
        Assert.IsTrue((bool)c.ConvertBack("True", typeof(bool), null, null));
    }

    [Test]
    public void Convert_StringFalse_ExpectFalse()
    {
        var c = new BooleanToStringConverter();
        Assert.IsFalse((bool)c.ConvertBack("False", typeof(bool), null, null));
    }

    [Test]
    public void Convert_StringNeitherTrueOrFalse_ExpectFalse()
    {
        var c = new BooleanToStringConverter();
        Assert.IsFalse((bool)c.ConvertBack("F", typeof(bool), null, null));
    }

}