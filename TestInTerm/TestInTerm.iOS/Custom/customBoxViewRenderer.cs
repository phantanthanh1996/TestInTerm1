using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using TestInTerm.iOS;
using TestInTerm;

[assembly: ExportRenderer(typeof(customBoxView), typeof(customBoxViewRenderer))]
namespace TestInTerm.iOS
{
    class customBoxViewRenderer: BoxRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            Layer.CornerRadius = 30f;
        }
    }
}