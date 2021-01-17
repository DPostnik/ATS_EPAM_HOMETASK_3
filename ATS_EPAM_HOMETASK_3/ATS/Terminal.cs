using System;
using ATS_EPAM_HOMETASK_3.ATS.enums;
using ATS_EPAM_HOMETASK_3.ATS.Interfaces;

namespace ATS_EPAM_HOMETASK_3.ATS
{
    class Terminal: ITerminal
    {
        

        public IPort Port { get; set; }
        public string PhoneNumber { get; set; }
        public CallEventArgs CallEventArgs { get; set; } = new CallEventArgs();

        public event EventHandler<CallEventArgs> OutgoingCall;
        public event EventHandler<CallEventArgs> IncomingCall;
        public event EventHandler<CallEventArgs> Answer;
        public event EventHandler<CallEventArgs> Drop;

        public Terminal()
        {
            
        }
    }
}
