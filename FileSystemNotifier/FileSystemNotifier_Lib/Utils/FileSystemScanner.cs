using System.IO;
using FileSystemNotifier_Lib.Models;
using System.Windows.Forms;

namespace FileSystemNotifier_Lib
{
    public class FileSystemScanner
    {
        private FileSystemWatcher _watcher;
        private Form _invokerForm;

        public FileSystemScanner(Form invokerForm, ScannerSettings settings)
        {
            _invokerForm = invokerForm;
            _watcher = new FileSystemWatcher
            {
                NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.Security,
                IncludeSubdirectories = true
            };
            ApplySettings(settings);
        }

        private void ApplySettings(ScannerSettings settings)
        {
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
            _invokerForm.Invoke((MethodInvoker)delegate { });
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            _invokerForm.Invoke((MethodInvoker)delegate { });
        }

        public void Start()
        {
            _watcher.EnableRaisingEvents = true;
        }
    }
}
