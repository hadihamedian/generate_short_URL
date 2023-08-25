using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShortLink.ApplicationService.ManageLink;

namespace ShortLink.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
        private readonly ManageLinkService _manageLinkService;
        private readonly IConfiguration _configuration;

        public UrlController(ManageLinkService manageLinkService, IConfiguration configuration)
        {
            _manageLinkService = manageLinkService;
            _configuration = configuration;
        }

        [HttpPost("CreateShortUrl")]
        public IActionResult CreateShortUrl(string url)
        {
            var link = _manageLinkService.Create(_configuration["BaseUrl"], url);

            return Ok(link);
        }

        [HttpGet("GetFullUrlAndRedirect")]
        public IActionResult GetFullUrlAndRedirect(string url)
        {
            var link = _manageLinkService.GetValidFullUrl(url);

            return Redirect(link);
        }
    }
}
