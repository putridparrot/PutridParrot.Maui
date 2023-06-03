namespace PutridParrot.Maui.Converters;

public class BooleanToStringConverter : BooleanToValueConverter<string>
{
    public BooleanToStringConverter() :
        base("True", "False")
    {
    }

    public BooleanToStringConverter(string whenTrue, string whenFalse) :
        base(whenTrue, whenFalse)
    {
    }
}