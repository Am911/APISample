namespace APISample.Interface.OTPSender
{
    public interface IOTPSender
    {
        bool sendOtpByMail(string mailFrom, string ToMail, string sub, string body);
        long generateOTP();
        void sendMail(string email);
    }
}
