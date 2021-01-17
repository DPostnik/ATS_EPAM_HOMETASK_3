
using System;

namespace ATS_EPAM_HOMETASK_3.ATS.Interfaces
{
    interface ITerminal
    {
        IPort Port { get; set; }
        string PhoneNumber { get; }
        CallEventArgs CallEventArgs { set; }

        event EventHandler<CallEventArgs> OutgoingCall;

        event EventHandler<CallEventArgs> IncomingCall;

        event EventHandler<CallEventArgs> Answer;

        event EventHandler<CallEventArgs> Drop;

        void Call(string to);
        void IncomingCallFromPort(CallEventArgs arg);
        void AnswerCall();
        void DropCall();
    }
}
