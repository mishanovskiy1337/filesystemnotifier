using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSystemNotifier_Lib;
using System.Collections.Generic;

namespace FileSystemNotifier_Form
{
    public enum ApplicationMode
    {
        Scanning = 1,
        Stopped = 2
    }

    public partial class Form1 : Form
    {
        private ApplicationMode applicationMode;
        private List<FileSystemScanner> scanners;
        private ScanningResultsLogger scanningResultsLogger;
        private ExceptionLogger exceptionLogger;
        public Form1()
        {
            InitializeComponent();
            scanningResultsLogger = new ScanningResultsLogger(@"c:\temp.txt");
            exceptionLogger = new ExceptionLogger();
            scanners = new List<FileSystemScanner>();
            applicationMode = ApplicationMode.Stopped;

            // get logical drives pathes to run scanner on them
            Directory.GetLogicalDrives().ToList().ForEach(x => 
            {
                scanners.Add(new FileSystemScanner(this, x, scanningResultsLogger));
            });
        }

        private void StartScanning_Click(object sender, EventArgs e)
        {
            // global popup settings (should be UI setted)
            PopupNotifierSettings popupSettings = new PopupNotifierSettings
            {
                Size = 15
            };

            // global scanner settings (UI setted)
            ScannerSettings scannerSettings = new ScannerSettings
            {
                AllowScannChange = changedBox.Checked,
                AllowScannCreate = createdBox.Checked,
                AllowScannDelete = deletedBox.Checked,
                AllowScannRenamed = renamedBox.Checked
            };

            // App running settings
            if (applicationMode == ApplicationMode.Stopped)
            {
                applicationMode = ApplicationMode.Scanning;
                startScanning.Text = "Stop";
                changedBox.Enabled = false;
                createdBox.Enabled = false;
                deletedBox.Enabled = false;
                renamedBox.Enabled = false;
            }
            else
            {
                applicationMode = ApplicationMode.Stopped;
                startScanning.Text = "Start";
                changedBox.Enabled = true;
                createdBox.Enabled = true;
                deletedBox.Enabled = true;
                renamedBox.Enabled = true;
            }

            ScannersLauncher(scannerSettings, popupSettings, applicationMode);
        }

        private void ScannersLauncher(ScannerSettings scannerSettings, PopupNotifierSettings popupNotifierSettings, ApplicationMode applicationMode)
        {
            try
            {
                scanners.ForEach(scanner => Task.Factory.StartNew(() =>
                {
                    scanner.ApplySettings(scannerSettings, popupNotifierSettings);
                    scanner.StartStopWorker(applicationMode == ApplicationMode.Scanning);
                }));
            }
            catch (Exception)
            {

            }
        }
    }
}
