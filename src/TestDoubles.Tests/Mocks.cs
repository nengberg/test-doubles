using NSubstitute;

using TestDoubles.Implementation;
using TestDoubles.Implementation.Commands;
using TestDoubles.Implementation.Queries;

using Xunit;

namespace TestDoubles {
	public class Mocks {
		private readonly ProductsDashboard sut;
		private readonly ISaveProductCommand saveProductCommand;
		private readonly IAddSubscriberCommand addSubscriberCommand;

		public Mocks() {
			this.saveProductCommand = Substitute.For<ISaveProductCommand>();
			this.addSubscriberCommand = Substitute.For<IAddSubscriberCommand>();
			this.sut = new ProductsDashboard(
				Substitute.For<IGetProductQuery>(),
				this.saveProductCommand,
				this.addSubscriberCommand,
				Substitute.For<IGetProductDiscountQuery>());
		}

		#region Add product
		[Fact]
		public void GivenValidInput_WhenAddingProduct_ShouldAddProductWithThatInformation() {
			const string id = "abc123";

			this.sut.Add(id);

			this.saveProductCommand.Received(1).Execute(id);
		}
		#endregion

		#region Subscription
		[Fact]
		public void GivenPresentEmail_WhenClickingSubscribe_AnActivationEmailShouldBeSentToThatEmail() {
			const string email = "abc@abc.se";

			this.sut.SubscribeToProductUpdates(email);

			this.addSubscriberCommand.Received(1).Execute(email);
		}
		#endregion
	}
}