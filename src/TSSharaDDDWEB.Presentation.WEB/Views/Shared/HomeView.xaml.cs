using System;
using System.Diagnostics;
using TSSharaDDDWEB.Presentation.WEB.ViewModels;
using TSSharaDDDWEB.Presentation.WEB.Views.CartesianChart.ConstantChanges;
using TSSharaDDDWEB.Presentation.WEB.Views.Report;
using TSSharaDDDWEB.Presentation.WEB.Views.Monitoring;

namespace TSSharaDDDWEB.Presentation.WEB.Views.Shared
{
    /// <summary>
    /// Interaction logic for HomeView.xaml
    /// </summary>
    public partial class HomeView : MetroWindow
    {

        public HomeView()
        {
            InitializeComponent();
        }


        private void RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void Metters_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            SampleVm SampleVm = new SampleVm()
            {
                Id = 0,
                Content = typeof(Graficos),
                Tags = "",
                Title = "",
            };
            SetUpViewOnBoxView(SampleVm);

        }

        private void Graphics_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SampleVm SampleVm = new SampleVm()
            {
                Id = 1,
                Content = typeof(Medidores),
                Tags = "",
                Title = "",
            };
            SetUpViewOnBoxView(SampleVm);

        }

        private void Report_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SampleVm SampleVm = new SampleVm()
            {
                Id = 2,
                Content = typeof(ReportView),
                Tags = "",
                Title = "",
            };
            SetUpViewOnBoxView(SampleVm);
        }

        private void Settings_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SampleVm SampleVm = new SampleVm()
            {
                Id = 3,
                Content = typeof(SettingsView),
                Tags = "",
                Title = "",
            };
            SetUpViewOnBoxView(SampleVm);
        }

        private void Test_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SampleVm SampleVm = new SampleVm()
            {
                Id = 4,
                Content = typeof(TestView),
                Tags = "",
                Title = "",
            };
            SetUpViewOnBoxView(SampleVm);
        }

        private void Monitoring_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SampleVm SampleVm = new SampleVm()
            {
                Id = 5,
                Content = typeof(MonitoringView),
                Tags = "",
                Title = "",
            };
            SetUpViewOnBoxView(SampleVm);
        }

        private void SetUpViewOnBoxView(SampleVm SampleVm)
        {
            var hvm = (HomeViewModel)DataContext;
            hvm.Content = (UserControl)Activator.CreateInstance(SampleVm.Content);
            hvm.IsMenuOpen = false;
        }

        private void TechnicalAssistance_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Process.Start("http://tsshara.com.br/assistencia-tecnica/");
        }
    }


}
