using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using mshtml;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.webBrowser.Navigate(new Uri("http://google.com.ua"));
            //this.webBrowser.Navigate(new Uri("http://t.t"));
        }
        
        private void WebBrowser_Navigating(object sender, NavigatingCancelEventArgs e)
        {
            dynamic activeX = this.webBrowser.GetType().InvokeMember("ActiveXInstance",
                    BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, this.webBrowser, new object[] { });
            activeX.Silent = true;
            ((SHDocVw.WebBrowser)activeX).NavigateError += MainWindow_NavigateError;
        }

        private void WebBrowser_Navigated(object sender, NavigationEventArgs e)
        {
            dynamic activeX = this.webBrowser.GetType().InvokeMember("ActiveXInstance",
                    BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                    null, this.webBrowser, new object[] { });
            activeX.Silent = true;
            ((SHDocVw.WebBrowser)activeX).NavigateError += MainWindow_NavigateError;
            HTMLDocument document = (HTMLDocument)webBrowser.Document;
            IHTMLElement topLinks = document.getElementById("g_ctl00_ctl01_pnlHeader");
            var headElements = document.getElementsByTagName("head");
        }

        private void MainWindow_NavigateError(object pdisp, ref object url, ref object frame, ref object statuscode, ref bool cancel)
        {
            
        }
    }
}
