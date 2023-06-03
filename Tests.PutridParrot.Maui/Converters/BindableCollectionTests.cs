using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using FluentAssertions;
using NUnit.Framework;
using PutridParrot.Maui.Collections;

namespace Tests.PutridParrot.Maui.Converters;

[ExcludeFromCodeCoverage]
[TestFixture]
public class BindableCollectionTests
{
    [Test]
    public void Constructor_Default_ExpectNoItems()
    {
        var o = new BindableCollection<string>();

        o.Count
            .Should()
            .Be(0);
    }

    [Test]
    public void Constructor_FromList_ExpectSameNumberOfItems()
    {
        var o = new BindableCollection<string>(new List<string>
            {
                "Hair",
                "Bear",
                "Bunch"
            });

        o.Count
            .Should()
            .Be(3);
    }

    [Test]
    public void Constructor_FromEnumerable_ExpectSameNumberOfItems()
    {
        var o = new BindableCollection<string>(new[]
        {
                "Hair",
                "Bear",
                "Bunch"
            });

        o.Count
            .Should()
            .Be(3);
    }

    [Test]
    public void AddRange_NullEnumerable_ExpectException()
    {
        var o = new BindableCollection<string>();

        Action action = () => o.AddRange(null);
        action
            .Should()
            .Throw<ArgumentNullException>();
    }

    [Test]
    public void AddRange_EmptyEnumerable_ExpectNoException()
    {
        var o = new BindableCollection<string>();

        Action action = () => o.AddRange(new string[0]);
        action
            .Should()
            .NotThrow<ArgumentNullException>();
    }

    [Test]
    public void AddRange_Enumerable_ExpectItemsToBeAdded()
    {
        var o = new BindableCollection<string>();

        o.AddRange(new[] { "Scooby", "Shaggy" });
        o.Count
            .Should()
            .Be(2);
    }

    [Test]
    public void AddRange_ShouldOnlyRaiseOneCollectionChangeEvent_EvenThoughtMoreThanOneItemAdded()
    {
        var o = new BindableCollection<string>();

        using (var ev = o.Monitor())
        {
            o.AddRange(new[] { "Scooby", "Shaggy" });
            ev
                .Should()
                .Raise("CollectionChanged")
                .Count()
                .Should()
                .Be(1);
        }
    }

    [Test]
    public void BeginUpdate_ShouldNotAllowCollectionChangeEvents()
    {
        var o = new BindableCollection<string>();

        using (var ev = o.Monitor())
        {
            o.BeginUpdate();
            o.AddRange(new[] { "Scooby", "Shaggy" });
            ev
                .Should()
                .NotRaise("CollectionChanged");
        }
    }

    [Test]
    public void EndUpdate_ShouldAllowCollectionChangeEvents()
    {
        var o = new BindableCollection<string>();

        using (var ev = o.Monitor())
        {
            o.BeginUpdate();
            o.AddRange(new[] { "Scooby", "Shaggy" });
            o.EndUpdate();
            ev
                .Should()
                .Raise("CollectionChanged")
                .Count()
                .Should()
                .Be(1);
        }
    }

    [Test]
    public void IsEmpty_ExpectTrueWhenEmpty()
    {
        var o = new BindableCollection<string>();
        o.IsEmpty
            .Should()
            .BeTrue();
    }

    [Test]
    public void IsEmpty_ExpectFalseWhenItemsExist()
    {
        var o = new BindableCollection<string>();

        o.AddRange(new[] { "Captain", "Caveman" });

        o.IsEmpty
            .Should()
            .BeFalse();
    }

    [Test]
    public void IsEmpty_PropertyChangedExpectedWhenItemsAdded()
    {
        var o = new BindableCollection<string>();
        var npc = (INotifyPropertyChanged)o;

        using (var ev = npc.Monitor())
        {

            o.AddRange(new[] { "Captain", "Caveman" });

            ev
                .Should()
                .Raise("PropertyChanged")
                .WithArgs<PropertyChangedEventArgs>(a => a.PropertyName == "IsEmpty");
        }
    }

    [Test]
    public void IsEmpty_PropertyChangedExpectedWhenAllItemsRemoved()
    {
        var o = new BindableCollection<string>(new[] { "Captain", "Caveman" });
        var npc = (INotifyPropertyChanged)o;

        using (var ev = npc.Monitor())
        {
            o.Clear();

            ev
                .Should()
                .Raise("PropertyChanged")
                .WithArgs<PropertyChangedEventArgs>(a => a.PropertyName == "IsEmpty");
        }
    }

    [Test]
    public void Sort_EnsureItemsSorted()
    {
        var o = new BindableCollection<string>(new[]
        {
                "Hair",
                "Bear",
                "Bunch"
            });

        o.Sort(string.CompareOrdinal);

        o
            .Should()
            .BeInAscendingOrder();
    }

    [Test]
    public void Sort_CollectionChangedShouldOccurOnce()
    {
        var o = new BindableCollection<string>(new[]
        {
                "Hair",
                "Bear",
                "Bunch"
            });

        using (var ev = o.Monitor())
        {
            o.Sort(string.CompareOrdinal);

            ev
                .Should()
                .Raise("CollectionChanged")
                .Count()
                .Should()
                .Be(1);
        }
    }
}
