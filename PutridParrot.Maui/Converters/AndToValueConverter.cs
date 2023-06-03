using System.Globalization;

namespace PutridParrot.Maui.Converters;

public abstract class AndToValueConverter<T> : IMarkupExtension,
    IMultiValueConverter
{
    public AndToValueConverter() :
        this(default(T), default(T))
    {
        // should be overriden is subclass to be
        // specific to the supported type
    }

    public AndToValueConverter(T whenTrue, T whenFalse)
    {
        WhenTrue = whenTrue;
        WhenFalse = whenFalse;
    }

    public T WhenTrue { get; set; }

    public T WhenFalse { get; set; }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values == null)
            return BindableProperty.UnsetValue;

        var booleans = values.Where(_ => _ is bool).ToArray();
        return booleans.All(_ => (bool)_) ? WhenTrue : WhenFalse;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}
