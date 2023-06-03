using System.Diagnostics.CodeAnalysis;
using Microsoft.Maui;
using NUnit.Framework;
using PutridParrot.Maui.Converters;

namespace Tests.PutridParrot.Maui.Converters;

[ExcludeFromCodeCoverage]
[TestFixture]
public class BooleanToVisibilityConverterTests
{
    [Test]
    public void BooleanToVisibilityConverter_EnsureDefaultForTrueIsVisible()
    {
        var converter = new BooleanToVisibilityConverter();

        Visibility visibility = (Visibility)converter.Convert(true, null, null, null);
        Assert.AreEqual(Visibility.Visible, visibility);
    }

    [Test]
    public void BooleanToVisibilityConverter_EnsureDefaultForFalseIsCollapsed()
    {
        var converter = new BooleanToVisibilityConverter();

        Visibility visibility = (Visibility)converter.Convert(false, null, null, null);
        Assert.AreEqual(Visibility.Collapsed, visibility);
    }

    [Test]
    public void BooleanToVisibilityConverter_WhenTrueIsNotVisible_EnsureTrueReturnsWhenTrueValue()
    {
        var converter = new BooleanToVisibilityConverter
        {
            WhenTrue = Visibility.Hidden,
            WhenFalse = Visibility.Visible
        };

        Visibility visibility = (Visibility)converter.Convert(true, null, null, null);
        Assert.AreEqual(Visibility.Hidden, visibility);
    }

    [Test]
    public void BooleanToVisibilityConverter_WhenFalseIsNotCollapsed_EnsureFalseReturnsWhenFalseValue()
    {
        var converter = new BooleanToVisibilityConverter
        {
            WhenTrue = Visibility.Collapsed,
            WhenFalse = Visibility.Hidden
        };

        Visibility visibility = (Visibility)converter.Convert(false, null, null, null);
        Assert.AreEqual(Visibility.Hidden, visibility);
    }
}