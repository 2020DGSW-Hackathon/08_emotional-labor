using System.Web.Http;
using TipSoGo.Models;

namespace TipSoGo.Controllers
{
    public class AuthController : ApiController
    {
        [HttpPost]
        [Route("API/Auth/Login")]
        public IHttpActionResult Login([FromBody] UserRecive userRecive)
        {
            bool result = WebApiApplication.authViewModel.Login(userRecive.Id, userRecive.Password);
            if (result)
            {
                return Ok(new Json() { Status = 200, Message = "로그인 성공" });
            }
            else
            {
                return NotFound();
            }
        }
        [HttpPost]
        [Route("API/Auth/Signup")]
        public IHttpActionResult Signup([FromBody]User user)
        {
            bool result = WebApiApplication.authViewModel.Signup(user);
            if (result)
            {
                return Ok(new Json() { Status = 200, Message = "회원가입 성공" });
            }
            else
            {
                return NotFound();
            }
        }
    }
}
