using System.Xml.Serialization;

namespace FastFood.DataProcessor.Dto.Export
{
    [XmlType("Category")]
    public class CategoryDtoXml
    {
        public string Name { get; set; }

        public MostPopularItemDtoXml MostPopularItem { get; set; }
    }
}
