using System.Configuration;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace Utility.Configuration
{
    public class XElementAppConfigSectionHandler : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            using (var stringReader = new StringReader(section.OuterXml))
            {
                return XElement.Load(stringReader);
            }
        }
    }
}
