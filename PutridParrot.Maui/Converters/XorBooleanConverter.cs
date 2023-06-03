namespace PutridParrot.Maui.Converters;

public class XorBooleanConverter : XorToValueConverter<bool>
{
    public XorBooleanConverter() :
        this(true, false)
    {
        // should be overriden is subclass to be
        // specific to the supported type
    }

    public XorBooleanConverter(bool whenTrue, bool whenFalse)
    {
        WhenTrue = whenTrue;
        WhenFalse = whenFalse;
    }
}