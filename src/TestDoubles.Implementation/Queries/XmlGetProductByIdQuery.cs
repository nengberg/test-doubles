using System.Xml;

namespace TestDoubles.Implementation.Queries {
	public class XmlGetProductByIdQuery : IGetProductQuery {
		public Product Execute(string id) {
			var doc = new XmlDocument();
			doc.Load("filename.xml");
			var element = doc.GetElementById("A111");
			var name = element?.GetAttribute("name");
			return new Product(name);
		}
	}
}