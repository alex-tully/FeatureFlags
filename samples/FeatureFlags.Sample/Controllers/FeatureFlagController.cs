using Microsoft.AspNetCore.Mvc;

namespace FeatureFlags.Sample.Controllers
{
    [Route("/feature-flags")]
    public class FeatureFlagController : Controller
    {
        private readonly IFeatureFlag _featureFlag;

        public FeatureFlagController(IFeatureFlag featureFlag)
        {
            _featureFlag = featureFlag;
        }

        [HttpGet(Name = "default")]
        [Route("~/")]
        public IActionResult Index()
        {
            return Ok("Please navigate to /feature-flags/{flag} to find out if a flag is enabled or disabled.");
        }

        [HttpGet("{flag}")]
        public IActionResult Index(string flag)
        {
            return Ok($"Feature Flag: {flag} enabled = {_featureFlag.IsEnabled(flag)}");
        }
    }
}
