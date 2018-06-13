using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using FileSystemNotifier_Lib;
using System.Collections.Generic;
using FileSystemNotifier_Lib.Models;
using System.ComponentModel;

namespace FileSystemNotifier_Form
{
    public partial class Form1 : Form
    {
        internal enum ApplicationMode
        {
            Scanning = 1,
            Stopped = 2
        }

        private ApplicationMode applicationMode;
        private List<FileSystemScanner> scanners;
        private ScanningResultsLogger scanningResultsLogger;
        private ExceptionLogger exceptionLogger;
        private string _loggerFile;
        private BindingList<ScanResultViewModel> _scannerResults; // list of global system changes

        public Form1()
        {
            InitializeComponent();
            _scannerResults = new BindingList<ScanResultViewModel>();
            startScanning.Enabled = false;
            scanningResultsLogger = new ScanningResultsLogger(_loggerFile);
            exceptionLogger = new ExceptionLogger();
            scanners = new List<FileSystemScanner>();
            applicationMode = ApplicationMode.Stopped;
            scanResultsGridView.AutoResizeColumns(
            DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader);
            scanResultsGridView.DataSource = _scannerResults;
            
            // get logical drives pathes to run scanner on them
            Directory.GetLogicalDrives().ToList().ForEach(x => 
            {
                scanners.Add(new FileSystemScanner(this, x, scanningResultsLogger, _scannerResults));
            });
        }

        private void StartScanning_Click(object sender, EventArgs e)
        {
            scanResultsGridView.Refresh();
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
                // write exception into the log.
            }
        }

        private void selectFolderBtn_Click(object sender, EventArgs e)
        {
            var result = folderBrowserDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                var directoryPath = folderBrowserDialog1.SelectedPath;
                _loggerFile = directoryPath + "results.txt";
                File.Create(_loggerFile).Dispose();
                scanningResultsLogger.SetLogFile(_loggerFile);
            }

            startScanning.Enabled = true;
            selectFolderBtn.Enabled = false;
        }
    }
}
