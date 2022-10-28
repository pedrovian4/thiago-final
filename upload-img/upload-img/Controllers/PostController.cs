using Microsoft.AspNetCore.Mvc;
using upload_img.Business;
using upload_img.Model;
using upload_img.Tools;

namespace upload_img.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class PostController : ControllerBase 
    {
        PostBusiness business;
        public PostController(Context context)
        {
            this.business = new PostBusiness(context);
        }

        [HttpPost]
        public IActionResult Post([FromForm] PostDTO post)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            var caminho = ClientFile.CreateLocal(post.Img, post.UserId);
            

            return Ok(business.AdicionarPost(post, caminho));
        }
    }
}
