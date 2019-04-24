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
        public ActionResult GetAvatar(string name) {
            var buffer = _avatarService.GenerateAvatar(name, 512, 275);

            return new FileContentResult(buffer, new MediaTypeHeaderValue("image/png"));
        }

        [HttpGet("thumb/{name}")]
        public ActionResult GetAvatarThumb(string name) {
            var buffer = _avatarService.GenerateAvatar(name, 64, 32);

            return new FileContentResult(buffer, new MediaTypeHeaderValue("image/png"));
        }

        [HttpGet("mini/{name}")]
        public ActionResult GetAvatarMini(string name) {
            var buffer = _avatarService.GenerateAvatar(name, 32, 16);

            return new FileContentResult(buffer, new MediaTypeHeaderValue("image/png"));
        }
    }
}
