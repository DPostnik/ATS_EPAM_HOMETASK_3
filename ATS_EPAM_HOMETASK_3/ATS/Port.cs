using System;
using ATS_EPAM_HOMETASK_3.ATS.enums;
using ATS_EPAM_HOMETASK_3.ATS.Interfaces;

namespace ATS_EPAM_HOMETASK_3.ATS
{
    class Port: IPort
    {
        private PortState state;
        public PortState State
        {
            get
            {
                return state;
            }
            set
            {
                state = value;
                StateChanged?.Invoke(this, value);
            }
        }
        public event EventHandler<PortState> StateChanged;
        public event EventHandler<CallEventArgs> OutgoingCall;
        public event EventHandler<CallEventArgs> IncomingCall;
        public event EventHandler<CallEventArgs> Answer;
        public event EventHandler<CallEventArgs> Drop;
    }
}
