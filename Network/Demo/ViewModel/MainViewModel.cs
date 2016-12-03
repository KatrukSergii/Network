using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace Demo.ViewModel
{
    /// <summary>
    /// 
    /// </summary>
    /// <owner>Sergii Katruk</owner>
    public class MainViewModel : ViewModelBase
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
            this.PropgressText += this.TextToSend;
        }
    }
}