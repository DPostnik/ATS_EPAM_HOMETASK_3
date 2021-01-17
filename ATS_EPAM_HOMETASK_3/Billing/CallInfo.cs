using System;
using ATS_EPAM_HOMETASK_3.ATS;


namespace ATS_EPAM_HOMETASK_3.Billing
{
    class BillInfo
    {
        public CallInfo CallInfo { get; }
        public double Cost { get; }
        public IClient SourceClient { get; set; }
        public IClient TargetClient { get; set; }

    }
}
