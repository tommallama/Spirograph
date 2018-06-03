using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Spirograph
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private bool initComplete = false;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            InitSliders();
            UpdateSliderVals();
            initComplete = true;
        }

        private void InitSliders()
        {
            SliderR1.Value = SliderR1.Maximum;
            SliderR2.Value = 35;
            SliderR3.Value = 75;
            SliderPPR.Value = SliderPPR.Minimum;
            SliderRot.Value = 5;

            double R = SliderR1.Value / 600;// Fix this but the spiromath uses a unit of 1 max...
            double r = R * SliderR2.Value / 100;  // r is a percentage of R
            double rho = r * SliderR3.Value / 100;    // rho is a percentage of r
            SpirographDisp.AddSpiroToCanvas(R, r, rho, SliderPPR.Value, SliderRot.Value);
        }

        private void UpdateSliderVals()
        {
            // This is very lazy... use proper binding here instead of this to update.
            SliderVal_R1 = SliderR1.Value.ToString();
            SliderVal_R2 = SliderR2.Value.ToString();
            SliderVal_R3 = SliderR3.Value.ToString();
            SliderVal_PPR = SliderPPR.Value.ToString();
            SliderVal_Rot = SliderRot.Value.ToString();
        }

        // Move these out of this area... quick and extra dirty
        private string sliderVal_R1;
        private string sliderVal_R2;
        private string sliderVal_R3;
        private string sliderVal_PPR;
        private string sliderVal_Rot;

        public string SliderVal_R1
        {
            get => sliderVal_R1;
            set { sliderVal_R1 = value; NotifyPropertyChanged(); }
        }
        public string SliderVal_R2
        {
            get => sliderVal_R2;
            set { sliderVal_R2 = value; NotifyPropertyChanged(); }
        }
        public string SliderVal_R3
        {
            get => sliderVal_R3;
            set { sliderVal_R3 = value; NotifyPropertyChanged(); }
        }
        public string SliderVal_PPR
        {
            get => sliderVal_PPR;
            set { sliderVal_PPR = value; NotifyPropertyChanged(); }
        }
        public string SliderVal_Rot
        {
            get => sliderVal_Rot;
            set { sliderVal_Rot = value; NotifyPropertyChanged(); }
        }







        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.  
        // The CallerMemberName attribute that is applied to the optional propertyName  
        // parameter causes the property name of the caller to be substituted as an argument.  
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (initComplete)
            {
                UpdateSliderVals();
                // Need to convert the percentages into real numbers
                double R = SliderR1.Value / 600;// Fix this but the spiromath uses a unit of 1 max...
                double r = R * SliderR2.Value / 100;  // r is a percentage of R
                double rho = r * SliderR3.Value / 100;    // rho is a percentage of r
                SpirographDisp.AddSpiroToCanvas(R, r, rho, SliderPPR.Value, SliderRot.Value);
            }
        }
    }
}
