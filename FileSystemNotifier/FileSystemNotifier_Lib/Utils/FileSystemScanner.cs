using System.IO;
using System.Windows.Forms;

namespace FileSystemNotifier_Lib
{
    public class FileSystemScanner
    {
        private FileSystemWatcher _watcher;
        private Form _invokerForm;
        private PopupNotifierSettings _popupNotifierSettings;
        public FileSystemScanner(Form invokerForm, ScannerSettings settings, PopupNotifierSettings popupSettings)
        {
            _invokerForm = invokerForm;
            _popupNotifierSettings = popupSettings;
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
            _invokerForm.Invoke((MethodInvoker)delegate 
            {
                PopupNotifierWrapper popupNotifierWrapper = new PopupNotifierWrapper(_popupNotifierSettings);
                _popupNotifierSettings.ContentText = string.Format("Item {0} have been {1}", e.FullPath, e.ChangeType);
                _popupNotifierSettings.TitleText = e.ChangeType.ToString();
                popupNotifierWrapper.PopupMessage();
            });
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            _invokerForm.Invoke((MethodInvoker)delegate 
            {
                PopupNotifierWrapper popupNotifierWrapper = new PopupNotifierWrapper(_popupNotifierSettings);
                _popupNotifierSettings.ContentText = string.Format("Item {0} renamed to {1}", e.OldFullPath, e.FullPath);
                _popupNotifierSettings.TitleText = e.ChangeType.ToString();
                popupNotifierWrapper.PopupMessage();
            });
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
        }
    }
}
