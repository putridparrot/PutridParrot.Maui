namespace PutridParrot.Maui.Converters;

public class OrToBooleanConverter : OrToValueConverter<bool>
{
    public OrToBooleanConverter() :
        this(true, false)
    {
        // should be overriden is subclass to be
        // specific to the supported type
    }

    public OrToBooleanConverter(bool whenTrue, bool whenFalse)
    {
        WhenTrue = whenTrue;
        WhenFalse = whenFalse;
    }
}