using Cirrious.CrossCore.WindowsStore.Converters;
using Cirrious.MvvmCross.Plugins.Color;
using Cirrious.MvvmCross.Plugins.Visibility;
using ValueConversion.Core.Converters;

namespace ValueConversion.UI.WindowsStore.NativeConverters
{
    public class NativeTimeAgoConverter : MvxNativeValueConverter<TimeAgoConverter>
    {
    }

    public class NativeVisibilityConverter : MvxNativeValueConverter<MvxVisibilityValueConverter>
    {
    }

    public class NativeInvertedVisibilityConverter : MvxNativeValueConverter<MvxInvertedVisibilityValueConverter>
    {
    }

    public class NativeContrastColorConverter : MvxNativeValueConverter<ContrastColorConverter>
    {
    }

    public class NativeColorConverter : MvxNativeValueConverter<MvxNativeColorValueConverter>
    {
    }

    public class NativeStringLengthConverter : MvxNativeValueConverter<StringLengthConverter>
    {
    }

    public class NativeStringReverseConverter : MvxNativeValueConverter<StringReverseConverter>
    {
    }

    public class NativeTwoWayConverter : MvxNativeValueConverter<TwoWayConverter>
    {
    }
}