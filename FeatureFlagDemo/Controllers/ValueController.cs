using System.Threading.Tasks;
using Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace FeatureFlagDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValueController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;
        private readonly ILogic _logic;

        public ValueController(IFeatureManager featureManager, ILogic logic)
        {
            _featureManager = featureManager;
            _logic = logic;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            if (await _featureManager.IsEnabledAsync(MyFeatureFlags.FeatureA))
            {
                var result1 =_logic.MethodA();
                return Ok(result1);
            }
            var result2 = _logic.MethodB();
            return Ok(result2);
        }
    }
}
