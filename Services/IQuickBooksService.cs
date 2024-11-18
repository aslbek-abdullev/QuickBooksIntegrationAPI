namespace QuickBooksIntegrationAPI.Services;
public interface IQuickBooksService
{
    string QueryQuickBooks(string qbXmlRequest);
    public string GetChecks();
    public string GetBills();
    public string UpdateTask(string qbXmlRequest);
}
