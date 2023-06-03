namespace PutridParrot.Maui.Converters;

public class BooleanToVisibilityConverter : BooleanToValueConverter<Visibility>
{
    public BooleanToVisibilityConverter() :
        base(Visibility.Visible, Visibility.Collapsed)
    {
    }

    public BooleanToVisibilityConverter(Visibility whenTrue, Visibility whenFalse) :
        base(whenTrue, whenFalse)
    {
    }
}