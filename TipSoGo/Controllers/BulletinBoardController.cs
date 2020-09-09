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

        [HttpGet]
        [Route("API/BulletinBoard/InsertBulletin")]
        public IHttpActionResult InsertBulletin([FromBody] Bulletin b)
        {
            bool result = WebApiApplication.bulletinBoardViewModel.InsertBulletin(b);
            if (result)
            {
                return Ok(new Json() { Status = 200, Message = "정상적으로 삽입 되었습니다." });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("API/BulletinBoard/GetComments")]
        public IHttpActionResult GetComments([FromUri] int idx)
        {
            var result = WebApiApplication.bulletinBoardViewModel.GetComments(idx);
            if (result != null)
            {
                return Ok(new CommentsJson()
                {
                    Status = 200,
                    Message = "성공적으로 조회 되었습니다.",
                    comments = result
                });
            }
            else
            {
                return NotFound();
            }
        }
        [HttpGet]
        [Route("API/BulletinBoard/InsertComment")]
        public IHttpActionResult InsertComment([FromBody] Comment c)
        {
            bool result = WebApiApplication.bulletinBoardViewModel.InsertComment(c);
            if (result)
            {
                return Ok(new Json() { Status = 200, Message = "성공적으로 삽입 되었습니다." });
            }
            else
            {
                return NotFound();
            }
        }
    }
}