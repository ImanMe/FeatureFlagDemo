using System.Threading.Tasks;
using Microsoft.FeatureManagement;

namespace Logic
{
    public class Logic : ILogic
    {
        private readonly IFeatureManager _featureManager;

        public Logic(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        public async Task<string> MethodA()
        {
            if (await _featureManager.IsEnabledAsync(MyFeatureFlags.FeatureB))
            {
                return "Method A - B is enabled";
            }
            return "Method A - B is disabled";
        }

        public async Task<string> MethodB()
        {
            if (await _featureManager.IsEnabledAsync(MyFeatureFlags.FeatureA))
            {
                return "Method B - A is enabled";
            }
            return "Method B - A is disabled";
        }
    }
}
