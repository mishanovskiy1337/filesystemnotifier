namespace FileSystemNotifier_Lib
{
    public class ScannerSettings
    {
        public string Path { get; set; }
        public bool AllowScannCreate { get; set; }
        public bool AllowScannDelete { get; set; }
        public bool AllowScannChange { get; set; }
        public bool AllowScannRenamed { get; set; }
    }
}
