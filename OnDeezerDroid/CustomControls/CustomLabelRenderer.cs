using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using OneDeezer.CustomControls;
using System.ComponentModel;
using OnDeezerDroid.CustomControls;
using Android.Graphics;
using Android.Util;

[assembly: ExportRenderer(typeof(CustomLabel),typeof(CustomLabelRenderer))]
namespace OnDeezerDroid.CustomControls
{
    class CustomLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if(e.NewElement != null)
            {
                var newElement = (CustomLabel)e.NewElement;
                updateUi((newElement));
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CustomLabel.FontNameProperty.PropertyName)
            {
                updateUi((CustomLabel)Element);
            }
        }

        private void updateUi(CustomLabel element)
        {
            TextView view = Control;
            var typeFace = GetTypeface(element.FontName, element.FontAttributes, Context);
            view.SetTypeface(typeFace, (TypefaceStyle)element.FontAttributes);
        }

        private static Typeface GetTypeface(string fontName, FontAttributes font,Context ctx)
        {
            var fontPath = System.IO.Path.Combine("Fonts", fontName + ".ttf");
            try
            {
                return Typeface.CreateFromAsset(ctx.Assets, fontPath);
            }
            catch (Exception)
            {
                Log.Error("OneDeezer", String.Format("Font {0} not found", fontName));
                return Typeface.Default;
            }
        }
    }
}