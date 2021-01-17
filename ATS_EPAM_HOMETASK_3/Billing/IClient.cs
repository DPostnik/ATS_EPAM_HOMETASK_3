namespace ATS_EPAM_HOMETASK_3.Billing
{
    interface IClient
    {
        string Name { get; set; }
        TariffPlan TariffPlan { get; set; }
    }
}