namespace FileSystemNotifier_Lib
{
    /// <summary>
    /// Base scanner settigs that allow to launch which events we should catch while scanning the operation system
    /// </summary>
    public class ScannerSettings
    {
        public bool AllowScannCreate { get; set; } // scan file/directory Created events
        public bool AllowScannDelete { get; set; } // scan file/directory Deleted events
        public bool AllowScannChange { get; set; } // scan file/directory Modified events(changed size, attributes..)
        public bool AllowScannRenamed { get; set; } // scan file/directory Renamed events
    }
}
