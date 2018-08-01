using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;

namespace TSSharaDDDWEB.Presentation.WEB.Views.Monitoring
{
    /// <summary>
    /// Interaction logic for MonitoringView.xaml
    /// </summary>
    public partial class MonitoringView : UserControl
    {
        private MonitoringViewModel monitoringViewModel;
        public MonitoringView()
        {
            InitializeComponent();
            monitoringViewModel = new MonitoringViewModel();
            DataContext = monitoringViewModel;
            SetupTextFieldsEnabling(false);
        }

        private void SetupTextFieldsEnabling(bool value)
        {
            this.textBoxEmail.IsEnabled = value;
            this.textBoxPassword.IsEnabled = value;
            this.textBoxNobreakNickname.IsEnabled = value;
            this.textBoxSerial.IsEnabled = value;
            this.labelEmail.IsEnabled = value;
            this.labelPassword.IsEnabled = value;
            this.labelNobreakNickname.IsEnabled = value;
            this.labelSerial.IsEnabled = value;
        }

        private void SaveChanges(object sender, System.Windows.RoutedEventArgs e)
        {

            var client = new RestClient("http://localhost:62140/Token");
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddParameter("grant_type", "password");
            request.AddParameter("username", textBoxEmail.Text);
            request.AddParameter("password", textBoxPassword.Password);
            IRestResponse response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                Dictionary<string, string> tokenDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);
                string accessToken = tokenDictionary["access_token"];
                var clientAddNobreakToAccount = new RestClient("http://localhost:62140/api/");
                var requestAddNobreakToAccount = new RestRequest("Nobreaks/PostAddNobreakToAccount", Method.POST);


                requestAddNobreakToAccount.AddHeader("content-type", "application/x-www-form-urlencoded");
                requestAddNobreakToAccount.AddHeader("Authorization", "Bearer " + accessToken);
                requestAddNobreakToAccount.AddHeader("token_type", "bearer");

                INobreakServiceChannel ch = App.Channel;

                //var informacoesNobreak = ch.InformationInquiry();

                var nobreak = new Nobreak()
                {
                    Serial = textBoxSerial.Text,
                    Label = textBoxNobreakNickname.Text,
                    //nobreak.UPSModel = informacoesNobreak.Modelo;
                    //nobreak.Version = informacoesNobreak.Versao;
                    CompanyName = "TS Shara"
                };
                var nbJson = JsonConvert.SerializeObject(nobreak);

                requestAddNobreakToAccount.AddParameter("text/json", nbJson, ParameterType.RequestBody);
                requestAddNobreakToAccount.RequestFormat = RestSharp.DataFormat.Json;

                response = clientAddNobreakToAccount.Execute(requestAddNobreakToAccount);

                var settingsWorkQuery = new SettingsWorkQuery();
                var currentSettings = settingsWorkQuery.FindFirstData();
                currentSettings.UserEmail = textBoxEmail.Text;
                currentSettings.UserToken = accessToken;

                settingsWorkQuery.UpdateData(currentSettings);

                //MessageBox.Show(response.Content);
                NotifierHelper.ShowInformation(response.Content, 1);
            }
            else
            {
                Dictionary<string, string> responseError = JsonConvert.DeserializeObject<Dictionary<string, string>>(response.Content);

                NotifierHelper.ShowInformation(responseError["error_description"], 2);
            }
        }

        private void Checkbox_checked(object sender, RoutedEventArgs e)
        {
            SetupTextFieldsEnabling(true);
        }

        private void Checkbox_unchecked(object sender, RoutedEventArgs e)
        {
            SetupTextFieldsEnabling(false);
        }
    }
}
