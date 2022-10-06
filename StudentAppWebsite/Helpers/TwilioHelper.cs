using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Net;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace StudentAppWebsite.Helpers
{
    public class TwilioHelper
    {
        #region Twilio Message
        public static string SendSms(string To, string Messagebody, string from)
        {
            try
            {
                string accountSid = "ACfff202aa8402d4161074272bb0f6150d";
                string authToken = "0b7cd7903943e216c3bc45b358d1c3ed";

                TwilioClient.Init(accountSid, authToken);

                var message = MessageResource.Create(
                    body: Messagebody,
                    from: new Twilio.Types.PhoneNumber(from),
                    to: new Twilio.Types.PhoneNumber(To)
                );

                //Console.WriteLine(message.Sid);
                return message.Sid;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        #endregion

    }
}