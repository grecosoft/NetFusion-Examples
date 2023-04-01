using NetFusion.Core.Settings;
using NetFusion.Integration.MongoDB.Plugin.Settings;

namespace Examples.MongoDB.Infra.Repositories;

[ConfigurationSection("netfusion:mongoDB:geographicDB")]
public class GeographicDb : MongoSettings
{

}