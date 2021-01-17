using System;


namespace ATS_EPAM_HOMETASK_3.Billing
{
    class Client : IClient
    {
        public string Name { get; set; }
        public TariffPlan TariffPlan { get; set; }

        public double Balance = 0;

        public Client()
        {
            TariffPlan = new TariffPlan(0.125,"super");
        }

        public Client(TariffPlan tariffPlan)
        {
            if (tariffPlan == null) TariffPlan = new TariffPlan(0.125, "super");
            TariffPlan = tariffPlan;

        }
    }
}
