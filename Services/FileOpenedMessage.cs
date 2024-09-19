using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Services
{
    public class FileOpenedMessage : ValueChangedMessage<string>
    {
        public FileOpenedMessage(string filePath) : base(filePath) { }
    }

}
