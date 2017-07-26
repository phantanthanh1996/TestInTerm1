using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using TestInTerm.iOS;
using TestInTerm;

[assembly: ExportRenderer(typeof(customButton), typeof(customButtonRenderer))]
namespace TestInTerm.iOS
{
    public class customButtonRenderer : ButtonRenderer
    {
        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == VisualElement.HeightProperty.PropertyName ||
               e.PropertyName == VisualElement.WidthProperty.PropertyName)
            {
                CreateCircle();
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Button> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;
            CreateCircle();
        }

        private void CreateCircle()
        {
            double min = Math.Min(Element.Width, Element.Height);
            Control.Layer.CornerRadius = (float)(min / 2.0);
            Control.Layer.MasksToBounds = false;
            Control.Layer.BorderColor = Color.White.ToCGColor();
            Control.Layer.BorderWidth = 3;
            Control.ClipsToBounds = true;

        }
    }
}