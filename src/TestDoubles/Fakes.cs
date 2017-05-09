using NSubstitute;

using Shouldly;

using TestDoubles.Implementation;
using TestDoubles.Implementation.Commands;
using TestDoubles.Implementation.Queries;

using Xunit;

namespace TestDoubles {
	public class Fakes {
		private readonly ProductsDashboard sut;

		public Fakes() {
			var getProductByIdQuery = new FakeGetProductByIdQuery();
			this.sut = new ProductsDashboard(
				getProductByIdQuery,
				Substitute.For<ISaveProductCommand>(),
				Substitute.For<IAddSubscriberCommand>(),
				Substitute.For<IGetProductDiscountQuery>());
		}

		[Fact]
		public void GivenIdThatMatchesProduct_WhenCallingGetOnProductsDashboard_ReturnsProductMatchingThatId() {
			const string id = "123";

			var result = this.sut.Get(id);

			result.Product.Id.ShouldBe(id);	
		}
	}
}