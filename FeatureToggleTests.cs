using Xunit;
using System;
using FluentAssertions;
using Ilix.Configuration;

namespace Ilix.Configuration.Test
{
    public class FeatureToggleTests
    {
        private readonly IFeatureToggle _featureToggle;

        public FeatureToggleTests()
        {
            _featureToggle = new FeatureToggle();
        }

        [Fact]
        public void Existing_FeatureToggle_is_true_when_On()
        {
            _featureToggle.Enabled("EnabledFeature").Should().BeTrue();
        }

        [Fact]
        public void Existing_FeatureToggle_is_false_when_Off()
        {
            _featureToggle.Enabled("DisabledFeature").Should().BeFalse();
        }

        [Fact]
        public void Unconfiguraed_FeatureToggle_is_always_false()
        {
            _featureToggle.Enabled(Guid.NewGuid().ToString()).Should().BeFalse();
        }
    }
}
