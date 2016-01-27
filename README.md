# dot-net-feature-toggle
Sample code to demonstrate a simple feature toggle service

1. See App.config on how to configure your project to support the <FeatureToggles /> section.
2. Add one or more toggles to your config.
3. Inject or setup a new instance of the FeatureToggle class, implementing the IFeatureToggle.
4. Use the instance to check whether a given feature is enabled or disabled.

```
namespace Ilix
{
    public class MyService : IMyService
    {
        private readonly IFeatureToggle _featureToggle;

        public MyService(IFeatureToggle featureToggle)
        {
            _featureToggle = featureToggle;
        }
        
        public DoSomething()
        {
            If (_featureToggle.Enabled("MyFeature"))
            {
                // Executed when "MyFeature" is enabled.
            }
        }
    }
}
```
