using Tulpep.NotificationWindow;

namespace FileSystemNotifier_Lib
{
    /// <summary>
    /// Wrapper over the PopupNotifier that allows user to see the notification about changes in file system
    /// </summary>
    public class PopupNotifierWrapper
    {
        private PopupNotifier _notifier; // notifier instance

        public PopupNotifierWrapper(PopupNotifierSettings notifierSettings)
        {
            _notifier = new PopupNotifier();
            ApplySettings(notifierSettings);
        }

        private void ApplySettings(PopupNotifierSettings settings)
        {
            _notifier.ContentText = settings.ContentText;
            _notifier.TitleText = settings.TitleText;
        }

        public void PopupMessage() => _notifier.Popup();
    }
}
