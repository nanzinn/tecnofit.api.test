using Android.Graphics.Drawables;
using tecnofit.test.api.Droid.Renderer;
using tecnofit.test.api.UI.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace tecnofit.test.api.Droid.Renderer
{
    public class ExtendedEntryRenderer : EntryRenderer

    {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)

        {

            base.OnElementChanged(e);



            if (Control == null || e.NewElement == null) return;



            UpdateBorders();

        }



        protected override void OnElementPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)

        {

            base.OnElementPropertyChanged(sender, e);



            if (Control == null) return;



            if(e.PropertyName == ExtendedEntry.IsBorderErrorVisibleProperty.PropertyName)

                UpdateBorders();

        }



        void UpdateBorders()

        {

            GradientDrawable shape = new GradientDrawable();

            shape.SetShape(ShapeType.Rectangle);

            shape.SetCornerRadius(10);

			

            if (((ExtendedEntry)this.Element).IsBorderErrorVisible){

                shape.SetStroke(1, ((ExtendedEntry)this.Element).BorderErrorColor.ToAndroid());

            }


            this.Control.SetBackground(shape);

        }



    }
}