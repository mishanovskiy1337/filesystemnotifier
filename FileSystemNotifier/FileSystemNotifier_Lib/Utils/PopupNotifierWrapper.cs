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
            _notifier.ContentText = settings.ContentText;
            _notifier.TitleText = settings.TitleText;
        }

        public void PopupMessage() => _notifier.Popup();
    }
}
