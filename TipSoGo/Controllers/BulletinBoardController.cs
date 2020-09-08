using System.Web.Http;
using TipSoGo.Models;

namespace TipSoGo.Controllers
{
    public class BulletinBoardController : ApiController
    {
        [HttpGet]
        [Route("API/BulletinBoard/GetAllBulletin")]
        public IHttpActionResult GetAllBulletin()
        {
            BulletinsJson bulletins = new BulletinsJson()
            {
                Status = 200,
                Message = "정상적으로 조회 되었습니다",
                bulletins = WebApiApplication.bulletinBoardViewModel.SelectAllBulletin()
            };

            return Ok(bulletins);
        }
    }
}
