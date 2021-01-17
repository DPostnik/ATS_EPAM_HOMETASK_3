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

        public Terminal() { }

        public Terminal(string number)
        {
            PhoneNumber = number;
        }
        protected virtual void OnOutgoingCall(object sender, CallEventArgs arg)
        {
            OutgoingCall?.Invoke(sender, arg);
        }
        protected virtual void OnIncomingCall(object sender, CallEventArgs arg)
        {
            IncomingCall?.Invoke(sender, arg);
        }
        protected virtual void OnAnswerCall(object sender, CallEventArgs arg)
        {
            Answer?.Invoke(sender, arg);
        }
        protected virtual void OnDropCall(object sender, CallEventArgs arg)
        {
            Drop?.Invoke(sender, arg);
        }

        public void Call(string to)
        {
            if (Port != null && Port.State == PortState.Free)
            {
                CallEventArgs = new CallEventArgs
                {
                    TargetNumber = to,
                    SourceNumber = PhoneNumber,
                    State = CallState.None
                };
                OnOutgoingCall(this, CallEventArgs);
            }
        }
        public void IncomingCallFromPort(CallEventArgs arg)
        {
            if (Port != null && arg != null)
            {
                OnIncomingCall(this, arg);
            }
        }
        public void AnswerCall()
        {
            if (Port != null && CallEventArgs.SourceNumber != string.Empty)
            {
                OnAnswerCall(this, CallEventArgs);
            }
        }
        public void DropCall()
        {
            if (Port != null && Port.State == PortState.Busy)
            {
                OnDropCall(this, CallEventArgs);
            }
        }
    }
}
