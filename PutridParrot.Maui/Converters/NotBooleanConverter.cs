namespace PutridParrot.Maui.Converters;

/// <summary>
/// If used on multiple values acts as a Not(And(values)), so values True, False will be And'd
/// to produce False and then Not'd to produce True
/// </summary>
public class NotBooleanConverter : IMarkupExtension,
    IValueConverter, IMultiValueConverter
{
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return !(value is bool && (bool)value);
    }

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return !(value is bool && (bool)value);
    }

    public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        if (values == null)
            return false;

        return !values.Where(_ => _ is bool).All(_ => (bool)_);
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