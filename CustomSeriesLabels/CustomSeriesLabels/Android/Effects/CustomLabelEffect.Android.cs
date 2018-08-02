using Android.Graphics;
using Com.Telerik.Widget.Chart.Visualization.CartesianChart;
using Com.Telerik.Widget.Chart.Visualization.CartesianChart.Series.Categorical;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

// To distinguish between .NET or Xamarin.Forms Color
using Color = Android.Graphics.Color;

[assembly: ResolutionGroupName("MyCompany")]
[assembly: ExportEffect(typeof(CustomSeriesLabels.Android.Effects.CustomLabelEffect), "CustomLabelEffect")]
namespace CustomSeriesLabels.Android.Effects
{
    public class CustomLabelEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            if (Control is RadCartesianChartView nativeChart)
            {
                // Iterate over the native chart's series
                for (int i = 0; i < nativeChart.Series.Size(); i++)
                {
                    // Get a reference to the series you want
                    if (nativeChart.Series.Get(i) is SplineAreaSeries series)
                    {
                        // set the Label properties you want
                        series.LabelFillColor = Color.Red;
                        series.LabelTextColor = Color.White;
                        series.DataPointRenderer = new CustomPointRenderer();
                    }
                }
            }
        }

        protected override void OnDetached()
        {
        }
    }

    public class CustomPointRenderer : Java.Lang.Object, Com.Telerik.Widget.Chart.Visualization.CartesianChart.Series.Pointrenderers.IChartDataPointRenderer
    {
        public void RenderPoint(Canvas canvas, Com.Telerik.Widget.Chart.Engine.DataPoints.DataPoint p1)
        {
            canvas.DrawCircle((float)p1.CenterX, (float)p1.CenterY, 10, new Paint() { Color = Color.Red });

            p1.Arrange(new Com.Telerik.Android.Common.Math.RadRect((float)p1.CenterX + 4, (float)p1.CenterY + 4));
        }
    }
}