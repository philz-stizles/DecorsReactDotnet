using Decors.Application.Services.Auth;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Decors.API.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("register-customer")]
        public async Task<ActionResult> RegisterCustomer(RegisterCustomer.Command command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("/register-customer-with-verification")]
        public async Task RegisterCustomerWithVerification()
        {

        }

        [HttpGet]
        [Route("/verify-customer")]
        public async Task VerifyCustomer()
        {

        }

        [HttpPost("register-vendor")]
        public async Task<ActionResult> RegisterVendor(RegisterVendor.Command command)
        {
            var result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpPost]
        [Route("/register-business-with-verification")]
        public async Task RegisterBusinessWithVerification()
        {

        }

        [HttpGet]
        [Route("/verify-business")]
        public async Task VerifyBusiness()
        {

        }

        [HttpPost]
        [Route("/login")]
        public async Task<ActionResult> Login(Login.Query query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        [Route("/login-with-cookie")]
        public async Task LoginWithCookie()
        {

        }

        [HttpGet]
        [Route("/current-user")]
        public async Task<ActionResult> CurrentUser(CurrentUser.Query query)
        {
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}
