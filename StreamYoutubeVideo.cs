using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using YoutubeExplode;
using YoutubeExplode.Models.MediaStreams;

namespace AspNetYoutubeExplode
{
    public class StreamYoutubeVideo : ActionResult
    {
        private readonly IYoutubeClient _client;
        private readonly string _videoId;
        public StreamYoutubeVideo(IYoutubeClient client, string videoId)
        {
            _client = client;
            _videoId = videoId;
        }
        public override async Task ExecuteResultAsync(ActionContext context)
        {
            var mediaInfoSet = await _client.GetVideoMediaStreamInfosAsync(_videoId);
            var mediaStreamInfo = mediaInfoSet.Audio.WithHighestBitrate();
            context.HttpContext.Response.Headers.Add("Content-Disposition", $"attachment;filename={_videoId}.{mediaStreamInfo.Container.GetFileExtension()}");
            context.HttpContext.Response.Headers.Add("Content-Type", $"audio/{mediaStreamInfo.Container.GetFileExtension()}");
            await _client.DownloadMediaStreamAsync(mediaStreamInfo, context.HttpContext.Response.Body);
        }
    }
}