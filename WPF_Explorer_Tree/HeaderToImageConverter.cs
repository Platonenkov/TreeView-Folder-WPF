using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media.Imaging;

namespace WPF_Explorer_Tree
{
    #region HeaderToImageConverter

    [ValueConversion(typeof(string), typeof(bool)), MarkupExtensionReturnType(typeof(HeaderToImageConverter))]
    public class HeaderToImageConverter : ValueConverter
    {
        /// <summary>Вид отображения корня</summary>
        public string RootType
        {
            private get => _RootType;
            set => _RootType = value;

        }
        private string _RootType = "Folder";
        /// <summary>Вид отображения вложенных уровней</summary>
        public string FolderType 
        { 
            private get => _FolderType;
            set => _FolderType = value;
        }

        private string _FolderType = "Folder";
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((string) value).Contains(@"\") ? RootType : FolderType;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }

    }

    [MarkupExtensionReturnType(typeof(ValueConverter))]
    public abstract class ValueConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider sp) => this;

        public abstract object Convert(object v, Type t, object p, CultureInfo c);

        public virtual object ConvertBack(object v, Type t, object p, CultureInfo c) => throw new NotSupportedException();
    }


    #endregion 


}