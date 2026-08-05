using HotFix.Sources.Base.Sources.Scripts.GvG3UI.Model;
using UI.GvGExpeditionHall;

namespace HotFix.Sources.Base.Sources.Scripts.GvG3UI.Interface;

public interface IGvGExpeditionPopup
{
	void Init(GvGExpeditionHallModel data, UI_GvGExpeditionHallPanel parentPanel);

	void RegisterUiEventListeners();

	void UnregisterUiEventListeners();

	void OnActivate();

	void OnInactivate();
}
