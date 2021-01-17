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

        public virtual void RegisterEventHandlersForTerminal(ITerminal terminal)
        {
            terminal.OutgoingCall += (sender, arg) =>
            {
                State = PortState.Busy;
                OutgoingCall?.Invoke(this, arg);
                Console.WriteLine(arg.SourceNumber + " is calling " + arg.TargetNumber);
            };
            terminal.IncomingCall += (sender, arg) =>
            {
                State = PortState.Busy;
                terminal.CallEventArgs = arg;
                Console.WriteLine(arg.SourceNumber + " is calling " + arg.TargetNumber);
            };
            terminal.Answer += (sender, arg) =>
            {
                Console.WriteLine(arg.TargetNumber + " answered " + arg.SourceNumber);
                Answer?.Invoke(this, arg);
            };
            terminal.Drop += (sender, arg) =>
            {
                State = PortState.Free;
                Drop?.Invoke(this, arg);
            };
            this.IncomingCall += (sender, arg) =>
            {
                terminal.IncomingCallFromPort(arg);
            };
        }

        protected void OnCalling(object sender, CallEventArgs arg)
        {
            IncomingCall?.Invoke(sender, arg);
        }
        public void GetCall(CallEventArgs arg)
        {
            OnCalling(this, arg);
        }
    }
}
