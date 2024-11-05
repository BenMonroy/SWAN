using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace SWAN.Services
{
    public class SaveButtonClickedMessage : ValueChangedMessage<bool>
    {
        public SaveButtonClickedMessage() : base(true) { }
    }
}