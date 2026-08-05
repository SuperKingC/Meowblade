using System.Collections.Generic;
using Shift.Legion.Common.Managers;
using Shift.Legion.Common.Services;
using UI.UnlockSoldierShow;

public class UnlockSoldierCommandExecutor
{
	private readonly Contexts _contexts;

	public UnlockSoldierCommandExecutor(Contexts contexts)
	{
		_contexts = contexts;
	}

	public void Prepare()
	{
	}

	public void Execute(UnlockSoldierCommand cmd)
	{
		_contexts.gameState.ReplaceUnlockedSoldiers(GameManagers.Instance.UserArchiveManager.GetUnlockedSoldiers());
		OpenShowSoldierPanel(cmd.soldierId, cmd.unlockedProduct);
	}

	private void OpenShowSoldierPanel(string soldierId, List<string> unlockedProductList)
	{
		Dictionary<string, object> dictionary = new Dictionary<string, object>();
		dictionary.Add("SoldierId", soldierId);
		dictionary.Add("UnlockedProductList", unlockedProductList);
		_contexts.Service<IUiService>().OpenPanel(UI_main_NewSoldierPanel.Name, dictionary);
	}
}
