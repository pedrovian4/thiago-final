using Microsoft.AspNetCore.Mvc;

namespace upload_img.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class PostController : ControllerBase 
    {
        [HttpPost]
        public IActionResult Post([FromForm] PostDTO post)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(post);
        }
    }
}
