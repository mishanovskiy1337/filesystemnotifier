using FileSystemNotifier_Lib.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Security.Permissions;
using System.Windows.Forms;

namespace FileSystemNotifier_Lib
{
    /// <summary>
    /// FileSystemWatcher library wrapper that allows to launch which type of event we should handle,
    /// notification filters and start the wathcher.
    /// </summary>
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    public class FileSystemScanner
    {
        private FileSystemWatcher _watcher; // file system watcher instance
        private Form _invokerForm; // UI form that invokes the Watcher
        private PopupNotifierSettings _popupNotifierSettings; // base settings for the PopUp, that allows to notify user about file changing
        private List<string> _scannerResultsLocalStorage; // list of system changes
        private BindingList<ScanResultViewModel> _scannerResults; // list of global system changes
        private ScanningResultsLogger _scanningResultsLogger; // File system scanner internal logger, that allows to collect all changes in text file

        public FileSystemScanner(Form invokerForm, string scannDirectoryPath, ScanningResultsLogger scanningResultsLogger, BindingList<ScanResultViewModel> scannerResults)
        {
            _invokerForm = invokerForm;
            _watcher = new FileSystemWatcher
            {
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Security,
                IncludeSubdirectories = true,
                Path = scannDirectoryPath
            };

            _scannerResults = scannerResults;
            _scannerResultsLocalStorage = new List<string>();
            _scanningResultsLogger = scanningResultsLogger;
        }

        /// <summary>
        /// Launch settings for the watcher
        /// </summary>
        /// <param name="settings">scanner settings(from UI)</param>
        /// <param name="popupSettings">popup settings(from UI)</param>
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

        /// <summary>
        /// File/directory created/modified/deleted event handler
        /// Allow to notify user with a PopUp and write data to log
        /// </summary>
        private void OnChange(object sender, FileSystemEventArgs e)
        {
            string handledItemInfo = $"Item {e.FullPath} has been {e.ChangeType}";
            _invokerForm.Invoke((MethodInvoker)delegate 
            {
                PopupNotifierWrapper popupNotifierWrapper = new PopupNotifierWrapper(_popupNotifierSettings);
                _popupNotifierSettings.ContentText = handledItemInfo;
                _popupNotifierSettings.TitleText = e.ChangeType.ToString();
                popupNotifierWrapper.PopupMessage();
                _scannerResults.Add(new ScanResultViewModel { Path = e.FullPath, ChangeType = e.ChangeType.ToString(), Date = DateTime.Now.ToShortDateString() });
            });
            _scannerResultsLocalStorage.Add($"{e.FullPath}\t|\t{e.ChangeType}\t|\t{DateTime.Now}");
        }

        /// <summary>
        /// File/directory renamed event handler
        /// </summary>
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            string handledItemInfo = $"Item {e.OldFullPath} renamed to {e.FullPath}";
            _invokerForm.Invoke((MethodInvoker)delegate 
            {
                PopupNotifierWrapper popupNotifierWrapper = new PopupNotifierWrapper(_popupNotifierSettings);
                _popupNotifierSettings.ContentText = handledItemInfo;
                _popupNotifierSettings.TitleText = e.ChangeType.ToString();
                popupNotifierWrapper.PopupMessage();
                _scannerResults.Add(new ScanResultViewModel { Path = e.OldFullPath, ChangeType = e.ChangeType.ToString(), Date = DateTime.Now.ToShortDateString() });
            });
            _scannerResultsLocalStorage.Add($"{e.OldFullPath}\t|\t{e.ChangeType}\t|\t{DateTime.Now}");
        }
        
        /// <summary>
        /// Start/stop button has been clicked on UI by user
        /// Allows to handle when we should start/stop file system watcher
        /// </summary>
        /// <param name="enableRaisingEvents">start or stop watcher</param>
        public void StartStopWorker(bool enableRaisingEvents)
        {
            try
            {
                _watcher.EnableRaisingEvents = enableRaisingEvents;

                // if user clicked Stop button - write all the collected data in Log file.
                if (!enableRaisingEvents)
                {
                    _scannerResultsLocalStorage.ForEach(result =>
                    {
                        _scanningResultsLogger.Write(result);
                    });

                    _scannerResultsLocalStorage.Clear();
                }
            }
            catch (Exception)
            {
                // nothing to do..
            }
        }
    }
}
