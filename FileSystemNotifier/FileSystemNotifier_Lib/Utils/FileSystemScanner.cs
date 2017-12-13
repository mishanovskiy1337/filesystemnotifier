using System;
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
        private FileFixatorService _fileFixatorService;
        public FileSystemScanner(Form invokerForm, ScannerSettings settings, PopupNotifierSettings popupSettings)
        {
            _invokerForm = invokerForm;
            _popupNotifierSettings = popupSettings;
            _fileFixatorService = new FileFixatorService(Directory.GetCurrentDirectory() + @"\" + settings.Path.Replace(@"\", "").Replace(":", "") + ".txt"); // path to file
            _watcher = new FileSystemWatcher
            {
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Security,
                IncludeSubdirectories = true
            };
            ApplySettings(settings);
        }

        private void ApplySettings(ScannerSettings settings)
        {
            _watcher.Path = settings.Path;
            if (settings.AllowScannCreate)
                _watcher.Created += OnChange;
            if (settings.AllowScannDelete)
                _watcher.Deleted += OnChange;
            if (settings.AllowScannChange)
                _watcher.Changed += OnChange;
            if (settings.AllowScannRenamed)
                _watcher.Renamed += OnRenamed;
        }

        private void OnChange(object sender, FileSystemEventArgs e)
        {
            string handledItemInfo = string.Format("Item {0} has been {1}", e.FullPath, e.ChangeType);
            _invokerForm.Invoke((MethodInvoker)delegate 
            {
                PopupNotifierWrapper popupNotifierWrapper = new PopupNotifierWrapper(_popupNotifierSettings);
                _popupNotifierSettings.ContentText = handledItemInfo;
                _popupNotifierSettings.TitleText = e.ChangeType.ToString();
                popupNotifierWrapper.PopupMessage();
            });
            _fileFixatorService.Fixate(string.Format("{0}\t{1}\t{2}", e.FullPath, e.ChangeType, DateTime.Now));
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            string handledItemInfo = string.Format("Item {0} renamed to {1}", e.OldFullPath, e.FullPath);
            _invokerForm.Invoke((MethodInvoker)delegate 
            {
                PopupNotifierWrapper popupNotifierWrapper = new PopupNotifierWrapper(_popupNotifierSettings);
                _popupNotifierSettings.ContentText = handledItemInfo;
                _popupNotifierSettings.TitleText = e.ChangeType.ToString();
                popupNotifierWrapper.PopupMessage();
            });
            _fileFixatorService.Fixate(string.Format("{0}\t{1}\t{2}", e.OldFullPath, e.ChangeType, DateTime.Now));
        }
        
        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
        }
    }
}
