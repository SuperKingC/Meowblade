using Assets.Scripts.Managers;
using Shift.Legion.ClientApi.Protocol;
using Shift.Legion.Common.Services;

public class LoginCompleteCommandExecutor
{
	private readonly Contexts _contexts;

	public LoginCompleteCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute(LoginCompleteCommand cmd)
	{
		User user = cmd.user;
		if (user != null)
		{
			_contexts.Service<INetworkService>().GetAnnouncements();
			_contexts.gameState.ReplaceUser(user);
			LoadUserData(user.UserId);
			SharedMessenger.Broadcast("LOGIN_SUCCESS");
		}
		else
		{
			SharedMessenger.Broadcast("LOGIN_FAIL", LanguagesManager.GetDesc("CsharpCodeZhTcText67"));
		}
	}

	private void LoadUserData(int userId)
	{
		_contexts.Service<IGameDataService>().StartLoadGameData();
		_contexts.Service<IGameDataService>().StartLoadUserArchive(userId);
	}
}
