using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StoreBranchApp
{
    public class MySession
    {
        public int LoginId { get; set; }
        public List<TransactionItem> transactionLists {get; set;}
        // private constructor
        private MySession()
        {
            LoginId = 0;
            transactionLists = new List<TransactionItem>();
        }

        // Gets the current session.
        public static MySession Current
        {
            get
            {
                MySession session =
                  (MySession)HttpContext.Current.Session["__MySession__"];
                if (session == null)
                {
                    session = new MySession();
                    HttpContext.Current.Session["__MySession__"] = session;
                }
                return session;
            }
        }

        // **** add your session properties here, e.g like this:
        //public string Property1 { get; set; }
        //public DateTime MyDate { get; set; }
        
    }
}