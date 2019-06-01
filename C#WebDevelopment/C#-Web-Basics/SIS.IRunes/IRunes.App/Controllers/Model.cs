using System.Xml.Serialization;

namespace IRunes.App.Controllers
{
    [XmlType]
    public class Model
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("age")]
        public int Age { get; set; }

        [XmlElement("occupation")]
        public string Occupation { get; set; }

        [XmlElement("is-mar")]
        public bool IsMarried { get; set; }
    }
}
