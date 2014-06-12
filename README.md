# AutoStuff Workforce Automation #

AutoStuff demonstrates a simple workforce automation solution powered by [Twilo](http://twilio.com) SMS.  In this example a manager can view unfilled shifts and send out text message notifications to notify employees of available shifts.  Employees can volunteer to fill the open shift by replying to the text message.  The first employee to reply is assigned to the shift.

![](http://i.imgur.com/frYVEOG.jpg)

## Setting up the Project ##
The AutoStuff application is an ASP.NET MVC 5 application created in Visual Studio 2013.  Once you have downloaded the source code and opened the solution in Visual Studio you will need to make the following configuration changes to the app:

- Twilio Account - If you do not already have one, you will need to [sign up for a Twilio account](http://twilio.com/try-twilio).

- Twilio Credentials - In `Credentials.cs` you will need to replace the placeholder values with your Twilio credentials:

        //Replace the placeholders with your Twilio credentials
        public static string AccountSid { get { return "[YOUR_TWILIO_ACCOUNTSID]"; } }
        public static string AuthToken { get { return "[YOUR_TWILIO_AUTHTOKEN]"; } }

- Caller ID - In `HomeController.cs` you will need to replace the placeholder in the `callerid` variable with your Twilio phone number:

        const string callerid = "[PUT_YOUR_TWILIO_PHONE_NUMBER_HERE]";

- Employee Phone Number - In `EmployeeRepository.cs`, in order to receive the outbound text messages, replace the employee phone number with a valid phone number:

        _instance.Insert(
            new Employee() { 
                ID=23473, AvailableShiftsNotificationSmsOptIn = true, 
                PhoneNumber = "[REPLACE_WITH_A_VALID_PHONE_NUMBER]" 
            });
