using System.Configuration;
using HandyConfig.Configuration;

namespace Joyride.Specflow.Configuration
{
    public class CapabilitiesElement : HandyConfigElement
    {
        [ConfigurationProperty("android")]
        public AndroidElement Android { get { return (AndroidElement) this["android"]; } }

        [ConfigurationProperty("ios")]
        public IosElement Ios { get { return (IosElement) this["ios"]; } }        
    }
}