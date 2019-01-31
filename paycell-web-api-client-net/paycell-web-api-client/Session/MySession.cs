using System.Data;
using System.Web;

namespace paycell_web_api_client.Session
{

    public class MySession
    {
        // private constructor
        private MySession()
        {
            requestFilter = "SOAP";
        }

        // Gets the current session.
        public static MySession Current
        {
            get
            {
                MySession session = (MySession)HttpContext.Current.Session["_paycell_web_api_"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["_paycell_web_api_"] = session;
                }
                return session;
            }
        }

        public string requestFilter { get; set; }
        public string msisdn { get; set; }
        public string cardId { get; set; }
        public string cardToken { get; set; }
        public string threeDSessionId { get; set; }
        public DataTable dataTable { get; set; }
    }
}