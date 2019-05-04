using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LetterAvatarService.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;

namespace LetterAvatarService.Controllers {
    [Route("avatars")]
    [ApiController]
    public class AvatarController : ControllerBase {
        private readonly IAvatarService _avatarService;
        private readonly ILogger<AvatarController> _log;

        public AvatarController(IAvatarService avatarService, ILogger<AvatarController> log) {
            _avatarService = avatarService;
            _log = log;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetAvatar(string name) {
            var buffer = await _avatarService.GenerateAvatar(name, AvatarFormat.Png, 512, 275);

            return new FileContentResult(buffer, new MediaTypeHeaderValue("image/png"));
        }

        [HttpGet("thumb/{name}")]
        public async Task<ActionResult> GetAvatarThumb(string name) {
            var buffer = await _avatarService.GenerateAvatar(name, AvatarFormat.Png, 64, 32);

            return new FileContentResult(buffer, new MediaTypeHeaderValue("image/png"));
        }

        [HttpGet("mini/{name}")]
        public async Task<ActionResult> GetAvatarMini(string name) {
            var buffer = await _avatarService.GenerateAvatar(name, AvatarFormat.Png, 32, 16);

            return new FileContentResult(buffer, new MediaTypeHeaderValue("image/png"));
        }

        [HttpGet("svg/{name}")]
        public async Task<ActionResult> GetAvatarSvg(string name) {
            var buffer = await _avatarService.GenerateAvatar(name, AvatarFormat.Svg, 512, 275);

            return new FileContentResult(buffer, new MediaTypeHeaderValue("image/svg+xml"));
        }
    }
}
