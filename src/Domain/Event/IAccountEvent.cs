namespace Domain.Event
{
	public interface IAccountEvent {
		void Apply(Account account);
	}
}