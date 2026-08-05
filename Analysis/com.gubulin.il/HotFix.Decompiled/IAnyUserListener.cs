using Shift.Legion.ClientApi.Protocol;

public interface IAnyUserListener
{
	void OnAnyUser(GameStateEntity entity, User value);
}
