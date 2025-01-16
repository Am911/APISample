using System.Net.Mail;
using System.Net;
using System.Text;
using APISample.Interface.OTPSender;

namespace APISample.Sevices.OTPSender
{
    public class SOTPSender : IOTPSender
    {
        private readonly IConfiguration _configuration;
        public SOTPSender(IConfiguration configuration)
        {
                this._configuration = configuration;
        }
        public bool sendOtpByMail(string mailFrom, string ToMail, string sub, string body)
        {
            using (MailMessage mail = new MailMessage())
            {

                string? displayName = _configuration["AppSettings:DisplayName"];
                mailFrom = _configuration["AppSettings:smtpUser"];
                mail.To.Add(ToMail.Trim());
                mail.From = new MailAddress(mailFrom, displayName);
                mail.Subject = sub.Trim();
                mail.Body = body.Trim();
                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient())
                {
                    smtp.Host = _configuration["AppSettings:smtpServer"];
                    smtp.Port = Convert.ToInt32(_configuration["AppSettings:smtpPort"]);
                    smtp.EnableSsl = Convert.ToBoolean(_configuration["AppSettings:EnableSsl"]);
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(Convert.ToString(_configuration["AppSettings:smtpUser"]), Convert.ToString(_configuration["AppSettings:PWD"]));
                    smtp.Timeout = 20000;
                    ServicePointManager.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyErrors) =>
                    {
                        Console.WriteLine($"SSL Policy Errors: {sslPolicyErrors}");
                        return true; // Bypass certificate validation
                    };
                    smtp.Send(mail);
                    return true;
                }
            }            

        }

        public long generateOTP()
        {
            Random number = new Random();
            long OTP = number.Next(100000, 999999);
            return OTP;
        }

        public void sendMail(string email)
        {
            StringBuilder mailbody = new StringBuilder(" ");
            mailbody.Append("<html><head></head><body>");
            mailbody.Append("<h3 style='color:green;'>Verification code (OTP)</h3>");
            mailbody.Append("<p>Please use the verification code below to reset password.</p>");
            long gentatedOTP = generateOTP();
            mailbody.Append($"<h4>OTP is : {gentatedOTP}</h4>");
            mailbody.Append("<p>Please do not share with anyone.</p>");
            mailbody.Append("<p>If you didn’t send this request , you can ignore this email. \nThanks</p>");
            bool result = sendOtpByMail("", email.ToString(), " Reset OTP", mailbody.ToString());
        }
    }
}
