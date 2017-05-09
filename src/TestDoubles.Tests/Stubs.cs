using NSubstitute;

using Shouldly;

using TestDoubles.Implementation;
using TestDoubles.Implementation.Commands;
using TestDoubles.Implementation.Queries;

using Xunit;

namespace TestDoubles {
	public class Stubs {
		private readonly ProductsDashboard sut;
		private readonly IGetProductDiscountQuery getProductDiscountQuery;

		public Stubs() {
			this.getProductDiscountQuery = Substitute.For<IGetProductDiscountQuery>();

			this.sut = new ProductsDashboard(
				Substitute.For<IGetProductQuery>(),
				Substitute.For<ISaveProductCommand>(),
				Substitute.For<IAddSubscriberCommand>(),
				this.getProductDiscountQuery);
		}

		[Fact]
		public void GivenProductId_WhenFetchingDiscount_DiscountAmountForThatProductShouldBeReturned() {
			const string id = "123";
			const decimal productDiscount = 100;
			this.getProductDiscountQuery.Execute(Arg.Any<string>())
				.Returns(productDiscount);
			const decimal expectedDiscount = productDiscount * 0.5m;

			var result = this.sut.GetDiscountForProduct(id);

			result.ShouldBe(expectedDiscount);
		}
	}
}
