using AutoStuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Twilio;
using Twilio.TwiML;
using Twilio.TwiML.Mvc;

namespace AutoStuff.Controllers
{
    public class HomeController : TwilioController
    {
        const string callerid = "[PUT_YOUR_TWILIO_PHONE_NUMBER_HERE]";

        EmployeeRepository _employeeRepository;
        ShiftRepository _shiftRepository;

        public HomeController()
        {
            _employeeRepository = EmployeeRepository.Instance;
            _shiftRepository = ShiftRepository.Instance;;
        }

        public ActionResult Index()
        {
            return View(new OpenShiftsViewModel());
        }

        public ActionResult SendShiftFillAlert(int shiftID)
        {
            var client = new TwilioRestClient(Credentials.AccountSid, Credentials.AuthToken);

            var optinEmployees = _employeeRepository.Select().Where(e => e.AvailableShiftsNotificationSmsOptIn == true);
            var openShift = _shiftRepository.Select().Where(s => s.ID == shiftID).FirstOrDefault();

            var message = string.Format(
                "An open shift starting at {0} and ending at {1} is available on {2}.  To fill this open shift reply with the message: 'yes {3}'",
                openShift.StartTime.ToShortTimeString(),
                openShift.EndTime.ToShortTimeString(),
                openShift.StartTime.ToShortDateString(),
                openShift.ID);

            int sentMessageCounter = 0;
            foreach (var employee in optinEmployees)
            {
                var result = client.SendMessage(callerid, employee.PhoneNumber, message);
                if (result.RestException != null)
                {
                    //TODO: log this error
                }
                {
                    sentMessageCounter++;
                }
            }

            return Json(new { shiftid = openShift.ID, messagesSentCount = sentMessageCounter });
        }

        public ActionResult AcceptOpenShift(string From, string Body)
        {
            var response = new TwilioResponse();

            var employee = _employeeRepository.Select().Where(e => e.PhoneNumber == From).FirstOrDefault();
            if (employee == null)
            {
                return TwiML(response);
            }

            //parse and process sms message body
            var parameters = Body.Split(' ');
            if (parameters.Count() < 2)
            {
                response.Message("Whoops.  Not sure what that command was.  Try again.");
            }

            if (parameters[0].ToLower() == "yes")
            {
                var openShift = _shiftRepository.Select().Where(s => s.ID.ToString() == parameters[1]).FirstOrDefault();

                if (openShift.AssignedEmployee == null)
                {
                    openShift.AssignedEmployee = employee;
                    _shiftRepository.Update(openShift);
                    _shiftRepository.Save();

                    var message = string.Format(
                        "Awesome.  Thanks for stepping up.  See you on {0} at {1}",
                        openShift.StartTime.ToLongDateString(),
                        openShift.StartTime.ToShortTimeString()
                        );

                    response.Message(message);

                }
                else
                {
                    response.Message("Ohhh, so close.  Try again next time");
                }
            }

            return TwiML(response);
        }

    }
}
; 