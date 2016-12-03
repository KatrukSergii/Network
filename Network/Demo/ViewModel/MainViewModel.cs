using System;
using System.Threading.Tasks;
using System.Windows.Threading;
using Common;
using Common.Interface;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Demo.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    /// <owner>Sergii Katruk</owner>
    public class MainViewModel : ViewModelBase, ILogger<string>
    {
        private string textToSend;
        private string propgressText;
        
        public RelayCommand SendCommand => new RelayCommand(this.Send);

        public string TextToSend
        {
            get
            {
                return this.textToSend;
            }
            set
            {
                this.textToSend = value;
                this.RaisePropertyChanged();
            }
        }

        public string PropgressText
        {
            get
            {
                return this.propgressText;
            }
            set
            {
                this.propgressText = value;
                this.RaisePropertyChanged();
            }
        }

        private void Send()
        {
            Client.UDP.Client udpClient = new Client.UDP.Client(this);
            udpClient.Send(new Request(this.textToSend));
        }

        public void Log(string logItem)
        {
            this.PropgressText += logItem + Environment.NewLine;
        }

        public MainViewModel()
        {
            this.TextToSend = "Test";
            Server.UDP.Server server = new Server.UDP.Server(this);
            server.OnRequestRecieved += this.OnRequestRecieved;
            Task.Run(() => server.Start());
        }

        private void OnRequestRecieved(object sender, Request e)
        {
            Dispatcher.CurrentDispatcher.Invoke(() =>
            {
                this.PropgressText += $"Received message: {e.Message}{Environment.NewLine}";
            });
        }
    }
}