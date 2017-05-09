namespace TestDoubles.Implementation.Queries {
	public interface IGetProductDiscountQuery {
		decimal Execute(string productId);
	}
}