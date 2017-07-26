using Xamarin.Forms;
using TestInTerm;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using TestInTerm.Droid;

[assembly: ExportRenderer(typeof(customBoxView), typeof(customBoxViewRenderer))]
namespace TestInTerm.Droid
{
    class customBoxViewRenderer: BoxRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<BoxView> e)
        {
            base.OnElementChanged(e);

            GradientDrawable gd = new GradientDrawable();
            gd.SetColor(Android.Graphics.Color.White);
            gd.SetCornerRadius(30);
            gd.SetSize(100, 30);
            gd.SetStroke(1, Android.Graphics.Color.LightGray);
            this.SetBackgroundDrawable(gd);
        }
    }
}