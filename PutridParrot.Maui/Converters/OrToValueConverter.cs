namespace PutridParrot.Maui.Converters;

public abstract class OrToValueConverter<T> : IMarkupExtension,
    IMultiValueConverter
{
    public OrToValueConverter() :
        this(default(T), default(T))
    {
        // should be overriden is subclass to be
        // specific to the supported type
    }

    public OrToValueConverter(T whenTrue, T whenFalse)
    {
        WhenTrue = whenTrue;
        WhenFalse = whenFalse;
    }

    public T WhenTrue { get; set; }

    public T WhenFalse { get; set; }

    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (values == null)
            return BindableProperty.UnsetValue;

        var booleans = values.Where(_ => _ is bool).ToArray();
        return booleans.Any(_ => (bool)_) ? WhenTrue : WhenFalse;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
    {
        throw new NotImplementedException();
    }

    public object ProvideValue(IServiceProvider serviceProvider)
    {
        return this;
    }
}