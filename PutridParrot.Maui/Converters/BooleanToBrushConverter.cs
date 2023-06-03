namespace PutridParrot.Maui.Converters;

public class BooleanToBrushConverter : BooleanToValueConverter<Brush>
{
    public BooleanToBrushConverter() :
        base(Brush.Green, Brush.Red)
    {
    }

    public BooleanToBrushConverter(Brush whenTrue, Brush whenFalse) :
        base(whenTrue, whenFalse)
    {
    }
}