using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoStuff
{
    public static class Credentials
    {
        //Replace the placeholders with your Twilio credentials
        public static string AccountSid { get { return "[YOUR_TWILIO_ACCOUNTSID]"; } }
        public static string AuthToken { get { return "[YOUR_TWILIO_AUTHTOKEN]"; } }
    }
}