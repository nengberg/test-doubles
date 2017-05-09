namespace TestDoubles.Implementation.Queries {
	public interface IGetProductQuery {
		Product Execute(string id);
	}
}