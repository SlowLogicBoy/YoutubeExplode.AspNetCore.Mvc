using Microsoft.AspNetCore.Mvc;
using YoutubeExplode;

namespace AspNetYoutubeExplode.Controllers
{
    [Route("Youtube")]
    public class YoutubeController : Controller
    {
        [HttpGet("Download/{id}")] //request example: http://localhost:5000/Youtube/Download/jgW7w-SCnAs
        public IActionResult DownloadAudio(string id)
        {
            //TODO: validate id
            var client = new YoutubeClient(); //This should be initialized in YoutubeController constructor.
            return new StreamYoutubeVideo(client, id);
        }
    }
}