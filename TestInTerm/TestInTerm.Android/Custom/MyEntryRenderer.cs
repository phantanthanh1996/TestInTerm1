
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using TestInTerm.Droid;
using TestInTerm;

[assembly: ExportRenderer(typeof(MyEntry), typeof(MyEntryRenderer))]
namespace TestInTerm.Droid
{
    class MyEntryRenderer: EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if(Control != null)
            {
                Control.SetBackgroundColor(global::Android.Graphics.Color.LightBlue);
            }
        }
    }
}