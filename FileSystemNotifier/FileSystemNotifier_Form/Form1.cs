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

        private void StartScanning_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ScannerSettings scannerSettings = new ScannerSettings();
            scannerSettings.AllowScannChange = changedBox.Checked;
            scannerSettings.AllowScannCreate = createdBox.Checked;
            scannerSettings.AllowScannDelete = deletedBox.Checked;
            scannerSettings.AllowScannRenamed = renamedBox.Checked;
            PopupNotifierSettings popupSettings = new PopupNotifierSettings
            {
                AnimationDuration = 3,
                AnimationInterval = 3,
                Size = 15
            };
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
