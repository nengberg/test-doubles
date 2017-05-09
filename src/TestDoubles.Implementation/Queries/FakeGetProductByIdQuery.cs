namespace TestDoubles.Implementation.Queries {
	public class FakeGetProductByIdQuery : IGetProductQuery {
		public Product Execute(string id) {
			return new Product(id);
		}
	}
}