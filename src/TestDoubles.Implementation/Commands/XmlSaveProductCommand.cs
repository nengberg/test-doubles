using System.Xml;

namespace TestDoubles.Implementation.Commands {
	public class XmlSaveProductCommand : ISaveProductCommand {
		public void Execute(string id) {
			var doc = new XmlDocument();
			doc.Load("filename.xml");
			var node = doc.CreateNode(XmlNodeType.Element, "Product", null);
			node.InnerText = id;
			doc.AppendChild(node);
		}
	}
}