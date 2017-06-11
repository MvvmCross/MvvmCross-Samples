using System;
using MvvmCross.Core.ViewModels;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace StarWarsSample.ViewModels
{
    public class StatusViewModel : BaseViewModel
    {
        public StatusViewModel()
        {
        }

        // MvvmCross Lifecycle
        public override void Start()
        {
            base.Start();

            PlotModel = new PlotModel
            {
                Title = "Death Star Status"
            };
            PlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom, Title = "Time" });
            PlotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0, Title = "Targets" });

            var series1 = new LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.Red,
                Color = OxyColors.Red
            };

            series1.Points.Add(new DataPoint(0.0, 6.0));
            series1.Points.Add(new DataPoint(1.4, 2.1));
            series1.Points.Add(new DataPoint(2.0, 4.2));
            series1.Points.Add(new DataPoint(3.3, 2.3));
            series1.Points.Add(new DataPoint(4.7, 7.4));
            series1.Points.Add(new DataPoint(6.0, 6.2));
            series1.Points.Add(new DataPoint(8.9, 8.9));

            PlotModel.Series.Add(series1);
        }

        // MVVM Properties
        private PlotModel _plotModel;
        public PlotModel PlotModel
        {
            get
            {
                return _plotModel;
            }
            set
            {
                _plotModel = value;
                RaisePropertyChanged(() => PlotModel);
            }
        }

        // MVVM Commands

        // Private methods
    }
}
