using System;
using ATS_EPAM_HOMETASK_3.ATS.enums;

namespace ATS_EPAM_HOMETASK_3.ATS.Interfaces
{
    interface IPort
    {
        PortState State { get; set; }

        event EventHandler<PortState> StateChanged;

        event EventHandler<CallEventArgs> OutgoingCall;

        event EventHandler<CallEventArgs> IncomingCall;

        event EventHandler<CallEventArgs> Answer;

        event EventHandler<CallEventArgs> Drop;
    }
}
