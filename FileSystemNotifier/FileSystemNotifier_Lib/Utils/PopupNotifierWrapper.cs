using Tulpep.NotificationWindow;
using FileSystemNotifier_Lib.Models;
namespace FileSystemNotifier_Lib.Utils
{
    public class PopupNotifierWrapper
    {
        private PopupNotifier _notifier;

        public PopupNotifierWrapper(PopupNotifier notifier, PopupNotifierSettings notifierSettings)
        {
            _notifier = notifier;
            
            ApplySettings(notifierSettings);
        }

        private void ApplySettings(PopupNotifierSettings settings)
        {

        }

        public void PopupMessage() => _notifier.Popup();
    }
}
