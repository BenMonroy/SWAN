using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace SWAN.Services
{
    public class CloseSettingsButtonClickedMessage : ValueChangedMessage<bool>
    {
        public CloseSettingsButtonClickedMessage() : base(true) { }
    }
}