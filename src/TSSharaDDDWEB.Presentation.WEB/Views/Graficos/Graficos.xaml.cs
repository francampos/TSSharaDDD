using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;

namespace TSSharaDDDWEB.Presentation.WEB.Views.CartesianChart.ConstantChanges
{
    public partial class Graficos : UserControl, INotifyPropertyChanged
    {
        private double _axisMax;
        private double _axisMin;
        private double _trendTensaoSaida;
        private double _trendTensaoEntrada;
        private double _trendFrequencia;
        private bool _tensaoEntradaVisibility;
        private bool _tensaoSaidaVisibility;
        private bool _frequenciaVisibility;
        //private Nobreak _nobreak;

        public Graficos()
        {
            InitializeComponent();

            var mapper = Mappers.Xy<MeasureModel>()
                .X(model => model.DateTime.Ticks)   //use DateTime.Ticks as X
                .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);

            //the values property will store our values array
            TensaoSaida = new ChartValues<MeasureModel>();
            TensaoEntrada = new ChartValues<MeasureModel>();
            Frequencia = new ChartValues<MeasureModel>();

            //lets set how to display the X Labels
            DateTimeFormatter = value => new DateTime((long)value).ToString("HH:mm:ss");

            //AxisStep forces the distance between each separator in the X axis
            AxisStep = TimeSpan.FromSeconds(2).Ticks;
            //AxisUnit forces lets the axis know that we are plotting seconds
            //this is not always necessary, but it can prevent wrong labeling
            AxisUnit = TimeSpan.TicksPerSecond;

            SetAxisLimits(DateTime.Now);

            IsReading = true;
            Task.Factory.StartNew(Read);

            DataContext = this;
        }

        public ChartValues<MeasureModel> TensaoSaida { get; set; }

        public ChartValues<MeasureModel> TensaoEntrada { get; set; }

        public ChartValues<MeasureModel> Frequencia { get; set; }

        public Func<double, string> DateTimeFormatter { get; set; }

        public double AxisStep { get; set; }

        public double AxisUnit { get; set; }

        public double AxisMax
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                OnPropertyChanged("AxisMax");
            }
        }

        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                OnPropertyChanged("AxisMin");
            }
        }

        public bool IsReading { get; set; }

        private void Read()
        {
            
            while (IsReading)
            {
                //UPSData upsData = App.Nobreak.UPSInquiry();// _nobreak.UPSInquiry();

                 if (App.StatusInfo != null && App.StatusInfo.Conectado)
                {
                    ShowGraficos();
                    var now = DateTime.Now;

                    //_trendTensaoSaida = upsData.TensaoSaida; //_nobreak.TensaoSaida; 
                    //_trendTensaoEntrada = upsData.TensaoEntrada;// _nobreak.TensaoEntrada;

                    _trendTensaoSaida = App.UPSData.TensaoSaida;
                    _trendTensaoEntrada = App.UPSData.TensaoEntrada;
                    _trendFrequencia = App.UPSData.Frequencia;

                    //Debug.WriteLine($"Tensao Entrada: {_trendTensaoEntrada} Tensao Saida: {_trendTensaoSaida}");
                    
                    TensaoSaida.Add(new MeasureModel
                    {
                        DateTime = now,
                        Value = _trendTensaoSaida
                    });

                    TensaoEntrada.Add(new MeasureModel
                    {
                        DateTime = now,
                        Value = _trendTensaoEntrada
                    });

                    Frequencia.Add(new MeasureModel
                    {
                        DateTime = now,
                        Value = _trendFrequencia
                    });

                    SetAxisLimits(now);

                    //lets only use the last 150 values
                    if (TensaoSaida.Count > 150) TensaoSaida.RemoveAt(0);
                    if (TensaoEntrada.Count > 150) TensaoEntrada.RemoveAt(0);
                    if (Frequencia.Count > 150) Frequencia.RemoveAt(0);
                }
                else
                {
                    HideGraficos();
                }
                Thread.Sleep(2000);
            }
        }

        private void SetAxisLimits(DateTime now)
        {
            AxisMax = now.Ticks + TimeSpan.FromSeconds(5).Ticks; // lets force the axis to be 1 second ahead
            AxisMin = now.Ticks - TimeSpan.FromSeconds(10).Ticks; // and 8 seconds behind
        }

        private void InjectStopOnClick(object sender, RoutedEventArgs e)
        {
            IsReading = !IsReading;
            if (IsReading) Task.Factory.StartNew(Read);
        }

        private void HideGraficos()
        {
            TensaoEntradaVisibility = false;
            TensaoSaidaVisibility = false;
            FrequenciaVisibility = false;
            
        }

        private void ShowGraficos()
        {
            TensaoEntradaVisibility = true;
            TensaoSaidaVisibility = true;
            FrequenciaVisibility = true;
        }

        public bool TensaoEntradaVisibility
        {
            get { return _tensaoEntradaVisibility; }
            set
            {
                _tensaoEntradaVisibility = value;
                OnPropertyChanged("TensaoEntradaVisibility");
            }
        }

        public bool TensaoSaidaVisibility
        {
            get { return _tensaoSaidaVisibility; }
            set
            {
                _tensaoSaidaVisibility = value;
                OnPropertyChanged("TensaoSaidaVisibility");
            }
        }

        public bool FrequenciaVisibility
        {
            get { return _frequenciaVisibility; }
            set
            {
                _frequenciaVisibility = value;
                OnPropertyChanged("FrequenciaVisibility");
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
