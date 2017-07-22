using System;
using Android.Graphics;
using TestInTerm;
using TestInTerm.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(UnderlineLabel), typeof(UnderlineLabelRenderer))]
namespace TestInTerm.Droid
{
    public class UnderlineLabelRenderer : LabelRenderer

    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (this.Control != null)
            {
                Control.PaintFlags = PaintFlags.UnderlineText;
                Control.SetTextColor(Android.Graphics.Color.White);
            }

        }
    }
}