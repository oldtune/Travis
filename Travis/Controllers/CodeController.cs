using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Options;
using Travis.Configurations;
using Travis.Models;

namespace Travis.Controllers
{
    [ApiController]
    public class CodeController : ControllerBase
    {
        readonly CodeConfig _codeConfig;
        readonly IMemoryCache _cache;

        public CodeController(IMemoryCache cache, IOptionsSnapshot<CodeConfig> codeConfig)
        {
            _cache = cache;
            _codeConfig = codeConfig?.Value ?? throw new System.Exception("Missing config for code");
        }

        [HttpGet("")]
        public IActionResult Get()
        {
            var code = _cache.GetOrCreate<Code>("code", cacheEntry =>
            {
                cacheEntry.AbsoluteExpirationRelativeToNow = _codeConfig.ExpireTimeSpan;
                return new Code(_codeConfig.CodeLength);
            });

            return Ok(code);
        }
    }
}
