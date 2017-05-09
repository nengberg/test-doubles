namespace TestDoubles.Implementation.Commands {
	public interface IAddSubscriberCommand {
		void Execute(string email);
	}
}