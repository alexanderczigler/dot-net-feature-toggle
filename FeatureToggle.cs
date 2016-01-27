using System.Collections.Generic;

namespace Ilix.Configuration
{
    public interface IFeatureToggle
    {
        bool Disabled(string feature);
        bool Enabled(string feature);
    }
    
    public class FeatureToggle : IFeatureToggle
    {
        public bool Enabled(string feature)
        {
            if (!FeatureToggles().ContainsKey(feature))
                return false;

            return FeatureToggles()[feature];
        }

        public bool Disabled(string feature)
        {
            return !Enabled(feature);
        }

        private Dictionary<string, bool> FeatureToggles()
        {
            var result = new Dictionary<string, bool>();
            var featureToggles = (System.Collections.Hashtable)System.Configuration.ConfigurationManager.GetSection("FeatureToggles");
            if (featureToggles != null)
            {
                System.Collections.ICollection featureToggleFeatures =
                    ((System.Collections.Hashtable)
                        System.Configuration.ConfigurationManager.GetSection("FeatureToggles")).Keys;
                foreach (string feature in featureToggleFeatures)
                {
                    result.Add(feature, featureToggles[feature].ToString() == "On");
                }
            }
            return result;
        }
    }
}
