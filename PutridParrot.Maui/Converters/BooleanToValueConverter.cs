using System.Globalization;

namespace PutridParrot.Maui.Converters;

/// <summary>
/// Abstract Base class for specializations of the BooleanToXXXConverter
/// classes.
///
/// If the object passed into Convert or ConvertBack is not of the
/// expected type a DependencyProperty.UnsetValue is returned to
/// allow the binding's fallback to work 
/// </summary>
/// <typeparam name="T"></typeparam>
public abstract class BooleanToValueConverter<T> : IMarkupExtension,
    IValueConverter
{
    protected BooleanToValueConverter() :
        this(default(T), default(T))
    {
        // should be overriden is subclass to be
        // specific to the supported type
    }

    protected BooleanToValueConverter(T whenTrue, T whenFalse) :
        this(whenTrue, whenFalse, BindableProperty.UnsetValue)
    {
    }

    protected BooleanToValueConverter(T whenTrue, T whenFalse, object whenUnset)
    {
        WhenTrue = whenTrue;
        WhenFalse = whenFalse;
        WhenUnset = whenUnset;
    }

    public T WhenTrue { get; set; }

    public T WhenFalse { get; set; }

    public object WhenUnset { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }

    private T Convert(bool b)
    {
        return b ? WhenTrue : WhenFalse;
    }

    private bool ConvertBack(T value)
    {
        return value.Equals(WhenTrue);
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is bool b ? Convert(b) : WhenUnset;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        return value is T v ? ConvertBack(v) : WhenUnset;
    }
}
