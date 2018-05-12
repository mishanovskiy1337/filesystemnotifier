using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;

namespace FileSystemNotifier_Lib
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class FileSystemScanner
    {
        private FileSystemWatcher _watcher;
        private Form _invokerForm;
        private PopupNotifierSettings _popupNotifierSettings;
        private List<string> _scannerResultsLocalStorage;
        private ScanningResultsLogger _scanningResultsLogger;

        public FileSystemScanner(Form invokerForm, string scannDirectoryPath, ScanningResultsLogger scanningResultsLogger)
        {
            _invokerForm = invokerForm;
            _watcher = new FileSystemWatcher
            {
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Security,
                IncludeSubdirectories = true,
                Path = scannDirectoryPath
            };

            _scannerResultsLocalStorage = new List<string>();
            _scanningResultsLogger = scanningResultsLogger;
        }

        public void ApplySettings(ScannerSettings settings, PopupNotifierSettings popupSettings)
        {
            if (settings.AllowScannCreate)
                _watcher.Created += OnChange;
            else
                _watcher.Created -= OnChange;

            if (settings.AllowScannDelete)
                _watcher.Deleted += OnChange;
            else
                _watcher.Deleted -= OnChange;

            if (settings.AllowScannChange)
                _watcher.Changed += OnChange;
            else
                _watcher.Changed -= OnChange;

            if (settings.AllowScannRenamed)
                _watcher.Renamed += OnRenamed;
            else
                _watcher.Renamed -= OnRenamed;

            _popupNotifierSettings = popupSettings;
        }

        private void OnChange(object sender, FileSystemEventArgs e)
        {
            string handledItemInfo = $"Item {e.FullPath} has been {e.ChangeType}";
            _invokerForm.Invoke((MethodInvoker)delegate 
            {
                PopupNotifierWrapper popupNotifierWrapper = new PopupNotifierWrapper(_popupNotifierSettings);
                _popupNotifierSettings.ContentText = handledItemInfo;
                _popupNotifierSettings.TitleText = e.ChangeType.ToString();
                popupNotifierWrapper.PopupMessage();
            });
            _scannerResultsLocalStorage.Add($"{e.FullPath}\t|\t{e.ChangeType}\t|\t{DateTime.Now}");
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            string handledItemInfo = $"Item {e.OldFullPath} renamed to {e.FullPath}";
            _invokerForm.Invoke((MethodInvoker)delegate 
            {
                PopupNotifierWrapper popupNotifierWrapper = new PopupNotifierWrapper(_popupNotifierSettings);
                _popupNotifierSettings.ContentText = handledItemInfo;
                _popupNotifierSettings.TitleText = e.ChangeType.ToString();
                popupNotifierWrapper.PopupMessage();
            });
            _scannerResultsLocalStorage.Add($"{e.OldFullPath}\t|\t{e.ChangeType}\t|\t{DateTime.Now}");
        }
        
        public void StartStopWorker(bool enableRaisingEvents)
        {
            _watcher.EnableRaisingEvents = enableRaisingEvents;
            if (!enableRaisingEvents)
            {
                _scannerResultsLocalStorage.ForEach(result => 
                {
                    _scanningResultsLogger.Write(result);
                });

                _scannerResultsLocalStorage.Clear();
            }              
        }
    }
}
