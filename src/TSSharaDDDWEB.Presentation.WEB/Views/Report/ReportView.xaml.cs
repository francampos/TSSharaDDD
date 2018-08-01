using TSSharaDDDWEB.Presentation.WEB.ViewModels;

namespace TSSharaDDDWEB.Presentation.WEB.Views.Report
{
    /// <summary>
    /// Interaction logic for ReportView.xaml
    /// </summary>
    public partial class ReportView : UserControl
    {

        public ReportView()
        {

            DataContext = new ReportViewModel();
            InitializeComponent();

        }
    }
}
