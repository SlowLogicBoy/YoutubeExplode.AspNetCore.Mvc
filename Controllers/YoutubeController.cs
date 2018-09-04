using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace AspNetYoutubeExplode.Controllers
{
    [Route("Youtube")]
    public class YoutubeController : ControllerBase
    {
        [HttpGet("Download/{id}")] //request example: http://localhost:5000/Youtube/Download/jgW7w-SCnAs
        public async Task<IActionResult> DownloadAudioAsync(string id)
        {
            //TODO: validate id
            var client = new YoutubeClient(); //This should be initialized in YoutubeController constructor.
            var mediaInfoSet = await client.GetVideoMediaStreamInfosAsync(id);
            var mediaStreamInfo = mediaInfoSet.Audio.WithHighestBitrate();
            var mimeType = $"audio/{mediaStreamInfo.Container.GetFileExtension()}";
            var fileName = $"{id}.{mediaStreamInfo.Container.GetFileExtension()}";
            return File(await client.GetMediaStreamAsync(mediaStreamInfo), mimeType, fileName);
        }
    }
}
