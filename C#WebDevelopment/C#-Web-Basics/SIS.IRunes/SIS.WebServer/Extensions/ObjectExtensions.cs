namespace SIS.MvcFramework.Extensions
{
    using Mapping;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Serialization;
    using System.IO;
    using System.Xml.Serialization;

    public static class ObjectExtensions
    {
        public static string ToXml(this object obj)
        {
            using (var stringWriter = new StringWriter())
            {
                var serializer = new XmlSerializer(obj.GetType());
                // TODO : Maybe use the third overload for namespace -> null
                serializer.Serialize(stringWriter, obj);
                return stringWriter.ToString();
            }
        }

        public static string ToJson(this object obj)
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });
        }

        public static TDestination To<TDestination>(this object obj)
        {
            return ModelMapper.ProjectTo<TDestination>(obj);
        }
    }
}
