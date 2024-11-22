using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;

namespace SWAN.Services
{
    public class MetricsNavigatedMessage : ValueChangedMessage<bool>
    {
        public MetricsNavigatedMessage() : base(true) { }
    }
}