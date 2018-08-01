using System;
using System.ComponentModel;


namespace NobreakTSShara.UI.Views

{
    /// <summary>
    /// Interaction logic for MeasurerView.xaml
    /// </summary>
    public partial class Medidores : UserControl, INotifyPropertyChanged
    {

        private bool _temperaturaVisibility = false;

        public Medidores()
        {
            InitializeComponent();

            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += TimeChanged;
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Start();

            Autonomia.LabelFormatter = value => new TranslateToCurrentLanguage().GetCurrentLanguageDictionary("LabelAutonomyChart");

        }


        private void TimeChanged(object sender, EventArgs e)
        {

            if (App.StatusInfo != null && App.StatusInfo.Conectado)
            {
                TensaoEntrada.PrimaryScale.Value = App.UPSData.TensaoEntrada;
                Frequencia.PrimaryScale.Value = App.UPSData.Frequencia;
                TensaoSaida.PrimaryScale.Value = App.UPSData.TensaoSaida;
                Autonomia.Value = App.UPSData.PorcentagemBateria;
                Temperatura.PrimaryScale.Value = App.UPSData.Temperatura;
                Carga.PrimaryScale.Value = App.UPSData.Carga;

                //TODO: Tratar melhor visibilidade destes medidores
                if (App.UPSData.Temperatura == 0)
                {
                    Temperatura.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {
                    Temperatura.Visibility = System.Windows.Visibility.Visible;
                }

                if (App.UPSData.Carga == 0)
                {
                    Carga.Visibility = System.Windows.Visibility.Hidden;
                }
                else
                {
                    Carga.Visibility = System.Windows.Visibility.Visible;
                }

            }
            else
            {
                TensaoEntrada.PrimaryScale.Value = 0;
                Frequencia.PrimaryScale.Value = 0;
                TensaoSaida.PrimaryScale.Value = 0;
                Autonomia.Value = 0;
                Temperatura.Visibility = System.Windows.Visibility.Hidden;
                Carga.Visibility = System.Windows.Visibility.Hidden;

            }
        }


        public bool TemperaturaVisibility
        {
            get { return _temperaturaVisibility; }

            set
            {
                _temperaturaVisibility = value;
                OnPropertyChanged("TemperaturaVisibility");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private static Random random;
        private static object syncObj = new object();
        private static void InitRandomNumber(int seed)
        {
            random = new Random(seed);
        }
        private static int GenerateRandomNumber(int min, int max)
        {
            lock (syncObj)
            {
                if (random == null)
                    random = new Random(); // Or exception...
                return random.Next(min, max);
            }
        }
    }
}
