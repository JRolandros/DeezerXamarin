using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace OneDeezer.CustomControls
{
    public class CustomLabel:Label
    {
        public static readonly BindableProperty FontNameProperty = BindableProperty.Create<CustomLabel, string>(p => p.FontName, string.Empty); //propriété de binding
        public string FontName
        {
            get
            {
                return (string)GetValue(FontNameProperty);
            }
            set
            {
                SetValue(FontNameProperty, value);
            }
        }
    }
}
