using Interop.QBFC16;
using System.Xml.Linq;
namespace QuickBooksIntegrationAPI.Services;
public class QuickBooksService : IQuickBooksService
{
    public string QueryQuickBooks(string qbXmlRequest)
    {
        try
        {
            QBSessionManager sessionManager = new QBSessionManager();
            sessionManager.OpenConnection("", "QuickBooks Integration");
            sessionManager.BeginSession("", ENOpenMode.omDontCare);

            IMsgSetRequest requestSet = sessionManager.CreateMsgSetRequest("US", 8, 0);
            requestSet.AppendXML(qbXmlRequest);

            IMsgSetResponse responseSet = sessionManager.DoRequests(requestSet);
            string response = responseSet.ToXMLString();

            sessionManager.EndSession();
            sessionManager.CloseConnection();
            return response;
        }
        catch (Exception ex)
        {
            return $"Error: {ex.Message}";
        }
    }
    public string GetBills()
    {
        string billRequest = File.ReadAllText("XmlRequests/BillQueryRq.xml");
        return QueryQuickBooks(billRequest);
    }

    public string GetChecks()
    {
        string checkRequest = File.ReadAllText("XmlRequests/CheckQueryRq.xml");
        return QueryQuickBooks(checkRequest);
    }
    public string UpdateTask(string qbXmlRequest)
    {
        return QueryQuickBooks(qbXmlRequest);
    }

}