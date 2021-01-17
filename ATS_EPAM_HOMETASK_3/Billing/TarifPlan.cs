using System;


namespace ATS_EPAM_HOMETASK_3.Billing
{
    class TariffPlan
    {
        public double CostPerMinute { get; set; }
        public string NameTariff { get; set; }

        public TariffPlan(double costPerMinute, string nameTariff)
        {
            CostPerMinute = costPerMinute;
            NameTariff = nameTariff;
        }
    }
}
