﻿using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWAN.Services
{
    class WidthUpdatedMessage : ValueChangedMessage<int>
    {
        public WidthUpdatedMessage(int value) : base(value) { }
    }
}
