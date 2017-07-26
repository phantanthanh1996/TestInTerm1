

using Android.Graphics.Drawables;
using TestInTerm;
using TestInTerm.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(customButton), typeof(customButtonRenderer))]
namespace TestInTerm.Droid
{
    public class customButtonRenderer : ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            GradientDrawable gd = new GradientDrawable();
            gd.SetColor(Android.Graphics.Color.Aqua);
            gd.SetCornerRadius(20);
            gd.SetSize(100, 30);
            gd.SetStroke(1, Android.Graphics.Color.LightGray);
            Control.SetBackgroundDrawable(gd);
        }
    }
}