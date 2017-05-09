using System;

using TestDoubles.Implementation.Commands;
using TestDoubles.Implementation.Queries;

namespace TestDoubles.Implementation {
	public class ProductsDashboard {
		private readonly ISaveProductCommand saveProductCommand;
		private readonly IGetProductQuery getProductByIdQuery;
		private readonly IAddSubscriberCommand addSubscriberCommand;
		private readonly IGetProductDiscountQuery getProductDiscountQuery;

		public ProductsDashboard(
			IGetProductQuery getProductByIdQuery,
			ISaveProductCommand saveProductCommand,
			IAddSubscriberCommand addSubscriberCommand,
			IGetProductDiscountQuery getProductDiscountQuery) {
			this.saveProductCommand = saveProductCommand ?? throw new ArgumentNullException(nameof(saveProductCommand));
			this.getProductByIdQuery = getProductByIdQuery ?? throw new ArgumentNullException(nameof(getProductByIdQuery));
			this.addSubscriberCommand = addSubscriberCommand ?? throw new ArgumentNullException(nameof(addSubscriberCommand));
			this.getProductDiscountQuery = getProductDiscountQuery ?? throw new ArgumentNullException(nameof(getProductDiscountQuery));
		}

		public ProductPageViewModel Get(string id) {
			var model = new ProductPageViewModel();
			model.Heading = "Product list";
			model.Product = this.getProductByIdQuery.Execute(id);
			return model;
		}

		public void Add(string id) {
			//omitted validation
			this.saveProductCommand.Execute(id);
		}

		public void SubscribeToProductUpdates(string email) {
			//omitted validation
			this.addSubscriberCommand.Execute(email);
		}

		public decimal GetDiscountForProduct(string productId) {
			var productDiscount = this.getProductDiscountQuery.Execute(productId);
			return productDiscount * 0.5m;
		}
	}
}