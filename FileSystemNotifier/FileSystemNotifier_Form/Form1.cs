using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSystemNotifier_Lib;

namespace FileSystemNotifier_Form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startScanning_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.ShowInTaskbar = false;
            // apply some settings
            ScannerSettings scannerSettings = new ScannerSettings();
            scannerSettings.AllowScannChange = true;
            PopupNotifierSettings popupSettings = new PopupNotifierSettings();
            // apply some settings
            Directory.GetLogicalDrives().ToList().ForEach(x => Task.Factory.StartNew(() => 
            {
                scannerSettings.Path = x;
                ScannerLauncher(scannerSettings, popupSettings);
            })); 
        }

        private void ScannerLauncher(ScannerSettings scannerSettings, PopupNotifierSettings popupNotifierSettings)
        {
            try
            {
                FileSystemScanner scanner = new FileSystemScanner(this, scannerSettings, popupNotifierSettings);
                scanner.Start();
            }
            catch (Exception)
            {

            }
        }
    }
}
