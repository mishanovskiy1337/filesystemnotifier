namespace FileSystemNotifier_Lib
{
    /// <summary>
    /// Base popup notifier settings that allow user to customize popup windows
    /// </summary>
    public class PopupNotifierSettings
    {
        public string ContentText { get; set; }  // popup content(file/directory name)
        public string TitleText { get; set; } // popup title text(which event has been fired)
        public int Size { get; set; } // popup content text size
    }
}
