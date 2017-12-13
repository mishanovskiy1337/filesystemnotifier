using Tulpep.NotificationWindow;
namespace FileSystemNotifier_Lib
{
    public class PopupNotifierWrapper
    {
        private PopupNotifier _notifier;

        public PopupNotifierWrapper(PopupNotifierSettings notifierSettings)
        {
            _notifier = new PopupNotifier();
            ApplySettings(notifierSettings);
        }

        private void ApplySettings(PopupNotifierSettings settings)
        {

        }

        public void PopupMessage() => _notifier.Popup();
    }
}
