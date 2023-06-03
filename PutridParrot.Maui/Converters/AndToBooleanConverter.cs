using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PutridParrot.Maui.Converters;

/// <summary>
/// Takes multiple values and acts as an And
/// </summary>
public class AndToBooleanConverter : AndToValueConverter<bool>
{
    public AndToBooleanConverter() :
        this(true, false)
    {
        // should be overriden is subclass to be
        // specific to the supported type
    }

    public AndToBooleanConverter(bool whenTrue, bool whenFalse)
    {
        WhenTrue = whenTrue;
        WhenFalse = whenFalse;
    }
}
