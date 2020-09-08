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
        [HttpGet]
        [Route("API/BulletinBoard/GetBulletin")]
        public IHttpActionResult GetBulletin([FromUri] int idx)
        {
            Bulletin b = new BulletinJson(WebApiApplication.bulletinBoardViewModel.SelectBulletin(idx));
            BulletinJson bulletin = new BulletinJson(b)
            {
                Status = 200,
                Message = "정상적으로 조회 되었습니다",
            };

            return Ok(bulletin);
        }
    }
}
