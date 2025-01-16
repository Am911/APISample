using APISample.Interface.OTPSender;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OTPSenderController : ControllerBase
    {
        private readonly IOTPSender otpSender;
        public OTPSenderController(IOTPSender otpSender)
        {
                this.otpSender = otpSender;
        }

        [HttpPost]
        [Route("MailOTP")]
        public IActionResult SendOtpByMail(string email)
        {
            otpSender.sendMail(email);
            return Ok();
        }
    }
}
